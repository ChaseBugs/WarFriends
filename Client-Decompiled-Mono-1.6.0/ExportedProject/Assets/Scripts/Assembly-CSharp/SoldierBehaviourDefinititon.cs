using System;
using UnityEngine;

[Serializable]
public class SoldierBehaviourDefinititon : BehaviourDefinititon
{
	public int fireBatchSizeMin = 1;

	public int fireBatchSizeMax = 4;

	public float minShootTime = 1f;

	public float maxShootTime = 5f;

	public bool useSecondaryWeapon;

	public float switchToSecondaryProb;

	public bool canShootWhileRunning;

	public bool canShootWhileRunningDontStop;

	public bool canUseParachute;

	public float walkShotTimeMin = 1f;

	public float walkShotTimeMax = 5f;

	public float special;

	public override BehaviourDefinititon MDFLAMBJIPM(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		SoldierBehaviourDefinititon soldierBehaviourDefinititon = (SoldierBehaviourDefinititon)LLGHNHMFCPN;
		SoldierBehaviourDefinititon soldierBehaviourDefinititon2 = (SoldierBehaviourDefinititon)AJCHDECIFJC;
		SoldierBehaviourDefinititon soldierBehaviourDefinititon3 = (SoldierBehaviourDefinititon)LLGHNHMFCPN.ABNPNLMHNKK();
		soldierBehaviourDefinititon3.health = Mathf.Lerp(soldierBehaviourDefinititon.health, soldierBehaviourDefinititon2.health, GACKNHPFGFM);
		soldierBehaviourDefinititon3.probabilityOfRealShot = Mathf.Lerp(soldierBehaviourDefinititon.probabilityOfRealShot, soldierBehaviourDefinititon2.probabilityOfRealShot, GACKNHPFGFM);
		soldierBehaviourDefinititon3.damage = Mathf.Lerp(soldierBehaviourDefinititon.damage, soldierBehaviourDefinititon2.damage, GACKNHPFGFM);
		soldierBehaviourDefinititon3.fireBatchSizeMin = (int)Mathf.Lerp(soldierBehaviourDefinititon.fireBatchSizeMin, soldierBehaviourDefinititon2.fireBatchSizeMin, GACKNHPFGFM);
		soldierBehaviourDefinititon3.fireBatchSizeMax = (int)Mathf.Lerp(soldierBehaviourDefinititon.fireBatchSizeMax, soldierBehaviourDefinititon2.fireBatchSizeMax, GACKNHPFGFM);
		soldierBehaviourDefinititon3.minShootTime = Mathf.Lerp(soldierBehaviourDefinititon.minShootTime, soldierBehaviourDefinititon2.minShootTime, GACKNHPFGFM);
		soldierBehaviourDefinititon3.maxShootTime = Mathf.Lerp(soldierBehaviourDefinititon.maxShootTime, soldierBehaviourDefinititon2.maxShootTime, GACKNHPFGFM);
		soldierBehaviourDefinititon3.walkShotTimeMin = Mathf.Lerp(soldierBehaviourDefinititon.walkShotTimeMin, soldierBehaviourDefinititon2.walkShotTimeMin, GACKNHPFGFM);
		soldierBehaviourDefinititon3.walkShotTimeMax = Mathf.Lerp(soldierBehaviourDefinititon.walkShotTimeMax, soldierBehaviourDefinititon2.walkShotTimeMax, GACKNHPFGFM);
		return soldierBehaviourDefinititon3;
	}

	public virtual BehaviourDefinititon AFHECGBAKDG(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		SoldierBehaviourDefinititon soldierBehaviourDefinititon = (SoldierBehaviourDefinititon)LLGHNHMFCPN;
		SoldierBehaviourDefinititon soldierBehaviourDefinititon2 = (SoldierBehaviourDefinititon)AJCHDECIFJC;
		SoldierBehaviourDefinititon soldierBehaviourDefinititon3 = (SoldierBehaviourDefinititon)LLGHNHMFCPN.PONPCFJHNOM();
		soldierBehaviourDefinititon3.health = Mathf.Lerp(soldierBehaviourDefinititon.health, soldierBehaviourDefinititon2.health, GACKNHPFGFM);
		soldierBehaviourDefinititon3.probabilityOfRealShot = Mathf.Lerp(soldierBehaviourDefinititon.probabilityOfRealShot, soldierBehaviourDefinititon2.probabilityOfRealShot, GACKNHPFGFM);
		soldierBehaviourDefinititon3.damage = Mathf.Lerp(soldierBehaviourDefinititon.damage, soldierBehaviourDefinititon2.damage, GACKNHPFGFM);
		soldierBehaviourDefinititon3.fireBatchSizeMin = (int)Mathf.Lerp(soldierBehaviourDefinititon.fireBatchSizeMin, soldierBehaviourDefinititon2.fireBatchSizeMin, GACKNHPFGFM);
		soldierBehaviourDefinititon3.fireBatchSizeMax = (int)Mathf.Lerp(soldierBehaviourDefinititon.fireBatchSizeMax, soldierBehaviourDefinititon2.fireBatchSizeMax, GACKNHPFGFM);
		soldierBehaviourDefinititon3.minShootTime = Mathf.Lerp(soldierBehaviourDefinititon.minShootTime, soldierBehaviourDefinititon2.minShootTime, GACKNHPFGFM);
		soldierBehaviourDefinititon3.maxShootTime = Mathf.Lerp(soldierBehaviourDefinititon.maxShootTime, soldierBehaviourDefinititon2.maxShootTime, GACKNHPFGFM);
		soldierBehaviourDefinititon3.walkShotTimeMin = Mathf.Lerp(soldierBehaviourDefinititon.walkShotTimeMin, soldierBehaviourDefinititon2.walkShotTimeMin, GACKNHPFGFM);
		soldierBehaviourDefinititon3.walkShotTimeMax = Mathf.Lerp(soldierBehaviourDefinititon.walkShotTimeMax, soldierBehaviourDefinititon2.walkShotTimeMax, GACKNHPFGFM);
		return soldierBehaviourDefinititon3;
	}

	public override void FPKDOOLFAMM()
	{
		health = 1958f;
		probabilityOfRealShot = 498f;
		fireBatchSizeMin = 0;
		fireBatchSizeMax = 0;
		minShootTime = 809f;
		maxShootTime = 211f;
		damage = 746f;
		special = 144f;
		walkShotTimeMin = 651f;
		walkShotTimeMax = 1458f;
	}

	public virtual void DLKALMFJOJF()
	{
		health = 472f;
		probabilityOfRealShot = 1467f;
		fireBatchSizeMin = 1;
		fireBatchSizeMax = 0;
		minShootTime = 1668f;
		maxShootTime = 651f;
		damage = 1173f;
		special = 743f;
		walkShotTimeMin = 470f;
		walkShotTimeMax = 951f;
	}

