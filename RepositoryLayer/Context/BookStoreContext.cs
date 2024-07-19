using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Context
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions options) : base(options) { }

        public DbSet<UserEntity>? Users { get; set; }
        public DbSet<BookEntity>? Books { get; set; }
        public DbSet<CartEntity>? Carts { get; set; }
        public DbSet<CustomerDetailsEntity>? CustomerDetails { get; set; }
        public DbSet <OrderEntity>? Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>().HasIndex(u => u.Email).IsUnique();

            modelBuilder.Entity<CartEntity>()
                .HasOne(c=>c.UserEntity)
                .WithMany(c=>c.Carts)
                .HasForeignKey(c=>c.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CartEntity>()
               .HasOne(c => c.BookEntity)
               .WithMany(c => c.Carts)
               .HasForeignKey(c => c.BookId)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OrderEntity>()
               .HasOne(c => c.User)
               .WithMany(c => c.Orders)
               .HasForeignKey(c => c.UserEntityId)
               .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
