using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace War.BattleServer;

internal sealed record CollisionPlayer(string PlayerId, PlayerCollisionModel Pose);
internal sealed record DynamicShotTarget(ulong EntityId,int PartComponentFileId,int Layer,PlayerHitbox Hitbox,
    string? PassengerRole=null,int? RepairDronePathIndex=null,bool ArmyInfantry=false,bool Decoy=false);
internal sealed record ShotCollision(float Distance, Vector3 Position, string SourcePath, string? PlayerId, float PartWeight, bool Static = false,string? DynamicOwner=null,int? ColliderIndex=null,ulong? DynamicEntityId=null,int? DynamicPartId=null,string? DynamicPassengerRole=null,int? DynamicRepairDronePathIndex=null,bool DynamicArmyInfantry=false,bool DynamicDecoy=false);

// Input poses come exclusively from host animation/pose authority. This class has
// no network adapter and no client-submitted target player or damage parameter.
internal sealed class ShotCollisionWorld
{
    private readonly RecoveredBattleMap? map;
    private readonly CollisionPlayer[] players;
    private readonly Func<string,bool>? dynamicEnabled;
    private readonly Func<int,bool>? colliderEnabled;
    private readonly Func<int,int,int>? runtimeLayer;
    private readonly Func<string,IReadOnlyList<DynamicShotTarget>>? dynamicTargets;
    internal ShotCollisionWorld(RecoveredBattleMap? map, IEnumerable<CollisionPlayer> players,
        Func<string,bool>? dynamicEnabled=null,Func<int,bool>? colliderEnabled=null,
        Func<int,int,int>? runtimeLayer=null,Func<string,IReadOnlyList<DynamicShotTarget>>? dynamicTargets=null)
    {
        this.map = map;this.dynamicEnabled=dynamicEnabled;this.colliderEnabled=colliderEnabled;
        this.runtimeLayer=runtimeLayer;this.dynamicTargets=dynamicTargets;
        this.players = players.Take(3).ToArray();
        if (this.players.Length != 2 || this.players.Any(p => p == null || p.Pose == null || p.Pose.Role != "gameplay" ||
            !Guid.TryParseExact(p.PlayerId, "N", out _) || p.PlayerId != p.PlayerId.ToLowerInvariant()) ||
            this.players[0].PlayerId == this.players[1].PlayerId)
            throw new InvalidDataException("Expected two distinct host-owned gameplay collision poses.");
    }
    internal ShotCollision? Raycast(string shooterId, Vector3 origin, Vector3 direction, float range, uint mapLayerMask = uint.MaxValue)
    {
        if (!players.Any(p => p.PlayerId == shooterId)) throw new InvalidDataException("Unknown shot owner.");
        if (!PlayerHitbox.Finite(origin) || !PlayerHitbox.Finite(direction) || direction.LengthSquared()<1e-12f ||
            !float.IsFinite(range) || range is <= 0 or > 10000) throw new InvalidDataException("Invalid server shot ray.");
        // Static geometry wins a distance tie: never shoot through a surface to
        // an overlapping player. Disabled reference colliders are never promoted.
        direction = Vector3.Normalize(direction);
        var geometry = map?.Raycast(origin, direction, range, mapLayerMask,dynamicEnabled,colliderEnabled,runtimeLayer);
        ShotCollision? nearest = geometry == null ? null : new(geometry.Distance, geometry.Position, geometry.SourcePath, null, 0, geometry.Layer is 13 or 30,geometry.DynamicOwner,geometry.ColliderIndex);
        foreach (var player in players)
        {
            if (player.PlayerId == shooterId) continue;
            var hit = player.Pose.Raycast(origin, direction, range);
            if (hit != null && (nearest == null || hit.Distance < nearest.Distance))
                nearest = new(hit.Distance, hit.Position, hit.PartPath, player.PlayerId, hit.Weight);
        }
        if(dynamicTargets!=null)
            foreach(var target in dynamicTargets(shooterId))
            {
                if(target==null||target.EntityId==0||target.Layer is <0 or >31||target.Hitbox==null||
                   target.RepairDronePathIndex is <0 or >1||
                   (target.PassengerRole==null&&target.RepairDronePathIndex==null&&!target.ArmyInfantry&&!target.Decoy&&target.PartComponentFileId<=0)||
                   (target.PassengerRole!=null&&(target.PartComponentFileId!=0||target.RepairDronePathIndex!=null||
                       target.ArmyInfantry||target.Decoy||target.PassengerRole.Length is <1 or >32||target.PassengerRole.Any(char.IsControl)))||
                   (target.RepairDronePathIndex!=null&&(target.PartComponentFileId!=0||target.PassengerRole!=null||target.ArmyInfantry||target.Decoy))||
                   (target.ArmyInfantry&&(target.PartComponentFileId!=0||target.PassengerRole!=null||target.RepairDronePathIndex!=null||target.Decoy))||
                   (target.Decoy&&(target.PartComponentFileId!=0||target.PassengerRole!=null||target.RepairDronePathIndex!=null||target.ArmyInfantry)))
                    throw new InvalidDataException("Invalid host dynamic shot target.");
                if((mapLayerMask&(1u<<target.Layer))==0)continue;
                var distance=target.Hitbox.Raycast(origin,direction,range);
                if(distance.HasValue&&(nearest==null||distance.Value<nearest.Distance))
                    nearest=new(distance.Value,origin+direction*distance.Value,target.Hitbox.SourcePath,null,
                        target.Hitbox.Weight,DynamicEntityId:target.EntityId,
                        DynamicPartId:target.PartComponentFileId>0?target.PartComponentFileId:null,
                        DynamicPassengerRole:target.PassengerRole,
                        DynamicRepairDronePathIndex:target.RepairDronePathIndex,
                        DynamicArmyInfantry:target.ArmyInfantry,DynamicDecoy:target.Decoy);
            }
        return nearest;
    }
    internal IReadOnlyList<ShotgunCollider> OverlapEnemy(string shooterId,Vector3 origin,float radius)
    {
        if(!PlayerHitbox.Finite(origin) || !float.IsFinite(radius) || radius is <=0 or >100)
            throw new InvalidDataException("Invalid shotgun overlap query.");
        var shooter=players.SingleOrDefault(p=>p.PlayerId==shooterId);
        if(shooter==null)
            throw new InvalidDataException("Unknown shotgun shooter.");
        var enemy=players.Single(p=>p.PlayerId!=shooterId);
        if(shooter.Pose.PoseKind=="serialized-reference-only" || enemy.Pose.PoseKind=="serialized-reference-only")
            throw new InvalidDataException("Shotgun overlap needs current host player poses.");
        return Array.AsReadOnly(enemy.Pose.Parts.Where(p=>p.OverlapsSphere(origin,radius))
            .Select(p=>new ShotgunCollider(Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(p.SourcePath))),
                enemy.PlayerId,p.Center,true)).ToArray());
    }
}
