using System;
using System.Collections.Generic;
using UnityEngine;

public class AssignmentsScreen : GuiScreenSingle<AssignmentsScreen>
{
	public enum Tab
	{
		Daily,
		Starter
	}

	[Header("Header Buttons")]
	public UITable buttonsTable;

	public List<SquadButton> headerButtons;

	public UISprite leftHighlight;

	public UISprite rightHighlight;

	public SquadButtonDaily dailyButton;

	public SquadButtonStarter starterButton;

	[Header("Contents")]
	public DailyPart dailyPart;

	public StarterAssignmentPart starterPart;

	[Header("Debug")]
	public GameObject debugContentDaily;

	public GameObject getNewAssignments;

	public GameObject completeCurrentAssignments;

	public GameObject debugContentStarter;

	public GameObject completeCurrentStarter;

	[HideInInspector]
	public float dur = 0.2f;

	private Tab mActiveTab;

	public void ShowStarter()
	{
		mActiveTab = Tab.Starter;
		if (isShowed)
		{
			InitGUIValues();
		}
		else
		{
			Singleton<GuiManager>.instance.ShowGui(this);
		}
	}

	public void ShowDaily()
	{
		mActiveTab = Tab.Daily;
		if (isShowed)
		{
			InitGUIValues();
		}
		else
		{
			Singleton<GuiManager>.instance.ShowGui(this);
		}
	}

	public override void InitEvents()
	{
		dailyPart.InitEvents();
	}

