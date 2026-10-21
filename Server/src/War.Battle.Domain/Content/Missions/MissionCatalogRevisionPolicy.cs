using System.Security.Cryptography;

namespace War.BattleServer;

internal static class MissionCatalogRevisionPolicy
{
    private const string RestoredSceneRevision =
        "5b159bba5105203cd2a771385a110e63820a840d232e6a027b52b577604495ff";
    private const string ReviewedRestoredCatalogRevision =
        "30ad1a305b0c7fca26c83afcc4d7b2fa8ca845d25389c527bf2344dfa54cf79b";

    internal static void Validate(string sceneRevision, byte[] bytes)
    {
        if (sceneRevision == MissionCatalog.SourceRevision)
        {
            return;
        }

        // The restored LevelManager pointers do not change any of the 75 extracted mission rules.
        if (sceneRevision != RestoredSceneRevision ||
            Convert.ToHexStringLower(SHA256.HashData(bytes)) != ReviewedRestoredCatalogRevision)
        {
            throw new InvalidDataException("Mission catalog is from an unreviewed source snapshot.");
        }
    }
}
