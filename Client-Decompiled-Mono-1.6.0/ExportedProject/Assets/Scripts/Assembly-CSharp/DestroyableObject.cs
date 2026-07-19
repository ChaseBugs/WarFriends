using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using CodeStage.AntiCheat.ObscuredTypes;
using Google2u;
using UnityEngine;

public class DestroyableObject : Core_BaseScript, KMHCMCBGFFC
{
	public enum MANAGOLPMLH
	{
		Shot = 0,
		Explosion = 1,
		Shiver = 2,
		Basic = 3,
		Poison = 4,
		Flame = 5,
		Heal = 6,
		Immortal = 7,
		Suicide = 8
	}

	public struct CJLNCMMNPBM
	{
		public MANAGOLPMLH FJLBLLLEELD;

		public float EPDELOGPNAC;

		public Vector3 LPGMLOCLBGP;

		public bool CCFJFAMEODO;

		public Weapon JMMJHCOKCGG;

		public KMHCMCBGFFC HNFNINFCBEJ;

		public bool KLOJNPBGFIG;

		public byte MEFOHLAIBFA;

		public Vector3 OHNCLEOMHCF;

		public bool NLJFIIEGHCK;

		public float HOLHMENGGOC;

		public bool DBFIOEAHJFD;
	}

	[SerializeField]
	private ObscuredFloat mMaxHealth = 1000f;

	private string OKDOCOLEBLJ = string.Empty;

	[SerializeField]
	private bool mDestroyableByBonusBox = true;

	protected bool IHIEMNMKCEE;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action<DestroyableObject, CJLNCMMNPBM> EKDKBACABCK;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action<DestroyableObject, CJLNCMMNPBM> FHEMDCFGMMF;

	public Transform HIPAPKDJBNL;

	public bool JEGFCLCJMLA;

	public Vector3 MKOGHDKDFIN;

	public bool LMEKEPANAJI;

	public bool NBNDIIENBLK = true;

	public bool AEJBIHBEOCP;

	public float HHOCGCLBHKB = 1f;

	public List<string> HEFDIGJBKED;

	protected PhotonView FEHCCGEGPLH;

	private ObscuredBool CCFJNDFBOAK;

	public Healthbar.NGLEBBHJCJG GEKFNCJIDNI;

	[SerializeField]
	protected Color mHealthbarColor = Color.green;

	protected Transform CDKBFIGEBOA;

	protected Transform CHHHEFFBGLC;

	public Healthbar GPLNJOPPKIM;

	protected Vector3 MMANIGLDGEH;

	private Vector3 FDLBJLNOBLG;

	private byte FHDDLICKIEO;

	private byte NIPNBBOKENF;

	protected Camera GNICEGBOGOL;

	private byte GLLFFIHFCEF = byte.MaxValue;

	private CJLNCMMNPBM MHFIGDEMOCJ;

	public HINJJOAJAOA JFPMMLGBGPE = HINJJOAJAOA.ShieldHit;

	private ObscuredFloat LEMMBHKKJEO { get; set; }

	public virtual bool destroyableByBonusBox
	{
		get
		{
			return mDestroyableByBonusBox;
		}
		set
		{
			mDestroyableByBonusBox = value;
		}
	}

	public float maxHealth
	{
		get
		{
			return mMaxHealth;
		}
		set
		{
			mMaxHealth = value;
		}
	}

	public virtual DestroyableObject mainDestroyableObject
	{
		get
		{
			return this;
		}
	}

