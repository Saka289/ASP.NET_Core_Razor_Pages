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
    public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
    {
        private readonly ApplicationDbContext _context;
        public MenuItemRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(MenuItem menuItem)
        {
            var queryMenuItem = _context.MenuItem.FirstOrDefault(m => m.Id == menuItem.Id);
            if (queryMenuItem != null)
            {
                queryMenuItem.Name = menuItem.Name;
                queryMenuItem.Description = menuItem.Description;
                queryMenuItem.Price = menuItem.Price;
                queryMenuItem.CategoryId = menuItem.CategoryId;
                queryMenuItem.FoodTypeId = menuItem.FoodTypeId;
                if (queryMenuItem.Image != null)
                {
                    queryMenuItem.Image = menuItem.Image;
                }
            }
        }
    }
}