	public override BehaviourDefinititon FPJFMJGJMMH(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		SoldierBehaviourDefinititon soldierBehaviourDefinititon = (SoldierBehaviourDefinititon)LLGHNHMFCPN;
		SoldierBehaviourDefinititon soldierBehaviourDefinititon2 = (SoldierBehaviourDefinititon)AJCHDECIFJC;
		SoldierBehaviourDefinititon soldierBehaviourDefinititon3 = (SoldierBehaviourDefinititon)LLGHNHMFCPN.AFBBNOFJJCP();
		soldierBehaviourDefinititon3.health = Mathf.Lerp(soldierBehaviourDefinititon.health, soldierBehaviourDefinititon2.health, GACKNHPFGFM);
		soldierBehaviourDefinititon3.probabilityOfRealShot = Mathf.Lerp(soldierBehaviourDefinititon.probabilityOfRealShot, soldierBehaviourDefinititon2.probabilityOfRealShot, GACKNHPFGFM);
		soldierBehaviourDefinititon3.damage = Mathf.Lerp(soldierBehaviourDefinititon.damage, soldierBehaviourDefinititon2.damage, GACKNHPFGFM);
		soldierBehaviourDefinititon3.fireBatchSizeMin = (int)Mathf.Lerp(soldierBehaviourDefinititon.fireBatchSizeMin, soldierBehaviourDefinititon2.fireBatchSizeMin, GACKNHPFGFM);
		soldierBehaviourDefinititon3.fireBatchSizeMax = (int)Mathf.Lerp(soldierBehaviourDefinititon.fireBatchSizeMax, soldierBehaviourDefinititon2.fireBatchSizeMax, GACKNHPFGFM);
		soldierBehaviourDefinititon3.minShootTime = Mathf.Lerp(soldierBehaviourDefinititon.minShootTime, soldierBehaviourDefinititon2.minShootTime, GACKNHPFGFM);
		soldierBehaviourDefinititon3.maxShootTime = Mathf.Lerp(soldierBehaviourDefinititon.maxShootTime, soldierBehaviourDefinititon2.maxShootTime, GACKNHPFGFM);
		soldierBehaviourDefinititon3.walkShotTimeMin = Mathf.Lerp(soldierBehaviourDefinititon.walkShotTimeMin, soldierBehaviourDefinititon2.walkShotTimeMin, GACKNHPFGFM);
		soldierBehaviourDefinititon3.walkShotTimeMax = Mathf.Lerp(soldierBehaviourDefinititon.walkShotTimeMax, soldierBehaviourDefinititon2.walkShotTimeMax, GACKNHPFGFM);
		return soldierBehaviourDefinititon3;
	}

	public override void HNCJFJPHNCA()
	{
		health = 237f;
		probabilityOfRealShot = 845f;
		fireBatchSizeMin = 1;
		fireBatchSizeMax = 0;
		minShootTime = 557f;
		maxShootTime = 606f;
		damage = 616f;
		special = 587f;
		walkShotTimeMin = 101f;
		walkShotTimeMax = 578f;
	}

	public override void BMNOBIELKHG()
	{
		health = 1638f;
		probabilityOfRealShot = 833f;
		fireBatchSizeMin = 0;
		fireBatchSizeMax = 1;
		minShootTime = 1755f;
		maxShootTime = 966f;
		damage = 1311f;
		special = 594f;
		walkShotTimeMin = 880f;
		walkShotTimeMax = 1633f;
	}

	public virtual void CEFGHPBGDHJ()
	{
		health = 505f;
		probabilityOfRealShot = 1642f;
		fireBatchSizeMin = 1;
		fireBatchSizeMax = 0;
		minShootTime = 1664f;
		maxShootTime = 516f;
		damage = 348f;
		special = 1052f;
		walkShotTimeMin = 656f;
		walkShotTimeMax = 1110f;
	}

	public virtual void AHPKBGKOBMK()
	{
		health = 1827f;
		probabilityOfRealShot = 1561f;
		fireBatchSizeMin = 1;
		fireBatchSizeMax = 0;
		minShootTime = 700f;
		maxShootTime = 561f;
		damage = 892f;
		special = 688f;
		walkShotTimeMin = 1543f;
		walkShotTimeMax = 1925f;
	}

	public virtual BehaviourDefinititon DHMNGPPLAHI(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		SoldierBehaviourDefinititon soldierBehaviourDefinititon = (SoldierBehaviourDefinititon)LLGHNHMFCPN;
		SoldierBehaviourDefinititon soldierBehaviourDefinititon2 = (SoldierBehaviourDefinititon)AJCHDECIFJC;
		SoldierBehaviourDefinititon soldierBehaviourDefinititon3 = (SoldierBehaviourDefinititon)LLGHNHMFCPN.ABNPNLMHNKK();
		soldierBehaviourDefinititon3.health = Mathf.Lerp(soldierBehaviourDefinititon.health, soldierBehaviourDefinititon2.health, GACKNHPFGFM);
		soldierBehaviourDefinititon3.probabilityOfRealShot = Mathf.Lerp(soldierBehaviourDefinititon.probabilityOfRealShot, soldierBehaviourDefinititon2.probabilityOfRealShot, GACKNHPFGFM);
		soldierBehaviourDefinititon3.damage = Mathf.Lerp(soldierBehaviourDefinititon.damage, soldierBehaviourDefinititon2.damage, GACKNHPFGFM);
		soldierBehaviourDefinititon3.fireBatchSizeMin = (int)Mathf.Lerp(soldierBehaviourDefinititon.fireBatchSizeMin, soldierBehaviourDefinititon2.fireBatchSizeMin, GACKNHPFGFM);
		soldierBehaviourDefinititon3.fireBatchSizeMax = (int)Mathf.Lerp(soldierBehaviourDefinititon.fireBatchSizeMax, soldierBehaviourDefinititon2.fireBatchSizeMax, GACKNHPFGFM);
		soldierBehaviourDefinititon3.minShootTime = Mathf.Lerp(soldierBehaviourDefinititon.minShootTime, soldierBehaviourDefinititon2.minShootTime, GACKNHPFGFM);
		soldierBehaviourDefinititon3.maxShootTime = Mathf.Lerp(soldierBehaviourDefinititon.maxShootTime, soldierBehaviourDefinititon2.maxShootTime, GACKNHPFGFM);
		soldierBehaviourDefinititon3.walkShotTimeMin = Mathf.Lerp(soldierBehaviourDefinititon.walkShotTimeMin, soldierBehaviourDefinititon2.walkShotTimeMin, GACKNHPFGFM);
		soldierBehaviourDefinititon3.walkShotTimeMax = Mathf.Lerp(soldierBehaviourDefinititon.walkShotTimeMax, soldierBehaviourDefinititon2.walkShotTimeMax, GACKNHPFGFM);
		return soldierBehaviourDefinititon3;
	}

