using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TaskManager.Domain.Interfaces.Repositories;
using TaskManager.Infra.Data.Context;

namespace TaskManager.Infra.Data.Repository
{
    public class ReportRepository:IReportRepository
    {
        protected readonly TaskManagerDbContext _dbContext;
        public ReportRepository(TaskManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Domain.Entities.Task> BuildReport(Guid userId, DateTime startDate, DateTime endDate)
        {
            var mapping = _dbContext.Tasks
                                    .Include(x => x.ChangeHistory)
                                    .Include(x => x.Project)
                                    .ThenInclude(x => x.Owner)
                                    .Where(task => task.Project.OwnerId == userId && task.CurrentStatus == Domain.Enums.TaskStatus.Completed)
                                    .Where(task => task.ChangeHistory.Any(change => change.UpdatedValue == "CurrentStatus" && (change.UpdateDate >= startDate && change.UpdateDate <= endDate)));


            return mapping.Select(x => (Domain.Entities.Task)x);
        }
    }
}
