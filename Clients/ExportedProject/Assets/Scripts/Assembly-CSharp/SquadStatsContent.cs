using System.Collections.Generic;
using UnityEngine;

public class SquadStatsContent : Core_BaseScript
{
	public class SquadStatInternal
	{
		public enum StatType
		{
			SimpleInt,
			SimpleFloat,
			PlayerInt,
			PlayerFloat,
			PlayerPercent,
			PictureInt
		}

		public StatType type;

		public string title;

		public int number;

		public float floatNumber;

		public string spriteName;

		public Color spriteColor;

		public DatabasePlayer player;

		public Color textColor;

		private static SquadStatInternal CreateEmpty()
		{
			SquadStatInternal squadStatInternal = new SquadStatInternal();
			squadStatInternal.type = StatType.SimpleInt;
			squadStatInternal.title = string.Empty;
			squadStatInternal.number = 0;
			squadStatInternal.floatNumber = 0f;
			squadStatInternal.spriteName = string.Empty;
			squadStatInternal.spriteColor = Color.white;
			squadStatInternal.player = null;
			squadStatInternal.textColor = Colours.blue;
			return squadStatInternal;
		}

		public static SquadStatInternal CreateSquadStatInt(string name, int count)
		{
			SquadStatInternal squadStatInternal = CreateEmpty();
			squadStatInternal.title = name;
			squadStatInternal.number = count;
			return squadStatInternal;
		}

		public static SquadStatInternal CreateSquadStatFloat(string name, float number)
		{
			SquadStatInternal squadStatInternal = CreateEmpty();
			squadStatInternal.type = StatType.SimpleFloat;
			squadStatInternal.title = name;
			squadStatInternal.floatNumber = number;
			return squadStatInternal;
		}

		public static SquadStatInternal CreateSquadStatPlayerInt(string name, int count, DatabasePlayer player, Color statColor)
		{
			SquadStatInternal squadStatInternal = CreateEmpty();
			squadStatInternal.type = StatType.PlayerInt;
			squadStatInternal.title = name;
			squadStatInternal.number = count;
			squadStatInternal.player = player;
			squadStatInternal.textColor = statColor;
			return squadStatInternal;
		}

		public static SquadStatInternal CreateSquadStatPlayerFloat(string name, float number, DatabasePlayer player)
		{
			SquadStatInternal squadStatInternal = CreateEmpty();
			squadStatInternal.type = StatType.PlayerFloat;
			squadStatInternal.title = name;
			squadStatInternal.floatNumber = number;
			squadStatInternal.player = player;
			return squadStatInternal;
		}

		public static SquadStatInternal CreateSquadStatPlayerPercent(string name, int count, DatabasePlayer player)
		{
			SquadStatInternal squadStatInternal = CreateEmpty();
			squadStatInternal.type = StatType.PlayerPercent;
			squadStatInternal.title = name;
			squadStatInternal.number = count;
			squadStatInternal.player = player;
			return squadStatInternal;
		}

		public static SquadStatInternal CreateSquadStatPicture(string name, int count, string spriteName, Color spriteColor, Color labelColor)
		{
			SquadStatInternal squadStatInternal = CreateEmpty();
			squadStatInternal.type = StatType.PictureInt;
			squadStatInternal.title = name;
			squadStatInternal.number = count;
			squadStatInternal.spriteName = spriteName;
			squadStatInternal.spriteColor = spriteColor;
			squadStatInternal.textColor = labelColor;
			return squadStatInternal;
		}
	}

	[Header("Drag Part")]
	public UIPanel panel;

	public UIDraggablePanel draggablePanel;

	[Header("Loading Part")]
	public GameObject contentPart;

	public GameObject waitingPart;

	[Header("Squad Rank")]
	public UILabel squadRank;

	public UILabel squadXP;

	public UISprite progressXP;

	[Header("Squad Members")]
	public UILabel membersHeader;

	public GameObject nextSquadSizePart;

	public UILabel squadSizeIncrease;

	public GameObject maxSquadSizePart;

	[Header("List of Squad Statistics")]
	public SquadStatsRecord squadStatsRecordPrefab;

	public int maxStats = 32;

	public List<UILabel> partLabels;

