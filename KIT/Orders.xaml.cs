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
    /// Логика взаимодействия для Orders.xaml
    /// </summary>
    public partial class Orders : Window
    {
        public Orders()
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
                                    order.Login_ID = i.Login_ID;

                                    if (i.Status == 0)
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


                                    List_Orders.Items.Add(order);

                                    break;
                                }

                            }

                        
                    }
                }
            }
        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            AdminMenu AdminMenu_wpf = new AdminMenu();
            AdminMenu_wpf.Show();
            Close();
        }

        private void Button_Select_Click(object sender, RoutedEventArgs e)
        {


            OrderInfo orderinfo_wpf = new OrderInfo();
            orderinfo_wpf.Show();
            Close();
        }

        private void Button_S_Status0_Click(object sender, RoutedEventArgs e)
        {
            List_Orders.Items.Clear();
            using (Context_Orders dbo = new Context_Orders())
            {
                using (Context_Product dbp = new Context_Product())
                {

                    var o = dbo.Orders.ToList();
                    var p = dbp.Product.ToList();

                    foreach (Orders_DB i in o)
                    {
                        if (i.Status == 0)
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
                                    order.Login_ID = i.Login_ID;

                                    if (i.Status == 0)
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


                                    List_Orders.Items.Add(order);

                                    break;
                                }

                            }
                        }

                    }
                }
            }
        }

        private void Button_S_Status1_Click(object sender, RoutedEventArgs e)
        {
            List_Orders.Items.Clear();
            using (Context_Orders dbo = new Context_Orders())
            {
                using (Context_Product dbp = new Context_Product())
                {

                    var o = dbo.Orders.ToList();
                    var p = dbp.Product.ToList();

                    foreach (Orders_DB i in o)
                    {
                        if (i.Status == 1)
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
                                    order.Login_ID = i.Login_ID;

                                    if (i.Status == 0)
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


                                    List_Orders.Items.Add(order);

                                    break;
                                }

                            }
                        }

                    }
                }
            }
        }

        private void Button_S_Status2_Click(object sender, RoutedEventArgs e)
        {
            List_Orders.Items.Clear();
            using (Context_Orders dbo = new Context_Orders())
            {
                using (Context_Product dbp = new Context_Product())
                {

                    var o = dbo.Orders.ToList();
                    var p = dbp.Product.ToList();

                    foreach (Orders_DB i in o)
                    {
                        if (i.Status == 2)
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
                                    order.Login_ID = i.Login_ID;

                                    if (i.Status == 0)
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


                                    List_Orders.Items.Add(order);

                                    break;
                                }

                            }
                        }

                    }
                }
            }
        }

        private void Button_S_LoginID_Click(object sender, RoutedEventArgs e)
        {
            int id;
            try
            {
                Convert.ToInt32(TextBox_S_LoginID.Text);
                id = Convert.ToInt32(TextBox_S_LoginID.Text);
                List_Orders.Items.Clear();
                using (Context_Orders dbo = new Context_Orders())
                {
                    using (Context_Product dbp = new Context_Product())
                    {
                        
                        var o = dbo.Orders.ToList();
                        var p = dbp.Product.ToList();

                        foreach (Orders_DB i in o)
                        {
                            if (i.Login_ID == id)
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
                                        order.Login_ID = i.Login_ID;

                                        if (i.Status == 0)
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


                                        List_Orders.Items.Add(order);

                                        break;
                                    }

                                }
                            }

                        }
                    }
                }

            }
            catch
            {
                MessageBox.Show("Некорректный ID!", "KIT");
            }
           
        }

        private void Button_S_OrderID_Click(object sender, RoutedEventArgs e)
        {
            int id;
            try
            {
                Convert.ToInt32(TextBox_S_OrderID.Text);
                id = Convert.ToInt32(TextBox_S_OrderID.Text);
                List_Orders.Items.Clear();
                using (Context_Orders dbo = new Context_Orders())
                {
                    using (Context_Product dbp = new Context_Product())
                    {

                        var o = dbo.Orders.ToList();
                        var p = dbp.Product.ToList();

                        foreach (Orders_DB i in o)
                        {
                            if (i.Orders_ID == id)
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
                                        order.Login_ID = i.Login_ID;

                                        if (i.Status == 0)
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


                                        List_Orders.Items.Add(order);

                                        break;
                                    }

                                }
                            }

                        }
                    }
                }

            }
            catch
            {
                MessageBox.Show("Некорректный ID!", "KIT");
            }
        }

        private void ListOrders_Select(object sender, SelectionChangedEventArgs e)
        {
            Order_View? order = List_Orders.SelectedItem as Order_View;
            if (order != null)
            {
                Worker.O_ID = order.Orders_ID;
            }
        }

        private void Button_Del_Click(object sender, RoutedEventArgs e)
        {
            Worker.DelOrders_Status_2();
            List_Orders.Items.Clear();
            using (Context_Orders dbo = new Context_Orders())
            {
                using (Context_Product dbp = new Context_Product())
                {

                    var o = dbo.Orders.ToList();
                    var p = dbp.Product.ToList();

                    foreach (Orders_DB i in o)
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
                                order.Login_ID = i.Login_ID;

                                if (i.Status == 0)
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


                                List_Orders.Items.Add(order);

                                break;
                            }

                        }


                    }
                }
            }
        }

        private void Button_Del_Selected_Click(object sender, RoutedEventArgs e)
        {
            Worker.DelOrders_Any();
            List_Orders.Items.Remove(List_Orders.SelectedItem);
           
        }

        private void Button_Refresh_Click(object sender, RoutedEventArgs e)
        {
            List_Orders.Items.Clear();
            using (Context_Orders dbo = new Context_Orders())
            {
                using (Context_Product dbp = new Context_Product())
                {

                    var o = dbo.Orders.ToList();
                    var p = dbp.Product.ToList();

                    foreach (Orders_DB i in o)
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
                                order.Login_ID = i.Login_ID;

                                if (i.Status == 0)
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


                                List_Orders.Items.Add(order);

                                break;
                            }

                        }


                    }
                }
            }
        }
    }
}
