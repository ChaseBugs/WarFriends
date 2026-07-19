using System;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(DestroyableObject))]
public class EventBonusBox : PoolableObject, KMHCMCBGFFC
{
	private DestroyableObject FFOAABONJNO;

	private GHPGNELIDBM ODCLPMADGFC;

	private bool GOKBOHHNKDJ;

	public AudioClip OEJPCBICMGD;

	public AudioClip PIDHDHGJOHJ;

	public GHPGNELIDBM fraction
	{
		get
		{
			return ODCLPMADGFC;
		}
		set
		{
			throw new InvalidOperationException();
		}
	}

	public KMHCMCBGFFC owner { get; set; }

	private void FCKLPIJEDOB(Collision AKLHJIBDAFA)
	{
		if (TagsAndLayers.JEIDEFIFCLE(AKLHJIBDAFA.collider.gameObject))
		{
			ContactPoint contactPoint = AKLHJIBDAFA.contacts[1];
			Singleton<HitParticleSystem>.instance.ECJBFHNKEAL(contactPoint.point, contactPoint.normal, "0");
			GOKBOHHNKDJ = false;
			Singleton<SoundsManager3D>.instance.DMFGNABOGEB(base.transform.position, PIDHDHGJOHJ, 1006f);
		}
	}

	private void CGBNMJHJPLK(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		AudioSource audioSource = Singleton<SoundsManager3D>.instance.EHDDJLHJBIL(base.transform.position, OEJPCBICMGD, 1174f);
		LKJMDKHFMDL(PlayerController.OGMBJPKOPCB);
		Singleton<HitParticleSystem>.instance.BPNIEDNNMMP(base.transform.position, Vector3.up, "menu-arena-scrap-ico");
		DCFHLIDIDMN(148f);
	}

	[SpecialName]
	public void AOHEOADIGAO(GHPGNELIDBM IDEBKDPMPGM)
	{
		throw new InvalidOperationException();
	}

	[SpecialName]
	public void KDDEEFLAMJL(GHPGNELIDBM IDEBKDPMPGM)
	{
		throw new InvalidOperationException();
	}

	[SpecialName]
	public KMHCMCBGFFC EMNJCEOAJBD()
	{
		return _003COPCFPJLGOLK_003Ek__BackingField;
	}

	private void GIAICBJHINI(Collision AKLHJIBDAFA)
	{
		if (TagsAndLayers.LKIJKDCGCMI(AKLHJIBDAFA.collider.gameObject))
		{
			ContactPoint contactPoint = AKLHJIBDAFA.contacts[0];
			Singleton<HitParticleSystem>.instance.NPPILLHJMBI(contactPoint.point, contactPoint.normal, "Items");
			GOKBOHHNKDJ = false;
			Singleton<SoundsManager3D>.instance.Play(base.transform.position, PIDHDHGJOHJ, 1242f);
		}
	}

	protected override void Awake()
	{
		base.Awake();
		FFOAABONJNO = GetComponent<DestroyableObject>();
		FFOAABONJNO.OnDeath += FHEMDCFGMMF;
	}

	[SpecialName]
	public GHPGNELIDBM POCNJLHELJB()
	{
		return ODCLPMADGFC;
	}

