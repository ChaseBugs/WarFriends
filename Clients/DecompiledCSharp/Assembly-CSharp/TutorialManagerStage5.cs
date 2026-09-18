using System.Collections;
using Beebyte.Obfuscator;
using Google2u;
using UnityEngine;

[Skip]
public class TutorialManagerStage5 : TutorialManagerBase
{
	public const string id = "Stage5";

	private static TutorialManagerStage5 mInstance;

	private LevelBehaviour mUnitToUpgrade;

	private int mGoldAdded;

	private int mWarbucksAdded;

	private bool mRewardShowable;

	public static TutorialManagerStage5 instance
	{
		get
		{
			mInstance = mInstance ?? Object.FindObjectOfType<TutorialManagerStage5>();
			return mInstance;
		}
	}

	public bool wasFinished => data.started;

	public int numberOfGames => (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.TutorialUpgradeUnitAfterGames).FLOATVALUE;

	private bool canRunTutorial => !LevelManager.instance.isLevelUp && !wasFinished && !TutorialManagerStage4.instance.isTutorialRunning;

	protected override void Awake()
	{
		base.Awake();
		mInstance = this;
	}

	protected void OnApplicationPause(bool pause)
	{
		if (pause && base.isTutorialRunning)
		{
			StopTutorial();
		}
	}

	public void RewardCame(int wb, int gold)
	{
		mWarbucksAdded = wb;
		mGoldAdded = gold;
		if (mRewardShowable)
		{
			GuiElementSingle<TutorialDialog>.instance.ShowReward(Localization.Localize("ID_TUTORIAL_UPGRADEUNIT_3"), Localization.Localize("ID_TUTORIAL_UPGRADEUNIT_4"), mWarbucksAdded, mGoldAdded, 0f, TutorialDialog.DialogPosition.Right);
		}
	}

	public bool TryToStartUnitUpgradeTutorial()
	{
		if (wasFinished)
		{
			return false;
		}
		if (StatsManager.instance.totalGames < numberOfGames)
		{
			return false;
		}
		if (StatsManager.instance.unitsUpgrades > 0 || LevelManager.instance.DeliveringUnit() != null)
		{
			data.started = true;
			Save();
			return false;
		}
		if (!canRunTutorial)
		{
			return false;
		}
		RunTutorial();
		return true;
	}

	public void RunTutorial()
	{
		StopTutorial();
		Singleton<GuiManager>.instance.TurnOnInputCompletly();
		StartCoroutine(RadicalRoutine.Run(UpdateUnitTutorial()));
	}

	public override void StartTutorial(bool isContinue)
	{
		base.StartTutorial(isContinue);
		StartCoroutine(Singleton<AtlasPreparer>.instance.LoadTutorialCoroutine());
	}

	private void CleanUpAfterTutorial()
	{
		data.started = true;
		Save();
		Singleton<AtlasPreparer>.instance.UnloadTutorial();
	}

	private LevelBehaviour ChooseUnit()
	{
		return LevelManager.instance.Unit("Google2u.DBUpgradeSlotsAssaulter");
	}

	private void StopTutorial()
	{
		StopAllCoroutines();
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
		GuiElementSingle<TutorialClickOverlay>.instance.Hide();
		if (GuiElementSingle<TutorialDialog>.instance.isShowed)
		{
			GuiElementSingle<TutorialDialog>.instance.Hide();
		}
	}

