using System;
using System.Collections.Generic;
using System.Threading.Tasks.Dataflow;
using Bookstore_Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookstore_Ecommerce.Data;

public partial class BookEcContext : DbContext
{
    public BookEcContext()
    {
    }

    public BookEcContext(DbContextOptions<BookEcContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=KHALED;Database=BOOK_EC;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)

    {
        modelBuilder.Entity<Book>()
       .HasOne(b => b.Publish_house)
       .WithMany(ph => ph.books)
       .HasForeignKey(b => b.Publish_houseId)
       .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Book_Shop>().HasKey(am => new {am.Shopid,am.Bookid});   
        modelBuilder.Entity<Book_Shop>().HasOne(m=>m.book).WithMany(am =>am.Book_shop).HasForeignKey(m=> m.Bookid);
        modelBuilder.Entity<Book_Shop>().HasOne(m => m.shop).WithMany(am => am.Book_shop).HasForeignKey(m => m.Shopid);
        base.OnModelCreating(modelBuilder);
    
    }

    internal object Include(Func<object, object> value)
    {
        throw new NotImplementedException();
    }

    public DbSet<Book> books { get; set; }
    public DbSet<Author> author { get; set; }
    public DbSet<Shop> shops { get; set; }
    public DbSet<Publishing_House> publish_house { get; set; }
    public DbSet<Book_Shop> book_shop { get; set; }
}
