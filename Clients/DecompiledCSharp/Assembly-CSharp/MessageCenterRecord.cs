using System;
using UnityEngine;

public class MessageCenterRecord : PoolableObject
{
	public enum RightButtonStates
	{
		none,
		blue,
		yellow
	}

	public enum BottomPanelStates
	{
		none,
		simple,
		reward,
		emblem,
		acceptPlayer
	}

	[Header("Background")]
	public UISprite background;

	public BoxCollider boxCollider;

	[Header("Header")]
	public UILabel messageName;

	public WinStreakCounter counter;

	[Header("-New")]
	public GameObject newStamp;

	public UILabel newLabel;

	public UISprite newBackground;

	[Header("Left Icon")]
	public UISprite messageIcon;

	public UISprite squadTierChallengeIcon;

	public UITexture leagueIcon;

	public UISprite adviseJoinOrCreateSquad;

	public GameObject rateNowPart;

	public GameObject moneyPackIconPart;

	public UILabel moneyPackSaleValue;

	public GameObject starterPackIconPart;

	public UILabel starterPackSaleValue;

	public GameObject depositIcon;

	[Header("Player Info")]
	public GameObject playerHolder;

	public UISprite personRank;

	public UILabel personRankNumber;

	public UILabel personName;

	public BoxCollider playerButton;

	public UILabel messageLabel;

	[Header("-Special Reward Part")]
	public UITable specialGoldRewardSocial;

	public UILabel specialGoldRewardNumber;

	[Header("Right Button")]
	public UISprite buttonSprite;

	[Header("-Simple Part")]
	public GameObject bottomSimplePanel;

	public UILabel simpleBottomDescription;

	[Header("-Emblem Part")]
	public GameObject bottomEmblemPanel;

	public UITexture emblemTexture;

	public UILabel emblemDescription;

	[Header("-Reward Part")]
	public GameObject bottomRewardPanel;

	public UITable rewardTable;

	public UILabel rewardDescription;

	public UISprite rewardIcon;

	public UILabel rewardAmount;

	[Header("-Accept player")]
	public GameObject bottomAcceptPlayerPanel;

	public GameObject yesButton;

	public GameObject noButton;

	public GameObject waiting;

	public UITable acceptInfoTable;

	public UILabel armyPower;

	public UILabel medalsNumber;

	public UISprite medalsIcon;

	[Header("-Warcard Withdrew")]
	public GameObject warcardWithdrewPart;

	public UITable reputationPointsTable;

	public UILabel reputationPointsLabel;

	public UISprite withdrewWarcardBackground;

	public UISprite withdrewWarcardIcon;

	public UITexture withdrewWarcardTexture;

	public UISprite withdrewWarcardBonusIcon;

	public UILabel withdrewWarcardBonusName;

	private DatabaseMessage mMessage;

	private DatabasePlayer mAcceptPlayer;

	private DatabasePlayer mPlayer;

	private Card mWithdrewWarcard;

	public bool canChallengePlayer
	{
		get
		{
			if (mPlayer == null)
			{
				return false;
			}
			if (mMessage is ChallengeMessage { expired: false })
			{
				return false;
			}
			return true;
		}
	}

	public float height => background.transform.localScale.y + 10f;

	public event Action OnClickEvent;

	public void SetAppearance_Challenge(DatabaseMessage.Type messageType, int messageTime, DatabasePlayer otherPlayer, bool isHitlist, bool isCoop, ChallengeMessage challengeMessage)
	{
		int num = Singleton<BeanstalkServerManager>.instance.currentTimestamp - messageTime;
		if (num < 120)
		{
			challengeMessage.expired = false;
			counter.StartMessageCenterCounter(120 - num);
			counter.winStreakTimer = delegate
			{
				Debug.Log("Challenge Counter expired!");
				counter.winStreakTimer = null;
				challengeMessage.expired = true;
			};
		}
		else
		{
			challengeMessage.expired = true;
			counter.counterLabel.text = Localization.Localize("ID_EXPIRED");
		}
		if (isHitlist)
		{
			SetMessage(Localization.Localize("ID_GUI_INVITETOFIGHT"));
		}
		else
		{
			SetMessage(Localization.Localize((!isCoop) ? "ID_GUI_INVITETOFIGHT" : "ID_GUI_INVITETOCOOP"));
		}
		SetHeader(messageType);
		SetIsNew();
		SetLeftIcon(messageType);
		HideSpecialRewardPart();
		InitPlayer(otherPlayer);
		SetRightButtonState(RightButtonStates.yellow);
		SetBottomPanel(BottomPanelStates.none);
		SetBackgroundHeight(RightButtonStates.yellow, BottomPanelStates.none);
	}

	public void SetAppearance_CheatWarning(DatabaseMessage.Type messageType, int messageTime, AntiCheatDetector.Cheat cheatType)
	{
		SetHeader(messageType);
		SetIsNew();
		StartCounterFrom(messageTime);
		HidePlayer();
		SetMessage(Localization.LocalizeFormat(MessageCenterTab.messageInfo[messageType].messageText, Colours.stringRed, Colours.stringWhite, cheatType));
		SetLeftIcon(messageType);
		HideSpecialRewardPart();
		SetRightButtonState(RightButtonStates.none);
		SetBottomPanel(BottomPanelStates.none);
		SetBackgroundHeight(RightButtonStates.blue, BottomPanelStates.none);
	}

