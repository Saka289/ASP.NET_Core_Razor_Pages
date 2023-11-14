using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.DataAccess.Repository.IRepository;

namespace WebApp.Pages.Admin.Ingredient
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public Web.Models.Ingredient Ingredient { get; set; }

        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet(int id)
        {
            Ingredient = _unitOfWork.Ingredient.GetFirstOrDefault(u => u.Id == id);
        }

        public async Task<IActionResult> OnPost()
        {
            var ingredientFromDb = _unitOfWork.Ingredient.GetFirstOrDefault(c => c.Id == Ingredient.Id);
            if (ingredientFromDb != null)
            {
                _unitOfWork.Ingredient.Remove(ingredientFromDb);
                _unitOfWork.Save();
                TempData["success"] = "Ingredient deleted successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
