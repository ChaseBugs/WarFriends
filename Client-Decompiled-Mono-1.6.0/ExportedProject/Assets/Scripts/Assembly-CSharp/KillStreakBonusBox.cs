using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

[RequireComponent(typeof(DestroyableObject))]
public class KillStreakBonusBox : PoolableObject, NKMKCCDCHCL, KMHCMCBGFFC
{
	private DestroyableObject FFOAABONJNO;

	public KillStreakBonus NNIHCIHLJDK;

	public Transform KNAAHEBEOJK;

	private Transform NGCDDPCAGJB;

	private bool GOKBOHHNKDJ;

	public Material HGGBOBNDEMO;

	public Material DJOIMIIJKBK;

	public int HCEKKAMPANP;

	public AudioClip OEJPCBICMGD;

	public AudioClip MLPHPPMFNFD;

	public AudioClip PIDHDHGJOHJ;

	private SkillShotControllerBonusBox ANGGPBHLGPM;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> FJHBCIAKBPF;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action<NKMKCCDCHCL, GHPGNELIDBM, GHPGNELIDBM> FIDJIJFEEIH;

	public GHPGNELIDBM fraction
	{
		get
		{
			return GHPGNELIDBM.None;
		}
		set
		{
		}
	}

	public KMHCMCBGFFC owner { get; set; }

	public int power { get; set; }

	public bool isAlive { get; set; }

	public bool onGround
	{
		get
		{
			return GOKBOHHNKDJ;
		}
		set
		{
			GOKBOHHNKDJ = value;
		}
	}

	public event Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> Killed
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

