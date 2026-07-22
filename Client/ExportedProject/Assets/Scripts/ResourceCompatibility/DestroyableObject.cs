using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CodeStage.AntiCheat.ObscuredTypes;
using UnityEngine;

public class DestroyableObject : Core_BaseScript, IBFMOMDLFEP
{
	public enum BMOKOKCHMLP
	{
		disableUnit
	}

	public enum GIKHDAPJINF
	{
		Shot,
		Explosion,
		Shiver,
		Basic,
		Poison,
		Flame,
		Heal,
		Immortal,
		Suicide,
		Sword,
		PoisonArrow,
		Absorbed
	}

	public struct LDOKCBNNLCH
	{
		public GIKHDAPJINF JFACCKJNHHC;

		public float MPKEOMEFONA;

		public Vector3 LNODBAPDOJO;

		public bool HNFEBKCLFMA;

		public Weapon AEBEOCBIBFI;

		public IBFMOMDLFEP JFFNCLJBGLM;

		public bool IBHIIDHCGDP;

		public byte ADMHPIALNEH;

		public Vector3 CDFKFNHODFA;

		public bool GLEAGMIIDJK;

		public float OCLOJOFDGAA;

		public bool JAGJKEBMNKC;

		public IBFMOMDLFEP CAPOAMFMJMO;

		public float HMLKCPABODN;

		public float JHOKGPOACAI;
	}

	private sealed class NOKAJKCGDCI
	{
		public MNLPFJJCLHJ NPJLEGFFNGF;

		internal bool KNDHHDGFDIC(MNLPFJJCLHJ GPNMAPHHKAA)
		{
			return false;
		}
	}

	private sealed class KFDMEODCDIK
	{
		public Guid HCOLEEOMDJE;

		internal bool BLHCBNMGGHC(MNLPFJJCLHJ GPNMAPHHKAA)
		{
			return false;
		}
	}

	private sealed class KINPEDKGALN
	{
		public MNLPFJJCLHJ DDCIPKOBEMG;

		internal bool BHNHCBJINHJ(MNLPFJJCLHJ EOALFBIHCNB)
		{
			return false;
		}
	}

	private sealed class MBPJDBHIBAE
	{
		public MNLPFJJCLHJ NPJLEGFFNGF;

		internal bool GNMEAMNILHL(MNLPFJJCLHJ EOALFBIHCNB)
		{
			return false;
		}
	}

	private sealed class GKKLHNABOHK
	{
		public Guid AOCDKEILCLP;

		internal bool DLLLDMGOPPJ(MNLPFJJCLHJ GPNMAPHHKAA)
		{
			return false;
		}
	}

	[CompilerGenerated]
	private ObscuredFloat _003CNKAHCHFKGDO_003Ek__BackingField;

	[SerializeField]
	private ObscuredFloat mMaxHealth;

	private string GGHEAKFGAPO;

	[SerializeField]
	private bool mDestroyableByBonusBox;

	private bool DPBDMBOPNGM;

	protected bool LBFDEHEINFK;

	[CompilerGenerated]
	private static Action<DestroyableObject, LDOKCBNNLCH> OIDBKOGLAHP;

	[CompilerGenerated]
	private Action<DestroyableObject, LDOKCBNNLCH> LMAICIAFMDN;

	[CompilerGenerated]
	private Action<DestroyableObject, LDOKCBNNLCH> PIHGLAOAPDN;

	[CompilerGenerated]
	private Action<BMOKOKCHMLP, float> KLAMICNCDKB;

	public Transform ELCKDHAAJEB;

	public bool NPHBCDIMINF;

	public Vector3 BGIOBKDLNLD;

	public bool LBMIOFEGECG;

	public bool IFBCJNAFOMI;

	public bool PIDMKHKLOEN;

	public bool DFGALPCAKGA;

	public bool ODJCHENCJOM;

	public float GODCPFOGPMA;

	public List<string> KPJCPMKFBAI;

	protected PhotonView IBBJLFJLAFA;

	private ObscuredBool JGBECNPJIEI;

	private ObscuredFloat PKFONNJGBOA;

	private ObscuredBool OJABDEJABGI;

	public Healthbar.MOAJNNCOLPB HMCBHCJHFFH;

	private bool GHHBEABKOOC;

