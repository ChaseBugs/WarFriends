using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using War.BattleServer;

/// <summary>Prevents a full bind-pose reset from replacing the source's partial root restoration.</summary>
internal static class SoldierAnimationRootResetTests
{
    private const string ReferenceDigest = "5a18328895cb24379ee407c0ceacef714bcd88c072a2d255e2b42bd24d48cf98";

    internal static int Run(string directory)
    {
        string text = File.ReadAllText(Path.Combine(directory,
            "recovered-soldier-pose-reset-unity-reference.json")).Replace("\r\n", "\n");
        Require(Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(text))) == ReferenceDigest,
            "Soldier root reset reference changed without review.");
        using JsonDocument document = JsonDocument.Parse(text);
        JsonElement root = document.RootElement;
        RigLocalTransform[] rest = ReadPose(root.GetProperty("rest"));
        RigLocalTransform[] sampled = ReadPose(root.GetProperty("sampled"));
        RigLocalTransform[] before = ReadPose(root.GetProperty("before"));
        RigLocalTransform[] after = ReadPose(root.GetProperty("after"));
        int rootIndex = root.GetProperty("rootIndex").GetInt32();
        Require(rootIndex == 1 && root.GetProperty("innerIndex").GetInt32() == -1 && rest.Length == 9,
            "Source root/palm chain binding changed.");
        var target = new SoldierAnimationRootReset.Target(rootIndex, rest[rootIndex]);
        RigLocalTransform[] result = SoldierAnimationRootReset.Apply(before, new[] { target });
        Require(result.SequenceEqual(after), "Partial root reset differs from actual original controller output.");
        Require(before[0] == after[0] && before[rootIndex].Scale == after[rootIndex].Scale &&
            before[rootIndex].Scale != rest[rootIndex].Scale && !sampled.SequenceEqual(rest),
            "Reset fixture lost its changed animation, retained non-root transform or retained scale.");
        Require(before[rootIndex].Position != result[rootIndex].Position &&
            before.SequenceEqual(ReadPose(root.GetProperty("before"))),
            "Root reset changed the input or did not restore the source root position.");
        VerifyStoppedClip(root);
        Reject(before, new[] { target, target });
        Reject(before, new[] { target with { Index = before.Length } });
        Console.WriteLine("PASS: source partial root reset, retained sampled bones/scale " +
            "and stopped clip observation.");
        return 16;
    }

    private static void VerifyStoppedClip(JsonElement root)
    {
        JsonElement before = root.GetProperty("statesBefore")[0];
        JsonElement after = root.GetProperty("statesAfter")[0];
        Require(before.GetProperty("enabled").GetBoolean() && before.GetProperty("time").GetSingle() > 0 &&
            !after.GetProperty("enabled").GetBoolean() && after.GetProperty("time").GetSingle() == 0 &&
            before.GetProperty("weight").GetSingle() == after.GetProperty("weight").GetSingle(),
            "Reset capture no longer observes the sampled clip stopping while retaining its weight.");
    }

    private static void Reject(RigLocalTransform[] current, SoldierAnimationRootReset.Target[] targets)
    {
        RigLocalTransform[] before = current.ToArray();
        try
        {
            SoldierAnimationRootReset.Apply(current, targets);
        }
        catch (InvalidDataException)
        {
            Require(current.SequenceEqual(before), "Rejected root reset mutated the current pose.");
            return;
        }
        throw new Exception("Root reset accepted invalid source bindings.");
    }

    private static RigLocalTransform[] ReadPose(JsonElement rows)
    {
        return rows.EnumerateArray().Select(row => new RigLocalTransform(Vector(row.GetProperty("position")),
            Rotation(row.GetProperty("rotation")), Vector(row.GetProperty("scale")))).ToArray();
    }

    private static Vector3 Vector(JsonElement value)
    {
        return new Vector3(value[0].GetSingle(), value[1].GetSingle(), value[2].GetSingle());
    }

    private static Quaternion Rotation(JsonElement value)
    {
        return new Quaternion(value[0].GetSingle(), value[1].GetSingle(), value[2].GetSingle(), value[3].GetSingle());
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}
