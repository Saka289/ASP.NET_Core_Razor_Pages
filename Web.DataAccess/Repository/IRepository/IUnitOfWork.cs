using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }

        IFoodtypeRepository FoodType { get; }

        IMenuItemRepository MenuItem { get; }

        IShoppingCartRepository ShoppingCart { get; }

        void Save();
    }
}
