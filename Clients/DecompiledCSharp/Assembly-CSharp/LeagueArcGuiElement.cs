using System;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class LeagueArcGuiElement : Core_BaseScript
{
	public enum Type
	{
		MainScreen,
		MenuHeader,
		EndScreen,
		NoUpdate
	}

	public static Dictionary<League, Color> leagueColours = new Dictionary<League, Color>
	{
		{
			League.NoLeague,
			Colours.whiteTransparent
		},
		{
			League.Bronze3,
			Colours.bronzeBgLeague
		},
		{
			League.Bronze2,
			Colours.bronzeBgLeague
		},
		{
			League.Bronze1,
			Colours.bronzeBgLeague
		},
		{
			League.Silver3,
			Colours.silverBgLeague
		},
		{
			League.Silver2,
			Colours.silverBgLeague
		},
		{
			League.Silver1,
			Colours.silverBgLeague
		},
		{
			League.Gold3,
			Colours.goldBgLeague
		},
		{
			League.Gold2,
			Colours.goldBgLeague
		},
		{
			League.Gold1,
			Colours.goldBgLeague
		},
		{
			League.Elite3,
			Colours.eliteBgLeague
		},
		{
			League.Elite2,
			Colours.eliteBgLeague
		},
		{
			League.Elite1,
			Colours.eliteBgLeague
		},
		{
			League.Master3,
			Colours.masterBgLeague
		},
		{
			League.Master2,
			Colours.masterBgLeague
		},
		{
			League.Master1,
			Colours.masterBgLeague
		},
		{
			League.Champion,
			Colours.championBgLeague
		}
	};

	[Header("Core")]
	public Type currentType;

	public BoxCollider boxCollider;

	public UIPanel panel;

	public UISprite glowBackground;

	public UISprite blueProgress;

	public UISprite blueProgress2;

	public UISprite arrow;

	public GameObject arrowParent;

	[Header("League Icon")]
	public GameObject leagueIconPart;

	public UISprite leagueIcon;

	public UISprite leagueIconShadow;

	[Header("Promote Demote parts")]
	public GameObject redDemotePart;

	public UILabel demoteMedals;

	public UISprite demoteGlow;

	public GameObject greenPromotePart;

	public UILabel promoteMedals;

	public UISprite promoteGlow;

	[Header("Medals part")]
	public UITable medalsTable;

	public UISprite medalsIcon;

	public UILabel currentMedals;

	public UILabel beginnersMedals;

	[Header("Processing part")]
	public GameObject processingPart;

	[Header("Not In League part")]
	public GameObject notInLeaguePart;

	[Header("Locked part")]
	public GameObject lockedPart;

	[Header("Loading part")]
	public GameObject loadingPart;

	private bool mIgnoreUpdate;

	private bool mFirstLoading = true;

	public void InitEvents()
	{
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += OnAfterPlayerDataLoaded;
		LeagueArcManager.instance.ShowLoading += OnShowLoading;
		LeagueArcManager.instance.LeagueArcUpdate += OnLeagueArcUpdate;
		LeagueArcManager.instance.StopIgnore += OnStopIgnore;
		ServerResultsCache instance = Singleton<ServerResultsCache>.instance;
		instance.PlayerLeagueProcessingChanged = (Action)Delegate.Combine(instance.PlayerLeagueProcessingChanged, new Action(OnPlayerLeagueProcessingChanged));
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataLoaded;
	}

	private void OnAfterPlayerDataLoaded()
	{
		if (base.gameObject.activeSelf && base.gameObject.activeInHierarchy && currentType == Type.MenuHeader && LevelManager.instance.isMainScreenPartsLocked)
		{
			InitGuiValues();
		}
	}

	private void OnShowLoading(League league, int leagueMedals)
	{
		if (base.gameObject.activeSelf && base.gameObject.activeInHierarchy && !mIgnoreUpdate && mFirstLoading && (currentType == Type.MainScreen || currentType == Type.MenuHeader))
		{
			Debug.Log(string.Concat("#PETER# League Arc ", currentType, " set loading for league ", league));
			SetLoading(league, leagueMedals);
			mFirstLoading = false;
		}
	}

	private void OnLeagueArcUpdate(LeagueArcData data)
	{
		if (base.gameObject.activeSelf && base.gameObject.activeInHierarchy && !mIgnoreUpdate && (currentType == Type.MainScreen || currentType == Type.MenuHeader))
		{
			if (data.isBeginnersLeague)
			{
				Debug.Log(string.Concat("#PETER# League Arc ", currentType, " set beginners league ", data.beginnersLeague));
				SetBeginnersLeague(data.beginnersLeague, data.leagueMedals, data.position);
			}
			else if (data.isLeagueProcessing)
			{
				Debug.Log(string.Concat("#PETER# League Arc ", currentType, " set league processing"));
				SetLeagueProcessing();
			}
			else if (data.isInLeague)
			{
				Debug.Log(string.Concat("#PETER# League Arc ", currentType, " set league ", data.league));
				SetNormalLeague(data.league, data.leagueMedals, data.position, data.numberOfPlayers, data.hasPromote, data.promoteMedals, data.hasDemote, data.demoteMedals);
			}
			else
			{
				Debug.Log(string.Concat("#PETER# League Arc ", currentType, " set not in league"));
				SetNotInLeague();
			}
		}
	}

	private void OnStopIgnore()
	{
		Debug.Log("#PETER# League Arc - stop ignore on " + currentType);
		mIgnoreUpdate = false;
	}

	private void OnPlayerLeagueProcessingChanged()
	{
		if (base.gameObject.activeSelf && base.gameObject.activeInHierarchy && !mIgnoreUpdate && (currentType == Type.MainScreen || currentType == Type.MenuHeader))
		{
			InitGuiValues();
		}
	}

	private void OnDataLoaded(DatabaseAction action)
	{
		if (base.gameObject.activeSelf && base.gameObject.activeInHierarchy && (currentType == Type.MainScreen || currentType == Type.MenuHeader))
		{
			if (action == DatabaseAction.DebugChangeLeague || action == DatabaseAction.DebugChangeDivision || action == DatabaseAction.DebugChangeMedals)
			{
				InitGuiValues();
			}
		}
	}

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(boxCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OnArcClick));
		medalsTable.onReposition = delegate
		{
			GameObject gameObject = ((!beginnersMedals.transform.parent.transform.gameObject.activeSelf) ? currentMedals.transform.parent.transform.gameObject : beginnersMedals.transform.parent.transform.gameObject);
			float val = 0f - medalsTable.padding.x - (gameObject.transform.localPosition.x - medalsTable.padding.x) / 2f;
			medalsTable.transform.localPosition = medalsTable.transform.localPosition.ReplaceX(val);
		};
	}

	private void OnArcClick(GameObject go)
	{
		if (currentType == Type.MainScreen)
		{
			GuiScreenSingle<LeaguesScreen>.instance.ShowPlayerLeague();
		}
		if (currentType == Type.EndScreen)
		{
			GuiScreenSingle<LeaguesScreen>.instance.ShowPlayerLeague();
			GuiScreenSingle<LeaguesScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
		}
	}

	public void InitGuiValues()
	{
		if (!Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			SetDataNotLoaded();
		}
		else if (LevelManager.instance.isMainScreenPartsLocked)
		{
			SetLocked();
		}
		else if (GameLoginManager.currentPlayer.isInBeginnersLeague)
		{
			int beginnersLeague = GameLoginManager.currentPlayer.beginnersLeague;
			int medalsBalance = GameLoginManager.currentPlayer.medalsBalance;
			int currentPositionInBeginnersLeague = FakePlayersManager.instance.GetCurrentPositionInBeginnersLeague(100, medalsBalance, beginnersLeague);
			SetBeginnersLeague(beginnersLeague, medalsBalance, currentPositionInBeginnersLeague);
		}
		else if (Singleton<ServerResultsCache>.instance.isPlayerLeagueProcessing)
		{
			SetLeagueProcessing();
		}
		else if (GameLoginManager.currentPlayer.isInLeague)
		{
			mFirstLoading = true;
			League leagueTier = GameLoginManager.currentPlayer.leagueTier;
			int medalsBalance2 = GameLoginManager.currentPlayer.medalsBalance;
			SetLoading(leagueTier, medalsBalance2);
			Singleton<BeanstalkServerManager>.instance.GetPlayersFromLeague(GameLoginManager.currentPlayer.leagueId);
		}
		else
		{
			SetNotInLeague();
		}
	}

	public void InitializeTo(LeagueArcData data, bool halfStepInAnimation = false)
	{
		if (halfStepInAnimation)
		{
			Debug.Log("#PETER# League Arc - start ignore on " + currentType);
			mIgnoreUpdate = true;
		}
		if (data.isBeginnersLeague)
		{
			SetBeginnersLeague(data.beginnersLeague, data.leagueMedals, data.position);
		}
		else if (data.isLeagueProcessing)
		{
			SetLeagueProcessing();
		}
		else if (data.isInLeague)
		{
			SetNormalLeague(data.league, data.leagueMedals, data.position, data.numberOfPlayers, data.hasPromote, data.promoteMedals, data.hasDemote, data.demoteMedals);
		}
		else
		{
			SetNotInLeague();
		}
	}

	public void StopAnimations()
	{
		TweenBeginnerLeague component = base.gameObject.GetComponent<TweenBeginnerLeague>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenLeague component2 = base.gameObject.GetComponent<TweenLeague>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
	}

	public void Animate(LeagueArcData previousData, LeagueArcData currentData)
	{
		Debug.LogFormat("#PETER# Animating league arc {0}    from:\"{1}\"  to:\"{2}\"", currentType, previousData.debugMessage, currentData.debugMessage);
		if (previousData.isBeginnersLeague)
		{
			if (currentData.isBeginnersLeague && previousData.beginnersLeague == currentData.beginnersLeague)
			{
				TweenBeginnerLeague.Begin(this, 1f, previousData, currentData).onFinished = delegate
				{
					Debug.Log("#PETER# League Arc - stop ignore on " + currentType);
					mIgnoreUpdate = false;
				};
				return;
			}
			LeagueArcData leagueArcData = new LeagueArcData(previousData);
			leagueArcData.position = 1;
			leagueArcData.leagueMedals = Singleton<GameVariables>.instance.BeginnersLeagueMaxMedals(previousData.beginnersLeague);
			TweenBeginnerLeague.Begin(this, 1f, previousData, leagueArcData).onFinished = delegate
			{
				if (currentData.isBeginnersLeague)
				{
					LeagueArcData leagueArcData2 = new LeagueArcData(currentData)
					{
						position = 100,
						leagueMedals = 0
					};
					InitializeTo(leagueArcData2, halfStepInAnimation: true);
					TweenBeginnerLeague.Begin(this, 1f, leagueArcData2, currentData).onFinished = null;
				}
				else if (currentData.isLeagueProcessing || !currentData.isInLeague)
				{
					InitializeTo(currentData);
				}
				else
				{
					InitializeToAndLogError(previousData, currentData);
				}
			};
			return;
		}
		bool flag = !previousData.isBeginnersLeague && !previousData.isLeagueProcessing && !previousData.isInLeague;
		bool flag2 = !previousData.isBeginnersLeague && !previousData.isLeagueProcessing && previousData.isInLeague;
		bool flag3 = !currentData.isBeginnersLeague && !currentData.isLeagueProcessing && !currentData.isInLeague;
		bool flag4 = !currentData.isBeginnersLeague && !currentData.isLeagueProcessing && currentData.isInLeague;
		if (currentData.isBeginnersLeague)
		{
			InitializeToAndLogError(previousData, currentData);
		}
		else if (flag2 && flag4)
		{
			TweenLeague.Begin(this, 1f, previousData, currentData).onFinished = delegate
			{
				InitializeTo(currentData);
			};
		}
		else if (flag && flag3)
		{
			InitializeToAndLogError(previousData, currentData);
		}
		else
		{
			InitializeTo(currentData);
		}
	}

	private void InitializeToAndLogError(LeagueArcData previousData, LeagueArcData currentData)
	{
		InitializeTo(currentData);
		Debug.LogFormat("#PETER# League Arc Animation - Error - previous: {0}     current: {1}", previousData.debugMessage, currentData.debugMessage);
	}

	public void ShowLoading()
	{
		LeagueArcData previousData = LeagueArcManager.instance.GetPreviousData();
		SetLoading(previousData.league, previousData.leagueMedals);
		Debug.Log("#PETER# League Arc - start ignore on " + currentType);
		mIgnoreUpdate = true;
	}

	private void SetDataNotLoaded()
	{
		boxCollider.enabled = false;
		glowBackground.color = Colours.gray7e;
		blueProgress.gameObject.SetActive(value: false);
		blueProgress2.gameObject.SetActive(value: false);
		leagueIconPart.SetActive(value: false);
		medalsTable.gameObject.SetActive(value: false);
		redDemotePart.SetActive(value: false);
		demoteMedals.gameObject.SetActive(value: false);
		greenPromotePart.SetActive(value: false);
		promoteMedals.gameObject.SetActive(value: false);
		processingPart.SetActive(value: false);
		notInLeaguePart.SetActive(value: false);
		loadingPart.SetActive(value: false);
		lockedPart.SetActive(value: false);
		arrowParent.SetActive(value: false);
		HideGlow();
	}

	private void SetLocked()
	{
		boxCollider.enabled = false;
		glowBackground.color = Colours.gray7e;
		lockedPart.SetActive(value: true);
		blueProgress.gameObject.SetActive(value: false);
		blueProgress2.gameObject.SetActive(value: false);
		leagueIconPart.SetActive(value: false);
		medalsTable.gameObject.SetActive(value: false);
		redDemotePart.SetActive(value: false);
		demoteMedals.gameObject.SetActive(value: false);
		greenPromotePart.SetActive(value: false);
		promoteMedals.gameObject.SetActive(value: false);
		processingPart.SetActive(value: false);
		notInLeaguePart.SetActive(value: false);
		loadingPart.SetActive(value: false);
		arrowParent.SetActive(value: false);
		HideGlow();
	}

	private void SetLeagueProcessing()
	{
		boxCollider.enabled = true;
		glowBackground.color = Colours.gray7e;
		processingPart.SetActive(value: true);
		blueProgress.gameObject.SetActive(value: false);
		blueProgress2.gameObject.SetActive(value: false);
		leagueIconPart.SetActive(value: false);
		medalsTable.gameObject.SetActive(value: false);
		redDemotePart.SetActive(value: false);
		demoteMedals.gameObject.SetActive(value: false);
		greenPromotePart.SetActive(value: false);
		promoteMedals.gameObject.SetActive(value: false);
		notInLeaguePart.SetActive(value: false);
		loadingPart.SetActive(value: false);
		lockedPart.SetActive(value: false);
		arrowParent.SetActive(value: false);
		HideGlow();
	}

	private void SetNotInLeague()
	{
		boxCollider.enabled = true;
		glowBackground.color = Colours.blueEnterLeague;
		notInLeaguePart.SetActive(value: true);
		blueProgress.gameObject.SetActive(value: false);
		blueProgress2.gameObject.SetActive(value: false);
		leagueIconPart.SetActive(value: false);
		medalsTable.gameObject.SetActive(value: false);
		redDemotePart.SetActive(value: false);
		demoteMedals.gameObject.SetActive(value: false);
		greenPromotePart.SetActive(value: false);
		promoteMedals.gameObject.SetActive(value: false);
		processingPart.SetActive(value: false);
		loadingPart.SetActive(value: false);
		lockedPart.SetActive(value: false);
		arrowParent.SetActive(value: false);
		HideGlow();
	}

	private void SetBeginnersLeague(int beginnersLeague, int leagueMedals, int position)
	{
		boxCollider.enabled = true;
		int num = Singleton<GameVariables>.instance.BeginnersLeagueMaxMedals(beginnersLeague);
		medalsTable.gameObject.SetActive(value: true);
		currentMedals.text = MiscTools.FormatBigNumber(leagueMedals);
		beginnersMedals.transform.parent.transform.gameObject.SetActive(value: true);
		beginnersMedals.text = $"/ {Colours.stringBlue}{MiscTools.FormatBigNumber(num)}";
		medalsTable.repositionNow = true;
		blueProgress.gameObject.SetActive(value: true);
		blueProgress2.gameObject.SetActive(value: true);
		SetBeginnersPosition(position);
		HideGlow();
		leagueIconPart.SetActive(value: true);
		leagueIcon.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(beginnersLeague);
		glowBackground.color = Colours.rookieBgLeague;
		leagueIconShadow.spriteName = leagueIcon.spriteName;
		redDemotePart.SetActive(value: false);
		demoteMedals.gameObject.SetActive(value: false);
		greenPromotePart.SetActive(value: false);
		promoteMedals.gameObject.SetActive(value: false);
		processingPart.SetActive(value: false);
		notInLeaguePart.SetActive(value: false);
		loadingPart.SetActive(value: false);
		lockedPart.SetActive(value: false);
	}

	private void SetLoading(League league, int leagueMedals)
	{
		boxCollider.enabled = true;
		blueProgress.gameObject.SetActive(value: false);
		blueProgress2.gameObject.SetActive(value: false);
		float num = Singleton<GameVariables>.instance.LeagueGoDownPercent(league);
		float num2 = Singleton<GameVariables>.instance.LeagueGoUpPercent(league);
		bool active = num > 0f;
		bool active2 = num2 > 0f;
		leagueIconPart.SetActive(value: true);
		leagueIcon.spriteName = GameVariables.leagueNames[league].Value2;
		glowBackground.color = leagueColours[league];
		leagueIconShadow.spriteName = leagueIcon.spriteName;
		medalsTable.gameObject.SetActive(value: true);
		currentMedals.text = MiscTools.FormatBigNumber(leagueMedals);
		beginnersMedals.transform.parent.transform.gameObject.SetActive(value: false);
		medalsTable.repositionNow = true;
		redDemotePart.SetActive(active);
		demoteMedals.gameObject.SetActive(active);
		demoteMedals.text = string.Empty;
		greenPromotePart.SetActive(active2);
		promoteMedals.gameObject.SetActive(active2);
		promoteMedals.text = string.Empty;
		arrowParent.SetActive(value: false);
		HideGlow();
		processingPart.SetActive(value: false);
		notInLeaguePart.SetActive(value: false);
		lockedPart.SetActive(value: false);
		loadingPart.SetActive(value: true);
	}

	private void SetNormalLeague(League league, int leagueMedals, int playerPosition, int playersCount, bool hasPromote, int promotePlayerMedals, bool hasDemote, int demotePlayerMedals)
	{
		bool flag = playersCount > (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.NotEnoughPlayersForPlayerLeague).FLOATVALUE;
		loadingPart.SetActive(value: false);
		blueProgress.gameObject.SetActive(value: false);
		blueProgress2.gameObject.SetActive(value: false);
		redDemotePart.SetActive(flag && hasDemote);
		demoteMedals.gameObject.SetActive(flag && hasDemote);
		demoteMedals.text = MiscTools.FormatBigNumber(demotePlayerMedals);
		greenPromotePart.SetActive(flag && hasPromote);
		promoteMedals.gameObject.SetActive(flag && hasPromote);
		promoteMedals.text = MiscTools.FormatBigNumber(promotePlayerMedals);
		leagueIconPart.SetActive(value: true);
		leagueIcon.spriteName = GameVariables.leagueNames[league].Value2;
		glowBackground.color = leagueColours[league];
		leagueIconShadow.spriteName = leagueIcon.spriteName;
		medalsTable.gameObject.SetActive(value: true);
		currentMedals.text = MiscTools.FormatBigNumber(leagueMedals);
		beginnersMedals.transform.parent.transform.gameObject.SetActive(value: false);
		medalsTable.repositionNow = true;
		SetArrow(playerPosition, playersCount, league);
		SetGlow(playerPosition, playersCount, league);
		processingPart.SetActive(value: false);
		notInLeaguePart.SetActive(value: false);
		lockedPart.SetActive(value: false);
	}

	public void SetBeginnersPosition(int playerPosition)
	{
		float num = (float)(100 - playerPosition) / 99f;
		SetArrowBeginners(num);
		num *= 2f;
		blueProgress.fillAmount = Mathf.Clamp01(num);
		blueProgress2.fillAmount = Mathf.Clamp01(num - 1f);
	}

	private void SetArrowBeginners(float progress)
	{
		float arrowRotation = Mathf.Lerp(90f, -90f, progress);
		arrowParent.SetActive(value: true);
		SetArrowRotation(arrowRotation);
	}

	public void HideGlow()
	{
		promoteGlow.gameObject.SetActive(value: false);
		demoteGlow.gameObject.SetActive(value: false);
	}

	public void SetGlow(int playerPosition, int playersInLeague, League currentLeague, bool animate = false)
	{
		bool flag = false;
		bool flag2 = false;
		if (playersInLeague > (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.NotEnoughPlayersForPlayerLeague).FLOATVALUE)
		{
			bool flag3 = Singleton<GameVariables>.instance.LeagueGoDownPercent(currentLeague) > 0f;
			bool flag4 = Singleton<GameVariables>.instance.LeagueGoUpPercent(currentLeague) > 0f;
			int num = Singleton<GameVariables>.instance.LeaguePositionPromote(playersInLeague, currentLeague);
			int num2 = Singleton<GameVariables>.instance.LeaguePositionDemote(playersInLeague, currentLeague);
			flag = flag4 && playerPosition <= num;
			flag2 = flag3 && playerPosition >= num2;
		}
		if (animate)
		{
			if (flag && !promoteGlow.gameObject.activeSelf)
			{
				promoteGlow.gameObject.SetActive(value: true);
				TweenAlpha.Begin(promoteGlow.gameObject, 0.2f, 0f, 1f).onFinished = null;
			}
			if (!flag && promoteGlow.gameObject.activeSelf && promoteGlow.alpha == 1f)
			{
				TweenAlpha.Begin(promoteGlow.gameObject, 0.2f, 1f, 0f).onFinished = delegate
				{
					promoteGlow.gameObject.SetActive(value: false);
				};
			}
			if (flag2 && !demoteGlow.gameObject.activeSelf)
			{
				demoteGlow.gameObject.SetActive(value: true);
				TweenAlpha.Begin(demoteGlow.gameObject, 0.2f, 0f, 1f).onFinished = null;
			}
			if (!flag2 && demoteGlow.gameObject.activeSelf && demoteGlow.alpha == 1f)
			{
				TweenAlpha.Begin(demoteGlow.gameObject, 0.2f, 1f, 0f).onFinished = delegate
				{
					demoteGlow.gameObject.SetActive(value: false);
				};
			}
		}
		else
		{
			promoteGlow.gameObject.SetActive(flag);
			demoteGlow.gameObject.SetActive(flag2);
			promoteGlow.alpha = 1f;
			demoteGlow.alpha = 1f;
			TweenAlpha component = promoteGlow.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			component = demoteGlow.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
		}
	}

	public void SetArrow(int playerPosition, int playersInLeague, League currentLeague)
	{
		bool flag = playersInLeague > (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.NotEnoughPlayersForPlayerLeague).FLOATVALUE;
		arrowParent.SetActive(value: true);
		float a = 90f;
		float b = -90f;
		float num = 1f;
		float num2 = 0f;
		if (!flag)
		{
			num = ((playersInLeague >= 2) ? ((float)(playersInLeague - playerPosition) / (float)(playersInLeague - 1)) : 1f);
			num2 = Mathf.Lerp(a, b, num);
			SetArrowRotation(num2);
			return;
		}
		playerPosition = Mathf.Clamp(playerPosition, 1, playersInLeague);
		bool flag2 = Singleton<GameVariables>.instance.LeagueGoDownPercent(currentLeague) > 0f;
		bool flag3 = Singleton<GameVariables>.instance.LeagueGoUpPercent(currentLeague) > 0f;
		int num3 = Singleton<GameVariables>.instance.LeaguePositionPromote(playersInLeague, currentLeague);
		int num4 = Singleton<GameVariables>.instance.LeaguePositionDemote(playersInLeague, currentLeague);
		if (playerPosition <= num3)
		{
			a = -45f;
			b = -90f;
			int num5 = playerPosition;
			int num6 = num3;
			num = ((num6 >= 2) ? ((float)(num6 - num5) / (float)(num6 - 1)) : 1f);
		}
		else if (playerPosition >= num4)
		{
			a = 90f;
			b = 45f;
			int num7 = playerPosition - num4;
			int num8 = playersInLeague - num4;
			num = ((num8 >= 2) ? ((float)(num8 - num7) / (float)num8) : 0f);
		}
		else if (flag3 && !flag2)
		{
			a = 90f;
			b = -45f;
			int num9 = playerPosition - num3;
			int num10 = playersInLeague - num3;
			num = (float)(num10 - num9) / (float)num10;
		}
		else if (flag2 && !flag3)
		{
			a = 45f;
			b = -90f;
			int num11 = playerPosition;
			int num12 = num4;
			num = (float)(num12 - num11) / (float)(num12 - 1);
		}
		else
		{
			a = 45f;
			b = -45f;
			int num13 = playerPosition - num3;
			int num14 = num4 - num3;
			num = (float)(num14 - num13) / (float)(num14 - 1);
		}
		num2 = Mathf.Lerp(a, b, num);
		SetArrowRotation(num2);
	}

	private void SetArrowRotation(float rotation)
	{
		rotation = Mathf.Clamp(rotation, -90f, 90f);
		arrowParent.transform.localRotation = Quaternion.Euler(0f, 0f, rotation);
		arrow.transform.localRotation = Quaternion.Euler(0f, 0f, RotationOfArrowToKeepInScreen(rotation));
	}

	private float RotationOfArrowToKeepInScreen(float parrentRotation)
	{
		if (parrentRotation <= -81f)
		{
			float num = Mathf.Clamp(-81f - parrentRotation, 0f, 9f);
			return 31f * (num / 9f);
		}
		if (parrentRotation >= 81f)
		{
			float num2 = Mathf.Clamp(parrentRotation - 81f, 0f, 9f);
			return -31f * (num2 / 9f);
		}
		return 0f;
	}

	public void SetTutorialLook()
	{
		boxCollider.enabled = false;
		League leagueTier = GameLoginManager.currentPlayer.leagueTier;
		float num = Singleton<GameVariables>.instance.LeagueGoDownPercent(leagueTier);
		float num2 = Singleton<GameVariables>.instance.LeagueGoUpPercent(leagueTier);
		bool active = num > 0f;
		bool active2 = num2 > 0f;
		loadingPart.SetActive(value: false);
		blueProgress.gameObject.SetActive(value: false);
		blueProgress2.gameObject.SetActive(value: false);
		redDemotePart.SetActive(active);
		demoteMedals.gameObject.SetActive(active);
		demoteMedals.text = string.Empty;
		greenPromotePart.SetActive(active2);
		promoteMedals.gameObject.SetActive(active2);
		promoteMedals.text = string.Empty;
		leagueIconPart.SetActive(value: true);
		leagueIcon.spriteName = GameVariables.leagueNames[leagueTier].Value2;
		glowBackground.color = leagueColours[leagueTier];
		leagueIconShadow.spriteName = leagueIcon.spriteName;
		medalsTable.gameObject.SetActive(value: true);
		currentMedals.text = MiscTools.FormatBigNumber(GameLoginManager.currentPlayer.medalsBalance);
		beginnersMedals.transform.parent.transform.gameObject.SetActive(value: false);
		medalsTable.onReposition = delegate
		{
			GameObject gameObject = ((!beginnersMedals.transform.parent.transform.gameObject.activeSelf) ? currentMedals.transform.parent.transform.gameObject : beginnersMedals.transform.parent.transform.gameObject);
			float val = 0f - medalsTable.padding.x - (gameObject.transform.localPosition.x - medalsTable.padding.x) / 2f;
			medalsTable.transform.localPosition = medalsTable.transform.localPosition.ReplaceX(val);
		};
		medalsTable.repositionNow = true;
		SetArrowBeginners(0.5f);
		HideGlow();
		processingPart.SetActive(value: false);
		notInLeaguePart.SetActive(value: false);
		lockedPart.SetActive(value: false);
	}
}
