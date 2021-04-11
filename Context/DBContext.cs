using Lab4Softbinator.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.IO;

namespace Lab4Softbinator.Context
{
    public class DBContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<StudentSubject> StudentSubjectAssociation { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var connString = new ConfigurationBuilder().SetBasePath(
               Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build().GetConnectionString("DB");

            optionsBuilder.UseSqlServer(connString);
        }


    }
}
