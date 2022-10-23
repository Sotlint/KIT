using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KIT
{

    public class AuthData_DB
    {
        [Key]
        public int Login_ID { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }


        public int Contact_ID { get; set; }
        public int DeliverAddres_ID { get; set; }
        public int Role { get; set; }
    }



    public class ContactData_DB
    {
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? E_mail { get; set; }
        public string? Telephone { get; set; }
        public int Login_ID { get; set; }
        
        [Key]
        public int Contact_ID { get; set; }
        public int DeliverAddres_ID { get; set; }
   
    }


  
    public class DeliverAddresData_DB
    {
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? Entrance { get; set; }
        public string? Floor { get; set; }
        public string? ApartmentNumber { get; set; }
        public int Login_ID { get; set; }
        public int Contact_ID { get; set; }
        [Key]
        public int DeliverAddres_ID { get; set; }
    }


   
    public class Categories_DB
    {
        public string? Title { get; set; }
        [Key]
        public int C_ID { get; set; }
    }


  
    public class Product_DB
    {
        [Key]
        public int P_ID { get; set; }
        public int Price { get; set; }
        public int AmounthInStock { get; set; }
        public string? Title { get; set; }

        public string? Text { get; set; }
        public int C_ID { get; set; }
    }


   
    public class Orders_DB
    {
        [Key]
        public int Orders_ID { get; set; }
        public int Login_ID { get; set; }
        public int Contact_ID { get; set; }
        public int DeliverAddres_ID { get; set; }
        public int C_ID { get; set; }
        public int P_ID { get; set; }

        public int Status { get; set; }

        public int Amount { get; set; }

        public int TotalCost { get; set; }
    }


    public class Busket
    {
        public int Orders_ID { get; set; }
        public int P_ID { get; set; }
        public string? Title { get; set; }

        public int Amount { get; set; }

        public int TotalCost { get; set; }

    }

    public class Order_View
    {

        public int Orders_ID { get; set; }

        public int Login_ID { get; set; }
        public int P_ID { get; set; }
        public string? Title { get; set; }

        public string? Status { get; set; }
        public int Amount { get; set; }

        public int TotalCost { get; set; }
    }

}
