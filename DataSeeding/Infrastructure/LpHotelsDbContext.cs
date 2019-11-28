using System;
using TeamHours.DomainModel;
using System.Data.Entity;
namespace DataSeeding.Infrastructure
{
    public class LpHotelsDbContext : TeamHoursDatabase
    {
        private static string CONNECTION_STRING = System.Configuration.ConfigurationManager.ConnectionStrings["LpHotelsDataBase"].ConnectionString;

        public LpHotelsDbContext() : this(CONNECTION_STRING)
        {

        }

        public LpHotelsDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }
    }
}
