using System;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using War.Protocol;

/// <summary>Checks self-hosted auto-deploy admission and stale candidate removal in Unity Mono.</summary>
public static class UnityArmyAutoDeployAudit
{
    public static void Run()
    {
        GameObject owner = new GameObject("ArmyAutoDeployAudit");
        owner.SetActive(false);
        try
        {
            SelfHostedBattleClient client = owner.AddComponent<SelfHostedBattleClient>();
            SpawningManagerDeathMatch army = owner.AddComponent<SpawningManagerDeathMatch>();
            SetProperty(client, "IsConnected", true);
            var state = new MatchSnapshot { Phase = BattlePhase.Running };
            SetProperty(client, "State", state);
            army.autoDeployEnabled = true;
            army.BindSelfHosted(client);
            Require(army.autoDeployEnabled, "Binding a host session erased the selected auto-deploy mode.");
            army.currentArmyUnitDefinitions.Add(new SpawningManagerDeathMatch.ArmyUnitDefinition());
            Require(CanAdvance(army), "A connected running session with offers cannot advance.");
            SetField(army, "mSelfHostedDeployPending", true);
            Require(!CanAdvance(army), "An outstanding command permits duplicate automatic input.");
            SetField(army, "mSelfHostedDeployPending", false);
            state.PauseHostTick = 1;
            Require(!CanAdvance(army), "Reconnect pause permits automatic input.");
            state.PauseHostTick = 0;
            state.Phase = BattlePhase.Countdown;
            Require(!CanAdvance(army), "Loading/countdown permits automatic input.");
            state.Phase = BattlePhase.Running;
            SetProperty(client, "IsConnected", false);
            Require(!CanAdvance(army), "Disconnected transport permits automatic input.");
            SetProperty(client, "IsConnected", true);
            SetField(army, "mHasPregeneratedArmy", true);
            SetField(army, "mPregenerated", army.currentArmyUnitDefinitions[0]);
            typeof(SpawningManagerDeathMatch).GetMethod("ApplySelfHostedArmy", PrivateInstance)
                .Invoke(army, new object[] { new MatchArmyBatch { Code = "army-unavailable", Energy = 8 } });
            Require(!CanAdvance(army), "An empty host hand permits automatic input.");
            Require(!(bool)GetField(army, "mHasPregeneratedArmy") && GetField(army, "mPregenerated") == null,
                "A removed host offer retained a stale preselected unit.");
            File.WriteAllText(Path.Combine(Application.dataPath, "../army-auto-deploy-unity-audit.json"),
                "{\"checks\":8,\"scope\":\"compiled Unity auto-deploy gate and stale candidate lifecycle\"}\n");
            Debug.Log("PASS: 8 Unity auto-deploy gate and candidate checks; no rendered battle acceptance.");
            EditorApplication.Exit(0);
        }
        catch (Exception failure)
        {
            Debug.LogException(failure);
            EditorApplication.Exit(1);
        }
        finally
        {
            UnityEngine.Object.DestroyImmediate(owner);
        }
    }

    private const BindingFlags PrivateInstance = BindingFlags.Instance | BindingFlags.NonPublic;

    private static bool CanAdvance(SpawningManagerDeathMatch army)
    {
        return (bool)typeof(SpawningManagerDeathMatch).GetMethod("CanAdvanceSelfHostedAutoDeploy", PrivateInstance)
            .Invoke(army, null);
    }

    private static void SetProperty(object owner, string name, object value)
    {
        owner.GetType().GetProperty(name).SetValue(owner, value, null);
    }

    private static object GetField(object owner, string name)
    {
        return owner.GetType().GetField(name, PrivateInstance).GetValue(owner);
    }

    private static void SetField(object owner, string name, object value)
    {
        owner.GetType().GetField(name, PrivateInstance).SetValue(owner, value);
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
