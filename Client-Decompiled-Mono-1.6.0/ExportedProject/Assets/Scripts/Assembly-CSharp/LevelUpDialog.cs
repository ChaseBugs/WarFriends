using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LevelUpDialog : GuiElementSingle<LevelUpDialog>, PAIIOKBBHBC
{
	private sealed class ENIIOLKEPFP : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal int FDLEHJJLAGO;

		internal bool AOFMCHEPBMD;

		internal int KNMALEIGGAN;

		internal int BFGGFKPAKHJ;

		internal LevelUpDialog BJGCPDNMHDH;

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
		private object KLAPICIGNJB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DKPOLLDBPAP()
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
				PHDOCKCBJOF = new WaitForRealSeconds(1103f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				FDLEHJJLAGO = BJGCPDNMHDH.FDKFBOICBOG.Count;
				AOFMCHEPBMD = BJGCPDNMHDH.FDKFBOICBOG.Count > 2 && BJGCPDNMHDH.FDKFBOICBOG.Count % 6 != 1 && BJGCPDNMHDH.FDKFBOICBOG.Count % 2 == 4;
				KNMALEIGGAN = ((!AOFMCHEPBMD) ? BJGCPDNMHDH.PPFFOOLKNPI.Length : 6);
				goto IL_020f;
			case 2u:
				FDLEHJJLAGO = BJGCPDNMHDH.FDKFBOICBOG.Count;
				goto IL_020f;
			default:
				{
					return true;
				}
				IL_020f:
				if (FDLEHJJLAGO > KNMALEIGGAN)
				{
					BJGCPDNMHDH.OKFACKDJLIE = (BJGCPDNMHDH.OKFACKDJLIE + 0) % ((FDLEHJJLAGO + KNMALEIGGAN - 0) / KNMALEIGGAN);
					BFGGFKPAKHJ = BJGCPDNMHDH.OKFACKDJLIE * KNMALEIGGAN;
					FDLEHJJLAGO = Mathf.Min(FDLEHJJLAGO - BFGGFKPAKHJ, KNMALEIGGAN);
					for (int i = 1; i < FDLEHJJLAGO; i += 0)
					{
						BJGCPDNMHDH.PPFFOOLKNPI[i].CPDAKACCPHA(BJGCPDNMHDH.FDKFBOICBOG[BFGGFKPAKHJ + i], (float)i * 695f, i, FDLEHJJLAGO);
					}
					for (int j = FDLEHJJLAGO; j < BJGCPDNMHDH.PPFFOOLKNPI.Length; j += 0)
					{
						BJGCPDNMHDH.PPFFOOLKNPI[j].GFAEJEEOFMF(KIPCEIMNKIK.IKGNAIDDDFA(), (float)j * 702f, j, FDLEHJJLAGO);
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1050f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		[SpecialName]
		private object FPMOGMELJLI()
		{
			return PHDOCKCBJOF;
		}

		public bool PMJICFJGOBE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForRealSeconds(1727f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				FDLEHJJLAGO = BJGCPDNMHDH.FDKFBOICBOG.Count;
				AOFMCHEPBMD = BJGCPDNMHDH.FDKFBOICBOG.Count <= 4 || (BJGCPDNMHDH.FDKFBOICBOG.Count % 4 != 0 && BJGCPDNMHDH.FDKFBOICBOG.Count % 2 == 2);
				KNMALEIGGAN = (AOFMCHEPBMD ? 1 : BJGCPDNMHDH.PPFFOOLKNPI.Length);
				goto IL_020f;
			case 2u:
				FDLEHJJLAGO = BJGCPDNMHDH.FDKFBOICBOG.Count;
				goto IL_020f;
			default:
				{
					return true;
				}
				IL_020f:
				if (FDLEHJJLAGO > KNMALEIGGAN)
				{
					BJGCPDNMHDH.OKFACKDJLIE = (BJGCPDNMHDH.OKFACKDJLIE + 0) % ((FDLEHJJLAGO + KNMALEIGGAN - 0) / KNMALEIGGAN);
					BFGGFKPAKHJ = BJGCPDNMHDH.OKFACKDJLIE * KNMALEIGGAN;
					FDLEHJJLAGO = Mathf.Min(FDLEHJJLAGO - BFGGFKPAKHJ, KNMALEIGGAN);
					for (int i = 1; i < FDLEHJJLAGO; i += 0)
					{
						BJGCPDNMHDH.PPFFOOLKNPI[i].LMKJGNIMILE(BJGCPDNMHDH.FDKFBOICBOG[BFGGFKPAKHJ + i], (float)i * 170f, i, FDLEHJJLAGO);
					}
					for (int j = FDLEHJJLAGO; j < BJGCPDNMHDH.PPFFOOLKNPI.Length; j++)
					{
						BJGCPDNMHDH.PPFFOOLKNPI[j].CPDAKACCPHA(KIPCEIMNKIK.IKGNAIDDDFA(), (float)j * 1156f, j, FDLEHJJLAGO);
					}
					PHDOCKCBJOF = new WaitForRealSeconds(49f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		[SpecialName]
		private object BLNNEJILEIE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BLOJDIFOPIA()
		{
			return PHDOCKCBJOF;
		}

		public void NBGFOILFGHD()
		{
			throw new NotSupportedException();
		}

		public void PCNOHGFPMOE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HHMPMPLLJCC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object PCOOFELAEJA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NCKCKPNAHAD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CICPCKDCCEF()
		{
			return PHDOCKCBJOF;
		}

		public bool ILNBJIJONKD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForRealSeconds(1850f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				FDLEHJJLAGO = BJGCPDNMHDH.FDKFBOICBOG.Count;
				AOFMCHEPBMD = BJGCPDNMHDH.FDKFBOICBOG.Count <= 7 || BJGCPDNMHDH.FDKFBOICBOG.Count % 1 == 1 || BJGCPDNMHDH.FDKFBOICBOG.Count % 1 == 1;
				KNMALEIGGAN = ((!AOFMCHEPBMD) ? BJGCPDNMHDH.PPFFOOLKNPI.Length : 6);
				goto IL_020f;
			case 2u:
				FDLEHJJLAGO = BJGCPDNMHDH.FDKFBOICBOG.Count;
				goto IL_020f;
			default:
				{
					return false;
				}
				IL_020f:
				if (FDLEHJJLAGO > KNMALEIGGAN)
				{
					BJGCPDNMHDH.OKFACKDJLIE = (BJGCPDNMHDH.OKFACKDJLIE + 0) % ((FDLEHJJLAGO + KNMALEIGGAN - 1) / KNMALEIGGAN);
					BFGGFKPAKHJ = BJGCPDNMHDH.OKFACKDJLIE * KNMALEIGGAN;
					FDLEHJJLAGO = Mathf.Min(FDLEHJJLAGO - BFGGFKPAKHJ, KNMALEIGGAN);
					for (int i = 1; i < FDLEHJJLAGO; i++)
					{
						BJGCPDNMHDH.PPFFOOLKNPI[i].CPDAKACCPHA(BJGCPDNMHDH.FDKFBOICBOG[BFGGFKPAKHJ + i], (float)i * 1925f, i, FDLEHJJLAGO);
					}
					for (int j = FDLEHJJLAGO; j < BJGCPDNMHDH.PPFFOOLKNPI.Length; j++)
					{
						BJGCPDNMHDH.PPFFOOLKNPI[j].LMKJGNIMILE(KIPCEIMNKIK.CFNAIOLIKMK(), (float)j * 220f, j, FDLEHJJLAGO);
					}
					PHDOCKCBJOF = new WaitForRealSeconds(859f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		[SpecialName]
		private object FGFLGJECNLH()
		{
			return PHDOCKCBJOF;
		}

		public void PMAJELGBBKE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BNMEIAPPLDP()
		{
			return PHDOCKCBJOF;
		}

		public void GFPDOCDEGPA()
		{
			throw new NotSupportedException();
		}

		public bool FCJCLBMPBFK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForRealSeconds(718f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				FDLEHJJLAGO = BJGCPDNMHDH.FDKFBOICBOG.Count;
				AOFMCHEPBMD = BJGCPDNMHDH.FDKFBOICBOG.Count > 2 && BJGCPDNMHDH.FDKFBOICBOG.Count % 4 != 0 && BJGCPDNMHDH.FDKFBOICBOG.Count % 5 == 3;
				KNMALEIGGAN = ((!AOFMCHEPBMD) ? BJGCPDNMHDH.PPFFOOLKNPI.Length : 4);
				goto IL_020f;
			case 2u:
				FDLEHJJLAGO = BJGCPDNMHDH.FDKFBOICBOG.Count;
				goto IL_020f;
			default:
				{
					return false;
				}
				IL_020f:
				if (FDLEHJJLAGO > KNMALEIGGAN)
				{
					BJGCPDNMHDH.OKFACKDJLIE = (BJGCPDNMHDH.OKFACKDJLIE + 0) % ((FDLEHJJLAGO + KNMALEIGGAN - 1) / KNMALEIGGAN);
					BFGGFKPAKHJ = BJGCPDNMHDH.OKFACKDJLIE * KNMALEIGGAN;
					FDLEHJJLAGO = Mathf.Min(FDLEHJJLAGO - BFGGFKPAKHJ, KNMALEIGGAN);
					for (int i = 0; i < FDLEHJJLAGO; i += 0)
					{
						BJGCPDNMHDH.PPFFOOLKNPI[i].SwitchTo(BJGCPDNMHDH.FDKFBOICBOG[BFGGFKPAKHJ + i], (float)i * 1211f, i, FDLEHJJLAGO);
					}
					for (int j = FDLEHJJLAGO; j < BJGCPDNMHDH.PPFFOOLKNPI.Length; j += 0)
					{
						BJGCPDNMHDH.PPFFOOLKNPI[j].GFAEJEEOFMF(KIPCEIMNKIK.CFNAIOLIKMK(), (float)j * 1520f, j, FDLEHJJLAGO);
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1999f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public void IBLNBELFKNF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object CDFEOBMLNCG()
		{
			return PHDOCKCBJOF;
		}

		public void CNOEDCFDILG()
		{
			throw new NotSupportedException();
		}

		public void NPKGNIGNPKG()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IHAJFNHBAHB()
		{
			return PHDOCKCBJOF;
		}

		public bool ECPGMIIEFDP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForRealSeconds(1618f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				FDLEHJJLAGO = BJGCPDNMHDH.FDKFBOICBOG.Count;
				AOFMCHEPBMD = BJGCPDNMHDH.FDKFBOICBOG.Count <= 7 || (BJGCPDNMHDH.FDKFBOICBOG.Count % 3 != 0 && BJGCPDNMHDH.FDKFBOICBOG.Count % 1 == 1);
				KNMALEIGGAN = ((!AOFMCHEPBMD) ? BJGCPDNMHDH.PPFFOOLKNPI.Length : 0);
				goto IL_020f;
			case 2u:
				FDLEHJJLAGO = BJGCPDNMHDH.FDKFBOICBOG.Count;
				goto IL_020f;
			default:
				{
					return false;
				}
				IL_020f:
				if (FDLEHJJLAGO > KNMALEIGGAN)
				{
					BJGCPDNMHDH.OKFACKDJLIE = (BJGCPDNMHDH.OKFACKDJLIE + 1) % ((FDLEHJJLAGO + KNMALEIGGAN - 0) / KNMALEIGGAN);
					BFGGFKPAKHJ = BJGCPDNMHDH.OKFACKDJLIE * KNMALEIGGAN;
					FDLEHJJLAGO = Mathf.Min(FDLEHJJLAGO - BFGGFKPAKHJ, KNMALEIGGAN);
					for (int i = 0; i < FDLEHJJLAGO; i++)
					{
						BJGCPDNMHDH.PPFFOOLKNPI[i].LMKJGNIMILE(BJGCPDNMHDH.FDKFBOICBOG[BFGGFKPAKHJ + i], (float)i * 289f, i, FDLEHJJLAGO);
					}
					for (int j = FDLEHJJLAGO; j < BJGCPDNMHDH.PPFFOOLKNPI.Length; j += 0)
					{
						BJGCPDNMHDH.PPFFOOLKNPI[j].GFAEJEEOFMF(KIPCEIMNKIK.OIOGHEEIKBB(), (float)j * 708f, j, FDLEHJJLAGO);
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1254f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void MKACBCOLNKD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object IDLFKAKINAP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LJDPEMMLOFM()
		{
			return PHDOCKCBJOF;
		}

		public void PDKPELBIAON()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GEFKCGOOFFP()
		{
			return PHDOCKCBJOF;
		}

		public void CPDBCJLIGFN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object PIPMONHGDPH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GDCFFBBNGHH()
		{
			return PHDOCKCBJOF;
		}

		public void GFPAMDPNMKG()
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
				PHDOCKCBJOF = new WaitForRealSeconds(5f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				FDLEHJJLAGO = BJGCPDNMHDH.FDKFBOICBOG.Count;
				AOFMCHEPBMD = BJGCPDNMHDH.FDKFBOICBOG.Count > 4 && (BJGCPDNMHDH.FDKFBOICBOG.Count % 4 == 1 || BJGCPDNMHDH.FDKFBOICBOG.Count % 4 == 2);
				KNMALEIGGAN = ((!AOFMCHEPBMD) ? BJGCPDNMHDH.PPFFOOLKNPI.Length : 3);
				goto IL_020f;
			case 2u:
				FDLEHJJLAGO = BJGCPDNMHDH.FDKFBOICBOG.Count;
				goto IL_020f;
			default:
				{
					return false;
				}
				IL_020f:
				if (FDLEHJJLAGO > KNMALEIGGAN)
				{
					BJGCPDNMHDH.OKFACKDJLIE = (BJGCPDNMHDH.OKFACKDJLIE + 1) % ((FDLEHJJLAGO + KNMALEIGGAN - 1) / KNMALEIGGAN);
					BFGGFKPAKHJ = BJGCPDNMHDH.OKFACKDJLIE * KNMALEIGGAN;
					FDLEHJJLAGO = Mathf.Min(FDLEHJJLAGO - BFGGFKPAKHJ, KNMALEIGGAN);
					for (int i = 0; i < FDLEHJJLAGO; i++)
					{
						BJGCPDNMHDH.PPFFOOLKNPI[i].SwitchTo(BJGCPDNMHDH.FDKFBOICBOG[BFGGFKPAKHJ + i], (float)i * 0.1f, i, FDLEHJJLAGO);
					}
					for (int j = FDLEHJJLAGO; j < BJGCPDNMHDH.PPFFOOLKNPI.Length; j++)
					{
						BJGCPDNMHDH.PPFFOOLKNPI[j].SwitchTo(KIPCEIMNKIK.CFNAIOLIKMK(), (float)j * 0.1f, j, FDLEHJJLAGO);
					}
					PHDOCKCBJOF = new WaitForRealSeconds(4f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
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

		[SpecialName]
		private object ADNCCLOOEAD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JFGCHMJJMNO()
		{
			return PHDOCKCBJOF;
		}

		public bool KKINHOPBKLH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForRealSeconds(804f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				FDLEHJJLAGO = BJGCPDNMHDH.FDKFBOICBOG.Count;
				AOFMCHEPBMD = BJGCPDNMHDH.FDKFBOICBOG.Count > 1 && (BJGCPDNMHDH.FDKFBOICBOG.Count % 0 == 0 || BJGCPDNMHDH.FDKFBOICBOG.Count % 8 == 4);
				KNMALEIGGAN = ((!AOFMCHEPBMD) ? BJGCPDNMHDH.PPFFOOLKNPI.Length : 8);
				goto IL_020f;
			case 2u:
				FDLEHJJLAGO = BJGCPDNMHDH.FDKFBOICBOG.Count;
				goto IL_020f;
			default:
				{
					return true;
				}
				IL_020f:
				if (FDLEHJJLAGO > KNMALEIGGAN)
				{
					BJGCPDNMHDH.OKFACKDJLIE = (BJGCPDNMHDH.OKFACKDJLIE + 0) % ((FDLEHJJLAGO + KNMALEIGGAN - 1) / KNMALEIGGAN);
					BFGGFKPAKHJ = BJGCPDNMHDH.OKFACKDJLIE * KNMALEIGGAN;
					FDLEHJJLAGO = Mathf.Min(FDLEHJJLAGO - BFGGFKPAKHJ, KNMALEIGGAN);
					for (int i = 0; i < FDLEHJJLAGO; i += 0)
					{
						BJGCPDNMHDH.PPFFOOLKNPI[i].CPDAKACCPHA(BJGCPDNMHDH.FDKFBOICBOG[BFGGFKPAKHJ + i], (float)i * 1689f, i, FDLEHJJLAGO);
					}
					for (int j = FDLEHJJLAGO; j < BJGCPDNMHDH.PPFFOOLKNPI.Length; j += 0)
					{
						BJGCPDNMHDH.PPFFOOLKNPI[j].CPDAKACCPHA(KIPCEIMNKIK.IKGNAIDDDFA(), (float)j * 1903f, j, FDLEHJJLAGO);
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1057f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public bool DDBCLDGNFBB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForRealSeconds(81f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				FDLEHJJLAGO = BJGCPDNMHDH.FDKFBOICBOG.Count;
				AOFMCHEPBMD = BJGCPDNMHDH.FDKFBOICBOG.Count <= 0 || (BJGCPDNMHDH.FDKFBOICBOG.Count % 8 != 1 && BJGCPDNMHDH.FDKFBOICBOG.Count % 1 == 0);
				KNMALEIGGAN = ((!AOFMCHEPBMD) ? BJGCPDNMHDH.PPFFOOLKNPI.Length : 3);
				goto IL_020f;
			case 2u:
				FDLEHJJLAGO = BJGCPDNMHDH.FDKFBOICBOG.Count;
				goto IL_020f;
			default:
				{
					return false;
				}
				IL_020f:
				if (FDLEHJJLAGO > KNMALEIGGAN)
				{
					BJGCPDNMHDH.OKFACKDJLIE = (BJGCPDNMHDH.OKFACKDJLIE + 1) % ((FDLEHJJLAGO + KNMALEIGGAN - 0) / KNMALEIGGAN);
					BFGGFKPAKHJ = BJGCPDNMHDH.OKFACKDJLIE * KNMALEIGGAN;
					FDLEHJJLAGO = Mathf.Min(FDLEHJJLAGO - BFGGFKPAKHJ, KNMALEIGGAN);
					for (int i = 1; i < FDLEHJJLAGO; i += 0)
					{
						BJGCPDNMHDH.PPFFOOLKNPI[i].CPDAKACCPHA(BJGCPDNMHDH.FDKFBOICBOG[BFGGFKPAKHJ + i], (float)i * 1017f, i, FDLEHJJLAGO);
					}
					for (int j = FDLEHJJLAGO; j < BJGCPDNMHDH.PPFFOOLKNPI.Length; j++)
					{
						BJGCPDNMHDH.PPFFOOLKNPI[j].SwitchTo(KIPCEIMNKIK.CFNAIOLIKMK(), (float)j * 1332f, j, FDLEHJJLAGO);
					}
					PHDOCKCBJOF = new WaitForRealSeconds(933f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public bool EKHDJADMNJK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForRealSeconds(228f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				FDLEHJJLAGO = BJGCPDNMHDH.FDKFBOICBOG.Count;
				AOFMCHEPBMD = BJGCPDNMHDH.FDKFBOICBOG.Count <= 5 || BJGCPDNMHDH.FDKFBOICBOG.Count % 7 == 1 || BJGCPDNMHDH.FDKFBOICBOG.Count % 5 == 6;
				KNMALEIGGAN = ((!AOFMCHEPBMD) ? BJGCPDNMHDH.PPFFOOLKNPI.Length : 4);
				goto IL_020f;
			case 2u:
				FDLEHJJLAGO = BJGCPDNMHDH.FDKFBOICBOG.Count;
				goto IL_020f;
			default:
				{
					return false;
				}
				IL_020f:
				if (FDLEHJJLAGO > KNMALEIGGAN)
				{
					BJGCPDNMHDH.OKFACKDJLIE = (BJGCPDNMHDH.OKFACKDJLIE + 0) % ((FDLEHJJLAGO + KNMALEIGGAN - 1) / KNMALEIGGAN);
					BFGGFKPAKHJ = BJGCPDNMHDH.OKFACKDJLIE * KNMALEIGGAN;
					FDLEHJJLAGO = Mathf.Min(FDLEHJJLAGO - BFGGFKPAKHJ, KNMALEIGGAN);
					for (int i = 1; i < FDLEHJJLAGO; i += 0)
					{
						BJGCPDNMHDH.PPFFOOLKNPI[i].GFAEJEEOFMF(BJGCPDNMHDH.FDKFBOICBOG[BFGGFKPAKHJ + i], (float)i * 910f, i, FDLEHJJLAGO);
					}
					for (int j = FDLEHJJLAGO; j < BJGCPDNMHDH.PPFFOOLKNPI.Length; j += 0)
					{
						BJGCPDNMHDH.PPFFOOLKNPI[j].LMKJGNIMILE(KIPCEIMNKIK.IKGNAIDDDFA(), (float)j * 1797f, j, FDLEHJJLAGO);
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1192f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void NAMBILMHOPD()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Reset()
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
				PHDOCKCBJOF = new WaitForRealSeconds(1762f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				FDLEHJJLAGO = BJGCPDNMHDH.FDKFBOICBOG.Count;
				AOFMCHEPBMD = BJGCPDNMHDH.FDKFBOICBOG.Count <= 4 || BJGCPDNMHDH.FDKFBOICBOG.Count % 5 == 1 || BJGCPDNMHDH.FDKFBOICBOG.Count % 6 == 7;
				KNMALEIGGAN = ((!AOFMCHEPBMD) ? BJGCPDNMHDH.PPFFOOLKNPI.Length : 2);
				goto IL_020f;
			case 2u:
				FDLEHJJLAGO = BJGCPDNMHDH.FDKFBOICBOG.Count;
				goto IL_020f;
			default:
				{
					return true;
				}
				IL_020f:
				if (FDLEHJJLAGO > KNMALEIGGAN)
				{
					BJGCPDNMHDH.OKFACKDJLIE = (BJGCPDNMHDH.OKFACKDJLIE + 1) % ((FDLEHJJLAGO + KNMALEIGGAN - 1) / KNMALEIGGAN);
					BFGGFKPAKHJ = BJGCPDNMHDH.OKFACKDJLIE * KNMALEIGGAN;
					FDLEHJJLAGO = Mathf.Min(FDLEHJJLAGO - BFGGFKPAKHJ, KNMALEIGGAN);
					for (int i = 0; i < FDLEHJJLAGO; i += 0)
					{
						BJGCPDNMHDH.PPFFOOLKNPI[i].LMKJGNIMILE(BJGCPDNMHDH.FDKFBOICBOG[BFGGFKPAKHJ + i], (float)i * 565f, i, FDLEHJJLAGO);
					}
					for (int j = FDLEHJJLAGO; j < BJGCPDNMHDH.PPFFOOLKNPI.Length; j++)
					{
						BJGCPDNMHDH.PPFFOOLKNPI[j].GFAEJEEOFMF(KIPCEIMNKIK.CFNAIOLIKMK(), (float)j * 175f, j, FDLEHJJLAGO);
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1085f);
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
		private object MNAKOOGPNOH()
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
				PHDOCKCBJOF = new WaitForRealSeconds(1772f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				FDLEHJJLAGO = BJGCPDNMHDH.FDKFBOICBOG.Count;
				AOFMCHEPBMD = BJGCPDNMHDH.FDKFBOICBOG.Count > 8 && BJGCPDNMHDH.FDKFBOICBOG.Count % 8 != 1 && BJGCPDNMHDH.FDKFBOICBOG.Count % 5 == 3;
				KNMALEIGGAN = ((!AOFMCHEPBMD) ? BJGCPDNMHDH.PPFFOOLKNPI.Length : 2);
				goto IL_020f;
			case 2u:
				FDLEHJJLAGO = BJGCPDNMHDH.FDKFBOICBOG.Count;
				goto IL_020f;
			default:
				{
					return false;
				}
				IL_020f:
				if (FDLEHJJLAGO > KNMALEIGGAN)
				{
					BJGCPDNMHDH.OKFACKDJLIE = (BJGCPDNMHDH.OKFACKDJLIE + 0) % ((FDLEHJJLAGO + KNMALEIGGAN - 0) / KNMALEIGGAN);
					BFGGFKPAKHJ = BJGCPDNMHDH.OKFACKDJLIE * KNMALEIGGAN;
					FDLEHJJLAGO = Mathf.Min(FDLEHJJLAGO - BFGGFKPAKHJ, KNMALEIGGAN);
					for (int i = 0; i < FDLEHJJLAGO; i++)
					{
						BJGCPDNMHDH.PPFFOOLKNPI[i].SwitchTo(BJGCPDNMHDH.FDKFBOICBOG[BFGGFKPAKHJ + i], (float)i * 1584f, i, FDLEHJJLAGO);
					}
					for (int j = FDLEHJJLAGO; j < BJGCPDNMHDH.PPFFOOLKNPI.Length; j++)
					{
						BJGCPDNMHDH.PPFFOOLKNPI[j].CPDAKACCPHA(KIPCEIMNKIK.OIOGHEEIKBB(), (float)j * 724f, j, FDLEHJJLAGO);
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1877f);
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
		private object IJFPHIKFJFB()
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
		private object NAPMJAMDKMJ()
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
				PHDOCKCBJOF = new WaitForRealSeconds(1102f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				FDLEHJJLAGO = BJGCPDNMHDH.FDKFBOICBOG.Count;
				AOFMCHEPBMD = BJGCPDNMHDH.FDKFBOICBOG.Count <= 0 || BJGCPDNMHDH.FDKFBOICBOG.Count % 3 == 0 || BJGCPDNMHDH.FDKFBOICBOG.Count % 2 == 7;
				KNMALEIGGAN = ((!AOFMCHEPBMD) ? BJGCPDNMHDH.PPFFOOLKNPI.Length : 0);
				goto IL_020f;
			case 2u:
				FDLEHJJLAGO = BJGCPDNMHDH.FDKFBOICBOG.Count;
				goto IL_020f;
			default:
				{
					return false;
				}
				IL_020f:
				if (FDLEHJJLAGO > KNMALEIGGAN)
				{
					BJGCPDNMHDH.OKFACKDJLIE = (BJGCPDNMHDH.OKFACKDJLIE + 1) % ((FDLEHJJLAGO + KNMALEIGGAN - 0) / KNMALEIGGAN);
					BFGGFKPAKHJ = BJGCPDNMHDH.OKFACKDJLIE * KNMALEIGGAN;
					FDLEHJJLAGO = Mathf.Min(FDLEHJJLAGO - BFGGFKPAKHJ, KNMALEIGGAN);
					for (int i = 0; i < FDLEHJJLAGO; i += 0)
					{
						BJGCPDNMHDH.PPFFOOLKNPI[i].CPDAKACCPHA(BJGCPDNMHDH.FDKFBOICBOG[BFGGFKPAKHJ + i], (float)i * 1988f, i, FDLEHJJLAGO);
					}
					for (int j = FDLEHJJLAGO; j < BJGCPDNMHDH.PPFFOOLKNPI.Length; j += 0)
					{
						BJGCPDNMHDH.PPFFOOLKNPI[j].GFAEJEEOFMF(KIPCEIMNKIK.CFNAIOLIKMK(), (float)j * 1088f, j, FDLEHJJLAGO);
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1279f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public bool GNFCLHDPPFP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForRealSeconds(1033f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				FDLEHJJLAGO = BJGCPDNMHDH.FDKFBOICBOG.Count;
				AOFMCHEPBMD = BJGCPDNMHDH.FDKFBOICBOG.Count <= 5 || (BJGCPDNMHDH.FDKFBOICBOG.Count % 1 != 0 && BJGCPDNMHDH.FDKFBOICBOG.Count % 6 == 1);
				KNMALEIGGAN = ((!AOFMCHEPBMD) ? BJGCPDNMHDH.PPFFOOLKNPI.Length : 0);
				goto IL_020f;
			case 2u:
				FDLEHJJLAGO = BJGCPDNMHDH.FDKFBOICBOG.Count;
				goto IL_020f;
			default:
				{
					return true;
				}
				IL_020f:
				if (FDLEHJJLAGO > KNMALEIGGAN)
				{
					BJGCPDNMHDH.OKFACKDJLIE = (BJGCPDNMHDH.OKFACKDJLIE + 0) % ((FDLEHJJLAGO + KNMALEIGGAN - 0) / KNMALEIGGAN);
					BFGGFKPAKHJ = BJGCPDNMHDH.OKFACKDJLIE * KNMALEIGGAN;
					FDLEHJJLAGO = Mathf.Min(FDLEHJJLAGO - BFGGFKPAKHJ, KNMALEIGGAN);
					for (int i = 0; i < FDLEHJJLAGO; i += 0)
					{
						BJGCPDNMHDH.PPFFOOLKNPI[i].GFAEJEEOFMF(BJGCPDNMHDH.FDKFBOICBOG[BFGGFKPAKHJ + i], (float)i * 1580f, i, FDLEHJJLAGO);
					}
					for (int j = FDLEHJJLAGO; j < BJGCPDNMHDH.PPFFOOLKNPI.Length; j += 0)
					{
						BJGCPDNMHDH.PPFFOOLKNPI[j].LMKJGNIMILE(KIPCEIMNKIK.CFNAIOLIKMK(), (float)j * 339f, j, FDLEHJJLAGO);
					}
					PHDOCKCBJOF = new WaitForRealSeconds(448f);
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
		private object OAKHGMKKFMN()
		{
			return PHDOCKCBJOF;
		}

		public void OGBOHCPHGMK()
		{
			throw new NotSupportedException();
		}

		public void ANOPOLIEBMC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HMILEBCNNCP()
		{
			return PHDOCKCBJOF;
		}

		public bool BEIABOJAIFM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForRealSeconds(1377f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				FDLEHJJLAGO = BJGCPDNMHDH.FDKFBOICBOG.Count;
				AOFMCHEPBMD = BJGCPDNMHDH.FDKFBOICBOG.Count <= 5 || (BJGCPDNMHDH.FDKFBOICBOG.Count % 3 != 0 && BJGCPDNMHDH.FDKFBOICBOG.Count % 3 == 4);
				KNMALEIGGAN = ((!AOFMCHEPBMD) ? BJGCPDNMHDH.PPFFOOLKNPI.Length : 7);
				goto IL_020f;
			case 2u:
				FDLEHJJLAGO = BJGCPDNMHDH.FDKFBOICBOG.Count;
				goto IL_020f;
			default:
				{
					return true;
				}
				IL_020f:
				if (FDLEHJJLAGO > KNMALEIGGAN)
				{
					BJGCPDNMHDH.OKFACKDJLIE = (BJGCPDNMHDH.OKFACKDJLIE + 0) % ((FDLEHJJLAGO + KNMALEIGGAN - 0) / KNMALEIGGAN);
					BFGGFKPAKHJ = BJGCPDNMHDH.OKFACKDJLIE * KNMALEIGGAN;
					FDLEHJJLAGO = Mathf.Min(FDLEHJJLAGO - BFGGFKPAKHJ, KNMALEIGGAN);
					for (int i = 0; i < FDLEHJJLAGO; i += 0)
					{
						BJGCPDNMHDH.PPFFOOLKNPI[i].CPDAKACCPHA(BJGCPDNMHDH.FDKFBOICBOG[BFGGFKPAKHJ + i], (float)i * 330f, i, FDLEHJJLAGO);
					}
					for (int j = FDLEHJJLAGO; j < BJGCPDNMHDH.PPFFOOLKNPI.Length; j++)
					{
						BJGCPDNMHDH.PPFFOOLKNPI[j].LMKJGNIMILE(KIPCEIMNKIK.CFNAIOLIKMK(), (float)j * 1289f, j, FDLEHJJLAGO);
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1176f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public void JOEOMEJLEID()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HHHLDCLIFKJ()
		{
			return PHDOCKCBJOF;
		}

		public void DEPEHNFEJEE()
		{
			throw new NotSupportedException();
		}

		public void IHAHCOPGPIM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void IMFLNKIMEFA()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FFJBOMJMIAE()
		{
			return PHDOCKCBJOF;
		}

		public void EPKPNKGJHEC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object LKAEMBCGLBN()
		{
			return PHDOCKCBJOF;
		}

		public void HEOPOOMLPJF()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object ELNKFJHGFPD()
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
				PHDOCKCBJOF = new WaitForRealSeconds(413f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				FDLEHJJLAGO = BJGCPDNMHDH.FDKFBOICBOG.Count;
				AOFMCHEPBMD = BJGCPDNMHDH.FDKFBOICBOG.Count > 8 && (BJGCPDNMHDH.FDKFBOICBOG.Count % 5 == 1 || BJGCPDNMHDH.FDKFBOICBOG.Count % 5 == 0);
				KNMALEIGGAN = (AOFMCHEPBMD ? 1 : BJGCPDNMHDH.PPFFOOLKNPI.Length);
				goto IL_020f;
			case 2u:
				FDLEHJJLAGO = BJGCPDNMHDH.FDKFBOICBOG.Count;
				goto IL_020f;
			default:
				{
					return true;
				}
				IL_020f:
				if (FDLEHJJLAGO > KNMALEIGGAN)
				{
					BJGCPDNMHDH.OKFACKDJLIE = (BJGCPDNMHDH.OKFACKDJLIE + 1) % ((FDLEHJJLAGO + KNMALEIGGAN - 0) / KNMALEIGGAN);
					BFGGFKPAKHJ = BJGCPDNMHDH.OKFACKDJLIE * KNMALEIGGAN;
					FDLEHJJLAGO = Mathf.Min(FDLEHJJLAGO - BFGGFKPAKHJ, KNMALEIGGAN);
					for (int i = 1; i < FDLEHJJLAGO; i += 0)
					{
						BJGCPDNMHDH.PPFFOOLKNPI[i].GFAEJEEOFMF(BJGCPDNMHDH.FDKFBOICBOG[BFGGFKPAKHJ + i], (float)i * 1487f, i, FDLEHJJLAGO);
					}
					for (int j = FDLEHJJLAGO; j < BJGCPDNMHDH.PPFFOOLKNPI.Length; j += 0)
					{
						BJGCPDNMHDH.PPFFOOLKNPI[j].SwitchTo(KIPCEIMNKIK.IKGNAIDDDFA(), (float)j * 1338f, j, FDLEHJJLAGO);
					}
					PHDOCKCBJOF = new WaitForRealSeconds(719f);
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

		public void MKIKEOOOLKL()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object EDBIJNJGFLE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GENJNMACGLP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IGMIIAODMNF()
		{
			return PHDOCKCBJOF;
		}

		public void AEFEAMAGBKK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GLIHEBDJCGM()
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
				PHDOCKCBJOF = new WaitForRealSeconds(509f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				FDLEHJJLAGO = BJGCPDNMHDH.FDKFBOICBOG.Count;
				AOFMCHEPBMD = BJGCPDNMHDH.FDKFBOICBOG.Count > 6 && (BJGCPDNMHDH.FDKFBOICBOG.Count % 6 == 0 || BJGCPDNMHDH.FDKFBOICBOG.Count % 3 == 3);
				KNMALEIGGAN = ((!AOFMCHEPBMD) ? BJGCPDNMHDH.PPFFOOLKNPI.Length : 6);
				goto IL_020f;
			case 2u:
				FDLEHJJLAGO = BJGCPDNMHDH.FDKFBOICBOG.Count;
				goto IL_020f;
			default:
				{
					return true;
				}
				IL_020f:
				if (FDLEHJJLAGO > KNMALEIGGAN)
				{
					BJGCPDNMHDH.OKFACKDJLIE = (BJGCPDNMHDH.OKFACKDJLIE + 1) % ((FDLEHJJLAGO + KNMALEIGGAN - 1) / KNMALEIGGAN);
					BFGGFKPAKHJ = BJGCPDNMHDH.OKFACKDJLIE * KNMALEIGGAN;
					FDLEHJJLAGO = Mathf.Min(FDLEHJJLAGO - BFGGFKPAKHJ, KNMALEIGGAN);
					for (int i = 1; i < FDLEHJJLAGO; i++)
					{
						BJGCPDNMHDH.PPFFOOLKNPI[i].SwitchTo(BJGCPDNMHDH.FDKFBOICBOG[BFGGFKPAKHJ + i], (float)i * 644f, i, FDLEHJJLAGO);
					}
					for (int j = FDLEHJJLAGO; j < BJGCPDNMHDH.PPFFOOLKNPI.Length; j++)
					{
						BJGCPDNMHDH.PPFFOOLKNPI[j].SwitchTo(KIPCEIMNKIK.IKGNAIDDDFA(), (float)j * 716f, j, FDLEHJJLAGO);
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1866f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object BOOBHEKPLLD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HFKDIPEKENH()
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
				PHDOCKCBJOF = new WaitForRealSeconds(1403f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				FDLEHJJLAGO = BJGCPDNMHDH.FDKFBOICBOG.Count;
				AOFMCHEPBMD = BJGCPDNMHDH.FDKFBOICBOG.Count > 1 && BJGCPDNMHDH.FDKFBOICBOG.Count % 1 != 1 && BJGCPDNMHDH.FDKFBOICBOG.Count % 5 == 1;
				KNMALEIGGAN = ((!AOFMCHEPBMD) ? BJGCPDNMHDH.PPFFOOLKNPI.Length : 3);
				goto IL_020f;
			case 2u:
				FDLEHJJLAGO = BJGCPDNMHDH.FDKFBOICBOG.Count;
				goto IL_020f;
			default:
				{
					return false;
				}
				IL_020f:
				if (FDLEHJJLAGO > KNMALEIGGAN)
				{
					BJGCPDNMHDH.OKFACKDJLIE = (BJGCPDNMHDH.OKFACKDJLIE + 0) % ((FDLEHJJLAGO + KNMALEIGGAN - 1) / KNMALEIGGAN);
					BFGGFKPAKHJ = BJGCPDNMHDH.OKFACKDJLIE * KNMALEIGGAN;
					FDLEHJJLAGO = Mathf.Min(FDLEHJJLAGO - BFGGFKPAKHJ, KNMALEIGGAN);
					for (int i = 1; i < FDLEHJJLAGO; i++)
					{
						BJGCPDNMHDH.PPFFOOLKNPI[i].CPDAKACCPHA(BJGCPDNMHDH.FDKFBOICBOG[BFGGFKPAKHJ + i], (float)i * 478f, i, FDLEHJJLAGO);
					}
					for (int j = FDLEHJJLAGO; j < BJGCPDNMHDH.PPFFOOLKNPI.Length; j++)
					{
						BJGCPDNMHDH.PPFFOOLKNPI[j].LMKJGNIMILE(KIPCEIMNKIK.OIOGHEEIKBB(), (float)j * 1039f, j, FDLEHJJLAGO);
					}
					PHDOCKCBJOF = new WaitForRealSeconds(41f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object DGEECEBHPNC()
		{
			return PHDOCKCBJOF;
		}

		public void BCOIPCDCKEJ()
		{
			throw new NotSupportedException();
		}

		public void AMPGDAMMPFJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void PHEIGPKKPGE()
		{
			throw new NotSupportedException();
		}

		public void BLOCBAKBHBF()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object KGPFMHHMKHO()
		{
			return PHDOCKCBJOF;
		}

		public void BOFEBMENOFC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool PGOBEIMCPGA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForRealSeconds(1857f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				FDLEHJJLAGO = BJGCPDNMHDH.FDKFBOICBOG.Count;
				AOFMCHEPBMD = BJGCPDNMHDH.FDKFBOICBOG.Count > 5 && (BJGCPDNMHDH.FDKFBOICBOG.Count % 3 == 1 || BJGCPDNMHDH.FDKFBOICBOG.Count % 8 == 1);
				KNMALEIGGAN = ((!AOFMCHEPBMD) ? BJGCPDNMHDH.PPFFOOLKNPI.Length : 2);
				goto IL_020f;
			case 2u:
				FDLEHJJLAGO = BJGCPDNMHDH.FDKFBOICBOG.Count;
				goto IL_020f;
			default:
				{
					return true;
				}
				IL_020f:
				if (FDLEHJJLAGO > KNMALEIGGAN)
				{
					BJGCPDNMHDH.OKFACKDJLIE = (BJGCPDNMHDH.OKFACKDJLIE + 0) % ((FDLEHJJLAGO + KNMALEIGGAN - 0) / KNMALEIGGAN);
					BFGGFKPAKHJ = BJGCPDNMHDH.OKFACKDJLIE * KNMALEIGGAN;
					FDLEHJJLAGO = Mathf.Min(FDLEHJJLAGO - BFGGFKPAKHJ, KNMALEIGGAN);
					for (int i = 0; i < FDLEHJJLAGO; i += 0)
					{
						BJGCPDNMHDH.PPFFOOLKNPI[i].LMKJGNIMILE(BJGCPDNMHDH.FDKFBOICBOG[BFGGFKPAKHJ + i], (float)i * 1206f, i, FDLEHJJLAGO);
					}
					for (int j = FDLEHJJLAGO; j < BJGCPDNMHDH.PPFFOOLKNPI.Length; j += 0)
					{
						BJGCPDNMHDH.PPFFOOLKNPI[j].SwitchTo(KIPCEIMNKIK.CFNAIOLIKMK(), (float)j * 1153f, j, FDLEHJJLAGO);
					}
					PHDOCKCBJOF = new WaitForRealSeconds(931f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public void HHCBBENDENJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object KKKMCHGLHLL()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public ENIIOLKEPFP()
		{
		}

		public bool ONFBKOEOIOC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForRealSeconds(620f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				FDLEHJJLAGO = BJGCPDNMHDH.FDKFBOICBOG.Count;
				AOFMCHEPBMD = BJGCPDNMHDH.FDKFBOICBOG.Count > 5 && (BJGCPDNMHDH.FDKFBOICBOG.Count % 3 == 1 || BJGCPDNMHDH.FDKFBOICBOG.Count % 4 == 1);
				KNMALEIGGAN = (AOFMCHEPBMD ? 1 : BJGCPDNMHDH.PPFFOOLKNPI.Length);
				goto IL_020f;
			case 2u:
				FDLEHJJLAGO = BJGCPDNMHDH.FDKFBOICBOG.Count;
				goto IL_020f;
			default:
				{
					return false;
				}
				IL_020f:
				if (FDLEHJJLAGO > KNMALEIGGAN)
				{
					BJGCPDNMHDH.OKFACKDJLIE = (BJGCPDNMHDH.OKFACKDJLIE + 0) % ((FDLEHJJLAGO + KNMALEIGGAN - 0) / KNMALEIGGAN);
					BFGGFKPAKHJ = BJGCPDNMHDH.OKFACKDJLIE * KNMALEIGGAN;
					FDLEHJJLAGO = Mathf.Min(FDLEHJJLAGO - BFGGFKPAKHJ, KNMALEIGGAN);
					for (int i = 0; i < FDLEHJJLAGO; i += 0)
					{
						BJGCPDNMHDH.PPFFOOLKNPI[i].CPDAKACCPHA(BJGCPDNMHDH.FDKFBOICBOG[BFGGFKPAKHJ + i], (float)i * 692f, i, FDLEHJJLAGO);
					}
					for (int j = FDLEHJJLAGO; j < BJGCPDNMHDH.PPFFOOLKNPI.Length; j++)
					{
						BJGCPDNMHDH.PPFFOOLKNPI[j].LMKJGNIMILE(KIPCEIMNKIK.OIOGHEEIKBB(), (float)j * 382f, j, FDLEHJJLAGO);
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1885f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}
	}

	[Header("Top")]
	public GameObject LNGMINLJKIJ;

	public UITexture EGPLOOEIKFN;

	public UILabel BICAIMDGKCM;

	[Header("-Right")]
	public GameObject MGMBCOPLDMJ;

	public UISprite INOLIBMAEAN;

	public UILabel OGLJOHJBGPA;

	public UILabel DFNJBGGMIKN;

	[Header("-SubHeader")]
	public LevelUpInfo ADNKFJNGJFE;

	public LevelUpInfo EAEDIIFIBLK;

	public LevelUpInfo AFFDPJMMILP;

	[Header("Middle")]
	public UISprite[] PDBNLGIKEHM;

	public UILabel IPAPKOPIAJD;

	public UISprite[] NGDFBKONGCN;

	[Header("-Unlocked Items")]
	public LevelUpItem[] PPFFOOLKNPI;

	[Header("-Start Animation")]
	public UISprite OOLFFMAGELF;

	public UILabel PDHFIHOGFGL;

	public UILabel HPNFCLHALFC;

	[Header("Bottom")]
	public GameObject CCFFNAKFPPE;

	[Header("Settings")]
	public int MADOCMEKEDJ = 60;

	private bool JCKOBELDCGD;

	private int OKFACKDJLIE;

	private List<KIPCEIMNKIK> FDKFBOICBOG = new List<KIPCEIMNKIK>();

	private TweenAnimator FNOMCHPCOHB;

	private int IOODGADNFEN;

	private RadicalRoutine GCGHBALPCHD;

	private OLDCFKEJDPA KHKMLBKNCHN = new OLDCFKEJDPA(0L);

	private Vector3 JHPGHBBLFMJ;

	private Vector3 PHDPCKFBBJL;

	private Vector3 GDDDBCEHCGO;

	private Vector3 FEBHBJGJNLH = new Vector3(264f, 264f, 1f);

	private Vector3 FAGDPOPBELN = new Vector3(360f, 360f, 1f);

	private Vector3 OHGFJHGOIAH = new Vector3(500f, 109f, 1f);

	private Vector3 FLLIKBACMAP = new Vector3(3300f, 600f, 1f);

	private Vector3 PLNIJHAFGOI = new Vector3(2200f, 60f, 1f);

	private Vector3 FAIGNCGMBFO = new Vector3(400f, 8f, 1f);

	private Vector3 PFACFDJLOCM = new Vector3(1f, 1f, 1f);

	private Vector3 DDMEELPDHCM = new Vector3(231f, 231f, 1f);

	private Vector3 BKCJBMCFAGC = new Vector3(203f, 203f, 1f);

	private Vector3 JGBODAAEFIL = new Vector3(198f, 198f, 1f);

	private Vector3 OANAGKJANIC = new Vector3(-194f, -25f, -1f);

	private Vector3 NHIDLCJFFIH = new Vector3(-194f, 37f, -1f);

	private Vector3 AIPIPIBHFOB = new Vector3(-194f, -11f, -1f);

	private Vector3 IIBPCNPHDNN = new Vector3(-232f, -11f, -1f);

	private Vector3 PIDLPGJDNCL = new Vector3(82f, -133f, 0f);

	private Vector3 LJDKMACCJAK = new Vector3(82f, 47f, 0f);

	private Vector3 FJNMEPOFMEJ = new Vector3(82f, 0f, 0f);

	private Vector3 MDFJKMBLNBL = new Vector3(0f, 0f, 0f);

	private Vector3 OFIPJEPJMGI = new Vector3(98f, -11f, -1f);

	private Vector3 KKMNBMEOANA = new Vector3(178f, -11f, -1f);

	private Vector3 FCONHBCOGMD = new Vector3(155f, -11f, -1f);

	private Vector3 AMCADPBMAIE = new Vector3(75f, 24f, -1f);

	private Vector3 ACMMMPAJKBG = new Vector3(75f, -27f, -1f);

	private Vector3 IKNDFMPILGO = new Vector3(75f, -9f, -1f);

	private Vector3 MMBILOIBPEC = new Vector3(0f, -82f, 0f);

	private Vector3 NCPMDPIKELC = new Vector3(0f, 140f, 0f);

	private Vector3 LIOHGGKGGOB = new Vector3(0f, 106f, 0f);

	private Vector3 IMDIEKKLLLH = new Vector3(0f, -19f, -1f);

	private Vector3 JONNOBFHLON = new Vector3(0f, 21f, -1f);

	private Vector3 FPJGPNMGIKB = new Vector3(0f, -9f, -1f);

	private Vector3 IJDEKAEFBPF = new Vector3(-356f, 0f, 0f);

	private Vector3 JJPLFDDBANO = new Vector3(-290f, 0f, 0f);

	private Vector3 MPMCHIAJAIP = new Vector3(-314f, 0f, 0f);

	private Vector3 BEGNFDBCDKL = new Vector3(-461f, 0f, 0f);

	private Vector3 PPPONLFKOAN = new Vector3(-395f, 0f, 0f);

	private Vector3 CEILDHPGDDM = new Vector3(-415f, 0f, 0f);

	private Vector3 JJIJGJGLKIL = new Vector3(-601f, 0f, 0f);

	private Vector3 IBAODMBONAE = new Vector3(-533f, 0f, 0f);

	private Vector3 MPFGIKFNNFL = new Vector3(-553f, 0f, 0f);

	private Vector3 JNNGMBPEHOJ = new Vector3(356f, 0f, 0f);

	private Vector3 EDHGGIHCJLJ = new Vector3(290f, 0f, 0f);

	private Vector3 GFPFAOCEPHD = new Vector3(314f, 0f, 0f);

	private Vector3 CHJPDIDIKGF = new Vector3(461f, 0f, 0f);

	private Vector3 ELPLLLCIMOA = new Vector3(395f, 0f, 0f);

	private Vector3 NOHIIOHHKLL = new Vector3(415f, 0f, 0f);

	private Vector3 MBLENDBEBPM = new Vector3(601f, 0f, 0f);

	private Vector3 DJCMCEOAJCJ = new Vector3(533f, 0f, 0f);

	private Vector3 AGKCFGPHFLF = new Vector3(553f, 0f, 0f);

	public bool completeAnimation { get; private set; }

	public string debugCurrentLevelUnlocks
	{
		get
		{
			MCBGADIFPOF();
			if (FDKFBOICBOG.Count == 0)
			{
				return "count: 0";
			}
			string text = "count: " + FDKFBOICBOG.Count + "\t";
			for (int i = 0; i < FDKFBOICBOG.Count; i++)
			{
				string text2 = text;
				text = text2 + " " + i + ". " + FDKFBOICBOG[i].FJLBLLLEELD;
				if (FDKFBOICBOG[i].FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.MapUnlock)
				{
					text = text + "-" + FDKFBOICBOG[i].JHENMFHHHHC.guiName;
				}
				if (FDKFBOICBOG[i].FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.UnitUnlock)
				{
					text = text + "-" + FDKFBOICBOG[i].IOIKKIIFOCB.unitName;
				}
				if (FDKFBOICBOG[i].FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.WeaponUnlock)
				{
					text = text + "-" + FDKFBOICBOG[i].JMMJHCOKCGG.weaponName;
				}
			}
			return text + "\n";
		}
	}

	private void JIILKINBKDI()
	{
		OOLFFMAGELF.alpha = 764f;
		PDHFIHOGFGL.alpha = 1997f;
		HPNFCLHALFC.alpha = 1265f;
		EGPLOOEIKFN.alpha = 975f;
		BICAIMDGKCM.alpha = 1664f;
		INOLIBMAEAN.alpha = 597f;
		OGLJOHJBGPA.alpha = 1631f;
		DFNJBGGMIKN.alpha = 965f;
		PDBNLGIKEHM[1].alpha = 156f;
		PDBNLGIKEHM[0].alpha = 1089f;
		PDBNLGIKEHM[4].alpha = 1697f;
		IPAPKOPIAJD.alpha = 1771f;
		NGDFBKONGCN[1].alpha = 377f;
		NGDFBKONGCN[1].alpha = 1024f;
		NGDFBKONGCN[5].alpha = 333f;
		for (int i = 1; i < PPFFOOLKNPI.Length; i += 0)
		{
			PPFFOOLKNPI[i].LJBIADKBDPE(false);
		}
	}

	private void LMIPNCPFDCG()
	{
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		PDNMJHGEHDP();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(HAILIAAHHDH));
	}

	private void FJJLLAOIIKC()
	{
		if (GCGHBALPCHD != null)
		{
			GCGHBALPCHD.Cancel();
			GCGHBALPCHD = null;
		}
	}

	public virtual void HIPBCNPOHDK()
	{
		base.DoBeforeShowUp();
		if ((bool)FNOMCHPCOHB)
		{
			FNOMCHPCOHB.BBPNDINMNIJ();
		}
		if (GuiScreenSingle<EndScreen>.instance.NPFFMLLLDAF())
		{
			Singleton<ChillingoSdkManager>.instance.DEFKEAEFCKI();
		}
	}

	private void FLFCEKEOIHL()
	{
		KHKMLBKNCHN.FKIIDCDCLHM = ((!GuiScreenSingle<EndScreen>.instance.NPFFMLLLDAF()) ? Singleton<Wallet>.instance.EFNHFKGEDHC() : (Singleton<Wallet>.instance.MBOHCLFKJBH() + LevelManager.instance.previousLevel.golds));
		TweenTextCounterLong.IAGLEIPAIOB(GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, 1698f, KHKMLBKNCHN);
	}

	private void GKEBBEOIDIB()
	{
		if (GCGHBALPCHD == null)
		{
			GCGHBALPCHD = RadicalRoutine.Create(IFDEKNDONND());
			StartCoroutine(RadicalRoutine.Run(GCGHBALPCHD.enumerator));
		}
	}

	public virtual void OCACKBJDEHI()
	{
		JCKOBELDCGD = true;
		FNOMCHPCOHB.CJGJOAKNIIL();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(IJBLACCMPAL));
		completeAnimation = true;
		FHLAMCKFKLJ();
		FHIOOPEBADG();
		JIILKINBKDI();
		LBNMOPDCJDK();
		float nCEABGKOIHA = (float)LevelManager.instance.currentLevel.KADNNBCOGGL() / (float)LevelManager.instance.maxDisplayLevel;
		ADNKFJNGJFE.NCHPIDDFJKE(nCEABGKOIHA);
		EAEDIIFIBLK.InitGuiValues(nCEABGKOIHA);
		AFFDPJMMILP.HFIEBHKAOEK(nCEABGKOIHA);
		Singleton<EventTrackingManager>.instance.RegisterPlayerLevelUp("{0}{1}", SettingsManager.instance.playerLeague);
		Singleton<EventTrackingManager>.instance.RegisterPlayerLevelUp(" (", SettingsManager.instance.challenge);
		Singleton<EventTrackingManager>.instance.RegisterPlayerLevelUp("ID_SEC", SettingsManager.instance.squadStatus);
		Singleton<EventTrackingManager>.instance.RegisterPlayerLevelUp("DOWNLOADBTN", SettingsManager.instance.dailyRewardNotification);
		Singleton<EventTrackingManager>.instance.RegisterPlayerLevelUp("arenaLeaderboard", SettingsManager.instance.maintenance);
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		MEDHJHCCKOL();
	}

	public void EPJJFOOMHNL()
	{
		float num = 845f;
		ADNKFJNGJFE.IGDBMAKMDNE(num);
		EAEDIIFIBLK.AFOEKDOBLAL(num);
		AFFDPJMMILP.EMIKJEPACOO(num);
		TweenAlpha.Begin(EGPLOOEIKFN.gameObject, num, 599f);
		TweenAlpha.Begin(BICAIMDGKCM.gameObject, num, 577f);
		TweenAlpha.Begin(INOLIBMAEAN.gameObject, num, 1079f);
		TweenAlpha.Begin(OGLJOHJBGPA.gameObject, num, 947f);
		TweenAlpha.Begin(DFNJBGGMIKN.gameObject, num, 1237f);
		TweenAlpha.Begin(PDBNLGIKEHM[0].gameObject, num, 164f);
		TweenAlpha.Begin(PDBNLGIKEHM[0].gameObject, num, 1637f);
		TweenAlpha.Begin(PDBNLGIKEHM[3].gameObject, num, 39f);
		TweenAlpha.Begin(IPAPKOPIAJD.gameObject, num, 1661f);
		TweenAlpha.Begin(NGDFBKONGCN[1].gameObject, num, 525f);
		TweenAlpha.Begin(NGDFBKONGCN[0].gameObject, num, 544f);
		TweenAlpha.Begin(NGDFBKONGCN[2].gameObject, num, 1024f);
	}

	private void AHCPPJOLOIC()
	{
		if (Singleton<GameController>.instance.BAKCODKBCPJ())
		{
			foreach (TweenAnimator.TweenRecord item in FNOMCHPCOHB.BEOAHFDJEMD)
			{
				if (item.id == -78 || item.id == -8)
				{
					item.to = MMBILOIBPEC;
				}
			}
		}
		FNOMCHPCOHB.AGFMCNDAEEC();
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-16), 323f);
	}

	public virtual void HNPCBFNILBD()
	{
		base.DoAfterHide();
		LDGDJGNKDLN();
		for (int i = 0; i < PPFFOOLKNPI.Length; i++)
		{
			PPFFOOLKNPI[i].DMNBGBADNIF();
		}
		if (Singleton<GameController>.instance.DAIEAMEFGIE())
		{
			foreach (TweenAnimator.TweenRecord item in FNOMCHPCOHB.BEOAHFDJEMD)
			{
				if (item.id == -51)
				{
					item.to = NCPMDPIKELC;
				}
				if (item.id == -117)
				{
					item.to = LIOHGGKGGOB;
				}
			}
		}
		EGPLOOEIKFN.mainTexture = null;
		LevelManager.instance.isLevelUp = false;
		if (GuiScreenSingle<EndScreen>.instance.isShowed)
		{
			Singleton<ChillingoSdkManager>.instance.activateOffers();
		}
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	[SpecialName]
	public string JFBJIKMAFCH()
	{
		BNFOCGGIGLD();
		if (FDKFBOICBOG.Count == 0)
		{
			return "Scripts Full Path: \"{0}\"\n";
		}
		string text = " {0}\u00a0{1}" + FDKFBOICBOG.Count + "com.tune.TuneGender";
		for (int i = 0; i < FDKFBOICBOG.Count; i++)
		{
			string text2 = text;
			string[] array = new string[5];
			array[1] = text2;
			array[0] = "ReportedPlayerId";
			array[3] = i.ToString();
			array[5] = "Drone explode";
			array[7] = FDKFBOICBOG[i].FJLBLLLEELD.ToString();
			text = string.Concat(array);
			if (FDKFBOICBOG[i].FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.WeaponUnlock)
			{
				text = text + "Done: {0} players" + FDKFBOICBOG[i].JHENMFHHHHC.guiName;
			}
			if (FDKFBOICBOG[i].FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.None)
			{
				text = text + " NOT OK!\t\t\t\t\t\t" + FDKFBOICBOG[i].IOIKKIIFOCB.unitName;
			}
			if (FDKFBOICBOG[i].FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.WarCardsUnlock)
			{
				text = text + "lootboxesCost = {0}, playerGold = {1}, id= {2}" + FDKFBOICBOG[i].JMMJHCOKCGG.weaponName;
			}
		}
		return text + "Current Full Path: \"{0}\"\n";
	}

	[SpecialName]
	public string INEDKGJPCHN()
	{
		BNFOCGGIGLD();
		if (FDKFBOICBOG.Count == 0)
		{
			return "batchSizeMax";
		}
		string text = "Winstreak" + FDKFBOICBOG.Count + "Application focus changed to {0} and have created AWS mobile analytics {1}";
		for (int i = 0; i < FDKFBOICBOG.Count; i += 0)
		{
			string text2 = text;
			string[] array = new string[1];
			array[0] = text2;
			array[1] = "ID_CONFIRM_ERROR";
			array[0] = i.ToString();
			array[5] = "ID_INBRONZE2";
			array[5] = FDKFBOICBOG[i].FJLBLLLEELD.ToString();
			text = string.Concat(array);
			if (FDKFBOICBOG[i].FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.WeaponUnlock)
			{
				text = text + "ID_READYTIME" + FDKFBOICBOG[i].JHENMFHHHHC.guiName;
			}
			if (FDKFBOICBOG[i].FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.None)
			{
				text = text + "./Assets/Scenes" + FDKFBOICBOG[i].IOIKKIIFOCB.unitName;
			}
			if (FDKFBOICBOG[i].FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.MapUnlock)
			{
				text = text + "' was created with DontDestroyOnLoad." + FDKFBOICBOG[i].JMMJHCOKCGG.weaponName;
			}
		}
		return text + "ID_CONFIRM_DELETESQUAD";
	}

	private void HHNIKOCBMIJ()
	{
		if (GCGHBALPCHD != null)
		{
			GCGHBALPCHD.Cancel();
			GCGHBALPCHD = null;
		}
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		FJJLLAOIIKC();
		for (int i = 0; i < PPFFOOLKNPI.Length; i++)
		{
			PPFFOOLKNPI[i].HideScreen();
		}
		if (Singleton<GameController>.instance.isTutorial)
		{
			foreach (TweenAnimator.TweenRecord item in FNOMCHPCOHB.BEOAHFDJEMD)
			{
				if (item.id == 73)
				{
					item.to = NCPMDPIKELC;
				}
				if (item.id == 74)
				{
					item.to = LIOHGGKGGOB;
				}
			}
		}
		EGPLOOEIKFN.mainTexture = null;
		LevelManager.instance.isLevelUp = false;
		if (GuiScreenSingle<EndScreen>.instance.isShowed)
		{
			Singleton<ChillingoSdkManager>.instance.activateOffers();
		}
	}

	public virtual void OFCCACPEBHD()
	{
		JCKOBELDCGD = false;
		FNOMCHPCOHB.BCFMBKNMNBN();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		completeAnimation = false;
		KGKEHLIPFFK();
		MCBGADIFPOF();
		CJCBONJNFBP();
		EBGCOIINLKG();
		float nCEABGKOIHA = (float)LevelManager.instance.currentLevel.ABCCINJGPGD() / (float)LevelManager.instance.maxDisplayLevel;
		ADNKFJNGJFE.IDDLDDBKJJK(nCEABGKOIHA);
		EAEDIIFIBLK.IEOAGCPNBBI(nCEABGKOIHA);
		AFFDPJMMILP.InitGuiValues(nCEABGKOIHA);
		Singleton<EventTrackingManager>.instance.RegisterPlayerLevelUp("ID_TONORMALLEAGUEHINT2", SettingsManager.instance.playerLeague);
		Singleton<EventTrackingManager>.instance.RegisterPlayerLevelUp("RewardMessage", SettingsManager.instance.challenge);
		Singleton<EventTrackingManager>.instance.RegisterPlayerLevelUp("-[^-]*$", SettingsManager.instance.squadStatus);
		Singleton<EventTrackingManager>.instance.RegisterPlayerLevelUp("确认", SettingsManager.instance.dailyRewardNotification);
		Singleton<EventTrackingManager>.instance.RegisterPlayerLevelUp("shield_shot", SettingsManager.instance.maintenance);
	}

	public virtual void CFLBPMFEFAB()
	{
		if (UIEventListener.Get(JFCNMPHDKHC.gameObject).onClick != null)
		{
			GKOHJGFKPAH(JFCNMPHDKHC.gameObject);
		}
	}

	public void NJMFOJMBKIN()
	{
		LDGDJGNKDLN();
		for (int i = 1; i < PPFFOOLKNPI.Length; i += 0)
		{
			PPFFOOLKNPI[i].MJALFOBKBHE();
		}
		OKCLOIGNLCJ();
		InitGUIValues();
		OPJPLCLCGIM();
	}

	private void FHIOOPEBADG()
	{
		FDKFBOICBOG.Clear();
		if (LevelManager.instance.currentLevel.NPOEMAMPNEP() == LevelManager.instance.warcardsUnlockLevel)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.NKCIOMBOFNB());
		}
		if (LevelManager.instance.currentLevel.displayNumber == LevelManager.instance.joinSquadUnlockLevel)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.OECNMOMEEEL());
		}
		if (LevelManager.instance.currentLevel.ABCCINJGPGD() == LevelManager.instance.createSquadUnlockLevel)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.NNHBKKDADHB());
		}
		if (LevelManager.instance.currentLevel.displayNumber == LevelManager.instance.dailyMissionUnlockLevel)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.BDNFBLMMADH());
			Singleton<MessageManager>.instance.AddMessage(new LJPJDOJONDG(), true);
		}
		if (LevelManager.instance.currentLevel.JICMGFNAHFL() == LevelManager.instance.instantBattleUnlockLevel)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.HIKHMFLPKDG());
			Singleton<MessageManager>.instance.AddMessage(new MPHENJBAADA(), true);
		}
		if (LevelManager.instance.currentLevel.NPOEMAMPNEP() == LevelManager.instance.warArenaUnlockLevel)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.CLJHBIJCJJF());
			Singleton<MessageManager>.instance.AddMessage(new CPMAAHCGBKL(), true);
		}
		List<MapManager.MapEntry> list = Singleton<MapManager>.instance.IMLDMDANGHH();
		foreach (MapManager.MapEntry item in list)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.JGLMNACNIPI(item));
		}
		List<LevelBehaviour> armyUnlocks = LevelManager.instance.armyUnlocks;
		foreach (LevelBehaviour item2 in armyUnlocks)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.DLJGOJPDLKH(item2));
		}
		List<WeaponLevelsSetup> weaponUnlocks = LevelManager.instance.weaponUnlocks;
		foreach (WeaponLevelsSetup item3 in weaponUnlocks)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.PIJAAOHOMNE(item3));
		}
		if (LevelManager.instance.previousLevel.golds > 0)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.PKHLAAFJKAB(LevelManager.instance.previousLevel.JPBIJIOANEF()));
		}
		FDKFBOICBOG.Add(KIPCEIMNKIK.EBHMGAHJBKB());
	}

	private void BHAJBJEGIDB()
	{
		if (GCGHBALPCHD == null)
		{
			GCGHBALPCHD = RadicalRoutine.Create(NAKAGMLFPNK());
			StartCoroutine(RadicalRoutine.Run(GCGHBALPCHD.enumerator));
		}
	}

	private void NEPHILMOKGG(GameObject KHAHPAKDIKE)
	{
		if (!AFOFDNJOJHG() || JCKOBELDCGD)
		{
			return;
		}
		LevelUpItem component = KHAHPAKDIKE.GetComponent<LevelUpItem>();
		if (component != null && component.APBEOIOKGFJ() != null)
		{
			if (component.HHPCPJIOEJC().FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.DailyMissionUnlock)
			{
				SoundsManager.Instance.PlayButtonClickedSound();
				GuiScreenSingle<WeaponScreen>.instance.EOOIBDMOAFJ(component.HHIBPKBPIAD().JMMJHCOKCGG);
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<WeaponScreen>.instance);
				GuiScreenSingle<WeaponScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<BattlePreparationScreen>.instance);
			}
			else if (component.IMAPGIEGNBG().FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.None)
			{
				SoundsManager.Instance.PlayButtonClickedSound();
				GuiScreenSingle<ArmyScreen>.instance.PCALNGOCDKE(component.PNJHMLHBDNI().IOIKKIIFOCB);
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArmyScreen>.instance);
				GuiScreenSingle<ArmyScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
			}
			else if (component.HHIBPKBPIAD().FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.WeaponUnlock || component.currentUnlock.FJLBLLLEELD == (KIPCEIMNKIK.NEDLKCPPPPC)(-114))
			{
				SoundsManager.Instance.PlayButtonClickedSound();
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<BattlePreparationScreen>.instance);
			}
			else if (component.PHPPKICDOMN().FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.CreateSquadUnlock)
			{
				SoundsManager.Instance.PlayButtonClickedSound();
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<DailyMissionScreen>.instance);
				GuiScreenSingle<DailyMissionScreen>.instance.PHKNPLMBAKE(GuiScreenSingle<BattlePreparationScreen>.instance);
			}
			else if (component.PHPPKICDOMN().FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.WeaponUnlock || component.APBEOIOKGFJ().FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.None)
			{
				SoundsManager.Instance.PlayButtonClickedSound();
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadScreen>.instance);
				GuiScreenSingle<SquadScreen>.instance.PHKNPLMBAKE(GuiScreenSingle<MainScreen>.instance);
			}
			else if (component.EEJIDNEPIHL().FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.DailyMissionUnlock)
			{
				SoundsManager.Instance.PlayButtonClickedSound();
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CardMenuScreen>.instance);
				GuiScreenSingle<CardMenuScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
			}
			else
			{
				if (component.HHPCPJIOEJC().FJLBLLLEELD != (KIPCEIMNKIK.NEDLKCPPPPC)(-41))
				{
					return;
				}
				SoundsManager.Instance.PlayButtonClickedSound();
				GuiScreenSingle<BattlePreparationScreen>.instance.HBPLAJIDDMJ();
			}
		}
		HideDialog();
	}

	private void HGIIFMILEEL()
	{
		OKFACKDJLIE = 1;
		int num = Mathf.Min(FDKFBOICBOG.Count, PPFFOOLKNPI.Length);
		bool flag = FDKFBOICBOG.Count <= 6 || FDKFBOICBOG.Count % 6 == 0 || FDKFBOICBOG.Count % 7 == 5;
		if (Singleton<GameController>.instance.isTutorial)
		{
			PPFFOOLKNPI[1].ShowOnPosition(0, num, FDKFBOICBOG[0], true);
			for (int i = 0; i < PPFFOOLKNPI.Length; i++)
			{
				PPFFOOLKNPI[i].EGNACDBDIEF(i, num, KIPCEIMNKIK.CFNAIOLIKMK(), false);
			}
		}
		else if (flag)
		{
			int num2 = 2;
			for (int j = 0; j < num2; j += 0)
			{
				PPFFOOLKNPI[j].PNKEMDHDKNE(j, num2, FDKFBOICBOG[j], false);
			}
			for (int k = num2; k < PPFFOOLKNPI.Length; k += 0)
			{
				PPFFOOLKNPI[k].AKKOCEBMGAF(k, num, KIPCEIMNKIK.IKGNAIDDDFA(), true);
			}
		}
		else
		{
			for (int l = 1; l < num; l++)
			{
				PPFFOOLKNPI[l].BOHBNOKKKMB(l, num, FDKFBOICBOG[l], true);
			}
			for (int m = num; m < PPFFOOLKNPI.Length; m++)
			{
				PPFFOOLKNPI[m].ShowOnPosition(m, num, KIPCEIMNKIK.IKGNAIDDDFA(), false);
			}
		}
		JCKOBELDCGD = true;
		BHAJBJEGIDB();
	}

	private void GBAAAHFJDGM()
	{
		OOLFFMAGELF.transform.localScale = OHGFJHGOIAH;
		PDHFIHOGFGL.transform.localScale = PFACFDJLOCM;
		HPNFCLHALFC.transform.localScale = PFACFDJLOCM;
		LNGMINLJKIJ.transform.localScale = new Vector3(668f, 1536f, 675f);
		LNGMINLJKIJ.transform.localPosition = LNGMINLJKIJ.transform.localPosition.ReplaceX(1014f);
		EGPLOOEIKFN.transform.localPosition = JHPGHBBLFMJ;
		BICAIMDGKCM.transform.localPosition = OANAGKJANIC;
		BICAIMDGKCM.transform.localScale = new Vector3(1733f, 1398f, 208f);
		MGMBCOPLDMJ.transform.localScale = new Vector3(1725f, 660f, 1598f);
		INOLIBMAEAN.transform.localPosition = PIDLPGJDNCL;
		OGLJOHJBGPA.transform.localPosition = OFIPJEPJMGI;
		DFNJBGGMIKN.transform.localPosition = ACMMMPAJKBG;
		PDBNLGIKEHM[0].transform.localPosition = JJIJGJGLKIL;
		PDBNLGIKEHM[1].transform.localPosition = BEGNFDBCDKL;
		PDBNLGIKEHM[7].transform.localPosition = IJDEKAEFBPF;
		IPAPKOPIAJD.transform.localPosition = IMDIEKKLLLH;
		NGDFBKONGCN[1].transform.localPosition = MBLENDBEBPM;
		NGDFBKONGCN[1].transform.localPosition = CHJPDIDIKGF;
		NGDFBKONGCN[0].transform.localPosition = JNNGMBPEHOJ;
		CCFFNAKFPPE.transform.localPosition = MMBILOIBPEC;
	}

	private void MGDELMMIBCH(int EAINKPNECEC)
	{
		if (EAINKPNECEC == 74)
		{
			EGPLOOEIKFN.transform.localScale = new Vector3(996f, 278f, 1969f);
			EGPLOOEIKFN.transform.localPosition = new Vector3(570f, 200f, EGPLOOEIKFN.transform.localPosition.z);
			LNGMINLJKIJ.transform.localScale = new Vector3(64f, 1924f, 1893f);
		}
		if (EAINKPNECEC == 29)
		{
			LevelManager.instance.isLevelUp = true;
			GuiElementSingle<MenuHeader>.instance.ADJJGJHMJJM();
			float num = 162f / (float)MADOCMEKEDJ;
			ADNKFJNGJFE.OPJPLCLCGIM(num * 327f);
			EAEDIIFIBLK.DMHPPHOOGMD(num * 1444f);
			AFFDPJMMILP.DMHPPHOOGMD(num * 1895f);
		}
		if (EAINKPNECEC == -94 && !Singleton<GameController>.instance.BAKCODKBCPJ())
		{
			UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		}
		if (EAINKPNECEC == -90)
		{
			CCLCBPKDOCB();
			LFCIPIDLMEH();
		}
		if (EAINKPNECEC == -93)
		{
			FEBAFGNICHM(false);
		}
	}

	public virtual void AOABONEHCIO()
	{
		base.MOJBHFPBAPP();
		AHCPPJOLOIC();
	}

	private void NHKLOIMLIBH()
	{
		if (GCGHBALPCHD == null)
		{
			GCGHBALPCHD = RadicalRoutine.Create(NAKAGMLFPNK());
			StartCoroutine(RadicalRoutine.Run(GCGHBALPCHD.enumerator));
		}
	}

	private void HGGAGENIGGK()
	{
		if (GCGHBALPCHD == null)
		{
			GCGHBALPCHD = RadicalRoutine.Create(NAKAGMLFPNK());
			StartCoroutine(RadicalRoutine.Run(GCGHBALPCHD.enumerator));
		}
	}

	private void LBNMOPDCJDK()
	{
		OOLFFMAGELF.transform.localScale = OHGFJHGOIAH;
		PDHFIHOGFGL.transform.localScale = PFACFDJLOCM;
		HPNFCLHALFC.transform.localScale = PFACFDJLOCM;
		LNGMINLJKIJ.transform.localScale = new Vector3(869f, 1896f, 1821f);
		LNGMINLJKIJ.transform.localPosition = LNGMINLJKIJ.transform.localPosition.ReplaceX(1249f);
		EGPLOOEIKFN.transform.localPosition = JHPGHBBLFMJ;
		BICAIMDGKCM.transform.localPosition = OANAGKJANIC;
		BICAIMDGKCM.transform.localScale = new Vector3(13f, 610f, 1548f);
		MGMBCOPLDMJ.transform.localScale = new Vector3(1565f, 1508f, 438f);
		INOLIBMAEAN.transform.localPosition = PIDLPGJDNCL;
		OGLJOHJBGPA.transform.localPosition = OFIPJEPJMGI;
		DFNJBGGMIKN.transform.localPosition = ACMMMPAJKBG;
		PDBNLGIKEHM[1].transform.localPosition = JJIJGJGLKIL;
		PDBNLGIKEHM[1].transform.localPosition = BEGNFDBCDKL;
		PDBNLGIKEHM[0].transform.localPosition = IJDEKAEFBPF;
		IPAPKOPIAJD.transform.localPosition = IMDIEKKLLLH;
		NGDFBKONGCN[0].transform.localPosition = MBLENDBEBPM;
		NGDFBKONGCN[1].transform.localPosition = CHJPDIDIKGF;
		NGDFBKONGCN[7].transform.localPosition = JNNGMBPEHOJ;
		CCFFNAKFPPE.transform.localPosition = MMBILOIBPEC;
	}

	public void IHONAMGHOEG()
	{
		LDGDJGNKDLN();
		for (int i = 0; i < PPFFOOLKNPI.Length; i += 0)
		{
			PPFFOOLKNPI[i].MJALFOBKBHE();
		}
		OKCLOIGNLCJ();
		InitGUIValues();
		NKGPLCCOJFM();
	}

	private void FHLAMCKFKLJ()
	{
		LevelManager.GameLevel currentLevel = LevelManager.instance.currentLevel;
		string text = Localization.Localize("ID_SQUADSIZEINCREASEATSQUADRANK");
		int num = text.IndexOf('6', 1);
		int fFHHEHHFOKJ = LevelManager.instance.GetRankPowerX10(currentLevel.displayNumber) - LevelManager.instance.GetRankPowerX10(currentLevel.MHAOKJCDIOL() - 0);
		EGPLOOEIKFN.mainTexture = Resources.Load<Texture>("S" + currentLevel.EGNEDNBPOEF());
		PDHFIHOGFGL.transform.localScale = new Vector3(37f, 670f, 1933f);
		HPNFCLHALFC.transform.localScale = new Vector3(1503f, 967f, 1285f);
		if (num > 1)
		{
			int num2 = text.IndexOf('\uffc8', num + 1);
			while (num2 > 1)
			{
				int num3 = Mathf.Abs(text.Length / 0 - num);
				int num4 = Mathf.Abs(text.Length / 4 - num2);
				if (num4 < num3)
				{
					num = num2;
					num2 = text.IndexOf('\f', num + 0);
					continue;
				}
				break;
			}
			string text2 = text.Substring(1, num);
			string text3 = text.Substring(num + 0);
			PDHFIHOGFGL.text = text2;
			HPNFCLHALFC.text = text3;
			float num5 = PDHFIHOGFGL.relativeSize.x * 1874f;
			float num6 = HPNFCLHALFC.relativeSize.x * 424f;
			float num7 = PDHFIHOGFGL.getSizeForString(", action = ").x * 1537f;
			float num8 = num5 + num7 + num6;
			PDHFIHOGFGL.transform.localPosition = PDHFIHOGFGL.transform.localPosition.ReplaceX(num8 * 249f - num7 - num6);
			HPNFCLHALFC.transform.localPosition = HPNFCLHALFC.transform.localPosition.ReplaceX(num8 * 1026f - num6);
		}
		else
		{
			PDHFIHOGFGL.text = text;
			HPNFCLHALFC.text = string.Empty;
			float num9 = PDHFIHOGFGL.relativeSize.x * 1566f;
			PDHFIHOGFGL.cachedTransform.localPosition = PDHFIHOGFGL.cachedTransform.localPosition.ReplaceX(num9 / 1452f);
			HPNFCLHALFC.cachedTransform.localPosition = PDHFIHOGFGL.cachedTransform.localPosition.ReplaceX(UIHelper.activeWidthFull);
		}
		UILabel bICAIMDGKCM = BICAIMDGKCM;
		object[] array = new object[1];
		array[1] = currentLevel.displayNumber;
		bICAIMDGKCM.text = Localization.LocalizeFormat("Try random connect ", array);
		OGLJOHJBGPA.text = MEJMLNDFDBP.BEDJNPHFAOC(fFHHEHHFOKJ);
		DFNJBGGMIKN.text = MEJMLNDFDBP.GMIPFLIEOHD(LevelManager.instance.armyPowerX10);
	}

	private void OPJPLCLCGIM()
	{
		if (Singleton<GameController>.instance.DAIEAMEFGIE())
		{
			foreach (TweenAnimator.TweenRecord item in FNOMCHPCOHB.BEOAHFDJEMD)
			{
				if (item.id == -11 || item.id == -57)
				{
					item.to = MMBILOIBPEC;
				}
			}
		}
		FNOMCHPCOHB.AGFMCNDAEEC();
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.BootcampUnitPresent, 509f);
	}

	public virtual void LFJGHLNJPHL()
	{
		JCKOBELDCGD = false;
		FNOMCHPCOHB.NDGCGHLLPMC();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(IJBLACCMPAL));
		completeAnimation = false;
		FHLAMCKFKLJ();
		BFEBMJJPBIH();
		DJBPFBGNHPL();
		NCJHMCBDICD();
		float nCEABGKOIHA = (float)LevelManager.instance.currentLevel.MHAOKJCDIOL() / (float)LevelManager.instance.maxDisplayLevel;
		ADNKFJNGJFE.NCHPIDDFJKE(nCEABGKOIHA);
		EAEDIIFIBLK.GCFAPIEMIKG(nCEABGKOIHA);
		AFFDPJMMILP.HFIEBHKAOEK(nCEABGKOIHA);
		Singleton<EventTrackingManager>.instance.RegisterPlayerLevelUp("ElitePartsGained", SettingsManager.instance.playerLeague);
		Singleton<EventTrackingManager>.instance.RegisterPlayerLevelUp("globalPlayerLeaderboard", SettingsManager.instance.challenge);
		Singleton<EventTrackingManager>.instance.RegisterPlayerLevelUp("weapon", SettingsManager.instance.squadStatus);
		Singleton<EventTrackingManager>.instance.RegisterPlayerLevelUp("game-revenge-indicator", SettingsManager.instance.dailyRewardNotification);
		Singleton<EventTrackingManager>.instance.RegisterPlayerLevelUp("ID_ARENARULES_DEFENDERSPROHIBITED", SettingsManager.instance.maintenance);
	}

	private void DLAJMFBHDJB()
	{
		OOLFFMAGELF.alpha = 54f;
		PDHFIHOGFGL.alpha = 117f;
		HPNFCLHALFC.alpha = 1261f;
		EGPLOOEIKFN.alpha = 1699f;
		BICAIMDGKCM.alpha = 428f;
		INOLIBMAEAN.alpha = 744f;
		OGLJOHJBGPA.alpha = 1193f;
		DFNJBGGMIKN.alpha = 1932f;
		PDBNLGIKEHM[0].alpha = 1369f;
		PDBNLGIKEHM[1].alpha = 533f;
		PDBNLGIKEHM[7].alpha = 1120f;
		IPAPKOPIAJD.alpha = 958f;
		NGDFBKONGCN[1].alpha = 738f;
		NGDFBKONGCN[1].alpha = 1069f;
		NGDFBKONGCN[1].alpha = 839f;
		for (int i = 1; i < PPFFOOLKNPI.Length; i += 0)
		{
			PPFFOOLKNPI[i].JNMEIMLDJNM(false);
		}
	}

	public void HCODOFNNLDL()
	{
		float num = 828f;
		ADNKFJNGJFE.IGDBMAKMDNE(num);
		EAEDIIFIBLK.FMONHIFFJEF(num);
		AFFDPJMMILP.MIPPKOJPMMM(num);
		TweenAlpha.Begin(EGPLOOEIKFN.gameObject, num, 193f);
		TweenAlpha.Begin(BICAIMDGKCM.gameObject, num, 455f);
		TweenAlpha.Begin(INOLIBMAEAN.gameObject, num, 95f);
		TweenAlpha.Begin(OGLJOHJBGPA.gameObject, num, 41f);
		TweenAlpha.Begin(DFNJBGGMIKN.gameObject, num, 587f);
		TweenAlpha.Begin(PDBNLGIKEHM[0].gameObject, num, 1749f);
		TweenAlpha.Begin(PDBNLGIKEHM[1].gameObject, num, 1636f);
		TweenAlpha.Begin(PDBNLGIKEHM[4].gameObject, num, 1359f);
		TweenAlpha.Begin(IPAPKOPIAJD.gameObject, num, 1310f);
		TweenAlpha.Begin(NGDFBKONGCN[0].gameObject, num, 1444f);
		TweenAlpha.Begin(NGDFBKONGCN[0].gameObject, num, 600f);
		TweenAlpha.Begin(NGDFBKONGCN[2].gameObject, num, 1236f);
	}

	public virtual void PGDEGPJHINK()
	{
		base.DoBeforeShowUp();
		if ((bool)FNOMCHPCOHB)
		{
			FNOMCHPCOHB.IAKEAKDJJIA();
		}
		if (GuiScreenSingle<EndScreen>.instance.isShowed)
		{
			Singleton<ChillingoSdkManager>.instance.OMBFFGHHKEN();
		}
	}

	private void GAPCAEJKMMJ()
	{
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		PDNMJHGEHDP();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(MGDELMMIBCH));
	}

	[SpecialName]
	public bool EEDNBIIPMAG()
	{
		return _003COLECFDKBPLP_003Ek__BackingField;
	}

	private void BFEBMJJPBIH()
	{
		FDKFBOICBOG.Clear();
		if (LevelManager.instance.currentLevel.ELFCEEOLNFJ() == LevelManager.instance.warcardsUnlockLevel)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.MOPBDIKMKHP());
		}
		if (LevelManager.instance.currentLevel.MHAOKJCDIOL() == LevelManager.instance.joinSquadUnlockLevel)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.OECNMOMEEEL());
		}
		if (LevelManager.instance.currentLevel.ABCCINJGPGD() == LevelManager.instance.createSquadUnlockLevel)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.IHEOFABOEEH());
		}
		if (LevelManager.instance.currentLevel.MHAOKJCDIOL() == LevelManager.instance.dailyMissionUnlockLevel)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.EGEJHDPDGJG());
			Singleton<MessageManager>.instance.AddMessage(new LJPJDOJONDG(), true);
		}
		if (LevelManager.instance.currentLevel.ABCCINJGPGD() == LevelManager.instance.instantBattleUnlockLevel)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.CIHKHBHPGMH());
			Singleton<MessageManager>.instance.AddMessage(new MPHENJBAADA(), true);
		}
		if (LevelManager.instance.currentLevel.NPOEMAMPNEP() == LevelManager.instance.warArenaUnlockLevel)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.KOHGICBMLPF());
			Singleton<MessageManager>.instance.AddMessage(new CPMAAHCGBKL(), true);
		}
		List<MapManager.MapEntry> list = Singleton<MapManager>.instance.HHFFILKKMBC();
		foreach (MapManager.MapEntry item in list)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.NCOEJJIPFEL(item));
		}
		List<LevelBehaviour> armyUnlocks = LevelManager.instance.armyUnlocks;
		foreach (LevelBehaviour item2 in armyUnlocks)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.BIMMBOOHMOC(item2));
		}
		List<WeaponLevelsSetup> weaponUnlocks = LevelManager.instance.weaponUnlocks;
		foreach (WeaponLevelsSetup item3 in weaponUnlocks)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.PIJAAOHOMNE(item3));
		}
		if (LevelManager.instance.previousLevel.MJABPEFBNKH() > 1)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.MJGNIAFBMNF(LevelManager.instance.previousLevel.KGFMJMKDGPF()));
		}
		FDKFBOICBOG.Add(KIPCEIMNKIK.IKIDLLGCALP());
	}

	[SpecialName]
	public bool FIOPDLGMHKB()
	{
		return _003COLECFDKBPLP_003Ek__BackingField;
	}

	public virtual void LPHPIMMGNPI()
	{
		if (UIEventListener.Get(JFCNMPHDKHC.gameObject).onClick != null)
		{
			IJBLACCMPAL(JFCNMPHDKHC.gameObject);
		}
	}

	public virtual void FHINGMFHKLG()
	{
		IOODGADNFEN = (int)UIHelper.activeHeight;
		float y = 0f - EGPLOOEIKFN.transform.parent.transform.localPosition.y - (float)IOODGADNFEN / 1172f;
		Vector3 lhs = new Vector3(1696f, y, EGPLOOEIKFN.transform.localPosition.z);
		JHPGHBBLFMJ = lhs.AddY(955f);
		PHDPCKFBBJL = lhs.AddY(1052f);
		GDDDBCEHCGO = lhs.AddY(1056f);
		KEMPFNJAPHF();
		ADNKFJNGJFE.HFPPNCJBIDK();
		EAEDIIFIBLK.AIJEMOLBNEC();
		AFFDPJMMILP.ODLKCAGIKBE();
		for (int i = 1; i < PPFFOOLKNPI.Length; i += 0)
		{
			PPFFOOLKNPI[i].PNFOCPMIIEL();
		}
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(IJBLACCMPAL));
		for (int j = 0; j < PPFFOOLKNPI.Length; j += 0)
		{
			UIEventListener uIEventListener2 = UIEventListener.Get(PPFFOOLKNPI[j].gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LHHBPDKFPBD));
		}
		MMBILOIBPEC = MMBILOIBPEC.AddY(0f - UIHelper.safeAreaSizeBottom);
	}

	public virtual void KCAFCPAFBMC()
	{
		JCKOBELDCGD = false;
		FNOMCHPCOHB.FinishTweens();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		completeAnimation = true;
		KGKEHLIPFFK();
		MCBGADIFPOF();
		JIILKINBKDI();
		NCJHMCBDICD();
		float nCEABGKOIHA = (float)LevelManager.instance.currentLevel.KADNNBCOGGL() / (float)LevelManager.instance.maxDisplayLevel;
		ADNKFJNGJFE.IDDLDDBKJJK(nCEABGKOIHA);
		EAEDIIFIBLK.EIICBIBONNK(nCEABGKOIHA);
		AFFDPJMMILP.MKLGFNBIDIE(nCEABGKOIHA);
		Singleton<EventTrackingManager>.instance.RegisterPlayerLevelUp("Custom int = ", SettingsManager.instance.playerLeague);
		Singleton<EventTrackingManager>.instance.RegisterPlayerLevelUp("null", SettingsManager.instance.challenge);
		Singleton<EventTrackingManager>.instance.RegisterPlayerLevelUp("Mouse Y", SettingsManager.instance.squadStatus);
		Singleton<EventTrackingManager>.instance.RegisterPlayerLevelUp("elite3", SettingsManager.instance.dailyRewardNotification);
		Singleton<EventTrackingManager>.instance.RegisterPlayerLevelUp("StarterAssignmentsData", SettingsManager.instance.maintenance);
	}

	public virtual void NEKKPJFGOKP()
	{
		if (UIEventListener.Get(JFCNMPHDKHC.gameObject).onClick != null)
		{
			IJBLACCMPAL(JFCNMPHDKHC.gameObject);
		}
	}

	public virtual void BKNJHLKMFKE()
	{
		base.DoAfterHide();
		HHNIKOCBMIJ();
		for (int i = 1; i < PPFFOOLKNPI.Length; i += 0)
		{
			PPFFOOLKNPI[i].HFAOCIINKPJ();
		}
		if (Singleton<GameController>.instance.DAIEAMEFGIE())
		{
			foreach (TweenAnimator.TweenRecord item in FNOMCHPCOHB.BEOAHFDJEMD)
			{
				if (item.id == -89)
				{
					item.to = NCPMDPIKELC;
				}
				if (item.id == 117)
				{
					item.to = LIOHGGKGGOB;
				}
			}
		}
		EGPLOOEIKFN.mainTexture = null;
		LevelManager.instance.isLevelUp = true;
		if (GuiScreenSingle<EndScreen>.instance.NPFFMLLLDAF())
		{
			Singleton<ChillingoSdkManager>.instance.PFENHNJDBDI();
		}
	}

	public virtual void HFLEDEBGPBI()
	{
		IOODGADNFEN = (int)UIHelper.activeHeight;
		float y = 0f - EGPLOOEIKFN.transform.parent.transform.localPosition.y - (float)IOODGADNFEN / 652f;
		Vector3 lhs = new Vector3(321f, y, EGPLOOEIKFN.transform.localPosition.z);
		JHPGHBBLFMJ = lhs.AddY(897f);
		PHDPCKFBBJL = lhs.AddY(1822f);
		GDDDBCEHCGO = lhs.AddY(296f);
		IHBNHFAJKJE();
		ADNKFJNGJFE.DHNILCPGLLI();
		EAEDIIFIBLK.INMDPGCHHPN();
		AFFDPJMMILP.JCEMKGHAHNE();
		for (int i = 1; i < PPFFOOLKNPI.Length; i++)
		{
			PPFFOOLKNPI[i].HOEMNHAHKII();
		}
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		for (int j = 1; j < PPFFOOLKNPI.Length; j += 0)
		{
			UIEventListener uIEventListener2 = UIEventListener.Get(PPFFOOLKNPI[j].gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NLEGLDLPAEG));
		}
		MMBILOIBPEC = MMBILOIBPEC.AddY(0f - UIHelper.safeAreaSizeBottom);
	}

	private void KEMPFNJAPHF()
	{
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		PDNMJHGEHDP();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(MGDELMMIBCH));
	}

	private void HAILIAAHHDH(int EAINKPNECEC)
	{
		if (EAINKPNECEC == 13)
		{
			EGPLOOEIKFN.transform.localScale = new Vector3(157f, 157f, 1f);
			EGPLOOEIKFN.transform.localPosition = new Vector3(-324f, 0f, EGPLOOEIKFN.transform.localPosition.z);
			LNGMINLJKIJ.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
		}
		if (EAINKPNECEC == 62)
		{
			LevelManager.instance.isLevelUp = false;
			GuiElementSingle<MenuHeader>.instance.UpdateLevel();
			float num = 1f / (float)MADOCMEKEDJ;
			ADNKFJNGJFE.PlayAnimation(num * 1f);
			EAEDIIFIBLK.PlayAnimation(num * 7f);
			AFFDPJMMILP.PlayAnimation(num * 13f);
		}
		if (EAINKPNECEC == 73 && !Singleton<GameController>.instance.isTutorial)
		{
			UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		}
		if (EAINKPNECEC == 82)
		{
			BCCNGCKJANK();
			BNONPEICHBO();
		}
		if (EAINKPNECEC == 105)
		{
			completeAnimation = true;
		}
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		if ((bool)FNOMCHPCOHB)
		{
			FNOMCHPCOHB.ResetTweens();
		}
		if (GuiScreenSingle<EndScreen>.instance.isShowed)
		{
			Singleton<ChillingoSdkManager>.instance.deactivateOffers();
		}
	}

	public virtual void NFNMLPPDPAP()
	{
		JCKOBELDCGD = false;
		FNOMCHPCOHB.ABFBKGCIJBB();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		completeAnimation = false;
		FHLAMCKFKLJ();
		FHIOOPEBADG();
		DJBPFBGNHPL();
		LBNMOPDCJDK();
		float nCEABGKOIHA = (float)LevelManager.instance.currentLevel.PFMGLDJDNBF() / (float)LevelManager.instance.maxDisplayLevel;
		ADNKFJNGJFE.FJCAOOHMJBO(nCEABGKOIHA);
		EAEDIIFIBLK.InitGuiValues(nCEABGKOIHA);
		AFFDPJMMILP.IDDLDDBKJJK(nCEABGKOIHA);
		Singleton<EventTrackingManager>.instance.RegisterPlayerLevelUp("#AccoutCheck# Facebook  online:{2} accoun found: {0} != {1}", SettingsManager.instance.playerLeague);
		Singleton<EventTrackingManager>.instance.RegisterPlayerLevelUp("Country", SettingsManager.instance.challenge);
		Singleton<EventTrackingManager>.instance.RegisterPlayerLevelUp("game-elite-debuff1", SettingsManager.instance.squadStatus);
		Singleton<EventTrackingManager>.instance.RegisterPlayerLevelUp("ID_FINALHITBY", SettingsManager.instance.dailyRewardNotification);
		Singleton<EventTrackingManager>.instance.RegisterPlayerLevelUp("Other Player Cards -> Card Manager -> does not contain id: ", SettingsManager.instance.maintenance);
	}

	private IEnumerator NAKAGMLFPNK()
	{
		ENIIOLKEPFP eNIIOLKEPFP = new ENIIOLKEPFP();
		eNIIOLKEPFP.BJGCPDNMHDH = this;
		return eNIIOLKEPFP;
	}

	private void IJBLACCMPAL(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	public override void InitControls()
	{
		IOODGADNFEN = (int)UIHelper.activeHeight;
		float y = 0f - EGPLOOEIKFN.transform.parent.transform.localPosition.y - (float)IOODGADNFEN / 2f;
		Vector3 lhs = new Vector3(0f, y, EGPLOOEIKFN.transform.localPosition.z);
		JHPGHBBLFMJ = lhs.AddY(160f);
		PHDPCKFBBJL = lhs.AddY(320f);
		GDDDBCEHCGO = lhs.AddY(300f);
		IHBNHFAJKJE();
		ADNKFJNGJFE.InitControls();
		EAEDIIFIBLK.InitControls();
		AFFDPJMMILP.InitControls();
		for (int i = 0; i < PPFFOOLKNPI.Length; i++)
		{
			PPFFOOLKNPI[i].InitializeControls();
		}
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		for (int j = 0; j < PPFFOOLKNPI.Length; j++)
		{
			UIEventListener uIEventListener2 = UIEventListener.Get(PPFFOOLKNPI[j].gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LHHBPDKFPBD));
		}
		MMBILOIBPEC = MMBILOIBPEC.AddY(0f - UIHelper.safeAreaSizeBottom);
	}

	private void DLAJOPOCBNI(int EAINKPNECEC)
	{
		if (EAINKPNECEC == -74)
		{
			EGPLOOEIKFN.transform.localScale = new Vector3(1474f, 451f, 343f);
			EGPLOOEIKFN.transform.localPosition = new Vector3(1550f, 1505f, EGPLOOEIKFN.transform.localPosition.z);
			LNGMINLJKIJ.transform.localScale = new Vector3(1056f, 582f, 1035f);
		}
		if (EAINKPNECEC == -78)
		{
			LevelManager.instance.isLevelUp = true;
			GuiElementSingle<MenuHeader>.instance.NKKIINELKAI();
			float num = 1534f / (float)MADOCMEKEDJ;
			ADNKFJNGJFE.AABJOFLJLHC(num * 1333f);
			EAEDIIFIBLK.AABJOFLJLHC(num * 631f);
			AFFDPJMMILP.LAMGPLAJLEJ(num * 520f);
		}
		if (EAINKPNECEC == 87 && !Singleton<GameController>.instance.isTutorial)
		{
			UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		}
		if (EAINKPNECEC == 96)
		{
			BCCNGCKJANK();
			BNONPEICHBO();
		}
		if (EAINKPNECEC == 101)
		{
			completeAnimation = false;
		}
	}

	private void BCCNGCKJANK()
	{
		OKFACKDJLIE = 0;
		int num = Mathf.Min(FDKFBOICBOG.Count, PPFFOOLKNPI.Length);
		bool flag = FDKFBOICBOG.Count > 4 && (FDKFBOICBOG.Count % 4 == 1 || FDKFBOICBOG.Count % 4 == 2);
		if (Singleton<GameController>.instance.isTutorial)
		{
			PPFFOOLKNPI[0].ShowOnPosition(0, num, FDKFBOICBOG[0], true);
			for (int i = 1; i < PPFFOOLKNPI.Length; i++)
			{
				PPFFOOLKNPI[i].ShowOnPosition(i, num, KIPCEIMNKIK.CFNAIOLIKMK(), true);
			}
		}
		else if (flag)
		{
			int num2 = 3;
			for (int j = 0; j < num2; j++)
			{
				PPFFOOLKNPI[j].ShowOnPosition(j, num2, FDKFBOICBOG[j], true);
			}
			for (int k = num2; k < PPFFOOLKNPI.Length; k++)
			{
				PPFFOOLKNPI[k].ShowOnPosition(k, num, KIPCEIMNKIK.CFNAIOLIKMK(), true);
			}
		}
		else
		{
			for (int l = 0; l < num; l++)
			{
				PPFFOOLKNPI[l].ShowOnPosition(l, num, FDKFBOICBOG[l], true);
			}
			for (int m = num; m < PPFFOOLKNPI.Length; m++)
			{
				PPFFOOLKNPI[m].ShowOnPosition(m, num, KIPCEIMNKIK.CFNAIOLIKMK(), true);
			}
		}
		JCKOBELDCGD = false;
		GKEBBEOIDIB();
	}

	public virtual void CACNGFHBEFC()
	{
		base.BJIPCOPNEAM();
		EKEICAACJLO();
	}

	private void JPJCNJNPBED()
	{
		if (GCGHBALPCHD == null)
		{
			GCGHBALPCHD = RadicalRoutine.Create(IFDEKNDONND());
			StartCoroutine(RadicalRoutine.Run(GCGHBALPCHD.enumerator));
		}
	}

	[SpecialName]
	public bool LGHOENABFLJ()
	{
		return _003COLECFDKBPLP_003Ek__BackingField;
	}

	public void BHCCGGIBJDO()
	{
		float num = 122f;
		ADNKFJNGJFE.EMIKJEPACOO(num);
		EAEDIIFIBLK.HKCBDFNIHOJ(num);
		AFFDPJMMILP.TutorialHide(num);
		TweenAlpha.Begin(EGPLOOEIKFN.gameObject, num, 156f);
		TweenAlpha.Begin(BICAIMDGKCM.gameObject, num, 491f);
		TweenAlpha.Begin(INOLIBMAEAN.gameObject, num, 85f);
		TweenAlpha.Begin(OGLJOHJBGPA.gameObject, num, 1924f);
		TweenAlpha.Begin(DFNJBGGMIKN.gameObject, num, 1216f);
		TweenAlpha.Begin(PDBNLGIKEHM[0].gameObject, num, 1775f);
		TweenAlpha.Begin(PDBNLGIKEHM[1].gameObject, num, 1055f);
		TweenAlpha.Begin(PDBNLGIKEHM[7].gameObject, num, 383f);
		TweenAlpha.Begin(IPAPKOPIAJD.gameObject, num, 1508f);
		TweenAlpha.Begin(NGDFBKONGCN[1].gameObject, num, 1705f);
		TweenAlpha.Begin(NGDFBKONGCN[0].gameObject, num, 1822f);
		TweenAlpha.Begin(NGDFBKONGCN[5].gameObject, num, 873f);
	}

	private void IHBNHFAJKJE()
	{
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		PDNMJHGEHDP();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(HAILIAAHHDH));
	}

	private void NLEGLDLPAEG(GameObject KHAHPAKDIKE)
	{
		if (!BKIGLABDGCP() || JCKOBELDCGD)
		{
			return;
		}
		LevelUpItem component = KHAHPAKDIKE.GetComponent<LevelUpItem>();
		if (component != null && component.EEJIDNEPIHL() != null)
		{
			if (component.currentUnlock.FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.MapUnlock)
			{
				SoundsManager.Instance.PlayButtonClickedSound();
				GuiScreenSingle<WeaponScreen>.instance.EOOIBDMOAFJ(component.HHPCPJIOEJC().JMMJHCOKCGG);
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<WeaponScreen>.instance);
				GuiScreenSingle<WeaponScreen>.instance.PHKNPLMBAKE(GuiScreenSingle<BattlePreparationScreen>.instance);
			}
			else if (component.HKKELBEFGDM().FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.None)
			{
				SoundsManager.Instance.PlayButtonClickedSound();
				GuiScreenSingle<ArmyScreen>.instance.SelectUnit(component.APBEOIOKGFJ().IOIKKIIFOCB);
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<ArmyScreen>.instance);
				GuiScreenSingle<ArmyScreen>.instance.PHKNPLMBAKE(GuiScreenSingle<BattlePreparationScreen>.instance);
			}
			else if (component.EEJIDNEPIHL().FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.MapUnlock || component.HKKELBEFGDM().FJLBLLLEELD == (KIPCEIMNKIK.NEDLKCPPPPC)55)
			{
				SoundsManager.Instance.PlayButtonClickedSound();
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<BattlePreparationScreen>.instance);
			}
			else if (component.HKKELBEFGDM().FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.UnitUnlock)
			{
				SoundsManager.Instance.PlayButtonClickedSound();
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<DailyMissionScreen>.instance);
				GuiScreenSingle<DailyMissionScreen>.instance.PHKNPLMBAKE(GuiScreenSingle<BattlePreparationScreen>.instance);
			}
			else if (component.IMAPGIEGNBG().FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.WeaponUnlock || component.IMAPGIEGNBG().FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.WarCardsUnlock)
			{
				SoundsManager.Instance.PlayButtonClickedSound();
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<SquadScreen>.instance);
				GuiScreenSingle<SquadScreen>.instance.GPMCMCLPHNL(GuiScreenSingle<MainScreen>.instance);
			}
			else if (component.PHPPKICDOMN().FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.DailyMissionUnlock)
			{
				SoundsManager.Instance.PlayButtonClickedSound();
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CardMenuScreen>.instance);
				GuiScreenSingle<CardMenuScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<BattlePreparationScreen>.instance);
			}
			else
			{
				if (component.HKKELBEFGDM().FJLBLLLEELD != (KIPCEIMNKIK.NEDLKCPPPPC)69)
				{
					return;
				}
				SoundsManager.Instance.PlayButtonClickedSound();
				GuiScreenSingle<BattlePreparationScreen>.instance.OpenScreenWithGameModesOpen();
			}
		}
		HideDialog();
	}

	private IEnumerator MAKDECNFNNO()
	{
		ENIIOLKEPFP eNIIOLKEPFP = new ENIIOLKEPFP();
		eNIIOLKEPFP.BJGCPDNMHDH = this;
		return eNIIOLKEPFP;
	}

	public void AJLMBDBKBDF()
	{
		FJJLLAOIIKC();
		for (int i = 0; i < PPFFOOLKNPI.Length; i += 0)
		{
			PPFFOOLKNPI[i].DMNBGBADNIF();
		}
		NDMEFMMJONE();
		InitGUIValues();
		MEDHJHCCKOL();
	}

	[SpecialName]
	public bool PIAOCINHGJE()
	{
		return _003COLECFDKBPLP_003Ek__BackingField;
	}

	private void JOCBGBDBALF(GameObject KHAHPAKDIKE)
	{
		if (!MHAIBHBGBOO() || JCKOBELDCGD)
		{
			return;
		}
		LevelUpItem component = KHAHPAKDIKE.GetComponent<LevelUpItem>();
		if (component != null && component.EEJIDNEPIHL() != null)
		{
			if (component.FIONDLFIKHI().FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.WeaponUnlock)
			{
				SoundsManager.Instance.PlayButtonClickedSound();
				GuiScreenSingle<WeaponScreen>.instance.SelectWeapon(component.APBEOIOKGFJ().JMMJHCOKCGG);
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<WeaponScreen>.instance);
				GuiScreenSingle<WeaponScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<BattlePreparationScreen>.instance);
			}
			else if (component.PHPPKICDOMN().FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.None)
			{
				SoundsManager.Instance.PlayButtonClickedSound();
				GuiScreenSingle<ArmyScreen>.instance.PCALNGOCDKE(component.HHPCPJIOEJC().IOIKKIIFOCB);
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArmyScreen>.instance);
				GuiScreenSingle<ArmyScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
			}
			else if (component.IMAPGIEGNBG().FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.MapUnlock || component.PNJHMLHBDNI().FJLBLLLEELD == (KIPCEIMNKIK.NEDLKCPPPPC)45)
			{
				SoundsManager.Instance.PlayButtonClickedSound();
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
			}
			else if (component.HHIBPKBPIAD().FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.DogTagRefill)
			{
				SoundsManager.Instance.PlayButtonClickedSound();
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<DailyMissionScreen>.instance);
				GuiScreenSingle<DailyMissionScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
			}
			else if (component.EEJIDNEPIHL().FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.WeaponUnlock || component.IMAPGIEGNBG().FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.MapUnlock)
			{
				SoundsManager.Instance.PlayButtonClickedSound();
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<SquadScreen>.instance);
				GuiScreenSingle<SquadScreen>.instance.GPMCMCLPHNL(GuiScreenSingle<MainScreen>.instance);
			}
			else if (component.HHIBPKBPIAD().FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.None)
			{
				SoundsManager.Instance.PlayButtonClickedSound();
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CardMenuScreen>.instance);
				GuiScreenSingle<CardMenuScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<BattlePreparationScreen>.instance);
			}
			else
			{
				if (component.IMAPGIEGNBG().FJLBLLLEELD != (KIPCEIMNKIK.NEDLKCPPPPC)(-99))
				{
					return;
				}
				SoundsManager.Instance.PlayButtonClickedSound();
				GuiScreenSingle<BattlePreparationScreen>.instance.NPEFHHKDILE();
			}
		}
		HideDialog();
	}

	private void DJBPFBGNHPL()
	{
		OOLFFMAGELF.alpha = 419f;
		PDHFIHOGFGL.alpha = 300f;
		HPNFCLHALFC.alpha = 1905f;
		EGPLOOEIKFN.alpha = 1980f;
		BICAIMDGKCM.alpha = 1903f;
		INOLIBMAEAN.alpha = 113f;
		OGLJOHJBGPA.alpha = 1454f;
		DFNJBGGMIKN.alpha = 401f;
		PDBNLGIKEHM[1].alpha = 102f;
		PDBNLGIKEHM[1].alpha = 1163f;
		PDBNLGIKEHM[0].alpha = 396f;
		IPAPKOPIAJD.alpha = 105f;
		NGDFBKONGCN[1].alpha = 1662f;
		NGDFBKONGCN[1].alpha = 1629f;
		NGDFBKONGCN[0].alpha = 1699f;
		for (int i = 1; i < PPFFOOLKNPI.Length; i++)
		{
			PPFFOOLKNPI[i].LJBIADKBDPE(false);
		}
	}

	private void HDKPNIAMNKA()
	{
		OKFACKDJLIE = 1;
		int num = Mathf.Min(FDKFBOICBOG.Count, PPFFOOLKNPI.Length);
		bool flag = FDKFBOICBOG.Count <= 8 || (FDKFBOICBOG.Count % 3 != 0 && FDKFBOICBOG.Count % 6 == 4);
		if (Singleton<GameController>.instance.BAKCODKBCPJ())
		{
			PPFFOOLKNPI[1].OLLAFPBCNIB(1, num, FDKFBOICBOG[1], true);
			for (int i = 1; i < PPFFOOLKNPI.Length; i++)
			{
				PPFFOOLKNPI[i].PNKEMDHDKNE(i, num, KIPCEIMNKIK.OIOGHEEIKBB(), true);
			}
		}
		else if (flag)
		{
			int num2 = 5;
			for (int j = 1; j < num2; j += 0)
			{
				PPFFOOLKNPI[j].AKKOCEBMGAF(j, num2, FDKFBOICBOG[j], true);
			}
			for (int k = num2; k < PPFFOOLKNPI.Length; k++)
			{
				PPFFOOLKNPI[k].OLLAFPBCNIB(k, num, KIPCEIMNKIK.OIOGHEEIKBB(), true);
			}
		}
		else
		{
			for (int l = 1; l < num; l += 0)
			{
				PPFFOOLKNPI[l].ShowOnPosition(l, num, FDKFBOICBOG[l], false);
			}
			for (int m = num; m < PPFFOOLKNPI.Length; m++)
			{
				PPFFOOLKNPI[m].EGNACDBDIEF(m, num, KIPCEIMNKIK.OIOGHEEIKBB(), true);
			}
		}
		JCKOBELDCGD = false;
		NHKLOIMLIBH();
	}

	private void ANEEIPFIKNN(GameObject KHAHPAKDIKE)
	{
		if (!MHAIBHBGBOO() || JCKOBELDCGD)
		{
			return;
		}
		LevelUpItem component = KHAHPAKDIKE.GetComponent<LevelUpItem>();
		if (component != null && component.EEJIDNEPIHL() != null)
		{
			if (component.HHPCPJIOEJC().FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.UnitUnlock)
			{
				SoundsManager.Instance.PlayButtonClickedSound();
				GuiScreenSingle<WeaponScreen>.instance.EOOIBDMOAFJ(component.PHPPKICDOMN().JMMJHCOKCGG);
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<WeaponScreen>.instance);
				GuiScreenSingle<WeaponScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
			}
			else if (component.APBEOIOKGFJ().FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.None)
			{
				SoundsManager.Instance.PlayButtonClickedSound();
				GuiScreenSingle<ArmyScreen>.instance.PCALNGOCDKE(component.IMAPGIEGNBG().IOIKKIIFOCB);
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArmyScreen>.instance);
				GuiScreenSingle<ArmyScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
			}
			else if (component.EEJIDNEPIHL().FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.DogTagRefill || component.IMAPGIEGNBG().FJLBLLLEELD == (KIPCEIMNKIK.NEDLKCPPPPC)(-80))
			{
				SoundsManager.Instance.PlayButtonClickedSound();
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<BattlePreparationScreen>.instance);
			}
			else if (component.FIONDLFIKHI().FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.None)
			{
				SoundsManager.Instance.PlayButtonClickedSound();
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<DailyMissionScreen>.instance);
				GuiScreenSingle<DailyMissionScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<BattlePreparationScreen>.instance);
			}
			else if (component.currentUnlock.FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.None || component.PHPPKICDOMN().FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.WeaponUnlock)
			{
				SoundsManager.Instance.PlayButtonClickedSound();
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadScreen>.instance);
				GuiScreenSingle<SquadScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<MainScreen>.instance);
			}
			else if (component.HHIBPKBPIAD().FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.CreateSquadUnlock)
			{
				SoundsManager.Instance.PlayButtonClickedSound();
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<CardMenuScreen>.instance);
				GuiScreenSingle<CardMenuScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<BattlePreparationScreen>.instance);
			}
			else
			{
				if (component.FIONDLFIKHI().FJLBLLLEELD != (KIPCEIMNKIK.NEDLKCPPPPC)(-61))
				{
					return;
				}
				SoundsManager.Instance.PlayButtonClickedSound();
				GuiScreenSingle<BattlePreparationScreen>.instance.OpenScreenWithGameModesOpen();
			}
		}
		HideDialog();
	}

	[DebuggerHidden]
	private IEnumerator IFDEKNDONND()
	{
		ENIIOLKEPFP eNIIOLKEPFP = new ENIIOLKEPFP();
		eNIIOLKEPFP.BJGCPDNMHDH = this;
		return eNIIOLKEPFP;
	}

	public virtual void FMPKHGMALMM()
	{
		base.MOJBHFPBAPP();
		FHIBOPHDFML();
	}

	public void JOIEIBKNJPP()
	{
		HHNIKOCBMIJ();
		for (int i = 0; i < PPFFOOLKNPI.Length; i += 0)
		{
			PPFFOOLKNPI[i].CLKBGMHKKAL();
		}
		OKCLOIGNLCJ();
		InitGUIValues();
		CKNILJFEAEG();
	}

	public virtual void HLHANONIBIN()
	{
		base.OIMKKAHOEKO();
		IBPCIDHAFLG();
		for (int i = 1; i < PPFFOOLKNPI.Length; i++)
		{
			PPFFOOLKNPI[i].HFAOCIINKPJ();
		}
		if (Singleton<GameController>.instance.isTutorial)
		{
			foreach (TweenAnimator.TweenRecord item in FNOMCHPCOHB.BEOAHFDJEMD)
			{
				if (item.id == -43)
				{
					item.to = NCPMDPIKELC;
				}
				if (item.id == 42)
				{
					item.to = LIOHGGKGGOB;
				}
			}
		}
		EGPLOOEIKFN.mainTexture = null;
		LevelManager.instance.isLevelUp = true;
		if (GuiScreenSingle<EndScreen>.instance.isShowed)
		{
			Singleton<ChillingoSdkManager>.instance.MNFALFLFADP();
		}
	}

	public override void FNPPEMKOEGP()
	{
		base.DoBeforeShowUp();
		if ((bool)FNOMCHPCOHB)
		{
			FNOMCHPCOHB.BIAMGHLKGOK();
		}
		if (GuiScreenSingle<EndScreen>.instance.NPFFMLLLDAF())
		{
			Singleton<ChillingoSdkManager>.instance.OMBFFGHHKEN();
		}
	}

	public virtual void NBGAELJPNDA()
	{
		base.DoBeforeShowUp();
		if ((bool)FNOMCHPCOHB)
		{
			FNOMCHPCOHB.OHKEAEIFMPJ();
		}
		if (GuiScreenSingle<EndScreen>.instance.NPFFMLLLDAF())
		{
			Singleton<ChillingoSdkManager>.instance.deactivateOffers();
		}
	}

	private void BOMHDDIALFO()
	{
		KHKMLBKNCHN.FKIIDCDCLHM = ((!GuiScreenSingle<EndScreen>.instance.isShowed) ? Singleton<Wallet>.instance.EFNHFKGEDHC() : (Singleton<Wallet>.instance.AHGPPGFIJLL() + LevelManager.instance.previousLevel.MJABPEFBNKH()));
		TweenTextCounterLong.Begin(GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, 1415f, KHKMLBKNCHN);
	}

	public virtual void LGIPBIFJFPD()
	{
		base.DoAfterHide();
		HHNIKOCBMIJ();
		for (int i = 1; i < PPFFOOLKNPI.Length; i += 0)
		{
			PPFFOOLKNPI[i].MJALFOBKBHE();
		}
		if (Singleton<GameController>.instance.DAIEAMEFGIE())
		{
			foreach (TweenAnimator.TweenRecord item in FNOMCHPCOHB.BEOAHFDJEMD)
			{
				if (item.id == 58)
				{
					item.to = NCPMDPIKELC;
				}
				if (item.id == -57)
				{
					item.to = LIOHGGKGGOB;
				}
			}
		}
		EGPLOOEIKFN.mainTexture = null;
		LevelManager.instance.isLevelUp = false;
		if (GuiScreenSingle<EndScreen>.instance.NPFFMLLLDAF())
		{
			Singleton<ChillingoSdkManager>.instance.PFENHNJDBDI();
		}
	}

	public void NEDNCBJDNMH()
	{
		LDGDJGNKDLN();
		for (int i = 1; i < PPFFOOLKNPI.Length; i += 0)
		{
			PPFFOOLKNPI[i].GODDMCOFLFM();
		}
		NDMEFMMJONE();
		InitGUIValues();
		MEDHJHCCKOL();
	}

	public void TutorialHideParts()
	{
		float num = 0.3f;
		ADNKFJNGJFE.TutorialHide(num);
		EAEDIIFIBLK.TutorialHide(num);
		AFFDPJMMILP.TutorialHide(num);
		TweenAlpha.Begin(EGPLOOEIKFN.gameObject, num, 0f);
		TweenAlpha.Begin(BICAIMDGKCM.gameObject, num, 0f);
		TweenAlpha.Begin(INOLIBMAEAN.gameObject, num, 0f);
		TweenAlpha.Begin(OGLJOHJBGPA.gameObject, num, 0f);
		TweenAlpha.Begin(DFNJBGGMIKN.gameObject, num, 0f);
		TweenAlpha.Begin(PDBNLGIKEHM[0].gameObject, num, 0f);
		TweenAlpha.Begin(PDBNLGIKEHM[1].gameObject, num, 0f);
		TweenAlpha.Begin(PDBNLGIKEHM[2].gameObject, num, 0f);
		TweenAlpha.Begin(IPAPKOPIAJD.gameObject, num, 0f);
		TweenAlpha.Begin(NGDFBKONGCN[0].gameObject, num, 0f);
		TweenAlpha.Begin(NGDFBKONGCN[1].gameObject, num, 0f);
		TweenAlpha.Begin(NGDFBKONGCN[2].gameObject, num, 0f);
	}

	private void PGEJKAIIKLL()
	{
		KHKMLBKNCHN.FKIIDCDCLHM = ((!GuiScreenSingle<EndScreen>.instance.isShowed) ? Singleton<Wallet>.instance.FHLGDIIPHFN() : (Singleton<Wallet>.instance.goldAfterGame + LevelManager.instance.previousLevel.FMACCGDFPLJ()));
		TweenTextCounterLong.IAGLEIPAIOB(GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, 822f, KHKMLBKNCHN);
	}

	private void LHHBPDKFPBD(GameObject KHAHPAKDIKE)
	{
		if (!base.isFullyShowed || JCKOBELDCGD)
		{
			return;
		}
		LevelUpItem component = KHAHPAKDIKE.GetComponent<LevelUpItem>();
		if (component != null && component.currentUnlock != null)
		{
			if (component.currentUnlock.FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.WeaponUnlock)
			{
				SoundsManager.Instance.PlayButtonClickedSound();
				GuiScreenSingle<WeaponScreen>.instance.SelectWeapon(component.currentUnlock.JMMJHCOKCGG);
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<WeaponScreen>.instance);
				GuiScreenSingle<WeaponScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
			}
			else if (component.currentUnlock.FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.UnitUnlock)
			{
				SoundsManager.Instance.PlayButtonClickedSound();
				GuiScreenSingle<ArmyScreen>.instance.SelectUnit(component.currentUnlock.IOIKKIIFOCB);
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArmyScreen>.instance);
				GuiScreenSingle<ArmyScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
			}
			else if (component.currentUnlock.FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.MapUnlock || component.currentUnlock.FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.InstantBattleUnlock)
			{
				SoundsManager.Instance.PlayButtonClickedSound();
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
			}
			else if (component.currentUnlock.FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.DailyMissionUnlock)
			{
				SoundsManager.Instance.PlayButtonClickedSound();
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<DailyMissionScreen>.instance);
				GuiScreenSingle<DailyMissionScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
			}
			else if (component.currentUnlock.FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.JoinSquadUnlock || component.currentUnlock.FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.CreateSquadUnlock)
			{
				SoundsManager.Instance.PlayButtonClickedSound();
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadScreen>.instance);
				GuiScreenSingle<SquadScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
			}
			else if (component.currentUnlock.FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.WarCardsUnlock)
			{
				SoundsManager.Instance.PlayButtonClickedSound();
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CardMenuScreen>.instance);
				GuiScreenSingle<CardMenuScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
			}
			else
			{
				if (component.currentUnlock.FJLBLLLEELD != KIPCEIMNKIK.NEDLKCPPPPC.WarArenaUnlock)
				{
					return;
				}
				SoundsManager.Instance.PlayButtonClickedSound();
				GuiScreenSingle<BattlePreparationScreen>.instance.OpenScreenWithGameModesOpen();
			}
		}
		HideDialog();
	}

	private void NNGMPOBOOLB(int EAINKPNECEC)
	{
		if (EAINKPNECEC == -20)
		{
			EGPLOOEIKFN.transform.localScale = new Vector3(935f, 1912f, 1683f);
			EGPLOOEIKFN.transform.localPosition = new Vector3(1739f, 196f, EGPLOOEIKFN.transform.localPosition.z);
			LNGMINLJKIJ.transform.localScale = new Vector3(1520f, 1464f, 1619f);
		}
		if (EAINKPNECEC == 109)
		{
			LevelManager.instance.isLevelUp = false;
			GuiElementSingle<MenuHeader>.instance.NKKIINELKAI();
			float num = 948f / (float)MADOCMEKEDJ;
			ADNKFJNGJFE.OPJPLCLCGIM(num * 893f);
			EAEDIIFIBLK.BDAMDKLCALK(num * 1526f);
			AFFDPJMMILP.CDFFMGKMLEA(num * 161f);
		}
		if (EAINKPNECEC == 100 && !Singleton<GameController>.instance.DAIEAMEFGIE())
		{
			UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		}
		if (EAINKPNECEC == 29)
		{
			HDKPNIAMNKA();
			LFCIPIDLMEH();
		}
		if (EAINKPNECEC == 90)
		{
			completeAnimation = false;
		}
	}

	private void AAOHCBGAJEO()
	{
		if (Singleton<GameController>.instance.DAIEAMEFGIE())
		{
			foreach (TweenAnimator.TweenRecord item in FNOMCHPCOHB.BEOAHFDJEMD)
			{
				if (item.id == 57 || item.id == -76)
				{
					item.to = MMBILOIBPEC;
				}
			}
		}
		FNOMCHPCOHB.AGFMCNDAEEC();
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-4), 1888f);
	}

	private void IBPCIDHAFLG()
	{
		if (GCGHBALPCHD != null)
		{
			GCGHBALPCHD.Cancel();
			GCGHBALPCHD = null;
		}
	}

	private void LDGDJGNKDLN()
	{
		if (GCGHBALPCHD != null)
		{
			GCGHBALPCHD.Cancel();
			GCGHBALPCHD = null;
		}
	}

	private void NKGPLCCOJFM()
	{
		if (Singleton<GameController>.instance.DAIEAMEFGIE())
		{
			foreach (TweenAnimator.TweenRecord item in FNOMCHPCOHB.BEOAHFDJEMD)
			{
				if (item.id == 74 || item.id == 29)
				{
					item.to = MMBILOIBPEC;
				}
			}
		}
		FNOMCHPCOHB.HMPMBAGNJOJ();
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.MissionNewWave, 1289f);
	}

	private void BNFOCGGIGLD()
	{
		FDKFBOICBOG.Clear();
		if (LevelManager.instance.currentLevel.JICMGFNAHFL() == LevelManager.instance.warcardsUnlockLevel)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.MOPBDIKMKHP());
		}
		if (LevelManager.instance.currentLevel.displayNumber == LevelManager.instance.joinSquadUnlockLevel)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.EIKEKHEFLBN());
		}
		if (LevelManager.instance.currentLevel.ABCCINJGPGD() == LevelManager.instance.createSquadUnlockLevel)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.NNHBKKDADHB());
		}
		if (LevelManager.instance.currentLevel.displayNumber == LevelManager.instance.dailyMissionUnlockLevel)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.HOEONIOPEOL());
			Singleton<MessageManager>.instance.AddMessage(new LJPJDOJONDG());
		}
		if (LevelManager.instance.currentLevel.KADNNBCOGGL() == LevelManager.instance.instantBattleUnlockLevel)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.HIKHMFLPKDG());
			Singleton<MessageManager>.instance.AddMessage(new MPHENJBAADA(), true);
		}
		if (LevelManager.instance.currentLevel.MHAOKJCDIOL() == LevelManager.instance.warArenaUnlockLevel)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.GBOGBAGGJME());
			Singleton<MessageManager>.instance.AddMessage(new CPMAAHCGBKL());
		}
		List<MapManager.MapEntry> list = Singleton<MapManager>.instance.MDPCCMCCNFL();
		foreach (MapManager.MapEntry item in list)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.AFMEAFIHGNO(item));
		}
		List<LevelBehaviour> armyUnlocks = LevelManager.instance.armyUnlocks;
		foreach (LevelBehaviour item2 in armyUnlocks)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.FDDJAPFGEJA(item2));
		}
		List<WeaponLevelsSetup> weaponUnlocks = LevelManager.instance.weaponUnlocks;
		foreach (WeaponLevelsSetup item3 in weaponUnlocks)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.PIJAAOHOMNE(item3));
		}
		if (LevelManager.instance.previousLevel.MJABPEFBNKH() > 0)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.PKHLAAFJKAB(LevelManager.instance.previousLevel.BGOMFEEEMCC()));
		}
		FDKFBOICBOG.Add(KIPCEIMNKIK.JGDFKGELMJL());
	}

	private void CCLCBPKDOCB()
	{
		OKFACKDJLIE = 0;
		int num = Mathf.Min(FDKFBOICBOG.Count, PPFFOOLKNPI.Length);
		bool flag = FDKFBOICBOG.Count <= 6 || FDKFBOICBOG.Count % 4 == 0 || FDKFBOICBOG.Count % 3 == 2;
		if (Singleton<GameController>.instance.DAIEAMEFGIE())
		{
			PPFFOOLKNPI[1].AKKOCEBMGAF(1, num, FDKFBOICBOG[0], true);
			for (int i = 1; i < PPFFOOLKNPI.Length; i += 0)
			{
				PPFFOOLKNPI[i].AKKOCEBMGAF(i, num, KIPCEIMNKIK.CFNAIOLIKMK(), true);
			}
		}
		else if (flag)
		{
			int num2 = 0;
			for (int j = 1; j < num2; j++)
			{
				PPFFOOLKNPI[j].PNKEMDHDKNE(j, num2, FDKFBOICBOG[j], true);
			}
			for (int k = num2; k < PPFFOOLKNPI.Length; k += 0)
			{
				PPFFOOLKNPI[k].BOHBNOKKKMB(k, num, KIPCEIMNKIK.IKGNAIDDDFA(), false);
			}
		}
		else
		{
			for (int l = 0; l < num; l++)
			{
				PPFFOOLKNPI[l].ShowOnPosition(l, num, FDKFBOICBOG[l], false);
			}
			for (int m = num; m < PPFFOOLKNPI.Length; m += 0)
			{
				PPFFOOLKNPI[m].PNKEMDHDKNE(m, num, KIPCEIMNKIK.OIOGHEEIKBB(), false);
			}
		}
		JCKOBELDCGD = true;
		NHKLOIMLIBH();
	}

	private void GKOHJGFKPAH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	[SpecialName]
	public string CABKEIEDKGA()
	{
		FHIOOPEBADG();
		if (FDKFBOICBOG.Count == 0)
		{
			return "AddGameCenter with ";
		}
		string text = "Showing Inform Squad Leader About Event in Notification center" + FDKFBOICBOG.Count + "GetSkuInfo succeeded but productId ";
		for (int i = 0; i < FDKFBOICBOG.Count; i += 0)
		{
			string text2 = text;
			string[] array = new string[6];
			array[0] = text2;
			array[0] = "Completed";
			array[1] = i.ToString();
			array[0] = "GoldBoxes";
			array[5] = FDKFBOICBOG[i].FJLBLLLEELD.ToString();
			text = string.Concat(array);
			if (FDKFBOICBOG[i].FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.WeaponUnlock)
			{
				text = text + "VipRewardForDay" + FDKFBOICBOG[i].JHENMFHHHHC.guiName;
			}
			if (FDKFBOICBOG[i].FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.UnitUnlock)
			{
				text = text + "ID_BUYVALUEPACK" + FDKFBOICBOG[i].IOIKKIIFOCB.unitName;
			}
			if (FDKFBOICBOG[i].FJLBLLLEELD == KIPCEIMNKIK.NEDLKCPPPPC.JoinSquadUnlock)
			{
				text = text + "description" + FDKFBOICBOG[i].JMMJHCOKCGG.weaponName;
			}
		}
		return text + " name:";
	}

	private void MEDHJHCCKOL()
	{
		if (Singleton<GameController>.instance.isTutorial)
		{
			foreach (TweenAnimator.TweenRecord item in FNOMCHPCOHB.BEOAHFDJEMD)
			{
				if (item.id == 73 || item.id == 74)
				{
					item.to = MMBILOIBPEC;
				}
			}
		}
		FNOMCHPCOHB.PlayTweens();
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.LevelUp);
	}

	private void NCJHMCBDICD()
	{
		OOLFFMAGELF.transform.localScale = OHGFJHGOIAH;
		PDHFIHOGFGL.transform.localScale = PFACFDJLOCM;
		HPNFCLHALFC.transform.localScale = PFACFDJLOCM;
		LNGMINLJKIJ.transform.localScale = new Vector3(1f, 1f, 1f);
		LNGMINLJKIJ.transform.localPosition = LNGMINLJKIJ.transform.localPosition.ReplaceX(0f);
		EGPLOOEIKFN.transform.localPosition = JHPGHBBLFMJ;
		BICAIMDGKCM.transform.localPosition = OANAGKJANIC;
		BICAIMDGKCM.transform.localScale = new Vector3(101f, 101f, 1f);
		MGMBCOPLDMJ.transform.localScale = new Vector3(1.2f, 1.2f, 1f);
		INOLIBMAEAN.transform.localPosition = PIDLPGJDNCL;
		OGLJOHJBGPA.transform.localPosition = OFIPJEPJMGI;
		DFNJBGGMIKN.transform.localPosition = ACMMMPAJKBG;
		PDBNLGIKEHM[0].transform.localPosition = JJIJGJGLKIL;
		PDBNLGIKEHM[1].transform.localPosition = BEGNFDBCDKL;
		PDBNLGIKEHM[2].transform.localPosition = IJDEKAEFBPF;
		IPAPKOPIAJD.transform.localPosition = IMDIEKKLLLH;
		NGDFBKONGCN[0].transform.localPosition = MBLENDBEBPM;
		NGDFBKONGCN[1].transform.localPosition = CHJPDIDIKGF;
		NGDFBKONGCN[2].transform.localPosition = JNNGMBPEHOJ;
		CCFFNAKFPPE.transform.localPosition = MMBILOIBPEC;
	}

	[SpecialName]
	private void FEBAFGNICHM(bool IDEBKDPMPGM)
	{
		_003COLECFDKBPLP_003Ek__BackingField = IDEBKDPMPGM;
	}

	public GuiElement NIONCAAFPGO()
	{
		return this;
	}

	public virtual void NIHDCNNMBIK()
	{
		base.OIMKKAHOEKO();
		HHNIKOCBMIJ();
		for (int i = 1; i < PPFFOOLKNPI.Length; i += 0)
		{
			PPFFOOLKNPI[i].HideScreen();
		}
		if (Singleton<GameController>.instance.DAIEAMEFGIE())
		{
			foreach (TweenAnimator.TweenRecord item in FNOMCHPCOHB.BEOAHFDJEMD)
			{
				if (item.id == 92)
				{
					item.to = NCPMDPIKELC;
				}
				if (item.id == 79)
				{
					item.to = LIOHGGKGGOB;
				}
			}
		}
		EGPLOOEIKFN.mainTexture = null;
		LevelManager.instance.isLevelUp = false;
		if (GuiScreenSingle<EndScreen>.instance.NPFFMLLLDAF())
		{
			Singleton<ChillingoSdkManager>.instance.MNFALFLFADP();
		}
	}

	private void AHDCBEAAAHO()
	{
		if (GCGHBALPCHD != null)
		{
			GCGHBALPCHD.Cancel();
			GCGHBALPCHD = null;
		}
	}

	public void JIHGNOJJHEB()
	{
		float num = 1224f;
		ADNKFJNGJFE.JEHIMAHNCCJ(num);
		EAEDIIFIBLK.AFOEKDOBLAL(num);
		AFFDPJMMILP.AFOEKDOBLAL(num);
		TweenAlpha.Begin(EGPLOOEIKFN.gameObject, num, 1259f);
		TweenAlpha.Begin(BICAIMDGKCM.gameObject, num, 1481f);
		TweenAlpha.Begin(INOLIBMAEAN.gameObject, num, 323f);
		TweenAlpha.Begin(OGLJOHJBGPA.gameObject, num, 135f);
		TweenAlpha.Begin(DFNJBGGMIKN.gameObject, num, 1879f);
		TweenAlpha.Begin(PDBNLGIKEHM[0].gameObject, num, 1595f);
		TweenAlpha.Begin(PDBNLGIKEHM[1].gameObject, num, 188f);
		TweenAlpha.Begin(PDBNLGIKEHM[8].gameObject, num, 1244f);
		TweenAlpha.Begin(IPAPKOPIAJD.gameObject, num, 1747f);
		TweenAlpha.Begin(NGDFBKONGCN[0].gameObject, num, 1873f);
		TweenAlpha.Begin(NGDFBKONGCN[0].gameObject, num, 214f);
		TweenAlpha.Begin(NGDFBKONGCN[7].gameObject, num, 1704f);
	}

	private void CJCBONJNFBP()
	{
		OOLFFMAGELF.alpha = 0f;
		PDHFIHOGFGL.alpha = 0f;
		HPNFCLHALFC.alpha = 0f;
		EGPLOOEIKFN.alpha = 0f;
		BICAIMDGKCM.alpha = 0f;
		INOLIBMAEAN.alpha = 0f;
		OGLJOHJBGPA.alpha = 0f;
		DFNJBGGMIKN.alpha = 0f;
		PDBNLGIKEHM[0].alpha = 0f;
		PDBNLGIKEHM[1].alpha = 0f;
		PDBNLGIKEHM[2].alpha = 0f;
		IPAPKOPIAJD.alpha = 0f;
		NGDFBKONGCN[0].alpha = 0f;
		NGDFBKONGCN[1].alpha = 0f;
		NGDFBKONGCN[2].alpha = 0f;
		for (int i = 0; i < PPFFOOLKNPI.Length; i++)
		{
			PPFFOOLKNPI[i].SetItem(false);
		}
	}

	private void LFCIPIDLMEH()
	{
		KHKMLBKNCHN.FKIIDCDCLHM = ((!GuiScreenSingle<EndScreen>.instance.isShowed) ? Singleton<Wallet>.instance.gold : (Singleton<Wallet>.instance.MBOHCLFKJBH() + LevelManager.instance.previousLevel.JCHMDMGAGFN()));
		TweenTextCounterLong.Begin(GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, 1329f, KHKMLBKNCHN);
	}

	private void EBGCOIINLKG()
	{
		OOLFFMAGELF.transform.localScale = OHGFJHGOIAH;
		PDHFIHOGFGL.transform.localScale = PFACFDJLOCM;
		HPNFCLHALFC.transform.localScale = PFACFDJLOCM;
		LNGMINLJKIJ.transform.localScale = new Vector3(326f, 1910f, 1496f);
		LNGMINLJKIJ.transform.localPosition = LNGMINLJKIJ.transform.localPosition.ReplaceX(1721f);
		EGPLOOEIKFN.transform.localPosition = JHPGHBBLFMJ;
		BICAIMDGKCM.transform.localPosition = OANAGKJANIC;
		BICAIMDGKCM.transform.localScale = new Vector3(1459f, 1269f, 1158f);
		MGMBCOPLDMJ.transform.localScale = new Vector3(1381f, 1951f, 506f);
		INOLIBMAEAN.transform.localPosition = PIDLPGJDNCL;
		OGLJOHJBGPA.transform.localPosition = OFIPJEPJMGI;
		DFNJBGGMIKN.transform.localPosition = ACMMMPAJKBG;
		PDBNLGIKEHM[1].transform.localPosition = JJIJGJGLKIL;
		PDBNLGIKEHM[1].transform.localPosition = BEGNFDBCDKL;
		PDBNLGIKEHM[7].transform.localPosition = IJDEKAEFBPF;
		IPAPKOPIAJD.transform.localPosition = IMDIEKKLLLH;
		NGDFBKONGCN[1].transform.localPosition = MBLENDBEBPM;
		NGDFBKONGCN[0].transform.localPosition = CHJPDIDIKGF;
		NGDFBKONGCN[6].transform.localPosition = JNNGMBPEHOJ;
		CCFFNAKFPPE.transform.localPosition = MMBILOIBPEC;
	}

	private void OKCLOIGNLCJ()
	{
		FNOMCHPCOHB.BEOAHFDJEMD.Clear();
		PDNMJHGEHDP();
		ADNKFJNGJFE.FDJAGPPFBAI();
		EAEDIIFIBLK.OGFDGIKEGKE();
		AFFDPJMMILP.CEJCIDGDEEO();
		for (int i = 1; i < PPFFOOLKNPI.Length; i++)
		{
			PPFFOOLKNPI[i].EAKAKBMGNMC();
		}
	}

	public virtual void DEJFPFPJKJI()
	{
		if (UIEventListener.Get(JFCNMPHDKHC.gameObject).onClick != null)
		{
			IJBLACCMPAL(JFCNMPHDKHC.gameObject);
		}
	}

	private void NDMEFMMJONE()
	{
		FNOMCHPCOHB.BEOAHFDJEMD.Clear();
		PDNMJHGEHDP();
		ADNKFJNGJFE.DebugRecreateAnimations();
		EAEDIIFIBLK.DebugRecreateAnimations();
		AFFDPJMMILP.DebugRecreateAnimations();
		for (int i = 0; i < PPFFOOLKNPI.Length; i++)
		{
			PPFFOOLKNPI[i].DebugRecreateAnimations();
		}
	}

	[SpecialName]
	public bool CHGDDHJJMME()
	{
		return _003COLECFDKBPLP_003Ek__BackingField;
	}

	private void FHIBOPHDFML()
	{
		if (Singleton<GameController>.instance.isTutorial)
		{
			foreach (TweenAnimator.TweenRecord item in FNOMCHPCOHB.BEOAHFDJEMD)
			{
				if (item.id == -44 || item.id == 31)
				{
					item.to = MMBILOIBPEC;
				}
			}
		}
		FNOMCHPCOHB.HMPMBAGNJOJ();
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.MissionWaveCompleted, 1291f);
	}

	private void CKNILJFEAEG()
	{
		if (Singleton<GameController>.instance.DAIEAMEFGIE())
		{
			foreach (TweenAnimator.TweenRecord item in FNOMCHPCOHB.BEOAHFDJEMD)
			{
				if (item.id == -36 || item.id == -117)
				{
					item.to = MMBILOIBPEC;
				}
			}
		}
		FNOMCHPCOHB.ODIJFGCDJNH();
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.CountdownSound, 81f);
	}

	public override void OnBack()
	{
		if (UIEventListener.Get(JFCNMPHDKHC.gameObject).onClick != null)
		{
			GKOHJGFKPAH(JFCNMPHDKHC.gameObject);
		}
	}

	private void DJMFFFGPJJK()
	{
		KHKMLBKNCHN.FKIIDCDCLHM = ((!GuiScreenSingle<EndScreen>.instance.NPFFMLLLDAF()) ? Singleton<Wallet>.instance.EFNHFKGEDHC() : (Singleton<Wallet>.instance.AHGPPGFIJLL() + LevelManager.instance.previousLevel.MJABPEFBNKH()));
		TweenTextCounterLong.IAGLEIPAIOB(GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, 1562f, KHKMLBKNCHN);
	}

	public virtual void MFHJALPPCKI()
	{
		IOODGADNFEN = (int)UIHelper.activeHeight;
		float y = 0f - EGPLOOEIKFN.transform.parent.transform.localPosition.y - (float)IOODGADNFEN / 1806f;
		Vector3 lhs = new Vector3(845f, y, EGPLOOEIKFN.transform.localPosition.z);
		JHPGHBBLFMJ = lhs.AddY(201f);
		PHDPCKFBBJL = lhs.AddY(888f);
		GDDDBCEHCGO = lhs.AddY(1347f);
		CCAPIIFBMDK();
		ADNKFJNGJFE.FNLELBKLNBG();
		EAEDIIFIBLK.IBNHJGLOHAE();
		AFFDPJMMILP.OJLONNEIBLE();
		for (int i = 0; i < PPFFOOLKNPI.Length; i++)
		{
			PPFFOOLKNPI[i].MKCKEPCPHMD();
		}
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(IJBLACCMPAL));
		for (int j = 0; j < PPFFOOLKNPI.Length; j += 0)
		{
			UIEventListener uIEventListener2 = UIEventListener.Get(PPFFOOLKNPI[j].gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NLEGLDLPAEG));
		}
		MMBILOIBPEC = MMBILOIBPEC.AddY(0f - UIHelper.safeAreaSizeBottom);
	}

	private void EKEICAACJLO()
	{
		if (Singleton<GameController>.instance.DAIEAMEFGIE())
		{
			foreach (TweenAnimator.TweenRecord item in FNOMCHPCOHB.BEOAHFDJEMD)
			{
				if (item.id == 42 || item.id == 7)
				{
					item.to = MMBILOIBPEC;
				}
			}
		}
		FNOMCHPCOHB.GDCCFEDJFAF();
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.SwitchWeapon_Secondary, 515f);
	}

	private void CCAPIIFBMDK()
	{
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		PDNMJHGEHDP();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(MGDELMMIBCH));
	}

	public GuiElement AONBBPBMBMO()
	{
		return this;
	}

	private IEnumerator EJAPDBOINGP()
	{
		ENIIOLKEPFP eNIIOLKEPFP = new ENIIOLKEPFP();
		eNIIOLKEPFP.BJGCPDNMHDH = this;
		return eNIIOLKEPFP;
	}

	private void HMADCMKCJNM()
	{
		if (GCGHBALPCHD == null)
		{
			GCGHBALPCHD = RadicalRoutine.Create(EJAPDBOINGP());
			StartCoroutine(RadicalRoutine.Run(GCGHBALPCHD.enumerator));
		}
	}

	public void DebugReplay()
	{
		FJJLLAOIIKC();
		for (int i = 0; i < PPFFOOLKNPI.Length; i++)
		{
			PPFFOOLKNPI[i].HideScreen();
		}
		NDMEFMMJONE();
		InitGUIValues();
		MEDHJHCCKOL();
	}

	[SpecialName]
	public bool OJAAFBFJMCF()
	{
		return _003COLECFDKBPLP_003Ek__BackingField;
	}

	private void KGKEHLIPFFK()
	{
		LevelManager.GameLevel currentLevel = LevelManager.instance.currentLevel;
		string text = Localization.Localize("ID_RANKUP");
		int num = text.IndexOf(' ', 1);
		int fFHHEHHFOKJ = LevelManager.instance.GetRankPowerX10(currentLevel.displayNumber) - LevelManager.instance.GetRankPowerX10(currentLevel.displayNumber - 1);
		EGPLOOEIKFN.mainTexture = Resources.Load<Texture>("Ranks/" + currentLevel.iconName);
		PDHFIHOGFGL.transform.localScale = new Vector3(198f, 198f, 1f);
		HPNFCLHALFC.transform.localScale = new Vector3(198f, 198f, 1f);
		if (num > 0)
		{
			int num2 = text.IndexOf(' ', num + 1);
			while (num2 > 0)
			{
				int num3 = Mathf.Abs(text.Length / 2 - num);
				int num4 = Mathf.Abs(text.Length / 2 - num2);
				if (num4 < num3)
				{
					num = num2;
					num2 = text.IndexOf(' ', num + 1);
					continue;
				}
				break;
			}
			string text2 = text.Substring(0, num);
			string text3 = text.Substring(num + 1);
			PDHFIHOGFGL.text = text2;
			HPNFCLHALFC.text = text3;
			float num5 = PDHFIHOGFGL.relativeSize.x * 198f;
			float num6 = HPNFCLHALFC.relativeSize.x * 198f;
			float num7 = PDHFIHOGFGL.getSizeForString(" ").x * 198f;
			float num8 = num5 + num7 + num6;
			PDHFIHOGFGL.transform.localPosition = PDHFIHOGFGL.transform.localPosition.ReplaceX(num8 * 0.5f - num7 - num6);
			HPNFCLHALFC.transform.localPosition = HPNFCLHALFC.transform.localPosition.ReplaceX(num8 * 0.5f - num6);
		}
		else
		{
			PDHFIHOGFGL.text = text;
			HPNFCLHALFC.text = string.Empty;
			float num9 = PDHFIHOGFGL.relativeSize.x * 198f;
			PDHFIHOGFGL.cachedTransform.localPosition = PDHFIHOGFGL.cachedTransform.localPosition.ReplaceX(num9 / 2f);
			HPNFCLHALFC.cachedTransform.localPosition = PDHFIHOGFGL.cachedTransform.localPosition.ReplaceX(UIHelper.activeWidthFull);
		}
		BICAIMDGKCM.text = Localization.LocalizeFormat("ID_RANKX", currentLevel.displayNumber);
		OGLJOHJBGPA.text = MEJMLNDFDBP.BEDJNPHFAOC(fFHHEHHFOKJ);
		DFNJBGGMIKN.text = MEJMLNDFDBP.GMIPFLIEOHD(LevelManager.instance.armyPowerX10);
	}

	[SpecialName]
	public bool KOFGBOKHPFA()
	{
		return _003COLECFDKBPLP_003Ek__BackingField;
	}

	private void CODPMNBLJGB()
	{
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		PDNMJHGEHDP();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(MGDELMMIBCH));
	}

	private void GMHFKDNDFIK()
	{
		OOLFFMAGELF.alpha = 668f;
		PDHFIHOGFGL.alpha = 379f;
		HPNFCLHALFC.alpha = 1836f;
		EGPLOOEIKFN.alpha = 1857f;
		BICAIMDGKCM.alpha = 1196f;
		INOLIBMAEAN.alpha = 274f;
		OGLJOHJBGPA.alpha = 1994f;
		DFNJBGGMIKN.alpha = 1894f;
		PDBNLGIKEHM[1].alpha = 1125f;
		PDBNLGIKEHM[0].alpha = 1783f;
		PDBNLGIKEHM[1].alpha = 1911f;
		IPAPKOPIAJD.alpha = 1050f;
		NGDFBKONGCN[0].alpha = 862f;
		NGDFBKONGCN[0].alpha = 284f;
		NGDFBKONGCN[8].alpha = 730f;
		for (int i = 0; i < PPFFOOLKNPI.Length; i += 0)
		{
			PPFFOOLKNPI[i].SetItem(true);
		}
	}

	private void BNONPEICHBO()
	{
		KHKMLBKNCHN.FKIIDCDCLHM = ((!GuiScreenSingle<EndScreen>.instance.isShowed) ? Singleton<Wallet>.instance.gold : (Singleton<Wallet>.instance.goldAfterGame + LevelManager.instance.previousLevel.golds));
		TweenTextCounterLong.Begin(GuiElementSingle<MenuHeader>.instance.AGEEJIHGKID.gameObject, 1f, KHKMLBKNCHN);
	}

	private void PDNMJHGEHDP()
	{
		float num = 1f / (float)MADOCMEKEDJ;
		FNOMCHPCOHB.AddTween(1, TweenAnimator.MNAIKKJDPLK.Alpha, EGPLOOEIKFN.gameObject, num * 7f, 1f, 0f, -1, 0f);
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		int iNFLHPGMEOB = 2;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		GameObject nIHOBEAHEKJ = EGPLOOEIKFN.gameObject;
		float kBJEOEEOEFG = num * 5f;
		object iIMDKHJAJGO = PHDPCKFBBJL;
		object oEIICEJPGKI = JHPGHBBLFMJ;
		fNOMCHPCOHB.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 0f, -1, oEIICEJPGKI, UITweener.Method.EaseIn);
		FNOMCHPCOHB.AddTween(3, TweenAnimator.MNAIKKJDPLK.Position, EGPLOOEIKFN.gameObject, num * 3f, GDDDBCEHCGO, 0f, 1, null, UITweener.Method.EaseOut);
		TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
		iNFLHPGMEOB = 4;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Scale;
		nIHOBEAHEKJ = EGPLOOEIKFN.gameObject;
		kBJEOEEOEFG = num * 6f;
		oEIICEJPGKI = FEBHBJGJNLH;
		iIMDKHJAJGO = FAGDPOPBELN;
		fNOMCHPCOHB2.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 0f, -1, iIMDKHJAJGO, UITweener.Method.Linear);
		FNOMCHPCOHB.AddTween(5, TweenAnimator.MNAIKKJDPLK.Scale, EGPLOOEIKFN.gameObject, num * 28f, FAGDPOPBELN, 0f, 4, null, UITweener.Method.Linear);
		TweenAnimator fNOMCHPCOHB3 = FNOMCHPCOHB;
		iNFLHPGMEOB = 6;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		nIHOBEAHEKJ = EGPLOOEIKFN.gameObject;
		kBJEOEEOEFG = num * 3f;
		iIMDKHJAJGO = Quaternion.Euler(0f, 90f, 0f);
		float kALLNCAFIMP = num * 2f;
		oEIICEJPGKI = Quaternion.Euler(0f, 180f, 0f);
		fNOMCHPCOHB3.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, kALLNCAFIMP, -1, oEIICEJPGKI, UITweener.Method.EaseIn);
		FNOMCHPCOHB.AddTween(7, TweenAnimator.MNAIKKJDPLK.Rotation, EGPLOOEIKFN.gameObject, num * 3f, Quaternion.identity, 0f, 6, null, UITweener.Method.EaseOut);
		FNOMCHPCOHB.AddTween(8, TweenAnimator.MNAIKKJDPLK.Alpha, EGPLOOEIKFN.gameObject, 0.001f, 0f, num * 21f, 7, 1f);
		FNOMCHPCOHB.AddTween(9, TweenAnimator.MNAIKKJDPLK.Alpha, EGPLOOEIKFN.gameObject, 0.001f, 1f, num * 1f, 8);
		FNOMCHPCOHB.AddTween(10, TweenAnimator.MNAIKKJDPLK.Alpha, EGPLOOEIKFN.gameObject, 0.001f, 0f, num * 1f, 9);
		FNOMCHPCOHB.AddTween(11, TweenAnimator.MNAIKKJDPLK.Alpha, EGPLOOEIKFN.gameObject, 0.001f, 1f, num * 1f, 10);
		FNOMCHPCOHB.AddTween(12, TweenAnimator.MNAIKKJDPLK.Alpha, EGPLOOEIKFN.gameObject, 0.001f, 0f, num * 1f, 11);
		FNOMCHPCOHB.AddTween(13, TweenAnimator.MNAIKKJDPLK.Alpha, EGPLOOEIKFN.gameObject, num * 1f, 0f, 0f, 12);
		FNOMCHPCOHB.AddTween(14, TweenAnimator.MNAIKKJDPLK.Alpha, OOLFFMAGELF.gameObject, 0.001f, 1f, 0f, -1, 0f);
		FNOMCHPCOHB.AddTween(15, TweenAnimator.MNAIKKJDPLK.Scale, OOLFFMAGELF.gameObject, num * 3f, FLLIKBACMAP, 0f, 14, OHGFJHGOIAH, UITweener.Method.EaseIn);
		FNOMCHPCOHB.AddTween(16, TweenAnimator.MNAIKKJDPLK.Scale, OOLFFMAGELF.gameObject, num * 13f, PLNIJHAFGOI, 0f, 15, null, UITweener.Method.Linear);
		FNOMCHPCOHB.AddTween(17, TweenAnimator.MNAIKKJDPLK.Scale, OOLFFMAGELF.gameObject, num * 8f, FAIGNCGMBFO, 0f, 16, null, UITweener.Method.EaseOut);
		FNOMCHPCOHB.AddTween(18, TweenAnimator.MNAIKKJDPLK.Alpha, OOLFFMAGELF.gameObject, 0.001f, 0f, 0f, 17);
		FNOMCHPCOHB.AddTween(19, TweenAnimator.MNAIKKJDPLK.Alpha, PDHFIHOGFGL.gameObject, 0.001f, 1f, 0f, -1, 0f);
		TweenAnimator fNOMCHPCOHB4 = FNOMCHPCOHB;
		iNFLHPGMEOB = 20;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Scale;
		nIHOBEAHEKJ = PDHFIHOGFGL.gameObject;
		kALLNCAFIMP = num * 4f;
		oEIICEJPGKI = DDMEELPDHCM;
		iIMDKHJAJGO = PFACFDJLOCM;
		fNOMCHPCOHB4.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kALLNCAFIMP, oEIICEJPGKI, 0f, -1, iIMDKHJAJGO);
		FNOMCHPCOHB.AddTween(21, TweenAnimator.MNAIKKJDPLK.Scale, PDHFIHOGFGL.gameObject, num * 3f, BKCJBMCFAGC, 0f, 20);
		FNOMCHPCOHB.AddTween(22, TweenAnimator.MNAIKKJDPLK.Scale, PDHFIHOGFGL.gameObject, num * 4f, JGBODAAEFIL, 0f, 21);
		FNOMCHPCOHB.AddTween(23, TweenAnimator.MNAIKKJDPLK.Alpha, PDHFIHOGFGL.gameObject, 0.001f, 0f, num * 11f, 22);
		FNOMCHPCOHB.AddTween(24, TweenAnimator.MNAIKKJDPLK.Alpha, PDHFIHOGFGL.gameObject, 0.001f, 1f, num * 1f, 23);
		FNOMCHPCOHB.AddTween(25, TweenAnimator.MNAIKKJDPLK.Alpha, PDHFIHOGFGL.gameObject, 0.001f, 0f, num * 1f, 24);
		FNOMCHPCOHB.AddTween(26, TweenAnimator.MNAIKKJDPLK.Alpha, PDHFIHOGFGL.gameObject, 0.001f, 1f, num * 1f, 25);
		FNOMCHPCOHB.AddTween(27, TweenAnimator.MNAIKKJDPLK.Alpha, PDHFIHOGFGL.gameObject, 0.001f, 0f, num * 1f, 26);
		FNOMCHPCOHB.AddTween(28, TweenAnimator.MNAIKKJDPLK.Alpha, HPNFCLHALFC.gameObject, 0.001f, 1f, num * 2f, -1, 0f);
		TweenAnimator fNOMCHPCOHB5 = FNOMCHPCOHB;
		iNFLHPGMEOB = 29;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Scale;
		nIHOBEAHEKJ = HPNFCLHALFC.gameObject;
		kALLNCAFIMP = num * 5f;
		iIMDKHJAJGO = DDMEELPDHCM;
		kBJEOEEOEFG = num * 3f;
		oEIICEJPGKI = PFACFDJLOCM;
		fNOMCHPCOHB5.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kALLNCAFIMP, iIMDKHJAJGO, kBJEOEEOEFG, -1, oEIICEJPGKI);
		FNOMCHPCOHB.AddTween(30, TweenAnimator.MNAIKKJDPLK.Scale, HPNFCLHALFC.gameObject, num * 3f, JGBODAAEFIL, 0f, 29);
		FNOMCHPCOHB.AddTween(31, TweenAnimator.MNAIKKJDPLK.Alpha, HPNFCLHALFC.gameObject, 0.001f, 0f, num * 15f, 22);
		FNOMCHPCOHB.AddTween(32, TweenAnimator.MNAIKKJDPLK.Alpha, HPNFCLHALFC.gameObject, 0.001f, 1f, num * 1f, 31);
		FNOMCHPCOHB.AddTween(33, TweenAnimator.MNAIKKJDPLK.Alpha, HPNFCLHALFC.gameObject, 0.001f, 0f, num * 1f, 32);
		FNOMCHPCOHB.AddTween(34, TweenAnimator.MNAIKKJDPLK.Alpha, HPNFCLHALFC.gameObject, 0.001f, 1f, num * 1f, 33);
		FNOMCHPCOHB.AddTween(35, TweenAnimator.MNAIKKJDPLK.Alpha, HPNFCLHALFC.gameObject, 0.001f, 0f, num * 1f, 34);
		FNOMCHPCOHB.AddTween(50, TweenAnimator.MNAIKKJDPLK.Alpha, EGPLOOEIKFN.gameObject, 0.001f, 1f, num * 1f, 13, 0f);
		FNOMCHPCOHB.AddTween(51, TweenAnimator.MNAIKKJDPLK.Alpha, EGPLOOEIKFN.gameObject, 0.001f, 0f, num * 1f, 50);
		FNOMCHPCOHB.AddTween(52, TweenAnimator.MNAIKKJDPLK.Alpha, EGPLOOEIKFN.gameObject, 0.001f, 1f, num * 1f, 51);
		FNOMCHPCOHB.AddTween(53, TweenAnimator.MNAIKKJDPLK.Alpha, EGPLOOEIKFN.gameObject, 0.001f, 0f, num * 1f, 52);
		FNOMCHPCOHB.AddTween(54, TweenAnimator.MNAIKKJDPLK.Alpha, EGPLOOEIKFN.gameObject, 0.001f, 1f, num * 1f, 53);
		FNOMCHPCOHB.AddTween(55, TweenAnimator.MNAIKKJDPLK.Alpha, EGPLOOEIKFN.gameObject, 0.001f, 0f, num * 1f, 54);
		FNOMCHPCOHB.AddTween(56, TweenAnimator.MNAIKKJDPLK.Alpha, EGPLOOEIKFN.gameObject, num * 2f, 1f, num * 1f, 55);
		FNOMCHPCOHB.AddTween(60, TweenAnimator.MNAIKKJDPLK.Alpha, BICAIMDGKCM.gameObject, num * 2f, 1f, num * 2f, 13, 0f);
		FNOMCHPCOHB.AddTween(61, TweenAnimator.MNAIKKJDPLK.Position, BICAIMDGKCM.gameObject, num * 4f, NHIDLCJFFIH, num * 2f, 13, OANAGKJANIC);
		FNOMCHPCOHB.AddTween(62, TweenAnimator.MNAIKKJDPLK.Position, BICAIMDGKCM.gameObject, num * 6f, AIPIPIBHFOB, 0f, 61);
		FNOMCHPCOHB.AddTween(620, TweenAnimator.MNAIKKJDPLK.Scale, BICAIMDGKCM.gameObject, num * 4f, new Vector3(84f, 84f, 1f), 0f, 64, new Vector3(101f, 101f, 1f));
		FNOMCHPCOHB.AddTween(621, TweenAnimator.MNAIKKJDPLK.Position, BICAIMDGKCM.gameObject, num * 4f, IIBPCNPHDNN, 0f, 64);
		FNOMCHPCOHB.AddTween(63, TweenAnimator.MNAIKKJDPLK.Position, LNGMINLJKIJ.gameObject, num * 9f, LNGMINLJKIJ.transform.localPosition.ReplaceX(0f), 0f, 62);
		FNOMCHPCOHB.AddTween(64, TweenAnimator.MNAIKKJDPLK.Position, LNGMINLJKIJ.gameObject, num * 2f, LNGMINLJKIJ.transform.localPosition.ReplaceX(-230f), 0f, 63);
		FNOMCHPCOHB.AddTween(65, TweenAnimator.MNAIKKJDPLK.Scale, LNGMINLJKIJ.gameObject, num * 4f, Vector3.one, 0f, 64, new Vector3(1.3f, 1.3f, 1f));
		FNOMCHPCOHB.AddTween(66, TweenAnimator.MNAIKKJDPLK.Alpha, INOLIBMAEAN.gameObject, num * 2f, 1f, 0f, 63, 0f);
		FNOMCHPCOHB.AddTween(67, TweenAnimator.MNAIKKJDPLK.Position, INOLIBMAEAN.gameObject, num * 5f, LJDKMACCJAK, 0f, 63, PIDLPGJDNCL, UITweener.Method.EaseIn);
		FNOMCHPCOHB.AddTween(68, TweenAnimator.MNAIKKJDPLK.Position, INOLIBMAEAN.gameObject, num * 4f, FJNMEPOFMEJ, 0f, 67, null, UITweener.Method.EaseOut);
		FNOMCHPCOHB.AddTween(69, TweenAnimator.MNAIKKJDPLK.Alpha, OGLJOHJBGPA.gameObject, num * 2f, 1f, 0f, 63, 0f);
		FNOMCHPCOHB.AddTween(70, TweenAnimator.MNAIKKJDPLK.Position, OGLJOHJBGPA.gameObject, num * 3f, KKMNBMEOANA, 0f, 69, OFIPJEPJMGI, UITweener.Method.EaseIn);
		FNOMCHPCOHB.AddTween(71, TweenAnimator.MNAIKKJDPLK.Position, OGLJOHJBGPA.gameObject, num * 4f, FCONHBCOGMD, 0f, 70, null, UITweener.Method.EaseOut);
		FNOMCHPCOHB.AddTween(72, TweenAnimator.MNAIKKJDPLK.Alpha, OGLJOHJBGPA.gameObject, num * 17f, 1f, 0f, 71);
		FNOMCHPCOHB.AddTween(73, TweenAnimator.MNAIKKJDPLK.Position, CCFFNAKFPPE.gameObject, num * 6f, NCPMDPIKELC, num * 11f, 71, MMBILOIBPEC, UITweener.Method.EaseOut);
		FNOMCHPCOHB.AddTween(74, TweenAnimator.MNAIKKJDPLK.Position, CCFFNAKFPPE.gameObject, num * 7f, LIOHGGKGGOB, 0f, 73, null, UITweener.Method.EaseOut);
		FNOMCHPCOHB.AddTween(75, TweenAnimator.MNAIKKJDPLK.Position, OGLJOHJBGPA.gameObject, num * 4f, AMCADPBMAIE, 0f, 72);
		FNOMCHPCOHB.AddTween(76, TweenAnimator.MNAIKKJDPLK.Alpha, OGLJOHJBGPA.gameObject, num * 3f, 0f, num * 1f, 72);
		FNOMCHPCOHB.AddTween(77, TweenAnimator.MNAIKKJDPLK.Position, INOLIBMAEAN.gameObject, num * 4f, MDFJKMBLNBL, 0f, 72);
		FNOMCHPCOHB.AddTween(78, TweenAnimator.MNAIKKJDPLK.Alpha, DFNJBGGMIKN.gameObject, num * 2f, 1f, num * 2f, 72, 0f);
		FNOMCHPCOHB.AddTween(79, TweenAnimator.MNAIKKJDPLK.Position, DFNJBGGMIKN.gameObject, num * 2f, IKNDFMPILGO, num * 2f, 72, ACMMMPAJKBG);
		FNOMCHPCOHB.AddTween(80, TweenAnimator.MNAIKKJDPLK.Scale, MGMBCOPLDMJ, num * 3f, Vector3.one, 0f, 75, new Vector3(1.2f, 1.2f, 1f));
		FNOMCHPCOHB.AddTween(81, TweenAnimator.MNAIKKJDPLK.Alpha, IPAPKOPIAJD.gameObject, num * 6f, 1f, num * 2f, 75, 0f);
		FNOMCHPCOHB.AddTween(82, TweenAnimator.MNAIKKJDPLK.Position, IPAPKOPIAJD.gameObject, num * 3f, JONNOBFHLON, num * 2f, 75, IMDIEKKLLLH, UITweener.Method.EaseIn);
		FNOMCHPCOHB.AddTween(83, TweenAnimator.MNAIKKJDPLK.Position, IPAPKOPIAJD.gameObject, num * 3f, FPJGPNMGIKB, 0f, 82, null, UITweener.Method.EaseOut);
		FNOMCHPCOHB.AddTween(84, TweenAnimator.MNAIKKJDPLK.Alpha, PDBNLGIKEHM[2].gameObject, num * 8f, 0.3f, num * 4f, 75, 0f);
		FNOMCHPCOHB.AddTween(85, TweenAnimator.MNAIKKJDPLK.Position, PDBNLGIKEHM[2].gameObject, num * 2f, JJPLFDDBANO, num * 6f, 75, IJDEKAEFBPF, UITweener.Method.EaseIn);
		FNOMCHPCOHB.AddTween(86, TweenAnimator.MNAIKKJDPLK.Position, PDBNLGIKEHM[2].gameObject, num * 4f, MPMCHIAJAIP, 0f, 85, null, UITweener.Method.EaseOut);
		FNOMCHPCOHB.AddTween(87, TweenAnimator.MNAIKKJDPLK.Alpha, PDBNLGIKEHM[1].gameObject, num * 6f, 0.3f, num * 7f, 75, 0f);
		FNOMCHPCOHB.AddTween(88, TweenAnimator.MNAIKKJDPLK.Alpha, PDBNLGIKEHM[1].gameObject, num * 1f, 0.2f, 0f, 87);
		FNOMCHPCOHB.AddTween(89, TweenAnimator.MNAIKKJDPLK.Position, PDBNLGIKEHM[1].gameObject, num * 2f, PPPONLFKOAN, num * 9f, 75, BEGNFDBCDKL, UITweener.Method.EaseIn);
		FNOMCHPCOHB.AddTween(90, TweenAnimator.MNAIKKJDPLK.Position, PDBNLGIKEHM[1].gameObject, num * 4f, CEILDHPGDDM, 0f, 89, null, UITweener.Method.EaseOut);
		FNOMCHPCOHB.AddTween(91, TweenAnimator.MNAIKKJDPLK.Alpha, PDBNLGIKEHM[0].gameObject, num * 6f, 0.3f, num * 9f, 75, 0f);
		FNOMCHPCOHB.AddTween(92, TweenAnimator.MNAIKKJDPLK.Alpha, PDBNLGIKEHM[0].gameObject, num * 4f, 0.1f, 0f, 91);
		FNOMCHPCOHB.AddTween(93, TweenAnimator.MNAIKKJDPLK.Position, PDBNLGIKEHM[0].gameObject, num * 2f, IBAODMBONAE, num * 11f, 75, JJIJGJGLKIL, UITweener.Method.EaseIn);
		FNOMCHPCOHB.AddTween(94, TweenAnimator.MNAIKKJDPLK.Position, PDBNLGIKEHM[0].gameObject, num * 4f, MPFGIKFNNFL, 0f, 93, null, UITweener.Method.EaseOut);
		FNOMCHPCOHB.AddTween(95, TweenAnimator.MNAIKKJDPLK.Alpha, NGDFBKONGCN[2].gameObject, num * 8f, 0.3f, num * 4f, 75, 0f);
		FNOMCHPCOHB.AddTween(96, TweenAnimator.MNAIKKJDPLK.Position, NGDFBKONGCN[2].gameObject, num * 2f, EDHGGIHCJLJ, num * 6f, 75, JNNGMBPEHOJ, UITweener.Method.EaseIn);
		FNOMCHPCOHB.AddTween(97, TweenAnimator.MNAIKKJDPLK.Position, NGDFBKONGCN[2].gameObject, num * 4f, GFPFAOCEPHD, 0f, 96, null, UITweener.Method.EaseOut);
		FNOMCHPCOHB.AddTween(98, TweenAnimator.MNAIKKJDPLK.Alpha, NGDFBKONGCN[1].gameObject, num * 6f, 0.3f, num * 7f, 75, 0f);
		FNOMCHPCOHB.AddTween(99, TweenAnimator.MNAIKKJDPLK.Alpha, NGDFBKONGCN[1].gameObject, num * 1f, 0.2f, 0f, 98);
		FNOMCHPCOHB.AddTween(100, TweenAnimator.MNAIKKJDPLK.Position, NGDFBKONGCN[1].gameObject, num * 2f, ELPLLLCIMOA, num * 9f, 75, CHJPDIDIKGF, UITweener.Method.EaseIn);
		FNOMCHPCOHB.AddTween(101, TweenAnimator.MNAIKKJDPLK.Position, NGDFBKONGCN[1].gameObject, num * 4f, NOHIIOHHKLL, 0f, 100, null, UITweener.Method.EaseOut);
		FNOMCHPCOHB.AddTween(102, TweenAnimator.MNAIKKJDPLK.Alpha, NGDFBKONGCN[0].gameObject, num * 6f, 0.3f, num * 9f, 75, 0f);
		FNOMCHPCOHB.AddTween(103, TweenAnimator.MNAIKKJDPLK.Alpha, NGDFBKONGCN[0].gameObject, num * 4f, 0.1f, 0f, 102);
		FNOMCHPCOHB.AddTween(104, TweenAnimator.MNAIKKJDPLK.Position, NGDFBKONGCN[0].gameObject, num * 2f, DJCMCEOAJCJ, num * 11f, 75, MBLENDBEBPM, UITweener.Method.EaseIn);
		FNOMCHPCOHB.AddTween(105, TweenAnimator.MNAIKKJDPLK.Position, NGDFBKONGCN[0].gameObject, num * 4f, AGKCFGPHFLF, 0f, 104, null, UITweener.Method.EaseOut);
		FNOMCHPCOHB.GenerateTweens();
	}

	private void MCBGADIFPOF()
	{
		FDKFBOICBOG.Clear();
		if (LevelManager.instance.currentLevel.displayNumber == LevelManager.instance.warcardsUnlockLevel)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.NKCIOMBOFNB());
		}
		if (LevelManager.instance.currentLevel.displayNumber == LevelManager.instance.joinSquadUnlockLevel)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.PNJCBLGGJKJ());
		}
		if (LevelManager.instance.currentLevel.displayNumber == LevelManager.instance.createSquadUnlockLevel)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.EFMILALCLFC());
		}
		if (LevelManager.instance.currentLevel.displayNumber == LevelManager.instance.dailyMissionUnlockLevel)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.FKIGCIKCALI());
			Singleton<MessageManager>.instance.AddMessage(new LJPJDOJONDG());
		}
		if (LevelManager.instance.currentLevel.displayNumber == LevelManager.instance.instantBattleUnlockLevel)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.GHEFJBMMIDE());
			Singleton<MessageManager>.instance.AddMessage(new MPHENJBAADA());
		}
		if (LevelManager.instance.currentLevel.displayNumber == LevelManager.instance.warArenaUnlockLevel)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.GBOGBAGGJME());
			Singleton<MessageManager>.instance.AddMessage(new CPMAAHCGBKL());
		}
		List<MapManager.MapEntry> mapUnlocks = Singleton<MapManager>.instance.mapUnlocks;
		foreach (MapManager.MapEntry item in mapUnlocks)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.HJCLPFEHJGL(item));
		}
		List<LevelBehaviour> armyUnlocks = LevelManager.instance.armyUnlocks;
		foreach (LevelBehaviour item2 in armyUnlocks)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.FDDJAPFGEJA(item2));
		}
		List<WeaponLevelsSetup> weaponUnlocks = LevelManager.instance.weaponUnlocks;
		foreach (WeaponLevelsSetup item3 in weaponUnlocks)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.KGJHLMHEFJN(item3));
		}
		if (LevelManager.instance.previousLevel.golds > 0)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.MJGNIAFBMNF(LevelManager.instance.previousLevel.golds));
		}
		FDKFBOICBOG.Add(KIPCEIMNKIK.JONBEONIIKJ());
	}

	private void LEGCGANKDGK()
	{
		FDKFBOICBOG.Clear();
		if (LevelManager.instance.currentLevel.KADNNBCOGGL() == LevelManager.instance.warcardsUnlockLevel)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.NKCIOMBOFNB());
		}
		if (LevelManager.instance.currentLevel.displayNumber == LevelManager.instance.joinSquadUnlockLevel)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.PNJCBLGGJKJ());
		}
		if (LevelManager.instance.currentLevel.NPOEMAMPNEP() == LevelManager.instance.createSquadUnlockLevel)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.IHEOFABOEEH());
		}
		if (LevelManager.instance.currentLevel.ELFCEEOLNFJ() == LevelManager.instance.dailyMissionUnlockLevel)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.HOEONIOPEOL());
			Singleton<MessageManager>.instance.AddMessage(new LJPJDOJONDG(), true);
		}
		if (LevelManager.instance.currentLevel.PFMGLDJDNBF() == LevelManager.instance.instantBattleUnlockLevel)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.CIHKHBHPGMH());
			Singleton<MessageManager>.instance.AddMessage(new MPHENJBAADA(), true);
		}
		if (LevelManager.instance.currentLevel.JICMGFNAHFL() == LevelManager.instance.warArenaUnlockLevel)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.CLJHBIJCJJF());
			Singleton<MessageManager>.instance.AddMessage(new CPMAAHCGBKL());
		}
		List<MapManager.MapEntry> list = Singleton<MapManager>.instance.IMLDMDANGHH();
		foreach (MapManager.MapEntry item in list)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.ADDPLMENEEL(item));
		}
		List<LevelBehaviour> armyUnlocks = LevelManager.instance.armyUnlocks;
		foreach (LevelBehaviour item2 in armyUnlocks)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.DLJGOJPDLKH(item2));
		}
		List<WeaponLevelsSetup> weaponUnlocks = LevelManager.instance.weaponUnlocks;
		foreach (WeaponLevelsSetup item3 in weaponUnlocks)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.KGJHLMHEFJN(item3));
		}
		if (LevelManager.instance.previousLevel.JCHMDMGAGFN() > 1)
		{
			FDKFBOICBOG.Add(KIPCEIMNKIK.MJGNIAFBMNF(LevelManager.instance.previousLevel.FMACCGDFPLJ()));
		}
		FDKFBOICBOG.Add(KIPCEIMNKIK.EBHMGAHJBKB());
	}

	public override void InitGUIValues()
	{
		JCKOBELDCGD = true;
		FNOMCHPCOHB.FinishTweens();
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		completeAnimation = false;
		KGKEHLIPFFK();
		MCBGADIFPOF();
		CJCBONJNFBP();
		NCJHMCBDICD();
		float nCEABGKOIHA = (float)LevelManager.instance.currentLevel.displayNumber / (float)LevelManager.instance.maxDisplayLevel;
		ADNKFJNGJFE.InitGuiValues(nCEABGKOIHA);
		EAEDIIFIBLK.InitGuiValues(nCEABGKOIHA);
		AFFDPJMMILP.InitGuiValues(nCEABGKOIHA);
		Singleton<EventTrackingManager>.instance.RegisterPlayerLevelUp("Notification_PlayerLeague", SettingsManager.instance.playerLeague);
		Singleton<EventTrackingManager>.instance.RegisterPlayerLevelUp("Notification_PlayerBattleChallenges", SettingsManager.instance.challenge);
		Singleton<EventTrackingManager>.instance.RegisterPlayerLevelUp("Notification_YourSquadstatus", SettingsManager.instance.squadStatus);
		Singleton<EventTrackingManager>.instance.RegisterPlayerLevelUp("Notification_DailyRewards", SettingsManager.instance.dailyRewardNotification);
		Singleton<EventTrackingManager>.instance.RegisterPlayerLevelUp("Notification_MaintenanceInformation", SettingsManager.instance.maintenance);
	}
}