	protected override void InitControls()
	{
		rightHighlight.transform.localPosition = new Vector3(UIRoot.list[0].activeWidth - 48f, rightHighlight.transform.localPosition.y, 0f);
		headerButtons[0].Initialize(Localization.Localize("ID_DAILY"), dur);
		headerButtons[1].Initialize(Localization.Localize("ID_STARTERASSIGNMENT"), dur);
		buttonsTable.repositionNow = true;
		buttonsTable.onReposition = delegate
		{
			SetAndAnimateHighlights(instant: true);
		};
		foreach (SquadButton headerButton in headerButtons)
		{
			UIEventListener uIEventListener = UIEventListener.Get(headerButton.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HeaderButtonClick));
		}
		dailyPart.InitControls();
		starterPart.InitControls();
		AssignmentsManager.instance.AssignmentClaimed += AssignmentClaimedEvent;
		StarterAssignmentsManager.instance.AssignmentClaimed += NotificationsUpdate;
	}

	private void HeaderButtonClick(GameObject go)
	{
		SquadButton button = go.GetComponentsInChildren<SquadButton>(includeInactive: true)[0];
		int num = headerButtons.FindIndex((SquadButton a) => a.buttonName == button.buttonName);
		if (!headerButtons[num].pressed)
		{
			SelectTab((Tab)num);
		}
	}

	public override void InitGUIValues()
	{
		bool isActiveAndNotCompleted = StarterAssignmentsManager.instance.isActiveAndNotCompleted;
		bool activeSelf = headerButtons[0].gameObject.activeSelf;
		bool activeSelf2 = headerButtons[1].gameObject.activeSelf;
		headerButtons[0].gameObject.SetActive(!isActiveAndNotCompleted);
		headerButtons[1].gameObject.SetActive(isActiveAndNotCompleted);
		if (activeSelf != headerButtons[0].gameObject.activeSelf || activeSelf2 != headerButtons[1].gameObject.activeSelf)
		{
			buttonsTable.repositionNow = true;
		}
		if (isActiveAndNotCompleted)
		{
			starterButton.StartUpdate();
			if (mActiveTab == Tab.Daily)
			{
				mActiveTab = Tab.Starter;
			}
		}
		else if (mActiveTab == Tab.Starter)
		{
			mActiveTab = Tab.Daily;
		}
		SetDebugButtons();
		NotificationsUpdate();
		SelectTab(mActiveTab, instant: true);
	}

	private void SetDebugButtons()
	{
		debugContentDaily.SetActive(value: false);
		debugContentStarter.SetActive(value: false);
	}

	private void AssignmentClaimedEvent(int index)
	{
		NotificationsUpdate();
	}

	private void NotificationsUpdate()
	{
		dailyButton.ShowNotification(Singleton<NotificationManager>.instance.GetNumberOfAssignmentNotifications() > 0);
		starterButton.ShowNotification(Singleton<NotificationManager>.instance.NotificationStarterAssignments(), !StarterAssignmentsManager.instance.isWBReward);
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		dailyPart.DoAfterHide();
		starterPart.DoAfterHide();
		starterButton.StopUpdate();
	}

	private void SelectTab(Tab selectedTab, bool instant = false)
	{
		mActiveTab = selectedTab;
		SetAndAnimateButtons(instant);
		SetAndAnimateHighlights(instant);
		SetAndAnimateContent(instant);
	}

	private void SetAndAnimateButtons(bool instant)
	{
		if (instant)
		{
			for (int i = 0; i < headerButtons.Count; i++)
			{
				headerButtons[i].InstantAnimate(i == (int)mActiveTab);
			}
		}
		else
		{
			headerButtons[0].Animate(toHighlight: false);
			headerButtons[1].Animate(toHighlight: false).onFinished = delegate
			{
				headerButtons[(int)mActiveTab].Animate(toHighlight: true);
			};
		}
	}

	private void SetAndAnimateHighlights(bool instant)
	{
		float activeWidth = UIRoot.list[0].activeWidth;
		float posX = headerButtons[(int)mActiveTab].posX;
		float width = headerButtons[(int)mActiveTab].width;
		float num = posX - width / 2f;
		float num2 = posX + width / 2f;
		float leftScale = Mathf.Max(28f, 28f + num - 60f);
		float rightScale = Mathf.Max(28f, 28f + (activeWidth - num2) - 60f);
		bool showLeft = true;
		bool showRight = true;
		AnimateHighlights(showLeft, leftScale, showRight, rightScale, instant);
	}

	private void SetHighlights(float leftScale, float rightScale)
	{
		leftHighlight.transform.localScale = new Vector3(leftScale, leftHighlight.transform.localScale.y, 0f);
		rightHighlight.transform.localScale = new Vector3(rightScale, rightHighlight.transform.localScale.y, 0f);
	}

	private void AnimateHighlights(bool showLeft, float leftScale, bool showRight, float rightScale, bool instant)
	{
		if (instant)
		{
			SetHighlights(leftScale, rightScale);
			leftHighlight.alpha = ((!showLeft) ? 0f : 1f);
			rightHighlight.alpha = ((!showRight) ? 0f : 1f);
			TweenAlpha component = leftHighlight.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			TweenAlpha component2 = rightHighlight.gameObject.GetComponent<TweenAlpha>();
			if (component2 != null)
			{
				component2.onFinished = null;
				component2.enabled = false;
			}
		}
		else
		{
			TweenAlpha.Begin(leftHighlight.gameObject, dur, 0f);
			TweenAlpha.Begin(rightHighlight.gameObject, dur, 0f).onFinished = delegate
			{
				SetHighlights(leftScale, rightScale);
				TweenAlpha.Begin(leftHighlight.gameObject, dur, (!showLeft) ? 0f : 1f);
				TweenAlpha.Begin(rightHighlight.gameObject, dur, (!showRight) ? 0f : 1f).onFinished = null;
			};
		}
	}

	private void SetAndAnimateContent(bool instant)
	{
		bool flag = mActiveTab == Tab.Daily;
		bool flag2 = mActiveTab == Tab.Starter;
		if (instant)
		{
			dailyPart.Animate(flag, instant: true);
			starterPart.Animate(flag2, instant: true);
			return;
		}
		if (dailyPart.gameObject.activeSelf && !flag)
		{
			dailyPart.Animate(flag, instant: false);
		}
		if (starterPart.gameObject.activeSelf && !flag2)
		{
			starterPart.Animate(flag2, instant: false);
		}
		if (!dailyPart.gameObject.activeSelf && flag)
		{
			dailyPart.Animate(flag, instant: false);
		}
		if (!starterPart.gameObject.activeSelf && flag2)
		{
			starterPart.Animate(flag2, instant: false);
		}
		if (dailyPart.gameObject.activeSelf && flag)
		{
			dailyPart.Animate(flag, instant: false);
		}
		if (starterPart.gameObject.activeSelf && flag2)
		{
			starterPart.Animate(flag2, instant: false);
		}
	}
}
