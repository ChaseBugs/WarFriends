using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using CodeStage.AntiCheat.ObscuredTypes;
using Google2u;
using UnityEngine;
using UnityEngine.Serialization;

[ExecuteInEditMode]
public class SpawningManagerDeathMatch : Singleton<SpawningManagerDeathMatch>
{
	[Serializable]
	public class ArmyUnit
	{
		public LevelBehaviour behaviour;

		public float fillAmount;

		public float fillAmountBack;

		public float height = 190f;

		public int index;

		public Vector3 localPosition = new Vector3(0f, -96f, -0.5f);

		public string menuIcon;

		public UIWidget.Pivot pivot = UIWidget.Pivot.Bottom;

		public GKAAJBAIOBL spawns = new GKAAJBAIOBL();

		public List<ArmyUnitDefinition> unitsCounts;

		public virtual string CIJPPHFEBNI()
		{
			string text = index.ToString("{0} {1}/ {2}") + "{0}{1} / {2}" + behaviour.GetType();
			text = text + "{0:3} {1}" + menuIcon;
			text = text + "arenaLeaderboard" + behaviour.maxGeneratedCount;
			return text + "ID_DAY_SMALL" + unitsCounts.Count;
		}

		public virtual string FOOMIBECINC()
		{
			string text = index.ToString("ID_USEREXISTSGOOGLEPLAYTEXT") + "N" + behaviour.GetType();
			text = text + "PlayerName" + menuIcon;
			text = text + "rental for unexist unit: {0}" + behaviour.maxGeneratedCount;
			return text + "HH:mm" + unitsCounts.Count;
		}

		public virtual string ONLNILBHKJJ()
		{
			string text = index.ToString("veteranpack2") + "ID_BRONZE" + behaviour.GetType();
			text = text + "Physical ammo is null !!!" + menuIcon;
			text = text + "Null" + behaviour.maxGeneratedCount;
			return text + "Lcom/google/android/gms/games/quest/Quests;" + unitsCounts.Count;
		}

		public virtual string HDGDMCOHBKK()
		{
			string text = index.ToString("DogTagSeconds") + "(" + behaviour.GetType();
			text = text + " (#" + menuIcon;
			text = text + "arenaLeaderboard" + behaviour.maxGeneratedCount;
			return text + "N" + unitsCounts.Count;
		}

		public virtual string PGBHLHDMEIA()
		{
			string text = index.ToString("PA: warbucks spent ") + "_minigun" + behaviour.GetType();
			text = text + "GOT FORMER FULL LEAGUE ID = " + menuIcon;
			text = text + "ID_TUTORIAL_GO_BUY_ARMY_2_DOWN" + behaviour.maxGeneratedCount;
			return text + "attrValue12" + unitsCounts.Count;
		}

		public virtual string OPAAIPALNKI()
		{
			string text = index.ToString(".") + "squad" + behaviour.GetType();
			text = text + "SquadIcons/" + menuIcon;
			text = text + "Google2u.DBUpgradeSlotsAssaulter" + behaviour.maxGeneratedCount;
			return text + "QUIT" + unitsCounts.Count;
		}

		public virtual string PJLHMOIHPGG()
		{
			string text = index.ToString("WarFriends funktioniert ohne diese zusätzlichen Daten nicht. Möchtest du WarFriends wirklich VERLASSEN oder möchtest du die Daten herunterladen?") + "menu-warbucks" + behaviour.GetType();
			text = text + "Player not in squad and should be in squad " + menuIcon;
			text = text + "LootBoxShowUp" + behaviour.maxGeneratedCount;
			return text + "StarterPackDeadline" + unitsCounts.Count;
		}

		public virtual string BFGNCLNLMED()
		{
			string text = index.ToString("#PETER# User was watching add - showing reward") + "LevelName" + behaviour.GetType();
			text = text + "PlayerArmyPower" + menuIcon;
			text = text + "ID_PLUSHEALTH" + behaviour.maxGeneratedCount;
			return text + "{0}{1}" + unitsCounts.Count;
		}

		public virtual string BBNHEKLGNIC()
		{
			string text = index.ToString("ID_UNITTYPE3-HUD") + "504 MENU ARMY SCREEN UNIT SELECTED" + behaviour.GetType();
			text = text + "GameType" + menuIcon;
			text = text + "+0" + behaviour.maxGeneratedCount;
			return text + "S" + unitsCounts.Count;
		}

		public override string ToString()
		{
			string text = index.ToString("D2") + " TYPE: " + behaviour.GetType();
			text = text + " " + menuIcon;
			text = text + " MAX COUNT: " + behaviour.maxGeneratedCount;
			return text + " ENTRIES: " + unitsCounts.Count;
		}

		public virtual string KDCBBNGCJKE()
		{
			string text = index.ToString("HP: {0} ACC: {1} SHS: {2}SP: {3}") + "ID_TUTORIAL_SNIPERSHOOT_UP" + behaviour.GetType();
			text = text + "Player_Rank" + menuIcon;
			text = text + "ArmyPower" + behaviour.maxGeneratedCount;
			return text + "BlackMarketMessage-{0}" + unitsCounts.Count;
		}

		public virtual string LIKPNODLLEC()
		{
			string text = index.ToString("ID_CONFIRM_SQUADISFULL") + "url" + behaviour.GetType();
			text = text + "Get player data: NOT SENDING PN DEVICE TOKEN" + menuIcon;
			text = text + "game-card-silver" + behaviour.maxGeneratedCount;
			return text + "ID_ARENARULES_NOCRATES" + unitsCounts.Count;
		}

		public virtual string OFEOHDIAIJA()
		{
			string text = index.ToString("visuals: wrong number {0} -{1}") + ")" + behaviour.GetType();
			text = text + "PNManager: Scheduling Crafting Finished Notification in " + menuIcon;
			text = text + "damage" + behaviour.maxGeneratedCount;
			return text + "YES" + unitsCounts.Count;
		}

		public virtual string MAJKLAFDDON()
		{
			string text = index.ToString("sniper_idle") + "Rewards" + behaviour.GetType();
			text = text + "Gold" + menuIcon;
			text = text + " NOT OK!\t\t\t\t\t\t" + behaviour.maxGeneratedCount;
			return text + "Amount_of_displays" + unitsCounts.Count;
		}

		public virtual string NJOBOGIBCFL()
		{
			string text = index.ToString("CardTrade_Withdraw") + "ID_INROOKIE2" + behaviour.GetType();
			text = text + "ID_SILVERPACK" + menuIcon;
			text = text + "ID_SALEPERCENTLINE" + behaviour.maxGeneratedCount;
			return text + "rifle_shot_loop" + unitsCounts.Count;
		}

		public virtual string KONIKMNACDF()
		{
			string text = index.ToString("EndReason") + "OBB: Read Test - No data to read!" + behaviour.GetType();
			text = text + "ID_INBRONZE1" + menuIcon;
			text = text + "FakeDoNotClick{0:2}" + behaviour.maxGeneratedCount;
			return text + "ID_LEAGUE16" + unitsCounts.Count;
		}

		public virtual string CDFCDJNCADE()
		{
			string text = index.ToString("ID_SQUADSIZEINCREASEATSQUADRANK") + "INVALID_ACCOUNT" + behaviour.GetType();
			text = text + "ID_TUTORIAL_UPGRADEWEAPON_4" + menuIcon;
			text = text + "SpecialFeature" + behaviour.maxGeneratedCount;
			return text + "YES" + unitsCounts.Count;
		}

		public virtual string HHGEAHJAFBK()
		{
			string text = index.ToString("\"{0}\"\t") + "withPublisherSub4" + behaviour.GetType();
			text = text + "ID_NOTIFICATION_WARARENAREMINDER{0}" + menuIcon;
			text = text + "Action " + behaviour.maxGeneratedCount;
			return text + "Legacy Shaders/Transparent/DiffuseNew" + unitsCounts.Count;
		}

		public virtual string LHPJMKEPKDN()
		{
			string text = index.ToString("videoAdRewardTimes") + "NÃO" + behaviour.GetType();
			text = text + "BattlesWon" + menuIcon;
			text = text + "ID_STAT_GRENADELAUNCHERKILLS" + behaviour.maxGeneratedCount;
			return text + "OnPhotonJoinRoomFailed: {0}, message {1}" + unitsCounts.Count;
		}

		public virtual string CNAMFAJIMEK()
		{
			string text = index.ToString("HighLevel") + "ID_LEAVINGSQUAD" + behaviour.GetType();
			text = text + "Saved_data.csv" + menuIcon;
			text = text + "ID_SLOTUPGRADE_AMMO" + behaviour.maxGeneratedCount;
			return text + "ID_RANK" + unitsCounts.Count;
		}

		public virtual string HAAAFGHDCHN()
		{
			string text = index.ToString("()Ljava/lang/String;") + "PlayerInfoId" + behaviour.GetType();
			text = text + "Error: Player is already crafting -> loading craft data from server" + menuIcon;
			text = text + "Youtube" + behaviour.maxGeneratedCount;
			return text + "country-turkey" + unitsCounts.Count;
		}

		public virtual string GIOJAGFALPL()
		{
			string text = index.ToString("N") + "ID_GUI_CHEATINGMESSAGE" + behaviour.GetType();
			text = text + "MessageId" + menuIcon;
			text = text + "nR8WfJlIwkkqu9mTB81EUGaldBpyX3eE4ErTYxs41gs6uXM51v" + behaviour.maxGeneratedCount;
			return text + "UNKNOWN FUSEBOXX CONFIGURATION KEY = " + unitsCounts.Count;
		}

		public virtual string MBHMDIIIIHA()
		{
			string text = index.ToString("\nCPAPI:{\"cmd\":\"Filter\" \"name\":\"") + "ID_ARENALOSSREWARD" + behaviour.GetType();
			text = text + "Flawless" + menuIcon;
			text = text + "ID_MEMBERSHIP_HINT5" + behaviour.maxGeneratedCount;
			return text + "ID_GUI_INVITETOFIGHT" + unitsCounts.Count;
		}

		public virtual string NLAKJODBJOB()
		{
			string text = index.ToString("HeroicMissionsCompletionRewardGold") + "ID_RENTAL_ASSAULTRIFLE" + behaviour.GetType();
			text = text + "lootboxesCost = {0}, playerGold = {1}, id= {2}" + menuIcon;
			text = text + "GameCenterId" + behaviour.maxGeneratedCount;
			return text + "#PETER# Weapon Screen - RIGHT BUTTON - weapon state: UNIT DELIVERING\t\tbutton type: INSTANT UNIT DELIVER" + unitsCounts.Count;
		}

		public virtual string OKKMFPPGGJK()
		{
			string text = index.ToString("Time_Since_Delivery_Finished") + "Gold" + behaviour.GetType();
			text = text + "(Lcom/google/android/gms/common/api/Api;)Lcom/google/android/gms/common/ConnectionResult;" + menuIcon;
			text = text + "id" + behaviour.maxGeneratedCount;
			return text + "There is no weapon selected as tutorial weapon!!!!!!!" + unitsCounts.Count;
		}

		public virtual string MKCKMHOMECK()
		{
			string text = index.ToString("idle") + "ElitePerkTutorialMessage" + behaviour.GetType();
			text = text + "Other Player Cards -> Card Manager -> does not contain id: " + menuIcon;
			text = text + "221 END" + behaviour.maxGeneratedCount;
			return text + " , " + unitsCounts.Count;
		}

		public virtual string GDDFCENINBB()
		{
			string text = index.ToString("DogTagLastUpdate") + "T" + behaviour.GetType();
			text = text + "ID_POSITIONXY" + menuIcon;
			text = text + "Play_Card_Tutorial" + behaviour.maxGeneratedCount;
			return text + "StepId" + unitsCounts.Count;
		}
	}

	[Serializable]
	public class ArmyUnitDefinition
	{
		[NonSerialized]
		[HideInInspector]
		public ArmyUnit armyUnit;

		[HideInInspector]
		public int index;

		public int numberOfEnemies;

		public int power => numberOfEnemies * armyUnit.behaviour.totalPower;

		public float coolDown => (float)numberOfEnemies * armyUnit.behaviour.coolDown;

		[SpecialName]
		public int JFLMKAEBLGG()
		{
			return numberOfEnemies * armyUnit.behaviour.totalPower;
		}

