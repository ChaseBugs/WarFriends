using System;
using UnityEngine;

[Serializable]
public class CarBuggyBehaviourDefinititon : VehicleBehaviourDefinititon
{
	public float damageCannon;

	public float maxShootTimeCannon;

	public float minShootTimeCannon;

	public override void KFLADKOLPCM()
	{
		base.KFLADKOLPCM();
		maxShootTimeCannon = 0f;
		minShootTimeCannon = 0f;
		damageCannon = 0f;
	}

	public override void FPKDOOLFAMM()
	{
		JIKNJOFGFGJ();
		maxShootTimeCannon = 587f;
		minShootTimeCannon = 1923f;
		damageCannon = 1185f;
	}

	public virtual void LFHGKNJLIKP()
	{
		base.IMAHMPAIDJL();
		maxShootTimeCannon = 870f;
		minShootTimeCannon = 1988f;
		damageCannon = 1801f;
	}

	public virtual BehaviourDefinititon NAPOEHHFEHK(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon = (CarBuggyBehaviourDefinititon)LLGHNHMFCPN;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon2 = (CarBuggyBehaviourDefinititon)AJCHDECIFJC;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon3 = (CarBuggyBehaviourDefinititon)FKOLJINEJCG(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.minShootTimeCannon, carBuggyBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.maxShootTimeCannon, carBuggyBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.damageCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.damageCannon, carBuggyBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return carBuggyBehaviourDefinititon3;
	}

	public override BehaviourDefinititon BMLALFLBNKO(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon = (CarBuggyBehaviourDefinititon)LLGHNHMFCPN;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon2 = (CarBuggyBehaviourDefinititon)AJCHDECIFJC;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon3 = (CarBuggyBehaviourDefinititon)base.BMLALFLBNKO(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.minShootTimeCannon, carBuggyBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.maxShootTimeCannon, carBuggyBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.damageCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.damageCannon, carBuggyBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return carBuggyBehaviourDefinititon3;
	}

	public virtual void FDHKOEPGEJD()
	{
		DOLDGOGFJOI();
		maxShootTimeCannon = 989f;
		minShootTimeCannon = 134f;
		damageCannon = 259f;
	}

	public virtual BehaviourDefinititon HJBHLEIGCOJ(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon = (CarBuggyBehaviourDefinititon)LLGHNHMFCPN;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon2 = (CarBuggyBehaviourDefinititon)AJCHDECIFJC;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon3 = (CarBuggyBehaviourDefinititon)JFDIDIIHNMK(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.minShootTimeCannon, carBuggyBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.maxShootTimeCannon, carBuggyBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.damageCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.damageCannon, carBuggyBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return carBuggyBehaviourDefinititon3;
	}

	public virtual BehaviourDefinititon OMMFJPIBDPL(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon = (CarBuggyBehaviourDefinititon)LLGHNHMFCPN;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon2 = (CarBuggyBehaviourDefinititon)AJCHDECIFJC;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon3 = (CarBuggyBehaviourDefinititon)BNOINHIGGLH(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.minShootTimeCannon, carBuggyBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.maxShootTimeCannon, carBuggyBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.damageCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.damageCannon, carBuggyBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return carBuggyBehaviourDefinititon3;
	}

	public virtual void GCAHOBBFNDH()
	{
		DOLDGOGFJOI();
		maxShootTimeCannon = 245f;
		minShootTimeCannon = 118f;
		damageCannon = 1508f;
	}

	public override void HNCJFJPHNCA()
	{
		base.MDNAPECLMME();
		maxShootTimeCannon = 623f;
		minShootTimeCannon = 1234f;
		damageCannon = 134f;
	}

	public virtual BehaviourDefinititon CNFKLCGLMLI(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon = (CarBuggyBehaviourDefinititon)LLGHNHMFCPN;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon2 = (CarBuggyBehaviourDefinititon)AJCHDECIFJC;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon3 = (CarBuggyBehaviourDefinititon)GAJJIEPGECN(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.minShootTimeCannon, carBuggyBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.maxShootTimeCannon, carBuggyBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.damageCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.damageCannon, carBuggyBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return carBuggyBehaviourDefinititon3;
	}

	public override void AHPKBGKOBMK()
	{
		base.AHPKBGKOBMK();
		maxShootTimeCannon = 1252f;
		minShootTimeCannon = 898f;
		damageCannon = 169f;
	}

	public virtual void JMBGHDJKEFG(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.LBPNKGOOAPL(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual BehaviourDefinititon ACDDAJINGNB(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon = (CarBuggyBehaviourDefinititon)LLGHNHMFCPN;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon2 = (CarBuggyBehaviourDefinititon)AJCHDECIFJC;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon3 = (CarBuggyBehaviourDefinititon)base.NCLKBGAIDKO(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.minShootTimeCannon, carBuggyBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.maxShootTimeCannon, carBuggyBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.damageCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.damageCannon, carBuggyBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return carBuggyBehaviourDefinititon3;
	}

	public virtual void ELAHIHANNKD()
	{
		base.LFIIJFJHBDH();
		maxShootTimeCannon = 1319f;
		minShootTimeCannon = 1539f;
		damageCannon = 1202f;
	}

	public override void LFIIJFJHBDH()
	{
		base.IFBPEKJAPNB();
		maxShootTimeCannon = 1932f;
		minShootTimeCannon = 702f;
		damageCannon = 1082f;
	}

	public override BehaviourDefinititon MONDPJEGDIF(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon = (CarBuggyBehaviourDefinititon)LLGHNHMFCPN;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon2 = (CarBuggyBehaviourDefinititon)AJCHDECIFJC;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon3 = (CarBuggyBehaviourDefinititon)base.BMLALFLBNKO(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.minShootTimeCannon, carBuggyBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.maxShootTimeCannon, carBuggyBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.damageCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.damageCannon, carBuggyBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return carBuggyBehaviourDefinititon3;
	}

	public virtual void IEBFDGDAKKD(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.LPBNNPBPIPA(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual void EKDEIHINNEO(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.LBPNKGOOAPL(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual void CBBEFJLBKEG(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.EFCOOLOEMIO(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual void ILGFLFJIIKD()
	{
		JIKNJOFGFGJ();
		maxShootTimeCannon = 1910f;
		minShootTimeCannon = 132f;
		damageCannon = 841f;
	}

	public virtual void OMMKDNMKMBB()
	{
		CEFGHPBGDHJ();
		maxShootTimeCannon = 526f;
		minShootTimeCannon = 1883f;
		damageCannon = 1827f;
	}

	public virtual BehaviourDefinititon DEMCHICOAPH(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon = (CarBuggyBehaviourDefinititon)LLGHNHMFCPN;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon2 = (CarBuggyBehaviourDefinititon)AJCHDECIFJC;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon3 = (CarBuggyBehaviourDefinititon)OPOCLLEENEF(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.minShootTimeCannon, carBuggyBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.maxShootTimeCannon, carBuggyBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.damageCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.damageCannon, carBuggyBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return carBuggyBehaviourDefinititon3;
	}

	public virtual void MBEBLIHADLM(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.LLNPDHAHFDB(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual BehaviourDefinititon IMCEHOCJLDN(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon = (CarBuggyBehaviourDefinititon)LLGHNHMFCPN;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon2 = (CarBuggyBehaviourDefinititon)AJCHDECIFJC;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon3 = (CarBuggyBehaviourDefinititon)AFHECGBAKDG(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.minShootTimeCannon, carBuggyBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.maxShootTimeCannon, carBuggyBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.damageCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.damageCannon, carBuggyBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return carBuggyBehaviourDefinititon3;
	}

	public override BehaviourDefinititon NCLKBGAIDKO(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon = (CarBuggyBehaviourDefinititon)LLGHNHMFCPN;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon2 = (CarBuggyBehaviourDefinititon)AJCHDECIFJC;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon3 = (CarBuggyBehaviourDefinititon)base.BPEGKDHDHLH(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.minShootTimeCannon, carBuggyBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.maxShootTimeCannon, carBuggyBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.damageCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.damageCannon, carBuggyBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return carBuggyBehaviourDefinititon3;
	}

	public virtual void BHMNKIGMMPA(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.EFCOOLOEMIO(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual void CIJFOOHEFDJ(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.PBKKFFKLHKA(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public override BehaviourDefinititon BPEGKDHDHLH(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon = (CarBuggyBehaviourDefinititon)LLGHNHMFCPN;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon2 = (CarBuggyBehaviourDefinititon)AJCHDECIFJC;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon3 = (CarBuggyBehaviourDefinititon)GAJJIEPGECN(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.minShootTimeCannon, carBuggyBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.maxShootTimeCannon, carBuggyBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.damageCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.damageCannon, carBuggyBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return carBuggyBehaviourDefinititon3;
	}

	public override BehaviourDefinititon MFBEAKIFANE(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon = (CarBuggyBehaviourDefinititon)LLGHNHMFCPN;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon2 = (CarBuggyBehaviourDefinititon)AJCHDECIFJC;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon3 = (CarBuggyBehaviourDefinititon)FIEIDMGECFG(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.minShootTimeCannon, carBuggyBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.maxShootTimeCannon, carBuggyBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.damageCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.damageCannon, carBuggyBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return carBuggyBehaviourDefinititon3;
	}

	public virtual void MEANNEECHBF(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.MBNKINKNPIG(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual void CEEACPNJBIL()
	{
		EKLCHIEMDBP();
		maxShootTimeCannon = 1286f;
		minShootTimeCannon = 1412f;
		damageCannon = 158f;
	}

	public virtual void ADHAKGAGPLI(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.LBPNKGOOAPL(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual void NNBOFOFGNJC()
	{
		JIKNJOFGFGJ();
		maxShootTimeCannon = 1755f;
		minShootTimeCannon = 1551f;
		damageCannon = 958f;
	}

	public override void LGIPJECKKLE()
	{
		DOLDGOGFJOI();
		maxShootTimeCannon = 590f;
		minShootTimeCannon = 89f;
		damageCannon = 1715f;
	}

	public virtual void GFBHOHPNODL(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.NNECIPAKPIL(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual void FKOMLMOEAEB()
	{
		base.IFBPEKJAPNB();
		maxShootTimeCannon = 891f;
		minShootTimeCannon = 1911f;
		damageCannon = 889f;
	}

	public virtual void JHNEGGJAMNP()
	{
		FPDGMNFIHIL();
		maxShootTimeCannon = 1799f;
		minShootTimeCannon = 512f;
		damageCannon = 891f;
	}

	public virtual void KFDOKCJBFFF()
	{
		base.AHPKBGKOBMK();
		maxShootTimeCannon = 1447f;
		minShootTimeCannon = 1326f;
		damageCannon = 954f;
	}

	public virtual BehaviourDefinititon KDCMNECNDHP(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon = (CarBuggyBehaviourDefinititon)LLGHNHMFCPN;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon2 = (CarBuggyBehaviourDefinititon)AJCHDECIFJC;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon3 = (CarBuggyBehaviourDefinititon)KJIANOALDCF(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.minShootTimeCannon, carBuggyBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.maxShootTimeCannon, carBuggyBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.damageCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.damageCannon, carBuggyBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return carBuggyBehaviourDefinititon3;
	}

	public virtual void EKLBEMCFCBB(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.AKAFKDJEOCM(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual BehaviourDefinititon KPAPFKKMAJB(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon = (CarBuggyBehaviourDefinititon)LLGHNHMFCPN;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon2 = (CarBuggyBehaviourDefinititon)AJCHDECIFJC;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon3 = (CarBuggyBehaviourDefinititon)JHNHOFKAIII(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.minShootTimeCannon, carBuggyBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.maxShootTimeCannon, carBuggyBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.damageCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.damageCannon, carBuggyBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return carBuggyBehaviourDefinititon3;
	}

	public virtual void NIFJFEDGKIP(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.CKMPDJCJDGB(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual void BHFBCCJCPBI(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.PBKKFFKLHKA(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual BehaviourDefinititon CIIHMGPAMDD(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon = (CarBuggyBehaviourDefinititon)LLGHNHMFCPN;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon2 = (CarBuggyBehaviourDefinititon)AJCHDECIFJC;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon3 = (CarBuggyBehaviourDefinititon)BADMBJMHDPJ(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.minShootTimeCannon, carBuggyBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.maxShootTimeCannon, carBuggyBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.damageCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.damageCannon, carBuggyBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return carBuggyBehaviourDefinititon3;
	}

	public virtual void AKAMKBKLPGG()
	{
		base.KFLADKOLPCM();
		maxShootTimeCannon = 1150f;
		minShootTimeCannon = 1383f;
		damageCannon = 1543f;
	}

	public override void IMAHMPAIDJL()
	{
		base.MDNAPECLMME();
		maxShootTimeCannon = 1437f;
		minShootTimeCannon = 39f;
		damageCannon = 984f;
	}

	public virtual void BBAPPPIPLGD()
	{
		CEFGHPBGDHJ();
		maxShootTimeCannon = 937f;
		minShootTimeCannon = 221f;
		damageCannon = 856f;
	}

	public virtual void JEBIEHGPPFJ(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.PBKKFFKLHKA(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public override void NCMLOODDMCF(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.CKMPDJCJDGB(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual BehaviourDefinititon LLPCAHNMGCB(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon = (CarBuggyBehaviourDefinititon)LLGHNHMFCPN;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon2 = (CarBuggyBehaviourDefinititon)AJCHDECIFJC;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon3 = (CarBuggyBehaviourDefinititon)FKOLJINEJCG(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.minShootTimeCannon, carBuggyBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.maxShootTimeCannon, carBuggyBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.damageCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.damageCannon, carBuggyBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return carBuggyBehaviourDefinititon3;
	}

	public virtual void JOEDKIIAMAO()
	{
		DOLDGOGFJOI();
		maxShootTimeCannon = 49f;
		minShootTimeCannon = 23f;
		damageCannon = 1334f;
	}

	public virtual void FAINAOBKMKN()
	{
		base.LGIPJECKKLE();
		maxShootTimeCannon = 789f;
		minShootTimeCannon = 740f;
		damageCannon = 680f;
	}

	public virtual void KKHACPLEANP(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.GPAGBDBEPPO(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public override void BHAIOPCLJPM()
	{
		CEFGHPBGDHJ();
		maxShootTimeCannon = 873f;
		minShootTimeCannon = 326f;
		damageCannon = 394f;
	}

	public virtual void MGDCJDOJHEJ()
	{
		FPDGMNFIHIL();
		maxShootTimeCannon = 1033f;
		minShootTimeCannon = 1831f;
		damageCannon = 345f;
	}

	public virtual void HLFCCJFPAGA()
	{
		EAEEEKCAOIN();
		maxShootTimeCannon = 1987f;
		minShootTimeCannon = 521f;
		damageCannon = 515f;
	}

	public virtual void KNLCPCOJDLK(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.NNECIPAKPIL(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public override BehaviourDefinititon KOLNONBJGAJ(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon = (CarBuggyBehaviourDefinititon)LLGHNHMFCPN;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon2 = (CarBuggyBehaviourDefinititon)AJCHDECIFJC;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon3 = (CarBuggyBehaviourDefinititon)base.BPEGKDHDHLH(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.minShootTimeCannon, carBuggyBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.maxShootTimeCannon, carBuggyBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.damageCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.damageCannon, carBuggyBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return carBuggyBehaviourDefinititon3;
	}

	public virtual void HFMJHBMMJAF()
	{
		base.LFIIJFJHBDH();
		maxShootTimeCannon = 1141f;
		minShootTimeCannon = 765f;
		damageCannon = 1853f;
	}

	public virtual BehaviourDefinititon HDCIADOHGHC(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon = (CarBuggyBehaviourDefinititon)LLGHNHMFCPN;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon2 = (CarBuggyBehaviourDefinititon)AJCHDECIFJC;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon3 = (CarBuggyBehaviourDefinititon)base.KOLNONBJGAJ(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.minShootTimeCannon, carBuggyBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.maxShootTimeCannon, carBuggyBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.damageCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.damageCannon, carBuggyBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return carBuggyBehaviourDefinititon3;
	}

	public virtual BehaviourDefinititon IGJPKLDFJGD(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon = (CarBuggyBehaviourDefinititon)LLGHNHMFCPN;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon2 = (CarBuggyBehaviourDefinititon)AJCHDECIFJC;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon3 = (CarBuggyBehaviourDefinititon)AFHECGBAKDG(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.minShootTimeCannon, carBuggyBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.maxShootTimeCannon, carBuggyBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.damageCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.damageCannon, carBuggyBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return carBuggyBehaviourDefinititon3;
	}

	public virtual BehaviourDefinititon NLAKDMKFCEE(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon = (CarBuggyBehaviourDefinititon)LLGHNHMFCPN;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon2 = (CarBuggyBehaviourDefinititon)AJCHDECIFJC;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon3 = (CarBuggyBehaviourDefinititon)OPOCLLEENEF(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.minShootTimeCannon, carBuggyBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.maxShootTimeCannon, carBuggyBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.damageCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.damageCannon, carBuggyBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return carBuggyBehaviourDefinititon3;
	}

	public virtual void KEMMIOELHDE(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.EFCOOLOEMIO(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public override void CDLJAKLCDMG()
	{
		EKLCHIEMDBP();
		maxShootTimeCannon = 1856f;
		minShootTimeCannon = 482f;
		damageCannon = 1513f;
	}

	public virtual void FLMIDMJDDCK(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.LPBNNPBPIPA(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual void EBODHNKIIDK()
	{
		EAEEEKCAOIN();
		maxShootTimeCannon = 1548f;
		minShootTimeCannon = 1948f;
		damageCannon = 663f;
	}

	public virtual void AJFJGGOKDCB()
	{
		EAEEEKCAOIN();
		maxShootTimeCannon = 1540f;
		minShootTimeCannon = 917f;
		damageCannon = 484f;
	}

	public virtual void MMDPHICOMLH()
	{
		CEFGHPBGDHJ();
		maxShootTimeCannon = 1622f;
		minShootTimeCannon = 957f;
		damageCannon = 295f;
	}

	public virtual void GIOOJCHEGJF(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.PBKKFFKLHKA(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public override void MIKOLPDBCLK(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.MIKOLPDBCLK(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual void BDMIHIPFJJJ()
	{
		NGDPPPEBJGA();
		maxShootTimeCannon = 1262f;
		minShootTimeCannon = 1196f;
		damageCannon = 1694f;
	}

	public virtual BehaviourDefinititon DPKDPKFCCIN(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon = (CarBuggyBehaviourDefinititon)LLGHNHMFCPN;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon2 = (CarBuggyBehaviourDefinititon)AJCHDECIFJC;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon3 = (CarBuggyBehaviourDefinititon)JFDIDIIHNMK(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.minShootTimeCannon, carBuggyBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.maxShootTimeCannon, carBuggyBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.damageCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.damageCannon, carBuggyBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return carBuggyBehaviourDefinititon3;
	}

	public virtual void IKADBFAIKJA()
	{
		FPDGMNFIHIL();
		maxShootTimeCannon = 1655f;
		minShootTimeCannon = 960f;
		damageCannon = 1446f;
	}

	public virtual void INIGMMONCLM()
	{
		base.IMAHMPAIDJL();
		maxShootTimeCannon = 1158f;
		minShootTimeCannon = 591f;
		damageCannon = 326f;
	}

	public virtual BehaviourDefinititon HGMDOHANMJE(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon = (CarBuggyBehaviourDefinititon)LLGHNHMFCPN;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon2 = (CarBuggyBehaviourDefinititon)AJCHDECIFJC;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon3 = (CarBuggyBehaviourDefinititon)base.KOLNONBJGAJ(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.minShootTimeCannon, carBuggyBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.maxShootTimeCannon, carBuggyBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.damageCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.damageCannon, carBuggyBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return carBuggyBehaviourDefinititon3;
	}

	public override void MDNAPECLMME()
	{
		EGONLEGNLFO();
		maxShootTimeCannon = 71f;
		minShootTimeCannon = 963f;
		damageCannon = 1177f;
	}

	public virtual void AFEEEODBMLO(float MBACPAEEGIG, float DCFKGBKLHLF)
	{
		damageCannon *= MBACPAEEGIG;
		base.MBNKINKNPIG(MBACPAEEGIG, DCFKGBKLHLF);
	}

	public virtual void BBEJFJHJJPD()
	{
		DNMFDLADKEM();
		maxShootTimeCannon = 1560f;
		minShootTimeCannon = 1931f;
		damageCannon = 1988f;
	}

	public virtual BehaviourDefinititon JAGACICNFDL(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon = (CarBuggyBehaviourDefinititon)LLGHNHMFCPN;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon2 = (CarBuggyBehaviourDefinititon)AJCHDECIFJC;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon3 = (CarBuggyBehaviourDefinititon)GAJJIEPGECN(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.minShootTimeCannon, carBuggyBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.maxShootTimeCannon, carBuggyBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.damageCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.damageCannon, carBuggyBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return carBuggyBehaviourDefinititon3;
	}

	public override void IFBPEKJAPNB()
	{
		EKLCHIEMDBP();
		maxShootTimeCannon = 1655f;
		minShootTimeCannon = 1375f;
		damageCannon = 623f;
	}

	public virtual BehaviourDefinititon LHHDLLEDDAO(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon = (CarBuggyBehaviourDefinititon)LLGHNHMFCPN;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon2 = (CarBuggyBehaviourDefinititon)AJCHDECIFJC;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon3 = (CarBuggyBehaviourDefinititon)EOAOBHGGIKA(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.minShootTimeCannon, carBuggyBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.maxShootTimeCannon, carBuggyBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.damageCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.damageCannon, carBuggyBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return carBuggyBehaviourDefinititon3;
	}

	public virtual BehaviourDefinititon JMAHKNAGEDK(BehaviourDefinititon LLGHNHMFCPN, BehaviourDefinititon AJCHDECIFJC, float GACKNHPFGFM)
	{
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon = (CarBuggyBehaviourDefinititon)LLGHNHMFCPN;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon2 = (CarBuggyBehaviourDefinititon)AJCHDECIFJC;
		CarBuggyBehaviourDefinititon carBuggyBehaviourDefinititon3 = (CarBuggyBehaviourDefinititon)BFNDBKPGOJN(LLGHNHMFCPN, AJCHDECIFJC, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.minShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.minShootTimeCannon, carBuggyBehaviourDefinititon2.minShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.maxShootTimeCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.maxShootTimeCannon, carBuggyBehaviourDefinititon2.maxShootTimeCannon, GACKNHPFGFM);
		carBuggyBehaviourDefinititon3.damageCannon = Mathf.Lerp(carBuggyBehaviourDefinititon.damageCannon, carBuggyBehaviourDefinititon2.damageCannon, GACKNHPFGFM);
		return carBuggyBehaviourDefinititon3;
	}
}
