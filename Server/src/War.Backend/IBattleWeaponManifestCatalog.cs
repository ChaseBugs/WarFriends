using System.Text.Json.Nodes;
using War.Shared;

namespace War.Backend;

// The allocator selects one source-validated combat package per reviewed template.
public interface IBattleWeaponManifestCatalog
{
    void ValidateTemplate(JsonObject template);
    void Bind(JsonObject participant,BattlePlayerPresentation view);
}
