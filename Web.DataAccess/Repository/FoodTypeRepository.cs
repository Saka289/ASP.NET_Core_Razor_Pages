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
    public class FoodTypeRepository : Repository<FoodType>, IFoodtypeRepository
    {
        private readonly ApplicationDbContext _context;
        public FoodTypeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(FoodType foodType)
        {
            var queryFromDb = _context.FoodType.FirstOrDefault(f => f.Id == foodType.Id);
            if (queryFromDb != null)
            {
                queryFromDb.Name = foodType.Name;
            }
        }
    }
}
