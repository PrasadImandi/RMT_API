using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RMT_API.Data;
using RMT_API.Infrastructure;
using RMT_API.Middleware;
using RMT_API.Services;
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddServices();

string sasUrl = builder.Configuration.GetValue<string>("BlobSasUrl") ?? "";
builder.Services.AddScoped<IBlobStorageService>(provider =>
{
	return new BlobStorageService(sasUrl);
});

builder.Services.AddCors(options =>
{

	var allowedOrigins = builder.Configuration.GetSection("CorsSettings:AllowOrigins").Get<string[]>();

	options.AddPolicy("AllowAll", builder => builder.WithOrigins(allowedOrigins ?? []).AllowAnyMethod()
																				.AllowAnyHeader()
																				.AllowCredentials());
});
builder.Services.AddAutoMapper(typeof(Automapper).Assembly);


builder.Services.AddControllers()
 .AddJsonOptions(options =>
 {
	 // Apply CamelCase property names globally
	 options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;

	 // Optionally, configure null value handling
	 options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
 });

builder.Services.Configure<FormOptions>(options =>
{
	options.MultipartBodyLengthLimit = Convert.ToInt64(builder.Configuration["BlobFileLength"]);
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(options =>
	{
		options.RequireHttpsMetadata = false;
		options.SaveToken = true;
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = true,
			ValidateAudience = true,
			ValidateIssuerSigningKey = true,
			ValidateLifetime = true,
			ClockSkew = TimeSpan.Zero, // Optional: No clock skew (adjust as needed)
			ValidIssuer = builder.Configuration["Jwt:Issuer"],
			ValidAudience = builder.Configuration["Jwt:Audience"],
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]))
		};
	});

builder.Services.AddAuthorization();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
// Add authentication middleware
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
