using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record PvpBonusGoldRange(int Minimum, int MaximumExclusive);
