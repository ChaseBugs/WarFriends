using System;
using System.Collections.Generic;
using War.Protocol;

namespace War.Client
{
    internal static class BattlePvpBonusBoxPolicy
    {
        internal static void Validate(MatchSnapshot snapshot)
        {
            if (snapshot.PvpBonusBoxes.Count > 256)
                throw new InvalidOperationException("Too many bonus boxes in a battle snapshot.");

            var owners = new HashSet<string>(StringComparer.Ordinal);
            foreach (BattlePlayerState player in snapshot.Players)
                owners.Add(player.PlayerId);

            string previousBoxId = null;
            foreach (BattlePvpBonusBoxState box in snapshot.PvpBonusBoxes)
            {
                if (!Guid.TryParseExact(box.BoxId, "N", out _) ||
                    box.BoxId != box.BoxId.ToLowerInvariant() ||
                    (previousBoxId != null &&
                     StringComparer.Ordinal.Compare(previousBoxId, box.BoxId) >= 0) ||
                    !owners.Contains(box.OwnerPlayerId) ||
                    box.PrefabIndex < 0 || box.PrefabIndex > 8 ||
                    box.Phase < 0 || box.Phase > 1 ||
                    !Finite(box.X) || !Finite(box.Y) || !Finite(box.Z))
                    throw new InvalidOperationException("Invalid bonus box in a battle snapshot.");
                previousBoxId = box.BoxId;
            }
        }

        private static bool Finite(float coordinate)
        {
            return !float.IsNaN(coordinate) && !float.IsInfinity(coordinate) &&
                Math.Abs(coordinate) <= 10000f;
        }
    }
}
