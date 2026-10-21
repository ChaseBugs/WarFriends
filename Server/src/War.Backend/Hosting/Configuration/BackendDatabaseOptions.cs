using MongoDB.Driver;
using War.Persistence;

namespace War.Backend.Hosting.Configuration;

/// <summary>Validates database coordinates without opening a client or making a database write.</summary>
public sealed class BackendDatabaseOptions
{
    private BackendDatabaseOptions(string uri, string databaseName)
    {
        Uri = uri;
        DatabaseName = databaseName;
    }

    public string Uri { get; }

    public string DatabaseName { get; }

    public static BackendDatabaseOptions FromConfiguration(IConfiguration configuration)
    {
        string uri = configuration["Mongo:Uri"] ?? "mongodb://127.0.0.1:27017";
        string databaseName = configuration["Mongo:Database"] ?? "warfriends";
        if (!AccountStore.ValidDatabaseName(databaseName))
        {
            throw new InvalidDataException("Invalid Mongo:Database configuration.");
        }
        try
        {
            _ = new MongoUrl(uri);
            _ = new DatabaseNamespace(databaseName);
        }
        catch (Exception error) when (error is ArgumentException or FormatException or MongoConfigurationException)
        {
            // Driver exception text can contain a credential-bearing URI.
            throw new InvalidDataException("Invalid Mongo:Uri or Mongo:Database configuration.");
        }
        return new BackendDatabaseOptions(uri, databaseName);
    }
}