	public void SetAppearance_LeagueEntered(DatabaseMessage.Type messageType, int messageTime, League league)
	{
		SetHeader(messageType);
		SetIsNew();
		StartCounterFrom(messageTime);
		HidePlayer();
		SetMessage(Localization.LocalizeFormat(MessageCenterTab.messageInfo[messageType].messageText, Colours.stringBlue, GameVariables.leagueNames[league].Value1));
		SetLeftIcon(messageType, league);
		HideSpecialRewardPart();
		SetRightButtonState(RightButtonStates.blue);
		SetBottomPanel(BottomPanelStates.none);
		SetBackgroundHeight(RightButtonStates.blue, BottomPanelStates.none);
	}

	public void SetAppearance_InformSquadLeader(DatabaseMessage.Type messageType, int messageTime)
	{
		SetHeader(messageType);
		StartCounterFrom(messageTime);
		HidePlayer();
		SetMessage(Localization.Localize(MessageCenterTab.messageInfo[messageType].messageText));
		SetLeftIcon(messageType);
		HideSpecialRewardPart();
		SetRightButtonState(RightButtonStates.blue);
		SetBottomPanel(BottomPanelStates.none);
		SetBackgroundHeight(RightButtonStates.blue, BottomPanelStates.none);
	}

	public void SetAppearance_SquadDemotion(DatabaseMessage.Type messageType, int messageTime, int newRank, DatabasePlayer player, DatabasePlayer executor)
	{
		SetIsNew();
		StartCounterFrom(messageTime);
		SetLeftIcon(messageType);
		HideSpecialRewardPart();
		SetRightButtonState(RightButtonStates.blue);
		SetBottomPanel(BottomPanelStates.none);
		if (newRank == -1)
		{
			if (player.id == GameLoginManager.currentPlayer.id)
			{
				InitPlayer(executor);
				messageLabel.text = Localization.LocalizeFormat("ID_KICKEDYOUFROMSQUAD", Colours.stringRed);
			}
			else
			{
				InitPlayer(player);
				messageLabel.text = Localization.LocalizeFormat("ID_GUI_SQUADKICKTEXT", Colours.stringRed);
			}
			SetHeaderText(Localization.Localize("ID_GUI_SQUADKICK"));
			messageLabel.lineWidth = 532;
			messageIcon.spriteName = "menu-sidetab-player-kick";
			messageIcon.MakePixelPerfect();
			float multiplier = 110f / Mathf.Max(messageIcon.transform.localScale.x, messageIcon.transform.localScale.y);
			messageIcon.transform.localScale = messageIcon.transform.localScale.MultiplyXY(multiplier);
		}
		else
		{
			InitPlayer(player);
			SetHeader(messageType);
			SetMessage(Localization.LocalizeFormat(MessageCenterTab.messageInfo[messageType].messageText, Colours.stringRed, Localization.Localize(GameVariables.squadFunctions[(SquadRank)newRank])));
		}
		SetBackgroundHeight(RightButtonStates.blue, BottomPanelStates.none);
	}

	public void SetAppearance_SquadEventEntered(DatabaseMessage.Type messageType, int messageTime)
	{
		SetHeader(messageType);
		SetIsNew();
		StartCounterFrom(messageTime);
		HidePlayer();
		SetMessage(Localization.LocalizeFormat(MessageCenterTab.messageInfo[messageType].messageText, Colours.stringBlue, Colours.stringWhite));
		SetLeftIcon(messageType);
		HideSpecialRewardPart();
		SetRightButtonState(RightButtonStates.blue);
		SetBottomPanel(BottomPanelStates.none);
		SetBackgroundHeight(RightButtonStates.blue, BottomPanelStates.none);
	}

	public void SetAppearance_SquadEventTierReward(DatabaseMessage.Type messageType, int messageTime, int tier, int reward)
	{
		SetHeader(messageType);
		SetIsNew();
		StartCounterFrom(messageTime);
		HidePlayer();
		SetMessage(Localization.LocalizeFormat(MessageCenterTab.messageInfo[messageType].messageText, Colours.stringBlue, Colours.stringYellow, tier, Colours.stringWhite));
		SetLeftIcon(messageType);
		HideSpecialRewardPart();
		SetRightButtonState(RightButtonStates.none);
		SetBottomPanel(BottomPanelStates.reward);
		rewardIcon.spriteName = "menu-gold";
		rewardDescription.text = Localization.LocalizeFormat("ID_GUI_TIERREWARD", tier);
		rewardAmount.text = MiscTools.FormatBigNumber(reward);
		rewardTable.repositionNow = true;
		SetBackgroundHeight(RightButtonStates.none, BottomPanelStates.reward);
	}

	public void SetAppearance_SquadEventEnded(DatabaseMessage.Type messageType, int messageTime, int currentTier, int maxTiers)
	{
		SetHeader(messageType);
		SetIsNew();
		StartCounterFrom(messageTime);
		HidePlayer();
		SetMessage(Localization.LocalizeFormat(MessageCenterTab.messageInfo[messageType].messageText, Colours.stringBlue, Colours.stringYellow, currentTier, Colours.stringWhite, maxTiers));
		SetLeftIcon(messageType);
		HideSpecialRewardPart();
		SetRightButtonState(RightButtonStates.none);
		SetBottomPanel(BottomPanelStates.none);
		SetBackgroundHeight(RightButtonStates.none, BottomPanelStates.none);
	}

	public void SetAppearance_SquadInvitation(DatabaseMessage.Type messageType, int messageTime, DatabasePlayer playerThatSendInvite)
	{
		SetIsNew();
		SetHeader(messageType);
		StartCounterFrom(messageTime);
		InitPlayer(playerThatSendInvite);
		SetMessage(Localization.Localize(MessageCenterTab.messageInfo[messageType].messageText));
		SetLeftIcon(messageType);
		HideSpecialRewardPart();
		SetRightButtonState(RightButtonStates.blue);
		SetBottomPanel(BottomPanelStates.none);
		SetBackgroundHeight(RightButtonStates.blue, BottomPanelStates.none);
	}

