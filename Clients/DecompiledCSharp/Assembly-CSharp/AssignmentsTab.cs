using System;
using System.Collections.Generic;
using UnityEngine;

public class AssignmentsTab : Core_BaseScript
{
	[Header("Core")]
	public UIPanel[] panels;

	[Header("Daily")]
	public GameObject dailyPart;

	public WinStreakCounter newDailyCounter;

	public AssignmentsTabDailyRecord[] dailyRecords;

	[Header("Starter")]
	public GameObject starterPart;

	public UILabel starterDeadline;

	public AssignmentsTabStarterRecord currentStarterAssignment;

	public UILabel rewardsTitle;

	private bool mInitializedTime;

	public void AnimatePanels(float time, float toAlpha)
	{
		for (int i = 0; i < panels.Length; i++)
		{
			TweenAlpha.Begin(panels[i].gameObject, time, toAlpha);
		}
	}

	public void InstaShow()
	{
		for (int i = 0; i < panels.Length; i++)
		{
			TweenAlpha component = panels[i].gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			panels[i].alpha1 = 1f;
		}
	}

	public void InitControls()
	{
		for (int i = 0; i < dailyRecords.Length; i++)
		{
			dailyRecords[i].InitControls();
		}
		currentStarterAssignment.InitControls();
		AssignmentsManager.instance.AssignmentsLoaded += delegate
		{
			if (base.gameObject.activeSelf)
			{
				InitGUIValues();
			}
		};
	}

	public void InitGUIValues()
	{
		bool isActiveAndNotCompleted = StarterAssignmentsManager.instance.isActiveAndNotCompleted;
		dailyPart.SetActive(!isActiveAndNotCompleted);
		starterPart.SetActive(isActiveAndNotCompleted);
		if (isActiveAndNotCompleted)
		{
			StarterAssignmentsManager.instance.Evaluate();
			CounterManager instance = Singleton<CounterManager>.instance;
			instance.updateCounterBySecond = (Action)Delegate.Remove(instance.updateCounterBySecond, new Action(UpdateTimer));
			CounterManager instance2 = Singleton<CounterManager>.instance;
			instance2.updateCounterBySecond = (Action)Delegate.Combine(instance2.updateCounterBySecond, new Action(UpdateTimer));
			currentStarterAssignment.Initialize(StarterAssignmentsManager.instance.currentAssignment);
			return;
		}
		if (!mInitializedTime)
		{
			newDailyCounter.counterLabel.text = Localization.Localize("ID_LOADING");
			int num = ((AssignmentsManager.instance.data != null) ? AssignmentsManager.instance.data.tomorrow : (-1));
			Debug.Log("Day = " + num);
			SetAssignmentCounter(num);
		}
		List<Assignment> assignments = AssignmentsManager.instance.GetAssignments(update: false);
		for (int i = 0; i < 3; i++)
		{
			bool flag = assignments != null && assignments.Count > i && assignments[i] != null;
			dailyRecords[i].gameObject.SetActive(flag);
			if (flag)
			{
				try
				{
					dailyRecords[i].Initialize(assignments[i]);
				}
				catch (Exception e)
				{
					Crittercism.LogHandledException(e);
				}
			}
		}
	}

	public void UpdateTimer()
	{
		if (StarterAssignmentsManager.instance.isAllCompleted)
		{
			starterDeadline.text = Colours.stringWhite + Localization.Localize("ID_COMPLETED");
			rewardsTitle.text = Localization.Localize("ID_YOURREWARDS");
			return;
		}
		int remainingTime = StarterAssignmentsManager.instance.remainingTime;
		if (remainingTime == 0)
		{
			starterDeadline.text = Localization.Localize("ID_EXPIRED");
			rewardsTitle.text = Localization.Localize("ID_STARTERASSIGNMENTSEXPIRED");
		}
		else
		{
			starterDeadline.text = string.Format("{0} {1}{2}", MiscTools.PrintableTime(remainingTime, "ID_READYTIME", string.Empty), Colours.stringWhite, Localization.Localize("ID_TOCOMPLETE"));
			rewardsTitle.text = Localization.Localize("ID_GETREWARDSFORSTARTERASSIGNMENTS");
		}
	}

	private void SetAssignmentCounter(int assignmnetEndTimestamp)
	{
		if (assignmnetEndTimestamp >= Singleton<BeanstalkServerManager>.instance.currentTimestamp)
		{
			mInitializedTime = true;
			newDailyCounter.StartCountingTo(assignmnetEndTimestamp);
			WinStreakCounter winStreakCounter = newDailyCounter;
			winStreakCounter.winStreakTimer = (Action)Delegate.Remove(winStreakCounter.winStreakTimer, new Action(EndCounter));
			WinStreakCounter winStreakCounter2 = newDailyCounter;
			winStreakCounter2.winStreakTimer = (Action)Delegate.Combine(winStreakCounter2.winStreakTimer, new Action(EndCounter));
		}
	}

	private void EndCounter()
	{
		newDailyCounter.counterLabel.text = Localization.Localize("ID_NOW");
		mInitializedTime = false;
		Singleton<BeanstalkServerManager>.instance.GetNewAssignments();
	}
}
