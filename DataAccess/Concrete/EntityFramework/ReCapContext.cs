using Core.Entities;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class ReCapContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=desktop-f57a1sm;Database=ReCapDB;Trusted_Connection=True;TrustServerCertificate=True");
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<CarImage> CarImages { get; set; }

        // Eger olusturduğumuz Entity class ismi ile veritabanındaki tablo adları farklı ise,
        // OnModelCreating metodunu override ile aşağıdaki gibi doldururuz....

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Rental>().ToTable("Rentals");  // Tabloları eşleştirir.

        //    // Burada, car entity mizdeki her bir alan, tabloda hangi sütuna denk geliyor onu belirtiyoruz..
        //    modelBuilder.Entity<Rental>().Property(p => p.RentId).HasColumnName("RentId");
        //    modelBuilder.Entity<Rental>().Property(p => p.CarId).HasColumnName("CarId");
        //    modelBuilder.Entity<Rental>().Property(p => p.CustomerId).HasColumnName("CustomerId");
        //    modelBuilder.Entity<Rental>().Property(p => p.RentDate).HasColumnName("RentDate");
        //    modelBuilder.Entity<Rental>().Property(p => p.ReturnDate).HasColumnName("ReturnDate");

        //    //
        //    //

        //}

    }
}
