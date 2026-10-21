using Newtonsoft.Json.Linq;
using War.Backend.Legacy;
using War.LegacyContract.Tests.Recovered;
using ClientAction = War.LegacyContract.Tests.Recovered.DatabaseAction;
using ClientResult = War.LegacyContract.Tests.Recovered.DatabaseResult;
using ServerAction = War.Backend.Legacy.DatabaseAction;
using ServerResult = War.Backend.Legacy.DatabaseResult;

namespace War.LegacyContract.Tests;

/// <summary>Runs the actual Client callback and proves required/guarded fields by removing each one.</summary>
internal static class BufferContractMatrixTests
{
    internal static int Run(JObject matrix)
    {
        var actions = new HashSet<string>(StringComparer.Ordinal);
        int checks = 0;
        foreach (JObject group in matrix["groups"]!.Children<JObject>())
        {
            foreach (string action in Strings(group, "actions"))
            {
                Require(actions.Add(action), "Duplicate action in contract matrix.");
                Require((int)Enum.Parse<ClientAction>(action) == (int)Enum.Parse<ServerAction>(action),
                    "Client/server action identity disagrees: " + action);
                checks += CheckResult(group, action, "Success");
                foreach (string result in Strings(group, "failures"))
                {
                    checks += CheckResult(group, action, result);
                }

                foreach (string result in Strings(matrix, "genericResults"))
                {
                    Read(Envelope(action, result), true);
                    checks++;
                }
            }
        }

        Require(actions.SetEquals(LegacyBufferProcessor.SupportedActions.Select(action => action.ToString())),
            "Contract matrix disagrees with the server's implemented action allowlist.");
        return checks + 1;
    }

    private static int CheckResult(JObject group, string action, string result)
    {
        bool success = result == "Success";
        Require((int)Enum.Parse<ClientResult>(result) == (int)Enum.Parse<ServerResult>(result),
            "Client/server result identity disagrees: " + result);
        string[] required = Strings(group, success ? "successRequired" : "required");
        string[] guarded = Strings(group, success ? "successGuarded" : "guarded");
        JObject response = Envelope(action, result);
        foreach (string field in required.Concat(guarded))
        {
            response[field] = Value(field);
        }

        if (result == "NoDiscountFound")
        {
            response["SpecialOffers"] = new JObject();
        }

        Read(response, true);
        CheckObservedReads(required.Concat(guarded));
        CheckNotificationOrder(group, success);
        CheckRelogConfirmation(group, success);
        int checks = 1 + CheckDeliveryGate(group, response);
        foreach (string field in required)
        {
            JObject missing = (JObject)response.DeepClone();
            missing.Remove(field);
            RequireRejected(missing, action + "/" + result + " silently accepted missing " + field);
            checks++;
        }

        foreach (string field in guarded)
        {
            JObject missing = (JObject)response.DeepClone();
            missing.Remove(field);
            Read(missing, true);
            checks++;
        }

        if (result == "NoDiscountFound")
        {
            response.Remove("SpecialOffers");
            Read(response, true);
            Require(OracleTrace.Calls.Contains("offers"), "Null-safe offer refresh was skipped.");
            checks++;
        }

        return checks;
    }

    internal static void Read(JObject response, bool isLast)
    {
        OracleTrace.Reset();
        try
        {
            ServerResponseHandler.Read(response, isLast);
            Require(OracleTrace.ParseErrors == 0, "Client value parser used its fallback.");
        }
        catch (Exception error)
        {
            throw new InvalidDataException("Client rejected action/result " + response["ActionId"] + "/" +
                response["Result"] + ".", error);
        }
    }

    private static void RequireRejected(JObject response, string message)
    {
        OracleTrace.Reset();
        try
        {
            ServerResponseHandler.Read(response, true);
        }
        catch (Exception)
        {
            return;
        }

        Require(OracleTrace.ParseErrors > 0, message);
    }

    private static int CheckDeliveryGate(JObject group, JObject response)
    {
        if (response["DeliveryTime"] == null)
        {
            return 0;
        }

        string timer = (string)group["family"]! + "-timer";
        Require(OracleTrace.Calls.Contains(timer), "Last response did not apply delivery countdown.");
        Read(response, false);
        Require(!OracleTrace.Calls.Contains(timer), "A non-last response applied a delivery countdown.");
        return 1;
    }

    private static void CheckObservedReads(IEnumerable<string> fields)
    {
        foreach (string field in fields)
        {
            if (field is "LevelName" or "DecalId" or "ExpiresOn" or "DeliveryTime")
            {
                continue;
            }

            string observed = field == "data" ? "Unit" : field;
            Require(OracleTrace.Calls.Contains(observed), "Callback did not consume " + field);
        }
    }

    private static void CheckNotificationOrder(JObject group, bool success)
    {
        string notification = success ? "scheduled" : "rescheduled";
        Require(OracleTrace.Calls.LastOrDefault() == notification, "Push callback order changed.");
        string family = (string)group["family"]!;
        if (family is "weapon" or "unit")
        {
            Require(OracleTrace.Calls[^2] == family + "-notification", "Delivery notification order changed.");
        }
    }

    private static void CheckRelogConfirmation(JObject group, bool success)
    {
        if (success || (string?)group["family"] is not ("elite" or "parts" or "scraps"))
        {
            return;
        }

        Require(OracleTrace.Confirmation != null && !OracleTrace.Calls.Contains("relog"),
            "Relog must wait for the Client dialog confirmation.");
        OracleTrace.Confirmation!();
        Require(OracleTrace.Calls.Last() == "relog", "Dialog confirmation failed to request relog.");
    }

    private static JObject Envelope(string action, string result) => new()
    {
        ["ActionId"] = (int)Enum.Parse<ClientAction>(action),
        ["Result"] = (int)Enum.Parse<ClientResult>(result)
    };

    private static JToken Value(string field) => field switch
    {
        "LevelName" => "source-item",
        "DecalId" => "source-visual",
        "ExpiresOn" => 0,
        "DeliveryTime" => 30,
        "Gold" or "WarBucks" => 120L,
        "data" => "{\"source-unit\":\"{}\"}",
        _ => "{}"
    };

    private static string[] Strings(JObject value, string key) => value[key]!.Values<string>().ToArray()!;

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
