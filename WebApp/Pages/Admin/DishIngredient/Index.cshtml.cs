using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing.Printing;
using Web.DataAccess.Repository.IRepository;
using Web.Models;
using Web.Utility;

namespace WebApp.Pages.Admin.DishIngredient
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IEnumerable<MenuItem> MenuItemList { get; set; }

        public IEnumerable<MenuItemIngredient> DishIngredientList { get; set; }

        public PaginatedList<MenuItem> MenuItemPaging { get; set; }

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet(int? pageIndex)
        {
            int pageSize = 5;
            MenuItemList = _unitOfWork.MenuItem.GetAll();
            DishIngredientList = _unitOfWork.MenuItemIngredient.GetAll(includeProperties: "MenuItem,Ingredient");
            MenuItemPaging = PaginatedList<MenuItem>.Create(_unitOfWork.MenuItem.GetAll(), pageIndex ?? 1, pageSize);
            MenuItemList = MenuItemPaging;
        }
    }
}
