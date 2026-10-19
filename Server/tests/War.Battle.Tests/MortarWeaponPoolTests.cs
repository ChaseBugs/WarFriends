using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

using War.BattleServer;
using War.Backend;

/// <summary>Checks the recovered four-slot pool and rejects stale actor ownership.</summary>
internal static class MortarWeaponPoolTests
{
    private const string ReferenceDigest = "b47c3e88b9d70a48508e125f4e10712fc207f814bf239a20b01887a996620d3e";

    internal static int Run(string directory)
    {
        byte[] bytes = File.ReadAllBytes(Path.Combine(directory, "recovered-mortar-weapon-pool.json"));
        int checks = Require(Convert.ToHexStringLower(SHA256.HashData(bytes)) == ReferenceDigest,
            "Mortar pool source evidence changed without a reviewed extraction.");
        using JsonDocument document = JsonDocument.Parse(bytes);
        JsonElement root = document.RootElement;
        checks += Require(root.GetProperty("schemaVersion").GetInt32() == 2 &&
            root.GetProperty("capacity").GetInt32() == 4 &&
            root.GetProperty("poolComponentFileId").GetInt32() == 49549 &&
            root.GetProperty("weaponComponentFileId").GetInt32() == 11496012,
            "The recovered pool lost its exact scene/prefab/capacity identity.");
        checks += CheckSources(directory, root);
        return checks + CheckMixedAllocation(root.GetProperty("capacity").GetInt32()) + CheckRejectedInputs() +
            CheckStartupSource(directory, root) + MortarCorpseReturnClockTests.Run(directory);
    }

    private static int CheckStartupSource(string directory, JsonElement root)
    {
        BattleCombatContent content = BattleArmyManifestProjectionTests.LoadContent(directory);
        string path = Path.Combine(directory, "recovered-mortar-weapon-pool.json");
        string sceneRevision = root.GetProperty("deployment").GetProperty("sceneRevision").GetString()!;
        int checks = Require(MortarWeaponPoolSource.Load(path, content.Army, sceneRevision).Capacity == 4 &&
            content.MortarWeaponPool.Capacity == 4,
            "Combat startup did not retain the verified pool capacity.");
        checks += Require(BattleRifleManifestCatalog.Load(Path.Combine(directory, "combat-content-manifest.json"))
            .PackageRevision == content.Revision,
            "Backend admission and Worker content use different pool-bound catalog revisions.");
        string temporary = Path.GetTempFileName();
        try
        {
            byte[] valid = File.ReadAllBytes(path);
            byte[] changed = (byte[])valid.Clone();
            changed[0] ^= 1;
            foreach (byte[] invalid in new[] { new byte[1], new byte[16385], changed })
            {
                File.WriteAllBytes(temporary, invalid);
                bool rejected = false;
                try
                {
                    MortarWeaponPoolSource.Load(temporary, content.Army, sceneRevision);
                }
                catch (InvalidDataException)
                {
                    rejected = true;
                }
                checks += Require(rejected, "Startup accepted a truncated, oversized or unreviewed pool artifact.");
            }
            File.WriteAllBytes(temporary, valid);
            bool sceneRejected = false;
            try
            {
                MortarWeaponPoolSource.Load(temporary, content.Army, new string('a', 64));
            }
            catch (InvalidDataException)
            {
                sceneRejected = true;
            }
            checks += Require(sceneRejected, "Pool capacity was attached to a different deployment scene.");
        }
        finally
        {
            File.Delete(temporary);
        }
        return checks;
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
            pool.TryAllocateForPeer(22, out int peerSecond) && peerSecond == 2 && pool.OccupiedCount == capacity,
            "Mixed master/peer allocation did not use opposing free-list ends.");
        checks += Require(!pool.TryAllocateForMaster(13, out int exhausted) && exhausted == -1 &&
            pool.SlotFor(13) == null && pool.OccupiedCount == capacity,
            "Exhaustion created a source index or consumed a future actor identity.");
        checks += Require(pool.Release(21) && pool.Release(12) &&
            pool.FreeSlots().SequenceEqual(new[] { 1, 3 }),
            "Returned slots must be inserted at the front regardless of their original owner side.");
        checks += Require(pool.TryAllocateForPeer(23, out int reusedPeer) && reusedPeer == 3 &&
            pool.TryAllocateForMaster(13, out int reusedMaster) && reusedMaster == 1,
            "A peer must not consume the most recently returned slot when an older free slot exists.");
        checks += Require(!pool.Release(21) && !pool.Release(99) && pool.SlotFor(23) == 3 &&
            pool.OccupiedCount == capacity,
            "An old actor release freed a slot now owned by a successor.");
        checks += Require(pool.Release(22) && pool.Release(11) && pool.Release(23) &&
            pool.FreeSlots().SequenceEqual(new[] { 3, 0, 2 }) &&
            pool.TryAllocateForPeer(24, out int lastPeer) && lastPeer == 2 &&
            pool.TryAllocateForMaster(14, out int lastMaster) && lastMaster == 3,
            "Multi-return ordering was replaced with actor order or a FIFO policy.");
        int[] copied = pool.FreeSlots();
        copied[0] = 999;
        checks += Require(pool.TryAllocateForMaster(15, out int final) && final == 0 && pool.OccupiedCount == capacity,
            "A diagnostic free-list copy mutated pool authority.");
        pool.Clear();
        checks += Require(pool.OccupiedCount == 0 && pool.SlotFor(15) == null && !pool.Release(15) &&
            pool.FreeSlots().SequenceEqual(new[] { 0, 1, 2, 3 }),
            "Terminal pool reset retained an actor binding or changed the next scene's initial index order.");
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
            {
                () => pool.TryAllocateForPeer(11, out _),
                () => pool.TryAllocateForMaster(0, out _),
                () => pool.Release(0)
            })
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
            checks += Require(rejected && pool.SlotFor(11) == 0 && pool.OccupiedCount == 1 &&
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
