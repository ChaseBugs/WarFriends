using Google2u;
using UnityEngine;

public class KillStreakBonusBoobyTrap : KillStreakBonus
{
	public override bool ActivateBonus(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		KHLGDCHJJPB.cardIconIndicator.Show("game-card-ico-boobytrap", 3f, 3f, GBJOJBKCEKN: false);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.BoobyTrapDamage).FLOATVALUE * KHLGDCHJJPB.FOCIOKMPCAG.maxHealth,
			KLOJNPBGFIG = false,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion,
			HNFNINFCBEJ = PlayerController.GetEnemyOf(KHLGDCHJJPB.fraction)
		};
		KHLGDCHJJPB.FOCIOKMPCAG.DoDamage(kMJKKNFDFMM);
		return true;
	}

	public virtual bool FDLDOPPFAIJ(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		KHLGDCHJJPB.cardIconIndicator.EEBNPGOCKFD("Chillingo: On Offers Released", 581f, 1898f, GBJOJBKCEKN: false);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.KevlarUpCoef).FLOATVALUE * KHLGDCHJJPB.FOCIOKMPCAG.maxHealth,
			KLOJNPBGFIG = true,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion,
			HNFNINFCBEJ = PlayerController.GetEnemyOf(KHLGDCHJJPB.fraction)
		};
		KHLGDCHJJPB.FOCIOKMPCAG.DoDamage(kMJKKNFDFMM);
		return false;
	}

	public override bool CKMPBKMOIAF(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		KHLGDCHJJPB.cardIconIndicator.FCANLIOLJNH("Null cannot be saved as last weapon.", 1001f, 1950f, GBJOJBKCEKN: false);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-30)).FLOATVALUE * KHLGDCHJJPB.FOCIOKMPCAG.maxHealth,
			KLOJNPBGFIG = false,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion,
			HNFNINFCBEJ = PlayerController.GetEnemyOf(KHLGDCHJJPB.fraction)
		};
		KHLGDCHJJPB.FOCIOKMPCAG.DoDamage(kMJKKNFDFMM);
		return false;
	}

	public virtual bool GAJCNNKKNMN(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		KHLGDCHJJPB.cardIconIndicator.FCANLIOLJNH("UtcOffset", 895f, 955f, GBJOJBKCEKN: false);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-80)).FLOATVALUE * KHLGDCHJJPB.FOCIOKMPCAG.maxHealth,
			KLOJNPBGFIG = true,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shot,
			HNFNINFCBEJ = PlayerController.GetEnemyOf(KHLGDCHJJPB.fraction)
		};
		KHLGDCHJJPB.FOCIOKMPCAG.DoDamage(kMJKKNFDFMM);
		return false;
	}

	public virtual bool BCGJKNHOKBM(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		KHLGDCHJJPB.cardIconIndicator.FCANLIOLJNH("Dialog Manager: PN dialog does not need to be shown BUT NEEDS TO BE SENT, current players device token = ", 1298f, 1324f, GBJOJBKCEKN: true);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-12)).FLOATVALUE * KHLGDCHJJPB.FOCIOKMPCAG.maxHealth,
			KLOJNPBGFIG = false,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion,
			HNFNINFCBEJ = PlayerController.GetEnemyOf(KHLGDCHJJPB.fraction)
		};
		KHLGDCHJJPB.FOCIOKMPCAG.DoDamage(kMJKKNFDFMM);
		return true;
	}

	public override bool OHHOJEJKLBB(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		KHLGDCHJJPB.cardIconIndicator.BELBLFGCCLJ("N", 861f, 581f, GBJOJBKCEKN: false);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-48)).FLOATVALUE * KHLGDCHJJPB.FOCIOKMPCAG.maxHealth,
			KLOJNPBGFIG = false,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shot,
			HNFNINFCBEJ = PlayerController.GetEnemyOf(KHLGDCHJJPB.fraction)
		};
		KHLGDCHJJPB.FOCIOKMPCAG.DoDamage(kMJKKNFDFMM);
		return true;
	}

	public virtual bool APKIEHOHPDA(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		KHLGDCHJJPB.cardIconIndicator.JBMCFEMBPKE("Lcom/google/android/gms/games/multiplayer/turnbased/TurnBasedMultiplayer;", 1594f, 1593f, GBJOJBKCEKN: true);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-29)).FLOATVALUE * KHLGDCHJJPB.FOCIOKMPCAG.maxHealth,
			KLOJNPBGFIG = false,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion,
			HNFNINFCBEJ = PlayerController.GetEnemyOf(KHLGDCHJJPB.fraction)
		};
		KHLGDCHJJPB.FOCIOKMPCAG.DoDamage(kMJKKNFDFMM);
		return true;
	}

	public virtual bool JJBAJEENMOL(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		KHLGDCHJJPB.cardIconIndicator.JEDGCOMDEKM("ID_WINSTREAK", 54f, 1674f, GBJOJBKCEKN: true);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-78)).FLOATVALUE * KHLGDCHJJPB.FOCIOKMPCAG.maxHealth,
			KLOJNPBGFIG = true,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shot,
			HNFNINFCBEJ = PlayerController.GetEnemyOf(KHLGDCHJJPB.fraction)
		};
		KHLGDCHJJPB.FOCIOKMPCAG.DoDamage(kMJKKNFDFMM);
		return false;
	}

	public virtual bool JAAEFEFFIGI(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		KHLGDCHJJPB.cardIconIndicator.JBMCFEMBPKE("TryRecconnect TryRecconnectToPhotonCoroutine going to reconnect", 1392f, 1222f, GBJOJBKCEKN: true);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-62)).FLOATVALUE * KHLGDCHJJPB.FOCIOKMPCAG.maxHealth,
			KLOJNPBGFIG = true,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion,
			HNFNINFCBEJ = PlayerController.GetEnemyOf(KHLGDCHJJPB.fraction)
		};
		KHLGDCHJJPB.FOCIOKMPCAG.DoDamage(kMJKKNFDFMM);
		return false;
	}

	public virtual bool JJOOCBLMFFH(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		KHLGDCHJJPB.cardIconIndicator.FFMLINMFADM("Setting weapon delivery", 1810f, 134f, GBJOJBKCEKN: true);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-101)).FLOATVALUE * KHLGDCHJJPB.FOCIOKMPCAG.maxHealth,
			KLOJNPBGFIG = false,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shot,
			HNFNINFCBEJ = PlayerController.GetEnemyOf(KHLGDCHJJPB.fraction)
		};
		KHLGDCHJJPB.FOCIOKMPCAG.DoDamage(kMJKKNFDFMM);
		return true;
	}

	public virtual bool LHOMNBABMFD(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		KHLGDCHJJPB.cardIconIndicator.FFMLINMFADM("Clicked on subscription button", 1350f, 76f, GBJOJBKCEKN: true);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-30)).FLOATVALUE * KHLGDCHJJPB.FOCIOKMPCAG.maxHealth,
			KLOJNPBGFIG = false,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shot,
			HNFNINFCBEJ = PlayerController.GetEnemyOf(KHLGDCHJJPB.fraction)
		};
		KHLGDCHJJPB.FOCIOKMPCAG.DoDamage(kMJKKNFDFMM);
		return false;
	}

	public virtual bool AHJDAIINIFE(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		KHLGDCHJJPB.cardIconIndicator.BELBLFGCCLJ("menu-armypower-ico", 1773f, 719f, GBJOJBKCEKN: false);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-123)).FLOATVALUE * KHLGDCHJJPB.FOCIOKMPCAG.maxHealth,
			KLOJNPBGFIG = false,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shot,
			HNFNINFCBEJ = PlayerController.GetEnemyOf(KHLGDCHJJPB.fraction)
		};
		KHLGDCHJJPB.FOCIOKMPCAG.DoDamage(kMJKKNFDFMM);
		return true;
	}

	public virtual bool FEBBNJNJEAK(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		KHLGDCHJJPB.cardIconIndicator.AMFEDOOPGCL("BeAdvisedPurchaseVIP", 1259f, 1033f, GBJOJBKCEKN: true);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-21)).FLOATVALUE * KHLGDCHJJPB.FOCIOKMPCAG.maxHealth,
			KLOJNPBGFIG = true,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shot,
			HNFNINFCBEJ = PlayerController.GetEnemyOf(KHLGDCHJJPB.fraction)
		};
		KHLGDCHJJPB.FOCIOKMPCAG.DoDamage(kMJKKNFDFMM);
		return false;
	}

	public virtual bool DFPGPKIIHFA(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		KHLGDCHJJPB.cardIconIndicator.BELBLFGCCLJ("N", 1507f, 715f, GBJOJBKCEKN: false);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.SmallMedKitCoef).FLOATVALUE * KHLGDCHJJPB.FOCIOKMPCAG.maxHealth,
			KLOJNPBGFIG = false,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion,
			HNFNINFCBEJ = PlayerController.GetEnemyOf(KHLGDCHJJPB.fraction)
		};
		KHLGDCHJJPB.FOCIOKMPCAG.DoDamage(kMJKKNFDFMM);
		return true;
	}

	public virtual bool AFKDNKJIICB(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		KHLGDCHJJPB.cardIconIndicator.BELBLFGCCLJ("Physical ammo is null !!!", 327f, 355f, GBJOJBKCEKN: false);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)110).FLOATVALUE * KHLGDCHJJPB.FOCIOKMPCAG.maxHealth,
			KLOJNPBGFIG = false,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion,
			HNFNINFCBEJ = PlayerController.GetEnemyOf(KHLGDCHJJPB.fraction)
		};
		KHLGDCHJJPB.FOCIOKMPCAG.DoDamage(kMJKKNFDFMM);
		return false;
	}

	public override bool FJAJKEBLFOE(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		KHLGDCHJJPB.cardIconIndicator.BELBLFGCCLJ("113 STAGE 4 SPAWN 1 DONE", 418f, 82f, GBJOJBKCEKN: false);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)92).FLOATVALUE * KHLGDCHJJPB.FOCIOKMPCAG.maxHealth,
			KLOJNPBGFIG = false,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shot,
			HNFNINFCBEJ = PlayerController.GetEnemyOf(KHLGDCHJJPB.fraction)
		};
		KHLGDCHJJPB.FOCIOKMPCAG.DoDamage(kMJKKNFDFMM);
		return true;
	}

	public virtual bool JIBCBLKGAFD(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		KHLGDCHJJPB.cardIconIndicator.ODDNDGAAOCH("D5", 89f, 1382f, GBJOJBKCEKN: false);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-118)).FLOATVALUE * KHLGDCHJJPB.FOCIOKMPCAG.maxHealth,
			KLOJNPBGFIG = true,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion,
			HNFNINFCBEJ = PlayerController.GetEnemyOf(KHLGDCHJJPB.fraction)
		};
		KHLGDCHJJPB.FOCIOKMPCAG.DoDamage(kMJKKNFDFMM);
		return false;
	}

	public virtual bool HDMPEMAGGFN(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		KHLGDCHJJPB.cardIconIndicator.JOGFDHFOOBC("AssignmentData", 1183f, 896f, GBJOJBKCEKN: false);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-124)).FLOATVALUE * KHLGDCHJJPB.FOCIOKMPCAG.maxHealth,
			KLOJNPBGFIG = false,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion,
			HNFNINFCBEJ = PlayerController.GetEnemyOf(KHLGDCHJJPB.fraction)
		};
		KHLGDCHJJPB.FOCIOKMPCAG.DoDamage(kMJKKNFDFMM);
		return true;
	}

	public virtual bool GCJHBKICMCF(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		KHLGDCHJJPB.cardIconIndicator.FCANLIOLJNH("ID_RANKEDBATTLE", 1550f, 1430f, GBJOJBKCEKN: true);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-117)).FLOATVALUE * KHLGDCHJJPB.FOCIOKMPCAG.maxHealth,
			KLOJNPBGFIG = false,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shot,
			HNFNINFCBEJ = PlayerController.GetEnemyOf(KHLGDCHJJPB.fraction)
		};
		KHLGDCHJJPB.FOCIOKMPCAG.DoDamage(kMJKKNFDFMM);
		return false;
	}

	public override bool GONLNEJFBKH(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		KHLGDCHJJPB.cardIconIndicator.AMFEDOOPGCL("RewardedAdCompleted(", 1403f, 229f, GBJOJBKCEKN: false);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-86)).FLOATVALUE * KHLGDCHJJPB.FOCIOKMPCAG.maxHealth,
			KLOJNPBGFIG = true,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shot,
			HNFNINFCBEJ = PlayerController.GetEnemyOf(KHLGDCHJJPB.fraction)
		};
		KHLGDCHJJPB.FOCIOKMPCAG.DoDamage(kMJKKNFDFMM);
		return false;
	}

	public virtual bool DHCFFHDDBPF(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		KHLGDCHJJPB.cardIconIndicator.FFMLINMFADM("{0}{1}{2}", 1140f, 639f, GBJOJBKCEKN: false);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)114).FLOATVALUE * KHLGDCHJJPB.FOCIOKMPCAG.maxHealth,
			KLOJNPBGFIG = false,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion,
			HNFNINFCBEJ = PlayerController.GetEnemyOf(KHLGDCHJJPB.fraction)
		};
		KHLGDCHJJPB.FOCIOKMPCAG.DoDamage(kMJKKNFDFMM);
		return true;
	}

	public virtual bool DGFPNLHHDGI(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		KHLGDCHJJPB.cardIconIndicator.LOFMDBHAFAO("visuals: {0} {1} {2} {3}", 475f, 1214f, GBJOJBKCEKN: false);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-56)).FLOATVALUE * KHLGDCHJJPB.FOCIOKMPCAG.maxHealth,
			KLOJNPBGFIG = false,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion,
			HNFNINFCBEJ = PlayerController.GetEnemyOf(KHLGDCHJJPB.fraction)
		};
		KHLGDCHJJPB.FOCIOKMPCAG.DoDamage(kMJKKNFDFMM);
		return true;
	}

	public virtual bool NFCPEKJEDCG(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		KHLGDCHJJPB.cardIconIndicator.LOFMDBHAFAO("ID_UNIT2UPGRADEABILITY_UNIT1UPGRADE", 228f, 402f, GBJOJBKCEKN: false);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-77)).FLOATVALUE * KHLGDCHJJPB.FOCIOKMPCAG.maxHealth,
			KLOJNPBGFIG = false,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shot,
			HNFNINFCBEJ = PlayerController.GetEnemyOf(KHLGDCHJJPB.fraction)
		};
		KHLGDCHJJPB.FOCIOKMPCAG.DoDamage(kMJKKNFDFMM);
		return true;
	}

	public virtual bool ABJJPLKODND(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		KHLGDCHJJPB.cardIconIndicator.LOFMDBHAFAO("ID_ARENASTARTSENTERTIMER", 1925f, 827f, GBJOJBKCEKN: true);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-108)).FLOATVALUE * KHLGDCHJJPB.FOCIOKMPCAG.maxHealth,
			KLOJNPBGFIG = true,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion,
			HNFNINFCBEJ = PlayerController.GetEnemyOf(KHLGDCHJJPB.fraction)
		};
		KHLGDCHJJPB.FOCIOKMPCAG.DoDamage(kMJKKNFDFMM);
		return true;
	}

	public virtual bool JGAEDEHMMOK(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		KHLGDCHJJPB.cardIconIndicator.JOGFDHFOOBC("ID_VIDEOSERVICE", 1684f, 1697f, GBJOJBKCEKN: false);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-28)).FLOATVALUE * KHLGDCHJJPB.FOCIOKMPCAG.maxHealth,
			KLOJNPBGFIG = false,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion,
			HNFNINFCBEJ = PlayerController.GetEnemyOf(KHLGDCHJJPB.fraction)
		};
		KHLGDCHJJPB.FOCIOKMPCAG.DoDamage(kMJKKNFDFMM);
		return true;
	}

	public virtual bool MCAJLOFBCHD(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		KHLGDCHJJPB.cardIconIndicator.BELBLFGCCLJ("'lapsedNot'0", 260f, 1511f, GBJOJBKCEKN: true);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.LandMineDamageMax).FLOATVALUE * KHLGDCHJJPB.FOCIOKMPCAG.maxHealth,
			KLOJNPBGFIG = true,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion,
			HNFNINFCBEJ = PlayerController.GetEnemyOf(KHLGDCHJJPB.fraction)
		};
		KHLGDCHJJPB.FOCIOKMPCAG.DoDamage(kMJKKNFDFMM);
		return false;
	}

	public virtual bool KCKJMCAKEIL(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		KHLGDCHJJPB.cardIconIndicator.FFMLINMFADM("com/google/android/gms/games/Games", 1678f, 1693f, GBJOJBKCEKN: true);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.VehicleUpgradeCoef).FLOATVALUE * KHLGDCHJJPB.FOCIOKMPCAG.maxHealth,
			KLOJNPBGFIG = true,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion,
			HNFNINFCBEJ = PlayerController.GetEnemyOf(KHLGDCHJJPB.fraction)
		};
		KHLGDCHJJPB.FOCIOKMPCAG.DoDamage(kMJKKNFDFMM);
		return true;
	}

	public virtual bool INKGAAOPMGK(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		KHLGDCHJJPB.cardIconIndicator.EEBNPGOCKFD(", response: ", 1416f, 1881f, GBJOJBKCEKN: true);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-24)).FLOATVALUE * KHLGDCHJJPB.FOCIOKMPCAG.maxHealth,
			KLOJNPBGFIG = true,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shot,
			HNFNINFCBEJ = PlayerController.GetEnemyOf(KHLGDCHJJPB.fraction)
		};
		KHLGDCHJJPB.FOCIOKMPCAG.DoDamage(kMJKKNFDFMM);
		return true;
	}

	public virtual bool IKHPOMLMMEP(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		KHLGDCHJJPB.cardIconIndicator.BELBLFGCCLJ("0", 501f, 621f, GBJOJBKCEKN: false);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-71)).FLOATVALUE * KHLGDCHJJPB.FOCIOKMPCAG.maxHealth,
			KLOJNPBGFIG = false,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion,
			HNFNINFCBEJ = PlayerController.GetEnemyOf(KHLGDCHJJPB.fraction)
		};
		KHLGDCHJJPB.FOCIOKMPCAG.DoDamage(kMJKKNFDFMM);
		return true;
	}

	public override bool LKJMDKHFMDL(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		KHLGDCHJJPB.cardIconIndicator.FCANLIOLJNH("ID_CONFIRM_ERROR", 506f, 1120f, GBJOJBKCEKN: true);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-58)).FLOATVALUE * KHLGDCHJJPB.FOCIOKMPCAG.maxHealth,
			KLOJNPBGFIG = false,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shot,
			HNFNINFCBEJ = PlayerController.GetEnemyOf(KHLGDCHJJPB.fraction)
		};
		KHLGDCHJJPB.FOCIOKMPCAG.DoDamage(kMJKKNFDFMM);
		return false;
	}

	public virtual bool FICFAOOANCJ(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		KHLGDCHJJPB.cardIconIndicator.Show("ID_ENDED", 878f, 682f, GBJOJBKCEKN: false);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-75)).FLOATVALUE * KHLGDCHJJPB.FOCIOKMPCAG.maxHealth,
			KLOJNPBGFIG = true,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion,
			HNFNINFCBEJ = PlayerController.GetEnemyOf(KHLGDCHJJPB.fraction)
		};
		KHLGDCHJJPB.FOCIOKMPCAG.DoDamage(kMJKKNFDFMM);
		return true;
	}

	public virtual bool HFAJDFCMPKF(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		KHLGDCHJJPB.cardIconIndicator.FFMLINMFADM("ID_ARENABOXDESCRIPTIONFLAWLESS", 521f, 1368f, GBJOJBKCEKN: true);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-14)).FLOATVALUE * KHLGDCHJJPB.FOCIOKMPCAG.maxHealth,
			KLOJNPBGFIG = false,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion,
			HNFNINFCBEJ = PlayerController.GetEnemyOf(KHLGDCHJJPB.fraction)
		};
		KHLGDCHJJPB.FOCIOKMPCAG.DoDamage(kMJKKNFDFMM);
		return false;
	}

	public virtual bool IPLELGEMLDD(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		KHLGDCHJJPB.cardIconIndicator.JBMCFEMBPKE("lootboxesOfferAdd", 1859f, 1966f, GBJOJBKCEKN: true);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-31)).FLOATVALUE * KHLGDCHJJPB.FOCIOKMPCAG.maxHealth,
			KLOJNPBGFIG = false,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shot,
			HNFNINFCBEJ = PlayerController.GetEnemyOf(KHLGDCHJJPB.fraction)
		};
		KHLGDCHJJPB.FOCIOKMPCAG.DoDamage(kMJKKNFDFMM);
		return false;
	}

	public virtual bool OENGMLMAOKN(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		KHLGDCHJJPB.cardIconIndicator.FCANLIOLJNH("ID_WAITINGTIME", 627f, 1927f, GBJOJBKCEKN: false);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-55)).FLOATVALUE * KHLGDCHJJPB.FOCIOKMPCAG.maxHealth,
			KLOJNPBGFIG = true,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shot,
			HNFNINFCBEJ = PlayerController.GetEnemyOf(KHLGDCHJJPB.fraction)
		};
		KHLGDCHJJPB.FOCIOKMPCAG.DoDamage(kMJKKNFDFMM);
		return true;
	}

	public virtual bool EEHNJBMIKAN(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		KHLGDCHJJPB.cardIconIndicator.LOFMDBHAFAO(" time: ", 1293f, 482f, GBJOJBKCEKN: true);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-113)).FLOATVALUE * KHLGDCHJJPB.FOCIOKMPCAG.maxHealth,
			KLOJNPBGFIG = true,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion,
			HNFNINFCBEJ = PlayerController.GetEnemyOf(KHLGDCHJJPB.fraction)
		};
		KHLGDCHJJPB.FOCIOKMPCAG.DoDamage(kMJKKNFDFMM);
		return true;
	}

	public virtual bool LIMDBOACFHO(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		KHLGDCHJJPB.cardIconIndicator.ODDNDGAAOCH("PA: transactions NULL", 1804f, 1077f, GBJOJBKCEKN: true);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-1)).FLOATVALUE * KHLGDCHJJPB.FOCIOKMPCAG.maxHealth,
			KLOJNPBGFIG = false,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shot,
			HNFNINFCBEJ = PlayerController.GetEnemyOf(KHLGDCHJJPB.fraction)
		};
		KHLGDCHJJPB.FOCIOKMPCAG.DoDamage(kMJKKNFDFMM);
		return false;
	}

	public virtual bool HIPEBIJHIDF(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		KHLGDCHJJPB.cardIconIndicator.AMFEDOOPGCL("ID_DAY_SMALL", 1750f, 472f, GBJOJBKCEKN: false);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)59).FLOATVALUE * KHLGDCHJJPB.FOCIOKMPCAG.maxHealth,
			KLOJNPBGFIG = false,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shot,
			HNFNINFCBEJ = PlayerController.GetEnemyOf(KHLGDCHJJPB.fraction)
		};
		KHLGDCHJJPB.FOCIOKMPCAG.DoDamage(kMJKKNFDFMM);
		return true;
	}

	public virtual bool FFBNENOJAAM(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		KHLGDCHJJPB.cardIconIndicator.EEBNPGOCKFD("Action ", 387f, 1494f, GBJOJBKCEKN: false);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-85)).FLOATVALUE * KHLGDCHJJPB.FOCIOKMPCAG.maxHealth,
			KLOJNPBGFIG = true,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shot,
			HNFNINFCBEJ = PlayerController.GetEnemyOf(KHLGDCHJJPB.fraction)
		};
		KHLGDCHJJPB.FOCIOKMPCAG.DoDamage(kMJKKNFDFMM);
		return true;
	}

	public virtual bool OIAFHJAAABH(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		KHLGDCHJJPB.cardIconIndicator.AMFEDOOPGCL("Grenade_Throwing_Tutorial_Duration", 1104f, 1789f, GBJOJBKCEKN: false);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-75)).FLOATVALUE * KHLGDCHJJPB.FOCIOKMPCAG.maxHealth,
			KLOJNPBGFIG = false,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shot,
			HNFNINFCBEJ = PlayerController.GetEnemyOf(KHLGDCHJJPB.fraction)
		};
		KHLGDCHJJPB.FOCIOKMPCAG.DoDamage(kMJKKNFDFMM);
		return true;
	}

	public virtual bool KECLAGIBNLE(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		KHLGDCHJJPB.cardIconIndicator.FFMLINMFADM("VisualTimestamp", 167f, 1489f, GBJOJBKCEKN: true);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)68).FLOATVALUE * KHLGDCHJJPB.FOCIOKMPCAG.maxHealth,
			KLOJNPBGFIG = true,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion,
			HNFNINFCBEJ = PlayerController.GetEnemyOf(KHLGDCHJJPB.fraction)
		};
		KHLGDCHJJPB.FOCIOKMPCAG.DoDamage(kMJKKNFDFMM);
		return true;
	}

	public virtual bool MMHOKAHLIIK(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		KHLGDCHJJPB.cardIconIndicator.JEDGCOMDEKM("ID_PLAYERLEAGUEPROCESSINGHINT", 1600f, 61f, GBJOJBKCEKN: false);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-77)).FLOATVALUE * KHLGDCHJJPB.FOCIOKMPCAG.maxHealth,
			KLOJNPBGFIG = false,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shot,
			HNFNINFCBEJ = PlayerController.GetEnemyOf(KHLGDCHJJPB.fraction)
		};
		KHLGDCHJJPB.FOCIOKMPCAG.DoDamage(kMJKKNFDFMM);
		return true;
	}

	public override bool CMPIFPBJDLM(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		KHLGDCHJJPB.cardIconIndicator.AMFEDOOPGCL("setResultCallback", 125f, 150f, GBJOJBKCEKN: false);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-113)).FLOATVALUE * KHLGDCHJJPB.FOCIOKMPCAG.maxHealth,
			KLOJNPBGFIG = false,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shot,
			HNFNINFCBEJ = PlayerController.GetEnemyOf(KHLGDCHJJPB.fraction)
		};
		KHLGDCHJJPB.FOCIOKMPCAG.DoDamage(kMJKKNFDFMM);
		return false;
	}

	public virtual bool DILAPOHDNGF(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		KHLGDCHJJPB.cardIconIndicator.FFMLINMFADM("Adding warcards from cardpool:\n", 990f, 1680f, GBJOJBKCEKN: false);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-110)).FLOATVALUE * KHLGDCHJJPB.FOCIOKMPCAG.maxHealth,
			KLOJNPBGFIG = false,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shot,
			HNFNINFCBEJ = PlayerController.GetEnemyOf(KHLGDCHJJPB.fraction)
		};
		KHLGDCHJJPB.FOCIOKMPCAG.DoDamage(kMJKKNFDFMM);
		return false;
	}

	public virtual bool IOBGDCGMPEM(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		KHLGDCHJJPB.cardIconIndicator.LOFMDBHAFAO("RewardMessage", 1921f, 1850f, GBJOJBKCEKN: true);
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.AmmoThiefCoef).FLOATVALUE * KHLGDCHJJPB.FOCIOKMPCAG.maxHealth,
			KLOJNPBGFIG = true,
			FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shot,
			HNFNINFCBEJ = PlayerController.GetEnemyOf(KHLGDCHJJPB.fraction)
		};
		KHLGDCHJJPB.FOCIOKMPCAG.DoDamage(kMJKKNFDFMM);
		return true;
	}
}