	public override BehaviourDefinititon BMLALFLBNKO(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		SoldierBehaviourDefinititon soldierBehaviourDefinititon = (SoldierBehaviourDefinititon)LLGHNHMFCPN;
		SoldierBehaviourDefinititon soldierBehaviourDefinititon2 = (SoldierBehaviourDefinititon)AJCHDECIFJC;
		SoldierBehaviourDefinititon soldierBehaviourDefinititon3 = (SoldierBehaviourDefinititon)LLGHNHMFCPN.HIGKMHJIFJF();
		soldierBehaviourDefinititon3.health = Mathf.Lerp(soldierBehaviourDefinititon.health, soldierBehaviourDefinititon2.health, GACKNHPFGFM);
		soldierBehaviourDefinititon3.probabilityOfRealShot = Mathf.Lerp(soldierBehaviourDefinititon.probabilityOfRealShot, soldierBehaviourDefinititon2.probabilityOfRealShot, GACKNHPFGFM);
		soldierBehaviourDefinititon3.damage = Mathf.Lerp(soldierBehaviourDefinititon.damage, soldierBehaviourDefinititon2.damage, GACKNHPFGFM);
		soldierBehaviourDefinititon3.fireBatchSizeMin = (int)Mathf.Lerp(soldierBehaviourDefinititon.fireBatchSizeMin, soldierBehaviourDefinititon2.fireBatchSizeMin, GACKNHPFGFM);
		soldierBehaviourDefinititon3.fireBatchSizeMax = (int)Mathf.Lerp(soldierBehaviourDefinititon.fireBatchSizeMax, soldierBehaviourDefinititon2.fireBatchSizeMax, GACKNHPFGFM);
		soldierBehaviourDefinititon3.minShootTime = Mathf.Lerp(soldierBehaviourDefinititon.minShootTime, soldierBehaviourDefinititon2.minShootTime, GACKNHPFGFM);
		soldierBehaviourDefinititon3.maxShootTime = Mathf.Lerp(soldierBehaviourDefinititon.maxShootTime, soldierBehaviourDefinititon2.maxShootTime, GACKNHPFGFM);
		soldierBehaviourDefinititon3.walkShotTimeMin = Mathf.Lerp(soldierBehaviourDefinititon.walkShotTimeMin, soldierBehaviourDefinititon2.walkShotTimeMin, GACKNHPFGFM);
		soldierBehaviourDefinititon3.walkShotTimeMax = Mathf.Lerp(soldierBehaviourDefinititon.walkShotTimeMax, soldierBehaviourDefinititon2.walkShotTimeMax, GACKNHPFGFM);
		return soldierBehaviourDefinititon3;
	}

	public virtual void ILGFLFJIIKD()
	{
		health = 912f;
		probabilityOfRealShot = 1878f;
		fireBatchSizeMin = 1;
		fireBatchSizeMax = 0;
		minShootTime = 1782f;
		maxShootTime = 506f;
		damage = 68f;
		special = 1487f;
		walkShotTimeMin = 490f;
		walkShotTimeMax = 1881f;
	}

	public virtual BehaviourDefinititon JKLCBNKNIJE(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		SoldierBehaviourDefinititon soldierBehaviourDefinititon = (SoldierBehaviourDefinititon)LLGHNHMFCPN;
		SoldierBehaviourDefinititon soldierBehaviourDefinititon2 = (SoldierBehaviourDefinititon)AJCHDECIFJC;
		SoldierBehaviourDefinititon soldierBehaviourDefinititon3 = (SoldierBehaviourDefinititon)LLGHNHMFCPN.AFBBNOFJJCP();
		soldierBehaviourDefinititon3.health = Mathf.Lerp(soldierBehaviourDefinititon.health, soldierBehaviourDefinititon2.health, GACKNHPFGFM);
		soldierBehaviourDefinititon3.probabilityOfRealShot = Mathf.Lerp(soldierBehaviourDefinititon.probabilityOfRealShot, soldierBehaviourDefinititon2.probabilityOfRealShot, GACKNHPFGFM);
		soldierBehaviourDefinititon3.damage = Mathf.Lerp(soldierBehaviourDefinititon.damage, soldierBehaviourDefinititon2.damage, GACKNHPFGFM);
		soldierBehaviourDefinititon3.fireBatchSizeMin = (int)Mathf.Lerp(soldierBehaviourDefinititon.fireBatchSizeMin, soldierBehaviourDefinititon2.fireBatchSizeMin, GACKNHPFGFM);
		soldierBehaviourDefinititon3.fireBatchSizeMax = (int)Mathf.Lerp(soldierBehaviourDefinititon.fireBatchSizeMax, soldierBehaviourDefinititon2.fireBatchSizeMax, GACKNHPFGFM);
		soldierBehaviourDefinititon3.minShootTime = Mathf.Lerp(soldierBehaviourDefinititon.minShootTime, soldierBehaviourDefinititon2.minShootTime, GACKNHPFGFM);
		soldierBehaviourDefinititon3.maxShootTime = Mathf.Lerp(soldierBehaviourDefinititon.maxShootTime, soldierBehaviourDefinititon2.maxShootTime, GACKNHPFGFM);
		soldierBehaviourDefinititon3.walkShotTimeMin = Mathf.Lerp(soldierBehaviourDefinititon.walkShotTimeMin, soldierBehaviourDefinititon2.walkShotTimeMin, GACKNHPFGFM);
		soldierBehaviourDefinititon3.walkShotTimeMax = Mathf.Lerp(soldierBehaviourDefinititon.walkShotTimeMax, soldierBehaviourDefinititon2.walkShotTimeMax, GACKNHPFGFM);
		return soldierBehaviourDefinititon3;
	}

	public override BehaviourDefinititon BNOINHIGGLH(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		SoldierBehaviourDefinititon soldierBehaviourDefinititon = (SoldierBehaviourDefinititon)LLGHNHMFCPN;
		SoldierBehaviourDefinititon soldierBehaviourDefinititon2 = (SoldierBehaviourDefinititon)AJCHDECIFJC;
		SoldierBehaviourDefinititon soldierBehaviourDefinititon3 = (SoldierBehaviourDefinititon)LLGHNHMFCPN.JCPMGMGGPPF();
		soldierBehaviourDefinititon3.health = Mathf.Lerp(soldierBehaviourDefinititon.health, soldierBehaviourDefinititon2.health, GACKNHPFGFM);
		soldierBehaviourDefinititon3.probabilityOfRealShot = Mathf.Lerp(soldierBehaviourDefinititon.probabilityOfRealShot, soldierBehaviourDefinititon2.probabilityOfRealShot, GACKNHPFGFM);
		soldierBehaviourDefinititon3.damage = Mathf.Lerp(soldierBehaviourDefinititon.damage, soldierBehaviourDefinititon2.damage, GACKNHPFGFM);
		soldierBehaviourDefinititon3.fireBatchSizeMin = (int)Mathf.Lerp(soldierBehaviourDefinititon.fireBatchSizeMin, soldierBehaviourDefinititon2.fireBatchSizeMin, GACKNHPFGFM);
		soldierBehaviourDefinititon3.fireBatchSizeMax = (int)Mathf.Lerp(soldierBehaviourDefinititon.fireBatchSizeMax, soldierBehaviourDefinititon2.fireBatchSizeMax, GACKNHPFGFM);
		soldierBehaviourDefinititon3.minShootTime = Mathf.Lerp(soldierBehaviourDefinititon.minShootTime, soldierBehaviourDefinititon2.minShootTime, GACKNHPFGFM);
		soldierBehaviourDefinititon3.maxShootTime = Mathf.Lerp(soldierBehaviourDefinititon.maxShootTime, soldierBehaviourDefinititon2.maxShootTime, GACKNHPFGFM);
		soldierBehaviourDefinititon3.walkShotTimeMin = Mathf.Lerp(soldierBehaviourDefinititon.walkShotTimeMin, soldierBehaviourDefinititon2.walkShotTimeMin, GACKNHPFGFM);
		soldierBehaviourDefinititon3.walkShotTimeMax = Mathf.Lerp(soldierBehaviourDefinititon.walkShotTimeMax, soldierBehaviourDefinititon2.walkShotTimeMax, GACKNHPFGFM);
		return soldierBehaviourDefinititon3;
	}