	[NonSerialized]
	public bool NOPOFJAABPP;

	[CompilerGenerated]
	private IBFMOMDLFEP _003CMBNKCDNNBNK_003Ek__BackingField;

	[SerializeField]
	protected Color mHealthbarColor;

	protected Transform DDOHNDOCKKI;

	protected Transform AIDMKNEOPHG;

	public Healthbar OLOMLIKGODG;

	protected Vector3 HBEDNGALFHD;

	private Vector3 HFHHAEJFPKO;

	protected Camera FALBFANKDOF;

	private byte JGDJPGOBHEG;

	private LDOKCBNNLCH DHNPDKMFNIC;

	public ICHBAJOHDJC NPBCLPGBMEP;

	public ICHBAJOHDJC EAJOBFBLHMM;

	private static readonly List<MNLPFJJCLHJ> DGNDJDHEIKN;

	private readonly List<MNLPFJJCLHJ> KMHJMMGFBOI;

	private const byte HOFENEDJBGO = 84;

	private const byte LOHKOHLAHNI = 85;

	private static bool EJNPGOEBBKJ;

	private ObscuredFloat GEHDLLFOBMC
	{
		[CompilerGenerated]
		get
		{
			return default(ObscuredFloat);
		}
		[CompilerGenerated]
		set
		{
		}
	}

	public virtual bool destroyableByBonusBox
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool wasDamaged
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public float maxHealth
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public virtual DestroyableObject mainDestroyableObject => null;

	public virtual HPHFGNJPDKN fraction
	{
		get
		{
			return default(HPHFGNJPDKN);
		}
		set
		{
		}
	}

	public virtual IBFMOMDLFEP owner
	{
		[CompilerGenerated]
		get
		{
			return null;
		}
		[CompilerGenerated]
		set
		{
		}
	}

	protected virtual bool NAGIOJGKGJP => false;

	public Vector3 velocity => default(Vector3);

