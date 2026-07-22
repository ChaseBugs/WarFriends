using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class MechBehaviour : LevelBehaviour
{
	[FormerlySerializedAs("LOGDMCLMDKF")]
	public MechBehaviourDefinititon IPKOPMEMPLJ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private VehicleBehaviourDefinititon _003CILKKKBELCPJ_003Ek__BackingField;

	public VehicleBehaviourDefinititon vehicleDefinititon
	{
		[CompilerGenerated]
		get
		{
			return _003CILKKKBELCPJ_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CILKKKBELCPJ_003Ek__BackingField = value;
		}
	}

	public override BehaviourDefinititon baseBehaviourDefinititon => IPKOPMEMPLJ;

	public MechBehaviourDefinititon mechDefinition
	{
		get
		{
			return (MechBehaviourDefinititon)base.behaviourDefinition;
		}
		set
		{
			base.behaviourDefinition = value;
		}
	}

	[SpecialName]
	public void NJHBCBOJOHB(MechBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public VehicleBehaviourDefinititon BDJBOKKFNKJ()
	{
		return _003CILKKKBELCPJ_003Ek__BackingField;
	}

	[SpecialName]
	public virtual BehaviourDefinititon IGANLOHNLIK()
	{
		return IPKOPMEMPLJ;
	}

	[SpecialName]
	public MechBehaviourDefinititon PDAIFDHKGFN()
	{
		return (MechBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public VehicleBehaviourDefinititon CPDMMIHPMGN()
	{
		return _003CILKKKBELCPJ_003Ek__BackingField;
	}

	[SpecialName]
	public VehicleBehaviourDefinititon MJANMJNCCMM()
	{
		return _003CILKKKBELCPJ_003Ek__BackingField;
	}

	[SpecialName]
	public MechBehaviourDefinititon NPJLPMOFKIE()
	{
		return (MechBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public virtual BehaviourDefinititon EDKFHMLJGMN()
	{
		return IPKOPMEMPLJ;
	}

	[SpecialName]
	public MechBehaviourDefinititon CGLGPGCIADN()
	{
		return (MechBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public MechBehaviourDefinititon PNFGGJNDOBG()
	{
		return (MechBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public void GJEEEDMONIM(VehicleBehaviourDefinititon IDEBKDPMPGM)
	{
		_003CILKKKBELCPJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public VehicleBehaviourDefinititon DANPEELJIKI()
	{
		return _003CILKKKBELCPJ_003Ek__BackingField;
	}

	public override void Unload()
	{
		if (base.unitModel != null)
		{
			List<string> list = new List<string>();
			SkinnedMeshRenderer[] componentsInChildren = base.unitModel.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
			SkinnedMeshRenderer[] array = componentsInChildren;
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in array)
			{
				Resources.UnloadAsset(skinnedMeshRenderer.sharedMesh);
			}
		}
		base.Unload();
	}

	[SpecialName]
	public VehicleBehaviourDefinititon BLPMJHHLGAK()
	{
		return _003CILKKKBELCPJ_003Ek__BackingField;
	}

	[SpecialName]
	public void CJNJKCDHGHO(VehicleBehaviourDefinititon IDEBKDPMPGM)
	{
		_003CILKKKBELCPJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public VehicleBehaviourDefinititon KMBMDDFABGD()
	{
		return _003CILKKKBELCPJ_003Ek__BackingField;
	}

	[SpecialName]
	public void GNGDCBBFBGA(VehicleBehaviourDefinititon IDEBKDPMPGM)
	{
		_003CILKKKBELCPJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public MechBehaviourDefinititon IKFLKLAHGFD()
	{
		return (MechBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public void KPKBIAKIHIK(VehicleBehaviourDefinititon IDEBKDPMPGM)
	{
		_003CILKKKBELCPJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	public virtual void BNPHDECJMIF()
	{
		if (base.unitModel != null)
		{
			List<string> list = new List<string>();
			SkinnedMeshRenderer[] componentsInChildren = base.unitModel.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
			SkinnedMeshRenderer[] array = componentsInChildren;
			for (int i = 0; i < array.Length; i += 0)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = array[i];
				Resources.UnloadAsset(skinnedMeshRenderer.sharedMesh);
			}
		}
		base.Unload();
	}

	[SpecialName]
	public void EAOIDFLOBCF(VehicleBehaviourDefinititon IDEBKDPMPGM)
	{
		_003CILKKKBELCPJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public MechBehaviourDefinititon AFICADABELK()
	{
		return (MechBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public virtual BehaviourDefinititon IAKKFBPBCHO()
	{
		return IPKOPMEMPLJ;
	}

	[SpecialName]
	public MechBehaviourDefinititon APALDODNMLJ()
	{
		return (MechBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public VehicleBehaviourDefinititon OHEFMILBBPF()
	{
		return _003CILKKKBELCPJ_003Ek__BackingField;
	}

	public virtual void IAHEHPMOLHH()
	{
		if (base.unitModel != null)
		{
			List<string> list = new List<string>();
			SkinnedMeshRenderer[] componentsInChildren = base.unitModel.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
			SkinnedMeshRenderer[] array = componentsInChildren;
			for (int i = 0; i < array.Length; i += 0)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = array[i];
				Resources.UnloadAsset(skinnedMeshRenderer.sharedMesh);
			}
		}
		base.Unload();
	}

	[SpecialName]
	public VehicleBehaviourDefinititon FKKMEGLADMK()
	{
		return _003CILKKKBELCPJ_003Ek__BackingField;
	}

	[SpecialName]
	public MechBehaviourDefinititon FNDHEGEJLPI()
	{
		return (MechBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public void OHDKDOGDBJP(VehicleBehaviourDefinititon IDEBKDPMPGM)
	{
		_003CILKKKBELCPJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	public virtual void BAFAKPDFJFN()
	{
		if (base.unitModel != null)
		{
			List<string> list = new List<string>();
			SkinnedMeshRenderer[] componentsInChildren = base.unitModel.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: false);
			SkinnedMeshRenderer[] array = componentsInChildren;
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in array)
			{
				Resources.UnloadAsset(skinnedMeshRenderer.sharedMesh);
			}
		}
		base.Unload();
	}

	[SpecialName]
	public MechBehaviourDefinititon JPDBPFDGLHM()
	{
		return (MechBehaviourDefinititon)base.behaviourDefinition;
	}

	public virtual void OBDOBFIOLGB()
	{
		if (base.unitModel != null)
		{
			List<string> list = new List<string>();
			SkinnedMeshRenderer[] componentsInChildren = base.unitModel.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
			SkinnedMeshRenderer[] array = componentsInChildren;
			for (int i = 0; i < array.Length; i += 0)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = array[i];
				Resources.UnloadAsset(skinnedMeshRenderer.sharedMesh);
			}
		}
		base.Unload();
	}

	public virtual void ONGKENAHKJB()
	{
		if (base.unitModel != null)
		{
			List<string> list = new List<string>();
			SkinnedMeshRenderer[] componentsInChildren = base.unitModel.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: false);
			SkinnedMeshRenderer[] array = componentsInChildren;
			for (int i = 1; i < array.Length; i++)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = array[i];
				Resources.UnloadAsset(skinnedMeshRenderer.sharedMesh);
			}
		}
		base.Unload();
	}

	[SpecialName]
	public MechBehaviourDefinititon GCBILHNDEMH()
	{
		return (MechBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public MechBehaviourDefinititon EJKBFDGMOCP()
	{
		return (MechBehaviourDefinititon)base.behaviourDefinition;
	}

	public virtual void GICGDKCJJJN()
	{
		if (base.unitModel != null)
		{
			List<string> list = new List<string>();
			SkinnedMeshRenderer[] componentsInChildren = base.unitModel.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
			SkinnedMeshRenderer[] array = componentsInChildren;
			for (int i = 0; i < array.Length; i += 0)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = array[i];
				Resources.UnloadAsset(skinnedMeshRenderer.sharedMesh);
			}
		}
		base.Unload();
	}

	[SpecialName]
	public void NMDBIGJCFLM(MechBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	public virtual void EGHPNNPOMCH()
	{
		if (base.unitModel != null)
		{
			List<string> list = new List<string>();
			SkinnedMeshRenderer[] componentsInChildren = base.unitModel.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: false);
			SkinnedMeshRenderer[] array = componentsInChildren;
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in array)
			{
				Resources.UnloadAsset(skinnedMeshRenderer.sharedMesh);
			}
		}
		base.Unload();
	}

	[SpecialName]
	public void DGNKMKEPJMO(MechBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	public virtual void JNPKABAMLAD()
	{
		if (base.unitModel != null)
		{
			List<string> list = new List<string>();
			SkinnedMeshRenderer[] componentsInChildren = base.unitModel.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
			SkinnedMeshRenderer[] array = componentsInChildren;
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in array)
			{
				Resources.UnloadAsset(skinnedMeshRenderer.sharedMesh);
			}
		}
		base.Unload();
	}

	[SpecialName]
	public void FKKKJEJCFDL(MechBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public VehicleBehaviourDefinititon LCHGHNPOHGN()
	{
		return _003CILKKKBELCPJ_003Ek__BackingField;
	}

	[SpecialName]
	public virtual BehaviourDefinititon JMAEPCOOLGA()
	{
		return IPKOPMEMPLJ;
	}

	public virtual void EPAPNALPBKN()
	{
		if (base.unitModel != null)
		{
			List<string> list = new List<string>();
			SkinnedMeshRenderer[] componentsInChildren = base.unitModel.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: false);
			SkinnedMeshRenderer[] array = componentsInChildren;
			for (int i = 0; i < array.Length; i += 0)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = array[i];
				Resources.UnloadAsset(skinnedMeshRenderer.sharedMesh);
			}
		}
		base.Unload();
	}

	[SpecialName]
	public void IMFPBPMMJEF(MechBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	public virtual void BADLHDJPADC()
	{
		if (base.unitModel != null)
		{
			List<string> list = new List<string>();
			SkinnedMeshRenderer[] componentsInChildren = base.unitModel.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
			SkinnedMeshRenderer[] array = componentsInChildren;
			for (int i = 0; i < array.Length; i += 0)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = array[i];
				Resources.UnloadAsset(skinnedMeshRenderer.sharedMesh);
			}
		}
		base.Unload();
	}

	[SpecialName]
	public void PGHKDOOHLPB(MechBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public void OGEHEPEJDAL(VehicleBehaviourDefinititon IDEBKDPMPGM)
	{
		_003CILKKKBELCPJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public VehicleBehaviourDefinititon IBMDEDLFPLP()
	{
		return _003CILKKKBELCPJ_003Ek__BackingField;
	}

	public virtual void OAANIMCCPLN()
	{
		if (base.unitModel != null)
		{
			List<string> list = new List<string>();
			SkinnedMeshRenderer[] componentsInChildren = base.unitModel.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
			SkinnedMeshRenderer[] array = componentsInChildren;
			for (int i = 1; i < array.Length; i += 0)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = array[i];
				Resources.UnloadAsset(skinnedMeshRenderer.sharedMesh);
			}
		}
		base.Unload();
	}

	[SpecialName]
	public MechBehaviourDefinititon BKNGKPHIMOC()
	{
		return (MechBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public virtual BehaviourDefinititon CGAANAGLLIK()
	{
		return IPKOPMEMPLJ;
	}

	public virtual void PFIEBIOPFGJ()
	{
		if (base.unitModel != null)
		{
			List<string> list = new List<string>();
			SkinnedMeshRenderer[] componentsInChildren = base.unitModel.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
			SkinnedMeshRenderer[] array = componentsInChildren;
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in array)
			{
				Resources.UnloadAsset(skinnedMeshRenderer.sharedMesh);
			}
		}
		base.Unload();
	}

	public virtual void KLLAKEFELAO()
	{
		if (base.unitModel != null)
		{
			List<string> list = new List<string>();
			SkinnedMeshRenderer[] componentsInChildren = base.unitModel.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
			SkinnedMeshRenderer[] array = componentsInChildren;
			for (int i = 1; i < array.Length; i++)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = array[i];
				Resources.UnloadAsset(skinnedMeshRenderer.sharedMesh);
			}
		}
		base.Unload();
	}

	[SpecialName]
	public void IJBONPDFPOH(MechBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public void NEDAMHPLGFG(VehicleBehaviourDefinititon IDEBKDPMPGM)
	{
		_003CILKKKBELCPJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	public virtual void MFNBADGAJAI()
	{
		if (base.unitModel != null)
		{
			List<string> list = new List<string>();
			SkinnedMeshRenderer[] componentsInChildren = base.unitModel.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
			SkinnedMeshRenderer[] array = componentsInChildren;
			for (int i = 1; i < array.Length; i++)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = array[i];
				Resources.UnloadAsset(skinnedMeshRenderer.sharedMesh);
			}
		}
		base.Unload();
	}

	[SpecialName]
	public void PCPMOEPNPKE(VehicleBehaviourDefinititon IDEBKDPMPGM)
	{
		_003CILKKKBELCPJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual BehaviourDefinititon GAPMJJPKLMK()
	{
		return IPKOPMEMPLJ;
	}

	[SpecialName]
	public void BNHGKJNKOCK(VehicleBehaviourDefinititon IDEBKDPMPGM)
	{
		_003CILKKKBELCPJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	public virtual void IIDFGGEOACK()
	{
		if (base.unitModel != null)
		{
			List<string> list = new List<string>();
			SkinnedMeshRenderer[] componentsInChildren = base.unitModel.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
			SkinnedMeshRenderer[] array = componentsInChildren;
			for (int i = 0; i < array.Length; i += 0)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = array[i];
				Resources.UnloadAsset(skinnedMeshRenderer.sharedMesh);
			}
		}
		base.Unload();
	}

	[SpecialName]
	public void BBMBGLDMIOC(VehicleBehaviourDefinititon IDEBKDPMPGM)
	{
		_003CILKKKBELCPJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public VehicleBehaviourDefinititon ENFEMAALNIM()
	{
		return _003CILKKKBELCPJ_003Ek__BackingField;
	}

	[SpecialName]
	public void KDJNMAHCOCH(VehicleBehaviourDefinititon IDEBKDPMPGM)
	{
		_003CILKKKBELCPJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual BehaviourDefinititon NECJCNFAIOG()
	{
		return IPKOPMEMPLJ;
	}

	[SpecialName]
	public VehicleBehaviourDefinititon LNLMKFAENAL()
	{
		return _003CILKKKBELCPJ_003Ek__BackingField;
	}

	[SpecialName]
	public MechBehaviourDefinititon FMFEABFFCKA()
	{
		return (MechBehaviourDefinititon)base.behaviourDefinition;
	}

	public virtual void DCJMJCGPDGA()
	{
		if (base.unitModel != null)
		{
			List<string> list = new List<string>();
			SkinnedMeshRenderer[] componentsInChildren = base.unitModel.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: false);
			SkinnedMeshRenderer[] array = componentsInChildren;
			for (int i = 1; i < array.Length; i += 0)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = array[i];
				Resources.UnloadAsset(skinnedMeshRenderer.sharedMesh);
			}
		}
		base.Unload();
	}

	[SpecialName]
	public void ECMJBEBCAJE(MechBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public MechBehaviourDefinititon EJLPFKFOABG()
	{
		return (MechBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public void MECDANPKENG(MechBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public MechBehaviourDefinititon ELCDGMPKFBH()
	{
		return (MechBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public void NCHDOJGJFDE(VehicleBehaviourDefinititon IDEBKDPMPGM)
	{
		_003CILKKKBELCPJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void GEAJDDNBBAI(MechBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public void OACPFEDJIDF(VehicleBehaviourDefinititon IDEBKDPMPGM)
	{
		_003CILKKKBELCPJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	public virtual void IPAIADKFJEJ()
	{
		if (base.unitModel != null)
		{
			List<string> list = new List<string>();
			SkinnedMeshRenderer[] componentsInChildren = base.unitModel.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: false);
			SkinnedMeshRenderer[] array = componentsInChildren;
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in array)
			{
				Resources.UnloadAsset(skinnedMeshRenderer.sharedMesh);
			}
		}
		base.Unload();
	}

	[SpecialName]
	public virtual BehaviourDefinititon GAIKJFNPLOB()
	{
		return IPKOPMEMPLJ;
	}

	public virtual void EAMFKHDALGC()
	{
		if (base.unitModel != null)
		{
			List<string> list = new List<string>();
			SkinnedMeshRenderer[] componentsInChildren = base.unitModel.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
			SkinnedMeshRenderer[] array = componentsInChildren;
			for (int i = 0; i < array.Length; i += 0)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = array[i];
				Resources.UnloadAsset(skinnedMeshRenderer.sharedMesh);
			}
		}
		base.Unload();
	}

	[SpecialName]
	public VehicleBehaviourDefinititon EILNCBCCGLH()
	{
		return _003CILKKKBELCPJ_003Ek__BackingField;
	}

	[SpecialName]
	public virtual BehaviourDefinititon POGPIFBJGKC()
	{
		return IPKOPMEMPLJ;
	}

	[SpecialName]
	public void PFJANIPKLKO(VehicleBehaviourDefinititon IDEBKDPMPGM)
	{
		_003CILKKKBELCPJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public VehicleBehaviourDefinititon PNLGLFFADGF()
	{
		return _003CILKKKBELCPJ_003Ek__BackingField;
	}

	[SpecialName]
	public void HNEKOGMALKG(VehicleBehaviourDefinititon IDEBKDPMPGM)
	{
		_003CILKKKBELCPJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public MechBehaviourDefinititon EANCDAANAOD()
	{
		return (MechBehaviourDefinititon)base.behaviourDefinition;
	}

	public virtual void FMOELDKEGPI()
	{
		if (base.unitModel != null)
		{
			List<string> list = new List<string>();
			SkinnedMeshRenderer[] componentsInChildren = base.unitModel.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: false);
			SkinnedMeshRenderer[] array = componentsInChildren;
			for (int i = 1; i < array.Length; i += 0)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = array[i];
				Resources.UnloadAsset(skinnedMeshRenderer.sharedMesh);
			}
		}
		base.Unload();
	}

	[SpecialName]
	public virtual BehaviourDefinititon JFKAADAGPFD()
	{
		return IPKOPMEMPLJ;
	}

	[SpecialName]
	public virtual BehaviourDefinititon DHKJAFEKIOP()
	{
		return IPKOPMEMPLJ;
	}

	[SpecialName]
	public MechBehaviourDefinititon MACHBLIOHKK()
	{
		return (MechBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public MechBehaviourDefinititon CGEIEJGCIMB()
	{
		return (MechBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public MechBehaviourDefinititon HNPOKNFOBDO()
	{
		return (MechBehaviourDefinititon)base.behaviourDefinition;
	}

	public virtual void AFKFCLGIBNP()
	{
		if (base.unitModel != null)
		{
			List<string> list = new List<string>();
			SkinnedMeshRenderer[] componentsInChildren = base.unitModel.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
			SkinnedMeshRenderer[] array = componentsInChildren;
			for (int i = 0; i < array.Length; i += 0)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = array[i];
				Resources.UnloadAsset(skinnedMeshRenderer.sharedMesh);
			}
		}
		base.Unload();
	}

	[SpecialName]
	public MechBehaviourDefinititon LEGLBPJPGOM()
	{
		return (MechBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public MechBehaviourDefinititon ICNFJPPJEKG()
	{
		return (MechBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public virtual BehaviourDefinititon DCDJGJKAFAE()
	{
		return IPKOPMEMPLJ;
	}

	[SpecialName]
	public void FOBHHDBBANG(MechBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual BehaviourDefinititon HFABBDENCBD()
	{
		return IPKOPMEMPLJ;
	}

	[SpecialName]
	public void NEOBPCCIAJA(VehicleBehaviourDefinititon IDEBKDPMPGM)
	{
		_003CILKKKBELCPJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public MechBehaviourDefinititon JAOIJLBHMKK()
	{
		return (MechBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public MechBehaviourDefinititon EKKFDPDMIJM()
	{
		return (MechBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public void NDIEFHPFCOI(VehicleBehaviourDefinititon IDEBKDPMPGM)
	{
		_003CILKKKBELCPJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	public virtual void PFAKGHCOPIJ()
	{
		if (base.unitModel != null)
		{
			List<string> list = new List<string>();
			SkinnedMeshRenderer[] componentsInChildren = base.unitModel.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
			SkinnedMeshRenderer[] array = componentsInChildren;
			for (int i = 1; i < array.Length; i += 0)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = array[i];
				Resources.UnloadAsset(skinnedMeshRenderer.sharedMesh);
			}
		}
		base.Unload();
	}

	[SpecialName]
	public MechBehaviourDefinititon PHEPGPOLOCM()
	{
		return (MechBehaviourDefinititon)base.behaviourDefinition;
	}

	[SpecialName]
	public VehicleBehaviourDefinititon KCCPAOPFBOD()
	{
		return _003CILKKKBELCPJ_003Ek__BackingField;
	}

	[SpecialName]
	public void BFHEBKMMOEH(MechBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public VehicleBehaviourDefinititon EEHLKBMNLNG()
	{
		return _003CILKKKBELCPJ_003Ek__BackingField;
	}

	[SpecialName]
	public virtual BehaviourDefinititon NHPBELJGPCC()
	{
		return IPKOPMEMPLJ;
	}

	[SpecialName]
	public void LNIHNPIFHLC(VehicleBehaviourDefinititon IDEBKDPMPGM)
	{
		_003CILKKKBELCPJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	public virtual void EJJGPGHLONN()
	{
		if (base.unitModel != null)
		{
			List<string> list = new List<string>();
			SkinnedMeshRenderer[] componentsInChildren = base.unitModel.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
			SkinnedMeshRenderer[] array = componentsInChildren;
			for (int i = 1; i < array.Length; i += 0)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = array[i];
				Resources.UnloadAsset(skinnedMeshRenderer.sharedMesh);
			}
		}
		base.Unload();
	}

	[SpecialName]
	public void FEECADEAHNH(MechBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public void FCFKOPDIJCH(VehicleBehaviourDefinititon IDEBKDPMPGM)
	{
		_003CILKKKBELCPJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void OIJGJOBCAML(VehicleBehaviourDefinititon IDEBKDPMPGM)
	{
		_003CILKKKBELCPJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void POHMFJEGLKO(MechBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public VehicleBehaviourDefinititon NJODIEHPOHH()
	{
		return _003CILKKKBELCPJ_003Ek__BackingField;
	}

	[SpecialName]
	public void PJOFFLLFGDH(VehicleBehaviourDefinititon IDEBKDPMPGM)
	{
		_003CILKKKBELCPJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public VehicleBehaviourDefinititon AMIEHMJBMDA()
	{
		return _003CILKKKBELCPJ_003Ek__BackingField;
	}

	[SpecialName]
	public void LOHINIAGNKA(MechBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public VehicleBehaviourDefinititon BOIIFMNCAHE()
	{
		return _003CILKKKBELCPJ_003Ek__BackingField;
	}

	[SpecialName]
	public VehicleBehaviourDefinititon KPGECNOHOAI()
	{
		return _003CILKKKBELCPJ_003Ek__BackingField;
	}

	[SpecialName]
	public void FOEIADPDMLK(MechBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public VehicleBehaviourDefinititon LJLEFOBNNLA()
	{
		return _003CILKKKBELCPJ_003Ek__BackingField;
	}

	[SpecialName]
	public void CKLIIPJNCNC(MechBehaviourDefinititon IDEBKDPMPGM)
	{
		base.behaviourDefinition = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual BehaviourDefinititon AGKAPIJCOLD()
	{
		return IPKOPMEMPLJ;
	}

	[SpecialName]
	public MechBehaviourDefinititon PNBAIFEINJI()
	{
		return (MechBehaviourDefinititon)base.behaviourDefinition;
	}

	public virtual void HPGFFEPOKKJ()
	{
		if (base.unitModel != null)
		{
			List<string> list = new List<string>();
			SkinnedMeshRenderer[] componentsInChildren = base.unitModel.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: false);
			SkinnedMeshRenderer[] array = componentsInChildren;
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in array)
			{
				Resources.UnloadAsset(skinnedMeshRenderer.sharedMesh);
			}
		}
		base.Unload();
	}

	[SpecialName]
	public virtual BehaviourDefinititon DAOJOGOOKAL()
	{
		return IPKOPMEMPLJ;
	}

	[SpecialName]
	public void NFFAHBNODMP(VehicleBehaviourDefinititon IDEBKDPMPGM)
	{
		_003CILKKKBELCPJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public MechBehaviourDefinititon DOJCOMIMPBG()
	{
		return (MechBehaviourDefinititon)base.behaviourDefinition;
	}
}
