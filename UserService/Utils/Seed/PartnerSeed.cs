using Microsoft.Azure.Cosmos;
using UserService.Contexts;
using UserService.Entities;

namespace UserService.Utils.Seed
{
    public class PartnerSeed
    {
        public static async Task Seed(CosmosDbContext context)
        {
            Guid partner1Id = Guid.Parse("c7f8ccd2-6392-4ae1-8445-33ac6306379c");
            var partner1Response = await context.Partners.ReadItemAsync<Partner>(partner1Id.ToString(), new PartitionKey(partner1Id.ToString()));
            if (partner1Response.Resource == null)
            {
                var partner1 = new Partner()
                {
                    Id = partner1Id.ToString(),
                    Address = "Address",
                    ContactNumber = "Contact Number",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Name = "Partner 1",
                    Password = "password1",
                    Username = "username1",
                    UrlCallback = "https://localhost:8000/callback"
                };

                await context.Partners.CreateItemAsync(partner1, new PartitionKey(partner1.Id));
            }


            Guid partner2Id = Guid.Parse("1251a2e4-b562-42ab-b37d-87a9163ff11a");
            var partner2Response = await context.Partners.ReadItemAsync<Partner>(partner1Id.ToString(), new PartitionKey(partner1Id.ToString()));
            if (partner2Response.Resource == null)
            {
                var partner2 = new Partner()
                {
                    Id = partner2Id.ToString(),
                    Address = "Address",
                    ContactNumber = "Contact Number",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Name = "Partner 2",
                    Password = "password2",
                    Username = "username2",
                    UrlCallback = "https://localhost:8000/callback"
                };

                await context.Partners.CreateItemAsync(partner2, new PartitionKey(partner2.Id));
            }


            Guid partner3Id = Guid.Parse("76db50a3-c955-4f7d-a973-5ddc1c7f3c62");
            var partner3Response = await context.Partners.ReadItemAsync<Partner>(partner1Id.ToString(), new PartitionKey(partner1Id.ToString()));
            if (partner3Response.Resource == null)
            {
                var partner3 = new Partner()
                {
                    Id = partner3Id.ToString(),
                    Address = "Address",
                    ContactNumber = "Contact Number",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Name = "Partner 3",
                    Password = "password3",
                    Username = "username3",
                    UrlCallback = "https://localhost:8000/callback"
                };

                await context.Partners.CreateItemAsync(partner3, new PartitionKey(partner3.Id));
            }




        }
    }
}
