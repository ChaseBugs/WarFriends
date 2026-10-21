using System.Text.Json.Nodes;
using War.Persistence.Legacy.Accounts;

namespace War.Backend.Legacy.Accounts;

/// <summary>Owns guest registration/login callback shapes and closed provider compatibility.</summary>
public sealed class LegacyAccountEndpoint(
    LegacyAccountService service, LegacyAccountProjection projection, ILogger<LegacyAccountEndpoint> logger)
{
    public async Task<IResult> CreateAsync(LegacyRequest request, CancellationToken cancellationToken)
    {
        LegacyAccountRegistration registration;
        try
        {
            registration = LegacyAccountParser.Parse(request);
        }
        catch (InvalidDataException)
        {
            return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        }

        if (request.Action == DatabaseAction.CreateGcAccount || registration.GameCenterId != null)
        {
            return LegacyResponse.Failure(DatabaseResult.ServerMaintenance);
        }

        if (request.HasField("StartingGold") || request.HasField("StartingWarbucks"))
        {
            logger.LogInformation("Ignoring client starting-currency assertions during guest registration.");
        }

        LegacyAccountCreated result = await service.CreateAsync(registration, cancellationToken);
        return LegacyResponse.Json(DatabaseResult.Success, new JsonObject
        {
            ["Player"] = projection.Player(result.Player),
            ["AccountType"] = result.Player.AccountType,
            ["Token"] = result.Token,
            ["Password"] = result.Password,
            ["PlayerData"] = projection.PlayerData(result.Player),
            ["Time"] = result.Player.LastAction
        });
    }

    public async Task<IResult> LoginAsync(LegacyRequest request, CancellationToken cancellationToken)
    {
        string? id = request.SingleField("Id");
        string? password = request.SingleField("Password");
        if (id == null || password == null || id.Length > 128 || password.Length > 128)
        {
            return LegacyResponse.Failure(DatabaseResult.LoginFailure);
        }

        LegacySessionIssued? result;
        try
        {
            result = await service.LoginAsync(id, password, cancellationToken);
        }
        catch (InvalidDataException exception)
        {
            logger.LogError(exception, "Refused invalid stored legacy login authority.");
            return LegacyResponse.Failure(DatabaseResult.ServerMaintenance);
        }

        if (result == null)
        {
            return LegacyResponse.Failure(DatabaseResult.LoginFailure);
        }

        // OnLoginToCustomAccount requires these four fields and fetches PlayerData separately.
        return LegacyResponse.Json(DatabaseResult.Success, new JsonObject
        {
            ["Player"] = projection.Player(result.Player),
            ["AccountType"] = result.Player.AccountType,
            ["Token"] = result.Token,
            ["Password"] = password
        });
    }
}
