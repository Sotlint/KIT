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
    /// Логика взаимодействия для ProductMenu.xaml
    /// </summary>
    public partial class ProductMenu : Window
    {
        public ProductMenu()
        {
            InitializeComponent();
        }

        private void Button_Return_Click(object sender, RoutedEventArgs e)
        {
            AdminMenu adminmenu_wpf = new AdminMenu();
            adminmenu_wpf.Show();
            Close();
        }

        private void Button_Create_Click(object sender, RoutedEventArgs e)
        {
            MPoduct product_wpf = new MPoduct();
            product_wpf.Show();
            Close();
        }

        private void Button_Stock_Click(object sender, RoutedEventArgs e)
        {
            Stock stock_wpf = new Stock();
            stock_wpf.Show();
            Close();
        }

        private void Button_Update_Click(object sender, RoutedEventArgs e)
        {
            ProductUpdateMenu update_wpf = new ProductUpdateMenu();
            update_wpf.Show();
            Close();
        }
    }
}
