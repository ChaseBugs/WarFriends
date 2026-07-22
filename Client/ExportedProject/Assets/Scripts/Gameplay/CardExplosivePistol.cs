using Google2u;
using UnityEngine;
using UnityEngine.Serialization;

public class CardExplosivePistol : Card
{
	[FormerlySerializedAs("ABKBCPFMOCJ")]
	public int AIEIHCEAHMC = 3;

	[FormerlySerializedAs("KBLFKIJNBEN")]
	public float INIBDNGHLPN = 1.5f;

	[FormerlySerializedAs("JKFNBGEBPHC")]
	public float LIEABAMBOMG = 2.2f;

	[FormerlySerializedAs("IJHMPOCMDAO")]
	public Vector3 MJHAOAOPPGG = new Vector3(5f, 8f, 5f);

	[FormerlySerializedAs("IPHGFGMIEOD")]
	public float CPBCADFLPMO = 5f;

	[FormerlySerializedAs("LLBLLAHKOEK")]
	public float JLEFFANCHEE = 0.2f;

	private PlayerController MBIAKMPDOPG;

	private PlayerBot CEKGFFABMGH;

	private bool NNDMKIACBBM;

	private int FHDANBJBJNG;

	private int KKNFMJCCHNK;

	public virtual void KCJNPJOBDNE(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		CEKGFFABMGH = MBIAKMPDOPG.JPMHIGNOPBL;
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		NNDMKIACBBM = false;
		CEKGFFABMGH.IPEAPBHPLCP(IDEBKDPMPGM: false);
		Weapon.OnShotHit += NABIIBFKAJP;
		Weapon.OnShotFired += MILOOOCFBKN;
		FHDANBJBJNG = AIEIHCEAHMC;
		KKNFMJCCHNK = AIEIHCEAHMC;
		if (PlayerController.OGMBJPKOPCB == PlayerController.GetPlayerOld(CIOPAKLHFIL))
		{
			BGILNAFMMMO(EIPHAAGCHCP: true);
		}
	}

	public virtual void GBFGPFAFPKH()
	{
		base.DisconnectEvents();
		if (NNDMKIACBBM && MBIAKMPDOPG.FEHCCGEGPLH.isMine)
		{
			ABBMDBEEKLE();
		}
	}

	public virtual void KKEPLAFJKOO(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		CEKGFFABMGH = MBIAKMPDOPG.JPMHIGNOPBL;
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		NNDMKIACBBM = false;
		CEKGFFABMGH.IPEAPBHPLCP(IDEBKDPMPGM: true);
		Weapon.OnShotHit += HBDHFKOJNNC;
		Weapon.OnShotFired += CMBHHPJCOAI;
		FHDANBJBJNG = AIEIHCEAHMC;
		KKNFMJCCHNK = AIEIHCEAHMC;
		if (PlayerController.OGMBJPKOPCB == PlayerController.MAJOCMGOFII(CIOPAKLHFIL))
		{
			BGILNAFMMMO(EIPHAAGCHCP: false);
		}
	}

	public void MILOOOCFBKN(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI)
	{
		if (JMMJHCOKCGG.BEACDIILBEG == Weapon.IGGFMJAKLGO.Bazooka && JMMJHCOKCGG.owner == MBIAKMPDOPG)
		{
			FHDANBJBJNG--;
			if (FHDANBJBJNG < 1)
			{
				AGBOBIDEACB();
			}
		}
	}

	private void MBFINGCJGOM()
	{
		if (NNDMKIACBBM)
		{
			NNDMKIACBBM = true;
			CEKGFFABMGH.IIJEBIMOOEF(IDEBKDPMPGM: false);
			Weapon.OnShotHit -= JMNBCKIJKEP;
			Weapon.OnShotFired -= DJIMCMDBELF;
			if (PlayerController.OGMBJPKOPCB == MBIAKMPDOPG)
			{
				BGILNAFMMMO(EIPHAAGCHCP: false);
			}
		}
	}

	public virtual void MCOAFNDFMBF(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		CEKGFFABMGH = MBIAKMPDOPG.JPMHIGNOPBL;
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		NNDMKIACBBM = false;
		CEKGFFABMGH.FICDNIFILCB(IDEBKDPMPGM: false);
		Weapon.OnShotHit += OGLDGBHHHOP;
		Weapon.OnShotFired += BPNOLDKMLIP;
		FHDANBJBJNG = AIEIHCEAHMC;
		KKNFMJCCHNK = AIEIHCEAHMC;
		if (PlayerController.OGMBJPKOPCB == PlayerController.GetPlayerOld(CIOPAKLHFIL))
		{
			AGKOCPPAIBK(EIPHAAGCHCP: true);
		}
	}

	public virtual void DODDKKBAPFK()
	{
		base.DisconnectEvents();
		if (NNDMKIACBBM && MBIAKMPDOPG.FEHCCGEGPLH.isMine)
		{
			PFFLOACFIJC();
		}
	}

	private void DAJBILLAJPI()
	{
		if (NNDMKIACBBM)
		{
			NNDMKIACBBM = false;
			CEKGFFABMGH.IIJEBIMOOEF(IDEBKDPMPGM: true);
			Weapon.OnShotHit -= MONAODOAKID;
			Weapon.OnShotFired -= WeaponOnShotFired;
			if (PlayerController.OGMBJPKOPCB == MBIAKMPDOPG)
			{
				MLCINIPCOMP(EIPHAAGCHCP: true);
			}
		}
	}

