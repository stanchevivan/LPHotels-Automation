using System;
using TeamHours.DomainModel;

namespace Tests.API.Infrastructure
{
    public interface ILpHotelsMainUnitOfWork : IDisposable
    {
        IRepository<Location> Location { get; }

        IRepository<BankHoliday> BankHoliday { get; }

        IRepository<Organisation> Organisation { get; }

        IRepository<Department> Department { get; }

        IRepository<TempStaff> TempStaff { get; }

        IRepository<TempArea> TempArea { get; }

        int SaveAsync();
    }
}
