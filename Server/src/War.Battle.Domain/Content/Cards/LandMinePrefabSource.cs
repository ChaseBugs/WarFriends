using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record LandMinePrefabSource(string Source,string Sha256,int RootTransformFileId,
    int AmmoComponentFileId,int TriggerComponentFileId,Vector3 TriggerCenter,Vector3 TriggerSize,
    int MeshComponentFileId,int MeshTransformFileId,Vector3 MeshLocalPosition,string MeshAsset);
