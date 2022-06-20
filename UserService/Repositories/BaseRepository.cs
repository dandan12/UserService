using Microsoft.Azure.Cosmos;
using UserService.Contexts;
using UserService.Entities;

namespace UserService.Repositories
{
    public class BaseRepository<T> where T : BaseEntity
    {
        private readonly CosmosDbContext _context;

        public BaseRepository(CosmosDbContext context)
        {
            _context = context;
        }

        public Container Container => _context.Get<T>();

        public Task<ItemResponse<T>> Get(string id)
        {
            return Container.ReadItemAsync<T>(id, new PartitionKey(id));
        }

        public Task<ItemResponse<T>> Save(T t)
        {
            t.Id = Guid.NewGuid().ToString();
            t.CreatedDate = DateTime.Now;
            t.ModifiedDate = DateTime.Now;

            return Container.CreateItemAsync(t, new PartitionKey(t.Id));
        }

        public Task<ItemResponse<T>> Update(string id, T t)
        {
            t.ModifiedDate = DateTime.Now;
            return Container.ReplaceItemAsync(t, id, new PartitionKey(id));
        }
    }
}
