using War.BattleServer;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<NetworkWorker>();

var host = builder.Build();
host.Run();
