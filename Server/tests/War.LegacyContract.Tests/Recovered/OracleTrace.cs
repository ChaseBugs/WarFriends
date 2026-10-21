using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace War.LegacyContract.Tests.Recovered;

internal static class OracleTrace
{
    internal static List<string> Calls { get; } = [];
    internal static Dictionary<string, JObject> Blobs { get; } = [];
    internal static Dictionary<string, JObject> Items { get; } = [];
    internal static long? Gold { get; set; }
    internal static long? WarBucks { get; set; }
    internal static int? WeaponDeliverySeconds { get; set; }
    internal static int? UnitDeliverySeconds { get; set; }

    internal static int ParseErrors { get; set; }
    internal static Action? Confirmation { get; set; }

    internal static void Reset()
    {
        Calls.Clear();
        Blobs.Clear();
        Items.Clear();
        Gold = null;
        WarBucks = null;
        WeaponDeliverySeconds = null;
        UnitDeliverySeconds = null;
        ParseErrors = 0;
        Confirmation = null;
        CamosManager.instance.data.visuals.Clear();
        CamosManager.instance.data.visuals["source-visual"] = new CamosManager.VisualState();
        CamosManager.instance.data.visuals["CAMOS_DEFAULT"] = new CamosManager.VisualState();
        foreach (string suffix in new[] { "wb", "gold", "locked", "vip", "noshop", "free" })
        {
            CamosManager.instance.data.visuals["fixture-visual-" + suffix] = new CamosManager.VisualState();
        }
    }

    internal static JObject Decode(string? json, string field)
    {
        JObject value = JsonConvert.DeserializeObject<JObject>(json!);
        if (value == null)
        {
            throw new InvalidDataException("Missing decoded " + field);
        }
        Calls.Add(field);
        Blobs[field] = value;
        return value;
    }
}
