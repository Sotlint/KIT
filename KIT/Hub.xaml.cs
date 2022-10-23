using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для Hub.xaml
    /// </summary>
    public partial class Hub : Window
    {
       
   

        Context_Categories dbc = new Context_Categories();
        public Hub()
        {
            InitializeComponent();
            dbc.Categories.Load();
            DataContext = dbc.Categories.Local.ToObservableCollection();

        }

        private void List_CStock_C(object sender, SelectionChangedEventArgs e)
        {
            List_PStock.Items.Clear();
            Categories_DB? c = List_CStock.SelectedItem as Categories_DB;
            using (Context_Product dbp = new Context_Product())
            {
                var p = dbp.Product.ToList();
                foreach (Product_DB i in p)
                {
                    if (i.C_ID == c.C_ID)
                    {
                        List_PStock.Items.Add(i);
                    }
                }

            }
            
        }

        private void HiddenLiist_ME(object sender, MouseEventArgs e)
        {
            List_Profile.Visibility = Visibility.Visible;
        }

        private void HiddenLiist_ML(object sender, MouseEventArgs e)
        {
            List_Profile.Visibility = Visibility.Hidden;
        }

        private void HiddenLiist_L_ME(object sender, MouseEventArgs e)
        {
            List_Profile.Visibility = Visibility.Visible;
        }

        private void HiddenLiist_L_ML(object sender, MouseEventArgs e)
        {
            List_Profile.Visibility = Visibility.Hidden;
        }

        private void ListProfile_ME(object sender, MouseEventArgs e)
        {
            List_Profile.Visibility = Visibility.Visible;
        }

        private void ListProfile_ML(object sender, MouseEventArgs e)
        {
            List_Profile.Visibility = Visibility.Hidden;
        }

        private void Button_Lk_Click(object sender, RoutedEventArgs e)
        {
            Profile prof_wpf = new Profile();
            prof_wpf.Show();
            Close();
        }

        private void Button_Setting_Click(object sender, RoutedEventArgs e)
        {
            Check ch_wpf = new Check();
            ch_wpf.Show();
            Close();
        }

        private void Button_Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main_wpf = new MainWindow();
            main_wpf.Show();
            Close();
        }

        private void Button_Profile_Click(object sender, RoutedEventArgs e)
        {
            Profile prof_wpf = new Profile();
            prof_wpf.Show();
            Close();
        }

        private void Button_Basket_Click(object sender, RoutedEventArgs e)
        {
            Korz busket_wpf = new Korz();
            busket_wpf.Show();
            Close();
        }

        private void Product_Click(object sender, MouseButtonEventArgs e)
        {
           
            
            ProductS product = new ProductS();
            product.Show();
            Close();
        }

        private void ListP_Select(object sender, SelectionChangedEventArgs e)
        {
            
               
 
                Product_DB? p = List_PStock.SelectedItem as Product_DB;
            if (p != null)
            {
                Worker.P_ID = p.P_ID;
            }
            
       
                
        }

        private void BSelect_Click(object sender, RoutedEventArgs e)
        {
            ProductS product = new ProductS();
            product.Show();
            Close();
        }

        private void Button_Orders_Click(object sender, RoutedEventArgs e)
        {
            UserOrder userorder = new UserOrder();
            userorder.Show();
            Close();
        }
    }
   
}
