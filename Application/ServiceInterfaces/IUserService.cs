using Domain.Dto;

namespace Application.ServiceInterfaces
{
    public interface IUserService
    {
        Task<bool> Register(UserInsertDto dto);
        Task<string> Login(UserDto dto);
    }
}
