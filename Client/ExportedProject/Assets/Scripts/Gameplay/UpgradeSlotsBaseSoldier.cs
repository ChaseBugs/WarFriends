using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;
using UnityEngine.Serialization;

public class UpgradeSlotsBaseSoldier<T> : UpgradeSlotsGeneric<T> where T : Google2uComponentBase
{
	private sealed class PKIINPFKGDD : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal UnitUpgrades PFGLIAHPMCK;

		internal bool EFBPOCHCGPB;

		internal UpgradeSlotsBaseSoldier<T> BJGCPDNMHDH;

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

		public void KGLKGNBCPLM()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void AHEOCEEJICJ()
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
		private object GKJIGGAAHBE()
		{
			return PHDOCKCBJOF;
		}

		public void JJOAHIOBOPO()
		{
			throw new NotSupportedException();
		}

		public bool BJIPDEICIML()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (PFGLIAHPMCK.isElite)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMineVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.EEDFGEONLFO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else if (PFGLIAHPMCK.isVeteran)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[0].JMJIGNKHEKL());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMineVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AELJBCKAJOB));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMineVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AFKMEDLCFCE));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[0].BCGOFHPCKAA());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 5u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMineVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.HGBLHFBLGJG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 2u:
			case 4u:
			case 6u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[DebuggerHidden]
		public PKIINPFKGDD()
		{
		}

		public void IODFILFCENJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CLFFFNGBPGJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JJBAIMILGLK()
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
				if (PFGLIAHPMCK.isElite)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMineVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.EEDFGEONLFO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else if (PFGLIAHPMCK.isVeteran)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[0].JMJIGNKHEKL());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				else
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMineVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AELJBCKAJOB));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMineVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AFKMEDLCFCE));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[0].CBKMNCJMJIH());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 5u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMineVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.HGBLHFBLGJG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
			case 4u:
			case 6u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void HEOPOOMLPJF()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IGMIIAODMNF()
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
				if (PFGLIAHPMCK.isElite)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMineVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.EEDFGEONLFO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else if (PFGLIAHPMCK.isVeteran)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[0].JMJIGNKHEKL());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				else
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMineVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AELJBCKAJOB));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMineVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AFKMEDLCFCE));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[1].JMJIGNKHEKL());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 5u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMineVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.HGBLHFBLGJG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 2u:
			case 4u:
			case 6u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
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
		private object HFKDIPEKENH()
		{
			return PHDOCKCBJOF;
		}

		public void AKEKFBGEJBG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void MKACBCOLNKD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HONCAABOMOC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HMIFLGCBDCO()
		{
			return PHDOCKCBJOF;
		}

		public void FMOJMHBAHAA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void MKIKEOOOLKL()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}
	}

	private sealed class EEHPCJJABDC : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal UnitUpgrades PFGLIAHPMCK;

		internal bool EFBPOCHCGPB;

		internal UpgradeSlotsBaseSoldier<T> BJGCPDNMHDH;

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
		private object GNFCCLCPCBO()
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
				if (PFGLIAHPMCK.isElite)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.EEDFGEONLFO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else if (PFGLIAHPMCK.isVeteran)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[0].HBIDPDPDADN());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				else
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AELJBCKAJOB));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AFKMEDLCFCE));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[1].GEIBNFKACDB());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 5u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.HGBLHFBLGJG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 2u:
			case 4u:
			case 6u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void GIAIFFPNMPJ()
		{
			throw new NotSupportedException();
		}

		public void MIFJOIIKFEB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object CLDLJNHAEAB()
		{
			return PHDOCKCBJOF;
		}

		public void LBNGPPPKLHI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool ILNBJIJONKD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (PFGLIAHPMCK.isElite)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.EEDFGEONLFO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else if (PFGLIAHPMCK.isVeteran)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[1].GEIBNFKACDB());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				else
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AELJBCKAJOB));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AFKMEDLCFCE));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[0].LJAAMEPKPII());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 5u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.HGBLHFBLGJG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
			case 4u:
			case 6u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object HGMMDPIGEGN()
		{
			return PHDOCKCBJOF;
		}

		public void FIENOOBNNGD()
		{
			throw new NotSupportedException();
		}

		public void LFIGPJBHPBH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HFKDIPEKENH()
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
				if (PFGLIAHPMCK.isElite)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.EEDFGEONLFO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else if (PFGLIAHPMCK.isVeteran)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[0].IDJIGNLGAKB());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AELJBCKAJOB));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AFKMEDLCFCE));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[0].IDJIGNLGAKB());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 5u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.HGBLHFBLGJG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 2u:
			case 4u:
			case 6u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object JPJBNHHKOJD()
		{
			return PHDOCKCBJOF;
		}

		public void IFLGJMJCOMC()
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
				if (PFGLIAHPMCK.isElite)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.EEDFGEONLFO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else if (PFGLIAHPMCK.isVeteran)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[1].LJAAMEPKPII());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				else
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AELJBCKAJOB));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AFKMEDLCFCE));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[1].LJAAMEPKPII());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 5u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.HGBLHFBLGJG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 2u:
			case 4u:
			case 6u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[DebuggerHidden]
		public void Reset()
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
				if (PFGLIAHPMCK.isElite)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.EEDFGEONLFO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else if (PFGLIAHPMCK.isVeteran)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[1].HBIDPDPDADN());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				else
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AELJBCKAJOB));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AFKMEDLCFCE));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[1].IDJIGNLGAKB());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 5u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.HGBLHFBLGJG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 2u:
			case 4u:
			case 6u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object PFIIINLHGMH()
		{
			return PHDOCKCBJOF;
		}

		public void GGCLMIMHKBD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CEFJLKJNAKJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EFIEEKFCBJH()
		{
			return PHDOCKCBJOF;
		}

		public void CGCPMAHOJJC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void ODPKEEIHOPK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object DKPOLLDBPAP()
		{
			return PHDOCKCBJOF;
		}

		public void FJOIBBIGBJC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object JALKNCBEINE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JDKFIHJHNJC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ENKCCCABFFB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MBDBIPHLEIA()
		{
			return PHDOCKCBJOF;
		}

		public bool IDBCKIPOEEI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (PFGLIAHPMCK.isElite)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.EEDFGEONLFO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else if (PFGLIAHPMCK.isVeteran)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[0].PLNLICOAHFL());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				else
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AELJBCKAJOB));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AFKMEDLCFCE));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[0].HBIDPDPDADN());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 5u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.HGBLHFBLGJG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 2u:
			case 4u:
			case 6u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object CICPCKDCCEF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GMPGIODBIPO()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void POJKIIMAFDO()
		{
			throw new NotSupportedException();
		}

		public void PNGIELILHDI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MKNFFJPADIA()
		{
			return PHDOCKCBJOF;
		}

		public void LJPIDOKGNBF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void MBELAAJDOJA()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object LGDOCMENCOG()
		{
			return PHDOCKCBJOF;
		}

		public void HLDMODAFJBO()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void NMEJKACLHKJ()
		{
			throw new NotSupportedException();
		}

		public void KOEEOJGJNAO()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object JKKAEPEAGNP()
		{
			return PHDOCKCBJOF;
		}

		public bool BCFKDABEHHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (PFGLIAHPMCK.isElite)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.EEDFGEONLFO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else if (PFGLIAHPMCK.isVeteran)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[1].HBIDPDPDADN());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				else
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AELJBCKAJOB));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AFKMEDLCFCE));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[1].HBIDPDPDADN());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 5u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.HGBLHFBLGJG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 2u:
			case 4u:
			case 6u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object IHAJFNHBAHB()
		{
			return PHDOCKCBJOF;
		}

		public void GFJIKANGNMC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object JLLOKNANOCN()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public EEHPCJJABDC()
		{
		}

		[SpecialName]
		private object AAAOCACGKIP()
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
				if (PFGLIAHPMCK.isElite)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.EEDFGEONLFO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else if (PFGLIAHPMCK.isVeteran)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[0].GEIBNFKACDB());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AELJBCKAJOB));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AFKMEDLCFCE));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[1].IDJIGNLGAKB());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 5u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.HGBLHFBLGJG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 2u:
			case 4u:
			case 6u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public bool JMCPAKBLPML()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (PFGLIAHPMCK.isElite)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.EEDFGEONLFO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else if (PFGLIAHPMCK.isVeteran)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[1].PLNLICOAHFL());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				else
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AELJBCKAJOB));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AFKMEDLCFCE));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[0].GEIBNFKACDB());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 5u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.HGBLHFBLGJG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 2u:
			case 4u:
			case 6u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void NFAMBMLLFGP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool KCEAGNMILMA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (PFGLIAHPMCK.isElite)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.EEDFGEONLFO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else if (PFGLIAHPMCK.isVeteran)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[1].GEIBNFKACDB());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AELJBCKAJOB));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AFKMEDLCFCE));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[0].HBIDPDPDADN());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 5u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.HGBLHFBLGJG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 2u:
			case 4u:
			case 6u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object ONADHLDNKKB()
		{
			return PHDOCKCBJOF;
		}

		public bool OKELILGDPLJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (PFGLIAHPMCK.isElite)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.EEDFGEONLFO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else if (PFGLIAHPMCK.isVeteran)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[0].GEIBNFKACDB());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				else
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AELJBCKAJOB));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AFKMEDLCFCE));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[1].LJAAMEPKPII());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 5u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.HGBLHFBLGJG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 2u:
			case 4u:
			case 6u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
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
				if (PFGLIAHPMCK.isElite)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.EEDFGEONLFO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else if (PFGLIAHPMCK.isVeteran)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[0].PLNLICOAHFL());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
				}
				else
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AELJBCKAJOB));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AFKMEDLCFCE));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[1].HBIDPDPDADN());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 5u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.HGBLHFBLGJG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 2u:
			case 4u:
			case 6u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public bool GNFCLHDPPFP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (PFGLIAHPMCK.isElite)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.EEDFGEONLFO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else if (PFGLIAHPMCK.isVeteran)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[1].PLNLICOAHFL());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				else
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AELJBCKAJOB));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AFKMEDLCFCE));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[0].LJAAMEPKPII());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 5u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.HGBLHFBLGJG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 2u:
			case 4u:
			case 6u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void KKDOJDCJAJB()
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
				if (PFGLIAHPMCK.isElite)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.EEDFGEONLFO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else if (PFGLIAHPMCK.isVeteran)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[1].LJAAMEPKPII());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
				}
				else
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AELJBCKAJOB));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AFKMEDLCFCE));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[0].PLNLICOAHFL());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 5u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.HGBLHFBLGJG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 2u:
			case 4u:
			case 6u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object HADIFBCDICK()
		{
			return PHDOCKCBJOF;
		}

		public bool MKLIDMNLNPN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (PFGLIAHPMCK.isElite)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.EEDFGEONLFO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else if (PFGLIAHPMCK.isVeteran)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[0].IDJIGNLGAKB());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				else
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AELJBCKAJOB));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AFKMEDLCFCE));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[0].PLNLICOAHFL());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 5u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.HGBLHFBLGJG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 2u:
			case 4u:
			case 6u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object CFBNPKIMOJC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KGPFMHHMKHO()
		{
			return PHDOCKCBJOF;
		}

		public bool CBGPIONEKLM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (PFGLIAHPMCK.isElite)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.EEDFGEONLFO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else if (PFGLIAHPMCK.isVeteran)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[1].PLNLICOAHFL());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				else
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AELJBCKAJOB));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AFKMEDLCFCE));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[1].GEIBNFKACDB());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 5u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.HGBLHFBLGJG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 2u:
			case 4u:
			case 6u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void IJHCIJLDKHK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BMGHJKFMKJE()
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
				if (PFGLIAHPMCK.isElite)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.EEDFGEONLFO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else if (PFGLIAHPMCK.isVeteran)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[1].IDJIGNLGAKB());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AELJBCKAJOB));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AFKMEDLCFCE));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[1].HBIDPDPDADN());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 5u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.HGBLHFBLGJG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 2u:
			case 4u:
			case 6u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object CMNCAPEMEJI()
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
				if (PFGLIAHPMCK.isElite)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.EEDFGEONLFO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else if (PFGLIAHPMCK.isVeteran)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[0].PLNLICOAHFL());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				else
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AELJBCKAJOB));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AFKMEDLCFCE));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[1].LJAAMEPKPII());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 5u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.HGBLHFBLGJG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 2u:
			case 4u:
			case 6u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object KBNAGKKMLBP()
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
				if (PFGLIAHPMCK.isElite)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.EEDFGEONLFO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else if (PFGLIAHPMCK.isVeteran)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[1].HBIDPDPDADN());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				else
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AELJBCKAJOB));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AFKMEDLCFCE));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[0].IDJIGNLGAKB());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 5u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.HGBLHFBLGJG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 2u:
			case 4u:
			case 6u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object EAGBDDECKHF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PCELHKMHCOB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IAMNDODCIEB()
		{
			return PHDOCKCBJOF;
		}

		public void BCIPEBNJONK()
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
				if (PFGLIAHPMCK.isElite)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.EEDFGEONLFO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else if (PFGLIAHPMCK.isVeteran)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[0].LJAAMEPKPII());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				else
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AELJBCKAJOB));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AFKMEDLCFCE));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[1].LJAAMEPKPII());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 5u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.HGBLHFBLGJG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 2u:
			case 4u:
			case 6u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object DGEECEBHPNC()
		{
			return PHDOCKCBJOF;
		}

		public void OLPILJFHMGD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object ADNCCLOOEAD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KBEEEOJMBPG()
		{
			return PHDOCKCBJOF;
		}

		public void GFPDOCDEGPA()
		{
			throw new NotSupportedException();
		}

		public bool PMBOHHPPJAC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (PFGLIAHPMCK.isElite)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.EEDFGEONLFO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else if (PFGLIAHPMCK.isVeteran)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[1].IDJIGNLGAKB());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				else
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AELJBCKAJOB));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AFKMEDLCFCE));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[0].IDJIGNLGAKB());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 5u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.HGBLHFBLGJG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 2u:
			case 4u:
			case 6u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void EJADBNAIHEF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void HPJKDIGCCCE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void OEMOMDILPEE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object KKKMCHGLHLL()
		{
			return PHDOCKCBJOF;
		}

		public void FMOJMHBAHAA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool GBLFIBDBMGE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (PFGLIAHPMCK.isElite)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.EEDFGEONLFO));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else if (PFGLIAHPMCK.isVeteran)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[1].PLNLICOAHFL());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				else
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AELJBCKAJOB));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.AFKMEDLCFCE));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 3u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.cardVisuals[1].PLNLICOAHFL());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 5u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadOpponentVisualAsync(PFGLIAHPMCK.slotUpgradeindex, EFBPOCHCGPB, BJGCPDNMHDH.HGBLHFBLGJG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 2u:
			case 4u:
			case 6u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void ELMJLOBAMKH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object FONIPEGACDN()
		{
			return PHDOCKCBJOF;
		}

		public void CNEIBEACPCM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}
	}

	[Header("Visuals")]
	[FormerlySerializedAs("GNGBFNOGOFJ")]
	public List<TechnologyVisualDefinition> AELJBCKAJOB;

	[FormerlySerializedAs("LGHFHIKLCOK")]
	public List<TechnologyVisualDefinition> HGBLHFBLGJG;

	[FormerlySerializedAs("EEJPFNBFLJP")]
	public List<TechnologyVisualDefinition> GBCGHFAKBNI;

	[FormerlySerializedAs("JEOMDPJIHAC")]
	[Header("Elite Visuals")]
	public List<TechnologyVisualDefinition> EEDFGEONLFO;

	[FormerlySerializedAs("AIDEJHHNHAP")]
	public List<TechnologyVisualDefinition> AFKMEDLCFCE;

	[FormerlySerializedAs("OBOALLIGGCG")]
	public List<TechnologyVisualDefinition> IJFDEFAJHJK;

	public override float damage
	{
		get
		{
			int rowIndex = upgradeSlot.boughtIndex;
			return (float)base.excel.GetValue(rowIndex, "damage");
		}
	}

	public virtual List<Tuple<string, float[]>> CFPIJLPBPIJ(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(StatsFor(ACHJJKCIBCN, "ArenaLives", "ExplodeNetwork"));
		list.Add(StatsFor(ACHJJKCIBCN, ")", "Checker"));
		return list;
	}

	public virtual IEnumerator DPJBHHFJFPF(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		EEHPCJJABDC eEHPCJJABDC = new EEHPCJJABDC();
		eEHPCJJABDC.PFGLIAHPMCK = PFGLIAHPMCK;
		eEHPCJJABDC.EFBPOCHCGPB = EFBPOCHCGPB;
		eEHPCJJABDC.BJGCPDNMHDH = this;
		return eEHPCJJABDC;
	}

	public virtual List<TechnologyVisualDefinition> KBEAPADDNLM(UnitUpgrades PFGLIAHPMCK)
	{
		List<TechnologyVisualDefinition> list = new List<TechnologyVisualDefinition>();
		if (PFGLIAHPMCK.isElite)
		{
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, EEDFGEONLFO));
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, AFKMEDLCFCE));
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, IJFDEFAJHJK));
		}
		else if (PFGLIAHPMCK.isVeteran)
		{
			list = cardVisuals;
		}
		else
		{
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, AELJBCKAJOB));
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, HGBLHFBLGJG));
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, GBCGHFAKBNI));
		}
		return list;
	}

	[SpecialName]
	public virtual float NOAHPDILHHP()
	{
		int rowIndex = upgradeSlot.PAKKPEPIHPK();
		return (float)base.excel.GetValue(rowIndex, "ID_PLAYERLEAGUEPROCESSING");
	}

	public virtual void OMDECFDCMHC()
	{
		foreach (TechnologyVisualDefinition item in AELJBCKAJOB)
		{
			item.BHINPFEIIJG();
		}
		foreach (TechnologyVisualDefinition item2 in EEDFGEONLFO)
		{
			item2.EIFNJBHKBOM();
		}
		foreach (TechnologyVisualDefinition item3 in HGBLHFBLGJG)
		{
			item3.BHINPFEIIJG();
		}
		foreach (TechnologyVisualDefinition item4 in AFKMEDLCFCE)
		{
			item4.BHINPFEIIJG();
		}
	}

	protected override void IPGEHGPGGKL(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		SoldierBehaviourDefinititon soldierBehaviourDefinititon = (SoldierBehaviourDefinititon)BJOIGFEOMHN;
		soldierBehaviourDefinititon.health = (float)soldierBehaviourDefinititon.health + (float)base.excel.GetValue(FFCCFDJBLLD, "HP");
		soldierBehaviourDefinititon.probabilityOfRealShot += (float)base.excel.GetValue(FFCCFDJBLLD, "realShotProbability");
		soldierBehaviourDefinititon.fireBatchSizeMin += (int)base.excel.GetValue(FFCCFDJBLLD, "batchSizeMin");
		soldierBehaviourDefinititon.fireBatchSizeMax += (int)base.excel.GetValue(FFCCFDJBLLD, "batchSizeMax");
		soldierBehaviourDefinititon.minShootTime += (float)base.excel.GetValue(FFCCFDJBLLD, "ShotFrequencyMin");
		soldierBehaviourDefinititon.maxShootTime += (float)base.excel.GetValue(FFCCFDJBLLD, "ShotFrequencyMax");
		soldierBehaviourDefinititon.walkShotTimeMin += (float)base.excel.GetValue(FFCCFDJBLLD, "ShotFrequencyMin");
		soldierBehaviourDefinititon.walkShotTimeMax += (float)base.excel.GetValue(FFCCFDJBLLD, "ShotFrequencyMax");
		soldierBehaviourDefinititon.damage = (float)soldierBehaviourDefinititon.damage + (float)base.excel.GetValue(FFCCFDJBLLD, "damage");
		if (base.excel.HasColumn("special"))
		{
			soldierBehaviourDefinititon.special += (float)base.excel.GetValue(FFCCFDJBLLD, "special");
		}
	}

	public virtual IEnumerator AGNINOEADCK(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		PKIINPFKGDD pKIINPFKGDD = new PKIINPFKGDD();
		pKIINPFKGDD.PFGLIAHPMCK = PFGLIAHPMCK;
		pKIINPFKGDD.EFBPOCHCGPB = EFBPOCHCGPB;
		pKIINPFKGDD.BJGCPDNMHDH = this;
		return pKIINPFKGDD;
	}

	public virtual List<TechnologyVisualDefinition> EJMEAIIPPKL(UnitUpgrades PFGLIAHPMCK)
	{
		List<TechnologyVisualDefinition> list = new List<TechnologyVisualDefinition>();
		if (PFGLIAHPMCK.isElite)
		{
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, EEDFGEONLFO));
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, AFKMEDLCFCE));
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, IJFDEFAJHJK));
		}
		else if (PFGLIAHPMCK.isVeteran)
		{
			list = cardVisuals;
		}
		else
		{
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, AELJBCKAJOB));
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, HGBLHFBLGJG));
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, GBCGHFAKBNI));
		}
		return list;
	}

	protected virtual void GOGNCGEAAEM(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		SoldierBehaviourDefinititon soldierBehaviourDefinititon = (SoldierBehaviourDefinititon)BJOIGFEOMHN;
		soldierBehaviourDefinititon.health = (float)soldierBehaviourDefinititon.health + (float)base.excel.GetValue(FFCCFDJBLLD, "game-engi-progress-fill");
		soldierBehaviourDefinititon.probabilityOfRealShot += (float)base.excel.GetValue(FFCCFDJBLLD, "BotWeaponPower");
		soldierBehaviourDefinititon.fireBatchSizeMin += (int)base.excel.GetValue(FFCCFDJBLLD, "ID_ARENARULES_UNITCOST");
		soldierBehaviourDefinititon.fireBatchSizeMax += (int)base.excel.GetValue(FFCCFDJBLLD, "ID_CONFIRM_GAMECENTER");
		soldierBehaviourDefinititon.minShootTime += (float)base.excel.GetValue(FFCCFDJBLLD, " 3");
		soldierBehaviourDefinititon.maxShootTime += (float)base.excel.GetValue(FFCCFDJBLLD, "+{0}");
		soldierBehaviourDefinititon.walkShotTimeMin += (float)base.excel.GetValue(FFCCFDJBLLD, "Transaction_Amount");
		soldierBehaviourDefinititon.walkShotTimeMax += (float)base.excel.GetValue(FFCCFDJBLLD, "VipReward1");
		soldierBehaviourDefinititon.damage = (float)soldierBehaviourDefinititon.damage + (float)base.excel.GetValue(FFCCFDJBLLD, "SquadPoints");
		if (base.excel.HasColumn("ID_WARNING_CANTSENDINVITE_TEXT"))
		{
			soldierBehaviourDefinititon.special += (float)base.excel.GetValue(FFCCFDJBLLD, "Scripts");
		}
	}

	public virtual void BJLGMJBBOHL()
	{
		foreach (TechnologyVisualDefinition item in AELJBCKAJOB)
		{
			item.LPEPPPCBCDG();
		}
		foreach (TechnologyVisualDefinition item2 in EEDFGEONLFO)
		{
			item2.BBENKKFKDJH();
		}
		foreach (TechnologyVisualDefinition item3 in HGBLHFBLGJG)
		{
			item3.LLJOCAELALO();
		}
		foreach (TechnologyVisualDefinition item4 in AFKMEDLCFCE)
		{
			item4.LPEPPPCBCDG();
		}
	}

	public virtual List<TechnologyVisualDefinition> EMLGMAPBLAO(UnitUpgrades PFGLIAHPMCK)
	{
		List<TechnologyVisualDefinition> list = new List<TechnologyVisualDefinition>();
		if (PFGLIAHPMCK.isElite)
		{
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, EEDFGEONLFO));
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, AFKMEDLCFCE));
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, IJFDEFAJHJK));
		}
		else if (PFGLIAHPMCK.isVeteran)
		{
			list = cardVisuals;
		}
		else
		{
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, AELJBCKAJOB));
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, HGBLHFBLGJG));
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, GBCGHFAKBNI));
		}
		return list;
	}

	public virtual IEnumerator HIJKLCDNDHA(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		PKIINPFKGDD pKIINPFKGDD = new PKIINPFKGDD();
		pKIINPFKGDD.PFGLIAHPMCK = PFGLIAHPMCK;
		pKIINPFKGDD.EFBPOCHCGPB = EFBPOCHCGPB;
		pKIINPFKGDD.BJGCPDNMHDH = this;
		return pKIINPFKGDD;
	}

	[DebuggerHidden]
	public override IEnumerator LoadOponentVisualsCoroutine(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		EEHPCJJABDC eEHPCJJABDC = new EEHPCJJABDC();
		eEHPCJJABDC.PFGLIAHPMCK = PFGLIAHPMCK;
		eEHPCJJABDC.EFBPOCHCGPB = EFBPOCHCGPB;
		eEHPCJJABDC.BJGCPDNMHDH = this;
		return eEHPCJJABDC;
	}

	public virtual List<Tuple<string, float[]>> DNPNJANKBKK(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(StatsFor(ACHJJKCIBCN, "ExplodeNetwork", "dogTagTimerLock"));
		list.Add(StatsFor(ACHJJKCIBCN, "globalPlayerLeaderboard", "40+"));
		return list;
	}

	public virtual List<Tuple<string, float[]>> HDPMJGABCHI(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(StatsFor(ACHJJKCIBCN, "ID_PVP_BATTLE", "Gold"));
		list.Add(StatsFor(ACHJJKCIBCN, "ID_CATEGORY_LOW_PL_GRENADELAUNCHER", "ID_REMINDER_RAISEYOURCHANCES"));
		return list;
	}

	public virtual List<TechnologyVisualDefinition> GCHKBEFPGAP(UnitUpgrades PFGLIAHPMCK)
	{
		List<TechnologyVisualDefinition> list = new List<TechnologyVisualDefinition>();
		if (PFGLIAHPMCK.isElite)
		{
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, EEDFGEONLFO));
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, AFKMEDLCFCE));
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, IJFDEFAJHJK));
		}
		else if (PFGLIAHPMCK.isVeteran)
		{
			list = cardVisuals;
		}
		else
		{
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, AELJBCKAJOB));
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, HGBLHFBLGJG));
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, GBCGHFAKBNI));
		}
		return list;
	}

	public virtual IEnumerator HBBMGDJONBM(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		EEHPCJJABDC eEHPCJJABDC = new EEHPCJJABDC();
		eEHPCJJABDC.PFGLIAHPMCK = PFGLIAHPMCK;
		eEHPCJJABDC.EFBPOCHCGPB = EFBPOCHCGPB;
		eEHPCJJABDC.BJGCPDNMHDH = this;
		return eEHPCJJABDC;
	}

	public virtual IEnumerator IAMCKKJFFJM(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		EEHPCJJABDC eEHPCJJABDC = new EEHPCJJABDC();
		eEHPCJJABDC.PFGLIAHPMCK = PFGLIAHPMCK;
		eEHPCJJABDC.EFBPOCHCGPB = EFBPOCHCGPB;
		eEHPCJJABDC.BJGCPDNMHDH = this;
		return eEHPCJJABDC;
	}

	public override void NullMineVisuals()
	{
		foreach (TechnologyVisualDefinition item in AELJBCKAJOB)
		{
			item.LLGPADPJPIF();
		}
		foreach (TechnologyVisualDefinition item2 in EEDFGEONLFO)
		{
			item2.LLGPADPJPIF();
		}
		foreach (TechnologyVisualDefinition item3 in HGBLHFBLGJG)
		{
			item3.LLGPADPJPIF();
		}
		foreach (TechnologyVisualDefinition item4 in AFKMEDLCFCE)
		{
			item4.LLGPADPJPIF();
		}
	}

	public virtual List<Tuple<string, float[]>> CIFEHNGJMKH(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(StatsFor(ACHJJKCIBCN, " mSpriteName:", "Pool"));
		list.Add(StatsFor(ACHJJKCIBCN, "generate", "Rank"));
		return list;
	}

	public virtual IEnumerator PCKEHPGELIL(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		EEHPCJJABDC eEHPCJJABDC = new EEHPCJJABDC();
		eEHPCJJABDC.PFGLIAHPMCK = PFGLIAHPMCK;
		eEHPCJJABDC.EFBPOCHCGPB = EFBPOCHCGPB;
		eEHPCJJABDC.BJGCPDNMHDH = this;
		return eEHPCJJABDC;
	}

	public virtual void MGIJPJBODCE()
	{
		base.UnloadVisuals();
		foreach (TechnologyVisualDefinition item in AELJBCKAJOB)
		{
			item.BMBAPDEABCP();
		}
		foreach (TechnologyVisualDefinition item2 in EEDFGEONLFO)
		{
			item2.NLIEFEDBJDK();
		}
		foreach (TechnologyVisualDefinition item3 in HGBLHFBLGJG)
		{
			item3.PKFILEOILFD();
		}
		foreach (TechnologyVisualDefinition item4 in AFKMEDLCFCE)
		{
			item4.AFGFFBIONBJ();
		}
	}

	public virtual List<Tuple<string, float[]>> GBMIBIPKPOO(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(StatsFor(ACHJJKCIBCN, "explosive", "LeagueEvaluation"));
		list.Add(StatsFor(ACHJJKCIBCN, "+{0}", "ID_WARNING_CONNECTIONERROR"));
		return list;
	}

	public override List<Tuple<string, float[]>> GetGuiStats(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(StatsFor(ACHJJKCIBCN, "DPS", "ID_ATTACK"));
		list.Add(StatsFor(ACHJJKCIBCN, "HP", "ID_HEALTH"));
		return list;
	}

	public virtual List<TechnologyVisualDefinition> PNBFHPKOPPN(UnitUpgrades PFGLIAHPMCK)
	{
		List<TechnologyVisualDefinition> list = new List<TechnologyVisualDefinition>();
		if (PFGLIAHPMCK.isElite)
		{
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, EEDFGEONLFO));
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, AFKMEDLCFCE));
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, IJFDEFAJHJK));
		}
		else if (PFGLIAHPMCK.isVeteran)
		{
			list = cardVisuals;
		}
		else
		{
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, AELJBCKAJOB));
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, HGBLHFBLGJG));
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, GBCGHFAKBNI));
		}
		return list;
	}

	public override List<TechnologyVisualDefinition> GetVisuals(UnitUpgrades PFGLIAHPMCK)
	{
		List<TechnologyVisualDefinition> list = new List<TechnologyVisualDefinition>();
		if (PFGLIAHPMCK.isElite)
		{
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, EEDFGEONLFO));
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, AFKMEDLCFCE));
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, IJFDEFAJHJK));
		}
		else if (PFGLIAHPMCK.isVeteran)
		{
			list = cardVisuals;
		}
		else
		{
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, AELJBCKAJOB));
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, HGBLHFBLGJG));
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, GBCGHFAKBNI));
		}
		return list;
	}

	public virtual List<Tuple<string, float[]>> AMBJAOJJADI(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(StatsFor(ACHJJKCIBCN, "ID_WATCHVIDEO", "Wrong_Category"));
		list.Add(StatsFor(ACHJJKCIBCN, "IsLocal", "getAverageSessionLength"));
		return list;
	}

	[SpecialName]
	public virtual float NGNCDPFOGBO()
	{
		int rowIndex = upgradeSlot.PAKKPEPIHPK();
		return (float)base.excel.GetValue(rowIndex, "Enemy could not be spawned");
	}

	[SpecialName]
	public virtual float NLDICGHLJLI()
	{
		int rowIndex = upgradeSlot.PAKKPEPIHPK();
		return (float)base.excel.GetValue(rowIndex, "LeagueId");
	}

	public virtual IEnumerator PIHGDLACFIN(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		PKIINPFKGDD pKIINPFKGDD = new PKIINPFKGDD();
		pKIINPFKGDD.PFGLIAHPMCK = PFGLIAHPMCK;
		pKIINPFKGDD.EFBPOCHCGPB = EFBPOCHCGPB;
		pKIINPFKGDD.BJGCPDNMHDH = this;
		return pKIINPFKGDD;
	}

	public virtual void FCIJIDIEAKJ()
	{
		base.UnloadVisuals();
		foreach (TechnologyVisualDefinition item in AELJBCKAJOB)
		{
			item.AFGFFBIONBJ();
		}
		foreach (TechnologyVisualDefinition item2 in EEDFGEONLFO)
		{
			item2.AFGFFBIONBJ();
		}
		foreach (TechnologyVisualDefinition item3 in HGBLHFBLGJG)
		{
			item3.AFGFFBIONBJ();
		}
		foreach (TechnologyVisualDefinition item4 in AFKMEDLCFCE)
		{
			item4.BMBAPDEABCP();
		}
	}

	[SpecialName]
	public virtual float HKEMJOKCAOE()
	{
		int rowIndex = upgradeSlot.PAKKPEPIHPK();
		return (float)base.excel.GetValue(rowIndex, "!!!UNDER TABLE!!! ");
	}

	public override void UnloadVisuals()
	{
		base.UnloadVisuals();
		foreach (TechnologyVisualDefinition item in AELJBCKAJOB)
		{
			item.PKFILEOILFD();
		}
		foreach (TechnologyVisualDefinition item2 in EEDFGEONLFO)
		{
			item2.PKFILEOILFD();
		}
		foreach (TechnologyVisualDefinition item3 in HGBLHFBLGJG)
		{
			item3.PKFILEOILFD();
		}
		foreach (TechnologyVisualDefinition item4 in AFKMEDLCFCE)
		{
			item4.PKFILEOILFD();
		}
	}

	public virtual IEnumerator HLJNMLFBKGN(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		EEHPCJJABDC eEHPCJJABDC = new EEHPCJJABDC();
		eEHPCJJABDC.PFGLIAHPMCK = PFGLIAHPMCK;
		eEHPCJJABDC.EFBPOCHCGPB = EFBPOCHCGPB;
		eEHPCJJABDC.BJGCPDNMHDH = this;
		return eEHPCJJABDC;
	}

	public virtual void OKCANKDKFJJ()
	{
		foreach (TechnologyVisualDefinition item in AELJBCKAJOB)
		{
			item.BHINPFEIIJG();
		}
		foreach (TechnologyVisualDefinition item2 in EEDFGEONLFO)
		{
			item2.BLEGJDCNAAJ();
		}
		foreach (TechnologyVisualDefinition item3 in HGBLHFBLGJG)
		{
			item3.MIHNPIJCIKK();
		}
		foreach (TechnologyVisualDefinition item4 in AFKMEDLCFCE)
		{
			item4.BLEGJDCNAAJ();
		}
	}

	public virtual void JADOCNFEJHA()
	{
		foreach (TechnologyVisualDefinition item in AELJBCKAJOB)
		{
			item.BLEGJDCNAAJ();
		}
		foreach (TechnologyVisualDefinition item2 in EEDFGEONLFO)
		{
			item2.EIFNJBHKBOM();
		}
		foreach (TechnologyVisualDefinition item3 in HGBLHFBLGJG)
		{
			item3.EIFNJBHKBOM();
		}
		foreach (TechnologyVisualDefinition item4 in AFKMEDLCFCE)
		{
			item4.MIHNPIJCIKK();
		}
	}

	[SpecialName]
	public virtual float AFFPBOAFOKL()
	{
		int rowIndex = upgradeSlot.PAKKPEPIHPK();
		return (float)base.excel.GetValue(rowIndex, "PROD");
	}

	[DebuggerHidden]
	public override IEnumerator LoadMineVisualsCoroutine(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		PKIINPFKGDD pKIINPFKGDD = new PKIINPFKGDD();
		pKIINPFKGDD.PFGLIAHPMCK = PFGLIAHPMCK;
		pKIINPFKGDD.EFBPOCHCGPB = EFBPOCHCGPB;
		pKIINPFKGDD.BJGCPDNMHDH = this;
		return pKIINPFKGDD;
	}

	public virtual void PMLEJGEHILG()
	{
		foreach (TechnologyVisualDefinition item in AELJBCKAJOB)
		{
			item.BHINPFEIIJG();
		}
		foreach (TechnologyVisualDefinition item2 in EEDFGEONLFO)
		{
			item2.BHINPFEIIJG();
		}
		foreach (TechnologyVisualDefinition item3 in HGBLHFBLGJG)
		{
			item3.EIFNJBHKBOM();
		}
		foreach (TechnologyVisualDefinition item4 in AFKMEDLCFCE)
		{
			item4.EIFNJBHKBOM();
		}
	}

	public virtual void POEFIGMGIEG()
	{
		foreach (TechnologyVisualDefinition item in AELJBCKAJOB)
		{
			item.BHINPFEIIJG();
		}
		foreach (TechnologyVisualDefinition item2 in EEDFGEONLFO)
		{
			item2.EIFNJBHKBOM();
		}
		foreach (TechnologyVisualDefinition item3 in HGBLHFBLGJG)
		{
			item3.MIHNPIJCIKK();
		}
		foreach (TechnologyVisualDefinition item4 in AFKMEDLCFCE)
		{
			item4.EIFNJBHKBOM();
		}
	}

	public virtual List<TechnologyVisualDefinition> JGMIAOPLHPH(UnitUpgrades PFGLIAHPMCK)
	{
		List<TechnologyVisualDefinition> list = new List<TechnologyVisualDefinition>();
		if (PFGLIAHPMCK.isElite)
		{
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, EEDFGEONLFO));
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, AFKMEDLCFCE));
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, IJFDEFAJHJK));
		}
		else if (PFGLIAHPMCK.isVeteran)
		{
			list = cardVisuals;
		}
		else
		{
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, AELJBCKAJOB));
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, HGBLHFBLGJG));
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, GBCGHFAKBNI));
		}
		return list;
	}

	public virtual IEnumerator HBFDKLPHFMB(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		PKIINPFKGDD pKIINPFKGDD = new PKIINPFKGDD();
		pKIINPFKGDD.PFGLIAHPMCK = PFGLIAHPMCK;
		pKIINPFKGDD.EFBPOCHCGPB = EFBPOCHCGPB;
		pKIINPFKGDD.BJGCPDNMHDH = this;
		return pKIINPFKGDD;
	}

	public override void NullOpponentVisuals()
	{
		foreach (TechnologyVisualDefinition item in AELJBCKAJOB)
		{
			item.LPEPPPCBCDG();
		}
		foreach (TechnologyVisualDefinition item2 in EEDFGEONLFO)
		{
			item2.LPEPPPCBCDG();
		}
		foreach (TechnologyVisualDefinition item3 in HGBLHFBLGJG)
		{
			item3.LPEPPPCBCDG();
		}
		foreach (TechnologyVisualDefinition item4 in AFKMEDLCFCE)
		{
			item4.LPEPPPCBCDG();
		}
	}

	public virtual IEnumerator LMHDKINFDAK(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		EEHPCJJABDC eEHPCJJABDC = new EEHPCJJABDC();
		eEHPCJJABDC.PFGLIAHPMCK = PFGLIAHPMCK;
		eEHPCJJABDC.EFBPOCHCGPB = EFBPOCHCGPB;
		eEHPCJJABDC.BJGCPDNMHDH = this;
		return eEHPCJJABDC;
	}

	public virtual void BFMJKFFMLFD()
	{
		foreach (TechnologyVisualDefinition item in AELJBCKAJOB)
		{
			item.BBENKKFKDJH();
		}
		foreach (TechnologyVisualDefinition item2 in EEDFGEONLFO)
		{
			item2.LPEPPPCBCDG();
		}
		foreach (TechnologyVisualDefinition item3 in HGBLHFBLGJG)
		{
			item3.BBENKKFKDJH();
		}
		foreach (TechnologyVisualDefinition item4 in AFKMEDLCFCE)
		{
			item4.LPEPPPCBCDG();
		}
	}

	[SpecialName]
	public virtual float MKBBKKCJJAL()
	{
		int rowIndex = upgradeSlot.boughtIndex;
		return (float)base.excel.GetValue(rowIndex, "PlayerName");
	}

	public virtual void CNPEPHEBAEK()
	{
		base.UnloadVisuals();
		foreach (TechnologyVisualDefinition item in AELJBCKAJOB)
		{
			item.NLIEFEDBJDK();
		}
		foreach (TechnologyVisualDefinition item2 in EEDFGEONLFO)
		{
			item2.NLIEFEDBJDK();
		}
		foreach (TechnologyVisualDefinition item3 in HGBLHFBLGJG)
		{
			item3.PKFILEOILFD();
		}
		foreach (TechnologyVisualDefinition item4 in AFKMEDLCFCE)
		{
			item4.GCGIKADBCPG();
		}
	}

	public virtual IEnumerator LOONMIMHFOM(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		EEHPCJJABDC eEHPCJJABDC = new EEHPCJJABDC();
		eEHPCJJABDC.PFGLIAHPMCK = PFGLIAHPMCK;
		eEHPCJJABDC.EFBPOCHCGPB = EFBPOCHCGPB;
		eEHPCJJABDC.BJGCPDNMHDH = this;
		return eEHPCJJABDC;
	}

	public virtual List<TechnologyVisualDefinition> FPMDNOINGGA(UnitUpgrades PFGLIAHPMCK)
	{
		List<TechnologyVisualDefinition> list = new List<TechnologyVisualDefinition>();
		if (PFGLIAHPMCK.isElite)
		{
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, EEDFGEONLFO));
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, AFKMEDLCFCE));
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, IJFDEFAJHJK));
		}
		else if (PFGLIAHPMCK.isVeteran)
		{
			list = cardVisuals;
		}
		else
		{
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, AELJBCKAJOB));
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, HGBLHFBLGJG));
			list.Add(GetTechnologyVisualDefinition(PFGLIAHPMCK.slotUpgradeindex, GBCGHFAKBNI));
		}
		return list;
	}

	public virtual List<Tuple<string, float[]>> JKFJCGGJJKC(UpgradeSlot ACHJJKCIBCN)
	{
		List<Tuple<string, float[]>> list = new List<Tuple<string, float[]>>();
		list.Add(StatsFor(ACHJJKCIBCN, "ID_RANDOMWARCARDCRAFTINGINPROGRESS", "WarCards_Screen"));
		list.Add(StatsFor(ACHJJKCIBCN, "Name", "LootBox_Purchase"));
		return list;
	}

	[SpecialName]
	public virtual float LECDGGPECCE()
	{
		int rowIndex = upgradeSlot.boughtIndex;
		return (float)base.excel.GetValue(rowIndex, "Test Setter Methods");
	}

	public virtual IEnumerator FPJDJIAFCOM(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		PKIINPFKGDD pKIINPFKGDD = new PKIINPFKGDD();
		pKIINPFKGDD.PFGLIAHPMCK = PFGLIAHPMCK;
		pKIINPFKGDD.EFBPOCHCGPB = EFBPOCHCGPB;
		pKIINPFKGDD.BJGCPDNMHDH = this;
		return pKIINPFKGDD;
	}

	public virtual IEnumerator BMOPGCCFKPK(UnitUpgrades PFGLIAHPMCK, bool EFBPOCHCGPB)
	{
		EEHPCJJABDC eEHPCJJABDC = new EEHPCJJABDC();
		eEHPCJJABDC.PFGLIAHPMCK = PFGLIAHPMCK;
		eEHPCJJABDC.EFBPOCHCGPB = EFBPOCHCGPB;
		eEHPCJJABDC.BJGCPDNMHDH = this;
		return eEHPCJJABDC;
	}

	[SpecialName]
	public virtual float CJHHFLDAMIB()
	{
		int rowIndex = upgradeSlot.PAKKPEPIHPK();
		return (float)base.excel.GetValue(rowIndex, "Awaiting players - Player id:\"{0}\" is not in list of awaiting members");
	}

	public virtual void MAKAGCPAAGM()
	{
		base.UnloadVisuals();
		foreach (TechnologyVisualDefinition item in AELJBCKAJOB)
		{
			item.PKFILEOILFD();
		}
		foreach (TechnologyVisualDefinition item2 in EEDFGEONLFO)
		{
			item2.NLIEFEDBJDK();
		}
		foreach (TechnologyVisualDefinition item3 in HGBLHFBLGJG)
		{
			item3.NLIEFEDBJDK();
		}
		foreach (TechnologyVisualDefinition item4 in AFKMEDLCFCE)
		{
			item4.BMBAPDEABCP();
		}
	}

	public virtual void IEHOGAKIHOE()
	{
		foreach (TechnologyVisualDefinition item in AELJBCKAJOB)
		{
			item.BBENKKFKDJH();
		}
		foreach (TechnologyVisualDefinition item2 in EEDFGEONLFO)
		{
			item2.BBENKKFKDJH();
		}
		foreach (TechnologyVisualDefinition item3 in HGBLHFBLGJG)
		{
			item3.LPEPPPCBCDG();
		}
		foreach (TechnologyVisualDefinition item4 in AFKMEDLCFCE)
		{
			item4.LPEPPPCBCDG();
		}
	}

	[SpecialName]
	public virtual float OKKENAGOLHA()
	{
		int rowIndex = upgradeSlot.PAKKPEPIHPK();
		return (float)base.excel.GetValue(rowIndex, "ID_TABLE_SQUAD");
	}

	public virtual void KPBKBCLAGLA()
	{
		base.UnloadVisuals();
		foreach (TechnologyVisualDefinition item in AELJBCKAJOB)
		{
			item.GCGIKADBCPG();
		}
		foreach (TechnologyVisualDefinition item2 in EEDFGEONLFO)
		{
			item2.GCGIKADBCPG();
		}
		foreach (TechnologyVisualDefinition item3 in HGBLHFBLGJG)
		{
			item3.BMBAPDEABCP();
		}
		foreach (TechnologyVisualDefinition item4 in AFKMEDLCFCE)
		{
			item4.NLIEFEDBJDK();
		}
	}

	public virtual void POFNIJHHIKO()
	{
		base.UnloadVisuals();
		foreach (TechnologyVisualDefinition item in AELJBCKAJOB)
		{
			item.PKFILEOILFD();
		}
		foreach (TechnologyVisualDefinition item2 in EEDFGEONLFO)
		{
			item2.NLIEFEDBJDK();
		}
		foreach (TechnologyVisualDefinition item3 in HGBLHFBLGJG)
		{
			item3.AFGFFBIONBJ();
		}
		foreach (TechnologyVisualDefinition item4 in AFKMEDLCFCE)
		{
			item4.GCGIKADBCPG();
		}
	}

	protected virtual void JHLLBDBFMNJ(BehaviourDefinititon BJOIGFEOMHN, int FFCCFDJBLLD)
	{
		base.IPGEHGPGGKL(BJOIGFEOMHN, FFCCFDJBLLD);
		SoldierBehaviourDefinititon soldierBehaviourDefinititon = (SoldierBehaviourDefinititon)BJOIGFEOMHN;
		soldierBehaviourDefinititon.health = (float)soldierBehaviourDefinititon.health + (float)base.excel.GetValue(FFCCFDJBLLD, "ID_FRIENDREFUSEDREMATCHCOOP");
		soldierBehaviourDefinititon.probabilityOfRealShot += (float)base.excel.GetValue(FFCCFDJBLLD, "Cancel - Disconnect, clicked in dialog !!!");
		soldierBehaviourDefinititon.fireBatchSizeMin += (int)base.excel.GetValue(FFCCFDJBLLD, "SuggestedSquad");
		soldierBehaviourDefinititon.fireBatchSizeMax += (int)base.excel.GetValue(FFCCFDJBLLD, "{0}{1}{2} {3}{4}");
		soldierBehaviourDefinititon.minShootTime += (float)base.excel.GetValue(FFCCFDJBLLD, "'RewardForDay_'0");
		soldierBehaviourDefinititon.maxShootTime += (float)base.excel.GetValue(FFCCFDJBLLD, "DecalExpiresOn");
		soldierBehaviourDefinititon.walkShotTimeMin += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_CATEGORY_LOW_PL_MINIGUN");
		soldierBehaviourDefinititon.walkShotTimeMax += (float)base.excel.GetValue(FFCCFDJBLLD, "ID_GUI_BEADVISED");
		soldierBehaviourDefinititon.damage = (float)soldierBehaviourDefinititon.damage + (float)base.excel.GetValue(FFCCFDJBLLD, "special");
		if (base.excel.HasColumn("ID_INSILVER1"))
		{
			soldierBehaviourDefinititon.special += (float)base.excel.GetValue(FFCCFDJBLLD, "From_queue");
		}
	}

	public virtual void GHGNLJGBEBN()
	{
		foreach (TechnologyVisualDefinition item in AELJBCKAJOB)
		{
			item.BHINPFEIIJG();
		}
		foreach (TechnologyVisualDefinition item2 in EEDFGEONLFO)
		{
			item2.BLEGJDCNAAJ();
		}
		foreach (TechnologyVisualDefinition item3 in HGBLHFBLGJG)
		{
			item3.MIHNPIJCIKK();
		}
		foreach (TechnologyVisualDefinition item4 in AFKMEDLCFCE)
		{
			item4.BHINPFEIIJG();
		}
	}

	[SpecialName]
	public virtual float MMEPIELHDCM()
	{
		int rowIndex = upgradeSlot.PPKAIEKPNID();
		return (float)base.excel.GetValue(rowIndex, "Gold");
	}
}
