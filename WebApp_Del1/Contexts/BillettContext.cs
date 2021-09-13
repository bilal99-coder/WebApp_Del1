using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Del1.Contexts
{
    public class BillettContext : DbContext
    {

        public BillettContext(DbContextOptions<BillettContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        //
        public DbSet<Lugar> lugarer { get; set; }
        public DbSet<Billett> billetter { get; set; }

        public DbSet<Person> personer { get; set; }
        public DbSet<BillettLugar> billettLugar { get; set; }
        public DbSet<BillettPerson> BillettPerson { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BillettLugar>().HasKey(table => new {
                table.billettId,
                table.lugarId
            });


            modelBuilder.Entity<BillettPerson>().HasKey(table => new {
                table.billettId,
                table.personId
            });
        }
    }

}
