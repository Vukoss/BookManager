using System;
using BookAuthorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookAuthorApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthorMap> BookAuthorMaps { get; set; }
        public DbSet<BookCategoryMap> BookCategoryMaps { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql("Host = localhost; Database = BookAuthorDB; User ID = patryk; Port=5432;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasKey(u => u.Author_Id);
            modelBuilder.Entity<Author>().Property(u => u.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Author>().Property(u => u.LastName).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Author>().Ignore(a => a.FullName);

            modelBuilder.Entity<Book>().HasKey(u => u.Book_Id);
            modelBuilder.Entity<Book>().Property(u => u.Title).IsRequired();
            modelBuilder.Entity<Book>().Property(u => u.ISBN).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Book>().Ignore(b => b.PriceRange);
            modelBuilder.Entity<Book>().HasOne(b => b.Publisher).WithMany(b => b.Books).HasForeignKey(b => b.Publisher_Id);

            modelBuilder.Entity<BookDetail>().HasKey(d => d.BookDetail_Id);
            modelBuilder.Entity<BookDetail>().Property(d => d.NumberOfChapters).IsRequired();
            modelBuilder.Entity<BookDetail>().HasOne(d => d.Book).WithOne(d => d.BookDetail).HasForeignKey<BookDetail>(d => d.Book_Id);

            modelBuilder.Entity<Category>().HasKey(c => c.CategoryId);
            modelBuilder.Entity<Category>().Property(c => c.CategoryName).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<Publisher>().Property(p => p.Name).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Publisher>().HasKey(p => p.Publisher_Id);

            modelBuilder.Entity<BookAuthorMap>().HasKey(b => new { b.Author_Id, b.Book_Id });

            modelBuilder.Entity<BookAuthorMap>()
                .HasOne(b => b.Book)
                .WithMany(b => b.BookAuthorMap)
                .HasForeignKey(b => b.Book_Id);

            modelBuilder.Entity<BookAuthorMap>()
                .HasOne(a => a.Author)
                .WithMany(a => a.BookAuthorMap)
                .HasForeignKey(a => a.Author_Id);

            modelBuilder.Entity<BookCategoryMap>().HasKey(b => new { b.Book_Id, b.Category_Id });

            modelBuilder.Entity<BookCategoryMap>()
                .HasOne(b => b.Book)
                .WithMany(b => b.BookCategoryMaps)
                .HasForeignKey(b => b.Book_Id);
            modelBuilder.Entity<BookCategoryMap>()
                .HasOne(b => b.Category)
                .WithMany(b => b.BookCategoryMaps)
                .HasForeignKey(b => b.Category_Id);

        }
    }
}