	public List<UISprite> leftSprites;

	public List<UISprite> rightSprites;

	[Header("-Squad Total")]
	public GameObject totalPart;

	public UIPooledGrid statsTotalGrid;

	[Header("-Squad Best")]
	public GameObject bestPart;

	public UIPooledGrid statsBestGrid;

	private bool mIsActive;

	private List<SquadStatInternal> mSquadTotalStats = new List<SquadStatInternal>();

	private List<SquadStatInternal> mSquadBestStats = new List<SquadStatInternal>();

	public void InitControls()
	{
		base.gameObject.SetActive(value: false);
		mIsActive = false;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnServerDataLoaded;
		float activeWidth = UIRoot.list[0].activeWidth;
		float num = UIRoot.list[0].activeHeight;
		int num2 = UIRoot.list[0].activeHeight - 470;
		panel.clipRange = new Vector4(activeWidth / 2f, (float)(-num2) / 2f, activeWidth, num2);
		draggablePanel.transform.localPosition = draggablePanel.transform.localPosition.ReplaceY(0f);
		int num3 = Mathf.CeilToInt(num / 250f) + 2;
		int a = maxStats / num3;
		float num4 = activeWidth - 120f;
		int b = Mathf.FloorToInt(num4 / 520f);
		int num5 = Mathf.Min(a, b);
		float num6 = (num4 - (float)num5 * 520f) / (float)Mathf.Max(1, num5 - 1);
		statsTotalGrid.maxPerLine = num5;
		statsTotalGrid.cellWidth = 520f + num6;
		statsTotalGrid.offsetGrid = new Vector2(0f, Mathf.Abs(totalPart.transform.localPosition.y) + 95f);
		statsBestGrid.maxPerLine = num5;
		statsBestGrid.cellWidth = 520f + num6;
		partLabels[0].text = Localization.Localize("ID_STAT_SQUADTOTAL");
		partLabels[1].text = Localization.Localize("ID_STAT_SQUADBEST");
		for (int i = 0; i < 2; i++)
		{
			partLabels[i].transform.localPosition = partLabels[i].transform.localPosition.ReplaceX(num4 / 2f);
			float num7 = num4 - (partLabels[i].relativeSize.x * partLabels[i].transform.localScale.x + 100f);
			leftSprites[i].transform.localScale = leftSprites[i].transform.localScale.ReplaceX(num7 / 2f);
			rightSprites[i].transform.localScale = rightSprites[i].transform.localScale.ReplaceX(num7 / 2f);
			leftSprites[i].transform.localPosition = leftSprites[i].transform.localPosition.ReplaceX(0f);
			rightSprites[i].transform.localPosition = rightSprites[i].transform.localPosition.ReplaceX(num4);
		}
	}

	private void OnServerDataLoaded(DatabaseAction action)
	{
		if (!GuiScreenSingle<SquadScreen>.instance.isShowed || !mIsActive)
		{
			return;
		}
		switch (action)
		{
		case DatabaseAction.GetSquadDetails:
		{
			DatabaseSquad squad2 = Singleton<ServerResultsCache>.instance.GetSquad(GameLoginManager.currentPlayer.squadName, ommitTime: true);
			if (squad2 != null)
			{
				ShowSquadDetails(squad2);
			}
			break;
		}
		case DatabaseAction.GetAllSquadMembers:
		{
			DatabasePlayer generatedCurrentPlayer = GameLoginManager.generatedCurrentPlayer;
			DatabaseSquad squad = Singleton<ServerResultsCache>.instance.GetSquad(generatedCurrentPlayer.squadName, ommitTime: true);
			List<DatabasePlayer> squadMembers = Singleton<ServerResultsCache>.instance.GetSquadMembers(generatedCurrentPlayer.squadName);
			if (squad == null || squadMembers == null)
			{
				break;
			}
			int num = squadMembers.FindIndex((DatabasePlayer p1) => p1.id == GameLoginManager.currentPlayer.id);
			if (num > -1)
			{
				squadMembers[num].playerVisuals = generatedCurrentPlayer.playerVisuals;
				squadMembers[num].statisticsData = generatedCurrentPlayer.statisticsData;
				squadMembers[num].armyPower = generatedCurrentPlayer.armyPower;
				squadMembers[num].skill = generatedCurrentPlayer.skill;
				squadMembers.Sort((DatabasePlayer m1, DatabasePlayer m2) => m2.skill.CompareTo(m1.skill));
			}
			ShowSquadMembers(squad, squadMembers);
			break;
		}
		}
	}

