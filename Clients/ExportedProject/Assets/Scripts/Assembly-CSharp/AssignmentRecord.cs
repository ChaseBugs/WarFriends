using System;
using UnityEngine;

public class AssignmentRecord : Core_BaseScript
{
	[Header("Common")]
	public UISprite picture;

	public UILabel title;

	public UISprite progress;

	[Header("Right Reward")]
	public GameObject rewardPart;

	public UILabel rewardValue;

	[Header("Right Claim")]
	public GameObject claimPart;

	public BoxCollider claimCollider;

	public UILabel claimValue;

	public UISprite claimGoldSprite;

	[Header("Right Claimed")]
	public GameObject claimedPart;

	public UISprite claimedSprite;

	[Header("Animation")]
	public UISprite[] goldSprites;

	public GameObject flash;

	[Header("Hint")]
	public GameObject hintPart;

	public BoxCollider buttonHint;

	public UISprite buttonBackground;

	public UIPanel dialogPart;

	public BoxCollider dialogHint;

	public UISprite dialogBackground;

	public UITable dialogTable;

	public UILabel dialogTitle;

	public UILabel dialogText;

	private Assignment mAssignment;

	private Vector3 mClaimedSpriteScale = new Vector3(72f, 59f, 1f);

	private Vector3 mSmallClaimedSpriteScale = new Vector3(58f, 47f, 1f);

	private Vector3 mBigClaimedSpriteScale = new Vector3(504f, 413f, 1f);

	private bool mAnimating;

