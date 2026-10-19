using System.Text.Json.Nodes;
using War.BattleServer;
using War.Shared;

namespace War.Backend;

/// <summary>Identifies a catalog that rebuilds army lanes from current durable player presentation.</summary>
public interface IBattleArmyManifestCatalog : IBattleWeaponManifestCatalog
{
    /// <summary>Rejects source army authority that the catalog cannot refresh before binding.</summary>
    void RequireRefreshableArmyAuthority(JsonObject participant);

    /// <summary>Computes both sides' combat coefficients before publishing either participant.</summary>
    void BindArmyCombat(JsonArray participants, IReadOnlyList<BattlePlayerPresentation> views);

    /// <summary>Validates and releases an accepted combat projection before current account state replaces it.</summary>
    void PrepareArmyCombatRefresh(JsonObject source, MatchManifest previous);
}
