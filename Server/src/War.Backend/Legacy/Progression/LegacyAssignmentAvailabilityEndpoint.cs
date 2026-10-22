using System.Text.Json.Nodes;
using War.Persistence;

namespace War.Backend.Legacy.Progression;

/// <summary>Reads assignment availability without issuing unsupported tasks or rewards.</summary>
public static class LegacyAssignmentAvailabilityEndpoint
{
    public static IResult Read(LegacyPlayerDocument player)
    {
        // OnGetNewAssignments requires a JSON string in AssignmentData. Preserve an
        // existing snapshot just as PlayerData does; never reset earned progress here.
        if (!player.Serialized.TryGetValue("AssignmentData", out string? data))
        {
            // This deployment has no assignment issuer yet. Match the recovered
            // LoadEmpty state explicitly, with no tasks, deadlines, claims or rewards.
            data = new JsonObject
            {
                ["assignments"] = new JsonArray(),
                ["tomorrow"] = 0, ["completed"] = 0, ["issued"] = 0,
                ["rewardCounter"] = 0, ["days"] = 0
            }.ToJsonString();
        }
        return LegacyResponse.Json(DatabaseResult.Success, new JsonObject { ["AssignmentData"] = data });
    }
}
