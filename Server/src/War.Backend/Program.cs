using War.Backend.Hosting;
using War.Backend.Hosting.Configuration;
using War.Backend.Transport.Http;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
BackendDeploymentOptions deployment;
try
{
    deployment = BackendDeploymentOptions.FromConfiguration(builder.Configuration);
}
catch (InvalidDataException error)
{
    Console.Error.WriteLine("Backend startup configuration rejected: " + error.Message);
    Environment.ExitCode = 1;
    return;
}

builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.MaxRequestBodySize = BackendHttpPolicy.MaximumRequestBodyBytes;
});
builder.Services.AddBackendServices(deployment);
WebApplication app = builder.Build();
await app.InitializeBackendAsync();
app.UseBackendPipeline();
app.MapBackendEndpoints();
app.Run();
