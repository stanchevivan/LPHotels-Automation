using System;
using TeamHours.DomainModel;
using System.Data.Entity;
namespace Tests.API.Infrastructure
{
    public class LpHotelsDbContext : DbContext
    {
        private const string CONNECTION_STRING = "LpHotelsDataBase";

        public LpHotelsDbContext() : this($"name={CONNECTION_STRING}")
        {

        }

        public LpHotelsDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public virtual DbSet<Location> Location { get; set; }

    }
}
