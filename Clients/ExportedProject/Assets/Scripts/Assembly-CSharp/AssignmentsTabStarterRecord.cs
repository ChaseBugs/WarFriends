using System;
using UnityEngine;

public class AssignmentsTabStarterRecord : Core_BaseScript
{
	[Header("Core")]
	public UILabel starterProgress;

	public UILabel number;

	public UISprite numberBackground;

	public UILabel objective;

	public UILabel allCompleted;

	[Header("Bottom")]
	public GameObject emptyPart;

	public GameObject claimButton;

	[Header("-Empty Reward")]
	public UITable rewardEmptyTable;

	public UISprite rewardEmptyIconGold;

	public UISprite rewardEmptyIconWB;

	public UILabel rewardEmptyValue;

	[Header("-Claim Reward")]
	public BoxCollider buttonCollider;

	public UITable rewardClaimTable;

	public UISprite rewardClaimIconGold;

	public UISprite rewardClaimIconWB;

	public UILabel rewardClaimValue;

	private StarterAssignment mStarterAssignment;

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(claimButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, (UIEventListener.VoidDelegate)delegate
		{
			ClaimClicked();
		});
		rewardEmptyTable.onReposition = delegate
		{
			float val = 0f - rewardEmptyTable.padding.x - (rewardEmptyValue.transform.parent.transform.localPosition.x - rewardEmptyTable.padding.x) / 2f;
			rewardEmptyTable.transform.localPosition = rewardEmptyTable.transform.localPosition.ReplaceX(val);
		};
		rewardClaimTable.onReposition = delegate
		{
			float val = 0f - rewardClaimTable.padding.x - (rewardClaimValue.transform.parent.transform.localPosition.x - rewardClaimTable.padding.x) / 2f;
			rewardClaimTable.transform.localPosition = rewardClaimTable.transform.localPosition.ReplaceX(val);
		};
	}

	public void ClaimClicked()
	{
		buttonCollider.enabled = false;
		mStarterAssignment.Claim();
		InvokeAfterRealTime(delegate
		{
			Initialize(StarterAssignmentsManager.instance.currentAssignment);
		}, 0.2f);
	}

	public void Initialize(StarterAssignment assignment)
	{
		mStarterAssignment = assignment;
		ShowContent(assignment != null);
		if (assignment != null)
		{
			if (SavingLastSelected.instance.data.lastViewedStarterAssignmentId < assignment.order)
			{
				Singleton<EventTrackingManager>.instance.RegisterViewStarterAssignmentTab(assignment);
				SavingLastSelected.instance.StarterAssignmentViewed(assignment);
			}
			StarterAssignment starterAssignment = StarterAssignmentsManager.instance.currentAssignment;
			if (starterAssignment == null && StarterAssignmentsManager.instance.assignmentsCount > 0)
			{
				starterAssignment = StarterAssignmentsManager.instance.assignments[StarterAssignmentsManager.instance.assignmentsCount - 1];
			}
			int num = ((starterAssignment != null) ? (starterAssignment.order - 1) : StarterAssignmentsManager.instance.assignmentsCount);
			starterProgress.text = Localization.LocalizeFormat("ID_STARTERASSIGNMENTX", num + 1, StarterAssignmentsManager.instance.assignmentsCount);
			number.text = assignment.order.ToString();
			objective.text = assignment.textWithProgress;
			rewardEmptyValue.text = MiscTools.FormatAssignmentNumber(assignment.rewardGold + assignment.rewardWB);
			rewardClaimValue.text = rewardEmptyValue.text;
			rewardEmptyIconGold.gameObject.SetActive(assignment.rewardGold > 0);
			rewardEmptyIconWB.gameObject.SetActive(assignment.rewardWB > 0);
			rewardClaimIconGold.gameObject.SetActive(rewardEmptyIconGold.gameObject.activeSelf);
			rewardClaimIconWB.gameObject.SetActive(rewardEmptyIconWB.gameObject.activeSelf);
			buttonCollider.enabled = assignment.completed && !assignment.claimed;
			emptyPart.SetActive(!assignment.completed);
			if (emptyPart.activeSelf)
			{
				rewardEmptyTable.repositionNow = true;
			}
			claimButton.SetActive(assignment.completed && !assignment.claimed);
			if (claimButton.activeSelf)
			{
				rewardClaimTable.repositionNow = true;
			}
		}
	}

	private void ShowContent(bool active)
	{
		if (!active)
		{
			number.text = string.Empty;
			objective.text = string.Empty;
			emptyPart.SetActive(value: false);
			claimButton.SetActive(value: false);
		}
		allCompleted.gameObject.SetActive(!active);
		numberBackground.gameObject.SetActive(active);
	}
}
