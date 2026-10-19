using System.IO;
using System.Text.RegularExpressions;

namespace War.Shared
{
    /// <summary>Validates the scene identity carried by a trusted battle assignment.</summary>
    public static class BattleMapIdentity
    {
        /// <summary>Requires one bounded scene name and its lowercase SHA-256 revision.</summary>
        public static void Require(string mapId, string revision)
        {
            if (mapId == null || revision == null ||
                !Regex.IsMatch(mapId, @"\A[A-Za-z0-9_-]{1,64}\z") ||
                !Regex.IsMatch(revision, @"\A[0-9a-f]{64}\z"))
            {
                throw new InvalidDataException("Invalid battle map identity or revision.");
            }
        }

        /// <summary>Allows transport-only callers to omit both fields; partial metadata is never valid.</summary>
        public static void ValidateOptional(string mapId, string revision)
        {
            if (mapId == string.Empty && revision == string.Empty)
            {
                return;
            }
            Require(mapId, revision);
        }
    }
}
