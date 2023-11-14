using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.DataAccess.Repository.IRepository;
using Web.Models;

namespace WebApp.Pages.Admin.Ingredient
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public Web.Models.Ingredient Ingredient { get; set; }


        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> OnPost()
        {
            if (Ingredient.ExpirationDate < DateTime.Now)
            {
                ModelState.AddModelError("Ingredient.ExpirationDate", "The expiration date must be greater than the current date");
            }
            if (ModelState.IsValid)
            {
                Ingredient.ImportDate = DateTime.Now;
                _unitOfWork.Ingredient.Add(Ingredient);
                _unitOfWork.Save();
                TempData["success"] = "Ingredient created successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
