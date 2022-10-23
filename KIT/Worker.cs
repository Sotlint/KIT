using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;

namespace KIT
{
    public class Worker
    {
        public static int id;
        public static int id_r;

        public static int O_ID;

        public static int P_ID;

        static bool x = false;
        public static bool Check_authorization(string l, string p)
        {
            using (Context_authorization db = new Context_authorization())
            {

                var users = db.AuthData.ToList();
                foreach (AuthData_DB i in users)
                {
                    if (i.Login == l)
                    {
                        if (i.Password == p)
                        {
                            x = true;
                            id = i.Login_ID;
                            break;

                        }

                    }

                    else
                    {
                        x = false;
                    }
                }

            }
            return x;
        }
        public static bool Register(string login, string password, string LastName, string FirstName, string E_mail, string Telephone, string City, string Street, string Entrance, string Floor, string ApartmentNumber)
        {
            bool x = false;
            bool k = false;

            using (Context_authorization db0 = new Context_authorization())
            {
                using (Context_DeliverAddresData db1 = new Context_DeliverAddresData())
                {
                    using (Context_ContactData db2 = new Context_ContactData())
                    {
                        var users = db0.AuthData.ToList();
                        id_r = users.Count + 1;

                        AuthData_DB user0 = new AuthData_DB { DeliverAddres_ID = id_r, Contact_ID = id_r, Role = 1, Login = login, Password = password };
                        db0.AuthData.Add(user0);
                        try
                        {
                            db0.SaveChanges();
                            x = true;
                        }
                        catch
                        {
                            MessageBox.Show("Такой логин уже используется!", "KIT");
                            x = false;
                        }

                        DeliverAddresData_DB user1 = new DeliverAddresData_DB { Login_ID = id_r, Contact_ID = id_r, City = City, Street = Street, Entrance = Entrance, Floor = Floor, ApartmentNumber = ApartmentNumber };
                        db1.DeliverAddresData.Add(user1);
                        try
                        {
                            db1.SaveChanges();
                            x = true;
                        }
                        catch
                        {
                            x = false;
                        }

                        ContactData_DB user2 = new ContactData_DB { DeliverAddres_ID = id_r, FirstName = FirstName, LastName = LastName, };
                        db2.ContactData.Add(user2);

                        try
                        {
                            user2.Login_ID = id_r;
                            db2.SaveChanges();
                            x = true;
                        }
                        catch
                        {
                            x = false;
                        }

                        try
                        {
                            user2.E_mail = E_mail;
                            db2.SaveChanges();
                            x = true;
                        }

                        catch
                        {
                            MessageBox.Show("Такой E-mail уже используется!", "KIT");
                            x = false;
                        }

                        try
                        {
                            user2.Telephone = Telephone;
                            db2.SaveChanges();
                            x = true;
                        }

                        catch
                        {
                            MessageBox.Show("Такой телефон уже используется!", "KIT");
                            x = false;
                        }

                        if (x == false)
                        {
                            k = false;
                            db0.AuthData.Remove(user0);
                            db1.DeliverAddresData.Remove(user1);
                            db2.ContactData.Remove(user2);

                            db0.SaveChanges();

                        }
                        else
                        {
                            k = true;
                        }
                    }
                }
            }

            return k;

        }
        public static void Info(int id)
        {
            using (Context_authorization db0 = new Context_authorization())
            {

                using (Context_DeliverAddresData db1 = new Context_DeliverAddresData())
                {
                    using (Context_ContactData db2 = new Context_ContactData())
                    {
                        var user0 = db0.AuthData.ToList();
                        foreach (AuthData_DB i in user0)
                        {
                            if (i.Login_ID == id)
                            {
                                User_info.id = i.Login_ID;
                                User_info.Role = i.Role;
                                User_info.Login = i.Login;
                                User_info.Password = i.Password;

                            }
                        }


                        var user1 = db1.DeliverAddresData.ToList();
                        foreach (DeliverAddresData_DB i in user1)
                        {
                            if (i.Login_ID == id)
                            {
                                User_info.City = i.City;
                                User_info.Street = i.Street;
                                User_info.Entrance = i.Entrance;
                                User_info.Floor = i.Floor;
                                User_info.ApartmentNumber = i.ApartmentNumber;

                            }
                        }


                        var user2 = db2.ContactData.ToList();
                        foreach (ContactData_DB i in user2)
                        {
                            if (i.Login_ID == id)
                            {
                                User_info.E_mail = i.E_mail;
                                User_info.Telephone = i.Telephone;
                                User_info.LastName = i.LastName;
                                User_info.FirstName = i.FirstName;

                            }
                        }
                    }
                }
            }
        }
        public static bool Update(string login, string password, string LastName, string FirstName, string E_mail, string Telephone, string City, string Street, string Entrance, string Floor, string ApartmentNumber)
        {
            bool x = false;
            using (Context_authorization db = new Context_authorization())
            {
                var user = db.AuthData.ToList();
                foreach (AuthData_DB i in user)
                {
                    if (i.Login_ID == id)
                    {
                        try
                        {
                            i.Login = login;
                            i.Password = password;
                            db.SaveChanges();
                            x = true;
                        }
                        catch
                        {
                            MessageBox.Show("Такой логин уже используется!", "KIT");
                            x = false;
                        }
                        break;
                    }
                }
            }
            using (Context_DeliverAddresData db = new Context_DeliverAddresData())
            {
                var user = db.DeliverAddresData.ToList();
                foreach (DeliverAddresData_DB i in user)
                {
                    if (i.Login_ID == id)
                    {
                        i.City = City;
                        i.Street = Street;
                        i.Entrance = Entrance;
                        i.Floor = Floor;
                        i.ApartmentNumber = ApartmentNumber;

                        db.SaveChanges();
                        x = true;
                        break;
                    }

                }
            }
            using (Context_ContactData db = new Context_ContactData())
            {
                var user = db.ContactData.ToList();
                foreach (ContactData_DB i in user)
                {
                    if (i.Login_ID == id)
                    {
                        i.LastName = LastName;
                        i.FirstName = FirstName;
                        try
                        {
                            i.E_mail = E_mail;
                            db.SaveChanges();
                            x = true;
                        }
                        catch
                        {
                            MessageBox.Show("Такой E-mail уже используется!", "KIT");
                            x = false;
                        }

                        try
                        {
                            i.Telephone = Telephone;
                            db.SaveChanges();
                            x = true;
                        }
                        catch
                        {
                            MessageBox.Show("Такой телефон уже используется!", "KIT");
                            x = false;
                        }

                        break;
                    }
                }
            }
            return x;
        }

