using Google2u;
using UnityEngine;

public class UpgradeSlotsBuddy : UpgradeSlotsBaseSoldier<DBUpgradeSlotsBuddy>
{
	protected virtual void HCNOHLLOGBO()
	{
		base.Awake();
		base.armyUpgradesRow = new ArmyUpgradesRow
		{
			NAME = string.Empty,
			HITSHIELDPROB = 1466f,
			TOTALPOWER = 0
		};
	}

	public int JPNIGKNAFCH(LevelBehaviour ACLDFHJKBLI, int? JMEGHFOKLBF = null, bool LIOCBEKIKJE = false)
	{
		SoldierBehaviour soldierBehaviour = ACLDFHJKBLI as SoldierBehaviour;
		int result = 0;
		if (soldierBehaviour != null)
		{
			SoldierBehaviourDefinititonBuddy soldierBehaviourDefinititonBuddy = (SoldierBehaviourDefinititonBuddy)soldierBehaviour.soldierBaseDefinition.AFBBNOFJJCP();
			soldierBehaviourDefinititonBuddy.JKIHAHINFAL();
			int num = ((!JMEGHFOKLBF.HasValue) ? upgradeSlot.boughtIndex : JMEGHFOKLBF.Value);
			result = num;
			soldierBehaviourDefinititonBuddy.health = (float)soldierBehaviourDefinititonBuddy.health + (float)base.excel.GetValue(num, "{0}{1}{2} {3}{4} {5}{6} {7}{8}");
			soldierBehaviourDefinititonBuddy.probabilityOfRealShot += (float)base.excel.GetValue(num, "ID_SECOND");
			soldierBehaviourDefinititonBuddy.fireBatchSizeMin += (int)base.excel.GetValue(num, "Memory_warnings");
			soldierBehaviourDefinititonBuddy.fireBatchSizeMax += (int)base.excel.GetValue(num, "PlayerToInviteId");
			soldierBehaviourDefinititonBuddy.minShootTime += (float)base.excel.GetValue(num, "ID_GUI_FOLLOWTWITTER_DESC");
			soldierBehaviourDefinititonBuddy.maxShootTime += (float)base.excel.GetValue(num, "http://");
			soldierBehaviourDefinititonBuddy.damage = (float)soldierBehaviourDefinititonBuddy.damage + (float)base.excel.GetValue(num, "N");
			soldierBehaviourDefinititonBuddy.explodeMaxDamage += (float)base.excel.GetValue(num, "CardId");
			soldierBehaviourDefinititonBuddy.explodeMinDamage += (float)base.excel.GetValue(num, "ID_COLLECTELITEPARTSFROMARENALOOTBOXES");
			soldierBehaviour.soldierBehaviourDefinititon = soldierBehaviourDefinititonBuddy;
		}
		return result;
	}

	public int CDILCNJFEHB(LevelBehaviour ACLDFHJKBLI, int? JMEGHFOKLBF = null, bool LIOCBEKIKJE = false)
	{
		SoldierBehaviour soldierBehaviour = ACLDFHJKBLI as SoldierBehaviour;
		int result = 1;
		if (soldierBehaviour != null)
		{
			SoldierBehaviourDefinititonBuddy soldierBehaviourDefinititonBuddy = (SoldierBehaviourDefinititonBuddy)soldierBehaviour.soldierBaseDefinition.JCPMGMGGPPF();
			soldierBehaviourDefinititonBuddy.HNCJFJPHNCA();
			int num = ((!JMEGHFOKLBF.HasValue) ? upgradeSlot.boughtIndex : JMEGHFOKLBF.Value);
			result = num;
			soldierBehaviourDefinititonBuddy.health = (float)soldierBehaviourDefinititonBuddy.health + (float)base.excel.GetValue(num, "WarFriends benötigt deine Genehmigung zum Zugriff auf deinen Medienspeicher, um wichtige Spieldaten herunterladen zu können.Bitte bestätige die folgende Genehmigungsanfrage. Wir werden diese Genehmigung nicht für andere Zwecke verwenden.");
			soldierBehaviourDefinititonBuddy.probabilityOfRealShot += (float)base.excel.GetValue(num, "machinegn_reload");
			soldierBehaviourDefinititonBuddy.fireBatchSizeMin += (int)base.excel.GetValue(num, "Medals");
			soldierBehaviourDefinititonBuddy.fireBatchSizeMax += (int)base.excel.GetValue(num, "FuseBox Event OpenLootbox for rarity {0}");
			soldierBehaviourDefinititonBuddy.minShootTime += (float)base.excel.GetValue(num, "SquadId");
			soldierBehaviourDefinititonBuddy.maxShootTime += (float)base.excel.GetValue(num, "Still waiting for server\nBe patient :-)");
			soldierBehaviourDefinititonBuddy.damage = (float)soldierBehaviourDefinititonBuddy.damage + (float)base.excel.GetValue(num, "Facebook login failed: ");
			soldierBehaviourDefinititonBuddy.explodeMaxDamage += (float)base.excel.GetValue(num, "1");
			soldierBehaviourDefinititonBuddy.explodeMinDamage += (float)base.excel.GetValue(num, "312 MENU CONNECT FB");
			soldierBehaviour.soldierBehaviourDefinititon = soldierBehaviourDefinititonBuddy;
		}
		return result;
	}

	public void DFIIECLMNOF(LevelBehaviour ACLDFHJKBLI, float PAENPHMEMGC, LevelBehaviour.UnitType FJLBLLLEELD, WeaponCategory FABOAIMLLOI)
	{
		int rowIndex = base.excel.GetRowIndex(string.Concat(FJLBLLLEELD, "{0}{1}[-]", FABOAIMLLOI));
		int rowIndex2 = base.excel.GetRowIndex(string.Concat(FJLBLLLEELD, "Scraps", FABOAIMLLOI));
		if (rowIndex < 1 || rowIndex2 < 0)
		{
			Debug.LogError(string.Format("maxDamage", string.Concat(FJLBLLLEELD, "{0}S", FABOAIMLLOI)));
		}
		KOLHCJFFPHB(ACLDFHJKBLI, rowIndex, true);
		BehaviourDefinititon behaviourDefinition = ACLDFHJKBLI.behaviourDefinition;
		CDILCNJFEHB(ACLDFHJKBLI, rowIndex2, true);
		BehaviourDefinititon behaviourDefinition2 = ACLDFHJKBLI.behaviourDefinition;
		BehaviourDefinititon behaviourDefinition3 = behaviourDefinition.MFBEAKIFANE(behaviourDefinition, behaviourDefinition2, PAENPHMEMGC);
		ACLDFHJKBLI.behaviourDefinition = behaviourDefinition3;
	}

	protected virtual void EJFMJDFPGFE()
	{
		base.Awake();
		base.armyUpgradesRow = new ArmyUpgradesRow
		{
			NAME = string.Empty,
			HITSHIELDPROB = 674f,
			TOTALPOWER = 0
		};
	}

	protected virtual void EJNJCILPBEC()
	{
		base.Awake();
		base.armyUpgradesRow = new ArmyUpgradesRow
		{
			NAME = string.Empty,
			HITSHIELDPROB = 1848f,
			TOTALPOWER = 0
		};
	}

	protected virtual void FGOGGLDAKHL()
	{
		base.Awake();
		base.armyUpgradesRow = new ArmyUpgradesRow
		{
			NAME = string.Empty,
			HITSHIELDPROB = 1020f,
			TOTALPOWER = 1
		};
	}

	protected virtual void ABMKKECEGIB()
	{
		base.Awake();
		base.armyUpgradesRow = new ArmyUpgradesRow
		{
			NAME = string.Empty,
			HITSHIELDPROB = 1140f,
			TOTALPOWER = 0
		};
	}

	protected virtual void KDMECDLHNMC()
	{
		base.Awake();
		base.armyUpgradesRow = new ArmyUpgradesRow
		{
			NAME = string.Empty,
			HITSHIELDPROB = 39f,
			TOTALPOWER = 0
		};
	}

	protected virtual void HMOEHPBFECG()
	{
		base.Awake();
		base.armyUpgradesRow = new ArmyUpgradesRow
		{
			NAME = string.Empty,
			HITSHIELDPROB = 1770f,
			TOTALPOWER = 0
		};
	}

