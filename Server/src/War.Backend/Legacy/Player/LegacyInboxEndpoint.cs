using System.Text.Json.Nodes;

namespace War.Backend.Legacy.Player;

public static class LegacyInboxEndpoint
{
    public static IResult Read()
    {
        // OnGetAllMessages casts Items to JArray without checking for presence.
        return LegacyResponse.Json(DatabaseResult.Success, new JsonObject { ["Items"] = new JsonArray() });
    }
}
