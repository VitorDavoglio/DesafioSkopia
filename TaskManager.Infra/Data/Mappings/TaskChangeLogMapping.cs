using System;
using TaskManager.Domain.Aggregate;
using TaskManager.Domain.ValueObjects;

namespace TaskManager.Infra.Data.Mappings
{
    public class TaskChangeLogMapping
    {
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public string Field { get; set; }
        public string PreviousValue { get; set; }
        public string UpdatedValue { get; set; }
        public Guid UpdaterId { get; set; }
        public DateTime UpdateDate { get; set; }

        public static explicit operator TaskChange(TaskChangeLogMapping mapping) {
            return new TaskChange()
            {
                Field = mapping.Field,
                PreviousValue = mapping.PreviousValue,
                UpdateDate = mapping.UpdateDate,
                UpdatedValue = mapping.UpdatedValue,
                UpdaterId = mapping.UpdaterId,
            };
        }
       
    }
}
