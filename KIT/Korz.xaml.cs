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
    /// Логика взаимодействия для Korz.xaml
    /// </summary>
    public partial class Korz : Window
    {


        public Korz()
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
                        if ((i.Login_ID == Worker.id) && (i.Status == 0))
                        {
                            var b = new Busket();
                            foreach (Product_DB j in p)
                            {
                                if (j.P_ID == i.P_ID)
                                {
                                    b.Orders_ID = i.Orders_ID;
                                    b.P_ID = i.P_ID;
                                    b.Title = j.Title;
                                    b.Amount = i.Amount;
                                    b.TotalCost = i.TotalCost;
                                    LabelTotal.Content = Convert.ToString(Convert.ToInt64(LabelTotal.Content)+i.TotalCost);


                                    List_Korz.Items.Add(b);

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
            Hub hub_wpf = new Hub();
            hub_wpf.Show();
            Close();
        }

        private void Button_Buy_Click(object sender, RoutedEventArgs e)
        {
            List_Korz.Items.Clear();
            using (Context_Orders dbo = new Context_Orders())
            {
                var o = dbo.Orders.ToList();
                foreach (Orders_DB i in o)
                {
                    if ((i.Login_ID == Worker.id) && (i.Status == 0))
                    {
                        i.Status = 1;
                        LabelTotal.Content = "0";
                        dbo.SaveChanges();
                    }
                }
            }
        }

        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            List_Korz.Items.Clear();
            using (Context_Orders dbo = new Context_Orders())
            {
                using (Context_Product dbp = new Context_Product())
                {


                    var o = dbo.Orders.ToList();
                    var p = dbp.Product.ToList();
                    foreach (Orders_DB i in o)
                    {
                        if ((i.Login_ID == Worker.id) && (i.Status == 0))
                        {
                            foreach (Product_DB j in p)
                            {
                                if (i.P_ID == j.P_ID)
                                {
                                    j.AmounthInStock += i.Amount;

                                    dbo.Orders.Remove(i);
                                    dbo.SaveChanges();
                                    dbp.SaveChanges();
                                    LabelTotal.Content = "0";
                                }

                            }
                        }
                    }



                }
            }
        }

        private void BDelete_Click(object sender, RoutedEventArgs e)
        {

            Busket? order = List_Korz.SelectedItem as Busket;
            using (Context_Orders dbo = new Context_Orders())
            {
                using (Context_Product dbp = new Context_Product())
                {

                    var o = dbo.Orders.ToList();
                    var p = dbp.Product.ToList();
                    foreach (Orders_DB i in o)
                    {
                        if (order.Orders_ID == i.Orders_ID)
                        {
                            foreach (Product_DB j in p)
                            {
                                if (order.P_ID == j.P_ID)
                                {
                                    j.AmounthInStock += i.Amount;
                                    LabelTotal.Content = Convert.ToString(Convert.ToInt64(LabelTotal.Content) - i.TotalCost);
                                    dbo.Orders.Remove(i);
                                    dbo.SaveChanges();
                                    dbp.SaveChanges();

                                }

                            }
                        }
                    }
                }
            }
            List_Korz.Items.Remove(List_Korz.SelectedItem);
        }

        private void BPlus_Click(object sender, RoutedEventArgs e)
        {
            using (Context_Orders dbo = new Context_Orders())
            {
                using (Context_Product dbp = new Context_Product())
                {
                    bool check = false;
                    var o = dbo.Orders.ToList();
                    var p = dbp.Product.ToList();
                    int index;
                    Busket? order = List_Korz.SelectedItem as Busket;
                   
                    index = List_Korz.SelectedIndex;


                    foreach (Product_DB i in p)
                    {
                        if ((order.P_ID == i.P_ID) && (order.Amount <= i.AmounthInStock))
                        {
                            check = true;
                            order.Amount += 1;
                      


                            i.AmounthInStock -= 1;

                            foreach (Orders_DB j in o)
                            {
                                if (order.Orders_ID == j.Orders_ID)
                                {
                                    LabelTotal.Content = Convert.ToString(Convert.ToInt64(LabelTotal.Content) + i.Price);
                                    order.TotalCost += i.Price;
                                    j.TotalCost += i.Price;
                                    j.Amount += 1;
                                    List_Korz.Items.Remove(List_Korz.SelectedItem);
                                    List_Korz.Items.Insert(index, order);
                                    break;
                                }


                            }
                            break;
                        }

                    }

                    if (check == false)
                    {

                        MessageBox.Show("Товара больше нет на сладе!", "KIT");

                    }
                   
                    List_Korz.SelectedIndex = index;
                    dbo.SaveChanges();
                    dbp.SaveChanges();
                }
            }
        }

        private void BMinus_Click(object sender, RoutedEventArgs e)
        {
            using (Context_Orders dbo = new Context_Orders())
            {
                using (Context_Product dbp = new Context_Product())
                {
                   
                    var o = dbo.Orders.ToList();
                    var p = dbp.Product.ToList();
                    int index;
                    Busket? order = List_Korz.SelectedItem as Busket;
                   
                    index = List_Korz.SelectedIndex;

                    foreach (Product_DB i in p)
                    {
                        if (order.P_ID == i.P_ID)
                        {
                            
                            order.Amount -= 1;
                            i.AmounthInStock += 1;

                            foreach (Orders_DB j in o)
                            {
                                if (order.Orders_ID == j.Orders_ID)
                                {
                                    LabelTotal.Content = Convert.ToString(Convert.ToInt64(LabelTotal.Content) - i.Price);
                                    order.TotalCost -= i.Price;
                                    j.TotalCost -= i.Price;
                                    j.Amount -= 1;
                                    List_Korz.Items.Remove(List_Korz.SelectedItem);
                                   
                                    if(order.Amount>0)
                                    {
                                        List_Korz.Items.Insert(index, order);
                                    }
                                   else
                                    {
                                        dbo.Orders.Remove(j);
                                        List_Korz.Items.Remove(List_Korz.SelectedItem);

                                    }
                                    break;
                                }


                            }
                           
                        }
                       
                    }


                  
                    List_Korz.SelectedIndex = index;
                    dbo.SaveChanges();
                    dbp.SaveChanges();

                }
            }
        }
    }
}
