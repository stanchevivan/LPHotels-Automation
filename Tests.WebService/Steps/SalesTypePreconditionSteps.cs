using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Helpers;
using DataSeeding.Generators;
using DataSeeding.Infrastructure;
using Fourth.Automation.Framework.RestApi.Steps;
using Fourth.LabourProductivity.Scheduling.Domain.LabourDemands.Models;
using Fourth.LabourProductivity.Scheduling.Domain.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using TeamHours.DomainModel;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Tests.WebService.Steps
{
    [Binding]
    class SalesTypePreconditionSteps
    {
        private readonly ScenarioContext context;
        private readonly RestSession restSession;
        private readonly ILpHotelsMainUnitOfWork _lpHotelsMainUnitOfWork;

        public SalesTypePreconditionSteps(ScenarioContext context, RestSession restSession, ILpHotelsMainUnitOfWork lpHotelsMainUnitOfWork)
        {
            this.context = context;
            this.restSession = restSession;
            _lpHotelsMainUnitOfWork = lpHotelsMainUnitOfWork;
        }

        [Given(@"create sales types")]
        public void CreateSalesTypes()
        {
            var department = context.Get<Department>(Constants.Data.Department);
            var salesTypes = new SalesTypesEntityGenerator().GenerateMultiple(3, x =>
            {
                x.DepartmentID = department.ID;
            }).ToList();

            _lpHotelsMainUnitOfWork.SalesType.AddRange(salesTypes);
            _lpHotelsMainUnitOfWork.SaveAsync();

            context.Set(salesTypes, Constants.Data.SalesTypes);
        }

        [Given(@"create rule with (.*) and (.*)")]
        public void CreateRule(string required, string amount)
        {
            var departmentId = context.Get<Department>(Constants.Data.Department).ID;
            var roleID = context.Get<TempRole>(Constants.Data.Role).ID.ToString();
            var session1 = context.Get<List<DailyPeriod>>(Constants.Data.DailyPeriods)[0].ID;
            var session2 = context.Get<List<DailyPeriod>>(Constants.Data.DailyPeriods)[1].ID;
            var session3 = context.Get<List<DailyPeriod>>(Constants.Data.DailyPeriods)[2].ID;
            var sessionId = session1 + "," + session2 + "," + session3;
            var metadata = $"[{{\"SalesTypeIDs\":[0],\"SalesTypeID\":null,\"RoleID\":{roleID},\"People\":{required},\"Items\":{amount},\"DailyPeriods\":[{sessionId}],\"Index\":0,\"Sales\":true,\"DayString\":null,\"ExternalSalesTypes\":[]}}]";
            var rule = new WorkloadRules(metadata, departmentId);

            _lpHotelsMainUnitOfWork.WorkloadRules.Add(rule);
            _lpHotelsMainUnitOfWork.SaveAsync();
        }

        //        [Given(@"create rule with (.*) and (.*)")]
        //        public void CreateRules(string required1, string amount)
        //        {
        //            var departmentId = context.Get<Department>(Constants.Data.Department).ID;
        //            var roleID1 = context.Get<List<TempRole>>(Constants.Data.Roles)[0].ID.ToString();
        //            var session1 = context.Get<List<DailyPeriod>>(Constants.Data.DailyPeriods)[0].ID;
        //            var session2 = context.Get<List<DailyPeriod>>(Constants.Data.DailyPeriods)[1].ID;
        //            var session3 = context.Get<List<DailyPeriod>>(Constants.Data.DailyPeriods)[2].ID;
        //            var sessionId1 = session1;
        //            var sessionId2 = session2 + "," + session3;
        //            var metadata = $"[{{\"SalesTypeIDs\":[0],\"SalesTypeID\":null,\"RoleID\":{roleID1},\"People\":{required1},\"Items\":{amount},\"DailyPeriods\":[{sessionId1}],\"Index\":0,\"Sales\":true,\"DayString\":null,\"ExternalSalesTypes\":[]}
        //{\"SalesTypeIDs\":[0],\"SalesTypeID\":null,\"RoleID\":{roleID2},\"People\":{required2},\"Items\":{amount},\"DailyPeriods\":[{sessionId2}],\"Index\":0,\"Sales\":true,\"DayString\":null,\"ExternalSalesTypes\":[]}}]";
        //                var rule = new WorkloadRules(metadata, departmentId);

        //            _lpHotelsMainUnitOfWork.WorkloadRules.Add(rule);
        //            _lpHotelsMainUnitOfWork.SaveAsync();
        //        }
        [When(@"response should be with correct values (.*), (.*), (.*)")]
        [Then(@"response should be with correct values (.*), (.*), (.*)")]
        public void ResponseShouldBewithCorrectValues(DateTime onDate, int scheduledHours, int demandHours)
        {
            var restResponse = restSession.Response.Content;
 
            var response = JsonConvert.DeserializeObject<List<LabourDemandDto>>(restResponse);

            var employeeId = context.Get<TempStaff>(Constants.Data.Employee).ID;
            var sessions = context.Get<List<DailyPeriod>>(Constants.Data.DailyPeriods);
            var sessions1 = context.Get<List<DailyPeriod>>(Constants.Data.DailyPeriods)[0].ID.ToString();
            var roleID = context.Get<TempRole>(Constants.Data.Role).ID.ToString();



            var actualOnDate = response.Select(s=> s.OnDate);
            var byRoles = response.Select(d => d.ByRoles.Select(x => x.Key));
            var byRoleSessions = response.SelectMany(e => e.ByRoleSessions).Select(t => t.Key).ToList();
            var byRoleSessions3 = response.SelectMany(e => e.ByRoleSessions).Select(x => x.Value);
            var byRoleSessions1 = response.SelectMany(e => e.ByRoles).Select(x => x.Value);

            var expectedRoleSessions = new List<string>();

            foreach (var session in sessions)
            {
                 var list1 = roleID + "-" + session.ID;
                var list2 = "0" + "-" + session.ID;
                expectedRoleSessions.Add(list1);
                expectedRoleSessions.Add(list2);
            }


            //FirstSession
            var underHoursFirstRoleSession1 = response.SelectMany(e => e.ByRoleSessions).Where(d => d.Key.Contains(sessions[0].ID.ToString())).Select(v => v.Value).Select(f=> f.UnderHours).ToList()[0];
            var underHoursFirstRoleSession2 = response.SelectMany(e => e.ByRoleSessions).Where(d => d.Key.Contains(sessions[0].ID.ToString())).Select(v => v.Value).Select(f => f.UnderHours).ToList()[1];

            var overHoursFirstRoleSession1 = response.SelectMany(e => e.ByRoleSessions).Where(d => d.Key.Contains(sessions[0].ID.ToString())).Select(v => v.Value).Select(f => f.OverHours).ToList()[0];
            var overHoursFirstRoleSession2 = response.SelectMany(e => e.ByRoleSessions).Where(d => d.Key.Contains(sessions[0].ID.ToString())).Select(v => v.Value).Select(f => f.OverHours).ToList()[1];

            var correctHoursFirstRoleSession1 = response.SelectMany(e => e.ByRoleSessions).Where(d => d.Key.Contains(sessions[0].ID.ToString())).Select(v => v.Value).Select(f => f.CorrectHours).ToList()[0];
            var correctHoursFirstRoleSession2 = response.SelectMany(e => e.ByRoleSessions).Where(d => d.Key.Contains(sessions[0].ID.ToString())).Select(v => v.Value).Select(f => f.CorrectHours).ToList()[1];

            var scheduledHoursFirstRoleSession1 = response.SelectMany(e => e.ByRoleSessions).Where(d => d.Key.Contains(sessions[0].ID.ToString())).Select(v => v.Value).Select(f => f.ScheduledHours).ToList()[0];
            var scheduledHoursFirstRoleSession2 = response.SelectMany(e => e.ByRoleSessions).Where(d => d.Key.Contains(sessions[0].ID.ToString())).Select(v => v.Value).Select(f => f.ScheduledHours).ToList()[1];

            var averageDemandHoursFirstRoleSession1 = response.SelectMany(e => e.ByRoleSessions).Where(d => d.Key.Contains(sessions[0].ID.ToString())).Select(v => v.Value).Select(f => f.AverageDemandHours).ToList()[0];
            var averageDemandHoursFirstRoleSession2 = response.SelectMany(e => e.ByRoleSessions).Where(d => d.Key.Contains(sessions[0].ID.ToString())).Select(v => v.Value).Select(f => f.AverageDemandHours).ToList()[1];

            var AverageScheduledHoursFirstRoleSession1 = response.SelectMany(e => e.ByRoleSessions).Where(d => d.Key.Contains(sessions[0].ID.ToString())).Select(v => v.Value).Select(f => f.AverageScheduledHours).ToList()[0];
            var AverageScheduledHoursFirstRoleSession2 = response.SelectMany(e => e.ByRoleSessions).Where(d => d.Key.Contains(sessions[0].ID.ToString())).Select(v => v.Value).Select(f => f.AverageScheduledHours).ToList()[1];
            
            //averageDemandHours = RoundUp(scheduled Hours/session length hours)
            var averageScheduledHoursFirstSession = scheduledHours / ((sessions[0].EndMins - sessions[0].StartMins) / 60);
            //averageDemandHours = RoundUp(demand Hours/session length hours)
            var expectedAverageDemandHoursFirstSession = demandHours / ((sessions[0].EndMins - sessions[0].StartMins) / 60);
            //expectedunderHours = demandHours - correctHours(scheduledHours);
            var expectedUnderHours = (demandHours - scheduledHours) < 0 ? 0 : demandHours - scheduledHours;
            //expectedOverHours = scheduledHours - demandHours
            var expectedOverHours = (scheduledHours - demandHours) < 0 ? 0 : scheduledHours - demandHours;

            var expectedOverHours1 = Math.Max(0, scheduledHours - demandHours);
            var expectedUnderHours2 = Math.Max(0, demandHours - scheduledHours);




            var chargedDate = DateTime.UtcNow;


            var hoursss = 0;
            var shiftEnd = 0;

            var scheduledHoursqq = 0;
            var shifts = _lpHotelsMainUnitOfWork.TempShift.GetAll().Where(x => x.ChargedDate.Date == chargedDate.Date && x.TempStaffID == employeeId).ToList();

            foreach (var shift in shifts)
            {
                for(int i = 0; i < sessions.Count; i++)
                {
                    if (shift.EndDateTime.Value.Minute < (sessions[i].EndMins/60))
                    {
                         shiftEnd = shift.EndDateTime.Value.Minute;
                    }
                    else
                    {
                         shiftEnd = sessions[i].EndMins / 60;
                    }
                    
                }
                var hours = shiftEnd - (shift.StartDateTime.Hour);
                hoursss+= hours;
            }


            Assert.AreEqual(onDate, response.Select(s => s.OnDate).FirstOrDefault(), "Wrong Date");
                CollectionAssert.AreEquivalent(expectedRoleSessions, byRoleSessions);

        }
    }
}
