using Domain.Dto;

namespace Domain
{
    public interface IJwtProvider
    {
        string GenerateToken(UserDto dto);
        string GetUserIdFromClaims();
    }
}
