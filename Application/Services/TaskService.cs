using Application.ServiceInterfaces;
using Domain;
using Domain.Common.Enums;
using Domain.Dto;
using Domain.RepositoryInterfaces;

namespace Application.Services
{
    public class TaskService(
        ITaskRepository _taskRepository,
        IJwtProvider _jwtProvider) : ITaskService
    {
        public async Task Insert(TaskInsertDto dto)
        {
            dto.State = StateEnum.None;

            string id = _jwtProvider.GetUserIdFromClaims();
            dto.UserId = int.Parse(id);

            await _taskRepository.Insert(dto);
        }

        public async Task<List<TaskDto>> GetAllTasks()
        {
            string id = _jwtProvider.GetUserIdFromClaims();
            int newId = int.Parse(id);

            return await _taskRepository.GetAllTasks(newId);
        }
    }
}
