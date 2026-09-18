using System.Collections;
using UnityEngine;

public class SquadButtonStarter : SquadButton
{
	[Header("Remaining Time")]
	public UILabel remainingTimeLabel;

	[Header("Notification")]
	public GameObject notificationObject;

	public UISprite warbucksIcon;

	public UISprite goldIcon;

	private bool mWorking;

	public override void Initialize(string nameOfButton, float duration, bool toHighlight = false)
	{
		base.Initialize(nameOfButton, duration, toHighlight);
		remainingTimeLabel.transform.localPosition = new Vector3((0f - mInsideWidth) / 2f, -45f, -1f);
		notificationObject.transform.localPosition = new Vector3((mInsideWidth + mSpaceAround) / 2f - 10f, 44f, 0f);
	}

	public void StartUpdate()
	{
		if (!mWorking)
		{
			mWorking = true;
			StartCoroutine(TimerWorker());
		}
	}

	public void StopUpdate()
	{
		if (mWorking)
		{
			mWorking = false;
			StopCoroutine(TimerWorker());
		}
	}

	public void ShowNotification(bool active, bool isGold)
	{
		notificationObject.SetActive(active);
		warbucksIcon.gameObject.SetActive(!isGold);
		goldIcon.gameObject.SetActive(isGold);
	}

	private IEnumerator TimerWorker()
	{
		while (mWorking)
		{
			if (StarterAssignmentsManager.instance.isActive)
			{
				if (StarterAssignmentsManager.instance.isAllCompleted)
				{
					remainingTimeLabel.text = Localization.Localize("ID_COMPLETED");
				}
				else
				{
					remainingTimeLabel.text = MiscTools.PrintableTime(StarterAssignmentsManager.instance.remainingTime, "ID_READYTIME", string.Empty);
				}
				yield return new WaitForRealSeconds(0.333f);
				continue;
			}
			remainingTimeLabel.text = Localization.Localize("ID_EXPIRED");
			break;
		}
	}
}
