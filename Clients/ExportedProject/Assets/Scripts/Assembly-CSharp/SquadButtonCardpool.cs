using UnityEngine;

public class SquadButtonCardpool : SquadButton
{
	[Header("Cardpool Notification")]
	public GameObject cardpoolNotification;

	public UILabel cardpoolNotificationNumber;

	public UIPanel cardpoolLockPanel;

	public UISprite cardpoolLockedIcon;

	public BoxCollider cardpoolCollider;

	private bool mIsLocked;

	protected float mAlphaBorderLockedMax = 0.1f;

	public override void Initialize(string nameOfButton, float duration, bool toHighlight = false)
	{
		base.Initialize(nameOfButton, duration, toHighlight);
		cardpoolNotification.transform.localPosition = new Vector3((mInsideWidth + mSpaceAround) / 2f - 10f, 44f, 0f);
	}

	public override TweenAlpha Animate(bool toHighlight)
	{
		if (mIsLocked)
		{
			TweenColor.Begin(buttonName.gameObject, mDuration, Colours.grayLockedCards);
			TweenAlpha.Begin(border.gameObject, mDuration, mAlphaBorderLockedMax);
			return TweenAlpha.Begin(highlight.gameObject, mDuration, 0f);
		}
		return base.Animate(toHighlight);
	}

	public override void InstantAnimate(bool toHighlight)
	{
		if (mIsLocked)
		{
			border.alpha = mAlphaBorderLockedMax;
			highlight.alpha = 0f;
			buttonName.color = Colours.grayLockedCards;
			UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(includeInactive: true);
			foreach (UITweener uITweener in componentsInChildren)
			{
				if (!(uITweener.gameObject == cardpoolLockPanel.gameObject))
				{
					uITweener.onFinished = null;
					uITweener.enabled = false;
				}
			}
		}
		else
		{
			base.InstantAnimate(toHighlight);
		}
	}

	public void SetNotifications(int notification)
	{
		cardpoolNotificationNumber.text = MiscTools.FormatBigNumber(notification);
		cardpoolNotification.SetActive(notification > 0);
	}

	public void SetLocked(bool isLocked)
	{
		mIsLocked = isLocked;
		cardpoolLockedIcon.gameObject.SetActive(mIsLocked);
		cardpoolCollider.enabled = !mIsLocked;
		if (mIsLocked)
		{
			InstantAnimate(toHighlight: false);
		}
	}
}
