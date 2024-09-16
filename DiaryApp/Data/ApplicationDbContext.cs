using DiaryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DiaryApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //4 kroki do stworzenia tabeli w bazie danych
            //1. Stworzenie klasy ktora bedzie reprezentowac tabele
            //2. Stworzenie klasy ktora bedzie dziedziczyc po DbContext
            //3. dodanie migracji adddiaryentrytable
            //4. update-database
        }

        public DbSet<DiaryEntry> DiaryEntries { get; set; } //to jest 2 krok

        //seeding a data to our database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<DiaryEntry>().HasData(
                new DiaryEntry { Content = "Went hiking with John Doe",
                    Title = "Went Hiking",
                    Id = 1,
                    Created = DateTime.UtcNow },
                new DiaryEntry { Content = "Went shoping with John Doe",
                    Title = "Went Shoping",
                    Id = 2,
                    Created = DateTime.UtcNow },
                new DiaryEntry { Content = "Went diving with John Doe",
                    Title = "Went Diving",
                    Id = 3,
                    Created = DateTime.UtcNow }
                );

        }
    }
}
