using BusinessObject;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for WindowOrders.xaml
    /// </summary>
    public partial class WindowOrders : Window
    {
        public bool isPermit { get; set; }

        public WindowOrders()
        {
            InitializeComponent();
        }

        IOrderRepository orderRepository = new OrderRepository();

        private OrderObject GetOrderObject()
        {
            OrderObject order = null;
            try
            {
                order = new OrderObject
                {
                    OrderId = int.Parse(txtOrderId.Text),
                    MemberId = int.Parse(txtMemberId.Text),
                    OrderDate = DateTime.Parse(txtOrderDate.Text),
                    RequiredDate = DateTime.Parse(txtRequiredDate.Text),
                    ShippedDate = DateTime.Parse(txtShippedDate.Text),
                    Freight = decimal.Parse(txtFreight.Text),

                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Order");
            }
            return order;
        }

        public void LoadOrderList()
        {
            lvOrders.ItemsSource = orderRepository.GetOrders();
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadOrderList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load order list");
            }
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OrderObject order = GetOrderObject();
                orderRepository.InsertOrder(order);
                LoadOrderList();
                MessageBox.Show("Insert order");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert order");
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OrderObject order = GetOrderObject();
                orderRepository.UpdateOrder(order);
                LoadOrderList();
                MessageBox.Show("Update order");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update order");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OrderObject order = GetOrderObject();
                orderRepository.DeleteOrder(order);
                LoadOrderList();
                MessageBox.Show("Delete order");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete order");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
