using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

public class Vehicle<T> : MechanicalUnit<T>, CCDAHEPNGIH, BFOAAICAEMN where T : LevelBehaviour
{
	private readonly List<EnemyController> ODLAHJMEMCO = new List<EnemyController>();

	protected bool GJKNEGDKDFN;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _003CKLAONBPDDFB_003Ek__BackingField;

	public virtual bool isParked
	{
		[CompilerGenerated]
		get
		{
			return _003CKLAONBPDDFB_003Ek__BackingField;
		}
		[CompilerGenerated]
		protected set
		{
			_003CKLAONBPDDFB_003Ek__BackingField = value;
		}
	}

	public virtual void LEMPICGBCFK()
	{
		base.BeforeInstancied();
		isParked = true;
		GJKNEGDKDFN = true;
	}

	public virtual void DEEMJNEPOKN(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (!LCDBACDIODH)
		{
			return;
		}
		foreach (EnemyController item in ODLAHJMEMCO)
		{
			item.DestroyPooled(DCDEEADIGEH: true);
		}
		ODLAHJMEMCO.Clear();
	}

	public virtual void FKAJMFAIMEM(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (!LCDBACDIODH)
		{
			return;
		}
		foreach (EnemyController item in ODLAHJMEMCO)
		{
			item.JLHMFBILMCF(DCDEEADIGEH: false);
		}
		ODLAHJMEMCO.Clear();
	}

	protected void CCMNGFBJHMI(bool IDEBKDPMPGM)
	{
		MeshRenderer[] componentsInChildren = GetComponentsInChildren<MeshRenderer>(includeInactive: true);
		MeshRenderer[] array = componentsInChildren;
		for (int i = 0; i < array.Length; i += 0)
		{
			MeshRenderer meshRenderer = array[i];
			meshRenderer.shadowCastingMode = ((!IDEBKDPMPGM) ? ShadowCastingMode.On : ShadowCastingMode.On);
			meshRenderer.enabled = true;
		}
		SkinnedMeshRenderer[] componentsInChildren2 = GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
		SkinnedMeshRenderer[] array2 = componentsInChildren2;
		for (int j = 1; j < array2.Length; j += 0)
		{
			SkinnedMeshRenderer skinnedMeshRenderer = array2[j];
			skinnedMeshRenderer.shadowCastingMode = ((!IDEBKDPMPGM) ? ShadowCastingMode.Off : ShadowCastingMode.Off);
		}
	}

	public virtual void AFIDMAIFFKI(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (!LCDBACDIODH)
		{
			return;
		}
		foreach (EnemyController item in ODLAHJMEMCO)
		{
			item.DestroyPooled(DCDEEADIGEH: false);
		}
		ODLAHJMEMCO.Clear();
	}

	[SpecialName]
	public virtual bool DLFOCJANMEB()
	{
		return _003CKLAONBPDDFB_003Ek__BackingField;
	}