	public virtual void DIFCLHEPNHH()
	{
		health = 929f;
		probabilityOfRealShot = 2f;
		fireBatchSizeMin = 0;
		fireBatchSizeMax = 0;
		minShootTime = 1549f;
		maxShootTime = 1124f;
		damage = 1576f;
		special = 1197f;
		walkShotTimeMin = 32f;
		walkShotTimeMax = 116f;
	}

	public virtual void AKNKCNFFDBK()
	{
		health = 892f;
		probabilityOfRealShot = 375f;
		fireBatchSizeMin = 0;
		fireBatchSizeMax = 1;
		minShootTime = 1870f;
		maxShootTime = 1786f;
		damage = 59f;
		special = 654f;
		walkShotTimeMin = 1685f;
		walkShotTimeMax = 1509f;
	}

	public virtual BehaviourDefinititon NLAKDMKFCEE(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		SoldierBehaviourDefinititon soldierBehaviourDefinititon = (SoldierBehaviourDefinititon)LLGHNHMFCPN;
		SoldierBehaviourDefinititon soldierBehaviourDefinititon2 = (SoldierBehaviourDefinititon)AJCHDECIFJC;
		SoldierBehaviourDefinititon soldierBehaviourDefinititon3 = (SoldierBehaviourDefinititon)LLGHNHMFCPN.MCCHPFINCKH();
		soldierBehaviourDefinititon3.health = Mathf.Lerp(soldierBehaviourDefinititon.health, soldierBehaviourDefinititon2.health, GACKNHPFGFM);
		soldierBehaviourDefinititon3.probabilityOfRealShot = Mathf.Lerp(soldierBehaviourDefinititon.probabilityOfRealShot, soldierBehaviourDefinititon2.probabilityOfRealShot, GACKNHPFGFM);
		soldierBehaviourDefinititon3.damage = Mathf.Lerp(soldierBehaviourDefinititon.damage, soldierBehaviourDefinititon2.damage, GACKNHPFGFM);
		soldierBehaviourDefinititon3.fireBatchSizeMin = (int)Mathf.Lerp(soldierBehaviourDefinititon.fireBatchSizeMin, soldierBehaviourDefinititon2.fireBatchSizeMin, GACKNHPFGFM);
		soldierBehaviourDefinititon3.fireBatchSizeMax = (int)Mathf.Lerp(soldierBehaviourDefinititon.fireBatchSizeMax, soldierBehaviourDefinititon2.fireBatchSizeMax, GACKNHPFGFM);
		soldierBehaviourDefinititon3.minShootTime = Mathf.Lerp(soldierBehaviourDefinititon.minShootTime, soldierBehaviourDefinititon2.minShootTime, GACKNHPFGFM);
		soldierBehaviourDefinititon3.maxShootTime = Mathf.Lerp(soldierBehaviourDefinititon.maxShootTime, soldierBehaviourDefinititon2.maxShootTime, GACKNHPFGFM);
		soldierBehaviourDefinititon3.walkShotTimeMin = Mathf.Lerp(soldierBehaviourDefinititon.walkShotTimeMin, soldierBehaviourDefinititon2.walkShotTimeMin, GACKNHPFGFM);
		soldierBehaviourDefinititon3.walkShotTimeMax = Mathf.Lerp(soldierBehaviourDefinititon.walkShotTimeMax, soldierBehaviourDefinititon2.walkShotTimeMax, GACKNHPFGFM);
		return soldierBehaviourDefinititon3;
	}

	public virtual void ELMAAOEJDAN()
	{
		health = 295f;
		probabilityOfRealShot = 979f;
		fireBatchSizeMin = 1;
		fireBatchSizeMax = 0;
		minShootTime = 376f;
		maxShootTime = 1857f;
		damage = 1175f;
		special = 1580f;
		walkShotTimeMin = 1165f;
		walkShotTimeMax = 617f;
	}

	public virtual BehaviourDefinititon BNCHOEJMPOK(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		SoldierBehaviourDefinititon soldierBehaviourDefinititon = (SoldierBehaviourDefinititon)LLGHNHMFCPN;
		SoldierBehaviourDefinititon soldierBehaviourDefinititon2 = (SoldierBehaviourDefinititon)AJCHDECIFJC;
		SoldierBehaviourDefinititon soldierBehaviourDefinititon3 = (SoldierBehaviourDefinititon)LLGHNHMFCPN.HIGKMHJIFJF();
		soldierBehaviourDefinititon3.health = Mathf.Lerp(soldierBehaviourDefinititon.health, soldierBehaviourDefinititon2.health, GACKNHPFGFM);
		soldierBehaviourDefinititon3.probabilityOfRealShot = Mathf.Lerp(soldierBehaviourDefinititon.probabilityOfRealShot, soldierBehaviourDefinititon2.probabilityOfRealShot, GACKNHPFGFM);
		soldierBehaviourDefinititon3.damage = Mathf.Lerp(soldierBehaviourDefinititon.damage, soldierBehaviourDefinititon2.damage, GACKNHPFGFM);
		soldierBehaviourDefinititon3.fireBatchSizeMin = (int)Mathf.Lerp(soldierBehaviourDefinititon.fireBatchSizeMin, soldierBehaviourDefinititon2.fireBatchSizeMin, GACKNHPFGFM);
		soldierBehaviourDefinititon3.fireBatchSizeMax = (int)Mathf.Lerp(soldierBehaviourDefinititon.fireBatchSizeMax, soldierBehaviourDefinititon2.fireBatchSizeMax, GACKNHPFGFM);
		soldierBehaviourDefinititon3.minShootTime = Mathf.Lerp(soldierBehaviourDefinititon.minShootTime, soldierBehaviourDefinititon2.minShootTime, GACKNHPFGFM);
		soldierBehaviourDefinititon3.maxShootTime = Mathf.Lerp(soldierBehaviourDefinititon.maxShootTime, soldierBehaviourDefinititon2.maxShootTime, GACKNHPFGFM);
		soldierBehaviourDefinititon3.walkShotTimeMin = Mathf.Lerp(soldierBehaviourDefinititon.walkShotTimeMin, soldierBehaviourDefinititon2.walkShotTimeMin, GACKNHPFGFM);
		soldierBehaviourDefinititon3.walkShotTimeMax = Mathf.Lerp(soldierBehaviourDefinititon.walkShotTimeMax, soldierBehaviourDefinititon2.walkShotTimeMax, GACKNHPFGFM);
		return soldierBehaviourDefinititon3;
	}

