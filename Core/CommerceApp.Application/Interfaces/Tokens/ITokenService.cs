using CommerceApp.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CommerceApp.Application.Interfaces.Tokens
{
    public interface ITokenService
    {
        Task<JwtSecurityToken> CreateToken(User user, List<string> roles);
        string GenerateRefreshToken();
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token);
    }
}
