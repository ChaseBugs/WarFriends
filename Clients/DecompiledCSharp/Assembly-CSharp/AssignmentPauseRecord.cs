using UnityEngine;

public class AssignmentPauseRecord : Core_BaseScript
{
	[Header("Core")]
	public UISprite icon;

	public UILabel title;

	public UISprite progressBar;

	[Header("-Reward")]
	public GameObject rewardPart;

	public UILabel rewardValue;

	[Header("-Done")]
	public GameObject donePart;

	public UILabel doneValue;

	[Header("-Claimed")]
	public GameObject claimedPart;

	internal void Initialize(Assignment assignment)
	{
		Assignment.State currentState = assignment.currentState;
		float progress = assignment.GetProgress();
		int reward = assignment.GetReward();
		icon.spriteName = assignment.assignmentPicture;
		icon.MakePixelPerfect();
		icon.transform.localScale = icon.transform.localScale.MultiplyXY(0.76f);
		title.text = $"{((currentState != Assignment.State.InProgress) ? assignment.goldDescription : assignment.blueDescription)} {assignment.status}";
		progressBar.spriteName = ((currentState != Assignment.State.InProgress) ? AssignmentsManager.goldProgressBar : assignment.progressBarSpriteForProgress);
		progressBar.fillAmount = progress;
		rewardPart.SetActive(currentState == Assignment.State.InProgress);
		donePart.SetActive(currentState == Assignment.State.Done || currentState == Assignment.State.Finishing);
		claimedPart.SetActive(currentState == Assignment.State.Claimed);
		rewardValue.text = MiscTools.FormatAssignmentNumber(reward);
		doneValue.text = MiscTools.FormatAssignmentNumber(reward);
	}
}
