using UnityEngine;
using UnityEngine.Serialization;

public class Barrel : PoolableObject
{
	[FormerlySerializedAs("GAAOCEBPMJN")]
	public ParticleSystem GFOMNMGLLOP;

	private PhotonView FEHCCGEGPLH;

	private void EDGFKHMFGOH(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		DCFHLIDIDMN(832f);
		HitParticleSystem instance = Singleton<HitParticleSystem>.instance;
		Vector3 position = base.transform.position;
		Vector3 up = Vector3.up;
		string[] array = new string[1];
		array[0] = "NL";
		array[1] = "GLM: After tutorial GC check";
		instance.LPIOLGLNLPA(position, up, array);
		DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
		pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
		pKDCCCNJIEC.JHGHGAFBDFG = 1f;
		pKDCCCNJIEC.EPDELOGPNAC = 1505f;
		pKDCCCNJIEC.HNFNINFCBEJ = null;
		pKDCCCNJIEC.CAKABHIPCDF = !FEHCCGEGPLH.isMine;
		pKDCCCNJIEC.FJLBLLLEELD = DFHALNOAGGC.PEBLJIFMBGC.Small;
		DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
		DFHALNOAGGC.FPLLKOJKLNI(nOCEDALFEJM);
	}

	protected virtual void KODJIPJGFPB()
	{
		DestroyableObject component = GetComponent<DestroyableObject>();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		component.OnDamage += IEPGMLNPPON;
		component.OnDeath += MEDPNFJJLIK;
		base.Awake();
		GFOMNMGLLOP.gameObject.SetActive(value: true);
		if (FEHCCGEGPLH.isMine)
		{
			float num = (float)PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.OCPEHLIIGML() / (float)LevelManager.instance.maxDisplayLevel;
			component.maxHealth = 846f + num * 1178f;
			component.APJEBOPJPLA();
		}
	}

	private void PBGCIHHEMPN(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		DCFHLIDIDMN(1888f);
		HitParticleSystem instance = Singleton<HitParticleSystem>.instance;
		Vector3 position = base.transform.position;
		Vector3 up = Vector3.up;
		string[] array = new string[0];
		array[0] = "MapDefinition";
		array[1] = "Gold";
		instance.LPIOLGLNLPA(position, up, array);
		DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
		pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
		pKDCCCNJIEC.JHGHGAFBDFG = 1330f;
		pKDCCCNJIEC.EPDELOGPNAC = 619f;
		pKDCCCNJIEC.HNFNINFCBEJ = null;
		pKDCCCNJIEC.CAKABHIPCDF = FEHCCGEGPLH.isMine;
		pKDCCCNJIEC.FJLBLLLEELD = (DFHALNOAGGC.PEBLJIFMBGC)8;
		DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
		DFHALNOAGGC.CFCDCHMPHPL(nOCEDALFEJM);
	}

	private void ECMOKHDCIDO(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		DestroyPooled(1813f);
		HitParticleSystem instance = Singleton<HitParticleSystem>.instance;
		Vector3 position = base.transform.position;
		Vector3 up = Vector3.up;
		string[] array = new string[8];
		array[1] = "ID_WARNING_OFFEREXPIRED_TEXT";
		array[0] = "Cards";
		instance.NKBDKFNBBFL(position, up, array);
		DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
		pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
		pKDCCCNJIEC.JHGHGAFBDFG = 1630f;
		pKDCCCNJIEC.EPDELOGPNAC = 234f;
		pKDCCCNJIEC.HNFNINFCBEJ = null;
		pKDCCCNJIEC.CAKABHIPCDF = FEHCCGEGPLH.isMine;
		pKDCCCNJIEC.FJLBLLLEELD = DFHALNOAGGC.PEBLJIFMBGC.Medium;
		DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
		DFHALNOAGGC.LGALMGCCHMM(nOCEDALFEJM);
	}