	public void Animate(bool showTab, bool instant)
	{
		mIsActive = showTab;
		if (mIsActive && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
			InitGUIValues();
		}
		if (base.gameObject.activeSelf)
		{
			TweenAlpha.Begin(panel.gameObject, (!instant) ? (GuiScreenSingle<SquadScreen>.instance.dur * 2f) : 0.01f, (!mIsActive) ? 0f : 1f).onFinished = delegate
			{
				if (!mIsActive)
				{
					base.gameObject.SetActive(value: false);
					DoAfterHide();
				}
			};
		}
		else if (!mIsActive)
		{
			InstantHideTab();
		}
	}

	public void InitGUIValues()
	{
		waitingPart.SetActive(value: true);
		contentPart.SetActive(value: false);
		statsTotalGrid.MakeEmpty();
		statsBestGrid.MakeEmpty();
		DatabaseSquad squad = Singleton<ServerResultsCache>.instance.GetSquad(GameLoginManager.currentPlayer.squadName, ommitTime: true);
		if (squad == null)
		{
			Singleton<BeanstalkServerManager>.instance.GetSquadDetails(GameLoginManager.currentPlayer.squadName);
		}
		else
		{
			ShowSquadDetails(squad);
		}
	}

	private void ShowSquadDetails(DatabaseSquad squad)
	{
		bool flag = Singleton<GameVariables>.instance.MaxSquadDisplayLevel() <= squad.rank;
		squadRank.text = MiscTools.FormatBigNumber(squad.rank);
		if (flag)
		{
			squadXP.text = string.Format("{0} / {1}", MiscTools.FormatBigNumberLong(squad.levelExperience), Localization.Localize("ID_MAX"));
			progressXP.fillAmount = 0f;
		}
		else
		{
			long num = Singleton<GameVariables>.instance.SquadExperience(squad.rank);
			squadXP.text = $"{MiscTools.FormatBigNumberLong(squad.levelExperience)} / {MiscTools.FormatBigNumberLong(num)}";
			progressXP.fillAmount = Mathf.Clamp01((float)squad.levelExperience / (float)num);
		}
		int nextSquadRankIncreaseSize = Singleton<GameVariables>.instance.GetNextSquadRankIncreaseSize(squad.rank);
		nextSquadSizePart.SetActive(nextSquadRankIncreaseSize > 0);
		maxSquadSizePart.SetActive(nextSquadRankIncreaseSize < 1);
		membersHeader.text = string.Format("{0} / {1} {2}", squad.size, Singleton<GameVariables>.instance.GetSquadRankSize(squad.rank), Localization.Localize("ID_MEMBERS"));
		squadSizeIncrease.text = string.Format("{0} {1}", Localization.Localize("ID_SQUADSIZEINCREASEATSQUADRANK"), nextSquadRankIncreaseSize);
		Singleton<BeanstalkServerManager>.instance.GetAllSquadMembers(GameLoginManager.currentPlayer.squadName);
	}

	private void ShowSquadMembers(DatabaseSquad squad, List<DatabasePlayer> squadMembers)
	{
		if (waitingPart.activeSelf)
		{
			waitingPart.SetActive(value: false);
			contentPart.SetActive(value: true);
			CreateData(squad, squadMembers);
			statsTotalGrid.init(mSquadTotalStats.Count, StatTotalInstantiate, StatFree, draggablePanel);
			float num = Mathf.Abs(totalPart.transform.localPosition.y) + 165f + Mathf.Abs(statsTotalGrid.helperMin.localPosition.y - statsTotalGrid.helperMax.localPosition.y);
			bestPart.transform.localPosition = new Vector3(0f, 0f - num, 0f);
			statsBestGrid.offsetGrid = new Vector2(0f, num);
			statsBestGrid.init(mSquadBestStats.Count, StatBestInstantiate, StatFree, draggablePanel);
			if (!draggablePanel.onePanelDisabled)
			{
				draggablePanel.AlignToPos(instant: false);
			}
		}
		else
		{
			UpdateData(squad, squadMembers);
			UpdateShownRecords();
		}
	}

