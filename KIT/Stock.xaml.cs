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
    /// Логика взаимодействия для Stock.xaml
    /// </summary>
    public partial class Stock : Window
    {

        Context_Categories dbc = new Context_Categories();
       
        public Stock()
        {
            InitializeComponent();
            dbc.Categories.Load();
            DataContext = dbc.Categories.Local.ToObservableCollection();
        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            ProductMenu productmenu_wpf = new ProductMenu();
            productmenu_wpf.Show();
            Close();
        }

    

        private void ListCat(object sender, SelectionChangedEventArgs e)
        {
            List_PStock.Items.Clear();
            Categories_DB? c = List_CStock.SelectedItem as Categories_DB;
            using (Context_Product dbp = new Context_Product())
            {
                var p = dbp.Product.ToList();
                foreach (Product_DB i in p)
                {
                    if(i.C_ID==c.C_ID)
                    {
                        List_PStock.Items.Add(i);
                    }
                }
            }
        }

        private void Button_Obn_Click(object sender, RoutedEventArgs e)
        {
            dbc.Categories.Load();
            List_PStock.Items.Clear();
            DataContext = dbc.Categories.Local.ToObservableCollection();
            List_CStock.Items.Refresh();
        }
    }
}
