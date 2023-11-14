using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.DataAccess.Repository.IRepository;
using Web.Models;
using Web.Utility;

namespace WebApp.Pages.Admin.Ingredient
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IEnumerable<Web.Models.Ingredient> Ingredients { get; set; }

        public PaginatedList<Web.Models.Ingredient> IngredientsPaging { get; set; }

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet(int? pageIndex)
        {
            int pageSize = 5;
            IngredientsPaging = PaginatedList<Web.Models.Ingredient>.Create(_unitOfWork.Ingredient.GetAll(), pageIndex ?? 1, pageSize);
            Ingredients = IngredientsPaging;
        }
    }
}
