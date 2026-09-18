using System;
using UnityEngine;

public class LobbyPlayerPart : Core_BaseScript
{
	[Header("Icon")]
	public GameObject iconGO;

	public UISprite textureBackground;

	public UISprite textureInside;

	public UITexture playerIcon;

	public PlayerIcon playerTexture;

	public BoxCollider playerIconButton;

	public UIButtonScale playerIconButtonScale;

	public GameObject questionMarkParent;

	public UILabel questionMark;

	[Header("Texts")]
	public UILabel playerName;

	public BoxCollider playerNameButton;

	public UILabel playerStateText;

	private float mNameTextSize;

	private float mStateTextSize;

	private float mStateYDiff;

	private float mQuestionMarkSize;

	private int mNameMaxWidth;

	private string mPlayerName;

	private string mPlayerId;

	private bool mIsBot;

	private bool mIsLeft;

	private Vector3 mIconGOLocalPosition;

	private Vector3 mNameLocalPosition;

	private Vector3 mStateLocalPosition;

	private float mZLabelPosition = -2f;

	public void SetButtonClicks()
	{
		UIEventListener uIEventListener = UIEventListener.Get(playerNameButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NameClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(playerNameButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NameClick));
		UIEventListener uIEventListener3 = UIEventListener.Get(playerIconButton.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(IconClick));
		UIEventListener uIEventListener4 = UIEventListener.Get(playerIconButton.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(IconClick));
		playerIconButtonScale.enabled = true;
	}

	private void NameClick(GameObject go)
	{
		TweenColor tweenColor = TweenColor.Begin(playerName.gameObject, GameVariables.durationOfNameButtonColor, Color.white, Colours.blue);
		tweenColor.NumOfRepetitions = 2;
		tweenColor.style = UITweener.Style.PingPong;
		SoundsManager.Instance.PlayButtonClickedSound();
		if (mIsBot)
		{
			GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(mPlayerName, Singleton<GameController>.instance.opponent.playerProperties.databaseInfoBot);
		}
		else
		{
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(mPlayerName, mPlayerId);
		}
	}