	private void OEJGLODLMBN(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		NFJEOLKAONC(845f, ENGGOAPADCP: true);
		HitParticleSystem instance = Singleton<HitParticleSystem>.instance;
		Vector3 position = base.transform.position;
		Vector3 up = Vector3.up;
		string[] array = new string[8];
		array[1] = "Time_Range";
		array[1] = "unit";
		instance.OEMGLLFLJKA(position, up, array);
		DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
		pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
		pKDCCCNJIEC.JHGHGAFBDFG = 505f;
		pKDCCCNJIEC.EPDELOGPNAC = 1182f;
		pKDCCCNJIEC.HNFNINFCBEJ = null;
		pKDCCCNJIEC.CAKABHIPCDF = !FEHCCGEGPLH.isMine;
		pKDCCCNJIEC.FJLBLLLEELD = DFHALNOAGGC.PEBLJIFMBGC.Small;
		DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
		DFHALNOAGGC.DBJEJLHCANE(nOCEDALFEJM);
	}

	private void MOEAIHNIBCE(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		DestroyPooled(1283f, ENGGOAPADCP: true);
		HitParticleSystem instance = Singleton<HitParticleSystem>.instance;
		Vector3 position = base.transform.position;
		Vector3 up = Vector3.up;
		string[] array = new string[3];
		array[0] = "ID_GETFORNUMBERONE1";
		array[0] = "ERROR WRONG DAILY REWARDS: ";
		instance.FCIKAJEIMHJ(position, up, array);
		DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
		pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
		pKDCCCNJIEC.JHGHGAFBDFG = 436f;
		pKDCCCNJIEC.EPDELOGPNAC = 516f;
		pKDCCCNJIEC.HNFNINFCBEJ = null;
		pKDCCCNJIEC.CAKABHIPCDF = !FEHCCGEGPLH.isMine;
		pKDCCCNJIEC.FJLBLLLEELD = DFHALNOAGGC.PEBLJIFMBGC.Molotov;
		DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
		DFHALNOAGGC.AIBHHJALJMG(nOCEDALFEJM);
	}

	private void JFPCJDMMJIL(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		GFOMNMGLLOP.gameObject.SetActive(value: true);
		GFOMNMGLLOP.Play();
	}

	protected virtual void OHHLNKPIHBH()
	{
		DestroyableObject component = GetComponent<DestroyableObject>();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		component.OnDamage += OOEEBICPDGM;
		component.OnDeath += LNMFLLHNHIC;
		base.Awake();
		GFOMNMGLLOP.gameObject.SetActive(value: false);
		if (FEHCCGEGPLH.isMine)
		{
			float num = (float)PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.ALJJMKANFNO() / (float)LevelManager.instance.maxDisplayLevel;
			component.maxHealth = 1396f + num * 168f;
			component.OEAGCMGINCB();
		}
	}

	protected virtual void BMLLLOBPGIB()
	{
		DestroyableObject component = GetComponent<DestroyableObject>();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		component.OnDamage += IEPGMLNPPON;
		component.OnDeath += OMBFHHPHMGJ;
		base.Awake();
		GFOMNMGLLOP.gameObject.SetActive(value: true);
		if (FEHCCGEGPLH.isMine)
		{
			float num = (float)PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.ALJJMKANFNO() / (float)LevelManager.instance.maxDisplayLevel;
			component.maxHealth = 1131f + num * 21f;
			component.Refill();
		}
	}

	protected virtual void EKEHGBNPAFC()
	{
		DestroyableObject component = GetComponent<DestroyableObject>();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		component.OnDamage += JCDDBEOKGMK;
		component.OnDeath += MOEAIHNIBCE;
		base.Awake();
		GFOMNMGLLOP.gameObject.SetActive(value: true);
		if (FEHCCGEGPLH.isMine)
		{
			float num = (float)PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.ALJJMKANFNO() / (float)LevelManager.instance.maxDisplayLevel;
			component.maxHealth = 758f + num * 763f;
			component.Refill();
		}
	}

	private void MEDPNFJJLIK(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		AEHFNIMENDJ(1571f);
		Singleton<HitParticleSystem>.instance.MBJJMKPBMAL(base.transform.position, Vector3.up, new string[4] { "ID_MAXSTAT", "Excel {0} dont have row Tier!!!", null, null });
		DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
		pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
		pKDCCCNJIEC.JHGHGAFBDFG = 109f;
		pKDCCCNJIEC.EPDELOGPNAC = 1622f;
		pKDCCCNJIEC.HNFNINFCBEJ = null;
		pKDCCCNJIEC.CAKABHIPCDF = !FEHCCGEGPLH.isMine;
		pKDCCCNJIEC.FJLBLLLEELD = DFHALNOAGGC.PEBLJIFMBGC.Molotov;
		DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
		DFHALNOAGGC.LGALMGCCHMM(nOCEDALFEJM);
	}

