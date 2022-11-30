using Beca.KeyboardShop.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace Beca.KeyboardShop.DbContexts
{
    public class KeyboardShopDbContext : DbContext
    {

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Keyboard> Keyboards { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;


        public KeyboardShopDbContext(DbContextOptions<KeyboardShopDbContext> options) : base(options)
        {}

        protected override async void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Keyboard>().HasData(
                    new Keyboard("Logitech MX", 149.99)
                    {
                        Id = 1,
                        Discounter = true,
                        OfferInSeconds = 1000,
                        CategoryId = 1,
                        Description = "A minimalist keyboard with a US QWERTY key layout for Mac computers."
                    },
                    new Keyboard("Forgeon Clutch 60% Switch Brown", 99.99)
                    {
                        Id = 2,
                        Discounter = true,
                        OfferInSeconds = 200,
                        CategoryId = 2,
                        Description = "An ergonomic and sophisticated keyboard that will give you a great gaming experience."
                    },
                    new Keyboard("Logitech K380", 54.99)
                    {
                        Id = 3,
                        CategoryId = 1,
                        Description = "The Logitech® K380 Bluetooth® keyboard makes any space minimalist, modern and multi-device."
                    }
                );

            modelBuilder.Entity<Category>().HasData(
                    new Category("Slim") { Id = 1 },
                    new Category("Mechanical") { Id = 2 }
                );


            var hasher = new PasswordHasher<IdentityUser>();

            modelBuilder.Entity<User>().HasData(
                    new User()
                    {
                        Id = 1,
                        UserName = "Mayo",
                        Password = hasher.HashPassword(null, "Mayo123!")
                    }

                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