	public override void KFLADKOLPCM()
	{
		health = 0f;
		probabilityOfRealShot = 0f;
		fireBatchSizeMin = 0;
		fireBatchSizeMax = 0;
		minShootTime = 0f;
		maxShootTime = 0f;
		damage = 0f;
		special = 0f;
		walkShotTimeMin = 0f;
		walkShotTimeMax = 0f;
	}

	public virtual BehaviourDefinititon MONDPJEGDIF(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		SoldierBehaviourDefinititon soldierBehaviourDefinititon = (SoldierBehaviourDefinititon)LLGHNHMFCPN;
		SoldierBehaviourDefinititon soldierBehaviourDefinititon2 = (SoldierBehaviourDefinititon)AJCHDECIFJC;
		SoldierBehaviourDefinititon soldierBehaviourDefinititon3 = (SoldierBehaviourDefinititon)LLGHNHMFCPN.NOBGFCMPPKP();
		soldierBehaviourDefinititon3.health = Mathf.Lerp(soldierBehaviourDefinititon.health, soldierBehaviourDefinititon2.health, GACKNHPFGFM);
		soldierBehaviourDefinititon3.probabilityOfRealShot = Mathf.Lerp(soldierBehaviourDefinititon.probabilityOfRealShot, soldierBehaviourDefinititon2.probabilityOfRealShot, GACKNHPFGFM);
		soldierBehaviourDefinititon3.damage = Mathf.Lerp(soldierBehaviourDefinititon.damage, soldierBehaviourDefinititon2.damage, GACKNHPFGFM);
		soldierBehaviourDefinititon3.fireBatchSizeMin = (int)Mathf.Lerp(soldierBehaviourDefinititon.fireBatchSizeMin, soldierBehaviourDefinititon2.fireBatchSizeMin, GACKNHPFGFM);
		soldierBehaviourDefinititon3.fireBatchSizeMax = (int)Mathf.Lerp(soldierBehaviourDefinititon.fireBatchSizeMax, soldierBehaviourDefinititon2.fireBatchSizeMax, GACKNHPFGFM);
		soldierBehaviourDefinititon3.minShootTime = Mathf.Lerp(soldierBehaviourDefinititon.minShootTime, soldierBehaviourDefinititon2.minShootTime, GACKNHPFGFM);
		soldierBehaviourDefinititon3.maxShootTime = Mathf.Lerp(soldierBehaviourDefinititon.maxShootTime, soldierBehaviourDefinititon2.maxShootTime, GACKNHPFGFM);
		soldierBehaviourDefinititon3.walkShotTimeMin = Mathf.Lerp(soldierBehaviourDefinititon.walkShotTimeMin, soldierBehaviourDefinititon2.walkShotTimeMin, GACKNHPFGFM);
		soldierBehaviourDefinititon3.walkShotTimeMax = Mathf.Lerp(soldierBehaviourDefinititon.walkShotTimeMax, soldierBehaviourDefinititon2.walkShotTimeMax, GACKNHPFGFM);
		return soldierBehaviourDefinititon3;
	}

	public virtual void KJOGKCHJODC()
	{
		health = 1471f;
		probabilityOfRealShot = 865f;
		fireBatchSizeMin = 0;
		fireBatchSizeMax = 1;
		minShootTime = 524f;
		maxShootTime = 254f;
		damage = 559f;
		special = 579f;
		walkShotTimeMin = 752f;
		walkShotTimeMax = 1021f;
	}

	public virtual BehaviourDefinititon NCLKBGAIDKO(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		SoldierBehaviourDefinititon soldierBehaviourDefinititon = (SoldierBehaviourDefinititon)LLGHNHMFCPN;
		SoldierBehaviourDefinititon soldierBehaviourDefinititon2 = (SoldierBehaviourDefinititon)AJCHDECIFJC;
		SoldierBehaviourDefinititon soldierBehaviourDefinititon3 = (SoldierBehaviourDefinititon)LLGHNHMFCPN.JCPMGMGGPPF();
		soldierBehaviourDefinititon3.health = Mathf.Lerp(soldierBehaviourDefinititon.health, soldierBehaviourDefinititon2.health, GACKNHPFGFM);
		soldierBehaviourDefinititon3.probabilityOfRealShot = Mathf.Lerp(soldierBehaviourDefinititon.probabilityOfRealShot, soldierBehaviourDefinititon2.probabilityOfRealShot, GACKNHPFGFM);
		soldierBehaviourDefinititon3.damage = Mathf.Lerp(soldierBehaviourDefinititon.damage, soldierBehaviourDefinititon2.damage, GACKNHPFGFM);
		soldierBehaviourDefinititon3.fireBatchSizeMin = (int)Mathf.Lerp(soldierBehaviourDefinititon.fireBatchSizeMin, soldierBehaviourDefinititon2.fireBatchSizeMin, GACKNHPFGFM);
		soldierBehaviourDefinititon3.fireBatchSizeMax = (int)Mathf.Lerp(soldierBehaviourDefinititon.fireBatchSizeMax, soldierBehaviourDefinititon2.fireBatchSizeMax, GACKNHPFGFM);
		soldierBehaviourDefinititon3.minShootTime = Mathf.Lerp(soldierBehaviourDefinititon.minShootTime, soldierBehaviourDefinititon2.minShootTime, GACKNHPFGFM);
		soldierBehaviourDefinititon3.maxShootTime = Mathf.Lerp(soldierBehaviourDefinititon.maxShootTime, soldierBehaviourDefinititon2.maxShootTime, GACKNHPFGFM);
		soldierBehaviourDefinititon3.walkShotTimeMin = Mathf.Lerp(soldierBehaviourDefinititon.walkShotTimeMin, soldierBehaviourDefinititon2.walkShotTimeMin, GACKNHPFGFM);
		soldierBehaviourDefinititon3.walkShotTimeMax = Mathf.Lerp(soldierBehaviourDefinititon.walkShotTimeMax, soldierBehaviourDefinititon2.walkShotTimeMax, GACKNHPFGFM);
		return soldierBehaviourDefinititon3;
	}

	public virtual void IMAHMPAIDJL()
	{
		health = 1452f;
		probabilityOfRealShot = 1186f;
		fireBatchSizeMin = 0;
		fireBatchSizeMax = 0;
		minShootTime = 1246f;
		maxShootTime = 1098f;
		damage = 1086f;
		special = 1950f;
		walkShotTimeMin = 796f;
		walkShotTimeMax = 1483f;
	}

