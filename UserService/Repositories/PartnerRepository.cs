using Microsoft.Azure.Cosmos;
using UserService.Contexts;
using UserService.Entities;
using UserService.Repositories.Interface;

namespace UserService.Repositories
{
    public class PartnerRepository : BaseRepository<Partner>, IPartnerRepository
    {
        private readonly CosmosDbContext _context;

        public PartnerRepository(CosmosDbContext context) : base(context)
        {
            _context = context;
        }

        public Partner GetPartnerByCredential(string username, string pasword)
        {
            var query = Container.GetItemLinqQueryable<Partner>(true);
            var item = query.Where(x => x.Username.Equals(username) && x.Password.Equals(pasword))
                .AsEnumerable()
                .FirstOrDefault();
            return item;
        }
    }
}