	public bool isAnimatingClaim => mAnimating;

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(claimCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, (UIEventListener.VoidDelegate)delegate
		{
			ClaimClicked();
		});
		UIEventListener uIEventListener2 = UIEventListener.Get(buttonHint.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (hintPart.activeSelf)
			{
				SoundsManager.Instance.PlayButtonClickedSound();
				if (dialogPart.gameObject.activeSelf)
				{
					HideHint();
				}
				else
				{
					ShowHint();
				}
			}
		});
		UIEventListener uIEventListener3 = UIEventListener.Get(dialogHint.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, (UIEventListener.VoidDelegate)delegate
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			HideHint();
		});
		UITable uITable = dialogTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Combine(uITable.onReposition, (UITable.OnReposition)delegate
		{
			float val = 68f + dialogTitle.transform.localPosition.y + 52f;
			dialogBackground.transform.localScale = dialogBackground.transform.localScale.ReplaceY(val);
		});
	}

	internal void Init(Assignment assignment)
	{
		mAssignment = assignment;
		mAnimating = false;
		Assignment.State currentState = assignment.currentState;
		int reward = mAssignment.GetReward();
		rewardValue.text = MiscTools.FormatAssignmentNumber(reward);
		claimValue.text = MiscTools.FormatAssignmentNumber(reward);
		float startProgress = mAssignment.GetStartProgress();
		progress.fillAmount = startProgress;
		bool flag = currentState == Assignment.State.InProgress || currentState == Assignment.State.Finishing;
		title.text = $"{((!flag) ? mAssignment.goldDescription : mAssignment.blueDescription)} {((!flag) ? mAssignment.status : mAssignment.redStatus)}";
		hintPart.SetActive(assignment.hasHint);
		if (assignment.hasHint)
		{
			dialogText.text = assignment.hintText;
			dialogTable.repositionNow = true;
			dialogPart.gameObject.SetActive(value: false);
			buttonBackground.spriteName = MiscTools.infoButtonSprite;
			buttonBackground.MakePixelPerfect();
		}
		SetInitialLook(currentState, firstShow: true);
	}

	public void Initialize(Assignment assignment)
	{
		Init(assignment);
		UpdateAssignmentLook(firstShow: true);
		progress.fillAmount = mAssignment.GetEndProgress();
	}

	private void SetInitialLook(Assignment.State state, bool firstShow = false)
	{
		claimCollider.enabled = state == Assignment.State.Finishing || state == Assignment.State.Done;
		bool active;
		switch (state)
		{
			case Assignment.State.Finishing: active = firstShow; break;
			case Assignment.State.InProgress: active = true; break;
			default: active = false; break;
		}
		rewardPart.SetActive(active);
		if (rewardPart.activeSelf)
		{
			TweenAlpha.Begin(rewardPart, 0f, 1f);
		}
		bool active2;
		switch (state)
		{
			case Assignment.State.Finishing: active2 = !firstShow; break;
			case Assignment.State.Done: active2 = true; break;
			default: active2 = false; break;
		}
		claimPart.SetActive(active2);
		if (claimPart.activeSelf)
		{
			TweenAlpha.Begin(claimPart, 0f, 1f);
		}
		claimedPart.SetActive(state == Assignment.State.Claimed);
		if (claimedPart.activeSelf)
		{
			TweenAlpha.Begin(claimedPart, 0f, 1f);
			TweenScale.Begin(claimedSprite.gameObject, 0f, mClaimedSpriteScale);
		}
		UISprite[] array = goldSprites;
		foreach (UISprite uISprite in array)
		{
			TweenAlpha.Begin(uISprite.gameObject, 0f, 0f);
			TweenPosition.Begin(uISprite.gameObject, 0f, uISprite.transform.localPosition);
			uISprite.transform.position = claimGoldSprite.transform.position.ReplaceZ(uISprite.transform.position.z);
		}
		TweenAlpha.Begin(flash, 0f, 0f).onFinished = null;
	}

	public void UpdateAssignmentLook(bool firstShow)
	{
		if (mAssignment != null)
		{
			if (firstShow)
			{
				picture.spriteName = mAssignment.assignmentPicture;
				picture.MakePixelPerfect();
			}
			bool flag = mAssignment.currentState == Assignment.State.InProgress || (firstShow && mAssignment.currentState == Assignment.State.Finishing);
			progress.spriteName = ((!flag) ? AssignmentsManager.goldProgressBar : mAssignment.progressBarSpriteForProgress);
			SetInitialLook(mAssignment.currentState, firstShow);
		}
	}

	public void ChangeToCompleted()
	{
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.AssigmentBarCompleted);
		TweenAlpha.Begin(rewardPart, 0.2f, 0f).onFinished = delegate
		{
			rewardPart.SetActive(value: false);
			progress.spriteName = AssignmentsManager.goldProgressBar;
			title.text = $"{mAssignment.goldDescription} {mAssignment.status}";
			claimPart.SetActive(value: true);
			TweenAlpha.Begin(claimPart, 0f, 0f);
			TweenAlpha.Begin(claimPart, 0.2f, 1f);
		};
	}

	public void ClaimClicked()
	{
		if (mAssignment != null)
		{
			claimCollider.enabled = false;
			mAssignment.Claim();
			mAnimating = true;
			float num = 0.2f;
			TweenAlpha.Begin(flash, 0f, 0f).onFinished = null;
			TweenAlpha.Begin(flash, num, 0f).onFinished = delegate
			{
				FlashAnimation(5);
			};
			GoldSpritesMove(num);
		}
	}

	private void FlashAnimation(int interval)
	{
		if (interval >= 0)
		{
			if (interval == 3)
			{
				SwitchToClaimed();
			}
			if (interval == 0)
			{
				ClaimedSpriteScale();
			}
			float alpha = ((interval % 2 != 1) ? 0f : 0.5f);
			TweenAlpha.Begin(flash, 0f, alpha).onFinished = null;
			TweenAlpha.Begin(flash, 0.05f, alpha).onFinished = delegate
			{
				FlashAnimation(interval - 1);
			};
		}
	}

	private void SwitchToClaimed()
	{
		TweenAlpha.Begin(claimPart, 0f, 0f);
		claimPart.SetActive(value: false);
		claimedPart.SetActive(value: true);
		TweenAlpha.Begin(claimedPart, 0f, 1f);
	}

	private void ClaimedSpriteScale()
	{
		TweenScale.Begin(claimedSprite.gameObject, 0f, mBigClaimedSpriteScale).onFinished = null;
		TweenScale.Begin(claimedSprite.gameObject, 0.15f, mSmallClaimedSpriteScale).onFinished = delegate
		{
			TweenScale.Begin(claimedSprite.gameObject, 0.15f, mClaimedSpriteScale).onFinished = null;
		};
	}

	private void GoldSpritesMove(float delay)
	{
		Vector3 vector = claimGoldSprite.transform.position.ReplaceZ(goldSprites[0].transform.position.z);
		Vector3 endPosition = GuiElementSingle<MenuHeader>.instance.goldIcon.transform.position.ReplaceZ(goldSprites[0].transform.position.z);
		for (int i = 0; i < goldSprites.Length; i++)
		{
			TweenPosition.Begin(goldSprites[i].gameObject, 0f, vector, useLocal: false).onFinished = null;
			TweenAlpha.Begin(goldSprites[i].gameObject, 0f, 0f).onFinished = null;
			GoldSpriteAnimation(delay + (float)i * 0.05f, goldSprites[i].gameObject, vector, endPosition);
		}
	}

	private void GoldSpriteAnimation(float delay, GameObject go, Vector3 startPosition, Vector3 endPosition)
	{
		TweenAlpha.Begin(go, delay, 0f).onFinished = delegate
		{
			TweenAlpha.Begin(go, 0f, 1f).onFinished = null;
			TweenPosition.Begin(go, 0.45f, startPosition, endPosition, useLocal: false).onFinished = delegate
			{
				TweenAlpha.Begin(go, 0f, 0f).onFinished = null;
				mAnimating = false;
			};
		};
	}

	private void ShowHint()
	{
		buttonBackground.spriteName = MiscTools.closeButtonSprite;
		buttonBackground.MakePixelPerfect();
		dialogPart.gameObject.SetActive(value: true);
		dialogPart.alpha1 = 0.005f;
		TweenAlpha.Begin(dialogPart.gameObject, 0.4f, 1f).onFinished = null;
		dialogPart.transform.localPosition = new Vector3(0f, -200f, dialogPart.transform.localPosition.z);
		TweenPosition tweenPosition = TweenPosition.Begin(dialogPart.gameObject, 0.25f, new Vector3(0f, -220f, dialogPart.transform.localPosition.z), new Vector3(0f, -190f, dialogPart.transform.localPosition.z));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			TweenPosition tweenPosition2 = TweenPosition.Begin(dialogPart.gameObject, 0.15f, new Vector3(0f, -200f, dialogPart.transform.localPosition.z));
			tweenPosition2.method = UITweener.Method.EaseOut;
			tweenPosition2.onFinished = null;
		};
	}

	private void HideHint()
	{
		buttonBackground.spriteName = MiscTools.infoButtonSprite;
		buttonBackground.MakePixelPerfect();
		TweenAlpha.Begin(dialogPart.gameObject, 0.4f, 0f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(dialogPart.gameObject, 0.4f, new Vector3(0f, -180f, dialogPart.transform.localPosition.z));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			dialogPart.gameObject.SetActive(value: false);
		};
	}
}
