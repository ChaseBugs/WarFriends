using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.SceneManagement;
using UnityEngine;
using War.Protocol;

/// <summary>Binds source rigs for both the Editor control and automatic Play Mode UDP scenario.</summary>
public static class UnityLiveBazookaRigs
{
    /// <summary>Uses preserved inactive Play Mode rigs or copies the original Editor scene rig.</summary>
    public static void Select(GameObject sources, out GameObject left, out GameObject right)
    {
        if (sources != null)
        {
            PlayerController[] players = sources.GetComponentsInChildren<PlayerController>(true);
            left = players.Single(row => row.name == "LiveBazookaLeft").gameObject;
            right = players.Single(row => row.name == "LiveBazookaRight").gameObject;
            return;
        }

        var scene = EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
        PlayerController original = scene.GetRootGameObjects()
            .SelectMany(root => root.GetComponentsInChildren<GameController>(true)).Single().mainPlayerController;
        left = CloneRig(original, "LiveBazookaLeft");
        right = CloneRig(original, "LiveBazookaRight");
    }

    /// <summary>Checks both the authoritative slot and the recovered current weapon reference.</summary>
    public static void VerifySlotSelection(SelfHostedBattleClient adapter, int slot)
    {
        Require(adapter.State.Players.Single(row => row.PlayerId == adapter.LocalPlayerId)
            .ActiveWeaponSlot == slot, "The host must accept the local RPG slot switch.");
        int weaponIndex = adapter.PlayerViews.Single(row => row.PlayerId == adapter.LocalPlayerId)
            .Weapons.Single(row => row.Slot == slot).WeaponIndex;
        PlayerController player = Resources.FindObjectsOfTypeAll<PlayerController>()
            .Single(row => row.name == "LiveBazookaLeft" && row.gameObject.scene.IsValid());
        Require(player.weaponInventory.currentWeapon == player.weaponInventory.allWeapons[weaponIndex],
            "The recovered rig must select its actual RPG weapon.");
    }

    /// <summary>Retains source weapon identities for each independently authenticated participant.</summary>
    public static void BindInventory(PlayerController player, MatchConnectionGrant grant)
    {
        player.playerProperties = new PlayerProperties { playerID = grant.PlayerId };
        WeaponInventory inventory = player.ResolveSelfHostedInventory();
        inventory.usedWeapons = new List<PlayerWeapon>();
        foreach (BattleWeaponView weapon in grant.PlayerViews.Single(row => row.PlayerId == grant.PlayerId).Weapons)
        {
            PlayerWeapon source = inventory.allWeapons[weapon.WeaponIndex];
            source.playerController = player;
            inventory.usedWeapons.Add(source);
        }
    }

    private static GameObject CloneRig(PlayerController original, string name)
    {
        bool wasActive = original.gameObject.activeSelf;
        original.gameObject.SetActive(false);
        GameObject clone = UnityEngine.Object.Instantiate(original.gameObject);
        original.gameObject.SetActive(wasActive);
        clone.name = name;
        foreach (MonoBehaviour behaviour in clone.GetComponentsInChildren<MonoBehaviour>(true))
        {
            behaviour.enabled = false;
        }

        clone.SetActive(true);
        return clone;
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
