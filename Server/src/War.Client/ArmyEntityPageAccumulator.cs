using System;
using System.Collections.Generic;
using War.Protocol;

namespace War.Client
{
    /// <summary>
    /// Collects one paged army roster. The Worker may advance positions between
    /// pages, so each row retains its own PositionTick; membership and ordering
    /// must still describe one roster revision and active count.
    /// </summary>
    internal sealed class ArmyEntityPageAccumulator
    {
        private readonly List<BattleArmyEntityState> entities = new List<BattleArmyEntityState>();
        private ulong revision;
        private uint activeCount;
        private ulong lastServerTick;

        internal ulong Cursor { get; private set; }
        internal ulong Revision => revision;
        internal bool Complete { get; private set; }

        internal void Add(MatchArmyEntityBatch page)
        {
            if (page == null || page.Code != "entities" || Complete)
                throw new InvalidOperationException("Expected an unfinished army entity page.");
            if (page.ActiveCount > 10000 || page.Entities.Count > 4 ||
                page.HasMore && page.Entities.Count != 4)
                throw new InvalidOperationException("Army entity page exceeds its bounds.");

            if (entities.Count == 0 && Cursor == 0)
            {
                revision = page.Revision;
                activeCount = page.ActiveCount;
            }
            else if (page.Revision != revision || page.ActiveCount != activeCount ||
                     page.ServerTick < lastServerTick)
            {
                throw new InvalidOperationException("Army entity pages disagree on roster authority.");
            }

            ulong priorKey = Cursor;
            foreach (var entity in page.Entities)
            {
                if (entity.EntityKey <= priorKey)
                    throw new InvalidOperationException("Army entity pages are not ordered.");
                entities.Add(entity.Clone());
                priorKey = entity.EntityKey;
            }

            if (entities.Count > activeCount || page.HasMore && entities.Count == activeCount)
                throw new InvalidOperationException("Army entity page count contradicts the roster.");
            if (!page.HasMore && entities.Count != activeCount)
                throw new InvalidOperationException("Army entity roster is incomplete.");

            Cursor = priorKey;
            lastServerTick = page.ServerTick;
            Complete = !page.HasMore;
        }

        internal IReadOnlyList<BattleArmyEntityState> Snapshot()
        {
            if (!Complete)
                throw new InvalidOperationException("Army entity roster is incomplete.");
            return entities.AsReadOnly();
        }
    }
}
