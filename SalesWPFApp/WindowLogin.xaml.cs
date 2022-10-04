using BusinessObject;
using DataAccess.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for WindowLogin.xaml
    /// </summary>
    public partial class WindowLogin : Window
    {
        IMemberRepository memberRepository = new MemberRepository();

        public WindowLogin()
        {
            InitializeComponent();
        }

        static IConfiguration GetConfiguration()
            => new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Password;
            IConfiguration config = GetConfiguration();
            if (email.Equals(config["login:email"])
                && password.Equals(config["login:password"]))
            {
                this.Hide();
                MainWindow frmMain = new MainWindow { IsAdmin = true };
                frmMain.ShowDialog();
            }
            else if (memberRepository.LogIn(email, password) != null)
            {
                this.Hide();
                MemberObject account = memberRepository.LogIn(email, password);
                MainWindow frmMain = new MainWindow { IsAdmin = false, AccountID = account.MemberId };
                frmMain.ShowDialog();
            }
            else
            {
                lbMessage.Content = "Email or password is incorrect, try again!";
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            txtEmail.Text = string.Empty;
            txtPassword.Password = string.Empty;
        }

        private void txtEmail_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            status.Content = "Please enter your email.";
        }

        private void txtEmail_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            status.Content = string.Empty;
        }

        private void txtPassword_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            status.Content = "Please enter your password.";
        }

        private void txtPassword_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            status.Content = string.Empty;
        }
    }
}
