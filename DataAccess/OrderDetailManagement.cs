using System;
using BusinessObject;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class OrderDetailManagement
    {
        private static OrderDetailManagement instance = null;
        private static readonly object instanceLock = new object();

        private OrderDetailManagement() { }
        public static OrderDetailManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailManagement();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<OrderDetailObject> GetOrderDetailList()
        {
            List<OrderDetailObject> orderDetails;
            try
            {
                var fStoreDB = new FStoreContext();
                orderDetails = fStoreDB.OrderDetails.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetails;
        }

        public OrderDetailObject GetOrderDetailByID(int orderId, int productId)
        {
            OrderDetailObject orderDetail = null;
            try
            {
                var fStoreDB = new FStoreContext();
                orderDetail = fStoreDB.OrderDetails.SingleOrDefault(orderDetail => orderDetail.OrderId == orderId && orderDetail.ProductId == productId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetail;
        }

        public void AddNew(OrderDetailObject orderDetail)
        {
            try
            {
                OrderDetailObject _orderDetail = GetOrderDetailByID(orderDetail.OrderId, orderDetail.ProductId);
                if (_orderDetail == null)
                {
                    var fStoreDB = new FStoreContext();
                    fStoreDB.OrderDetails.Add(orderDetail);
                    fStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The order detail is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(OrderDetailObject orderDetail)
        {
            try
            {
                OrderDetailObject o = GetOrderDetailByID(orderDetail.OrderId, orderDetail.ProductId);
                if (o != null)
                {
                    var fStoreDB = new FStoreContext();
                    fStoreDB.Entry<OrderDetailObject>(orderDetail).State = EntityState.Modified;
                    fStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The order detail does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(OrderDetailObject orderDetail)
        {
            try
            {
                OrderDetailObject _orderDetail = GetOrderDetailByID(orderDetail.OrderId, orderDetail.ProductId);
                if (_orderDetail != null)
                {
                    var fStoreDB = new FStoreContext();
                    fStoreDB.OrderDetails.Remove(orderDetail);
                    fStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The order detail does not already exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