	private void IconClick(GameObject go)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (mIsBot)
		{
			GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(mPlayerName, Singleton<GameController>.instance.opponent.playerProperties.databaseInfoBot);
		}
		else
		{
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(mPlayerName, mPlayerId);
		}
	}

	public void InitSizeAndOrientation(bool isBig, bool isLeft, bool isTop = true)
	{
		StopAllAnimations();
		mIsLeft = isLeft;
		float num = ((!isBig) ? 70f : 140f);
		float num2 = ((!isBig) ? 62f : 124f);
		float num3 = num / 2f;
		mIconGOLocalPosition = new Vector3((!isLeft) ? (0f - num3) : num3, (!isTop) ? (0f - (num3 + 70f)) : (0f - num3), -2f);
		iconGO.transform.localPosition = mIconGOLocalPosition;
		textureBackground.transform.localScale = new Vector3(num, num, 1f);
		textureInside.transform.localScale = new Vector3(num2, num2, 1f);
		playerIcon.transform.localScale = new Vector3(num2, num2, 1f);
		playerIconButton.size = ((!isBig) ? new Vector3(100f, 100f, 1f) : new Vector3(150f, 150f, 1f));
		playerIconButton.center = ((!isBig) ? new Vector3(0f, (!isTop) ? (-15f) : 15f, -1f) : new Vector3(0f, 0f, -1f));
		mNameTextSize = ((!isBig) ? 41f : 47f);
		mStateTextSize = ((!isBig) ? 22f : 30f);
		mStateYDiff = ((!isBig) ? 2f : 3f);
		mQuestionMarkSize = ((!isBig) ? 30f : 57f);
		float num4 = ((!isBig) ? 96f : 184f);
		float num5 = ((!isBig) ? (GuiScreenSingle<CardSelectionScreen>.instance.lobbyHeader.positionOfArrow - 5f) : 184f);
		float num6 = ((!isBig) ? (-40f) : (-51f));
		float num7 = ((!isBig) ? (-36f) : (-100f));
		playerName.pivot = ((!isLeft) ? UIWidget.Pivot.Right : UIWidget.Pivot.Left);
		playerStateText.pivot = (isLeft ? ((!isBig) ? UIWidget.Pivot.Right : UIWidget.Pivot.Left) : ((!isBig) ? UIWidget.Pivot.Left : UIWidget.Pivot.Right));
		mNameLocalPosition = new Vector3((!isLeft) ? (0f - num4) : num4, (!isTop) ? (num6 - 70f) : num6, mZLabelPosition);
		playerName.transform.localPosition = mNameLocalPosition;
		mStateLocalPosition = new Vector3((!isLeft) ? (0f - num5) : num5, (!isTop) ? (num7 - 70f - mStateYDiff) : (num7 - mStateYDiff), mZLabelPosition);
		playerStateText.transform.localPosition = mStateLocalPosition;
		playerName.transform.localScale = new Vector3(mNameTextSize, mNameTextSize, 1f);
		playerStateText.transform.localScale = new Vector3(mStateTextSize, mStateTextSize, 1f);
		questionMark.transform.localScale = new Vector3(mQuestionMarkSize, mQuestionMarkSize, 1f);
		int num8 = MiscTools.RoundToInt(GuiScreenSingle<CardSelectionScreen>.instance.lobbyHeader.positionOfArrow - Mathf.Abs(mNameLocalPosition.x) - 10f);
		mNameMaxWidth = ((!isBig) ? (num8 / 2) : num8);
		playerNameButton.transform.localPosition = new Vector3((!isLeft) ? (0f - num4) : num4, -70f, 0f);
		playerNameButton.size = ((!isBig) ? new Vector3(mNameMaxWidth, 70f, 1f) : new Vector3(mNameMaxWidth, 100f, 1f));
		playerNameButton.center = ((!isBig) ? new Vector3((!isLeft) ? (0f - (float)mNameMaxWidth / 2f) : ((float)mNameMaxWidth / 2f), (!isTop) ? (-35f) : 35f, -1f) : new Vector3((!isLeft) ? (0f - (float)mNameMaxWidth / 2f) : ((float)mNameMaxWidth / 2f), 0f, -2f));
		SetClickable(isClickable: false);
	}

	private void StopAllAnimations()
	{
		UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(includeInactive: true);
		foreach (UITweener uITweener in componentsInChildren)
		{
			uITweener.enabled = false;
		}
	}

	public void SetState(string stateText)
	{
		playerStateText.text = stateText;
		MiscTools.SetUILabelRescale(playerStateText, mStateTextSize, 17f, mNameMaxWidth);
	}

	private void SetName(string nameOfPlayer)
	{
		playerName.text = nameOfPlayer;
		MiscTools.SetUILabelRescale(playerName, mNameTextSize, 21f, mNameMaxWidth);
	}

	private void SetClickable(bool isClickable)
	{
		playerIconButton.enabled = isClickable;
		playerNameButton.enabled = isClickable;
	}

	private void SetTexture(Texture texture, long facebookId = -1)
	{
		playerTexture.gameObject.SetActive(value: true);
		playerTexture.avatar = texture;
		StopQuestionMarkAnimation();
	}

	private void HideTexture()
	{
		playerTexture.gameObject.SetActive(value: false);
		StartQuestionMarkAnimation();
	}

	private void PopIconAnimation()
	{
		bool flag = mPlayerId == GameLoginManager.currentPlayer.id;
		float duration = 0.3f;
		float popAmount = 1.2f;
		float upTime = ((!flag) ? 0.12f : 0.4f);
		float downTime = ((!flag) ? 0.06f : 0.2f);
		TweenScale component = iconGO.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = false;
		}
		iconGO.transform.localScale = new Vector3(0.001f, 0.001f, 1f);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(iconGO, duration, 0f, 0f);
		tweenAlpha.onFinished = delegate
		{
			TweenAlpha.Begin(iconGO, 0.15f, 0f, 1f).onFinished = null;
			TweenScale tweenScale = TweenScale.Begin(iconGO, upTime, new Vector3(0.001f, 0.001f, 1f), new Vector3(popAmount, popAmount, 1f));
			tweenScale.method = UITweener.Method.EaseOut;
			tweenScale.onFinished = delegate
			{
				TweenScale tweenScale2 = TweenScale.Begin(iconGO, downTime, new Vector3(popAmount, popAmount, 1f), new Vector3(1f, 1f, 1f));
				tweenScale2.method = UITweener.Method.EaseIn;
			};
		};
	}

	private void TextsDeathMatchAnimation()
	{
		bool flag = mPlayerId == GameLoginManager.currentPlayer.id;
		float delay = ((!flag) ? 0.01f : 0.5f);
		float delay2 = ((!flag) ? 0.3f : 0.8f);
		TextAnimation(playerName.gameObject, 0f, 16f, 0f, delay);
		TextAnimation(playerStateText.gameObject, -25f - mStateYDiff, 10f - mStateYDiff, 0f - mStateYDiff, delay2);
	}

	private void TextAnimation(GameObject go, float from, float upTo, float to, float delay)
	{
		float fadeInTime = 0.1f;
		float upTime = 0.2f;
		float downTime = 0.1f;
		Vector3 startPos = go.transform.localPosition;
		startPos.y += from;
		Vector3 middlePos = go.transform.localPosition;
		middlePos.y += upTo;
		Vector3 endPos = go.transform.localPosition;
		endPos.y += to;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(go, delay, 0f, 0f);
		tweenAlpha.onFinished = delegate
		{
			TweenAlpha.Begin(go, fadeInTime, 0f, 1f).onFinished = null;
			TweenPosition tweenPosition = TweenPosition.Begin(go, upTime, startPos, middlePos);
			tweenPosition.method = UITweener.Method.EaseOut;
			tweenPosition.onFinished = delegate
			{
				TweenPosition tweenPosition2 = TweenPosition.Begin(go, downTime, middlePos, endPos);
				tweenPosition2.method = UITweener.Method.EaseIn;
				tweenPosition2.onFinished = null;
			};
		};
	}

	private void StartQuestionMarkAnimation()
	{
		questionMark.alpha = 1f;
		TweenColor tweenColor = TweenColor.Begin(questionMark.gameObject, 0.3f, Colours.grayStatus, Colours.grayStatus);
		tweenColor.onFinished = delegate
		{
			QuestionMarkAnimation();
		};
		questionMark.color = Colours.grayStatus;
	}

	private void QuestionMarkAnimation()
	{
		TweenScale.Begin(questionMarkParent, 0.5f, Vector3.one, new Vector3(1.2f, 1.2f, 1f));
		questionMarkParent.transform.localScale = Vector3.one;
		TweenColor tweenColor = TweenColor.Begin(questionMark.gameObject, 0.5f, Colours.grayStatus, Color.white);
		tweenColor.method = UITweener.Method.EaseInOut;
		tweenColor.onFinished = delegate
		{
			TweenScale.Begin(questionMarkParent, 0.5f, new Vector3(1.2f, 1.2f, 1f), Vector3.one);
			questionMarkParent.transform.localScale = new Vector3(1.2f, 1.2f, 1f);
			TweenColor tweenColor2 = TweenColor.Begin(questionMark.gameObject, 0.5f, Color.white, Colours.grayStatus);
			tweenColor2.method = UITweener.Method.EaseInOut;
			tweenColor2.onFinished = delegate
			{
				StartQuestionMarkAnimation();
			};
			questionMark.color = Color.white;
		};
		questionMark.color = Colours.grayStatus;
	}

	private void StopQuestionMarkAnimation()
	{
		TweenColor component = questionMark.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = false;
		}
		questionMark.alpha = 0f;
	}

	private void InitialShowStatus(Color showColor)
	{
		TweenColor tweenColor = TweenColor.Begin(playerStateText.gameObject, 0.8f, Colours.whiteTransparent, Colours.whiteTransparent);
		tweenColor.onFinished = delegate
		{
			TweenColor.Begin(playerStateText.gameObject, 0.5f, showColor).onFinished = null;
		};
		playerStateText.alpha = 0f;
	}

	private void StartPulseStatus()
	{
		Color color = playerStateText.color;
		TweenColor tweenColor = TweenColor.Begin(playerStateText.gameObject, 0.8f, color, color);
		tweenColor.onFinished = delegate
		{
			PulseStatus();
		};
	}

	private void PulseStatus()
	{
		TweenColor tweenColor = TweenColor.Begin(playerStateText.gameObject, 0.5f, Color.white);
		tweenColor.method = UITweener.Method.EaseInOut;
		tweenColor.onFinished = delegate
		{
			TweenColor tweenColor2 = TweenColor.Begin(playerStateText.gameObject, 0.5f, Colours.grayStatus);
			tweenColor2.method = UITweener.Method.EaseInOut;
			tweenColor2.onFinished = delegate
			{
				PulseStatus();
			};
		};
	}

	private void StopPulseStatus()
	{
		TweenColor.Begin(playerStateText.gameObject, 0f, (!mIsLeft) ? Colours.redEnemy : Colours.blue);
	}

	private void InitialShowName(Color showColor)
	{
		TweenColor tweenColor = TweenColor.Begin(playerName.gameObject, 0.5f, Colours.whiteTransparent, Colours.whiteTransparent);
		tweenColor.onFinished = delegate
		{
			TweenColor.Begin(playerName.gameObject, 0.2f, showColor).onFinished = null;
		};
		playerName.alpha = 0f;
	}

	private void StartFakeNamesAnimation()
	{
		TweenColor tweenColor = TweenColor.Begin(playerName.gameObject, 0.5f, Colours.whiteTransparent, Colours.whiteTransparent);
		tweenColor.onFinished = delegate
		{
			FakeNamesAnimation();
		};
		playerName.alpha = 0f;
	}

	private void FakeNamesAnimation()
	{
		int index = UnityEngine.Random.Range(0, GuiScreenSingle<CardSelectionScreen>.instance.lobbyHeader.fakeNames.Count);
		while (GuiScreenSingle<CardSelectionScreen>.instance.lobbyHeader.fakeNames[index] == playerName.text)
		{
			index = UnityEngine.Random.Range(0, GuiScreenSingle<CardSelectionScreen>.instance.lobbyHeader.fakeNames.Count);
		}
		SetName(GuiScreenSingle<CardSelectionScreen>.instance.lobbyHeader.fakeNames[index]);
		Vector3 fromnPos = mNameLocalPosition;
		fromnPos.y -= 16f;
		Vector3 middleNamePosition = mNameLocalPosition;
		Vector3 upNamePosition = mNameLocalPosition;
		upNamePosition.y += 16f;
		float dur = 0.1f;
		TweenPosition tweenPosition = TweenPosition.Begin(playerName.gameObject, dur, fromnPos, middleNamePosition);
		tweenPosition.method = UITweener.Method.EaseOut;
		TweenColor tweenColor = TweenColor.Begin(playerName.gameObject, dur, Colours.grayStatus.ReplaceA(0f), Color.white);
		tweenColor.onFinished = delegate
		{
			if (!GuiElementSingle<LoadingDialog>.instance.isShowed)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.OpponentSearch);
			}
			TweenPosition tweenPosition2 = TweenPosition.Begin(playerName.gameObject, dur, middleNamePosition, upNamePosition);
			tweenPosition2.method = UITweener.Method.EaseIn;
			TweenColor tweenColor2 = TweenColor.Begin(playerName.gameObject, dur, Color.white, Colours.grayStatus.ReplaceA(0f));
			tweenColor2.onFinished = delegate
			{
				FakeNamesAnimation();
			};
		};
	}

	private void StopFakeNamesAnimation()
	{
		TweenColor component = playerName.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = false;
		}
		playerName.color = Color.white;
		TweenPosition component2 = playerName.GetComponent<TweenPosition>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		playerName.transform.localPosition = mNameLocalPosition;
	}

	public void AnimateCurrentPlayer(bool clickableName = true)
	{
		mPlayerName = PlayerController.currentPlayer.playerProperties.name;
		mPlayerId = PlayerController.currentPlayer.playerProperties.playerID;
		SetName(mPlayerName);
		SetTexture(PlayerController.currentPlayer.playerProperties.texture);
		InitialShowStatus(Colours.blue);
		InitialShowName(Color.white);
		PopIconAnimation();
		TextsDeathMatchAnimation();
		SetClickable(clickableName);
	}

	public void AnimateBoss()
	{
		SetName(MissionsManager.instance.currentMission.GetMissionObjective());
		SetTexture(Singleton<GameController>.instance.opponent.playerProperties.texture);
		SetState(Localization.Localize("ID_MISSION_BOSSFIGHT"));
		InitialShowName(Color.white);
		InitialShowStatus(Colours.grayStatus);
		PopIconAnimation();
		TextsDeathMatchAnimation();
	}

	public void AnimateConnectingToPhoton()
	{
		PopIconAnimation();
		SetName(string.Empty);
		HideTexture();
		SetClickable(isClickable: false);
		InitialShowName(Color.white);
		InitialShowStatus((!mIsLeft) ? Colours.grayStatus : Colours.blue);
	}

	public void AnimatePlayerSearching()
	{
		StartPulseStatus();
		StartFakeNamesAnimation();
		SetClickable(isClickable: false);
	}

	public void AnimateWaitingForFriend(string name, Texture avatar)
	{
		mPlayerName = name;
		mIsBot = false;
		SetName(mPlayerName);
		SetTexture(avatar);
		StartPulseStatus();
		SetClickable(isClickable: true);
	}

	public void AnimateWaitingForFriend()
	{
		mIsBot = false;
		SetName(string.Empty);
		HideTexture();
		StartPulseStatus();
		SetClickable(isClickable: false);
	}

	public void AnimatePlayerFound(PlayerProperties playerProperties)
	{
		mPlayerName = playerProperties.name;
		mPlayerId = playerProperties.playerID;
		mIsBot = playerProperties.isBot;
		SetName(mPlayerName);
		SetTexture(playerProperties.texture);
		StopPulseStatus();
		StopQuestionMarkAnimation();
		StopFakeNamesAnimation();
		PopIconAnimation();
		TextsDeathMatchAnimation();
		SetClickable(isClickable: true);
		if (!GuiElementSingle<LoadingDialog>.instance.isShowed)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.OpponentFound);
		}
	}
}
