using System.Collections.Generic;
using BusinessObject;

namespace DataAccess.Repository
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetailObject> GetOrdersDetail();
        OrderDetailObject GetOrderDetailByID(int orderId, int productId);
        void InsertOrderDetail(OrderDetailObject orderDetail);
        void DeleteOrderDetail(OrderDetailObject orderDetail);
        void UpdateOrderDetail(OrderDetailObject orderDetail);
    }
}
