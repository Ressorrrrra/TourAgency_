using DomainLevel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TourAgencyContext : DbContext
    {
        public virtual DbSet<Tour> Tours { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Direction> Directions { get; set; }
        public virtual DbSet<TransportType> TransportTypes { get; set; }
        public virtual DbSet<TourOperator> TourOperators { get; set; }

        public TourAgencyContext() : base()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=1;Database=TourAgency1; Include Error Detail=true");
        }

    }
}
