using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.DataAccess.Repository.IRepository;
using Web.Models;

namespace WebApp.Pages.Admin.Ingredient
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public Web.Models.Ingredient Ingredient { get; set; }

        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet(int id)
        {
            Ingredient = _unitOfWork.Ingredient.GetFirstOrDefault(i => i.Id == id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (Ingredient.ExpirationDate < DateTime.Now)
            {
                ModelState.AddModelError("Ingredient.ExpirationDate", "The expiration date must be greater than the current date");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Ingredient.Update(Ingredient);
                _unitOfWork.Save();
                TempData["success"] = "Ingredient updated successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
