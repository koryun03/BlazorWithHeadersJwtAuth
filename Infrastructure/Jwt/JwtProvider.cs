using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain;
using Domain.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Jwt
{
    public class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions _options;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public JwtProvider(IOptions<JwtOptions> options, IHttpContextAccessor httpContextAccessor)
        {
            _options = options.Value;
            _httpContextAccessor = httpContextAccessor;
        }

        public string GenerateToken(UserDto u)
        {
            Claim[] c = [new("userId", u.Id.ToString())];

            //var c = new[]
            //   {
            //      new Claim ("userId", u.Id.ToString()),
            //      new Claim (ClaimTypes.Role, "User")
            //   };

            var signingCredentials = new SigningCredentials
                (new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)), SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: c, //claim-y stex ogtagorcvuma vor token-ic karenanq baci exacic urish info el stananq, es depqum orinak id enq stanum
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddHours(_options.ExpiresHours));

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token); //token-y sarqinq string

            return tokenValue;
        }

        public string GetUserIdFromClaims()
        {
            var user = _httpContextAccessor.HttpContext?.User;

            var userIdClaim = user?.Claims.FirstOrDefault(c => c.Type == "userId");

            return userIdClaim?.Value; // Возвращаем значение claim или null, если его нет
        }
    }
}
