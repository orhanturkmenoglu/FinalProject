using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Context
{
    // Context nesnesi db tablosu ile projemizdeki nesne  classlarını ilişkilendirir
    // OnConfiguring(): bu metod bizim hangi veritabanıyla ilişkilendireceğimiz metot.
    // Database=Northwind tablosuna baglanacagız
    // Trusted_Connection=true ; kullanıcı adı ve şifremiz olmadığı içi direk bağlantı saglıyoruz
    public class NorthwindContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // veritabanına baglıyoruz.
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");
            
        }

        public DbSet<Product> Products { get; set; }  // Product classımızı Productsa eşitledik karşılığı Products
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}
