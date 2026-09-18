using System;
using System.Collections;
using UnityEngine;

public class InGameMessageDialog : GuiElementSingle<InGameMessageDialog>, IGuiDialog
{
	[Header("Core")]
	public GameObject backButton;

	public GameObject closeButton;

	[Header("GUI")]
	public UILabel title;

	public UILabel subtitle;

	public UISprite line;

	public UISprite background;

	public UISprite glow;

	[Header("Scrolling Part")]
	public UIPanel panel;

	public UIDraggablePanel draggablePanel;

	public UISprite topSpacer;

	public UILabel mainText;

	public UISprite bottomSpacer;

	public GameObject scrollBarParent;

	public UISprite[] scrollBarSprites;

	[Header("Reward Part")]
	public GameObject rewardPart;

	public GameObject claimButton;

	public GameObject claimedButton;

	public UILabel claimedLabel;

	public UISprite rewardBackground;

	public UILabel rewardTitle;

	public InGameMessageReward[] rewardObjects;

	[Header("Continue Part")]
	public GameObject continueButton;

	[Header("Animation")]
	public CardMenuOwerlay overlay;

	private DailyRewardMonthScreen.DailyRewardDataForDay[] mRewards;

	private InGameMessage mDatabaseMessage;

	private bool mClaimClicked;

	private bool mClaimedReward;

	private bool mAnimatingClaiming;

	public void ShowDialog(InGameMessage databaseMessage)
	{
		mDatabaseMessage = databaseMessage;
		title.text = databaseMessage.translatedTitle;
		subtitle.text = $"{Colours.stringBlue}{MiscTools.GetPrintableDate(databaseMessage.timeCreated)}{Colours.stringWhite} {databaseMessage.translatedSubtitle}";
		mainText.text = databaseMessage.translatedText;
		mainText.transform.localScale = new Vector3(databaseMessage.textSize, databaseMessage.textSize, 1f);
		for (int i = 0; i < rewardObjects.Length; i++)
		{
			rewardObjects[i].gameObject.SetActive(i < databaseMessage.rewards.Length);
			if (i < databaseMessage.rewards.Length)
			{
				rewardObjects[i].Initialize(databaseMessage.rewards[i]);
			}
		}
		mRewards = databaseMessage.rewards;
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(closeButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener2 = UIEventListener.Get(backButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener3 = UIEventListener.Get(continueButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener4 = UIEventListener.Get(claimButton);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(ClaimClick));
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataLoaded;
	}

	private void CloseDialog(GameObject go)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		HideDialog();
		if (!mClaimClicked)
		{
			if (rewardObjects[0].gameObject.activeSelf)
			{
				GuiElementSingle<ChatGuiElement>.instance.messageContent.AddMessageWithoutNotification(mDatabaseMessage);
			}
			else
			{
				mDatabaseMessage.Confirm();
			}
		}
	}

	private void OnDataLoaded(DatabaseAction action)
	{
		if (isShowed && action == DatabaseAction.ClaimReward)
		{
			Debug.Log("Claiming reward ...");
			ClaimedConfirmServer();
		}
	}

	private void ClaimClick(GameObject go)
	{
		mAnimatingClaiming = true;
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.DailyRewardClaim);
		TweenPosition.Begin(claimButton.gameObject, 0.25f, new Vector3(300f, claimButton.transform.localPosition.y, 0f)).onFinished = delegate
		{
			claimedLabel.text = Localization.Localize("ID_CLAIMING");
			TweenPosition.Begin(claimedButton.gameObject, 0.25f, new Vector3(-243f, claimedButton.transform.localPosition.y, 0f)).onFinished = delegate
			{
				mAnimatingClaiming = false;
				if (mClaimedReward)
				{
					AnimateClaimed();
				}
			};
		};
		mClaimClicked = true;
		mClaimedReward = false;
		mDatabaseMessage.Confirm();
	}

	private void ClaimedConfirmServer()
	{
		mClaimedReward = true;
		if (!mAnimatingClaiming)
		{
			AnimateClaimed();
		}
	}

	private void AnimateClaimed()
	{
		TweenPosition.Begin(claimedButton.gameObject, 0.25f, new Vector3(300f, claimedButton.transform.localPosition.y, 0f)).onFinished = delegate
		{
			claimedLabel.text = Localization.Localize("ID_CLAIMED");
			TweenPosition.Begin(claimedButton.gameObject, 0.25f, new Vector3(-243f, claimedButton.transform.localPosition.y, 0f)).onFinished = null;
			StartCoroutine(RadicalRoutine.Run(ClaimRewards()));
		};
	}

	public override void InitGUIValues()
	{
		mClaimClicked = false;
		mClaimedReward = false;
		mAnimatingClaiming = false;
		SetSizesLeft();
		SetSizesRight();
		StopAnimation();
		overlay.ResetDraw();
		GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
	}

