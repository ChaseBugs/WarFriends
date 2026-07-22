using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.Serialization;

public class MiniDrone : MainGameEntity
{
	[FormerlySerializedAs("KPGABKOOCAO")]
	public ParticleSystem MLJMFMAIDIB;

	[FormerlySerializedAs("DLFOGCGNJEB")]
	public ParticleSystem NDMMMFFLNPJ;

	private bool ADEPHFKJEKG;

	private DestroyableObject FFOAABONJNO;

	private DroneSteering ILFPJEGPJJE;

	private bool PFKPCFCEDME;

	private PhotonView FEHCCGEGPLH;

	private Transform NGCDDPCAGJB;

	private GHPGNELIDBM ODCLPMADGFC;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _003CCDNMFDJOELD_003Ek__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private WayPointPath _003CLOKJMCAKHAI_003Ek__BackingField;

	private int IAGLMAMNMFH;

	private AICarTransporter OANCIEHCCNA;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private float _003CJENKLJFAGFD_003Ek__BackingField;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> FJHBCIAKBPF;

	public AICarTransporter transporterToRepair
	{
		get
		{
			return OANCIEHCCNA;
		}
		set
		{
			OANCIEHCCNA = value;
			GameShootableEntity component = GetComponent<GameShootableEntity>();
			if (component != null)
			{
				component.owner = OANCIEHCCNA;
				component.isMain = false;
			}
		}
	}

	public override GHPGNELIDBM fraction
	{
		get
		{
			return ODCLPMADGFC;
		}
		set
		{
			ODCLPMADGFC = value;
			FEHCCGEGPLH.RPC("SetFractionRPC", PhotonTargets.Others, (byte)value);
			JNJMPOHBFGN();
			FFOAABONJNO.ChangeLayer(ODCLPMADGFC, MNFCGHNFFFF: false);
		}
	}

	public override KMHCMCBGFFC owner
	{
		get
		{
			return this;
		}
		set
		{
		}
	}

	public override int power
	{
		[CompilerGenerated]
		get
		{
			return _003CCDNMFDJOELD_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CCDNMFDJOELD_003Ek__BackingField = value;
		}
	}

	public WayPointPath wayPointPath
	{
		[CompilerGenerated]
		get
		{
			return _003CLOKJMCAKHAI_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CLOKJMCAKHAI_003Ek__BackingField = value;
		}
	}

	public DestroyableObject destroyableObject => FFOAABONJNO;

	public float repairRatioPerSec
	{
		[CompilerGenerated]
		get
		{
			return _003CJENKLJFAGFD_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CJENKLJFAGFD_003Ek__BackingField = value;
		}
	}

