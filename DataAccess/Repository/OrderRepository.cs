using System.Collections.Generic;
using BusinessObject;

namespace DataAccess.Repository
{
    public  class OrderRepository : IOrderRepository
    {
        public IEnumerable<OrderObject> GetOrders() 
            => OrderManagement.Instance.GetOrderList();
        public OrderObject GetOrderByID(int orderID) 
            => OrderManagement.Instance.GetOrderByID(orderID);
        public void InsertOrder(OrderObject order) 
            => OrderManagement.Instance.AddNew(order);
        public void DeleteOrder(OrderObject order) 
            => OrderManagement.Instance.Remove(order);
        public void UpdateOrder(OrderObject order) 
            => OrderManagement.Instance.Update(order);
    }
}
