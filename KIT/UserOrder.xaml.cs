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
    /// Логика взаимодействия для UserOrder.xaml
    /// </summary>
    public partial class UserOrder : Window
    {
        public UserOrder()
        {
            InitializeComponent();
            using (Context_Orders dbo = new Context_Orders())
            {
                using (Context_Product dbp = new Context_Product())
                {

                    var o = dbo.Orders.ToList();
                    var p = dbp.Product.ToList();

                    foreach (Orders_DB i in o)
                    {
                        if (i.Login_ID == Worker.id)
                        {
                            var order = new Order_View();
                            foreach (Product_DB j in p)
                            {
                                if (j.P_ID == i.P_ID)
                                {
                                    order.Orders_ID = i.Orders_ID;
                                    order.P_ID = i.P_ID;
                                    order.Title = j.Title;
                                    order.Amount = i.Amount;
                                    order.TotalCost = i.TotalCost;
                                    if(i.Status == 0)
                                    {
                                        order.Status = "В обработке";
                                    }
                                    if (i.Status == 1)
                                    {
                                        order.Status = "Исполняется";
                                    }
                                    if (i.Status == 2)
                                    {
                                        order.Status = "Исполнен";
                                    }

                                    List_Order.Items.Add(order);

                                    break;
                                }

                            }

                        }
                    }
                }
            }
        }

        private void Button_Return_Click(object sender, RoutedEventArgs e)
        {
            Hub Hub_wpf = new Hub();
            Hub_wpf.Show();
            Close();
        }
    }
}
