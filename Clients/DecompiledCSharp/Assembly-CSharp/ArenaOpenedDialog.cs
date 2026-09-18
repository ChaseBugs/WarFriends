using System;
using System.Collections.Generic;
using UnityEngine;

public class ArenaOpenedDialog : GuiElementSingle<ArenaOpenedDialog>, IGuiDialog
{
	[Header("Top")]
	public GameObject backButton;

	public UILabel title;

	public GameObject closeButton;

	[Header("Left")]
	public UILabel arenaTimeLabel;

	[Header("Middle")]
	public UISprite elitePartIcon;

	public UILabel elitePartsHint;

	[Header("Right")]
	public WararenaRewardRecord wararenaRewardRecordPrefab;

	public UIDraggablePanel rewardsDraggablePanel;

	public UIPooledGrid rewardGrid;

	[Header("Bottom")]
	public GameObject bottomButton;

	public UILabel bottomButtonLabel;

	private float mTimer;

	private List<WarArenaReward> mRewards;

	private LevelBehaviour mUnit;

	private bool mArenaHasNotStarted;

	public void ShowDialog()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public void ChangeUnit(LevelBehaviour unit)
	{
		mUnit = unit;
		SetUnitHint();
		if (isShowed)
		{
			Singleton<LootBoxCameraArena>.instance.DisplayModel(mUnit, isLootboxReward: false);
		}
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(backButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(closeButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CloseClick));
		UIEventListener uIEventListener3 = UIEventListener.Get(bottomButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(ArenaClick));
	}

	private void CloseClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void ArenaClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			if (WarArena.instance.isArenaTicketBought)
			{
				GuiScreenSingle<ArenaScreen>.instance.ShowWarArena(ArenaScreen.ArenaScreenMode.MainArena);
			}
			else
			{
				GuiScreenSingle<ArenaScreen>.instance.ShowWarArena(ArenaScreen.ArenaScreenMode.EnterArena);
			}
			HideDialog();
		}
	}

	public override void InitGUIValues()
	{
		mUnit = WarArena.instance.warArenaConfig.doubleDropUnit;
		mArenaHasNotStarted = WarArena.instance.warArenaConfig.isBeforeArenaStart;
		title.text = Localization.Localize((!mArenaHasNotStarted) ? "ID_ARENAISOPEN" : "ID_ARENAWILLOPENSOON");
		bottomButtonLabel.text = Localization.Localize((!mArenaHasNotStarted) ? "ID_TAKEMETHERE" : "ID_MOREINFO");
		SetUnitHint();
		mRewards = WarArena.instance.warArenaConfig.warArenaRewards;
		rewardGrid.MakeEmpty();
		rewardGrid.init(mRewards.Count, RewardInstantiate, RewardFree, rewardsDraggablePanel);
		rewardsDraggablePanel.AlignToPos(instant: true);
		float seconds = fadeInTime * 0.5f;
		InvokeAfter(delegate
		{
			Singleton<LootBoxCameraArena>.instance.DisplayModel(mUnit, isLootboxReward: false);
		}, seconds);
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		Singleton<LootBoxCameraArena>.instance.Hide();
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		UIDraggablePanel.panelDisabled = false;
		rewardGrid.MakeEmpty();
	}

	private void SetUnitHint()
	{
		elitePartsHint.text = ((!mUnit.upgradeSlots.upgradeSlotElite.isUnlocked) ? string.Empty : Localization.LocalizeFormat("ID_COLLECTXELITEPARTSANDUPGRADETOELITE", Colours.stringGreenArena, MiscTools.FormatBigNumber(mUnit.upgradeSlots.upgradeSlotElite.upgradePriceParts), mUnit.unitElitePartsName.ToUpper(), mUnit.unitName.ToUpper()));
		float val = (0f - elitePartsHint.relativeSize.x * elitePartsHint.transform.localScale.x) / 2f - 50f;
		elitePartIcon.transform.localPosition = elitePartIcon.transform.localPosition.ReplaceX(val);
	}

	private Transform RewardInstantiate(int index)
	{
		if (index >= 0 && index < mRewards.Count)
		{
			WararenaRewardRecord wararenaRewardRecord = Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(wararenaRewardRecordPrefab, rewardGrid.gameObject, $"Reward {index:D2}") as WararenaRewardRecord;
			if (wararenaRewardRecord != null)
			{
				wararenaRewardRecord.Initialize(mRewards[index], WararenaRewardRecord.ClickBehaviour.ChangeUnit);
				return wararenaRewardRecord.transform;
			}
		}
		return null;
	}

	private void RewardFree(Transform obj)
	{
		if (obj != null)
		{
			WararenaRewardRecord component = obj.GetComponent<WararenaRewardRecord>();
			if (component != null)
			{
				component.DestroyPooled();
			}
		}
	}

	protected override void Update()
	{
		base.Update();
		mTimer += Time.deltaTime;
		if (mTimer > 0.333f)
		{
			mTimer -= 0.333f;
			arenaTimeLabel.text = WarArenaGui.CreateArenaEventTimeTextLowerCase();
			if (mArenaHasNotStarted && !WarArena.instance.warArenaConfig.isBeforeArenaStart)
			{
				mArenaHasNotStarted = false;
				title.text = Localization.Localize("ID_ARENAISOPEN");
				bottomButtonLabel.text = Localization.Localize("ID_TAKEMETHERE");
			}
		}
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		CloseClick(backButton);
	}
}
