using System;
using System.Collections.Generic;
using UnityEngine;

public class ChatRecord : PoolableObject
{
	[Header("Time Info")]
	public GameObject timePart;

	public WinStreakCounter timeCounter;

	[Header("Chat Message")]
	public GameObject chatPart;

	public UISprite border;

	[Header("-Header Left")]
	public UISprite rankIcon;

	public UILabel rankLabel;

	public UILabel nameLabel;

	public UISprite crownSprite;

	public GameObject playerButton;

	[Header("-Header Right Message")]
	public GameObject fullHeaderHolder;

	public UITexture squadIconTexture;

	public UILabel squadName;

	public UIButton squadButton;

	public UISprite leagueIcon;

	public UISprite backgroundSmallTriangle;

	[Header("-Header Right SquadAction")]
	public GameObject simpleHeaderHolder;

	public UITable simpleTable;

	public UISprite simpleSprite;

	public UILabel simpleDesc;

	[Header("-Right SquadAction ByPlayer")]
	public UITable byPlayerTable;

	public UISprite byPlayerLevelIcon;

	public UILabel byPlayerLevelName;

	public UILabel byPlayerName;

	public BoxCollider byPlayerButton;

	[Header("-Content")]
	public GameObject contentHolder;

	public UISprite background;

	public UILabel messageLabel;

	public UIButton abuseButton;

	private float mHeight = 116f;

	private Chat.ChatRecordData mData;

	private static Dictionary<Chat.SquadActionType, Tuple<string, Color, float, string>> mSquadAction = new Dictionary<Chat.SquadActionType, Tuple<string, Color, float, string>>
	{
		{
			Chat.SquadActionType.Promotion,
			new Tuple<string, Color, float, string>("menu-button-promote-ico", Colours.cyan, 0f, "ID_GUI_CHAT_SQUAD_PROMOTED")
		},
		{
			Chat.SquadActionType.Demotion,
			new Tuple<string, Color, float, string>("menu-button-promote-ico", Color.red, 180f, "ID_GUI_CHAT_SQUAD_DEMOTED")
		},
		{
			Chat.SquadActionType.Kick,
			new Tuple<string, Color, float, string>("menu-close", Color.red, 0f, "ID_GUI_CHAT_SQUAD_KICK")
		},
		{
			Chat.SquadActionType.JoinedSquad,
			new Tuple<string, Color, float, string>("menu-addsoldier-ico", Color.white, 0f, "ID_GUI_CHAT_SQUAD_JOINED")
		},
		{
			Chat.SquadActionType.Left,
			new Tuple<string, Color, float, string>("menu-close", Color.red, 0f, "ID_GUI_CHAT_SQUAD_LEFT")
		}
	};

	public float Height => mHeight;

	public void InitEmpty()
	{
		chatPart.SetActive(value: false);
		timePart.SetActive(value: false);
		mHeight = 5f;
	}