	public virtual void IDFMFMDHHAF()
	{
		health = 416f;
		probabilityOfRealShot = 1450f;
		fireBatchSizeMin = 0;
		fireBatchSizeMax = 1;
		minShootTime = 1214f;
		maxShootTime = 1758f;
		damage = 1027f;
		special = 277f;
		walkShotTimeMin = 1258f;
		walkShotTimeMax = 389f;
	}

	public virtual BehaviourDefinititon LDMMAGFJKDN(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		SoldierBehaviourDefinititon soldierBehaviourDefinititon = (SoldierBehaviourDefinititon)LLGHNHMFCPN;
		SoldierBehaviourDefinititon soldierBehaviourDefinititon2 = (SoldierBehaviourDefinititon)AJCHDECIFJC;
		SoldierBehaviourDefinititon soldierBehaviourDefinititon3 = (SoldierBehaviourDefinititon)LLGHNHMFCPN.JCPMGMGGPPF();
		soldierBehaviourDefinititon3.health = Mathf.Lerp(soldierBehaviourDefinititon.health, soldierBehaviourDefinititon2.health, GACKNHPFGFM);
		soldierBehaviourDefinititon3.probabilityOfRealShot = Mathf.Lerp(soldierBehaviourDefinititon.probabilityOfRealShot, soldierBehaviourDefinititon2.probabilityOfRealShot, GACKNHPFGFM);
		soldierBehaviourDefinititon3.damage = Mathf.Lerp(soldierBehaviourDefinititon.damage, soldierBehaviourDefinititon2.damage, GACKNHPFGFM);
		soldierBehaviourDefinititon3.fireBatchSizeMin = (int)Mathf.Lerp(soldierBehaviourDefinititon.fireBatchSizeMin, soldierBehaviourDefinititon2.fireBatchSizeMin, GACKNHPFGFM);
		soldierBehaviourDefinititon3.fireBatchSizeMax = (int)Mathf.Lerp(soldierBehaviourDefinititon.fireBatchSizeMax, soldierBehaviourDefinititon2.fireBatchSizeMax, GACKNHPFGFM);
		soldierBehaviourDefinititon3.minShootTime = Mathf.Lerp(soldierBehaviourDefinititon.minShootTime, soldierBehaviourDefinititon2.minShootTime, GACKNHPFGFM);
		soldierBehaviourDefinititon3.maxShootTime = Mathf.Lerp(soldierBehaviourDefinititon.maxShootTime, soldierBehaviourDefinititon2.maxShootTime, GACKNHPFGFM);
		soldierBehaviourDefinititon3.walkShotTimeMin = Mathf.Lerp(soldierBehaviourDefinititon.walkShotTimeMin, soldierBehaviourDefinititon2.walkShotTimeMin, GACKNHPFGFM);
		soldierBehaviourDefinititon3.walkShotTimeMax = Mathf.Lerp(soldierBehaviourDefinititon.walkShotTimeMax, soldierBehaviourDefinititon2.walkShotTimeMax, GACKNHPFGFM);
		return soldierBehaviourDefinititon3;
	}

	public virtual void FIMKEDFEHML()
	{
		health = 755f;
		probabilityOfRealShot = 1083f;
		fireBatchSizeMin = 0;
		fireBatchSizeMax = 1;
		minShootTime = 768f;
		maxShootTime = 1117f;
		damage = 1512f;
		special = 904f;
		walkShotTimeMin = 96f;
		walkShotTimeMax = 892f;
	}

	public virtual void OBEEJDNBBLP()
	{
		health = 1786f;
		probabilityOfRealShot = 1042f;
		fireBatchSizeMin = 1;
		fireBatchSizeMax = 0;
		minShootTime = 1993f;
		maxShootTime = 1250f;
		damage = 1786f;
		special = 1740f;
		walkShotTimeMin = 839f;
		walkShotTimeMax = 253f;
	}

	public virtual BehaviourDefinititon FKOLJINEJCG(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		SoldierBehaviourDefinititon soldierBehaviourDefinititon = (SoldierBehaviourDefinititon)LLGHNHMFCPN;
		SoldierBehaviourDefinititon soldierBehaviourDefinititon2 = (SoldierBehaviourDefinititon)AJCHDECIFJC;
		SoldierBehaviourDefinititon soldierBehaviourDefinititon3 = (SoldierBehaviourDefinititon)LLGHNHMFCPN.ABNPNLMHNKK();
		soldierBehaviourDefinititon3.health = Mathf.Lerp(soldierBehaviourDefinititon.health, soldierBehaviourDefinititon2.health, GACKNHPFGFM);
		soldierBehaviourDefinititon3.probabilityOfRealShot = Mathf.Lerp(soldierBehaviourDefinititon.probabilityOfRealShot, soldierBehaviourDefinititon2.probabilityOfRealShot, GACKNHPFGFM);
		soldierBehaviourDefinititon3.damage = Mathf.Lerp(soldierBehaviourDefinititon.damage, soldierBehaviourDefinititon2.damage, GACKNHPFGFM);
		soldierBehaviourDefinititon3.fireBatchSizeMin = (int)Mathf.Lerp(soldierBehaviourDefinititon.fireBatchSizeMin, soldierBehaviourDefinititon2.fireBatchSizeMin, GACKNHPFGFM);
		soldierBehaviourDefinititon3.fireBatchSizeMax = (int)Mathf.Lerp(soldierBehaviourDefinititon.fireBatchSizeMax, soldierBehaviourDefinititon2.fireBatchSizeMax, GACKNHPFGFM);
		soldierBehaviourDefinititon3.minShootTime = Mathf.Lerp(soldierBehaviourDefinititon.minShootTime, soldierBehaviourDefinititon2.minShootTime, GACKNHPFGFM);
		soldierBehaviourDefinititon3.maxShootTime = Mathf.Lerp(soldierBehaviourDefinititon.maxShootTime, soldierBehaviourDefinititon2.maxShootTime, GACKNHPFGFM);
		soldierBehaviourDefinititon3.walkShotTimeMin = Mathf.Lerp(soldierBehaviourDefinititon.walkShotTimeMin, soldierBehaviourDefinititon2.walkShotTimeMin, GACKNHPFGFM);
		soldierBehaviourDefinititon3.walkShotTimeMax = Mathf.Lerp(soldierBehaviourDefinititon.walkShotTimeMax, soldierBehaviourDefinititon2.walkShotTimeMax, GACKNHPFGFM);
		return soldierBehaviourDefinititon3;
	}

	public virtual void EAEEEKCAOIN()
	{
		health = 1521f;
		probabilityOfRealShot = 1691f;
		fireBatchSizeMin = 1;
		fireBatchSizeMax = 0;
		minShootTime = 1273f;
		maxShootTime = 759f;
		damage = 933f;
		special = 1034f;
		walkShotTimeMin = 1173f;
		walkShotTimeMax = 422f;
	}

