using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Google2u;

public class UpgradeSlotsVehicle<T> : UpgradeSlotsMechanical<T> where T : Google2uComponentBase
{
	private sealed class PKIINPFKGDD : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal LevelBehaviour FAJOCOIFFOA;

		internal bool EFBPOCHCGPB;

		internal UnitUpgrades PFGLIAHPMCK;

		internal UpgradeSlotsVehicle<T> BJGCPDNMHDH;

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

		[SpecialName]
		private object CNGCLCAAHIG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PJOAMPDDGAM()
		{
			return PHDOCKCBJOF;
		}

		public void BCIPEBNJONK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object PKEABJICHAI()
		{
			return PHDOCKCBJOF;
		}

		public bool KBPKMAKLNPB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				FAJOCOIFFOA = LevelManager.instance.behaviours[0];
				if (EFBPOCHCGPB)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(FAJOCOIFFOA.PrepareVisualsForCardCoroutine(true, false));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.ICKAKNNBANK(PFGLIAHPMCK, EFBPOCHCGPB));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void FLFOEIMCFBL()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool IDBCKIPOEEI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				FAJOCOIFFOA = LevelManager.instance.behaviours[1];
				if (EFBPOCHCGPB)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(FAJOCOIFFOA.PrepareVisualsForCardCoroutine(false, false));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.ICKAKNNBANK(PFGLIAHPMCK, EFBPOCHCGPB));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object LKAEMBCGLBN()
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
				FAJOCOIFFOA = LevelManager.instance.behaviours[0];
				if (EFBPOCHCGPB)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(FAJOCOIFFOA.PrepareVisualsForCardCoroutine(false, false));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.ICKAKNNBANK(PFGLIAHPMCK, EFBPOCHCGPB));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object MLDIMIPJMDD()
		{
			return PHDOCKCBJOF;
		}

		public void NPIDJAPKFLN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void NPKGNIGNPKG()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object AHFIDCCJHKE()
		{
			return PHDOCKCBJOF;
		}

		public void PAOPOFJHFGD()
		{
			throw new NotSupportedException();
		}

		public void ODFCBNONFPL()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object PIPMONHGDPH()
		{
			return PHDOCKCBJOF;
		}

		public bool NJBCJDFKGHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				FAJOCOIFFOA = LevelManager.instance.behaviours[0];
				if (EFBPOCHCGPB)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(FAJOCOIFFOA.PrepareVisualsForCardCoroutine(true, false));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.ICKAKNNBANK(PFGLIAHPMCK, EFBPOCHCGPB));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object BNMEIAPPLDP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HBKJOBOMGKB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GCJFGIKENJA()
		{
			return PHDOCKCBJOF;
		}

		public void GIAIFFPNMPJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CCANBMDEKMB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GLIHEBDJCGM()
		{
			return PHDOCKCBJOF;
		}

		public void GGLMLMFEJCD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HHHLDCLIFKJ()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Dispose()
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
		private object NEGMMIBLJLP()
		{
			return PHDOCKCBJOF;
		}

		public void NFLHLMKKJMO()
		{
			throw new NotSupportedException();
		}

		public bool KDFAHLNCNMN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				FAJOCOIFFOA = LevelManager.instance.behaviours[1];
				if (EFBPOCHCGPB)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(FAJOCOIFFOA.PrepareVisualsForCardCoroutine(true, true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.ICKAKNNBANK(PFGLIAHPMCK, EFBPOCHCGPB));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object BGMNDLEJNHH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ADIAKJMNIEB()
		{
			return PHDOCKCBJOF;
		}

		public void PCNOHGFPMOE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void ODPKEEIHOPK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void MKIKEOOOLKL()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HHMPMPLLJCC()
		{
			throw new NotSupportedException();
		}

		public bool HDGDKCMIOGK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				FAJOCOIFFOA = LevelManager.instance.behaviours[0];
				if (EFBPOCHCGPB)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(FAJOCOIFFOA.PrepareVisualsForCardCoroutine(false, true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.ICKAKNNBANK(PFGLIAHPMCK, EFBPOCHCGPB));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void EPKPNKGJHEC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object CIGHIOCACPH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LJDPEMMLOFM()
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
				FAJOCOIFFOA = LevelManager.instance.behaviours[0];
				if (EFBPOCHCGPB)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(FAJOCOIFFOA.PrepareVisualsForCardCoroutine(true, false));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.ICKAKNNBANK(PFGLIAHPMCK, EFBPOCHCGPB));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object MOMPOEEALPJ()
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
				FAJOCOIFFOA = LevelManager.instance.behaviours[1];
				if (EFBPOCHCGPB)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(FAJOCOIFFOA.PrepareVisualsForCardCoroutine(true, true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.ICKAKNNBANK(PFGLIAHPMCK, EFBPOCHCGPB));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object EOKIMMCAABI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IHAOBCEALPD()
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
				FAJOCOIFFOA = LevelManager.instance.behaviours[1];
				if (EFBPOCHCGPB)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(FAJOCOIFFOA.PrepareVisualsForCardCoroutine(true, true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.ICKAKNNBANK(PFGLIAHPMCK, EFBPOCHCGPB));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public bool BCFKDABEHHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				FAJOCOIFFOA = LevelManager.instance.behaviours[1];
				if (EFBPOCHCGPB)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(FAJOCOIFFOA.PrepareVisualsForCardCoroutine(true, true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.ICKAKNNBANK(PFGLIAHPMCK, EFBPOCHCGPB));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object GDCFFBBNGHH()
		{
			return PHDOCKCBJOF;
		}

		public bool PMCFLKAJNHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				FAJOCOIFFOA = LevelManager.instance.behaviours[1];
				if (EFBPOCHCGPB)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(FAJOCOIFFOA.PrepareVisualsForCardCoroutine(false, true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.ICKAKNNBANK(PFGLIAHPMCK, EFBPOCHCGPB));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
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
				FAJOCOIFFOA = LevelManager.instance.behaviours[1];
				if (EFBPOCHCGPB)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(FAJOCOIFFOA.PrepareVisualsForCardCoroutine(false, true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.ICKAKNNBANK(PFGLIAHPMCK, EFBPOCHCGPB));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public bool NOHPKMDNEAO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				FAJOCOIFFOA = LevelManager.instance.behaviours[0];
				if (EFBPOCHCGPB)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(FAJOCOIFFOA.PrepareVisualsForCardCoroutine(false, true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.ICKAKNNBANK(PFGLIAHPMCK, EFBPOCHCGPB));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object HLFLANGJJHM()
		{
			return PHDOCKCBJOF;
		}

		public void DLIBOPAMHAN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void MIPBONGPIJE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HMILEBCNNCP()
		{
			return PHDOCKCBJOF;
		}

		public void OKIANDBCDIB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool BKJCILLNJLG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				FAJOCOIFFOA = LevelManager.instance.behaviours[0];
				if (EFBPOCHCGPB)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(FAJOCOIFFOA.PrepareVisualsForCardCoroutine(false, true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.ICKAKNNBANK(PFGLIAHPMCK, EFBPOCHCGPB));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 2u:
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

		public bool PPOPGFELIDA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				FAJOCOIFFOA = LevelManager.instance.behaviours[1];
				if (EFBPOCHCGPB)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(FAJOCOIFFOA.PrepareVisualsForCardCoroutine(true, false));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.ICKAKNNBANK(PFGLIAHPMCK, EFBPOCHCGPB));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public bool NEMOAIBCODB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				FAJOCOIFFOA = LevelManager.instance.behaviours[0];
				if (EFBPOCHCGPB)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(FAJOCOIFFOA.PrepareVisualsForCardCoroutine(true, false));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.ICKAKNNBANK(PFGLIAHPMCK, EFBPOCHCGPB));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void GFJIKANGNMC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object NAPMJAMDKMJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BKHFGLNNCDF()
		{
			return PHDOCKCBJOF;
		}

		public bool FCJCLBMPBFK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				FAJOCOIFFOA = LevelManager.instance.behaviours[0];
				if (EFBPOCHCGPB)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(FAJOCOIFFOA.PrepareVisualsForCardCoroutine(true, true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.ICKAKNNBANK(PFGLIAHPMCK, EFBPOCHCGPB));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object CFBNPKIMOJC()
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
				FAJOCOIFFOA = LevelManager.instance.behaviours[1];
				if (EFBPOCHCGPB)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(FAJOCOIFFOA.PrepareVisualsForCardCoroutine(true, true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.ICKAKNNBANK(PFGLIAHPMCK, EFBPOCHCGPB));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object LMJBCDNGAHP()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public PKIINPFKGDD()
		{
		}

		public bool MPKAJACHAIC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				FAJOCOIFFOA = LevelManager.instance.behaviours[1];
				if (EFBPOCHCGPB)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(FAJOCOIFFOA.PrepareVisualsForCardCoroutine(true, false));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.ICKAKNNBANK(PFGLIAHPMCK, EFBPOCHCGPB));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
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
				FAJOCOIFFOA = LevelManager.instance.behaviours[0];
				if (EFBPOCHCGPB)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(FAJOCOIFFOA.PrepareVisualsForCardCoroutine(true, true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.ICKAKNNBANK(PFGLIAHPMCK, EFBPOCHCGPB));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object CICPCKDCCEF()
		{
			return PHDOCKCBJOF;
		}

		public void HCHNHNDDKKA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void JJOAHIOBOPO()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object EDBIJNJGFLE()
		{
			return PHDOCKCBJOF;
		}

		public void ONGBFFAENBP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}
	}

	private sealed class EEHPCJJABDC : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal LevelBehaviour FAJOCOIFFOA;

		internal bool EFBPOCHCGPB;

		internal UnitUpgrades PFGLIAHPMCK;

		internal UpgradeSlotsVehicle<T> BJGCPDNMHDH;

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
		private object GOAJCEAOPLA()
		{
			return PHDOCKCBJOF;
		}

		public void HCHNHNDDKKA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object JDKFIHJHNJC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BGMNDLEJNHH()
		{
			return PHDOCKCBJOF;
		}

		public void FMOJMHBAHAA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HCPKEMLPEDI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KKKMCHGLHLL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HJFIBBBPDKK()
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
				FAJOCOIFFOA = LevelManager.instance.behaviours[0];
				if (EFBPOCHCGPB)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(FAJOCOIFFOA.PrepareVisualsForCardCoroutine(true, true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.MHNNGEAIJHJ(PFGLIAHPMCK, EFBPOCHCGPB));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void ABBPOMCBIIH()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object EFIEEKFCBJH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JPJBNHHKOJD()
		{
			return PHDOCKCBJOF;
		}

		public void HNFEJKPKEHK()
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
				FAJOCOIFFOA = LevelManager.instance.behaviours[0];
				if (EFBPOCHCGPB)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(FAJOCOIFFOA.PrepareVisualsForCardCoroutine(false, true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.MHNNGEAIJHJ(PFGLIAHPMCK, EFBPOCHCGPB));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object OAMLLHEMBIK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AGANCOFPDCK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MILFCGMBHIG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HLBMCNKGBDM()
		{
			return PHDOCKCBJOF;
		}

		public void KNFDDIHLBKJ()
		{
			throw new NotSupportedException();
		}

		public void HMBLLDJFIJG()
		{
			throw new NotSupportedException();
		}

		public void NFLHLMKKJMO()
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
				FAJOCOIFFOA = LevelManager.instance.behaviours[1];
				if (EFBPOCHCGPB)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(FAJOCOIFFOA.PrepareVisualsForCardCoroutine(false, true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.MHNNGEAIJHJ(PFGLIAHPMCK, EFBPOCHCGPB));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object HMIFLGCBDCO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ADIAKJMNIEB()
		{
			return PHDOCKCBJOF;
		}

		public void MEBPMHDHIPJ()
		{
			throw new NotSupportedException();
		}

		public void ODCIKOOGNFG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void CHFJIODFNIP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void DLIBOPAMHAN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public EEHPCJJABDC()
		{
		}

		public void IDCJDJMGKFG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GKJIGGAAHBE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DOOAHBLHGFO()
		{
			return PHDOCKCBJOF;
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

		public void HONCAABOMOC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HOCLBPGAEMP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NAPMJAMDKMJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AHFIDCCJHKE()
		{
			return PHDOCKCBJOF;
		}

		public void IBDAHMOEBCM()
		{
			throw new NotSupportedException();
		}

		public void JKOCLGOOBEK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool DDLMLOJGJMA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				FAJOCOIFFOA = LevelManager.instance.behaviours[0];
				if (EFBPOCHCGPB)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(FAJOCOIFFOA.PrepareVisualsForCardCoroutine(false, true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.MHNNGEAIJHJ(PFGLIAHPMCK, EFBPOCHCGPB));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public bool HEHJAEIGHDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				FAJOCOIFFOA = LevelManager.instance.behaviours[0];
				if (EFBPOCHCGPB)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(FAJOCOIFFOA.PrepareVisualsForCardCoroutine(true, true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.MHNNGEAIJHJ(PFGLIAHPMCK, EFBPOCHCGPB));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void NINFNJOMJOD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object PEGJNAKGHCC()
		{
			return PHDOCKCBJOF;
		}

		public void NGAGGCFIEGJ()
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
				FAJOCOIFFOA = LevelManager.instance.behaviours[1];
				if (EFBPOCHCGPB)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(FAJOCOIFFOA.PrepareVisualsForCardCoroutine(true, false));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.MHNNGEAIJHJ(PFGLIAHPMCK, EFBPOCHCGPB));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object BMGHJKFMKJE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HCCLNDKNCIE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GDCFFBBNGHH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GJMNLPAEIDA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FMCLBOCENPE()
		{
			return PHDOCKCBJOF;
		}

		public void MENEBJLDGJD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FKKBFFHMEME()
		{
			return PHDOCKCBJOF;
		}
	}

	private IEnumerator LMPFKNEBOHH(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		return base.LoadMineVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB);
	}

	public virtual IEnumerator HNFCEBMLHJN(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		EEHPCJJABDC eEHPCJJABDC = new EEHPCJJABDC();
		eEHPCJJABDC.EFBPOCHCGPB = EFBPOCHCGPB;
		eEHPCJJABDC.PFGLIAHPMCK = PFGLIAHPMCK;
		eEHPCJJABDC.BJGCPDNMHDH = this;
		return eEHPCJJABDC;
	}

	public virtual IEnumerator PCKEHPGELIL(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		EEHPCJJABDC eEHPCJJABDC = new EEHPCJJABDC();
		eEHPCJJABDC.EFBPOCHCGPB = EFBPOCHCGPB;
		eEHPCJJABDC.PFGLIAHPMCK = PFGLIAHPMCK;
		eEHPCJJABDC.BJGCPDNMHDH = this;
		return eEHPCJJABDC;
	}

	public virtual IEnumerator KEDLDLLGNCO(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		EEHPCJJABDC eEHPCJJABDC = new EEHPCJJABDC();
		eEHPCJJABDC.EFBPOCHCGPB = EFBPOCHCGPB;
		eEHPCJJABDC.PFGLIAHPMCK = PFGLIAHPMCK;
		eEHPCJJABDC.BJGCPDNMHDH = this;
		return eEHPCJJABDC;
	}

	public virtual IEnumerator HBBMGDJONBM(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		EEHPCJJABDC eEHPCJJABDC = new EEHPCJJABDC();
		eEHPCJJABDC.EFBPOCHCGPB = EFBPOCHCGPB;
		eEHPCJJABDC.PFGLIAHPMCK = PFGLIAHPMCK;
		eEHPCJJABDC.BJGCPDNMHDH = this;
		return eEHPCJJABDC;
	}

	public virtual IEnumerator LBHNGLHICGI(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		PKIINPFKGDD pKIINPFKGDD = new PKIINPFKGDD();
		pKIINPFKGDD.EFBPOCHCGPB = EFBPOCHCGPB;
		pKIINPFKGDD.PFGLIAHPMCK = PFGLIAHPMCK;
		pKIINPFKGDD.BJGCPDNMHDH = this;
		return pKIINPFKGDD;
	}

	public virtual IEnumerator JCNECDMKEIA(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		EEHPCJJABDC eEHPCJJABDC = new EEHPCJJABDC();
		eEHPCJJABDC.EFBPOCHCGPB = EFBPOCHCGPB;
		eEHPCJJABDC.PFGLIAHPMCK = PFGLIAHPMCK;
		eEHPCJJABDC.BJGCPDNMHDH = this;
		return eEHPCJJABDC;
	}

	private IEnumerator BBMBABLHKPP(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		return base.LoadOponentVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB);
	}

	private IEnumerator OHGOPOPJCPB(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		return base.LoadOponentVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB);
	}

	public virtual IEnumerator KCIPDEIFLKK(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		EEHPCJJABDC eEHPCJJABDC = new EEHPCJJABDC();
		eEHPCJJABDC.EFBPOCHCGPB = EFBPOCHCGPB;
		eEHPCJJABDC.PFGLIAHPMCK = PFGLIAHPMCK;
		eEHPCJJABDC.BJGCPDNMHDH = this;
		return eEHPCJJABDC;
	}

	public virtual IEnumerator IOOHPGBPLGD(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		EEHPCJJABDC eEHPCJJABDC = new EEHPCJJABDC();
		eEHPCJJABDC.EFBPOCHCGPB = EFBPOCHCGPB;
		eEHPCJJABDC.PFGLIAHPMCK = PFGLIAHPMCK;
		eEHPCJJABDC.BJGCPDNMHDH = this;
		return eEHPCJJABDC;
	}

	private IEnumerator DMANOCEDOFO(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		return base.LoadMineVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB);
	}

	public virtual IEnumerator DLAHHHHJDPM(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		PKIINPFKGDD pKIINPFKGDD = new PKIINPFKGDD();
		pKIINPFKGDD.EFBPOCHCGPB = EFBPOCHCGPB;
		pKIINPFKGDD.PFGLIAHPMCK = PFGLIAHPMCK;
		pKIINPFKGDD.BJGCPDNMHDH = this;
		return pKIINPFKGDD;
	}

	public virtual IEnumerator GNIOJOJOMPB(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		PKIINPFKGDD pKIINPFKGDD = new PKIINPFKGDD();
		pKIINPFKGDD.EFBPOCHCGPB = EFBPOCHCGPB;
		pKIINPFKGDD.PFGLIAHPMCK = PFGLIAHPMCK;
		pKIINPFKGDD.BJGCPDNMHDH = this;
		return pKIINPFKGDD;
	}

	private IEnumerator KDLKAEKLFOO(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		return base.LoadOponentVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB);
	}

	private IEnumerator EMHPJPPPJGN(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		return base.LoadMineVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB);
	}

	public virtual IEnumerator FMDLBANPFPB(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		PKIINPFKGDD pKIINPFKGDD = new PKIINPFKGDD();
		pKIINPFKGDD.EFBPOCHCGPB = EFBPOCHCGPB;
		pKIINPFKGDD.PFGLIAHPMCK = PFGLIAHPMCK;
		pKIINPFKGDD.BJGCPDNMHDH = this;
		return pKIINPFKGDD;
	}

	public virtual IEnumerator DFIAOLMBEEH(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		EEHPCJJABDC eEHPCJJABDC = new EEHPCJJABDC();
		eEHPCJJABDC.EFBPOCHCGPB = EFBPOCHCGPB;
		eEHPCJJABDC.PFGLIAHPMCK = PFGLIAHPMCK;
		eEHPCJJABDC.BJGCPDNMHDH = this;
		return eEHPCJJABDC;
	}

	public virtual IEnumerator FMAOBEMJBNI(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		PKIINPFKGDD pKIINPFKGDD = new PKIINPFKGDD();
		pKIINPFKGDD.EFBPOCHCGPB = EFBPOCHCGPB;
		pKIINPFKGDD.PFGLIAHPMCK = PFGLIAHPMCK;
		pKIINPFKGDD.BJGCPDNMHDH = this;
		return pKIINPFKGDD;
	}

	private IEnumerator HHOHLPEBKHB(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		return base.LoadMineVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB);
	}

	public virtual IEnumerator BNOCBKFFNLI(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		EEHPCJJABDC eEHPCJJABDC = new EEHPCJJABDC();
		eEHPCJJABDC.EFBPOCHCGPB = EFBPOCHCGPB;
		eEHPCJJABDC.PFGLIAHPMCK = PFGLIAHPMCK;
		eEHPCJJABDC.BJGCPDNMHDH = this;
		return eEHPCJJABDC;
	}

	public virtual IEnumerator AGNINOEADCK(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		PKIINPFKGDD pKIINPFKGDD = new PKIINPFKGDD();
		pKIINPFKGDD.EFBPOCHCGPB = EFBPOCHCGPB;
		pKIINPFKGDD.PFGLIAHPMCK = PFGLIAHPMCK;
		pKIINPFKGDD.BJGCPDNMHDH = this;
		return pKIINPFKGDD;
	}

	public virtual IEnumerator MIKPOBDCEGB(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		PKIINPFKGDD pKIINPFKGDD = new PKIINPFKGDD();
		pKIINPFKGDD.EFBPOCHCGPB = EFBPOCHCGPB;
		pKIINPFKGDD.PFGLIAHPMCK = PFGLIAHPMCK;
		pKIINPFKGDD.BJGCPDNMHDH = this;
		return pKIINPFKGDD;
	}

	public virtual IEnumerator ABMHKLFMKKL(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		PKIINPFKGDD pKIINPFKGDD = new PKIINPFKGDD();
		pKIINPFKGDD.EFBPOCHCGPB = EFBPOCHCGPB;
		pKIINPFKGDD.PFGLIAHPMCK = PFGLIAHPMCK;
		pKIINPFKGDD.BJGCPDNMHDH = this;
		return pKIINPFKGDD;
	}

	public virtual IEnumerator EENKBCKHMMA(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		EEHPCJJABDC eEHPCJJABDC = new EEHPCJJABDC();
		eEHPCJJABDC.EFBPOCHCGPB = EFBPOCHCGPB;
		eEHPCJJABDC.PFGLIAHPMCK = PFGLIAHPMCK;
		eEHPCJJABDC.BJGCPDNMHDH = this;
		return eEHPCJJABDC;
	}

	public virtual IEnumerator PKOLMAFLAHL(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		EEHPCJJABDC eEHPCJJABDC = new EEHPCJJABDC();
		eEHPCJJABDC.EFBPOCHCGPB = EFBPOCHCGPB;
		eEHPCJJABDC.PFGLIAHPMCK = PFGLIAHPMCK;
		eEHPCJJABDC.BJGCPDNMHDH = this;
		return eEHPCJJABDC;
	}

	private IEnumerator LMOJCIODCEB(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		return base.LoadOponentVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB);
	}

	public virtual IEnumerator FHCLONKCDCF(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		EEHPCJJABDC eEHPCJJABDC = new EEHPCJJABDC();
		eEHPCJJABDC.EFBPOCHCGPB = EFBPOCHCGPB;
		eEHPCJJABDC.PFGLIAHPMCK = PFGLIAHPMCK;
		eEHPCJJABDC.BJGCPDNMHDH = this;
		return eEHPCJJABDC;
	}

	public virtual IEnumerator DNLNKBAMJOA(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		PKIINPFKGDD pKIINPFKGDD = new PKIINPFKGDD();
		pKIINPFKGDD.EFBPOCHCGPB = EFBPOCHCGPB;
		pKIINPFKGDD.PFGLIAHPMCK = PFGLIAHPMCK;
		pKIINPFKGDD.BJGCPDNMHDH = this;
		return pKIINPFKGDD;
	}

	private IEnumerator DEGAFHHHALP(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		return base.LoadMineVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB);
	}

	private IEnumerator AJOMBLNODGO(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		return base.LoadOponentVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB);
	}

	private IEnumerator IODHDCHOEGG(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		return base.LoadMineVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB);
	}

	private IEnumerator NDMINLCHIHP(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		return base.LoadOponentVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB);
	}

	public virtual IEnumerator FAEHJFLKIIJ(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		EEHPCJJABDC eEHPCJJABDC = new EEHPCJJABDC();
		eEHPCJJABDC.EFBPOCHCGPB = EFBPOCHCGPB;
		eEHPCJJABDC.PFGLIAHPMCK = PFGLIAHPMCK;
		eEHPCJJABDC.BJGCPDNMHDH = this;
		return eEHPCJJABDC;
	}

	private IEnumerator IBHGBNMDEMH(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		return base.LoadMineVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB);
	}

	public virtual IEnumerator OBDGALLODOO(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		EEHPCJJABDC eEHPCJJABDC = new EEHPCJJABDC();
		eEHPCJJABDC.EFBPOCHCGPB = EFBPOCHCGPB;
		eEHPCJJABDC.PFGLIAHPMCK = PFGLIAHPMCK;
		eEHPCJJABDC.BJGCPDNMHDH = this;
		return eEHPCJJABDC;
	}

	public virtual IEnumerator LPALCPLEMND(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		EEHPCJJABDC eEHPCJJABDC = new EEHPCJJABDC();
		eEHPCJJABDC.EFBPOCHCGPB = EFBPOCHCGPB;
		eEHPCJJABDC.PFGLIAHPMCK = PFGLIAHPMCK;
		eEHPCJJABDC.BJGCPDNMHDH = this;
		return eEHPCJJABDC;
	}

	public virtual IEnumerator BBBGCLKFEID(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		EEHPCJJABDC eEHPCJJABDC = new EEHPCJJABDC();
		eEHPCJJABDC.EFBPOCHCGPB = EFBPOCHCGPB;
		eEHPCJJABDC.PFGLIAHPMCK = PFGLIAHPMCK;
		eEHPCJJABDC.BJGCPDNMHDH = this;
		return eEHPCJJABDC;
	}

	public virtual IEnumerator JNHHEMLADHH(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		EEHPCJJABDC eEHPCJJABDC = new EEHPCJJABDC();
		eEHPCJJABDC.EFBPOCHCGPB = EFBPOCHCGPB;
		eEHPCJJABDC.PFGLIAHPMCK = PFGLIAHPMCK;
		eEHPCJJABDC.BJGCPDNMHDH = this;
		return eEHPCJJABDC;
	}

	public virtual IEnumerator ABOHEIIBOOB(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		PKIINPFKGDD pKIINPFKGDD = new PKIINPFKGDD();
		pKIINPFKGDD.EFBPOCHCGPB = EFBPOCHCGPB;
		pKIINPFKGDD.PFGLIAHPMCK = PFGLIAHPMCK;
		pKIINPFKGDD.BJGCPDNMHDH = this;
		return pKIINPFKGDD;
	}

	private IEnumerator NOJMKLNJBLE(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		return base.LoadOponentVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB);
	}

	private IEnumerator KHENGFOPEFM(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		return base.LoadMineVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB);
	}

	private IEnumerator NONAMFBNLMG(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		return base.LoadMineVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB);
	}

	private IEnumerator DNEANNAJFHK(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		return base.LoadMineVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB);
	}

	public virtual IEnumerator FIFBDOFOAGB(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		PKIINPFKGDD pKIINPFKGDD = new PKIINPFKGDD();
		pKIINPFKGDD.EFBPOCHCGPB = EFBPOCHCGPB;
		pKIINPFKGDD.PFGLIAHPMCK = PFGLIAHPMCK;
		pKIINPFKGDD.BJGCPDNMHDH = this;
		return pKIINPFKGDD;
	}

	public virtual IEnumerator MPKICEBPGPB(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		PKIINPFKGDD pKIINPFKGDD = new PKIINPFKGDD();
		pKIINPFKGDD.EFBPOCHCGPB = EFBPOCHCGPB;
		pKIINPFKGDD.PFGLIAHPMCK = PFGLIAHPMCK;
		pKIINPFKGDD.BJGCPDNMHDH = this;
		return pKIINPFKGDD;
	}

	public virtual IEnumerator MLGIOKLHDMD(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		EEHPCJJABDC eEHPCJJABDC = new EEHPCJJABDC();
		eEHPCJJABDC.EFBPOCHCGPB = EFBPOCHCGPB;
		eEHPCJJABDC.PFGLIAHPMCK = PFGLIAHPMCK;
		eEHPCJJABDC.BJGCPDNMHDH = this;
		return eEHPCJJABDC;
	}

	public virtual IEnumerator DABCBDDGLBH(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		EEHPCJJABDC eEHPCJJABDC = new EEHPCJJABDC();
		eEHPCJJABDC.EFBPOCHCGPB = EFBPOCHCGPB;
		eEHPCJJABDC.PFGLIAHPMCK = PFGLIAHPMCK;
		eEHPCJJABDC.BJGCPDNMHDH = this;
		return eEHPCJJABDC;
	}

	public virtual IEnumerator DOANBPAHJLC(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		PKIINPFKGDD pKIINPFKGDD = new PKIINPFKGDD();
		pKIINPFKGDD.EFBPOCHCGPB = EFBPOCHCGPB;
		pKIINPFKGDD.PFGLIAHPMCK = PFGLIAHPMCK;
		pKIINPFKGDD.BJGCPDNMHDH = this;
		return pKIINPFKGDD;
	}

	public virtual IEnumerator LOONMIMHFOM(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		EEHPCJJABDC eEHPCJJABDC = new EEHPCJJABDC();
		eEHPCJJABDC.EFBPOCHCGPB = EFBPOCHCGPB;
		eEHPCJJABDC.PFGLIAHPMCK = PFGLIAHPMCK;
		eEHPCJJABDC.BJGCPDNMHDH = this;
		return eEHPCJJABDC;
	}

	public virtual IEnumerator IODJDPMBDPH(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		EEHPCJJABDC eEHPCJJABDC = new EEHPCJJABDC();
		eEHPCJJABDC.EFBPOCHCGPB = EFBPOCHCGPB;
		eEHPCJJABDC.PFGLIAHPMCK = PFGLIAHPMCK;
		eEHPCJJABDC.BJGCPDNMHDH = this;
		return eEHPCJJABDC;
	}

	public virtual IEnumerator EJCFGEENMGH(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		PKIINPFKGDD pKIINPFKGDD = new PKIINPFKGDD();
		pKIINPFKGDD.EFBPOCHCGPB = EFBPOCHCGPB;
		pKIINPFKGDD.PFGLIAHPMCK = PFGLIAHPMCK;
		pKIINPFKGDD.BJGCPDNMHDH = this;
		return pKIINPFKGDD;
	}

	[DebuggerHidden]
	[CompilerGenerated]
	private IEnumerator ICKAKNNBANK(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		return base.LoadMineVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB);
	}

	public virtual IEnumerator ONHBJEGKNCG(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		PKIINPFKGDD pKIINPFKGDD = new PKIINPFKGDD();
		pKIINPFKGDD.EFBPOCHCGPB = EFBPOCHCGPB;
		pKIINPFKGDD.PFGLIAHPMCK = PFGLIAHPMCK;
		pKIINPFKGDD.BJGCPDNMHDH = this;
		return pKIINPFKGDD;
	}

	private IEnumerator AMMMONFABJB(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		return base.LoadOponentVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB);
	}

	private IEnumerator EGCCHEBCDJM(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		return base.LoadOponentVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB);
	}

	public virtual IEnumerator JDENPOIENIL(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		EEHPCJJABDC eEHPCJJABDC = new EEHPCJJABDC();
		eEHPCJJABDC.EFBPOCHCGPB = EFBPOCHCGPB;
		eEHPCJJABDC.PFGLIAHPMCK = PFGLIAHPMCK;
		eEHPCJJABDC.BJGCPDNMHDH = this;
		return eEHPCJJABDC;
	}

	public virtual IEnumerator DGBNHFGAHLN(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		EEHPCJJABDC eEHPCJJABDC = new EEHPCJJABDC();
		eEHPCJJABDC.EFBPOCHCGPB = EFBPOCHCGPB;
		eEHPCJJABDC.PFGLIAHPMCK = PFGLIAHPMCK;
		eEHPCJJABDC.BJGCPDNMHDH = this;
		return eEHPCJJABDC;
	}

	private IEnumerator PBEOOGDPFHL(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		return base.LoadMineVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB);
	}

	public virtual IEnumerator LBNOHPKPEMB(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		PKIINPFKGDD pKIINPFKGDD = new PKIINPFKGDD();
		pKIINPFKGDD.EFBPOCHCGPB = EFBPOCHCGPB;
		pKIINPFKGDD.PFGLIAHPMCK = PFGLIAHPMCK;
		pKIINPFKGDD.BJGCPDNMHDH = this;
		return pKIINPFKGDD;
	}

	private IEnumerator PKALBFHFHND(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		return base.LoadOponentVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB);
	}

	private IEnumerator MJNHFJJOLDJ(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		return base.LoadMineVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB);
	}

	public virtual IEnumerator AIBMPIMGOFA(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		PKIINPFKGDD pKIINPFKGDD = new PKIINPFKGDD();
		pKIINPFKGDD.EFBPOCHCGPB = EFBPOCHCGPB;
		pKIINPFKGDD.PFGLIAHPMCK = PFGLIAHPMCK;
		pKIINPFKGDD.BJGCPDNMHDH = this;
		return pKIINPFKGDD;
	}

	public virtual IEnumerator MOJDGCPODFB(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		EEHPCJJABDC eEHPCJJABDC = new EEHPCJJABDC();
		eEHPCJJABDC.EFBPOCHCGPB = EFBPOCHCGPB;
		eEHPCJJABDC.PFGLIAHPMCK = PFGLIAHPMCK;
		eEHPCJJABDC.BJGCPDNMHDH = this;
		return eEHPCJJABDC;
	}

	private IEnumerator LMEAMDMLAHN(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		return base.LoadOponentVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB);
	}

	private IEnumerator NFEDHPBBBPA(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		return base.LoadOponentVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB);
	}

	private IEnumerator GOHKNKAALJL(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		return base.LoadMineVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB);
	}

	public virtual IEnumerator OIOIDLPNAML(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		PKIINPFKGDD pKIINPFKGDD = new PKIINPFKGDD();
		pKIINPFKGDD.EFBPOCHCGPB = EFBPOCHCGPB;
		pKIINPFKGDD.PFGLIAHPMCK = PFGLIAHPMCK;
		pKIINPFKGDD.BJGCPDNMHDH = this;
		return pKIINPFKGDD;
	}

	public virtual IEnumerator EKEHJGHCDKF(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		EEHPCJJABDC eEHPCJJABDC = new EEHPCJJABDC();
		eEHPCJJABDC.EFBPOCHCGPB = EFBPOCHCGPB;
		eEHPCJJABDC.PFGLIAHPMCK = PFGLIAHPMCK;
		eEHPCJJABDC.BJGCPDNMHDH = this;
		return eEHPCJJABDC;
	}

	public virtual IEnumerator JBOOAOLIAMP(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		PKIINPFKGDD pKIINPFKGDD = new PKIINPFKGDD();
		pKIINPFKGDD.EFBPOCHCGPB = EFBPOCHCGPB;
		pKIINPFKGDD.PFGLIAHPMCK = PFGLIAHPMCK;
		pKIINPFKGDD.BJGCPDNMHDH = this;
		return pKIINPFKGDD;
	}

	private IEnumerator FJPBOAHDEEM(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		return base.LoadOponentVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB);
	}

	public virtual IEnumerator EEMGNNNPPGD(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		PKIINPFKGDD pKIINPFKGDD = new PKIINPFKGDD();
		pKIINPFKGDD.EFBPOCHCGPB = EFBPOCHCGPB;
		pKIINPFKGDD.PFGLIAHPMCK = PFGLIAHPMCK;
		pKIINPFKGDD.BJGCPDNMHDH = this;
		return pKIINPFKGDD;
	}

	private IEnumerator GONDBIJNNKM(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		return base.LoadMineVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB);
	}

	public virtual IEnumerator KMJFFCKAMOH(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		PKIINPFKGDD pKIINPFKGDD = new PKIINPFKGDD();
		pKIINPFKGDD.EFBPOCHCGPB = EFBPOCHCGPB;
		pKIINPFKGDD.PFGLIAHPMCK = PFGLIAHPMCK;
		pKIINPFKGDD.BJGCPDNMHDH = this;
		return pKIINPFKGDD;
	}

	private IEnumerator FFACGHLJKCC(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		return base.LoadMineVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB);
	}

	public virtual IEnumerator HBFDKLPHFMB(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		PKIINPFKGDD pKIINPFKGDD = new PKIINPFKGDD();
		pKIINPFKGDD.EFBPOCHCGPB = EFBPOCHCGPB;
		pKIINPFKGDD.PFGLIAHPMCK = PFGLIAHPMCK;
		pKIINPFKGDD.BJGCPDNMHDH = this;
		return pKIINPFKGDD;
	}

	private IEnumerator NPDJDHDLNAO(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		return base.LoadOponentVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB);
	}

	private IEnumerator AEIPABCMJNP(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		return base.LoadMineVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB);
	}

	private IEnumerator ILLIBNIKIKB(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		return base.LoadOponentVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB);
	}

	public virtual IEnumerator OCAFLGCBJCA(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		EEHPCJJABDC eEHPCJJABDC = new EEHPCJJABDC();
		eEHPCJJABDC.EFBPOCHCGPB = EFBPOCHCGPB;
		eEHPCJJABDC.PFGLIAHPMCK = PFGLIAHPMCK;
		eEHPCJJABDC.BJGCPDNMHDH = this;
		return eEHPCJJABDC;
	}

	[DebuggerHidden]
	[CompilerGenerated]
	private IEnumerator MHNNGEAIJHJ(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		return base.LoadOponentVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB);
	}

	private IEnumerator HGABGKHHHDG(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		return base.LoadOponentVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB);
	}

	public virtual IEnumerator GAKKCEMDJHM(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		EEHPCJJABDC eEHPCJJABDC = new EEHPCJJABDC();
		eEHPCJJABDC.EFBPOCHCGPB = EFBPOCHCGPB;
		eEHPCJJABDC.PFGLIAHPMCK = PFGLIAHPMCK;
		eEHPCJJABDC.BJGCPDNMHDH = this;
		return eEHPCJJABDC;
	}

	public virtual IEnumerator BNPFJCEKLOP(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		EEHPCJJABDC eEHPCJJABDC = new EEHPCJJABDC();
		eEHPCJJABDC.EFBPOCHCGPB = EFBPOCHCGPB;
		eEHPCJJABDC.PFGLIAHPMCK = PFGLIAHPMCK;
		eEHPCJJABDC.BJGCPDNMHDH = this;
		return eEHPCJJABDC;
	}

	public virtual IEnumerator DLNJMHNGEGG(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		PKIINPFKGDD pKIINPFKGDD = new PKIINPFKGDD();
		pKIINPFKGDD.EFBPOCHCGPB = EFBPOCHCGPB;
		pKIINPFKGDD.PFGLIAHPMCK = PFGLIAHPMCK;
		pKIINPFKGDD.BJGCPDNMHDH = this;
		return pKIINPFKGDD;
	}

	private IEnumerator KHHLKLHJIGE(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		return base.LoadOponentVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB);
	}

	private IEnumerator JOLLFJDLPDP(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		return base.LoadMineVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB);
	}

	private IEnumerator GLHODIECOEG(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		return base.LoadMineVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB);
	}

	private IEnumerator LDBPLPADDJA(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		return base.LoadOponentVisualsCoroutine(PFGLIAHPMCK, EFBPOCHCGPB);
	}

	[DebuggerHidden]
	public override IEnumerator LoadMineVisualsCoroutine(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		PKIINPFKGDD pKIINPFKGDD = new PKIINPFKGDD();
		pKIINPFKGDD.EFBPOCHCGPB = EFBPOCHCGPB;
		pKIINPFKGDD.PFGLIAHPMCK = PFGLIAHPMCK;
		pKIINPFKGDD.BJGCPDNMHDH = this;
		return pKIINPFKGDD;
	}

	[DebuggerHidden]
	public override IEnumerator LoadOponentVisualsCoroutine(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		EEHPCJJABDC eEHPCJJABDC = new EEHPCJJABDC();
		eEHPCJJABDC.EFBPOCHCGPB = EFBPOCHCGPB;
		eEHPCJJABDC.PFGLIAHPMCK = PFGLIAHPMCK;
		eEHPCJJABDC.BJGCPDNMHDH = this;
		return eEHPCJJABDC;
	}

	public virtual IEnumerator BGPGICPDBEJ(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		EEHPCJJABDC eEHPCJJABDC = new EEHPCJJABDC();
		eEHPCJJABDC.EFBPOCHCGPB = EFBPOCHCGPB;
		eEHPCJJABDC.PFGLIAHPMCK = PFGLIAHPMCK;
		eEHPCJJABDC.BJGCPDNMHDH = this;
		return eEHPCJJABDC;
	}
}
