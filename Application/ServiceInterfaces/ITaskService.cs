using Domain.Dto;

namespace Application.ServiceInterfaces
{
    public interface ITaskService
    {
        Task Insert(TaskInsertDto dto);
        Task<List<TaskDto>> GetAllTasks();
    }
}
