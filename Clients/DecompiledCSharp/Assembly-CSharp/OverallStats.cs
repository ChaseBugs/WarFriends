using System;
using System.Collections.Generic;
using UnityEngine;

public class OverallStats : Core_BaseScript
{
	public class PlayerStat
	{
		public enum StatType
		{
			SimpleInt,
			SimpleFloat,
			SimplePercent,
			SimpleTime,
			SimpleIntInt,
			Medals,
			League,
			Missions,
			Coop,
			Stars,
			ArmyPower,
			SquadPoints,
			SimpleLong
		}

		public StatType statisticsType;

		public string statisticsName;

		public int statisticSimpleInt;

		public float statisticsSimpleFloat;

		public int statisticsSecondInt;

		public League statisticsLeague;

		public long statisticSimpleLong;

		private static PlayerStat CreateEmpty()
		{
			PlayerStat playerStat = new PlayerStat();
			playerStat.statisticsType = StatType.SimpleInt;
			playerStat.statisticsName = string.Empty;
			playerStat.statisticSimpleInt = 0;
			playerStat.statisticsSimpleFloat = 0f;
			playerStat.statisticsSecondInt = 0;
			playerStat.statisticsLeague = League.NoLeague;
			return playerStat;
		}

		public static PlayerStat CreateSimpleInt(string title, int value)
		{
			PlayerStat playerStat = CreateEmpty();
			playerStat.statisticsType = StatType.SimpleInt;
			playerStat.statisticsName = title;
			playerStat.statisticSimpleInt = value;
			return playerStat;
		}

		public static PlayerStat CreateSimpleLong(string title, long value)
		{
			PlayerStat playerStat = CreateEmpty();
			playerStat.statisticsType = StatType.SimpleLong;
			playerStat.statisticsName = title;
			playerStat.statisticSimpleLong = value;
			return playerStat;
		}

		public static PlayerStat CreateSimpleFloat(string title, float value)
		{
			PlayerStat playerStat = CreateEmpty();
			playerStat.statisticsType = StatType.SimpleFloat;
			playerStat.statisticsName = title;
			playerStat.statisticsSimpleFloat = value;
			return playerStat;
		}

		public static PlayerStat CreateSimplePercent(string title, int value)
		{
			PlayerStat playerStat = CreateEmpty();
			playerStat.statisticsType = StatType.SimplePercent;
			playerStat.statisticsName = title;
			playerStat.statisticSimpleInt = value;
			return playerStat;
		}

		public static PlayerStat CreateSimpleTime(string title, int value)
		{
			PlayerStat playerStat = CreateEmpty();
			playerStat.statisticsType = StatType.SimpleTime;
			playerStat.statisticsName = title;
			playerStat.statisticSimpleInt = value;
			return playerStat;
		}

		public static PlayerStat CreateSimpleIntInt(string title, int value1, int value2)
		{
			PlayerStat playerStat = CreateEmpty();
			playerStat.statisticsType = StatType.SimpleIntInt;
			playerStat.statisticsName = title;
			playerStat.statisticSimpleInt = value1;
			playerStat.statisticsSecondInt = value2;
			return playerStat;
		}

		public static PlayerStat CreateMedals(string title, int value)
		{
			PlayerStat playerStat = CreateEmpty();
			playerStat.statisticsType = StatType.Medals;
			playerStat.statisticsName = title;
			playerStat.statisticSimpleInt = value;
			return playerStat;
		}

		public static PlayerStat CreateLeague(string title, League bestLeague)
		{
			PlayerStat playerStat = CreateEmpty();
			playerStat.statisticsType = StatType.League;
			playerStat.statisticsName = title;
			playerStat.statisticsLeague = bestLeague;
			return playerStat;
		}

		public static PlayerStat CreateMissions(string title, int value1, int value2)
		{
			PlayerStat playerStat = CreateEmpty();
			playerStat.statisticsType = StatType.Missions;
			playerStat.statisticsName = title;
			playerStat.statisticSimpleInt = value1;
			playerStat.statisticsSecondInt = value2;
			return playerStat;
		}

		public static PlayerStat CreateCoop(string title, int value1, int value2)
		{
			PlayerStat playerStat = CreateEmpty();
			playerStat.statisticsType = StatType.Coop;
			playerStat.statisticsName = title;
			playerStat.statisticSimpleInt = value1;
			playerStat.statisticsSecondInt = value2;
			return playerStat;
		}

