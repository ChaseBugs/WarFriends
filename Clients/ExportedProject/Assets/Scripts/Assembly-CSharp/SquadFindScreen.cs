using System;
using System.Collections.Generic;
using UnityEngine;

public class SquadFindScreen : GuiScreenSingle<SquadFindScreen>
{
	public enum SearchingState
	{
		NoInput,
		Writing,
		Searching
	}

	public enum Tab
	{
		Local,
		Global
	}

	[Header("Header Buttons")]
	public UITable buttonsTable;

	public List<SquadButton> tabButtons;

	public UISprite leftHighlight;

	public UISprite rightHighlight;

	[Header("Search Part")]
	public GameObject searchButton;

	public GameObject cancelSearchButton;

	public UIInput searchInput;

	public UISprite searchInputBorder;

	public BoxCollider searchInputCollider;

	public UISprite waitingSprite;

	[Header("Contents")]
	public SquadFindResults globalResults;

	public SquadFindResults localResults;

	[HideInInspector]
	public float dur = 0.2f;

	[HideInInspector]
	public string lastSearch;

	[HideInInspector]
	public bool firstSuggestedSquadsSearch = true;

	private Tab mActiveTab;

	private SearchingState mState;

	public float headerHeight => 450f;

	public void ShowTab(bool global)
	{
		mActiveTab = (global ? Tab.Global : Tab.Local);
		if (isShowed)
		{
			InitGUIValues();
		}
		else
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadFindScreen>.instance);
		}
	}

	public override void InitEvents()
	{
		localResults.InitEvents();
		globalResults.InitEvents();
	}

	protected override void InitControls()
	{
		UIInput uIInput = searchInput;
		uIInput.onSubmit = (UIInput.OnSubmit)Delegate.Combine(uIInput.onSubmit, new UIInput.OnSubmit(OnInputSubmit));
		UIInput uIInput2 = searchInput;
		uIInput2.onLostFocus = (UIInput.OnLostFocus)Delegate.Combine(uIInput2.onLostFocus, new UIInput.OnLostFocus(OnLostFocus));
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataLoaded;
		UIEventListener uIEventListener = UIEventListener.Get(searchButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FindSquadClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(searchInputCollider.gameObject);
		uIEventListener2.onPress = (UIEventListener.BoolDelegate)Delegate.Combine(uIEventListener2.onPress, new UIEventListener.BoolDelegate(InputPressed));
		UIEventListener uIEventListener3 = UIEventListener.Get(cancelSearchButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(CancelSearchClick));
		searchInput.maxChars = DatabaseSquad.maxSquadName;
		searchInput.defaultText = Localization.Localize("ID_SEARCHFORSQUAD");
		rightHighlight.transform.localPosition = new Vector3(UIRoot.list[0].activeWidth - 48f, rightHighlight.transform.localPosition.y, 0f);
		tabButtons[0].Initialize(Localization.Localize("ID_LOCAL"), dur);
		tabButtons[1].Initialize(Localization.Localize("ID_GLOBAL"), dur);
		buttonsTable.repositionNow = true;
		buttonsTable.onReposition = delegate
		{
			SetAndAnimateHighlights(instant: true);
		};
		foreach (SquadButton tabButton in tabButtons)
		{
			UIEventListener uIEventListener4 = UIEventListener.Get(tabButton.gameObject);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(HeaderButtonClick));
		}
		SetSearchingState(SearchingState.NoInput, callChildrenEvent: false);
		localResults.InitControls();
		globalResults.InitControls();
	}

	private void OnInputSubmit(string inputString)
	{
		if (inputString.Length == 0)
		{
			SetSearchingState(SearchingState.NoInput);
			return;
		}
		SetSearchingState(SearchingState.Searching);
		if (inputString.Length >= 3)
		{
			waitingSprite.gameObject.SetActive(value: true);
			lastSearch = inputString;
			Singleton<BeanstalkServerManager>.instance.GetSquads(inputString, mActiveTab == Tab.Global);
		}
	}

	private void OnLostFocus(string inputString)
	{
		SetSearchingState((inputString.Length != 0) ? SearchingState.Writing : SearchingState.NoInput, callChildrenEvent: false);
	}

	private void OnDataLoaded(DatabaseAction action)
	{
		if (action == DatabaseAction.UserAddedToSquadSuccess)
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadScreen>.instance);
			GuiScreenSingle<SquadScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
		}
	}

	private void FindSquadClick(GameObject go)
	{
		OnInputSubmit(searchInput.text);
	}

	private void InputPressed(GameObject go, bool state)
	{
		if (state)
		{
			SetSearchingState(SearchingState.Writing);
		}
	}

	private void CancelSearchClick(GameObject go)
	{
		waitingSprite.gameObject.SetActive(value: false);
		searchInput.text = string.Empty;
		SetSearchingState(SearchingState.NoInput);
	}

	private void HeaderButtonClick(GameObject go)
	{
		SquadButton button = go.GetComponentsInChildren<SquadButton>(includeInactive: true)[0];
		int num = tabButtons.FindIndex((SquadButton a) => a == button);
		if (!tabButtons[num].pressed)
		{
			SelectTab((Tab)num);
			if (string.IsNullOrEmpty(lastSearch))
			{
				ResetSearchingField();
			}
			else
			{
				OnInputSubmit(lastSearch);
			}
		}
	}

	private void ResetSearchingField()
	{
		waitingSprite.gameObject.SetActive(value: false);
		searchInput.text = string.Empty;
		SetSearchingState(SearchingState.NoInput, callChildrenEvent: false);
	}

	public override void InitGUIValues()
	{
		SelectTab(mActiveTab, instant: true);
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		firstSuggestedSquadsSearch = true;
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		if (mActiveTab == Tab.Local)
		{
			localResults.Animate(showTab: false, instant: false);
		}
		if (mActiveTab == Tab.Global)
		{
			globalResults.Animate(showTab: false, instant: false);
		}
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		localResults.InstantHideTab();
		globalResults.InstantHideTab();
		ResetSearchingField();
	}

	private void SetSearchingState(SearchingState newState, bool callChildrenEvent = true)
	{
		mState = newState;
		cancelSearchButton.SetActive(mState != SearchingState.NoInput);
		searchInputBorder.color = ((mState != SearchingState.NoInput) ? Color.white : Colours.grayBorder);
		searchInput.label.color = ((mState != SearchingState.Searching) ? Color.white : Colours.blue);
		if (mState == SearchingState.NoInput)
		{
			lastSearch = string.Empty;
		}
		if (callChildrenEvent && newState == SearchingState.NoInput)
		{
			if (mActiveTab == Tab.Global)
			{
				globalResults.SetSuggested();
			}
			else
			{
				localResults.SetSuggested();
			}
		}
		if (callChildrenEvent && newState == SearchingState.Searching)
		{
			if (mActiveTab == Tab.Global)
			{
				globalResults.SetSearching(searchInput.text);
			}
			else
			{
				localResults.SetSearching(searchInput.text);
			}
		}
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
		bool flag = mActiveTab == Tab.Local;
		bool flag2 = mActiveTab == Tab.Global;
		if (instant)
		{
			localResults.Animate(flag, instant: true);
			globalResults.Animate(flag2, instant: true);
			return;
		}
		if (localResults.gameObject.activeSelf && !flag)
		{
			localResults.Animate(flag, instant: false);
		}
		if (globalResults.gameObject.activeSelf && !flag2)
		{
			globalResults.Animate(flag2, instant: false);
		}
		if (!localResults.gameObject.activeSelf && flag)
		{
			localResults.Animate(flag, instant: false);
		}
		if (!globalResults.gameObject.activeSelf && flag2)
		{
			globalResults.Animate(flag2, instant: false);
		}
		if (localResults.gameObject.activeSelf && flag)
		{
			localResults.Animate(flag, instant: false);
		}
		if (globalResults.gameObject.activeSelf && flag2)
		{
			globalResults.Animate(flag2, instant: false);
		}
	}
}
