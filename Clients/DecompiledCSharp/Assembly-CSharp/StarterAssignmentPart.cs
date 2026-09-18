using System;
using UnityEngine;

public class StarterAssignmentPart : Core_BaseScript
{
	[Header("Core")]
	public UIPanel panel;

	public UIPanel[] panels;

	[Header("Completition")]
	public GameObject completitionPart;

	public UILabel timeToCompleteLabel;

	public StarterAssignmentComplete[] completedAssignments;

	[Header("Current Assignment")]
	public StarterAssignmentRecord currentAssignmentRecord;

	[Header("Rewards")]
	public GameObject rewardsPart;

	public UILabel rewardsTimeToEndLabel;

	public UIGrid rewardsGrid;

	public UISprite[] rewardsIcons;

	public UILabel[] rewardsTexts;

	private bool mIsActive;

	private float mWidth;

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
			TweenAlpha.Begin(panel.gameObject, (!instant) ? (GuiScreenSingle<AssignmentsScreen>.instance.dur * 2f) : 0.01f, (!mIsActive) ? 0f : 1f).onFinished = delegate
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

	public void InitControls()
	{
		mWidth = UIRoot.list[0].activeWidth;
		float num = 1.3333334f;
		float num2 = 1.7777778f;
		float num3 = Mathf.Clamp(mWidth / (float)UIRoot.list[0].activeHeight, num, num2);
		float num4 = (num3 - num2) / (num - num2);
		float num5 = (1f - num4) * 60f;
		completitionPart.transform.localPosition = new Vector3(mWidth / 2f, -86f, 0f);
		currentAssignmentRecord.transform.localPosition = new Vector3(60f, -290f + num5 / 2f, 0f);
		rewardsPart.transform.localPosition = new Vector3(mWidth / 2f, -484f + num5, 0f);
		float num6 = 326f;
		rewardsGrid.cellWidth = num6 + (mWidth - 120f - 5f * num6) / 4f;
		rewardsGrid.transform.localPosition = new Vector3(0f - (mWidth - 120f) / 2f + num6 / 2f, rewardsGrid.transform.localPosition.y, rewardsGrid.transform.localPosition.z);
		currentAssignmentRecord.InitControls(mWidth);
		StarterAssignmentsManager.instance.AssignmentClaimed += AnimateLine;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += delegate(DatabaseAction action)
		{
			if (base.gameObject.activeInHierarchy && DebugSettings.debugEnabled && action == DatabaseAction.CompleteStarterAssignments)
			{
				InitGUIValues();
			}
		};
	}

	private void AnimateLine()
	{
		StarterAssignment starterAssignment = StarterAssignmentsManager.instance.currentAssignment;
		if (starterAssignment == null && StarterAssignmentsManager.instance.assignmentsCount > 0)
		{
			starterAssignment = StarterAssignmentsManager.instance.assignments[StarterAssignmentsManager.instance.assignmentsCount - 1];
		}
		int num = ((starterAssignment != null) ? (starterAssignment.order - 1) : StarterAssignmentsManager.instance.assignmentsCount);
		completedAssignments[num - 1].AnimateFinish();
		if (num < StarterAssignmentsManager.instance.assignmentsCount)
		{
			completedAssignments[num].AnimateProgress();
		}
	}

	public void InitGUIValues()
	{
		StarterAssignmentsManager.instance.Evaluate();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.updateCounterBySecond = (Action)Delegate.Remove(instance.updateCounterBySecond, new Action(UpdateTimer));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.updateCounterBySecond = (Action)Delegate.Combine(instance2.updateCounterBySecond, new Action(UpdateTimer));
		StarterAssignment currentAssignment = StarterAssignmentsManager.instance.currentAssignment;
		int num = ((!StarterAssignmentsManager.instance.isAllCompleted) ? (currentAssignment.order - 1) : StarterAssignmentsManager.instance.assignmentsCount);
		for (int i = 0; i < completedAssignments.Length; i++)
		{
			if (i < num)
			{
				completedAssignments[i].SetCompleted();
			}
			else if (i == num)
			{
				completedAssignments[i].SetCurrent();
			}
			else
			{
				completedAssignments[i].SetDefault();
			}
		}
		currentAssignmentRecord.Initialize(currentAssignment);
	}

	public void DoAfterHide()
	{
		base.gameObject.SetActive(value: false);
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.updateCounterBySecond = (Action)Delegate.Remove(instance.updateCounterBySecond, new Action(UpdateTimer));
	}

	public void UpdateTimer()
	{
		if (StarterAssignmentsManager.instance.isAllCompleted)
		{
			timeToCompleteLabel.text = Colours.stringWhite + Localization.Localize("ID_COMPLETED");
			rewardsTimeToEndLabel.text = Localization.Localize("ID_YOURREWARDS");
			return;
		}
		int remainingTime = StarterAssignmentsManager.instance.remainingTime;
		if (remainingTime == 0)
		{
			timeToCompleteLabel.text = Localization.Localize("ID_EXPIRED");
			rewardsTimeToEndLabel.text = Localization.Localize("ID_STARTERASSIGNMENTSEXPIRED");
		}
		else
		{
			timeToCompleteLabel.text = string.Format("{0} {1}{2}", MiscTools.PrintableTime(remainingTime, "ID_READYTIME", string.Empty), Colours.stringWhite, Localization.Localize("ID_TOCOMPLETE"));
			rewardsTimeToEndLabel.text = Localization.LocalizeFormat("ID_COMPLETEALLTENSTARTERASSIGNMENTS", MiscTools.PrintableTime(remainingTime, "ID_READYTIME", string.Empty));
		}
	}
}
