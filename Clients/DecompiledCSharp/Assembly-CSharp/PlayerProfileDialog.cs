using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProfileDialog : GuiElementSingle<PlayerProfileDialog>, IGuiDialog
{
	public class EquippedUnit
	{
		public LevelBehaviour behaviour;

		public int tier;
	}

	public Dictionary<LevelBehaviour.UnitType, int> sortingOrder = new Dictionary<LevelBehaviour.UnitType, int>
	{
		{
			LevelBehaviour.UnitType.Defender,
			0
		},
		{
			LevelBehaviour.UnitType.AttackerRusher,
			1
		},
		{
			LevelBehaviour.UnitType.AttackerShooter,
			2
		},
		{
			LevelBehaviour.UnitType.AttackerExplosive,
			3
		}
	};

	public UIPanel dialogPanel;

	[Header("Close")]
	public GameObject closeButton;

	[Header("Header")]
	public UISprite vipPlayer;

	public UITable headerTable;

	public GameObject playerRankPart;

	public UITexture playerRankIcon;

	public UILabel playerRank;

	public GameObject rightPositionOfName;

	public UILabel playerNameLabel;

	public UISprite playerCrownIcon;

	public UISprite playerCountryIcon;

	public UISprite playerOnlineStatusIcon;

	public UILabel playerOnlineStatusLabel;

	public GameObject bannedPart;

	[Header("Middle")]
	public GameObject loadingPart;

	public GameObject statsPart;

	[Header("-Medals")]
	public UILabel playerMedals;

	public UILabel playerBestMedals;

	[Header("-League")]
	public UISprite playerLeagueIcon;

	public UILabel playerLeagueName;

	[Header("-Army Power")]
	public UILabel playerArmyPower;

	[Header("-Win Lose Ratio")]
	public UILabel playerWinLoseRatio;

	public UILabel playerWonLostMatches;

	[Header("-Icon")]
	public PlayerIcon playerVisual;

	[Header("-Not In Squad")]
	public GameObject notInSquadPart;

	public GameObject inviteToSquad;

	[Header("-In Squad")]
	public GameObject inSquadPart;

	public UITexture squadIcon;

	public UILabel squadNameLabel;

	public BoxCollider squadNameCollider;

	public UILabel squadPointsLabel;

	public UILabel reputationPointsLabel;

	[Header("-Army")]
	public PlayerProfileArmyRecord armyIconPrefab;

	public UIGrid armyGrid;

	[Header("-Primary Weapon")]
	public GameObject primaryWeaponPart;

	public UISprite primaryWeaponIcon;

	public UILabel primaryWeaponLevel;

	public UILabel primaryWeaponName;

	[Header("-Special Weapon")]
	public GameObject specialWeaponPart;

	public UISprite specialWeaponIcon;

	public UILabel specialWeaponLevel;

	public UILabel specialWeaponName;

	[Header("-Explosive Weapon")]
	public GameObject explosiveWeaponPart;

	public UISprite explosiveWeaponIcon;

	public UILabel explosiveWeaponLevel;

	public UILabel explosiveWeaponName;

	[Header("-Favourite Unit")]
	public GameObject favouriteUnitPart;

	public UISprite favouriteUnitIcon;

	public UILabel favouriteUnitLevel;

	public UILabel favouriteUnitName;

	public UISprite[] favouriteUnitTiers;

	[Header("-Favourite Warcard")]
	public GameObject favouriteCardPart;

	public UISprite favouriteCardIcon;

	public UISprite favouriteCardBonusIcon;

	public UILabel favouriteCardBonusName;

	public UISprite favouriteCardBackground;

	public UILabel favouriteCardName;

	public UILabel favouriteCardNA;

	private string mPlayerId;

	private string mPlayerName;

	private bool mIsBot;

	private DatabasePlayerInfo mPlayer;

	private bool mTurnOffDragBackground;

	private PlayerProfileArmyRecord[] mArmyIcons;

	private bool mOpenSquadDetails;

	private bool mPreviousPanelDisabled;

	private int mTestIndexUnit;

	private int mTestIndexWeapon;

	private int mTestIndexCard;

	public void ShowDialog(string playerName, string playerId, bool turnOffDragBackground = true)
	{
		Debug.Log($"Player profile - Show dialog for PLAYER: {playerName} with id: {playerId}");
		mPlayerName = playerName;
		mPlayerId = playerId;
		mPlayer = null;
		mTurnOffDragBackground = turnOffDragBackground;
		mIsBot = false;
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public void ShowDialogFromCache(DatabasePlayerInfo playerInfo, bool turnOffDragBackground = true, bool isBot = false)
	{
		Debug.Log(string.Format("Player profile - Show dialog for {0} from CACHE: {1}", (!isBot) ? "PLAYER" : "BOT", playerInfo.name));
		mPlayerName = playerInfo.name;
		mPlayerId = playerInfo.id;
		mPlayer = playerInfo;
		mTurnOffDragBackground = turnOffDragBackground;
		mIsBot = isBot;
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public void ShowBotDialog(string playerName, DatabasePlayerInfo botInfo)
	{
		Debug.Log($"Player profile - Show dialog for BOT: {playerName}");
		mPlayerName = playerName;
		mPlayerId = string.Empty;
		mPlayer = botInfo;
		mTurnOffDragBackground = true;
		mIsBot = true;
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(closeButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener2 = UIEventListener.Get(overlayBackground.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener3 = UIEventListener.Get(inviteToSquad);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(InviteToSquad));
		UIEventListener uIEventListener4 = UIEventListener.Get(squadNameCollider.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(SquadNameClicked));
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataLoaded;
		headerTable.onReposition = delegate
		{
			Transform transform = rightPositionOfName.transform;
			if (playerCountryIcon.gameObject.activeSelf)
			{
				transform = playerCountryIcon.transform;
			}
			else if (playerCrownIcon.gameObject.active)
			{
				transform = playerCrownIcon.transform;
			}
			float val = 0f - headerTable.padding.x - (transform.localPosition.x - headerTable.padding.x) / 2f;
			headerTable.transform.localPosition = headerTable.transform.localPosition.ReplaceX(val);
		};
		CreateArmyIcons();
	}

	private void CloseDialog(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void InviteToSquad(GameObject go)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		DatabaseSquad squad = Singleton<ServerResultsCache>.instance.GetSquad(GameLoginManager.currentPlayer.squadName, ommitTime: true);
		bool flag = GameLoginManager.currentPlayer.squadRank == SquadRank.Member;
		if (!squad.isPublic && flag)
		{
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_CANTSENDINVITE_TEXT"), Localization.Localize("ID_WARNING_CANTSENDINVITE"), 0f, null, string.Empty);
			return;
		}
		if (squad != null && squad.GetPlacesLeft() <= 0)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<IncreaseSquadRankDialog>.instance, 0f);
			return;
		}
		if (!mIsBot)
		{
			Singleton<BeanstalkServerManager>.instance.InvitePlayerToSquad(mPlayer);
		}
		inviteToSquad.SetActive(value: false);
	}

	private IEnumerator FakeInviteToSquad()
	{
		WaitingDialog.ShowDialog("ID_SENDINGINVITE");
		float waitFor = UnityEngine.Random.Range(1.2f, 3f);
		yield return new WaitForRealSeconds(waitFor);
		WaitingDialog.Hide();
	}

	private void SquadNameClicked(GameObject go)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		HideDialog();
		mOpenSquadDetails = true;
		TweenColor tweenColor = TweenColor.Begin(squadNameLabel.gameObject, 0.2f, Color.white, Colours.blue);
		tweenColor.NumOfRepetitions = 2;
		tweenColor.style = UITweener.Style.PingPong;
	}

	private void OnDataLoaded(DatabaseAction action)
	{
		if (isShowed)
		{
			if (action == DatabaseAction.GetPlayerInfo)
			{
				ShowPlayerInfo(Singleton<ServerResultsCache>.instance.GetPlayer(mPlayerId));
			}
		}
	}

	private void CreateArmyIcons()
	{
		mArmyIcons = new PlayerProfileArmyRecord[8];
		mArmyIcons[0] = armyIconPrefab;
		for (int i = 0; i < 7; i++)
		{
			PlayerProfileArmyRecord playerProfileArmyRecord = UnityEngine.Object.Instantiate(armyIconPrefab);
			playerProfileArmyRecord.transform.parent = armyGrid.transform;
			playerProfileArmyRecord.transform.localScale = armyIconPrefab.transform.localScale;
			playerProfileArmyRecord.transform.localPosition = armyIconPrefab.transform.localPosition;
			playerProfileArmyRecord.name = $"Unit Icon {i + 1}";
			playerProfileArmyRecord.InitializeUnit(null);
			mArmyIcons[i + 1] = playerProfileArmyRecord;
		}
		armyIconPrefab.InitializeUnit(null);
		armyGrid.repositionNow = true;
	}

	public override void InitGUIValues()
	{
		mOpenSquadDetails = false;
		vipPlayer.gameObject.SetActive(value: false);
		bannedPart.SetActive(value: false);
		ShowLoading(active: true);
		SetPlayerName(mPlayerName);
		headerTable.repositionNow = true;
		if (mPlayer != null)
		{
			ShowPlayerInfo(mPlayer);
		}
		else if (string.IsNullOrEmpty(mPlayerId))
		{
			Debug.LogError("Player profile - Null or empty player id in player profile dialog.");
		}
		else
		{
			Singleton<BeanstalkServerManager>.instance.GetPlayerInfo(mPlayerId);
		}
	}

	private void ShowPlayerInfo(DatabasePlayerInfo player)
	{
		if (player == null)
		{
			Debug.LogError($"Player profile - Null player for id: \"{mPlayerId}\" and name: {mPlayerName}");
			return;
		}
		mPlayer = player;
		ShowLoading(active: false);
		FillHeader();
		FillStatistics();
		playerVisual.Reset();
		playerVisual.gameObject.SetActive(value: false);
		StartCoroutine(CreatePlayerTexture());
		FillSquadStatistics();
		FillArmyStatistics();
		FillEquippedWeapons();
		FillFavouriteItems();
		if (player != null)
		{
			Singleton<ServerResultsCache>.instance.UpdatePlayer(player);
		}
	}

	private void ShowLoading(bool active)
	{
		loadingPart.SetActive(active);
		statsPart.SetActive(!active);
		playerRankPart.SetActive(!active);
		playerCrownIcon.gameObject.SetActive(!active);
		playerCountryIcon.gameObject.SetActive(!active);
		playerOnlineStatusIcon.gameObject.SetActive(!active);
		playerOnlineStatusLabel.gameObject.SetActive(!active);
	}

	private void FillHeader()
	{
		int num = ((mPlayer != null) ? mPlayer.vipExpiration : 0);
		bool flag = num > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		int level = ((mPlayer != null) ? mPlayer.level : 2);
		string playerName = ((mPlayer != null && !string.IsNullOrEmpty(mPlayer.name)) ? mPlayer.name : mPlayerName);
		string cc = ((mPlayer != null && !string.IsNullOrEmpty(mPlayer.country)) ? mPlayer.country : string.Empty);
		PlayerStatus key = ((mPlayer != null) ? mPlayer.GetRealStatus() : PlayerStatus.Offline);
		bool flag2 = mPlayer != null && mPlayer.isBanned;
		WarArenaCrown warArenaCrown = ((mPlayer != null) ? mPlayer.warArenaCrown : WarArenaCrown.None);
		bool flag3 = warArenaCrown != WarArenaCrown.None;
		Debug.Log(string.Format("Player profile - {0} is banned {1}", (!string.IsNullOrEmpty(mPlayerId)) ? mPlayerId : "bot", flag2));
		vipPlayer.gameObject.SetActive(flag && !flag2);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(level);
		playerRankIcon.mainTexture = Resources.Load<Texture>("Ranks/" + levelDefinition.iconName);
		playerRank.text = levelDefinition.displayString;
		playerCrownIcon.gameObject.SetActive(flag3);
		if (flag3)
		{
			playerCrownIcon.spriteName = GameVariables.crownSprites[warArenaCrown];
			playerCrownIcon.MakePixelPerfect();
			float multiplier = Mathf.Min(60f / playerCrownIcon.transform.localScale.x, 60f / playerCrownIcon.transform.localScale.y);
			playerCrownIcon.transform.localScale = playerCrownIcon.transform.localScale.MultiplyXY(multiplier);
		}
		string text = GameVariables.CountryCodeSpriteName(cc);
		bool flag4 = !string.IsNullOrEmpty(text);
		playerCountryIcon.gameObject.SetActive(flag4);
		if (flag4)
		{
			playerCountryIcon.spriteName = text;
			playerCountryIcon.MakePixelPerfect();
		}
		bannedPart.SetActive(flag2);
		playerOnlineStatusIcon.gameObject.SetActive(!flag2);
		playerOnlineStatusLabel.gameObject.SetActive(!flag2);
		if (!flag2)
		{
			playerOnlineStatusLabel.text = Localization.Localize(GameVariables.playerStatus[key].Value1);
			playerOnlineStatusLabel.color = GameVariables.playerStatus[key].Value2;
			playerOnlineStatusIcon.color = GameVariables.playerStatus[key].Value2;
		}
		SetPlayerName(playerName);
		headerTable.repositionNow = true;
	}

	private void FillStatistics()
	{
		int num = ((mPlayer != null) ? mPlayer.skill : 500);
		int num2 = ((mPlayer != null && mPlayer.statisticsData != null) ? mPlayer.statisticsData.maxMedals : Mathf.Max(500, num));
		int num3 = ((mPlayer != null) ? mPlayer.statisticsData.mmmGames : 0);
		bool flag = mPlayer == null || !mPlayer.isInLeague;
		bool flag2 = mPlayer != null && mPlayer.isInBeginnersLeague;
		int beginnersNumber = ((mPlayer != null) ? mPlayer.beginnersLeague : 0);
		League key = ((mPlayer != null) ? mPlayer.leagueTier : League.Bronze1);
		int num4 = ((mPlayer != null) ? mPlayer.armyPowerX10 : 0);
		float num5 = ((mPlayer != null && mPlayer.statisticsData != null) ? mPlayer.statisticsData.winLoseRatio : 0f);
		int num6 = ((mPlayer != null && mPlayer.statisticsData != null) ? mPlayer.statisticsData.battlesWonRanked : 0);
		int num7 = ((mPlayer != null && mPlayer.statisticsData != null) ? mPlayer.statisticsData.battlesLostRanked : 0);
		playerMedals.text = MiscTools.FormatBigNumber(num);
		playerBestMedals.text = MiscTools.FormatBigNumber(num2);
		if (num3 < 1)
		{
			playerLeagueIcon.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(1);
			playerLeagueIcon.MakePixelPerfect();
			playerLeagueIcon.alpha = 0.2f;
			playerLeagueName.text = Singleton<GameVariables>.instance.BeginnersLeagueName(1);
		}
		else if (flag2)
		{
			playerLeagueIcon.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(beginnersNumber);
			playerLeagueIcon.MakePixelPerfect();
			playerLeagueIcon.alpha = 1f;
			playerLeagueName.text = Singleton<GameVariables>.instance.BeginnersLeagueName(beginnersNumber);
		}
		else
		{
			playerLeagueIcon.spriteName = GameVariables.leagueNames[key].Value2;
			playerLeagueIcon.MakePixelPerfect();
			playerLeagueIcon.alpha = ((!flag) ? 1f : 0.2f);
			playerLeagueName.text = ((!flag) ? GameVariables.leagueNames[key].Value1 : Localization.Localize("ID_NA"));
		}
		playerArmyPower.text = MiscTools.FormatBigNumber(num4);
		playerWinLoseRatio.text = ((!(num5 < 0f)) ? MiscTools.FormatFloatNumberRoundOne(num5) : Localization.Localize("ID_NA"));
		playerWonLostMatches.text = $"{num6} {Colours.stringGray}/{Colours.stringRedLostMatches} {num7}";
		MiscTools.SetUILabelRescale(playerWonLostMatches, 47f, 25f, 280);
	}

	private void FillSquadStatistics()
	{
		string text = ((mPlayer != null) ? mPlayer.squadName : string.Empty);
		bool flag = !string.IsNullOrEmpty(text);
		inSquadPart.SetActive(flag);
		notInSquadPart.SetActive(!flag);
		if (flag)
		{
			squadNameLabel.text = text;
			TweenColor.Begin(squadNameLabel.gameObject, 0f, Color.white);
			MiscTools.SetUILabelRescale(squadNameLabel, 37f, 17f, 260);
			squadIcon.mainTexture = Resources.Load<Texture>("SquadIcons/" + mPlayer.squadEmblem);
			squadPointsLabel.text = MiscTools.FormatBigNumber(mPlayer.squadPoints);
			reputationPointsLabel.text = MiscTools.FormatBigNumber(mPlayer.reputation);
			return;
		}
		bool flag2 = !string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName);
		if (flag2)
		{
			DatabaseSquad squad = Singleton<ServerResultsCache>.instance.GetSquad(GameLoginManager.currentPlayer.squadName, ommitTime: true);
			bool flag3 = GameLoginManager.currentPlayer.squadRank == SquadRank.Member;
			flag2 = squad.isPublic || !flag3;
		}
		inviteToSquad.SetActive(flag2);
	}

	private void FillArmyStatistics()
	{
		List<EquippedUnit> list = new List<EquippedUnit>();
		Dictionary<string, LevelManager.SavedArmySlots> dictionary = ((mPlayer != null && mPlayer.equippedUnits != null) ? mPlayer.equippedUnits : new Dictionary<string, LevelManager.SavedArmySlots>());
		if (dictionary.Count != 0)
		{
			foreach (KeyValuePair<string, LevelManager.SavedArmySlots> item in dictionary)
			{
				if (item.Value.equipped)
				{
					EquippedUnit equippedUnit = new EquippedUnit();
					equippedUnit.behaviour = LevelManager.instance.Unit(item.Key);
					equippedUnit.tier = ((item.Value.tier >= 1) ? item.Value.tier : equippedUnit.behaviour.upgradeSlots.startTier);
					list.Add(equippedUnit);
				}
			}
		}
		if (list.Count == 0)
		{
			EquippedUnit equippedUnit2 = new EquippedUnit();
			equippedUnit2.behaviour = LevelManager.instance.Unit("Google2u.DBUpgradeSlotsAssaulter");
			equippedUnit2.tier = 1;
			list.Add(equippedUnit2);
			equippedUnit2 = new EquippedUnit();
			equippedUnit2.behaviour = LevelManager.instance.Unit("Google2u.DBUpgradeSlotsShotgunner");
			equippedUnit2.tier = 1;
			list.Add(equippedUnit2);
			equippedUnit2 = new EquippedUnit();
			equippedUnit2.behaviour = LevelManager.instance.Unit("Google2u.DBUpgradeSlotsMachineGunner");
			equippedUnit2.tier = 1;
			list.Add(equippedUnit2);
			equippedUnit2 = new EquippedUnit();
			equippedUnit2.behaviour = LevelManager.instance.Unit("Google2u.DBUpgradeSlotsGrennader");
			equippedUnit2.tier = 1;
			list.Add(equippedUnit2);
		}
		list.Sort(SortEquippedUnits);
		for (int i = list.Count; i < 8; i++)
		{
			list.Add(new EquippedUnit());
		}
		for (int j = 0; j < 8; j++)
		{
			bool isEarlyUnlock = list[j].behaviour != null && list[j].behaviour.upgradeSlots.unlockLevelIndex > mPlayer.level;
			mArmyIcons[j].InitializeUnit(list[j].behaviour, list[j].tier, isEarlyUnlock);
			mArmyIcons[j].AnimationSet(dialogPanel.alpha1, fadeInTime);
		}
	}

	private int SortEquippedUnits(EquippedUnit a, EquippedUnit b)
	{
		bool flag = a == null || a.behaviour == null || a.behaviour.upgradeSlots == null;
		bool flag2 = b == null || b.behaviour == null || b.behaviour.upgradeSlots == null;
		if (flag)
		{
			return (!flag2) ? (-1) : 0;
		}
		if (flag2)
		{
			return 1;
		}
		if (a.behaviour.unitType != b.behaviour.unitType)
		{
			return sortingOrder[a.behaviour.unitType].CompareTo(sortingOrder[b.behaviour.unitType]);
		}
		return a.behaviour.upgradeSlots.unlockLevelIndex.CompareTo(b.behaviour.upgradeSlots.unlockLevelIndex);
	}

	private void FillEquippedWeapons()
	{
		primaryWeaponPart.SetActive(value: true);
		WeaponLevelsSetup weaponLevelsSetup = ((mPlayer != null && mPlayer.inventoryData != null && mPlayer.inventoryData.slots != null && mPlayer.inventoryData.slots.ContainsKey(0)) ? LevelManager.instance.weaponLevelsSetups[mPlayer.inventoryData.slots[0].weaponIndex] : LevelManager.instance.Weapon("Google2u.AssaultRifle_AK47"));
		int weaponLevel = ((mPlayer == null || mPlayer.levelManagerData == null || mPlayer.levelManagerData.savedWeapons == null || !mPlayer.levelManagerData.savedWeapons.ContainsKey(weaponLevelsSetup.GetSheetName())) ? 1 : (1 + mPlayer.levelManagerData.savedWeapons[weaponLevelsSetup.GetSheetName()].boughtIndex));
		SetUpWeaponLook(weaponLevelsSetup, weaponLevel, primaryWeaponIcon, primaryWeaponName, primaryWeaponLevel);
		specialWeaponPart.SetActive(value: true);
		WeaponLevelsSetup weaponLevelsSetup2 = ((mPlayer != null && mPlayer.inventoryData != null && mPlayer.inventoryData.slots != null && mPlayer.inventoryData.slots.ContainsKey(1)) ? LevelManager.instance.weaponLevelsSetups[mPlayer.inventoryData.slots[1].weaponIndex] : LevelManager.instance.Weapon("Google2u.SniperRifle_M24"));
		int weaponLevel2 = ((mPlayer == null || mPlayer.levelManagerData == null || mPlayer.levelManagerData.savedWeapons == null || !mPlayer.levelManagerData.savedWeapons.ContainsKey(weaponLevelsSetup2.GetSheetName())) ? 1 : (1 + mPlayer.levelManagerData.savedWeapons[weaponLevelsSetup2.GetSheetName()].boughtIndex));
		SetUpWeaponLook(weaponLevelsSetup2, weaponLevel2, specialWeaponIcon, specialWeaponName, specialWeaponLevel);
		explosiveWeaponPart.SetActive(value: true);
		WeaponLevelsSetup weaponLevelsSetup3 = ((mPlayer != null && mPlayer.inventoryData != null && mPlayer.inventoryData.slots != null && mPlayer.inventoryData.slots.ContainsKey(2)) ? LevelManager.instance.weaponLevelsSetups[mPlayer.inventoryData.slots[2].weaponIndex] : LevelManager.instance.Weapon("Google2u.Grenade_FRAG"));
		int weaponLevel3 = ((mPlayer == null || mPlayer.levelManagerData == null || mPlayer.levelManagerData.savedWeapons == null || !mPlayer.levelManagerData.savedWeapons.ContainsKey(weaponLevelsSetup3.GetSheetName())) ? 1 : (1 + mPlayer.levelManagerData.savedWeapons[weaponLevelsSetup3.GetSheetName()].boughtIndex));
		SetUpWeaponLook(weaponLevelsSetup3, weaponLevel3, explosiveWeaponIcon, explosiveWeaponName, explosiveWeaponLevel);
	}

	private void SetUpWeaponLook(WeaponLevelsSetup weapon, int weaponLevel, UISprite weaponIconSprite, UILabel weaponNameLabel, UILabel weaponLevelLabel)
	{
		weaponIconSprite.gameObject.SetActive(value: true);
		weaponIconSprite.spriteName = weapon.playerWeapon.iconName;
		weaponIconSprite.MakePixelPerfect();
		float multiplier = Mathf.Min(240f / weaponIconSprite.transform.localScale.x, 160f / weaponIconSprite.transform.localScale.y);
		weaponIconSprite.transform.localScale = weaponIconSprite.transform.localScale.MultiplyXY(multiplier);
		weaponNameLabel.text = weapon.weaponName.ToUpper();
		MiscTools.SetUILabelRescale(weaponNameLabel, 25f, 10f, 222);
		weaponLevelLabel.text = ((weaponLevel != 0) ? Localization.LocalizeFormat("ID_LVLNUMBER", weaponLevel) : string.Empty);
	}

	private void FillFavouriteItems()
	{
		bool active = mPlayer != null && mPlayer.statisticsData != null && mPlayer.levelManagerData != null && mPlayer.levelManagerData.savedArmies != null;
		favouriteUnitPart.SetActive(active);
		if (favouriteUnitPart.activeSelf)
		{
			int favouriteUnitIndex = mPlayer.statisticsData.favouriteUnitIndex;
			LevelBehaviour levelBehaviour = ((favouriteUnitIndex < 0 || favouriteUnitIndex >= LevelManager.instance.behaviours.Count) ? LevelManager.instance.Unit("Google2u.DBUpgradeSlotsAssaulter") : LevelManager.instance.behaviours[favouriteUnitIndex]);
			int num = ((!mPlayer.levelManagerData.savedArmies.ContainsKey(levelBehaviour.upgradeSlots.GetSheetName())) ? levelBehaviour.upgradeSlots.startTier : mPlayer.levelManagerData.savedArmies[levelBehaviour.upgradeSlots.GetSheetName()].tier);
			int num2 = levelBehaviour.upgradeSlots.startUnitLevel + (mPlayer.levelManagerData.savedArmies.ContainsKey(levelBehaviour.upgradeSlots.GetSheetName()) ? mPlayer.levelManagerData.savedArmies[levelBehaviour.upgradeSlots.GetSheetName()].boughtIndex : 0);
			favouriteUnitIcon.spriteName = levelBehaviour.upgradeSlots.iconName;
			favouriteUnitIcon.MakePixelPerfect();
			float multiplier = Mathf.Min(240f / favouriteUnitIcon.transform.localScale.x, 188f / favouriteUnitIcon.transform.localScale.y);
			favouriteUnitIcon.transform.localScale = favouriteUnitIcon.transform.localScale.MultiplyXY(multiplier);
			favouriteUnitName.text = levelBehaviour.unitName.ToUpper();
			MiscTools.SetUILabelRescale(favouriteUnitName, 25f, 10f, 222);
			favouriteUnitLevel.text = ((num2 != 0) ? Localization.LocalizeFormat("ID_LVLNUMBER", num2) : string.Empty);
			for (int i = 0; i < favouriteUnitTiers.Length; i++)
			{
				favouriteUnitTiers[i].gameObject.SetActive(i < num);
			}
		}
		string text = ((mPlayer == null || mPlayer.statisticsData == null) ? null : mPlayer.statisticsData.favouriteWarcardId);
		bool flag = !string.IsNullOrEmpty(text) && CardManager.instance.IsCardId(text);
		favouriteCardPart.SetActive(flag);
		favouriteCardNA.gameObject.SetActive(!flag);
		if (flag)
		{
			Card cardInstance = CardManager.instance.GetCardInstance(text);
			cardInstance.SetUpSmallCard(favouriteCardBackground, favouriteCardIcon, favouriteCardBonusIcon, favouriteCardBonusName);
			favouriteCardName.text = cardInstance.cardName.ToUpper();
			MiscTools.SetUILabelRescale(favouriteCardName, 25f, 10f, 222);
		}
		else
		{
			favouriteCardName.text = string.Empty;
		}
	}

	private void SetPlayerName(string playerNameText)
	{
		playerNameLabel.text = playerNameText;
		int num = 1140;
		if (bannedPart.activeSelf)
		{
			num = 860;
		}
		else if (playerOnlineStatusIcon.gameObject.activeSelf || vipPlayer.gameObject.activeSelf)
		{
			num = 860;
		}
		if (!playerCrownIcon.gameObject.activeSelf)
		{
			num += 60;
		}
		if (!playerCountryIcon.gameObject.activeSelf)
		{
			num += 64;
		}
		MiscTools.SetUILabelRescale(playerNameLabel, 80f, 20f, num);
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		mPreviousPanelDisabled = UIDraggablePanel.panelDisabled;
		UIDraggablePanel.panelDisabled = true;
		if (mTurnOffDragBackground)
		{
			if (GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed)
			{
				GuiElementSingle<ChatGuiElement>.instance.chatContent.draggablePanel.forceDrag = false;
				GuiElementSingle<ChatGuiElement>.instance.messageContent.draggablePanel.forceDrag = false;
			}
			else
			{
				GuiElementSingle<SelectFriendsDialog>.instance.friendsScrollview.forceDrag = false;
				GuiElementSingle<SelectFriendsDialog>.instance.friendsScrollview.onePanelDisabled = true;
				GuiScreenSingle<LeaguesScreen>.instance.allTime.draggablePanel.onePanelDisabled = true;
				GuiScreenSingle<LeaguesScreen>.instance.squadWars.draggableSquads.onePanelDisabled = true;
				GuiScreenSingle<LeaguesScreen>.instance.squadWars.draggableMembers.onePanelDisabled = true;
				GuiScreenSingle<LeaguesScreen>.instance.league.positionsScrollview.onePanelDisabled = true;
				GuiScreenSingle<SquadScreen>.instance.memberContent.draggablePanel.onePanelDisabled = true;
				GuiScreenSingle<SquadScreen>.instance.statsContent.draggablePanel.onePanelDisabled = true;
				GuiElementSingle<SelectSquadLeaderDialog>.instance.draggablePanel.onePanelDisabled = true;
				GuiElementSingle<MissionDialog>.instance.draggablePanel.onePanelDisabled = true;
				GuiElementSingle<MissionDialog>.instance.draggableEnemies.onePanelDisabled = true;
				GuiScreenSingle<EndScreen>.instance.enemy.panelEnemy.onePanelDisabled = true;
				GuiScreenSingle<EndScreen>.instance.cards.panelCards.onePanelDisabled = true;
				GuiScreenSingle<EndScreen>.instance.ribbons.panelRibbons.onePanelDisabled = true;
			}
		}
		GuiElementSingle<SquadDetailsDialog>.instance.draggablePanel.forceDrag = false;
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		UIDraggablePanel.panelDisabled = mPreviousPanelDisabled;
		if (mTurnOffDragBackground)
		{
			if (GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed)
			{
				GuiElementSingle<ChatGuiElement>.instance.chatContent.draggablePanel.forceDrag = true;
				GuiElementSingle<ChatGuiElement>.instance.messageContent.draggablePanel.forceDrag = true;
			}
			else
			{
				GuiElementSingle<SelectFriendsDialog>.instance.friendsScrollview.forceDrag = true;
				GuiElementSingle<SelectFriendsDialog>.instance.friendsScrollview.onePanelDisabled = false;
				GuiScreenSingle<LeaguesScreen>.instance.allTime.draggablePanel.onePanelDisabled = false;
				GuiScreenSingle<LeaguesScreen>.instance.squadWars.draggableSquads.onePanelDisabled = false;
				GuiScreenSingle<LeaguesScreen>.instance.squadWars.draggableMembers.onePanelDisabled = false;
				GuiScreenSingle<LeaguesScreen>.instance.league.positionsScrollview.onePanelDisabled = false;
				GuiScreenSingle<SquadScreen>.instance.memberContent.draggablePanel.onePanelDisabled = false;
				GuiScreenSingle<SquadScreen>.instance.statsContent.draggablePanel.onePanelDisabled = false;
				GuiElementSingle<SelectSquadLeaderDialog>.instance.draggablePanel.onePanelDisabled = false;
				GuiElementSingle<MissionDialog>.instance.draggablePanel.onePanelDisabled = false;
				GuiElementSingle<MissionDialog>.instance.draggableEnemies.onePanelDisabled = false;
				GuiScreenSingle<EndScreen>.instance.enemy.panelEnemy.onePanelDisabled = false;
				GuiScreenSingle<EndScreen>.instance.cards.panelCards.onePanelDisabled = false;
				GuiScreenSingle<EndScreen>.instance.ribbons.panelRibbons.onePanelDisabled = false;
			}
		}
		squadIcon.mainTexture = null;
		GuiElementSingle<SquadDetailsDialog>.instance.draggablePanel.forceDrag = true;
		if (mOpenSquadDetails && Singleton<GameController>.instance.gameState == GameController.GameState.Menu && !GuiElementSingle<LoadingDialog>.instance.isShowed)
		{
			GuiElementSingle<SquadDetailsDialog>.instance.ShowDialog(squadNameLabel.text, mPlayer, mTurnOffDragBackground, mIsBot);
		}
		mPlayerName = null;
		mPlayerId = null;
		playerRankIcon.mainTexture = null;
	}

	public void TestFavUnit()
	{
		mTestIndexUnit++;
		if (mTestIndexUnit >= LevelManager.instance.behaviours.Count)
		{
			mTestIndexUnit = 0;
		}
		LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[mTestIndexUnit];
		int startTier = levelBehaviour.upgradeSlots.startTier;
		favouriteUnitIcon.spriteName = levelBehaviour.upgradeSlots.iconName;
		favouriteUnitIcon.MakePixelPerfect();
		float multiplier = Mathf.Min(240f / favouriteUnitIcon.transform.localScale.x, 188f / favouriteUnitIcon.transform.localScale.y);
		favouriteUnitIcon.transform.localScale = favouriteUnitIcon.transform.localScale.MultiplyXY(multiplier);
		favouriteUnitName.text = levelBehaviour.unitName.ToUpper();
		MiscTools.SetUILabelRescale(favouriteUnitName, 25f, 10f, 222);
		favouriteUnitLevel.text = Localization.LocalizeFormat("ID_LVLNUMBER", levelBehaviour.upgradeSlots.startUnitLevel);
		for (int i = 0; i < favouriteUnitTiers.Length; i++)
		{
			favouriteUnitTiers[i].gameObject.SetActive(i < startTier);
		}
	}

	public void TestPrimaryWeapon()
	{
		mTestIndexWeapon++;
		if (mTestIndexWeapon >= LevelManager.instance.weaponLevelsSetups.Count)
		{
			mTestIndexWeapon = 0;
		}
		WeaponLevelsSetup weaponLevelsSetup = LevelManager.instance.weaponLevelsSetups[mTestIndexWeapon];
		int weaponLevel = weaponLevelsSetup.weaponLevel;
		primaryWeaponPart.SetActive(value: true);
		SetUpWeaponLook(weaponLevelsSetup, weaponLevel, primaryWeaponIcon, primaryWeaponName, primaryWeaponLevel);
	}

	public void TestWarcards()
	{
		mTestIndexCard++;
		if (mTestIndexCard >= CardManager.instance.cardsByRarity.Count)
		{
			mTestIndexCard = 0;
		}
		Card card = CardManager.instance.cardsByRarity[mTestIndexCard];
		favouriteCardPart.SetActive(value: true);
		favouriteCardNA.gameObject.SetActive(value: false);
		card.SetUpSmallCard(favouriteCardBackground, favouriteCardIcon, favouriteCardBonusIcon, favouriteCardBonusName);
		favouriteCardName.text = card.cardName.ToUpper();
		MiscTools.SetUILabelRescale(favouriteCardName, 25f, 10f, 222);
	}

	public IEnumerator CreatePlayerTexture()
	{
		yield return StartCoroutine(Singleton<ArmyPreviewCamera>.instance.CreateHiresPlayerTexture(mPlayer, useBackground: false));
		playerVisual.gameObject.SetActive(value: true);
		playerVisual.avatar = Singleton<ArmyPreviewCamera>.instance.GetHiresPlayerTexture();
		playerVisual.UpdateIcon();
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		CloseDialog(closeButton.gameObject);
	}
}
