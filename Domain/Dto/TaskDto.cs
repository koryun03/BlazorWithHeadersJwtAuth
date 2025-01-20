using Domain.Common.Enums;

namespace Domain.Dto
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public StateEnum State { get; set; }
        public bool IsCompleted { get; set; }
        public int UserId { get; set; }
    }
}
