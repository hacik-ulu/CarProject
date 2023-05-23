using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class ProjectDatabaseContext : DbContext
    {
        //Hangi veritabanına bağlanılacağı karar verildi.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server =HACIKULU1\SQLEXPRESS;Database =ProjectDatabase;Trusted_Connection=true");
        }


        //Hangi class hangi tabloya karşılık geliyor.
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rental> Rentals { get; set; }


    }
}


