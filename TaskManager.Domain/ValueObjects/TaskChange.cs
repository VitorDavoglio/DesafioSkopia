using System;

namespace TaskManager.Domain.ValueObjects
{
    public class TaskChange
    {
        public string Field { get; set; }
        public string PreviousValue { get; set; }
        public string UpdatedValue { get; set; }
        public Guid UpdaterId { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
