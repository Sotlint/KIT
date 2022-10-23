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
    /// Логика взаимодействия для ProductS.xaml
    /// </summary>
    /// 
    public partial class ProductS : Window
    {

        Context_Product db = new Context_Product();
        Product_DB product = new Product_DB();

        public int x;
        public ProductS()
        {
            InitializeComponent();
          
                var p = db.Product.ToList();
                foreach (Product_DB i in p)
                {
                    if (i.P_ID == Worker.P_ID)
                    {
                        product = i;
                        DataContext = i;
                        
                    }
                }
           
        }

        private void Return_Button_Click(object sender, RoutedEventArgs e)
        {
            Hub hub_wpf = new Hub();
            hub_wpf.Show();
            Close();
        }

        private void Plus_Button_Click(object sender, RoutedEventArgs e)
        {
            x=Convert.ToInt32(Amount.Content);
            if((x+1)<=product.AmounthInStock)
            {
             
                x++;
            }
            Amount.Content = Convert.ToString(x);
        }

        private void Minus_Button_Click(object sender, RoutedEventArgs e)
        {
            x = Convert.ToInt32(Amount.Content);
            if (x > 0)
            {
                x--;
            }
            else 
            {
               x = 0; 
            }
            Amount.Content = Convert.ToString(x);
        }

        private void Buy_Button_Click(object sender, RoutedEventArgs e)
        {

            if (Convert.ToInt32(Amount.Content) > 0)
            {
                Worker.NewOrder(Worker.id, Worker.P_ID, Convert.ToInt32(Amount.Content));
                MessageBox.Show("Товар добавлен в корзину!", "KIT");
                AmountInS.Content = Convert.ToInt32(AmountInS.Content) - Convert.ToInt32(Amount.Content);
            }
        }

        private void Status(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(AmountInS.Content) == 0)
            {
                MessageBox.Show("Данного товара в данный момент нет на складе!", "KIT");
            }
        }
    }
}
