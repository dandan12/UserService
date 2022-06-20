using Microsoft.Azure.Cosmos;
using UserService.Attributes;
using UserService.Entities;
using UserService.Models;
using UserService.Utils.Constants;

namespace UserService.Contexts
{
    public class CosmosDbContext
    {
        private readonly CosmosDbSetting _setting;
        private CosmosClient _client;

        public CosmosDbContext(CosmosDbSetting setting)
        {
            _client = new CosmosClient(setting.ConnectionString);
            _setting = setting;
        }

        public Container Partners => _client.GetContainer(_setting.DatabaseName, ContainerConstant.Partners);

        public Container Get<T>()
        {
            var type = typeof(T);
            var attrs = type.GetCustomAttributes(false);
            var containerAttribute = attrs.Where(x => x is CosmosContainerAttribute).FirstOrDefault();
            if (containerAttribute == null)
                throw new Exception("No CosmosContainerAttribute attribute");

            var _containerAttribute = containerAttribute as CosmosContainerAttribute;
            return _client.GetContainer(_setting.DatabaseName, _containerAttribute?.Name);
        }
    }
}
