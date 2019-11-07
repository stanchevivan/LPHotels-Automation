using System;
using Fourth.LabourProductivity.Scheduling.Domain.Models;

namespace Tests.API.Infrastructure
{
    public interface ILpHotelsMainUnitOfWork : IDisposable
    {
        IRepository<Employee> Employees { get; }

        int Save();
    }
}
