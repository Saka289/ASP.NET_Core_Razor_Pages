using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Stripe;
using System.Security.Claims;
using Web.DataAccess.Repository;
using Web.DataAccess.Repository.IRepository;
using Web.Models;

namespace WebApp.Pages.Admin.DishIngredient
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public MenuItemIngredient MenuItemIngredient { get; set; }

        public IEnumerable<SelectListItem> MenuItemList { get; set; }

        public IEnumerable<Web.Models.Ingredient> IngredientList { get; set; }

        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet()
        {
            MenuItemList = _unitOfWork.MenuItem.GetAll().Select(m => new SelectListItem
            {
                Value = m.Id.ToString(),
                Text = m.Name
            });
            IngredientList = _unitOfWork.Ingredient.GetAll();
        }

        public IActionResult OnPost()
        {
            MenuItemList = _unitOfWork.MenuItem.GetAll().Select(m => new SelectListItem
            {
                Value = m.Id.ToString(),
                Text = m.Name
            });
            IngredientList = _unitOfWork.Ingredient.GetAll();
            var selectedIngredients = Request.Form["ingredientList"];
            if (!selectedIngredients.Any())
            {
                ModelState.AddModelError("MenuItemIngredient.IngredientId", "The Ingredients field is required.");
            }
            var listIngredient = _unitOfWork.MenuItemIngredient.GetAll(filter: m => m.MenuItemId == MenuItemIngredient.MenuItemId);
            bool hasCommonValues = listIngredient.Select(x => x.IngredientId.ToString()).Intersect(selectedIngredients).Any();
            if (hasCommonValues)
            {
                ModelState.AddModelError("MenuItemIngredient.IngredientId", "Ingredients do not overlap each other");
            }
            if (ModelState.IsValid)
            {
                foreach (var item in selectedIngredients.ToList())
                {
                    MenuItemIngredient menuItemIngredient = new()
                    {
                        MenuItemId = MenuItemIngredient.MenuItemId,
                        IngredientId = Convert.ToInt32(item)
                    };
                    _unitOfWork.MenuItemIngredient.Add(menuItemIngredient);
                    _unitOfWork.Save();
                }
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
