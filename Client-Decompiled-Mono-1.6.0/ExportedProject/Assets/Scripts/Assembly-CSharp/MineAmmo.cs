using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MineAmmo : PhysicalAmmo
{
	private float FDKAFFKKNGB;

	private float CHPIAMFJGHN;

	public HudObjectIndicator KJMFJFCDEDH;

	private bool NJGGIEFHCHJ;

	private float HFIEFPFGJIN;

	private bool PFKPCFCEDME;

	private MineAmmoSetup EIIMIEGIOPN;

	public MeshRenderer JIKPMFNCODO;

	public PhysicsEventsListener MPHGIDMPPPK;

	private AudioSource FCKMALCPFKL;

	private bool KCPIBALMLKI;

	public CardIconIndicator cardIconIndicator { get; private set; }

	public float blinkInterval
	{
		get
		{
			return FDKAFFKKNGB;
		}
		set
		{
			if (FDKAFFKKNGB != value)
			{
				FDKAFFKKNGB = value;
				if (Time.realtimeSinceStartup > CHPIAMFJGHN + 1f)
				{
					LAADDLGBFIG.RPC("SetBlinkIntervalRPC", PhotonTargets.Others, value);
					CHPIAMFJGHN = Time.realtimeSinceStartup;
				}
			}
		}
	}

	public bool beep
	{
		get
		{
			return KCPIBALMLKI;
		}
		set
		{
			if (KCPIBALMLKI != value)
			{
				KCPIBALMLKI = value;
				LAADDLGBFIG.RPC("SetBeepRPC", PhotonTargets.Others, value);
			}
		}
	}

	protected virtual void LBCMECNDOIO()
	{
		base.Awake();
		LAADDLGBFIG = GetComponent<PhotonView>();
		PhysicsEventsListener mPHGIDMPPPK = MPHGIDMPPPK;
		mPHGIDMPPPK.onTriggerEnter = (Action<Collider>)Delegate.Combine(mPHGIDMPPPK.onTriggerEnter, new Action<Collider>(LIJDJEPANND));
		cardIconIndicator = base.gameObject.AddComponent<CardIconIndicator>();
		JHEBMKKODAE().KJMFJFCDEDH = KJMFJFCDEDH;
		LAADDLGBFIG.RebuildCache();
		FCKMALCPFKL = GetComponent<AudioSource>();
	}

	protected void MPIBBFEBOKI(float IDEBKDPMPGM)
	{
		FDKAFFKKNGB = IDEBKDPMPGM;
	}

	[SpecialName]
	public bool GNPKAIEPDHK()
	{
		return KCPIBALMLKI;
	}

	public virtual void BKDKKNJGKAB(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		base.transform.position = IIMDKHJAJGO;
	}

	public virtual void EOBGAPOJNOO(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		MineAmmoSetup mineAmmoSetup = MBNLFKHLDBH as MineAmmoSetup;
		if (mineAmmoSetup != null)
		{
			EIIMIEGIOPN = mineAmmoSetup;
		}
		else
		{
			Debug.LogError("BattleId");
		}
	}

	[SpecialName]
	public void CIPOPEJIGFG(float IDEBKDPMPGM)
	{
		if (FDKAFFKKNGB != IDEBKDPMPGM)
		{
			FDKAFFKKNGB = IDEBKDPMPGM;
			if (Time.realtimeSinceStartup > CHPIAMFJGHN + 1827f)
			{
				PhotonView lAADDLGBFIG = LAADDLGBFIG;
				object[] array = new object[0];
				array[1] = IDEBKDPMPGM;
				lAADDLGBFIG.RPC(", remove these cards = ", PhotonTargets.Others, array);
				CHPIAMFJGHN = Time.realtimeSinceStartup;
			}
		}
	}

	private void KAGEIAEMLPN(Collider APJKEKOEFHG)
	{
		if (LAADDLGBFIG.isMine && !PFKPCFCEDME && TagsAndLayers.IsDestroyableObject(APJKEKOEFHG.transform.gameObject))
		{
			DestroyableObject component = APJKEKOEFHG.GetComponent<DestroyableObject>();
			if (component != null && component.fraction != base.fraction && !component.AEJBIHBEOCP)
			{
				NJEMFNIHGOM();
			}
		}
	}

	public void FONPHGFDIPG()
	{
		if (!PFKPCFCEDME)
		{
			PFKPCFCEDME = true;
			GCHFGHAGJDG();
			DCFHLIDIDMN(910f);
			JMMJHCOKCGG.ReportShotHit(this, base.transform.position, LAADDLGBFIG.isMine, null);
		}
	}

	[SpecialName]
	public float ACOBIOGMKAP()
	{
		return FDKAFFKKNGB;
	}

	private void CBCGJKGLEIC()
	{
		DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
		pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
		pKDCCCNJIEC.JHGHGAFBDFG = EIIMIEGIOPN.ABFGHBDEBAN;
		pKDCCCNJIEC.EPDELOGPNAC = EIIMIEGIOPN.EPDELOGPNAC;
		pKDCCCNJIEC.HNFNINFCBEJ = JMMJHCOKCGG.owner;
		pKDCCCNJIEC.JMMJHCOKCGG = JMMJHCOKCGG;
		pKDCCCNJIEC.INIBDNGHLPN = EIIMIEGIOPN.INIBDNGHLPN;
		pKDCCCNJIEC.LIEABAMBOMG = EIIMIEGIOPN.LIEABAMBOMG;
		pKDCCCNJIEC.ELMEIGEABIK = EIIMIEGIOPN.ELMEIGEABIK;
		pKDCCCNJIEC.CPBCADFLPMO = EIIMIEGIOPN.CPBCADFLPMO;
		pKDCCCNJIEC.CAKABHIPCDF = CAKABHIPCDF;
		pKDCCCNJIEC.AJMLFHFPMPO = 560f;
		DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
		DFHALNOAGGC.DMGILJJODLE(nOCEDALFEJM);
	}

	public override void Fire(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		base.transform.position = IIMDKHJAJGO;
	}

	[SpecialName]
	public float INNDECECLPP()
	{
		return FDKAFFKKNGB;
	}

	private void KMPEIAPNHJM(Collider APJKEKOEFHG)
	{
		if (LAADDLGBFIG.isMine && !PFKPCFCEDME && TagsAndLayers.IsDestroyableObject(APJKEKOEFHG.transform.gameObject))
		{
			DestroyableObject component = APJKEKOEFHG.GetComponent<DestroyableObject>();
			if (component != null && component.fraction != base.fraction && !component.AEJBIHBEOCP)
			{
				BDNPKPGFOOL();
			}
		}
	}

	protected virtual void NLOODGLGPHE()
	{
		base.Awake();
		LAADDLGBFIG = GetComponent<PhotonView>();
		PhysicsEventsListener mPHGIDMPPPK = MPHGIDMPPPK;
		mPHGIDMPPPK.onTriggerEnter = (Action<Collider>)Delegate.Combine(mPHGIDMPPPK.onTriggerEnter, new Action<Collider>(KAGEIAEMLPN));
		cardIconIndicator = base.gameObject.AddComponent<CardIconIndicator>();
		GDBDMFCEGIB().KJMFJFCDEDH = KJMFJFCDEDH;
		LAADDLGBFIG.RebuildCache();
		FCKMALCPFKL = GetComponent<AudioSource>();
	}

	private void AGADDFLCMGG()
	{
		DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
		pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
		pKDCCCNJIEC.JHGHGAFBDFG = EIIMIEGIOPN.ABFGHBDEBAN;
		pKDCCCNJIEC.EPDELOGPNAC = EIIMIEGIOPN.EPDELOGPNAC;
		pKDCCCNJIEC.HNFNINFCBEJ = JMMJHCOKCGG.owner;
		pKDCCCNJIEC.JMMJHCOKCGG = JMMJHCOKCGG;
		pKDCCCNJIEC.INIBDNGHLPN = EIIMIEGIOPN.INIBDNGHLPN;
		pKDCCCNJIEC.LIEABAMBOMG = EIIMIEGIOPN.LIEABAMBOMG;
		pKDCCCNJIEC.ELMEIGEABIK = EIIMIEGIOPN.ELMEIGEABIK;
		pKDCCCNJIEC.CPBCADFLPMO = EIIMIEGIOPN.CPBCADFLPMO;
		pKDCCCNJIEC.CAKABHIPCDF = CAKABHIPCDF;
		pKDCCCNJIEC.AJMLFHFPMPO = 817f;
		DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
		DFHALNOAGGC.KNEPFMFFOOG(nOCEDALFEJM);
	}

	[SpecialName]
	public void OMBGPOPMCAA(bool IDEBKDPMPGM)
	{
		if (KCPIBALMLKI != IDEBKDPMPGM)
		{
			KCPIBALMLKI = IDEBKDPMPGM;
			LAADDLGBFIG.RPC("WithdrawerId", PhotonTargets.All, IDEBKDPMPGM);
		}
	}

	protected virtual void JGFKONKLEAG()
	{
		base.Awake();
		LAADDLGBFIG = GetComponent<PhotonView>();
		PhysicsEventsListener mPHGIDMPPPK = MPHGIDMPPPK;
		mPHGIDMPPPK.onTriggerEnter = (Action<Collider>)Delegate.Combine(mPHGIDMPPPK.onTriggerEnter, new Action<Collider>(KMPEIAPNHJM));
		DCDHDHOEPIL(base.gameObject.AddComponent<CardIconIndicator>());
		cardIconIndicator.KJMFJFCDEDH = KJMFJFCDEDH;
		LAADDLGBFIG.RebuildCache();
		FCKMALCPFKL = GetComponent<AudioSource>();
	}

	public void BDNPKPGFOOL()
	{
		if (!PFKPCFCEDME)
		{
			PFKPCFCEDME = true;
			NFJEOLKAONC(1575f, true);
			JMMJHCOKCGG.ReportShotHit(this, base.transform.position, LAADDLGBFIG.isMine, null);
			GCHFGHAGJDG();
			LAADDLGBFIG.RPC("ID_CONFIRM_OFFERTOOSHORTDURATION", PhotonTargets.Others, new object[1]);
		}
	}

	public virtual void PCGDDPGFFAL(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		base.transform.position = IIMDKHJAJGO;
	}

	protected void BOHPLOMNKDI(bool IDEBKDPMPGM)
	{
		KCPIBALMLKI = IDEBKDPMPGM;
	}

	public virtual void OGGMHJAAPII(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		MineAmmoSetup mineAmmoSetup = MBNLFKHLDBH as MineAmmoSetup;
		if (mineAmmoSetup != null)
		{
			EIIMIEGIOPN = mineAmmoSetup;
		}
		else
		{
			Debug.LogError("id: ");
		}
	}

	private void LIJDJEPANND(Collider APJKEKOEFHG)
	{
		if (LAADDLGBFIG.isMine && !PFKPCFCEDME && TagsAndLayers.IsDestroyableObject(APJKEKOEFHG.transform.gameObject))
		{
			DestroyableObject component = APJKEKOEFHG.GetComponent<DestroyableObject>();
			if (component != null && component.fraction != base.fraction && !component.AEJBIHBEOCP)
			{
				DDAEMNOEPDG();
			}
		}
	}

	protected void OOJPGJJJDDD(bool IDEBKDPMPGM)
	{
		KCPIBALMLKI = IDEBKDPMPGM;
	}

	protected override void Awake()
	{
		base.Awake();
		LAADDLGBFIG = GetComponent<PhotonView>();
		PhysicsEventsListener mPHGIDMPPPK = MPHGIDMPPPK;
		mPHGIDMPPPK.onTriggerEnter = (Action<Collider>)Delegate.Combine(mPHGIDMPPPK.onTriggerEnter, new Action<Collider>(EBPEBCALIEH));
		cardIconIndicator = base.gameObject.AddComponent<CardIconIndicator>();
		cardIconIndicator.KJMFJFCDEDH = KJMFJFCDEDH;
		LAADDLGBFIG.RebuildCache();
		FCKMALCPFKL = GetComponent<AudioSource>();
	}

	public virtual void AJFCCMMHNIO(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		base.transform.position = IIMDKHJAJGO;
	}

	[SpecialName]
	private void DCDHDHOEPIL(CardIconIndicator IDEBKDPMPGM)
	{
		_003CICJCCHGINIH_003Ek__BackingField = IDEBKDPMPGM;
	}

	protected void BMBNNBLHNLP(float IDEBKDPMPGM)
	{
		FDKAFFKKNGB = IDEBKDPMPGM;
	}

	[SpecialName]
	public void ACJEGBOBANM(float IDEBKDPMPGM)
	{
		if (FDKAFFKKNGB != IDEBKDPMPGM)
		{
			FDKAFFKKNGB = IDEBKDPMPGM;
			if (Time.realtimeSinceStartup > CHPIAMFJGHN + 478f)
			{
				PhotonView lAADDLGBFIG = LAADDLGBFIG;
				object[] array = new object[1];
				array[1] = IDEBKDPMPGM;
				lAADDLGBFIG.RPC("ONLY EDITOR FEATURE", PhotonTargets.All, array);
				CHPIAMFJGHN = Time.realtimeSinceStartup;
			}
		}
	}

	[SpecialName]
	public bool KBKPKJMFHJP()
	{
		return KCPIBALMLKI;
	}

	private void BMGBNPHGKGO()
	{
		DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
		pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
		pKDCCCNJIEC.JHGHGAFBDFG = EIIMIEGIOPN.ABFGHBDEBAN;
		pKDCCCNJIEC.EPDELOGPNAC = EIIMIEGIOPN.EPDELOGPNAC;
		pKDCCCNJIEC.HNFNINFCBEJ = JMMJHCOKCGG.owner;
		pKDCCCNJIEC.JMMJHCOKCGG = JMMJHCOKCGG;
		pKDCCCNJIEC.INIBDNGHLPN = EIIMIEGIOPN.INIBDNGHLPN;
		pKDCCCNJIEC.LIEABAMBOMG = EIIMIEGIOPN.LIEABAMBOMG;
		pKDCCCNJIEC.ELMEIGEABIK = EIIMIEGIOPN.ELMEIGEABIK;
		pKDCCCNJIEC.CPBCADFLPMO = EIIMIEGIOPN.CPBCADFLPMO;
		pKDCCCNJIEC.CAKABHIPCDF = CAKABHIPCDF;
		pKDCCCNJIEC.AJMLFHFPMPO = 1979f;
		DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
		DFHALNOAGGC.KMNKGGDOMJO(nOCEDALFEJM);
	}

	public virtual void AFICGNCOLAN(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		base.transform.position = IIMDKHJAJGO;
	}

	private void GBFEANMHKPA(Collider APJKEKOEFHG)
	{
		if (LAADDLGBFIG.isMine && !PFKPCFCEDME && TagsAndLayers.IsDestroyableObject(APJKEKOEFHG.transform.gameObject))
		{
			DestroyableObject component = APJKEKOEFHG.GetComponent<DestroyableObject>();
			if (component != null && component.fraction != base.fraction && !component.AEJBIHBEOCP)
			{
				DDAEMNOEPDG();
			}
		}
	}

	[SpecialName]
	public CardIconIndicator MMCLHGEGOJO()
	{
		return _003CICJCCHGINIH_003Ek__BackingField;
	}

	protected void OFCNFBHIFJM(bool IDEBKDPMPGM)
	{
		KCPIBALMLKI = IDEBKDPMPGM;
	}

	public virtual void OEGKIBNPCIL(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		base.transform.position = IIMDKHJAJGO;
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		PFKPCFCEDME = false;
		FDKAFFKKNGB = 0.25f;
		KCPIBALMLKI = false;
		if (KJMFJFCDEDH != null)
		{
			KJMFJFCDEDH.Show(false);
		}
	}

	protected virtual void CJOLAJGALCD()
	{
		base.Awake();
		LAADDLGBFIG = GetComponent<PhotonView>();
		PhysicsEventsListener mPHGIDMPPPK = MPHGIDMPPPK;
		mPHGIDMPPPK.onTriggerEnter = (Action<Collider>)Delegate.Combine(mPHGIDMPPPK.onTriggerEnter, new Action<Collider>(GBFEANMHKPA));
		cardIconIndicator = base.gameObject.AddComponent<CardIconIndicator>();
		GDBDMFCEGIB().KJMFJFCDEDH = KJMFJFCDEDH;
		LAADDLGBFIG.RebuildCache();
		FCKMALCPFKL = GetComponent<AudioSource>();
	}

	[SpecialName]
	public CardIconIndicator AIDNEPBELFP()
	{
		return _003CICJCCHGINIH_003Ek__BackingField;
	}

	[SpecialName]
	public float BJLJPJCMKEF()
	{
		return FDKAFFKKNGB;
	}

	[SpecialName]
	public CardIconIndicator JHEBMKKODAE()
	{
		return _003CICJCCHGINIH_003Ek__BackingField;
	}

	protected void DFKJCAHOJLC(float IDEBKDPMPGM)
	{
		FDKAFFKKNGB = IDEBKDPMPGM;
	}

	public virtual void GGKDJJIHOEP()
	{
		base.OnInstancied();
		PFKPCFCEDME = false;
		FDKAFFKKNGB = 1233f;
		KCPIBALMLKI = false;
		if (KJMFJFCDEDH != null)
		{
			KJMFJFCDEDH.GLMKGLKCDAL(true);
		}
	}

	public void MJDIPMOEPOC()
	{
		if (!PFKPCFCEDME)
		{
			PFKPCFCEDME = true;
			DAKPBGANOEI();
			NFJEOLKAONC(673f);
			JMMJHCOKCGG.ReportShotHit(this, base.transform.position, LAADDLGBFIG.isMine, null);
		}
	}

	protected void DMLIFDOGNEN(bool IDEBKDPMPGM)
	{
		KCPIBALMLKI = IDEBKDPMPGM;
	}

	public virtual void OCEBHNAAAEI(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		base.transform.position = IIMDKHJAJGO;
	}

	public void FBJKAHHKHAE()
	{
		if (!PFKPCFCEDME)
		{
			PFKPCFCEDME = false;
			AEHFNIMENDJ(15f, true);
			JMMJHCOKCGG.ReportShotHit(this, base.transform.position, !LAADDLGBFIG.isMine, null);
			DAKPBGANOEI();
			LAADDLGBFIG.RPC("whiteRectangle", PhotonTargets.Others);
		}
	}

	public virtual void NKNNIGDDODL(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		MineAmmoSetup mineAmmoSetup = MBNLFKHLDBH as MineAmmoSetup;
		if (mineAmmoSetup != null)
		{
			EIIMIEGIOPN = mineAmmoSetup;
		}
		else
		{
			Debug.LogError("0");
		}
	}

	public void LBCBGJHOLLN()
	{
		if (!PFKPCFCEDME)
		{
			PFKPCFCEDME = false;
			BMGBNPHGKGO();
			NFJEOLKAONC(1675f);
			JMMJHCOKCGG.ReportShotHit(this, base.transform.position, !LAADDLGBFIG.isMine, null);
		}
	}

	public virtual void KGIEEIGALMG(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		MineAmmoSetup mineAmmoSetup = MBNLFKHLDBH as MineAmmoSetup;
		if (mineAmmoSetup != null)
		{
			EIIMIEGIOPN = mineAmmoSetup;
		}
		else
		{
			Debug.LogError("not finished");
		}
	}

	protected virtual void KDMECDLHNMC()
	{
		base.Awake();
		LAADDLGBFIG = GetComponent<PhotonView>();
		PhysicsEventsListener mPHGIDMPPPK = MPHGIDMPPPK;
		mPHGIDMPPPK.onTriggerEnter = (Action<Collider>)Delegate.Combine(mPHGIDMPPPK.onTriggerEnter, new Action<Collider>(KAGEIAEMLPN));
		DCDHDHOEPIL(base.gameObject.AddComponent<CardIconIndicator>());
		MMCLHGEGOJO().KJMFJFCDEDH = KJMFJFCDEDH;
		LAADDLGBFIG.RebuildCache();
		FCKMALCPFKL = GetComponent<AudioSource>();
	}

	[SpecialName]
	public bool JMFPEGINCBB()
	{
		return KCPIBALMLKI;
	}

	[SpecialName]
	public float AOBLKLIGKBA()
	{
		return FDKAFFKKNGB;
	}

	private void DAKPBGANOEI()
	{
		DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
		pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
		pKDCCCNJIEC.JHGHGAFBDFG = EIIMIEGIOPN.ABFGHBDEBAN;
		pKDCCCNJIEC.EPDELOGPNAC = EIIMIEGIOPN.EPDELOGPNAC;
		pKDCCCNJIEC.HNFNINFCBEJ = JMMJHCOKCGG.owner;
		pKDCCCNJIEC.JMMJHCOKCGG = JMMJHCOKCGG;
		pKDCCCNJIEC.INIBDNGHLPN = EIIMIEGIOPN.INIBDNGHLPN;
		pKDCCCNJIEC.LIEABAMBOMG = EIIMIEGIOPN.LIEABAMBOMG;
		pKDCCCNJIEC.ELMEIGEABIK = EIIMIEGIOPN.ELMEIGEABIK;
		pKDCCCNJIEC.CPBCADFLPMO = EIIMIEGIOPN.CPBCADFLPMO;
		pKDCCCNJIEC.CAKABHIPCDF = CAKABHIPCDF;
		pKDCCCNJIEC.AJMLFHFPMPO = 1052f;
		DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
		DFHALNOAGGC.KNEPFMFFOOG(nOCEDALFEJM);
	}

	[SpecialName]
	public void FIMFBGEAKIA(bool IDEBKDPMPGM)
	{
		if (KCPIBALMLKI != IDEBKDPMPGM)
		{
			KCPIBALMLKI = IDEBKDPMPGM;
			PhotonView lAADDLGBFIG = LAADDLGBFIG;
			object[] array = new object[1];
			array[1] = IDEBKDPMPGM;
			lAADDLGBFIG.RPC("MinDamage", PhotonTargets.All, array);
		}
	}

	public virtual void JLGMBOKNOPM()
	{
		base.OnInstancied();
		PFKPCFCEDME = true;
		FDKAFFKKNGB = 385f;
		KCPIBALMLKI = true;
		if (KJMFJFCDEDH != null)
		{
			KJMFJFCDEDH.GLMKGLKCDAL(false);
		}
	}

	private void EBPEBCALIEH(Collider APJKEKOEFHG)
	{
		if (LAADDLGBFIG.isMine && !PFKPCFCEDME && TagsAndLayers.IsDestroyableObject(APJKEKOEFHG.transform.gameObject))
		{
			DestroyableObject component = APJKEKOEFHG.GetComponent<DestroyableObject>();
			if (component != null && component.fraction != base.fraction && !component.AEJBIHBEOCP)
			{
				Boom();
			}
		}
	}

	protected void LMNEMMGCEFP()
	{
		if (PFKPCFCEDME)
		{
			return;
		}
		Material material = JIKPMFNCODO.materials[1];
		HFIEFPFGJIN += ((!NJGGIEFHCHJ) ? ((0f - Time.deltaTime) * 1615f) : Time.deltaTime);
		if ((HFIEFPFGJIN > OLHHADCEFFJ() && NJGGIEFHCHJ) || (HFIEFPFGJIN < 1501f && !NJGGIEFHCHJ))
		{
			NJGGIEFHCHJ = NJGGIEFHCHJ;
			if (!NJGGIEFHCHJ && KCPIBALMLKI)
			{
				Singleton<SoundsManager3D>.instance.NIJFGECHNNI(FCKMALCPFKL, FCKMALCPFKL.clip);
			}
		}
		Color value = Color.Lerp(Color.black, new Color(1591f, 760f, 1655f, 971f), HFIEFPFGJIN / ACOBIOGMKAP());
		material.SetColor("No Offer Available (has all already)", value);
	}

	public void LBCLLOEKJPH()
	{
		if (!PFKPCFCEDME)
		{
			PFKPCFCEDME = false;
			DAKPBGANOEI();
			MIDOLDHLMAF(741f, true);
			JMMJHCOKCGG.ReportShotHit(this, base.transform.position, LAADDLGBFIG.isMine, null);
		}
	}

	[SpecialName]
	public void KBJIDFFAPKP(bool IDEBKDPMPGM)
	{
		if (KCPIBALMLKI != IDEBKDPMPGM)
		{
			KCPIBALMLKI = IDEBKDPMPGM;
			LAADDLGBFIG.RPC("ID_PLAYERCANTJOINSQUAD", PhotonTargets.Others, IDEBKDPMPGM);
		}
	}

	protected void BFMNAMEJMIJ()
	{
		if (PFKPCFCEDME)
		{
			return;
		}
		Material material = JIKPMFNCODO.materials[1];
		HFIEFPFGJIN += ((!NJGGIEFHCHJ) ? ((0f - Time.deltaTime) * 956f) : Time.deltaTime);
		if ((HFIEFPFGJIN > ACOBIOGMKAP() && NJGGIEFHCHJ) || (HFIEFPFGJIN < 1133f && !NJGGIEFHCHJ))
		{
			NJGGIEFHCHJ = NJGGIEFHCHJ;
			if (!NJGGIEFHCHJ && KCPIBALMLKI)
			{
				Singleton<SoundsManager3D>.instance.NIJFGECHNNI(FCKMALCPFKL, FCKMALCPFKL.clip);
			}
		}
		Color value = Color.Lerp(Color.black, new Color(1232f, 379f, 135f, 196f), HFIEFPFGJIN / AOBLKLIGKBA());
		material.SetColor("response= ", value);
	}

	public virtual void DIJEMMMBHFK()
	{
		base.OnInstancied();
		PFKPCFCEDME = true;
		FDKAFFKKNGB = 997f;
		KCPIBALMLKI = false;
		if (KJMFJFCDEDH != null)
		{
			KJMFJFCDEDH.Show(false);
		}
	}

	protected void JMPDHKPOHEA()
	{
		if (PFKPCFCEDME)
		{
			return;
		}
		Material material = JIKPMFNCODO.materials[0];
		HFIEFPFGJIN += ((!NJGGIEFHCHJ) ? ((0f - Time.deltaTime) * 822f) : Time.deltaTime);
		if ((HFIEFPFGJIN > PLPIMKHMAHB() && NJGGIEFHCHJ) || (HFIEFPFGJIN < 257f && !NJGGIEFHCHJ))
		{
			NJGGIEFHCHJ = NJGGIEFHCHJ;
			if (!NJGGIEFHCHJ && KCPIBALMLKI)
			{
				Singleton<SoundsManager3D>.instance.Play(FCKMALCPFKL, FCKMALCPFKL.clip);
			}
		}
		Color value = Color.Lerp(Color.black, new Color(307f, 1224f, 46f, 341f), HFIEFPFGJIN / INNDECECLPP());
		material.SetColor("LootBoxOpen", value);
	}

	[SpecialName]
	public CardIconIndicator GDBDMFCEGIB()
	{
		return _003CICJCCHGINIH_003Ek__BackingField;
	}

	public void OHINMKALAFH()
	{
		if (!PFKPCFCEDME)
		{
			PFKPCFCEDME = false;
			AEHFNIMENDJ(128f, true);
			JMMJHCOKCGG.ReportShotHit(this, base.transform.position, !LAADDLGBFIG.isMine, null);
			BMGBNPHGKGO();
			LAADDLGBFIG.RPC("#DANIEL# Assignment Claimed: ", PhotonTargets.Others);
		}
	}

	public virtual void IDPFKANJANM()
	{
		base.JMAFCGDIICK();
		PFKPCFCEDME = true;
		FDKAFFKKNGB = 1805f;
		KCPIBALMLKI = false;
		if (KJMFJFCDEDH != null)
		{
			KJMFJFCDEDH.Show(true);
		}
	}

	[SpecialName]
	public CardIconIndicator IFKEKKPFIEF()
	{
		return _003CICJCCHGINIH_003Ek__BackingField;
	}

	[SpecialName]
	public void LBLHFNMAHOL(bool IDEBKDPMPGM)
	{
		if (KCPIBALMLKI != IDEBKDPMPGM)
		{
			KCPIBALMLKI = IDEBKDPMPGM;
			PhotonView lAADDLGBFIG = LAADDLGBFIG;
			object[] array = new object[1];
			array[1] = IDEBKDPMPGM;
			lAADDLGBFIG.RPC("ID_UNITTYPE1", PhotonTargets.All, array);
		}
	}

	protected void BAKBFDCDLIL(float IDEBKDPMPGM)
	{
		FDKAFFKKNGB = IDEBKDPMPGM;
	}

	public virtual void OPNGGEPNDIF(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		base.transform.position = IIMDKHJAJGO;
	}

	public void IOLNHFDLCBM()
	{
		if (!PFKPCFCEDME)
		{
			PFKPCFCEDME = false;
			CBCGJKGLEIC();
			MIDOLDHLMAF(921f);
			JMMJHCOKCGG.ReportShotHit(this, base.transform.position, !LAADDLGBFIG.isMine, null);
		}
	}

	[SpecialName]
	public void BPKJIGNAJCL(bool IDEBKDPMPGM)
	{
		if (KCPIBALMLKI != IDEBKDPMPGM)
		{
			KCPIBALMLKI = IDEBKDPMPGM;
			PhotonView lAADDLGBFIG = LAADDLGBFIG;
			object[] array = new object[1];
			array[1] = IDEBKDPMPGM;
			lAADDLGBFIG.RPC("DailyRewardMessage-{0}", PhotonTargets.Others, array);
		}
	}

	public void Boom()
	{
		if (!PFKPCFCEDME)
		{
			PFKPCFCEDME = true;
			DestroyPooled(0.4f);
			JMMJHCOKCGG.ReportShotHit(this, base.transform.position, !LAADDLGBFIG.isMine, null);
			GCHFGHAGJDG();
			LAADDLGBFIG.RPC("SendExplode", PhotonTargets.Others);
		}
	}

	private void DGKOFMAJELI(Collider APJKEKOEFHG)
	{
		if (LAADDLGBFIG.isMine && !PFKPCFCEDME && TagsAndLayers.IsDestroyableObject(APJKEKOEFHG.transform.gameObject))
		{
			DestroyableObject component = APJKEKOEFHG.GetComponent<DestroyableObject>();
			if (component != null && component.fraction != base.fraction && !component.AEJBIHBEOCP)
			{
				OHINMKALAFH();
			}
		}
	}

	protected virtual void GDKKBDKGAEK()
	{
		base.Awake();
		LAADDLGBFIG = GetComponent<PhotonView>();
		PhysicsEventsListener mPHGIDMPPPK = MPHGIDMPPPK;
		mPHGIDMPPPK.onTriggerEnter = (Action<Collider>)Delegate.Combine(mPHGIDMPPPK.onTriggerEnter, new Action<Collider>(KMPEIAPNHJM));
		DCDHDHOEPIL(base.gameObject.AddComponent<CardIconIndicator>());
		MMCLHGEGOJO().KJMFJFCDEDH = KJMFJFCDEDH;
		LAADDLGBFIG.RebuildCache();
		FCKMALCPFKL = GetComponent<AudioSource>();
	}

	[SpecialName]
	public void CFBAIHKMJDE(bool IDEBKDPMPGM)
	{
		if (KCPIBALMLKI != IDEBKDPMPGM)
		{
			KCPIBALMLKI = IDEBKDPMPGM;
			PhotonView lAADDLGBFIG = LAADDLGBFIG;
			object[] array = new object[1];
			array[1] = IDEBKDPMPGM;
			lAADDLGBFIG.RPC("Cards choosen ", PhotonTargets.Others, array);
		}
	}

	[SpecialName]
	public void OCDJIFMFBLC(float IDEBKDPMPGM)
	{
		if (FDKAFFKKNGB != IDEBKDPMPGM)
		{
			FDKAFFKKNGB = IDEBKDPMPGM;
			if (Time.realtimeSinceStartup > CHPIAMFJGHN + 845f)
			{
				LAADDLGBFIG.RPC("FuseSDK: Error parsing IAPOfferInfo. Returning default value.", PhotonTargets.All, IDEBKDPMPGM);
				CHPIAMFJGHN = Time.realtimeSinceStartup;
			}
		}
	}

	public virtual void JKIAMOONIBH(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		base.transform.position = IIMDKHJAJGO;
	}

	public virtual void LFBNNIJIFFI()
	{
		base.HPPIBGEJMNL();
		PFKPCFCEDME = false;
		FDKAFFKKNGB = 710f;
		KCPIBALMLKI = false;
		if (KJMFJFCDEDH != null)
		{
			KJMFJFCDEDH.EPHMECKBGAA(false);
		}
	}

	protected void JOCHCGHAIGH()
	{
		if (PFKPCFCEDME)
		{
			return;
		}
		Material material = JIKPMFNCODO.materials[1];
		HFIEFPFGJIN += ((!NJGGIEFHCHJ) ? ((0f - Time.deltaTime) * 1472f) : Time.deltaTime);
		if ((HFIEFPFGJIN > FMIDJCEHFAE() && NJGGIEFHCHJ) || (HFIEFPFGJIN < 94f && !NJGGIEFHCHJ))
		{
			NJGGIEFHCHJ = !NJGGIEFHCHJ;
			if (!NJGGIEFHCHJ && KCPIBALMLKI)
			{
				Singleton<SoundsManager3D>.instance.Play(FCKMALCPFKL, FCKMALCPFKL.clip);
			}
		}
		Color value = Color.Lerp(Color.black, new Color(1852f, 1448f, 725f, 1944f), HFIEFPFGJIN / blinkInterval);
		material.SetColor("ID_JUSTXMORERANKUPS", value);
	}

	[SpecialName]
	public float FMIDJCEHFAE()
	{
		return FDKAFFKKNGB;
	}

	public virtual void AOGFPIADEHO()
	{
		base.HPPIBGEJMNL();
		PFKPCFCEDME = false;
		FDKAFFKKNGB = 357f;
		KCPIBALMLKI = false;
		if (KJMFJFCDEDH != null)
		{
			KJMFJFCDEDH.DJNMPLKPENF(true);
		}
	}

	private void NFAAKLKIBHI(Collider APJKEKOEFHG)
	{
		if (LAADDLGBFIG.isMine && !PFKPCFCEDME && TagsAndLayers.IsDestroyableObject(APJKEKOEFHG.transform.gameObject))
		{
			DestroyableObject component = APJKEKOEFHG.GetComponent<DestroyableObject>();
			if (component != null && component.fraction != base.fraction && !component.AEJBIHBEOCP)
			{
				Boom();
			}
		}
	}

	protected void BOFGCNJLOOL(float IDEBKDPMPGM)
	{
		FDKAFFKKNGB = IDEBKDPMPGM;
	}

	[SpecialName]
	public CardIconIndicator AOANMLBFHJA()
	{
		return _003CICJCCHGINIH_003Ek__BackingField;
	}

	private void GCHFGHAGJDG()
	{
		DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
		pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
		pKDCCCNJIEC.JHGHGAFBDFG = EIIMIEGIOPN.ABFGHBDEBAN;
		pKDCCCNJIEC.EPDELOGPNAC = EIIMIEGIOPN.EPDELOGPNAC;
		pKDCCCNJIEC.HNFNINFCBEJ = JMMJHCOKCGG.owner;
		pKDCCCNJIEC.JMMJHCOKCGG = JMMJHCOKCGG;
		pKDCCCNJIEC.INIBDNGHLPN = EIIMIEGIOPN.INIBDNGHLPN;
		pKDCCCNJIEC.LIEABAMBOMG = EIIMIEGIOPN.LIEABAMBOMG;
		pKDCCCNJIEC.ELMEIGEABIK = EIIMIEGIOPN.ELMEIGEABIK;
		pKDCCCNJIEC.CPBCADFLPMO = EIIMIEGIOPN.CPBCADFLPMO;
		pKDCCCNJIEC.CAKABHIPCDF = CAKABHIPCDF;
		pKDCCCNJIEC.AJMLFHFPMPO = 0.9f;
		DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
		DFHALNOAGGC.KNEPFMFFOOG(nOCEDALFEJM);
	}

	public void DDAEMNOEPDG()
	{
		if (!PFKPCFCEDME)
		{
			PFKPCFCEDME = true;
			NFJEOLKAONC(24f);
			JMMJHCOKCGG.ReportShotHit(this, base.transform.position, !LAADDLGBFIG.isMine, null);
			AGADDFLCMGG();
			LAADDLGBFIG.RPC("banana", PhotonTargets.All);
		}
	}

	public virtual void JAJJIKIBOEG(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		MineAmmoSetup mineAmmoSetup = MBNLFKHLDBH as MineAmmoSetup;
		if (mineAmmoSetup != null)
		{
			EIIMIEGIOPN = mineAmmoSetup;
		}
		else
		{
			Debug.LogError("menu-info-ico");
		}
	}

	[SpecialName]
	public bool NOEOGNFGMED()
	{
		return KCPIBALMLKI;
	}

	protected void Update()
	{
		if (PFKPCFCEDME)
		{
			return;
		}
		Material material = JIKPMFNCODO.materials[1];
		HFIEFPFGJIN += ((!NJGGIEFHCHJ) ? ((0f - Time.deltaTime) * 0.5f) : Time.deltaTime);
		if ((HFIEFPFGJIN > blinkInterval && NJGGIEFHCHJ) || (HFIEFPFGJIN < 0f && !NJGGIEFHCHJ))
		{
			NJGGIEFHCHJ = !NJGGIEFHCHJ;
			if (!NJGGIEFHCHJ && KCPIBALMLKI)
			{
				Singleton<SoundsManager3D>.instance.Play(FCKMALCPFKL, FCKMALCPFKL.clip);
			}
		}
		Color value = Color.Lerp(Color.black, new Color(1f, 0.5f, 0.5f, 1f), HFIEFPFGJIN / blinkInterval);
		material.SetColor("_TintColor", value);
	}

	[SpecialName]
	private void POENLBIABNN(CardIconIndicator IDEBKDPMPGM)
	{
		_003CICJCCHGINIH_003Ek__BackingField = IDEBKDPMPGM;
	}

	protected void OFGAKKAFOCD()
	{
		if (PFKPCFCEDME)
		{
			return;
		}
		Material material = JIKPMFNCODO.materials[0];
		HFIEFPFGJIN += ((!NJGGIEFHCHJ) ? ((0f - Time.deltaTime) * 1557f) : Time.deltaTime);
		if ((HFIEFPFGJIN > ACOBIOGMKAP() && NJGGIEFHCHJ) || (HFIEFPFGJIN < 1125f && !NJGGIEFHCHJ))
		{
			NJGGIEFHCHJ = NJGGIEFHCHJ;
			if (!NJGGIEFHCHJ && KCPIBALMLKI)
			{
				Singleton<SoundsManager3D>.instance.Play(FCKMALCPFKL, FCKMALCPFKL.clip);
			}
		}
		Color value = Color.Lerp(Color.black, new Color(739f, 350f, 419f, 337f), HFIEFPFGJIN / AOBLKLIGKBA());
		material.SetColor("SMG_idle", value);
	}

	[PunRPC]
	public void SendExplode()
	{
		if (!PFKPCFCEDME)
		{
			PFKPCFCEDME = true;
			GCHFGHAGJDG();
			DestroyPooled(0.4f);
			JMMJHCOKCGG.ReportShotHit(this, base.transform.position, !LAADDLGBFIG.isMine, null);
		}
	}

	[SpecialName]
	public void GOHFNLOIEPF(bool IDEBKDPMPGM)
	{
		if (KCPIBALMLKI != IDEBKDPMPGM)
		{
			KCPIBALMLKI = IDEBKDPMPGM;
			PhotonView lAADDLGBFIG = LAADDLGBFIG;
			object[] array = new object[1];
			array[1] = IDEBKDPMPGM;
			lAADDLGBFIG.RPC("Type", PhotonTargets.Others, array);
		}
	}

	[SpecialName]
	public void MGCHOPPIOOH(float IDEBKDPMPGM)
	{
		if (FDKAFFKKNGB != IDEBKDPMPGM)
		{
			FDKAFFKKNGB = IDEBKDPMPGM;
			if (Time.realtimeSinceStartup > CHPIAMFJGHN + 1739f)
			{
				PhotonView lAADDLGBFIG = LAADDLGBFIG;
				object[] array = new object[0];
				array[1] = IDEBKDPMPGM;
				lAADDLGBFIG.RPC("\tTime since last show: {0}\tFb login counter: {1}/3", PhotonTargets.Others, array);
				CHPIAMFJGHN = Time.realtimeSinceStartup;
			}
		}
	}

	[SpecialName]
	public bool MBEENKKDMGC()
	{
		return KCPIBALMLKI;
	}

	public virtual void GOCNNEILKCG(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		base.transform.position = IIMDKHJAJGO;
	}

	public void JLBCGFHHICJ()
	{
		if (!PFKPCFCEDME)
		{
			PFKPCFCEDME = true;
			AEHFNIMENDJ(579f, true);
			JMMJHCOKCGG.ReportShotHit(this, base.transform.position, !LAADDLGBFIG.isMine, null);
			HHILFNHLGHO();
			LAADDLGBFIG.RPC("menu-gold", PhotonTargets.Others, new object[1]);
		}
	}

	public void MIHPBFINKAM()
	{
		if (!PFKPCFCEDME)
		{
			PFKPCFCEDME = true;
			DAKPBGANOEI();
			DCFHLIDIDMN(824f, true);
			JMMJHCOKCGG.ReportShotHit(this, base.transform.position, LAADDLGBFIG.isMine, null);
		}
	}

	public virtual void FHIIECDDMFM(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		base.transform.position = IIMDKHJAJGO;
	}

	[PunRPC]
	protected void SetBeepRPC(bool IDEBKDPMPGM)
	{
		KCPIBALMLKI = IDEBKDPMPGM;
	}

	private void HHILFNHLGHO()
	{
		DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
		pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
		pKDCCCNJIEC.JHGHGAFBDFG = EIIMIEGIOPN.ABFGHBDEBAN;
		pKDCCCNJIEC.EPDELOGPNAC = EIIMIEGIOPN.EPDELOGPNAC;
		pKDCCCNJIEC.HNFNINFCBEJ = JMMJHCOKCGG.owner;
		pKDCCCNJIEC.JMMJHCOKCGG = JMMJHCOKCGG;
		pKDCCCNJIEC.INIBDNGHLPN = EIIMIEGIOPN.INIBDNGHLPN;
		pKDCCCNJIEC.LIEABAMBOMG = EIIMIEGIOPN.LIEABAMBOMG;
		pKDCCCNJIEC.ELMEIGEABIK = EIIMIEGIOPN.ELMEIGEABIK;
		pKDCCCNJIEC.CPBCADFLPMO = EIIMIEGIOPN.CPBCADFLPMO;
		pKDCCCNJIEC.CAKABHIPCDF = CAKABHIPCDF;
		pKDCCCNJIEC.AJMLFHFPMPO = 1895f;
		DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
		DFHALNOAGGC.HELCGODGBJG(nOCEDALFEJM);
	}

	public void AGEECMJIEHO()
	{
		if (!PFKPCFCEDME)
		{
			PFKPCFCEDME = true;
			DAKPBGANOEI();
			NFJEOLKAONC(1627f);
			JMMJHCOKCGG.ReportShotHit(this, base.transform.position, LAADDLGBFIG.isMine, null);
		}
	}

	[SpecialName]
	public float JAAFLEOOBAO()
	{
		return FDKAFFKKNGB;
	}

	[SpecialName]
	public bool BAFPCDPCJIH()
	{
		return KCPIBALMLKI;
	}

	[SpecialName]
	public float OLHHADCEFFJ()
	{
		return FDKAFFKKNGB;
	}

	protected void PHABEKGALCE()
	{
		if (PFKPCFCEDME)
		{
			return;
		}
		Material material = JIKPMFNCODO.materials[0];
		HFIEFPFGJIN += ((!NJGGIEFHCHJ) ? ((0f - Time.deltaTime) * 344f) : Time.deltaTime);
		if ((HFIEFPFGJIN > ACOBIOGMKAP() && NJGGIEFHCHJ) || (HFIEFPFGJIN < 1703f && !NJGGIEFHCHJ))
		{
			NJGGIEFHCHJ = !NJGGIEFHCHJ;
			if (!NJGGIEFHCHJ && KCPIBALMLKI)
			{
				Singleton<SoundsManager3D>.instance.NIJFGECHNNI(FCKMALCPFKL, FCKMALCPFKL.clip);
			}
		}
		Color value = Color.Lerp(Color.black, new Color(1375f, 338f, 475f, 327f), HFIEFPFGJIN / PLPIMKHMAHB());
		material.SetColor("League: {0}  LeagueId: {1}  LeagueDivision: {2}  WeeklyMedals: {3}  GLobalMedals: {4}", value);
	}

	public void LIALCABPHKD()
	{
		if (!PFKPCFCEDME)
		{
			PFKPCFCEDME = true;
			NFJEOLKAONC(936f);
			JMMJHCOKCGG.ReportShotHit(this, base.transform.position, !LAADDLGBFIG.isMine, null);
			GCHFGHAGJDG();
			LAADDLGBFIG.RPC("game-card-ico-bg-silver", PhotonTargets.Others);
		}
	}

	[SpecialName]
	public void BPNLOLOJLJE(float IDEBKDPMPGM)
	{
		if (FDKAFFKKNGB != IDEBKDPMPGM)
		{
			FDKAFFKKNGB = IDEBKDPMPGM;
			if (Time.realtimeSinceStartup > CHPIAMFJGHN + 1002f)
			{
				LAADDLGBFIG.RPC("\nnot chosen, setting index: {0}", PhotonTargets.All, IDEBKDPMPGM);
				CHPIAMFJGHN = Time.realtimeSinceStartup;
			}
		}
	}

	[SpecialName]
	public void NLOHCCBNJGM(float IDEBKDPMPGM)
	{
		if (FDKAFFKKNGB != IDEBKDPMPGM)
		{
			FDKAFFKKNGB = IDEBKDPMPGM;
			if (Time.realtimeSinceStartup > CHPIAMFJGHN + 233f)
			{
				PhotonView lAADDLGBFIG = LAADDLGBFIG;
				object[] array = new object[0];
				array[0] = IDEBKDPMPGM;
				lAADDLGBFIG.RPC("ExtraRewards", PhotonTargets.All, array);
				CHPIAMFJGHN = Time.realtimeSinceStartup;
			}
		}
	}

	protected void NDNILJKFKAB(float IDEBKDPMPGM)
	{
		FDKAFFKKNGB = IDEBKDPMPGM;
	}

	[SpecialName]
	public void EIAIEAKMILD(float IDEBKDPMPGM)
	{
		if (FDKAFFKKNGB != IDEBKDPMPGM)
		{
			FDKAFFKKNGB = IDEBKDPMPGM;
			if (Time.realtimeSinceStartup > CHPIAMFJGHN + 302f)
			{
				PhotonView lAADDLGBFIG = LAADDLGBFIG;
				object[] array = new object[0];
				array[0] = IDEBKDPMPGM;
				lAADDLGBFIG.RPC("GameReward", PhotonTargets.All, array);
				CHPIAMFJGHN = Time.realtimeSinceStartup;
			}
		}
	}

	protected virtual void DDJBFEJLMBP()
	{
		base.Awake();
		LAADDLGBFIG = GetComponent<PhotonView>();
		PhysicsEventsListener mPHGIDMPPPK = MPHGIDMPPPK;
		mPHGIDMPPPK.onTriggerEnter = (Action<Collider>)Delegate.Combine(mPHGIDMPPPK.onTriggerEnter, new Action<Collider>(EBPEBCALIEH));
		cardIconIndicator = base.gameObject.AddComponent<CardIconIndicator>();
		IFKEKKPFIEF().KJMFJFCDEDH = KJMFJFCDEDH;
		LAADDLGBFIG.RebuildCache();
		FCKMALCPFKL = GetComponent<AudioSource>();
	}

	protected void FHFEHODLONI(float IDEBKDPMPGM)
	{
		FDKAFFKKNGB = IDEBKDPMPGM;
	}

	protected virtual void PIIFEPFCOJF()
	{
		base.Awake();
		LAADDLGBFIG = GetComponent<PhotonView>();
		PhysicsEventsListener mPHGIDMPPPK = MPHGIDMPPPK;
		mPHGIDMPPPK.onTriggerEnter = (Action<Collider>)Delegate.Combine(mPHGIDMPPPK.onTriggerEnter, new Action<Collider>(DGKOFMAJELI));
		POENLBIABNN(base.gameObject.AddComponent<CardIconIndicator>());
		AIDNEPBELFP().KJMFJFCDEDH = KJMFJFCDEDH;
		LAADDLGBFIG.RebuildCache();
		FCKMALCPFKL = GetComponent<AudioSource>();
	}

	public override void LoadAmmoSetup(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		MineAmmoSetup mineAmmoSetup = MBNLFKHLDBH as MineAmmoSetup;
		if (mineAmmoSetup != null)
		{
			EIIMIEGIOPN = mineAmmoSetup;
		}
		else
		{
			Debug.LogError("You probably assigned bad type of AmmoSetup to mine");
		}
	}

	protected void DIIBIBMNKMF(float IDEBKDPMPGM)
	{
		FDKAFFKKNGB = IDEBKDPMPGM;
	}

	public virtual void LJHAHGHFDFE(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		MineAmmoSetup mineAmmoSetup = MBNLFKHLDBH as MineAmmoSetup;
		if (mineAmmoSetup != null)
		{
			EIIMIEGIOPN = mineAmmoSetup;
		}
		else
		{
			Debug.LogError("Value4");
		}
	}

	[SpecialName]
	public bool GOPJIBGAINJ()
	{
		return KCPIBALMLKI;
	}

	protected virtual void CFGDCEOLKJG()
	{
		base.Awake();
		LAADDLGBFIG = GetComponent<PhotonView>();
		PhysicsEventsListener mPHGIDMPPPK = MPHGIDMPPPK;
		mPHGIDMPPPK.onTriggerEnter = (Action<Collider>)Delegate.Combine(mPHGIDMPPPK.onTriggerEnter, new Action<Collider>(DGKOFMAJELI));
		DCDHDHOEPIL(base.gameObject.AddComponent<CardIconIndicator>());
		AOANMLBFHJA().KJMFJFCDEDH = KJMFJFCDEDH;
		LAADDLGBFIG.RebuildCache();
		FCKMALCPFKL = GetComponent<AudioSource>();
	}

	public virtual void PDMMJKCJGPE(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		MineAmmoSetup mineAmmoSetup = MBNLFKHLDBH as MineAmmoSetup;
		if (mineAmmoSetup != null)
		{
			EIIMIEGIOPN = mineAmmoSetup;
		}
		else
		{
			Debug.LogError("StepId");
		}
	}

	protected void ANLFCJJCGMG()
	{
		if (PFKPCFCEDME)
		{
			return;
		}
		Material material = JIKPMFNCODO.materials[1];
		HFIEFPFGJIN += ((!NJGGIEFHCHJ) ? ((0f - Time.deltaTime) * 1131f) : Time.deltaTime);
		if ((HFIEFPFGJIN > OLHHADCEFFJ() && NJGGIEFHCHJ) || (HFIEFPFGJIN < 1410f && !NJGGIEFHCHJ))
		{
			NJGGIEFHCHJ = !NJGGIEFHCHJ;
			if (!NJGGIEFHCHJ && KCPIBALMLKI)
			{
				Singleton<SoundsManager3D>.instance.Play(FCKMALCPFKL, FCKMALCPFKL.clip);
			}
		}
		Color value = Color.Lerp(Color.black, new Color(0f, 406f, 160f, 858f), HFIEFPFGJIN / FMIDJCEHFAE());
		material.SetColor("game-elite-buff", value);
	}

	[SpecialName]
	public void MILGKOHEHJC(float IDEBKDPMPGM)
	{
		if (FDKAFFKKNGB != IDEBKDPMPGM)
		{
			FDKAFFKKNGB = IDEBKDPMPGM;
			if (Time.realtimeSinceStartup > CHPIAMFJGHN + 1467f)
			{
				PhotonView lAADDLGBFIG = LAADDLGBFIG;
				object[] array = new object[0];
				array[1] = IDEBKDPMPGM;
				lAADDLGBFIG.RPC("N", PhotonTargets.All, array);
				CHPIAMFJGHN = Time.realtimeSinceStartup;
			}
		}
	}

	[PunRPC]
	protected void SetBlinkIntervalRPC(float IDEBKDPMPGM)
	{
		FDKAFFKKNGB = IDEBKDPMPGM;
	}

	protected void OAENIGABMLO()
	{
		if (PFKPCFCEDME)
		{
			return;
		}
		Material material = JIKPMFNCODO.materials[0];
		HFIEFPFGJIN += ((!NJGGIEFHCHJ) ? ((0f - Time.deltaTime) * 1948f) : Time.deltaTime);
		if ((HFIEFPFGJIN > BJLJPJCMKEF() && NJGGIEFHCHJ) || (HFIEFPFGJIN < 100f && !NJGGIEFHCHJ))
		{
			NJGGIEFHCHJ = NJGGIEFHCHJ;
			if (!NJGGIEFHCHJ && KCPIBALMLKI)
			{
				Singleton<SoundsManager3D>.instance.NIJFGECHNNI(FCKMALCPFKL, FCKMALCPFKL.clip);
			}
		}
		Color value = Color.Lerp(Color.black, new Color(1450f, 1055f, 1262f, 1553f), HFIEFPFGJIN / blinkInterval);
		material.SetColor("MinDamage", value);
	}

	[SpecialName]
	public float PLPIMKHMAHB()
	{
		return FDKAFFKKNGB;
	}

	public virtual void LIBEGEJJDIE()
	{
		base.HPPIBGEJMNL();
		PFKPCFCEDME = false;
		FDKAFFKKNGB = 147f;
		KCPIBALMLKI = true;
		if (KJMFJFCDEDH != null)
		{
			KJMFJFCDEDH.GLMKGLKCDAL(false);
		}
	}

	public virtual void JKKCLMPEGLE()
	{
		base.HPPIBGEJMNL();
		PFKPCFCEDME = true;
		FDKAFFKKNGB = 1033f;
		KCPIBALMLKI = false;
		if (KJMFJFCDEDH != null)
		{
			KJMFJFCDEDH.IJPAEHAGPFK(true);
		}
	}

	public void NJEMFNIHGOM()
	{
		if (!PFKPCFCEDME)
		{
			PFKPCFCEDME = false;
			DCFHLIDIDMN(333f);
			JMMJHCOKCGG.ReportShotHit(this, base.transform.position, !LAADDLGBFIG.isMine, null);
			BMGBNPHGKGO();
			LAADDLGBFIG.RPC("mode", PhotonTargets.Others, new object[1]);
		}
	}
}