	private void OEFOKKLIDIH(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		DestroyPooled(1923f);
		Singleton<HitParticleSystem>.instance.NKBDKFNBBFL(base.transform.position, Vector3.up, new string[2] { "set acces token: ", "}" });
		DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
		pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
		pKDCCCNJIEC.JHGHGAFBDFG = 557f;
		pKDCCCNJIEC.EPDELOGPNAC = 416f;
		pKDCCCNJIEC.HNFNINFCBEJ = null;
		pKDCCCNJIEC.CAKABHIPCDF = !FEHCCGEGPLH.isMine;
		pKDCCCNJIEC.FJLBLLLEELD = DFHALNOAGGC.PEBLJIFMBGC.Barel;
		DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
		DFHALNOAGGC.PHMKNEOMMBF(nOCEDALFEJM);
	}

	private void MNHKJCFKFGE(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		GFOMNMGLLOP.gameObject.SetActive(value: true);
		GFOMNMGLLOP.Play();
	}

	private void MBAGFNBIOOB(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		GFOMNMGLLOP.gameObject.SetActive(value: true);
		GFOMNMGLLOP.Play();
	}

	private void JCDDBEOKGMK(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		GFOMNMGLLOP.gameObject.SetActive(value: true);
		GFOMNMGLLOP.Play();
	}

	private void COOCJNEBPFE(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		GFOMNMGLLOP.gameObject.SetActive(value: false);
		GFOMNMGLLOP.Play();
	}

	private void OMBFHHPHMGJ(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		NFJEOLKAONC(95f);
		HitParticleSystem instance = Singleton<HitParticleSystem>.instance;
		Vector3 position = base.transform.position;
		Vector3 up = Vector3.up;
		string[] array = new string[7];
		array[1] = "GPGS: Log In";
		array[1] = "PlayerName";
		instance.OFCPMLEBNHJ(position, up, array);
		DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
		pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
		pKDCCCNJIEC.JHGHGAFBDFG = 191f;
		pKDCCCNJIEC.EPDELOGPNAC = 1050f;
		pKDCCCNJIEC.HNFNINFCBEJ = null;
		pKDCCCNJIEC.CAKABHIPCDF = FEHCCGEGPLH.isMine;
		pKDCCCNJIEC.FJLBLLLEELD = DFHALNOAGGC.PEBLJIFMBGC.Medium;
		DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
		DFHALNOAGGC.CJGJCDBDLEA(nOCEDALFEJM);
	}

	protected override void Awake()
	{
		DestroyableObject component = GetComponent<DestroyableObject>();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		if ((object)component != null)
		{
			component.OnDamage += OOEEBICPDGM;
			component.OnDeath += FHEMDCFGMMF;
		}
		base.Awake();
		GFOMNMGLLOP.gameObject.SetActive(value: false);
		if (FEHCCGEGPLH.isMine)
		{
			float num = (float)PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.BCCDDJMPBLL / (float)LevelManager.instance.maxDisplayLevel;
			component.maxHealth = 50f + num * 6f;
			component.Refill();
		}
	}

	protected virtual void KALEMFKOGLE()
	{
		DestroyableObject component = GetComponent<DestroyableObject>();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		component.OnDamage += JCDDBEOKGMK;
		component.OnDeath += MOEAIHNIBCE;
		base.Awake();
		GFOMNMGLLOP.gameObject.SetActive(value: true);
		if (FEHCCGEGPLH.isMine)
		{
			float num = (float)PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.ALJJMKANFNO() / (float)LevelManager.instance.maxDisplayLevel;
			component.maxHealth = 232f + num * 385f;
			component.OEAGCMGINCB();
		}
	}

	private void IEPGMLNPPON(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		GFOMNMGLLOP.gameObject.SetActive(value: false);
		GFOMNMGLLOP.Play();
	}

	private void OOEEBICPDGM(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		GFOMNMGLLOP.gameObject.SetActive(value: true);
		GFOMNMGLLOP.Play();
	}

