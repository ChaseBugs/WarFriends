using System.Numerics;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private readonly Dictionary<ulong, MortarFacingTween> _mortarFacings = [];

    /// <summary>Reads captured facing authority for construction and cover-change verification.</summary>
    internal MortarFacingTween? MortarFacing(ulong entityKey)
    {
        return _mortarFacings.GetValueOrDefault(entityKey);
    }

    private void BeginMortarFacing(ulong entityKey, Vector3 from)
    {
        var entity = activeArmyEntities[entityKey];
        Player opponent = players.Single(player => player.Definition.PlayerId != entity.OwnerPlayerId);
        // PlayerController changes currentPlayerPoint when GoTo is accepted, before physical arrival.
        // Cover still identifies the physical old cover during a host route; Destination owns the new logical point.
        int cover = opponent.Route == null ? opponent.Cover : opponent.Destination;
        if (map == null || cover < 0 || cover >= map.Covers.Count)
        {
            throw new InvalidDataException("Mortar facing lost the opponent's current source point.");
        }

        Vector3 direction = map.Covers[cover].ShotPosition - new Vector3(entity.X, entity.Y, entity.Z);
        direction.Y = 0f;
        _mortarFacings[entityKey] = new MortarFacingTween(tick, cover, from, direction);
    }

    private void AdvanceMortarFacing()
    {
        foreach (var (entityKey, construction) in _mortarConstruction.OrderBy(row => row.Key))
        {
            MortarFacingTween facing = _mortarFacings.GetValueOrDefault(entityKey) ??
                throw new InvalidDataException("Mortar construction lost its facing authority.");
            var entity = activeArmyEntities[entityKey];
            Player opponent = players.Single(player => player.Definition.PlayerId != entity.OwnerPlayerId);
            int cover = opponent.Route == null ? opponent.Cover : opponent.Destination;
            // MortarUpdate's strict firing branch wins over its cover-change branch on the first eligible tick.
            // Shoot generates a new deadline during windup; EndShooting resets it to maximum.
            MortarShotAttempt? attempt = MortarAttempt(entityKey);
            bool canRetarget = tick < construction.FirstFireEligibleTick ||
                (attempt != null && tick > attempt.PreparedTick && !attempt.CompletedTick.HasValue);
            if (canRetarget && cover != facing.TargetCoverIndex)
            {
                BeginMortarFacing(entityKey, facing.FacingAt(tick));
            }
        }
    }
}
