using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RMT_API.Migrations
{
    /// <inheritdoc />
    public partial class firstmigration_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_ContactInformation_ContactInformationID",
                table: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_ContactInformationID",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "ContactInformationID",
                table: "Supplier");

            migrationBuilder.AddColumn<int>(
                name: "SupplierID",
                table: "ContactInformation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ResourceCode",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: false,
                computedColumnSql: "CONCAT('RES', RIGHT('10000' + CAST(ID AS VARCHAR), 5))",
                stored: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProjectCode",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                computedColumnSql: "CONCAT('PROJ', RIGHT('10000' + CAST(ID AS VARCHAR), 5))",
                stored: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_ResourceInformationID",
                table: "Resources",
                column: "ResourceInformationID",
                unique: true,
                filter: "[ResourceInformationID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInformation_SupplierID",
                table: "ContactInformation",
                column: "SupplierID");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInformation_Supplier_SupplierID",
                table: "ContactInformation",
                column: "SupplierID",
                principalTable: "Supplier",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactInformation_Supplier_SupplierID",
                table: "ContactInformation");

            migrationBuilder.DropIndex(
                name: "IX_Resources_ResourceInformationID",
                table: "Resources");

            migrationBuilder.DropIndex(
                name: "IX_ContactInformation_SupplierID",
                table: "ContactInformation");

            migrationBuilder.DropColumn(
                name: "ResourceCode",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "SupplierID",
                table: "ContactInformation");

            migrationBuilder.AddColumn<int>(
                name: "ContactInformationID",
                table: "Supplier",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProjectCode",
                table: "Projects",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComputedColumnSql: "CONCAT('PROJ', RIGHT('10000' + CAST(ID AS VARCHAR), 5))");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_ContactInformationID",
                table: "Supplier",
                column: "ContactInformationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_ContactInformation_ContactInformationID",
                table: "Supplier",
                column: "ContactInformationID",
                principalTable: "ContactInformation",
                principalColumn: "ID");
        }
    }
}
