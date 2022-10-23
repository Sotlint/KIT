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
    /// Логика взаимодействия для UpdateProduct.xaml
    /// </summary>
    public partial class UpdateProduct : Window
    {
        Context_Categories dbc = new Context_Categories();
        Context_Product dbp = new Context_Product();



        public UpdateProduct()
        {
            InitializeComponent();
            dbc.Categories.Load();
            DataContext = dbc.Categories.Local.ToObservableCollection();
        }

        private void Button_Return_Click(object sender, RoutedEventArgs e)
        {
            ProductUpdateMenu productmenu_wpf = new ProductUpdateMenu();
            productmenu_wpf.Show();
            Close();
        }

        private void ListCategories_Ch(object sender, SelectionChangedEventArgs e)
        {
            List_P.Items.Clear();
            Categories_DB? c = List_C.SelectedItem as Categories_DB;
            using (Context_Product dbp = new Context_Product())
            {
                var p = dbp.Product.ToList();
                foreach (Product_DB i in p)
                {
                    if (i.C_ID == c.C_ID)
                    {
                        List_P.Items.Add(i);
                    }
                }
            }
        }

        private void ListProduct_Ch(object sender, SelectionChangedEventArgs e)
        {
            
            Product_DB? p = List_P.SelectedItem as Product_DB;
            if (p != null)
            {
                TitleBox.Text = p.Title;
                PriceBox.Text = Convert.ToString(p.Price);
                InStockBox.Text = Convert.ToString(p.AmounthInStock);
                TextP.Text = p.Text;
            }
            else
            {
                TitleBox.Text = "";
                PriceBox.Text = "";
                InStockBox.Text = "";
                TextP.Text = "";
            }
 
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            Product_DB? p = List_P.SelectedItem as Product_DB;
            Worker.DeleteProduct(p.P_ID);
            List_P.Items.Remove(p);

           
            
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            Product_DB? p = List_P.SelectedItem as Product_DB;
            if (Worker.UpdateProduct(p.P_ID, TitleBox.Text, PriceBox.Text, InStockBox.Text, TextP.Text) == true)
            {
                p.Title = TitleBox.Text;
                p.Price = Convert.ToInt32(PriceBox.Text);
                p.AmounthInStock = Convert.ToInt32(InStockBox.Text);
                p.Text = TextP.Text;
            }
            List_P.Items.Remove(List_P.SelectedItem);
            List_P.Items.Add(p);

        }
    }
}
