using System;
using System.Collections;
using UnityEngine;

public class StarterAssignmentDialog : GuiElementSingle<StarterAssignmentDialog>, IGuiDialog
{
	[Header("Completition")]
	public UILabel timeToCompleteLabel;

	public StarterAssignmentComplete[] completedAssignments;

	[Header("Current Assignment")]
	public StarterAssignmentRecord currentAssignmentRecord;

	[Header("Rewards")]
	public UILabel rewardsTimeToEndLabel;

	[Header("Bottom")]
	public GameObject okButton;

	private RadicalRoutine mUpdate;

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(okButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OkClick));
		currentAssignmentRecord.InitControls(1868f);
		StarterAssignmentsManager.instance.AssignmentClaimed += AnimateLine;
	}

	private void OkClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
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

	public override void InitGUIValues()
	{
		StarterAssignmentsManager.instance.Evaluate();
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
		StartUpdate();
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		StopUpdate();
	}

	public void StartUpdate()
	{
		StopUpdate();
		mUpdate = RadicalRoutine.Create(AlternativeUpdate());
		StartCoroutine(RadicalRoutine.Run(mUpdate.enumerator));
	}

	private void StopUpdate()
	{
		if (mUpdate != null)
		{
			mUpdate.Cancel();
			mUpdate = null;
		}
	}

	private IEnumerator AlternativeUpdate()
	{
		bool keepUpdating = StarterAssignmentsManager.instance.isActive;
		while (isShowed && keepUpdating)
		{
			yield return new WaitForRealSeconds(0.333f);
			if (StarterAssignmentsManager.instance.isAllCompleted)
			{
				timeToCompleteLabel.text = Colours.stringWhite + Localization.Localize("ID_COMPLETED");
				rewardsTimeToEndLabel.text = Localization.Localize("ID_YOURREWARDS");
			}
			else
			{
				int starterAssignmentRemainingTime = Mathf.Max(StarterAssignmentsManager.instance.remainingTime, 0);
				if (starterAssignmentRemainingTime == 0)
				{
					timeToCompleteLabel.text = Localization.Localize("ID_EXPIRED");
					rewardsTimeToEndLabel.text = Localization.Localize("ID_STARTERASSIGNMENTSEXPIRED");
				}
				else
				{
					timeToCompleteLabel.text = string.Format("{0} {1}{2}", MiscTools.PrintableTime(starterAssignmentRemainingTime, "ID_READYTIME", string.Empty), Colours.stringWhite, Localization.Localize("ID_TOCOMPLETE"));
					rewardsTimeToEndLabel.text = Localization.LocalizeFormat("ID_COMPLETEALLTENSTARTERASSIGNMENTS", MiscTools.PrintableTime(starterAssignmentRemainingTime, "ID_READYTIME", string.Empty));
				}
			}
			keepUpdating = StarterAssignmentsManager.instance.isActive;
		}
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		OkClick(okButton.gameObject);
	}
}
