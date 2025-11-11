using TaskManager.Domain.Entities;

namespace TaskManager.Application.Resources
{
    public class ProjectQueryResult
    {
        public string User { get; set; }
        public IEnumerable<Project> Projects { get; set; }
    }
}
