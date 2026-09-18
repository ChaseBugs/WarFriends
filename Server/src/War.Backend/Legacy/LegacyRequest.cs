using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using System.Text.Json.Nodes;

namespace War.Backend.Legacy;

/// <summary>
/// One decoded legacy request: the single-URL form POST the 1.4.0 client sends to
/// <c>index_09_25_2015.php</c>, built by <c>BeanstalkServerManager.GetServerRequest</c>.
/// </summary>
/// <remarks>
/// Envelope fields, in the order the client adds them: <c>SheetConfig</c> (or <c>"0"</c>),
/// the <c>App-Version</c> header, <c>requestId</c>, <c>Version</c>, <c>Os</c> (always
/// <c>"android"</c> in this build), optional <c>DebugEnabled</c>/<c>DevAccess</c>, then — for every
/// action outside <see cref="IsAccountManagement"/> — <c>Token</c>, <c>PlayerId</c> and an optional
/// <c>Cheat</c>. Per-action fields follow.
/// <para>The client substitutes the literal string <c>"null"</c> for an absent token, player id or
/// per-action value. Treat <c>"null"</c> as absent everywhere; see <see cref="Field"/>.</para>
/// </remarks>
public sealed class LegacyRequest
{
    /// <summary>The literal the client sends in place of an empty value.</summary>
    public const string NullLiteral = "null";

    /// <summary>
    /// Actions the client sends without <c>Token</c>/<c>PlayerId</c>, from
    /// <c>BeanstalkServerManager.mAccountManagementActions</c>. These establish a session rather
    /// than consuming one, so they are the only actions that may skip authentication.
    /// </summary>
    private static readonly HashSet<int> AccountManagementActions = [118, 146, 30];

    private readonly IFormCollection form;

    private LegacyRequest(IFormCollection form, DatabaseAction action, string appVersion)
    {
        this.form = form;
        Action = action;
        AppVersion = appVersion;
    }

    public DatabaseAction Action { get; }
    public string AppVersion { get; }
    public string Version => Field("Version") ?? "";
    public string Os => Field("Os") ?? "";
    public string SheetConfig => Field("SheetConfig") ?? "0";
    public string? Token => Field("Token");
    public string? PlayerId => Field("PlayerId");

    /// <summary>True when the client omitted <c>Token</c>/<c>PlayerId</c> by design.</summary>
    public bool IsAccountManagement => AccountManagementActions.Contains((int)Action);

    /// <summary>
    /// A per-action form field, or null when absent or sent as the <c>"null"</c> literal.
    /// </summary>
    public string? Field(string name)
    {
        if (!form.TryGetValue(name, out var values)) return null;
        string value = values.ToString();
        return value.Length == 0 || value == NullLiteral ? null : value;
    }

    /// <summary>A per-action integer field, or <paramref name="fallback"/> when absent/unparsable.</summary>
    public int Int(string name, int fallback = 0) =>
        int.TryParse(Field(name), NumberStyles.Integer, CultureInfo.InvariantCulture, out int parsed) ? parsed : fallback;

    /// <summary>A per-action long field, or <paramref name="fallback"/> when absent/unparsable.</summary>
    public long Long(string name, long fallback = 0) =>
        long.TryParse(Field(name), NumberStyles.Integer, CultureInfo.InvariantCulture, out long parsed) ? parsed : fallback;

    /// <summary>
    /// Decodes the envelope. Returns false when <c>requestId</c> is missing or is not a known
    /// <see cref="DatabaseAction"/>, so an unrecognised id is answered rather than throwing.
    /// </summary>
    public static bool TryParse(HttpRequest request, [NotNullWhen(true)] out LegacyRequest? parsed)
    {
        parsed = null;
        if (!request.HasFormContentType) return false;
        var form = request.Form;
        if (!form.TryGetValue("requestId", out var raw)) return false;
        if (!int.TryParse(raw.ToString(), NumberStyles.Integer, CultureInfo.InvariantCulture, out int id)) return false;
        if (!Enum.IsDefined(typeof(DatabaseAction), id)) return false;
        parsed = new LegacyRequest(form, (DatabaseAction)id, request.Headers["App-Version"].ToString());
        return true;
    }
}

/// <summary>
/// Writes legacy responses in the exact shapes <c>ServerResponseHandler</c> consumes.
/// </summary>
public static class LegacyResponse
{
    /// <summary>
    /// A JSON response body. <c>Result</c> is written as a plain number, not an AttributeValue —
    /// the client reads it with <c>Convert.ToInt32(mResponse["Result"])</c>.
    /// </summary>
    public static IResult Json(DatabaseResult result, JsonObject? body = null)
    {
        var payload = body ?? [];
        payload["Result"] = (int)result;
        return new LegacyJsonResult(payload);
    }

    /// <summary>
    /// A failure response. The client's failure branch triggers on <c>Result &gt; 10</c> only, so
    /// this rejects the two sub-11 non-success codes rather than silently returning a body the
    /// client would route into a success handler that expects fields this response does not carry.
    /// </summary>
    public static IResult Failure(DatabaseResult result, JsonObject? body = null)
    {
        if ((int)result <= 10)
            throw new ArgumentOutOfRangeException(nameof(result), result, "The 1.4.0 client only treats Result > 10 as a failure; codes 3 and 4 reach the success handler.");
        return Json(result, body);
    }

    /// <summary>
    /// The <see cref="DatabaseAction.GetConfigurations"/> response, which bypasses JSON entirely:
    /// <c>GameConfigurationManager.PrepareConfigurations</c> splits the raw body on <c>';'</c> and
    /// requires segment 1 to equal <c>"success"</c>, segment 2 to be the sheet-configuration
    /// version, and segment 3 to be a JSON object of per-sheet versions. Further segments are
    /// individual sheet documents; emitting none leaves the client on its shipped Google2u sheets.
    /// </summary>
    public static IResult Configurations(string sheetConfigurationVersion, string sheetVersionsJson = "{}")
    {
        if (sheetConfigurationVersion.Contains(';')) throw new ArgumentException("A configuration version cannot contain the ';' segment separator.", nameof(sheetConfigurationVersion));
        return new LegacyTextResult($"success;{sheetConfigurationVersion};{sheetVersionsJson}");
    }

    /// <summary>
    /// The <c>check.php</c> connectivity probe. <c>BeanstalkServerManager.GetCheckRequest</c>
    /// requires the body to be exactly <c>"ok"</c>; anything else blocks login behind a
    /// "check your connection" error. This is a reachability probe and nothing more — it grants no
    /// session and must never award anything.
    /// </summary>
    public static IResult Ok() => new LegacyTextResult("ok");

    private sealed record LegacyJsonResult(JsonObject Payload) : IResult
    {
        public async Task ExecuteAsync(HttpContext context)
        {
            context.Response.StatusCode = 200;
            context.Response.ContentType = "application/json";
            context.Response.Headers.CacheControl = "no-store";
            await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes(Payload.ToJsonString()), context.RequestAborted);
        }
    }

    private sealed record LegacyTextResult(string Body) : IResult
    {
        public async Task ExecuteAsync(HttpContext context)
        {
            context.Response.StatusCode = 200;
            context.Response.ContentType = "text/plain";
            context.Response.Headers.CacheControl = "no-store";
            await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes(Body), context.RequestAborted);
        }
    }
}
