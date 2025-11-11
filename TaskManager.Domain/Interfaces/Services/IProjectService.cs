using Threading = System.Threading.Tasks;
using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Interfaces.Services
{
    public interface IProjectService
    {
        Threading.Task DeleteProject(Project project);
    }
}
