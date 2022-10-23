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
    /// Логика взаимодействия для OrderInfo.xaml
    /// </summary>
    public partial class OrderInfo : Window
    {
        int login_id=0;
        public OrderInfo()
        {
            InitializeComponent();
            using (Context_Orders dbo = new Context_Orders())
            {
                using (Context_Product dbp = new Context_Product())
                {
                    using (Context_ContactData dbc = new Context_ContactData())
                    {
                        using (Context_DeliverAddresData dbd = new Context_DeliverAddresData())
                        {
                            var o = dbo.Orders.ToList();
                            var p = dbp.Product.ToList();
                            var d = dbd.DeliverAddresData.ToList();
                            var c = dbc.ContactData.ToList();

                            var contact = new ContactData_DB();
                            var deliver = new DeliverAddresData_DB();
                            var order = new Order_View();

                            foreach (Orders_DB i in o)
                            {
                                if (i.Orders_ID == Worker.O_ID)
                                {
                                    login_id = i.Login_ID;
                                    order.Orders_ID = i.Orders_ID;
                                    order.Amount=i.Amount;
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
                                    order.TotalCost = i.TotalCost;
                                    foreach(Product_DB j in p)
                                    {
                                        if(j.P_ID==i.P_ID)
                                        {
                                            order.Title=j.Title;
                                            break;
                                        }
                                    }


                                    break;
                                }
                            }
                            List_Order.Items.Add(order);

                            foreach (ContactData_DB i in c)
                            {
                                if(i.Login_ID==login_id)
                                {
                                    contact.FirstName = i.FirstName;
                                    contact.LastName = i.LastName;
                                    contact.E_mail = i.E_mail;
                                    contact.Telephone = i.Telephone;
                                    break;
                                }

                            }
                            List_Contact.Items.Add(contact);

                            foreach(DeliverAddresData_DB i in d)
                            {
                                if(i.Login_ID==login_id)
                                {
                                    deliver.City = i.City;
                                    deliver.Street = i.Street;
                                    deliver.Entrance = i.Entrance;
                                    deliver.Floor = i.Floor;
                                    deliver.ApartmentNumber = i.ApartmentNumber;
                                    break;
                                }
                            }
                            List_Delivery.Items.Add(deliver);


                        }
                    }
                }
            }
        }

        private void Button_Return_Click(object sender, RoutedEventArgs e)
        {
            Orders orders_wpf = new Orders();
            orders_wpf.Show();
            Close();
        }

        private void Button_Status0_Click(object sender, RoutedEventArgs e)
        {
            using (Context_Orders dbo = new Context_Orders())
            {
                using (Context_Product dbp = new Context_Product())
                {
                    var o = dbo.Orders.ToList();
                    var p = dbp.Product.ToList();
                    var order = new Order_View();
                    foreach (Orders_DB i in o)
                    {

                        if (i.Orders_ID == Worker.O_ID)
                        {
                            i.Status = 0;
                            dbo.SaveChanges();
                            List_Order.Items.Clear();
                            login_id = i.Login_ID;
                            order.Orders_ID = i.Orders_ID;
                            order.Amount = i.Amount;
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
                            order.TotalCost = i.TotalCost;
                            foreach (Product_DB j in p)
                            {
                                if (j.P_ID == i.P_ID)
                                {
                                    order.Title = j.Title;
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    List_Order.Items.Add(order);
                }
            }
        }
        private void Button_Status1_Click(object sender, RoutedEventArgs e)
        {
            using (Context_Orders dbo = new Context_Orders())
            {
                using (Context_Product dbp = new Context_Product())
                {
                    var o = dbo.Orders.ToList();
                    var p = dbp.Product.ToList();
                    var order = new Order_View();
                    foreach (Orders_DB i in o)
                    {

                        if (i.Orders_ID == Worker.O_ID)
                        {
                            i.Status = 1;
                            dbo.SaveChanges();
                            List_Order.Items.Clear();
                            login_id = i.Login_ID;
                            order.Orders_ID = i.Orders_ID;
                            order.Amount = i.Amount;
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
                            order.TotalCost = i.TotalCost;
                            foreach (Product_DB j in p)
                            {
                                if (j.P_ID == i.P_ID)
                                {
                                    order.Title = j.Title;
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    List_Order.Items.Add(order);
                }
            }
        }

        private void Button_Status2_Click(object sender, RoutedEventArgs e)
        {
            using (Context_Orders dbo = new Context_Orders())
            {
                using (Context_Product dbp = new Context_Product())
                {
                    var o = dbo.Orders.ToList();
                    var p = dbp.Product.ToList();
                    var order = new Order_View();
                    foreach (Orders_DB i in o)
                    {

                        if (i.Orders_ID == Worker.O_ID)
                        {
                            i.Status = 2;
                            dbo.SaveChanges();
                            List_Order.Items.Clear();
                            login_id = i.Login_ID;
                            order.Orders_ID = i.Orders_ID;
                            order.Amount = i.Amount;
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
                            order.TotalCost = i.TotalCost;
                            foreach (Product_DB j in p)
                            {
                                if (j.P_ID == i.P_ID)
                                {
                                    order.Title = j.Title;
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    List_Order.Items.Add(order);
                }
            }
        }
    }
}