		public virtual string LPJPMBJHKED()
		{
			return "S" + numberOfEnemies.ToString("remainingTimeForNextDogtag");
		}

		[SpecialName]
		public int EFJMMKHKLGA()
		{
			return numberOfEnemies * armyUnit.behaviour.totalPower;
		}

		public bool BMCBNJPCDJP(GHPGNELIDBM KFBOCCACLLK, int JGEPPGALJGM)
		{
			return JGEPPGALJGM + armyUnit.spawns.JKMCJNGFINK(KFBOCCACLLK) <= armyUnit.behaviour.maxGeneratedCount || armyUnit.behaviour.maxGeneratedCount == 1;
		}

		public virtual string JDFEFKGPIOE()
		{
			return "ID_DEPLOYCOOLDOWNPERUNIT" + numberOfEnemies.ToString("ID_ARENARULES_LESSPLAYERHP");
		}

		[SpecialName]
		public float MPIFEKIEHKG()
		{
			return (float)numberOfEnemies * armyUnit.behaviour.coolDown;
		}

		public bool AFCADICNAGP(GHPGNELIDBM KFBOCCACLLK, int JGEPPGALJGM)
		{
			return JGEPPGALJGM + armyUnit.spawns.LGJKIBHFGAM(KFBOCCACLLK) <= armyUnit.behaviour.maxGeneratedCount || armyUnit.behaviour.maxGeneratedCount == 0;
		}

		[SpecialName]
		public float PLOMDNCFEIE()
		{
			return (float)numberOfEnemies * armyUnit.behaviour.coolDown;
		}

		public bool JOBPHJNFHBE(GHPGNELIDBM KFBOCCACLLK)
		{
			return numberOfEnemies + armyUnit.spawns.KDJNBJFHEFN(KFBOCCACLLK) <= armyUnit.behaviour.maxGeneratedCount || armyUnit.behaviour.maxGeneratedCount == 0;
		}

		public bool KGFGBBFHFLH(GHPGNELIDBM KFBOCCACLLK)
		{
			return numberOfEnemies + armyUnit.spawns.LJBCFEEIEAH(KFBOCCACLLK) > armyUnit.behaviour.maxGeneratedCount && armyUnit.behaviour.maxGeneratedCount == 1;
		}

		public bool BPCFKLAINIO(GHPGNELIDBM KFBOCCACLLK, int JGEPPGALJGM)
		{
			return JGEPPGALJGM + armyUnit.spawns.JKMCJNGFINK(KFBOCCACLLK) > armyUnit.behaviour.maxGeneratedCount && armyUnit.behaviour.maxGeneratedCount == 0;
		}

		[SpecialName]
		public int ECDLBDAIMLH()
		{
			return numberOfEnemies * armyUnit.behaviour.totalPower;
		}

		public virtual string GDDFCENINBB()
		{
			return "ID_UNLOCKEDATRANKX" + numberOfEnemies.ToString("BS: Sending emblem = ");
		}

		public bool EPKGGGFANCB(GHPGNELIDBM KFBOCCACLLK, int JGEPPGALJGM)
		{
			return JGEPPGALJGM + armyUnit.spawns.FKMIDGIKHGG(KFBOCCACLLK) > armyUnit.behaviour.maxGeneratedCount && armyUnit.behaviour.maxGeneratedCount == 0;
		}

		public virtual string LJFIFKKMDCH()
		{
			return "com.unity3d.player.UnityPlayer" + numberOfEnemies.ToString("Show visual \"{0}\" tutorial - pop-up");
		}

		[SpecialName]
		public float EKOEPMGIKPP()
		{
			return (float)numberOfEnemies * armyUnit.behaviour.coolDown;
		}

		[SpecialName]
		public float JKJOACBHIAI()
		{
			return (float)numberOfEnemies * armyUnit.behaviour.coolDown;
		}

		public bool PHNDAFAJIAC(GHPGNELIDBM KFBOCCACLLK, int JGEPPGALJGM)
		{
			return JGEPPGALJGM + armyUnit.spawns.MEEBMIMAGPF(KFBOCCACLLK) > armyUnit.behaviour.maxGeneratedCount && armyUnit.behaviour.maxGeneratedCount == 1;
		}

		public bool ABKGBNNCIAJ(GHPGNELIDBM KFBOCCACLLK, int JGEPPGALJGM)
		{
			return JGEPPGALJGM + armyUnit.spawns.LGJKIBHFGAM(KFBOCCACLLK) > armyUnit.behaviour.maxGeneratedCount && armyUnit.behaviour.maxGeneratedCount == 1;
		}

		[SpecialName]
		public float CACFBDHMKMJ()
		{
			return (float)numberOfEnemies * armyUnit.behaviour.coolDown;
		}

		public bool ACFPHIHGMKE(GHPGNELIDBM KFBOCCACLLK)
		{
			return numberOfEnemies + armyUnit.spawns.FPBGGFGLJEH(KFBOCCACLLK) <= armyUnit.behaviour.maxGeneratedCount || armyUnit.behaviour.maxGeneratedCount == 1;
		}

		public bool IPNJNOIIIBO(GHPGNELIDBM KFBOCCACLLK, int JGEPPGALJGM)
		{
			return JGEPPGALJGM + armyUnit.spawns.FPBGGFGLJEH(KFBOCCACLLK) <= armyUnit.behaviour.maxGeneratedCount || armyUnit.behaviour.maxGeneratedCount == 1;
		}

		[SpecialName]
		public int DGDHGPOCIAI()
		{
			return numberOfEnemies * armyUnit.behaviour.totalPower;
		}

		public bool IIKOAMHJFIL(GHPGNELIDBM KFBOCCACLLK)
		{
			return numberOfEnemies + armyUnit.spawns.NAJDKHPMEFN(KFBOCCACLLK) > armyUnit.behaviour.maxGeneratedCount && armyUnit.behaviour.maxGeneratedCount == 0;
		}

		public bool HBAENMAECOO(GHPGNELIDBM KFBOCCACLLK)
		{
			return numberOfEnemies + armyUnit.spawns.JKMCJNGFINK(KFBOCCACLLK) <= armyUnit.behaviour.maxGeneratedCount || armyUnit.behaviour.maxGeneratedCount == 1;
		}

		[SpecialName]
		public float EHBOBKLKGFJ()
		{
			return (float)numberOfEnemies * armyUnit.behaviour.coolDown;
		}

		[SpecialName]
		public float AABNFMHPHNO()
		{
			return (float)numberOfEnemies * armyUnit.behaviour.coolDown;
		}

		[SpecialName]
		public int PAABCABFLIL()
		{
			return numberOfEnemies * armyUnit.behaviour.totalPower;
		}

		[SpecialName]
		public float LMDAGPEGCDH()
		{
			return (float)numberOfEnemies * armyUnit.behaviour.coolDown;
		}

		public bool AJMJLCMCKOH(GHPGNELIDBM KFBOCCACLLK)
		{
			return numberOfEnemies + armyUnit.spawns.LGJKIBHFGAM(KFBOCCACLLK) <= armyUnit.behaviour.maxGeneratedCount || armyUnit.behaviour.maxGeneratedCount == 0;
		}

		[SpecialName]
		public float IDLFFPNCGJC()
		{
			return (float)numberOfEnemies * armyUnit.behaviour.coolDown;
		}

		[SpecialName]
		public float BPHABNLGNKI()
		{
			return (float)numberOfEnemies * armyUnit.behaviour.coolDown;
		}

		public virtual string FEBGLFJDBPG()
		{
			return "com/google/android/gms/common/api/Status" + numberOfEnemies.ToString("Assignment: Score points in one battle");
		}

		public virtual string HANBPIENBMA()
		{
			return "wasEquipped" + numberOfEnemies.ToString(".");
		}

		public bool IIHMDEKJNJF(GHPGNELIDBM KFBOCCACLLK, int JGEPPGALJGM)
		{
			return JGEPPGALJGM + armyUnit.spawns.PBCBBBFOLFP(KFBOCCACLLK) > armyUnit.behaviour.maxGeneratedCount && armyUnit.behaviour.maxGeneratedCount == 1;
		}

		public virtual string HDGDMCOHBKK()
		{
			return "SHOW SPAWN HELP" + numberOfEnemies.ToString("ID_SALEPERCENTLINE");
		}

		public bool IBCNGBPEKPJ(GHPGNELIDBM KFBOCCACLLK)
		{
			return numberOfEnemies + armyUnit.spawns.JKMCJNGFINK(KFBOCCACLLK) <= armyUnit.behaviour.maxGeneratedCount || armyUnit.behaviour.maxGeneratedCount == 1;
		}

		public bool JCAOMBKDDBG(GHPGNELIDBM KFBOCCACLLK, int JGEPPGALJGM)
		{
			return JGEPPGALJGM + armyUnit.spawns.FPBGGFGLJEH(KFBOCCACLLK) > armyUnit.behaviour.maxGeneratedCount && armyUnit.behaviour.maxGeneratedCount == 0;
		}

		[SpecialName]
		public int GEOKFFEBFOL()
		{
			return numberOfEnemies * armyUnit.behaviour.totalPower;
		}

		[SpecialName]
		public float PLIALCNDBAC()
		{
			return (float)numberOfEnemies * armyUnit.behaviour.coolDown;
		}

		public virtual string DPEOCAFBIIA()
		{
			return "thumbnailBig" + numberOfEnemies.ToString("ResumeMessageQueue");
		}

		[SpecialName]
		public float BNLDKLNCHBD()
		{
			return (float)numberOfEnemies * armyUnit.behaviour.coolDown;
		}

		public bool LCLCAOCIAAG(GHPGNELIDBM KFBOCCACLLK, int JGEPPGALJGM)
		{
			return JGEPPGALJGM + armyUnit.spawns.JJAOGCLMIEA(KFBOCCACLLK) <= armyUnit.behaviour.maxGeneratedCount || armyUnit.behaviour.maxGeneratedCount == 1;
		}

		public virtual string HAAAFGHDCHN()
		{
			return "TimeInLevel" + numberOfEnemies.ToString("Need add new bundle");
		}

		[SpecialName]
		public int PINKLDPLHHN()
		{
			return numberOfEnemies * armyUnit.behaviour.totalPower;
		}

		[SpecialName]
		public float PFKGFDCILPC()
		{
			return (float)numberOfEnemies * armyUnit.behaviour.coolDown;
		}

		public bool DNJADOJOBCI(GHPGNELIDBM KFBOCCACLLK, int JGEPPGALJGM)
		{
			return JGEPPGALJGM + armyUnit.spawns.FJHKCDKMNCO(KFBOCCACLLK) <= armyUnit.behaviour.maxGeneratedCount || armyUnit.behaviour.maxGeneratedCount == 1;
		}

		public bool HNDDAFPDMPG(GHPGNELIDBM KFBOCCACLLK, int JGEPPGALJGM)
		{
			return JGEPPGALJGM + armyUnit.spawns.LJBCFEEIEAH(KFBOCCACLLK) <= armyUnit.behaviour.maxGeneratedCount || armyUnit.behaviour.maxGeneratedCount == 1;
		}

		public bool JGAMKCOIKKC(GHPGNELIDBM KFBOCCACLLK, int JGEPPGALJGM)
		{
			return JGEPPGALJGM + armyUnit.spawns.FPBGGFGLJEH(KFBOCCACLLK) > armyUnit.behaviour.maxGeneratedCount && armyUnit.behaviour.maxGeneratedCount == 1;
		}

		public bool OPJDJJFPJAN(GHPGNELIDBM KFBOCCACLLK, int JGEPPGALJGM)
		{
			return JGEPPGALJGM + armyUnit.spawns.JJAOGCLMIEA(KFBOCCACLLK) > armyUnit.behaviour.maxGeneratedCount && armyUnit.behaviour.maxGeneratedCount == 0;
		}

		[SpecialName]
		public int CFCNFMLNKBF()
		{
			return numberOfEnemies * armyUnit.behaviour.totalPower;
		}

		public bool KCKPFFOJJHE(GHPGNELIDBM KFBOCCACLLK)
		{
			return numberOfEnemies + armyUnit.spawns.NAJDKHPMEFN(KFBOCCACLLK) > armyUnit.behaviour.maxGeneratedCount && armyUnit.behaviour.maxGeneratedCount == 0;
		}