		public static PlayerStat CreateStars(string title, int value1, int value2)
		{
			PlayerStat playerStat = CreateEmpty();
			playerStat.statisticsType = StatType.Stars;
			playerStat.statisticsName = title;
			playerStat.statisticSimpleInt = value1;
			playerStat.statisticsSecondInt = value2;
			return playerStat;
		}

		public static PlayerStat CreateArmyPower(string title, int value)
		{
			PlayerStat playerStat = CreateEmpty();
			playerStat.statisticsType = StatType.ArmyPower;
			playerStat.statisticsName = title;
			playerStat.statisticSimpleInt = value;
			return playerStat;
		}

		public static PlayerStat CreateSquadPoints(string title, int value)
		{
			PlayerStat playerStat = CreateEmpty();
			playerStat.statisticsType = StatType.SquadPoints;
			playerStat.statisticsName = title;
			playerStat.statisticSimpleInt = value;
			return playerStat;
		}
	}

	[Header("Content")]
	public PlayerStatsScreenRecord playerStatsRecordPrefab;

	public int maxStats = 30;

	public UIDraggablePanel draggablePanel;

	[Header("-Name Change")]
	public UITable nameTable;

	public UISprite facebookIcon;

	public UISprite googlePlayIcon;

	public UILabel playerName;

	public BoxCollider playerNameCollider;

	public GameObject playerNameParent;

	public UIButton changeNameButton;

	[Header("-Rank Progress")]
	public UITexture playerRankTexture;

	public UILabel playerRank;

	public UILabel playerXP;

	public UISprite progressXP;

	[Header("-Army Power")]
	public UILabel rankPowerLabel;

	public UILabel weaponsPowerLabel;

	public UILabel unitsPowerLabel;

	public UILabel yourPowerLabel;

	[Header("-Grids")]
	public List<UILabel> partLabels;

	public List<UISprite> leftSprites;

	public List<UISprite> rightSprites;

	public UIPooledGrid multiplayerGrid;

	public GameObject arenaPart;

	public UIPooledGrid arenaGrid;

	public GameObject careerPart;

	public UIPooledGrid careerGrid;

	public GameObject warpathPart;

	public UIPooledGrid warpathGrid;

	private List<PlayerStat> mMultiplayerStat = new List<PlayerStat>();

	private List<PlayerStat> mArenaStat = new List<PlayerStat>();

	private List<PlayerStat> mCareerStat = new List<PlayerStat>();

	private List<PlayerStat> mWarpathStat = new List<PlayerStat>();

	private bool isDataCreated => mMultiplayerStat != null && mMultiplayerStat.Count == 21 && mArenaStat != null && mArenaStat.Count == 5 && mCareerStat != null && mCareerStat.Count == 11 && mWarpathStat != null && mWarpathStat.Count == 7;

	public void Animate(bool showTab, bool instant)
	{
		if (showTab && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
			InitGUIValues();
		}
		if (base.gameObject.activeSelf)
		{
			TweenAlpha.Begin(draggablePanel.gameObject, (!instant) ? (GuiScreenSingle<PlayerStatsScreen>.instance.dur * 2f) : 0.01f, (!showTab) ? 0f : 1f).onFinished = delegate
			{
				if (!showTab)
				{
					base.gameObject.SetActive(value: false);
					DoAfterHide();
				}
			};
		}
		else if (!showTab)
		{
			InstantHideTab();
		}
	}

	public void InitEvents()
	{
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += delegate
		{
			if (GuiScreenSingle<PlayerStatsScreen>.instance.isShowed && base.gameObject.activeSelf)
			{
				InitGUIValues();
			}
		};
		Singleton<BeanstalkServerManager>.instance.DataLoaded += delegate(DatabaseAction action)
		{
			if (GuiScreenSingle<PlayerStatsScreen>.instance.isShowed && base.gameObject.activeSelf)
			{
				if (action == DatabaseAction.AddFacebook || action == DatabaseAction.SwitchToFacebook || action == DatabaseAction.AddGooglePlay || action == DatabaseAction.RemoveGooglePlay || action == DatabaseAction.LoginToCustomAccount || action == DatabaseAction.ChangePlayerName || action == DatabaseAction.RemoveFacebook)
				{
					UpdateAccount();
				}
			}
		};
	}

