using System;
using System.Collections.Generic;
using UnityEngine;

public class MainScreenAssignments : Core_BaseScript
{
	[Header("Core")]
	public BoxCollider boxCollider;

	public GameObject assignmentNotificationObject;

	public GameObject assignmentNotificationGold;

	public GameObject assignmentNotificationWarbucks;

	[Header("Starter")]
	public GameObject starterPart;

	public WinStreakCounter starterCounter;

	public StarterAssignmentComplete[] starterCompleted;

	[Header("Daily")]
	public GameObject dailyPart;

	public UILabel dailyProgressLabel;

	public UISprite[] dailyAssignmentProgress;

	public UISprite dailyDayProgress;

	public UISprite[] dailyDayCompleted;

	public BoxCollider dailyPartClaimCollider;

	[Header("-Hint")]
	public BoxCollider dailyMegaRewardHint;

	public UISprite dailyMegaRewardHintButtonSprite;

	public UIPanel hintDialog;

	public BoxCollider hintCollider;

	public UITable hintTable;

	public GameObject hintLengthObject;

	public UISprite hintDialogBackground;

	public void InitControls()
	{
		AssignmentsManager.instance.AssignmentsLoaded += UpdateGui;
		AssignmentsManager.instance.AssignmentClaimed += delegate
		{
			UpdateGui();
		};
		StarterAssignmentsManager.instance.AssignmentClaimed += UpdateGui;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataLoaded;
		hintTable.repositionNow = true;
		UITable uITable = hintTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Combine(uITable.onReposition, new UITable.OnReposition(OnHintReposition));
		UIEventListener uIEventListener = UIEventListener.Get(boxCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(AssignmentsClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(dailyMegaRewardHint.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HintButtonClick));
		UIEventListener uIEventListener3 = UIEventListener.Get(hintDialog.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(HintDialogClick));
		UIEventListener uIEventListener4 = UIEventListener.Get(dailyPartClaimCollider.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(ClaimMegaRewardClick));
	}

	private void OnDataLoaded(DatabaseAction action)
	{
		if (action == DatabaseAction.CompleteStarterAssignments || action == DatabaseAction.ClaimAssignmentMegaReward)
		{
			UpdateGui();
		}
	}

	private void UpdateGui()
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed)
		{
			InitGuiValues();
		}
	}

	private void OnHintReposition()
	{
		float num = Mathf.Abs(hintLengthObject.transform.localPosition.y);
		hintDialogBackground.transform.localScale = hintDialogBackground.transform.localScale.ReplaceY(num + 60f);
		hintCollider.center = hintCollider.center.ReplaceY((0f - num) / 2f - 30f);
		hintCollider.size = hintCollider.size.ReplaceY(num + 100f);
	}

	private void AssignmentsClick(GameObject go)
	{
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<AssignmentsScreen>.instance);
	}

	private void HintButtonClick(GameObject go)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (hintDialog.gameObject.activeSelf)
		{
			HideHint();
		}
		else
		{
			ShowHint();
		}
	}

	private void HintDialogClick(GameObject go)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		HideHint();
	}

	private void ClaimMegaRewardClick(GameObject go)
	{
		dailyPartClaimCollider.enabled = false;
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.AssignmentMegaReward);
		Singleton<BeanstalkServerManager>.instance.ClaimAssignmentMegaReward();
	}

	public void InitGuiValues()
	{
		bool isActiveAndNotCompleted = StarterAssignmentsManager.instance.isActiveAndNotCompleted;
		dailyPart.SetActive(!isActiveAndNotCompleted);
		starterPart.SetActive(isActiveAndNotCompleted);
		AssignmentNotification();
		if (isActiveAndNotCompleted)
		{
			UpdateStarterLook();
		}
		else
		{
			UpdateDailyLook();
		}
	}

	private void UpdateStarterLook()
	{
		StarterAssignment currentAssignment = StarterAssignmentsManager.instance.currentAssignment;
		int num = ((currentAssignment == null) ? StarterAssignmentsManager.instance.assignmentsCount : (currentAssignment.order - 1));
		for (int i = 0; i < starterCompleted.Length; i++)
		{
			if (i < num)
			{
				starterCompleted[i].SetCompleted();
			}
			else if (i == num)
			{
				starterCompleted[i].SetCurrent();
			}
			else
			{
				starterCompleted[i].SetDefault();
			}
		}
		starterCounter.StopCounter();
		starterCounter.StartCounter(StarterAssignmentsManager.instance.remainingTime);
	}

	private void UpdateDailyLook()
	{
		List<Assignment> assignments = AssignmentsManager.instance.GetAssignments(update: false);
		int num = 0;
		for (int i = 0; i < dailyAssignmentProgress.Length; i++)
		{
			float fillAmount = ((assignments.Count > i) ? assignments[i].GetProgress() : 0f);
			dailyAssignmentProgress[i].fillAmount = fillAmount;
			if (assignments.Count > i && assignments[i].currentState == Assignment.State.Claimed)
			{
				num++;
			}
		}
		dailyProgressLabel.text = $"{num} / {assignments.Count}";
		int completedDaysAssignments = AssignmentsManager.instance.completedDaysAssignments;
		for (int j = 0; j < dailyDayCompleted.Length; j++)
		{
			dailyDayCompleted[j].gameObject.SetActive(j < completedDaysAssignments);
		}
		if (completedDaysAssignments >= 7)
		{
			dailyDayProgress.fillAmount = 1f;
		}
		else if (completedDaysAssignments <= 0)
		{
			dailyDayProgress.fillAmount = 0f;
		}
		else
		{
			dailyDayProgress.fillAmount = (90f + 70f * (float)(completedDaysAssignments - 1)) / 600f;
		}
		InstantHideHint();
		bool active = completedDaysAssignments >= dailyDayCompleted.Length;
		dailyPartClaimCollider.gameObject.SetActive(active);
		dailyPartClaimCollider.enabled = true;
	}

	private void AssignmentNotification()
	{
		if (!StarterAssignmentsManager.instance.isActiveAndNotCompleted && Singleton<NotificationManager>.instance.GetNumberOfAssignmentNotifications() > 0)
		{
			assignmentNotificationObject.SetActive(value: true);
			assignmentNotificationGold.gameObject.SetActive(value: true);
			assignmentNotificationWarbucks.gameObject.SetActive(value: false);
		}
		else if (Singleton<NotificationManager>.instance.NotificationStarterAssignments())
		{
			assignmentNotificationObject.SetActive(value: true);
			assignmentNotificationGold.gameObject.SetActive(!StarterAssignmentsManager.instance.isWBReward);
			assignmentNotificationWarbucks.gameObject.SetActive(StarterAssignmentsManager.instance.isWBReward);
		}
		else
		{
			assignmentNotificationObject.SetActive(value: false);
		}
	}

	private void ShowHint()
	{
		dailyMegaRewardHintButtonSprite.spriteName = MiscTools.closeButtonSprite;
		dailyMegaRewardHintButtonSprite.MakePixelPerfect();
		hintDialog.gameObject.SetActive(value: true);
		hintDialog.alpha1 = 0.005f;
		TweenAlpha.Begin(hintDialog.gameObject, 0.4f, 1f).onFinished = null;
		hintDialog.transform.localPosition = new Vector3(302f, -20f, -50f);
		TweenPosition tweenPosition = TweenPosition.Begin(hintDialog.gameObject, 0.25f, new Vector3(302f, -115f, -50f), new Vector3(302f, -85f, -50f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			TweenPosition tweenPosition2 = TweenPosition.Begin(hintDialog.gameObject, 0.15f, new Vector3(302f, -95f, -50f));
			tweenPosition2.method = UITweener.Method.EaseOut;
			tweenPosition2.onFinished = null;
		};
	}

	private void HideHint()
	{
		dailyMegaRewardHintButtonSprite.spriteName = MiscTools.infoButtonSprite;
		dailyMegaRewardHintButtonSprite.MakePixelPerfect();
		TweenAlpha.Begin(hintDialog.gameObject, 0.4f, 0f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(hintDialog.gameObject, 0.4f, new Vector3(302f, -115f, -50f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			InstantHideHint();
		};
	}

	private void InstantHideHint()
	{
		hintDialog.gameObject.SetActive(value: false);
		dailyMegaRewardHintButtonSprite.spriteName = MiscTools.infoButtonSprite;
		dailyMegaRewardHintButtonSprite.MakePixelPerfect();
	}
}
