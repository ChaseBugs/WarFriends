namespace War.BattleServer;

/// <summary>Match-owned car spawn and aerial-path reservations; normal soldier points remain reusable.</summary>
public sealed class ArmySpawnReservationLedger
{
    private readonly IReadOnlyDictionary<int,ArmySpawnPoint> sourcePoints;
    private readonly HashSet<int> occupied=[];
    private readonly Dictionary<ulong,int> byEntity=[];
    public ArmySpawnReservationLedger(ArmySpawnPointCatalog catalog,RecoveredBattleMap map)
        =>sourcePoints=catalog.ForMap(map).ToDictionary(p=>p.ComponentFileId);
    public bool Available(ArmySpawnPoint point)
    {
        var source=Source(point);
        return source.ReservationFileId==0 || !occupied.Contains(source.ReservationFileId);
    }
    public bool Owns(ulong entityId,int reservationFileId)
        =>byEntity.TryGetValue(entityId,out int current) && current==reservationFileId &&
           (current==0 || occupied.Contains(current));
    public bool TryReserve(ArmySpawnPoint point,ulong entityId)
    {
        if(entityId==0 || byEntity.ContainsKey(entityId))throw new InvalidDataException("Invalid or reused army entity identity.");
        var source=Source(point);
        int reservation=source.ReservationFileId;
        if(reservation!=0 && !occupied.Add(reservation))return false;
        byEntity.Add(entityId,reservation);
        return true;
    }
    public bool Release(ulong entityId)
    {
        if(!byEntity.Remove(entityId,out int reservation))return false;
        if(reservation!=0 && !occupied.Remove(reservation))
            throw new InvalidDataException("Army route reservation was lost.");
        return true;
    }
    private ArmySpawnPoint Source(ArmySpawnPoint point)
    {
        if(point==null || !sourcePoints.TryGetValue(point.ComponentFileId,out var source) || source!=point)
            throw new InvalidDataException("Army point does not belong to the bound map.");
        return source;
    }
}
