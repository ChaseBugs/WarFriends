using System;
using System.Collections.Generic;

public class NotificationManager : Singleton<NotificationManager>
{
	private bool mUnitDelivering;

	private int mUnitTimeOfDelivered;

	private bool mWeaponDelivering;

	private int mWeaponTimeOfDelivered;

	private bool mBuddyDepositCooldown;

	private bool mWithdrawCooldown;

	private bool mAnyWithdrawableWarcard;

	public event Action UnitDelivered;

	public event Action WeaponDelivered;

	public event Action CardpoolNotificationChanged;

	public event Action VisualWasShown;

	protected override void Start()
	{
		base.Start();
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += OnAfterPlayerDataLoaded;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataLoaded;
	}

	private void OnAfterPlayerDataLoaded()
	{
		UpdateUnitDelivery();
		UpdateWeaponDelivery();
		UpdateCardpoolNotifications();
	}

	private void OnDataLoaded(DatabaseAction action)
	{
		if (action != DatabaseAction.GetAllSquadMembers)
		{
			return;
		}
		List<DatabasePlayer> squadMembers = Singleton<ServerResultsCache>.instance.GetSquadMembers(GameLoginManager.currentPlayer.squadName);
		if (squadMembers != null)
		{
			for (int i = 0; i < squadMembers.Count; i++)
			{
				if (squadMembers[i].id != GameLoginManager.currentPlayer.id && squadMembers[i].depositedCardsDic != null && squadMembers[i].depositedCardsDic.Count > 0)
				{
					mAnyWithdrawableWarcard = true;
					return;
				}
			}
		}
		mAnyWithdrawableWarcard = false;
	}

	public void UpdateUnitDelivery()
	{
		mUnitDelivering = false;
		foreach (LevelBehaviour item in LevelManager.instance.unitsSortedByLevel)
		{
			if (item.upgradeSlots.unitState == UpgradeSlots.State.Delivering || item.upgradeSlots.unitState == UpgradeSlots.State.UnitDelivering)
			{
				mUnitDelivering = true;
				mUnitTimeOfDelivered = (int)item.upgradeSlots.endDeliveryTime;
			}
		}
	}

	public void UpdateWeaponDelivery()
	{
		mWeaponDelivering = false;
		foreach (WeaponLevelsSetup item in LevelManager.instance.weaponsSortedByLevel)
		{
			if (item.weaponState == WeaponLevelsSetup.State.Delivering || item.weaponState == WeaponLevelsSetup.State.WeaponDelivering)
			{
				mWeaponDelivering = true;
				mWeaponTimeOfDelivered = (int)item.endDeliveryTime;
			}
		}
	}

	public void UpdateCardpoolNotifications()
	{
		mBuddyDepositCooldown = CardManager.instance.nextBuddyDeposit > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		mWithdrawCooldown = CardManager.instance.nextWithdraw > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
	}

	public void ClientCardpoolNotifications()
	{
		if (this.CardpoolNotificationChanged != null)
		{
			this.CardpoolNotificationChanged();
		}
	}

	public void VisualWasShownFunction()
	{
		if (this.VisualWasShown != null)
		{
			this.VisualWasShown();
		}
	}

	protected void Update()
	{
		if (mUnitDelivering && Singleton<BeanstalkServerManager>.instance.currentTimestamp > mUnitTimeOfDelivered)
		{
			mUnitDelivering = false;
			if (this.UnitDelivered != null)
			{
				this.UnitDelivered();
			}
		}
		if (mWeaponDelivering && Singleton<BeanstalkServerManager>.instance.currentTimestamp > mWeaponTimeOfDelivered)
		{
			mWeaponDelivering = false;
			if (this.WeaponDelivered != null)
			{
				this.WeaponDelivered();
			}
		}
		if (mBuddyDepositCooldown && Singleton<BeanstalkServerManager>.instance.currentTimestamp > CardManager.instance.nextBuddyDeposit)
		{
			mBuddyDepositCooldown = false;
			if (this.CardpoolNotificationChanged != null)
			{
				this.CardpoolNotificationChanged();
			}
		}
		if (mWithdrawCooldown && Singleton<BeanstalkServerManager>.instance.currentTimestamp > CardManager.instance.nextWithdraw)
		{
			mWithdrawCooldown = false;
			if (this.CardpoolNotificationChanged != null)
			{
				this.CardpoolNotificationChanged();
			}
		}
	}

	public int GetNumberOfEndScreenNotifications()
	{
		int numberOfMenuNotifications = GetNumberOfMenuNotifications();
		int squadCardpoolNotifications = GetSquadCardpoolNotifications();
		return numberOfMenuNotifications + squadCardpoolNotifications;
	}

	public int GetNumberOfMenuNotifications()
	{
		int numberOfArmyNotifications = GetNumberOfArmyNotifications();
		int numberOfWeaponNotifications = GetNumberOfWeaponNotifications();
		int numberOfVisualNotifications = GetNumberOfVisualNotifications();
		int num = (NotificationWarpath() ? 1 : 0);
		int num2 = (NotificationWarcards() ? 1 : 0);
		return numberOfArmyNotifications + numberOfWeaponNotifications + numberOfVisualNotifications + num + num2;
	}

