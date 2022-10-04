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
    /// Interaction logic for WindowProducts.xaml
    /// </summary>
    public partial class WindowProducts : Window
    {
        public bool isPermit { get; set; }

        public WindowProducts()
        {
            InitializeComponent();
        }

        IProductRepository productRepository = new ProductRepository();

        private ProductObject GetProductObject()
        {
            ProductObject product = null;
            try
            {
                product = new ProductObject
                {
                    ProductId = int.Parse(txtProductId.Text),
                    CategoryId = int.Parse(txtCategoryId.Text),
                    ProductName = txtProductName.Text,
                    Weight = txtWeight.Text,
                    UnitPrice = decimal.Parse(txtUnitPrice.Text),
                    UnitInStock = int.Parse(txtUnitInStock.Text)
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get product");
            }
            return product;
        }

        public void LoadProductList()
        {
            lvProducts.ItemsSource = productRepository.GetProducts();
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadProductList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load product list");
            }
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProductObject product = GetProductObject();
                productRepository.InsertProduct(product);
                LoadProductList();
                MessageBox.Show("Insert product");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert product");
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProductObject product = GetProductObject();
                productRepository.UpdateProduct(product);
                LoadProductList();
                MessageBox.Show("Update product");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update product");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ProductObject product = GetProductObject();
                productRepository.DeleteProduct(product);
                LoadProductList();
                MessageBox.Show("Delete product");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete product");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
