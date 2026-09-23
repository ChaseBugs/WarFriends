using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using War.Protocol;

public static class SelfHostedArmyBridgeAudit
{
    public static void Run()
    {
        var root = new GameObject("SelfHostedArmyBridgeAudit");
        try
        {
            var manager = root.AddComponent<SpawningManagerDeathMatch>();
            var client = root.AddComponent<SelfHostedBattleClient>();
            typeof(SelfHostedBattleClient).GetProperty("IsConnected")
                .GetSetMethod(true).Invoke(client, new object[] { true });
            typeof(SelfHostedBattleClient).GetProperty("State")
                .GetSetMethod(true).Invoke(client, new object[] {
                    new MatchSnapshot { ServerTick = 60 }
                });
            var family = new SpawningManagerDeathMatch.ArmyUnit();
            family.unitsCounts = new List<SpawningManagerDeathMatch.ArmyUnitDefinition>();
            for (int index = 0; index < 3; index++)
                family.unitsCounts.Add(new SpawningManagerDeathMatch.ArmyUnitDefinition {
                    armyUnit = family, index = index
                });
            manager.armyDefinitions = new List<SpawningManagerDeathMatch.ArmyUnit> { family };
            int changes = 0;
            manager.ArmyChanged += () => changes++;
            manager.BindSelfHosted(client);
            var hidden = BindingFlags.Instance | BindingFlags.NonPublic;
            typeof(SpawningManagerDeathMatch).GetMethod("GetUnitsForClient", hidden)
                .Invoke(manager, null);
            typeof(SpawningManagerDeathMatch).GetMethod("SendUnitRPC", hidden)
                .Invoke(manager, new object[] { 0, (byte)1, true });
            typeof(SpawningManagerDeathMatch).GetMethod("GetRandomUnitsForHost", hidden)
                .Invoke(manager, new object[] { (byte)1, 1 });
            typeof(SpawningManagerDeathMatch).GetMethod("RecieveRandomUnitsForHost", hidden)
                .Invoke(manager, new object[] { new byte[] { 0, 1, 2 }, 1 });
            var field = typeof(SelfHostedBattleClient).GetField("ArmyOffersReceived",
                BindingFlags.Instance | BindingFlags.NonPublic);
            var publish = (Action<MatchArmyBatch>)field.GetValue(client);
            var offered = new MatchArmyBatch { Code = "army-offers", Energy = 8 };
            offered.OptionIndexes.Add(2); offered.OptionIndexes.Add(0); offered.OptionIndexes.Add(1);
            publish(offered);
            if (changes != 1 || manager.currentArmyUnitDefinitions.Count != 3 ||
                manager.currentArmyUnitDefinitions[0] != family.unitsCounts[2] ||
                manager.currentArmyUnitDefinitions[1] != family.unitsCounts[0] ||
                manager.currentArmyUnitDefinitions[2] != family.unitsCounts[1] ||
                (int)manager.powerLeft != 8)
                throw new Exception("Source army UI did not receive the exact host hand and energy.");
            publish(offered);
            if (changes != 1) throw new Exception("Stable host poll republished the same army hand.");
            var invalid = new MatchArmyBatch { Code = "army-offers", Energy = 8 };
            invalid.OptionIndexes.Add(2); invalid.OptionIndexes.Add(99); invalid.OptionIndexes.Add(1);
            try { publish(invalid); throw new Exception("Unknown source option was accepted."); }
            catch (InvalidOperationException) { }
            if (manager.currentArmyUnitDefinitions[1] != family.unitsCounts[0])
                throw new Exception("Invalid host hand changed the visible source hand.");
            publish(new MatchArmyBatch { Code = "army-unavailable", Energy = 6 });
            if (changes != 2 || manager.currentArmyUnitDefinitions.Count != 0 ||
                (int)manager.powerLeft != 6)
                throw new Exception("Unavailable host hand did not clear the original cards.");
            manager.UnbindSelfHosted(client);
            if (field.GetValue(client) != null || changes != 3 ||
                manager.currentArmyUnitDefinitions.Count != 0)
                throw new Exception("Army bridge left a subscriber or visible hand after unbind.");
            typeof(SpawningManagerDeathMatch).GetMethod("GetUnitsForClient", hidden)
                .Invoke(manager, null);
            typeof(SpawningManagerDeathMatch).GetMethod("SendUnitRPC", hidden)
                .Invoke(manager, new object[] { 0, (byte)1, true });
            typeof(SpawningManagerDeathMatch).GetMethod("GetRandomUnitsForHost", hidden)
                .Invoke(manager, new object[] { (byte)1, 1 });
            typeof(SpawningManagerDeathMatch).GetMethod("RecieveRandomUnitsForHost", hidden)
                .Invoke(manager, new object[] { new byte[] { 0, 1, 2 }, 1 });
            manager.SendUnit(family.unitsCounts[0], Fractions.Allies);
            try { manager.BindSelfHosted(client); throw new Exception("Match mode was rebound."); }
            catch (InvalidOperationException) { }
            Debug.Log("SELF_HOSTED_ARMY_BRIDGE_AUDIT_PASSED");
        }
        finally { UnityEngine.Object.DestroyImmediate(root); }
        EditorApplication.Exit(0);
    }
}
