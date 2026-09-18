using System;
using System.Collections;
using System.Collections.Generic;
using CodeStage.AntiCheat.ObscuredTypes;
using Google2u;
using UnityEngine;

public class GameControllerWarArena : GameControllerPVP
{
	private bool mDropCrates;

	private PlayerInventory.EquippedWeapon[] mEquippedWeapons;

	private bool mTotalMatchesInfoShown;

	private ObscuredFloat mPlayerHP;

	private ObscuredFloat mShielHP;

	private float mMatchesInfoTime;

	private CardManager.CardFilter mCardFilter;

	private SpawningType mSpawningType;

	public override string loadingWaiting => Localization.Localize("ID_STATE_SEARCHINGFOROPPONENT");

	protected override string mChoosingCardsText => Localization.Localize("ID_WAITINGFOROPPONENTCARDS");

	public override bool dropCreates => mDropCrates;

	public override CardManager.CardFilter cardsFilter => mCardFilter;

	public override SpawningType spawningType => mSpawningType;

	protected override bool shouldLooseDogtagWhenQuit => false;

	public override bool ableToQuit
	{
		get
		{
			return !mBothPlayersConnected;
		}
		set
		{
		}
	}

	public override string quitText => Localization.Localize("ID_CONFIRM_EXITINGMATCHWARARENA_TEXT");

	public override PlayerInventory.EquippedWeapon[] equippedWeapons => mEquippedWeapons;

