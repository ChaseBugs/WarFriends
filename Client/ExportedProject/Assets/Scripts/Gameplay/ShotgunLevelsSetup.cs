using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.Serialization;

public class ShotgunLevelsSetup : WeaponLevelsSetup
{
	[FormerlySerializedAs("PMHIDIOLPKF")]
	public float NKKHJFEDCPI = 3f;

	[FormerlySerializedAs("LKNJDKAFCEJ")]
	public float DODAJKFAJMO = 50f;

	[FormerlySerializedAs("BIJPGIPIEIA")]
	public float PPNDNOHMBKH = 10f;

	public override float shotDamage => Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.boughtIndex, "maxDamage")) * base.weaponFeature.damageCoef;

	public virtual void MNLCHGLNDIB(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		ShotGunBulletSetup shotGunBulletSetup = JMMJHCOKCGG.ammoSetup as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			shotGunBulletSetup.GJFCKILFOAE = ANFDAHOPDLO(NDPMDKGJAFH, "{0}S");
			shotGunBulletSetup.NNNCAFEGNNC = ANFDAHOPDLO(NDPMDKGJAFH, "FuseboxxConfigValue");
			shotGunBulletSetup.PPNDNOHMBKH = PPNDNOHMBKH;
			shotGunBulletSetup.NKKHJFEDCPI = NKKHJFEDCPI;
			shotGunBulletSetup.DODAJKFAJMO = DODAJKFAJMO;
			shotGunBulletSetup.GJEMHOBNEMD(base.shotVelocity);
			return;
		}
		throw new NullReferenceException("MM/dd/yyyy");
	}

	[SpecialName]
	public virtual float GNPIIAJHDGJ()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.AGKHAOLEHDE(), "Packs")) * base.weaponFeature.damageCoef;
	}

	[SpecialName]
	public virtual float MGHJIIDNGLG()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.OBNOCCJIMPG(), "ItemRarity_4")) * base.weaponFeature.damageCoef;
	}

	public virtual void KJEIPALMEGO(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		ShotGunBulletSetup shotGunBulletSetup = JMMJHCOKCGG.ammoSetup as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			shotGunBulletSetup.GJFCKILFOAE = ANFDAHOPDLO(NDPMDKGJAFH, "ID_ASSIGNMENTSSHORT");
			shotGunBulletSetup.NNNCAFEGNNC = ANFDAHOPDLO(NDPMDKGJAFH, " {0}\u00a0{1}");
			shotGunBulletSetup.PPNDNOHMBKH = PPNDNOHMBKH;
			shotGunBulletSetup.NKKHJFEDCPI = NKKHJFEDCPI;
			shotGunBulletSetup.DODAJKFAJMO = DODAJKFAJMO;
			shotGunBulletSetup.AFMIEAOANDL(base.shotVelocity);
			return;
		}
		throw new NullReferenceException("You probably assigned bad type of AmmoSetup to mine");
	}

	public override List<Tuple<string, float[]>> GetGuiStats(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "attack", "ID_SLOTUPGRADE_DAMAGE", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "clipSize", "ID_SLOTUPGRADE_CLIP_SIZE", base.weaponFeature.clipSizeCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "reloadTime", "ID_SLOTUPGRADE_ROF", base.weaponFeature.reloadCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ammo", "ID_SLOTUPGRADE_AMMO", base.weaponFeature.ammoCoef, CLFOOLKGCEO: true));
		return list;
	}

	public virtual List<Tuple<string, float[]>> LEICHMNLNBD(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "InstantBattleEnded: NUMBER OF BATTLES = ", "buyRentalDiscounted", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "{0} Rookie {1}", "ID_ERROR_SQUADNAMENOTUNIQUE", base.weaponFeature.clipSizeCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_READYTIME", "ID_STATE_FRIENDDOESNTWANTREMATCH", base.weaponFeature.reloadCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "N", "ID_CONFIRM_PLAYERALREADYEXISTS", base.weaponFeature.ammoCoef));
		return list;
	}

	[SpecialName]
	public virtual float BKMHMMPBLBL()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.LHLGAAEEKID(), "registerAge")) * base.weaponFeature.damageCoef;
	}

	public virtual List<Tuple<string, float[]>> OBKCNFKALGH(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Sniper_Tutorial_Played", "longValue", base.weaponFeature.attackCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "rental for unexist weapon: {0}", "LootBox_Purchase", base.weaponFeature.clipSizeCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "HeroicMissionsCompletionRewardTickets", "_Alpha", base.weaponFeature.reloadCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Input turned OFF completely: ", "ID_TUTORIAL_SNIPERSHOOT_UP", base.weaponFeature.ammoCoef));
		return list;
	}

	public virtual void HKNJPECAMPB(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		ShotGunBulletSetup shotGunBulletSetup = JMMJHCOKCGG.ammoSetup as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			shotGunBulletSetup.GJFCKILFOAE = ANFDAHOPDLO(NDPMDKGJAFH, "withPublisherSubAd");
			shotGunBulletSetup.NNNCAFEGNNC = ANFDAHOPDLO(NDPMDKGJAFH, "com.tune.unityutils.TuneUnityListener");
			shotGunBulletSetup.PPNDNOHMBKH = PPNDNOHMBKH;
			shotGunBulletSetup.NKKHJFEDCPI = NKKHJFEDCPI;
			shotGunBulletSetup.DODAJKFAJMO = DODAJKFAJMO;
			shotGunBulletSetup.CGFBEKMPGEM(base.shotVelocity);
			return;
		}
		throw new NullReferenceException("Null");
	}

	[SpecialName]
	public virtual float IDIPJPKDHJL()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.MPKFMIPMCMP(), "ID_TUTORIAL_NOACCOUNT_{0}_TITLE")) * base.weaponFeature.damageCoef;
	}

	public virtual void KCBDLCMCHIG(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		ShotGunBulletSetup shotGunBulletSetup = JMMJHCOKCGG.ammoSetup as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			shotGunBulletSetup.GJFCKILFOAE = ANFDAHOPDLO(NDPMDKGJAFH, "ID_TUTORIAL_OVERTIME");
			shotGunBulletSetup.NNNCAFEGNNC = ANFDAHOPDLO(NDPMDKGJAFH, "ID_BUYMONEYPACK");
			shotGunBulletSetup.PPNDNOHMBKH = PPNDNOHMBKH;
			shotGunBulletSetup.NKKHJFEDCPI = NKKHJFEDCPI;
			shotGunBulletSetup.DODAJKFAJMO = DODAJKFAJMO;
			shotGunBulletSetup.CBAJAPCNLHI(base.shotVelocity);
			return;
		}
		throw new NullReferenceException("gold");
	}

	public virtual void HOLEOPAJOJC(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		ShotGunBulletSetup shotGunBulletSetup = JMMJHCOKCGG.ammoSetup as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			shotGunBulletSetup.GJFCKILFOAE = ANFDAHOPDLO(NDPMDKGJAFH, "dogtag");
			shotGunBulletSetup.NNNCAFEGNNC = ANFDAHOPDLO(NDPMDKGJAFH, "Price");
			shotGunBulletSetup.PPNDNOHMBKH = PPNDNOHMBKH;
			shotGunBulletSetup.NKKHJFEDCPI = NKKHJFEDCPI;
			shotGunBulletSetup.DODAJKFAJMO = DODAJKFAJMO;
			shotGunBulletSetup.EBBNFOBHBKI(base.shotVelocity);
			return;
		}
		throw new NullReferenceException("equals");
	}

	[SpecialName]
	public virtual float KPCPAOEPIFP()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.OBNOCCJIMPG(), "MedalsOfferMult")) * base.weaponFeature.damageCoef;
	}

	public virtual void IKNPIMNKCDC(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		ShotGunBulletSetup shotGunBulletSetup = JMMJHCOKCGG.ammoSetup as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			shotGunBulletSetup.GJFCKILFOAE = ANFDAHOPDLO(NDPMDKGJAFH, "ID_ARENASHORTCUTEVENTSTART");
			shotGunBulletSetup.NNNCAFEGNNC = ANFDAHOPDLO(NDPMDKGJAFH, "\n");
			shotGunBulletSetup.PPNDNOHMBKH = PPNDNOHMBKH;
			shotGunBulletSetup.NKKHJFEDCPI = NKKHJFEDCPI;
			shotGunBulletSetup.DODAJKFAJMO = DODAJKFAJMO;
			shotGunBulletSetup.NIAFHAHPMBC(base.shotVelocity);
			return;
		}
		throw new NullReferenceException("Xp");
	}

	public virtual void EOKHEILDBDB(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		ShotGunBulletSetup shotGunBulletSetup = JMMJHCOKCGG.ammoSetup as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			shotGunBulletSetup.GJFCKILFOAE = ANFDAHOPDLO(NDPMDKGJAFH, "ID_DOGTAGSREFILL");
			shotGunBulletSetup.NNNCAFEGNNC = ANFDAHOPDLO(NDPMDKGJAFH, "ID_FEATURE_SHOTSPEED-FANCY");
			shotGunBulletSetup.PPNDNOHMBKH = PPNDNOHMBKH;
			shotGunBulletSetup.NKKHJFEDCPI = NKKHJFEDCPI;
			shotGunBulletSetup.DODAJKFAJMO = DODAJKFAJMO;
			shotGunBulletSetup.ODJMANKCKDM(base.shotVelocity);
			return;
		}
		throw new NullReferenceException("PlaySparks");
	}

	public virtual List<Tuple<string, float[]>> LEGEPDLIOLJ(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "{0}{1}/{2}{3}", "com/google/android/gms/games/stats/PlayerStats", base.weaponFeature.attackCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "AtlasPreparer.LoadMenuCoroutine", "shield_unhide", base.weaponFeature.clipSizeCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Show Loadout After Create Account", "Bad player visuals, data= ", base.weaponFeature.reloadCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "End Screen - button content - visual notification changed. End Screen active ", "VIPMembershipExpired", base.weaponFeature.ammoCoef, CLFOOLKGCEO: true));
		return list;
	}

	[SpecialName]
	public virtual float CEKFNNFGIPF()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.AGKHAOLEHDE(), "ArenaHeartDialog")) * base.weaponFeature.damageCoef;
	}

	public virtual List<Tuple<string, float[]>> EKBIICIJIBG(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Deposited Warcards: ", "Started delivering |", base.weaponFeature.attackCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_STARTSINX", "ID_WARNING_NOTENOUGHWARBUCKSFORELITE", base.weaponFeature.clipSizeCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "getStatusCode", "ID_GUI_EQUIPPED", base.weaponFeature.reloadCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ammo", "ID_STATE_WAITINGFOROPPONENT", base.weaponFeature.ammoCoef, CLFOOLKGCEO: true));
		return list;
	}

	public virtual void AHJHHDNGLGP(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		ShotGunBulletSetup shotGunBulletSetup = JMMJHCOKCGG.ammoSetup as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			shotGunBulletSetup.GJFCKILFOAE = ANFDAHOPDLO(NDPMDKGJAFH, "menu-arena-ticket");
			shotGunBulletSetup.NNNCAFEGNNC = ANFDAHOPDLO(NDPMDKGJAFH, "Category number {0} is not present in CamosManager.instance.data.slots");
			shotGunBulletSetup.PPNDNOHMBKH = PPNDNOHMBKH;
			shotGunBulletSetup.NKKHJFEDCPI = NKKHJFEDCPI;
			shotGunBulletSetup.DODAJKFAJMO = DODAJKFAJMO;
			shotGunBulletSetup.NIAFHAHPMBC(base.shotVelocity);
			return;
		}
		throw new NullReferenceException("setListener");
	}

	public virtual void KAHOGOAPKCJ(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		ShotGunBulletSetup shotGunBulletSetup = JMMJHCOKCGG.ammoSetup as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			shotGunBulletSetup.GJFCKILFOAE = ANFDAHOPDLO(NDPMDKGJAFH, "ID_GUI_EQUIP");
			shotGunBulletSetup.NNNCAFEGNNC = ANFDAHOPDLO(NDPMDKGJAFH, "Squad Members not in client cache!");
			shotGunBulletSetup.PPNDNOHMBKH = PPNDNOHMBKH;
			shotGunBulletSetup.NKKHJFEDCPI = NKKHJFEDCPI;
			shotGunBulletSetup.DODAJKFAJMO = DODAJKFAJMO;
			shotGunBulletSetup.ODJMANKCKDM(base.shotVelocity);
			return;
		}
		throw new NullReferenceException("Rules");
	}

	public virtual List<Tuple<string, float[]>> GFJDKGGCDFK(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "213 MENU ARMY SCREEN SHOWN", "HP", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_NOTIFICATION_DAILYREWARD_TICKET", "Effect: ", base.weaponFeature.clipSizeCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_RANDOMMAP", "1\u00a0{0}", base.weaponFeature.reloadCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "BeanstalkServerManager: AfterPlayerDataLoaded", "ID_BONUS-EVENT_POINTS", base.weaponFeature.ammoCoef, CLFOOLKGCEO: true));
		return list;
	}

	public virtual List<Tuple<string, float[]>> FJAFBAPOPEE(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_ARENARULES_NOOVERTIME", "FacebookId", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Rank", "stand_up_crawl", base.weaponFeature.clipSizeCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_READYTIME", "d: ", base.weaponFeature.reloadCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Buy_Weapon_At_Rank_Gold", "Achievement '{0}' progress '{1}' successfully reported.", base.weaponFeature.ammoCoef));
		return list;
	}

	public virtual void NKGGONOBBEH(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		ShotGunBulletSetup shotGunBulletSetup = JMMJHCOKCGG.ammoSetup as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			shotGunBulletSetup.GJFCKILFOAE = ANFDAHOPDLO(NDPMDKGJAFH, "level");
			shotGunBulletSetup.NNNCAFEGNNC = ANFDAHOPDLO(NDPMDKGJAFH, "Animation from State: Craft to State: Ready");
			shotGunBulletSetup.PPNDNOHMBKH = PPNDNOHMBKH;
			shotGunBulletSetup.NKKHJFEDCPI = NKKHJFEDCPI;
			shotGunBulletSetup.DODAJKFAJMO = DODAJKFAJMO;
			shotGunBulletSetup.GLBFCAFEFDF(base.shotVelocity);
			return;
		}
		throw new NullReferenceException("Level");
	}

	public virtual List<Tuple<string, float[]>> JNLDADKCANP(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_SALEPERCENTLINE", "GetRewardedInfoForZoneID", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Configurations hacked", "Configurations error, there is {0} configurations of type {1}", base.weaponFeature.clipSizeCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_EARLYUNLOCK2", "shotgunner_run", base.weaponFeature.reloadCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_REPORTUSER_ITEM1", "shield_idle", base.weaponFeature.ammoCoef));
		return list;
	}

	public virtual List<Tuple<string, float[]>> NOKOBINOBCI(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "\t\"FALSE\"", "HeroicPoints", base.weaponFeature.attackCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_ELITEPACKDESCRIPTION", "game-neardeath-indicator", base.weaponFeature.clipSizeCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_BUYSTARTERPACK", "ArenaLootBox", base.weaponFeature.reloadCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Show {0} invitation dialog id: {1}", "+{0}", base.weaponFeature.ammoCoef));
		return list;
	}

	public virtual List<Tuple<string, float[]>> AICDAPKDMHM(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_ERROR_SQUADMESSAGE_PROFANITY", "ID_POISONDAMAGE", base.weaponFeature.attackCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_WARNING_PROMOTEERROR", "v", base.weaponFeature.clipSizeCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, ". Loading default...", "74379913-3b64-482e-bda1-8a8d90c0f3f9", base.weaponFeature.reloadCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_", "smallURL", base.weaponFeature.ammoCoef));
		return list;
	}

	[SpecialName]
	public virtual float FFHLPGHCEMK()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.KMHMJEDDNOP(), "04")) * base.weaponFeature.damageCoef;
	}

	[SpecialName]
	public virtual float FCNDBNMPAGE()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.EJHKOFFOFOA(), "Gold")) * base.weaponFeature.damageCoef;
	}

	[SpecialName]
	public virtual float OJHDGNNDDMD()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.OBNOCCJIMPG(), "LevelExperience")) * base.weaponFeature.damageCoef;
	}

	[SpecialName]
	public virtual float KJPBBEFCMPH()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.HEKMIFHFEKN(), "ID_CONFIRM_RESUME")) * base.weaponFeature.damageCoef;
	}

	public virtual List<Tuple<string, float[]>> NLJCIAJMAOA(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_FEATURE_MAGAZINE-WEAPONPREFIX", "discount", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Show reconnect dialog", "CardId", base.weaponFeature.clipSizeCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "VipReward1", "com/google/android/gms/games/Games", base.weaponFeature.reloadCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "purchase", "Twitter_Like", base.weaponFeature.ammoCoef));
		return list;
	}

	public virtual List<Tuple<string, float[]>> EELEAGABDAI(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "KLHPEJKKNPD", "ID_GETSP", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "offerMult", "ID_ARENARULES_NOWARCARDS", base.weaponFeature.clipSizeCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_VISUALRARITY5", "goldcardpack", base.weaponFeature.reloadCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "FuseSDK", "Directory \"{0}\" does not exists", base.weaponFeature.ammoCoef));
		return list;
	}

	[SpecialName]
	public virtual float JBJOJBMDHCK()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.GCBOONOBIKH(), "WFX_MF Spr")) * base.weaponFeature.damageCoef;
	}

	public virtual void JGLOGLABAGG(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		ShotGunBulletSetup shotGunBulletSetup = JMMJHCOKCGG.ammoSetup as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			shotGunBulletSetup.GJFCKILFOAE = ANFDAHOPDLO(NDPMDKGJAFH, "Requests");
			shotGunBulletSetup.NNNCAFEGNNC = ANFDAHOPDLO(NDPMDKGJAFH, "ID_YOUNEEDMONEYTODELIVER");
			shotGunBulletSetup.PPNDNOHMBKH = PPNDNOHMBKH;
			shotGunBulletSetup.NKKHJFEDCPI = NKKHJFEDCPI;
			shotGunBulletSetup.DODAJKFAJMO = DODAJKFAJMO;
			shotGunBulletSetup.NIAFHAHPMBC(base.shotVelocity);
			return;
		}
		throw new NullReferenceException("Unranked");
	}

	public virtual void IDJGNLLACGC(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		ShotGunBulletSetup shotGunBulletSetup = JMMJHCOKCGG.ammoSetup as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			shotGunBulletSetup.GJFCKILFOAE = ANFDAHOPDLO(NDPMDKGJAFH, "ID_CONFIRM_OFFERTOOSHORTDURATION");
			shotGunBulletSetup.NNNCAFEGNNC = ANFDAHOPDLO(NDPMDKGJAFH, "Amazon Mobile Analytics Operations");
			shotGunBulletSetup.PPNDNOHMBKH = PPNDNOHMBKH;
			shotGunBulletSetup.NKKHJFEDCPI = NKKHJFEDCPI;
			shotGunBulletSetup.DODAJKFAJMO = DODAJKFAJMO;
			shotGunBulletSetup.EDPGCDLFCLB(base.shotVelocity);
			return;
		}
		throw new NullReferenceException(", databaseType= ");
	}

	public virtual void OJKHIDOKPPA(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		ShotGunBulletSetup shotGunBulletSetup = JMMJHCOKCGG.ammoSetup as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			shotGunBulletSetup.GJFCKILFOAE = ANFDAHOPDLO(NDPMDKGJAFH, "Action ");
			shotGunBulletSetup.NNNCAFEGNNC = ANFDAHOPDLO(NDPMDKGJAFH, "ID_CONFIRM_NOSQUADACTIONS_TEXT");
			shotGunBulletSetup.PPNDNOHMBKH = PPNDNOHMBKH;
			shotGunBulletSetup.NKKHJFEDCPI = NKKHJFEDCPI;
			shotGunBulletSetup.DODAJKFAJMO = DODAJKFAJMO;
			shotGunBulletSetup.ECMFHOBPHCF(base.shotVelocity);
			return;
		}
		throw new NullReferenceException("BattleId");
	}

	public virtual void EKIOKFIEPDL(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		ShotGunBulletSetup shotGunBulletSetup = JMMJHCOKCGG.ammoSetup as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			shotGunBulletSetup.GJFCKILFOAE = ANFDAHOPDLO(NDPMDKGJAFH, "OtherPlayer");
			shotGunBulletSetup.NNNCAFEGNNC = ANFDAHOPDLO(NDPMDKGJAFH, " bonusIcon:");
			shotGunBulletSetup.PPNDNOHMBKH = PPNDNOHMBKH;
			shotGunBulletSetup.NKKHJFEDCPI = NKKHJFEDCPI;
			shotGunBulletSetup.DODAJKFAJMO = DODAJKFAJMO;
			shotGunBulletSetup.EBBNFOBHBKI(base.shotVelocity);
			return;
		}
		throw new NullReferenceException("ID_BATTLEWINBONUSRISESTO");
	}

	public virtual List<Tuple<string, float[]>> EIAEOKINDPJ(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_TIERX", "Card_2_Played", base.weaponFeature.attackCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "()Lcom/google/android/gms/games/stats/PlayerStats;", "Changed country to {0} from {1}.", base.weaponFeature.clipSizeCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Packs", "ShowRope", base.weaponFeature.reloadCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "HeroicMissionsCompletionRewardScraps", "!!!!", base.weaponFeature.ammoCoef, CLFOOLKGCEO: true));
		return list;
	}

	public virtual List<Tuple<string, float[]>> EIIPDLCPJCB(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "shield_run", "ShotFrequencyMax", base.weaponFeature.attackCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "UnitTutorial", "-ABILITY", base.weaponFeature.clipSizeCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Found Pack Id", "Rushers", base.weaponFeature.reloadCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "BattleId", "WaveCoolDown", base.weaponFeature.ammoCoef));
		return list;
	}

	[SpecialName]
	public virtual float EGJJPEJAELO()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.LHLGAAEEKID(), "playerInfo")) * base.weaponFeature.damageCoef;
	}

	public virtual void OKNBCKFEJGI(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		ShotGunBulletSetup shotGunBulletSetup = JMMJHCOKCGG.ammoSetup as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			shotGunBulletSetup.GJFCKILFOAE = ANFDAHOPDLO(NDPMDKGJAFH, "DOWNLOAD");
			shotGunBulletSetup.NNNCAFEGNNC = ANFDAHOPDLO(NDPMDKGJAFH, "ID_CONGRATULATIONSMOVEDTO");
			shotGunBulletSetup.PPNDNOHMBKH = PPNDNOHMBKH;
			shotGunBulletSetup.NKKHJFEDCPI = NKKHJFEDCPI;
			shotGunBulletSetup.DODAJKFAJMO = DODAJKFAJMO;
			shotGunBulletSetup.FPHDJENJANK(base.shotVelocity);
			return;
		}
		throw new NullReferenceException("extraScraps");
	}

	public virtual void HMAHHOCGEHE(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		ShotGunBulletSetup shotGunBulletSetup = JMMJHCOKCGG.ammoSetup as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			shotGunBulletSetup.GJFCKILFOAE = ANFDAHOPDLO(NDPMDKGJAFH, "ID_YOUHAVENOBRONZEWARCARDSAVAILABLE");
			shotGunBulletSetup.NNNCAFEGNNC = ANFDAHOPDLO(NDPMDKGJAFH, "SyncWarperRPC");
			shotGunBulletSetup.PPNDNOHMBKH = PPNDNOHMBKH;
			shotGunBulletSetup.NKKHJFEDCPI = NKKHJFEDCPI;
			shotGunBulletSetup.DODAJKFAJMO = DODAJKFAJMO;
			shotGunBulletSetup.GJEMHOBNEMD(base.shotVelocity);
			return;
		}
		throw new NullReferenceException("ID_SQUADMEMBERSLOWER");
	}

	[SpecialName]
	public virtual float EGMMJCBMHJH()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.MPKFMIPMCMP(), "/")) * base.weaponFeature.damageCoef;
	}

	public virtual void BDKALGOIBLD(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		ShotGunBulletSetup shotGunBulletSetup = JMMJHCOKCGG.ammoSetup as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			shotGunBulletSetup.GJFCKILFOAE = ANFDAHOPDLO(NDPMDKGJAFH, "bazooka_shoot_right");
			shotGunBulletSetup.NNNCAFEGNNC = ANFDAHOPDLO(NDPMDKGJAFH, "#PETER# League Arc ");
			shotGunBulletSetup.PPNDNOHMBKH = PPNDNOHMBKH;
			shotGunBulletSetup.NKKHJFEDCPI = NKKHJFEDCPI;
			shotGunBulletSetup.DODAJKFAJMO = DODAJKFAJMO;
			shotGunBulletSetup.FPFCEEIEFDM(base.shotVelocity);
			return;
		}
		throw new NullReferenceException("ID_NOTIFICATION_DAILYREWARD_CARDPACK");
	}

	[SpecialName]
	public virtual float EJFGCFDMBJD()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.OFEJOLENCKI(), "{0}:{1}\t\t{2}")) * base.weaponFeature.damageCoef;
	}

	public virtual void GKACMDBMLHG(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		ShotGunBulletSetup shotGunBulletSetup = JMMJHCOKCGG.ammoSetup as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			shotGunBulletSetup.GJFCKILFOAE = ANFDAHOPDLO(NDPMDKGJAFH, "I");
			shotGunBulletSetup.NNNCAFEGNNC = ANFDAHOPDLO(NDPMDKGJAFH, "InAppHandlerIos: product list fail, message = ");
			shotGunBulletSetup.PPNDNOHMBKH = PPNDNOHMBKH;
			shotGunBulletSetup.NKKHJFEDCPI = NKKHJFEDCPI;
			shotGunBulletSetup.DODAJKFAJMO = DODAJKFAJMO;
			shotGunBulletSetup.bulletSpeed = base.shotVelocity;
			return;
		}
		throw new NullReferenceException("GOT REWARDS!!");
	}

	[SpecialName]
	public virtual float LEEHJLGNNHO()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.PNKECEJELDP(), "[Singleton] An instance of ")) * base.weaponFeature.damageCoef;
	}

	public virtual List<Tuple<string, float[]>> JPNLNDEIBCM(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "{0} -> {1}", "NO", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "\t\"TRUE\"", "ID_FREEPERCENTLINE", base.weaponFeature.clipSizeCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "doesnt exist", "RETRY", base.weaponFeature.reloadCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "-", "shootAdditive", base.weaponFeature.ammoCoef, CLFOOLKGCEO: true));
		return list;
	}

	public virtual List<Tuple<string, float[]>> FDJGKJMELLE(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_CONFIRM_NOSQUADACTIONS_TITLE", "CONFIRM", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "SquadIcons/", "ID_GUI_ACCEPT_PLAYER_CANTJOIN", base.weaponFeature.clipSizeCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "#VOJTA# LOADED DAILY MISSIONS AFTER LEVEL UP", "ObjectPool", base.weaponFeature.reloadCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "PlayerUnitPower", "__", base.weaponFeature.ammoCoef, CLFOOLKGCEO: true));
		return list;
	}

	public virtual List<Tuple<string, float[]>> PKKGGPLAHFA(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "HeroicMissionsCompletionRewardScraps", "ID_DEBUG_STACKTRACEINCONSOLE", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "kr", "Out|In|Sum:\t{0,4} | {1,4} | {2,4}", base.weaponFeature.clipSizeCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "country-sweden", "#PETER# User was watching add - waiting for server reward - reward came", base.weaponFeature.reloadCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, " leveled up to ", "Gold", base.weaponFeature.ammoCoef, CLFOOLKGCEO: true));
		return list;
	}

	[SpecialName]
	public virtual float ANCOBKDLFFB()
	{
		return Convert.ToSingle(LIEFNEPEIJO.GetValue(MGAGEKAAJOL.OFEJOLENCKI(), "Mega_Reward")) * base.weaponFeature.damageCoef;
	}

	public override void SetWeaponparameters(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		ShotGunBulletSetup shotGunBulletSetup = JMMJHCOKCGG.ammoSetup as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			shotGunBulletSetup.GJFCKILFOAE = ANFDAHOPDLO(NDPMDKGJAFH, "maxDamage");
			shotGunBulletSetup.NNNCAFEGNNC = ANFDAHOPDLO(NDPMDKGJAFH, "minDamage");
			shotGunBulletSetup.PPNDNOHMBKH = PPNDNOHMBKH;
			shotGunBulletSetup.NKKHJFEDCPI = NKKHJFEDCPI;
			shotGunBulletSetup.DODAJKFAJMO = DODAJKFAJMO;
			shotGunBulletSetup.bulletSpeed = base.shotVelocity;
			return;
		}
		throw new NullReferenceException("weapon doesnt have ammo setup");
	}

	public virtual List<Tuple<string, float[]>> CFPIJLPBPIJ(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "playerVisuals", "Yes_Clicked", base.weaponFeature.attackCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "minigun_shot", "offers", base.weaponFeature.clipSizeCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Application focus changed to {0} and have created AWS mobile analytics {1}", "Weapon_ID", base.weaponFeature.reloadCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "width", "Shots_Fired", base.weaponFeature.ammoCoef, CLFOOLKGCEO: true));
		return list;
	}

	public virtual List<Tuple<string, float[]>> MJCMHPKKKBI(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_FRIENDPAUSED", "end", base.weaponFeature.attackCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "vibrator", "ID_NOW", base.weaponFeature.clipSizeCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "elite", "ID_VISUALCOMPLETED", base.weaponFeature.reloadCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "NULL WARCARD", " (#", base.weaponFeature.ammoCoef, CLFOOLKGCEO: true));
		return list;
	}

	public virtual void HALBFOCGMAE(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		ShotGunBulletSetup shotGunBulletSetup = JMMJHCOKCGG.ammoSetup as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			shotGunBulletSetup.GJFCKILFOAE = ANFDAHOPDLO(NDPMDKGJAFH, "Medals - old:{0} new:{1} Balance old:{2} Balance new:{3} Remaining fights:{4}\n");
			shotGunBulletSetup.NNNCAFEGNNC = ANFDAHOPDLO(NDPMDKGJAFH, "otherInfo");
			shotGunBulletSetup.PPNDNOHMBKH = PPNDNOHMBKH;
			shotGunBulletSetup.NKKHJFEDCPI = NKKHJFEDCPI;
			shotGunBulletSetup.DODAJKFAJMO = DODAJKFAJMO;
			shotGunBulletSetup.EBBNFOBHBKI(base.shotVelocity);
			return;
		}
		throw new NullReferenceException("OnDisconnectedFromPhoton");
	}

	public virtual void DIKJILLPDFK(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		ShotGunBulletSetup shotGunBulletSetup = JMMJHCOKCGG.ammoSetup as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			shotGunBulletSetup.GJFCKILFOAE = ANFDAHOPDLO(NDPMDKGJAFH, "GameType");
			shotGunBulletSetup.NNNCAFEGNNC = ANFDAHOPDLO(NDPMDKGJAFH, "x");
			shotGunBulletSetup.PPNDNOHMBKH = PPNDNOHMBKH;
			shotGunBulletSetup.NKKHJFEDCPI = NKKHJFEDCPI;
			shotGunBulletSetup.DODAJKFAJMO = DODAJKFAJMO;
			shotGunBulletSetup.GJEMHOBNEMD(base.shotVelocity);
			return;
		}
		throw new NullReferenceException("BAND_TYPE_RELOAD");
	}

	public virtual List<Tuple<string, float[]>> NJFKIKMLIJO(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_UNIT2UPGRADEABILITY_UNIT1BUY", "ID_OVERTIME", base.weaponFeature.attackCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "subscription", "menu-cards-bronzepack", base.weaponFeature.clipSizeCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_STAT_MOSTWARCARDSPLAYED", "D2", base.weaponFeature.reloadCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "\t\t", "id", base.weaponFeature.ammoCoef, CLFOOLKGCEO: true));
		return list;
	}

	public virtual List<Tuple<string, float[]>> GBMIBIPKPOO(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "ID_STAT_MOSTWINS", "banana", base.weaponFeature.attackCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "*****   Bootcamp 3/3 Ended   *****", "BS: Update Army Power", base.weaponFeature.clipSizeCoef));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, "Lcom/google/android/gms/games/snapshot/Snapshots;", "Player connectionState {0} to player {1}", base.weaponFeature.reloadCoef, CLFOOLKGCEO: true));
		list.Add(MMPLMBONDIJ(ACHJJKCIBCN, " ", "ID_ARENARARITY", base.weaponFeature.ammoCoef));
		return list;
	}

	public virtual void LPHNLGEGOOD(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		ShotGunBulletSetup shotGunBulletSetup = JMMJHCOKCGG.ammoSetup as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			shotGunBulletSetup.GJFCKILFOAE = ANFDAHOPDLO(NDPMDKGJAFH, "description");
			shotGunBulletSetup.NNNCAFEGNNC = ANFDAHOPDLO(NDPMDKGJAFH, "HeroicMissionsCompletionRewardGold");
			shotGunBulletSetup.PPNDNOHMBKH = PPNDNOHMBKH;
			shotGunBulletSetup.NKKHJFEDCPI = NKKHJFEDCPI;
			shotGunBulletSetup.DODAJKFAJMO = DODAJKFAJMO;
			shotGunBulletSetup.CGFBEKMPGEM(base.shotVelocity);
			return;
		}
		throw new NullReferenceException("PACK");
	}

	public virtual void HHCCDGNPEAF(Weapon JMMJHCOKCGG, byte? NDPMDKGJAFH)
	{
		base.SetWeaponparameters(JMMJHCOKCGG, NDPMDKGJAFH);
		ShotGunBulletSetup shotGunBulletSetup = JMMJHCOKCGG.ammoSetup as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			shotGunBulletSetup.GJFCKILFOAE = ANFDAHOPDLO(NDPMDKGJAFH, "Mission data saved");
			shotGunBulletSetup.NNNCAFEGNNC = ANFDAHOPDLO(NDPMDKGJAFH, "Your Best");
			shotGunBulletSetup.PPNDNOHMBKH = PPNDNOHMBKH;
			shotGunBulletSetup.NKKHJFEDCPI = NKKHJFEDCPI;
			shotGunBulletSetup.DODAJKFAJMO = DODAJKFAJMO;
			shotGunBulletSetup.IHCNBONBOAO(base.shotVelocity);
			return;
		}
		throw new NullReferenceException("RETRY");
	}
}
