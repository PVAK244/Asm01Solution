using System.Collections.Generic;
using BusinessObject;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public IEnumerable<OrderDetailObject> GetOrdersDetail() 
            => OrderDetailManagement.Instance.GetOrderDetailList();
        public OrderDetailObject GetOrderDetailByID(int orderId, int productId) 
            => OrderDetailManagement.Instance.GetOrderDetailByID(orderId, productId);
        public void InsertOrderDetail(OrderDetailObject orderDetail) 
            => OrderDetailManagement.Instance.AddNew(orderDetail);
        public void DeleteOrderDetail(OrderDetailObject orderDetail) 
            => OrderDetailManagement.Instance.Remove(orderDetail);
        public void UpdateOrderDetail(OrderDetailObject orderDetail) 
            => OrderDetailManagement.Instance.Update(orderDetail);
    }
}
