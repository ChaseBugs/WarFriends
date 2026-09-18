using System;
using UnityEngine;

public class SquadEventDialog : GuiElementSingle<SquadEventDialog>, IGuiDialog
{
	[Header("Dialog Parts")]
	public UISprite background;

	public UIButton close;

	[Header("JOIN")]
	public GameObject squadEventJoin;

	public WinStreakCounter counterEventEnd;

	[Header("-Bottom Join")]
	public UIButton joinEvent;

	public GameObject memberPart;

	public UIButton informSquadLeader;

	public UISprite waitingCircle;

	public UILabel yellowNotifLabel;

	[Header("RESULT")]
	public GameObject squadEventResult;

	public UILabel tiersFinished;

	public UILabel rewardValue;

	public UIButton joinNewEvent;

	private bool waitingForResponse;

	private Vector3 mShorterBackground = new Vector3(1240f, 986f, 1f);

	private Vector3 mLongerBackground = new Vector3(1240f, 986f, 1f);

	public void ShowResult(int reward, int tier)
	{
		background.transform.localScale = mShorterBackground;
		squadEventResult.SetActive(value: true);
		squadEventJoin.SetActive(value: false);
		bool active = GameLoginManager.currentPlayer.squadRank == SquadRank.Leader;
		joinNewEvent.gameObject.SetActive(active);
		DatabaseSquadEventProgress squadEventProgress = Singleton<ServerResultsCache>.instance.squadEventProgress;
		tiersFinished.text = Localization.LocalizeFormat("ID_TIERSFINISHED", Colours.stringGoldTier, tier, squadEventProgress.tiers.Count);
		rewardValue.text = $"{MiscTools.FormatBigNumber(reward)}";
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<SquadEventDialog>.instance, 0f);
	}

	public void ShowJoin()
	{
		squadEventResult.SetActive(value: false);
		squadEventJoin.SetActive(value: true);
		bool flag = GameLoginManager.currentPlayer.squadRank == SquadRank.Leader;
		background.transform.localScale = ((!flag) ? mShorterBackground : mLongerBackground);
		joinEvent.gameObject.SetActive(flag);
		memberPart.SetActive(!flag && !waitingForResponse);
		waitingCircle.gameObject.SetActive(waitingForResponse);
		yellowNotifLabel.gameObject.SetActive(value: false);
		DatabaseSquadEventDefinition squadEventDefinition = Singleton<ServerResultsCache>.instance.squadEventDefinition;
		counterEventEnd.StartCountingTo(squadEventDefinition.eventEnd);
		counterEventEnd.winStreakTimer = delegate
		{
			counterEventEnd.winStreakTimer = null;
			joinEvent.gameObject.SetActive(value: false);
			memberPart.SetActive(value: false);
			waitingCircle.gameObject.SetActive(value: false);
			yellowNotifLabel.gameObject.SetActive(value: false);
		};
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<SquadEventDialog>.instance, 0f);
	}

	public override void InitEvents()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataLoaded;
		GameLoginManager.instance.PlayerLogOut += delegate
		{
			waitingForResponse = false;
		};
	}

	private void OnDataLoaded(DatabaseAction action)
	{
		if (action == DatabaseAction.InformSquadLeaderAboutEvent)
		{
			waitingForResponse = false;
			memberPart.SetActive(value: false);
			waitingCircle.gameObject.SetActive(waitingForResponse);
			yellowNotifLabel.gameObject.SetActive(value: true);
		}
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(close.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener2 = UIEventListener.Get(joinEvent.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(JoinEventClick));
		UIEventListener uIEventListener3 = UIEventListener.Get(informSquadLeader.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(InformSquadLeaderClick));
		UIEventListener uIEventListener4 = UIEventListener.Get(joinNewEvent.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(JoinEventClick));
	}

	private void CloseDialog(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void JoinEventClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			Singleton<BeanstalkServerManager>.instance.JoinSquadEvent();
			GuiScreenSingle<SquadScreen>.instance.eventContent.ShowWaiting();
			HideDialog();
		}
	}

	private void InformSquadLeaderClick(GameObject go)
	{
		if (!waitingForResponse)
		{
			waitingForResponse = true;
			memberPart.SetActive(value: false);
			waitingCircle.gameObject.SetActive(waitingForResponse);
			yellowNotifLabel.gameObject.SetActive(value: false);
			Singleton<BeanstalkServerManager>.instance.InformSquadLeaderAboutEvent();
		}
	}

	public override void InitGUIValues()
	{
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		counterEventEnd.StopCountingTo();
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		CloseDialog(close.gameObject);
	}
}
