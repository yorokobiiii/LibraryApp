using Microsoft.EntityFrameworkCore;
using LibraryApp.Models;

namespace LibraryApp.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) 
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Война и мир", Author = "Лев Толстой", Genre = "Роман", Year = 1869 },
                new Book { Id = 2, Title = "Преступление и наказание", Author = "Фёдор Достоевский", Genre = "Роман", Year = 1866 },
                new Book { Id = 3, Title = "Мастер и Маргарита", Author = "Михаил Булгаков", Genre = "Роман", Year = 1967 }
            );

            modelBuilder.Entity<Reader>().HasData(
                new Reader { Id = 1, FirstName = "Иван", LastName = "Петров", Email = "ivan@mail.ru", Phone = "+79991234567", IsPremium = true },
                new Reader { Id = 2, FirstName = "Мария", LastName = "Сидорова", Email = "maria@mail.ru", Phone = "+79997654321", IsPremium = false }
            );
        }
    }
}