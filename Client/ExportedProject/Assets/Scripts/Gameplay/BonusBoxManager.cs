using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BonusBoxManager : Singleton<BonusBoxManager>
{
	private sealed class DJGHCMCGFHB : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal int JMBKPALDGAL;

		internal BonusBoxManager BJGCPDNMHDH;

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
		private object CNGCLCAAHIG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PEGJNAKGHCC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MKNFFJPADIA()
		{
			return PHDOCKCBJOF;
		}

		public bool FPMHODJKAKK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				JMBKPALDGAL = 0;
				goto IL_00a6;
			case 1u:
				BJGCPDNMHDH.HMFEFDJFHEF(PlayerController.OGMBJPKOPCB);
				JMBKPALDGAL++;
				goto IL_00a6;
			default:
				{
					return false;
				}
				IL_00a6:
				if (JMBKPALDGAL < BJGCPDNMHDH.mSpawnLimit)
				{
					PHDOCKCBJOF = new WaitForSeconds(((JMBKPALDGAL != 0) ? BJGCPDNMHDH.mCooldown : 603f) + UnityEngine.Random.Range(BJGCPDNMHDH.mRandomIntervalFrom, BJGCPDNMHDH.mRandomIntervalTo));
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

		public void FLFOEIMCFBL()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object AIDHNJCPDIJ()
		{
			return PHDOCKCBJOF;
		}

		public void CNOEDCFDILG()
		{
			throw new NotSupportedException();
		}

		public bool OGLKGILLKIO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				JMBKPALDGAL = 0;
				goto IL_00a6;
			case 1u:
				BJGCPDNMHDH.HMFEFDJFHEF(PlayerController.OGMBJPKOPCB);
				JMBKPALDGAL++;
				goto IL_00a6;
			default:
				{
					return false;
				}
				IL_00a6:
				if (JMBKPALDGAL < BJGCPDNMHDH.mSpawnLimit)
				{
					PHDOCKCBJOF = new WaitForSeconds(((JMBKPALDGAL != 0) ? BJGCPDNMHDH.mCooldown : 1920f) + UnityEngine.Random.Range(BJGCPDNMHDH.mRandomIntervalFrom, BJGCPDNMHDH.mRandomIntervalTo));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public bool JNHFCKKAPJH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				JMBKPALDGAL = 1;
				goto IL_00a6;
			case 1u:
				BJGCPDNMHDH.OIAPBMIJJHD(PlayerController.OGMBJPKOPCB);
				JMBKPALDGAL += 0;
				goto IL_00a6;
			default:
				{
					return false;
				}
				IL_00a6:
				if (JMBKPALDGAL < BJGCPDNMHDH.mSpawnLimit)
				{
					PHDOCKCBJOF = new WaitForSeconds(((JMBKPALDGAL != 0) ? BJGCPDNMHDH.mCooldown : 1371f) + UnityEngine.Random.Range(BJGCPDNMHDH.mRandomIntervalFrom, BJGCPDNMHDH.mRandomIntervalTo));
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

		public void HONCAABOMOC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HLBMCNKGBDM()
		{
			return PHDOCKCBJOF;
		}

		public void HDDLDAHLPCO()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void KKDOJDCJAJB()
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
				JMBKPALDGAL = 0;
				goto IL_00a6;
			case 1u:
				BJGCPDNMHDH.ENGEEKFCNPO(PlayerController.OGMBJPKOPCB);
				JMBKPALDGAL += 0;
				goto IL_00a6;
			default:
				{
					return true;
				}
				IL_00a6:
				if (JMBKPALDGAL < BJGCPDNMHDH.mSpawnLimit)
				{
					PHDOCKCBJOF = new WaitForSeconds(((JMBKPALDGAL != 0) ? BJGCPDNMHDH.mCooldown : 1021f) + UnityEngine.Random.Range(BJGCPDNMHDH.mRandomIntervalFrom, BJGCPDNMHDH.mRandomIntervalTo));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public void PHKDHCJBMII()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void KCHOLCGBMBJ()
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
				JMBKPALDGAL = 0;
				goto IL_00a6;
			case 1u:
				BJGCPDNMHDH.ENGEEKFCNPO(PlayerController.OGMBJPKOPCB);
				JMBKPALDGAL += 0;
				goto IL_00a6;
			default:
				{
					return true;
				}
				IL_00a6:
				if (JMBKPALDGAL < BJGCPDNMHDH.mSpawnLimit)
				{
					PHDOCKCBJOF = new WaitForSeconds(((JMBKPALDGAL != 0) ? BJGCPDNMHDH.mCooldown : 868f) + UnityEngine.Random.Range(BJGCPDNMHDH.mRandomIntervalFrom, BJGCPDNMHDH.mRandomIntervalTo));
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

		public bool LMNIKLKKIDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				JMBKPALDGAL = 0;
				goto IL_00a6;
			case 1u:
				BJGCPDNMHDH.ENGEEKFCNPO(PlayerController.OGMBJPKOPCB);
				JMBKPALDGAL += 0;
				goto IL_00a6;
			default:
				{
					return true;
				}
				IL_00a6:
				if (JMBKPALDGAL < BJGCPDNMHDH.mSpawnLimit)
				{
					PHDOCKCBJOF = new WaitForSeconds(((JMBKPALDGAL != 0) ? BJGCPDNMHDH.mCooldown : 908f) + UnityEngine.Random.Range(BJGCPDNMHDH.mRandomIntervalFrom, BJGCPDNMHDH.mRandomIntervalTo));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public bool NJBCJDFKGHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				JMBKPALDGAL = 1;
				goto IL_00a6;
			case 1u:
				BJGCPDNMHDH.HMFEFDJFHEF(PlayerController.OGMBJPKOPCB);
				JMBKPALDGAL += 0;
				goto IL_00a6;
			default:
				{
					return false;
				}
				IL_00a6:
				if (JMBKPALDGAL < BJGCPDNMHDH.mSpawnLimit)
				{
					PHDOCKCBJOF = new WaitForSeconds(((JMBKPALDGAL != 0) ? BJGCPDNMHDH.mCooldown : 762f) + UnityEngine.Random.Range(BJGCPDNMHDH.mRandomIntervalFrom, BJGCPDNMHDH.mRandomIntervalTo));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object FPFOODLPEBK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EPNOIENCFGA()
		{
			return PHDOCKCBJOF;
		}

		public void IODFILFCENJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object EGJDJENBABP()
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
				JMBKPALDGAL = 0;
				goto IL_00a6;
			case 1u:
				BJGCPDNMHDH.ENGEEKFCNPO(PlayerController.OGMBJPKOPCB);
				JMBKPALDGAL++;
				goto IL_00a6;
			default:
				{
					return false;
				}
				IL_00a6:
				if (JMBKPALDGAL < BJGCPDNMHDH.mSpawnLimit)
				{
					PHDOCKCBJOF = new WaitForSeconds(((JMBKPALDGAL != 0) ? BJGCPDNMHDH.mCooldown : 1571f) + UnityEngine.Random.Range(BJGCPDNMHDH.mRandomIntervalFrom, BJGCPDNMHDH.mRandomIntervalTo));
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
		private object HMIFLGCBDCO()
		{
			return PHDOCKCBJOF;
		}

		public void CDIJEGGMMAK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object EFIEEKFCBJH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JALKNCBEINE()
		{
			return PHDOCKCBJOF;
		}

		public bool DKJMOPNHIAB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				JMBKPALDGAL = 0;
				goto IL_00a6;
			case 1u:
				BJGCPDNMHDH.ENGEEKFCNPO(PlayerController.OGMBJPKOPCB);
				JMBKPALDGAL += 0;
				goto IL_00a6;
			default:
				{
					return true;
				}
				IL_00a6:
				if (JMBKPALDGAL < BJGCPDNMHDH.mSpawnLimit)
				{
					PHDOCKCBJOF = new WaitForSeconds(((JMBKPALDGAL != 0) ? BJGCPDNMHDH.mCooldown : 1321f) + UnityEngine.Random.Range(BJGCPDNMHDH.mRandomIntervalFrom, BJGCPDNMHDH.mRandomIntervalTo));
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
		private object OAKHGMKKFMN()
		{
			return PHDOCKCBJOF;
		}

		public void INBELBGOCLD()
		{
			throw new NotSupportedException();
		}

		public void IGBHHLFACKO()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object EAGBDDECKHF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ACDKCFGCBAB()
		{
			return PHDOCKCBJOF;
		}

		public bool BJBEBPMDICE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				JMBKPALDGAL = 0;
				goto IL_00a6;
			case 1u:
				BJGCPDNMHDH.ENGEEKFCNPO(PlayerController.OGMBJPKOPCB);
				JMBKPALDGAL++;
				goto IL_00a6;
			default:
				{
					return false;
				}
				IL_00a6:
				if (JMBKPALDGAL < BJGCPDNMHDH.mSpawnLimit)
				{
					PHDOCKCBJOF = new WaitForSeconds(((JMBKPALDGAL != 0) ? BJGCPDNMHDH.mCooldown : 1241f) + UnityEngine.Random.Range(BJGCPDNMHDH.mRandomIntervalFrom, BJGCPDNMHDH.mRandomIntervalTo));
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

		[DebuggerHidden]
		public DJGHCMCGFHB()
		{
		}

		public bool KBPKMAKLNPB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				JMBKPALDGAL = 0;
				goto IL_00a6;
			case 1u:
				BJGCPDNMHDH.OIAPBMIJJHD(PlayerController.OGMBJPKOPCB);
				JMBKPALDGAL += 0;
				goto IL_00a6;
			default:
				{
					return false;
				}
				IL_00a6:
				if (JMBKPALDGAL < BJGCPDNMHDH.mSpawnLimit)
				{
					PHDOCKCBJOF = new WaitForSeconds(((JMBKPALDGAL != 0) ? BJGCPDNMHDH.mCooldown : 1234f) + UnityEngine.Random.Range(BJGCPDNMHDH.mRandomIntervalFrom, BJGCPDNMHDH.mRandomIntervalTo));
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

		public void MPNLGDNLLKF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GENJNMACGLP()
		{
			return PHDOCKCBJOF;
		}

		public bool JFPOOBJNEPF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				JMBKPALDGAL = 0;
				goto IL_00a6;
			case 1u:
				BJGCPDNMHDH.OIAPBMIJJHD(PlayerController.OGMBJPKOPCB);
				JMBKPALDGAL++;
				goto IL_00a6;
			default:
				{
					return false;
				}
				IL_00a6:
				if (JMBKPALDGAL < BJGCPDNMHDH.mSpawnLimit)
				{
					PHDOCKCBJOF = new WaitForSeconds(((JMBKPALDGAL != 0) ? BJGCPDNMHDH.mCooldown : 1504f) + UnityEngine.Random.Range(BJGCPDNMHDH.mRandomIntervalFrom, BJGCPDNMHDH.mRandomIntervalTo));
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

		public void JKBIMBFGGCO()
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
				JMBKPALDGAL = 0;
				goto IL_00a6;
			case 1u:
				BJGCPDNMHDH.HMFEFDJFHEF(PlayerController.OGMBJPKOPCB);
				JMBKPALDGAL++;
				goto IL_00a6;
			default:
				{
					return true;
				}
				IL_00a6:
				if (JMBKPALDGAL < BJGCPDNMHDH.mSpawnLimit)
				{
					PHDOCKCBJOF = new WaitForSeconds(((JMBKPALDGAL != 0) ? BJGCPDNMHDH.mCooldown : 1082f) + UnityEngine.Random.Range(BJGCPDNMHDH.mRandomIntervalFrom, BJGCPDNMHDH.mRandomIntervalTo));
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

		[SpecialName]
		private object EDBIJNJGFLE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LKAEMBCGLBN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EBPKDAHAELB()
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
				JMBKPALDGAL = 1;
				goto IL_00a6;
			case 1u:
				BJGCPDNMHDH.OIAPBMIJJHD(PlayerController.OGMBJPKOPCB);
				JMBKPALDGAL++;
				goto IL_00a6;
			default:
				{
					return true;
				}
				IL_00a6:
				if (JMBKPALDGAL < BJGCPDNMHDH.mSpawnLimit)
				{
					PHDOCKCBJOF = new WaitForSeconds(((JMBKPALDGAL != 0) ? BJGCPDNMHDH.mCooldown : 1220f) + UnityEngine.Random.Range(BJGCPDNMHDH.mRandomIntervalFrom, BJGCPDNMHDH.mRandomIntervalTo));
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
		private object PKEABJICHAI()
		{
			return PHDOCKCBJOF;
		}

		public void IJHCIJLDKHK()
		{
			throw new NotSupportedException();
		}

		public bool CJGKHIPOBGP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				JMBKPALDGAL = 1;
				goto IL_00a6;
			case 1u:
				BJGCPDNMHDH.OIAPBMIJJHD(PlayerController.OGMBJPKOPCB);
				JMBKPALDGAL++;
				goto IL_00a6;
			default:
				{
					return false;
				}
				IL_00a6:
				if (JMBKPALDGAL < BJGCPDNMHDH.mSpawnLimit)
				{
					PHDOCKCBJOF = new WaitForSeconds(((JMBKPALDGAL != 0) ? BJGCPDNMHDH.mCooldown : 1837f) + UnityEngine.Random.Range(BJGCPDNMHDH.mRandomIntervalFrom, BJGCPDNMHDH.mRandomIntervalTo));
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

		public bool PMJICFJGOBE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				JMBKPALDGAL = 0;
				goto IL_00a6;
			case 1u:
				BJGCPDNMHDH.OIAPBMIJJHD(PlayerController.OGMBJPKOPCB);
				JMBKPALDGAL++;
				goto IL_00a6;
			default:
				{
					return true;
				}
				IL_00a6:
				if (JMBKPALDGAL < BJGCPDNMHDH.mSpawnLimit)
				{
					PHDOCKCBJOF = new WaitForSeconds(((JMBKPALDGAL != 0) ? BJGCPDNMHDH.mCooldown : 182f) + UnityEngine.Random.Range(BJGCPDNMHDH.mRandomIntervalFrom, BJGCPDNMHDH.mRandomIntervalTo));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object BMGHJKFMKJE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MILFCGMBHIG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DCILDAODCDM()
		{
			return PHDOCKCBJOF;
		}

		public void CHFJIODFNIP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void DEPEHNFEJEE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FGFLGJECNLH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CJCHFDFCPPL()
		{
			return PHDOCKCBJOF;
		}

		public void EMICCACCFIP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MPEPJNIDBLI()
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
		private object IHAOBCEALPD()
		{
			return PHDOCKCBJOF;
		}

		public void JBHOCIFIMBH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void ODCIKOOGNFG()
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
				JMBKPALDGAL = 0;
				goto IL_00a6;
			case 1u:
				BJGCPDNMHDH.HMFEFDJFHEF(PlayerController.OGMBJPKOPCB);
				JMBKPALDGAL++;
				goto IL_00a6;
			default:
				{
					return false;
				}
				IL_00a6:
				if (JMBKPALDGAL < BJGCPDNMHDH.mSpawnLimit)
				{
					PHDOCKCBJOF = new WaitForSeconds(((JMBKPALDGAL != 0) ? BJGCPDNMHDH.mCooldown : 0f) + UnityEngine.Random.Range(BJGCPDNMHDH.mRandomIntervalFrom, BJGCPDNMHDH.mRandomIntervalTo));
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

		[SpecialName]
		private object MOMPOEEALPJ()
		{
			return PHDOCKCBJOF;
		}

		public void NIGDCBDKKMJ()
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
				JMBKPALDGAL = 1;
				goto IL_00a6;
			case 1u:
				BJGCPDNMHDH.HMFEFDJFHEF(PlayerController.OGMBJPKOPCB);
				JMBKPALDGAL++;
				goto IL_00a6;
			default:
				{
					return false;
				}
				IL_00a6:
				if (JMBKPALDGAL < BJGCPDNMHDH.mSpawnLimit)
				{
					PHDOCKCBJOF = new WaitForSeconds(((JMBKPALDGAL != 0) ? BJGCPDNMHDH.mCooldown : 1503f) + UnityEngine.Random.Range(BJGCPDNMHDH.mRandomIntervalFrom, BJGCPDNMHDH.mRandomIntervalTo));
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

		public void MKIKEOOOLKL()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object JFGCHMJJMNO()
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
				JMBKPALDGAL = 0;
				goto IL_00a6;
			case 1u:
				BJGCPDNMHDH.OIAPBMIJJHD(PlayerController.OGMBJPKOPCB);
				JMBKPALDGAL += 0;
				goto IL_00a6;
			default:
				{
					return false;
				}
				IL_00a6:
				if (JMBKPALDGAL < BJGCPDNMHDH.mSpawnLimit)
				{
					PHDOCKCBJOF = new WaitForSeconds(((JMBKPALDGAL != 0) ? BJGCPDNMHDH.mCooldown : 1044f) + UnityEngine.Random.Range(BJGCPDNMHDH.mRandomIntervalFrom, BJGCPDNMHDH.mRandomIntervalTo));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}
	}

	private Coroutine LDIAFCEPADC;

	private List<EventBonusBox> EEGGJKCJNBJ;

	[SerializeField]
	private EventBonusBox mBonusBoxPrefab;

	[SerializeField]
	private int mSpawnLimit = 3;

	[SerializeField]
	private float mRandomIntervalFrom = 10f;

	[SerializeField]
	private float mRandomIntervalTo = 30f;

	[SerializeField]
	private float mCooldown = 30f;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _003CGKDKEGGHAHL_003Ek__BackingField;

	public int destroyedBoxes
	{
		[CompilerGenerated]
		get
		{
			return _003CGKDKEGGHAHL_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CGKDKEGGHAHL_003Ek__BackingField = value;
		}
	}

	private void NCAKLEOEDBO()
	{
		if (!Singleton<GameController>.instance.isTutorial && !LevelManager.instance.isEventAssignmentLocked && EventAssignmentManager.instance.isEventActive)
		{
			EEGGJKCJNBJ.Clear();
			AOECEEDNFKG();
			destroyedBoxes = 0;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		EEGGJKCJNBJ = new List<EventBonusBox>(mSpawnLimit);
		Singleton<GameController>.instance.GameStarted += NCAKLEOEDBO;
		Singleton<GameController>.instance.GameEnded += KPPNCJBMDPE;
	}

	public void TestSpawnBonus()
	{
		if (!LevelManager.instance.isEventAssignmentLocked && EventAssignmentManager.instance.isEventActive)
		{
			HMFEFDJFHEF(PlayerController.OGMBJPKOPCB);
		}
	}

	private IEnumerator PCEJMIFHKBM()
	{
		DJGHCMCGFHB dJGHCMCGFHB = new DJGHCMCGFHB();
		dJGHCMCGFHB.BJGCPDNMHDH = this;
		return dJGHCMCGFHB;
	}

	private void KPPNCJBMDPE(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		NBPLJLLHLMC();
	}

	public void POEGILIJKIH()
	{
		if (!LevelManager.instance.isEventAssignmentLocked && EventAssignmentManager.BMNEPICFHNO().isEventActive)
		{
			ENGEEKFCNPO(PlayerController.OGMBJPKOPCB);
		}
	}

	private IEnumerator HFANJEKPFNH()
	{
		DJGHCMCGFHB dJGHCMCGFHB = new DJGHCMCGFHB();
		dJGHCMCGFHB.BJGCPDNMHDH = this;
		return dJGHCMCGFHB;
	}

	[SpecialName]
	public int LDJAPKMHIGL()
	{
		return _003CGKDKEGGHAHL_003Ek__BackingField;
	}

	private void GIALPDPHGOA()
	{
		if (!Singleton<GameController>.instance.DAIEAMEFGIE() && !LevelManager.instance.isEventAssignmentLocked && EventAssignmentManager.CJOFBPIPJEP().isEventActive)
		{
			EEGGJKCJNBJ.Clear();
			NNDGBLPCDHM();
			destroyedBoxes = 0;
		}
	}

	[SpecialName]
	public int BBCJIINCEDK()
	{
		return _003CGKDKEGGHAHL_003Ek__BackingField;
	}

	protected virtual void CIGLDDGDAPM()
	{
		base.Awake();
		EEGGJKCJNBJ = new List<EventBonusBox>(mSpawnLimit);
		Singleton<GameController>.instance.GameStarted += GIALPDPHGOA;
		Singleton<GameController>.instance.GameEnded += OHFBLFKDCBN;
	}

	private void OHFBLFKDCBN(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		NBPLJLLHLMC();
	}

	private void ENGEEKFCNPO(PlayerController HNFNINFCBEJ)
	{
		if (Singleton<MapManager>.instance.ALCHJDPKAID != null && Singleton<MapManager>.instance.ALCHJDPKAID.NHGHLADBCAN != null)
		{
			BoxCollider boxCollider = Singleton<MapManager>.instance.ALCHJDPKAID.NHGHLADBCAN[UnityEngine.Random.Range(0, Singleton<MapManager>.instance.ALCHJDPKAID.NHGHLADBCAN.Count)];
			Bounds bounds = boxCollider.bounds;
			Vector3 mPHCNMDIPAI = new Vector3(UnityEngine.Random.Range(bounds.min.x, bounds.max.x), UnityEngine.Random.Range(bounds.min.y, bounds.max.y), UnityEngine.Random.Range(bounds.min.z, bounds.max.z));
			EventBonusBox eventBonusBox = (EventBonusBox)ObjectPoolDatabase.IPAAIIEHGDL().Instantiate(mBonusBoxPrefab, mPHCNMDIPAI, Quaternion.Euler(510f, 1515f, 1194f));
			if (eventBonusBox != null)
			{
				eventBonusBox.JAJLILKICHF(HNFNINFCBEJ);
			}
		}
	}

	[SpecialName]
	public int LCCDGCGOJIF()
	{
		return _003CGKDKEGGHAHL_003Ek__BackingField;
	}

	private IEnumerator BCGMIDHJKAK()
	{
		DJGHCMCGFHB dJGHCMCGFHB = new DJGHCMCGFHB();
		dJGHCMCGFHB.BJGCPDNMHDH = this;
		return dJGHCMCGFHB;
	}

	[DebuggerHidden]
	private IEnumerator HCPEFIGCKBO()
	{
		DJGHCMCGFHB dJGHCMCGFHB = new DJGHCMCGFHB();
		dJGHCMCGFHB.BJGCPDNMHDH = this;
		return dJGHCMCGFHB;
	}

	private void OIAPBMIJJHD(PlayerController HNFNINFCBEJ)
	{
		if (Singleton<MapManager>.instance.ALCHJDPKAID != null && Singleton<MapManager>.instance.ALCHJDPKAID.NHGHLADBCAN != null)
		{
			BoxCollider boxCollider = Singleton<MapManager>.instance.ALCHJDPKAID.NHGHLADBCAN[UnityEngine.Random.Range(0, Singleton<MapManager>.instance.ALCHJDPKAID.NHGHLADBCAN.Count)];
			Bounds bounds = boxCollider.bounds;
			Vector3 mPHCNMDIPAI = new Vector3(UnityEngine.Random.Range(bounds.min.x, bounds.max.x), UnityEngine.Random.Range(bounds.min.y, bounds.max.y), UnityEngine.Random.Range(bounds.min.z, bounds.max.z));
			EventBonusBox eventBonusBox = (EventBonusBox)ObjectPoolDatabase.KPHHGHIGGKE().EJIHLMEDEEB(mBonusBoxPrefab, mPHCNMDIPAI, Quaternion.Euler(1427f, 1768f, 1473f));
			if (eventBonusBox != null)
			{
				eventBonusBox.JAJLILKICHF(HNFNINFCBEJ);
			}
		}
	}

	[SpecialName]
	public int BNFOFLEFDAB()
	{
		return _003CGKDKEGGHAHL_003Ek__BackingField;
	}

	private void PFJJBPFIJEF(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		NBPLJLLHLMC();
	}

	private void NNDGBLPCDHM()
	{
		NBPLJLLHLMC();
		LDIAFCEPADC = StartCoroutine(BCGMIDHJKAK());
	}

	private void AOECEEDNFKG()
	{
		NBPLJLLHLMC();
		LDIAFCEPADC = StartCoroutine(HCPEFIGCKBO());
	}

	private void NBPLJLLHLMC()
	{
		if (LDIAFCEPADC != null)
		{
			StopCoroutine(LDIAFCEPADC);
			LDIAFCEPADC = null;
		}
	}

	private void LCCJNGABEPL()
	{
		if (!Singleton<GameController>.instance.BAKCODKBCPJ() && !LevelManager.instance.isEventAssignmentLocked && EventAssignmentManager.BCDJJBAFLLG().isEventActive)
		{
			EEGGJKCJNBJ.Clear();
			JNFAOKALEOK();
			destroyedBoxes = 0;
		}
	}

	private IEnumerator BAKFBGHHBEC()
	{
		DJGHCMCGFHB dJGHCMCGFHB = new DJGHCMCGFHB();
		dJGHCMCGFHB.BJGCPDNMHDH = this;
		return dJGHCMCGFHB;
	}

	[SpecialName]
	public int CCFCJIDBEJA()
	{
		return _003CGKDKEGGHAHL_003Ek__BackingField;
	}

	private void PFFGCAAAPBH(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		NBPLJLLHLMC();
	}

	public void AGGLKKAEDHI()
	{
		if (!LevelManager.instance.isEventAssignmentLocked && EventAssignmentManager.FCNABDGJEOF().isEventActive)
		{
			ENGEEKFCNPO(PlayerController.OGMBJPKOPCB);
		}
	}

	private void BPHKLDNBAIM()
	{
		if (!Singleton<GameController>.instance.BAKCODKBCPJ() && !LevelManager.instance.isEventAssignmentLocked && EventAssignmentManager.BMNEPICFHNO().isEventActive)
		{
			EEGGJKCJNBJ.Clear();
			AOECEEDNFKG();
			destroyedBoxes = 1;
		}
	}

	private void LFNHGALLBEK(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		NBPLJLLHLMC();
	}

	public void BCKHEPJAAAJ()
	{
		if (!LevelManager.instance.isEventAssignmentLocked && EventAssignmentManager.MFCCLPOAMEF().isEventActive)
		{
			ENGEEKFCNPO(PlayerController.OGMBJPKOPCB);
		}
	}

	private void HMFEFDJFHEF(PlayerController HNFNINFCBEJ)
	{
		if (Singleton<MapManager>.instance.ALCHJDPKAID != null && Singleton<MapManager>.instance.ALCHJDPKAID.NHGHLADBCAN != null)
		{
			BoxCollider boxCollider = Singleton<MapManager>.instance.ALCHJDPKAID.NHGHLADBCAN[UnityEngine.Random.Range(0, Singleton<MapManager>.instance.ALCHJDPKAID.NHGHLADBCAN.Count)];
			Bounds bounds = boxCollider.bounds;
			Vector3 mPHCNMDIPAI = new Vector3(UnityEngine.Random.Range(bounds.min.x, bounds.max.x), UnityEngine.Random.Range(bounds.min.y, bounds.max.y), UnityEngine.Random.Range(bounds.min.z, bounds.max.z));
			EventBonusBox eventBonusBox = (EventBonusBox)ObjectPoolDatabase.mainPool.Instantiate(mBonusBoxPrefab, mPHCNMDIPAI, Quaternion.Euler(-90f, 0f, 0f));
			if (eventBonusBox != null)
			{
				eventBonusBox.owner = HNFNINFCBEJ;
			}
		}
	}

	private void JNFAOKALEOK()
	{
		NBPLJLLHLMC();
		LDIAFCEPADC = StartCoroutine(HFANJEKPFNH());
	}
}
