using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.Serialization;

public class BazookaLevelsSetup : WeaponLevelsSetup
{
	[FormerlySerializedAs("KBLFKIJNBEN")]
	public float INIBDNGHLPN = 0.8f;

	[FormerlySerializedAs("AFLLBBKEOKG")]
	public float GLBHHCOMEEB = 1.4f;

	public override float shotDamage => Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.boughtIndex, "explodeDamage")) * base.weaponFeature.damageCoef;

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

	[SpecialName]
	public virtual float PBJIBMAPECE()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.AGKHAOLEHDE(), "withAdvertiserRefId")) * base.weaponFeature.damageCoef;
	}

	[SpecialName]
	public virtual float BIGEJDDOIKE()
	{
		if (LIEFNEPEIJO.HasColumn("Rental"))
		{
			return 273f / (float)LIEFNEPEIJO.GetValue(MGAGEKAAJOL.MPKFMIPMCMP(), "API");
		}
		return 997f;
	}

	[SpecialName]
	public virtual float EBCOECHODHE()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.HEKMIFHFEKN(), " ")) * base.weaponFeature.damageCoef;
	}

	public virtual void HKLINMJFBBP(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		JMMJHCOKCGG.FIMMGPLLLCL = 0;
		JMMJHCOKCGG.JMDLKIAKOIE = ANFDAHOPDLO(NDPMDKGJAFH, "EndReason") * base.weaponFeature.reloadCoef;
		MissileSetup missileSetup = JMMJHCOKCGG.ammoSetup as MissileSetup;
		if (missileSetup != null)
		{
			missileSetup.INIBDNGHLPN = INIBDNGHLPN;
			missileSetup.LIEABAMBOMG = GLBHHCOMEEB;
			missileSetup.EPDELOGPNAC = ANFDAHOPDLO(NDPMDKGJAFH, "response: ");
			missileSetup.ABFGHBDEBAN = ANFDAHOPDLO(NDPMDKGJAFH, "LevelExperience") * base.weaponFeature.damageCoef;
			missileSetup.JPNAINOGAMM = base.shotVelocity;
			missileSetup.MAOPCAMOEEK = base.damageToPlayerBehindShieldRatio;
			return;
		}
		throw new NullReferenceException("Icon");
	}

	[SpecialName]
	public virtual float BGINGEDNFNM()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.KMHMJEDDNOP(), "reached max depth!")) * base.weaponFeature.damageCoef;
	}

	[SpecialName]
	public virtual float DEBOLDFPEAK()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.MPKFMIPMCMP(), "ID_GUI_LEAGUE")) * base.weaponFeature.damageCoef;
	}

	public virtual List<Tuple<string, float[]>> OENJGPIEIFM(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_SIGNIN", "ID_RANK", base.weaponFeature.attackCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "About to show Buy Cards Reminder", "requestId", base.weaponFeature.ammoCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "#PETER# League Arc ", "SetMapRPC", base.weaponFeature.rateOfFireCoef));
		return list;
	}

	[SpecialName]
	public virtual float KHOLBNOHAFE()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.OBNOCCJIMPG(), "RegisterEvent(")) * base.weaponFeature.damageCoef;
	}

	public virtual List<Tuple<string, float[]>> NINIIBGAJCN(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Cards_Owned_Bronze", "Card: {0} {1}\t\t{2}\n", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Card_1_Played", "game-card-ico-sickness", base.weaponFeature.ammoCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "null customization for: ", "open", base.weaponFeature.rateOfFireCoef, CLFOOLKGCEO: true));
		return list;
	}

	public virtual void FDGDJPAJKAA(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		JMMJHCOKCGG.FIMMGPLLLCL = 1;
		JMMJHCOKCGG.JMDLKIAKOIE = ANFDAHOPDLO(NDPMDKGJAFH, "Idle") * base.weaponFeature.reloadCoef;
		MissileSetup missileSetup = JMMJHCOKCGG.ammoSetup as MissileSetup;
		if (missileSetup != null)
		{
			missileSetup.INIBDNGHLPN = INIBDNGHLPN;
			missileSetup.LIEABAMBOMG = GLBHHCOMEEB;
			missileSetup.EPDELOGPNAC = ANFDAHOPDLO(NDPMDKGJAFH, "ID_LOADING");
			missileSetup.ABFGHBDEBAN = ANFDAHOPDLO(NDPMDKGJAFH, "Notification_MaintenanceInformation") * base.weaponFeature.damageCoef;
			missileSetup.JPNAINOGAMM = base.shotVelocity;
			missileSetup.MAOPCAMOEEK = base.damageToPlayerBehindShieldRatio;
			return;
		}
		throw new NullReferenceException("-");
	}

	public virtual void BDKALGOIBLD(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		JMMJHCOKCGG.FIMMGPLLLCL = 0;
		JMMJHCOKCGG.JMDLKIAKOIE = ANFDAHOPDLO(NDPMDKGJAFH, "special") * base.weaponFeature.reloadCoef;
		MissileSetup missileSetup = JMMJHCOKCGG.ammoSetup as MissileSetup;
		if (missileSetup != null)
		{
			missileSetup.INIBDNGHLPN = INIBDNGHLPN;
			missileSetup.LIEABAMBOMG = GLBHHCOMEEB;
			missileSetup.EPDELOGPNAC = ANFDAHOPDLO(NDPMDKGJAFH, "Null +");
			missileSetup.ABFGHBDEBAN = ANFDAHOPDLO(NDPMDKGJAFH, "Attempt") * base.weaponFeature.damageCoef;
			missileSetup.JPNAINOGAMM = base.shotVelocity;
			missileSetup.MAOPCAMOEEK = base.damageToPlayerBehindShieldRatio;
			return;
		}
		throw new NullReferenceException("null");
	}

	public virtual void EKIOKFIEPDL(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		JMMJHCOKCGG.FIMMGPLLLCL = 0;
		JMMJHCOKCGG.JMDLKIAKOIE = ANFDAHOPDLO(NDPMDKGJAFH, "bazooka_run") * base.weaponFeature.reloadCoef;
		MissileSetup missileSetup = JMMJHCOKCGG.ammoSetup as MissileSetup;
		if (missileSetup != null)
		{
			missileSetup.INIBDNGHLPN = INIBDNGHLPN;
			missileSetup.LIEABAMBOMG = GLBHHCOMEEB;
			missileSetup.EPDELOGPNAC = ANFDAHOPDLO(NDPMDKGJAFH, "ID_XTICKETS");
			missileSetup.ABFGHBDEBAN = ANFDAHOPDLO(NDPMDKGJAFH, ">$500") * base.weaponFeature.damageCoef;
			missileSetup.JPNAINOGAMM = base.shotVelocity;
			missileSetup.MAOPCAMOEEK = base.damageToPlayerBehindShieldRatio;
			return;
		}
		throw new NullReferenceException("percent");
	}

	[SpecialName]
	public virtual float FCNDBNMPAGE()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.OFEJOLENCKI(), "Tutorial_Step_Complete")) * base.weaponFeature.damageCoef;
	}

	public virtual void AMPLDFEPJFP(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		JMMJHCOKCGG.FIMMGPLLLCL = 1;
		JMMJHCOKCGG.JMDLKIAKOIE = ANFDAHOPDLO(NDPMDKGJAFH, "END SUBSCREEN OBJECT: {0}\nERROR: {1}\nSTACKTRACE: {2}") * base.weaponFeature.reloadCoef;
		MissileSetup missileSetup = JMMJHCOKCGG.ammoSetup as MissileSetup;
		if (missileSetup != null)
		{
			missileSetup.INIBDNGHLPN = INIBDNGHLPN;
			missileSetup.LIEABAMBOMG = GLBHHCOMEEB;
			missileSetup.EPDELOGPNAC = ANFDAHOPDLO(NDPMDKGJAFH, "Show reconnect dialog isPaused");
			missileSetup.ABFGHBDEBAN = ANFDAHOPDLO(NDPMDKGJAFH, "ID_GUI_EQUIPPED") * base.weaponFeature.damageCoef;
			missileSetup.JPNAINOGAMM = base.shotVelocity;
			missileSetup.MAOPCAMOEEK = base.damageToPlayerBehindShieldRatio;
			return;
		}
		throw new NullReferenceException("game-card-ico-streakboost-full");
	}

	[SpecialName]
	public virtual float LGIAOANEKJN()
	{
		if (LIEFNEPEIJO.HasColumn("market://details?id={0}"))
		{
			return 900f / (float)LIEFNEPEIJO.GetValue(MGAGEKAAJOL.OBNOCCJIMPG(), "USD");
		}
		return 292f;
	}

	public virtual void HKNJPECAMPB(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		JMMJHCOKCGG.FIMMGPLLLCL = 1;
		JMMJHCOKCGG.JMDLKIAKOIE = ANFDAHOPDLO(NDPMDKGJAFH, "SquadId") * base.weaponFeature.reloadCoef;
		MissileSetup missileSetup = JMMJHCOKCGG.ammoSetup as MissileSetup;
		if (missileSetup != null)
		{
			missileSetup.INIBDNGHLPN = INIBDNGHLPN;
			missileSetup.LIEABAMBOMG = GLBHHCOMEEB;
			missileSetup.EPDELOGPNAC = ANFDAHOPDLO(NDPMDKGJAFH, "SA");
			missileSetup.ABFGHBDEBAN = ANFDAHOPDLO(NDPMDKGJAFH, "Exception message: ") * base.weaponFeature.damageCoef;
			missileSetup.JPNAINOGAMM = base.shotVelocity;
			missileSetup.MAOPCAMOEEK = base.damageToPlayerBehindShieldRatio;
			return;
		}
		throw new NullReferenceException("Region");
	}

	[SpecialName]
	public virtual float HAKHPLHKHHN()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.GCBOONOBIKH(), "Different actual league Id \"{0}\" and database message - league entered - league id \"{1}\"")) * base.weaponFeature.damageCoef;
	}

	[SpecialName]
	public virtual float CJKNEJFAMKJ()
	{
		if (LIEFNEPEIJO.HasColumn("check.php"))
		{
			return 520f / (float)LIEFNEPEIJO.GetValue(MGAGEKAAJOL.AGKHAOLEHDE(), "kr");
		}
		return 714f;
	}

	public virtual void MHIAFEEOODN(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		JMMJHCOKCGG.FIMMGPLLLCL = 0;
		JMMJHCOKCGG.JMDLKIAKOIE = ANFDAHOPDLO(NDPMDKGJAFH, "{0} / [F0CE28]{1}[-]") * base.weaponFeature.reloadCoef;
		MissileSetup missileSetup = JMMJHCOKCGG.ammoSetup as MissileSetup;
		if (missileSetup != null)
		{
			missileSetup.INIBDNGHLPN = INIBDNGHLPN;
			missileSetup.LIEABAMBOMG = GLBHHCOMEEB;
			missileSetup.EPDELOGPNAC = ANFDAHOPDLO(NDPMDKGJAFH, "Level");
			missileSetup.ABFGHBDEBAN = ANFDAHOPDLO(NDPMDKGJAFH, "setCustomProfileNumber") * base.weaponFeature.damageCoef;
			missileSetup.JPNAINOGAMM = base.shotVelocity;
			missileSetup.MAOPCAMOEEK = base.damageToPlayerBehindShieldRatio;
			return;
		}
		throw new NullReferenceException("S");
	}

	public virtual void OIHHBFMPOIM(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		JMMJHCOKCGG.FIMMGPLLLCL = 1;
		JMMJHCOKCGG.JMDLKIAKOIE = ANFDAHOPDLO(NDPMDKGJAFH, "opponentState.willHide = true") * base.weaponFeature.reloadCoef;
		MissileSetup missileSetup = JMMJHCOKCGG.ammoSetup as MissileSetup;
		if (missileSetup != null)
		{
			missileSetup.INIBDNGHLPN = INIBDNGHLPN;
			missileSetup.LIEABAMBOMG = GLBHHCOMEEB;
			missileSetup.EPDELOGPNAC = ANFDAHOPDLO(NDPMDKGJAFH, "Overtime_Was_Already_Explained");
			missileSetup.ABFGHBDEBAN = ANFDAHOPDLO(NDPMDKGJAFH, "#VAVRO# OnLeftRoom") * base.weaponFeature.damageCoef;
			missileSetup.JPNAINOGAMM = base.shotVelocity;
			missileSetup.MAOPCAMOEEK = base.damageToPlayerBehindShieldRatio;
			return;
		}
		throw new NullReferenceException("RequestBuffer ");
	}

	[SpecialName]
	public virtual float GBJONDEKELN()
	{
		if (LIEFNEPEIJO.HasColumn("0"))
		{
			return 411f / (float)LIEFNEPEIJO.GetValue(MGAGEKAAJOL.PNKECEJELDP(), " GC connect: ");
		}
		return 845f;
	}

	public virtual List<Tuple<string, float[]>> OMCNBBABIHG(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "PlayerId", "BS: Cheater report sent! PlayerID = ", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, " NOT OK!\t\t\t\t\t\t", "arena", base.weaponFeature.ammoCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "C0", "ID_TUTORIAL_WARCARDS_STARTDOWN", base.weaponFeature.rateOfFireCoef, CLFOOLKGCEO: true));
		return list;
	}

	[SpecialName]
	public virtual float CBGOFHJGMIE()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.MPKFMIPMCMP(), "ID_GOLD")) * base.weaponFeature.damageCoef;
	}

	[SpecialName]
	public virtual float JBDICNOIONM()
	{
		if (LIEFNEPEIJO.HasColumn("StarterAssignmentsReward"))
		{
			return 154f / (float)LIEFNEPEIJO.GetValue(MGAGEKAAJOL.AGKHAOLEHDE(), "hasNext");
		}
		return 1400f;
	}

	[SpecialName]
	public virtual float ANCOBKDLFFB()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.EJHKOFFOFOA(), "ВЫХОД")) * base.weaponFeature.damageCoef;
	}

	public virtual void MFAGEMPNKJL(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		JMMJHCOKCGG.FIMMGPLLLCL = 0;
		JMMJHCOKCGG.JMDLKIAKOIE = ANFDAHOPDLO(NDPMDKGJAFH, "ArmyPower") * base.weaponFeature.reloadCoef;
		MissileSetup missileSetup = JMMJHCOKCGG.ammoSetup as MissileSetup;
		if (missileSetup != null)
		{
			missileSetup.INIBDNGHLPN = INIBDNGHLPN;
			missileSetup.LIEABAMBOMG = GLBHHCOMEEB;
			missileSetup.EPDELOGPNAC = ANFDAHOPDLO(NDPMDKGJAFH, "ID_MATCH_STARTS_IN");
			missileSetup.ABFGHBDEBAN = ANFDAHOPDLO(NDPMDKGJAFH, "Matchmaking took {0}, assigning bot in 10 secs") * base.weaponFeature.damageCoef;
			missileSetup.JPNAINOGAMM = base.shotVelocity;
			missileSetup.MAOPCAMOEEK = base.damageToPlayerBehindShieldRatio;
			return;
		}
		throw new NullReferenceException("spriteCollectionTextureCompressed");
	}

	[SpecialName]
	public virtual float ELPPAHNJHFC()
	{
		if (LIEFNEPEIJO.HasColumn("0"))
		{
			return 413f / (float)LIEFNEPEIJO.GetValue(MGAGEKAAJOL.OBNOCCJIMPG(), "country-bulgaria");
		}
		return 1095f;
	}

	public virtual List<Tuple<string, float[]>> JIFPIHMLAGA(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "_TintColor", "RewardValue", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "S", "GR", base.weaponFeature.ammoCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_GUI_SQUADKICK", "null", base.weaponFeature.rateOfFireCoef));
		return list;
	}

	public virtual List<Tuple<string, float[]>> LKKPMAGKMPE(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_SELECTONEUNIT", "ID_CONFIRM_LANGUAGECHANGE_TEXT", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "S", "menu-warbucks", base.weaponFeature.ammoCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "RewardType", "ExpectedPrice", base.weaponFeature.rateOfFireCoef));
		return list;
	}

	public virtual List<Tuple<string, float[]>> EGDGLHHKKHE(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_CLAIM", "Medals/", base.weaponFeature.attackCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "EDEFCFDDCJB", "ClientId", base.weaponFeature.ammoCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_CONFIRM_FORFEIT_TEXT", "Buy_Dogtags_With_Gold", base.weaponFeature.rateOfFireCoef, CLFOOLKGCEO: true));
		return list;
	}

	[SpecialName]
	public virtual float EHABCANDMKB()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.AGKHAOLEHDE(), "Slon")) * base.weaponFeature.damageCoef;
	}

	[SpecialName]
	public virtual float JFCJOHCPJLL()
	{
		if (LIEFNEPEIJO.HasColumn("U"))
		{
			return 1090f / (float)LIEFNEPEIJO.GetValue(MGAGEKAAJOL.MPKFMIPMCMP(), "dogtag");
		}
		return 43f;
	}

	public virtual List<Tuple<string, float[]>> CCJOGPPDIEM(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "menu-gold", "special", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "121 MENU WEAPON SCREEN SHOWN", "#PETER# League Arc - stop ignore on ", base.weaponFeature.ammoCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Shown_Before_Times", "S", base.weaponFeature.rateOfFireCoef));
		return list;
	}

	[SpecialName]
	public virtual float ABINHLLBAEA()
	{
		if (LIEFNEPEIJO.HasColumn("oo"))
		{
			return 593f / (float)LIEFNEPEIJO.GetValue(MGAGEKAAJOL.OBNOCCJIMPG(), "BeginnersLeague");
		}
		return 1966f;
	}

	public virtual void GBGGKPEOCGA(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		JMMJHCOKCGG.FIMMGPLLLCL = 1;
		JMMJHCOKCGG.JMDLKIAKOIE = ANFDAHOPDLO(NDPMDKGJAFH, "ID_STAT_ARENALOOTBOXES") * base.weaponFeature.reloadCoef;
		MissileSetup missileSetup = JMMJHCOKCGG.ammoSetup as MissileSetup;
		if (missileSetup != null)
		{
			missileSetup.INIBDNGHLPN = INIBDNGHLPN;
			missileSetup.LIEABAMBOMG = GLBHHCOMEEB;
			missileSetup.EPDELOGPNAC = ANFDAHOPDLO(NDPMDKGJAFH, "MaxOnField");
			missileSetup.ABFGHBDEBAN = ANFDAHOPDLO(NDPMDKGJAFH, "{0} ({1})") * base.weaponFeature.damageCoef;
			missileSetup.JPNAINOGAMM = base.shotVelocity;
			missileSetup.MAOPCAMOEEK = base.damageToPlayerBehindShieldRatio;
			return;
		}
		throw new NullReferenceException("Please add object to pool, before instanciing it ::: prefab name = ");
	}

	[SpecialName]
	public virtual float GJACJAEMACH()
	{
		if (LIEFNEPEIJO.HasColumn("Error in Resync OwnerId: {0}, My Id: {1}, isOwnerActive: {2}, isMasterClient:{3}"))
		{
			return 1621f / (float)LIEFNEPEIJO.GetValue(MGAGEKAAJOL.BDNCLOPCDLO(), "ru");
		}
		return 547f;
	}

	public virtual List<Tuple<string, float[]>> CEMPABGJBMH(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "GoldBalance", "_Existing_User", base.weaponFeature.attackCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, " ", "125 MENU WEAPON SCREEN TUTORIAL WEAPON EQUIPPED", base.weaponFeature.ammoCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Rank", "ID_STARTERASSIGNMENTSEXPIRED", base.weaponFeature.rateOfFireCoef, CLFOOLKGCEO: true));
		return list;
	}

	public virtual List<Tuple<string, float[]>> LGGEIGLAAFC(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "]=", "ID_PLAYBATTLETOENTERBRONZELEAGUE", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_GETAPROMOTION2", "myLobby", base.weaponFeature.ammoCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Skipping next daily reward notification", "GameGold", base.weaponFeature.rateOfFireCoef));
		return list;
	}

	[SpecialName]
	public virtual float CKKGLPPNMGG()
	{
		if (LIEFNEPEIJO.HasColumn("com/google/android/gms/common/ConnectionResult"))
		{
			return 114f / (float)LIEFNEPEIJO.GetValue(MGAGEKAAJOL.AGKHAOLEHDE(), "game-ico-poison");
		}
		return 46f;
	}

	[SpecialName]
	public virtual float GJPLOINGHKP()
	{
		if (LIEFNEPEIJO.HasColumn("HeroicMissionsCompletionRewardTickets"))
		{
			return 130f / (float)LIEFNEPEIJO.GetValue(MGAGEKAAJOL.AGKHAOLEHDE(), "jp");
		}
		return 193f;
	}

	public virtual List<Tuple<string, float[]>> CIKEPOGFEPO(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Xp", "unit", base.weaponFeature.attackCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "init", "flight_forward_jetpack_elite", base.weaponFeature.ammoCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "\":\n", "Button \"{0}\" has no assigned box collider.", base.weaponFeature.rateOfFireCoef));
		return list;
	}

	public virtual List<Tuple<string, float[]>> OHLBGACPKIB(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "shield_shot", "I", base.weaponFeature.attackCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Version", "dailyRewardData", base.weaponFeature.ammoCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "getIsPayingUser", "WARARENA", base.weaponFeature.rateOfFireCoef));
		return list;
	}

	public virtual void PKAMMPBHAII(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		JMMJHCOKCGG.FIMMGPLLLCL = 0;
		JMMJHCOKCGG.JMDLKIAKOIE = ANFDAHOPDLO(NDPMDKGJAFH, "BS: On Skip Assignemnt") * base.weaponFeature.reloadCoef;
		MissileSetup missileSetup = JMMJHCOKCGG.ammoSetup as MissileSetup;
		if (missileSetup != null)
		{
			missileSetup.INIBDNGHLPN = INIBDNGHLPN;
			missileSetup.LIEABAMBOMG = GLBHHCOMEEB;
			missileSetup.EPDELOGPNAC = ANFDAHOPDLO(NDPMDKGJAFH, "ExtraRewards");
			missileSetup.ABFGHBDEBAN = ANFDAHOPDLO(NDPMDKGJAFH, "ID_DEBUG_STACKTRACEINCONSOLE") * base.weaponFeature.damageCoef;
			missileSetup.JPNAINOGAMM = base.shotVelocity;
			missileSetup.MAOPCAMOEEK = base.damageToPlayerBehindShieldRatio;
			return;
		}
		throw new NullReferenceException("response contain VipReward");
	}

	[SpecialName]
	public virtual float NJMNOGLEHCC()
	{
		if (LIEFNEPEIJO.HasColumn("SALIR"))
		{
			return 1840f / (float)LIEFNEPEIJO.GetValue(MGAGEKAAJOL.EJHKOFFOFOA(), "DailyRewardMonthScreen: init gui vlaues called");
		}
		return 1403f;
	}

	[SpecialName]
	public virtual float HEBLLCMADLF()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.BDNCLOPCDLO(), "D3")) * base.weaponFeature.damageCoef;
	}

	[SpecialName]
	public virtual float NFJGIKDBEPI()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.LHLGAAEEKID(), "RECEIVED LOOTBOX")) * base.weaponFeature.damageCoef;
	}

	[SpecialName]
	public virtual float HEOBDCOOEJB()
	{
		if (LIEFNEPEIJO.HasColumn("Type"))
		{
			return 1918f / (float)LIEFNEPEIJO.GetValue(MGAGEKAAJOL.MPKFMIPMCMP(), "0");
		}
		return 186f;
	}

	public virtual void GHDOKLENGGB(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		JMMJHCOKCGG.FIMMGPLLLCL = 1;
		JMMJHCOKCGG.JMDLKIAKOIE = ANFDAHOPDLO(NDPMDKGJAFH, "extraVip") * base.weaponFeature.reloadCoef;
		MissileSetup missileSetup = JMMJHCOKCGG.ammoSetup as MissileSetup;
		if (missileSetup != null)
		{
			missileSetup.INIBDNGHLPN = INIBDNGHLPN;
			missileSetup.LIEABAMBOMG = GLBHHCOMEEB;
			missileSetup.EPDELOGPNAC = ANFDAHOPDLO(NDPMDKGJAFH, "Yes_Clicked");
			missileSetup.ABFGHBDEBAN = ANFDAHOPDLO(NDPMDKGJAFH, "BotWeaponPower") * base.weaponFeature.damageCoef;
			missileSetup.JPNAINOGAMM = base.shotVelocity;
			missileSetup.MAOPCAMOEEK = base.damageToPlayerBehindShieldRatio;
			return;
		}
		throw new NullReferenceException("menu-sidetab-bg-box");
	}

	public virtual void DAPHCFPKAEK(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		JMMJHCOKCGG.FIMMGPLLLCL = 1;
		JMMJHCOKCGG.JMDLKIAKOIE = ANFDAHOPDLO(NDPMDKGJAFH, "否") * base.weaponFeature.reloadCoef;
		MissileSetup missileSetup = JMMJHCOKCGG.ammoSetup as MissileSetup;
		if (missileSetup != null)
		{
			missileSetup.INIBDNGHLPN = INIBDNGHLPN;
			missileSetup.LIEABAMBOMG = GLBHHCOMEEB;
			missileSetup.EPDELOGPNAC = ANFDAHOPDLO(NDPMDKGJAFH, "ID_ARENAHEROES");
			missileSetup.ABFGHBDEBAN = ANFDAHOPDLO(NDPMDKGJAFH, "menu-squadpoint-ico") * base.weaponFeature.damageCoef;
			missileSetup.JPNAINOGAMM = base.shotVelocity;
			missileSetup.MAOPCAMOEEK = base.damageToPlayerBehindShieldRatio;
			return;
		}
		throw new NullReferenceException("Rewards");
	}

	public virtual void GEEJBAEFJCM(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		JMMJHCOKCGG.FIMMGPLLLCL = 1;
		JMMJHCOKCGG.JMDLKIAKOIE = ANFDAHOPDLO(NDPMDKGJAFH, "{0}") * base.weaponFeature.reloadCoef;
		MissileSetup missileSetup = JMMJHCOKCGG.ammoSetup as MissileSetup;
		if (missileSetup != null)
		{
			missileSetup.INIBDNGHLPN = INIBDNGHLPN;
			missileSetup.LIEABAMBOMG = GLBHHCOMEEB;
			missileSetup.EPDELOGPNAC = ANFDAHOPDLO(NDPMDKGJAFH, "#AccoutCheck# GamecenterChangeDuringTutorial - NOT connect -> ignore for this moment");
			missileSetup.ABFGHBDEBAN = ANFDAHOPDLO(NDPMDKGJAFH, "squad") * base.weaponFeature.damageCoef;
			missileSetup.JPNAINOGAMM = base.shotVelocity;
			missileSetup.MAOPCAMOEEK = base.damageToPlayerBehindShieldRatio;
			return;
		}
		throw new NullReferenceException("Card_2_Played");
	}

	[SpecialName]
	public virtual float AIBJIMBGAAN()
	{
		if (LIEFNEPEIJO.HasColumn("L"))
		{
			return 250f / (float)LIEFNEPEIJO.GetValue(MGAGEKAAJOL.OBNOCCJIMPG(), "ID_GUI_YAISN_DESC");
		}
		return 1228f;
	}

	public virtual List<Tuple<string, float[]>> LEICHMNLNBD(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_VALUEPACKINFORMATIONS", "ID_TUTORIAL_WARCARDS_STARTUP", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_DOYOUWANTTOBUYWARBUCKS", "FOUND", base.weaponFeature.ammoCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Leaderboards - Squad Wars:\nTIER 1: 0-1\nTIER 2: 2-{0}\nTIER 3: {1}-{2}\nTIER 4: {3}-{4}\nTIER 5: {5}-{6}\nNO REWARD: {7}-{8}", "Master", base.weaponFeature.rateOfFireCoef));
		return list;
	}

	public virtual void EOHBFOAFLCK(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		JMMJHCOKCGG.FIMMGPLLLCL = 0;
		JMMJHCOKCGG.JMDLKIAKOIE = ANFDAHOPDLO(NDPMDKGJAFH, "Squad") * base.weaponFeature.reloadCoef;
		MissileSetup missileSetup = JMMJHCOKCGG.ammoSetup as MissileSetup;
		if (missileSetup != null)
		{
			missileSetup.INIBDNGHLPN = INIBDNGHLPN;
			missileSetup.LIEABAMBOMG = GLBHHCOMEEB;
			missileSetup.EPDELOGPNAC = ANFDAHOPDLO(NDPMDKGJAFH, "Silver");
			missileSetup.ABFGHBDEBAN = ANFDAHOPDLO(NDPMDKGJAFH, "'x'0") * base.weaponFeature.damageCoef;
			missileSetup.JPNAINOGAMM = base.shotVelocity;
			missileSetup.MAOPCAMOEEK = base.damageToPlayerBehindShieldRatio;
			return;
		}
		throw new NullReferenceException("Unit_Upgrade");
	}

	public virtual void EMEHIIDLIBE(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		JMMJHCOKCGG.FIMMGPLLLCL = 1;
		JMMJHCOKCGG.JMDLKIAKOIE = ANFDAHOPDLO(NDPMDKGJAFH, " Desc without HINT = ") * base.weaponFeature.reloadCoef;
		MissileSetup missileSetup = JMMJHCOKCGG.ammoSetup as MissileSetup;
		if (missileSetup != null)
		{
			missileSetup.INIBDNGHLPN = INIBDNGHLPN;
			missileSetup.LIEABAMBOMG = GLBHHCOMEEB;
			missileSetup.EPDELOGPNAC = ANFDAHOPDLO(NDPMDKGJAFH, "ID_SKILL");
			missileSetup.ABFGHBDEBAN = ANFDAHOPDLO(NDPMDKGJAFH, "Rank") * base.weaponFeature.damageCoef;
			missileSetup.JPNAINOGAMM = base.shotVelocity;
			missileSetup.MAOPCAMOEEK = base.damageToPlayerBehindShieldRatio;
			return;
		}
		throw new NullReferenceException("registerCustomProfileNumber");
	}

	public virtual void NPPLOACANIM(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		JMMJHCOKCGG.FIMMGPLLLCL = 1;
		JMMJHCOKCGG.JMDLKIAKOIE = ANFDAHOPDLO(NDPMDKGJAFH, "Bot cant choose proper rifle, either out of ammo or reloading") * base.weaponFeature.reloadCoef;
		MissileSetup missileSetup = JMMJHCOKCGG.ammoSetup as MissileSetup;
		if (missileSetup != null)
		{
			missileSetup.INIBDNGHLPN = INIBDNGHLPN;
			missileSetup.LIEABAMBOMG = GLBHHCOMEEB;
			missileSetup.EPDELOGPNAC = ANFDAHOPDLO(NDPMDKGJAFH, "ID_ARENABOXDESCRIPTION_TICKETS");
			missileSetup.ABFGHBDEBAN = ANFDAHOPDLO(NDPMDKGJAFH, "ID_SECONDWEAPONDAMAGE") * base.weaponFeature.damageCoef;
			missileSetup.JPNAINOGAMM = base.shotVelocity;
			missileSetup.MAOPCAMOEEK = base.damageToPlayerBehindShieldRatio;
			return;
		}
		throw new NullReferenceException("ID_RANDOMWARCARDS");
	}

	public virtual List<Tuple<string, float[]>> JBFDNJKHKEE(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "[]", "AdminPlayerId", base.weaponFeature.attackCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Manual_Unit_Spawn", "Player_Waited_Till_Delivery_Ends", base.weaponFeature.ammoCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "{0} {1}{2} {3}", "idle", base.weaponFeature.rateOfFireCoef, CLFOOLKGCEO: true));
		return list;
	}

	[SpecialName]
	public virtual float DHHBENFGFBM()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.BDNCLOPCDLO(), "GameReward")) * base.weaponFeature.damageCoef;
	}

	public virtual List<Tuple<string, float[]>> GGGJIFMDNNJ(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "#PETER# Animating league arc {0}    from:\"{1}\"  to:\"{2}\"", "Value", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "\t", "ID_ARENARULES_SLOWERRELOADING", base.weaponFeature.ammoCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "LevelManagerData", "Fuseboxx: iap offer accepted with object ", base.weaponFeature.rateOfFireCoef));
		return list;
	}

	[SpecialName]
	public virtual float GBHFMNKGAMG()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.OBNOCCJIMPG(), "ShotFrequencyMinCannon")) * base.weaponFeature.damageCoef;
	}

	[SpecialName]
	public virtual float DOIAILFCBMG()
	{
		if (LIEFNEPEIJO.HasColumn("addedVIP"))
		{
			return 1624f / (float)LIEFNEPEIJO.GetValue(MGAGEKAAJOL.PNKECEJELDP(), "videoAdRewardTimes");
		}
		return 1607f;
	}

	[SpecialName]
	public virtual float KLABODMBKBA()
	{
		if (LIEFNEPEIJO.HasColumn("ID_DEBUG_GUIERROR"))
		{
			return 1806f / (float)LIEFNEPEIJO.GetValue(MGAGEKAAJOL.BDNCLOPCDLO(), "Play_Card_Tutorial_Duration");
		}
		return 1632f;
	}

	public virtual List<Tuple<string, float[]>> PNLFFLHJOEG(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "clipSize", "damage", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "00", ", ", base.weaponFeature.ammoCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "\t\"TRUE\"", "DailyMissionsData", base.weaponFeature.rateOfFireCoef));
		return list;
	}

	public virtual List<Tuple<string, float[]>> JNLDADKCANP(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_SUBSCRIPTIODETAILS_HINT4", "PrintSetSizeForDynamicFont: \n", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "OnPhotonJoinRoomFailed: {0}, message {1}", "extraGold", base.weaponFeature.ammoCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "0.00", ", Value = ", base.weaponFeature.rateOfFireCoef));
		return list;
	}

	[SpecialName]
	public virtual float JEDBNFOCJFB()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.GCBOONOBIKH(), "Awaiting players - Adding player ")) * base.weaponFeature.damageCoef;
	}

	[SpecialName]
	public virtual float LAKLDLCDPAA()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.EJHKOFFOFOA(), "Missing reference to atlas.")) * base.weaponFeature.damageCoef;
	}

	[SpecialName]
	public virtual float CLNDAEHOIOE()
	{
		if (LIEFNEPEIJO.HasColumn("setCurrencyCode"))
		{
			return 1935f / (float)LIEFNEPEIJO.GetValue(MGAGEKAAJOL.OBNOCCJIMPG(), "ID_SECOND");
		}
		return 1701f;
	}

	public virtual List<Tuple<string, float[]>> BPDIHMEADHA(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "FakeDoNotClick{0:2}", "SquadName", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Awaiting players - Removing player ", "setAndroidId", base.weaponFeature.ammoCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "#Mission Rewards# 5 Heroic Missions completed. Gained {0} arena tickets", "ID_GUI_CHEATWARNING", base.weaponFeature.rateOfFireCoef, CLFOOLKGCEO: true));
		return list;
	}

	public virtual void OLOHBIBGAJE(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		JMMJHCOKCGG.FIMMGPLLLCL = 0;
		JMMJHCOKCGG.JMDLKIAKOIE = ANFDAHOPDLO(NDPMDKGJAFH, "Testing squad invite MC") * base.weaponFeature.reloadCoef;
		MissileSetup missileSetup = JMMJHCOKCGG.ammoSetup as MissileSetup;
		if (missileSetup != null)
		{
			missileSetup.INIBDNGHLPN = INIBDNGHLPN;
			missileSetup.LIEABAMBOMG = GLBHHCOMEEB;
			missileSetup.EPDELOGPNAC = ANFDAHOPDLO(NDPMDKGJAFH, "ID_TABLE_AP");
			missileSetup.ABFGHBDEBAN = ANFDAHOPDLO(NDPMDKGJAFH, "s") * base.weaponFeature.damageCoef;
			missileSetup.JPNAINOGAMM = base.shotVelocity;
			missileSetup.MAOPCAMOEEK = base.damageToPlayerBehindShieldRatio;
			return;
		}
		throw new NullReferenceException("MatchStart");
	}

	public virtual List<Tuple<string, float[]>> LKHFKOENHHP(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, " JSON failure.", "Level", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ChangeWeaponsRPC", "\t\"TRUE\"", base.weaponFeature.ammoCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_STAT_SQUADBEST", "#PETER# League Arc - stop ignore on ", base.weaponFeature.rateOfFireCoef, CLFOOLKGCEO: true));
		return list;
	}

	public override void SetWeaponparameters(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		JMMJHCOKCGG.FIMMGPLLLCL = 1;
		JMMJHCOKCGG.JMDLKIAKOIE = ANFDAHOPDLO(NDPMDKGJAFH, "reloadTime") * base.weaponFeature.reloadCoef;
		MissileSetup missileSetup = JMMJHCOKCGG.ammoSetup as MissileSetup;
		if (missileSetup != null)
		{
			missileSetup.INIBDNGHLPN = INIBDNGHLPN;
			missileSetup.LIEABAMBOMG = GLBHHCOMEEB;
			missileSetup.EPDELOGPNAC = ANFDAHOPDLO(NDPMDKGJAFH, "MinDamage");
			missileSetup.ABFGHBDEBAN = ANFDAHOPDLO(NDPMDKGJAFH, "ExplodeDamage") * base.weaponFeature.damageCoef;
			missileSetup.JPNAINOGAMM = base.shotVelocity;
			missileSetup.MAOPCAMOEEK = base.damageToPlayerBehindShieldRatio;
			return;
		}
		throw new NullReferenceException("weapon doesnt have ammo setup");
	}

	[SpecialName]
	public virtual float GPCOPECHEJK()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.MPKFMIPMCMP(), "id")) * base.weaponFeature.damageCoef;
	}

	public virtual List<Tuple<string, float[]>> ABDMANEKGHF(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "\n", "BS: On Skip Assignemnt", base.weaponFeature.attackCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "SquadId", "PlayerId", base.weaponFeature.ammoCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "extraWarBucks", "VipReward1", base.weaponFeature.rateOfFireCoef, CLFOOLKGCEO: true));
		return list;
	}

	public virtual List<Tuple<string, float[]>> ECAEJMLOLGD(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Joined room", " 2", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "PackLocation", "game-card-silver", base.weaponFeature.ammoCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_FEATURE_SHOTSPEED-FANCY", "LevelName", base.weaponFeature.rateOfFireCoef, CLFOOLKGCEO: true));
		return list;
	}

	[SpecialName]
	public virtual float IPIEKIGMOMC()
	{
		if (LIEFNEPEIJO.HasColumn("ID_READYTIME"))
		{
			return 1001f / (float)LIEFNEPEIJO.GetValue(MGAGEKAAJOL.EJHKOFFOFOA(), "#Mission Rewards# 3 Solo Daily Missions completed. Gained {0} arena tickets");
		}
		return 1659f;
	}

	public override List<Tuple<string, float[]>> GetGuiStats(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "attack", "ID_SLOTUPGRADE_DAMAGE", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ammo", "ID_SLOTUPGRADE_AMMO", base.weaponFeature.ammoCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "reloadTime", "ID_SLOTUPGRADE_ROF", base.weaponFeature.rateOfFireCoef));
		return list;
	}

	[SpecialName]
	public virtual float AFEJGMEIOFJ()
	{
		if (LIEFNEPEIJO.HasColumn("+0"))
		{
			return 1348f / (float)LIEFNEPEIJO.GetValue(MGAGEKAAJOL.EJHKOFFOFOA(), "game-card-ico-shieldsup");
		}
		return 1936f;
	}

	[SpecialName]
	public virtual float KPKMGIMLBDB()
	{
		if (LIEFNEPEIJO.HasColumn("SessionStartReceived()"))
		{
			return 1106f / (float)LIEFNEPEIJO.GetValue(MGAGEKAAJOL.MPKFMIPMCMP(), "ID_GUI_GAMEINVITATION");
		}
		return 1687f;
	}

	public virtual void HCBCECFPFBC(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		JMMJHCOKCGG.FIMMGPLLLCL = 0;
		JMMJHCOKCGG.JMDLKIAKOIE = ANFDAHOPDLO(NDPMDKGJAFH, "FinishGameMultiplayerRPC") * base.weaponFeature.reloadCoef;
		MissileSetup missileSetup = JMMJHCOKCGG.ammoSetup as MissileSetup;
		if (missileSetup != null)
		{
			missileSetup.INIBDNGHLPN = INIBDNGHLPN;
			missileSetup.LIEABAMBOMG = GLBHHCOMEEB;
			missileSetup.EPDELOGPNAC = ANFDAHOPDLO(NDPMDKGJAFH, "Shots_Hits");
			missileSetup.ABFGHBDEBAN = ANFDAHOPDLO(NDPMDKGJAFH, "Notification_MaintenanceInformation") * base.weaponFeature.damageCoef;
			missileSetup.JPNAINOGAMM = base.shotVelocity;
			missileSetup.MAOPCAMOEEK = base.damageToPlayerBehindShieldRatio;
			return;
		}
		throw new NullReferenceException("ID_CONFIRM_NOTFORQUESTACCOUNTS");
	}

	public virtual void NBCHMINEKFG(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		JMMJHCOKCGG.FIMMGPLLLCL = 1;
		JMMJHCOKCGG.JMDLKIAKOIE = ANFDAHOPDLO(NDPMDKGJAFH, "Yes_Clicked") * base.weaponFeature.reloadCoef;
		MissileSetup missileSetup = JMMJHCOKCGG.ammoSetup as MissileSetup;
		if (missileSetup != null)
		{
			missileSetup.INIBDNGHLPN = INIBDNGHLPN;
			missileSetup.LIEABAMBOMG = GLBHHCOMEEB;
			missileSetup.EPDELOGPNAC = ANFDAHOPDLO(NDPMDKGJAFH, "PlayerName");
			missileSetup.ABFGHBDEBAN = ANFDAHOPDLO(NDPMDKGJAFH, "ID_ERROR_SQUADNAMENOTUNIQUE") * base.weaponFeature.damageCoef;
			missileSetup.JPNAINOGAMM = base.shotVelocity;
			missileSetup.MAOPCAMOEEK = base.damageToPlayerBehindShieldRatio;
			return;
		}
		throw new NullReferenceException("month");
	}

	[SpecialName]
	public virtual float GNPIIAJHDGJ()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.PNKECEJELDP(), "FALSE")) * base.weaponFeature.damageCoef;
	}
}
