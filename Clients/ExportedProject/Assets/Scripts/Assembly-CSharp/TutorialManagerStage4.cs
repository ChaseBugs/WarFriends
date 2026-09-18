using System.Collections;
using Beebyte.Obfuscator;
using Google2u;
using UnityEngine;

[Skip]
public class TutorialManagerStage4 : TutorialManagerBase
{
	public const string id = "Stage4";

	private static TutorialManagerStage4 mInstance;

	private WeaponLevelsSetup mWeaponToUpgrade;

	private int mGoldAdded;

	private int mWarbucksAdded;

	private bool mRewardShowable;

	private int mNumberOfGames;

	public static TutorialManagerStage4 instance
	{
		get
		{
			mInstance = mInstance ?? Object.FindObjectOfType<TutorialManagerStage4>();
			return mInstance;
		}
	}

	public bool wasFinished => data.started;

	public int numberOfGames
	{
		get
		{
			if (mNumberOfGames < 1)
			{
				mNumberOfGames = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.TutorialUpgradeWeaponAfterGames).FLOATVALUE;
			}
			return mNumberOfGames;
		}
	}

	private bool canRunTutorial => !LevelManager.instance.isLevelUp && !wasFinished && !TutorialManagerStage5.instance.isTutorialRunning;

	protected override void Awake()
	{
		base.Awake();
		mInstance = this;
		Singleton<BeanstalkServerManager>.instance.PlayerDataLoaded += delegate
		{
			mNumberOfGames = 0;
		};
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
			GuiElementSingle<TutorialDialog>.instance.ShowReward(Localization.Localize("ID_TUTORIAL_UPGRADEWEAPON_3"), Localization.Localize("ID_TUTORIAL_UPGRADEWEAPON_4"), mWarbucksAdded, mGoldAdded, 0.3f, TutorialDialog.DialogPosition.Right);
		}
	}

	public bool TryToStartWeaponUpgradeTutorial()
	{
		if (wasFinished)
		{
			return false;
		}
		if (StatsManager.instance.totalGames < numberOfGames)
		{
			return false;
		}
		if (StatsManager.instance.weaponsUpgrades > 0 || LevelManager.instance.DeliveringWeapon() != null)
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
		StartCoroutine(RadicalRoutine.Run(UpdateWeaponTutorial()));
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

	private WeaponLevelsSetup ChooseWeapon()
	{
		return LevelManager.instance.Weapon("Google2u.AssaultRifle_AK47");
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

	public IEnumerator UpdateWeaponTutorial()
	{
		StartTutorial(isContinue: false);
		Singleton<MessageManager>.instance.StopMessageCoroutine();
		mWeaponToUpgrade = ChooseWeapon();
		Singleton<EventTrackingManager>.instance.RegisterTutorialMenuTutorialEvent("401 START");
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
		GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_TUTORIAL_UPGRADEWEAPON_1"), Localization.Localize("ID_TUTORIAL_UPGRADEWEAPON_2"), 0.1f, TutorialDialog.DialogPosition.Right, useCollider: false);
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<MainScreen>.instance.nextButton.transform.position);
		GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<MainScreen>.instance.nextButton, showBlueOverlay: false);
		while (GuiScreenSingle<MainScreen>.instance.isShowed)
		{
			yield return null;
		}
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("402 MENU BATTLE SCREEN SHOWN");
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
		GuiElementSingle<TutorialDialog>.instance.Hide();
		GuiElementSingle<TutorialClickOverlay>.instance.Hide();
		mRewardShowable = false;
		Singleton<BeanstalkServerManager>.instance.AddOneTimeReward("WeaponTutorial", mWeaponToUpgrade.GetSheetName());
		Singleton<GuiManager>.instance.TurnOffInputCompletly();
		while (!GuiScreenSingle<BattlePreparationScreen>.instance.isFullyShowed)
		{
			yield return null;
		}
		while (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
		{
			yield return null;
		}
		GuiElementSingle<TutorialDialog>.instance.ShowReward(Localization.Localize("ID_TUTORIAL_UPGRADEWEAPON_3"), Localization.Localize("ID_TUTORIAL_UPGRADEWEAPON_4"), mWarbucksAdded, mGoldAdded, 0.3f, TutorialDialog.DialogPosition.Right);
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<BattlePreparationScreen>.instance.weaponButton.weaponButton.transform.position);
		GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<BattlePreparationScreen>.instance.weaponButton.weaponButton, showBlueOverlay: false);
		GuiScreenSingle<WeaponScreen>.instance.SelectWeapon(mWeaponToUpgrade);
		int categoryIndex = 0;
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
				mWarbucksAdded = ((!(mWeaponToUpgrade == null)) ? mWeaponToUpgrade.upgradeSlots.upgradePrice : 500);
				mGoldAdded = ((mWeaponToUpgrade == null) ? 1 : mWeaponToUpgrade.instantWeaponDeliveryPrice);
				GuiElementSingle<TutorialDialog>.instance.ShowReward(Localization.Localize("ID_TUTORIAL_UPGRADEWEAPON_3"), Localization.Localize("ID_TUTORIAL_UPGRADEWEAPON_4"), mWarbucksAdded, mGoldAdded, 0.3f, TutorialDialog.DialogPosition.Right);
			}
		}
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("403 MENU WEAPON SCREEN SHOWN");
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
		GuiElementSingle<TutorialDialog>.instance.Hide();
		GuiElementSingle<TutorialClickOverlay>.instance.Hide();
		Singleton<GuiManager>.instance.TurnOffInputCompletly();
		while (!GuiScreenSingle<WeaponScreen>.instance.isFullyShowed)
		{
			yield return null;
		}
		bool selectedWrongCategory = false;
		bool selectedWrongWeapon = false;
		if (GuiScreenSingle<WeaponScreen>.instance.selectedCategory != (GuiScreenSingle<WeaponScreen>.instance.selectedCategory & mWeaponToUpgrade.weaponCategory))
		{
			selectedWrongCategory = true;
			string topTextCategory = Localization.LocalizeFormat("ID_TUTORIAL_UPGRADEWEAPON_5", GuiScreenSingle<WeaponScreen>.instance.weaponCategoryButtons[categoryIndex].label.text);
			GuiElementSingle<TutorialDialog>.instance.ShowSpecial(topTextCategory, 0.25f);
			Vector3 pos = GuiScreenSingle<WeaponScreen>.instance.weaponCategoryButtons[categoryIndex].transform.position;
			Transform bg = GuiScreenSingle<WeaponScreen>.instance.weaponCategoryButtons[categoryIndex].background.transform;
			if (bg != null)
			{
				pos.x += bg.lossyScale.x * 0.5f;
			}
			GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(pos);
			GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(pos, bg.localScale, showBlueOverlay: false);
			while (GuiScreenSingle<WeaponScreen>.instance.selectedCategory != (GuiScreenSingle<WeaponScreen>.instance.selectedCategory & mWeaponToUpgrade.weaponCategory))
			{
				yield return null;
			}
			GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
			GuiElementSingle<TutorialDialog>.instance.Hide();
			GuiElementSingle<TutorialClickOverlay>.instance.Hide();
		}
		WeaponGuiRecord selectedWeapon = GuiScreenSingle<WeaponScreen>.instance.selectedIcon;
		if (selectedWeapon.weaponSetup.weaponDictionaryId != mWeaponToUpgrade.weaponDictionaryId)
		{
			selectedWrongWeapon = true;
			Singleton<GuiManager>.instance.TurnOffInputCompletly();
			yield return new WaitForSeconds(0.5f);
			GuiElementSingle<TutorialDialog>.instance.ShowSpecial("ID_TUTORIAL_UPGRADEWEAPON_6", 0.25f);
			WeaponGuiRecord weaponToSelect = null;
			Vector3 globalPos = Vector3.zero;
			Vector3 size = Vector3.one;
			foreach (WeaponGuiRecord weaponIcon in GuiScreenSingle<WeaponScreen>.instance.weaponIcons)
			{
				if (weaponIcon.weaponSetup.weaponDictionaryId == mWeaponToUpgrade.weaponDictionaryId)
				{
					weaponToSelect = weaponIcon;
					globalPos = weaponToSelect.transform.position;
					size = weaponToSelect.GetComponent<BoxCollider>().size;
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(globalPos);
					GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(globalPos, size, showBlueOverlay: false);
					break;
				}
			}
			while (selectedWeapon.weaponSetup.weaponDictionaryId != mWeaponToUpgrade.weaponDictionaryId)
			{
				if (weaponToSelect != null && weaponToSelect.transform.position != globalPos)
				{
					globalPos = weaponToSelect.transform.position;
					GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateTapAnimation(globalPos);
					GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(globalPos, size, showBlueOverlay: false);
				}
				yield return null;
				selectedWeapon = GuiScreenSingle<WeaponScreen>.instance.selectedIcon;
			}
			GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
			GuiElementSingle<TutorialDialog>.instance.Hide();
			GuiElementSingle<TutorialClickOverlay>.instance.Hide();
		}
		Singleton<EventTrackingManager>.instance.RegisterTutorialWeaponSelectedEvent("404 MENU WEAPON SCREEN SELECT WEAPON", selectedWrongCategory, selectedWrongWeapon);
		Singleton<GuiManager>.instance.TurnOffInputCompletly();
		yield return new WaitForSeconds(0.5f);
		GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_TUTORIAL_UPGRADEWEAPON_7"), Localization.LocalizeFormat("ID_TUTORIAL_TAPON", Localization.Localize("ID_UPGRADE")), 0.6f, TutorialDialog.DialogPosition.BottomRight, useCollider: false);
		Vector3 leftButtonGlobalPosition = GuiScreenSingle<WeaponScreen>.instance.weaponLeftContent.prizeLabel.cachedTransform.position;
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(leftButtonGlobalPosition, new Vector3(40f, -56f, 0f));
		GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<WeaponScreen>.instance.weaponLeftContent.leftButton, showBlueOverlay: false);
		while (selectedWeapon.weaponSetup.weaponState != WeaponLevelsSetup.State.Delivering)
		{
			yield return null;
		}
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("405 MENU WEAPON SCREEN BUY UPGRADE");
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
		GuiElementSingle<TutorialDialog>.instance.Hide();
		GuiElementSingle<TutorialClickOverlay>.instance.Hide();
		bool playerWaitedTillDeliveryEnds = false;
		Singleton<GuiManager>.instance.TurnOffInputCompletly();
		yield return new WaitForSeconds(1.1f);
		GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_TUTORIAL_UPGRADEWEAPON_8"), Localization.LocalizeFormat("ID_TUTORIAL_TAPON", Localization.Localize("ID_DELIVERNOW")), 0.6f, TutorialDialog.DialogPosition.BottomRight, useCollider: false);
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(leftButtonGlobalPosition, new Vector3(40f, -56f, 0f));
		GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<WeaponScreen>.instance.weaponLeftContent.leftButton, showBlueOverlay: false);
		bool canChange = true;
		while (selectedWeapon.weaponSetup.weaponState != WeaponLevelsSetup.State.Active)
		{
			if (canChange && selectedWeapon.weaponSetup.weaponState == WeaponLevelsSetup.State.Delivered)
			{
				playerWaitedTillDeliveryEnds = true;
				canChange = false;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide();
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				yield return new WaitForSeconds(1.1f);
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_TUTORIAL_UPGRADEWEAPON_9"), Localization.LocalizeFormat("ID_TUTORIAL_TAPON", Localization.Localize("ID_ACTIVATION")), 0.6f, TutorialDialog.DialogPosition.BottomRight, useCollider: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(leftButtonGlobalPosition, new Vector3(40f, -56f, 0f));
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<WeaponScreen>.instance.weaponLeftContent.leftButton, showBlueOverlay: false);
			}
			yield return false;
		}
		Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("406 MENU WEAPON SCREEN UPGRADE ACTIVATED", playerWaitedTillDeliveryEnds);
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
		GuiElementSingle<TutorialDialog>.instance.Hide();
		GuiElementSingle<TutorialClickOverlay>.instance.Hide();
		bool automaticEquip = true;
		if (PlayerInventory.instance.inventorySlots[categoryIndex].weaponLevelsSetup != selectedWeapon.weaponSetup)
		{
			automaticEquip = false;
			Singleton<GuiManager>.instance.TurnOffInputCompletly();
			yield return new WaitForSeconds(1.1f);
			GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_TUTORIAL_UPGRADEWEAPON_10"), Localization.LocalizeFormat("ID_TUTORIAL_TAPON", Localization.Localize("ID_GUI_EQUIP")), 0.6f, TutorialDialog.DialogPosition.BottomLeft, useCollider: false);
			GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<WeaponScreen>.instance.weaponRightContent.equipButton.transform.position);
			GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<WeaponScreen>.instance.weaponRightContent.equipButton, showBlueOverlay: false);
			while (PlayerInventory.instance.inventorySlots[categoryIndex].weaponLevelsSetup != selectedWeapon.weaponSetup)
			{
				yield return null;
			}
			GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
			GuiElementSingle<TutorialDialog>.instance.Hide();
			GuiElementSingle<TutorialClickOverlay>.instance.Hide();
		}
		Singleton<EventTrackingManager>.instance.RegisterTutorialWeaponEquippedEvent("407 MENU WEAPON SCREEN WEAPON EQUIPPED", automaticEquip);
		yield return new WaitForSeconds(2.8f);
		CleanUpAfterTutorial();
		FinishTutorial();
	}
}
