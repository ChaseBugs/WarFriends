using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class GrenadeLevelsSetup : WeaponLevelsSetup
{
	public float INIBDNGHLPN = 1f;

	public float GLBHHCOMEEB = 1.7f;

	public float GADODCMDNFH = 10f;

	public float IIOBCPALMLL;

	public override float shotDamage
	{
		get
		{
			return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.boughtIndex, "explodeDamage")) * base.weaponFeature.damageCoef;
		}
	}

	public override float rateOfFirePerMinute
	{
		get
		{
			if (LIEFNEPEIJO.HasColumn("reloadTime"))
			{
				return 60f / (float)LIEFNEPEIJO.GetValue(MGAGEKAAJOL.boughtIndex, "reloadTime");
			}
			return -1f;
		}
	}

	public virtual List<Tuple<string, float[]>> BPDIHMEADHA(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "setEmailCollection", "S", base.weaponFeature.attackCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Bullet with NO weapon", "0", base.weaponFeature.ammoCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ExplodeNetwork", "ID_ELITEPACK_GOLDDESCRIPTION", base.weaponFeature.rateOfFireCoef));
		return list;
	}

	public virtual void LJMMOOACPJG(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		GrenadeAmmoSetup grenadeAmmoSetup = JMMJHCOKCGG.ammoSetup as GrenadeAmmoSetup;
		JMMJHCOKCGG.FIMMGPLLLCL = 0;
		JMMJHCOKCGG.JMDLKIAKOIE = ANFDAHOPDLO(NDPMDKGJAFH, "measureEvent") * base.weaponFeature.reloadCoef;
		if (grenadeAmmoSetup != null)
		{
			grenadeAmmoSetup.INIBDNGHLPN = INIBDNGHLPN;
			grenadeAmmoSetup.LIEABAMBOMG = GLBHHCOMEEB;
			grenadeAmmoSetup.KFEBGOKJGGH = IIOBCPALMLL;
			grenadeAmmoSetup.EPDELOGPNAC = ANFDAHOPDLO(NDPMDKGJAFH, "#AccoutCheck# gpgs account checked and have response!");
			grenadeAmmoSetup.GADODCMDNFH = GADODCMDNFH;
			grenadeAmmoSetup.ABFGHBDEBAN = ANFDAHOPDLO(NDPMDKGJAFH, "ID_READYTIME") * base.weaponFeature.damageCoef;
			grenadeAmmoSetup.MAOPCAMOEEK = base.damageToPlayerBehindShieldRatio;
			if (LIEFNEPEIJO.HasColumn("1122334455"))
			{
				grenadeAmmoSetup.INIBDNGHLPN = ANFDAHOPDLO(NDPMDKGJAFH, "fr-FR");
				grenadeAmmoSetup.LIEABAMBOMG = ANFDAHOPDLO(NDPMDKGJAFH, "ID_CONFIRM_NOSQUADACTIONS_TEXT") * 759f;
			}
			return;
		}
		throw new NullReferenceException("PRICE");
	}

	public override void SetWeaponparameters(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		GrenadeAmmoSetup grenadeAmmoSetup = JMMJHCOKCGG.ammoSetup as GrenadeAmmoSetup;
		JMMJHCOKCGG.FIMMGPLLLCL = 1;
		JMMJHCOKCGG.JMDLKIAKOIE = ANFDAHOPDLO(NDPMDKGJAFH, "reloadTime") * base.weaponFeature.reloadCoef;
		if (grenadeAmmoSetup != null)
		{
			grenadeAmmoSetup.INIBDNGHLPN = INIBDNGHLPN;
			grenadeAmmoSetup.LIEABAMBOMG = GLBHHCOMEEB;
			grenadeAmmoSetup.KFEBGOKJGGH = IIOBCPALMLL;
			grenadeAmmoSetup.EPDELOGPNAC = ANFDAHOPDLO(NDPMDKGJAFH, "MinDamage");
			grenadeAmmoSetup.GADODCMDNFH = GADODCMDNFH;
			grenadeAmmoSetup.ABFGHBDEBAN = ANFDAHOPDLO(NDPMDKGJAFH, "ExplodeDamage") * base.weaponFeature.damageCoef;
			grenadeAmmoSetup.MAOPCAMOEEK = base.damageToPlayerBehindShieldRatio;
			if (LIEFNEPEIJO.HasColumn("DeadRadius"))
			{
				grenadeAmmoSetup.INIBDNGHLPN = ANFDAHOPDLO(NDPMDKGJAFH, "DeadRadius");
				grenadeAmmoSetup.LIEABAMBOMG = ANFDAHOPDLO(NDPMDKGJAFH, "DeadRadius") * 1.5f;
			}
			return;
		}
		throw new NullReferenceException("weapon doesnt have ammo setup");
	}

	public virtual List<Tuple<string, float[]>> JNLDADKCANP(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "CurrentBundleVersion.GetModifiedVersion - version is '{0}'", "PNManager: registration failed: ", base.weaponFeature.attackCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Wood", "getFuseID", base.weaponFeature.ammoCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "SpecialOfferSuffix", "1", base.weaponFeature.rateOfFireCoef));
		return list;
	}

	[SpecialName]
	public virtual float GGHBEHHEPJL()
	{
		if (LIEFNEPEIJO.HasColumn("ID_TUTORIAL_TAPON"))
		{
			return 1721f / (float)LIEFNEPEIJO.GetValue(MGAGEKAAJOL.OFEJOLENCKI(), "ID_GETFORNUMBERONE2");
		}
		return 519f;
	}

	public virtual List<Tuple<string, float[]>> NINIIBGAJCN(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "D3", "WarFriends cannot function without downloading these additional data. Do you really wish to QUIT or would you like to download the data?", base.weaponFeature.attackCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "\n", "G1", base.weaponFeature.ammoCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "{0} {1}", "About to show Buy Cards Reminder", base.weaponFeature.rateOfFireCoef));
		return list;
	}

	public virtual List<Tuple<string, float[]>> MJCMHPKKKBI(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Wrong_Category", "Time-limited Offers", base.weaponFeature.attackCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "2 RATE APP REMINDER\tLast game won: True\tVersion: {0}\tShown Times in this version: {1}/{2}\tTotal ranked wins: {3}?={4}\tIs level up: {5}\tLevel: {6}?={7}/{8}\tAfter update: {9}", "PlayerLeagueFinished - FORMER LEAGUE ID = {0}, current = {1}", base.weaponFeature.ammoCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Added", "ID_RELOG_TO_FB_DIALOG_TITLE", base.weaponFeature.rateOfFireCoef, true));
		return list;
	}

	public override List<Tuple<string, float[]>> GetGuiStats(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "attack", "ID_SLOTUPGRADE_POWER", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ammo", "ID_SLOTUPGRADE_AMMO", base.weaponFeature.ammoCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "reloadTime", "ID_SLOTUPGRADE_ROF", base.weaponFeature.rateOfFireCoef));
		return list;
	}

	[SpecialName]
	public virtual float GBHFMNKGAMG()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.HEKMIFHFEKN(), "FuseBoxx: Session Started")) * base.weaponFeature.damageCoef;
	}

	[SpecialName]
	public virtual float DDFMLPJCEMJ()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.GCBOONOBIKH(), "PlayerLevel")) * base.weaponFeature.damageCoef;
	}

	[SpecialName]
	public virtual float GJACJAEMACH()
	{
		if (LIEFNEPEIJO.HasColumn("1"))
		{
			return 1990f / (float)LIEFNEPEIJO.GetValue(MGAGEKAAJOL.GCBOONOBIKH(), "ID_RENTAL_SHOTGUN");
		}
		return 906f;
	}

	public virtual List<Tuple<string, float[]>> LEGEPDLIOLJ(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "menu-info-ico", "BlackMarketOffer", base.weaponFeature.attackCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "getGameConfigurationKeys", "ID_YOUNEEDMONEYTOUPGRADE", base.weaponFeature.ammoCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "WarBucks", "THANK YOU", base.weaponFeature.rateOfFireCoef, true));
		return list;
	}

	public virtual void BFAJKBKOPGK(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		GrenadeAmmoSetup grenadeAmmoSetup = JMMJHCOKCGG.ammoSetup as GrenadeAmmoSetup;
		JMMJHCOKCGG.FIMMGPLLLCL = 1;
		JMMJHCOKCGG.JMDLKIAKOIE = ANFDAHOPDLO(NDPMDKGJAFH, "game-card-ico-shielddestroyer") * base.weaponFeature.reloadCoef;
		if (grenadeAmmoSetup != null)
		{
			grenadeAmmoSetup.INIBDNGHLPN = INIBDNGHLPN;
			grenadeAmmoSetup.LIEABAMBOMG = GLBHHCOMEEB;
			grenadeAmmoSetup.KFEBGOKJGGH = IIOBCPALMLL;
			grenadeAmmoSetup.EPDELOGPNAC = ANFDAHOPDLO(NDPMDKGJAFH, "EDEFCFDDCJB");
			grenadeAmmoSetup.GADODCMDNFH = GADODCMDNFH;
			grenadeAmmoSetup.ABFGHBDEBAN = ANFDAHOPDLO(NDPMDKGJAFH, "com.tune.unityutils.TuneUnityPowerHooksListener") * base.weaponFeature.damageCoef;
			grenadeAmmoSetup.MAOPCAMOEEK = base.damageToPlayerBehindShieldRatio;
			if (LIEFNEPEIJO.HasColumn("EnableData()"))
			{
				grenadeAmmoSetup.INIBDNGHLPN = ANFDAHOPDLO(NDPMDKGJAFH, "com/google/android/gms/common/ConnectionResult");
				grenadeAmmoSetup.LIEABAMBOMG = ANFDAHOPDLO(NDPMDKGJAFH, "ID_TUTORIAL_UPGRADEUNIT_3") * 1118f;
			}
			return;
		}
		throw new NullReferenceException("Fb_login");
	}

	[SpecialName]
	public virtual float KFIFBJEOCKF()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.HEKMIFHFEKN(), "ID_WARNING_BLACKMARKETDOESNTEXIST")) * base.weaponFeature.damageCoef;
	}

	public virtual void NJADOBPJKAH(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		GrenadeAmmoSetup grenadeAmmoSetup = JMMJHCOKCGG.ammoSetup as GrenadeAmmoSetup;
		JMMJHCOKCGG.FIMMGPLLLCL = 1;
		JMMJHCOKCGG.JMDLKIAKOIE = ANFDAHOPDLO(NDPMDKGJAFH, "create new account and add FB") * base.weaponFeature.reloadCoef;
		if (grenadeAmmoSetup != null)
		{
			grenadeAmmoSetup.INIBDNGHLPN = INIBDNGHLPN;
			grenadeAmmoSetup.LIEABAMBOMG = GLBHHCOMEEB;
			grenadeAmmoSetup.KFEBGOKJGGH = IIOBCPALMLL;
			grenadeAmmoSetup.EPDELOGPNAC = ANFDAHOPDLO(NDPMDKGJAFH, "Number");
			grenadeAmmoSetup.GADODCMDNFH = GADODCMDNFH;
			grenadeAmmoSetup.ABFGHBDEBAN = ANFDAHOPDLO(NDPMDKGJAFH, "?") * base.weaponFeature.damageCoef;
			grenadeAmmoSetup.MAOPCAMOEEK = base.damageToPlayerBehindShieldRatio;
			if (LIEFNEPEIJO.HasColumn("ID_SILVER"))
			{
				grenadeAmmoSetup.INIBDNGHLPN = ANFDAHOPDLO(NDPMDKGJAFH, "Changing label \"{0}\" with pivot \"{1}\". New size {2} and yDown {3}.");
				grenadeAmmoSetup.LIEABAMBOMG = ANFDAHOPDLO(NDPMDKGJAFH, "MatchesToNextLootboxes") * 475f;
			}
			return;
		}
		throw new NullReferenceException("showed");
	}

	[SpecialName]
	public virtual float KJPBBEFCMPH()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.AGKHAOLEHDE(), "0")) * base.weaponFeature.damageCoef;
	}

	public virtual void GBGGKPEOCGA(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		GrenadeAmmoSetup grenadeAmmoSetup = JMMJHCOKCGG.ammoSetup as GrenadeAmmoSetup;
		JMMJHCOKCGG.FIMMGPLLLCL = 0;
		JMMJHCOKCGG.JMDLKIAKOIE = ANFDAHOPDLO(NDPMDKGJAFH, "attrValue13") * base.weaponFeature.reloadCoef;
		if (grenadeAmmoSetup != null)
		{
			grenadeAmmoSetup.INIBDNGHLPN = INIBDNGHLPN;
			grenadeAmmoSetup.LIEABAMBOMG = GLBHHCOMEEB;
			grenadeAmmoSetup.KFEBGOKJGGH = IIOBCPALMLL;
			grenadeAmmoSetup.EPDELOGPNAC = ANFDAHOPDLO(NDPMDKGJAFH, "05");
			grenadeAmmoSetup.GADODCMDNFH = GADODCMDNFH;
			grenadeAmmoSetup.ABFGHBDEBAN = ANFDAHOPDLO(NDPMDKGJAFH, "Google2u.AssaultRifle_AK47") * base.weaponFeature.damageCoef;
			grenadeAmmoSetup.MAOPCAMOEEK = base.damageToPlayerBehindShieldRatio;
			if (LIEFNEPEIJO.HasColumn("ID_GOLD"))
			{
				grenadeAmmoSetup.INIBDNGHLPN = ANFDAHOPDLO(NDPMDKGJAFH, "    promote:{0}");
				grenadeAmmoSetup.LIEABAMBOMG = ANFDAHOPDLO(NDPMDKGJAFH, "App installed") * 772f;
			}
			return;
		}
		throw new NullReferenceException("S");
	}

	public virtual void JHFCHJDJJAE(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		GrenadeAmmoSetup grenadeAmmoSetup = JMMJHCOKCGG.ammoSetup as GrenadeAmmoSetup;
		JMMJHCOKCGG.FIMMGPLLLCL = 0;
		JMMJHCOKCGG.JMDLKIAKOIE = ANFDAHOPDLO(NDPMDKGJAFH, "Skip assignment success") * base.weaponFeature.reloadCoef;
		if (grenadeAmmoSetup != null)
		{
			grenadeAmmoSetup.INIBDNGHLPN = INIBDNGHLPN;
			grenadeAmmoSetup.LIEABAMBOMG = GLBHHCOMEEB;
			grenadeAmmoSetup.KFEBGOKJGGH = IIOBCPALMLL;
			grenadeAmmoSetup.EPDELOGPNAC = ANFDAHOPDLO(NDPMDKGJAFH, "ID_GETFORNUMBERONE1");
			grenadeAmmoSetup.GADODCMDNFH = GADODCMDNFH;
			grenadeAmmoSetup.ABFGHBDEBAN = ANFDAHOPDLO(NDPMDKGJAFH, "isRandomMap") * base.weaponFeature.damageCoef;
			grenadeAmmoSetup.MAOPCAMOEEK = base.damageToPlayerBehindShieldRatio;
			if (LIEFNEPEIJO.HasColumn("com/google/android/gms/games/Games"))
			{
				grenadeAmmoSetup.INIBDNGHLPN = ANFDAHOPDLO(NDPMDKGJAFH, "ID_GETAPROMOTION2");
				grenadeAmmoSetup.LIEABAMBOMG = ANFDAHOPDLO(NDPMDKGJAFH, "Different names \"{0}\" and \"{1}\"\n") * 654f;
			}
			return;
		}
		throw new NullReferenceException("MaintenanceMessage");
	}

	public virtual void IOBDCCGDPEN(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		GrenadeAmmoSetup grenadeAmmoSetup = JMMJHCOKCGG.ammoSetup as GrenadeAmmoSetup;
		JMMJHCOKCGG.FIMMGPLLLCL = 1;
		JMMJHCOKCGG.JMDLKIAKOIE = ANFDAHOPDLO(NDPMDKGJAFH, "ID_MEMBERS") * base.weaponFeature.reloadCoef;
		if (grenadeAmmoSetup != null)
		{
			grenadeAmmoSetup.INIBDNGHLPN = INIBDNGHLPN;
			grenadeAmmoSetup.LIEABAMBOMG = GLBHHCOMEEB;
			grenadeAmmoSetup.KFEBGOKJGGH = IIOBCPALMLL;
			grenadeAmmoSetup.EPDELOGPNAC = ANFDAHOPDLO(NDPMDKGJAFH, "ID_BUTTON_YOURSQUAD");
			grenadeAmmoSetup.GADODCMDNFH = GADODCMDNFH;
			grenadeAmmoSetup.ABFGHBDEBAN = ANFDAHOPDLO(NDPMDKGJAFH, "Total_Gold_Spent") * base.weaponFeature.damageCoef;
			grenadeAmmoSetup.MAOPCAMOEEK = base.damageToPlayerBehindShieldRatio;
			if (LIEFNEPEIJO.HasColumn("Total_Sessions"))
			{
				grenadeAmmoSetup.INIBDNGHLPN = ANFDAHOPDLO(NDPMDKGJAFH, "OnPhotonJoinRoomFailed: {0}, message {1}");
				grenadeAmmoSetup.LIEABAMBOMG = ANFDAHOPDLO(NDPMDKGJAFH, " was BuyAndActivated.") * 1106f;
			}
			return;
		}
		throw new NullReferenceException("BotLevel");
	}

	public virtual void HALBFOCGMAE(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		GrenadeAmmoSetup grenadeAmmoSetup = JMMJHCOKCGG.ammoSetup as GrenadeAmmoSetup;
		JMMJHCOKCGG.FIMMGPLLLCL = 0;
		JMMJHCOKCGG.JMDLKIAKOIE = ANFDAHOPDLO(NDPMDKGJAFH, "ID_FORFEIT") * base.weaponFeature.reloadCoef;
		if (grenadeAmmoSetup != null)
		{
			grenadeAmmoSetup.INIBDNGHLPN = INIBDNGHLPN;
			grenadeAmmoSetup.LIEABAMBOMG = GLBHHCOMEEB;
			grenadeAmmoSetup.KFEBGOKJGGH = IIOBCPALMLL;
			grenadeAmmoSetup.EPDELOGPNAC = ANFDAHOPDLO(NDPMDKGJAFH, "SetAutoRepairRPC");
			grenadeAmmoSetup.GADODCMDNFH = GADODCMDNFH;
			grenadeAmmoSetup.ABFGHBDEBAN = ANFDAHOPDLO(NDPMDKGJAFH, "null image url for offer!") * base.weaponFeature.damageCoef;
			grenadeAmmoSetup.MAOPCAMOEEK = base.damageToPlayerBehindShieldRatio;
			if (LIEFNEPEIJO.HasColumn("{0}{1}{2}"))
			{
				grenadeAmmoSetup.INIBDNGHLPN = ANFDAHOPDLO(NDPMDKGJAFH, "FacebookId");
				grenadeAmmoSetup.LIEABAMBOMG = ANFDAHOPDLO(NDPMDKGJAFH, "OBB: Read Test - Bytes read ") * 99f;
			}
			return;
		}
		throw new NullReferenceException("ID_CATEGORY_LOW_PL_HANDGUN");
	}

	[SpecialName]
	public virtual float ODPCNBNFDIN()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.LHLGAAEEKID(), "isNotificationAvailable")) * base.weaponFeature.damageCoef;
	}

	public virtual void DBDNCFEAGOE(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		GrenadeAmmoSetup grenadeAmmoSetup = JMMJHCOKCGG.ammoSetup as GrenadeAmmoSetup;
		JMMJHCOKCGG.FIMMGPLLLCL = 0;
		JMMJHCOKCGG.JMDLKIAKOIE = ANFDAHOPDLO(NDPMDKGJAFH, "ID_CHANGENAMENOTENOUGHT") * base.weaponFeature.reloadCoef;
		if (grenadeAmmoSetup != null)
		{
			grenadeAmmoSetup.INIBDNGHLPN = INIBDNGHLPN;
			grenadeAmmoSetup.LIEABAMBOMG = GLBHHCOMEEB;
			grenadeAmmoSetup.KFEBGOKJGGH = IIOBCPALMLL;
			grenadeAmmoSetup.EPDELOGPNAC = ANFDAHOPDLO(NDPMDKGJAFH, "Wave");
			grenadeAmmoSetup.GADODCMDNFH = GADODCMDNFH;
			grenadeAmmoSetup.ABFGHBDEBAN = ANFDAHOPDLO(NDPMDKGJAFH, "TuneListener trackerDidEnqueueRequest: ") * base.weaponFeature.damageCoef;
			grenadeAmmoSetup.MAOPCAMOEEK = base.damageToPlayerBehindShieldRatio;
			if (LIEFNEPEIJO.HasColumn("\t\"TRUE\""))
			{
				grenadeAmmoSetup.INIBDNGHLPN = ANFDAHOPDLO(NDPMDKGJAFH, "#AccoutCheck# Account exist check result NOT contain result message");
				grenadeAmmoSetup.LIEABAMBOMG = ANFDAHOPDLO(NDPMDKGJAFH, "WinLooseStreak") * 1010f;
			}
			return;
		}
		throw new NullReferenceException("ID_ARENARULES_SHIELDSBREAKFASTER");
	}

	public virtual List<Tuple<string, float[]>> DNPNJANKBKK(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "menu-arena-scrap-ico", "MessageId", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "GUiManager", "userId", base.weaponFeature.ammoCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Current Language = ", "gold", base.weaponFeature.rateOfFireCoef));
		return list;
	}

	[SpecialName]
	public virtual float HLDIMIEIAAL()
	{
		if (LIEFNEPEIJO.HasColumn("RegisterEvent("))
		{
			return 749f / (float)LIEFNEPEIJO.GetValue(MGAGEKAAJOL.KMHMJEDDNOP(), "vveteranpack");
		}
		return 1838f;
	}

	[SpecialName]
	public virtual float LEHDHPLDAAJ()
	{
		if (LIEFNEPEIJO.HasColumn("Status"))
		{
			return 745f / (float)LIEFNEPEIJO.GetValue(MGAGEKAAJOL.HEKMIFHFEKN(), "Cant generate buddy card for weapons: {0}, {1} and type {2}");
		}
		return 1450f;
	}

	public virtual List<Tuple<string, float[]>> GGJPOKKDBOH(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "START PLAYING TUTORIAL", "Claim_Reward", base.weaponFeature.attackCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Scripts Full Path: \"{0}\"\n", "Player_Waited_Till_Delivery_Ends", base.weaponFeature.ammoCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_YES", "set schedule gc check 1", base.weaponFeature.rateOfFireCoef));
		return list;
	}

	public virtual List<Tuple<string, float[]>> EGDGLHHKKHE(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "TranslationIdFinder.cs", "Autodeploy_On", base.weaponFeature.attackCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Google2u.AssaultRifle_AK47", "ID_STATE_READYFORBATTLE", base.weaponFeature.ammoCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Physical ammo is null !!!", "*****   Bootcamp 3/3 Ended   *****", base.weaponFeature.rateOfFireCoef));
		return list;
	}

	public virtual void MILIIGHFAAA(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		GrenadeAmmoSetup grenadeAmmoSetup = JMMJHCOKCGG.ammoSetup as GrenadeAmmoSetup;
		JMMJHCOKCGG.FIMMGPLLLCL = 1;
		JMMJHCOKCGG.JMDLKIAKOIE = ANFDAHOPDLO(NDPMDKGJAFH, "ID_SKILLSHOTHINT_RUNNER") * base.weaponFeature.reloadCoef;
		if (grenadeAmmoSetup != null)
		{
			grenadeAmmoSetup.INIBDNGHLPN = INIBDNGHLPN;
			grenadeAmmoSetup.LIEABAMBOMG = GLBHHCOMEEB;
			grenadeAmmoSetup.KFEBGOKJGGH = IIOBCPALMLL;
			grenadeAmmoSetup.EPDELOGPNAC = ANFDAHOPDLO(NDPMDKGJAFH, "ID_WAITINGFORFRIEND");
			grenadeAmmoSetup.GADODCMDNFH = GADODCMDNFH;
			grenadeAmmoSetup.ABFGHBDEBAN = ANFDAHOPDLO(NDPMDKGJAFH, "ID_MISSION_KILLUNIT") * base.weaponFeature.damageCoef;
			grenadeAmmoSetup.MAOPCAMOEEK = base.damageToPlayerBehindShieldRatio;
			if (LIEFNEPEIJO.HasColumn("deliveryReduce"))
			{
				grenadeAmmoSetup.INIBDNGHLPN = ANFDAHOPDLO(NDPMDKGJAFH, "extraVip");
				grenadeAmmoSetup.LIEABAMBOMG = ANFDAHOPDLO(NDPMDKGJAFH, "Memory_warnings") * 111f;
			}
			return;
		}
		throw new NullReferenceException("ID_USEREXISTSGAMECENTERTEXT");
	}

	[SpecialName]
	public virtual float FKBOCDNDFIH()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.EJHKOFFOFOA(), "ID_CONFIRM_EXITINGMATCH")) * base.weaponFeature.damageCoef;
	}

	[SpecialName]
	public virtual float DHHBENFGFBM()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.KMHMJEDDNOP(), "AddedCards")) * base.weaponFeature.damageCoef;
	}

	public virtual List<Tuple<string, float[]>> HDPMJGABCHI(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "game-card-ico-shielddestroyer", "{0}{1}{2}", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "gold", "ID_WARNING_INCORRECTASSIGNMENTS_TEXT", base.weaponFeature.ammoCoef, true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "RegisterEvent(", "(Lcom/google/android/gms/common/api/Api;)Lcom/google/android/gms/common/ConnectionResult;", base.weaponFeature.rateOfFireCoef, true));
		return list;
	}

	public virtual List<Tuple<string, float[]>> CCJOGPPDIEM(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "AT", "{0}/videoFeedTextures/", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Exception while processing received sheets: ", "ID_NEWLOOTBOXINBATTLE", base.weaponFeature.ammoCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "something is wrong - time == 0", "game-missions-blue-mission-ico", base.weaponFeature.rateOfFireCoef));
		return list;
	}

	public virtual void HCBCECFPFBC(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		GrenadeAmmoSetup grenadeAmmoSetup = JMMJHCOKCGG.ammoSetup as GrenadeAmmoSetup;
		JMMJHCOKCGG.FIMMGPLLLCL = 0;
		JMMJHCOKCGG.JMDLKIAKOIE = ANFDAHOPDLO(NDPMDKGJAFH, "PrevLevelId") * base.weaponFeature.reloadCoef;
		if (grenadeAmmoSetup != null)
		{
			grenadeAmmoSetup.INIBDNGHLPN = INIBDNGHLPN;
			grenadeAmmoSetup.LIEABAMBOMG = GLBHHCOMEEB;
			grenadeAmmoSetup.KFEBGOKJGGH = IIOBCPALMLL;
			grenadeAmmoSetup.EPDELOGPNAC = ANFDAHOPDLO(NDPMDKGJAFH, "RETRY");
			grenadeAmmoSetup.GADODCMDNFH = GADODCMDNFH;
			grenadeAmmoSetup.ABFGHBDEBAN = ANFDAHOPDLO(NDPMDKGJAFH, "game-card-silver") * base.weaponFeature.damageCoef;
			grenadeAmmoSetup.MAOPCAMOEEK = base.damageToPlayerBehindShieldRatio;
			if (LIEFNEPEIJO.HasColumn("menu-assignments-type-cards"))
			{
				grenadeAmmoSetup.INIBDNGHLPN = ANFDAHOPDLO(NDPMDKGJAFH, "Sniper_Tutorial_Played");
				grenadeAmmoSetup.LIEABAMBOMG = ANFDAHOPDLO(NDPMDKGJAFH, "()Lcom/google/android/gms/games/stats/PlayerStats;") * 639f;
			}
			return;
		}
		throw new NullReferenceException("VipCardMessage {0}");
	}
}
