using Lord.Gym.Application.Interfaces.Models;
using Lord.Gym.Domain.Entities.Auth;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Lord.Gym.Application.Interfaces.JWT
{
    public interface IJwtFactory
    {
        Task<AuthenticationResult> GenerateAuthenticationResultForUserAsync(AppUser user);

        ClaimsPrincipal GetPrincipalFromToken(string token);
    }
}