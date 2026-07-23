using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class IntroductionDeals : Core_BaseScript
{
	private sealed class DPGECBFGBGI : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal bool NMBKNILBINN;

		internal IntroductionDealsItem CMCLNPEBPHD;

		internal IntroductionDealsItem DMPNHJPGIAO;

		internal IntroductionDeals BJGCPDNMHDH;

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

		public bool OOECALAHCFK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				NMBKNILBINN = true;
				CMCLNPEBPHD = null;
				goto IL_003b;
			case 2u:
				if (DMPNHJPGIAO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(DMPNHJPGIAO.ONCKKJFAMKF(BJGCPDNMHDH.JIEDOFAPHFN));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				goto case 3u;
			case 3u:
				CMCLNPEBPHD = DMPNHJPGIAO;
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 4u:
				if (!(CMCLNPEBPHD != null) || !CMCLNPEBPHD.DIEACOMHPOP())
				{
					goto IL_003b;
				}
				goto case 1u;
			default:
				{
					return true;
				}
				IL_003b:
				if (CMCLNPEBPHD != null && CMCLNPEBPHD.HGBLICDJOHG() && !CMCLNPEBPHD.KAEGGLFKJHD())
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CMCLNPEBPHD.Change(BJGCPDNMHDH.JIEDOFAPHFN));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				DMPNHJPGIAO = BJGCPDNMHDH.EBPJLEPGDAF(CMCLNPEBPHD);
				if (DMPNHJPGIAO != null && !NMBKNILBINN)
				{
					NMBKNILBINN = false;
					BJGCPDNMHDH.PFPAPBMLEIJ();
				}
				if (DMPNHJPGIAO == null && NMBKNILBINN)
				{
					NMBKNILBINN = false;
					BJGCPDNMHDH.KIKIIHKDDNE();
				}
				if (CMCLNPEBPHD != DMPNHJPGIAO)
				{
					if (CMCLNPEBPHD != null)
					{
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CMCLNPEBPHD.EPCEHACNCNH(BJGCPDNMHDH.JIEDOFAPHFN));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 2;
						}
						break;
					}
					goto case 2u;
				}
				goto case 1u;
			}
			return false;
		}

		public void ODJLLLFJIOB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool GPIPJIDGCKM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				NMBKNILBINN = true;
				CMCLNPEBPHD = null;
				goto IL_003b;
			case 2u:
				if (DMPNHJPGIAO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(DMPNHJPGIAO.DMLDBKFCACB(BJGCPDNMHDH.JIEDOFAPHFN));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				goto case 3u;
			case 3u:
				CMCLNPEBPHD = DMPNHJPGIAO;
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 4u:
				if (!(CMCLNPEBPHD != null) || !CMCLNPEBPHD.JEOFLLBGGJB())
				{
					goto IL_003b;
				}
				goto case 1u;
			default:
				{
					return false;
				}
				IL_003b:
				if (CMCLNPEBPHD != null && CMCLNPEBPHD.DAPHOJDBHFE() && !CMCLNPEBPHD.KMAAKJEKFMJ())
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CMCLNPEBPHD.Change(BJGCPDNMHDH.JIEDOFAPHFN));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				DMPNHJPGIAO = BJGCPDNMHDH.AMJEEKIGNJJ(CMCLNPEBPHD);
				if (DMPNHJPGIAO != null && !NMBKNILBINN)
				{
					NMBKNILBINN = false;
					BJGCPDNMHDH.GFMBOEEODKK();
				}
				if (DMPNHJPGIAO == null && NMBKNILBINN)
				{
					NMBKNILBINN = false;
					BJGCPDNMHDH.FHCIDOHMIMM();
				}
				if (CMCLNPEBPHD != DMPNHJPGIAO)
				{
					if (CMCLNPEBPHD != null)
					{
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CMCLNPEBPHD.GDLOAPIHMOB(BJGCPDNMHDH.JIEDOFAPHFN));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						break;
					}
					goto case 2u;
				}
				goto case 1u;
			}
			return true;
		}

		public void IFLGJMJCOMC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object FMCLBOCENPE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ACDKCFGCBAB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AHFIDCCJHKE()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HKFEFDNFKKK()
		{
			throw new NotSupportedException();
		}

		public bool PMCFLKAJNHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				NMBKNILBINN = false;
				CMCLNPEBPHD = null;
				goto IL_003b;
			case 2u:
				if (DMPNHJPGIAO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(DMPNHJPGIAO.LOFMDBHAFAO(BJGCPDNMHDH.JIEDOFAPHFN));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				goto case 3u;
			case 3u:
				CMCLNPEBPHD = DMPNHJPGIAO;
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 4u:
				if (!(CMCLNPEBPHD != null) || !CMCLNPEBPHD.BKJLIIINJLG())
				{
					goto IL_003b;
				}
				goto case 1u;
			default:
				{
					return true;
				}
				IL_003b:
				if (CMCLNPEBPHD != null && CMCLNPEBPHD.DAPHOJDBHFE() && !CMCLNPEBPHD.KMAAKJEKFMJ())
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CMCLNPEBPHD.KKFMEGJAHIM(BJGCPDNMHDH.JIEDOFAPHFN));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				DMPNHJPGIAO = BJGCPDNMHDH.DLPDDBKMNPO(CMCLNPEBPHD);
				if (DMPNHJPGIAO != null && !NMBKNILBINN)
				{
					NMBKNILBINN = true;
					BJGCPDNMHDH.PFPAPBMLEIJ();
				}
				if (DMPNHJPGIAO == null && NMBKNILBINN)
				{
					NMBKNILBINN = false;
					BJGCPDNMHDH.AMGIODLLPHF();
				}
				if (CMCLNPEBPHD != DMPNHJPGIAO)
				{
					if (CMCLNPEBPHD != null)
					{
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CMCLNPEBPHD.GDLOAPIHMOB(BJGCPDNMHDH.JIEDOFAPHFN));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						break;
					}
					goto case 2u;
				}
				goto case 1u;
			}
			return false;
		}

		[SpecialName]
		private object NMGBFNNHIPN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FKKBFFHMEME()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BBHOODPMEFM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FFJBOMJMIAE()
		{
			return PHDOCKCBJOF;
		}

		public void HCHNHNDDKKA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void NINFHADPHJI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object DOOAHBLHGFO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GKJIGGAAHBE()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IHDBAJNCNGN()
		{
			return PHDOCKCBJOF;
		}

		public void KNFDMCEJHLB()
		{
			throw new NotSupportedException();
		}

		public bool HKPECDLGFJB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				NMBKNILBINN = true;
				CMCLNPEBPHD = null;
				goto IL_003b;
			case 2u:
				if (DMPNHJPGIAO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(DMPNHJPGIAO.Show(BJGCPDNMHDH.JIEDOFAPHFN));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				goto case 3u;
			case 3u:
				CMCLNPEBPHD = DMPNHJPGIAO;
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 4u:
				if (!(CMCLNPEBPHD != null) || !CMCLNPEBPHD.PDFDHAGAOEC())
				{
					goto IL_003b;
				}
				goto case 1u;
			default:
				{
					return true;
				}
				IL_003b:
				if (CMCLNPEBPHD != null && CMCLNPEBPHD.OKFFGJDBNFO() && !CMCLNPEBPHD.KAEGGLFKJHD())
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CMCLNPEBPHD.Change(BJGCPDNMHDH.JIEDOFAPHFN));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				DMPNHJPGIAO = BJGCPDNMHDH.PKOFJBJIOPH(CMCLNPEBPHD);
				if (DMPNHJPGIAO != null && !NMBKNILBINN)
				{
					NMBKNILBINN = true;
					BJGCPDNMHDH.BKELNHDKFGP();
				}
				if (DMPNHJPGIAO == null && NMBKNILBINN)
				{
					NMBKNILBINN = false;
					BJGCPDNMHDH.AFMCDEJCGIC();
				}
				if (CMCLNPEBPHD != DMPNHJPGIAO)
				{
					if (CMCLNPEBPHD != null)
					{
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CMCLNPEBPHD.OCAEJPMPBMH(BJGCPDNMHDH.JIEDOFAPHFN));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 4;
						}
						break;
					}
					goto case 2u;
				}
				goto case 1u;
			}
			return false;
		}

		public void HMBLLDJFIJG()
		{
			throw new NotSupportedException();
		}

		public void EFDJMHAPDLB()
		{
			throw new NotSupportedException();
		}

		public bool PMJICFJGOBE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				NMBKNILBINN = true;
				CMCLNPEBPHD = null;
				goto IL_003b;
			case 2u:
				if (DMPNHJPGIAO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(DMPNHJPGIAO.DMLDBKFCACB(BJGCPDNMHDH.JIEDOFAPHFN));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				goto case 3u;
			case 3u:
				CMCLNPEBPHD = DMPNHJPGIAO;
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 4u:
				if (!(CMCLNPEBPHD != null) || !CMCLNPEBPHD.JEOFLLBGGJB())
				{
					goto IL_003b;
				}
				goto case 1u;
			default:
				{
					return true;
				}
				IL_003b:
				if (CMCLNPEBPHD != null && CMCLNPEBPHD.OKFFGJDBNFO() && !CMCLNPEBPHD.KMAAKJEKFMJ())
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CMCLNPEBPHD.KKFMEGJAHIM(BJGCPDNMHDH.JIEDOFAPHFN));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				DMPNHJPGIAO = BJGCPDNMHDH.DLPDDBKMNPO(CMCLNPEBPHD);
				if (DMPNHJPGIAO != null && !NMBKNILBINN)
				{
					NMBKNILBINN = false;
					BJGCPDNMHDH.GJKKFBBLBJP();
				}
				if (DMPNHJPGIAO == null && NMBKNILBINN)
				{
					NMBKNILBINN = true;
					BJGCPDNMHDH.AMGIODLLPHF();
				}
				if (CMCLNPEBPHD != DMPNHJPGIAO)
				{
					if (CMCLNPEBPHD != null)
					{
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CMCLNPEBPHD.GDLOAPIHMOB(BJGCPDNMHDH.JIEDOFAPHFN));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 2;
						}
						break;
					}
					goto case 2u;
				}
				goto case 1u;
			}
			return true;
		}

		public bool BJBEBPMDICE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				NMBKNILBINN = true;
				CMCLNPEBPHD = null;
				goto IL_003b;
			case 2u:
				if (DMPNHJPGIAO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(DMPNHJPGIAO.LOFMDBHAFAO(BJGCPDNMHDH.JIEDOFAPHFN));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				goto case 3u;
			case 3u:
				CMCLNPEBPHD = DMPNHJPGIAO;
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 4u:
				if (!(CMCLNPEBPHD != null) || !CMCLNPEBPHD.DIEACOMHPOP())
				{
					goto IL_003b;
				}
				goto case 1u;
			default:
				{
					return true;
				}
				IL_003b:
				if (CMCLNPEBPHD != null && CMCLNPEBPHD.OKFFGJDBNFO() && !CMCLNPEBPHD.isLastLook)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CMCLNPEBPHD.KKFMEGJAHIM(BJGCPDNMHDH.JIEDOFAPHFN));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				DMPNHJPGIAO = BJGCPDNMHDH.PKOFJBJIOPH(CMCLNPEBPHD);
				if (DMPNHJPGIAO != null && !NMBKNILBINN)
				{
					NMBKNILBINN = false;
					BJGCPDNMHDH.JIJIKPCMEBD();
				}
				if (DMPNHJPGIAO == null && NMBKNILBINN)
				{
					NMBKNILBINN = false;
					BJGCPDNMHDH.MHHDCGDEGDD();
				}
				if (CMCLNPEBPHD != DMPNHJPGIAO)
				{
					if (CMCLNPEBPHD != null)
					{
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CMCLNPEBPHD.Hide(BJGCPDNMHDH.JIEDOFAPHFN));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 5;
						}
						break;
					}
					goto case 2u;
				}
				goto case 1u;
			}
			return false;
		}

		public bool CMBMOAECEJG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				NMBKNILBINN = false;
				CMCLNPEBPHD = null;
				goto IL_003b;
			case 2u:
				if (DMPNHJPGIAO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(DMPNHJPGIAO.DMLDBKFCACB(BJGCPDNMHDH.JIEDOFAPHFN));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				goto case 3u;
			case 3u:
				CMCLNPEBPHD = DMPNHJPGIAO;
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 4u:
				if (!(CMCLNPEBPHD != null) || !CMCLNPEBPHD.ANELGJOMCAB())
				{
					goto IL_003b;
				}
				goto case 1u;
			default:
				{
					return false;
				}
				IL_003b:
				if (CMCLNPEBPHD != null && CMCLNPEBPHD.hasMoreLooks && !CMCLNPEBPHD.KMAAKJEKFMJ())
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CMCLNPEBPHD.KKFMEGJAHIM(BJGCPDNMHDH.JIEDOFAPHFN));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				DMPNHJPGIAO = BJGCPDNMHDH.HCAIMEDJMND(CMCLNPEBPHD);
				if (DMPNHJPGIAO != null && !NMBKNILBINN)
				{
					NMBKNILBINN = true;
					BJGCPDNMHDH.MJDPDHBECHA();
				}
				if (DMPNHJPGIAO == null && NMBKNILBINN)
				{
					NMBKNILBINN = false;
					BJGCPDNMHDH.FHCIDOHMIMM();
				}
				if (CMCLNPEBPHD != DMPNHJPGIAO)
				{
					if (CMCLNPEBPHD != null)
					{
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CMCLNPEBPHD.NDODOLKAABG(BJGCPDNMHDH.JIEDOFAPHFN));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 4;
						}
						break;
					}
					goto case 2u;
				}
				goto case 1u;
			}
			return true;
		}

		[SpecialName]
		private object IAMNDODCIEB()
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
				NMBKNILBINN = true;
				CMCLNPEBPHD = null;
				goto IL_003b;
			case 2u:
				if (DMPNHJPGIAO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(DMPNHJPGIAO.Show(BJGCPDNMHDH.JIEDOFAPHFN));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				goto case 3u;
			case 3u:
				CMCLNPEBPHD = DMPNHJPGIAO;
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 4u:
				if (!(CMCLNPEBPHD != null) || !CMCLNPEBPHD.JEOFLLBGGJB())
				{
					goto IL_003b;
				}
				goto case 1u;
			default:
				{
					return false;
				}
				IL_003b:
				if (CMCLNPEBPHD != null && CMCLNPEBPHD.DAPHOJDBHFE() && !CMCLNPEBPHD.KAEGGLFKJHD())
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CMCLNPEBPHD.KKFMEGJAHIM(BJGCPDNMHDH.JIEDOFAPHFN));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				DMPNHJPGIAO = BJGCPDNMHDH.AMJEEKIGNJJ(CMCLNPEBPHD);
				if (DMPNHJPGIAO != null && !NMBKNILBINN)
				{
					NMBKNILBINN = false;
					BJGCPDNMHDH.MJDPDHBECHA();
				}
				if (DMPNHJPGIAO == null && NMBKNILBINN)
				{
					NMBKNILBINN = false;
					BJGCPDNMHDH.AMGIODLLPHF();
				}
				if (CMCLNPEBPHD != DMPNHJPGIAO)
				{
					if (CMCLNPEBPHD != null)
					{
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CMCLNPEBPHD.Hide(BJGCPDNMHDH.JIEDOFAPHFN));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 6;
						}
						break;
					}
					goto case 2u;
				}
				goto case 1u;
			}
			return true;
		}

		[SpecialName]
		private object GDCFFBBNGHH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JALKNCBEINE()
		{
			return PHDOCKCBJOF;
		}

		public void CPEDOIELFMP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GNFCCLCPCBO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MLDIMIPJMDD()
		{
			return PHDOCKCBJOF;
		}

		public void CPDBCJLIGFN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void CGCPMAHOJJC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool CCOPPEKLJOB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				NMBKNILBINN = false;
				CMCLNPEBPHD = null;
				goto IL_003b;
			case 2u:
				if (DMPNHJPGIAO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(DMPNHJPGIAO.DMLDBKFCACB(BJGCPDNMHDH.JIEDOFAPHFN));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				goto case 3u;
			case 3u:
				CMCLNPEBPHD = DMPNHJPGIAO;
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 4u:
				if (!(CMCLNPEBPHD != null) || !CMCLNPEBPHD.ANELGJOMCAB())
				{
					goto IL_003b;
				}
				goto case 1u;
			default:
				{
					return true;
				}
				IL_003b:
				if (CMCLNPEBPHD != null && CMCLNPEBPHD.HGBLICDJOHG() && !CMCLNPEBPHD.EIJJPCDHBMG())
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CMCLNPEBPHD.Change(BJGCPDNMHDH.JIEDOFAPHFN));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				DMPNHJPGIAO = BJGCPDNMHDH.HCAIMEDJMND(CMCLNPEBPHD);
				if (DMPNHJPGIAO != null && !NMBKNILBINN)
				{
					NMBKNILBINN = true;
					BJGCPDNMHDH.GJKKFBBLBJP();
				}
				if (DMPNHJPGIAO == null && NMBKNILBINN)
				{
					NMBKNILBINN = true;
					BJGCPDNMHDH.OPPBNIONNNI();
				}
				if (CMCLNPEBPHD != DMPNHJPGIAO)
				{
					if (CMCLNPEBPHD != null)
					{
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CMCLNPEBPHD.NDODOLKAABG(BJGCPDNMHDH.JIEDOFAPHFN));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 8;
						}
						break;
					}
					goto case 2u;
				}
				goto case 1u;
			}
			return true;
		}

		public void NPIDJAPKFLN()
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
				NMBKNILBINN = false;
				CMCLNPEBPHD = null;
				goto IL_003b;
			case 2u:
				if (DMPNHJPGIAO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(DMPNHJPGIAO.LOFMDBHAFAO(BJGCPDNMHDH.JIEDOFAPHFN));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 3u;
			case 3u:
				CMCLNPEBPHD = DMPNHJPGIAO;
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 4u:
				if (!(CMCLNPEBPHD != null) || !CMCLNPEBPHD.LNGFGGAGMJP())
				{
					goto IL_003b;
				}
				goto case 1u;
			default:
				{
					return true;
				}
				IL_003b:
				if (CMCLNPEBPHD != null && CMCLNPEBPHD.HGBLICDJOHG() && !CMCLNPEBPHD.HJMPIKCDJDP())
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CMCLNPEBPHD.KKFMEGJAHIM(BJGCPDNMHDH.JIEDOFAPHFN));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				DMPNHJPGIAO = BJGCPDNMHDH.AMJEEKIGNJJ(CMCLNPEBPHD);
				if (DMPNHJPGIAO != null && !NMBKNILBINN)
				{
					NMBKNILBINN = false;
					BJGCPDNMHDH.ODPCAKCPFHB();
				}
				if (DMPNHJPGIAO == null && NMBKNILBINN)
				{
					NMBKNILBINN = false;
					BJGCPDNMHDH.AIADDDGEHKO();
				}
				if (CMCLNPEBPHD != DMPNHJPGIAO)
				{
					if (CMCLNPEBPHD != null)
					{
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CMCLNPEBPHD.EPCEHACNCNH(BJGCPDNMHDH.JIEDOFAPHFN));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 2;
						}
						break;
					}
					goto case 2u;
				}
				goto case 1u;
			}
			return true;
		}

		public void FOBPOJPHNHE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BMGHJKFMKJE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AGCPJGAAODG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EFIEEKFCBJH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ABGFJLAPNNM()
		{
			return PHDOCKCBJOF;
		}

		public void KOEEOJGJNAO()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool DKJMOPNHIAB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				NMBKNILBINN = false;
				CMCLNPEBPHD = null;
				goto IL_003b;
			case 2u:
				if (DMPNHJPGIAO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(DMPNHJPGIAO.Show(BJGCPDNMHDH.JIEDOFAPHFN));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				goto case 3u;
			case 3u:
				CMCLNPEBPHD = DMPNHJPGIAO;
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 4u:
				if (!(CMCLNPEBPHD != null) || !CMCLNPEBPHD.JEOFLLBGGJB())
				{
					goto IL_003b;
				}
				goto case 1u;
			default:
				{
					return false;
				}
				IL_003b:
				if (CMCLNPEBPHD != null && CMCLNPEBPHD.hasMoreLooks && !CMCLNPEBPHD.isLastLook)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CMCLNPEBPHD.KKFMEGJAHIM(BJGCPDNMHDH.JIEDOFAPHFN));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				DMPNHJPGIAO = BJGCPDNMHDH.AALMOLBOHMP(CMCLNPEBPHD);
				if (DMPNHJPGIAO != null && !NMBKNILBINN)
				{
					NMBKNILBINN = false;
					BJGCPDNMHDH.GFMBOEEODKK();
				}
				if (DMPNHJPGIAO == null && NMBKNILBINN)
				{
					NMBKNILBINN = true;
					BJGCPDNMHDH.FPOOIDHDLKP();
				}
				if (CMCLNPEBPHD != DMPNHJPGIAO)
				{
					if (CMCLNPEBPHD != null)
					{
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CMCLNPEBPHD.OCAEJPMPBMH(BJGCPDNMHDH.JIEDOFAPHFN));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 4;
						}
						break;
					}
					goto case 2u;
				}
				goto case 1u;
			}
			return true;
		}

		public bool IJEDIDEJIII()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				NMBKNILBINN = false;
				CMCLNPEBPHD = null;
				goto IL_003b;
			case 2u:
				if (DMPNHJPGIAO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(DMPNHJPGIAO.ONCKKJFAMKF(BJGCPDNMHDH.JIEDOFAPHFN));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 3u;
			case 3u:
				CMCLNPEBPHD = DMPNHJPGIAO;
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 4u:
				if (!(CMCLNPEBPHD != null) || !CMCLNPEBPHD.IsShowTime())
				{
					goto IL_003b;
				}
				goto case 1u;
			default:
				{
					return false;
				}
				IL_003b:
				if (CMCLNPEBPHD != null && CMCLNPEBPHD.HGBLICDJOHG() && !CMCLNPEBPHD.EIJJPCDHBMG())
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CMCLNPEBPHD.Change(BJGCPDNMHDH.JIEDOFAPHFN));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				DMPNHJPGIAO = BJGCPDNMHDH.AMJEEKIGNJJ(CMCLNPEBPHD);
				if (DMPNHJPGIAO != null && !NMBKNILBINN)
				{
					NMBKNILBINN = false;
					BJGCPDNMHDH.MJDPDHBECHA();
				}
				if (DMPNHJPGIAO == null && NMBKNILBINN)
				{
					NMBKNILBINN = true;
					BJGCPDNMHDH.OPPBNIONNNI();
				}
				if (CMCLNPEBPHD != DMPNHJPGIAO)
				{
					if (CMCLNPEBPHD != null)
					{
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CMCLNPEBPHD.OMCADBPJEOL(BJGCPDNMHDH.JIEDOFAPHFN));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 6;
						}
						break;
					}
					goto case 2u;
				}
				goto case 1u;
			}
			return true;
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

		[SpecialName]
		private object OAKHGMKKFMN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GKDLMFPKKNM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NOIDHHDEEPL()
		{
			return PHDOCKCBJOF;
		}

		public void HLJMNBBDJGE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void KKDOJDCJAJB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void IDCJDJMGKFG()
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
				NMBKNILBINN = false;
				CMCLNPEBPHD = null;
				goto IL_003b;
			case 2u:
				if (DMPNHJPGIAO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(DMPNHJPGIAO.Show(BJGCPDNMHDH.JIEDOFAPHFN));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				goto case 3u;
			case 3u:
				CMCLNPEBPHD = DMPNHJPGIAO;
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 4u:
				if (!(CMCLNPEBPHD != null) || !CMCLNPEBPHD.IsShowTime())
				{
					goto IL_003b;
				}
				goto case 1u;
			default:
				{
					return false;
				}
				IL_003b:
				if (CMCLNPEBPHD != null && CMCLNPEBPHD.hasMoreLooks && !CMCLNPEBPHD.isLastLook)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CMCLNPEBPHD.Change(BJGCPDNMHDH.JIEDOFAPHFN));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				DMPNHJPGIAO = BJGCPDNMHDH.AALMOLBOHMP(CMCLNPEBPHD);
				if (DMPNHJPGIAO != null && !NMBKNILBINN)
				{
					NMBKNILBINN = true;
					BJGCPDNMHDH.CJLADAHONNK();
				}
				if (DMPNHJPGIAO == null && NMBKNILBINN)
				{
					NMBKNILBINN = false;
					BJGCPDNMHDH.AMGIODLLPHF();
				}
				if (CMCLNPEBPHD != DMPNHJPGIAO)
				{
					if (CMCLNPEBPHD != null)
					{
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CMCLNPEBPHD.Hide(BJGCPDNMHDH.JIEDOFAPHFN));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 2;
						}
						break;
					}
					goto case 2u;
				}
				goto case 1u;
			}
			return true;
		}

		public void FMOJMHBAHAA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public DPGECBFGBGI()
		{
		}

		public bool CIIHKFDLDKN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				NMBKNILBINN = false;
				CMCLNPEBPHD = null;
				goto IL_003b;
			case 2u:
				if (DMPNHJPGIAO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(DMPNHJPGIAO.DMLDBKFCACB(BJGCPDNMHDH.JIEDOFAPHFN));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 3u;
			case 3u:
				CMCLNPEBPHD = DMPNHJPGIAO;
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 4u:
				if (!(CMCLNPEBPHD != null) || !CMCLNPEBPHD.PDFDHAGAOEC())
				{
					goto IL_003b;
				}
				goto case 1u;
			default:
				{
					return true;
				}
				IL_003b:
				if (CMCLNPEBPHD != null && CMCLNPEBPHD.DAPHOJDBHFE() && !CMCLNPEBPHD.HJMPIKCDJDP())
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CMCLNPEBPHD.KKFMEGJAHIM(BJGCPDNMHDH.JIEDOFAPHFN));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				DMPNHJPGIAO = BJGCPDNMHDH.EBPJLEPGDAF(CMCLNPEBPHD);
				if (DMPNHJPGIAO != null && !NMBKNILBINN)
				{
					NMBKNILBINN = true;
					BJGCPDNMHDH.EDADDCCPMMP();
				}
				if (DMPNHJPGIAO == null && NMBKNILBINN)
				{
					NMBKNILBINN = true;
					BJGCPDNMHDH.FPOOIDHDLKP();
				}
				if (CMCLNPEBPHD != DMPNHJPGIAO)
				{
					if (CMCLNPEBPHD != null)
					{
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CMCLNPEBPHD.OCAEJPMPBMH(BJGCPDNMHDH.JIEDOFAPHFN));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						break;
					}
					goto case 2u;
				}
				goto case 1u;
			}
			return true;
		}

		public void GGLMLMFEJCD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HMIFLGCBDCO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IGMIIAODMNF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CLDLJNHAEAB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PIPMONHGDPH()
		{
			return PHDOCKCBJOF;
		}

		public void GIAIFFPNMPJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KIHECHEHNJJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FPFOODLPEBK()
		{
			return PHDOCKCBJOF;
		}

		public void JKBIMBFGGCO()
		{
			throw new NotSupportedException();
		}

		public void INBELBGOCLD()
		{
			throw new NotSupportedException();
		}

		public void EJNCMFMOBAJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KBNAGKKMLBP()
		{
			return PHDOCKCBJOF;
		}

		public void JGKDJGIANIG()
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
				NMBKNILBINN = false;
				CMCLNPEBPHD = null;
				goto IL_003b;
			case 2u:
				if (DMPNHJPGIAO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(DMPNHJPGIAO.ONCKKJFAMKF(BJGCPDNMHDH.JIEDOFAPHFN));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				goto case 3u;
			case 3u:
				CMCLNPEBPHD = DMPNHJPGIAO;
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 4u:
				if (!(CMCLNPEBPHD != null) || !CMCLNPEBPHD.ANELGJOMCAB())
				{
					goto IL_003b;
				}
				goto case 1u;
			default:
				{
					return false;
				}
				IL_003b:
				if (CMCLNPEBPHD != null && CMCLNPEBPHD.HGBLICDJOHG() && !CMCLNPEBPHD.isLastLook)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CMCLNPEBPHD.Change(BJGCPDNMHDH.JIEDOFAPHFN));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				DMPNHJPGIAO = BJGCPDNMHDH.EBPJLEPGDAF(CMCLNPEBPHD);
				if (DMPNHJPGIAO != null && !NMBKNILBINN)
				{
					NMBKNILBINN = true;
					BJGCPDNMHDH.GFMBOEEODKK();
				}
				if (DMPNHJPGIAO == null && NMBKNILBINN)
				{
					NMBKNILBINN = false;
					BJGCPDNMHDH.AIADDDGEHKO();
				}
				if (CMCLNPEBPHD != DMPNHJPGIAO)
				{
					if (CMCLNPEBPHD != null)
					{
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CMCLNPEBPHD.NDODOLKAABG(BJGCPDNMHDH.JIEDOFAPHFN));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						break;
					}
					goto case 2u;
				}
				goto case 1u;
			}
			return false;
		}

		[SpecialName]
		private object IHPDPKLEDKC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GAPDDGJNMPK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MDHGGDNNOAK()
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
				NMBKNILBINN = false;
				CMCLNPEBPHD = null;
				goto IL_003b;
			case 2u:
				if (DMPNHJPGIAO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(DMPNHJPGIAO.DMLDBKFCACB(BJGCPDNMHDH.JIEDOFAPHFN));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				goto case 3u;
			case 3u:
				CMCLNPEBPHD = DMPNHJPGIAO;
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 4u:
				if (!(CMCLNPEBPHD != null) || !CMCLNPEBPHD.PDFDHAGAOEC())
				{
					goto IL_003b;
				}
				goto case 1u;
			default:
				{
					return true;
				}
				IL_003b:
				if (CMCLNPEBPHD != null && CMCLNPEBPHD.FEBAKFHNHGB() && !CMCLNPEBPHD.isLastLook)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CMCLNPEBPHD.KKFMEGJAHIM(BJGCPDNMHDH.JIEDOFAPHFN));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				DMPNHJPGIAO = BJGCPDNMHDH.DLPDDBKMNPO(CMCLNPEBPHD);
				if (DMPNHJPGIAO != null && !NMBKNILBINN)
				{
					NMBKNILBINN = true;
					BJGCPDNMHDH.GGLONDBDIGK();
				}
				if (DMPNHJPGIAO == null && NMBKNILBINN)
				{
					NMBKNILBINN = false;
					BJGCPDNMHDH.FPOOIDHDLKP();
				}
				if (CMCLNPEBPHD != DMPNHJPGIAO)
				{
					if (CMCLNPEBPHD != null)
					{
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CMCLNPEBPHD.Hide(BJGCPDNMHDH.JIEDOFAPHFN));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 6;
						}
						break;
					}
					goto case 2u;
				}
				goto case 1u;
			}
			return true;
		}

		[SpecialName]
		private object CLFFFNGBPGJ()
		{
			return PHDOCKCBJOF;
		}

		public void MEBPMHDHIPJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object LGDOCMENCOG()
		{
			return PHDOCKCBJOF;
		}

		public void OGHELMDBPIL()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object EKJDPPIGKCF()
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
				NMBKNILBINN = true;
				CMCLNPEBPHD = null;
				goto IL_003b;
			case 2u:
				if (DMPNHJPGIAO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(DMPNHJPGIAO.ONCKKJFAMKF(BJGCPDNMHDH.JIEDOFAPHFN));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				goto case 3u;
			case 3u:
				CMCLNPEBPHD = DMPNHJPGIAO;
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 4u:
				if (!(CMCLNPEBPHD != null) || !CMCLNPEBPHD.JEOFLLBGGJB())
				{
					goto IL_003b;
				}
				goto case 1u;
			default:
				{
					return false;
				}
				IL_003b:
				if (CMCLNPEBPHD != null && CMCLNPEBPHD.DAPHOJDBHFE() && !CMCLNPEBPHD.EIJJPCDHBMG())
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CMCLNPEBPHD.Change(BJGCPDNMHDH.JIEDOFAPHFN));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				DMPNHJPGIAO = BJGCPDNMHDH.AMJEEKIGNJJ(CMCLNPEBPHD);
				if (DMPNHJPGIAO != null && !NMBKNILBINN)
				{
					NMBKNILBINN = true;
					BJGCPDNMHDH.JIJIKPCMEBD();
				}
				if (DMPNHJPGIAO == null && NMBKNILBINN)
				{
					NMBKNILBINN = false;
					BJGCPDNMHDH.MHHDCGDEGDD();
				}
				if (CMCLNPEBPHD != DMPNHJPGIAO)
				{
					if (CMCLNPEBPHD != null)
					{
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CMCLNPEBPHD.GDLOAPIHMOB(BJGCPDNMHDH.JIEDOFAPHFN));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 7;
						}
						break;
					}
					goto case 2u;
				}
				goto case 1u;
			}
			return false;
		}

		public void LBNGPPPKLHI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object LMBPPPOFIOC()
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
				NMBKNILBINN = false;
				CMCLNPEBPHD = null;
				goto IL_003b;
			case 2u:
				if (DMPNHJPGIAO != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(DMPNHJPGIAO.Show(BJGCPDNMHDH.JIEDOFAPHFN));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				goto case 3u;
			case 3u:
				CMCLNPEBPHD = DMPNHJPGIAO;
				goto case 1u;
			case 1u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 4u:
				if (!(CMCLNPEBPHD != null) || !CMCLNPEBPHD.BKJLIIINJLG())
				{
					goto IL_003b;
				}
				goto case 1u;
			default:
				{
					return true;
				}
				IL_003b:
				if (CMCLNPEBPHD != null && CMCLNPEBPHD.FEBAKFHNHGB() && !CMCLNPEBPHD.HJMPIKCDJDP())
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CMCLNPEBPHD.Change(BJGCPDNMHDH.JIEDOFAPHFN));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				DMPNHJPGIAO = BJGCPDNMHDH.AMJEEKIGNJJ(CMCLNPEBPHD);
				if (DMPNHJPGIAO != null && !NMBKNILBINN)
				{
					NMBKNILBINN = true;
					BJGCPDNMHDH.IEABHFCEOAH();
				}
				if (DMPNHJPGIAO == null && NMBKNILBINN)
				{
					NMBKNILBINN = false;
					BJGCPDNMHDH.FHCIDOHMIMM();
				}
				if (CMCLNPEBPHD != DMPNHJPGIAO)
				{
					if (CMCLNPEBPHD != null)
					{
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CMCLNPEBPHD.Hide(BJGCPDNMHDH.JIEDOFAPHFN));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 5;
						}
						break;
					}
					goto case 2u;
				}
				goto case 1u;
			}
			return true;
		}

		[SpecialName]
		private object CICPCKDCCEF()
		{
			return PHDOCKCBJOF;
		}
	}

	[Header("Background")]
	[FormerlySerializedAs("MADEDKKBOIH")]
	public UISprite GJIGEFJAKNM;

	[FormerlySerializedAs("JHAGKDBCJIB")]
	public UISprite FNGFNNOIOCD;

	[FormerlySerializedAs("GIMMLMFBMEI")]
	public UISprite KMFGCJEGJJK;

	[Header("Deals")]
	[FormerlySerializedAs("MFIFBBMIAFD")]
	public List<IntroductionDealsItem> IFDPIFMKOIA;

	[Header("Parameters")]
	[FormerlySerializedAs("PHHNBDGFHCL")]
	public float JIEDOFAPHFN = 0.3f;

	[FormerlySerializedAs("BJPLHKNBIKJ")]
	public float KJHOLALIGAC = 0.35f;

	private RadicalRoutine GKHOMBPNBHC;

	public void CCFJENHGIMN()
	{
		foreach (IntroductionDealsItem iFDPIFMKOIum in IFDPIFMKOIA)
		{
			iFDPIFMKOIum.gameObject.SetActive(value: false);
			iFDPIFMKOIum.KBALFNMGIOA();
		}
	}

	private void AMGIODLLPHF()
	{
		TweenAlpha.Begin(GJIGEFJAKNM.gameObject, KJHOLALIGAC, 0f);
		TweenAlpha.Begin(FNGFNNOIOCD.gameObject, KJHOLALIGAC, 0f);
		TweenAlpha.Begin(KMFGCJEGJJK.gameObject, KJHOLALIGAC, 0f);
	}

	public void HBMEBODGOHH()
	{
		foreach (IntroductionDealsItem iFDPIFMKOIum in IFDPIFMKOIA)
		{
			iFDPIFMKOIum.gameObject.SetActive(value: true);
			iFDPIFMKOIum.KBALFNMGIOA();
		}
	}

	public void NEEAKMELPBJ()
	{
		BKAAFILGLIE();
	}

	private IEnumerator NPLPPONHDOO()
	{
		DPGECBFGBGI dPGECBFGBGI = new DPGECBFGBGI();
		dPGECBFGBGI.BJGCPDNMHDH = this;
		return dPGECBFGBGI;
	}

	private void HDKCFAMJBBO()
	{
		GKHOMBPNBHC = RadicalRoutine.Create(IAFDEDEDAID());
		StartCoroutine(RadicalRoutine.Run(GKHOMBPNBHC.enumerator));
	}

	public void KPIPIEIEPLC()
	{
		foreach (IntroductionDealsItem iFDPIFMKOIum in IFDPIFMKOIA)
		{
			iFDPIFMKOIum.gameObject.SetActive(value: true);
			iFDPIFMKOIum.InitEvents();
		}
	}

	private void MGKMBCBBOHK()
	{
		GKHOMBPNBHC = RadicalRoutine.Create(AJPOOAHKAFG());
		StartCoroutine(RadicalRoutine.Run(GKHOMBPNBHC.enumerator));
	}

	public void PLDAPLOGJPA()
	{
		foreach (IntroductionDealsItem iFDPIFMKOIum in IFDPIFMKOIA)
		{
			iFDPIFMKOIum.gameObject.SetActive(value: true);
			iFDPIFMKOIum.InitEvents();
		}
	}

	private IntroductionDealsItem EBPJLEPGDAF(IntroductionDealsItem NFDJCGOPOEO)
	{
		int num = IFDPIFMKOIA.IndexOf(NFDJCGOPOEO);
		num += 0;
		for (int i = 0; i < IFDPIFMKOIA.Count; i += 0)
		{
			IntroductionDealsItem introductionDealsItem = IFDPIFMKOIA[(num + i) % IFDPIFMKOIA.Count];
			if (introductionDealsItem.EOJDPCMGMBP())
			{
				return introductionDealsItem;
			}
		}
		return null;
	}

	public void InitGuiValues()
	{
		if (IFDPIFMKOIA == null)
		{
			return;
		}
		foreach (IntroductionDealsItem iFDPIFMKOIum in IFDPIFMKOIA)
		{
			if (iFDPIFMKOIum == null)
			{
				continue;
			}
			iFDPIFMKOIum.gameObject.SetActive(value: true);
			iFDPIFMKOIum.InitGuiValues();
		}
	}

	public void NNGDAMJFDBG()
	{
		foreach (IntroductionDealsItem iFDPIFMKOIum in IFDPIFMKOIA)
		{
			iFDPIFMKOIum.gameObject.SetActive(value: false);
			iFDPIFMKOIum.InitEvents();
		}
	}

	private void ENHDEGCEAPM()
	{
		if (GKHOMBPNBHC != null)
		{
			GKHOMBPNBHC.Cancel();
		}
		foreach (IntroductionDealsItem iFDPIFMKOIum in IFDPIFMKOIA)
		{
			StartCoroutine(iFDPIFMKOIum.GDLOAPIHMOB(820f));
		}
		AFMCDEJCGIC();
	}

	public void OOBJHJLMEED()
	{
		LEGJDOEKBCF();
		foreach (IntroductionDealsItem iFDPIFMKOIum in IFDPIFMKOIA)
		{
			iFDPIFMKOIum.gameObject.SetActive(value: false);
			iFDPIFMKOIum.MEHAKDFBGJN();
		}
	}

	private void PFPAPBMLEIJ()
	{
		TweenAlpha.Begin(GJIGEFJAKNM.gameObject, KJHOLALIGAC, 27f);
		TweenAlpha.Begin(FNGFNNOIOCD.gameObject, KJHOLALIGAC, 168f);
		TweenAlpha.Begin(KMFGCJEGJJK.gameObject, KJHOLALIGAC, 569f);
	}

	private void CJLADAHONNK()
	{
		TweenAlpha.Begin(GJIGEFJAKNM.gameObject, KJHOLALIGAC, 0.81f);
		TweenAlpha.Begin(FNGFNNOIOCD.gameObject, KJHOLALIGAC, 0.81f);
		TweenAlpha.Begin(KMFGCJEGJJK.gameObject, KJHOLALIGAC, 0.5f);
	}

	public void JFKIJCDGJLF()
	{
		foreach (IntroductionDealsItem iFDPIFMKOIum in IFDPIFMKOIA)
		{
			iFDPIFMKOIum.gameObject.SetActive(value: false);
			iFDPIFMKOIum.InitGuiValues();
		}
	}

	public void InitControls()
	{
		AMGIODLLPHF();
		if (IFDPIFMKOIA == null)
		{
			return;
		}
		foreach (IntroductionDealsItem iFDPIFMKOIum in IFDPIFMKOIA)
		{
			if (iFDPIFMKOIum == null)
			{
				continue;
			}
			iFDPIFMKOIum.gameObject.SetActive(value: true);
			iFDPIFMKOIum.InitControls();
		}
	}

	private void JIJIKPCMEBD()
	{
		TweenAlpha.Begin(GJIGEFJAKNM.gameObject, KJHOLALIGAC, 1759f);
		TweenAlpha.Begin(FNGFNNOIOCD.gameObject, KJHOLALIGAC, 1515f);
		TweenAlpha.Begin(KMFGCJEGJJK.gameObject, KJHOLALIGAC, 423f);
	}

	public void NDLGLAIMIEO()
	{
		foreach (IntroductionDealsItem iFDPIFMKOIum in IFDPIFMKOIA)
		{
			iFDPIFMKOIum.gameObject.SetActive(value: false);
			iFDPIFMKOIum.InitEvents();
		}
	}

	public void MMGLJEAHKPD()
	{
		foreach (IntroductionDealsItem iFDPIFMKOIum in IFDPIFMKOIA)
		{
			StartCoroutine(iFDPIFMKOIum.EPCEHACNCNH(480f));
		}
		EKNDHCNIJFG();
	}

	private IntroductionDealsItem DLPDDBKMNPO(IntroductionDealsItem NFDJCGOPOEO)
	{
		int num = IFDPIFMKOIA.IndexOf(NFDJCGOPOEO);
		num += 0;
		for (int i = 1; i < IFDPIFMKOIA.Count; i += 0)
		{
			IntroductionDealsItem introductionDealsItem = IFDPIFMKOIA[(num + i) % IFDPIFMKOIA.Count];
			if (introductionDealsItem.EOJDPCMGMBP())
			{
				return introductionDealsItem;
			}
		}
		return null;
	}

	public void OILPJONILBG()
	{
		ODNENECJFII();
		foreach (IntroductionDealsItem iFDPIFMKOIum in IFDPIFMKOIA)
		{
			iFDPIFMKOIum.gameObject.SetActive(value: false);
			iFDPIFMKOIum.InitControls();
		}
	}

	private void EDADDCCPMMP()
	{
		TweenAlpha.Begin(GJIGEFJAKNM.gameObject, KJHOLALIGAC, 1238f);
		TweenAlpha.Begin(FNGFNNOIOCD.gameObject, KJHOLALIGAC, 1475f);
		TweenAlpha.Begin(KMFGCJEGJJK.gameObject, KJHOLALIGAC, 400f);
	}

	public void LNNPGJPEEIP()
	{
		foreach (IntroductionDealsItem iFDPIFMKOIum in IFDPIFMKOIA)
		{
			iFDPIFMKOIum.gameObject.SetActive(value: false);
			iFDPIFMKOIum.InitEvents();
		}
	}

	public void IDPNONPEBPO()
	{
		GOLNNLNFLEI();
	}

	private void GEKIMGFKNHC()
	{
		GKHOMBPNBHC = RadicalRoutine.Create(LFDKLGIJNGL());
		StartCoroutine(RadicalRoutine.Run(GKHOMBPNBHC.enumerator));
	}

	private IntroductionDealsItem AMJEEKIGNJJ(IntroductionDealsItem NFDJCGOPOEO)
	{
		int num = IFDPIFMKOIA.IndexOf(NFDJCGOPOEO);
		num += 0;
		for (int i = 0; i < IFDPIFMKOIA.Count; i += 0)
		{
			IntroductionDealsItem introductionDealsItem = IFDPIFMKOIA[(num + i) % IFDPIFMKOIA.Count];
			if (introductionDealsItem.EOJDPCMGMBP())
			{
				return introductionDealsItem;
			}
		}
		return null;
	}

	private void GFMBOEEODKK()
	{
		TweenAlpha.Begin(GJIGEFJAKNM.gameObject, KJHOLALIGAC, 1412f);
		TweenAlpha.Begin(FNGFNNOIOCD.gameObject, KJHOLALIGAC, 1369f);
		TweenAlpha.Begin(KMFGCJEGJJK.gameObject, KJHOLALIGAC, 170f);
	}

	private IntroductionDealsItem AALMOLBOHMP(IntroductionDealsItem NFDJCGOPOEO)
	{
		int num = IFDPIFMKOIA.IndexOf(NFDJCGOPOEO);
		num++;
		for (int i = 0; i < IFDPIFMKOIA.Count; i++)
		{
			IntroductionDealsItem introductionDealsItem = IFDPIFMKOIA[(num + i) % IFDPIFMKOIA.Count];
			if (introductionDealsItem.IsAvailable())
			{
				return introductionDealsItem;
			}
		}
		return null;
	}

	public void HLJOIPOIOBO()
	{
		ENHDEGCEAPM();
	}

	public void GGFCEDLIFNI()
	{
		BILIFMOOBOM();
	}

	private void IEABHFCEOAH()
	{
		TweenAlpha.Begin(GJIGEFJAKNM.gameObject, KJHOLALIGAC, 461f);
		TweenAlpha.Begin(FNGFNNOIOCD.gameObject, KJHOLALIGAC, 1586f);
		TweenAlpha.Begin(KMFGCJEGJJK.gameObject, KJHOLALIGAC, 1206f);
	}

	private void DONHNAIKMCB()
	{
		GKHOMBPNBHC = RadicalRoutine.Create(ICPKGMKDMNH());
		StartCoroutine(RadicalRoutine.Run(GKHOMBPNBHC.enumerator));
	}

	public void ILCKGHGDDJA()
	{
		OPPBNIONNNI();
		foreach (IntroductionDealsItem iFDPIFMKOIum in IFDPIFMKOIA)
		{
			iFDPIFMKOIum.gameObject.SetActive(value: true);
			iFDPIFMKOIum.InitControls();
		}
	}

	private void MJDPDHBECHA()
	{
		TweenAlpha.Begin(GJIGEFJAKNM.gameObject, KJHOLALIGAC, 635f);
		TweenAlpha.Begin(FNGFNNOIOCD.gameObject, KJHOLALIGAC, 1185f);
		TweenAlpha.Begin(KMFGCJEGJJK.gameObject, KJHOLALIGAC, 1562f);
	}

	private IEnumerator ICPKGMKDMNH()
	{
		DPGECBFGBGI dPGECBFGBGI = new DPGECBFGBGI();
		dPGECBFGBGI.BJGCPDNMHDH = this;
		return dPGECBFGBGI;
	}

	public void MCFOGHKDCHL()
	{
		foreach (IntroductionDealsItem iFDPIFMKOIum in IFDPIFMKOIA)
		{
			iFDPIFMKOIum.gameObject.SetActive(value: false);
			iFDPIFMKOIum.KBALFNMGIOA();
		}
	}

	[DebuggerHidden]
	private IEnumerator LFDKLGIJNGL()
	{
		DPGECBFGBGI dPGECBFGBGI = new DPGECBFGBGI();
		dPGECBFGBGI.BJGCPDNMHDH = this;
		return dPGECBFGBGI;
	}

	public void NFNDGHPDMDN()
	{
		IFGMJHLIPJL();
	}

	public void OIECDPBEKNH()
	{
		foreach (IntroductionDealsItem iFDPIFMKOIum in IFDPIFMKOIA)
		{
			StartCoroutine(iFDPIFMKOIum.Hide(1080f));
		}
		MNLAIHAPJOA();
	}

	private void DDJFNDIDCGD()
	{
		TweenAlpha.Begin(GJIGEFJAKNM.gameObject, KJHOLALIGAC, 1965f);
		TweenAlpha.Begin(FNGFNNOIOCD.gameObject, KJHOLALIGAC, 350f);
		TweenAlpha.Begin(KMFGCJEGJJK.gameObject, KJHOLALIGAC, 609f);
	}

	private void FHCIDOHMIMM()
	{
		TweenAlpha.Begin(GJIGEFJAKNM.gameObject, KJHOLALIGAC, 1532f);
		TweenAlpha.Begin(FNGFNNOIOCD.gameObject, KJHOLALIGAC, 1435f);
		TweenAlpha.Begin(KMFGCJEGJJK.gameObject, KJHOLALIGAC, 456f);
	}

	public void IGIOAPCEGMN()
	{
		foreach (IntroductionDealsItem iFDPIFMKOIum in IFDPIFMKOIA)
		{
			iFDPIFMKOIum.gameObject.SetActive(value: true);
			iFDPIFMKOIum.InitEvents();
		}
	}

	private void MHHDCGDEGDD()
	{
		TweenAlpha.Begin(GJIGEFJAKNM.gameObject, KJHOLALIGAC, 1418f);
		TweenAlpha.Begin(FNGFNNOIOCD.gameObject, KJHOLALIGAC, 1297f);
		TweenAlpha.Begin(KMFGCJEGJJK.gameObject, KJHOLALIGAC, 1242f);
	}

	public void HAOFBOPJBEI()
	{
		foreach (IntroductionDealsItem iFDPIFMKOIum in IFDPIFMKOIA)
		{
			iFDPIFMKOIum.gameObject.SetActive(value: false);
			iFDPIFMKOIum.InitEvents();
		}
	}

	private void FMOMJJEFLMF()
	{
		TweenAlpha.Begin(GJIGEFJAKNM.gameObject, KJHOLALIGAC, 1959f);
		TweenAlpha.Begin(FNGFNNOIOCD.gameObject, KJHOLALIGAC, 1834f);
		TweenAlpha.Begin(KMFGCJEGJJK.gameObject, KJHOLALIGAC, 949f);
	}

	public void GICCBEJKDNL()
	{
		foreach (IntroductionDealsItem iFDPIFMKOIum in IFDPIFMKOIA)
		{
			iFDPIFMKOIum.gameObject.SetActive(value: false);
			iFDPIFMKOIum.InitGuiValues();
		}
	}

	public void HDGJHGPACIF()
	{
		foreach (IntroductionDealsItem iFDPIFMKOIum in IFDPIFMKOIA)
		{
			StartCoroutine(iFDPIFMKOIum.Hide(707f));
		}
		MGKMBCBBOHK();
	}

	public void LCBOBKAKAKN()
	{
		foreach (IntroductionDealsItem iFDPIFMKOIum in IFDPIFMKOIA)
		{
			iFDPIFMKOIum.gameObject.SetActive(value: false);
			iFDPIFMKOIum.KBALFNMGIOA();
		}
	}

	public void NGOMHEHCDMG()
	{
		foreach (IntroductionDealsItem iFDPIFMKOIum in IFDPIFMKOIA)
		{
			iFDPIFMKOIum.gameObject.SetActive(value: false);
			iFDPIFMKOIum.InitGuiValues();
		}
	}

	private void ADHNJJLHFEN()
	{
		TweenAlpha.Begin(GJIGEFJAKNM.gameObject, KJHOLALIGAC, 1488f);
		TweenAlpha.Begin(FNGFNNOIOCD.gameObject, KJHOLALIGAC, 1413f);
		TweenAlpha.Begin(KMFGCJEGJJK.gameObject, KJHOLALIGAC, 384f);
	}

	public void AnimateShow()
	{
		foreach (IntroductionDealsItem iFDPIFMKOIum in IFDPIFMKOIA)
		{
			StartCoroutine(iFDPIFMKOIum.Hide(0f));
		}
		GEKIMGFKNHC();
	}

	public void KBALFNMGIOA()
	{
		foreach (IntroductionDealsItem iFDPIFMKOIum in IFDPIFMKOIA)
		{
			iFDPIFMKOIum.gameObject.SetActive(value: false);
			iFDPIFMKOIum.InitGuiValues();
		}
	}

	public void KHKJNFHNGHM()
	{
		NMBHFCGOKMK();
	}

	private IEnumerator AJPOOAHKAFG()
	{
		DPGECBFGBGI dPGECBFGBGI = new DPGECBFGBGI();
		dPGECBFGBGI.BJGCPDNMHDH = this;
		return dPGECBFGBGI;
	}

	private void LFAIBCHJFGP()
	{
		TweenAlpha.Begin(GJIGEFJAKNM.gameObject, KJHOLALIGAC, 1474f);
		TweenAlpha.Begin(FNGFNNOIOCD.gameObject, KJHOLALIGAC, 260f);
		TweenAlpha.Begin(KMFGCJEGJJK.gameObject, KJHOLALIGAC, 787f);
	}

	public void BGJHODBOGAN()
	{
		ENHDEGCEAPM();
	}

	private void BKELNHDKFGP()
	{
		TweenAlpha.Begin(GJIGEFJAKNM.gameObject, KJHOLALIGAC, 512f);
		TweenAlpha.Begin(FNGFNNOIOCD.gameObject, KJHOLALIGAC, 1893f);
		TweenAlpha.Begin(KMFGCJEGJJK.gameObject, KJHOLALIGAC, 646f);
	}

	private void KIKIIHKDDNE()
	{
		TweenAlpha.Begin(GJIGEFJAKNM.gameObject, KJHOLALIGAC, 1012f);
		TweenAlpha.Begin(FNGFNNOIOCD.gameObject, KJHOLALIGAC, 1031f);
		TweenAlpha.Begin(KMFGCJEGJJK.gameObject, KJHOLALIGAC, 319f);
	}

	private void DJBCPGABIPC()
	{
		TweenAlpha.Begin(GJIGEFJAKNM.gameObject, KJHOLALIGAC, 802f);
		TweenAlpha.Begin(FNGFNNOIOCD.gameObject, KJHOLALIGAC, 1335f);
		TweenAlpha.Begin(KMFGCJEGJJK.gameObject, KJHOLALIGAC, 1734f);
	}

	private void AFMCDEJCGIC()
	{
		TweenAlpha.Begin(GJIGEFJAKNM.gameObject, KJHOLALIGAC, 745f);
		TweenAlpha.Begin(FNGFNNOIOCD.gameObject, KJHOLALIGAC, 366f);
		TweenAlpha.Begin(KMFGCJEGJJK.gameObject, KJHOLALIGAC, 1833f);
	}

	private void BILIFMOOBOM()
	{
		if (GKHOMBPNBHC != null)
		{
			GKHOMBPNBHC.Cancel();
		}
		foreach (IntroductionDealsItem iFDPIFMKOIum in IFDPIFMKOIA)
		{
			StartCoroutine(iFDPIFMKOIum.Hide(0f));
		}
		AMGIODLLPHF();
	}

	private void BKAAFILGLIE()
	{
		if (GKHOMBPNBHC != null)
		{
			GKHOMBPNBHC.Cancel();
		}
		foreach (IntroductionDealsItem iFDPIFMKOIum in IFDPIFMKOIA)
		{
			StartCoroutine(iFDPIFMKOIum.Hide(760f));
		}
		MHHDCGDEGDD();
	}

	private void AIADDDGEHKO()
	{
		TweenAlpha.Begin(GJIGEFJAKNM.gameObject, KJHOLALIGAC, 1408f);
		TweenAlpha.Begin(FNGFNNOIOCD.gameObject, KJHOLALIGAC, 906f);
		TweenAlpha.Begin(KMFGCJEGJJK.gameObject, KJHOLALIGAC, 1341f);
	}

	public void CEAHALCLDNE()
	{
		IFGMJHLIPJL();
	}

	private IEnumerator IAFDEDEDAID()
	{
		DPGECBFGBGI dPGECBFGBGI = new DPGECBFGBGI();
		dPGECBFGBGI.BJGCPDNMHDH = this;
		return dPGECBFGBGI;
	}

	private void GGLONDBDIGK()
	{
		TweenAlpha.Begin(GJIGEFJAKNM.gameObject, KJHOLALIGAC, 1107f);
		TweenAlpha.Begin(FNGFNNOIOCD.gameObject, KJHOLALIGAC, 1425f);
		TweenAlpha.Begin(KMFGCJEGJJK.gameObject, KJHOLALIGAC, 1190f);
	}

	public void InitEvents()
	{
		if (IFDPIFMKOIA == null)
		{
			return;
		}
		foreach (IntroductionDealsItem iFDPIFMKOIum in IFDPIFMKOIA)
		{
			if (iFDPIFMKOIum == null)
			{
				continue;
			}
			iFDPIFMKOIum.gameObject.SetActive(value: true);
			iFDPIFMKOIum.InitEvents();
		}
	}

	private void OPPBNIONNNI()
	{
		TweenAlpha.Begin(GJIGEFJAKNM.gameObject, KJHOLALIGAC, 1780f);
		TweenAlpha.Begin(FNGFNNOIOCD.gameObject, KJHOLALIGAC, 1624f);
		TweenAlpha.Begin(KMFGCJEGJJK.gameObject, KJHOLALIGAC, 1754f);
	}

	private void ODNENECJFII()
	{
		TweenAlpha.Begin(GJIGEFJAKNM.gameObject, KJHOLALIGAC, 932f);
		TweenAlpha.Begin(FNGFNNOIOCD.gameObject, KJHOLALIGAC, 673f);
		TweenAlpha.Begin(KMFGCJEGJJK.gameObject, KJHOLALIGAC, 1892f);
	}

	private void LEGJDOEKBCF()
	{
		TweenAlpha.Begin(GJIGEFJAKNM.gameObject, KJHOLALIGAC, 1802f);
		TweenAlpha.Begin(FNGFNNOIOCD.gameObject, KJHOLALIGAC, 1607f);
		TweenAlpha.Begin(KMFGCJEGJJK.gameObject, KJHOLALIGAC, 245f);
	}

	public void DoBeforeHide()
	{
		BILIFMOOBOM();
	}

	private IEnumerator BMPIJEEINCJ()
	{
		DPGECBFGBGI dPGECBFGBGI = new DPGECBFGBGI();
		dPGECBFGBGI.BJGCPDNMHDH = this;
		return dPGECBFGBGI;
	}

	private void NMBHFCGOKMK()
	{
		if (GKHOMBPNBHC != null)
		{
			GKHOMBPNBHC.Cancel();
		}
		foreach (IntroductionDealsItem iFDPIFMKOIum in IFDPIFMKOIA)
		{
			StartCoroutine(iFDPIFMKOIum.NDODOLKAABG(1921f));
		}
		AFMCDEJCGIC();
	}

	private void ODPCAKCPFHB()
	{
		TweenAlpha.Begin(GJIGEFJAKNM.gameObject, KJHOLALIGAC, 400f);
		TweenAlpha.Begin(FNGFNNOIOCD.gameObject, KJHOLALIGAC, 1587f);
		TweenAlpha.Begin(KMFGCJEGJJK.gameObject, KJHOLALIGAC, 1841f);
	}

	private void GOLNNLNFLEI()
	{
		if (GKHOMBPNBHC != null)
		{
			GKHOMBPNBHC.Cancel();
		}
		foreach (IntroductionDealsItem iFDPIFMKOIum in IFDPIFMKOIA)
		{
			StartCoroutine(iFDPIFMKOIum.GDLOAPIHMOB(1374f));
		}
		DDJFNDIDCGD();
	}

	private IntroductionDealsItem HCAIMEDJMND(IntroductionDealsItem NFDJCGOPOEO)
	{
		int num = IFDPIFMKOIA.IndexOf(NFDJCGOPOEO);
		num++;
		for (int i = 1; i < IFDPIFMKOIA.Count; i += 0)
		{
			IntroductionDealsItem introductionDealsItem = IFDPIFMKOIA[(num + i) % IFDPIFMKOIA.Count];
			if (introductionDealsItem.KPEHFFDDDKD())
			{
				return introductionDealsItem;
			}
		}
		return null;
	}

	public void LBHEIOEPJLJ()
	{
		LEGJDOEKBCF();
		foreach (IntroductionDealsItem iFDPIFMKOIum in IFDPIFMKOIA)
		{
			iFDPIFMKOIum.gameObject.SetActive(value: false);
			iFDPIFMKOIum.FHINGMFHKLG();
		}
	}

	public void PLLNFBOKOFK()
	{
		foreach (IntroductionDealsItem iFDPIFMKOIum in IFDPIFMKOIA)
		{
			StartCoroutine(iFDPIFMKOIum.GDLOAPIHMOB(964f));
		}
		FAFEGBECEEM();
	}

	private void GJKKFBBLBJP()
	{
		TweenAlpha.Begin(GJIGEFJAKNM.gameObject, KJHOLALIGAC, 1228f);
		TweenAlpha.Begin(FNGFNNOIOCD.gameObject, KJHOLALIGAC, 397f);
		TweenAlpha.Begin(KMFGCJEGJJK.gameObject, KJHOLALIGAC, 192f);
	}

	private void FPOOIDHDLKP()
	{
		TweenAlpha.Begin(GJIGEFJAKNM.gameObject, KJHOLALIGAC, 242f);
		TweenAlpha.Begin(FNGFNNOIOCD.gameObject, KJHOLALIGAC, 1249f);
		TweenAlpha.Begin(KMFGCJEGJJK.gameObject, KJHOLALIGAC, 519f);
	}

	private void MNLAIHAPJOA()
	{
		GKHOMBPNBHC = RadicalRoutine.Create(NPLPPONHDOO());
		StartCoroutine(RadicalRoutine.Run(GKHOMBPNBHC.enumerator));
	}

	private void DFJBBKKIPAD()
	{
		GKHOMBPNBHC = RadicalRoutine.Create(NPLPPONHDOO());
		StartCoroutine(RadicalRoutine.Run(GKHOMBPNBHC.enumerator));
	}

	private void FAFEGBECEEM()
	{
		GKHOMBPNBHC = RadicalRoutine.Create(AJPOOAHKAFG());
		StartCoroutine(RadicalRoutine.Run(GKHOMBPNBHC.enumerator));
	}

	private IntroductionDealsItem PKOFJBJIOPH(IntroductionDealsItem NFDJCGOPOEO)
	{
		int num = IFDPIFMKOIA.IndexOf(NFDJCGOPOEO);
		num++;
		for (int i = 1; i < IFDPIFMKOIA.Count; i += 0)
		{
			IntroductionDealsItem introductionDealsItem = IFDPIFMKOIA[(num + i) % IFDPIFMKOIA.Count];
			if (introductionDealsItem.KPEHFFDDDKD())
			{
				return introductionDealsItem;
			}
		}
		return null;
	}

	private void IFGMJHLIPJL()
	{
		if (GKHOMBPNBHC != null)
		{
			GKHOMBPNBHC.Cancel();
		}
		foreach (IntroductionDealsItem iFDPIFMKOIum in IFDPIFMKOIA)
		{
			StartCoroutine(iFDPIFMKOIum.OMCADBPJEOL(1077f));
		}
		AIADDDGEHKO();
	}

	private void EKNDHCNIJFG()
	{
		GKHOMBPNBHC = RadicalRoutine.Create(AJPOOAHKAFG());
		StartCoroutine(RadicalRoutine.Run(GKHOMBPNBHC.enumerator));
	}

	public void OEJFBEOJNFO()
	{
		foreach (IntroductionDealsItem iFDPIFMKOIum in IFDPIFMKOIA)
		{
			StartCoroutine(iFDPIFMKOIum.OCAEJPMPBMH(1685f));
		}
		GEKIMGFKNHC();
	}

	public void HOBEPBFPFKG()
	{
		LEGJDOEKBCF();
		foreach (IntroductionDealsItem iFDPIFMKOIum in IFDPIFMKOIA)
		{
			iFDPIFMKOIum.gameObject.SetActive(value: true);
			iFDPIFMKOIum.MEHAKDFBGJN();
		}
	}

	public void NAFADEANOBG()
	{
		foreach (IntroductionDealsItem iFDPIFMKOIum in IFDPIFMKOIA)
		{
			StartCoroutine(iFDPIFMKOIum.GDLOAPIHMOB(993f));
		}
		MNLAIHAPJOA();
	}

	public void NBJKGKHHGCJ()
	{
		foreach (IntroductionDealsItem iFDPIFMKOIum in IFDPIFMKOIA)
		{
			StartCoroutine(iFDPIFMKOIum.GDLOAPIHMOB(177f));
		}
		DFJBBKKIPAD();
	}
}
