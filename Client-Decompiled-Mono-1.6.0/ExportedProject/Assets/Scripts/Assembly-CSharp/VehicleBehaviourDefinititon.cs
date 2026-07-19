using System;
using UnityEngine;

[Serializable]
public class VehicleBehaviourDefinititon : BehaviourDefinititon
{
	public float minShootTime;

	public float maxShootTime;

	public int fireBatchSizeMin;

	public int fireBatchSizeMax;

	public float special;

	public virtual void EAEEEKCAOIN()
	{
		health = 1534f;
		damage = 1516f;
		minShootTime = 206f;
		maxShootTime = 578f;
		probabilityOfRealShot = 573f;
		fireBatchSizeMin = 1;
		fireBatchSizeMax = 0;
		special = 286f;
	}

	public virtual void IDJNOCBPALG()
	{
		health = 1327f;
		damage = 442f;
		minShootTime = 833f;
		maxShootTime = 469f;
		probabilityOfRealShot = 1652f;
		fireBatchSizeMin = 0;
		fireBatchSizeMax = 1;
		special = 1752f;
	}

	public virtual BehaviourDefinititon BADMBJMHDPJ(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon = (VehicleBehaviourDefinititon)LLGHNHMFCPN;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon2 = (VehicleBehaviourDefinititon)AJCHDECIFJC;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon3 = (VehicleBehaviourDefinititon)LLGHNHMFCPN.MCCHPFINCKH();
		vehicleBehaviourDefinititon3.health = Mathf.Lerp(vehicleBehaviourDefinititon.health, vehicleBehaviourDefinititon2.health, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.probabilityOfRealShot = Mathf.Lerp(vehicleBehaviourDefinititon.probabilityOfRealShot, vehicleBehaviourDefinititon2.probabilityOfRealShot, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.damage = Mathf.Lerp(vehicleBehaviourDefinititon.damage, vehicleBehaviourDefinititon2.damage, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMin = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMin, vehicleBehaviourDefinititon2.fireBatchSizeMin, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMax = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMax, vehicleBehaviourDefinititon2.fireBatchSizeMax, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.minShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.minShootTime, vehicleBehaviourDefinititon2.minShootTime, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.maxShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.maxShootTime, vehicleBehaviourDefinititon2.maxShootTime, GACKNHPFGFM);
		return vehicleBehaviourDefinititon3;
	}

	public virtual BehaviourDefinititon KOLNONBJGAJ(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon = (VehicleBehaviourDefinititon)LLGHNHMFCPN;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon2 = (VehicleBehaviourDefinititon)AJCHDECIFJC;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon3 = (VehicleBehaviourDefinititon)LLGHNHMFCPN.HIGKMHJIFJF();
		vehicleBehaviourDefinititon3.health = Mathf.Lerp(vehicleBehaviourDefinititon.health, vehicleBehaviourDefinititon2.health, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.probabilityOfRealShot = Mathf.Lerp(vehicleBehaviourDefinititon.probabilityOfRealShot, vehicleBehaviourDefinititon2.probabilityOfRealShot, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.damage = Mathf.Lerp(vehicleBehaviourDefinititon.damage, vehicleBehaviourDefinititon2.damage, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMin = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMin, vehicleBehaviourDefinititon2.fireBatchSizeMin, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMax = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMax, vehicleBehaviourDefinititon2.fireBatchSizeMax, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.minShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.minShootTime, vehicleBehaviourDefinititon2.minShootTime, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.maxShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.maxShootTime, vehicleBehaviourDefinititon2.maxShootTime, GACKNHPFGFM);
		return vehicleBehaviourDefinititon3;
	}

	public virtual BehaviourDefinititon NMILPKNGEAD(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon = (VehicleBehaviourDefinititon)LLGHNHMFCPN;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon2 = (VehicleBehaviourDefinititon)AJCHDECIFJC;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon3 = (VehicleBehaviourDefinititon)LLGHNHMFCPN.ABNPNLMHNKK();
		vehicleBehaviourDefinititon3.health = Mathf.Lerp(vehicleBehaviourDefinititon.health, vehicleBehaviourDefinititon2.health, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.probabilityOfRealShot = Mathf.Lerp(vehicleBehaviourDefinititon.probabilityOfRealShot, vehicleBehaviourDefinititon2.probabilityOfRealShot, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.damage = Mathf.Lerp(vehicleBehaviourDefinititon.damage, vehicleBehaviourDefinititon2.damage, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMin = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMin, vehicleBehaviourDefinititon2.fireBatchSizeMin, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMax = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMax, vehicleBehaviourDefinititon2.fireBatchSizeMax, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.minShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.minShootTime, vehicleBehaviourDefinititon2.minShootTime, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.maxShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.maxShootTime, vehicleBehaviourDefinititon2.maxShootTime, GACKNHPFGFM);
		return vehicleBehaviourDefinititon3;
	}

	public virtual void EKLCHIEMDBP()
	{
		health = 1126f;
		damage = 491f;
		minShootTime = 179f;
		maxShootTime = 854f;
		probabilityOfRealShot = 1027f;
		fireBatchSizeMin = 0;
		fireBatchSizeMax = 1;
		special = 1181f;
	}

	public virtual void FPDGMNFIHIL()
	{
		health = 375f;
		damage = 1923f;
		minShootTime = 1165f;
		maxShootTime = 1996f;
		probabilityOfRealShot = 946f;
		fireBatchSizeMin = 0;
		fireBatchSizeMax = 0;
		special = 107f;
	}

	public virtual void LFIIJFJHBDH()
	{
		health = 1656f;
		damage = 230f;
		minShootTime = 554f;
		maxShootTime = 1137f;
		probabilityOfRealShot = 1445f;
		fireBatchSizeMin = 0;
		fireBatchSizeMax = 0;
		special = 1430f;
	}

	public virtual BehaviourDefinititon AFHECGBAKDG(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon = (VehicleBehaviourDefinititon)LLGHNHMFCPN;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon2 = (VehicleBehaviourDefinititon)AJCHDECIFJC;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon3 = (VehicleBehaviourDefinititon)LLGHNHMFCPN.JCPMGMGGPPF();
		vehicleBehaviourDefinititon3.health = Mathf.Lerp(vehicleBehaviourDefinititon.health, vehicleBehaviourDefinititon2.health, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.probabilityOfRealShot = Mathf.Lerp(vehicleBehaviourDefinititon.probabilityOfRealShot, vehicleBehaviourDefinititon2.probabilityOfRealShot, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.damage = Mathf.Lerp(vehicleBehaviourDefinititon.damage, vehicleBehaviourDefinititon2.damage, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMin = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMin, vehicleBehaviourDefinititon2.fireBatchSizeMin, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMax = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMax, vehicleBehaviourDefinititon2.fireBatchSizeMax, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.minShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.minShootTime, vehicleBehaviourDefinititon2.minShootTime, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.maxShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.maxShootTime, vehicleBehaviourDefinititon2.maxShootTime, GACKNHPFGFM);
		return vehicleBehaviourDefinititon3;
	}

	public override BehaviourDefinititon GJDCGFJOPLI(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon = (VehicleBehaviourDefinititon)LLGHNHMFCPN;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon2 = (VehicleBehaviourDefinititon)AJCHDECIFJC;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon3 = (VehicleBehaviourDefinititon)LLGHNHMFCPN.PONPCFJHNOM();
		vehicleBehaviourDefinititon3.health = Mathf.Lerp(vehicleBehaviourDefinititon.health, vehicleBehaviourDefinititon2.health, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.probabilityOfRealShot = Mathf.Lerp(vehicleBehaviourDefinititon.probabilityOfRealShot, vehicleBehaviourDefinititon2.probabilityOfRealShot, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.damage = Mathf.Lerp(vehicleBehaviourDefinititon.damage, vehicleBehaviourDefinititon2.damage, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMin = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMin, vehicleBehaviourDefinititon2.fireBatchSizeMin, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMax = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMax, vehicleBehaviourDefinititon2.fireBatchSizeMax, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.minShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.minShootTime, vehicleBehaviourDefinititon2.minShootTime, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.maxShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.maxShootTime, vehicleBehaviourDefinititon2.maxShootTime, GACKNHPFGFM);
		return vehicleBehaviourDefinititon3;
	}

	public virtual BehaviourDefinititon GAJJIEPGECN(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon = (VehicleBehaviourDefinititon)LLGHNHMFCPN;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon2 = (VehicleBehaviourDefinititon)AJCHDECIFJC;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon3 = (VehicleBehaviourDefinititon)LLGHNHMFCPN.JCPMGMGGPPF();
		vehicleBehaviourDefinititon3.health = Mathf.Lerp(vehicleBehaviourDefinititon.health, vehicleBehaviourDefinititon2.health, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.probabilityOfRealShot = Mathf.Lerp(vehicleBehaviourDefinititon.probabilityOfRealShot, vehicleBehaviourDefinititon2.probabilityOfRealShot, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.damage = Mathf.Lerp(vehicleBehaviourDefinititon.damage, vehicleBehaviourDefinititon2.damage, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMin = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMin, vehicleBehaviourDefinititon2.fireBatchSizeMin, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMax = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMax, vehicleBehaviourDefinititon2.fireBatchSizeMax, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.minShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.minShootTime, vehicleBehaviourDefinititon2.minShootTime, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.maxShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.maxShootTime, vehicleBehaviourDefinititon2.maxShootTime, GACKNHPFGFM);
		return vehicleBehaviourDefinititon3;
	}

	public virtual void DOLDGOGFJOI()
	{
		health = 655f;
		damage = 857f;
		minShootTime = 458f;
		maxShootTime = 79f;
		probabilityOfRealShot = 96f;
		fireBatchSizeMin = 0;
		fireBatchSizeMax = 0;
		special = 1407f;
	}

	public virtual BehaviourDefinititon FIEIDMGECFG(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon = (VehicleBehaviourDefinititon)LLGHNHMFCPN;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon2 = (VehicleBehaviourDefinititon)AJCHDECIFJC;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon3 = (VehicleBehaviourDefinititon)LLGHNHMFCPN.NOBGFCMPPKP();
		vehicleBehaviourDefinititon3.health = Mathf.Lerp(vehicleBehaviourDefinititon.health, vehicleBehaviourDefinititon2.health, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.probabilityOfRealShot = Mathf.Lerp(vehicleBehaviourDefinititon.probabilityOfRealShot, vehicleBehaviourDefinititon2.probabilityOfRealShot, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.damage = Mathf.Lerp(vehicleBehaviourDefinititon.damage, vehicleBehaviourDefinititon2.damage, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMin = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMin, vehicleBehaviourDefinititon2.fireBatchSizeMin, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMax = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMax, vehicleBehaviourDefinititon2.fireBatchSizeMax, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.minShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.minShootTime, vehicleBehaviourDefinititon2.minShootTime, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.maxShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.maxShootTime, vehicleBehaviourDefinititon2.maxShootTime, GACKNHPFGFM);
		return vehicleBehaviourDefinititon3;
	}

	public virtual void ANEPLHCBIOD()
	{
		health = 1727f;
		damage = 454f;
		minShootTime = 870f;
		maxShootTime = 1061f;
		probabilityOfRealShot = 1424f;
		fireBatchSizeMin = 0;
		fireBatchSizeMax = 1;
		special = 1505f;
	}

	public virtual void NGDPPPEBJGA()
	{
		health = 1259f;
		damage = 575f;
		minShootTime = 1739f;
		maxShootTime = 222f;
		probabilityOfRealShot = 424f;
		fireBatchSizeMin = 1;
		fireBatchSizeMax = 1;
		special = 196f;
	}

	public virtual BehaviourDefinititon KJIANOALDCF(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon = (VehicleBehaviourDefinititon)LLGHNHMFCPN;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon2 = (VehicleBehaviourDefinititon)AJCHDECIFJC;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon3 = (VehicleBehaviourDefinititon)LLGHNHMFCPN.ABNPNLMHNKK();
		vehicleBehaviourDefinititon3.health = Mathf.Lerp(vehicleBehaviourDefinititon.health, vehicleBehaviourDefinititon2.health, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.probabilityOfRealShot = Mathf.Lerp(vehicleBehaviourDefinititon.probabilityOfRealShot, vehicleBehaviourDefinititon2.probabilityOfRealShot, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.damage = Mathf.Lerp(vehicleBehaviourDefinititon.damage, vehicleBehaviourDefinititon2.damage, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMin = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMin, vehicleBehaviourDefinititon2.fireBatchSizeMin, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMax = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMax, vehicleBehaviourDefinititon2.fireBatchSizeMax, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.minShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.minShootTime, vehicleBehaviourDefinititon2.minShootTime, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.maxShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.maxShootTime, vehicleBehaviourDefinititon2.maxShootTime, GACKNHPFGFM);
		return vehicleBehaviourDefinititon3;
	}

	public virtual BehaviourDefinititon MACOFIBCMJF(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon = (VehicleBehaviourDefinititon)LLGHNHMFCPN;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon2 = (VehicleBehaviourDefinititon)AJCHDECIFJC;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon3 = (VehicleBehaviourDefinititon)LLGHNHMFCPN.HIGKMHJIFJF();
		vehicleBehaviourDefinititon3.health = Mathf.Lerp(vehicleBehaviourDefinititon.health, vehicleBehaviourDefinititon2.health, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.probabilityOfRealShot = Mathf.Lerp(vehicleBehaviourDefinititon.probabilityOfRealShot, vehicleBehaviourDefinititon2.probabilityOfRealShot, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.damage = Mathf.Lerp(vehicleBehaviourDefinititon.damage, vehicleBehaviourDefinititon2.damage, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMin = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMin, vehicleBehaviourDefinititon2.fireBatchSizeMin, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMax = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMax, vehicleBehaviourDefinititon2.fireBatchSizeMax, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.minShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.minShootTime, vehicleBehaviourDefinititon2.minShootTime, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.maxShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.maxShootTime, vehicleBehaviourDefinititon2.maxShootTime, GACKNHPFGFM);
		return vehicleBehaviourDefinititon3;
	}

	public virtual void BHAIOPCLJPM()
	{
		health = 687f;
		damage = 1232f;
		minShootTime = 796f;
		maxShootTime = 586f;
		probabilityOfRealShot = 573f;
		fireBatchSizeMin = 1;
		fireBatchSizeMax = 0;
		special = 125f;
	}

	public virtual void CEFGHPBGDHJ()
	{
		health = 1944f;
		damage = 613f;
		minShootTime = 478f;
		maxShootTime = 123f;
		probabilityOfRealShot = 1702f;
		fireBatchSizeMin = 0;
		fireBatchSizeMax = 1;
		special = 1781f;
	}

	public virtual void EGONLEGNLFO()
	{
		health = 1439f;
		damage = 1521f;
		minShootTime = 1352f;
		maxShootTime = 1587f;
		probabilityOfRealShot = 1011f;
		fireBatchSizeMin = 0;
		fireBatchSizeMax = 1;
		special = 1738f;
	}

	public virtual BehaviourDefinititon BFNDBKPGOJN(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon = (VehicleBehaviourDefinititon)LLGHNHMFCPN;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon2 = (VehicleBehaviourDefinititon)AJCHDECIFJC;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon3 = (VehicleBehaviourDefinititon)LLGHNHMFCPN.MCCHPFINCKH();
		vehicleBehaviourDefinititon3.health = Mathf.Lerp(vehicleBehaviourDefinititon.health, vehicleBehaviourDefinititon2.health, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.probabilityOfRealShot = Mathf.Lerp(vehicleBehaviourDefinititon.probabilityOfRealShot, vehicleBehaviourDefinititon2.probabilityOfRealShot, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.damage = Mathf.Lerp(vehicleBehaviourDefinititon.damage, vehicleBehaviourDefinititon2.damage, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMin = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMin, vehicleBehaviourDefinititon2.fireBatchSizeMin, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMax = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMax, vehicleBehaviourDefinititon2.fireBatchSizeMax, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.minShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.minShootTime, vehicleBehaviourDefinititon2.minShootTime, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.maxShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.maxShootTime, vehicleBehaviourDefinititon2.maxShootTime, GACKNHPFGFM);
		return vehicleBehaviourDefinititon3;
	}

	public virtual BehaviourDefinititon FKOLJINEJCG(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon = (VehicleBehaviourDefinititon)LLGHNHMFCPN;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon2 = (VehicleBehaviourDefinititon)AJCHDECIFJC;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon3 = (VehicleBehaviourDefinititon)LLGHNHMFCPN.JCPMGMGGPPF();
		vehicleBehaviourDefinititon3.health = Mathf.Lerp(vehicleBehaviourDefinititon.health, vehicleBehaviourDefinititon2.health, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.probabilityOfRealShot = Mathf.Lerp(vehicleBehaviourDefinititon.probabilityOfRealShot, vehicleBehaviourDefinititon2.probabilityOfRealShot, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.damage = Mathf.Lerp(vehicleBehaviourDefinititon.damage, vehicleBehaviourDefinititon2.damage, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMin = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMin, vehicleBehaviourDefinititon2.fireBatchSizeMin, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMax = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMax, vehicleBehaviourDefinititon2.fireBatchSizeMax, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.minShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.minShootTime, vehicleBehaviourDefinititon2.minShootTime, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.maxShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.maxShootTime, vehicleBehaviourDefinititon2.maxShootTime, GACKNHPFGFM);
		return vehicleBehaviourDefinititon3;
	}

	public virtual void AHPKBGKOBMK()
	{
		health = 840f;
		damage = 182f;
		minShootTime = 880f;
		maxShootTime = 1380f;
		probabilityOfRealShot = 114f;
		fireBatchSizeMin = 1;
		fireBatchSizeMax = 0;
		special = 623f;
	}

	public virtual void MDNAPECLMME()
	{
		health = 983f;
		damage = 569f;
		minShootTime = 407f;
		maxShootTime = 1671f;
		probabilityOfRealShot = 897f;
		fireBatchSizeMin = 0;
		fireBatchSizeMax = 1;
		special = 1439f;
	}

	public virtual void IFBPEKJAPNB()
	{
		health = 620f;
		damage = 1603f;
		minShootTime = 538f;
		maxShootTime = 1176f;
		probabilityOfRealShot = 1546f;
		fireBatchSizeMin = 0;
		fireBatchSizeMax = 1;
		special = 666f;
	}

	public virtual BehaviourDefinititon JHNHOFKAIII(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon = (VehicleBehaviourDefinititon)LLGHNHMFCPN;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon2 = (VehicleBehaviourDefinititon)AJCHDECIFJC;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon3 = (VehicleBehaviourDefinititon)LLGHNHMFCPN.MCCHPFINCKH();
		vehicleBehaviourDefinititon3.health = Mathf.Lerp(vehicleBehaviourDefinititon.health, vehicleBehaviourDefinititon2.health, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.probabilityOfRealShot = Mathf.Lerp(vehicleBehaviourDefinititon.probabilityOfRealShot, vehicleBehaviourDefinititon2.probabilityOfRealShot, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.damage = Mathf.Lerp(vehicleBehaviourDefinititon.damage, vehicleBehaviourDefinititon2.damage, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMin = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMin, vehicleBehaviourDefinititon2.fireBatchSizeMin, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMax = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMax, vehicleBehaviourDefinititon2.fireBatchSizeMax, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.minShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.minShootTime, vehicleBehaviourDefinititon2.minShootTime, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.maxShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.maxShootTime, vehicleBehaviourDefinititon2.maxShootTime, GACKNHPFGFM);
		return vehicleBehaviourDefinititon3;
	}

	public virtual BehaviourDefinititon BPEGKDHDHLH(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon = (VehicleBehaviourDefinititon)LLGHNHMFCPN;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon2 = (VehicleBehaviourDefinititon)AJCHDECIFJC;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon3 = (VehicleBehaviourDefinititon)LLGHNHMFCPN.MCCHPFINCKH();
		vehicleBehaviourDefinititon3.health = Mathf.Lerp(vehicleBehaviourDefinititon.health, vehicleBehaviourDefinititon2.health, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.probabilityOfRealShot = Mathf.Lerp(vehicleBehaviourDefinititon.probabilityOfRealShot, vehicleBehaviourDefinititon2.probabilityOfRealShot, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.damage = Mathf.Lerp(vehicleBehaviourDefinititon.damage, vehicleBehaviourDefinititon2.damage, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMin = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMin, vehicleBehaviourDefinititon2.fireBatchSizeMin, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMax = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMax, vehicleBehaviourDefinititon2.fireBatchSizeMax, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.minShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.minShootTime, vehicleBehaviourDefinititon2.minShootTime, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.maxShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.maxShootTime, vehicleBehaviourDefinititon2.maxShootTime, GACKNHPFGFM);
		return vehicleBehaviourDefinititon3;
	}

	public virtual BehaviourDefinititon GIKHOPAMHPG(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon = (VehicleBehaviourDefinititon)LLGHNHMFCPN;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon2 = (VehicleBehaviourDefinititon)AJCHDECIFJC;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon3 = (VehicleBehaviourDefinititon)LLGHNHMFCPN.MCCHPFINCKH();
		vehicleBehaviourDefinititon3.health = Mathf.Lerp(vehicleBehaviourDefinititon.health, vehicleBehaviourDefinititon2.health, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.probabilityOfRealShot = Mathf.Lerp(vehicleBehaviourDefinititon.probabilityOfRealShot, vehicleBehaviourDefinititon2.probabilityOfRealShot, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.damage = Mathf.Lerp(vehicleBehaviourDefinititon.damage, vehicleBehaviourDefinititon2.damage, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMin = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMin, vehicleBehaviourDefinititon2.fireBatchSizeMin, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMax = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMax, vehicleBehaviourDefinititon2.fireBatchSizeMax, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.minShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.minShootTime, vehicleBehaviourDefinititon2.minShootTime, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.maxShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.maxShootTime, vehicleBehaviourDefinititon2.maxShootTime, GACKNHPFGFM);
		return vehicleBehaviourDefinititon3;
	}

	public override void KFLADKOLPCM()
	{
		health = 0f;
		damage = 0f;
		minShootTime = 0f;
		maxShootTime = 0f;
		probabilityOfRealShot = 0f;
		fireBatchSizeMin = 0;
		fireBatchSizeMax = 0;
		special = 0f;
	}

	public override BehaviourDefinititon BMLALFLBNKO(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon = (VehicleBehaviourDefinititon)LLGHNHMFCPN;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon2 = (VehicleBehaviourDefinititon)AJCHDECIFJC;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon3 = (VehicleBehaviourDefinititon)LLGHNHMFCPN.HIGKMHJIFJF();
		vehicleBehaviourDefinititon3.health = Mathf.Lerp(vehicleBehaviourDefinititon.health, vehicleBehaviourDefinititon2.health, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.probabilityOfRealShot = Mathf.Lerp(vehicleBehaviourDefinititon.probabilityOfRealShot, vehicleBehaviourDefinititon2.probabilityOfRealShot, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.damage = Mathf.Lerp(vehicleBehaviourDefinititon.damage, vehicleBehaviourDefinititon2.damage, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMin = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMin, vehicleBehaviourDefinititon2.fireBatchSizeMin, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMax = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMax, vehicleBehaviourDefinititon2.fireBatchSizeMax, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.minShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.minShootTime, vehicleBehaviourDefinititon2.minShootTime, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.maxShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.maxShootTime, vehicleBehaviourDefinititon2.maxShootTime, GACKNHPFGFM);
		return vehicleBehaviourDefinititon3;
	}

	public virtual BehaviourDefinititon JKLCBNKNIJE(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon = (VehicleBehaviourDefinititon)LLGHNHMFCPN;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon2 = (VehicleBehaviourDefinititon)AJCHDECIFJC;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon3 = (VehicleBehaviourDefinititon)LLGHNHMFCPN.AFBBNOFJJCP();
		vehicleBehaviourDefinititon3.health = Mathf.Lerp(vehicleBehaviourDefinititon.health, vehicleBehaviourDefinititon2.health, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.probabilityOfRealShot = Mathf.Lerp(vehicleBehaviourDefinititon.probabilityOfRealShot, vehicleBehaviourDefinititon2.probabilityOfRealShot, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.damage = Mathf.Lerp(vehicleBehaviourDefinititon.damage, vehicleBehaviourDefinititon2.damage, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMin = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMin, vehicleBehaviourDefinititon2.fireBatchSizeMin, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMax = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMax, vehicleBehaviourDefinititon2.fireBatchSizeMax, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.minShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.minShootTime, vehicleBehaviourDefinititon2.minShootTime, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.maxShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.maxShootTime, vehicleBehaviourDefinititon2.maxShootTime, GACKNHPFGFM);
		return vehicleBehaviourDefinititon3;
	}

	public virtual void LGIPJECKKLE()
	{
		health = 1715f;
		damage = 602f;
		minShootTime = 39f;
		maxShootTime = 1505f;
		probabilityOfRealShot = 766f;
		fireBatchSizeMin = 1;
		fireBatchSizeMax = 1;
		special = 1544f;
	}

	public virtual BehaviourDefinititon NCLKBGAIDKO(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon = (VehicleBehaviourDefinititon)LLGHNHMFCPN;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon2 = (VehicleBehaviourDefinititon)AJCHDECIFJC;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon3 = (VehicleBehaviourDefinititon)LLGHNHMFCPN.AFBBNOFJJCP();
		vehicleBehaviourDefinititon3.health = Mathf.Lerp(vehicleBehaviourDefinititon.health, vehicleBehaviourDefinititon2.health, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.probabilityOfRealShot = Mathf.Lerp(vehicleBehaviourDefinititon.probabilityOfRealShot, vehicleBehaviourDefinititon2.probabilityOfRealShot, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.damage = Mathf.Lerp(vehicleBehaviourDefinititon.damage, vehicleBehaviourDefinititon2.damage, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMin = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMin, vehicleBehaviourDefinititon2.fireBatchSizeMin, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMax = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMax, vehicleBehaviourDefinititon2.fireBatchSizeMax, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.minShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.minShootTime, vehicleBehaviourDefinititon2.minShootTime, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.maxShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.maxShootTime, vehicleBehaviourDefinititon2.maxShootTime, GACKNHPFGFM);
		return vehicleBehaviourDefinititon3;
	}

	public virtual BehaviourDefinititon EOAOBHGGIKA(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon = (VehicleBehaviourDefinititon)LLGHNHMFCPN;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon2 = (VehicleBehaviourDefinititon)AJCHDECIFJC;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon3 = (VehicleBehaviourDefinititon)LLGHNHMFCPN.PONPCFJHNOM();
		vehicleBehaviourDefinititon3.health = Mathf.Lerp(vehicleBehaviourDefinititon.health, vehicleBehaviourDefinititon2.health, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.probabilityOfRealShot = Mathf.Lerp(vehicleBehaviourDefinititon.probabilityOfRealShot, vehicleBehaviourDefinititon2.probabilityOfRealShot, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.damage = Mathf.Lerp(vehicleBehaviourDefinititon.damage, vehicleBehaviourDefinititon2.damage, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMin = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMin, vehicleBehaviourDefinititon2.fireBatchSizeMin, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMax = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMax, vehicleBehaviourDefinititon2.fireBatchSizeMax, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.minShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.minShootTime, vehicleBehaviourDefinititon2.minShootTime, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.maxShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.maxShootTime, vehicleBehaviourDefinititon2.maxShootTime, GACKNHPFGFM);
		return vehicleBehaviourDefinititon3;
	}

	public virtual void IMAHMPAIDJL()
	{
		health = 1339f;
		damage = 293f;
		minShootTime = 149f;
		maxShootTime = 99f;
		probabilityOfRealShot = 754f;
		fireBatchSizeMin = 0;
		fireBatchSizeMax = 1;
		special = 1037f;
	}

	public virtual void JNAEJHJGHNP()
	{
		health = 1959f;
		damage = 503f;
		minShootTime = 1016f;
		maxShootTime = 908f;
		probabilityOfRealShot = 846f;
		fireBatchSizeMin = 0;
		fireBatchSizeMax = 0;
		special = 841f;
	}

	public virtual BehaviourDefinititon KKGMDKFFGLJ(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon = (VehicleBehaviourDefinititon)LLGHNHMFCPN;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon2 = (VehicleBehaviourDefinititon)AJCHDECIFJC;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon3 = (VehicleBehaviourDefinititon)LLGHNHMFCPN.MCCHPFINCKH();
		vehicleBehaviourDefinititon3.health = Mathf.Lerp(vehicleBehaviourDefinititon.health, vehicleBehaviourDefinititon2.health, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.probabilityOfRealShot = Mathf.Lerp(vehicleBehaviourDefinititon.probabilityOfRealShot, vehicleBehaviourDefinititon2.probabilityOfRealShot, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.damage = Mathf.Lerp(vehicleBehaviourDefinititon.damage, vehicleBehaviourDefinititon2.damage, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMin = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMin, vehicleBehaviourDefinititon2.fireBatchSizeMin, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMax = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMax, vehicleBehaviourDefinititon2.fireBatchSizeMax, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.minShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.minShootTime, vehicleBehaviourDefinititon2.minShootTime, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.maxShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.maxShootTime, vehicleBehaviourDefinititon2.maxShootTime, GACKNHPFGFM);
		return vehicleBehaviourDefinititon3;
	}

	public virtual BehaviourDefinititon OPOCLLEENEF(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon = (VehicleBehaviourDefinititon)LLGHNHMFCPN;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon2 = (VehicleBehaviourDefinititon)AJCHDECIFJC;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon3 = (VehicleBehaviourDefinititon)LLGHNHMFCPN.MCCHPFINCKH();
		vehicleBehaviourDefinititon3.health = Mathf.Lerp(vehicleBehaviourDefinititon.health, vehicleBehaviourDefinititon2.health, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.probabilityOfRealShot = Mathf.Lerp(vehicleBehaviourDefinititon.probabilityOfRealShot, vehicleBehaviourDefinititon2.probabilityOfRealShot, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.damage = Mathf.Lerp(vehicleBehaviourDefinititon.damage, vehicleBehaviourDefinititon2.damage, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMin = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMin, vehicleBehaviourDefinititon2.fireBatchSizeMin, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMax = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMax, vehicleBehaviourDefinititon2.fireBatchSizeMax, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.minShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.minShootTime, vehicleBehaviourDefinititon2.minShootTime, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.maxShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.maxShootTime, vehicleBehaviourDefinititon2.maxShootTime, GACKNHPFGFM);
		return vehicleBehaviourDefinititon3;
	}

	public override BehaviourDefinititon BNOINHIGGLH(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon = (VehicleBehaviourDefinititon)LLGHNHMFCPN;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon2 = (VehicleBehaviourDefinititon)AJCHDECIFJC;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon3 = (VehicleBehaviourDefinititon)LLGHNHMFCPN.HIGKMHJIFJF();
		vehicleBehaviourDefinititon3.health = Mathf.Lerp(vehicleBehaviourDefinititon.health, vehicleBehaviourDefinititon2.health, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.probabilityOfRealShot = Mathf.Lerp(vehicleBehaviourDefinititon.probabilityOfRealShot, vehicleBehaviourDefinititon2.probabilityOfRealShot, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.damage = Mathf.Lerp(vehicleBehaviourDefinititon.damage, vehicleBehaviourDefinititon2.damage, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMin = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMin, vehicleBehaviourDefinititon2.fireBatchSizeMin, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMax = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMax, vehicleBehaviourDefinititon2.fireBatchSizeMax, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.minShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.minShootTime, vehicleBehaviourDefinititon2.minShootTime, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.maxShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.maxShootTime, vehicleBehaviourDefinititon2.maxShootTime, GACKNHPFGFM);
		return vehicleBehaviourDefinititon3;
	}

	public virtual void DNMFDLADKEM()
	{
		health = 680f;
		damage = 710f;
		minShootTime = 776f;
		maxShootTime = 1417f;
		probabilityOfRealShot = 107f;
		fireBatchSizeMin = 0;
		fireBatchSizeMax = 0;
		special = 704f;
	}

	public virtual void JIKNJOFGFGJ()
	{
		health = 972f;
		damage = 1458f;
		minShootTime = 1434f;
		maxShootTime = 23f;
		probabilityOfRealShot = 1150f;
		fireBatchSizeMin = 1;
		fireBatchSizeMax = 1;
		special = 1549f;
	}

	public virtual BehaviourDefinititon JFDIDIIHNMK(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon = (VehicleBehaviourDefinititon)LLGHNHMFCPN;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon2 = (VehicleBehaviourDefinititon)AJCHDECIFJC;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon3 = (VehicleBehaviourDefinititon)LLGHNHMFCPN.ABNPNLMHNKK();
		vehicleBehaviourDefinititon3.health = Mathf.Lerp(vehicleBehaviourDefinititon.health, vehicleBehaviourDefinititon2.health, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.probabilityOfRealShot = Mathf.Lerp(vehicleBehaviourDefinititon.probabilityOfRealShot, vehicleBehaviourDefinititon2.probabilityOfRealShot, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.damage = Mathf.Lerp(vehicleBehaviourDefinititon.damage, vehicleBehaviourDefinititon2.damage, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMin = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMin, vehicleBehaviourDefinititon2.fireBatchSizeMin, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMax = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMax, vehicleBehaviourDefinititon2.fireBatchSizeMax, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.minShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.minShootTime, vehicleBehaviourDefinititon2.minShootTime, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.maxShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.maxShootTime, vehicleBehaviourDefinititon2.maxShootTime, GACKNHPFGFM);
		return vehicleBehaviourDefinititon3;
	}

	public virtual BehaviourDefinititon KKCHFGFBABB(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon = (VehicleBehaviourDefinititon)LLGHNHMFCPN;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon2 = (VehicleBehaviourDefinititon)AJCHDECIFJC;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon3 = (VehicleBehaviourDefinititon)LLGHNHMFCPN.HIGKMHJIFJF();
		vehicleBehaviourDefinititon3.health = Mathf.Lerp(vehicleBehaviourDefinititon.health, vehicleBehaviourDefinititon2.health, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.probabilityOfRealShot = Mathf.Lerp(vehicleBehaviourDefinititon.probabilityOfRealShot, vehicleBehaviourDefinititon2.probabilityOfRealShot, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.damage = Mathf.Lerp(vehicleBehaviourDefinititon.damage, vehicleBehaviourDefinititon2.damage, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMin = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMin, vehicleBehaviourDefinititon2.fireBatchSizeMin, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMax = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMax, vehicleBehaviourDefinititon2.fireBatchSizeMax, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.minShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.minShootTime, vehicleBehaviourDefinititon2.minShootTime, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.maxShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.maxShootTime, vehicleBehaviourDefinititon2.maxShootTime, GACKNHPFGFM);
		return vehicleBehaviourDefinititon3;
	}

	public virtual BehaviourDefinititon MONDPJEGDIF(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon = (VehicleBehaviourDefinititon)LLGHNHMFCPN;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon2 = (VehicleBehaviourDefinititon)AJCHDECIFJC;
		VehicleBehaviourDefinititon vehicleBehaviourDefinititon3 = (VehicleBehaviourDefinititon)LLGHNHMFCPN.ABNPNLMHNKK();
		vehicleBehaviourDefinititon3.health = Mathf.Lerp(vehicleBehaviourDefinititon.health, vehicleBehaviourDefinititon2.health, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.probabilityOfRealShot = Mathf.Lerp(vehicleBehaviourDefinititon.probabilityOfRealShot, vehicleBehaviourDefinititon2.probabilityOfRealShot, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.damage = Mathf.Lerp(vehicleBehaviourDefinititon.damage, vehicleBehaviourDefinititon2.damage, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMin = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMin, vehicleBehaviourDefinititon2.fireBatchSizeMin, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.fireBatchSizeMax = (int)Mathf.Lerp(vehicleBehaviourDefinititon.fireBatchSizeMax, vehicleBehaviourDefinititon2.fireBatchSizeMax, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.minShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.minShootTime, vehicleBehaviourDefinititon2.minShootTime, GACKNHPFGFM);
		vehicleBehaviourDefinititon3.maxShootTime = Mathf.Lerp(vehicleBehaviourDefinititon.maxShootTime, vehicleBehaviourDefinititon2.maxShootTime, GACKNHPFGFM);
		return vehicleBehaviourDefinititon3;
	}
}
