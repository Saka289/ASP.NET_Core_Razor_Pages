using Microsoft.AspNetCore.Mvc;
using Web.DataAccess.Repository.IRepository;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IWebHostEnvironment _hostEnvironment;

        public MenuItemController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var menuItemList = _unitOfWork.MenuItem.GetAll(includeProperties: "Category,FoodType");
            return Json(new { data = menuItemList });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.MenuItem.GetFirstOrDefault(m => m.Id == id);
            if (objFromDb != null)
            {
                //delete the old image
                var oldImagPath = Path.Combine(_hostEnvironment.WebRootPath, objFromDb.Image.TrimStart('\\'));
                if (System.IO.File.Exists(oldImagPath))
                {
                    System.IO.File.Delete(oldImagPath);
                }
                _unitOfWork.MenuItem.Remove(objFromDb);
                _unitOfWork.Save();
            }
            return Json(new { success = true, message = "Delete success." });
        }
    }
}
