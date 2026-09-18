using System;
using System.Collections;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class InstantBattleResultsDialog : GuiElementSingle<InstantBattleResultsDialog>, IGuiDialog
{
	[Header("Header")]
	public UILabel headerTitle;

	public UILabel rewardsTitle;

	public UISprite ornamentsL;

	public UISprite ornamentsR;

	[Header("-Buttons")]
	public UIButton backButton;

	public UIButton closeButton;

	public BoxCollider nextBattleCollider;

	[Header("Rewards")]
	public SetInstantBattleRewards reward1;

	public SetInstantBattleRewards reward2;

	public SetInstantBattleRewards reward3;

	[Header("Footer")]
	public UILabel message;

	[Header("Unlock")]
	public UILabel unlockPrice;

	public UISprite unlockGold;

	public UISprite unlockWaiting;

	public UISprite unlockBorder;

	public UILabel unlockTitle;

	[HideInInspector]
	public bool animationFinished;

	private int mNumberOfBattles;

	private int mGoldCost;

	private Vector3 mUnlockPriceScale;

	private Vector3 mUnlockGoldScale;

	private int mXpAmmount;

	private int mWbAmmount;

	private int mGdAmmount;

	private int mExtraWarbucks;

	private List<Card> mWarcards;

	private InstantBattleRewardType mThirdRewardType;

	private Dictionary<string, object> mResponse;

	private TweenAnimator mAnimator;

	private bool mClosing;

	public void ShowScreen()
	{
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InstantBattleResultsDialog>.instance, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(nextBattleCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NextBattleButtonClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(backButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener3 = UIEventListener.Get(closeButton.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		mUnlockPriceScale = unlockPrice.transform.localScale;
		mUnlockGoldScale = unlockGold.transform.localScale;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += OnErrorReceived;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataLoaded;
	}

	private void NextBattleButtonClick(GameObject go)
	{
		if (animationFinished)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InstantBattleConfirmDialog>.instance, 0f);
		}
	}

	private void CloseDialog(GameObject go)
	{
		if (base.isFullyShowed && animationFinished)
		{
			CloseAndChangeScreen();
		}
	}

	private void OnErrorReceived(DatabaseAction action)
	{
		if (isShowed && action == DatabaseAction.InstantBattle)
		{
			if (base.isFullyShowed)
			{
				CloseDialog(base.gameObject);
			}
			else
			{
				CloseAndChangeScreen();
			}
		}
	}

	public override void InitGUIValues()
	{
		mClosing = false;
		reward1.ResetValues();
		reward2.ResetValues();
		reward3.ResetValues();
		animationFinished = false;
		mNumberOfBattles = GuiScreenSingle<InstantBattleResultsScreen>.instance.instantBattles;
		if (mNumberOfBattles > 1)
		{
			headerTitle.text = Localization.LocalizeFormat("ID_XSKIRMISHESRESULT", mNumberOfBattles);
		}
		else
		{
			headerTitle.text = Localization.Localize("ID_SKIRMISHRESULT");
		}
		unlockWaiting.gameObject.SetActive(value: true);
		unlockPrice.transform.localScale = new Vector3(0.001f, 0.001f, 1f);
		unlockGold.transform.localScale = new Vector3(0.001f, 0.001f, 1f);
		nextBattleCollider.enabled = false;
		TweenColor.Begin(unlockBorder.gameObject, 0f, Colours.graySkirmish);
		reward1.InitializeWaiting();
		reward2.InitializeWaiting();
		reward3.InitializeWaiting();
		float num = rewardsTitle.transform.localScale.x * rewardsTitle.relativeSize.x;
		float val = (1320f - (num + 40f)) / 2f;
		Transform obj = ornamentsR.transform;
		Vector3 localScale = ornamentsL.transform.localScale.ReplaceX(val);
		ornamentsL.transform.localScale = localScale;
		obj.localScale = localScale;
		InvokeAfter(delegate
		{
			animationFinished = true;
		}, 5f);
		if (InstantBattleManager.instance.responseArrive)
		{
			ResponseParse();
		}
		mGoldCost = PlayerAnalytics.instance.data.GetInstantBattleCost();
		unlockPrice.text = MiscTools.FormatBigNumber(mGoldCost);
		unlockTitle.text = Localization.LocalizeFormat("ID_PLAYXMORESKIRMISHES", (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.InstantBattleMax).FLOATVALUE);
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		ClearVariables();
		if (mClosing)
		{
			GuiScreenSingle<InstantBattleResultsScreen>.instance.FlashScreen(null);
		}
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		if (mClosing)
		{
			GuiScreenSingle<InstantBattleResultsScreen>.instance.AfterDialogExit();
		}
	}

	private void ClearVariables()
	{
		mXpAmmount = 0;
		mWbAmmount = 0;
		mGdAmmount = 0;
		mThirdRewardType = InstantBattleRewardType.None;
		mResponse = null;
	}

	private void AnimateRewards()
	{
		AnimateUnlockCost();
		reward1.InitializeXP(mXpAmmount, mNumberOfBattles, (!LevelManager.instance.isLevelUp) ? LevelManager.instance.GetProgress() : 1f);
		InvokeAfter(delegate
		{
			reward2.InitializeWarbucks(mWbAmmount, mNumberOfBattles);
			TweenTextCounterLong.Begin(GuiElementSingle<MenuHeader>.instance.warBucksLabel.gameObject, 1f, new LongObject(Singleton<Wallet>.instance.warBucks - (mWbAmmount + mExtraWarbucks)), new LongObject(Singleton<Wallet>.instance.warBucks));
		}, 0.15f);
		InvokeAfter(delegate
		{
			switch (mThirdRewardType)
			{
			case InstantBattleRewardType.Gold:
				reward3.InitializeGold(mGdAmmount);
				TweenTextCounterLong.Begin(GuiElementSingle<MenuHeader>.instance.goldLabel.gameObject, 1f, new LongObject(Singleton<Wallet>.instance.gold - mGdAmmount), new LongObject(Singleton<Wallet>.instance.gold));
				break;
			case InstantBattleRewardType.WarCard:
				reward3.InitializeWarcard(mWarcards);
				break;
			case InstantBattleRewardType.Warbucks:
				reward3.InitializeWarbucks(mExtraWarbucks);
				break;
			default:
				reward3.InitializeNoReward();
				break;
			}
		}, 0.3f);
		if (LevelManager.instance.isLevelUp)
		{
			StartCoroutine(LevelUpProcedure());
		}
	}

	private IEnumerator LevelUpProcedure()
	{
		yield return new WaitForSeconds(0.45f);
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LevelUpDialog>.instance, 0f);
		yield return new WaitForSeconds(0.5f);
		while (GuiElementSingle<LevelUpDialog>.instance.isShowed)
		{
			yield return null;
		}
		TweenAlpha tw = TweenAlpha.Begin(GuiElementSingle<MenuHeader>.instance.progressSprite.gameObject, 0.2f, 0f, 1f);
		tw.style = UITweener.Style.PingPong;
		tw.NumOfRepetitions = 11;
		tw.onFinished = delegate
		{
			float duration = 1f;
			float num = LevelManager.instance.GetProgress();
			if (num > 1f)
			{
				num -= 1f;
			}
			GuiElementSingle<MenuHeader>.instance.UpdateLevel();
			TweenProgressBar.Begin(GuiElementSingle<MenuHeader>.instance.progressSpriteWhite.gameObject, duration, new FloatObject(0f), new FloatObject(num));
			TweenProgressBar.Begin(GuiElementSingle<MenuHeader>.instance.progressSprite.gameObject, duration, new FloatObject(0f), new FloatObject(num));
		};
	}

	private void CloseAndChangeScreen()
	{
		mClosing = true;
		HideDialog();
	}

	public void PlayAgain()
	{
		HideDialog();
		GuiScreenSingle<InstantBattleResultsScreen>.instance.ShowAgain();
	}

	private void AnimateUnlockCost()
	{
		unlockWaiting.gameObject.SetActive(value: false);
		nextBattleCollider.enabled = true;
		TweenColor.Begin(unlockBorder.gameObject, 0f, new Color(1f, 1f, 1f));
		TweenScale.Begin(unlockPrice.gameObject, 0.2f, mUnlockPriceScale.MultiplyXY(1.2f));
		TweenScale.Begin(unlockGold.gameObject, 0.2f, mUnlockGoldScale.MultiplyXY(1.2f)).onFinished = delegate
		{
			TweenScale.Begin(unlockPrice.gameObject, 0.2f, mUnlockPriceScale);
			TweenScale.Begin(unlockGold.gameObject, 0.2f, mUnlockGoldScale);
		};
	}

	public void OnDataLoaded(DatabaseAction action)
	{
		if (action == DatabaseAction.InstantBattle && GuiElementSingle<InstantBattleResultsDialog>.instance.isShowed && base.gameObject.activeInHierarchy)
		{
			ResponseParse();
		}
	}

	private void ResponseParse()
	{
		mGoldCost = InstantBattleManager.instance.goldCost;
		unlockPrice.text = MiscTools.FormatBigNumber(mGoldCost);
		mXpAmmount = InstantBattleManager.instance.mXpAmmount;
		mWbAmmount = InstantBattleManager.instance.mWbAmmount;
		mExtraWarbucks = InstantBattleManager.instance.mExtraWarbucks;
		mGdAmmount = InstantBattleManager.instance.mGdAmmount;
		mWarcards = InstantBattleManager.instance.mWarcards;
		mNumberOfBattles = InstantBattleManager.instance.mNumberOfBattles;
		mThirdRewardType = InstantBattleManager.instance.mThirdRewardType;
		InstantBattleManager.instance.responseArrive = false;
		AnimateRewards();
	}

	public override void OnBack()
	{
		if (base.isFullyShowed)
		{
			CloseDialog(backButton.gameObject);
		}
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}
}
