using System;
using UnityEngine;

public class ArenaNode : Core_BaseScript
{
	[SerializeField]
	private UISprite mCompleted;

	[SerializeField]
	private UISprite mReward;

	[SerializeField]
	private UISprite mCrown;

	[SerializeField]
	private UISprite mBorderAnimRight;

	[SerializeField]
	private UISprite mBorderAnimLeft;

	[SerializeField]
	private UISprite mOutline;

	[SerializeField]
	private UISprite mCompletedFill;

	[SerializeField]
	private BoxCollider mHint;

	private int lootboxIndex = -1;

	private bool mRewardBool;

	private Vector3 mOriginalCrownPosition = new Vector3(0f, 80f, -1f);

	private Vector3 mOriginalRewardScale = new Vector3(64f, 59f, 1f);

	private Vector3 mOriginalCompletedScale = new Vector3(77f, 90f, 1f);

	private Vector3 mOriginalBorderAnimScale = new Vector3(56f, 128f, 1f);

	protected override void Awake()
	{
		base.Awake();
		UIEventListener uIEventListener = UIEventListener.Get(mHint.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HintClicked));
	}

	private void HintClicked(GameObject go)
	{
		if (lootboxIndex >= 0)
		{
			GuiScreenSingle<ArenaScreen>.instance.mainContent.boxes[lootboxIndex].HintClicked(base.gameObject);
		}
	}

	public void SetCompletedOrReward(bool win, WarArenaConfig.LootBoxType type = WarArenaConfig.LootBoxType.None, WarArenaConfig.VisualType crownType = WarArenaConfig.VisualType.None, int index = -1)
	{
		lootboxIndex = index;
		mBorderAnimLeft.gameObject.SetActive(value: false);
		mBorderAnimRight.gameObject.SetActive(value: false);
		mOutline.gameObject.SetActive(value: false);
		mCompletedFill.gameObject.SetActive(value: false);
		mCompleted.gameObject.SetActive(win);
		mReward.gameObject.SetActive(!win);
		mCrown.gameObject.SetActive(value: true);
		mCrown.alpha = 1f;
		mHint.gameObject.SetActive(!win);
		mRewardBool = !win;
		switch (type)
		{
		case WarArenaConfig.LootBoxType.Bronze:
			mCrown.spriteName = "menu-crown-bronze";
			mReward.spriteName = "menu-arena-lootbox-bronze";
			break;
		case WarArenaConfig.LootBoxType.Silver:
			mCrown.spriteName = "menu-crown-silver";
			mReward.spriteName = "menu-arena-lootbox-silver";
			break;
		case WarArenaConfig.LootBoxType.Gold:
			mCrown.spriteName = "menu-crown-gold";
			mReward.spriteName = "menu-arena-lootbox-gold";
			break;
		}
		if (crownType == WarArenaConfig.VisualType.None)
		{
			mCrown.gameObject.SetActive(value: false);
		}
	}

	public void SetEmpty()
	{
		mCrown.gameObject.SetActive(value: false);
		mCompleted.gameObject.SetActive(value: false);
		mReward.gameObject.SetActive(value: false);
		lootboxIndex = -1;
	}

	public void AnimateNode()
	{
		if (mRewardBool)
		{
			TweenAlpha.Begin(mCrown.gameObject, 0.3f, 0f);
			TweenPosition.Begin(mCrown.gameObject, 0.4f, mCrown.transform.localPosition.ReplaceY(mOriginalCrownPosition.y + 100f)).onFinished = delegate
			{
				mCrown.transform.localPosition = mOriginalCrownPosition;
			};
			TweenScale tweenScale = TweenScale.Begin(mReward.gameObject, 0.15f, mReward.transform.localScale.MultiplyXY(3f));
			tweenScale.delay = 0.1f;
			tweenScale.onFinished = delegate
			{
				AnimateCompleted();
			};
		}
		else
		{
			AnimateCompleted();
		}
	}

	private void AnimateCompleted()
	{
		mCompleted.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
		mCompleted.transform.localScale = mOriginalCompletedScale;
		mCompleted.gameObject.SetActive(value: true);
		mCompletedFill.gameObject.SetActive(value: true);
		mCompletedFill.alpha = 0f;
		TweenScale.Begin(mCompleted.gameObject, 0.15f, mCompleted.transform.localScale.MultiplyXY(3f));
		TweenScale.Begin(mCompletedFill.gameObject, 0.15f, mCompleted.transform.localScale.MultiplyXY(3f));
		TweenRotation.Begin(mCompleted.gameObject, 0.15f, Quaternion.Euler(new Vector3(0f, 180f, 0f))).onFinished = delegate
		{
			mReward.transform.localScale = mOriginalRewardScale;
			mReward.gameObject.SetActive(value: false);
			TweenRotation.Begin(mCompleted.gameObject, 0.3f, Quaternion.Euler(new Vector3(0f, 360f, 0f))).onFinished = delegate
			{
				mCrown.alpha = 1f;
				mCompleted.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
				TweenScale.Begin(mCompletedFill.gameObject, 0.3f, mOriginalCompletedScale);
				TweenScale.Begin(mCompleted.gameObject, 0.3f, mOriginalCompletedScale).onFinished = delegate
				{
					SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.LeagueRewardShowed);
				};
				InvokeAfter(delegate
				{
					mBorderAnimLeft.gameObject.SetActive(value: true);
					mBorderAnimRight.gameObject.SetActive(value: true);
					mOutline.gameObject.SetActive(value: true);
					TweenAlpha.Begin(mBorderAnimLeft.gameObject, 0.7f, 0f);
					TweenAlpha.Begin(mBorderAnimRight.gameObject, 0.7f, 0f);
					TweenAlpha.Begin(mOutline.gameObject, 0.7f, 0.5f, 0f);
					TweenAlpha.Begin(mCompletedFill.gameObject, 0.25f, 0f, 1f).onFinished = delegate
					{
						TweenAlpha.Begin(mCompletedFill.gameObject, 0.4f, 0f).onFinished = delegate
						{
							mCompletedFill.gameObject.SetActive(value: false);
						};
					};
					TweenScale.Begin(mBorderAnimLeft.gameObject, 0.8f, mBorderAnimLeft.transform.localScale.MultiplyXY(2.5f)).onFinished = delegate
					{
						mBorderAnimLeft.transform.localScale = mOriginalBorderAnimScale;
						mBorderAnimLeft.alpha = 1f;
						mBorderAnimLeft.gameObject.SetActive(value: false);
					};
					TweenScale.Begin(mBorderAnimRight.gameObject, 0.8f, mBorderAnimRight.transform.localScale.MultiplyXY(2.5f)).onFinished = delegate
					{
						mBorderAnimRight.transform.localScale = mOriginalBorderAnimScale;
						mBorderAnimRight.alpha = 1f;
						mBorderAnimRight.gameObject.SetActive(value: false);
					};
					TweenScale.Begin(mOutline.gameObject, 0.8f, mOutline.transform.localScale.MultiplyXY(6f)).onFinished = delegate
					{
						mOutline.transform.localScale = mOriginalCompletedScale;
						mOutline.alpha = 0.5f;
						mOutline.gameObject.SetActive(value: false);
						mHint.gameObject.SetActive(value: false);
						if (WarArena.instance.warArenaConfig.nodes[(int)WarArena.instance.data.wins - 1].lootBoxType == WarArenaConfig.LootBoxType.None)
						{
							GuiScreenSingle<ArenaScreen>.instance.AfterAnimation();
						}
					};
				}, 0.2f);
			};
		};
	}
}
