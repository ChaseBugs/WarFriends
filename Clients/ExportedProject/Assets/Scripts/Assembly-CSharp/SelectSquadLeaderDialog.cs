using System;
using System.Collections.Generic;
using UnityEngine;

public class SelectSquadLeaderDialog : GuiElementSingle<SelectSquadLeaderDialog>, IGuiDialog
{
	public Action<DatabasePlayer, bool> memberSelected;

	[Header("Close Button")]
	public UIButton closeButton;

	[Header("Result Lists")]
	public MemberSelectRecord memberSelectPrefab;

	public UIDraggablePanel draggablePanel;

	public UIPooledGrid membersGrid;

	public GameObject membersWaiting;

	private List<DatabasePlayer> mMembersList = new List<DatabasePlayer>();

	private UIDraggablePanel mPanelToDisable;

	public static void ShowSelectNewSquadLeader(Action<DatabasePlayer, bool> memberSelect, UIDraggablePanel draggablePanelToDisable)
	{
		SelectSquadLeaderDialog selectSquadLeaderDialog = GuiElementSingle<SelectSquadLeaderDialog>.instance;
		selectSquadLeaderDialog.mPanelToDisable = draggablePanelToDisable;
		selectSquadLeaderDialog.memberSelected = memberSelect;
		Singleton<GuiManager>.instance.ShowDialog(selectSquadLeaderDialog, 0f);
	}

	public override void InitEvents()
	{
		base.InitEvents();
		UIEventListener uIEventListener = UIEventListener.Get(closeButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseButtonClick));
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataLoaded;
	}

	public override void InitControls()
	{
		float num = (float)UIRoot.list[0].activeHeight - 454f;
		draggablePanel.transform.localPosition = new Vector3(draggablePanel.transform.localPosition.x, 0f, draggablePanel.transform.localPosition.z);
		BoxCollider component = draggablePanel.gameObject.GetComponent<BoxCollider>();
		component.center = new Vector3(component.center.x, 0f - num / 2f, component.center.z);
		component.size = new Vector3(component.size.x, num, component.size.z);
		UIPanel component2 = draggablePanel.gameObject.GetComponent<UIPanel>();
		component2.clipRange = new Vector4(component2.clipRange.x, 0f - num / 2f, component2.clipRange.z, num);
	}

	private void CloseButtonClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			if (memberSelected != null)
			{
				memberSelected(null, arg2: false);
				memberSelected = null;
			}
		}
	}

	private void OnDataLoaded(DatabaseAction action)
	{
		if (!isShowed)
		{
			return;
		}
		if (action != DatabaseAction.GetAllSquadMembers)
		{
			return;
		}
		DatabasePlayer me = GameLoginManager.currentPlayer;
		List<DatabasePlayer> squadMembers = Singleton<ServerResultsCache>.instance.GetSquadMembers(me.squadName);
		if (squadMembers == null)
		{
			return;
		}
		mMembersList = new List<DatabasePlayer>(squadMembers);
		int num = mMembersList.FindIndex((DatabasePlayer p1) => p1.id == me.id);
		if (num > -1)
		{
			mMembersList.RemoveAt(num);
		}
		for (int num2 = mMembersList.Count - 1; num2 >= 0; num2--)
		{
			if (string.IsNullOrEmpty(mMembersList[num2].name))
			{
				mMembersList.RemoveAt(num2);
			}
		}
		mMembersList.Sort(SortFunctionPlayers);
		ShowSquadMembers();
	}

	private int SortFunctionPlayers(DatabasePlayer a, DatabasePlayer b)
	{
		if (string.IsNullOrEmpty(a.name))
		{
			return (!string.IsNullOrEmpty(b.name)) ? (-1) : 0;
		}
		return a.name.CompareTo(b.name);
	}

	private void ShowSquadMembers()
	{
		membersWaiting.SetActive(value: false);
		membersGrid.init(mMembersList.Count, MemberInstantinate, MemberFree, draggablePanel);
		draggablePanel.AlignToPos(instant: true);
	}

	private Transform MemberInstantinate(int index)
	{
		if (index >= 0 && index < mMembersList.Count)
		{
			MemberSelectRecord memberSelectRecord = Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(memberSelectPrefab, membersGrid.gameObject, $"{index} {mMembersList[index].name}") as MemberSelectRecord;
			if (memberSelectRecord != null)
			{
				memberSelectRecord.Initialize(mMembersList[index]);
				return memberSelectRecord.transform;
			}
		}
		return null;
	}

	private void MemberFree(Transform obj)
	{
		if (obj != null)
		{
			MemberSelectRecord component = obj.GetComponent<MemberSelectRecord>();
			if (component != null)
			{
				component.DestroyPooled();
			}
		}
	}

	public override void InitGUIValues()
	{
		membersWaiting.SetActive(value: true);
		membersGrid.MakeEmpty();
		Singleton<BeanstalkServerManager>.instance.GetAllSquadMembers(GameLoginManager.currentPlayer.squadName);
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		draggablePanel.forceDrag = true;
		if (mPanelToDisable != null)
		{
			mPanelToDisable.onePanelDisabled = true;
		}
		UIDraggablePanel.panelDisabled = true;
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		if (mPanelToDisable != null)
		{
			mPanelToDisable.onePanelDisabled = false;
			mPanelToDisable = null;
		}
		UIDraggablePanel.panelDisabled = false;
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		membersGrid.MakeEmpty();
	}

	public void Select(DatabasePlayer player)
	{
		if (isShowed)
		{
			if (memberSelected != null)
			{
				SoundsManager.Instance.PlayButtonClickedSound();
				memberSelected(player, arg2: true);
				memberSelected = null;
			}
			HideDialog();
		}
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		CloseButtonClick(closeButton.gameObject);
	}
}
