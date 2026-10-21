using System.Text.Json.Nodes;
using static War.Backend.Legacy.Buffering.LegacyBufferedResults;

namespace War.Backend.Legacy.Buffering;

internal static class LegacyBufferedUnitResults
{
    internal static (DatabaseResult, JsonObject) UnitRollback(
        BufferedRequest request, LegacyBufferedState state, string name, DatabaseResult code)
    {
        var rollback = Result(request.Action, code);
        rollback["LevelName"] = name;
        rollback["Unit"] = PlayerState.Write(state.Levels.SavedArmies.GetValueOrDefault(name) ?? new SavedArmySlots());
        rollback["unitDelivery"] = PlayerState.Write(state.Levels.UnitDelivery);
        rollback["WarBucks"] = state.CurrentWarBucks;
        rollback["Gold"] = state.CurrentGold;
        return (code, rollback);
    }
}
