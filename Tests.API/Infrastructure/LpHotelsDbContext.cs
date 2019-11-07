using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fourth.LabourProductivity.Scheduling.Domain.Models;

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

        //public virtual DbSet<EmployeeEntity> Employees { get; set; }

    }
}
