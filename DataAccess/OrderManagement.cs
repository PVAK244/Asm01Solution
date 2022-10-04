using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class OrderManagement
    {
        private static OrderManagement instance = null;
        private static readonly object instanceLock = new object();
        private OrderManagement() { }
        public static OrderManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderManagement();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<OrderObject> GetOrderList()
        {
            List<OrderObject> orders;
            try
            {
                var fStoreDB = new FStoreContext();
                orders = fStoreDB.Orders.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }

        public OrderObject GetOrderByID(int orderId)
        {
            OrderObject order = null;
            try
            {
                var fStoreDB = new FStoreContext();
                order = fStoreDB.Orders.SingleOrDefault(order => order.OrderId == orderId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return order;
        }


        public void AddNew(OrderObject order)
        {
            try
            {
                OrderObject _order = GetOrderByID(order.OrderId);
                if (_order == null)
                {
                    var fStoreDB = new FStoreContext();
                    fStoreDB.Orders.Add(order);
                    fStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The order is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(OrderObject order)
        {
            try
            {
                OrderObject o = GetOrderByID(order.OrderId);
                if (o != null)
                {
                    var fStoreDB = new FStoreContext();
                    fStoreDB.Entry<OrderObject>(order).State = EntityState.Modified;
                    fStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The order does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(OrderObject order)
        {
            try
            {
                OrderObject _order = GetOrderByID(order.OrderId);
                if (_order != null)
                {
                    var fStoreDB = new FStoreContext();
                    fStoreDB.Orders.Remove(order);
                    fStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The order does not already exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
