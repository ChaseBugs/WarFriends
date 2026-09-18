using System.Collections.Generic;
using UnityEngine;

public class LobbyHeader : Core_BaseScript
{
	public enum LobbyState
	{
		MissionBot = 1,
		MissionBotCoop,
		DeathMatch
	}

	[Header("Header")]
	public GameObject centerParent;

	public UILabel centerVs;

	public GameObject centerArena;

	public UILabel arenaTime;

	[Header("-Left")]
	public UISprite leftBackground;

	public UISprite leftArrow;

	public LobbyPlayerPart player1;

	public LobbyPlayerPart player2;

	[Header("-Right")]
	public UISprite rightBackground;

	public UISprite rightArrow;

	public LobbyPlayerPart player3;

	public LobbyPlayerPart player4;

	[Header("Fake Names")]
	public List<string> fakeNames;

	private bool mGuiValuesInitialized;

	private float mWidthOfBackgroundCache = -1f;

	private LobbyState mScreenState;

	private bool mUpdateArenaTime;

	private float mTime;

	public float widthOfBackground
	{
		get
		{
			if (mWidthOfBackgroundCache > 0f)
			{
				return mWidthOfBackgroundCache;
			}
			float num = 1.3333334f;
			float num2 = 1.7777778f;
			float num3 = Mathf.Clamp(UIRoot.list[0].activeWidth / (float)UIRoot.list[0].activeHeight, num, num2);
			float num4 = (num3 - num2) / (num - num2);
			mWidthOfBackgroundCache = 878f + num4 * -138f;
			return mWidthOfBackgroundCache;
		}
	}

	public float positionOfArrow => widthOfBackground - 126f;

	public void InitEvents()
	{
		MatchManager.MatchStateChanged += MatchStateChanged;
		PlayerNetworkStatus.MatchStateChanged += PlayerNetworkStatusOnMatchStateChanged;
	}

	public void MatchStateChanged(MatchState matchState)
	{
		if (!GuiScreenSingle<CardSelectionScreen>.instance.isShowed || !base.gameObject.activeInHierarchy)
		{
			return;
		}
		if (mScreenState == LobbyState.DeathMatch)
		{
			player1.SetState(MatchManager.matchStatusPlayer);
			player3.SetState(MatchManager.matchStatusOpponent);
			if ((matchState == MatchState.ConnectingToPhoton || matchState == MatchState.GameCancelled) && mGuiValuesInitialized)
			{
				player3.AnimateConnectingToPhoton();
			}
			if (matchState == MatchState.WaitingForOpponent && (Singleton<GameController>.instance.isRandomMatchMaking || Singleton<GameController>.instance.isWarArena) && mGuiValuesInitialized)
			{
				player3.AnimatePlayerSearching();
			}
			if (matchState == MatchState.BothPlayersConnected)
			{
				player3.AnimatePlayerFound(Singleton<GameController>.instance.opponent.playerProperties);
			}
		}
		else
		{
			if (mScreenState != LobbyState.MissionBotCoop)
			{
				return;
			}
			player1.SetState(MatchManager.matchStatusPlayer);
			player2.SetState(MatchManager.matchStatusFriend);
			if (matchState == MatchState.ConnectingToPhoton || matchState == MatchState.WaitingForOpponent)
			{
				if (Singleton<GameController>.instance.friend != null)
				{
					player2.AnimateWaitingForFriend(Singleton<GameController>.instance.friend.playerProperties.name, Singleton<GameController>.instance.friend.playerProperties.texture);
				}
				else
				{
					player2.AnimateWaitingForFriend();
				}
			}
			if (matchState == MatchState.BothPlayersConnected)
			{
				player2.AnimatePlayerFound(Singleton<GameController>.instance.friend.playerProperties);
			}
		}
	}

	private void PlayerNetworkStatusOnMatchStateChanged(PlayerNetworkStatus.MatchState matchState, PlayerController playerController)
	{
		if (!GuiScreenSingle<CardSelectionScreen>.instance.isShowed || !base.gameObject.activeInHierarchy)
		{
			return;
		}
		if (mScreenState == LobbyState.DeathMatch)
		{
			if (playerController == Singleton<GameController>.instance.opponent)
			{
				player3.SetState(MatchManager.matchStatusOpponent);
			}
			if (playerController.isCurrentPlayer && matchState == PlayerNetworkStatus.MatchState.Rematch)
			{
				player3.AnimatePlayerFound(Singleton<GameController>.instance.opponent.playerProperties);
			}
		}
		else if (mScreenState == LobbyState.MissionBotCoop)
		{
			if (playerController == Singleton<GameController>.instance.friend)
			{
				player2.SetState(MatchManager.matchStatusFriend);
			}
			if (playerController.isCurrentPlayer && matchState == PlayerNetworkStatus.MatchState.Rematch)
			{
				player2.AnimatePlayerFound(Singleton<GameController>.instance.friend.playerProperties);
			}
		}
	}

	public void InitControls()
	{
		player1.SetButtonClicks();
		player2.SetButtonClicks();
		player4.gameObject.SetActive(value: false);
	}