	public void InitControls()
	{
		SetSizes();
		CreateDataStats();
		UIEventListener uIEventListener = UIEventListener.Get(playerNameCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, (UIEventListener.VoidDelegate)delegate
		{
			TweenColor tweenColor = TweenColor.Begin(playerName.gameObject, GameVariables.durationOfNameButtonColor, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.PingPong;
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(GameLoginManager.currentPlayer.name, GameLoginManager.currentPlayer.id);
		});
		UIEventListener uIEventListener2 = UIEventListener.Get(changeNameButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (GameLoginManager.currentPlayer.accountType == AccountType.Guest)
			{
				GuiElementSingle<SettingsDialog>.instance.ShowUser();
			}
			else
			{
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<RenameDialog>.instance, 0f);
			}
		});
		nameTable.onReposition = delegate
		{
			float val = 0f - nameTable.padding.x - (playerNameParent.transform.localPosition.x - nameTable.padding.x) / 2f;
			nameTable.transform.localPosition = nameTable.transform.localPosition.ReplaceX(val);
		};
	}

	public void InitGUIValues()
	{
		UpdateAccount();
		UpdateRank();
		UpdateArmyPower();
		UpdateDataStats();
		RepositionGridsAndTable();
	}

	public void DoAfterHide()
	{
		playerRankTexture.mainTexture = null;
	}

	public void InstantHideTab()
	{
		TweenAlpha component = draggablePanel.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		base.gameObject.SetActive(value: false);
		DoAfterHide();
	}

	private void UpdateAccount()
	{
		facebookIcon.gameObject.SetActive(GameLoginManager.currentPlayer.isFacebookConnected);
		googlePlayIcon.gameObject.SetActive(GameLoginManager.currentPlayer.isGooglePlayConnected && !GameLoginManager.currentPlayer.isFacebookConnected);
		playerName.text = GameLoginManager.currentPlayer.name;
		playerNameCollider.center = playerNameCollider.center.ReplaceX((0f - playerName.relativeSize.x) / 2f);
		playerNameCollider.size = playerNameCollider.size.ReplaceX(playerName.relativeSize.x * 1.05f);
		nameTable.repositionNow = true;
	}

	private void UpdateRank()
	{
		LevelManager.GameLevel currentLevel = LevelManager.instance.currentLevel;
		playerRank.text = currentLevel.displayString;
		playerRankTexture.mainTexture = Resources.Load<Texture>("Ranks/" + currentLevel.iconName);
		string arg = ((currentLevel.displayNumber != LevelManager.instance.maxDisplayLevel) ? MiscTools.FormatBigNumber(currentLevel.score) : Localization.Localize("ID_MAX"));
		playerXP.text = $"{MiscTools.FormatBigNumber(LevelManager.instance.levelExperience)} / {arg}";
		progressXP.fillAmount = LevelManager.instance.GetProgress();
	}

	private void UpdateArmyPower()
	{
		rankPowerLabel.text = MiscTools.FormatBigNumber(LevelManager.instance.rankPowerX10);
		weaponsPowerLabel.text = MiscTools.FormatBigNumber(LevelManager.instance.weaponPowerX10);
		unitsPowerLabel.text = MiscTools.FormatBigNumber(LevelManager.instance.unitPowerX10);
		yourPowerLabel.text = MiscTools.FormatBigNumber(LevelManager.instance.armyPowerX10);
	}

	private void CreateDataStats()
	{
		if (mMultiplayerStat == null)
		{
			mMultiplayerStat = new List<PlayerStat>();
		}
		else
		{
			mMultiplayerStat.Clear();
		}
		mMultiplayerStat.Add(PlayerStat.CreateSimpleInt(Localization.Localize("ID_STAT_BATTLESPLAYED"), StatsManager.instance.battlesPlayed));
		mMultiplayerStat.Add(PlayerStat.CreateSimpleInt(Localization.Localize("ID_STAT_WINS"), StatsManager.instance.battlesWon));
		mMultiplayerStat.Add(PlayerStat.CreateSimpleInt(Localization.Localize("ID_STAT_LOSSES"), StatsManager.instance.battlesLost));
		mMultiplayerStat.Add(PlayerStat.CreateSimpleFloat(Localization.Localize("ID_STAT_WINLOSSRATIO"), StatsManager.instance.winLoseRatio));
		mMultiplayerStat.Add(PlayerStat.CreateSimpleInt(Localization.Localize("ID_STAT_KILLS"), StatsManager.instance.kills));
		mMultiplayerStat.Add(PlayerStat.CreateSimplePercent(Localization.Localize("ID_STAT_ACCURACY"), (int)(StatsManager.instance.accuracy * 100f)));
		mMultiplayerStat.Add(PlayerStat.CreateSimpleInt(Localization.Localize("ID_STAT_UNITSDEPLOYED"), StatsManager.instance.unitsDeployedTotal));
		mMultiplayerStat.Add(PlayerStat.CreateSimpleInt(Localization.Localize("ID_STAT_WARCARDSPLAYED"), StatsManager.instance.cardsPlayed));
		mMultiplayerStat.Add(PlayerStat.CreateSimpleInt(Localization.Localize("ID_STAT_SCORESTREAKSGAINED"), StatsManager.instance.scorestreakGained));
		mMultiplayerStat.Add(PlayerStat.CreateSimpleInt(Localization.Localize("ID_STAT_CRATESSTOLEN"), StatsManager.instance.cratesStolen));
		mMultiplayerStat.Add(PlayerStat.CreateSimpleInt(Localization.Localize("ID_STAT_VEHICLEDESTROYED"), StatsManager.instance.vehicleDestroyed));
		mMultiplayerStat.Add(PlayerStat.CreateSimpleInt(Localization.Localize("ID_STAT_ASSAULTRIFLEKILLS"), StatsManager.instance.GetWeaponKills(WeaponCategory.AssaultRifle)));
		mMultiplayerStat.Add(PlayerStat.CreateSimpleInt(Localization.Localize("ID_STAT_SMGKILLS"), StatsManager.instance.GetWeaponKills(WeaponCategory.SMG)));
		mMultiplayerStat.Add(PlayerStat.CreateSimpleInt(Localization.Localize("ID_STAT_LMGKILLS"), StatsManager.instance.GetWeaponKills(WeaponCategory.LMG)));
		mMultiplayerStat.Add(PlayerStat.CreateSimpleInt(Localization.Localize("ID_STAT_MINIGUNKILLS"), StatsManager.instance.GetWeaponKills(WeaponCategory.Minigun)));
		mMultiplayerStat.Add(PlayerStat.CreateSimpleInt(Localization.Localize("ID_STAT_SNIPERRIFLEKILLS"), StatsManager.instance.GetWeaponKills(WeaponCategory.SniperRifle)));
		mMultiplayerStat.Add(PlayerStat.CreateSimpleInt(Localization.Localize("ID_STAT_SHOTGUNKILLS"), StatsManager.instance.GetWeaponKills(WeaponCategory.Shotgun)));
		mMultiplayerStat.Add(PlayerStat.CreateSimpleInt(Localization.Localize("ID_STAT_GRENADEKILLS"), StatsManager.instance.GetWeaponKills(WeaponCategory.Grenade)));
		mMultiplayerStat.Add(PlayerStat.CreateSimpleInt(Localization.Localize("ID_STAT_ROCKETLAUNCHERKILLS"), StatsManager.instance.GetWeaponKills(WeaponCategory.RocketLauncher)));
		mMultiplayerStat.Add(PlayerStat.CreateSimpleInt(Localization.Localize("ID_STAT_GRENADELAUNCHERKILLS"), StatsManager.instance.GetWeaponKills(WeaponCategory.GrenadeLauncher)));
		mMultiplayerStat.Add(PlayerStat.CreateSimpleInt(Localization.Localize("ID_STAT_HANDGUNKILLS"), StatsManager.instance.GetWeaponKills(WeaponCategory.Pistol)));
		if (mArenaStat == null)
		{
			mArenaStat = new List<PlayerStat>();
		}
		else
		{
			mArenaStat.Clear();
		}
		mArenaStat.Add(PlayerStat.CreateSimpleInt(Localization.Localize("ID_STAT_ALLTIMERUNS"), StatsManager.instance.arenaRuns));
		mArenaStat.Add(PlayerStat.CreateSimpleInt(Localization.Localize("ID_STAT_BATTLESPLAYED"), StatsManager.instance.arenaBattles));
		mArenaStat.Add(PlayerStat.CreateSimpleInt(Localization.Localize("ID_STAT_ARENAWINS"), StatsManager.instance.arenaWins));
		mArenaStat.Add(PlayerStat.CreateSimpleInt(Localization.Localize("ID_STAT_FLAWLESSHERO"), StatsManager.instance.arenaFlawless));
		mArenaStat.Add(PlayerStat.CreateSimpleInt(Localization.Localize("ID_STAT_ARENALOOTBOXES"), StatsManager.instance.arenaLootboxes));
		if (mCareerStat == null)
		{
			mCareerStat = new List<PlayerStat>();
		}
		else
		{
			mCareerStat.Clear();
		}
		mCareerStat.Add(PlayerStat.CreateSimpleLong(Localization.Localize("ID_STAT_GLOBALXP"), StatsManager.instance.globalXP));
		mCareerStat.Add(PlayerStat.CreateSimpleTime(Localization.Localize("ID_STAT_TIMEPLAYED"), StatsManager.instance.secondsPlayed));
		mCareerStat.Add(PlayerStat.CreateSimpleInt(Localization.Localize("ID_STAT_ASSIGNMENTSDONE"), StatsManager.instance.assignmentsCompleted));
		mCareerStat.Add(PlayerStat.CreateMedals(Localization.Localize("ID_STAT_MAXMEDALSGAINED"), StatsManager.instance.maxMedals));
		mCareerStat.Add(PlayerStat.CreateLeague(Localization.Localize("ID_STAT_BESTLEAGUE"), StatsManager.instance.bestLeague));
		mCareerStat.Add(PlayerStat.CreateArmyPower(Localization.Localize("ID_ARMYPOWER"), StatsManager.instance.armyPowerX10));
		mCareerStat.Add(PlayerStat.CreateSquadPoints(Localization.Localize("ID_STAT_ALLTIMESQUADPOINTS"), StatsManager.instance.data.squadPointsTotal));
		mCareerStat.Add(PlayerStat.CreateSimpleIntInt(Localization.Localize("ID_STAT_WEAPONSPURCHASED"), StatsManager.instance.weaponsPurchased, StatsManager.instance.weaponsPurchaseCount));
		mCareerStat.Add(PlayerStat.CreateSimpleIntInt(Localization.Localize("ID_STAT_WEAPONSUPGRADES"), StatsManager.instance.weaponsUpgrades, StatsManager.instance.weaponsUpgradesCount));
		mCareerStat.Add(PlayerStat.CreateSimpleIntInt(Localization.Localize("ID_STAT_UNITSPURCHASED"), StatsManager.instance.unitsPurchased, StatsManager.instance.unitPurchaseCount));
		mCareerStat.Add(PlayerStat.CreateSimpleIntInt(Localization.Localize("ID_STAT_UNITSUPGRADES"), StatsManager.instance.unitsUpgrades, StatsManager.instance.unitUpgradesCount));
		mCareerStat.Add(PlayerStat.CreateSimpleIntInt(Localization.Localize("ID_STAT_CUSTOMISATIONSPURCHASED"), StatsManager.instance.customisationsPurchased, StatsManager.instance.customisationsCount));
		if (mWarpathStat == null)
		{
			mWarpathStat = new List<PlayerStat>();
		}
		else
		{
			mWarpathStat.Clear();
		}
		mWarpathStat.Add(PlayerStat.CreateMissions(Localization.Localize("ID_STAT_MISSIONSCOMPLETED"), StatsManager.instance.missionsCompleted, StatsManager.instance.missionsCount));
		mWarpathStat.Add(PlayerStat.CreateCoop(Localization.Localize("ID_STAT_MISSIONSINCOOP"), StatsManager.instance.missionsCoop, StatsManager.instance.missionsCount));
		mWarpathStat.Add(PlayerStat.CreateStars(Localization.Localize("ID_STAT_STARSGAINED"), StatsManager.instance.starsGained, 3 * StatsManager.instance.missionsCount));
		mWarpathStat.Add(PlayerStat.CreateSimpleInt(Localization.Localize("ID_STAT_KILLS"), StatsManager.instance.missionsKills));
		mWarpathStat.Add(PlayerStat.CreateSimpleInt(Localization.Localize("ID_STAT_DEATHS"), StatsManager.instance.missionsDeaths));
		mWarpathStat.Add(PlayerStat.CreateSimpleFloat(Localization.Localize("ID_STAT_KILLSDEATHSRATIO"), StatsManager.instance.missionsKillsDeathsRatio));
		mWarpathStat.Add(PlayerStat.CreateSimplePercent(Localization.Localize("ID_STAT_ACCURACY"), (int)(StatsManager.instance.missionsAccuracy * 100f)));
	}

	private void UpdateDataStats()
	{
		if (!isDataCreated)
		{
			CreateDataStats();
		}
		mMultiplayerStat[0].statisticSimpleInt = StatsManager.instance.battlesPlayed;
		mMultiplayerStat[1].statisticSimpleInt = StatsManager.instance.battlesWon;
		mMultiplayerStat[2].statisticSimpleInt = StatsManager.instance.battlesLost;
		mMultiplayerStat[3].statisticsSimpleFloat = StatsManager.instance.winLoseRatio;
		mMultiplayerStat[4].statisticSimpleInt = StatsManager.instance.kills;
		mMultiplayerStat[5].statisticSimpleInt = (int)(StatsManager.instance.accuracy * 100f);
		mMultiplayerStat[6].statisticSimpleInt = StatsManager.instance.unitsDeployedTotal;
		mMultiplayerStat[7].statisticSimpleInt = StatsManager.instance.cardsPlayed;
		mMultiplayerStat[8].statisticSimpleInt = StatsManager.instance.scorestreakGained;
		mMultiplayerStat[9].statisticSimpleInt = StatsManager.instance.cratesStolen;
		mMultiplayerStat[10].statisticSimpleInt = StatsManager.instance.vehicleDestroyed;
		mMultiplayerStat[11].statisticSimpleInt = StatsManager.instance.GetWeaponKills(WeaponCategory.AssaultRifle);
		mMultiplayerStat[12].statisticSimpleInt = StatsManager.instance.GetWeaponKills(WeaponCategory.SMG);
		mMultiplayerStat[13].statisticSimpleInt = StatsManager.instance.GetWeaponKills(WeaponCategory.LMG);
		mMultiplayerStat[14].statisticSimpleInt = StatsManager.instance.GetWeaponKills(WeaponCategory.Minigun);
		mMultiplayerStat[15].statisticSimpleInt = StatsManager.instance.GetWeaponKills(WeaponCategory.SniperRifle);
		mMultiplayerStat[16].statisticSimpleInt = StatsManager.instance.GetWeaponKills(WeaponCategory.Shotgun);
		mMultiplayerStat[17].statisticSimpleInt = StatsManager.instance.GetWeaponKills(WeaponCategory.Grenade);
		mMultiplayerStat[18].statisticSimpleInt = StatsManager.instance.GetWeaponKills(WeaponCategory.RocketLauncher);
		mMultiplayerStat[19].statisticSimpleInt = StatsManager.instance.GetWeaponKills(WeaponCategory.GrenadeLauncher);
		mMultiplayerStat[20].statisticSimpleInt = StatsManager.instance.GetWeaponKills(WeaponCategory.Pistol);
		mArenaStat[0].statisticSimpleInt = StatsManager.instance.arenaRuns;
		mArenaStat[1].statisticSimpleInt = StatsManager.instance.arenaBattles;
		mArenaStat[2].statisticSimpleInt = StatsManager.instance.arenaWins;
		mArenaStat[3].statisticSimpleInt = StatsManager.instance.arenaFlawless;
		mArenaStat[4].statisticSimpleInt = StatsManager.instance.arenaLootboxes;
		mCareerStat[0].statisticSimpleLong = StatsManager.instance.globalXP;
		mCareerStat[1].statisticSimpleInt = StatsManager.instance.secondsPlayed;
		mCareerStat[2].statisticSimpleInt = StatsManager.instance.assignmentsCompleted;
		mCareerStat[3].statisticSimpleInt = StatsManager.instance.maxMedals;
		mCareerStat[4].statisticsLeague = StatsManager.instance.bestLeague;
		mCareerStat[5].statisticSimpleInt = StatsManager.instance.armyPowerX10;
		mCareerStat[6].statisticSimpleInt = StatsManager.instance.data.squadPointsTotal;
		mCareerStat[7].statisticSimpleInt = StatsManager.instance.weaponsPurchased;
		mCareerStat[8].statisticSimpleInt = StatsManager.instance.weaponsUpgrades;
		mCareerStat[9].statisticSimpleInt = StatsManager.instance.unitsPurchased;
		mCareerStat[10].statisticSimpleInt = StatsManager.instance.unitsUpgrades;
		mCareerStat[11].statisticSimpleInt = StatsManager.instance.customisationsPurchased;
		mWarpathStat[0].statisticSimpleInt = StatsManager.instance.missionsCompleted;
		mWarpathStat[1].statisticSimpleInt = StatsManager.instance.missionsCoop;
		mWarpathStat[2].statisticSimpleInt = StatsManager.instance.starsGained;
		mWarpathStat[3].statisticSimpleInt = StatsManager.instance.missionsKills;
		mWarpathStat[4].statisticSimpleInt = StatsManager.instance.missionsDeaths;
		mWarpathStat[5].statisticsSimpleFloat = StatsManager.instance.missionsKillsDeathsRatio;
		mWarpathStat[6].statisticSimpleInt = (int)(StatsManager.instance.missionsAccuracy * 100f);
	}

	private void RepositionGridsAndTable()
	{
		float num = 200f;
		float num2 = 542f;
		multiplayerGrid.MakeEmpty();
		multiplayerGrid.init(mMultiplayerStat.Count, StatMultiplayerInstantiate, StatFree, draggablePanel);
		float num3 = num2 + num + Mathf.Abs(multiplayerGrid.helperMin.localPosition.y - multiplayerGrid.helperMax.localPosition.y);
		arenaPart.transform.localPosition = new Vector3(0f, 0f - num3, 0f);
		arenaGrid.offsetGrid = new Vector2(0f, num3);
		arenaGrid.MakeEmpty();
		arenaGrid.init(mArenaStat.Count, StatArenaInstantiate, StatFree, draggablePanel);
		float num4 = num3 + num + Mathf.Abs(arenaGrid.helperMin.localPosition.y - arenaGrid.helperMax.localPosition.y);
		careerPart.transform.localPosition = new Vector3(0f, 0f - num4, 0f);
		careerGrid.offsetGrid = new Vector2(0f, num4);
		careerGrid.MakeEmpty();
		careerGrid.init(mCareerStat.Count, StatCareerInstantiate, StatFree, draggablePanel);
		float num5 = num4 + num + Mathf.Abs(careerGrid.helperMin.localPosition.y - careerGrid.helperMax.localPosition.y);
		warpathPart.transform.localPosition = new Vector3(0f, 0f - num5, 0f);
		warpathGrid.offsetGrid = new Vector2(0f, num5);
		warpathGrid.MakeEmpty();
		warpathGrid.init(mWarpathStat.Count, StatWarpathInstantiate, StatFree, draggablePanel);
		draggablePanel.UpdateScrollbars(recalculateBounds: true);
		draggablePanel.AlignToPos(instant: true);
	}

	private Transform StatMultiplayerInstantiate(int index)
	{
		if (index >= 0 && index < mMultiplayerStat.Count)
		{
			PlayerStatsScreenRecord playerStatsScreenRecord = Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(playerStatsRecordPrefab, multiplayerGrid.gameObject, $"Multiplayer Record {index + 1:D2}") as PlayerStatsScreenRecord;
			if (playerStatsScreenRecord != null)
			{
				playerStatsScreenRecord.Init(mMultiplayerStat[index]);
				return playerStatsScreenRecord.transform;
			}
		}
		return null;
	}

	private Transform StatArenaInstantiate(int index)
	{
		if (index >= 0 && index < mArenaStat.Count)
		{
			PlayerStatsScreenRecord playerStatsScreenRecord = Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(playerStatsRecordPrefab, arenaGrid.gameObject, $"Arena Record {index + 1:D2}") as PlayerStatsScreenRecord;
			if (playerStatsScreenRecord != null)
			{
				playerStatsScreenRecord.Init(mArenaStat[index]);
				return playerStatsScreenRecord.transform;
			}
		}
		return null;
	}

	private Transform StatCareerInstantiate(int index)
	{
		if (index >= 0 && index < mCareerStat.Count)
		{
			PlayerStatsScreenRecord playerStatsScreenRecord = Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(playerStatsRecordPrefab, careerGrid.gameObject, $"Career Record {index + 1:D2}") as PlayerStatsScreenRecord;
			if (playerStatsScreenRecord != null)
			{
				playerStatsScreenRecord.Init(mCareerStat[index]);
				return playerStatsScreenRecord.transform;
			}
		}
		return null;
	}

	private Transform StatWarpathInstantiate(int index)
	{
		if (index >= 0 && index < mWarpathStat.Count)
		{
			PlayerStatsScreenRecord playerStatsScreenRecord = Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(playerStatsRecordPrefab, warpathGrid.gameObject, $"Warpath Record {index + 1:D2}") as PlayerStatsScreenRecord;
			if (playerStatsScreenRecord != null)
			{
				playerStatsScreenRecord.Init(mWarpathStat[index]);
				return playerStatsScreenRecord.transform;
			}
		}
		return null;
	}

	private void StatFree(Transform obj)
	{
		if (!(obj == null))
		{
			PlayerStatsScreenRecord component = obj.GetComponent<PlayerStatsScreenRecord>();
			if (component != null)
			{
				component.DestroyPooled();
			}
		}
	}

	private void SetSizes()
	{
		float num = UIRoot.list[0].activeHeight;
		float activeWidth = UIRoot.list[0].activeWidth;
		float num2 = activeWidth - 120f;
		float num3 = num2 / 2f;
		float num4 = num - GuiScreenSingle<PlayerStatsScreen>.instance.headerHeight;
		float num5 = num / 2f - GuiScreenSingle<PlayerStatsScreen>.instance.headerHeight - num4 / 2f;
		int num6 = Mathf.CeilToInt(num / 230f) + 2;
		int a = maxStats / num6;
		int b = Mathf.FloorToInt(num2 / 520f);
		int num7 = Mathf.Min(a, b);
		float num8 = (num2 - (float)num7 * 520f) / (float)Mathf.Max(1, num7 - 1);
		UIPanel component = draggablePanel.gameObject.GetComponent<UIPanel>();
		if (component != null)
		{
			component.clipRange = new Vector4(component.clipRange.x, num5, component.clipRange.z, num4);
		}
		BoxCollider component2 = draggablePanel.gameObject.GetComponent<BoxCollider>();
		if (component2 != null)
		{
			component2.center = component2.center.ReplaceY(num5);
			component2.size = component2.size.ReplaceY(num4);
		}
		draggablePanel.transform.localPosition = Vector3.zero;
		multiplayerGrid.maxPerLine = num7;
		multiplayerGrid.cellWidth = 520f + num8;
		multiplayerGrid.transform.localPosition = multiplayerGrid.transform.localPosition.ReplaceX(0f - num3 + 260f);
		arenaGrid.maxPerLine = num7;
		arenaGrid.cellWidth = 520f + num8;
		arenaGrid.transform.localPosition = arenaGrid.transform.localPosition.ReplaceX(0f - num3 + 260f);
		careerGrid.maxPerLine = num7;
		careerGrid.cellWidth = 520f + num8;
		careerGrid.transform.localPosition = careerGrid.transform.localPosition.ReplaceX(0f - num3 + 260f);
		warpathGrid.maxPerLine = num7;
		warpathGrid.cellWidth = 520f + num8;
		warpathGrid.transform.localPosition = warpathGrid.transform.localPosition.ReplaceX(0f - num3 + 260f);
		for (int i = 0; i < 4; i++)
		{
			float num9 = num2 - (partLabels[i].relativeSize.x * partLabels[i].transform.localScale.x + 100f);
			leftSprites[i].transform.localScale = leftSprites[i].transform.localScale.ReplaceX(num9 / 2f);
			rightSprites[i].transform.localScale = rightSprites[i].transform.localScale.ReplaceX(num9 / 2f);
			leftSprites[i].transform.localPosition = leftSprites[i].transform.localPosition.ReplaceX(0f - num3);
			rightSprites[i].transform.localPosition = rightSprites[i].transform.localPosition.ReplaceX(num3);
		}
	}
}
