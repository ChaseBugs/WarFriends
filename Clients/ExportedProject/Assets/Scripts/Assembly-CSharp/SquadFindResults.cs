using System;
using System.Collections.Generic;
using UnityEngine;

public class SquadFindResults : Core_BaseScript
{
	public bool isGlobal = true;

	[Header("Content List")]
	public SquadRecord squadRecordPrefab;

	public UIDraggablePanel draggablePanel;

	public UIPooledGrid grid;

	[Header("-List Header")]
	public GameObject header;

	public UISprite headerBackground;

	public UILabel headerLabel;

	[Header("-Error")]
	public GameObject error;

	public UISprite errorBorder;

	public UILabel errorLabel;

	[Header("-Waiting")]
	public GameObject waitingSuggested;

	[Header("Empty Suggested Squads")]
	public UIPanel emptySuggestedSquads;

	public GameObject createNewSquadButton;

	public BoxCollider createButtonCollider;

	public UIPanel createButtonInsidePanel;

	public GameObject createButtonLock;

	public UILabel createButtonUnlockLabel;

	private bool mIsActive;

	private ObjectPool mPool;

	private List<DatabaseSquad> mSquads;

	private bool mSearchedSquads;

	public void Animate(bool showTab, bool instant)
	{
		mIsActive = showTab;
		if (mIsActive && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
			InitGUIValues();
		}
		if (base.gameObject.activeSelf)
		{
			TweenAlpha.Begin(emptySuggestedSquads.gameObject, (!instant) ? (GuiScreenSingle<SquadFindScreen>.instance.dur * 2f) : 0.01f, (!mIsActive) ? 0f : 1f);
			TweenAlpha.Begin(createButtonInsidePanel.gameObject, (!instant) ? (GuiScreenSingle<SquadFindScreen>.instance.dur * 2f) : 0.01f, (!mIsActive) ? 0f : 1f);
			TweenAlpha.Begin(draggablePanel.gameObject, (!instant) ? (GuiScreenSingle<SquadFindScreen>.instance.dur * 2f) : 0.01f, (!mIsActive) ? 0f : 1f).onFinished = delegate
			{
				if (!mIsActive)
				{
					base.gameObject.SetActive(value: false);
					DoAfterHide();
				}
			};
		}
		else if (!mIsActive)
		{
			InstantHideTab();
		}
	}

	public void SetSuggested()
	{
		grid.MakeEmpty();
		ShowError(string.Empty, Color.white);
		DisplayEmptySuggestedSquads(showEmpty: false);
		mSearchedSquads = false;
		ShowHeader(Localization.Localize((!isGlobal) ? "ID_SUGGESTEDLOCALSQUADS" : "ID_SUGGESTEDGLOBALSQUADS"));
		waitingSuggested.SetActive(value: true);
		AlignTable();
		Singleton<BeanstalkServerManager>.instance.FindSuggestedSquads(isGlobal);
	}

	public void SetSearching(string searchedQuery)
	{
		grid.MakeEmpty();
		DisplayEmptySuggestedSquads(showEmpty: false);
		mSearchedSquads = true;
		ShowHeader(Localization.LocalizeFormat("ID_SEARCHRESULTSFOR", Colours.stringBlue, searchedQuery, Colours.stringWhite));
		if (searchedQuery.Length < 3)
		{
			ShowError(Localization.LocalizeFormat("ID_ERROR_SHORTINPUT", Colours.stringWhite, Colours.stringBlue), Colours.red);
		}
		else
		{
			ShowError(string.Empty, Color.white);
		}
		AlignTable();
	}

