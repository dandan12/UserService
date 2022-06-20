using Microsoft.Azure.Cosmos;
using UserService.Utils.Constants;

namespace UserService.Models
{
    public class CosmosDbSetting
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }    

        public async Task ConfigureCosmosDb()
        {
            var client = new CosmosClient(ConnectionString, new CosmosClientOptions() { ConnectionMode = ConnectionMode.Gateway });
            var database = await client.CreateDatabaseIfNotExistsAsync(DatabaseName);

            await database.Database.CreateContainerIfNotExistsAsync(ContainerConstant.Partners, "/id");
        }
    }

    
}