	public override void AnimateShow(bool forceFadeIn)
	{
		base.AnimateShow(forceFadeIn);
		overlay.gameObject.SetActive(value: true);
		TweenAlpha component = overlay.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
			component.from = 1f;
			component.to = 1f;
			component.duration = 0.1f;
		}
		overlay.owerlayPanel.alpha1 = 1f;
		overlay.gameObject.SetActive(value: false);
	}

	private void SetSizesLeft()
	{
		float activeWidth = UIRoot.list[0].activeWidth;
		float num = UIRoot.list[0].activeHeight;
		float num2 = activeWidth - 540f;
		float num3 = activeWidth - 220f;
		float num4 = subtitle.relativeSize.y * subtitle.transform.localScale.y;
		float num5 = subtitle.transform.localPosition.y - num4 - 30f;
		float num6 = num5 - 8f;
		float y = num6 - 36f;
		float num7 = num + num5;
		float num8 = num7 - 20f;
		float num9 = num2;
		line.transform.localScale = new Vector3(num2, line.transform.localScale.y, 1f);
		background.transform.localScale = new Vector3(num2, num7, 1f);
		glow.transform.localScale = new Vector3(num3, num3 * 109f / 500f, 1f);
		line.transform.localPosition = new Vector3(line.transform.localPosition.x, num6, 1f);
		background.transform.localPosition = new Vector3(background.transform.localPosition.x, num5, 1f);
		glow.transform.localPosition = new Vector3(glow.transform.localPosition.x, y, 1f);
		float num10 = num6 - 12f;
		draggablePanel.transform.localPosition = new Vector3(0f, num10, draggablePanel.transform.localPosition.z);
		panel.clipRange = new Vector4(num9 / 2f, (0f - num8) / 2f, num9, num8);
		scrollBarParent.transform.localPosition = new Vector3(scrollBarParent.transform.localPosition.x, num10, scrollBarParent.transform.localPosition.z);
		for (int i = 0; i < scrollBarSprites.Length; i++)
		{
			scrollBarSprites[i].transform.localScale = new Vector3(scrollBarSprites[i].transform.localScale.x, num8, 1f);
		}
		float num11 = 20f;
		topSpacer.transform.localPosition = new Vector3(0f, 0f, 0f);
		float num12 = mainText.relativeSize.y * mainText.transform.localScale.y;
		mainText.transform.localPosition = new Vector3(60f, 0f - num11, 0f);
		bottomSpacer.transform.localPosition = new Vector3(0f, 0f - num12 - 2f * num11, 0f);
		draggablePanel.onePanelDisabled = Mathf.Abs(num10 + bottomSpacer.transform.localPosition.y) < num;
	}

	private void SetSizesRight()
	{
		bool activeSelf = rewardObjects[0].gameObject.activeSelf;
		continueButton.SetActive(!activeSelf);
		rewardPart.SetActive(activeSelf);
		if (!activeSelf)
		{
			return;
		}
		float num = 0f;
		for (int i = 0; i < rewardObjects.Length; i++)
		{
			if (rewardObjects[i].gameObject.activeSelf)
			{
				num = rewardObjects[i].transform.localPosition.y;
			}
		}
		float y = num + 150f - 50f;
		rewardBackground.transform.localScale = new Vector3(rewardBackground.transform.localScale.x, y, rewardBackground.transform.localScale.z);
		float y2 = num + 106f - 4f;
		rewardTitle.transform.localPosition = new Vector3(rewardTitle.transform.localPosition.x, y2, rewardTitle.transform.localPosition.z);
	}

	private void StopAnimation()
	{
		TweenPosition.Begin(claimButton.gameObject, 0.01f, new Vector3(-243f, claimButton.transform.localPosition.y, 0f)).onFinished = null;
		claimedLabel.text = Localization.Localize("ID_CLAIMING");
		TweenPosition.Begin(claimedButton.gameObject, 0.01f, new Vector3(300f, claimedButton.transform.localPosition.y, 0f)).onFinished = null;
	}

	public void ShowCards(string[] cardNames, int mult)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		Card[] array = new Card[cardNames.Length * mult];
		for (int i = 0; i < cardNames.Length; i++)
		{
			Card cardInstance = CardManager.instance.GetCardInstance(cardNames[i]);
			for (int j = 0; j < mult; j++)
			{
				array[i * mult + j] = cardInstance;
			}
		}
		overlay.StartShowAnimation(array, 0.5f);
	}

	public IEnumerator ClaimRewards()
	{
		if (overlay == null)
		{
			Debug.LogError("No overlay to display cards!");
			yield break;
		}
		for (int i = 0; i < mRewards.Length; i++)
		{
			DailyReward rew = mRewards[i].rewardType;
			if ((rew == DailyReward.BronzeCard || rew == DailyReward.SilverCard || rew == DailyReward.GoldCard || rew == DailyReward.ParticularCards) && !string.IsNullOrEmpty(mRewards[i].parameters))
			{
				string[] ids = mRewards[i].parameters.Split(';');
				Card[] cards = new Card[ids.Length];
				for (int index = 0; index < ids.Length; index++)
				{
					cards[index] = CardManager.instance.GetCardInstance(ids[index]);
				}
				overlay.StartShowAnimation(cards, 0.5f);
				yield return new WaitForRealSeconds(1f);
				while (overlay.gameObject.activeSelf)
				{
					yield return null;
				}
			}
		}
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		CloseDialog(backButton.gameObject);
	}
}
