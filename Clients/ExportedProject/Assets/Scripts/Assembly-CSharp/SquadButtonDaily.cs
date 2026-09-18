using UnityEngine;

public class SquadButtonDaily : SquadButton
{
	[Header("Notification")]
	public GameObject notificationObject;

	public override void Initialize(string nameOfButton, float duration, bool toHighlight = false)
	{
		base.Initialize(nameOfButton, duration, toHighlight);
		notificationObject.transform.localPosition = new Vector3((mInsideWidth + mSpaceAround) / 2f - 10f, 44f, 0f);
	}

	public void ShowNotification(bool active)
	{
		notificationObject.SetActive(active);
	}
}