	public void InitEvents()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataLoaded;
	}

	private void OnDataLoaded(DatabaseAction action)
	{
		if (!GuiScreenSingle<SquadFindScreen>.instance.isShowed || !mIsActive)
		{
			return;
		}
		if (action != DatabaseAction.GetSquads && action != DatabaseAction.FindSuggestedSquads)
		{
			return;
		}
		Debug.Log($"Result for action:{action} on global:{isGlobal}");
		waitingSuggested.SetActive(value: false);
		GuiScreenSingle<SquadFindScreen>.instance.waitingSprite.gameObject.SetActive(value: false);
		if (action == DatabaseAction.FindSuggestedSquads && !isGlobal && !Singleton<ServerResultsCache>.instance.squadSearchIsLocal)
		{
			mSquads = null;
			DisplaySquads();
			if (GuiScreenSingle<SquadFindScreen>.instance.firstSuggestedSquadsSearch)
			{
				GuiScreenSingle<SquadFindScreen>.instance.ShowTab(global: true);
			}
		}
		else
		{
			mSquads = Singleton<ServerResultsCache>.instance.squadSearchResult;
			DisplaySquads();
		}
		GuiScreenSingle<SquadFindScreen>.instance.firstSuggestedSquadsSearch = false;
	}

	public void InitControls()
	{
		mPool = Singleton<GuiManager>.instance.objectPool;
		mIsActive = false;
		SetSizes();
		UIEventListener uIEventListener = UIEventListener.Get(createNewSquadButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CreateNewSquadClick));
	}

	private void CreateNewSquadClick(GameObject go)
	{
		if (DebugSettings.debugEnabled || !createButtonLock.activeSelf)
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadCreateScreen>.instance);
		}
	}

	public void InitGUIValues()
	{
		CreateSquadButtonLook();
		if (string.IsNullOrEmpty(GuiScreenSingle<SquadFindScreen>.instance.lastSearch))
		{
			SetSuggested();
		}
	}

	public void DoAfterHide()
	{
		grid.MakeEmpty();
	}

	public void InstantHideTab()
	{
		TweenAlpha component = draggablePanel.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		base.gameObject.SetActive(value: false);
		DoAfterHide();
	}

	private void DisplayEmptySuggestedSquads(bool showEmpty)
	{
		emptySuggestedSquads.gameObject.SetActive(showEmpty);
		if (showEmpty)
		{
			ShowHeader(string.Empty);
			ShowError(string.Empty, Color.white);
			waitingSuggested.SetActive(value: false);
		}
	}

	private void CreateSquadButtonLook()
	{
		int createSquadUnlockLevel = LevelManager.instance.createSquadUnlockLevel;
		bool flag = LevelManager.instance.currentLevel.displayNumber < createSquadUnlockLevel;
		createButtonCollider.enabled = !flag;
		createButtonUnlockLabel.text = string.Format("{0} {1}", Localization.Localize("ID_UNLOCKEDATRANK"), createSquadUnlockLevel);
		createButtonLock.SetActive(flag);
	}

	private void AlignTable()
	{
		draggablePanel.AlignToPos(instant: false);
	}

	private void ShowHeader(string headerMessage)
	{
		bool active = !string.IsNullOrEmpty(headerMessage);
		header.SetActive(active);
		headerLabel.text = headerMessage;
	}

	private void ShowError(string errorMessage, Color errorColor)
	{
		bool flag = !string.IsNullOrEmpty(errorMessage);
		error.SetActive(flag);
		errorLabel.color = errorColor.ReplaceA(errorLabel.alpha);
		errorLabel.text = errorMessage;
		grid.transform.localPosition = new Vector3(0f, (!flag) ? (-207f) : (-437f), 0f);
	}

	private void DisplaySquads()
	{
		if (mSquads == null || mSquads.Count == 0)
		{
			Debug.Log("No Squads Found");
			if (!mSearchedSquads)
			{
				DisplayEmptySuggestedSquads(showEmpty: true);
				return;
			}
			ShowError(Localization.Localize((!isGlobal) ? "ID_EMPTYFOUNDSQUADSLOCAL" : "ID_EMPTYFOUNDSQUADSGLOBAL"), Color.white);
			AlignTable();
		}
		else
		{
			grid.init(mSquads.Count, SquadInstantiate, SquadFree, draggablePanel);
			AlignTable();
		}
	}

	private Transform SquadInstantiate(int index)
	{
		if (index >= 0 && index < mSquads.Count)
		{
			DatabaseSquad databaseSquad = mSquads[index];
			if (databaseSquad == null)
			{
				return null;
			}
			SquadRecord squadRecord = (SquadRecord)mPool.InstantiateAsChild(squadRecordPrefab, grid.gameObject, $"Squad {databaseSquad.name}");
			if (squadRecord != null)
			{
				squadRecord.InitializeSquad(databaseSquad, grid.cellWidth);
				return squadRecord.transform;
			}
		}
		return null;
	}

	private void SquadFree(Transform obj)
	{
		if (obj != null)
		{
			SquadRecord component = obj.GetComponent<SquadRecord>();
			if (component != null)
			{
				component.DestroyPooled();
			}
		}
	}

	private void SetSizes()
	{
		float num = UIRoot.list[0].activeHeight;
		float activeWidth = UIRoot.list[0].activeWidth;
		float num2 = activeWidth - 120f;
		float num3 = num - GuiScreenSingle<SquadFindScreen>.instance.headerHeight;
		float y = num / 2f - GuiScreenSingle<SquadFindScreen>.instance.headerHeight - num3 / 2f;
		UIPanel component = draggablePanel.gameObject.GetComponent<UIPanel>();
		component.clipRange = new Vector4(component.clipRange.x, y, component.clipRange.z, num3);
		BoxCollider component2 = draggablePanel.gameObject.GetComponent<BoxCollider>();
		component2.center = new Vector3(component2.center.x, y, component2.center.z);
		component2.size = new Vector3(component2.size.x, num3, component2.size.z);
		draggablePanel.transform.localPosition = Vector3.zero;
		grid.cellWidth = num2;
		headerBackground.transform.localScale = headerBackground.transform.localScale.ReplaceX(num2);
		errorBorder.transform.localScale = errorBorder.transform.localScale.ReplaceX(num2);
		waitingSuggested.transform.localPosition = waitingSuggested.transform.localPosition.ReplaceY(GuiScreenSingle<SquadFindScreen>.instance.headerHeight - num / 2f - 100f);
	}
}