	public override event Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> Killed
	{
		add
		{
			Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> action = FJHBCIAKBPF;
			Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref FJHBCIAKBPF, (Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> action = FJHBCIAKBPF;
			Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref FJHBCIAKBPF, (Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	[PunRPC]
	private void PlaySparks()
	{
		if (FEHCCGEGPLH.isMine)
		{
			FEHCCGEGPLH.RPC("PlaySparks", PhotonTargets.Others);
		}
		NDMMMFFLNPJ.Play();
	}

	[SpecialName]
	public virtual void KIGLMCJPMCL(int IDEBKDPMPGM)
	{
		_003CCDNMFDJOELD_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void OnTriggerEnter(Collider AKLHJIBDAFA)
	{
		if (!ADEPHFKJEKG && !PFKPCFCEDME)
		{
			JPILOMEHDLN.DMHEGPIPEEH(JPILOMEHDLN.GOEFODHLMBC.VibrateHeavy);
			PFKPCFCEDME = true;
			CDCOFHGPJHN(0.2f);
			DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
			pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
			pKDCCCNJIEC.JHGHGAFBDFG = destroyableObject.maxHealth * 0.5f;
			pKDCCCNJIEC.EPDELOGPNAC = destroyableObject.maxHealth * 0.05f;
			pKDCCCNJIEC.HNFNINFCBEJ = this;
			pKDCCCNJIEC.CAKABHIPCDF = !FEHCCGEGPLH.isMine;
			pKDCCCNJIEC.INIBDNGHLPN = 0.7f;
			pKDCCCNJIEC.LIEABAMBOMG = 1.4f;
			pKDCCCNJIEC.FJLBLLLEELD = DFHALNOAGGC.PEBLJIFMBGC.Small;
			DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
			DFHALNOAGGC.GCHFGHAGJDG(nOCEDALFEJM);
		}
	}

	protected virtual void BAGCDJMLCPF()
	{
		base.Awake();
		FFOAABONJNO = GetComponent<DestroyableObject>();
		destroyableObject.AEJBIHBEOCP = true;
		NGMHBPOPFDN().OnDeath += BFHJDJCFBAI;
		NGMHBPOPFDN().OnDamage += LHNJAKKMNAD;
		NGCDDPCAGJB = base.transform;
		ILFPJEGPJJE = GetComponent<DroneSteering>();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		ILFPJEGPJJE.ArrivedToWayPoint += OPFMDIFOLOG;
	}

	[PunRPC]
	public virtual void ReSyncRPC(byte KFBOCCACLLK, Vector3 FLJHPFJFJIN, Quaternion OOMCGGAFJNH)
	{
		if (!base.isInstantiated || !ADEPHFKJEKG)
		{
			if (base.isInstantiated && !ADEPHFKJEKG)
			{
				DestroyPooled();
			}
			base.pool.ReInstantiate(this, FLJHPFJFJIN, OOMCGGAFJNH);
			SetFractionRPC(KFBOCCACLLK);
		}
	}

	public virtual void OEMOOAENMHN()
	{
		base.DestroyPooled();
		ILFPJEGPJJE.LDNELDGECPB();
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		ILFPJEGPJJE.Init();
		MLJMFMAIDIB.Stop();
		ADEPHFKJEKG = true;
		StopAllCoroutines();
		PFKPCFCEDME = false;
		Singleton<SoundsManager3D>.instance.PlayOneShot(base.gameObject, HINJJOAJAOA.PredatorDeployRepairDrone);
	}

	[SpecialName]
	public virtual void MDBJJHNADJE(Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> IDEBKDPMPGM)
	{
		Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> action = FJHBCIAKBPF;
		Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref FJHBCIAKBPF, (Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void JNJMPOHBFGN()
	{
		destroyableObject.healthbarColor = ((PlayerController.OGMBJPKOPCB.fraction == fraction) ? Color.green : Color.red);
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		ILFPJEGPJJE.Clear();
	}

	private void LHNJAKKMNAD(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if ((double)destroyableObject.healthRatio < 0.4)
		{
			MLJMFMAIDIB.Play();
		}
	}

	[SpecialName]
	public virtual void CPGAEHGKAHL(Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> IDEBKDPMPGM)
	{
		Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> action = FJHBCIAKBPF;
		Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref FJHBCIAKBPF, (Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	protected override void Awake()
	{
		base.Awake();
		FFOAABONJNO = GetComponent<DestroyableObject>();
		destroyableObject.AEJBIHBEOCP = true;
		destroyableObject.OnDeath += BFHJDJCFBAI;
		destroyableObject.OnDamage += LHNJAKKMNAD;
		NGCDDPCAGJB = base.transform;
		ILFPJEGPJJE = GetComponent<DroneSteering>();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		ILFPJEGPJJE.ArrivedToWayPoint += OPFMDIFOLOG;
	}

	protected override void Update()
	{
		base.Update();
		if (FEHCCGEGPLH.isMine && (int)Time.time > IAGLMAMNMFH)
		{
			IAGLMAMNMFH = (int)Time.time;
			if (transporterToRepair != null)
			{
				float num = repairRatioPerSec;
				transporterToRepair.destroyableObj.Heal(transporterToRepair.destroyableObj.maxHealth * num, CAKABHIPCDF: false);
			}
		}
	}

	private void OPFMDIFOLOG(WayPoint PKOKHMEOFKM)
	{
		if (PKOKHMEOFKM.INPLNAMBFPG > 0f)
		{
			PlaySparks();
		}
	}

	private void LAMHHNLGAGF(byte NJNEADGIFJM)
	{
		ODCLPMADGFC = (GHPGNELIDBM)NJNEADGIFJM;
		JNJMPOHBFGN();
		FFOAABONJNO.CBHBBLBDFOO(ODCLPMADGFC, MNFCGHNFFFF: true);
	}

	[SpecialName]
	public DestroyableObject NGMHBPOPFDN()
	{
		return FFOAABONJNO;
	}

	private void BFHJDJCFBAI(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		ILFPJEGPJJE.Clear();
		ILFPJEGPJJE.FallDown();
		ADEPHFKJEKG = false;
		if (FJHBCIAKBPF != null)
		{
			FJHBCIAKBPF(this, OHJPPHFEAFI);
		}
	}

	public void SetWayPoint(WayPointPath MFHFIHIHBHA)
	{
		ILFPJEGPJJE.SetWayPoint(MFHFIHIHBHA.wayPoints[0], this);
		ILFPJEGPJJE.PBPNIONACKO = MFHFIHIHBHA.transform;
		wayPointPath = MFHFIHIHBHA;
	}

	public void OCOCNNIBDCB(WayPointPath MFHFIHIHBHA)
	{
		ILFPJEGPJJE.SetWayPoint(MFHFIHIHBHA.wayPoints[1], this);
		ILFPJEGPJJE.PBPNIONACKO = MFHFIHIHBHA.transform;
		wayPointPath = MFHFIHIHBHA;
	}

	public virtual void DALOPJLLJPD()
	{
		if (base.isInstantiated)
		{
			OBCAIFMOPPA();
		}
	}

	protected virtual void NHAEGCBBJNP()
	{
		PIMNKPOIFOM();
		MLJMFMAIDIB.Stop();
	}

	[SpecialName]
	public void OGKJDPMBHEF(AICarTransporter IDEBKDPMPGM)
	{
		OANCIEHCCNA = IDEBKDPMPGM;
		GameShootableEntity component = GetComponent<GameShootableEntity>();
		if (component != null)
		{
			component.owner = OANCIEHCCNA;
			component.HAMHNNFOLEF(IDEBKDPMPGM: true);
		}
	}

	[SpecialName]
	public virtual void DIOEINBFJBG(Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> IDEBKDPMPGM)
	{
		Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> action = FJHBCIAKBPF;
		Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref FJHBCIAKBPF, (Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public virtual void BDLDAODODDA()
	{
		if (JHJJKEBNGEN())
		{
			DestroyPooled();
		}
	}

	public virtual void NCAELCJEIFC(byte KFBOCCACLLK, Vector3 FLJHPFJFJIN, Quaternion OOMCGGAFJNH)
	{
		if (!JHJJKEBNGEN() || !ADEPHFKJEKG)
		{
			if (base.isInstantiated && !ADEPHFKJEKG)
			{
				OBCAIFMOPPA();
			}
			DINLNPNCJMH().MEOJMCOPLAI(this, FLJHPFJFJIN, OOMCGGAFJNH);
			SetFractionRPC(KFBOCCACLLK);
		}
	}

	public virtual void NFOCLCJLGPP(byte KFBOCCACLLK, Vector3 FLJHPFJFJIN, Quaternion OOMCGGAFJNH)
	{
		if (!JHJJKEBNGEN() || !ADEPHFKJEKG)
		{
			if (JHJJKEBNGEN() && !ADEPHFKJEKG)
			{
				OBCAIFMOPPA();
			}
			GPCIHICHOJB().HFHLEPKHIJG(this, FLJHPFJFJIN, OOMCGGAFJNH);
			LAMHHNLGAGF(KFBOCCACLLK);
		}
	}

	protected virtual void GPLKEOAHFJI()
	{
		base.Update();
		if (FEHCCGEGPLH.isMine && (int)Time.time > IAGLMAMNMFH)
		{
			IAGLMAMNMFH = (int)Time.time;
			if (transporterToRepair != null)
			{
				float num = repairRatioPerSec;
				transporterToRepair.destroyableObj.LNPKAAGJIGO(transporterToRepair.destroyableObj.maxHealth * num, CAKABHIPCDF: true);
			}
		}
	}

	[SpecialName]
	public void LBFLPAKMIKM(float IDEBKDPMPGM)
	{
		_003CJENKLJFAGFD_003Ek__BackingField = IDEBKDPMPGM;
	}

	[PunRPC]
	public virtual void ReSyncDisabledRPC()
	{
		if (base.isInstantiated)
		{
			DestroyPooled();
		}
	}

	[SpecialName]
	public virtual GHPGNELIDBM EMIIJMBDCAB()
	{
		return ODCLPMADGFC;
	}

	private void IIGAJLCDNKM()
	{
		if (FEHCCGEGPLH.isMine)
		{
			FEHCCGEGPLH.RPC("ID_SALEPERCENTLINE", PhotonTargets.All);
		}
		NDMMMFFLNPJ.Play();
	}

	private void CMMOHGLMGDI(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		ILFPJEGPJJE.PJFMFICLKEA();
		ILFPJEGPJJE.IGCJCNFFALO();
		ADEPHFKJEKG = true;
		if (FJHBCIAKBPF != null)
		{
			FJHBCIAKBPF(this, OHJPPHFEAFI);
		}
	}

	[SpecialName]
	public virtual void EDDLDJJJGPF(GHPGNELIDBM IDEBKDPMPGM)
	{
		ODCLPMADGFC = IDEBKDPMPGM;
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[1];
		array[1] = (byte)IDEBKDPMPGM;
		fEHCCGEGPLH.RPC("menu-sidetab-challenge", PhotonTargets.All, array);
		JNJMPOHBFGN();
		FFOAABONJNO.ChangeLayer(ODCLPMADGFC, MNFCGHNFFFF: false);
	}

	public void ReSync()
	{
		if (ADEPHFKJEKG && base.isInstantiated)
		{
			LAADDLGBFIG.RPC("ReSyncRPC", PhotonTargets.Others, (byte)fraction, base.transform.position, base.transform.rotation);
			FFOAABONJNO.RefillTo(FFOAABONJNO.health);
		}
		else
		{
			LAADDLGBFIG.RPC("ReSyncDisabledRPC", PhotonTargets.Others);
		}
	}

	[PunRPC]
	private void SetFractionRPC(byte NJNEADGIFJM)
	{
		ODCLPMADGFC = (GHPGNELIDBM)NJNEADGIFJM;
		JNJMPOHBFGN();
		FFOAABONJNO.ChangeLayer(ODCLPMADGFC, MNFCGHNFFFF: false);
	}

	private void EGADEALAFFE(Collider AKLHJIBDAFA)
	{
		if (!ADEPHFKJEKG && !PFKPCFCEDME)
		{
			JPILOMEHDLN.DMHEGPIPEEH(JPILOMEHDLN.GOEFODHLMBC.VibrateError);
			PFKPCFCEDME = true;
			CDCOFHGPJHN(709f);
			DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
			pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
			pKDCCCNJIEC.JHGHGAFBDFG = NGMHBPOPFDN().maxHealth * 271f;
			pKDCCCNJIEC.EPDELOGPNAC = destroyableObject.maxHealth * 24f;
			pKDCCCNJIEC.HNFNINFCBEJ = this;
			pKDCCCNJIEC.CAKABHIPCDF = !FEHCCGEGPLH.isMine;
			pKDCCCNJIEC.INIBDNGHLPN = 345f;
			pKDCCCNJIEC.LIEABAMBOMG = 1188f;
			pKDCCCNJIEC.FJLBLLLEELD = DFHALNOAGGC.PEBLJIFMBGC.Small;
			DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
			DFHALNOAGGC.GKHNFCINDFK(nOCEDALFEJM);
		}
	}

	protected override void Start()
	{
		base.Start();
		MLJMFMAIDIB.Stop();
	}

	[SpecialName]
	public WayPointPath JAPHCAFHKGO()
	{
		return _003CLOKJMCAKHAI_003Ek__BackingField;
	}
}
