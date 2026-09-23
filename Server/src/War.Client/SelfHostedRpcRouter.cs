using System;
using System.Globalization;
using System.Threading.Tasks;

namespace War.Client
{
    /// <summary>Bounded replacement for the small set of recovered Photon RPCs
    /// that have a self-hosted equivalent. Unknown method names are rejected;
    /// this is not an arbitrary RPC relay.</summary>
    public sealed class SelfHostedRpcRouter
    {
        private readonly SelfHostedBattleClientAdapter adapter;

        public SelfHostedRpcRouter(SelfHostedBattleClientAdapter adapter)
            => this.adapter = adapter ?? throw new ArgumentNullException(nameof(adapter));

        public bool TryDispatch(string method, params object[] arguments)
        {
            if (string.IsNullOrEmpty(method) || arguments == null) return false;
            switch (method)
            {
                case "LoadingFinishedRPC":
                    if (arguments.Length != 0) return false;
                    _ = adapter.ReadyAsync();
                    return true;
                case "ResyncTimeRPC":
                    return arguments.Length == 1 && TryFiniteDouble(arguments[0]);
                case "StartCameraAnimationFinishedRPC":
                    return arguments.Length == 0;
                default:
                    return false;
            }
        }

        private static bool TryFiniteDouble(object value)
        {
            if (value is double d) return !double.IsNaN(d) && !double.IsInfinity(d);
            if (value is float f) return !float.IsNaN(f) && !float.IsInfinity(f);
            return value is string s && double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out var parsed) &&
                !double.IsNaN(parsed) && !double.IsInfinity(parsed);
        }
    }

    /// <summary>Minimal transport-neutral seam used by the RPC router. Unity's
    /// MonoBehaviour adapter can implement this without exposing Photon types.</summary>
    public interface SelfHostedBattleClientAdapter
    {
        Task ReadyAsync();
    }
}
