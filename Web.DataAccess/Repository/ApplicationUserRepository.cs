using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.DataAccess.Repository.IRepository;
using Web.DataAccesss.Data;
using Web.Models;

namespace Web.DataAccess.Repository
{
	public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
	{
		private readonly ApplicationDbContext _context;
		public ApplicationUserRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}
	}
}
