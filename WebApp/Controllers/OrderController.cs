using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Web.DataAccess.Repository.IRepository;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
           var OrderHeaderList = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser");
            return Json(new {data = OrderHeaderList});
        }
    }
}
