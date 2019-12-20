using System;
using TeamHours.DomainModel;
using Fourth.LabourProductivity.Scheduling.Domain.Scheduling.Models;
using Fourth.LabourProductivity.Scheduling.Domain.LabourDemands.Models;

namespace DataSeeding.Infrastructure
{
    public interface ILpHotelsMainUnitOfWork : IDisposable
    {
        IRepository<Location> Location { get; }

        IRepository<BankHoliday> BankHoliday { get; }

        IRepository<Organisation> Organisation { get; }

        IRepository<Department> Department { get; }

        IRepository<TempStaff> TempStaff { get; }

        IRepository<TempArea> TempArea { get; }

        IRepository<TempRole> TempRole { get; }

        IRepository<JobTitle> JobTitle { get; }

        IRepository<StaffPayInfo> StaffPayInfo { get; }

        IRepository<TempShift> TempShift { get; }

        IRepository<User> User { get; }

        IRepository<UserLevel> UserLevel { get; }

        IRepository<DailyPeriod> DailyPeriod { get; }

        IRepository<AdditionalRole> AdditionalRole { get; }

        IRepository<ScheduleDto> LabourDemandDto { get; }

        IRepository<SalesType> SalesType { get; }

        IRepository<ACTUALSALES_DEPARTMENT_BYSALESTYPE_INTERVAL> ACTUALSALES_DEPARTMENT_BYSALESTYPE_INTERVAL { get; }

        IRepository<WorkloadRules> WorkloadRules { get; }

        int SaveAsync();
    }
}
