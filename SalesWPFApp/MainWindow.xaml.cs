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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static WindowMembers? frmMember;
        private static WindowOrders? frmOrders;
        private static WindowProducts? frmProducts;

        public bool IsAdmin { get; set; }
        public int AccountID { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void memberManagement_Click(object sender, RoutedEventArgs e)
        {
                frmMember = new WindowMembers { isPermit = IsAdmin, AccountID = AccountID };
                frmMember.Show();
        }

        private void orderManagement_Click(object sender, RoutedEventArgs e)
        {
            frmOrders = new WindowOrders { isPermit = IsAdmin };
            frmOrders.Show();
        }

        private void productManagement_Click(object sender, RoutedEventArgs e)
        {
            frmProducts = new WindowProducts { isPermit = IsAdmin };
            frmProducts.Show();
        }
    }
}
