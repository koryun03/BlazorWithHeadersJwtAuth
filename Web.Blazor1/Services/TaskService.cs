using Web.Blazor1.Dtos;
using Web.Blazor1.ServiceInterfaces;

namespace Web.Blazor1.Services
{
    public class TaskService(HttpClient _httpClient) : ITaskService
    {
        public async Task<List<TaskDto>> GetAllTasks()
        {
            var response = await _httpClient.GetAsync("api/Task/GetAllTasks");

            if (response.IsSuccessStatusCode)
            {
                return null;
            }
            return null;

        }

        public async Task Insert(TaskInsertDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
