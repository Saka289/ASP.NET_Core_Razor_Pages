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
	public class OrderDetailsRepository : Repository<OrderDetails>, IOrderDetailsRepository
	{
		private readonly ApplicationDbContext _context;

		public OrderDetailsRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}

		public void Update(OrderDetails orderDetails)
		{
			_context.OrderDetails.Update(orderDetails);
		}
	}
}
