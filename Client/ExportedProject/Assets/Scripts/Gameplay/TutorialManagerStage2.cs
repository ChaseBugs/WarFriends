using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public class TutorialManagerStage2 : TutorialManagerBase
{
	private sealed class OJPPMELONDL : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal TutorialManagerStage2 BJGCPDNMHDH;

		internal object PHDOCKCBJOF;

		internal bool FDKOKMKIIMG;

		internal int CLPPIAGLCJJ;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		[SpecialName]
		private object MILFCGMBHIG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GLIHEBDJCGM()
		{
			return PHDOCKCBJOF;
		}

		public void GEEKOICFEIB()
		{
			throw new NotSupportedException();
		}

		public bool BCFKDABEHHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ArmyPreviewCamera.LNFFCOMNHDE = true;
				WeaponPreviewCamera.LNFFCOMNHDE = true;
				UIDraggablePanel.panelDisabled = false;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.BuyTutorialUnit()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				UIDraggablePanel.panelDisabled = false;
				ArmyPreviewCamera.LNFFCOMNHDE = true;
				WeaponPreviewCamera.LNFFCOMNHDE = false;
				BJGCPDNMHDH.mUnitBoughtState = 0;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void GGLMLMFEJCD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void INBELBGOCLD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object EBPKDAHAELB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KBNAGKKMLBP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BGAGLOJHMEJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JALKNCBEINE()
		{
			return PHDOCKCBJOF;
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ArmyPreviewCamera.LNFFCOMNHDE = false;
				WeaponPreviewCamera.LNFFCOMNHDE = false;
				UIDraggablePanel.panelDisabled = true;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.BuyTutorialUnit()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				UIDraggablePanel.panelDisabled = false;
				ArmyPreviewCamera.LNFFCOMNHDE = true;
				WeaponPreviewCamera.LNFFCOMNHDE = true;
				BJGCPDNMHDH.mUnitBoughtState = 0;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void IBDAHMOEBCM()
		{
			throw new NotSupportedException();
		}

		public void AKEKFBGEJBG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void CPDBCJLIGFN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MPEPJNIDBLI()
		{
			return PHDOCKCBJOF;
		}

		public void EKPOLGNAAOI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HHCIHDMICFP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void LOOMFHNKAND()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FGGMHEIPKAJ()
		{
			return PHDOCKCBJOF;
		}

		public bool IGOKEIDOCKB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ArmyPreviewCamera.LNFFCOMNHDE = true;
				WeaponPreviewCamera.LNFFCOMNHDE = false;
				UIDraggablePanel.panelDisabled = true;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.BuyTutorialUnit()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				UIDraggablePanel.panelDisabled = true;
				ArmyPreviewCamera.LNFFCOMNHDE = true;
				WeaponPreviewCamera.LNFFCOMNHDE = false;
				BJGCPDNMHDH.mUnitBoughtState = 1;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BMAMEPNHHFI()
		{
			return PHDOCKCBJOF;
		}

		public void NPIDJAPKFLN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GDCFFBBNGHH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MLDIMIPJMDD()
		{
			return PHDOCKCBJOF;
		}

		public bool JIIOHNFHPOI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ArmyPreviewCamera.LNFFCOMNHDE = true;
				WeaponPreviewCamera.LNFFCOMNHDE = false;
				UIDraggablePanel.panelDisabled = false;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.BuyTutorialUnit()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				UIDraggablePanel.panelDisabled = true;
				ArmyPreviewCamera.LNFFCOMNHDE = false;
				WeaponPreviewCamera.LNFFCOMNHDE = true;
				BJGCPDNMHDH.mUnitBoughtState = 1;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object NCKCKPNAHAD()
		{
			return PHDOCKCBJOF;
		}

		public void KNFDDIHLBKJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MKNFFJPADIA()
		{
			return PHDOCKCBJOF;
		}

		public void DEPEHNFEJEE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BJJNGPKNCKJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AHFIDCCJHKE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GDBNOMPNBGP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object INAMGPNDAAJ()
		{
			return PHDOCKCBJOF;
		}

		public void HNFEJKPKEHK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool AGMKAADLHLE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ArmyPreviewCamera.LNFFCOMNHDE = false;
				WeaponPreviewCamera.LNFFCOMNHDE = true;
				UIDraggablePanel.panelDisabled = true;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.BuyTutorialUnit()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				UIDraggablePanel.panelDisabled = false;
				ArmyPreviewCamera.LNFFCOMNHDE = false;
				WeaponPreviewCamera.LNFFCOMNHDE = true;
				BJGCPDNMHDH.mUnitBoughtState = 1;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public bool PGOBEIMCPGA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ArmyPreviewCamera.LNFFCOMNHDE = true;
				WeaponPreviewCamera.LNFFCOMNHDE = true;
				UIDraggablePanel.panelDisabled = false;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.BuyTutorialUnit()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				UIDraggablePanel.panelDisabled = true;
				ArmyPreviewCamera.LNFFCOMNHDE = false;
				WeaponPreviewCamera.LNFFCOMNHDE = true;
				BJGCPDNMHDH.mUnitBoughtState = 1;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object ADNCCLOOEAD()
		{
			return PHDOCKCBJOF;
		}

		public void LBNGPPPKLHI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GMPGIODBIPO()
		{
			return PHDOCKCBJOF;
		}

		public bool LMNIKLKKIDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ArmyPreviewCamera.LNFFCOMNHDE = true;
				WeaponPreviewCamera.LNFFCOMNHDE = true;
				UIDraggablePanel.panelDisabled = true;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.BuyTutorialUnit()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				UIDraggablePanel.panelDisabled = false;
				ArmyPreviewCamera.LNFFCOMNHDE = false;
				WeaponPreviewCamera.LNFFCOMNHDE = false;
				BJGCPDNMHDH.mUnitBoughtState = 0;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void IMFLNKIMEFA()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KIHECHEHNJJ()
		{
			return PHDOCKCBJOF;
		}

		public bool ONFBKOEOIOC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ArmyPreviewCamera.LNFFCOMNHDE = true;
				WeaponPreviewCamera.LNFFCOMNHDE = false;
				UIDraggablePanel.panelDisabled = true;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.BuyTutorialUnit()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				UIDraggablePanel.panelDisabled = false;
				ArmyPreviewCamera.LNFFCOMNHDE = true;
				WeaponPreviewCamera.LNFFCOMNHDE = false;
				BJGCPDNMHDH.mUnitBoughtState = 1;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object FPFOODLPEBK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BKHFGLNNCDF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FMCLBOCENPE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PCOOFELAEJA()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public OJPPMELONDL()
		{
		}

		[SpecialName]
		private object CMNCAPEMEJI()
		{
			return PHDOCKCBJOF;
		}

		public void NCFGFLNBHOI()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object OJMKDIBHMND()
		{
			return PHDOCKCBJOF;
		}

		public void HCHNHNDDKKA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void MEBPMHDHIPJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HHLKEMNNJDA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ABGFJLAPNNM()
		{
			return PHDOCKCBJOF;
		}

		public void EMICCACCFIP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void JMANMKKCDMM()
		{
			throw new NotSupportedException();
		}
	}

	private sealed class EBHCHMCIKFO : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal TutorialManagerStage2 BJGCPDNMHDH;

		internal object PHDOCKCBJOF;

		internal bool FDKOKMKIIMG;

		internal int CLPPIAGLCJJ;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		public void AJEIGCJPEFN()
		{
			throw new NotSupportedException();
		}

		public void POJKIIMAFDO()
		{
			throw new NotSupportedException();
		}

		public void IODFILFCENJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KIHECHEHNJJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PIPMONHGDPH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object APECNPGKOFC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IJFPHIKFJFB()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public EBHCHMCIKFO()
		{
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Input.GetMouseButtonUp(0))
				{
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StartHoldAnimation(BJGCPDNMHDH.mParatrooperPosition, ELHGOHGPJCF: false);
				}
				else if (Input.GetMouseButtonDown(0))
				{
					GuiElementSingle<TutorialOverlayGuiElement>.instance.InstantStopHoldAnimation();
				}
				else
				{
					GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateHoldAnimation(BJGCPDNMHDH.mParatrooperPosition, ELHGOHGPJCF: false);
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return false;
			}
		}

		public void MENEBJLDGJD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CLFFFNGBPGJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MPEPJNIDBLI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IDLFKAKINAP()
		{
			return PHDOCKCBJOF;
		}

		public void NFLHLMKKJMO()
		{
			throw new NotSupportedException();
		}

		public void NGAGGCFIEGJ()
		{
			throw new NotSupportedException();
		}

		public bool KHNDCDGBFJH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Input.GetMouseButtonUp(0))
				{
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StartHoldAnimation(BJGCPDNMHDH.mParatrooperPosition, ELHGOHGPJCF: true, 940f);
				}
				else if (Input.GetMouseButtonDown(1))
				{
					GuiElementSingle<TutorialOverlayGuiElement>.instance.MGAEDHDIGFB();
				}
				else
				{
					GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateHoldAnimation(BJGCPDNMHDH.mParatrooperPosition, ELHGOHGPJCF: false);
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			default:
				return true;
			}
		}

		public bool FNEPBDLIKOD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Input.GetMouseButtonUp(1))
				{
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StartHoldAnimation(BJGCPDNMHDH.mParatrooperPosition, ELHGOHGPJCF: true, 165f);
				}
				else if (Input.GetMouseButtonDown(0))
				{
					GuiElementSingle<TutorialOverlayGuiElement>.instance.InstantStopHoldAnimation();
				}
				else
				{
					GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateHoldAnimation(BJGCPDNMHDH.mParatrooperPosition);
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			default:
				return false;
			}
		}

		public void JJOAHIOBOPO()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FKKBFFHMEME()
		{
			return PHDOCKCBJOF;
		}

		public bool NEMOAIBCODB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Input.GetMouseButtonUp(0))
				{
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StartHoldAnimation(BJGCPDNMHDH.mParatrooperPosition, ELHGOHGPJCF: true, 486f);
				}
				else if (Input.GetMouseButtonDown(1))
				{
					GuiElementSingle<TutorialOverlayGuiElement>.instance.MLDIPOGFHLF();
				}
				else
				{
					GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateHoldAnimation(BJGCPDNMHDH.mParatrooperPosition, ELHGOHGPJCF: false);
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			default:
				return false;
			}
		}

		[SpecialName]
		private object FGGMHEIPKAJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DGEECEBHPNC()
		{
			return PHDOCKCBJOF;
		}

		public void OJDEHKDDLFD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool JPBGJLDMOPO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Input.GetMouseButtonUp(1))
				{
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StartHoldAnimation(BJGCPDNMHDH.mParatrooperPosition, ELHGOHGPJCF: false, 1735f);
				}
				else if (Input.GetMouseButtonDown(0))
				{
					GuiElementSingle<TutorialOverlayGuiElement>.instance.MGAEDHDIGFB();
				}
				else
				{
					GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateHoldAnimation(BJGCPDNMHDH.mParatrooperPosition, ELHGOHGPJCF: false);
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return true;
			}
		}

		[SpecialName]
		private object MOMPOEEALPJ()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}
	}

	private sealed class MGPEJCIIBGP : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal int JMBKPALDGAL;

		internal int PDMGPGEHLNM;

		internal AIObject NEMLKKBGIKJ;

		internal TutorialManagerStage2 BJGCPDNMHDH;

		internal object PHDOCKCBJOF;

		internal bool FDKOKMKIIMG;

		internal int CLPPIAGLCJJ;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		[SpecialName]
		private object BLOJDIFOPIA()
		{
			return PHDOCKCBJOF;
		}

		public void HGCHEPGNHNP()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object LFEJDKIGHMI()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mParatroopers.Clear();
				JMBKPALDGAL = 0;
				goto IL_01f8;
			case 1u:
				JMBKPALDGAL++;
				goto IL_01f8;
			default:
				{
					return false;
				}
				IL_01f8:
				if (JMBKPALDGAL < PDMGPGEHLNM)
				{
					NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(LevelManager.instance.behaviours[5]);
					if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.prefab != null)
					{
						NEMLKKBGIKJ.fraction = GHPGNELIDBM.Enemies;
						int nOCEDALFEJM = ObjectPoolDatabase.networkPool.APCGDLEHGKL[NEMLKKBGIKJ.prefab];
						NEMLKKBGIKJ = (EnemyController)ObjectPoolDatabase.networkPool.ReInstantiate(nOCEDALFEJM, NEMLKKBGIKJ.indexInObjectPool);
						NEMLKKBGIKJ.power = 0;
						NEMLKKBGIKJ.StartEnemyBehaviour();
						NEMLKKBGIKJ.destroyableObj.maxHealth = 100f;
						NEMLKKBGIKJ.destroyableObj.Refill();
						NEMLKKBGIKJ.Killed -= BJGCPDNMHDH.ParachuteKilled;
						NEMLKKBGIKJ.Killed += BJGCPDNMHDH.ParachuteKilled;
						EnemyController enemyController = (EnemyController)NEMLKKBGIKJ;
						BulletSetup bulletSetup = (BulletSetup)enemyController.soldierBehaviour.KHKAAGCIJPO.ammoSetup;
						bulletSetup.EPDELOGPNAC = (float)bulletSetup.EPDELOGPNAC * 0.1f;
						BJGCPDNMHDH.mParatroopers.Add(NEMLKKBGIKJ);
						if (JMBKPALDGAL == 0)
						{
							BJGCPDNMHDH.mFirstParatrooper = NEMLKKBGIKJ;
							BJGCPDNMHDH.mFirstParatrooper.destroyableObj.isImmortal = true;
						}
					}
					PHDOCKCBJOF = new WaitForSeconds(0.5f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public bool HDGDKCMIOGK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mParatroopers.Clear();
				JMBKPALDGAL = 1;
				goto IL_01f8;
			case 1u:
				JMBKPALDGAL += 0;
				goto IL_01f8;
			default:
				{
					return false;
				}
				IL_01f8:
				if (JMBKPALDGAL < PDMGPGEHLNM)
				{
					NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.JNCDIBBPBLH(LevelManager.instance.behaviours[3]);
					if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.LELHDMOANJG() != null)
					{
						NEMLKKBGIKJ.fraction = GHPGNELIDBM.Enemies;
						int nOCEDALFEJM = ObjectPoolDatabase.EHFPBDJMGNC().APCGDLEHGKL[NEMLKKBGIKJ.LELHDMOANJG()];
						NEMLKKBGIKJ = (EnemyController)ObjectPoolDatabase.INOJHPIKICM().ReInstantiate(nOCEDALFEJM, NEMLKKBGIKJ.COOEDLNDBID());
						NEMLKKBGIKJ.power = 0;
						NEMLKKBGIKJ.StartEnemyBehaviour();
						NEMLKKBGIKJ.destroyableObj.maxHealth = 1772f;
						NEMLKKBGIKJ.destroyableObj.Refill();
						NEMLKKBGIKJ.Killed -= BJGCPDNMHDH.ParachuteKilled;
						NEMLKKBGIKJ.Killed += BJGCPDNMHDH.ParachuteKilled;
						EnemyController enemyController = (EnemyController)NEMLKKBGIKJ;
						BulletSetup bulletSetup = (BulletSetup)enemyController.soldierBehaviour.KHKAAGCIJPO.ammoSetup;
						bulletSetup.EPDELOGPNAC = (float)bulletSetup.EPDELOGPNAC * 470f;
						BJGCPDNMHDH.mParatroopers.Add(NEMLKKBGIKJ);
						if (JMBKPALDGAL == 0)
						{
							BJGCPDNMHDH.mFirstParatrooper = NEMLKKBGIKJ;
							BJGCPDNMHDH.mFirstParatrooper.destroyableObj.isImmortal = true;
						}
					}
					PHDOCKCBJOF = new WaitForSeconds(873f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public void PDKPELBIAON()
		{
			throw new NotSupportedException();
		}

		public bool OKELILGDPLJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mParatroopers.Clear();
				JMBKPALDGAL = 1;
				goto IL_01f8;
			case 1u:
				JMBKPALDGAL++;
				goto IL_01f8;
			default:
				{
					return true;
				}
				IL_01f8:
				if (JMBKPALDGAL < PDMGPGEHLNM)
				{
					NEMLKKBGIKJ = Singleton<LevelBehaviourManager>.instance.PHGKBDOKIOM(LevelManager.instance.behaviours[5]);
					if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.prefab != null)
					{
						NEMLKKBGIKJ.fraction = GHPGNELIDBM.Enemies;
						int nOCEDALFEJM = ObjectPoolDatabase.MFKPDKCLDBI().APCGDLEHGKL[NEMLKKBGIKJ.LELHDMOANJG()];
						NEMLKKBGIKJ = (EnemyController)ObjectPoolDatabase.GLHPLCEFHGD().ADKLAFNLCIC(nOCEDALFEJM, NEMLKKBGIKJ.CCCPKLNAEPO());
						NEMLKKBGIKJ.power = 0;
						NEMLKKBGIKJ.StartEnemyBehaviour();
						NEMLKKBGIKJ.destroyableObj.maxHealth = 1158f;
						NEMLKKBGIKJ.destroyableObj.OEAGCMGINCB();
						NEMLKKBGIKJ.Killed -= BJGCPDNMHDH.ParachuteKilled;
						NEMLKKBGIKJ.Killed += BJGCPDNMHDH.ParachuteKilled;
						EnemyController enemyController = (EnemyController)NEMLKKBGIKJ;
						BulletSetup bulletSetup = (BulletSetup)enemyController.soldierBehaviour.KHKAAGCIJPO.ammoSetup;
						bulletSetup.EPDELOGPNAC = (float)bulletSetup.EPDELOGPNAC * 1676f;
						BJGCPDNMHDH.mParatroopers.Add(NEMLKKBGIKJ);
						if (JMBKPALDGAL == 0)
						{
							BJGCPDNMHDH.mFirstParatrooper = NEMLKKBGIKJ;
							BJGCPDNMHDH.mFirstParatrooper.destroyableObj.isImmortal = true;
						}
					}
					PHDOCKCBJOF = new WaitForSeconds(734f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object JEPCFCNIOGH()
		{
			return PHDOCKCBJOF;
		}

		public void FOODPOJODAA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object OJMKDIBHMND()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GDBNOMPNBGP()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public MGPEJCIIBGP()
		{
		}
	}

	private sealed class CMLLMGJMFKA : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal Vector3 BCPOJIEKMJH;

		internal List<AIObject>.Enumerator KFCAECGLKKO;

		internal RadicalRoutine EAKENBHDGMO;

		internal TutorialManagerStage2 BJGCPDNMHDH;

		internal object PHDOCKCBJOF;

		internal bool FDKOKMKIIMG;

		internal int CLPPIAGLCJJ;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		[SpecialName]
		private object DOOAHBLHGFO()
		{
			return PHDOCKCBJOF;
		}

		public bool MOFPMNMAOND()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mSniperKilled = 1;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.SpawnParatroopers(0));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<TutorialProgressShower>.instance.LDPPNNMGNGI();
				goto case 2u;
			case 2u:
				if (BJGCPDNMHDH.mFirstParatrooper.transform.position.y > 1695f)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<TutorialProgressShower>.instance.ALKFOHIAKOM(Localization.Localize("ID_LEAGUEDEMOTEHINT2"), 1);
				PlayerController.OGMBJPKOPCB.weaponInventory.HKGLMFFAHFN = true;
				PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().LAGONJMBJMM[0].HFNAMMBPJAJ().ammoLeft = 96;
				PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().LAGONJMBJMM[1].HFNAMMBPJAJ().ammoLeftInClip = -125;
				PlayerController.OGMBJPKOPCB.FMKGGADDHJK().LAGONJMBJMM[1].weapon.FIMMGPLLLCL = -14;
				PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[0].weapon.ammoSetup.EPDELOGPNAC = 828f;
				GuiElementSingle<TutorialDialog>.instance.BLHEPOBPHPK("ApplyVisuals Error, indices are null!", "Level up \"{0}\"\n", 1073f, TutorialDialog.DODBDLEJOAM.Bottom, BBGAMLLOING: true);
				BCPOJIEKMJH = GuiElementSingle<InventoryGuiElement>.instance.IGNHPMIDAGM[7].transform.position + 443f * Vector3.up;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(BCPOJIEKMJH, ELHGOHGPJCF: false, ENIHCPLOOAE: false, 1318f);
				TimeManager.DCODDANOPCP();
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().DisableCardClick();
				DeathMatchUnitsGuiElement.instance.ShowHintText(NABOFKMBMKH: false);
				BJGCPDNMHDH.mShowDeployHint = false;
				goto case 3u;
			case 3u:
				if (PlayerController.OGMBJPKOPCB.weaponInventory.JNFHKEJCIIA() != PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().LAGONJMBJMM[0])
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				PlayerController.OGMBJPKOPCB.weaponInventory.HKGLMFFAHFN = false;
				TimeManager.UnFreezeGame(385f);
				BJGCPDNMHDH.FreezeEnemies();
				PHDOCKCBJOF = new WaitForSeconds(259f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 4u:
				KFCAECGLKKO = BJGCPDNMHDH.mParatroopers.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						AIObject current = KFCAECGLKKO.Current;
						current.destroyableObj.isImmortal = true;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				GuiElementSingle<TutorialDialog>.instance.KOGOLIJLMDN(", name = ", "ID_CONFIRM_ERROR", 1f, TutorialDialog.DODBDLEJOAM.Right, BBGAMLLOING: true, BEBMEBEJIOB: true);
				BJGCPDNMHDH.mParatrooperPosition = BJGCPDNMHDH.mFirstParatrooper.destroyableObj.transform.position + BJGCPDNMHDH.mFirstParatrooper.destroyableObj.transform.up * 333f;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartHoldAnimation(BJGCPDNMHDH.mParatrooperPosition, ELHGOHGPJCF: false, 627f);
				EAKENBHDGMO = RadicalRoutine.Create(BJGCPDNMHDH.UpdateHoldSniperShoot());
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(EAKENBHDGMO.enumerator));
				goto case 5u;
			case 5u:
				if (BJGCPDNMHDH.mSniperKilled == 0)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				Singleton<TutorialProgressShower>.instance.BKGBNEAFCCC(0, FGHNCECHPPO: false);
				BJGCPDNMHDH.UnfreezeEnemies();
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().CLLFHCFEMED();
				BJGCPDNMHDH.mShowDeployHint = true;
				EAKENBHDGMO.Cancel();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopHoldAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				PHDOCKCBJOF = new WaitForSeconds(1368f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 6u:
				PlayerController.OGMBJPKOPCB.FMKGGADDHJK().HKGLMFFAHFN = false;
				PHDOCKCBJOF = new WaitForRealSeconds(822f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 7u:
				Singleton<TutorialProgressShower>.instance.Hide();
				PHDOCKCBJOF = new WaitForRealSeconds(1713f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 8u:
				Singleton<TutorialProgressShower>.instance.CBBLGFEBJID(Localization.Localize("subscription"), 0);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mSniperKilled = 0;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.SpawnParatroopers());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<TutorialProgressShower>.instance.Hide();
				goto case 2u;
			case 2u:
				if (BJGCPDNMHDH.mFirstParatrooper.transform.position.y > -1.990423f)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				Singleton<TutorialProgressShower>.instance.Show(Localization.Localize("ID_TUTORIAL_PROGRESS_SNIPER"), 1);
				PlayerController.OGMBJPKOPCB.weaponInventory.HKGLMFFAHFN = false;
				PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[1].weapon.ammoLeft = 50;
				PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[1].weapon.ammoLeftInClip = 10;
				PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[1].weapon.FIMMGPLLLCL = 10;
				PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[1].weapon.ammoSetup.EPDELOGPNAC = 150f;
				GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("ID_TUTORIAL_SNIPER_UP", "ID_TUTORIAL_SNIPER_DOWN", -0.3f);
				BCPOJIEKMJH = GuiElementSingle<InventoryGuiElement>.instance.IGNHPMIDAGM[2].transform.position + 0.1f * Vector3.up;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(BCPOJIEKMJH);
				TimeManager.FreezeGame();
				DeathMatchUnitsGuiElement.instance.DisableCardClick();
				DeathMatchUnitsGuiElement.instance.ShowHintText(NABOFKMBMKH: false);
				BJGCPDNMHDH.mShowDeployHint = false;
				goto case 3u;
			case 3u:
				if (PlayerController.OGMBJPKOPCB.weaponInventory.currentWeapon != PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[1])
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				PlayerController.OGMBJPKOPCB.weaponInventory.HKGLMFFAHFN = true;
				TimeManager.UnFreezeGame();
				BJGCPDNMHDH.FreezeEnemies();
				PHDOCKCBJOF = new WaitForSeconds(0.5f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 4u:
				KFCAECGLKKO = BJGCPDNMHDH.mParatroopers.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						AIObject current = KFCAECGLKKO.Current;
						current.destroyableObj.isImmortal = false;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("ID_TUTORIAL_SNIPERSHOOT_UP", "ID_TUTORIAL_SNIPERSHOOT_DOWN", -0.3f);
				BJGCPDNMHDH.mParatrooperPosition = BJGCPDNMHDH.mFirstParatrooper.destroyableObj.transform.position + BJGCPDNMHDH.mFirstParatrooper.destroyableObj.transform.up * 0.4f;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartHoldAnimation(BJGCPDNMHDH.mParatrooperPosition, ELHGOHGPJCF: false);
				EAKENBHDGMO = RadicalRoutine.Create(BJGCPDNMHDH.UpdateHoldSniperShoot());
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(EAKENBHDGMO.enumerator));
				goto case 5u;
			case 5u:
				if (BJGCPDNMHDH.mSniperKilled == 0)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				Singleton<TutorialProgressShower>.instance.CheckNum(0);
				BJGCPDNMHDH.UnfreezeEnemies();
				DeathMatchUnitsGuiElement.instance.EnableCardClick();
				BJGCPDNMHDH.mShowDeployHint = true;
				EAKENBHDGMO.Cancel();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopHoldAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				PHDOCKCBJOF = new WaitForSeconds(0.5f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 6u:
				PlayerController.OGMBJPKOPCB.weaponInventory.HKGLMFFAHFN = false;
				PHDOCKCBJOF = new WaitForRealSeconds(0.5f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 7u:
				Singleton<TutorialProgressShower>.instance.Hide();
				PHDOCKCBJOF = new WaitForRealSeconds(2f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 8u:
				Singleton<TutorialProgressShower>.instance.Show(Localization.Localize("ID_TUTORIAL_PROGRESS_KILLING2"), 1);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void FJOIBBIGBJC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void IFLGJMJCOMC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool HDGDKCMIOGK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mSniperKilled = 0;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.SpawnParatroopers(0));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				Singleton<TutorialProgressShower>.instance.PKLDJJIALHA();
				goto case 2u;
			case 2u:
				if (BJGCPDNMHDH.mFirstParatrooper.transform.position.y > 127f)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				Singleton<TutorialProgressShower>.instance.EKNDHCNIJFG(Localization.Localize("menu-squad-1"), 1);
				PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().HKGLMFFAHFN = false;
				PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[1].weapon.ammoLeft = 65;
				PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().LAGONJMBJMM[0].HFNAMMBPJAJ().ammoLeftInClip = -53;
				PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[1].weapon.FIMMGPLLLCL = -51;
				PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[0].weapon.ammoSetup.EPDELOGPNAC = 20f;
				GuiElementSingle<TutorialDialog>.instance.KOGOLIJLMDN("Network pool: InstantiatePooledObjects '", "Shots_Fired", 1770f, TutorialDialog.DODBDLEJOAM.Right, BBGAMLLOING: true);
				BCPOJIEKMJH = GuiElementSingle<InventoryGuiElement>.instance.IGNHPMIDAGM[8].transform.position + 1251f * Vector3.up;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(BCPOJIEKMJH, ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1971f);
				TimeManager.FODFANEEDFF();
				DeathMatchUnitsGuiElement.instance.DisableCardClick();
				DeathMatchUnitsGuiElement.BCDJJBAFLLG().JADNIAFKNIF(NABOFKMBMKH: false);
				BJGCPDNMHDH.mShowDeployHint = false;
				goto case 3u;
			case 3u:
				if (PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().JECOEJBGKDF() != PlayerController.OGMBJPKOPCB.FMKGGADDHJK().LAGONJMBJMM[0])
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().HKGLMFFAHFN = true;
				TimeManager.UnFreezeGame(1019f);
				BJGCPDNMHDH.FreezeEnemies();
				PHDOCKCBJOF = new WaitForSeconds(608f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 4u:
				KFCAECGLKKO = BJGCPDNMHDH.mParatroopers.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						AIObject current = KFCAECGLKKO.Current;
						current.destroyableObj.isImmortal = false;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				GuiElementSingle<TutorialDialog>.instance.BLHEPOBPHPK("ID_CONFIRM_FBLOGINCANCELLED_TEXT", "ClientVersion", 1205f, TutorialDialog.DODBDLEJOAM.Top, BBGAMLLOING: false, BEBMEBEJIOB: true);
				BJGCPDNMHDH.mParatrooperPosition = BJGCPDNMHDH.mFirstParatrooper.destroyableObj.transform.position + BJGCPDNMHDH.mFirstParatrooper.destroyableObj.transform.up * 1513f;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartHoldAnimation(BJGCPDNMHDH.mParatrooperPosition, ELHGOHGPJCF: true, 258f);
				EAKENBHDGMO = RadicalRoutine.Create(BJGCPDNMHDH.UpdateHoldSniperShoot());
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(EAKENBHDGMO.enumerator));
				goto case 5u;
			case 5u:
				if (BJGCPDNMHDH.mSniperKilled == 0)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<TutorialProgressShower>.instance.AADHLKHFJLE(1);
				BJGCPDNMHDH.UnfreezeEnemies();
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().EnableCardClick();
				BJGCPDNMHDH.mShowDeployHint = true;
				EAKENBHDGMO.Cancel();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopHoldAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				PHDOCKCBJOF = new WaitForSeconds(1896f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 6u:
				PlayerController.OGMBJPKOPCB.FMKGGADDHJK().HKGLMFFAHFN = true;
				PHDOCKCBJOF = new WaitForRealSeconds(1205f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 7u:
				Singleton<TutorialProgressShower>.instance.Hide();
				PHDOCKCBJOF = new WaitForRealSeconds(1653f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 8u:
				Singleton<TutorialProgressShower>.instance.IECHFELOIIO(Localization.Localize("matchMadeGames"), 0);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void HMBLLDJFIJG()
		{
			throw new NotSupportedException();
		}

		public void FOBPOJPHNHE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool OKELILGDPLJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mSniperKilled = 1;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.SpawnParatroopers(0));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				Singleton<TutorialProgressShower>.instance.OCAEJPMPBMH();
				goto case 2u;
			case 2u:
				if (BJGCPDNMHDH.mFirstParatrooper.transform.position.y > 759f)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<TutorialProgressShower>.instance.EEOKJCKNEAL(Localization.Localize("(Ljava/lang/Object;)Z"), 1);
				PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().HKGLMFFAHFN = false;
				PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().LAGONJMBJMM[0].HFNAMMBPJAJ().ammoLeft = -126;
				PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[1].weapon.ammoLeftInClip = 23;
				PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[1].HFNAMMBPJAJ().FIMMGPLLLCL = -29;
				PlayerController.OGMBJPKOPCB.FMKGGADDHJK().LAGONJMBJMM[0].weapon.ammoSetup.EPDELOGPNAC = 214f;
				GuiElementSingle<TutorialDialog>.instance.KOGOLIJLMDN("ID_MISSION_KILLUNIT", "open", 1747f, TutorialDialog.DODBDLEJOAM.Top);
				BCPOJIEKMJH = GuiElementSingle<InventoryGuiElement>.instance.IGNHPMIDAGM[1].transform.position + 829f * Vector3.up;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(BCPOJIEKMJH, ELHGOHGPJCF: true, ENIHCPLOOAE: false, 315f);
				TimeManager.FreezeGame();
				DeathMatchUnitsGuiElement.instance.DisableCardClick();
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().JADNIAFKNIF(NABOFKMBMKH: true, FMOIFJNOIKA: false);
				BJGCPDNMHDH.mShowDeployHint = false;
				goto case 3u;
			case 3u:
				if (PlayerController.OGMBJPKOPCB.weaponInventory.JNFHKEJCIIA() != PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().LAGONJMBJMM[1])
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				PlayerController.OGMBJPKOPCB.weaponInventory.HKGLMFFAHFN = false;
				TimeManager.UnFreezeGame(1929f);
				BJGCPDNMHDH.FreezeEnemies();
				PHDOCKCBJOF = new WaitForSeconds(262f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 4u:
				KFCAECGLKKO = BJGCPDNMHDH.mParatroopers.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						AIObject current = KFCAECGLKKO.Current;
						current.destroyableObj.isImmortal = true;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				GuiElementSingle<TutorialDialog>.instance.BLHEPOBPHPK("expiresOn", "OnDisconnectedFromPhoton", 1233f, TutorialDialog.DODBDLEJOAM.BottomRight, BBGAMLLOING: true);
				BJGCPDNMHDH.mParatrooperPosition = BJGCPDNMHDH.mFirstParatrooper.destroyableObj.transform.position + BJGCPDNMHDH.mFirstParatrooper.destroyableObj.transform.up * 859f;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartHoldAnimation(BJGCPDNMHDH.mParatrooperPosition, ELHGOHGPJCF: false, 1795f);
				EAKENBHDGMO = RadicalRoutine.Create(BJGCPDNMHDH.UpdateHoldSniperShoot());
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(EAKENBHDGMO.enumerator));
				goto case 5u;
			case 5u:
				if (BJGCPDNMHDH.mSniperKilled == 0)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				Singleton<TutorialProgressShower>.instance.BMBAEDIOBKN(0, FGHNCECHPPO: false);
				BJGCPDNMHDH.UnfreezeEnemies();
				DeathMatchUnitsGuiElement.instance.CLLFHCFEMED();
				BJGCPDNMHDH.mShowDeployHint = true;
				EAKENBHDGMO.Cancel();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopHoldAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				PHDOCKCBJOF = new WaitForSeconds(856f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 6u:
				PlayerController.OGMBJPKOPCB.FMKGGADDHJK().HKGLMFFAHFN = false;
				PHDOCKCBJOF = new WaitForRealSeconds(1308f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 7u:
				Singleton<TutorialProgressShower>.instance.PKLDJJIALHA();
				PHDOCKCBJOF = new WaitForRealSeconds(1517f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 8u:
				Singleton<TutorialProgressShower>.instance.CALBGDIEDGA(Localization.Localize("Starting stage 2 "), 1);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void BICMFOEHHGN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void DEPEHNFEJEE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IHAOBCEALPD()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void FIAPMEMIIKB()
		{
			throw new NotSupportedException();
		}

		public void IGBHHLFACKO()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool LPCBKGKFNFD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mSniperKilled = 1;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.SpawnParatroopers(0));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				Singleton<TutorialProgressShower>.instance.LDPPNNMGNGI();
				goto case 2u;
			case 2u:
				if (BJGCPDNMHDH.mFirstParatrooper.transform.position.y > 920f)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				Singleton<TutorialProgressShower>.instance.DIBLFOPCCPL(Localization.Localize("tc"), 1);
				PlayerController.OGMBJPKOPCB.FMKGGADDHJK().HKGLMFFAHFN = true;
				PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().LAGONJMBJMM[1].HFNAMMBPJAJ().ammoLeft = 0;
				PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().LAGONJMBJMM[1].weapon.ammoLeftInClip = -78;
				PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().LAGONJMBJMM[0].weapon.FIMMGPLLLCL = -47;
				PlayerController.OGMBJPKOPCB.FMKGGADDHJK().LAGONJMBJMM[0].weapon.ammoSetup.EPDELOGPNAC = 240f;
				GuiElementSingle<TutorialDialog>.instance.KOGOLIJLMDN("02", "BANDS_EMPTY", 1050f, TutorialDialog.DODBDLEJOAM.Top, BBGAMLLOING: true, BEBMEBEJIOB: true);
				BCPOJIEKMJH = GuiElementSingle<InventoryGuiElement>.instance.IGNHPMIDAGM[6].transform.position + 436f * Vector3.up;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(BCPOJIEKMJH, ELHGOHGPJCF: false, ENIHCPLOOAE: false, 1422f);
				TimeManager.DCODDANOPCP();
				DeathMatchUnitsGuiElement.instance.DisableCardClick();
				DeathMatchUnitsGuiElement.BLHCFKIELCA().JADNIAFKNIF(NABOFKMBMKH: true, FMOIFJNOIKA: false);
				BJGCPDNMHDH.mShowDeployHint = true;
				goto case 3u;
			case 3u:
				if (PlayerController.OGMBJPKOPCB.FMKGGADDHJK().currentWeapon != PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().LAGONJMBJMM[0])
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().HKGLMFFAHFN = true;
				TimeManager.UnFreezeGame(1553f);
				BJGCPDNMHDH.FreezeEnemies();
				PHDOCKCBJOF = new WaitForSeconds(348f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 4u:
				KFCAECGLKKO = BJGCPDNMHDH.mParatroopers.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						AIObject current = KFCAECGLKKO.Current;
						current.destroyableObj.isImmortal = true;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("GoldBonusCount", "ID_SQUADWAREND", 1299f, TutorialDialog.DODBDLEJOAM.Left, BBGAMLLOING: true);
				BJGCPDNMHDH.mParatrooperPosition = BJGCPDNMHDH.mFirstParatrooper.destroyableObj.transform.position + BJGCPDNMHDH.mFirstParatrooper.destroyableObj.transform.up * 1077f;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartHoldAnimation(BJGCPDNMHDH.mParatrooperPosition, ELHGOHGPJCF: false, 1581f);
				EAKENBHDGMO = RadicalRoutine.Create(BJGCPDNMHDH.UpdateHoldSniperShoot());
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(EAKENBHDGMO.enumerator));
				goto case 5u;
			case 5u:
				if (BJGCPDNMHDH.mSniperKilled == 0)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				Singleton<TutorialProgressShower>.instance.JPNBJLFCNKD(1, FGHNCECHPPO: false);
				BJGCPDNMHDH.UnfreezeEnemies();
				DeathMatchUnitsGuiElement.BCDJJBAFLLG().EnableCardClick();
				BJGCPDNMHDH.mShowDeployHint = false;
				EAKENBHDGMO.Cancel();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopHoldAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				PHDOCKCBJOF = new WaitForSeconds(341f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 6u:
				PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().HKGLMFFAHFN = false;
				PHDOCKCBJOF = new WaitForRealSeconds(810f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 7u:
				Singleton<TutorialProgressShower>.instance.LDPPNNMGNGI();
				PHDOCKCBJOF = new WaitForRealSeconds(285f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 8u:
				Singleton<TutorialProgressShower>.instance.DIBLFOPCCPL(Localization.Localize("I"), 1);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object HCCLNDKNCIE()
		{
			return PHDOCKCBJOF;
		}

		public void IBDAHMOEBCM()
		{
			throw new NotSupportedException();
		}

		public bool KHNDCDGBFJH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mSniperKilled = 1;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.SpawnParatroopers());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				Singleton<TutorialProgressShower>.instance.JIILFGDJFPP();
				goto case 2u;
			case 2u:
				if (BJGCPDNMHDH.mFirstParatrooper.transform.position.y > 328f)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				Singleton<TutorialProgressShower>.instance.JOGFDHFOOBC(Localization.Localize("WarBucksSkipPrice"), 1);
				PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().HKGLMFFAHFN = true;
				PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().LAGONJMBJMM[1].weapon.ammoLeft = 49;
				PlayerController.OGMBJPKOPCB.FMKGGADDHJK().LAGONJMBJMM[0].HFNAMMBPJAJ().ammoLeftInClip = 85;
				PlayerController.OGMBJPKOPCB.FMKGGADDHJK().LAGONJMBJMM[0].weapon.FIMMGPLLLCL = 44;
				PlayerController.OGMBJPKOPCB.FMKGGADDHJK().LAGONJMBJMM[1].HFNAMMBPJAJ().ammoSetup.EPDELOGPNAC = 842f;
				GuiElementSingle<TutorialDialog>.instance.KOGOLIJLMDN("ShotFrequencyMaxCannon", "ID_GUI_BRONZE", 302f, TutorialDialog.DODBDLEJOAM.Top);
				BCPOJIEKMJH = GuiElementSingle<InventoryGuiElement>.instance.IGNHPMIDAGM[1].transform.position + 965f * Vector3.up;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(BCPOJIEKMJH, ELHGOHGPJCF: false, ENIHCPLOOAE: false, 1014f);
				TimeManager.DCODDANOPCP();
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().DisableCardClick();
				DeathMatchUnitsGuiElement.BLHCFKIELCA().ShowHintText(NABOFKMBMKH: false, FMOIFJNOIKA: false);
				BJGCPDNMHDH.mShowDeployHint = true;
				goto case 3u;
			case 3u:
				if (PlayerController.OGMBJPKOPCB.FMKGGADDHJK().JKHKBGPKFFF() != PlayerController.OGMBJPKOPCB.FMKGGADDHJK().LAGONJMBJMM[1])
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				PlayerController.OGMBJPKOPCB.FMKGGADDHJK().HKGLMFFAHFN = true;
				TimeManager.UnFreezeGame(830f);
				BJGCPDNMHDH.FreezeEnemies();
				PHDOCKCBJOF = new WaitForSeconds(1062f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 4u:
				KFCAECGLKKO = BJGCPDNMHDH.mParatroopers.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						AIObject current = KFCAECGLKKO.Current;
						current.destroyableObj.isImmortal = true;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				GuiElementSingle<TutorialDialog>.instance.BLHEPOBPHPK("Buy_VIP", "Rewards", 858f, TutorialDialog.DODBDLEJOAM.TopRight, BBGAMLLOING: true, BEBMEBEJIOB: true);
				BJGCPDNMHDH.mParatrooperPosition = BJGCPDNMHDH.mFirstParatrooper.destroyableObj.transform.position + BJGCPDNMHDH.mFirstParatrooper.destroyableObj.transform.up * 1672f;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartHoldAnimation(BJGCPDNMHDH.mParatrooperPosition, ELHGOHGPJCF: false, 1122f);
				EAKENBHDGMO = RadicalRoutine.Create(BJGCPDNMHDH.UpdateHoldSniperShoot());
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(EAKENBHDGMO.enumerator));
				goto case 5u;
			case 5u:
				if (BJGCPDNMHDH.mSniperKilled == 0)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				Singleton<TutorialProgressShower>.instance.AJMCILHGLFA(0);
				BJGCPDNMHDH.UnfreezeEnemies();
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().EnableCardClick();
				BJGCPDNMHDH.mShowDeployHint = true;
				EAKENBHDGMO.Cancel();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopHoldAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				PHDOCKCBJOF = new WaitForSeconds(660f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 6u:
				PlayerController.OGMBJPKOPCB.weaponInventory.HKGLMFFAHFN = false;
				PHDOCKCBJOF = new WaitForRealSeconds(238f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 7u:
				Singleton<TutorialProgressShower>.instance.JIILFGDJFPP();
				PHDOCKCBJOF = new WaitForRealSeconds(1314f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 8u:
				Singleton<TutorialProgressShower>.instance.BLFNIFFFAIJ(Localization.Localize("slotUpgradeindex: {0}, slotUpgradeIndexElite: {0}, slotUpgradeIndexSpecial {1},  isSpecial {2},  scaleDamage {3},  scaleHP {4}"), 0);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void NIGDCBDKKMJ()
		{
			throw new NotSupportedException();
		}

		public void BCIPEBNJONK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object AHFIDCCJHKE()
		{
			return PHDOCKCBJOF;
		}

		public void IODFILFCENJ()
		{
			throw new NotSupportedException();
		}

		public void IPKNPABKAJD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object DFHCLJNONGC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EOPJNKFKMNB()
		{
			return PHDOCKCBJOF;
		}

		public void GFPDOCDEGPA()
		{
			throw new NotSupportedException();
		}

		public bool LLOCENNFFFJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mSniperKilled = 1;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.SpawnParatroopers());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<TutorialProgressShower>.instance.Hide();
				goto case 2u;
			case 2u:
				if (BJGCPDNMHDH.mFirstParatrooper.transform.position.y > 567f)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				Singleton<TutorialProgressShower>.instance.JEDGCOMDEKM(Localization.Localize("WindowDuration"), 0);
				PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().HKGLMFFAHFN = true;
				PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().LAGONJMBJMM[1].HFNAMMBPJAJ().ammoLeft = -94;
				PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[0].weapon.ammoLeftInClip = -121;
				PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[1].HFNAMMBPJAJ().FIMMGPLLLCL = 23;
				PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().LAGONJMBJMM[1].weapon.ammoSetup.EPDELOGPNAC = 34f;
				GuiElementSingle<TutorialDialog>.instance.KOGOLIJLMDN(",", "ExperienceGained", 950f, TutorialDialog.DODBDLEJOAM.TopLeft, BBGAMLLOING: true, BEBMEBEJIOB: true);
				BCPOJIEKMJH = GuiElementSingle<InventoryGuiElement>.instance.IGNHPMIDAGM[7].transform.position + 525f * Vector3.up;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(BCPOJIEKMJH, ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1863f);
				TimeManager.FreezeGame();
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().DisableCardClick();
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().ShowHintText(NABOFKMBMKH: true, FMOIFJNOIKA: false);
				BJGCPDNMHDH.mShowDeployHint = true;
				goto case 3u;
			case 3u:
				if (PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().OLHICLNCPNA() != PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[1])
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().HKGLMFFAHFN = false;
				TimeManager.UnFreezeGame(725f);
				BJGCPDNMHDH.FreezeEnemies();
				PHDOCKCBJOF = new WaitForSeconds(1047f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 4u:
				KFCAECGLKKO = BJGCPDNMHDH.mParatroopers.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						AIObject current = KFCAECGLKKO.Current;
						current.destroyableObj.isImmortal = false;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				GuiElementSingle<TutorialDialog>.instance.KOGOLIJLMDN("Node", "Current unit is not delivered at the moment!!!", 1569f, TutorialDialog.DODBDLEJOAM.Left, BBGAMLLOING: true, BEBMEBEJIOB: true);
				BJGCPDNMHDH.mParatrooperPosition = BJGCPDNMHDH.mFirstParatrooper.destroyableObj.transform.position + BJGCPDNMHDH.mFirstParatrooper.destroyableObj.transform.up * 651f;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartHoldAnimation(BJGCPDNMHDH.mParatrooperPosition, ELHGOHGPJCF: false, 1716f);
				EAKENBHDGMO = RadicalRoutine.Create(BJGCPDNMHDH.UpdateHoldSniperShoot());
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(EAKENBHDGMO.enumerator));
				goto case 5u;
			case 5u:
				if (BJGCPDNMHDH.mSniperKilled == 0)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				Singleton<TutorialProgressShower>.instance.BMBAEDIOBKN(0, FGHNCECHPPO: false);
				BJGCPDNMHDH.UnfreezeEnemies();
				DeathMatchUnitsGuiElement.instance.EnableCardClick();
				BJGCPDNMHDH.mShowDeployHint = true;
				EAKENBHDGMO.Cancel();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopHoldAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				PHDOCKCBJOF = new WaitForSeconds(310f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 6u:
				PlayerController.OGMBJPKOPCB.FMKGGADDHJK().HKGLMFFAHFN = false;
				PHDOCKCBJOF = new WaitForRealSeconds(764f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 7u:
				Singleton<TutorialProgressShower>.instance.JIILFGDJFPP();
				PHDOCKCBJOF = new WaitForRealSeconds(1919f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 8u:
				Singleton<TutorialProgressShower>.instance.CALBGDIEDGA(Localization.Localize("1.0"), 1);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object FPFOODLPEBK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BGAGLOJHMEJ()
		{
			return PHDOCKCBJOF;
		}

		public void IJHCIJLDKHK()
		{
			throw new NotSupportedException();
		}

		public bool CCOPPEKLJOB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mSniperKilled = 0;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.SpawnParatroopers(0));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				Singleton<TutorialProgressShower>.instance.Hide();
				goto case 2u;
			case 2u:
				if (BJGCPDNMHDH.mFirstParatrooper.transform.position.y > 544f)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				Singleton<TutorialProgressShower>.instance.ALKFOHIAKOM(Localization.Localize("_MatCap"), 1);
				PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().HKGLMFFAHFN = false;
				PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[0].weapon.ammoLeft = 34;
				PlayerController.OGMBJPKOPCB.FMKGGADDHJK().LAGONJMBJMM[0].HFNAMMBPJAJ().ammoLeftInClip = -116;
				PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().LAGONJMBJMM[1].weapon.FIMMGPLLLCL = -120;
				PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().LAGONJMBJMM[1].HFNAMMBPJAJ().ammoSetup.EPDELOGPNAC = 812f;
				GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("' already destroyed on application quit. Won't create again - returning null.", "TuneListener trackerDidEnqueueUrl: ", 30f, TutorialDialog.DODBDLEJOAM.Right, BBGAMLLOING: false, BEBMEBEJIOB: true);
				BCPOJIEKMJH = GuiElementSingle<InventoryGuiElement>.instance.IGNHPMIDAGM[1].transform.position + 1955f * Vector3.up;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(BCPOJIEKMJH, ELHGOHGPJCF: false, ENIHCPLOOAE: false, 1772f);
				TimeManager.FreezeGame();
				DeathMatchUnitsGuiElement.BCDJJBAFLLG().DisableCardClick();
				DeathMatchUnitsGuiElement.BLHCFKIELCA().ShowHintText(NABOFKMBMKH: true, FMOIFJNOIKA: false);
				BJGCPDNMHDH.mShowDeployHint = true;
				goto case 3u;
			case 3u:
				if (PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().JNFHKEJCIIA() != PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().LAGONJMBJMM[1])
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().HKGLMFFAHFN = true;
				TimeManager.UnFreezeGame(1546f);
				BJGCPDNMHDH.FreezeEnemies();
				PHDOCKCBJOF = new WaitForSeconds(391f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 4u:
				KFCAECGLKKO = BJGCPDNMHDH.mParatroopers.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						AIObject current = KFCAECGLKKO.Current;
						current.destroyableObj.isImmortal = false;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				GuiElementSingle<TutorialDialog>.instance.KOGOLIJLMDN("SERVICE_MISSING", "menu-tilegfx-facebook", 748f, TutorialDialog.DODBDLEJOAM.BottomRight, BBGAMLLOING: true, BEBMEBEJIOB: true);
				BJGCPDNMHDH.mParatrooperPosition = BJGCPDNMHDH.mFirstParatrooper.destroyableObj.transform.position + BJGCPDNMHDH.mFirstParatrooper.destroyableObj.transform.up * 822f;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartHoldAnimation(BJGCPDNMHDH.mParatrooperPosition, ELHGOHGPJCF: true, 1434f);
				EAKENBHDGMO = RadicalRoutine.Create(BJGCPDNMHDH.UpdateHoldSniperShoot());
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(EAKENBHDGMO.enumerator));
				goto case 5u;
			case 5u:
				if (BJGCPDNMHDH.mSniperKilled == 0)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				Singleton<TutorialProgressShower>.instance.BKGBNEAFCCC(1);
				BJGCPDNMHDH.UnfreezeEnemies();
				DeathMatchUnitsGuiElement.BCDJJBAFLLG().CLLFHCFEMED();
				BJGCPDNMHDH.mShowDeployHint = true;
				EAKENBHDGMO.Cancel();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopHoldAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				PHDOCKCBJOF = new WaitForSeconds(1577f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 6u:
				PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().HKGLMFFAHFN = false;
				PHDOCKCBJOF = new WaitForRealSeconds(1820f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 7u:
				Singleton<TutorialProgressShower>.instance.CDLODKKNAEF();
				PHDOCKCBJOF = new WaitForRealSeconds(625f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 8u:
				Singleton<TutorialProgressShower>.instance.EMHGOECGAFL(Localization.Localize("S"), 1);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object JMKGAJNOLEM()
		{
			return PHDOCKCBJOF;
		}

		public void MEBPMHDHIPJ()
		{
			throw new NotSupportedException();
		}

		public void ODJLLLFJIOB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object EOKIMMCAABI()
		{
			return PHDOCKCBJOF;
		}

		public bool FBMLBIOKKBE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mSniperKilled = 0;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.SpawnParatroopers(0));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<TutorialProgressShower>.instance.PKLDJJIALHA();
				goto case 2u;
			case 2u:
				if (BJGCPDNMHDH.mFirstParatrooper.transform.position.y > 217f)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				Singleton<TutorialProgressShower>.instance.CBBLGFEBJID(Localization.Localize("NONCONSUMABLE INAPP: "), 0);
				PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().HKGLMFFAHFN = false;
				PlayerController.OGMBJPKOPCB.FMKGGADDHJK().LAGONJMBJMM[1].weapon.ammoLeft = 6;
				PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().LAGONJMBJMM[1].HFNAMMBPJAJ().ammoLeftInClip = -75;
				PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[0].HFNAMMBPJAJ().FIMMGPLLLCL = 106;
				PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().LAGONJMBJMM[1].HFNAMMBPJAJ().ammoSetup.EPDELOGPNAC = 777f;
				GuiElementSingle<TutorialDialog>.instance.KOGOLIJLMDN("damage", "AddedCards", 390f, TutorialDialog.DODBDLEJOAM.Bottom, BBGAMLLOING: true, BEBMEBEJIOB: true);
				BCPOJIEKMJH = GuiElementSingle<InventoryGuiElement>.instance.IGNHPMIDAGM[1].transform.position + 1735f * Vector3.up;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(BCPOJIEKMJH, ELHGOHGPJCF: false, ENIHCPLOOAE: true, 1031f);
				TimeManager.DCODDANOPCP();
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().DisableCardClick();
				DeathMatchUnitsGuiElement.instance.ShowHintText(NABOFKMBMKH: true, FMOIFJNOIKA: false);
				BJGCPDNMHDH.mShowDeployHint = false;
				goto case 3u;
			case 3u:
				if (PlayerController.OGMBJPKOPCB.weaponInventory.CILCMCDCKKE() != PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().LAGONJMBJMM[0])
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				PlayerController.OGMBJPKOPCB.FMKGGADDHJK().HKGLMFFAHFN = true;
				TimeManager.UnFreezeGame(1965f);
				BJGCPDNMHDH.FreezeEnemies();
				PHDOCKCBJOF = new WaitForSeconds(146f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 4u:
				KFCAECGLKKO = BJGCPDNMHDH.mParatroopers.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						AIObject current = KFCAECGLKKO.Current;
						current.destroyableObj.isImmortal = false;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("Completed", "HeartPrice", 799f, TutorialDialog.DODBDLEJOAM.TopLeft, BBGAMLLOING: true, BEBMEBEJIOB: true);
				BJGCPDNMHDH.mParatrooperPosition = BJGCPDNMHDH.mFirstParatrooper.destroyableObj.transform.position + BJGCPDNMHDH.mFirstParatrooper.destroyableObj.transform.up * 1706f;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartHoldAnimation(BJGCPDNMHDH.mParatrooperPosition, ELHGOHGPJCF: true, 1116f);
				EAKENBHDGMO = RadicalRoutine.Create(BJGCPDNMHDH.UpdateHoldSniperShoot());
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(EAKENBHDGMO.enumerator));
				goto case 5u;
			case 5u:
				if (BJGCPDNMHDH.mSniperKilled == 0)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				Singleton<TutorialProgressShower>.instance.PPADPIDMPGN(1, FGHNCECHPPO: false);
				BJGCPDNMHDH.UnfreezeEnemies();
				DeathMatchUnitsGuiElement.BLHCFKIELCA().EnableCardClick();
				BJGCPDNMHDH.mShowDeployHint = false;
				EAKENBHDGMO.Cancel();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopHoldAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				PHDOCKCBJOF = new WaitForSeconds(429f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 6u:
				PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().HKGLMFFAHFN = true;
				PHDOCKCBJOF = new WaitForRealSeconds(311f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 7u:
				Singleton<TutorialProgressShower>.instance.JIILFGDJFPP();
				PHDOCKCBJOF = new WaitForRealSeconds(1572f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 8u:
				Singleton<TutorialProgressShower>.instance.EKNDHCNIJFG(Localization.Localize("DepositedCards"), 0);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void AKEKFBGEJBG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object KJMPNHLOKJL()
		{
			return PHDOCKCBJOF;
		}

		public void PHKDHCJBMII()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object EGJDJENBABP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HJFIBBBPDKK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AKGMMLGANMJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BGBGCFGNJLA()
		{
			return PHDOCKCBJOF;
		}

		public bool KDFAHLNCNMN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mSniperKilled = 0;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.SpawnParatroopers());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				Singleton<TutorialProgressShower>.instance.OCAEJPMPBMH();
				goto case 2u;
			case 2u:
				if (BJGCPDNMHDH.mFirstParatrooper.transform.position.y > 390f)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				Singleton<TutorialProgressShower>.instance.DLCFAJEFLHO(Localization.Localize("bronze3"), 1);
				PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().HKGLMFFAHFN = false;
				PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().LAGONJMBJMM[1].weapon.ammoLeft = 95;
				PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().LAGONJMBJMM[0].HFNAMMBPJAJ().ammoLeftInClip = -97;
				PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[0].HFNAMMBPJAJ().FIMMGPLLLCL = -18;
				PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().LAGONJMBJMM[1].HFNAMMBPJAJ().ammoSetup.EPDELOGPNAC = 834f;
				GuiElementSingle<TutorialDialog>.instance.KOGOLIJLMDN("com/google/android/gms/games/Games", "NO", 882f, TutorialDialog.DODBDLEJOAM.BottomRight, BBGAMLLOING: true, BEBMEBEJIOB: true);
				BCPOJIEKMJH = GuiElementSingle<InventoryGuiElement>.instance.IGNHPMIDAGM[0].transform.position + 1748f * Vector3.up;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(BCPOJIEKMJH, ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1232f);
				TimeManager.FreezeGame();
				DeathMatchUnitsGuiElement.BLHCFKIELCA().DisableCardClick();
				DeathMatchUnitsGuiElement.instance.ShowHintText(NABOFKMBMKH: true, FMOIFJNOIKA: false);
				BJGCPDNMHDH.mShowDeployHint = true;
				goto case 3u;
			case 3u:
				if (PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().PDLFJEDGLAO() != PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().LAGONJMBJMM[0])
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				PlayerController.OGMBJPKOPCB.FMKGGADDHJK().HKGLMFFAHFN = false;
				TimeManager.UnFreezeGame(1470f);
				BJGCPDNMHDH.FreezeEnemies();
				PHDOCKCBJOF = new WaitForSeconds(48f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 4u:
				KFCAECGLKKO = BJGCPDNMHDH.mParatroopers.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						AIObject current = KFCAECGLKKO.Current;
						current.destroyableObj.isImmortal = true;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				GuiElementSingle<TutorialDialog>.instance.BLHEPOBPHPK("UpdateFriendsListFromServer()", "ID_CONFIRM_NOTENOUGHMEDALSTOJOIN", 1233f, TutorialDialog.DODBDLEJOAM.Right, BBGAMLLOING: true);
				BJGCPDNMHDH.mParatrooperPosition = BJGCPDNMHDH.mFirstParatrooper.destroyableObj.transform.position + BJGCPDNMHDH.mFirstParatrooper.destroyableObj.transform.up * 217f;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartHoldAnimation(BJGCPDNMHDH.mParatrooperPosition, ELHGOHGPJCF: true, 1300f);
				EAKENBHDGMO = RadicalRoutine.Create(BJGCPDNMHDH.UpdateHoldSniperShoot());
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(EAKENBHDGMO.enumerator));
				goto case 5u;
			case 5u:
				if (BJGCPDNMHDH.mSniperKilled == 0)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				Singleton<TutorialProgressShower>.instance.AADHLKHFJLE(0);
				BJGCPDNMHDH.UnfreezeEnemies();
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().EnableCardClick();
				BJGCPDNMHDH.mShowDeployHint = true;
				EAKENBHDGMO.Cancel();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopHoldAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				PHDOCKCBJOF = new WaitForSeconds(416f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 6u:
				PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().HKGLMFFAHFN = true;
				PHDOCKCBJOF = new WaitForRealSeconds(1929f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 7u:
				Singleton<TutorialProgressShower>.instance.OCAEJPMPBMH();
				PHDOCKCBJOF = new WaitForRealSeconds(12f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 8u:
				Singleton<TutorialProgressShower>.instance.EKNDHCNIJFG(Localization.Localize("ID_RELOG_TO_FB_DIALOG_TITLE"), 0);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[DebuggerHidden]
		public CMLLMGJMFKA()
		{
		}

		public void NAMBILMHOPD()
		{
			throw new NotSupportedException();
		}

		public bool LPMIKEPIMCM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mSniperKilled = 0;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.SpawnParatroopers(0));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				Singleton<TutorialProgressShower>.instance.OCAEJPMPBMH();
				goto case 2u;
			case 2u:
				if (BJGCPDNMHDH.mFirstParatrooper.transform.position.y > 1606f)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<TutorialProgressShower>.instance.EEOKJCKNEAL(Localization.Localize("PackId"), 0);
				PlayerController.OGMBJPKOPCB.weaponInventory.HKGLMFFAHFN = false;
				PlayerController.OGMBJPKOPCB.FMKGGADDHJK().LAGONJMBJMM[1].HFNAMMBPJAJ().ammoLeft = -66;
				PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().LAGONJMBJMM[1].HFNAMMBPJAJ().ammoLeftInClip = -99;
				PlayerController.OGMBJPKOPCB.FMKGGADDHJK().LAGONJMBJMM[1].weapon.FIMMGPLLLCL = 78;
				PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[0].HFNAMMBPJAJ().ammoSetup.EPDELOGPNAC = 513f;
				GuiElementSingle<TutorialDialog>.instance.DDFADDKPPDI("SquadIcons/", "_CameraWS", 314f, TutorialDialog.DODBDLEJOAM.Center, BBGAMLLOING: false, BEBMEBEJIOB: true);
				BCPOJIEKMJH = GuiElementSingle<InventoryGuiElement>.instance.IGNHPMIDAGM[7].transform.position + 1248f * Vector3.up;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(BCPOJIEKMJH, ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1986f);
				TimeManager.DCODDANOPCP();
				DeathMatchUnitsGuiElement.instance.DisableCardClick();
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().JADNIAFKNIF(NABOFKMBMKH: true);
				BJGCPDNMHDH.mShowDeployHint = false;
				goto case 3u;
			case 3u:
				if (PlayerController.OGMBJPKOPCB.FMKGGADDHJK().LJELEJEJIEB() != PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().LAGONJMBJMM[0])
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().HKGLMFFAHFN = false;
				TimeManager.UnFreezeGame(1332f);
				BJGCPDNMHDH.FreezeEnemies();
				PHDOCKCBJOF = new WaitForSeconds(1238f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 4u:
				KFCAECGLKKO = BJGCPDNMHDH.mParatroopers.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						AIObject current = KFCAECGLKKO.Current;
						current.destroyableObj.isImmortal = false;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				GuiElementSingle<TutorialDialog>.instance.BLHEPOBPHPK("null", "menu-armypower-ico", 1798f, TutorialDialog.DODBDLEJOAM.Left, BBGAMLLOING: true, BEBMEBEJIOB: true);
				BJGCPDNMHDH.mParatrooperPosition = BJGCPDNMHDH.mFirstParatrooper.destroyableObj.transform.position + BJGCPDNMHDH.mFirstParatrooper.destroyableObj.transform.up * 134f;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartHoldAnimation(BJGCPDNMHDH.mParatrooperPosition, ELHGOHGPJCF: false, 855f);
				EAKENBHDGMO = RadicalRoutine.Create(BJGCPDNMHDH.UpdateHoldSniperShoot());
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(EAKENBHDGMO.enumerator));
				goto case 5u;
			case 5u:
				if (BJGCPDNMHDH.mSniperKilled == 0)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				Singleton<TutorialProgressShower>.instance.NGANGLPOOJM(1);
				BJGCPDNMHDH.UnfreezeEnemies();
				DeathMatchUnitsGuiElement.BCDJJBAFLLG().CLLFHCFEMED();
				BJGCPDNMHDH.mShowDeployHint = false;
				EAKENBHDGMO.Cancel();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopHoldAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				PHDOCKCBJOF = new WaitForSeconds(1025f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 6u:
				PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().HKGLMFFAHFN = true;
				PHDOCKCBJOF = new WaitForRealSeconds(407f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 7u:
				Singleton<TutorialProgressShower>.instance.LDPPNNMGNGI();
				PHDOCKCBJOF = new WaitForRealSeconds(218f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 8u:
				Singleton<TutorialProgressShower>.instance.EMHGOECGAFL(Localization.Localize("ID_INVITATION_VALID_FOR"), 1);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void HPJKDIGCCCE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void NINFNJOMJOD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool FADACBKMFGG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mSniperKilled = 0;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.SpawnParatroopers(0));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<TutorialProgressShower>.instance.Hide();
				goto case 2u;
			case 2u:
				if (BJGCPDNMHDH.mFirstParatrooper.transform.position.y > 1475f)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				Singleton<TutorialProgressShower>.instance.PCJHCBIHFNF(Localization.Localize(","), 0);
				PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().HKGLMFFAHFN = false;
				PlayerController.OGMBJPKOPCB.FMKGGADDHJK().LAGONJMBJMM[1].HFNAMMBPJAJ().ammoLeft = 116;
				PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().LAGONJMBJMM[1].weapon.ammoLeftInClip = -20;
				PlayerController.OGMBJPKOPCB.FMKGGADDHJK().LAGONJMBJMM[1].HFNAMMBPJAJ().FIMMGPLLLCL = 10;
				PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[1].HFNAMMBPJAJ().ammoSetup.EPDELOGPNAC = 1139f;
				GuiElementSingle<TutorialDialog>.instance.BLHEPOBPHPK("Vip", "Cards_Owned_Bronze", 204f, TutorialDialog.DODBDLEJOAM.BottomRight, BBGAMLLOING: true, BEBMEBEJIOB: true);
				BCPOJIEKMJH = GuiElementSingle<InventoryGuiElement>.instance.IGNHPMIDAGM[5].transform.position + 476f * Vector3.up;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(BCPOJIEKMJH, ELHGOHGPJCF: true, ENIHCPLOOAE: true, 467f);
				TimeManager.FODFANEEDFF();
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().DisableCardClick();
				DeathMatchUnitsGuiElement.instance.JADNIAFKNIF(NABOFKMBMKH: false, FMOIFJNOIKA: false);
				BJGCPDNMHDH.mShowDeployHint = false;
				goto case 3u;
			case 3u:
				if (PlayerController.OGMBJPKOPCB.FMKGGADDHJK().OLHICLNCPNA() != PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[0])
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				PlayerController.OGMBJPKOPCB.weaponInventory.HKGLMFFAHFN = false;
				TimeManager.UnFreezeGame(133f);
				BJGCPDNMHDH.FreezeEnemies();
				PHDOCKCBJOF = new WaitForSeconds(547f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 4u:
				KFCAECGLKKO = BJGCPDNMHDH.mParatroopers.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						AIObject current = KFCAECGLKKO.Current;
						current.destroyableObj.isImmortal = false;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				GuiElementSingle<TutorialDialog>.instance.DDFADDKPPDI("Play_Card_Tutorial_Duration", "ID_ONETIMESPECIALOFFER", 1171f, TutorialDialog.DODBDLEJOAM.Left, BBGAMLLOING: true);
				BJGCPDNMHDH.mParatrooperPosition = BJGCPDNMHDH.mFirstParatrooper.destroyableObj.transform.position + BJGCPDNMHDH.mFirstParatrooper.destroyableObj.transform.up * 1568f;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartHoldAnimation(BJGCPDNMHDH.mParatrooperPosition, ELHGOHGPJCF: false, 1488f);
				EAKENBHDGMO = RadicalRoutine.Create(BJGCPDNMHDH.UpdateHoldSniperShoot());
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(EAKENBHDGMO.enumerator));
				goto case 5u;
			case 5u:
				if (BJGCPDNMHDH.mSniperKilled == 0)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				Singleton<TutorialProgressShower>.instance.AADHLKHFJLE(1);
				BJGCPDNMHDH.UnfreezeEnemies();
				DeathMatchUnitsGuiElement.BCDJJBAFLLG().EnableCardClick();
				BJGCPDNMHDH.mShowDeployHint = true;
				EAKENBHDGMO.Cancel();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopHoldAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				PHDOCKCBJOF = new WaitForSeconds(621f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 6u:
				PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().HKGLMFFAHFN = true;
				PHDOCKCBJOF = new WaitForRealSeconds(640f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 7u:
				Singleton<TutorialProgressShower>.instance.PKLDJJIALHA();
				PHDOCKCBJOF = new WaitForRealSeconds(801f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 8u:
				Singleton<TutorialProgressShower>.instance.BLFNIFFFAIJ(Localization.Localize("Message"), 1);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void ODCIKOOGNFG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GPKBICHIBHF()
		{
			return PHDOCKCBJOF;
		}

		public void MNFJGIMMBLE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HGOKAFJBFGJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AFDKAGLDADB()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void NBGFOILFGHD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KKCOHEHPJPF()
		{
			return PHDOCKCBJOF;
		}

		public bool HMLAEHJKPJE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mSniperKilled = 0;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.SpawnParatroopers());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<TutorialProgressShower>.instance.GGOJJHILEGE();
				goto case 2u;
			case 2u:
				if (BJGCPDNMHDH.mFirstParatrooper.transform.position.y > 1213f)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<TutorialProgressShower>.instance.FCANLIOLJNH(Localization.Localize("ID_READYTIME"), 0);
				PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().HKGLMFFAHFN = true;
				PlayerController.OGMBJPKOPCB.FMKGGADDHJK().LAGONJMBJMM[1].weapon.ammoLeft = 122;
				PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().LAGONJMBJMM[0].HFNAMMBPJAJ().ammoLeftInClip = 110;
				PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().LAGONJMBJMM[0].HFNAMMBPJAJ().FIMMGPLLLCL = -106;
				PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().LAGONJMBJMM[0].weapon.ammoSetup.EPDELOGPNAC = 1586f;
				GuiElementSingle<TutorialDialog>.instance.DDFADDKPPDI("'Day'0", "Player not in squad and should be in squad ", 673f, TutorialDialog.DODBDLEJOAM.Right);
				BCPOJIEKMJH = GuiElementSingle<InventoryGuiElement>.instance.IGNHPMIDAGM[8].transform.position + 974f * Vector3.up;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(BCPOJIEKMJH, ELHGOHGPJCF: true, ENIHCPLOOAE: false, 641f);
				TimeManager.FODFANEEDFF();
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().DisableCardClick();
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().JADNIAFKNIF(NABOFKMBMKH: false);
				BJGCPDNMHDH.mShowDeployHint = false;
				goto case 3u;
			case 3u:
				if (PlayerController.OGMBJPKOPCB.weaponInventory.NANJBGIGNCG() != PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().LAGONJMBJMM[0])
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				PlayerController.OGMBJPKOPCB.weaponInventory.HKGLMFFAHFN = true;
				TimeManager.UnFreezeGame(863f);
				BJGCPDNMHDH.FreezeEnemies();
				PHDOCKCBJOF = new WaitForSeconds(392f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 4u:
				KFCAECGLKKO = BJGCPDNMHDH.mParatroopers.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						AIObject current = KFCAECGLKKO.Current;
						current.destroyableObj.isImmortal = true;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial(")", "Finish Game", 1129f, TutorialDialog.DODBDLEJOAM.Bottom, BBGAMLLOING: true);
				BJGCPDNMHDH.mParatrooperPosition = BJGCPDNMHDH.mFirstParatrooper.destroyableObj.transform.position + BJGCPDNMHDH.mFirstParatrooper.destroyableObj.transform.up * 997f;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartHoldAnimation(BJGCPDNMHDH.mParatrooperPosition, ELHGOHGPJCF: true, 41f);
				EAKENBHDGMO = RadicalRoutine.Create(BJGCPDNMHDH.UpdateHoldSniperShoot());
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(EAKENBHDGMO.enumerator));
				goto case 5u;
			case 5u:
				if (BJGCPDNMHDH.mSniperKilled == 0)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				Singleton<TutorialProgressShower>.instance.BKGBNEAFCCC(0);
				BJGCPDNMHDH.UnfreezeEnemies();
				DeathMatchUnitsGuiElement.BCDJJBAFLLG().EnableCardClick();
				BJGCPDNMHDH.mShowDeployHint = true;
				EAKENBHDGMO.Cancel();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopHoldAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				PHDOCKCBJOF = new WaitForSeconds(890f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 6u:
				PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().HKGLMFFAHFN = false;
				PHDOCKCBJOF = new WaitForRealSeconds(655f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 7u:
				Singleton<TutorialProgressShower>.instance.GGOJJHILEGE();
				PHDOCKCBJOF = new WaitForRealSeconds(1568f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 8u:
				Singleton<TutorialProgressShower>.instance.JOGFDHFOOBC(Localization.Localize("menu-squad-1"), 1);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object GMPGIODBIPO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OAKHGMKKFMN()
		{
			return PHDOCKCBJOF;
		}
	}

	private sealed class EEBKAGLDPHL : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal PlayerController LHAAAIGMEBK;

		internal PlayerBot PNBNBGCNMCF;

		internal bool CEDLJPOCKED;

		internal int MCAKMECBJNA;

		internal TutorialManagerStage2 BJGCPDNMHDH;

		internal object PHDOCKCBJOF;

		internal bool FDKOKMKIIMG;

		internal int CLPPIAGLCJJ;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		public bool BGOEENAEBNO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				BJGCPDNMHDH.mGameStarted = true;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("SquadIcons/");
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 1490f;
				Singleton<SpawningManagerDeathMatch>.instance.autoDeployEnabled = false;
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf((GHPGNELIDBM)4);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 1452f;
				LHAAAIGMEBK.FOCIOKMPCAG.APJEBOPJPLA();
				LHAAAIGMEBK.KIIHLIPAGIH = true;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.MBECPMJFIHB();
				PNBNBGCNMCF.PADBFAIBBDG = 0;
				PNBNBGCNMCF.MGECHKCAELH = false;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = false;
				PHDOCKCBJOF = new WaitForRealSeconds(1997f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 4u:
				Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.WinstreakReward8).FLOATVALUE;
				Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-106)).FLOATVALUE;
				DeathMatchUnitsGuiElement.BCDJJBAFLLG().MDBPINJMNKO.GAODJMFOOHM(IDEBKDPMPGM: false);
				DeathMatchUnitsGuiElement.BCDJJBAFLLG().MDBPINJMNKO.CLLJEINIGBL();
				PHDOCKCBJOF = new WaitForRealSeconds(1354f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 5u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				PHDOCKCBJOF = new WaitForRealSeconds(747f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.ThrowGrenade()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 7u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheck(258f)));
				PHDOCKCBJOF = new WaitForRealSeconds(1111f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 8u:
				CEDLJPOCKED = true;
				MCAKMECBJNA = 1;
				if (BJGCPDNMHDH.mSniperRifleShots == 0)
				{
					CEDLJPOCKED = true;
					MCAKMECBJNA = (int)TimeManager.CEAFAMFNGCC();
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SniperExplain()));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 79;
					}
					break;
				}
				goto IL_038d;
			case 9u:
				MCAKMECBJNA = Mathf.Abs((int)TimeManager.realTimeWithoutPauses - MCAKMECBJNA);
				goto IL_038d;
			default:
				{
					return false;
				}
				IL_038d:
				PlayerController.GetEnemyOf((GHPGNELIDBM)6).KIIHLIPAGIH = false;
				Singleton<EventTrackingManager>.instance.RegisterTutorialSniperShootEvent("NewAssignments", CEDLJPOCKED, MCAKMECBJNA);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object LNAPDCBIFIJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FJGIOPMDPGA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JDECDOJJAAH()
		{
			return PHDOCKCBJOF;
		}

		public bool NOHPKMDNEAO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				BJGCPDNMHDH.mGameStarted = true;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_GUI_REPORTABUSE_LISTITEM1");
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 670f;
				Singleton<SpawningManagerDeathMatch>.instance.autoDeployEnabled = false;
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf((GHPGNELIDBM)6);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 1006f;
				LHAAAIGMEBK.FOCIOKMPCAG.APJEBOPJPLA();
				LHAAAIGMEBK.KIIHLIPAGIH = true;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.GetWeakBotConfig();
				PNBNBGCNMCF.PADBFAIBBDG = 5;
				PNBNBGCNMCF.MGECHKCAELH = true;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = false;
				PHDOCKCBJOF = new WaitForRealSeconds(1740f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 4u:
				Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-127)).FLOATVALUE;
				Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-127)).FLOATVALUE;
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().MDBPINJMNKO.AHPJFHNNODC(IDEBKDPMPGM: false);
				DeathMatchUnitsGuiElement.BCDJJBAFLLG().MDBPINJMNKO.HFNPJIMLJNG();
				PHDOCKCBJOF = new WaitForRealSeconds(677f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 5u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				PHDOCKCBJOF = new WaitForRealSeconds(1407f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.ThrowGrenade()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 7u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheck(1721f)));
				PHDOCKCBJOF = new WaitForRealSeconds(334f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 8u:
				CEDLJPOCKED = false;
				MCAKMECBJNA = 0;
				if (BJGCPDNMHDH.mSniperRifleShots == 0)
				{
					CEDLJPOCKED = false;
					MCAKMECBJNA = (int)TimeManager.CEAFAMFNGCC();
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SniperExplain()));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -51;
					}
					break;
				}
				goto IL_038d;
			case 9u:
				MCAKMECBJNA = Mathf.Abs((int)TimeManager.realTimeWithoutPauses - MCAKMECBJNA);
				goto IL_038d;
			default:
				{
					return false;
				}
				IL_038d:
				PlayerController.GetEnemyOf((GHPGNELIDBM)6).KIIHLIPAGIH = true;
				Singleton<EventTrackingManager>.instance.RegisterTutorialSniperShootEvent("N", CEDLJPOCKED, MCAKMECBJNA);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public void EEHBKGPLIJN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object KKIMCCGAMJA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DFHCLJNONGC()
		{
			return PHDOCKCBJOF;
		}

		public void DBEMHFEBPFM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool FCJCLBMPBFK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				BJGCPDNMHDH.mGameStarted = false;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("localSquadLeaderboard");
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 357f;
				Singleton<SpawningManagerDeathMatch>.instance.OLJIPPEIOBO(IDEBKDPMPGM: true);
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf((GHPGNELIDBM)7);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 1103f;
				LHAAAIGMEBK.FOCIOKMPCAG.OEAGCMGINCB();
				LHAAAIGMEBK.KIIHLIPAGIH = false;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.DMIECFDHMKN();
				PNBNBGCNMCF.PADBFAIBBDG = 8;
				PNBNBGCNMCF.MGECHKCAELH = true;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = false;
				PHDOCKCBJOF = new WaitForRealSeconds(1711f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 4u:
				Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DogtagAdInterval).FLOATVALUE;
				Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.GoldenSuitcaseAdTimeBetweenMinutes).FLOATVALUE;
				DeathMatchUnitsGuiElement.BCDJJBAFLLG().MDBPINJMNKO.BDHPCMOGAHF(IDEBKDPMPGM: false);
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().MDBPINJMNKO.HFNPJIMLJNG();
				PHDOCKCBJOF = new WaitForRealSeconds(1709f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 5u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				PHDOCKCBJOF = new WaitForRealSeconds(1031f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.ThrowGrenade()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 7u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheck(1179f)));
				PHDOCKCBJOF = new WaitForRealSeconds(75f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 8u:
				CEDLJPOCKED = false;
				MCAKMECBJNA = 1;
				if (BJGCPDNMHDH.mSniperRifleShots == 0)
				{
					CEDLJPOCKED = false;
					MCAKMECBJNA = (int)TimeManager.realTimeWithoutPauses;
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SniperExplain()));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -70;
					}
					break;
				}
				goto IL_038d;
			case 9u:
				MCAKMECBJNA = Mathf.Abs((int)TimeManager.realTimeWithoutPauses - MCAKMECBJNA);
				goto IL_038d;
			default:
				{
					return true;
				}
				IL_038d:
				PlayerController.GetEnemyOf(GHPGNELIDBM.Allies).KIIHLIPAGIH = false;
				Singleton<EventTrackingManager>.instance.RegisterTutorialSniperShootEvent("PrepareBotForDeathMatch 0", CEDLJPOCKED, MCAKMECBJNA);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object CMNCAPEMEJI()
		{
			return PHDOCKCBJOF;
		}

		public void EBAGFJMHLCB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool JPAOKNLNFCB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				BJGCPDNMHDH.mGameStarted = true;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(", ");
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 624f;
				Singleton<SpawningManagerDeathMatch>.instance.OLJIPPEIOBO(IDEBKDPMPGM: true);
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf((GHPGNELIDBM)4);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 420f;
				LHAAAIGMEBK.FOCIOKMPCAG.OEAGCMGINCB();
				LHAAAIGMEBK.KIIHLIPAGIH = false;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.GetWeakBotConfig();
				PNBNBGCNMCF.PADBFAIBBDG = 7;
				PNBNBGCNMCF.MGECHKCAELH = true;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = true;
				PHDOCKCBJOF = new WaitForRealSeconds(1903f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 4u:
				Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-112)).FLOATVALUE;
				Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.WinstreakReward4).FLOATVALUE;
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().MDBPINJMNKO.PPGEPMHPNDB(IDEBKDPMPGM: false);
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().MDBPINJMNKO.DKPLBHODAAF();
				PHDOCKCBJOF = new WaitForRealSeconds(366f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 5u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				PHDOCKCBJOF = new WaitForRealSeconds(1357f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.ThrowGrenade()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 7u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheck(1692f)));
				PHDOCKCBJOF = new WaitForRealSeconds(891f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 8u:
				CEDLJPOCKED = true;
				MCAKMECBJNA = 0;
				if (BJGCPDNMHDH.mSniperRifleShots == 0)
				{
					CEDLJPOCKED = true;
					MCAKMECBJNA = (int)TimeManager.realTimeWithoutPauses;
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SniperExplain()));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -27;
					}
					break;
				}
				goto IL_038d;
			case 9u:
				MCAKMECBJNA = Mathf.Abs((int)TimeManager.realTimeWithoutPauses - MCAKMECBJNA);
				goto IL_038d;
			default:
				{
					return true;
				}
				IL_038d:
				PlayerController.GetEnemyOf(GHPGNELIDBM.None).KIIHLIPAGIH = false;
				Singleton<EventTrackingManager>.instance.RegisterTutorialSniperShootEvent("ChillingoSdkManager", CEDLJPOCKED, MCAKMECBJNA);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void GGLMLMFEJCD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void PMPGBMCHGPE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void MNFJGIMMBLE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BBHOODPMEFM()
		{
			return PHDOCKCBJOF;
		}

		public void CDDFJOEEFID()
		{
			throw new NotSupportedException();
		}

		public void OPMABIIDKCN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool ONFBKOEOIOC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				BJGCPDNMHDH.mGameStarted = false;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ArenaLootbox");
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 523f;
				Singleton<SpawningManagerDeathMatch>.instance.KPGIELJBLEH(IDEBKDPMPGM: false);
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf((GHPGNELIDBM)7);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 964f;
				LHAAAIGMEBK.FOCIOKMPCAG.OEAGCMGINCB();
				LHAAAIGMEBK.KIIHLIPAGIH = false;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.GetWeakBotConfig();
				PNBNBGCNMCF.PADBFAIBBDG = 6;
				PNBNBGCNMCF.MGECHKCAELH = true;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = false;
				PHDOCKCBJOF = new WaitForRealSeconds(1876f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 4u:
				Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.TimeBetweenUnitUpgradeReminderShown).FLOATVALUE;
				Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.ServerRentalSaleMax).FLOATVALUE;
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().MDBPINJMNKO.AHPJFHNNODC(IDEBKDPMPGM: true);
				DeathMatchUnitsGuiElement.BLHCFKIELCA().MDBPINJMNKO.OIADGFDOPJM();
				PHDOCKCBJOF = new WaitForRealSeconds(728f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 5u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				PHDOCKCBJOF = new WaitForRealSeconds(826f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.ThrowGrenade()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 7u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheck(386f)));
				PHDOCKCBJOF = new WaitForRealSeconds(1456f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 8u:
				CEDLJPOCKED = true;
				MCAKMECBJNA = 0;
				if (BJGCPDNMHDH.mSniperRifleShots == 0)
				{
					CEDLJPOCKED = false;
					MCAKMECBJNA = (int)TimeManager.CEAFAMFNGCC();
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SniperExplain()));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -115;
					}
					break;
				}
				goto IL_038d;
			case 9u:
				MCAKMECBJNA = Mathf.Abs((int)TimeManager.realTimeWithoutPauses - MCAKMECBJNA);
				goto IL_038d;
			default:
				{
					return true;
				}
				IL_038d:
				PlayerController.GetEnemyOf((GHPGNELIDBM)3).KIIHLIPAGIH = true;
				Singleton<EventTrackingManager>.instance.RegisterTutorialSniperShootEvent("#DOMINIK# Video feeed added!! ", CEDLJPOCKED, MCAKMECBJNA);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public bool CJGKHIPOBGP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				BJGCPDNMHDH.mGameStarted = true;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Video_feed_upload");
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 1344f;
				Singleton<SpawningManagerDeathMatch>.instance.KPGIELJBLEH(IDEBKDPMPGM: false);
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf((GHPGNELIDBM)6);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 1078f;
				LHAAAIGMEBK.FOCIOKMPCAG.Refill();
				LHAAAIGMEBK.KIIHLIPAGIH = true;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.GetWeakBotConfig();
				PNBNBGCNMCF.PADBFAIBBDG = 6;
				PNBNBGCNMCF.MGECHKCAELH = false;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = true;
				PHDOCKCBJOF = new WaitForRealSeconds(401f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 4u:
				Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SilverPackSilverCards).FLOATVALUE;
				Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.WinstreakReward1).FLOATVALUE;
				DeathMatchUnitsGuiElement.BLHCFKIELCA().MDBPINJMNKO.GAODJMFOOHM(IDEBKDPMPGM: true);
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().MDBPINJMNKO.InstantUpdate();
				PHDOCKCBJOF = new WaitForRealSeconds(362f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 5u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				PHDOCKCBJOF = new WaitForRealSeconds(1525f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.ThrowGrenade()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 7u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheck(1282f)));
				PHDOCKCBJOF = new WaitForRealSeconds(1815f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 8u:
				CEDLJPOCKED = true;
				MCAKMECBJNA = 1;
				if (BJGCPDNMHDH.mSniperRifleShots == 0)
				{
					CEDLJPOCKED = true;
					MCAKMECBJNA = (int)TimeManager.CEAFAMFNGCC();
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SniperExplain()));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 14;
					}
					break;
				}
				goto IL_038d;
			case 9u:
				MCAKMECBJNA = Mathf.Abs((int)TimeManager.CEAFAMFNGCC() - MCAKMECBJNA);
				goto IL_038d;
			default:
				{
					return false;
				}
				IL_038d:
				PlayerController.GetEnemyOf(GHPGNELIDBM.Enemies).KIIHLIPAGIH = false;
				Singleton<EventTrackingManager>.instance.RegisterTutorialSniperShootEvent("ID_BATTLECANCELED", CEDLJPOCKED, MCAKMECBJNA);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				BJGCPDNMHDH.mGameStarted = false;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("202 GAME STARTED");
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 0f;
				Singleton<SpawningManagerDeathMatch>.instance.autoDeployEnabled = true;
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf(GHPGNELIDBM.Allies);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 125f;
				LHAAAIGMEBK.FOCIOKMPCAG.Refill();
				LHAAAIGMEBK.KIIHLIPAGIH = true;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.GetWeakBotConfig();
				PNBNBGCNMCF.PADBFAIBBDG = 5;
				PNBNBGCNMCF.MGECHKCAELH = false;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = true;
				PHDOCKCBJOF = new WaitForRealSeconds(0.5f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 4u:
				Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MaxEnergy).FLOATVALUE;
				Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MaxEnergy).FLOATVALUE;
				DeathMatchUnitsGuiElement.instance.MDBPINJMNKO.shouldUpdate = true;
				DeathMatchUnitsGuiElement.instance.MDBPINJMNKO.InstantUpdate();
				PHDOCKCBJOF = new WaitForRealSeconds(1f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 5u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				PHDOCKCBJOF = new WaitForRealSeconds(1f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.ThrowGrenade()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 7u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheck()));
				PHDOCKCBJOF = new WaitForRealSeconds(15f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 8u:
				CEDLJPOCKED = false;
				MCAKMECBJNA = 0;
				if (BJGCPDNMHDH.mSniperRifleShots == 0)
				{
					CEDLJPOCKED = true;
					MCAKMECBJNA = (int)TimeManager.realTimeWithoutPauses;
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SniperExplain()));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 9;
					}
					break;
				}
				goto IL_038d;
			case 9u:
				MCAKMECBJNA = Mathf.Abs((int)TimeManager.realTimeWithoutPauses - MCAKMECBJNA);
				goto IL_038d;
			default:
				{
					return false;
				}
				IL_038d:
				PlayerController.GetEnemyOf(GHPGNELIDBM.Allies).KIIHLIPAGIH = false;
				Singleton<EventTrackingManager>.instance.RegisterTutorialSniperShootEvent("207 STAGE 7 SNIPER", CEDLJPOCKED, MCAKMECBJNA);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void POJKIIMAFDO()
		{
			throw new NotSupportedException();
		}

		public void JANIKOFKDCH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void FLCIMHOJPDF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void MEBPMHDHIPJ()
		{
			throw new NotSupportedException();
		}

		public bool HOOHJGPHHGN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				BJGCPDNMHDH.mGameStarted = false;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_CONFIRM_ERROR");
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 1067f;
				Singleton<SpawningManagerDeathMatch>.instance.autoDeployEnabled = true;
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf((GHPGNELIDBM)3);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 1838f;
				LHAAAIGMEBK.FOCIOKMPCAG.Refill();
				LHAAAIGMEBK.KIIHLIPAGIH = false;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.MBECPMJFIHB();
				PNBNBGCNMCF.PADBFAIBBDG = 6;
				PNBNBGCNMCF.MGECHKCAELH = true;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = false;
				PHDOCKCBJOF = new WaitForRealSeconds(922f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 4u:
				Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.RepairShields).FLOATVALUE;
				Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-108)).FLOATVALUE;
				DeathMatchUnitsGuiElement.BLHCFKIELCA().MDBPINJMNKO.INGNIDHDLPD(IDEBKDPMPGM: false);
				DeathMatchUnitsGuiElement.BCDJJBAFLLG().MDBPINJMNKO.OIADGFDOPJM();
				PHDOCKCBJOF = new WaitForRealSeconds(854f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 5u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				PHDOCKCBJOF = new WaitForRealSeconds(1775f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.ThrowGrenade()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 7u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheck(1215f)));
				PHDOCKCBJOF = new WaitForRealSeconds(1590f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 8u:
				CEDLJPOCKED = true;
				MCAKMECBJNA = 1;
				if (BJGCPDNMHDH.mSniperRifleShots == 0)
				{
					CEDLJPOCKED = true;
					MCAKMECBJNA = (int)TimeManager.realTimeWithoutPauses;
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SniperExplain()));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 108;
					}
					break;
				}
				goto IL_038d;
			case 9u:
				MCAKMECBJNA = Mathf.Abs((int)TimeManager.realTimeWithoutPauses - MCAKMECBJNA);
				goto IL_038d;
			default:
				{
					return true;
				}
				IL_038d:
				PlayerController.GetEnemyOf((GHPGNELIDBM)7).KIIHLIPAGIH = false;
				Singleton<EventTrackingManager>.instance.RegisterTutorialSniperShootEvent("game-tutorial-grenadier", CEDLJPOCKED, MCAKMECBJNA);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object OLMAFKDGMDB()
		{
			return PHDOCKCBJOF;
		}

		public void LOOMFHNKAND()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BMGHJKFMKJE()
		{
			return PHDOCKCBJOF;
		}

		public bool IGOAJGEADPH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				BJGCPDNMHDH.mGameStarted = false;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("gold");
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 1996f;
				Singleton<SpawningManagerDeathMatch>.instance.OLJIPPEIOBO(IDEBKDPMPGM: false);
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf(GHPGNELIDBM.None);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 1983f;
				LHAAAIGMEBK.FOCIOKMPCAG.Refill();
				LHAAAIGMEBK.KIIHLIPAGIH = true;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.MBECPMJFIHB();
				PNBNBGCNMCF.PADBFAIBBDG = 2;
				PNBNBGCNMCF.MGECHKCAELH = false;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = true;
				PHDOCKCBJOF = new WaitForRealSeconds(588f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 4u:
				Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-29)).FLOATVALUE;
				Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.VipGoldMultiplier).FLOATVALUE;
				DeathMatchUnitsGuiElement.BLHCFKIELCA().MDBPINJMNKO.PJFDIEGEGAC(IDEBKDPMPGM: false);
				DeathMatchUnitsGuiElement.BCDJJBAFLLG().MDBPINJMNKO.OIADGFDOPJM();
				PHDOCKCBJOF = new WaitForRealSeconds(418f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 5u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				PHDOCKCBJOF = new WaitForRealSeconds(533f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.ThrowGrenade()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 7u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheck(774f)));
				PHDOCKCBJOF = new WaitForRealSeconds(28f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 8u:
				CEDLJPOCKED = true;
				MCAKMECBJNA = 1;
				if (BJGCPDNMHDH.mSniperRifleShots == 0)
				{
					CEDLJPOCKED = false;
					MCAKMECBJNA = (int)TimeManager.CEAFAMFNGCC();
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SniperExplain()));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 21;
					}
					break;
				}
				goto IL_038d;
			case 9u:
				MCAKMECBJNA = Mathf.Abs((int)TimeManager.CEAFAMFNGCC() - MCAKMECBJNA);
				goto IL_038d;
			default:
				{
					return false;
				}
				IL_038d:
				PlayerController.GetEnemyOf(GHPGNELIDBM.None).KIIHLIPAGIH = true;
				Singleton<EventTrackingManager>.instance.RegisterTutorialSniperShootEvent("master3", CEDLJPOCKED, MCAKMECBJNA);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object PFMFFMEJBPM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JNKDBMNFGJJ()
		{
			return PHDOCKCBJOF;
		}

		public void MJIEDEKLIAP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object OAMLLHEMBIK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NOIDHHDEEPL()
		{
			return PHDOCKCBJOF;
		}

		public void JOEOMEJLEID()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void HJOCCDLNFLN()
		{
			throw new NotSupportedException();
		}

		public void AMPGDAMMPFJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool FPOFCJOEAMO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				BJGCPDNMHDH.mGameStarted = false;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("shieldDestroy");
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 809f;
				Singleton<SpawningManagerDeathMatch>.instance.OLJIPPEIOBO(IDEBKDPMPGM: true);
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf((GHPGNELIDBM)4);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 1214f;
				LHAAAIGMEBK.FOCIOKMPCAG.APJEBOPJPLA();
				LHAAAIGMEBK.KIIHLIPAGIH = false;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.MBECPMJFIHB();
				PNBNBGCNMCF.PADBFAIBBDG = 6;
				PNBNBGCNMCF.MGECHKCAELH = false;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = false;
				PHDOCKCBJOF = new WaitForRealSeconds(1208f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 4u:
				Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.VipWarbucksMultiplier).FLOATVALUE;
				Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.UnitCategoriesReminderAfterGames).FLOATVALUE;
				DeathMatchUnitsGuiElement.BCDJJBAFLLG().MDBPINJMNKO.GAODJMFOOHM(IDEBKDPMPGM: true);
				DeathMatchUnitsGuiElement.instance.MDBPINJMNKO.LIHDDPHJNOG();
				PHDOCKCBJOF = new WaitForRealSeconds(879f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 5u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				PHDOCKCBJOF = new WaitForRealSeconds(808f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.ThrowGrenade()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 7u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheck(1724f)));
				PHDOCKCBJOF = new WaitForRealSeconds(971f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 8u:
				CEDLJPOCKED = false;
				MCAKMECBJNA = 0;
				if (BJGCPDNMHDH.mSniperRifleShots == 0)
				{
					CEDLJPOCKED = true;
					MCAKMECBJNA = (int)TimeManager.CEAFAMFNGCC();
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SniperExplain()));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -10;
					}
					break;
				}
				goto IL_038d;
			case 9u:
				MCAKMECBJNA = Mathf.Abs((int)TimeManager.realTimeWithoutPauses - MCAKMECBJNA);
				goto IL_038d;
			default:
				{
					return true;
				}
				IL_038d:
				PlayerController.GetEnemyOf(GHPGNELIDBM.Allies).KIIHLIPAGIH = false;
				Singleton<EventTrackingManager>.instance.RegisterTutorialSniperShootEvent("Elite_parts", CEDLJPOCKED, MCAKMECBJNA);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void BICMFOEHHGN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void CNBLDCICPLL()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object DFKJEOAPBGP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AHFIDCCJHKE()
		{
			return PHDOCKCBJOF;
		}

		public void CNEIBEACPCM()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HBKJOBOMGKB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AGANCOFPDCK()
		{
			return PHDOCKCBJOF;
		}

		public void LGCKODOHHIA()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MCCMIANNJAN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ILNCOKPCNBB()
		{
			return PHDOCKCBJOF;
		}

		public void BBBLJNFEACC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object OJANHAIEAEJ()
		{
			return PHDOCKCBJOF;
		}

		public bool NEMOAIBCODB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				BJGCPDNMHDH.mGameStarted = false;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Message ");
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 1903f;
				Singleton<SpawningManagerDeathMatch>.instance.OLJIPPEIOBO(IDEBKDPMPGM: false);
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf(GHPGNELIDBM.None);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 1936f;
				LHAAAIGMEBK.FOCIOKMPCAG.APJEBOPJPLA();
				LHAAAIGMEBK.KIIHLIPAGIH = true;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.GetWeakBotConfig();
				PNBNBGCNMCF.PADBFAIBBDG = 7;
				PNBNBGCNMCF.MGECHKCAELH = false;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = true;
				PHDOCKCBJOF = new WaitForRealSeconds(251f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 4u:
				Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.TimeBetweenUnitUpgradeReminderShown).FLOATVALUE;
				Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-96)).FLOATVALUE;
				DeathMatchUnitsGuiElement.instance.MDBPINJMNKO.LIOJDDABNKO(IDEBKDPMPGM: true);
				DeathMatchUnitsGuiElement.instance.MDBPINJMNKO.AEKAOMNLMBL();
				PHDOCKCBJOF = new WaitForRealSeconds(562f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 5u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				PHDOCKCBJOF = new WaitForRealSeconds(1930f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.ThrowGrenade()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 7u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheck(520f)));
				PHDOCKCBJOF = new WaitForRealSeconds(1089f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 8u:
				CEDLJPOCKED = false;
				MCAKMECBJNA = 0;
				if (BJGCPDNMHDH.mSniperRifleShots == 0)
				{
					CEDLJPOCKED = false;
					MCAKMECBJNA = (int)TimeManager.realTimeWithoutPauses;
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SniperExplain()));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -22;
					}
					break;
				}
				goto IL_038d;
			case 9u:
				MCAKMECBJNA = Mathf.Abs((int)TimeManager.realTimeWithoutPauses - MCAKMECBJNA);
				goto IL_038d;
			default:
				{
					return true;
				}
				IL_038d:
				PlayerController.GetEnemyOf((GHPGNELIDBM)5).KIIHLIPAGIH = false;
				Singleton<EventTrackingManager>.instance.RegisterTutorialSniperShootEvent("SpecialOfferMessage {0} {1} {2}", CEDLJPOCKED, MCAKMECBJNA);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public bool FOKKNCCLABE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				BJGCPDNMHDH.mGameStarted = false;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Beanstalk: New Message sent succesfully");
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 64f;
				Singleton<SpawningManagerDeathMatch>.instance.KPGIELJBLEH(IDEBKDPMPGM: false);
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf(GHPGNELIDBM.None);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 1909f;
				LHAAAIGMEBK.FOCIOKMPCAG.OEAGCMGINCB();
				LHAAAIGMEBK.KIIHLIPAGIH = true;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.MBECPMJFIHB();
				PNBNBGCNMCF.PADBFAIBBDG = 3;
				PNBNBGCNMCF.MGECHKCAELH = false;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = true;
				PHDOCKCBJOF = new WaitForRealSeconds(835f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 4u:
				Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-15)).FLOATVALUE;
				Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-7)).FLOATVALUE;
				DeathMatchUnitsGuiElement.BCDJJBAFLLG().MDBPINJMNKO.PFPLHOHDFFD(IDEBKDPMPGM: true);
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().MDBPINJMNKO.KLPHMIGJLCG();
				PHDOCKCBJOF = new WaitForRealSeconds(1845f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 5u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				PHDOCKCBJOF = new WaitForRealSeconds(1013f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.ThrowGrenade()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 7u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheck(135f)));
				PHDOCKCBJOF = new WaitForRealSeconds(1212f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 8u:
				CEDLJPOCKED = true;
				MCAKMECBJNA = 0;
				if (BJGCPDNMHDH.mSniperRifleShots == 0)
				{
					CEDLJPOCKED = false;
					MCAKMECBJNA = (int)TimeManager.CEAFAMFNGCC();
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SniperExplain()));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -105;
					}
					break;
				}
				goto IL_038d;
			case 9u:
				MCAKMECBJNA = Mathf.Abs((int)TimeManager.realTimeWithoutPauses - MCAKMECBJNA);
				goto IL_038d;
			default:
				{
					return true;
				}
				IL_038d:
				PlayerController.GetEnemyOf((GHPGNELIDBM)4).KIIHLIPAGIH = false;
				Singleton<EventTrackingManager>.instance.RegisterTutorialSniperShootEvent(", keys.Length = ", CEDLJPOCKED, MCAKMECBJNA);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public bool PGOBEIMCPGA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				BJGCPDNMHDH.mGameStarted = false;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("RewardGold");
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 1144f;
				Singleton<SpawningManagerDeathMatch>.instance.OLJIPPEIOBO(IDEBKDPMPGM: true);
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf(GHPGNELIDBM.Enemies);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 1301f;
				LHAAAIGMEBK.FOCIOKMPCAG.Refill();
				LHAAAIGMEBK.KIIHLIPAGIH = true;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.GetWeakBotConfig();
				PNBNBGCNMCF.PADBFAIBBDG = 2;
				PNBNBGCNMCF.MGECHKCAELH = false;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = false;
				PHDOCKCBJOF = new WaitForRealSeconds(701f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 4u:
				Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-24)).FLOATVALUE;
				Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-50)).FLOATVALUE;
				DeathMatchUnitsGuiElement.instance.MDBPINJMNKO.PJFDIEGEGAC(IDEBKDPMPGM: false);
				DeathMatchUnitsGuiElement.instance.MDBPINJMNKO.OIADGFDOPJM();
				PHDOCKCBJOF = new WaitForRealSeconds(51f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 5u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				PHDOCKCBJOF = new WaitForRealSeconds(554f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.ThrowGrenade()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 7u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheck(185f)));
				PHDOCKCBJOF = new WaitForRealSeconds(1245f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 8u:
				CEDLJPOCKED = false;
				MCAKMECBJNA = 1;
				if (BJGCPDNMHDH.mSniperRifleShots == 0)
				{
					CEDLJPOCKED = true;
					MCAKMECBJNA = (int)TimeManager.realTimeWithoutPauses;
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SniperExplain()));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -109;
					}
					break;
				}
				goto IL_038d;
			case 9u:
				MCAKMECBJNA = Mathf.Abs((int)TimeManager.CEAFAMFNGCC() - MCAKMECBJNA);
				goto IL_038d;
			default:
				{
					return true;
				}
				IL_038d:
				PlayerController.GetEnemyOf(GHPGNELIDBM.None).KIIHLIPAGIH = false;
				Singleton<EventTrackingManager>.instance.RegisterTutorialSniperShootEvent("Pack: Warbucks ", CEDLJPOCKED, MCAKMECBJNA);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object GPKBICHIBHF()
		{
			return PHDOCKCBJOF;
		}

		public void JKEONFBJPPE()
		{
			throw new NotSupportedException();
		}

		public void FIAPMEMIIKB()
		{
			throw new NotSupportedException();
		}

		public void PKMIJKOPPBF()
		{
			throw new NotSupportedException();
		}

		public void AJEIGCJPEFN()
		{
			throw new NotSupportedException();
		}

		public void HHCBBENDENJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void EMICCACCFIP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MOLLIAAFOMJ()
		{
			return PHDOCKCBJOF;
		}

		public bool LAICPPPPIKL()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				BJGCPDNMHDH.mGameStarted = true;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Player was removed from db!");
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 1085f;
				Singleton<SpawningManagerDeathMatch>.instance.OLJIPPEIOBO(IDEBKDPMPGM: false);
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf(GHPGNELIDBM.None);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 676f;
				LHAAAIGMEBK.FOCIOKMPCAG.Refill();
				LHAAAIGMEBK.KIIHLIPAGIH = true;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.GetWeakBotConfig();
				PNBNBGCNMCF.PADBFAIBBDG = 8;
				PNBNBGCNMCF.MGECHKCAELH = false;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = true;
				PHDOCKCBJOF = new WaitForRealSeconds(1258f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 4u:
				Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-79)).FLOATVALUE;
				Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.GoldenSuitcase_VIPRewardDuration).FLOATVALUE;
				DeathMatchUnitsGuiElement.BCDJJBAFLLG().MDBPINJMNKO.INGNIDHDLPD(IDEBKDPMPGM: false);
				DeathMatchUnitsGuiElement.BLHCFKIELCA().MDBPINJMNKO.MHGLNMLKENG();
				PHDOCKCBJOF = new WaitForRealSeconds(1358f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 5u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				PHDOCKCBJOF = new WaitForRealSeconds(706f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.ThrowGrenade()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 7u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheck(581f)));
				PHDOCKCBJOF = new WaitForRealSeconds(822f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 8u:
				CEDLJPOCKED = false;
				MCAKMECBJNA = 1;
				if (BJGCPDNMHDH.mSniperRifleShots == 0)
				{
					CEDLJPOCKED = true;
					MCAKMECBJNA = (int)TimeManager.realTimeWithoutPauses;
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SniperExplain()));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 18;
					}
					break;
				}
				goto IL_038d;
			case 9u:
				MCAKMECBJNA = Mathf.Abs((int)TimeManager.realTimeWithoutPauses - MCAKMECBJNA);
				goto IL_038d;
			default:
				{
					return false;
				}
				IL_038d:
				PlayerController.GetEnemyOf(GHPGNELIDBM.None).KIIHLIPAGIH = true;
				Singleton<EventTrackingManager>.instance.RegisterTutorialSniperShootEvent(",", CEDLJPOCKED, MCAKMECBJNA);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object FKJJFNMBKOP()
		{
			return PHDOCKCBJOF;
		}

		public void AHEOCEEJICJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void IBDAHMOEBCM()
		{
			throw new NotSupportedException();
		}

		public void KGLHLHLLOEM()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool FGAFKEKGPHF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				BJGCPDNMHDH.mGameStarted = false;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("isVIP");
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 32f;
				Singleton<SpawningManagerDeathMatch>.instance.autoDeployEnabled = false;
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf(GHPGNELIDBM.None);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 236f;
				LHAAAIGMEBK.FOCIOKMPCAG.Refill();
				LHAAAIGMEBK.KIIHLIPAGIH = false;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.MBECPMJFIHB();
				PNBNBGCNMCF.PADBFAIBBDG = 7;
				PNBNBGCNMCF.MGECHKCAELH = false;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = false;
				PHDOCKCBJOF = new WaitForRealSeconds(1443f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 4u:
				Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-48)).FLOATVALUE;
				Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-85)).FLOATVALUE;
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().MDBPINJMNKO.PPGEPMHPNDB(IDEBKDPMPGM: false);
				DeathMatchUnitsGuiElement.BLHCFKIELCA().MDBPINJMNKO.OIADGFDOPJM();
				PHDOCKCBJOF = new WaitForRealSeconds(118f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 5u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				PHDOCKCBJOF = new WaitForRealSeconds(1120f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.ThrowGrenade()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 7u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheck(731f)));
				PHDOCKCBJOF = new WaitForRealSeconds(642f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 8u:
				CEDLJPOCKED = false;
				MCAKMECBJNA = 0;
				if (BJGCPDNMHDH.mSniperRifleShots == 0)
				{
					CEDLJPOCKED = false;
					MCAKMECBJNA = (int)TimeManager.CEAFAMFNGCC();
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SniperExplain()));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 11;
					}
					break;
				}
				goto IL_038d;
			case 9u:
				MCAKMECBJNA = Mathf.Abs((int)TimeManager.realTimeWithoutPauses - MCAKMECBJNA);
				goto IL_038d;
			default:
				{
					return true;
				}
				IL_038d:
				PlayerController.GetEnemyOf(GHPGNELIDBM.Allies).KIIHLIPAGIH = false;
				Singleton<EventTrackingManager>.instance.RegisterTutorialSniperShootEvent("DeviceToken", CEDLJPOCKED, MCAKMECBJNA);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public bool HKPECDLGFJB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				BJGCPDNMHDH.mGameStarted = false;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_SQUADMEMBERSLOWER");
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 249f;
				Singleton<SpawningManagerDeathMatch>.instance.KPGIELJBLEH(IDEBKDPMPGM: false);
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf((GHPGNELIDBM)6);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 843f;
				LHAAAIGMEBK.FOCIOKMPCAG.APJEBOPJPLA();
				LHAAAIGMEBK.KIIHLIPAGIH = false;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.DMIECFDHMKN();
				PNBNBGCNMCF.PADBFAIBBDG = 3;
				PNBNBGCNMCF.MGECHKCAELH = true;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = true;
				PHDOCKCBJOF = new WaitForRealSeconds(73f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 4u:
				Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.NotificationAllowReward).FLOATVALUE;
				Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.GoldenSuitcaseAdTimeBetweenMinutes).FLOATVALUE;
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().MDBPINJMNKO.PJFDIEGEGAC(IDEBKDPMPGM: false);
				DeathMatchUnitsGuiElement.BLHCFKIELCA().MDBPINJMNKO.CLLJEINIGBL();
				PHDOCKCBJOF = new WaitForRealSeconds(173f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 5u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				PHDOCKCBJOF = new WaitForRealSeconds(1334f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.ThrowGrenade()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 7u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheck(1275f)));
				PHDOCKCBJOF = new WaitForRealSeconds(1030f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 8u:
				CEDLJPOCKED = true;
				MCAKMECBJNA = 1;
				if (BJGCPDNMHDH.mSniperRifleShots == 0)
				{
					CEDLJPOCKED = true;
					MCAKMECBJNA = (int)TimeManager.CEAFAMFNGCC();
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SniperExplain()));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -46;
					}
					break;
				}
				goto IL_038d;
			case 9u:
				MCAKMECBJNA = Mathf.Abs((int)TimeManager.CEAFAMFNGCC() - MCAKMECBJNA);
				goto IL_038d;
			default:
				{
					return true;
				}
				IL_038d:
				PlayerController.GetEnemyOf((GHPGNELIDBM)3).KIIHLIPAGIH = true;
				Singleton<EventTrackingManager>.instance.RegisterTutorialSniperShootEvent("localSquadLeaderboard", CEDLJPOCKED, MCAKMECBJNA);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public bool EEJLFIHFDLK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				BJGCPDNMHDH.mGameStarted = false;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("registerVirtualGoodsPurchase");
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 228f;
				Singleton<SpawningManagerDeathMatch>.instance.OLJIPPEIOBO(IDEBKDPMPGM: true);
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf((GHPGNELIDBM)6);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 865f;
				LHAAAIGMEBK.FOCIOKMPCAG.Refill();
				LHAAAIGMEBK.KIIHLIPAGIH = false;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.MBECPMJFIHB();
				PNBNBGCNMCF.PADBFAIBBDG = 1;
				PNBNBGCNMCF.MGECHKCAELH = false;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = true;
				PHDOCKCBJOF = new WaitForRealSeconds(1342f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 4u:
				Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.GoldExpCoefficient).FLOATVALUE;
				Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-29)).FLOATVALUE;
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().MDBPINJMNKO.NHOKPBAKMKL(IDEBKDPMPGM: false);
				DeathMatchUnitsGuiElement.BCDJJBAFLLG().MDBPINJMNKO.OIADGFDOPJM();
				PHDOCKCBJOF = new WaitForRealSeconds(352f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 5u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				PHDOCKCBJOF = new WaitForRealSeconds(1629f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.ThrowGrenade()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 7u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheck(56f)));
				PHDOCKCBJOF = new WaitForRealSeconds(1784f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 8u:
				CEDLJPOCKED = true;
				MCAKMECBJNA = 0;
				if (BJGCPDNMHDH.mSniperRifleShots == 0)
				{
					CEDLJPOCKED = true;
					MCAKMECBJNA = (int)TimeManager.realTimeWithoutPauses;
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SniperExplain()));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 54;
					}
					break;
				}
				goto IL_038d;
			case 9u:
				MCAKMECBJNA = Mathf.Abs((int)TimeManager.CEAFAMFNGCC() - MCAKMECBJNA);
				goto IL_038d;
			default:
				{
					return true;
				}
				IL_038d:
				PlayerController.GetEnemyOf((GHPGNELIDBM)8).KIIHLIPAGIH = true;
				Singleton<EventTrackingManager>.instance.RegisterTutorialSniperShootEvent("Battle_End_Dialog", CEDLJPOCKED, MCAKMECBJNA);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void HANDHJHGLAP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void OLPILJFHMGD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool GMBFJOBKMMN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				BJGCPDNMHDH.mGameStarted = true;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("LeagueId");
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 1980f;
				Singleton<SpawningManagerDeathMatch>.instance.OLJIPPEIOBO(IDEBKDPMPGM: true);
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf((GHPGNELIDBM)4);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 1371f;
				LHAAAIGMEBK.FOCIOKMPCAG.OEAGCMGINCB();
				LHAAAIGMEBK.KIIHLIPAGIH = true;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.GetWeakBotConfig();
				PNBNBGCNMCF.PADBFAIBBDG = 8;
				PNBNBGCNMCF.MGECHKCAELH = true;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = false;
				PHDOCKCBJOF = new WaitForRealSeconds(1867f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 4u:
				Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-2)).FLOATVALUE;
				Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SilverPackMaxRarityCardsType).FLOATVALUE;
				DeathMatchUnitsGuiElement.BLHCFKIELCA().MDBPINJMNKO.PJFDIEGEGAC(IDEBKDPMPGM: true);
				DeathMatchUnitsGuiElement.instance.MDBPINJMNKO.KLPHMIGJLCG();
				PHDOCKCBJOF = new WaitForRealSeconds(1880f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 5u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				PHDOCKCBJOF = new WaitForRealSeconds(702f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.ThrowGrenade()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 7u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheck(1095f)));
				PHDOCKCBJOF = new WaitForRealSeconds(1329f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 8u:
				CEDLJPOCKED = true;
				MCAKMECBJNA = 1;
				if (BJGCPDNMHDH.mSniperRifleShots == 0)
				{
					CEDLJPOCKED = true;
					MCAKMECBJNA = (int)TimeManager.realTimeWithoutPauses;
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SniperExplain()));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -114;
					}
					break;
				}
				goto IL_038d;
			case 9u:
				MCAKMECBJNA = Mathf.Abs((int)TimeManager.realTimeWithoutPauses - MCAKMECBJNA);
				goto IL_038d;
			default:
				{
					return false;
				}
				IL_038d:
				PlayerController.GetEnemyOf(GHPGNELIDBM.Allies).KIIHLIPAGIH = false;
				Singleton<EventTrackingManager>.instance.RegisterTutorialSniperShootEvent("Shots_Fired", CEDLJPOCKED, MCAKMECBJNA);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object OIBJFPCIHIL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DAAINALAFOJ()
		{
			return PHDOCKCBJOF;
		}

		public bool HEHJAEIGHDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				BJGCPDNMHDH.mGameStarted = false;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_WAITINGFORLOOTBOX");
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 326f;
				Singleton<SpawningManagerDeathMatch>.instance.autoDeployEnabled = false;
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf((GHPGNELIDBM)6);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 928f;
				LHAAAIGMEBK.FOCIOKMPCAG.Refill();
				LHAAAIGMEBK.KIIHLIPAGIH = true;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.DMIECFDHMKN();
				PNBNBGCNMCF.PADBFAIBBDG = 3;
				PNBNBGCNMCF.MGECHKCAELH = false;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = false;
				PHDOCKCBJOF = new WaitForRealSeconds(561f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 4u:
				Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.ServerRentalWoUDelayMax).FLOATVALUE;
				Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.ServerRentalWoUDelayMax).FLOATVALUE;
				DeathMatchUnitsGuiElement.BLHCFKIELCA().MDBPINJMNKO.NHOKPBAKMKL(IDEBKDPMPGM: false);
				DeathMatchUnitsGuiElement.BLHCFKIELCA().MDBPINJMNKO.HDOFLJONIFH();
				PHDOCKCBJOF = new WaitForRealSeconds(1242f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 5u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				PHDOCKCBJOF = new WaitForRealSeconds(196f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.ThrowGrenade()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 7u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheck(1898f)));
				PHDOCKCBJOF = new WaitForRealSeconds(925f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 8u:
				CEDLJPOCKED = false;
				MCAKMECBJNA = 0;
				if (BJGCPDNMHDH.mSniperRifleShots == 0)
				{
					CEDLJPOCKED = false;
					MCAKMECBJNA = (int)TimeManager.realTimeWithoutPauses;
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SniperExplain()));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 108;
					}
					break;
				}
				goto IL_038d;
			case 9u:
				MCAKMECBJNA = Mathf.Abs((int)TimeManager.realTimeWithoutPauses - MCAKMECBJNA);
				goto IL_038d;
			default:
				{
					return true;
				}
				IL_038d:
				PlayerController.GetEnemyOf(GHPGNELIDBM.Enemies).KIIHLIPAGIH = false;
				Singleton<EventTrackingManager>.instance.RegisterTutorialSniperShootEvent("ID_OVERALL", CEDLJPOCKED, MCAKMECBJNA);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void HDDLDAHLPCO()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void AKEKFBGEJBG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object FBPFPJOCKGD()
		{
			return PHDOCKCBJOF;
		}

		public void JMANMKKCDMM()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KLEHMEIAJHO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DGEECEBHPNC()
		{
			return PHDOCKCBJOF;
		}

		public bool DKIKFMODFJF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				BJGCPDNMHDH.mGameStarted = true;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("PurchaseVerification(");
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 1734f;
				Singleton<SpawningManagerDeathMatch>.instance.autoDeployEnabled = false;
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf((GHPGNELIDBM)8);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 316f;
				LHAAAIGMEBK.FOCIOKMPCAG.APJEBOPJPLA();
				LHAAAIGMEBK.KIIHLIPAGIH = false;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.DMIECFDHMKN();
				PNBNBGCNMCF.PADBFAIBBDG = 4;
				PNBNBGCNMCF.MGECHKCAELH = false;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = false;
				PHDOCKCBJOF = new WaitForRealSeconds(556f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 4u:
				Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-78)).FLOATVALUE;
				Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-121)).FLOATVALUE;
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().MDBPINJMNKO.PPGEPMHPNDB(IDEBKDPMPGM: false);
				DeathMatchUnitsGuiElement.instance.MDBPINJMNKO.HFNPJIMLJNG();
				PHDOCKCBJOF = new WaitForRealSeconds(1990f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 5u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				PHDOCKCBJOF = new WaitForRealSeconds(1460f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.ThrowGrenade()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 7u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheck(1140f)));
				PHDOCKCBJOF = new WaitForRealSeconds(1110f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 8u:
				CEDLJPOCKED = true;
				MCAKMECBJNA = 0;
				if (BJGCPDNMHDH.mSniperRifleShots == 0)
				{
					CEDLJPOCKED = false;
					MCAKMECBJNA = (int)TimeManager.CEAFAMFNGCC();
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SniperExplain()));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -101;
					}
					break;
				}
				goto IL_038d;
			case 9u:
				MCAKMECBJNA = Mathf.Abs((int)TimeManager.realTimeWithoutPauses - MCAKMECBJNA);
				goto IL_038d;
			default:
				{
					return false;
				}
				IL_038d:
				PlayerController.GetEnemyOf((GHPGNELIDBM)7).KIIHLIPAGIH = true;
				Singleton<EventTrackingManager>.instance.RegisterTutorialSniperShootEvent("otherInfo", CEDLJPOCKED, MCAKMECBJNA);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public bool PJJPPMIBNLN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				BJGCPDNMHDH.mGameStarted = true;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("AtlasPreparer.LoadCommonCoroutine");
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 942f;
				Singleton<SpawningManagerDeathMatch>.instance.autoDeployEnabled = false;
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf((GHPGNELIDBM)5);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 1087f;
				LHAAAIGMEBK.FOCIOKMPCAG.Refill();
				LHAAAIGMEBK.KIIHLIPAGIH = true;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.DMIECFDHMKN();
				PNBNBGCNMCF.PADBFAIBBDG = 2;
				PNBNBGCNMCF.MGECHKCAELH = true;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = true;
				PHDOCKCBJOF = new WaitForRealSeconds(87f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 4u:
				Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GooglePlayLoginReward).FLOATVALUE;
				Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-56)).FLOATVALUE;
				DeathMatchUnitsGuiElement.BLHCFKIELCA().MDBPINJMNKO.PPGEPMHPNDB(IDEBKDPMPGM: false);
				DeathMatchUnitsGuiElement.BLHCFKIELCA().MDBPINJMNKO.HDOFLJONIFH();
				PHDOCKCBJOF = new WaitForRealSeconds(1636f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 5u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				PHDOCKCBJOF = new WaitForRealSeconds(1847f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.ThrowGrenade()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 7u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheck(538f)));
				PHDOCKCBJOF = new WaitForRealSeconds(812f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 8u:
				CEDLJPOCKED = false;
				MCAKMECBJNA = 1;
				if (BJGCPDNMHDH.mSniperRifleShots == 0)
				{
					CEDLJPOCKED = true;
					MCAKMECBJNA = (int)TimeManager.CEAFAMFNGCC();
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SniperExplain()));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -41;
					}
					break;
				}
				goto IL_038d;
			case 9u:
				MCAKMECBJNA = Mathf.Abs((int)TimeManager.realTimeWithoutPauses - MCAKMECBJNA);
				goto IL_038d;
			default:
				{
					return true;
				}
				IL_038d:
				PlayerController.GetEnemyOf((GHPGNELIDBM)3).KIIHLIPAGIH = true;
				Singleton<EventTrackingManager>.instance.RegisterTutorialSniperShootEvent("getIsPayingUser", CEDLJPOCKED, MCAKMECBJNA);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public void IKNKDDMLDIN()
		{
			throw new NotSupportedException();
		}

		public void IPKNPABKAJD()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public EEBKAGLDPHL()
		{
		}

		public void HKFEFDNFKKK()
		{
			throw new NotSupportedException();
		}

		public bool GBHCODKDPBO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				BJGCPDNMHDH.mGameStarted = false;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("WarFriends precisa de permissão para aceder seus arquivos de mídia para baixar dados críticos do jogo.Sem essa permissão o jogo não poderá funcionar e será encerrado. Por favor, tente novamente ou saia de WarFriends.");
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 1309f;
				Singleton<SpawningManagerDeathMatch>.instance.KPGIELJBLEH(IDEBKDPMPGM: false);
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf(GHPGNELIDBM.None);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 71f;
				LHAAAIGMEBK.FOCIOKMPCAG.APJEBOPJPLA();
				LHAAAIGMEBK.KIIHLIPAGIH = true;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.DMIECFDHMKN();
				PNBNBGCNMCF.PADBFAIBBDG = 5;
				PNBNBGCNMCF.MGECHKCAELH = false;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = false;
				PHDOCKCBJOF = new WaitForRealSeconds(1412f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 4u:
				Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-107)).FLOATVALUE;
				Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-112)).FLOATVALUE;
				DeathMatchUnitsGuiElement.BCDJJBAFLLG().MDBPINJMNKO.PPGEPMHPNDB(IDEBKDPMPGM: true);
				DeathMatchUnitsGuiElement.instance.MDBPINJMNKO.InstantUpdate();
				PHDOCKCBJOF = new WaitForRealSeconds(363f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 5u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				PHDOCKCBJOF = new WaitForRealSeconds(1557f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.ThrowGrenade()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 7u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheck(619f)));
				PHDOCKCBJOF = new WaitForRealSeconds(1596f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 8u:
				CEDLJPOCKED = false;
				MCAKMECBJNA = 1;
				if (BJGCPDNMHDH.mSniperRifleShots == 0)
				{
					CEDLJPOCKED = true;
					MCAKMECBJNA = (int)TimeManager.CEAFAMFNGCC();
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SniperExplain()));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 100;
					}
					break;
				}
				goto IL_038d;
			case 9u:
				MCAKMECBJNA = Mathf.Abs((int)TimeManager.CEAFAMFNGCC() - MCAKMECBJNA);
				goto IL_038d;
			default:
				{
					return true;
				}
				IL_038d:
				PlayerController.GetEnemyOf((GHPGNELIDBM)3).KIIHLIPAGIH = false;
				Singleton<EventTrackingManager>.instance.RegisterTutorialSniperShootEvent("gained offer from fuse: {0}", CEDLJPOCKED, MCAKMECBJNA);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object MLCINLDHAGM()
		{
			return PHDOCKCBJOF;
		}

		public void IJHCIJLDKHK()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public bool FIBKLKNDFDO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				BJGCPDNMHDH.mGameStarted = true;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_MEMBERSHIP_HINT5");
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 1845f;
				Singleton<SpawningManagerDeathMatch>.instance.OLJIPPEIOBO(IDEBKDPMPGM: false);
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf((GHPGNELIDBM)3);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 1051f;
				LHAAAIGMEBK.FOCIOKMPCAG.APJEBOPJPLA();
				LHAAAIGMEBK.KIIHLIPAGIH = true;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.MBECPMJFIHB();
				PNBNBGCNMCF.PADBFAIBBDG = 5;
				PNBNBGCNMCF.MGECHKCAELH = false;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = true;
				PHDOCKCBJOF = new WaitForRealSeconds(1516f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 4u:
				Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.WinstreakReward1).FLOATVALUE;
				Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-104)).FLOATVALUE;
				DeathMatchUnitsGuiElement.instance.MDBPINJMNKO.GAODJMFOOHM(IDEBKDPMPGM: false);
				DeathMatchUnitsGuiElement.instance.MDBPINJMNKO.CLLJEINIGBL();
				PHDOCKCBJOF = new WaitForRealSeconds(1056f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 5u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				PHDOCKCBJOF = new WaitForRealSeconds(1534f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.ThrowGrenade()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 7u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheck(1814f)));
				PHDOCKCBJOF = new WaitForRealSeconds(170f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 8u:
				CEDLJPOCKED = false;
				MCAKMECBJNA = 1;
				if (BJGCPDNMHDH.mSniperRifleShots == 0)
				{
					CEDLJPOCKED = true;
					MCAKMECBJNA = (int)TimeManager.CEAFAMFNGCC();
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SniperExplain()));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -48;
					}
					break;
				}
				goto IL_038d;
			case 9u:
				MCAKMECBJNA = Mathf.Abs((int)TimeManager.realTimeWithoutPauses - MCAKMECBJNA);
				goto IL_038d;
			default:
				{
					return false;
				}
				IL_038d:
				PlayerController.GetEnemyOf((GHPGNELIDBM)7).KIIHLIPAGIH = true;
				Singleton<EventTrackingManager>.instance.RegisterTutorialSniperShootEvent(" Desc without HINT = ", CEDLJPOCKED, MCAKMECBJNA);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void DOPCGPGKHIJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void ODJLLLFJIOB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object EDBIJNJGFLE()
		{
			return PHDOCKCBJOF;
		}

		public void CPFFPONIFOM()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void FDCPBGNCKHH()
		{
			throw new NotSupportedException();
		}

		public void BCIPEBNJONK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MHFEOEIHFDC()
		{
			return PHDOCKCBJOF;
		}

		public void ODCIKOOGNFG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void HLDMODAFJBO()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void GICFBDJLDKF()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool DNDHHHDOLMO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				BJGCPDNMHDH.mGameStarted = false;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_WARNING_CONNECTIONERROR");
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 1465f;
				Singleton<SpawningManagerDeathMatch>.instance.KPGIELJBLEH(IDEBKDPMPGM: false);
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf(GHPGNELIDBM.None);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 1176f;
				LHAAAIGMEBK.FOCIOKMPCAG.Refill();
				LHAAAIGMEBK.KIIHLIPAGIH = false;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.MBECPMJFIHB();
				PNBNBGCNMCF.PADBFAIBBDG = 1;
				PNBNBGCNMCF.MGECHKCAELH = true;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = false;
				PHDOCKCBJOF = new WaitForRealSeconds(694f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 4u:
				Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.DogTagRefillTime).FLOATVALUE;
				Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.RateAppReward).FLOATVALUE;
				DeathMatchUnitsGuiElement.instance.MDBPINJMNKO.PJFDIEGEGAC(IDEBKDPMPGM: false);
				DeathMatchUnitsGuiElement.BLHCFKIELCA().MDBPINJMNKO.KAHGINIEOFF();
				PHDOCKCBJOF = new WaitForRealSeconds(0f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 5u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				PHDOCKCBJOF = new WaitForRealSeconds(331f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.ThrowGrenade()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 7u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheck(1402f)));
				PHDOCKCBJOF = new WaitForRealSeconds(366f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 8u:
				CEDLJPOCKED = false;
				MCAKMECBJNA = 1;
				if (BJGCPDNMHDH.mSniperRifleShots == 0)
				{
					CEDLJPOCKED = true;
					MCAKMECBJNA = (int)TimeManager.CEAFAMFNGCC();
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SniperExplain()));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 77;
					}
					break;
				}
				goto IL_038d;
			case 9u:
				MCAKMECBJNA = Mathf.Abs((int)TimeManager.CEAFAMFNGCC() - MCAKMECBJNA);
				goto IL_038d;
			default:
				{
					return false;
				}
				IL_038d:
				PlayerController.GetEnemyOf((GHPGNELIDBM)5).KIIHLIPAGIH = false;
				Singleton<EventTrackingManager>.instance.RegisterTutorialSniperShootEvent("Invitations", CEDLJPOCKED, MCAKMECBJNA);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void OJDEHKDDLFD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object IFDMDGBPDKD()
		{
			return PHDOCKCBJOF;
		}

		public void GBGMIJNBLNH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void ENCGDFIIGNH()
		{
			throw new NotSupportedException();
		}

		public void KINGACOICNF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void LDBAMIKAGHC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool HOJKAHEGFEB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				BJGCPDNMHDH.mGameStarted = false;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("《WarFriends》需要再多下載大約190MB的資料才能運作。\n下載時間將依你的網路與所在位置有所不同。\n\n想要繼續嗎？");
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 1858f;
				Singleton<SpawningManagerDeathMatch>.instance.OLJIPPEIOBO(IDEBKDPMPGM: true);
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf((GHPGNELIDBM)3);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 1926f;
				LHAAAIGMEBK.FOCIOKMPCAG.OEAGCMGINCB();
				LHAAAIGMEBK.KIIHLIPAGIH = true;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.MBECPMJFIHB();
				PNBNBGCNMCF.PADBFAIBBDG = 1;
				PNBNBGCNMCF.MGECHKCAELH = true;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = true;
				PHDOCKCBJOF = new WaitForRealSeconds(1872f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 4u:
				Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-92)).FLOATVALUE;
				Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-43)).FLOATVALUE;
				DeathMatchUnitsGuiElement.BLHCFKIELCA().MDBPINJMNKO.shouldUpdate = false;
				DeathMatchUnitsGuiElement.BLHCFKIELCA().MDBPINJMNKO.CLLJEINIGBL();
				PHDOCKCBJOF = new WaitForRealSeconds(970f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 5u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				PHDOCKCBJOF = new WaitForRealSeconds(1506f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.ThrowGrenade()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 7u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheck(1188f)));
				PHDOCKCBJOF = new WaitForRealSeconds(1543f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 8u:
				CEDLJPOCKED = false;
				MCAKMECBJNA = 1;
				if (BJGCPDNMHDH.mSniperRifleShots == 0)
				{
					CEDLJPOCKED = true;
					MCAKMECBJNA = (int)TimeManager.realTimeWithoutPauses;
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SniperExplain()));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -49;
					}
					break;
				}
				goto IL_038d;
			case 9u:
				MCAKMECBJNA = Mathf.Abs((int)TimeManager.CEAFAMFNGCC() - MCAKMECBJNA);
				goto IL_038d;
			default:
				{
					return true;
				}
				IL_038d:
				PlayerController.GetEnemyOf(GHPGNELIDBM.Enemies).KIIHLIPAGIH = true;
				Singleton<EventTrackingManager>.instance.RegisterTutorialSniperShootEvent("throw_grenade_left", CEDLJPOCKED, MCAKMECBJNA);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		[SpecialName]
		private object IGMIIAODMNF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HNBOIMNNPOH()
		{
			return PHDOCKCBJOF;
		}

		public void LHADJAFHDDC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MPHILJJDNIO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MHKODCGLJFD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JMKGAJNOLEM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PKEABJICHAI()
		{
			return PHDOCKCBJOF;
		}

		public void GIAIFFPNMPJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JJBAIMILGLK()
		{
			return PHDOCKCBJOF;
		}

		public void EJNCMFMOBAJ()
		{
			throw new NotSupportedException();
		}

		public void PDNKLJFHBGO()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BGAGLOJHMEJ()
		{
			return PHDOCKCBJOF;
		}

		public bool CGOKGPGALLH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				BJGCPDNMHDH.mGameStarted = true;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("game-card-ico-healingstorm");
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 1290f;
				Singleton<SpawningManagerDeathMatch>.instance.OLJIPPEIOBO(IDEBKDPMPGM: true);
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf((GHPGNELIDBM)3);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 906f;
				LHAAAIGMEBK.FOCIOKMPCAG.OEAGCMGINCB();
				LHAAAIGMEBK.KIIHLIPAGIH = false;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.MBECPMJFIHB();
				PNBNBGCNMCF.PADBFAIBBDG = 1;
				PNBNBGCNMCF.MGECHKCAELH = false;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = true;
				PHDOCKCBJOF = new WaitForRealSeconds(1296f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 4u:
				Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldenSuitcase_VIPRewardDuration).FLOATVALUE;
				Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.NotificationAllowWinsNeed).FLOATVALUE;
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().MDBPINJMNKO.BDHPCMOGAHF(IDEBKDPMPGM: true);
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().MDBPINJMNKO.CLLJEINIGBL();
				PHDOCKCBJOF = new WaitForRealSeconds(1081f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 5u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				PHDOCKCBJOF = new WaitForRealSeconds(370f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.ThrowGrenade()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 7u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheck(36f)));
				PHDOCKCBJOF = new WaitForRealSeconds(209f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 8u:
				CEDLJPOCKED = false;
				MCAKMECBJNA = 0;
				if (BJGCPDNMHDH.mSniperRifleShots == 0)
				{
					CEDLJPOCKED = true;
					MCAKMECBJNA = (int)TimeManager.CEAFAMFNGCC();
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SniperExplain()));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 99;
					}
					break;
				}
				goto IL_038d;
			case 9u:
				MCAKMECBJNA = Mathf.Abs((int)TimeManager.realTimeWithoutPauses - MCAKMECBJNA);
				goto IL_038d;
			default:
				{
					return false;
				}
				IL_038d:
				PlayerController.GetEnemyOf((GHPGNELIDBM)6).KIIHLIPAGIH = false;
				Singleton<EventTrackingManager>.instance.RegisterTutorialSniperShootEvent(",", CEDLJPOCKED, MCAKMECBJNA);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public bool MKCOLOBIAAP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				BJGCPDNMHDH.mGameStarted = true;
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Grenade_Throwing_Tutorial_Duration");
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 1046f;
				Singleton<SpawningManagerDeathMatch>.instance.autoDeployEnabled = false;
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf(GHPGNELIDBM.Allies);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 109f;
				LHAAAIGMEBK.FOCIOKMPCAG.OEAGCMGINCB();
				LHAAAIGMEBK.KIIHLIPAGIH = true;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.MBECPMJFIHB();
				PNBNBGCNMCF.PADBFAIBBDG = 6;
				PNBNBGCNMCF.MGECHKCAELH = false;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = false;
				PHDOCKCBJOF = new WaitForRealSeconds(397f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 4u:
				Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-85)).FLOATVALUE;
				Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-64)).FLOATVALUE;
				DeathMatchUnitsGuiElement.BLHCFKIELCA().MDBPINJMNKO.NHOKPBAKMKL(IDEBKDPMPGM: false);
				DeathMatchUnitsGuiElement.BLHCFKIELCA().MDBPINJMNKO.LIHDDPHJNOG();
				PHDOCKCBJOF = new WaitForRealSeconds(1204f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 5u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				PHDOCKCBJOF = new WaitForRealSeconds(1447f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.ThrowGrenade()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 7u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheck(673f)));
				PHDOCKCBJOF = new WaitForRealSeconds(560f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 8u:
				CEDLJPOCKED = true;
				MCAKMECBJNA = 1;
				if (BJGCPDNMHDH.mSniperRifleShots == 0)
				{
					CEDLJPOCKED = true;
					MCAKMECBJNA = (int)TimeManager.realTimeWithoutPauses;
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SniperExplain()));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -113;
					}
					break;
				}
				goto IL_038d;
			case 9u:
				MCAKMECBJNA = Mathf.Abs((int)TimeManager.realTimeWithoutPauses - MCAKMECBJNA);
				goto IL_038d;
			default:
				{
					return true;
				}
				IL_038d:
				PlayerController.GetEnemyOf((GHPGNELIDBM)3).KIIHLIPAGIH = true;
				Singleton<EventTrackingManager>.instance.RegisterTutorialSniperShootEvent("UpdateHeadScaleRPC", CEDLJPOCKED, MCAKMECBJNA);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}
	}

	private sealed class CCBNMMIKEHF : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal TutorialManagerStage2 BJGCPDNMHDH;

		internal object PHDOCKCBJOF;

		internal bool FDKOKMKIIMG;

		internal int CLPPIAGLCJJ;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		[SpecialName]
		private object KBNAGKKMLBP()
		{
			return PHDOCKCBJOF;
		}

		public void PDKPELBIAON()
		{
			throw new NotSupportedException();
		}

		public bool IEDGDDDADFM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Singleton<GameController>.instance.CBAPHFGNLLH.time > 758f)
				{
					PHDOCKCBJOF = new WaitForSeconds(1072f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("如不下载这些额外数据，《战争之友》将无法运行。您希望退出还是下载这些数据？");
				Singleton<MatchManager>.instance.INNLJEMFICP(PlayerController.OGMBJPKOPCB, Singleton<GameController>.instance.opponent);
				PHDOCKCBJOF = new WaitForSeconds(1407f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 2u:
				TimeManager.FODFANEEDFF();
				GuiElementSingle<TutorialDialog>.instance.BLHEPOBPHPK("Player connectionState {0} to player {1}", string.Empty, 1446f, TutorialDialog.DODBDLEJOAM.BottomLeft, BBGAMLLOING: true, BEBMEBEJIOB: true);
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				BJGCPDNMHDH.data.overtimeShowed = true;
				BJGCPDNMHDH.Save();
				goto case 3u;
			case 3u:
				if (!GuiElementSingle<TutorialDialog>.instance.GDAIHLIGAKP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_ELITEPACK_WEAPONDESCRIPTION");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				TimeManager.UnFreezeGame(614f);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void DLIBOPAMHAN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool MKLIDMNLNPN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Singleton<GameController>.instance.CBAPHFGNLLH.time > 1600f)
				{
					PHDOCKCBJOF = new WaitForSeconds(1828f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("shootAdditive");
				Singleton<MatchManager>.instance.StartOverTime(PlayerController.OGMBJPKOPCB, Singleton<GameController>.instance.opponent);
				PHDOCKCBJOF = new WaitForSeconds(1001f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 2u:
				TimeManager.FreezeGame();
				GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("level", string.Empty, 367f, TutorialDialog.DODBDLEJOAM.Bottom, BBGAMLLOING: false, BEBMEBEJIOB: true);
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				BJGCPDNMHDH.data.overtimeShowed = true;
				BJGCPDNMHDH.Save();
				goto case 3u;
			case 3u:
				if (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Null +");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				TimeManager.UnFreezeGame(431f);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void OEMOMDILPEE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool LPCBKGKFNFD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Singleton<GameController>.instance.CBAPHFGNLLH.time > 509f)
				{
					PHDOCKCBJOF = new WaitForSeconds(1289f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ArenaLootbox");
				Singleton<MatchManager>.instance.StartOverTime(PlayerController.OGMBJPKOPCB, Singleton<GameController>.instance.opponent);
				PHDOCKCBJOF = new WaitForSeconds(659f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 2u:
				TimeManager.DCODDANOPCP();
				GuiElementSingle<TutorialDialog>.instance.DDFADDKPPDI("com/google/android/gms/common/api/Status", string.Empty, 1062f, TutorialDialog.DODBDLEJOAM.Bottom, BBGAMLLOING: true);
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				BJGCPDNMHDH.data.overtimeShowed = false;
				BJGCPDNMHDH.Save();
				goto case 3u;
			case 3u:
				if (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("PlayerId");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				TimeManager.UnFreezeGame(1493f);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void IBDAHMOEBCM()
		{
			throw new NotSupportedException();
		}

		public bool HNCDLFFBMAA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Singleton<GameController>.instance.CBAPHFGNLLH.time > 1967f)
				{
					PHDOCKCBJOF = new WaitForSeconds(450f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_XARENATICKETS");
				Singleton<MatchManager>.instance.StartOverTime(PlayerController.OGMBJPKOPCB, Singleton<GameController>.instance.opponent);
				PHDOCKCBJOF = new WaitForSeconds(442f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
				TimeManager.DCODDANOPCP();
				GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("Overtime_Was_Already_Explained", string.Empty, 691f, TutorialDialog.DODBDLEJOAM.Top, BBGAMLLOING: true);
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				BJGCPDNMHDH.data.overtimeShowed = true;
				BJGCPDNMHDH.Save();
				goto case 3u;
			case 3u:
				if (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_WARNING_NOTENOUGHSCRAPS");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				TimeManager.UnFreezeGame(1356f);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object MPHILJJDNIO()
		{
			return PHDOCKCBJOF;
		}

		public void MDBDGOJADJM()
		{
			throw new NotSupportedException();
		}

		public void LICALBFPBLL()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KKKMCHGLHLL()
		{
			return PHDOCKCBJOF;
		}

		public void LPKDPNHBLGJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool FPMHODJKAKK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Singleton<GameController>.instance.CBAPHFGNLLH.time > 1478f)
				{
					PHDOCKCBJOF = new WaitForSeconds(560f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("GameDataReceived(");
				Singleton<MatchManager>.instance.INNLJEMFICP(PlayerController.OGMBJPKOPCB, Singleton<GameController>.instance.opponent);
				PHDOCKCBJOF = new WaitForSeconds(866f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
				TimeManager.FODFANEEDFF();
				GuiElementSingle<TutorialDialog>.instance.DDFADDKPPDI("ID_SQUADPLACE", string.Empty, 1458f, TutorialDialog.DODBDLEJOAM.TopRight);
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				BJGCPDNMHDH.data.overtimeShowed = true;
				BJGCPDNMHDH.Save();
				goto case 3u;
			case 3u:
				if (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Sniper_Tutorial_Played");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				TimeManager.UnFreezeGame(239f);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object JPJBNHHKOJD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ELNKFJHGFPD()
		{
			return PHDOCKCBJOF;
		}

		public void NAMBILMHOPD()
		{
			throw new NotSupportedException();
		}

		public void JMANMKKCDMM()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GENJNMACGLP()
		{
			return PHDOCKCBJOF;
		}

		public void BLOCBAKBHBF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object INAMGPNDAAJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AAIGGFHFBIC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AIDHNJCPDIJ()
		{
			return PHDOCKCBJOF;
		}

		public void FGLAPPKJHBK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GJMNLPAEIDA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BJJNGPKNCKJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ALJCBJBHLMK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LDBICDEEENB()
		{
			return PHDOCKCBJOF;
		}

		public bool KIFNNJFJJCG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Singleton<GameController>.instance.CBAPHFGNLLH.time > 182f)
				{
					PHDOCKCBJOF = new WaitForSeconds(1468f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("fire");
				Singleton<MatchManager>.instance.INNLJEMFICP(PlayerController.OGMBJPKOPCB, Singleton<GameController>.instance.opponent);
				PHDOCKCBJOF = new WaitForSeconds(1196f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 2u:
				TimeManager.FreezeGame();
				GuiElementSingle<TutorialDialog>.instance.KOGOLIJLMDN("ID_BLACKMARKETLEFTTEXT1", string.Empty, 629f, TutorialDialog.DODBDLEJOAM.BottomLeft);
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				BJGCPDNMHDH.data.overtimeShowed = true;
				BJGCPDNMHDH.Save();
				goto case 3u;
			case 3u:
				if (!GuiElementSingle<TutorialDialog>.instance.GDAIHLIGAKP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_CANCEL");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				TimeManager.UnFreezeGame(1718f);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void GGMKKIDFJOH()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BJDOHADMIEB()
		{
			return PHDOCKCBJOF;
		}

		public bool PKOMECFNPIP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Singleton<GameController>.instance.CBAPHFGNLLH.time > 1524f)
				{
					PHDOCKCBJOF = new WaitForSeconds(1734f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("InAppHandlerIos: product list fail, message = ");
				Singleton<MatchManager>.instance.StartOverTime(PlayerController.OGMBJPKOPCB, Singleton<GameController>.instance.opponent);
				PHDOCKCBJOF = new WaitForSeconds(1565f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 2u:
				TimeManager.DCODDANOPCP();
				GuiElementSingle<TutorialDialog>.instance.BLHEPOBPHPK("GLM: current player is null while adding FB account!!", string.Empty, 567f, TutorialDialog.DODBDLEJOAM.Bottom, BBGAMLLOING: true);
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				BJGCPDNMHDH.data.overtimeShowed = true;
				BJGCPDNMHDH.Save();
				goto case 3u;
			case 3u:
				if (!GuiElementSingle<TutorialDialog>.instance.GDAIHLIGAKP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("IsWarArena");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				TimeManager.UnFreezeGame(212f);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object GAPDDGJNMPK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GEFKCGOOFFP()
		{
			return PHDOCKCBJOF;
		}

		public void PCNOHGFPMOE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void OGDMPCFMMML()
		{
			throw new NotSupportedException();
		}

		public bool JICHKPANPEE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Singleton<GameController>.instance.CBAPHFGNLLH.time > 1734f)
				{
					PHDOCKCBJOF = new WaitForSeconds(565f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Awaiting players - Removing player ");
				Singleton<MatchManager>.instance.StartOverTime(PlayerController.OGMBJPKOPCB, Singleton<GameController>.instance.opponent);
				PHDOCKCBJOF = new WaitForSeconds(464f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 2u:
				TimeManager.DCODDANOPCP();
				GuiElementSingle<TutorialDialog>.instance.KOGOLIJLMDN("Skill", string.Empty, 356f, TutorialDialog.DODBDLEJOAM.BottomRight, BBGAMLLOING: true, BEBMEBEJIOB: true);
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				BJGCPDNMHDH.data.overtimeShowed = false;
				BJGCPDNMHDH.Save();
				goto case 3u;
			case 3u:
				if (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Scenes Full Path: \"{0}\"\n");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				TimeManager.UnFreezeGame(1321f);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public bool IIJKAMFGNKA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Singleton<GameController>.instance.CBAPHFGNLLH.time > 1959f)
				{
					PHDOCKCBJOF = new WaitForSeconds(429f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("menu-gold");
				Singleton<MatchManager>.instance.INNLJEMFICP(PlayerController.OGMBJPKOPCB, Singleton<GameController>.instance.opponent);
				PHDOCKCBJOF = new WaitForSeconds(609f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 2u:
				TimeManager.FODFANEEDFF();
				GuiElementSingle<TutorialDialog>.instance.DDFADDKPPDI("Beanstalk: That account already exists! Player will choose how to proceed, provider = ", string.Empty, 165f, TutorialDialog.DODBDLEJOAM.TopRight, BBGAMLLOING: true, BEBMEBEJIOB: true);
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				BJGCPDNMHDH.data.overtimeShowed = false;
				BJGCPDNMHDH.Save();
				goto case 3u;
			case 3u:
				if (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Midnight");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				GuiElementSingle<TutorialDialog>.instance.Hide();
				TimeManager.UnFreezeGame(1106f);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object NOIDHHDEEPL()
		{
			return PHDOCKCBJOF;
		}

		public bool EBLHEEKHANA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Singleton<GameController>.instance.CBAPHFGNLLH.time > 382f)
				{
					PHDOCKCBJOF = new WaitForSeconds(26f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(", val = ");
				Singleton<MatchManager>.instance.StartOverTime(PlayerController.OGMBJPKOPCB, Singleton<GameController>.instance.opponent);
				PHDOCKCBJOF = new WaitForSeconds(534f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
				TimeManager.DCODDANOPCP();
				GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("C5", string.Empty, 841f, TutorialDialog.DODBDLEJOAM.BottomLeft, BBGAMLLOING: true);
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				BJGCPDNMHDH.data.overtimeShowed = true;
				BJGCPDNMHDH.Save();
				goto case 3u;
			case 3u:
				if (!GuiElementSingle<TutorialDialog>.instance.GDAIHLIGAKP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("getFriendsList");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				TimeManager.UnFreezeGame(1438f);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object LAENBDAPNJL()
		{
			return PHDOCKCBJOF;
		}

		public void NINFHADPHJI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool KHNDCDGBFJH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Singleton<GameController>.instance.CBAPHFGNLLH.time > 1804f)
				{
					PHDOCKCBJOF = new WaitForSeconds(567f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("RETRY");
				Singleton<MatchManager>.instance.INNLJEMFICP(PlayerController.OGMBJPKOPCB, Singleton<GameController>.instance.opponent);
				PHDOCKCBJOF = new WaitForSeconds(500f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 2u:
				TimeManager.DCODDANOPCP();
				GuiElementSingle<TutorialDialog>.instance.BLHEPOBPHPK("warArenaStart", string.Empty, 1605f, TutorialDialog.DODBDLEJOAM.Top);
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				BJGCPDNMHDH.data.overtimeShowed = false;
				BJGCPDNMHDH.Save();
				goto case 3u;
			case 3u:
				if (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_CONFIRM_UNKNOWNREASON");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				TimeManager.UnFreezeGame(1566f);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[DebuggerHidden]
		public CCBNMMIKEHF()
		{
		}

		[SpecialName]
		private object LMJBCDNGAHP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KLAPICIGNJB()
		{
			return PHDOCKCBJOF;
		}

		public void JKOCLGOOBEK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void DBEMHFEBPFM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void JDFJKNFDDGN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object FJGIOPMDPGA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KBEEEOJMBPG()
		{
			return PHDOCKCBJOF;
		}

		public bool BKJCILLNJLG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Singleton<GameController>.instance.CBAPHFGNLLH.time > 231f)
				{
					PHDOCKCBJOF = new WaitForSeconds(491f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Exception stacktrace: ");
				Singleton<MatchManager>.instance.INNLJEMFICP(PlayerController.OGMBJPKOPCB, Singleton<GameController>.instance.opponent);
				PHDOCKCBJOF = new WaitForSeconds(124f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 2u:
				TimeManager.FODFANEEDFF();
				GuiElementSingle<TutorialDialog>.instance.BLHEPOBPHPK("Automatic_Equip", string.Empty, 1412f, TutorialDialog.DODBDLEJOAM.Top, BBGAMLLOING: false, BEBMEBEJIOB: true);
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				BJGCPDNMHDH.data.overtimeShowed = false;
				BJGCPDNMHDH.Save();
				goto case 3u;
			case 3u:
				if (!GuiElementSingle<TutorialDialog>.instance.GDAIHLIGAKP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("PlayWarcardsAssignment complate at: ");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				GuiElementSingle<TutorialDialog>.instance.Hide();
				TimeManager.UnFreezeGame(449f);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void GICLICNJPBF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool FBMLBIOKKBE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Singleton<GameController>.instance.CBAPHFGNLLH.time > 933f)
				{
					PHDOCKCBJOF = new WaitForSeconds(439f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Target");
				Singleton<MatchManager>.instance.INNLJEMFICP(PlayerController.OGMBJPKOPCB, Singleton<GameController>.instance.opponent);
				PHDOCKCBJOF = new WaitForSeconds(1770f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 2u:
				TimeManager.FODFANEEDFF();
				GuiElementSingle<TutorialDialog>.instance.BLHEPOBPHPK("DogTagSeconds", string.Empty, 1312f, TutorialDialog.DODBDLEJOAM.BottomLeft, BBGAMLLOING: true);
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				BJGCPDNMHDH.data.overtimeShowed = true;
				BJGCPDNMHDH.Save();
				goto case 3u;
			case 3u:
				if (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Player_Had_To_Select_Grenade");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				GuiElementSingle<TutorialDialog>.instance.Hide();
				TimeManager.UnFreezeGame(774f);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void ONGBFFAENBP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool HDGDKCMIOGK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Singleton<GameController>.instance.CBAPHFGNLLH.time > 749f)
				{
					PHDOCKCBJOF = new WaitForSeconds(610f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("menu-weapon-mp5-elite");
				Singleton<MatchManager>.instance.StartOverTime(PlayerController.OGMBJPKOPCB, Singleton<GameController>.instance.opponent);
				PHDOCKCBJOF = new WaitForSeconds(1122f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 2u:
				TimeManager.FODFANEEDFF();
				GuiElementSingle<TutorialDialog>.instance.KOGOLIJLMDN("ID_FREEPERCENTLINE", string.Empty, 273f, TutorialDialog.DODBDLEJOAM.Left, BBGAMLLOING: false, BEBMEBEJIOB: true);
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				BJGCPDNMHDH.data.overtimeShowed = true;
				BJGCPDNMHDH.Save();
				goto case 3u;
			case 3u:
				if (!GuiElementSingle<TutorialDialog>.instance.GDAIHLIGAKP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("{0}{1}[-] / {2}");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				TimeManager.UnFreezeGame(695f);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void GEEKOICFEIB()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BBDOFDBCILK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BPKCMCDJOBF()
		{
			return PHDOCKCBJOF;
		}

		public void BICMFOEHHGN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool CJGKHIPOBGP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Singleton<GameController>.instance.CBAPHFGNLLH.time > 1054f)
				{
					PHDOCKCBJOF = new WaitForSeconds(1292f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Squad");
				Singleton<MatchManager>.instance.StartOverTime(PlayerController.OGMBJPKOPCB, Singleton<GameController>.instance.opponent);
				PHDOCKCBJOF = new WaitForSeconds(163f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
				TimeManager.FODFANEEDFF();
				GuiElementSingle<TutorialDialog>.instance.BLHEPOBPHPK("ID_CONFIRM_SERVERERROR", string.Empty, 917f, TutorialDialog.DODBDLEJOAM.Bottom, BBGAMLLOING: true);
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				BJGCPDNMHDH.data.overtimeShowed = true;
				BJGCPDNMHDH.Save();
				goto case 3u;
			case 3u:
				if (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("dailyRewardData");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				TimeManager.UnFreezeGame(761f);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void KNFDDIHLBKJ()
		{
			throw new NotSupportedException();
		}

		public void KGLKGNBCPLM()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void ENCGDFIIGNH()
		{
			throw new NotSupportedException();
		}

		public void PHEIGPKKPGE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BNMEIAPPLDP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OAMLLHEMBIK()
		{
			return PHDOCKCBJOF;
		}

		public void ODACICLOMHJ()
		{
			throw new NotSupportedException();
		}

		public bool EEJLFIHFDLK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Singleton<GameController>.instance.CBAPHFGNLLH.time > 1507f)
				{
					PHDOCKCBJOF = new WaitForSeconds(1037f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("This labels must be done manualy (add sprite spacer arround):\n");
				Singleton<MatchManager>.instance.StartOverTime(PlayerController.OGMBJPKOPCB, Singleton<GameController>.instance.opponent);
				PHDOCKCBJOF = new WaitForSeconds(1441f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 2u:
				TimeManager.DCODDANOPCP();
				GuiElementSingle<TutorialDialog>.instance.DDFADDKPPDI("com/google/android/gms/common/ConnectionResult", string.Empty, 852f, TutorialDialog.DODBDLEJOAM.Center, BBGAMLLOING: false, BEBMEBEJIOB: true);
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				BJGCPDNMHDH.data.overtimeShowed = true;
				BJGCPDNMHDH.Save();
				goto case 3u;
			case 3u:
				if (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("SquadId");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				GuiElementSingle<TutorialDialog>.instance.Hide();
				TimeManager.UnFreezeGame(205f);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Singleton<GameController>.instance.CBAPHFGNLLH.time > 0f)
				{
					PHDOCKCBJOF = new WaitForSeconds(1f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("208 OVERTIME");
				Singleton<MatchManager>.instance.StartOverTime(PlayerController.OGMBJPKOPCB, Singleton<GameController>.instance.opponent);
				PHDOCKCBJOF = new WaitForSeconds(1f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
				TimeManager.FreezeGame();
				GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("ID_TUTORIAL_OVERTIME", string.Empty, 0.3f, TutorialDialog.DODBDLEJOAM.Center, BBGAMLLOING: true);
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				BJGCPDNMHDH.data.overtimeShowed = true;
				BJGCPDNMHDH.Save();
				goto case 3u;
			case 3u:
				if (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("209 OVERTIME CONTINUE");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				GuiElementSingle<TutorialDialog>.instance.Hide();
				TimeManager.UnFreezeGame();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object KLEHMEIAJHO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FONIPEGACDN()
		{
			return PHDOCKCBJOF;
		}

		public bool LMNIKLKKIDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Singleton<GameController>.instance.CBAPHFGNLLH.time > 897f)
				{
					PHDOCKCBJOF = new WaitForSeconds(603f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("GameLoginManager: Logout from facebook");
				Singleton<MatchManager>.instance.StartOverTime(PlayerController.OGMBJPKOPCB, Singleton<GameController>.instance.opponent);
				PHDOCKCBJOF = new WaitForSeconds(431f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 2u:
				TimeManager.DCODDANOPCP();
				GuiElementSingle<TutorialDialog>.instance.DDFADDKPPDI("!!!ROTATED!!! ", string.Empty, 510f, TutorialDialog.DODBDLEJOAM.Right, BBGAMLLOING: true, BEBMEBEJIOB: true);
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				BJGCPDNMHDH.data.overtimeShowed = true;
				BJGCPDNMHDH.Save();
				goto case 3u;
			case 3u:
				if (!GuiElementSingle<TutorialDialog>.instance.GDAIHLIGAKP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_EARLYUNLOCK2");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				TimeManager.UnFreezeGame(603f);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object BMAMEPNHHFI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MBGCBKJBCND()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PGMPMBFDAAC()
		{
			return PHDOCKCBJOF;
		}

		public bool FNIOOIGJPAM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Singleton<GameController>.instance.CBAPHFGNLLH.time > 897f)
				{
					PHDOCKCBJOF = new WaitForSeconds(689f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("DogTagCap");
				Singleton<MatchManager>.instance.StartOverTime(PlayerController.OGMBJPKOPCB, Singleton<GameController>.instance.opponent);
				PHDOCKCBJOF = new WaitForSeconds(1814f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 2u:
				TimeManager.FODFANEEDFF();
				GuiElementSingle<TutorialDialog>.instance.DDFADDKPPDI("Mortar", string.Empty, 1702f, TutorialDialog.DODBDLEJOAM.Left, BBGAMLLOING: false, BEBMEBEJIOB: true);
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				BJGCPDNMHDH.data.overtimeShowed = true;
				BJGCPDNMHDH.Save();
				goto case 3u;
			case 3u:
				if (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("StartTime");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				TimeManager.UnFreezeGame(518f);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object LPMKMBAOMFP()
		{
			return PHDOCKCBJOF;
		}

		public void MAKKCANEHIB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void BPFAJJGHCCD()
		{
			throw new NotSupportedException();
		}

		public void BKGBMJMNJCD()
		{
			throw new NotSupportedException();
		}

		public bool PGOBEIMCPGA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Singleton<GameController>.instance.CBAPHFGNLLH.time > 1798f)
				{
					PHDOCKCBJOF = new WaitForSeconds(1460f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_PLAYRANKEDBATTLETOENTERLEAGUE");
				Singleton<MatchManager>.instance.INNLJEMFICP(PlayerController.OGMBJPKOPCB, Singleton<GameController>.instance.opponent);
				PHDOCKCBJOF = new WaitForSeconds(1379f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
				TimeManager.DCODDANOPCP();
				GuiElementSingle<TutorialDialog>.instance.BLHEPOBPHPK("Param", string.Empty, 1689f, TutorialDialog.DODBDLEJOAM.BottomRight);
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				BJGCPDNMHDH.data.overtimeShowed = false;
				BJGCPDNMHDH.Save();
				goto case 3u;
			case 3u:
				if (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_EXPIRED");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				TimeManager.UnFreezeGame(1689f);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object BMGHJKFMKJE()
		{
			return PHDOCKCBJOF;
		}

		public void ENFGGBNAPGG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object PNBPOAMPNKP()
		{
			return PHDOCKCBJOF;
		}

		public void HHPHMIJOAPL()
		{
			throw new NotSupportedException();
		}

		public void GFPAMDPNMKG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object OJANHAIEAEJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JFHOHPKEFGM()
		{
			return PHDOCKCBJOF;
		}

		public void GGCLMIMHKBD()
		{
			throw new NotSupportedException();
		}

		public void LDKFDMLPIOC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object AFDKAGLDADB()
		{
			return PHDOCKCBJOF;
		}

		public void IBLNBELFKNF()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HCHFFFPDMDA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void BOFEBMENOFC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool HOJKAHEGFEB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Singleton<GameController>.instance.CBAPHFGNLLH.time > 900f)
				{
					PHDOCKCBJOF = new WaitForSeconds(1611f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_FACEBOOKLOGOUTLEGALTEXT");
				Singleton<MatchManager>.instance.INNLJEMFICP(PlayerController.OGMBJPKOPCB, Singleton<GameController>.instance.opponent);
				PHDOCKCBJOF = new WaitForSeconds(927f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 2u:
				TimeManager.DCODDANOPCP();
				GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("ID_GUI_REPORTABUSE_LISTITEM1", string.Empty, 1032f, TutorialDialog.DODBDLEJOAM.Top, BBGAMLLOING: false, BEBMEBEJIOB: true);
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				BJGCPDNMHDH.data.overtimeShowed = true;
				BJGCPDNMHDH.Save();
				goto case 3u;
			case 3u:
				if (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Gold");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				TimeManager.UnFreezeGame(885f);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object FGFLGJECNLH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CPJCCMLEPCE()
		{
			return PHDOCKCBJOF;
		}

		public void IHAHCOPGPIM()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HJFIBBBPDKK()
		{
			return PHDOCKCBJOF;
		}
	}

	private sealed class GHIEJKBFMGP : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal object PHDOCKCBJOF;

		internal bool FDKOKMKIIMG;

		internal int CLPPIAGLCJJ;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		public bool MPKAJACHAIC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_GUI_JOINEDOURSQUAD");
				PHDOCKCBJOF = new WaitForRealSeconds(63f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				TimeManager.FreezeGame();
				GuiElementSingle<TutorialDialog>.instance.BLHEPOBPHPK("SetDepositedCards ", "null", 1527f, TutorialDialog.DODBDLEJOAM.Left, BBGAMLLOING: true);
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				GuiElementSingle<InventoryGuiElement>.instance.ShowHintText();
				goto case 2u;
			case 2u:
				if (!GuiElementSingle<TutorialDialog>.instance.GDAIHLIGAKP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_ERROR_SQUADSKILLCLAMP");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				TimeManager.UnFreezeGame(226f);
				GuiElementSingle<InventoryGuiElement>.instance.HideHintText();
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().Enable();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object FKKBFFHMEME()
		{
			return PHDOCKCBJOF;
		}

		public void GGCLMIMHKBD()
		{
			throw new NotSupportedException();
		}

		public void PHKDHCJBMII()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void AHEOCEEJICJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HIFNMHAGHLI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HCCLNDKNCIE()
		{
			return PHDOCKCBJOF;
		}

		public void FJOIBBIGBJC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object NOIDHHDEEPL()
		{
			return PHDOCKCBJOF;
		}

		public void GEEKOICFEIB()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void IFLGJMJCOMC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void LHADJAFHDDC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool HOOHJGPHHGN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_WARNING_POORCONNECTION_TEXT");
				PHDOCKCBJOF = new WaitForRealSeconds(706f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				TimeManager.DCODDANOPCP();
				GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("memoryWarnings", "Daily_mission_start_heroic", 1372f, TutorialDialog.DODBDLEJOAM.BottomLeft);
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				GuiElementSingle<InventoryGuiElement>.instance.ShowHintText();
				goto case 2u;
			case 2u:
				if (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Level");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				TimeManager.UnFreezeGame(663f);
				GuiElementSingle<InventoryGuiElement>.instance.NFPGIBJBMBG();
				DeathMatchUnitsGuiElement.instance.Enable();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object JJBAIMILGLK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FKPDNNMENFD()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public GHIEJKBFMGP()
		{
		}

		[SpecialName]
		private object KIHECHEHNJJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FBPFPJOCKGD()
		{
			return PHDOCKCBJOF;
		}

		public void DLIBOPAMHAN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object NDIGINEEOMH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IHPDPKLEDKC()
		{
			return PHDOCKCBJOF;
		}

		public void MKIKEOOOLKL()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("203 AUTOSPAWN STARTED");
				PHDOCKCBJOF = new WaitForRealSeconds(0.85f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				TimeManager.FreezeGame();
				GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("ID_TUTORIAL_FULL_ARSENAL", "ID_TUTORIAL_FULL_ARSENAL_DOWN", 0.3f, TutorialDialog.DODBDLEJOAM.Center, BBGAMLLOING: true);
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				GuiElementSingle<InventoryGuiElement>.instance.ShowHintText();
				goto case 2u;
			case 2u:
				if (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("204 AUTOSPAWN CONTINUE");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				GuiElementSingle<TutorialDialog>.instance.Hide();
				TimeManager.UnFreezeGame();
				GuiElementSingle<InventoryGuiElement>.instance.HideHintText();
				DeathMatchUnitsGuiElement.instance.Enable();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object BOOBHEKPLLD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MHKODCGLJFD()
		{
			return PHDOCKCBJOF;
		}
	}

	private sealed class LLMBOEIMOHG : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal object PHDOCKCBJOF;

		internal bool FDKOKMKIIMG;

		internal int CLPPIAGLCJJ;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		[SpecialName]
		private object BBOGBCNCIFN()
		{
			return PHDOCKCBJOF;
		}

		public void CNOEDCFDILG()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object EOKIMMCAABI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KBPOAPCEPBN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AFAOHBIDOJD()
		{
			return PHDOCKCBJOF;
		}

		public void LDKFDMLPIOC()
		{
			throw new NotSupportedException();
		}

		public void CHFJIODFNIP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void PDNKLJFHBGO()
		{
			throw new NotSupportedException();
		}

		public void FCHOHLMCHED()
		{
			throw new NotSupportedException();
		}

		public void EFKBIIPFDOM()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public LLMBOEIMOHG()
		{
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object AGCPJGAAODG()
		{
			return PHDOCKCBJOF;
		}

		public void FJOIBBIGBJC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void GFGEEFGMNDP()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object AKGMMLGANMJ()
		{
			return PHDOCKCBJOF;
		}

		public bool HCONPNNPBAD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (PlayerController.OGMBJPKOPCB.FMKGGADDHJK().LAGONJMBJMM[1].HFNAMMBPJAJ().ammoLeft < -85)
				{
					PlayerController.OGMBJPKOPCB.FMKGGADDHJK().LAGONJMBJMM[1].HFNAMMBPJAJ().ammoLeft = 21;
				}
				PHDOCKCBJOF = new WaitForRealSeconds(1340f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			default:
				return false;
			}
		}

		[SpecialName]
		private object FONIPEGACDN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KKCOHEHPJPF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IHDBAJNCNGN()
		{
			return PHDOCKCBJOF;
		}

		public void BLOCBAKBHBF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object AFDKAGLDADB()
		{
			return PHDOCKCBJOF;
		}

		public void ODJLLLFJIOB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool EJKHEELJJFM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[0].weapon.ammoLeft < 0)
				{
					PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[0].HFNAMMBPJAJ().ammoLeft = 111;
				}
				PHDOCKCBJOF = new WaitForRealSeconds(1023f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			default:
				return true;
			}
		}

		[SpecialName]
		private object HGOKAFJBFGJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PCELHKMHCOB()
		{
			return PHDOCKCBJOF;
		}

		public void HNBFJFDLABI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void OGDMPCFMMML()
		{
			throw new NotSupportedException();
		}

		public bool KIFNNJFJJCG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().LAGONJMBJMM[0].weapon.ammoLeft < 35)
				{
					PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().LAGONJMBJMM[1].HFNAMMBPJAJ().ammoLeft = 79;
				}
				PHDOCKCBJOF = new WaitForRealSeconds(412f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			default:
				return false;
			}
		}

		[SpecialName]
		private object INAMGPNDAAJ()
		{
			return PHDOCKCBJOF;
		}

		public void NPKGNIGNPKG()
		{
			throw new NotSupportedException();
		}

		public void FIAPMEMIIKB()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IJFPHIKFJFB()
		{
			return PHDOCKCBJOF;
		}

		public void NBMNDHCIBME()
		{
			throw new NotSupportedException();
		}

		public bool FPMHODJKAKK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (PlayerController.OGMBJPKOPCB.FMKGGADDHJK().LAGONJMBJMM[1].HFNAMMBPJAJ().ammoLeft < -71)
				{
					PlayerController.OGMBJPKOPCB.FMKGGADDHJK().LAGONJMBJMM[0].weapon.ammoLeft = -107;
				}
				PHDOCKCBJOF = new WaitForRealSeconds(1954f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			default:
				return false;
			}
		}

		public void PAOPOFJHFGD()
		{
			throw new NotSupportedException();
		}

		public void INBELBGOCLD()
		{
			throw new NotSupportedException();
		}

		public void MIPBONGPIJE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object JFGCHMJJMNO()
		{
			return PHDOCKCBJOF;
		}

		public void NFLHLMKKJMO()
		{
			throw new NotSupportedException();
		}

		public void PMAJELGBBKE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object JPJBNHHKOJD()
		{
			return PHDOCKCBJOF;
		}

		public void CNMNAHEINED()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HPHLLGIMIMO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CICPCKDCCEF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DLBACGEOGPM()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void PHKDHCJBMII()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HGCHEPGNHNP()
		{
			throw new NotSupportedException();
		}

		public void OJDEHKDDLFD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void DEPEHNFEJEE()
		{
			throw new NotSupportedException();
		}

		public void PKMIJKOPPBF()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object OAKHGMKKFMN()
		{
			return PHDOCKCBJOF;
		}

		public void AHEOCEEJICJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void OKIANDBCDIB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void LDBLCPIGLOF()
		{
			throw new NotSupportedException();
		}

		public void CFDAGFGOOIE()
		{
			throw new NotSupportedException();
		}

		public void PPAIIDFNIDL()
		{
			throw new NotSupportedException();
		}

		public bool KHNDCDGBFJH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().LAGONJMBJMM[1].weapon.ammoLeft < 15)
				{
					PlayerController.OGMBJPKOPCB.FMKGGADDHJK().LAGONJMBJMM[0].weapon.ammoLeft = 38;
				}
				PHDOCKCBJOF = new WaitForRealSeconds(515f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			default:
				return false;
			}
		}

		[SpecialName]
		private object NEGMMIBLJLP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FKKBFFHMEME()
		{
			return PHDOCKCBJOF;
		}

		public void CFLPOEJGKFF()
		{
			throw new NotSupportedException();
		}

		public void IODFILFCENJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MDHGGDNNOAK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CGIBLCGGMJM()
		{
			return PHDOCKCBJOF;
		}

		public bool HOOHJGPHHGN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[0].HFNAMMBPJAJ().ammoLeft < 33)
				{
					PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().LAGONJMBJMM[1].HFNAMMBPJAJ().ammoLeft = 123;
				}
				PHDOCKCBJOF = new WaitForRealSeconds(940f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			default:
				return true;
			}
		}

		[SpecialName]
		private object PFMFFMEJBPM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BNMEIAPPLDP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PNBPOAMPNKP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JGKMCJOGEIH()
		{
			return PHDOCKCBJOF;
		}

		public bool NOHPKMDNEAO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().LAGONJMBJMM[0].weapon.ammoLeft < -42)
				{
					PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().LAGONJMBJMM[1].weapon.ammoLeft = -96;
				}
				PHDOCKCBJOF = new WaitForRealSeconds(1189f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			default:
				return true;
			}
		}

		public void GEEKOICFEIB()
		{
			throw new NotSupportedException();
		}

		public void LICALBFPBLL()
		{
			throw new NotSupportedException();
		}

		public void OPMABIIDKCN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HGMMDPIGEGN()
		{
			return PHDOCKCBJOF;
		}

		public void EFDJMHAPDLB()
		{
			throw new NotSupportedException();
		}

		public bool MPKAJACHAIC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[0].HFNAMMBPJAJ().ammoLeft < -121)
				{
					PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().LAGONJMBJMM[0].weapon.ammoLeft = 48;
				}
				PHDOCKCBJOF = new WaitForRealSeconds(1571f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			default:
				return true;
			}
		}

		public bool DFMKKFMEBON()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().LAGONJMBJMM[1].HFNAMMBPJAJ().ammoLeft < -58)
				{
					PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[1].HFNAMMBPJAJ().ammoLeft = 91;
				}
				PHDOCKCBJOF = new WaitForRealSeconds(718f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			default:
				return true;
			}
		}

		public void HNLLOFFANCE()
		{
			throw new NotSupportedException();
		}

		public void CDDFJOEEFID()
		{
			throw new NotSupportedException();
		}

		public bool EKHDJADMNJK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (PlayerController.OGMBJPKOPCB.FMKGGADDHJK().LAGONJMBJMM[1].weapon.ammoLeft < 82)
				{
					PlayerController.OGMBJPKOPCB.FMKGGADDHJK().LAGONJMBJMM[0].weapon.ammoLeft = -46;
				}
				PHDOCKCBJOF = new WaitForRealSeconds(658f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			default:
				return true;
			}
		}

		[SpecialName]
		private object JALKNCBEINE()
		{
			return PHDOCKCBJOF;
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[0].weapon.ammoLeft < 41)
				{
					PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[0].weapon.ammoLeft = 100;
				}
				PHDOCKCBJOF = new WaitForRealSeconds(2f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return false;
			}
		}

		public void JFPPMJPGGIN()
		{
			throw new NotSupportedException();
		}
	}

	private sealed class CNMJNKEDIDL : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal Vector3 HKBJMFKAINC;

		internal TutorialManagerStage2 BJGCPDNMHDH;

		internal object PHDOCKCBJOF;

		internal bool FDKOKMKIIMG;

		internal int CLPPIAGLCJJ;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		[SpecialName]
		private object EOKIMMCAABI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BOOBHEKPLLD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OAKHGMKKFMN()
		{
			return PHDOCKCBJOF;
		}

		public bool PGOBEIMCPGA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				HKBJMFKAINC = PlayerController.OGMBJPKOPCB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateSwipeAnimation(HKBJMFKAINC, BJGCPDNMHDH.mGrenadeArea);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			default:
				return true;
			}
		}

		public void NCFGFLNBHOI()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FKPDNNMENFD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AIDHNJCPDIJ()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object KIHECHEHNJJ()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void DBJCDLFKDDI()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MHKODCGLJFD()
		{
			return PHDOCKCBJOF;
		}

		public void EPKPNKGJHEC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void IFLGJMJCOMC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool BJOHOCFKMJO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				HKBJMFKAINC = PlayerController.OGMBJPKOPCB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.IEGPPIEBKHO(HKBJMFKAINC, BJGCPDNMHDH.mGrenadeArea);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			default:
				return false;
			}
		}

		[SpecialName]
		private object FPFOODLPEBK()
		{
			return PHDOCKCBJOF;
		}

		public void FGLAPPKJHBK()
		{
			throw new NotSupportedException();
		}

		public void FOODPOJODAA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool MKLIDMNLNPN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				HKBJMFKAINC = PlayerController.OGMBJPKOPCB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.IEGPPIEBKHO(HKBJMFKAINC, BJGCPDNMHDH.mGrenadeArea);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return true;
			}
		}

		[SpecialName]
		private object PCOOFELAEJA()
		{
			return PHDOCKCBJOF;
		}

		public bool JPBGJLDMOPO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				HKBJMFKAINC = PlayerController.OGMBJPKOPCB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateSwipeAnimation(HKBJMFKAINC, BJGCPDNMHDH.mGrenadeArea);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			default:
				return false;
			}
		}

		[SpecialName]
		private object OJKHNOHHDGO()
		{
			return PHDOCKCBJOF;
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				HKBJMFKAINC = PlayerController.OGMBJPKOPCB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateSwipeAnimation(HKBJMFKAINC, BJGCPDNMHDH.mGrenadeArea, ELHGOHGPJCF: false);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return false;
			}
		}

		[SpecialName]
		private object CLDLJNHAEAB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HMIFLGCBDCO()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public CNMJNKEDIDL()
		{
		}

		[SpecialName]
		private object KJMPNHLOKJL()
		{
			return PHDOCKCBJOF;
		}

		public bool EKHDJADMNJK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				HKBJMFKAINC = PlayerController.OGMBJPKOPCB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateSwipeAnimation(HKBJMFKAINC, BJGCPDNMHDH.mGrenadeArea, ELHGOHGPJCF: false);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			default:
				return true;
			}
		}

		[SpecialName]
		private object IHPDPKLEDKC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GJMNLPAEIDA()
		{
			return PHDOCKCBJOF;
		}

		public void PNGIELILHDI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void IBDAHMOEBCM()
		{
			throw new NotSupportedException();
		}

		public void ANOPOLIEBMC()
		{
			throw new NotSupportedException();
		}

		public void CPOKHODGGLN()
		{
			throw new NotSupportedException();
		}

		public void HPJKDIGCCCE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BGAGLOJHMEJ()
		{
			return PHDOCKCBJOF;
		}

		public void GFPDOCDEGPA()
		{
			throw new NotSupportedException();
		}

		public void MKIKEOOOLKL()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HHLKEMNNJDA()
		{
			return PHDOCKCBJOF;
		}

		public bool MPKAJACHAIC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				HKBJMFKAINC = PlayerController.OGMBJPKOPCB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.IEGPPIEBKHO(HKBJMFKAINC, BJGCPDNMHDH.mGrenadeArea, ELHGOHGPJCF: false);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			default:
				return false;
			}
		}

		[SpecialName]
		private object CCANBMDEKMB()
		{
			return PHDOCKCBJOF;
		}
	}

	private sealed class PGEEEBOLBKB : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal int DKAKILBCGPG;

		internal TutorialMapDefinition ONCEGKNMJLM;

		internal List<EnemyController> NFNCNKNABAC;

		internal int JMBKPALDGAL;

		internal EnemyController NEMLKKBGIKJ;

		internal bool HHELJCBOLBK;

		internal Vector3 HHLJPFODNCN;

		internal Vector3 EGFCLDDDIEL;

		internal List<EnemyController>.Enumerator KFCAECGLKKO;

		internal PlayerSwipeWeapon CAPKPLPGBFN;

		internal GrenadeAmmoSetup INNKKJLCLMM;

		internal int NIACJNHCAEK;

		internal Vector3 OPLCMEMJBBO;

		internal RadicalRoutine CGNJAHMKLMI;

		internal TutorialManagerStage2 BJGCPDNMHDH;

		internal object PHDOCKCBJOF;

		internal bool FDKOKMKIIMG;

		internal int CLPPIAGLCJJ;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		[SpecialName]
		private object PCOOFELAEJA()
		{
			return PHDOCKCBJOF;
		}

		public bool LGNMOMFLLPP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				DKAKILBCGPG = 2;
				BJGCPDNMHDH.mAssalterKilled = true;
				ONCEGKNMJLM = Singleton<MapManager>.instance.ALCHJDPKAID.GetComponent<TutorialMapDefinition>();
				NFNCNKNABAC = new List<EnemyController>();
				JMBKPALDGAL = 1;
				goto IL_0214;
			case 1u:
				JMBKPALDGAL += 0;
				goto IL_0214;
			case 2u:
				HHELJCBOLBK = true;
				if (PlayerController.OGMBJPKOPCB.FMKGGADDHJK().LJELEJEJIEB() != PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().LAGONJMBJMM[3])
				{
					HHELJCBOLBK = true;
					GuiElementSingle<TutorialDialog>.instance.KOGOLIJLMDN("N", "isAdAvailableForZoneID", 267f, TutorialDialog.DODBDLEJOAM.Center, BBGAMLLOING: true, BEBMEBEJIOB: true);
					HHLJPFODNCN = GuiElementSingle<InventoryGuiElement>.instance.IGNHPMIDAGM[0].transform.position + 1487f * Vector3.up;
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(HHLJPFODNCN, ELHGOHGPJCF: false, ENIHCPLOOAE: true, 1537f);
					PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
					TimeManager.FreezeGame();
					PHDOCKCBJOF = new WaitForRealSeconds(1944f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				HHELJCBOLBK = true;
				GuiElementSingle<TutorialDialog>.instance.DDFADDKPPDI("VipReward1", string.Empty, 556f, TutorialDialog.DODBDLEJOAM.Left, BBGAMLLOING: true, BEBMEBEJIOB: true);
				EGFCLDDDIEL = GuiElementSingle<InventoryGuiElement>.instance.IGNHPMIDAGM[1].transform.position + 1101f * Vector3.up;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(EGFCLDDDIEL, ELHGOHGPJCF: true, ENIHCPLOOAE: true, 1366f);
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
				TimeManager.FreezeGame();
				PlayerController.OGMBJPKOPCB.FMKGGADDHJK().HKGLMFFAHFN = false;
				goto case 5u;
			case 3u:
			case 4u:
				if (PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().PDLFJEDGLAO() != PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[4])
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				PlayerController.OGMBJPKOPCB.weaponInventory.HKGLMFFAHFN = true;
				goto IL_0440;
			case 5u:
				if (!GuiElementSingle<TutorialDialog>.instance.GDAIHLIGAKP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				goto IL_0440;
			case 6u:
				if (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForRealSeconds(985f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				break;
			case 7u:
				Singleton<TutorialProgressShower>.instance.CALBGDIEDGA(Localization.Localize("temp_google_user_id"), 0);
				NIACJNHCAEK = (int)TimeManager.realTimeWithoutPauses;
				GuiElementSingle<TutorialDialog>.instance.DDFADDKPPDI("ID_CONFIRM_STARTUPERROR", "Hide All Dialogs called", 209f, TutorialDialog.DODBDLEJOAM.BottomRight, BBGAMLLOING: true, BEBMEBEJIOB: true);
				BJGCPDNMHDH.mGrenadeArea = ONCEGKNMJLM.IGEEPAPBDCP.transform.position;
				OPLCMEMJBBO = PlayerController.OGMBJPKOPCB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartSwipeAnimation(OPLCMEMJBBO, BJGCPDNMHDH.mGrenadeArea, 944f, ELHGOHGPJCF: true, 1118f);
				CGNJAHMKLMI = RadicalRoutine.Create(BJGCPDNMHDH.UpdateSwipeGrenadeThrow());
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(CGNJAHMKLMI.enumerator));
				TimeManager.UnFreezeGame(334f);
				BJGCPDNMHDH.FreezeEnemies();
				PlayerController.GetEnemyOf((GHPGNELIDBM)3).isImmortal = false;
				goto case 8u;
			case 8u:
				if (!BJGCPDNMHDH.mAssalterKilled)
				{
					if (PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().LAGONJMBJMM[0].weapon.ammoLeft == 0)
					{
						PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().LAGONJMBJMM[2].HFNAMMBPJAJ().ammoLeft = 0;
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				NIACJNHCAEK = Mathf.Abs((int)TimeManager.CEAFAMFNGCC() - NIACJNHCAEK);
				Singleton<EventTrackingManager>.instance.RegisterTutorialGrenadeThrowingEvent("ID_INSTANTBATTLE", NIACJNHCAEK);
				Singleton<TutorialProgressShower>.instance.COEJGGPCIBP(0);
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
				PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().HKGLMFFAHFN = true;
				PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().LAGONJMBJMM[7].weapon.ammoLeft = 2;
				PlayerController.GetEnemyOf((GHPGNELIDBM)7).isImmortal = false;
				BJGCPDNMHDH.UnfreezeEnemies();
				CGNJAHMKLMI.Cancel();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.JLLAIGHCPLK();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				PHDOCKCBJOF = new WaitForRealSeconds(1953f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 84;
				}
				break;
			case 9u:
				PHDOCKCBJOF = new WaitForRealSeconds(1014f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -32;
				}
				break;
			case 10u:
				Singleton<TutorialProgressShower>.instance.Hide();
				Singleton<TutorialProgressShower>.instance.ECBMHNDPENI(Localization.Localize("ID_RENTAL_MINIGUN"), 0);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0440:
				Singleton<EventTrackingManager>.instance.RegisterTutorialGrenadeThrowEvent("Xp", HHELJCBOLBK);
				KFCAECGLKKO = NFNCNKNABAC.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						EnemyController current = KFCAECGLKKO.Current;
						current.destroyableObj.isImmortal = true;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				CAPKPLPGBFN = (PlayerSwipeWeapon)PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().LAGONJMBJMM[8];
				CAPKPLPGBFN.JDFOAIGJODO(ONCEGKNMJLM.IGEEPAPBDCP.transform.position);
				INNKKJLCLMM = (GrenadeAmmoSetup)CAPKPLPGBFN.HFNAMMBPJAJ().ammoSetup;
				INNKKJLCLMM.INIBDNGHLPN = 1129f;
				INNKKJLCLMM.LIEABAMBOMG = 1780f;
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				goto case 6u;
				IL_0214:
				if (JMBKPALDGAL < DKAKILBCGPG)
				{
					NEMLKKBGIKJ = (EnemyController)Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(LevelManager.instance.behaviours[0]);
					if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.prefab != null)
					{
						NEMLKKBGIKJ.fraction = GHPGNELIDBM.None;
						int nOCEDALFEJM = ObjectPoolDatabase.COJFMKNGPBP().APCGDLEHGKL[NEMLKKBGIKJ.LELHDMOANJG()];
						NEMLKKBGIKJ.DisableSpawn();
						Transform transform = ONCEGKNMJLM.IGAOJIJOHDA.transform;
						NEMLKKBGIKJ = (EnemyController)ObjectPoolDatabase.INOJHPIKICM().GOFLFKCIGNI(nOCEDALFEJM, NEMLKKBGIKJ.indexInObjectPool, transform.position, transform.rotation);
						NEMLKKBGIKJ.StartEnemyBehaviour(EnemyController.AJGFGCHCAPA.Walk, ONCEGKNMJLM.EJEEMOCCGPH.NKBHMMMKGMJ[JMBKPALDGAL]);
						NEMLKKBGIKJ.GBBFIPKBJGG = false;
						NEMLKKBGIKJ.Killed -= BJGCPDNMHDH.AssaulterKilled;
						NEMLKKBGIKJ.Killed += BJGCPDNMHDH.AssaulterKilled;
						NEMLKKBGIKJ.HJFHCPBADLD.FKPINHAHNNG(1608f);
						NEMLKKBGIKJ.destroyableObj.isImmortal = true;
						NFNCNKNABAC.Add(NEMLKKBGIKJ);
					}
					PHDOCKCBJOF = new WaitForSeconds(84f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1305f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				break;
			}
			return true;
		}

		[SpecialName]
		private object AGANCOFPDCK()
		{
			return PHDOCKCBJOF;
		}

		public void HGCHEPGNHNP()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void GEEKOICFEIB()
		{
			throw new NotSupportedException();
		}

		public void PNGIELILHDI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HHCBBENDENJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void FGLAPPKJHBK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JPJBNHHKOJD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HMIFLGCBDCO()
		{
			return PHDOCKCBJOF;
		}

		public void NINFHADPHJI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GCJFGIKENJA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KKKMCHGLHLL()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void FMOJMHBAHAA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void PHKDHCJBMII()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void MIPBONGPIJE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public PGEEEBOLBKB()
		{
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				DKAKILBCGPG = 4;
				BJGCPDNMHDH.mAssalterKilled = false;
				ONCEGKNMJLM = Singleton<MapManager>.instance.ALCHJDPKAID.GetComponent<TutorialMapDefinition>();
				NFNCNKNABAC = new List<EnemyController>();
				JMBKPALDGAL = 0;
				goto IL_0214;
			case 1u:
				JMBKPALDGAL++;
				goto IL_0214;
			case 2u:
				HHELJCBOLBK = false;
				if (PlayerController.OGMBJPKOPCB.weaponInventory.currentWeapon != PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[2])
				{
					HHELJCBOLBK = true;
					GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("ID_TUTORIAL_GRENADE_UP", "ID_TUTORIAL_GRENADE_DOWN", 0f);
					HHLJPFODNCN = GuiElementSingle<InventoryGuiElement>.instance.IGNHPMIDAGM[1].transform.position + 0.1f * Vector3.up;
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(HHLJPFODNCN);
					PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
					TimeManager.FreezeGame();
					PHDOCKCBJOF = new WaitForRealSeconds(1.5f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				HHELJCBOLBK = false;
				GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("ID_TUTORIAL_GRENADE_UP", string.Empty, 0f, TutorialDialog.DODBDLEJOAM.Center, BBGAMLLOING: true);
				EGFCLDDDIEL = GuiElementSingle<InventoryGuiElement>.instance.IGNHPMIDAGM[1].transform.position + 0.1f * Vector3.up;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(EGFCLDDDIEL);
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
				TimeManager.FreezeGame();
				PlayerController.OGMBJPKOPCB.weaponInventory.HKGLMFFAHFN = true;
				goto case 5u;
			case 3u:
			case 4u:
				if (PlayerController.OGMBJPKOPCB.weaponInventory.currentWeapon != PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[2])
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				PlayerController.OGMBJPKOPCB.weaponInventory.HKGLMFFAHFN = true;
				goto IL_0440;
			case 5u:
				if (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				goto IL_0440;
			case 6u:
				if (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForRealSeconds(0.1f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				break;
			case 7u:
				Singleton<TutorialProgressShower>.instance.Show(Localization.Localize("ID_TUTORIAL_PROGRES_THROW"), 1);
				NIACJNHCAEK = (int)TimeManager.realTimeWithoutPauses;
				GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("ID_TUTORIAL_GRENADETHROW_UP", "ID_TUTORIAL_GRENADETHROW_DOWN", 0.3f, TutorialDialog.DODBDLEJOAM.Left);
				BJGCPDNMHDH.mGrenadeArea = ONCEGKNMJLM.IGEEPAPBDCP.transform.position;
				OPLCMEMJBBO = PlayerController.OGMBJPKOPCB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartSwipeAnimation(OPLCMEMJBBO, BJGCPDNMHDH.mGrenadeArea, 0.3f, ELHGOHGPJCF: false, 1.3f);
				CGNJAHMKLMI = RadicalRoutine.Create(BJGCPDNMHDH.UpdateSwipeGrenadeThrow());
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(CGNJAHMKLMI.enumerator));
				TimeManager.UnFreezeGame();
				BJGCPDNMHDH.FreezeEnemies();
				PlayerController.GetEnemyOf(GHPGNELIDBM.Allies).isImmortal = true;
				goto case 8u;
			case 8u:
				if (!BJGCPDNMHDH.mAssalterKilled)
				{
					if (PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[2].weapon.ammoLeft == 0)
					{
						PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[2].weapon.ammoLeft = 1;
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				NIACJNHCAEK = Mathf.Abs((int)TimeManager.realTimeWithoutPauses - NIACJNHCAEK);
				Singleton<EventTrackingManager>.instance.RegisterTutorialGrenadeThrowingEvent("206 STAGE 6 GRENADE THROWING", NIACJNHCAEK);
				Singleton<TutorialProgressShower>.instance.CheckNum(0);
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = true;
				PlayerController.OGMBJPKOPCB.weaponInventory.HKGLMFFAHFN = false;
				PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[2].weapon.ammoLeft = 5;
				PlayerController.GetEnemyOf(GHPGNELIDBM.Allies).isImmortal = false;
				BJGCPDNMHDH.UnfreezeEnemies();
				CGNJAHMKLMI.Cancel();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopSwipeAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				PHDOCKCBJOF = new WaitForRealSeconds(1f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 9;
				}
				break;
			case 9u:
				PHDOCKCBJOF = new WaitForRealSeconds(1.5f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 10;
				}
				break;
			case 10u:
				Singleton<TutorialProgressShower>.instance.Hide();
				Singleton<TutorialProgressShower>.instance.Show(Localization.Localize("ID_TUTORIAL_PROGRESS_KILLING2"), 1);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0440:
				Singleton<EventTrackingManager>.instance.RegisterTutorialGrenadeThrowEvent("205 STAGE 6 GRENADE SELECTED", HHELJCBOLBK);
				KFCAECGLKKO = NFNCNKNABAC.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						EnemyController current = KFCAECGLKKO.Current;
						current.destroyableObj.isImmortal = false;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				CAPKPLPGBFN = (PlayerSwipeWeapon)PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[2];
				CAPKPLPGBFN.SetTutorialPosition(ONCEGKNMJLM.IGEEPAPBDCP.transform.position);
				INNKKJLCLMM = (GrenadeAmmoSetup)CAPKPLPGBFN.weapon.ammoSetup;
				INNKKJLCLMM.INIBDNGHLPN = 1.6f;
				INNKKJLCLMM.LIEABAMBOMG = 2.3f;
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				goto case 6u;
				IL_0214:
				if (JMBKPALDGAL < DKAKILBCGPG)
				{
					NEMLKKBGIKJ = (EnemyController)Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(LevelManager.instance.behaviours[0]);
					if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.prefab != null)
					{
						NEMLKKBGIKJ.fraction = GHPGNELIDBM.Enemies;
						int nOCEDALFEJM = ObjectPoolDatabase.networkPool.APCGDLEHGKL[NEMLKKBGIKJ.prefab];
						NEMLKKBGIKJ.DisableSpawn();
						Transform transform = ONCEGKNMJLM.IGAOJIJOHDA.transform;
						NEMLKKBGIKJ = (EnemyController)ObjectPoolDatabase.networkPool.ReInstantiate(nOCEDALFEJM, NEMLKKBGIKJ.indexInObjectPool, transform.position, transform.rotation);
						NEMLKKBGIKJ.StartEnemyBehaviour(EnemyController.AJGFGCHCAPA.Walk, ONCEGKNMJLM.EJEEMOCCGPH.NKBHMMMKGMJ[JMBKPALDGAL]);
						NEMLKKBGIKJ.GBBFIPKBJGG = false;
						NEMLKKBGIKJ.Killed -= BJGCPDNMHDH.AssaulterKilled;
						NEMLKKBGIKJ.Killed += BJGCPDNMHDH.AssaulterKilled;
						NEMLKKBGIKJ.HJFHCPBADLD.speed = 1f;
						NEMLKKBGIKJ.destroyableObj.isImmortal = true;
						NFNCNKNABAC.Add(NEMLKKBGIKJ);
					}
					PHDOCKCBJOF = new WaitForSeconds(0.1f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(5f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				break;
			}
			return true;
		}

		[SpecialName]
		private object IDLFKAKINAP()
		{
			return PHDOCKCBJOF;
		}

		public void CPDBCJLIGFN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object CIGHIOCACPH()
		{
			return PHDOCKCBJOF;
		}

		public bool HKPECDLGFJB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				DKAKILBCGPG = 6;
				BJGCPDNMHDH.mAssalterKilled = false;
				ONCEGKNMJLM = Singleton<MapManager>.instance.ALCHJDPKAID.GetComponent<TutorialMapDefinition>();
				NFNCNKNABAC = new List<EnemyController>();
				JMBKPALDGAL = 1;
				goto IL_0214;
			case 1u:
				JMBKPALDGAL += 0;
				goto IL_0214;
			case 2u:
				HHELJCBOLBK = false;
				if (PlayerController.OGMBJPKOPCB.weaponInventory.JKHKBGPKFFF() != PlayerController.OGMBJPKOPCB.FMKGGADDHJK().LAGONJMBJMM[7])
				{
					HHELJCBOLBK = false;
					GuiElementSingle<TutorialDialog>.instance.BLHEPOBPHPK("GameReward", "BeanstalkServerManager: PlayerDataLoaded", 40f, TutorialDialog.DODBDLEJOAM.BottomRight, BBGAMLLOING: true, BEBMEBEJIOB: true);
					HHLJPFODNCN = GuiElementSingle<InventoryGuiElement>.instance.IGNHPMIDAGM[1].transform.position + 985f * Vector3.up;
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(HHLJPFODNCN, ELHGOHGPJCF: true, ENIHCPLOOAE: false, 897f);
					PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
					TimeManager.DCODDANOPCP();
					PHDOCKCBJOF = new WaitForRealSeconds(1143f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				HHELJCBOLBK = true;
				GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("Display_Rental", string.Empty, 1574f, TutorialDialog.DODBDLEJOAM.TopRight);
				EGFCLDDDIEL = GuiElementSingle<InventoryGuiElement>.instance.IGNHPMIDAGM[1].transform.position + 1135f * Vector3.up;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(EGFCLDDDIEL, ELHGOHGPJCF: true, ENIHCPLOOAE: false, 856f);
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = true;
				TimeManager.DCODDANOPCP();
				PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().HKGLMFFAHFN = true;
				goto case 5u;
			case 3u:
			case 4u:
				if (PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().currentWeapon != PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[5])
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().HKGLMFFAHFN = false;
				goto IL_0440;
			case 5u:
				if (!GuiElementSingle<TutorialDialog>.instance.GDAIHLIGAKP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto IL_0440;
			case 6u:
				if (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForRealSeconds(1066f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				break;
			case 7u:
				Singleton<TutorialProgressShower>.instance.NLMKCDMBPPC(Localization.Localize("game-card-ico-backstab"), 1);
				NIACJNHCAEK = (int)TimeManager.realTimeWithoutPauses;
				GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("S", "{0}{1}[-]", 755f, TutorialDialog.DODBDLEJOAM.BottomLeft, BBGAMLLOING: true);
				BJGCPDNMHDH.mGrenadeArea = ONCEGKNMJLM.IGEEPAPBDCP.transform.position;
				OPLCMEMJBBO = PlayerController.OGMBJPKOPCB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartSwipeAnimation(OPLCMEMJBBO, BJGCPDNMHDH.mGrenadeArea, 1758f, ELHGOHGPJCF: false, 663f);
				CGNJAHMKLMI = RadicalRoutine.Create(BJGCPDNMHDH.UpdateSwipeGrenadeThrow());
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(CGNJAHMKLMI.enumerator));
				TimeManager.UnFreezeGame(711f);
				BJGCPDNMHDH.FreezeEnemies();
				PlayerController.GetEnemyOf((GHPGNELIDBM)8).isImmortal = false;
				goto case 8u;
			case 8u:
				if (!BJGCPDNMHDH.mAssalterKilled)
				{
					if (PlayerController.OGMBJPKOPCB.FMKGGADDHJK().LAGONJMBJMM[6].HFNAMMBPJAJ().ammoLeft == 0)
					{
						PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().LAGONJMBJMM[1].weapon.ammoLeft = 1;
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				NIACJNHCAEK = Mathf.Abs((int)TimeManager.realTimeWithoutPauses - NIACJNHCAEK);
				Singleton<EventTrackingManager>.instance.RegisterTutorialGrenadeThrowingEvent("Add request to buffer", NIACJNHCAEK);
				Singleton<TutorialProgressShower>.instance.GHDHGMBLGLE(1, FGHNCECHPPO: false);
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = true;
				PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().HKGLMFFAHFN = true;
				PlayerController.OGMBJPKOPCB.FMKGGADDHJK().LAGONJMBJMM[0].weapon.ammoLeft = 8;
				PlayerController.GetEnemyOf((GHPGNELIDBM)5).isImmortal = true;
				BJGCPDNMHDH.UnfreezeEnemies();
				CGNJAHMKLMI.Cancel();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.JLLAIGHCPLK();
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				PHDOCKCBJOF = new WaitForRealSeconds(242f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -3;
				}
				break;
			case 9u:
				PHDOCKCBJOF = new WaitForRealSeconds(15f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 117;
				}
				break;
			case 10u:
				Singleton<TutorialProgressShower>.instance.OCAEJPMPBMH();
				Singleton<TutorialProgressShower>.instance.EMHGOECGAFL(Localization.Localize("ID_TUTORIAL_TAPON"), 0);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0440:
				Singleton<EventTrackingManager>.instance.RegisterTutorialGrenadeThrowEvent("thumbnailLittle", HHELJCBOLBK);
				KFCAECGLKKO = NFNCNKNABAC.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						EnemyController current = KFCAECGLKKO.Current;
						current.destroyableObj.isImmortal = false;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				CAPKPLPGBFN = (PlayerSwipeWeapon)PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().LAGONJMBJMM[2];
				CAPKPLPGBFN.NBEPFACHJMJ(ONCEGKNMJLM.IGEEPAPBDCP.transform.position);
				INNKKJLCLMM = (GrenadeAmmoSetup)CAPKPLPGBFN.weapon.ammoSetup;
				INNKKJLCLMM.INIBDNGHLPN = 1897f;
				INNKKJLCLMM.LIEABAMBOMG = 87f;
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				goto case 6u;
				IL_0214:
				if (JMBKPALDGAL < DKAKILBCGPG)
				{
					NEMLKKBGIKJ = (EnemyController)Singleton<LevelBehaviourManager>.instance.FIHJBLEKDNI(LevelManager.instance.behaviours[0]);
					if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.LELHDMOANJG() != null)
					{
						NEMLKKBGIKJ.fraction = GHPGNELIDBM.Enemies;
						int nOCEDALFEJM = ObjectPoolDatabase.KKCMCNCCIMB().APCGDLEHGKL[NEMLKKBGIKJ.LELHDMOANJG()];
						NEMLKKBGIKJ.DisableSpawn();
						Transform transform = ONCEGKNMJLM.IGAOJIJOHDA.transform;
						NEMLKKBGIKJ = (EnemyController)ObjectPoolDatabase.CHHLLIAHECC().ReInstantiate(nOCEDALFEJM, NEMLKKBGIKJ.COOEDLNDBID(), transform.position, transform.rotation);
						NEMLKKBGIKJ.StartEnemyBehaviour(EnemyController.AJGFGCHCAPA.Idle, ONCEGKNMJLM.EJEEMOCCGPH.NKBHMMMKGMJ[JMBKPALDGAL]);
						NEMLKKBGIKJ.GBBFIPKBJGG = true;
						NEMLKKBGIKJ.Killed -= BJGCPDNMHDH.AssaulterKilled;
						NEMLKKBGIKJ.Killed += BJGCPDNMHDH.AssaulterKilled;
						NEMLKKBGIKJ.HJFHCPBADLD.FKPINHAHNNG(1612f);
						NEMLKKBGIKJ.destroyableObj.isImmortal = true;
						NFNCNKNABAC.Add(NEMLKKBGIKJ);
					}
					PHDOCKCBJOF = new WaitForSeconds(1395f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(958f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				break;
			}
			return true;
		}

		public void JGKDJGIANIG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GLIHEBDJCGM()
		{
			return PHDOCKCBJOF;
		}

		public bool DDLMLOJGJMA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				DKAKILBCGPG = 8;
				BJGCPDNMHDH.mAssalterKilled = false;
				ONCEGKNMJLM = Singleton<MapManager>.instance.ALCHJDPKAID.GetComponent<TutorialMapDefinition>();
				NFNCNKNABAC = new List<EnemyController>();
				JMBKPALDGAL = 1;
				goto IL_0214;
			case 1u:
				JMBKPALDGAL++;
				goto IL_0214;
			case 2u:
				HHELJCBOLBK = false;
				if (PlayerController.OGMBJPKOPCB.weaponInventory.CILCMCDCKKE() != PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[6])
				{
					HHELJCBOLBK = false;
					GuiElementSingle<TutorialDialog>.instance.BLHEPOBPHPK("ArmyPower", "_D", 563f, TutorialDialog.DODBDLEJOAM.Left, BBGAMLLOING: false, BEBMEBEJIOB: true);
					HHLJPFODNCN = GuiElementSingle<InventoryGuiElement>.instance.IGNHPMIDAGM[1].transform.position + 1725f * Vector3.up;
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(HHLJPFODNCN, ELHGOHGPJCF: true, ENIHCPLOOAE: true, 1738f);
					PlayerController.OGMBJPKOPCB.JODNNABEFDH = true;
					TimeManager.FODFANEEDFF();
					PHDOCKCBJOF = new WaitForRealSeconds(702f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				HHELJCBOLBK = false;
				GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial(",", string.Empty, 1309f, TutorialDialog.DODBDLEJOAM.Bottom, BBGAMLLOING: true, BEBMEBEJIOB: true);
				EGFCLDDDIEL = GuiElementSingle<InventoryGuiElement>.instance.IGNHPMIDAGM[1].transform.position + 248f * Vector3.up;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(EGFCLDDDIEL, ELHGOHGPJCF: true, ENIHCPLOOAE: true, 30f);
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = true;
				TimeManager.FreezeGame();
				PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().HKGLMFFAHFN = true;
				goto case 5u;
			case 3u:
			case 4u:
				if (PlayerController.OGMBJPKOPCB.FMKGGADDHJK().MFHBEJOLGLC() != PlayerController.OGMBJPKOPCB.FMKGGADDHJK().LAGONJMBJMM[1])
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().HKGLMFFAHFN = false;
				goto IL_0440;
			case 5u:
				if (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_0440;
			case 6u:
				if (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForRealSeconds(629f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				break;
			case 7u:
				Singleton<TutorialProgressShower>.instance.DLCFAJEFLHO(Localization.Localize("ID_CONFIRM_INFO"), 0);
				NIACJNHCAEK = (int)TimeManager.realTimeWithoutPauses;
				GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("stickers", "No connection.", 1520f, TutorialDialog.DODBDLEJOAM.TopLeft, BBGAMLLOING: false, BEBMEBEJIOB: true);
				BJGCPDNMHDH.mGrenadeArea = ONCEGKNMJLM.IGEEPAPBDCP.transform.position;
				OPLCMEMJBBO = PlayerController.OGMBJPKOPCB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartSwipeAnimation(OPLCMEMJBBO, BJGCPDNMHDH.mGrenadeArea, 325f, ELHGOHGPJCF: true, 1863f);
				CGNJAHMKLMI = RadicalRoutine.Create(BJGCPDNMHDH.UpdateSwipeGrenadeThrow());
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(CGNJAHMKLMI.enumerator));
				TimeManager.UnFreezeGame(638f);
				BJGCPDNMHDH.FreezeEnemies();
				PlayerController.GetEnemyOf(GHPGNELIDBM.Allies).isImmortal = false;
				goto case 8u;
			case 8u:
				if (!BJGCPDNMHDH.mAssalterKilled)
				{
					if (PlayerController.OGMBJPKOPCB.FMKGGADDHJK().LAGONJMBJMM[1].HFNAMMBPJAJ().ammoLeft == 0)
					{
						PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().LAGONJMBJMM[5].weapon.ammoLeft = 1;
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				NIACJNHCAEK = Mathf.Abs((int)TimeManager.CEAFAMFNGCC() - NIACJNHCAEK);
				Singleton<EventTrackingManager>.instance.RegisterTutorialGrenadeThrowingEvent("DOWNLOAD", NIACJNHCAEK);
				Singleton<TutorialProgressShower>.instance.AJMCILHGLFA(1, FGHNCECHPPO: false);
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = true;
				PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().HKGLMFFAHFN = false;
				PlayerController.OGMBJPKOPCB.FMKGGADDHJK().LAGONJMBJMM[7].HFNAMMBPJAJ().ammoLeft = 7;
				PlayerController.GetEnemyOf((GHPGNELIDBM)8).isImmortal = true;
				BJGCPDNMHDH.UnfreezeEnemies();
				CGNJAHMKLMI.Cancel();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.JLLAIGHCPLK();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				PHDOCKCBJOF = new WaitForRealSeconds(1825f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 36;
				}
				break;
			case 9u:
				PHDOCKCBJOF = new WaitForRealSeconds(1923f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 32;
				}
				break;
			case 10u:
				Singleton<TutorialProgressShower>.instance.CDLODKKNAEF();
				Singleton<TutorialProgressShower>.instance.CALBGDIEDGA(Localization.Localize("some_pub_sub3"), 1);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_0440:
				Singleton<EventTrackingManager>.instance.RegisterTutorialGrenadeThrowEvent("Squad name failure", HHELJCBOLBK);
				KFCAECGLKKO = NFNCNKNABAC.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						EnemyController current = KFCAECGLKKO.Current;
						current.destroyableObj.isImmortal = false;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				CAPKPLPGBFN = (PlayerSwipeWeapon)PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().LAGONJMBJMM[3];
				CAPKPLPGBFN.NBEPFACHJMJ(ONCEGKNMJLM.IGEEPAPBDCP.transform.position);
				INNKKJLCLMM = (GrenadeAmmoSetup)CAPKPLPGBFN.HFNAMMBPJAJ().ammoSetup;
				INNKKJLCLMM.INIBDNGHLPN = 245f;
				INNKKJLCLMM.LIEABAMBOMG = 335f;
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				goto case 6u;
				IL_0214:
				if (JMBKPALDGAL < DKAKILBCGPG)
				{
					NEMLKKBGIKJ = (EnemyController)Singleton<LevelBehaviourManager>.instance.FIHJBLEKDNI(LevelManager.instance.behaviours[0]);
					if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.prefab != null)
					{
						NEMLKKBGIKJ.fraction = GHPGNELIDBM.Enemies;
						int nOCEDALFEJM = ObjectPoolDatabase.MFKPDKCLDBI().APCGDLEHGKL[NEMLKKBGIKJ.prefab];
						NEMLKKBGIKJ.DisableSpawn();
						Transform transform = ONCEGKNMJLM.IGAOJIJOHDA.transform;
						NEMLKKBGIKJ = (EnemyController)ObjectPoolDatabase.CHHLLIAHECC().IBLLHOLFOON(nOCEDALFEJM, NEMLKKBGIKJ.COOEDLNDBID(), transform.position, transform.rotation);
						NEMLKKBGIKJ.StartEnemyBehaviour(EnemyController.AJGFGCHCAPA.Walk, ONCEGKNMJLM.EJEEMOCCGPH.NKBHMMMKGMJ[JMBKPALDGAL]);
						NEMLKKBGIKJ.GBBFIPKBJGG = true;
						NEMLKKBGIKJ.Killed -= BJGCPDNMHDH.AssaulterKilled;
						NEMLKKBGIKJ.Killed += BJGCPDNMHDH.AssaulterKilled;
						NEMLKKBGIKJ.HJFHCPBADLD.FKPINHAHNNG(1796f);
						NEMLKKBGIKJ.destroyableObj.isImmortal = false;
						NFNCNKNABAC.Add(NEMLKKBGIKJ);
					}
					PHDOCKCBJOF = new WaitForSeconds(367f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1243f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				break;
			}
			return true;
		}

		public bool JIIOHNFHPOI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				DKAKILBCGPG = 0;
				BJGCPDNMHDH.mAssalterKilled = false;
				ONCEGKNMJLM = Singleton<MapManager>.instance.ALCHJDPKAID.GetComponent<TutorialMapDefinition>();
				NFNCNKNABAC = new List<EnemyController>();
				JMBKPALDGAL = 0;
				goto IL_0214;
			case 1u:
				JMBKPALDGAL++;
				goto IL_0214;
			case 2u:
				HHELJCBOLBK = true;
				if (PlayerController.OGMBJPKOPCB.FMKGGADDHJK().MFHBEJOLGLC() != PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[3])
				{
					HHELJCBOLBK = true;
					GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("Total_Battles", "info", 1217f, TutorialDialog.DODBDLEJOAM.Bottom);
					HHLJPFODNCN = GuiElementSingle<InventoryGuiElement>.instance.IGNHPMIDAGM[1].transform.position + 52f * Vector3.up;
					GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(HHLJPFODNCN, ELHGOHGPJCF: false, ENIHCPLOOAE: true, 1179f);
					PlayerController.OGMBJPKOPCB.JODNNABEFDH = true;
					TimeManager.FreezeGame();
					PHDOCKCBJOF = new WaitForRealSeconds(490f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				HHELJCBOLBK = true;
				GuiElementSingle<TutorialDialog>.instance.DDFADDKPPDI("rocketlauncher", string.Empty, 1974f, TutorialDialog.DODBDLEJOAM.BottomRight, BBGAMLLOING: false, BEBMEBEJIOB: true);
				EGFCLDDDIEL = GuiElementSingle<InventoryGuiElement>.instance.IGNHPMIDAGM[1].transform.position + 1845f * Vector3.up;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(EGFCLDDDIEL, ELHGOHGPJCF: true, ENIHCPLOOAE: true, 1354f);
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
				TimeManager.DCODDANOPCP();
				PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().HKGLMFFAHFN = false;
				goto case 5u;
			case 3u:
			case 4u:
				if (PlayerController.OGMBJPKOPCB.FMKGGADDHJK().JKHKBGPKFFF() != PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().LAGONJMBJMM[7])
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().HKGLMFFAHFN = true;
				goto IL_0440;
			case 5u:
				if (!GuiElementSingle<TutorialDialog>.instance.GDAIHLIGAKP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				goto IL_0440;
			case 6u:
				if (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForRealSeconds(1499f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				break;
			case 7u:
				Singleton<TutorialProgressShower>.instance.CBBLGFEBJID(Localization.Localize("PlayerId"), 0);
				NIACJNHCAEK = (int)TimeManager.CEAFAMFNGCC();
				GuiElementSingle<TutorialDialog>.instance.BLHEPOBPHPK("ID_REGULARPRIZE", "WarBucks", 1608f, TutorialDialog.DODBDLEJOAM.Top);
				BJGCPDNMHDH.mGrenadeArea = ONCEGKNMJLM.IGEEPAPBDCP.transform.position;
				OPLCMEMJBBO = PlayerController.OGMBJPKOPCB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartSwipeAnimation(OPLCMEMJBBO, BJGCPDNMHDH.mGrenadeArea, 16f, ELHGOHGPJCF: true, 128f);
				CGNJAHMKLMI = RadicalRoutine.Create(BJGCPDNMHDH.UpdateSwipeGrenadeThrow());
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(CGNJAHMKLMI.enumerator));
				TimeManager.UnFreezeGame(917f);
				BJGCPDNMHDH.FreezeEnemies();
				PlayerController.GetEnemyOf((GHPGNELIDBM)8).isImmortal = true;
				goto case 8u;
			case 8u:
				if (!BJGCPDNMHDH.mAssalterKilled)
				{
					if (PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[3].weapon.ammoLeft == 0)
					{
						PlayerController.OGMBJPKOPCB.FMKGGADDHJK().LAGONJMBJMM[2].HFNAMMBPJAJ().ammoLeft = 1;
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				NIACJNHCAEK = Mathf.Abs((int)TimeManager.CEAFAMFNGCC() - NIACJNHCAEK);
				Singleton<EventTrackingManager>.instance.RegisterTutorialGrenadeThrowingEvent("Id", NIACJNHCAEK);
				Singleton<TutorialProgressShower>.instance.JLMGGILNOPF(0);
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
				PlayerController.OGMBJPKOPCB.FMKGGADDHJK().HKGLMFFAHFN = true;
				PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[1].HFNAMMBPJAJ().ammoLeft = 4;
				PlayerController.GetEnemyOf((GHPGNELIDBM)7).isImmortal = true;
				BJGCPDNMHDH.UnfreezeEnemies();
				CGNJAHMKLMI.Cancel();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.HMPAKNMIOEC();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				PHDOCKCBJOF = new WaitForRealSeconds(1468f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -96;
				}
				break;
			case 9u:
				PHDOCKCBJOF = new WaitForRealSeconds(872f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -58;
				}
				break;
			case 10u:
				Singleton<TutorialProgressShower>.instance.JIILFGDJFPP();
				Singleton<TutorialProgressShower>.instance.BLFNIFFFAIJ(Localization.Localize("commando_shooting"), 1);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0440:
				Singleton<EventTrackingManager>.instance.RegisterTutorialGrenadeThrowEvent("Starting stage 1 ", HHELJCBOLBK);
				KFCAECGLKKO = NFNCNKNABAC.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						EnemyController current = KFCAECGLKKO.Current;
						current.destroyableObj.isImmortal = false;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				CAPKPLPGBFN = (PlayerSwipeWeapon)PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().LAGONJMBJMM[0];
				CAPKPLPGBFN.NBEPFACHJMJ(ONCEGKNMJLM.IGEEPAPBDCP.transform.position);
				INNKKJLCLMM = (GrenadeAmmoSetup)CAPKPLPGBFN.HFNAMMBPJAJ().ammoSetup;
				INNKKJLCLMM.INIBDNGHLPN = 1179f;
				INNKKJLCLMM.LIEABAMBOMG = 1946f;
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				goto case 6u;
				IL_0214:
				if (JMBKPALDGAL < DKAKILBCGPG)
				{
					NEMLKKBGIKJ = (EnemyController)Singleton<LevelBehaviourManager>.instance.FIHJBLEKDNI(LevelManager.instance.behaviours[1]);
					if (NEMLKKBGIKJ != null && NEMLKKBGIKJ.prefab != null)
					{
						NEMLKKBGIKJ.fraction = GHPGNELIDBM.None;
						int nOCEDALFEJM = ObjectPoolDatabase.KJEANKAJELG().APCGDLEHGKL[NEMLKKBGIKJ.LELHDMOANJG()];
						NEMLKKBGIKJ.DisableSpawn();
						Transform transform = ONCEGKNMJLM.IGAOJIJOHDA.transform;
						NEMLKKBGIKJ = (EnemyController)ObjectPoolDatabase.COJFMKNGPBP().GOFLFKCIGNI(nOCEDALFEJM, NEMLKKBGIKJ.indexInObjectPool, transform.position, transform.rotation);
						NEMLKKBGIKJ.StartEnemyBehaviour(EnemyController.AJGFGCHCAPA.Idle, ONCEGKNMJLM.EJEEMOCCGPH.NKBHMMMKGMJ[JMBKPALDGAL]);
						NEMLKKBGIKJ.GBBFIPKBJGG = true;
						NEMLKKBGIKJ.Killed -= BJGCPDNMHDH.AssaulterKilled;
						NEMLKKBGIKJ.Killed += BJGCPDNMHDH.AssaulterKilled;
						NEMLKKBGIKJ.HJFHCPBADLD.speed = 1060f;
						NEMLKKBGIKJ.destroyableObj.isImmortal = false;
						NFNCNKNABAC.Add(NEMLKKBGIKJ);
					}
					PHDOCKCBJOF = new WaitForSeconds(631f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(776f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				break;
			}
			return true;
		}

		public void JMANMKKCDMM()
		{
			throw new NotSupportedException();
		}
	}

	private sealed class MHHGEIJMPPB : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal List<LevelBehaviour>.Enumerator KFCAECGLKKO;

		internal bool FKGHFOJFMBP;

		internal List<ArmyUpgradeIcon> OIBJCLOPOLG;

		internal ArmyUpgradeIcon GOBCHPOLPIE;

		internal Vector3 IODGHHFAHJH;

		internal Vector3 CMIKGAOHHPH;

		internal bool FPHGINDBIDI;

		internal bool JGPPKCAGAGC;

		internal TutorialManagerStage2 BJGCPDNMHDH;

		internal object PHDOCKCBJOF;

		internal bool FDKOKMKIIMG;

		internal int CLPPIAGLCJJ;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		public bool CIIHKFDLDKN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mUnitBoughtState = 0;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						LevelBehaviour current = KFCAECGLKKO.Current;
						if (current.upgradeSlots.isTutorialUnit)
						{
							current.upgradeSlots.bought = false;
							BJGCPDNMHDH.mTutorialUnit = current;
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (BJGCPDNMHDH.mTutorialUnit == null)
				{
					UnityEngine.Debug.LogError(" BUTTONS CONTENT ");
				}
				goto case 1u;
			case 1u:
				if (!GuiElementSingle<LevelUpDialog>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (!GuiElementSingle<LevelUpDialog>.instance.LGHOENABFLJ())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				GuiElementSingle<LevelUpDialog>.instance.EPJJFOOMHNL();
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ios");
				PHDOCKCBJOF = new WaitForSeconds(116f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 3u:
				GuiElementSingle<TutorialDialog>.instance.PBEAOCBHFGD(Localization.Localize("elite1"), Localization.Localize("menu-everyplay-ico"), 804f, TutorialDialog.DODBDLEJOAM.Bottom, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[1].NALOPNJHPLI.transform.position, ELHGOHGPJCF: false, ENIHCPLOOAE: false, 1482f);
				GuiElementSingle<TutorialClickOverlay>.instance.EEMMKEMADFC(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[1].PAKNGGNNNDO.transform.position, GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].EPHBGCBAPAN.size);
				goto case 4u;
			case 4u:
				if (GuiElementSingle<LevelUpDialog>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(952f);
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<ArmyScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Unit");
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 6u;
			case 6u:
				if (!GuiScreenSingle<ArmyScreen>.instance.AFOFDNJOJHG())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				FKGHFOJFMBP = false;
				if (GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().KHEOKHHDGPO() != BJGCPDNMHDH.mTutorialUnit)
				{
					FKGHFOJFMBP = true;
					Singleton<GuiManager>.instance.CMCCOCBIGBB();
					PHDOCKCBJOF = new WaitForSeconds(648f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				goto IL_052e;
			case 7u:
				GuiElementSingle<TutorialDialog>.instance.CLINGHOGNGM("added", 941f);
				OIBJCLOPOLG = GuiScreenSingle<ArmyScreen>.instance.MAPKDMOOFMM();
				GOBCHPOLPIE = null;
				IODGHHFAHJH = Vector3.zero;
				CMIKGAOHHPH = Vector3.one;
				if (OIBJCLOPOLG != null)
				{
					foreach (ArmyUpgradeIcon item in OIBJCLOPOLG)
					{
						if (item.PPMNNKANOEF() == BJGCPDNMHDH.mTutorialUnit)
						{
							GOBCHPOLPIE = item;
							IODGHHFAHJH = item.transform.position;
							CMIKGAOHHPH = item.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(IODGHHFAHJH, ELHGOHGPJCF: false, ENIHCPLOOAE: false, 1129f);
							GuiElementSingle<TutorialClickOverlay>.instance.AJNGLEIBMHD(IODGHHFAHJH, CMIKGAOHHPH);
							break;
						}
					}
				}
				goto case 8u;
			case 8u:
				if (GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().AIHMCHBCJDO() != BJGCPDNMHDH.mTutorialUnit)
				{
					if (GOBCHPOLPIE != null && GOBCHPOLPIE.transform.position != IODGHHFAHJH)
					{
						IODGHHFAHJH = GOBCHPOLPIE.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateTapAnimation(IODGHHFAHJH, ELHGOHGPJCF: false);
						GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(IODGHHFAHJH, CMIKGAOHHPH);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(1077f);
				goto IL_052e;
			case 9u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("menu-wftv-youtube-ico");
				object[] array = new object[0];
				array[0] = Localization.Localize("ItemRarity_3");
				instance.PBEAOCBHFGD(aMKLKMJEMJM, Localization.LocalizeFormat("Multiplayer Record {0:D2}", array), 1007f, TutorialDialog.DODBDLEJOAM.Top);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.BGPBNIJPOKM.cachedTransform.position, new Vector3(480f, 902f, 504f), ELHGOHGPJCF: true, ENIHCPLOOAE: true, 1029f);
				GuiElementSingle<TutorialClickOverlay>.instance.LPKOHAKMOOC(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
				goto case 10u;
			}
			case 10u:
				if (GuiScreenSingle<ArmyScreen>.instance.selectedIcon.levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Locked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 22;
					}
					break;
				}
				BJGCPDNMHDH.mUnitBoughtState = 5;
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("GameCenterPassword");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(1049f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(316f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 94;
				}
				break;
			case 11u:
				if (!GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().BNPKCKFMBLG().upgradeSlots.bought)
				{
					FPHGINDBIDI = false;
					TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
					string aMKLKMJEMJM2 = Localization.Localize("ID_XOFPLAYERSGETSRELEGATED");
					object[] array2 = new object[0];
					array2[0] = Localization.Localize("source_id");
					instance2.PBEAOCBHFGD(aMKLKMJEMJM2, Localization.LocalizeFormat("OfflineRoom", array2), 1900f, TutorialDialog.DODBDLEJOAM.TopRight, NHEJDPIIOJG: false);
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.LNFLDPLGEJE.transform.position, new Vector3(234f, 1848f, 50f), ELHGOHGPJCF: true, ENIHCPLOOAE: false, 8f);
					GuiElementSingle<TutorialClickOverlay>.instance.PGOLMCBEIOD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL);
					JGPPKCAGAGC = true;
					goto case 13u;
				}
				goto case 14u;
			case 12u:
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("Render player texture ERROR: Weapon load failed! (timeouted - 5 sec)"), Localization.LocalizeFormat("ProgressId", Localization.Localize("BUY: ")), 117f, TutorialDialog.DODBDLEJOAM.BottomLeft, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.JPJLKKJJFDB.transform.position, new Vector3(1697f, 586f, 1509f), ELHGOHGPJCF: false, ENIHCPLOOAE: false, 1491f);
				GuiElementSingle<TutorialClickOverlay>.instance.LPKOHAKMOOC(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL);
				goto IL_088a;
			case 13u:
				if (!GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().levelBehaviour.upgradeSlots.bought)
				{
					if (JGPPKCAGAGC && GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Delivered)
					{
						FPHGINDBIDI = true;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
						GuiElementSingle<TutorialClickOverlay>.instance.Hide(357f);
						JGPPKCAGAGC = false;
						Singleton<GuiManager>.instance.CMCCOCBIGBB();
						PHDOCKCBJOF = new WaitForSeconds(58f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = -42;
						}
						break;
					}
					goto IL_088a;
				}
				BJGCPDNMHDH.mUnitBoughtState = 7;
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("N", FPHGINDBIDI);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(1254f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(147f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 55;
				}
				break;
			case 14u:
				BJGCPDNMHDH.mUnitBoughtState = 6;
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ.transform.position, new Vector3(355f, 267f, 561f), ELHGOHGPJCF: true, ENIHCPLOOAE: true, 321f);
				GuiElementSingle<TutorialClickOverlay>.instance.LPKOHAKMOOC(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ, GPCEHFNNCIN: false);
				GuiElementSingle<TutorialClickOverlay>.instance.EOBHJEGACCF();
				PHDOCKCBJOF = new WaitForSeconds(977f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -24;
				}
				break;
			case 15u:
			case 16u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -24;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("\":\n");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(1213f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 17u;
			case 17u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.BJNBLINDAED())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -111;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.BLHPAFCOPMD(Localization.Localize("_HeightParams"), Localization.Localize("{0}{1}"), 501f, TutorialDialog.DODBDLEJOAM.Bottom);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.OMDKNOFNFBB.transform.position, ELHGOHGPJCF: false, ENIHCPLOOAE: false, 795f);
				GuiElementSingle<TutorialClickOverlay>.instance.CLPPGONHLHI(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.ECJHCGPGGDC);
				goto case 18u;
			case 18u:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -33;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("idle");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(1291f);
				BJGCPDNMHDH.mUnitBoughtState = 4;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_088a:
				PHDOCKCBJOF = false;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -44;
				}
				break;
				IL_052e:
				Singleton<EventTrackingManager>.instance.KEKPOIPDIGK("Beanstalk Server Manager: Found Player Progress = ", FKGHFOJFMBP);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(289f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 17;
				}
				break;
			}
			return false;
		}

		public bool LMNIKLKKIDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mUnitBoughtState = 0;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						LevelBehaviour current = KFCAECGLKKO.Current;
						if (current.upgradeSlots.isTutorialUnit)
						{
							current.upgradeSlots.bought = true;
							BJGCPDNMHDH.mTutorialUnit = current;
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (BJGCPDNMHDH.mTutorialUnit == null)
				{
					UnityEngine.Debug.LogError("Squad Member record does not have DatabasePlayer");
				}
				goto case 1u;
			case 1u:
				if (!GuiElementSingle<LevelUpDialog>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (!GuiElementSingle<LevelUpDialog>.instance.OJAAFBFJMCF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				GuiElementSingle<LevelUpDialog>.instance.JIHGNOJJHEB();
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("FormerFullLeagueId");
				PHDOCKCBJOF = new WaitForSeconds(1139f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 3u:
				GuiElementSingle<TutorialDialog>.instance.BLHPAFCOPMD(Localization.Localize("ID_STAT_WARCARDSPLAYED"), Localization.Localize("nonEliteUnits"), 1418f, TutorialDialog.DODBDLEJOAM.Left);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].NALOPNJHPLI.transform.position, ELHGOHGPJCF: true, ENIHCPLOOAE: false, 301f);
				GuiElementSingle<TutorialClickOverlay>.instance.NNPKOKCJMHL(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[1].PAKNGGNNNDO.transform.position, GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].EPHBGCBAPAN.size, GPCEHFNNCIN: false);
				goto case 4u;
			case 4u:
				if (GuiElementSingle<LevelUpDialog>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(464f);
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<ArmyScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("WHEN PLAYING RANDOM MATCHMAKING - SERVER GAME END RESPONSE SHOULD ALWAYS CONTAINS UPDATE OF GLOBAL MEDALS!!!!!!");
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 6u;
			case 6u:
				if (!GuiScreenSingle<ArmyScreen>.instance.AFOFDNJOJHG())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				FKGHFOJFMBP = false;
				if (GuiScreenSingle<ArmyScreen>.instance.selectedIcon.PPMNNKANOEF() != BJGCPDNMHDH.mTutorialUnit)
				{
					FKGHFOJFMBP = true;
					Singleton<GuiManager>.instance.CMCCOCBIGBB();
					PHDOCKCBJOF = new WaitForSeconds(1059f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				goto IL_052e;
			case 7u:
				GuiElementSingle<TutorialDialog>.instance.CLINGHOGNGM("Yes_Clicked", 1427f, TutorialDialog.DODBDLEJOAM.BottomLeft);
				OIBJCLOPOLG = GuiScreenSingle<ArmyScreen>.instance.armyIcons;
				GOBCHPOLPIE = null;
				IODGHHFAHJH = Vector3.zero;
				CMIKGAOHHPH = Vector3.one;
				if (OIBJCLOPOLG != null)
				{
					foreach (ArmyUpgradeIcon item in OIBJCLOPOLG)
					{
						if (item.KHEOKHHDGPO() == BJGCPDNMHDH.mTutorialUnit)
						{
							GOBCHPOLPIE = item;
							IODGHHFAHJH = item.transform.position;
							CMIKGAOHHPH = item.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(IODGHHFAHJH, ELHGOHGPJCF: true, ENIHCPLOOAE: true, 665f);
							GuiElementSingle<TutorialClickOverlay>.instance.NNPKOKCJMHL(IODGHHFAHJH, CMIKGAOHHPH);
							break;
						}
					}
				}
				goto case 8u;
			case 8u:
				if (GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().PPMNNKANOEF() != BJGCPDNMHDH.mTutorialUnit)
				{
					if (GOBCHPOLPIE != null && GOBCHPOLPIE.transform.position != IODGHHFAHJH)
					{
						IODGHHFAHJH = GOBCHPOLPIE.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateTapAnimation(IODGHHFAHJH, ELHGOHGPJCF: false);
						GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(1303f);
				goto IL_052e;
			case 9u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("elitepack1");
				object[] array = new object[0];
				array[0] = Localization.Localize("ID_NOTIFICATION_DAILYREWARDCOUNTABLE_MESSAGE");
				instance.DOLDLDECPIO(aMKLKMJEMJM, Localization.LocalizeFormat("ReSyncDisabledRPC", array), 1813f, TutorialDialog.DODBDLEJOAM.BottomLeft, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.BGPBNIJPOKM.cachedTransform.position, new Vector3(552f, 1681f, 1542f), ELHGOHGPJCF: false, ENIHCPLOOAE: true, 1497f);
				GuiElementSingle<TutorialClickOverlay>.instance.LECHCOBHAFP(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
				goto case 10u;
			}
			case 10u:
				if (GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().AIHMCHBCJDO().upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 29;
					}
					break;
				}
				BJGCPDNMHDH.mUnitBoughtState = 8;
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("DailyMissionsData");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(1993f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1291f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 12;
				}
				break;
			case 11u:
				if (!GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().KHEOKHHDGPO().upgradeSlots.bought)
				{
					FPHGINDBIDI = false;
					TutorialDialog instance3 = GuiElementSingle<TutorialDialog>.instance;
					string aMKLKMJEMJM3 = Localization.Localize("Card_1_Played");
					object[] array3 = new object[0];
					array3[1] = Localization.Localize("Lcom/google/android/gms/games/multiplayer/Invitations;");
					instance3.BLHPAFCOPMD(aMKLKMJEMJM3, Localization.LocalizeFormat("Attempt", array3), 823f, TutorialDialog.DODBDLEJOAM.BottomRight, NHEJDPIIOJG: false);
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.LNFLDPLGEJE.transform.position, new Vector3(1895f, 895f, 782f), ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1993f);
					GuiElementSingle<TutorialClickOverlay>.instance.PGOLMCBEIOD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
					JGPPKCAGAGC = false;
					goto case 13u;
				}
				goto case 14u;
			case 12u:
			{
				TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM2 = Localization.Localize("ID_CONFIRM_ERROR");
				object[] array2 = new object[0];
				array2[1] = Localization.Localize("ERROR WRONG DAILY REWARDS: ");
				instance2.BLHPAFCOPMD(aMKLKMJEMJM2, Localization.LocalizeFormat("goldShields", array2), 8f, TutorialDialog.DODBDLEJOAM.Right, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.JPJLKKJJFDB.transform.position, new Vector3(746f, 479f, 1544f), ELHGOHGPJCF: false, ENIHCPLOOAE: true, 776f);
				GuiElementSingle<TutorialClickOverlay>.instance.LPKOHAKMOOC(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL);
				goto IL_088a;
			}
			case 13u:
				if (!GuiScreenSingle<ArmyScreen>.instance.BDBKFBEIHNF().KHEOKHHDGPO().upgradeSlots.bought)
				{
					if (JGPPKCAGAGC && GuiScreenSingle<ArmyScreen>.instance.selectedIcon.KHEOKHHDGPO().upgradeSlots.unitState == (UpgradeSlots.JLANLLEABDC)8)
					{
						FPHGINDBIDI = true;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
						GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(1598f);
						JGPPKCAGAGC = false;
						Singleton<GuiManager>.instance.TurnOffInputCompletly();
						PHDOCKCBJOF = new WaitForSeconds(1390f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = -93;
						}
						break;
					}
					goto IL_088a;
				}
				BJGCPDNMHDH.mUnitBoughtState = 7;
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("====== Waiting to connect to photon: ", FPHGINDBIDI);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(387f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1944f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -65;
				}
				break;
			case 14u:
				BJGCPDNMHDH.mUnitBoughtState = 0;
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ.transform.position, new Vector3(1222f, 79f, 1393f), ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1473f);
				GuiElementSingle<TutorialClickOverlay>.instance.GBHNBKFGCPG(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ);
				GuiElementSingle<TutorialClickOverlay>.instance.StartBorderAnimation();
				PHDOCKCBJOF = new WaitForSeconds(85f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -84;
				}
				break;
			case 15u:
			case 16u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -118;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_WARNING_MAINTENANCE");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(59f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 17u;
			case 17u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.BJNBLINDAED())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -96;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.DOLDLDECPIO(Localization.Localize("isVIP"), Localization.Localize("ID_CONFIRM_ERROR"), 1567f, TutorialDialog.DODBDLEJOAM.TopLeft, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.OMDKNOFNFBB.transform.position, ELHGOHGPJCF: false, ENIHCPLOOAE: false, 395f);
				GuiElementSingle<TutorialClickOverlay>.instance.JGHBBJEFLEB(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.ECJHCGPGGDC);
				goto case 18u;
			case 18u:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 92;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_HEROICMISSIONX");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(1715f);
				BJGCPDNMHDH.mUnitBoughtState = 3;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_088a:
				PHDOCKCBJOF = true;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -58;
				}
				break;
				IL_052e:
				Singleton<EventTrackingManager>.instance.KEKPOIPDIGK("Total_Battles", FKGHFOJFMBP);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(592f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 33;
				}
				break;
			}
			return false;
		}

		public void IDCJDJMGKFG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object PCOOFELAEJA()
		{
			return PHDOCKCBJOF;
		}

		public void FCHOHLMCHED()
		{
			throw new NotSupportedException();
		}

		public void KINGACOICNF()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void JGKDJGIANIG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void CGCPMAHOJJC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GAPDDGJNMPK()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public MHHGEIJMPPB()
		{
		}

		public void CPEDOIELFMP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void KMIHPBNFGFH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool EEJLFIHFDLK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mUnitBoughtState = 0;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						LevelBehaviour current = KFCAECGLKKO.Current;
						if (current.upgradeSlots.isTutorialUnit)
						{
							current.upgradeSlots.bought = true;
							BJGCPDNMHDH.mTutorialUnit = current;
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (BJGCPDNMHDH.mTutorialUnit == null)
				{
					UnityEngine.Debug.LogError("2-5");
				}
				goto case 1u;
			case 1u:
				if (!GuiElementSingle<LevelUpDialog>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (!GuiElementSingle<LevelUpDialog>.instance.PIAOCINHGJE())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				GuiElementSingle<LevelUpDialog>.instance.TutorialHideParts();
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("D2");
				PHDOCKCBJOF = new WaitForSeconds(1779f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 3u:
				GuiElementSingle<TutorialDialog>.instance.DOLDLDECPIO(Localization.Localize("Connected()"), Localization.Localize("{0:D2}:{1:D2}"), 1976f, TutorialDialog.DODBDLEJOAM.TopLeft);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[1].NALOPNJHPLI.transform.position, ELHGOHGPJCF: true, ENIHCPLOOAE: false, 755f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[1].PAKNGGNNNDO.transform.position, GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[1].EPHBGCBAPAN.size, GPCEHFNNCIN: false);
				goto case 4u;
			case 4u:
				if (GuiElementSingle<LevelUpDialog>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(861f);
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<ArmyScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_GUI_CHAT_SQUAD_LEFT");
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 6u;
			case 6u:
				if (!GuiScreenSingle<ArmyScreen>.instance.AFOFDNJOJHG())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				FKGHFOJFMBP = true;
				if (GuiScreenSingle<ArmyScreen>.instance.selectedIcon.PPMNNKANOEF() != BJGCPDNMHDH.mTutorialUnit)
				{
					FKGHFOJFMBP = true;
					Singleton<GuiManager>.instance.CMCCOCBIGBB();
					PHDOCKCBJOF = new WaitForSeconds(1474f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				goto IL_052e;
			case 7u:
				GuiElementSingle<TutorialDialog>.instance.GKODNFIOLPB("warbucks", 1980f, TutorialDialog.DODBDLEJOAM.Right);
				OIBJCLOPOLG = GuiScreenSingle<ArmyScreen>.instance.armyIcons;
				GOBCHPOLPIE = null;
				IODGHHFAHJH = Vector3.zero;
				CMIKGAOHHPH = Vector3.one;
				if (OIBJCLOPOLG != null)
				{
					foreach (ArmyUpgradeIcon item in OIBJCLOPOLG)
					{
						if (item.levelBehaviour == BJGCPDNMHDH.mTutorialUnit)
						{
							GOBCHPOLPIE = item;
							IODGHHFAHJH = item.transform.position;
							CMIKGAOHHPH = item.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(IODGHHFAHJH, ELHGOHGPJCF: false, ENIHCPLOOAE: false, 536f);
							GuiElementSingle<TutorialClickOverlay>.instance.NNPKOKCJMHL(IODGHHFAHJH, CMIKGAOHHPH);
							break;
						}
					}
				}
				goto case 8u;
			case 8u:
				if (GuiScreenSingle<ArmyScreen>.instance.BDBKFBEIHNF().BNPKCKFMBLG() != BJGCPDNMHDH.mTutorialUnit)
				{
					if (GOBCHPOLPIE != null && GOBCHPOLPIE.transform.position != IODGHHFAHJH)
					{
						IODGHHFAHJH = GOBCHPOLPIE.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.EIDNJNBEPFI(IODGHHFAHJH, ELHGOHGPJCF: false);
						GuiElementSingle<TutorialClickOverlay>.instance.NNPKOKCJMHL(IODGHHFAHJH, CMIKGAOHHPH);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(1180f);
				goto IL_052e;
			case 9u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("friend name");
				object[] array = new object[0];
				array[1] = Localization.Localize("ID_STATE_SELECTINGWARCARDS");
				instance.ShowMenuTutorial(aMKLKMJEMJM, Localization.LocalizeFormat("100+.", array), 1732f, TutorialDialog.DODBDLEJOAM.BottomRight);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.BGPBNIJPOKM.cachedTransform.position, new Vector3(403f, 1836f, 462f), ELHGOHGPJCF: false, ENIHCPLOOAE: false, 1152f);
				GuiElementSingle<TutorialClickOverlay>.instance.GBHNBKFGCPG(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
				goto case 10u;
			}
			case 10u:
				if (GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().KHEOKHHDGPO().upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -75;
					}
					break;
				}
				BJGCPDNMHDH.mUnitBoughtState = 0;
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(". ");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(302f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(850f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -2;
				}
				break;
			case 11u:
				if (!GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().BNPKCKFMBLG().upgradeSlots.bought)
				{
					FPHGINDBIDI = false;
					TutorialDialog instance3 = GuiElementSingle<TutorialDialog>.instance;
					string aMKLKMJEMJM3 = Localization.Localize("grenade_idle");
					object[] array3 = new object[0];
					array3[1] = Localization.Localize("No Request ready or already sent");
					instance3.BLHPAFCOPMD(aMKLKMJEMJM3, Localization.LocalizeFormat("{0} {1}", array3), 37f, TutorialDialog.DODBDLEJOAM.TopLeft);
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.LNFLDPLGEJE.transform.position, new Vector3(574f, 821f, 1024f), ELHGOHGPJCF: false, ENIHCPLOOAE: true, 706f);
					GuiElementSingle<TutorialClickOverlay>.instance.LPKOHAKMOOC(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
					JGPPKCAGAGC = true;
					goto case 13u;
				}
				goto case 14u;
			case 12u:
			{
				TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM2 = Localization.Localize("ID_WARNING_CONNECTIONERROR");
				object[] array2 = new object[0];
				array2[0] = Localization.Localize("LostGameInRow");
				instance2.ShowMenuTutorial(aMKLKMJEMJM2, Localization.LocalizeFormat("GetFriendsList()", array2), 58f, TutorialDialog.DODBDLEJOAM.TopLeft);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.JPJLKKJJFDB.transform.position, new Vector3(1404f, 1832f, 763f), ELHGOHGPJCF: true, ENIHCPLOOAE: true, 1301f);
				GuiElementSingle<TutorialClickOverlay>.instance.LECHCOBHAFP(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
				goto IL_088a;
			}
			case 13u:
				if (!GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().PPMNNKANOEF().upgradeSlots.bought)
				{
					if (JGPPKCAGAGC && GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().BNPKCKFMBLG().upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Active)
					{
						FPHGINDBIDI = false;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
						GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(1539f);
						JGPPKCAGAGC = true;
						Singleton<GuiManager>.instance.CMCCOCBIGBB();
						PHDOCKCBJOF = new WaitForSeconds(813f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 79;
						}
						break;
					}
					goto IL_088a;
				}
				BJGCPDNMHDH.mUnitBoughtState = 3;
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("ID_CONFIRM_LOGGEDOUT", FPHGINDBIDI);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(1183f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(922f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -42;
				}
				break;
			case 14u:
				BJGCPDNMHDH.mUnitBoughtState = 0;
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ.transform.position, new Vector3(1529f, 1359f, 381f), ELHGOHGPJCF: false, ENIHCPLOOAE: true, 1364f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ, GPCEHFNNCIN: false);
				GuiElementSingle<TutorialClickOverlay>.instance.EOBHJEGACCF();
				PHDOCKCBJOF = new WaitForSeconds(751f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 115;
				}
				break;
			case 15u:
			case 16u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 12;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("1");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(1598f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 17u;
			case 17u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 14;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.PBEAOCBHFGD(Localization.Localize("assignment"), Localization.Localize("X2"), 1256f);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.OMDKNOFNFBB.transform.position, ELHGOHGPJCF: true, ENIHCPLOOAE: true, 1841f);
				GuiElementSingle<TutorialClickOverlay>.instance.MLCGPAJJOMB(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.ECJHCGPGGDC);
				goto case 18u;
			case 18u:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 33;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("********** DEBUG GAINED CARDS **********\n");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(718f);
				BJGCPDNMHDH.mUnitBoughtState = 8;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_088a:
				PHDOCKCBJOF = true;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 82;
				}
				break;
				IL_052e:
				Singleton<EventTrackingManager>.instance.RegisterTutorialUnitSelectedEvent("NextBuddyDeposit", FKGHFOJFMBP);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1473f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 57;
				}
				break;
			}
			return false;
		}

		[SpecialName]
		private object FGGMHEIPKAJ()
		{
			return PHDOCKCBJOF;
		}

		public void IOBGNBBJOLM()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void EPIIDCKHCIN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MHFEOEIHFDC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FGFLGJECNLH()
		{
			return PHDOCKCBJOF;
		}

		public void HLJMNBBDJGE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object OHCAEJILBKE()
		{
			return PHDOCKCBJOF;
		}

		public void HHCIHDMICFP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object KBEEEOJMBPG()
		{
			return PHDOCKCBJOF;
		}

		public bool HKPECDLGFJB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mUnitBoughtState = 1;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						LevelBehaviour current = KFCAECGLKKO.Current;
						if (current.upgradeSlots.isTutorialUnit)
						{
							current.upgradeSlots.bought = false;
							BJGCPDNMHDH.mTutorialUnit = current;
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (BJGCPDNMHDH.mTutorialUnit == null)
				{
					UnityEngine.Debug.LogError("Tier");
				}
				goto case 1u;
			case 1u:
				if (!GuiElementSingle<LevelUpDialog>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (!GuiElementSingle<LevelUpDialog>.instance.LGHOENABFLJ())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				GuiElementSingle<LevelUpDialog>.instance.TutorialHideParts();
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_EARN");
				PHDOCKCBJOF = new WaitForSeconds(1874f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 3u:
				GuiElementSingle<TutorialDialog>.instance.PBEAOCBHFGD(Localization.Localize("Visual"), Localization.Localize("WarFriends no puede funcionar sin descargar estos datos adicionales. ¿Seguro que quieres SALIR o prefieres descargar los datos?"), 771f, TutorialDialog.DODBDLEJOAM.TopRight);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[1].NALOPNJHPLI.transform.position, ELHGOHGPJCF: true, ENIHCPLOOAE: true, 1415f);
				GuiElementSingle<TutorialClickOverlay>.instance.AJNGLEIBMHD(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[1].PAKNGGNNNDO.transform.position, GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].EPHBGCBAPAN.size, GPCEHFNNCIN: false);
				goto case 4u;
			case 4u:
				if (GuiElementSingle<LevelUpDialog>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(989f);
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<ArmyScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("WarFriends не может работать без загрузки этих дополнительных данных. Вы действительно хотите ВЫЙТИ или предпочитаете загрузить данные?");
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 6u;
			case 6u:
				if (!GuiScreenSingle<ArmyScreen>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				FKGHFOJFMBP = false;
				if (GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().KHEOKHHDGPO() != BJGCPDNMHDH.mTutorialUnit)
				{
					FKGHFOJFMBP = true;
					Singleton<GuiManager>.instance.TurnOffInputCompletly();
					PHDOCKCBJOF = new WaitForSeconds(671f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				goto IL_052e;
			case 7u:
				GuiElementSingle<TutorialDialog>.instance.FJFFALBAFBD("damage", 1401f, TutorialDialog.DODBDLEJOAM.Top);
				OIBJCLOPOLG = GuiScreenSingle<ArmyScreen>.instance.OOLKNBJNFJC();
				GOBCHPOLPIE = null;
				IODGHHFAHJH = Vector3.zero;
				CMIKGAOHHPH = Vector3.one;
				if (OIBJCLOPOLG != null)
				{
					foreach (ArmyUpgradeIcon item in OIBJCLOPOLG)
					{
						if (item.PPMNNKANOEF() == BJGCPDNMHDH.mTutorialUnit)
						{
							GOBCHPOLPIE = item;
							IODGHHFAHJH = item.transform.position;
							CMIKGAOHHPH = item.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(IODGHHFAHJH, ELHGOHGPJCF: false, ENIHCPLOOAE: false, 44f);
							GuiElementSingle<TutorialClickOverlay>.instance.IGNJKOKGNOI(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
							break;
						}
					}
				}
				goto case 8u;
			case 8u:
				if (GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().AIHMCHBCJDO() != BJGCPDNMHDH.mTutorialUnit)
				{
					if (GOBCHPOLPIE != null && GOBCHPOLPIE.transform.position != IODGHHFAHJH)
					{
						IODGHHFAHJH = GOBCHPOLPIE.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.OBNDALJCPHG(IODGHHFAHJH, ELHGOHGPJCF: false);
						GuiElementSingle<TutorialClickOverlay>.instance.NNPKOKCJMHL(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(1904f);
				goto IL_052e;
			case 9u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("Saved_data.csv");
				object[] array = new object[0];
				array[1] = Localization.Localize(",");
				instance.BLHPAFCOPMD(aMKLKMJEMJM, Localization.LocalizeFormat("ID_CONFIRM_SQUADNAMETAKEN", array), 640f, TutorialDialog.DODBDLEJOAM.Left);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.BGPBNIJPOKM.cachedTransform.position, new Vector3(900f, 1724f, 835f), ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1811f);
				GuiElementSingle<TutorialClickOverlay>.instance.PGOLMCBEIOD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL);
				goto case 10u;
			}
			case 10u:
				if (GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().KHEOKHHDGPO().upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 118;
					}
					break;
				}
				BJGCPDNMHDH.mUnitBoughtState = 0;
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("menu-army-ammo-ico");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(256f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1342f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 32;
				}
				break;
			case 11u:
				if (!GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().AIHMCHBCJDO().upgradeSlots.bought)
				{
					FPHGINDBIDI = false;
					TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
					string aMKLKMJEMJM2 = Localization.Localize("()I");
					object[] array2 = new object[1];
					array2[1] = Localization.Localize(" & ");
					instance2.ShowMenuTutorial(aMKLKMJEMJM2, Localization.LocalizeFormat("getFuseID", array2), 1397f, TutorialDialog.DODBDLEJOAM.TopRight);
					GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.LNFLDPLGEJE.transform.position, new Vector3(693f, 457f, 1265f), ELHGOHGPJCF: false, ENIHCPLOOAE: true, 141f);
					GuiElementSingle<TutorialClickOverlay>.instance.GBHNBKFGCPG(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL);
					JGPPKCAGAGC = false;
					goto case 13u;
				}
				goto case 14u;
			case 12u:
				GuiElementSingle<TutorialDialog>.instance.BLHPAFCOPMD(Localization.Localize("menu-army-cat-shooter"), Localization.LocalizeFormat(">", Localization.Localize("ID_SEARCHFORSQUAD")), 1082f, TutorialDialog.DODBDLEJOAM.TopLeft);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.JPJLKKJJFDB.transform.position, new Vector3(113f, 439f, 1218f), ELHGOHGPJCF: false, ENIHCPLOOAE: true, 748f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
				goto IL_088a;
			case 13u:
				if (!GuiScreenSingle<ArmyScreen>.instance.selectedIcon.BNPKCKFMBLG().upgradeSlots.bought)
				{
					if (JGPPKCAGAGC && GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().KHEOKHHDGPO().upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.UnitDelivered)
					{
						FPHGINDBIDI = true;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
						GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(1796f);
						JGPPKCAGAGC = true;
						Singleton<GuiManager>.instance.TurnOffInputCompletly();
						PHDOCKCBJOF = new WaitForSeconds(108f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 72;
						}
						break;
					}
					goto IL_088a;
				}
				BJGCPDNMHDH.mUnitBoughtState = 4;
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("ID_FACEBOOKLOGINLEGALTEXT", FPHGINDBIDI);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(1890f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1038f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 32;
				}
				break;
			case 14u:
				BJGCPDNMHDH.mUnitBoughtState = 3;
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ.transform.position, new Vector3(243f, 1799f, 1919f), ELHGOHGPJCF: true, ENIHCPLOOAE: true, 841f);
				GuiElementSingle<TutorialClickOverlay>.instance.GBHNBKFGCPG(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ);
				GuiElementSingle<TutorialClickOverlay>.instance.KKCKBELEPHJ();
				PHDOCKCBJOF = new WaitForSeconds(1208f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 77;
				}
				break;
			case 15u:
			case 16u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 118;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Configurations error, there is {0} configurations of type {1}");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(807f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 17u;
			case 17u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.LHDGJFHPJNM())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_DEPLOYAMOUNT"), Localization.Localize("Need add new bundle"), 434f, TutorialDialog.DODBDLEJOAM.TopLeft, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.OMDKNOFNFBB.transform.position, ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1375f);
				GuiElementSingle<TutorialClickOverlay>.instance.CLPPGONHLHI(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.ECJHCGPGGDC);
				goto case 18u;
			case 18u:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 102;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("/");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(760f);
				BJGCPDNMHDH.mUnitBoughtState = 3;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_088a:
				PHDOCKCBJOF = false;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 87;
				}
				break;
				IL_052e:
				Singleton<EventTrackingManager>.instance.KEKPOIPDIGK("DogTagSeconds", FKGHFOJFMBP);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(735f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -72;
				}
				break;
			}
			return false;
		}

		[SpecialName]
		private object CMNCAPEMEJI()
		{
			return PHDOCKCBJOF;
		}

		public void OGDMPCFMMML()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object NOIDHHDEEPL()
		{
			return PHDOCKCBJOF;
		}

		public void KPJIDBHHKFM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool PGOBEIMCPGA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mUnitBoughtState = 0;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						LevelBehaviour current = KFCAECGLKKO.Current;
						if (current.upgradeSlots.isTutorialUnit)
						{
							current.upgradeSlots.bought = true;
							BJGCPDNMHDH.mTutorialUnit = current;
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (BJGCPDNMHDH.mTutorialUnit == null)
				{
					UnityEngine.Debug.LogError("MessageToParse");
				}
				goto case 1u;
			case 1u:
				if (!GuiElementSingle<LevelUpDialog>.instance.BKIGLABDGCP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (!GuiElementSingle<LevelUpDialog>.instance.completeAnimation)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				GuiElementSingle<LevelUpDialog>.instance.TutorialHideParts();
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("overriding army unit ");
				PHDOCKCBJOF = new WaitForSeconds(1347f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 3u:
				GuiElementSingle<TutorialDialog>.instance.BLHPAFCOPMD(Localization.Localize("S"), Localization.Localize("{0}{1}"), 1274f, TutorialDialog.DODBDLEJOAM.TopRight);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[1].NALOPNJHPLI.transform.position, ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1191f);
				GuiElementSingle<TutorialClickOverlay>.instance.NNPKOKCJMHL(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[1].PAKNGGNNNDO.transform.position, GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].EPHBGCBAPAN.size);
				goto case 4u;
			case 4u:
				if (GuiElementSingle<LevelUpDialog>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(746f);
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<ArmyScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("StartEnemyBehaviourNetwork");
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 6u;
			case 6u:
				if (!GuiScreenSingle<ArmyScreen>.instance.MHAIBHBGBOO())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				FKGHFOJFMBP = false;
				if (GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().levelBehaviour != BJGCPDNMHDH.mTutorialUnit)
				{
					FKGHFOJFMBP = false;
					Singleton<GuiManager>.instance.TurnOffInputCompletly();
					PHDOCKCBJOF = new WaitForSeconds(1461f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				goto IL_052e;
			case 7u:
				GuiElementSingle<TutorialDialog>.instance.CLINGHOGNGM("ID_FACEBOOKLOGOUTLEGALTEXT", 131f, TutorialDialog.DODBDLEJOAM.BottomLeft);
				OIBJCLOPOLG = GuiScreenSingle<ArmyScreen>.instance.OOLKNBJNFJC();
				GOBCHPOLPIE = null;
				IODGHHFAHJH = Vector3.zero;
				CMIKGAOHHPH = Vector3.one;
				if (OIBJCLOPOLG != null)
				{
					foreach (ArmyUpgradeIcon item in OIBJCLOPOLG)
					{
						if (item.PPMNNKANOEF() == BJGCPDNMHDH.mTutorialUnit)
						{
							GOBCHPOLPIE = item;
							IODGHHFAHJH = item.transform.position;
							CMIKGAOHHPH = item.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(IODGHHFAHJH, ELHGOHGPJCF: true, ENIHCPLOOAE: true, 913f);
							GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
							break;
						}
					}
				}
				goto case 8u;
			case 8u:
				if (GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().levelBehaviour != BJGCPDNMHDH.mTutorialUnit)
				{
					if (GOBCHPOLPIE != null && GOBCHPOLPIE.transform.position != IODGHHFAHJH)
					{
						IODGHHFAHJH = GOBCHPOLPIE.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.IMOAGBADPCC(IODGHHFAHJH, ELHGOHGPJCF: false);
						GuiElementSingle<TutorialClickOverlay>.instance.AJNGLEIBMHD(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(521f);
				goto IL_052e;
			case 9u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("was added");
				object[] array = new object[0];
				array[0] = Localization.Localize("Hearts");
				instance.ShowMenuTutorial(aMKLKMJEMJM, Localization.LocalizeFormat("Video ad reward - lootbox visuals List =  ", array), 969f, TutorialDialog.DODBDLEJOAM.Bottom);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.BGPBNIJPOKM.cachedTransform.position, new Vector3(777f, 623f, 1014f), ELHGOHGPJCF: false, ENIHCPLOOAE: true, 485f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL);
				goto case 10u;
			}
			case 10u:
				if (GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().KHEOKHHDGPO().upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -128;
					}
					break;
				}
				BJGCPDNMHDH.mUnitBoughtState = 3;
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("menu-gold");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(417f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(476f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 55;
				}
				break;
			case 11u:
				if (!GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().AIHMCHBCJDO().upgradeSlots.bought)
				{
					FPHGINDBIDI = false;
					TutorialDialog instance3 = GuiElementSingle<TutorialDialog>.instance;
					string aMKLKMJEMJM3 = Localization.Localize("Items");
					object[] array3 = new object[0];
					array3[0] = Localization.Localize("Shotgunner spawned");
					instance3.ShowMenuTutorial(aMKLKMJEMJM3, Localization.LocalizeFormat("SquadId = ", array3), 1585f, TutorialDialog.DODBDLEJOAM.TopLeft, NHEJDPIIOJG: false);
					GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.LNFLDPLGEJE.transform.position, new Vector3(1572f, 1808f, 123f), ELHGOHGPJCF: false, ENIHCPLOOAE: false, 1313f);
					GuiElementSingle<TutorialClickOverlay>.instance.PGOLMCBEIOD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL);
					JGPPKCAGAGC = true;
					goto case 13u;
				}
				goto case 14u;
			case 12u:
			{
				TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM2 = Localization.Localize("ID_REMINDER_WEAPONUPGRADEREADY");
				object[] array2 = new object[1];
				array2[1] = Localization.Localize("ID_COLLECTXELITEPARTSX");
				instance2.BLHPAFCOPMD(aMKLKMJEMJM2, Localization.LocalizeFormat("These IDs have the same translations:\n", array2), 879f, TutorialDialog.DODBDLEJOAM.Left, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.JPJLKKJJFDB.transform.position, new Vector3(91f, 864f, 1555f), ELHGOHGPJCF: true, ENIHCPLOOAE: false, 751f);
				GuiElementSingle<TutorialClickOverlay>.instance.LECHCOBHAFP(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
				goto IL_088a;
			}
			case 13u:
				if (!GuiScreenSingle<ArmyScreen>.instance.BDBKFBEIHNF().levelBehaviour.upgradeSlots.bought)
				{
					if (JGPPKCAGAGC && GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().AIHMCHBCJDO().upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Delivered)
					{
						FPHGINDBIDI = true;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.Hide();
						GuiElementSingle<TutorialClickOverlay>.instance.Hide(1276f);
						JGPPKCAGAGC = true;
						Singleton<GuiManager>.instance.CMCCOCBIGBB();
						PHDOCKCBJOF = new WaitForSeconds(1040f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = -5;
						}
						break;
					}
					goto IL_088a;
				}
				BJGCPDNMHDH.mUnitBoughtState = 8;
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("ID_WARNING_FAILTORESTORE", FPHGINDBIDI);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(800f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1738f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -21;
				}
				break;
			case 14u:
				BJGCPDNMHDH.mUnitBoughtState = 0;
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ.transform.position, new Vector3(1516f, 929f, 56f), ELHGOHGPJCF: false, ENIHCPLOOAE: false, 96f);
				GuiElementSingle<TutorialClickOverlay>.instance.LPKOHAKMOOC(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ);
				GuiElementSingle<TutorialClickOverlay>.instance.EMEBKHJECFA();
				PHDOCKCBJOF = new WaitForSeconds(1659f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -46;
				}
				break;
			case 15u:
			case 16u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -16;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_COMPLETEALLTENSTARTERASSIGNMENTS");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(1276f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 17u;
			case 17u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.LHDGJFHPJNM())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 25;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.DOLDLDECPIO(Localization.Localize("ID_GOOGLEPLAYLOGOUTTEXT"), Localization.Localize("DailyMissionsData"), 816f, TutorialDialog.DODBDLEJOAM.TopRight, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.OMDKNOFNFBB.transform.position, ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1323f);
				GuiElementSingle<TutorialClickOverlay>.instance.CAIGHMDPBDI(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.ECJHCGPGGDC, GPCEHFNNCIN: false);
				goto case 18u;
			case 18u:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 127;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Name");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(120f);
				BJGCPDNMHDH.mUnitBoughtState = 3;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_088a:
				PHDOCKCBJOF = true;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -121;
				}
				break;
				IL_052e:
				Singleton<EventTrackingManager>.instance.RegisterTutorialUnitSelectedEvent("{0}{1}[-] {2}/[-] {3}", FKGHFOJFMBP);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(304f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 36;
				}
				break;
			}
			return true;
		}

		[SpecialName]
		private object ANBCMDOAJCM()
		{
			return PHDOCKCBJOF;
		}

		public bool JNHFCKKAPJH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mUnitBoughtState = 1;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						LevelBehaviour current = KFCAECGLKKO.Current;
						if (current.upgradeSlots.isTutorialUnit)
						{
							current.upgradeSlots.bought = true;
							BJGCPDNMHDH.mTutorialUnit = current;
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (BJGCPDNMHDH.mTutorialUnit == null)
				{
					UnityEngine.Debug.LogError("ID_UNITCOMBINATIONNOTSAVED");
				}
				goto case 1u;
			case 1u:
				if (!GuiElementSingle<LevelUpDialog>.instance.AFOFDNJOJHG())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (!GuiElementSingle<LevelUpDialog>.instance.FIOPDLGMHKB())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				GuiElementSingle<LevelUpDialog>.instance.HCODOFNNLDL();
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Bad level manager data, data= ");
				PHDOCKCBJOF = new WaitForSeconds(1848f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 3u:
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_DELIVEREDTIME"), Localization.Localize("Shotgunner"), 382f, TutorialDialog.DODBDLEJOAM.BottomLeft, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].NALOPNJHPLI.transform.position, ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1623f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].PAKNGGNNNDO.transform.position, GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].EPHBGCBAPAN.size, GPCEHFNNCIN: false);
				goto case 4u;
			case 4u:
				if (GuiElementSingle<LevelUpDialog>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(1864f);
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<ArmyScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("getDeviceToken");
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 6u;
			case 6u:
				if (!GuiScreenSingle<ArmyScreen>.instance.BJNBLINDAED())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				FKGHFOJFMBP = true;
				if (GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().AIHMCHBCJDO() != BJGCPDNMHDH.mTutorialUnit)
				{
					FKGHFOJFMBP = false;
					Singleton<GuiManager>.instance.CMCCOCBIGBB();
					PHDOCKCBJOF = new WaitForSeconds(714f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				goto IL_052e;
			case 7u:
				GuiElementSingle<TutorialDialog>.instance.NIGINCPEHFP("{0} {1}/{2} {3}", 286f, TutorialDialog.DODBDLEJOAM.TopRight);
				OIBJCLOPOLG = GuiScreenSingle<ArmyScreen>.instance.OOLKNBJNFJC();
				GOBCHPOLPIE = null;
				IODGHHFAHJH = Vector3.zero;
				CMIKGAOHHPH = Vector3.one;
				if (OIBJCLOPOLG != null)
				{
					foreach (ArmyUpgradeIcon item in OIBJCLOPOLG)
					{
						if (item.KHEOKHHDGPO() == BJGCPDNMHDH.mTutorialUnit)
						{
							GOBCHPOLPIE = item;
							IODGHHFAHJH = item.transform.position;
							CMIKGAOHHPH = item.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(IODGHHFAHJH, ELHGOHGPJCF: false, ENIHCPLOOAE: true, 1211f);
							GuiElementSingle<TutorialClickOverlay>.instance.EEMMKEMADFC(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
							break;
						}
					}
				}
				goto case 8u;
			case 8u:
				if (GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().AIHMCHBCJDO() != BJGCPDNMHDH.mTutorialUnit)
				{
					if (GOBCHPOLPIE != null && GOBCHPOLPIE.transform.position != IODGHHFAHJH)
					{
						IODGHHFAHJH = GOBCHPOLPIE.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.NFPJIFHLFNB(IODGHHFAHJH);
						GuiElementSingle<TutorialClickOverlay>.instance.NNPKOKCJMHL(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(502f);
				goto IL_052e;
			case 9u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("ID_NA");
				object[] array = new object[0];
				array[1] = Localization.Localize("playerVisuals");
				instance.BLHPAFCOPMD(aMKLKMJEMJM, Localization.LocalizeFormat("menu-weapon-benelli-starterpack", array), 186f, TutorialDialog.DODBDLEJOAM.BottomRight);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.BGPBNIJPOKM.cachedTransform.position, new Vector3(1081f, 313f, 661f), ELHGOHGPJCF: false, ENIHCPLOOAE: true, 1041f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
				goto case 10u;
			}
			case 10u:
				if (GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().AIHMCHBCJDO().upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Locked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -14;
					}
					break;
				}
				BJGCPDNMHDH.mUnitBoughtState = 4;
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("lootboxId");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(1679f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1695f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 68;
				}
				break;
			case 11u:
				if (!GuiScreenSingle<ArmyScreen>.instance.selectedIcon.PPMNNKANOEF().upgradeSlots.bought)
				{
					FPHGINDBIDI = false;
					GuiElementSingle<TutorialDialog>.instance.PBEAOCBHFGD(Localization.Localize("recordingStartedEvent + mTryToSetRecording"), Localization.LocalizeFormat("ID_ALLAVAILABLEUNITSMUSTBESELECTED", Localization.Localize("Yes_Clicked")), 1782f, TutorialDialog.DODBDLEJOAM.TopLeft, NHEJDPIIOJG: false);
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.LNFLDPLGEJE.transform.position, new Vector3(1772f, 1682f, 1551f), ELHGOHGPJCF: true, ENIHCPLOOAE: true, 1603f);
					GuiElementSingle<TutorialClickOverlay>.instance.LECHCOBHAFP(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
					JGPPKCAGAGC = true;
					goto case 13u;
				}
				goto case 14u;
			case 12u:
			{
				TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM2 = Localization.Localize("如不下载这些额外数据，《战争之友》将无法运行。您希望退出还是下载这些数据？");
				object[] array2 = new object[1];
				array2[1] = Localization.Localize("height");
				instance2.DOLDLDECPIO(aMKLKMJEMJM2, Localization.LocalizeFormat("WarArenaConfig", array2), 1172f);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.JPJLKKJJFDB.transform.position, new Vector3(270f, 1782f, 464f), ELHGOHGPJCF: false, ENIHCPLOOAE: false, 1809f);
				GuiElementSingle<TutorialClickOverlay>.instance.PGOLMCBEIOD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL);
				goto IL_088a;
			}
			case 13u:
				if (!GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().KHEOKHHDGPO().upgradeSlots.bought)
				{
					if (JGPPKCAGAGC && GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().PPMNNKANOEF().upgradeSlots.unitState == (UpgradeSlots.JLANLLEABDC)8)
					{
						FPHGINDBIDI = true;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
						GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(1145f);
						JGPPKCAGAGC = true;
						Singleton<GuiManager>.instance.TurnOffInputCompletly();
						PHDOCKCBJOF = new WaitForSeconds(976f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = -83;
						}
						break;
					}
					goto IL_088a;
				}
				BJGCPDNMHDH.mUnitBoughtState = 5;
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("DeliveryTime", FPHGINDBIDI);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(1267f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1516f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -16;
				}
				break;
			case 14u:
				BJGCPDNMHDH.mUnitBoughtState = 1;
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ.transform.position, new Vector3(686f, 256f, 1714f), ELHGOHGPJCF: false, ENIHCPLOOAE: true, 312f);
				GuiElementSingle<TutorialClickOverlay>.instance.LECHCOBHAFP(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ, GPCEHFNNCIN: false);
				GuiElementSingle<TutorialClickOverlay>.instance.EDPNLNIPCGJ();
				PHDOCKCBJOF = new WaitForSeconds(733f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -103;
				}
				break;
			case 15u:
			case 16u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 97;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("DailyMissionsCompletionRewardTickets");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(1946f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 17u;
			case 17u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 62;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.BLHPAFCOPMD(Localization.Localize("{0:D2}:{1:D2}"), Localization.Localize("ID_TUTORIAL_UPGRADEUNIT_4"), 1851f, TutorialDialog.DODBDLEJOAM.BottomLeft);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.OMDKNOFNFBB.transform.position, ELHGOHGPJCF: false, ENIHCPLOOAE: false, 283f);
				GuiElementSingle<TutorialClickOverlay>.instance.MLCGPAJJOMB(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.ECJHCGPGGDC);
				goto case 18u;
			case 18u:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Buy_DogTags");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(159f);
				BJGCPDNMHDH.mUnitBoughtState = 7;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_088a:
				PHDOCKCBJOF = false;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -5;
				}
				break;
				IL_052e:
				Singleton<EventTrackingManager>.instance.RegisterTutorialUnitSelectedEvent("DogTagSeconds", FKGHFOJFMBP);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(349f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -48;
				}
				break;
			}
			return false;
		}

		public bool IGOKEIDOCKB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mUnitBoughtState = 1;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						LevelBehaviour current = KFCAECGLKKO.Current;
						if (current.upgradeSlots.isTutorialUnit)
						{
							current.upgradeSlots.bought = false;
							BJGCPDNMHDH.mTutorialUnit = current;
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (BJGCPDNMHDH.mTutorialUnit == null)
				{
					UnityEngine.Debug.LogError("LoadingFinishedRPC");
				}
				goto case 1u;
			case 1u:
				if (!GuiElementSingle<LevelUpDialog>.instance.BJNBLINDAED())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (!GuiElementSingle<LevelUpDialog>.instance.LGHOENABFLJ())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				GuiElementSingle<LevelUpDialog>.instance.TutorialHideParts();
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_EXPIRED");
				PHDOCKCBJOF = new WaitForSeconds(309f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 3u:
				GuiElementSingle<TutorialDialog>.instance.BLHPAFCOPMD(Localization.Localize("throw_grenade_up"), Localization.Localize("Army upgrade for "), 1454f, TutorialDialog.DODBDLEJOAM.Top, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[1].NALOPNJHPLI.transform.position, ELHGOHGPJCF: false, ENIHCPLOOAE: true, 807f);
				GuiElementSingle<TutorialClickOverlay>.instance.AJNGLEIBMHD(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].PAKNGGNNNDO.transform.position, GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[1].EPHBGCBAPAN.size);
				goto case 4u;
			case 4u:
				if (GuiElementSingle<LevelUpDialog>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(376f);
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<ArmyScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ActiveTier");
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 6u;
			case 6u:
				if (!GuiScreenSingle<ArmyScreen>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				FKGHFOJFMBP = false;
				if (GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().levelBehaviour != BJGCPDNMHDH.mTutorialUnit)
				{
					FKGHFOJFMBP = false;
					Singleton<GuiManager>.instance.CMCCOCBIGBB();
					PHDOCKCBJOF = new WaitForSeconds(501f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				goto IL_052e;
			case 7u:
				GuiElementSingle<TutorialDialog>.instance.GPIFEPGEHLF("withAttribute5", 514f, TutorialDialog.DODBDLEJOAM.BottomRight);
				OIBJCLOPOLG = GuiScreenSingle<ArmyScreen>.instance.armyIcons;
				GOBCHPOLPIE = null;
				IODGHHFAHJH = Vector3.zero;
				CMIKGAOHHPH = Vector3.one;
				if (OIBJCLOPOLG != null)
				{
					foreach (ArmyUpgradeIcon item in OIBJCLOPOLG)
					{
						if (item.levelBehaviour == BJGCPDNMHDH.mTutorialUnit)
						{
							GOBCHPOLPIE = item;
							IODGHHFAHJH = item.transform.position;
							CMIKGAOHHPH = item.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(IODGHHFAHJH, ELHGOHGPJCF: true, ENIHCPLOOAE: false, 869f);
							GuiElementSingle<TutorialClickOverlay>.instance.NNPKOKCJMHL(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
							break;
						}
					}
				}
				goto case 8u;
			case 8u:
				if (GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().PPMNNKANOEF() != BJGCPDNMHDH.mTutorialUnit)
				{
					if (GOBCHPOLPIE != null && GOBCHPOLPIE.transform.position != IODGHHFAHJH)
					{
						IODGHHFAHJH = GOBCHPOLPIE.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.IMOAGBADPCC(IODGHHFAHJH, ELHGOHGPJCF: false);
						GuiElementSingle<TutorialClickOverlay>.instance.IGNJKOKGNOI(IODGHHFAHJH, CMIKGAOHHPH);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(1338f);
				goto IL_052e;
			case 9u:
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("height"), Localization.LocalizeFormat("ID_TUTORIAL_GO_TO_ARMORY_2_DOWN", Localization.Localize("ID_ISALREADYMEMBEROFANOTHERSQUAD")), 1842f, TutorialDialog.DODBDLEJOAM.TopLeft, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.BGPBNIJPOKM.cachedTransform.position, new Vector3(618f, 824f, 1520f), ELHGOHGPJCF: false, ENIHCPLOOAE: true, 1897f);
				GuiElementSingle<TutorialClickOverlay>.instance.GBHNBKFGCPG(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
				goto case 10u;
			case 10u:
				if (GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Locked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 97;
					}
					break;
				}
				BJGCPDNMHDH.mUnitBoughtState = 0;
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_STAT_LMGKILLS");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(972f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1285f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -110;
				}
				break;
			case 11u:
				if (!GuiScreenSingle<ArmyScreen>.instance.BDBKFBEIHNF().levelBehaviour.upgradeSlots.bought)
				{
					FPHGINDBIDI = true;
					GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("game-card-ico-emptymag"), Localization.LocalizeFormat("ID_ARENARULES_NORELOADING", Localization.Localize("id")), 1712f);
					GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.LNFLDPLGEJE.transform.position, new Vector3(738f, 683f, 1552f), ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1629f);
					GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
					JGPPKCAGAGC = true;
					goto case 13u;
				}
				goto case 14u;
			case 12u:
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_SUBSCRIPTIODETAILS_HINT3TRAILGOOGLE"), Localization.LocalizeFormat("N", Localization.Localize("setCustomProfileNumber")), 1099f, TutorialDialog.DODBDLEJOAM.Top, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.JPJLKKJJFDB.transform.position, new Vector3(568f, 1937f, 105f), ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1035f);
				GuiElementSingle<TutorialClickOverlay>.instance.LECHCOBHAFP(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
				goto IL_088a;
			case 13u:
				if (!GuiScreenSingle<ArmyScreen>.instance.selectedIcon.BNPKCKFMBLG().upgradeSlots.bought)
				{
					if (JGPPKCAGAGC && GuiScreenSingle<ArmyScreen>.instance.selectedIcon.levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.UnitDelivered)
					{
						FPHGINDBIDI = false;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.Hide();
						GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(1897f);
						JGPPKCAGAGC = true;
						Singleton<GuiManager>.instance.TurnOffInputCompletly();
						PHDOCKCBJOF = new WaitForSeconds(1014f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 96;
						}
						break;
					}
					goto IL_088a;
				}
				BJGCPDNMHDH.mUnitBoughtState = 4;
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("elite", FPHGINDBIDI);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(215f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1623f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -113;
				}
				break;
			case 14u:
				BJGCPDNMHDH.mUnitBoughtState = 3;
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ.transform.position, new Vector3(140f, 78f, 865f), ELHGOHGPJCF: false, ENIHCPLOOAE: true, 565f);
				GuiElementSingle<TutorialClickOverlay>.instance.LPKOHAKMOOC(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ);
				GuiElementSingle<TutorialClickOverlay>.instance.JMPLMMANKMP();
				PHDOCKCBJOF = new WaitForSeconds(1015f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -111;
				}
				break;
			case 15u:
			case 16u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 51;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Battle id = ");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(1667f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 17u;
			case 17u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.BJNBLINDAED())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -28;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("FinishGameCoopClient"), Localization.Localize(")"), 1525f, TutorialDialog.DODBDLEJOAM.Left);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.OMDKNOFNFBB.transform.position, ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1337f);
				GuiElementSingle<TutorialClickOverlay>.instance.CAIGHMDPBDI(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.ECJHCGPGGDC);
				goto case 18u;
			case 18u:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -28;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("HeroicMissionsUnlocked");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(63f);
				BJGCPDNMHDH.mUnitBoughtState = 8;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_088a:
				PHDOCKCBJOF = false;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 124;
				}
				break;
				IL_052e:
				Singleton<EventTrackingManager>.instance.KEKPOIPDIGK("213 MENU ARMY SCREEN SHOWN", FKGHFOJFMBP);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1485f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 71;
				}
				break;
			}
			return false;
		}

		public void JJOAHIOBOPO()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CCANBMDEKMB()
		{
			return PHDOCKCBJOF;
		}

		public bool GBLFIBDBMGE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mUnitBoughtState = 1;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						LevelBehaviour current = KFCAECGLKKO.Current;
						if (current.upgradeSlots.isTutorialUnit)
						{
							current.upgradeSlots.bought = false;
							BJGCPDNMHDH.mTutorialUnit = current;
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (BJGCPDNMHDH.mTutorialUnit == null)
				{
					UnityEngine.Debug.LogError("country-belarus");
				}
				goto case 1u;
			case 1u:
				if (!GuiElementSingle<LevelUpDialog>.instance.MHAIBHBGBOO())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (!GuiElementSingle<LevelUpDialog>.instance.EEDNBIIPMAG())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				GuiElementSingle<LevelUpDialog>.instance.EPJJFOOMHNL();
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(" arena id");
				PHDOCKCBJOF = new WaitForSeconds(1387f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 3u:
				GuiElementSingle<TutorialDialog>.instance.DOLDLDECPIO(Localization.Localize("8 SQUAD REMINDER\tIs in squad: {0}\tLevel: {1}/{2}"), Localization.Localize("ID_CONFIRM_ERROR"), 1897f, TutorialDialog.DODBDLEJOAM.BottomRight, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].NALOPNJHPLI.transform.position, ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1338f);
				GuiElementSingle<TutorialClickOverlay>.instance.EEMMKEMADFC(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].PAKNGGNNNDO.transform.position, GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[1].EPHBGCBAPAN.size);
				goto case 4u;
			case 4u:
				if (GuiElementSingle<LevelUpDialog>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(1987f);
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<ArmyScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("You probably assigned bad type of AmmoSetup to gun");
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 6u;
			case 6u:
				if (!GuiScreenSingle<ArmyScreen>.instance.BKIGLABDGCP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				FKGHFOJFMBP = false;
				if (GuiScreenSingle<ArmyScreen>.instance.BDBKFBEIHNF().levelBehaviour != BJGCPDNMHDH.mTutorialUnit)
				{
					FKGHFOJFMBP = false;
					Singleton<GuiManager>.instance.CMCCOCBIGBB();
					PHDOCKCBJOF = new WaitForSeconds(1558f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto IL_052e;
			case 7u:
				GuiElementSingle<TutorialDialog>.instance.ShowSpecial("CardsPlayed", 1119f, TutorialDialog.DODBDLEJOAM.BottomLeft);
				OIBJCLOPOLG = GuiScreenSingle<ArmyScreen>.instance.OOLKNBJNFJC();
				GOBCHPOLPIE = null;
				IODGHHFAHJH = Vector3.zero;
				CMIKGAOHHPH = Vector3.one;
				if (OIBJCLOPOLG != null)
				{
					foreach (ArmyUpgradeIcon item in OIBJCLOPOLG)
					{
						if (item.BNPKCKFMBLG() == BJGCPDNMHDH.mTutorialUnit)
						{
							GOBCHPOLPIE = item;
							IODGHHFAHJH = item.transform.position;
							CMIKGAOHHPH = item.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(IODGHHFAHJH, ELHGOHGPJCF: false, ENIHCPLOOAE: false, 1055f);
							GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
							break;
						}
					}
				}
				goto case 8u;
			case 8u:
				if (GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().AIHMCHBCJDO() != BJGCPDNMHDH.mTutorialUnit)
				{
					if (GOBCHPOLPIE != null && GOBCHPOLPIE.transform.position != IODGHHFAHJH)
					{
						IODGHHFAHJH = GOBCHPOLPIE.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateTapAnimation(IODGHHFAHJH);
						GuiElementSingle<TutorialClickOverlay>.instance.AJNGLEIBMHD(IODGHHFAHJH, CMIKGAOHHPH);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(946f);
				goto IL_052e;
			case 9u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("), ");
				object[] array = new object[1];
				array[1] = Localization.Localize("PlayeScifiParticles");
				instance.DOLDLDECPIO(aMKLKMJEMJM, Localization.LocalizeFormat(", name = ", array), 1094f, TutorialDialog.DODBDLEJOAM.BottomLeft);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.BGPBNIJPOKM.cachedTransform.position, new Vector3(1098f, 1438f, 1861f), ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1401f);
				GuiElementSingle<TutorialClickOverlay>.instance.LECHCOBHAFP(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
				goto case 10u;
			}
			case 10u:
				if (GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().PPMNNKANOEF().upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 99;
					}
					break;
				}
				BJGCPDNMHDH.mUnitBoughtState = 8;
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_YOURDOGTAGSAREFULLMOVEALONG");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(1381f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(539f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -50;
				}
				break;
			case 11u:
				if (!GuiScreenSingle<ArmyScreen>.instance.BDBKFBEIHNF().KHEOKHHDGPO().upgradeSlots.bought)
				{
					FPHGINDBIDI = false;
					TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
					string aMKLKMJEMJM2 = Localization.Localize("GameGold");
					object[] array2 = new object[0];
					array2[1] = Localization.Localize("You probably assigned bad type of AmmoSetup to gun");
					instance2.DOLDLDECPIO(aMKLKMJEMJM2, Localization.LocalizeFormat("game-card-ico-shieldgenerator", array2), 1985f, TutorialDialog.DODBDLEJOAM.Bottom, NHEJDPIIOJG: false);
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.LNFLDPLGEJE.transform.position, new Vector3(1342f, 1513f, 548f), ELHGOHGPJCF: false, ENIHCPLOOAE: false, 948f);
					GuiElementSingle<TutorialClickOverlay>.instance.LECHCOBHAFP(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
					JGPPKCAGAGC = true;
					goto case 13u;
				}
				goto case 14u;
			case 12u:
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("{0}{1}[-] {2}/[-] 3"), Localization.LocalizeFormat("-", Localization.Localize("SpentWarbucks")), 1902f, TutorialDialog.DODBDLEJOAM.Center, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.JPJLKKJJFDB.transform.position, new Vector3(1369f, 762f, 1928f), ELHGOHGPJCF: false, ENIHCPLOOAE: true, 861f);
				GuiElementSingle<TutorialClickOverlay>.instance.GBHNBKFGCPG(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
				goto IL_088a;
			case 13u:
				if (!GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().BNPKCKFMBLG().upgradeSlots.bought)
				{
					if (JGPPKCAGAGC && GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().BNPKCKFMBLG().upgradeSlots.unitState == (UpgradeSlots.JLANLLEABDC)8)
					{
						FPHGINDBIDI = false;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
						GuiElementSingle<TutorialClickOverlay>.instance.Hide(1148f);
						JGPPKCAGAGC = false;
						Singleton<GuiManager>.instance.CMCCOCBIGBB();
						PHDOCKCBJOF = new WaitForSeconds(122f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = -107;
						}
						break;
					}
					goto IL_088a;
				}
				BJGCPDNMHDH.mUnitBoughtState = 8;
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("ID_CONFIRM_GAMEDOESNOTEXIST", FPHGINDBIDI);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(825f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(712f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -80;
				}
				break;
			case 14u:
				BJGCPDNMHDH.mUnitBoughtState = 8;
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ.transform.position, new Vector3(1229f, 53f, 1537f), ELHGOHGPJCF: false, ENIHCPLOOAE: true, 1795f);
				GuiElementSingle<TutorialClickOverlay>.instance.LECHCOBHAFP(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ);
				GuiElementSingle<TutorialClickOverlay>.instance.KKCKBELEPHJ();
				PHDOCKCBJOF = new WaitForSeconds(1484f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -72;
				}
				break;
			case 15u:
			case 16u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 57;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_YOUNEEDMONEYTOTRAINELITE");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(840f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 17u;
			case 17u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.MHAIBHBGBOO())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -37;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.BLHPAFCOPMD(Localization.Localize(" 1"), Localization.Localize("orderId"), 1174f, TutorialDialog.DODBDLEJOAM.Bottom);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.OMDKNOFNFBB.transform.position, ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1723f);
				GuiElementSingle<TutorialClickOverlay>.instance.JGHBBJEFLEB(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.ECJHCGPGGDC);
				goto case 18u;
			case 18u:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -108;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("MissionReward");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(1512f);
				BJGCPDNMHDH.mUnitBoughtState = 8;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_088a:
				PHDOCKCBJOF = false;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -39;
				}
				break;
				IL_052e:
				Singleton<EventTrackingManager>.instance.KEKPOIPDIGK("#VAVRO# Accept Challenge Message {0}", FKGHFOJFMBP);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1079f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -7;
				}
				break;
			}
			return false;
		}

		public bool DAKMHLEGICB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mUnitBoughtState = 1;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						LevelBehaviour current = KFCAECGLKKO.Current;
						if (current.upgradeSlots.isTutorialUnit)
						{
							current.upgradeSlots.bought = true;
							BJGCPDNMHDH.mTutorialUnit = current;
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (BJGCPDNMHDH.mTutorialUnit == null)
				{
					UnityEngine.Debug.LogError("menu-event-gift");
				}
				goto case 1u;
			case 1u:
				if (!GuiElementSingle<LevelUpDialog>.instance.BKIGLABDGCP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (!GuiElementSingle<LevelUpDialog>.instance.OJAAFBFJMCF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				GuiElementSingle<LevelUpDialog>.instance.HCODOFNNLDL();
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_FACEBOOKUSER");
				PHDOCKCBJOF = new WaitForSeconds(425f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 3u:
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("SquadId"), Localization.Localize("EventAssignmentClaimed"), 1488f, TutorialDialog.DODBDLEJOAM.Bottom);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].NALOPNJHPLI.transform.position, ELHGOHGPJCF: true, ENIHCPLOOAE: true, 316f);
				GuiElementSingle<TutorialClickOverlay>.instance.NNPKOKCJMHL(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].PAKNGGNNNDO.transform.position, GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[1].EPHBGCBAPAN.size);
				goto case 4u;
			case 4u:
				if (GuiElementSingle<LevelUpDialog>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(468f);
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<ArmyScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("game-tutorial-minigunner");
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 6u;
			case 6u:
				if (!GuiScreenSingle<ArmyScreen>.instance.MHAIBHBGBOO())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				FKGHFOJFMBP = false;
				if (GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().PPMNNKANOEF() != BJGCPDNMHDH.mTutorialUnit)
				{
					FKGHFOJFMBP = false;
					Singleton<GuiManager>.instance.TurnOffInputCompletly();
					PHDOCKCBJOF = new WaitForSeconds(1558f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				goto IL_052e;
			case 7u:
				GuiElementSingle<TutorialDialog>.instance.CLINGHOGNGM("Squad", 897f);
				OIBJCLOPOLG = GuiScreenSingle<ArmyScreen>.instance.armyIcons;
				GOBCHPOLPIE = null;
				IODGHHFAHJH = Vector3.zero;
				CMIKGAOHHPH = Vector3.one;
				if (OIBJCLOPOLG != null)
				{
					foreach (ArmyUpgradeIcon item in OIBJCLOPOLG)
					{
						if (item.KHEOKHHDGPO() == BJGCPDNMHDH.mTutorialUnit)
						{
							GOBCHPOLPIE = item;
							IODGHHFAHJH = item.transform.position;
							CMIKGAOHHPH = item.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(IODGHHFAHJH, ELHGOHGPJCF: false, ENIHCPLOOAE: false, 318f);
							GuiElementSingle<TutorialClickOverlay>.instance.IGNJKOKGNOI(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
							break;
						}
					}
				}
				goto case 8u;
			case 8u:
				if (GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().PPMNNKANOEF() != BJGCPDNMHDH.mTutorialUnit)
				{
					if (GOBCHPOLPIE != null && GOBCHPOLPIE.transform.position != IODGHHFAHJH)
					{
						IODGHHFAHJH = GOBCHPOLPIE.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateTapAnimation(IODGHHFAHJH, ELHGOHGPJCF: false);
						GuiElementSingle<TutorialClickOverlay>.instance.IGNJKOKGNOI(IODGHHFAHJH, CMIKGAOHHPH);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(1852f);
				goto IL_052e;
			case 9u:
				GuiElementSingle<TutorialDialog>.instance.PBEAOCBHFGD(Localization.Localize("AFLODScrpt"), Localization.LocalizeFormat("FuseboxxConfigValue", Localization.Localize("ID_SQUADEVENT")), 507f, TutorialDialog.DODBDLEJOAM.Right);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.BGPBNIJPOKM.cachedTransform.position, new Vector3(417f, 1792f, 40f), ELHGOHGPJCF: true, ENIHCPLOOAE: false, 915f);
				GuiElementSingle<TutorialClickOverlay>.instance.PGOLMCBEIOD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL);
				goto case 10u;
			case 10u:
				if (GuiScreenSingle<ArmyScreen>.instance.selectedIcon.BNPKCKFMBLG().upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 68;
					}
					break;
				}
				BJGCPDNMHDH.mUnitBoughtState = 7;
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Main sceneLoaded");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(1258f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(979f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 72;
				}
				break;
			case 11u:
				if (!GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().BNPKCKFMBLG().upgradeSlots.bought)
				{
					FPHGINDBIDI = true;
					TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
					string aMKLKMJEMJM = Localization.Localize("LevelExperience");
					object[] array = new object[0];
					array[1] = Localization.Localize("squadsFromLeague");
					instance.PBEAOCBHFGD(aMKLKMJEMJM, Localization.LocalizeFormat("<", array), 978f, TutorialDialog.DODBDLEJOAM.Top, NHEJDPIIOJG: false);
					GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.LNFLDPLGEJE.transform.position, new Vector3(156f, 1697f, 675f), ELHGOHGPJCF: true, ENIHCPLOOAE: false, 617f);
					GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL);
					JGPPKCAGAGC = false;
					goto case 13u;
				}
				goto case 14u;
			case 12u:
				GuiElementSingle<TutorialDialog>.instance.DOLDLDECPIO(Localization.Localize("VipReward2"), Localization.LocalizeFormat("FpsDevice", Localization.Localize("Current unit is not delivering at the moment!!!")), 547f, TutorialDialog.DODBDLEJOAM.TopRight);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.JPJLKKJJFDB.transform.position, new Vector3(1640f, 1886f, 1795f), ELHGOHGPJCF: true, ENIHCPLOOAE: false, 631f);
				GuiElementSingle<TutorialClickOverlay>.instance.LPKOHAKMOOC(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL);
				goto IL_088a;
			case 13u:
				if (!GuiScreenSingle<ArmyScreen>.instance.BDBKFBEIHNF().levelBehaviour.upgradeSlots.bought)
				{
					if (JGPPKCAGAGC && GuiScreenSingle<ArmyScreen>.instance.BDBKFBEIHNF().KHEOKHHDGPO().upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Locked)
					{
						FPHGINDBIDI = true;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.Hide();
						GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(1543f);
						JGPPKCAGAGC = true;
						Singleton<GuiManager>.instance.CMCCOCBIGBB();
						PHDOCKCBJOF = new WaitForSeconds(1839f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 76;
						}
						break;
					}
					goto IL_088a;
				}
				BJGCPDNMHDH.mUnitBoughtState = 4;
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("ID_GUI_EQUIP", FPHGINDBIDI);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(52f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(497f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -114;
				}
				break;
			case 14u:
				BJGCPDNMHDH.mUnitBoughtState = 0;
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ.transform.position, new Vector3(1318f, 751f, 721f), ELHGOHGPJCF: false, ENIHCPLOOAE: true, 1186f);
				GuiElementSingle<TutorialClickOverlay>.instance.LECHCOBHAFP(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ, GPCEHFNNCIN: false);
				GuiElementSingle<TutorialClickOverlay>.instance.EOBHJEGACCF();
				PHDOCKCBJOF = new WaitForSeconds(364f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -66;
				}
				break;
			case 15u:
			case 16u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 110;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_CONFIRM_GAMEDIDNTEXIST");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(213f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 17u;
			case 17u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -13;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.DOLDLDECPIO(Localization.Localize("Exception during Load Event Assignment Config: "), Localization.Localize("menu-info-ico"), 1721f, TutorialDialog.DODBDLEJOAM.TopRight);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.OMDKNOFNFBB.transform.position, ELHGOHGPJCF: true, ENIHCPLOOAE: true, 622f);
				GuiElementSingle<TutorialClickOverlay>.instance.CLPPGONHLHI(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.ECJHCGPGGDC);
				goto case 18u;
			case 18u:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 124;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_LOGINREWARDS");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(390f);
				BJGCPDNMHDH.mUnitBoughtState = 6;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_088a:
				PHDOCKCBJOF = true;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 55;
				}
				break;
				IL_052e:
				Singleton<EventTrackingManager>.instance.RegisterTutorialUnitSelectedEvent("IAPOfferInfo", FKGHFOJFMBP);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1982f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -83;
				}
				break;
			}
			return false;
		}

		public void NCFGFLNBHOI()
		{
			throw new NotSupportedException();
		}

		public void ODFCBNONFPL()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BBHOODPMEFM()
		{
			return PHDOCKCBJOF;
		}

		public void HJLCPFDBNKP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void LPKDPNHBLGJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object CGIBLCGGMJM()
		{
			return PHDOCKCBJOF;
		}

		public bool JIIOHNFHPOI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mUnitBoughtState = 1;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						LevelBehaviour current = KFCAECGLKKO.Current;
						if (current.upgradeSlots.isTutorialUnit)
						{
							current.upgradeSlots.bought = false;
							BJGCPDNMHDH.mTutorialUnit = current;
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (BJGCPDNMHDH.mTutorialUnit == null)
				{
					UnityEngine.Debug.LogError("Error: Could not start game ");
				}
				goto case 1u;
			case 1u:
				if (!GuiElementSingle<LevelUpDialog>.instance.MHAIBHBGBOO())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (!GuiElementSingle<LevelUpDialog>.instance.EEDNBIIPMAG())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				GuiElementSingle<LevelUpDialog>.instance.JIHGNOJJHEB();
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("shieldDestroy");
				PHDOCKCBJOF = new WaitForSeconds(878f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 3u:
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("\t"), Localization.Localize("ID_STARTERASSIGNMENT"), 208f);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[1].NALOPNJHPLI.transform.position, ELHGOHGPJCF: false, ENIHCPLOOAE: true, 1694f);
				GuiElementSingle<TutorialClickOverlay>.instance.AJNGLEIBMHD(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[1].PAKNGGNNNDO.transform.position, GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].EPHBGCBAPAN.size, GPCEHFNNCIN: false);
				goto case 4u;
			case 4u:
				if (GuiElementSingle<LevelUpDialog>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(1037f);
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<ArmyScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_CONFIRM_ERROR");
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 6u;
			case 6u:
				if (!GuiScreenSingle<ArmyScreen>.instance.BJNBLINDAED())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				FKGHFOJFMBP = true;
				if (GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().PPMNNKANOEF() != BJGCPDNMHDH.mTutorialUnit)
				{
					FKGHFOJFMBP = false;
					Singleton<GuiManager>.instance.TurnOffInputCompletly();
					PHDOCKCBJOF = new WaitForSeconds(583f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				goto IL_052e;
			case 7u:
				GuiElementSingle<TutorialDialog>.instance.ShowSpecial("file://", 1520f, TutorialDialog.DODBDLEJOAM.Right);
				OIBJCLOPOLG = GuiScreenSingle<ArmyScreen>.instance.armyIcons;
				GOBCHPOLPIE = null;
				IODGHHFAHJH = Vector3.zero;
				CMIKGAOHHPH = Vector3.one;
				if (OIBJCLOPOLG != null)
				{
					foreach (ArmyUpgradeIcon item in OIBJCLOPOLG)
					{
						if (item.KHEOKHHDGPO() == BJGCPDNMHDH.mTutorialUnit)
						{
							GOBCHPOLPIE = item;
							IODGHHFAHJH = item.transform.position;
							CMIKGAOHHPH = item.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(IODGHHFAHJH, ELHGOHGPJCF: true, ENIHCPLOOAE: false, 895f);
							GuiElementSingle<TutorialClickOverlay>.instance.NNPKOKCJMHL(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
							break;
						}
					}
				}
				goto case 8u;
			case 8u:
				if (GuiScreenSingle<ArmyScreen>.instance.BDBKFBEIHNF().KHEOKHHDGPO() != BJGCPDNMHDH.mTutorialUnit)
				{
					if (GOBCHPOLPIE != null && GOBCHPOLPIE.transform.position != IODGHHFAHJH)
					{
						IODGHHFAHJH = GOBCHPOLPIE.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.NFPJIFHLFNB(IODGHHFAHJH);
						GuiElementSingle<TutorialClickOverlay>.instance.AJNGLEIBMHD(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(254f);
				goto IL_052e;
			case 9u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("_grenadelauncher");
				object[] array = new object[0];
				array[1] = Localization.Localize("Overtime_Was_Already_Explained");
				instance.DOLDLDECPIO(aMKLKMJEMJM, Localization.LocalizeFormat("N", array), 844f, TutorialDialog.DODBDLEJOAM.Bottom);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.BGPBNIJPOKM.cachedTransform.position, new Vector3(1635f, 1741f, 866f), ELHGOHGPJCF: true, ENIHCPLOOAE: false, 712f);
				GuiElementSingle<TutorialClickOverlay>.instance.LPKOHAKMOOC(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
				goto case 10u;
			}
			case 10u:
				if (GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().PPMNNKANOEF().upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 14;
					}
					break;
				}
				BJGCPDNMHDH.mUnitBoughtState = 2;
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("2DBigSprites/menu-membership-agent-big");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(297f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1812f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -23;
				}
				break;
			case 11u:
				if (!GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().BNPKCKFMBLG().upgradeSlots.bought)
				{
					FPHGINDBIDI = false;
					TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
					string aMKLKMJEMJM2 = Localization.Localize("Progress");
					object[] array2 = new object[0];
					array2[0] = Localization.Localize("LeagueEvaluation");
					instance2.DOLDLDECPIO(aMKLKMJEMJM2, Localization.LocalizeFormat("discount", array2), 134f, TutorialDialog.DODBDLEJOAM.TopRight);
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.LNFLDPLGEJE.transform.position, new Vector3(897f, 1119f, 1295f), ELHGOHGPJCF: false, ENIHCPLOOAE: false, 871f);
					GuiElementSingle<TutorialClickOverlay>.instance.GBHNBKFGCPG(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL);
					JGPPKCAGAGC = false;
					goto case 13u;
				}
				goto case 14u;
			case 12u:
				GuiElementSingle<TutorialDialog>.instance.DOLDLDECPIO(Localization.Localize("\n"), Localization.LocalizeFormat("ID_WITHACHANCEOFORWARCARDS", Localization.Localize("withPublisherSubKeyword")), 619f);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.JPJLKKJJFDB.transform.position, new Vector3(1210f, 1061f, 1739f), ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1412f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL);
				goto IL_088a;
			case 13u:
				if (!GuiScreenSingle<ArmyScreen>.instance.selectedIcon.levelBehaviour.upgradeSlots.bought)
				{
					if (JGPPKCAGAGC && GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().BNPKCKFMBLG().upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Delivered)
					{
						FPHGINDBIDI = false;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
						GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(885f);
						JGPPKCAGAGC = true;
						Singleton<GuiManager>.instance.TurnOffInputCompletly();
						PHDOCKCBJOF = new WaitForSeconds(994f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = -105;
						}
						break;
					}
					goto IL_088a;
				}
				BJGCPDNMHDH.mUnitBoughtState = 2;
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("ID_INSTANTBATTLEHINT4", FPHGINDBIDI);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(1181f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1981f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 121;
				}
				break;
			case 14u:
				BJGCPDNMHDH.mUnitBoughtState = 7;
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ.transform.position, new Vector3(525f, 138f, 624f), ELHGOHGPJCF: true, ENIHCPLOOAE: false, 506f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ);
				GuiElementSingle<TutorialClickOverlay>.instance.EDPNLNIPCGJ();
				PHDOCKCBJOF = new WaitForSeconds(737f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 15;
				}
				break;
			case 15u:
			case 16u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 25;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Shots_Fired");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(1102f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 17u;
			case 17u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.AFOFDNJOJHG())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -53;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.DOLDLDECPIO(Localization.Localize("fr"), Localization.Localize("ID_ARENARULES_LESSCRATES"), 670f, TutorialDialog.DODBDLEJOAM.TopRight, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.OMDKNOFNFBB.transform.position, ELHGOHGPJCF: false, ENIHCPLOOAE: false, 114f);
				GuiElementSingle<TutorialClickOverlay>.instance.CLPPGONHLHI(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.ECJHCGPGGDC, GPCEHFNNCIN: false);
				goto case 18u;
			case 18u:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -110;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Player name:{0} Player id:{1}\n");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(581f);
				BJGCPDNMHDH.mUnitBoughtState = 1;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_088a:
				PHDOCKCBJOF = true;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -51;
				}
				break;
				IL_052e:
				Singleton<EventTrackingManager>.instance.KEKPOIPDIGK("armyPower", FKGHFOJFMBP);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1800f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -91;
				}
				break;
			}
			return true;
		}

		public void HKHANLKODIB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool PMJICFJGOBE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mUnitBoughtState = 1;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						LevelBehaviour current = KFCAECGLKKO.Current;
						if (current.upgradeSlots.isTutorialUnit)
						{
							current.upgradeSlots.bought = false;
							BJGCPDNMHDH.mTutorialUnit = current;
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (BJGCPDNMHDH.mTutorialUnit == null)
				{
					UnityEngine.Debug.LogError("ID_WARNING_CANNOTCREATESQUAD");
				}
				goto case 1u;
			case 1u:
				if (!GuiElementSingle<LevelUpDialog>.instance.BKIGLABDGCP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (!GuiElementSingle<LevelUpDialog>.instance.CHGDDHJJMME())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				GuiElementSingle<LevelUpDialog>.instance.BHCCGGIBJDO();
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("damage");
				PHDOCKCBJOF = new WaitForSeconds(1179f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 3u:
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_ROCKETLAUNCHERTUTORIALTEXT"), Localization.Localize("silver2"), 286f);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[1].NALOPNJHPLI.transform.position, ELHGOHGPJCF: false, ENIHCPLOOAE: false, 1018f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].PAKNGGNNNDO.transform.position, GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].EPHBGCBAPAN.size, GPCEHFNNCIN: false);
				goto case 4u;
			case 4u:
				if (GuiElementSingle<LevelUpDialog>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(784f);
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<ArmyScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("405 MENU WEAPON SCREEN BUY UPGRADE");
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 6u;
			case 6u:
				if (!GuiScreenSingle<ArmyScreen>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				FKGHFOJFMBP = false;
				if (GuiScreenSingle<ArmyScreen>.instance.BDBKFBEIHNF().PPMNNKANOEF() != BJGCPDNMHDH.mTutorialUnit)
				{
					FKGHFOJFMBP = true;
					Singleton<GuiManager>.instance.TurnOffInputCompletly();
					PHDOCKCBJOF = new WaitForSeconds(247f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				goto IL_052e;
			case 7u:
				GuiElementSingle<TutorialDialog>.instance.GPIFEPGEHLF("menu-helmets-reaper", 1168f, TutorialDialog.DODBDLEJOAM.BottomLeft);
				OIBJCLOPOLG = GuiScreenSingle<ArmyScreen>.instance.OOLKNBJNFJC();
				GOBCHPOLPIE = null;
				IODGHHFAHJH = Vector3.zero;
				CMIKGAOHHPH = Vector3.one;
				if (OIBJCLOPOLG != null)
				{
					foreach (ArmyUpgradeIcon item in OIBJCLOPOLG)
					{
						if (item.BNPKCKFMBLG() == BJGCPDNMHDH.mTutorialUnit)
						{
							GOBCHPOLPIE = item;
							IODGHHFAHJH = item.transform.position;
							CMIKGAOHHPH = item.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(IODGHHFAHJH, ELHGOHGPJCF: false, ENIHCPLOOAE: false, 1966f);
							GuiElementSingle<TutorialClickOverlay>.instance.NNPKOKCJMHL(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
							break;
						}
					}
				}
				goto case 8u;
			case 8u:
				if (GuiScreenSingle<ArmyScreen>.instance.selectedIcon.BNPKCKFMBLG() != BJGCPDNMHDH.mTutorialUnit)
				{
					if (GOBCHPOLPIE != null && GOBCHPOLPIE.transform.position != IODGHHFAHJH)
					{
						IODGHHFAHJH = GOBCHPOLPIE.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.IMOAGBADPCC(IODGHHFAHJH, ELHGOHGPJCF: false);
						GuiElementSingle<TutorialClickOverlay>.instance.IGNJKOKGNOI(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(1403f);
				goto IL_052e;
			case 9u:
				GuiElementSingle<TutorialDialog>.instance.BLHPAFCOPMD(Localization.Localize("0"), Localization.LocalizeFormat("menu-button-small", Localization.Localize("S")), 799f, TutorialDialog.DODBDLEJOAM.TopLeft);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.BGPBNIJPOKM.cachedTransform.position, new Vector3(753f, 1588f, 1988f), ELHGOHGPJCF: true, ENIHCPLOOAE: false, 156f);
				GuiElementSingle<TutorialClickOverlay>.instance.GBHNBKFGCPG(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
				goto case 10u;
			case 10u:
				if (GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().PPMNNKANOEF().upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 33;
					}
					break;
				}
				BJGCPDNMHDH.mUnitBoughtState = 7;
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Cards on saved data: ");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(712f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(839f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -96;
				}
				break;
			case 11u:
				if (!GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().BNPKCKFMBLG().upgradeSlots.bought)
				{
					FPHGINDBIDI = false;
					GuiElementSingle<TutorialDialog>.instance.DOLDLDECPIO(Localization.Localize("GameGold"), Localization.LocalizeFormat("《WarFriends》需要權限存取你的媒體存儲才能下載關鍵的遊戲資料。缺少此權限，遊戲就無法運作並會關閉。請重試或退出《WarFriends》。", Localization.Localize("ID_CONFIRM_OFFERTOOSHORTNAME")), 23f, TutorialDialog.DODBDLEJOAM.BottomLeft, NHEJDPIIOJG: false);
					GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.LNFLDPLGEJE.transform.position, new Vector3(1104f, 741f, 1195f), ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1230f);
					GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL);
					JGPPKCAGAGC = false;
					goto case 13u;
				}
				goto case 14u;
			case 12u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("ID_GUI_BUDDY");
				object[] array = new object[1];
				array[1] = Localization.Localize("PauseGameRPC");
				instance.PBEAOCBHFGD(aMKLKMJEMJM, Localization.LocalizeFormat("Wrong_Category", array), 1010f, TutorialDialog.DODBDLEJOAM.Right);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.JPJLKKJJFDB.transform.position, new Vector3(380f, 1996f, 1675f), ELHGOHGPJCF: true, ENIHCPLOOAE: true, 1639f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
				goto IL_088a;
			}
			case 13u:
				if (!GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().levelBehaviour.upgradeSlots.bought)
				{
					if (JGPPKCAGAGC && GuiScreenSingle<ArmyScreen>.instance.selectedIcon.AIHMCHBCJDO().upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Active)
					{
						FPHGINDBIDI = false;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
						GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(542f);
						JGPPKCAGAGC = false;
						Singleton<GuiManager>.instance.CMCCOCBIGBB();
						PHDOCKCBJOF = new WaitForSeconds(644f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = -128;
						}
						break;
					}
					goto IL_088a;
				}
				BJGCPDNMHDH.mUnitBoughtState = 5;
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("ID_ARENARULES_NOCRATES", FPHGINDBIDI);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(1136f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1445f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 19;
				}
				break;
			case 14u:
				BJGCPDNMHDH.mUnitBoughtState = 7;
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ.transform.position, new Vector3(152f, 233f, 1704f), ELHGOHGPJCF: true, ENIHCPLOOAE: true, 405f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ);
				GuiElementSingle<TutorialClickOverlay>.instance.JMPLMMANKMP();
				PHDOCKCBJOF = new WaitForSeconds(1586f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 18;
				}
				break;
			case 15u:
			case 16u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -125;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Game Rewards lootboxes contents:\n");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(639f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 17u;
			case 17u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.BKIGLABDGCP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 103;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("#AccoutCheck# account exist"), Localization.Localize("ID_LEAGUETOPPOSITIONHINT"), 1577f, TutorialDialog.DODBDLEJOAM.BottomRight, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.OMDKNOFNFBB.transform.position, ELHGOHGPJCF: true, ENIHCPLOOAE: false, 59f);
				GuiElementSingle<TutorialClickOverlay>.instance.MLCGPAJJOMB(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.ECJHCGPGGDC);
				goto case 18u;
			case 18u:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 50;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("added");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(1819f);
				BJGCPDNMHDH.mUnitBoughtState = 1;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_088a:
				PHDOCKCBJOF = true;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -120;
				}
				break;
				IL_052e:
				Singleton<EventTrackingManager>.instance.RegisterTutorialUnitSelectedEvent("Gold", FKGHFOJFMBP);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1875f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -106;
				}
				break;
			}
			return true;
		}

		[SpecialName]
		private object KPNBIPDNGOM()
		{
			return PHDOCKCBJOF;
		}

		public bool PJJPPMIBNLN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mUnitBoughtState = 1;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						LevelBehaviour current = KFCAECGLKKO.Current;
						if (current.upgradeSlots.isTutorialUnit)
						{
							current.upgradeSlots.bought = true;
							BJGCPDNMHDH.mTutorialUnit = current;
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (BJGCPDNMHDH.mTutorialUnit == null)
				{
					UnityEngine.Debug.LogError("AIRSTRIKE");
				}
				goto case 1u;
			case 1u:
				if (!GuiElementSingle<LevelUpDialog>.instance.BJNBLINDAED())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (!GuiElementSingle<LevelUpDialog>.instance.EEDNBIIPMAG())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				GuiElementSingle<LevelUpDialog>.instance.HCODOFNNLDL();
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("BattleRewards");
				PHDOCKCBJOF = new WaitForSeconds(1067f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 3u:
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("Player_promoted"), Localization.Localize("ID_TRAININGINPROGRESS"), 1113f, TutorialDialog.DODBDLEJOAM.Left);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[1].NALOPNJHPLI.transform.position, ELHGOHGPJCF: true, ENIHCPLOOAE: true, 1641f);
				GuiElementSingle<TutorialClickOverlay>.instance.EEMMKEMADFC(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].PAKNGGNNNDO.transform.position, GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[1].EPHBGCBAPAN.size);
				goto case 4u;
			case 4u:
				if (GuiElementSingle<LevelUpDialog>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(157f);
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<ArmyScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_STATE_SELECTINGWARCARDS");
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 6u;
			case 6u:
				if (!GuiScreenSingle<ArmyScreen>.instance.BJNBLINDAED())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				FKGHFOJFMBP = true;
				if (GuiScreenSingle<ArmyScreen>.instance.selectedIcon.KHEOKHHDGPO() != BJGCPDNMHDH.mTutorialUnit)
				{
					FKGHFOJFMBP = false;
					Singleton<GuiManager>.instance.CMCCOCBIGBB();
					PHDOCKCBJOF = new WaitForSeconds(1175f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				goto IL_052e;
			case 7u:
				GuiElementSingle<TutorialDialog>.instance.ShowSpecial("ID_RENTAL_ROCKETLAUNCHER", 522f, TutorialDialog.DODBDLEJOAM.BottomLeft);
				OIBJCLOPOLG = GuiScreenSingle<ArmyScreen>.instance.OOLKNBJNFJC();
				GOBCHPOLPIE = null;
				IODGHHFAHJH = Vector3.zero;
				CMIKGAOHHPH = Vector3.one;
				if (OIBJCLOPOLG != null)
				{
					foreach (ArmyUpgradeIcon item in OIBJCLOPOLG)
					{
						if (item.levelBehaviour == BJGCPDNMHDH.mTutorialUnit)
						{
							GOBCHPOLPIE = item;
							IODGHHFAHJH = item.transform.position;
							CMIKGAOHHPH = item.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(IODGHHFAHJH, ELHGOHGPJCF: false, ENIHCPLOOAE: true, 666f);
							GuiElementSingle<TutorialClickOverlay>.instance.AJNGLEIBMHD(IODGHHFAHJH, CMIKGAOHHPH);
							break;
						}
					}
				}
				goto case 8u;
			case 8u:
				if (GuiScreenSingle<ArmyScreen>.instance.BDBKFBEIHNF().AIHMCHBCJDO() != BJGCPDNMHDH.mTutorialUnit)
				{
					if (GOBCHPOLPIE != null && GOBCHPOLPIE.transform.position != IODGHHFAHJH)
					{
						IODGHHFAHJH = GOBCHPOLPIE.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateTapAnimation(IODGHHFAHJH);
						GuiElementSingle<TutorialClickOverlay>.instance.IGNJKOKGNOI(IODGHHFAHJH, CMIKGAOHHPH);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(325f);
				goto IL_052e;
			case 9u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("Flawless");
				object[] array = new object[1];
				array[1] = Localization.Localize(" BOXES ");
				instance.BLHPAFCOPMD(aMKLKMJEMJM, Localization.LocalizeFormat("resizing texture ", array), 1278f, TutorialDialog.DODBDLEJOAM.TopRight);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.BGPBNIJPOKM.cachedTransform.position, new Vector3(448f, 1443f, 1778f), ELHGOHGPJCF: false, ENIHCPLOOAE: true, 1957f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
				goto case 10u;
			}
			case 10u:
				if (GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().PPMNNKANOEF().upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Locked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 48;
					}
					break;
				}
				BJGCPDNMHDH.mUnitBoughtState = 4;
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("idle");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(1432f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1275f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -64;
				}
				break;
			case 11u:
				if (!GuiScreenSingle<ArmyScreen>.instance.selectedIcon.AIHMCHBCJDO().upgradeSlots.bought)
				{
					FPHGINDBIDI = true;
					TutorialDialog instance3 = GuiElementSingle<TutorialDialog>.instance;
					string aMKLKMJEMJM3 = Localization.Localize("WarbucksId");
					object[] array3 = new object[1];
					array3[1] = Localization.Localize(" {0}{1}");
					instance3.BLHPAFCOPMD(aMKLKMJEMJM3, Localization.LocalizeFormat("ID_WARNING_CONNECTIONERROR", array3), 1169f);
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.LNFLDPLGEJE.transform.position, new Vector3(199f, 1524f, 714f), ELHGOHGPJCF: false, ENIHCPLOOAE: false, 671f);
					GuiElementSingle<TutorialClickOverlay>.instance.GBHNBKFGCPG(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL);
					JGPPKCAGAGC = false;
					goto case 13u;
				}
				goto case 14u;
			case 12u:
			{
				TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM2 = Localization.Localize("ID_CONFIRM_OTHERSERVERRESPONDERROR");
				object[] array2 = new object[0];
				array2[1] = Localization.Localize("ID_FEATURE_RATE-WEAPONPREFIX");
				instance2.DOLDLDECPIO(aMKLKMJEMJM2, Localization.LocalizeFormat("Locale", array2), 558f, TutorialDialog.DODBDLEJOAM.TopRight, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.JPJLKKJJFDB.transform.position, new Vector3(236f, 563f, 988f), ELHGOHGPJCF: false, ENIHCPLOOAE: false, 1051f);
				GuiElementSingle<TutorialClickOverlay>.instance.GBHNBKFGCPG(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL);
				goto IL_088a;
			}
			case 13u:
				if (!GuiScreenSingle<ArmyScreen>.instance.BDBKFBEIHNF().KHEOKHHDGPO().upgradeSlots.bought)
				{
					if (JGPPKCAGAGC && GuiScreenSingle<ArmyScreen>.instance.BDBKFBEIHNF().KHEOKHHDGPO().upgradeSlots.unitState == (UpgradeSlots.JLANLLEABDC)8)
					{
						FPHGINDBIDI = false;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
						GuiElementSingle<TutorialClickOverlay>.instance.Hide(452f);
						JGPPKCAGAGC = false;
						Singleton<GuiManager>.instance.TurnOffInputCompletly();
						PHDOCKCBJOF = new WaitForSeconds(96f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = -34;
						}
						break;
					}
					goto IL_088a;
				}
				BJGCPDNMHDH.mUnitBoughtState = 4;
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("menu-event-reward-progress-red", FPHGINDBIDI);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(683f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1325f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 60;
				}
				break;
			case 14u:
				BJGCPDNMHDH.mUnitBoughtState = 7;
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ.transform.position, new Vector3(1215f, 1487f, 575f), ELHGOHGPJCF: true, ENIHCPLOOAE: true, 46f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ, GPCEHFNNCIN: false);
				GuiElementSingle<TutorialClickOverlay>.instance.StartBorderAnimation();
				PHDOCKCBJOF = new WaitForSeconds(747f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 126;
				}
				break;
			case 15u:
			case 16u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 80;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("{0} {1}{2} {3}");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(1707f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 17u;
			case 17u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.BKIGLABDGCP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 9;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("Xp"), Localization.Localize("game-card-ico-bg-silver"), 1320f, TutorialDialog.DODBDLEJOAM.Top, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.OMDKNOFNFBB.transform.position, ELHGOHGPJCF: true, ENIHCPLOOAE: false, 30f);
				GuiElementSingle<TutorialClickOverlay>.instance.CLPPGONHLHI(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.ECJHCGPGGDC);
				goto case 18u;
			case 18u:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 19;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("SquadId");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(495f);
				BJGCPDNMHDH.mUnitBoughtState = 4;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_088a:
				PHDOCKCBJOF = false;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -20;
				}
				break;
				IL_052e:
				Singleton<EventTrackingManager>.instance.RegisterTutorialUnitSelectedEvent("Spend_Gold_On_Power_Bands", FKGHFOJFMBP);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1248f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 89;
				}
				break;
			}
			return false;
		}

		[SpecialName]
		private object PKEABJICHAI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LGDOCMENCOG()
		{
			return PHDOCKCBJOF;
		}

		public void BGMDCMOCLBN()
		{
			throw new NotSupportedException();
		}

		public void ODACICLOMHJ()
		{
			throw new NotSupportedException();
		}

		public void EPKPNKGJHEC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object DGEECEBHPNC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JIIJMDIFMKF()
		{
			return PHDOCKCBJOF;
		}

		public bool HOJKAHEGFEB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mUnitBoughtState = 1;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						LevelBehaviour current = KFCAECGLKKO.Current;
						if (current.upgradeSlots.isTutorialUnit)
						{
							current.upgradeSlots.bought = true;
							BJGCPDNMHDH.mTutorialUnit = current;
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (BJGCPDNMHDH.mTutorialUnit == null)
				{
					UnityEngine.Debug.LogError("ID_COMPLETED");
				}
				goto case 1u;
			case 1u:
				if (!GuiElementSingle<LevelUpDialog>.instance.BKIGLABDGCP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (!GuiElementSingle<LevelUpDialog>.instance.EEDNBIIPMAG())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				GuiElementSingle<LevelUpDialog>.instance.EPJJFOOMHNL();
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("GoldBase");
				PHDOCKCBJOF = new WaitForSeconds(501f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 3u:
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("D2"), Localization.Localize(", action = "), 1356f, TutorialDialog.DODBDLEJOAM.TopLeft, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[1].NALOPNJHPLI.transform.position, ELHGOHGPJCF: false, ENIHCPLOOAE: true, 1901f);
				GuiElementSingle<TutorialClickOverlay>.instance.AJNGLEIBMHD(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].PAKNGGNNNDO.transform.position, GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].EPHBGCBAPAN.size, GPCEHFNNCIN: false);
				goto case 4u;
			case 4u:
				if (GuiElementSingle<LevelUpDialog>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(261f);
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<ArmyScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("game-label-you-red");
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 6u;
			case 6u:
				if (!GuiScreenSingle<ArmyScreen>.instance.MHAIBHBGBOO())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				FKGHFOJFMBP = true;
				if (GuiScreenSingle<ArmyScreen>.instance.BDBKFBEIHNF().levelBehaviour != BJGCPDNMHDH.mTutorialUnit)
				{
					FKGHFOJFMBP = true;
					Singleton<GuiManager>.instance.TurnOffInputCompletly();
					PHDOCKCBJOF = new WaitForSeconds(534f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				goto IL_052e;
			case 7u:
				GuiElementSingle<TutorialDialog>.instance.NIGINCPEHFP("max", 968f, TutorialDialog.DODBDLEJOAM.BottomRight);
				OIBJCLOPOLG = GuiScreenSingle<ArmyScreen>.instance.armyIcons;
				GOBCHPOLPIE = null;
				IODGHHFAHJH = Vector3.zero;
				CMIKGAOHHPH = Vector3.one;
				if (OIBJCLOPOLG != null)
				{
					foreach (ArmyUpgradeIcon item in OIBJCLOPOLG)
					{
						if (item.levelBehaviour == BJGCPDNMHDH.mTutorialUnit)
						{
							GOBCHPOLPIE = item;
							IODGHHFAHJH = item.transform.position;
							CMIKGAOHHPH = item.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(IODGHHFAHJH, ELHGOHGPJCF: false, ENIHCPLOOAE: false, 1195f);
							GuiElementSingle<TutorialClickOverlay>.instance.EEMMKEMADFC(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
							break;
						}
					}
				}
				goto case 8u;
			case 8u:
				if (GuiScreenSingle<ArmyScreen>.instance.BDBKFBEIHNF().PPMNNKANOEF() != BJGCPDNMHDH.mTutorialUnit)
				{
					if (GOBCHPOLPIE != null && GOBCHPOLPIE.transform.position != IODGHHFAHJH)
					{
						IODGHHFAHJH = GOBCHPOLPIE.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateTapAnimation(IODGHHFAHJH, ELHGOHGPJCF: false);
						GuiElementSingle<TutorialClickOverlay>.instance.AJNGLEIBMHD(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(1547f);
				goto IL_052e;
			case 9u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("menu-sidetab-bg-box");
				object[] array = new object[0];
				array[0] = Localization.Localize("myLobby");
				instance.BLHPAFCOPMD(aMKLKMJEMJM, Localization.LocalizeFormat("ID_TUTORIAL_FINISHHIM", array), 1295f, TutorialDialog.DODBDLEJOAM.TopLeft);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.BGPBNIJPOKM.cachedTransform.position, new Vector3(489f, 1244f, 1537f), ELHGOHGPJCF: true, ENIHCPLOOAE: true, 571f);
				GuiElementSingle<TutorialClickOverlay>.instance.GBHNBKFGCPG(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL);
				goto case 10u;
			}
			case 10u:
				if (GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().BNPKCKFMBLG().upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -128;
					}
					break;
				}
				BJGCPDNMHDH.mUnitBoughtState = 2;
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("CardCraft_Collect");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(906f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1032f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -32;
				}
				break;
			case 11u:
				if (!GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().levelBehaviour.upgradeSlots.bought)
				{
					FPHGINDBIDI = true;
					TutorialDialog instance3 = GuiElementSingle<TutorialDialog>.instance;
					string aMKLKMJEMJM3 = Localization.Localize("Can not find asset {0}");
					object[] array3 = new object[0];
					array3[0] = Localization.Localize("GooglePlayId");
					instance3.ShowMenuTutorial(aMKLKMJEMJM3, Localization.LocalizeFormat("TENTAR NOVAMENTE", array3), 1173f, TutorialDialog.DODBDLEJOAM.Left, NHEJDPIIOJG: false);
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.LNFLDPLGEJE.transform.position, new Vector3(992f, 210f, 1017f), ELHGOHGPJCF: false, ENIHCPLOOAE: false, 47f);
					GuiElementSingle<TutorialClickOverlay>.instance.LPKOHAKMOOC(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
					JGPPKCAGAGC = false;
					goto case 13u;
				}
				goto case 14u;
			case 12u:
			{
				TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM2 = Localization.Localize("SetShieldPositionRPC");
				object[] array2 = new object[1];
				array2[1] = Localization.Localize("FinishChoosingCardsRPC");
				instance2.BLHPAFCOPMD(aMKLKMJEMJM2, Localization.LocalizeFormat("(Lcom/google/android/gms/common/api/GoogleApiClient$OnConnectionFailedListener;)V", array2), 1469f, TutorialDialog.DODBDLEJOAM.Left, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.JPJLKKJJFDB.transform.position, new Vector3(1393f, 1105f, 1423f), ELHGOHGPJCF: true, ENIHCPLOOAE: true, 530f);
				GuiElementSingle<TutorialClickOverlay>.instance.LPKOHAKMOOC(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL);
				goto IL_088a;
			}
			case 13u:
				if (!GuiScreenSingle<ArmyScreen>.instance.selectedIcon.KHEOKHHDGPO().upgradeSlots.bought)
				{
					if (JGPPKCAGAGC && GuiScreenSingle<ArmyScreen>.instance.selectedIcon.levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.UnitDelivering)
					{
						FPHGINDBIDI = true;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
						GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(155f);
						JGPPKCAGAGC = true;
						Singleton<GuiManager>.instance.TurnOffInputCompletly();
						PHDOCKCBJOF = new WaitForSeconds(1062f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 97;
						}
						break;
					}
					goto IL_088a;
				}
				BJGCPDNMHDH.mUnitBoughtState = 5;
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("checkForDeferredDeeplink", FPHGINDBIDI);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(1259f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1382f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -111;
				}
				break;
			case 14u:
				BJGCPDNMHDH.mUnitBoughtState = 3;
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ.transform.position, new Vector3(807f, 1808f, 1928f), ELHGOHGPJCF: false, ENIHCPLOOAE: false, 817f);
				GuiElementSingle<TutorialClickOverlay>.instance.LPKOHAKMOOC(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ);
				GuiElementSingle<TutorialClickOverlay>.instance.JMPLMMANKMP();
				PHDOCKCBJOF = new WaitForSeconds(306f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 106;
				}
				break;
			case 15u:
			case 16u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 93;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Deploys_Count");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(877f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 17u;
			case 17u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.MHAIBHBGBOO())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -29;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.BLHPAFCOPMD(Localization.Localize("Message Id = "), Localization.Localize("NO"), 1317f, TutorialDialog.DODBDLEJOAM.Bottom, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.OMDKNOFNFBB.transform.position, ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1758f);
				GuiElementSingle<TutorialClickOverlay>.instance.MLCGPAJJOMB(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.ECJHCGPGGDC, GPCEHFNNCIN: false);
				goto case 18u;
			case 18u:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -34;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("SpecialOffers");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(1887f);
				BJGCPDNMHDH.mUnitBoughtState = 1;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_088a:
				PHDOCKCBJOF = true;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 54;
				}
				break;
				IL_052e:
				Singleton<EventTrackingManager>.instance.KEKPOIPDIGK("SCOPE_GAMES", FKGHFOJFMBP);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(232f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 50;
				}
				break;
			}
			return true;
		}

		public void BLOCBAKBHBF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool FBMLBIOKKBE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mUnitBoughtState = 0;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						LevelBehaviour current = KFCAECGLKKO.Current;
						if (current.upgradeSlots.isTutorialUnit)
						{
							current.upgradeSlots.bought = true;
							BJGCPDNMHDH.mTutorialUnit = current;
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (BJGCPDNMHDH.mTutorialUnit == null)
				{
					UnityEngine.Debug.LogError("ID_NOTINLEAGUETEXT");
				}
				goto case 1u;
			case 1u:
				if (!GuiElementSingle<LevelUpDialog>.instance.LHDGJFHPJNM())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (!GuiElementSingle<LevelUpDialog>.instance.EEDNBIIPMAG())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				GuiElementSingle<LevelUpDialog>.instance.TutorialHideParts();
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_CONFIRM_SERVERERROR");
				PHDOCKCBJOF = new WaitForSeconds(887f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 3u:
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_SQUADEVENT"), Localization.Localize("ID_TUTORIAL_PLAY_CARD_DOWN"), 833f, TutorialDialog.DODBDLEJOAM.Top, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].NALOPNJHPLI.transform.position, ELHGOHGPJCF: false, ENIHCPLOOAE: true, 445f);
				GuiElementSingle<TutorialClickOverlay>.instance.EEMMKEMADFC(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[1].PAKNGGNNNDO.transform.position, GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].EPHBGCBAPAN.size, GPCEHFNNCIN: false);
				goto case 4u;
			case 4u:
				if (GuiElementSingle<LevelUpDialog>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(1309f);
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<ArmyScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Player_Avoided_Grenade_On_First_Try");
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 6u;
			case 6u:
				if (!GuiScreenSingle<ArmyScreen>.instance.BJNBLINDAED())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				FKGHFOJFMBP = false;
				if (GuiScreenSingle<ArmyScreen>.instance.selectedIcon.BNPKCKFMBLG() != BJGCPDNMHDH.mTutorialUnit)
				{
					FKGHFOJFMBP = false;
					Singleton<GuiManager>.instance.CMCCOCBIGBB();
					PHDOCKCBJOF = new WaitForSeconds(153f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				goto IL_052e;
			case 7u:
				GuiElementSingle<TutorialDialog>.instance.CLINGHOGNGM("Total_Sessions", 257f, TutorialDialog.DODBDLEJOAM.Left);
				OIBJCLOPOLG = GuiScreenSingle<ArmyScreen>.instance.armyIcons;
				GOBCHPOLPIE = null;
				IODGHHFAHJH = Vector3.zero;
				CMIKGAOHHPH = Vector3.one;
				if (OIBJCLOPOLG != null)
				{
					foreach (ArmyUpgradeIcon item in OIBJCLOPOLG)
					{
						if (item.BNPKCKFMBLG() == BJGCPDNMHDH.mTutorialUnit)
						{
							GOBCHPOLPIE = item;
							IODGHHFAHJH = item.transform.position;
							CMIKGAOHHPH = item.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(IODGHHFAHJH, ELHGOHGPJCF: false, ENIHCPLOOAE: false, 1787f);
							GuiElementSingle<TutorialClickOverlay>.instance.EEMMKEMADFC(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
							break;
						}
					}
				}
				goto case 8u;
			case 8u:
				if (GuiScreenSingle<ArmyScreen>.instance.selectedIcon.BNPKCKFMBLG() != BJGCPDNMHDH.mTutorialUnit)
				{
					if (GOBCHPOLPIE != null && GOBCHPOLPIE.transform.position != IODGHHFAHJH)
					{
						IODGHHFAHJH = GOBCHPOLPIE.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.IMOAGBADPCC(IODGHHFAHJH);
						GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(481f);
				goto IL_052e;
			case 9u:
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("Bad player regiones, data= "), Localization.LocalizeFormat("com/google/android/gms/games/Games", Localization.Localize("1")), 1878f, TutorialDialog.DODBDLEJOAM.Right, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.BGPBNIJPOKM.cachedTransform.position, new Vector3(1620f, 853f, 1630f), ELHGOHGPJCF: false, ENIHCPLOOAE: true, 556f);
				GuiElementSingle<TutorialClickOverlay>.instance.GBHNBKFGCPG(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
				goto case 10u;
			case 10u:
				if (GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -35;
					}
					break;
				}
				BJGCPDNMHDH.mUnitBoughtState = 4;
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_OVERTIME");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(1336f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1949f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -38;
				}
				break;
			case 11u:
				if (!GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().PPMNNKANOEF().upgradeSlots.bought)
				{
					FPHGINDBIDI = false;
					TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
					string aMKLKMJEMJM2 = Localization.Localize("HitListItem");
					object[] array2 = new object[0];
					array2[0] = Localization.Localize("ID_CONFIRM_ERROR");
					instance2.ShowMenuTutorial(aMKLKMJEMJM2, Localization.LocalizeFormat("LootboxType", array2), 943f, TutorialDialog.DODBDLEJOAM.BottomRight, NHEJDPIIOJG: false);
					GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.LNFLDPLGEJE.transform.position, new Vector3(1296f, 1733f, 455f), ELHGOHGPJCF: true, ENIHCPLOOAE: true, 1806f);
					GuiElementSingle<TutorialClickOverlay>.instance.LECHCOBHAFP(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
					JGPPKCAGAGC = true;
					goto case 13u;
				}
				goto case 14u;
			case 12u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("FacebookManagerOnSessionOpenedEvent");
				object[] array = new object[1];
				array[1] = Localization.Localize("ID_CONFIRM_FRIENDINSQUAD_TEXT");
				instance.PBEAOCBHFGD(aMKLKMJEMJM, Localization.LocalizeFormat("BattleId", array), 914f, TutorialDialog.DODBDLEJOAM.BottomLeft, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.JPJLKKJJFDB.transform.position, new Vector3(398f, 540f, 1668f), ELHGOHGPJCF: false, ENIHCPLOOAE: false, 854f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
				goto IL_088a;
			}
			case 13u:
				if (!GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().BNPKCKFMBLG().upgradeSlots.bought)
				{
					if (JGPPKCAGAGC && GuiScreenSingle<ArmyScreen>.instance.BDBKFBEIHNF().BNPKCKFMBLG().upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Delivered)
					{
						FPHGINDBIDI = false;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
						GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(570f);
						JGPPKCAGAGC = true;
						Singleton<GuiManager>.instance.TurnOffInputCompletly();
						PHDOCKCBJOF = new WaitForSeconds(1487f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = -5;
						}
						break;
					}
					goto IL_088a;
				}
				BJGCPDNMHDH.mUnitBoughtState = 4;
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("{0} {1}", FPHGINDBIDI);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(572f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1059f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -45;
				}
				break;
			case 14u:
				BJGCPDNMHDH.mUnitBoughtState = 1;
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ.transform.position, new Vector3(1591f, 538f, 1501f), ELHGOHGPJCF: false, ENIHCPLOOAE: false, 1365f);
				GuiElementSingle<TutorialClickOverlay>.instance.GBHNBKFGCPG(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ, GPCEHFNNCIN: false);
				GuiElementSingle<TutorialClickOverlay>.instance.EOBHJEGACCF();
				PHDOCKCBJOF = new WaitForSeconds(566f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -44;
				}
				break;
			case 15u:
			case 16u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -108;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(" ");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(83f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 17u;
			case 17u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.AFOFDNJOJHG())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -67;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.DOLDLDECPIO(Localization.Localize("registerEvent"), Localization.Localize("ID_USEREXISTSFACEBOOKTEXT"), 773f, TutorialDialog.DODBDLEJOAM.BottomRight);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.OMDKNOFNFBB.transform.position, ELHGOHGPJCF: false, ENIHCPLOOAE: true, 1883f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.ECJHCGPGGDC, GPCEHFNNCIN: false);
				goto case 18u;
			case 18u:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -41;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("PlayerLevel");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(670f);
				BJGCPDNMHDH.mUnitBoughtState = 6;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_088a:
				PHDOCKCBJOF = false;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -4;
				}
				break;
				IL_052e:
				Singleton<EventTrackingManager>.instance.RegisterTutorialUnitSelectedEvent("N", FKGHFOJFMBP);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(272f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 49;
				}
				break;
			}
			return false;
		}

		public void NINFHADPHJI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool BOENAMNMOAC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mUnitBoughtState = 1;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						LevelBehaviour current = KFCAECGLKKO.Current;
						if (current.upgradeSlots.isTutorialUnit)
						{
							current.upgradeSlots.bought = true;
							BJGCPDNMHDH.mTutorialUnit = current;
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (BJGCPDNMHDH.mTutorialUnit == null)
				{
					UnityEngine.Debug.LogError("NewVisuals");
				}
				goto case 1u;
			case 1u:
				if (!GuiElementSingle<LevelUpDialog>.instance.AFOFDNJOJHG())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (!GuiElementSingle<LevelUpDialog>.instance.OJAAFBFJMCF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				GuiElementSingle<LevelUpDialog>.instance.EPJJFOOMHNL();
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("order");
				PHDOCKCBJOF = new WaitForSeconds(1448f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 3u:
				GuiElementSingle<TutorialDialog>.instance.DOLDLDECPIO(Localization.Localize("ID_ARENAISOPEN"), Localization.Localize("getPackageManager"), 937f, TutorialDialog.DODBDLEJOAM.Right);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].NALOPNJHPLI.transform.position, ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1111f);
				GuiElementSingle<TutorialClickOverlay>.instance.AJNGLEIBMHD(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[1].PAKNGGNNNDO.transform.position, GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].EPHBGCBAPAN.size, GPCEHFNNCIN: false);
				goto case 4u;
			case 4u:
				if (GuiElementSingle<LevelUpDialog>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(1437f);
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<ArmyScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_CONFIRM_OPPONENTCANCELLED");
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 6u;
			case 6u:
				if (!GuiScreenSingle<ArmyScreen>.instance.BKIGLABDGCP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				FKGHFOJFMBP = false;
				if (GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().levelBehaviour != BJGCPDNMHDH.mTutorialUnit)
				{
					FKGHFOJFMBP = false;
					Singleton<GuiManager>.instance.TurnOffInputCompletly();
					PHDOCKCBJOF = new WaitForSeconds(379f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				goto IL_052e;
			case 7u:
				GuiElementSingle<TutorialDialog>.instance.CLINGHOGNGM("grenadeExplosion", 648f, TutorialDialog.DODBDLEJOAM.Right);
				OIBJCLOPOLG = GuiScreenSingle<ArmyScreen>.instance.MAPKDMOOFMM();
				GOBCHPOLPIE = null;
				IODGHHFAHJH = Vector3.zero;
				CMIKGAOHHPH = Vector3.one;
				if (OIBJCLOPOLG != null)
				{
					foreach (ArmyUpgradeIcon item in OIBJCLOPOLG)
					{
						if (item.PPMNNKANOEF() == BJGCPDNMHDH.mTutorialUnit)
						{
							GOBCHPOLPIE = item;
							IODGHHFAHJH = item.transform.position;
							CMIKGAOHHPH = item.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(IODGHHFAHJH, ELHGOHGPJCF: true, ENIHCPLOOAE: true, 2f);
							GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
							break;
						}
					}
				}
				goto case 8u;
			case 8u:
				if (GuiScreenSingle<ArmyScreen>.instance.BDBKFBEIHNF().KHEOKHHDGPO() != BJGCPDNMHDH.mTutorialUnit)
				{
					if (GOBCHPOLPIE != null && GOBCHPOLPIE.transform.position != IODGHHFAHJH)
					{
						IODGHHFAHJH = GOBCHPOLPIE.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.OBNDALJCPHG(IODGHHFAHJH, ELHGOHGPJCF: false);
						GuiElementSingle<TutorialClickOverlay>.instance.EEMMKEMADFC(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(1180f);
				goto IL_052e;
			case 9u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("{0} {1}{2}");
				object[] array = new object[0];
				array[0] = Localization.Localize("{0} / [FECA21]{1}");
				instance.ShowMenuTutorial(aMKLKMJEMJM, Localization.LocalizeFormat("N", array), 581f, TutorialDialog.DODBDLEJOAM.BottomRight);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.BGPBNIJPOKM.cachedTransform.position, new Vector3(1303f, 352f, 525f), ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1658f);
				GuiElementSingle<TutorialClickOverlay>.instance.LECHCOBHAFP(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL);
				goto case 10u;
			}
			case 10u:
				if (GuiScreenSingle<ArmyScreen>.instance.selectedIcon.levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -50;
					}
					break;
				}
				BJGCPDNMHDH.mUnitBoughtState = 5;
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_SKILLSHOTHINT_ONTHEMOVE");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(371f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(953f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 104;
				}
				break;
			case 11u:
				if (!GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().KHEOKHHDGPO().upgradeSlots.bought)
				{
					FPHGINDBIDI = true;
					GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("LevelName"), Localization.LocalizeFormat("localSquadLeaderboard", Localization.Localize("Awaiting players - Player id:\"{0}\" is not in list of awaiting members")), 742f, TutorialDialog.DODBDLEJOAM.Left, NHEJDPIIOJG: false);
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.LNFLDPLGEJE.transform.position, new Vector3(450f, 1030f, 1085f), ELHGOHGPJCF: true, ENIHCPLOOAE: true, 1007f);
					GuiElementSingle<TutorialClickOverlay>.instance.GBHNBKFGCPG(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
					JGPPKCAGAGC = false;
					goto case 13u;
				}
				goto case 14u;
			case 12u:
			{
				TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM2 = Localization.Localize("squadName");
				object[] array2 = new object[1];
				array2[1] = Localization.Localize("seconds");
				instance2.PBEAOCBHFGD(aMKLKMJEMJM2, Localization.LocalizeFormat("{0} {1}", array2), 1190f, TutorialDialog.DODBDLEJOAM.Bottom);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.JPJLKKJJFDB.transform.position, new Vector3(755f, 1334f, 41f), ELHGOHGPJCF: true, ENIHCPLOOAE: true, 1626f);
				GuiElementSingle<TutorialClickOverlay>.instance.PGOLMCBEIOD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
				goto IL_088a;
			}
			case 13u:
				if (!GuiScreenSingle<ArmyScreen>.instance.BDBKFBEIHNF().KHEOKHHDGPO().upgradeSlots.bought)
				{
					if (JGPPKCAGAGC && GuiScreenSingle<ArmyScreen>.instance.selectedIcon.BNPKCKFMBLG().upgradeSlots.unitState == (UpgradeSlots.JLANLLEABDC)7)
					{
						FPHGINDBIDI = true;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.Hide();
						GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(129f);
						JGPPKCAGAGC = true;
						Singleton<GuiManager>.instance.CMCCOCBIGBB();
						PHDOCKCBJOF = new WaitForSeconds(857f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = -21;
						}
						break;
					}
					goto IL_088a;
				}
				BJGCPDNMHDH.mUnitBoughtState = 6;
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("Card_3_Played", FPHGINDBIDI);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(421f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(395f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -42;
				}
				break;
			case 14u:
				BJGCPDNMHDH.mUnitBoughtState = 6;
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ.transform.position, new Vector3(815f, 351f, 96f), ELHGOHGPJCF: false, ENIHCPLOOAE: true, 1037f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ);
				GuiElementSingle<TutorialClickOverlay>.instance.KKCKBELEPHJ();
				PHDOCKCBJOF = new WaitForSeconds(1227f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -113;
				}
				break;
			case 15u:
			case 16u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -35;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("smallThumbnailLittle");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(1195f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 17u;
			case 17u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.LHDGJFHPJNM())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 95;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("VipRewardForDay"), Localization.Localize("DamageEvent"), 1759f, TutorialDialog.DODBDLEJOAM.Right);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.OMDKNOFNFBB.transform.position, ELHGOHGPJCF: true, ENIHCPLOOAE: true, 664f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.ECJHCGPGGDC, GPCEHFNNCIN: false);
				goto case 18u;
			case 18u:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -38;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Error - sheet {0} doesnt have column {1}");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(1559f);
				BJGCPDNMHDH.mUnitBoughtState = 0;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_088a:
				PHDOCKCBJOF = true;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 73;
				}
				break;
				IL_052e:
				Singleton<EventTrackingManager>.instance.KEKPOIPDIGK("ID_REPUTATIONSMALL", FKGHFOJFMBP);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1447f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -101;
				}
				break;
			}
			return true;
		}

		public void DOPCGPGKHIJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void AKLMKDOIDHP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mUnitBoughtState = 1;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						LevelBehaviour current = KFCAECGLKKO.Current;
						if (current.upgradeSlots.isTutorialUnit)
						{
							current.upgradeSlots.bought = false;
							BJGCPDNMHDH.mTutorialUnit = current;
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (BJGCPDNMHDH.mTutorialUnit == null)
				{
					UnityEngine.Debug.LogError("There is no unit selected as tutorial unit!!!!!!");
				}
				goto case 1u;
			case 1u:
				if (!GuiElementSingle<LevelUpDialog>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (!GuiElementSingle<LevelUpDialog>.instance.completeAnimation)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				GuiElementSingle<LevelUpDialog>.instance.TutorialHideParts();
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("212 MENU LEVEL UP SHOWN");
				PHDOCKCBJOF = new WaitForSeconds(0.1f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 3u:
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_TUTORIAL_GO_BUY_ARMY_2"), Localization.Localize("ID_TUTORIAL_GO_BUY_ARMY_2_DOWN"), -0.2f, TutorialDialog.DODBDLEJOAM.Right, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].NALOPNJHPLI.transform.position);
				GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].PAKNGGNNNDO.transform.position, GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].EPHBGCBAPAN.size, GPCEHFNNCIN: false);
				goto case 4u;
			case 4u:
				if (GuiElementSingle<LevelUpDialog>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(0.4f);
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<ArmyScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("213 MENU ARMY SCREEN SHOWN");
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 6u;
			case 6u:
				if (!GuiScreenSingle<ArmyScreen>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				FKGHFOJFMBP = false;
				if (GuiScreenSingle<ArmyScreen>.instance.selectedIcon.levelBehaviour != BJGCPDNMHDH.mTutorialUnit)
				{
					FKGHFOJFMBP = true;
					Singleton<GuiManager>.instance.TurnOffInputCompletly();
					PHDOCKCBJOF = new WaitForSeconds(0.5f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				goto IL_052e;
			case 7u:
				GuiElementSingle<TutorialDialog>.instance.ShowSpecial("ID_TUTORIAL_GO_BUY_ARMY_3", 0.25f);
				OIBJCLOPOLG = GuiScreenSingle<ArmyScreen>.instance.armyIcons;
				GOBCHPOLPIE = null;
				IODGHHFAHJH = Vector3.zero;
				CMIKGAOHHPH = Vector3.one;
				if (OIBJCLOPOLG != null)
				{
					foreach (ArmyUpgradeIcon item in OIBJCLOPOLG)
					{
						if (item.levelBehaviour == BJGCPDNMHDH.mTutorialUnit)
						{
							GOBCHPOLPIE = item;
							IODGHHFAHJH = item.transform.position;
							CMIKGAOHHPH = item.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(IODGHHFAHJH);
							GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(IODGHHFAHJH, CMIKGAOHHPH);
							break;
						}
					}
				}
				goto case 8u;
			case 8u:
				if (GuiScreenSingle<ArmyScreen>.instance.selectedIcon.levelBehaviour != BJGCPDNMHDH.mTutorialUnit)
				{
					if (GOBCHPOLPIE != null && GOBCHPOLPIE.transform.position != IODGHHFAHJH)
					{
						IODGHHFAHJH = GOBCHPOLPIE.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateTapAnimation(IODGHHFAHJH);
						GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(IODGHHFAHJH, CMIKGAOHHPH);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide();
				goto IL_052e;
			case 9u:
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_TUTORIAL_GO_BUY_ARMY_4"), Localization.LocalizeFormat("ID_TUTORIAL_TAPON", Localization.Localize("ID_BUY")), 0.6f, TutorialDialog.DODBDLEJOAM.BottomLeft, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.BGPBNIJPOKM.cachedTransform.position, new Vector3(40f, -56f, 0f));
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
				goto case 10u;
			case 10u:
				if (GuiScreenSingle<ArmyScreen>.instance.selectedIcon.levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 10;
					}
					break;
				}
				BJGCPDNMHDH.mUnitBoughtState = 2;
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("215 MENU ARMY SCREEN TUTORIAL UNIT BUY CLICKED");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide();
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1.1f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 11;
				}
				break;
			case 11u:
				if (!GuiScreenSingle<ArmyScreen>.instance.selectedIcon.levelBehaviour.upgradeSlots.bought)
				{
					FPHGINDBIDI = false;
					GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_TUTORIAL_DELIVER"), Localization.LocalizeFormat("ID_TUTORIAL_TAPON", Localization.Localize("ID_DELIVERNOW")), 0.6f, TutorialDialog.DODBDLEJOAM.BottomLeft, NHEJDPIIOJG: false);
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.LNFLDPLGEJE.transform.position, new Vector3(40f, -56f, 0f));
					GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
					JGPPKCAGAGC = true;
					goto case 13u;
				}
				goto case 14u;
			case 12u:
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_TUTORIAL_DELIVERED_UNIT"), Localization.LocalizeFormat("ID_TUTORIAL_TAPON", Localization.Localize("ID_ACTIVATION")), 0.6f, TutorialDialog.DODBDLEJOAM.BottomLeft, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.JPJLKKJJFDB.transform.position, new Vector3(40f, -56f, 0f));
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
				goto IL_088a;
			case 13u:
				if (!GuiScreenSingle<ArmyScreen>.instance.selectedIcon.levelBehaviour.upgradeSlots.bought)
				{
					if (JGPPKCAGAGC && GuiScreenSingle<ArmyScreen>.instance.selectedIcon.levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.UnitDelivered)
					{
						FPHGINDBIDI = true;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.Hide();
						GuiElementSingle<TutorialClickOverlay>.instance.Hide();
						JGPPKCAGAGC = false;
						Singleton<GuiManager>.instance.TurnOffInputCompletly();
						PHDOCKCBJOF = new WaitForSeconds(1.1f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 12;
						}
						break;
					}
					goto IL_088a;
				}
				BJGCPDNMHDH.mUnitBoughtState = 3;
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("216 MENU ARMY SCREEN TUTORIAL UNIT ACTIVATED", FPHGINDBIDI);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide();
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(0.5f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 14;
				}
				break;
			case 14u:
				BJGCPDNMHDH.mUnitBoughtState = 4;
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ.transform.position, new Vector3(0f, -25f, 0f));
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ);
				GuiElementSingle<TutorialClickOverlay>.instance.StartBorderAnimation();
				PHDOCKCBJOF = new WaitForSeconds(0.5f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 15;
				}
				break;
			case 15u:
			case 16u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 16;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("217 MENU BATTLE SCREEN SHOWN");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide();
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 17u;
			case 17u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 17;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_TUTORIAL_GO_BUY_ARMY_6"), Localization.Localize("ID_TUTORIAL_GO_BUY_ARMY_6_DOWN"), 0.1f, TutorialDialog.DODBDLEJOAM.Right, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.OMDKNOFNFBB.transform.position);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.ECJHCGPGGDC);
				goto case 18u;
			case 18u:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 18;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("220 NEXT TUTORIAL STARTING");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide();
				BJGCPDNMHDH.mUnitBoughtState = 5;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_088a:
				PHDOCKCBJOF = false;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 13;
				}
				break;
				IL_052e:
				Singleton<EventTrackingManager>.instance.RegisterTutorialUnitSelectedEvent("214 MENU ARMY SCREEN TUTORIAL UNIT", FKGHFOJFMBP);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(0.5f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 9;
				}
				break;
			}
			return true;
		}

		public bool MOFPMNMAOND()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mUnitBoughtState = 1;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						LevelBehaviour current = KFCAECGLKKO.Current;
						if (current.upgradeSlots.isTutorialUnit)
						{
							current.upgradeSlots.bought = false;
							BJGCPDNMHDH.mTutorialUnit = current;
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (BJGCPDNMHDH.mTutorialUnit == null)
				{
					UnityEngine.Debug.LogError("QUITTER");
				}
				goto case 1u;
			case 1u:
				if (!GuiElementSingle<LevelUpDialog>.instance.BKIGLABDGCP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (!GuiElementSingle<LevelUpDialog>.instance.LGHOENABFLJ())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				GuiElementSingle<LevelUpDialog>.instance.JIHGNOJJHEB();
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(" !=\"");
				PHDOCKCBJOF = new WaitForSeconds(1111f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 3u:
				GuiElementSingle<TutorialDialog>.instance.PBEAOCBHFGD(Localization.Localize("tempuser@tempcompany.com"), Localization.Localize("Pool"), 1449f, TutorialDialog.DODBDLEJOAM.TopRight);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].NALOPNJHPLI.transform.position, ELHGOHGPJCF: true, ENIHCPLOOAE: true, 920f);
				GuiElementSingle<TutorialClickOverlay>.instance.IGNJKOKGNOI(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].PAKNGGNNNDO.transform.position, GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[1].EPHBGCBAPAN.size);
				goto case 4u;
			case 4u:
				if (GuiElementSingle<LevelUpDialog>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(104f);
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<ArmyScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("special");
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 6u;
			case 6u:
				if (!GuiScreenSingle<ArmyScreen>.instance.AFOFDNJOJHG())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				FKGHFOJFMBP = true;
				if (GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().BNPKCKFMBLG() != BJGCPDNMHDH.mTutorialUnit)
				{
					FKGHFOJFMBP = true;
					Singleton<GuiManager>.instance.TurnOffInputCompletly();
					PHDOCKCBJOF = new WaitForSeconds(83f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				goto IL_052e;
			case 7u:
				GuiElementSingle<TutorialDialog>.instance.GPIFEPGEHLF("menu-hub-multiplayer-vipico", 97f, TutorialDialog.DODBDLEJOAM.Top);
				OIBJCLOPOLG = GuiScreenSingle<ArmyScreen>.instance.armyIcons;
				GOBCHPOLPIE = null;
				IODGHHFAHJH = Vector3.zero;
				CMIKGAOHHPH = Vector3.one;
				if (OIBJCLOPOLG != null)
				{
					foreach (ArmyUpgradeIcon item in OIBJCLOPOLG)
					{
						if (item.KHEOKHHDGPO() == BJGCPDNMHDH.mTutorialUnit)
						{
							GOBCHPOLPIE = item;
							IODGHHFAHJH = item.transform.position;
							CMIKGAOHHPH = item.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(IODGHHFAHJH, ELHGOHGPJCF: true, ENIHCPLOOAE: true, 1357f);
							GuiElementSingle<TutorialClickOverlay>.instance.AJNGLEIBMHD(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
							break;
						}
					}
				}
				goto case 8u;
			case 8u:
				if (GuiScreenSingle<ArmyScreen>.instance.selectedIcon.BNPKCKFMBLG() != BJGCPDNMHDH.mTutorialUnit)
				{
					if (GOBCHPOLPIE != null && GOBCHPOLPIE.transform.position != IODGHHFAHJH)
					{
						IODGHHFAHJH = GOBCHPOLPIE.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.IMOAGBADPCC(IODGHHFAHJH, ELHGOHGPJCF: false);
						GuiElementSingle<TutorialClickOverlay>.instance.EEMMKEMADFC(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(1076f);
				goto IL_052e;
			case 9u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("menu-wftv-youtube-ico");
				object[] array = new object[1];
				array[1] = Localization.Localize("roomName");
				instance.DOLDLDECPIO(aMKLKMJEMJM, Localization.LocalizeFormat("S", array), 791f, TutorialDialog.DODBDLEJOAM.Center, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.BGPBNIJPOKM.cachedTransform.position, new Vector3(37f, 1839f, 494f), ELHGOHGPJCF: false, ENIHCPLOOAE: true, 151f);
				GuiElementSingle<TutorialClickOverlay>.instance.LPKOHAKMOOC(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
				goto case 10u;
			}
			case 10u:
				if (GuiScreenSingle<ArmyScreen>.instance.selectedIcon.levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -98;
					}
					break;
				}
				BJGCPDNMHDH.mUnitBoughtState = 0;
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("N");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(1937f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(913f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -36;
				}
				break;
			case 11u:
				if (!GuiScreenSingle<ArmyScreen>.instance.BDBKFBEIHNF().BNPKCKFMBLG().upgradeSlots.bought)
				{
					FPHGINDBIDI = true;
					TutorialDialog instance3 = GuiElementSingle<TutorialDialog>.instance;
					string aMKLKMJEMJM3 = Localization.Localize("BattleLength");
					object[] array3 = new object[1];
					array3[1] = Localization.Localize("FacebookName");
					instance3.PBEAOCBHFGD(aMKLKMJEMJM3, Localization.LocalizeFormat(")", array3), 45f, TutorialDialog.DODBDLEJOAM.BottomLeft, NHEJDPIIOJG: false);
					GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.LNFLDPLGEJE.transform.position, new Vector3(662f, 881f, 264f), ELHGOHGPJCF: true, ENIHCPLOOAE: true, 594f);
					GuiElementSingle<TutorialClickOverlay>.instance.LPKOHAKMOOC(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL);
					JGPPKCAGAGC = false;
					goto case 13u;
				}
				goto case 14u;
			case 12u:
			{
				TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM2 = Localization.Localize("RemoveOld");
				object[] array2 = new object[0];
				array2[0] = Localization.Localize("{0} {1}/ {2}{3}");
				instance2.PBEAOCBHFGD(aMKLKMJEMJM2, Localization.LocalizeFormat("Time", array2), 1807f, TutorialDialog.DODBDLEJOAM.Bottom);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.JPJLKKJJFDB.transform.position, new Vector3(290f, 625f, 1082f), ELHGOHGPJCF: false, ENIHCPLOOAE: true, 441f);
				GuiElementSingle<TutorialClickOverlay>.instance.LPKOHAKMOOC(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL);
				goto IL_088a;
			}
			case 13u:
				if (!GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().BNPKCKFMBLG().upgradeSlots.bought)
				{
					if (JGPPKCAGAGC && GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().KHEOKHHDGPO().upgradeSlots.unitState == (UpgradeSlots.JLANLLEABDC)8)
					{
						FPHGINDBIDI = false;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
						GuiElementSingle<TutorialClickOverlay>.instance.Hide(280f);
						JGPPKCAGAGC = true;
						Singleton<GuiManager>.instance.TurnOffInputCompletly();
						PHDOCKCBJOF = new WaitForSeconds(458f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 2;
						}
						break;
					}
					goto IL_088a;
				}
				BJGCPDNMHDH.mUnitBoughtState = 1;
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("ID_TOJOINSQUADYOUNEEDTOHAVE", FPHGINDBIDI);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(1580f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(213f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 18;
				}
				break;
			case 14u:
				BJGCPDNMHDH.mUnitBoughtState = 4;
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ.transform.position, new Vector3(1133f, 1945f, 692f), ELHGOHGPJCF: false, ENIHCPLOOAE: true, 789f);
				GuiElementSingle<TutorialClickOverlay>.instance.LPKOHAKMOOC(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ, GPCEHFNNCIN: false);
				GuiElementSingle<TutorialClickOverlay>.instance.JMPLMMANKMP();
				PHDOCKCBJOF = new WaitForSeconds(1182f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 47;
				}
				break;
			case 15u:
			case 16u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 67;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Id");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(946f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 17u;
			case 17u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.AFOFDNJOJHG())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 113;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.BLHPAFCOPMD(Localization.Localize("GetFriendsList()"), Localization.Localize("Added reward message "), 792f, TutorialDialog.DODBDLEJOAM.Right);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.OMDKNOFNFBB.transform.position, ELHGOHGPJCF: false, ENIHCPLOOAE: false, 683f);
				GuiElementSingle<TutorialClickOverlay>.instance.JGHBBJEFLEB(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.ECJHCGPGGDC);
				goto case 18u;
			case 18u:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -67;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("DogTags");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(550f);
				BJGCPDNMHDH.mUnitBoughtState = 2;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_088a:
				PHDOCKCBJOF = false;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 39;
				}
				break;
				IL_052e:
				Singleton<EventTrackingManager>.instance.KEKPOIPDIGK("ID_SKILLSHOTHINT_ENVIROMENTALKILL", FKGHFOJFMBP);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1634f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -5;
				}
				break;
			}
			return false;
		}

		[SpecialName]
		private object HCPKEMLPEDI()
		{
			return PHDOCKCBJOF;
		}

		public bool NEPEDBPDMGL()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mUnitBoughtState = 0;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						LevelBehaviour current = KFCAECGLKKO.Current;
						if (current.upgradeSlots.isTutorialUnit)
						{
							current.upgradeSlots.bought = false;
							BJGCPDNMHDH.mTutorialUnit = current;
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (BJGCPDNMHDH.mTutorialUnit == null)
				{
					UnityEngine.Debug.LogError("Player_Waited_Till_Delivery_Ends");
				}
				goto case 1u;
			case 1u:
				if (!GuiElementSingle<LevelUpDialog>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (!GuiElementSingle<LevelUpDialog>.instance.OJAAFBFJMCF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				GuiElementSingle<LevelUpDialog>.instance.HCODOFNNLDL();
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("num");
				PHDOCKCBJOF = new WaitForSeconds(117f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 3u:
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("STAG"), Localization.Localize("ID_ATTACK"), 371f, TutorialDialog.DODBDLEJOAM.Bottom, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].NALOPNJHPLI.transform.position, ELHGOHGPJCF: false, ENIHCPLOOAE: true, 6f);
				GuiElementSingle<TutorialClickOverlay>.instance.EEMMKEMADFC(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[1].PAKNGGNNNDO.transform.position, GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[1].EPHBGCBAPAN.size);
				goto case 4u;
			case 4u:
				if (GuiElementSingle<LevelUpDialog>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(1650f);
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<ArmyScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("friend name");
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 6u;
			case 6u:
				if (!GuiScreenSingle<ArmyScreen>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				FKGHFOJFMBP = true;
				if (GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().PPMNNKANOEF() != BJGCPDNMHDH.mTutorialUnit)
				{
					FKGHFOJFMBP = false;
					Singleton<GuiManager>.instance.CMCCOCBIGBB();
					PHDOCKCBJOF = new WaitForSeconds(232f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				goto IL_052e;
			case 7u:
				GuiElementSingle<TutorialDialog>.instance.GPIFEPGEHLF("#VAVRO# mMainThreadDispatcher is null ", 665f, TutorialDialog.DODBDLEJOAM.TopLeft);
				OIBJCLOPOLG = GuiScreenSingle<ArmyScreen>.instance.OOLKNBJNFJC();
				GOBCHPOLPIE = null;
				IODGHHFAHJH = Vector3.zero;
				CMIKGAOHHPH = Vector3.one;
				if (OIBJCLOPOLG != null)
				{
					foreach (ArmyUpgradeIcon item in OIBJCLOPOLG)
					{
						if (item.PPMNNKANOEF() == BJGCPDNMHDH.mTutorialUnit)
						{
							GOBCHPOLPIE = item;
							IODGHHFAHJH = item.transform.position;
							CMIKGAOHHPH = item.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(IODGHHFAHJH, ELHGOHGPJCF: true, ENIHCPLOOAE: true, 1574f);
							GuiElementSingle<TutorialClickOverlay>.instance.AJNGLEIBMHD(IODGHHFAHJH, CMIKGAOHHPH);
							break;
						}
					}
				}
				goto case 8u;
			case 8u:
				if (GuiScreenSingle<ArmyScreen>.instance.BDBKFBEIHNF().BNPKCKFMBLG() != BJGCPDNMHDH.mTutorialUnit)
				{
					if (GOBCHPOLPIE != null && GOBCHPOLPIE.transform.position != IODGHHFAHJH)
					{
						IODGHHFAHJH = GOBCHPOLPIE.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.OBNDALJCPHG(IODGHHFAHJH, ELHGOHGPJCF: false);
						GuiElementSingle<TutorialClickOverlay>.instance.NNPKOKCJMHL(IODGHHFAHJH, CMIKGAOHHPH);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(1837f);
				goto IL_052e;
			case 9u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("ID_LOADING");
				object[] array = new object[0];
				array[1] = Localization.Localize("Chillingo: On Offers Closed ");
				instance.BLHPAFCOPMD(aMKLKMJEMJM, Localization.LocalizeFormat("ID_GUI_FOLLOWTWITTER_DESC", array), 1691f, TutorialDialog.DODBDLEJOAM.BottomRight, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.BGPBNIJPOKM.cachedTransform.position, new Vector3(1910f, 1610f, 461f), ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1638f);
				GuiElementSingle<TutorialClickOverlay>.instance.LECHCOBHAFP(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL);
				goto case 10u;
			}
			case 10u:
				if (GuiScreenSingle<ArmyScreen>.instance.BDBKFBEIHNF().BNPKCKFMBLG().upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Locked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 39;
					}
					break;
				}
				BJGCPDNMHDH.mUnitBoughtState = 8;
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("warArenaReminder");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(1783f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1000f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -121;
				}
				break;
			case 11u:
				if (!GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().levelBehaviour.upgradeSlots.bought)
				{
					FPHGINDBIDI = true;
					TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
					string aMKLKMJEMJM2 = Localization.Localize("WarCards");
					object[] array2 = new object[0];
					array2[0] = Localization.Localize("Warrior");
					instance2.ShowMenuTutorial(aMKLKMJEMJM2, Localization.LocalizeFormat(" | Hint ", array2), 536f, TutorialDialog.DODBDLEJOAM.BottomRight);
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.LNFLDPLGEJE.transform.position, new Vector3(1854f, 1128f, 40f), ELHGOHGPJCF: true, ENIHCPLOOAE: true, 392f);
					GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL);
					JGPPKCAGAGC = false;
					goto case 13u;
				}
				goto case 14u;
			case 12u:
				GuiElementSingle<TutorialDialog>.instance.BLHPAFCOPMD(Localization.Localize("rankDiff"), Localization.LocalizeFormat("0", Localization.Localize("WithdrawerId")), 1195f, TutorialDialog.DODBDLEJOAM.BottomRight);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.JPJLKKJJFDB.transform.position, new Vector3(1573f, 1960f, 925f), ELHGOHGPJCF: true, ENIHCPLOOAE: false, 94f);
				GuiElementSingle<TutorialClickOverlay>.instance.LPKOHAKMOOC(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL);
				goto IL_088a;
			case 13u:
				if (!GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().levelBehaviour.upgradeSlots.bought)
				{
					if (JGPPKCAGAGC && GuiScreenSingle<ArmyScreen>.instance.selectedIcon.BNPKCKFMBLG().upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Active)
					{
						FPHGINDBIDI = false;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
						GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(1667f);
						JGPPKCAGAGC = true;
						Singleton<GuiManager>.instance.CMCCOCBIGBB();
						PHDOCKCBJOF = new WaitForSeconds(281f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = -125;
						}
						break;
					}
					goto IL_088a;
				}
				BJGCPDNMHDH.mUnitBoughtState = 5;
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("GameCenterId", FPHGINDBIDI);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(654f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(794f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -119;
				}
				break;
			case 14u:
				BJGCPDNMHDH.mUnitBoughtState = 2;
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ.transform.position, new Vector3(1608f, 317f, 746f), ELHGOHGPJCF: true, ENIHCPLOOAE: true, 118f);
				GuiElementSingle<TutorialClickOverlay>.instance.LECHCOBHAFP(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ, GPCEHFNNCIN: false);
				GuiElementSingle<TutorialClickOverlay>.instance.EDPNLNIPCGJ();
				PHDOCKCBJOF = new WaitForSeconds(1165f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -91;
				}
				break;
			case 15u:
			case 16u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 56;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("menu-button-oneside");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(831f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 17u;
			case 17u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.LHDGJFHPJNM())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -26;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.DOLDLDECPIO(Localization.Localize("是"), Localization.Localize("PlayerUnits"), 725f, TutorialDialog.DODBDLEJOAM.TopRight, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.OMDKNOFNFBB.transform.position, ELHGOHGPJCF: false, ENIHCPLOOAE: false, 1385f);
				GuiElementSingle<TutorialClickOverlay>.instance.CAIGHMDPBDI(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.ECJHCGPGGDC, GPCEHFNNCIN: false);
				goto case 18u;
			case 18u:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 74;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("order");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(1813f);
				BJGCPDNMHDH.mUnitBoughtState = 2;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_088a:
				PHDOCKCBJOF = true;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -61;
				}
				break;
				IL_052e:
				Singleton<EventTrackingManager>.instance.KEKPOIPDIGK("WarFriends não poderá funcionar sem descarregar os dados adicionais. Realmente desejas SAIR ou gostarias de descarregar os dados?", FKGHFOJFMBP);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1357f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 18;
				}
				break;
			}
			return true;
		}

		[SpecialName]
		private object KBPOAPCEPBN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KMCGJFDPBCB()
		{
			return PHDOCKCBJOF;
		}

		public bool ACHIHMMCDNF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mUnitBoughtState = 1;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						LevelBehaviour current = KFCAECGLKKO.Current;
						if (current.upgradeSlots.isTutorialUnit)
						{
							current.upgradeSlots.bought = true;
							BJGCPDNMHDH.mTutorialUnit = current;
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (BJGCPDNMHDH.mTutorialUnit == null)
				{
					UnityEngine.Debug.LogError("lootboxesOfferAdd");
				}
				goto case 1u;
			case 1u:
				if (!GuiElementSingle<LevelUpDialog>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (!GuiElementSingle<LevelUpDialog>.instance.KOFGBOKHPFA())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				GuiElementSingle<LevelUpDialog>.instance.JIHGNOJJHEB();
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("menu-assignments-type-crate");
				PHDOCKCBJOF = new WaitForSeconds(1672f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 3u:
				GuiElementSingle<TutorialDialog>.instance.PBEAOCBHFGD(Localization.Localize("MessageId"), Localization.Localize("\""), 1038f);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].NALOPNJHPLI.transform.position, ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1514f);
				GuiElementSingle<TutorialClickOverlay>.instance.IGNJKOKGNOI(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].PAKNGGNNNDO.transform.position, GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[1].EPHBGCBAPAN.size, GPCEHFNNCIN: false);
				goto case 4u;
			case 4u:
				if (GuiElementSingle<LevelUpDialog>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(806f);
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<ArmyScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_SELECTONEUNIT");
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 6u;
			case 6u:
				if (!GuiScreenSingle<ArmyScreen>.instance.AFOFDNJOJHG())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				FKGHFOJFMBP = false;
				if (GuiScreenSingle<ArmyScreen>.instance.selectedIcon.KHEOKHHDGPO() != BJGCPDNMHDH.mTutorialUnit)
				{
					FKGHFOJFMBP = false;
					Singleton<GuiManager>.instance.CMCCOCBIGBB();
					PHDOCKCBJOF = new WaitForSeconds(1016f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				goto IL_052e;
			case 7u:
				GuiElementSingle<TutorialDialog>.instance.GPIFEPGEHLF("leagueId", 1612f, TutorialDialog.DODBDLEJOAM.BottomRight);
				OIBJCLOPOLG = GuiScreenSingle<ArmyScreen>.instance.OOLKNBJNFJC();
				GOBCHPOLPIE = null;
				IODGHHFAHJH = Vector3.zero;
				CMIKGAOHHPH = Vector3.one;
				if (OIBJCLOPOLG != null)
				{
					foreach (ArmyUpgradeIcon item in OIBJCLOPOLG)
					{
						if (item.BNPKCKFMBLG() == BJGCPDNMHDH.mTutorialUnit)
						{
							GOBCHPOLPIE = item;
							IODGHHFAHJH = item.transform.position;
							CMIKGAOHHPH = item.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(IODGHHFAHJH, ELHGOHGPJCF: true, ENIHCPLOOAE: true, 1254f);
							GuiElementSingle<TutorialClickOverlay>.instance.NNPKOKCJMHL(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
							break;
						}
					}
				}
				goto case 8u;
			case 8u:
				if (GuiScreenSingle<ArmyScreen>.instance.BDBKFBEIHNF().AIHMCHBCJDO() != BJGCPDNMHDH.mTutorialUnit)
				{
					if (GOBCHPOLPIE != null && GOBCHPOLPIE.transform.position != IODGHHFAHJH)
					{
						IODGHHFAHJH = GOBCHPOLPIE.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.EIDNJNBEPFI(IODGHHFAHJH);
						GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(1492f);
				goto IL_052e;
			case 9u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("Scenes search finished.\n");
				object[] array = new object[1];
				array[1] = Localization.Localize("ID_JOINSQUADDESCRIPTION4");
				instance.BLHPAFCOPMD(aMKLKMJEMJM, Localization.LocalizeFormat("ID_CONFIGURATIONSVERSION", array), 993f, TutorialDialog.DODBDLEJOAM.Left);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.BGPBNIJPOKM.cachedTransform.position, new Vector3(1643f, 552f, 54f), ELHGOHGPJCF: false, ENIHCPLOOAE: true, 1990f);
				GuiElementSingle<TutorialClickOverlay>.instance.LPKOHAKMOOC(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL);
				goto case 10u;
			}
			case 10u:
				if (GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().KHEOKHHDGPO().upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Locked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -123;
					}
					break;
				}
				BJGCPDNMHDH.mUnitBoughtState = 6;
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("nextSquadWars");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(504f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1392f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 68;
				}
				break;
			case 11u:
				if (!GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().AIHMCHBCJDO().upgradeSlots.bought)
				{
					FPHGINDBIDI = false;
					TutorialDialog instance3 = GuiElementSingle<TutorialDialog>.instance;
					string aMKLKMJEMJM3 = Localization.Localize("ID_GOOGLEPLAYLOGOUTTEXT");
					object[] array3 = new object[1];
					array3[1] = Localization.Localize("ADD special offer to show {0} {1} {2}");
					instance3.BLHPAFCOPMD(aMKLKMJEMJM3, Localization.LocalizeFormat("error in count of army", array3), 1346f, TutorialDialog.DODBDLEJOAM.Right, NHEJDPIIOJG: false);
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.LNFLDPLGEJE.transform.position, new Vector3(1648f, 839f, 254f), ELHGOHGPJCF: true, ENIHCPLOOAE: true, 1082f);
					GuiElementSingle<TutorialClickOverlay>.instance.LPKOHAKMOOC(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
					JGPPKCAGAGC = true;
					goto case 13u;
				}
				goto case 14u;
			case 12u:
			{
				TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM2 = Localization.Localize("ID_DELIVERNOW");
				object[] array2 = new object[0];
				array2[1] = Localization.Localize("colt_shooting_loop");
				instance2.PBEAOCBHFGD(aMKLKMJEMJM2, Localization.LocalizeFormat("ID_STATE_FRIENDDOESNTWANTREMATCH", array2), 1805f, TutorialDialog.DODBDLEJOAM.TopRight);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.JPJLKKJJFDB.transform.position, new Vector3(1264f, 161f, 292f), ELHGOHGPJCF: true, ENIHCPLOOAE: true, 495f);
				GuiElementSingle<TutorialClickOverlay>.instance.LPKOHAKMOOC(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
				goto IL_088a;
			}
			case 13u:
				if (!GuiScreenSingle<ArmyScreen>.instance.BDBKFBEIHNF().BNPKCKFMBLG().upgradeSlots.bought)
				{
					if (JGPPKCAGAGC && GuiScreenSingle<ArmyScreen>.instance.selectedIcon.AIHMCHBCJDO().upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Active)
					{
						FPHGINDBIDI = false;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
						GuiElementSingle<TutorialClickOverlay>.instance.Hide(1629f);
						JGPPKCAGAGC = false;
						Singleton<GuiManager>.instance.CMCCOCBIGBB();
						PHDOCKCBJOF = new WaitForSeconds(1473f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = -89;
						}
						break;
					}
					goto IL_088a;
				}
				BJGCPDNMHDH.mUnitBoughtState = 8;
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("SWITCH TO DEATCHMATCH", FPHGINDBIDI);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(1694f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(425f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -101;
				}
				break;
			case 14u:
				BJGCPDNMHDH.mUnitBoughtState = 0;
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ.transform.position, new Vector3(1680f, 1916f, 1331f), ELHGOHGPJCF: false, ENIHCPLOOAE: true, 426f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ, GPCEHFNNCIN: false);
				GuiElementSingle<TutorialClickOverlay>.instance.StartBorderAnimation();
				PHDOCKCBJOF = new WaitForSeconds(804f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -66;
				}
				break;
			case 15u:
			case 16u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 35;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Get Experiment Details clicked");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(1068f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 17u;
			case 17u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.BKIGLABDGCP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -52;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_CARD_DESC_BUDDY"), Localization.Localize("#PETER# removing warcards from slots"), 821f, TutorialDialog.DODBDLEJOAM.Right, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.OMDKNOFNFBB.transform.position, ELHGOHGPJCF: true, ENIHCPLOOAE: false, 559f);
				GuiElementSingle<TutorialClickOverlay>.instance.JGHBBJEFLEB(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.ECJHCGPGGDC, GPCEHFNNCIN: false);
				goto case 18u;
			case 18u:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 55;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("PA: install timestamp ");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(1284f);
				BJGCPDNMHDH.mUnitBoughtState = 5;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_088a:
				PHDOCKCBJOF = true;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 105;
				}
				break;
				IL_052e:
				Singleton<EventTrackingManager>.instance.KEKPOIPDIGK("Warbucks", FKGHFOJFMBP);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(498f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -9;
				}
				break;
			}
			return false;
		}

		[SpecialName]
		private object NAAMAOJBKBK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LCCOIHCHGFM()
		{
			return PHDOCKCBJOF;
		}

		public void ODPKEEIHOPK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GENJNMACGLP()
		{
			return PHDOCKCBJOF;
		}

		public void CALPCMFJHMC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HANDHJHGLAP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BNFADGLHBAH()
		{
			return PHDOCKCBJOF;
		}

		public bool BPHPJKKHNNG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mUnitBoughtState = 1;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						LevelBehaviour current = KFCAECGLKKO.Current;
						if (current.upgradeSlots.isTutorialUnit)
						{
							current.upgradeSlots.bought = true;
							BJGCPDNMHDH.mTutorialUnit = current;
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (BJGCPDNMHDH.mTutorialUnit == null)
				{
					UnityEngine.Debug.LogError(" Special ");
				}
				goto case 1u;
			case 1u:
				if (!GuiElementSingle<LevelUpDialog>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (!GuiElementSingle<LevelUpDialog>.instance.CHGDDHJJMME())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				GuiElementSingle<LevelUpDialog>.instance.EPJJFOOMHNL();
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Player with playerId {0} doesnt exists ! ");
				PHDOCKCBJOF = new WaitForSeconds(741f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 3u:
				GuiElementSingle<TutorialDialog>.instance.DOLDLDECPIO(Localization.Localize("game-label-lose"), Localization.Localize("special"), 1765f, TutorialDialog.DODBDLEJOAM.TopRight);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].NALOPNJHPLI.transform.position, ELHGOHGPJCF: true, ENIHCPLOOAE: false, 248f);
				GuiElementSingle<TutorialClickOverlay>.instance.AJNGLEIBMHD(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].PAKNGGNNNDO.transform.position, GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].EPHBGCBAPAN.size, GPCEHFNNCIN: false);
				goto case 4u;
			case 4u:
				if (GuiElementSingle<LevelUpDialog>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(1532f);
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<ArmyScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Tutorial Manager 6: Starting Tutorial - Guide player to match");
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 6u;
			case 6u:
				if (!GuiScreenSingle<ArmyScreen>.instance.AFOFDNJOJHG())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				FKGHFOJFMBP = false;
				if (GuiScreenSingle<ArmyScreen>.instance.BDBKFBEIHNF().BNPKCKFMBLG() != BJGCPDNMHDH.mTutorialUnit)
				{
					FKGHFOJFMBP = false;
					Singleton<GuiManager>.instance.TurnOffInputCompletly();
					PHDOCKCBJOF = new WaitForSeconds(474f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				goto IL_052e;
			case 7u:
				GuiElementSingle<TutorialDialog>.instance.NIGINCPEHFP("Started delivering |", 844f, TutorialDialog.DODBDLEJOAM.Bottom);
				OIBJCLOPOLG = GuiScreenSingle<ArmyScreen>.instance.armyIcons;
				GOBCHPOLPIE = null;
				IODGHHFAHJH = Vector3.zero;
				CMIKGAOHHPH = Vector3.one;
				if (OIBJCLOPOLG != null)
				{
					foreach (ArmyUpgradeIcon item in OIBJCLOPOLG)
					{
						if (item.PPMNNKANOEF() == BJGCPDNMHDH.mTutorialUnit)
						{
							GOBCHPOLPIE = item;
							IODGHHFAHJH = item.transform.position;
							CMIKGAOHHPH = item.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(IODGHHFAHJH, ELHGOHGPJCF: true, ENIHCPLOOAE: false, 873f);
							GuiElementSingle<TutorialClickOverlay>.instance.IGNJKOKGNOI(IODGHHFAHJH, CMIKGAOHHPH);
							break;
						}
					}
				}
				goto case 8u;
			case 8u:
				if (GuiScreenSingle<ArmyScreen>.instance.selectedIcon.AIHMCHBCJDO() != BJGCPDNMHDH.mTutorialUnit)
				{
					if (GOBCHPOLPIE != null && GOBCHPOLPIE.transform.position != IODGHHFAHJH)
					{
						IODGHHFAHJH = GOBCHPOLPIE.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.IMOAGBADPCC(IODGHHFAHJH);
						GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(1827f);
				goto IL_052e;
			case 9u:
				GuiElementSingle<TutorialDialog>.instance.DOLDLDECPIO(Localization.Localize("Source texture is null"), Localization.LocalizeFormat("Xp", Localization.Localize("SERVICE_DISABLED")), 1398f, TutorialDialog.DODBDLEJOAM.Center, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.BGPBNIJPOKM.cachedTransform.position, new Vector3(321f, 142f, 1075f), ELHGOHGPJCF: true, ENIHCPLOOAE: true, 1951f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
				goto case 10u;
			case 10u:
				if (GuiScreenSingle<ArmyScreen>.instance.BDBKFBEIHNF().levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -78;
					}
					break;
				}
				BJGCPDNMHDH.mUnitBoughtState = 1;
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Hiding CONFIRM dialog");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(1006f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(628f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -126;
				}
				break;
			case 11u:
				if (!GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().levelBehaviour.upgradeSlots.bought)
				{
					FPHGINDBIDI = false;
					TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
					string aMKLKMJEMJM2 = Localization.Localize("zoneHasVirtualGoodsOffer");
					object[] array2 = new object[1];
					array2[1] = Localization.Localize("veteranpack0");
					instance2.DOLDLDECPIO(aMKLKMJEMJM2, Localization.LocalizeFormat("ID_MISSION_SURVIVE_HUD", array2), 164f, TutorialDialog.DODBDLEJOAM.BottomLeft);
					GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.LNFLDPLGEJE.transform.position, new Vector3(1429f, 327f, 1389f), ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1321f);
					GuiElementSingle<TutorialClickOverlay>.instance.GBHNBKFGCPG(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
					JGPPKCAGAGC = false;
					goto case 13u;
				}
				goto case 14u;
			case 12u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("HeroicMissionsCompletionRewardCardPack");
				object[] array = new object[1];
				array[1] = Localization.Localize("GameLauncher.Start");
				instance.BLHPAFCOPMD(aMKLKMJEMJM, Localization.LocalizeFormat("ID_RANK", array), 1339f, TutorialDialog.DODBDLEJOAM.Top);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.JPJLKKJJFDB.transform.position, new Vector3(1654f, 1115f, 521f), ELHGOHGPJCF: false, ENIHCPLOOAE: false, 915f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL);
				goto IL_088a;
			}
			case 13u:
				if (!GuiScreenSingle<ArmyScreen>.instance.selectedIcon.KHEOKHHDGPO().upgradeSlots.bought)
				{
					if (JGPPKCAGAGC && GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().KHEOKHHDGPO().upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Locked)
					{
						FPHGINDBIDI = true;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.Hide();
						GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(1443f);
						JGPPKCAGAGC = false;
						Singleton<GuiManager>.instance.TurnOffInputCompletly();
						PHDOCKCBJOF = new WaitForSeconds(607f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = -7;
						}
						break;
					}
					goto IL_088a;
				}
				BJGCPDNMHDH.mUnitBoughtState = 1;
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("Still waiting for server\nBe patient :-)", FPHGINDBIDI);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(291f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1632f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -1;
				}
				break;
			case 14u:
				BJGCPDNMHDH.mUnitBoughtState = 4;
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ.transform.position, new Vector3(1005f, 1135f, 207f), ELHGOHGPJCF: false, ENIHCPLOOAE: false, 893f);
				GuiElementSingle<TutorialClickOverlay>.instance.LECHCOBHAFP(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ);
				GuiElementSingle<TutorialClickOverlay>.instance.EMEBKHJECFA();
				PHDOCKCBJOF = new WaitForSeconds(243f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -87;
				}
				break;
			case 15u:
			case 16u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("DemoteOrKickPlayer {0} {1}");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(1290f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 17u;
			case 17u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -68;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.BLHPAFCOPMD(Localization.Localize("game-revenge-indicator"), Localization.Localize("ID_TUTORIAL_OBJECTIVE"), 243f, TutorialDialog.DODBDLEJOAM.BottomLeft, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.OMDKNOFNFBB.transform.position, ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1098f);
				GuiElementSingle<TutorialClickOverlay>.instance.CAIGHMDPBDI(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.ECJHCGPGGDC, GPCEHFNNCIN: false);
				goto case 18u;
			case 18u:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 20;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("YES");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(1221f);
				BJGCPDNMHDH.mUnitBoughtState = 5;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_088a:
				PHDOCKCBJOF = false;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -16;
				}
				break;
				IL_052e:
				Singleton<EventTrackingManager>.instance.RegisterTutorialUnitSelectedEvent("ShotFrequencyMin", FKGHFOJFMBP);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1082f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -65;
				}
				break;
			}
			return true;
		}

		public void NINFNJOMJOD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void GICLICNJPBF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object CIHKIABJBGJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BJJNGPKNCKJ()
		{
			return PHDOCKCBJOF;
		}

		public bool FJKEEKBNKPN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mUnitBoughtState = 1;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						LevelBehaviour current = KFCAECGLKKO.Current;
						if (current.upgradeSlots.isTutorialUnit)
						{
							current.upgradeSlots.bought = true;
							BJGCPDNMHDH.mTutorialUnit = current;
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (BJGCPDNMHDH.mTutorialUnit == null)
				{
					UnityEngine.Debug.LogError("Setting master client");
				}
				goto case 1u;
			case 1u:
				if (!GuiElementSingle<LevelUpDialog>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (!GuiElementSingle<LevelUpDialog>.instance.KOFGBOKHPFA())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				GuiElementSingle<LevelUpDialog>.instance.HCODOFNNLDL();
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Connection_Fail");
				PHDOCKCBJOF = new WaitForSeconds(780f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 3u:
				GuiElementSingle<TutorialDialog>.instance.PBEAOCBHFGD(Localization.Localize("ID_MIN"), Localization.Localize("Rental"), 1832f, TutorialDialog.DODBDLEJOAM.Top);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[1].NALOPNJHPLI.transform.position, ELHGOHGPJCF: false, ENIHCPLOOAE: true, 698f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[1].PAKNGGNNNDO.transform.position, GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].EPHBGCBAPAN.size);
				goto case 4u;
			case 4u:
				if (GuiElementSingle<LevelUpDialog>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(1846f);
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<ArmyScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Text");
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 6u;
			case 6u:
				if (!GuiScreenSingle<ArmyScreen>.instance.BKIGLABDGCP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				FKGHFOJFMBP = true;
				if (GuiScreenSingle<ArmyScreen>.instance.selectedIcon.levelBehaviour != BJGCPDNMHDH.mTutorialUnit)
				{
					FKGHFOJFMBP = false;
					Singleton<GuiManager>.instance.CMCCOCBIGBB();
					PHDOCKCBJOF = new WaitForSeconds(1401f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				goto IL_052e;
			case 7u:
				GuiElementSingle<TutorialDialog>.instance.CLINGHOGNGM("ID_ACCEPTEDMEMBERSONLY", 1265f, TutorialDialog.DODBDLEJOAM.Right);
				OIBJCLOPOLG = GuiScreenSingle<ArmyScreen>.instance.OOLKNBJNFJC();
				GOBCHPOLPIE = null;
				IODGHHFAHJH = Vector3.zero;
				CMIKGAOHHPH = Vector3.one;
				if (OIBJCLOPOLG != null)
				{
					foreach (ArmyUpgradeIcon item in OIBJCLOPOLG)
					{
						if (item.KHEOKHHDGPO() == BJGCPDNMHDH.mTutorialUnit)
						{
							GOBCHPOLPIE = item;
							IODGHHFAHJH = item.transform.position;
							CMIKGAOHHPH = item.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(IODGHHFAHJH, ELHGOHGPJCF: false, ENIHCPLOOAE: false, 1795f);
							GuiElementSingle<TutorialClickOverlay>.instance.IGNJKOKGNOI(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
							break;
						}
					}
				}
				goto case 8u;
			case 8u:
				if (GuiScreenSingle<ArmyScreen>.instance.selectedIcon.AIHMCHBCJDO() != BJGCPDNMHDH.mTutorialUnit)
				{
					if (GOBCHPOLPIE != null && GOBCHPOLPIE.transform.position != IODGHHFAHJH)
					{
						IODGHHFAHJH = GOBCHPOLPIE.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.OOIJFHGCCNH(IODGHHFAHJH, ELHGOHGPJCF: false);
						GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(IODGHHFAHJH, CMIKGAOHHPH);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(841f);
				goto IL_052e;
			case 9u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("menu-army-reload-ico");
				object[] array = new object[0];
				array[0] = Localization.Localize("game-card-ico-disarmed");
				instance.BLHPAFCOPMD(aMKLKMJEMJM, Localization.LocalizeFormat("ACD: Memory was tampered, cheater detected!", array), 517f, TutorialDialog.DODBDLEJOAM.Right, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.BGPBNIJPOKM.cachedTransform.position, new Vector3(1821f, 1243f, 478f), ELHGOHGPJCF: true, ENIHCPLOOAE: true, 1030f);
				GuiElementSingle<TutorialClickOverlay>.instance.LECHCOBHAFP(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL);
				goto case 10u;
			}
			case 10u:
				if (GuiScreenSingle<ArmyScreen>.instance.BDBKFBEIHNF().KHEOKHHDGPO().upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Locked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 48;
					}
					break;
				}
				BJGCPDNMHDH.mUnitBoughtState = 6;
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_RETRY");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(1352f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(941f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -54;
				}
				break;
			case 11u:
				if (!GuiScreenSingle<ArmyScreen>.instance.BDBKFBEIHNF().levelBehaviour.upgradeSlots.bought)
				{
					FPHGINDBIDI = true;
					GuiElementSingle<TutorialDialog>.instance.DOLDLDECPIO(Localization.Localize("BoughtIndex"), Localization.LocalizeFormat("Device Language - android: {0}", Localization.Localize("BonusDamage")), 438f);
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.LNFLDPLGEJE.transform.position, new Vector3(1686f, 1605f, 603f), ELHGOHGPJCF: false, ENIHCPLOOAE: true, 507f);
					GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
					JGPPKCAGAGC = false;
					goto case 13u;
				}
				goto case 14u;
			case 12u:
			{
				TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM2 = Localization.Localize("PLAYER");
				object[] array2 = new object[1];
				array2[1] = Localization.Localize("ID_YOUNEEDTOEQUIPWEAPON");
				instance2.DOLDLDECPIO(aMKLKMJEMJM2, Localization.LocalizeFormat(" has no SkillShotController", array2), 1751f, TutorialDialog.DODBDLEJOAM.BottomLeft, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.JPJLKKJJFDB.transform.position, new Vector3(1675f, 846f, 1722f), ELHGOHGPJCF: true, ENIHCPLOOAE: true, 400f);
				GuiElementSingle<TutorialClickOverlay>.instance.LECHCOBHAFP(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
				goto IL_088a;
			}
			case 13u:
				if (!GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().levelBehaviour.upgradeSlots.bought)
				{
					if (JGPPKCAGAGC && GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().BNPKCKFMBLG().upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Locked)
					{
						FPHGINDBIDI = true;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
						GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(755f);
						JGPPKCAGAGC = false;
						Singleton<GuiManager>.instance.TurnOffInputCompletly();
						PHDOCKCBJOF = new WaitForSeconds(1912f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = -126;
						}
						break;
					}
					goto IL_088a;
				}
				BJGCPDNMHDH.mUnitBoughtState = 5;
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent(" TOTAL UNSUED RESERVED: ", FPHGINDBIDI);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(1739f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1722f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 16;
				}
				break;
			case 14u:
				BJGCPDNMHDH.mUnitBoughtState = 0;
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ.transform.position, new Vector3(1007f, 1701f, 634f), ELHGOHGPJCF: false, ENIHCPLOOAE: true, 1312f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ);
				GuiElementSingle<TutorialClickOverlay>.instance.KKCKBELEPHJ();
				PHDOCKCBJOF = new WaitForSeconds(1470f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -78;
				}
				break;
			case 15u:
			case 16u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 48;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Card_2_Played");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(551f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 17u;
			case 17u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -118;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.BLHPAFCOPMD(Localization.Localize("Show squad "), Localization.Localize("SquadPoints"), 1756f);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.OMDKNOFNFBB.transform.position, ELHGOHGPJCF: false, ENIHCPLOOAE: true, 863f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.ECJHCGPGGDC, GPCEHFNNCIN: false);
				goto case 18u;
			case 18u:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -71;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("x");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(1182f);
				BJGCPDNMHDH.mUnitBoughtState = 5;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_088a:
				PHDOCKCBJOF = false;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 10;
				}
				break;
				IL_052e:
				Singleton<EventTrackingManager>.instance.KEKPOIPDIGK("run_grenadelauncher", FKGHFOJFMBP);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(781f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 118;
				}
				break;
			}
			return true;
		}

		public void AEFEAMAGBKK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CJCHFDFCPPL()
		{
			return PHDOCKCBJOF;
		}

		public void MEBPMHDHIPJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BBDOFDBCILK()
		{
			return PHDOCKCBJOF;
		}

		public void LJPIDOKGNBF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void GPJGKJCDFOE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool LAICPPPPIKL()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mUnitBoughtState = 0;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						LevelBehaviour current = KFCAECGLKKO.Current;
						if (current.upgradeSlots.isTutorialUnit)
						{
							current.upgradeSlots.bought = true;
							BJGCPDNMHDH.mTutorialUnit = current;
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (BJGCPDNMHDH.mTutorialUnit == null)
				{
					UnityEngine.Debug.LogError(".");
				}
				goto case 1u;
			case 1u:
				if (!GuiElementSingle<LevelUpDialog>.instance.LHDGJFHPJNM())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (!GuiElementSingle<LevelUpDialog>.instance.PIAOCINHGJE())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				GuiElementSingle<LevelUpDialog>.instance.JIHGNOJJHEB();
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("DatabasePlayer Name: {0}  Id: {1}  Level: {2}  SquadRank: {3}");
				PHDOCKCBJOF = new WaitForSeconds(446f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 3u:
				GuiElementSingle<TutorialDialog>.instance.BLHPAFCOPMD(Localization.Localize("SquadMembers"), Localization.Localize("QUIT"), 1919f, TutorialDialog.DODBDLEJOAM.TopLeft);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[1].NALOPNJHPLI.transform.position, ELHGOHGPJCF: false, ENIHCPLOOAE: false, 461f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[1].PAKNGGNNNDO.transform.position, GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[1].EPHBGCBAPAN.size);
				goto case 4u;
			case 4u:
				if (GuiElementSingle<LevelUpDialog>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(752f);
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<ArmyScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("#PETER# NOTIFICATION CENTER - Add message ");
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 6u;
			case 6u:
				if (!GuiScreenSingle<ArmyScreen>.instance.AFOFDNJOJHG())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				FKGHFOJFMBP = true;
				if (GuiScreenSingle<ArmyScreen>.instance.selectedIcon.levelBehaviour != BJGCPDNMHDH.mTutorialUnit)
				{
					FKGHFOJFMBP = false;
					Singleton<GuiManager>.instance.TurnOffInputCompletly();
					PHDOCKCBJOF = new WaitForSeconds(1095f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				goto IL_052e;
			case 7u:
				GuiElementSingle<TutorialDialog>.instance.CLINGHOGNGM("   {0}", 1303f, TutorialDialog.DODBDLEJOAM.TopLeft);
				OIBJCLOPOLG = GuiScreenSingle<ArmyScreen>.instance.MAPKDMOOFMM();
				GOBCHPOLPIE = null;
				IODGHHFAHJH = Vector3.zero;
				CMIKGAOHHPH = Vector3.one;
				if (OIBJCLOPOLG != null)
				{
					foreach (ArmyUpgradeIcon item in OIBJCLOPOLG)
					{
						if (item.AIHMCHBCJDO() == BJGCPDNMHDH.mTutorialUnit)
						{
							GOBCHPOLPIE = item;
							IODGHHFAHJH = item.transform.position;
							CMIKGAOHHPH = item.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(IODGHHFAHJH, ELHGOHGPJCF: true, ENIHCPLOOAE: true, 1199f);
							GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(IODGHHFAHJH, CMIKGAOHHPH);
							break;
						}
					}
				}
				goto case 8u;
			case 8u:
				if (GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().AIHMCHBCJDO() != BJGCPDNMHDH.mTutorialUnit)
				{
					if (GOBCHPOLPIE != null && GOBCHPOLPIE.transform.position != IODGHHFAHJH)
					{
						IODGHHFAHJH = GOBCHPOLPIE.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.OOIJFHGCCNH(IODGHHFAHJH);
						GuiElementSingle<TutorialClickOverlay>.instance.IGNJKOKGNOI(IODGHHFAHJH, CMIKGAOHHPH);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(555f);
				goto IL_052e;
			case 9u:
				GuiElementSingle<TutorialDialog>.instance.DOLDLDECPIO(Localization.Localize("N"), Localization.LocalizeFormat("Walk", Localization.Localize("ID_HOURAGO")), 527f, TutorialDialog.DODBDLEJOAM.Top);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.BGPBNIJPOKM.cachedTransform.position, new Vector3(684f, 1634f, 1831f), ELHGOHGPJCF: true, ENIHCPLOOAE: true, 890f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
				goto case 10u;
			case 10u:
				if (GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().PPMNNKANOEF().upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Locked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -72;
					}
					break;
				}
				BJGCPDNMHDH.mUnitBoughtState = 5;
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("LostGameInRow");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(874f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(266f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -125;
				}
				break;
			case 11u:
				if (!GuiScreenSingle<ArmyScreen>.instance.selectedIcon.levelBehaviour.upgradeSlots.bought)
				{
					FPHGINDBIDI = true;
					TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
					string aMKLKMJEMJM2 = Localization.Localize("Google2u.");
					object[] array2 = new object[0];
					array2[1] = Localization.Localize(",");
					instance2.BLHPAFCOPMD(aMKLKMJEMJM2, Localization.LocalizeFormat("LevelName", array2), 675f, TutorialDialog.DODBDLEJOAM.Right, NHEJDPIIOJG: false);
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.LNFLDPLGEJE.transform.position, new Vector3(92f, 1632f, 1117f), ELHGOHGPJCF: false, ENIHCPLOOAE: true, 1323f);
					GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
					JGPPKCAGAGC = true;
					goto case 13u;
				}
				goto case 14u;
			case 12u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("BANDS_EMPTY");
				object[] array = new object[1];
				array[1] = Localization.Localize("UnitTutorial");
				instance.ShowMenuTutorial(aMKLKMJEMJM, Localization.LocalizeFormat(" NOT OK!\t\t\t\t\t\t", array), 554f, TutorialDialog.DODBDLEJOAM.TopRight);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.JPJLKKJJFDB.transform.position, new Vector3(827f, 1445f, 849f), ELHGOHGPJCF: true, ENIHCPLOOAE: true, 147f);
				GuiElementSingle<TutorialClickOverlay>.instance.PGOLMCBEIOD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
				goto IL_088a;
			}
			case 13u:
				if (!GuiScreenSingle<ArmyScreen>.instance.BDBKFBEIHNF().PPMNNKANOEF().upgradeSlots.bought)
				{
					if (JGPPKCAGAGC && GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.UnitDelivering)
					{
						FPHGINDBIDI = false;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
						GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(1057f);
						JGPPKCAGAGC = false;
						Singleton<GuiManager>.instance.CMCCOCBIGBB();
						PHDOCKCBJOF = new WaitForSeconds(1334f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = -34;
						}
						break;
					}
					goto IL_088a;
				}
				BJGCPDNMHDH.mUnitBoughtState = 5;
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("getOriginalAccountType", FPHGINDBIDI);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(651f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(774f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -24;
				}
				break;
			case 14u:
				BJGCPDNMHDH.mUnitBoughtState = 2;
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ.transform.position, new Vector3(151f, 985f, 1181f), ELHGOHGPJCF: true, ENIHCPLOOAE: true, 1683f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ, GPCEHFNNCIN: false);
				GuiElementSingle<TutorialClickOverlay>.instance.EOBHJEGACCF();
				PHDOCKCBJOF = new WaitForSeconds(1728f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -71;
				}
				break;
			case 15u:
			case 16u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 14;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_SALEPERCENT");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(1506f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 17u;
			case 17u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.MHAIBHBGBOO())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -28;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("Sniper_Tutorial_Played"), Localization.Localize("ShotFrequencyMax"), 9f, TutorialDialog.DODBDLEJOAM.BottomRight);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.OMDKNOFNFBB.transform.position, ELHGOHGPJCF: false, ENIHCPLOOAE: true, 465f);
				GuiElementSingle<TutorialClickOverlay>.instance.MEBFBNDKOGD(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.ECJHCGPGGDC);
				goto case 18u;
			case 18u:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -89;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("GetAllSquadMembers - squad {0} - force {1}");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(287f);
				BJGCPDNMHDH.mUnitBoughtState = 3;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_088a:
				PHDOCKCBJOF = true;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 108;
				}
				break;
				IL_052e:
				Singleton<EventTrackingManager>.instance.RegisterTutorialUnitSelectedEvent("whiteRectangle", FKGHFOJFMBP);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1977f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -82;
				}
				break;
			}
			return true;
		}

		public bool HMLAEHJKPJE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mUnitBoughtState = 0;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						LevelBehaviour current = KFCAECGLKKO.Current;
						if (current.upgradeSlots.isTutorialUnit)
						{
							current.upgradeSlots.bought = false;
							BJGCPDNMHDH.mTutorialUnit = current;
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (BJGCPDNMHDH.mTutorialUnit == null)
				{
					UnityEngine.Debug.LogError("special");
				}
				goto case 1u;
			case 1u:
				if (!GuiElementSingle<LevelUpDialog>.instance.MHAIBHBGBOO())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (!GuiElementSingle<LevelUpDialog>.instance.completeAnimation)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				GuiElementSingle<LevelUpDialog>.instance.BHCCGGIBJDO();
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(" ");
				PHDOCKCBJOF = new WaitForSeconds(815f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 3u:
				GuiElementSingle<TutorialDialog>.instance.BLHPAFCOPMD(Localization.Localize("ID_CATEGORY_LOW_PL_SMG"), Localization.Localize("Setting unit delivery"), 1909f, TutorialDialog.DODBDLEJOAM.Center, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].NALOPNJHPLI.transform.position, ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1534f);
				GuiElementSingle<TutorialClickOverlay>.instance.EEMMKEMADFC(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[1].PAKNGGNNNDO.transform.position, GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[1].EPHBGCBAPAN.size);
				goto case 4u;
			case 4u:
				if (GuiElementSingle<LevelUpDialog>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(714f);
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<ArmyScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Awaiting players - Player id:\"{0}\" is not in list of awaiting members - cannot accept player");
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 6u;
			case 6u:
				if (!GuiScreenSingle<ArmyScreen>.instance.BKIGLABDGCP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				FKGHFOJFMBP = true;
				if (GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().PPMNNKANOEF() != BJGCPDNMHDH.mTutorialUnit)
				{
					FKGHFOJFMBP = true;
					Singleton<GuiManager>.instance.CMCCOCBIGBB();
					PHDOCKCBJOF = new WaitForSeconds(516f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				goto IL_052e;
			case 7u:
				GuiElementSingle<TutorialDialog>.instance.NIGINCPEHFP("ID_SQUADMEDALS", 1865f, TutorialDialog.DODBDLEJOAM.TopRight);
				OIBJCLOPOLG = GuiScreenSingle<ArmyScreen>.instance.armyIcons;
				GOBCHPOLPIE = null;
				IODGHHFAHJH = Vector3.zero;
				CMIKGAOHHPH = Vector3.one;
				if (OIBJCLOPOLG != null)
				{
					foreach (ArmyUpgradeIcon item in OIBJCLOPOLG)
					{
						if (item.levelBehaviour == BJGCPDNMHDH.mTutorialUnit)
						{
							GOBCHPOLPIE = item;
							IODGHHFAHJH = item.transform.position;
							CMIKGAOHHPH = item.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(IODGHHFAHJH, ELHGOHGPJCF: false, ENIHCPLOOAE: true, 1734f);
							GuiElementSingle<TutorialClickOverlay>.instance.EEMMKEMADFC(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
							break;
						}
					}
				}
				goto case 8u;
			case 8u:
				if (GuiScreenSingle<ArmyScreen>.instance.selectedIcon.BNPKCKFMBLG() != BJGCPDNMHDH.mTutorialUnit)
				{
					if (GOBCHPOLPIE != null && GOBCHPOLPIE.transform.position != IODGHHFAHJH)
					{
						IODGHHFAHJH = GOBCHPOLPIE.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.NFPJIFHLFNB(IODGHHFAHJH, ELHGOHGPJCF: false);
						GuiElementSingle<TutorialClickOverlay>.instance.AJNGLEIBMHD(IODGHHFAHJH, CMIKGAOHHPH);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(78f);
				goto IL_052e;
			case 9u:
				GuiElementSingle<TutorialDialog>.instance.DOLDLDECPIO(Localization.Localize("ID_BATTLEWINBONUSFALLSTO"), Localization.LocalizeFormat("Ban Chat Message received", Localization.Localize("Weapon_ID")), 1961f, TutorialDialog.DODBDLEJOAM.TopRight);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.BGPBNIJPOKM.cachedTransform.position, new Vector3(654f, 1483f, 611f), ELHGOHGPJCF: false, ENIHCPLOOAE: true, 354f);
				GuiElementSingle<TutorialClickOverlay>.instance.GBHNBKFGCPG(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
				goto case 10u;
			case 10u:
				if (GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().PPMNNKANOEF().upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -57;
					}
					break;
				}
				BJGCPDNMHDH.mUnitBoughtState = 6;
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Wrong_Category");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(1030f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1322f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 107;
				}
				break;
			case 11u:
				if (!GuiScreenSingle<ArmyScreen>.instance.BDBKFBEIHNF().PPMNNKANOEF().upgradeSlots.bought)
				{
					FPHGINDBIDI = true;
					TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
					string aMKLKMJEMJM2 = Localization.Localize("ID_CONFIRM_ERROR");
					object[] array2 = new object[1];
					array2[1] = Localization.Localize("ID_CONFIRM_SERVERERROR");
					instance2.DOLDLDECPIO(aMKLKMJEMJM2, Localization.LocalizeFormat("Seconds_to_connect", array2), 1846f, TutorialDialog.DODBDLEJOAM.BottomLeft);
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.LNFLDPLGEJE.transform.position, new Vector3(1403f, 629f, 1231f), ELHGOHGPJCF: false, ENIHCPLOOAE: false, 1189f);
					GuiElementSingle<TutorialClickOverlay>.instance.LECHCOBHAFP(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL);
					JGPPKCAGAGC = true;
					goto case 13u;
				}
				goto case 14u;
			case 12u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("Gold");
				object[] array = new object[1];
				array[1] = Localization.Localize("()Z");
				instance.DOLDLDECPIO(aMKLKMJEMJM, Localization.LocalizeFormat("ID_READYTIME", array), 682f, TutorialDialog.DODBDLEJOAM.BottomLeft);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.JPJLKKJJFDB.transform.position, new Vector3(1225f, 402f, 1100f), ELHGOHGPJCF: false, ENIHCPLOOAE: false, 1255f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
				goto IL_088a;
			}
			case 13u:
				if (!GuiScreenSingle<ArmyScreen>.instance.selectedIcon.levelBehaviour.upgradeSlots.bought)
				{
					if (JGPPKCAGAGC && GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().KHEOKHHDGPO().upgradeSlots.unitState == (UpgradeSlots.JLANLLEABDC)8)
					{
						FPHGINDBIDI = true;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.Hide();
						GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(1141f);
						JGPPKCAGAGC = false;
						Singleton<GuiManager>.instance.CMCCOCBIGBB();
						PHDOCKCBJOF = new WaitForSeconds(1615f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = -26;
						}
						break;
					}
					goto IL_088a;
				}
				BJGCPDNMHDH.mUnitBoughtState = 3;
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("id: ", FPHGINDBIDI);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(1640f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1470f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -99;
				}
				break;
			case 14u:
				BJGCPDNMHDH.mUnitBoughtState = 8;
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ.transform.position, new Vector3(1552f, 817f, 68f), ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1458f);
				GuiElementSingle<TutorialClickOverlay>.instance.GBHNBKFGCPG(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ, GPCEHFNNCIN: false);
				GuiElementSingle<TutorialClickOverlay>.instance.JMPLMMANKMP();
				PHDOCKCBJOF = new WaitForSeconds(1922f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -94;
				}
				break;
			case 15u:
			case 16u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -126;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Joined room");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(404f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 17u;
			case 17u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -6;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.DOLDLDECPIO(Localization.Localize("leagueMembers"), Localization.Localize("MX"), 1058f, TutorialDialog.DODBDLEJOAM.TopRight, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.OMDKNOFNFBB.transform.position, ELHGOHGPJCF: false, ENIHCPLOOAE: true, 1591f);
				GuiElementSingle<TutorialClickOverlay>.instance.CAIGHMDPBDI(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.ECJHCGPGGDC);
				goto case 18u;
			case 18u:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -43;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("squad");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(1750f);
				BJGCPDNMHDH.mUnitBoughtState = 1;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_088a:
				PHDOCKCBJOF = false;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 18;
				}
				break;
				IL_052e:
				Singleton<EventTrackingManager>.instance.RegisterTutorialUnitSelectedEvent("country-finland", FKGHFOJFMBP);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(663f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 119;
				}
				break;
			}
			return true;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void CDIJEGGMMAK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object AKGMMLGANMJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AFDKAGLDADB()
		{
			return PHDOCKCBJOF;
		}

		public void OEMOMDILPEE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void ODCIKOOGNFG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MJKLPCMKADD()
		{
			return PHDOCKCBJOF;
		}

		public void BCOIPCDCKEJ()
		{
			throw new NotSupportedException();
		}

		public bool KCEAGNMILMA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mUnitBoughtState = 0;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						LevelBehaviour current = KFCAECGLKKO.Current;
						if (current.upgradeSlots.isTutorialUnit)
						{
							current.upgradeSlots.bought = true;
							BJGCPDNMHDH.mTutorialUnit = current;
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (BJGCPDNMHDH.mTutorialUnit == null)
				{
					UnityEngine.Debug.LogError("SquadWarsFinishedMessage: Claiming gold: {0}");
				}
				goto case 1u;
			case 1u:
				if (!GuiElementSingle<LevelUpDialog>.instance.BKIGLABDGCP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (!GuiElementSingle<LevelUpDialog>.instance.CHGDDHJJMME())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				GuiElementSingle<LevelUpDialog>.instance.TutorialHideParts();
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Show money pack: {0}\tConfiguration time: {1}\tTime till end time: {2}\tLast shown: {3}");
				PHDOCKCBJOF = new WaitForSeconds(437f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 3u:
				GuiElementSingle<TutorialDialog>.instance.PBEAOCBHFGD(Localization.Localize("DamageEventPlayerShoot damage: {0} to {1} new HP {2}"), Localization.Localize("damage"), 1858f, TutorialDialog.DODBDLEJOAM.Center, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[1].NALOPNJHPLI.transform.position, ELHGOHGPJCF: false, ENIHCPLOOAE: true, 481f);
				GuiElementSingle<TutorialClickOverlay>.instance.EEMMKEMADFC(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].PAKNGGNNNDO.transform.position, GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].EPHBGCBAPAN.size, GPCEHFNNCIN: false);
				goto case 4u;
			case 4u:
				if (GuiElementSingle<LevelUpDialog>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(1357f);
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<ArmyScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("BattleLength");
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 6u;
			case 6u:
				if (!GuiScreenSingle<ArmyScreen>.instance.MHAIBHBGBOO())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				FKGHFOJFMBP = false;
				if (GuiScreenSingle<ArmyScreen>.instance.selectedIcon.PPMNNKANOEF() != BJGCPDNMHDH.mTutorialUnit)
				{
					FKGHFOJFMBP = true;
					Singleton<GuiManager>.instance.CMCCOCBIGBB();
					PHDOCKCBJOF = new WaitForSeconds(631f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				goto IL_052e;
			case 7u:
				GuiElementSingle<TutorialDialog>.instance.NIGINCPEHFP("Player is in squad ", 1805f, TutorialDialog.DODBDLEJOAM.Top);
				OIBJCLOPOLG = GuiScreenSingle<ArmyScreen>.instance.armyIcons;
				GOBCHPOLPIE = null;
				IODGHHFAHJH = Vector3.zero;
				CMIKGAOHHPH = Vector3.one;
				if (OIBJCLOPOLG != null)
				{
					foreach (ArmyUpgradeIcon item in OIBJCLOPOLG)
					{
						if (item.PPMNNKANOEF() == BJGCPDNMHDH.mTutorialUnit)
						{
							GOBCHPOLPIE = item;
							IODGHHFAHJH = item.transform.position;
							CMIKGAOHHPH = item.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(IODGHHFAHJH, ELHGOHGPJCF: false, ENIHCPLOOAE: false, 940f);
							GuiElementSingle<TutorialClickOverlay>.instance.NNPKOKCJMHL(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
							break;
						}
					}
				}
				goto case 8u;
			case 8u:
				if (GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().KHEOKHHDGPO() != BJGCPDNMHDH.mTutorialUnit)
				{
					if (GOBCHPOLPIE != null && GOBCHPOLPIE.transform.position != IODGHHFAHJH)
					{
						IODGHHFAHJH = GOBCHPOLPIE.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateTapAnimation(IODGHHFAHJH, ELHGOHGPJCF: false);
						GuiElementSingle<TutorialClickOverlay>.instance.EEMMKEMADFC(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(1736f);
				goto IL_052e;
			case 9u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("SquadEventActiveTier");
				object[] array = new object[1];
				array[1] = Localization.Localize("#Mission Rewards# New missions data (midnight or heroic completed)");
				instance.PBEAOCBHFGD(aMKLKMJEMJM, Localization.LocalizeFormat("Is Public = ", array), 60f, TutorialDialog.DODBDLEJOAM.Bottom);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.BGPBNIJPOKM.cachedTransform.position, new Vector3(1552f, 116f, 771f), ELHGOHGPJCF: false, ENIHCPLOOAE: false, 1104f);
				GuiElementSingle<TutorialClickOverlay>.instance.PGOLMCBEIOD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
				goto case 10u;
			}
			case 10u:
				if (GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().BNPKCKFMBLG().upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -14;
					}
					break;
				}
				BJGCPDNMHDH.mUnitBoughtState = 3;
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("{0}");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(744f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(91f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 102;
				}
				break;
			case 11u:
				if (!GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().BNPKCKFMBLG().upgradeSlots.bought)
				{
					FPHGINDBIDI = false;
					TutorialDialog instance3 = GuiElementSingle<TutorialDialog>.instance;
					string aMKLKMJEMJM3 = Localization.Localize("ID_TAKEMETHERE");
					object[] array3 = new object[0];
					array3[0] = Localization.Localize("LEADERBOARDS - showing ");
					instance3.ShowMenuTutorial(aMKLKMJEMJM3, Localization.LocalizeFormat("ammo", array3), 1528f, TutorialDialog.DODBDLEJOAM.Left);
					GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.LNFLDPLGEJE.transform.position, new Vector3(1433f, 1448f, 1241f), ELHGOHGPJCF: true, ENIHCPLOOAE: false, 218f);
					GuiElementSingle<TutorialClickOverlay>.instance.PGOLMCBEIOD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL);
					JGPPKCAGAGC = true;
					goto case 13u;
				}
				goto case 14u;
			case 12u:
			{
				TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM2 = Localization.Localize("StarterPackTimeLimitedOffer");
				object[] array2 = new object[0];
				array2[1] = Localization.Localize("_MatCap");
				instance2.PBEAOCBHFGD(aMKLKMJEMJM2, Localization.LocalizeFormat("ID_THATWASGOODRUNSOLDIERXWINS", array2), 1105f, TutorialDialog.DODBDLEJOAM.Right);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.JPJLKKJJFDB.transform.position, new Vector3(189f, 1522f, 1380f), ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1558f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
				goto IL_088a;
			}
			case 13u:
				if (!GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().AIHMCHBCJDO().upgradeSlots.bought)
				{
					if (JGPPKCAGAGC && GuiScreenSingle<ArmyScreen>.instance.BDBKFBEIHNF().BNPKCKFMBLG().upgradeSlots.unitState == (UpgradeSlots.JLANLLEABDC)7)
					{
						FPHGINDBIDI = true;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
						GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(888f);
						JGPPKCAGAGC = true;
						Singleton<GuiManager>.instance.TurnOffInputCompletly();
						PHDOCKCBJOF = new WaitForSeconds(1688f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 125;
						}
						break;
					}
					goto IL_088a;
				}
				BJGCPDNMHDH.mUnitBoughtState = 8;
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("_D", FPHGINDBIDI);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(567f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1883f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 40;
				}
				break;
			case 14u:
				BJGCPDNMHDH.mUnitBoughtState = 3;
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ.transform.position, new Vector3(1120f, 1263f, 764f), ELHGOHGPJCF: true, ENIHCPLOOAE: true, 986f);
				GuiElementSingle<TutorialClickOverlay>.instance.GBHNBKFGCPG(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ);
				GuiElementSingle<TutorialClickOverlay>.instance.EDPNLNIPCGJ();
				PHDOCKCBJOF = new WaitForSeconds(850f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -30;
				}
				break;
			case 15u:
			case 16u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -49;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("+#;-#");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(5f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 17u;
			case 17u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.MHAIBHBGBOO())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 39;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.PBEAOCBHFGD(Localization.Localize("getExtrasPayload"), Localization.Localize("About to show unit categories reminder"), 1404f, TutorialDialog.DODBDLEJOAM.Center, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.OMDKNOFNFBB.transform.position, ELHGOHGPJCF: true, ENIHCPLOOAE: true, 674f);
				GuiElementSingle<TutorialClickOverlay>.instance.MEBFBNDKOGD(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.ECJHCGPGGDC);
				goto case 18u;
			case 18u:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 65;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ChillingoSdkManager");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(1955f);
				BJGCPDNMHDH.mUnitBoughtState = 8;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_088a:
				PHDOCKCBJOF = true;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -56;
				}
				break;
				IL_052e:
				Singleton<EventTrackingManager>.instance.RegisterTutorialUnitSelectedEvent("0", FKGHFOJFMBP);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1051f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -22;
				}
				break;
			}
			return false;
		}

		public bool PMLLPHFACBM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mUnitBoughtState = 0;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						LevelBehaviour current = KFCAECGLKKO.Current;
						if (current.upgradeSlots.isTutorialUnit)
						{
							current.upgradeSlots.bought = true;
							BJGCPDNMHDH.mTutorialUnit = current;
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (BJGCPDNMHDH.mTutorialUnit == null)
				{
					UnityEngine.Debug.LogError("LeagueEvaluation");
				}
				goto case 1u;
			case 1u:
				if (!GuiElementSingle<LevelUpDialog>.instance.LHDGJFHPJNM())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (!GuiElementSingle<LevelUpDialog>.instance.PIAOCINHGJE())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				GuiElementSingle<LevelUpDialog>.instance.EPJJFOOMHNL();
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Null cannot be saved as last unit.");
				PHDOCKCBJOF = new WaitForSeconds(347f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 3u:
				GuiElementSingle<TutorialDialog>.instance.BLHPAFCOPMD(Localization.Localize("ReSyncRPC"), Localization.Localize("Wood"), 1356f, TutorialDialog.DODBDLEJOAM.Right, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].NALOPNJHPLI.transform.position, ELHGOHGPJCF: false, ENIHCPLOOAE: false, 1507f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[1].PAKNGGNNNDO.transform.position, GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[1].EPHBGCBAPAN.size);
				goto case 4u;
			case 4u:
				if (GuiElementSingle<LevelUpDialog>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(1090f);
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<ArmyScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("\n");
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 6u;
			case 6u:
				if (!GuiScreenSingle<ArmyScreen>.instance.MHAIBHBGBOO())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				FKGHFOJFMBP = true;
				if (GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().levelBehaviour != BJGCPDNMHDH.mTutorialUnit)
				{
					FKGHFOJFMBP = false;
					Singleton<GuiManager>.instance.TurnOffInputCompletly();
					PHDOCKCBJOF = new WaitForSeconds(73f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				goto IL_052e;
			case 7u:
				GuiElementSingle<TutorialDialog>.instance.GPIFEPGEHLF("Action Finished: ", 764f, TutorialDialog.DODBDLEJOAM.BottomRight);
				OIBJCLOPOLG = GuiScreenSingle<ArmyScreen>.instance.armyIcons;
				GOBCHPOLPIE = null;
				IODGHHFAHJH = Vector3.zero;
				CMIKGAOHHPH = Vector3.one;
				if (OIBJCLOPOLG != null)
				{
					foreach (ArmyUpgradeIcon item in OIBJCLOPOLG)
					{
						if (item.AIHMCHBCJDO() == BJGCPDNMHDH.mTutorialUnit)
						{
							GOBCHPOLPIE = item;
							IODGHHFAHJH = item.transform.position;
							CMIKGAOHHPH = item.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(IODGHHFAHJH, ELHGOHGPJCF: false, ENIHCPLOOAE: false, 1131f);
							GuiElementSingle<TutorialClickOverlay>.instance.EEMMKEMADFC(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
							break;
						}
					}
				}
				goto case 8u;
			case 8u:
				if (GuiScreenSingle<ArmyScreen>.instance.BDBKFBEIHNF().PPMNNKANOEF() != BJGCPDNMHDH.mTutorialUnit)
				{
					if (GOBCHPOLPIE != null && GOBCHPOLPIE.transform.position != IODGHHFAHJH)
					{
						IODGHHFAHJH = GOBCHPOLPIE.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateTapAnimation(IODGHHFAHJH, ELHGOHGPJCF: false);
						GuiElementSingle<TutorialClickOverlay>.instance.EEMMKEMADFC(IODGHHFAHJH, CMIKGAOHHPH);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(277f);
				goto IL_052e;
			case 9u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("purchase");
				object[] array = new object[0];
				array[1] = Localization.Localize("ID_NOTIFICATION_UNITUPGRADEDELIVERED");
				instance.PBEAOCBHFGD(aMKLKMJEMJM, Localization.LocalizeFormat("NOT IN LEAGUE", array), 183f, TutorialDialog.DODBDLEJOAM.BottomLeft, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.BGPBNIJPOKM.cachedTransform.position, new Vector3(1357f, 1528f, 1806f), ELHGOHGPJCF: true, ENIHCPLOOAE: false, 317f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
				goto case 10u;
			}
			case 10u:
				if (GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().KHEOKHHDGPO().upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Locked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 69;
					}
					break;
				}
				BJGCPDNMHDH.mUnitBoughtState = 5;
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("PhotonConnectionManager: JoinOfflineGame");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(1043f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1620f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -12;
				}
				break;
			case 11u:
				if (!GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().BNPKCKFMBLG().upgradeSlots.bought)
				{
					FPHGINDBIDI = false;
					TutorialDialog instance3 = GuiElementSingle<TutorialDialog>.instance;
					string aMKLKMJEMJM3 = Localization.Localize("count: 0");
					object[] array3 = new object[0];
					array3[0] = Localization.Localize("Creating challenge message:\nclient version: {0} and room name: {1}");
					instance3.BLHPAFCOPMD(aMKLKMJEMJM3, Localization.LocalizeFormat("Game Rewards lootboxes contents:\n", array3), 449f, TutorialDialog.DODBDLEJOAM.Center, NHEJDPIIOJG: false);
					GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.LNFLDPLGEJE.transform.position, new Vector3(741f, 161f, 1562f), ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1343f);
					GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
					JGPPKCAGAGC = true;
					goto case 13u;
				}
				goto case 14u;
			case 12u:
			{
				TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM2 = Localization.Localize("ID_SLOTUPGRADE_DAMAGE");
				object[] array2 = new object[0];
				array2[1] = Localization.Localize("FJDACAACLLI");
				instance2.PBEAOCBHFGD(aMKLKMJEMJM2, Localization.LocalizeFormat("Google2u.AssaultRifle_AK47", array2), 1823f, TutorialDialog.DODBDLEJOAM.BottomLeft, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.JPJLKKJJFDB.transform.position, new Vector3(1331f, 988f, 1246f), ELHGOHGPJCF: true, ENIHCPLOOAE: false, 171f);
				GuiElementSingle<TutorialClickOverlay>.instance.PGOLMCBEIOD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
				goto IL_088a;
			}
			case 13u:
				if (!GuiScreenSingle<ArmyScreen>.instance.selectedIcon.BNPKCKFMBLG().upgradeSlots.bought)
				{
					if (JGPPKCAGAGC && GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.UnitDelivering)
					{
						FPHGINDBIDI = true;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
						GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(1877f);
						JGPPKCAGAGC = false;
						Singleton<GuiManager>.instance.CMCCOCBIGBB();
						PHDOCKCBJOF = new WaitForSeconds(844f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 24;
						}
						break;
					}
					goto IL_088a;
				}
				BJGCPDNMHDH.mUnitBoughtState = 4;
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("Get full squad id = ", FPHGINDBIDI);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(24f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1928f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 80;
				}
				break;
			case 14u:
				BJGCPDNMHDH.mUnitBoughtState = 7;
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ.transform.position, new Vector3(1127f, 1433f, 1337f), ELHGOHGPJCF: true, ENIHCPLOOAE: true, 0f);
				GuiElementSingle<TutorialClickOverlay>.instance.LECHCOBHAFP(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ);
				GuiElementSingle<TutorialClickOverlay>.instance.JMPLMMANKMP();
				PHDOCKCBJOF = new WaitForSeconds(220f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -95;
				}
				break;
			case 15u:
			case 16u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 75;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("TopRun");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(1618f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 17u;
			case 17u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 48;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.DOLDLDECPIO(Localization.Localize("{0}%"), Localization.Localize(", "), 1791f, TutorialDialog.DODBDLEJOAM.Top);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.OMDKNOFNFBB.transform.position, ELHGOHGPJCF: true, ENIHCPLOOAE: true, 1537f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.ECJHCGPGGDC);
				goto case 18u;
			case 18u:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -29;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("WALLET - spent tickets {0}");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(1592f);
				BJGCPDNMHDH.mUnitBoughtState = 7;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_088a:
				PHDOCKCBJOF = false;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -40;
				}
				break;
				IL_052e:
				Singleton<EventTrackingManager>.instance.KEKPOIPDIGK("ID_CONFIRM_ERROR", FKGHFOJFMBP);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(434f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			}
			return true;
		}

		[SpecialName]
		private object BJECHFCOBLP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MILFCGMBHIG()
		{
			return PHDOCKCBJOF;
		}

		public bool MHNPBDBGBLK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mUnitBoughtState = 1;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						LevelBehaviour current = KFCAECGLKKO.Current;
						if (current.upgradeSlots.isTutorialUnit)
						{
							current.upgradeSlots.bought = true;
							BJGCPDNMHDH.mTutorialUnit = current;
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (BJGCPDNMHDH.mTutorialUnit == null)
				{
					UnityEngine.Debug.LogError("SpawningManagerMultiplayer.prefab");
				}
				goto case 1u;
			case 1u:
				if (!GuiElementSingle<LevelUpDialog>.instance.LHDGJFHPJNM())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (!GuiElementSingle<LevelUpDialog>.instance.FIOPDLGMHKB())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				GuiElementSingle<LevelUpDialog>.instance.TutorialHideParts();
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Attempt");
				PHDOCKCBJOF = new WaitForSeconds(1804f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 3u:
				GuiElementSingle<TutorialDialog>.instance.PBEAOCBHFGD(Localization.Localize("ID_ARENARULES_BATTLES"), Localization.Localize("Visual"), 1408f, TutorialDialog.DODBDLEJOAM.Bottom);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[1].NALOPNJHPLI.transform.position, ELHGOHGPJCF: true, ENIHCPLOOAE: true, 1350f);
				GuiElementSingle<TutorialClickOverlay>.instance.EEMMKEMADFC(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[1].PAKNGGNNNDO.transform.position, GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[1].EPHBGCBAPAN.size);
				goto case 4u;
			case 4u:
				if (GuiElementSingle<LevelUpDialog>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(1350f);
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<ArmyScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("AssignemntId");
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 6u;
			case 6u:
				if (!GuiScreenSingle<ArmyScreen>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				FKGHFOJFMBP = true;
				if (GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().KHEOKHHDGPO() != BJGCPDNMHDH.mTutorialUnit)
				{
					FKGHFOJFMBP = false;
					Singleton<GuiManager>.instance.TurnOffInputCompletly();
					PHDOCKCBJOF = new WaitForSeconds(852f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				goto IL_052e;
			case 7u:
				GuiElementSingle<TutorialDialog>.instance.GPIFEPGEHLF("GetActualIndex()\nCurPosX: {0}", 1925f, TutorialDialog.DODBDLEJOAM.Right);
				OIBJCLOPOLG = GuiScreenSingle<ArmyScreen>.instance.OOLKNBJNFJC();
				GOBCHPOLPIE = null;
				IODGHHFAHJH = Vector3.zero;
				CMIKGAOHHPH = Vector3.one;
				if (OIBJCLOPOLG != null)
				{
					foreach (ArmyUpgradeIcon item in OIBJCLOPOLG)
					{
						if (item.AIHMCHBCJDO() == BJGCPDNMHDH.mTutorialUnit)
						{
							GOBCHPOLPIE = item;
							IODGHHFAHJH = item.transform.position;
							CMIKGAOHHPH = item.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(IODGHHFAHJH, ELHGOHGPJCF: true, ENIHCPLOOAE: true, 1475f);
							GuiElementSingle<TutorialClickOverlay>.instance.NNPKOKCJMHL(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
							break;
						}
					}
				}
				goto case 8u;
			case 8u:
				if (GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().AIHMCHBCJDO() != BJGCPDNMHDH.mTutorialUnit)
				{
					if (GOBCHPOLPIE != null && GOBCHPOLPIE.transform.position != IODGHHFAHJH)
					{
						IODGHHFAHJH = GOBCHPOLPIE.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.NFPJIFHLFNB(IODGHHFAHJH, ELHGOHGPJCF: false);
						GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(IODGHHFAHJH, CMIKGAOHHPH);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(655f);
				goto IL_052e;
			case 9u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("trial");
				object[] array = new object[0];
				array[0] = Localization.Localize("Gold Spent ");
				instance.BLHPAFCOPMD(aMKLKMJEMJM, Localization.LocalizeFormat("[0-9.,]*", array), 1391f, TutorialDialog.DODBDLEJOAM.Bottom);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.BGPBNIJPOKM.cachedTransform.position, new Vector3(773f, 1586f, 1836f), ELHGOHGPJCF: false, ENIHCPLOOAE: false, 1909f);
				GuiElementSingle<TutorialClickOverlay>.instance.LECHCOBHAFP(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
				goto case 10u;
			}
			case 10u:
				if (GuiScreenSingle<ArmyScreen>.instance.BDBKFBEIHNF().levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 13;
					}
					break;
				}
				BJGCPDNMHDH.mUnitBoughtState = 6;
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_UPGRADESMALL");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(911f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1102f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -85;
				}
				break;
			case 11u:
				if (!GuiScreenSingle<ArmyScreen>.instance.BDBKFBEIHNF().BNPKCKFMBLG().upgradeSlots.bought)
				{
					FPHGINDBIDI = true;
					GuiElementSingle<TutorialDialog>.instance.PBEAOCBHFGD(Localization.Localize("Medals requirement = "), Localization.LocalizeFormat("SetBeepRPC", Localization.Localize("ID_GUI_SQUADCHALLENGEENDED")), 331f, TutorialDialog.DODBDLEJOAM.TopLeft, NHEJDPIIOJG: false);
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.LNFLDPLGEJE.transform.position, new Vector3(1764f, 381f, 1764f), ELHGOHGPJCF: true, ENIHCPLOOAE: true, 1779f);
					GuiElementSingle<TutorialClickOverlay>.instance.LECHCOBHAFP(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL);
					JGPPKCAGAGC = false;
					goto case 13u;
				}
				goto case 14u;
			case 12u:
				GuiElementSingle<TutorialDialog>.instance.DOLDLDECPIO(Localization.Localize("DemotedPlayer"), Localization.LocalizeFormat("워프렌즈를 실행하려면 약 190MB의 추가 데이터를 다운로드 받아야 합니다.\n다운로드 시간은 네트워크 및 지역에 따라 달라질 수 있습니다.\n\n계속 진행하시겠습니까?", Localization.Localize("nR8WfJlIwkkqu9mTB81EUGaldBpyX3eE4ErTYxs41gs6uXM51v")), 329f, TutorialDialog.DODBDLEJOAM.Top, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.JPJLKKJJFDB.transform.position, new Vector3(132f, 700f, 1465f), ELHGOHGPJCF: true, ENIHCPLOOAE: false, 672f);
				GuiElementSingle<TutorialClickOverlay>.instance.LECHCOBHAFP(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL);
				goto IL_088a;
			case 13u:
				if (!GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().KHEOKHHDGPO().upgradeSlots.bought)
				{
					if (JGPPKCAGAGC && GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().PPMNNKANOEF().upgradeSlots.unitState == (UpgradeSlots.JLANLLEABDC)7)
					{
						FPHGINDBIDI = false;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
						GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(824f);
						JGPPKCAGAGC = true;
						Singleton<GuiManager>.instance.CMCCOCBIGBB();
						PHDOCKCBJOF = new WaitForSeconds(381f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = -126;
						}
						break;
					}
					goto IL_088a;
				}
				BJGCPDNMHDH.mUnitBoughtState = 5;
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("payloadKeys", FPHGINDBIDI);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(1577f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1011f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -41;
				}
				break;
			case 14u:
				BJGCPDNMHDH.mUnitBoughtState = 0;
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ.transform.position, new Vector3(1892f, 1215f, 792f), ELHGOHGPJCF: false, ENIHCPLOOAE: true, 458f);
				GuiElementSingle<TutorialClickOverlay>.instance.PGOLMCBEIOD(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ, GPCEHFNNCIN: false);
				GuiElementSingle<TutorialClickOverlay>.instance.EOBHJEGACCF();
				PHDOCKCBJOF = new WaitForSeconds(880f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 98;
				}
				break;
			case 15u:
			case 16u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("it");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(426f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 17u;
			case 17u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.AFOFDNJOJHG())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -111;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_CHALLENGEYOURFRIEND"), Localization.Localize("ID_READYTIME"), 482f, TutorialDialog.DODBDLEJOAM.TopRight, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.OMDKNOFNFBB.transform.position, ELHGOHGPJCF: false, ENIHCPLOOAE: true, 186f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.ECJHCGPGGDC, GPCEHFNNCIN: false);
				goto case 18u;
			case 18u:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -67;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("D3");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(1878f);
				BJGCPDNMHDH.mUnitBoughtState = 5;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_088a:
				PHDOCKCBJOF = true;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 126;
				}
				break;
				IL_052e:
				Singleton<EventTrackingManager>.instance.RegisterTutorialUnitSelectedEvent("DOGTAG REWARD DIALOG - not showing because player already played one match and spent gained dogtag", FKGHFOJFMBP);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(249f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -16;
				}
				break;
			}
			return true;
		}

		[SpecialName]
		private object IGFMIFOHCHJ()
		{
			return PHDOCKCBJOF;
		}

		public void JKOCLGOOBEK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void ODINNCBLBOF()
		{
			throw new NotSupportedException();
		}

		public bool BGOEENAEBNO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mUnitBoughtState = 1;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						LevelBehaviour current = KFCAECGLKKO.Current;
						if (current.upgradeSlots.isTutorialUnit)
						{
							current.upgradeSlots.bought = false;
							BJGCPDNMHDH.mTutorialUnit = current;
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (BJGCPDNMHDH.mTutorialUnit == null)
				{
					UnityEngine.Debug.LogError("auto");
				}
				goto case 1u;
			case 1u:
				if (!GuiElementSingle<LevelUpDialog>.instance.AFOFDNJOJHG())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (!GuiElementSingle<LevelUpDialog>.instance.completeAnimation)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				GuiElementSingle<LevelUpDialog>.instance.HCODOFNNLDL();
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_ACHIEVEMENTS");
				PHDOCKCBJOF = new WaitForSeconds(744f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 3u:
				GuiElementSingle<TutorialDialog>.instance.BLHPAFCOPMD(Localization.Localize("menu-attack-ico"), Localization.Localize("ID_INELITE1"), 82f, TutorialDialog.DODBDLEJOAM.Right, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].NALOPNJHPLI.transform.position, ELHGOHGPJCF: true, ENIHCPLOOAE: false, 993f);
				GuiElementSingle<TutorialClickOverlay>.instance.EEMMKEMADFC(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].PAKNGGNNNDO.transform.position, GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[1].EPHBGCBAPAN.size, GPCEHFNNCIN: false);
				goto case 4u;
			case 4u:
				if (GuiElementSingle<LevelUpDialog>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(1333f);
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<ArmyScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("menu-cards-silverpack");
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 6u;
			case 6u:
				if (!GuiScreenSingle<ArmyScreen>.instance.BJNBLINDAED())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				FKGHFOJFMBP = false;
				if (GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().PPMNNKANOEF() != BJGCPDNMHDH.mTutorialUnit)
				{
					FKGHFOJFMBP = false;
					Singleton<GuiManager>.instance.CMCCOCBIGBB();
					PHDOCKCBJOF = new WaitForSeconds(1726f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				goto IL_052e;
			case 7u:
				GuiElementSingle<TutorialDialog>.instance.FJFFALBAFBD("de", 954f, TutorialDialog.DODBDLEJOAM.Right);
				OIBJCLOPOLG = GuiScreenSingle<ArmyScreen>.instance.OOLKNBJNFJC();
				GOBCHPOLPIE = null;
				IODGHHFAHJH = Vector3.zero;
				CMIKGAOHHPH = Vector3.one;
				if (OIBJCLOPOLG != null)
				{
					foreach (ArmyUpgradeIcon item in OIBJCLOPOLG)
					{
						if (item.AIHMCHBCJDO() == BJGCPDNMHDH.mTutorialUnit)
						{
							GOBCHPOLPIE = item;
							IODGHHFAHJH = item.transform.position;
							CMIKGAOHHPH = item.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(IODGHHFAHJH, ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1347f);
							GuiElementSingle<TutorialClickOverlay>.instance.NNPKOKCJMHL(IODGHHFAHJH, CMIKGAOHHPH);
							break;
						}
					}
				}
				goto case 8u;
			case 8u:
				if (GuiScreenSingle<ArmyScreen>.instance.selectedIcon.PPMNNKANOEF() != BJGCPDNMHDH.mTutorialUnit)
				{
					if (GOBCHPOLPIE != null && GOBCHPOLPIE.transform.position != IODGHHFAHJH)
					{
						IODGHHFAHJH = GOBCHPOLPIE.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.IMOAGBADPCC(IODGHHFAHJH);
						GuiElementSingle<TutorialClickOverlay>.instance.NNPKOKCJMHL(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(1909f);
				goto IL_052e;
			case 9u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("ABOUT TO SHOW DAILY GOLD BOOST ");
				object[] array = new object[0];
				array[1] = Localization.Localize("ID_USEREXISTSGOOGLEPLAYTEXT");
				instance.PBEAOCBHFGD(aMKLKMJEMJM, Localization.LocalizeFormat("Different levels \"{0}\" and \"{1}\"\n", array), 655f, TutorialDialog.DODBDLEJOAM.Left);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.BGPBNIJPOKM.cachedTransform.position, new Vector3(499f, 1480f, 809f), ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1372f);
				GuiElementSingle<TutorialClickOverlay>.instance.LECHCOBHAFP(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL);
				goto case 10u;
			}
			case 10u:
				if (GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 95;
					}
					break;
				}
				BJGCPDNMHDH.mUnitBoughtState = 6;
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_CONFIRM_JOININGSQUAD_TEXT");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(1284f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1500f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 74;
				}
				break;
			case 11u:
				if (!GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().KHEOKHHDGPO().upgradeSlots.bought)
				{
					FPHGINDBIDI = false;
					TutorialDialog instance3 = GuiElementSingle<TutorialDialog>.instance;
					string aMKLKMJEMJM3 = Localization.Localize("BONUS: size: ");
					object[] array3 = new object[1];
					array3[1] = Localization.Localize("DailyMissionsCompletionRewardCards");
					instance3.ShowMenuTutorial(aMKLKMJEMJM3, Localization.LocalizeFormat(", current = ", array3), 749f, TutorialDialog.DODBDLEJOAM.Bottom, NHEJDPIIOJG: false);
					GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.LNFLDPLGEJE.transform.position, new Vector3(1353f, 1760f, 1852f), ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1288f);
					GuiElementSingle<TutorialClickOverlay>.instance.GBHNBKFGCPG(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
					JGPPKCAGAGC = true;
					goto case 13u;
				}
				goto case 14u;
			case 12u:
			{
				TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM2 = Localization.Localize("PowerBandBuyReminder");
				object[] array2 = new object[1];
				array2[1] = Localization.Localize("\n</font>");
				instance2.PBEAOCBHFGD(aMKLKMJEMJM2, Localization.LocalizeFormat("N", array2), 1960f, TutorialDialog.DODBDLEJOAM.Center, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.JPJLKKJJFDB.transform.position, new Vector3(1994f, 320f, 1525f), ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1450f);
				GuiElementSingle<TutorialClickOverlay>.instance.GBHNBKFGCPG(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL);
				goto IL_088a;
			}
			case 13u:
				if (!GuiScreenSingle<ArmyScreen>.instance.BDBKFBEIHNF().KHEOKHHDGPO().upgradeSlots.bought)
				{
					if (JGPPKCAGAGC && GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().AIHMCHBCJDO().upgradeSlots.unitState == (UpgradeSlots.JLANLLEABDC)8)
					{
						FPHGINDBIDI = true;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
						GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(978f);
						JGPPKCAGAGC = false;
						Singleton<GuiManager>.instance.TurnOffInputCompletly();
						PHDOCKCBJOF = new WaitForSeconds(1850f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 83;
						}
						break;
					}
					goto IL_088a;
				}
				BJGCPDNMHDH.mUnitBoughtState = 6;
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("ID_READYTIME", FPHGINDBIDI);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(92f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1831f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -11;
				}
				break;
			case 14u:
				BJGCPDNMHDH.mUnitBoughtState = 1;
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ.transform.position, new Vector3(1723f, 117f, 747f), ELHGOHGPJCF: true, ENIHCPLOOAE: true, 1460f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ);
				GuiElementSingle<TutorialClickOverlay>.instance.StartBorderAnimation();
				PHDOCKCBJOF = new WaitForSeconds(546f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 52;
				}
				break;
			case 15u:
			case 16u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -83;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Heroic");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(1769f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 17u;
			case 17u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -60;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.DOLDLDECPIO(Localization.Localize("Time"), Localization.Localize("Days_Since_Install"), 1342f, TutorialDialog.DODBDLEJOAM.Top, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.OMDKNOFNFBB.transform.position, ELHGOHGPJCF: true, ENIHCPLOOAE: true, 1760f);
				GuiElementSingle<TutorialClickOverlay>.instance.FCGLGPIBAEN(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.ECJHCGPGGDC, GPCEHFNNCIN: false);
				goto case 18u;
			case 18u:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 117;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("PA: transactions NULL");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(1129f);
				BJGCPDNMHDH.mUnitBoughtState = 7;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_088a:
				PHDOCKCBJOF = true;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 125;
				}
				break;
				IL_052e:
				Singleton<EventTrackingManager>.instance.KEKPOIPDIGK("testingidsquadrankup", FKGHFOJFMBP);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1734f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 16;
				}
				break;
			}
			return true;
		}

		[SpecialName]
		private object JNKDBMNFGJJ()
		{
			return PHDOCKCBJOF;
		}

		public bool HOOHJGPHHGN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mUnitBoughtState = 1;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						LevelBehaviour current = KFCAECGLKKO.Current;
						if (current.upgradeSlots.isTutorialUnit)
						{
							current.upgradeSlots.bought = true;
							BJGCPDNMHDH.mTutorialUnit = current;
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (BJGCPDNMHDH.mTutorialUnit == null)
				{
					UnityEngine.Debug.LogError("Beanstalk Error (try = ");
				}
				goto case 1u;
			case 1u:
				if (!GuiElementSingle<LevelUpDialog>.instance.BKIGLABDGCP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (!GuiElementSingle<LevelUpDialog>.instance.PIAOCINHGJE())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				GuiElementSingle<LevelUpDialog>.instance.HCODOFNNLDL();
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_SKILLSHOTHINT_ONEHITKILL");
				PHDOCKCBJOF = new WaitForSeconds(771f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 3u:
				GuiElementSingle<TutorialDialog>.instance.DOLDLDECPIO(Localization.Localize("game-card-ico-mineyourstep-full"), Localization.Localize("Stop shooting "), 1031f, TutorialDialog.DODBDLEJOAM.BottomLeft);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].NALOPNJHPLI.transform.position, ELHGOHGPJCF: false, ENIHCPLOOAE: true, 509f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].PAKNGGNNNDO.transform.position, GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].EPHBGCBAPAN.size, GPCEHFNNCIN: false);
				goto case 4u;
			case 4u:
				if (GuiElementSingle<LevelUpDialog>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(355f);
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<ArmyScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("LostGameInRow");
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 6u;
			case 6u:
				if (!GuiScreenSingle<ArmyScreen>.instance.BKIGLABDGCP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				FKGHFOJFMBP = true;
				if (GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().PPMNNKANOEF() != BJGCPDNMHDH.mTutorialUnit)
				{
					FKGHFOJFMBP = false;
					Singleton<GuiManager>.instance.CMCCOCBIGBB();
					PHDOCKCBJOF = new WaitForSeconds(517f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				goto IL_052e;
			case 7u:
				GuiElementSingle<TutorialDialog>.instance.FJFFALBAFBD("Yes_Clicked", 21f, TutorialDialog.DODBDLEJOAM.TopRight);
				OIBJCLOPOLG = GuiScreenSingle<ArmyScreen>.instance.OOLKNBJNFJC();
				GOBCHPOLPIE = null;
				IODGHHFAHJH = Vector3.zero;
				CMIKGAOHHPH = Vector3.one;
				if (OIBJCLOPOLG != null)
				{
					foreach (ArmyUpgradeIcon item in OIBJCLOPOLG)
					{
						if (item.PPMNNKANOEF() == BJGCPDNMHDH.mTutorialUnit)
						{
							GOBCHPOLPIE = item;
							IODGHHFAHJH = item.transform.position;
							CMIKGAOHHPH = item.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(IODGHHFAHJH, ELHGOHGPJCF: false, ENIHCPLOOAE: false, 1662f);
							GuiElementSingle<TutorialClickOverlay>.instance.AJNGLEIBMHD(IODGHHFAHJH, CMIKGAOHHPH);
							break;
						}
					}
				}
				goto case 8u;
			case 8u:
				if (GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().PPMNNKANOEF() != BJGCPDNMHDH.mTutorialUnit)
				{
					if (GOBCHPOLPIE != null && GOBCHPOLPIE.transform.position != IODGHHFAHJH)
					{
						IODGHHFAHJH = GOBCHPOLPIE.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.IMOAGBADPCC(IODGHHFAHJH);
						GuiElementSingle<TutorialClickOverlay>.instance.IGNJKOKGNOI(IODGHHFAHJH, CMIKGAOHHPH);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(1253f);
				goto IL_052e;
			case 9u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("Assignment: Finish Missions Constructor, count = ");
				object[] array = new object[1];
				array[1] = Localization.Localize("bazooka_uncover_left");
				instance.PBEAOCBHFGD(aMKLKMJEMJM, Localization.LocalizeFormat("shieldDestroy", array), 1636f, TutorialDialog.DODBDLEJOAM.TopRight);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.BGPBNIJPOKM.cachedTransform.position, new Vector3(1785f, 489f, 1318f), ELHGOHGPJCF: false, ENIHCPLOOAE: false, 1309f);
				GuiElementSingle<TutorialClickOverlay>.instance.PGOLMCBEIOD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
				goto case 10u;
			}
			case 10u:
				if (GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 90;
					}
					break;
				}
				BJGCPDNMHDH.mUnitBoughtState = 8;
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_CONFIRM_SERVERDIDNOTRESPOND");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(1518f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1502f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 96;
				}
				break;
			case 11u:
				if (!GuiScreenSingle<ArmyScreen>.instance.selectedIcon.KHEOKHHDGPO().upgradeSlots.bought)
				{
					FPHGINDBIDI = false;
					TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
					string aMKLKMJEMJM2 = Localization.Localize("Lootbox");
					object[] array2 = new object[0];
					array2[0] = Localization.Localize("Particle with name: ");
					instance2.BLHPAFCOPMD(aMKLKMJEMJM2, Localization.LocalizeFormat("^[0-9]*-", array2), 1885f);
					GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.LNFLDPLGEJE.transform.position, new Vector3(514f, 700f, 1866f), ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1834f);
					GuiElementSingle<TutorialClickOverlay>.instance.GBHNBKFGCPG(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
					JGPPKCAGAGC = true;
					goto case 13u;
				}
				goto case 14u;
			case 12u:
				GuiElementSingle<TutorialDialog>.instance.PBEAOCBHFGD(Localization.Localize("NAME"), Localization.LocalizeFormat("NO DISCOUNT FOUND!!! ", Localization.Localize("Waiting too long for all playersFinish to loading")), 383f, TutorialDialog.DODBDLEJOAM.BottomLeft, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.JPJLKKJJFDB.transform.position, new Vector3(1444f, 134f, 136f), ELHGOHGPJCF: true, ENIHCPLOOAE: false, 444f);
				GuiElementSingle<TutorialClickOverlay>.instance.LECHCOBHAFP(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
				goto IL_088a;
			case 13u:
				if (!GuiScreenSingle<ArmyScreen>.instance.BDBKFBEIHNF().PPMNNKANOEF().upgradeSlots.bought)
				{
					if (JGPPKCAGAGC && GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().PPMNNKANOEF().upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.UnitDelivered)
					{
						FPHGINDBIDI = true;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
						GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(1611f);
						JGPPKCAGAGC = false;
						Singleton<GuiManager>.instance.TurnOffInputCompletly();
						PHDOCKCBJOF = new WaitForSeconds(1079f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = -29;
						}
						break;
					}
					goto IL_088a;
				}
				BJGCPDNMHDH.mUnitBoughtState = 8;
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("S", FPHGINDBIDI);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(758f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1707f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 79;
				}
				break;
			case 14u:
				BJGCPDNMHDH.mUnitBoughtState = 6;
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ.transform.position, new Vector3(532f, 1807f, 592f), ELHGOHGPJCF: false, ENIHCPLOOAE: true, 398f);
				GuiElementSingle<TutorialClickOverlay>.instance.GBHNBKFGCPG(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ);
				GuiElementSingle<TutorialClickOverlay>.instance.EOJBPKGMJIP();
				PHDOCKCBJOF = new WaitForSeconds(65f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 70;
				}
				break;
			case 15u:
			case 16u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 13;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Mega_Reward");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(758f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 17u;
			case 17u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.LHDGJFHPJNM())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 105;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.PBEAOCBHFGD(Localization.Localize("ID_COMPLETED"), Localization.Localize("shotReal"), 1535f, TutorialDialog.DODBDLEJOAM.Right);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.OMDKNOFNFBB.transform.position, ELHGOHGPJCF: false, ENIHCPLOOAE: true, 1108f);
				GuiElementSingle<TutorialClickOverlay>.instance.JGHBBJEFLEB(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.ECJHCGPGGDC);
				goto case 18u;
			case 18u:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -45;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("menu-arena-scrap-ico");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(1534f);
				BJGCPDNMHDH.mUnitBoughtState = 8;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_088a:
				PHDOCKCBJOF = true;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -68;
				}
				break;
				IL_052e:
				Singleton<EventTrackingManager>.instance.RegisterTutorialUnitSelectedEvent("com/google/android/gms/common/ConnectionResult", FKGHFOJFMBP);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(482f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 107;
				}
				break;
			}
			return true;
		}

		[SpecialName]
		private object HBKJOBOMGKB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NMGBFNNHIPN()
		{
			return PHDOCKCBJOF;
		}

		public void NFAMBMLLFGP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void CNBLDCICPLL()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public bool CCOPPEKLJOB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mUnitBoughtState = 0;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						LevelBehaviour current = KFCAECGLKKO.Current;
						if (current.upgradeSlots.isTutorialUnit)
						{
							current.upgradeSlots.bought = false;
							BJGCPDNMHDH.mTutorialUnit = current;
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (BJGCPDNMHDH.mTutorialUnit == null)
				{
					UnityEngine.Debug.LogError("titleFontSize");
				}
				goto case 1u;
			case 1u:
				if (!GuiElementSingle<LevelUpDialog>.instance.BKIGLABDGCP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (!GuiElementSingle<LevelUpDialog>.instance.CHGDDHJJMME())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				GuiElementSingle<LevelUpDialog>.instance.HCODOFNNLDL();
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Show Waiting Dialog ");
				PHDOCKCBJOF = new WaitForSeconds(857f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 3u:
				GuiElementSingle<TutorialDialog>.instance.PBEAOCBHFGD(Localization.Localize("attrValue12"), Localization.Localize("ID_CONFIRM_SQUADISFULL"), 1248f, TutorialDialog.DODBDLEJOAM.BottomLeft);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].NALOPNJHPLI.transform.position, ELHGOHGPJCF: false, ENIHCPLOOAE: false, 1140f);
				GuiElementSingle<TutorialClickOverlay>.instance.EEMMKEMADFC(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[1].PAKNGGNNNDO.transform.position, GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[1].EPHBGCBAPAN.size, GPCEHFNNCIN: false);
				goto case 4u;
			case 4u:
				if (GuiElementSingle<LevelUpDialog>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(152f);
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<ArmyScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Beanstalk: Send Log. Wait for Response with Log Id....");
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 6u;
			case 6u:
				if (!GuiScreenSingle<ArmyScreen>.instance.MHAIBHBGBOO())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				FKGHFOJFMBP = false;
				if (GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().BNPKCKFMBLG() != BJGCPDNMHDH.mTutorialUnit)
				{
					FKGHFOJFMBP = true;
					Singleton<GuiManager>.instance.TurnOffInputCompletly();
					PHDOCKCBJOF = new WaitForSeconds(780f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_052e;
			case 7u:
				GuiElementSingle<TutorialDialog>.instance.FJFFALBAFBD("ID_CONFIRM_SQUADFULL_TEXT", 652f, TutorialDialog.DODBDLEJOAM.Left);
				OIBJCLOPOLG = GuiScreenSingle<ArmyScreen>.instance.MAPKDMOOFMM();
				GOBCHPOLPIE = null;
				IODGHHFAHJH = Vector3.zero;
				CMIKGAOHHPH = Vector3.one;
				if (OIBJCLOPOLG != null)
				{
					foreach (ArmyUpgradeIcon item in OIBJCLOPOLG)
					{
						if (item.levelBehaviour == BJGCPDNMHDH.mTutorialUnit)
						{
							GOBCHPOLPIE = item;
							IODGHHFAHJH = item.transform.position;
							CMIKGAOHHPH = item.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(IODGHHFAHJH, ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1720f);
							GuiElementSingle<TutorialClickOverlay>.instance.NNPKOKCJMHL(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
							break;
						}
					}
				}
				goto case 8u;
			case 8u:
				if (GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().KHEOKHHDGPO() != BJGCPDNMHDH.mTutorialUnit)
				{
					if (GOBCHPOLPIE != null && GOBCHPOLPIE.transform.position != IODGHHFAHJH)
					{
						IODGHHFAHJH = GOBCHPOLPIE.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateTapAnimation(IODGHHFAHJH);
						GuiElementSingle<TutorialClickOverlay>.instance.IGNJKOKGNOI(IODGHHFAHJH, CMIKGAOHHPH);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(586f);
				goto IL_052e;
			case 9u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("/StreamingAssets");
				object[] array = new object[0];
				array[1] = Localization.Localize("ID_UPDATINGACCOUNT");
				instance.ShowMenuTutorial(aMKLKMJEMJM, Localization.LocalizeFormat("ID_ENDSINTIME", array), 523f, TutorialDialog.DODBDLEJOAM.TopRight, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.BGPBNIJPOKM.cachedTransform.position, new Vector3(982f, 1570f, 638f), ELHGOHGPJCF: true, ENIHCPLOOAE: true, 645f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL);
				goto case 10u;
			}
			case 10u:
				if (GuiScreenSingle<ArmyScreen>.instance.selectedIcon.BNPKCKFMBLG().upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 16;
					}
					break;
				}
				BJGCPDNMHDH.mUnitBoughtState = 1;
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_CONFIRM_ERROR");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(1159f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1400f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -119;
				}
				break;
			case 11u:
				if (!GuiScreenSingle<ArmyScreen>.instance.selectedIcon.AIHMCHBCJDO().upgradeSlots.bought)
				{
					FPHGINDBIDI = true;
					TutorialDialog instance3 = GuiElementSingle<TutorialDialog>.instance;
					string aMKLKMJEMJM3 = Localization.Localize("last {0} and can now {1} ({2})\n");
					object[] array3 = new object[0];
					array3[1] = Localization.Localize("InstantBattleEnded: Money Pack Deadline = ");
					instance3.DOLDLDECPIO(aMKLKMJEMJM3, Localization.LocalizeFormat("CONFIRM", array3), 302f);
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.LNFLDPLGEJE.transform.position, new Vector3(1598f, 564f, 581f), ELHGOHGPJCF: false, ENIHCPLOOAE: false, 1038f);
					GuiElementSingle<TutorialClickOverlay>.instance.GBHNBKFGCPG(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL);
					JGPPKCAGAGC = false;
					goto case 13u;
				}
				goto case 14u;
			case 12u:
			{
				TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM2 = Localization.Localize("AssignmentsIds");
				object[] array2 = new object[1];
				array2[1] = Localization.Localize("IsGold");
				instance2.BLHPAFCOPMD(aMKLKMJEMJM2, Localization.LocalizeFormat("-", array2), 15f, TutorialDialog.DODBDLEJOAM.BottomLeft, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.JPJLKKJJFDB.transform.position, new Vector3(1142f, 858f, 1851f), ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1019f);
				GuiElementSingle<TutorialClickOverlay>.instance.LPKOHAKMOOC(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
				goto IL_088a;
			}
			case 13u:
				if (!GuiScreenSingle<ArmyScreen>.instance.selectedIcon.PPMNNKANOEF().upgradeSlots.bought)
				{
					if (JGPPKCAGAGC && GuiScreenSingle<ArmyScreen>.instance.BDBKFBEIHNF().AIHMCHBCJDO().upgradeSlots.unitState == (UpgradeSlots.JLANLLEABDC)7)
					{
						FPHGINDBIDI = false;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
						GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(1008f);
						JGPPKCAGAGC = true;
						Singleton<GuiManager>.instance.CMCCOCBIGBB();
						PHDOCKCBJOF = new WaitForSeconds(1607f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = -56;
						}
						break;
					}
					goto IL_088a;
				}
				BJGCPDNMHDH.mUnitBoughtState = 0;
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("ID_NO", FPHGINDBIDI);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(1127f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1630f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -48;
				}
				break;
			case 14u:
				BJGCPDNMHDH.mUnitBoughtState = 8;
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ.transform.position, new Vector3(77f, 290f, 589f), ELHGOHGPJCF: false, ENIHCPLOOAE: false, 189f);
				GuiElementSingle<TutorialClickOverlay>.instance.GBHNBKFGCPG(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ);
				GuiElementSingle<TutorialClickOverlay>.instance.EDPNLNIPCGJ();
				PHDOCKCBJOF = new WaitForSeconds(19f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 44;
				}
				break;
			case 15u:
			case 16u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -124;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("bazooka_run");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(421f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 17u;
			case 17u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -70;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("WeaponTutorial"), Localization.Localize("ID_NOTENOUGHWARBUCKS"), 292f, TutorialDialog.DODBDLEJOAM.BottomLeft, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.OMDKNOFNFBB.transform.position, ELHGOHGPJCF: true, ENIHCPLOOAE: true, 1453f);
				GuiElementSingle<TutorialClickOverlay>.instance.CAIGHMDPBDI(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.ECJHCGPGGDC, GPCEHFNNCIN: false);
				goto case 18u;
			case 18u:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -103;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("offerType");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(1408f);
				BJGCPDNMHDH.mUnitBoughtState = 0;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_088a:
				PHDOCKCBJOF = true;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 20;
				}
				break;
				IL_052e:
				Singleton<EventTrackingManager>.instance.RegisterTutorialUnitSelectedEvent(", response: ", FKGHFOJFMBP);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(67f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -123;
				}
				break;
			}
			return true;
		}

		public void GCEMCPODLNM()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MFNFCFAJKCM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JMKGAJNOLEM()
		{
			return PHDOCKCBJOF;
		}

		public void EJNCMFMOBAJ()
		{
			throw new NotSupportedException();
		}

		public void EPIKLCFKOBJ()
		{
			throw new NotSupportedException();
		}

		public void KOEEOJGJNAO()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool MKLIDMNLNPN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mUnitBoughtState = 1;
				KFCAECGLKKO = LevelManager.instance.behaviours.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						LevelBehaviour current = KFCAECGLKKO.Current;
						if (current.upgradeSlots.isTutorialUnit)
						{
							current.upgradeSlots.bought = true;
							BJGCPDNMHDH.mTutorialUnit = current;
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (BJGCPDNMHDH.mTutorialUnit == null)
				{
					UnityEngine.Debug.LogError("Xp");
				}
				goto case 1u;
			case 1u:
				if (!GuiElementSingle<LevelUpDialog>.instance.MHAIBHBGBOO())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (!GuiElementSingle<LevelUpDialog>.instance.LGHOENABFLJ())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				GuiElementSingle<LevelUpDialog>.instance.HCODOFNNLDL();
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_CONFIRM_FORFEIT_TEXT");
				PHDOCKCBJOF = new WaitForSeconds(1372f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 3u:
				GuiElementSingle<TutorialDialog>.instance.BLHPAFCOPMD(Localization.Localize("ID_OPPONENTREFUSEDTHEREMATCH"), Localization.Localize("veteranpack"), 592f, TutorialDialog.DODBDLEJOAM.Top);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].NALOPNJHPLI.transform.position, ELHGOHGPJCF: false, ENIHCPLOOAE: false, 1319f);
				GuiElementSingle<TutorialClickOverlay>.instance.EEMMKEMADFC(GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].PAKNGGNNNDO.transform.position, GuiElementSingle<LevelUpDialog>.instance.PPFFOOLKNPI[0].EPHBGCBAPAN.size, GPCEHFNNCIN: false);
				goto case 4u;
			case 4u:
				if (GuiElementSingle<LevelUpDialog>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(43f);
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<ArmyScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_UNITTYPE2-HUD");
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 6u;
			case 6u:
				if (!GuiScreenSingle<ArmyScreen>.instance.BJNBLINDAED())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				FKGHFOJFMBP = true;
				if (GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().KHEOKHHDGPO() != BJGCPDNMHDH.mTutorialUnit)
				{
					FKGHFOJFMBP = true;
					Singleton<GuiManager>.instance.TurnOffInputCompletly();
					PHDOCKCBJOF = new WaitForSeconds(1333f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				goto IL_052e;
			case 7u:
				GuiElementSingle<TutorialDialog>.instance.GKODNFIOLPB("1", 1134f, TutorialDialog.DODBDLEJOAM.Right);
				OIBJCLOPOLG = GuiScreenSingle<ArmyScreen>.instance.OOLKNBJNFJC();
				GOBCHPOLPIE = null;
				IODGHHFAHJH = Vector3.zero;
				CMIKGAOHHPH = Vector3.one;
				if (OIBJCLOPOLG != null)
				{
					foreach (ArmyUpgradeIcon item in OIBJCLOPOLG)
					{
						if (item.KHEOKHHDGPO() == BJGCPDNMHDH.mTutorialUnit)
						{
							GOBCHPOLPIE = item;
							IODGHHFAHJH = item.transform.position;
							CMIKGAOHHPH = item.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(IODGHHFAHJH, ELHGOHGPJCF: true, ENIHCPLOOAE: false, 604f);
							GuiElementSingle<TutorialClickOverlay>.instance.EEMMKEMADFC(IODGHHFAHJH, CMIKGAOHHPH);
							break;
						}
					}
				}
				goto case 8u;
			case 8u:
				if (GuiScreenSingle<ArmyScreen>.instance.selectedIcon.levelBehaviour != BJGCPDNMHDH.mTutorialUnit)
				{
					if (GOBCHPOLPIE != null && GOBCHPOLPIE.transform.position != IODGHHFAHJH)
					{
						IODGHHFAHJH = GOBCHPOLPIE.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.OOIJFHGCCNH(IODGHHFAHJH);
						GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(IODGHHFAHJH, CMIKGAOHHPH);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(896f);
				goto IL_052e;
			case 9u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("AdFailedToDisplay()");
				object[] array = new object[0];
				array[1] = Localization.Localize("Unfreeze ");
				instance.BLHPAFCOPMD(aMKLKMJEMJM, Localization.LocalizeFormat("BANDS", array), 874f, TutorialDialog.DODBDLEJOAM.BottomLeft);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.BGPBNIJPOKM.cachedTransform.position, new Vector3(1512f, 157f, 1961f), ELHGOHGPJCF: true, ENIHCPLOOAE: false, 21f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
				goto case 10u;
			}
			case 10u:
				if (GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().PPMNNKANOEF().upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -41;
					}
					break;
				}
				BJGCPDNMHDH.mUnitBoughtState = 7;
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("GLM: RegisterOrLogin -  2");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(983f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(412f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 87;
				}
				break;
			case 11u:
				if (!GuiScreenSingle<ArmyScreen>.instance.BDBKFBEIHNF().BNPKCKFMBLG().upgradeSlots.bought)
				{
					FPHGINDBIDI = false;
					GuiElementSingle<TutorialDialog>.instance.BLHPAFCOPMD(Localization.Localize("Weapons/"), Localization.LocalizeFormat("country-austria", Localization.Localize("Sniper_Tutorial_Played")), 581f, TutorialDialog.DODBDLEJOAM.BottomRight, NHEJDPIIOJG: false);
					GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.LNFLDPLGEJE.transform.position, new Vector3(1062f, 1806f, 1885f), ELHGOHGPJCF: true, ENIHCPLOOAE: true, 231f);
					GuiElementSingle<TutorialClickOverlay>.instance.PGOLMCBEIOD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL);
					JGPPKCAGAGC = false;
					goto case 13u;
				}
				goto case 14u;
			case 12u:
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_WATCHVIDEO"), Localization.LocalizeFormat("batchSizeMin", Localization.Localize("ID_ASSIGNMENTSSHORT")), 896f, TutorialDialog.DODBDLEJOAM.BottomLeft, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.JPJLKKJJFDB.transform.position, new Vector3(1974f, 76f, 979f), ELHGOHGPJCF: true, ENIHCPLOOAE: false, 55f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.KEFLEFIPLNJ.EPFODCCNGDL, GPCEHFNNCIN: false);
				goto IL_088a;
			case 13u:
				if (!GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().KHEOKHHDGPO().upgradeSlots.bought)
				{
					if (JGPPKCAGAGC && GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().AIHMCHBCJDO().upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.UnitDelivering)
					{
						FPHGINDBIDI = true;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
						GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(1108f);
						JGPPKCAGAGC = true;
						Singleton<GuiManager>.instance.TurnOffInputCompletly();
						PHDOCKCBJOF = new WaitForSeconds(224f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 2;
						}
						break;
					}
					goto IL_088a;
				}
				BJGCPDNMHDH.mUnitBoughtState = 3;
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("#Game Results# Debug Log:\n", FPHGINDBIDI);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(510f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(852f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 122;
				}
				break;
			case 14u:
				BJGCPDNMHDH.mUnitBoughtState = 8;
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ.transform.position, new Vector3(1005f, 468f, 814f), ELHGOHGPJCF: false, ENIHCPLOOAE: true, 1250f);
				GuiElementSingle<TutorialClickOverlay>.instance.LECHCOBHAFP(GuiScreenSingle<ArmyScreen>.instance.FNOFLJEOHGJ, GPCEHFNNCIN: false);
				GuiElementSingle<TutorialClickOverlay>.instance.EMEBKHJECFA();
				PHDOCKCBJOF = new WaitForSeconds(1065f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -11;
				}
				break;
			case 15u:
			case 16u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -31;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_ARENARULES_NOSHIELDS");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(435f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 17u;
			case 17u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.AFOFDNJOJHG())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 55;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.DOLDLDECPIO(Localization.Localize("VALUE PACK for $"), Localization.Localize("Total_Sessions"), 1841f, TutorialDialog.DODBDLEJOAM.Right, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.OMDKNOFNFBB.transform.position, ELHGOHGPJCF: false, ENIHCPLOOAE: false, 1375f);
				GuiElementSingle<TutorialClickOverlay>.instance.CAIGHMDPBDI(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.ECJHCGPGGDC, GPCEHFNNCIN: false);
				goto case 18u;
			case 18u:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -123;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Buy_Units");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(48f);
				BJGCPDNMHDH.mUnitBoughtState = 8;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_088a:
				PHDOCKCBJOF = false;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -71;
				}
				break;
				IL_052e:
				Singleton<EventTrackingManager>.instance.KEKPOIPDIGK("OnDeathRPC", FKGHFOJFMBP);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1859f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -52;
				}
				break;
			}
			return true;
		}

		public void IGBHHLFACKO()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object IIJAMNPBACH()
		{
			return PHDOCKCBJOF;
		}

		public void IBDAHMOEBCM()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BEGHOADNMJF()
		{
			return PHDOCKCBJOF;
		}
	}

	private static TutorialManagerStage2 mInstance;

	public const string id = "Stage2";

	private bool mAssalterKilled;

	private int mAssaltersKilledNotGrenade;

	private AIObject mFirstParatrooper;

	private List<AIObject> mParatroopers = new List<AIObject>();

	private bool mGameStarted;

	private Vector3 mGrenadeArea;

	private Vector3 mParatrooperPosition;

	private int mSniperKilled;

	private int mSniperRifleShots;

	private LevelBehaviour mTutorialUnit;

	private int mUnitBoughtState;

	public static TutorialManagerStage2 instance
	{
		get
		{
			mInstance = mInstance ?? UnityEngine.Object.FindObjectOfType<TutorialManagerStage2>();
			return mInstance;
		}
	}

	public override bool autoDeployEnabled => true;

	protected override void Awake()
	{
		base.Awake();
		mInstance = this;
		Singleton<GameController>.instance.GameStarted += OnGameStarted;
		Singleton<GameController>.instance.GameEnded += OnGameEnded;
	}

	private void OnGameStarted()
	{
		mGameStarted = true;
		if (base.isTutorialRunning)
		{
			Singleton<GameController>.instance.opponent.FOCIOKMPCAG.GPLNJOPPKIM.Enable();
			Singleton<GameController>.instance.opponent.FOCIOKMPCAG.GPLNJOPPKIM.FadeIn(0.1f);
		}
	}

	private void OnGameEnded(GameController.HKGHCIEPGEL obj)
	{
		if (base.isTutorialRunning)
		{
			GameLoginManager.instance.TryPresetStartingCurrency();
			Weapon.OnShotFired -= WeaponOnOnShotFired;
			StopAllCoroutines();
			if (Singleton<GameController>.instance.MNMLNIMFMJP != GameController.HKGHCIEPGEL.Forfeit)
			{
				Singleton<EventTrackingManager>.instance.RegisterTutorialGameEnded(2, "210 GAME END");
				LevelManager.instance.SetLevelUpProgressForTutorial(3, 0f, levelUp: true);
				Singleton<Wallet>.instance.SetRewardForTutorial(1000, 2);
				StartCoroutine(RadicalRoutine.Run(Menu()));
			}
			GuiElementSingle<TutorialDialog>.instance.HideDialog();
			Singleton<TutorialProgressShower>.instance.Disable();
			UnityEngine.Debug.Log("*****   Bootcamp 2/3 Ended   *****");
		}
	}

	[DebuggerHidden]
	private IEnumerator Menu()
	{
		OJPPMELONDL oJPPMELONDL = new OJPPMELONDL();
		oJPPMELONDL.BJGCPDNMHDH = this;
		return oJPPMELONDL;
	}

	public override void StartTutorial(bool isContinue)
	{
		base.StartTutorial(isContinue);
		PrepareDataForTutorial();
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("201 LOADING MAP");
		SetPlayerDefaultWeapons(enableRifle: true, enableSniper: true);
		PlayerController.OGMBJPKOPCB.weaponInventory.HKGLMFFAHFN = false;
		PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[2].weapon.ammoLeft = 5;
		PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[2].weapon.ammoLeftInClip = 5;
		PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[2].weapon.JMDLKIAKOIE = 1f;
		PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
		if (isContinue)
		{
			data.gold = (int)Singleton<Wallet>.instance.gold;
			data.wb = (int)Singleton<Wallet>.instance.warBucks;
		}
		else if (data.gold != 0 && data.wb != 0)
		{
			Singleton<Wallet>.instance.SetTutorialCurrency(data.wb, data.gold);
		}
		data.started = true;
		Save();
		mSniperRifleShots = 0;
		Weapon.OnShotFired += WeaponOnOnShotFired;
		Singleton<TutorialProgressShower>.instance.Disable();
		StartCoroutine(RadicalRoutine.Run(WeaponGrenadeTutorial()));
		UnityEngine.Debug.Log("*****   Bootcamp 2/3 Started   *****");
	}

	private void PrepareDataForTutorial()
	{
		LevelManager.instance.SetLevelUpProgressForTutorial(2, 0f, levelUp: false);
		PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.BCCDDJMPBLL = 2;
		PlayerController.GetEnemyOf(PlayerController.OGMBJPKOPCB.fraction).EHHHBEMKGOE.BCCDDJMPBLL = 2;
		GuiElementSingle<MenuHeader>.instance.InitGUIValues();
	}

	private void ParachuteKilled(NKMKCCDCHCL enemy, DestroyableObject.CJLNCMMNPBM damage)
	{
		if (PlayerController.OGMBJPKOPCB.weaponInventory.currentWeapon == PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[1])
		{
			mSniperKilled++;
		}
		enemy.Killed -= ParachuteKilled;
	}

	[DebuggerHidden]
	private IEnumerator UpdateHoldSniperShoot()
	{
		EBHCHMCIKFO eBHCHMCIKFO = new EBHCHMCIKFO();
		eBHCHMCIKFO.BJGCPDNMHDH = this;
		return eBHCHMCIKFO;
	}

	[DebuggerHidden]
	private IEnumerator SpawnParatroopers(int count = 1)
	{
		MGPEJCIIBGP mGPEJCIIBGP = new MGPEJCIIBGP();
		mGPEJCIIBGP.PDMGPGEHLNM = count;
		mGPEJCIIBGP.BJGCPDNMHDH = this;
		return mGPEJCIIBGP;
	}

	[DebuggerHidden]
	private IEnumerator SniperExplain()
	{
		CMLLMGJMFKA cMLLMGJMFKA = new CMLLMGJMFKA();
		cMLLMGJMFKA.BJGCPDNMHDH = this;
		return cMLLMGJMFKA;
	}

	private void WeaponOnOnShotFired(Weapon weapon, Vector3 vector3)
	{
		if (weapon == PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[1].weapon)
		{
			mSniperRifleShots++;
		}
	}

	[DebuggerHidden]
	private IEnumerator WeaponGrenadeTutorial()
	{
		EEBKAGLDPHL eEBKAGLDPHL = new EEBKAGLDPHL();
		eEBKAGLDPHL.BJGCPDNMHDH = this;
		return eEBKAGLDPHL;
	}

	[DebuggerHidden]
	private IEnumerator Overtime()
	{
		CCBNMMIKEHF cCBNMMIKEHF = new CCBNMMIKEHF();
		cCBNMMIKEHF.BJGCPDNMHDH = this;
		return cCBNMMIKEHF;
	}

	[DebuggerHidden]
	private IEnumerator Welcome()
	{
		return new GHIEJKBFMGP();
	}

	[DebuggerHidden]
	private IEnumerator CheckAmmo()
	{
		return new LLMBOEIMOHG();
	}

	private void AssaulterKilled(NKMKCCDCHCL gameMainEntity, DestroyableObject.CJLNCMMNPBM damageInfo)
	{
		if (PlayerController.OGMBJPKOPCB.weaponInventory.currentWeapon == PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[2])
		{
			mAssalterKilled = true;
		}
		else
		{
			mAssaltersKilledNotGrenade++;
		}
	}

	[DebuggerHidden]
	private IEnumerator UpdateSwipeGrenadeThrow()
	{
		CNMJNKEDIDL cNMJNKEDIDL = new CNMJNKEDIDL();
		cNMJNKEDIDL.BJGCPDNMHDH = this;
		return cNMJNKEDIDL;
	}

	[DebuggerHidden]
	private IEnumerator ThrowGrenade()
	{
		PGEEEBOLBKB pGEEEBOLBKB = new PGEEEBOLBKB();
		pGEEEBOLBKB.BJGCPDNMHDH = this;
		return pGEEEBOLBKB;
	}

	public void CheckAfterDownload()
	{
		if (mUnitBoughtState > 0 && base.isTutorialRunning)
		{
			LevelManager.instance.CheckCurrentLevelForTutorial(3);
			if (mUnitBoughtState < 3)
			{
				mTutorialUnit.upgradeSlots.bought = false;
			}
		}
	}

	[DebuggerHidden]
	private IEnumerator BuyTutorialUnit()
	{
		MHHGEIJMPPB mHHGEIJMPPB = new MHHGEIJMPPB();
		mHHGEIJMPPB.BJGCPDNMHDH = this;
		return mHHGEIJMPPB;
	}

	public void EquipTutorialUnitAfterSkipTutorial()
	{
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			if (behaviour.upgradeSlots.isTutorialUnit)
			{
				behaviour.upgradeSlots.bought = true;
				behaviour.upgradeSlots.equipped = true;
				break;
			}
		}
	}
}
