using System;
using System.IO;
using System.Threading.Tasks;

using UnityEngine;

using War.Protocol;

namespace WarFriends.Validation
{
    /// <summary>Prepares one authoritative shot, then checks the actual selected HUD reload on both peers.</summary>
    public static class UnityNormalReloadAudit
    {
        private const float TargetHeightAboveOpponent = 100f;
        private const float MaximumAimSeconds = 10f;
        private const int AimPollMilliseconds = 50;
        private static Task _shot;
        private static string _playerId;
        private static string _failureType;
        private static Weapon _weapon;
        private static int _initialClip;
        private static int _initialReserve;
        private static bool _hasClickedReload;
        private static bool _hasObservedShot;
        private static bool _hasObservedPending;
        private static bool _hasCompleted;

        private static bool IsInitiator
        {
            get { return Environment.GetEnvironmentVariable("WAR_NORMAL_BATTLE_RECONNECT_SELF") == "1"; }
        }

        private static string MarkerPrefix
        {
            get { return Environment.GetEnvironmentVariable("WAR_NORMAL_BATTLE_RECONNECT_MARKER") + ".reload"; }
        }

        /// <summary>Requires real host ammunition consumption and pending/completed reload presentation.</summary>
        public static bool Observe(GameController game, SelfHostedBattleClient client)
        {
            if (_failureType != null)
            {
                return false;
            }
            try
            {
                if (_weapon == null)
                {
                    Bind(game, client);
                }
                BattlePlayerState state = FindPlayer(client);
                if (IsInitiator && !_hasClickedReload && !PrepareReload(game, client, state))
                {
                    return false;
                }
                return ObserveReload(client, state);
            }
            catch (Exception failure)
            {
                // Failure types are sufficient for this gate without retaining session-bearing messages.
                _failureType = failure.GetBaseException().GetType().Name;
                return false;
            }
        }

        /// <summary>Separates diagnostic shot preparation from actual pointer/trigger input acceptance.</summary>
        public static object Capture()
        {
            return new
            {
                hasCompletedShotRequest = _shot != null && _shot.Status == TaskStatus.RanToCompletion,
                hasObservedShot = _hasObservedShot,
                shotMode = _weapon != null && _weapon.playerWeapon is PlayerZoomOnTouchWeapon
                    ? "sniper-aim-release" : "fire",
                hasClickedReload = _hasClickedReload,
                hasObservedPending = _hasObservedPending,
                hasCompleted = _hasCompleted,
                initialClip = _initialClip,
                initialReserve = _initialReserve,
                failureType = _failureType
            };
        }

        private static void Bind(GameController game, SelfHostedBattleClient client)
        {
            PlayerController player = IsInitiator ? game.mainPlayerController : game.opponent;
            _playerId = player.playerProperties.playerID;
            _weapon = player.ResolveSelfHostedInventory().currentWeapon.weapon;
            BattlePlayerState state = FindPlayer(client);
            _initialClip = state.ClipAmmo;
            _initialReserve = state.ReserveAmmo;
            if (!_weapon.reloadableWeapon || _initialClip < 2 || _initialReserve <= 0)
            {
                throw new InvalidOperationException("The selected reload fixture requires a loaded reloadable weapon.");
            }
            Publish(".bound");
        }

        private static BattlePlayerState FindPlayer(SelfHostedBattleClient client)
        {
            foreach (BattlePlayerState player in client.State.Players)
            {
                if (player.PlayerId == _playerId)
                {
                    return player;
                }
            }
            throw new InvalidOperationException("The reload participant disappeared from the host snapshot.");
        }

        private static bool PrepareReload(GameController game, SelfHostedBattleClient client, BattlePlayerState state)
        {
            if (!BothMarkersExist(".bound"))
            {
                return false;
            }
            if (_shot == null)
            {
                // The diagnostic setup uses the real adapter, without writing ammunition into either scene.
                _shot = PrepareShot(game, client);
                return false;
            }
            if (!_shot.IsCompleted)
            {
                return false;
            }
            _shot.GetAwaiter().GetResult();
            if (state.ClipAmmo != _initialClip - 1 || state.ReserveAmmo != _initialReserve || state.ReloadEndTick != 0)
            {
                return false;
            }
            UnityNormalWeaponSelectionAudit.ClickSelectedWeaponForReload();
            _hasObservedShot = true;
            _hasClickedReload = true;
            return true;
        }

        private static async Task PrepareShot(GameController game, SelfHostedBattleClient client)
        {
            Vector3 target = game.opponent.transform.position + Vector3.up * TargetHeightAboveOpponent;
            if (!(_weapon.playerWeapon is PlayerZoomOnTouchWeapon))
            {
                await client.Fire(target);
                return;
            }
            // Recovered PlayerZoomOnTouchWeapon requires aim readiness and release, never generic Fire.
            await client.SniperAim(true, false, target);
            float deadline = Time.realtimeSinceStartup + MaximumAimSeconds;
            while (!FindPlayer(client).SniperScopeVisible)
            {
                if (!client.IsConnected || Time.realtimeSinceStartup > deadline)
                {
                    throw new TimeoutException("The host did not confirm sniper aim readiness.");
                }
                await Task.Delay(AimPollMilliseconds);
            }
            await client.SniperAim(false, false, Vector3.zero);
        }

        private static bool ObserveReload(SelfHostedBattleClient client, BattlePlayerState state)
        {
            if (state.ReloadEndTick > client.State.ServerTick)
            {
                if (!_weapon.isReloading || _weapon.reloadingTimeLeft <= 0f ||
                    state.ClipAmmo != _initialClip - 1 || state.ReserveAmmo != _initialReserve)
                {
                    return false;
                }
                Publish(".pending");
                _hasObservedPending = true;
            }
            if (!_hasObservedPending || state.ReloadEndTick != 0 || _weapon.isReloading)
            {
                return false;
            }
            int expectedReserve = _initialReserve == int.MaxValue ? int.MaxValue : _initialReserve - 1;
            if (state.ClipAmmo != _initialClip || state.ReserveAmmo != expectedReserve ||
                _weapon.ammoLeftInClip != state.ClipAmmo || _weapon.ammoLeft != state.ReserveAmmo)
            {
                return false;
            }
            Publish(".complete");
            _hasCompleted = BothMarkersExist(".pending") && BothMarkersExist(".complete");
            return _hasCompleted;
        }

        private static void Publish(string suffix)
        {
            string path = MarkerPrefix + (IsInitiator ? ".self" : ".peer") + suffix;
            if (!File.Exists(path))
            {
                File.WriteAllText(path + ".writing", _playerId);
                File.Move(path + ".writing", path);
            }
        }

        private static bool BothMarkersExist(string suffix)
        {
            string first = MarkerPrefix + ".self" + suffix;
            string second = MarkerPrefix + ".peer" + suffix;
            return File.Exists(first) && File.Exists(second) &&
                File.ReadAllText(first) == _playerId && File.ReadAllText(second) == _playerId;
        }
    }
}
