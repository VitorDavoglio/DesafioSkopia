using System;
using System.Threading.Tasks;

namespace TaskManager.Domain.Interfaces.Services
{
    public interface ITaskService
    {
        Task<Entities.Task> UpdateTaskAndSaveHistory(Entities.Task newState, Guid updaterId);

        Task<Entities.Task> AddTaskToProject(Entities.Task newTask);
        Task<Entities.Task> AddCommentToTaskAndSaveHistory(Entities.Task task, Guid commenterId, string comment);
    }
}
