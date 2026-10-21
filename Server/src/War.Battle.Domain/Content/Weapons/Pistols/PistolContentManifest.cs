using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public sealed record PistolContentManifest(int Version,string SceneRevision,string StatsRevision,string BindingsRevision);
