﻿// <auto-generated />
using System;
using Beartic.Infraestructure.DataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Beartic.Api.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Beartic.Core.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("customers", (string)null);
                });

            modelBuilder.Entity("Beartic.Core.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date")
                        .HasColumnName("Create_Date");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("date")
                        .HasColumnName("Modification_Date");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("Status");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("orders", (string)null);
                });

            modelBuilder.Entity("Beartic.Core.Entities.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("orderItems");
                });

            modelBuilder.Entity("Beartic.Core.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(500)")
                        .HasColumnName("Description");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal")
                        .HasColumnName("Price");

                    b.Property<int>("QuantityOnHand")
                        .HasColumnType("int")
                        .HasColumnName("QuantityOnHand");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Title");

                    b.HasKey("Id");

                    b.ToTable("products", (string)null);
                });

            modelBuilder.Entity("Beartic.Core.Entities.Customer", b =>
                {
                    b.OwnsOne("Beartic.Shared.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("varchar(100)")
                                .HasColumnName("Address_City");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("varchar(50)")
                                .HasColumnName("Address_Country");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnType("varchar(10)")
                                .HasColumnName("Address_Number");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasColumnType("varchar(100)")
                                .HasColumnName("Address_State");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("varchar(100)")
                                .HasColumnName("Address_Street");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasColumnType("varchar(8)")
                                .HasColumnName("Address_ZipCode");

                            b1.HasKey("CustomerId");

                            b1.ToTable("customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.OwnsOne("Beartic.Shared.ValueObjects.Document", "Document", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnType("varchar(14)")
                                .HasColumnName("Document_Number");

                            b1.Property<int>("Type")
                                .HasColumnType("int")
                                .HasColumnName("Document_Type");

                            b1.HasKey("CustomerId");

                            b1.ToTable("customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.OwnsOne("Beartic.Shared.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("varchar(100)")
                                .HasColumnName("Email_Address");

                            b1.HasKey("CustomerId");

                            b1.ToTable("customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.OwnsOne("Beartic.Shared.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Firstname")
                                .IsRequired()
                                .HasColumnType("varchar(50)")
                                .HasColumnName("Firstname");

                            b1.Property<string>("Lastname")
                                .IsRequired()
                                .HasColumnType("varchar(50)")
                                .HasColumnName("Lastname");

                            b1.HasKey("CustomerId");

                            b1.ToTable("customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.OwnsOne("Beartic.Shared.ValueObjects.Phone", "Phone", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnType("varchar(11)")
                                .HasColumnName("Phone_Number");

                            b1.HasKey("CustomerId");

                            b1.ToTable("customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Document")
                        .IsRequired();

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Name")
                        .IsRequired();

                    b.Navigation("Phone")
                        .IsRequired();
                });

            modelBuilder.Entity("Beartic.Core.Entities.Order", b =>
                {
                    b.HasOne("Beartic.Core.Entities.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Beartic.Core.ValueObjects.Installment", "Installment", b1 =>
                        {
                            b1.Property<Guid>("OrderId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("InstallmentPrice")
                                .HasColumnType("decimal")
                                .HasColumnName("Installment_Price");

                            b1.Property<int>("Installments")
                                .HasColumnType("int")
                                .HasColumnName("Installments");

                            b1.Property<DateTime>("ModifiedAt")
                                .HasColumnType("date")
                                .HasColumnName("Installment_Modification_Date");

                            b1.Property<decimal>("Price")
                                .HasColumnType("decimal")
                                .HasColumnName("Price");

                            b1.HasKey("OrderId");

                            b1.ToTable("orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.Navigation("Customer");

                    b.Navigation("Installment")
                        .IsRequired();
                });

            modelBuilder.Entity("Beartic.Core.Entities.OrderItem", b =>
                {
                    b.HasOne("Beartic.Core.Entities.Order", null)
                        .WithMany("Items")
                        .HasForeignKey("OrderId");

                    b.HasOne("Beartic.Core.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Beartic.Core.Entities.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Beartic.Core.Entities.Order", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
