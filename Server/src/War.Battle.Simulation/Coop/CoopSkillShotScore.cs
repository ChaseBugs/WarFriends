using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record CoopSkillShotScore(int Flag, string Name, string DictionaryId, int MissionPoints);
