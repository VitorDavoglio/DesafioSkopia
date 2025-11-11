
using System;
using System.Collections.Generic;
using TaskManager.Domain.Enums;
using TaskManager.Domain.ValueObjects;

namespace TaskManager.Domain.Entities
{
    public class Task
    {
        public Guid Id { get; set; }
        public Guid? ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public TaskStatus? CurrentStatus { get; set; }
        public TaskPriority? Priority { get; set; }
        public Project Project { get; set; }
        public IEnumerable<string> Comments { get; set; }
        public IEnumerable<TaskChange> ChangeLog { get; set; }


        public IEnumerable<TaskChange> PrepareUpdate(Task newState,Guid updaterId)
        {
            var changeList = new List<TaskChange>();
            if (this.Description != newState.Description)
            {
                changeList.Add(new TaskChange()
                {
                    Field = "description",
                    PreviousValue = this.Description,
                    UpdatedValue = newState.Description,
                    UpdateDate = DateTime.Now,
                    UpdaterId = updaterId,
                });
                this.Description = newState.Description;
            }
            if (this.CurrentStatus != newState.CurrentStatus)
            {
                changeList.Add(new TaskChange()
                {
                    Field = "currentStatus",
                    PreviousValue = this.Description,
                    UpdatedValue = newState.Description,
                    UpdateDate = DateTime.Now,
                    UpdaterId = updaterId,
                });
                this.CurrentStatus = newState.CurrentStatus;
            }
            return changeList;
        }

    }
}
