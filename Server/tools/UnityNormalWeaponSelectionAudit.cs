using System;
using System.IO;
using System.Reflection;

using UnityEngine;

using War.Protocol;

namespace WarFriends.Validation
{
    /// <summary>Exercises the recovered HUD click and observes host-owned weapon selection on both peers.</summary>
    public static class UnityNormalWeaponSelectionAudit
    {
        private const int SelectedInventoryIndex = 1;
        private const int OriginalInventoryIndex = 0;
        private static readonly FieldInfo ItemWeapon = typeof(InventoryItem).GetField(
            "mWeapon", BindingFlags.Instance | BindingFlags.NonPublic);
        private static WeaponInventory _inventory;
        private static InventoryItem _clickedItem;
        private static string _targetPlayerId;
        private static string _failureType;
        private static int _targetSlot;
        private static bool _hasRequested;
        private static bool _hasObservedSelection;
        private static bool _hasCheckedReconnectBlock;

        private static bool IsInitiator
        {
            get { return Environment.GetEnvironmentVariable("WAR_NORMAL_BATTLE_RECONNECT_SELF") == "1"; }
        }

        private static string MarkerPrefix
        {
            get { return Environment.GetEnvironmentVariable("WAR_NORMAL_BATTLE_RECONNECT_MARKER"); }
        }

        /// <summary>Requires both peers to observe the same HUD-selected weapon before reconnect starts.</summary>
        public static bool Observe(GameController game, SelfHostedBattleClient client)
        {
            if (string.IsNullOrEmpty(MarkerPrefix))
            {
                return true;
            }
            if (_failureType != null)
            {
                return false;
            }
            try
            {
                if (_inventory == null)
                {
                    Bind(game, client);
                }
                if (IsInitiator && !_hasRequested)
                {
                    RequireDifferentInitialSelection(client);
                    ClickRecoveredHud();
                }
                return ObserveSelection(client);
            }
            catch (Exception failure)
            {
                // Keep diagnostics bounded without retaining server/session error messages.
                _failureType = failure.GetBaseException().GetType().Name;
                return false;
            }
        }

        /// <summary>Checks that an ordinary selection cannot mutate the scene during transport replacement.</summary>
        public static void RequireSelectionBlockedDuringReconnect(SelfHostedBattleClient client)
        {
            if (!IsInitiator || _inventory == null || _inventory.weaponSwitchLocked ||
                client.IsConnected && !client.IsReconnecting)
            {
                throw new InvalidOperationException("The reconnect selection guard was not exercised.");
            }
            _inventory.currentWeapon = _inventory.usedWeapons[OriginalInventoryIndex];
            if (_inventory.weaponIndex != SelectedInventoryIndex)
            {
                throw new InvalidOperationException("A reconnect-time selection mutated the local inventory.");
            }
            _hasCheckedReconnectBlock = true;
        }

        /// <summary>Reports the real HUD path separately from pointer hit-testing and firing input.</summary>
        public static object Capture()
        {
            return new
            {
                hasRequestedHudClick = _hasRequested,
                hasObservedSelection = _hasObservedSelection,
                hasCheckedReconnectBlock = _hasCheckedReconnectBlock,
                targetInventoryIndex = SelectedInventoryIndex,
                targetSlot = _targetSlot,
                failureType = _failureType
            };
        }

        /// <summary>Invokes the selected recovered HUD item's ordinary reload callback.</summary>
        public static void ClickSelectedWeaponForReload()
        {
            if (!IsInitiator || _clickedItem == null || !_hasObservedSelection)
            {
                throw new InvalidOperationException("The selected normal weapon HUD item is unavailable.");
            }
            _clickedItem.SendMessage("OnClick", SendMessageOptions.RequireReceiver);
        }

