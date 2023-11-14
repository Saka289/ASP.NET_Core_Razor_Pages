using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.DataAccess.Repository.IRepository;
using Web.Models;

namespace WebApp.Pages.Admin.DishIngredient
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public MenuItemIngredient MenuItemIngredient { get; set; }

        public IEnumerable<SelectListItem> MenuItemList { get; set; }

        public IEnumerable<Web.Models.Ingredient> IngredientList { get; set; }

        [BindProperty]
        public IEnumerable<int> SelectedIngredients { get; set; }

        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            MenuItemIngredient = new();
        }

        public void OnGet(int id)
        {
            MenuItemIngredient = _unitOfWork.MenuItemIngredient.GetFirstOrDefault(m => m.MenuItemId == id);
            SelectedIngredients = _unitOfWork.MenuItemIngredient.GetAll(filter: m => m.MenuItemId == id).Select(m => m.IngredientId).ToList();
            MenuItemList = _unitOfWork.MenuItem.GetAll().Select(m => new SelectListItem
            {
                Value = m.Id.ToString(),
                Text = m.Name
            });
            IngredientList = _unitOfWork.Ingredient.GetAll();
        }
    }
}
