using Domain.Dto;

namespace Domain.RepositoryInterfaces
{
    public interface ITaskRepository
    {
        Task Insert(TaskInsertDto dto);
        Task<List<TaskDto>> GetAllTasks(int userId);
    }
}
