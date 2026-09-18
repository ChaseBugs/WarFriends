using System;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class MainScreenLeagueEnding : Core_BaseScript
{
	private enum Type
	{
		None,
		League,
		SquadWar,
		Locked
	}

	[Header("None")]
	public GameObject leaguePositionHeaderPart;

	[Header("Player League")]
	public GameObject playerLeaguePart;

	public UILabel playerLeagueTimer;

	[Header("Squad War")]
	public GameObject squadWarPart;

	public UILabel squadWarTimer;

	public UILabel squadWarPositionAndName;

	public UISprite squadWarGoldIcon;

	public UILabel squadWarReward;

	private bool mSquadWarsTimer;

	private int mSquadWarsEnd;

	private bool mLeagueTimer;

	private int mLeagueEnd;

	private Type currentLook
	{
		get
		{
			if (!Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
			{
				return Type.Locked;
			}
			if (LevelManager.instance.isMainScreenPartsLocked)
			{
				return Type.Locked;
			}
			if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) && showSquadWarsReminder)
			{
				return Type.SquadWar;
			}
			if (!GameLoginManager.currentPlayer.isInBeginnersLeague && GameLoginManager.currentPlayer.isInLeague && showLeagueReminder)
			{
				return Type.League;
			}
			return Type.None;
		}
	}

	private bool showLeagueReminder
	{
		get
		{
			int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.LeagueReminder).FLOATVALUE * 3600;
			return mLeagueEnd >= currentTimestamp && mLeagueEnd <= num + currentTimestamp;
		}
	}

	private bool showSquadWarsReminder
	{
		get
		{
			int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsReminder).FLOATVALUE * 3600;
			return mSquadWarsEnd >= currentTimestamp && mSquadWarsEnd <= num + currentTimestamp;
		}
	}

	public void SetSquadWarsEnd(int time)
	{
		mSquadWarsEnd = time;
		if (base.gameObject.activeInHierarchy)
		{
			InitGuiValues();
		}
	}

	public void SetLeagueEnd(int time)
	{
		mLeagueEnd = time;
		if (base.gameObject.activeInHierarchy)
		{
			InitGuiValues();
		}
	}

	public void InitEvents()
	{
		SquadWarManager.instance.SquadWarSquadsUpdated += OnSquadsUpdated;
	}

	private void OnSquadsUpdated()
	{
		if (!GuiScreenSingle<MainScreen>.instance.isShowed || !Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			return;
		}
		string squadName = GameLoginManager.currentPlayer.squadName;
		if (string.IsNullOrEmpty(squadName))
		{
			HideSquadWarsEnd();
			return;
		}
		DatabaseSquad squad = Singleton<ServerResultsCache>.instance.GetSquad(squadName, ommitTime: true);
		List<DatabaseSquad> squadWarSquads = SquadWarManager.instance.GetSquadWarSquads();
		int num = squadWarSquads.FindIndex((DatabaseSquad s1) => s1.name == squadName);
		bool flag = squadWarSquads.Count > (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsLowerSquadLimit).FLOATVALUE;
		ShowSquadWarsEnd(!flag, num + 1, squadWarSquads.Count, squad.squadWarDivision, squadName);
	}

	public void InitControls()
	{
	}

	public void InitGuiValues()
	{
		if (!GuiScreenSingle<MainScreen>.instance.isShowed)
		{
			return;
		}
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.updateCounterBySecond = (Action)Delegate.Remove(instance.updateCounterBySecond, new Action(UpdateEverySecond));
		mLeagueTimer = false;
		mSquadWarsTimer = false;
		Type type = currentLook;
		if (type == Type.Locked)
		{
			if (squadWarPart.activeSelf)
			{
				squadWarPart.SetActive(value: false);
			}
			if (playerLeaguePart.activeSelf)
			{
				playerLeaguePart.SetActive(value: false);
			}
			if (leaguePositionHeaderPart.activeSelf)
			{
				leaguePositionHeaderPart.SetActive(value: false);
			}
		}
		if (type == Type.None)
		{
			if (squadWarPart.activeSelf)
			{
				squadWarPart.SetActive(value: false);
			}
			if (playerLeaguePart.activeSelf)
			{
				playerLeaguePart.SetActive(value: false);
			}
			if (!leaguePositionHeaderPart.activeSelf)
			{
				leaguePositionHeaderPart.SetActive(value: true);
			}
		}
		if (type == Type.League)
		{
			if (squadWarPart.activeSelf)
			{
				squadWarPart.SetActive(value: false);
			}
			if (!playerLeaguePart.activeSelf)
			{
				playerLeaguePart.SetActive(value: true);
			}
			if (leaguePositionHeaderPart.activeSelf)
			{
				leaguePositionHeaderPart.SetActive(value: false);
			}
			ShowLeagueEnd();
			CounterManager instance2 = Singleton<CounterManager>.instance;
			instance2.updateCounterBySecond = (Action)Delegate.Combine(instance2.updateCounterBySecond, new Action(UpdateEverySecond));
		}
		if (type == Type.SquadWar)
		{
			if (!squadWarPart.activeSelf)
			{
				squadWarPart.SetActive(value: true);
			}
			if (playerLeaguePart.activeSelf)
			{
				playerLeaguePart.SetActive(value: false);
			}
			if (leaguePositionHeaderPart.activeSelf)
			{
				leaguePositionHeaderPart.SetActive(value: false);
			}
			DatabaseSquad squad = Singleton<ServerResultsCache>.instance.GetSquad(GameLoginManager.currentPlayer.squadName, ommitTime: true);
			if (squad != null)
			{
				Singleton<BeanstalkServerManager>.instance.GetSquadsFromRound(squad.roundId);
			}
			CounterManager instance3 = Singleton<CounterManager>.instance;
			instance3.updateCounterBySecond = (Action)Delegate.Combine(instance3.updateCounterBySecond, new Action(UpdateEverySecond));
		}
	}

	public void DoAfterHide()
	{
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.updateCounterBySecond = (Action)Delegate.Remove(instance.updateCounterBySecond, new Action(UpdateEverySecond));
	}

	private void UpdateEverySecond()
	{
		bool flag = false;
		if (mSquadWarsTimer)
		{
			if (showSquadWarsReminder)
			{
				FillSquadWarsEndTime();
			}
			else
			{
				HideSquadWarsEnd();
			}
		}
		else if (showSquadWarsReminder && !mLeagueTimer)
		{
			flag = true;
		}
		if (mLeagueTimer)
		{
			if (showLeagueReminder)
			{
				FillLeagueEndTime();
			}
			else
			{
				HideLeagueEnd();
			}
		}
		else if (showLeagueReminder && !mSquadWarsTimer)
		{
			flag = true;
		}
		if (flag)
		{
			InitGuiValues();
		}
	}

	private void ShowLeagueEnd()
	{
		mLeagueTimer = true;
		playerLeaguePart.SetActive(value: true);
		FillLeagueEndTime();
	}

	private void FillLeagueEndTime()
	{
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		int num = mLeagueEnd - currentTimestamp;
		playerLeagueTimer.text = Localization.LocalizeFormat("ID_PLAYERLEAGUEENDSIN", MiscTools.PrintableTime(num, "ID_READYTIME", string.Empty));
		MiscTools.SetUILabelRescale(playerLeagueTimer, 30f, 20f, 420);
	}

	private void HideLeagueEnd()
	{
		mLeagueTimer = false;
		playerLeaguePart.SetActive(value: false);
	}

	private void ShowSquadWarsEnd(bool lowSquads, int position, int count, int division, string squadName)
	{
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (!mLeagueTimer && currentTimestamp <= mSquadWarsEnd)
		{
			mSquadWarsTimer = true;
			squadWarPart.SetActive(value: true);
			FillSquadWarsEndTime();
			squadWarPositionAndName.text = $"{MiscTools.FormatNumberToOrdinalPoint(position)} {squadName}";
			MiscTools.SetUILabelRescale(squadWarPositionAndName, 27f, 20f);
			int tier = MiscTools.SquadWarTier(position, count);
			int num = Singleton<GameVariables>.instance.SquadWarsRewardForSquad(tier, division);
			squadWarReward.text = MiscTools.FormatBigNumber(num);
			float num2 = 33f + squadWarReward.relativeSize.x * squadWarReward.transform.localScale.x + 14f;
			squadWarGoldIcon.transform.localPosition = squadWarGoldIcon.transform.localPosition.ReplaceX(0f - num2);
		}
	}

	private void FillSquadWarsEndTime()
	{
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		int num = mSquadWarsEnd - currentTimestamp;
		squadWarTimer.text = Localization.LocalizeFormat("ID_SQUADWAREND", MiscTools.PrintableTime(num, "ID_READYTIME", string.Empty));
		MiscTools.SetUILabelRescale(squadWarTimer, 27f, 20f, 486);
	}

	private void HideSquadWarsEnd()
	{
		mSquadWarsTimer = false;
		squadWarPart.SetActive(value: false);
	}
}