	public virtual GHPGNELIDBM fraction
	{
		get
		{
			if (owner == null)
			{
				return GHPGNELIDBM.None;
			}
			return owner.fraction;
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public virtual KMHCMCBGFFC owner { get; set; }

	protected virtual bool HEFCGCLCANF
	{
		get
		{
			return true;
		}
	}

	public Vector3 velocity
	{
		get
		{
			return FDLBJLNOBLG / Time.deltaTime;
		}
	}

	public virtual float healthRatio
	{
		get
		{
			return Mathf.Clamp01((float)LEMMBHKKJEO / maxHealth);
		}
		set
		{
			health = maxHealth * value;
		}
	}

	public virtual float health
	{
		get
		{
			return LEMMBHKKJEO;
		}
		set
		{
			LEMMBHKKJEO = value;
			LEMMBHKKJEO = Mathf.Clamp(LEMMBHKKJEO, float.NegativeInfinity, maxHealth);
		}
	}

	public Color healthbarColor
	{
		get
		{
			return mHealthbarColor;
		}
		set
		{
			mHealthbarColor = value;
			if (GPLNJOPPKIM != null)
			{
				GPLNJOPPKIM.color = mHealthbarColor;
			}
		}
	}

	public bool isDead
	{
		get
		{
			return IHIEMNMKCEE;
		}
	}

	private bool PFMKNMNBJKA
	{
		get
		{
			return DebugSettings.debugEnabled;
		}
	}

	public bool isImmortal
	{
		get
		{
			return CCFJNDFBOAK;
		}
		set
		{
			if ((bool)CCFJNDFBOAK != value)
			{
				CCFJNDFBOAK = value;
				FEHCCGEGPLH.RPC("SetIsImmortalRPC", PhotonTargets.Others, value);
			}
		}
	}

	public event Action<DestroyableObject, CJLNCMMNPBM> OnDamage
	{
		add
		{
			Action<DestroyableObject, CJLNCMMNPBM> action = EKDKBACABCK;
			Action<DestroyableObject, CJLNCMMNPBM> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref EKDKBACABCK, (Action<DestroyableObject, CJLNCMMNPBM>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<DestroyableObject, CJLNCMMNPBM> action = EKDKBACABCK;
			Action<DestroyableObject, CJLNCMMNPBM> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref EKDKBACABCK, (Action<DestroyableObject, CJLNCMMNPBM>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public event Action<DestroyableObject, CJLNCMMNPBM> OnDeath
	{
		add
		{
			Action<DestroyableObject, CJLNCMMNPBM> action = FHEMDCFGMMF;
			Action<DestroyableObject, CJLNCMMNPBM> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref FHEMDCFGMMF, (Action<DestroyableObject, CJLNCMMNPBM>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<DestroyableObject, CJLNCMMNPBM> action = FHEMDCFGMMF;
			Action<DestroyableObject, CJLNCMMNPBM> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref FHEMDCFGMMF, (Action<DestroyableObject, CJLNCMMNPBM>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	private void OnDisable()
	{
		if (LMEKEPANAJI && GPLNJOPPKIM != null)
		{
			GPLNJOPPKIM.DestroyPooled();
		}
		GPLNJOPPKIM = null;
		OKDOCOLEBLJ = string.Empty;
	}

	protected virtual void LOGACKIDIBF()
	{
		if (LMEKEPANAJI && GPLNJOPPKIM != null)
		{
			GPLNJOPPKIM.OHONEPMDAMM(healthRatio);
			Vector3 point = GNICEGBOGOL.WorldToNormalizedViewportPoint(HIPAPKDJBNL.position);
			float num = Vector3.Distance(HIPAPKDJBNL.position, GNICEGBOGOL.transform.position);
			float num2 = Mathf.Clamp(1927f / num, 3f, 362f);
			Vector3 localScale = new Vector3(num2, num2, num2);
			CHHHEFFBGLC.localScale = localScale;
			CHHHEFFBGLC.position = MKOGHDKDFIN * num2 + HealthBarManager.JCEKIJCAMGH().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
		}
		FDLBJLNOBLG = CDKBFIGEBOA.position - MMANIGLDGEH;
		MMANIGLDGEH = CDKBFIGEBOA.position;
	}

	public virtual void Burn(float CJDCGPMIHEA, Vector3 DIAKDJLIJAN, Vector3 LPGMLOCLBGP, Weapon AEJJCMHDFBA, KMHCMCBGFFC ELOOOFODMNP, bool CAKABHIPCDF, bool NLJFIIEGHCK)
	{
		if (!CAKABHIPCDF)
		{
			DoDamage(new CJLNCMMNPBM
			{
				LPGMLOCLBGP = LPGMLOCLBGP,
				EPDELOGPNAC = CJDCGPMIHEA * HHOCGCLBHKB,
				FJLBLLLEELD = MANAGOLPMLH.Flame,
				JMMJHCOKCGG = AEJJCMHDFBA,
				HNFNINFCBEJ = ELOOOFODMNP,
				OHNCLEOMHCF = DIAKDJLIJAN,
				NLJFIIEGHCK = NLJFIIEGHCK
			});
		}
	}

	public void Shiver(float CJDCGPMIHEA, Vector3 LPGMLOCLBGP, Weapon AEJJCMHDFBA, KMHCMCBGFFC ELOOOFODMNP, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			DoDamage(new CJLNCMMNPBM
			{
				LPGMLOCLBGP = LPGMLOCLBGP,
				EPDELOGPNAC = CJDCGPMIHEA,
				FJLBLLLEELD = MANAGOLPMLH.Shiver,
				JMMJHCOKCGG = AEJJCMHDFBA,
				HNFNINFCBEJ = ELOOOFODMNP
			});
		}
	}

	public virtual void MPDGGFOFNMJ(GHPGNELIDBM CIOPAKLHFIL, bool MNFCGHNFFFF)
	{
		int layer = Singleton<TagsAndLayers>.instance.MHMMLBHAOCI(CIOPAKLHFIL, MNFCGHNFFFF);
		base.gameObject.layer = layer;
	}

	public void HAADJCJHECF(float CJDCGPMIHEA, Vector3 LPGMLOCLBGP, Weapon AEJJCMHDFBA, KMHCMCBGFFC ELOOOFODMNP, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF && !AEJBIHBEOCP)
		{
			DoDamage(new CJLNCMMNPBM
			{
				LPGMLOCLBGP = LPGMLOCLBGP,
				EPDELOGPNAC = CJDCGPMIHEA,
				FJLBLLLEELD = MANAGOLPMLH.Suicide,
				JMMJHCOKCGG = AEJJCMHDFBA,
				HNFNINFCBEJ = ELOOOFODMNP
			});
		}
	}

	protected void PGKPEONGOID(float EPDELOGPNAC, byte FJLBLLLEELD, byte AKGDPKJCILO, byte FMAOPCINBDA, byte MEFOHLAIBFA, Vector3 MDOPFNNFLFB, Vector3 LPGMLOCLBGP, bool MBAGBOIGODP)
	{
		KMHCMCBGFFC hNFNINFCBEJ = null;
		if (AKGDPKJCILO > 0 || FMAOPCINBDA > 0)
		{
			PoolableObject poolableObject = ObjectPoolDatabase.networkPool.CALAKLNMEFF[AKGDPKJCILO][FMAOPCINBDA];
			hNFNINFCBEJ = poolableObject as KMHCMCBGFFC;
		}
		KKOFHGIAJNE(new CJLNCMMNPBM
		{
			EPDELOGPNAC = EPDELOGPNAC,
			KLOJNPBGFIG = true,
			FJLBLLLEELD = (MANAGOLPMLH)FJLBLLLEELD,
			HNFNINFCBEJ = hNFNINFCBEJ,
			MEFOHLAIBFA = MEFOHLAIBFA,
			OHNCLEOMHCF = CDKBFIGEBOA.TransformPoint(MDOPFNNFLFB),
			LPGMLOCLBGP = LPGMLOCLBGP
		}, MBAGBOIGODP);
	}

	[PunRPC]
	protected virtual void RefillRPC(float MNAJKODCACI, float NKKIGGNCDLL)
	{
		IHIEMNMKCEE = false;
		CCFJNDFBOAK = false;
		maxHealth = NKKIGGNCDLL;
		health = MNAJKODCACI;
	}

	[SpecialName]
	public virtual void GGMFIDCAFGM(KMHCMCBGFFC IDEBKDPMPGM)
	{
		_003COPCFPJLGOLK_003Ek__BackingField = IDEBKDPMPGM;
	}

	[PunRPC]
	protected virtual void DamageEvent(float MNAJKODCACI, byte FJLBLLLEELD, byte AKGDPKJCILO, byte FMAOPCINBDA)
	{
		PGKPEONGOID(MNAJKODCACI, FJLBLLLEELD, AKGDPKJCILO, FMAOPCINBDA, 0, Vector3.zero, Vector3.zero, false);
	}

	[PunRPC]
	protected virtual void DeathEventShoot(float MNAJKODCACI, byte FJLBLLLEELD, byte AKGDPKJCILO, byte FMAOPCINBDA, byte MEFOHLAIBFA, Vector3 MDOPFNNFLFB, Vector3 LPGMLOCLBGP)
	{
		PGKPEONGOID(MNAJKODCACI, FJLBLLLEELD, AKGDPKJCILO, FMAOPCINBDA, MEFOHLAIBFA, MDOPFNNFLFB, LPGMLOCLBGP, true);
	}

	public void Disable()
	{
		IHIEMNMKCEE = true;
	}

	[SpecialName]
	private ObscuredFloat PLNNBNEEBFC()
	{
		return _003CNBKAGGBFMBE_003Ek__BackingField;
	}

	[SpecialName]
	public virtual void MNMCGGIINIF(float IDEBKDPMPGM)
	{
		health = maxHealth * IDEBKDPMPGM;
	}

	public virtual void HEGJMOOMPLI(GHPGNELIDBM CIOPAKLHFIL, bool MNFCGHNFFFF)
	{
		int layer = Singleton<TagsAndLayers>.instance.ALDBGABJCKN(CIOPAKLHFIL, MNFCGHNFFFF);
		base.gameObject.layer = layer;
	}

	public void LNPKAAGJIGO(float NEJNIEEHCKJ, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			DoDamage(new CJLNCMMNPBM
			{
				LPGMLOCLBGP = Vector3.zero,
				EPDELOGPNAC = 0f - NEJNIEEHCKJ,
				FJLBLLLEELD = MANAGOLPMLH.Basic,
				JMMJHCOKCGG = null,
				HNFNINFCBEJ = null
			});
		}
	}

	public virtual void DDLOHJKGEPG(Vector3 LPGMLOCLBGP, float CJDCGPMIHEA, Weapon AEJJCMHDFBA, KMHCMCBGFFC ELOOOFODMNP, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			DoDamage(new CJLNCMMNPBM
			{
				EPDELOGPNAC = CJDCGPMIHEA,
				LPGMLOCLBGP = LPGMLOCLBGP,
				FJLBLLLEELD = MANAGOLPMLH.Explosion,
				JMMJHCOKCGG = AEJJCMHDFBA,
				HNFNINFCBEJ = ELOOOFODMNP
			});
		}
	}

	public void JEODCHPDDEI(float CJDCGPMIHEA, Vector3 LPGMLOCLBGP, Weapon AEJJCMHDFBA, KMHCMCBGFFC ELOOOFODMNP, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			DoDamage(new CJLNCMMNPBM
			{
				LPGMLOCLBGP = LPGMLOCLBGP,
				EPDELOGPNAC = CJDCGPMIHEA,
				FJLBLLLEELD = MANAGOLPMLH.Shiver,
				JMMJHCOKCGG = AEJJCMHDFBA,
				HNFNINFCBEJ = ELOOOFODMNP
			});
		}
	}

	[PunRPC]
	protected virtual void DamageEventShoot(float MNAJKODCACI, byte FJLBLLLEELD, byte AKGDPKJCILO, byte FMAOPCINBDA, byte MEFOHLAIBFA, Vector3 MDOPFNNFLFB)
	{
		PGKPEONGOID(MNAJKODCACI, FJLBLLLEELD, AKGDPKJCILO, FMAOPCINBDA, MEFOHLAIBFA, MDOPFNNFLFB, Vector3.zero, false);
	}

	public void Suicide(float CJDCGPMIHEA, Vector3 LPGMLOCLBGP, Weapon AEJJCMHDFBA, KMHCMCBGFFC ELOOOFODMNP, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			DoDamage(new CJLNCMMNPBM
			{
				LPGMLOCLBGP = LPGMLOCLBGP,
				EPDELOGPNAC = CJDCGPMIHEA,
				FJLBLLLEELD = MANAGOLPMLH.Suicide,
				JMMJHCOKCGG = AEJJCMHDFBA,
				HNFNINFCBEJ = ELOOOFODMNP
			});
		}
	}

	public virtual void Shoot(float CJDCGPMIHEA, Vector3 DIAKDJLIJAN, Vector3 LPGMLOCLBGP, Weapon AEJJCMHDFBA, KMHCMCBGFFC ELOOOFODMNP, bool CAKABHIPCDF, bool NLJFIIEGHCK)
	{
		if (CAKABHIPCDF)
		{
			return;
		}
		DoDamage(new CJLNCMMNPBM
		{
			LPGMLOCLBGP = LPGMLOCLBGP,
			EPDELOGPNAC = CJDCGPMIHEA * HHOCGCLBHKB,
			FJLBLLLEELD = MANAGOLPMLH.Shot,
			JMMJHCOKCGG = AEJJCMHDFBA,
			HNFNINFCBEJ = ELOOOFODMNP,
			OHNCLEOMHCF = DIAKDJLIJAN,
			NLJFIIEGHCK = NLJFIIEGHCK
		});
		if (HEFCGCLCANF)
		{
			foreach (string item in HEFDIGJBKED)
			{
				Singleton<HitParticleSystem>.instance.PlayParticle(DIAKDJLIJAN, LPGMLOCLBGP, item);
			}
		}
		if (NBNDIIENBLK)
		{
			Singleton<HitParticleSystem>.instance.PlayParticle(DIAKDJLIJAN, LPGMLOCLBGP, 2);
		}
		PlaySound(JFPMMLGBGPE);
	}

	[SpecialName]
	public void PCJDPFLIAJJ(Color IDEBKDPMPGM)
	{
		mHealthbarColor = IDEBKDPMPGM;
		if (GPLNJOPPKIM != null)
		{
			GPLNJOPPKIM.color = mHealthbarColor;
		}
	}

	public void Heal(float NEJNIEEHCKJ, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			DoDamage(new CJLNCMMNPBM
			{
				LPGMLOCLBGP = Vector3.zero,
				EPDELOGPNAC = 0f - NEJNIEEHCKJ,
				FJLBLLLEELD = MANAGOLPMLH.Basic,
				JMMJHCOKCGG = null,
				HNFNINFCBEJ = null
			});
		}
	}

	public void JHNIBNBEGFJ()
	{
		IHIEMNMKCEE = false;
	}

	public void Poison(float CJDCGPMIHEA, Vector3 LPGMLOCLBGP, Weapon AEJJCMHDFBA, KMHCMCBGFFC ELOOOFODMNP, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF && !AEJBIHBEOCP)
		{
			DoDamage(new CJLNCMMNPBM
			{
				LPGMLOCLBGP = LPGMLOCLBGP,
				EPDELOGPNAC = CJDCGPMIHEA,
				FJLBLLLEELD = MANAGOLPMLH.Poison,
				JMMJHCOKCGG = AEJJCMHDFBA,
				HNFNINFCBEJ = ELOOOFODMNP
			});
		}
	}

	public virtual void MFOLMJGHKBL(DestroyableObject OJIHGNJFPFM, CJLNCMMNPBM KMJKKNFDFMM)
	{
		IHIEMNMKCEE = false;
		if (FHEMDCFGMMF != null)
		{
			FHEMDCFGMMF(OJIHGNJFPFM, KMJKKNFDFMM);
		}
	}

	protected void LLGOAKNKNJK(CJLNCMMNPBM KMJKKNFDFMM)
	{
		MHFIGDEMOCJ = KMJKKNFDFMM;
		FHDDLICKIEO = 0;
		NIPNBBOKENF = 0;
		GLLFFIHFCEF = byte.MaxValue;
		PlayerController playerController = KMJKKNFDFMM.HNFNINFCBEJ as PlayerController;
		if (playerController != null)
		{
			GLLFFIHFCEF = (byte)playerController.NAGAHNHAKBJ;
		}
		else
		{
			PoolableObject poolableObject = KMJKKNFDFMM.HNFNINFCBEJ as PoolableObject;
			if (poolableObject != null && poolableObject.pool != null)
			{
				FHDDLICKIEO = (byte)poolableObject.indexInObjectPool;
				NIPNBBOKENF = (byte)poolableObject.pool.APCGDLEHGKL[poolableObject.prefab];
			}
		}
		if (FEHCCGEGPLH == null)
		{
			return;
		}
		if (health > 0f)
		{
			if (MHFIGDEMOCJ.FJLBLLLEELD == MANAGOLPMLH.Shot)
			{
				Vector3 vector = CDKBFIGEBOA.InverseTransformPoint(MHFIGDEMOCJ.OHNCLEOMHCF);
				if (GLLFFIHFCEF == byte.MaxValue)
				{
					FEHCCGEGPLH.RPC("DamageEventShoot", PhotonTargets.Others, KMJKKNFDFMM.EPDELOGPNAC, (byte)MHFIGDEMOCJ.FJLBLLLEELD, NIPNBBOKENF, FHDDLICKIEO, MHFIGDEMOCJ.MEFOHLAIBFA, vector);
					return;
				}
				FEHCCGEGPLH.RPC("DamageEventPlayerShoot", PhotonTargets.Others, KMJKKNFDFMM.EPDELOGPNAC, (byte)MHFIGDEMOCJ.FJLBLLLEELD, GLLFFIHFCEF, MHFIGDEMOCJ.MEFOHLAIBFA, vector);
				if (PFMKNMNBJKA)
				{
					UnityEngine.Debug.Log(string.Format("DamageEventPlayerShoot damage: {0} to {1} new HP {2}", KMJKKNFDFMM.EPDELOGPNAC, owner, health));
				}
			}
			else if (GLLFFIHFCEF == byte.MaxValue)
			{
				FEHCCGEGPLH.RPC("DamageEvent", PhotonTargets.Others, KMJKKNFDFMM.EPDELOGPNAC, (byte)MHFIGDEMOCJ.FJLBLLLEELD, NIPNBBOKENF, FHDDLICKIEO);
			}
			else
			{
				FEHCCGEGPLH.RPC("DamageEventPlayer", PhotonTargets.Others, KMJKKNFDFMM.EPDELOGPNAC, (byte)MHFIGDEMOCJ.FJLBLLLEELD, GLLFFIHFCEF);
				if (PFMKNMNBJKA)
				{
					UnityEngine.Debug.Log(string.Format("DamageEventPlayer damage: {0} to {1} new HP {2}", KMJKKNFDFMM.EPDELOGPNAC, owner, health));
				}
			}
		}
		else if (MHFIGDEMOCJ.FJLBLLLEELD == MANAGOLPMLH.Shot)
		{
			Vector3 vector2 = CDKBFIGEBOA.InverseTransformPoint(MHFIGDEMOCJ.OHNCLEOMHCF);
			if (GLLFFIHFCEF == byte.MaxValue)
			{
				FEHCCGEGPLH.RPC("DeathEventShoot", PhotonTargets.Others, KMJKKNFDFMM.EPDELOGPNAC, (byte)MHFIGDEMOCJ.FJLBLLLEELD, NIPNBBOKENF, FHDDLICKIEO, MHFIGDEMOCJ.MEFOHLAIBFA, vector2, MHFIGDEMOCJ.LPGMLOCLBGP);
				return;
			}
			FEHCCGEGPLH.RPC("DeathEventPlayerShoot", PhotonTargets.Others, KMJKKNFDFMM.EPDELOGPNAC, (byte)MHFIGDEMOCJ.FJLBLLLEELD, GLLFFIHFCEF, MHFIGDEMOCJ.MEFOHLAIBFA, vector2, MHFIGDEMOCJ.LPGMLOCLBGP);
			if (PFMKNMNBJKA)
			{
				UnityEngine.Debug.Log(string.Format("DeathEventPlayerShoot damage: {0} to {1} new HP {2}", KMJKKNFDFMM.EPDELOGPNAC, owner, health));
			}
		}
		else if (GLLFFIHFCEF == byte.MaxValue)
		{
			FEHCCGEGPLH.RPC("DeathEvent", PhotonTargets.Others, KMJKKNFDFMM.EPDELOGPNAC, (byte)MHFIGDEMOCJ.FJLBLLLEELD, NIPNBBOKENF, FHDDLICKIEO, MHFIGDEMOCJ.LPGMLOCLBGP);
		}
		else
		{
			FEHCCGEGPLH.RPC("DeathEventPlayer", PhotonTargets.Others, KMJKKNFDFMM.EPDELOGPNAC, (byte)MHFIGDEMOCJ.FJLBLLLEELD, GLLFFIHFCEF, MHFIGDEMOCJ.LPGMLOCLBGP);
			if (PFMKNMNBJKA)
			{
				UnityEngine.Debug.Log(string.Format("DeathEventPlayer damage: {0} to {1} new HP {2}", KMJKKNFDFMM.EPDELOGPNAC, owner, health));
			}
		}
	}

	public void IODGCIGOLKG(float CJDCGPMIHEA, Vector3 LPGMLOCLBGP, Weapon AEJJCMHDFBA, KMHCMCBGFFC ELOOOFODMNP, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF && !AEJBIHBEOCP)
		{
			DoDamage(new CJLNCMMNPBM
			{
				LPGMLOCLBGP = LPGMLOCLBGP,
				EPDELOGPNAC = CJDCGPMIHEA,
				FJLBLLLEELD = MANAGOLPMLH.Poison,
				JMMJHCOKCGG = AEJJCMHDFBA,
				HNFNINFCBEJ = ELOOOFODMNP
			});
		}
	}

	protected virtual void GGPILMECPDC(float MNAJKODCACI, byte FJLBLLLEELD, byte FFLOJLDIHGI)
	{
		JOPGOFCDHIO(MNAJKODCACI, FJLBLLLEELD, FFLOJLDIHGI, 0, Vector3.zero, Vector3.zero, false);
	}

	public virtual void ChangeLayer(GHPGNELIDBM CIOPAKLHFIL, bool MNFCGHNFFFF)
	{
		int fractionBulletLayer = Singleton<TagsAndLayers>.instance.GetFractionBulletLayer(CIOPAKLHFIL, MNFCGHNFFFF);
		base.gameObject.layer = fractionBulletLayer;
	}

	[SpecialName]
	public virtual void GMNNGEELOFC(float IDEBKDPMPGM)
	{
		LEMMBHKKJEO = IDEBKDPMPGM;
		LEMMBHKKJEO = Mathf.Clamp(PLNNBNEEBFC(), 1644f, maxHealth);
	}

	public void MCHGNPBACBJ(float MNAJKODCACI)
	{
		health = MNAJKODCACI;
		CCFJNDFBOAK = true;
		IHIEMNMKCEE = true;
		if (!(FEHCCGEGPLH == null))
		{
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[2];
			array[1] = health;
			array[1] = maxHealth;
			fEHCCGEGPLH.RPC("FeaturedVideos", PhotonTargets.Others, array);
		}
	}

	protected void FHMPHEBJCCN(DestroyableObject ENCEFOOPBMK, CJLNCMMNPBM KMJKKNFDFMM)
	{
		if (EKDKBACABCK != null)
		{
			EKDKBACABCK(ENCEFOOPBMK, KMJKKNFDFMM);
		}
	}

	public void HealSoldier(float NEJNIEEHCKJ, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			DoDamage(new CJLNCMMNPBM
			{
				LPGMLOCLBGP = Vector3.zero,
				EPDELOGPNAC = 0f - NEJNIEEHCKJ,
				FJLBLLLEELD = MANAGOLPMLH.Heal,
				JMMJHCOKCGG = null,
				HNFNINFCBEJ = null
			});
			if (GPLNJOPPKIM != null)
			{
				GPLNJOPPKIM.BlinkToWhite();
			}
		}
	}

