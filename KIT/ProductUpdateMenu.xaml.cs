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

namespace KIT
{
    /// <summary>
    /// Логика взаимодействия для ProductUpdateMenu.xaml
    /// </summary>
    public partial class ProductUpdateMenu : Window
    {
        public ProductUpdateMenu()
        {
            InitializeComponent();
        }

        private void Button_Return_Click(object sender, RoutedEventArgs e)
        {
            ProductMenu productmenu_wpf = new ProductMenu();
            productmenu_wpf.Show();
            Close();
        }

        private void Button_Product_Click(object sender, RoutedEventArgs e)
        {
            UpdateProduct product_wpf = new UpdateProduct();
            product_wpf.Show();
            Close();
        }

        private void Button_Categories_Click(object sender, RoutedEventArgs e)
        {
            UpdateCategories categories_wpf = new UpdateCategories();
            categories_wpf.Show();
            Close();
        }
    }
}
