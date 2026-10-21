namespace War.Backend.Legacy.Battle;

public static class LegacyOfflinePhotonEndpoint
{
    public static IResult Acknowledge()
    {
        // OnUpdateRegionPings is empty and OnPhotonIsFull only logs. The deployment is offline:
        // never store Regions/Connection, contact Photon, or infer battle admission from this payload.
        return LegacyResponse.Json(DatabaseResult.Success);
    }
}
