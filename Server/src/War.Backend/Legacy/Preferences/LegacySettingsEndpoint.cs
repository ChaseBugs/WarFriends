using System.Text.Json;
using War.Persistence;
using War.Persistence.Legacy.Preferences;

namespace War.Backend.Legacy.Preferences;

/// <summary>Owns complete Settings requests and acknowledgements without granting gameplay authority.</summary>
public sealed class LegacySettingsEndpoint(
    LegacyPlayerStore store, ILogger<LegacySettingsEndpoint> logger, TimeProvider? clock = null)
{
    private readonly TimeProvider _clock = clock ?? TimeProvider.System;

    /// <summary>Validates one complete source request before session/revision-bound publication.</summary>
    public async Task<IResult> UpdateAsync(
        LegacyRequest request, LegacyPlayerDocument authenticated, CancellationToken cancellationToken)
    {
        string? json = request.SingleField("Settings");
        if (json == null)
        {
            return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        }

        LegacySettingsSnapshot replacement;
        try
        {
            replacement = LegacySettingsSnapshot.Parse(json);
        }
        catch (JsonException)
        {
            return LegacyResponse.Failure(DatabaseResult.JsonFailure);
        }

        try
        {
            LegacyPlayerDocument? committed = await store.ApplySettingsAsync(
                authenticated, replacement, _clock.GetUtcNow(), cancellationToken);
            // OnSendSettings reads no response fields; only successful acknowledgement clears the Client dirty flag.
            return committed == null
                ? LegacyResponse.Failure(DatabaseResult.InvalidToken)
                : LegacyResponse.Json(DatabaseResult.Success);
        }
        catch (InvalidDataException exception)
        {
            logger.LogError(exception, "Refused invalid durable Settings authority.");
            return LegacyResponse.Failure(DatabaseResult.ServerMaintenance);
        }
    }
}