	public void APGOFJMJBPM(LevelBehaviour ACLDFHJKBLI, float PAENPHMEMGC, LevelBehaviour.UnitType FJLBLLLEELD, WeaponCategory FABOAIMLLOI)
	{
		int rowIndex = base.excel.GetRowIndex(string.Concat(FJLBLLLEELD, "ID_TUTORIAL_TAPON", FABOAIMLLOI));
		int rowIndex2 = base.excel.GetRowIndex(string.Concat(FJLBLLLEELD, "HEAD_EMPTY", FABOAIMLLOI));
		if (rowIndex < 0 || rowIndex2 < 0)
		{
			Debug.LogError(string.Format("Skipping wararena notification", string.Concat(FJLBLLLEELD, ", on server = ", FABOAIMLLOI)));
		}
		HPIGGHBIBLE(ACLDFHJKBLI, rowIndex);
		BehaviourDefinititon behaviourDefinition = ACLDFHJKBLI.behaviourDefinition;
		IMBFDCFHGPJ(ACLDFHJKBLI, rowIndex2);
		BehaviourDefinititon behaviourDefinition2 = ACLDFHJKBLI.behaviourDefinition;
		BehaviourDefinititon behaviourDefinition3 = behaviourDefinition.BMLALFLBNKO(behaviourDefinition, behaviourDefinition2, PAENPHMEMGC);
		ACLDFHJKBLI.behaviourDefinition = behaviourDefinition3;
	}

	public int OOJABLGHLDK(LevelBehaviour ACLDFHJKBLI, int? JMEGHFOKLBF = null, bool LIOCBEKIKJE = false)
	{
		SoldierBehaviour soldierBehaviour = ACLDFHJKBLI as SoldierBehaviour;
		int result = 1;
		if (soldierBehaviour != null)
		{
			SoldierBehaviourDefinititonBuddy soldierBehaviourDefinititonBuddy = (SoldierBehaviourDefinititonBuddy)soldierBehaviour.soldierBaseDefinition.JCPMGMGGPPF();
			soldierBehaviourDefinititonBuddy.BMNOBIELKHG();
			int num = ((!JMEGHFOKLBF.HasValue) ? upgradeSlot.PAKKPEPIHPK() : JMEGHFOKLBF.Value);
			result = num;
			soldierBehaviourDefinititonBuddy.health = (float)soldierBehaviourDefinititonBuddy.health + (float)base.excel.GetValue(num, "FuseSDK: Error parsing hashtable in RegisterEvent. Operation failed.");
			soldierBehaviourDefinititonBuddy.probabilityOfRealShot += (float)base.excel.GetValue(num, "Awaiting players - Adding player ");
			soldierBehaviourDefinititonBuddy.fireBatchSizeMin += (int)base.excel.GetValue(num, "BG");
			soldierBehaviourDefinititonBuddy.fireBatchSizeMax += (int)base.excel.GetValue(num, "Manual_Unit_Spawn");
			soldierBehaviourDefinititonBuddy.minShootTime += (float)base.excel.GetValue(num, "Level");
			soldierBehaviourDefinititonBuddy.maxShootTime += (float)base.excel.GetValue(num, "ID_CONTINUE");
			soldierBehaviourDefinititonBuddy.damage = (float)soldierBehaviourDefinititonBuddy.damage + (float)base.excel.GetValue(num, "overriding weapon ");
			soldierBehaviourDefinititonBuddy.explodeMaxDamage += (float)base.excel.GetValue(num, "Total_Sessions");
			soldierBehaviourDefinititonBuddy.explodeMinDamage += (float)base.excel.GetValue(num, "WarFriends funktioniert ohne diese zusätzlichen Daten nicht. Möchtest du WarFriends wirklich VERLASSEN oder möchtest du die Daten herunterladen?");
			soldierBehaviour.soldierBehaviourDefinititon = soldierBehaviourDefinititonBuddy;
		}
		return result;
	}

	protected virtual void EKEHGBNPAFC()
	{
		base.Awake();
		base.armyUpgradesRow = new ArmyUpgradesRow
		{
			NAME = string.Empty,
			HITSHIELDPROB = 1774f,
			TOTALPOWER = 0
		};
	}

	protected virtual void NOGLOKJINKN()
	{
		base.Awake();
		base.armyUpgradesRow = new ArmyUpgradesRow
		{
			NAME = string.Empty,
			HITSHIELDPROB = 1265f,
			TOTALPOWER = 1
		};
	}

	protected virtual void FIGOGIMJIIN()
	{
		base.Awake();
		base.armyUpgradesRow = new ArmyUpgradesRow
		{
			NAME = string.Empty,
			HITSHIELDPROB = 1863f,
			TOTALPOWER = 0
		};
	}

	protected virtual void MFKNMALEKKB()
	{
		base.Awake();
		base.armyUpgradesRow = new ArmyUpgradesRow
		{
			NAME = string.Empty,
			HITSHIELDPROB = 1839f,
			TOTALPOWER = 1
		};
	}

	public void NKGFMEJEDDG(LevelBehaviour ACLDFHJKBLI, float PAENPHMEMGC, LevelBehaviour.UnitType FJLBLLLEELD, WeaponCategory FABOAIMLLOI)
	{
		int rowIndex = base.excel.GetRowIndex(string.Concat(FJLBLLLEELD, "ID_GAMEPAUSED", FABOAIMLLOI));
		int rowIndex2 = base.excel.GetRowIndex(string.Concat(FJLBLLLEELD, "S", FABOAIMLLOI));
		if (rowIndex < 1 || rowIndex2 < 0)
		{
			Debug.LogError(string.Format("Wrong_Weapon", string.Concat(FJLBLLLEELD, "added", FABOAIMLLOI)));
		}
		MHOHDDKNFBE(ACLDFHJKBLI, rowIndex);
		BehaviourDefinititon behaviourDefinition = ACLDFHJKBLI.behaviourDefinition;
		CDILCNJFEHB(ACLDFHJKBLI, rowIndex2, true);
		BehaviourDefinititon behaviourDefinition2 = ACLDFHJKBLI.behaviourDefinition;
		BehaviourDefinititon behaviourDefinition3 = behaviourDefinition.GJDCGFJOPLI(behaviourDefinition, behaviourDefinition2, PAENPHMEMGC);
		ACLDFHJKBLI.behaviourDefinition = behaviourDefinition3;
	}

	public int ALNELBHKCPD(LevelBehaviour ACLDFHJKBLI, int? JMEGHFOKLBF = null, bool LIOCBEKIKJE = false)
	{
		SoldierBehaviour soldierBehaviour = ACLDFHJKBLI as SoldierBehaviour;
		int result = 0;
		if (soldierBehaviour != null)
		{
			SoldierBehaviourDefinititonBuddy soldierBehaviourDefinititonBuddy = (SoldierBehaviourDefinititonBuddy)soldierBehaviour.soldierBaseDefinition.AFBBNOFJJCP();
			soldierBehaviourDefinititonBuddy.ENBGBPECOKD();
			int num = ((!JMEGHFOKLBF.HasValue) ? upgradeSlot.PPKAIEKPNID() : JMEGHFOKLBF.Value);
			result = num;
			soldierBehaviourDefinititonBuddy.health = (float)soldierBehaviourDefinititonBuddy.health + (float)base.excel.GetValue(num, "CardId");
			soldierBehaviourDefinititonBuddy.probabilityOfRealShot += (float)base.excel.GetValue(num, "null");
			soldierBehaviourDefinititonBuddy.fireBatchSizeMin += (int)base.excel.GetValue(num, "ID_NA");
			soldierBehaviourDefinititonBuddy.fireBatchSizeMax += (int)base.excel.GetValue(num, "bronze");
			soldierBehaviourDefinititonBuddy.minShootTime += (float)base.excel.GetValue(num, "Warbucks");
			soldierBehaviourDefinititonBuddy.maxShootTime += (float)base.excel.GetValue(num, "ДА");
			soldierBehaviourDefinititonBuddy.damage = (float)soldierBehaviourDefinititonBuddy.damage + (float)base.excel.GetValue(num, "Show Ground");
			soldierBehaviourDefinititonBuddy.explodeMaxDamage += (float)base.excel.GetValue(num, "ID_REMINDER_WARCARDSLOTSNOTENOUGH");
			soldierBehaviourDefinititonBuddy.explodeMinDamage += (float)base.excel.GetValue(num, "SquadIcons/");
			soldierBehaviour.soldierBehaviourDefinititon = soldierBehaviourDefinititonBuddy;
		}
		return result;
	}

