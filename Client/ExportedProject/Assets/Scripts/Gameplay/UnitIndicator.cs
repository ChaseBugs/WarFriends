using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class UnitIndicator : PoolableObject
{
	private sealed class AFEJOHDDHIB : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal bool ICOIAJEDDAJ;

		internal UnitIndicator BJGCPDNMHDH;

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

		[DebuggerHidden]
		public AFEJOHDDHIB()
		{
		}

		[SpecialName]
		private object GLKCJHHLOCE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BMAMEPNHHFI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HOCLBPGAEMP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HFKDIPEKENH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GKJIGGAAHBE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JDKFIHJHNJC()
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
				ICOIAJEDDAJ = BJGCPDNMHDH.CCGEDOPLEEF(BJGCPDNMHDH.OBKKJGBIHFN.transform.position);
				if (ICOIAJEDDAJ && !BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.GEKIMGFKNHC();
				}
				if (!ICOIAJEDDAJ && BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.BILIFMOOBOM();
				}
				if (!BJGCPDNMHDH.OBKKJGBIHFN.isAlive || !BJGCPDNMHDH.OBKKJGBIHFN.isInstantiated)
				{
					BJGCPDNMHDH.FBPPJKLCCMB();
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

		public void MIFJOIIKFEB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void FDCPBGNCKHH()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BIGMAMMHKFP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ALJCBJBHLMK()
		{
			return PHDOCKCBJOF;
		}

		public bool KCEAGNMILMA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				ICOIAJEDDAJ = BJGCPDNMHDH.CCGEDOPLEEF(BJGCPDNMHDH.OBKKJGBIHFN.transform.position);
				if (ICOIAJEDDAJ && !BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.GEKIMGFKNHC();
				}
				if (!ICOIAJEDDAJ && BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.BILIFMOOBOM();
				}
				if (!BJGCPDNMHDH.OBKKJGBIHFN.isAlive || !BJGCPDNMHDH.OBKKJGBIHFN.JHJJKEBNGEN())
				{
					BJGCPDNMHDH.FBPPJKLCCMB();
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			default:
				return true;
			}
		}

		public void LGCKODOHHIA()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KBOFICGMHNF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FPFOODLPEBK()
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
				ICOIAJEDDAJ = BJGCPDNMHDH.CCGEDOPLEEF(BJGCPDNMHDH.OBKKJGBIHFN.transform.position);
				if (ICOIAJEDDAJ && !BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.GEKIMGFKNHC();
				}
				if (!ICOIAJEDDAJ && BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.BNMBJJLAMIE();
				}
				if (!BJGCPDNMHDH.OBKKJGBIHFN.isAlive || !BJGCPDNMHDH.OBKKJGBIHFN.JHJJKEBNGEN())
				{
					BJGCPDNMHDH.FBPPJKLCCMB();
				}
				PHDOCKCBJOF = null;
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
		private object LMJBCDNGAHP()
		{
			return PHDOCKCBJOF;
		}

		public void BOFEBMENOFC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool JIIOHNFHPOI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				ICOIAJEDDAJ = BJGCPDNMHDH.CCGEDOPLEEF(BJGCPDNMHDH.OBKKJGBIHFN.transform.position);
				if (ICOIAJEDDAJ && !BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.GEKIMGFKNHC();
				}
				if (!ICOIAJEDDAJ && BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.BILIFMOOBOM();
				}
				if (!BJGCPDNMHDH.OBKKJGBIHFN.isAlive || !BJGCPDNMHDH.OBKKJGBIHFN.PPHLEDLNGIN())
				{
					BJGCPDNMHDH.FBPPJKLCCMB();
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

		public bool FPMHODJKAKK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				ICOIAJEDDAJ = BJGCPDNMHDH.DCPMGAGKABE(BJGCPDNMHDH.OBKKJGBIHFN.transform.position);
				if (ICOIAJEDDAJ && !BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.GEKIMGFKNHC();
				}
				if (!ICOIAJEDDAJ && BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.BILIFMOOBOM();
				}
				if (!BJGCPDNMHDH.OBKKJGBIHFN.isAlive || !BJGCPDNMHDH.OBKKJGBIHFN.JHJJKEBNGEN())
				{
					BJGCPDNMHDH.FBPPJKLCCMB();
				}
				PHDOCKCBJOF = null;
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
		private object MNAKOOGPNOH()
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
			case 1u:
				ICOIAJEDDAJ = BJGCPDNMHDH.DCPMGAGKABE(BJGCPDNMHDH.OBKKJGBIHFN.transform.position);
				if (ICOIAJEDDAJ && !BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.GEKIMGFKNHC();
				}
				if (!ICOIAJEDDAJ && BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.BNMBJJLAMIE();
				}
				if (!BJGCPDNMHDH.OBKKJGBIHFN.isAlive || !BJGCPDNMHDH.OBKKJGBIHFN.PLPBGNOCCPI())
				{
					BJGCPDNMHDH.FBPPJKLCCMB();
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

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KLAPICIGNJB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IAMNDODCIEB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AGANCOFPDCK()
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
				ICOIAJEDDAJ = BJGCPDNMHDH.DCPMGAGKABE(BJGCPDNMHDH.OBKKJGBIHFN.transform.position);
				if (ICOIAJEDDAJ && !BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.GEKIMGFKNHC();
				}
				if (!ICOIAJEDDAJ && BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.BNMBJJLAMIE();
				}
				if (!BJGCPDNMHDH.OBKKJGBIHFN.isAlive || !BJGCPDNMHDH.OBKKJGBIHFN.isInstantiated)
				{
					BJGCPDNMHDH.FBPPJKLCCMB();
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

		[SpecialName]
		private object HHHLDCLIFKJ()
		{
			return PHDOCKCBJOF;
		}

		public bool NIGJJBALHDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				ICOIAJEDDAJ = BJGCPDNMHDH.CCGEDOPLEEF(BJGCPDNMHDH.OBKKJGBIHFN.transform.position);
				if (ICOIAJEDDAJ && !BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.GEKIMGFKNHC();
				}
				if (!ICOIAJEDDAJ && BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.BILIFMOOBOM();
				}
				if (!BJGCPDNMHDH.OBKKJGBIHFN.isAlive || !BJGCPDNMHDH.OBKKJGBIHFN.isInstantiated)
				{
					BJGCPDNMHDH.FBPPJKLCCMB();
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

		[SpecialName]
		private object PGOIHDIKFEI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NFJJHCBCIEM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BPKCMCDJOBF()
		{
			return PHDOCKCBJOF;
		}

		public void IDCJDJMGKFG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GIEPJLBHHEO()
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
			case 1u:
				ICOIAJEDDAJ = BJGCPDNMHDH.CCGEDOPLEEF(BJGCPDNMHDH.OBKKJGBIHFN.transform.position);
				if (ICOIAJEDDAJ && !BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.GEKIMGFKNHC();
				}
				if (!ICOIAJEDDAJ && BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.BILIFMOOBOM();
				}
				if (!BJGCPDNMHDH.OBKKJGBIHFN.isAlive || !BJGCPDNMHDH.OBKKJGBIHFN.PPHLEDLNGIN())
				{
					BJGCPDNMHDH.FBPPJKLCCMB();
				}
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

		public bool HBJOFNCAAGI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				ICOIAJEDDAJ = BJGCPDNMHDH.DCPMGAGKABE(BJGCPDNMHDH.OBKKJGBIHFN.transform.position);
				if (ICOIAJEDDAJ && !BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.GEKIMGFKNHC();
				}
				if (!ICOIAJEDDAJ && BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.BILIFMOOBOM();
				}
				if (!BJGCPDNMHDH.OBKKJGBIHFN.isAlive || !BJGCPDNMHDH.OBKKJGBIHFN.PPHLEDLNGIN())
				{
					BJGCPDNMHDH.FBPPJKLCCMB();
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

		public void KCHOLCGBMBJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JFEPOFBDLMB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KJGPLKJAIMC()
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
			case 1u:
				ICOIAJEDDAJ = BJGCPDNMHDH.DCPMGAGKABE(BJGCPDNMHDH.OBKKJGBIHFN.transform.position);
				if (ICOIAJEDDAJ && !BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.GEKIMGFKNHC();
				}
				if (!ICOIAJEDDAJ && BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.BNMBJJLAMIE();
				}
				if (!BJGCPDNMHDH.OBKKJGBIHFN.isAlive || !BJGCPDNMHDH.OBKKJGBIHFN.PPHLEDLNGIN())
				{
					BJGCPDNMHDH.FBPPJKLCCMB();
				}
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
		private object DFHCLJNONGC()
		{
			return PHDOCKCBJOF;
		}

		public void BGMDCMOCLBN()
		{
			throw new NotSupportedException();
		}

		public void HCHFFFPDMDA()
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
			case 1u:
				ICOIAJEDDAJ = BJGCPDNMHDH.CCGEDOPLEEF(BJGCPDNMHDH.OBKKJGBIHFN.transform.position);
				if (ICOIAJEDDAJ && !BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.GEKIMGFKNHC();
				}
				if (!ICOIAJEDDAJ && BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.BILIFMOOBOM();
				}
				if (!BJGCPDNMHDH.OBKKJGBIHFN.isAlive || !BJGCPDNMHDH.OBKKJGBIHFN.JHJJKEBNGEN())
				{
					BJGCPDNMHDH.FBPPJKLCCMB();
				}
				PHDOCKCBJOF = null;
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
		private object KLEHMEIAJHO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CGNOIKAGEMC()
		{
			return PHDOCKCBJOF;
		}

		public void ODACICLOMHJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GOAJCEAOPLA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FFNFEAHBBLJ()
		{
			return PHDOCKCBJOF;
		}

		public void ADLICCCIEGG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void IGNIJGAPJOP()
		{
			throw new NotSupportedException();
		}

		public void CDDFJOEEFID()
		{
			throw new NotSupportedException();
		}

		public void LPKDPNHBLGJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool GMBFJOBKMMN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				ICOIAJEDDAJ = BJGCPDNMHDH.DCPMGAGKABE(BJGCPDNMHDH.OBKKJGBIHFN.transform.position);
				if (ICOIAJEDDAJ && !BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.GEKIMGFKNHC();
				}
				if (!ICOIAJEDDAJ && BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.BILIFMOOBOM();
				}
				if (!BJGCPDNMHDH.OBKKJGBIHFN.isAlive || !BJGCPDNMHDH.OBKKJGBIHFN.JHJJKEBNGEN())
				{
					BJGCPDNMHDH.FBPPJKLCCMB();
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

		public void CHFJIODFNIP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool LAICPPPPIKL()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				ICOIAJEDDAJ = BJGCPDNMHDH.DCPMGAGKABE(BJGCPDNMHDH.OBKKJGBIHFN.transform.position);
				if (ICOIAJEDDAJ && !BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.GEKIMGFKNHC();
				}
				if (!ICOIAJEDDAJ && BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.BILIFMOOBOM();
				}
				if (!BJGCPDNMHDH.OBKKJGBIHFN.isAlive || !BJGCPDNMHDH.OBKKJGBIHFN.PPHLEDLNGIN())
				{
					BJGCPDNMHDH.FBPPJKLCCMB();
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

		[SpecialName]
		private object LAENBDAPNJL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KPNBIPDNGOM()
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
			case 1u:
				ICOIAJEDDAJ = BJGCPDNMHDH.CCGEDOPLEEF(BJGCPDNMHDH.OBKKJGBIHFN.transform.position);
				if (ICOIAJEDDAJ && !BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.GEKIMGFKNHC();
				}
				if (!ICOIAJEDDAJ && BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.BNMBJJLAMIE();
				}
				if (!BJGCPDNMHDH.OBKKJGBIHFN.isAlive || !BJGCPDNMHDH.OBKKJGBIHFN.PPHLEDLNGIN())
				{
					BJGCPDNMHDH.FBPPJKLCCMB();
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

		public void OAFPDIHGJDC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void MKACBCOLNKD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object PLHNILIJAPA()
		{
			return PHDOCKCBJOF;
		}

		public void ODPKEEIHOPK()
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
		private object DNNAMCFLCGE()
		{
			return PHDOCKCBJOF;
		}

		public void GICFBDJLDKF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void HHCIHDMICFP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void NCOPKHMOMMK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object KMCGJFDPBCB()
		{
			return PHDOCKCBJOF;
		}

		public void IKGBMDKKAPA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HBKJOBOMGKB()
		{
			return PHDOCKCBJOF;
		}

		public bool FCPJPIDEPOF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				ICOIAJEDDAJ = BJGCPDNMHDH.DCPMGAGKABE(BJGCPDNMHDH.OBKKJGBIHFN.transform.position);
				if (ICOIAJEDDAJ && !BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.GEKIMGFKNHC();
				}
				if (!ICOIAJEDDAJ && BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.BNMBJJLAMIE();
				}
				if (!BJGCPDNMHDH.OBKKJGBIHFN.isAlive || !BJGCPDNMHDH.OBKKJGBIHFN.isInstantiated)
				{
					BJGCPDNMHDH.FBPPJKLCCMB();
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

		public void JMANMKKCDMM()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object DJIJFANFBCP()
		{
			return PHDOCKCBJOF;
		}

		public bool IEDGDDDADFM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				ICOIAJEDDAJ = BJGCPDNMHDH.CCGEDOPLEEF(BJGCPDNMHDH.OBKKJGBIHFN.transform.position);
				if (ICOIAJEDDAJ && !BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.GEKIMGFKNHC();
				}
				if (!ICOIAJEDDAJ && BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.BNMBJJLAMIE();
				}
				if (!BJGCPDNMHDH.OBKKJGBIHFN.isAlive || !BJGCPDNMHDH.OBKKJGBIHFN.PLPBGNOCCPI())
				{
					BJGCPDNMHDH.FBPPJKLCCMB();
				}
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

		public bool JICHKPANPEE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				ICOIAJEDDAJ = BJGCPDNMHDH.DCPMGAGKABE(BJGCPDNMHDH.OBKKJGBIHFN.transform.position);
				if (ICOIAJEDDAJ && !BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.GEKIMGFKNHC();
				}
				if (!ICOIAJEDDAJ && BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.BNMBJJLAMIE();
				}
				if (!BJGCPDNMHDH.OBKKJGBIHFN.isAlive || !BJGCPDNMHDH.OBKKJGBIHFN.PLPBGNOCCPI())
				{
					BJGCPDNMHDH.FBPPJKLCCMB();
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
		private object JMKGAJNOLEM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ADIAKJMNIEB()
		{
			return PHDOCKCBJOF;
		}

		public void EFKBIIPFDOM()
		{
			throw new NotSupportedException();
		}

		public void IGBHHLFACKO()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void DBEMHFEBPFM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void DLPFJEAMNIO()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GEFKCGOOFFP()
		{
			return PHDOCKCBJOF;
		}

		public void OEHJOBELOFF()
		{
			throw new NotSupportedException();
		}

		public void EHMOLOCPIGB()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object ABGFJLAPNNM()
		{
			return PHDOCKCBJOF;
		}

		public void NFLHLMKKJMO()
		{
			throw new NotSupportedException();
		}

		public void EKPOLGNAAOI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object JIIJMDIFMKF()
		{
			return PHDOCKCBJOF;
		}

		public void CKEOKOKAAPB()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object EGJDJENBABP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BCIDICEAAEN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CEFJLKJNAKJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NCKCKPNAHAD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GMEIAAMCBGA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MBGCBKJBCND()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CNGCLCAAHIG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LMBPPPOFIOC()
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
				ICOIAJEDDAJ = BJGCPDNMHDH.CCGEDOPLEEF(BJGCPDNMHDH.OBKKJGBIHFN.transform.position);
				if (ICOIAJEDDAJ && !BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.GEKIMGFKNHC();
				}
				if (!ICOIAJEDDAJ && BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.BILIFMOOBOM();
				}
				if (!BJGCPDNMHDH.OBKKJGBIHFN.isAlive || !BJGCPDNMHDH.OBKKJGBIHFN.PLPBGNOCCPI())
				{
					BJGCPDNMHDH.FBPPJKLCCMB();
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

		[SpecialName]
		private object KOGGPMGMFIN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MBDBIPHLEIA()
		{
			return PHDOCKCBJOF;
		}

		public void FILDGEMDECJ()
		{
			throw new NotSupportedException();
		}

		public bool EJKHEELJJFM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				ICOIAJEDDAJ = BJGCPDNMHDH.CCGEDOPLEEF(BJGCPDNMHDH.OBKKJGBIHFN.transform.position);
				if (ICOIAJEDDAJ && !BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.GEKIMGFKNHC();
				}
				if (!ICOIAJEDDAJ && BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.BILIFMOOBOM();
				}
				if (!BJGCPDNMHDH.OBKKJGBIHFN.isAlive || !BJGCPDNMHDH.OBKKJGBIHFN.PPHLEDLNGIN())
				{
					BJGCPDNMHDH.FBPPJKLCCMB();
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

		public bool EOLNOFMPMHI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				ICOIAJEDDAJ = BJGCPDNMHDH.CCGEDOPLEEF(BJGCPDNMHDH.OBKKJGBIHFN.transform.position);
				if (ICOIAJEDDAJ && !BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.GEKIMGFKNHC();
				}
				if (!ICOIAJEDDAJ && BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.BNMBJJLAMIE();
				}
				if (!BJGCPDNMHDH.OBKKJGBIHFN.isAlive || !BJGCPDNMHDH.OBKKJGBIHFN.isInstantiated)
				{
					BJGCPDNMHDH.FBPPJKLCCMB();
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

		[SpecialName]
		private object MLCINLDHAGM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HHLKEMNNJDA()
		{
			return PHDOCKCBJOF;
		}

		public void HJLCPFDBNKP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool JMCPAKBLPML()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				ICOIAJEDDAJ = BJGCPDNMHDH.CCGEDOPLEEF(BJGCPDNMHDH.OBKKJGBIHFN.transform.position);
				if (ICOIAJEDDAJ && !BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.GEKIMGFKNHC();
				}
				if (!ICOIAJEDDAJ && BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.BILIFMOOBOM();
				}
				if (!BJGCPDNMHDH.OBKKJGBIHFN.isAlive || !BJGCPDNMHDH.OBKKJGBIHFN.JHJJKEBNGEN())
				{
					BJGCPDNMHDH.FBPPJKLCCMB();
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

		public bool KHNDCDGBFJH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				ICOIAJEDDAJ = BJGCPDNMHDH.DCPMGAGKABE(BJGCPDNMHDH.OBKKJGBIHFN.transform.position);
				if (ICOIAJEDDAJ && !BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.GEKIMGFKNHC();
				}
				if (!ICOIAJEDDAJ && BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.BNMBJJLAMIE();
				}
				if (!BJGCPDNMHDH.OBKKJGBIHFN.isAlive || !BJGCPDNMHDH.OBKKJGBIHFN.JHJJKEBNGEN())
				{
					BJGCPDNMHDH.FBPPJKLCCMB();
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

		[SpecialName]
		private object NANCGKHPCAN()
		{
			return PHDOCKCBJOF;
		}

		public void LDKFDMLPIOC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object AHFIDCCJHKE()
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
				ICOIAJEDDAJ = BJGCPDNMHDH.CCGEDOPLEEF(BJGCPDNMHDH.OBKKJGBIHFN.transform.position);
				if (ICOIAJEDDAJ && !BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.GEKIMGFKNHC();
				}
				if (!ICOIAJEDDAJ && BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.BILIFMOOBOM();
				}
				if (!BJGCPDNMHDH.OBKKJGBIHFN.isAlive || !BJGCPDNMHDH.OBKKJGBIHFN.JHJJKEBNGEN())
				{
					BJGCPDNMHDH.FBPPJKLCCMB();
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

		public bool DAKMHLEGICB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				ICOIAJEDDAJ = BJGCPDNMHDH.DCPMGAGKABE(BJGCPDNMHDH.OBKKJGBIHFN.transform.position);
				if (ICOIAJEDDAJ && !BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.GEKIMGFKNHC();
				}
				if (!ICOIAJEDDAJ && BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.BILIFMOOBOM();
				}
				if (!BJGCPDNMHDH.OBKKJGBIHFN.isAlive || !BJGCPDNMHDH.OBKKJGBIHFN.PLPBGNOCCPI())
				{
					BJGCPDNMHDH.FBPPJKLCCMB();
				}
				PHDOCKCBJOF = null;
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
		private object ONLMGMBKGHI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JFHOHPKEFGM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HMIFLGCBDCO()
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
			case 1u:
				ICOIAJEDDAJ = BJGCPDNMHDH.DCPMGAGKABE(BJGCPDNMHDH.OBKKJGBIHFN.transform.position);
				if (ICOIAJEDDAJ && !BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.GEKIMGFKNHC();
				}
				if (!ICOIAJEDDAJ && BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.BNMBJJLAMIE();
				}
				if (!BJGCPDNMHDH.OBKKJGBIHFN.isAlive || !BJGCPDNMHDH.OBKKJGBIHFN.PPHLEDLNGIN())
				{
					BJGCPDNMHDH.FBPPJKLCCMB();
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			default:
				return true;
			}
		}

		public void PHKDHCJBMII()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object FNCEOCMMGKH()
		{
			return PHDOCKCBJOF;
		}

		public void KNFDMCEJHLB()
		{
			throw new NotSupportedException();
		}

		public bool HJHJCCFGJIH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				ICOIAJEDDAJ = BJGCPDNMHDH.CCGEDOPLEEF(BJGCPDNMHDH.OBKKJGBIHFN.transform.position);
				if (ICOIAJEDDAJ && !BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.GEKIMGFKNHC();
				}
				if (!ICOIAJEDDAJ && BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.BILIFMOOBOM();
				}
				if (!BJGCPDNMHDH.OBKKJGBIHFN.isAlive || !BJGCPDNMHDH.OBKKJGBIHFN.isInstantiated)
				{
					BJGCPDNMHDH.FBPPJKLCCMB();
				}
				PHDOCKCBJOF = null;
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
		private object IJONKJIBHGO()
		{
			return PHDOCKCBJOF;
		}

		public bool MHCIOCPGMHF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				ICOIAJEDDAJ = BJGCPDNMHDH.DCPMGAGKABE(BJGCPDNMHDH.OBKKJGBIHFN.transform.position);
				if (ICOIAJEDDAJ && !BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.GEKIMGFKNHC();
				}
				if (!ICOIAJEDDAJ && BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.BNMBJJLAMIE();
				}
				if (!BJGCPDNMHDH.OBKKJGBIHFN.isAlive || !BJGCPDNMHDH.OBKKJGBIHFN.PLPBGNOCCPI())
				{
					BJGCPDNMHDH.FBPPJKLCCMB();
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

		public void LFIGPJBHPBH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool MKCOLOBIAAP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				ICOIAJEDDAJ = BJGCPDNMHDH.DCPMGAGKABE(BJGCPDNMHDH.OBKKJGBIHFN.transform.position);
				if (ICOIAJEDDAJ && !BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.GEKIMGFKNHC();
				}
				if (!ICOIAJEDDAJ && BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.BNMBJJLAMIE();
				}
				if (!BJGCPDNMHDH.OBKKJGBIHFN.isAlive || !BJGCPDNMHDH.OBKKJGBIHFN.PLPBGNOCCPI())
				{
					BJGCPDNMHDH.FBPPJKLCCMB();
				}
				PHDOCKCBJOF = null;
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
		private object PPHNDLFFCAG()
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
			case 1u:
				ICOIAJEDDAJ = BJGCPDNMHDH.CCGEDOPLEEF(BJGCPDNMHDH.OBKKJGBIHFN.transform.position);
				if (ICOIAJEDDAJ && !BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.GEKIMGFKNHC();
				}
				if (!ICOIAJEDDAJ && BJGCPDNMHDH.EABMMNBCABK)
				{
					BJGCPDNMHDH.BNMBJJLAMIE();
				}
				if (!BJGCPDNMHDH.OBKKJGBIHFN.isAlive || !BJGCPDNMHDH.OBKKJGBIHFN.isInstantiated)
				{
					BJGCPDNMHDH.FBPPJKLCCMB();
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			default:
				return true;
			}
		}

		public void NHFMKLGIKPM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}
	}

	[FormerlySerializedAs("GIMMLMFBMEI")]
	public UISprite KMFGCJEGJJK;

	[FormerlySerializedAs("BAFOKBJPNDN")]
	public UISprite OKJNAJJCDBF;

	[FormerlySerializedAs("JENPPJHBNPM")]
	public UISprite OPDJNGGLABF;

	private RadicalRoutine ONHBHFBLDHM;

	private bool MBEGGPKOJEE;

	private EnemyController OBKKJGBIHFN;

	private bool EABMMNBCABK;

	private bool JCKOBELDCGD;

	private float HKFOGNIMLOO;

	private float HBAGHHPMDGK = 0.025f;

	private float NHMJMJIMANP = 0.975f;

	[CompilerGenerated]
	private void ONMPDCPIDIA(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = false;
		EABMMNBCABK = false;
		FBPPJKLCCMB();
	}

	private void HPNHJKCAKKN()
	{
		if (!MBEGGPKOJEE)
		{
			float num = 50f / UIHelper.activeWidthFull;
			float num2 = UIHelper.safeAreaSize / UIHelper.activeWidthFull;
			HBAGHHPMDGK = num + num2;
			NHMJMJIMANP = 1f - (num + num2);
			ONHBHFBLDHM = RadicalRoutine.Create(JHDPJDALCDP());
			StartCoroutine(RadicalRoutine.Run(ONHBHFBLDHM.enumerator));
			MBEGGPKOJEE = true;
		}
	}

	private IEnumerator KDPEIMMOADK()
	{
		AFEJOHDDHIB aFEJOHDDHIB = new AFEJOHDDHIB();
		aFEJOHDDHIB.BJGCPDNMHDH = this;
		return aFEJOHDDHIB;
	}

	public virtual void DNMMADBDOLM()
	{
		base.HPPIBGEJMNL();
		Singleton<GameController>.instance.CNPGMMPAGIE(KPPNCJBMDPE);
		KMFGCJEGJJK.alpha = 160f;
		OKJNAJJCDBF.alpha = 1010f;
		OPDJNGGLABF.alpha = 1861f;
		EABMMNBCABK = true;
		JCKOBELDCGD = true;
	}

	private bool CCGEDOPLEEF(Vector3 GHECLGIFKNF)
	{
		Vector3 point = Camera.main.WorldToNormalizedViewportPoint(GHECLGIFKNF);
		if (point.x == Mathf.Clamp01(point.x) && point.y == Mathf.Clamp01(point.y))
		{
			return false;
		}
		point.x = Mathf.Clamp(point.x, HBAGHHPMDGK, NHMJMJIMANP);
		point.y = Mathf.Clamp(point.y, 0.22f, 0.78f);
		point = Singleton<GuiManager>.instance.KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
		point.z = 0f;
		base.transform.position = point;
		base.transform.localPosition = base.transform.localPosition.ReplaceZ(HKFOGNIMLOO);
		OPDJNGGLABF.transform.localRotation = ((!(point.x < 0.5f)) ? Quaternion.Euler(0f, 180f, 0f) : Quaternion.identity);
		return true;
	}

	private void KPPNCJBMDPE(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		Singleton<GameController>.instance.GameEnded -= KPPNCJBMDPE;
		EABMMNBCABK = false;
		FBPPJKLCCMB();
	}

	private void PHJAIIBGBGH(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = true;
		EABMMNBCABK = true;
		FBPPJKLCCMB();
	}

	private void BILIFMOOBOM()
	{
		if (EABMMNBCABK && !JCKOBELDCGD)
		{
			JCKOBELDCGD = true;
			TweenAlpha.Begin(OKJNAJJCDBF.gameObject, 0.2f, 0f);
			TweenColor tweenColor = TweenColor.Begin(KMFGCJEGJJK.gameObject, 0.2f, Colours.blueTransparent);
			tweenColor.NumOfRepetitions = 1;
			TweenColor tweenColor2 = TweenColor.Begin(OPDJNGGLABF.gameObject, 0.2f, Colours.whiteTransparent);
			tweenColor2.NumOfRepetitions = 1;
			tweenColor2.onFinished = delegate
			{
				JCKOBELDCGD = false;
				EABMMNBCABK = false;
				FBPPJKLCCMB();
			};
		}
	}

	private void PCEDKGPHKPI()
	{
		DestroyPooled();
	}

	public void ACPFCAMFEAJ(string ICKIMPBKKEB, EnemyController GIPEKIBEPEB, float FDNBJFDPGFJ)
	{
		OKJNAJJCDBF.spriteName = ICKIMPBKKEB;
		OKJNAJJCDBF.MakePixelPerfect();
		float multiplier = Mathf.Min(1300f / OKJNAJJCDBF.transform.localScale.x, 492f / OKJNAJJCDBF.transform.localScale.y);
		OKJNAJJCDBF.transform.localScale = OKJNAJJCDBF.transform.localScale.MultiplyXY(multiplier);
		HKFOGNIMLOO = FDNBJFDPGFJ;
		OBKKJGBIHFN = GIPEKIBEPEB;
		MBEGGPKOJEE = false;
		EABMMNBCABK = true;
		JCKOBELDCGD = true;
		HPNHJKCAKKN();
		GEKIMGFKNHC();
	}

	[CompilerGenerated]
	private void BCMKJHNOAFO(UITweener MGDJMGHCAAI)
	{
		EBFKMMHNDJA();
	}

	public void InitAndShow(string ICKIMPBKKEB, EnemyController GIPEKIBEPEB, float FDNBJFDPGFJ)
	{
		OKJNAJJCDBF.spriteName = ICKIMPBKKEB;
		OKJNAJJCDBF.MakePixelPerfect();
		float multiplier = Mathf.Min(98f / OKJNAJJCDBF.transform.localScale.x, 98f / OKJNAJJCDBF.transform.localScale.y);
		OKJNAJJCDBF.transform.localScale = OKJNAJJCDBF.transform.localScale.MultiplyXY(multiplier);
		HKFOGNIMLOO = FDNBJFDPGFJ;
		OBKKJGBIHFN = GIPEKIBEPEB;
		MBEGGPKOJEE = false;
		EABMMNBCABK = false;
		JCKOBELDCGD = false;
		HPNHJKCAKKN();
		GEKIMGFKNHC();
	}

	private void FBPPJKLCCMB()
	{
		CMFDEOFKFBN();
		if (!EABMMNBCABK)
		{
			DestroyPooled();
			return;
		}
		BILIFMOOBOM();
		InvokeAfterRealTime(delegate
		{
			DestroyPooled();
		}, 0.3f);
	}

	private void NMMGJFHKDEI(UITweener MGDJMGHCAAI)
	{
		EBFKMMHNDJA();
	}

	private bool DCPMGAGKABE(Vector3 GHECLGIFKNF)
	{
		Vector3 point = Camera.main.WorldToNormalizedViewportPoint(GHECLGIFKNF);
		if (point.x == Mathf.Clamp01(point.x) && point.y == Mathf.Clamp01(point.y))
		{
			return false;
		}
		point.x = Mathf.Clamp(point.x, HBAGHHPMDGK, NHMJMJIMANP);
		point.y = Mathf.Clamp(point.y, 645f, 138f);
		point = Singleton<GuiManager>.instance.KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
		point.z = 411f;
		base.transform.position = point;
		base.transform.localPosition = base.transform.localPosition.ReplaceZ(HKFOGNIMLOO);
		OPDJNGGLABF.transform.localRotation = ((!(point.x < 909f)) ? Quaternion.Euler(1608f, 1619f, 1558f) : Quaternion.identity);
		return false;
	}

	public override void DestroyPooled()
	{
		Singleton<GameController>.instance.GameEnded -= KPPNCJBMDPE;
		CMFDEOFKFBN();
		base.DestroyPooled();
	}

	private void CMFDEOFKFBN()
	{
		if (MBEGGPKOJEE)
		{
			ONHBHFBLDHM.Cancel();
			MBEGGPKOJEE = false;
		}
	}

	private void BNMBJJLAMIE()
	{
		if (EABMMNBCABK && !JCKOBELDCGD)
		{
			JCKOBELDCGD = true;
			TweenAlpha.Begin(OKJNAJJCDBF.gameObject, 658f, 228f);
			TweenColor tweenColor = TweenColor.Begin(KMFGCJEGJJK.gameObject, 1183f, Colours.blueTransparent);
			tweenColor.NumOfRepetitions = 0;
			TweenColor tweenColor2 = TweenColor.Begin(OPDJNGGLABF.gameObject, 1246f, Colours.whiteTransparent);
			tweenColor2.NumOfRepetitions = 1;
			tweenColor2.onFinished = PHJAIIBGBGH;
		}
	}

	public virtual void IPEAHJBMBGI()
	{
		base.JMAFCGDIICK();
		Singleton<GameController>.instance.GameEnded += FMIOCIGFOPI;
		KMFGCJEGJJK.alpha = 1500f;
		OKJNAJJCDBF.alpha = 344f;
		OPDJNGGLABF.alpha = 1501f;
		EABMMNBCABK = false;
		JCKOBELDCGD = false;
	}

	[CompilerGenerated]
	private void GFJCPGECIBD()
	{
		DestroyPooled();
	}

	private void KIOCANKBCFA()
	{
		if (!MBEGGPKOJEE)
		{
			float num = 460f / UIHelper.activeWidthFull;
			float num2 = UIHelper.safeAreaSize / UIHelper.activeWidthFull;
			HBAGHHPMDGK = num + num2;
			NHMJMJIMANP = 1626f - (num + num2);
			ONHBHFBLDHM = RadicalRoutine.Create(JHDPJDALCDP());
			StartCoroutine(RadicalRoutine.Run(ONHBHFBLDHM.enumerator));
			MBEGGPKOJEE = true;
		}
	}

	[DebuggerHidden]
	private IEnumerator JHDPJDALCDP()
	{
		AFEJOHDDHIB aFEJOHDDHIB = new AFEJOHDDHIB();
		aFEJOHDDHIB.BJGCPDNMHDH = this;
		return aFEJOHDDHIB;
	}

	private void DMMDIGGJDMM(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = false;
		EABMMNBCABK = true;
		FBPPJKLCCMB();
	}

	private void NBBIGMHCEKH()
	{
		if (MBEGGPKOJEE)
		{
			ONHBHFBLDHM.Cancel();
			MBEGGPKOJEE = false;
		}
	}

	private void GEKIMGFKNHC()
	{
		if (!EABMMNBCABK && !JCKOBELDCGD)
		{
			JCKOBELDCGD = true;
			TweenAlpha.Begin(OKJNAJJCDBF.gameObject, 0.2f, 0f, 1f);
			TweenColor tweenColor = TweenColor.Begin(KMFGCJEGJJK.gameObject, 0.2f, Colours.blueTransparent, Colours.blue);
			tweenColor.NumOfRepetitions = 1;
			TweenColor tweenColor2 = TweenColor.Begin(OPDJNGGLABF.gameObject, 0.2f, Colours.whiteTransparent, Color.white);
			tweenColor2.NumOfRepetitions = 1;
			tweenColor2.onFinished = delegate
			{
				EBFKMMHNDJA();
			};
		}
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		Singleton<GameController>.instance.GameEnded += KPPNCJBMDPE;
		KMFGCJEGJJK.alpha = 0f;
		OKJNAJJCDBF.alpha = 0f;
		OPDJNGGLABF.alpha = 0f;
		EABMMNBCABK = false;
		JCKOBELDCGD = false;
	}

	private void EBFKMMHNDJA()
	{
		JCKOBELDCGD = false;
		EABMMNBCABK = true;
	}

	private void FMIOCIGFOPI(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		Singleton<GameController>.instance.MAMBOBJAGOJ(FMIOCIGFOPI);
		EABMMNBCABK = true;
		FBPPJKLCCMB();
	}

	private void HHJCIAMCIGH(UITweener MGDJMGHCAAI)
	{
		EBFKMMHNDJA();
	}
}