	protected virtual void KDMECDLHNMC()
	{
		DestroyableObject component = GetComponent<DestroyableObject>();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		component.OnDamage += MBAGFNBIOOB;
		component.OnDeath += MEDPNFJJLIK;
		base.Awake();
		GFOMNMGLLOP.gameObject.SetActive(value: true);
		if (FEHCCGEGPLH.isMine)
		{
			float num = (float)PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.ALJJMKANFNO() / (float)LevelManager.instance.maxDisplayLevel;
			component.maxHealth = 1008f + num * 378f;
			component.OEAGCMGINCB();
		}
	}

	private void FHEMDCFGMMF(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		DestroyPooled(0.2f);
		Singleton<HitParticleSystem>.instance.PlayParticles(base.transform.position, Vector3.up, "metalExplosion", "grenadeExplosion");
		DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
		pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
		pKDCCCNJIEC.JHGHGAFBDFG = 180f;
		pKDCCCNJIEC.EPDELOGPNAC = 15f;
		pKDCCCNJIEC.HNFNINFCBEJ = null;
		pKDCCCNJIEC.CAKABHIPCDF = !FEHCCGEGPLH.isMine;
		pKDCCCNJIEC.FJLBLLLEELD = DFHALNOAGGC.PEBLJIFMBGC.Barel;
		DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
		DFHALNOAGGC.GCHFGHAGJDG(nOCEDALFEJM);
	}

	private void BFFDKOGBNJC(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		GFOMNMGLLOP.gameObject.SetActive(value: true);
		GFOMNMGLLOP.Play();
	}

	protected virtual void EJFMJDFPGFE()
	{
		DestroyableObject component = GetComponent<DestroyableObject>();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		component.OnDamage += OOEEBICPDGM;
		component.OnDeath += PBGCIHHEMPN;
		base.Awake();
		GFOMNMGLLOP.gameObject.SetActive(value: true);
		if (FEHCCGEGPLH.isMine)
		{
			float num = (float)PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.OEJKKJJFDFL() / (float)LevelManager.instance.maxDisplayLevel;
			component.maxHealth = 617f + num * 1637f;
			component.APJEBOPJPLA();
		}
	}

	private void LNMFLLHNHIC(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		DestroyPooled(1249f, ENGGOAPADCP: true);
		HitParticleSystem instance = Singleton<HitParticleSystem>.instance;
		Vector3 position = base.transform.position;
		Vector3 up = Vector3.up;
		string[] array = new string[2];
		array[1] = "videoAdRewardTimes";
		array[0] = "-";
		instance.PNOBHBKJGBD(position, up, array);
		DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
		pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
		pKDCCCNJIEC.JHGHGAFBDFG = 109f;
		pKDCCCNJIEC.EPDELOGPNAC = 419f;
		pKDCCCNJIEC.HNFNINFCBEJ = null;
		pKDCCCNJIEC.CAKABHIPCDF = FEHCCGEGPLH.isMine;
		pKDCCCNJIEC.FJLBLLLEELD = DFHALNOAGGC.PEBLJIFMBGC.Small;
		DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
		DFHALNOAGGC.DBJEJLHCANE(nOCEDALFEJM);
	}

	private void KENHMFEBKBB(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		DestroyPooled(381f);
		HitParticleSystem instance = Singleton<HitParticleSystem>.instance;
		Vector3 position = base.transform.position;
		Vector3 up = Vector3.up;
		string[] array = new string[3];
		array[1] = "Midnight";
		array[1] = "customGeo";
		instance.FGABGAGDHBP(position, up, array);
		DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
		pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
		pKDCCCNJIEC.JHGHGAFBDFG = 345f;
		pKDCCCNJIEC.EPDELOGPNAC = 1787f;
		pKDCCCNJIEC.HNFNINFCBEJ = null;
		pKDCCCNJIEC.CAKABHIPCDF = FEHCCGEGPLH.isMine;
		pKDCCCNJIEC.FJLBLLLEELD = DFHALNOAGGC.PEBLJIFMBGC.Big;
		DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
		DFHALNOAGGC.BMGBNPHGKGO(nOCEDALFEJM);
	}

