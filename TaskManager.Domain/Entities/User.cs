using System;
using System.Collections.Generic;
using TaskManager.Domain.Enums;

namespace TaskManager.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }
        public UserRole Role { get; set; }
        public IEnumerable<Project> Projects { get; set; }
    }
}
