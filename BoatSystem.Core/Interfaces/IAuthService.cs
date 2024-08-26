namespace BoatSystem.Core.Interfaces
{
    using BoatSystem.Core.Models;
    using System.IdentityModel.Tokens.Jwt;
    using System.Threading.Tasks;

    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);
        Task<AuthModel> Login(TokenRequestModel model);
        Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user);
    }
}
