using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameWork
{
    //contex : Db tabloları ile proje classlarını bağlamak
    //DbContext Entityframework'deki bir context
    public class NorthWindContext:DbContext
    {
        // override yazıp bosluk bıraktık
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // tek ters slash'ın bir anlamı oldugu için
            // önüne @ getiririrz 

            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
