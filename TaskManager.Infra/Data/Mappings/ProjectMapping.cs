using System;
using System.Collections.Generic;
using System.Linq;
using TaskManager.Domain.Entities;

namespace TaskManager.Infra.Data.Mappings
{
    public class ProjectMapping
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }

        public IEnumerable<TaskMapping> Tasks { get; set; }
        public UserMapping Owner { get; set; }

        public static explicit operator Project(ProjectMapping mapping)
        {
            if (mapping == null) return null;
            return new Project()
            {
                Id = mapping.Id != default ? mapping.Id : null,
                OwnerId = mapping.OwnerId,
                Owner = (User)mapping.Owner,
                Tasks = mapping.Tasks?.Select(x => (Task)x),
            };
        }
        public static explicit operator ProjectMapping(Project entity)
        {
            if (entity == null) return null;
            return new ProjectMapping()
            {
                OwnerId = entity.OwnerId,
                Owner = (UserMapping)entity.Owner,
                Tasks = entity.Tasks?.Select(x => (TaskMapping)x),
            };
        }
    }
}
