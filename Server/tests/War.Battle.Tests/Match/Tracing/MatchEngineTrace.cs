using System.Buffers.Binary;
using System.Security.Cryptography;
using Google.Protobuf;
using War.BattleServer;
using War.Protocol;

namespace War.Battle.Tests.Match.Tracing;

internal sealed class MatchEngineTrace : IDisposable
{
    private readonly IncrementalHash _hash = IncrementalHash.CreateHash(HashAlgorithmName.SHA256);
    private readonly string _scenario;
    private readonly string _first;
    private readonly string _second;
    private int _observations;

    internal MatchEngineTrace(string scenario, MatchManifest manifest, RecoveredBattleMap? map = null,
        BattleCombatContent? content = null)
    {
        _scenario = scenario;
        _first = manifest.Players[0].PlayerId;
        _second = manifest.Players[1].PlayerId;
        Engine = new MatchEngine(manifest, map, content, armyChoice: _ => 0, combatRandom: () => 0.5f,
            bonusAreaChoice: _ => 0, bonusPositionDraw: () => new System.Numerics.Vector3(0.5f));
        Observe("allocated", true);
    }

    internal MatchEngine Engine { get; }

    internal MatchEngineTrace(string scenario, MatchEngine engine)
    {
        _scenario = scenario;
        Engine = engine;
        MatchSnapshot snapshot = engine.Snapshot();
        _first = snapshot.Players[0].PlayerId;
        _second = snapshot.Players[1].PlayerId;
        Observe("attached-source-host", true);
    }

    internal void AdmitBoth()
    {
        Observe("admit-first", Engine.Admit(_first));
        Observe("admit-second", Engine.Admit(_second));
    }

    internal void Ready(string playerId)
    {
        Command(playerId, new MatchCommand { CommandId = 1, Ready = new() { ManifestHash = Engine.ManifestHash } });
    }

    internal void Advance(ulong hostTick)
    {
        Engine.Advance(hostTick, hostTick / (double)MatchManifest.TickRate);
        Observe("advance", true);
    }

    internal void Advance(ulong hostTick, double realTimeSeconds)
    {
        Engine.Advance(hostTick, realTimeSeconds);
        Observe("source-frame", true);
    }

    internal void ObservePayload(string action, byte[] payload)
    {
        Append(payload);
        Observe(action, true);
    }

    internal void Poll(string playerId)
    {
        Command(playerId, new MatchCommand { Poll = new() });
    }

    internal MatchReply Command(string playerId, MatchCommand command)
    {
        MatchReply reply = Engine.Command(playerId, command);
        Append(reply.ToByteArray());
        Observe("command", true);
        return reply;
    }

    internal void Observe(string action, bool result)
    {
        Append(System.Text.Encoding.UTF8.GetBytes(action));
        Append([result ? (byte)1 : (byte)0]);
        Append(Engine.Snapshot().ToByteArray());
        if (Engine.Terminal)
        {
            Append(Engine.TerminalEvidenceSnapshot().ToByteArray());
            Append(Engine.EventBatch(_first, 0).ToByteArray());
        }
        byte[] realTime = new byte[sizeof(long)];
        BinaryPrimitives.WriteInt64LittleEndian(realTime,
            BitConverter.DoubleToInt64Bits(Engine.ObservedRealTimeSeconds));
        Append(realTime);
        byte[] cooldown = new byte[sizeof(int)];
        BinaryPrimitives.WriteInt32LittleEndian(cooldown,
            BitConverter.SingleToInt32Bits(Engine.ObservedCooldownSeconds));
        Append(cooldown);
        _observations++;
    }

    internal MatchEngineTraceResult Finish()
    {
        MatchSnapshot snapshot = Engine.Snapshot();
        return new(_scenario, _observations, Convert.ToHexStringLower(_hash.GetHashAndReset()),
            snapshot.Phase.ToString(), snapshot.ServerTick, snapshot.TerminalReason);
    }

    private void Append(byte[] payload)
    {
        Span<byte> length = stackalloc byte[sizeof(int)];
        BinaryPrimitives.WriteInt32LittleEndian(length, payload.Length);
        _hash.AppendData(length);
        _hash.AppendData(payload);
    }

    public void Dispose()
    {
        _hash.Dispose();
    }
}
