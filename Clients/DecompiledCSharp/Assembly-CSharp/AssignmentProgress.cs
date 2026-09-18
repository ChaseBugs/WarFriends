using System;
using UnityEngine;

public class AssignmentProgress : Core_BaseScript
{
	[Header("Core")]
	public UITable table;

	public UISprite[] claimedSprites;

	public Transform[] claimedParents;

	public UISprite dayCompleted;

	private Vector3 mClaimSpriteScale = new Vector3(1f, 1f, 1f);

	private Vector3 mBigClaimSpriteScale = new Vector3(3.5f, 3.5f, 1f);

	private Vector3 mCompletedSpriteScale = new Vector3(72f, 78f, 0f);

	private Vector3 mBigCompletedSpriteScale = new Vector3(252f, 273f, 0f);

	private Vector3 mBasicPosition = new Vector3(0f, 0f, 0f);

	private Vector3 mOffScreenPosition = new Vector3(-900f, 0f, 0f);

	public event Action AllClaimed;

	public void Initialize(bool firstClaimed, bool secondClaimed, bool thirdClaimed, bool showProgress)
	{
		table.repositionNow = true;
		if (claimedSprites.Length != 3)
		{
			UISprite[] array = claimedSprites;
			foreach (UISprite uISprite in array)
			{
				uISprite.color = Color.white;
			}
			dayCompleted.spriteName = AssignmentsManager.dayNotCompleted;
			return;
		}
		claimedSprites[0].color = ((!firstClaimed) ? Colours.grayMedium : Colours.goldAssignment);
		claimedSprites[1].color = ((!secondClaimed) ? Colours.grayMedium : Colours.goldAssignment);
		claimedSprites[2].color = ((!thirdClaimed) ? Colours.grayMedium : Colours.goldAssignment);
		TweenScale.Begin(claimedParents[0].gameObject, 0f, mClaimSpriteScale).onFinished = null;
		TweenScale.Begin(claimedParents[1].gameObject, 0f, mClaimSpriteScale).onFinished = null;
		TweenScale.Begin(claimedParents[2].gameObject, 0f, mClaimSpriteScale).onFinished = null;
		bool flag = firstClaimed && secondClaimed && thirdClaimed;
		dayCompleted.spriteName = ((!flag) ? AssignmentsManager.dayNotCompleted : AssignmentsManager.dayCompleted);
		TweenAlpha.Begin(dayCompleted.gameObject, 0f, 1f, 1f).onFinished = null;
		TweenScale.Begin(dayCompleted.gameObject, 0f, mCompletedSpriteScale).onFinished = null;
		TweenPosition.Begin(base.gameObject, 0f, mBasicPosition).onFinished = null;
		base.gameObject.SetActive(showProgress);
	}

	public void AnimateClaim(int number)
	{
		int num = Mathf.Clamp(number, 0, 2);
		float dur = 0.25f;
		dayCompleted.spriteName = AssignmentsManager.dayNotCompleted;
		claimedSprites[num].color = Colours.goldAssignment;
		TweenScale.Begin(claimedParents[num].gameObject, dur, mBigClaimSpriteScale, mClaimSpriteScale);
		if (!AssignmentsManager.instance.dailyAssignmentsClaimed)
		{
			return;
		}
		TweenAlpha.Begin(dayCompleted.gameObject, dur * 0.6f, 1f, 1f).onFinished = delegate
		{
			dayCompleted.spriteName = AssignmentsManager.dayCompleted;
			TweenScale.Begin(dayCompleted.gameObject, dur, mBigCompletedSpriteScale, mCompletedSpriteScale).onFinished = delegate
			{
				TweenPosition.Begin(base.gameObject, dur * 2f, mBasicPosition, mOffScreenPosition).onFinished = delegate
				{
					base.gameObject.SetActive(value: false);
				};
				TweenAlpha.Begin(dayCompleted.gameObject, dur * 1.2f, 1f, 1f).onFinished = delegate
				{
					if (this.AllClaimed != null)
					{
						this.AllClaimed();
					}
				};
			};
		};
	}
}