	public void InitGUIValues()
	{
		mScreenState = CurrentState();
		bool flag = mScreenState == LobbyState.MissionBotCoop;
		player1.InitSizeAndOrientation(!flag, isLeft: true);
		player2.InitSizeAndOrientation(isBig: false, isLeft: true, isTop: false);
		player2.gameObject.SetActive(flag);
		player3.InitSizeAndOrientation(isBig: true, isLeft: false);
		ResetPlayersGui();
		mUpdateArenaTime = Singleton<GameController>.instance.isWarArena;
		centerVs.gameObject.SetActive(!mUpdateArenaTime);
		centerArena.SetActive(mUpdateArenaTime);
		InitialHeaderAnimation();
		player1.AnimateCurrentPlayer(mScreenState == LobbyState.DeathMatch || mScreenState == LobbyState.MissionBotCoop);
		if (mScreenState == LobbyState.MissionBotCoop)
		{
			player2.AnimateConnectingToPhoton();
		}
		if (mScreenState == LobbyState.MissionBot || mScreenState == LobbyState.MissionBotCoop)
		{
			player3.AnimateBoss();
		}
		else if (mScreenState == LobbyState.DeathMatch)
		{
			player3.AnimateConnectingToPhoton();
		}
		if (mScreenState == LobbyState.DeathMatch || mScreenState == LobbyState.MissionBotCoop)
		{
			MatchStateChanged(MatchManager.matchState);
		}
		mGuiValuesInitialized = true;
	}

	private void ResetPlayersGui()
	{
		TweenAlpha.Begin(leftBackground.gameObject, 0f, 1f);
		TweenScale.Begin(leftBackground.gameObject, 0f, leftBackground.transform.localScale.ReplaceX(790f));
		TweenAlpha.Begin(leftArrow.gameObject, 0f, 1f);
		TweenPosition.Begin(leftArrow.gameObject, 0f, leftBackground.transform.localPosition.ReplaceX(664f));
		TweenAlpha.Begin(rightBackground.gameObject, 0f, 1f);
		TweenScale.Begin(rightBackground.gameObject, 0f, leftBackground.transform.localScale.ReplaceX(790f));
		TweenAlpha.Begin(rightArrow.gameObject, 0f, 1f);
		TweenPosition.Begin(rightArrow.gameObject, 0f, leftBackground.transform.localPosition.ReplaceX(664f));
		TweenAlpha.Begin(centerVs.gameObject, 0f, 1f);
		TweenScale.Begin(centerVs.transform.parent.gameObject, 0f, Vector3.one);
		centerVs.alpha = 1f;
	}

	private void InitialHeaderAnimation()
	{
		float delay = 0.3f;
		float popAmount = 1.3f;
		float upTime = 0.4f;
		float downTime = 0.2f;
		float delay2 = 0.4f;
		RollAnimation(leftBackground.gameObject, leftArrow.gameObject, delay, toRight: true);
		RollAnimation(rightBackground.gameObject, rightArrow.gameObject, delay, toRight: false);
		PopAnimator(centerParent, popAmount, upTime, downTime, delay2);
	}

	private LobbyState CurrentState()
	{
		if (Singleton<GameController>.instance.isCampaignBot)
		{
			return LobbyState.MissionBot;
		}
		if (Singleton<GameController>.instance.isCoopBot)
		{
			return LobbyState.MissionBotCoop;
		}
		return LobbyState.DeathMatch;
	}

	public void DoAfterHide()
	{
		mGuiValuesInitialized = false;
	}

	private void PopAnimator(GameObject go, float popAmount, float upTime, float downTime, float delay)
	{
		TweenScale.Begin(go, 0f, new Vector3(0f, 0f, 1f)).onFinished = null;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(go, delay, 0f, 0f);
		tweenAlpha.onFinished = delegate
		{
			TweenAlpha.Begin(go, 0.15f, 0f, 1f);
			TweenScale tweenScale = TweenScale.Begin(go, upTime, new Vector3(0f, 0f, 1f), new Vector3(popAmount, popAmount, 1f));
			tweenScale.method = UITweener.Method.EaseOut;
			tweenScale.onFinished = delegate
			{
				TweenScale tweenScale2 = TweenScale.Begin(go, downTime, new Vector3(popAmount, popAmount, 1f), new Vector3(1f, 1f, 1f));
				tweenScale2.method = UITweener.Method.EaseIn;
			};
		};
	}

	private void RollAnimation(GameObject goBackground, GameObject goArrow, float delay, bool toRight)
	{
		float width = widthOfBackground;
		float arrowPosition = positionOfArrow;
		float rollTime = 0.3f;
		TweenAlpha.Begin(goArrow, delay, 0f, 0f);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(goBackground, delay, 0f, 0f);
		tweenAlpha.onFinished = delegate
		{
			TweenAlpha.Begin(goBackground, 0.1f, 0f, 1f);
			TweenScale tweenScale = TweenScale.Begin(goBackground, rollTime, goArrow.transform.localScale.ReplaceX(0f), goArrow.transform.localScale.ReplaceX(width));
			tweenScale.method = UITweener.Method.Linear;
			TweenAlpha.Begin(goArrow, 0.1f, 0f, 1f);
			TweenPosition.Begin(goArrow, rollTime, goArrow.transform.localPosition.ReplaceX((!toRight) ? (arrowPosition - width) : (width - arrowPosition)), goArrow.transform.localPosition.ReplaceX((!toRight) ? (0f - arrowPosition) : arrowPosition));
		};
	}

	private void Update()
	{
		if (mUpdateArenaTime)
		{
			mTime += Time.deltaTime;
			if (mTime > 0.333f)
			{
				mTime -= 0.333f;
				arenaTime.text = WarArenaGui.CreateArenaWindowTimeText(encoding: false, moreLines: true);
			}
		}
	}
}
