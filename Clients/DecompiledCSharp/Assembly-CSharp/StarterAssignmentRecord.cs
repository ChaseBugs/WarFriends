using System;
using UnityEngine;

public class StarterAssignmentRecord : Core_BaseScript
{
	[Header("Common")]
	public UISprite background;

	public UISprite numberBackground;

	public UILabel number;

	public UILabel objective;

	public GameObject rightPart;

	[Header("Right Reward")]
	public GameObject rewardPart;

	public UITable rewardTable;

	public UISprite rewardIconGold;

	public UISprite rewardIconWB;

	public UILabel rewardValue;

	[Header("Right Claim")]
	public GameObject claimPart;

	public BoxCollider claimCollider;

	public UITable claimTable;

	public UILabel claimValue;

	public UISprite claimGoldSprite;

	public UISprite claimWBSprite;

	[Header("Animation")]
	public UISprite[] goldSprites;

	public UISprite[] wbSprites;

	public GameObject flash;

	[Header("Finish")]
	public UILabel allCompleted;

	private StarterAssignment mStarterAssignment;

	private bool mClaimAnimating;

	public bool isClaimAnimating => mClaimAnimating;

	public void InitControls(float width)
	{
		UIEventListener uIEventListener = UIEventListener.Get(claimCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, (UIEventListener.VoidDelegate)delegate
		{
			ClaimClicked();
		});
		background.transform.localScale = background.transform.localScale.ReplaceX(width - 120f);
		rightPart.transform.localPosition = rightPart.transform.localPosition.ReplaceX(width - 120f);
		allCompleted.transform.localPosition = allCompleted.transform.localPosition.ReplaceX(width / 2f - 60f);
		objective.lineWidth = MiscTools.RoundToInt(width - 800f);
		rewardTable.onReposition = delegate
		{
			float val = 0f - rewardTable.padding.x - (rewardValue.transform.parent.transform.localPosition.x - rewardTable.padding.x) / 2f;
			rewardTable.transform.localPosition = rewardTable.transform.localPosition.ReplaceX(val);
		};
		claimTable.onReposition = delegate
		{
			float val = 0f - claimTable.padding.x - (claimValue.transform.parent.transform.localPosition.x - claimTable.padding.x) / 2f;
			claimTable.transform.localPosition = claimTable.transform.localPosition.ReplaceX(val);
		};
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
			number.text = assignment.order.ToString();
			objective.text = assignment.textWithProgress;
			rewardValue.text = MiscTools.FormatAssignmentNumber(assignment.rewardGold + assignment.rewardWB);
			claimValue.text = MiscTools.FormatAssignmentNumber(assignment.rewardGold + assignment.rewardWB);
			rewardIconGold.gameObject.SetActive(assignment.rewardGold > 0);
			rewardIconWB.gameObject.SetActive(assignment.rewardWB > 0);
			claimGoldSprite.gameObject.SetActive(assignment.rewardGold > 0);
			claimWBSprite.gameObject.SetActive(assignment.rewardWB > 0);
			claimCollider.enabled = assignment.completed && !assignment.claimed;
			rewardPart.SetActive(!assignment.completed);
			if (rewardPart.activeSelf)
			{
				rewardTable.repositionNow = true;
				TweenAlpha.Begin(rewardPart, 0f, 1f);
			}
			claimPart.SetActive(assignment.completed && !assignment.claimed);
			if (claimPart.activeSelf)
			{
				claimTable.repositionNow = true;
				TweenAlpha.Begin(claimPart, 0f, 1f);
			}
			UISprite[] array = goldSprites;
			foreach (UISprite uISprite in array)
			{
				TweenAlpha.Begin(uISprite.gameObject, 0f, 0f);
				TweenPosition.Begin(uISprite.gameObject, 0f, uISprite.transform.localPosition);
				uISprite.transform.position = new Vector3(claimGoldSprite.transform.position.x, claimGoldSprite.transform.position.y, uISprite.transform.position.z);
			}
			UISprite[] array2 = wbSprites;
			foreach (UISprite uISprite2 in array2)
			{
				TweenAlpha.Begin(uISprite2.gameObject, 0f, 0f);
				TweenPosition.Begin(uISprite2.gameObject, 0f, uISprite2.transform.localPosition);
				uISprite2.transform.position = new Vector3(claimWBSprite.transform.position.x, claimWBSprite.transform.position.y, uISprite2.transform.position.z);
			}
			TweenAlpha.Begin(flash, 0f, 0f).onFinished = null;
		}
	}

	private void ShowContent(bool active)
	{
		if (!active)
		{
			number.text = string.Empty;
			objective.text = string.Empty;
		}
		allCompleted.gameObject.SetActive(!active);
		numberBackground.gameObject.SetActive(active);
		rightPart.gameObject.SetActive(active);
	}

	public void ClaimClicked()
	{
		mClaimAnimating = true;
		bool flag = mStarterAssignment.rewardGold > 0;
		claimCollider.enabled = false;
		mStarterAssignment.Claim();
		float duration = 0.2f;
		TweenAlpha.Begin(flash, 0f, 0f).onFinished = null;
		TweenAlpha.Begin(flash, duration, 0f).onFinished = delegate
		{
			FlashAnimation(5);
		};
		if (flag)
		{
			GoldSpritesMove(0f);
		}
		else
		{
			WbSpritesMove(0f);
		}
	}

	private void FlashAnimation(int interval)
	{
		if (interval >= 0)
		{
			if (interval == 3)
			{
				HideClaimPart();
			}
			if (interval == 0)
			{
				ChangeToNextOrEnd();
			}
			float alpha = ((interval % 2 != 1) ? 0f : 0.5f);
			TweenAlpha.Begin(flash, 0f, alpha).onFinished = null;
			TweenAlpha.Begin(flash, 0.05f, alpha).onFinished = delegate
			{
				FlashAnimation(interval - 1);
			};
		}
	}

	private void HideClaimPart()
	{
		TweenAlpha.Begin(claimPart, 0f, 0f);
		claimPart.SetActive(value: false);
	}

	private void ChangeToNextOrEnd()
	{
		StarterAssignment currentAssignment = StarterAssignmentsManager.instance.currentAssignment;
		Initialize(currentAssignment);
	}

	private void GoldSpritesMove(float delay)
	{
		Vector3 vector = claimGoldSprite.transform.position.ReplaceZ(goldSprites[0].transform.position.z);
		Vector3 endPosition = GuiElementSingle<MenuHeader>.instance.goldIcon.transform.position.ReplaceZ(goldSprites[0].transform.position.z);
		for (int i = 0; i < goldSprites.Length; i++)
		{
			TweenPosition.Begin(goldSprites[i].gameObject, 0f, vector, useLocal: false).onFinished = null;
			TweenAlpha.Begin(goldSprites[i].gameObject, 0f, 0f).onFinished = null;
			MoneySpriteAnimation(delay + (float)i * 0.05f, goldSprites[i].gameObject, vector, endPosition);
		}
	}

	private void WbSpritesMove(float delay)
	{
		Vector3 vector = claimWBSprite.transform.position.ReplaceZ(wbSprites[0].transform.position.z);
		Vector3 endPosition = GuiElementSingle<MenuHeader>.instance.warbucksIcon.transform.position.ReplaceZ(wbSprites[0].transform.position.z);
		for (int i = 0; i < wbSprites.Length; i++)
		{
			TweenPosition.Begin(wbSprites[i].gameObject, 0f, vector, useLocal: false).onFinished = null;
			TweenAlpha.Begin(wbSprites[i].gameObject, 0f, 0f).onFinished = null;
			MoneySpriteAnimation(delay + (float)i * 0.05f, wbSprites[i].gameObject, vector, endPosition);
		}
	}

	private void MoneySpriteAnimation(float delay, GameObject go, Vector3 startPosition, Vector3 endPosition)
	{
		TweenAlpha.Begin(go, delay, 0f).onFinished = delegate
		{
			TweenAlpha.Begin(go, 0f, 1f).onFinished = null;
			TweenPosition.Begin(go, 0.45f, startPosition, endPosition, useLocal: false).onFinished = delegate
			{
				TweenAlpha.Begin(go, 0f, 0f).onFinished = null;
				mClaimAnimating = false;
			};
		};
	}
}
