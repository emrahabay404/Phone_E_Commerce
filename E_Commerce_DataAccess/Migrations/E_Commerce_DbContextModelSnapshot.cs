﻿// <auto-generated />
using System;
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace E_Commerce_DataAccess.Migrations
{
    [DbContext(typeof(E_Commerce_DbContext))]
    partial class E_Commerce_DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("E_Commerce_Core.Entities.Concrete.OperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OperationClaims");
                });

            modelBuilder.Entity("E_Commerce_Core.Entities.Concrete.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("E_Commerce_Core.Entities.Concrete.UserOperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OperationClaimId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UserOperationClaims");
                });

            modelBuilder.Entity("E_Commerce_Entity.Concrete.Brand", b =>
                {
                    b.Property<int>("BrandID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BrandID"));

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BrandID");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("E_Commerce_Entity.Concrete.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("E_Commerce_Entity.Concrete.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerID"));

                    b.Property<string>("CustomerLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("E_Commerce_Entity.Concrete.Model", b =>
                {
                    b.Property<int>("ModelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ModelID"));

                    b.Property<int>("BrandID")
                        .HasColumnType("int");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ModelID");

                    b.HasIndex("BrandID");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("E_Commerce_Entity.Concrete.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderID"));

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("OrderStatus")
                        .HasColumnType("bit");

                    b.Property<float>("TotalPrice")
                        .HasColumnType("real");

                    b.HasKey("OrderID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("E_Commerce_Entity.Concrete.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderDetailId"));

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<float>("UnitPrice")
                        .HasColumnType("real");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("E_Commerce_Entity.Concrete.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ProductImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("UnitPrice")
                        .HasColumnType("real");

                    b.Property<int>("UnitsInStock")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("E_Commerce_Entity.Concrete.Version", b =>
                {
                    b.Property<int>("VersionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VersionID"));

                    b.Property<int>("ModelID")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("StockStatus")
                        .HasColumnType("int");

                    b.Property<int>("StorageCapacity")
                        .HasColumnType("int");

                    b.HasKey("VersionID");

                    b.HasIndex("ModelID");

                    b.ToTable("Versions");
                });

            modelBuilder.Entity("E_Commerce_Entity.Concrete.Model", b =>
                {
                    b.HasOne("E_Commerce_Entity.Concrete.Brand", "Brand")
                        .WithMany("Models")
                        .HasForeignKey("BrandID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("E_Commerce_Entity.Concrete.Order", b =>
                {
                    b.HasOne("E_Commerce_Entity.Concrete.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("E_Commerce_Entity.Concrete.OrderDetail", b =>
                {
                    b.HasOne("E_Commerce_Entity.Concrete.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_Commerce_Entity.Concrete.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("E_Commerce_Entity.Concrete.Product", b =>
                {
                    b.HasOne("E_Commerce_Entity.Concrete.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("E_Commerce_Entity.Concrete.Version", b =>
                {
                    b.HasOne("E_Commerce_Entity.Concrete.Model", "Model")
                        .WithMany("Versions")
                        .HasForeignKey("ModelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Model");
                });

            modelBuilder.Entity("E_Commerce_Entity.Concrete.Brand", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("E_Commerce_Entity.Concrete.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("E_Commerce_Entity.Concrete.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("E_Commerce_Entity.Concrete.Model", b =>
                {
                    b.Navigation("Versions");
                });

            modelBuilder.Entity("E_Commerce_Entity.Concrete.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("E_Commerce_Entity.Concrete.Product", b =>
                {
                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
