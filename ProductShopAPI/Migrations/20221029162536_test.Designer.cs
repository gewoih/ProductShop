﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductShopAPI.DAL;

#nullable disable

namespace ProductShopAPI.Migrations
{
    [DbContext(typeof(ProductsDbContext))]
    [Migration("20221029162536_test")]
    partial class test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ProductShopLibrary.Products.Cart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("ProductShopLibrary.Products.CartProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("CartId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartProduct");
                });

            modelBuilder.Entity("ProductShopLibrary.Products.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("QuantityInStock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ProductShopLibrary.Purchases.CustomerInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("CustomerInfo");
                });

            modelBuilder.Entity("ProductShopLibrary.Purchases.Purchase", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CustomerInfoId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ProductCartId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerInfoId");

                    b.HasIndex("ProductCartId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("ProductShopLibrary.Products.CartProduct", b =>
                {
                    b.HasOne("ProductShopLibrary.Products.Cart", null)
                        .WithMany("Products")
                        .HasForeignKey("CartId");

                    b.HasOne("ProductShopLibrary.Products.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ProductShopLibrary.Purchases.Purchase", b =>
                {
                    b.HasOne("ProductShopLibrary.Purchases.CustomerInfo", "CustomerInfo")
                        .WithMany()
                        .HasForeignKey("CustomerInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductShopLibrary.Products.Cart", "ProductCart")
                        .WithMany()
                        .HasForeignKey("ProductCartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerInfo");

                    b.Navigation("ProductCart");
                });

            modelBuilder.Entity("ProductShopLibrary.Products.Cart", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