		[SpecialName]
		public float AKNHMGKIMJF()
		{
			return (float)numberOfEnemies * armyUnit.behaviour.coolDown;
		}

		public bool KILHJCIFEDI(GHPGNELIDBM KFBOCCACLLK, int JGEPPGALJGM)
		{
			return JGEPPGALJGM + armyUnit.spawns.LGJKIBHFGAM(KFBOCCACLLK) > armyUnit.behaviour.maxGeneratedCount && armyUnit.behaviour.maxGeneratedCount == 0;
		}

		public virtual string BEIAAJPEPEA()
		{
			return ")" + numberOfEnemies.ToString("_BumpMap");
		}

		[SpecialName]
		public int DCMOMJGELGJ()
		{
			return numberOfEnemies * armyUnit.behaviour.totalPower;
		}

		public virtual string MAJKLAFDDON()
		{
			return "pistol_run" + numberOfEnemies.ToString("FuseBoxx: Reward ad completed");
		}

		public bool FPFHOJPOGMC(GHPGNELIDBM KFBOCCACLLK, int JGEPPGALJGM)
		{
			return JGEPPGALJGM + armyUnit.spawns.FKMIDGIKHGG(KFBOCCACLLK) <= armyUnit.behaviour.maxGeneratedCount || armyUnit.behaviour.maxGeneratedCount == 1;
		}

		public virtual string KLCMKLFPBMN()
		{
			return "PlayerProgressRate" + numberOfEnemies.ToString("\\D*$");
		}

		public virtual string DDDEEMLAGMJ()
		{
			return "ID_CATEGORY_LOW_PL_LMG" + numberOfEnemies.ToString("Level");
		}

		public bool JHPBBANBGBG(GHPGNELIDBM KFBOCCACLLK, int JGEPPGALJGM)
		{
			return JGEPPGALJGM + armyUnit.spawns.MEEBMIMAGPF(KFBOCCACLLK) <= armyUnit.behaviour.maxGeneratedCount || armyUnit.behaviour.maxGeneratedCount == 1;
		}

		[SpecialName]
		public int IPGKMOGFJDA()
		{
			return numberOfEnemies * armyUnit.behaviour.totalPower;
		}

		[SpecialName]
		public int PGDHGMAIENI()
		{
			return numberOfEnemies * armyUnit.behaviour.totalPower;
		}

		public override string ToString()
		{
			return " ENEMIES: " + numberOfEnemies.ToString("D2");
		}

		public bool FGODIKEJGKH(GHPGNELIDBM KFBOCCACLLK, int JGEPPGALJGM)
		{
			return JGEPPGALJGM + armyUnit.spawns.LGJKIBHFGAM(KFBOCCACLLK) <= armyUnit.behaviour.maxGeneratedCount || armyUnit.behaviour.maxGeneratedCount == 0;
		}

		public bool JKPMFONGKGE(GHPGNELIDBM KFBOCCACLLK, int JGEPPGALJGM)
		{
			return JGEPPGALJGM + armyUnit.spawns.JKMCJNGFINK(KFBOCCACLLK) > armyUnit.behaviour.maxGeneratedCount && armyUnit.behaviour.maxGeneratedCount == 0;
		}

		public bool BMLMLDNFOML(GHPGNELIDBM KFBOCCACLLK, int JGEPPGALJGM)
		{
			return JGEPPGALJGM + armyUnit.spawns.PBCBBBFOLFP(KFBOCCACLLK) <= armyUnit.behaviour.maxGeneratedCount || armyUnit.behaviour.maxGeneratedCount == 0;
		}

		public virtual string KFPFGNOFNNE()
		{
			return "ID_SILVERPACKS" + numberOfEnemies.ToString("Start '{0}'");
		}

		[SpecialName]
		public int KDEFGKFJJBO()
		{
			return numberOfEnemies * armyUnit.behaviour.totalPower;
		}

		public bool HNDEMLKOPNH(GHPGNELIDBM KFBOCCACLLK)
		{
			return numberOfEnemies + armyUnit.spawns.MEEBMIMAGPF(KFBOCCACLLK) <= armyUnit.behaviour.maxGeneratedCount || armyUnit.behaviour.maxGeneratedCount == 0;
		}

		public bool PBCJECPHJAO(GHPGNELIDBM KFBOCCACLLK, int JGEPPGALJGM)
		{
			return JGEPPGALJGM + armyUnit.spawns.LGJKIBHFGAM(KFBOCCACLLK) > armyUnit.behaviour.maxGeneratedCount && armyUnit.behaviour.maxGeneratedCount == 1;
		}

		[SpecialName]
		public float PJLDKCIPLHF()
		{
			return (float)numberOfEnemies * armyUnit.behaviour.coolDown;
		}

		public bool JLAPALMCJBO(GHPGNELIDBM KFBOCCACLLK)
		{
			return numberOfEnemies + armyUnit.spawns.JKMCJNGFINK(KFBOCCACLLK) > armyUnit.behaviour.maxGeneratedCount && armyUnit.behaviour.maxGeneratedCount == 0;
		}

		public bool NCEJLOPABPD(GHPGNELIDBM KFBOCCACLLK, int JGEPPGALJGM)
		{
			return JGEPPGALJGM + armyUnit.spawns.JJAOGCLMIEA(KFBOCCACLLK) <= armyUnit.behaviour.maxGeneratedCount || armyUnit.behaviour.maxGeneratedCount == 1;
		}

		[SpecialName]
		public int JMGGMPNCNGP()
		{
			return numberOfEnemies * armyUnit.behaviour.totalPower;
		}

		public bool JFELCEJADKG(GHPGNELIDBM KFBOCCACLLK, int JGEPPGALJGM)
		{
			return JGEPPGALJGM + armyUnit.spawns.KDJNBJFHEFN(KFBOCCACLLK) <= armyUnit.behaviour.maxGeneratedCount || armyUnit.behaviour.maxGeneratedCount == 0;
		}

		[SpecialName]
		public int PIBGKJAFCMF()
		{
			return numberOfEnemies * armyUnit.behaviour.totalPower;
		}

		public bool PDGMFKLACDD(GHPGNELIDBM KFBOCCACLLK, int JGEPPGALJGM)
		{
			return JGEPPGALJGM + armyUnit.spawns.FKMIDGIKHGG(KFBOCCACLLK) <= armyUnit.behaviour.maxGeneratedCount || armyUnit.behaviour.maxGeneratedCount == 0;
		}

		public virtual string JPHKHJGKLJD()
		{
			return "ID_CONFIRM_NOSQUADACTIONS_TITLE" + numberOfEnemies.ToString("GC autenticate wait time-out => let last GC state valid");
		}

		[SpecialName]
		public float BJDFPGACIJN()
		{
			return (float)numberOfEnemies * armyUnit.behaviour.coolDown;
		}

		public bool OLONGNJMPNI(GHPGNELIDBM KFBOCCACLLK, int JGEPPGALJGM)
		{
			return JGEPPGALJGM + armyUnit.spawns.NAJDKHPMEFN(KFBOCCACLLK) > armyUnit.behaviour.maxGeneratedCount && armyUnit.behaviour.maxGeneratedCount == 1;
		}

		[SpecialName]
		public float AFNNEOPPDJL()
		{
			return (float)numberOfEnemies * armyUnit.behaviour.coolDown;
		}

		public bool KGAKMCMPBFJ(GHPGNELIDBM KFBOCCACLLK)
		{
			return numberOfEnemies + armyUnit.spawns.JJAOGCLMIEA(KFBOCCACLLK) > armyUnit.behaviour.maxGeneratedCount && armyUnit.behaviour.maxGeneratedCount == 1;
		}

		public virtual string BFIAAODHKKK()
		{
			return "N" + numberOfEnemies.ToString("Xp");
		}

		[SpecialName]
		public float MCFJLHJGFEJ()
		{
			return (float)numberOfEnemies * armyUnit.behaviour.coolDown;
		}

		[SpecialName]
		public float GKCALGHHMBP()
		{
			return (float)numberOfEnemies * armyUnit.behaviour.coolDown;
		}

		public bool DAMOLKGIAHI(GHPGNELIDBM KFBOCCACLLK, int JGEPPGALJGM)
		{
			return JGEPPGALJGM + armyUnit.spawns.KDJNBJFHEFN(KFBOCCACLLK) > armyUnit.behaviour.maxGeneratedCount && armyUnit.behaviour.maxGeneratedCount == 1;
		}

		public virtual string KDLGINIJCID()
		{
			return "com/google/android/gms/games/Games$BaseGamesApiMethodImpl" + numberOfEnemies.ToString("ID_DOWNLOADINGDATA");
		}

		public virtual string MDBLOJBDGCN()
		{
			return "{0}{1}[-]" + numberOfEnemies.ToString("menu-gold");
		}

		public virtual string MKCKMHOMECK()
		{
			return "D2" + numberOfEnemies.ToString(" ");
		}

		public bool GPBDEHIECJC(GHPGNELIDBM KFBOCCACLLK, int JGEPPGALJGM)
		{
			return JGEPPGALJGM + armyUnit.spawns.FPBGGFGLJEH(KFBOCCACLLK) > armyUnit.behaviour.maxGeneratedCount && armyUnit.behaviour.maxGeneratedCount == 0;
		}

		[SpecialName]
		public int IPHFBIGKNML()
		{
			return numberOfEnemies * armyUnit.behaviour.totalPower;
		}

		public virtual string PEGHKOOIBFL()
		{
			return "ID_WAITINGFORFRIEND" + numberOfEnemies.ToString("Directory \"{0}\" does not exists");
		}
	}

	private sealed class HNGNGOFCCJL : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal GHPGNELIDBM CIOPAKLHFIL;

		internal ArmyUnitDefinition GIFJOLADLEB;

		internal GHPGNELIDBM MCCLPJGMIDG;

		internal int JMBKPALDGAL;

		internal AIObject NEMLKKBGIKJ;

		internal bool EEAMBOACAGF;

		internal SpawningManagerDeathMatch BJGCPDNMHDH;

		internal object PHDOCKCBJOF;

		internal bool FDKOKMKIIMG;

