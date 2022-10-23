using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KIT
{
    public class Context_authorization : DbContext
    {
        public DbSet<AuthData_DB>  AuthData { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DB\KIT.db");
        }
        public Context_authorization() => Database.EnsureCreated();
    }

    public class Context_ContactData : DbContext
    {
        public DbSet<ContactData_DB> ContactData { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DB\KIT.db");
        }
        public Context_ContactData() => Database.EnsureCreated();
    }

    public class Context_DeliverAddresData : DbContext
    {
        public DbSet<DeliverAddresData_DB> DeliverAddresData { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DB\KIT.db");
        }
        public Context_DeliverAddresData() => Database.EnsureCreated();
    }

    public class Context_Categories : DbContext
    {
        public DbSet<Categories_DB> Categories { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DB\KIT.db");
        }
        public Context_Categories() => Database.EnsureCreated();
    }

    public class Context_Product : DbContext
    {
        public DbSet<Product_DB> Product { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DB\KIT.db");
        }
        public Context_Product() => Database.EnsureCreated();
    }

    public class Context_Orders : DbContext
    {
        public DbSet<Orders_DB> Orders { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DB\KIT.db");
        }
        public Context_Orders() => Database.EnsureCreated();
    }




}