        public static void Delete(int id)
        {
            using (Context_authorization db = new Context_authorization())
            {
                var user = db.AuthData.ToList();

                foreach (AuthData_DB i in user)
                {
                    if (i.Login_ID == id)
                    {
                        db.AuthData.Remove(i);
                        db.SaveChanges();

                    }
                }
            }
        }

        public static void NewCategory(string text)
        {
            using (Context_Categories db = new Context_Categories())
            {
                Categories_DB C = new Categories_DB { Title = text };
                db.Categories.Add(C);

                try
                {
                    db.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Такая категория товаров уже существует!", "KIT");
                }
            }
        }

        public static void NewProduct(string title, int price, int amounth, int id, string text)
        {
            using (Context_Product db = new Context_Product())
            {
                Product_DB P = new Product_DB { Title = title, Price = price, AmounthInStock = amounth, C_ID = id, Text = text };
                db.Product.Add(P);
                try
                {
                    db.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Такой товар уже существует!", "KIT");
                }

            }
        }

        public static void DeleteProduct(int id)
        {
            using (Context_Product db = new Context_Product())
            {
                var product = db.Product.ToList();

                foreach (Product_DB i in product)
                {
                    if (i.P_ID == id)
                    {
                        db.Product.Remove(i);
                        db.SaveChanges();
                    }
                }
            }
        }

        public static bool UpdateProduct(int id, string title, string price, string instock, string text)
        {
            using (Context_Product db = new Context_Product())
            {
                var product = db.Product.ToList();
                bool x = false;
                foreach (Product_DB i in product)
                {
                    if (i.P_ID == id)
                    {
                        try
                        {
                            i.Title = title;
                            i.Price = Convert.ToInt32(price);
                            i.AmounthInStock = Convert.ToInt32(instock);
                            i.Text = text;
                            db.SaveChanges();

                        }
                        catch
                        {
                            MessageBox.Show("Продукт с таким названием уже есть!", "KIT");
                            x = false;
                        }
                        finally
                        {
                            x = true;
                        }
                    }

                }
                return x;
            }
        }

        public static void UpdateBuyProduct(int p_id,int amount)
        {
            using (Context_Product db = new Context_Product())
            {
                var product = db.Product.ToList();
                foreach (Product_DB i in product)
                {
                    if (i.P_ID == p_id)
                    {
                        i.AmounthInStock-=amount;
                        db.SaveChanges();
                    }
                }
            }
        
        }
        public static void NewOrder(int login_id, int p_id ,int amount)
        {
            int totalcost = 0;
            int contact_id = 0;
            int deliver_id = 0;
            int c_id=0;

            using (Context_authorization db = new Context_authorization())
            {
                var users = db.AuthData.ToList();
                foreach (AuthData_DB i in users)
                {
                    if (i.Login_ID == login_id)
                    {
                        contact_id = i.Contact_ID;
                        deliver_id = i.DeliverAddres_ID;
                    }
                }
            }

            using (Context_Product db = new Context_Product())
            {
                var p = db.Product.ToList();
                foreach (Product_DB i in p)
                {
                    if (i.P_ID == p_id)
                    {
                        c_id = i.C_ID;
                        totalcost = i.Price * amount;
                    }
                }
            }


            using (Context_Orders db = new Context_Orders())
            {
                Orders_DB o = new Orders_DB { Login_ID = login_id, Contact_ID = contact_id, DeliverAddres_ID = deliver_id, C_ID = c_id, P_ID = p_id ,Status=0,Amount=amount,TotalCost=totalcost};
                db.Orders.Add(o);
                db.SaveChanges();
            }



            UpdateBuyProduct(p_id,amount);
        }

        public static void DelOrders_Status_2()
        {
            using (Context_Orders db = new Context_Orders())
            {
                var o = db.Orders.ToList();
                foreach (Orders_DB i in o)
                {
                    if(i.Status==2)
                    {
                        db.Orders.Remove(i);
                        
                    }
                }
                db.SaveChanges();
            }
        }

        public static void DelOrders_Any()
        {
            using (Context_Orders db = new Context_Orders())
            {
                var o = db.Orders.ToList();
                foreach (Orders_DB i in o)
                {
                    if (i.Orders_ID==O_ID)
                    {
                        db.Orders.Remove(i);

                    }
                }
                db.SaveChanges();
            }
        }

    }
}
