using System.Text.Json.Nodes;

namespace War.Backend.Legacy.Buffering;

internal static class LegacyBufferedResults
{
    internal static (DatabaseResult, JsonObject) Ok(BufferedRequest request) =>
        (DatabaseResult.Success, Result(request.Action, DatabaseResult.Success));

    internal static (DatabaseResult, JsonObject) Fail(BufferedRequest request, DatabaseResult code) =>
        (code, Result(request.Action, code));

    internal static JsonObject Result(DatabaseAction action, DatabaseResult result) =>
        new() { ["ActionId"] = (int)action, ["Result"] = (int)result };
}
