using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Utility
{
    public static class SD
    {
        public const string ManagerRole = "Manager";
        public const string FrontDeskRole = "Front";
        public const string KitchenRole = "Kitchen";
        public const string CustomerRole = "Customer";

        //Đang chờ thanh toán
        public const string StatusPending = "Pending_Payment";
        //Đang được phê duyệt
        public const string StatusSubmitted = "Submitted_PaymentApproved";
        //Trạng thái bị từ chối
        public const string StatusRejected = "Rejected_Payment";
        //Trạng thái đang xử lý
        public const string StatusInProcess = "Being Prepared";
        //Trạng thái sẵn sàng 
        public const string StatusReady = "Ready for Pickup";
        //Trạng thái hoàn thành
        public const string StatusCompleted = "Completed";
        //Trạng thái hủy đơn hàng
        public const string StatusCancelled = "Cancelled";
        //Trạng thái hoàn tiền
        public const string StatusRefunded = "Refunded";
    }
}
