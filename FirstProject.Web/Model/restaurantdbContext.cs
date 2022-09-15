using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FirstProject.Web.Model
{
    public partial class restaurantdbContext : DbContext
    {
        public restaurantdbContext()
        {
        }

        public restaurantdbContext(DbContextOptions<restaurantdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<RestaurantMenu> RestaurantMenus { get; set; }
        public virtual DbSet<RestaurantMenuCustomer> RestaurantMenuCustomers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=MSI\\SQLEXPRESS;Database=restaurantdb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("date");
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.ToTable("Restaurant");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("date");
            });

            modelBuilder.Entity<RestaurantMenu>(entity =>
            {
                entity.ToTable("RestaurantMenu");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.MealName).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("date");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.RestaurantMenus)
                    .HasForeignKey(d => d.RestaurantId)
                    .HasConstraintName("FK_RestaurantMenu_Restaurant");
            });

            modelBuilder.Entity<RestaurantMenuCustomer>(entity =>
            {
                entity.ToTable("RestaurantMenu_Customer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.RestaurantMenuCustomers)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_RestaurantMenu_Customer_Customer");

                entity.HasOne(d => d.RestaurantMenu)
                    .WithMany(p => p.RestaurantMenuCustomers)
                    .HasForeignKey(d => d.RestaurantMenuId)
                    .HasConstraintName("FK_RestaurantMenu_Customer_RestaurantMenu");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
