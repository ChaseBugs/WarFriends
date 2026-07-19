using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class HHFHFANGCEJ
{
	public enum NKHJBLBAAEB
	{
		ChallengeIgnored = 15,
		VipCards = 50,
		DailyReward = 51,
		EnablePushNotificationMessage = 52,
		RateAppMessage = 52,
		RewardMessage = 53,
		DailyRental = 54,
		BannedFromChat = 17,
		UnitReadyForPromotion = 18,
		WelcomBackSoldierMessage = 19,
		Challenge = 0,
		CheatWarning = 12,
		LeagueEntered = 7,
		SquadDemotion = 3,
		SquadEventEntered = 18,
		SquadEventTierReward = 11,
		SquadEventEnded = 19,
		SquadInvitation = 1,
		SquadJoined = 14,
		SquadJoinRequest = 13,
		SquadLevelUp = 10,
		SquadPromotion = 4,
		SquadWarEnd = 9,
		NonExistingSquadWarsEnd = 16,
		BeAdvisedConnectFacebook = 70,
		BeAdvisedJoinOrCreateSquad = 71,
		BeAdvisedPurchaseVIP = 72,
		SystemMessage = 20,
		VIPMemeberShipAlmostEnded = 73,
		VIPMembershipExpired = 74,
		UpgradeWeaponReminder = 75,
		UpgradeUnitReminder = 76,
		PowerBandBuyAfterLose = 77,
		BuyCardsReminder = 78,
		LikeUsOnFacebook = 79,
		TweetAboutWarfriends = 80,
		FollowUsOnTwitter = 81,
		InformSquadLeaderAboutEvent = 21,
		HitlistLogedIn = 33,
		BlackMarketMessage = 29,
		SquadLeft = 34,
		NameChangeReminder = 35,
		TimeLimitedOffer = 36,
		NewSquadJoinRequest = 22,
		PlayerLeagueFinished = 23,
		WeaponTutorialDialogMessage = 24,
		SquadMemberGameEnded = 25,
		SquadDepositedCardsChanged = 26,
		SpecialOfferMessage = 90,
		UnitCategoriesReminder = 91,
		InGameMessage = 27,
		DepositWarcards = 28,
		StarterPackTimeLimitedOffer = 29,
		ChatTutorialMessage = 30,
		CardpoolTutorialMessage = 31,
		CustomizationTutorialMessage = 32,
		StarterAssignmentsReward = 33,
		DailyAssignmentsReminder = 34,
		DailyGoldBooster = 35,
		ArenaUnlockedMessage = 36,
		BuyHearthMessage = 37,
		ArenaLostMessage = 38,
		ArenaVisualMessage = 39,
		ArenaShieldsMessage = 40,
		ArenaOpenedMessage = 41,
		ArenaWonMessage = 42,
		InstantBattleUnlockedMessage = 43,
		ArenaGoldenShieldMessage = 44,
		ElitePerkTutorialMessage = 45,
		DailyMissionUnlockMessage = 46,
		JoinNowSquadMessage = 47,
		EventAssignmentCompletedMessage = 48
	}

	public string NHHGDIDEIMM;

	public NKHJBLBAAEB HPGHHECHLAN;

	public int KJCKFGCLGLG;

	public string EJBEDLHIKDG;

	private bool PKDOJNABLDE;

	private bool LBLGJDOMOFJ;

	public bool MJGAKEOAKNA;

	private bool EABMMNBCABK;

	public bool PFCJDAHIIIC
	{
		get
		{
			return LBLGJDOMOFJ;
		}
		set
		{
			if (value && !LBLGJDOMOFJ && PKDOJNABLDE)
			{
				Singleton<MessageManager>.instance.SentDatabaseMessageWasShown(NHHGDIDEIMM, EJBEDLHIKDG);
			}
			LBLGJDOMOFJ = value;
		}
	}

	public virtual bool OMMPKNEEJIB
	{
		get
		{
			return false;
		}
	}

	public virtual bool LOJJMCMKECE
	{
		get
		{
			return true;
		}
	}

	public virtual bool JLCLGAKDIMG
	{
		get
		{
			return false;
		}
	}

	public virtual bool OBMJDKBCOAE
	{
		get
		{
			return true;
		}
	}

	public void OJFJOJONNJK()
	{
		Singleton<MessageManager>.instance.SentDatabaseMessageIgnore(NHHGDIDEIMM);
		MJGAKEOAKNA = true;
	}

	[SpecialName]
	public virtual bool IJELOOFLPCK()
	{
		return false;
	}

	public virtual void DJCBGMALLHE()
	{
	}

	internal virtual Action HDCCFKAHHOP(MessageCenterRecord HDEGOGFCNAC)
	{
		throw new NotImplementedException();
	}

	public static HHFHFANGCEJ MAINIENLLIL(JToken OGNGMBLDAOP, NKHJBLBAAEB HPGHHECHLAN)
	{
		switch (HPGHHECHLAN)
		{
		case NKHJBLBAAEB.NonExistingSquadWarsEnd:
		{
			Debug.LogError("DatabaseMessage - No long existing database message came from server!");
			HHFHFANGCEJ hHFHFANGCEJ = new HHFHFANGCEJ(OGNGMBLDAOP);
			hHFHFANGCEJ.OJFJOJONNJK();
			return hHFHFANGCEJ;
		}
		case NKHJBLBAAEB.Challenge:
			return new ICFCHEHNHEN(OGNGMBLDAOP);
		case NKHJBLBAAEB.SquadInvitation:
			return new HLHBMMCBHJF(OGNGMBLDAOP);
		case NKHJBLBAAEB.SquadDemotion:
			return new MBACFNICJPL(OGNGMBLDAOP);
		case NKHJBLBAAEB.SquadJoinRequest:
			return new GNOIPPHBAKA(OGNGMBLDAOP);
		case NKHJBLBAAEB.SquadPromotion:
			return new HEOOEHGBLEN(OGNGMBLDAOP);
		case NKHJBLBAAEB.LeagueEntered:
			return new IMKNKBHECOD(OGNGMBLDAOP);
		case NKHJBLBAAEB.SquadWarEnd:
			return new LDDEMALIBBK(OGNGMBLDAOP);
		case NKHJBLBAAEB.SquadLevelUp:
			return new KGALJDLJCEH(OGNGMBLDAOP);
		case NKHJBLBAAEB.UnitReadyForPromotion:
			return new EDCMLKFFIIH(OGNGMBLDAOP);
		case NKHJBLBAAEB.SquadEventTierReward:
			return new OKLNJJBHAIH(OGNGMBLDAOP);
		case NKHJBLBAAEB.WelcomBackSoldierMessage:
			return new KEGHCEANIDJ(OGNGMBLDAOP);
		case NKHJBLBAAEB.CheatWarning:
			return new KPJANALDHHP(OGNGMBLDAOP);
		case NKHJBLBAAEB.SquadJoined:
			return new PDIHEPGNPCA(OGNGMBLDAOP);
		case NKHJBLBAAEB.ChallengeIgnored:
			return new JCIMACEGNNK(OGNGMBLDAOP);
		case NKHJBLBAAEB.SystemMessage:
			return new NPMPDDDPPCA(OGNGMBLDAOP);
		case NKHJBLBAAEB.BannedFromChat:
			return new LDEBCOFIANK(OGNGMBLDAOP);
		case NKHJBLBAAEB.InformSquadLeaderAboutEvent:
			return new IIPKANOGHOA(OGNGMBLDAOP);
		case NKHJBLBAAEB.SquadLeft:
			return new JEJHNAPPOFN(OGNGMBLDAOP);
		case NKHJBLBAAEB.NewSquadJoinRequest:
			return new LENKEHOHBLB(OGNGMBLDAOP);
		case NKHJBLBAAEB.PlayerLeagueFinished:
			return new MMKFEEGDFKN(OGNGMBLDAOP);
		case NKHJBLBAAEB.SquadMemberGameEnded:
			return new IGAAGFOBKMO(OGNGMBLDAOP);
		case NKHJBLBAAEB.SquadDepositedCardsChanged:
			return new NMNJDAANAOD(OGNGMBLDAOP);
		case NKHJBLBAAEB.InGameMessage:
			return new JAGLDFKMHHI(OGNGMBLDAOP);
		case NKHJBLBAAEB.DepositWarcards:
			return new BOAFLMMKCGB(OGNGMBLDAOP);
		case NKHJBLBAAEB.BlackMarketMessage:
			return new IBPMPPJBBFG(OGNGMBLDAOP);
		default:
			return new HHFHFANGCEJ(OGNGMBLDAOP);
		}
	}

	internal static HHFHFANGCEJ JGBPFKCPLLF(JToken OGNGMBLDAOP, string NHHGDIDEIMM)
	{
		try
		{
			NKHJBLBAAEB hPGHHECHLAN = (NKHJBLBAAEB)Convert.ToInt32(Regex.Replace(NHHGDIDEIMM, "Description!!!!!!! Motherfuckers :-)", string.Empty));
			string text = "./warfriends" + NHHGDIDEIMM + "ID_CONFIRM_ERROR";
			Debug.Log("consumePurchaseSucceededEvent: " + text);
			JToken content = JToken.Parse(text);
			JProperty content2 = new JProperty("forceSetUserInSegmentId", content);
			if (OGNGMBLDAOP.First != null)
			{
				Debug.LogError("SquadMates");
				OGNGMBLDAOP.Last.AddAfterSelf(content2);
			}
			else
			{
				Debug.LogError(" 1\u00a0{0}");
				OGNGMBLDAOP = new JObject(content2);
			}
			Debug.Log("ID_RENTAL_ASSAULTRIFLE");
			HHFHFANGCEJ hHFHFANGCEJ = HGNOEFFCJNP(OGNGMBLDAOP, hPGHHECHLAN);
			Debug.Log("TransactionId123");
			hHFHFANGCEJ.EJBEDLHIKDG = GameLoginManager.instance.playerId;
			hHFHFANGCEJ.HPGHHECHLAN = hPGHHECHLAN;
			hHFHFANGCEJ.KJCKFGCLGLG = Convert.ToInt32(Regex.Replace(NHHGDIDEIMM, "https://fb.me/1157647734253183", string.Empty));
			Debug.Log("AFTER CreateFromDatabase" + hHFHFANGCEJ.NHHGDIDEIMM);
			return hHFHFANGCEJ;
		}
		catch (Exception ex)
		{
			Debug.Log(ex.StackTrace);
			Debug.LogError("AccountType" + ex.Message);
			return null;
		}
	}

	internal static HHFHFANGCEJ POOLFDCGBKI(JToken OGNGMBLDAOP)
	{
		try
		{
			NKHJBLBAAEB hPGHHECHLAN = (NKHJBLBAAEB)OGNGMBLDAOP["ID_VETERAN"]["ID_ERROR_SQUADNAME_PROFANITY"].ToObject<int>();
			return MAINIENLLIL(OGNGMBLDAOP, hPGHHECHLAN);
		}
		catch (Exception ex)
		{
			Debug.Log(ex.StackTrace);
			Debug.LogError("Visual" + ex.Message);
			if (OGNGMBLDAOP["WarbuckRewardLoss"] == null)
			{
				string nHHGDIDEIMM = OGNGMBLDAOP["Direct"]["Battles_Played"].ToObject<string>();
				Singleton<MessageManager>.instance.JLAPHOBNFBO(nHHGDIDEIMM);
			}
			else
			{
				Debug.LogError("URL" + OGNGMBLDAOP.ToString());
			}
			return null;
		}
	}

	public bool ILAEGPAJALF()
	{
		return EABMMNBCABK;
	}

	internal static HHFHFANGCEJ OALBDJKEPNF(JToken OGNGMBLDAOP)
	{
		try
		{
			NKHJBLBAAEB hPGHHECHLAN = (NKHJBLBAAEB)OGNGMBLDAOP["\t\"TRUE\""]["MY"].ToObject<int>();
			return HGNOEFFCJNP(OGNGMBLDAOP, hPGHHECHLAN);
		}
		catch (Exception ex)
		{
			Debug.Log(ex.StackTrace);
			Debug.LogError("ID_PLAYERCANTJOINSQUAD" + ex.Message);
			if (OGNGMBLDAOP["ID_SALEPERCENTLINE"] != null)
			{
				string nHHGDIDEIMM = OGNGMBLDAOP["[Singleton] An instance of "]["Time-limited Offers"].ToObject<string>();
				Singleton<MessageManager>.instance.ODEAFFPKDKN(nHHGDIDEIMM);
			}
			else
			{
				Debug.LogError("Total_Gold_Spent" + OGNGMBLDAOP.ToString());
			}
			return null;
		}
	}

	internal static HHFHFANGCEJ PDDMJGJDFOI(JToken OGNGMBLDAOP, string NHHGDIDEIMM)
	{
		try
		{
			NKHJBLBAAEB hPGHHECHLAN = (NKHJBLBAAEB)Convert.ToInt32(Regex.Replace(NHHGDIDEIMM, "ID_CATEGORY_ASSAULTRIFLE", string.Empty));
			string text = "Lootbox" + NHHGDIDEIMM + "Cards_Owned_Gold";
			Debug.Log("D3" + text);
			JToken content = JToken.Parse(text);
			JProperty content2 = new JProperty("Play_Card_Tutorial", content);
			if (OGNGMBLDAOP.First != null)
			{
				Debug.LogError("WarBucks");
				OGNGMBLDAOP.Last.AddAfterSelf(content2);
			}
			else
			{
				Debug.LogError("MX");
				OGNGMBLDAOP = new JObject(content2);
			}
			Debug.Log("Play_Card_Tutorial");
			HHFHFANGCEJ hHFHFANGCEJ = ICGLBEOPPLP(OGNGMBLDAOP, hPGHHECHLAN);
			Debug.Log("Google2u.DBUpgradeSlotsAssaulter");
			hHFHFANGCEJ.EJBEDLHIKDG = GameLoginManager.instance.playerId;
			hHFHFANGCEJ.HPGHHECHLAN = hPGHHECHLAN;
			hHFHFANGCEJ.KJCKFGCLGLG = Convert.ToInt32(Regex.Replace(NHHGDIDEIMM, "WarBucksBoxes", string.Empty));
			Debug.Log("Sprite  z:{0}\t\"{1}\"    with depth:{2} and atlas:{3}" + hHFHFANGCEJ.NHHGDIDEIMM);
			return hHFHFANGCEJ;
		}
		catch (Exception ex)
		{
			Debug.Log(ex.StackTrace);
			Debug.LogError("ID_HEYDEPOSITSOMEWARCARDS" + ex.Message);
			return null;
		}
	}

	public virtual void DMCPPGEEHOK(DatabasePlayerInfo KHLGDCHJJPB)
	{
		throw new NotImplementedException();
	}

	internal static HHFHFANGCEJ MAINIENLLIL(JToken OGNGMBLDAOP)
	{
		try
		{
			NKHJBLBAAEB hPGHHECHLAN = (NKHJBLBAAEB)OGNGMBLDAOP["MessageType"]["N"].ToObject<int>();
			return MAINIENLLIL(OGNGMBLDAOP, hPGHHECHLAN);
		}
		catch (Exception ex)
		{
			Debug.Log(ex.StackTrace);
			Debug.LogError("Database Message: Error parsing message!! Auto Ignore! " + ex.Message);
			if (OGNGMBLDAOP["MessageId"] != null)
			{
				string nHHGDIDEIMM = OGNGMBLDAOP["MessageId"]["S"].ToObject<string>();
				Singleton<MessageManager>.instance.SentDatabaseMessageIgnore(nHHGDIDEIMM);
			}
			else
			{
				Debug.LogError("Database Message does not contain id or type:\n" + OGNGMBLDAOP.ToString());
			}
			return null;
		}
	}

	public virtual void CGOOGHIJOAH()
	{
		throw new NotImplementedException();
	}

	internal static HHFHFANGCEJ CKKMIAGLJAP(JToken OGNGMBLDAOP, string NHHGDIDEIMM)
	{
		try
		{
			NKHJBLBAAEB hPGHHECHLAN = (NKHJBLBAAEB)Convert.ToInt32(Regex.Replace(NHHGDIDEIMM, "NextDailyRewardLocalnotification", string.Empty));
			string text = "ID_GUI_EMBLEMUNLOCKED" + NHHGDIDEIMM + "WEAPON IS NULL";
			Debug.Log("DamageEventPlayer damage: {0} to {1} new HP {2}" + text);
			JToken content = JToken.Parse(text);
			JProperty content2 = new JProperty("CLIENT REMINDERS:\nTutorial upgrade weapon running \"{0}\"\n", content);
			if (OGNGMBLDAOP.First != null)
			{
				Debug.LogError("AtlasPreparer.LoadGameCoroutine");
				OGNGMBLDAOP.Last.AddAfterSelf(content2);
			}
			else
			{
				Debug.LogError("BEGINNERS {0}   {1}.   {2}");
				OGNGMBLDAOP = new JObject(content2);
			}
			Debug.Log("getGameConfigurationKeys");
			HHFHFANGCEJ hHFHFANGCEJ = HGNOEFFCJNP(OGNGMBLDAOP, hPGHHECHLAN);
			Debug.Log("null");
			hHFHFANGCEJ.EJBEDLHIKDG = GameLoginManager.instance.playerId;
			hHFHFANGCEJ.HPGHHECHLAN = hPGHHECHLAN;
			hHFHFANGCEJ.KJCKFGCLGLG = Convert.ToInt32(Regex.Replace(NHHGDIDEIMM, "Reward Was Already Added!!", string.Empty));
			Debug.Log("ID_MEMBERS" + hHFHFANGCEJ.NHHGDIDEIMM);
			return hHFHFANGCEJ;
		}
		catch (Exception ex)
		{
			Debug.Log(ex.StackTrace);
			Debug.LogError("com/google/android/gms/common/ConnectionResult" + ex.Message);
			return null;
		}
	}

	public virtual void LEJEDFACEGP()
	{
		EABMMNBCABK = false;
	}

	public HHFHFANGCEJ(JToken OGNGMBLDAOP)
	{
		if (OGNGMBLDAOP.First != null)
		{
			if (OGNGMBLDAOP["MessageId"] != null)
			{
				NHHGDIDEIMM = OGNGMBLDAOP["MessageId"]["S"].ToObject<string>();
				KJCKFGCLGLG = Convert.ToInt32(Regex.Replace(NHHGDIDEIMM, "^.*-", string.Empty));
			}
			if (OGNGMBLDAOP["PlayerId"] != null)
			{
				EJBEDLHIKDG = OGNGMBLDAOP["PlayerId"]["S"].ToObject<string>();
			}
			if (OGNGMBLDAOP["MessageType"] != null)
			{
				HPGHHECHLAN = (NKHJBLBAAEB)OGNGMBLDAOP["MessageType"]["N"].ToObject<int>();
			}
			if (OGNGMBLDAOP["WasShown"] != null)
			{
				LBLGJDOMOFJ = true;
			}
			PKDOJNABLDE = true;
		}
	}

	internal static HHFHFANGCEJ ONADBGMFLOB(JToken OGNGMBLDAOP)
	{
		try
		{
			NKHJBLBAAEB hPGHHECHLAN = (NKHJBLBAAEB)OGNGMBLDAOP["/"]["ID_SAVEPERCENTLINE"].ToObject<int>();
			return MAINIENLLIL(OGNGMBLDAOP, hPGHHECHLAN);
		}
		catch (Exception ex)
		{
			Debug.Log(ex.StackTrace);
			Debug.LogError("SetupPushNotifications(" + ex.Message);
			if (OGNGMBLDAOP["ID_TUTORIAL_UPGRADEUNIT_4"] != null)
			{
				string nHHGDIDEIMM = OGNGMBLDAOP["UK"]["VipRewardForDay"].ToObject<string>();
				Singleton<MessageManager>.instance.SentDatabaseMessageIgnore(nHHGDIDEIMM);
			}
			else
			{
				Debug.LogError("Start DMO" + OGNGMBLDAOP.ToString());
			}
			return null;
		}
	}

	public virtual void JEDCCICKHEH()
	{
	}

	public virtual void LPAMOEECKBB()
	{
	}

	public virtual bool KGPPDBFOGOK()
	{
		return DialogManager.instance.isSomeDialogShowed;
	}

	[SpecialName]
	public virtual bool AKMBPCCFAAO()
	{
		return false;
	}

	public virtual bool HFDGKLFCBLE()
	{
		return !DialogManager.instance.isSomeDialogShowed;
	}

	public virtual void JPGMEFJGNNA()
	{
		EABMMNBCABK = false;
	}

	public virtual void GEKIMGFKNHC()
	{
		EABMMNBCABK = true;
	}

	public virtual bool LMMGABHMGLK()
	{
		return !DialogManager.instance.isSomeDialogShowed;
	}

	public bool PAHBCCFBADA()
	{
		return EABMMNBCABK;
	}

	internal virtual Action ENNLMIGMBKJ(MessageCenterRecord HDEGOGFCNAC)
	{
		throw new NotImplementedException();
	}

	public virtual void IFLECEBGJMC(DatabasePlayerInfo KHLGDCHJJPB)
	{
		throw new NotImplementedException();
	}

	public virtual void OBJEMJHBJFO()
	{
		EABMMNBCABK = false;
	}

	public virtual void MGKMBCBBOHK()
	{
		EABMMNBCABK = true;
	}

	[SpecialName]
	public bool KKENHDCOLKB()
	{
		return LBLGJDOMOFJ;
	}

	public virtual void EBBHCLMKKKK(DatabasePlayerInfo KHLGDCHJJPB)
	{
		throw new NotImplementedException();
	}

	[SpecialName]
	public virtual bool DPDALPPEEMH()
	{
		return true;
	}

	public virtual void BACFCDODPCN(DatabasePlayerInfo KHLGDCHJJPB)
	{
		throw new NotImplementedException();
	}

	[SpecialName]
	public virtual bool MDIDMLHIFPH()
	{
		return false;
	}

	public void IFFBCOLBDOP()
	{
		Singleton<MessageManager>.instance.SentDatabaseMessageIgnore(NHHGDIDEIMM);
		MJGAKEOAKNA = false;
	}

	[SpecialName]
	public bool HJJHBEABPJB()
	{
		return LBLGJDOMOFJ;
	}

	[SpecialName]
	public virtual bool IDMCDKILAJG()
	{
		return true;
	}

	public virtual bool COGGIIALJOP()
	{
		return !DialogManager.instance.isSomeDialogShowed;
	}

	[SpecialName]
	public virtual bool MAOHFICPBMI()
	{
		return false;
	}

	[SpecialName]
	public virtual bool CEFHHOFLHCG()
	{
		return false;
	}

	public virtual void GDOIFOIGDPF(DatabasePlayerInfo KHLGDCHJJPB)
	{
		throw new NotImplementedException();
	}

	[SpecialName]
	public virtual bool KILOAOCGEGC()
	{
		return false;
	}

	public virtual void PCCOCDNINLG()
	{
	}

	public virtual void DNBLNABNHNM(DatabasePlayerInfo KHLGDCHJJPB)
	{
		throw new NotImplementedException();
	}

	[SpecialName]
	public virtual bool OPKHDPLAPIM()
	{
		return false;
	}

	[SpecialName]
	public virtual bool FMAJPIGBCGC()
	{
		return true;
	}

	public virtual void AKICNBAOGOL()
	{
		throw new NotImplementedException();
	}

	public virtual void IMDBPLNFIKD()
	{
	}

	[SpecialName]
	public bool JCLPLMEMGKA()
	{
		return LBLGJDOMOFJ;
	}

	[SpecialName]
	public virtual bool EHNDCPMCONF()
	{
		return true;
	}

	public virtual void LOFMDBHAFAO()
	{
		EABMMNBCABK = true;
	}

	[SpecialName]
	public virtual bool GAJELAEPPHI()
	{
		return false;
	}

	[SpecialName]
	public virtual bool KJJKDDDEIJD()
	{
		return false;
	}

	public bool KCALOENKINP()
	{
		return EABMMNBCABK;
	}

	public virtual void KPANLOMNEIG()
	{
		EABMMNBCABK = true;
	}

	public void JFDENNGOGJC()
	{
		Singleton<MessageManager>.instance.ODEAFFPKDKN(NHHGDIDEIMM);
		MJGAKEOAKNA = false;
	}

	public bool EADMIHGNFCK()
	{
		return EABMMNBCABK;
	}

	public virtual void IDIIHLPJLGF(DatabasePlayerInfo KHLGDCHJJPB)
	{
		throw new NotImplementedException();
	}

	public bool LGPJJGBDNIO()
	{
		return EABMMNBCABK;
	}

	internal static HHFHFANGCEJ GFEGFBLEJKK(JToken OGNGMBLDAOP)
	{
		try
		{
			NKHJBLBAAEB hPGHHECHLAN = (NKHJBLBAAEB)OGNGMBLDAOP["GoldCoefficient"]["pooled:"].ToObject<int>();
			return ICGLBEOPPLP(OGNGMBLDAOP, hPGHHECHLAN);
		}
		catch (Exception ex)
		{
			Debug.Log(ex.StackTrace);
			Debug.LogError("C1" + ex.Message);
			if (OGNGMBLDAOP["ID_VISUALCATEGORY2"] != null)
			{
				string nHHGDIDEIMM = OGNGMBLDAOP["Squad Member record does not have DatabasePlayer"]["ID_TUTORIAL_OBJECTIVE"].ToObject<string>();
				Singleton<MessageManager>.instance.JLAPHOBNFBO(nHHGDIDEIMM);
			}
			else
			{
				Debug.LogError("ID_DEMOTETODIVISION" + OGNGMBLDAOP.ToString());
			}
			return null;
		}
	}

	[SpecialName]
	public void MFDNOBJDPDH(bool IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM && !LBLGJDOMOFJ && PKDOJNABLDE)
		{
			Singleton<MessageManager>.instance.HDCBACKLIOI(NHHGDIDEIMM, EJBEDLHIKDG);
		}
		LBLGJDOMOFJ = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual bool MBCOJJEKANP()
	{
		return false;
	}

	[SpecialName]
	public virtual bool AGIOGHDBEFM()
	{
		return true;
	}

	[SpecialName]
	public virtual bool LNKIFBFEKHN()
	{
		return false;
	}

	[SpecialName]
	public virtual bool LODHBNHBOPO()
	{
		return false;
	}

	[SpecialName]
	public virtual bool BDDHPAHHDHM()
	{
		return false;
	}

	internal static HHFHFANGCEJ HKDJOAOBDIN(JToken OGNGMBLDAOP)
	{
		try
		{
			NKHJBLBAAEB hPGHHECHLAN = (NKHJBLBAAEB)OGNGMBLDAOP["country-noflag"]["#DANIEL# Price: {0}\nFormatted price: {1}"].ToObject<int>();
			return MAINIENLLIL(OGNGMBLDAOP, hPGHHECHLAN);
		}
		catch (Exception ex)
		{
			Debug.Log(ex.StackTrace);
			Debug.LogError("ID_WINTEREVENT" + ex.Message);
			if (OGNGMBLDAOP["grenadeExplosion"] == null)
			{
				string nHHGDIDEIMM = OGNGMBLDAOP["menu-assignments-type-mission"]["MissionType"].ToObject<string>();
				Singleton<MessageManager>.instance.SentDatabaseMessageIgnore(nHHGDIDEIMM);
			}
			else
			{
				Debug.LogError("Weapon model not found! weaponprefab = '{0}' assetBundleName = '{1}'" + OGNGMBLDAOP.ToString());
			}
			return null;
		}
	}

	[SpecialName]
	public bool NNFMFPLGDCE()
	{
		return LBLGJDOMOFJ;
	}

	internal static HHFHFANGCEJ NBCDBIJKKNG(JToken OGNGMBLDAOP)
	{
		try
		{
			NKHJBLBAAEB hPGHHECHLAN = (NKHJBLBAAEB)OGNGMBLDAOP["{0} {1}"]["ID_ERROR_SQUADNAMESHORT"].ToObject<int>();
			return MAINIENLLIL(OGNGMBLDAOP, hPGHHECHLAN);
		}
		catch (Exception ex)
		{
			Debug.Log(ex.StackTrace);
			Debug.LogError("Enemy could not be spawned" + ex.Message);
			if (OGNGMBLDAOP["CONTENTS_FILE_DESCRIPTOR"] == null)
			{
				string nHHGDIDEIMM = OGNGMBLDAOP["Mouse X"]["country-bulgaria"].ToObject<string>();
				Singleton<MessageManager>.instance.ODEAFFPKDKN(nHHGDIDEIMM);
			}
			else
			{
				Debug.LogError("gold" + OGNGMBLDAOP.ToString());
			}
			return null;
		}
	}

	public static HHFHFANGCEJ HGNOEFFCJNP(JToken OGNGMBLDAOP, NKHJBLBAAEB HPGHHECHLAN)
	{
		switch (HPGHHECHLAN)
		{
		case (NKHJBLBAAEB)(-35):
		{
			Debug.LogError("WarFriends necesita permiso para acceder a tu almacenamiento de medios para descargar datos del juego esenciales.Sin este permiso, el juego no puede funcionar y se cerrará. Reinicia o sal de WarFriends.");
			HHFHFANGCEJ hHFHFANGCEJ = new HHFHFANGCEJ(OGNGMBLDAOP);
			hHFHFANGCEJ.IFFBCOLBDOP();
			return hHFHFANGCEJ;
		}
		case NKHJBLBAAEB.Challenge:
			return new ICFCHEHNHEN(OGNGMBLDAOP);
		case NKHJBLBAAEB.SquadInvitation:
			return new HLHBMMCBHJF(OGNGMBLDAOP);
		case NKHJBLBAAEB.SquadDemotion:
			return new MBACFNICJPL(OGNGMBLDAOP);
		case NKHJBLBAAEB.SquadJoinRequest:
			return new GNOIPPHBAKA(OGNGMBLDAOP);
		case NKHJBLBAAEB.SquadPromotion:
			return new HEOOEHGBLEN(OGNGMBLDAOP);
		case NKHJBLBAAEB.LeagueEntered:
			return new IMKNKBHECOD(OGNGMBLDAOP);
		case NKHJBLBAAEB.SquadWarEnd:
			return new LDDEMALIBBK(OGNGMBLDAOP);
		case NKHJBLBAAEB.SquadLevelUp:
			return new KGALJDLJCEH(OGNGMBLDAOP);
		case NKHJBLBAAEB.UnitReadyForPromotion:
			return new EDCMLKFFIIH(OGNGMBLDAOP);
		case NKHJBLBAAEB.SquadEventTierReward:
			return new OKLNJJBHAIH(OGNGMBLDAOP);
		case NKHJBLBAAEB.WelcomBackSoldierMessage:
			return new KEGHCEANIDJ(OGNGMBLDAOP);
		case NKHJBLBAAEB.CheatWarning:
			return new KPJANALDHHP(OGNGMBLDAOP);
		case NKHJBLBAAEB.SquadJoined:
			return new PDIHEPGNPCA(OGNGMBLDAOP);
		case NKHJBLBAAEB.ChallengeIgnored:
			return new JCIMACEGNNK(OGNGMBLDAOP);
		case NKHJBLBAAEB.SystemMessage:
			return new NPMPDDDPPCA(OGNGMBLDAOP);
		case NKHJBLBAAEB.BannedFromChat:
			return new LDEBCOFIANK(OGNGMBLDAOP);
		case NKHJBLBAAEB.InformSquadLeaderAboutEvent:
			return new IIPKANOGHOA(OGNGMBLDAOP);
		case NKHJBLBAAEB.SquadLeft:
			return new JEJHNAPPOFN(OGNGMBLDAOP);
		case NKHJBLBAAEB.NewSquadJoinRequest:
			return new LENKEHOHBLB(OGNGMBLDAOP);
		case NKHJBLBAAEB.PlayerLeagueFinished:
			return new MMKFEEGDFKN(OGNGMBLDAOP);
		case NKHJBLBAAEB.SquadMemberGameEnded:
			return new IGAAGFOBKMO(OGNGMBLDAOP);
		case NKHJBLBAAEB.SquadDepositedCardsChanged:
			return new NMNJDAANAOD(OGNGMBLDAOP);
		case NKHJBLBAAEB.InGameMessage:
			return new JAGLDFKMHHI(OGNGMBLDAOP);
		case NKHJBLBAAEB.DepositWarcards:
			return new BOAFLMMKCGB(OGNGMBLDAOP);
		case NKHJBLBAAEB.BlackMarketMessage:
			return new IBPMPPJBBFG(OGNGMBLDAOP);
		default:
			return new HHFHFANGCEJ(OGNGMBLDAOP);
		}
	}

	[SpecialName]
	public void ACCCCDEAFPP(bool IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM && !LBLGJDOMOFJ && PKDOJNABLDE)
		{
			Singleton<MessageManager>.instance.SentDatabaseMessageWasShown(NHHGDIDEIMM, EJBEDLHIKDG);
		}
		LBLGJDOMOFJ = IDEBKDPMPGM;
	}

	public void CALACCCGMGD()
	{
		Singleton<MessageManager>.instance.SentDatabaseMessageIgnore(NHHGDIDEIMM);
		MJGAKEOAKNA = true;
	}

	public virtual void OIDDCBBFBHJ()
	{
		throw new NotImplementedException();
	}

	public virtual bool NIJOCMMLCGG()
	{
		return !DialogManager.instance.isSomeDialogShowed;
	}

	internal virtual Action OPOALBECPDE(MessageCenterRecord HDEGOGFCNAC)
	{
		throw new NotImplementedException();
	}

	public virtual void JPEEONOIHLI(DatabasePlayerInfo KHLGDCHJJPB)
	{
		throw new NotImplementedException();
	}

	[SpecialName]
	public bool COBJHFOGCEG()
	{
		return LBLGJDOMOFJ;
	}

	[SpecialName]
	public virtual bool IJENJFFJECP()
	{
		return false;
	}

	[SpecialName]
	public virtual bool IAEOGOBPIAM()
	{
		return true;
	}

	public bool ADLOCFNJEPB()
	{
		return EABMMNBCABK;
	}

	[SpecialName]
	public virtual bool KGLIPNKPGJC()
	{
		return false;
	}

	public HHFHFANGCEJ(string INFLHPGMEOB, NKHJBLBAAEB HCHFBLIJCFD)
	{
		NHHGDIDEIMM = INFLHPGMEOB + DateTime.Now.Day;
		EJBEDLHIKDG = GameLoginManager.currentPlayer.id;
		HPGHHECHLAN = HCHFBLIJCFD;
		KJCKFGCLGLG = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
	}

	public virtual void OLECKGKLHCE()
	{
		EABMMNBCABK = true;
	}

	public static HHFHFANGCEJ ICGLBEOPPLP(JToken OGNGMBLDAOP, NKHJBLBAAEB HPGHHECHLAN)
	{
		switch (HPGHHECHLAN)
		{
		case (NKHJBLBAAEB)97:
		{
			Debug.LogError("ID_SKILLSHOTHINT_HEADSHOT");
			HHFHFANGCEJ hHFHFANGCEJ = new HHFHFANGCEJ(OGNGMBLDAOP);
			hHFHFANGCEJ.IFFBCOLBDOP();
			return hHFHFANGCEJ;
		}
		case NKHJBLBAAEB.Challenge:
			return new ICFCHEHNHEN(OGNGMBLDAOP);
		case NKHJBLBAAEB.SquadInvitation:
			return new HLHBMMCBHJF(OGNGMBLDAOP);
		case NKHJBLBAAEB.SquadDemotion:
			return new MBACFNICJPL(OGNGMBLDAOP);
		case NKHJBLBAAEB.SquadJoinRequest:
			return new GNOIPPHBAKA(OGNGMBLDAOP);
		case NKHJBLBAAEB.SquadPromotion:
			return new HEOOEHGBLEN(OGNGMBLDAOP);
		case NKHJBLBAAEB.LeagueEntered:
			return new IMKNKBHECOD(OGNGMBLDAOP);
		case NKHJBLBAAEB.SquadWarEnd:
			return new LDDEMALIBBK(OGNGMBLDAOP);
		case NKHJBLBAAEB.SquadLevelUp:
			return new KGALJDLJCEH(OGNGMBLDAOP);
		case NKHJBLBAAEB.UnitReadyForPromotion:
			return new EDCMLKFFIIH(OGNGMBLDAOP);
		case NKHJBLBAAEB.SquadEventTierReward:
			return new OKLNJJBHAIH(OGNGMBLDAOP);
		case NKHJBLBAAEB.WelcomBackSoldierMessage:
			return new KEGHCEANIDJ(OGNGMBLDAOP);
		case NKHJBLBAAEB.CheatWarning:
			return new KPJANALDHHP(OGNGMBLDAOP);
		case NKHJBLBAAEB.SquadJoined:
			return new PDIHEPGNPCA(OGNGMBLDAOP);
		case NKHJBLBAAEB.ChallengeIgnored:
			return new JCIMACEGNNK(OGNGMBLDAOP);
		case NKHJBLBAAEB.SystemMessage:
			return new NPMPDDDPPCA(OGNGMBLDAOP);
		case NKHJBLBAAEB.BannedFromChat:
			return new LDEBCOFIANK(OGNGMBLDAOP);
		case NKHJBLBAAEB.InformSquadLeaderAboutEvent:
			return new IIPKANOGHOA(OGNGMBLDAOP);
		case NKHJBLBAAEB.SquadLeft:
			return new JEJHNAPPOFN(OGNGMBLDAOP);
		case NKHJBLBAAEB.NewSquadJoinRequest:
			return new LENKEHOHBLB(OGNGMBLDAOP);
		case NKHJBLBAAEB.PlayerLeagueFinished:
			return new MMKFEEGDFKN(OGNGMBLDAOP);
		case NKHJBLBAAEB.SquadMemberGameEnded:
			return new IGAAGFOBKMO(OGNGMBLDAOP);
		case NKHJBLBAAEB.SquadDepositedCardsChanged:
			return new NMNJDAANAOD(OGNGMBLDAOP);
		case NKHJBLBAAEB.InGameMessage:
			return new JAGLDFKMHHI(OGNGMBLDAOP);
		case NKHJBLBAAEB.DepositWarcards:
			return new BOAFLMMKCGB(OGNGMBLDAOP);
		case NKHJBLBAAEB.BlackMarketMessage:
			return new IBPMPPJBBFG(OGNGMBLDAOP);
		default:
			return new HHFHFANGCEJ(OGNGMBLDAOP);
		}
	}

	internal static HHFHFANGCEJ COEBAPFLNPE(JToken OGNGMBLDAOP, string NHHGDIDEIMM)
	{
		try
		{
			NKHJBLBAAEB hPGHHECHLAN = (NKHJBLBAAEB)Convert.ToInt32(Regex.Replace(NHHGDIDEIMM, "Assignment: Error, task definition not found for id = ", string.Empty));
			string text = "ID_CATEGORY_LOW_PL_EXPLOSIVE" + NHHGDIDEIMM + "shotReal";
			Debug.Log("\\" + text);
			JToken content = JToken.Parse(text);
			JProperty content2 = new JProperty("SETTING HalfResNoMs", content);
			if (OGNGMBLDAOP.First != null)
			{
				Debug.LogError("Fuseb oxx manager: TEsting stufff");
				OGNGMBLDAOP.Last.AddAfterSelf(content2);
			}
			else
			{
				Debug.LogError("withContentId");
				OGNGMBLDAOP = new JObject(content2);
			}
			Debug.Log("toString");
			HHFHFANGCEJ hHFHFANGCEJ = MAINIENLLIL(OGNGMBLDAOP, hPGHHECHLAN);
			Debug.Log("stand_up_crawl");
			hHFHFANGCEJ.EJBEDLHIKDG = GameLoginManager.instance.playerId;
			hHFHFANGCEJ.HPGHHECHLAN = hPGHHECHLAN;
			hHFHFANGCEJ.KJCKFGCLGLG = Convert.ToInt32(Regex.Replace(NHHGDIDEIMM, "Can not find asset {0}", string.Empty));
			Debug.Log("clearDefaultAccountAndReconnect" + hHFHFANGCEJ.NHHGDIDEIMM);
			return hHFHFANGCEJ;
		}
		catch (Exception ex)
		{
			Debug.Log(ex.StackTrace);
			Debug.LogError("OnDeathRPC" + ex.Message);
			return null;
		}
	}

	internal static HHFHFANGCEJ MAINIENLLIL(JToken OGNGMBLDAOP, string NHHGDIDEIMM)
	{
		try
		{
			NKHJBLBAAEB hPGHHECHLAN = (NKHJBLBAAEB)Convert.ToInt32(Regex.Replace(NHHGDIDEIMM, "-.*$", string.Empty));
			string text = "{ \"S\": \"" + NHHGDIDEIMM + "\"}";
			Debug.Log("JSON = " + text);
			JToken content = JToken.Parse(text);
			JProperty content2 = new JProperty("MessageId", content);
			if (OGNGMBLDAOP.First != null)
			{
				Debug.LogError("Adding MessageId after first");
				OGNGMBLDAOP.Last.AddAfterSelf(content2);
			}
			else
			{
				Debug.LogError("Adding MessageId instead of empty Jtoken");
				OGNGMBLDAOP = new JObject(content2);
			}
			Debug.Log("Before CreateFromDatabase");
			HHFHFANGCEJ hHFHFANGCEJ = MAINIENLLIL(OGNGMBLDAOP, hPGHHECHLAN);
			Debug.Log("AFTER CreateFromDatabase");
			hHFHFANGCEJ.EJBEDLHIKDG = GameLoginManager.instance.playerId;
			hHFHFANGCEJ.HPGHHECHLAN = hPGHHECHLAN;
			hHFHFANGCEJ.KJCKFGCLGLG = Convert.ToInt32(Regex.Replace(NHHGDIDEIMM, "^.*-", string.Empty));
			Debug.Log("Message Id = " + hHFHFANGCEJ.NHHGDIDEIMM);
			return hHFHFANGCEJ;
		}
		catch (Exception ex)
		{
			Debug.Log(ex.StackTrace);
			Debug.LogError("Database Message: Error parsing message!! Auto Ignore! " + ex.Message);
			return null;
		}
	}

	public virtual void CJPBMDDGDHG()
	{
		throw new NotImplementedException();
	}

	[SpecialName]
	public void HDMCKAMIMGM(bool IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM && !LBLGJDOMOFJ && PKDOJNABLDE)
		{
			Singleton<MessageManager>.instance.HDCBACKLIOI(NHHGDIDEIMM, EJBEDLHIKDG);
		}
		LBLGJDOMOFJ = IDEBKDPMPGM;
	}

	internal static HHFHFANGCEJ OGIGGJNFIDE(JToken OGNGMBLDAOP, string NHHGDIDEIMM)
	{
		try
		{
			NKHJBLBAAEB hPGHHECHLAN = (NKHJBLBAAEB)Convert.ToInt32(Regex.Replace(NHHGDIDEIMM, "Warbucks: {0}\n", string.Empty));
			string text = "CardManagerData" + NHHGDIDEIMM + "setPushNotificationRegistrationId";
			Debug.Log("ID_SALEPERCENT" + text);
			JToken content = JToken.Parse(text);
			JProperty content2 = new JProperty("it", content);
			if (OGNGMBLDAOP.First != null)
			{
				Debug.LogError("Gold");
				OGNGMBLDAOP.Last.AddAfterSelf(content2);
			}
			else
			{
				Debug.LogError("Locale");
				OGNGMBLDAOP = new JObject(content2);
			}
			Debug.Log("\n");
			HHFHFANGCEJ hHFHFANGCEJ = ICGLBEOPPLP(OGNGMBLDAOP, hPGHHECHLAN);
			Debug.Log("Level");
			hHFHFANGCEJ.EJBEDLHIKDG = GameLoginManager.instance.playerId;
			hHFHFANGCEJ.HPGHHECHLAN = hPGHHECHLAN;
			hHFHFANGCEJ.KJCKFGCLGLG = Convert.ToInt32(Regex.Replace(NHHGDIDEIMM, "Name", string.Empty));
			Debug.Log("ID_ARENAWILLOPENSOON" + hHFHFANGCEJ.NHHGDIDEIMM);
			return hHFHFANGCEJ;
		}
		catch (Exception ex)
		{
			Debug.Log(ex.StackTrace);
			Debug.LogError("ID_ARENAWONFLAWLESSLYTEXT" + ex.Message);
			return null;
		}
	}

	public virtual void LACLELOOKHD()
	{
		throw new NotImplementedException();
	}

	public virtual void OEAJBFLGJCA()
	{
		EABMMNBCABK = false;
	}

	public virtual void AFHANMFDNGB()
	{
	}

	public bool PKNNBCCLADK()
	{
		return EABMMNBCABK;
	}

	public void BCIOBLLBLLC()
	{
		Singleton<MessageManager>.instance.SentDatabaseMessageIgnore(NHHGDIDEIMM);
		MJGAKEOAKNA = true;
	}

	[SpecialName]
	public virtual bool KOGNNLBGBKJ()
	{
		return false;
	}

	[SpecialName]
	public void GOGAHDHJBAE(bool IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM && !LBLGJDOMOFJ && PKDOJNABLDE)
		{
			Singleton<MessageManager>.instance.FJKCLMFCFDO(NHHGDIDEIMM, EJBEDLHIKDG);
		}
		LBLGJDOMOFJ = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual bool PHFNIOBIKML()
	{
		return true;
	}

	[SpecialName]
	public void KINBBAFNJPG(bool IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM && !LBLGJDOMOFJ && PKDOJNABLDE)
		{
			Singleton<MessageManager>.instance.SentDatabaseMessageWasShown(NHHGDIDEIMM, EJBEDLHIKDG);
		}
		LBLGJDOMOFJ = IDEBKDPMPGM;
	}
}
