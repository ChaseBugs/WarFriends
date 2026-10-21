using System.Text.Json;
using System.Text.Json.Nodes;
using War.BattleServer;

namespace War.Backend.Features.Battle.Settlement;

internal static class BattleSettlementTemplate
{
    internal static byte[] Bind(byte[] templateBytes, BattleRewardPolicy? policy)
    {
        JsonObject template = JsonNode.Parse(templateBytes)?.AsObject()
            ?? throw new InvalidDataException("Missing battle allocation template.");
        if (policy == null || template["PvpBonusMode"]?.GetValue<string>() != MatchManifest.OrdinaryPvpBonusMode)
        {
            template.Remove("SettlementPolicyRevision");
            template.Remove("SettlementPolicyJson");
        }
        else
        {
            template["SettlementPolicyRevision"] = policy.Revision();
            template["SettlementPolicyJson"] = policy.ToJson();
        }
        return JsonSerializer.SerializeToUtf8Bytes(template);
    }
}