	public void InitChatMessage(Chat.ChatRecordData data)
	{
		mData = data;
		UIEventListener uIEventListener = UIEventListener.Get(playerButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(PlayerNameClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(playerButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PlayerNameClick));
		UIEventListener uIEventListener3 = UIEventListener.Get(squadButton.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(SquadNameClick));
		UIEventListener uIEventListener4 = UIEventListener.Get(squadButton.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(SquadNameClick));
		UIEventListener uIEventListener5 = UIEventListener.Get(abuseButton.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(ChatAbuseButtonClick));
		UIEventListener uIEventListener6 = UIEventListener.Get(abuseButton.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(ChatAbuseButtonClick));
		UIEventListener uIEventListener7 = UIEventListener.Get(byPlayerButton.gameObject);
		uIEventListener7.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener7.onClick, new UIEventListener.VoidDelegate(ByPlayerNameClick));
		UIEventListener uIEventListener8 = UIEventListener.Get(byPlayerButton.gameObject);
		uIEventListener8.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener8.onClick, new UIEventListener.VoidDelegate(ByPlayerNameClick));
		squadButton.gameObject.SetActive(!string.IsNullOrEmpty(data.squadName) && !data.squadMessage);
		bool flag = data.playerId == GameLoginManager.currentPlayer.id;
		abuseButton.gameObject.SetActive(!flag && data.chatType == Chat.ChatMessageType.Message);
		if (data.chatType == Chat.ChatMessageType.Timer)
		{
			InitTimeCounter(data.time);
			return;
		}
		InitChatPart(data.name, data.level, data.warArenaCrown);
		if (data.chatType == Chat.ChatMessageType.Message)
		{
			if (data.squadMessage)
			{
				InitSquadMessage(data.squadRank, data.isBeginnersLeague, data.beginnersLeague, data.league, data.message, flag);
			}
			else
			{
				InitNormalMessage(data.squadName, data.squadIcon, data.isBeginnersLeague, data.beginnersLeague, data.league, data.message, flag);
			}
		}
		else
		{
			InitSquadAction(data.squadActionType, data.newSquadRank, data.byPlayer);
			data.databaseMessage.messageShown = true;
		}
	}

	public void InitializeForHeightOnly(Chat.ChatRecordData data)
	{
		if (data.chatType == Chat.ChatMessageType.Timer)
		{
			mHeight = 60f;
			return;
		}
		chatPart.SetActive(value: true);
		timePart.SetActive(value: false);
		if (data.chatType == Chat.ChatMessageType.Message)
		{
			messageLabel.text = data.message;
		}
		else
		{
			byPlayerTable.gameObject.SetActive(data.byPlayer != null);
		}
		SetUpSize(data.chatType == Chat.ChatMessageType.Message, setAlsoLook: false);
	}

	private void PlayerNameClick(GameObject go)
	{
		if (!string.IsNullOrEmpty(mData.name))
		{
			TweenColor tweenColor = TweenColor.Begin(nameLabel.gameObject, GameVariables.durationOfNameButtonColor, Colours.blue, Color.white);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(mData.name, mData.playerId);
		}
	}

	private void SquadNameClick(GameObject go)
	{
		TweenColor tweenColor = TweenColor.Begin(squadName.gameObject, GameVariables.durationOfNameButtonColor, Color.white, Colours.blue);
		tweenColor.NumOfRepetitions = 2;
		tweenColor.style = UITweener.Style.PingPong;
		SoundsManager.Instance.PlayButtonClickedSound();
		GuiElementSingle<SquadDetailsDialog>.instance.ShowDialog(mData.squadName);
	}

	private void ChatAbuseButtonClick(GameObject go)
	{
		ChatAbuseDialog.ShowAbuseDialog(mData.playerId, mData.message);
	}

	private void ByPlayerNameClick(GameObject go)
	{
		if (mData.byPlayer != null && !string.IsNullOrEmpty(mData.byPlayer.name))
		{
			TweenColor tweenColor = TweenColor.Begin(byPlayerName.gameObject, GameVariables.durationOfNameButtonColor, Colours.blue, Color.white);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(mData.byPlayer.name, mData.byPlayer.id);
		}
	}

	private void InitTimeCounter(int startTime)
	{
		chatPart.SetActive(value: false);
		timePart.SetActive(value: true);
		mHeight = 60f;
		timeCounter.StartChatTimer(startTime);
	}

	private void InitChatPart(string player, int level, WarArenaCrown warArenaCrown)
	{
		chatPart.SetActive(value: true);
		timePart.SetActive(value: false);
		int num = 290;
		bool flag = warArenaCrown != WarArenaCrown.None;
		crownSprite.gameObject.SetActive(flag);
		if (flag)
		{
			crownSprite.spriteName = GameVariables.crownSprites[warArenaCrown];
			crownSprite.MakePixelPerfect();
			float multiplier = Mathf.Min(30f / crownSprite.transform.localScale.x, 40f / crownSprite.transform.localScale.y);
			crownSprite.transform.localScale = crownSprite.transform.localScale.MultiplyXY(multiplier);
			num -= 40;
		}
		nameLabel.text = player;
		TweenColor.Begin(nameLabel.gameObject, 0f, Colours.blue);
		MiscTools.SetUILabelRescale(nameLabel, 33f, 20f, num);
		if (flag)
		{
			float num2 = nameLabel.relativeSize.x * nameLabel.transform.localScale.x;
			float val = nameLabel.transform.localPosition.x + num2 + 8f + crownSprite.transform.localScale.x / 2f;
			crownSprite.transform.localPosition = crownSprite.transform.localPosition.ReplaceX(val);
		}
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(level);
		rankIcon.spriteName = levelDefinition.iconName;
		rankIcon.MakePixelPerfect();
		rankLabel.text = levelDefinition.displayString;
	}

	private void InitSquadAction(Chat.SquadActionType type, int newSquadRank, DatabasePlayer byPlayer)
	{
		fullHeaderHolder.SetActive(value: false);
		contentHolder.SetActive(value: false);
		simpleHeaderHolder.SetActive(value: true);
		byPlayerTable.gameObject.SetActive(byPlayer != null);
		simpleSprite.gameObject.SetActive(!string.IsNullOrEmpty(mSquadAction[type].Value1));
		if (simpleSprite.gameObject.activeSelf)
		{
			simpleSprite.spriteName = mSquadAction[type].Value1;
			simpleSprite.MakePixelPerfect();
			simpleSprite.color = mSquadAction[type].Value2;
			simpleSprite.transform.localRotation = Quaternion.Euler(0f, 0f, mSquadAction[type].Value3);
			float multiplier = 28f / simpleSprite.transform.localScale.y;
			simpleSprite.transform.localScale = simpleSprite.transform.localScale.MultiplyXY(multiplier);
		}
		switch (type)
		{
		case Chat.SquadActionType.Demotion:
		{
			string text2 = Localization.Localize(GameVariables.squadFunctions[(SquadRank)newSquadRank]);
			simpleDesc.text = Localization.LocalizeFormat(mSquadAction[type].Value4, Colours.stringRed, text2);
			break;
		}
		case Chat.SquadActionType.Kick:
			simpleDesc.text = Localization.LocalizeFormat(mSquadAction[type].Value4, Colours.stringRed);
			break;
		case Chat.SquadActionType.Promotion:
		{
			string text = Localization.Localize(GameVariables.squadFunctions[(SquadRank)newSquadRank]);
			simpleDesc.text = Localization.LocalizeFormat(mSquadAction[type].Value4, Colours.stringCyan, text);
			break;
		}
		case Chat.SquadActionType.JoinedSquad:
			simpleDesc.text = Localization.Localize(mSquadAction[type].Value4);
			break;
		case Chat.SquadActionType.Left:
			simpleDesc.text = Localization.Localize(mSquadAction[type].Value4);
			break;
		default:
			simpleDesc.text = Localization.Localize(mSquadAction[type].Value4);
			break;
		}
		ResizeNameSquadActionDescription();
		float num = nameLabel.relativeSize.x * nameLabel.transform.localScale.x;
		float num2 = nameLabel.transform.localPosition.x + num + 10f;
		if (crownSprite.gameObject.activeSelf)
		{
			num2 += 8f + crownSprite.transform.localScale.x;
		}
		simpleTable.transform.localPosition = simpleTable.transform.localPosition.ReplaceX(num2);
		if (byPlayer != null)
		{
			byPlayerName.text = byPlayer.name;
			TweenColor.Begin(byPlayerName.gameObject, 0f, Colours.blue);
			LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(byPlayer.level);
			byPlayerLevelIcon.spriteName = levelDefinition.iconName;
			byPlayerLevelIcon.MakePixelPerfect();
			byPlayerLevelName.text = levelDefinition.displayString;
			byPlayerTable.transform.localPosition = byPlayerTable.transform.localPosition.ReplaceX(num2);
			UITable uITable = simpleTable;
			uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(OnRepositionSimpleTable));
			UITable uITable2 = simpleTable;
			uITable2.onReposition = (UITable.OnReposition)Delegate.Combine(uITable2.onReposition, new UITable.OnReposition(OnRepositionSimpleTable));
		}
		simpleTable.repositionNow = true;
		SetUpSize(isFullContentShowed: false);
	}

	private void InitNormalMessage(string squad, string squadEmblem, bool isInBeginnerLeague, int beginnersLeague, League league, string message, bool isMine)
	{
		fullHeaderHolder.SetActive(value: true);
		contentHolder.SetActive(value: true);
		simpleHeaderHolder.SetActive(value: false);
		squadName.transform.localPosition = new Vector3(95f, squadName.transform.localPosition.y, squadName.transform.localPosition.z);
		TweenColor.Begin(squadName.gameObject, 0f, Color.white);
		squadName.text = squad;
		MiscTools.SetUILabelRescale(squadName, 30f, 12f, 180);
		bool flag = !string.IsNullOrEmpty(squadEmblem);
		squadIconTexture.alpha = ((!flag) ? 0f : 1f);
		if (flag)
		{
			squadIconTexture.mainTexture = Resources.Load<Texture>("SquadIcons/" + squadEmblem);
			squadIconTexture.MakePixelPerfect();
			squadIconTexture.transform.localScale = squadIconTexture.transform.localScale.MultiplyXY(0.25f);
		}
		bool active = isInBeginnerLeague || league != League.NoLeague;
		leagueIcon.gameObject.SetActive(active);
		if (isInBeginnerLeague)
		{
			leagueIcon.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(beginnersLeague);
			leagueIcon.MakePixelPerfect();
		}
		else if (league != League.NoLeague)
		{
			leagueIcon.spriteName = GameVariables.leagueNames[league].Value2;
			leagueIcon.MakePixelPerfect();
		}
		messageLabel.text = message;
		background.color = ((!isMine) ? Colours.chatBackgroundGray : Colours.chatBackgroundBlue);
		backgroundSmallTriangle.color = ((!isMine) ? Colours.chatBackgroundGray : Colours.chatBackgroundBlue);
		SetUpSize(isFullContentShowed: true);
	}

	private void InitSquadMessage(SquadRank squadRank, bool isInBeginnerLeague, int beginnersLeague, League league, string message, bool isMine)
	{
		fullHeaderHolder.SetActive(value: true);
		contentHolder.SetActive(value: true);
		simpleHeaderHolder.SetActive(value: false);
		squadIconTexture.alpha = 0f;
		squadName.transform.localPosition = new Vector3(30f, squadName.transform.localPosition.y, squadName.transform.localPosition.z);
		squadName.text = Localization.Localize(GameVariables.squadFunctions[squadRank]);
		MiscTools.SetUILabelRescale(squadName, 30f, 12f, 180);
		switch (squadRank)
		{
		case SquadRank.Leader:
			TweenColor.Begin(squadName.gameObject, 0f, Colours.goldUpgrade);
			break;
		case SquadRank.Coleader:
			TweenColor.Begin(squadName.gameObject, 0f, Colours.magenta);
			break;
		case SquadRank.Veteran:
			TweenColor.Begin(squadName.gameObject, 0f, Colours.cyan);
			break;
		case SquadRank.Member:
			TweenColor.Begin(squadName.gameObject, 0f, Color.white);
			break;
		}
		bool active = isInBeginnerLeague || league != League.NoLeague;
		leagueIcon.gameObject.SetActive(active);
		if (isInBeginnerLeague)
		{
			leagueIcon.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(beginnersLeague);
			leagueIcon.MakePixelPerfect();
		}
		else if (league != League.NoLeague)
		{
			leagueIcon.spriteName = GameVariables.leagueNames[league].Value2;
			leagueIcon.MakePixelPerfect();
		}
		messageLabel.text = message;
		background.color = ((!isMine) ? Colours.chatBackgroundGray : Colours.chatBackgroundBlue);
		backgroundSmallTriangle.color = ((!isMine) ? Colours.chatBackgroundGray : Colours.chatBackgroundBlue);
		SetUpSize(isFullContentShowed: true);
	}

	private void OnRepositionSimpleTable()
	{
		UITable uITable = simpleTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(OnRepositionSimpleTable));
		if (byPlayerTable.gameObject.activeSelf)
		{
			UITable uITable2 = byPlayerTable;
			uITable2.onReposition = (UITable.OnReposition)Delegate.Remove(uITable2.onReposition, new UITable.OnReposition(OnRepositionByPlayerTable));
			UITable uITable3 = byPlayerTable;
			uITable3.onReposition = (UITable.OnReposition)Delegate.Combine(uITable3.onReposition, new UITable.OnReposition(OnRepositionByPlayerTable));
			byPlayerTable.repositionNow = true;
		}
	}

	private void OnRepositionByPlayerTable()
	{
		UITable uITable = byPlayerTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(OnRepositionByPlayerTable));
		float num = 345f + byPlayerTable.transform.localPosition.x + byPlayerName.transform.parent.transform.localPosition.x;
		int width = 690 - (int)num;
		MiscTools.SetUILabelRescale(byPlayerName, 33f, 22f, width);
		float x = byPlayerName.relativeSize.x;
		byPlayerButton.center = new Vector3(x / 2f, 0.1f, -1f);
		byPlayerButton.size = new Vector3(x + 0.2f, 1.5f, 1f);
	}

	private void ResizeNameSquadActionDescription()
	{
		int num = ((!crownSprite.gameObject.activeSelf) ? 290 : 250);
		int num2 = 320;
		int num3 = num + num2;
		float x = nameLabel.relativeSize.x;
		float x2 = simpleDesc.relativeSize.x;
		float defaultHeight = Mathf.Clamp((float)num3 / (x + x2), 20f, 33f);
		MiscTools.SetUILabelRescale(nameLabel, defaultHeight, 20f, num3);
		MiscTools.SetUILabelRescale(simpleDesc, defaultHeight, 20f, num3);
	}

	private void SetUpSize(bool isFullContentShowed, bool setAlsoLook = true)
	{
		if (isFullContentShowed)
		{
			float num = messageLabel.relativeSize.y * messageLabel.transform.localScale.y;
			float val = 32f + num;
			float val2 = 116f + num;
			float val3 = -93f - num;
			mHeight = val2;
			if (setAlsoLook)
			{
				background.transform.localScale = background.transform.localScale.ReplaceY(val);
				border.transform.localScale = border.transform.localScale.ReplaceY(val2);
				abuseButton.transform.localPosition = abuseButton.transform.localPosition.ReplaceY(val3);
			}
		}
		else
		{
			mHeight = ((!byPlayerTable.gameObject.activeSelf) ? 80f : 145f);
			if (setAlsoLook)
			{
				border.transform.localScale = border.transform.localScale.ReplaceY(mHeight);
			}
		}
	}

	public override void DestroyPooled()
	{
		UIEventListener uIEventListener = UIEventListener.Get(playerButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(PlayerNameClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(squadButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(SquadNameClick));
		UIEventListener uIEventListener3 = UIEventListener.Get(abuseButton.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(ChatAbuseButtonClick));
		UIEventListener uIEventListener4 = UIEventListener.Get(byPlayerButton.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener4.onClick, new UIEventListener.VoidDelegate(ByPlayerNameClick));
		timeCounter.StopChatTimer();
		mData = default(Chat.ChatRecordData);
		squadIconTexture.mainTexture = null;
		base.DestroyPooled();
	}
}
