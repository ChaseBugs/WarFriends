using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Google2u;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class RewardDialog : GuiElementSingle<RewardDialog>, PAIIOKBBHBC
{
	private sealed class CFBAIONKKFH : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal RewardDialog BJGCPDNMHDH;

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
		private object GCJFGIKENJA()
		{
			return PHDOCKCBJOF;
		}

		public bool HNCDLFFBMAA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.NPFFMLLLDAF())
				{
					if (Singleton<DogTagManager>.instance.AKAALNKEBAF() || Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.LootBox))
					{
						BJGCPDNMHDH.FJDEILFCFMB();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(665f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object HHLKEMNNJDA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JMKGAJNOLEM()
		{
			return PHDOCKCBJOF;
		}

		public void FDCPBGNCKHH()
		{
			throw new NotSupportedException();
		}

		public void MNFJGIMMBLE()
		{
			throw new NotSupportedException();
		}

		public bool IIJKAMFGNKA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.NPFFMLLLDAF())
				{
					if (Singleton<DogTagManager>.instance.MHIHFAOMHKK() || Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.GoldenSuitcase))
					{
						BJGCPDNMHDH.KGIBLIPGJDH();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1632f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public bool PPOPGFELIDA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.NPFFMLLLDAF())
				{
					if (Singleton<DogTagManager>.instance.MHIHFAOMHKK() || Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.RandomCard))
					{
						BJGCPDNMHDH.FJDEILFCFMB();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1836f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public bool EKGEDEKHBME()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.isShowed)
				{
					if (Singleton<DogTagManager>.instance.MHIHFAOMHKK() || Singleton<EventTrackingManager>.instance.MMNPIBNEDFA((MHNMOFPPKBN)7))
					{
						BJGCPDNMHDH.KGIBLIPGJDH();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1071f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object IFDMDGBPDKD()
		{
			return PHDOCKCBJOF;
		}

		public void KMIHPBNFGFH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool BJIPDEICIML()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.isShowed)
				{
					if (Singleton<DogTagManager>.instance.HPKBIIIEGIB() || Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.Dogtag))
					{
						BJGCPDNMHDH.KGIBLIPGJDH();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1028f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public bool CONJMMKAAGH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.isShowed)
				{
					if (Singleton<DogTagManager>.instance.MHIHFAOMHKK() || Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.GoldenSuitcase))
					{
						BJGCPDNMHDH.KGIBLIPGJDH();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1269f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object MBGCBKJBCND()
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
				if (BJGCPDNMHDH.isShowed)
				{
					if (Singleton<DogTagManager>.instance.HPKBIIIEGIB() || Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.Dogtag))
					{
						BJGCPDNMHDH.KGIBLIPGJDH();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(840f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object NIDLKNKKCND()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PNBPOAMPNKP()
		{
			return PHDOCKCBJOF;
		}

		public void PMAJELGBBKE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GKDLMFPKKNM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PCOOFELAEJA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JPJBNHHKOJD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PFIIINLHGMH()
		{
			return PHDOCKCBJOF;
		}

		public void OCBFBEMDMMJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool CIIHKFDLDKN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.NPFFMLLLDAF())
				{
					if (Singleton<DogTagManager>.instance.isFull || Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.None))
					{
						BJGCPDNMHDH.KGIBLIPGJDH();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(807f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object MIKGAKNJGKL()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public CFBAIONKKFH()
		{
		}

		[SpecialName]
		private object AAAOCACGKIP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JJBAIMILGLK()
		{
			return PHDOCKCBJOF;
		}

		public bool PMLLPHFACBM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.isShowed)
				{
					if (Singleton<DogTagManager>.instance.JFFKJKMOACB() || Singleton<EventTrackingManager>.instance.MMNPIBNEDFA((MHNMOFPPKBN)7))
					{
						BJGCPDNMHDH.FJDEILFCFMB();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1371f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object ELNKFJHGFPD()
		{
			return PHDOCKCBJOF;
		}

		public bool GMBFJOBKMMN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.NPFFMLLLDAF())
				{
					if (Singleton<DogTagManager>.instance.JFFKJKMOACB() || Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.Dogtag))
					{
						BJGCPDNMHDH.FJDEILFCFMB();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1799f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void JKBIMBFGGCO()
		{
			throw new NotSupportedException();
		}

		public void EPKPNKGJHEC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HNOPIDGLMPA()
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
		private object COEKBAFPBLD()
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
			case 1u:
				if (BJGCPDNMHDH.isShowed)
				{
					if (Singleton<DogTagManager>.instance.JFFKJKMOACB() || Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.None))
					{
						BJGCPDNMHDH.FJDEILFCFMB();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(850f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
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

		[SpecialName]
		private object CICPCKDCCEF()
		{
			return PHDOCKCBJOF;
		}

		public void EEHBKGPLIJN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GMPGIODBIPO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OJANHAIEAEJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HBKJOBOMGKB()
		{
			return PHDOCKCBJOF;
		}

		public bool IJEDIDEJIII()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.isShowed)
				{
					if (Singleton<DogTagManager>.instance.KDKHHPFBBBB() || Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.RandomCard))
					{
						BJGCPDNMHDH.FJDEILFCFMB();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1967f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object OJKHNOHHDGO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EBPKDAHAELB()
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
			case 1u:
				if (BJGCPDNMHDH.isShowed)
				{
					if (Singleton<DogTagManager>.instance.isFull || Singleton<EventTrackingManager>.instance.MMNPIBNEDFA((MHNMOFPPKBN)8))
					{
						BJGCPDNMHDH.FJDEILFCFMB();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(637f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object DFHCLJNONGC()
		{
			return PHDOCKCBJOF;
		}

		public void PAOPOFJHFGD()
		{
			throw new NotSupportedException();
		}

		public void AKLMKDOIDHP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object NOIDHHDEEPL()
		{
			return PHDOCKCBJOF;
		}

		public void ELMJLOBAMKH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MFNFCFAJKCM()
		{
			return PHDOCKCBJOF;
		}

		public void NGNOJECCHGF()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JGKMCJOGEIH()
		{
			return PHDOCKCBJOF;
		}

		public void IPKNPABKAJD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CGIBLCGGMJM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CIGHIOCACPH()
		{
			return PHDOCKCBJOF;
		}

		public void CFHJPHLFONO()
		{
			throw new NotSupportedException();
		}

		public bool DDBCLDGNFBB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.isShowed)
				{
					if (Singleton<DogTagManager>.instance.MHIHFAOMHKK() || Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.RandomCard))
					{
						BJGCPDNMHDH.FJDEILFCFMB();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1812f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object GKJIGGAAHBE()
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
				if (BJGCPDNMHDH.isShowed)
				{
					if (Singleton<DogTagManager>.instance.isFull || Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.Dogtag))
					{
						BJGCPDNMHDH.KGIBLIPGJDH();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(0.333f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void OKIANDBCDIB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void NGAGGCFIEGJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GFMLDIMOGHD()
		{
			return PHDOCKCBJOF;
		}

		public void KFOFFCGINMO()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool APJNFAOFAFD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.isShowed)
				{
					if (Singleton<DogTagManager>.instance.HPKBIIIEGIB() || Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.None))
					{
						BJGCPDNMHDH.KGIBLIPGJDH();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(957f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public bool MKLIDMNLNPN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.isShowed)
				{
					if (Singleton<DogTagManager>.instance.AKAALNKEBAF() || Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.GoldenSuitcase))
					{
						BJGCPDNMHDH.FJDEILFCFMB();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(807f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object KLECLPIKEJK()
		{
			return PHDOCKCBJOF;
		}

		public void ENFGGBNAPGG()
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
			case 1u:
				if (BJGCPDNMHDH.NPFFMLLLDAF())
				{
					if (Singleton<DogTagManager>.instance.MHIHFAOMHKK() || Singleton<EventTrackingManager>.instance.MMNPIBNEDFA((MHNMOFPPKBN)6))
					{
						BJGCPDNMHDH.FJDEILFCFMB();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(528f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void HNBFJFDLABI()
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
		private object GLKCJHHLOCE()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void BDPFKFGBNOH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void GICLICNJPBF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool KBPKMAKLNPB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.NPFFMLLLDAF())
				{
					if (Singleton<DogTagManager>.instance.AKAALNKEBAF() || Singleton<EventTrackingManager>.instance.MMNPIBNEDFA((MHNMOFPPKBN)5))
					{
						BJGCPDNMHDH.KGIBLIPGJDH();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1725f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void MGJIOLLKHDK()
		{
			throw new NotSupportedException();
		}

		public void BKGBMJMNJCD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FMCLBOCENPE()
		{
			return PHDOCKCBJOF;
		}

		public void HHCBBENDENJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object EFIEEKFCBJH()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object PJOAMPDDGAM()
		{
			return PHDOCKCBJOF;
		}

		public void BLOCBAKBHBF()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void IKGBMDKKAPA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object FCBCEDKNBKC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FIDLDFGJLFK()
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
			case 1u:
				if (BJGCPDNMHDH.NPFFMLLLDAF())
				{
					if (Singleton<DogTagManager>.instance.isFull || Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.LootBox))
					{
						BJGCPDNMHDH.KGIBLIPGJDH();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1218f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void KKCNPIPOCKK()
		{
			throw new NotSupportedException();
		}

		public void KCHOLCGBMBJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object AKGMMLGANMJ()
		{
			return PHDOCKCBJOF;
		}

		public void HKFEFDNFKKK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GPKBICHIBHF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KKCOHEHPJPF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BEGHOADNMJF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IPCODJDAOBE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HGOKAFJBFGJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GENJNMACGLP()
		{
			return PHDOCKCBJOF;
		}

		public void HLDMODAFJBO()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool PMBOHHPPJAC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.NPFFMLLLDAF())
				{
					if (Singleton<DogTagManager>.instance.HPKBIIIEGIB() || Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.GoldenSuitcase))
					{
						BJGCPDNMHDH.FJDEILFCFMB();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1516f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void IJHCIJLDKHK()
		{
			throw new NotSupportedException();
		}
	}

	[Header("Core")]
	[FormerlySerializedAs("GIMMLMFBMEI")]
	public UISprite KMFGCJEGJJK;

	[FormerlySerializedAs("KFEGNKJLMEL")]
	public UILabel OKMNFHNBMFA;

	[FormerlySerializedAs("HPOCJBBBPOC")]
	public UISprite DAANKCOLJGJ;

	public UISprite PEJFFMLEHFA;

	[FormerlySerializedAs("KJFNFBOFPGA")]
	[Header("-Top Right Promo")]
	public GameObject GKBPGIDDBGH;

	[FormerlySerializedAs("CLJCHGFOCCP")]
	public UILabel FOFFIHIHDJL;

	[FormerlySerializedAs("DPIBKCHLCEH")]
	[Header("-DogTag Part")]
	public UISprite HJLGGGCCGKO;

	[FormerlySerializedAs("KCNMGGKLALG")]
	[Header("-Card Part")]
	public GameObject FMOFBIBPANE;

	[FormerlySerializedAs("PMNKNPPKEDH")]
	public CardRecord PJOFHIKENOI;

	[Header("-Power Band")]
	[FormerlySerializedAs("CKOLJBOLFFB")]
	public GameObject HLOEAHMFPMG;

	[FormerlySerializedAs("MCLGLFLAGBK")]
	public UISprite JAJCFNOIBPM;

	[FormerlySerializedAs("EIAPONDPOEC")]
	public UISprite GPPJEHFBCCE;

	[FormerlySerializedAs("PBEPMEPBCOP")]
	public UILabel JBCBEOCNJBH;

	[FormerlySerializedAs("MCIFFHJHCKG")]
	public UILabel EPKDEDPGOLM;

	[Header("-CardPack")]
	[FormerlySerializedAs("EKCGLCFBFHN")]
	public UISprite FOKNEJJNKMG;

	[Header("-Elite Parts")]
	[FormerlySerializedAs("IDLBGEKEJPK")]
	public GameObject FOMAGOFBEDA;

	[FormerlySerializedAs("CAFCPAMLGAF")]
	public UILabel MJGJPPLCKLE;

	[FormerlySerializedAs("CNMJNIMAPGM")]
	public UISprite LDPKLFCGAAI;

	[FormerlySerializedAs("PJKOAFGFCDD")]
	public UILabel MPCKHNIBGAF;

	[Header("-Bottom Reward")]
	[FormerlySerializedAs("mPlayerVisualPart")]
	public GameObject DFADEHLLAAM;

	[FormerlySerializedAs("mPlayerVisualIcon")]
	public UISprite PAGPPMOEFLG;

	[FormerlySerializedAs("EMCKAKJMEPB")]
	public UILabel AAOJDLOBAJG;

	[Header("-Bottom Double")]
	[FormerlySerializedAs("GALCFBKBHKK")]
	public GameObject HJAKKICCMHP;

	[FormerlySerializedAs("LNAFPLOIHHF")]
	public UISprite APPHIEKINOJ;

	[FormerlySerializedAs("IAKKGJIDKMG")]
	public UILabel NFPLGDHDGDE;

	[Header("Bottom 1 Button")]
	[FormerlySerializedAs("MHGMBEIDHNH")]
	public GameObject PBBLBPFAFKP;

	[FormerlySerializedAs("FLLCIDOBFLP")]
	public GameObject IDPLLLAHIHN;

	[FormerlySerializedAs("HBACMGNHCCN")]
	public GameObject MBKCPLIJMEN;

	[FormerlySerializedAs("NHLKDOEGEHE")]
	[Header("Bottom 2 Buttons Dogtag")]
	public GameObject KIOAFJHDBBJ;

	[FormerlySerializedAs("BEAABNNMFIF")]
	public GameObject MCADILCIEPM;

	[FormerlySerializedAs("FBPNHAMAFFE")]
	public GameObject LFJOKEIPAIK;

	[Header("Bottom 2 Buttons Daily Gold")]
	[FormerlySerializedAs("JBNLLAGNCBL")]
	public GameObject BIIJGABDHAB;

	[FormerlySerializedAs("LCPIIIMDHIJ")]
	public GameObject GJGLGILGDGO;

	[FormerlySerializedAs("EOLKCIIEPFM")]
	public GameObject OEKAHMGJBBE;

	[FormerlySerializedAs("GKHMLOPOIEK")]
	[Header("Animation")]
	public CardMenuOwerlay DJDABJKPKOF;

	private IHFDGLMHHBE MMLIIEIJOJD;

	private long DFNCGKPNBPK;

	private Card GHINGDGFNJC;

	private PlayerVisual FGIMNJOOAOB;

	private NGNPIOOAHEH NGMELAKOPBK;

	private Card[] OAKNNNMGEID;

	private RadicalRoutine NAKHBAEKPJD;

	private bool CDPNOOGFKOF;

	private LevelBehaviour IFFDIHCPKFE;

	private void MHMOPNBFOPH(string MHPNDNJDPGE, float OOHHOBCCKKG, Quaternion OOMCGGAFJNH)
	{
		DAANKCOLJGJ.spriteName = MHPNDNJDPGE;
		DAANKCOLJGJ.MakePixelPerfect();
		DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(OOHHOBCCKKG);
		DAANKCOLJGJ.transform.localRotation = OOMCGGAFJNH;
	}

	public void CKJCFLGKPOA(IHFDGLMHHBE FJLBLLLEELD, NGNPIOOAHEH GIPDDOPFGKK, Card[] HGPGKHLOHEF)
	{
		MMLIIEIJOJD = FJLBLLLEELD;
		NGMELAKOPBK = GIPDDOPFGKK;
		OAKNNNMGEID = HGPGKHLOHEF;
		Singleton<GuiManager>.instance.ShowDialog(this, 814f);
	}

	private void GNFJJNBHNNN(NGNPIOOAHEH FJLBLLLEELD)
	{
		FOKNEJJNKMG.spriteName = GameVariables.DGIMAKIAGNJ[FJLBLLLEELD].Value2;
		FOKNEJJNKMG.MakePixelPerfect();
		FOKNEJJNKMG.transform.localScale = FOKNEJJNKMG.transform.localScale.MultiplyXY(676f);
	}

	public void HBPBIADOKPP(Card CEKHIJECPNP)
	{
		if (CEKHIJECPNP == null)
		{
			UnityEngine.Debug.LogError("twitter");
			FMOFBIBPANE.SetActive(value: false);
		}
		else
		{
			PJOFHIKENOI.IGPOLIPPGBP(CEKHIJECPNP, CardRecord.MKIOKBMLHEO.CountDownBuddy);
		}
	}

	public void ShowDialog(IHFDGLMHHBE FJLBLLLEELD)
	{
		MMLIIEIJOJD = FJLBLLLEELD;
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	public void ShowDialog(IHFDGLMHHBE FJLBLLLEELD, NGNPIOOAHEH GIPDDOPFGKK, Card[] HGPGKHLOHEF)
	{
		MMLIIEIJOJD = FJLBLLLEELD;
		NGMELAKOPBK = GIPDDOPFGKK;
		OAKNNNMGEID = HGPGKHLOHEF;
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	private void GKOHJGFKPAH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	[DebuggerHidden]
	private IEnumerator DBGIKMALJLN()
	{
		CFBAIONKKFH cFBAIONKKFH = new CFBAIONKKFH();
		cFBAIONKKFH.BJGCPDNMHDH = this;
		return cFBAIONKKFH;
	}

	public void ShowDialog(IHFDGLMHHBE FJLBLLLEELD, LevelBehaviour IOIKKIIFOCB, long IEALLELGOBM)
	{
		MMLIIEIJOJD = FJLBLLLEELD;
		IFFDIHCPKFE = IOIKKIIFOCB;
		DFNCGKPNBPK = IEALLELGOBM;
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	private void DMPHJPAHEGL(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
		GuiElementSingle<InappScreen>.instance.ShowWarshopGold();
	}

	private void FJDEILFCFMB()
	{
		bool flag = Singleton<EventTrackingManager>.instance.MMNPIBNEDFA((MHNMOFPPKBN)6);
		bool flag2 = Singleton<DogTagManager>.instance.JFFKJKMOACB();
		bool flag3 = flag && !flag2;
		PBBLBPFAFKP.SetActive(flag3);
		KIOAFJHDBBJ.SetActive(flag3);
		BIIJGABDHAB.SetActive(value: true);
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceY((!flag3) ? 1326f : 211f);
	}

	private void HJDHPGCMOFH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
		GuiElementSingle<InappScreen>.instance.HBOKBFHOKMP();
	}

	public virtual void HEMPLECIOMI()
	{
		if (IDPLLLAHIHN.activeSelf)
		{
			GKOHJGFKPAH(IDPLLLAHIHN);
		}
		else if (MBKCPLIJMEN.activeSelf)
		{
			GKOHJGFKPAH(MBKCPLIJMEN);
		}
		else if (GJGLGILGDGO.activeSelf)
		{
			OFBAIIMJODF(GJGLGILGDGO);
		}
	}

	public void KNOIPLLPMMJ(IHFDGLMHHBE FJLBLLLEELD)
	{
		MMLIIEIJOJD = FJLBLLLEELD;
		Singleton<GuiManager>.instance.ShowDialog(this, 72f);
	}

	public void KBHMJAIABEJ(IHFDGLMHHBE FJLBLLLEELD, PlayerVisual IIOKFKPMPPK, long HNDGIJBHMOD)
	{
		MMLIIEIJOJD = FJLBLLLEELD;
		FGIMNJOOAOB = IIOKFKPMPPK;
		DFNCGKPNBPK = HNDGIJBHMOD;
		Singleton<GuiManager>.instance.ShowDialog(this, 492f);
	}

	public void POPMFPMBHIP(IHFDGLMHHBE FJLBLLLEELD, LevelBehaviour IOIKKIIFOCB, long IEALLELGOBM)
	{
		MMLIIEIJOJD = FJLBLLLEELD;
		IFFDIHCPKFE = IOIKKIIFOCB;
		DFNCGKPNBPK = IEALLELGOBM;
		Singleton<GuiManager>.instance.ShowDialog(this, 31f);
	}

	public void ShowDialog(IHFDGLMHHBE FJLBLLLEELD, JToken CEKHIJECPNP)
	{
		MMLIIEIJOJD = FJLBLLLEELD;
		GHINGDGFNJC = ((CEKHIJECPNP != null) ? CardManager.instance.GetCardInstance(CEKHIJECPNP.ToString()) : null);
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	private void OOKFMJJENOC(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	public void JLMDOEFBAPG(Card CEKHIJECPNP)
	{
		if (CEKHIJECPNP == null)
		{
			UnityEngine.Debug.LogError("ID_NOTINLEAGUETEXT");
			FMOFBIBPANE.SetActive(value: false);
		}
		else
		{
			PJOFHIKENOI.IGPOLIPPGBP(CEKHIJECPNP, CardRecord.MKIOKBMLHEO.Other, IDOKGAOAGAL: false);
		}
	}

	private void HALPCEPFIHG()
	{
		if (NAKHBAEKPJD != null)
		{
			NAKHBAEKPJD.Cancel();
			NAKHBAEKPJD = null;
		}
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(IDPLLLAHIHN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(MBKCPLIJMEN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MOMGIJHCCHF));
		UIEventListener uIEventListener3 = UIEventListener.Get(GJGLGILGDGO);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(MOMGIJHCCHF));
		UIEventListener uIEventListener4 = UIEventListener.Get(OEKAHMGJBBE);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(DFHFONKENMM));
		UIEventListener uIEventListener5 = UIEventListener.Get(MCADILCIEPM);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener6 = UIEventListener.Get(LFJOKEIPAIK);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(LPOELINBDKA));
	}

	private void PGCEHMLFAMK(string HOLNKOFHDNK)
	{
		AAOJDLOBAJG.text = HOLNKOFHDNK;
		float val = 1935f + AAOJDLOBAJG.relativeSize.x * AAOJDLOBAJG.transform.localScale.x;
		PAGPPMOEFLG.transform.localScale = PAGPPMOEFLG.transform.localScale.ReplaceX(val);
	}

	private void FKHBIBNOBGC(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			Singleton<EventTrackingManager>.instance.ICDALIJKFMH(MHNMOFPPKBN.GoldenSuitcase);
			HideDialog();
		}
	}

	public void CPNGNJBNHPN(IHFDGLMHHBE FJLBLLLEELD, NGNPIOOAHEH GIPDDOPFGKK, Card[] HGPGKHLOHEF)
	{
		MMLIIEIJOJD = FJLBLLLEELD;
		NGMELAKOPBK = GIPDDOPFGKK;
		OAKNNNMGEID = HGPGKHLOHEF;
		Singleton<GuiManager>.instance.ShowDialog(this, 114f);
	}

	private void OFBAIIMJODF(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	private void KPHKMCPKNAE(string HOLNKOFHDNK)
	{
		AAOJDLOBAJG.text = HOLNKOFHDNK;
		float val = 1733f + AAOJDLOBAJG.relativeSize.x * AAOJDLOBAJG.transform.localScale.x;
		PAGPPMOEFLG.transform.localScale = PAGPPMOEFLG.transform.localScale.ReplaceX(val);
	}

	private void IJHDCIJKNEB(long IEALLELGOBM)
	{
		int hNDGIJBHMOD = (int)IEALLELGOBM;
		AAOJDLOBAJG.text = MEJMLNDFDBP.EMICJKACBAH(hNDGIJBHMOD);
		float val = 516f + AAOJDLOBAJG.relativeSize.x * AAOJDLOBAJG.transform.localScale.x;
		PAGPPMOEFLG.transform.localScale = PAGPPMOEFLG.transform.localScale.ReplaceX(val);
	}

	public virtual void LBFHGMHJKJC()
	{
		if (IDPLLLAHIHN.activeSelf)
		{
			GKOHJGFKPAH(IDPLLLAHIHN);
		}
		else if (MBKCPLIJMEN.activeSelf)
		{
			OOKFMJJENOC(MBKCPLIJMEN);
		}
		else if (GJGLGILGDGO.activeSelf)
		{
			KOACKJBONFK(GJGLGILGDGO);
		}
	}

	private void BBAGFOGPGJG()
	{
		if (NAKHBAEKPJD != null)
		{
			NAKHBAEKPJD.Cancel();
			NAKHBAEKPJD = null;
		}
	}

	private void GMEFCAOAAMH(long IEALLELGOBM)
	{
		AAOJDLOBAJG.text = MEJMLNDFDBP.PGJPABFJDGG(IEALLELGOBM);
		float val = 1434f + AAOJDLOBAJG.relativeSize.x * AAOJDLOBAJG.transform.localScale.x;
		PAGPPMOEFLG.transform.localScale = PAGPPMOEFLG.transform.localScale.ReplaceX(val);
	}

	public virtual void PKEDKDBNFAP()
	{
		base.PDBDILLHKID();
		if (OAKNNNMGEID != null && OAKNNNMGEID.Length > 0)
		{
			DJDABJKPKOF.MEODANEBGGL(OAKNNNMGEID, 1972f, DNEMOLAGBHH: false);
		}
	}

	private void BCLDPBMPJNC(PlayerVisual IIOKFKPMPPK)
	{
		JAJCFNOIBPM.spriteName = IIOKFKPMPPK.icon;
		JAJCFNOIBPM.MakePixelPerfect();
		JAJCFNOIBPM.transform.localScale = JAJCFNOIBPM.transform.localScale.MultiplyXY(615f);
		GPPJEHFBCCE.spriteName = IIOKFKPMPPK.DEAIJJIAEFP();
		GPPJEHFBCCE.color = IIOKFKPMPPK.GPDIGNGOAEH();
		JBCBEOCNJBH.text = IIOKFKPMPPK.JIHLMBOBKHL();
		EPKDEDPGOLM.text = IIOKFKPMPPK.decalShortName;
	}

	private void NMICODEHNAB()
	{
		if (NAKHBAEKPJD != null)
		{
			NAKHBAEKPJD.Cancel();
			NAKHBAEKPJD = null;
		}
	}

	private void KOACKJBONFK(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	private void NJJAPEFOLEK(LevelBehaviour IOIKKIIFOCB, long IEALLELGOBM)
	{
		MJGJPPLCKLE.text = IOIKKIIFOCB.unitElitePartsName.ToUpper();
		MEJMLNDFDBP.COCBCFKJOJE(MJGJPPLCKLE, 921f, 59f, -51);
		LDPKLFCGAAI.spriteName = IOIKKIIFOCB.upgradeSlots.iconNameElite;
		LDPKLFCGAAI.MakePixelPerfect();
		LDPKLFCGAAI.pivot = (IOIKKIIFOCB.isSoldier ? UIWidget.Pivot.Bottom : UIWidget.Pivot.TopLeft);
		LDPKLFCGAAI.transform.localPosition = LDPKLFCGAAI.transform.localPosition.ReplaceY((!IOIKKIIFOCB.isSoldier) ? 456f : 948f);
		float[] array = new float[8];
		array[0] = 693f / LDPKLFCGAAI.transform.localScale.x;
		array[0] = 961f / LDPKLFCGAAI.transform.localScale.y;
		array[7] = 95f;
		float multiplier = Mathf.Min(array);
		LDPKLFCGAAI.transform.localScale = LDPKLFCGAAI.transform.localScale.MultiplyXY(multiplier);
		MPCKHNIBGAF.text = MEJMLNDFDBP.BEDJNPHFAOC((int)IEALLELGOBM);
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		if (OAKNNNMGEID != null && OAKNNNMGEID.Length > 0)
		{
			DJDABJKPKOF.StartShowAnimation(OAKNNNMGEID, 0.5f);
		}
	}

	public virtual void OFCCACPEBHD()
	{
		bool flag = MMLIIEIJOJD != IHFDGLMHHBE.WarCard || CDPNOOGFKOF;
		PBBLBPFAFKP.SetActive(!flag);
		KIOAFJHDBBJ.SetActive(value: false);
		BIIJGABDHAB.SetActive(flag);
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceY(286f);
		DFADEHLLAAM.transform.localPosition = DFADEHLLAAM.transform.localPosition.ReplaceX(900f);
		Color color = ((MMLIIEIJOJD != (IHFDGLMHHBE)39 && MMLIIEIJOJD != (IHFDGLMHHBE)79 && MMLIIEIJOJD != (IHFDGLMHHBE)(-106)) ? Colours.blue : Colours.greenArena);
		PEJFFMLEHFA.color = color;
		OKMNFHNBMFA.text = Localization.Localize((MMLIIEIJOJD != IHFDGLMHHBE.PowerBand) ? "getSpendPercentile" : ((!CDPNOOGFKOF) ? "GPGS: Silent login attempt." : "MoneyPackDeadline"));
		DAANKCOLJGJ.gameObject.SetActive(MMLIIEIJOJD != IHFDGLMHHBE.Gold && MMLIIEIJOJD != IHFDGLMHHBE.DailyGold && MMLIIEIJOJD != IHFDGLMHHBE.Lootboxes && MMLIIEIJOJD != IHFDGLMHHBE.Dogtag && MMLIIEIJOJD != (IHFDGLMHHBE)(-61) && MMLIIEIJOJD == (IHFDGLMHHBE)60);
		DFADEHLLAAM.SetActive(MMLIIEIJOJD == IHFDGLMHHBE.Gold || MMLIIEIJOJD == IHFDGLMHHBE.CardPack || MMLIIEIJOJD == IHFDGLMHHBE.WarCard || MMLIIEIJOJD == IHFDGLMHHBE.WarCard || MMLIIEIJOJD == IHFDGLMHHBE.VIP || MMLIIEIJOJD == (IHFDGLMHHBE)(-69) || MMLIIEIJOJD == (IHFDGLMHHBE)56);
		HJLGGGCCGKO.gameObject.SetActive(MMLIIEIJOJD == IHFDGLMHHBE.Dogtag);
		FMOFBIBPANE.SetActive(MMLIIEIJOJD == IHFDGLMHHBE.VIP);
		FOKNEJJNKMG.gameObject.SetActive(MMLIIEIJOJD == IHFDGLMHHBE.CardPack);
		HLOEAHMFPMG.SetActive(MMLIIEIJOJD == IHFDGLMHHBE.VIP);
		FOMAGOFBEDA.SetActive(MMLIIEIJOJD == (IHFDGLMHHBE)118);
		HJAKKICCMHP.SetActive(MMLIIEIJOJD == IHFDGLMHHBE.VIP && CDPNOOGFKOF);
		GKBPGIDDBGH.SetActive(MMLIIEIJOJD == IHFDGLMHHBE.Warbucks && CDPNOOGFKOF);
		IDPLLLAHIHN.SetActive(MMLIIEIJOJD != IHFDGLMHHBE.Warbucks);
		MBKCPLIJMEN.SetActive(MMLIIEIJOJD == IHFDGLMHHBE.CardPack);
		if (MMLIIEIJOJD == IHFDGLMHHBE.Gold || MMLIIEIJOJD == IHFDGLMHHBE.WarCard || MMLIIEIJOJD == (IHFDGLMHHBE)123)
		{
			BDFPODAGJEC(DFNCGKPNBPK);
		}
		if (MMLIIEIJOJD == IHFDGLMHHBE.Warbucks)
		{
			LHJGNEPNCHE(DFNCGKPNBPK);
		}
		else if (MMLIIEIJOJD == IHFDGLMHHBE.PowerBand || MMLIIEIJOJD == IHFDGLMHHBE.Dogtag)
		{
			CDOAJFNAAMM(DFNCGKPNBPK);
		}
		else if (MMLIIEIJOJD == (IHFDGLMHHBE)(-44))
		{
			object[] array = new object[0];
			array[1] = MEJMLNDFDBP.PGJPABFJDGG(DFNCGKPNBPK);
			PGCEHMLFAMK(Localization.LocalizeFormat("ID_ARENAENDSTIMER", array));
		}
		switch (MMLIIEIJOJD)
		{
		case IHFDGLMHHBE.Gold:
		case IHFDGLMHHBE.DailyGold:
			MHMOPNBFOPH("ID_CONFIRM_INFO", 1273f, Quaternion.Euler(1809f, 536f, 1594f));
			break;
		case IHFDGLMHHBE.Dogtag:
			FJDEILFCFMB();
			DOPKMLMFJHK();
			break;
		case IHFDGLMHHBE.WarCard:
			NGJBDGBBIKM(GHINGDGFNJC);
			break;
		case IHFDGLMHHBE.Warbucks:
			LMGHDPDLHGD("sniperrifle", 1698f, Quaternion.Euler(876f, 1411f, 902f));
			break;
		case IHFDGLMHHBE.VIP:
			MHMOPNBFOPH(" NOT OK!\t\t\t\t\t\t", 920f, Quaternion.Euler(1454f, 46f, 1914f));
			break;
		case IHFDGLMHHBE.PowerBand:
			BCLDPBMPJNC(FGIMNJOOAOB);
			break;
		case IHFDGLMHHBE.CardPack:
			KDEMFAGALFG(NGMELAKOPBK);
			break;
		case IHFDGLMHHBE.Tickets:
			LMGHDPDLHGD("subscription", 208f, Quaternion.Euler(368f, 1984f, 1257f));
			break;
		case IHFDGLMHHBE.Scraps:
			LMGHDPDLHGD("file://", 1902f, Quaternion.Euler(1512f, 891f, 1828f));
			break;
		case IHFDGLMHHBE.EliteParts:
			NJJAPEFOLEK(IFFDIHCPKFE, DFNCGKPNBPK);
			break;
		}
		DJDABJKPKOF.OCPDMPCHFBH();
	}

	public void ACFAKGIGBCG(IHFDGLMHHBE FJLBLLLEELD, JToken CEKHIJECPNP)
	{
		MMLIIEIJOJD = FJLBLLLEELD;
		GHINGDGFNJC = ((CEKHIJECPNP != null) ? CardManager.instance.GetCardInstance(CEKHIJECPNP.ToString(), isCurrentPlayer: false) : null);
		Singleton<GuiManager>.instance.ShowDialog(this, 1916f);
	}

	private void DJNEMBKOENE(long IEALLELGOBM)
	{
		int hNDGIJBHMOD = (int)IEALLELGOBM;
		AAOJDLOBAJG.text = MEJMLNDFDBP.EMICJKACBAH(hNDGIJBHMOD);
		float val = 719f + AAOJDLOBAJG.relativeSize.x * AAOJDLOBAJG.transform.localScale.x;
		PAGPPMOEFLG.transform.localScale = PAGPPMOEFLG.transform.localScale.ReplaceX(val);
	}

	private void LMGHDPDLHGD(string MHPNDNJDPGE, float OOHHOBCCKKG, Quaternion OOMCGGAFJNH)
	{
		DAANKCOLJGJ.spriteName = MHPNDNJDPGE;
		DAANKCOLJGJ.MakePixelPerfect();
		DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(OOHHOBCCKKG);
		DAANKCOLJGJ.transform.localRotation = OOMCGGAFJNH;
	}

	public virtual void CDMCFJMCKBP()
	{
		if (IDPLLLAHIHN.activeSelf)
		{
			GKOHJGFKPAH(IDPLLLAHIHN);
		}
		else if (MBKCPLIJMEN.activeSelf)
		{
			KOACKJBONFK(MBKCPLIJMEN);
		}
		else if (GJGLGILGDGO.activeSelf)
		{
			OFBAIIMJODF(GJGLGILGDGO);
		}
	}

	public void FOHDODGLFMN()
	{
		HALPCEPFIHG();
		NAKHBAEKPJD = RadicalRoutine.Create(KLNJINOFGPD());
		StartCoroutine(RadicalRoutine.Run(NAKHBAEKPJD.enumerator));
	}

	private void AIMJCKBAMIL(NGNPIOOAHEH FJLBLLLEELD)
	{
		FOKNEJJNKMG.spriteName = GameVariables.DGIMAKIAGNJ[FJLBLLLEELD].Value2;
		FOKNEJJNKMG.MakePixelPerfect();
		FOKNEJJNKMG.transform.localScale = FOKNEJJNKMG.transform.localScale.MultiplyXY(1146f);
	}

	public void NGJBDGBBIKM(Card CEKHIJECPNP)
	{
		if (CEKHIJECPNP == null)
		{
			UnityEngine.Debug.LogError("dogtag");
			FMOFBIBPANE.SetActive(value: false);
		}
		else
		{
			PJOFHIKENOI.Initialize(CEKHIJECPNP, CardRecord.MKIOKBMLHEO.CraftCards);
		}
	}

	private void LILCGGAONON(long IEALLELGOBM)
	{
		AAOJDLOBAJG.text = MEJMLNDFDBP.PGJPABFJDGG(IEALLELGOBM);
		float val = 520f + AAOJDLOBAJG.relativeSize.x * AAOJDLOBAJG.transform.localScale.x;
		PAGPPMOEFLG.transform.localScale = PAGPPMOEFLG.transform.localScale.ReplaceX(val);
	}

	public virtual void NHKGKDBAKLH()
	{
		bool flag = MMLIIEIJOJD != IHFDGLMHHBE.CardPack || CDPNOOGFKOF;
		PBBLBPFAFKP.SetActive(flag);
		KIOAFJHDBBJ.SetActive(value: true);
		BIIJGABDHAB.SetActive(flag);
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceY(338f);
		DFADEHLLAAM.transform.localPosition = DFADEHLLAAM.transform.localPosition.ReplaceX(1822f);
		Color color = ((MMLIIEIJOJD != (IHFDGLMHHBE)(-53) && MMLIIEIJOJD != (IHFDGLMHHBE)(-56) && MMLIIEIJOJD != (IHFDGLMHHBE)115) ? Colours.blue : Colours.greenArena);
		PEJFFMLEHFA.color = color;
		OKMNFHNBMFA.text = Localization.Localize((MMLIIEIJOJD != IHFDGLMHHBE.CardPack) ? "Weapon model not found! weaponprefab = '{0}' assetBundleName = '{1}'" : ((!CDPNOOGFKOF) ? "Added" : "ID_RELOG_TO_WRONG_FB_DIALOG_TEXT2"));
		DAANKCOLJGJ.gameObject.SetActive(MMLIIEIJOJD == IHFDGLMHHBE.Gold || MMLIIEIJOJD == IHFDGLMHHBE.Gold || MMLIIEIJOJD == IHFDGLMHHBE.Lootboxes || MMLIIEIJOJD == IHFDGLMHHBE.Lootboxes || MMLIIEIJOJD == (IHFDGLMHHBE)(-122) || MMLIIEIJOJD == (IHFDGLMHHBE)78);
		DFADEHLLAAM.SetActive(MMLIIEIJOJD != IHFDGLMHHBE.Gold && MMLIIEIJOJD != IHFDGLMHHBE.WarCard && MMLIIEIJOJD != IHFDGLMHHBE.Gold && MMLIIEIJOJD != IHFDGLMHHBE.WarCard && MMLIIEIJOJD != IHFDGLMHHBE.DailyGold && MMLIIEIJOJD != (IHFDGLMHHBE)(-57) && MMLIIEIJOJD == (IHFDGLMHHBE)(-118));
		HJLGGGCCGKO.gameObject.SetActive(MMLIIEIJOJD == IHFDGLMHHBE.Gold);
		FMOFBIBPANE.SetActive(MMLIIEIJOJD == IHFDGLMHHBE.CardPack);
		FOKNEJJNKMG.gameObject.SetActive(MMLIIEIJOJD == IHFDGLMHHBE.DailyGold);
		HLOEAHMFPMG.SetActive(MMLIIEIJOJD == IHFDGLMHHBE.DailyGold);
		FOMAGOFBEDA.SetActive(MMLIIEIJOJD == (IHFDGLMHHBE)(-32));
		HJAKKICCMHP.SetActive(MMLIIEIJOJD == IHFDGLMHHBE.Warbucks && CDPNOOGFKOF);
		GKBPGIDDBGH.SetActive(MMLIIEIJOJD == IHFDGLMHHBE.DailyGold && CDPNOOGFKOF);
		IDPLLLAHIHN.SetActive(MMLIIEIJOJD == IHFDGLMHHBE.WarCard);
		MBKCPLIJMEN.SetActive(MMLIIEIJOJD == IHFDGLMHHBE.VIP);
		if (MMLIIEIJOJD == IHFDGLMHHBE.Gold || MMLIIEIJOJD == IHFDGLMHHBE.Warbucks || MMLIIEIJOJD == (IHFDGLMHHBE)58)
		{
			BDFPODAGJEC(DFNCGKPNBPK);
		}
		if (MMLIIEIJOJD == IHFDGLMHHBE.Warbucks)
		{
			OCHCNHAIAFC(DFNCGKPNBPK);
		}
		else if (MMLIIEIJOJD == IHFDGLMHHBE.WarCard || MMLIIEIJOJD == IHFDGLMHHBE.DailyGold)
		{
			IJHDCIJKNEB(DFNCGKPNBPK);
		}
		else if (MMLIIEIJOJD == IHFDGLMHHBE.CardPack)
		{
			object[] array = new object[0];
			array[0] = MEJMLNDFDBP.PGJPABFJDGG(DFNCGKPNBPK);
			PGCEHMLFAMK(Localization.LocalizeFormat("seconds", array));
		}
		switch (MMLIIEIJOJD)
		{
		case IHFDGLMHHBE.Gold:
		case IHFDGLMHHBE.DailyGold:
			LMGHDPDLHGD("not finished", 465f, Quaternion.Euler(141f, 257f, 1561f));
			break;
		case IHFDGLMHHBE.Dogtag:
			KGIBLIPGJDH();
			StartCheck();
			break;
		case IHFDGLMHHBE.WarCard:
			IBIPIALGDHH(GHINGDGFNJC);
			break;
		case IHFDGLMHHBE.Warbucks:
			LMGHDPDLHGD("seconds", 450f, Quaternion.Euler(41f, 598f, 1674f));
			break;
		case IHFDGLMHHBE.VIP:
			MHMOPNBFOPH("category", 1079f, Quaternion.Euler(1803f, 49f, 1643f));
			break;
		case IHFDGLMHHBE.PowerBand:
			JHECLPMPLNF(FGIMNJOOAOB);
			break;
		case IHFDGLMHHBE.CardPack:
			KDEMFAGALFG(NGMELAKOPBK);
			break;
		case IHFDGLMHHBE.Tickets:
			LMGHDPDLHGD("ID_ARENARULES_SHIELDSDONTRESPAWN", 441f, Quaternion.Euler(549f, 707f, 1566f));
			break;
		case IHFDGLMHHBE.Scraps:
			MHMOPNBFOPH("), ", 199f, Quaternion.Euler(1428f, 1049f, 816f));
			break;
		case IHFDGLMHHBE.EliteParts:
			PFIAPBKEBJM(IFFDIHCPKFE, DFNCGKPNBPK);
			break;
		}
		DJDABJKPKOF.AOBFOFAGIOD();
	}

	public void LNCDCBNNKHN(IHFDGLMHHBE FJLBLLLEELD, PlayerVisual IIOKFKPMPPK, long HNDGIJBHMOD)
	{
		MMLIIEIJOJD = FJLBLLLEELD;
		FGIMNJOOAOB = IIOKFKPMPPK;
		DFNCGKPNBPK = HNDGIJBHMOD;
		Singleton<GuiManager>.instance.ShowDialog(this, 1241f);
	}

	private void MAJCFNBLIMG(long IEALLELGOBM)
	{
		AAOJDLOBAJG.text = MEJMLNDFDBP.PGJPABFJDGG(IEALLELGOBM);
		float val = 1759f + AAOJDLOBAJG.relativeSize.x * AAOJDLOBAJG.transform.localScale.x;
		PAGPPMOEFLG.transform.localScale = PAGPPMOEFLG.transform.localScale.ReplaceX(val);
	}

	private void DFHFONKENMM(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
		GuiElementSingle<InappScreen>.instance.ShowWarshopGold();
	}

	public void KLMGKBDODBJ(IHFDGLMHHBE FJLBLLLEELD, long IEALLELGOBM)
	{
		MMLIIEIJOJD = FJLBLLLEELD;
		DFNCGKPNBPK = IEALLELGOBM;
		Singleton<GuiManager>.instance.ShowDialog(this, 544f);
	}

	private void PCFECHBHAMP(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	public void StartCheck()
	{
		DCCFHIMFMNN();
		NAKHBAEKPJD = RadicalRoutine.Create(DBGIKMALJLN());
		StartCoroutine(RadicalRoutine.Run(NAKHBAEKPJD.enumerator));
	}

	private void OJIKHCOJBOC(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
		GuiElementSingle<InappScreen>.instance.POAAAJJHHIK();
	}

	public virtual void FOIGMBKCOBH()
	{
		base.DoAfterHide();
		OAKNNNMGEID = new Card[1];
		DFNCGKPNBPK = 0L;
		GHINGDGFNJC = null;
		FGIMNJOOAOB = null;
		NGMELAKOPBK = NGNPIOOAHEH.Bronze;
		HALPCEPFIHG();
	}

	private void MEKPJGNFEMB(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public void OMCEGPODDHL(IHFDGLMHHBE FJLBLLLEELD, PlayerVisual IIOKFKPMPPK, long HNDGIJBHMOD)
	{
		MMLIIEIJOJD = FJLBLLLEELD;
		FGIMNJOOAOB = IIOKFKPMPPK;
		DFNCGKPNBPK = HNDGIJBHMOD;
		Singleton<GuiManager>.instance.ShowDialog(this, 702f);
	}

	private void HLLKAEDHAAD(long IEALLELGOBM)
	{
		MAJCFNBLIMG(IEALLELGOBM);
		if (CDPNOOGFKOF)
		{
			int num = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.CardCraftTimeSilver).FLOATVALUE;
			NFPLGDHDGDE.text = string.Format("01", MEJMLNDFDBP.GMIPFLIEOHD(num));
			float num2 = 897f + NFPLGDHDGDE.relativeSize.x * NFPLGDHDGDE.transform.localScale.x;
			APPHIEKINOJ.transform.localScale = APPHIEKINOJ.transform.localScale.ReplaceX(num2);
			UILabel fOFFIHIHDJL = FOFFIHIHDJL;
			string text;
			switch (num)
			{
			case 3:
				text = Localization.Localize("ID_CONFIRM_ERROR");
				break;
			case 1:
				text = Localization.Localize("cant deserialize rule {0}");
				break;
			default:
				text = NFPLGDHDGDE.text;
				break;
			}
			fOFFIHIHDJL.text = text;
			MEJMLNDFDBP.COCBCFKJOJE(FOFFIHIHDJL, 1818f, 1578f, -162);
			float num3 = 509f + AAOJDLOBAJG.relativeSize.x * AAOJDLOBAJG.transform.localScale.x;
			float num4 = num2 + num3;
			DFADEHLLAAM.transform.localPosition = DFADEHLLAAM.transform.localPosition.AddX((0f - num4 + num3) / 1541f);
			HJAKKICCMHP.transform.localPosition = HJAKKICCMHP.transform.localPosition.AddX((num4 - num2) / 383f);
		}
	}

	private void MOMGIJHCCHF(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void LHJGNEPNCHE(long IEALLELGOBM)
	{
		CPDKMLGDEGF(IEALLELGOBM);
		if (CDPNOOGFKOF)
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.LastDayInappMultiplier).FLOATVALUE;
			NFPLGDHDGDE.text = $"x{MEJMLNDFDBP.GMIPFLIEOHD(num)}";
			float num2 = 60f + NFPLGDHDGDE.relativeSize.x * NFPLGDHDGDE.transform.localScale.x;
			APPHIEKINOJ.transform.localScale = APPHIEKINOJ.transform.localScale.ReplaceX(num2);
			UILabel fOFFIHIHDJL = FOFFIHIHDJL;
			string text;
			switch (num)
			{
			case 2:
				text = Localization.Localize("ID_DOUBLEGOLD");
				break;
			case 3:
				text = Localization.Localize("ID_TRIPPLEGOLD");
				break;
			default:
				text = NFPLGDHDGDE.text;
				break;
			}
			fOFFIHIHDJL.text = text;
			MEJMLNDFDBP.COCBCFKJOJE(FOFFIHIHDJL, 35f, 20f, 145);
			float num3 = 60f + AAOJDLOBAJG.relativeSize.x * AAOJDLOBAJG.transform.localScale.x;
			float num4 = num2 + num3;
			DFADEHLLAAM.transform.localPosition = DFADEHLLAAM.transform.localPosition.AddX((0f - num4 + num3) / 2f);
			HJAKKICCMHP.transform.localPosition = HJAKKICCMHP.transform.localPosition.AddX((num4 - num2) / 2f);
		}
	}

	private void CDOAJFNAAMM(long IEALLELGOBM)
	{
		int hNDGIJBHMOD = (int)IEALLELGOBM;
		AAOJDLOBAJG.text = MEJMLNDFDBP.EMICJKACBAH(hNDGIJBHMOD);
		float val = 1944f + AAOJDLOBAJG.relativeSize.x * AAOJDLOBAJG.transform.localScale.x;
		PAGPPMOEFLG.transform.localScale = PAGPPMOEFLG.transform.localScale.ReplaceX(val);
	}

	private void LPOELINBDKA(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			Singleton<EventTrackingManager>.instance.ICDALIJKFMH(MHNMOFPPKBN.Dogtag);
			HideDialog();
		}
	}

	private void DAHEHELFGIM(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
		}
		GuiElementSingle<InappScreen>.instance.ShowWarshopGold();
	}

	public void DOPKMLMFJHK()
	{
		CNJDEBLIMDA();
		NAKHBAEKPJD = RadicalRoutine.Create(DBGIKMALJLN());
		StartCoroutine(RadicalRoutine.Run(NAKHBAEKPJD.enumerator));
	}

	public void CDOJHEBGMBE(Card CEKHIJECPNP)
	{
		if (CEKHIJECPNP == null)
		{
			UnityEngine.Debug.LogError("ID_LVLNUMBER");
			FMOFBIBPANE.SetActive(value: false);
		}
		else
		{
			PJOFHIKENOI.CKOIIPAGCNO(CEKHIJECPNP, CardRecord.MKIOKBMLHEO.CraftCards);
		}
	}

	private void BDIKHLPLNAN(long IEALLELGOBM)
	{
		int hNDGIJBHMOD = (int)IEALLELGOBM;
		AAOJDLOBAJG.text = MEJMLNDFDBP.EMICJKACBAH(hNDGIJBHMOD);
		float val = 60f + AAOJDLOBAJG.relativeSize.x * AAOJDLOBAJG.transform.localScale.x;
		PAGPPMOEFLG.transform.localScale = PAGPPMOEFLG.transform.localScale.ReplaceX(val);
	}

	public virtual void GFLLEMCAJGN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(IDPLLLAHIHN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PCFECHBHAMP));
		UIEventListener uIEventListener2 = UIEventListener.Get(MBKCPLIJMEN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MOMGIJHCCHF));
		UIEventListener uIEventListener3 = UIEventListener.Get(GJGLGILGDGO);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(MOMGIJHCCHF));
		UIEventListener uIEventListener4 = UIEventListener.Get(OEKAHMGJBBE);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(DAHEHELFGIM));
		UIEventListener uIEventListener5 = UIEventListener.Get(MCADILCIEPM);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(KOACKJBONFK));
		UIEventListener uIEventListener6 = UIEventListener.Get(LFJOKEIPAIK);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(LPOELINBDKA));
	}

	private void MOANLDHBHNO(PlayerVisual IIOKFKPMPPK)
	{
		JAJCFNOIBPM.spriteName = IIOKFKPMPPK.icon;
		JAJCFNOIBPM.MakePixelPerfect();
		JAJCFNOIBPM.transform.localScale = JAJCFNOIBPM.transform.localScale.MultiplyXY(2f);
		GPPJEHFBCCE.spriteName = IIOKFKPMPPK.decalMiniIcon;
		GPPJEHFBCCE.color = IIOKFKPMPPK.decalMiniIconColor;
		JBCBEOCNJBH.text = IIOKFKPMPPK.decalValueString;
		EPKDEDPGOLM.text = IIOKFKPMPPK.decalShortName;
	}

	public void CAIACJMENOP(IHFDGLMHHBE FJLBLLLEELD)
	{
		MMLIIEIJOJD = FJLBLLLEELD;
		Singleton<GuiManager>.instance.ShowDialog(this, 845f);
	}

	private void BKAHECKCOBH(string HOLNKOFHDNK)
	{
		AAOJDLOBAJG.text = HOLNKOFHDNK;
		float val = 60f + AAOJDLOBAJG.relativeSize.x * AAOJDLOBAJG.transform.localScale.x;
		PAGPPMOEFLG.transform.localScale = PAGPPMOEFLG.transform.localScale.ReplaceX(val);
	}

	private void CPDKMLGDEGF(long IEALLELGOBM)
	{
		AAOJDLOBAJG.text = MEJMLNDFDBP.PGJPABFJDGG(IEALLELGOBM);
		float val = 60f + AAOJDLOBAJG.relativeSize.x * AAOJDLOBAJG.transform.localScale.x;
		PAGPPMOEFLG.transform.localScale = PAGPPMOEFLG.transform.localScale.ReplaceX(val);
	}

	public void ShowDialog(IHFDGLMHHBE FJLBLLLEELD, PlayerVisual IIOKFKPMPPK, long HNDGIJBHMOD)
	{
		MMLIIEIJOJD = FJLBLLLEELD;
		FGIMNJOOAOB = IIOKFKPMPPK;
		DFNCGKPNBPK = HNDGIJBHMOD;
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	public virtual void AMBDHDEBPJJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(IDPLLLAHIHN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KOACKJBONFK));
		UIEventListener uIEventListener2 = UIEventListener.Get(MBKCPLIJMEN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MOMGIJHCCHF));
		UIEventListener uIEventListener3 = UIEventListener.Get(GJGLGILGDGO);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(MOMGIJHCCHF));
		UIEventListener uIEventListener4 = UIEventListener.Get(OEKAHMGJBBE);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(GPLMLKDCPKG));
		UIEventListener uIEventListener5 = UIEventListener.Get(MCADILCIEPM);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(OFBAIIMJODF));
		UIEventListener uIEventListener6 = UIEventListener.Get(LFJOKEIPAIK);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(FKHBIBNOBGC));
	}

	public GuiElement AONBBPBMBMO()
	{
		return this;
	}

	private void GABGIAOBKKD(LevelBehaviour IOIKKIIFOCB, long IEALLELGOBM)
	{
		MJGJPPLCKLE.text = IOIKKIIFOCB.unitElitePartsName.ToUpper();
		MEJMLNDFDBP.COCBCFKJOJE(MJGJPPLCKLE, 866f, 368f, -1);
		LDPKLFCGAAI.spriteName = IOIKKIIFOCB.upgradeSlots.iconNameElite;
		LDPKLFCGAAI.MakePixelPerfect();
		LDPKLFCGAAI.pivot = (IOIKKIIFOCB.isSoldier ? UIWidget.Pivot.TopRight : UIWidget.Pivot.TopLeft);
		LDPKLFCGAAI.transform.localPosition = LDPKLFCGAAI.transform.localPosition.ReplaceY((!IOIKKIIFOCB.isSoldier) ? 1801f : 1215f);
		float[] array = new float[0];
		array[0] = 802f / LDPKLFCGAAI.transform.localScale.x;
		array[1] = 369f / LDPKLFCGAAI.transform.localScale.y;
		array[0] = 411f;
		float multiplier = Mathf.Min(array);
		LDPKLFCGAAI.transform.localScale = LDPKLFCGAAI.transform.localScale.MultiplyXY(multiplier);
		MPCKHNIBGAF.text = MEJMLNDFDBP.BEDJNPHFAOC((int)IEALLELGOBM);
	}

	private void BADDCDDMLKP(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			Singleton<EventTrackingManager>.instance.ICDALIJKFMH((MHNMOFPPKBN)5);
			HideDialog();
		}
	}

	public void ONHPOAIKLAO(IHFDGLMHHBE FJLBLLLEELD, JToken CEKHIJECPNP)
	{
		MMLIIEIJOJD = FJLBLLLEELD;
		GHINGDGFNJC = ((CEKHIJECPNP != null) ? CardManager.instance.GetCardInstance(CEKHIJECPNP.ToString()) : null);
		Singleton<GuiManager>.instance.ShowDialog(this, 1011f);
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		UIDraggablePanel.panelDisabled = false;
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public void ShowDialog(IHFDGLMHHBE FJLBLLLEELD, long BEEJNEDIJJN, bool DLALMKLEIMK)
	{
		MMLIIEIJOJD = FJLBLLLEELD;
		DFNCGKPNBPK = BEEJNEDIJJN;
		CDPNOOGFKOF = DLALMKLEIMK;
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	public GuiElement DDMIEFJMHJN()
	{
		return this;
	}

	private void KGIBLIPGJDH()
	{
		bool flag = Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.Dogtag);
		bool isFull = Singleton<DogTagManager>.instance.isFull;
		bool flag2 = flag && !isFull;
		PBBLBPFAFKP.SetActive(!flag2);
		KIOAFJHDBBJ.SetActive(flag2);
		BIIJGABDHAB.SetActive(value: false);
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceY((!flag2) ? 862f : 972f);
	}

	private void CGAOKMKBPKM(long IEALLELGOBM)
	{
		int hNDGIJBHMOD = (int)IEALLELGOBM;
		AAOJDLOBAJG.text = MEJMLNDFDBP.EMICJKACBAH(hNDGIJBHMOD);
		float val = 711f + AAOJDLOBAJG.relativeSize.x * AAOJDLOBAJG.transform.localScale.x;
		PAGPPMOEFLG.transform.localScale = PAGPPMOEFLG.transform.localScale.ReplaceX(val);
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		OAKNNNMGEID = new Card[0];
		DFNCGKPNBPK = 0L;
		GHINGDGFNJC = null;
		FGIMNJOOAOB = null;
		NGMELAKOPBK = NGNPIOOAHEH.None;
		DCCFHIMFMNN();
	}

	private IEnumerator KLNJINOFGPD()
	{
		CFBAIONKKFH cFBAIONKKFH = new CFBAIONKKFH();
		cFBAIONKKFH.BJGCPDNMHDH = this;
		return cFBAIONKKFH;
	}

	public void IBIPIALGDHH(Card CEKHIJECPNP)
	{
		if (CEKHIJECPNP == null)
		{
			UnityEngine.Debug.LogError("clipSize");
			FMOFBIBPANE.SetActive(value: true);
		}
		else
		{
			PJOFHIKENOI.Initialize(CEKHIJECPNP, CardRecord.MKIOKBMLHEO.Deposit);
		}
	}

	private void GPLMLKDCPKG(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
		}
		GuiElementSingle<InappScreen>.instance.GNNKBAAGCCL();
	}

	private void CNJDEBLIMDA()
	{
		if (NAKHBAEKPJD != null)
		{
			NAKHBAEKPJD.Cancel();
			NAKHBAEKPJD = null;
		}
	}

	public void JKIMMLIGLAF(IHFDGLMHHBE FJLBLLLEELD, long BEEJNEDIJJN, bool DLALMKLEIMK)
	{
		MMLIIEIJOJD = FJLBLLLEELD;
		DFNCGKPNBPK = BEEJNEDIJJN;
		CDPNOOGFKOF = DLALMKLEIMK;
		Singleton<GuiManager>.instance.ShowDialog(this, 1160f);
	}

	private void OCHCNHAIAFC(long IEALLELGOBM)
	{
		GMEFCAOAAMH(IEALLELGOBM);
		if (CDPNOOGFKOF)
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-33)).FLOATVALUE;
			NFPLGDHDGDE.text = string.Format("PartsToConvert", MEJMLNDFDBP.GMIPFLIEOHD(num));
			float num2 = 1068f + NFPLGDHDGDE.relativeSize.x * NFPLGDHDGDE.transform.localScale.x;
			APPHIEKINOJ.transform.localScale = APPHIEKINOJ.transform.localScale.ReplaceX(num2);
			FOFFIHIHDJL.text = ((num == 4) ? Localization.Localize("N") : ((num != 4) ? NFPLGDHDGDE.text : Localization.Localize("N")));
			MEJMLNDFDBP.COCBCFKJOJE(FOFFIHIHDJL, 1798f, 1018f, 84);
			float num3 = 548f + AAOJDLOBAJG.relativeSize.x * AAOJDLOBAJG.transform.localScale.x;
			float num4 = num2 + num3;
			DFADEHLLAAM.transform.localPosition = DFADEHLLAAM.transform.localPosition.AddX((0f - num4 + num3) / 78f);
			HJAKKICCMHP.transform.localPosition = HJAKKICCMHP.transform.localPosition.AddX((num4 - num2) / 430f);
		}
	}

	public virtual void NLHKADALMDJ()
	{
		base.DoAfterHide();
		OAKNNNMGEID = new Card[1];
		DFNCGKPNBPK = 0L;
		GHINGDGFNJC = null;
		FGIMNJOOAOB = null;
		NGMELAKOPBK = NGNPIOOAHEH.Bronze;
		CNJDEBLIMDA();
	}

	public void ShowDialog(IHFDGLMHHBE FJLBLLLEELD, long IEALLELGOBM)
	{
		MMLIIEIJOJD = FJLBLLLEELD;
		DFNCGKPNBPK = IEALLELGOBM;
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	public void FGAOCOCPAIF(IHFDGLMHHBE FJLBLLLEELD, PlayerVisual IIOKFKPMPPK, long HNDGIJBHMOD)
	{
		MMLIIEIJOJD = FJLBLLLEELD;
		FGIMNJOOAOB = IIOKFKPMPPK;
		DFNCGKPNBPK = HNDGIJBHMOD;
		Singleton<GuiManager>.instance.ShowDialog(this, 632f);
	}

	public virtual void PHNKOMPPPLD()
	{
		bool flag = MMLIIEIJOJD == IHFDGLMHHBE.CardPack && CDPNOOGFKOF;
		PBBLBPFAFKP.SetActive(!flag);
		KIOAFJHDBBJ.SetActive(value: false);
		BIIJGABDHAB.SetActive(flag);
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceY(492f);
		DFADEHLLAAM.transform.localPosition = DFADEHLLAAM.transform.localPosition.ReplaceX(1409f);
		Color color = ((MMLIIEIJOJD != (IHFDGLMHHBE)(-7) && MMLIIEIJOJD != (IHFDGLMHHBE)(-64) && MMLIIEIJOJD != (IHFDGLMHHBE)(-7)) ? Colours.blue : Colours.greenArena);
		PEJFFMLEHFA.color = color;
		OKMNFHNBMFA.text = Localization.Localize((MMLIIEIJOJD != IHFDGLMHHBE.DailyGold) ? "ID_INVITATIONNOTACCEPTED" : ((!CDPNOOGFKOF) ? "getChurnProbability" : "ID_CONFIRM_RESTORE"));
		DAANKCOLJGJ.gameObject.SetActive(MMLIIEIJOJD == IHFDGLMHHBE.Gold || MMLIIEIJOJD == IHFDGLMHHBE.DailyGold || MMLIIEIJOJD == IHFDGLMHHBE.Lootboxes || MMLIIEIJOJD == IHFDGLMHHBE.CardPack || MMLIIEIJOJD == (IHFDGLMHHBE)(-33) || MMLIIEIJOJD == (IHFDGLMHHBE)(-91));
		DFADEHLLAAM.SetActive(MMLIIEIJOJD != IHFDGLMHHBE.Gold && MMLIIEIJOJD != IHFDGLMHHBE.Lootboxes && MMLIIEIJOJD != IHFDGLMHHBE.Warbucks && MMLIIEIJOJD != IHFDGLMHHBE.Warbucks && MMLIIEIJOJD != IHFDGLMHHBE.VIP && MMLIIEIJOJD != (IHFDGLMHHBE)15 && MMLIIEIJOJD == (IHFDGLMHHBE)(-123));
		HJLGGGCCGKO.gameObject.SetActive(MMLIIEIJOJD == IHFDGLMHHBE.Gold);
		FMOFBIBPANE.SetActive(MMLIIEIJOJD == IHFDGLMHHBE.DailyGold);
		FOKNEJJNKMG.gameObject.SetActive(MMLIIEIJOJD == IHFDGLMHHBE.WarCard);
		HLOEAHMFPMG.SetActive(MMLIIEIJOJD == IHFDGLMHHBE.Dogtag);
		FOMAGOFBEDA.SetActive(MMLIIEIJOJD == (IHFDGLMHHBE)(-126));
		HJAKKICCMHP.SetActive(MMLIIEIJOJD != IHFDGLMHHBE.Lootboxes || CDPNOOGFKOF);
		GKBPGIDDBGH.SetActive(MMLIIEIJOJD != IHFDGLMHHBE.DailyGold || CDPNOOGFKOF);
		IDPLLLAHIHN.SetActive(MMLIIEIJOJD == IHFDGLMHHBE.Lootboxes);
		MBKCPLIJMEN.SetActive(MMLIIEIJOJD == IHFDGLMHHBE.Warbucks);
		if (MMLIIEIJOJD == IHFDGLMHHBE.Gold || MMLIIEIJOJD == IHFDGLMHHBE.Warbucks || MMLIIEIJOJD == (IHFDGLMHHBE)109)
		{
			GMEFCAOAAMH(DFNCGKPNBPK);
		}
		if (MMLIIEIJOJD == IHFDGLMHHBE.VIP)
		{
			OCHCNHAIAFC(DFNCGKPNBPK);
		}
		else if (MMLIIEIJOJD == IHFDGLMHHBE.CardPack || MMLIIEIJOJD == IHFDGLMHHBE.PowerBand)
		{
			BDIKHLPLNAN(DFNCGKPNBPK);
		}
		else if (MMLIIEIJOJD == (IHFDGLMHHBE)15)
		{
			PGCEHMLFAMK(Localization.LocalizeFormat("ID_WARNING_NOTENOUGHTWARCARDS", MEJMLNDFDBP.PGJPABFJDGG(DFNCGKPNBPK)));
		}
		switch (MMLIIEIJOJD)
		{
		case IHFDGLMHHBE.Gold:
		case IHFDGLMHHBE.DailyGold:
			MHMOPNBFOPH("CreateGcAccount with ", 810f, Quaternion.Euler(711f, 1036f, 383f));
			break;
		case IHFDGLMHHBE.Dogtag:
			FJDEILFCFMB();
			DOPKMLMFJHK();
			break;
		case IHFDGLMHHBE.WarCard:
			IBIPIALGDHH(GHINGDGFNJC);
			break;
		case IHFDGLMHHBE.Warbucks:
			MHMOPNBFOPH("menu-twitter", 969f, Quaternion.Euler(818f, 1552f, 1100f));
			break;
		case IHFDGLMHHBE.VIP:
			MHMOPNBFOPH("Start overtime", 965f, Quaternion.Euler(541f, 277f, 64f));
			break;
		case IHFDGLMHHBE.PowerBand:
			MOANLDHBHNO(FGIMNJOOAOB);
			break;
		case IHFDGLMHHBE.CardPack:
			OICEIJPEICD(NGMELAKOPBK);
			break;
		case IHFDGLMHHBE.Tickets:
			LMGHDPDLHGD("ID_TUTORIAL_OVERTIME", 1093f, Quaternion.Euler(704f, 1921f, 987f));
			break;
		case IHFDGLMHHBE.Scraps:
			MHMOPNBFOPH("allocMem", 1330f, Quaternion.Euler(593f, 1149f, 1941f));
			break;
		case IHFDGLMHHBE.EliteParts:
			PFIAPBKEBJM(IFFDIHCPKFE, DFNCGKPNBPK);
			break;
		}
		DJDABJKPKOF.OCPDMPCHFBH();
	}

	private void BDFPODAGJEC(long IEALLELGOBM)
	{
		AAOJDLOBAJG.text = MEJMLNDFDBP.PGJPABFJDGG(IEALLELGOBM);
		float val = 1862f + AAOJDLOBAJG.relativeSize.x * AAOJDLOBAJG.transform.localScale.x;
		PAGPPMOEFLG.transform.localScale = PAGPPMOEFLG.transform.localScale.ReplaceX(val);
	}

	public GuiElement IDDIJEBGLDL()
	{
		return this;
	}

	public override void InitGUIValues()
	{
		bool flag = MMLIIEIJOJD == IHFDGLMHHBE.DailyGold && CDPNOOGFKOF;
		PBBLBPFAFKP.SetActive(!flag);
		KIOAFJHDBBJ.SetActive(value: false);
		BIIJGABDHAB.SetActive(flag);
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceY(862f);
		DFADEHLLAAM.transform.localPosition = DFADEHLLAAM.transform.localPosition.ReplaceX(0f);
		Color color = ((MMLIIEIJOJD != IHFDGLMHHBE.Tickets && MMLIIEIJOJD != IHFDGLMHHBE.Scraps && MMLIIEIJOJD != IHFDGLMHHBE.EliteParts) ? Colours.blue : Colours.greenArena);
		PEJFFMLEHFA.color = color;
		OKMNFHNBMFA.text = Localization.Localize((MMLIIEIJOJD != IHFDGLMHHBE.DailyGold) ? "ID_YOURREWARD" : ((!CDPNOOGFKOF) ? "ID_DAILYGOLDBOOSTER" : "ID_FINALDAILYGOLDBOOSTER"));
		DAANKCOLJGJ.gameObject.SetActive(MMLIIEIJOJD == IHFDGLMHHBE.Gold || MMLIIEIJOJD == IHFDGLMHHBE.Warbucks || MMLIIEIJOJD == IHFDGLMHHBE.VIP || MMLIIEIJOJD == IHFDGLMHHBE.DailyGold || MMLIIEIJOJD == IHFDGLMHHBE.Tickets || MMLIIEIJOJD == IHFDGLMHHBE.Scraps);
		DFADEHLLAAM.SetActive(MMLIIEIJOJD == IHFDGLMHHBE.Gold || MMLIIEIJOJD == IHFDGLMHHBE.Warbucks || MMLIIEIJOJD == IHFDGLMHHBE.VIP || MMLIIEIJOJD == IHFDGLMHHBE.PowerBand || MMLIIEIJOJD == IHFDGLMHHBE.DailyGold || MMLIIEIJOJD == IHFDGLMHHBE.Tickets || MMLIIEIJOJD == IHFDGLMHHBE.Scraps);
		HJLGGGCCGKO.gameObject.SetActive(MMLIIEIJOJD == IHFDGLMHHBE.Dogtag);
		FMOFBIBPANE.SetActive(MMLIIEIJOJD == IHFDGLMHHBE.WarCard);
		FOKNEJJNKMG.gameObject.SetActive(MMLIIEIJOJD == IHFDGLMHHBE.CardPack);
		HLOEAHMFPMG.SetActive(MMLIIEIJOJD == IHFDGLMHHBE.PowerBand);
		FOMAGOFBEDA.SetActive(MMLIIEIJOJD == IHFDGLMHHBE.EliteParts);
		HJAKKICCMHP.SetActive(MMLIIEIJOJD == IHFDGLMHHBE.DailyGold && CDPNOOGFKOF);
		GKBPGIDDBGH.SetActive(MMLIIEIJOJD == IHFDGLMHHBE.DailyGold && CDPNOOGFKOF);
		IDPLLLAHIHN.SetActive(MMLIIEIJOJD != IHFDGLMHHBE.DailyGold);
		MBKCPLIJMEN.SetActive(MMLIIEIJOJD == IHFDGLMHHBE.DailyGold);
		if (MMLIIEIJOJD == IHFDGLMHHBE.Gold || MMLIIEIJOJD == IHFDGLMHHBE.Warbucks || MMLIIEIJOJD == IHFDGLMHHBE.Scraps)
		{
			CPDKMLGDEGF(DFNCGKPNBPK);
		}
		if (MMLIIEIJOJD == IHFDGLMHHBE.DailyGold)
		{
			LHJGNEPNCHE(DFNCGKPNBPK);
		}
		else if (MMLIIEIJOJD == IHFDGLMHHBE.VIP || MMLIIEIJOJD == IHFDGLMHHBE.PowerBand)
		{
			BDIKHLPLNAN(DFNCGKPNBPK);
		}
		else if (MMLIIEIJOJD == IHFDGLMHHBE.Tickets)
		{
			BKAHECKCOBH(Localization.LocalizeFormat("ID_XARENATICKETS", MEJMLNDFDBP.PGJPABFJDGG(DFNCGKPNBPK)));
		}
		switch (MMLIIEIJOJD)
		{
		case IHFDGLMHHBE.Gold:
		case IHFDGLMHHBE.DailyGold:
			MHMOPNBFOPH("menu-gold", 1.5f, Quaternion.Euler(0f, 180f, 0f));
			break;
		case IHFDGLMHHBE.Dogtag:
			KGIBLIPGJDH();
			StartCheck();
			break;
		case IHFDGLMHHBE.WarCard:
			SetCard(GHINGDGFNJC);
			break;
		case IHFDGLMHHBE.Warbucks:
			MHMOPNBFOPH("menu-warbucks", 1.5f, Quaternion.Euler(0f, 0f, 0f));
			break;
		case IHFDGLMHHBE.VIP:
			MHMOPNBFOPH("menu-hub-multiplayer-vipico", 2f, Quaternion.Euler(0f, 0f, 0f));
			break;
		case IHFDGLMHHBE.PowerBand:
			MOANLDHBHNO(FGIMNJOOAOB);
			break;
		case IHFDGLMHHBE.CardPack:
			KDEMFAGALFG(NGMELAKOPBK);
			break;
		case IHFDGLMHHBE.Tickets:
			MHMOPNBFOPH("menu-arena-ticket", 2.5f, Quaternion.Euler(0f, 0f, 0f));
			break;
		case IHFDGLMHHBE.Scraps:
			MHMOPNBFOPH("menu-arena-scrap-ico", 3f, Quaternion.Euler(0f, 0f, 0f));
			break;
		case IHFDGLMHHBE.EliteParts:
			PFIAPBKEBJM(IFFDIHCPKFE, DFNCGKPNBPK);
			break;
		}
		DJDABJKPKOF.ResetDraw();
	}

	private void JHECLPMPLNF(PlayerVisual IIOKFKPMPPK)
	{
		JAJCFNOIBPM.spriteName = IIOKFKPMPPK.icon;
		JAJCFNOIBPM.MakePixelPerfect();
		JAJCFNOIBPM.transform.localScale = JAJCFNOIBPM.transform.localScale.MultiplyXY(1588f);
		GPPJEHFBCCE.spriteName = IIOKFKPMPPK.LIIOLLAAHGB();
		GPPJEHFBCCE.color = IIOKFKPMPPK.GPDIGNGOAEH();
		JBCBEOCNJBH.text = IIOKFKPMPPK.decalValueString;
		EPKDEDPGOLM.text = IIOKFKPMPPK.decalShortName;
	}

	public void KFKNFJCGMFD(IHFDGLMHHBE FJLBLLLEELD, long BEEJNEDIJJN, bool DLALMKLEIMK)
	{
		MMLIIEIJOJD = FJLBLLLEELD;
		DFNCGKPNBPK = BEEJNEDIJJN;
		CDPNOOGFKOF = DLALMKLEIMK;
		Singleton<GuiManager>.instance.ShowDialog(this, 1204f);
	}

	public void AHDPEFICJAP(Card CEKHIJECPNP)
	{
		if (CEKHIJECPNP == null)
		{
			UnityEngine.Debug.LogError("SIGN_IN_REQUIRED");
			FMOFBIBPANE.SetActive(value: true);
		}
		else
		{
			PJOFHIKENOI.IGPOLIPPGBP(CEKHIJECPNP, CardRecord.MKIOKBMLHEO.MyWarcards, IDOKGAOAGAL: false);
		}
	}

	private void GAOILNILCFA(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			Singleton<EventTrackingManager>.instance.ICDALIJKFMH(MHNMOFPPKBN.None);
			HideDialog();
		}
	}

	private void PFIAPBKEBJM(LevelBehaviour IOIKKIIFOCB, long IEALLELGOBM)
	{
		MJGJPPLCKLE.text = IOIKKIIFOCB.unitElitePartsName.ToUpper();
		MEJMLNDFDBP.COCBCFKJOJE(MJGJPPLCKLE, 47f, 20f, 1100);
		LDPKLFCGAAI.spriteName = IOIKKIIFOCB.upgradeSlots.iconNameElite;
		LDPKLFCGAAI.MakePixelPerfect();
		LDPKLFCGAAI.pivot = ((!IOIKKIIFOCB.isSoldier) ? UIWidget.Pivot.Center : UIWidget.Pivot.Bottom);
		LDPKLFCGAAI.transform.localPosition = LDPKLFCGAAI.transform.localPosition.ReplaceY((!IOIKKIIFOCB.isSoldier) ? 0f : (-64f));
		float multiplier = Mathf.Min(128f / LDPKLFCGAAI.transform.localScale.x, 120f / LDPKLFCGAAI.transform.localScale.y, 1f);
		LDPKLFCGAAI.transform.localScale = LDPKLFCGAAI.transform.localScale.MultiplyXY(multiplier);
		MPCKHNIBGAF.text = MEJMLNDFDBP.BEDJNPHFAOC((int)IEALLELGOBM);
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
	}

	private void GCKCIOCGBAD(long IEALLELGOBM)
	{
		AAOJDLOBAJG.text = MEJMLNDFDBP.PGJPABFJDGG(IEALLELGOBM);
		float val = 993f + AAOJDLOBAJG.relativeSize.x * AAOJDLOBAJG.transform.localScale.x;
		PAGPPMOEFLG.transform.localScale = PAGPPMOEFLG.transform.localScale.ReplaceX(val);
	}

	public override void OnBack()
	{
		if (IDPLLLAHIHN.activeSelf)
		{
			GKOHJGFKPAH(IDPLLLAHIHN);
		}
		else if (MBKCPLIJMEN.activeSelf)
		{
			GKOHJGFKPAH(MBKCPLIJMEN);
		}
		else if (GJGLGILGDGO.activeSelf)
		{
			GKOHJGFKPAH(GJGLGILGDGO);
		}
	}

	public virtual void KFLMMJFLBEA()
	{
		base.BJIPCOPNEAM();
		if (OAKNNNMGEID != null && OAKNNNMGEID.Length > 0)
		{
			DJDABJKPKOF.BKLMJCEPNMK(OAKNNNMGEID, 827f, DNEMOLAGBHH: false);
		}
	}

	public virtual void JCOILGHDPHA()
	{
		base.OIMKKAHOEKO();
		OAKNNNMGEID = new Card[0];
		DFNCGKPNBPK = 0L;
		GHINGDGFNJC = null;
		FGIMNJOOAOB = null;
		NGMELAKOPBK = NGNPIOOAHEH.None;
		HALPCEPFIHG();
	}

	public void SetCard(Card CEKHIJECPNP)
	{
		if (CEKHIJECPNP == null)
		{
			UnityEngine.Debug.LogError("null card in reward dialog");
			FMOFBIBPANE.SetActive(value: false);
		}
		else
		{
			PJOFHIKENOI.Initialize(CEKHIJECPNP);
		}
	}

	private void AHBOKOHDOIJ(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
		GuiElementSingle<InappScreen>.instance.POAAAJJHHIK();
	}

	public void IJKKOFGPIOE(Card CEKHIJECPNP)
	{
		if (CEKHIJECPNP == null)
		{
			UnityEngine.Debug.LogError("Has Gc Name!");
			FMOFBIBPANE.SetActive(value: false);
		}
		else
		{
			PJOFHIKENOI.IGPOLIPPGBP(CEKHIJECPNP, CardRecord.MKIOKBMLHEO.Deposit, IDOKGAOAGAL: false);
		}
	}

	public void EMBNLMGLNFN(IHFDGLMHHBE FJLBLLLEELD, JToken CEKHIJECPNP)
	{
		MMLIIEIJOJD = FJLBLLLEELD;
		GHINGDGFNJC = ((CEKHIJECPNP != null) ? CardManager.instance.GetCardInstance(CEKHIJECPNP.ToString(), isCurrentPlayer: false) : null);
		Singleton<GuiManager>.instance.ShowDialog(this, 812f);
	}

	public virtual void IMPJPMIDCBB()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
	}

	private void OICEIJPEICD(NGNPIOOAHEH FJLBLLLEELD)
	{
		FOKNEJJNKMG.spriteName = GameVariables.DGIMAKIAGNJ[FJLBLLLEELD].Value2;
		FOKNEJJNKMG.MakePixelPerfect();
		FOKNEJJNKMG.transform.localScale = FOKNEJJNKMG.transform.localScale.MultiplyXY(1264f);
	}

	private void KDEMFAGALFG(NGNPIOOAHEH FJLBLLLEELD)
	{
		FOKNEJJNKMG.spriteName = GameVariables.DGIMAKIAGNJ[FJLBLLLEELD].Value2;
		FOKNEJJNKMG.MakePixelPerfect();
		FOKNEJJNKMG.transform.localScale = FOKNEJJNKMG.transform.localScale.MultiplyXY(0.9f);
	}

	public GuiElement HICAOJMPENK()
	{
		return this;
	}

	private void DCCFHIMFMNN()
	{
		if (NAKHBAEKPJD != null)
		{
			NAKHBAEKPJD.Cancel();
			NAKHBAEKPJD = null;
		}
	}
}