	public int GetNumberOfArmyNotifications()
	{
		int num = 0;
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			if (NotificationForArmyUnit(behaviour))
			{
				num++;
			}
		}
		return num;
	}

	public int GetNumberOfWeaponNotifications()
	{
		int num = 0;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			if (NotificationForWeapon(weaponLevelsSetup))
			{
				num++;
			}
		}
		return num;
	}

	public int GetNumberOfVisualNotifications()
	{
		int num = ((!PlayerAnalytics.instance.data.customizationShown) ? 1 : 0);
		foreach (PlayerVisualCategory playerVisualCategory in CamosManager.instance.playerVisualCategories)
		{
			foreach (PlayerVisual allVisual in playerVisualCategory.allVisuals)
			{
				if (NotificationForVisual(allVisual))
				{
					num++;
				}
			}
		}
		return num;
	}

	public bool NotificationWarcards()
	{
		return !LevelManager.instance.isWarcardsLocked && (CardCraftingManager.instance.isCardCrafted || (!PlayerAnalytics.instance.data.craftingShown && CardCraftingManager.instance.canAnyWarcardBeCrafted));
	}

	public bool NotificationWarpath()
	{
		return !LevelManager.instance.isWarpathLocked && !PlayerAnalytics.instance.data.warpathShown;
	}

	public int GetNumberOfAssignmentNotifications()
	{
		int num = 0;
		if (AssignmentsManager.instance.preparedAssignments != null)
		{
			foreach (Assignment preparedAssignment in AssignmentsManager.instance.preparedAssignments)
			{
				if (preparedAssignment != null && (preparedAssignment.currentState == Assignment.State.Finishing || preparedAssignment.currentState == Assignment.State.Done))
				{
					num++;
				}
			}
		}
		return num;
	}

	public bool NotificationStarterAssignments()
	{
		if (StarterAssignmentsManager.instance.currentAssignment != null)
		{
			StarterAssignmentsManager.instance.Evaluate();
		}
		return StarterAssignmentsManager.instance.isActiveAndNotCompleted && StarterAssignmentsManager.instance.currentAssignment != null && StarterAssignmentsManager.instance.currentAssignment.completed && !StarterAssignmentsManager.instance.currentAssignment.claimed;
	}

	public int GetSquadCardpoolNotifications()
	{
		if (string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) || LevelManager.instance.isWarcardsLocked)
		{
			return 0;
		}
		int num = 0;
		if (!PlayerAnalytics.instance.data.cardpoolShown)
		{
			num++;
		}
		if (mAnyWithdrawableWarcard && CardManager.instance.isWithdrawAvailable)
		{
			num++;
		}
		if (CardManager.instance.isBuddyDepositAvailable && !GameLoginManager.currentPlayer.IsDepositedBuddyCard())
		{
			num++;
		}
		return num;
	}

	public bool NotificationForArmyUnit(LevelBehaviour behaviour)
	{
		return behaviour.upgradeSlots.unitState == UpgradeSlots.State.Delivered || behaviour.upgradeSlots.unitState == UpgradeSlots.State.UnitDelivered || (behaviour.upgradeSlots.unitState == UpgradeSlots.State.NotBuyed && !behaviour.upgradeSlots.showed);
	}

	public bool NotificationForWeapon(WeaponLevelsSetup weaponSetup)
	{
		return weaponSetup.weaponState == WeaponLevelsSetup.State.Delivered || weaponSetup.weaponState == WeaponLevelsSetup.State.WeaponDelivered || (weaponSetup.weaponState == WeaponLevelsSetup.State.NotBuyed && weaponSetup.purchasableInShop && !weaponSetup.showed);
	}

	public bool NotificationForVisual(PlayerVisual visual)
	{
		return visual.purchasableInShop && visual.notificate;
	}

	public int GetNumberOfWeaponCategoryNotifications(WeaponCategory category)
	{
		int num = 0;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			if ((weaponLevelsSetup.weaponCategory & category) == weaponLevelsSetup.weaponCategory && NotificationForWeapon(weaponLevelsSetup))
			{
				num++;
			}
		}
		return num;
	}

	public int GetNumberOfVisualCategoryNotifications(PlayerVisualCategory category)
	{
		int num = 0;
		foreach (PlayerVisual allVisual in category.allVisuals)
		{
			if (NotificationForVisual(allVisual))
			{
				num++;
			}
		}
		return num;
	}

	public int ActiveUnitToChoose()
	{
		if (Singleton<GameController>.instance.isTutorial)
		{
			return 0;
		}
		int num = 0;
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			if (behaviour.upgradeSlots.bought && !behaviour.upgradeSlots.borrowed && !behaviour.upgradeSlots.wasEquipped)
			{
				num++;
			}
		}
		return num;
	}

	public LevelBehaviour ActiveUnitWithNotification()
	{
		if (Singleton<GameController>.instance.isTutorial)
		{
			return null;
		}
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			if (behaviour.upgradeSlots.bought && !behaviour.upgradeSlots.borrowed && !behaviour.upgradeSlots.wasEquipped)
			{
				return behaviour;
			}
		}
		return null;
	}

	public LevelBehaviour GetUnlockedUnitWithNotification()
	{
		foreach (LevelBehaviour item in LevelManager.instance.unitsSortedByLevel)
		{
			if (item.upgradeSlots.unitState == UpgradeSlots.State.NotBuyed && !item.upgradeSlots.showed)
			{
				return item;
			}
		}
		return null;
	}

	public WeaponLevelsSetup GetUnlockedWeaponWithNotification()
	{
		foreach (WeaponLevelsSetup item in LevelManager.instance.weaponsSortedByLevel)
		{
			if (item.weaponState == WeaponLevelsSetup.State.NotBuyed && item.purchasableInShop && !item.showed)
			{
				return item;
			}
		}
		return null;
	}

	public PlayerVisual GetUnlockedVisualWithNotification()
	{
		foreach (PlayerVisual item in CamosManager.instance.visualsSortedByLevel)
		{
			if (NotificationForVisual(item))
			{
				return item;
			}
		}
		return null;
	}
}
