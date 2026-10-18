using Google.Protobuf;

using War.Client;
using War.Protocol;
using War.Shared;

/// <summary>Checks protobuf pose identity/lifetime and independent observations in a paged replay roster.</summary>
internal static class MortarWeaponPoseProjectionTests
{
    private const ulong ObservedTick = 120;

    internal static int Run()
    {
        BattleArmyEntityState valid = Actor();
        BattleArmyEntityState decoded = BattleArmyEntityState.Parser.ParseFrom(valid.ToByteArray());
        int checks = Require(MortarWeaponPosePolicy.IsValid(decoded, ObservedTick) && decoded.Equals(valid),
            "The complete Mortar world observation did not survive protobuf serialization.");
        Action<BattleArmyEntityState>[] corruptions =
        {
            row => row.UnitId = "ID_UNIT-GUNSLINGER",
            row => row.SourceCardId = "BIGROCKET",
            row => row.InfantryClip = "mortar_up",
            row => row.InfantryClipStartTick++,
            row => row.SpawnTick = row.MortarWeaponPose.PreparedTick + 1,
            row => row.MortarWeaponPose.PreparedTick = ulong.MaxValue,
            row => row.MortarWeaponPose.HandReturnTick++,
            row => row.MortarWeaponPose.ObservedTick++,
            row => row.MortarWeaponPose.X = float.NaN,
            row => row.MortarWeaponPose.Y = float.PositiveInfinity,
            row => row.MortarWeaponPose.Z = 10001f,
            row => row.MortarWeaponPose.Rotation = null,
            row => row.MortarWeaponPose.Rotation.W = 0f,
            row => row.MortarWeaponPose.Rotation.X = float.NaN,
            row => row.MortarWeaponPose.ScaleX = 0f,
            row => row.MortarWeaponPose.ScaleY = 2f,
            row => row.MortarWeaponPose.ScaleZ = float.NaN
        };
        foreach (Action<BattleArmyEntityState> corrupt in corruptions)
        {
            BattleArmyEntityState row = valid.Clone();
            corrupt(row);
            checks += Require(!MortarWeaponPosePolicy.IsValid(row, ObservedTick),
                "SDK accepted a forged or malformed Mortar pose observation.");
        }
        BattleArmyEntityState expired = valid.Clone();
        expired.MortarWeaponPose.ObservedTick = expired.MortarWeaponPose.HandReturnTick;
        checks += Require(!MortarWeaponPosePolicy.IsValid(expired, expired.MortarWeaponPose.ObservedTick),
            "A hand-return observation retained detached authority.");
        valid.MortarWeaponPose = null;
        checks += Require(MortarWeaponPosePolicy.IsValid(valid, ObservedTick),
            "An absent pose must retain the source held/terminal state.");
        return checks + CheckPagedReplay();
    }

    private static int CheckPagedReplay()
    {
        var first = new MatchArmyEntityBatch
        {
            Code = "entities", ActiveCount = 4, Revision = 1, ServerTick = ObservedTick, HasMore = true
        };
        first.Entities.Add(Actor());
        first.Entities.Add(new BattleArmyEntityState { EntityKey = 2 });
        first.Entities.Add(new BattleArmyEntityState { EntityKey = 3 });
        var roster = new ArmyEntityPageAccumulator();
        roster.Add(MatchArmyEntityBatch.Parser.ParseFrom(first.ToByteArray()));
        first.Entities[0].MortarWeaponPose.X = 99f;
        var last = new MatchArmyEntityBatch
        {
            Code = "entities", ActiveCount = 4, Revision = 1, ServerTick = 135
        };
        last.Entities.Add(new BattleArmyEntityState { EntityKey = 4 });
        roster.Add(last);
        var captured = roster.Snapshot()[0];
        int checks = Require(captured.MortarWeaponPose.ObservedTick == ObservedTick &&
            captured.MortarWeaponPose.X == 2f &&
            MortarWeaponPosePolicy.IsValid(captured, ObservedTick),
            "Paged reconstruction lost the earlier pose's own observation or retained a mutable input alias.");
        var invalid = first.Clone();
        invalid.Entities[0].MortarWeaponPose.ScaleX = -1f;
        try
        {
            new ArmyEntityPageAccumulator().Add(invalid);
        }
        catch (InvalidOperationException)
        {
            return checks + 1;
        }
        throw new InvalidOperationException("Roster reconstruction accepted a malformed nested world pose.");
    }

    private static BattleArmyEntityState Actor()
    {
        return new BattleArmyEntityState
        {
            EntityKey = 1, UnitId = "ID_UNIT-MORTAR", SpawnTick = 61,
            InfantryClip = "mortar_hide", InfantryClipStartTick = 100,
            MortarWeaponPose = new BattleMortarWeaponPose
            {
                PreparedTick = 100, HandReturnTick = 134, ObservedTick = ObservedTick,
                X = 2f, Y = 0.1f, Z = 3f, Rotation = new BattleJointRotation { W = 1f },
                ScaleX = 1f, ScaleY = 1f, ScaleZ = 1f
            }
        };
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
