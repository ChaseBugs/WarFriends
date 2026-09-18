using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsScreen : GuiScreenSingle<PlayerStatsScreen>
{
	public enum Tab
	{
		Overall,
		Ribbons
	}

	[Header("Header Buttons")]
	public UITable buttonsTable;

	public List<SquadButton> tabButtons;

	public UISprite leftHighlight;

	public UISprite rightHighlight;

	[Header("Contents")]
	public OverallStats overallStats;

	public RibbonsStats ribbonsStats;

	[HideInInspector]
	public float dur = 0.2f;

	private Tab mActiveTab;

	public float headerHeight => 450f;

	public override void InitEvents()
	{
		overallStats.InitEvents();
		overallStats.gameObject.SetActive(value: false);
		ribbonsStats.gameObject.SetActive(value: false);
	}

	protected override void InitControls()
	{
		rightHighlight.transform.localPosition = new Vector3(UIRoot.list[0].activeWidth - 48f, rightHighlight.transform.localPosition.y, 0f);
		tabButtons[0].Initialize(Localization.Localize("ID_OVERALL"), dur);
		tabButtons[1].Initialize(Localization.Localize("ID_RIBBONS"), dur);
		buttonsTable.repositionNow = true;
		buttonsTable.onReposition = delegate
		{
			SetAndAnimateHighlights(instant: true);
		};
		foreach (SquadButton tabButton in tabButtons)
		{
			UIEventListener uIEventListener = UIEventListener.Get(tabButton.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HeaderButtonClick));
		}
		overallStats.InitControls();
		ribbonsStats.InitControls();
	}

	private void HeaderButtonClick(GameObject go)
	{
		SquadButton button = go.GetComponentsInChildren<SquadButton>(includeInactive: true)[0];
		int num = tabButtons.FindIndex((SquadButton a) => a == button);
		if (!tabButtons[num].pressed)
		{
			SelectTab((Tab)num);
		}
	}

	public override void InitGUIValues()
	{
		SelectTab(mActiveTab, instant: true);
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		if (mActiveTab == Tab.Overall)
		{
			overallStats.Animate(showTab: false, instant: false);
		}
		if (mActiveTab == Tab.Ribbons)
		{
			ribbonsStats.Animate(showTab: false, instant: false);
		}
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		overallStats.InstantHideTab();
		ribbonsStats.InstantHideTab();
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
			for (int i = 0; i < tabButtons.Count; i++)
			{
				tabButtons[i].InstantAnimate(i == (int)mActiveTab);
			}
		}
		else
		{
			tabButtons[0].Animate(toHighlight: false);
			tabButtons[1].Animate(toHighlight: false).onFinished = delegate
			{
				tabButtons[(int)mActiveTab].Animate(toHighlight: true);
			};
		}
	}

	private void SetAndAnimateHighlights(bool instant)
	{
		float activeWidth = UIRoot.list[0].activeWidth;
		float posX = tabButtons[(int)mActiveTab].posX;
		float width = tabButtons[(int)mActiveTab].width;
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
		bool flag = mActiveTab == Tab.Overall;
		bool flag2 = mActiveTab == Tab.Ribbons;
		if (instant)
		{
			overallStats.Animate(flag, instant: true);
			ribbonsStats.Animate(flag2, instant: true);
			return;
		}
		if (overallStats.gameObject.activeSelf || flag)
		{
			overallStats.Animate(flag, instant: false);
		}
		if (ribbonsStats.gameObject.activeSelf || flag2)
		{
			ribbonsStats.Animate(flag2, instant: false);
		}
	}
}
