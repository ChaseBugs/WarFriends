using System.Text.Json.Nodes;
using static War.Backend.Legacy.Buffering.LegacyBufferedResults;
using static War.Backend.Legacy.Buffering.LegacyBufferedSlots;

namespace War.Backend.Legacy.Buffering.Inventory;

internal static class LegacyBufferedInventoryMarkers
{
    // The client sets savedWeapons[name].showed locally at WeaponScreen.cs:530; mirror it.
    internal static (DatabaseResult, JsonObject) WeaponWasShown(BufferedRequest request, LegacyBufferedState state)
    {
        if (string.IsNullOrEmpty(request.Data))
        {
            return Fail(request, DatabaseResult.WrongPlayerData);
        }
        Slot(state.Levels.SavedWeapons, request.Data).Showed = true;
        state.LevelsChanged();
        return Ok(request);
    }

    // The client sets savedArmies[name].showed locally at ArmyScreen.cs:398; mirror it.
    internal static (DatabaseResult, JsonObject) ArmyUnitWasShown(BufferedRequest request, LegacyBufferedState state)
    {
        if (string.IsNullOrEmpty(request.Data))
        {
            return Fail(request, DatabaseResult.WrongPlayerData);
        }
        Slot(state.Levels.SavedArmies, request.Data).Showed = true;
        state.LevelsChanged();
        return Ok(request);
    }

    // CamosScreen.WasShown clears notificate only; it does not touch showed. Mirror exactly.
    internal static (DatabaseResult, JsonObject) VisualWasShown(BufferedRequest request, LegacyBufferedState state)
    {
        if (string.IsNullOrEmpty(request.Data))
        {
            return Fail(request, DatabaseResult.WrongPlayerData);
        }
        Slot(state.Decals.Visuals, request.Data).Notificate = false;
        state.DecalsChanged();
        return Ok(request);
    }

}
