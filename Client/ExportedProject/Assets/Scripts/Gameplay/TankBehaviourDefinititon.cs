using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class TankBehaviourDefinititon : VehicleBehaviourDefinititon
{
	[FormerlySerializedAs("maxShootTimeCannon")]
	public float damageCannon;

	[FormerlySerializedAs("minShootTimeCannon")]
	public float maxShootTimeCannon;

	[FormerlySerializedAs("damageCannon")]
	public float minShootTimeCannon;

	public virtual void LCGICKDCKNC(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.NNECIPAKPIL(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual BehaviourDefinititon KDCMNECNDHP(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)LLGHNHMFCPN;
		TankBehaviourDefinititon tankBehaviourDefinititon2 = (TankBehaviourDefinititon)AJCHDECIFJC;
		TankBehaviourDefinititon tankBehaviourDefinititon3 = (TankBehaviourDefinititon)BFNDBKPGOJN(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		tankBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.minShootTimeCannon, tankBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.maxShootTimeCannon, tankBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.damageCannon = Mathf.Lerp(tankBehaviourDefinititon.damageCannon, tankBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return tankBehaviourDefinititon3;
	}

	public virtual BehaviourDefinititon EJOMODBJONN(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)LLGHNHMFCPN;
		TankBehaviourDefinititon tankBehaviourDefinititon2 = (TankBehaviourDefinititon)AJCHDECIFJC;
		TankBehaviourDefinititon tankBehaviourDefinititon3 = (TankBehaviourDefinititon)GAJJIEPGECN(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		tankBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.minShootTimeCannon, tankBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.maxShootTimeCannon, tankBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.damageCannon = Mathf.Lerp(tankBehaviourDefinititon.damageCannon, tankBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return tankBehaviourDefinititon3;
	}

	public virtual void GFBHOHPNODL(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.AKAFKDJEOCM(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual BehaviourDefinititon LMIFPKFMFPN(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)LLGHNHMFCPN;
		TankBehaviourDefinititon tankBehaviourDefinititon2 = (TankBehaviourDefinititon)AJCHDECIFJC;
		TankBehaviourDefinititon tankBehaviourDefinititon3 = (TankBehaviourDefinititon)MONDPJEGDIF(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		tankBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.minShootTimeCannon, tankBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.maxShootTimeCannon, tankBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.damageCannon = Mathf.Lerp(tankBehaviourDefinititon.damageCannon, tankBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return tankBehaviourDefinititon3;
	}

	public virtual BehaviourDefinititon DPKDPKFCCIN(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)LLGHNHMFCPN;
		TankBehaviourDefinititon tankBehaviourDefinititon2 = (TankBehaviourDefinititon)AJCHDECIFJC;
		TankBehaviourDefinititon tankBehaviourDefinititon3 = (TankBehaviourDefinititon)KJIANOALDCF(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		tankBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.minShootTimeCannon, tankBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.maxShootTimeCannon, tankBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.damageCannon = Mathf.Lerp(tankBehaviourDefinititon.damageCannon, tankBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return tankBehaviourDefinititon3;
	}

	public virtual BehaviourDefinititon IAIBILOBCOK(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)LLGHNHMFCPN;
		TankBehaviourDefinititon tankBehaviourDefinititon2 = (TankBehaviourDefinititon)AJCHDECIFJC;
		TankBehaviourDefinititon tankBehaviourDefinititon3 = (TankBehaviourDefinititon)BADMBJMHDPJ(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		tankBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.minShootTimeCannon, tankBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.maxShootTimeCannon, tankBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.damageCannon = Mathf.Lerp(tankBehaviourDefinititon.damageCannon, tankBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return tankBehaviourDefinititon3;
	}

	public virtual void FDBEFNHMGKJ(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.LBPNKGOOAPL(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public override BehaviourDefinititon MDFLAMBJIPM(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)LLGHNHMFCPN;
		TankBehaviourDefinititon tankBehaviourDefinititon2 = (TankBehaviourDefinititon)AJCHDECIFJC;
		TankBehaviourDefinititon tankBehaviourDefinititon3 = (TankBehaviourDefinititon)base.BNOINHIGGLH(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		tankBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.minShootTimeCannon, tankBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.maxShootTimeCannon, tankBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.damageCannon = Mathf.Lerp(tankBehaviourDefinititon.damageCannon, tankBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return tankBehaviourDefinititon3;
	}

	public virtual BehaviourDefinititon HDAHFMMJCPH(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)LLGHNHMFCPN;
		TankBehaviourDefinititon tankBehaviourDefinititon2 = (TankBehaviourDefinititon)AJCHDECIFJC;
		TankBehaviourDefinititon tankBehaviourDefinititon3 = (TankBehaviourDefinititon)GJDCGFJOPLI(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		tankBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.minShootTimeCannon, tankBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.maxShootTimeCannon, tankBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.damageCannon = Mathf.Lerp(tankBehaviourDefinititon.damageCannon, tankBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return tankBehaviourDefinititon3;
	}

	public virtual BehaviourDefinititon JDKNBANJCLK(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)LLGHNHMFCPN;
		TankBehaviourDefinititon tankBehaviourDefinititon2 = (TankBehaviourDefinititon)AJCHDECIFJC;
		TankBehaviourDefinititon tankBehaviourDefinititon3 = (TankBehaviourDefinititon)NMILPKNGEAD(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		tankBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.minShootTimeCannon, tankBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.maxShootTimeCannon, tankBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.damageCannon = Mathf.Lerp(tankBehaviourDefinititon.damageCannon, tankBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return tankBehaviourDefinititon3;
	}

	public override void FPKDOOLFAMM()
	{
		AHPKBGKOBMK();
		damageCannon = 1776f;
		minShootTimeCannon = 80f;
		maxShootTimeCannon = 1855f;
	}

	public override void BHAIOPCLJPM()
	{
		FPDGMNFIHIL();
		damageCannon = 299f;
		minShootTimeCannon = 1064f;
		maxShootTimeCannon = 860f;
	}

	public virtual void IOIFHEPOOIF(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.AKAFKDJEOCM(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual void AMBOJAPCCPO()
	{
		LGIPJECKKLE();
		damageCannon = 996f;
		minShootTimeCannon = 1591f;
		maxShootTimeCannon = 1389f;
	}

	public override BehaviourDefinititon KKCHFGFBABB(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)LLGHNHMFCPN;
		TankBehaviourDefinititon tankBehaviourDefinititon2 = (TankBehaviourDefinititon)AJCHDECIFJC;
		TankBehaviourDefinititon tankBehaviourDefinititon3 = (TankBehaviourDefinititon)base.BNOINHIGGLH(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		tankBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.minShootTimeCannon, tankBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.maxShootTimeCannon, tankBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.damageCannon = Mathf.Lerp(tankBehaviourDefinititon.damageCannon, tankBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return tankBehaviourDefinititon3;
	}

	public override BehaviourDefinititon NCLKBGAIDKO(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)LLGHNHMFCPN;
		TankBehaviourDefinititon tankBehaviourDefinititon2 = (TankBehaviourDefinititon)AJCHDECIFJC;
		TankBehaviourDefinititon tankBehaviourDefinititon3 = (TankBehaviourDefinititon)KKGMDKFFGLJ(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		tankBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.minShootTimeCannon, tankBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.maxShootTimeCannon, tankBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.damageCannon = Mathf.Lerp(tankBehaviourDefinititon.damageCannon, tankBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return tankBehaviourDefinititon3;
	}

	public virtual void EHLIPHKFDMB(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.MIKOLPDBCLK(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual void LEAFJOPKMBI(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.EFCOOLOEMIO(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual void IKHHOCGPJGB()
	{
		AHPKBGKOBMK();
		damageCannon = 1318f;
		minShootTimeCannon = 1376f;
		maxShootTimeCannon = 643f;
	}

	public override void MDNAPECLMME()
	{
		base.MDNAPECLMME();
		damageCannon = 822f;
		minShootTimeCannon = 1451f;
		maxShootTimeCannon = 870f;
	}

	public virtual BehaviourDefinititon BCDHNCMFACJ(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)LLGHNHMFCPN;
		TankBehaviourDefinititon tankBehaviourDefinititon2 = (TankBehaviourDefinititon)AJCHDECIFJC;
		TankBehaviourDefinititon tankBehaviourDefinititon3 = (TankBehaviourDefinititon)base.EOAOBHGGIKA(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		tankBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.minShootTimeCannon, tankBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.maxShootTimeCannon, tankBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.damageCannon = Mathf.Lerp(tankBehaviourDefinititon.damageCannon, tankBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return tankBehaviourDefinititon3;
	}

	public virtual void MEKLJNPMMFP()
	{
		base.IMAHMPAIDJL();
		damageCannon = 1855f;
		minShootTimeCannon = 1682f;
		maxShootTimeCannon = 1815f;
	}

	public virtual void NCLAAJGPMFF()
	{
		base.JNAEJHJGHNP();
		damageCannon = 825f;
		minShootTimeCannon = 166f;
		maxShootTimeCannon = 857f;
	}

	public virtual void OOPBKGGADLA()
	{
		LGIPJECKKLE();
		damageCannon = 1648f;
		minShootTimeCannon = 6f;
		maxShootTimeCannon = 1844f;
	}

	public virtual void CJLNFEKBNHB(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.LPBNNPBPIPA(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual BehaviourDefinititon NJOGCOIMGHA(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)LLGHNHMFCPN;
		TankBehaviourDefinititon tankBehaviourDefinititon2 = (TankBehaviourDefinititon)AJCHDECIFJC;
		TankBehaviourDefinititon tankBehaviourDefinititon3 = (TankBehaviourDefinititon)base.OPOCLLEENEF(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		tankBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.minShootTimeCannon, tankBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.maxShootTimeCannon, tankBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.damageCannon = Mathf.Lerp(tankBehaviourDefinititon.damageCannon, tankBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return tankBehaviourDefinititon3;
	}

	public virtual BehaviourDefinititon ADDAEFJKEID(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)LLGHNHMFCPN;
		TankBehaviourDefinititon tankBehaviourDefinititon2 = (TankBehaviourDefinititon)AJCHDECIFJC;
		TankBehaviourDefinititon tankBehaviourDefinititon3 = (TankBehaviourDefinititon)FKOLJINEJCG(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		tankBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.minShootTimeCannon, tankBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.maxShootTimeCannon, tankBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.damageCannon = Mathf.Lerp(tankBehaviourDefinititon.damageCannon, tankBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return tankBehaviourDefinititon3;
	}

	public virtual BehaviourDefinititon JKKGKAKBODI(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)LLGHNHMFCPN;
		TankBehaviourDefinititon tankBehaviourDefinititon2 = (TankBehaviourDefinititon)AJCHDECIFJC;
		TankBehaviourDefinititon tankBehaviourDefinititon3 = (TankBehaviourDefinititon)BADMBJMHDPJ(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		tankBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.minShootTimeCannon, tankBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.maxShootTimeCannon, tankBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.damageCannon = Mathf.Lerp(tankBehaviourDefinititon.damageCannon, tankBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return tankBehaviourDefinititon3;
	}

	public virtual void AEBCDMHMNPD(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.LPBNNPBPIPA(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual void NNGIBAAOFME(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.NNECIPAKPIL(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual void ELAHIHANNKD()
	{
		CEFGHPBGDHJ();
		damageCannon = 1297f;
		minShootTimeCannon = 1942f;
		maxShootTimeCannon = 61f;
	}

	public override BehaviourDefinititon JKLCBNKNIJE(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)LLGHNHMFCPN;
		TankBehaviourDefinititon tankBehaviourDefinititon2 = (TankBehaviourDefinititon)AJCHDECIFJC;
		TankBehaviourDefinititon tankBehaviourDefinititon3 = (TankBehaviourDefinititon)GAJJIEPGECN(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		tankBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.minShootTimeCannon, tankBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.maxShootTimeCannon, tankBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.damageCannon = Mathf.Lerp(tankBehaviourDefinititon.damageCannon, tankBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return tankBehaviourDefinititon3;
	}

	public virtual BehaviourDefinititon BJKLAGLEFGM(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)LLGHNHMFCPN;
		TankBehaviourDefinititon tankBehaviourDefinititon2 = (TankBehaviourDefinititon)AJCHDECIFJC;
		TankBehaviourDefinititon tankBehaviourDefinititon3 = (TankBehaviourDefinititon)FKOLJINEJCG(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		tankBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.minShootTimeCannon, tankBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.maxShootTimeCannon, tankBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.damageCannon = Mathf.Lerp(tankBehaviourDefinititon.damageCannon, tankBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return tankBehaviourDefinititon3;
	}

	public virtual void BDMIHIPFJJJ()
	{
		JIKNJOFGFGJ();
		damageCannon = 811f;
		minShootTimeCannon = 358f;
		maxShootTimeCannon = 1526f;
	}

	public virtual void DLKALMFJOJF()
	{
		base.EAEEEKCAOIN();
		damageCannon = 321f;
		minShootTimeCannon = 523f;
		maxShootTimeCannon = 177f;
	}

	public override BehaviourDefinititon AFHECGBAKDG(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)LLGHNHMFCPN;
		TankBehaviourDefinititon tankBehaviourDefinititon2 = (TankBehaviourDefinititon)AJCHDECIFJC;
		TankBehaviourDefinititon tankBehaviourDefinititon3 = (TankBehaviourDefinititon)base.NCLKBGAIDKO(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		tankBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.minShootTimeCannon, tankBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.maxShootTimeCannon, tankBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.damageCannon = Mathf.Lerp(tankBehaviourDefinititon.damageCannon, tankBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return tankBehaviourDefinititon3;
	}

	public virtual void EOBNCOCFCAI(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.FOICCNFHPAE(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual void JOEDKIIAMAO()
	{
		IDJNOCBPALG();
		damageCannon = 900f;
		minShootTimeCannon = 1837f;
		maxShootTimeCannon = 226f;
	}

	public virtual void MFCIKFMGFKJ(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.EFCOOLOEMIO(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public override void ENBGBPECOKD()
	{
		base.IFBPEKJAPNB();
		damageCannon = 415f;
		minShootTimeCannon = 780f;
		maxShootTimeCannon = 1580f;
	}

	public virtual void LOIPEJAAHOA()
	{
		AHPKBGKOBMK();
		damageCannon = 1621f;
		minShootTimeCannon = 888f;
		maxShootTimeCannon = 345f;
	}

	public override BehaviourDefinititon MFBEAKIFANE(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)LLGHNHMFCPN;
		TankBehaviourDefinititon tankBehaviourDefinititon2 = (TankBehaviourDefinititon)AJCHDECIFJC;
		TankBehaviourDefinititon tankBehaviourDefinititon3 = (TankBehaviourDefinititon)base.NCLKBGAIDKO(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		tankBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.minShootTimeCannon, tankBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.maxShootTimeCannon, tankBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.damageCannon = Mathf.Lerp(tankBehaviourDefinititon.damageCannon, tankBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return tankBehaviourDefinititon3;
	}

	public virtual void BLOEEHAFIGM(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.PBKKFFKLHKA(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual void MCPFOKMMLDM()
	{
		base.BHAIOPCLJPM();
		damageCannon = 1516f;
		minShootTimeCannon = 315f;
		maxShootTimeCannon = 40f;
	}

	public virtual void IEHEHIFJNAL()
	{
		ANEPLHCBIOD();
		damageCannon = 774f;
		minShootTimeCannon = 57f;
		maxShootTimeCannon = 497f;
	}

	public virtual void CKOGEEHEBPH(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.LPBNNPBPIPA(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual void HKBPLJJJNDA()
	{
		base.LFIIJFJHBDH();
		damageCannon = 1426f;
		minShootTimeCannon = 1190f;
		maxShootTimeCannon = 433f;
	}

	public virtual BehaviourDefinititon DDNMJGMIEDG(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)LLGHNHMFCPN;
		TankBehaviourDefinititon tankBehaviourDefinititon2 = (TankBehaviourDefinititon)AJCHDECIFJC;
		TankBehaviourDefinititon tankBehaviourDefinititon3 = (TankBehaviourDefinititon)GAJJIEPGECN(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		tankBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.minShootTimeCannon, tankBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.maxShootTimeCannon, tankBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.damageCannon = Mathf.Lerp(tankBehaviourDefinititon.damageCannon, tankBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return tankBehaviourDefinititon3;
	}

	public override void EGONLEGNLFO()
	{
		base.KFLADKOLPCM();
		damageCannon = 1316f;
		minShootTimeCannon = 1802f;
		maxShootTimeCannon = 376f;
	}

	public virtual BehaviourDefinititon HJBHLEIGCOJ(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)LLGHNHMFCPN;
		TankBehaviourDefinititon tankBehaviourDefinititon2 = (TankBehaviourDefinititon)AJCHDECIFJC;
		TankBehaviourDefinititon tankBehaviourDefinititon3 = (TankBehaviourDefinititon)BPEGKDHDHLH(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		tankBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.minShootTimeCannon, tankBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.maxShootTimeCannon, tankBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.damageCannon = Mathf.Lerp(tankBehaviourDefinititon.damageCannon, tankBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return tankBehaviourDefinititon3;
	}

	public virtual BehaviourDefinititon LHEFFDONEPD(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)LLGHNHMFCPN;
		TankBehaviourDefinititon tankBehaviourDefinititon2 = (TankBehaviourDefinititon)AJCHDECIFJC;
		TankBehaviourDefinititon tankBehaviourDefinititon3 = (TankBehaviourDefinititon)base.OPOCLLEENEF(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		tankBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.minShootTimeCannon, tankBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.maxShootTimeCannon, tankBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.damageCannon = Mathf.Lerp(tankBehaviourDefinititon.damageCannon, tankBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return tankBehaviourDefinititon3;
	}

	public virtual void MBJGMGANFJJ()
	{
		base.BHAIOPCLJPM();
		damageCannon = 1160f;
		minShootTimeCannon = 1273f;
		maxShootTimeCannon = 471f;
	}

	public virtual BehaviourDefinititon DGKDCNCAJHL(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)LLGHNHMFCPN;
		TankBehaviourDefinititon tankBehaviourDefinititon2 = (TankBehaviourDefinititon)AJCHDECIFJC;
		TankBehaviourDefinititon tankBehaviourDefinititon3 = (TankBehaviourDefinititon)GAJJIEPGECN(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		tankBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.minShootTimeCannon, tankBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.maxShootTimeCannon, tankBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.damageCannon = Mathf.Lerp(tankBehaviourDefinititon.damageCannon, tankBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return tankBehaviourDefinititon3;
	}

	public virtual BehaviourDefinititon OMMFJPIBDPL(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)LLGHNHMFCPN;
		TankBehaviourDefinititon tankBehaviourDefinititon2 = (TankBehaviourDefinititon)AJCHDECIFJC;
		TankBehaviourDefinititon tankBehaviourDefinititon3 = (TankBehaviourDefinititon)base.JKLCBNKNIJE(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		tankBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.minShootTimeCannon, tankBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.maxShootTimeCannon, tankBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.damageCannon = Mathf.Lerp(tankBehaviourDefinititon.damageCannon, tankBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return tankBehaviourDefinititon3;
	}

	public virtual BehaviourDefinititon EDJMJFPNKLP(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)LLGHNHMFCPN;
		TankBehaviourDefinititon tankBehaviourDefinititon2 = (TankBehaviourDefinititon)AJCHDECIFJC;
		TankBehaviourDefinititon tankBehaviourDefinititon3 = (TankBehaviourDefinititon)FIEIDMGECFG(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		tankBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.minShootTimeCannon, tankBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.maxShootTimeCannon, tankBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.damageCannon = Mathf.Lerp(tankBehaviourDefinititon.damageCannon, tankBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return tankBehaviourDefinititon3;
	}

	public virtual void KNBFCADNGHE(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.EFCOOLOEMIO(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual void BKJJOHFOBMO()
	{
		base.BHAIOPCLJPM();
		damageCannon = 513f;
		minShootTimeCannon = 439f;
		maxShootTimeCannon = 1686f;
	}

	public override void EAEEEKCAOIN()
	{
		base.EKLCHIEMDBP();
		damageCannon = 909f;
		minShootTimeCannon = 1200f;
		maxShootTimeCannon = 1908f;
	}

	public virtual void BDNBCAIGGPC()
	{
		base.EGONLEGNLFO();
		damageCannon = 1462f;
		minShootTimeCannon = 462f;
		maxShootTimeCannon = 1332f;
	}

	public virtual void HLGPDBIIKAD(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.NCMLOODDMCF(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual void EIIDHAFGNKA()
	{
		base.BHAIOPCLJPM();
		damageCannon = 215f;
		minShootTimeCannon = 590f;
		maxShootTimeCannon = 1012f;
	}

	public override void JNAEJHJGHNP()
	{
		AHPKBGKOBMK();
		damageCannon = 161f;
		minShootTimeCannon = 1095f;
		maxShootTimeCannon = 1248f;
	}

	public virtual void LODOMLIAHFE(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.MIKOLPDBCLK(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public override BehaviourDefinititon BMLALFLBNKO(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)LLGHNHMFCPN;
		TankBehaviourDefinititon tankBehaviourDefinititon2 = (TankBehaviourDefinititon)AJCHDECIFJC;
		TankBehaviourDefinititon tankBehaviourDefinititon3 = (TankBehaviourDefinititon)base.BMLALFLBNKO(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		tankBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.minShootTimeCannon, tankBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.maxShootTimeCannon, tankBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.damageCannon = Mathf.Lerp(tankBehaviourDefinititon.damageCannon, tankBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return tankBehaviourDefinititon3;
	}

	public override BehaviourDefinititon OPOCLLEENEF(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)LLGHNHMFCPN;
		TankBehaviourDefinititon tankBehaviourDefinititon2 = (TankBehaviourDefinititon)AJCHDECIFJC;
		TankBehaviourDefinititon tankBehaviourDefinititon3 = (TankBehaviourDefinititon)base.BNOINHIGGLH(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		tankBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.minShootTimeCannon, tankBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.maxShootTimeCannon, tankBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.damageCannon = Mathf.Lerp(tankBehaviourDefinititon.damageCannon, tankBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return tankBehaviourDefinititon3;
	}

	public virtual void AFKMPILEIIP(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.MBNKINKNPIG(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual void FOPOEAJFKPP(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.NNECIPAKPIL(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual void LFLCCBHBDDP(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.MIKOLPDBCLK(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual void LANIKKALILJ(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.AKAFKDJEOCM(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public override void LFIIJFJHBDH()
	{
		base.EKLCHIEMDBP();
		damageCannon = 1060f;
		minShootTimeCannon = 1008f;
		maxShootTimeCannon = 1530f;
	}

	public virtual void FIOGJOHADAL()
	{
		base.KFLADKOLPCM();
		damageCannon = 1306f;
		minShootTimeCannon = 236f;
		maxShootTimeCannon = 985f;
	}

	public override void IFBPEKJAPNB()
	{
		LGIPJECKKLE();
		damageCannon = 999f;
		minShootTimeCannon = 219f;
		maxShootTimeCannon = 1209f;
	}

	public virtual void EEIEFJOHKIJ(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.LLNPDHAHFDB(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual void KHJNONBACJJ(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.GPAGBDBEPPO(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual void CAGIBLDCGMD()
	{
		base.EGONLEGNLFO();
		damageCannon = 384f;
		minShootTimeCannon = 1519f;
		maxShootTimeCannon = 143f;
	}

	public virtual void BGBCHLPDPPJ(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.EFCOOLOEMIO(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public override void IMAHMPAIDJL()
	{
		DNMFDLADKEM();
		damageCannon = 1136f;
		minShootTimeCannon = 771f;
		maxShootTimeCannon = 1721f;
	}

	public virtual void INIPLOPGAOH(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.LLNPDHAHFDB(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual void BLNHFLBJLCK()
	{
		IDJNOCBPALG();
		damageCannon = 1921f;
		minShootTimeCannon = 1868f;
		maxShootTimeCannon = 308f;
	}

	public virtual void EHIGEHEMNIM()
	{
		base.BHAIOPCLJPM();
		damageCannon = 1288f;
		minShootTimeCannon = 1284f;
		maxShootTimeCannon = 1972f;
	}

	public virtual void LFLKAHFIGEF(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.LPBNNPBPIPA(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public override void EKLCHIEMDBP()
	{
		DNMFDLADKEM();
		damageCannon = 1201f;
		minShootTimeCannon = 1321f;
		maxShootTimeCannon = 1488f;
	}

	public override BehaviourDefinititon EOAOBHGGIKA(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)LLGHNHMFCPN;
		TankBehaviourDefinititon tankBehaviourDefinititon2 = (TankBehaviourDefinititon)AJCHDECIFJC;
		TankBehaviourDefinititon tankBehaviourDefinititon3 = (TankBehaviourDefinititon)KOLNONBJGAJ(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		tankBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.minShootTimeCannon, tankBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.maxShootTimeCannon, tankBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.damageCannon = Mathf.Lerp(tankBehaviourDefinititon.damageCannon, tankBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return tankBehaviourDefinititon3;
	}

	public override BehaviourDefinititon BNOINHIGGLH(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)LLGHNHMFCPN;
		TankBehaviourDefinititon tankBehaviourDefinititon2 = (TankBehaviourDefinititon)AJCHDECIFJC;
		TankBehaviourDefinititon tankBehaviourDefinititon3 = (TankBehaviourDefinititon)GIKHOPAMHPG(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		tankBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.minShootTimeCannon, tankBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.maxShootTimeCannon, tankBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.damageCannon = Mathf.Lerp(tankBehaviourDefinititon.damageCannon, tankBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return tankBehaviourDefinititon3;
	}

	public virtual BehaviourDefinititon NNODEHIFAJF(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)LLGHNHMFCPN;
		TankBehaviourDefinititon tankBehaviourDefinititon2 = (TankBehaviourDefinititon)AJCHDECIFJC;
		TankBehaviourDefinititon tankBehaviourDefinititon3 = (TankBehaviourDefinititon)base.AFHECGBAKDG(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		tankBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.minShootTimeCannon, tankBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.maxShootTimeCannon, tankBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.damageCannon = Mathf.Lerp(tankBehaviourDefinititon.damageCannon, tankBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return tankBehaviourDefinititon3;
	}

	public virtual void LPFJLLJONEN(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.LLNPDHAHFDB(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual void HFOIEJJGFLJ(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.FOICCNFHPAE(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual BehaviourDefinititon OIEJPFNHMDA(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)LLGHNHMFCPN;
		TankBehaviourDefinititon tankBehaviourDefinititon2 = (TankBehaviourDefinititon)AJCHDECIFJC;
		TankBehaviourDefinititon tankBehaviourDefinititon3 = (TankBehaviourDefinititon)JHNHOFKAIII(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		tankBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.minShootTimeCannon, tankBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.maxShootTimeCannon, tankBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.damageCannon = Mathf.Lerp(tankBehaviourDefinititon.damageCannon, tankBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return tankBehaviourDefinititon3;
	}

	public virtual void FMODOCADKJC(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.LPBNNPBPIPA(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual void JMKFKEDNOCH(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.GPAGBDBEPPO(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual BehaviourDefinititon BEBGCLCAJDI(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)LLGHNHMFCPN;
		TankBehaviourDefinititon tankBehaviourDefinititon2 = (TankBehaviourDefinititon)AJCHDECIFJC;
		TankBehaviourDefinititon tankBehaviourDefinititon3 = (TankBehaviourDefinititon)JHNHOFKAIII(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		tankBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.minShootTimeCannon, tankBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.maxShootTimeCannon, tankBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.damageCannon = Mathf.Lerp(tankBehaviourDefinititon.damageCannon, tankBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return tankBehaviourDefinititon3;
	}

	public virtual void GJJGPBPIKNH(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.NCMLOODDMCF(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual BehaviourDefinititon IDGOFGEKEBF(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)LLGHNHMFCPN;
		TankBehaviourDefinititon tankBehaviourDefinititon2 = (TankBehaviourDefinititon)AJCHDECIFJC;
		TankBehaviourDefinititon tankBehaviourDefinititon3 = (TankBehaviourDefinititon)base.EOAOBHGGIKA(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		tankBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.minShootTimeCannon, tankBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.maxShootTimeCannon, tankBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.damageCannon = Mathf.Lerp(tankBehaviourDefinititon.damageCannon, tankBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return tankBehaviourDefinititon3;
	}

	public override void MIKOLPDBCLK(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.MIKOLPDBCLK(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual void HOPBECAGHEC(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.FOICCNFHPAE(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual void KFDOKCJBFFF()
	{
		AHPKBGKOBMK();
		damageCannon = 1504f;
		minShootTimeCannon = 739f;
		maxShootTimeCannon = 1671f;
	}

	public virtual BehaviourDefinititon DJLGLEMKFMM(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)LLGHNHMFCPN;
		TankBehaviourDefinititon tankBehaviourDefinititon2 = (TankBehaviourDefinititon)AJCHDECIFJC;
		TankBehaviourDefinititon tankBehaviourDefinititon3 = (TankBehaviourDefinititon)GIKHOPAMHPG(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		tankBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.minShootTimeCannon, tankBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.maxShootTimeCannon, tankBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.damageCannon = Mathf.Lerp(tankBehaviourDefinititon.damageCannon, tankBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return tankBehaviourDefinititon3;
	}

	public override void KFLADKOLPCM()
	{
		base.KFLADKOLPCM();
		damageCannon = 0f;
		minShootTimeCannon = 0f;
		maxShootTimeCannon = 0f;
	}

	public virtual BehaviourDefinititon AKLKEPHMKCL(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)LLGHNHMFCPN;
		TankBehaviourDefinititon tankBehaviourDefinititon2 = (TankBehaviourDefinititon)AJCHDECIFJC;
		TankBehaviourDefinititon tankBehaviourDefinititon3 = (TankBehaviourDefinititon)base.JKLCBNKNIJE(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		tankBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.minShootTimeCannon, tankBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.maxShootTimeCannon, tankBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.damageCannon = Mathf.Lerp(tankBehaviourDefinititon.damageCannon, tankBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return tankBehaviourDefinititon3;
	}

	public virtual void PKANNCJPDBP(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.AKAFKDJEOCM(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual void LINOPFMCDAI()
	{
		ANEPLHCBIOD();
		damageCannon = 832f;
		minShootTimeCannon = 907f;
		maxShootTimeCannon = 1157f;
	}

	public virtual void JJHMNJAPDIF()
	{
		base.EKLCHIEMDBP();
		damageCannon = 1661f;
		minShootTimeCannon = 927f;
		maxShootTimeCannon = 1853f;
	}

	public virtual BehaviourDefinititon LIBFDOLBALL(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)LLGHNHMFCPN;
		TankBehaviourDefinititon tankBehaviourDefinititon2 = (TankBehaviourDefinititon)AJCHDECIFJC;
		TankBehaviourDefinititon tankBehaviourDefinititon3 = (TankBehaviourDefinititon)FIEIDMGECFG(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		tankBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.minShootTimeCannon, tankBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.maxShootTimeCannon, tankBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.damageCannon = Mathf.Lerp(tankBehaviourDefinititon.damageCannon, tankBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return tankBehaviourDefinititon3;
	}

	public override void NNECIPAKPIL(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.LPBNNPBPIPA(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual void NOKENABGOLH(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.FOICCNFHPAE(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual void GDGIKFPDIBM(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.MIKOLPDBCLK(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public override void DOLDGOGFJOI()
	{
		base.JNAEJHJGHNP();
		damageCannon = 756f;
		minShootTimeCannon = 1001f;
		maxShootTimeCannon = 1845f;
	}

	public virtual BehaviourDefinititon PCPFEIMMLHJ(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)LLGHNHMFCPN;
		TankBehaviourDefinititon tankBehaviourDefinititon2 = (TankBehaviourDefinititon)AJCHDECIFJC;
		TankBehaviourDefinititon tankBehaviourDefinititon3 = (TankBehaviourDefinititon)GIKHOPAMHPG(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		tankBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.minShootTimeCannon, tankBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.maxShootTimeCannon, tankBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.damageCannon = Mathf.Lerp(tankBehaviourDefinititon.damageCannon, tankBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return tankBehaviourDefinititon3;
	}

	public virtual void ONFHEPLCPBK(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.EFCOOLOEMIO(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual void PMKGPNBNACG(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.MBNKINKNPIG(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual BehaviourDefinititon JAGACICNFDL(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		TankBehaviourDefinititon tankBehaviourDefinititon = (TankBehaviourDefinititon)LLGHNHMFCPN;
		TankBehaviourDefinititon tankBehaviourDefinititon2 = (TankBehaviourDefinititon)AJCHDECIFJC;
		TankBehaviourDefinititon tankBehaviourDefinititon3 = (TankBehaviourDefinititon)base.KKCHFGFBABB(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		tankBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.minShootTimeCannon, tankBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(tankBehaviourDefinititon.maxShootTimeCannon, tankBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		tankBehaviourDefinititon3.damageCannon = Mathf.Lerp(tankBehaviourDefinititon.damageCannon, tankBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return tankBehaviourDefinititon3;
	}
}
