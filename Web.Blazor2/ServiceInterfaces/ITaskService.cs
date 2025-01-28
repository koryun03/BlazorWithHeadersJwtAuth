using Web.Blazor2.Dtos;

namespace Web.Blazor2.ServiceInterfaces
{
    public interface ITaskService
    {
        Task<bool> Insert(TaskInsertDto dto);
        Task<List<TaskDto>> GetAllTasks();
    }
}
