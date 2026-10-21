using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record CoopNetworkPoolEntry(
    string Name, string PrefabField, string Guid, int PooledComponentFileId);
