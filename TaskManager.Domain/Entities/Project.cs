using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace TaskManager.Domain.Entities
{
    public class Project
    {
        public Guid? Id { get; set; }
        public Guid OwnerId { get; set; }
        public User Owner { get; set; }
        public IEnumerable<Task> Tasks { get; set; }

        public bool CanBeDeleted => this.Tasks == null || !this.Tasks.Any(x => x.CurrentStatus == Enums.TaskStatus.Pending);
        public bool HasReachMaximumTaskLimit => this.Tasks != null && this.Tasks.Count() >= 20;

    }
}
