using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Enums;
using TaskManager.Domain.ValueObjects;

namespace TaskManager.Infra.Data.Mappings
{
    public class TaskMapping
    {

        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public TaskStatus CurrentStatus { get; set; }
        public TaskPriority Priority { get; set; }

        public ProjectMapping Project { get; set; }
        public IEnumerable<TaskChangeLogMapping> ChangeHistory { get; set; }
        public IEnumerable<TaskCommentMapping> Comments { get; set; }


        public static explicit operator Task(TaskMapping mapping)
        {

            if (mapping == null) return null;

            return new Task()
            {
                ProjectId = mapping.ProjectId,
                CurrentStatus = mapping.CurrentStatus,
                Description = mapping.Description,
                DueDate = mapping.DueDate,
                Id = mapping.Id,
                Title = mapping.Title,
                Priority = mapping.Priority,
                Comments = mapping.Comments?.Select(x => x.Comment),
                ChangeLog = mapping.ChangeHistory?.Select(x => (TaskChange)x),
            };
        }

        public static explicit operator TaskMapping(Task entity)
        {
            if (entity == null) return null;

            return new TaskMapping()
            {
                ProjectId = entity.ProjectId ?? entity.ProjectId.Value,
                CurrentStatus = entity.CurrentStatus == null ? TaskStatus.Pending : entity.CurrentStatus.Value,
                Description = entity.Description,
                DueDate = entity.DueDate,
                Id = entity.Id,
                Title = entity.Title,
                Priority = entity.Priority == null ? TaskPriority.Low : entity.Priority.Value,
            };
        }
    }
}
