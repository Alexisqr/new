using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Shelter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelter.Infrastructure
{
    public class ComentDbContext : DbContext
    {
        public ComentDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Proect3_new2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        public ComentDbContext(DbContextOptions options):base(options) {

        }
        public DbSet<Goods> Goods { get; set; }
        public DbSet<ComentGlob> ComentGlobs { get; set; }
        public DbSet<ComentGood> ComentGoods { get; set; }
        public DbSet<ComentKindAnimals> ComentKindAnimalss { get; set; }
    }
}
