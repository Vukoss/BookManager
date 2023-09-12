﻿// <auto-generated />
using System;
using BookAuthorApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BookAuthorApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230912200922_BookCategoryManyToManyFluentApiConfiguration")]
    partial class BookCategoryManyToManyFluentApiConfiguration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BookAuthorApp.Models.Author", b =>
                {
                    b.Property<int>("Author_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Author_Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Author_Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("BookAuthorApp.Models.Book", b =>
                {
                    b.Property<int>("Book_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Book_Id"));

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("Publisher_Id")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Book_Id");

                    b.HasIndex("Publisher_Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookAuthorApp.Models.BookAuthorMap", b =>
                {
                    b.Property<int>("Author_Id")
                        .HasColumnType("integer");

                    b.Property<int>("Book_Id")
                        .HasColumnType("integer");

                    b.HasKey("Author_Id", "Book_Id");

                    b.HasIndex("Book_Id");

                    b.ToTable("BookAuthorMaps");
                });

            modelBuilder.Entity("BookAuthorApp.Models.BookCategoryMap", b =>
                {
                    b.Property<int>("Book_Id")
                        .HasColumnType("integer");

                    b.Property<int>("Category_Id")
                        .HasColumnType("integer");

                    b.HasKey("Book_Id", "Category_Id");

                    b.HasIndex("Category_Id");

                    b.ToTable("BookCategoryMaps");
                });

            modelBuilder.Entity("BookAuthorApp.Models.BookDetail", b =>
                {
                    b.Property<int>("BookDetail_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BookDetail_Id"));

                    b.Property<int>("Book_Id")
                        .HasColumnType("integer");

                    b.Property<int>("NumberOfChapters")
                        .HasColumnType("integer");

                    b.Property<int>("NumberOfPages")
                        .HasColumnType("integer");

                    b.Property<string>("Weight")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("BookDetail_Id");

                    b.HasIndex("Book_Id")
                        .IsUnique();

                    b.ToTable("BookDetails");
                });

            modelBuilder.Entity("BookAuthorApp.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BookAuthorApp.Models.Publisher", b =>
                {
                    b.Property<int>("Publisher_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Publisher_Id"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Publisher_Id");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("BookAuthorApp.Models.Book", b =>
                {
                    b.HasOne("BookAuthorApp.Models.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("Publisher_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("BookAuthorApp.Models.BookAuthorMap", b =>
                {
                    b.HasOne("BookAuthorApp.Models.Author", "Author")
                        .WithMany("BookAuthorMap")
                        .HasForeignKey("Author_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookAuthorApp.Models.Book", "Book")
                        .WithMany("BookAuthorMap")
                        .HasForeignKey("Book_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BookAuthorApp.Models.BookCategoryMap", b =>
                {
                    b.HasOne("BookAuthorApp.Models.Book", "Book")
                        .WithMany("BookCategoryMaps")
                        .HasForeignKey("Book_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookAuthorApp.Models.Category", "Category")
                        .WithMany("BookCategoryMaps")
                        .HasForeignKey("Category_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BookAuthorApp.Models.BookDetail", b =>
                {
                    b.HasOne("BookAuthorApp.Models.Book", "Book")
                        .WithOne("BookDetail")
                        .HasForeignKey("BookAuthorApp.Models.BookDetail", "Book_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BookAuthorApp.Models.Author", b =>
                {
                    b.Navigation("BookAuthorMap");
                });

            modelBuilder.Entity("BookAuthorApp.Models.Book", b =>
                {
                    b.Navigation("BookAuthorMap");

                    b.Navigation("BookCategoryMaps");

                    b.Navigation("BookDetail")
                        .IsRequired();
                });

            modelBuilder.Entity("BookAuthorApp.Models.Category", b =>
                {
                    b.Navigation("BookCategoryMaps");
                });

            modelBuilder.Entity("BookAuthorApp.Models.Publisher", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
