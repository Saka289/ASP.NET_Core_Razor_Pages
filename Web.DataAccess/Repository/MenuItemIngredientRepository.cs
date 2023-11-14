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
    public class MenuItemIngredientRepository : Repository<MenuItemIngredient>, IMenuItemIngredientRepository
    {

        private readonly ApplicationDbContext _context;
        public MenuItemIngredientRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(MenuItemIngredient menuItemIngredient)
        {
            var queryFromDB = _context.MenuItemIngredients.FirstOrDefault(m => m.Id == menuItemIngredient.Id);
            if (queryFromDB != null)
            {
                queryFromDB.IngredientId = menuItemIngredient.Id;
                queryFromDB.MenuItemId = menuItemIngredient.Id;
            }
        }
    }
}
