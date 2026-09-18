using System;
using System.Collections;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class MainScreenLeaguePlayers : Core_BaseScript
{
	[Header("Core")]
	public UIPanel playersPanel;

	public GameObject listParent;

	public BoxCollider listCollider;

	public LeagueArcGuiElement leagueArc;

	public MainScreenLeagueEnding leagueEnding;

	[Header("Hint Part")]
	public UITable hintTable;

	public UILabel hintFirstLabel;

	public UISprite hintMedals;

	public UILabel hintSecondLabel;

	[Header("Records")]
	public MainScreenLeagueRecord[] playerRecords;

	public GameObject loadingPart;

	private RadicalRoutine mPresentLeague;

	private float mPositionY = -117f;

	private bool mBeginnersLeagueLook;

	public void InitEvents()
	{
		leagueArc.InitEvents();
		leagueEnding.InitEvents();
	}

	public void InitControls()
	{
		leagueArc.InitControls();
		leagueEnding.InitControls();
		LeagueArcManager.instance.LeagueArcUpdate += OnLeagueArcUpdate;
		LeagueArcManager.instance.SorterPlayersLeague += OnSorterPlayersLeague;
		hintTable.onReposition = delegate
		{
			float val = 0f - hintTable.padding.x - (hintSecondLabel.transform.parent.transform.localPosition.x - hintTable.padding.x) / 2f;
			hintTable.transform.localPosition = hintTable.transform.localPosition.ReplaceX(val);
		};
		UIEventListener uIEventListener = UIEventListener.Get(listCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(ListClicked));
	}

	private void ListClicked(GameObject go)
	{
		GuiScreenSingle<LeaguesScreen>.instance.ShowPlayerLeague();
	}

	private void OnLeagueArcUpdate(LeagueArcData data)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed && data.isBeginnersLeague)
		{
			OnBeginnersLeagueUpdate(data.position);
		}
	}

	private void OnBeginnersLeagueUpdate(int position)
	{
		loadingPart.SetActive(value: false);
		hintTable.gameObject.SetActive(value: false);
		for (int i = 0; i < playerRecords.Length; i++)
		{
			playerRecords[i].gameObject.SetActive(i == 0);
		}
		playerRecords[0].InitalizePlayer(position, GameLoginManager.currentPlayer, LeagueType.Stay);
		playerRecords[0].transform.localPosition = playerRecords[0].transform.localPosition.ReplaceY(48f);
		mPositionY = -24f;
	}

	private void OnSorterPlayersLeague(int myPosition, List<DatabasePlayer> databasePlayers)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed)
		{
			InitializePlayers(myPosition, databasePlayers);
		}
	}

	public void InitGuiValues()
	{
		mBeginnersLeagueLook = false;
		listCollider.enabled = true;
		if (!Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			HideEverything();
			InitializeToBottom(hideIt: true);
		}
		else if (LevelManager.instance.isMainScreenPartsLocked)
		{
			ShowLocked();
			InitializeToBottom();
		}
		else if (GameLoginManager.currentPlayer.isInBeginnersLeague)
		{
			mBeginnersLeagueLook = true;
			int beginnersLeague = GameLoginManager.currentPlayer.beginnersLeague;
			int medalsBalance = GameLoginManager.currentPlayer.medalsBalance;
			int currentPositionInBeginnersLeague = FakePlayersManager.instance.GetCurrentPositionInBeginnersLeague(100, medalsBalance, beginnersLeague);
			InitializeToBottom();
			OnBeginnersLeagueUpdate(currentPositionInBeginnersLeague);
		}
		else if (Singleton<ServerResultsCache>.instance.isPlayerLeagueProcessing)
		{
			InitializeToBottom();
			ShowProcessing();
		}
		else if (GameLoginManager.currentPlayer.isInLeague)
		{
			InitializeToBottom();
			ShowLoading();
		}
		else
		{
			InitializeToBottom();
			ShowNotInLeague();
		}
		leagueArc.InitGuiValues();
		leagueEnding.InitGuiValues();
	}

	public void AnimateShow()
	{
		if (base.gameObject.activeSelf && base.gameObject.activeInHierarchy)
		{
			StopPresentLeague();
			StartPresentLeague();
		}
	}

	public void DoAfterHide()
	{
		StopPresentLeague();
	}

	private void InitializeToBottom(bool hideIt = false)
	{
		listParent.transform.localPosition = listParent.transform.localPosition.ReplaceY((!hideIt) ? (-117f) : (-200f));
		TweenPosition component = listParent.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
	}

	private void AnimateToPosition(float dur)
	{
		if (listParent.transform.localPosition.y != mPositionY)
		{
			TweenPosition.Begin(listParent, dur, listParent.transform.localPosition.ReplaceY(mPositionY));
			return;
		}
		TweenPosition component = listParent.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
	}

	private void StartPresentLeague()
	{
		if (mPresentLeague == null)
		{
			mPresentLeague = RadicalRoutine.Create(PresentLeague());
			StartCoroutine(RadicalRoutine.Run(mPresentLeague.enumerator));
		}
	}

	private void StopPresentLeague()
	{
		if (mPresentLeague != null)
		{
			mPresentLeague.Cancel();
			mPresentLeague = null;
		}
	}

	private IEnumerator PresentLeague()
	{
		AnimateToPosition(0.3f);
		if (!mBeginnersLeagueLook)
		{
			yield return new WaitForSeconds(0.3f);
			float time = 0f;
			while (time < 6f)
			{
				time += Time.deltaTime;
				yield return null;
			}
			TweenPosition.Begin(listParent, 0.3f, listParent.transform.localPosition.ReplaceY(-117f));
		}
	}

	public void InitializePlayers(int myPosition, List<DatabasePlayer> players)
	{
		League leagueTier = GameLoginManager.currentPlayer.leagueTier;
		int count = players.Count;
		int positionPromote = Singleton<GameVariables>.instance.LeaguePositionPromote(count, leagueTier);
		int positionDemote = Singleton<GameVariables>.instance.LeaguePositionDemote(count, leagueTier);
		ShowPlayers(myPosition - 1, players, positionPromote, positionDemote);
	}

	private void HideEverything()
	{
		loadingPart.SetActive(value: false);
		hintTable.gameObject.SetActive(value: false);
		for (int i = 0; i < playerRecords.Length; i++)
		{
			playerRecords[i].gameObject.SetActive(value: false);
		}
		listCollider.enabled = false;
		mPositionY = -177f;
	}

	private void ShowLocked()
	{
		loadingPart.SetActive(value: false);
		hintTable.gameObject.SetActive(value: false);
		for (int i = 0; i < playerRecords.Length; i++)
		{
			playerRecords[i].gameObject.SetActive(value: false);
		}
		listCollider.enabled = false;
		mPositionY = -117f;
	}

	private void ShowLoading()
	{
		loadingPart.SetActive(value: true);
		hintTable.gameObject.SetActive(value: false);
		for (int i = 0; i < playerRecords.Length; i++)
		{
			playerRecords[i].gameObject.SetActive(value: false);
		}
		mPositionY = -117f;
	}

	private void ShowProcessing()
	{
		loadingPart.SetActive(value: false);
		hintTable.gameObject.SetActive(value: true);
		hintFirstLabel.transform.parent.gameObject.SetActive(value: false);
		hintMedals.gameObject.SetActive(value: false);
		hintSecondLabel.text = Localization.Localize("ID_PLAYERLEAGUEPROCESSINGHINT");
		hintTable.repositionNow = true;
		for (int i = 0; i < playerRecords.Length; i++)
		{
			playerRecords[i].gameObject.SetActive(value: false);
		}
		mPositionY = -24f;
	}

	private void ShowNotInLeague()
	{
		loadingPart.SetActive(value: false);
		hintTable.gameObject.SetActive(value: true);
		hintFirstLabel.transform.parent.gameObject.SetActive(value: false);
		hintMedals.gameObject.SetActive(value: false);
		hintSecondLabel.text = Localization.Localize("ID_NOTINLEAGUEHINT");
		hintTable.repositionNow = true;
		for (int i = 0; i < playerRecords.Length; i++)
		{
			playerRecords[i].gameObject.SetActive(value: false);
		}
		mPositionY = -24f;
	}

	private void ShowPlayers(int myIndex, List<DatabasePlayer> players, int positionPromote, int positionDemote)
	{
		loadingPart.SetActive(value: false);
		int count = players.Count;
		bool flag = count > (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.NotEnoughPlayersForPlayerLeague).FLOATVALUE;
		League leagueTier = GameLoginManager.currentPlayer.leagueTier;
		int positionInPlayersLeague = myIndex + 1;
		LeagueType leagueType = Singleton<GameVariables>.instance.LeaguePositionType(!flag, leagueTier, positionInPlayersLeague, positionPromote, positionDemote);
		int medalsBalance = players[myIndex].medalsBalance;
		playerRecords[0].transform.localPosition = playerRecords[0].transform.localPosition.ReplaceY(-40f);
		for (int i = 0; i < playerRecords.Length; i++)
		{
			playerRecords[i].gameObject.SetActive(count > i);
		}
		if (players.Count < 6)
		{
			for (int j = 0; j < playerRecords.Length; j++)
			{
				if (playerRecords[j].gameObject.activeSelf)
				{
					playerRecords[j].InitalizePlayer(j + 1, players[j], LeagueType.Stay);
				}
			}
		}
		else
		{
			int num = 0;
			int num2 = count - 1;
			if (myIndex + 1 >= num2)
			{
				num = num2 - 4;
			}
			else if (myIndex > 2)
			{
				num = myIndex - 2;
			}
			for (int k = 0; k < playerRecords.Length; k++)
			{
				int num3 = num + k;
				int positionInPlayersLeague2 = num3 + 1;
				LeagueType type = Singleton<GameVariables>.instance.LeaguePositionType(!flag, leagueTier, positionInPlayersLeague2, positionPromote, positionDemote);
				playerRecords[k].InitalizePlayer(num3 + 1, players[num3], type);
			}
		}
		hintTable.gameObject.SetActive(value: true);
		hintFirstLabel.transform.parent.gameObject.SetActive(myIndex > 0);
		hintMedals.gameObject.SetActive(myIndex > 0);
		if (!flag)
		{
			if (myIndex == 0)
			{
				hintSecondLabel.text = Localization.LocalizeFormat("ID_YOUARENUMBERONE", Colours.stringGreenLeague);
			}
			else
			{
				int num4 = players[0].medalsBalance - medalsBalance + 1;
				hintFirstLabel.text = Localization.Localize("ID_GETFORNUMBERONE1");
				hintSecondLabel.text = Localization.LocalizeFormat("ID_GETFORNUMBERONE2", MiscTools.FormatMedalsDifference(num4), Colours.stringGreenLeague);
			}
		}
		else if (myIndex == 0)
		{
			string text = ((leagueType != LeagueType.Top) ? Colours.stringGreenLeague : Colours.stringYellowLeague);
			hintSecondLabel.text = Localization.LocalizeFormat("ID_YOUARENUMBERONE", text);
		}
		else
		{
			switch (leagueType)
			{
			case LeagueType.Promote:
			case LeagueType.Top:
			{
				int num7 = players[0].medalsBalance - medalsBalance + 1;
				string text2 = ((leagueType != LeagueType.Top) ? Colours.stringGreenLeague : Colours.stringYellowLeague);
				hintFirstLabel.text = Localization.Localize("ID_GETFORNUMBERONE1");
				hintSecondLabel.text = Localization.LocalizeFormat("ID_GETFORNUMBERONE2", MiscTools.FormatMedalsDifference(num7), text2);
				break;
			}
			case LeagueType.Stay:
			{
				int num6 = players[positionPromote - 1].medalsBalance - medalsBalance + 1;
				hintFirstLabel.text = Localization.Localize("ID_GETFORPROMOTION1");
				hintSecondLabel.text = Localization.LocalizeFormat("ID_GETFORPROMOTION2", MiscTools.FormatMedalsDifference(num6), Colours.stringGreenLeague);
				break;
			}
			default:
			{
				int num5 = players[positionDemote - 2].medalsBalance - medalsBalance + 1;
				hintFirstLabel.text = Localization.Localize("ID_GETTOAVOIDRELEGATION1");
				hintSecondLabel.text = Localization.LocalizeFormat("ID_GETTOAVOIDRELEGATION2", MiscTools.FormatMedalsDifference(num5), Colours.stringRedLeague);
				break;
			}
			}
		}
		hintTable.repositionNow = true;
		mPositionY = 377f - 80f * (float)Mathf.Max(5 - count, 0);
		AnimateShow();
	}
}
