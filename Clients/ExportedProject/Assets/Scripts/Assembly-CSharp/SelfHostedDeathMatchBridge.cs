using System;
using System.Threading.Tasks;
using UnityEngine;
using War.Client;
using War.Protocol;

public sealed class SelfHostedDeathMatchBridge : MonoBehaviour
{
	private SelfHostedBattleClient client;
	private PlayerController local;
	private PlayerController other;
	private SoldierAnimationController localAnimator;
	private SoldierAnimationController otherAnimator;
	private bool commandPending;
	private bool terminalPresented;
	private float nextFireIntent;
	private bool minigunInputHeld;
	private bool sniperInputHeld;
	private bool bazookaInputHeld;
	private bool bazookaTargetVisible;
	private bool sniperScopeVisible;
	private SniperScope sniperScope;
	private HudScreen hud;
	private bool localMinigunMotor;
	private bool otherMinigunMotor;
	private float grenadeSwipeStartedAt;
	private SelfHostedProjectilePresenter projectilePresenter;
	private SelfHostedDecoyPresenter decoyPresenter;
	private SelfHostedLandMinePresenter landMinePresenter;
	private SelfHostedHeavyTurretPresenter heavyTurretPresenter;

	public void Configure(SelfHostedBattleClient owner, PlayerController localPlayer, PlayerController otherPlayer)
	{
		if (client != null || owner == null || localPlayer == null || otherPlayer == null || owner.PlayerViews == null || owner.PlayerViews.Count != 2)
			throw new InvalidOperationException("A complete self-hosted DeathMatch scene is required.");
		client = owner; local = localPlayer; other = otherPlayer;
		localAnimator = local.ResolveSelfHostedAnimator();
		otherAnimator = other.ResolveSelfHostedAnimator();
		sniperScope = UnityEngine.Object.FindObjectOfType<SniperScope>();
		hud = UnityEngine.Object.FindObjectOfType<HudScreen>();
		if (localAnimator == null || otherAnimator == null)
			throw new InvalidOperationException("Both self-hosted DeathMatch players require an animation controller.");
		local.enabled = false; other.enabled = false;
		localAnimator.enabled = false; otherAnimator.enabled = false;
		client.BindRifleView(local.playerProperties.playerID, local.transform, localAnimator);
		client.BindRifleView(other.playerProperties.playerID, other.transform, otherAnimator);
		projectilePresenter = gameObject.AddComponent<SelfHostedProjectilePresenter>();
		projectilePresenter.Configure(local, other);
		decoyPresenter = gameObject.AddComponent<SelfHostedDecoyPresenter>();
		decoyPresenter.Configure(client.LocalPlayerId);
		MineAmmo mineVisual = local.weaponInventory == null || local.weaponInventory.landMine == null ? null :
			local.weaponInventory.landMine.bulletPrefab as MineAmmo;
		landMinePresenter = gameObject.AddComponent<SelfHostedLandMinePresenter>();
		landMinePresenter.Configure(mineVisual);
		heavyTurretPresenter = gameObject.AddComponent<SelfHostedHeavyTurretPresenter>();
		heavyTurretPresenter.Configure(Singleton<ObjectPoolDatabase>.instance == null ? null : Singleton<ObjectPoolDatabase>.instance.heavyTurret);
		client.StateReceived += Apply;
		client.CombatEventReceived += ApplyEvent;
		if (client.State != null) Apply(client.State);
	}

