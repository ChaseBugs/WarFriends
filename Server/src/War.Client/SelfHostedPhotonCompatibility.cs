using System;

namespace War.Client
{
    /// <summary>Small compatibility surface for controllers that formerly called
    /// Photon connection helpers. It contains no Photon types or network calls.
    /// Region probing is intentionally unavailable because the self-hosted battle
    /// host is selected by the allocator, not by a cloud region ping.</summary>
    public sealed class SelfHostedPhotonCompatibility
    {
        private readonly SelfHostedRoomLifecycle room;

        public SelfHostedPhotonCompatibility(SelfHostedRoomLifecycle room)
            => this.room = room ?? throw new ArgumentNullException(nameof(room));

        public bool IsConnected
        {
            get
            {
                return room.Phase == SelfHostedRoomPhase.Connecting ||
                    room.Phase == SelfHostedRoomPhase.Loading ||
                    room.Phase == SelfHostedRoomPhase.Ready ||
                    room.Phase == SelfHostedRoomPhase.Running;
            }
        }

        public bool IsMasterClient => IsConnected;

        public bool IsCloudRegionAvailable => false;

        public void Disconnect() => room.Close();

        public static bool TryGetRegionPing(string region, out int milliseconds)
        {
            milliseconds = 0;
            return false;
        }
    }
}
