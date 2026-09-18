using System.Globalization;
using System.Text.Json.Nodes;

namespace War.Backend.Legacy;

/// <summary>
/// Builds the DynamoDB AttributeValue JSON shape the 1.4.0 client's parsers require.
/// </summary>
/// <remarks>
/// <para>Evidence, from the recovered client:</para>
/// <list type="bullet">
/// <item><c>StringParser.ParseString(key, databaseType, dict)</c> evaluates
/// <c>dict[key][databaseType].ToObject&lt;string&gt;()</c>; <c>ParseInt</c>/<c>ParseLong</c> do the
/// same with <c>"N"</c>. Every scalar inside <c>Player</c>/<c>PlayerData</c> is therefore wrapped.</item>
/// <item><c>DatabasePlayer.CreateFromDatabase</c> walks <c>item["DepositedCards"]["M"]</c> as
/// <c>JProperty</c>s, so maps use <see cref="Map"/>.</item>
/// <item><c>DatabaseSerializedObjectGeneric&lt;T&gt;.Load</c> reads
/// <c>(string)dict[typeof(T).Name]["S"]</c> and JSON-deserializes it, so subsystem blobs are a
/// JSON document *escaped inside* an <c>S</c> string — see <see cref="Json"/>.</item>
/// </list>
/// <para><c>N</c> is emitted as a JSON string, which is DynamoDB's real wire shape and what the
/// retired PHP backend relayed. Newtonsoft's <c>ToObject&lt;int&gt;()</c> converts it, so both
/// forms parse; the string form is kept because it is what the client was shipped against.</para>
/// <para>Top-level response keys are NOT wrapped. <c>ServerResponseHandler</c> reads them with the
/// single-argument overloads (<c>Convert.ToInt32</c>/<c>ToString</c>) straight off the
/// <c>Dictionary&lt;string, object&gt;</c>. Wrapping <c>Result</c> or <c>Time</c> breaks the client.</para>
/// </remarks>
public static class Dynamo
{
    /// <summary>A DynamoDB string attribute: <c>{"S": value}</c>.</summary>
    public static JsonObject S(string value) => new() { ["S"] = value };

    /// <summary>A DynamoDB number attribute: <c>{"N": "value"}</c>.</summary>
    public static JsonObject N(long value) => new() { ["N"] = value.ToString(CultureInfo.InvariantCulture) };

    /// <summary>A DynamoDB number attribute carrying a non-integral value.</summary>
    public static JsonObject N(double value) => new() { ["N"] = value.ToString("R", CultureInfo.InvariantCulture) };

    /// <summary>A DynamoDB map attribute: <c>{"M": {...}}</c>.</summary>
    public static JsonObject Map(JsonObject entries) => new() { ["M"] = entries };

    /// <summary>A DynamoDB list attribute: <c>{"L": [...]}</c>.</summary>
    public static JsonObject List(JsonArray entries) => new() { ["L"] = entries };

    /// <summary>
    /// A subsystem blob: a JSON document escaped inside an <c>S</c> string, which is how every
    /// <c>DatabaseSerializedObject</c> and the <c>InventoryData</c>/<c>PlayerVisuals</c>/<c>Regions</c>
    /// fields of <c>DatabasePlayer</c> are transported.
    /// </summary>
    public static JsonObject Json(string rawJsonDocument) => S(rawJsonDocument);

    /// <summary>
    /// Adds <paramref name="value"/> under <paramref name="key"/> only when it is present.
    /// </summary>
    /// <remarks>
    /// Every field in <c>DatabasePlayer.CreateFromDatabase</c> and <c>LoadPlayerData</c> is guarded
    /// by a <c>dict["Key"] != null</c> test, and <c>DatabaseSerializedObjectGeneric.Load</c> falls
    /// back to <c>LoadEmpty()</c> (an <c>Activator.CreateInstance</c> default) for a missing key.
    /// Omitting a key is therefore the correct way to express "no stored value" — it is not an
    /// error path, and it is how a brand-new account legitimately reports empty subsystems.
    /// Emitting a null or an empty string instead would take the client down its JSON-failure
    /// branch, which reports an error back to the server.
    /// </remarks>
    public static void SetIfPresent(this JsonObject target, string key, JsonNode? value)
    {
        if (value != null) target[key] = value;
    }
}
