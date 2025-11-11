using MediatR;
using TaskManager.Application.Queries;
using TaskManager.Application.Results;
using TaskManager.Domain.Interfaces.Repositories;

namespace TaskManager.Application.Handlers
{
    public class ReportQueryHandler : IRequestHandler<GetPerformanceReportByUserQuery, PerformanceReport>
    {
        private readonly IReportRepository _reportRepository;

        public ReportQueryHandler(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<PerformanceReport> Handle(GetPerformanceReportByUserQuery request, CancellationToken cancellationToken)
        {
            var taskReport = _reportRepository.BuildReport(request.TargetUserId,request.StartDate,request.EndDate);
            return new PerformanceReport()
            {
                CompletedTaskCount = taskReport.Count(),
                UserId = request.TargetUserId
            };
        }
    }
}