	public event Action<NKMKCCDCHCL, GHPGNELIDBM, GHPGNELIDBM> FractionChanged
	{
		add
		{
			Action<NKMKCCDCHCL, GHPGNELIDBM, GHPGNELIDBM> action = FIDJIJFEEIH;
			Action<NKMKCCDCHCL, GHPGNELIDBM, GHPGNELIDBM> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref FIDJIJFEEIH, (Action<NKMKCCDCHCL, GHPGNELIDBM, GHPGNELIDBM>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<NKMKCCDCHCL, GHPGNELIDBM, GHPGNELIDBM> action = FIDJIJFEEIH;
			Action<NKMKCCDCHCL, GHPGNELIDBM, GHPGNELIDBM> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref FIDJIJFEEIH, (Action<NKMKCCDCHCL, GHPGNELIDBM, GHPGNELIDBM>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		FFOAABONJNO.maxHealth = 1f;
		FFOAABONJNO.RefillOffline();
		onGround = false;
	}

	protected void BPNLIABHCPN()
	{
		KNAAHEBEOJK.position = NGCDDPCAGJB.position + Vector3.up * 1085f;
	}

	[SpecialName]
	public void HHCEBMPOJHB(int IDEBKDPMPGM)
	{
		_003CCDNMFDJOELD_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void FHEMDCFGMMF(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		AudioSource audioSource = Singleton<SoundsManager3D>.instance.Play(NGCDDPCAGJB.position, OEJPCBICMGD);
		if (!OHJPPHFEAFI.KLOJNPBGFIG)
		{
			if (OHJPPHFEAFI.HNFNINFCBEJ != null)
			{
				PlayerController playerOld = PlayerController.GetPlayerOld(OHJPPHFEAFI.HNFNINFCBEJ.fraction);
				Singleton<KillStreakManager>.instance.ActivateBonus(this, playerOld);
			}
			else
			{
				PlayerController playerOld2 = PlayerController.GetPlayerOld(owner.fraction);
				Singleton<KillStreakManager>.instance.ActivateBonus(this, playerOld2);
			}
		}
		isAlive = false;
		if (FJHBCIAKBPF != null)
		{
			FJHBCIAKBPF(this, OHJPPHFEAFI);
		}
		Singleton<HitParticleSystem>.instance.PlayParticle(base.transform.position, Vector3.up, "groundBoxHit");
		DestroyPooled(0.1f);
	}

	private void ECMOKHDCIDO(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		AudioSource audioSource = Singleton<SoundsManager3D>.instance.DMFGNABOGEB(NGCDDPCAGJB.position, OEJPCBICMGD, 898f);
		if (!OHJPPHFEAFI.KLOJNPBGFIG)
		{
			if (OHJPPHFEAFI.HNFNINFCBEJ != null)
			{
				PlayerController playerOld = PlayerController.GetPlayerOld(OHJPPHFEAFI.HNFNINFCBEJ.fraction);
				Singleton<KillStreakManager>.instance.NFCPEKJEDCG(this, playerOld);
			}
			else
			{
				PlayerController kHLGDCHJJPB = PlayerController.CCPHMCAIJNA(JOGPBECMDGF().fraction);
				Singleton<KillStreakManager>.instance.LKJMDKHFMDL(this, kHLGDCHJJPB);
			}
		}
		isAlive = true;
		if (FJHBCIAKBPF != null)
		{
			FJHBCIAKBPF(this, OHJPPHFEAFI);
		}
		Singleton<HitParticleSystem>.instance.DOBEGFNGKIP(base.transform.position, Vector3.up, "ID_CONFIRM_ERROR");
		AEHFNIMENDJ(1583f);
	}

	[SpecialName]
	public KMHCMCBGFFC FHJGJCNCGBD()
	{
		return _003COPCFPJLGOLK_003Ek__BackingField;
	}

	[SpecialName]
	public bool EJCCAJJKAFB()
	{
		return GOKBOHHNKDJ;
	}

	[SpecialName]
	public void IGFBBFCELND(Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> IDEBKDPMPGM)
	{
		Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> action = FJHBCIAKBPF;
		Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref FJHBCIAKBPF, (Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	protected virtual void IABJJOPLKFF()
	{
		base.Awake();
		FFOAABONJNO = GetComponent<DestroyableObject>();
		ANGGPBHLGPM = GetComponent<SkillShotControllerBonusBox>();
		FFOAABONJNO.OnDeath += BKEFMGLNOIG;
		NGCDDPCAGJB = base.transform;
	}

	[SpecialName]
	public void JOKDGFCJAMF(Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> IDEBKDPMPGM)
	{
		Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> action = FJHBCIAKBPF;
		Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref FJHBCIAKBPF, (Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	protected void Update()
	{
		KNAAHEBEOJK.position = NGCDDPCAGJB.position + Vector3.up * 0.7f;
	}

	protected virtual void HEJKGFPPIDC()
	{
		base.Awake();
		FFOAABONJNO = GetComponent<DestroyableObject>();
		ANGGPBHLGPM = GetComponent<SkillShotControllerBonusBox>();
		FFOAABONJNO.OnDeath += BKEFMGLNOIG;
		NGCDDPCAGJB = base.transform;
	}

	[SpecialName]
	public GHPGNELIDBM OCABOHDOPGP()
	{
		return GHPGNELIDBM.None;
	}

	private void OnCollisionEnter(Collision AKLHJIBDAFA)
	{
		if (!onGround && TagsAndLayers.IsDestroyableObject(AKLHJIBDAFA.collider.gameObject))
		{
			DestroyableObject component = AKLHJIBDAFA.collider.gameObject.GetComponent<DestroyableObject>();
			if (component != null && component.destroyableByBonusBox)
			{
				component.DoDamage(new DestroyableObject.CJLNCMMNPBM
				{
					EPDELOGPNAC = float.MaxValue,
					LPGMLOCLBGP = Vector3.zero,
					KLOJNPBGFIG = false,
					HNFNINFCBEJ = null,
					FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Basic,
					DBFIOEAHJFD = true
				});
			}
		}
		if (TagsAndLayers.IsStatic(AKLHJIBDAFA.collider.gameObject))
		{
			isAlive = true;
			ContactPoint contactPoint = AKLHJIBDAFA.contacts[0];
			Singleton<HitParticleSystem>.instance.PlayParticle(contactPoint.point, contactPoint.normal, "groundBoxHit");
			onGround = true;
			Singleton<SoundsManager3D>.instance.Play(NGCDDPCAGJB.position, PIDHDHGJOHJ);
		}
	}

	[SpecialName]
	public void PAOLKAIEJHP(bool IDEBKDPMPGM)
	{
		_003CFCIBDHGKAGG_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void BKEFMGLNOIG(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		AudioSource audioSource = Singleton<SoundsManager3D>.instance.CEDACKOHHNA(NGCDDPCAGJB.position, OEJPCBICMGD, 705f);
		if (!OHJPPHFEAFI.KLOJNPBGFIG)
		{
			if (OHJPPHFEAFI.HNFNINFCBEJ != null)
			{
				PlayerController kHLGDCHJJPB = PlayerController.CCPHMCAIJNA(OHJPPHFEAFI.HNFNINFCBEJ.fraction);
				Singleton<KillStreakManager>.instance.LKJMDKHFMDL(this, kHLGDCHJJPB);
			}
			else
			{
				PlayerController kHLGDCHJJPB2 = PlayerController.HEAGPACBLJA(FHJGJCNCGBD().fraction);
				Singleton<KillStreakManager>.instance.NFCPEKJEDCG(this, kHLGDCHJJPB2);
			}
		}
		PAOLKAIEJHP(true);
		if (FJHBCIAKBPF != null)
		{
			FJHBCIAKBPF(this, OHJPPHFEAFI);
		}
		Singleton<HitParticleSystem>.instance.KNANLLHOLFB(base.transform.position, Vector3.up, "WALLET - spent scraps {0}");
		AEHFNIMENDJ(1902f, true);
	}

	[SpecialName]
	public GHPGNELIDBM ECBOMFKCGNN()
	{
		return GHPGNELIDBM.Enemies;
	}

	[SpecialName]
	public void KHIJPNFEIIH(Action<NKMKCCDCHCL, GHPGNELIDBM, GHPGNELIDBM> IDEBKDPMPGM)
	{
		Action<NKMKCCDCHCL, GHPGNELIDBM, GHPGNELIDBM> action = FIDJIJFEEIH;
		Action<NKMKCCDCHCL, GHPGNELIDBM, GHPGNELIDBM> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref FIDJIJFEEIH, (Action<NKMKCCDCHCL, GHPGNELIDBM, GHPGNELIDBM>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	protected override void Awake()
	{
		base.Awake();
		FFOAABONJNO = GetComponent<DestroyableObject>();
		ANGGPBHLGPM = GetComponent<SkillShotControllerBonusBox>();
		FFOAABONJNO.OnDeath += FHEMDCFGMMF;
		NGCDDPCAGJB = base.transform;
	}

	public void ActivateBonus(PlayerController KHLGDCHJJPB, bool COMJEIAJHOO)
	{
		if (!COMJEIAJHOO)
		{
			return;
		}
		if (owner.fraction != KHLGDCHJJPB.fraction && Singleton<KillStreakManager>.instance.CanBoobyTrap(owner.fraction))
		{
			NNIHCIHLJDK = Singleton<KillStreakManager>.instance.OPJPAOGKIML;
			Singleton<KillStreakManager>.instance.BoobyTrapSet(false, owner.fraction);
		}
		if (owner.fraction != KHLGDCHJJPB.fraction)
		{
			ANGGPBHLGPM.Play(KHLGDCHJJPB.fraction);
		}
		NNIHCIHLJDK.ActivateBonus(base.gameObject, KHLGDCHJJPB);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			Vector3 vector = HealthBarManager.instance.KPDAPFBIPAI.transform.position + new Vector3(0f, 0f, HealthBarManager.instance.KPDAPFBIPAI.nearClipPlane + 3f);
			Vector3 point = Camera.main.WorldToNormalizedViewportPoint(base.transform.position);
			point = HealthBarManager.instance.KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			point.z = vector.z;
			BonusTakeDisplayer bonusTakeDisplayer = Singleton<SkillShotManager>.instance.CHDIOFDMHEF.Instantiate(Singleton<KillStreakManager>.instance.GLEJPBCEKFA, point + Vector3.up * 10f, Quaternion.identity) as BonusTakeDisplayer;
			if (bonusTakeDisplayer != null)
			{
				bonusTakeDisplayer.Play(NNIHCIHLJDK);
			}
			if (KHLGDCHJJPB.isCurrentPlayer)
			{
				Singleton<KillStreakManager>.instance.CPCHNGODJNF++;
			}
		}
	}

	[SpecialName]
	public void ELPOPCJABJH(Action<NKMKCCDCHCL, GHPGNELIDBM, GHPGNELIDBM> IDEBKDPMPGM)
	{
		Action<NKMKCCDCHCL, GHPGNELIDBM, GHPGNELIDBM> action = FIDJIJFEEIH;
		Action<NKMKCCDCHCL, GHPGNELIDBM, GHPGNELIDBM> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref FIDJIJFEEIH, (Action<NKMKCCDCHCL, GHPGNELIDBM, GHPGNELIDBM>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public bool KJEGGEIFHEC()
	{
		return GOKBOHHNKDJ;
	}

	[SpecialName]
	public int JMOLFHNHPOK()
	{
		return _003CCDNMFDJOELD_003Ek__BackingField;
	}

	[SpecialName]
	public bool OPFECNFMINK()
	{
		return _003CFCIBDHGKAGG_003Ek__BackingField;
	}

	[SpecialName]
	public bool NENKEBDPNEB()
	{
		return _003CFCIBDHGKAGG_003Ek__BackingField;
	}

	[SpecialName]
	public void CLOMDAGMHHL(Action<NKMKCCDCHCL, GHPGNELIDBM, GHPGNELIDBM> IDEBKDPMPGM)
	{
		Action<NKMKCCDCHCL, GHPGNELIDBM, GHPGNELIDBM> action = FIDJIJFEEIH;
		Action<NKMKCCDCHCL, GHPGNELIDBM, GHPGNELIDBM> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref FIDJIJFEEIH, (Action<NKMKCCDCHCL, GHPGNELIDBM, GHPGNELIDBM>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void JALJGBPHFMB(Action<NKMKCCDCHCL, GHPGNELIDBM, GHPGNELIDBM> IDEBKDPMPGM)
	{
		Action<NKMKCCDCHCL, GHPGNELIDBM, GHPGNELIDBM> action = FIDJIJFEEIH;
		Action<NKMKCCDCHCL, GHPGNELIDBM, GHPGNELIDBM> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref FIDJIJFEEIH, (Action<NKMKCCDCHCL, GHPGNELIDBM, GHPGNELIDBM>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public KMHCMCBGFFC JOGPBECMDGF()
	{
		return _003COPCFPJLGOLK_003Ek__BackingField;
	}
}
