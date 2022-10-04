using BusinessObject;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
    /// Interaction logic for WindowMembers.xaml
    /// </summary>
    public partial class WindowMembers : Window
    {
        public bool isPermit { get; set; }
        public int AccountID { get; set; }

        public WindowMembers()
        {
            InitializeComponent();
        }

        IMemberRepository memberRepository = new MemberRepository();

        private MemberObject GetMemberObject()
        {
            MemberObject member = null;
            try
            {
                member = new MemberObject
                {
                    MemberId = int.Parse(txtMemberId.Text),
                    City = txtCity.Text,
                    Email = txtEmail.Text,
                    Country = txtCountry.Text,
                    CompanyName = txtCompanyName.Text,
                    Password = txtPassword.Text 
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get member");
            }
            return member;
        }

        public void LoadMemberList()
        {
            lvMembers.ItemsSource = memberRepository.GetMembers();
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadMemberList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load member list");
            }
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MemberObject member = GetMemberObject();
                memberRepository.InsertMember(member);
                LoadMemberList();
                MessageBox.Show($"{member.Email} inserted successfully ", "Insert member");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert member");
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MemberObject member = GetMemberObject();
                memberRepository.UpdateMember(member);
                LoadMemberList();
                MessageBox.Show($"{member.Email} updated successfully ", "Update member");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update member");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MemberObject member = GetMemberObject();
                memberRepository.DeleteMember(member);
                LoadMemberList();
                MessageBox.Show($"{member.Email} deleted successfully ", "Delete member");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete member");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
