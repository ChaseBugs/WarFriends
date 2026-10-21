using Microsoft.AspNetCore.Builder;
using War.BattleServer;
using War.BattleServer.Hosting;
using War.BattleServer.Transport.Control;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
BattleHostStartupOptions startup;
try
{
    startup = BattleHostStartupOptions.FromConfiguration(builder.Configuration);
}
catch (InvalidDataException error)
{
    Console.Error.WriteLine("Worker startup configuration rejected: " + error.Message);
    Environment.ExitCode = 1;
    return;
}

builder.ConfigureBattleHost(startup);
WebApplication app = builder.Build();
app.MapBattleControlEndpoints();
await app.RunAsync();