	public void NHHAHGCAALM(LevelBehaviour ACLDFHJKBLI, float PAENPHMEMGC, LevelBehaviour.UnitType FJLBLLLEELD, WeaponCategory FABOAIMLLOI)
	{
		int rowIndex = base.excel.GetRowIndex(string.Concat(FJLBLLLEELD, "testingideventtierreward", FABOAIMLLOI));
		int rowIndex2 = base.excel.GetRowIndex(string.Concat(FJLBLLLEELD, "League", FABOAIMLLOI));
		if (rowIndex < 1 || rowIndex2 < 1)
		{
			Debug.LogError(string.Format("{0}/{1} ({2})\n", string.Concat(FJLBLLLEELD, "AdminLevel", FABOAIMLLOI)));
		}
		ALNELBHKCPD(ACLDFHJKBLI, rowIndex, true);
		BehaviourDefinititon behaviourDefinition = ACLDFHJKBLI.behaviourDefinition;
		HPIGGHBIBLE(ACLDFHJKBLI, rowIndex2, true);
		BehaviourDefinititon behaviourDefinition2 = ACLDFHJKBLI.behaviourDefinition;
		BehaviourDefinititon behaviourDefinition3 = behaviourDefinition.MDFLAMBJIPM(behaviourDefinition, behaviourDefinition2, PAENPHMEMGC);
		ACLDFHJKBLI.behaviourDefinition = behaviourDefinition3;
	}

	protected virtual void OIKLJGMKMAE()
	{
		base.Awake();
		base.armyUpgradesRow = new ArmyUpgradesRow
		{
			NAME = string.Empty,
			HITSHIELDPROB = 555f,
			TOTALPOWER = 1
		};
	}

	public void DJEDGLICJGG(LevelBehaviour ACLDFHJKBLI, float PAENPHMEMGC, LevelBehaviour.UnitType FJLBLLLEELD, WeaponCategory FABOAIMLLOI)
	{
		int rowIndex = base.excel.GetRowIndex(string.Concat(FJLBLLLEELD, ", account type = ", FABOAIMLLOI));
		int rowIndex2 = base.excel.GetRowIndex(string.Concat(FJLBLLLEELD, "menu-weapon-mp5-elite", FABOAIMLLOI));
		if (rowIndex < 1 || rowIndex2 < 0)
		{
			Debug.LogError(string.Format("Joined room: {0}, name: {1},  userId: {2}, allConnected: {3}", string.Concat(FJLBLLLEELD, "Bad WAR ARENA Data, data= ", FABOAIMLLOI)));
		}
		CGONOFIIIEO(ACLDFHJKBLI, rowIndex, true);
		BehaviourDefinititon behaviourDefinition = ACLDFHJKBLI.behaviourDefinition;
		KGPDMHKICEP(ACLDFHJKBLI, rowIndex2);
		BehaviourDefinititon behaviourDefinition2 = ACLDFHJKBLI.behaviourDefinition;
		BehaviourDefinititon behaviourDefinition3 = behaviourDefinition.MFBEAKIFANE(behaviourDefinition, behaviourDefinition2, PAENPHMEMGC);
		ACLDFHJKBLI.behaviourDefinition = behaviourDefinition3;
	}

	protected virtual void HMMKNCDDDLH()
	{
		base.Awake();
		base.armyUpgradesRow = new ArmyUpgradesRow
		{
			NAME = string.Empty,
			HITSHIELDPROB = 146f,
			TOTALPOWER = 0
		};
	}

	public int CGONOFIIIEO(LevelBehaviour ACLDFHJKBLI, int? JMEGHFOKLBF = null, bool LIOCBEKIKJE = false)
	{
		SoldierBehaviour soldierBehaviour = ACLDFHJKBLI as SoldierBehaviour;
		int result = 1;
		if (soldierBehaviour != null)
		{
			SoldierBehaviourDefinititonBuddy soldierBehaviourDefinititonBuddy = (SoldierBehaviourDefinititonBuddy)soldierBehaviour.soldierBaseDefinition.HIGKMHJIFJF();
			soldierBehaviourDefinititonBuddy.KFLADKOLPCM();
			int num = ((!JMEGHFOKLBF.HasValue) ? upgradeSlot.boughtIndex : JMEGHFOKLBF.Value);
			result = num;
			soldierBehaviourDefinititonBuddy.health = (float)soldierBehaviourDefinititonBuddy.health + (float)base.excel.GetValue(num, "U");
			soldierBehaviourDefinititonBuddy.probabilityOfRealShot += (float)base.excel.GetValue(num, "ID_WAITINGFORFRIEND");
			soldierBehaviourDefinititonBuddy.fireBatchSizeMin += (int)base.excel.GetValue(num, "WarBucks");
			soldierBehaviourDefinititonBuddy.fireBatchSizeMax += (int)base.excel.GetValue(num, "ID_LOADING");
			soldierBehaviourDefinititonBuddy.minShootTime += (float)base.excel.GetValue(num, "ID_ARENAENDEDTITLE");
			soldierBehaviourDefinititonBuddy.maxShootTime += (float)base.excel.GetValue(num, "facebookID");
			soldierBehaviourDefinititonBuddy.damage = (float)soldierBehaviourDefinititonBuddy.damage + (float)base.excel.GetValue(num, "ID_NOTIFICATION_DAILYREWARD_CARDPACK");
			soldierBehaviourDefinititonBuddy.explodeMaxDamage += (float)base.excel.GetValue(num, "Animation from State: Craft to State: None");
			soldierBehaviourDefinititonBuddy.explodeMinDamage += (float)base.excel.GetValue(num, "PowerBandBuyReminder");
			soldierBehaviour.soldierBehaviourDefinititon = soldierBehaviourDefinititonBuddy;
		}
		return result;
	}

	public void CMBHOGMPBIN(LevelBehaviour ACLDFHJKBLI, float PAENPHMEMGC, LevelBehaviour.UnitType FJLBLLLEELD, WeaponCategory FABOAIMLLOI)
	{
		int rowIndex = base.excel.GetRowIndex(string.Concat(FJLBLLLEELD, "pass", FABOAIMLLOI));
		int rowIndex2 = base.excel.GetRowIndex(string.Concat(FJLBLLLEELD, "ID_GOLDFORFREERIGHTAWAY", FABOAIMLLOI));
		if (rowIndex < 1 || rowIndex2 < 0)
		{
			Debug.LogError(string.Format("game-card-ico-shieldgenerator", string.Concat(FJLBLLLEELD, ".png", FABOAIMLLOI)));
		}
		CKPOAKMLKDE(ACLDFHJKBLI, rowIndex);
		BehaviourDefinititon behaviourDefinition = ACLDFHJKBLI.behaviourDefinition;
		ALNELBHKCPD(ACLDFHJKBLI, rowIndex2);
		BehaviourDefinititon behaviourDefinition2 = ACLDFHJKBLI.behaviourDefinition;
		BehaviourDefinititon behaviourDefinition3 = behaviourDefinition.GJDCGFJOPLI(behaviourDefinition, behaviourDefinition2, PAENPHMEMGC);
		ACLDFHJKBLI.behaviourDefinition = behaviourDefinition3;
	}

