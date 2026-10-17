using System;
using War.Protocol;

namespace War.Shared
{
    /// <summary>Maps the seven recovered player bazookas to their original inventory identities.</summary>
    public static class BazookaSourceIdentity
    {
        /// <summary>Resolves the source slot independently of the player's currently equipped weapon.</summary>
        public static bool TryGetInventoryIndex(string sourceId, out int inventoryIndex)
        {
            switch (sourceId)
            {
                case "Google2u.Bazooka_RPG7":
                    inventoryIndex = 3;
                    return true;
                case "Google2u.Bazooka_FGM":
                    inventoryIndex = 37;
                    return true;
                case "Google2u.Bazooka_HMV":
                    inventoryIndex = 38;
                    return true;
                case "Google2u.Bazooka_Panzerfaust":
                    inventoryIndex = 41;
                    return true;
                case "Google2u.Bazooka_M202":
                    inventoryIndex = 42;
                    return true;
                case "Google2u.Bazooka_FGMElite":
                    inventoryIndex = 57;
                    return true;
                case "Google2u.Bazooka_Hater":
                    inventoryIndex = 58;
                    return true;
                default:
                    inventoryIndex = -1;
                    return false;
            }
        }

        /// <summary>Only the recovered M202 volley contains harmless fake missiles.</summary>
        public static bool ValidProjectile(string sourceId, bool isFake)
        {
            int inventoryIndex;
            return TryGetInventoryIndex(sourceId, out inventoryIndex) &&
                (!isFake || sourceId == "Google2u.Bazooka_M202");
        }

        /// <summary>Requires launch identity on RPG events and forbids it on unrelated events.</summary>
        public static bool ValidEvent(MatchEvent item)
        {
            bool isBazooka = item.Reason == "bazooka" || item.Reason == "bazooka-fake";
            if (!isBazooka)
            {
                return item.WeaponSourceId.Length == 0;
            }

            return (item.Kind == MatchEventKind.Shot || item.Kind == MatchEventKind.Impact) &&
                item.ProjectileId != 0 && Guid.TryParseExact(item.ActorId, "N", out _) &&
                item.ActorId == item.ActorId.ToLowerInvariant() &&
                ValidProjectile(item.WeaponSourceId, item.Reason == "bazooka-fake");
        }
    }
}
