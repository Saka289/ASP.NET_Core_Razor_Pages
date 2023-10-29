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
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _context;

		public UnitOfWork(ApplicationDbContext context)
		{
			_context = context;
			Category = new CategoryRepository(_context);
			FoodType = new FoodTypeRepository(_context);
			MenuItem = new MenuItemRepository(_context);
			ShoppingCart = new ShoppingCartRepository(_context);
			OrderHeader = new OrderHeaderRepository(_context);
			OrderDetails = new OrderDetailsRepository(_context);
			ApplicationUser = new ApplicationUserRepository(_context);
		}

		public ICategoryRepository Category { get; private set; }

		public IFoodtypeRepository FoodType { get; private set; }

		public IMenuItemRepository MenuItem { get; private set; }

		public IShoppingCartRepository ShoppingCart { get; private set; }

		public IOrderHeaderRepository OrderHeader { get; private set; }

		public IOrderDetailsRepository OrderDetails { get; private set; }

		public IApplicationUserRepository ApplicationUser { get; private set; }

		public void Dispose()
		{
			_context.Dispose();
		}

		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
