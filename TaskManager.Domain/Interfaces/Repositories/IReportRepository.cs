using System;
using System.Linq;

namespace TaskManager.Domain.Interfaces.Repositories
{
    public interface IReportRepository
    {
        IQueryable<Entities.Task> BuildReport(Guid userId, DateTime startDate, DateTime endDate);
    }
}