	public virtual BehaviourDefinititon JHNHOFKAIII(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		SoldierBehaviourDefinititon soldierBehaviourDefinititon = (SoldierBehaviourDefinititon)LLGHNHMFCPN;
		SoldierBehaviourDefinititon soldierBehaviourDefinititon2 = (SoldierBehaviourDefinititon)AJCHDECIFJC;
		SoldierBehaviourDefinititon soldierBehaviourDefinititon3 = (SoldierBehaviourDefinititon)LLGHNHMFCPN.ABNPNLMHNKK();
		soldierBehaviourDefinititon3.health = Mathf.Lerp(soldierBehaviourDefinititon.health, soldierBehaviourDefinititon2.health, GACKNHPFGFM);
		soldierBehaviourDefinititon3.probabilityOfRealShot = Mathf.Lerp(soldierBehaviourDefinititon.probabilityOfRealShot, soldierBehaviourDefinititon2.probabilityOfRealShot, GACKNHPFGFM);
		soldierBehaviourDefinititon3.damage = Mathf.Lerp(soldierBehaviourDefinititon.damage, soldierBehaviourDefinititon2.damage, GACKNHPFGFM);
		soldierBehaviourDefinititon3.fireBatchSizeMin = (int)Mathf.Lerp(soldierBehaviourDefinititon.fireBatchSizeMin, soldierBehaviourDefinititon2.fireBatchSizeMin, GACKNHPFGFM);
		soldierBehaviourDefinititon3.fireBatchSizeMax = (int)Mathf.Lerp(soldierBehaviourDefinititon.fireBatchSizeMax, soldierBehaviourDefinititon2.fireBatchSizeMax, GACKNHPFGFM);
		soldierBehaviourDefinititon3.minShootTime = Mathf.Lerp(soldierBehaviourDefinititon.minShootTime, soldierBehaviourDefinititon2.minShootTime, GACKNHPFGFM);
		soldierBehaviourDefinititon3.maxShootTime = Mathf.Lerp(soldierBehaviourDefinititon.maxShootTime, soldierBehaviourDefinititon2.maxShootTime, GACKNHPFGFM);
		soldierBehaviourDefinititon3.walkShotTimeMin = Mathf.Lerp(soldierBehaviourDefinititon.walkShotTimeMin, soldierBehaviourDefinititon2.walkShotTimeMin, GACKNHPFGFM);
		soldierBehaviourDefinititon3.walkShotTimeMax = Mathf.Lerp(soldierBehaviourDefinititon.walkShotTimeMax, soldierBehaviourDefinititon2.walkShotTimeMax, GACKNHPFGFM);
		return soldierBehaviourDefinititon3;
	}

	public override BehaviourDefinititon CNJJLEJIMHG(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		SoldierBehaviourDefinititon soldierBehaviourDefinititon = (SoldierBehaviourDefinititon)LLGHNHMFCPN;
		SoldierBehaviourDefinititon soldierBehaviourDefinititon2 = (SoldierBehaviourDefinititon)AJCHDECIFJC;
		SoldierBehaviourDefinititon soldierBehaviourDefinititon3 = (SoldierBehaviourDefinititon)LLGHNHMFCPN.AFBBNOFJJCP();
		soldierBehaviourDefinititon3.health = Mathf.Lerp(soldierBehaviourDefinititon.health, soldierBehaviourDefinititon2.health, GACKNHPFGFM);
		soldierBehaviourDefinititon3.probabilityOfRealShot = Mathf.Lerp(soldierBehaviourDefinititon.probabilityOfRealShot, soldierBehaviourDefinititon2.probabilityOfRealShot, GACKNHPFGFM);
		soldierBehaviourDefinititon3.damage = Mathf.Lerp(soldierBehaviourDefinititon.damage, soldierBehaviourDefinititon2.damage, GACKNHPFGFM);
		soldierBehaviourDefinititon3.fireBatchSizeMin = (int)Mathf.Lerp(soldierBehaviourDefinititon.fireBatchSizeMin, soldierBehaviourDefinititon2.fireBatchSizeMin, GACKNHPFGFM);
		soldierBehaviourDefinititon3.fireBatchSizeMax = (int)Mathf.Lerp(soldierBehaviourDefinititon.fireBatchSizeMax, soldierBehaviourDefinititon2.fireBatchSizeMax, GACKNHPFGFM);
		soldierBehaviourDefinititon3.minShootTime = Mathf.Lerp(soldierBehaviourDefinititon.minShootTime, soldierBehaviourDefinititon2.minShootTime, GACKNHPFGFM);
		soldierBehaviourDefinititon3.maxShootTime = Mathf.Lerp(soldierBehaviourDefinititon.maxShootTime, soldierBehaviourDefinititon2.maxShootTime, GACKNHPFGFM);
		soldierBehaviourDefinititon3.walkShotTimeMin = Mathf.Lerp(soldierBehaviourDefinititon.walkShotTimeMin, soldierBehaviourDefinititon2.walkShotTimeMin, GACKNHPFGFM);
		soldierBehaviourDefinititon3.walkShotTimeMax = Mathf.Lerp(soldierBehaviourDefinititon.walkShotTimeMax, soldierBehaviourDefinititon2.walkShotTimeMax, GACKNHPFGFM);
		return soldierBehaviourDefinititon3;
	}

	public virtual void IIEBAPPGDPH()
	{
		health = 655f;
		probabilityOfRealShot = 1589f;
		fireBatchSizeMin = 1;
		fireBatchSizeMax = 0;
		minShootTime = 1270f;
		maxShootTime = 954f;
		damage = 1056f;
		special = 240f;
		walkShotTimeMin = 598f;
		walkShotTimeMax = 1983f;
	}

	public virtual BehaviourDefinititon KOLNONBJGAJ(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		SoldierBehaviourDefinititon soldierBehaviourDefinititon = (SoldierBehaviourDefinititon)LLGHNHMFCPN;
		SoldierBehaviourDefinititon soldierBehaviourDefinititon2 = (SoldierBehaviourDefinititon)AJCHDECIFJC;
		SoldierBehaviourDefinititon soldierBehaviourDefinititon3 = (SoldierBehaviourDefinititon)LLGHNHMFCPN.AFBBNOFJJCP();
		soldierBehaviourDefinititon3.health = Mathf.Lerp(soldierBehaviourDefinititon.health, soldierBehaviourDefinititon2.health, GACKNHPFGFM);
		soldierBehaviourDefinititon3.probabilityOfRealShot = Mathf.Lerp(soldierBehaviourDefinititon.probabilityOfRealShot, soldierBehaviourDefinititon2.probabilityOfRealShot, GACKNHPFGFM);
		soldierBehaviourDefinititon3.damage = Mathf.Lerp(soldierBehaviourDefinititon.damage, soldierBehaviourDefinititon2.damage, GACKNHPFGFM);
		soldierBehaviourDefinititon3.fireBatchSizeMin = (int)Mathf.Lerp(soldierBehaviourDefinititon.fireBatchSizeMin, soldierBehaviourDefinititon2.fireBatchSizeMin, GACKNHPFGFM);
		soldierBehaviourDefinititon3.fireBatchSizeMax = (int)Mathf.Lerp(soldierBehaviourDefinititon.fireBatchSizeMax, soldierBehaviourDefinititon2.fireBatchSizeMax, GACKNHPFGFM);
		soldierBehaviourDefinititon3.minShootTime = Mathf.Lerp(soldierBehaviourDefinititon.minShootTime, soldierBehaviourDefinititon2.minShootTime, GACKNHPFGFM);
		soldierBehaviourDefinititon3.maxShootTime = Mathf.Lerp(soldierBehaviourDefinititon.maxShootTime, soldierBehaviourDefinititon2.maxShootTime, GACKNHPFGFM);
		soldierBehaviourDefinititon3.walkShotTimeMin = Mathf.Lerp(soldierBehaviourDefinititon.walkShotTimeMin, soldierBehaviourDefinititon2.walkShotTimeMin, GACKNHPFGFM);
		soldierBehaviourDefinititon3.walkShotTimeMax = Mathf.Lerp(soldierBehaviourDefinititon.walkShotTimeMax, soldierBehaviourDefinititon2.walkShotTimeMax, GACKNHPFGFM);
		return soldierBehaviourDefinititon3;
	}

