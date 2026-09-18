using System;
using System.Collections.Generic;
using UnityEngine;

public class LeaguesScreen : GuiScreenSingle<LeaguesScreen>
{
	public enum Tab
	{
		PlayerLeague,
		SquadWars,
		AllTime
	}

	[Header("Buttons")]
	public UITable buttonsTable;

	public List<SquadButton> tabButtons;

	public UISprite leftHighlight;

	public UISprite rightHighlight;

	[Header("Contents")]
	public LeagueContent league;

	public SquadWarsContent squadWars;

	public AllTimeContent allTime;

	[HideInInspector]
	public float dur = 0.2f;

	private Tab mCurrentTab;

	public void ShowPlayerLeague()
	{
		mCurrentTab = Tab.PlayerLeague;
		if (isShowed)
		{
			InitGUIValues();
		}
		else
		{
			Singleton<GuiManager>.instance.ShowGui(this);
		}
	}

	public void ShowSquadWars()
	{
		mCurrentTab = Tab.SquadWars;
		if (isShowed)
		{
			InitGUIValues();
		}
		else
		{
			Singleton<GuiManager>.instance.ShowGui(this);
		}
	}

	public void ShowGlobalPlayerLeaderboard()
	{
		mCurrentTab = Tab.AllTime;
		allTime.SetPlayerLeaderboard();
		if (isShowed)
		{
			InitGUIValues();
		}
		else
		{
			Singleton<GuiManager>.instance.ShowGui(this);
		}
	}

	public void ShowGlobalSquadLeaderboard()
	{
		mCurrentTab = Tab.AllTime;
		allTime.SetSquadLeaderboard();
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
		base.InitEvents();
		league.gameObject.SetActive(value: false);
		squadWars.gameObject.SetActive(value: false);
		allTime.gameObject.SetActive(value: false);
		league.InitEvents();
		squadWars.InitEvents();
		allTime.InitEvents();
	}

	protected override void InitControls()
	{
		rightHighlight.transform.localPosition = new Vector3(UIRoot.list[0].activeWidth - 48f, rightHighlight.transform.localPosition.y, 0f);
		tabButtons[0].Initialize(Localization.Localize("ID_PLAYERLEAGUE"), dur);
		tabButtons[1].Initialize(Localization.Localize("ID_SQUADWAR"), dur);
		tabButtons[2].Initialize(Localization.Localize("ID_ALLTIME"), dur);
		buttonsTable.repositionNow = true;
		buttonsTable.onReposition = delegate
		{
			SetAndAnimateHighlights(instant: true);
		};
		league.InitControls();
		squadWars.InitControls();
		allTime.InitControls();
		foreach (SquadButton tabButton in tabButtons)
		{
			UIEventListener uIEventListener = UIEventListener.Get(tabButton.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HeaderButtonClick));
		}
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
		Singleton<EventTrackingManager>.instance.RegisterVisitLeagueTable();
		SelectTab(mCurrentTab, instant: true);
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		if (mCurrentTab == Tab.PlayerLeague)
		{
			league.Animate(showTab: false, instant: false);
		}
		if (mCurrentTab == Tab.SquadWars)
		{
			squadWars.Animate(showTab: false, instant: false);
		}
		if (mCurrentTab == Tab.AllTime)
		{
			allTime.Animate(showTab: false, instant: false);
		}
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		league.InstantHideTab();
		squadWars.InstantHideTab();
		allTime.InstantHideTab();
	}

	private void SelectTab(Tab selectedTab, bool instant = false)
	{
		mCurrentTab = selectedTab;
		SetAndAnimateButtons(instant);
		SetAndAnimateHighlights(instant);
		SetAndAnimateContent(instant);
		SavingLastSelected.instance.SaveLastLeaderboardTab((int)selectedTab);
	}

	private void SetAndAnimateButtons(bool instant)
	{
		if (instant)
		{
			for (int i = 0; i < tabButtons.Count; i++)
			{
				tabButtons[i].InstantAnimate(i == (int)mCurrentTab);
			}
			return;
		}
		tabButtons[0].Animate(toHighlight: false);
		tabButtons[1].Animate(toHighlight: false);
		tabButtons[2].Animate(toHighlight: false).onFinished = delegate
		{
			tabButtons[(int)mCurrentTab].Animate(toHighlight: true);
		};
	}

	private void SetAndAnimateHighlights(bool instant)
	{
		float activeWidth = UIRoot.list[0].activeWidth;
		float posX = tabButtons[(int)mCurrentTab].posX;
		float width = tabButtons[(int)mCurrentTab].width;
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
		bool flag = mCurrentTab == Tab.PlayerLeague;
		bool flag2 = mCurrentTab == Tab.SquadWars;
		bool flag3 = mCurrentTab == Tab.AllTime;
		if (instant)
		{
			league.Animate(flag, instant: true);
			squadWars.Animate(flag2, instant: true);
			allTime.Animate(flag3, instant: true);
			return;
		}
		if (league.gameObject.activeSelf || flag)
		{
			league.Animate(flag, instant: false);
		}
		if (squadWars.gameObject.activeSelf || flag2)
		{
			squadWars.Animate(flag2, instant: false);
		}
		if (allTime.gameObject.activeSelf || flag3)
		{
			allTime.Animate(flag3, instant: false);
		}
	}
}