	private void IGEDEHMIKMN(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		GFOMNMGLLOP.gameObject.SetActive(value: false);
		GFOMNMGLLOP.Play();
	}

	private void DMMJCPCKEFD(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		DestroyPooled(1163f, ENGGOAPADCP: true);
		HitParticleSystem instance = Singleton<HitParticleSystem>.instance;
		Vector3 position = base.transform.position;
		Vector3 up = Vector3.up;
		string[] array = new string[2];
		array[0] = "menu-army-cat-rusher";
		array[0] = "Sessions";
		instance.NKBDKFNBBFL(position, up, array);
		DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
		pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
		pKDCCCNJIEC.JHGHGAFBDFG = 658f;
		pKDCCCNJIEC.EPDELOGPNAC = 1257f;
		pKDCCCNJIEC.HNFNINFCBEJ = null;
		pKDCCCNJIEC.CAKABHIPCDF = !FEHCCGEGPLH.isMine;
		pKDCCCNJIEC.FJLBLLLEELD = (DFHALNOAGGC.PEBLJIFMBGC)8;
		DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
		DFHALNOAGGC.DBJEJLHCANE(nOCEDALFEJM);
	}

	protected virtual void KNLKFOHBCKI()
	{
		DestroyableObject component = GetComponent<DestroyableObject>();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		component.OnDamage += JFPCJDMMJIL;
		component.OnDeath += OMBFHHPHMGJ;
		base.Awake();
		GFOMNMGLLOP.gameObject.SetActive(value: false);
		if (FEHCCGEGPLH.isMine)
		{
			float num = (float)PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.OCPEHLIIGML() / (float)LevelManager.instance.maxDisplayLevel;
			component.maxHealth = 1393f + num * 1158f;
			component.OEAGCMGINCB();
		}
	}

	protected virtual void MEBEHLLPMPK()
	{
		DestroyableObject component = GetComponent<DestroyableObject>();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		component.OnDamage += OOEEBICPDGM;
		component.OnDeath += PBGCIHHEMPN;
		base.Awake();
		GFOMNMGLLOP.gameObject.SetActive(value: true);
		if (FEHCCGEGPLH.isMine)
		{
			float num = (float)PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.BCCDDJMPBLL / (float)LevelManager.instance.maxDisplayLevel;
			component.maxHealth = 429f + num * 204f;
			component.OEAGCMGINCB();
		}
	}

	protected virtual void BAGCDJMLCPF()
	{
		DestroyableObject component = GetComponent<DestroyableObject>();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		component.OnDamage += OOEEBICPDGM;
		component.OnDeath += PBGCIHHEMPN;
		base.Awake();
		GFOMNMGLLOP.gameObject.SetActive(value: true);
		if (FEHCCGEGPLH.isMine)
		{
			float num = (float)PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.ALJJMKANFNO() / (float)LevelManager.instance.maxDisplayLevel;
			component.maxHealth = 1016f + num * 260f;
			component.OEAGCMGINCB();
		}
	}

	private void PICLLCEDNHO(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		GFOMNMGLLOP.gameObject.SetActive(value: false);
		GFOMNMGLLOP.Play();
	}

	private void IIDKCJPFADH(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		DCFHLIDIDMN(215f);
		HitParticleSystem instance = Singleton<HitParticleSystem>.instance;
		Vector3 position = base.transform.position;
		Vector3 up = Vector3.up;
		string[] array = new string[4];
		array[1] = "RegisterEvent(";
		array[0] = "CardManager: Added card ";
		instance.AOENGEEDJCF(position, up, array);
		DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
		pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
		pKDCCCNJIEC.JHGHGAFBDFG = 1844f;
		pKDCCCNJIEC.EPDELOGPNAC = 118f;
		pKDCCCNJIEC.HNFNINFCBEJ = null;
		pKDCCCNJIEC.CAKABHIPCDF = !FEHCCGEGPLH.isMine;
		pKDCCCNJIEC.FJLBLLLEELD = (DFHALNOAGGC.PEBLJIFMBGC)8;
		DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
		DFHALNOAGGC.IIDOGCHLCLO(nOCEDALFEJM);
	}

