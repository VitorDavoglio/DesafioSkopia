using MediatR;
using TaskManager.Application.Results;

namespace TaskManager.Application.Queries
{
    public class GetPerformanceReportByUserQuery:IRequest<PerformanceReport>
    {
        public Guid TargetUserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
