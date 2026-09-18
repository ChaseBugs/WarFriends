using System;
using System.Collections.Generic;
using UnityEngine;

public class DailyPart : Core_BaseScript
{
	[Header("Core")]
	public UIPanel[] panels;

	[Header("Left Part")]
	public AssignmentProgress assignmentProgress;

	public DailyProgress daysProgress;

	[Header("Center Part")]
	public GameObject centerPart;

	[Header("Right Part")]
	public GameObject rightPart;

	public UITable rightTable;

	public WinStreakCounter timeCounter;

	[Header("3 Assignments")]
	public UIGrid grid;

	public List<AssignmentScreenRecord> assignmentRecords;

	private bool mInitializedTime;

	private bool mIsActive;

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
			AnimatePanels((!instant) ? (GuiScreenSingle<AssignmentsScreen>.instance.dur * 2f) : 0.01f, (!mIsActive) ? 0f : 1f);
			TweenAlpha.Begin(base.gameObject, (!instant) ? (GuiScreenSingle<AssignmentsScreen>.instance.dur * 2f) : 0.01f, (!mIsActive) ? 0f : 1f).onFinished = delegate
			{
				if (!mIsActive)
				{
					DoAfterHide();
				}
			};
		}
		else if (!mIsActive)
		{
			InstantHideTab();
		}
	}

	private void AnimatePanels(float duration, float toAlpha)
	{
		for (int i = 0; i < panels.Length; i++)
		{
			if (panels[i].gameObject.activeSelf)
			{
				TweenAlpha.Begin(panels[i].gameObject, duration, toAlpha);
			}
		}
	}

	public void InstantHideTab()
	{
		DoAfterHide();
	}

	public void InitEvents()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataLoaded;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += OnDataLoaded;
	}

	private void OnDataLoaded(DatabaseAction action)
	{
		switch (action)
		{
		case DatabaseAction.SkipAssignment:
		case DatabaseAction.GetNewAssignments:
			UpdateAssignments();
			break;
		case DatabaseAction.ClaimAssignmentMegaReward:
			if (base.gameObject.activeInHierarchy)
			{
				InitGUIValues();
			}
			break;
		}
	}

	public void InitControls()
	{
		float activeWidth = UIRoot.list[0].activeWidth;
		centerPart.transform.localPosition = new Vector3(activeWidth / 2f, 0f, 0f);
		rightPart.transform.localPosition = new Vector3(activeWidth - 60f, 0f, 0f);
		float num = 1.3333334f;
		float num2 = 1.7777778f;
		float num3 = Mathf.Clamp(activeWidth / (float)UIRoot.list[0].activeHeight, num, num2);
		float num4 = (num2 - num3) / (num2 - num);
		grid.cellHeight = 240f + 18f * num4;
		grid.transform.localPosition = new Vector3(0f, -200f - 20f * num4, 0f);
		grid.repositionNow = true;
		assignmentRecords[0].InitControls();
		assignmentRecords[1].InitControls();
		assignmentRecords[2].InitControls();
		AssignmentsManager.instance.AssignmentsLoaded += delegate
		{
			if (base.gameObject.activeInHierarchy)
			{
				InitGUIValues();
			}
		};
		AssignmentsManager.instance.AssignmentClaimed += AssignmentClaimedEvent;
		assignmentProgress.AllClaimed += DailyAssignmentsClaimed;
		rightTable.onReposition = delegate
		{
			rightTable.transform.localPosition = new Vector3(0f - timeCounter.transform.localPosition.x, rightTable.transform.localPosition.y, 0f);
		};
		daysProgress.InitControls();
	}

	private void AssignmentClaimedEvent(int index)
	{
		assignmentProgress.AnimateClaim(index);
		List<Assignment> assignments = AssignmentsManager.instance.GetAssignments(update: false);
		if (assignments != null && assignments.Count == 3 && assignmentRecords[index].gameObject.activeSelf && !assignmentRecords[index].isAnimatingClaim)
		{
			assignmentRecords[index].Init(assignments[index]);
		}
	}

	private void DailyAssignmentsClaimed()
	{
		daysProgress.Show();
	}

	public void InitGUIValues()
	{
		UpdateAssignments();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.updateCounterBySecond = (Action)Delegate.Remove(instance.updateCounterBySecond, new Action(UpdateTable));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.updateCounterBySecond = (Action)Delegate.Combine(instance2.updateCounterBySecond, new Action(UpdateTable));
		daysProgress.Initialize();
		bool flag = AssignmentsManager.instance.preparedAssignments != null && AssignmentsManager.instance.preparedAssignments.Count > 0 && AssignmentsManager.instance.preparedAssignments[0] != null && AssignmentsManager.instance.preparedAssignments[0].claimed;
		bool flag2 = AssignmentsManager.instance.preparedAssignments != null && AssignmentsManager.instance.preparedAssignments.Count > 1 && AssignmentsManager.instance.preparedAssignments[1] != null && AssignmentsManager.instance.preparedAssignments[1].claimed;
		bool flag3 = AssignmentsManager.instance.preparedAssignments != null && AssignmentsManager.instance.preparedAssignments.Count > 2 && AssignmentsManager.instance.preparedAssignments[2] != null && AssignmentsManager.instance.preparedAssignments[2].claimed;
		bool flag4 = AssignmentsManager.instance.completedDaysAssignments >= 7;
		bool flag5 = flag && flag2 && flag3;
		bool showProgress = !flag4 && !flag5;
		assignmentProgress.Initialize(flag, flag2, flag3, showProgress);
	}

	public void DoAfterHide()
	{
		base.gameObject.SetActive(value: false);
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.updateCounterBySecond = (Action)Delegate.Remove(instance.updateCounterBySecond, new Action(UpdateTable));
	}

	private void UpdateAssignments()
	{
		if (!mInitializedTime)
		{
			timeCounter.counterLabel.text = Localization.Localize("ID_LOADING");
			Debug.Log("Day = " + AssignmentsManager.instance.data.tomorrow);
			SetAssignmentCounter(AssignmentsManager.instance.data.tomorrow);
		}
		List<Assignment> assignments = AssignmentsManager.instance.GetAssignments(update: false);
		for (int i = 0; i < 3; i++)
		{
			bool flag = assignments != null && assignments.Count > i && assignments[i] != null;
			assignmentRecords[i].gameObject.SetActive(flag);
			if (flag)
			{
				try
				{
					assignmentRecords[i].Init(assignments[i]);
				}
				catch (Exception e)
				{
					Crittercism.LogHandledException(e);
				}
			}
		}
	}

	private void SetAssignmentCounter(int assignmnetEndTimestamp)
	{
		mInitializedTime = true;
		timeCounter.StartCountingTo(assignmnetEndTimestamp);
		WinStreakCounter winStreakCounter = timeCounter;
		winStreakCounter.winStreakTimer = (Action)Delegate.Remove(winStreakCounter.winStreakTimer, new Action(EndCounter));
		WinStreakCounter winStreakCounter2 = timeCounter;
		winStreakCounter2.winStreakTimer = (Action)Delegate.Combine(winStreakCounter2.winStreakTimer, new Action(EndCounter));
	}

	private void EndCounter()
	{
		timeCounter.counterLabel.text = Localization.Localize("ID_NOW");
		mInitializedTime = false;
		Singleton<BeanstalkServerManager>.instance.GetNewAssignments();
	}

	private void UpdateTable()
	{
		rightTable.repositionNow = true;
	}
}
