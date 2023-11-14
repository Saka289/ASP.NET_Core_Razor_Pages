using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Web.DataAccess.Repository.IRepository;
using Web.Models;
using Web.Models.ViewModel;
using Web.Utility;

namespace WebApp.Pages.Admin.Order
{
    [Authorize(Roles = $"{SD.ManagerRole}, {SD.KitchenRole}")]
    public class ManageOrderModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public List<OrderDetailVM> OrderDetailVM { get; set; }
        public ManageOrderModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
            OrderDetailVM = new();

            List<OrderHeader> orderHeaders = _unitOfWork.OrderHeader.GetAll(u => u.Status == SD.StatusSubmitted || u.Status == SD.StatusInProcess).ToList();
            foreach (OrderHeader item in orderHeaders)
            {
                OrderDetailVM individual = new OrderDetailVM()
                {
                    OrderHeader = item,
                    OrderDetails = _unitOfWork.OrderDetails.GetAll(u => u.OrderId == item.Id).ToList()
                };
                OrderDetailVM.Add(individual);
            }
        }

        public IActionResult OnPostOrderInProcess(int orderId)
        {
            _unitOfWork.OrderHeader.UpdateStatus(orderId, SD.StatusInProcess);
            _unitOfWork.Save();
            return RedirectToPage("ManageOrder");
        }
        public IActionResult OnPostOrderReady(int orderId)
        {
            _unitOfWork.OrderHeader.UpdateStatus(orderId, SD.StatusReady);
            _unitOfWork.Save();
            var ListMenuItem = _unitOfWork.OrderDetails.GetAll(filter: o => o.OrderId == orderId).Select(m => m.MenuItemId).ToList();
            foreach (var item in ListMenuItem)
            {
                var listIngredient = _unitOfWork.MenuItemIngredient.GetAll(filter: m => m.MenuItemId == item).Select(m => m.IngredientId).ToList();
                if (listIngredient != null)
                {
                    foreach (var itemIngredient in listIngredient)
                    {
                        _unitOfWork.Ingredient.UpdateQuatity(itemIngredient);
                        _unitOfWork.Save();
                    }
                }
            }
            return RedirectToPage("ManageOrder");
        }
        public IActionResult OnPostOrderCancel(int orderId)
        {
            _unitOfWork.OrderHeader.UpdateStatus(orderId, SD.StatusCancelled);
            _unitOfWork.Save();
            return RedirectToPage("ManageOrder");
        }
    }
}
