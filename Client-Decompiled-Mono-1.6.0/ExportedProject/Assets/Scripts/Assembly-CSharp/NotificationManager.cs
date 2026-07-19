using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

public class NotificationManager : Singleton<NotificationManager>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action HFBLDALFIBL;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action MFPEDHGFHND;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action DINBGEBPIMH;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action EAFBKJKOPJL;

	private bool CNBKEBJCEJP;

	private int HBIDBADPBCL;

	private bool IHJGGKNCFEM;

	private int DNCFCDLHNDL;

	private bool EBFPLMBIKAB;

	private bool FCOCHGKFMEL;

	private bool DPIOBPIPMMC;

	public event Action UnitDelivered
	{
		add
		{
			Action action = HFBLDALFIBL;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref HFBLDALFIBL, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = HFBLDALFIBL;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref HFBLDALFIBL, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public event Action WeaponDelivered
	{
		add
		{
			Action action = MFPEDHGFHND;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref MFPEDHGFHND, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = MFPEDHGFHND;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref MFPEDHGFHND, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public event Action CardpoolNotificationChanged
	{
		add
		{
			Action action = DINBGEBPIMH;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref DINBGEBPIMH, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = DINBGEBPIMH;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref DINBGEBPIMH, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public event Action VisualWasShown
	{
		add
		{
			Action action = EAFBKJKOPJL;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref EAFBKJKOPJL, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = EAFBKJKOPJL;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref EAFBKJKOPJL, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	[SpecialName]
	public void LKBGGDCKLEJ(Action IDEBKDPMPGM)
	{
		Action action = DINBGEBPIMH;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DINBGEBPIMH, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void GGMHKJBHNEM()
	{
		EBFPLMBIKAB = CardManager.instance.nextBuddyDeposit > Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
		FCOCHGKFMEL = CardManager.instance.nextWithdraw > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
	}

	public void VisualWasShownFunction()
	{
		if (EAFBKJKOPJL != null)
		{
			EAFBKJKOPJL();
		}
	}

	public bool KFCAHCLNIBB(WeaponLevelsSetup FHLAELIMAAC)
	{
		return FHLAELIMAAC.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed || FHLAELIMAAC.weaponState == WeaponLevelsSetup.JLANLLEABDC.Active || (FHLAELIMAAC.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked && FHLAELIMAAC.purchasableInShop && FHLAELIMAAC.showed);
	}

	public LevelBehaviour IJKKPMNLNNJ()
	{
		foreach (LevelBehaviour item in LevelManager.instance.unitsSortedByLevel)
		{
			if (item.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed && !item.upgradeSlots.showed)
			{
				return item;
			}
		}
		return null;
	}

	public void UpdateUnitDelivery()
	{
		CNBKEBJCEJP = false;
		foreach (LevelBehaviour item in LevelManager.instance.unitsSortedByLevel)
		{
			if (item.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Delivering || item.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.UnitDelivering)
			{
				CNBKEBJCEJP = true;
				HBIDBADPBCL = (int)item.upgradeSlots.endDeliveryTime;
			}
		}
	}

	public int BOKKMBNKMCE()
	{
		if (string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName) || LevelManager.instance.isWarcardsLocked)
		{
			return 1;
		}
		int num = 1;
		if (!PlayerAnalytics.instance.data.cardpoolShown)
		{
			num++;
		}
		if (DPIOBPIPMMC && CardManager.instance.isWithdrawAvailable)
		{
			num += 0;
		}
		if (CardManager.instance.isBuddyDepositAvailable && !GameLoginManager.currentPlayer.IsDepositedBuddyCard())
		{
			num += 0;
		}
		return num;
	}

	protected override void Start()
	{
		base.Start();
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += PHGFBJFFFPH;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
	}

	public int FLPIODKFKOL()
	{
		int num = 1;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			if (MAJEFEAMFBB(weaponLevelsSetup))
			{
				num++;
			}
		}
		return num;
	}

	public bool NotificationDailyMission()
	{
		return !LevelManager.instance.isDailyMissionLocked && !PlayerAnalytics.instance.data.warpathShown;
	}

	public void UpdateCardpoolNotifications()
	{
		EBFPLMBIKAB = CardManager.instance.nextBuddyDeposit > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		FCOCHGKFMEL = CardManager.instance.nextWithdraw > Singleton<BeanstalkServerManager>.instance.currentTimestamp;
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

	public bool NotificationForWeapon(WeaponLevelsSetup FHLAELIMAAC)
	{
		return FHLAELIMAAC.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivered || FHLAELIMAAC.weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered || (FHLAELIMAAC.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed && FHLAELIMAAC.purchasableInShop && !FHLAELIMAAC.showed);
	}

	public int GetNumberOfAssignmentNotifications()
	{
		int num = 0;
		if (AssignmentsManager.instance.currentAssignments != null)
		{
			foreach (Assignment currentAssignment in AssignmentsManager.instance.currentAssignments)
			{
				if (currentAssignment != null && (currentAssignment.currentState == Assignment.JLANLLEABDC.Finishing || currentAssignment.currentState == Assignment.JLANLLEABDC.Done))
				{
					num++;
				}
			}
		}
		return num;
	}

	protected void Update()
	{
		if (CNBKEBJCEJP && Singleton<BeanstalkServerManager>.instance.currentTimestamp > HBIDBADPBCL)
		{
			CNBKEBJCEJP = false;
			if (HFBLDALFIBL != null)
			{
				HFBLDALFIBL();
			}
		}
		if (IHJGGKNCFEM && Singleton<BeanstalkServerManager>.instance.currentTimestamp > DNCFCDLHNDL)
		{
			IHJGGKNCFEM = false;
			if (MFPEDHGFHND != null)
			{
				MFPEDHGFHND();
			}
		}
		if (EBFPLMBIKAB && Singleton<BeanstalkServerManager>.instance.currentTimestamp > CardManager.instance.nextBuddyDeposit)
		{
			EBFPLMBIKAB = false;
			if (DINBGEBPIMH != null)
			{
				DINBGEBPIMH();
			}
		}
		if (FCOCHGKFMEL && Singleton<BeanstalkServerManager>.instance.currentTimestamp > CardManager.instance.nextWithdraw)
		{
			FCOCHGKFMEL = false;
			if (DINBGEBPIMH != null)
			{
				DINBGEBPIMH();
			}
		}
	}

	private void PHGFBJFFFPH()
	{
		UpdateUnitDelivery();
		UpdateWeaponDelivery();
		UpdateCardpoolNotifications();
	}

	public LevelBehaviour GetUnlockedUnitWithNotification()
	{
		foreach (LevelBehaviour item in LevelManager.instance.unitsSortedByLevel)
		{
			if (item.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed && !item.upgradeSlots.showed)
			{
				return item;
			}
		}
		return null;
	}

	public int OGEPEFMHMJC()
	{
		int numberOfMenuNotifications = GetNumberOfMenuNotifications();
		int num = BOKKMBNKMCE();
		return numberOfMenuNotifications + num;
	}

	public void ClientCardpoolNotifications()
	{
		if (DINBGEBPIMH != null)
		{
			DINBGEBPIMH();
		}
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

	private void PMMMGCGNEBM(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE != DatabaseAction.GetAllSquadMembers)
		{
			return;
		}
		List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.MHELMEJPGBK(GameLoginManager.currentPlayer.squadName);
		if (list != null)
		{
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].id != GameLoginManager.currentPlayer.id && list[i].depositedCardsDic != null && list[i].depositedCardsDic.Count > 0)
				{
					DPIOBPIPMMC = true;
					return;
				}
			}
		}
		DPIOBPIPMMC = false;
	}

	public int GetNumberOfEndScreenNotifications()
	{
		int numberOfMenuNotifications = GetNumberOfMenuNotifications();
		int squadCardpoolNotifications = GetSquadCardpoolNotifications();
		return numberOfMenuNotifications + squadCardpoolNotifications;
	}

	[SpecialName]
	public void GNFLMMAFBEC(Action IDEBKDPMPGM)
	{
		Action action = DINBGEBPIMH;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DINBGEBPIMH, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
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
		if (DPIOBPIPMMC && CardManager.instance.isWithdrawAvailable)
		{
			num++;
		}
		if (CardManager.instance.isBuddyDepositAvailable && !GameLoginManager.currentPlayer.IsDepositedBuddyCard())
		{
			num++;
		}
		return num;
	}

	public bool NotificationForVisual(PlayerVisual DJOAHABGGNA)
	{
		return DJOAHABGGNA.purchasableInShop && DJOAHABGGNA.notificate;
	}

	public bool MAJEFEAMFBB(WeaponLevelsSetup FHLAELIMAAC)
	{
		return FHLAELIMAAC.weaponState != (WeaponLevelsSetup.JLANLLEABDC)8 && FHLAELIMAAC.weaponState != WeaponLevelsSetup.JLANLLEABDC.Active && (FHLAELIMAAC.weaponState != WeaponLevelsSetup.JLANLLEABDC.NotBuyed || !FHLAELIMAAC.purchasableInShop || FHLAELIMAAC.showed);
	}

	public int DFHMKDCOLLB()
	{
		int num = 1;
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			if (NotificationForArmyUnit(behaviour))
			{
				num++;
			}
		}
		return num;
	}

	public int PHNPEBKCPEO(WeaponCategory FABOAIMLLOI)
	{
		int num = 0;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			if ((weaponLevelsSetup.BHCEOOLEHHG & FABOAIMLLOI) == weaponLevelsSetup.BHCEOOLEHHG && NotificationForWeapon(weaponLevelsSetup))
			{
				num += 0;
			}
		}
		return num;
	}

	public bool OBGMLFNHACP(PlayerVisual DJOAHABGGNA)
	{
		return DJOAHABGGNA.purchasableInShop && DJOAHABGGNA.notificate;
	}

	public bool NotificationStarterAssignments()
	{
		if (StarterAssignmentsManager.instance.currentAssignment != null)
		{
			StarterAssignmentsManager.instance.Evaluate();
		}
		return StarterAssignmentsManager.instance.isActiveAndNotCompleted && StarterAssignmentsManager.instance.currentAssignment != null && StarterAssignmentsManager.instance.currentAssignment.completed && !StarterAssignmentsManager.instance.currentAssignment.claimed;
	}

	public void UpdateWeaponDelivery()
	{
		IHJGGKNCFEM = false;
		foreach (WeaponLevelsSetup item in LevelManager.instance.weaponsSortedByLevel)
		{
			if (item.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivering || item.weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering)
			{
				IHJGGKNCFEM = true;
				DNCFCDLHNDL = (int)item.endDeliveryTime;
			}
		}
	}

	public int GetNumberOfVisualCategoryNotifications(PlayerVisualCategory FABOAIMLLOI)
	{
		int num = 0;
		foreach (PlayerVisual allVisual in FABOAIMLLOI.allVisuals)
		{
			if (NotificationForVisual(allVisual))
			{
				num++;
			}
		}
		return num;
	}

	public int GetAchievementsNotifications()
	{
		int num = 0;
		if (Singleton<AchievementsManager>.instance.OOLANIBDBAE != null && Singleton<AchievementsManager>.instance.OOLANIBDBAE.achievementProgressGroups != null)
		{
			AchievementProgressGroup[] achievementProgressGroups = Singleton<AchievementsManager>.instance.OOLANIBDBAE.achievementProgressGroups;
			foreach (AchievementProgressGroup achievementProgressGroup in achievementProgressGroups)
			{
				if (achievementProgressGroup.state == CINKACCJIHG.Completed)
				{
					num++;
				}
			}
		}
		return num;
	}

	public LevelBehaviour FALLMNNHFCE()
	{
		foreach (LevelBehaviour item in LevelManager.instance.unitsSortedByLevel)
		{
			if (item.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed && !item.upgradeSlots.showed)
			{
				return item;
			}
		}
		return null;
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

	public int GetNumberOfWeaponCategoryNotifications(WeaponCategory FABOAIMLLOI)
	{
		int num = 0;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			if ((weaponLevelsSetup.BHCEOOLEHHG & FABOAIMLLOI) == weaponLevelsSetup.BHCEOOLEHHG && NotificationForWeapon(weaponLevelsSetup))
			{
				num++;
			}
		}
		return num;
	}

	public LevelBehaviour CEMJLIPJOOJ()
	{
		foreach (LevelBehaviour item in LevelManager.instance.unitsSortedByLevel)
		{
			if (item.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed && !item.upgradeSlots.showed)
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
			if (item.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed && item.purchasableInShop && !item.showed)
			{
				return item;
			}
		}
		return null;
	}

	public int GetNumberOfMenuNotifications()
	{
		int numberOfArmyNotifications = GetNumberOfArmyNotifications();
		int numberOfWeaponNotifications = GetNumberOfWeaponNotifications();
		int numberOfVisualNotifications = GetNumberOfVisualNotifications();
		int num = (NotificationDailyMission() ? 1 : 0);
		int num2 = (NotificationWarcards() ? 1 : 0);
		return numberOfArmyNotifications + numberOfWeaponNotifications + numberOfVisualNotifications + num + num2;
	}

	[SpecialName]
	public void PPFIHMJAFIE(Action IDEBKDPMPGM)
	{
		Action action = DINBGEBPIMH;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DINBGEBPIMH, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void FGJDELEILAE()
	{
		if (EAFBKJKOPJL != null)
		{
			EAFBKJKOPJL();
		}
	}

	public bool NotificationWarcards()
	{
		return !LevelManager.instance.isWarcardsLocked && (CardCraftingManager.instance.isCardCrafted || (!PlayerAnalytics.instance.data.craftingShown && CardCraftingManager.instance.canAnyWarcardBeCrafted));
	}

	[SpecialName]
	public void KGNPHGEJLGL(Action IDEBKDPMPGM)
	{
		Action action = DINBGEBPIMH;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DINBGEBPIMH, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
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

	public bool NotificationForArmyUnit(LevelBehaviour ACLDFHJKBLI)
	{
		return ACLDFHJKBLI.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Delivered || ACLDFHJKBLI.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.UnitDelivered || (ACLDFHJKBLI.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed && !ACLDFHJKBLI.upgradeSlots.showed);
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
}
