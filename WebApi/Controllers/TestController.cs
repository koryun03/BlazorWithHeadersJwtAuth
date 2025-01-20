using Application.ServiceInterfaces;
using Domain.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController(ITaskService _taskService) : ControllerBase
    {
        [Authorize]
        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(TaskInsertDto dto)
        {
            await _taskService.Insert(dto);
            return Ok();
        }

        [Authorize]
        [HttpPut("Update")]
        public async Task<IActionResult> Update(TaskInsertDto dto)
        {
            await _taskService.Insert(dto);
            return Ok();
        }

        [Authorize]
        [HttpGet("GetAllTasks")]
        public async Task<IActionResult> GetAllTasks()
        {
            var result = await _taskService.GetAllTasks();
            return Ok(result);
        }

    }
}
