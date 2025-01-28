using Web.Blazor2.Common.StateEnum;

namespace Web.Blazor2.Dtos
{
    public class TaskInsertDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public StateEnum State { get; set; }
        public bool IsCompleted { get; set; }
        public int UserId { get; set; }
    }
}
