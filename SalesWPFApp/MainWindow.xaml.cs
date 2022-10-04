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

        public bool IsAdmin { get; set; }
        public int AccountID { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void memberManagement_Click(object sender, RoutedEventArgs e)
        {
            if (frmMember == null || frmMember.FrmMemberState == false)
            {
                frmMember = new WindowMembers { FrmMemberState = true, isPermit = IsAdmin, AccountID = AccountID };
                frmMember.Show();
            }
        }
    }
}
