using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

using War.BattleServer;

/// <summary>Checks the recovered four-slot source pool and rejects stale actor ownership at its authority boundary.</summary>
internal static class MortarWeaponPoolTests
{
    private const string ReferenceDigest = "eb2726f6a612d44b8ca6272bb1c686cdb70e474113b4019979c1856ee5998eb6";

    internal static int Run(string directory)
    {
        byte[] bytes = File.ReadAllBytes(Path.Combine(directory, "recovered-mortar-weapon-pool.json"));
        int checks = Require(Convert.ToHexStringLower(SHA256.HashData(bytes)) == ReferenceDigest,
            "Mortar pool source evidence changed without a reviewed extraction.");
        using JsonDocument document = JsonDocument.Parse(bytes);
        JsonElement root = document.RootElement;
        checks += Require(root.GetProperty("schemaVersion").GetInt32() == 1 &&
            root.GetProperty("capacity").GetInt32() == 4 && root.GetProperty("poolComponentFileId").GetInt32() == 49549 &&
            root.GetProperty("weaponComponentFileId").GetInt32() == 11496012,
            "The recovered pool lost its exact scene/prefab/capacity identity.");
        checks += CheckSources(directory, root);
        return checks + CheckMixedAllocation(root.GetProperty("capacity").GetInt32()) + CheckRejectedInputs();
    }

    private static int CheckSources(string directory, JsonElement root)
    {
        string repository = Directory.GetParent(directory)!.Parent!.FullName;
        int checks = 0;
        foreach (JsonElement row in root.GetProperty("sources").EnumerateArray())
        {
            string path = Path.Combine(repository, "Clients/ExportedProject", row.GetProperty("source").GetString()!);
            string normalized = File.ReadAllText(path).Replace("\r\n", "\n").Replace('\r', '\n');
            string digest = Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(normalized)));
            checks += Require(digest == row.GetProperty("normalizedUtf8LfSha256").GetString(),
                "Recovered source/configuration changed without reviewing the pool policy.");
        }
        return checks;
    }

    private static int CheckMixedAllocation(int capacity)
    {
        var pool = new MortarWeaponPool(capacity);
        int checks = Require(pool.FreeSlots().SequenceEqual(new[] { 0, 1, 2, 3 }),
            "Original prewarmed indices must start in ascending order.");
        checks += Require(pool.TryAllocateForMaster(11, out int masterFirst) && masterFirst == 0 &&
            pool.TryAllocateForPeer(21, out int peerFirst) && peerFirst == 3 &&
            pool.TryAllocateForMaster(12, out int masterSecond) && masterSecond == 1 &&
            pool.TryAllocateForPeer(22, out int peerSecond) && peerSecond == 2 && pool.ActiveCount == capacity,
            "Mixed master/peer allocation did not use opposing free-list ends.");
        checks += Require(!pool.TryAllocateForMaster(13, out int exhausted) && exhausted == -1 &&
            pool.SlotFor(13) == null && pool.ActiveCount == capacity,
            "Exhaustion created a source index or consumed a future actor identity.");
        checks += Require(pool.Release(21) && pool.Release(12) &&
            pool.FreeSlots().SequenceEqual(new[] { 1, 3 }),
            "Returned slots must be inserted at the front regardless of their original owner side.");
        checks += Require(pool.TryAllocateForPeer(23, out int reusedPeer) && reusedPeer == 3 &&
            pool.TryAllocateForMaster(13, out int reusedMaster) && reusedMaster == 1,
            "A peer must not consume the most recently returned slot when an older free slot exists.");
        checks += Require(!pool.Release(21) && !pool.Release(99) && pool.SlotFor(23) == 3 &&
            pool.ActiveCount == capacity,
            "An old actor release freed a slot now owned by a successor.");
        checks += Require(pool.Release(22) && pool.Release(11) && pool.Release(23) &&
            pool.FreeSlots().SequenceEqual(new[] { 3, 0, 2 }) &&
            pool.TryAllocateForPeer(24, out int lastPeer) && lastPeer == 2 &&
            pool.TryAllocateForMaster(14, out int lastMaster) && lastMaster == 3,
            "Multi-return ordering was replaced with actor order or a FIFO policy.");
        int[] copied = pool.FreeSlots();
        copied[0] = 999;
        checks += Require(pool.TryAllocateForMaster(15, out int final) && final == 0 && pool.ActiveCount == capacity,
            "A diagnostic free-list copy mutated pool authority.");
        return checks;
    }

    private static int CheckRejectedInputs()
    {
        int checks = 0;
        foreach (int capacity in new[] { -1, 0, 257 })
        {
            bool rejected = false;
            try
            {
                _ = new MortarWeaponPool(capacity);
            }
            catch (ArgumentOutOfRangeException)
            {
                rejected = true;
            }
            checks += Require(rejected, "Pool capacity escaped its recovered index domain.");
        }
        var pool = new MortarWeaponPool(4);
        pool.TryAllocateForMaster(11, out _);
        foreach (Action action in new Action[]
            { () => pool.TryAllocateForPeer(11, out _), () => pool.TryAllocateForMaster(0, out _), () => pool.Release(0) })
        {
            bool rejected = false;
            try
            {
                action();
            }
            catch (Exception failure) when (failure is InvalidDataException or ArgumentOutOfRangeException)
            {
                rejected = true;
            }
            checks += Require(rejected && pool.SlotFor(11) == 0 && pool.ActiveCount == 1 &&
                pool.FreeSlots().SequenceEqual(new[] { 1, 2, 3 }),
                "Rejected allocation/release changed existing slot ownership.");
        }
        return checks;
    }

    private static int Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
        return 1;
    }
}
