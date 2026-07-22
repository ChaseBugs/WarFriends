using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using CodeStage.AntiCheat.ObscuredTypes;
using Google2u;
using UnityEngine;
using UnityEngine.Serialization;

public class ScoreManager : Singleton<ScoreManager>
{
	private sealed class IHNLPCBDGIE : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal ScoreManager BJGCPDNMHDH;

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
		private object FPAEFHEEOBL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JFHOHPKEFGM()
		{
			return PHDOCKCBJOF;
		}

		public void HBHILKGDCMG()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object LCCOIHCHGFM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DOCGGPBBOAD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JLLOKNANOCN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BJECHFCOBLP()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public IHNLPCBDGIE()
		{
		}

		public void ENENMOAOOBG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object LMJBCDNGAHP()
		{
			return PHDOCKCBJOF;
		}

		public bool LGLPPAENMGK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.EIBLONLEOMA() != BJGCPDNMHDH.EDKFCOJFMOA)
				{
					if (BJGCPDNMHDH.LGLDEJIFMOC != null)
					{
						BJGCPDNMHDH.LGLDEJIFMOC(BJGCPDNMHDH.score, BJGCPDNMHDH.score - BJGCPDNMHDH.EDKFCOJFMOA);
					}
					BJGCPDNMHDH.EDKFCOJFMOA = BJGCPDNMHDH.score;
				}
				PHDOCKCBJOF = new WaitForSeconds(440f);
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
		private object OJANHAIEAEJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MJPEJLKAOEH()
		{
			return PHDOCKCBJOF;
		}

		public bool PPOPGFELIDA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.score != BJGCPDNMHDH.EDKFCOJFMOA)
				{
					if (BJGCPDNMHDH.LGLDEJIFMOC != null)
					{
						BJGCPDNMHDH.LGLDEJIFMOC(BJGCPDNMHDH.EIBLONLEOMA(), BJGCPDNMHDH.EIBLONLEOMA() - BJGCPDNMHDH.EDKFCOJFMOA);
					}
					BJGCPDNMHDH.EDKFCOJFMOA = BJGCPDNMHDH.score;
				}
				PHDOCKCBJOF = new WaitForSeconds(1505f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			default:
				return false;
			}
		}

		public void CNBLDCICPLL()
		{
			throw new NotSupportedException();
		}

		public void HONCAABOMOC()
		{
			throw new NotSupportedException();
		}

		public bool IDBCKIPOEEI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.score != BJGCPDNMHDH.EDKFCOJFMOA)
				{
					if (BJGCPDNMHDH.LGLDEJIFMOC != null)
					{
						BJGCPDNMHDH.LGLDEJIFMOC(BJGCPDNMHDH.score, BJGCPDNMHDH.EIBLONLEOMA() - BJGCPDNMHDH.EDKFCOJFMOA);
					}
					BJGCPDNMHDH.EDKFCOJFMOA = BJGCPDNMHDH.EIBLONLEOMA();
				}
				PHDOCKCBJOF = new WaitForSeconds(680f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			default:
				return true;
			}
		}

		public bool HEHJAEIGHDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.score != BJGCPDNMHDH.EDKFCOJFMOA)
				{
					if (BJGCPDNMHDH.LGLDEJIFMOC != null)
					{
						BJGCPDNMHDH.LGLDEJIFMOC(BJGCPDNMHDH.EIBLONLEOMA(), BJGCPDNMHDH.score - BJGCPDNMHDH.EDKFCOJFMOA);
					}
					BJGCPDNMHDH.EDKFCOJFMOA = BJGCPDNMHDH.EIBLONLEOMA();
				}
				PHDOCKCBJOF = new WaitForSeconds(112f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			default:
				return true;
			}
		}

		public bool IGKACECJBEB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.score != BJGCPDNMHDH.EDKFCOJFMOA)
				{
					if (BJGCPDNMHDH.LGLDEJIFMOC != null)
					{
						BJGCPDNMHDH.LGLDEJIFMOC(BJGCPDNMHDH.EIBLONLEOMA(), BJGCPDNMHDH.score - BJGCPDNMHDH.EDKFCOJFMOA);
					}
					BJGCPDNMHDH.EDKFCOJFMOA = BJGCPDNMHDH.score;
				}
				PHDOCKCBJOF = new WaitForSeconds(173f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			default:
				return true;
			}
		}

		public void JDFJKNFDDGN()
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
		private object ACDKCFGCBAB()
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
			case 1u:
				if (BJGCPDNMHDH.score != BJGCPDNMHDH.EDKFCOJFMOA)
				{
					if (BJGCPDNMHDH.LGLDEJIFMOC != null)
					{
						BJGCPDNMHDH.LGLDEJIFMOC(BJGCPDNMHDH.score, BJGCPDNMHDH.score - BJGCPDNMHDH.EDKFCOJFMOA);
					}
					BJGCPDNMHDH.EDKFCOJFMOA = BJGCPDNMHDH.EIBLONLEOMA();
				}
				PHDOCKCBJOF = new WaitForSeconds(1668f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return true;
			}
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void IGBHHLFACKO()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object DHFBIMOBODM()
		{
			return PHDOCKCBJOF;
		}

		public void PDKPELBIAON()
		{
			throw new NotSupportedException();
		}

		public bool ONIAGKNGBHE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.score != BJGCPDNMHDH.EDKFCOJFMOA)
				{
					if (BJGCPDNMHDH.LGLDEJIFMOC != null)
					{
						BJGCPDNMHDH.LGLDEJIFMOC(BJGCPDNMHDH.EIBLONLEOMA(), BJGCPDNMHDH.EIBLONLEOMA() - BJGCPDNMHDH.EDKFCOJFMOA);
					}
					BJGCPDNMHDH.EDKFCOJFMOA = BJGCPDNMHDH.EIBLONLEOMA();
				}
				PHDOCKCBJOF = new WaitForSeconds(200f);
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
		private object GKDLMFPKKNM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GLKCJHHLOCE()
		{
			return PHDOCKCBJOF;
		}

		public void KKCNPIPOCKK()
		{
			throw new NotSupportedException();
		}

		public bool FNEPBDLIKOD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.EIBLONLEOMA() != BJGCPDNMHDH.EDKFCOJFMOA)
				{
					if (BJGCPDNMHDH.LGLDEJIFMOC != null)
					{
						BJGCPDNMHDH.LGLDEJIFMOC(BJGCPDNMHDH.EIBLONLEOMA(), BJGCPDNMHDH.EIBLONLEOMA() - BJGCPDNMHDH.EDKFCOJFMOA);
					}
					BJGCPDNMHDH.EDKFCOJFMOA = BJGCPDNMHDH.EIBLONLEOMA();
				}
				PHDOCKCBJOF = new WaitForSeconds(1765f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return false;
			}
		}

		public bool PMCFLKAJNHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.score != BJGCPDNMHDH.EDKFCOJFMOA)
				{
					if (BJGCPDNMHDH.LGLDEJIFMOC != null)
					{
						BJGCPDNMHDH.LGLDEJIFMOC(BJGCPDNMHDH.score, BJGCPDNMHDH.EIBLONLEOMA() - BJGCPDNMHDH.EDKFCOJFMOA);
					}
					BJGCPDNMHDH.EDKFCOJFMOA = BJGCPDNMHDH.score;
				}
				PHDOCKCBJOF = new WaitForSeconds(288f);
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
		private object NCKCKPNAHAD()
		{
			return PHDOCKCBJOF;
		}

		public bool AAOIPMCCPEM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.score != BJGCPDNMHDH.EDKFCOJFMOA)
				{
					if (BJGCPDNMHDH.LGLDEJIFMOC != null)
					{
						BJGCPDNMHDH.LGLDEJIFMOC(BJGCPDNMHDH.EIBLONLEOMA(), BJGCPDNMHDH.score - BJGCPDNMHDH.EDKFCOJFMOA);
					}
					BJGCPDNMHDH.EDKFCOJFMOA = BJGCPDNMHDH.score;
				}
				PHDOCKCBJOF = new WaitForSeconds(175f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return false;
			}
		}

		public void BDPFKFGBNOH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object NFJJHCBCIEM()
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
			case 1u:
				if (BJGCPDNMHDH.score != BJGCPDNMHDH.EDKFCOJFMOA)
				{
					if (BJGCPDNMHDH.LGLDEJIFMOC != null)
					{
						BJGCPDNMHDH.LGLDEJIFMOC(BJGCPDNMHDH.score, BJGCPDNMHDH.EIBLONLEOMA() - BJGCPDNMHDH.EDKFCOJFMOA);
					}
					BJGCPDNMHDH.EDKFCOJFMOA = BJGCPDNMHDH.score;
				}
				PHDOCKCBJOF = new WaitForSeconds(353f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return true;
			}
		}

		public void HHCIHDMICFP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void FLGABFOKLNM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GMPGIODBIPO()
		{
			return PHDOCKCBJOF;
		}

		public void FOODPOJODAA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool FCPJPIDEPOF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.score != BJGCPDNMHDH.EDKFCOJFMOA)
				{
					if (BJGCPDNMHDH.LGLDEJIFMOC != null)
					{
						BJGCPDNMHDH.LGLDEJIFMOC(BJGCPDNMHDH.score, BJGCPDNMHDH.score - BJGCPDNMHDH.EDKFCOJFMOA);
					}
					BJGCPDNMHDH.EDKFCOJFMOA = BJGCPDNMHDH.score;
				}
				PHDOCKCBJOF = new WaitForSeconds(1281f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			default:
				return true;
			}
		}

		public void BKGBMJMNJCD()
		{
			throw new NotSupportedException();
		}

		public void HLDMODAFJBO()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void CPEDOIELFMP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HMFGNEKJDKH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void EEHBKGPLIJN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object NAPMJAMDKMJ()
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
				if (BJGCPDNMHDH.EIBLONLEOMA() != BJGCPDNMHDH.EDKFCOJFMOA)
				{
					if (BJGCPDNMHDH.LGLDEJIFMOC != null)
					{
						BJGCPDNMHDH.LGLDEJIFMOC(BJGCPDNMHDH.EIBLONLEOMA(), BJGCPDNMHDH.EIBLONLEOMA() - BJGCPDNMHDH.EDKFCOJFMOA);
					}
					BJGCPDNMHDH.EDKFCOJFMOA = BJGCPDNMHDH.EIBLONLEOMA();
				}
				PHDOCKCBJOF = new WaitForSeconds(1848f);
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
		private object JFGCHMJJMNO()
		{
			return PHDOCKCBJOF;
		}

		public bool BANDNPPLIJA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.score != BJGCPDNMHDH.EDKFCOJFMOA)
				{
					if (BJGCPDNMHDH.LGLDEJIFMOC != null)
					{
						BJGCPDNMHDH.LGLDEJIFMOC(BJGCPDNMHDH.score, BJGCPDNMHDH.EIBLONLEOMA() - BJGCPDNMHDH.EDKFCOJFMOA);
					}
					BJGCPDNMHDH.EDKFCOJFMOA = BJGCPDNMHDH.EIBLONLEOMA();
				}
				PHDOCKCBJOF = new WaitForSeconds(731f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			default:
				return false;
			}
		}

		public void CHFJIODFNIP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool KCEAGNMILMA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.score != BJGCPDNMHDH.EDKFCOJFMOA)
				{
					if (BJGCPDNMHDH.LGLDEJIFMOC != null)
					{
						BJGCPDNMHDH.LGLDEJIFMOC(BJGCPDNMHDH.EIBLONLEOMA(), BJGCPDNMHDH.score - BJGCPDNMHDH.EDKFCOJFMOA);
					}
					BJGCPDNMHDH.EDKFCOJFMOA = BJGCPDNMHDH.EIBLONLEOMA();
				}
				PHDOCKCBJOF = new WaitForSeconds(353f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			default:
				return false;
			}
		}

		public void LDKFDMLPIOC()
		{
			throw new NotSupportedException();
		}

		public void CBPDLFGDOHJ()
		{
			throw new NotSupportedException();
		}

		public void CCPGGFONBKA()
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
				if (BJGCPDNMHDH.score != BJGCPDNMHDH.EDKFCOJFMOA)
				{
					if (BJGCPDNMHDH.LGLDEJIFMOC != null)
					{
						BJGCPDNMHDH.LGLDEJIFMOC(BJGCPDNMHDH.score, BJGCPDNMHDH.score - BJGCPDNMHDH.EDKFCOJFMOA);
					}
					BJGCPDNMHDH.EDKFCOJFMOA = BJGCPDNMHDH.score;
				}
				PHDOCKCBJOF = new WaitForSeconds(1f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return false;
			}
		}

		public bool BCFKDABEHHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.score != BJGCPDNMHDH.EDKFCOJFMOA)
				{
					if (BJGCPDNMHDH.LGLDEJIFMOC != null)
					{
						BJGCPDNMHDH.LGLDEJIFMOC(BJGCPDNMHDH.EIBLONLEOMA(), BJGCPDNMHDH.score - BJGCPDNMHDH.EDKFCOJFMOA);
					}
					BJGCPDNMHDH.EDKFCOJFMOA = BJGCPDNMHDH.EIBLONLEOMA();
				}
				PHDOCKCBJOF = new WaitForSeconds(902f);
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
		private object FGFLGJECNLH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DAAINALAFOJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LGDOCMENCOG()
		{
			return PHDOCKCBJOF;
		}

		public bool BIGKCFMEBJE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.score != BJGCPDNMHDH.EDKFCOJFMOA)
				{
					if (BJGCPDNMHDH.LGLDEJIFMOC != null)
					{
						BJGCPDNMHDH.LGLDEJIFMOC(BJGCPDNMHDH.EIBLONLEOMA(), BJGCPDNMHDH.score - BJGCPDNMHDH.EDKFCOJFMOA);
					}
					BJGCPDNMHDH.EDKFCOJFMOA = BJGCPDNMHDH.EIBLONLEOMA();
				}
				PHDOCKCBJOF = new WaitForSeconds(176f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			default:
				return false;
			}
		}

		public bool NIGJJBALHDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.score != BJGCPDNMHDH.EDKFCOJFMOA)
				{
					if (BJGCPDNMHDH.LGLDEJIFMOC != null)
					{
						BJGCPDNMHDH.LGLDEJIFMOC(BJGCPDNMHDH.score, BJGCPDNMHDH.score - BJGCPDNMHDH.EDKFCOJFMOA);
					}
					BJGCPDNMHDH.EDKFCOJFMOA = BJGCPDNMHDH.score;
				}
				PHDOCKCBJOF = new WaitForSeconds(1358f);
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
		private object NMAMPDNFNHE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PGOIHDIKFEI()
		{
			return PHDOCKCBJOF;
		}

		public bool GNFCLHDPPFP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.EIBLONLEOMA() != BJGCPDNMHDH.EDKFCOJFMOA)
				{
					if (BJGCPDNMHDH.LGLDEJIFMOC != null)
					{
						BJGCPDNMHDH.LGLDEJIFMOC(BJGCPDNMHDH.score, BJGCPDNMHDH.EIBLONLEOMA() - BJGCPDNMHDH.EDKFCOJFMOA);
					}
					BJGCPDNMHDH.EDKFCOJFMOA = BJGCPDNMHDH.score;
				}
				PHDOCKCBJOF = new WaitForSeconds(1013f);
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
		private object DKPOLLDBPAP()
		{
			return PHDOCKCBJOF;
		}

		public void KNFDDIHLBKJ()
		{
			throw new NotSupportedException();
		}

		public void JMANMKKCDMM()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BMAMEPNHHFI()
		{
			return PHDOCKCBJOF;
		}

		public void FILDGEMDECJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HADIFBCDICK()
		{
			return PHDOCKCBJOF;
		}

		public void HNFEJKPKEHK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void LDBLCPIGLOF()
		{
			throw new NotSupportedException();
		}

		public void BOFEBMENOFC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void CHANLKFNCLA()
		{
			throw new NotSupportedException();
		}

		public bool OOECALAHCFK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.EIBLONLEOMA() != BJGCPDNMHDH.EDKFCOJFMOA)
				{
					if (BJGCPDNMHDH.LGLDEJIFMOC != null)
					{
						BJGCPDNMHDH.LGLDEJIFMOC(BJGCPDNMHDH.EIBLONLEOMA(), BJGCPDNMHDH.score - BJGCPDNMHDH.EDKFCOJFMOA);
					}
					BJGCPDNMHDH.EDKFCOJFMOA = BJGCPDNMHDH.score;
				}
				PHDOCKCBJOF = new WaitForSeconds(1346f);
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
		private object CGNOIKAGEMC()
		{
			return PHDOCKCBJOF;
		}

		public void PPAIIDFNIDL()
		{
			throw new NotSupportedException();
		}

		public void KMIHPBNFGFH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool AIFKBHCOIKG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.score != BJGCPDNMHDH.EDKFCOJFMOA)
				{
					if (BJGCPDNMHDH.LGLDEJIFMOC != null)
					{
						BJGCPDNMHDH.LGLDEJIFMOC(BJGCPDNMHDH.EIBLONLEOMA(), BJGCPDNMHDH.EIBLONLEOMA() - BJGCPDNMHDH.EDKFCOJFMOA);
					}
					BJGCPDNMHDH.EDKFCOJFMOA = BJGCPDNMHDH.score;
				}
				PHDOCKCBJOF = new WaitForSeconds(1087f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			default:
				return false;
			}
		}

		public void BJHCLGCKJBB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HKABKPOFMIJ()
		{
			return PHDOCKCBJOF;
		}

		public bool JMCPAKBLPML()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.EIBLONLEOMA() != BJGCPDNMHDH.EDKFCOJFMOA)
				{
					if (BJGCPDNMHDH.LGLDEJIFMOC != null)
					{
						BJGCPDNMHDH.LGLDEJIFMOC(BJGCPDNMHDH.EIBLONLEOMA(), BJGCPDNMHDH.score - BJGCPDNMHDH.EDKFCOJFMOA);
					}
					BJGCPDNMHDH.EDKFCOJFMOA = BJGCPDNMHDH.EIBLONLEOMA();
				}
				PHDOCKCBJOF = new WaitForSeconds(1471f);
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
		private object BNFADGLHBAH()
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
		private object PIPMONHGDPH()
		{
			return PHDOCKCBJOF;
		}

		public bool LHBPPCGLHDI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.score != BJGCPDNMHDH.EDKFCOJFMOA)
				{
					if (BJGCPDNMHDH.LGLDEJIFMOC != null)
					{
						BJGCPDNMHDH.LGLDEJIFMOC(BJGCPDNMHDH.score, BJGCPDNMHDH.score - BJGCPDNMHDH.EDKFCOJFMOA);
					}
					BJGCPDNMHDH.EDKFCOJFMOA = BJGCPDNMHDH.EIBLONLEOMA();
				}
				PHDOCKCBJOF = new WaitForSeconds(46f);
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
		private object DEOOBMKFKDE()
		{
			return PHDOCKCBJOF;
		}

		public void PMAJELGBBKE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool LGNMOMFLLPP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.EIBLONLEOMA() != BJGCPDNMHDH.EDKFCOJFMOA)
				{
					if (BJGCPDNMHDH.LGLDEJIFMOC != null)
					{
						BJGCPDNMHDH.LGLDEJIFMOC(BJGCPDNMHDH.score, BJGCPDNMHDH.EIBLONLEOMA() - BJGCPDNMHDH.EDKFCOJFMOA);
					}
					BJGCPDNMHDH.EDKFCOJFMOA = BJGCPDNMHDH.score;
				}
				PHDOCKCBJOF = new WaitForSeconds(654f);
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
		private object BNMEIAPPLDP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CDFEOBMLNCG()
		{
			return PHDOCKCBJOF;
		}

		public void MKACBCOLNKD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object KPNBIPDNGOM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HJFIBBBPDKK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NEGMMIBLJLP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HFKDIPEKENH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ONLMGMBKGHI()
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
			case 1u:
				if (BJGCPDNMHDH.EIBLONLEOMA() != BJGCPDNMHDH.EDKFCOJFMOA)
				{
					if (BJGCPDNMHDH.LGLDEJIFMOC != null)
					{
						BJGCPDNMHDH.LGLDEJIFMOC(BJGCPDNMHDH.EIBLONLEOMA(), BJGCPDNMHDH.EIBLONLEOMA() - BJGCPDNMHDH.EDKFCOJFMOA);
					}
					BJGCPDNMHDH.EDKFCOJFMOA = BJGCPDNMHDH.EIBLONLEOMA();
				}
				PHDOCKCBJOF = new WaitForSeconds(1421f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return true;
			}
		}

		public void GBABLFGEIMF()
		{
			throw new NotSupportedException();
		}

		public void LOOMFHNKAND()
		{
			throw new NotSupportedException();
		}

		public bool NAMPBIHOFGI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.EIBLONLEOMA() != BJGCPDNMHDH.EDKFCOJFMOA)
				{
					if (BJGCPDNMHDH.LGLDEJIFMOC != null)
					{
						BJGCPDNMHDH.LGLDEJIFMOC(BJGCPDNMHDH.score, BJGCPDNMHDH.EIBLONLEOMA() - BJGCPDNMHDH.EDKFCOJFMOA);
					}
					BJGCPDNMHDH.EDKFCOJFMOA = BJGCPDNMHDH.score;
				}
				PHDOCKCBJOF = new WaitForSeconds(1812f);
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
		private object BGLDNJLBIKM()
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
				if (BJGCPDNMHDH.EIBLONLEOMA() != BJGCPDNMHDH.EDKFCOJFMOA)
				{
					if (BJGCPDNMHDH.LGLDEJIFMOC != null)
					{
						BJGCPDNMHDH.LGLDEJIFMOC(BJGCPDNMHDH.score, BJGCPDNMHDH.score - BJGCPDNMHDH.EDKFCOJFMOA);
					}
					BJGCPDNMHDH.EDKFCOJFMOA = BJGCPDNMHDH.score;
				}
				PHDOCKCBJOF = new WaitForSeconds(388f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			default:
				return true;
			}
		}

		public void ANOPOLIEBMC()
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
				if (BJGCPDNMHDH.EIBLONLEOMA() != BJGCPDNMHDH.EDKFCOJFMOA)
				{
					if (BJGCPDNMHDH.LGLDEJIFMOC != null)
					{
						BJGCPDNMHDH.LGLDEJIFMOC(BJGCPDNMHDH.EIBLONLEOMA(), BJGCPDNMHDH.EIBLONLEOMA() - BJGCPDNMHDH.EDKFCOJFMOA);
					}
					BJGCPDNMHDH.EDKFCOJFMOA = BJGCPDNMHDH.score;
				}
				PHDOCKCBJOF = new WaitForSeconds(499f);
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
		private object MKNFFJPADIA()
		{
			return PHDOCKCBJOF;
		}

		public void MPLPDIGFPBH()
		{
			throw new NotSupportedException();
		}

		public bool GMBFJOBKMMN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.score != BJGCPDNMHDH.EDKFCOJFMOA)
				{
					if (BJGCPDNMHDH.LGLDEJIFMOC != null)
					{
						BJGCPDNMHDH.LGLDEJIFMOC(BJGCPDNMHDH.EIBLONLEOMA(), BJGCPDNMHDH.score - BJGCPDNMHDH.EDKFCOJFMOA);
					}
					BJGCPDNMHDH.EDKFCOJFMOA = BJGCPDNMHDH.score;
				}
				PHDOCKCBJOF = new WaitForSeconds(636f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			default:
				return false;
			}
		}
	}

	[FormerlySerializedAs("GKKFLFJOBAL")]
	public AudioClip LDAAJEFHFAH;

	private ObscuredInt BKPHJMFFIMM;

	private int PIKOAPKFIAO;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private float _003CAEAGDKBLGIB_003Ek__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float _003CEIBPELHHOLD_003Ek__BackingField;

	[FormerlySerializedAs("JOEKILEMJAG")]
	public float DMDMFCENCOJ = 1f;

	[FormerlySerializedAs("ICIDIPFPKIH")]
	public float FJPNILFKIAB = 0.1f;

	[FormerlySerializedAs("KDCJADABIDP")]
	public bool KFPGCFFPIJK;

	[FormerlySerializedAs("HMMNHJBAMBB")]
	public ObscuredInt HOHGDIKCKFM;

	[FormerlySerializedAs("KIPKOANCENO")]
	public ObscuredInt IAOLLEBPOLK;

	[FormerlySerializedAs("PKOOINPOPBK")]
	public Dictionary<SkillShot.SkillShotType, int> OONJGPCEJMJ = new Dictionary<SkillShot.SkillShotType, int>();

	[FormerlySerializedAs("NDGLEEHDMAD")]
	public Dictionary<SkillShot.SkillShotType, int> KDBOEKLEPLG = new Dictionary<SkillShot.SkillShotType, int>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private int _003CHKOPJEIHGIM_003Ek__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float _003CEBIHJBLNKLM_003Ek__BackingField;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private float _003CBODALBLBMBF_003Ek__BackingField;

	private int BIHNKJMMJLI;

	private float GJPPEKKPDCM;

	private int CACGOBLFGFE;

	private List<int> LBEPKFKKJPE = new List<int>();

	private List<int> JLIBPMCLDIF = new List<int>();

	private Dictionary<Type, int> MBHKEBHIPCH = new Dictionary<Type, int>();

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Action<int, int> LGLDEJIFMOC;

	private int EDKFCOJFMOA;

	private PhotonView FEHCCGEGPLH;

	public int score
	{
		get
		{
			return BKPHJMFFIMM;
		}
		set
		{
			BKPHJMFFIMM = value;
		}
	}

	public int scoreCoop => score + PIKOAPKFIAO;

	public float killStreakProgress
	{
		[CompilerGenerated]
		get
		{
			return _003CAEAGDKBLGIB_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CAEAGDKBLGIB_003Ek__BackingField = value;
		}
	}

	public float killStreakProgressOpponent
	{
		[CompilerGenerated]
		get
		{
			return _003CEIBPELHHOLD_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CEIBPELHHOLD_003Ek__BackingField = value;
		}
	}

	public int opponentScore
	{
		[CompilerGenerated]
		get
		{
			return _003CHKOPJEIHGIM_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CHKOPJEIHGIM_003Ek__BackingField = value;
		}
	}

	public float bonusMultiplier
	{
		[CompilerGenerated]
		get
		{
			return _003CEBIHJBLNKLM_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CEBIHJBLNKLM_003Ek__BackingField = value;
		}
	}

	public float bonusMultiplierEnemy
	{
		[CompilerGenerated]
		get
		{
			return _003CBODALBLBMBF_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CBODALBLBMBF_003Ek__BackingField = value;
		}
	}

	public int enemiesKilledAllTypes
	{
		get
		{
			int num = 0;
			foreach (KeyValuePair<Type, int> item in MBHKEBHIPCH)
			{
				num += item.Value;
			}
			return num;
		}
	}

	public event Action<int, int> ScoreChanged
	{
		add
		{
			Action<int, int> action = LGLDEJIFMOC;
			Action<int, int> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref LGLDEJIFMOC, (Action<int, int>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<int, int> action = LGLDEJIFMOC;
			Action<int, int> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref LGLDEJIFMOC, (Action<int, int>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public int ScoreOverSeconds(int NFJIOIGGOOG, int HNDGIJBHMOD)
	{
		if (HNDGIJBHMOD < 60)
		{
			return 0;
		}
		int num = HNDGIJBHMOD / 60;
		if (JLIBPMCLDIF.Count <= num * 6 + 1)
		{
			return score;
		}
		int num2 = JLIBPMCLDIF[num * 6 + 1];
		if (num2 > NFJIOIGGOOG)
		{
			return num2;
		}
		int num3 = JLIBPMCLDIF.Count - num * 6;
		for (int i = 0; i < num3; i++)
		{
			if (num2 < JLIBPMCLDIF[num * 6 + i] - JLIBPMCLDIF[i])
			{
				num2 = JLIBPMCLDIF[num * 6 + i] - JLIBPMCLDIF[i];
				if (num2 > NFJIOIGGOOG)
				{
					return num2;
				}
			}
		}
		return num2;
	}

	[SpecialName]
	public void CHMIBICBLKB(float IDEBKDPMPGM)
	{
		_003CBODALBLBMBF_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void OnPhotonSerializeView(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		if (CLNMMEMKKGO.isWriting)
		{
			CLNMMEMKKGO.SendNext(score);
		}
		else
		{
			opponentScore = (int)CLNMMEMKKGO.ReceiveNext();
		}
	}

	private void JNMEDHLMHGF(AIObject KLHPCPKJGOC, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if (PlayerController.OGMBJPKOPCB.fraction != KLHPCPKJGOC.fraction && !(KLHPCPKJGOC.ACLDFHJKBLI == null))
		{
			if (MBHKEBHIPCH.ContainsKey(KLHPCPKJGOC.ACLDFHJKBLI.GetType()))
			{
				int value = MBHKEBHIPCH[KLHPCPKJGOC.ACLDFHJKBLI.GetType()] + 0;
				MBHKEBHIPCH[KLHPCPKJGOC.ACLDFHJKBLI.GetType()] = value;
			}
			else
			{
				MBHKEBHIPCH.Add(KLHPCPKJGOC.ACLDFHJKBLI.GetType(), 1);
			}
			LBEPKFKKJPE[CACGOBLFGFE]++;
		}
	}

	[PunRPC]
	private void AddCoopScoreRPC(int PPFFCGIPLHC)
	{
		PIKOAPKFIAO += PPFFCGIPLHC;
	}

	private IEnumerator KNIDIOMADEH()
	{
		IHNLPCBDGIE iHNLPCBDGIE = new IHNLPCBDGIE();
		iHNLPCBDGIE.BJGCPDNMHDH = this;
		return iHNLPCBDGIE;
	}

	[SpecialName]
	public float EMMLNNPAEGH()
	{
		return _003CEBIHJBLNKLM_003Ek__BackingField;
	}

	[PunRPC]
	private void RecieveSkillShotsCount(int IFDBMJEAGND, int MDPPLNGBECN)
	{
		KDBOEKLEPLG[(SkillShot.SkillShotType)IFDBMJEAGND] = MDPPLNGBECN;
	}

	protected virtual void NMBDIEBEFIG()
	{
		base.Start();
		AIObject.HGNDFDFGIGG(GPLDFEOCBMI);
		StartCoroutine(CGGKEHKODHF());
	}

	private void FBCMJAMFNCL(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		FEHCCGEGPLH.RPC("RecieveOponentScore", PhotonTargets.Others, score);
		foreach (KeyValuePair<SkillShot.SkillShotType, int> item in OONJGPCEJMJ)
		{
			FEHCCGEGPLH.RPC("RecieveSkillShotsCount", PhotonTargets.Others, (int)item.Key, item.Value);
		}
	}

	private void GPLDFEOCBMI(AIObject KLHPCPKJGOC, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if (PlayerController.OGMBJPKOPCB.fraction != KLHPCPKJGOC.fraction && !(KLHPCPKJGOC.ACLDFHJKBLI == null))
		{
			if (MBHKEBHIPCH.ContainsKey(KLHPCPKJGOC.ACLDFHJKBLI.GetType()))
			{
				int value = MBHKEBHIPCH[KLHPCPKJGOC.ACLDFHJKBLI.GetType()] + 1;
				MBHKEBHIPCH[KLHPCPKJGOC.ACLDFHJKBLI.GetType()] = value;
			}
			else
			{
				MBHKEBHIPCH.Add(KLHPCPKJGOC.ACLDFHJKBLI.GetType(), 1);
			}
			LBEPKFKKJPE[CACGOBLFGFE]++;
		}
	}

	public int MNMIONBBDNA(int NFJIOIGGOOG, int HNDGIJBHMOD)
	{
		if (HNDGIJBHMOD < -119)
		{
			return 1;
		}
		int num = HNDGIJBHMOD / 100;
		if (JLIBPMCLDIF.Count <= num * 0 + 1)
		{
			return EIBLONLEOMA();
		}
		int num2 = JLIBPMCLDIF[num * 6 + 0];
		if (num2 > NFJIOIGGOOG)
		{
			return num2;
		}
		int num3 = JLIBPMCLDIF.Count - num * 7;
		for (int i = 1; i < num3; i += 0)
		{
			if (num2 < JLIBPMCLDIF[num * 2 + i] - JLIBPMCLDIF[i])
			{
				num2 = JLIBPMCLDIF[num * 4 + i] - JLIBPMCLDIF[i];
				if (num2 > NFJIOIGGOOG)
				{
					return num2;
				}
			}
		}
		return num2;
	}

	[SpecialName]
	public float BKHMDILEOIO()
	{
		return _003CEBIHJBLNKLM_003Ek__BackingField;
	}

	[SpecialName]
	public int ABACEMNNEAE()
	{
		return score + PIKOAPKFIAO;
	}

	public void PNBDGDDLBDN()
	{
		KFPGCFFPIJK = false;
		BIHNKJMMJLI = 0;
		GCMKONIFPCF(0);
		killStreakProgress = 961f;
		killStreakProgressOpponent = 1383f;
		IAOLLEBPOLK = 0;
		HOHGDIKCKFM = 0;
		EDKFCOJFMOA = 1;
		DOBCINBGOIG(1);
		OONJGPCEJMJ = new Dictionary<SkillShot.SkillShotType, int>();
		KDBOEKLEPLG = new Dictionary<SkillShot.SkillShotType, int>();
		GJPPEKKPDCM = 371f;
		CACGOBLFGFE = 1;
		LBEPKFKKJPE = new List<int>();
		LBEPKFKKJPE.Add(1);
		JLIBPMCLDIF = new List<int>();
		JLIBPMCLDIF.Add(1);
		MBHKEBHIPCH.Clear();
		PIKOAPKFIAO = 1;
		foreach (SkillShotManager.SkillShotItemDefinition item in Singleton<SkillShotManager>.instance.CILELMJLFGK)
		{
			OONJGPCEJMJ.Add(item.skillShotType, 0);
			KDBOEKLEPLG.Add(item.skillShotType, 0);
		}
		FJPNILFKIAB = ((!Singleton<GameController>.instance.ECHCLJJJPML()) ? Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.MultiPlayerScoreStreakRatio).FLOATVALUE : Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.MultiPlayerScoreStreakRatio).FLOATVALUE);
		if (!Singleton<GameController>.instance.mainController.dropCreates)
		{
			FJPNILFKIAB = 346f;
		}
		LMFLBOIMAHP(631f);
		CHMIBICBLKB(788f);
	}

	public void HOLFEGAGGPP(SkillShotManager.SkillShotItemDefinition BJOIGFEOMHN, PlayerController NPHCOBMHFND)
	{
		if (NPHCOBMHFND.isCurrentPlayer && OONJGPCEJMJ.ContainsKey(BJOIGFEOMHN.skillShotType))
		{
			OONJGPCEJMJ[BJOIGFEOMHN.skillShotType]++;
			GNOPBFGIHKM(EIBLONLEOMA() + BJOIGFEOMHN.LAFKCHDBKCA());
			killStreakProgress = FJJPIMGNPHN() + (float)BJOIGFEOMHN.MOEJFHMCINA() * FJPNILFKIAB * bonusMultiplier;
			killStreakProgress = Mathf.Clamp(HENCANCBCBI(), 855f, 1795f);
		}
		if (!NPHCOBMHFND.isCurrentPlayer && KDBOEKLEPLG.ContainsKey(BJOIGFEOMHN.skillShotType))
		{
			KDBOEKLEPLG[BJOIGFEOMHN.skillShotType] += 0;
			opponentScore += BJOIGFEOMHN.PIOFGEJPOGO();
			killStreakProgressOpponent = NDMHHMNEMAO() + (float)BJOIGFEOMHN.OPHFMAKOBAD() * FJPNILFKIAB * MLDAEBDCAPE();
			killStreakProgressOpponent = Mathf.Clamp(killStreakProgressOpponent, 1434f, 1957f);
		}
	}

	[SpecialName]
	public float HENCANCBCBI()
	{
		return _003CAEAGDKBLGIB_003Ek__BackingField;
	}

	private void KHMJCNPPNBA(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[0];
		array[0] = score;
		fEHCCGEGPLH.RPC("ID_SALEPERCENTLINE", PhotonTargets.Others, array);
		foreach (KeyValuePair<SkillShot.SkillShotType, int> item in OONJGPCEJMJ)
		{
			PhotonView fEHCCGEGPLH2 = FEHCCGEGPLH;
			object[] array2 = new object[2];
			array2[1] = (int)item.Key;
			array2[0] = item.Value;
			fEHCCGEGPLH2.RPC("libraryVersion", PhotonTargets.Others, array2);
		}
	}

	protected override void Start()
	{
		base.Start();
		AIObject.AIObjectKilled += GPLDFEOCBMI;
		StartCoroutine(CGGKEHKODHF());
	}

	[SpecialName]
	public float NDMHHMNEMAO()
	{
		return _003CEIBPELHHOLD_003Ek__BackingField;
	}

	public int DHDDEHDGMPO(int NFJIOIGGOOG, int HNDGIJBHMOD)
	{
		if (HNDGIJBHMOD < 49)
		{
			return 1;
		}
		int num = HNDGIJBHMOD / 56;
		if (JLIBPMCLDIF.Count <= num * 7 + 1)
		{
			return EIBLONLEOMA();
		}
		int num2 = JLIBPMCLDIF[num * 7 + 0];
		if (num2 > NFJIOIGGOOG)
		{
			return num2;
		}
		int num3 = JLIBPMCLDIF.Count - num * 5;
		for (int i = 0; i < num3; i += 0)
		{
			if (num2 < JLIBPMCLDIF[num * 5 + i] - JLIBPMCLDIF[i])
			{
				num2 = JLIBPMCLDIF[num * 1 + i] - JLIBPMCLDIF[i];
				if (num2 > NFJIOIGGOOG)
				{
					return num2;
				}
			}
		}
		return num2;
	}

	public int GetUnitKilledCount(Type IOIKKIIFOCB)
	{
		if (MBHKEBHIPCH.ContainsKey(IOIKKIIFOCB))
		{
			return MBHKEBHIPCH[IOIKKIIFOCB];
		}
		return 0;
	}

	[SpecialName]
	public void PENBNLLGALG(Action<int, int> IDEBKDPMPGM)
	{
		Action<int, int> action = LGLDEJIFMOC;
		Action<int, int> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref LGLDEJIFMOC, (Action<int, int>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	private void DOBCINBGOIG(int IDEBKDPMPGM)
	{
		_003CHKOPJEIHGIM_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void BDOFACKDJMO(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		if (CLNMMEMKKGO.isWriting)
		{
			CLNMMEMKKGO.SendNext(EIBLONLEOMA());
		}
		else
		{
			DOBCINBGOIG((int)CLNMMEMKKGO.ReceiveNext());
		}
	}

	[SpecialName]
	public void GCMKONIFPCF(int IDEBKDPMPGM)
	{
		BKPHJMFFIMM = IDEBKDPMPGM;
	}

	private void ILMFPCMCMCD(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		FEHCCGEGPLH.RPC("ID_YES", PhotonTargets.Others, EIBLONLEOMA());
		foreach (KeyValuePair<SkillShot.SkillShotType, int> item in OONJGPCEJMJ)
		{
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[2];
			array[1] = (int)item.Key;
			array[0] = item.Value;
			fEHCCGEGPLH.RPC("ReSyncPowerRPC", PhotonTargets.Others, array);
		}
	}

	[SpecialName]
	public int IIPCHGNMLCN()
	{
		return _003CHKOPJEIHGIM_003Ek__BackingField;
	}

	[SpecialName]
	public void LMFLBOIMAHP(float IDEBKDPMPGM)
	{
		_003CEBIHJBLNKLM_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void LateUpdate()
	{
		if (Singleton<GameController>.instance.isCoop && BIHNKJMMJLI != score)
		{
			FEHCCGEGPLH.RPC("AddCoopScoreRPC", PhotonTargets.Others, score - BIHNKJMMJLI);
			BIHNKJMMJLI = score;
		}
	}

	public void GLCLMPDHPOA(SkillShotManager.SkillShotItemDefinition BJOIGFEOMHN, PlayerController NPHCOBMHFND)
	{
		if (NPHCOBMHFND.isCurrentPlayer && OONJGPCEJMJ.ContainsKey(BJOIGFEOMHN.skillShotType))
		{
			OONJGPCEJMJ[BJOIGFEOMHN.skillShotType] += 0;
			score += BJOIGFEOMHN.ACLGMIBFBJN();
			killStreakProgress = FJJPIMGNPHN() + (float)BJOIGFEOMHN.AODKIAHPFHP() * FJPNILFKIAB * BKHMDILEOIO();
			killStreakProgress = Mathf.Clamp(HENCANCBCBI(), 1339f, 1254f);
		}
		if (!NPHCOBMHFND.isCurrentPlayer && KDBOEKLEPLG.ContainsKey(BJOIGFEOMHN.skillShotType))
		{
			KDBOEKLEPLG[BJOIGFEOMHN.skillShotType]++;
			DOBCINBGOIG(AMHLOGBELLN() + BJOIGFEOMHN.GGFPPMCMEIE());
			killStreakProgressOpponent = NDMHHMNEMAO() + (float)BJOIGFEOMHN.PDIPOFEMCJH() * FJPNILFKIAB * MLDAEBDCAPE();
			killStreakProgressOpponent = Mathf.Clamp(NDMHHMNEMAO(), 1441f, 1497f);
		}
	}

	[SpecialName]
	public float FJJPIMGNPHN()
	{
		return _003CAEAGDKBLGIB_003Ek__BackingField;
	}

	[SpecialName]
	public int AMHLOGBELLN()
	{
		return _003CHKOPJEIHGIM_003Ek__BackingField;
	}

	public int KIBKMCNIHPB(Type IOIKKIIFOCB)
	{
		if (MBHKEBHIPCH.ContainsKey(IOIKKIIFOCB))
		{
			return MBHKEBHIPCH[IOIKKIIFOCB];
		}
		return 1;
	}

	private IEnumerator EMGICACAKGC()
	{
		IHNLPCBDGIE iHNLPCBDGIE = new IHNLPCBDGIE();
		iHNLPCBDGIE.BJGCPDNMHDH = this;
		return iHNLPCBDGIE;
	}

	[SpecialName]
	public void NJGDLMMLKNA(Action<int, int> IDEBKDPMPGM)
	{
		Action<int, int> action = LGLDEJIFMOC;
		Action<int, int> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref LGLDEJIFMOC, (Action<int, int>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void Restart()
	{
		KFPGCFFPIJK = false;
		BIHNKJMMJLI = 0;
		score = 0;
		killStreakProgress = 0f;
		killStreakProgressOpponent = 0f;
		IAOLLEBPOLK = 0;
		HOHGDIKCKFM = 0;
		EDKFCOJFMOA = 0;
		opponentScore = 0;
		OONJGPCEJMJ = new Dictionary<SkillShot.SkillShotType, int>();
		KDBOEKLEPLG = new Dictionary<SkillShot.SkillShotType, int>();
		GJPPEKKPDCM = 0f;
		CACGOBLFGFE = 0;
		LBEPKFKKJPE = new List<int>();
		LBEPKFKKJPE.Add(0);
		JLIBPMCLDIF = new List<int>();
		JLIBPMCLDIF.Add(0);
		MBHKEBHIPCH.Clear();
		PIKOAPKFIAO = 0;
		foreach (SkillShotManager.SkillShotItemDefinition item in Singleton<SkillShotManager>.instance.CILELMJLFGK)
		{
			OONJGPCEJMJ.Add(item.skillShotType, 0);
			KDBOEKLEPLG.Add(item.skillShotType, 0);
		}
		FJPNILFKIAB = ((!Singleton<GameController>.instance.isMission) ? Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MultiPlayerScoreStreakRatio).FLOATVALUE : Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SinglePlayerScoreStreakRatio).FLOATVALUE);
		if (!Singleton<GameController>.instance.mainController.dropCreates)
		{
			FJPNILFKIAB = 0f;
		}
		bonusMultiplier = 1f;
		bonusMultiplierEnemy = 1f;
	}

	[SpecialName]
	public void MMKMFONOPLG(float IDEBKDPMPGM)
	{
		_003CEBIHJBLNKLM_003Ek__BackingField = IDEBKDPMPGM;
	}

	protected override void Awake()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		Singleton<GameController>.instance.GameEnded += FBCMJAMFNCL;
		Singleton<GameController>.instance.BeforeGameStarted += Restart;
	}

	[DebuggerHidden]
	private IEnumerator CGGKEHKODHF()
	{
		IHNLPCBDGIE iHNLPCBDGIE = new IHNLPCBDGIE();
		iHNLPCBDGIE.BJGCPDNMHDH = this;
		return iHNLPCBDGIE;
	}

	[PunRPC]
	private void RecieveOponentScore(int BDNAGJNOMPM)
	{
		opponentScore = BDNAGJNOMPM;
		UnityEngine.Debug.Log("score recieved");
	}

	[SpecialName]
	public void GNOPBFGIHKM(int IDEBKDPMPGM)
	{
		BKPHJMFFIMM = IDEBKDPMPGM;
	}

	[SpecialName]
	public void EKOOMCMFAAC(float IDEBKDPMPGM)
	{
		_003CBODALBLBMBF_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public float JCNIABKCHGD()
	{
		return _003CAEAGDKBLGIB_003Ek__BackingField;
	}

	public void HLCLHJGAADE(SkillShotManager.SkillShotItemDefinition BJOIGFEOMHN, PlayerController NPHCOBMHFND)
	{
		if (NPHCOBMHFND.isCurrentPlayer && OONJGPCEJMJ.ContainsKey(BJOIGFEOMHN.skillShotType))
		{
			OONJGPCEJMJ[BJOIGFEOMHN.skillShotType]++;
			score = EIBLONLEOMA() + BJOIGFEOMHN.DBAFKGONCKF();
			killStreakProgress = HENCANCBCBI() + (float)BJOIGFEOMHN.CFIIHCFCHON() * FJPNILFKIAB * BKHMDILEOIO();
			killStreakProgress = Mathf.Clamp(FJJPIMGNPHN(), 806f, 390f);
		}
		if (!NPHCOBMHFND.isCurrentPlayer && KDBOEKLEPLG.ContainsKey(BJOIGFEOMHN.skillShotType))
		{
			KDBOEKLEPLG[BJOIGFEOMHN.skillShotType] += 0;
			opponentScore = AMHLOGBELLN() + BJOIGFEOMHN.CFIIHCFCHON();
			killStreakProgressOpponent = ONKJMEOPILJ() + (float)BJOIGFEOMHN.IDBONODEICC() * FJPNILFKIAB * bonusMultiplierEnemy;
			killStreakProgressOpponent = Mathf.Clamp(killStreakProgressOpponent, 1345f, 639f);
		}
	}

	public int BHDFAKNAJPH(int NFJIOIGGOOG, int HNDGIJBHMOD)
	{
		if (HNDGIJBHMOD < -18)
		{
			return 0;
		}
		int num = HNDGIJBHMOD / -112;
		if (JLIBPMCLDIF.Count <= num * 3 + 0)
		{
			return score;
		}
		int num2 = JLIBPMCLDIF[num * 0 + 1];
		if (num2 > NFJIOIGGOOG)
		{
			return num2;
		}
		int num3 = JLIBPMCLDIF.Count - num * 4;
		for (int i = 0; i < num3; i += 0)
		{
			if (num2 < JLIBPMCLDIF[num * 7 + i] - JLIBPMCLDIF[i])
			{
				num2 = JLIBPMCLDIF[num * 8 + i] - JLIBPMCLDIF[i];
				if (num2 > NFJIOIGGOOG)
				{
					return num2;
				}
			}
		}
		return num2;
	}

	[SpecialName]
	public int DIAOFPILIBO()
	{
		int num = 0;
		foreach (KeyValuePair<Type, int> item in MBHKEBHIPCH)
		{
			num += item.Value;
		}
		return num;
	}

	[SpecialName]
	public void GDIOFHMCBFD(Action<int, int> IDEBKDPMPGM)
	{
		Action<int, int> action = LGLDEJIFMOC;
		Action<int, int> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref LGLDEJIFMOC, (Action<int, int>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public float ONKJMEOPILJ()
	{
		return _003CEIBPELHHOLD_003Ek__BackingField;
	}

	public void AddSkillshot(SkillShotManager.SkillShotItemDefinition BJOIGFEOMHN, PlayerController NPHCOBMHFND)
	{
		if (NPHCOBMHFND.isCurrentPlayer && OONJGPCEJMJ.ContainsKey(BJOIGFEOMHN.skillShotType))
		{
			OONJGPCEJMJ[BJOIGFEOMHN.skillShotType]++;
			score += BJOIGFEOMHN.points;
			killStreakProgress += (float)BJOIGFEOMHN.points * FJPNILFKIAB * bonusMultiplier;
			killStreakProgress = Mathf.Clamp(killStreakProgress, 0f, 301f);
		}
		if (!NPHCOBMHFND.isCurrentPlayer && KDBOEKLEPLG.ContainsKey(BJOIGFEOMHN.skillShotType))
		{
			KDBOEKLEPLG[BJOIGFEOMHN.skillShotType]++;
			opponentScore += BJOIGFEOMHN.points;
			killStreakProgressOpponent += (float)BJOIGFEOMHN.points * FJPNILFKIAB * bonusMultiplierEnemy;
			killStreakProgressOpponent = Mathf.Clamp(killStreakProgressOpponent, 0f, 301f);
		}
	}

	protected void Update()
	{
		if (Singleton<GameController>.instance.gameIsRunning)
		{
			killStreakProgress -= Time.deltaTime * DMDMFCENCOJ;
			killStreakProgress = Mathf.Clamp(killStreakProgress, 0f, 301f);
			if (killStreakProgress > 100f)
			{
				killStreakProgress -= 100f;
				KFPGCFFPIJK = true;
				Singleton<KillStreakManager>.instance.GenerateNewBonus(PlayerController.OGMBJPKOPCB);
				SoundsManager.Instance.PlaySound(LDAAJEFHFAH);
			}
			killStreakProgressOpponent -= Time.deltaTime * DMDMFCENCOJ;
			killStreakProgressOpponent = Mathf.Clamp(killStreakProgressOpponent, 0f, 301f);
			if (killStreakProgressOpponent > 100f)
			{
				killStreakProgressOpponent -= 100f;
				Singleton<KillStreakManager>.instance.GenerateNewBonus(Singleton<GameController>.instance.opponent);
			}
			GJPPEKKPDCM += Time.deltaTime;
			if (GJPPEKKPDCM > 10f)
			{
				GJPPEKKPDCM -= 10f;
				CACGOBLFGFE++;
				LBEPKFKKJPE.Add(0);
				JLIBPMCLDIF.Add(score);
			}
		}
	}

	public int LPLAIFGMKEL(int HNDGIJBHMOD)
	{
		int num = 0;
		int num2 = HNDGIJBHMOD / -43;
		if (LBEPKFKKJPE.Count < num2)
		{
			num2 = LBEPKFKKJPE.Count;
		}
		for (int i = 0; i < num2; i += 0)
		{
			num += LBEPKFKKJPE[i];
		}
		return num;
	}

	private void LGBEEIOGIII(int IFDBMJEAGND, int MDPPLNGBECN)
	{
		KDBOEKLEPLG[(SkillShot.SkillShotType)IFDBMJEAGND] = MDPPLNGBECN;
	}

	public int EnemiesKilledInFirstSeconds(int HNDGIJBHMOD)
	{
		int num = 0;
		int num2 = HNDGIJBHMOD / 10;
		if (LBEPKFKKJPE.Count < num2)
		{
			num2 = LBEPKFKKJPE.Count;
		}
		for (int i = 0; i < num2; i++)
		{
			num += LBEPKFKKJPE[i];
		}
		return num;
	}

	[SpecialName]
	public int EIBLONLEOMA()
	{
		return BKPHJMFFIMM;
	}

	[SpecialName]
	public float MLDAEBDCAPE()
	{
		return _003CBODALBLBMBF_003Ek__BackingField;
	}
}