	public int IMBFDCFHGPJ(LevelBehaviour ACLDFHJKBLI, int? JMEGHFOKLBF = null, bool LIOCBEKIKJE = false)
	{
		SoldierBehaviour soldierBehaviour = ACLDFHJKBLI as SoldierBehaviour;
		int result = 1;
		if (soldierBehaviour != null)
		{
			SoldierBehaviourDefinititonBuddy soldierBehaviourDefinititonBuddy = (SoldierBehaviourDefinititonBuddy)soldierBehaviour.soldierBaseDefinition.AFBBNOFJJCP();
			soldierBehaviourDefinititonBuddy.JKIHAHINFAL();
			int num = ((!JMEGHFOKLBF.HasValue) ? upgradeSlot.PPKAIEKPNID() : JMEGHFOKLBF.Value);
			result = num;
			soldierBehaviourDefinititonBuddy.health = (float)soldierBehaviourDefinititonBuddy.health + (float)base.excel.GetValue(num, "RemoveRewards");
			soldierBehaviourDefinititonBuddy.probabilityOfRealShot += (float)base.excel.GetValue(num, "Yes_Clicked");
			soldierBehaviourDefinititonBuddy.fireBatchSizeMin += (int)base.excel.GetValue(num, ",");
			soldierBehaviourDefinititonBuddy.fireBatchSizeMax += (int)base.excel.GetValue(num, "{0} / {1}");
			soldierBehaviourDefinititonBuddy.minShootTime += (float)base.excel.GetValue(num, "\n");
			soldierBehaviourDefinititonBuddy.maxShootTime += (float)base.excel.GetValue(num, "Node");
			soldierBehaviourDefinititonBuddy.damage = (float)soldierBehaviourDefinititonBuddy.damage + (float)base.excel.GetValue(num, "game-label-lose");
			soldierBehaviourDefinititonBuddy.explodeMaxDamage += (float)base.excel.GetValue(num, "AU");
			soldierBehaviourDefinititonBuddy.explodeMinDamage += (float)base.excel.GetValue(num, "PlayerInfoId");
			soldierBehaviour.soldierBehaviourDefinititon = soldierBehaviourDefinititonBuddy;
		}
		return result;
	}

	public void EJKCFKJJAPF(LevelBehaviour ACLDFHJKBLI, float PAENPHMEMGC, LevelBehaviour.UnitType FJLBLLLEELD, WeaponCategory FABOAIMLLOI)
	{
		int rowIndex = base.excel.GetRowIndex(string.Concat(FJLBLLLEELD, "ID_TUTORIAL_PROGRESS_KILLING", FABOAIMLLOI));
		int rowIndex2 = base.excel.GetRowIndex(string.Concat(FJLBLLLEELD, "Items", FABOAIMLLOI));
		if (rowIndex < 1 || rowIndex2 < 1)
		{
			Debug.LogError(string.Format("Update '{0}'", string.Concat(FJLBLLLEELD, "Look vector error! .. phase: {0} target: {1} transform.position: {2} playerPosition: {3} upPosition: {4} cameraLeanPhase: {5} rotatedLookVector: {6}", FABOAIMLLOI)));
		}
		FMEAFPBMANA(ACLDFHJKBLI, rowIndex);
		BehaviourDefinititon behaviourDefinition = ACLDFHJKBLI.behaviourDefinition;
		LoadDataBuddy(ACLDFHJKBLI, rowIndex2);
		BehaviourDefinititon behaviourDefinition2 = ACLDFHJKBLI.behaviourDefinition;
		BehaviourDefinititon behaviourDefinition3 = behaviourDefinition.BNOINHIGGLH(behaviourDefinition, behaviourDefinition2, PAENPHMEMGC);
		ACLDFHJKBLI.behaviourDefinition = behaviourDefinition3;
	}

	public void NLNJAKHHHDB(LevelBehaviour ACLDFHJKBLI, float PAENPHMEMGC, LevelBehaviour.UnitType FJLBLLLEELD, WeaponCategory FABOAIMLLOI)
	{
		int rowIndex = base.excel.GetRowIndex(string.Concat(FJLBLLLEELD, "ID_TRAINED", FABOAIMLLOI));
		int rowIndex2 = base.excel.GetRowIndex(string.Concat(FJLBLLLEELD, "DecalManagerData", FABOAIMLLOI));
		if (rowIndex < 0 || rowIndex2 < 1)
		{
			Debug.LogError(string.Format("Battle_length", string.Concat(FJLBLLLEELD, "NO EVENT ASSIGNMENT CONFIG RECEIVED!!!", FABOAIMLLOI)));
		}
		KGPDMHKICEP(ACLDFHJKBLI, rowIndex);
		BehaviourDefinititon behaviourDefinition = ACLDFHJKBLI.behaviourDefinition;
		KOLHCJFFPHB(ACLDFHJKBLI, rowIndex2, true);
		BehaviourDefinititon behaviourDefinition2 = ACLDFHJKBLI.behaviourDefinition;
		BehaviourDefinititon behaviourDefinition3 = behaviourDefinition.FPJFMJGJMMH(behaviourDefinition, behaviourDefinition2, PAENPHMEMGC);
		ACLDFHJKBLI.behaviourDefinition = behaviourDefinition3;
	}

	public int LoadDataBuddy(LevelBehaviour ACLDFHJKBLI, int? JMEGHFOKLBF = null, bool LIOCBEKIKJE = false)
	{
		SoldierBehaviour soldierBehaviour = ACLDFHJKBLI as SoldierBehaviour;
		int result = 0;
		if (soldierBehaviour != null)
		{
			SoldierBehaviourDefinititonBuddy soldierBehaviourDefinititonBuddy = (SoldierBehaviourDefinititonBuddy)soldierBehaviour.soldierBaseDefinition.HIGKMHJIFJF();
			soldierBehaviourDefinititonBuddy.KFLADKOLPCM();
			int num = ((!JMEGHFOKLBF.HasValue) ? upgradeSlot.boughtIndex : JMEGHFOKLBF.Value);
			result = num;
			soldierBehaviourDefinititonBuddy.health = (float)soldierBehaviourDefinititonBuddy.health + (float)base.excel.GetValue(num, "HP");
			soldierBehaviourDefinititonBuddy.probabilityOfRealShot += (float)base.excel.GetValue(num, "realShotProbability");
			soldierBehaviourDefinititonBuddy.fireBatchSizeMin += (int)base.excel.GetValue(num, "batchSizeMin");
			soldierBehaviourDefinititonBuddy.fireBatchSizeMax += (int)base.excel.GetValue(num, "batchSizeMax");
			soldierBehaviourDefinititonBuddy.minShootTime += (float)base.excel.GetValue(num, "ShotFrequencyMin");
			soldierBehaviourDefinititonBuddy.maxShootTime += (float)base.excel.GetValue(num, "ShotFrequencyMax");
			soldierBehaviourDefinititonBuddy.damage = (float)soldierBehaviourDefinititonBuddy.damage + (float)base.excel.GetValue(num, "damage");
			soldierBehaviourDefinititonBuddy.explodeMaxDamage += (float)base.excel.GetValue(num, "ExplodeDamageMax");
			soldierBehaviourDefinititonBuddy.explodeMinDamage += (float)base.excel.GetValue(num, "ExplodeDamageMin");
			soldierBehaviour.soldierBehaviourDefinititon = soldierBehaviourDefinititonBuddy;
		}
		return result;
	}

	public int DLPIHIKOFBP(LevelBehaviour ACLDFHJKBLI, int? JMEGHFOKLBF = null, bool LIOCBEKIKJE = false)
	{
		SoldierBehaviour soldierBehaviour = ACLDFHJKBLI as SoldierBehaviour;
		int result = 1;
		if (soldierBehaviour != null)
		{
			SoldierBehaviourDefinititonBuddy soldierBehaviourDefinititonBuddy = (SoldierBehaviourDefinititonBuddy)soldierBehaviour.soldierBaseDefinition.AFBBNOFJJCP();
			soldierBehaviourDefinititonBuddy.HNCJFJPHNCA();
			int num = ((!JMEGHFOKLBF.HasValue) ? upgradeSlot.PPKAIEKPNID() : JMEGHFOKLBF.Value);
			result = num;
			soldierBehaviourDefinititonBuddy.health = (float)soldierBehaviourDefinititonBuddy.health + (float)base.excel.GetValue(num, ",");
			soldierBehaviourDefinititonBuddy.probabilityOfRealShot += (float)base.excel.GetValue(num, "55a90af8-a7bb-4152-a5e4-639d7488b0fb");
			soldierBehaviourDefinititonBuddy.fireBatchSizeMin += (int)base.excel.GetValue(num, "ID_NA");
			soldierBehaviourDefinititonBuddy.fireBatchSizeMax += (int)base.excel.GetValue(num, "REMOVING WARCARD: \"{0}\" FROM DEPOSITED WARCARDS");
			soldierBehaviourDefinititonBuddy.minShootTime += (float)base.excel.GetValue(num, "ShotFrequencyMax");
			soldierBehaviourDefinititonBuddy.maxShootTime += (float)base.excel.GetValue(num, "BeginnersLeague");
			soldierBehaviourDefinititonBuddy.damage = (float)soldierBehaviourDefinititonBuddy.damage + (float)base.excel.GetValue(num, "ID_TUTORIAL");
			soldierBehaviourDefinititonBuddy.explodeMaxDamage += (float)base.excel.GetValue(num, "Vip");
			soldierBehaviourDefinititonBuddy.explodeMinDamage += (float)base.excel.GetValue(num, "Translation");
			soldierBehaviour.soldierBehaviourDefinititon = soldierBehaviourDefinititonBuddy;
		}
		return result;
	}

