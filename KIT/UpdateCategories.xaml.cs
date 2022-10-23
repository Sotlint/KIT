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
    /// Логика взаимодействия для UpdateCategories.xaml
    /// </summary>
    public partial class UpdateCategories : Window
    {
        Context_Categories dbc = new Context_Categories();
        public UpdateCategories()
        {
            InitializeComponent();
            dbc.Categories.Load();
            DataContext = dbc.Categories.Local.ToObservableCollection();
        }

        private void ListCategories_Ch(object sender, SelectionChangedEventArgs e)
        {
            Categories_DB? c = List_C.SelectedItem as Categories_DB;
            if (c != null)
            {
                TitleBox.Text = c.Title;
            
            }
            else
            {
                TitleBox.Text = "";
          
            }
     
        }

        private void Button_Return_Click(object sender, RoutedEventArgs e)
        {
            ProductUpdateMenu productmenu_wpf = new ProductUpdateMenu();
            productmenu_wpf.Show();
            Close();
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            Categories_DB? c = List_C.SelectedItem as Categories_DB;
            dbc.Categories.Remove(c);
            dbc.SaveChanges();
            List_C.Items.Refresh();

        }
    }
}
