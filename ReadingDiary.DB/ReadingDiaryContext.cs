using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReadingDiary.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ReadingDiary.DB
{
    public class ReadingDiaryContext : DbContext
    {
        public DbSet<Author> Authors => Set<Author>();

        public DbSet<Book> Books => Set<Book>();

        public DbSet<Diary> Diaries => Set<Diary>();


        public DbSet<DiaryEntry> DiaryEntries => Set<DiaryEntry>();

        public ReadingDiaryContext(DbContextOptions<ReadingDiaryContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DiaryEntry>()
                .Property(p => p.StartDate);                
                

        }
    }

    public class ReadingDiaryFactory : IDesignTimeDbContextFactory<ReadingDiaryContext>
    {
        public ReadingDiaryContext CreateDbContext(string[] args)
        {
            var configPath = Path.GetFullPath("../ReadingDiary/appsettings.Development.json");
            var config = new ConfigurationBuilder()
               .AddJsonFile(configPath)
               .Build();
            var optionsBuilder = new DbContextOptionsBuilder<ReadingDiaryContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("ReadingDiary"));
            
            return new ReadingDiaryContext(optionsBuilder.Options);
        }
    }
}