	public virtual BehaviourDefinititon KKCHFGFBABB(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		SoldierBehaviourDefinititon soldierBehaviourDefinititon = (SoldierBehaviourDefinititon)LLGHNHMFCPN;
		SoldierBehaviourDefinititon soldierBehaviourDefinititon2 = (SoldierBehaviourDefinititon)AJCHDECIFJC;
		SoldierBehaviourDefinititon soldierBehaviourDefinititon3 = (SoldierBehaviourDefinititon)LLGHNHMFCPN.ABNPNLMHNKK();
		soldierBehaviourDefinititon3.health = Mathf.Lerp(soldierBehaviourDefinititon.health, soldierBehaviourDefinititon2.health, GACKNHPFGFM);
		soldierBehaviourDefinititon3.probabilityOfRealShot = Mathf.Lerp(soldierBehaviourDefinititon.probabilityOfRealShot, soldierBehaviourDefinititon2.probabilityOfRealShot, GACKNHPFGFM);
		soldierBehaviourDefinititon3.damage = Mathf.Lerp(soldierBehaviourDefinititon.damage, soldierBehaviourDefinititon2.damage, GACKNHPFGFM);
		soldierBehaviourDefinititon3.fireBatchSizeMin = (int)Mathf.Lerp(soldierBehaviourDefinititon.fireBatchSizeMin, soldierBehaviourDefinititon2.fireBatchSizeMin, GACKNHPFGFM);
		soldierBehaviourDefinititon3.fireBatchSizeMax = (int)Mathf.Lerp(soldierBehaviourDefinititon.fireBatchSizeMax, soldierBehaviourDefinititon2.fireBatchSizeMax, GACKNHPFGFM);
		soldierBehaviourDefinititon3.minShootTime = Mathf.Lerp(soldierBehaviourDefinititon.minShootTime, soldierBehaviourDefinititon2.minShootTime, GACKNHPFGFM);
		soldierBehaviourDefinititon3.maxShootTime = Mathf.Lerp(soldierBehaviourDefinititon.maxShootTime, soldierBehaviourDefinititon2.maxShootTime, GACKNHPFGFM);
		soldierBehaviourDefinititon3.walkShotTimeMin = Mathf.Lerp(soldierBehaviourDefinititon.walkShotTimeMin, soldierBehaviourDefinititon2.walkShotTimeMin, GACKNHPFGFM);
		soldierBehaviourDefinititon3.walkShotTimeMax = Mathf.Lerp(soldierBehaviourDefinititon.walkShotTimeMax, soldierBehaviourDefinititon2.walkShotTimeMax, GACKNHPFGFM);
		return soldierBehaviourDefinititon3;
	}

	public virtual void ANEPLHCBIOD()
	{
		health = 1096f;
		probabilityOfRealShot = 969f;
		fireBatchSizeMin = 0;
		fireBatchSizeMax = 0;
		minShootTime = 1450f;
		maxShootTime = 1168f;
		damage = 1799f;
		special = 404f;
		walkShotTimeMin = 688f;
		walkShotTimeMax = 792f;
	}

	public virtual void JMMGAKKHEIJ()
	{
		health = 366f;
		probabilityOfRealShot = 612f;
		fireBatchSizeMin = 1;
		fireBatchSizeMax = 1;
		minShootTime = 1340f;
		maxShootTime = 1024f;
		damage = 285f;
		special = 992f;
		walkShotTimeMin = 102f;
		walkShotTimeMax = 208f;
	}

	public override BehaviourDefinititon OCCIPOGAICC(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		SoldierBehaviourDefinititon soldierBehaviourDefinititon = (SoldierBehaviourDefinititon)LLGHNHMFCPN;
		SoldierBehaviourDefinititon soldierBehaviourDefinititon2 = (SoldierBehaviourDefinititon)AJCHDECIFJC;
		SoldierBehaviourDefinititon soldierBehaviourDefinititon3 = (SoldierBehaviourDefinititon)LLGHNHMFCPN.ABNPNLMHNKK();
		soldierBehaviourDefinititon3.health = Mathf.Lerp(soldierBehaviourDefinititon.health, soldierBehaviourDefinititon2.health, GACKNHPFGFM);
		soldierBehaviourDefinititon3.probabilityOfRealShot = Mathf.Lerp(soldierBehaviourDefinititon.probabilityOfRealShot, soldierBehaviourDefinititon2.probabilityOfRealShot, GACKNHPFGFM);
		soldierBehaviourDefinititon3.damage = Mathf.Lerp(soldierBehaviourDefinititon.damage, soldierBehaviourDefinititon2.damage, GACKNHPFGFM);
		soldierBehaviourDefinititon3.fireBatchSizeMin = (int)Mathf.Lerp(soldierBehaviourDefinititon.fireBatchSizeMin, soldierBehaviourDefinititon2.fireBatchSizeMin, GACKNHPFGFM);
		soldierBehaviourDefinititon3.fireBatchSizeMax = (int)Mathf.Lerp(soldierBehaviourDefinititon.fireBatchSizeMax, soldierBehaviourDefinititon2.fireBatchSizeMax, GACKNHPFGFM);
		soldierBehaviourDefinititon3.minShootTime = Mathf.Lerp(soldierBehaviourDefinititon.minShootTime, soldierBehaviourDefinititon2.minShootTime, GACKNHPFGFM);
		soldierBehaviourDefinititon3.maxShootTime = Mathf.Lerp(soldierBehaviourDefinititon.maxShootTime, soldierBehaviourDefinititon2.maxShootTime, GACKNHPFGFM);
		soldierBehaviourDefinititon3.walkShotTimeMin = Mathf.Lerp(soldierBehaviourDefinititon.walkShotTimeMin, soldierBehaviourDefinititon2.walkShotTimeMin, GACKNHPFGFM);
		soldierBehaviourDefinititon3.walkShotTimeMax = Mathf.Lerp(soldierBehaviourDefinititon.walkShotTimeMax, soldierBehaviourDefinititon2.walkShotTimeMax, GACKNHPFGFM);
		return soldierBehaviourDefinititon3;
	}
}