	public void SetAppearance_SquadJoined(DatabaseMessage.Type messageType, int messageTime, DatabasePlayer player)
	{
		SetIsNew();
		StartCounterFrom(messageTime);
		SetLeftIcon(messageType);
		HideSpecialRewardPart();
		SetRightButtonState(RightButtonStates.blue);
		SetBottomPanel(BottomPanelStates.none);
		if (player.id == GameLoginManager.currentPlayer.id)
		{
			SetHeaderText(Localization.Localize("ID_GUI_YAISN_HEADER"));
			SetMessage(Localization.LocalizeFormat("ID_GUI_YAISN_DESC", Colours.stringWhite, Colours.stringBlue, player.squadName));
			HidePlayer();
		}
		else
		{
			SetHeader(messageType);
			SetMessage(Localization.Localize(MessageCenterTab.messageInfo[messageType].messageText));
			InitPlayer(player);
		}
		SetBackgroundHeight(RightButtonStates.blue, BottomPanelStates.none);
	}

	public void SetAppearance_AcceptPlayer(DatabaseMessage.Type messageType, int messageTime, DatabasePlayer player)
	{
		mAcceptPlayer = player;
		AwaitingState awaitingState = Singleton<AwaitingSquadMembersManager>.instance.MemberState(player.id);
		boxCollider.enabled = awaitingState == AwaitingState.Error;
		yesButton.SetActive(awaitingState == AwaitingState.Response);
		noButton.SetActive(awaitingState == AwaitingState.Response);
		waiting.gameObject.SetActive(awaitingState == AwaitingState.Waiting);
		UIEventListener.Get(yesButton).onClick = delegate
		{
			if (Singleton<GuiManager>.instance.currentScreen != GuiScreenSingle<CardSelectionScreen>.instance)
			{
				TweenScale tweenScale = TweenScale.Begin(base.gameObject, 0.17f, Vector3.one, new Vector3(1.05f, 1.05f, 1f));
				tweenScale.style = UITweener.Style.PingPong;
				tweenScale.NumOfRepetitions = 2;
				tweenScale.method = UITweener.Method.EaseInOut;
				Singleton<AwaitingSquadMembersManager>.instance.YesClick(player.id);
				yesButton.SetActive(value: false);
				noButton.SetActive(value: false);
				waiting.gameObject.SetActive(value: true);
			}
		};
		UIEventListener.Get(noButton).onClick = delegate
		{
			if (Singleton<GuiManager>.instance.currentScreen != GuiScreenSingle<CardSelectionScreen>.instance)
			{
				TweenScale tweenScale = TweenScale.Begin(base.gameObject, 0.17f, Vector3.one, new Vector3(1.05f, 1.05f, 1f));
				tweenScale.style = UITweener.Style.PingPong;
				tweenScale.NumOfRepetitions = 2;
				tweenScale.method = UITweener.Method.EaseInOut;
				Singleton<AwaitingSquadMembersManager>.instance.NoClick(player.id);
				yesButton.SetActive(value: false);
				noButton.SetActive(value: false);
				waiting.gameObject.SetActive(value: true);
			}
		};
		SetLeftIcon(messageType);
		HideSpecialRewardPart();
		SetRightButtonState(RightButtonStates.none);
		InitPlayer(player, longSpaceForName: false);
		SetHeader(messageType);
		SetIsNew();
		StartCounterFrom(messageTime);
		if (awaitingState == AwaitingState.Error)
		{
			SetMessage(Localization.LocalizeFormat("ID_GUI_ACCEPT_PLAYER_CANTJOIN", Colours.stringRed));
			SetBottomPanel(BottomPanelStates.simple);
			simpleBottomDescription.text = Localization.LocalizeFormat("ID_GUI_ACCEPT_PLAYER_ALREADYMEMBER", Colours.stringWhite);
			SetBackgroundHeight(RightButtonStates.none, BottomPanelStates.simple);
			return;
		}
		SetMessage(Localization.LocalizeFormat(MessageCenterTab.messageInfo[messageType].messageText, Colours.stringBlue, Colours.stringWhite));
		SetBottomPanel(BottomPanelStates.acceptPlayer);
		armyPower.text = MiscTools.FormatBigNumber(player.armyPowerX10);
		medalsNumber.text = MiscTools.FormatBigNumber(player.skill);
		if (player.isInBeginnersLeague)
		{
			medalsIcon.gameObject.SetActive(value: true);
			medalsIcon.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(player.beginnersLeague);
			medalsIcon.MakePixelPerfect();
			medalsIcon.transform.localScale = medalsIcon.transform.localScale.MultiplyXY(0.634f);
			medalsIcon.alpha = 1f;
		}
		else
		{
			medalsIcon.gameObject.SetActive(player.leagueTier != League.NoLeague);
			if (medalsIcon.gameObject.activeSelf)
			{
				medalsIcon.spriteName = GameVariables.leagueNames[player.leagueTier].Value2;
				medalsIcon.MakePixelPerfect();
				medalsIcon.transform.localScale = medalsIcon.transform.localScale.MultiplyXY(0.634f);
				medalsIcon.alpha = ((!player.isInLeague) ? 0.5f : 1f);
			}
		}
		acceptInfoTable.repositionNow = true;
		SetBackgroundHeight(RightButtonStates.none, BottomPanelStates.acceptPlayer);
	}

	public void UpdateAcceptPlayer(string playerId)
	{
		if (mAcceptPlayer != null && mMessage.messageType == DatabaseMessage.Type.SquadJoinRequest && (string.IsNullOrEmpty(playerId) || !(mAcceptPlayer.id != playerId)))
		{
			SetAppearance_AcceptPlayer(mMessage.messageType, mMessage.messageTime, mAcceptPlayer);
		}
	}

