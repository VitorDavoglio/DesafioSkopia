using System;
using TaskManager.Domain.ValueObjects;

namespace TaskManager.Infra.Data.Mappings
{
    public class TaskCommentMapping
    {
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public Guid CreatorId { get; set; }

        public string Comment { get; set; }
        public DateTime Created { get; set; }


        public static explicit operator TaskCommentMapping(TaskComment comment)
        {
            return new TaskCommentMapping()
            {
                Comment = comment.Comment,
                Created = comment.Created,
                CreatorId = comment.Creator,
                TaskId = comment.TaskId,
            };
        }
        public static explicit operator TaskComment(TaskCommentMapping mapping)
        {
            return new TaskComment()
            {
                Comment = mapping.Comment,
                Created = mapping.Created,
                Creator = mapping.CreatorId,
                TaskId = mapping.TaskId,
            };
        }
    }
}
