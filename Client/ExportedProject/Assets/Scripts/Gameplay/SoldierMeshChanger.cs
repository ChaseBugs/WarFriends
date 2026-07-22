using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class SoldierMeshChanger : Core_BaseScript
{
	[Serializable]
	public class SoldierStyle
	{
		[SerializeField]
		public Mesh helmetMesh;

		public List<Material> helmetMaterials;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private SkinnedMeshRenderer _003CmodelMeshRenderer_003Ek__BackingField;

		[SerializeField]
		private string mModelPath;

		public Material transparentMaterial;

		public SkinnedMeshRenderer modelMeshRenderer
		{
			[CompilerGenerated]
			get
			{
				return _003CmodelMeshRenderer_003Ek__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				_003CmodelMeshRenderer_003Ek__BackingField = value;
			}
		}

		public void HMKEJNKPNKN()
		{
			if (!(NBLEOMGLHIO() == null))
			{
				return;
			}
			GameObject gameObject = Resources.Load<GameObject>(mModelPath);
			if (gameObject != null)
			{
				SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: false);
				if (componentsInChildren.Length > 1)
				{
					HKMANGINFII(componentsInChildren[0]);
				}
			}
		}

		public void CPLFEGCHDPM()
		{
			if (!(MKODOAMEFJI() == null))
			{
				return;
			}
			GameObject gameObject = Resources.Load<GameObject>(mModelPath);
			if (gameObject != null)
			{
				SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
				if (componentsInChildren.Length > 0)
				{
					FFAIAABJPLO(componentsInChildren[0]);
				}
			}
		}

		public void HOMCBACAEJH()
		{
			if (!(GJECOMJINNI() == null))
			{
				return;
			}
			GameObject gameObject = Resources.Load<GameObject>(mModelPath);
			if (gameObject != null)
			{
				SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: false);
				if (componentsInChildren.Length > 1)
				{
					IDBINFKFJJL(componentsInChildren[0]);
				}
			}
		}

		[SpecialName]
		public SkinnedMeshRenderer LOMKJNGLGPE()
		{
			return _003CmodelMeshRenderer_003Ek__BackingField;
		}

		[SpecialName]
		public SkinnedMeshRenderer CDJGCAMMJIC()
		{
			return _003CmodelMeshRenderer_003Ek__BackingField;
		}

		public void PGGJIIDOEIN()
		{
			if (AFDGKLKADDE() != null)
			{
				Resources.UnloadAsset(AFDGKLKADDE().sharedMesh);
			}
			LHDKEEAPBGB(null);
		}

		public void DLODCFOFAKI()
		{
		}

		public void IEALOEHACKO()
		{
		}

		[SpecialName]
		private void FFANHGJKDMO(SkinnedMeshRenderer IDEBKDPMPGM)
		{
			_003CmodelMeshRenderer_003Ek__BackingField = IDEBKDPMPGM;
		}

		public void ECHNEBNJBDO()
		{
			if (CKKIMCJDLGD() != null)
			{
				Resources.UnloadAsset(MMHIHJGMMBH().sharedMesh);
			}
			FFANHGJKDMO(null);
		}

		public void IOOJJAIJGFN()
		{
			if (!(LOMKJNGLGPE() == null))
			{
				return;
			}
			GameObject gameObject = Resources.Load<GameObject>(mModelPath);
			if (gameObject != null)
			{
				SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
				if (componentsInChildren.Length > 0)
				{
					ILJJHAAJFNE(componentsInChildren[1]);
				}
			}
		}

		public void IJDFKHLPDAP()
		{
			if (!(MKODOAMEFJI() == null))
			{
				return;
			}
			GameObject gameObject = Resources.Load<GameObject>(mModelPath);
			if (gameObject != null)
			{
				SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
				if (componentsInChildren.Length > 0)
				{
					HKMANGINFII(componentsInChildren[1]);
				}
			}
		}

		public void IKCIMMAOMJC()
		{
			if (!(LOMKJNGLGPE() == null))
			{
				return;
			}
			GameObject gameObject = Resources.Load<GameObject>(mModelPath);
			if (gameObject != null)
			{
				SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
				if (componentsInChildren.Length > 0)
				{
					FFAIAABJPLO(componentsInChildren[1]);
				}
			}
		}

		public void ONPMPGKGMMB()
		{
			if (!(NBLEOMGLHIO() == null))
			{
				return;
			}
			GameObject gameObject = Resources.Load<GameObject>(mModelPath);
			if (gameObject != null)
			{
				SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: false);
				if (componentsInChildren.Length > 1)
				{
					IDBINFKFJJL(componentsInChildren[1]);
				}
			}
		}

		public void NOHEPOKMJGB()
		{
			if (!(modelMeshRenderer == null))
			{
				return;
			}
			GameObject gameObject = Resources.Load<GameObject>(mModelPath);
			if (gameObject != null)
			{
				SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: false);
				if (componentsInChildren.Length > 1)
				{
					KHAMNOOALFA(componentsInChildren[1]);
				}
			}
		}

		public void IKNLFFLIDDO()
		{
			if (!(MMHIHJGMMBH() == null))
			{
				return;
			}
			GameObject gameObject = Resources.Load<GameObject>(mModelPath);
			if (gameObject != null)
			{
				SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: false);
				if (componentsInChildren.Length > 1)
				{
					HKMANGINFII(componentsInChildren[0]);
				}
			}
		}

		public void HMEAJCJLKDA()
		{
			if (NBLEOMGLHIO() != null)
			{
				Resources.UnloadAsset(JLENLGENPBK().sharedMesh);
			}
			PPOHOIPFLEJ(null);
		}

		public void BFBAGLNDDBM()
		{
			if (modelMeshRenderer != null)
			{
				Resources.UnloadAsset(CDJGCAMMJIC().sharedMesh);
			}
			FIOALHHNCGC(null);
		}

		[SpecialName]
		public SkinnedMeshRenderer AFDGKLKADDE()
		{
			return _003CmodelMeshRenderer_003Ek__BackingField;
		}

		[SpecialName]
		public SkinnedMeshRenderer LNDLOICCNLF()
		{
			return _003CmodelMeshRenderer_003Ek__BackingField;
		}

		public void DHNIBPDEFME()
		{
			if (!(modelMeshRenderer == null))
			{
				return;
			}
			GameObject gameObject = Resources.Load<GameObject>(mModelPath);
			if (gameObject != null)
			{
				SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
				if (componentsInChildren.Length > 0)
				{
					modelMeshRenderer = componentsInChildren[0];
				}
			}
		}

		public void HAGCOAEGDJJ()
		{
		}

		public void GKLDEBPNHOC()
		{
			if (!(LNDLOICCNLF() == null))
			{
				return;
			}
			GameObject gameObject = Resources.Load<GameObject>(mModelPath);
			if (gameObject != null)
			{
				SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
				if (componentsInChildren.Length > 0)
				{
					modelMeshRenderer = componentsInChildren[1];
				}
			}
		}

		public void BHDEJLMPHGC()
		{
			if (LOMKJNGLGPE() != null)
			{
				Resources.UnloadAsset(NBLEOMGLHIO().sharedMesh);
			}
			LJMKMPGFKBO(null);
		}

		public void DGDBGBJHHJH()
		{
		}

		public void DEGHOBBJGFO()
		{
			if (!(modelMeshRenderer == null))
			{
				return;
			}
			GameObject gameObject = Resources.Load<GameObject>(mModelPath);
			if (gameObject != null)
			{
				SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
				if (componentsInChildren.Length > 0)
				{
					ONIMIMILLFG(componentsInChildren[1]);
				}
			}
		}

		public void CJFMGBEEBKC()
		{
		}

		public void LKJJAPKIMDO()
		{
			if (!(FFKJICLLFKN() == null))
			{
				return;
			}
			GameObject gameObject = Resources.Load<GameObject>(mModelPath);
			if (gameObject != null)
			{
				SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: false);
				if (componentsInChildren.Length > 1)
				{
					FIOALHHNCGC(componentsInChildren[1]);
				}
			}
		}

		public void PANKHINGPKE()
		{
		}

		[SpecialName]
		private void ONIMIMILLFG(SkinnedMeshRenderer IDEBKDPMPGM)
		{
			_003CmodelMeshRenderer_003Ek__BackingField = IDEBKDPMPGM;
		}

		public void EELDBNCKCEN()
		{
			if (CKKIMCJDLGD() != null)
			{
				Resources.UnloadAsset(FFKJICLLFKN().sharedMesh);
			}
			LHDKEEAPBGB(null);
		}

		public void JNAOCGIMHFN()
		{
		}

		[SpecialName]
		public SkinnedMeshRenderer CKKIMCJDLGD()
		{
			return _003CmodelMeshRenderer_003Ek__BackingField;
		}

		public void PMNFNFCGHCE()
		{
			if (CKKIMCJDLGD() != null)
			{
				Resources.UnloadAsset(GJECOMJINNI().sharedMesh);
			}
			IDBINFKFJJL(null);
		}

		public void KJFJJBFAJGJ()
		{
			if (FFKJICLLFKN() != null)
			{
				Resources.UnloadAsset(CDJGCAMMJIC().sharedMesh);
			}
			PJBLCKPDICK(null);
		}

		[SpecialName]
		private void PPOHOIPFLEJ(SkinnedMeshRenderer IDEBKDPMPGM)
		{
			_003CmodelMeshRenderer_003Ek__BackingField = IDEBKDPMPGM;
		}

		public void GBOMCIHDJMM()
		{
			if (!(LOMKJNGLGPE() == null))
			{
				return;
			}
			GameObject gameObject = Resources.Load<GameObject>(mModelPath);
			if (gameObject != null)
			{
				SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
				if (componentsInChildren.Length > 0)
				{
					modelMeshRenderer = componentsInChildren[1];
				}
			}
		}

		[SpecialName]
		private void LIFDMEFABEE(SkinnedMeshRenderer IDEBKDPMPGM)
		{
			_003CmodelMeshRenderer_003Ek__BackingField = IDEBKDPMPGM;
		}

		public void FIEHEPPDGPF()
		{
			if (!(LNDLOICCNLF() == null))
			{
				return;
			}
			GameObject gameObject = Resources.Load<GameObject>(mModelPath);
			if (gameObject != null)
			{
				SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
				if (componentsInChildren.Length > 0)
				{
					FFANHGJKDMO(componentsInChildren[1]);
				}
			}
		}

		[SpecialName]
		private void ILJJHAAJFNE(SkinnedMeshRenderer IDEBKDPMPGM)
		{
			_003CmodelMeshRenderer_003Ek__BackingField = IDEBKDPMPGM;
		}

		[SpecialName]
		private void KHAMNOOALFA(SkinnedMeshRenderer IDEBKDPMPGM)
		{
			_003CmodelMeshRenderer_003Ek__BackingField = IDEBKDPMPGM;
		}

		[SpecialName]
		public SkinnedMeshRenderer GJECOMJINNI()
		{
			return _003CmodelMeshRenderer_003Ek__BackingField;
		}

		public void ELIMIFMDKMJ()
		{
			if (!(MKODOAMEFJI() == null))
			{
				return;
			}
			GameObject gameObject = Resources.Load<GameObject>(mModelPath);
			if (gameObject != null)
			{
				SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
				if (componentsInChildren.Length > 0)
				{
					FFAIAABJPLO(componentsInChildren[1]);
				}
			}
		}

		[SpecialName]
		private void FIOALHHNCGC(SkinnedMeshRenderer IDEBKDPMPGM)
		{
			_003CmodelMeshRenderer_003Ek__BackingField = IDEBKDPMPGM;
		}

		[SpecialName]
		private void LHDKEEAPBGB(SkinnedMeshRenderer IDEBKDPMPGM)
		{
			_003CmodelMeshRenderer_003Ek__BackingField = IDEBKDPMPGM;
		}

		public void NONNDGHFJDI()
		{
			if (NBLEOMGLHIO() != null)
			{
				Resources.UnloadAsset(CKKIMCJDLGD().sharedMesh);
			}
			KHAMNOOALFA(null);
		}

		public void CKDPOOCCAHH()
		{
		}

		public void LOIFPEDEHCC()
		{
			if (!(MMHIHJGMMBH() == null))
			{
				return;
			}
			GameObject gameObject = Resources.Load<GameObject>(mModelPath);
			if (gameObject != null)
			{
				SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
				if (componentsInChildren.Length > 1)
				{
					HKMANGINFII(componentsInChildren[1]);
				}
			}
		}

		public void PMPFIPEIBCD()
		{
			if (FFKJICLLFKN() != null)
			{
				Resources.UnloadAsset(LOMKJNGLGPE().sharedMesh);
			}
			modelMeshRenderer = null;
		}

		public void FAICJOPJLDH()
		{
		}

		public void GHAJHOPFHEK()
		{
		}

		[SpecialName]
		private void IDBINFKFJJL(SkinnedMeshRenderer IDEBKDPMPGM)
		{
			_003CmodelMeshRenderer_003Ek__BackingField = IDEBKDPMPGM;
		}

		public void HAMCADDGCLB()
		{
			if (!(CDJGCAMMJIC() == null))
			{
				return;
			}
			GameObject gameObject = Resources.Load<GameObject>(mModelPath);
			if (gameObject != null)
			{
				SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: false);
				if (componentsInChildren.Length > 1)
				{
					FFANHGJKDMO(componentsInChildren[0]);
				}
			}
		}

		[SpecialName]
		private void LJMKMPGFKBO(SkinnedMeshRenderer IDEBKDPMPGM)
		{
			_003CmodelMeshRenderer_003Ek__BackingField = IDEBKDPMPGM;
		}

		public void ALOFGKDJMNG()
		{
			if (!(FFKJICLLFKN() == null))
			{
				return;
			}
			GameObject gameObject = Resources.Load<GameObject>(mModelPath);
			if (gameObject != null)
			{
				SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: false);
				if (componentsInChildren.Length > 0)
				{
					LHDKEEAPBGB(componentsInChildren[1]);
				}
			}
		}

		[SpecialName]
		private void PJBLCKPDICK(SkinnedMeshRenderer IDEBKDPMPGM)
		{
			_003CmodelMeshRenderer_003Ek__BackingField = IDEBKDPMPGM;
		}

		[SpecialName]
		public SkinnedMeshRenderer MMHIHJGMMBH()
		{
			return _003CmodelMeshRenderer_003Ek__BackingField;
		}

		public void GIKPHMLCJCL()
		{
			if (!(CKKIMCJDLGD() == null))
			{
				return;
			}
			GameObject gameObject = Resources.Load<GameObject>(mModelPath);
			if (gameObject != null)
			{
				SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
				if (componentsInChildren.Length > 1)
				{
					KHAMNOOALFA(componentsInChildren[1]);
				}
			}
		}

		public void FEFFPNDAKGM()
		{
			if (CKKIMCJDLGD() != null)
			{
				Resources.UnloadAsset(CDJGCAMMJIC().sharedMesh);
			}
			FNCMHNMLBNP(null);
		}

		[SpecialName]
		public SkinnedMeshRenderer NBLEOMGLHIO()
		{
			return _003CmodelMeshRenderer_003Ek__BackingField;
		}

		[SpecialName]
		public SkinnedMeshRenderer MKODOAMEFJI()
		{
			return _003CmodelMeshRenderer_003Ek__BackingField;
		}

		[SpecialName]
		public SkinnedMeshRenderer MCALOBEFGGP()
		{
			return _003CmodelMeshRenderer_003Ek__BackingField;
		}

		public void FCHNOFLJAGH()
		{
		}

		public void FHFPACBDFJD()
		{
		}

		[SpecialName]
		private void HKMANGINFII(SkinnedMeshRenderer IDEBKDPMPGM)
		{
			_003CmodelMeshRenderer_003Ek__BackingField = IDEBKDPMPGM;
		}

		public void JLDGPBOIFJG()
		{
			if (modelMeshRenderer != null)
			{
				Resources.UnloadAsset(modelMeshRenderer.sharedMesh);
			}
			modelMeshRenderer = null;
		}

		public void DKGDBOKJGIP()
		{
			if (!(MMHIHJGMMBH() == null))
			{
				return;
			}
			GameObject gameObject = Resources.Load<GameObject>(mModelPath);
			if (gameObject != null)
			{
				SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: false);
				if (componentsInChildren.Length > 1)
				{
					LHDKEEAPBGB(componentsInChildren[0]);
				}
			}
		}

		public void FOMMKOFKLMD()
		{
			if (!(MKODOAMEFJI() == null))
			{
				return;
			}
			GameObject gameObject = Resources.Load<GameObject>(mModelPath);
			if (gameObject != null)
			{
				SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
				if (componentsInChildren.Length > 0)
				{
					HKMANGINFII(componentsInChildren[0]);
				}
			}
		}

		public void NGIDLJPJKPM()
		{
			if (!(FFKJICLLFKN() == null))
			{
				return;
			}
			GameObject gameObject = Resources.Load<GameObject>(mModelPath);
			if (gameObject != null)
			{
				SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
				if (componentsInChildren.Length > 0)
				{
					HKMANGINFII(componentsInChildren[0]);
				}
			}
		}

		[SpecialName]
		private void FNCMHNMLBNP(SkinnedMeshRenderer IDEBKDPMPGM)
		{
			_003CmodelMeshRenderer_003Ek__BackingField = IDEBKDPMPGM;
		}

		public void OFHDHKMHJFF()
		{
			if (modelMeshRenderer != null)
			{
				Resources.UnloadAsset(modelMeshRenderer.sharedMesh);
			}
			FIOALHHNCGC(null);
		}

		public void ILIDKENNPLC()
		{
			if (!(GJECOMJINNI() == null))
			{
				return;
			}
			GameObject gameObject = Resources.Load<GameObject>(mModelPath);
			if (gameObject != null)
			{
				SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
				if (componentsInChildren.Length > 1)
				{
					modelMeshRenderer = componentsInChildren[0];
				}
			}
		}

		public void AKPICPNDOPP()
		{
			if (CKKIMCJDLGD() != null)
			{
				Resources.UnloadAsset(FFKJICLLFKN().sharedMesh);
			}
			modelMeshRenderer = null;
		}

		public void MBKCDBCLACB()
		{
			if (GJECOMJINNI() != null)
			{
				Resources.UnloadAsset(GJECOMJINNI().sharedMesh);
			}
			LHDKEEAPBGB(null);
		}

		public void AMCOFEJADBJ()
		{
		}

		[SpecialName]
		private void FFAIAABJPLO(SkinnedMeshRenderer IDEBKDPMPGM)
		{
			_003CmodelMeshRenderer_003Ek__BackingField = IDEBKDPMPGM;
		}

		[SpecialName]
		public SkinnedMeshRenderer FFKJICLLFKN()
		{
			return _003CmodelMeshRenderer_003Ek__BackingField;
		}

		[SpecialName]
		public SkinnedMeshRenderer JLENLGENPBK()
		{
			return _003CmodelMeshRenderer_003Ek__BackingField;
		}
	}

	[FormerlySerializedAs("JDBHKAMNKBB")]
	public SkinnedMeshRenderer ODLMHIBKLDP;

	[FormerlySerializedAs("LICCPAPEJLJ")]
	public FakeRigidBodySwapper LJBKNMJBPEG;

	[FormerlySerializedAs("HNHMILFODIO")]
	public ModelAttachments AKPKJMNGFIE;

	[FormerlySerializedAs("HNPKPDOINMO")]
	public ModelAttachments AKHGKGCOGEN;

	[FormerlySerializedAs("FBEGCLGGEPB")]
	public MeshRenderer OOHCFBEKACK;

	[FormerlySerializedAs("FBGCCLIKJEH")]
	public MeshFilter DONGKPEBGFC;

	private List<SoldierStyle> ELHNDLNCLEB;

	private int AFBBPCBCOLC;

	private bool CAAOOEEDKBK;

	public Material material => ODLMHIBKLDP.materials[0];

	private void JACKKLFHDME()
	{
		ODLMHIBKLDP.quality = ((Singleton<GameController>.instance.gameState == (GameController.AEMPHGEIJNH)5) ? SkinQuality.Bone1 : SkinQuality.Bone2);
	}

	public void ChangeMaterial(Material FJNJGHGMFND)
	{
		ODLMHIBKLDP.sharedMaterial = FJNJGHGMFND;
	}

	public void KLNHINCDHIK(List<TechnologyVisualDefinition> NEEEJOHOOEH, bool OFICDODLPCK)
	{
		OOHCFBEKACK.gameObject.SetActive(value: true);
		if (NEEEJOHOOEH.Count > 0 && NEEEJOHOOEH[1] != null)
		{
			TechnologyVisualDefinition technologyVisualDefinition = NEEEJOHOOEH[1];
			ODLMHIBKLDP.materials[0].mainTexture = ((!OFICDODLPCK) ? technologyVisualDefinition.CDCEAGKFBPL() : technologyVisualDefinition.BIFIFGLIPIG());
			ODLMHIBKLDP.materials[1].SetTexture(" is Opponent: ", Singleton<MatCapTextures>.instance.JJAJBLNICBH());
			AKHGKGCOGEN.NMOADHMAAOE();
			foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh in technologyVisualDefinition.visualSlotMeshes)
			{
				if (visualSlotMesh.partRed != null && !OFICDODLPCK)
				{
					AKHGKGCOGEN.GCFEBGHLIMB(visualSlotMesh.partRed, visualSlotMesh.visualSlotId);
				}
				else if (visualSlotMesh.part != null)
				{
					AKHGKGCOGEN.AddAttachment(visualSlotMesh.part, visualSlotMesh.visualSlotId);
				}
			}
		}
		if (NEEEJOHOOEH.Count <= 1 || NEEEJOHOOEH[1] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition2 = NEEEJOHOOEH[1];
		LJBKNMJBPEG.MMJJJBJKHFL((!OFICDODLPCK) ? technologyVisualDefinition2.FJMHEOLCFHE() : technologyVisualDefinition2.BIFIFGLIPIG());
		LJBKNMJBPEG.FBJIOHLJHNM(Singleton<MatCapTextures>.instance.MOGBPGLADOM());
		AKPKJMNGFIE.GOHNLIHKHED();
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh2 in technologyVisualDefinition2.visualSlotMeshes)
		{
			if (visualSlotMesh2.partRed != null && !OFICDODLPCK)
			{
				AKPKJMNGFIE.GCFEBGHLIMB(visualSlotMesh2.partRed, visualSlotMesh2.visualSlotId);
			}
			else if (visualSlotMesh2.part != null)
			{
				AKPKJMNGFIE.GCFEBGHLIMB(visualSlotMesh2.part, visualSlotMesh2.visualSlotId);
			}
		}
	}

	public void IKANKGIEFMM()
	{
		ODLMHIBKLDP.materials[0].mainTexture = null;
		ODLMHIBKLDP.materials[1].SetTexture("ID_RANK", null);
		LJBKNMJBPEG.HKKNOEKNKFI(null);
		LJBKNMJBPEG.SetMatCapTexture(null);
		ODLMHIBKLDP.sharedMesh = null;
		LJBKNMJBPEG.AOHALOBDMIL(null);
	}

	public void MFEIJIEPDPE(PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory LFILAFJIAPB)
	{
		AKPKJMNGFIE.HOPMMFHKFBO();
		AKPKJMNGFIE.GCFEBGHLIMB(LFILAFJIAPB.CFDAKNHGNAL(), LFILAFJIAPB.visualSlotId);
	}

	public void NHIOCJOCDKG()
	{
		ODLMHIBKLDP.materials[1].mainTexture = null;
		ODLMHIBKLDP.materials[0].SetTexture("MessageId", null);
		LJBKNMJBPEG.JBMBJPJGJFB(null);
		LJBKNMJBPEG.SetMatCapTexture(null);
		ODLMHIBKLDP.sharedMesh = null;
		LJBKNMJBPEG.FJDJPNPEAOC(null);
	}

	public void IACDKOAILCD(PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory LFILAFJIAPB)
	{
		AKPKJMNGFIE.HOPMMFHKFBO();
		AKPKJMNGFIE.AddAttachment(LFILAFJIAPB.PKODGDFFODG(), LFILAFJIAPB.visualSlotId);
	}

	public void BAICBGKMLIG()
	{
		ODLMHIBKLDP.materials[0].mainTexture = null;
		ODLMHIBKLDP.materials[1].SetTexture("Tutorial_Step_Complete", null);
		LJBKNMJBPEG.SetTexture(null);
		LJBKNMJBPEG.OCLOCHAODNM(null);
		ODLMHIBKLDP.sharedMesh = null;
		LJBKNMJBPEG.SetMesh(null);
	}

	private void IBMEDEPBOAK()
	{
		ODLMHIBKLDP.quality = ((Singleton<GameController>.instance.PEGCHNGBOAM() == (GameController.AEMPHGEIJNH)6) ? SkinQuality.Bone1 : ((SkinQuality)8));
	}

	private void MNLFDPJFIOL()
	{
		ODLMHIBKLDP.quality = ((Singleton<GameController>.instance.AFDJHMHONOH() == GameController.AEMPHGEIJNH.WaitingForResponse) ? SkinQuality.Bone1 : ((SkinQuality)5));
	}

	public void BFACJGODOJK(PlayerVisualCategoryCamos.PlayerVisualCamo PAFBOGDNAFF, int DFHAAIFFLOE)
	{
		Mesh mesh = PAFBOGDNAFF.KACGJBNNBPG(DFHAAIFFLOE);
		if (mesh != null)
		{
			DONGKPEBGFC.sharedMesh = mesh;
			DONGKPEBGFC.gameObject.SetActive(value: true);
		}
		else
		{
			DONGKPEBGFC.gameObject.SetActive(value: false);
		}
	}

	public void NOJBLAPJNBF(PlayerVisualCategoryCamos.PlayerVisualCamo PAFBOGDNAFF, int DFHAAIFFLOE)
	{
		Mesh mesh = PAFBOGDNAFF.KACGJBNNBPG(DFHAAIFFLOE);
		if (mesh != null)
		{
			DONGKPEBGFC.sharedMesh = mesh;
			DONGKPEBGFC.gameObject.SetActive(value: false);
		}
		else
		{
			DONGKPEBGFC.gameObject.SetActive(value: false);
		}
	}

	public void INCHOFKIBOI(PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory LFILAFJIAPB)
	{
		AKPKJMNGFIE.NMOADHMAAOE();
		AKPKJMNGFIE.GCFEBGHLIMB(LFILAFJIAPB.JGHFOKMMGME(), LFILAFJIAPB.visualSlotId);
	}

	public void KNMEFFFNIID(Material FJNJGHGMFND)
	{
		ODLMHIBKLDP.sharedMaterial = FJNJGHGMFND;
	}

	public void DIHHDKCMJLP(List<TechnologyVisualDefinition> NEEEJOHOOEH, bool OFICDODLPCK)
	{
		OOHCFBEKACK.gameObject.SetActive(value: false);
		if (NEEEJOHOOEH.Count > 0 && NEEEJOHOOEH[1] != null)
		{
			TechnologyVisualDefinition technologyVisualDefinition = NEEEJOHOOEH[0];
			ODLMHIBKLDP.materials[0].mainTexture = ((!OFICDODLPCK) ? technologyVisualDefinition.CDCEAGKFBPL() : technologyVisualDefinition.PNNPGAFLMMP());
			ODLMHIBKLDP.materials[1].SetTexture("JoinMatch_ServerConnect", Singleton<MatCapTextures>.instance.BINBIOPGNKL());
			AKHGKGCOGEN.MLGBHGMAKGC();
			foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh in technologyVisualDefinition.visualSlotMeshes)
			{
				if (visualSlotMesh.partRed != null && !OFICDODLPCK)
				{
					AKHGKGCOGEN.GCFEBGHLIMB(visualSlotMesh.partRed, visualSlotMesh.visualSlotId);
				}
				else if (visualSlotMesh.part != null)
				{
					AKHGKGCOGEN.AddAttachment(visualSlotMesh.part, visualSlotMesh.visualSlotId);
				}
			}
		}
		if (NEEEJOHOOEH.Count <= 0 || NEEEJOHOOEH[0] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition2 = NEEEJOHOOEH[0];
		LJBKNMJBPEG.MMJJJBJKHFL((!OFICDODLPCK) ? technologyVisualDefinition2.materialTetxureRed : technologyVisualDefinition2.PNNPGAFLMMP());
		LJBKNMJBPEG.OCLOCHAODNM(Singleton<MatCapTextures>.instance.GetMatCap());
		AKPKJMNGFIE.BMDAFFNPDOM();
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh2 in technologyVisualDefinition2.visualSlotMeshes)
		{
			if (visualSlotMesh2.partRed != null && !OFICDODLPCK)
			{
				AKPKJMNGFIE.AddAttachment(visualSlotMesh2.partRed, visualSlotMesh2.visualSlotId);
			}
			else if (visualSlotMesh2.part != null)
			{
				AKPKJMNGFIE.AddAttachment(visualSlotMesh2.part, visualSlotMesh2.visualSlotId);
			}
		}
	}

	private void FCHGHCPFOFC()
	{
		ODLMHIBKLDP.quality = ((Singleton<GameController>.instance.NOPCKHHDOMN() == (GameController.AEMPHGEIJNH)8) ? SkinQuality.Bone1 : ((SkinQuality)3));
	}

	public void DMNFLIBOPML(List<SoldierStyle> PFLHCDOHMBL)
	{
		AFBBPCBCOLC = UnityEngine.Random.Range(0, PFLHCDOHMBL.Count);
		ELHNDLNCLEB = PFLHCDOHMBL;
		SoldierStyle soldierStyle = PFLHCDOHMBL[AFBBPCBCOLC];
		SkinnedMeshTools.ChangeSkins(soldierStyle.CKKIMCJDLGD(), ODLMHIBKLDP);
		if (soldierStyle.helmetMaterials != null && soldierStyle.helmetMaterials.Count > 1)
		{
			LJBKNMJBPEG.SetMesh(soldierStyle.helmetMesh, soldierStyle.helmetMaterials);
		}
		else
		{
			LJBKNMJBPEG.MKHNALDNOFJ(soldierStyle.helmetMesh);
		}
	}

	public void AJKDDHHKBBO(PlayerVisualCategoryHelmets.PlayerVisualHelmet NILEPDCKFHN)
	{
		MeshFilter component = NILEPDCKFHN.ENKMNCFJBFA().GetComponent<MeshFilter>();
		LJBKNMJBPEG.FJDJPNPEAOC(component.sharedMesh);
		LJBKNMJBPEG.SetMaterials(NILEPDCKFHN.PKODGDFFODG().sharedMaterials);
	}

	public void CHIFPLFFKEI(PlayerVisualCategoryPowerBands.PlayerVisualPowerBand OPMNOMBCJLJ)
	{
		OOHCFBEKACK.gameObject.SetActive(OPMNOMBCJLJ.texture != null);
		OOHCFBEKACK.material.mainTexture = OPMNOMBCJLJ.texture;
	}

	public void KPLKGFJGADK(PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory LFILAFJIAPB)
	{
		AKPKJMNGFIE.HideAllAttachments();
		AKPKJMNGFIE.GCFEBGHLIMB(LFILAFJIAPB.ENKMNCFJBFA(), LFILAFJIAPB.visualSlotId);
	}

	public void DBEABEEAMMN(PlayerVisualCategoryCamos.PlayerVisualCamo PAFBOGDNAFF, int DFHAAIFFLOE)
	{
		Mesh mesh = PAFBOGDNAFF.GOAPCJMACAB(DFHAAIFFLOE);
		if (mesh != null)
		{
			DONGKPEBGFC.sharedMesh = mesh;
			DONGKPEBGFC.gameObject.SetActive(value: true);
		}
		else
		{
			DONGKPEBGFC.gameObject.SetActive(value: true);
		}
	}

	public void GEMKNCBEDEB(PlayerVisualCategoryPowerBands.PlayerVisualPowerBand OPMNOMBCJLJ)
	{
		OOHCFBEKACK.gameObject.SetActive(OPMNOMBCJLJ.texture != null);
		OOHCFBEKACK.material.mainTexture = OPMNOMBCJLJ.texture;
	}

	public void OLEBJCPJELE(PlayerVisualCategoryHelmets.PlayerVisualHelmet NILEPDCKFHN)
	{
		MeshFilter component = NILEPDCKFHN.IFLJJKAALLK().GetComponent<MeshFilter>();
		LJBKNMJBPEG.FJDJPNPEAOC(component.sharedMesh);
		LJBKNMJBPEG.SetMaterials(NILEPDCKFHN.IFLJJKAALLK().sharedMaterials);
	}

	private void LCHGOPCPPIB()
	{
		ODLMHIBKLDP.quality = ((Singleton<GameController>.instance.gameState != GameController.AEMPHGEIJNH.WaitingForResponse) ? SkinQuality.Bone4 : SkinQuality.Auto);
	}

	public void FLHJCAAFHKC()
	{
		ODLMHIBKLDP.materials[1].mainTexture = null;
		ODLMHIBKLDP.materials[1].SetTexture("Returning {0} isGoodPing: {1}", null);
		LJBKNMJBPEG.SetTexture(null);
		LJBKNMJBPEG.FBJIOHLJHNM(null);
		ODLMHIBKLDP.sharedMesh = null;
		LJBKNMJBPEG.MKHNALDNOFJ(null);
	}

	[SpecialName]
	public Material PEDKPENFCAG()
	{
		return ODLMHIBKLDP.materials[0];
	}

	[SpecialName]
	public Material LAEMFHIPKPI()
	{
		return ODLMHIBKLDP.materials[1];
	}

	[SpecialName]
	public Material IMMKJIEONDL()
	{
		return ODLMHIBKLDP.materials[1];
	}

	[SpecialName]
	public Material FGCMAABJLGD()
	{
		return ODLMHIBKLDP.materials[1];
	}

	public void FFDFHLOMECD(SkinnedMeshRenderer FGFGEJJADHE, Texture2D EBFDAICCJAK)
	{
		SkinnedMeshTools.ChangeSkins(FGFGEJJADHE, ODLMHIBKLDP);
		ODLMHIBKLDP.materials[1].mainTexture = EBFDAICCJAK;
		ODLMHIBKLDP.materials[0].SetTexture("S", Singleton<MatCapTextures>.instance.AAIFAPBKIMP());
		DONGKPEBGFC.GetComponent<MeshRenderer>().materials[0].mainTexture = EBFDAICCJAK;
	}

	private void OAHBEJNNNAB()
	{
		ODLMHIBKLDP.quality = ((Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.WaitingForResponse) ? SkinQuality.Bone1 : ((SkinQuality)3));
	}

	public void DJGOMOAJLPG(List<SoldierStyle> PFLHCDOHMBL)
	{
		AFBBPCBCOLC = UnityEngine.Random.Range(1, PFLHCDOHMBL.Count);
		ELHNDLNCLEB = PFLHCDOHMBL;
		SoldierStyle soldierStyle = PFLHCDOHMBL[AFBBPCBCOLC];
		SkinnedMeshTools.ChangeSkins(soldierStyle.JLENLGENPBK(), ODLMHIBKLDP);
		if (soldierStyle.helmetMaterials != null && soldierStyle.helmetMaterials.Count > 1)
		{
			LJBKNMJBPEG.SetMesh(soldierStyle.helmetMesh, soldierStyle.helmetMaterials);
		}
		else
		{
			LJBKNMJBPEG.FJDJPNPEAOC(soldierStyle.helmetMesh);
		}
	}

	public void IIMJAOLKLIG(Material FJNJGHGMFND)
	{
		ODLMHIBKLDP.sharedMaterial = FJNJGHGMFND;
	}

	public void LJDPGIHJDOM(PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory LFILAFJIAPB)
	{
		AKPKJMNGFIE.GOHNLIHKHED();
		AKPKJMNGFIE.AddAttachment(LFILAFJIAPB.MJAHFHDACEA(), LFILAFJIAPB.visualSlotId);
	}

	public void NIOJAMLKBNH(Material FJNJGHGMFND)
	{
		ODLMHIBKLDP.sharedMaterial = FJNJGHGMFND;
	}

	public void FCDJPFEGOHP(SkinnedMeshRenderer FGFGEJJADHE, Texture2D EBFDAICCJAK)
	{
		SkinnedMeshTools.ChangeSkins(FGFGEJJADHE, ODLMHIBKLDP);
		ODLMHIBKLDP.materials[0].mainTexture = EBFDAICCJAK;
		ODLMHIBKLDP.materials[1].SetTexture("customString", Singleton<MatCapTextures>.instance.NIAGPMCOJKK());
		DONGKPEBGFC.GetComponent<MeshRenderer>().materials[0].mainTexture = EBFDAICCJAK;
	}

	public void EIEEEEGHMEC(PlayerVisualCategoryCamos.PlayerVisualCamo PAFBOGDNAFF, int DFHAAIFFLOE)
	{
		Mesh mesh = PAFBOGDNAFF.HJLFDLBFMOI(DFHAAIFFLOE);
		if (mesh != null)
		{
			DONGKPEBGFC.sharedMesh = mesh;
			DONGKPEBGFC.gameObject.SetActive(value: true);
		}
		else
		{
			DONGKPEBGFC.gameObject.SetActive(value: true);
		}
	}

	public void JIKADKGLKML(PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory LFILAFJIAPB)
	{
		AKPKJMNGFIE.HideAllAttachments();
		AKPKJMNGFIE.AddAttachment(LFILAFJIAPB.MJAHFHDACEA(), LFILAFJIAPB.visualSlotId);
	}

	public void PILMIJNKFNB(List<SoldierStyle> PFLHCDOHMBL)
	{
		AFBBPCBCOLC = UnityEngine.Random.Range(1, PFLHCDOHMBL.Count);
		ELHNDLNCLEB = PFLHCDOHMBL;
		SoldierStyle soldierStyle = PFLHCDOHMBL[AFBBPCBCOLC];
		SkinnedMeshTools.ChangeSkins(soldierStyle.JLENLGENPBK(), ODLMHIBKLDP);
		if (soldierStyle.helmetMaterials != null && soldierStyle.helmetMaterials.Count > 0)
		{
			LJBKNMJBPEG.JINPGBKPGFH(soldierStyle.helmetMesh, soldierStyle.helmetMaterials);
		}
		else
		{
			LJBKNMJBPEG.SetMesh(soldierStyle.helmetMesh);
		}
	}

	public void BNCAKJMLJJP(List<SoldierStyle> PFLHCDOHMBL)
	{
		AFBBPCBCOLC = UnityEngine.Random.Range(0, PFLHCDOHMBL.Count);
		ELHNDLNCLEB = PFLHCDOHMBL;
		SoldierStyle soldierStyle = PFLHCDOHMBL[AFBBPCBCOLC];
		SkinnedMeshTools.ChangeSkins(soldierStyle.AFDGKLKADDE(), ODLMHIBKLDP);
		if (soldierStyle.helmetMaterials != null && soldierStyle.helmetMaterials.Count > 0)
		{
			LJBKNMJBPEG.SetMesh(soldierStyle.helmetMesh, soldierStyle.helmetMaterials);
		}
		else
		{
			LJBKNMJBPEG.SetMesh(soldierStyle.helmetMesh);
		}
	}

	public void OLLDFMAECAP(PlayerVisualCategoryCamos.PlayerVisualCamo PAFBOGDNAFF, int DFHAAIFFLOE)
	{
		Mesh mesh = PAFBOGDNAFF.KACGJBNNBPG(DFHAAIFFLOE);
		if (mesh != null)
		{
			DONGKPEBGFC.sharedMesh = mesh;
			DONGKPEBGFC.gameObject.SetActive(value: false);
		}
		else
		{
			DONGKPEBGFC.gameObject.SetActive(value: false);
		}
	}

	public void OCMOLNNBFOO(Material FJNJGHGMFND)
	{
		ODLMHIBKLDP.sharedMaterial = FJNJGHGMFND;
	}

	public void AMPBJNGFJCN(PlayerVisualCategoryPowerBands.PlayerVisualPowerBand OPMNOMBCJLJ)
	{
		OOHCFBEKACK.gameObject.SetActive(OPMNOMBCJLJ.texture != null);
		OOHCFBEKACK.material.mainTexture = OPMNOMBCJLJ.texture;
	}

	public void SetSoldierStyle(List<SoldierStyle> PFLHCDOHMBL)
	{
		AFBBPCBCOLC = UnityEngine.Random.Range(0, PFLHCDOHMBL.Count);
		ELHNDLNCLEB = PFLHCDOHMBL;
		SoldierStyle soldierStyle = PFLHCDOHMBL[AFBBPCBCOLC];
		SkinnedMeshTools.ChangeSkins(soldierStyle.modelMeshRenderer, ODLMHIBKLDP);
		if (soldierStyle.helmetMaterials != null && soldierStyle.helmetMaterials.Count > 0)
		{
			LJBKNMJBPEG.SetMesh(soldierStyle.helmetMesh, soldierStyle.helmetMaterials);
		}
		else
		{
			LJBKNMJBPEG.SetMesh(soldierStyle.helmetMesh);
		}
	}

	public void DDIENJDMHNI(PlayerVisualCategoryHelmets.PlayerVisualHelmet NILEPDCKFHN)
	{
		MeshFilter component = NILEPDCKFHN.IFLJJKAALLK().GetComponent<MeshFilter>();
		LJBKNMJBPEG.AOHALOBDMIL(component.sharedMesh);
		LJBKNMJBPEG.SetMaterials(NILEPDCKFHN.NNFALDBKIMK().sharedMaterials);
	}

	public void LMHJHCAJHAA(Material FJNJGHGMFND)
	{
		ODLMHIBKLDP.sharedMaterial = FJNJGHGMFND;
	}

	public void DBJNFMEODNG(PlayerVisualCategoryCamos.PlayerVisualCamo PAFBOGDNAFF, int DFHAAIFFLOE)
	{
		Mesh mesh = PAFBOGDNAFF.CELDDAMFEKK(DFHAAIFFLOE);
		if (mesh != null)
		{
			DONGKPEBGFC.sharedMesh = mesh;
			DONGKPEBGFC.gameObject.SetActive(value: false);
		}
		else
		{
			DONGKPEBGFC.gameObject.SetActive(value: true);
		}
	}

	public void BFAMLOFOGFN(PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory LFILAFJIAPB)
	{
		AKPKJMNGFIE.HideAllAttachments();
		AKPKJMNGFIE.AddAttachment(LFILAFJIAPB.ECOBDJDKCFF(), LFILAFJIAPB.visualSlotId);
	}

	public void JHEMILOKGJH(Material FJNJGHGMFND)
	{
		ODLMHIBKLDP.sharedMaterial = FJNJGHGMFND;
	}

	public void MFJKNMDFBOG(Material FJNJGHGMFND)
	{
		ODLMHIBKLDP.sharedMaterial = FJNJGHGMFND;
	}

	private void OnEnable()
	{
		ODLMHIBKLDP.quality = ((Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.Playing) ? SkinQuality.Bone1 : SkinQuality.Bone2);
	}

	public void LDFCPCBPLJF(SkinnedMeshRenderer FGFGEJJADHE, Texture2D EBFDAICCJAK)
	{
		SkinnedMeshTools.ChangeSkins(FGFGEJJADHE, ODLMHIBKLDP);
		ODLMHIBKLDP.materials[0].mainTexture = EBFDAICCJAK;
		ODLMHIBKLDP.materials[0].SetTexture("nextSquadWars", Singleton<MatCapTextures>.instance.BBFAKOCKHHA());
		DONGKPEBGFC.GetComponent<MeshRenderer>().materials[0].mainTexture = EBFDAICCJAK;
	}

	public void JJIFIIGONEO(Material FJNJGHGMFND)
	{
		ODLMHIBKLDP.sharedMaterial = FJNJGHGMFND;
	}

	private void DGJLIHKOHHC()
	{
		ODLMHIBKLDP.quality = ((Singleton<GameController>.instance.PEGCHNGBOAM() != GameController.AEMPHGEIJNH.Playing) ? ((SkinQuality)6) : SkinQuality.Auto);
	}

	public void BPJFMLIAHME(Material FJNJGHGMFND)
	{
		ODLMHIBKLDP.sharedMaterial = FJNJGHGMFND;
	}

	public void FKANJHJKPDO(Material FJNJGHGMFND)
	{
		ODLMHIBKLDP.sharedMaterial = FJNJGHGMFND;
	}

	public void ChangePowerBand(PlayerVisualCategoryPowerBands.PlayerVisualPowerBand OPMNOMBCJLJ)
	{
		OOHCFBEKACK.gameObject.SetActive(OPMNOMBCJLJ.texture != null);
		OOHCFBEKACK.material.mainTexture = OPMNOMBCJLJ.texture;
	}

	public void OGMIPACFIBF(PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory LFILAFJIAPB)
	{
		AKPKJMNGFIE.HOPMMFHKFBO();
		AKPKJMNGFIE.AddAttachment(LFILAFJIAPB.JGHFOKMMGME(), LFILAFJIAPB.visualSlotId);
	}

	public void BJMGLJFFPID()
	{
		ODLMHIBKLDP.materials[0].mainTexture = null;
		ODLMHIBKLDP.materials[1].SetTexture("GameController.LoadAndStartNewMap - DONE", null);
		LJBKNMJBPEG.SetTexture(null);
		LJBKNMJBPEG.OCLOCHAODNM(null);
		ODLMHIBKLDP.sharedMesh = null;
		LJBKNMJBPEG.MKHNALDNOFJ(null);
	}

	public void PNHIEAJLNAP(Material FJNJGHGMFND)
	{
		ODLMHIBKLDP.sharedMaterial = FJNJGHGMFND;
	}

	public void NullTexturesAndMeshes()
	{
		ODLMHIBKLDP.materials[0].mainTexture = null;
		ODLMHIBKLDP.materials[0].SetTexture("_MatCap", null);
		LJBKNMJBPEG.SetTexture(null);
		LJBKNMJBPEG.SetMatCapTexture(null);
		ODLMHIBKLDP.sharedMesh = null;
		LJBKNMJBPEG.SetMesh(null);
	}

	private void OMFEMBPCLFK()
	{
		ODLMHIBKLDP.quality = ((Singleton<GameController>.instance.PEGCHNGBOAM() != (GameController.AEMPHGEIJNH)7) ? SkinQuality.Bone1 : SkinQuality.Auto);
	}

	public void PEBHGKGKHHO(PlayerVisualCategoryCamos.PlayerVisualCamo PAFBOGDNAFF, int DFHAAIFFLOE)
	{
		Mesh mesh = PAFBOGDNAFF.ECENCKKCOMD(DFHAAIFFLOE);
		if (mesh != null)
		{
			DONGKPEBGFC.sharedMesh = mesh;
			DONGKPEBGFC.gameObject.SetActive(value: true);
		}
		else
		{
			DONGKPEBGFC.gameObject.SetActive(value: false);
		}
	}

	public void ChangeHelmetAttachment(PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory LFILAFJIAPB)
	{
		AKPKJMNGFIE.HideAllAttachments();
		AKPKJMNGFIE.AddAttachment(LFILAFJIAPB.CFDAKNHGNAL(), LFILAFJIAPB.visualSlotId);
	}

	public void ChangeHelmet(PlayerVisualCategoryHelmets.PlayerVisualHelmet NILEPDCKFHN)
	{
		MeshFilter component = NILEPDCKFHN.CFDAKNHGNAL().GetComponent<MeshFilter>();
		LJBKNMJBPEG.SetMesh(component.sharedMesh);
		LJBKNMJBPEG.SetMaterials(NILEPDCKFHN.CFDAKNHGNAL().sharedMaterials);
	}

	public void SetSoldierVisual(List<TechnologyVisualDefinition> NEEEJOHOOEH, bool OFICDODLPCK)
	{
		OOHCFBEKACK.gameObject.SetActive(value: false);
		if (NEEEJOHOOEH.Count > 0 && NEEEJOHOOEH[0] != null)
		{
			TechnologyVisualDefinition technologyVisualDefinition = NEEEJOHOOEH[0];
			ODLMHIBKLDP.materials[0].mainTexture = ((!OFICDODLPCK) ? technologyVisualDefinition.materialTetxureRed : technologyVisualDefinition.materialTetxureBlue);
			ODLMHIBKLDP.materials[0].SetTexture("_MatCap", Singleton<MatCapTextures>.instance.GetMatCap());
			AKHGKGCOGEN.HideAllAttachments();
			foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh in technologyVisualDefinition.visualSlotMeshes)
			{
				if (visualSlotMesh.partRed != null && !OFICDODLPCK)
				{
					AKHGKGCOGEN.AddAttachment(visualSlotMesh.partRed, visualSlotMesh.visualSlotId);
				}
				else if (visualSlotMesh.part != null)
				{
					AKHGKGCOGEN.AddAttachment(visualSlotMesh.part, visualSlotMesh.visualSlotId);
				}
			}
		}
		if (NEEEJOHOOEH.Count <= 1 || NEEEJOHOOEH[1] == null)
		{
			return;
		}
		TechnologyVisualDefinition technologyVisualDefinition2 = NEEEJOHOOEH[1];
		LJBKNMJBPEG.SetTexture((!OFICDODLPCK) ? technologyVisualDefinition2.materialTetxureRed : technologyVisualDefinition2.materialTetxureBlue);
		LJBKNMJBPEG.SetMatCapTexture(Singleton<MatCapTextures>.instance.GetMatCap());
		AKPKJMNGFIE.HideAllAttachments();
		foreach (UpgradeSlots.VisualSlotMesh visualSlotMesh2 in technologyVisualDefinition2.visualSlotMeshes)
		{
			if (visualSlotMesh2.partRed != null && !OFICDODLPCK)
			{
				AKPKJMNGFIE.AddAttachment(visualSlotMesh2.partRed, visualSlotMesh2.visualSlotId);
			}
			else if (visualSlotMesh2.part != null)
			{
				AKPKJMNGFIE.AddAttachment(visualSlotMesh2.part, visualSlotMesh2.visualSlotId);
			}
		}
	}

	public void MJJEKEFONAL(PlayerVisualCategoryPowerBands.PlayerVisualPowerBand OPMNOMBCJLJ)
	{
		OOHCFBEKACK.gameObject.SetActive(OPMNOMBCJLJ.texture != null);
		OOHCFBEKACK.material.mainTexture = OPMNOMBCJLJ.texture;
	}

	public void DHAOLBAODDD(PlayerVisualCategoryPowerBands.PlayerVisualPowerBand OPMNOMBCJLJ)
	{
		OOHCFBEKACK.gameObject.SetActive(OPMNOMBCJLJ.texture != null);
		OOHCFBEKACK.material.mainTexture = OPMNOMBCJLJ.texture;
	}

	public void ChangeHair(PlayerVisualCategoryCamos.PlayerVisualCamo PAFBOGDNAFF, int DFHAAIFFLOE)
	{
		Mesh mesh = PAFBOGDNAFF.GOAPCJMACAB(DFHAAIFFLOE);
		if (mesh != null)
		{
			DONGKPEBGFC.sharedMesh = mesh;
			DONGKPEBGFC.gameObject.SetActive(value: true);
		}
		else
		{
			DONGKPEBGFC.gameObject.SetActive(value: false);
		}
	}

	private void NKKPELCDHHC()
	{
		ODLMHIBKLDP.quality = ((Singleton<GameController>.instance.AFDJHMHONOH() != GameController.AEMPHGEIJNH.Playing) ? SkinQuality.Bone4 : SkinQuality.Auto);
	}

	public void KDBBPJAHDFP(PlayerVisualCategoryPowerBands.PlayerVisualPowerBand OPMNOMBCJLJ)
	{
		OOHCFBEKACK.gameObject.SetActive(OPMNOMBCJLJ.texture != null);
		OOHCFBEKACK.material.mainTexture = OPMNOMBCJLJ.texture;
	}

	public void LJNGFJFDIHO(PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory LFILAFJIAPB)
	{
		AKPKJMNGFIE.MLGBHGMAKGC();
		AKPKJMNGFIE.AddAttachment(LFILAFJIAPB.ECOBDJDKCFF(), LFILAFJIAPB.visualSlotId);
	}

	public void DDNILFBJDFI(SkinnedMeshRenderer FGFGEJJADHE, Texture2D EBFDAICCJAK)
	{
		SkinnedMeshTools.ChangeSkins(FGFGEJJADHE, ODLMHIBKLDP);
		ODLMHIBKLDP.materials[1].mainTexture = EBFDAICCJAK;
		ODLMHIBKLDP.materials[1].SetTexture("ID_XP", Singleton<MatCapTextures>.instance.DAFLADHIBIF());
		DONGKPEBGFC.GetComponent<MeshRenderer>().materials[0].mainTexture = EBFDAICCJAK;
	}

	public void ChangeCamo(SkinnedMeshRenderer FGFGEJJADHE, Texture2D EBFDAICCJAK)
	{
		SkinnedMeshTools.ChangeSkins(FGFGEJJADHE, ODLMHIBKLDP);
		ODLMHIBKLDP.materials[0].mainTexture = EBFDAICCJAK;
		ODLMHIBKLDP.materials[0].SetTexture("_MatCap", Singleton<MatCapTextures>.instance.GetMatCap());
		DONGKPEBGFC.GetComponent<MeshRenderer>().materials[0].mainTexture = EBFDAICCJAK;
	}

	public void IDKFGBKNCKF(PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory LFILAFJIAPB)
	{
		AKPKJMNGFIE.MLGBHGMAKGC();
		AKPKJMNGFIE.AddAttachment(LFILAFJIAPB.ECOBDJDKCFF(), LFILAFJIAPB.visualSlotId);
	}

	public void EDBKLEIFNDP(PlayerVisualCategoryPowerBands.PlayerVisualPowerBand OPMNOMBCJLJ)
	{
		OOHCFBEKACK.gameObject.SetActive(OPMNOMBCJLJ.texture != null);
		OOHCFBEKACK.material.mainTexture = OPMNOMBCJLJ.texture;
	}

	public void PLLPCOLEDHL(Material FJNJGHGMFND)
	{
		ODLMHIBKLDP.sharedMaterial = FJNJGHGMFND;
	}
}
