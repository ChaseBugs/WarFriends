using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

[ExecuteInEditMode]
public abstract class UpgradeSlots : Core_BaseScript
{
	public enum JLANLLEABDC
	{
		Locked,
		NotBuyed,
		UnitDelivering,
		UnitDelivered,
		Active,
		Delivering,
		Delivered
	}

	public struct UnitUpgrades
	{
		public bool isElite;

		public bool isVeteran;

		public bool isSpecial;

		public int slotUpgradeindex;

		public int slotUpgradeIndexElite;

		public int slotUpgradeIndexSpecial;

		public float scaleDamage;

		public float scaleHp;

		public UnitUpgrades(float scale)
		{
			scaleDamage = scale;
			scaleHp = scale;
			slotUpgradeIndexSpecial = 0;
			slotUpgradeindex = 0;
			slotUpgradeIndexElite = 0;
			isSpecial = false;
			isElite = false;
			isVeteran = false;
		}

		public static UnitUpgrades GetPreviewUpgrades(LevelBehaviour behavior, float scale = 1f)
		{
			UnitUpgrades result = default(UnitUpgrades);
			bool isUnlocked = behavior.upgradeSlots.upgradeSlotElite.isUnlocked;
			result.isElite = (behavior.upgradeSlots.upgradeSlotElite.isBought && !DebugSettings.instance.nonEliteUnits) || (showElite && isUnlocked);
			result.isSpecial = behavior.upgradeSlots.upgradeSlotSpecial.isBought;
			if (behavior.upgradeSlots.bought)
			{
				if (isUnlocked && showEliteUnitWhenBought && !DebugSettings.instance.nonEliteUnits)
				{
					result.isElite = true;
				}
				result.slotUpgradeindex = ((!result.isElite || behavior.upgradeSlots.upgradeSlotElite.isBought) ? behavior.upgradeSlots.upgradeSlot.boughtIndexAbsolute : behavior.upgradeSlots.upgradeSlot.maxIndexInExcel);
				result.slotUpgradeIndexElite = behavior.upgradeSlots.upgradeSlotElite.boughtIndexAbsolute;
				result.slotUpgradeIndexSpecial = behavior.upgradeSlots.upgradeSlotSpecial.boughtIndexAbsolute;
			}
			else
			{
				result.slotUpgradeindex = (showMaxLevelWhenNotBought ? behavior.upgradeSlots.upgradeSlot.maxIndexInExcel : 0);
				result.slotUpgradeIndexElite = (showMaxLevelWhenNotBought ? behavior.upgradeSlots.upgradeSlotElite.maxIndexInExcel : 0);
				result.slotUpgradeIndexSpecial = (showMaxLevelWhenNotBought ? behavior.upgradeSlots.upgradeSlotSpecial.maxIndexInExcel : 0);
			}
			result.scaleDamage = scale;
			result.scaleHp = scale;
			return result;
		}

		public override string ToString()
		{
			return string.Format("slotUpgradeindex: {0}, slotUpgradeIndexElite: {0}, slotUpgradeIndexSpecial {1},  isSpecial {2},  scaleDamage {3},  scaleHP {4}", slotUpgradeindex, slotUpgradeIndexElite, slotUpgradeIndexSpecial, isSpecial, scaleDamage, scaleHp);
		}
	}

	[Serializable]
	public class VisualSlotMesh
	{
		public MeshRenderer part;

		public MeshRenderer partRed;

		public int visualSlotId;
	}

	private sealed class JNBLKNMGMBD : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal int JMEGHFOKLBF;

		internal List<TechnologyVisualDefinition> EDNLBEDPMCM;

		internal TechnologyVisualDefinition HGMAPLKJONO;

		internal bool EFBPOCHCGPB;

		internal List<TechnologyVisualDefinition>.Enumerator KFCAECGLKKO;

		internal UpgradeSlots BJGCPDNMHDH;

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
		private object BBDOFDBCILK()
		{
			return PHDOCKCBJOF;
		}

		public void HGCHEPGNHNP()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BJDOHADMIEB()
		{
			return PHDOCKCBJOF;
		}

