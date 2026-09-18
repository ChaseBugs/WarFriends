using System;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class HeaderLeagueButton : GuiElementSingle<HeaderLeagueButton>
{
	[Header("Core")]
	public GameObject parentObject;

	[Header("League Arc")]
	public LeagueArcGuiElement leagueArc;

	[Header("Hints")]
	public GameObject hintsPart;

	public UILabel hintFirstLineLabel;

	public UITable hintsSecondLineTable;

	public UILabel hintsSecondLineFirstLabel;

	public UILabel hintsSecondLineLastLabel;

	private int mWidthForHints = 237;

	private bool mGameEnded;

	public override void InitEvents()
	{
		base.InitEvents();
		leagueArc.InitEvents();
		Singleton<GameController>.instance.GameEnded += OnGameEnded;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataLoaded;
		ServerResultsCache serverResultsCache = Singleton<ServerResultsCache>.instance;
		serverResultsCache.PlayerLeagueProcessingChanged = (Action)Delegate.Combine(serverResultsCache.PlayerLeagueProcessingChanged, new Action(OnPlayerLeagueProcessingChanged));
	}

	private void OnGameEnded(GameController.GameEndReason endReason)
	{
		mGameEnded = true;
	}

	private void OnDataLoaded(DatabaseAction action)
	{
		if (isShowed)
		{
			if (action == DatabaseAction.DebugChangeLeague || action == DatabaseAction.DebugChangeDivision || action == DatabaseAction.DebugChangeMedals)
			{
				InitGuiValues();
			}
		}
	}

	private void OnPlayerLeagueProcessingChanged()
	{
		if (isShowed)
		{
			InitializeHints();
		}
	}

	public override void InitControls()
	{
		mWidthForHints = (int)UIRoot.list[0].activeWidth - 1683;
		UIEventListener uIEventListener = UIEventListener.Get(leagueArc.boxCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MedalsClicked));
		LeagueArcManager.instance.SorterPlayersLeague += OnSorterPlayersLeague;
		leagueArc.InitControls();
	}

	private void MedalsClicked(GameObject go)
	{
		if (GuiScreenSingle<LeaguesScreen>.instance.isShowed)
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiScreenSingle<LeaguesScreen>.instance.ShowPlayerLeague();
		}
		else if (!GuiScreenSingle<CardSelectionScreen>.instance.isShowed && !Singleton<GameController>.instance.isTutorial && !GuiScreenSingle<EndScreen>.instance.canShowLvlUp)
		{
			DialogManager.instance.HideAllDialogs();
			SoundsManager.Instance.PlayButtonClickedSound();
			bool flag = GuiScreenSingle<EndScreen>.instance.isShowed;
			GuiScreenSingle<LeaguesScreen>.instance.ShowPlayerLeague();
			if (flag)
			{
				GuiScreenSingle<LeaguesScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
			}
		}
	}

	private void OnSorterPlayersLeague(int myPosition, List<DatabasePlayer> databasePlayers)
	{
		if (base.gameObject.activeSelf && base.gameObject.activeInHierarchy && (!GuiScreenSingle<EndScreen>.instance.isShowed || GuiScreenSingle<EndScreen>.instance.results.leagueArc.gameObject.activeInHierarchy))
		{
			InitializeHintInLeague(myPosition, databasePlayers);
		}
	}

	public override void InitGUIValues()
	{
		if (!mGameEnded)
		{
			InitGuiValues();
		}
		else if (!Singleton<GameController>.instance.isTutorial)
		{
			InitializeTo(LeagueArcManager.instance.GetPreviousData(), LeagueArcManager.instance.GetPreviousPlayers());
		}
		parentObject.SetActive(!Singleton<GameController>.instance.isTutorial);
		mGameEnded = false;
	}

	public void InitGuiValues()
	{
		InitializeHints();
		leagueArc.InitGuiValues();
	}

	private void InitializeHints()
	{
		if (!Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			InitializeHintEmpty();
		}
		else if (LevelManager.instance.isMainScreenPartsLocked)
		{
			InitializeHintEmpty();
		}
		else if (GameLoginManager.currentPlayer.isInBeginnersLeague)
		{
			InitializeHintEmpty();
		}
		else if (Singleton<ServerResultsCache>.instance.isPlayerLeagueProcessing)
		{
			InitializeHintProcessing();
		}
		else if (GameLoginManager.currentPlayer.isInLeague)
		{
			InitializeHintEmpty();
		}
		else
		{
			InitializeHintNotInLeague();
		}
		hintsPart.transform.localPosition = hintsPart.transform.localPosition.ReplaceY(4f);
		TweenPosition component = hintsPart.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
	}

	public void InitializeTo(LeagueArcData data, List<DatabasePlayer> databasePlayers, bool onlyHints = false)
	{
		if (onlyHints)
		{
			leagueArc.StopAnimations();
			leagueArc.InitializeTo(data);
		}
		if (data.isBeginnersLeague)
		{
			InitializeHintEmpty();
		}
		else if (data.isLeagueProcessing)
		{
			InitializeHintProcessing();
		}
		else if (data.isInLeague)
		{
			if (databasePlayers == null)
			{
				databasePlayers = new List<DatabasePlayer>();
				databasePlayers.Add(GameLoginManager.currentPlayer);
			}
			int myPosition = databasePlayers.FindIndex((DatabasePlayer p1) => p1.id == GameLoginManager.currentPlayer.id) + 1;
			InitializeHintInLeague(myPosition, databasePlayers);
		}
		else
		{
			InitializeHintNotInLeague();
		}
	}

	public void AnimateHint()
	{
		Vector3 pos = hintsPart.transform.localPosition.ReplaceY(120f);
		TweenPosition.Begin(hintsPart, 0.5f, pos).onFinished = delegate
		{
			if (LeagueArcManager.instance.GetWasDataUpdated())
			{
				InitializeTo(LeagueArcManager.instance.GetCurrentData(), LeagueArcManager.instance.GetCurrentPlayers(), onlyHints: true);
			}
			else
			{
				InitializeHintEmpty();
			}
			Vector3 pos2 = hintsPart.transform.localPosition.ReplaceY(4f);
			TweenPosition.Begin(hintsPart, 0.5f, pos2).onFinished = null;
		};
	}

	private void InitializeHintEmpty()
	{
		hintFirstLineLabel.text = string.Empty;
		hintFirstLineLabel.transform.localPosition = hintFirstLineLabel.transform.localPosition.ReplaceY(0f);
		hintsSecondLineTable.gameObject.SetActive(value: false);
		RescaleHintsAndRepositThem();
	}

	private void InitializeHintProcessing()
	{
		hintFirstLineLabel.text = Localization.Localize("ID_PLAYERLEAGUEPROCESSING");
		hintFirstLineLabel.transform.localPosition = hintFirstLineLabel.transform.localPosition.ReplaceY(0f);
		hintsSecondLineTable.gameObject.SetActive(value: false);
		RescaleHintsAndRepositThem();
	}

	private void InitializeHintNotInLeague()
	{
		hintFirstLineLabel.text = Localization.Localize("ID_PLAYPVPBATTLETOENTERLEAGUE");
		hintFirstLineLabel.transform.localPosition = hintFirstLineLabel.transform.localPosition.ReplaceY(0f);
		hintsSecondLineTable.gameObject.SetActive(value: false);
		RescaleHintsAndRepositThem();
	}

	private void InitializeHintInLeague(int myPosition, List<DatabasePlayer> databasePlayers)
	{
		League leagueTier = GameLoginManager.currentPlayer.leagueTier;
		int count = databasePlayers.Count;
		int num = Singleton<GameVariables>.instance.LeaguePositionPromote(count, leagueTier);
		int num2 = Singleton<GameVariables>.instance.LeaguePositionDemote(count, leagueTier);
		bool flag = count > (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.NotEnoughPlayersForPlayerLeague).FLOATVALUE;
		LeagueType leagueType = Singleton<GameVariables>.instance.LeaguePositionType(!flag, leagueTier, myPosition, num, num2);
		int medalsBalance = databasePlayers[myPosition - 1].medalsBalance;
		if (!flag)
		{
			if (myPosition == 1)
			{
				hintFirstLineLabel.text = Localization.Localize("ID_KEEPITUPYOUARENUMBERONE");
				hintFirstLineLabel.transform.localPosition = hintFirstLineLabel.transform.localPosition.ReplaceY(0f);
				hintsSecondLineTable.gameObject.SetActive(value: false);
			}
			else
			{
				int num3 = databasePlayers[0].medalsBalance - medalsBalance + 1;
				hintFirstLineLabel.text = Localization.Localize("ID_TOBENUMBERONE1");
				hintFirstLineLabel.transform.localPosition = hintFirstLineLabel.transform.localPosition.ReplaceY(22f);
				hintsSecondLineTable.gameObject.SetActive(value: true);
				hintsSecondLineFirstLabel.text = Localization.Localize("ID_TOBENUMBERONE2");
				hintsSecondLineLastLabel.text = MiscTools.FormatMedalsDifference(num3);
			}
		}
		else if (myPosition == 1)
		{
			hintFirstLineLabel.text = Localization.Localize("ID_KEEPITUPYOUARENUMBERONE");
			hintFirstLineLabel.transform.localPosition = hintFirstLineLabel.transform.localPosition.ReplaceY(0f);
			hintsSecondLineTable.gameObject.SetActive(value: false);
		}
		else
		{
			switch (leagueType)
			{
			case LeagueType.Promote:
			case LeagueType.Top:
			{
				int num6 = databasePlayers[0].medalsBalance - medalsBalance + 1;
				hintFirstLineLabel.text = Localization.Localize("ID_TOBENUMBERONE1");
				hintFirstLineLabel.transform.localPosition = hintFirstLineLabel.transform.localPosition.ReplaceY(22f);
				hintsSecondLineTable.gameObject.SetActive(value: true);
				hintsSecondLineFirstLabel.text = Localization.Localize("ID_TOBENUMBERONE2");
				hintsSecondLineLastLabel.text = MiscTools.FormatMedalsDifference(num6);
				break;
			}
			case LeagueType.Stay:
			{
				int num5 = databasePlayers[num - 1].medalsBalance - medalsBalance + 1;
				hintFirstLineLabel.text = Localization.Localize("ID_GETAPROMOTION1");
				hintFirstLineLabel.transform.localPosition = hintFirstLineLabel.transform.localPosition.ReplaceY(22f);
				hintsSecondLineTable.gameObject.SetActive(value: true);
				hintsSecondLineFirstLabel.text = Localization.Localize("ID_GETAPROMOTION2");
				hintsSecondLineLastLabel.text = MiscTools.FormatMedalsDifference(num5);
				break;
			}
			default:
			{
				int num4 = databasePlayers[num2 - 2].medalsBalance - medalsBalance + 1;
				hintFirstLineLabel.text = Localization.Localize("ID_AVOIDRELEGATION1");
				hintFirstLineLabel.transform.localPosition = hintFirstLineLabel.transform.localPosition.ReplaceY(22f);
				hintsSecondLineTable.gameObject.SetActive(value: true);
				hintsSecondLineFirstLabel.text = Localization.Localize("ID_AVOIDRELEGATION2");
				hintsSecondLineLastLabel.text = MiscTools.FormatMedalsDifference(num4);
				break;
			}
			}
		}
		RescaleHintsAndRepositThem();
	}

	private void RescaleHintsAndRepositThem()
	{
		if (hintsSecondLineTable.gameObject.activeSelf)
		{
			int num = 52;
			float num2 = hintFirstLineLabel.relativeSize.x * hintFirstLineLabel.transform.localScale.x;
			float num3 = hintsSecondLineFirstLabel.relativeSize.x * hintsSecondLineFirstLabel.transform.localScale.x + hintsSecondLineLastLabel.relativeSize.x * hintsSecondLineLastLabel.transform.localScale.x;
			float a = (float)mWidthForHints / num2;
			float b = (float)(mWidthForHints - num) / num3;
			float defaultHeight = Mathf.Clamp(Mathf.Min(a, b), 20f, 30f);
			MiscTools.SetUILabelRescale(hintFirstLineLabel, defaultHeight, 20f, mWidthForHints);
			MiscTools.SetUILabelRescale(hintsSecondLineFirstLabel, defaultHeight, 20f, mWidthForHints);
			MiscTools.SetUILabelRescale(hintsSecondLineLastLabel, defaultHeight, 20f, mWidthForHints);
			hintsSecondLineTable.repositionNow = true;
		}
		else
		{
			MiscTools.SetUILabelRescale(hintFirstLineLabel, 30f, 20f, mWidthForHints);
		}
	}
}
