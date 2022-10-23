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
    /// Логика взаимодействия для MPoduct.xaml
    /// </summary>
    public partial class MPoduct : Window
    {

        Context_Categories db = new Context_Categories();
        public MPoduct()
        {
            InitializeComponent();
            db.Categories.Load();
            DataContext = db.Categories.Local.ToObservableCollection();

        }

        private void Button_Return_Click(object sender, RoutedEventArgs e)
        {
            ProductMenu productmenu_wpf = new ProductMenu();
            productmenu_wpf.Show();
            Close();
        }

        private void Button_KCreate_Click(object sender, RoutedEventArgs e)
        {

            Worker.NewCategory(KBox.Text);
            db.Categories.Load();
            DataContext = db.Categories.Local.ToObservableCollection();
            List_Сat.Items.Refresh();
            KBox.Text = "";
          
        }

        private void Button_PCreate_Click(object sender, RoutedEventArgs e)
        {

            int price = 0;
            int amounth = 0;
            int id = List_Сat.SelectedIndex + 1;
            try
            {
                price = Convert.ToInt32(Pricebox.Text);
                amounth = Convert.ToInt32(Ibox.Text);

            }
            catch
            {
                MessageBox.Show("Недопустимые значения для цены/количества!", "KIT");
            }
            finally
            {
                Worker.NewProduct(TitleBox.Text,price,amounth,id,TextP.Text);
                Pricebox.Text = "";
                Ibox.Text = "";
                TitleBox.Text = "";
                TextP.Text = "";
            }
            
        }


    }
}
