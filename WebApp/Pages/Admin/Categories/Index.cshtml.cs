using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.DataAccess.Repository;
using Web.DataAccess.Repository.IRepository;
using Web.Models;
using Web.Utility;

namespace WebApp.Pages.Admin.Categories
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IEnumerable<Category> Categories { get; set; }

        public PaginatedList<Category> CategoryPaging { get; set; }

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet(int? pageIndex)
        {
            int pageSize = 5;
            CategoryPaging = PaginatedList<Category>.Create(_unitOfWork.Category.GetAll(), pageIndex ?? 1, pageSize);
            Categories = CategoryPaging;
        }
    }
}
