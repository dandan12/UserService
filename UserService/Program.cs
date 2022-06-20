using UserService.Contexts;
using UserService.Models;
using UserService.Repositories;
using UserService.Repositories.Interface;
using UserService.Services;
using UserService.Services.Interface;
using UserService.Utils.Seed;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;

var cosmosDbSetting = new CosmosDbSetting();
builder.Configuration.Bind("CosmosDbSetting", cosmosDbSetting);
services.AddScoped(x => cosmosDbSetting);

var authSetting = new AuthenticationSetting();
builder.Configuration.Bind("AuthenticationSetting", authSetting);
services.AddScoped(x => authSetting);

var cosmosDbContext = new CosmosDbContext(cosmosDbSetting);
services.AddScoped(x => cosmosDbContext);


services.AddScoped<IPartnerRepository, PartnerRepository>();
services.AddScoped<IUserService, UsersService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//await cosmosDbSetting.ConfigureCosmosDb();
//await PartnerSeed.Seed(cosmosDbContext);


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


