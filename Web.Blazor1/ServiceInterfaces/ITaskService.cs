using Web.Blazor1.Dtos;

namespace Web.Blazor1.ServiceInterfaces
{
    public interface ITaskService
    {
        Task Insert(TaskInsertDto dto);
        Task<List<TaskDto>> GetAllTasks();
    }
}
