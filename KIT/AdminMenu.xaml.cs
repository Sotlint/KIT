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
    /// Логика взаимодействия для AdminMenu.xaml
    /// </summary>
    public partial class AdminMenu : Window
    {
        public AdminMenu()
        {
            InitializeComponent();
        }

        private void Button_Click_Return(object sender, RoutedEventArgs e)
        {
            MainWindow Main_wpf = new MainWindow();
            Main_wpf.Show();
            Close();
        }

        private void Button_Click_Moder(object sender, RoutedEventArgs e)
        {
            AdminModer AdminModer_wpf = new AdminModer();
            AdminModer_wpf.Show();
            Close();
        }

        private void Button_Click_Product(object sender, RoutedEventArgs e)
        {
            ProductMenu productmenu_wpf = new ProductMenu();
            productmenu_wpf.Show();
            Close();
        }

        private void Button_Click_Orders(object sender, RoutedEventArgs e)
        {
            Orders orders_wpf = new Orders();
            orders_wpf.Show();
            Close();
        }
    }
}