	private void Update()
	{
		if (client == null || !client.IsConnected || commandPending || terminalPresented ||
			!Singleton<GameController>.instance.gameIsRunning || TimeManager.instance.mIsFreezed) return;
		InputController input = UnityEngine.Object.FindObjectOfType<InputController>();
		if (input == null) return;
		BattlePlayerState localState = null;
		if (client.State != null)
			foreach (BattlePlayerState state in client.State.Players)
				if (state.PlayerId == client.LocalPlayerId) { localState = state; break; }
		if (localState != null && localState.ClipAmmo == 0 && localState.ReserveAmmo > 0 && localState.ReloadEndTick == 0)
		{
			Run(client.Reload());
			return;
		}
		PlayerWeapon currentWeapon = local.weaponInventory == null ? null : local.weaponInventory.currentWeapon;
		if (currentWeapon is PlayerZoomOnTouchWeapon)
		{
			if (!input.isTapping && sniperInputHeld)
			{
				sniperInputHeld = false;
				Run(client.SniperAim(false, input.swipeEnded, Vector3.zero));
				return;
			}
			if (input.isTappingStarted || input.isTapping && Time.unscaledTime >= nextFireIntent)
			{
				nextFireIntent = Time.unscaledTime + 0.1f;
				Vector3 target = Singleton<AimingHelper>.instance.Aim(currentWeapon.weapon);
				sniperInputHeld = true;
				Run(client.SniperAim(true, false, target));
			}
			return;
		}
		if (sniperInputHeld)
		{
			sniperInputHeld = false;
			Run(client.SniperAim(false, true, Vector3.zero));
			return;
		}
		PlayerHoldWeapon bazooka = currentWeapon as PlayerHoldWeapon;
		if (bazooka != null)
		{
			if (!input.isTapping && bazookaInputHeld)
			{
				bazookaInputHeld = false;
				Run(client.BazookaHold(false, Vector3.zero));
				return;
			}
			if (input.isTappingStarted || input.isTapping && Time.unscaledTime >= nextFireIntent)
			{
				nextFireIntent = Time.unscaledTime + 0.1f;
				Vector3 target = Singleton<AimingHelper>.instance.Aim(bazooka.weapon);
				bazookaInputHeld = true;
				Run(client.BazookaHold(true, target));
			}
			return;
		}
		if (bazookaInputHeld)
		{
			bazookaInputHeld = false;
			Run(client.BazookaHold(false, Vector3.zero));
			return;
		}
		PlayerSwipeWeapon swipeGrenade = currentWeapon as PlayerSwipeWeapon;
		if (swipeGrenade != null)
		{
			if (input.rawSwipeInput.swipeStarted) grenadeSwipeStartedAt = Time.realtimeSinceStartup;
			if (input.rawSwipeInput.swipeDone)
			{
				Vector2 screenDelta = input.rawSwipeInput.swipeEnd - input.rawSwipeInput.swipeStart;
				if (screenDelta.magnitude > (float)Screen.width * 0.05f && Vector3.Angle(screenDelta, Vector3.up) <= 70f)
				{
					Vector3 start, end;
					if (TryGrenadeWorldSwipe(input.rawSwipeInput.swipeStart, input.rawSwipeInput.swipeEnd, swipeGrenade.maxDistance, out start, out end))
						Run(client.GrenadeSwipeThrow(start, end, Time.realtimeSinceStartup - grenadeSwipeStartedAt));
				}
			}
			return;
		}
		if (input.swipeEnded)
		{
			Vector3 delta = input.swipePosition - input.pressPosition;
			if (delta.magnitude > (float)Screen.width * 0.05f && Vector3.Angle(delta, Vector3.up) > 70f)
			{
				Run(client.MoveCover(delta.x > 0f ? 1 : -1));
				return;
			}
		}
		if (local.weaponInventory != null && local.weaponInventory.currentWeapon != null &&
			local.weaponInventory.currentWeapon is PlayerMinigunWeapon)
		{
			if (!input.isTapping && minigunInputHeld)
			{
				minigunInputHeld = false;
				Run(client.MinigunHold(false, Vector3.zero));
				return;
			}
			if ((input.isTappingStarted || input.isTapping && Time.unscaledTime >= nextFireIntent))
			{
				nextFireIntent = Time.unscaledTime + 0.1f;
				Vector3 target = Singleton<AimingHelper>.instance.Aim(local.weaponInventory.currentWeapon.weapon);
				minigunInputHeld = true;
				Run(client.MinigunHold(true, target));
			}
			return;
		}
		if (minigunInputHeld)
		{
			minigunInputHeld = false;
			Run(client.MinigunHold(false, Vector3.zero));
			return;
		}
		if ((input.isTappingStarted || input.isTapping && Time.unscaledTime >= nextFireIntent) &&
			local.weaponInventory != null && local.weaponInventory.currentWeapon != null)
		{
			nextFireIntent = Time.unscaledTime + 0.1f;
			Vector3 target = Singleton<AimingHelper>.instance.Aim(local.weaponInventory.currentWeapon.weapon);
			if (local.weaponInventory.currentWeapon.weapon.weaponType == Weapon.WeaponType.GrenadeLauncher)
				Run(client.GrenadeLauncherThrow(target));
			else Run(client.Fire(target));
		}
	}

	private bool TryGrenadeWorldSwipe(Vector2 screenStart, Vector2 screenEnd, float maxDistance, out Vector3 start, out Vector3 end)
	{
		start = end = Vector3.zero;
		if (local == null || local.currentPlayerPoint == null || local.currentPlayerPoint.point == null || Singleton<GameCamera>.instance == null || Singleton<GameCamera>.instance.camera == null) return false;
		Plane plane = new Plane(Vector3.up, local.currentPlayerPoint.point.transform.position);
		Ray first = Singleton<GameCamera>.instance.camera.ScreenPointToRay(screenStart);
		Ray second = Singleton<GameCamera>.instance.camera.ScreenPointToRay(screenEnd);
		float firstDistance, secondDistance;
		if (!plane.Raycast(first, out firstDistance)) return false;
		start = first.GetPoint(firstDistance);
		if (plane.Raycast(second, out secondDistance)) { end = second.GetPoint(secondDistance); return true; }
		Vector2 screenDirection = (screenEnd - screenStart).normalized;
		Ray fallback = Singleton<GameCamera>.instance.camera.ScreenPointToRay(screenStart + screenDirection);
		float fallbackDistance;
		if (!plane.Raycast(fallback, out fallbackDistance)) return false;
		end = start + (fallback.GetPoint(fallbackDistance) - start).normalized * maxDistance;
		return true;
	}