	public override int playerLevel => (int)(float)WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.PlayerLevel).FLOATVALUE;

	public ObscuredFloat hpCoeficient { get; set; }

	public override string[] equppedVisuals
	{
		get
		{
			string[] array = base.equppedVisuals;
			if (array.Length > 3)
			{
				array[3] = "BANDS_EMPTY";
			}
			return array;
		}
	}

	public override IEnumerator StartGame()
	{
		yield return StartCoroutine(base.StartGame());
		WarArena.instance.ApplyRules();
	}

	public override void StartRandomMatchMaking(float connectDelay = 1.5f)
	{
		LoadingDialog.SetLook(smallLook: true);
		Screen.sleepTimeout = -1;
		PlayerController.players.Clear();
		StartMatch();
		Reset();
		mRandomConnectTime = Time.realtimeSinceStartup;
		GuiScreenSingle<CardSelectionScreen>.instance.ShowArenaLobby();
		Singleton<PhotonConnectionManager>.instance.ConnnectToRandomRoomWarArena(connectDelay);
	}

	public void DisableCrates()
	{
		mDropCrates = false;
	}

	public void SetShieldHP(float value)
	{
		mShielHP = value;
	}

	public void SetPlayerHP(float playerHp)
	{
		mPlayerHP = playerHp;
	}

	public void SetSpawningType(SpawningType spawningType)
	{
		mSpawningType = spawningType;
	}

	public void SetCardsFilter(CardManager.CardFilter filter)
	{
		mCardFilter = filter;
	}

	public void ResetRules()
	{
		mShielHP = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.ShieldHP).FLOATVALUE;
		mPlayerHP = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.PlayerHP).FLOATVALUE;
		hpCoeficient = 1f;
		mCardFilter = CardManager.CardFilter.All;
		mSpawningType = SpawningType.Classic;
		mDropCrates = true;
		ChangeEquippedWeapons();
	}

	public override void RestartRandomMatchMaking(bool resetRandomConnectTime = true)
	{
		LoadingDialog.SetLook(smallLook: true);
		float num = mRandomConnectTime;
		Reset();
		PlayerController.players.Clear();
		mRandomConnectTime = ((!resetRandomConnectTime) ? num : Time.realtimeSinceStartup);
		StartMatch();
		Singleton<PhotonConnectionManager>.instance.ConnnectToRandomRoomWarArena(0f);
	}

	public override void FinishGame()
	{
		if (MatchManager.isReconnect)
		{
			Disconnect();
		}
		base.FinishGame();
		Disconnect();
	}

	[PunRPC]
	protected override void FinishGameMultiplayerRPC(byte gameEndReason)
	{
		if (MatchManager.isReconnect)
		{
			Disconnect();
		}
		base.FinishGameMultiplayerRPC(gameEndReason);
		Disconnect();
	}

	public void SetOverTime(int overTime)
	{
		if (overTime <= 0)
		{
			mIsOverTime = true;
			time = -1f;
		}
		else
		{
			time = overTime;
		}
	}

	protected override void LoadLevelAndStartGame()
	{
		base.LoadLevelAndStartGame();
		WarArena.WarArenaData data = WarArena.instance.data;
		Singleton<EventTrackingManager>.instance.ArenaBattleStart(data.wins, data.lives);
	}

	protected override void Update()
	{
		if (base.isInMatch)
		{
			if ((WarArena.instance.isExpired || (WarArena.instance.warArenaConfig != null && WarArena.instance.warArenaConfig.currentWindow.remainingTimeTillWindowEnd <= 0)) && !mBothPlayersConnected && Singleton<GameController>.instance.gameState == GameController.GameState.Menu)
			{
				if (WarArena.instance.isOpened)
				{
					GuiScreenSingle<ArenaScreen>.instance.arenaMode = ArenaScreen.ArenaScreenMode.MainArena;
				}
				else
				{
					GuiScreenSingle<ArenaScreen>.instance.arenaMode = ArenaScreen.ArenaScreenMode.EnterArena;
				}
				if (GuiScreenSingle<ArenaScreen>.instance.isFullyHidden)
				{
					Quit();
					Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArenaScreen>.instance);
					Debug.LogError("Quitting WarArena - Time window ended");
				}
				if (GuiElementSingle<ConfirmDialog>.instance.isShowed)
				{
					ConfirmDialog.Hide();
				}
			}
			if (Time.realtimeSinceStartup > mRandomConnectTime + mMatchesInfoTime && mRandomConnectTime != 0f && !mBothPlayersConnected && Singleton<GameController>.instance.gameState == GameController.GameState.Menu && !mTotalMatchesInfoShown && !GuiElementSingle<ConfirmDialog>.instance.isShowed)
			{
				mTotalMatchesInfoShown = true;
				int totalMatchesInRegions = PhotonConnectionManager.totalMatchesInRegions;
				ObscuredFloat fLOATVALUE = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.LowMatches).FLOATVALUE;
				ConfirmDialog.ShowAlert(delegate
				{
					mTotalMatchesInfoShown = false;
					mMatchesInfoTime = float.PositiveInfinity;
				}, Localization.Localize("ID_CONFIRM_LOWACTIVITY_TITLE"), Localization.LocalizeFormat((!((float)totalMatchesInRegions < (float)fLOATVALUE)) ? "ID_CONFIRM_LOWACTIVITYTHEREARE" : "ID_CONFIRM_LOWACTIVITYINREGION", totalMatchesInRegions * 2));
			}
		}
		if (mBothPlayersConnected && mTotalMatchesInfoShown && GuiElementSingle<ConfirmDialog>.instance != null && GuiElementSingle<ConfirmDialog>.instance.isFullyShowed)
		{
			GuiElementSingle<ConfirmDialog>.instance.HideDialog();
			mTotalMatchesInfoShown = false;
			mMatchesInfoTime = float.PositiveInfinity;
		}
		if (Time.realtimeSinceStartup > MatchManager.matchStartTime && mBothPlayersConnected && !mCardsChoosen && PhotonNetwork.inRoom)
		{
			FinishChoosingCards();
		}
		if (gameIsRunning && !TimeManager.instance.mIsFreezed)
		{
			time -= Time.deltaTime;
			time = Mathf.Clamp(time, -1f, float.MaxValue);
		}
		if (time <= 0f && gameIsRunning && !Singleton<PhotonConnectionManager>.instance.isClient && !mIsOverTime)
		{
			mIsOverTime = true;
			Singleton<MatchManager>.instance.StartOverTime(base.mMainPlayerController, GameControllerOnline.mOtherPlayerInstance);
		}
		base.Update();
	}

	protected override void StartMatch()
	{
		base.StartMatch();
		Singleton<GameController>.instance.opponent = null;
		mMinimizedInLobby = false;
	}

	protected override void Reset()
	{
		base.Reset();
		mMatchesInfoTime = WarArena.instance.warArenaParameters.GetRow(WarArenaParameters.rowIds.ShowMatchesInfo).FLOATVALUE;
		mRandomConnectTime = 0f;
		mTotalMatchesInfoShown = false;
	}

	public override void Rematch()
	{
		LoadingDialog.SetLook(smallLook: true);
		StartRandomMatchMaking();
	}

	public override void Quit()
	{
		if (MatchManager.beforeMatch && mBothPlayersConnected)
		{
			WarArena.instance.TakePlayerLive();
		}
		base.Quit();
	}

	public override UpgradeSlots.UnitUpgrades PickUpgradesForUnit(bool isPreview, AIObject o)
	{
		LevelBehaviour behaviour = o.behaviour;
		UpgradeSlots.UnitUpgrades result = base.PickUpgradesForUnit(isPreview, o);
		result.scaleHp = hpCoeficient;
		behaviour.behaviourDefinition.ScaleDamageAndHP(result.scaleDamage, result.scaleHp);
		return result;
	}

	public override List<UnitUpgradeDefinition> GetUnitsUpgrades()
	{
		List<LevelBehaviour> behaviours = LevelManager.instance.behaviours;
		List<UnitUpgradeDefinition> list = new List<UnitUpgradeDefinition>();
		foreach (LevelBehaviour item in behaviours)
		{
			UpgradeSlots.UnitUpgrades upgradeIndex = item.upgradeSlots.LoadDataForWarArena(item);
			list.Add(new UnitUpgradeDefinition(item.upgradeSlots.canUseInBattle, upgradeIndex, item.upgradeSlots.isNew, item.upgradeSlots.actualTier));
		}
		return list;
	}

	private void ChangeEquippedWeapons()
	{
		PlayerInventory.EquippedWeapon[] array = PlayerInventory.instance.equippedWeapons;
		List<PlayerInventory.InventorySlot> inventorySlots = PlayerInventory.instance.inventorySlots;
		for (int i = 0; i < inventorySlots.Count; i++)
		{
			PlayerInventory.InventorySlot inventorySlot = inventorySlots[i];
			if (inventorySlot.weaponLevelsSetup != null)
			{
				array[i].weaponUpgrade = inventorySlot.weaponLevelsSetup.upgradeSlots.warArenaUpgrade;
			}
		}
		mEquippedWeapons = array;
	}

	public override float GetPlayerHP(PlayerController playerController)
	{
		return mPlayerHP;
	}

	public override float GetShieldHP(PlayerController playerController)
	{
		return mShielHP;
	}

	protected void OnJoinedNewRoom()
	{
		float num = Time.realtimeSinceStartup - mRandomConnectTime;
		Debug.Log($"WarArena matchmaking took {num}");
	}

	public override void ShowResultsScreen()
	{
		GuiScreenSingle<ArenaScreen>.instance.arenaMode = ArenaScreen.ArenaScreenMode.EndArena;
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArenaScreen>.instance);
	}

	protected override void OnConnectionFail(DisconnectCause cause)
	{
		Debug.LogError("OnConnectionFailed: " + cause);
		Debug.LogError(DebugSettings.GetNetworkStatsText());
		CheckIf(cause);
		if (mBothPlayersConnected && HasAllPlayersStateAtLeast(PlayerNetworkStatus.MatchState.CardsChosen))
		{
			ReconnectInGame();
			return;
		}
		Debug.LogError("OnConnectionFailed: restarting");
		MatchManager.matchState = MatchState.ConnectingToPhoton;
		LoadingDialog.Hide();
		InvokeAfter(delegate
		{
			RestartRandomMatchMaking(resetRandomConnectTime: false);
		}, 1f);
	}

	protected override void PlayerDistonnectedBeforeAfterMatch(PhotonPlayer otherPlayer)
	{
		PlayerDisconnectedInLobby();
	}

	protected override void OnPhotonJoinRoomFailed(object[] codeAndMsg)
	{
		Debug.LogError($"OnPhotonJoinRoomFailed: {codeAndMsg[0]}, message {codeAndMsg[1]}");
		if (MatchManager.isReconnect)
		{
			JoinRoomFailedAfterReconnect(Convert.ToInt32(codeAndMsg[0]));
		}
		else
		{
			RestartRandomMatchMaking();
		}
	}
}
