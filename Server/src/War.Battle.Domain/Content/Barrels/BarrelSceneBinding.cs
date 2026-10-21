using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record BarrelSceneBinding(int ColliderIndex,int GameObjectFileId,int ColliderFileId,
    int BarrelFileId,int DestroyableFileId,float ShotCoefficient,string SourcePath);