	public void SetAppearance_SquadPromotion(DatabaseMessage.Type messageType, int messageTime, int newRank, DatabasePlayer player)
	{
		SetHeader(messageType);
		SetIsNew();
		StartCounterFrom(messageTime);
		InitPlayer(player);
		SetLeftIcon(messageType);
		HideSpecialRewardPart();
		SetMessage(Localization.LocalizeFormat(MessageCenterTab.messageInfo[messageType].messageText, Localization.Localize(GameVariables.squadFunctions[(SquadRank)newRank])));
		SetRightButtonState(RightButtonStates.blue);
		SetBottomPanel(BottomPanelStates.none);
		SetBackgroundHeight(RightButtonStates.blue, BottomPanelStates.none);
	}

	public void SetAppearance_SquadLevelUp(DatabaseMessage.Type messageType, int messageTime, int displayLevel)
	{
		int squadRankSize = Singleton<GameVariables>.instance.GetSquadRankSize(displayLevel - 1);
		int squadRankSize2 = Singleton<GameVariables>.instance.GetSquadRankSize(displayLevel);
		bool flag = squadRankSize2 > squadRankSize;
		int num = Singleton<GameVariables>.instance.SquadCardpoolSize(displayLevel - 1);
		int num2 = Singleton<GameVariables>.instance.SquadCardpoolSize(displayLevel);
		bool flag2 = num2 > num;
		string text = Singleton<GameVariables>.instance.SquadEmblemUnlockedOnLevel(displayLevel);
		bool flag3 = !string.IsNullOrEmpty(text);
		string empty = string.Empty;
		empty = (flag ? Localization.LocalizeFormat(MessageCenterTab.messageInfo[messageType].messageText, Colours.stringBlue, displayLevel, Colours.stringWhite, squadRankSize2) : ((!flag2) ? Localization.LocalizeFormat("ID_GUI_SQUADLEVELEDUP_NOINCR", Colours.stringBlue, displayLevel, Colours.stringWhite) : Localization.LocalizeFormat("ID_GUI_SQUADLEVELEDUP_CARDPOOLINC", Colours.stringBlue, displayLevel, Colours.stringWhite, num2)));
		SetHeader(messageType);
		SetIsNew();
		StartCounterFrom(messageTime);
		HidePlayer();
		SetMessage(empty);
		SetLeftIcon(messageType);
		HideSpecialRewardPart();
		SetRightButtonState(RightButtonStates.none);
		if (flag3)
		{
			SetBottomPanel(BottomPanelStates.emblem);
			emblemDescription.text = Localization.Localize("ID_GUI_EMBLEMUNLOCKED");
			emblemTexture.mainTexture = Resources.Load<Texture>("SquadIcons/" + text);
			emblemTexture.alpha = 1f;
			emblemTexture.MakePixelPerfect();
			float multiplier = 45f / 128f;
			emblemTexture.transform.localScale = emblemTexture.transform.localScale.MultiplyXY(multiplier);
			SetBackgroundHeight(RightButtonStates.none, BottomPanelStates.emblem);
		}
		else
		{
			SetBottomPanel(BottomPanelStates.none);
			SetBackgroundHeight(RightButtonStates.none, BottomPanelStates.none);
		}
	}

	public void SetAppearance_SquadWarsEnded(DatabaseMessage.Type messageType, int messageTime, int position, int yourReward, string squadName)
	{
		SetHeader(messageType);
		SetIsNew();
		StartCounterFrom(messageTime);
		HidePlayer();
		SetLeftIcon(messageType);
		HideSpecialRewardPart();
		SetRightButtonState(RightButtonStates.none);
		if (yourReward < 1)
		{
			SetMessage(Localization.LocalizeFormat("ID_GUI_SQUADWARSENDNOREWARD", squadName, Colours.stringBlue, position, Colours.stringGray));
			SetBottomPanel(BottomPanelStates.simple);
			simpleBottomDescription.text = Localization.Localize("ID_NOREWARD");
			SetBackgroundHeight(RightButtonStates.none, BottomPanelStates.simple);
		}
		else
		{
			SetMessage(Localization.LocalizeFormat("ID_GUI_SQUADWARSENDREWARD", squadName, Colours.stringBlue, position, Colours.stringGray));
			SetBottomPanel(BottomPanelStates.reward);
			rewardIcon.spriteName = "menu-gold";
			rewardDescription.text = Localization.Localize("ID_ROUNDREWARD");
			rewardAmount.text = MiscTools.FormatBigNumber(yourReward);
			rewardTable.repositionNow = true;
			SetBackgroundHeight(RightButtonStates.none, BottomPanelStates.reward);
		}
	}

	public void SetAppearance_WarcardWithdrew(DatabaseMessage.Type messageType, int messageTime, DatabasePlayer player, Card withdrewCard, int addedPoints)
	{
		SetHeader(messageType);
		SetIsNew();
		StartCounterFrom(messageTime);
		InitPlayer(player);
		SetMessage(string.Empty);
		SetLeftIcon(messageType);
		SetWarcardWithdrew(withdrewCard, addedPoints);
		HideSpecialRewardPart();
		SetRightButtonState(RightButtonStates.blue);
		SetBottomPanel(BottomPanelStates.none);
		SetBackgroundHeight(RightButtonStates.blue, BottomPanelStates.none);
	}

