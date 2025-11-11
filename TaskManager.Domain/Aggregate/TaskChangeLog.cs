using System;
using System.Collections.Generic;
using TaskManager.Domain.ValueObjects;

namespace TaskManager.Domain.Aggregate
{
    public class TaskChangeLog
    {
        public Guid TaskId { get; set; }
        public Entities.Task Task { get; set; }
        public IEnumerable<TaskChange> Changes { get; set; }
    }
}
