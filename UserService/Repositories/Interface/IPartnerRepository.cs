using Microsoft.Azure.Cosmos;
using UserService.Entities;

namespace UserService.Repositories.Interface
{
    public interface IPartnerRepository
    {
        Partner GetPartnerByCredential(string username, string pasword);
    }
}
