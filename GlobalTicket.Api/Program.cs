using GlobalTicket.Api;

var builder = WebApplication.CreateBuilder(args);
var app = builder
    .ConfigureServices()
    .ConfigurePipeline();
await app.RestDatabaseAsync();
app.Run();