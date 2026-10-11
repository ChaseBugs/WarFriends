using System;
using System.Collections.Generic;

namespace War.Shared
{
    /// <summary>
    /// Source Card.id to spawned Unit.id pairs recovered from MainScene.
    /// Shared by the Worker and portable SDK so a card unit cannot be read as
    /// an ordinary army deployment or relabeled as another unit.
    /// </summary>
    public static class CardUnitSourceIdentity
    {
        private static readonly IReadOnlyDictionary<string, string> Units =
            new Dictionary<string, string>(StringComparer.Ordinal)
            {
                ["BIGROCKET"] = "ID_UNIT-ROCKETSOLDIER",
                ["ELITEMINIGUN"] = "ID_UNIT-MINIGUNNER",
                ["ELITEPARA"] = "ID_UNIT-PARATROOPER",
                ["ELITESNIPER"] = "ID_UNIT-SNIPER",
                ["ELITESWAT"] = "ID_UNIT-SWAT",
                ["GREATGRENADIER"] = "ID_UNIT-GRENADIER",
                ["HEAVYDRONE"] = "ID_UNIT-DRONE"
            };

        public static bool Matches(string sourceCardId, string unitId)
        {
            return sourceCardId != null && unitId != null &&
                Units.TryGetValue(sourceCardId, out string expectedUnitId) &&
                expectedUnitId == unitId;
        }
    }
}