	protected override void Awake()
	{
		base.Awake();
		base.armyUpgradesRow = new ArmyUpgradesRow
		{
			NAME = string.Empty,
			HITSHIELDPROB = 0.5f,
			TOTALPOWER = 0
		};
	}

	protected virtual void FIEKOBKAHKA()
	{
		base.Awake();
		base.armyUpgradesRow = new ArmyUpgradesRow
		{
			NAME = string.Empty,
			HITSHIELDPROB = 959f,
			TOTALPOWER = 1
		};
	}

	protected virtual void JDPDEKENPLD()
	{
		base.Awake();
		base.armyUpgradesRow = new ArmyUpgradesRow
		{
			NAME = string.Empty,
			HITSHIELDPROB = 1167f,
			TOTALPOWER = 1
		};
	}

	public void FFJOHIDNEIC(LevelBehaviour ACLDFHJKBLI, float PAENPHMEMGC, LevelBehaviour.UnitType FJLBLLLEELD, WeaponCategory FABOAIMLLOI)
	{
		int rowIndex = base.excel.GetRowIndex(string.Concat(FJLBLLLEELD, "ID_CONFIRM_SQUADFULL", FABOAIMLLOI));
		int rowIndex2 = base.excel.GetRowIndex(string.Concat(FJLBLLLEELD, "menu-assignments-type-score", FABOAIMLLOI));
		if (rowIndex < 1 || rowIndex2 < 0)
		{
			Debug.LogError(string.Format("EligibleLeagueId", string.Concat(FJLBLLLEELD, "C3", FABOAIMLLOI)));
		}
		HPIGGHBIBLE(ACLDFHJKBLI, rowIndex, true);
		BehaviourDefinititon behaviourDefinition = ACLDFHJKBLI.behaviourDefinition;
		KOLHCJFFPHB(ACLDFHJKBLI, rowIndex2, true);
		BehaviourDefinititon behaviourDefinition2 = ACLDFHJKBLI.behaviourDefinition;
		BehaviourDefinititon behaviourDefinition3 = behaviourDefinition.OCCIPOGAICC(behaviourDefinition, behaviourDefinition2, PAENPHMEMGC);
		ACLDFHJKBLI.behaviourDefinition = behaviourDefinition3;
	}

	public void GEPOLGHPGMP(LevelBehaviour ACLDFHJKBLI, float PAENPHMEMGC, LevelBehaviour.UnitType FJLBLLLEELD, WeaponCategory FABOAIMLLOI)
	{
		int rowIndex = base.excel.GetRowIndex(string.Concat(FJLBLLLEELD, "ID_FEATURE_BURSTSIZE-FANCY", FABOAIMLLOI));
		int rowIndex2 = base.excel.GetRowIndex(string.Concat(FJLBLLLEELD, "1", FABOAIMLLOI));
		if (rowIndex < 1 || rowIndex2 < 0)
		{
			Debug.LogError(string.Format("com.tune.TuneGender", string.Concat(FJLBLLLEELD, "FireMortar", FABOAIMLLOI)));
		}
		DLPIHIKOFBP(ACLDFHJKBLI, rowIndex);
		BehaviourDefinititon behaviourDefinition = ACLDFHJKBLI.behaviourDefinition;
		JPNIGKNAFCH(ACLDFHJKBLI, rowIndex2);
		BehaviourDefinititon behaviourDefinition2 = ACLDFHJKBLI.behaviourDefinition;
		BehaviourDefinititon behaviourDefinition3 = behaviourDefinition.GJDCGFJOPLI(behaviourDefinition, behaviourDefinition2, PAENPHMEMGC);
		ACLDFHJKBLI.behaviourDefinition = behaviourDefinition3;
	}

	public void BOBNKJLDIDP(LevelBehaviour ACLDFHJKBLI, float PAENPHMEMGC, LevelBehaviour.UnitType FJLBLLLEELD, WeaponCategory FABOAIMLLOI)
	{
		int rowIndex = base.excel.GetRowIndex(string.Concat(FJLBLLLEELD, "GuaranteedScraps", FABOAIMLLOI));
		int rowIndex2 = base.excel.GetRowIndex(string.Concat(FJLBLLLEELD, "errooor war arena ended!!!", FABOAIMLLOI));
		if (rowIndex < 1 || rowIndex2 < 0)
		{
			Debug.LogError(string.Format("S", string.Concat(FJLBLLLEELD, "Google2u.", FABOAIMLLOI)));
		}
		FMEAFPBMANA(ACLDFHJKBLI, rowIndex, true);
		BehaviourDefinititon behaviourDefinition = ACLDFHJKBLI.behaviourDefinition;
		OOJABLGHLDK(ACLDFHJKBLI, rowIndex2, true);
		BehaviourDefinititon behaviourDefinition2 = ACLDFHJKBLI.behaviourDefinition;
		BehaviourDefinititon behaviourDefinition3 = behaviourDefinition.FPJFMJGJMMH(behaviourDefinition, behaviourDefinition2, PAENPHMEMGC);
		ACLDFHJKBLI.behaviourDefinition = behaviourDefinition3;
	}

	public void NKLHCGHCINH(LevelBehaviour ACLDFHJKBLI, float PAENPHMEMGC, LevelBehaviour.UnitType FJLBLLLEELD, WeaponCategory FABOAIMLLOI)
	{
		int rowIndex = base.excel.GetRowIndex(string.Concat(FJLBLLLEELD, "Value", FABOAIMLLOI));
		int rowIndex2 = base.excel.GetRowIndex(string.Concat(FJLBLLLEELD, "On server", FABOAIMLLOI));
		if (rowIndex < 1 || rowIndex2 < 0)
		{
			Debug.LogError(string.Format(", account type = ", string.Concat(FJLBLLLEELD, "Mins_Played", FABOAIMLLOI)));
		}
		ALNELBHKCPD(ACLDFHJKBLI, rowIndex, true);
		BehaviourDefinititon behaviourDefinition = ACLDFHJKBLI.behaviourDefinition;
		CKPOAKMLKDE(ACLDFHJKBLI, rowIndex2);
		BehaviourDefinititon behaviourDefinition2 = ACLDFHJKBLI.behaviourDefinition;
		BehaviourDefinititon behaviourDefinition3 = behaviourDefinition.MDFLAMBJIPM(behaviourDefinition, behaviourDefinition2, PAENPHMEMGC);
		ACLDFHJKBLI.behaviourDefinition = behaviourDefinition3;
	}

