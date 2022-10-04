using System.Collections.Generic;
using BusinessObject;

namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<OrderObject> GetOrders();
        OrderObject GetOrderByID(int orderID);
        void InsertOrder(OrderObject order);
        void DeleteOrder(OrderObject order);
        void UpdateOrder(OrderObject order);
    }
}