	public void SetAppearance_DepositWarcards(DatabaseMessage.Type messageType, int messageTime, DatabasePlayer player)
	{
		SetHeader(messageType);
		SetIsNew();
		StartCounterFrom(messageTime);
		InitPlayer(player);
		SetMessage(Localization.LocalizeFormat(MessageCenterTab.messageInfo[messageType].messageText, Colours.stringPink, Colours.stringWhite));
		SetLeftIcon(messageType);
		HideSpecialRewardPart();
		SetRightButtonState(RightButtonStates.blue);
		SetBottomPanel(BottomPanelStates.none);
		SetBackgroundHeight(RightButtonStates.blue, BottomPanelStates.none);
	}

	public void SetAppearance_BeAdvisedFacebook(DatabaseMessage.Type messageType, int messageTime)
	{
		SetHeader(messageType);
		SetIsNew();
		StartCounterFrom(messageTime);
		HidePlayer();
		SetMessage(Localization.LocalizeFormat(MessageCenterTab.messageInfo[messageType].messageText, Colours.stringBlue, Colours.stringWhite));
		SetLeftIcon(messageType);
		HideSpecialRewardPart();
		SetRightButtonState(RightButtonStates.blue);
		SetBottomPanel(BottomPanelStates.none);
		SetBackgroundHeight(RightButtonStates.blue, BottomPanelStates.none);
	}

	public void SetAppearance_GenericGetFreeGoldWithSocial(DatabaseMessage.Type messageType, int messageTime, int goldNumber)
	{
		SetHeader(messageType);
		SetIsNew();
		StartCounterFrom(messageTime);
		HidePlayer();
		SetMessage(Localization.LocalizeFormat(MessageCenterTab.messageInfo[messageType].messageText, Colours.stringBlue));
		SetLeftIcon(messageType);
		ShowSpecialRewardPart(goldNumber);
		SetRightButtonState(RightButtonStates.blue);
		SetBottomPanel(BottomPanelStates.none);
		SetBackgroundHeight(RightButtonStates.blue, BottomPanelStates.none);
	}

	public void SetAppearance_BeAdvisedJoinOrCreateSquad(DatabaseMessage.Type messageType, int messageTime)
	{
		SetHeader(messageType);
		SetIsNew();
		StartCounterFrom(messageTime);
		HidePlayer();
		SetMessage(Localization.LocalizeFormat(MessageCenterTab.messageInfo[messageType].messageText, Colours.stringBlue, Colours.stringWhite));
		SetLeftIcon(messageType);
		HideSpecialRewardPart();
		SetRightButtonState(RightButtonStates.blue);
		SetBottomPanel(BottomPanelStates.none);
		SetBackgroundHeight(RightButtonStates.blue, BottomPanelStates.none);
	}

	public void SetAppearance_BeAdvisedVIP(DatabaseMessage.Type messageType, int messageTime)
	{
		SetHeader(messageType);
		SetIsNew();
		StartCounterFrom(messageTime);
		HidePlayer();
		SetMessage(Localization.LocalizeFormat(MessageCenterTab.messageInfo[messageType].messageText, Colours.stringBlue, Colours.stringWhite));
		SetLeftIcon(messageType);
		HideSpecialRewardPart();
		SetRightButtonState(RightButtonStates.blue);
		SetBottomPanel(BottomPanelStates.none);
		SetBackgroundHeight(RightButtonStates.blue, BottomPanelStates.none);
	}

	public void SetAppearance_SystemMessage(DatabaseMessage.Type messageType, int messageTime, string date)
	{
		SetHeader(messageType);
		SetIsNew();
		StartCounterFrom(messageTime);
		HidePlayer();
		SetMessage(Localization.LocalizeFormat(MessageCenterTab.messageInfo[messageType].messageText, Colours.stringRed, Colours.stringWhite, date));
		SetLeftIcon(messageType);
		HideSpecialRewardPart();
		SetRightButtonState(RightButtonStates.none);
		SetBottomPanel(BottomPanelStates.none);
		SetBackgroundHeight(RightButtonStates.none, BottomPanelStates.none);
	}

	public void SetAppearance_VIPAlmostEnded(DatabaseMessage.Type messageType, int messageTime, int secondsLeft)
	{
		SetHeader(messageType);
		SetIsNew();
		StartCounterFrom(messageTime);
		HidePlayer();
		SetMessage(Localization.LocalizeFormat(MessageCenterTab.messageInfo[messageType].messageText, Colours.stringBlue, Colours.stringRed, MiscTools.PrintableTime(secondsLeft, "ID_READYTIME", string.Empty)));
		SetLeftIcon(messageType);
		HideSpecialRewardPart();
		SetRightButtonState(RightButtonStates.blue);
		SetBottomPanel(BottomPanelStates.none);
		SetBackgroundHeight(RightButtonStates.blue, BottomPanelStates.none);
	}

	public void SetAppearance_VIPExpired(DatabaseMessage.Type messageType, int messageTime)
	{
		SetHeader(messageType);
		SetIsNew();
		StartCounterFrom(messageTime);
		HidePlayer();
		SetMessage(Localization.LocalizeFormat(MessageCenterTab.messageInfo[messageType].messageText, Colours.stringRed, Colours.stringWhite));
		SetLeftIcon(messageType);
		HideSpecialRewardPart();
		SetRightButtonState(RightButtonStates.blue);
		SetBottomPanel(BottomPanelStates.none);
		SetBackgroundHeight(RightButtonStates.blue, BottomPanelStates.none);
	}