	public void DoAfterHide()
	{
		statsTotalGrid.MakeEmpty();
		statsBestGrid.MakeEmpty();
	}

	public void InstantHideTab()
	{
		TweenAlpha component = panel.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		base.gameObject.SetActive(value: false);
		DoAfterHide();
	}

	private void CreateData(DatabaseSquad squad, List<DatabasePlayer> squadMembers)
	{
		mSquadTotalStats.Clear();
		mSquadBestStats.Clear();
		int index = 0;
		int index2 = 0;
		int index3 = 0;
		int index4 = 0;
		int index5 = 0;
		int index6 = 0;
		int index7 = 0;
		int index8 = 0;
		int index9 = 0;
		int index10 = 0;
		int index11 = 0;
		squadMembers.Sort((DatabasePlayer player1, DatabasePlayer player2) => player2.skill.CompareTo(player1.skill));
		int num = squadMembers[0].armyPowerX10;
		float num2 = (float)squadMembers[0].skill * Singleton<GameVariables>.instance.GetSquadMedalWeight(0);
		for (int num3 = 1; num3 < squadMembers.Count; num3++)
		{
			num += squadMembers[num3].armyPowerX10;
			num2 += (float)squadMembers[num3].skill * Singleton<GameVariables>.instance.GetSquadMedalWeight(num3);
			if (squadMembers[num3].statisticsData != null)
			{
				if (squadMembers[index].statisticsData.battlesPlayed < squadMembers[num3].statisticsData.battlesPlayed)
				{
					index = num3;
				}
				if (squadMembers[index2].statisticsData.battlesWon < squadMembers[num3].statisticsData.battlesWon)
				{
					index2 = num3;
				}
				if (squadMembers[index3].statisticsData.kills < squadMembers[num3].statisticsData.kills)
				{
					index3 = num3;
				}
				if (squadMembers[index4].statisticsData.accuracy < squadMembers[num3].statisticsData.accuracy)
				{
					index4 = num3;
				}
				if (squadMembers[index5].statisticsData.winLoseRatio < squadMembers[num3].statisticsData.winLoseRatio)
				{
					index5 = num3;
				}
				if (squadMembers[index6].statisticsData.unitsDeployed < squadMembers[num3].statisticsData.unitsDeployed)
				{
					index6 = num3;
				}
				if (squadMembers[index7].statisticsData.cardsPlayed < squadMembers[num3].statisticsData.cardsPlayed)
				{
					index7 = num3;
				}
			}
			if (squadMembers[index8].squadPoints < squadMembers[num3].squadPoints)
			{
				index8 = num3;
			}
			if (squadMembers[index9].skill < squadMembers[num3].skill)
			{
				index9 = num3;
			}
			if (squadMembers[index10].armyPower < squadMembers[num3].armyPower)
			{
				index10 = num3;
			}
			if (squadMembers[index11].reputation < squadMembers[num3].reputation)
			{
				index11 = num3;
			}
		}
		mSquadTotalStats.Add(SquadStatInternal.CreateSquadStatInt(Localization.Localize("ID_STAT_BATTLESPLAYED"), squad.battlesPlayed));
		mSquadTotalStats.Add(SquadStatInternal.CreateSquadStatInt(Localization.Localize("ID_STAT_WINS"), squad.battlesWon));
		mSquadTotalStats.Add(SquadStatInternal.CreateSquadStatInt(Localization.Localize("ID_STAT_LOSSES"), squad.battlesLost));
		mSquadTotalStats.Add(SquadStatInternal.CreateSquadStatFloat(Localization.Localize("ID_STAT_WINLOSSRATIO"), squad.winLoseRatio));
		mSquadTotalStats.Add(SquadStatInternal.CreateSquadStatInt(Localization.Localize("ID_STAT_KILLS"), squad.kills));
		mSquadTotalStats.Add(SquadStatInternal.CreateSquadStatInt(Localization.Localize("ID_STAT_UNITSDEPLOYED"), squad.unitsDeployed));
		mSquadTotalStats.Add(SquadStatInternal.CreateSquadStatInt(Localization.Localize("ID_STAT_WARCARDSPLAYED"), squad.cardsPlayed));
		mSquadTotalStats.Add(SquadStatInternal.CreateSquadStatInt(Localization.Localize("ID_STAT_SQUADWARSWINS"), squad.squadWarWins));
		mSquadTotalStats.Add(SquadStatInternal.CreateSquadStatPicture(Localization.Localize("ID_STAT_SQUADPOINTSBEST"), squad.squadPointsBest, "menu-squadpoint-ico", Color.white, Colours.goldWar));
		mSquadTotalStats.Add(SquadStatInternal.CreateSquadStatPicture(Localization.Localize("ID_STAT_TIERSCOMPLETED"), squad.tiersCompleted, "menu-sidetab-challenge", Colours.blue, Colours.blue));
		mSquadTotalStats.Add(SquadStatInternal.CreateSquadStatPicture(Localization.Localize("ID_ARMYPOWER"), num, "menu-armypower-ico", Color.white, Colours.greenArmyPower));
		mSquadTotalStats.Add(SquadStatInternal.CreateSquadStatPicture(Localization.Localize("ID_SQUADMEDALSBIG"), MiscTools.RoundToInt(num2), "menu-medals-ico-big", Color.white, Colours.blue));
		mSquadBestStats.Add(SquadStatInternal.CreateSquadStatPlayerInt(Localization.Localize("ID_STAT_MOSTBATTLESPLAYED"), (squadMembers[index].statisticsData != null) ? squadMembers[index].statisticsData.battlesPlayed : (-1), squadMembers[index], Colours.blue));
		mSquadBestStats.Add(SquadStatInternal.CreateSquadStatPlayerInt(Localization.Localize("ID_STAT_MOSTWINS"), (squadMembers[index2].statisticsData != null) ? squadMembers[index2].statisticsData.battlesWon : (-1), squadMembers[index2], Colours.blue));
		mSquadBestStats.Add(SquadStatInternal.CreateSquadStatPlayerInt(Localization.Localize("ID_STAT_MOSTKILLS"), (squadMembers[index3].statisticsData != null) ? squadMembers[index3].statisticsData.kills : (-1), squadMembers[index3], Colours.blue));
		mSquadBestStats.Add(SquadStatInternal.CreateSquadStatPlayerPercent(Localization.Localize("ID_STAT_BESTACCURACY"), (squadMembers[index4].statisticsData != null) ? ((int)(squadMembers[index4].statisticsData.accuracy * 100f)) : (-1), squadMembers[index4]));
		mSquadBestStats.Add(SquadStatInternal.CreateSquadStatPlayerFloat(Localization.Localize("ID_STAT_BESTWLRATIO"), (squadMembers[index5].statisticsData != null) ? squadMembers[index5].statisticsData.winLoseRatio : (-1f), squadMembers[index5]));
		mSquadBestStats.Add(SquadStatInternal.CreateSquadStatPlayerInt(Localization.Localize("ID_STAT_MOSTUNITSDEPLOYED"), (squadMembers[index6].statisticsData != null) ? squadMembers[index6].statisticsData.unitsDeployed : (-1), squadMembers[index6], Colours.blue));
		mSquadBestStats.Add(SquadStatInternal.CreateSquadStatPlayerInt(Localization.Localize("ID_STAT_MOSTWARCARDSPLAYED"), (squadMembers[index7].statisticsData != null) ? squadMembers[index7].statisticsData.cardsPlayed : (-1), squadMembers[index7], Colours.blue));
		mSquadBestStats.Add(SquadStatInternal.CreateSquadStatPlayerInt(Localization.Localize("ID_STAT_MOSTSQUADPOINTS"), squadMembers[index8].squadPoints, squadMembers[index8], Colours.goldWar));
		mSquadBestStats.Add(SquadStatInternal.CreateSquadStatPlayerInt(Localization.Localize("ID_STAT_MOSTMEDALS"), squadMembers[index9].skill, squadMembers[index9], Colours.blue));
		mSquadBestStats.Add(SquadStatInternal.CreateSquadStatPlayerInt(Localization.Localize("ID_STAT_MOSTPOWERFULLARMY"), squadMembers[index10].armyPowerX10, squadMembers[index10], Colours.greenArmyPower));
		mSquadBestStats.Add(SquadStatInternal.CreateSquadStatPlayerInt(Localization.Localize("ID_STAT_MOSTREPUTATIONPOINTS"), squadMembers[index11].reputation, squadMembers[index11], Colours.pink));
	}