	protected void GPCFMCEHIBC(DestroyableObject ENCEFOOPBMK, CJLNCMMNPBM KMJKKNFDFMM)
	{
		if (EKDKBACABCK != null)
		{
			EKDKBACABCK(ENCEFOOPBMK, KMJKKNFDFMM);
		}
	}

	[SpecialName]
	protected virtual bool CGAOHAGJJJI()
	{
		return false;
	}

	public virtual void JPBFBBMCFPI(float CJDCGPMIHEA, Vector3 DIAKDJLIJAN, Vector3 LPGMLOCLBGP, Weapon AEJJCMHDFBA, KMHCMCBGFFC ELOOOFODMNP, bool CAKABHIPCDF, bool NLJFIIEGHCK)
	{
		if (CAKABHIPCDF)
		{
			return;
		}
		DoDamage(new CJLNCMMNPBM
		{
			LPGMLOCLBGP = LPGMLOCLBGP,
			EPDELOGPNAC = CJDCGPMIHEA * HHOCGCLBHKB,
			FJLBLLLEELD = MANAGOLPMLH.Explosion,
			JMMJHCOKCGG = AEJJCMHDFBA,
			HNFNINFCBEJ = ELOOOFODMNP,
			OHNCLEOMHCF = DIAKDJLIJAN,
			NLJFIIEGHCK = NLJFIIEGHCK
		});
		if (GDCBPLDNHEF())
		{
			foreach (string item in HEFDIGJBKED)
			{
				Singleton<HitParticleSystem>.instance.FAJOJJGBPCC(DIAKDJLIJAN, LPGMLOCLBGP, item);
			}
		}
		if (NBNDIIENBLK)
		{
			Singleton<HitParticleSystem>.instance.KADDCDCGNJE(DIAKDJLIJAN, LPGMLOCLBGP, 2);
		}
		PlaySound(JFPMMLGBGPE);
	}

