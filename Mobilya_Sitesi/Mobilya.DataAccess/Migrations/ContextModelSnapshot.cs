﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mobilya.DataAccess.Concrete.EntityFramework;

#nullable disable

namespace Mobilya.DataAccess.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.12");

            modelBuilder.Entity("Mobilya.Entity.Advice", b =>
                {
                    b.Property<int>("AdviceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AdviceId");

                    b.ToTable("Advices");
                });

            modelBuilder.Entity("Mobilya.Entity.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CartId");

                    b.HasIndex("UserId");

                    b.ToTable("Carts");

                    b.HasData(
                        new
                        {
                            CartId = 1,
                            CreatedDate = new DateTime(2024, 3, 9, 18, 16, 59, 111, DateTimeKind.Local).AddTicks(4244),
                            UserId = 1
                        },
                        new
                        {
                            CartId = 2,
                            CreatedDate = new DateTime(2024, 3, 9, 18, 16, 59, 111, DateTimeKind.Local).AddTicks(4245),
                            UserId = 2
                        },
                        new
                        {
                            CartId = 3,
                            CreatedDate = new DateTime(2024, 3, 9, 18, 16, 59, 111, DateTimeKind.Local).AddTicks(4274),
                            UserId = 3
                        });
                });

            modelBuilder.Entity("Mobilya.Entity.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CartId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("Mobilya.Entity.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Koltuk "
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Masa"
                        });
                });

            modelBuilder.Entity("Mobilya.Entity.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Cvv")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ExpirationMonth")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ExpirationYear")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Mobilya.Entity.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Mobilya.Entity.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("ProductName")
                        .HasColumnType("TEXT");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 1,
                            Description = "Chester1",
                            Image = "chester.jpg",
                            Price = 15000.0,
                            ProductName = "Super Chester"
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 1,
                            Description = "Chester2",
                            Image = "chester2.jpg",
                            Price = 13000.0,
                            ProductName = "Normal Chester"
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 1,
                            Description = "Classic",
                            Image = "klasik.jpg",
                            Price = 12500.0,
                            ProductName = "Classical"
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 1,
                            Description = "Sport",
                            Image = "spor.jpg",
                            Price = 12750.0,
                            ProductName = "Sport"
                        },
                        new
                        {
                            ProductId = 5,
                            CategoryId = 1,
                            Description = "Semi - Chester",
                            Image = "yarim-chester.jpg",
                            Price = 12000.0,
                            ProductName = "Semi - Chester"
                        },
                        new
                        {
                            ProductId = 6,
                            CategoryId = 2,
                            Description = "Masa1",
                            Image = "masa1.jpg",
                            Price = 7000.0,
                            ProductName = "Super Masa"
                        },
                        new
                        {
                            ProductId = 7,
                            CategoryId = 2,
                            Description = "Masa2",
                            Image = "masa2.jpg",
                            Price = 6500.0,
                            ProductName = "Normal Masa"
                        });
                });

            modelBuilder.Entity("Mobilya.Entity.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            RoleName = "Superadmin"
                        },
                        new
                        {
                            RoleId = 2,
                            RoleName = "Admin"
                        },
                        new
                        {
                            RoleId = 3,
                            RoleName = "Customer"
                        });
                });

            modelBuilder.Entity("Mobilya.Entity.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Password = "123456",
                            UserName = "superadmin"
                        },
                        new
                        {
                            UserId = 2,
                            Password = "123456",
                            UserName = "admin"
                        },
                        new
                        {
                            UserId = 3,
                            Password = "123456",
                            UserName = "customer"
                        });
                });

            modelBuilder.Entity("Mobilya.Entity.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 2,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 3,
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("Mobilya.Entity.Cart", b =>
                {
                    b.HasOne("Mobilya.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Mobilya.Entity.CartItem", b =>
                {
                    b.HasOne("Mobilya.Entity.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mobilya.Entity.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Mobilya.Entity.Order", b =>
                {
                    b.HasOne("Mobilya.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Mobilya.Entity.OrderDetail", b =>
                {
                    b.HasOne("Mobilya.Entity.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mobilya.Entity.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Mobilya.Entity.Product", b =>
                {
                    b.HasOne("Mobilya.Entity.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Mobilya.Entity.UserRole", b =>
                {
                    b.HasOne("Mobilya.Entity.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mobilya.Entity.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Mobilya.Entity.Cart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("Mobilya.Entity.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Mobilya.Entity.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("Mobilya.Entity.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Mobilya.Entity.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