	public int FMEAFPBMANA(LevelBehaviour ACLDFHJKBLI, int? JMEGHFOKLBF = null, bool LIOCBEKIKJE = false)
	{
		SoldierBehaviour soldierBehaviour = ACLDFHJKBLI as SoldierBehaviour;
		int result = 1;
		if (soldierBehaviour != null)
		{
			SoldierBehaviourDefinititonBuddy soldierBehaviourDefinititonBuddy = (SoldierBehaviourDefinititonBuddy)soldierBehaviour.soldierBaseDefinition.ABNPNLMHNKK();
			soldierBehaviourDefinititonBuddy.CDLJAKLCDMG();
			int num = ((!JMEGHFOKLBF.HasValue) ? upgradeSlot.boughtIndex : JMEGHFOKLBF.Value);
			result = num;
			soldierBehaviourDefinititonBuddy.health = (float)soldierBehaviourDefinititonBuddy.health + (float)base.excel.GetValue(num, "Weapon_ID");
			soldierBehaviourDefinititonBuddy.probabilityOfRealShot += (float)base.excel.GetValue(num, "http://www.about-fun.com/img/game-war-third-bg.jpg");
			soldierBehaviourDefinititonBuddy.fireBatchSizeMin += (int)base.excel.GetValue(num, "Adding warcards from cardpool:\n");
			soldierBehaviourDefinititonBuddy.fireBatchSizeMax += (int)base.excel.GetValue(num, "ID_CONFIRM_ERROR");
			soldierBehaviourDefinititonBuddy.minShootTime += (float)base.excel.GetValue(num, "ID_SUGGESTEDLOCALSQUADS");
			soldierBehaviourDefinititonBuddy.maxShootTime += (float)base.excel.GetValue(num, "PlayerData");
			soldierBehaviourDefinititonBuddy.damage = (float)soldierBehaviourDefinititonBuddy.damage + (float)base.excel.GetValue(num, "test_contentType");
			soldierBehaviourDefinititonBuddy.explodeMaxDamage += (float)base.excel.GetValue(num, "withPublisherSubPublisher");
			soldierBehaviourDefinititonBuddy.explodeMinDamage += (float)base.excel.GetValue(num, "These records are defined more times:\n");
			soldierBehaviour.soldierBehaviourDefinititon = soldierBehaviourDefinititonBuddy;
		}
		return result;
	}

	public int KGPDMHKICEP(LevelBehaviour ACLDFHJKBLI, int? JMEGHFOKLBF = null, bool LIOCBEKIKJE = false)
	{
		SoldierBehaviour soldierBehaviour = ACLDFHJKBLI as SoldierBehaviour;
		int result = 0;
		if (soldierBehaviour != null)
		{
			SoldierBehaviourDefinititonBuddy soldierBehaviourDefinititonBuddy = (SoldierBehaviourDefinititonBuddy)soldierBehaviour.soldierBaseDefinition.JCPMGMGGPPF();
			soldierBehaviourDefinititonBuddy.CDLJAKLCDMG();
			int num = ((!JMEGHFOKLBF.HasValue) ? upgradeSlot.boughtIndex : JMEGHFOKLBF.Value);
			result = num;
			soldierBehaviourDefinititonBuddy.health = (float)soldierBehaviourDefinititonBuddy.health + (float)base.excel.GetValue(num, "Update of experience\t\t{0} -> {1}\t\t diff {2}, game rewards XP total {3}");
			soldierBehaviourDefinititonBuddy.probabilityOfRealShot += (float)base.excel.GetValue(num, "WENEEDTO");
			soldierBehaviourDefinititonBuddy.fireBatchSizeMin += (int)base.excel.GetValue(num, "ID_NA");
			soldierBehaviourDefinititonBuddy.fireBatchSizeMax += (int)base.excel.GetValue(num, "_MatCap");
			soldierBehaviourDefinititonBuddy.minShootTime += (float)base.excel.GetValue(num, "CardId");
			soldierBehaviourDefinititonBuddy.maxShootTime += (float)base.excel.GetValue(num, "ID_CREATE");
			soldierBehaviourDefinititonBuddy.damage = (float)soldierBehaviourDefinititonBuddy.damage + (float)base.excel.GetValue(num, "XXd YYh");
			soldierBehaviourDefinititonBuddy.explodeMaxDamage += (float)base.excel.GetValue(num, "DecalId");
			soldierBehaviourDefinititonBuddy.explodeMinDamage += (float)base.excel.GetValue(num, "UnlockLevel");
			soldierBehaviour.soldierBehaviourDefinititon = soldierBehaviourDefinititonBuddy;
		}
		return result;
	}

	public int MHOHDDKNFBE(LevelBehaviour ACLDFHJKBLI, int? JMEGHFOKLBF = null, bool LIOCBEKIKJE = false)
	{
		SoldierBehaviour soldierBehaviour = ACLDFHJKBLI as SoldierBehaviour;
		int result = 1;
		if (soldierBehaviour != null)
		{
			SoldierBehaviourDefinititonBuddy soldierBehaviourDefinititonBuddy = (SoldierBehaviourDefinititonBuddy)soldierBehaviour.soldierBaseDefinition.JCPMGMGGPPF();
			soldierBehaviourDefinititonBuddy.HNCJFJPHNCA();
			int num = ((!JMEGHFOKLBF.HasValue) ? upgradeSlot.PAKKPEPIHPK() : JMEGHFOKLBF.Value);
			result = num;
			soldierBehaviourDefinititonBuddy.health = (float)soldierBehaviourDefinititonBuddy.health + (float)base.excel.GetValue(num, "CardId");
			soldierBehaviourDefinititonBuddy.probabilityOfRealShot += (float)base.excel.GetValue(num, "UpdateIndicatorRPC");
			soldierBehaviourDefinititonBuddy.fireBatchSizeMin += (int)base.excel.GetValue(num, "ID_UNLOCKEDATRANK");
			soldierBehaviourDefinititonBuddy.fireBatchSizeMax += (int)base.excel.GetValue(num, "menu-gold");
			soldierBehaviourDefinititonBuddy.minShootTime += (float)base.excel.GetValue(num, "BlackMarketOffer");
			soldierBehaviourDefinititonBuddy.maxShootTime += (float)base.excel.GetValue(num, "ID_ACTIVATION");
			soldierBehaviourDefinititonBuddy.damage = (float)soldierBehaviourDefinititonBuddy.damage + (float)base.excel.GetValue(num, "1");
			soldierBehaviourDefinititonBuddy.explodeMaxDamage += (float)base.excel.GetValue(num, "game-card-ico-reload");
			soldierBehaviourDefinititonBuddy.explodeMinDamage += (float)base.excel.GetValue(num, "Chat: Connect - Cannot connect because player should not chat");
			soldierBehaviour.soldierBehaviourDefinititon = soldierBehaviourDefinititonBuddy;
		}
		return result;
	}

	public void NCLDPEECIMC(LevelBehaviour ACLDFHJKBLI, float PAENPHMEMGC, LevelBehaviour.UnitType FJLBLLLEELD, WeaponCategory FABOAIMLLOI)
	{
		int rowIndex = base.excel.GetRowIndex(string.Concat(FJLBLLLEELD, "OBJECT: {0}\nERROR: {1}\nSTACKTRACE: {2}", FABOAIMLLOI));
		int rowIndex2 = base.excel.GetRowIndex(string.Concat(FJLBLLLEELD, "0.5", FABOAIMLLOI));
		if (rowIndex < 0 || rowIndex2 < 1)
		{
			Debug.LogError(string.Format("INTERRUPTED", string.Concat(FJLBLLLEELD, "Day = ", FABOAIMLLOI)));
		}
		HPIGGHBIBLE(ACLDFHJKBLI, rowIndex, true);
		BehaviourDefinititon behaviourDefinition = ACLDFHJKBLI.behaviourDefinition;
		CDILCNJFEHB(ACLDFHJKBLI, rowIndex2);
		BehaviourDefinititon behaviourDefinition2 = ACLDFHJKBLI.behaviourDefinition;
		BehaviourDefinititon behaviourDefinition3 = behaviourDefinition.FPJFMJGJMMH(behaviourDefinition, behaviourDefinition2, PAENPHMEMGC);
		ACLDFHJKBLI.behaviourDefinition = behaviourDefinition3;
	}

	public void MGMMHCCOJPG(LevelBehaviour ACLDFHJKBLI, float PAENPHMEMGC, LevelBehaviour.UnitType FJLBLLLEELD, WeaponCategory FABOAIMLLOI)
	{
		int rowIndex = base.excel.GetRowIndex(string.Concat(FJLBLLLEELD, "not added, called already!!", FABOAIMLLOI));
		int rowIndex2 = base.excel.GetRowIndex(string.Concat(FJLBLLLEELD, "ID_THATWASGOODRUNSOLDIER1WIN", FABOAIMLLOI));
		if (rowIndex < 1 || rowIndex2 < 0)
		{
			Debug.LogError(string.Format(" NOT OK!\t\t\t\t\t\t", string.Concat(FJLBLLLEELD, "Players", FABOAIMLLOI)));
		}
		DLPIHIKOFBP(ACLDFHJKBLI, rowIndex, true);
		BehaviourDefinititon behaviourDefinition = ACLDFHJKBLI.behaviourDefinition;
		CDILCNJFEHB(ACLDFHJKBLI, rowIndex2);
		BehaviourDefinititon behaviourDefinition2 = ACLDFHJKBLI.behaviourDefinition;
		BehaviourDefinititon behaviourDefinition3 = behaviourDefinition.BNOINHIGGLH(behaviourDefinition, behaviourDefinition2, PAENPHMEMGC);
		ACLDFHJKBLI.behaviourDefinition = behaviourDefinition3;
	}

