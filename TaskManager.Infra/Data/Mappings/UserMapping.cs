using System;
using System.Collections.Generic;
using System.Linq;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Enums;

namespace TaskManager.Infra.Data.Mappings
{
    public class UserMapping
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }
        public UserRole Role { get; set; }
        public IEnumerable<ProjectMapping> Projects { get; set; }

        public static explicit operator User(UserMapping mapping) {
            if (mapping == null)
                return null;
            return new User()
            {
                Account = mapping.Account,
                Id = mapping.Id,
                Name = mapping.Name,
                Projects = mapping.Projects?.Select(x => (Project)x)
            };
        }
        public static explicit operator UserMapping(User entity)
        {
            if (entity == null)
                return null;
            return new UserMapping()
            {
                Account = entity.Account,
                Id = entity.Id,
                Name = entity.Name,
                Role = entity.Role,
                Projects = entity.Projects?.Select(x => (ProjectMapping)x)
            };
        }
    }
}
