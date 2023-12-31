using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.DataAccess.Repository.IRepository;
using Web.DataAccesss.Data;
using Web.Models;
using Web.Utility;

namespace WebApp.Pages.Admin.FoodTypes
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IEnumerable<FoodType> FoodTypes { get; set; }

        public PaginatedList<FoodType> FoodTypePaging { get; set; }

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet(int? pageIndex)
        {
            int pageSize = 5;
            FoodTypePaging = PaginatedList<FoodType>.Create(_unitOfWork.FoodType.GetAll(), pageIndex ?? 1, pageSize);
            FoodTypes = FoodTypePaging;
        }
    }
}
