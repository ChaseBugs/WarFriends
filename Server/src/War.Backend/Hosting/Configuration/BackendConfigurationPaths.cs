namespace War.Backend.Hosting.Configuration;

internal static class BackendConfigurationPaths
{
    internal static string? ReadOptionalFile(IConfiguration configuration, string setting)
    {
        string? value = configuration[setting];
        if (value == null)
        {
            return null;
        }
        if (string.IsNullOrWhiteSpace(value) || value != value.Trim() ||
            value.Any(char.IsControl) || !File.Exists(value))
        {
            throw new InvalidDataException(setting + " must identify an existing file.");
        }
        return Path.GetFullPath(value);
    }

    internal static string Require(string? value, string setting)
    {
        return value ?? throw new InvalidDataException("Set " + setting + " for this deployment mode.");
    }
}