	protected virtual void JOPGOFCDHIO(float EPDELOGPNAC, byte FJLBLLLEELD, byte FFLOJLDIHGI, byte MEFOHLAIBFA, Vector3 MPHCNMDIPAI, Vector3 LPGMLOCLBGP, bool MBAGBOIGODP)
	{
		if (!PlayerController.JFGDAKMCJAM.ContainsKey(FFLOJLDIHGI))
		{
			UnityEngine.Debug.LogError("There is no player with id:" + FFLOJLDIHGI);
		}
		CJLNCMMNPBM kMJKKNFDFMM = new CJLNCMMNPBM
		{
			EPDELOGPNAC = EPDELOGPNAC,
			KLOJNPBGFIG = true,
			FJLBLLLEELD = (MANAGOLPMLH)FJLBLLLEELD,
			HNFNINFCBEJ = PlayerController.JFGDAKMCJAM[FFLOJLDIHGI],
			MEFOHLAIBFA = MEFOHLAIBFA,
			OHNCLEOMHCF = CDKBFIGEBOA.TransformPoint(MPHCNMDIPAI),
			LPGMLOCLBGP = LPGMLOCLBGP
		};
		KKOFHGIAJNE(kMJKKNFDFMM, MBAGBOIGODP);
		if (PFMKNMNBJKA)
		{
			UnityEngine.Debug.Log(string.Format("DamageEventPlayer damage: {0} to {1} new HP {2}", kMJKKNFDFMM.EPDELOGPNAC, owner, health));
		}
	}

