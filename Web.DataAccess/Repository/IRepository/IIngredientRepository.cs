using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Models;

namespace Web.DataAccess.Repository.IRepository
{
    public interface IIngredientRepository : IRepository<Ingredient>
    {
        void Update(Ingredient ingredient);

        void UpdateQuatity(int Id);
    }
}
