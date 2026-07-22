using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MechanicalUnit<T> : AIObjectG<T> where T : LevelBehaviour
{
	[FormerlySerializedAs("vehicleVisuals")]
	[FormerlySerializedAs("FOJGCGFNEHL")]
	public VehicleVisuals CMBKCHADJPD;

	[FormerlySerializedAs("LLJBPIKPLKD")]
	public VehicleEngine KJBGMIFCKDL;

	[FormerlySerializedAs("HKAGGADECOD")]
	public UnitModelLoader MHKMEPDCFID;

	public virtual void AKLHIBFIOGE()
	{
		base.DestroyPooled();
		if ((bool)CMBKCHADJPD)
		{
			CMBKCHADJPD.DLDKNPJLKEG();
		}
		if (KJBGMIFCKDL != null)
		{
			KJBGMIFCKDL.AJLNLJCFOHL();
		}
		if (MHKMEPDCFID != null)
		{
			MHKMEPDCFID.IMFLNKIMEFA();
		}
	}

	public virtual void DKPNDBIADDG()
	{
		base.UpgradesLoaded();
		HJMGINDGDIB();
	}

	protected virtual void FPNIEOFLGLH()
	{
		if (CMBKCHADJPD == null)
		{
			return;
		}
		if (base.spawnedByCard)
		{
			if (base.currentBeh.upgradeSlots.cardVisuals != null)
			{
				CMBKCHADJPD.OHPHBOGOBFH(base.currentBeh.upgradeSlots.cardVisuals, fraction == PlayerController.OGMBJPKOPCB.fraction);
			}
		}
		else
		{
			List<TechnologyVisualDefinition> visuals = base.currentBeh.upgradeSlots.GetVisuals(PFGLIAHPMCK);
			CMBKCHADJPD.GGAMLLEHKMF(visuals, !LCDBACDIODH && fraction == PlayerController.OGMBJPKOPCB.fraction);
		}
	}

	public virtual void FKKCHKEBFGD()
	{
		base.UpgradesLoaded();
		HJMGINDGDIB();
	}

	public virtual void EGEAFDFNEAP()
	{
		base.DestroyPooled();
		if ((bool)CMBKCHADJPD)
		{
			CMBKCHADJPD.JDJGJKNKBIC();
		}
		if (KJBGMIFCKDL != null)
		{
			KJBGMIFCKDL.AJLNLJCFOHL();
		}
		if (MHKMEPDCFID != null)
		{
			MHKMEPDCFID.GCEMCPODLNM();
		}
	}

	public virtual void FLPDMLGAOMC()
	{
		base.OnInstancied();
		if (KJBGMIFCKDL != null)
		{
			KJBGMIFCKDL.StartEngine();
		}
	}

	protected virtual void GDKONLLGAAN()
	{
		if (CMBKCHADJPD == null)
		{
			return;
		}
		if (base.spawnedByCard)
		{
			if (base.currentBeh.upgradeSlots.cardVisuals != null)
			{
				CMBKCHADJPD.LLGLEGJOADL(base.currentBeh.upgradeSlots.cardVisuals, fraction == PlayerController.OGMBJPKOPCB.fraction);
			}
		}
		else
		{
			List<TechnologyVisualDefinition> visuals = base.currentBeh.upgradeSlots.GetVisuals(PFGLIAHPMCK);
			CMBKCHADJPD.SetVisuals(visuals, LCDBACDIODH || fraction == PlayerController.OGMBJPKOPCB.fraction);
		}
	}

	public virtual void GFHFHFHEFAP(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		HJMGINDGDIB();
	}

	protected virtual void LNAIFOBDNIA()
	{
		if (CMBKCHADJPD == null)
		{
			return;
		}
		if (base.spawnedByCard)
		{
			if (base.currentBeh.upgradeSlots.cardVisuals != null)
			{
				CMBKCHADJPD.PJPDPOOFAID(base.currentBeh.upgradeSlots.cardVisuals, fraction == PlayerController.OGMBJPKOPCB.fraction);
			}
		}
		else
		{
			List<TechnologyVisualDefinition> visuals = base.currentBeh.upgradeSlots.GetVisuals(PFGLIAHPMCK);
			CMBKCHADJPD.LELBKBHOLBD(visuals, LCDBACDIODH || fraction == PlayerController.OGMBJPKOPCB.fraction);
		}
	}

	public virtual void JKIDPHAGFJI()
	{
		base.DestroyPooled();
		if ((bool)CMBKCHADJPD)
		{
			CMBKCHADJPD.AENFNGOCMHN();
		}
		if (KJBGMIFCKDL != null)
		{
			KJBGMIFCKDL.LIMCFAHHLKF();
		}
		if (MHKMEPDCFID != null)
		{
			MHKMEPDCFID.IKNKDDMLDIN();
		}
	}

	public virtual void FFMJJOALPLI()
	{
		base.UpgradesLoaded();
		HJMGINDGDIB();
	}

	public override void CCNKJOAKBNG()
	{
		base.BeforeInstancied();
		if (MHKMEPDCFID != null)
		{
			MHKMEPDCFID.MALPIDBEMAK(IAJJBAJOGDM.unitModel);
		}
	}

	public virtual void NODJPIHHECL(List<AudioSource> FJGIGBNDCFE)
	{
		base.GetAudioSources(FJGIGBNDCFE);
		if (KJBGMIFCKDL != null && KJBGMIFCKDL.COLIBDBBBEI != null)
		{
			FJGIGBNDCFE.Add(KJBGMIFCKDL.COLIBDBBBEI);
		}
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		if (KJBGMIFCKDL != null)
		{
			KJBGMIFCKDL.StartEngine();
		}
	}

	public virtual void LGPAICBOFGG(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		HJMGINDGDIB();
	}

	public virtual void EEGDMEDPOCA(List<AudioSource> FJGIGBNDCFE)
	{
		base.GetAudioSources(FJGIGBNDCFE);
		if (KJBGMIFCKDL != null && KJBGMIFCKDL.COLIBDBBBEI != null)
		{
			FJGIGBNDCFE.Add(KJBGMIFCKDL.COLIBDBBBEI);
		}
	}

	protected virtual void OCJNFJCFFIG(DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		StopAllCoroutines();
		base.DPFHODDILIF(LLAOOPMGBAG);
		if (KJBGMIFCKDL != null)
		{
			KJBGMIFCKDL.CAEAONDHHMJ();
		}
	}

	protected virtual void FNHAOPPLCIM()
	{
		if (CMBKCHADJPD == null)
		{
			return;
		}
		if (base.spawnedByCard)
		{
			if (base.currentBeh.upgradeSlots.cardVisuals != null)
			{
				CMBKCHADJPD.MKKIDKFOAJL(base.currentBeh.upgradeSlots.cardVisuals, fraction == PlayerController.OGMBJPKOPCB.fraction);
			}
		}
		else
		{
			List<TechnologyVisualDefinition> visuals = base.currentBeh.upgradeSlots.GetVisuals(PFGLIAHPMCK);
			CMBKCHADJPD.ALEGBKELHFN(visuals, !LCDBACDIODH && fraction == PlayerController.OGMBJPKOPCB.fraction);
		}
	}

	public virtual void MEMHHNKDHKM(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		HJMGINDGDIB();
	}

	public virtual void PBCHJELFINO()
	{
		base.DestroyPooled();
		if ((bool)CMBKCHADJPD)
		{
			CMBKCHADJPD.GJLENDCLGCL();
		}
		if (KJBGMIFCKDL != null)
		{
			KJBGMIFCKDL.PGEDLBBPCDC();
		}
		if (MHKMEPDCFID != null)
		{
			MHKMEPDCFID.GFGEEFGMNDP();
		}
	}

	public virtual void MFJPFCEDIEK()
	{
		base.BeforeInstancied();
		if (MHKMEPDCFID != null)
		{
			MHKMEPDCFID.MMAGABBGMHD(IAJJBAJOGDM.unitModel);
		}
	}

	public virtual void EMCFMPHKILC()
	{
		base.DestroyPooled();
		if ((bool)CMBKCHADJPD)
		{
			CMBKCHADJPD.PADKBBBFNEA();
		}
		if (KJBGMIFCKDL != null)
		{
			KJBGMIFCKDL.PGEDLBBPCDC();
		}
		if (MHKMEPDCFID != null)
		{
			MHKMEPDCFID.GCEMCPODLNM();
		}
	}

	public virtual void ICBAJOMDGII(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		HJMGINDGDIB();
	}

	public virtual void HLPLIBHBNEF()
	{
		base.DestroyPooled();
		if ((bool)CMBKCHADJPD)
		{
			CMBKCHADJPD.BJPLICPLPFK();
		}
		if (KJBGMIFCKDL != null)
		{
			KJBGMIFCKDL.BJOIAFDNMNG();
		}
		if (MHKMEPDCFID != null)
		{
			MHKMEPDCFID.LDBLCPIGLOF();
		}
	}

	public virtual void NHIKALCNLHL(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		HJMGINDGDIB();
	}

	public override void GetAudioSources(List<AudioSource> FJGIGBNDCFE)
	{
		base.GetAudioSources(FJGIGBNDCFE);
		if (KJBGMIFCKDL != null && KJBGMIFCKDL.COLIBDBBBEI != null)
		{
			FJGIGBNDCFE.Add(KJBGMIFCKDL.COLIBDBBBEI);
		}
	}

	protected override void DPFHODDILIF(DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		StopAllCoroutines();
		base.DPFHODDILIF(LLAOOPMGBAG);
		if (KJBGMIFCKDL != null)
		{
			KJBGMIFCKDL.OnDeath();
		}
	}

	public virtual void EALAJCCNLAE()
	{
		base.OnInstancied();
		if (KJBGMIFCKDL != null)
		{
			KJBGMIFCKDL.OIBMFDELKKG();
		}
	}

	public virtual void CJBKICPNFCC(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		HJMGINDGDIB();
	}

	public virtual void LFINKLNPMIF(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		HJMGINDGDIB();
	}

	public virtual void DEMIHINIEEL(List<AudioSource> FJGIGBNDCFE)
	{
		base.GetAudioSources(FJGIGBNDCFE);
		if (KJBGMIFCKDL != null && KJBGMIFCKDL.COLIBDBBBEI != null)
		{
			FJGIGBNDCFE.Add(KJBGMIFCKDL.COLIBDBBBEI);
		}
	}

	public virtual void ECNIPIKJPPH()
	{
		base.UpgradesLoaded();
		HJMGINDGDIB();
	}

	public virtual void IDEKKBMPNKL()
	{
		base.DestroyPooled();
		if ((bool)CMBKCHADJPD)
		{
			CMBKCHADJPD.IJLNLDFDHHD();
		}
		if (KJBGMIFCKDL != null)
		{
			KJBGMIFCKDL.NKFPADOCDMA();
		}
		if (MHKMEPDCFID != null)
		{
			MHKMEPDCFID.IPKNPABKAJD();
		}
	}

	public virtual void KGBNCKGGPAF()
	{
		base.OnInstancied();
		if (KJBGMIFCKDL != null)
		{
			KJBGMIFCKDL.OPFAKHKIBJB();
		}
	}

	public virtual void LLKBNDHBNAL()
	{
		base.DestroyPooled();
		if ((bool)CMBKCHADJPD)
		{
			CMBKCHADJPD.LMKNDGLMKNC();
		}
		if (KJBGMIFCKDL != null)
		{
			KJBGMIFCKDL.OLLGBDFCGFL();
		}
		if (MHKMEPDCFID != null)
		{
			MHKMEPDCFID.MHKKAFGKBJK();
		}
	}

	public virtual void OEDAHBCNELG(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		HJMGINDGDIB();
	}

	protected virtual void NJBJMIFEGLO(DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		StopAllCoroutines();
		base.DPFHODDILIF(LLAOOPMGBAG);
		if (KJBGMIFCKDL != null)
		{
			KJBGMIFCKDL.MEDPNFJJLIK();
		}
	}

	public virtual void PPJJKGKEGEL()
	{
		base.DestroyPooled();
		if ((bool)CMBKCHADJPD)
		{
			CMBKCHADJPD.BJPLICPLPFK();
		}
		if (KJBGMIFCKDL != null)
		{
			KJBGMIFCKDL.BJOIAFDNMNG();
		}
		if (MHKMEPDCFID != null)
		{
			MHKMEPDCFID.LICALBFPBLL();
		}
	}

	public virtual void LEAHIMHLAOE()
	{
		base.UpgradesLoaded();
		HJMGINDGDIB();
	}

	protected virtual void HLPDMLEDDOP()
	{
		if (CMBKCHADJPD == null)
		{
			return;
		}
		if (base.spawnedByCard)
		{
			if (base.currentBeh.upgradeSlots.cardVisuals != null)
			{
				CMBKCHADJPD.OGMNMNKFMCH(base.currentBeh.upgradeSlots.cardVisuals, fraction == PlayerController.OGMBJPKOPCB.fraction);
			}
		}
		else
		{
			List<TechnologyVisualDefinition> visuals = base.currentBeh.upgradeSlots.GetVisuals(PFGLIAHPMCK);
			CMBKCHADJPD.AIOCNLJICML(visuals, LCDBACDIODH || fraction == PlayerController.OGMBJPKOPCB.fraction);
		}
	}

	protected virtual void CGHBDBJNDBM(DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		StopAllCoroutines();
		base.DPFHODDILIF(LLAOOPMGBAG);
		if (KJBGMIFCKDL != null)
		{
			KJBGMIFCKDL.EJOCIKMPEML();
		}
	}

	public virtual void OJNNEKKDFNJ()
	{
		base.UpgradesLoaded();
		HJMGINDGDIB();
	}

	public virtual void BNFPJKBFBAH()
	{
		base.OnInstancied();
		if (KJBGMIFCKDL != null)
		{
			KJBGMIFCKDL.LAMFFBAOPGC();
		}
	}

	public override void UpdatePreview(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		HJMGINDGDIB();
	}

	public override void UpgradesLoaded()
	{
		base.UpgradesLoaded();
		HJMGINDGDIB();
	}

	public virtual void DDDMDBDFGLD()
	{
		base.UpgradesLoaded();
		HJMGINDGDIB();
	}

	public virtual void PONDIDGALJM()
	{
		base.DestroyPooled();
		if ((bool)CMBKCHADJPD)
		{
			CMBKCHADJPD.POPFHBPFPLO();
		}
		if (KJBGMIFCKDL != null)
		{
			KJBGMIFCKDL.PGEDLBBPCDC();
		}
		if (MHKMEPDCFID != null)
		{
			MHKMEPDCFID.MHKKAFGKBJK();
		}
	}

	public virtual void JDHJFJBHHNL(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		HJMGINDGDIB();
	}

	public virtual void EFBIFEOHMGI()
	{
		base.OnInstancied();
		if (KJBGMIFCKDL != null)
		{
			KJBGMIFCKDL.ICAPCKPMAAD();
		}
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		if ((bool)CMBKCHADJPD)
		{
			CMBKCHADJPD.NullTextures();
		}
		if (KJBGMIFCKDL != null)
		{
			KJBGMIFCKDL.OnDestroy();
		}
		if (MHKMEPDCFID != null)
		{
			MHKMEPDCFID.Reset();
		}
	}

	public virtual void HHFFAPBGLMC()
	{
		base.UpgradesLoaded();
		HJMGINDGDIB();
	}

	public virtual void GCOEKGADKOC()
	{
		base.UpgradesLoaded();
		HJMGINDGDIB();
	}

	public virtual void MBNGGPECOHN(List<AudioSource> FJGIGBNDCFE)
	{
		base.GetAudioSources(FJGIGBNDCFE);
		if (KJBGMIFCKDL != null && KJBGMIFCKDL.COLIBDBBBEI != null)
		{
			FJGIGBNDCFE.Add(KJBGMIFCKDL.COLIBDBBBEI);
		}
	}

	public virtual void COFHBAOEBLL()
	{
		base.UpgradesLoaded();
		HJMGINDGDIB();
	}

	protected virtual void CMOJGOFDBIA()
	{
		if (CMBKCHADJPD == null)
		{
			return;
		}
		if (base.spawnedByCard)
		{
			if (base.currentBeh.upgradeSlots.cardVisuals != null)
			{
				CMBKCHADJPD.LLGLEGJOADL(base.currentBeh.upgradeSlots.cardVisuals, fraction == PlayerController.OGMBJPKOPCB.fraction);
			}
		}
		else
		{
			List<TechnologyVisualDefinition> visuals = base.currentBeh.upgradeSlots.GetVisuals(PFGLIAHPMCK);
			CMBKCHADJPD.KOOPJHKHKMC(visuals, !LCDBACDIODH && fraction == PlayerController.OGMBJPKOPCB.fraction);
		}
	}

	public virtual void BNFHNJOPJCK()
	{
		base.DestroyPooled();
		if ((bool)CMBKCHADJPD)
		{
			CMBKCHADJPD.PADKBBBFNEA();
		}
		if (KJBGMIFCKDL != null)
		{
			KJBGMIFCKDL.LIMCFAHHLKF();
		}
		if (MHKMEPDCFID != null)
		{
			MHKMEPDCFID.GEEKOICFEIB();
		}
	}

	public virtual void ECMBCEPKAFO()
	{
		base.BeforeInstancied();
		if (MHKMEPDCFID != null)
		{
			MHKMEPDCFID.DBEAHIEIHFK(IAJJBAJOGDM.unitModel);
		}
	}

	public virtual void OPJJJBIOAIK(List<AudioSource> FJGIGBNDCFE)
	{
		base.GetAudioSources(FJGIGBNDCFE);
		if (KJBGMIFCKDL != null && KJBGMIFCKDL.COLIBDBBBEI != null)
		{
			FJGIGBNDCFE.Add(KJBGMIFCKDL.COLIBDBBBEI);
		}
	}

	public virtual void JNFGOFBEPIH()
	{
		base.OnInstancied();
		if (KJBGMIFCKDL != null)
		{
			KJBGMIFCKDL.ICAPCKPMAAD();
		}
	}

	protected virtual void GLOEPMLFEOG()
	{
		if (CMBKCHADJPD == null)
		{
			return;
		}
		if (base.spawnedByCard)
		{
			if (base.currentBeh.upgradeSlots.cardVisuals != null)
			{
				CMBKCHADJPD.AIOCNLJICML(base.currentBeh.upgradeSlots.cardVisuals, fraction == PlayerController.OGMBJPKOPCB.fraction);
			}
		}
		else
		{
			List<TechnologyVisualDefinition> visuals = base.currentBeh.upgradeSlots.GetVisuals(PFGLIAHPMCK);
			CMBKCHADJPD.BDGFKFFKIGI(visuals, LCDBACDIODH || fraction == PlayerController.OGMBJPKOPCB.fraction);
		}
	}

	public virtual void KOMJDNDMJDF()
	{
		base.DestroyPooled();
		if ((bool)CMBKCHADJPD)
		{
			CMBKCHADJPD.LNCAEAGCJKM();
		}
		if (KJBGMIFCKDL != null)
		{
			KJBGMIFCKDL.PGEDLBBPCDC();
		}
		if (MHKMEPDCFID != null)
		{
			MHKMEPDCFID.DBJCDLFKDDI();
		}
	}

	protected virtual void BBFCCIGOEAH()
	{
		if (CMBKCHADJPD == null)
		{
			return;
		}
		if (base.spawnedByCard)
		{
			if (base.currentBeh.upgradeSlots.cardVisuals != null)
			{
				CMBKCHADJPD.LLGLEGJOADL(base.currentBeh.upgradeSlots.cardVisuals, fraction == PlayerController.OGMBJPKOPCB.fraction);
			}
		}
		else
		{
			List<TechnologyVisualDefinition> visuals = base.currentBeh.upgradeSlots.GetVisuals(PFGLIAHPMCK);
			CMBKCHADJPD.ACBNOAIGMAE(visuals, LCDBACDIODH || fraction == PlayerController.OGMBJPKOPCB.fraction);
		}
	}

	public virtual void OHIPFGGHGNJ(List<AudioSource> FJGIGBNDCFE)
	{
		base.GetAudioSources(FJGIGBNDCFE);
		if (KJBGMIFCKDL != null && KJBGMIFCKDL.COLIBDBBBEI != null)
		{
			FJGIGBNDCFE.Add(KJBGMIFCKDL.COLIBDBBBEI);
		}
	}

	protected virtual void IANOIAOGAHO(DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		StopAllCoroutines();
		base.DPFHODDILIF(LLAOOPMGBAG);
		if (KJBGMIFCKDL != null)
		{
			KJBGMIFCKDL.OEFOKKLIDIH();
		}
	}

	protected virtual void DJPIEOMBAAN(DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		StopAllCoroutines();
		base.DPFHODDILIF(LLAOOPMGBAG);
		if (KJBGMIFCKDL != null)
		{
			KJBGMIFCKDL.EJOCIKMPEML();
		}
	}

	protected virtual void HJMGINDGDIB()
	{
		if (CMBKCHADJPD == null)
		{
			return;
		}
		if (base.spawnedByCard)
		{
			if (base.currentBeh.upgradeSlots.cardVisuals != null)
			{
				CMBKCHADJPD.SetVisuals(base.currentBeh.upgradeSlots.cardVisuals, fraction == PlayerController.OGMBJPKOPCB.fraction);
			}
		}
		else
		{
			List<TechnologyVisualDefinition> visuals = base.currentBeh.upgradeSlots.GetVisuals(PFGLIAHPMCK);
			CMBKCHADJPD.SetVisuals(visuals, LCDBACDIODH || fraction == PlayerController.OGMBJPKOPCB.fraction);
		}
	}

	public virtual void ODLNBIFFNBE(List<AudioSource> FJGIGBNDCFE)
	{
		base.GetAudioSources(FJGIGBNDCFE);
		if (KJBGMIFCKDL != null && KJBGMIFCKDL.COLIBDBBBEI != null)
		{
			FJGIGBNDCFE.Add(KJBGMIFCKDL.COLIBDBBBEI);
		}
	}

	public virtual void PKPMCFLJHFE()
	{
		base.BeforeInstancied();
		if (MHKMEPDCFID != null)
		{
			MHKMEPDCFID.EEIHAFJGAGM(IAJJBAJOGDM.unitModel);
		}
	}

	protected virtual void JGFELFMIMDB()
	{
		if (CMBKCHADJPD == null)
		{
			return;
		}
		if (base.spawnedByCard)
		{
			if (base.currentBeh.upgradeSlots.cardVisuals != null)
			{
				CMBKCHADJPD.EKNGDJOLOAF(base.currentBeh.upgradeSlots.cardVisuals, fraction == PlayerController.OGMBJPKOPCB.fraction);
			}
		}
		else
		{
			List<TechnologyVisualDefinition> visuals = base.currentBeh.upgradeSlots.GetVisuals(PFGLIAHPMCK);
			CMBKCHADJPD.LELBKBHOLBD(visuals, LCDBACDIODH || fraction == PlayerController.OGMBJPKOPCB.fraction);
		}
	}

	public virtual void MCAAIAJONDM()
	{
		base.UpgradesLoaded();
		HJMGINDGDIB();
	}

	public virtual void IKLHLGFMHHB(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		HJMGINDGDIB();
	}

	protected virtual void KPIAHCMAKME(DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		StopAllCoroutines();
		base.DPFHODDILIF(LLAOOPMGBAG);
		if (KJBGMIFCKDL != null)
		{
			KJBGMIFCKDL.CAEAONDHHMJ();
		}
	}

	public virtual void FPPDOIPMBCN()
	{
		base.BeforeInstancied();
		if (MHKMEPDCFID != null)
		{
			MHKMEPDCFID.FOMMKOFKLMD(IAJJBAJOGDM.unitModel);
		}
	}

	public virtual void OIKIKLEJKAL(List<AudioSource> FJGIGBNDCFE)
	{
		base.GetAudioSources(FJGIGBNDCFE);
		if (KJBGMIFCKDL != null && KJBGMIFCKDL.COLIBDBBBEI != null)
		{
			FJGIGBNDCFE.Add(KJBGMIFCKDL.COLIBDBBBEI);
		}
	}

	public virtual void KALNJKOBCAN()
	{
		base.DestroyPooled();
		if ((bool)CMBKCHADJPD)
		{
			CMBKCHADJPD.GHBDGCCCIGB();
		}
		if (KJBGMIFCKDL != null)
		{
			KJBGMIFCKDL.BJOIAFDNMNG();
		}
		if (MHKMEPDCFID != null)
		{
			MHKMEPDCFID.GFGEEFGMNDP();
		}
	}

	public virtual void MKHHOAKPOMP()
	{
		base.UpgradesLoaded();
		HJMGINDGDIB();
	}

	public virtual void BPECIIGGCOB()
	{
		base.BeforeInstancied();
		if (MHKMEPDCFID != null)
		{
			MHKMEPDCFID.PLBBOKLFCPP(IAJJBAJOGDM.unitModel);
		}
	}

	public virtual void LAJKINDAEEO()
	{
		base.DestroyPooled();
		if ((bool)CMBKCHADJPD)
		{
			CMBKCHADJPD.BJPLICPLPFK();
		}
		if (KJBGMIFCKDL != null)
		{
			KJBGMIFCKDL.NKFPADOCDMA();
		}
		if (MHKMEPDCFID != null)
		{
			MHKMEPDCFID.DBJCDLFKDDI();
		}
	}

	public virtual void MAPCMDAHBGI()
	{
		base.OnInstancied();
		if (KJBGMIFCKDL != null)
		{
			KJBGMIFCKDL.StartEngine();
		}
	}

	public virtual void DNGPOAFMJDO(List<AudioSource> FJGIGBNDCFE)
	{
		base.GetAudioSources(FJGIGBNDCFE);
		if (KJBGMIFCKDL != null && KJBGMIFCKDL.COLIBDBBBEI != null)
		{
			FJGIGBNDCFE.Add(KJBGMIFCKDL.COLIBDBBBEI);
		}
	}

	public virtual void MFDHPHBJDLO(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		HJMGINDGDIB();
	}

	public virtual void MLLDKPGDKJG()
	{
		base.BeforeInstancied();
		if (MHKMEPDCFID != null)
		{
			MHKMEPDCFID.IKNLFFLIDDO(IAJJBAJOGDM.unitModel);
		}
	}

	public virtual void OLCGDMKDNDE()
	{
		base.OnInstancied();
		if (KJBGMIFCKDL != null)
		{
			KJBGMIFCKDL.LAMFFBAOPGC();
		}
	}

	protected virtual void MBAKJNBNDHK()
	{
		if (CMBKCHADJPD == null)
		{
			return;
		}
		if (base.spawnedByCard)
		{
			if (base.currentBeh.upgradeSlots.cardVisuals != null)
			{
				CMBKCHADJPD.AHKACPILJNL(base.currentBeh.upgradeSlots.cardVisuals, fraction == PlayerController.OGMBJPKOPCB.fraction);
			}
		}
		else
		{
			List<TechnologyVisualDefinition> visuals = base.currentBeh.upgradeSlots.GetVisuals(PFGLIAHPMCK);
			CMBKCHADJPD.FIPLCMPHNLP(visuals, !LCDBACDIODH && fraction == PlayerController.OGMBJPKOPCB.fraction);
		}
	}

	public virtual void JIKGCAFOLEG()
	{
		base.BeforeInstancied();
		if (MHKMEPDCFID != null)
		{
			MHKMEPDCFID.FOMMKOFKLMD(IAJJBAJOGDM.unitModel);
		}
	}

	public virtual void DMHFKEHLJIN()
	{
		base.BeforeInstancied();
		if (MHKMEPDCFID != null)
		{
			MHKMEPDCFID.JCKIJDHKOMI(IAJJBAJOGDM.unitModel);
		}
	}

	public override void BeforeInstancied()
	{
		base.BeforeInstancied();
		if (MHKMEPDCFID != null)
		{
			MHKMEPDCFID.LoadModel(IAJJBAJOGDM.unitModel);
		}
	}

	protected virtual void FICGIKHHGAP(DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		StopAllCoroutines();
		base.DPFHODDILIF(LLAOOPMGBAG);
		if (KJBGMIFCKDL != null)
		{
			KJBGMIFCKDL.OEFOKKLIDIH();
		}
	}

	public virtual void GFAAIIGMLOH(List<AudioSource> FJGIGBNDCFE)
	{
		base.GetAudioSources(FJGIGBNDCFE);
		if (KJBGMIFCKDL != null && KJBGMIFCKDL.COLIBDBBBEI != null)
		{
			FJGIGBNDCFE.Add(KJBGMIFCKDL.COLIBDBBBEI);
		}
	}

	public virtual void PDFILOJGOMM()
	{
		base.DestroyPooled();
		if ((bool)CMBKCHADJPD)
		{
			CMBKCHADJPD.POPFHBPFPLO();
		}
		if (KJBGMIFCKDL != null)
		{
			KJBGMIFCKDL.GJKNFBFEOBJ();
		}
		if (MHKMEPDCFID != null)
		{
			MHKMEPDCFID.GEEKOICFEIB();
		}
	}

	public virtual void BDMNMGGGNHJ()
	{
		base.DestroyPooled();
		if ((bool)CMBKCHADJPD)
		{
			CMBKCHADJPD.KKBKBEHEFCP();
		}
		if (KJBGMIFCKDL != null)
		{
			KJBGMIFCKDL.LIMCFAHHLKF();
		}
		if (MHKMEPDCFID != null)
		{
			MHKMEPDCFID.CPOKHODGGLN();
		}
	}

	public virtual void PEBOKCPJCBB()
	{
		base.DestroyPooled();
		if ((bool)CMBKCHADJPD)
		{
			CMBKCHADJPD.OKJOMPMOOEG();
		}
		if (KJBGMIFCKDL != null)
		{
			KJBGMIFCKDL.NKFPADOCDMA();
		}
		if (MHKMEPDCFID != null)
		{
			MHKMEPDCFID.MHKKAFGKBJK();
		}
	}

	protected virtual void GKOKHFAIDNP()
	{
		if (CMBKCHADJPD == null)
		{
			return;
		}
		if (base.spawnedByCard)
		{
			if (base.currentBeh.upgradeSlots.cardVisuals != null)
			{
				CMBKCHADJPD.MKKIDKFOAJL(base.currentBeh.upgradeSlots.cardVisuals, fraction == PlayerController.OGMBJPKOPCB.fraction);
			}
		}
		else
		{
			List<TechnologyVisualDefinition> visuals = base.currentBeh.upgradeSlots.GetVisuals(PFGLIAHPMCK);
			CMBKCHADJPD.ACBNOAIGMAE(visuals, LCDBACDIODH || fraction == PlayerController.OGMBJPKOPCB.fraction);
		}
	}

	public virtual void AJDLLFNJGKO(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		HJMGINDGDIB();
	}

	protected virtual void NFFAPMFJLFJ(DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		StopAllCoroutines();
		base.DPFHODDILIF(LLAOOPMGBAG);
		if (KJBGMIFCKDL != null)
		{
			KJBGMIFCKDL.EJOCIKMPEML();
		}
	}

	public virtual void IPAJAFFKLIB()
	{
		base.DestroyPooled();
		if ((bool)CMBKCHADJPD)
		{
			CMBKCHADJPD.PNLHGBNDNMI();
		}
		if (KJBGMIFCKDL != null)
		{
			KJBGMIFCKDL.GJKNFBFEOBJ();
		}
		if (MHKMEPDCFID != null)
		{
			MHKMEPDCFID.DBJCDLFKDDI();
		}
	}

	public virtual void EANNHAPAAHO()
	{
		base.DestroyPooled();
		if ((bool)CMBKCHADJPD)
		{
			CMBKCHADJPD.GJLENDCLGCL();
		}
		if (KJBGMIFCKDL != null)
		{
			KJBGMIFCKDL.NLPFAKKGONC();
		}
		if (MHKMEPDCFID != null)
		{
			MHKMEPDCFID.IMFLNKIMEFA();
		}
	}

	protected virtual void GMKPEJCCONK(DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		StopAllCoroutines();
		base.DPFHODDILIF(LLAOOPMGBAG);
		if (KJBGMIFCKDL != null)
		{
			KJBGMIFCKDL.NHEEABFEIHC();
		}
	}

	public virtual void PCDBEEACOKN()
	{
		base.DestroyPooled();
		if ((bool)CMBKCHADJPD)
		{
			CMBKCHADJPD.KAHKMKGNABM();
		}
		if (KJBGMIFCKDL != null)
		{
			KJBGMIFCKDL.MPCFJHLDCOP();
		}
		if (MHKMEPDCFID != null)
		{
			MHKMEPDCFID.IMFLNKIMEFA();
		}
	}

	public virtual void DJDFKKJLHIC()
	{
		base.DestroyPooled();
		if ((bool)CMBKCHADJPD)
		{
			CMBKCHADJPD.KKBKBEHEFCP();
		}
		if (KJBGMIFCKDL != null)
		{
			KJBGMIFCKDL.NKFPADOCDMA();
		}
		if (MHKMEPDCFID != null)
		{
			MHKMEPDCFID.IKNKDDMLDIN();
		}
	}

	public virtual void KPFFJDEABJL()
	{
		base.BeforeInstancied();
		if (MHKMEPDCFID != null)
		{
			MHKMEPDCFID.PLBBOKLFCPP(IAJJBAJOGDM.unitModel);
		}
	}

	public virtual void DEAPPJDAHEG()
	{
		base.BeforeInstancied();
		if (MHKMEPDCFID != null)
		{
			MHKMEPDCFID.BBIKDHCJEBH(IAJJBAJOGDM.unitModel);
		}
	}

	public virtual void DBEGFFBKGED(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		HJMGINDGDIB();
	}

	public virtual void FABNNFHGOFI()
	{
		base.BeforeInstancied();
		if (MHKMEPDCFID != null)
		{
			MHKMEPDCFID.MALPIDBEMAK(IAJJBAJOGDM.unitModel);
		}
	}
}
