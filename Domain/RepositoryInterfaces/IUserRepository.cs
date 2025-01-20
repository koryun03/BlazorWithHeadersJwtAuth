using Domain.Dto;

namespace Domain.RepositoryInterfaces
{
    public interface IUserRepository
    {
        Task Insert(UserDto dto);
        Task<UserDto> GetUserByLogin(string login);
    }
}
