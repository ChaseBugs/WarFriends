using System.Collections.ObjectModel;
using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed class CoopMapRoutes
{
    public int Stage { get; }
    public string Scene { get; }
    public IReadOnlyList<CoopDefendRoute> Routes { get; }

    internal CoopMapRoutes(int stage, string scene, CoopDefendRoute[] routes)
    {
        Stage = stage;
        Scene = scene;
        Routes = new ReadOnlyCollection<CoopDefendRoute>(routes);
    }

    public CoopDefendRoute Between(int from, int to)
    {
        if (from is < 0 or > 3 || to is < 0 or > 3 || from == to)
            throw new ArgumentOutOfRangeException(nameof(to));
        int index = from * 3 + (to < from ? to : to - 1);
        return Routes[index];
    }
}