	public virtual void CBHBBLBDFOO(GHPGNELIDBM CIOPAKLHFIL, bool MNFCGHNFFFF)
	{
		int layer = Singleton<TagsAndLayers>.instance.ALDBGABJCKN(CIOPAKLHFIL, MNFCGHNFFFF);
		base.gameObject.layer = layer;
	}

	protected void BPCGMFOPAIK(float MNAJKODCACI, float NKKIGGNCDLL, bool AEIKFAIKDGI)
	{
		GMNNGEELOFC(MNAJKODCACI);
		maxHealth = NKKIGGNCDLL;
		IHIEMNMKCEE = AEIKFAIKDGI;
	}

	public void Repair(float MNAJKODCACI, KMHCMCBGFFC ELOOOFODMNP, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			DoDamage(new CJLNCMMNPBM
			{
				EPDELOGPNAC = 0f - MNAJKODCACI,
				FJLBLLLEELD = MANAGOLPMLH.Shiver,
				JMMJHCOKCGG = null,
				HNFNINFCBEJ = ELOOOFODMNP
			});
		}
	}

	protected override void Awake()
	{
		base.Awake();
		base.gameObject.layer = TagsAndLayers.FEFDIKDCGII;
		FEHCCGEGPLH = GetComponent<PhotonView>();
		Core_BaseScript[] components = GetComponents<Core_BaseScript>();
		CDKBFIGEBOA = base.transform;
		GNICEGBOGOL = Singleton<GameCamera>.instance.camera;
		Core_BaseScript[] array = components;
		foreach (Core_BaseScript core_BaseScript in array)
		{
			if (core_BaseScript is NKMKCCDCHCL && this != core_BaseScript)
			{
				owner = core_BaseScript as KMHCMCBGFFC;
				break;
			}
		}
		if (owner != null)
		{
			return;
		}
		Core_BaseScript[] array2 = components;
		foreach (Core_BaseScript core_BaseScript2 in array2)
		{
			if (core_BaseScript2 is KMHCMCBGFFC && this != core_BaseScript2)
			{
				owner = core_BaseScript2 as KMHCMCBGFFC;
				break;
			}
		}
	}

	public void OJEEHDKMIKK(string HOLNKOFHDNK)
	{
		OKDOCOLEBLJ = HOLNKOFHDNK;
		if (GPLNJOPPKIM != null)
		{
			GPLNJOPPKIM.ELPHJLKBPGM(OKDOCOLEBLJ);
		}
	}

	protected virtual void HBDFLIJHBBN(float MNAJKODCACI, byte FJLBLLLEELD, byte AKGDPKJCILO, byte FMAOPCINBDA, byte MEFOHLAIBFA, Vector3 MDOPFNNFLFB, Vector3 LPGMLOCLBGP)
	{
		PGKPEONGOID(MNAJKODCACI, FJLBLLLEELD, AKGDPKJCILO, FMAOPCINBDA, MEFOHLAIBFA, MDOPFNNFLFB, LPGMLOCLBGP, true);
	}

	public void RefillTo(float MNAJKODCACI)
	{
		health = MNAJKODCACI;
		CCFJNDFBOAK = false;
		IHIEMNMKCEE = false;
		if (!(FEHCCGEGPLH == null))
		{
			FEHCCGEGPLH.RPC("RefillRPC", PhotonTargets.Others, health, maxHealth);
		}
	}

	public void HPLKIPHDKDK(float CJDCGPMIHEA, Vector3 LPGMLOCLBGP, Weapon AEJJCMHDFBA, KMHCMCBGFFC ELOOOFODMNP, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF && !AEJBIHBEOCP)
		{
			DoDamage(new CJLNCMMNPBM
			{
				LPGMLOCLBGP = LPGMLOCLBGP,
				EPDELOGPNAC = CJDCGPMIHEA,
				FJLBLLLEELD = MANAGOLPMLH.Poison,
				JMMJHCOKCGG = AEJJCMHDFBA,
				HNFNINFCBEJ = ELOOOFODMNP
			});
		}
	}

	private void OnEnable()
	{
		if (LMEKEPANAJI)
		{
			GPLNJOPPKIM = Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.Instantiate(Singleton<ObjectPoolDatabase>.instance.MCMHGKKPHPO) as Healthbar;
			if (GPLNJOPPKIM != null)
			{
				GPLNJOPPKIM.SetText(OKDOCOLEBLJ);
				CHHHEFFBGLC = GPLNJOPPKIM.transform;
				GPLNJOPPKIM.InitHealthbar(this, mHealthbarColor);
			}
		}
	}

	protected void HPOHNPDOLEA(DestroyableObject ENCEFOOPBMK, CJLNCMMNPBM KMJKKNFDFMM)
	{
		if (EKDKBACABCK != null)
		{
			EKDKBACABCK(ENCEFOOPBMK, KMJKKNFDFMM);
		}
	}

	[SpecialName]
	private ObscuredFloat HDPDNCMNMMO()
	{
		return _003CNBKAGGBFMBE_003Ek__BackingField;
	}

	public void NGNPMPGIAGP()
	{
		GMNNGEELOFC(maxHealth);
		CCFJNDFBOAK = true;
		IHIEMNMKCEE = true;
	}

	[PunRPC]
	protected virtual void DeathEventPlayerShoot(float MNAJKODCACI, byte FJLBLLLEELD, byte FFLOJLDIHGI, byte MEFOHLAIBFA, Vector3 MPHCNMDIPAI, Vector3 LPGMLOCLBGP)
	{
		JOPGOFCDHIO(MNAJKODCACI, FJLBLLLEELD, FFLOJLDIHGI, MEFOHLAIBFA, MPHCNMDIPAI, LPGMLOCLBGP, true);
	}

	public virtual void Refill()
	{
		RefillOffline();
		if (!(FEHCCGEGPLH == null))
		{
			FEHCCGEGPLH.RPC("RefillRPC", PhotonTargets.Others, health, maxHealth);
		}
	}

	public void HBGDHOFDMBO(FCLADBGKCIA IGKDFJKEELP)
	{
		if (GPLNJOPPKIM != null)
		{
			GPLNJOPPKIM.SetBuffs(IGKDFJKEELP);
		}
	}

	[PunRPC]
	protected virtual void DamageEventPlayer(float MNAJKODCACI, byte FJLBLLLEELD, byte FFLOJLDIHGI)
	{
		JOPGOFCDHIO(MNAJKODCACI, FJLBLLLEELD, FFLOJLDIHGI, 0, Vector3.zero, Vector3.zero, false);
	}

	[SpecialName]
	public bool HNOMJIALPMM()
	{
		return IHIEMNMKCEE;
	}

	public virtual bool DoDamage(CJLNCMMNPBM KMJKKNFDFMM)
	{
		return DoDamage(KMJKKNFDFMM, this);
	}

	protected override void Start()
	{
		base.Start();
		health = maxHealth;
	}

	public virtual void Death(DestroyableObject OJIHGNJFPFM, CJLNCMMNPBM KMJKKNFDFMM)
	{
		IHIEMNMKCEE = true;
		if (FHEMDCFGMMF != null)
		{
			FHEMDCFGMMF(OJIHGNJFPFM, KMJKKNFDFMM);
		}
	}

	protected virtual void HBKEBDEELAG(float MNAJKODCACI, byte FJLBLLLEELD, byte AKGDPKJCILO, byte FMAOPCINBDA, byte MEFOHLAIBFA, Vector3 MDOPFNNFLFB, Vector3 LPGMLOCLBGP)
	{
		PGKPEONGOID(MNAJKODCACI, FJLBLLLEELD, AKGDPKJCILO, FMAOPCINBDA, MEFOHLAIBFA, MDOPFNNFLFB, LPGMLOCLBGP, false);
	}

	public void RefillOffline()
	{
		health = maxHealth;
		CCFJNDFBOAK = false;
		IHIEMNMKCEE = false;
	}

	[SpecialName]
	protected virtual bool GDCBPLDNHEF()
	{
		return true;
	}

	protected virtual void BGOJMFGHPDA()
	{
		if (LMEKEPANAJI && GPLNJOPPKIM != null)
		{
			GPLNJOPPKIM.OPMPHHEDEAJ(healthRatio);
			Vector3 point = GNICEGBOGOL.WorldToNormalizedViewportPoint(HIPAPKDJBNL.position);
			float num = Vector3.Distance(HIPAPKDJBNL.position, GNICEGBOGOL.transform.position);
			float num2 = Mathf.Clamp(766f / num, 1194f, 123f);
			Vector3 localScale = new Vector3(num2, num2, num2);
			CHHHEFFBGLC.localScale = localScale;
			CHHHEFFBGLC.position = MKOGHDKDFIN * num2 + HealthBarManager.OGBIHEFNJGO().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
		}
		FDLBJLNOBLG = CDKBFIGEBOA.position - MMANIGLDGEH;
		MMANIGLDGEH = CDKBFIGEBOA.position;
	}

	public void SetText(string HOLNKOFHDNK)
	{
		OKDOCOLEBLJ = HOLNKOFHDNK;
		if (GPLNJOPPKIM != null)
		{
			GPLNJOPPKIM.SetText(OKDOCOLEBLJ);
		}
	}

	public void PFCIGIGKAID(float MNAJKODCACI, KMHCMCBGFFC ELOOOFODMNP, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			DoDamage(new CJLNCMMNPBM
			{
				EPDELOGPNAC = 0f - MNAJKODCACI,
				FJLBLLLEELD = MANAGOLPMLH.Shot,
				JMMJHCOKCGG = null,
				HNFNINFCBEJ = ELOOOFODMNP
			});
		}
	}

	[PunRPC]
	protected virtual void DeathEventPlayer(float MNAJKODCACI, byte FJLBLLLEELD, byte FFLOJLDIHGI, Vector3 LPGMLOCLBGP)
	{
		JOPGOFCDHIO(MNAJKODCACI, FJLBLLLEELD, FFLOJLDIHGI, 0, Vector3.zero, LPGMLOCLBGP, true);
	}

	public void DGKBLICAPON(FCLADBGKCIA IGKDFJKEELP)
	{
		if (GPLNJOPPKIM != null)
		{
			GPLNJOPPKIM.FOHPKGLJGBC(IGKDFJKEELP);
		}
	}

	public virtual void APJEBOPJPLA()
	{
		NGNPMPGIAGP();
		if (!(FEHCCGEGPLH == null))
		{
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[3];
			array[1] = health;
			array[0] = maxHealth;
			fEHCCGEGPLH.RPC("C1", PhotonTargets.All, array);
		}
	}

	public virtual void Explode(Vector3 LPGMLOCLBGP, float CJDCGPMIHEA, Weapon AEJJCMHDFBA, KMHCMCBGFFC ELOOOFODMNP, bool CAKABHIPCDF)
	{
		if (!CAKABHIPCDF)
		{
			DoDamage(new CJLNCMMNPBM
			{
				EPDELOGPNAC = CJDCGPMIHEA,
				LPGMLOCLBGP = LPGMLOCLBGP,
				FJLBLLLEELD = MANAGOLPMLH.Explosion,
				JMMJHCOKCGG = AEJJCMHDFBA,
				HNFNINFCBEJ = ELOOOFODMNP
			});
		}
	}

	protected virtual void PCCPAAKGAMA(float MNAJKODCACI, byte FJLBLLLEELD, byte AKGDPKJCILO, byte FMAOPCINBDA)
	{
		PGKPEONGOID(MNAJKODCACI, FJLBLLLEELD, AKGDPKJCILO, FMAOPCINBDA, 0, Vector3.zero, Vector3.zero, true);
	}

	private void KCNEEJOLMLG()
	{
		if (LMEKEPANAJI)
		{
			GPLNJOPPKIM = Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.Instantiate(Singleton<ObjectPoolDatabase>.instance.MCMHGKKPHPO) as Healthbar;
			if (GPLNJOPPKIM != null)
			{
				GPLNJOPPKIM.IIBOJGPPHGE(OKDOCOLEBLJ);
				CHHHEFFBGLC = GPLNJOPPKIM.transform;
				GPLNJOPPKIM.InitHealthbar(this, mHealthbarColor);
			}
		}
	}

	public virtual bool DoDamage(CJLNCMMNPBM KMJKKNFDFMM, DestroyableObject ENCEFOOPBMK)
	{
		if (!IHIEMNMKCEE && Singleton<GameController>.instance.gameIsRunning)
		{
			if (KMJKKNFDFMM.JMMJHCOKCGG != null && !KMJKKNFDFMM.JMMJHCOKCGG.MEFJOGAOKDP && KMJKKNFDFMM.HNFNINFCBEJ.fraction == fraction)
			{
				return false;
			}
			if (KMJKKNFDFMM.HNFNINFCBEJ != null && KMJKKNFDFMM.HNFNINFCBEJ.fraction == fraction)
			{
				ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.FriendDamageCoeficient).FLOATVALUE;
				KMJKKNFDFMM.EPDELOGPNAC *= fLOATVALUE;
			}
			KMJKKNFDFMM.HOLHMENGGOC = KMJKKNFDFMM.EPDELOGPNAC;
			if ((bool)CCFJNDFBOAK && !KMJKKNFDFMM.DBFIOEAHJFD)
			{
				KMJKKNFDFMM.EPDELOGPNAC = 0f;
				KMJKKNFDFMM.FJLBLLLEELD = MANAGOLPMLH.Immortal;
			}
			if ((float)LEMMBHKKJEO >= maxHealth && KMJKKNFDFMM.EPDELOGPNAC >= (float)LEMMBHKKJEO)
			{
				KMJKKNFDFMM.CCFJFAMEODO = true;
			}
			health -= KMJKKNFDFMM.EPDELOGPNAC;
			float num = health;
			HPOHNPDOLEA(ENCEFOOPBMK, KMJKKNFDFMM);
			float num2 = health - num;
			KMJKKNFDFMM.EPDELOGPNAC -= num2;
			if ((float)LEMMBHKKJEO <= 0f)
			{
				Death(ENCEFOOPBMK, KMJKKNFDFMM);
			}
			LLGOAKNKNJK(KMJKKNFDFMM);
			return true;
		}
		return false;
	}

	protected virtual void ELLMDPLIPKI(float MNAJKODCACI, byte FJLBLLLEELD, byte FFLOJLDIHGI, byte MEFOHLAIBFA, Vector3 MPHCNMDIPAI)
	{
		JOPGOFCDHIO(MNAJKODCACI, FJLBLLLEELD, FFLOJLDIHGI, MEFOHLAIBFA, MPHCNMDIPAI, Vector3.zero, false);
	}

	public void AGNENPFGFDH(string HOLNKOFHDNK)
	{
		OKDOCOLEBLJ = HOLNKOFHDNK;
		if (GPLNJOPPKIM != null)
		{
			GPLNJOPPKIM.FCLIHEAKDGP(OKDOCOLEBLJ);
		}
	}

	protected virtual void PNEDFDNLBNP()
	{
		if (LMEKEPANAJI && GPLNJOPPKIM != null)
		{
			GPLNJOPPKIM.OPMPHHEDEAJ(healthRatio);
			Vector3 point = GNICEGBOGOL.WorldToNormalizedViewportPoint(HIPAPKDJBNL.position);
			float num = Vector3.Distance(HIPAPKDJBNL.position, GNICEGBOGOL.transform.position);
			float num2 = Mathf.Clamp(1100f / num, 260f, 188f);
			Vector3 localScale = new Vector3(num2, num2, num2);
			CHHHEFFBGLC.localScale = localScale;
			CHHHEFFBGLC.position = MKOGHDKDFIN * num2 + HealthBarManager.KPCLHHDMNDD().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
		}
		FDLBJLNOBLG = CDKBFIGEBOA.position - MMANIGLDGEH;
		MMANIGLDGEH = CDKBFIGEBOA.position;
	}

	[PunRPC]
	protected void SyncNetwork(float MNAJKODCACI, float NKKIGGNCDLL, bool AEIKFAIKDGI)
	{
		health = MNAJKODCACI;
		maxHealth = NKKIGGNCDLL;
		IHIEMNMKCEE = AEIKFAIKDGI;
	}

	[PunRPC]
	protected virtual void DamageEventPlayerShoot(float MNAJKODCACI, byte FJLBLLLEELD, byte FFLOJLDIHGI, byte MEFOHLAIBFA, Vector3 MPHCNMDIPAI)
	{
		JOPGOFCDHIO(MNAJKODCACI, FJLBLLLEELD, FFLOJLDIHGI, MEFOHLAIBFA, MPHCNMDIPAI, Vector3.zero, false);
	}

	public virtual void EJNMNMKJBJL(DestroyableObject OJIHGNJFPFM, CJLNCMMNPBM KMJKKNFDFMM)
	{
		IHIEMNMKCEE = true;
		if (FHEMDCFGMMF != null)
		{
			FHEMDCFGMMF(OJIHGNJFPFM, KMJKKNFDFMM);
		}
	}

	public virtual void EHFOHNLMJOH()
	{
		if (!(FEHCCGEGPLH == null))
		{
			FEHCCGEGPLH.RPC("Directory \"{0}\" does not exists", PhotonTargets.Others, health, maxHealth, null, null, null, null, IHIEMNMKCEE);
		}
	}

	protected virtual void HIFPLHOCDCK(float MNAJKODCACI, byte FJLBLLLEELD, byte AKGDPKJCILO, byte FMAOPCINBDA, Vector3 LPGMLOCLBGP)
	{
		PGKPEONGOID(MNAJKODCACI, FJLBLLLEELD, AKGDPKJCILO, FMAOPCINBDA, 0, Vector3.zero, LPGMLOCLBGP, true);
	}

	public void SetBuffs(FCLADBGKCIA IGKDFJKEELP)
	{
		if (GPLNJOPPKIM != null)
		{
			GPLNJOPPKIM.SetBuffs(IGKDFJKEELP);
		}
	}

	[SpecialName]
	public virtual void GPKEFODONHK(GHPGNELIDBM IDEBKDPMPGM)
	{
		throw new NotImplementedException();
	}

	protected void KKOFHGIAJNE(CJLNCMMNPBM KMJKKNFDFMM, bool AEIKFAIKDGI)
	{
		health -= KMJKKNFDFMM.EPDELOGPNAC;
		if (IHIEMNMKCEE)
		{
			return;
		}
		if (KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Shot)
		{
			if (HEFCGCLCANF)
			{
				foreach (string item in HEFDIGJBKED)
				{
					Singleton<HitParticleSystem>.instance.PlayParticle(KMJKKNFDFMM.OHNCLEOMHCF, Vector3.up, item);
				}
			}
			if (NBNDIIENBLK)
			{
				Singleton<HitParticleSystem>.instance.PlayParticle(KMJKKNFDFMM.OHNCLEOMHCF, Vector3.up, 2);
			}
			PlaySound(JFPMMLGBGPE);
		}
		if (KMJKKNFDFMM.FJLBLLLEELD == MANAGOLPMLH.Heal && GPLNJOPPKIM != null)
		{
			GPLNJOPPKIM.BlinkToWhite();
		}
		if (health <= 0f)
		{
			Death(this, KMJKKNFDFMM);
			if (!AEIKFAIKDGI)
			{
				UnityEngine.Debug.LogError(string.Format("NetworkDamage damage Error new HP is {0} and {1} should NOT be DEAD, damage: {2}, damage owner {3}", health, owner, KMJKKNFDFMM.EPDELOGPNAC, KMJKKNFDFMM.HNFNINFCBEJ));
			}
		}
		else if (AEIKFAIKDGI)
		{
			Death(this, KMJKKNFDFMM);
			if (health > 0f)
			{
				UnityEngine.Debug.LogError(string.Format("NetworkDamage damage Error new HP is {0} and {1} should BE DEAD, damage: {2}, damage owner {3}", health, owner, KMJKKNFDFMM.EPDELOGPNAC, KMJKKNFDFMM.HNFNINFCBEJ));
			}
		}
		HPOHNPDOLEA(this, KMJKKNFDFMM);
	}

	protected virtual void EBAFNBLINHG(float MNAJKODCACI, byte FJLBLLLEELD, byte FFLOJLDIHGI, byte MEFOHLAIBFA, Vector3 MPHCNMDIPAI, Vector3 LPGMLOCLBGP)
	{
		JOPGOFCDHIO(MNAJKODCACI, FJLBLLLEELD, FFLOJLDIHGI, MEFOHLAIBFA, MPHCNMDIPAI, LPGMLOCLBGP, true);
	}

	[PunRPC]
	protected void SetIsImmortalRPC(bool IDEBKDPMPGM)
	{
		CCFJNDFBOAK = IDEBKDPMPGM;
	}

	[PunRPC]
	protected virtual void DeathEvent(float MNAJKODCACI, byte FJLBLLLEELD, byte AKGDPKJCILO, byte FMAOPCINBDA, Vector3 LPGMLOCLBGP)
	{
		PGKPEONGOID(MNAJKODCACI, FJLBLLLEELD, AKGDPKJCILO, FMAOPCINBDA, 0, Vector3.zero, LPGMLOCLBGP, true);
	}

	public virtual void PlaySound(HINJJOAJAOA LJAMNPJAELB)
	{
		Singleton<SoundsManager3D>.instance.Play(base.gameObject, JFPMMLGBGPE);
	}

	protected virtual void OLCKJJBAOFD(float MNAJKODCACI, byte FJLBLLLEELD, byte FFLOJLDIHGI)
	{
		JOPGOFCDHIO(MNAJKODCACI, FJLBLLLEELD, FFLOJLDIHGI, 0, Vector3.zero, Vector3.zero, true);
	}

	public virtual void Sync()
	{
		if (!(FEHCCGEGPLH == null))
		{
			FEHCCGEGPLH.RPC("SyncNetwork", PhotonTargets.Others, health, maxHealth, IHIEMNMKCEE);
		}
	}

	protected virtual void LateUpdate()
	{
		if (LMEKEPANAJI && GPLNJOPPKIM != null)
		{
			GPLNJOPPKIM.healthRatio = healthRatio;
			Vector3 point = GNICEGBOGOL.WorldToNormalizedViewportPoint(HIPAPKDJBNL.position);
			float num = Vector3.Distance(HIPAPKDJBNL.position, GNICEGBOGOL.transform.position);
			float num2 = Mathf.Clamp(5f / num, 0.75f, 1.2f);
			Vector3 localScale = new Vector3(num2, num2, num2);
			CHHHEFFBGLC.localScale = localScale;
			CHHHEFFBGLC.position = MKOGHDKDFIN * num2 + HealthBarManager.instance.KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
		}
		FDLBJLNOBLG = CDKBFIGEBOA.position - MMANIGLDGEH;
		MMANIGLDGEH = CDKBFIGEBOA.position;
	}

	public virtual void OEAGCMGINCB()
	{
		NGNPMPGIAGP();
		if (!(FEHCCGEGPLH == null))
		{
			FEHCCGEGPLH.RPC("(Landroid/app/Activity;I)V", PhotonTargets.Others, health, maxHealth, null);
		}
	}
}
