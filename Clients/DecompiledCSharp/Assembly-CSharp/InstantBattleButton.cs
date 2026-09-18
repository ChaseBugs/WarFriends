using System;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class InstantBattleButton : Core_BaseScript
{
	[Header("Core")]
	public BoxCollider instantBattleCollider;

	public UISprite instantBattleBorder;

	[Header("Locked")]
	public GameObject lockedPart;

	public UILabel lockedLabel;

	[Header("Normal Part")]
	public GameObject normalPart;

	public UISprite normalPartGlow;

	public UILabel instantBattleLabel;

	public UISprite[] instantBattleSprites;

	public UILabel countDownLabel;

	[Header("-Buy 5 Battles")]
	public GameObject goldPart;

	public UILabel goldBuyLabel;

	public UITable goldTable;

	public UILabel goldValue;

	private int mNextInstantBattle;

	private float mUpdateTime;

	private int mInstantBattleBattles;

	private int mGoldCost;

	public void InitControls()
	{
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += OnErrorReceived;
		UIEventListener uIEventListener = UIEventListener.Get(instantBattleCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(InstantBattleClick));
	}

	private void OnErrorReceived(DatabaseAction action)
	{
		if (action == DatabaseAction.InstantBattle)
		{
			mInstantBattleBattles = PlayerAnalytics.instance.data.GetInstantBattlesReady();
			mGoldCost = PlayerAnalytics.instance.data.GetInstantBattleCost();
		}
	}

	private void InstantBattleClick(GameObject go)
	{
		int num = ((mInstantBattleBattles == 0) ? mGoldCost : 0);
		List<Tuple<string, string>> parameters = new List<Tuple<string, string>>();
		if (num > 0)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InstantBattleConfirmDialog>.instance, 0f);
			return;
		}
		instantBattleCollider.enabled = false;
		Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.InstantBattle, parameters);
		if (mInstantBattleBattles == 0)
		{
			mInstantBattleBattles = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.InstantBattleMax).FLOATVALUE;
		}
		GuiScreenSingle<InstantBattleResultsScreen>.instance.instantBattles = mInstantBattleBattles;
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<InstantBattleResultsScreen>.instance);
	}

	public void InstantBattleButtonReposition()
	{
		float activeWidth = UIRoot.list[0].activeWidth;
		float num = activeWidth / 1920f;
		float num2 = (activeWidth - (940f + 420f * num + 440f * num + 60f)) / 3f;
		float num3 = (activeWidth - (940f + 876f * num + 60f)) / 2f;
		float num4 = ((LevelManager.instance.isWarArenaLocked || (!WarArena.instance.isReminderTime && !WarArena.instance.isOpened)) ? num3 : num2);
		base.transform.localPosition = base.transform.localPosition.ReplaceX(500f + num4 + 220f);
	}

	public void InitGuiValues()
	{
		bool isInstantBattleLocked = LevelManager.instance.isInstantBattleLocked;
		instantBattleCollider.enabled = !isInstantBattleLocked;
		instantBattleBorder.alpha = ((!isInstantBattleLocked) ? 1f : 0.5f);
		lockedPart.SetActive(isInstantBattleLocked);
		normalPart.SetActive(!isInstantBattleLocked);
		if (isInstantBattleLocked)
		{
			goldPart.SetActive(value: false);
			lockedLabel.text = Localization.LocalizeFormat("ID_UNLOCKEDATRANKX", LevelManager.instance.instantBattleUnlockLevel);
			MiscTools.SetUILabelRescale(lockedLabel, 30f, 20f, 280);
			return;
		}
		mInstantBattleBattles = PlayerAnalytics.instance.data.GetInstantBattlesReady();
		int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.InstantBattleMax).FLOATVALUE;
		bool flag = mInstantBattleBattles == 0;
		bool flag2 = mInstantBattleBattles == num;
		normalPartGlow.gameObject.SetActive(!flag);
		normalPart.transform.localPosition = normalPart.transform.localPosition.ReplaceY((!flag) ? 0f : 34f);
		instantBattleLabel.transform.localPosition = instantBattleLabel.transform.localPosition.ReplaceY((!flag) ? 33f : 16f);
		instantBattleLabel.text = string.Format("{0} {1}({2})[-]", Localization.Localize("ID_INSTANTBATTLE"), Colours.stringBlue, mInstantBattleBattles);
		MiscTools.SetUILabelRescale(instantBattleLabel, 52f, 20f, 380);
		for (int i = 0; i < instantBattleSprites.Length; i++)
		{
			instantBattleSprites[i].color = ((mInstantBattleBattles <= i) ? Colours.grayTime.ReplaceA(0.33f) : Colours.blue);
		}
		mNextInstantBattle = PlayerAnalytics.instance.data.GetTimestampOfNextInstantBattle();
		mUpdateTime = 0f;
		countDownLabel.color = ((!flag2) ? Colours.grayTime : Colours.blueDarkMax);
		if (flag2)
		{
			countDownLabel.text = Localization.Localize("ID_MAX");
		}
		goldPart.SetActive(flag);
		if (flag)
		{
			mGoldCost = PlayerAnalytics.instance.data.GetInstantBattleCost();
			goldBuyLabel.text = Localization.LocalizeFormat("ID_5SKIRMISHES", num);
			MiscTools.SetUILabelRescale(goldBuyLabel, 35f, 20f, 270);
			goldValue.text = MiscTools.FormatBigNumber(mGoldCost);
			goldTable.repositionNow = true;
		}
	}

	public void Update()
	{
		if (mNextInstantBattle <= 0)
		{
			return;
		}
		mUpdateTime += Time.deltaTime;
		if (mUpdateTime > 0.333f)
		{
			mUpdateTime = 0f;
			if (mNextInstantBattle > Singleton<BeanstalkServerManager>.instance.currentTimestamp)
			{
				countDownLabel.text = MiscTools.PrintableTime(mNextInstantBattle - Singleton<BeanstalkServerManager>.instance.currentTimestamp, "ID_READYTIME", string.Empty);
			}
			else
			{
				InitGuiValues();
			}
		}
	}
}