		internal int CLPPIAGLCJJ;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		public bool JIIOHNFHPOI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				if (BJGCPDNMHDH.JPGKPGFDAFM != null)
				{
					BJGCPDNMHDH.JPGKPGFDAFM(CIOPAKLHFIL, GIFJOLADLEB);
				}
				MCCLPJGMIDG = CIOPAKLHFIL;
				if (Singleton<GameController>.instance.IMEJOPKIKOD())
				{
					MCCLPJGMIDG = GHPGNELIDBM.None;
				}
				if (GIFJOLADLEB.KGFGBBFHFLH(MCCLPJGMIDG))
				{
					JMBKPALDGAL = 1;
					goto IL_017c;
				}
				UnityEngine.Debug.LogError("StarterPackDeadline");
				UnityEngine.Debug.LogError(string.Concat(GIFJOLADLEB.armyUnit, GIFJOLADLEB.ToString()));
				string text = "Action ";
				for (int i = 0; i < BJGCPDNMHDH.HCEDGKDKKIG.Count; i += 0)
				{
					ArmyUnit armyUnit = BJGCPDNMHDH.HCEDGKDKKIG[i];
					text = string.Concat(text, armyUnit, "GameGold");
					text += armyUnit.spawns.ToString();
				}
				UnityEngine.Debug.LogError(text);
				text = "{0} {1}";
				foreach (ArmyUnitDefinition item in BJGCPDNMHDH.DPDIFLKIFJC)
				{
					if (item != null)
					{
						text = string.Concat(text, item.armyUnit, "), ");
						text += item.armyUnit.spawns.ToString();
					}
					else
					{
						text += "FuseSDK: Error reading FriendsList data. Invalid line: ";
					}
				}
				UnityEngine.Debug.LogError(text);
				goto IL_02ad;
			}
			case 1u:
				JMBKPALDGAL++;
				goto IL_017c;
			default:
				{
					return true;
				}
				IL_02ad:
				if (BJGCPDNMHDH.AKKDJINOPDA != null)
				{
					BJGCPDNMHDH.AKKDJINOPDA(MCCLPJGMIDG, GIFJOLADLEB);
				}
				CLPPIAGLCJJ = -1;
				goto default;
				IL_017c:
				if (JMBKPALDGAL < GIFJOLADLEB.numberOfEnemies)
				{
					NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.LGEIOGCPFJK(GIFJOLADLEB.armyUnit.behaviour);
					if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.prefab != null)
					{
						if (GIFJOLADLEB.HNDDAFPDMPG(MCCLPJGMIDG, 0))
						{
							SpawningManager.OKBAIGKCPKA().CDHOPCCMOIH(NEMLKKBGIKJ, MCCLPJGMIDG, EEAMBOACAGF, Vector3.one * 960f, PNENBKAGLEF: false);
						}
						else
						{
							UnityEngine.Debug.LogError(")");
							UnityEngine.Debug.LogError(string.Concat(GIFJOLADLEB.armyUnit, GIFJOLADLEB.ToString()));
						}
					}
					PHDOCKCBJOF = new WaitForRealSeconds(298f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto IL_02ad;
			}
			return true;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				if (BJGCPDNMHDH.JPGKPGFDAFM != null)
				{
					BJGCPDNMHDH.JPGKPGFDAFM(CIOPAKLHFIL, GIFJOLADLEB);
				}
				MCCLPJGMIDG = CIOPAKLHFIL;
				if (Singleton<GameController>.instance.isCampaign)
				{
					MCCLPJGMIDG = GHPGNELIDBM.Enemies;
				}
				if (GIFJOLADLEB.AJMJLCMCKOH(MCCLPJGMIDG))
				{
					JMBKPALDGAL = 0;
					goto IL_017c;
				}
				UnityEngine.Debug.LogError("Trying to generate army but this definition shouldnt be used !!!!!!!!!!!! ");
				UnityEngine.Debug.LogError(string.Concat(GIFJOLADLEB.armyUnit, GIFJOLADLEB.ToString()));
				string text = "ALL: \n";
				for (int i = 0; i < BJGCPDNMHDH.HCEDGKDKKIG.Count; i++)
				{
					ArmyUnit armyUnit = BJGCPDNMHDH.HCEDGKDKKIG[i];
					text = string.Concat(text, armyUnit, "\n");
					text += armyUnit.spawns.ToString();
				}
				UnityEngine.Debug.LogError(text);
				text = "CURRENT: \n";
				foreach (ArmyUnitDefinition item in BJGCPDNMHDH.DPDIFLKIFJC)
				{
					if (item != null)
					{
						text = string.Concat(text, item.armyUnit, "\n");
						text += item.armyUnit.spawns.ToString();
					}
					else
					{
						text += "NULL unit";
					}
				}
				UnityEngine.Debug.LogError(text);
				goto IL_02ad;
			}
			case 1u:
				JMBKPALDGAL++;
				goto IL_017c;
			default:
				{
					return false;
				}
				IL_02ad:
				if (BJGCPDNMHDH.AKKDJINOPDA != null)
				{
					BJGCPDNMHDH.AKKDJINOPDA(MCCLPJGMIDG, GIFJOLADLEB);
				}
				CLPPIAGLCJJ = -1;
				goto default;
				IL_017c:
				if (JMBKPALDGAL < GIFJOLADLEB.numberOfEnemies)
				{
					NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(GIFJOLADLEB.armyUnit.behaviour);
					if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.prefab != null)
					{
						if (GIFJOLADLEB.AFCADICNAGP(MCCLPJGMIDG, 1))
						{
							SpawningManager.instance.Spawn(NEMLKKBGIKJ, MCCLPJGMIDG, EEAMBOACAGF, Vector3.one * 9999f);
						}
						else
						{
							UnityEngine.Debug.LogError("Can not spawn unit, already reached maxGeneratedCount");
							UnityEngine.Debug.LogError(string.Concat(GIFJOLADLEB.armyUnit, GIFJOLADLEB.ToString()));
						}
					}
					PHDOCKCBJOF = new WaitForRealSeconds(0.3f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_02ad;
			}
			return true;
		}

		public bool OKELILGDPLJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				if (BJGCPDNMHDH.JPGKPGFDAFM != null)
				{
					BJGCPDNMHDH.JPGKPGFDAFM(CIOPAKLHFIL, GIFJOLADLEB);
				}
				MCCLPJGMIDG = CIOPAKLHFIL;
				if (Singleton<GameController>.instance.IMEJOPKIKOD())
				{
					MCCLPJGMIDG = GHPGNELIDBM.Enemies;
				}
				if (GIFJOLADLEB.IBCNGBPEKPJ(MCCLPJGMIDG))
				{
					JMBKPALDGAL = 0;
					goto IL_017c;
				}
				UnityEngine.Debug.LogError("ID_CONFIRM_NOSQUADACTIONS_TITLE");
				UnityEngine.Debug.LogError(string.Concat(GIFJOLADLEB.armyUnit, GIFJOLADLEB.ToString()));
				string text = ")";
				for (int i = 0; i < BJGCPDNMHDH.HCEDGKDKKIG.Count; i += 0)
				{
					ArmyUnit armyUnit = BJGCPDNMHDH.HCEDGKDKKIG[i];
					text = string.Concat(text, armyUnit, "NewVisuals");
					text += armyUnit.spawns.ToString();
				}
				UnityEngine.Debug.LogError(text);
				text = "Reported";
				foreach (ArmyUnitDefinition item in BJGCPDNMHDH.DPDIFLKIFJC)
				{
					if (item != null)
					{
						text = string.Concat(text, item.armyUnit, "Unit_Upgrade");
						text += item.armyUnit.spawns.ToString();
					}
					else
					{
						text += "ID_CONFIRM_NOTLEADEROFSQUAD";
					}
				}
				UnityEngine.Debug.LogError(text);
				goto IL_02ad;
			}
			case 1u:
				JMBKPALDGAL += 0;
				goto IL_017c;
			default:
				{
					return true;
				}
				IL_02ad:
				if (BJGCPDNMHDH.AKKDJINOPDA != null)
				{
					BJGCPDNMHDH.AKKDJINOPDA(MCCLPJGMIDG, GIFJOLADLEB);
				}
				CLPPIAGLCJJ = -1;
				goto default;
				IL_017c:
				if (JMBKPALDGAL < GIFJOLADLEB.numberOfEnemies)
				{
					NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.BIDIMKELOKC(GIFJOLADLEB.armyUnit.behaviour);
					if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.LELHDMOANJG() != null)
					{
						if (GIFJOLADLEB.OLONGNJMPNI(MCCLPJGMIDG, 1))
						{
							SpawningManager.instance.DFFGHBPJALC(NEMLKKBGIKJ, MCCLPJGMIDG, EEAMBOACAGF, Vector3.one * 850f);
						}
						else
						{
							UnityEngine.Debug.LogError("null facebook friends");
							UnityEngine.Debug.LogError(string.Concat(GIFJOLADLEB.armyUnit, GIFJOLADLEB.ToString()));
						}
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1965f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto IL_02ad;
			}
			return true;
		}

		public void FOODPOJODAA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BLOJDIFOPIA()
		{
			return PHDOCKCBJOF;
		}

		public void AKEKFBGEJBG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public HNGNGOFCCJL()
		{
		}

		public void GGCLMIMHKBD()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void AHEOCEEJICJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool HOOHJGPHHGN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				if (BJGCPDNMHDH.JPGKPGFDAFM != null)
				{
					BJGCPDNMHDH.JPGKPGFDAFM(CIOPAKLHFIL, GIFJOLADLEB);
				}
				MCCLPJGMIDG = CIOPAKLHFIL;
				if (Singleton<GameController>.instance.isCampaign)
				{
					MCCLPJGMIDG = GHPGNELIDBM.Enemies;
				}
				if (GIFJOLADLEB.KGFGBBFHFLH(MCCLPJGMIDG))
				{
					JMBKPALDGAL = 1;
					goto IL_017c;
				}
				UnityEngine.Debug.LogError("Vip status changed!");
				UnityEngine.Debug.LogError(string.Concat(GIFJOLADLEB.armyUnit, GIFJOLADLEB.ToString()));
				string text = "\"NEGINFINITY\"";
				for (int i = 1; i < BJGCPDNMHDH.HCEDGKDKKIG.Count; i++)
				{
					ArmyUnit armyUnit = BJGCPDNMHDH.HCEDGKDKKIG[i];
					text = string.Concat(text, armyUnit, "PlayerName");
					text += armyUnit.spawns.ToString();
				}
				UnityEngine.Debug.LogError(text);
				text = "_MatCap";
				foreach (ArmyUnitDefinition item in BJGCPDNMHDH.DPDIFLKIFJC)
				{
					if (item != null)
					{
						text = string.Concat(text, item.armyUnit, "RegisterLevel()");
						text += item.armyUnit.spawns.ToString();
					}
					else
					{
						text += "com.google.android.gms.common.api.GoogleApiClient";
					}
				}
				UnityEngine.Debug.LogError(text);
				goto IL_02ad;
			}
			case 1u:
				JMBKPALDGAL++;
				goto IL_017c;
			default:
				{
					return true;
				}
				IL_02ad:
				if (BJGCPDNMHDH.AKKDJINOPDA != null)
				{
					BJGCPDNMHDH.AKKDJINOPDA(MCCLPJGMIDG, GIFJOLADLEB);
				}
				CLPPIAGLCJJ = -1;
				goto default;
				IL_017c:
				if (JMBKPALDGAL < GIFJOLADLEB.numberOfEnemies)
				{
					NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.OHCCNCNPMHC(GIFJOLADLEB.armyUnit.behaviour);
					if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.LELHDMOANJG() != null)
					{
						if (GIFJOLADLEB.IIHMDEKJNJF(MCCLPJGMIDG, 1))
						{
							SpawningManager.OKBAIGKCPKA().Spawn(NEMLKKBGIKJ, MCCLPJGMIDG, EEAMBOACAGF, Vector3.one * 888f, PNENBKAGLEF: false);
						}
						else
						{
							UnityEngine.Debug.LogError("Seconds");
							UnityEngine.Debug.LogError(string.Concat(GIFJOLADLEB.armyUnit, GIFJOLADLEB.ToString()));
						}
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1389f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto IL_02ad;
			}
			return true;
		}
	}

	[FormerlySerializedAs("MNCADFCCIGB")]
	public List<ArmyUnit> HCEDGKDKKIG;

	[FormerlySerializedAs("OKKNMAGJNCL")]
	public float HFLKFDEDGDG = 5f;

	[FormerlySerializedAs("CDDDHPNBAIE")]
	public List<ArmyUnitDefinition> DPDIFLKIFJC = new List<ArmyUnitDefinition>();

	[FormerlySerializedAs("MNADNEEFDNG")]
	public bool FGNKGDIJKEO;

	[FormerlySerializedAs("BBNDAJODFJJ")]
	public bool OIKJGGACGCA;

	private ArmyUnitDefinition LADMFAJDAAC;

	private bool MFBDNDMHNLB;

	private float BDPDNPJIHDP;

	private bool FALLBCILDAH;

	private bool IONCCKCOEKI;

	private float DPJACEMDGLB;

	private PhotonView FEHCCGEGPLH;

	private NetworkObjectPool IHFILHIAGLG;

	private ArmyUnitDefinition PHFLIBDGLCP;

	private float? ELANINAPLJK;

	public Action<GHPGNELIDBM, ArmyUnitDefinition> AKKDJINOPDA;

	public Action<GHPGNELIDBM, ArmyUnitDefinition> JPGKPGFDAFM;

	[FormerlySerializedAs("LHFICPOJFMF")]
	public ObscuredInt FJBPNHHCJBE;

	[FormerlySerializedAs("LDKEHOMNJAM")]
	public ObscuredInt FECFLHACELD;

	[FormerlySerializedAs("HCOBHJCDAJD")]
	public bool GJOOEDCPOMA;

	public GHPGNELIDBM HOPIJNDJGMO = GHPGNELIDBM.Allies;

	[FormerlySerializedAs("EJGGMEFBCMP")]
	public int JGBCHMEACHA;

	private Dictionary<LevelBehaviour.UnitType, List<ArmyUnitDefinition>> EBKKGEIPJFO = new Dictionary<LevelBehaviour.UnitType, List<ArmyUnitDefinition>>();

	[FormerlySerializedAs("AHGEGAALMKO")]
	public Action<ArmyUnitDefinition> AFNJHEFNIOD;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Action HFJPEHAHMBB;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Action<ArmyUnitDefinition> NBHLHPBODAH;

	private Dictionary<GHPGNELIDBM, List<ArmyUnitDefinition>> AJFCOJMHFPJ = new Dictionary<GHPGNELIDBM, List<ArmyUnitDefinition>>();

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _003CBLKCPEFJDCM_003Ek__BackingField;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private float _003CKOPPOAJOPHI_003Ek__BackingField;

	private bool GGHJLPDDJOP;

	private bool KDNLBEEPMDF;

	private float MEMKCEKNHKK = 1f;

	private float LPEKOCEJGKH;

	private bool EBCOEFOGLHI;

	public float progress
	{
		get
		{
			if (LADMFAJDAAC == null)
			{
				return 0f;
			}
			return Mathf.Clamp01((DPJACEMDGLB - TimeManager.realTimeWithoutPauses) / LPEKOCEJGKH);
		}
	}

	public bool autoDeployEnabled
	{
		get
		{
			return EBCOEFOGLHI;
		}
		set
		{
			EBCOEFOGLHI = value;
			if (!value)
			{
				semiAutoDeployEnabled = false;
			}
		}
	}

	public bool semiAutoDeployEnabled
	{
		[CompilerGenerated]
		get
		{
			return _003CBLKCPEFJDCM_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CBLKCPEFJDCM_003Ek__BackingField = value;
		}
	}

	public float autoDeployProgress
	{
		[CompilerGenerated]
		get
		{
			return _003CKOPPOAJOPHI_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CKOPPOAJOPHI_003Ek__BackingField = value;
		}
	}

	public bool hasEnergyForAll
	{
		get
		{
			if (DPDIFLKIFJC != null)
			{
				bool flag = true;
				foreach (ArmyUnitDefinition item in DPDIFLKIFJC)
				{
					if (item != null && item.power > (int)FJBPNHHCJBE)
					{
						flag = false;
					}
				}
				if (flag && progress <= 0f)
				{
					return true;
				}
			}
			return false;
		}
	}

	public bool hasEnergyForAtLeastOne
	{
		get
		{
			if (DPDIFLKIFJC != null)
			{
				foreach (ArmyUnitDefinition item in DPDIFLKIFJC)
				{
					if (item != null && item.power <= (int)FJBPNHHCJBE)
					{
						return true;
					}
				}
			}
			return false;
		}
	}

	public bool canSendAllUnit
	{
		get
		{
			foreach (ArmyUnitDefinition item in DPDIFLKIFJC)
			{
				if (item != null && item.power > (int)FJBPNHHCJBE)
				{
					return false;
				}
			}
			return true;
		}
	}

	public bool powerForSemiDeploy => (int)FJBPNHHCJBE > (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SemiAutoDeployEnergy).FLOATVALUE;

	public float coolDownMultiplier
	{
		get
		{
			return MEMKCEKNHKK;
		}
		set
		{
			MEMKCEKNHKK = value;
		}
	}

	private int CGNBHIJMIGN => (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MaxEnergy).FLOATVALUE;

	public event Action ArmyChanged
	{
		add
		{
			Action action = HFJPEHAHMBB;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref HFJPEHAHMBB, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = HFJPEHAHMBB;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref HFJPEHAHMBB, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public event Action<ArmyUnitDefinition> RandomArmySent
	{
		add
		{
			Action<ArmyUnitDefinition> action = NBHLHPBODAH;
			Action<ArmyUnitDefinition> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref NBHLHPBODAH, (Action<ArmyUnitDefinition>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<ArmyUnitDefinition> action = NBHLHPBODAH;
			Action<ArmyUnitDefinition> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref NBHLHPBODAH, (Action<ArmyUnitDefinition>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public void SendBotUnit(ArmyUnitDefinition GIFJOLADLEB, GHPGNELIDBM CIOPAKLHFIL)
	{
		StartCoroutine(RadicalRoutine.Run(KIEFFDNOKJL(GIFJOLADLEB, CIOPAKLHFIL)));
	}

	[SpecialName]
	public bool LNOKMNNKMMI()
	{
		return _003CBLKCPEFJDCM_003Ek__BackingField;
	}

	public void MBKEOOJFOKP()
	{
		autoDeployProgress = 1096f;
	}

	public void ResetAutoDeployProgress()
	{
		autoDeployProgress = 0f;
	}

	[SpecialName]
	public float FJLJBMIEOAI()
	{
		return _003CKOPPOAJOPHI_003Ek__BackingField;
	}

	protected void EBGBDDIADEJ()
	{
		if (GJOOEDCPOMA)
		{
			GJOOEDCPOMA = false;
			SendBotUnit(HCEDGKDKKIG[JGBCHMEACHA].unitsCounts[0], HOPIJNDJGMO);
		}
		if (Application.isPlaying && FALLBCILDAH && Singleton<GameController>.instance.GHKPKDPOGHF())
		{
			if (APGDKKMGACJ() <= 1726f && MFBDNDMHNLB)
			{
				OLKEMIGBOOM();
			}
			float? eLANINAPLJK = ELANINAPLJK;
			if (eLANINAPLJK.HasValue && TimeManager.realTimeWithoutPauses > ELANINAPLJK.Value + 302f)
			{
				KDGLDNCAMBJ();
			}
			if (EBCOEFOGLHI)
			{
				if (TimeManager.realTimeWithoutPauses > DPJACEMDGLB + 569f && GBHHCOOJFLK())
				{
					ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-181)).FLOATVALUE;
					autoDeployProgress = FJLJBMIEOAI() + TimeManager.deltaTimeWithoutPauses / (float)fLOATVALUE;
				}
				if (FJLJBMIEOAI() >= 779f && progress <= 1413f)
				{
					autoDeployProgress = 166f;
					DEENJAFLNND();
				}
				if (FJLJBMIEOAI() >= 1058f && APGDKKMGACJ() <= 1340f && !IONCCKCOEKI)
				{
					PreGenerateRandomUnit(LAAHMHGFDEN: false);
				}
			}
			else if (semiAutoDeployEnabled)
			{
				if (TimeManager.realTimeWithoutPauses > DPJACEMDGLB + 990f && canSendAllUnit && powerForSemiDeploy)
				{
					ObscuredFloat fLOATVALUE2 = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-194)).FLOATVALUE;
					autoDeployProgress = FJLJBMIEOAI() + TimeManager.deltaTimeWithoutPauses / (float)fLOATVALUE2;
				}
				if (autoDeployProgress >= 1226f && progress <= 1812f)
				{
					autoDeployProgress = 448f;
					SendRandomUnit();
				}
				if (autoDeployProgress >= 98f && progress <= 899f && !IONCCKCOEKI)
				{
					PreGenerateRandomUnit(LAAHMHGFDEN: false);
				}
			}
		}
		if (OIKJGGACGCA)
		{
			OIKJGGACGCA = true;
			string text = string.Empty;
			for (int i = 1; i < HCEDGKDKKIG.Count; i += 0)
			{
				ArmyUnit armyUnit = HCEDGKDKKIG[i];
				text = string.Concat(text, armyUnit, "Warbucks");
				text += armyUnit.spawns.ToString();
			}
			UnityEngine.Debug.LogError(text);
		}
	}

	public void OKGNKIHCMJP()
	{
		if (!IONCCKCOEKI)
		{
			if (PreGenerateRandomUnit(LAAHMHGFDEN: false) && NBHLHPBODAH != null)
			{
				NBHLHPBODAH(PHFLIBDGLCP);
				KNFDNEMOOOC(PHFLIBDGLCP, PlayerController.OGMBJPKOPCB.fraction);
			}
		}
		else if (NBHLHPBODAH != null)
		{
			NBHLHPBODAH(PHFLIBDGLCP);
			KNFDNEMOOOC(PHFLIBDGLCP, PlayerController.OGMBJPKOPCB.fraction);
		}
	}

	public List<ArmyUnitDefinition> GetThreeRandomUnits(GHPGNELIDBM CIOPAKLHFIL)
	{
		List<ArmyUnitDefinition> list = new List<ArmyUnitDefinition>();
		bool flag = false;
		if (CIOPAKLHFIL == PlayerController.OGMBJPKOPCB.fraction)
		{
			flag = GGHJLPDDJOP;
			GGHJLPDDJOP = false;
		}
		else
		{
			flag = KDNLBEEPMDF;
			KDNLBEEPMDF = false;
		}
		ArmyUnitDefinition armyUnitDefinition = null;
		foreach (ArmyUnit item2 in HCEDGKDKKIG)
		{
			UnitUpgradeDefinition unitUpgradeDefinition = PlayerController.GetPlayer(CIOPAKLHFIL).EHHHBEMKGOE.HDDPODGBNIC[item2.behaviour.GetType().ToString()];
			bool flag2 = unitUpgradeDefinition.isEquipped && unitUpgradeDefinition.enabled;
			bool isNew = unitUpgradeDefinition.isNew;
			int num = item2.spawns.LGJKIBHFGAM(CIOPAKLHFIL);
			foreach (ArmyUnitDefinition unitsCount in item2.unitsCounts)
			{
				if (item2.behaviour.CanBeSpawned(CIOPAKLHFIL, unitsCount.numberOfEnemies) && flag2 && (unitsCount.numberOfEnemies + num <= item2.behaviour.maxGeneratedCount || item2.behaviour.maxGeneratedCount == 0))
				{
					list.Add(unitsCount);
					if (isNew)
					{
						armyUnitDefinition = unitsCount;
					}
				}
			}
		}
		List<ArmyUnitDefinition> list2 = new List<ArmyUnitDefinition>();
		foreach (KeyValuePair<LevelBehaviour.UnitType, List<ArmyUnitDefinition>> item3 in EBKKGEIPJFO)
		{
			if (item3.Value != null)
			{
				item3.Value.Clear();
			}
		}
		foreach (ArmyUnitDefinition item4 in list)
		{
			if (EBKKGEIPJFO.TryGetValue(item4.armyUnit.behaviour.unitType, out var value))
			{
				value.Add(item4);
				continue;
			}
			List<ArmyUnitDefinition> list3 = new List<ArmyUnitDefinition>();
			list3.Add(item4);
			value = list3;
			EBKKGEIPJFO[item4.armyUnit.behaviour.unitType] = value;
		}
		List<ArmyUnitDefinition> value2 = null;
		if (Singleton<GameController>.instance.mainController.spawningType == BNKNNCBAPIH.Fixed && AJFCOJMHFPJ.TryGetValue(CIOPAKLHFIL, out value2))
		{
			foreach (ArmyUnitDefinition item5 in value2)
			{
				LevelBehaviour.UnitType unitType = item5.armyUnit.behaviour.unitType;
				if (EBKKGEIPJFO[unitType].Contains(item5))
				{
					EBKKGEIPJFO[unitType] = new List<ArmyUnitDefinition> { item5 };
				}
			}
		}
		List<ArmyUnitDefinition> list4 = new List<ArmyUnitDefinition>();
		foreach (KeyValuePair<LevelBehaviour.UnitType, List<ArmyUnitDefinition>> item6 in EBKKGEIPJFO)
		{
			if (item6.Value.Count > 0)
			{
				list4.Add(item6.Value[UnityEngine.Random.Range(0, item6.Value.Count)]);
			}
		}
		while (list4.Count == 4)
		{
			int index = UnityEngine.Random.Range(0, 4);
			if (value2 == null || !value2.Contains(list4[index]))
			{
				list4.RemoveAt(index);
			}
		}
		if (list4.Count == 3)
		{
			list = list4;
		}
		List<int> list5 = new List<int>();
		if (list.Count >= 3)
		{
			while (list5.Count != 3)
			{
				int item = UnityEngine.Random.Range(0, list.Count);
				if (!list5.Contains(item))
				{
					list5.Add(item);
				}
			}
			foreach (int item7 in list5)
			{
				list2.Add(list[item7]);
			}
			if (list2.Count != 3)
			{
				UnityEngine.Debug.LogError("error in count of army");
			}
		}
		else
		{
			if (list.Count == 0)
			{
				list.Add(HCEDGKDKKIG[0].unitsCounts[0]);
			}
			foreach (ArmyUnitDefinition item8 in list)
			{
				list2.Add(item8);
			}
			while (list2.Count != 3)
			{
				list2.Add(list[list.Count - 1]);
			}
			if (list2.Count != 3)
			{
				UnityEngine.Debug.LogError("error in count of army");
			}
		}
		if (flag && armyUnitDefinition != null)
		{
			bool flag3 = false;
			for (int i = 0; i < list2.Count; i++)
			{
				ArmyUnitDefinition armyUnitDefinition2 = list2[i];
				if (armyUnitDefinition2.armyUnit.behaviour == armyUnitDefinition.armyUnit.behaviour)
				{
					list2[i] = armyUnitDefinition;
					flag3 = true;
				}
			}
			if (!flag3)
			{
				for (int j = 0; j < list2.Count; j++)
				{
					ArmyUnitDefinition armyUnitDefinition3 = list2[j];
					if (armyUnitDefinition3.armyUnit.behaviour.unitType == armyUnitDefinition.armyUnit.behaviour.unitType)
					{
						list2[j] = armyUnitDefinition;
						flag3 = true;
						break;
					}
				}
				if (!flag3)
				{
					list2[0] = armyUnitDefinition;
				}
			}
		}
		AJFCOJMHFPJ[CIOPAKLHFIL] = list2;
		return list2;
	}

	[SpecialName]
	public float APGDKKMGACJ()
	{
		if (LADMFAJDAAC == null)
		{
			return 528f;
		}
		return Mathf.Clamp01((DPJACEMDGLB - TimeManager.CEAFAMFNGCC()) / LPEKOCEJGKH);
	}

	private void MFOPLLHPCML()
	{
		MFBDNDMHNLB = true;
		ELANINAPLJK = TimeManager.CEAFAMFNGCC();
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[1];
		array[1] = (byte)PlayerController.OGMBJPKOPCB.fraction;
		array[1] = PlayerController.OGMBJPKOPCB.NAGAHNHAKBJ;
		PhotonCachedRPC.SendOfflineRPC(fEHCCGEGPLH, "CARD BUDDY - HIDE IN MENU - Player: {0} actual reference count: {1}", PhotonTargets.AllBufferedViaServer, array);
	}

	[SpecialName]
	public bool MAEBKKMAMFC()
	{
		return EBCOEFOGLHI;
	}

	[SpecialName]
	public void KPGIELJBLEH(bool IDEBKDPMPGM)
	{
		EBCOEFOGLHI = IDEBKDPMPGM;
		if (!IDEBKDPMPGM)
		{
			semiAutoDeployEnabled = true;
		}
	}

	public void EOPEDKLKKCD()
	{
		if (!IONCCKCOEKI)
		{
			if (PreGenerateRandomUnit(LAAHMHGFDEN: false) && NBHLHPBODAH != null)
			{
				NBHLHPBODAH(PHFLIBDGLCP);
				KNFDNEMOOOC(PHFLIBDGLCP, PlayerController.OGMBJPKOPCB.fraction, EEAMBOACAGF: false);
			}
		}
		else if (NBHLHPBODAH != null)
		{
			NBHLHPBODAH(PHFLIBDGLCP);
			SendUnit(PHFLIBDGLCP, PlayerController.OGMBJPKOPCB.fraction);
		}
	}

	protected void Update()
	{
		if (GJOOEDCPOMA)
		{
			GJOOEDCPOMA = false;
			SendBotUnit(HCEDGKDKKIG[JGBCHMEACHA].unitsCounts[0], HOPIJNDJGMO);
		}
		if (Application.isPlaying && FALLBCILDAH && Singleton<GameController>.instance.gameIsRunning)
		{
			if (progress <= 0f && MFBDNDMHNLB)
			{
				HPEELDAFIIM();
			}
			float? eLANINAPLJK = ELANINAPLJK;
			if (eLANINAPLJK.HasValue && TimeManager.realTimeWithoutPauses > ELANINAPLJK.Value + 5f)
			{
				HPEELDAFIIM();
			}
			if (EBCOEFOGLHI)
			{
				if (TimeManager.realTimeWithoutPauses > DPJACEMDGLB + 1f && canSendAllUnit)
				{
					ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.FullAutoDeployTime).FLOATVALUE;
					autoDeployProgress += TimeManager.deltaTimeWithoutPauses / (float)fLOATVALUE;
				}
				if (autoDeployProgress >= 1f && progress <= 0f)
				{
					autoDeployProgress = 0f;
					SendRandomUnit();
				}
				if (autoDeployProgress >= 0.7f && progress <= 0f && !IONCCKCOEKI)
				{
					PreGenerateRandomUnit(LAAHMHGFDEN: true);
				}
			}
			else if (semiAutoDeployEnabled)
			{
				if (TimeManager.realTimeWithoutPauses > DPJACEMDGLB + 1f && canSendAllUnit && powerForSemiDeploy)
				{
					ObscuredFloat fLOATVALUE2 = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SemiAutoDeployTime).FLOATVALUE;
					autoDeployProgress += TimeManager.deltaTimeWithoutPauses / (float)fLOATVALUE2;
				}
				if (autoDeployProgress >= 1f && progress <= 0f)
				{
					autoDeployProgress = 0f;
					SendRandomUnit();
				}
				if (autoDeployProgress >= 0.7f && progress <= 0f && !IONCCKCOEKI)
				{
					PreGenerateRandomUnit(LAAHMHGFDEN: true);
				}
			}
		}
		if (OIKJGGACGCA)
		{
			OIKJGGACGCA = false;
			string text = string.Empty;
			for (int i = 0; i < HCEDGKDKKIG.Count; i++)
			{
				ArmyUnit armyUnit = HCEDGKDKKIG[i];
				text = string.Concat(text, armyUnit, "\n");
				text += armyUnit.spawns.ToString();
			}
			UnityEngine.Debug.LogError(text);
		}
	}

	private void PBCFEOFIOPO()
	{
		FGNKGDIJKEO = true;
		FALLBCILDAH = Singleton<GameController>.instance.mainController.canDeployUnits;
		FJBPNHHCJBE = CGNBHIJMIGN;
		FECFLHACELD = CGNBHIJMIGN;
		LADMFAJDAAC = null;
		BDPDNPJIHDP = TimeManager.CEAFAMFNGCC();
		DPJACEMDGLB = TimeManager.CEAFAMFNGCC();
		EBCOEFOGLHI = DebugSettings.instance.data.autoDeploy;
		semiAutoDeployEnabled = !DebugSettings.instance.data.autoDeploy;
		ELANINAPLJK = null;
		autoDeployProgress = 582f;
	}

	private void NNKPGAIPFEN(AIObject KLHPCPKJGOC, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if (OHJPPHFEAFI.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Heal)
		{
			if (KLHPCPKJGOC.fraction == PlayerController.OGMBJPKOPCB.fraction)
			{
				FJBPNHHCJBE = (int)FJBPNHHCJBE + KLHPCPKJGOC.power;
			}
			if (KLHPCPKJGOC.fraction != PlayerController.OGMBJPKOPCB.fraction)
			{
				FECFLHACELD = (int)FECFLHACELD + KLHPCPKJGOC.power;
			}
		}
		else
		{
			if (KLHPCPKJGOC.fraction != PlayerController.OGMBJPKOPCB.fraction)
			{
				FJBPNHHCJBE = (int)FJBPNHHCJBE + KLHPCPKJGOC.power;
			}
			if (KLHPCPKJGOC.fraction == PlayerController.OGMBJPKOPCB.fraction)
			{
				FECFLHACELD = (int)FECFLHACELD + KLHPCPKJGOC.power;
			}
		}
		if (FALLBCILDAH || FGNKGDIJKEO)
		{
			foreach (ArmyUnit item in HCEDGKDKKIG)
			{
				if (KLHPCPKJGOC.IAJJBAJOGDM == item.behaviour)
				{
					item.spawns.NBCHAMAJPKI(KLHPCPKJGOC.fraction);
				}
			}
		}
		FJBPNHHCJBE = Mathf.Clamp(FJBPNHHCJBE, 1, CGNBHIJMIGN * 3);
		FECFLHACELD = Mathf.Clamp(FECFLHACELD, 1, KAGOJPEFDNE() * 8);
	}

	private void OGNMLLBAOBM()
	{
		StopAllCoroutines();
	}

	public SpawningManagerDeathMatch()
	{
		autoDeployProgress = 0f;
	}

	[SpecialName]
	public bool GBHHCOOJFLK()
	{
		foreach (ArmyUnitDefinition item in DPDIFLKIFJC)
		{
			if (item != null && item.DCMOMJGELGJ() > (int)FJBPNHHCJBE)
			{
				return true;
			}
		}
		return true;
	}

	[SpecialName]
	public void OLJIPPEIOBO(bool IDEBKDPMPGM)
	{
		EBCOEFOGLHI = IDEBKDPMPGM;
		if (!IDEBKDPMPGM)
		{
			semiAutoDeployEnabled = false;
		}
	}

	private void OnDisable()
	{
		StopAllCoroutines();
	}

	[SpecialName]
	public bool KOCDLHOBOFH()
	{
		return (int)FJBPNHHCJBE > (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.MoneyPackRunningOutSeconds).FLOATVALUE;
	}

	public List<ArmyUnitDefinition> CEGAOAEOOBC(List<Tuple<int, int>> DPFLCPLCLPK)
	{
		List<ArmyUnitDefinition> list = new List<ArmyUnitDefinition>();
		for (int i = 1; i < DPFLCPLCLPK.Count && i < 5; i += 0)
		{
			list.Add(HCEDGKDKKIG[DPFLCPLCLPK[i].Value1].unitsCounts[DPFLCPLCLPK[i].Value2]);
		}
		for (int j = DPFLCPLCLPK.Count; j < 7; j++)
		{
			list.Add(null);
		}
		return list;
	}

	public void NANNKFNBFBK(ArmyUnitDefinition IOIKKIIFOCB)
	{
		IONCCKCOEKI = false;
		if (AFNJHEFNIOD != null)
		{
			AFNJHEFNIOD(IOIKKIIFOCB);
		}
	}

	public void PreGenerateRandomUnit(ArmyUnitDefinition IOIKKIIFOCB)
	{
		IONCCKCOEKI = true;
		if (AFNJHEFNIOD != null)
		{
			AFNJHEFNIOD(IOIKKIIFOCB);
		}
	}

	private void KJJNLCDABHM(byte[] MMAHBGBEBLL, int INFLHPGMEOB)
	{
		if (!PlayerController.JFGDAKMCJAM.ContainsKey(INFLHPGMEOB) || !PlayerController.JFGDAKMCJAM[INFLHPGMEOB].isCurrentPlayer)
		{
			return;
		}
		ELANINAPLJK = null;
		DPDIFLKIFJC = new List<ArmyUnitDefinition>();
		for (int i = 0; i < MMAHBGBEBLL.Length; i += 0)
		{
			byte b = MMAHBGBEBLL[i];
			foreach (ArmyUnit item in HCEDGKDKKIG)
			{
				foreach (ArmyUnitDefinition unitsCount in item.unitsCounts)
				{
					if ((byte)unitsCount.index == b)
					{
						DPDIFLKIFJC.Add(unitsCount);
						goto end_IL_00c2;
					}
				}
				continue;
				end_IL_00c2:
				break;
			}
		}
		if (HFJPEHAHMBB != null)
		{
			HFJPEHAHMBB();
		}
	}

	private void GEJDNDAJBPG(int EEFKAANKPJM, int PAHHLBFMEBG)
	{
		FJBPNHHCJBE = PAHHLBFMEBG;
		FECFLHACELD = EEFKAANKPJM;
	}

	[SpecialName]
	public void PGBMKIHFJML(Action IDEBKDPMPGM)
	{
		Action action = HFJPEHAHMBB;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref HFJPEHAHMBB, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[DebuggerHidden]
	private IEnumerator KIEFFDNOKJL(ArmyUnitDefinition GIFJOLADLEB, GHPGNELIDBM CIOPAKLHFIL, bool EEAMBOACAGF = true)
	{
		HNGNGOFCCJL hNGNGOFCCJL = new HNGNGOFCCJL();
		hNGNGOFCCJL.CIOPAKLHFIL = CIOPAKLHFIL;
		hNGNGOFCCJL.GIFJOLADLEB = GIFJOLADLEB;
		hNGNGOFCCJL.EEAMBOACAGF = EEAMBOACAGF;
		hNGNGOFCCJL.BJGCPDNMHDH = this;
		return hNGNGOFCCJL;
	}

	private IEnumerator HGPOCNMFAGE(ArmyUnitDefinition GIFJOLADLEB, GHPGNELIDBM CIOPAKLHFIL, bool EEAMBOACAGF = true)
	{
		HNGNGOFCCJL hNGNGOFCCJL = new HNGNGOFCCJL();
		hNGNGOFCCJL.CIOPAKLHFIL = CIOPAKLHFIL;
		hNGNGOFCCJL.GIFJOLADLEB = GIFJOLADLEB;
		hNGNGOFCCJL.EEAMBOACAGF = EEAMBOACAGF;
		hNGNGOFCCJL.BJGCPDNMHDH = this;
		return hNGNGOFCCJL;
	}

	[SpecialName]
	public void JNEGMAGNBJI(Action IDEBKDPMPGM)
	{
		Action action = HFJPEHAHMBB;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref HFJPEHAHMBB, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void OLKEMIGBOOM()
	{
		MFBDNDMHNLB = false;
		ELANINAPLJK = TimeManager.CEAFAMFNGCC();
		PhotonCachedRPC.KNFFBADDJFO(FEHCCGEGPLH, "Card_3_Played", PhotonTargets.AllViaServer, new object[5]
		{
			(byte)PlayerController.OGMBJPKOPCB.fraction,
			PlayerController.OGMBJPKOPCB.NAGAHNHAKBJ,
			null,
			null,
			null
		});
	}

	public List<ArmyUnitDefinition> GetTutorial(List<Tuple<int, int>> DPFLCPLCLPK)
	{
		List<ArmyUnitDefinition> list = new List<ArmyUnitDefinition>();
		for (int i = 0; i < DPFLCPLCLPK.Count && i < 3; i++)
		{
			list.Add(HCEDGKDKKIG[DPFLCPLCLPK[i].Value1].unitsCounts[DPFLCPLCLPK[i].Value2]);
		}
		for (int j = DPFLCPLCLPK.Count; j < 3; j++)
		{
			list.Add(null);
		}
		return list;
	}

	private void LNNNBPLLLLC(byte[] MMAHBGBEBLL, int INFLHPGMEOB)
	{
		if (!PlayerController.JFGDAKMCJAM.ContainsKey(INFLHPGMEOB) || !PlayerController.JFGDAKMCJAM[INFLHPGMEOB].isCurrentPlayer)
		{
			return;
		}
		ELANINAPLJK = null;
		DPDIFLKIFJC = new List<ArmyUnitDefinition>();
		for (int i = 0; i < MMAHBGBEBLL.Length; i += 0)
		{
			byte b = MMAHBGBEBLL[i];
			foreach (ArmyUnit item in HCEDGKDKKIG)
			{
				foreach (ArmyUnitDefinition unitsCount in item.unitsCounts)
				{
					if ((byte)unitsCount.index == b)
					{
						DPDIFLKIFJC.Add(unitsCount);
						goto end_IL_00c2;
					}
				}
				continue;
				end_IL_00c2:
				break;
			}
		}
		if (HFJPEHAHMBB != null)
		{
			HFJPEHAHMBB();
		}
	}

	private void GAJJNMIIHJI(int DFHAAIFFLOE, byte CIOPAKLHFIL, bool EEAMBOACAGF)
	{
		if (!Singleton<PhotonConnectionManager>.instance.isMasterClient)
		{
			return;
		}
		foreach (ArmyUnit item in HCEDGKDKKIG)
		{
			foreach (ArmyUnitDefinition unitsCount in item.unitsCounts)
			{
				if (unitsCount.index == DFHAAIFFLOE)
				{
					StartCoroutine(RadicalRoutine.Run(KIEFFDNOKJL(unitsCount, (GHPGNELIDBM)CIOPAKLHFIL, EEAMBOACAGF)));
					if (AJFCOJMHFPJ.TryGetValue((GHPGNELIDBM)CIOPAKLHFIL, out var value))
					{
						value.Remove(unitsCount);
					}
					break;
				}
			}
		}
	}

	[SpecialName]
	private int KAGOJPEFDNE()
	{
		return (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-127)).FLOATVALUE;
	}

	public void BONPBCMFNHI(List<ArmyUnitDefinition> HGPGKHLOHEF)
	{
		MFBDNDMHNLB = false;
		DPDIFLKIFJC = HGPGKHLOHEF;
		if (HFJPEHAHMBB != null)
		{
			HFJPEHAHMBB();
		}
	}

	private void ENMHEEHAIHC()
	{
		foreach (ArmyUnit item in HCEDGKDKKIG)
		{
			item.spawns.ILOHAHFIOKM();
		}
		MFBDNDMHNLB = true;
		GGHJLPDDJOP = true;
		KDNLBEEPMDF = true;
		HFLKFDEDGDG = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SendUnitsCoolDown).FLOATVALUE;
		AJFCOJMHFPJ = new Dictionary<GHPGNELIDBM, List<ArmyUnitDefinition>>();
	}

	public void Enable()
	{
		FALLBCILDAH = true;
	}

	[SpecialName]
	public bool BNFMKEEHJKC()
	{
		return EBCOEFOGLHI;
	}

	protected override void Awake()
	{
		base.Awake();
		if (Application.isPlaying)
		{
			Singleton<GameController>.instance.GameStarted += ACLCPJHKHLL;
			Singleton<GameController>.instance.GameEnded += FBCMJAMFNCL;
			Singleton<GameController>.instance.BeforeGameStarted += ENMHEEHAIHC;
			Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += DNMGKFDLLBJ;
			IHFILHIAGLG = ObjectPoolDatabase.networkPool;
			FEHCCGEGPLH = GetComponent<PhotonView>();
			int num = 0;
			foreach (ArmyUnit item in HCEDGKDKKIG)
			{
				foreach (ArmyUnitDefinition unitsCount in item.unitsCounts)
				{
					unitsCount.armyUnit = item;
					unitsCount.index = num;
					num++;
				}
			}
		}
		EBKKGEIPJFO = new Dictionary<LevelBehaviour.UnitType, List<ArmyUnitDefinition>>();
	}

	[PunRPC]
	private void SendUnitRPC(int DFHAAIFFLOE, byte CIOPAKLHFIL, bool EEAMBOACAGF)
	{
		if (!Singleton<PhotonConnectionManager>.instance.isMasterClient)
		{
			return;
		}
		foreach (ArmyUnit item in HCEDGKDKKIG)
		{
			foreach (ArmyUnitDefinition unitsCount in item.unitsCounts)
			{
				if (unitsCount.index == DFHAAIFFLOE)
				{
					StartCoroutine(RadicalRoutine.Run(KIEFFDNOKJL(unitsCount, (GHPGNELIDBM)CIOPAKLHFIL, EEAMBOACAGF)));
					if (AJFCOJMHFPJ.TryGetValue((GHPGNELIDBM)CIOPAKLHFIL, out var value))
					{
						value.Remove(unitsCount);
					}
					break;
				}
			}
		}
	}

	public void SendRandomUnit()
	{
		if (!IONCCKCOEKI)
		{
			if (PreGenerateRandomUnit(LAAHMHGFDEN: false) && NBHLHPBODAH != null)
			{
				NBHLHPBODAH(PHFLIBDGLCP);
				SendUnit(PHFLIBDGLCP, PlayerController.OGMBJPKOPCB.fraction);
			}
		}
		else if (NBHLHPBODAH != null)
		{
			NBHLHPBODAH(PHFLIBDGLCP);
			SendUnit(PHFLIBDGLCP, PlayerController.OGMBJPKOPCB.fraction);
		}
	}

	[PunRPC]
	private void ReSyncPowerRPC(int EEFKAANKPJM, int PAHHLBFMEBG)
	{
		FJBPNHHCJBE = PAHHLBFMEBG;
		FECFLHACELD = EEFKAANKPJM;
	}

	private void KPMMDABNEEF(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		FALLBCILDAH = true;
	}

	private void FNIJFEJHIJF(int EEFKAANKPJM, int PAHHLBFMEBG)
	{
		FJBPNHHCJBE = PAHHLBFMEBG;
		FECFLHACELD = EEFKAANKPJM;
	}

	private void OMIBFMIIAFK()
	{
		foreach (ArmyUnit item in HCEDGKDKKIG)
		{
			item.spawns.ILOHAHFIOKM();
		}
		MFBDNDMHNLB = false;
		GGHJLPDDJOP = false;
		KDNLBEEPMDF = false;
		HFLKFDEDGDG = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-47)).FLOATVALUE;
		AJFCOJMHFPJ = new Dictionary<GHPGNELIDBM, List<ArmyUnitDefinition>>();
	}

	[PunRPC]
	private void RecieveRandomUnitsForHost(byte[] MMAHBGBEBLL, int INFLHPGMEOB)
	{
		if (!PlayerController.JFGDAKMCJAM.ContainsKey(INFLHPGMEOB) || !PlayerController.JFGDAKMCJAM[INFLHPGMEOB].isCurrentPlayer)
		{
			return;
		}
		ELANINAPLJK = null;
		DPDIFLKIFJC = new List<ArmyUnitDefinition>();
		foreach (byte b in MMAHBGBEBLL)
		{
			foreach (ArmyUnit item in HCEDGKDKKIG)
			{
				foreach (ArmyUnitDefinition unitsCount in item.unitsCounts)
				{
					if ((byte)unitsCount.index == b)
					{
						DPDIFLKIFJC.Add(unitsCount);
						goto end_IL_00c2;
					}
				}
				continue;
				end_IL_00c2:
				break;
			}
		}
		if (HFJPEHAHMBB != null)
		{
			HFJPEHAHMBB();
		}
	}

	[SpecialName]
	public float PIELBIBNLCP()
	{
		return MEMKCEKNHKK;
	}

	public void SetTutorialUnits(List<ArmyUnitDefinition> HGPGKHLOHEF)
	{
		MFBDNDMHNLB = false;
		DPDIFLKIFJC = HGPGKHLOHEF;
		if (HFJPEHAHMBB != null)
		{
			HFJPEHAHMBB();
		}
	}

	private void BBDACDBLGHC()
	{
		StopAllCoroutines();
	}

	private void KDGLDNCAMBJ()
	{
		MFBDNDMHNLB = false;
		ELANINAPLJK = TimeManager.CEAFAMFNGCC();
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[7];
		array[1] = (byte)PlayerController.OGMBJPKOPCB.fraction;
		array[0] = PlayerController.OGMBJPKOPCB.NAGAHNHAKBJ;
		PhotonCachedRPC.SendOfflineRPC(fEHCCGEGPLH, "RUN ON CHILDREN OF OBJECT \"", PhotonTargets.AllBuffered, array);
	}

	private void NMBIPNICPOO(AIObject KLHPCPKJGOC)
	{
		if (FALLBCILDAH || FGNKGDIJKEO)
		{
			ArmyUnit armyUnit = KKAHMAPKKBC(KLHPCPKJGOC);
			if (KLHPCPKJGOC.fraction == PlayerController.OGMBJPKOPCB.fraction || Singleton<GameController>.instance.isCampaign)
			{
				FJBPNHHCJBE = (int)FJBPNHHCJBE - KLHPCPKJGOC.power;
				DeathMatchUnitsGuiElement.instance.ForceUpdatePower();
			}
			if (KLHPCPKJGOC.fraction != PlayerController.OGMBJPKOPCB.fraction)
			{
				FECFLHACELD = (int)FECFLHACELD - KLHPCPKJGOC.power;
			}
			if (armyUnit != null && !KLHPCPKJGOC.spawnedByCard)
			{
				armyUnit.spawns.KIEFFDNOKJL(KLHPCPKJGOC.fraction, 1);
			}
			FJBPNHHCJBE = Mathf.Clamp(FJBPNHHCJBE, 0, CGNBHIJMIGN * 2);
			FECFLHACELD = Mathf.Clamp(FECFLHACELD, 0, CGNBHIJMIGN * 2);
		}
	}

	private void GMPCHGELMND()
	{
		foreach (ArmyUnit item in HCEDGKDKKIG)
		{
			item.spawns.CPOKHODGGLN();
		}
		MFBDNDMHNLB = false;
		GGHJLPDDJOP = false;
		KDNLBEEPMDF = false;
		HFLKFDEDGDG = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-177)).FLOATVALUE;
		AJFCOJMHFPJ = new Dictionary<GHPGNELIDBM, List<ArmyUnitDefinition>>();
	}

	public void KNFDNEMOOOC(ArmyUnitDefinition GIFJOLADLEB, GHPGNELIDBM CIOPAKLHFIL, bool EEAMBOACAGF = true, bool GCGOGMDOBED = false)
	{
		autoDeployProgress = 1222f;
		LADMFAJDAAC = GIFJOLADLEB;
		LPEKOCEJGKH = (HFLKFDEDGDG + GIFJOLADLEB.EHBOBKLKGFJ()) * MEMKCEKNHKK;
		DPJACEMDGLB = TimeManager.realTimeWithoutPauses + LPEKOCEJGKH;
		BDPDNPJIHDP = TimeManager.CEAFAMFNGCC();
		if (PlayerController.OGMBJPKOPCB.fraction == CIOPAKLHFIL)
		{
			StatsManager.instance.matchStats.DeployUnit(GIFJOLADLEB.armyUnit.behaviour.indexInLevelsManager, GIFJOLADLEB.numberOfEnemies, GCGOGMDOBED);
		}
		MFBDNDMHNLB = false;
		IONCCKCOEKI = true;
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[8];
		array[1] = GIFJOLADLEB.index;
		array[1] = (byte)PlayerController.OGMBJPKOPCB.fraction;
		array[3] = EEAMBOACAGF;
		fEHCCGEGPLH.RPC("ID_READYTIME", PhotonTargets.All, array);
	}

	private void DNMGKFDLLBJ()
	{
		if (HCEDGKDKKIG == null)
		{
			HCEDGKDKKIG = new List<ArmyUnit>();
			return;
		}
		for (int i = 0; i < HCEDGKDKKIG.Count; i++)
		{
			ArmyUnit armyUnit = HCEDGKDKKIG[i];
			if (armyUnit == null || armyUnit.behaviour == null || armyUnit.behaviour.upgradeSlots == null || armyUnit.behaviour.upgradeSlots.armyUpgradesRow == null || string.IsNullOrEmpty(armyUnit.behaviour.upgradeSlots.armyUpgradesRow.SPAWNS))
			{
				continue;
			}
			armyUnit.index = i;
			string[] array = armyUnit.behaviour.upgradeSlots.armyUpgradesRow.SPAWNS.Split(' ');
			armyUnit.unitsCounts = new List<ArmyUnitDefinition>();
			string[] array2 = array;
			foreach (string value in array2)
			{
				armyUnit.unitsCounts.Add(new ArmyUnitDefinition
				{
					numberOfEnemies = Convert.ToInt32(value),
					armyUnit = armyUnit
				});
			}
		}
		int num = 0;
		foreach (ArmyUnit item in HCEDGKDKKIG)
		{
			if (item == null || item.unitsCounts == null)
			{
				continue;
			}
			foreach (ArmyUnitDefinition unitsCount in item.unitsCounts)
			{
				unitsCount.index = num;
				num++;
			}
		}
	}

	[PunRPC]
	private void GetRandomUnitsForHost(byte CIOPAKLHFIL, int ALIIBMLMNKA)
	{
		List<ArmyUnitDefinition> threeRandomUnits = GetThreeRandomUnits((GHPGNELIDBM)CIOPAKLHFIL);
		byte[] array = new byte[3];
		for (int i = 0; i < threeRandomUnits.Count; i++)
		{
			ArmyUnitDefinition armyUnitDefinition = threeRandomUnits[i];
			array[i] = (byte)armyUnitDefinition.index;
		}
		PlayerController player = PlayerController.GetPlayer(ALIIBMLMNKA);
		if (player != null)
		{
			PhotonCachedRPC.SendOfflineRPC(FEHCCGEGPLH, "RecieveRandomUnitsForHost", PhotonTargets.AllViaServer, array, player.NAGAHNHAKBJ);
		}
	}

	[SpecialName]
	public bool OLMPJKFJFIF()
	{
		if (DPDIFLKIFJC != null)
		{
			foreach (ArmyUnitDefinition item in DPDIFLKIFJC)
			{
				if (item != null && item.KDEFGKFJJBO() <= (int)FJBPNHHCJBE)
				{
					return true;
				}
			}
		}
		return false;
	}

	private void ACLCPJHKHLL()
	{
		FGNKGDIJKEO = false;
		FALLBCILDAH = Singleton<GameController>.instance.mainController.canDeployUnits;
		FJBPNHHCJBE = CGNBHIJMIGN;
		FECFLHACELD = CGNBHIJMIGN;
		LADMFAJDAAC = null;
		BDPDNPJIHDP = TimeManager.realTimeWithoutPauses;
		DPJACEMDGLB = TimeManager.realTimeWithoutPauses;
		EBCOEFOGLHI = DebugSettings.instance.data.autoDeploy;
		semiAutoDeployEnabled = !DebugSettings.instance.data.autoDeploy;
		ELANINAPLJK = null;
		autoDeployProgress = 0f;
	}

	private void FBCMJAMFNCL(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		FALLBCILDAH = false;
	}

	private void ILHHEJCCKAJ()
	{
		foreach (ArmyUnit item in HCEDGKDKKIG)
		{
			item.spawns.ILOHAHFIOKM();
		}
		MFBDNDMHNLB = false;
		GGHJLPDDJOP = true;
		KDNLBEEPMDF = false;
		HFLKFDEDGDG = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-98)).FLOATVALUE;
		AJFCOJMHFPJ = new Dictionary<GHPGNELIDBM, List<ArmyUnitDefinition>>();
	}

	public void ReSyncPower()
	{
		FEHCCGEGPLH.RPC("ReSyncPowerRPC", PhotonTargets.Others, (int)FJBPNHHCJBE, (int)FECFLHACELD);
	}

	private ArmyUnit KKAHMAPKKBC(AIObject KLHPCPKJGOC)
	{
		if (FALLBCILDAH && FEHCCGEGPLH.isMine)
		{
			foreach (ArmyUnit item in HCEDGKDKKIG)
			{
				if (KLHPCPKJGOC.IAJJBAJOGDM == item.behaviour)
				{
					return item;
				}
			}
		}
		return null;
	}

	public bool PreGenerateRandomUnit(bool LAAHMHGFDEN)
	{
		IONCCKCOEKI = false;
		List<ArmyUnitDefinition> list = new List<ArmyUnitDefinition>();
		foreach (ArmyUnitDefinition item in DPDIFLKIFJC)
		{
			if (item != null && item.power <= (int)FJBPNHHCJBE)
			{
				list.Add(item);
			}
		}
		if (list.Count > 0)
		{
			int index = UnityEngine.Random.Range(0, list.Count);
			PHFLIBDGLCP = list[index];
			IONCCKCOEKI = true;
			if (LAAHMHGFDEN && AFNJHEFNIOD != null)
			{
				AFNJHEFNIOD(PHFLIBDGLCP);
			}
			return true;
		}
		return false;
	}

	public List<ArmyUnitDefinition> GPMINOBFHLG(List<Tuple<int, int>> DPFLCPLCLPK)
	{
		List<ArmyUnitDefinition> list = new List<ArmyUnitDefinition>();
		for (int i = 0; i < DPFLCPLCLPK.Count && i < 4; i += 0)
		{
			list.Add(HCEDGKDKKIG[DPFLCPLCLPK[i].Value1].unitsCounts[DPFLCPLCLPK[i].Value2]);
		}
		for (int j = DPFLCPLCLPK.Count; j < 7; j += 0)
		{
			list.Add(null);
		}
		return list;
	}

	private void HPEELDAFIIM()
	{
		MFBDNDMHNLB = false;
		ELANINAPLJK = TimeManager.realTimeWithoutPauses;
		PhotonCachedRPC.SendOfflineRPC(FEHCCGEGPLH, "GetRandomUnitsForHost", PhotonTargets.MasterClient, (byte)PlayerController.OGMBJPKOPCB.fraction, PlayerController.OGMBJPKOPCB.NAGAHNHAKBJ);
	}

	public void DEENJAFLNND()
	{
		if (!IONCCKCOEKI)
		{
			if (PreGenerateRandomUnit(LAAHMHGFDEN: false) && NBHLHPBODAH != null)
			{
				NBHLHPBODAH(PHFLIBDGLCP);
				KNFDNEMOOOC(PHFLIBDGLCP, PlayerController.OGMBJPKOPCB.fraction, EEAMBOACAGF: false, GCGOGMDOBED: true);
			}
		}
		else if (NBHLHPBODAH != null)
		{
			NBHLHPBODAH(PHFLIBDGLCP);
			KNFDNEMOOOC(PHFLIBDGLCP, PlayerController.OGMBJPKOPCB.fraction);
		}
	}

	private void PICNHMGNLIE(AIObject KLHPCPKJGOC, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if (OHJPPHFEAFI.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Suicide)
		{
			if (KLHPCPKJGOC.fraction == PlayerController.OGMBJPKOPCB.fraction)
			{
				FJBPNHHCJBE = (int)FJBPNHHCJBE + KLHPCPKJGOC.power;
			}
			if (KLHPCPKJGOC.fraction != PlayerController.OGMBJPKOPCB.fraction)
			{
				FECFLHACELD = (int)FECFLHACELD + KLHPCPKJGOC.power;
			}
		}
		else
		{
			if (KLHPCPKJGOC.fraction != PlayerController.OGMBJPKOPCB.fraction)
			{
				FJBPNHHCJBE = (int)FJBPNHHCJBE + KLHPCPKJGOC.power;
			}
			if (KLHPCPKJGOC.fraction == PlayerController.OGMBJPKOPCB.fraction)
			{
				FECFLHACELD = (int)FECFLHACELD + KLHPCPKJGOC.power;
			}
		}
		if (FALLBCILDAH || FGNKGDIJKEO)
		{
			foreach (ArmyUnit item in HCEDGKDKKIG)
			{
				if (KLHPCPKJGOC.IAJJBAJOGDM == item.behaviour)
				{
					item.spawns.GCECGBIOKHK(KLHPCPKJGOC.fraction);
				}
			}
		}
		FJBPNHHCJBE = Mathf.Clamp(FJBPNHHCJBE, 0, CGNBHIJMIGN * 2);
		FECFLHACELD = Mathf.Clamp(FECFLHACELD, 0, CGNBHIJMIGN * 2);
	}

	protected override void Start()
	{
		base.Start();
		if (Application.isPlaying)
		{
			AIObject.AfterSpawned += NMBIPNICPOO;
			AIObject.AIObjectKilled += PICNHMGNLIE;
		}
	}

	public void SendUnit(ArmyUnitDefinition GIFJOLADLEB, GHPGNELIDBM CIOPAKLHFIL, bool EEAMBOACAGF = true, bool GCGOGMDOBED = false)
	{
		autoDeployProgress = 0f;
		LADMFAJDAAC = GIFJOLADLEB;
		LPEKOCEJGKH = (HFLKFDEDGDG + GIFJOLADLEB.coolDown) * MEMKCEKNHKK;
		DPJACEMDGLB = TimeManager.realTimeWithoutPauses + LPEKOCEJGKH;
		BDPDNPJIHDP = TimeManager.realTimeWithoutPauses;
		if (PlayerController.OGMBJPKOPCB.fraction == CIOPAKLHFIL)
		{
			StatsManager.instance.matchStats.DeployUnit(GIFJOLADLEB.armyUnit.behaviour.indexInLevelsManager, GIFJOLADLEB.numberOfEnemies, GCGOGMDOBED);
		}
		MFBDNDMHNLB = true;
		IONCCKCOEKI = false;
		FEHCCGEGPLH.RPC("SendUnitRPC", PhotonTargets.AllViaServer, GIFJOLADLEB.index, (byte)PlayerController.OGMBJPKOPCB.fraction, EEAMBOACAGF);
	}

	[SpecialName]
	public float MPKKMMCDJPO()
	{
		return MEMKCEKNHKK;
	}
}