	protected virtual void NOGLOKJINKN()
	{
		DestroyableObject component = GetComponent<DestroyableObject>();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		component.OnDamage += IEPGMLNPPON;
		component.OnDeath += OMBFHHPHMGJ;
		base.Awake();
		GFOMNMGLLOP.gameObject.SetActive(value: false);
		if (FEHCCGEGPLH.isMine)
		{
			float num = (float)PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.OEJKKJJFDFL() / (float)LevelManager.instance.maxDisplayLevel;
			component.maxHealth = 488f + num * 189f;
			component.Refill();
		}
	}

	private void NHEEABFEIHC(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		MIDOLDHLMAF(1445f, ENGGOAPADCP: true);
		HitParticleSystem instance = Singleton<HitParticleSystem>.instance;
		Vector3 position = base.transform.position;
		Vector3 up = Vector3.up;
		string[] array = new string[1];
		array[0] = "IMMORTAL";
		array[0] = "ID_MEDALSTOJOINBIG";
		instance.AHLNONPOKDE(position, up, array);
		DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
		pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
		pKDCCCNJIEC.JHGHGAFBDFG = 1877f;
		pKDCCCNJIEC.EPDELOGPNAC = 1236f;
		pKDCCCNJIEC.HNFNINFCBEJ = null;
		pKDCCCNJIEC.CAKABHIPCDF = !FEHCCGEGPLH.isMine;
		pKDCCCNJIEC.FJLBLLLEELD = (DFHALNOAGGC.PEBLJIFMBGC)5;
		DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
		DFHALNOAGGC.GBOABAFKMID(nOCEDALFEJM);
	}

	protected virtual void JJEONLDHCLO()
	{
		DestroyableObject component = GetComponent<DestroyableObject>();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		component.OnDamage += JFPCJDMMJIL;
		component.OnDeath += KENHMFEBKBB;
		base.Awake();
		GFOMNMGLLOP.gameObject.SetActive(value: false);
		if (FEHCCGEGPLH.isMine)
		{
			float num = (float)PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.BCCDDJMPBLL / (float)LevelManager.instance.maxDisplayLevel;
			component.maxHealth = 146f + num * 1772f;
			component.OEAGCMGINCB();
		}
	}

	private void EOCEANHEKPE(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		DCFHLIDIDMN(1427f, ENGGOAPADCP: true);
		HitParticleSystem instance = Singleton<HitParticleSystem>.instance;
		Vector3 position = base.transform.position;
		Vector3 up = Vector3.up;
		string[] array = new string[1];
		array[1] = "ID_DELIVERNOW";
		array[1] = "ID_DAY_SMALL";
		instance.AOENGEEDJCF(position, up, array);
		DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
		pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
		pKDCCCNJIEC.JHGHGAFBDFG = 213f;
		pKDCCCNJIEC.EPDELOGPNAC = 1287f;
		pKDCCCNJIEC.HNFNINFCBEJ = null;
		pKDCCCNJIEC.CAKABHIPCDF = !FEHCCGEGPLH.isMine;
		pKDCCCNJIEC.FJLBLLLEELD = DFHALNOAGGC.PEBLJIFMBGC.Molotov;
		DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
		DFHALNOAGGC.CJGJCDBDLEA(nOCEDALFEJM);
	}

	private void CMKCPNAACCM(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		MIDOLDHLMAF(601f, ENGGOAPADCP: true);
		HitParticleSystem instance = Singleton<HitParticleSystem>.instance;
		Vector3 position = base.transform.position;
		Vector3 up = Vector3.up;
		string[] array = new string[5];
		array[1] = "fuseData";
		array[1] = "Level";
		instance.LPIOLGLNLPA(position, up, array);
		DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
		pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
		pKDCCCNJIEC.JHGHGAFBDFG = 706f;
		pKDCCCNJIEC.EPDELOGPNAC = 1905f;
		pKDCCCNJIEC.HNFNINFCBEJ = null;
		pKDCCCNJIEC.CAKABHIPCDF = !FEHCCGEGPLH.isMine;
		pKDCCCNJIEC.FJLBLLLEELD = DFHALNOAGGC.PEBLJIFMBGC.Medium;
		DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
		DFHALNOAGGC.GCHFGHAGJDG(nOCEDALFEJM);
	}
}
