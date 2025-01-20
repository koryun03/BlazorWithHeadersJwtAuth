using Application.ServiceInterfaces;
using Domain;
using Domain.Dto;
using Domain.RepositoryInterfaces;

namespace Application.Services
{
    public class UserService(
        IUserRepository _userRepository,
        IPasswordHasher _passwordHasher,
        IJwtProvider _jwtProvider) : IUserService
    {
        public async Task<bool> Register(UserInsertDto dto)
        {
            var user = await _userRepository.GetUserByLogin(dto.Login);

            if (user != null)
            {
                return false;
            }

            var hashedPassword = _passwordHasher.Generate(dto.Password);
            var newDto = new UserDto { Login = dto.Login, Password = hashedPassword };

            await _userRepository.Insert(newDto);

            return true;
        }

        public async Task<string> Login(UserDto dto)
        {
            var user = await _userRepository.GetUserByLogin(dto.Login);

            if (user == null)
            {
                return "";
            }

            var result = _passwordHasher.Verify(dto.Password, user.Password);

            // var token = _jwtProvider.GenerateToken(dto);
            var token = _jwtProvider.GenerateToken(user);

            return token;
        }

    }
}