	public void SetAppearance_TimeLimitedOffer(DatabaseMessage.Type messageType, int messageTime)
	{
		SetHeader(messageType);
		SetIsNew();
		StartCounterFrom(messageTime);
		HidePlayer();
		int num = PlayerAnalytics.instance.data.moneyPackDeadline - Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		SetMessage(Localization.LocalizeFormat(MessageCenterTab.messageInfo[messageType].messageText, Colours.stringBlue, Colours.stringWhite, MiscTools.PrintableTime(num, "-", string.Empty)));
		moneyPackSaleValue.text = Localization.LocalizeFormat("ID_SALEPERCENT", MiscTools.RoundToInt(Singleton<GameVariables>.instance.SaleOfPack(CardPack.Money) * 100f));
		SetLeftIcon(messageType);
		HideSpecialRewardPart();
		SetRightButtonState(RightButtonStates.none);
		SetBottomPanel(BottomPanelStates.none);
		SetBackgroundHeight(RightButtonStates.none, BottomPanelStates.none);
	}

	public void SetAppearance_StarterPackTimeLimitedOffer(DatabaseMessage.Type messageType, int messageTime)
	{
		SetHeader(messageType);
		SetIsNew();
		StartCounterFrom(messageTime);
		HidePlayer();
		int num = PlayerAnalytics.instance.data.starterPackDeadline - Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		SetMessage(Localization.LocalizeFormat(MessageCenterTab.messageInfo[messageType].messageText, Colours.stringBlue, Colours.stringWhite, MiscTools.PrintableTime(num, "-", string.Empty)));
		starterPackSaleValue.text = Localization.LocalizeFormat("ID_SALEPERCENT", MiscTools.RoundToInt(Singleton<GameVariables>.instance.SaleOfPack(CardPack.Starter) * 100f));
		SetLeftIcon(messageType);
		HideSpecialRewardPart();
		SetRightButtonState(RightButtonStates.none);
		SetBottomPanel(BottomPanelStates.none);
		SetBackgroundHeight(RightButtonStates.none, BottomPanelStates.none);
	}

	public void SetAppearance_InGameMessage(DatabaseMessage.Type messageType, int messageTime, bool isNew, string title, DateTime timeCreated)
	{
		SetHeader(messageType);
		SetIsNew(isNew);
		StartCounterFrom(messageTime);
		HidePlayer();
		SetMessage($"{Colours.stringBlue}{title}\n{Colours.stringWhite}{MiscTools.GetPrintableDate(timeCreated)}");
		SetLeftIcon(messageType);
		HideSpecialRewardPart();
		SetRightButtonState(RightButtonStates.blue);
		SetBottomPanel(BottomPanelStates.none);
		SetBackgroundHeight(RightButtonStates.blue, BottomPanelStates.none);
	}

