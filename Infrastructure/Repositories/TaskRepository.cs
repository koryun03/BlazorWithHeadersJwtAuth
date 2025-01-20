using Dapper;
using Domain.Dto;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using Infrastructure.Database;

namespace Infrastructure.Repositories
{
    public class TaskRepository(ISqlConnectionFactory _connectionFactory) : ITaskRepository
    {
        public async Task Insert(TaskInsertDto dto)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                await connection.OpenAsync();
                const string query = @"insert into TaskEntity(Title,Description,State,IsCompleted,UserId)
                                     Values(@Title,@Description,@State,@IsCompleted,@UserId);";

                await connection.ExecuteAsync(query, new TaskEntity
                {
                    Title = dto.Title,
                    Description = dto.Description,
                    State = dto.State,
                    IsCompleted = dto.IsCompleted,
                    UserId = dto.UserId,
                });
            }
        }

        public async Task<List<TaskDto>> GetAllTasks(int userId)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                await connection.OpenAsync();
                const string query = @"select * from TaskEntity where UserId=@userId";

                var tasks = await connection.QueryAsync<TaskEntity>(query, new { userId });
                var taskDto = tasks.Select(p => new TaskDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    State = p.State,
                    IsCompleted = p.IsCompleted,
                    UserId = p.UserId,
                })
                .ToList();

                return taskDto;
            }

        }

    }
}