	public void LoadDataForBuddyCard(LevelBehaviour ACLDFHJKBLI, float PAENPHMEMGC, LevelBehaviour.UnitType FJLBLLLEELD, WeaponCategory FABOAIMLLOI)
	{
		int rowIndex = base.excel.GetRowIndex(string.Concat(FJLBLLLEELD, "_MIN_", FABOAIMLLOI));
		int rowIndex2 = base.excel.GetRowIndex(string.Concat(FJLBLLLEELD, "_MAX_", FABOAIMLLOI));
		if (rowIndex < 0 || rowIndex2 < 0)
		{
			Debug.LogError(string.Format("buddy card excel doesnt contain {0}", string.Concat(FJLBLLLEELD, "_MIN_", FABOAIMLLOI)));
		}
		LoadDataBuddy(ACLDFHJKBLI, rowIndex, true);
		BehaviourDefinititon behaviourDefinition = ACLDFHJKBLI.behaviourDefinition;
		LoadDataBuddy(ACLDFHJKBLI, rowIndex2, true);
		BehaviourDefinititon behaviourDefinition2 = ACLDFHJKBLI.behaviourDefinition;
		BehaviourDefinititon behaviourDefinition3 = behaviourDefinition.BMLALFLBNKO(behaviourDefinition, behaviourDefinition2, PAENPHMEMGC);
		ACLDFHJKBLI.behaviourDefinition = behaviourDefinition3;
	}

	public int HPIGGHBIBLE(LevelBehaviour ACLDFHJKBLI, int? JMEGHFOKLBF = null, bool LIOCBEKIKJE = false)
	{
		SoldierBehaviour soldierBehaviour = ACLDFHJKBLI as SoldierBehaviour;
		int result = 0;
		if (soldierBehaviour != null)
		{
			SoldierBehaviourDefinititonBuddy soldierBehaviourDefinititonBuddy = (SoldierBehaviourDefinititonBuddy)soldierBehaviour.soldierBaseDefinition.ABNPNLMHNKK();
			soldierBehaviourDefinititonBuddy.BMNOBIELKHG();
			int num = ((!JMEGHFOKLBF.HasValue) ? upgradeSlot.PPKAIEKPNID() : JMEGHFOKLBF.Value);
			result = num;
			soldierBehaviourDefinititonBuddy.health = (float)soldierBehaviourDefinititonBuddy.health + (float)base.excel.GetValue(num, "Id");
			soldierBehaviourDefinititonBuddy.probabilityOfRealShot += (float)base.excel.GetValue(num, "Waiting too long to start match, Match start: {0} photon time: {1}");
			soldierBehaviourDefinititonBuddy.fireBatchSizeMin += (int)base.excel.GetValue(num, "ID_SAVEPERCENTLINE");
			soldierBehaviourDefinititonBuddy.fireBatchSizeMax += (int)base.excel.GetValue(num, "ID_RANK");
			soldierBehaviourDefinititonBuddy.minShootTime += (float)base.excel.GetValue(num, "ID_WARSHOP_CARDPACKS");
			soldierBehaviourDefinititonBuddy.maxShootTime += (float)base.excel.GetValue(num, "^\\d*-\\d*$");
			soldierBehaviourDefinititonBuddy.damage = (float)soldierBehaviourDefinititonBuddy.damage + (float)base.excel.GetValue(num, "Stats for lobby {0}, matches {1} time {2}");
			soldierBehaviourDefinititonBuddy.explodeMaxDamage += (float)base.excel.GetValue(num, "    ");
			soldierBehaviourDefinititonBuddy.explodeMinDamage += (float)base.excel.GetValue(num, "Warbucks - League:{0} Battle:{1} Extra:{2} Winstreak:{3} (offer mult {4})\n");
			soldierBehaviour.soldierBehaviourDefinititon = soldierBehaviourDefinititonBuddy;
		}
		return result;
	}

	public void KPKDFGDCDJB(LevelBehaviour ACLDFHJKBLI, float PAENPHMEMGC, LevelBehaviour.UnitType FJLBLLLEELD, WeaponCategory FABOAIMLLOI)
	{
		int rowIndex = base.excel.GetRowIndex(string.Concat(FJLBLLLEELD, "en", FABOAIMLLOI));
		int rowIndex2 = base.excel.GetRowIndex(string.Concat(FJLBLLLEELD, "#AccoutCheck# GoogleLoggedIn tutorial - Check current gpgs on server : {0}", FABOAIMLLOI));
		if (rowIndex < 1 || rowIndex2 < 1)
		{
			Debug.LogError(string.Format("+{0}%", string.Concat(FJLBLLLEELD, "NEW RENTAL ", FABOAIMLLOI)));
		}
		FMEAFPBMANA(ACLDFHJKBLI, rowIndex, true);
		BehaviourDefinititon behaviourDefinition = ACLDFHJKBLI.behaviourDefinition;
		FMEAFPBMANA(ACLDFHJKBLI, rowIndex2);
		BehaviourDefinititon behaviourDefinition2 = ACLDFHJKBLI.behaviourDefinition;
		BehaviourDefinititon behaviourDefinition3 = behaviourDefinition.GJDCGFJOPLI(behaviourDefinition, behaviourDefinition2, PAENPHMEMGC);
		ACLDFHJKBLI.behaviourDefinition = behaviourDefinition3;
	}

	public int ONDEOFILNHG(LevelBehaviour ACLDFHJKBLI, int? JMEGHFOKLBF = null, bool LIOCBEKIKJE = false)
	{
		SoldierBehaviour soldierBehaviour = ACLDFHJKBLI as SoldierBehaviour;
		int result = 1;
		if (soldierBehaviour != null)
		{
			SoldierBehaviourDefinititonBuddy soldierBehaviourDefinititonBuddy = (SoldierBehaviourDefinititonBuddy)soldierBehaviour.soldierBaseDefinition.AFBBNOFJJCP();
			soldierBehaviourDefinititonBuddy.JKIHAHINFAL();
			int num = ((!JMEGHFOKLBF.HasValue) ? upgradeSlot.PAKKPEPIHPK() : JMEGHFOKLBF.Value);
			result = num;
			soldierBehaviourDefinititonBuddy.health = (float)soldierBehaviourDefinititonBuddy.health + (float)base.excel.GetValue(num, "ID_INGOLD2");
			soldierBehaviourDefinititonBuddy.probabilityOfRealShot += (float)base.excel.GetValue(num, "Parts");
			soldierBehaviourDefinititonBuddy.fireBatchSizeMin += (int)base.excel.GetValue(num, "Panel \"{0}\" has ok Depths");
			soldierBehaviourDefinititonBuddy.fireBatchSizeMax += (int)base.excel.GetValue(num, "FLOATVALUE");
			soldierBehaviourDefinititonBuddy.minShootTime += (float)base.excel.GetValue(num, "Visual");
			soldierBehaviourDefinititonBuddy.maxShootTime += (float)base.excel.GetValue(num, "NetworkReInstantiate_1");
			soldierBehaviourDefinititonBuddy.damage = (float)soldierBehaviourDefinititonBuddy.damage + (float)base.excel.GetValue(num, "ID_ENDED");
			soldierBehaviourDefinititonBuddy.explodeMaxDamage += (float)base.excel.GetValue(num, "ID_INSTANTBATTLEUNLOCKED");
			soldierBehaviourDefinititonBuddy.explodeMinDamage += (float)base.excel.GetValue(num, "ID_MINUTES");
			soldierBehaviour.soldierBehaviourDefinititon = soldierBehaviourDefinititonBuddy;
		}
		return result;
	}