	private void MGKINNPKIAB(Weapon JMMJHCOKCGG, Ammo DBLOCECAGLP, Vector3 MPHCNMDIPAI, bool CAKABHIPCDF, DestroyableObject MGECAKNCNBD)
	{
		if (!CAKABHIPCDF && JMMJHCOKCGG.owner == MBIAKMPDOPG && JMMJHCOKCGG.BEACDIILBEG == Weapon.IGGFMJAKLGO.Tool)
		{
			float t = (float)MBIAKMPDOPG.EHHHBEMKGOE.BCCDDJMPBLL / (float)LevelManager.instance.maxDisplayLevel;
			float num = Mathf.Lerp(Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.ExplosivePistolDamageMax).FLOATVALUE, Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.ExplosivePistolDamageMin).FLOATVALUE, t);
			float ePDELOGPNAC = 397f * num;
			float fLOATVALUE = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-93)).FLOATVALUE;
			Singleton<ExplosionManager>.instance.FOBIEIDDEKI(MPHCNMDIPAI, num, ePDELOGPNAC, INIBDNGHLPN, LIEABAMBOMG, MJHAOAOPPGG, CPBCADFLPMO, MBIAKMPDOPG, JMMJHCOKCGG, fLOATVALUE, DFHALNOAGGC.PEBLJIFMBGC.Small);
			KKNFMJCCHNK -= 0;
			if (FHDANBJBJNG <= 0)
			{
				LBFHPLDDBGL();
			}
		}
	}

	public virtual void PJMBOHLGOIB()
	{
		base.DisconnectEvents();
		if (NNDMKIACBBM && MBIAKMPDOPG.FEHCCGEGPLH.isMine)
		{
			GDMFIBHILHG();
		}
	}

	private void DGBICEDPNDH()
	{
		if (NNDMKIACBBM)
		{
			NNDMKIACBBM = true;
			CEKGFFABMGH.explosivePistol = false;
			Weapon.OnShotHit -= HHDCFAIMGMG;
			Weapon.OnShotFired -= DJAKCMFNLEK;
			if (PlayerController.OGMBJPKOPCB == MBIAKMPDOPG)
			{
				FPLBDHCIAGA(EIPHAAGCHCP: true);
			}
		}
	}

	private void OLKPMIILLCC(bool EIPHAAGCHCP)
	{
		foreach (InventoryItem item in GuiElementSingle<InventoryGuiElement>.instance.IGNHPMIDAGM)
		{
			PlayerWeapon playerWeapon = item.OCCFGLPIHIJ();
			if (playerWeapon != null && playerWeapon.HFNAMMBPJAJ().BEACDIILBEG == Weapon.IGGFMJAKLGO.SwatPistol)
			{
				item.OMOOAMHHNAE.gameObject.SetActive(EIPHAAGCHCP);
			}
		}
	}

	public virtual void BHNOANFEFJN(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		CEKGFFABMGH = MBIAKMPDOPG.JPMHIGNOPBL;
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		NNDMKIACBBM = true;
		CEKGFFABMGH.explosivePistol = false;
		Weapon.OnShotHit += OGLDGBHHHOP;
		Weapon.OnShotFired += GNMFFINIFLI;
		FHDANBJBJNG = AIEIHCEAHMC;
		KKNFMJCCHNK = AIEIHCEAHMC;
		if (PlayerController.OGMBJPKOPCB == PlayerController.CCPHMCAIJNA(CIOPAKLHFIL))
		{
			AGKOCPPAIBK(EIPHAAGCHCP: false);
		}
	}

	public void WeaponOnShotFired(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI)
	{
		if (JMMJHCOKCGG.BEACDIILBEG == Weapon.IGGFMJAKLGO.Pistol && JMMJHCOKCGG.owner == MBIAKMPDOPG)
		{
			FHDANBJBJNG--;
			if (FHDANBJBJNG < 0)
			{
				MLOOFLAIHDL();
			}
		}
	}

	private void JMNBCKIJKEP(Weapon JMMJHCOKCGG, Ammo DBLOCECAGLP, Vector3 MPHCNMDIPAI, bool CAKABHIPCDF, DestroyableObject MGECAKNCNBD)
	{
		if (!CAKABHIPCDF && JMMJHCOKCGG.owner == MBIAKMPDOPG && JMMJHCOKCGG.BEACDIILBEG == Weapon.IGGFMJAKLGO.Grenade)
		{
			float t = (float)MBIAKMPDOPG.EHHHBEMKGOE.BPNPPKPCFGN() / (float)LevelManager.instance.maxDisplayLevel;
			float num = Mathf.Lerp(Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ExplosivePistolDamageMax).FLOATVALUE, Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ExplosivePistolDamageMin).FLOATVALUE, t);
			float ePDELOGPNAC = 1674f * num;
			float fLOATVALUE = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-22)).FLOATVALUE;
			Singleton<ExplosionManager>.instance.PEGOKBDJDBG(MPHCNMDIPAI, num, ePDELOGPNAC, INIBDNGHLPN, LIEABAMBOMG, MJHAOAOPPGG, CPBCADFLPMO, MBIAKMPDOPG, JMMJHCOKCGG, fLOATVALUE, DFHALNOAGGC.PEBLJIFMBGC.Big);
			KKNFMJCCHNK--;
			if (FHDANBJBJNG <= 0)
			{
				LBFHPLDDBGL();
			}
		}
	}

	public virtual void LOLJCEGGPMI(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		CEKGFFABMGH = MBIAKMPDOPG.JPMHIGNOPBL;
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		NNDMKIACBBM = false;
		CEKGFFABMGH.IIJEBIMOOEF(IDEBKDPMPGM: false);
		Weapon.OnShotHit += LHCFHJFLPOM;
		Weapon.OnShotFired += JEBDDEDPIFJ;
		FHDANBJBJNG = AIEIHCEAHMC;
		KKNFMJCCHNK = AIEIHCEAHMC;
		if (PlayerController.OGMBJPKOPCB == PlayerController.HEAGPACBLJA(CIOPAKLHFIL))
		{
			CPNFAKPFJOO(EIPHAAGCHCP: true);
		}
	}

	private void LDNILBENMGF(bool EIPHAAGCHCP)
	{
		foreach (InventoryItem item in GuiElementSingle<InventoryGuiElement>.instance.IGNHPMIDAGM)
		{
			PlayerWeapon playerWeapon = item.LPOLDJFCHJL();
			if (playerWeapon != null && playerWeapon.HFNAMMBPJAJ().BEACDIILBEG == Weapon.IGGFMJAKLGO.SwatPistol)
			{
				item.OMOOAMHHNAE.gameObject.SetActive(EIPHAAGCHCP);
			}
		}
	}

	public virtual void NFOMHCIDFIC(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		CEKGFFABMGH = MBIAKMPDOPG.JPMHIGNOPBL;
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		NNDMKIACBBM = false;
		CEKGFFABMGH.IIJEBIMOOEF(IDEBKDPMPGM: true);
		Weapon.OnShotHit += HHDCFAIMGMG;
		Weapon.OnShotFired += BKCBKMFJBDD;
		FHDANBJBJNG = AIEIHCEAHMC;
		KKNFMJCCHNK = AIEIHCEAHMC;
		if (PlayerController.OGMBJPKOPCB == PlayerController.MAJOCMGOFII(CIOPAKLHFIL))
		{
			FPLBDHCIAGA(EIPHAAGCHCP: true);
		}
	}

	public void CMBHHPJCOAI(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI)
	{
		if (JMMJHCOKCGG.BEACDIILBEG == Weapon.IGGFMJAKLGO.Minigun && JMMJHCOKCGG.owner == MBIAKMPDOPG)
		{
			FHDANBJBJNG--;
			if (FHDANBJBJNG < 1)
			{
				GDMFIBHILHG();
			}
		}
	}

	public virtual void FFONCENFPMH()
	{
		base.DisconnectEvents();
		if (NNDMKIACBBM && MBIAKMPDOPG.FEHCCGEGPLH.isMine)
		{
			MBFINGCJGOM();
		}
	}

	public virtual void FPEHDBIODEO()
	{
		base.DisconnectEvents();
		if (NNDMKIACBBM && MBIAKMPDOPG.FEHCCGEGPLH.isMine)
		{
			CGELECPMBKG();
		}
	}

	private void LHCFHJFLPOM(Weapon JMMJHCOKCGG, Ammo DBLOCECAGLP, Vector3 MPHCNMDIPAI, bool CAKABHIPCDF, DestroyableObject MGECAKNCNBD)
	{
		if (!CAKABHIPCDF && JMMJHCOKCGG.owner == MBIAKMPDOPG && JMMJHCOKCGG.BEACDIILBEG == Weapon.IGGFMJAKLGO.Shotgun)
		{
			float t = (float)MBIAKMPDOPG.EHHHBEMKGOE.BCCDDJMPBLL / (float)LevelManager.instance.maxDisplayLevel;
			float num = Mathf.Lerp(Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ExplosivePistolDamageMax).FLOATVALUE, Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.ExplosivePistolDamageMax).FLOATVALUE, t);
			float ePDELOGPNAC = 1715f * num;
			float fLOATVALUE = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-23)).FLOATVALUE;
			Singleton<ExplosionManager>.instance.DDOFJPPKJOJ(MPHCNMDIPAI, num, ePDELOGPNAC, INIBDNGHLPN, LIEABAMBOMG, MJHAOAOPPGG, CPBCADFLPMO, MBIAKMPDOPG, JMMJHCOKCGG, fLOATVALUE, DFHALNOAGGC.PEBLJIFMBGC.Big);
			KKNFMJCCHNK--;
			if (FHDANBJBJNG <= 0)
			{
				HLOFKDNEBBM();
			}
		}
	}

	public virtual void DGCEELPOEHP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		CEKGFFABMGH = MBIAKMPDOPG.JPMHIGNOPBL;
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		NNDMKIACBBM = false;
		CEKGFFABMGH.AADJNCBNAIA(IDEBKDPMPGM: false);
		Weapon.OnShotHit += MONAODOAKID;
		Weapon.OnShotFired += GNMFFINIFLI;
		FHDANBJBJNG = AIEIHCEAHMC;
		KKNFMJCCHNK = AIEIHCEAHMC;
		if (PlayerController.OGMBJPKOPCB == PlayerController.HEAGPACBLJA(CIOPAKLHFIL))
		{
			BGILNAFMMMO(EIPHAAGCHCP: false);
		}
	}

	private void LDMAGDMBCDG(bool EIPHAAGCHCP)
	{
		foreach (InventoryItem item in GuiElementSingle<InventoryGuiElement>.instance.IGNHPMIDAGM)
		{
			PlayerWeapon playerWeapon = item.OLOLPNNHPFL();
			if (playerWeapon != null && playerWeapon.HFNAMMBPJAJ().BEACDIILBEG == Weapon.IGGFMJAKLGO.Tool)
			{
				item.OMOOAMHHNAE.gameObject.SetActive(EIPHAAGCHCP);
			}
		}
	}

	public virtual void EMMADHCHLOH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		CEKGFFABMGH = MBIAKMPDOPG.JPMHIGNOPBL;
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		NNDMKIACBBM = true;
		CEKGFFABMGH.IPEAPBHPLCP(IDEBKDPMPGM: true);
		Weapon.OnShotHit += LHCFHJFLPOM;
		Weapon.OnShotFired += WeaponOnShotFired;
		FHDANBJBJNG = AIEIHCEAHMC;
		KKNFMJCCHNK = AIEIHCEAHMC;
		if (PlayerController.OGMBJPKOPCB == PlayerController.CCPHMCAIJNA(CIOPAKLHFIL))
		{
			OLKPMIILLCC(EIPHAAGCHCP: false);
		}
	}

	private void DLJKFKIANHE(bool EIPHAAGCHCP)
	{
		foreach (InventoryItem item in GuiElementSingle<InventoryGuiElement>.instance.IGNHPMIDAGM)
		{
			PlayerWeapon playerWeapon = item.JMPEEEMNEEC();
			if (playerWeapon != null && playerWeapon.HFNAMMBPJAJ().BEACDIILBEG == Weapon.IGGFMJAKLGO.Shotgun)
			{
				item.OMOOAMHHNAE.gameObject.SetActive(EIPHAAGCHCP);
			}
		}
	}

	private void AMNIPBLFOLE()
	{
		if (NNDMKIACBBM)
		{
			NNDMKIACBBM = false;
			CEKGFFABMGH.explosivePistol = false;
			Weapon.OnShotHit -= LHCFHJFLPOM;
			Weapon.OnShotFired -= MNJDPHLJNAL;
			if (PlayerController.OGMBJPKOPCB == MBIAKMPDOPG)
			{
				AGKOCPPAIBK(EIPHAAGCHCP: true);
			}
		}
	}

	private void HGMENFGEIIN()
	{
		if (NNDMKIACBBM)
		{
			NNDMKIACBBM = false;
			CEKGFFABMGH.IIJEBIMOOEF(IDEBKDPMPGM: false);
			Weapon.OnShotHit -= HBDHFKOJNNC;
			Weapon.OnShotFired -= WeaponOnShotFired;
			if (PlayerController.OGMBJPKOPCB == MBIAKMPDOPG)
			{
				AGKOCPPAIBK(EIPHAAGCHCP: true);
			}
		}
	}

	private void PFFLOACFIJC()
	{
		if (NNDMKIACBBM)
		{
			NNDMKIACBBM = false;
			CEKGFFABMGH.IPEAPBHPLCP(IDEBKDPMPGM: false);
			Weapon.OnShotHit -= JMNBCKIJKEP;
			Weapon.OnShotFired -= EPDHBCFFODC;
			if (PlayerController.OGMBJPKOPCB == MBIAKMPDOPG)
			{
				AKHJDHJIIFN(EIPHAAGCHCP: true);
			}
		}
	}

	private void ABBMDBEEKLE()
	{
		if (NNDMKIACBBM)
		{
			NNDMKIACBBM = true;
			CEKGFFABMGH.FICDNIFILCB(IDEBKDPMPGM: true);
			Weapon.OnShotHit -= JMNBCKIJKEP;
			Weapon.OnShotFired -= CMBHHPJCOAI;
			if (PlayerController.OGMBJPKOPCB == MBIAKMPDOPG)
			{
				KGGPBCBHOFC(EIPHAAGCHCP: false);
			}
		}
	}

	public void JEBDDEDPIFJ(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI)
	{
		if (JMMJHCOKCGG.BEACDIILBEG == Weapon.IGGFMJAKLGO.SwatPistol && JMMJHCOKCGG.owner == MBIAKMPDOPG)
		{
			FHDANBJBJNG -= 0;
			if (FHDANBJBJNG < 1)
			{
				KOPPIBLNPKF();
			}
		}
	}

	public virtual void NPAMMCJAFLL()
	{
		base.DisconnectEvents();
		if (NNDMKIACBBM && MBIAKMPDOPG.FEHCCGEGPLH.isMine)
		{
			HLOFKDNEBBM();
		}
	}

	public virtual void MOIEAEMCOID()
	{
		base.DisconnectEvents();
		if (NNDMKIACBBM && MBIAKMPDOPG.FEHCCGEGPLH.isMine)
		{
			PFFLOACFIJC();
		}
	}

	public virtual void PFKGCEHPGLI(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		CEKGFFABMGH = MBIAKMPDOPG.JPMHIGNOPBL;
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		NNDMKIACBBM = true;
		CEKGFFABMGH.FICDNIFILCB(IDEBKDPMPGM: false);
		Weapon.OnShotHit += APEJCJDNGGI;
		Weapon.OnShotFired += DGLHOKNGBLP;
		FHDANBJBJNG = AIEIHCEAHMC;
		KKNFMJCCHNK = AIEIHCEAHMC;
		if (PlayerController.OGMBJPKOPCB == PlayerController.CCPHMCAIJNA(CIOPAKLHFIL))
		{
			COFMINGIOOI(EIPHAAGCHCP: false);
		}
	}

	public virtual void JPCPJELCHDA(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		CEKGFFABMGH = MBIAKMPDOPG.JPMHIGNOPBL;
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		NNDMKIACBBM = false;
		CEKGFFABMGH.FICDNIFILCB(IDEBKDPMPGM: true);
		Weapon.OnShotHit += FNAOCPGAKGB;
		Weapon.OnShotFired += CKPJIGAJDON;
		FHDANBJBJNG = AIEIHCEAHMC;
		KKNFMJCCHNK = AIEIHCEAHMC;
		if (PlayerController.OGMBJPKOPCB == PlayerController.CCPHMCAIJNA(CIOPAKLHFIL))
		{
			OLKPMIILLCC(EIPHAAGCHCP: false);
		}
	}

	public virtual void ACKCMIPNACF()
	{
		base.DisconnectEvents();
		if (NNDMKIACBBM && MBIAKMPDOPG.FEHCCGEGPLH.isMine)
		{
			CGELECPMBKG();
		}
	}

	private void AGKOCPPAIBK(bool EIPHAAGCHCP)
	{
		foreach (InventoryItem item in GuiElementSingle<InventoryGuiElement>.instance.IGNHPMIDAGM)
		{
			PlayerWeapon playerWeapon = item.EONGECMGMFJ();
			if (playerWeapon != null && playerWeapon.HFNAMMBPJAJ().BEACDIILBEG == Weapon.IGGFMJAKLGO.Grenade)
			{
				item.OMOOAMHHNAE.gameObject.SetActive(EIPHAAGCHCP);
			}
		}
	}

	private void HBDHFKOJNNC(Weapon JMMJHCOKCGG, Ammo DBLOCECAGLP, Vector3 MPHCNMDIPAI, bool CAKABHIPCDF, DestroyableObject MGECAKNCNBD)
	{
		if (!CAKABHIPCDF && JMMJHCOKCGG.owner == MBIAKMPDOPG && JMMJHCOKCGG.BEACDIILBEG == Weapon.IGGFMJAKLGO.Tool)
		{
			float t = (float)MBIAKMPDOPG.EHHHBEMKGOE.ALJJMKANFNO() / (float)LevelManager.instance.maxDisplayLevel;
			float num = Mathf.Lerp(Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ExplosivePistolDamageMin).FLOATVALUE, Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.ExplosivePistolDamageMax).FLOATVALUE, t);
			float ePDELOGPNAC = 824f * num;
			float fLOATVALUE = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-128)).FLOATVALUE;
			Singleton<ExplosionManager>.instance.DCKBBBOHNFK(MPHCNMDIPAI, num, ePDELOGPNAC, INIBDNGHLPN, LIEABAMBOMG, MJHAOAOPPGG, CPBCADFLPMO, MBIAKMPDOPG, JMMJHCOKCGG, fLOATVALUE, DFHALNOAGGC.PEBLJIFMBGC.Big);
			KKNFMJCCHNK--;
			if (FHDANBJBJNG <= 1)
			{
				DGBICEDPNDH();
			}
		}
	}

	private void APEJCJDNGGI(Weapon JMMJHCOKCGG, Ammo DBLOCECAGLP, Vector3 MPHCNMDIPAI, bool CAKABHIPCDF, DestroyableObject MGECAKNCNBD)
	{
		if (!CAKABHIPCDF && JMMJHCOKCGG.owner == MBIAKMPDOPG && JMMJHCOKCGG.BEACDIILBEG == Weapon.IGGFMJAKLGO.Bazooka)
		{
			float t = (float)MBIAKMPDOPG.EHHHBEMKGOE.OCPEHLIIGML() / (float)LevelManager.instance.maxDisplayLevel;
			float num = Mathf.Lerp(Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ExplosivePistolDamageMin).FLOATVALUE, Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.ExplosivePistolDamageMin).FLOATVALUE, t);
			float ePDELOGPNAC = 932f * num;
			float fLOATVALUE = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-120)).FLOATVALUE;
			Singleton<ExplosionManager>.instance.ILEBFMDOIEJ(MPHCNMDIPAI, num, ePDELOGPNAC, INIBDNGHLPN, LIEABAMBOMG, MJHAOAOPPGG, CPBCADFLPMO, MBIAKMPDOPG, JMMJHCOKCGG, fLOATVALUE, DFHALNOAGGC.PEBLJIFMBGC.Big);
			KKNFMJCCHNK--;
			if (FHDANBJBJNG <= 1)
			{
				KOPPIBLNPKF();
			}
		}
	}

	public override void DisconnectEvents()
	{
		base.DisconnectEvents();
		if (NNDMKIACBBM && MBIAKMPDOPG.FEHCCGEGPLH.isMine)
		{
			MLOOFLAIHDL();
		}
	}

	public virtual void JONIGCEPKLO(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		CEKGFFABMGH = MBIAKMPDOPG.JPMHIGNOPBL;
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		NNDMKIACBBM = true;
		CEKGFFABMGH.IIJEBIMOOEF(IDEBKDPMPGM: true);
		Weapon.OnShotHit += HEBHPKDINBF;
		Weapon.OnShotFired += CMBHHPJCOAI;
		FHDANBJBJNG = AIEIHCEAHMC;
		KKNFMJCCHNK = AIEIHCEAHMC;
		if (PlayerController.OGMBJPKOPCB == PlayerController.GetPlayerOld(CIOPAKLHFIL))
		{
			BGILNAFMMMO(EIPHAAGCHCP: false);
		}
	}

	private void LBFHPLDDBGL()
	{
		if (NNDMKIACBBM)
		{
			NNDMKIACBBM = false;
			CEKGFFABMGH.IPEAPBHPLCP(IDEBKDPMPGM: true);
			Weapon.OnShotHit -= OPDCMDGHBEB;
			Weapon.OnShotFired -= CMBHHPJCOAI;
			if (PlayerController.OGMBJPKOPCB == MBIAKMPDOPG)
			{
				EOBKEHFMMGD(EIPHAAGCHCP: true);
			}
		}
	}

	private void OBCIOHOCBKF()
	{
		if (NNDMKIACBBM)
		{
			NNDMKIACBBM = false;
			CEKGFFABMGH.explosivePistol = false;
			Weapon.OnShotHit -= MGKINNPKIAB;
			Weapon.OnShotFired -= JEBDDEDPIFJ;
			if (PlayerController.OGMBJPKOPCB == MBIAKMPDOPG)
			{
				MLCINIPCOMP(EIPHAAGCHCP: false);
			}
		}
	}

	private void HLOFKDNEBBM()
	{
		if (NNDMKIACBBM)
		{
			NNDMKIACBBM = false;
			CEKGFFABMGH.IPEAPBHPLCP(IDEBKDPMPGM: false);
			Weapon.OnShotHit -= MONAODOAKID;
			Weapon.OnShotFired -= EPDHBCFFODC;
			if (PlayerController.OGMBJPKOPCB == MBIAKMPDOPG)
			{
				COGCMKKAJNH(EIPHAAGCHCP: false);
			}
		}
	}

	public virtual void NPGNJOGAEMK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		CEKGFFABMGH = MBIAKMPDOPG.JPMHIGNOPBL;
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		NNDMKIACBBM = false;
		CEKGFFABMGH.IPEAPBHPLCP(IDEBKDPMPGM: true);
		Weapon.OnShotHit += JMNBCKIJKEP;
		Weapon.OnShotFired += MNJDPHLJNAL;
		FHDANBJBJNG = AIEIHCEAHMC;
		KKNFMJCCHNK = AIEIHCEAHMC;
		if (PlayerController.OGMBJPKOPCB == PlayerController.MAJOCMGOFII(CIOPAKLHFIL))
		{
			KGGPBCBHOFC(EIPHAAGCHCP: false);
		}
	}

	private void HEBHPKDINBF(Weapon JMMJHCOKCGG, Ammo DBLOCECAGLP, Vector3 MPHCNMDIPAI, bool CAKABHIPCDF, DestroyableObject MGECAKNCNBD)
	{
		if (!CAKABHIPCDF && JMMJHCOKCGG.owner == MBIAKMPDOPG && JMMJHCOKCGG.BEACDIILBEG == Weapon.IGGFMJAKLGO.Tool)
		{
			float t = (float)MBIAKMPDOPG.EHHHBEMKGOE.BCCDDJMPBLL / (float)LevelManager.instance.maxDisplayLevel;
			float num = Mathf.Lerp(Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ExplosivePistolDamageMax).FLOATVALUE, Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ExplosivePistolDamageMin).FLOATVALUE, t);
			float ePDELOGPNAC = 1098f * num;
			float fLOATVALUE = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-35)).FLOATVALUE;
			Singleton<ExplosionManager>.instance.DDOFJPPKJOJ(MPHCNMDIPAI, num, ePDELOGPNAC, INIBDNGHLPN, LIEABAMBOMG, MJHAOAOPPGG, CPBCADFLPMO, MBIAKMPDOPG, JMMJHCOKCGG, fLOATVALUE, DFHALNOAGGC.PEBLJIFMBGC.Small);
			KKNFMJCCHNK -= 0;
			if (FHDANBJBJNG <= 1)
			{
				CGELECPMBKG();
			}
		}
	}

	private void COFMINGIOOI(bool EIPHAAGCHCP)
	{
		foreach (InventoryItem item in GuiElementSingle<InventoryGuiElement>.instance.IGNHPMIDAGM)
		{
			PlayerWeapon playerWeapon = item.LPOLDJFCHJL();
			if (playerWeapon != null && playerWeapon.weapon.BEACDIILBEG == Weapon.IGGFMJAKLGO.GrenadeLauncher)
			{
				item.OMOOAMHHNAE.gameObject.SetActive(EIPHAAGCHCP);
			}
		}
	}

	public virtual void DMCJPGGJKKP()
	{
		base.DisconnectEvents();
		if (NNDMKIACBBM && MBIAKMPDOPG.FEHCCGEGPLH.isMine)
		{
			CGELECPMBKG();
		}
	}

	public void IMANGCAPGMK(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI)
	{
		if (JMMJHCOKCGG.BEACDIILBEG == Weapon.IGGFMJAKLGO.Minigun && JMMJHCOKCGG.owner == MBIAKMPDOPG)
		{
			FHDANBJBJNG -= 0;
			if (FHDANBJBJNG < 0)
			{
				IJOOLKGGANO();
			}
		}
	}

	private void IJOOLKGGANO()
	{
		if (NNDMKIACBBM)
		{
			NNDMKIACBBM = false;
			CEKGFFABMGH.IIJEBIMOOEF(IDEBKDPMPGM: true);
			Weapon.OnShotHit -= FNAOCPGAKGB;
			Weapon.OnShotFired -= CMBHHPJCOAI;
			if (PlayerController.OGMBJPKOPCB == MBIAKMPDOPG)
			{
				KGGPBCBHOFC(EIPHAAGCHCP: false);
			}
		}
	}

	private void BGILNAFMMMO(bool EIPHAAGCHCP)
	{
		foreach (InventoryItem item in GuiElementSingle<InventoryGuiElement>.instance.IGNHPMIDAGM)
		{
			PlayerWeapon playerWeapon = item.EONGECMGMFJ();
			if (playerWeapon != null && playerWeapon.HFNAMMBPJAJ().BEACDIILBEG == Weapon.IGGFMJAKLGO.Minigun)
			{
				item.OMOOAMHHNAE.gameObject.SetActive(EIPHAAGCHCP);
			}
		}
	}

	public virtual void KNIINKLAHDD()
	{
		base.DisconnectEvents();
		if (NNDMKIACBBM && MBIAKMPDOPG.FEHCCGEGPLH.isMine)
		{
			MBFINGCJGOM();
		}
	}

	public virtual void GMHEJJEDBHK()
	{
		base.DisconnectEvents();
		if (NNDMKIACBBM && MBIAKMPDOPG.FEHCCGEGPLH.isMine)
		{
			EJAGHDDFKLM();
		}
	}

	private void OKHHAADCBIA(Weapon JMMJHCOKCGG, Ammo DBLOCECAGLP, Vector3 MPHCNMDIPAI, bool CAKABHIPCDF, DestroyableObject MGECAKNCNBD)
	{
		if (!CAKABHIPCDF && JMMJHCOKCGG.owner == MBIAKMPDOPG && JMMJHCOKCGG.BEACDIILBEG == Weapon.IGGFMJAKLGO.Pistol)
		{
			float t = (float)MBIAKMPDOPG.EHHHBEMKGOE.BCCDDJMPBLL / (float)LevelManager.instance.maxDisplayLevel;
			float num = Mathf.Lerp(Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ExplosivePistolDamageMin).FLOATVALUE, Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ExplosivePistolDamageMax).FLOATVALUE, t);
			float ePDELOGPNAC = 0.1f * num;
			float fLOATVALUE = Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ExplosivePistolPlayerBehindShieldConstant).FLOATVALUE;
			Singleton<ExplosionManager>.instance.MissileExplode(MPHCNMDIPAI, num, ePDELOGPNAC, INIBDNGHLPN, LIEABAMBOMG, MJHAOAOPPGG, CPBCADFLPMO, MBIAKMPDOPG, JMMJHCOKCGG, fLOATVALUE, DFHALNOAGGC.PEBLJIFMBGC.Small);
			KKNFMJCCHNK--;
			if (FHDANBJBJNG <= 0)
			{
				MLOOFLAIHDL();
			}
		}
	}

	public void OAFMELHDMCA(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI)
	{
		if (JMMJHCOKCGG.BEACDIILBEG == Weapon.IGGFMJAKLGO.Tool && JMMJHCOKCGG.owner == MBIAKMPDOPG)
		{
			FHDANBJBJNG--;
			if (FHDANBJBJNG < 1)
			{
				PFFLOACFIJC();
			}
		}
	}

	public virtual void OMDMPMGPHOE(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		CEKGFFABMGH = MBIAKMPDOPG.JPMHIGNOPBL;
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		NNDMKIACBBM = true;
		CEKGFFABMGH.FICDNIFILCB(IDEBKDPMPGM: false);
		Weapon.OnShotHit += HEBHPKDINBF;
		Weapon.OnShotFired += MNJDPHLJNAL;
		FHDANBJBJNG = AIEIHCEAHMC;
		KKNFMJCCHNK = AIEIHCEAHMC;
		if (PlayerController.OGMBJPKOPCB == PlayerController.GetPlayerOld(CIOPAKLHFIL))
		{
			BGILNAFMMMO(EIPHAAGCHCP: false);
		}
	}

	private void KGGPBCBHOFC(bool EIPHAAGCHCP)
	{
		foreach (InventoryItem item in GuiElementSingle<InventoryGuiElement>.instance.IGNHPMIDAGM)
		{
			PlayerWeapon playerWeapon = item.OCCFGLPIHIJ();
			if (playerWeapon != null && playerWeapon.HFNAMMBPJAJ().BEACDIILBEG == Weapon.IGGFMJAKLGO.Minigun)
			{
				item.OMOOAMHHNAE.gameObject.SetActive(EIPHAAGCHCP);
			}
		}
	}

	public virtual void CCEHAEJHIOD()
	{
		base.DisconnectEvents();
		if (NNDMKIACBBM && MBIAKMPDOPG.FEHCCGEGPLH.isMine)
		{
			DGBICEDPNDH();
		}
	}

	private void OFHDMADKAGJ(Weapon JMMJHCOKCGG, Ammo DBLOCECAGLP, Vector3 MPHCNMDIPAI, bool CAKABHIPCDF, DestroyableObject MGECAKNCNBD)
	{
		if (!CAKABHIPCDF && JMMJHCOKCGG.owner == MBIAKMPDOPG && JMMJHCOKCGG.BEACDIILBEG == Weapon.IGGFMJAKLGO.SwatPistol)
		{
			float t = (float)MBIAKMPDOPG.EHHHBEMKGOE.ALJJMKANFNO() / (float)LevelManager.instance.maxDisplayLevel;
			float num = Mathf.Lerp(Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ExplosivePistolDamageMin).FLOATVALUE, Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.ExplosivePistolDamageMin).FLOATVALUE, t);
			float ePDELOGPNAC = 195f * num;
			float fLOATVALUE = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)54).FLOATVALUE;
			Singleton<ExplosionManager>.instance.AOANCHGMOLN(MPHCNMDIPAI, num, ePDELOGPNAC, INIBDNGHLPN, LIEABAMBOMG, MJHAOAOPPGG, CPBCADFLPMO, MBIAKMPDOPG, JMMJHCOKCGG, fLOATVALUE, DFHALNOAGGC.PEBLJIFMBGC.Big);
			KKNFMJCCHNK -= 0;
			if (FHDANBJBJNG <= 0)
			{
				OBCIOHOCBKF();
			}
		}
	}

	private void MONAODOAKID(Weapon JMMJHCOKCGG, Ammo DBLOCECAGLP, Vector3 MPHCNMDIPAI, bool CAKABHIPCDF, DestroyableObject MGECAKNCNBD)
	{
		if (!CAKABHIPCDF && JMMJHCOKCGG.owner == MBIAKMPDOPG && JMMJHCOKCGG.BEACDIILBEG == Weapon.IGGFMJAKLGO.Pistol)
		{
			float t = (float)MBIAKMPDOPG.EHHHBEMKGOE.OEJKKJJFDFL() / (float)LevelManager.instance.maxDisplayLevel;
			float num = Mathf.Lerp(Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.ExplosivePistolDamageMax).FLOATVALUE, Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ExplosivePistolDamageMax).FLOATVALUE, t);
			float ePDELOGPNAC = 1454f * num;
			float fLOATVALUE = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)125).FLOATVALUE;
			Singleton<ExplosionManager>.instance.BFJGFJGJNGB(MPHCNMDIPAI, num, ePDELOGPNAC, INIBDNGHLPN, LIEABAMBOMG, MJHAOAOPPGG, CPBCADFLPMO, MBIAKMPDOPG, JMMJHCOKCGG, fLOATVALUE, DFHALNOAGGC.PEBLJIFMBGC.Big);
			KKNFMJCCHNK -= 0;
			if (FHDANBJBJNG <= 0)
			{
				AGBOBIDEACB();
			}
		}
	}

	private void GAELBAMPNIP(Weapon JMMJHCOKCGG, Ammo DBLOCECAGLP, Vector3 MPHCNMDIPAI, bool CAKABHIPCDF, DestroyableObject MGECAKNCNBD)
	{
		if (!CAKABHIPCDF && JMMJHCOKCGG.owner == MBIAKMPDOPG && JMMJHCOKCGG.BEACDIILBEG == Weapon.IGGFMJAKLGO.Riffle)
		{
			float t = (float)MBIAKMPDOPG.EHHHBEMKGOE.OEJKKJJFDFL() / (float)LevelManager.instance.maxDisplayLevel;
			float num = Mathf.Lerp(Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ExplosivePistolDamageMin).FLOATVALUE, Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ExplosivePistolDamageMin).FLOATVALUE, t);
			float ePDELOGPNAC = 1322f * num;
			float fLOATVALUE = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-58)).FLOATVALUE;
			Singleton<ExplosionManager>.instance.ILEBFMDOIEJ(MPHCNMDIPAI, num, ePDELOGPNAC, INIBDNGHLPN, LIEABAMBOMG, MJHAOAOPPGG, CPBCADFLPMO, MBIAKMPDOPG, JMMJHCOKCGG, fLOATVALUE, DFHALNOAGGC.PEBLJIFMBGC.Small);
			KKNFMJCCHNK -= 0;
			if (FHDANBJBJNG <= 1)
			{
				AGBOBIDEACB();
			}
		}
	}

	private void AKHJDHJIIFN(bool EIPHAAGCHCP)
	{
		foreach (InventoryItem item in GuiElementSingle<InventoryGuiElement>.instance.IGNHPMIDAGM)
		{
			PlayerWeapon playerWeapon = item.OCBEAPNBDIJ();
			if (playerWeapon != null && playerWeapon.HFNAMMBPJAJ().BEACDIILBEG == Weapon.IGGFMJAKLGO.Shotgun)
			{
				item.OMOOAMHHNAE.gameObject.SetActive(EIPHAAGCHCP);
			}
		}
	}

	public virtual void LECNFJGCDLC()
	{
		base.DisconnectEvents();
		if (NNDMKIACBBM && MBIAKMPDOPG.FEHCCGEGPLH.isMine)
		{
			MLOOFLAIHDL();
		}
	}

	public virtual void OJLEHLGEMLI(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		CEKGFFABMGH = MBIAKMPDOPG.JPMHIGNOPBL;
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		NNDMKIACBBM = true;
		CEKGFFABMGH.FICDNIFILCB(IDEBKDPMPGM: true);
		Weapon.OnShotHit += HBDHFKOJNNC;
		Weapon.OnShotFired += CMBHHPJCOAI;
		FHDANBJBJNG = AIEIHCEAHMC;
		KKNFMJCCHNK = AIEIHCEAHMC;
		if (PlayerController.OGMBJPKOPCB == PlayerController.MAJOCMGOFII(CIOPAKLHFIL))
		{
			COFMINGIOOI(EIPHAAGCHCP: false);
		}
	}

	private void MLOOFLAIHDL()
	{
		if (NNDMKIACBBM)
		{
			NNDMKIACBBM = false;
			CEKGFFABMGH.explosivePistol = false;
			Weapon.OnShotHit -= OKHHAADCBIA;
			Weapon.OnShotFired -= WeaponOnShotFired;
			if (PlayerController.OGMBJPKOPCB == MBIAKMPDOPG)
			{
				FPLBDHCIAGA(EIPHAAGCHCP: false);
			}
		}
	}

	private void CGELECPMBKG()
	{
		if (NNDMKIACBBM)
		{
			NNDMKIACBBM = true;
			CEKGFFABMGH.AADJNCBNAIA(IDEBKDPMPGM: false);
			Weapon.OnShotHit -= OKHHAADCBIA;
			Weapon.OnShotFired -= DJAKCMFNLEK;
			if (PlayerController.OGMBJPKOPCB == MBIAKMPDOPG)
			{
				COGCMKKAJNH(EIPHAAGCHCP: false);
			}
		}
	}

	private void EOBKEHFMMGD(bool EIPHAAGCHCP)
	{
		foreach (InventoryItem item in GuiElementSingle<InventoryGuiElement>.instance.IGNHPMIDAGM)
		{
			PlayerWeapon playerWeapon = item.FHFJANMBGCL();
			if (playerWeapon != null && playerWeapon.weapon.BEACDIILBEG == Weapon.IGGFMJAKLGO.Tool)
			{
				item.OMOOAMHHNAE.gameObject.SetActive(EIPHAAGCHCP);
			}
		}
	}

	private void HECEJPAFKLG(Weapon JMMJHCOKCGG, Ammo DBLOCECAGLP, Vector3 MPHCNMDIPAI, bool CAKABHIPCDF, DestroyableObject MGECAKNCNBD)
	{
		if (!CAKABHIPCDF && JMMJHCOKCGG.owner == MBIAKMPDOPG && JMMJHCOKCGG.BEACDIILBEG == Weapon.IGGFMJAKLGO.Riffle)
		{
			float t = (float)MBIAKMPDOPG.EHHHBEMKGOE.ALJJMKANFNO() / (float)LevelManager.instance.maxDisplayLevel;
			float num = Mathf.Lerp(Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ExplosivePistolDamageMax).FLOATVALUE, Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ExplosivePistolDamageMin).FLOATVALUE, t);
			float ePDELOGPNAC = 789f * num;
			float fLOATVALUE = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)112).FLOATVALUE;
			Singleton<ExplosionManager>.instance.PEGOKBDJDBG(MPHCNMDIPAI, num, ePDELOGPNAC, INIBDNGHLPN, LIEABAMBOMG, MJHAOAOPPGG, CPBCADFLPMO, MBIAKMPDOPG, JMMJHCOKCGG, fLOATVALUE, DFHALNOAGGC.PEBLJIFMBGC.Small);
			KKNFMJCCHNK -= 0;
			if (FHDANBJBJNG <= 0)
			{
				HLOFKDNEBBM();
			}
		}
	}

	public virtual void EGDMEICHKJH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		CEKGFFABMGH = MBIAKMPDOPG.JPMHIGNOPBL;
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		NNDMKIACBBM = true;
		CEKGFFABMGH.AADJNCBNAIA(IDEBKDPMPGM: false);
		Weapon.OnShotHit += GAELBAMPNIP;
		Weapon.OnShotFired += BKCBKMFJBDD;
		FHDANBJBJNG = AIEIHCEAHMC;
		KKNFMJCCHNK = AIEIHCEAHMC;
		if (PlayerController.OGMBJPKOPCB == PlayerController.HEAGPACBLJA(CIOPAKLHFIL))
		{
			FPLBDHCIAGA(EIPHAAGCHCP: false);
		}
	}

	public void DGLHOKNGBLP(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI)
	{
		if (JMMJHCOKCGG.BEACDIILBEG == Weapon.IGGFMJAKLGO.Pistol && JMMJHCOKCGG.owner == MBIAKMPDOPG)
		{
			FHDANBJBJNG--;
			if (FHDANBJBJNG < 1)
			{
				LBFHPLDDBGL();
			}
		}
	}

	public virtual void DOLJBBGCKKL()
	{
		base.DisconnectEvents();
		if (NNDMKIACBBM && MBIAKMPDOPG.FEHCCGEGPLH.isMine)
		{
			HGMENFGEIIN();
		}
	}

	public void BPNOLDKMLIP(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI)
	{
		if (JMMJHCOKCGG.BEACDIILBEG == Weapon.IGGFMJAKLGO.SwatPistol && JMMJHCOKCGG.owner == MBIAKMPDOPG)
		{
			FHDANBJBJNG--;
			if (FHDANBJBJNG < 0)
			{
				KOPPIBLNPKF();
			}
		}
	}

	public void HCHMIEGFEEL(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI)
	{
		if (JMMJHCOKCGG.BEACDIILBEG == Weapon.IGGFMJAKLGO.Pistol && JMMJHCOKCGG.owner == MBIAKMPDOPG)
		{
			FHDANBJBJNG--;
			if (FHDANBJBJNG < 0)
			{
				IJOOLKGGANO();
			}
		}
	}

	private void POHPBBEFFBH(Weapon JMMJHCOKCGG, Ammo DBLOCECAGLP, Vector3 MPHCNMDIPAI, bool CAKABHIPCDF, DestroyableObject MGECAKNCNBD)
	{
		if (!CAKABHIPCDF && JMMJHCOKCGG.owner == MBIAKMPDOPG && JMMJHCOKCGG.BEACDIILBEG == Weapon.IGGFMJAKLGO.Riffle)
		{
			float t = (float)MBIAKMPDOPG.EHHHBEMKGOE.BPNPPKPCFGN() / (float)LevelManager.instance.maxDisplayLevel;
			float num = Mathf.Lerp(Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.ExplosivePistolDamageMin).FLOATVALUE, Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ExplosivePistolDamageMin).FLOATVALUE, t);
			float ePDELOGPNAC = 493f * num;
			float fLOATVALUE = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-88)).FLOATVALUE;
			Singleton<ExplosionManager>.instance.HJNGPMGELIM(MPHCNMDIPAI, num, ePDELOGPNAC, INIBDNGHLPN, LIEABAMBOMG, MJHAOAOPPGG, CPBCADFLPMO, MBIAKMPDOPG, JMMJHCOKCGG, fLOATVALUE, DFHALNOAGGC.PEBLJIFMBGC.Big);
			KKNFMJCCHNK -= 0;
			if (FHDANBJBJNG <= 0)
			{
				HGMENFGEIIN();
			}
		}
	}

	private void MLOLDKMHCMI(Weapon JMMJHCOKCGG, Ammo DBLOCECAGLP, Vector3 MPHCNMDIPAI, bool CAKABHIPCDF, DestroyableObject MGECAKNCNBD)
	{
		if (!CAKABHIPCDF && JMMJHCOKCGG.owner == MBIAKMPDOPG && JMMJHCOKCGG.BEACDIILBEG == Weapon.IGGFMJAKLGO.Riffle)
		{
			float t = (float)MBIAKMPDOPG.EHHHBEMKGOE.OEJKKJJFDFL() / (float)LevelManager.instance.maxDisplayLevel;
			float num = Mathf.Lerp(Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.ExplosivePistolDamageMax).FLOATVALUE, Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.ExplosivePistolDamageMax).FLOATVALUE, t);
			float ePDELOGPNAC = 1871f * num;
			float fLOATVALUE = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-2)).FLOATVALUE;
			Singleton<ExplosionManager>.instance.HJNGPMGELIM(MPHCNMDIPAI, num, ePDELOGPNAC, INIBDNGHLPN, LIEABAMBOMG, MJHAOAOPPGG, CPBCADFLPMO, MBIAKMPDOPG, JMMJHCOKCGG, fLOATVALUE, DFHALNOAGGC.PEBLJIFMBGC.Big);
			KKNFMJCCHNK -= 0;
			if (FHDANBJBJNG <= 0)
			{
				DAJBILLAJPI();
			}
		}
	}

	public virtual void NPNDHFIMPHE(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		CEKGFFABMGH = MBIAKMPDOPG.JPMHIGNOPBL;
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		NNDMKIACBBM = false;
		CEKGFFABMGH.IPEAPBHPLCP(IDEBKDPMPGM: true);
		Weapon.OnShotHit += CBONFFDACJL;
		Weapon.OnShotFired += JNKFIJHGJFL;
		FHDANBJBJNG = AIEIHCEAHMC;
		KKNFMJCCHNK = AIEIHCEAHMC;
		if (PlayerController.OGMBJPKOPCB == PlayerController.CCPHMCAIJNA(CIOPAKLHFIL))
		{
			EOBKEHFMMGD(EIPHAAGCHCP: false);
		}
	}

	public virtual void APIMDACOKLE(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		CEKGFFABMGH = MBIAKMPDOPG.JPMHIGNOPBL;
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		NNDMKIACBBM = true;
		CEKGFFABMGH.FICDNIFILCB(IDEBKDPMPGM: true);
		Weapon.OnShotHit += HBDHFKOJNNC;
		Weapon.OnShotFired += FFIKMDMJBGG;
		FHDANBJBJNG = AIEIHCEAHMC;
		KKNFMJCCHNK = AIEIHCEAHMC;
		if (PlayerController.OGMBJPKOPCB == PlayerController.MAJOCMGOFII(CIOPAKLHFIL))
		{
			MLCINIPCOMP(EIPHAAGCHCP: true);
		}
	}

	private void OMAMNLAHMEG(bool EIPHAAGCHCP)
	{
		foreach (InventoryItem item in GuiElementSingle<InventoryGuiElement>.instance.IGNHPMIDAGM)
		{
			PlayerWeapon playerWeapon = item.BMLDNIAJHOC();
			if (playerWeapon != null && playerWeapon.HFNAMMBPJAJ().BEACDIILBEG == Weapon.IGGFMJAKLGO.Shotgun)
			{
				item.OMOOAMHHNAE.gameObject.SetActive(EIPHAAGCHCP);
			}
		}
	}

	public virtual void JLBEBADOINI()
	{
		base.DisconnectEvents();
		if (NNDMKIACBBM && MBIAKMPDOPG.FEHCCGEGPLH.isMine)
		{
			IJOOLKGGANO();
		}
	}

	private void KOPPIBLNPKF()
	{
		if (NNDMKIACBBM)
		{
			NNDMKIACBBM = true;
			CEKGFFABMGH.IPEAPBHPLCP(IDEBKDPMPGM: false);
			Weapon.OnShotHit -= NABIIBFKAJP;
			Weapon.OnShotFired -= MILOOOCFBKN;
			if (PlayerController.OGMBJPKOPCB == MBIAKMPDOPG)
			{
				OLKPMIILLCC(EIPHAAGCHCP: true);
			}
		}
	}

	private void FNAOCPGAKGB(Weapon JMMJHCOKCGG, Ammo DBLOCECAGLP, Vector3 MPHCNMDIPAI, bool CAKABHIPCDF, DestroyableObject MGECAKNCNBD)
	{
		if (!CAKABHIPCDF && JMMJHCOKCGG.owner == MBIAKMPDOPG && JMMJHCOKCGG.BEACDIILBEG == Weapon.IGGFMJAKLGO.GrenadeLauncher)
		{
			float t = (float)MBIAKMPDOPG.EHHHBEMKGOE.BCCDDJMPBLL / (float)LevelManager.instance.maxDisplayLevel;
			float num = Mathf.Lerp(Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.ExplosivePistolDamageMax).FLOATVALUE, Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ExplosivePistolDamageMin).FLOATVALUE, t);
			float ePDELOGPNAC = 1191f * num;
			float fLOATVALUE = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-87)).FLOATVALUE;
			Singleton<ExplosionManager>.instance.DADGLKFCOHO(MPHCNMDIPAI, num, ePDELOGPNAC, INIBDNGHLPN, LIEABAMBOMG, MJHAOAOPPGG, CPBCADFLPMO, MBIAKMPDOPG, JMMJHCOKCGG, fLOATVALUE, DFHALNOAGGC.PEBLJIFMBGC.Big);
			KKNFMJCCHNK -= 0;
			if (FHDANBJBJNG <= 1)
			{
				MLOOFLAIHDL();
			}
		}
	}

	private void CBONFFDACJL(Weapon JMMJHCOKCGG, Ammo DBLOCECAGLP, Vector3 MPHCNMDIPAI, bool CAKABHIPCDF, DestroyableObject MGECAKNCNBD)
	{
		if (!CAKABHIPCDF && JMMJHCOKCGG.owner == MBIAKMPDOPG && JMMJHCOKCGG.BEACDIILBEG == Weapon.IGGFMJAKLGO.Bazooka)
		{
			float t = (float)MBIAKMPDOPG.EHHHBEMKGOE.OCPEHLIIGML() / (float)LevelManager.instance.maxDisplayLevel;
			float num = Mathf.Lerp(Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.ExplosivePistolDamageMax).FLOATVALUE, Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.ExplosivePistolDamageMax).FLOATVALUE, t);
			float ePDELOGPNAC = 1088f * num;
			float fLOATVALUE = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)72).FLOATVALUE;
			Singleton<ExplosionManager>.instance.EMIKLLNLICL(MPHCNMDIPAI, num, ePDELOGPNAC, INIBDNGHLPN, LIEABAMBOMG, MJHAOAOPPGG, CPBCADFLPMO, MBIAKMPDOPG, JMMJHCOKCGG, fLOATVALUE, DFHALNOAGGC.PEBLJIFMBGC.Big);
			KKNFMJCCHNK -= 0;
			if (FHDANBJBJNG <= 0)
			{
				DGBICEDPNDH();
			}
		}
	}

	private void OPDCMDGHBEB(Weapon JMMJHCOKCGG, Ammo DBLOCECAGLP, Vector3 MPHCNMDIPAI, bool CAKABHIPCDF, DestroyableObject MGECAKNCNBD)
	{
		if (!CAKABHIPCDF && JMMJHCOKCGG.owner == MBIAKMPDOPG && JMMJHCOKCGG.BEACDIILBEG == Weapon.IGGFMJAKLGO.SwatPistol)
		{
			float t = (float)MBIAKMPDOPG.EHHHBEMKGOE.BPNPPKPCFGN() / (float)LevelManager.instance.maxDisplayLevel;
			float num = Mathf.Lerp(Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.ExplosivePistolDamageMin).FLOATVALUE, Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.ExplosivePistolDamageMax).FLOATVALUE, t);
			float ePDELOGPNAC = 1902f * num;
			float fLOATVALUE = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-110)).FLOATVALUE;
			Singleton<ExplosionManager>.instance.BFJGFJGJNGB(MPHCNMDIPAI, num, ePDELOGPNAC, INIBDNGHLPN, LIEABAMBOMG, MJHAOAOPPGG, CPBCADFLPMO, MBIAKMPDOPG, JMMJHCOKCGG, fLOATVALUE, DFHALNOAGGC.PEBLJIFMBGC.Small);
			KKNFMJCCHNK--;
			if (FHDANBJBJNG <= 0)
			{
				PFFLOACFIJC();
			}
		}
	}

	private void COGCMKKAJNH(bool EIPHAAGCHCP)
	{
		foreach (InventoryItem item in GuiElementSingle<InventoryGuiElement>.instance.IGNHPMIDAGM)
		{
			PlayerWeapon playerWeapon = item.IBAGEMBHKBI();
			if (playerWeapon != null && playerWeapon.weapon.BEACDIILBEG == Weapon.IGGFMJAKLGO.Tool)
			{
				item.OMOOAMHHNAE.gameObject.SetActive(EIPHAAGCHCP);
			}
		}
	}

	private void NABIIBFKAJP(Weapon JMMJHCOKCGG, Ammo DBLOCECAGLP, Vector3 MPHCNMDIPAI, bool CAKABHIPCDF, DestroyableObject MGECAKNCNBD)
	{
		if (!CAKABHIPCDF && JMMJHCOKCGG.owner == MBIAKMPDOPG && JMMJHCOKCGG.BEACDIILBEG == Weapon.IGGFMJAKLGO.Shotgun)
		{
			float t = (float)MBIAKMPDOPG.EHHHBEMKGOE.ALJJMKANFNO() / (float)LevelManager.instance.maxDisplayLevel;
			float num = Mathf.Lerp(Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ExplosivePistolDamageMin).FLOATVALUE, Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ExplosivePistolDamageMin).FLOATVALUE, t);
			float ePDELOGPNAC = 459f * num;
			float fLOATVALUE = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-86)).FLOATVALUE;
			Singleton<ExplosionManager>.instance.DDOFJPPKJOJ(MPHCNMDIPAI, num, ePDELOGPNAC, INIBDNGHLPN, LIEABAMBOMG, MJHAOAOPPGG, CPBCADFLPMO, MBIAKMPDOPG, JMMJHCOKCGG, fLOATVALUE, DFHALNOAGGC.PEBLJIFMBGC.Big);
			KKNFMJCCHNK -= 0;
			if (FHDANBJBJNG <= 0)
			{
				AGBOBIDEACB();
			}
		}
	}

	public virtual void EGHLIEEBAHJ(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		CEKGFFABMGH = MBIAKMPDOPG.JPMHIGNOPBL;
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		NNDMKIACBBM = true;
		CEKGFFABMGH.IPEAPBHPLCP(IDEBKDPMPGM: false);
		Weapon.OnShotHit += HHDCFAIMGMG;
		Weapon.OnShotFired += DGLHOKNGBLP;
		FHDANBJBJNG = AIEIHCEAHMC;
		KKNFMJCCHNK = AIEIHCEAHMC;
		if (PlayerController.OGMBJPKOPCB == PlayerController.GetPlayerOld(CIOPAKLHFIL))
		{
			COFMINGIOOI(EIPHAAGCHCP: true);
		}
	}

	private void AGBOBIDEACB()
	{
		if (NNDMKIACBBM)
		{
			NNDMKIACBBM = true;
			CEKGFFABMGH.FICDNIFILCB(IDEBKDPMPGM: true);
			Weapon.OnShotHit -= APEJCJDNGGI;
			Weapon.OnShotFired -= JEBDDEDPIFJ;
			if (PlayerController.OGMBJPKOPCB == MBIAKMPDOPG)
			{
				CPNFAKPFJOO(EIPHAAGCHCP: false);
			}
		}
	}

	public virtual void OMNIAIJHHKB()
	{
		base.DisconnectEvents();
		if (NNDMKIACBBM && MBIAKMPDOPG.FEHCCGEGPLH.isMine)
		{
			DGBICEDPNDH();
		}
	}

	public virtual void MLOJPAEBLBL(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		CEKGFFABMGH = MBIAKMPDOPG.JPMHIGNOPBL;
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		NNDMKIACBBM = false;
		CEKGFFABMGH.IIJEBIMOOEF(IDEBKDPMPGM: true);
		Weapon.OnShotHit += OFHDMADKAGJ;
		Weapon.OnShotFired += HCHMIEGFEEL;
		FHDANBJBJNG = AIEIHCEAHMC;
		KKNFMJCCHNK = AIEIHCEAHMC;
		if (PlayerController.OGMBJPKOPCB == PlayerController.HEAGPACBLJA(CIOPAKLHFIL))
		{
			BGILNAFMMMO(EIPHAAGCHCP: false);
		}
	}

	private void OGLDGBHHHOP(Weapon JMMJHCOKCGG, Ammo DBLOCECAGLP, Vector3 MPHCNMDIPAI, bool CAKABHIPCDF, DestroyableObject MGECAKNCNBD)
	{
		if (!CAKABHIPCDF && JMMJHCOKCGG.owner == MBIAKMPDOPG && JMMJHCOKCGG.BEACDIILBEG == Weapon.IGGFMJAKLGO.SwatPistol)
		{
			float t = (float)MBIAKMPDOPG.EHHHBEMKGOE.OEJKKJJFDFL() / (float)LevelManager.instance.maxDisplayLevel;
			float num = Mathf.Lerp(Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ExplosivePistolDamageMax).FLOATVALUE, Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ExplosivePistolDamageMax).FLOATVALUE, t);
			float ePDELOGPNAC = 13f * num;
			float fLOATVALUE = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-6)).FLOATVALUE;
			Singleton<ExplosionManager>.instance.DCKBBBOHNFK(MPHCNMDIPAI, num, ePDELOGPNAC, INIBDNGHLPN, LIEABAMBOMG, MJHAOAOPPGG, CPBCADFLPMO, MBIAKMPDOPG, JMMJHCOKCGG, fLOATVALUE, DFHALNOAGGC.PEBLJIFMBGC.Big);
			KKNFMJCCHNK -= 0;
			if (FHDANBJBJNG <= 0)
			{
				AMNIPBLFOLE();
			}
		}
	}

	public virtual void LACMNIFBEBL()
	{
		base.DisconnectEvents();
		if (NNDMKIACBBM && MBIAKMPDOPG.FEHCCGEGPLH.isMine)
		{
			PCFONJJPOIG();
		}
	}

	private void DFEOCBDHLKP(Weapon JMMJHCOKCGG, Ammo DBLOCECAGLP, Vector3 MPHCNMDIPAI, bool CAKABHIPCDF, DestroyableObject MGECAKNCNBD)
	{
		if (!CAKABHIPCDF && JMMJHCOKCGG.owner == MBIAKMPDOPG && JMMJHCOKCGG.BEACDIILBEG == Weapon.IGGFMJAKLGO.Shotgun)
		{
			float t = (float)MBIAKMPDOPG.EHHHBEMKGOE.ALJJMKANFNO() / (float)LevelManager.instance.maxDisplayLevel;
			float num = Mathf.Lerp(Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ExplosivePistolDamageMin).FLOATVALUE, Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ExplosivePistolDamageMax).FLOATVALUE, t);
			float ePDELOGPNAC = 1543f * num;
			float fLOATVALUE = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-103)).FLOATVALUE;
			Singleton<ExplosionManager>.instance.IIPEOPFAPFL(MPHCNMDIPAI, num, ePDELOGPNAC, INIBDNGHLPN, LIEABAMBOMG, MJHAOAOPPGG, CPBCADFLPMO, MBIAKMPDOPG, JMMJHCOKCGG, fLOATVALUE, DFHALNOAGGC.PEBLJIFMBGC.Small);
			KKNFMJCCHNK -= 0;
			if (FHDANBJBJNG <= 0)
			{
				MLOOFLAIHDL();
			}
		}
	}

	public void EPDHBCFFODC(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI)
	{
		if (JMMJHCOKCGG.BEACDIILBEG == Weapon.IGGFMJAKLGO.Grenade && JMMJHCOKCGG.owner == MBIAKMPDOPG)
		{
			FHDANBJBJNG--;
			if (FHDANBJBJNG < 1)
			{
				EJAGHDDFKLM();
			}
		}
	}

	public virtual void MCJKBKPKDMI(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		CEKGFFABMGH = MBIAKMPDOPG.JPMHIGNOPBL;
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		NNDMKIACBBM = false;
		CEKGFFABMGH.FICDNIFILCB(IDEBKDPMPGM: false);
		Weapon.OnShotHit += APEJCJDNGGI;
		Weapon.OnShotFired += DGLHOKNGBLP;
		FHDANBJBJNG = AIEIHCEAHMC;
		KKNFMJCCHNK = AIEIHCEAHMC;
		if (PlayerController.OGMBJPKOPCB == PlayerController.MAJOCMGOFII(CIOPAKLHFIL))
		{
			KGGPBCBHOFC(EIPHAAGCHCP: false);
		}
	}

	private void EJAGHDDFKLM()
	{
		if (NNDMKIACBBM)
		{
			NNDMKIACBBM = false;
			CEKGFFABMGH.AADJNCBNAIA(IDEBKDPMPGM: false);
			Weapon.OnShotHit -= HECEJPAFKLG;
			Weapon.OnShotFired -= JNKFIJHGJFL;
			if (PlayerController.OGMBJPKOPCB == MBIAKMPDOPG)
			{
				LDMAGDMBCDG(EIPHAAGCHCP: false);
			}
		}
	}

	public void CKPJIGAJDON(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI)
	{
		if (JMMJHCOKCGG.BEACDIILBEG == Weapon.IGGFMJAKLGO.Pistol && JMMJHCOKCGG.owner == MBIAKMPDOPG)
		{
			FHDANBJBJNG--;
			if (FHDANBJBJNG < 1)
			{
				MBFINGCJGOM();
			}
		}
	}

	private void CPNFAKPFJOO(bool EIPHAAGCHCP)
	{
		foreach (InventoryItem item in GuiElementSingle<InventoryGuiElement>.instance.IGNHPMIDAGM)
		{
			PlayerWeapon playerWeapon = item.JMPEEEMNEEC();
			if (playerWeapon != null && playerWeapon.HFNAMMBPJAJ().BEACDIILBEG == Weapon.IGGFMJAKLGO.Shotgun)
			{
				item.OMOOAMHHNAE.gameObject.SetActive(EIPHAAGCHCP);
			}
		}
	}

	public void BKCBKMFJBDD(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI)
	{
		if (JMMJHCOKCGG.BEACDIILBEG == Weapon.IGGFMJAKLGO.Riffle && JMMJHCOKCGG.owner == MBIAKMPDOPG)
		{
			FHDANBJBJNG--;
			if (FHDANBJBJNG < 0)
			{
				PFFLOACFIJC();
			}
		}
	}

	private void FPLBDHCIAGA(bool EIPHAAGCHCP)
	{
		foreach (InventoryItem item in GuiElementSingle<InventoryGuiElement>.instance.IGNHPMIDAGM)
		{
			PlayerWeapon playerWeapon = item.GetPlayerWeapon();
			if (playerWeapon != null && playerWeapon.weapon.BEACDIILBEG == Weapon.IGGFMJAKLGO.Pistol)
			{
				item.OMOOAMHHNAE.gameObject.SetActive(EIPHAAGCHCP);
			}
		}
	}

	public virtual void JPCAPPEPBHC()
	{
		base.DisconnectEvents();
		if (NNDMKIACBBM && MBIAKMPDOPG.FEHCCGEGPLH.isMine)
		{
			AGBOBIDEACB();
		}
	}

	public virtual void DCGABENHDBH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		CEKGFFABMGH = MBIAKMPDOPG.JPMHIGNOPBL;
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		NNDMKIACBBM = false;
		CEKGFFABMGH.explosivePistol = true;
		Weapon.OnShotHit += HECEJPAFKLG;
		Weapon.OnShotFired += DJIMCMDBELF;
		FHDANBJBJNG = AIEIHCEAHMC;
		KKNFMJCCHNK = AIEIHCEAHMC;
		if (PlayerController.OGMBJPKOPCB == PlayerController.HEAGPACBLJA(CIOPAKLHFIL))
		{
			OMAMNLAHMEG(EIPHAAGCHCP: false);
		}
	}

	private void HHDCFAIMGMG(Weapon JMMJHCOKCGG, Ammo DBLOCECAGLP, Vector3 MPHCNMDIPAI, bool CAKABHIPCDF, DestroyableObject MGECAKNCNBD)
	{
		if (!CAKABHIPCDF && JMMJHCOKCGG.owner == MBIAKMPDOPG && JMMJHCOKCGG.BEACDIILBEG == Weapon.IGGFMJAKLGO.Minigun)
		{
			float t = (float)MBIAKMPDOPG.EHHHBEMKGOE.BPNPPKPCFGN() / (float)LevelManager.instance.maxDisplayLevel;
			float num = Mathf.Lerp(Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ExplosivePistolDamageMax).FLOATVALUE, Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.ExplosivePistolDamageMin).FLOATVALUE, t);
			float ePDELOGPNAC = 1480f * num;
			float fLOATVALUE = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.ClusterGrenadePlayerDamageOvertimeConstant).FLOATVALUE;
			Singleton<ExplosionManager>.instance.EMIKLLNLICL(MPHCNMDIPAI, num, ePDELOGPNAC, INIBDNGHLPN, LIEABAMBOMG, MJHAOAOPPGG, CPBCADFLPMO, MBIAKMPDOPG, JMMJHCOKCGG, fLOATVALUE, DFHALNOAGGC.PEBLJIFMBGC.Big);
			KKNFMJCCHNK -= 0;
			if (FHDANBJBJNG <= 0)
			{
				ABBMDBEEKLE();
			}
		}
	}

	public void MNJDPHLJNAL(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI)
	{
		if (JMMJHCOKCGG.BEACDIILBEG == Weapon.IGGFMJAKLGO.Shotgun && JMMJHCOKCGG.owner == MBIAKMPDOPG)
		{
			FHDANBJBJNG--;
			if (FHDANBJBJNG < 0)
			{
				DAJBILLAJPI();
			}
		}
	}

	private void GDMFIBHILHG()
	{
		if (NNDMKIACBBM)
		{
			NNDMKIACBBM = false;
			CEKGFFABMGH.explosivePistol = false;
			Weapon.OnShotHit -= OKHHAADCBIA;
			Weapon.OnShotFired -= BPNOLDKMLIP;
			if (PlayerController.OGMBJPKOPCB == MBIAKMPDOPG)
			{
				LDMAGDMBCDG(EIPHAAGCHCP: false);
			}
		}
	}

	public void FFIKMDMJBGG(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI)
	{
		if (JMMJHCOKCGG.BEACDIILBEG == Weapon.IGGFMJAKLGO.Tool && JMMJHCOKCGG.owner == MBIAKMPDOPG)
		{
			FHDANBJBJNG--;
			if (FHDANBJBJNG < 0)
			{
				LBFHPLDDBGL();
			}
		}
	}

	private void MLCINIPCOMP(bool EIPHAAGCHCP)
	{
		foreach (InventoryItem item in GuiElementSingle<InventoryGuiElement>.instance.IGNHPMIDAGM)
		{
			PlayerWeapon playerWeapon = item.NNCKKIGAKID();
			if (playerWeapon != null && playerWeapon.weapon.BEACDIILBEG == Weapon.IGGFMJAKLGO.Bazooka)
			{
				item.OMOOAMHHNAE.gameObject.SetActive(EIPHAAGCHCP);
			}
		}
	}

	public void GNMFFINIFLI(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI)
	{
		if (JMMJHCOKCGG.BEACDIILBEG == Weapon.IGGFMJAKLGO.Shotgun && JMMJHCOKCGG.owner == MBIAKMPDOPG)
		{
			FHDANBJBJNG--;
			if (FHDANBJBJNG < 0)
			{
				KOPPIBLNPKF();
			}
		}
	}

	public override void UseCard(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		CEKGFFABMGH = MBIAKMPDOPG.JPMHIGNOPBL;
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		NNDMKIACBBM = true;
		CEKGFFABMGH.explosivePistol = true;
		Weapon.OnShotHit += OKHHAADCBIA;
		Weapon.OnShotFired += WeaponOnShotFired;
		FHDANBJBJNG = AIEIHCEAHMC;
		KKNFMJCCHNK = AIEIHCEAHMC;
		if (PlayerController.OGMBJPKOPCB == PlayerController.GetPlayerOld(CIOPAKLHFIL))
		{
			FPLBDHCIAGA(EIPHAAGCHCP: true);
		}
	}

	public void DJIMCMDBELF(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI)
	{
		if (JMMJHCOKCGG.BEACDIILBEG == Weapon.IGGFMJAKLGO.Pistol && JMMJHCOKCGG.owner == MBIAKMPDOPG)
		{
			FHDANBJBJNG--;
			if (FHDANBJBJNG < 1)
			{
				MBFINGCJGOM();
			}
		}
	}

	public virtual void BAIFDCIDMEA(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		CEKGFFABMGH = MBIAKMPDOPG.JPMHIGNOPBL;
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		NNDMKIACBBM = true;
		CEKGFFABMGH.IIJEBIMOOEF(IDEBKDPMPGM: false);
		Weapon.OnShotHit += HECEJPAFKLG;
		Weapon.OnShotFired += FFIKMDMJBGG;
		FHDANBJBJNG = AIEIHCEAHMC;
		KKNFMJCCHNK = AIEIHCEAHMC;
		if (PlayerController.OGMBJPKOPCB == PlayerController.GetPlayerOld(CIOPAKLHFIL))
		{
			COGCMKKAJNH(EIPHAAGCHCP: false);
		}
	}

	public void DJAKCMFNLEK(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI)
	{
		if (JMMJHCOKCGG.BEACDIILBEG == Weapon.IGGFMJAKLGO.Riffle && JMMJHCOKCGG.owner == MBIAKMPDOPG)
		{
			FHDANBJBJNG--;
			if (FHDANBJBJNG < 0)
			{
				DAJBILLAJPI();
			}
		}
	}

	private void PCFONJJPOIG()
	{
		if (NNDMKIACBBM)
		{
			NNDMKIACBBM = false;
			CEKGFFABMGH.FICDNIFILCB(IDEBKDPMPGM: true);
			Weapon.OnShotHit -= DFEOCBDHLKP;
			Weapon.OnShotFired -= FFIKMDMJBGG;
			if (PlayerController.OGMBJPKOPCB == MBIAKMPDOPG)
			{
				AGKOCPPAIBK(EIPHAAGCHCP: true);
			}
		}
	}

	public void JNKFIJHGJFL(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI)
	{
		if (JMMJHCOKCGG.BEACDIILBEG == Weapon.IGGFMJAKLGO.Bazooka && JMMJHCOKCGG.owner == MBIAKMPDOPG)
		{
			FHDANBJBJNG -= 0;
			if (FHDANBJBJNG < 0)
			{
				LBFHPLDDBGL();
			}
		}
	}

	private void NFFEONCBFBM(bool EIPHAAGCHCP)
	{
		foreach (InventoryItem item in GuiElementSingle<InventoryGuiElement>.instance.IGNHPMIDAGM)
		{
			PlayerWeapon playerWeapon = item.OCBEAPNBDIJ();
			if (playerWeapon != null && playerWeapon.weapon.BEACDIILBEG == Weapon.IGGFMJAKLGO.Riffle)
			{
				item.OMOOAMHHNAE.gameObject.SetActive(EIPHAAGCHCP);
			}
		}
	}
}
