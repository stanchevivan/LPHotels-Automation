using System;
using TeamHours.DomainModel;

namespace Tests.API.Infrastructure
{
    public interface ILpHotelsMainUnitOfWork : IDisposable
    {
        IRepository<Location> Location { get; }

        int Save();
    }
}