		public bool DIFNNJALIPB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				HGMAPLKJONO = BJGCPDNMHDH.GetTechnologyVisualDefinition(JMEGHFOKLBF, EDNLBEDPMCM);
				if (EFBPOCHCGPB && HGMAPLKJONO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HGMAPLKJONO.FFGDLJEMDNG());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				KFCAECGLKKO = EDNLBEDPMCM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TechnologyVisualDefinition current = KFCAECGLKKO.Current;
						if (current != HGMAPLKJONO)
						{
							current.BHINPFEIIJG();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object INHIPKJFGDI()
		{
			return PHDOCKCBJOF;
		}

		public void MAKKCANEHIB()
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
				HGMAPLKJONO = BJGCPDNMHDH.GetTechnologyVisualDefinition(JMEGHFOKLBF, EDNLBEDPMCM);
				if (EFBPOCHCGPB && HGMAPLKJONO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HGMAPLKJONO.JMJIGNKHEKL());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				KFCAECGLKKO = EDNLBEDPMCM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TechnologyVisualDefinition current = KFCAECGLKKO.Current;
						if (current != HGMAPLKJONO)
						{
							current.BLEGJDCNAAJ();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[DebuggerHidden]
		public JNBLKNMGMBD()
		{
		}

		public bool LPMIKEPIMCM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				HGMAPLKJONO = BJGCPDNMHDH.GetTechnologyVisualDefinition(JMEGHFOKLBF, EDNLBEDPMCM);
				if (EFBPOCHCGPB && HGMAPLKJONO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HGMAPLKJONO.JMJIGNKHEKL());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				KFCAECGLKKO = EDNLBEDPMCM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TechnologyVisualDefinition current = KFCAECGLKKO.Current;
						if (current != HGMAPLKJONO)
						{
							current.LLGPADPJPIF();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object FGFLGJECNLH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JNKDBMNFGJJ()
		{
			return PHDOCKCBJOF;
		}

		public void NFLHLMKKJMO()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BMGHJKFMKJE()
		{
			return PHDOCKCBJOF;
		}

		public void MNFJGIMMBLE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IIJAMNPBACH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MOOGINPIELE()
		{
			return PHDOCKCBJOF;
		}

		public void GDJMNEPLJNE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MPHILJJDNIO()
		{
			return PHDOCKCBJOF;
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
				HGMAPLKJONO = BJGCPDNMHDH.GetTechnologyVisualDefinition(JMEGHFOKLBF, EDNLBEDPMCM);
				if (EFBPOCHCGPB && HGMAPLKJONO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HGMAPLKJONO.CBKMNCJMJIH());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				KFCAECGLKKO = EDNLBEDPMCM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TechnologyVisualDefinition current = KFCAECGLKKO.Current;
						if (current != HGMAPLKJONO)
						{
							current.LLGPADPJPIF();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object HNBOIMNNPOH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AAAOCACGKIP()
		{
			return PHDOCKCBJOF;
		}

		public void JANIKOFKDCH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object KBPOAPCEPBN()
		{
			return PHDOCKCBJOF;
		}

		public void KKCNPIPOCKK()
		{
			throw new NotSupportedException();
		}

		public void MIFJOIIKFEB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void HPJKDIGCCCE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void HANDHJHGLAP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object IHAOBCEALPD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GENJNMACGLP()
		{
			return PHDOCKCBJOF;
		}

		public void BGMDCMOCLBN()
		{
			throw new NotSupportedException();
		}

		public void JKOCLGOOBEK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void LHADJAFHDDC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void JMANMKKCDMM()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object LCCOIHCHGFM()
		{
			return PHDOCKCBJOF;
		}

		public void PMPGBMCHGPE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void FLFOEIMCFBL()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void GOCCDFALOHI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void KFOFFCGINMO()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object LDBICDEEENB()
		{
			return PHDOCKCBJOF;
		}

		public void JKBIMBFGGCO()
		{
			throw new NotSupportedException();
		}

		public void HLJMNBBDJGE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void IBDAHMOEBCM()
		{
			throw new NotSupportedException();
		}

		public void HKHANLKODIB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object PGMPMBFDAAC()
		{
			return PHDOCKCBJOF;
		}

		public void ELMJLOBAMKH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void IGNIJGAPJOP()
		{
			throw new NotSupportedException();
		}

		public void IKGBMDKKAPA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void PDKPELBIAON()
		{
			throw new NotSupportedException();
		}

		public void OCBFBEMDMMJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void ADLICCCIEGG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool IGOKEIDOCKB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				HGMAPLKJONO = BJGCPDNMHDH.GetTechnologyVisualDefinition(JMEGHFOKLBF, EDNLBEDPMCM);
				if (EFBPOCHCGPB && HGMAPLKJONO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HGMAPLKJONO.BCGOFHPCKAA());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				KFCAECGLKKO = EDNLBEDPMCM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TechnologyVisualDefinition current = KFCAECGLKKO.Current;
						if (current != HGMAPLKJONO)
						{
							current.BLEGJDCNAAJ();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object IJFPHIKFJFB()
		{
			return PHDOCKCBJOF;
		}

		public void GGMKKIDFJOH()
		{
			throw new NotSupportedException();
		}

		public void GBABLFGEIMF()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object EMNOCMFCHJN()
		{
			return PHDOCKCBJOF;
		}

		public bool DAKMHLEGICB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				HGMAPLKJONO = BJGCPDNMHDH.GetTechnologyVisualDefinition(JMEGHFOKLBF, EDNLBEDPMCM);
				if (EFBPOCHCGPB && HGMAPLKJONO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HGMAPLKJONO.FFGDLJEMDNG());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				KFCAECGLKKO = EDNLBEDPMCM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TechnologyVisualDefinition current = KFCAECGLKKO.Current;
						if (current != HGMAPLKJONO)
						{
							current.BLEGJDCNAAJ();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object FCMAGGLJCMG()
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
				HGMAPLKJONO = BJGCPDNMHDH.GetTechnologyVisualDefinition(JMEGHFOKLBF, EDNLBEDPMCM);
				if (EFBPOCHCGPB && HGMAPLKJONO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HGMAPLKJONO.BCGOFHPCKAA());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				KFCAECGLKKO = EDNLBEDPMCM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TechnologyVisualDefinition current = KFCAECGLKKO.Current;
						if (current != HGMAPLKJONO)
						{
							current.BLEGJDCNAAJ();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public bool KHNDCDGBFJH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				HGMAPLKJONO = BJGCPDNMHDH.GetTechnologyVisualDefinition(JMEGHFOKLBF, EDNLBEDPMCM);
				if (EFBPOCHCGPB && HGMAPLKJONO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HGMAPLKJONO.CBKMNCJMJIH());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				KFCAECGLKKO = EDNLBEDPMCM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TechnologyVisualDefinition current = KFCAECGLKKO.Current;
						if (current != HGMAPLKJONO)
						{
							current.MIHNPIJCIKK();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void GOGEDHILBIA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool EBLHEEKHANA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				HGMAPLKJONO = BJGCPDNMHDH.GetTechnologyVisualDefinition(JMEGHFOKLBF, EDNLBEDPMCM);
				if (EFBPOCHCGPB && HGMAPLKJONO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HGMAPLKJONO.CBKMNCJMJIH());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				KFCAECGLKKO = EDNLBEDPMCM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TechnologyVisualDefinition current = KFCAECGLKKO.Current;
						if (current != HGMAPLKJONO)
						{
							current.BHINPFEIIJG();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public bool NIGJJBALHDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				HGMAPLKJONO = BJGCPDNMHDH.GetTechnologyVisualDefinition(JMEGHFOKLBF, EDNLBEDPMCM);
				if (EFBPOCHCGPB && HGMAPLKJONO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HGMAPLKJONO.JMJIGNKHEKL());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				KFCAECGLKKO = EDNLBEDPMCM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TechnologyVisualDefinition current = KFCAECGLKKO.Current;
						if (current != HGMAPLKJONO)
						{
							current.EIFNJBHKBOM();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object HGMMDPIGEGN()
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
				HGMAPLKJONO = BJGCPDNMHDH.GetTechnologyVisualDefinition(JMEGHFOKLBF, EDNLBEDPMCM);
				if (EFBPOCHCGPB && HGMAPLKJONO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HGMAPLKJONO.CBKMNCJMJIH());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				KFCAECGLKKO = EDNLBEDPMCM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TechnologyVisualDefinition current = KFCAECGLKKO.Current;
						if (current != HGMAPLKJONO)
						{
							current.LLGPADPJPIF();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void CDDFJOEEFID()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object ANBCMDOAJCM()
		{
			return PHDOCKCBJOF;
		}

		public void GBGMIJNBLNH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object IAMNDODCIEB()
		{
			return PHDOCKCBJOF;
		}

		public void HMBLLDJFIJG()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object ONADHLDNKKB()
		{
			return PHDOCKCBJOF;
		}

		public void DLIBOPAMHAN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object KKKMCHGLHLL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IFDMDGBPDKD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GAPDDGJNMPK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CICPCKDCCEF()
		{
			return PHDOCKCBJOF;
		}

		public void OGBOHCPHGMK()
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
				HGMAPLKJONO = BJGCPDNMHDH.GetTechnologyVisualDefinition(JMEGHFOKLBF, EDNLBEDPMCM);
				if (EFBPOCHCGPB && HGMAPLKJONO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HGMAPLKJONO.FFGDLJEMDNG());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				KFCAECGLKKO = EDNLBEDPMCM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TechnologyVisualDefinition current = KFCAECGLKKO.Current;
						if (current != HGMAPLKJONO)
						{
							current.BLEGJDCNAAJ();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public bool CGOKGPGALLH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				HGMAPLKJONO = BJGCPDNMHDH.GetTechnologyVisualDefinition(JMEGHFOKLBF, EDNLBEDPMCM);
				if (EFBPOCHCGPB && HGMAPLKJONO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HGMAPLKJONO.JMJIGNKHEKL());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				KFCAECGLKKO = EDNLBEDPMCM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TechnologyVisualDefinition current = KFCAECGLKKO.Current;
						if (current != HGMAPLKJONO)
						{
							current.BLEGJDCNAAJ();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object OJMKDIBHMND()
		{
			return PHDOCKCBJOF;
		}

		public void AGFMDCEAJNM()
		{
			throw new NotSupportedException();
		}

		public void JOEOMEJLEID()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object PJOAMPDDGAM()
		{
			return PHDOCKCBJOF;
		}

		public void PHEIGPKKPGE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JCDIBAEMKCA()
		{
			return PHDOCKCBJOF;
		}

		public void OPMABIIDKCN()
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
				HGMAPLKJONO = BJGCPDNMHDH.GetTechnologyVisualDefinition(JMEGHFOKLBF, EDNLBEDPMCM);
				if (EFBPOCHCGPB && HGMAPLKJONO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HGMAPLKJONO.JMJIGNKHEKL());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				KFCAECGLKKO = EDNLBEDPMCM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TechnologyVisualDefinition current = KFCAECGLKKO.Current;
						if (current != HGMAPLKJONO)
						{
							current.LLGPADPJPIF();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void CKEOKOKAAPB()
		{
			throw new NotSupportedException();
		}

		public void GGCLMIMHKBD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IHDBAJNCNGN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DJIJFANFBCP()
		{
			return PHDOCKCBJOF;
		}

		public void ODPKEEIHOPK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void JCDBOCPAKEC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object KOGGPMGMFIN()
		{
			return PHDOCKCBJOF;
		}

		public void GFGEEFGMNDP()
		{
			throw new NotSupportedException();
		}

		public bool AGMKAADLHLE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				HGMAPLKJONO = BJGCPDNMHDH.GetTechnologyVisualDefinition(JMEGHFOKLBF, EDNLBEDPMCM);
				if (EFBPOCHCGPB && HGMAPLKJONO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HGMAPLKJONO.CBKMNCJMJIH());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				KFCAECGLKKO = EDNLBEDPMCM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TechnologyVisualDefinition current = KFCAECGLKKO.Current;
						if (current != HGMAPLKJONO)
						{
							current.LLGPADPJPIF();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object JDECDOJJAAH()
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
				HGMAPLKJONO = BJGCPDNMHDH.GetTechnologyVisualDefinition(JMEGHFOKLBF, EDNLBEDPMCM);
				if (EFBPOCHCGPB && HGMAPLKJONO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HGMAPLKJONO.JMJIGNKHEKL());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				KFCAECGLKKO = EDNLBEDPMCM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TechnologyVisualDefinition current = KFCAECGLKKO.Current;
						if (current != HGMAPLKJONO)
						{
							current.EIFNJBHKBOM();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public bool DMPHMFDEINI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				HGMAPLKJONO = BJGCPDNMHDH.GetTechnologyVisualDefinition(JMEGHFOKLBF, EDNLBEDPMCM);
				if (EFBPOCHCGPB && HGMAPLKJONO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HGMAPLKJONO.BCGOFHPCKAA());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				KFCAECGLKKO = EDNLBEDPMCM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TechnologyVisualDefinition current = KFCAECGLKKO.Current;
						if (current != HGMAPLKJONO)
						{
							current.BHINPFEIIJG();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void NINFNJOMJOD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object LMLPPCCDELM()
		{
			return PHDOCKCBJOF;
		}

		public void NDPOBCODJAI()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IHPDPKLEDKC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JEKHOAFAIBP()
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
				HGMAPLKJONO = BJGCPDNMHDH.GetTechnologyVisualDefinition(JMEGHFOKLBF, EDNLBEDPMCM);
				if (EFBPOCHCGPB && HGMAPLKJONO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HGMAPLKJONO.BCGOFHPCKAA());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				KFCAECGLKKO = EDNLBEDPMCM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TechnologyVisualDefinition current = KFCAECGLKKO.Current;
						if (current != HGMAPLKJONO)
						{
							current.BHINPFEIIJG();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[DebuggerHidden]
		public void Dispose()
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
				HGMAPLKJONO = BJGCPDNMHDH.GetTechnologyVisualDefinition(JMEGHFOKLBF, EDNLBEDPMCM);
				if (EFBPOCHCGPB && HGMAPLKJONO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HGMAPLKJONO.JMJIGNKHEKL());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				KFCAECGLKKO = EDNLBEDPMCM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TechnologyVisualDefinition current = KFCAECGLKKO.Current;
						if (current != HGMAPLKJONO)
						{
							current.MIHNPIJCIKK();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public bool JFPOOBJNEPF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				HGMAPLKJONO = BJGCPDNMHDH.GetTechnologyVisualDefinition(JMEGHFOKLBF, EDNLBEDPMCM);
				if (EFBPOCHCGPB && HGMAPLKJONO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HGMAPLKJONO.FFGDLJEMDNG());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				KFCAECGLKKO = EDNLBEDPMCM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TechnologyVisualDefinition current = KFCAECGLKKO.Current;
						if (current != HGMAPLKJONO)
						{
							current.BLEGJDCNAAJ();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object NAAMAOJBKBK()
		{
			return PHDOCKCBJOF;
		}

		public void FMINPCPGBBG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void NCOPKHMOMMK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object FFNFEAHBBLJ()
		{
			return PHDOCKCBJOF;
		}

		public void BBBLJNFEACC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BGAGLOJHMEJ()
		{
			return PHDOCKCBJOF;
		}

		public void IFBOOBLACGK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void OGHELMDBPIL()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object PFIIINLHGMH()
		{
			return PHDOCKCBJOF;
		}
	}

	private sealed class NJPCJIKDDAJ : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal int JMEGHFOKLBF;

		internal List<TechnologyVisualDefinition> EDNLBEDPMCM;

		internal TechnologyVisualDefinition HGMAPLKJONO;

		internal bool EFBPOCHCGPB;

		internal List<TechnologyVisualDefinition>.Enumerator KFCAECGLKKO;

		internal UpgradeSlots BJGCPDNMHDH;

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
		private object GEFKCGOOFFP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AFAOHBIDOJD()
		{
			return PHDOCKCBJOF;
		}

		public void IMFLNKIMEFA()
		{
			throw new NotSupportedException();
		}

		public void HJLCPFDBNKP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void KOEEOJGJNAO()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BLOJDIFOPIA()
		{
			return PHDOCKCBJOF;
		}

		public bool PIAOIBJMLCC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				HGMAPLKJONO = BJGCPDNMHDH.GetTechnologyVisualDefinition(JMEGHFOKLBF, EDNLBEDPMCM);
				if (EFBPOCHCGPB && HGMAPLKJONO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HGMAPLKJONO.IDJIGNLGAKB());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				KFCAECGLKKO = EDNLBEDPMCM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TechnologyVisualDefinition current = KFCAECGLKKO.Current;
						if (current != HGMAPLKJONO)
						{
							current.LLJOCAELALO();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void CFDAGFGOOIE()
		{
			throw new NotSupportedException();
		}

		public void MKACBCOLNKD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool ICKNHCBNOMG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				HGMAPLKJONO = BJGCPDNMHDH.GetTechnologyVisualDefinition(JMEGHFOKLBF, EDNLBEDPMCM);
				if (EFBPOCHCGPB && HGMAPLKJONO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HGMAPLKJONO.LJAAMEPKPII());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				KFCAECGLKKO = EDNLBEDPMCM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TechnologyVisualDefinition current = KFCAECGLKKO.Current;
						if (current != HGMAPLKJONO)
						{
							current.LLJOCAELALO();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public bool EJKHEELJJFM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				HGMAPLKJONO = BJGCPDNMHDH.GetTechnologyVisualDefinition(JMEGHFOKLBF, EDNLBEDPMCM);
				if (EFBPOCHCGPB && HGMAPLKJONO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HGMAPLKJONO.IDJIGNLGAKB());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				KFCAECGLKKO = EDNLBEDPMCM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TechnologyVisualDefinition current = KFCAECGLKKO.Current;
						if (current != HGMAPLKJONO)
						{
							current.LPEPPPCBCDG();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void KNFDMCEJHLB()
		{
			throw new NotSupportedException();
		}

		public void NGAGGCFIEGJ()
		{
			throw new NotSupportedException();
		}

		public void FIENOOBNNGD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BGLDNJLBIKM()
		{
			return PHDOCKCBJOF;
		}

		public bool AGMKAADLHLE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				HGMAPLKJONO = BJGCPDNMHDH.GetTechnologyVisualDefinition(JMEGHFOKLBF, EDNLBEDPMCM);
				if (EFBPOCHCGPB && HGMAPLKJONO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HGMAPLKJONO.PLNLICOAHFL());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				KFCAECGLKKO = EDNLBEDPMCM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TechnologyVisualDefinition current = KFCAECGLKKO.Current;
						if (current != HGMAPLKJONO)
						{
							current.LPEPPPCBCDG();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void NGNOJECCHGF()
		{
			throw new NotSupportedException();
		}

		public bool LPCBKGKFNFD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				HGMAPLKJONO = BJGCPDNMHDH.GetTechnologyVisualDefinition(JMEGHFOKLBF, EDNLBEDPMCM);
				if (EFBPOCHCGPB && HGMAPLKJONO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HGMAPLKJONO.GEIBNFKACDB());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				KFCAECGLKKO = EDNLBEDPMCM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TechnologyVisualDefinition current = KFCAECGLKKO.Current;
						if (current != HGMAPLKJONO)
						{
							current.LPEPPPCBCDG();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public bool ONFBKOEOIOC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				HGMAPLKJONO = BJGCPDNMHDH.GetTechnologyVisualDefinition(JMEGHFOKLBF, EDNLBEDPMCM);
				if (EFBPOCHCGPB && HGMAPLKJONO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HGMAPLKJONO.HBIDPDPDADN());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				KFCAECGLKKO = EDNLBEDPMCM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TechnologyVisualDefinition current = KFCAECGLKKO.Current;
						if (current != HGMAPLKJONO)
						{
							current.LLJOCAELALO();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void OPMABIIDKCN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool BJBEBPMDICE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				HGMAPLKJONO = BJGCPDNMHDH.GetTechnologyVisualDefinition(JMEGHFOKLBF, EDNLBEDPMCM);
				if (EFBPOCHCGPB && HGMAPLKJONO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HGMAPLKJONO.GEIBNFKACDB());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				KFCAECGLKKO = EDNLBEDPMCM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TechnologyVisualDefinition current = KFCAECGLKKO.Current;
						if (current != HGMAPLKJONO)
						{
							current.BBENKKFKDJH();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object MBDBIPHLEIA()
		{
			return PHDOCKCBJOF;
		}

		public void DLIBOPAMHAN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object AHFIDCCJHKE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EPGLILIJMEM()
		{
			return PHDOCKCBJOF;
		}

		public bool CJGKHIPOBGP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				HGMAPLKJONO = BJGCPDNMHDH.GetTechnologyVisualDefinition(JMEGHFOKLBF, EDNLBEDPMCM);
				if (EFBPOCHCGPB && HGMAPLKJONO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HGMAPLKJONO.IDJIGNLGAKB());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				KFCAECGLKKO = EDNLBEDPMCM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TechnologyVisualDefinition current = KFCAECGLKKO.Current;
						if (current != HGMAPLKJONO)
						{
							current.LLJOCAELALO();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object FCMAGGLJCMG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MOMPOEEALPJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OJMKDIBHMND()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IDLFKAKINAP()
		{
			return PHDOCKCBJOF;
		}

		public bool BJOHOCFKMJO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				HGMAPLKJONO = BJGCPDNMHDH.GetTechnologyVisualDefinition(JMEGHFOKLBF, EDNLBEDPMCM);
				if (EFBPOCHCGPB && HGMAPLKJONO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HGMAPLKJONO.GEIBNFKACDB());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				KFCAECGLKKO = EDNLBEDPMCM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TechnologyVisualDefinition current = KFCAECGLKKO.Current;
						if (current != HGMAPLKJONO)
						{
							current.LPEPPPCBCDG();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object GJMNLPAEIDA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IGFMIFOHCHJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IPCODJDAOBE()
		{
			return PHDOCKCBJOF;
		}

		public void GGCLMIMHKBD()
		{
			throw new NotSupportedException();
		}

		public void EJADBNAIHEF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void HCJOIAHBFGB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void EKPOLGNAAOI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void GFGEEFGMNDP()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JCDIBAEMKCA()
		{
			return PHDOCKCBJOF;
		}

		public void BOFEBMENOFC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool NJBCJDFKGHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				HGMAPLKJONO = BJGCPDNMHDH.GetTechnologyVisualDefinition(JMEGHFOKLBF, EDNLBEDPMCM);
				if (EFBPOCHCGPB && HGMAPLKJONO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HGMAPLKJONO.PLNLICOAHFL());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				KFCAECGLKKO = EDNLBEDPMCM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TechnologyVisualDefinition current = KFCAECGLKKO.Current;
						if (current != HGMAPLKJONO)
						{
							current.BBENKKFKDJH();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[DebuggerHidden]
		public NJPCJIKDDAJ()
		{
		}

		public bool PMJICFJGOBE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				HGMAPLKJONO = BJGCPDNMHDH.GetTechnologyVisualDefinition(JMEGHFOKLBF, EDNLBEDPMCM);
				if (EFBPOCHCGPB && HGMAPLKJONO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HGMAPLKJONO.PLNLICOAHFL());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				KFCAECGLKKO = EDNLBEDPMCM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TechnologyVisualDefinition current = KFCAECGLKKO.Current;
						if (current != HGMAPLKJONO)
						{
							current.BBENKKFKDJH();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object JMKGAJNOLEM()
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
				HGMAPLKJONO = BJGCPDNMHDH.GetTechnologyVisualDefinition(JMEGHFOKLBF, EDNLBEDPMCM);
				if (EFBPOCHCGPB && HGMAPLKJONO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HGMAPLKJONO.LJAAMEPKPII());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				KFCAECGLKKO = EDNLBEDPMCM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TechnologyVisualDefinition current = KFCAECGLKKO.Current;
						if (current != HGMAPLKJONO)
						{
							current.LPEPPPCBCDG();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object MDHGGDNNOAK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BMAMEPNHHFI()
		{
			return PHDOCKCBJOF;
		}

		public void LOOMFHNKAND()
		{
			throw new NotSupportedException();
		}

		public bool LGNMOMFLLPP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				HGMAPLKJONO = BJGCPDNMHDH.GetTechnologyVisualDefinition(JMEGHFOKLBF, EDNLBEDPMCM);
				if (EFBPOCHCGPB && HGMAPLKJONO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HGMAPLKJONO.PLNLICOAHFL());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				KFCAECGLKKO = EDNLBEDPMCM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TechnologyVisualDefinition current = KFCAECGLKKO.Current;
						if (current != HGMAPLKJONO)
						{
							current.LPEPPPCBCDG();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object GKDLMFPKKNM()
		{
			return PHDOCKCBJOF;
		}

		public bool CIIHKFDLDKN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				HGMAPLKJONO = BJGCPDNMHDH.GetTechnologyVisualDefinition(JMEGHFOKLBF, EDNLBEDPMCM);
				if (EFBPOCHCGPB && HGMAPLKJONO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HGMAPLKJONO.LJAAMEPKPII());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				KFCAECGLKKO = EDNLBEDPMCM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TechnologyVisualDefinition current = KFCAECGLKKO.Current;
						if (current != HGMAPLKJONO)
						{
							current.BBENKKFKDJH();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void PPHBGPPJBNK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void BCKMHLBBBCK()
		{
			throw new NotSupportedException();
		}

		public void IPKNPABKAJD()
		{
			throw new NotSupportedException();
		}

		public bool JIIOHNFHPOI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				HGMAPLKJONO = BJGCPDNMHDH.GetTechnologyVisualDefinition(JMEGHFOKLBF, EDNLBEDPMCM);
				if (EFBPOCHCGPB && HGMAPLKJONO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HGMAPLKJONO.HBIDPDPDADN());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				KFCAECGLKKO = EDNLBEDPMCM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TechnologyVisualDefinition current = KFCAECGLKKO.Current;
						if (current != HGMAPLKJONO)
						{
							current.LPEPPPCBCDG();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object JEKHOAFAIBP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HJHFKNCBGDG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JPJBNHHKOJD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CEFJKELIBGG()
		{
			return PHDOCKCBJOF;
		}

		public void AJEIGCJPEFN()
		{
			throw new NotSupportedException();
		}

		public void CFHJPHLFONO()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IHAJFNHBAHB()
		{
			return PHDOCKCBJOF;
		}

		public void PAODBOEOFNF()
		{
			throw new NotSupportedException();
		}

		public bool JPAOKNLNFCB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				HGMAPLKJONO = BJGCPDNMHDH.GetTechnologyVisualDefinition(JMEGHFOKLBF, EDNLBEDPMCM);
				if (EFBPOCHCGPB && HGMAPLKJONO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HGMAPLKJONO.PLNLICOAHFL());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				KFCAECGLKKO = EDNLBEDPMCM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TechnologyVisualDefinition current = KFCAECGLKKO.Current;
						if (current != HGMAPLKJONO)
						{
							current.BBENKKFKDJH();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void LFIGPJBHPBH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MOLLIAAFOMJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GDBNOMPNBGP()
		{
			return PHDOCKCBJOF;
		}

		public void CDIJEGGMMAK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void HDDLDAHLPCO()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object CGIBLCGGMJM()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KKCOHEHPJPF()
		{
			return PHDOCKCBJOF;
		}

		public bool HJHJCCFGJIH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				HGMAPLKJONO = BJGCPDNMHDH.GetTechnologyVisualDefinition(JMEGHFOKLBF, EDNLBEDPMCM);
				if (EFBPOCHCGPB && HGMAPLKJONO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HGMAPLKJONO.PLNLICOAHFL());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				KFCAECGLKKO = EDNLBEDPMCM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TechnologyVisualDefinition current = KFCAECGLKKO.Current;
						if (current != HGMAPLKJONO)
						{
							current.LLJOCAELALO();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void NIGDCBDKKMJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JFHOHPKEFGM()
		{
			return PHDOCKCBJOF;
		}

		public void ODCIKOOGNFG()
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
				HGMAPLKJONO = BJGCPDNMHDH.GetTechnologyVisualDefinition(JMEGHFOKLBF, EDNLBEDPMCM);
				if (EFBPOCHCGPB && HGMAPLKJONO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HGMAPLKJONO.PLNLICOAHFL());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				KFCAECGLKKO = EDNLBEDPMCM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TechnologyVisualDefinition current = KFCAECGLKKO.Current;
						if (current != HGMAPLKJONO)
						{
							current.BBENKKFKDJH();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public bool BIGKCFMEBJE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				HGMAPLKJONO = BJGCPDNMHDH.GetTechnologyVisualDefinition(JMEGHFOKLBF, EDNLBEDPMCM);
				if (EFBPOCHCGPB && HGMAPLKJONO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(HGMAPLKJONO.LJAAMEPKPII());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				KFCAECGLKKO = EDNLBEDPMCM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						TechnologyVisualDefinition current = KFCAECGLKKO.Current;
						if (current != HGMAPLKJONO)
						{
							current.BBENKKFKDJH();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void NINFNJOMJOD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GOAJCEAOPLA()
		{
			return PHDOCKCBJOF;
		}

		public void CNEIBEACPCM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BBOGBCNCIFN()
		{
			return PHDOCKCBJOF;
		}

		public void FMOJMHBAHAA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object OEKIILKKNOE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BNMEIAPPLDP()
		{
			return PHDOCKCBJOF;
		}
	}

	private sealed class CGMBKNHFEKK : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal UnitUpgrades PFGLIAHPMCK;

		internal bool EFBPOCHCGPB;

		internal UpgradeSlots BJGCPDNMHDH;

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

		public bool BEIABOJAIFM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMineVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, (!PFGLIAHPMCK.isElite) ? BJGCPDNMHDH.allVisuals : BJGCPDNMHDH.eliteVisuals));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void CHANLKFNCLA()
		{
			throw new NotSupportedException();
		}

		public bool CIIHKFDLDKN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMineVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, (!PFGLIAHPMCK.isElite) ? BJGCPDNMHDH.allVisuals : BJGCPDNMHDH.eliteVisuals));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void LDBLCPIGLOF()
		{
			throw new NotSupportedException();
		}

		public void GBGMIJNBLNH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool LMNIKLKKIDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMineVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, (!PFGLIAHPMCK.isElite) ? BJGCPDNMHDH.allVisuals : BJGCPDNMHDH.eliteVisuals));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void DBJCDLFKDDI()
		{
			throw new NotSupportedException();
		}

		public void HCHNHNDDKKA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object DOOAHBLHGFO()
		{
			return PHDOCKCBJOF;
		}

		public void HONCAABOMOC()
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
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMineVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, (!PFGLIAHPMCK.isElite) ? BJGCPDNMHDH.allVisuals : BJGCPDNMHDH.eliteVisuals));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public bool OOECALAHCFK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMineVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, (!PFGLIAHPMCK.isElite) ? BJGCPDNMHDH.allVisuals : BJGCPDNMHDH.eliteVisuals));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void LBNGPPPKLHI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool CCOPPEKLJOB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMineVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, (!PFGLIAHPMCK.isElite) ? BJGCPDNMHDH.allVisuals : BJGCPDNMHDH.eliteVisuals));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
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
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMineVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, (!PFGLIAHPMCK.isElite) ? BJGCPDNMHDH.allVisuals : BJGCPDNMHDH.eliteVisuals));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void AMPGDAMMPFJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object FPMOGMELJLI()
		{
			return PHDOCKCBJOF;
		}

		public void GCEMCPODLNM()
		{
			throw new NotSupportedException();
		}

		public bool GAPIFMKNJBN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMineVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, (!PFGLIAHPMCK.isElite) ? BJGCPDNMHDH.allVisuals : BJGCPDNMHDH.eliteVisuals));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void CDDFJOEEFID()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GOAJCEAOPLA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FKKBFFHMEME()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DCILDAODCDM()
		{
			return PHDOCKCBJOF;
		}

		public void PHEIGPKKPGE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object PFIIINLHGMH()
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
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMineVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, (!PFGLIAHPMCK.isElite) ? BJGCPDNMHDH.allVisuals : BJGCPDNMHDH.eliteVisuals));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void GFGEEFGMNDP()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public bool ILNBJIJONKD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMineVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, (!PFGLIAHPMCK.isElite) ? BJGCPDNMHDH.allVisuals : BJGCPDNMHDH.eliteVisuals));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object HPHLLGIMIMO()
		{
			return PHDOCKCBJOF;
		}

		public bool DMPHMFDEINI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMineVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, (!PFGLIAHPMCK.isElite) ? BJGCPDNMHDH.allVisuals : BJGCPDNMHDH.eliteVisuals));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void PDKPELBIAON()
		{
			throw new NotSupportedException();
		}

		public void HPJKDIGCCCE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HCPKEMLPEDI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MPEPJNIDBLI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NCKCKPNAHAD()
		{
			return PHDOCKCBJOF;
		}

		public void IKNKDDMLDIN()
		{
			throw new NotSupportedException();
		}

		public bool BPHPJKKHNNG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMineVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, (!PFGLIAHPMCK.isElite) ? BJGCPDNMHDH.allVisuals : BJGCPDNMHDH.eliteVisuals));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void OPMABIIDKCN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object OAMLLHEMBIK()
		{
			return PHDOCKCBJOF;
		}

		public void ANOPOLIEBMC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object PEGJNAKGHCC()
		{
			return PHDOCKCBJOF;
		}

		public void OKIANDBCDIB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void ODPKEEIHOPK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BEGHOADNMJF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LKAEMBCGLBN()
		{
			return PHDOCKCBJOF;
		}

		public void CJLDNKALLLI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool LPMIKEPIMCM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMineVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, (!PFGLIAHPMCK.isElite) ? BJGCPDNMHDH.allVisuals : BJGCPDNMHDH.eliteVisuals));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void JJOAHIOBOPO()
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
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMineVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, (!PFGLIAHPMCK.isElite) ? BJGCPDNMHDH.allVisuals : BJGCPDNMHDH.eliteVisuals));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void NDPOBCODJAI()
		{
			throw new NotSupportedException();
		}

		public void ODCIKOOGNFG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void NBGFOILFGHD()
		{
			throw new NotSupportedException();
		}

		public void GFJIKANGNMC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool BIGKCFMEBJE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMineVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, (!PFGLIAHPMCK.isElite) ? BJGCPDNMHDH.allVisuals : BJGCPDNMHDH.eliteVisuals));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[DebuggerHidden]
		public CGMBKNHFEKK()
		{
		}

		[SpecialName]
		private object GKDLMFPKKNM()
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
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMineVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, (!PFGLIAHPMCK.isElite) ? BJGCPDNMHDH.allVisuals : BJGCPDNMHDH.eliteVisuals));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object BGMNDLEJNHH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OJKHNOHHDGO()
		{
			return PHDOCKCBJOF;
		}
	}

	private sealed class MJFCEHPBAGM : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal UnitUpgrades PFGLIAHPMCK;

		internal bool EFBPOCHCGPB;

		internal UpgradeSlots BJGCPDNMHDH;

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
		private object KJGPLKJAIMC()
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
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, (!PFGLIAHPMCK.isElite) ? BJGCPDNMHDH.allVisuals : BJGCPDNMHDH.eliteVisuals));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object KDLMIDIEPHD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CEFJLKJNAKJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GNFCCLCPCBO()
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
		private object MOLLIAAFOMJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CCANBMDEKMB()
		{
			return PHDOCKCBJOF;
		}

		public bool LLOCENNFFFJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, (!PFGLIAHPMCK.isElite) ? BJGCPDNMHDH.allVisuals : BJGCPDNMHDH.eliteVisuals));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public bool PMCFLKAJNHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, (!PFGLIAHPMCK.isElite) ? BJGCPDNMHDH.allVisuals : BJGCPDNMHDH.eliteVisuals));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object MPEPJNIDBLI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LDBICDEEENB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HJHFKNCBGDG()
		{
			return PHDOCKCBJOF;
		}

