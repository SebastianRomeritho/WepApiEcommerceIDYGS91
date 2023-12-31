﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WepApiEcommerceIDYGS91.Data;

#nullable disable

namespace WepApiEcommerceIDYGS91.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WepApiEcommerceIDYGS91.Models.Category", b =>
                {
                    b.Property<int>("IdCategory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idCategory");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCategory"), 1L, 1);

                    b.Property<string>("DescriptionCategory")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("descriptionCategory");

                    b.Property<string>("NameCategory")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nameCategory");

                    b.HasKey("IdCategory")
                        .HasName("PK__Category__79D361B69AF4766D");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("WepApiEcommerceIDYGS91.Models.Product", b =>
                {
                    b.Property<int>("IdProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idProduct");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProduct"), 1L, 1);

                    b.Property<string>("DescriptionProduct")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("descriptionProduct");

                    b.Property<int?>("IdCategory")
                        .HasColumnType("int");

                    b.Property<string>("ImageProduct")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("imageProduct");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("isActive");

                    b.Property<string>("NameProduct")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nameProduct");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("price");

                    b.Property<int?>("Stock")
                        .HasColumnType("int")
                        .HasColumnName("stock");

                    b.HasKey("IdProduct")
                        .HasName("PK__Product__5EEC79D16B119D94");

                    b.HasIndex("IdCategory");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("WepApiEcommerceIDYGS91.Models.Rol", b =>
                {
                    b.Property<int>("RolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RolId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RolId");

                    b.ToTable("Rols");
                });

            modelBuilder.Entity("WepApiEcommerceIDYGS91.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IsActive")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RolId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WepApiEcommerceIDYGS91.Models.Product", b =>
                {
                    b.HasOne("WepApiEcommerceIDYGS91.Models.Category", "oCategory")
                        .WithMany("Products")
                        .HasForeignKey("IdCategory")
                        .HasConstraintName("FK__Product__IdCateg__398D8EEE");

                    b.Navigation("oCategory");
                });

            modelBuilder.Entity("WepApiEcommerceIDYGS91.Models.User", b =>
                {
                    b.HasOne("WepApiEcommerceIDYGS91.Models.Rol", null)
                        .WithMany("Users")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WepApiEcommerceIDYGS91.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("WepApiEcommerceIDYGS91.Models.Rol", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