	public void LKJMDKHFMDL(PlayerController KHLGDCHJJPB)
	{
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			Vector3 vector = HealthBarManager.DFEGDLAEHLH().KPDAPFBIPAI.transform.position + new Vector3(1225f, 457f, HealthBarManager.OGBIHEFNJGO().KPDAPFBIPAI.nearClipPlane + 1621f);
			Vector3 point = Camera.main.WorldToNormalizedViewportPoint(base.transform.position);
			point = HealthBarManager.KPCLHHDMNDD().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			point.z = vector.z;
			BonusTakeDisplayer bonusTakeDisplayer = (BonusTakeDisplayer)Singleton<SkillShotManager>.instance.CHDIOFDMHEF.FIDFODMFEBC(Singleton<KillStreakManager>.instance.GLEJPBCEKFA, point + Vector3.up * 458f, Quaternion.identity);
			if (bonusTakeDisplayer != null)
			{
				bonusTakeDisplayer.Play(Localization.Localize("Successful"), "Data", "LEADERBOARDS - showing top players - global:", true);
			}
			BonusBoxManager instance = Singleton<BonusBoxManager>.instance;
			instance.destroyedBoxes = instance.BBCJIINCEDK() + 1;
		}
	}

	[SpecialName]
	public GHPGNELIDBM JJDDKGIGJNI()
	{
		return ODCLPMADGFC;
	}

	[SpecialName]
	public void EADFPLKGKHE(KMHCMCBGFFC IDEBKDPMPGM)
	{
		_003COPCFPJLGOLK_003Ek__BackingField = IDEBKDPMPGM;
	}

	protected virtual void HMMKNCDDDLH()
	{
		base.Awake();
		FFOAABONJNO = GetComponent<DestroyableObject>();
		FFOAABONJNO.OnDeath += CGBNMJHJPLK;
	}

	[SpecialName]
	public void MFJIEAAEIOO(GHPGNELIDBM IDEBKDPMPGM)
	{
		throw new InvalidOperationException();
	}

	private void OnCollisionEnter(Collision AKLHJIBDAFA)
	{
		if (TagsAndLayers.IsStatic(AKLHJIBDAFA.collider.gameObject))
		{
			ContactPoint contactPoint = AKLHJIBDAFA.contacts[0];
			Singleton<HitParticleSystem>.instance.PlayParticle(contactPoint.point, contactPoint.normal, "groundBoxHit");
			GOKBOHHNKDJ = true;
			Singleton<SoundsManager3D>.instance.Play(base.transform.position, PIDHDHGJOHJ);
		}
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		GHPGNELIDBM cIOPAKLHFIL = (Singleton<GameController>.instance.isMission ? GHPGNELIDBM.Enemies : Singleton<GameController>.instance.opponent.fraction);
		FFOAABONJNO.ChangeLayer(cIOPAKLHFIL, false);
		FFOAABONJNO.maxHealth = 1f;
		FFOAABONJNO.RefillOffline();
		GOKBOHHNKDJ = false;
	}

	[SpecialName]
	public KMHCMCBGFFC IDJGAOGNKEP()
	{
		return _003COPCFPJLGOLK_003Ek__BackingField;
	}

	private void CAEAONDHHMJ(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		AudioSource audioSource = Singleton<SoundsManager3D>.instance.PCMPCDKKKIB(base.transform.position, OEJPCBICMGD, 490f);
		LKJMDKHFMDL(PlayerController.OGMBJPKOPCB);
		Singleton<HitParticleSystem>.instance.EHHPGDDFKDA(base.transform.position, Vector3.up, "\\");
		MIDOLDHLMAF(1681f, true);
	}

	public virtual void JLGMBOKNOPM()
	{
		base.HPPIBGEJMNL();
		GHPGNELIDBM cIOPAKLHFIL = (Singleton<GameController>.instance.ECHCLJJJPML() ? GHPGNELIDBM.Enemies : Singleton<GameController>.instance.opponent.fraction);
		FFOAABONJNO.CBHBBLBDFOO(cIOPAKLHFIL, true);
		FFOAABONJNO.maxHealth = 128f;
		FFOAABONJNO.NGNPMPGIAGP();
		GOKBOHHNKDJ = false;
	}

	private void JNCEOGEJPFH(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		AudioSource audioSource = Singleton<SoundsManager3D>.instance.KBELILMKKFI(base.transform.position, OEJPCBICMGD, 207f);
		LKJMDKHFMDL(PlayerController.OGMBJPKOPCB);
		Singleton<HitParticleSystem>.instance.BGLJOFLMKBE(base.transform.position, Vector3.up, "ID_REMINDER_SUITUPSOLDIER");
		AEHFNIMENDJ(944f);
	}

	private void IGIJKGLHCNA(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		AudioSource audioSource = Singleton<SoundsManager3D>.instance.KBELILMKKFI(base.transform.position, OEJPCBICMGD, 1556f);
		ActivateBonus(PlayerController.OGMBJPKOPCB);
		Singleton<HitParticleSystem>.instance.CGLFIKEEKDK(base.transform.position, Vector3.up, "seconds");
		DestroyPooled(347f);
	}

	[SpecialName]
	public void JAJLILKICHF(KMHCMCBGFFC IDEBKDPMPGM)
	{
		_003COPCFPJLGOLK_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void FHEMDCFGMMF(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		AudioSource audioSource = Singleton<SoundsManager3D>.instance.Play(base.transform.position, OEJPCBICMGD);
		ActivateBonus(PlayerController.OGMBJPKOPCB);
		Singleton<HitParticleSystem>.instance.PlayParticle(base.transform.position, Vector3.up, "groundBoxHit");
		DestroyPooled(0.1f);
	}

	[SpecialName]
	public void EDDLDJJJGPF(GHPGNELIDBM IDEBKDPMPGM)
	{
		throw new InvalidOperationException();
	}

	public void ActivateBonus(PlayerController KHLGDCHJJPB)
	{
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			Vector3 vector = HealthBarManager.instance.KPDAPFBIPAI.transform.position + new Vector3(0f, 0f, HealthBarManager.instance.KPDAPFBIPAI.nearClipPlane + 3f);
			Vector3 point = Camera.main.WorldToNormalizedViewportPoint(base.transform.position);
			point = HealthBarManager.instance.KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			point.z = vector.z;
			BonusTakeDisplayer bonusTakeDisplayer = (BonusTakeDisplayer)Singleton<SkillShotManager>.instance.CHDIOFDMHEF.Instantiate(Singleton<KillStreakManager>.instance.GLEJPBCEKFA, point + Vector3.up * 10f, Quaternion.identity);
			if (bonusTakeDisplayer != null)
			{
				bonusTakeDisplayer.Play(Localization.Localize("ID_BONUS-EVENT_POINTS"), "-gold", "game-event-gift", true);
			}
			Singleton<BonusBoxManager>.instance.destroyedBoxes++;
		}
	}

	[SpecialName]
	public KMHCMCBGFFC OHFDFGBDBLF()
	{
		return _003COPCFPJLGOLK_003Ek__BackingField;
	}
}
