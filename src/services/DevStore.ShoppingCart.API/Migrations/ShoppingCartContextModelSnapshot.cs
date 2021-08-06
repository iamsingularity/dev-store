﻿// <auto-generated />
using System;
using DevStore.ShoppingCart.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DevStore.ShoppingCart.API.Migrations
{
    [DbContext(typeof(ShoppingCartContext))]
    partial class ShoppingCartContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DevStore.ShoppingCart.API.Model.CartItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Image")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("ShoppingCartId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("DevStore.ShoppingCart.API.Model.ShoppingCartClient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("HasVoucher")
                        .HasColumnType("bit");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId")
                        .HasDatabaseName("IDX_Cliente");

                    b.ToTable("ShoppingCartClient");
                });

            modelBuilder.Entity("DevStore.ShoppingCart.API.Model.CartItem", b =>
                {
                    b.HasOne("DevStore.ShoppingCart.API.Model.ShoppingCartClient", "ShoppingCartClient")
                        .WithMany("Items")
                        .HasForeignKey("ShoppingCartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShoppingCartClient");
                });

            modelBuilder.Entity("DevStore.ShoppingCart.API.Model.ShoppingCartClient", b =>
                {
                    b.OwnsOne("DevStore.ShoppingCart.API.Model.Voucher", "Voucher", b1 =>
                        {
                            b1.Property<Guid>("ShoppingCartClientId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Code")
                                .HasColumnType("varchar(50)");

                            b1.Property<decimal?>("Discount")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<int>("DiscountType")
                                .HasColumnType("int");

                            b1.Property<decimal?>("Percentage")
                                .HasColumnType("decimal(18,2)");

                            b1.HasKey("ShoppingCartClientId");

                            b1.ToTable("ShoppingCartClient");

                            b1.WithOwner()
                                .HasForeignKey("ShoppingCartClientId");
                        });

                    b.Navigation("Voucher");
                });

            modelBuilder.Entity("DevStore.ShoppingCart.API.Model.ShoppingCartClient", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
