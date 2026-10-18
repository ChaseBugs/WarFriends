using System.Text.Json.Nodes;

namespace War.Backend;

/// <summary>Identifies a catalog that rebuilds army lanes from current durable player presentation.</summary>
public interface IBattleArmyManifestCatalog : IBattleWeaponManifestCatalog
{
    /// <summary>Rejects source army authority that the catalog cannot refresh before binding.</summary>
    void RequireRefreshableArmyAuthority(JsonObject participant);
}
