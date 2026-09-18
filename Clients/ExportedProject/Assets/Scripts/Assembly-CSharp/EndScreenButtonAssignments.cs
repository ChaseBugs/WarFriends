using UnityEngine;

public class EndScreenButtonAssignments : EndScreenButton
{
	[Header("Additional")]
	public GameObject notification;

	public override void SetButtonHeight(bool smallHeight)
	{
		base.SetButtonHeight(smallHeight);
		notification.transform.localPosition = notification.transform.localPosition.ReplaceY((!smallHeight) ? 50f : 39f);
	}
}
