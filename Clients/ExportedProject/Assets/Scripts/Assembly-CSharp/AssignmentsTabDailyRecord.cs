using System;
using UnityEngine;

public class AssignmentsTabDailyRecord : Core_BaseScript
{
	[Header("Core")]
	public int index = 1;

	public UILabel title;

	public UISprite icon;

	public UILabel description;

	[Header("Bottom")]
	public GameObject progressPart;

	public UISprite progressBar;

	public UILabel progressLabel;

	public GameObject claimButton;

	public BoxCollider buttonCollider;

	public GameObject donePart;

	[Header("-Reward")]
	public GameObject rewardPart;

	public UITable rewardTable;

	public UILabel rewardValue;

	private Assignment mAssignment;

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(claimButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, (UIEventListener.VoidDelegate)delegate
		{
			ClaimClicked();
		});
		rewardTable.onReposition = delegate
		{
			float val = 0f - rewardTable.padding.x - (rewardValue.transform.parent.transform.localPosition.x - rewardTable.padding.x) / 2f;
			rewardTable.transform.localPosition = rewardTable.transform.localPosition.ReplaceX(val);
		};
		title.text = Localization.LocalizeFormat("ID_DAILYASSIGNMENTX", index);
	}

	private void ClaimClicked()
	{
		buttonCollider.enabled = false;
		mAssignment.Claim();
		InvokeAfterRealTime(delegate
		{
			claimButton.SetActive(value: false);
			donePart.SetActive(value: true);
		}, 0.2f);
	}

	public void Initialize(Assignment assignment)
	{
		mAssignment = assignment;
		bool flag = assignment.currentState != Assignment.State.InProgress;
		icon.spriteName = assignment.assignmentPicture;
		icon.MakePixelPerfect();
		if (icon.transform.localScale.y > 156f)
		{
			float multiplier = 156f / icon.transform.localScale.y;
			icon.transform.localScale = icon.transform.localScale.MultiplyXY(multiplier);
		}
		description.text = ((!flag) ? assignment.blueDescription : assignment.goldDescription);
		progressBar.fillAmount = assignment.GetProgress();
		progressBar.spriteName = ((!flag) ? assignment.progressBarSpriteForProgress : AssignmentsManager.goldProgressBar);
		progressLabel.color = ((!flag) ? Color.white : Color.black);
		if (flag)
		{
			progressLabel.text = Localization.Localize("ID_COMPLETED");
		}
		else
		{
			string status = assignment.status;
			progressLabel.text = ((!string.IsNullOrEmpty(status)) ? status.Replace("(", string.Empty).Replace(")", string.Empty) : Localization.Localize("ID_INPROGRESS"));
		}
		rewardValue.text = MiscTools.FormatAssignmentNumber(assignment.GetReward());
		rewardTable.repositionNow = true;
		Assignment.State currentState = assignment.currentState;
		buttonCollider.enabled = currentState == Assignment.State.Finishing || currentState == Assignment.State.Done;
		progressPart.SetActive(currentState == Assignment.State.InProgress);
		claimButton.SetActive(currentState == Assignment.State.Done || currentState == Assignment.State.Finishing);
		donePart.SetActive(currentState == Assignment.State.Claimed);
	}
}
