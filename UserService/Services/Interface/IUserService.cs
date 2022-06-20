using UserService.Entities;
using UserService.Models;

namespace UserService.Services.Interface
{
    public interface IUserService
    {
        TokenResponse GenerateToken(Partner partner);
    }
}