	private void UpdateData(DatabaseSquad squad, List<DatabasePlayer> squadMembers)
	{
		int index = 0;
		int index2 = 0;
		int index3 = 0;
		int index4 = 0;
		int index5 = 0;
		int index6 = 0;
		int index7 = 0;
		int index8 = 0;
		int index9 = 0;
		int index10 = 0;
		int index11 = 0;
		squadMembers.Sort((DatabasePlayer player1, DatabasePlayer player2) => player2.skill.CompareTo(player1.skill));
		int num = squadMembers[0].armyPowerX10;
		float num2 = (float)squadMembers[0].skill * Singleton<GameVariables>.instance.GetSquadMedalWeight(0);
		for (int num3 = 1; num3 < squadMembers.Count; num3++)
		{
			num += squadMembers[num3].armyPowerX10;
			num2 += (float)squadMembers[num3].skill * Singleton<GameVariables>.instance.GetSquadMedalWeight(num3);
			if (squadMembers[num3].statisticsData != null)
			{
				if (squadMembers[index].statisticsData.battlesPlayed < squadMembers[num3].statisticsData.battlesPlayed)
				{
					index = num3;
				}
				if (squadMembers[index2].statisticsData.battlesWon < squadMembers[num3].statisticsData.battlesWon)
				{
					index2 = num3;
				}
				if (squadMembers[index3].statisticsData.kills < squadMembers[num3].statisticsData.kills)
				{
					index3 = num3;
				}
				if (squadMembers[index4].statisticsData.accuracy < squadMembers[num3].statisticsData.accuracy)
				{
					index4 = num3;
				}
				if (squadMembers[index5].statisticsData.winLoseRatio < squadMembers[num3].statisticsData.winLoseRatio)
				{
					index5 = num3;
				}
				if (squadMembers[index6].statisticsData.unitsDeployed < squadMembers[num3].statisticsData.unitsDeployed)
				{
					index6 = num3;
				}
				if (squadMembers[index7].statisticsData.cardsPlayed < squadMembers[num3].statisticsData.cardsPlayed)
				{
					index7 = num3;
				}
			}
			if (squadMembers[index8].squadPoints < squadMembers[num3].squadPoints)
			{
				index8 = num3;
			}
			if (squadMembers[index9].skill < squadMembers[num3].skill)
			{
				index9 = num3;
			}
			if (squadMembers[index10].armyPower < squadMembers[num3].armyPower)
			{
				index10 = num3;
			}
			if (squadMembers[index11].reputation < squadMembers[num3].reputation)
			{
				index11 = num3;
			}
		}
		mSquadTotalStats[0].number = squad.battlesPlayed;
		mSquadTotalStats[1].number = squad.battlesWon;
		mSquadTotalStats[2].number = squad.battlesLost;
		mSquadTotalStats[3].floatNumber = squad.winLoseRatio;
		mSquadTotalStats[4].number = squad.kills;
		mSquadTotalStats[5].number = squad.unitsDeployed;
		mSquadTotalStats[6].number = squad.cardsPlayed;
		mSquadTotalStats[7].number = squad.squadWarWins;
		mSquadTotalStats[8].number = squad.squadPointsBest;
		mSquadTotalStats[9].number = squad.tiersCompleted;
		mSquadTotalStats[10].number = num;
		mSquadTotalStats[11].number = MiscTools.RoundToInt(num2);
		mSquadBestStats[0].player = squadMembers[index];
		mSquadBestStats[0].number = ((squadMembers[index].statisticsData != null) ? squadMembers[index].statisticsData.battlesPlayed : (-1));
		mSquadBestStats[1].player = squadMembers[index2];
		mSquadBestStats[1].number = ((squadMembers[index2].statisticsData != null) ? squadMembers[index2].statisticsData.battlesWon : (-1));
		mSquadBestStats[2].player = squadMembers[index3];
		mSquadBestStats[2].number = ((squadMembers[index3].statisticsData != null) ? squadMembers[index3].statisticsData.kills : (-1));
		mSquadBestStats[3].player = squadMembers[index4];
		mSquadBestStats[3].number = ((squadMembers[index4].statisticsData != null) ? ((int)(squadMembers[index4].statisticsData.accuracy * 100f)) : (-1));
		mSquadBestStats[4].player = squadMembers[index5];
		mSquadBestStats[4].floatNumber = ((squadMembers[index5].statisticsData != null) ? squadMembers[index5].statisticsData.winLoseRatio : (-1f));
		mSquadBestStats[5].player = squadMembers[index6];
		mSquadBestStats[5].number = ((squadMembers[index6].statisticsData != null) ? squadMembers[index6].statisticsData.unitsDeployed : (-1));
		mSquadBestStats[6].player = squadMembers[index7];
		mSquadBestStats[6].number = ((squadMembers[index7].statisticsData != null) ? squadMembers[index7].statisticsData.cardsPlayed : (-1));
		mSquadBestStats[7].player = squadMembers[index8];
		mSquadBestStats[7].number = squadMembers[index8].squadPoints;
		mSquadBestStats[8].player = squadMembers[index9];
		mSquadBestStats[8].number = squadMembers[index9].skill;
		mSquadBestStats[9].player = squadMembers[index10];
		mSquadBestStats[9].number = squadMembers[index10].armyPowerX10;
		mSquadBestStats[10].player = squadMembers[index11];
		mSquadBestStats[10].number = squadMembers[index11].reputation;
	}

