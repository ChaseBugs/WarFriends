using War.Protocol;
using System.Security.Cryptography;
using System.Text;

namespace War.BattleServer;

/// <summary>Binds reward eligibility to the Backend's frozen allocation, never a Client end request.</summary>
public static class BattleSettlementEligibility
{
    public static void ValidatePolicy(string? revision, string? policyJson)
    {
        if (revision == null && policyJson == null)
        {
            return;
        }

        if (policyJson == null || Encoding.UTF8.GetByteCount(policyJson) is < 2 or > 16_384 ||
            Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(policyJson))) != revision)
        {
            throw new InvalidDataException("Frozen settlement policy bytes do not match their identity.");
        }
    }
    public static void Validate(MatchSnapshot terminal, MatchManifest manifest)
    {
        bool eligible = terminal.Phase == BattlePhase.Ended && manifest.SettlementPolicyRevision != null;
        string revision = eligible ? manifest.SettlementPolicyRevision! : "";
        if (terminal.RewardEligible != eligible || terminal.SettlementPolicyRevision != revision ||
            terminal.ManifestHash != manifest.Digest())
        {
            throw new InvalidDataException("Terminal reward eligibility differs from the frozen allocation.");
        }
    }
}
