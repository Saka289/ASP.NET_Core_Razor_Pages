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
    public class IngredientRepository : Repository<Ingredient>, IIngredientRepository
    {

        private readonly ApplicationDbContext _context;
        public IngredientRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Ingredient ingredient)
        {
            var queryFromDB = _context.Ingredient.FirstOrDefault(i => i.Id == ingredient.Id);
            if (queryFromDB != null)
            {
                queryFromDB.Name = ingredient.Name;
                queryFromDB.Price = ingredient.Price;
                queryFromDB.ImportDate = DateTime.Now;
                queryFromDB.Quantity = ingredient.Quantity;
            }
        }

        public void UpdateQuatity(int Id)
        {
            var queryFromDB = _context.Ingredient.FirstOrDefault(i => i.Id == Id);
            if (queryFromDB != null)
            {
                queryFromDB.Quantity = queryFromDB.Quantity - 1;
            }
        }
    }
}
