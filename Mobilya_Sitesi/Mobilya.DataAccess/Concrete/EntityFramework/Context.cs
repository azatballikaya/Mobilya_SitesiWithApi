using Microsoft.EntityFrameworkCore;
using Mobilya.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.DataAccess.Concrete.EntityFramework
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
                
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<User>().HasData(
                new User() { UserId = 1, Password = "123456", UserName = "superadmin" },
                new User() { UserId = 2, Password = "123456", UserName = "admin" },
                new User() { UserId = 3, Password = "123456", UserName = "customer" });
            modelBuilder.Entity<Role>().HasData(
                new Role() { RoleId = 1, RoleName = "Superadmin" },
                new Role() { RoleId = 2, RoleName = "Admin" },
                new Role() { RoleId = 3, RoleName = "Customer" });
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole() { UserId = 1, RoleId = 1 },
                new UserRole() { UserId = 2, RoleId = 2 },
                new UserRole() { UserId = 3, RoleId = 3 });
            modelBuilder.Entity<Category>().HasData(
                new Category() { CategoryId = 1, CategoryName = "Koltuk " },
                new Category() { CategoryId = 2, CategoryName = "Masa" });
            modelBuilder.Entity<Product>().HasData(
                new Product() { ProductId = 1, ProductName = "Super Chester", Price = 15000, Description = "Chester1", Image = "chester.jpg", CategoryId = 1 },
                new Product() { ProductId = 2, ProductName = "Normal Chester", Price = 13000, Description = "Chester2", Image = "chester2.jpg", CategoryId = 1 },
                new Product() { ProductId = 3, ProductName = "Classical", Price = 12500, Description = "Classic", Image = "klasik.jpg", CategoryId = 1 },
                new Product() { ProductId = 4, ProductName = "Sport", Price = 12750, Description = "Sport", Image = "spor.jpg", CategoryId = 1 },
                new Product() { ProductId = 5, ProductName = "Semi - Chester", Price = 12000, Description = "Semi - Chester", Image = "yarim-chester.jpg", CategoryId = 1 },
                new Product() { ProductId = 6, ProductName = "Super Masa", Price = 7000, Description = "Masa1", Image = "masa1.jpg", CategoryId = 2 },
                new Product() { ProductId = 7, ProductName = "Normal Masa", Price = 6500, Description = "Masa2", Image = "masa2.jpg", CategoryId = 2 }



                );
            modelBuilder.Entity<Cart>().HasData(
                new Cart() { CartId=1,CreatedDate=DateTime.Now,UserId=1},
                new Cart() { CartId=2,CreatedDate=DateTime.Now,UserId=2},
                new Cart() { CartId=3,CreatedDate=DateTime.Now,UserId=3}
                );
            //modelBuilder.Entity<Order>().
            //    HasMany<OrderDetail>(od => od.OrderDetails).
            //    WithOne(o => o.Order).HasForeignKey(f => f.OrderId);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders{ get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Advice> Advices { get; set; }


    }
}
