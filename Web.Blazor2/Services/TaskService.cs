using Web.Blazor2.Dtos;
using Web.Blazor2.ServiceInterfaces;

namespace Web.Blazor2.Services
{
    public class TaskService(HttpClient _httpClient) : ITaskService
    {
        public async Task<List<TaskDto>> GetAllTasks()
        {
            //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "ваш-токен");

            //  var response = _httpClient.GetAsync("api/Task/GetAllTasks").Result;
            var response = await _httpClient.GetAsync("api/Task/GetAllTasks");
            // var response =await _httpClient.GetAsync("api/Task/GetAllTasks");

            //  var response = await _httpClient.GetStringAsync("api/Task/GetAllTasks");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<TaskDto>>();
                return result ?? new List<TaskDto>();
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> Insert(TaskInsertDto dto)
        {

            var response = await _httpClient.PostAsJsonAsync("api/Task/Insert", dto);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