        private static void Bind(GameController game, SelfHostedBattleClient client)
        {
            PlayerController player = IsInitiator ? game.mainPlayerController : game.opponent;
            _targetPlayerId = player.playerProperties.playerID;
            _inventory = player.ResolveSelfHostedInventory();
            if (_inventory == null || _inventory.usedWeapons.Count <= SelectedInventoryIndex)
            {
                throw new InvalidOperationException("The normal inventory has no alternate weapon.");
            }
            foreach (BattlePlayerView view in client.PlayerViews)
            {
                if (view.PlayerId == _targetPlayerId && view.Weapons.Count > SelectedInventoryIndex)
                {
                    _targetSlot = view.Weapons[SelectedInventoryIndex].Slot;
                    return;
                }
            }
            throw new InvalidOperationException("The alternate inventory has no authoritative slot.");
        }

        private static void ClickRecoveredHud()
        {
            InventoryGuiElement hud = UnityEngine.Object.FindObjectOfType<InventoryGuiElement>();
            PlayerWeapon weapon = _inventory.usedWeapons[SelectedInventoryIndex];
            if (hud == null || !PlayerController.currentPlayer.updateWeapons || _inventory.weaponSwitchLocked)
            {
                throw new InvalidOperationException("The normal weapon HUD is not available for input.");
            }
            foreach (InventoryItem item in hud.invItems)
            {
                if ((PlayerWeapon)ItemWeapon.GetValue(item) != weapon)
                {
                    continue;
                }
                if (!item.gameObject.activeInHierarchy || !item.icon.gameObject.activeSelf)
                {
                    throw new InvalidOperationException("The alternate weapon HUD item is hidden.");
                }
                _clickedItem = item;
                _hasRequested = true;
                item.SendMessage("OnClick", SendMessageOptions.RequireReceiver);
                return;
            }
            throw new InvalidOperationException("The normal HUD has no item for the alternate weapon.");
        }

        private static void RequireDifferentInitialSelection(SelfHostedBattleClient client)
        {
            if (_inventory.weaponIndex != OriginalInventoryIndex)
            {
                throw new InvalidOperationException("The HUD fixture must start on its original weapon.");
            }
            foreach (BattlePlayerState player in client.State.Players)
            {
                if (player.PlayerId == _targetPlayerId && player.ActiveWeaponSlot != _targetSlot)
                {
                    return;
                }
            }
            throw new InvalidOperationException("The alternate weapon is already selected on the host.");
        }

        private static bool ObserveSelection(SelfHostedBattleClient client)
        {
            if (client == null || client.State == null)
            {
                return false;
            }
            foreach (BattlePlayerState player in client.State.Players)
            {
                if (player.PlayerId != _targetPlayerId || player.ActiveWeaponSlot != _targetSlot)
                {
                    continue;
                }
                if (!IsPresented(player))
                {
                    return false;
                }
                PublishObservation(client.State.MatchId);
                string peerMarker = MarkerPrefix + (IsInitiator ? ".weapon-peer" : ".weapon-self");
                return File.Exists(peerMarker) && File.ReadAllText(peerMarker) == client.State.MatchId;
            }
            return false;
        }

        private static bool IsPresented(BattlePlayerState player)
        {
            PlayerWeapon selected = _inventory.currentWeapon;
            return _inventory.weaponIndex == SelectedInventoryIndex && selected.isActiveWeapon &&
                selected.gameObject.activeInHierarchy && selected.weapon.ammoLeftInClip == player.ClipAmmo &&
                selected.weapon.ammoLeft == player.ReserveAmmo &&
                (!IsInitiator || _clickedItem.selectedBorder.gameObject.activeSelf);
        }

        private static void PublishObservation(string matchId)
        {
            if (_hasObservedSelection)
            {
                return;
            }
            string marker = MarkerPrefix + (IsInitiator ? ".weapon-self" : ".weapon-peer");
            File.WriteAllText(marker + ".pending", matchId);
            File.Move(marker + ".pending", marker);
            _hasObservedSelection = true;
        }
    }
}
