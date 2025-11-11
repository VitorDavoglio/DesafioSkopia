using MediatR;
using System.Text.Json.Serialization;

namespace TaskManager.Application.Commands
{
    public class AddCommentToTask: IRequest<Unit>
    {
        [JsonIgnore]
        public Guid TaskId { get; set; }

        [JsonIgnore]
        public Guid CommenterId { get; set; }
        public string Comment { get; set; }
    }
}
