using System.Collections.ObjectModel;
using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed class CoopDefendRoute
{
    public int From { get; }
    public int To { get; }
    public IReadOnlyList<Vector3> Corners { get; }

    internal CoopDefendRoute(int from, int to, Vector3[] corners)
    {
        From = from;
        To = to;
        Corners = new ReadOnlyCollection<Vector3>(corners);
    }
}