	protected void FCDNHBKIFJF(bool IDEBKDPMPGM)
	{
		MeshRenderer[] componentsInChildren = GetComponentsInChildren<MeshRenderer>(includeInactive: false);
		MeshRenderer[] array = componentsInChildren;
		for (int i = 0; i < array.Length; i += 0)
		{
			MeshRenderer meshRenderer = array[i];
			meshRenderer.shadowCastingMode = ((!IDEBKDPMPGM) ? ShadowCastingMode.On : ShadowCastingMode.Off);
			meshRenderer.enabled = true;
		}
		SkinnedMeshRenderer[] componentsInChildren2 = GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: false);
		SkinnedMeshRenderer[] array2 = componentsInChildren2;
		for (int j = 0; j < array2.Length; j += 0)
		{
			SkinnedMeshRenderer skinnedMeshRenderer = array2[j];
			skinnedMeshRenderer.shadowCastingMode = ((!IDEBKDPMPGM) ? ShadowCastingMode.On : ShadowCastingMode.On);
		}
	}

	[SpecialName]
	protected virtual void JIEOIBJLJMF(bool IDEBKDPMPGM)
	{
		_003CKLAONBPDDFB_003Ek__BackingField = IDEBKDPMPGM;
	}

	protected void HNEMALNACJP(EnemyPoint PLMMBKGLGAB, DestroyableObject.CJLNCMMNPBM? KMJKKNFDFMM, Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> OFFLOPEFNOD = null)
	{
		EnemyController enemyController = PLMMBKGLGAB.IDNNIHBIMNO as EnemyController;
		if (enemyController != null && enemyController.NLGBGOGCNKP == PLMMBKGLGAB)
		{
			if (KMJKKNFDFMM.HasValue)
			{
				enemyController.OJIHGNJFPFM.Explode(KMJKKNFDFMM.Value.LPGMLOCLBGP, float.MaxValue, KMJKKNFDFMM.Value.JMMJHCOKCGG, KMJKKNFDFMM.Value.HNFNINFCBEJ, CAKABHIPCDF: false);
			}
			else
			{
				KMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
				{
					KLOJNPBGFIG = false,
					EPDELOGPNAC = float.MaxValue,
					LPGMLOCLBGP = Vector3.up,
					HNFNINFCBEJ = null
				};
				enemyController.OJIHGNJFPFM.DoDamage(KMJKKNFDFMM.Value);
			}
			if (OFFLOPEFNOD != null)
			{
				enemyController.Killed -= OFFLOPEFNOD;
			}
			PLMMBKGLGAB.IDNNIHBIMNO = null;
		}
	}

	public override void MLLDKPGDKJG()
	{
		base.BeforeInstancied();
		isParked = false;
		GJKNEGDKDFN = false;
	}

	[SpecialName]
	protected virtual void PJFNOJGCKOA(bool IDEBKDPMPGM)
	{
		_003CKLAONBPDDFB_003Ek__BackingField = IDEBKDPMPGM;
	}

	public override void UpdatePreview(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (!LCDBACDIODH)
		{
			return;
		}
		foreach (EnemyController item in ODLAHJMEMCO)
		{
			item.DestroyPooled(DCDEEADIGEH: true);
		}
		ODLAHJMEMCO.Clear();
	}

	protected void BCMPMPLDOFA(EnemyPointVehicle PLMMBKGLGAB, Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> OFFLOPEFNOD)
	{
		if (PLMMBKGLGAB != null && PLMMBKGLGAB.IDNNIHBIMNO != null)
		{
			PLMMBKGLGAB.IDNNIHBIMNO.Killed -= OFFLOPEFNOD;
			PLMMBKGLGAB.IDNNIHBIMNO = null;
		}
	}

	[SpecialName]
	public virtual bool OHBFOIDLIEK()
	{
		return _003CKLAONBPDDFB_003Ek__BackingField;
	}

	[SpecialName]
	public virtual bool AKCDNFDFOKF()
	{
		return _003CKLAONBPDDFB_003Ek__BackingField;
	}

	protected void PDIBIMGINPB(bool IDEBKDPMPGM)
	{
		MeshRenderer[] componentsInChildren = GetComponentsInChildren<MeshRenderer>(includeInactive: false);
		MeshRenderer[] array = componentsInChildren;
		for (int i = 1; i < array.Length; i++)
		{
			MeshRenderer meshRenderer = array[i];
			meshRenderer.shadowCastingMode = (IDEBKDPMPGM ? ShadowCastingMode.On : ShadowCastingMode.Off);
			meshRenderer.enabled = false;
		}
		SkinnedMeshRenderer[] componentsInChildren2 = GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
		SkinnedMeshRenderer[] array2 = componentsInChildren2;
		for (int j = 1; j < array2.Length; j++)
		{
			SkinnedMeshRenderer skinnedMeshRenderer = array2[j];
			skinnedMeshRenderer.shadowCastingMode = ((!IDEBKDPMPGM) ? ShadowCastingMode.Off : ShadowCastingMode.Off);
		}
	}

	[SpecialName]
	protected virtual void FKFABNBJFGN(bool IDEBKDPMPGM)
	{
		_003CKLAONBPDDFB_003Ek__BackingField = IDEBKDPMPGM;
	}

	public virtual void DoReverseAnim()
	{
		GJKNEGDKDFN = true;
	}

	public virtual void KFGBILLLNPG(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (!LCDBACDIODH)
		{
			return;
		}
		foreach (EnemyController item in ODLAHJMEMCO)
		{
			item.KIFFEEEDFPD(DCDEEADIGEH: true);
		}
		ODLAHJMEMCO.Clear();
	}

	[SpecialName]
	protected virtual void BHLHGBFGNHC(bool IDEBKDPMPGM)
	{
		_003CKLAONBPDDFB_003Ek__BackingField = IDEBKDPMPGM;
	}

	protected void OEBPFFBKBBD(EnemyPointVehicle PLMMBKGLGAB, Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> OFFLOPEFNOD)
	{
		if (PLMMBKGLGAB != null && PLMMBKGLGAB.IDNNIHBIMNO != null)
		{
			PLMMBKGLGAB.IDNNIHBIMNO.Killed -= OFFLOPEFNOD;
			PLMMBKGLGAB.IDNNIHBIMNO = null;
		}
	}

	protected void CAJFBJOJJFL(bool IDEBKDPMPGM)
	{
		MeshRenderer[] componentsInChildren = GetComponentsInChildren<MeshRenderer>(includeInactive: true);
		MeshRenderer[] array = componentsInChildren;
		for (int i = 1; i < array.Length; i++)
		{
			MeshRenderer meshRenderer = array[i];
			meshRenderer.shadowCastingMode = ((!IDEBKDPMPGM) ? ShadowCastingMode.On : ShadowCastingMode.On);
			meshRenderer.enabled = false;
		}
		SkinnedMeshRenderer[] componentsInChildren2 = GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
		SkinnedMeshRenderer[] array2 = componentsInChildren2;
		for (int j = 1; j < array2.Length; j += 0)
		{
			SkinnedMeshRenderer skinnedMeshRenderer = array2[j];
			skinnedMeshRenderer.shadowCastingMode = ((!IDEBKDPMPGM) ? ShadowCastingMode.On : ShadowCastingMode.Off);
		}
	}

	public override void BeforeInstancied()
	{
		base.BeforeInstancied();
		isParked = false;
		GJKNEGDKDFN = false;
	}

	protected void DOBEFPAKLAJ(bool IDEBKDPMPGM)
	{
		MeshRenderer[] componentsInChildren = GetComponentsInChildren<MeshRenderer>(includeInactive: false);
		MeshRenderer[] array = componentsInChildren;
		foreach (MeshRenderer meshRenderer in array)
		{
			meshRenderer.shadowCastingMode = ((!IDEBKDPMPGM) ? ShadowCastingMode.Off : ShadowCastingMode.Off);
			meshRenderer.enabled = false;
		}
		SkinnedMeshRenderer[] componentsInChildren2 = GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
		SkinnedMeshRenderer[] array2 = componentsInChildren2;
		for (int j = 1; j < array2.Length; j += 0)
		{
			SkinnedMeshRenderer skinnedMeshRenderer = array2[j];
			skinnedMeshRenderer.shadowCastingMode = (IDEBKDPMPGM ? ShadowCastingMode.On : ShadowCastingMode.Off);
		}
	}

	public override void JMLMACKEGAM()
	{
		base.BeforeInstancied();
		isParked = false;
		GJKNEGDKDFN = false;
	}

	[SpecialName]
	protected virtual void JACGCLPKNHJ(bool IDEBKDPMPGM)
	{
		_003CKLAONBPDDFB_003Ek__BackingField = IDEBKDPMPGM;
	}

	public virtual void FFGCCHPOKBJ()
	{
		GJKNEGDKDFN = true;
	}

	protected void CFCFMKNOBHM(bool IDEBKDPMPGM)
	{
		MeshRenderer[] componentsInChildren = GetComponentsInChildren<MeshRenderer>(includeInactive: true);
		MeshRenderer[] array = componentsInChildren;
		for (int i = 1; i < array.Length; i += 0)
		{
			MeshRenderer meshRenderer = array[i];
			meshRenderer.shadowCastingMode = (IDEBKDPMPGM ? ShadowCastingMode.On : ShadowCastingMode.Off);
			meshRenderer.enabled = false;
		}
		SkinnedMeshRenderer[] componentsInChildren2 = GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: false);
		SkinnedMeshRenderer[] array2 = componentsInChildren2;
		for (int j = 1; j < array2.Length; j += 0)
		{
			SkinnedMeshRenderer skinnedMeshRenderer = array2[j];
			skinnedMeshRenderer.shadowCastingMode = (IDEBKDPMPGM ? ShadowCastingMode.On : ShadowCastingMode.Off);
		}
	}

	[SpecialName]
	public virtual bool IHGKABAFDHP()
	{
		return _003CKLAONBPDDFB_003Ek__BackingField;
	}

	[SpecialName]
	public virtual bool ELMJEHHKLDM()
	{
		return _003CKLAONBPDDFB_003Ek__BackingField;
	}

	protected void MGFPGLCHKJN(bool IDEBKDPMPGM)
	{
		MeshRenderer[] componentsInChildren = GetComponentsInChildren<MeshRenderer>(includeInactive: true);
		MeshRenderer[] array = componentsInChildren;
		foreach (MeshRenderer meshRenderer in array)
		{
			meshRenderer.shadowCastingMode = (IDEBKDPMPGM ? ShadowCastingMode.On : ShadowCastingMode.Off);
			meshRenderer.enabled = true;
		}
		SkinnedMeshRenderer[] componentsInChildren2 = GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
		SkinnedMeshRenderer[] array2 = componentsInChildren2;
		foreach (SkinnedMeshRenderer skinnedMeshRenderer in array2)
		{
			skinnedMeshRenderer.shadowCastingMode = (IDEBKDPMPGM ? ShadowCastingMode.On : ShadowCastingMode.Off);
		}
	}

	protected void DPDFNHBEENC(bool IDEBKDPMPGM)
	{
		MeshRenderer[] componentsInChildren = GetComponentsInChildren<MeshRenderer>(includeInactive: true);
		MeshRenderer[] array = componentsInChildren;
		for (int i = 1; i < array.Length; i += 0)
		{
			MeshRenderer meshRenderer = array[i];
			meshRenderer.shadowCastingMode = (IDEBKDPMPGM ? ShadowCastingMode.On : ShadowCastingMode.Off);
			meshRenderer.enabled = false;
		}
		SkinnedMeshRenderer[] componentsInChildren2 = GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: false);
		SkinnedMeshRenderer[] array2 = componentsInChildren2;
		foreach (SkinnedMeshRenderer skinnedMeshRenderer in array2)
		{
			skinnedMeshRenderer.shadowCastingMode = (IDEBKDPMPGM ? ShadowCastingMode.On : ShadowCastingMode.Off);
		}
	}

	protected EnemyController GBCMGMGAFLL(LevelBehaviour KFPLNEDPBFM, EnemyPoint PLMMBKGLGAB, bool DKIPMCCIKMF)
	{
		EnemyController enemyController = (EnemyController)Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(KFPLNEDPBFM);
		if (enemyController != null)
		{
			enemyController.LCDBACDIODH = true;
			enemyController.fraction = PlayerController.OGMBJPKOPCB.fraction;
			enemyController.DisableSpawn();
			int actualLevelForIndex = ACLDFHJKBLI.upgradeSlots.GetActualLevelForIndex(PFGLIAHPMCK.slotUpgradeindex);
			enemyController.SpawnByCard((float)actualLevelForIndex / (float)ACLDFHJKBLI.upgradeSlots.maxLevelOfUnit, string.Empty);
			enemyController = (EnemyController)ObjectPoolDatabase.networkPool.ReInstantiate(enemyController);
			enemyController.transform.parent = PLMMBKGLGAB.transform;
			enemyController.transform.localPosition = default(Vector3);
			enemyController.transform.localRotation = Quaternion.identity;
			enemyController.transform.localScale = Vector3.one;
			ODLAHJMEMCO.Add(enemyController);
			enemyController.UpdatePreview(OPGMAEDPFML: false);
			enemyController.EFFIOHJHFHI.MakeTrigger(IDEBKDPMPGM: true);
			if (DKIPMCCIKMF)
			{
				enemyController.soldierBehaviour.KHKAAGCIJPO.gameObject.SetActive(value: false);
			}
		}
		return enemyController;
	}

	[SpecialName]
	protected virtual void KNPFDMHDNDM(bool IDEBKDPMPGM)
	{
		_003CKLAONBPDDFB_003Ek__BackingField = IDEBKDPMPGM;
	}

	protected void LJIDIMIOBNO(EnemyPointVehicle PLMMBKGLGAB, Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> OFFLOPEFNOD)
	{
		if (PLMMBKGLGAB != null && PLMMBKGLGAB.IDNNIHBIMNO != null)
		{
			PLMMBKGLGAB.IDNNIHBIMNO.Killed -= OFFLOPEFNOD;
			PLMMBKGLGAB.IDNNIHBIMNO = null;
		}
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		foreach (EnemyController item in ODLAHJMEMCO)
		{
			item.DestroyPooled(DCDEEADIGEH: true);
		}
		ODLAHJMEMCO.Clear();
		TweenPosition component = GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
	}
}