	public virtual float healthRatio
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public virtual float health
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public Color healthbarColor
	{
		get
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			return default(Color);
		}
		set
		{
		}
	}

	public bool isDead => false;

	private bool OPOHFNODGPH => false;

	public bool isImmortal
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool isGhost
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public float ignoreChance
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public virtual bool showHitParticles
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public static event Action<DestroyableObject, LDOKCBNNLCH> OnDamageGlobal
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action<DestroyableObject, LDOKCBNNLCH> OnDamage
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action<DestroyableObject, LDOKCBNNLCH> OnDeath
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action<BMOKOKCHMLP, float> OnDamageEffect
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	protected override void Awake()
	{
	}

	protected override void Start()
	{
	}

	public void Poison(float PIMDLOBOGIM, Vector3 LNODBAPDOJO, Weapon NFOFKPHABKH, IBFMOMDLFEP MDBPKLFPJPP, bool KMKNPEHKLMI)
	{
	}

	public void Heal(float LJJOKBBFIND, bool KMKNPEHKLMI)
	{
	}

	public void HealSoldier(float LJJOKBBFIND, bool KMKNPEHKLMI)
	{
	}

	public void Shiver(float PIMDLOBOGIM, float OELPBBCAHFJ, Vector3 LNODBAPDOJO, Weapon NFOFKPHABKH, IBFMOMDLFEP MDBPKLFPJPP, bool KMKNPEHKLMI, IBFMOMDLFEP AHGHFOGNAMJ = null)
	{
	}

	public void Suicide(float PIMDLOBOGIM, Vector3 LNODBAPDOJO, Weapon NFOFKPHABKH, IBFMOMDLFEP MDBPKLFPJPP, bool KMKNPEHKLMI)
	{
	}

	public void Repair(float MLPOAAMKAFI, IBFMOMDLFEP MDBPKLFPJPP, bool KMKNPEHKLMI)
	{
	}

	public virtual void PlaySound(ICHBAJOHDJC AELLBJOFHCB)
	{
	}

	public virtual void Shoot(float PIMDLOBOGIM, Vector3 FCHKNKPBKNA, Vector3 LNODBAPDOJO, Weapon NFOFKPHABKH, IBFMOMDLFEP MDBPKLFPJPP, bool KMKNPEHKLMI, bool GLEAGMIIDJK, float HMLKCPABODN = 0f, float JHOKGPOACAI = 0f)
	{
	}

	public virtual void PoisonArrowAttack(float PIMDLOBOGIM, Vector3 FCHKNKPBKNA, Vector3 LNODBAPDOJO, Weapon NFOFKPHABKH, IBFMOMDLFEP MDBPKLFPJPP, bool KMKNPEHKLMI, bool GLEAGMIIDJK)
	{
	}

	public virtual void SwordAttack(float PIMDLOBOGIM, Vector3 FCHKNKPBKNA, Vector3 LNODBAPDOJO, Weapon NFOFKPHABKH, IBFMOMDLFEP MDBPKLFPJPP, bool KMKNPEHKLMI)
	{
	}

	public virtual void Explode(Vector3 LNODBAPDOJO, float PIMDLOBOGIM, float OELPBBCAHFJ, Weapon NFOFKPHABKH, IBFMOMDLFEP MDBPKLFPJPP, bool KMKNPEHKLMI, IBFMOMDLFEP AHGHFOGNAMJ = null)
	{
	}

	public virtual void Burn(float PIMDLOBOGIM, Vector3 FCHKNKPBKNA, Vector3 LNODBAPDOJO, Weapon NFOFKPHABKH, IBFMOMDLFEP MDBPKLFPJPP, bool KMKNPEHKLMI, bool GLEAGMIIDJK)
	{
	}

	public virtual bool DoDamage(LDOKCBNNLCH INADGPICPMO)
	{
		return false;
	}

	public virtual bool DoDamage(LDOKCBNNLCH INADGPICPMO, DestroyableObject KIHIFIBOOIM)
	{
		return false;
	}

	public virtual void Death(DestroyableObject IILHBBEDLPP, LDOKCBNNLCH INADGPICPMO)
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	protected void OOCOHGDOHCL(LDOKCBNNLCH INADGPICPMO, bool GFECJHAPOBA)
	{
	}

	private void FFFHOJKMPBA(Vector3 CDFKFNHODFA)
	{
	}

	protected void CJANCLLKCJL(DestroyableObject KIHIFIBOOIM, LDOKCBNNLCH INADGPICPMO)
	{
	}

	public virtual void ApplyDisableSpecialAbility(float GHPPCNBBHDK)
	{
	}

	private void IIPIKBJJMLC(BMOKOKCHMLP DDJFNKANCKJ, float GHPPCNBBHDK)
	{
	}

	[PunRPC]
	protected void ApplyEffectRpc(BMOKOKCHMLP DDJFNKANCKJ, float GHPPCNBBHDK)
	{
	}

	public void RefillOffline()
	{
	}

	public void Disable()
	{
	}

	public virtual void Refill()
	{
	}

	public void RefillTo(float MLPOAAMKAFI)
	{
	}

	[PunRPC]
	protected virtual void RefillRPC(float MLPOAAMKAFI, float BIMKNONLOJD)
	{
	}

	public void SetHealthBar(Healthbar ILPGPLEDCJP)
	{
	}

	[PunRPC]
	protected void SetIsImmortalRPC(bool HHDCBKDKICG)
	{
	}

	[PunRPC]
	protected void SetIsGhostRPC(bool HHDCBKDKICG)
	{
	}

	[PunRPC]
	protected void SetIgnoreChanceRPC(float GHGAKEIAMEJ)
	{
	}

	[PunRPC]
	protected virtual void SetShowHitParticlesRPC(bool HHDCBKDKICG)
	{
	}

	protected void MFJAMCFLKPD(LDOKCBNNLCH INADGPICPMO)
	{
	}

	[PunRPC]
	protected virtual void DamageEvent(float MLPOAAMKAFI, byte JFACCKJNHHC, byte EMLGLDIPPDF, int NCNDABEOPDL)
	{
	}

	[PunRPC]
	protected virtual void DamageEventShoot(float MLPOAAMKAFI, byte JFACCKJNHHC, byte EMLGLDIPPDF, int NCNDABEOPDL, byte ADMHPIALNEH, Vector3 OIMMJIGPNDK)
	{
	}

	[PunRPC]
	protected virtual void DeathEvent(float MLPOAAMKAFI, byte JFACCKJNHHC, byte EMLGLDIPPDF, int NCNDABEOPDL, Vector3 LNODBAPDOJO)
	{
	}

	[PunRPC]
	protected virtual void DeathEventShoot(float MLPOAAMKAFI, byte JFACCKJNHHC, byte EMLGLDIPPDF, int NCNDABEOPDL, byte ADMHPIALNEH, Vector3 OIMMJIGPNDK, Vector3 LNODBAPDOJO)
	{
	}

	protected void EOOJEAPAIAE(float MPKEOMEFONA, byte JFACCKJNHHC, byte EMLGLDIPPDF, int NCNDABEOPDL, byte ADMHPIALNEH, Vector3 OIMMJIGPNDK, Vector3 LNODBAPDOJO, bool CJHIEFIMJGP)
	{
	}

	[PunRPC]
	protected virtual void DamageEventPlayer(float MLPOAAMKAFI, byte JFACCKJNHHC, byte MAFMFHFAEFG)
	{
	}

	[PunRPC]
	protected virtual void DamageEventPlayerShoot(float MLPOAAMKAFI, byte JFACCKJNHHC, byte MAFMFHFAEFG, byte ADMHPIALNEH, Vector3 MPHCJEIMBEB)
	{
	}

	[PunRPC]
	protected virtual void DeathEventPlayer(float MLPOAAMKAFI, byte JFACCKJNHHC, byte MAFMFHFAEFG, Vector3 LNODBAPDOJO)
	{
	}

	[PunRPC]
	protected virtual void DeathEventPlayerShoot(float MLPOAAMKAFI, byte JFACCKJNHHC, byte MAFMFHFAEFG, byte ADMHPIALNEH, Vector3 MPHCJEIMBEB, Vector3 LNODBAPDOJO)
	{
	}

	protected virtual void LNNPGPNKMMM(float MPKEOMEFONA, byte JFACCKJNHHC, byte MAFMFHFAEFG, byte ADMHPIALNEH, Vector3 MPHCJEIMBEB, Vector3 LNODBAPDOJO, bool CJHIEFIMJGP)
	{
	}

	protected virtual void LateUpdate()
	{
	}

	public virtual void Sync()
	{
	}

	[PunRPC]
	protected void SyncNetwork(float MLPOAAMKAFI, float BIMKNONLOJD, bool GFECJHAPOBA)
	{
	}

	public virtual void ChangeLayer(HPHFGNJPDKN LBHJBBKENEO, bool FDLHOKMOIFJ)
	{
	}

	public void SetText(string BALEOFOKIOC)
	{
	}

	public void SetBuffs(FEPKHDHDKII MAAKDJCLJJJ)
	{
	}

	public static void AddGlobalDamageModifier(MNLPFJJCLHJ DDCIPKOBEMG, bool FGDLKJECINB = false)
	{
	}

	private static void MDKCOMENADM(string PJKHEJAFDBO, Guid LJNLNJENHEN, object[] GBEHIIIODNJ, bool FGDLKJECINB)
	{
	}

	public static void RemoveGlobalDamageModifier(MNLPFJJCLHJ DDCIPKOBEMG)
	{
	}

	private static void DBJPFLJIKID(Guid HCOLEEOMDJE)
	{
	}

	public void AddDamageModifier(MNLPFJJCLHJ DDCIPKOBEMG, bool FGDLKJECINB = false)
	{
	}

	[PunRPC]
	protected void AddDamageModifierRPC(string PJKHEJAFDBO, byte[] LJNLNJENHEN, object[] GBEHIIIODNJ, bool FGDLKJECINB)
	{
	}

	public void RemoveDamageModifier(MNLPFJJCLHJ DDCIPKOBEMG)
	{
	}

	[PunRPC]
	protected void RemoveDamageModifierRPC(byte[] HCOLEEOMDJE)
	{
	}

	public void ClearAllDamageModifiersLocal()
	{
	}

	private void BKBMBCHDCNH(ref LDOKCBNNLCH INADGPICPMO)
	{
	}

	private static MNLPFJJCLHJ LEHJEGJFBGH(string PJKHEJAFDBO, Guid LJNLNJENHEN, object[] GBEHIIIODNJ)
	{
		return null;
	}

	private static void NJCFBALKFKH(byte NGKPBCAMGDD, object CCHDMDJLIOL, int EPMJKODHADP)
	{
	}
}
