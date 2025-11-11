using System;

namespace TaskManager.Domain.ValueObjects
{
    public class TaskComment
    {
        public Guid TaskId { get; set; }
        public string Comment { get; set; }
        public DateTime Created { get; set; }
        public Guid Creator { get; set; }
    }
}
