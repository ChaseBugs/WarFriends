using System.Collections.ObjectModel;
using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed class CoopBossMapRoutes
{
    public int Stage { get; }
    public string Scene { get; }
    public IReadOnlyList<CoopDefendRoute> Routes { get; }

    internal CoopBossMapRoutes(int stage, string scene, CoopDefendRoute[] routes)
    {
        Stage = stage;
        Scene = scene;
        Routes = new ReadOnlyCollection<CoopDefendRoute>(routes);
    }

    public CoopDefendRoute Between(int from, int to)
    {
        if (from is < 0 or > 7 || to is < 0 or > 7 || from == to ||
            from / 4 != to / 4)
            throw new ArgumentOutOfRangeException(nameof(to));

        int localFrom = from % 4;
        int localTo = to % 4;
        int groupOffset = from < 4 ? 0 : 12;
        int routeIndex = groupOffset + localFrom * 3 +
            (localTo < localFrom ? localTo : localTo - 1);
        return Routes[routeIndex];
    }
}