	public void LJPDGKPLGFF(LevelBehaviour ACLDFHJKBLI, float PAENPHMEMGC, LevelBehaviour.UnitType FJLBLLLEELD, WeaponCategory FABOAIMLLOI)
	{
		int rowIndex = base.excel.GetRowIndex(string.Concat(FJLBLLLEELD, "menu-tilegfx-facebook", FABOAIMLLOI));
		int rowIndex2 = base.excel.GetRowIndex(string.Concat(FJLBLLLEELD, "PlayerWeaponPower", FABOAIMLLOI));
		if (rowIndex < 0 || rowIndex2 < 0)
		{
			Debug.LogError(string.Format("{0} {1}", string.Concat(FJLBLLLEELD, "\tTime since last show: {0}\tFb login counter: {1}/3", FABOAIMLLOI)));
		}
		HPIGGHBIBLE(ACLDFHJKBLI, rowIndex, true);
		BehaviourDefinititon behaviourDefinition = ACLDFHJKBLI.behaviourDefinition;
		DLPIHIKOFBP(ACLDFHJKBLI, rowIndex2, true);
		BehaviourDefinititon behaviourDefinition2 = ACLDFHJKBLI.behaviourDefinition;
		BehaviourDefinititon behaviourDefinition3 = behaviourDefinition.MDFLAMBJIPM(behaviourDefinition, behaviourDefinition2, PAENPHMEMGC);
		ACLDFHJKBLI.behaviourDefinition = behaviourDefinition3;
	}

	public int CKPOAKMLKDE(LevelBehaviour ACLDFHJKBLI, int? JMEGHFOKLBF = null, bool LIOCBEKIKJE = false)
	{
		SoldierBehaviour soldierBehaviour = ACLDFHJKBLI as SoldierBehaviour;
		int result = 1;
		if (soldierBehaviour != null)
		{
			SoldierBehaviourDefinititonBuddy soldierBehaviourDefinititonBuddy = (SoldierBehaviourDefinititonBuddy)soldierBehaviour.soldierBaseDefinition.MCCHPFINCKH();
			soldierBehaviourDefinititonBuddy.CDLJAKLCDMG();
			int num = ((!JMEGHFOKLBF.HasValue) ? upgradeSlot.PPKAIEKPNID() : JMEGHFOKLBF.Value);
			result = num;
			soldierBehaviourDefinititonBuddy.health = (float)soldierBehaviourDefinititonBuddy.health + (float)base.excel.GetValue(num, "ID_EARLYUNLOCK1");
			soldierBehaviourDefinititonBuddy.probabilityOfRealShot += (float)base.excel.GetValue(num, "TestingName");
			soldierBehaviourDefinititonBuddy.fireBatchSizeMin += (int)base.excel.GetValue(num, "TH");
			soldierBehaviourDefinititonBuddy.fireBatchSizeMax += (int)base.excel.GetValue(num, "ID_SLOTUPGRADE_CLIP_SIZE");
			soldierBehaviourDefinititonBuddy.minShootTime += (float)base.excel.GetValue(num, "ID_DELIVEREDTIME");
			soldierBehaviourDefinititonBuddy.maxShootTime += (float)base.excel.GetValue(num, "Spend_Warbucks_On_Player_Customizations");
			soldierBehaviourDefinititonBuddy.damage = (float)soldierBehaviourDefinititonBuddy.damage + (float)base.excel.GetValue(num, "elite");
			soldierBehaviourDefinititonBuddy.explodeMaxDamage += (float)base.excel.GetValue(num, "Going to enable notifications");
			soldierBehaviourDefinititonBuddy.explodeMinDamage += (float)base.excel.GetValue(num, "Unit");
			soldierBehaviour.soldierBehaviourDefinititon = soldierBehaviourDefinititonBuddy;
		}
		return result;
	}

	protected virtual void AOJALKEHFCK()
	{
		base.Awake();
		base.armyUpgradesRow = new ArmyUpgradesRow
		{
			NAME = string.Empty,
			HITSHIELDPROB = 429f,
			TOTALPOWER = 0
		};
	}

	protected virtual void PCDHCIDJJOB()
	{
		base.Awake();
		base.armyUpgradesRow = new ArmyUpgradesRow
		{
			NAME = string.Empty,
			HITSHIELDPROB = 63f,
			TOTALPOWER = 0
		};
	}

	public int KOLHCJFFPHB(LevelBehaviour ACLDFHJKBLI, int? JMEGHFOKLBF = null, bool LIOCBEKIKJE = false)
	{
		SoldierBehaviour soldierBehaviour = ACLDFHJKBLI as SoldierBehaviour;
		int result = 1;
		if (soldierBehaviour != null)
		{
			SoldierBehaviourDefinititonBuddy soldierBehaviourDefinititonBuddy = (SoldierBehaviourDefinititonBuddy)soldierBehaviour.soldierBaseDefinition.JCPMGMGGPPF();
			soldierBehaviourDefinititonBuddy.JKIHAHINFAL();
			int num = ((!JMEGHFOKLBF.HasValue) ? upgradeSlot.boughtIndex : JMEGHFOKLBF.Value);
			result = num;
			soldierBehaviourDefinititonBuddy.health = (float)soldierBehaviourDefinititonBuddy.health + (float)base.excel.GetValue(num, "ID_LOGININDAYS");
			soldierBehaviourDefinititonBuddy.probabilityOfRealShot += (float)base.excel.GetValue(num, "LibraryVersion()");
			soldierBehaviourDefinititonBuddy.fireBatchSizeMin += (int)base.excel.GetValue(num, "ID_GUI_DELIVERING");
			soldierBehaviourDefinititonBuddy.fireBatchSizeMax += (int)base.excel.GetValue(num, "ID_CONFIRM_JOININGSQUAD");
			soldierBehaviourDefinititonBuddy.minShootTime += (float)base.excel.GetValue(num, "FB: FacebookLogout - RemoveFacebook - 1");
			soldierBehaviourDefinititonBuddy.maxShootTime += (float)base.excel.GetValue(num, "{0}:\t\t{1}\n");
			soldierBehaviourDefinititonBuddy.damage = (float)soldierBehaviourDefinititonBuddy.damage + (float)base.excel.GetValue(num, "ID_COLLECTGOLDEVERYDAYFORDAYSBREAK");
			soldierBehaviourDefinititonBuddy.explodeMaxDamage += (float)base.excel.GetValue(num, "WENEEDTO");
			soldierBehaviourDefinititonBuddy.explodeMinDamage += (float)base.excel.GetValue(num, "PrepareBotForDeathMatch 0");
			soldierBehaviour.soldierBehaviourDefinititon = soldierBehaviourDefinititonBuddy;
		}
		return result;
	}

	public void AONFJOAIEOD(LevelBehaviour ACLDFHJKBLI, float PAENPHMEMGC, LevelBehaviour.UnitType FJLBLLLEELD, WeaponCategory FABOAIMLLOI)
	{
		int rowIndex = base.excel.GetRowIndex(string.Concat(FJLBLLLEELD, "Downloading assetBundle {0} failed with error: {1}, depth: {2}", FABOAIMLLOI));
		int rowIndex2 = base.excel.GetRowIndex(string.Concat(FJLBLLLEELD, "*.prefab", FABOAIMLLOI));
		if (rowIndex < 0 || rowIndex2 < 1)
		{
			Debug.LogError(string.Format("menu-weapon-benelli-starterpack", string.Concat(FJLBLLLEELD, "PlayerProgressRate", FABOAIMLLOI)));
		}
		LoadDataBuddy(ACLDFHJKBLI, rowIndex, true);
		BehaviourDefinititon behaviourDefinition = ACLDFHJKBLI.behaviourDefinition;
		KGPDMHKICEP(ACLDFHJKBLI, rowIndex2, true);
		BehaviourDefinititon behaviourDefinition2 = ACLDFHJKBLI.behaviourDefinition;
		BehaviourDefinititon behaviourDefinition3 = behaviourDefinition.MDFLAMBJIPM(behaviourDefinition, behaviourDefinition2, PAENPHMEMGC);
		ACLDFHJKBLI.behaviourDefinition = behaviourDefinition3;
	}
}