	private async void Run(Task operation)
	{
		commandPending = true;
		try { await operation; }
		catch (Exception exception)
		{
			Debug.LogError("Self-hosted battle intent failed: " + exception.GetType().Name);
			MatchManager.matchState = MatchState.GameCancelled;
		}
		finally { commandPending = false; }
	}

	private void Apply(MatchSnapshot snapshot)
	{
		if (snapshot == null || client == null) return;
		foreach (BattlePlayerState state in snapshot.Players)
		{
			PlayerController player = state.PlayerId == local.playerProperties.playerID ? local :
				(state.PlayerId == other.playerProperties.playerID ? other : null);
			if (player != null)
			{
				int selected = -1;
				foreach (BattlePlayerView view in client.PlayerViews)
					if (view.PlayerId == state.PlayerId)
						for (int i = 0; i < view.Weapons.Count; i++)
							if (view.Weapons[i].Slot == state.ActiveWeaponSlot) { selected = i; break; }
				if (selected < 0) throw new InvalidOperationException("Authoritative weapon slot is absent from the player view.");
				player.ApplySelfHostedSnapshot(state, selected);
				if (player == local) ApplyMinigunMotor(player, state.MinigunHeld, ref localMinigunMotor);
				else ApplyMinigunMotor(player, state.MinigunHeld, ref otherMinigunMotor);
				if (player == local) ApplySniperScope(state.SniperScopeVisible);
				if (player == local) ApplyBazookaTarget(state.BazookaTargeting);
			}
		}
		if (projectilePresenter != null) projectilePresenter.Apply(snapshot);
		if (decoyPresenter != null) decoyPresenter.Apply(snapshot);
		if (landMinePresenter != null) landMinePresenter.Apply(snapshot);
		if (heavyTurretPresenter != null) heavyTurretPresenter.Apply(snapshot);
		if (!terminalPresented && snapshot.Phase == BattlePhase.Ended)
		{
			ClientGameEndReason reason = MatchOutcomeProjection.ForPlayer(snapshot, client.LocalPlayerId);
			if (reason != ClientGameEndReason.None)
			{
				terminalPresented = true;
				Singleton<GameController>.instance.gameEndReason = (GameController.GameEndReason)(byte)reason;
				Singleton<GameController>.instance.mainController.FinishGame();
			}
		}
	}

	private void ApplyEvent(MatchEvent item)
	{
		if (projectilePresenter != null) projectilePresenter.ApplyEvent(item);
		if (decoyPresenter != null) decoyPresenter.ApplyEvent(item);
		if (landMinePresenter != null) landMinePresenter.ApplyEvent(item);
		if (heavyTurretPresenter != null) heavyTurretPresenter.ApplyEvent(item);
	}

	private void ApplyBazookaTarget(bool visible)
	{
		if (visible == bazookaTargetVisible) return;
		bazookaTargetVisible = visible;
		if (hud == null) return;
		if (visible)
		{
			PlayerHoldWeapon bazooka = local == null || local.weaponInventory == null ? null :
				local.weaponInventory.currentWeapon as PlayerHoldWeapon;
			if (bazooka != null) hud.StartBazzokaTargettingAnimation(bazooka.holdTime);
		}
		else hud.StopBazzokaAnimation();
	}

	private void ApplySniperScope(bool visible)
	{
		if (visible == sniperScopeVisible) return;
		sniperScopeVisible = visible;
		if (sniperScope == null) return;
		if (!visible) { sniperScope.Hide(); return; }
		var sniper = local == null || local.weaponInventory == null ? null : local.weaponInventory.currentWeapon as PlayerZoomOnTouchWeapon;
		if (sniper == null) return;
		sniperScope.SetScope(sniper.scopeNum);
		if (sniperScope.touchCamera != null) sniperScope.touchCamera.fieldOfView = 9f;
		sniperScope.Show();
	}

	private static void ApplyMinigunMotor(PlayerController player, bool held, ref bool prior)
	{
		if (held == prior) return;
		prior = held;
		if (player == null) return;
		var minigun = player.weaponInventory == null ? null : player.weaponInventory.currentWeapon as PlayerMinigunWeapon;
		if (minigun == null || minigun.motor == null) return;
		if (held) minigun.motor.StartMotor(); else minigun.motor.StopMotor();
	}

	private void OnDestroy()
	{
		if (client == null) return;
		if (localMinigunMotor) ApplyMinigunMotor(local, false, ref localMinigunMotor);
		if (otherMinigunMotor) ApplyMinigunMotor(other, false, ref otherMinigunMotor);
		if (sniperScopeVisible) ApplySniperScope(false);
		if (bazookaTargetVisible) ApplyBazookaTarget(false);
		client.StateReceived -= Apply;
		client.CombatEventReceived -= ApplyEvent;
		if (local != null && local.playerProperties != null) client.UnbindRifleView(local.playerProperties.playerID);
		if (other != null && other.playerProperties != null) client.UnbindRifleView(other.playerProperties.playerID);
	}
}
