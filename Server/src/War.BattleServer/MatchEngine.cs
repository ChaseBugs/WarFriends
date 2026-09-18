using Google.Protobuf;
using System.Numerics;
using War.Protocol;

namespace War.BattleServer;

// Single writer: NetworkWorker's tick thread. Does not call Unity, Mongo or HTTP.
public sealed class MatchEngine
{
    private readonly MatchManifest manifest;
    private readonly Player[] players;
    private readonly ulong admissionDeadline;
    private readonly RecoveredBattleMap? map;
    private ulong tick;
    private ulong startTick;
    private ulong endTick;
    private BattlePhase phase = BattlePhase.Waiting;
    private string winner = "";
    private string terminalReason = "";
    private sealed class Player(ParticipantManifest definition)
    {
        public ParticipantManifest Definition { get; } = definition;
        public bool Admitted;
        public bool Ready;
        public ulong LastSeen;
        public int Clip = definition.Weapon.ClipSize;
        public int Reserve = definition.Weapon.ReserveAmmo;
        public ulong ReloadEnd;
        public ulong NextFire;
        public ulong Shots;
        public ulong LastCommand;
        public int Cover = -1;
        public Vector3 Position;
        public Vector3[]? Route;
        public ulong MoveStart;
        public ulong MoveEnd;
        public int Destination;
        public string LastGeometryHit = "";
        public readonly Dictionary<ulong, (byte[] Payload, MatchReply Reply)> Receipts = [];
    }
    public string MatchId => manifest.MatchId;
    public string ManifestHash { get; }
    public bool Terminal => phase is BattlePhase.Ended or BattlePhase.Aborted;
    public MatchEngine(MatchManifest definition, RecoveredBattleMap? map = null)
    {
        manifest = MatchManifest.Validate(definition);
        ManifestHash = manifest.Digest();
        players = manifest.Players.Select(p => new Player(p)).ToArray();
        this.map = map;
        if (map != null)
        {
            if (manifest.MapId != System.IO.Path.GetFileNameWithoutExtension(map.Source) || manifest.MapRevision != map.SourceHash)
                throw new InvalidDataException("Manifest map identity/revision does not bind recovered content.");
            foreach (var p in players)
            {
                var d = p.Definition;
                if (d.StartCover < 0 || d.StartCover >= map.Covers.Count || d.MovementSpeed <= 0 || !map.Covers[d.StartCover].Main || map.Covers[d.StartCover].Fraction != d.Fraction)
                    throw new InvalidDataException("Map participant needs a source-bound start cover, side and trusted movement speed.");
                p.Cover = d.StartCover;
                p.Position = map.Covers[d.StartCover].Position;
            }
            if (players[0].Definition.Fraction == players[1].Definition.Fraction) throw new InvalidDataException("This duel slice requires opposing sides.");
        }
        admissionDeadline = (ulong)manifest.AdmissionSeconds * MatchManifest.TickRate;
    }
    public bool HasPlayer(string id) => players.Any(p => p.Definition.PlayerId == id);
    private Player? Find(string id) => players.FirstOrDefault(p => p.Definition.PlayerId == id);
    public bool Admit(string id)
    {
        var p = Find(id);
        if (p == null || Terminal || phase != BattlePhase.Waiting || tick >= admissionDeadline) return false;
        p.Admitted = true;
        p.LastSeen = tick;
        return true;
    }
    public bool Resume(string id)
    {
        var p = Find(id);
        if (p == null || !p.Admitted || Terminal) return false;
        p.LastSeen = tick;
        return true;
    }
    public void Advance(ulong nextTick)
    {
        if (nextTick < tick || nextTick > 10000000) throw new ArgumentOutOfRangeException(nameof(nextTick));
        tick = nextTick;
        if (Terminal) return;
        if (phase == BattlePhase.Waiting && tick >= admissionDeadline) { End("admission-timeout", "", false); return; }
        if (phase == BattlePhase.Countdown && tick >= startTick) phase = BattlePhase.Running;
        if (phase is not (BattlePhase.Running or BattlePhase.Countdown)) return;
        if (tick >= endTick) { End("duration-limit", "", false); return; }
        var idle = players.Where(p => tick - p.LastSeen >= (ulong)manifest.IdleSeconds * MatchManifest.TickRate).ToArray();
        if (idle.Length > 0)
        {
            // A simultaneous loss of both peers is an abort, never an invented winner.
            End(idle.Length == 2 ? "both-disconnected" : "opponent-disconnected",
                idle.Length == 1 ? players.Single(p => p != idle[0]).Definition.PlayerId : "", idle.Length == 1);
            return;
        }
        foreach (var p in players)
        {
            AdvanceMovement(p);
            if (p.ReloadEnd != 0 && tick >= p.ReloadEnd)
            {
                int transfer = Math.Min(p.Definition.Weapon.ClipSize - p.Clip, p.Reserve);
                p.Clip += transfer;
                p.Reserve -= transfer;
                p.ReloadEnd = 0;
            }
        }
    }
    public MatchReply Command(string playerId, MatchCommand command)
    {
        var p = Find(playerId);
        if (p == null || !p.Admitted) return Reply(command.CommandId, "not-admitted");
        if (command.IntentCase == MatchCommand.IntentOneofCase.Poll)
        {
            if (command.CommandId != 0) return Reply(command.CommandId, "invalid-poll-id");
            p.LastSeen = tick;
            return Reply(0, "state");
        }
        if (command.CommandId == 0 || command.CommandId > 100000 || command.CalculateSize() > 256)
            return Reply(command.CommandId, "invalid-command");
        byte[] payload = command.ToByteArray();
        if (p.Receipts.TryGetValue(command.CommandId, out var receipt))
        {
            if (!payload.AsSpan().SequenceEqual(receipt.Payload)) return Reply(command.CommandId, "command-conflict");
            p.LastSeen = tick;
            return receipt.Reply.Clone();
        }
        if (command.CommandId != p.LastCommand + 1) return Reply(command.CommandId, "command-order");
        p.LastSeen = tick;
        string code = Apply(p, command);
        p.LastCommand = command.CommandId;
        MatchReply reply = Reply(command.CommandId, code);
        p.Receipts.Add(command.CommandId, (payload, reply.Clone()));
        if (p.Receipts.Count > 64) p.Receipts.Remove(command.CommandId - 64);
        return reply;
    }
    private string Apply(Player p, MatchCommand c)
    {
        if (Terminal) return "match-terminal";
        if (c.IntentCase == MatchCommand.IntentOneofCase.Ready)
        {
            if (phase != BattlePhase.Waiting) return "wrong-phase";
            if (c.Ready.ManifestHash != ManifestHash) return "manifest-mismatch";
            p.Ready = true;
            if (players.All(x => x.Ready && x.Admitted))
            {
                phase = BattlePhase.Countdown;
                startTick = tick + 2 * MatchManifest.TickRate; // GameControllerOnline SyncMatchStart +2s.
                endTick = startTick + (ulong)manifest.DurationSeconds * MatchManifest.TickRate;
            }
            return "ready";
        }
        if (c.IntentCase == MatchCommand.IntentOneofCase.Forfeit)
        {
            if (phase == BattlePhase.Waiting) End("cancelled-before-start", "", false);
            else End("forfeit", players.Single(x => x != p).Definition.PlayerId, true);
            return "forfeited";
        }
        if (phase != BattlePhase.Running) return "not-running";
        if (c.IntentCase == MatchCommand.IntentOneofCase.MoveCover)
        {
            if (map == null) return "map-unavailable";
            if (p.Route != null) return "already-moving";
            int target = map.Adjacent(p.Cover, c.MoveCover.Direction, p.Definition.Fraction);
            if (target < 0) return "cover-unavailable";
            if (players.Any(other => other != p && (other.Cover == target || (other.Route != null && other.Destination == target)))) return "cover-occupied";
            var route = map.Path(p.Cover, target);
            float length = 0;
            for (int i = 1; i < route.Length; i++) length += Vector3.Distance(route[i-1], route[i]);
            p.Route = route;
            p.Destination = target;
            p.MoveStart = tick + 1; // Source GoTo defaults to a 0.02-second deferred destination.
            p.MoveEnd = p.MoveStart + Math.Max(1, Ticks(length / p.Definition.MovementSpeed));
            return "moving";
        }
        if (c.IntentCase == MatchCommand.IntentOneofCase.Reload)
        {
            if (p.ReloadEnd != 0 || p.Reserve == 0 || p.Clip == p.Definition.Weapon.ClipSize) return "reload-unavailable";
            Reload(p);
            return "reloading";
        }
        if (c.IntentCase != MatchCommand.IntentOneofCase.Fire) return "unsupported-command";
        // Original Fire(Vector3 to) uses a target POSITION, not a normalized direction.
        if (!Coordinate(c.Fire.TargetX) || !Coordinate(c.Fire.TargetY) || !Coordinate(c.Fire.TargetZ)) return "invalid-target";
        if (p.Route != null) return "moving";
        if (p.ReloadEnd != 0) return "reloading";
        if (tick < p.NextFire) return "cooldown";
        if (p.Clip == 0) return "no-ammo";
        p.Clip--;
        p.Shots++;
        if (map != null)
        {
            Vector3 origin = map.Covers[p.Cover].ShotPosition;
            Vector3 delta = new Vector3(c.Fire.TargetX, c.Fire.TargetY, c.Fire.TargetZ) - origin;
            string hitPath = delta.LengthSquared() < 0.000001f ? "" : map.Raycast(origin, delta, Math.Min(10000, delta.Length()))?.SourcePath ?? "";
            // Fixed-size identity keeps replies inside the MTU even for deeply
            // nested source hierarchy names. Map hash already binds the namespace.
            p.LastGeometryHit = hitPath.Length == 0 ? "" : Convert.ToHexStringLower(System.Security.Cryptography.SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(hitPath)));
        }
        p.NextFire = tick + Ticks(p.Definition.Weapon.CadenceSeconds);
        if (p.Clip == 0 && p.Reserve > 0) Reload(p); // Source Weapon.Fire auto-reload.
        // Deliberately no hit, damage or reward: geometry is not implemented yet.
        return "shot-accepted";
    }
    private static bool Coordinate(float n) => float.IsFinite(n) && Math.Abs(n) <= 10000;
    private void AdvanceMovement(Player p)
    {
        if (p.Route == null) return;
        if (tick <= p.MoveStart) return;
        if (tick >= p.MoveEnd)
        {
            p.Cover = p.Destination;
            p.Position = map!.Covers[p.Cover].Position;
            p.Route = null;
            return;
        }
        float traveled = (float)(tick - p.MoveStart) / MatchManifest.TickRate * p.Definition.MovementSpeed;
        for (int i = 1; i < p.Route.Length; i++)
        {
            float segment = Vector3.Distance(p.Route[i-1], p.Route[i]);
            if (traveled <= segment && segment > 0) { p.Position = Vector3.Lerp(p.Route[i-1], p.Route[i], traveled/segment); return; }
            traveled -= segment;
        }
        p.Position = p.Route[^1];
    }
    private static ulong Ticks(double seconds) => checked((ulong)Math.Ceiling(seconds * MatchManifest.TickRate));
    private void Reload(Player p) => p.ReloadEnd = tick + Ticks(p.Definition.Weapon.ReloadSeconds);
    private void End(string reason, string winnerId, bool completed)
    {
        phase = completed ? BattlePhase.Ended : BattlePhase.Aborted;
        terminalReason = reason;
        winner = winnerId;
        endTick = tick;
    }
    public MatchReply Reply(ulong id, string code) => new() { CommandId = id, Code = code, Snapshot = Snapshot() };
    public MatchSnapshot Snapshot()
    {
        var snapshot = new MatchSnapshot
        {
            MatchId = MatchId, ManifestHash = ManifestHash, Phase = phase,
            ServerTick = tick, StartTick = startTick, EndTick = endTick,
            WinnerPlayerId = winner, TerminalReason = terminalReason, RewardEligible = false
        };
        snapshot.Players.AddRange(players.Select(p => new BattlePlayerState
        {
            PlayerId = p.Definition.PlayerId, Admitted = p.Admitted, Ready = p.Ready,
            ClipAmmo = p.Clip, ReserveAmmo = p.Reserve, ReloadEndTick = p.ReloadEnd,
            NextFireTick = p.NextFire, ShotsFired = p.Shots, LastCommandId = p.LastCommand,
            CoverIndex = p.Cover, PositionX = p.Position.X, PositionY = p.Position.Y, PositionZ = p.Position.Z,
            Moving = p.Route != null, MoveEndTick = p.MoveEnd, LastGeometryHit = p.LastGeometryHit
        }));
        return snapshot;
    }
}