	private Transform StatTotalInstantiate(int index)
	{
		if (index >= 0 && index < mSquadTotalStats.Count)
		{
			SquadStatInternal squadStat = mSquadTotalStats[index];
			SquadStatsRecord squadStatsRecord = Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(squadStatsRecordPrefab, statsTotalGrid.gameObject, string.Format("{0} Squad Total Stat", index.ToString("D2"))) as SquadStatsRecord;
			if (squadStatsRecord != null)
			{
				squadStatsRecord.InitializeSquadStat(squadStat);
				return squadStatsRecord.transform;
			}
		}
		return null;
	}

	private Transform StatBestInstantiate(int index)
	{
		if (index >= 0 && index < mSquadBestStats.Count)
		{
			SquadStatInternal squadStat = mSquadBestStats[index];
			SquadStatsRecord squadStatsRecord = Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(squadStatsRecordPrefab, statsBestGrid.gameObject, string.Format("{0} Squad Best Stat", index.ToString("D2"))) as SquadStatsRecord;
			if (squadStatsRecord != null)
			{
				squadStatsRecord.InitializeSquadStat(squadStat);
				return squadStatsRecord.transform;
			}
		}
		return null;
	}

	private void StatFree(Transform obj)
	{
		if (!(obj == null))
		{
			SquadStatsRecord component = obj.GetComponent<SquadStatsRecord>();
			if (component != null)
			{
				component.DestroyPooled();
			}
		}
	}

	private void UpdateShownRecords()
	{
		for (int i = 0; i < statsTotalGrid.containItems; i++)
		{
			Transform itemOnIndex = statsTotalGrid.GetItemOnIndex(i);
			if (itemOnIndex != null)
			{
				SquadStatsRecord component = itemOnIndex.GetComponent<SquadStatsRecord>();
				if (component != null)
				{
					component.InitializeSquadStat(mSquadTotalStats[i]);
				}
			}
		}
		for (int j = 0; j < statsBestGrid.containItems; j++)
		{
			Transform itemOnIndex2 = statsBestGrid.GetItemOnIndex(j);
			if (itemOnIndex2 != null)
			{
				SquadStatsRecord component2 = itemOnIndex2.GetComponent<SquadStatsRecord>();
				if (component2 != null)
				{
					component2.FreeTexture();
					component2.InitializeSquadStat(mSquadBestStats[j]);
				}
			}
		}
	}
}
