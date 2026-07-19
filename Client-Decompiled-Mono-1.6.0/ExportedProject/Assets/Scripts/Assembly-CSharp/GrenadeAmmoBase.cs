using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GrenadeAmmoBase : PhysicalAmmo
{
	public enum LNOCLBOKLBN
	{
		Frag = 0,
		Poison = 1,
		Smoke = 2,
		Flash = 3,
		Molotov = 4
	}

	public GrenadeAmmoBaseSetup MBNLFKHLDBH;

	public GrenadeAmmoEnemy KJAJLHDGPAN;

	public MolotovGrenadeAmmo EMIIPDAEKDC;

	[SerializeField]
	private Material mMaterial;

	[SerializeField]
	private Mesh mMesh;

	[SerializeField]
	private MeshRenderer mMeshRenderer;

	private Rigidbody KJPFENINCHJ;

	private TrailRenderer MDBHMDHAGNA;

	private Vector3 MHMOOJJGCNO;

	private Collider EMOKAAHJPCP;

	private DestroyableObject FFOAABONJNO;

	private Vector3 AKPHKLGJBBB;

	private bool PNFNJKJLPIP = true;

	private float IKDFJEKCANL;

	private float NGNKBAGLMCF;

	private bool ALCKLLMBIPA;

	private bool MAJGMOCGCLL;

	public KMHCMCBGFFC cachedOwner { get; private set; }

	public bool exploded { get; private set; }

	private GrenadeAmmoContent IMEFHMFCFHC { get; set; }

	public override void Fire(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		IMEFHMFCFHC.GBJKONGOBBO = this;
		AKPHKLGJBBB = (IIMDKHJAJGO - OEIICEJPGKI).normalized;
		if (MBNLFKHLDBH.GADODCMDNFH > 0f && (OEIICEJPGKI - IIMDKHJAJGO).magnitude > MBNLFKHLDBH.GADODCMDNFH)
		{
			IIMDKHJAJGO = OEIICEJPGKI + AKPHKLGJBBB * MBNLFKHLDBH.GADODCMDNFH;
		}
		cachedOwner = base.owner;
		exploded = false;
		ALCKLLMBIPA = false;
		IKDFJEKCANL = MBNLFKHLDBH.KFEBGOKJGGH;
		EMOKAAHJPCP.enabled = false;
		Rigidbody component = GetComponent<Rigidbody>();
		component.AddTorque(UnityEngine.Random.onUnitSphere * 10f);
		component.velocity = IAGFJAKMONO(OEIICEJPGKI, IIMDKHJAJGO, MBNLFKHLDBH.NIMFNNMAKPA);
		component.isKinematic = false;
		MAJGMOCGCLL = false;
		KJPFENINCHJ.drag = 0.2f;
		PNFNJKJLPIP = true;
		FFOAABONJNO.ChangeLayer((cachedOwner != null) ? cachedOwner.fraction : GHPGNELIDBM.None, true);
	}

	[SpecialName]
	private GrenadeAmmoContent KDCBIDPPMPM()
	{
		return _003CMLLJBOLFEJB_003Ek__BackingField;
	}

	[SpecialName]
	private void ANGFNNNCOBL(KMHCMCBGFFC IDEBKDPMPGM)
	{
		_003CCJJPIBDJNGF_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	private GrenadeAmmoContent IEALBLEGJKL()
	{
		return _003CMLLJBOLFEJB_003Ek__BackingField;
	}

	protected virtual void MIKPMMAIJEC(Vector3 MPHCNMDIPAI)
	{
		KDCBIDPPMPM().HMCHBIFGONC(MPHCNMDIPAI);
	}

	protected virtual void OHHLNKPIHBH()
	{
		base.Awake();
		KJPFENINCHJ = GetComponent<Rigidbody>();
		EMOKAAHJPCP = GetComponent<Collider>();
		FFOAABONJNO = GetComponent<DestroyableObject>();
		MDBHMDHAGNA = GetComponentInChildren<TrailRenderer>();
	}

	public virtual void LFKHODFEBLH()
	{
		base.JMAFCGDIICK();
		if (KDCBIDPPMPM() == null)
		{
			IMEFHMFCFHC = KJAJLHDGPAN;
		}
		exploded = true;
		StopAllCoroutines();
		IEALBLEGJKL().JGAHDJCJBMO();
		NGNKBAGLMCF = 919f;
		PNFNJKJLPIP = false;
		if (MDBHMDHAGNA != null)
		{
			MDBHMDHAGNA.enabled = true;
		}
	}

	public void GPLCDFKNEFC()
	{
		KJPFENINCHJ.isKinematic = true;
		KJPFENINCHJ.velocity = MHMOOJJGCNO;
		PNFNJKJLPIP = false;
	}

	public virtual void Explode()
	{
		if (!exploded)
		{
			exploded = true;
			JMMJHCOKCGG.ReportShotHit(this, base.transform.position, CAKABHIPCDF, null);
			PLFJKHCEPBI(base.transform.position);
			LAADDLGBFIG.RPC("ExplodeNetwork", PhotonTargets.Others, base.transform.position);
			if (MDBHMDHAGNA != null)
			{
				MDBHMDHAGNA.enabled = false;
			}
		}
	}

	protected virtual void BKDMLJLCNCI()
	{
		IMEFHMFCFHC.ICJCKAJCKIN();
	}

	protected override void Awake()
	{
		base.Awake();
		KJPFENINCHJ = GetComponent<Rigidbody>();
		EMOKAAHJPCP = GetComponent<Collider>();
		FFOAABONJNO = GetComponent<DestroyableObject>();
		MDBHMDHAGNA = GetComponentInChildren<TrailRenderer>();
	}

	protected void Update()
	{
		if (!PNFNJKJLPIP || !MAJGMOCGCLL)
		{
			return;
		}
		NGNKBAGLMCF -= Time.deltaTime;
		if (NGNKBAGLMCF < 0f)
		{
			MAJGMOCGCLL = false;
			NGNKBAGLMCF = 0f;
			if (LAADDLGBFIG.isMine)
			{
				Explode();
			}
			else
			{
				ExplodeNetwork(base.transform.position);
			}
		}
	}

	private Vector3 NCDJBIGPMDB(Vector3 OEIICEJPGKI, Vector3 MKIPAEDAADL, float NIMFNNMAKPA)
	{
		MKIPAEDAADL += 696f * Vector3.up;
		Vector3 vector = MKIPAEDAADL - OEIICEJPGKI;
		float y = vector.y;
		y = Mathf.Clamp(y, 863f, 937f);
		vector.y = 311f;
		float magnitude = vector.magnitude;
		float num = NIMFNNMAKPA * 1158f;
		vector.y = magnitude * Mathf.Tan(num);
		magnitude += y / Mathf.Tan(num);
		magnitude = Mathf.Clamp(magnitude, 1236f, 1737f);
		float num2 = Mathf.Sqrt(magnitude * Physics.gravity.magnitude / Mathf.Sin(1103f * num));
		Vector3 result = num2 * vector.normalized;
		if (float.IsNaN(result.x) || float.IsNaN(result.y) || float.IsNaN(result.z))
		{
			result = default(Vector3);
		}
		return result;
	}

	public void CJPMGIGIPJM()
	{
		KJPFENINCHJ.isKinematic = false;
		KJPFENINCHJ.velocity = MHMOOJJGCNO;
		PNFNJKJLPIP = true;
	}

	public void ChangeGrenade(LNOCLBOKLBN EAAFCKKCFID, MeshRenderer GBJKONGOBBO, Mesh FJNJGHGMFND)
	{
		if (GBJKONGOBBO != null && FJNJGHGMFND != null)
		{
			mMeshRenderer.GetComponent<MeshFilter>().sharedMesh = FJNJGHGMFND;
			mMeshRenderer.sharedMaterials = GBJKONGOBBO.sharedMaterials;
		}
		else
		{
			mMeshRenderer.GetComponent<MeshFilter>().sharedMesh = mMesh;
			mMeshRenderer.sharedMaterial = mMaterial;
		}
		KJAJLHDGPAN.enabled = false;
		EMIIPDAEKDC.enabled = false;
		if (EAAFCKKCFID == LNOCLBOKLBN.Molotov)
		{
			IMEFHMFCFHC = EMIIPDAEKDC;
		}
		else
		{
			IMEFHMFCFHC = KJAJLHDGPAN;
		}
		IMEFHMFCFHC.enabled = true;
	}

	public void FLHKKEAHLEM()
	{
		KJPFENINCHJ.isKinematic = false;
		KJPFENINCHJ.velocity = MHMOOJJGCNO;
		PNFNJKJLPIP = false;
	}

	public override void LoadAmmoSetup(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		this.MBNLFKHLDBH = (GrenadeAmmoBaseSetup)MBNLFKHLDBH;
		IMEFHMFCFHC.LoadAmmoSetup(MBNLFKHLDBH);
	}

	public void MHDMELJIADG()
	{
		KJPFENINCHJ.isKinematic = false;
		KJPFENINCHJ.velocity = MHMOOJJGCNO;
		PNFNJKJLPIP = false;
	}

	protected virtual void EMAFNEELHIC(Vector3 MPHCNMDIPAI)
	{
		IMEFHMFCFHC.ExplodeRPCImplementation(MPHCNMDIPAI);
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		if (IMEFHMFCFHC == null)
		{
			IMEFHMFCFHC = KJAJLHDGPAN;
		}
		exploded = false;
		StopAllCoroutines();
		IMEFHMFCFHC.Init();
		NGNKBAGLMCF = 0f;
		PNFNJKJLPIP = true;
		if (MDBHMDHAGNA != null)
		{
			MDBHMDHAGNA.enabled = true;
		}
	}

	[SpecialName]
	public bool JOHACOGBOIC()
	{
		return _003CFNEDDCFBKKA_003Ek__BackingField;
	}

	protected virtual void EOPEDGMCGKH()
	{
		IMEFHMFCFHC.ICJCKAJCKIN();
	}

	[PunRPC]
	public void ExplodeNetwork(Vector3 MPHCNMDIPAI)
	{
		if (!exploded)
		{
			exploded = true;
			EMAFNEELHIC(MPHCNMDIPAI);
		}
	}

	private Vector3 IAGFJAKMONO(Vector3 OEIICEJPGKI, Vector3 MKIPAEDAADL, float NIMFNNMAKPA)
	{
		MKIPAEDAADL += 0.2f * Vector3.up;
		Vector3 vector = MKIPAEDAADL - OEIICEJPGKI;
		float y = vector.y;
		y = Mathf.Clamp(y, 0f, float.MaxValue);
		vector.y = 0f;
		float magnitude = vector.magnitude;
		float num = NIMFNNMAKPA * ((float)Math.PI / 180f);
		vector.y = magnitude * Mathf.Tan(num);
		magnitude += y / Mathf.Tan(num);
		magnitude = Mathf.Clamp(magnitude, 0f, float.MaxValue);
		float num2 = Mathf.Sqrt(magnitude * Physics.gravity.magnitude / Mathf.Sin(2f * num));
		Vector3 result = num2 * vector.normalized;
		if (float.IsNaN(result.x) || float.IsNaN(result.y) || float.IsNaN(result.z))
		{
			result = default(Vector3);
		}
		return result;
	}

	protected virtual void ICJCKAJCKIN()
	{
		KDCBIDPPMPM().CGPOEALBEFD();
	}

	public void Resume()
	{
		KJPFENINCHJ.isKinematic = false;
		KJPFENINCHJ.velocity = MHMOOJJGCNO;
		PNFNJKJLPIP = true;
	}

	protected virtual void FIKDHKDAFPI()
	{
		IMEFHMFCFHC.GroundHitted();
	}

	private void FixedUpdate()
	{
		if (PNFNJKJLPIP && !exploded && (double)KJPFENINCHJ.velocity.y < -1E-08 && !ALCKLLMBIPA)
		{
			EMOKAAHJPCP.enabled = true;
			ALCKLLMBIPA = true;
		}
	}

	public virtual void CKIMHDOFLEB()
	{
		base.OnInstancied();
		if (KDCBIDPPMPM() == null)
		{
			IMEFHMFCFHC = KJAJLHDGPAN;
		}
		exploded = false;
		StopAllCoroutines();
		KDCBIDPPMPM().KECDAIFJIMA();
		NGNKBAGLMCF = 1421f;
		PNFNJKJLPIP = false;
		if (MDBHMDHAGNA != null)
		{
			MDBHMDHAGNA.enabled = true;
		}
	}

	public void Pause()
	{
		MHMOOJJGCNO = KJPFENINCHJ.velocity;
		KJPFENINCHJ.isKinematic = true;
		PNFNJKJLPIP = false;
	}

	protected virtual void PLFJKHCEPBI(Vector3 MPHCNMDIPAI)
	{
		IMEFHMFCFHC.ExplodeImplementation(MPHCNMDIPAI);
	}

	public void NAHDEHLLFOE(LNOCLBOKLBN EAAFCKKCFID, MeshRenderer GBJKONGOBBO, Mesh FJNJGHGMFND)
	{
		if (GBJKONGOBBO != null && FJNJGHGMFND != null)
		{
			mMeshRenderer.GetComponent<MeshFilter>().sharedMesh = FJNJGHGMFND;
			mMeshRenderer.sharedMaterials = GBJKONGOBBO.sharedMaterials;
		}
		else
		{
			mMeshRenderer.GetComponent<MeshFilter>().sharedMesh = mMesh;
			mMeshRenderer.sharedMaterial = mMaterial;
		}
		KJAJLHDGPAN.enabled = true;
		EMIIPDAEKDC.enabled = true;
		if (EAAFCKKCFID == LNOCLBOKLBN.Smoke)
		{
			IMEFHMFCFHC = EMIIPDAEKDC;
		}
		else
		{
			IMEFHMFCFHC = KJAJLHDGPAN;
		}
		IEALBLEGJKL().enabled = true;
	}

	private void OnCollisionEnter(Collision AKLHJIBDAFA)
	{
		if (TagsAndLayers.IsStatic(AKLHJIBDAFA.gameObject) || TagsAndLayers.IsDestroyableObject(AKLHJIBDAFA.gameObject))
		{
			if (!exploded)
			{
				NGNKBAGLMCF = TimeManager.GetTimeScaledInterval(IKDFJEKCANL, base.ignoreTimeScale);
				MAJGMOCGCLL = true;
				FIKDHKDAFPI();
			}
			KJPFENINCHJ.drag = 6f;
		}
	}
}