		public void FGLAPPKJHBK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BCIDICEAAEN()
		{
			return PHDOCKCBJOF;
		}

		public void BCOIPCDCKEJ()
		{
			throw new NotSupportedException();
		}

		public void PDNKLJFHBGO()
		{
			throw new NotSupportedException();
		}

		public void ONGBFFAENBP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void HNOPIDGLMPA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object DNNAMCFLCGE()
		{
			return PHDOCKCBJOF;
		}

		public void HCHFFFPDMDA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void IKNKDDMLDIN()
		{
			throw new NotSupportedException();
		}

		public void MPLPDIGFPBH()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BMAMEPNHHFI()
		{
			return PHDOCKCBJOF;
		}

		public bool DNDHHHDOLMO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, (!PFGLIAHPMCK.isElite) ? BJGCPDNMHDH.allVisuals : BJGCPDNMHDH.eliteVisuals));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object LAENBDAPNJL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CLDLJNHAEAB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FIFIOGBLLBE()
		{
			return PHDOCKCBJOF;
		}

		public void IBDAHMOEBCM()
		{
			throw new NotSupportedException();
		}

		public bool BKJCILLNJLG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, (!PFGLIAHPMCK.isElite) ? BJGCPDNMHDH.allVisuals : BJGCPDNMHDH.eliteVisuals));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void CDIJEGGMMAK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void IMFLNKIMEFA()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MJPEJLKAOEH()
		{
			return PHDOCKCBJOF;
		}

		public bool DDBCLDGNFBB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, (!PFGLIAHPMCK.isElite) ? BJGCPDNMHDH.allVisuals : BJGCPDNMHDH.eliteVisuals));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object PGOIHDIKFEI()
		{
			return PHDOCKCBJOF;
		}

		public bool FNEPBDLIKOD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, (!PFGLIAHPMCK.isElite) ? BJGCPDNMHDH.allVisuals : BJGCPDNMHDH.eliteVisuals));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void NNCBKIIJPMB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void DBJCDLFKDDI()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object OJMKDIBHMND()
		{
			return PHDOCKCBJOF;
		}

		public bool EKGEDEKHBME()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, (!PFGLIAHPMCK.isElite) ? BJGCPDNMHDH.allVisuals : BJGCPDNMHDH.eliteVisuals));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object ALJCBJBHLMK()
		{
			return PHDOCKCBJOF;
		}

		public bool LPMIKEPIMCM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, (!PFGLIAHPMCK.isElite) ? BJGCPDNMHDH.allVisuals : BJGCPDNMHDH.eliteVisuals));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void PCNOHGFPMOE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool OKELILGDPLJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, (!PFGLIAHPMCK.isElite) ? BJGCPDNMHDH.allVisuals : BJGCPDNMHDH.eliteVisuals));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object KBEEEOJMBPG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DFHCLJNONGC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FJGIOPMDPGA()
		{
			return PHDOCKCBJOF;
		}

		public bool NAMPBIHOFGI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, (!PFGLIAHPMCK.isElite) ? BJGCPDNMHDH.allVisuals : BJGCPDNMHDH.eliteVisuals));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[DebuggerHidden]
		public MJFCEHPBAGM()
		{
		}

		public void ODJLLLFJIOB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void BDPFKFGBNOH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void NINFHADPHJI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HHPHMIJOAPL()
		{
			throw new NotSupportedException();
		}

		public bool GBLFIBDBMGE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, (!PFGLIAHPMCK.isElite) ? BJGCPDNMHDH.allVisuals : BJGCPDNMHDH.eliteVisuals));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public bool PMJICFJGOBE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, (!PFGLIAHPMCK.isElite) ? BJGCPDNMHDH.allVisuals : BJGCPDNMHDH.eliteVisuals));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object IHAOBCEALPD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OJANHAIEAEJ()
		{
			return PHDOCKCBJOF;
		}

		public void PPHBGPPJBNK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void JCDBOCPAKEC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object PGMPMBFDAAC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FPMOGMELJLI()
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
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, (!PFGLIAHPMCK.isElite) ? BJGCPDNMHDH.allVisuals : BJGCPDNMHDH.eliteVisuals));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object GDCFFBBNGHH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GENJNMACGLP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MLDIMIPJMDD()
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
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, (!PFGLIAHPMCK.isElite) ? BJGCPDNMHDH.allVisuals : BJGCPDNMHDH.eliteVisuals));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public bool CGOKGPGALLH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, (!PFGLIAHPMCK.isElite) ? BJGCPDNMHDH.allVisuals : BJGCPDNMHDH.eliteVisuals));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public bool EKHDJADMNJK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, (!PFGLIAHPMCK.isElite) ? BJGCPDNMHDH.allVisuals : BJGCPDNMHDH.eliteVisuals));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object EOPJNKFKMNB()
		{
			return PHDOCKCBJOF;
		}

		public bool LPCBKGKFNFD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, (!PFGLIAHPMCK.isElite) ? BJGCPDNMHDH.allVisuals : BJGCPDNMHDH.eliteVisuals));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object HMILEBCNNCP()
		{
			return PHDOCKCBJOF;
		}

		public bool CCOPPEKLJOB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, (!PFGLIAHPMCK.isElite) ? BJGCPDNMHDH.allVisuals : BJGCPDNMHDH.eliteVisuals));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void HCJOIAHBFGB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void CGCPMAHOJJC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void ABBPOMCBIIH()
		{
			throw new NotSupportedException();
		}

		public void GFJIKANGNMC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object NIDLKNKKCND()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DCILDAODCDM()
		{
			return PHDOCKCBJOF;
		}

		public void KGLKGNBCPLM()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool BEIABOJAIFM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, (!PFGLIAHPMCK.isElite) ? BJGCPDNMHDH.allVisuals : BJGCPDNMHDH.eliteVisuals));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
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
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, (!PFGLIAHPMCK.isElite) ? BJGCPDNMHDH.allVisuals : BJGCPDNMHDH.eliteVisuals));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void NCFGFLNBHOI()
		{
			throw new NotSupportedException();
		}

		public void ODCIKOOGNFG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GEFKCGOOFFP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JDECDOJJAAH()
		{
			return PHDOCKCBJOF;
		}

		public bool BLHOCNMMPNP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, (!PFGLIAHPMCK.isElite) ? BJGCPDNMHDH.allVisuals : BJGCPDNMHDH.eliteVisuals));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public bool IJEDIDEJIII()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, (!PFGLIAHPMCK.isElite) ? BJGCPDNMHDH.allVisuals : BJGCPDNMHDH.eliteVisuals));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void GFGEEFGMNDP()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FONIPEGACDN()
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
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, (!PFGLIAHPMCK.isElite) ? BJGCPDNMHDH.allVisuals : BJGCPDNMHDH.eliteVisuals));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void KNFDDIHLBKJ()
		{
			throw new NotSupportedException();
		}

		public void HGCHEPGNHNP()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KMCGJFDPBCB()
		{
			return PHDOCKCBJOF;
		}

		public bool FGAFKEKGPHF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, (!PFGLIAHPMCK.isElite) ? BJGCPDNMHDH.allVisuals : BJGCPDNMHDH.eliteVisuals));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void NBGFOILFGHD()
		{
			throw new NotSupportedException();
		}

		public bool FNIOOIGJPAM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, (!PFGLIAHPMCK.isElite) ? BJGCPDNMHDH.allVisuals : BJGCPDNMHDH.eliteVisuals));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void GBGMIJNBLNH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void FMOJMHBAHAA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void OKIANDBCDIB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MOMPOEEALPJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FKJJFNMBKOP()
		{
			return PHDOCKCBJOF;
		}

		public void IGBHHLFACKO()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MHKODCGLJFD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HLBMCNKGBDM()
		{
			return PHDOCKCBJOF;
		}

		public void MAKKCANEHIB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BPKCMCDJOBF()
		{
			return PHDOCKCBJOF;
		}
	}

	private sealed class JKLFIKMDAOA : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal List<TechnologyVisualDefinition>.Enumerator KFCAECGLKKO;

		internal TechnologyVisualDefinition BJOLICIOGLK;

		internal UpgradeSlots BJGCPDNMHDH;

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
		private object AIDHNJCPDIJ()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public JKLFIKMDAOA()
		{
		}

		public bool HOOHJGPHHGN()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.cardVisuals.GetEnumerator();
				num = 48u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							BJOLICIOGLK = KFCAECGLKKO.Current;
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJOLICIOGLK.JMJIGNKHEKL());
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = true;
							goto IL_00c4;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_00c4:
				return true;
			}
		}

		public void GEEKOICFEIB()
		{
			throw new NotSupportedException();
		}

		public bool GNFCLHDPPFP()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.cardVisuals.GetEnumerator();
				num = 111u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							BJOLICIOGLK = KFCAECGLKKO.Current;
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJOLICIOGLK.FFGDLJEMDNG());
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = false;
							goto IL_00c4;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_00c4:
				return false;
			}
		}

		public bool EKHDJADMNJK()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.cardVisuals.GetEnumerator();
				num = 52u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							BJOLICIOGLK = KFCAECGLKKO.Current;
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJOLICIOGLK.FFGDLJEMDNG());
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = true;
							goto IL_00c4;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_00c4:
				return true;
			}
		}

		[SpecialName]
		private object PIPMONHGDPH()
		{
			return PHDOCKCBJOF;
		}

		public void GGCLMIMHKBD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GMPGIODBIPO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HCCLNDKNCIE()
		{
			return PHDOCKCBJOF;
		}

		public bool MoveNext()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.cardVisuals.GetEnumerator();
				num = 4294967293u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							BJOLICIOGLK = KFCAECGLKKO.Current;
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJOLICIOGLK.JMJIGNKHEKL());
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = true;
							goto IL_00c4;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_00c4:
				return true;
			}
		}
	}

	private sealed class GDPICKHGNNF : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal List<TechnologyVisualDefinition>.Enumerator KFCAECGLKKO;

		internal TechnologyVisualDefinition BJOLICIOGLK;

		internal UpgradeSlots BJGCPDNMHDH;

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

		public bool MoveNext()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.cardVisuals.GetEnumerator();
				num = 4294967293u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							BJOLICIOGLK = KFCAECGLKKO.Current;
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJOLICIOGLK.LJAAMEPKPII());
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = true;
							goto IL_00c4;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_00c4:
				return true;
			}
		}

		public void LHADJAFHDDC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public bool GNFCLHDPPFP()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.cardVisuals.GetEnumerator();
				num = 4294967247u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							BJOLICIOGLK = KFCAECGLKKO.Current;
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJOLICIOGLK.HBIDPDPDADN());
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = true;
							goto IL_00c4;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_00c4:
				return false;
			}
		}

		[SpecialName]
		private object FPFOODLPEBK()
		{
			return PHDOCKCBJOF;
		}

		public bool OGLKGILLKIO()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.cardVisuals.GetEnumerator();
				num = 4294967224u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							BJOLICIOGLK = KFCAECGLKKO.Current;
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJOLICIOGLK.LJAAMEPKPII());
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = false;
							goto IL_00c4;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_00c4:
				return true;
			}
		}

		[DebuggerHidden]
		public void Dispose()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object KBNAGKKMLBP()
		{
			return PHDOCKCBJOF;
		}

		public bool NJBCJDFKGHO()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.cardVisuals.GetEnumerator();
				num = 4294967216u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							BJOLICIOGLK = KFCAECGLKKO.Current;
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJOLICIOGLK.IDJIGNLGAKB());
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = false;
							goto IL_00c4;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_00c4:
				return false;
			}
		}

		[SpecialName]
		private object GDCFFBBNGHH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FIDLDFGJLFK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MHKODCGLJFD()
		{
			return PHDOCKCBJOF;
		}

		public void OJDEHKDDLFD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void MENEBJLDGJD()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public GDPICKHGNNF()
		{
		}

		public void EPKPNKGJHEC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public bool HOOHJGPHHGN()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.cardVisuals.GetEnumerator();
				num = 45u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							BJOLICIOGLK = KFCAECGLKKO.Current;
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJOLICIOGLK.LJAAMEPKPII());
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 1;
							}
							flag = false;
							goto IL_00c4;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_00c4:
				return false;
			}
		}

		public void NINFHADPHJI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void IJHCIJLDKHK()
		{
			throw new NotSupportedException();
		}

		public void ONGBFFAENBP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void AKEKFBGEJBG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void JMANMKKCDMM()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GJMNLPAEIDA()
		{
			return PHDOCKCBJOF;
		}

		public bool JPBGJLDMOPO()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.cardVisuals.GetEnumerator();
				num = 45u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							BJOLICIOGLK = KFCAECGLKKO.Current;
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJOLICIOGLK.PLNLICOAHFL());
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = false;
							goto IL_00c4;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_00c4:
				return false;
			}
		}

		public void NINFNJOMJOD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object IHPDPKLEDKC()
		{
			return PHDOCKCBJOF;
		}

		public bool OKELILGDPLJ()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.cardVisuals.GetEnumerator();
				num = 49u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					default:
						if (KFCAECGLKKO.MoveNext())
						{
							BJOLICIOGLK = KFCAECGLKKO.Current;
							PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJOLICIOGLK.IDJIGNLGAKB());
							if (!FDKOKMKIIMG)
							{
								CLPPIAGLCJJ = 0;
							}
							flag = false;
							goto IL_00c4;
						}
						break;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_00c4:
				return true;
			}
		}

		[SpecialName]
		private object CNGCLCAAHIG()
		{
			return PHDOCKCBJOF;
		}

		public void LPKDPNHBLGJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void FMOJMHBAHAA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		[SpecialName]
		private object ONADHLDNKKB()
		{
			return PHDOCKCBJOF;
		}
	}

	public List<TechnologyVisualDefinition> allVisuals;

	public List<TechnologyVisualDefinition> eliteVisuals;

	public List<TechnologyVisualDefinition> cardVisuals;

	public string iconName;

	public bool isTutorialUnit;

	private Google2uComponentBase mExcel;

	private string mExcelType;

	public List<HINJJOAJAOA> unitSounds;

	public static bool showMaxLevelWhenNotBought = true;

	public static bool showEliteUnitWhenBought;

	public static bool showElite;

	public LevelBehaviour owner;

	public UpgradeSlot upgradeSlot;

	public UpgradeSlotSpecial upgradeSlotSpecial;

	public UpgradeSlotElite upgradeSlotElite;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private ArmyUpgradesRow _003CarmyUpgradesRow_003Ek__BackingField;

	public bool inSelectMenuEquipped;

	public string iconNameElite => iconName + ((!upgradeSlotElite.isUnlocked) ? string.Empty : "-elite");

	public string iconNameVeteran => iconName + "-veteran";

	public bool borrowed
	{
		get
		{
			return GetArmySlot().borrowed;
		}
		set
		{
			GetArmySlot().borrowed = value;
		}
	}

	public ArmyUpgradesRow armyUpgradesRow
	{
		[CompilerGenerated]
		get
		{
			return _003CarmyUpgradesRow_003Ek__BackingField;
		}
		[CompilerGenerated]
		protected set
		{
			_003CarmyUpgradesRow_003Ek__BackingField = value;
		}
	}

	public LevelManager.GameLevel unlockLevel
	{
		get
		{
			if (unlockLevelIndex < 0)
			{
				UnityEngine.Debug.LogError(string.Concat("unlock level for: ", excel.GetType(), "out of range"));
			}
			return LevelManager.instance.GetLevelDefinition(unlockLevelIndex);
		}
	}

	public int unlockLevelIndex => armyUpgradesRow.UNLOCKLEVEL - 1;

	public int price => armyUpgradesRow.PRICE;

	public int priceGold => armyUpgradesRow.PRICEGOLD;

	public int unitDeliveryTime => armyUpgradesRow.DELIVERTIME;

	public int startUnitLevel => (armyUpgradesRow != null) ? armyUpgradesRow.STARTINGLEVEL : 0;

	public int startTier => armyUpgradesRow.STARTINGTIER;

	public float bulletSpeed => armyUpgradesRow.BULLETSPEED;

	public float playerBehindShieldDamageRatio => armyUpgradesRow.PLAYERBEHINDSHIELDDMGRATIO;

	public float playerDamageRatio => armyUpgradesRow.PLAYERDAMAGERATIO;

	public float playerDamageOvertimeRatio => armyUpgradesRow.PLAYERDAMAGEOVERTIMERATIO;

	public int totalPower => armyUpgradesRow.TOTALPOWER;

	public float coolDown => armyUpgradesRow.COOLDOWN;

	public float shieldHitProbability => armyUpgradesRow.HITSHIELDPROB;

	public string spawns
	{
		get
		{
			string sPAWNS = armyUpgradesRow.SPAWNS;
			return sPAWNS.Replace(" ", $" {Colours.stringGray}/{Colours.stringWhite} ");
		}
	}

	public float movementSpeed => armyUpgradesRow.MOVEMENTSPEED;

	public float soldierRespawnRate => armyUpgradesRow.UNITINMECHANICALRESPAWN;

	public virtual string shotDamageName => Localization.Localize("ID_SHOTDAMAGE");

	public virtual float damage => 0f;

	public virtual float accuracy
	{
		get
		{
			int rowIndex = upgradeSlot.boughtIndex;
			if (excel.HasColumn("realShotProbability"))
			{
				return (float)excel.GetValue(rowIndex, "realShotProbability");
			}
			return 1f;
		}
	}

	public virtual float rateOfFire
	{
		get
		{
			int rowIndex = upgradeSlot.boughtIndex;
			if (excel.HasColumn("ShotFrequencyMin") && excel.HasColumn("ShotFrequencyMax") && excel.HasColumn("BatchSizeMin") && excel.HasColumn("BatchSizeMax"))
			{
				float num = (float)excel.GetValue(rowIndex, "ShotFrequencyMin");
				float num2 = (float)excel.GetValue(rowIndex, "ShotFrequencyMax");
				int num3 = (int)excel.GetValue(rowIndex, "BatchSizeMin");
				int num4 = (int)excel.GetValue(rowIndex, "BatchSizeMax");
				return 60f / ((num + num2) * 0.5f) * ((float)(num3 + num4) * 0.5f);
			}
			return 1f;
		}
	}

	public virtual List<Tuple<string, float>> unitSpecifics => new List<Tuple<string, float>>();

	public virtual bool isSpecificTime => false;

	public int instantUnitDeliveryPrice
	{
		get
		{
			if (remainingDeliveringSeconds < 0.0)
			{
				return 0;
			}
			int num = MEJMLNDFDBP.BCEGIAODLCL(Convert.ToInt32(remainingDeliveringSeconds));
			int num2 = Singleton<OfferManager>.instance.DiscountedUnityDeliveryCost(owner.unitType, owner, NJMAGCAMDFM: false);
			if (num2 > 0)
			{
				num = num * (100 - num2) / 100;
			}
			return num;
		}
	}

	public Google2uComponentBase excel
	{
		get
		{
			if (mExcel == null)
			{
				mExcel = GetComponent<Google2uComponentBase>();
				mExcelType = excel.GetType().ToString();
			}
			return mExcel;
		}
	}

	public bool canBeUpgraded => actualUnitLevel < actualMaxUnitLevel;

	public bool canBuy => !delivering && !deliveryActivationNeeded;

	public float progressDelivering
	{
		get
		{
			if (unitState != JLANLLEABDC.Delivering && unitState != JLANLLEABDC.UnitDelivering)
			{
				return 0f;
			}
			double currentTimestampDouble = Singleton<BeanstalkServerManager>.instance.currentTimestampDouble;
			double num = (currentTimestampDouble - (double)startDeliveryTime) / (double)(endDeliveryTime - startDeliveryTime);
			return Mathf.Clamp01((float)num);
		}
	}

	public double remainingDeliveringSeconds
	{
		get
		{
			double currentTimestampDouble = Singleton<BeanstalkServerManager>.instance.currentTimestampDouble;
			return (double)endDeliveryTime - currentTimestampDouble;
		}
	}

	public bool isDeliveringOrDelivered => unitState == JLANLLEABDC.UnitDelivering || unitState == JLANLLEABDC.UnitDelivered || unitState == JLANLLEABDC.Delivering || unitState == JLANLLEABDC.Delivered;

	public JLANLLEABDC unitState
	{
		get
		{
			if (!unlocked)
			{
				return JLANLLEABDC.Locked;
			}
			if (bought && delivering)
			{
				return JLANLLEABDC.Delivering;
			}
			if (bought && deliveryActivationNeeded)
			{
				return JLANLLEABDC.Delivered;
			}
			if (!bought && delivering)
			{
				return JLANLLEABDC.UnitDelivering;
			}
			if (!bought && deliveryActivationNeeded)
			{
				return JLANLLEABDC.UnitDelivered;
			}
			if (!bought)
			{
				return JLANLLEABDC.NotBuyed;
			}
			return JLANLLEABDC.Active;
		}
	}

	public bool unlocked => unlockLevelIndex <= LevelManager.instance.currentLevel.index || bought;

	public bool delivering
	{
		get
		{
			double currentTimestampDouble = Singleton<BeanstalkServerManager>.instance.currentTimestampDouble;
			return currentTimestampDouble < (double)endDeliveryTime;
		}
	}

	public bool deliveryActivationNeeded
	{
		get
		{
			LevelManager.ItemDelivery unitDelivery = LevelManager.instance.data.unitDelivery;
			return GetSheetName() == unitDelivery.itemId && unitDelivery.activationNeeded;
		}
		set
		{
			if (value != deliveryActivationNeeded)
			{
				LevelManager.ItemDelivery unitDelivery = LevelManager.instance.data.unitDelivery;
				unitDelivery.itemId = GetSheetName();
				unitDelivery.activationNeeded = value;
			}
		}
	}

	public bool boughtDeliveringInProgress
	{
		get
		{
			GetArmySlot();
			return deliveryActivationNeeded && delivering;
		}
	}

	public bool canUseInBattle
	{
		get
		{
			LevelManager.SavedArmySlots armySlot = GetArmySlot();
			return (armySlot.equipped && bought) || armySlot.borrowed;
		}
	}

	public bool wasEquipped
	{
		get
		{
			return GetArmySlot().wasEquipped;
		}
		set
		{
			if (value != GetArmySlot().wasEquipped)
			{
				GetArmySlot().wasEquipped = value;
			}
		}
	}

	public bool equipped
	{
		get
		{
			return GetArmySlot().equipped;
		}
		set
		{
			if (value != GetArmySlot().equipped)
			{
				GetArmySlot().equipped = value;
			}
		}
	}

	public bool canBeBought => LevelManager.instance.currentLevel.index >= armyUpgradesRow.CANBEBOUGHT - 1;

	public bool bought
	{
		get
		{
			if (isTutorialUnit)
			{
				if (Singleton<GameController>.instance.isTutorial)
				{
					return GetArmySlot().bought;
				}
				return true;
			}
			return (GetArmySlot().bought && canBeBought) || (unlockLevelIndex == 0 && price == 0 && priceGold == 0) || borrowed || isTutorialUnit;
		}
		set
		{
			if (value != bought)
			{
				GetArmySlot().bought = value;
			}
		}
	}

	public int actualTier
	{
		get
		{
			if (!bought)
			{
				return startTier;
			}
			int tier = GetArmySlot().tier;
			if (tier == 0)
			{
				return startTier;
			}
			return tier;
		}
		private set
		{
			GetArmySlot().tier = value;
		}
	}

	public int actualUnitLevel => bought ? (upgradeSlot.boughtIndex + startUnitLevel) : 0;

	public int unlockTierLevel => GetUnlockLevelForNextTier(actualTier);

	public bool isPromoteToNextTierLocked => unlockTierLevel > LevelManager.instance.currentLevel.displayNumber;

	public bool isNew
	{
		get
		{
			if (isTutorialUnit && Singleton<GameController>.instance.isTutorial)
			{
				return true;
			}
			bool wasAlreadyUsed;
			LevelBehaviour lastBoughtUnit = PlayerAnalytics.instance.GetLastBoughtUnit(out wasAlreadyUsed);
			if (lastBoughtUnit.upgradeSlots == this && !wasAlreadyUsed)
			{
				return true;
			}
			return borrowed;
		}
	}

	public int actualMinUnitLevel => upgradeSlot.minRowForActualTier + startUnitLevel;

	public int actualMaxUnitLevel => upgradeSlot.maxRowForActualTier + startUnitLevel;

	public float actualUpgradeProgress => (float)(actualUnitLevel - actualMinUnitLevel) / (float)(actualMaxUnitLevel - actualMinUnitLevel);

	public bool allUpgradesBought => upgradeSlot.isMaxUpgraded && upgradeSlotSpecial.isMaxUpgraded && upgradeSlotElite.isMaxUpgraded;

	public int numberOfUpgrades => upgradeSlot.maxPower;

	public int maxLevelOfUnit => upgradeSlot.maxPower + startUnitLevel - 1;

	public float upgradesProgress
	{
		get
		{
			int num = (bought ? (upgradeSlot.boughtIndex + 1) : 0);
			return (float)num / (float)numberOfUpgrades;
		}
	}

	public float armyPower => GetArmyPower(upgradeSlot.boughtIndex, upgradeSlotSpecial.boughtIndexAbsolute, actualTier, upgradeSlotElite.boughtIndexAbsolute, upgradeSlotElite.isBought);

	public int armyPowerX10 => GetArmyPowerX10(upgradeSlot.boughtIndex, upgradeSlotSpecial.boughtIndexAbsolute, actualTier, upgradeSlotElite.boughtIndexAbsolute, upgradeSlotElite.isBought);

	public int armyPowerX10Max => GetArmyPowerX10(upgradeSlot.maxIndexInExcel, upgradeSlotSpecial.maxIndexInExcel, 6, upgradeSlotElite.maxIndexInExcel, upgradeSlotElite.isUnlocked);

	public int armyPowerX10NextSlot => GetArmyPowerX10(upgradeSlot.boughtIndex + 1, upgradeSlotSpecial.boughtIndexAbsolute, actualTier, upgradeSlotElite.boughtIndexAbsolute, upgradeSlotElite.isBought);

	public int armyPowerX10NextSpecialSlot => GetArmyPowerX10(upgradeSlot.boughtIndex, upgradeSlotSpecial.boughtIndexAbsolute + 1, actualTier, upgradeSlotElite.boughtIndexAbsolute, upgradeSlotElite.isBought);

	public int armyPowerX10NextEliteSlot => GetArmyPowerX10(upgradeSlot.boughtIndex, upgradeSlotSpecial.boughtIndexAbsolute, actualTier, upgradeSlotElite.boughtIndexAbsolute + 1, upgradeSlotElite.isBought);

	public bool showed
	{
		get
		{
			return GetArmySlot().showed;
		}
		set
		{
			GetArmySlot().showed = true;
		}
	}

	public int boughtIndex => upgradeSlot.boughtIndex;

	public long startDeliveryTime
	{
		get
		{
			LevelManager.ItemDelivery unitDelivery = LevelManager.instance.data.unitDelivery;
			return (!(GetSheetName() != unitDelivery.itemId)) ? unitDelivery.start : 0;
		}
		set
		{
			if (value != startDeliveryTime)
			{
				LevelManager.ItemDelivery unitDelivery = LevelManager.instance.data.unitDelivery;
				unitDelivery.itemId = GetSheetName();
				unitDelivery.start = value;
			}
		}
	}

	public long endDeliveryTime
	{
		get
		{
			LevelManager.ItemDelivery unitDelivery = LevelManager.instance.data.unitDelivery;
			return (!(GetSheetName() != unitDelivery.itemId)) ? unitDelivery.end : 0;
		}
		set
		{
			if (value != endDeliveryTime)
			{
				LevelManager.ItemDelivery unitDelivery = LevelManager.instance.data.unitDelivery;
				unitDelivery.itemId = GetSheetName();
				unitDelivery.end = value;
			}
		}
	}

	public int deliveringSlotId
	{
		get
		{
			LevelManager.ItemDelivery unitDelivery = LevelManager.instance.data.unitDelivery;
			return (!(GetSheetName() != unitDelivery.itemId)) ? unitDelivery.slotId : (-1);
		}
		set
		{
			if (value != deliveringSlotId)
			{
				LevelManager.ItemDelivery unitDelivery = LevelManager.instance.data.unitDelivery;
				unitDelivery.itemId = GetSheetName();
				unitDelivery.slotId = value;
			}
		}
	}

	public UpgradeSlot deliveringSlot
	{
		get
		{
			LevelManager.ItemDelivery unitDelivery = LevelManager.instance.data.unitDelivery;
			if (GetSheetName() == unitDelivery.itemId)
			{
				if (unitDelivery.slotId == 0)
				{
					return upgradeSlot;
				}
				if (unitDelivery.slotId == 1)
				{
					return upgradeSlotSpecial;
				}
			}
			return null;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		upgradeSlot.owner = this;
		upgradeSlotSpecial.owner = this;
		upgradeSlotElite.owner = this;
	}

	public int GetUnlockLevelForNextTier(int tier)
	{
		return GetUnlockLevelForTier(tier + 1);
	}

	public int GetUnlockLevelForTier(int tier)
	{
		if (tier == 1)
		{
			return 1;
		}
		if (tier == 2)
		{
			return armyUpgradesRow.UNLOCKTIER2;
		}
		if (tier == 3)
		{
			return armyUpgradesRow.UNLOCKTIER3;
		}
		if (tier == 4)
		{
			return armyUpgradesRow.UNLOCKTIER4;
		}
		if (tier == 5)
		{
			return armyUpgradesRow.UNLOCKTIER5;
		}
		if (tier == 6)
		{
			return armyUpgradesRow.UNLOCKTIER6;
		}
		if (tier > 6)
		{
			return 999;
		}
		return 0;
	}

	public int GetMaxTierForLevel(int level)
	{
		if (level >= armyUpgradesRow.UNLOCKTIER6)
		{
			return 6;
		}
		if (level >= armyUpgradesRow.UNLOCKTIER5)
		{
			return 5;
		}
		if (level >= armyUpgradesRow.UNLOCKTIER4)
		{
			return 4;
		}
		if (level >= armyUpgradesRow.UNLOCKTIER3)
		{
			return 3;
		}
		if (level >= armyUpgradesRow.UNLOCKTIER2)
		{
			return 2;
		}
		return 1;
	}

	public int GetActualLevelForIndex(int index)
	{
		return index + startUnitLevel;
	}

	public float GetSoldierHpInMechanic(int rowIndex)
	{
		bool flag = excel.HasColumn("SoldierHP");
		rowIndex = Mathf.Clamp(rowIndex, 0, upgradeSlot.maxIndexInExcel);
		return (!flag) ? 0f : ((float)excel.GetValue(rowIndex, "SoldierHP"));
	}

	public float GetArmyPower(int index, int indexAbility, int tier, int indexElite, bool isEliteBought)
	{
		float num = upgradeSlot.BCEGNGNIMHN(index);
		float num2 = upgradeSlotSpecial.BCEGNGNIMHN(indexAbility, tier);
		float num3 = upgradeSlotElite.BCEGNGNIMHN(indexElite, isEliteBought);
		return num + num2 + num3;
	}

	public int GetArmyPowerX10(int index, int indexAbility, int tier, int indexElite, bool isEliteBought)
	{
		return MEJMLNDFDBP.LJDADOKBBNA(10f * GetArmyPower(index, indexAbility, tier, indexElite, isEliteBought));
	}

	public int GetTier(int boughtIndex)
	{
		return (int)excel.GetValue(boughtIndex, "Tier") + 1;
	}

	public void Init(ArmyUpgradesRow row)
	{
		upgradeSlot.owner = this;
		upgradeSlotSpecial.owner = this;
		armyUpgradesRow = row;
		upgradeSlot.mMaxPower = -1;
		upgradeSlot.mMaxRowForActualTier = -1;
		upgradeSlot.mMinRowForActualTier = -1;
		upgradeSlotSpecial.mMaxPower = -1;
		upgradeSlotSpecial.mMaxRowForActualTier = -1;
		upgradeSlotSpecial.mMinRowForActualTier = -1;
	}

	public LevelManager.SavedArmySlots GetArmySlot()
	{
		if (armyUpgradesRow == null)
		{
			armyUpgradesRow = new ArmyUpgradesRow
			{
				NAME = string.Empty
			};
		}
		if (LevelManager.instance.data.savedArmies.TryGetValue(GetSheetName(), out var value))
		{
			return value;
		}
		LevelManager.SavedArmySlots savedArmySlots = new LevelManager.SavedArmySlots();
		savedArmySlots.bought = false;
		savedArmySlots.tier = startTier;
		savedArmySlots.showed = unlockLevelIndex == 0;
		value = savedArmySlots;
		LevelManager.instance.data.savedArmies[GetSheetName()] = value;
		return value;
	}

	public int FindLastRowIndex()
	{
		return upgradeSlot.maxIndexInExcel;
	}

	public int GetLastndexForTier(int tier)
	{
		int num = 0;
		for (int i = 0; i < excel.RowsGeneric.Count; i++)
		{
			int num2 = (int)excel.GetValue(i, "Tier");
			if (num2 < tier && num2 >= 0)
			{
				num++;
			}
		}
		return Mathf.Clamp(num - 1, 0, int.MaxValue);
	}

	private List<TechnologyVisualDefinition> GetVisualDefinitions(UnitUpgrades upgrades)
	{
		if (upgrades.isElite)
		{
			return eliteVisuals;
		}
		if (upgrades.isVeteran)
		{
			return cardVisuals;
		}
		return allVisuals;
	}

	public virtual List<TechnologyVisualDefinition> GetVisuals(UnitUpgrades unitUpgrades)
	{
		List<TechnologyVisualDefinition> list = new List<TechnologyVisualDefinition>();
		list.Add(GetTechnologyVisualDefinition(unitUpgrades.slotUpgradeindex, GetVisualDefinitions(unitUpgrades)));
		return list;
	}

	protected Tuple<string, float[]> StatsFor(UpgradeSlot slot, string identifier, string name)
	{
		Tuple<string, float[]> tuple = new Tuple<string, float[]>();
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		num3 += Convert.ToSingle(excel.GetValue(slot.boughtIndexAbsolute, identifier));
		num += ((slot.boughtIndexAbsolute >= slot.maxIndexInExcel) ? 0f : Convert.ToSingle(excel.GetValue(slot.boughtIndexAbsolute + 1, identifier)));
		int maxIndexInExcel = slot.maxIndexInExcel;
		num2 += Convert.ToSingle(excel.GetValue(maxIndexInExcel, identifier));
		tuple.Value1 = name;
		tuple.Value2 = new float[3] { num3, num2, num };
		return tuple;
	}

	protected Tuple<string, float> StartStatsFor(UpgradeSlot slot, string identifier, string name)
	{
		Tuple<string, float> tuple = new Tuple<string, float>();
		tuple.Value1 = name;
		tuple.Value2 = Convert.ToSingle(excel.GetValue(upgradeSlot.boughtIndexAbsolute, identifier));
		return tuple;
	}

	public virtual List<Tuple<string, float[]>> GetGuiStats(UpgradeSlot slot)
	{
		return new List<Tuple<string, float[]>>();
	}

	public virtual List<Tuple<string, float>> GetGuiStatsStart(UpgradeSlot slot)
	{
		return new List<Tuple<string, float>>();
	}

	public virtual List<Tuple<string, float[]>> GetGuiStatsSpecial(UpgradeSlotSpecial slot)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(StatsFor(slot, "special", "percent"));
		return list;
	}

	public virtual List<Tuple<string, float>> GetGuiStatsSpecialStart(UpgradeSlotSpecial slot)
	{
		List<Tuple<string, float>> list = new List<Tuple<string, float>>();
		list.Add(StartStatsFor(slot, "special", "percent"));
		return list;
	}

	public virtual List<Tuple<string, float[]>> GetGuiStatsElite(UpgradeSlotElite slot)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(StatsFor(slot, "elite", "percent"));
		return list;
	}

	public virtual List<Tuple<string, float>> GetGuiStatsEliteStart(UpgradeSlotElite slot)
	{
		List<Tuple<string, float>> list = new List<Tuple<string, float>>();
		list.Add(StartStatsFor(slot, "elite", "percent"));
		return list;
	}

	public virtual string GetAbilityCurrentValue(UpgradeSlotSpecial slot)
	{
		float iDEBKDPMPGM = slot.guiStatistics[0].Value2[0];
		return MEJMLNDFDBP.JJBMMICPIIG(iDEBKDPMPGM);
	}

	public virtual string GetAbilityMaxValue(UpgradeSlotSpecial slot)
	{
		float iDEBKDPMPGM = slot.guiStatistics[0].Value2[1];
		return MEJMLNDFDBP.JJBMMICPIIG(iDEBKDPMPGM);
	}

	public virtual string GetAbilityStartValue(UpgradeSlotSpecial slot)
	{
		return "0";
	}

	public virtual string GetEliteBuffCurrentValue(UpgradeSlotElite slot)
	{
		float iDEBKDPMPGM = slot.guiStatistics[0].Value2[0];
		return MEJMLNDFDBP.JJBMMICPIIG(iDEBKDPMPGM);
	}

	public virtual string GetEliteBuffMaxValue(UpgradeSlotElite slot)
	{
		float iDEBKDPMPGM = slot.guiStatistics[0].Value2[1];
		return MEJMLNDFDBP.JJBMMICPIIG(iDEBKDPMPGM);
	}

	public virtual string GetEliteBuffStartValue(UpgradeSlotElite slot)
	{
		return "0";
	}

	private string GetPath(Texture2D texture)
	{
		return string.Empty;
	}

	public abstract UnitUpgrades LoadData(LevelBehaviour behaviour, UnitUpgrades? boughtUpgrades = null, FCLADBGKCIA perk = null);

	public UnitUpgrades LoadDataForWarArena(LevelBehaviour behaviour)
	{
		int num = excel.GetRowIndex("WARARENA");
		if (num < 0)
		{
			UnityEngine.Debug.LogError($"{excel.GetType()} doesn't contain data for wararena unit");
			num = 0;
		}
		UnitUpgrades unitUpgrades = new UnitUpgrades(1f);
		unitUpgrades.slotUpgradeindex = num;
		UnitUpgrades result = unitUpgrades;
		LoadData(behaviour, new UnitUpgrades(1f)
		{
			slotUpgradeindex = num
		});
		BehaviourDefinititon behaviourDefinition = behaviour.behaviourDefinition;
		behaviour.behaviourDefinition = behaviourDefinition;
		return result;
	}

	public void LoadDataForCard(LevelBehaviour behaviour, float progress)
	{
		int num = excel.GetRowIndex("CARDS_MIN");
		int num2 = excel.GetRowIndex("CARDS_MAX");
		if (num < 0 || num2 < 0)
		{
			UnityEngine.Debug.LogError($"{excel.GetType()} doesn't contain data for card unit");
			num = 0;
			num2 = 0;
		}
		LoadData(behaviour, new UnitUpgrades(1f)
		{
			slotUpgradeindex = num
		});
		BehaviourDefinititon behaviourDefinition = behaviour.behaviourDefinition;
		LoadData(behaviour, new UnitUpgrades(1f)
		{
			slotUpgradeindex = num2
		});
		BehaviourDefinititon behaviourDefinition2 = behaviour.behaviourDefinition;
		BehaviourDefinititon behaviourDefinition3 = behaviourDefinition.BMLALFLBNKO(behaviourDefinition, behaviourDefinition2, progress);
		behaviour.behaviourDefinition = behaviourDefinition3;
	}

	public string GetSheetName()
	{
		if (string.IsNullOrEmpty(mExcelType))
		{
			mExcelType = excel.GetType().ToString();
		}
		return mExcelType;
	}

	public virtual void NullOpponentVisuals()
	{
		foreach (TechnologyVisualDefinition allVisual in allVisuals)
		{
			allVisual.LPEPPPCBCDG();
		}
		foreach (TechnologyVisualDefinition eliteVisual in eliteVisuals)
		{
			eliteVisual.LPEPPPCBCDG();
		}
	}

	public virtual void NullMineVisuals()
	{
		foreach (TechnologyVisualDefinition allVisual in allVisuals)
		{
			allVisual.LLGPADPJPIF();
		}
		foreach (TechnologyVisualDefinition eliteVisual in eliteVisuals)
		{
			eliteVisual.LLGPADPJPIF();
		}
	}

	public virtual void NullCardVisuals(bool mine, bool opponent)
	{
		foreach (TechnologyVisualDefinition cardVisual in cardVisuals)
		{
			if (mine)
			{
				cardVisual.LLGPADPJPIF();
			}
			if (opponent)
			{
				cardVisual.LPEPPPCBCDG();
			}
		}
	}

	[DebuggerHidden]
	public IEnumerator LoadMineVisualAsync(int boughtIndex, bool bought, List<TechnologyVisualDefinition> definitions)
	{
		JNBLKNMGMBD jNBLKNMGMBD = new JNBLKNMGMBD();
		jNBLKNMGMBD.JMEGHFOKLBF = boughtIndex;
		jNBLKNMGMBD.EDNLBEDPMCM = definitions;
		jNBLKNMGMBD.EFBPOCHCGPB = bought;
		jNBLKNMGMBD.BJGCPDNMHDH = this;
		return jNBLKNMGMBD;
	}

	[DebuggerHidden]
	public IEnumerator LoadOpponentVisualAsync(int boughtIndex, bool bought, List<TechnologyVisualDefinition> definitions)
	{
		NJPCJIKDDAJ nJPCJIKDDAJ = new NJPCJIKDDAJ();
		nJPCJIKDDAJ.JMEGHFOKLBF = boughtIndex;
		nJPCJIKDDAJ.EDNLBEDPMCM = definitions;
		nJPCJIKDDAJ.EFBPOCHCGPB = bought;
		nJPCJIKDDAJ.BJGCPDNMHDH = this;
		return nJPCJIKDDAJ;
	}

	[DebuggerHidden]
	public virtual IEnumerator LoadMineVisualsCoroutine(UnitUpgrades unitUpgrades, bool bought)
	{
		CGMBKNHFEKK cGMBKNHFEKK = new CGMBKNHFEKK();
		cGMBKNHFEKK.PFGLIAHPMCK = unitUpgrades;
		cGMBKNHFEKK.EFBPOCHCGPB = bought;
		cGMBKNHFEKK.BJGCPDNMHDH = this;
		return cGMBKNHFEKK;
	}

	[DebuggerHidden]
	public virtual IEnumerator LoadOponentVisualsCoroutine(UnitUpgrades unitUpgrades, bool bought)
	{
		MJFCEHPBAGM mJFCEHPBAGM = new MJFCEHPBAGM();
		mJFCEHPBAGM.PFGLIAHPMCK = unitUpgrades;
		mJFCEHPBAGM.EFBPOCHCGPB = bought;
		mJFCEHPBAGM.BJGCPDNMHDH = this;
		return mJFCEHPBAGM;
	}

	[DebuggerHidden]
	public virtual IEnumerator LoadMineVisualsCoroutineCards()
	{
		JKLFIKMDAOA jKLFIKMDAOA = new JKLFIKMDAOA();
		jKLFIKMDAOA.BJGCPDNMHDH = this;
		return jKLFIKMDAOA;
	}

	[DebuggerHidden]
	public virtual IEnumerator LoadOpponentVisualsCoroutineCards()
	{
		GDPICKHGNNF gDPICKHGNNF = new GDPICKHGNNF();
		gDPICKHGNNF.BJGCPDNMHDH = this;
		return gDPICKHGNNF;
	}

	public void Buy()
	{
		if (priceGold > 0)
		{
			bought = true;
			return;
		}
		bought = false;
		startDeliveryTime = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		endDeliveryTime = startDeliveryTime + unitDeliveryTime;
		deliveryActivationNeeded = true;
		UnityEngine.Debug.Log("Started delivering |" + GetSheetName() + "| time: " + unitDeliveryTime + "s");
	}

	public void InstantBuyUnit()
	{
		bought = true;
		actualTier = startTier;
		endDeliveryTime = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		deliveryActivationNeeded = false;
	}

	public void ActivateUnit()
	{
		bought = true;
		actualTier = startTier;
		if (priceGold == 0)
		{
			deliveryActivationNeeded = false;
		}
	}

	public void PromoteUnit()
	{
		actualTier++;
		upgradeSlot.mMaxRowForActualTier = -1;
		upgradeSlot.mMinRowForActualTier = -1;
		upgradeSlotSpecial.mMaxRowForActualTier = -1;
		upgradeSlotSpecial.mMinRowForActualTier = -1;
	}

	public TechnologyVisualDefinition GetTechnologyVisualDefinition(int level, List<TechnologyVisualDefinition> visuals)
	{
		TechnologyVisualDefinition result = null;
		if (visuals.Count > 0)
		{
			result = visuals[0];
		}
		foreach (TechnologyVisualDefinition visual in visuals)
		{
			if (visual.level <= level)
			{
				result = visual;
			}
		}
		return result;
	}

	public int GetDisplayLevelForIndex(int indexOfLevel)
	{
		return startUnitLevel + indexOfLevel;
	}

	public bool CanUpgrade(UpgradeSlot upgradeSlot1)
	{
		return excel.RowsGeneric.Count > boughtIndex;
	}

	public virtual void UnloadVisuals()
	{
		foreach (TechnologyVisualDefinition allVisual in allVisuals)
		{
			allVisual.PKFILEOILFD();
		}
		foreach (TechnologyVisualDefinition eliteVisual in eliteVisuals)
		{
			eliteVisual.PKFILEOILFD();
		}
		foreach (TechnologyVisualDefinition cardVisual in cardVisuals)
		{
			cardVisual.PKFILEOILFD();
		}
	}

	public virtual FCLADBGKCIA PerkImplementation(UnitUpgradeDefinition def, FCLADBGKCIA currentPerk)
	{
		return currentPerk;
	}
}
