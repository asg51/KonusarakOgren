using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class MyContext : DbContext
    {
        public DbSet<Quiz> Quizs { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = new FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).Directory.FullName;
            optionsBuilder.UseSqlite($"Data Source={path}/database.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quiz>().ToTable("Quizs");
            modelBuilder.Entity<Question>().ToTable("Questions");
            modelBuilder.Entity<Admin>().ToTable("Admins");
        }
    }
}
