using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace War.BattleServer;

/// <summary>Validated Unity CalculatePath observations; exact complete spawn-to-Rusher pairs can seed host navigation.</summary>
public sealed record ArmyNavMeshPathFixture(int SpawnFileId,int RusherFileId,
    Vector3 Start,Vector3 End,Vector3 SampledStart,Vector3 SampledEnd,
    bool Complete,IReadOnlyList<Vector3> Corners);
