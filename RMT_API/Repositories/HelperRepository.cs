using Microsoft.EntityFrameworkCore;
using RMT_API.Data;
using RMT_API.Models;

namespace RMT_API.Repositories
{
	public class HelperRepository(ApplicationDBContext context) : IHelperRepository
	{
		public async Task<IEnumerable<FormMaster>> GetLeftNavItemsByRoleIdAsync(int id)
		{
			var result =await context.FormMaster
						.Join(context.FormAccess, fm => fm.ID, fa => fa.FormID, (fm, fa) => new { fm, fa })
						.Join(context.AccessTypeMaster, temp => temp.fa.AccessTypeID, atm => atm.ID, (temp, atm) => new { temp.fm, temp.fa, atm })
						.Where(temp => temp.fa.AccessTypeID == id)
						.OrderBy(temp => temp.fm.Name)
						.Select(temp => temp.fm)
						.ToListAsync();

			return result;
		}
	}
}