	public IEnumerator UpdateUnitTutorial()
	{
		StartTutorial(isContinue: false);
		mUnitToUpgrade = ChooseUnit();
		Singleton<EventTrackingManager>.instance.RegisterTutorialMenuTutorialEvent("501 START");
		Singleton<MessageManager>.instance.StopMessageCoroutine();
		while (!GuiScreenSingle<EndScreen>.instance.isShowed)
		{
			yield return null;
		}
		while (GuiScreenSingle<EndScreen>.instance.isShowed)
		{
			yield return null;
		}
		if (Singleton<GuiManager>.instance.currentScreen != GuiScreenSingle<MainScreen>.instance)
		{
			yield break;
		}
		Singleton<GuiManager>.instance.TurnOffInputCompletly();
		while (!GuiScreenSingle<MainScreen>.instance.isFullyShowed)
		{
			yield return null;
		}
		GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
		GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_TUTORIAL_UPGRADEUNIT_3"), Localization.Localize("ID_TUTORIAL_UPGRADEUNIT_4"), 0.1f, TutorialDialog.DialogPosition.Right, useCollider: false);
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<MainScreen>.instance.nextButton.transform.position);
		GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<MainScreen>.instance.nextButton, showBlueOverlay: false);
		while (GuiScreenSingle<MainScreen>.instance.isShowed)
		{
			yield return null;
		}
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("502 MENU BATTLE SCREEN SHOWN");
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
		GuiElementSingle<TutorialDialog>.instance.Hide();
		GuiElementSingle<TutorialClickOverlay>.instance.Hide();
		mRewardShowable = false;
		Singleton<BeanstalkServerManager>.instance.AddOneTimeReward("UnitTutorial", mUnitToUpgrade.upgradeSlots.GetSheetName());
		while (!GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
		{
			yield return null;
		}
		Singleton<GuiManager>.instance.TurnOffInputCompletly();
		while (!GuiScreenSingle<BattlePreparationScreen>.instance.isFullyShowed)
		{
			yield return null;
		}
		while (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
		{
			yield return null;
		}
		GuiElementSingle<TutorialDialog>.instance.ShowReward(Localization.Localize("ID_TUTORIAL_UPGRADEUNIT_3"), Localization.Localize("ID_TUTORIAL_UPGRADEUNIT_4"), mWarbucksAdded, mGoldAdded, 0f, TutorialDialog.DialogPosition.Right);
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<BattlePreparationScreen>.instance.armyButton.armyButton.transform.position);
		GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<BattlePreparationScreen>.instance.armyButton.armyButton, showBlueOverlay: false);
		GuiScreenSingle<ArmyScreen>.instance.SelectUnit(mUnitToUpgrade);
		while (!GuiElementSingle<TutorialDialog>.instance.isFullyShowed)
		{
			yield return null;
		}
		mRewardShowable = true;
		float timeOut = 0f;
		while (GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
		{
			yield return null;
			timeOut += Time.deltaTime;
			if (timeOut > 20f)
			{
				mWarbucksAdded = ((!(mUnitToUpgrade == null)) ? mUnitToUpgrade.upgradeSlots.upgradeSlot.upgradePrice : 375);
				mGoldAdded = ((mUnitToUpgrade == null) ? 1 : mUnitToUpgrade.upgradeSlots.instantUnitDeliveryPrice);
				GuiElementSingle<TutorialDialog>.instance.ShowReward(Localization.Localize("ID_TUTORIAL_UPGRADEWEAPON_3"), Localization.Localize("ID_TUTORIAL_UPGRADEWEAPON_4"), mWarbucksAdded, mGoldAdded, 0f, TutorialDialog.DialogPosition.Right);
			}
		}
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("503 MENU ARMY SCREEN SHOWN");
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
		GuiElementSingle<TutorialDialog>.instance.Hide();
		GuiElementSingle<TutorialClickOverlay>.instance.Hide();
		Singleton<GuiManager>.instance.TurnOffInputCompletly();
		while (!GuiScreenSingle<ArmyScreen>.instance.isFullyShowed)
		{
			yield return null;
		}
		bool selectedWrongUnit = false;
		LevelBehaviour selected = GuiScreenSingle<ArmyScreen>.instance.selectedIcon.levelBehaviour;
		if (selected.unitDictionaryId != mUnitToUpgrade.unitDictionaryId)
		{
			selectedWrongUnit = true;
			yield return new WaitForSeconds(0.5f);
			GuiElementSingle<TutorialDialog>.instance.ShowSpecial("ID_TUTORIAL_UPGRADEUNIT_5", 0.25f);
			ArmyUpgradeIcon usedIcon = null;
			Vector3 globalPos = Vector3.zero;
			Vector3 size = Vector3.one;
			foreach (ArmyUpgradeIcon unitIcon in GuiScreenSingle<ArmyScreen>.instance.armyIcons)
			{
				if (unitIcon.levelBehaviour.unitDictionaryId == mUnitToUpgrade.unitDictionaryId)
				{
					usedIcon = unitIcon;
					globalPos = unitIcon.transform.position;
					size = unitIcon.GetComponent<BoxCollider>().size;
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(globalPos);
					GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(globalPos, size, showBlueOverlay: false);
					break;
				}
			}
			while (selected.unitDictionaryId != mUnitToUpgrade.unitDictionaryId)
			{
				if (usedIcon != null && usedIcon.transform.position != globalPos)
				{
					globalPos = usedIcon.transform.position;
					GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateTapAnimation(globalPos);
					GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(globalPos, size, showBlueOverlay: false);
				}
				yield return null;
				selected = GuiScreenSingle<ArmyScreen>.instance.selectedIcon.levelBehaviour;
			}
			GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
			GuiElementSingle<TutorialDialog>.instance.Hide();
			GuiElementSingle<TutorialClickOverlay>.instance.Hide();
		}
		Singleton<EventTrackingManager>.instance.RegisterTutorialUnitSelectedEvent("504 MENU ARMY SCREEN UNIT SELECTED", selectedWrongUnit);
		Singleton<GuiManager>.instance.TurnOffInputCompletly();
		yield return new WaitForSeconds(0.5f);
		GuiElementSingle<TutorialDialog>.instance.setDebug = true;
		GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_TUTORIAL_UPGRADEUNIT_6"), Localization.LocalizeFormat("ID_TUTORIAL_TAPON", Localization.Localize("ID_TRAIN")), 0.6f, TutorialDialog.DialogPosition.BottomRight, useCollider: false);
		Vector3 leftButtonGlobalPosition = GuiScreenSingle<ArmyScreen>.instance.armyLeftContent.leftButton.leftButtonUpgradePart.transform.position;
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(leftButtonGlobalPosition, new Vector3(40f, -56f, 0f));
		GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.armyLeftContent.leftButton.leftButtonUpgradePart, showBlueOverlay: false);
		while (!GuiScreenSingle<ArmyScreen>.instance.armyLeftContent.leftButton.powerDialog.upgradePart.activeSelf)
		{
			yield return null;
		}
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
		GuiElementSingle<TutorialClickOverlay>.instance.Hide();
		Singleton<GuiManager>.instance.TurnOffInputCompletly();
		yield return new WaitForSeconds(0.5f);
		Vector3 leftButtonUpgradeGlobalPosition = GuiScreenSingle<ArmyScreen>.instance.armyLeftContent.leftButton.powerDialog.unitButtonUpgradePrizeLabel.cachedTransform.position;
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(leftButtonUpgradeGlobalPosition, new Vector3(40f, -56f, 0f));
		GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.armyLeftContent.leftButton.powerDialog.unitButtonDeliverPart, showBlueOverlay: false);
		while (selected.upgradeSlots.unitState != UpgradeSlots.State.Delivering)
		{
			yield return null;
		}
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("505 MENU ARMY SCREEN BUY UPGRADE");
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
		GuiElementSingle<TutorialDialog>.instance.Hide();
		GuiElementSingle<TutorialDialog>.instance.setDebug = false;
		GuiElementSingle<TutorialClickOverlay>.instance.Hide();
		bool playerWaitedTillDeliveryEnds = false;
		Singleton<GuiManager>.instance.TurnOffInputCompletly();
		yield return new WaitForSeconds(1.1f);
		GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_TUTORIAL_UPGRADEUNIT_7"), Localization.LocalizeFormat("ID_TUTORIAL_TAPON", Localization.Localize("ID_DELIVERNOW")), 0.6f, TutorialDialog.DialogPosition.BottomRight, useCollider: false);
		Vector3 deliverNowButtonPosition = GuiScreenSingle<ArmyScreen>.instance.armyLeftContent.leftButton.powerDialog.unitButtonDeliverPart.transform.position;
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(deliverNowButtonPosition, new Vector3(40f, -56f, 0f));
		GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.armyLeftContent.leftButton.powerDialog.unitButtonDeliverPart, showBlueOverlay: false);
		bool canChange = true;
		while (selected.upgradeSlots.unitState == UpgradeSlots.State.Delivering || selected.upgradeSlots.unitState == UpgradeSlots.State.Delivered)
		{
			if (canChange && selected.upgradeSlots.unitState == UpgradeSlots.State.Delivered)
			{
				playerWaitedTillDeliveryEnds = true;
				canChange = false;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide();
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				yield return new WaitForSeconds(1.1f);
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_TUTORIAL_UPGRADEUNIT_8"), Localization.LocalizeFormat("ID_TUTORIAL_TAPON", Localization.Localize("ID_ACTIVATION")), 0.6f, TutorialDialog.DialogPosition.BottomRight, useCollider: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(deliverNowButtonPosition, new Vector3(40f, -56f, 0f));
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.armyLeftContent.leftButton.powerDialog.unitButtonDeliverPart, showBlueOverlay: false);
			}
			yield return false;
		}
		Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("506 MENU ARMY SCREEN UPGRADE ACTIVATED", playerWaitedTillDeliveryEnds);
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
		GuiElementSingle<TutorialDialog>.instance.Hide();
		GuiElementSingle<TutorialClickOverlay>.instance.Hide();
		yield return new WaitForSeconds(2.8f);
		CleanUpAfterTutorial();
		FinishTutorial();
	}
}
