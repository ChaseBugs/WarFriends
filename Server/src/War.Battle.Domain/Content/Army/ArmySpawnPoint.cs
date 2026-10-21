using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record ArmySpawnPoint(string Collection,int Order,int ComponentFileId,
    int GameObjectFileId,int TransformFileId,string ComponentType,int Fraction,
    int JoinWaypointFileId,int ReservationFileId,Vector3 Position,ArmyVehicleRoute? VehicleRoute);