	private void OnClick()
	{
		bool flag = Singleton<GuiManager>.instance.currentScreen == GuiScreenSingle<CardSelectionScreen>.instance;
		if (flag && !mMessage.canBeClickedInLobby)
		{
			Debug.Log("This notification record cannot be click while in Lobby screen");
		}
		else if (flag && mMessage.actionLeavesLobby)
		{
			if (!GuiScreenSingle<CardSelectionScreen>.instance.isFullyShowed)
			{
				return;
			}
			SoundsManager.Instance.PlayButtonClickedSound();
			if (Singleton<GameController>.instance.isWarArena)
			{
				ConfirmDialog.ShowConfirm("LEAVING ARENA BATTLE", "You are about to LEAVE the Arena lobby during matchmaking. This will count as a DEFEAT and you will lose a HEART. Do you really want to leave?", delegate(ConfirmDialog dialog, bool result)
				{
					if (result)
					{
						SuccessClick();
					}
				}, 0.2f);
			}
			else if (!string.IsNullOrEmpty(Singleton<GameController>.instance.mainController.quitText))
			{
				ConfirmDialog.ShowConfirm(Localization.Localize("ID_CONFIRM_EXITINGMATCH"), Singleton<GameController>.instance.mainController.quitText, delegate(ConfirmDialog dialog, bool result)
				{
					if (result)
					{
						SuccessClick();
					}
				}, 0.2f);
			}
			else
			{
				SuccessClick();
			}
		}
		else
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			SuccessClick();
		}
	}

	private void SuccessClick()
	{
		if (this.OnClickEvent != null)
		{
			this.OnClickEvent();
		}
		GuiElementSingle<ChatGuiElement>.instance.messageContent.RemoveMessage(mMessage);
	}

	internal void Initialize(DatabaseMessage message, bool forCountingHeight = false)
	{
		mMessage = message;
		this.OnClickEvent = message.InitMessageCenterRecord(this);
		if (!forCountingHeight)
		{
			message.messageShown = true;
		}
		rewardTable.onReposition = delegate
		{
			float val = 0f - rewardTable.padding.x - (rewardAmount.transform.parent.transform.localPosition.x - rewardTable.padding.x) / 2f;
			rewardTable.transform.localPosition = rewardTable.transform.localPosition.ReplaceX(val);
		};
	}

	public void FakeDestroyPooled()
	{
		if (mMessage != null)
		{
			if (mMessage.messageType == DatabaseMessage.Type.Challenge)
			{
				counter.StopMessageCenterCounter();
			}
			else
			{
				counter.StopTimer();
			}
		}
		UIEventListener.Get(playerButton.gameObject).onClick = null;
		UIEventListener.Get(yesButton).onClick = null;
		UIEventListener.Get(noButton).onClick = null;
		if (warcardWithdrewPart.activeSelf && mWithdrewWarcard != null && mWithdrewWarcard.isBuddyCard)
		{
			mWithdrewWarcard.HideInMenu();
		}
		mAcceptPlayer = null;
		mMessage = null;
		mPlayer = null;
		mWithdrewWarcard = null;
	}

	public override void DestroyPooled()
	{
		FakeDestroyPooled();
		leagueIcon.mainTexture = null;
		emblemTexture.mainTexture = null;
		base.DestroyPooled();
	}

	private void SetHeader(DatabaseMessage.Type messageType)
	{
		SetHeaderText((!(MessageCenterTab.messageInfo[messageType].headerText == string.Empty)) ? Localization.Localize(MessageCenterTab.messageInfo[messageType].headerText) : string.Empty);
	}

	private void SetHeaderText(string titleText)
	{
		messageName.text = titleText;
		int width = ((!newStamp.activeSelf) ? (476 - (int)(newLabel.relativeSize.x * newLabel.transform.localScale.x)) : 500);
		MiscTools.SetUILabelRescale(messageName, 28f, 20f, width);
	}

	private void SetIsNew(bool showNew = false)
	{
		newStamp.SetActive(showNew);
		if (newStamp.activeSelf)
		{
			float num = 24f + newLabel.relativeSize.x * newLabel.transform.localScale.x;
			newBackground.transform.localScale = newBackground.transform.localScale.ReplaceX(num);
			messageName.transform.localPosition = messageName.transform.localPosition.ReplaceX(-357f + num - 12f);
		}
		else
		{
			messageName.transform.localPosition = messageName.transform.localPosition.ReplaceX(-357f);
		}
		SetHeaderText(messageName.text);
	}

	private void StartCounterFrom(int messageTime)
	{
		counter.StartTimer(messageTime);
	}

	private void InitPlayer(DatabasePlayer player, bool longSpaceForName = true)
	{
		playerHolder.SetActive(value: true);
		messageLabel.transform.localPosition = messageLabel.transform.localPosition.ReplaceY(-82f);
		personName.text = player.name;
		TweenColor.Begin(personName.gameObject, 0f, Colours.blue);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(player.level);
		personRank.spriteName = levelDefinition.iconName;
		personRankNumber.text = levelDefinition.displayString;
		int width = ((!longSpaceForName) ? 337 : 474);
		MiscTools.SetUILabelRescale(personName, 37f, 11f, width);
		playerButton.center = new Vector3((!longSpaceForName) ? 160f : 240f, 0f, -22f);
		playerButton.size = new Vector3((!longSpaceForName) ? 350f : 490f, 55f, 1f);
		mPlayer = player;
		UIEventListener.Get(playerButton.gameObject).onClick = delegate
		{
			if (!string.IsNullOrEmpty(mPlayer.name))
			{
				TweenColor tweenColor = TweenColor.Begin(personName.gameObject, GameVariables.durationOfNameButtonColor, Colours.blue, Color.white);
				tweenColor.NumOfRepetitions = 2;
				tweenColor.style = UITweener.Style.PingPong;
				SoundsManager.Instance.PlayButtonClickedSound();
				GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(mPlayer.name, mPlayer.id, canChallengePlayer);
			}
		};
	}

	private void HidePlayer()
	{
		playerHolder.SetActive(value: false);
		messageLabel.transform.localPosition = messageLabel.transform.localPosition.ReplaceY(-31f);
	}

	private void SetMessage(string messageText, bool shorter = false)
	{
		messageLabel.text = messageText;
		messageLabel.lineWidth = ((!shorter) ? 532 : 392);
	}

	private void SetLeftIcon(DatabaseMessage.Type messageType, League league = League.NoLeague)
	{
		squadTierChallengeIcon.gameObject.SetActive(messageType == DatabaseMessage.Type.InformSquadLeaderAboutEvent || messageType == DatabaseMessage.Type.UnitReadyForPromotion || messageType == DatabaseMessage.Type.SquadEventTierReward || messageType == DatabaseMessage.Type.WelcomBackSoldierMessage);
		leagueIcon.gameObject.SetActive(messageType == DatabaseMessage.Type.LeagueEntered);
		adviseJoinOrCreateSquad.gameObject.SetActive(messageType == DatabaseMessage.Type.BeAdvisedJoinOrCreateSquad);
		moneyPackIconPart.SetActive(messageType == DatabaseMessage.Type.TimeLimitedOffer);
		starterPackIconPart.SetActive(messageType == DatabaseMessage.Type.StarterPackTimeLimitedOffer);
		rateNowPart.SetActive(messageType == DatabaseMessage.Type.EnablePushNotificationMessage);
		warcardWithdrewPart.SetActive(messageType == DatabaseMessage.Type.SquadDepositedCardsChanged);
		depositIcon.SetActive(messageType == DatabaseMessage.Type.DepositWarcards);
		switch (messageType)
		{
		case DatabaseMessage.Type.LeagueEntered:
		{
			leagueIcon.mainTexture = Resources.Load<Texture>("Medals/" + GameVariables.leagueNames[league].Value2);
			leagueIcon.MakePixelPerfect();
			float multiplier = 110f / leagueIcon.transform.localScale.x;
			leagueIcon.transform.localScale = leagueIcon.transform.localScale.MultiplyXY(multiplier);
			break;
		}
		case DatabaseMessage.Type.InformSquadLeaderAboutEvent:
			squadTierChallengeIcon.color = Color.white;
			squadTierChallengeIcon.spriteName = "menu-sidetab-challenge-start";
			squadTierChallengeIcon.MakePixelPerfect();
			break;
		case DatabaseMessage.Type.UnitReadyForPromotion:
			squadTierChallengeIcon.color = Colours.blue;
			squadTierChallengeIcon.spriteName = "menu-sidetab-challenge-start";
			squadTierChallengeIcon.MakePixelPerfect();
			break;
		case DatabaseMessage.Type.SquadEventTierReward:
			squadTierChallengeIcon.color = Colours.goldTier;
			squadTierChallengeIcon.spriteName = "menu-sidetab-challenge";
			squadTierChallengeIcon.MakePixelPerfect();
			break;
		case DatabaseMessage.Type.WelcomBackSoldierMessage:
			squadTierChallengeIcon.color = Colours.blue;
			squadTierChallengeIcon.spriteName = "menu-sidetab-challenge";
			squadTierChallengeIcon.MakePixelPerfect();
			break;
		}
		messageIcon.gameObject.SetActive(!squadTierChallengeIcon.gameObject.activeSelf && !leagueIcon.gameObject.activeSelf && !adviseJoinOrCreateSquad.gameObject.activeSelf && !moneyPackIconPart.activeSelf && !starterPackIconPart.activeSelf && !rateNowPart.activeSelf && !warcardWithdrewPart.activeSelf && !depositIcon.activeSelf);
		if (messageIcon.gameObject.activeSelf)
		{
			messageIcon.color = Color.white;
			if (messageType == DatabaseMessage.Type.CheatWarning)
			{
				messageIcon.color = Colours.redLose;
			}
			if (messageType == DatabaseMessage.Type.FollowUsOnTwitter || messageType == DatabaseMessage.Type.TweetAboutWarfriends)
			{
				messageIcon.color = Colours.blue;
			}
			messageIcon.spriteName = MessageCenterTab.messageInfo[messageType].iconName;
			messageIcon.MakePixelPerfect();
			float multiplier2 = 110f / Mathf.Max(messageIcon.transform.localScale.x, messageIcon.transform.localScale.y);
			messageIcon.transform.localScale = messageIcon.transform.localScale.MultiplyXY(multiplier2);
		}
	}

	private void SetWarcardWithdrew(Card withdrewCard, int addedReputationPoints)
	{
		warcardWithdrewPart.SetActive(value: true);
		reputationPointsLabel.text = MiscTools.FormatMedalsDifference(addedReputationPoints);
		reputationPointsTable.repositionNow = true;
		mWithdrewWarcard = withdrewCard;
		mWithdrewWarcard.ShowInMenu();
		withdrewCard.SetUpSmallCard(withdrewWarcardBackground, withdrewWarcardIcon, withdrewWarcardBonusIcon, withdrewWarcardBonusName, withdrewWarcardTexture);
	}

	private void ShowSpecialRewardPart(int goldNumber)
	{
		if (goldNumber == 0)
		{
			HideSpecialRewardPart();
			return;
		}
		specialGoldRewardSocial.gameObject.SetActive(value: true);
		float val = messageLabel.transform.localPosition.y - messageLabel.relativeSize.y * messageLabel.transform.localScale.y;
		specialGoldRewardSocial.transform.localPosition = specialGoldRewardSocial.transform.localPosition.ReplaceY(val);
		specialGoldRewardNumber.text = string.Format("{0} {1}", goldNumber, Localization.Localize("ID_GUI_LIKEFB_NOW"));
		specialGoldRewardSocial.repositionNow = true;
	}

	private void HideSpecialRewardPart()
	{
		specialGoldRewardSocial.gameObject.SetActive(value: false);
	}

	private void SetRightButtonState(RightButtonStates state)
	{
		buttonSprite.gameObject.SetActive(state != RightButtonStates.none);
		if (buttonSprite.gameObject.activeSelf)
		{
			buttonSprite.spriteName = ((state != RightButtonStates.yellow) ? "menu-sidetab-bg-box-button" : "menu-sidetab-bg-box-button-gold");
		}
	}

	private void SetBottomPanel(BottomPanelStates state)
	{
		bottomEmblemPanel.gameObject.SetActive(state == BottomPanelStates.emblem);
		bottomSimplePanel.gameObject.SetActive(state == BottomPanelStates.simple);
		bottomRewardPanel.gameObject.SetActive(state == BottomPanelStates.reward);
		bottomAcceptPlayerPanel.gameObject.SetActive(state == BottomPanelStates.acceptPlayer);
	}

	private void SetBackgroundHeight(RightButtonStates buttonState, BottomPanelStates panelState)
	{
		bool flag = messageLabel.transform.localPosition.y > -70f;
		float num = ((!specialGoldRewardSocial.gameObject.activeSelf) ? 0f : 45f);
		float num2 = messageLabel.relativeSize.y * messageLabel.transform.localScale.y + num;
		float num3 = Mathf.Max(156f, ((!flag) ? 111f : 60f) + num2);
		float val = num3 + 70f;
		background.transform.localScale = background.transform.localScale.ReplaceY(val);
		if (buttonState != RightButtonStates.none)
		{
			buttonSprite.transform.localScale = buttonSprite.transform.localScale.ReplaceY(num3);
		}
		if (panelState != BottomPanelStates.none)
		{
			float val2 = 0f - background.transform.localScale.y - 45f;
			bottomEmblemPanel.transform.localPosition = bottomEmblemPanel.transform.localScale.ReplaceY(val2);
			bottomSimplePanel.transform.localPosition = bottomSimplePanel.transform.localScale.ReplaceY(val2);
			bottomRewardPanel.transform.localPosition = bottomRewardPanel.transform.localScale.ReplaceY(val2);
			bottomAcceptPlayerPanel.transform.localPosition = bottomAcceptPlayerPanel.transform.localScale.ReplaceY(val2);
			background.transform.localScale = background.transform.localScale.AddY(100f);
		}
		boxCollider.center = boxCollider.center.ReplaceY(0f - background.transform.localScale.y / 2f);
		boxCollider.size = boxCollider.size.ReplaceY(background.transform.localScale.y);
	}

	protected void Update()
	{
		if (!withdrewWarcardTexture.gameObject.activeSelf && mWithdrewWarcard != null && mWithdrewWarcard.iconTexture != null)
		{
			withdrewWarcardIcon.gameObject.SetActive(value: false);
			withdrewWarcardTexture.gameObject.SetActive(value: true);
			withdrewWarcardTexture.mainTexture = mWithdrewWarcard.iconTexture;
		}
	}
}
