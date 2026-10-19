using System.Collections.Generic;
using System.IO;

namespace War.Client
{
    /// <summary>Binds server map selection to the five recovered 1.4.0 multiplayer scene revisions.</summary>
    public static class InstalledBattleMaps
    {
        // These are the source scene SHA-256 rows in recovered-battle-content.json, not geometry guesses.
        private static readonly Dictionary<string, string> Revisions = new Dictionary<string, string>
        {
            { "Aztec_Multiplayer", "50b3077f1898189cbf40c2232771175b85eec0f03737901373da377faf95291e" },
            { "City_Multiplayer", "acaf878b188dbc17fca6795b5db7e9c7797b91dee0fcb6fb02d5e85d7cc11c4f" },
            { "Desert_Multiplayer", "d2acaeb238fb2dfdcfb0e1bb69a52628798498f7b6992ecf9418a727360368c1" },
            { "Park_Multiplayer", "09b2c084ef5da6707fbebd4261a60baa0f12e24fef31efc4c6d4671b721e70ed" },
            { "Snow_Multiplayer", "67291457da28646c9ce377f3812d1bf0fa5332bfe664f58a4430a823744e6f21" }
        };

        /// <summary>Rejects an unknown or changed scene rather than silently loading the menu's default map.</summary>
        public static void Require(string mapId, string revision)
        {
            War.Shared.BattleMapIdentity.Require(mapId, revision);
            string expected;
            if (!Revisions.TryGetValue(mapId, out expected) || expected != revision)
            {
                throw new InvalidDataException("The assigned battle scene is not installed at the required revision.");
            }
        }

        /// <summary>Resolves the recovered RPC's array-index domain and rejects missing or duplicate scene entries.</summary>
        public static int ResolveIndex(IReadOnlyList<string> sceneNames, string mapId, string revision)
        {
            Require(mapId, revision);
            if (sceneNames == null)
            {
                throw new InvalidDataException("The local battle map list is missing.");
            }

            int selectedIndex = -1;
            for (int i = 0; i < sceneNames.Count; i++)
            {
                if (sceneNames[i] != mapId)
                {
                    continue;
                }
                if (selectedIndex >= 0)
                {
                    throw new InvalidDataException("The assigned battle scene has duplicate local map entries.");
                }
                selectedIndex = i;
            }
            if (selectedIndex < 0)
            {
                throw new InvalidDataException("The assigned battle scene has no local map entry.");
            }
            return selectedIndex;
        }
    }
}
