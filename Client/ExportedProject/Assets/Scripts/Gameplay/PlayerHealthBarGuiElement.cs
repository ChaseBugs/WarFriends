using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerHealthBarGuiElement : Core_BaseScript
{
	private sealed class FJHBNEKNKFB : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal PlayerHealthBarGuiElement BJGCPDNMHDH;

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

		public void FLCIMHOJPDF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void MDBDGOJADJM()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object DFHCLJNONGC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EOKIMMCAABI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FBPFPJOCKGD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FFJBOMJMIAE()
		{
			return PHDOCKCBJOF;
		}

		public void INBELBGOCLD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GIEPJLBHHEO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BBDOFDBCILK()
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
			case 1u:
				if (BJGCPDNMHDH.MBIAKMPDOPG != null)
				{
					if (BJGCPDNMHDH.ABKLOMBNDJB != BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio)
					{
						if (BJGCPDNMHDH.DKFLKBMKKKI != null)
						{
							BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.DKFLKBMKKKI);
							BJGCPDNMHDH.DKFLKBMKKKI = null;
						}
						if (BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio > BJGCPDNMHDH.ABKLOMBNDJB)
						{
							BJGCPDNMHDH.ABKLOMBNDJB = BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio;
							BJGCPDNMHDH.MNAJKODCACI.transform.localScale = BJGCPDNMHDH.MNAJKODCACI.transform.localScale.ReplaceX(BJGCPDNMHDH.ABKLOMBNDJB * BJGCPDNMHDH.JGNJJIKPICF);
							BJGCPDNMHDH.CGJIGBDGOOO.gameObject.SetActive(value: false);
						}
						else
						{
							BJGCPDNMHDH.ABKLOMBNDJB = BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio;
							BJGCPDNMHDH.DKFLKBMKKKI = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.ENDJPIKAADN());
						}
						if (!BJGCPDNMHDH.BNHAJBLDKOP)
						{
							BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.HKAFLLAFBIM());
							BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.GEDKCLHJNII());
						}
					}
					if (!BJGCPDNMHDH.BNHAJBLDKOP && BJGCPDNMHDH.MBIAKMPDOPG.IsNearDeath())
					{
						BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.GDIBBEOJPMA());
						if (BJGCPDNMHDH.MBIAKMPDOPG.isCurrentPlayer)
						{
							BJGCPDNMHDH.DOLNDLHICOO.volume = SoundsManager.Instance.soundsVolume;
							BJGCPDNMHDH.DOLNDLHICOO.Play();
						}
						BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.OPOAIMFMFPN());
					}
					PHDOCKCBJOF = null;
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

		public void PNGIELILHDI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool KEBEGEDKIKM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.MBIAKMPDOPG != null)
				{
					if (BJGCPDNMHDH.ABKLOMBNDJB != BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio)
					{
						if (BJGCPDNMHDH.DKFLKBMKKKI != null)
						{
							BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.DKFLKBMKKKI);
							BJGCPDNMHDH.DKFLKBMKKKI = null;
						}
						if (BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio > BJGCPDNMHDH.ABKLOMBNDJB)
						{
							BJGCPDNMHDH.ABKLOMBNDJB = BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio;
							BJGCPDNMHDH.MNAJKODCACI.transform.localScale = BJGCPDNMHDH.MNAJKODCACI.transform.localScale.ReplaceX(BJGCPDNMHDH.ABKLOMBNDJB * BJGCPDNMHDH.JGNJJIKPICF);
							BJGCPDNMHDH.CGJIGBDGOOO.gameObject.SetActive(value: true);
						}
						else
						{
							BJGCPDNMHDH.ABKLOMBNDJB = BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio;
							BJGCPDNMHDH.DKFLKBMKKKI = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JHHJEHLHICJ());
						}
						if (!BJGCPDNMHDH.BNHAJBLDKOP)
						{
							BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.HKAFLLAFBIM());
							BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.BLKOJLODOFA());
						}
					}
					if (!BJGCPDNMHDH.BNHAJBLDKOP && BJGCPDNMHDH.MBIAKMPDOPG.IsNearDeath())
					{
						BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.FBDKMEKOFAB());
						if (BJGCPDNMHDH.MBIAKMPDOPG.isCurrentPlayer)
						{
							BJGCPDNMHDH.DOLNDLHICOO.volume = SoundsManager.Instance.soundsVolume;
							BJGCPDNMHDH.DOLNDLHICOO.Play();
						}
						BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.BLBNAFADILI());
					}
					PHDOCKCBJOF = null;
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

		public bool LPCBKGKFNFD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.MBIAKMPDOPG != null)
				{
					if (BJGCPDNMHDH.ABKLOMBNDJB != BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio)
					{
						if (BJGCPDNMHDH.DKFLKBMKKKI != null)
						{
							BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.DKFLKBMKKKI);
							BJGCPDNMHDH.DKFLKBMKKKI = null;
						}
						if (BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio > BJGCPDNMHDH.ABKLOMBNDJB)
						{
							BJGCPDNMHDH.ABKLOMBNDJB = BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio;
							BJGCPDNMHDH.MNAJKODCACI.transform.localScale = BJGCPDNMHDH.MNAJKODCACI.transform.localScale.ReplaceX(BJGCPDNMHDH.ABKLOMBNDJB * BJGCPDNMHDH.JGNJJIKPICF);
							BJGCPDNMHDH.CGJIGBDGOOO.gameObject.SetActive(value: false);
						}
						else
						{
							BJGCPDNMHDH.ABKLOMBNDJB = BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio;
							BJGCPDNMHDH.DKFLKBMKKKI = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.EGEIELFHBCJ());
						}
						if (!BJGCPDNMHDH.BNHAJBLDKOP)
						{
							BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.LLIHLNDCJDO());
							BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.ICPKFKMPEAB());
						}
					}
					if (!BJGCPDNMHDH.BNHAJBLDKOP && BJGCPDNMHDH.MBIAKMPDOPG.IsNearDeath())
					{
						BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.FBDKMEKOFAB());
						if (BJGCPDNMHDH.MBIAKMPDOPG.isCurrentPlayer)
						{
							BJGCPDNMHDH.DOLNDLHICOO.volume = SoundsManager.Instance.soundsVolume;
							BJGCPDNMHDH.DOLNDLHICOO.Play();
						}
						BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.PIKIOLODGPG());
					}
					PHDOCKCBJOF = null;
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

		public void NFAMBMLLFGP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object KJMPNHLOKJL()
		{
			return PHDOCKCBJOF;
		}

		public void DLIBOPAMHAN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BBHOODPMEFM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GLIHEBDJCGM()
		{
			return PHDOCKCBJOF;
		}

		public bool JICHKPANPEE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.MBIAKMPDOPG != null)
				{
					if (BJGCPDNMHDH.ABKLOMBNDJB != BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio)
					{
						if (BJGCPDNMHDH.DKFLKBMKKKI != null)
						{
							BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.DKFLKBMKKKI);
							BJGCPDNMHDH.DKFLKBMKKKI = null;
						}
						if (BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio > BJGCPDNMHDH.ABKLOMBNDJB)
						{
							BJGCPDNMHDH.ABKLOMBNDJB = BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio;
							BJGCPDNMHDH.MNAJKODCACI.transform.localScale = BJGCPDNMHDH.MNAJKODCACI.transform.localScale.ReplaceX(BJGCPDNMHDH.ABKLOMBNDJB * BJGCPDNMHDH.JGNJJIKPICF);
							BJGCPDNMHDH.CGJIGBDGOOO.gameObject.SetActive(value: true);
						}
						else
						{
							BJGCPDNMHDH.ABKLOMBNDJB = BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio;
							BJGCPDNMHDH.DKFLKBMKKKI = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.ENDJPIKAADN());
						}
						if (!BJGCPDNMHDH.BNHAJBLDKOP)
						{
							BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.GOHBDCIHGPD());
							BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.FBDKMEKOFAB());
						}
					}
					if (!BJGCPDNMHDH.BNHAJBLDKOP && BJGCPDNMHDH.MBIAKMPDOPG.IsNearDeath())
					{
						BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.HIBJBCINOJF());
						if (BJGCPDNMHDH.MBIAKMPDOPG.isCurrentPlayer)
						{
							BJGCPDNMHDH.DOLNDLHICOO.volume = SoundsManager.Instance.soundsVolume;
							BJGCPDNMHDH.DOLNDLHICOO.Play();
						}
						BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.BLBNAFADILI());
					}
					PHDOCKCBJOF = null;
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

		public void CFDAGFGOOIE()
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
			case 1u:
				if (BJGCPDNMHDH.MBIAKMPDOPG != null)
				{
					if (BJGCPDNMHDH.ABKLOMBNDJB != BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio)
					{
						if (BJGCPDNMHDH.DKFLKBMKKKI != null)
						{
							BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.DKFLKBMKKKI);
							BJGCPDNMHDH.DKFLKBMKKKI = null;
						}
						if (BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio > BJGCPDNMHDH.ABKLOMBNDJB)
						{
							BJGCPDNMHDH.ABKLOMBNDJB = BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio;
							BJGCPDNMHDH.MNAJKODCACI.transform.localScale = BJGCPDNMHDH.MNAJKODCACI.transform.localScale.ReplaceX(BJGCPDNMHDH.ABKLOMBNDJB * BJGCPDNMHDH.JGNJJIKPICF);
							BJGCPDNMHDH.CGJIGBDGOOO.gameObject.SetActive(value: true);
						}
						else
						{
							BJGCPDNMHDH.ABKLOMBNDJB = BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio;
							BJGCPDNMHDH.DKFLKBMKKKI = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.NNBGMFIILEO());
						}
						if (!BJGCPDNMHDH.BNHAJBLDKOP)
						{
							BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.FBDKMEKOFAB());
							BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.HIBJBCINOJF());
						}
					}
					if (!BJGCPDNMHDH.BNHAJBLDKOP && BJGCPDNMHDH.MBIAKMPDOPG.IsNearDeath())
					{
						BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.GOHBDCIHGPD());
						if (BJGCPDNMHDH.MBIAKMPDOPG.isCurrentPlayer)
						{
							BJGCPDNMHDH.DOLNDLHICOO.volume = SoundsManager.Instance.soundsVolume;
							BJGCPDNMHDH.DOLNDLHICOO.Play();
						}
						BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.PIKIOLODGPG());
					}
					PHDOCKCBJOF = null;
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

		[SpecialName]
		private object CEFJKELIBGG()
		{
			return PHDOCKCBJOF;
		}

		public void AMPGDAMMPFJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BLNNEJILEIE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OAKHGMKKFMN()
		{
			return PHDOCKCBJOF;
		}

		public void GGCLMIMHKBD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object EPNOIENCFGA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MHKODCGLJFD()
		{
			return PHDOCKCBJOF;
		}

		public void KGLKGNBCPLM()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object JMKGAJNOLEM()
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
				if (BJGCPDNMHDH.MBIAKMPDOPG != null)
				{
					if (BJGCPDNMHDH.ABKLOMBNDJB != BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio)
					{
						if (BJGCPDNMHDH.DKFLKBMKKKI != null)
						{
							BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.DKFLKBMKKKI);
							BJGCPDNMHDH.DKFLKBMKKKI = null;
						}
						if (BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio > BJGCPDNMHDH.ABKLOMBNDJB)
						{
							BJGCPDNMHDH.ABKLOMBNDJB = BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio;
							BJGCPDNMHDH.MNAJKODCACI.transform.localScale = BJGCPDNMHDH.MNAJKODCACI.transform.localScale.ReplaceX(BJGCPDNMHDH.ABKLOMBNDJB * BJGCPDNMHDH.JGNJJIKPICF);
							BJGCPDNMHDH.CGJIGBDGOOO.gameObject.SetActive(value: true);
						}
						else
						{
							BJGCPDNMHDH.ABKLOMBNDJB = BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio;
							BJGCPDNMHDH.DKFLKBMKKKI = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.NNBGMFIILEO());
						}
						if (!BJGCPDNMHDH.BNHAJBLDKOP)
						{
							BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.LIPIGKGLOKP());
							BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.HIBJBCINOJF());
						}
					}
					if (!BJGCPDNMHDH.BNHAJBLDKOP && BJGCPDNMHDH.MBIAKMPDOPG.IsNearDeath())
					{
						BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.FBDKMEKOFAB());
						if (BJGCPDNMHDH.MBIAKMPDOPG.isCurrentPlayer)
						{
							BJGCPDNMHDH.DOLNDLHICOO.volume = SoundsManager.Instance.soundsVolume;
							BJGCPDNMHDH.DOLNDLHICOO.Play();
						}
						BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.BLBNAFADILI());
					}
					PHDOCKCBJOF = null;
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

		public bool IBEPOFJDKLG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.MBIAKMPDOPG != null)
				{
					if (BJGCPDNMHDH.ABKLOMBNDJB != BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio)
					{
						if (BJGCPDNMHDH.DKFLKBMKKKI != null)
						{
							BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.DKFLKBMKKKI);
							BJGCPDNMHDH.DKFLKBMKKKI = null;
						}
						if (BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio > BJGCPDNMHDH.ABKLOMBNDJB)
						{
							BJGCPDNMHDH.ABKLOMBNDJB = BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio;
							BJGCPDNMHDH.MNAJKODCACI.transform.localScale = BJGCPDNMHDH.MNAJKODCACI.transform.localScale.ReplaceX(BJGCPDNMHDH.ABKLOMBNDJB * BJGCPDNMHDH.JGNJJIKPICF);
							BJGCPDNMHDH.CGJIGBDGOOO.gameObject.SetActive(value: false);
						}
						else
						{
							BJGCPDNMHDH.ABKLOMBNDJB = BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio;
							BJGCPDNMHDH.DKFLKBMKKKI = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.IBIMHCNCOEB());
						}
						if (!BJGCPDNMHDH.BNHAJBLDKOP)
						{
							BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.CNBADNLJJPF());
							BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.DJMOPJGJEFJ());
						}
					}
					if (!BJGCPDNMHDH.BNHAJBLDKOP && BJGCPDNMHDH.MBIAKMPDOPG.IsNearDeath())
					{
						BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.LLIHLNDCJDO());
						if (BJGCPDNMHDH.MBIAKMPDOPG.isCurrentPlayer)
						{
							BJGCPDNMHDH.DOLNDLHICOO.volume = SoundsManager.Instance.soundsVolume;
							BJGCPDNMHDH.DOLNDLHICOO.Play();
						}
						BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LAEBAANFFBL());
					}
					PHDOCKCBJOF = null;
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

		public void BICMFOEHHGN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void OPMABIIDKCN()
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

		public bool DFMKKFMEBON()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.MBIAKMPDOPG != null)
				{
					if (BJGCPDNMHDH.ABKLOMBNDJB != BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio)
					{
						if (BJGCPDNMHDH.DKFLKBMKKKI != null)
						{
							BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.DKFLKBMKKKI);
							BJGCPDNMHDH.DKFLKBMKKKI = null;
						}
						if (BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio > BJGCPDNMHDH.ABKLOMBNDJB)
						{
							BJGCPDNMHDH.ABKLOMBNDJB = BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio;
							BJGCPDNMHDH.MNAJKODCACI.transform.localScale = BJGCPDNMHDH.MNAJKODCACI.transform.localScale.ReplaceX(BJGCPDNMHDH.ABKLOMBNDJB * BJGCPDNMHDH.JGNJJIKPICF);
							BJGCPDNMHDH.CGJIGBDGOOO.gameObject.SetActive(value: false);
						}
						else
						{
							BJGCPDNMHDH.ABKLOMBNDJB = BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio;
							BJGCPDNMHDH.DKFLKBMKKKI = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.NNBGMFIILEO());
						}
						if (!BJGCPDNMHDH.BNHAJBLDKOP)
						{
							BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.ICPKFKMPEAB());
							BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.GOHBDCIHGPD());
						}
					}
					if (!BJGCPDNMHDH.BNHAJBLDKOP && BJGCPDNMHDH.MBIAKMPDOPG.OBEIMNKPABG())
					{
						BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.LIPIGKGLOKP());
						if (BJGCPDNMHDH.MBIAKMPDOPG.isCurrentPlayer)
						{
							BJGCPDNMHDH.DOLNDLHICOO.volume = SoundsManager.Instance.soundsVolume;
							BJGCPDNMHDH.DOLNDLHICOO.Play();
						}
						BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.BLBNAFADILI());
					}
					PHDOCKCBJOF = null;
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

		public void CPDBCJLIGFN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void MKACBCOLNKD()
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
		private object HCCLNDKNCIE()
		{
			return PHDOCKCBJOF;
		}

		public void AHEOCEEJICJ()
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
				if (BJGCPDNMHDH.MBIAKMPDOPG != null)
				{
					if (BJGCPDNMHDH.ABKLOMBNDJB != BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio)
					{
						if (BJGCPDNMHDH.DKFLKBMKKKI != null)
						{
							BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.DKFLKBMKKKI);
							BJGCPDNMHDH.DKFLKBMKKKI = null;
						}
						if (BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio > BJGCPDNMHDH.ABKLOMBNDJB)
						{
							BJGCPDNMHDH.ABKLOMBNDJB = BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio;
							BJGCPDNMHDH.MNAJKODCACI.transform.localScale = BJGCPDNMHDH.MNAJKODCACI.transform.localScale.ReplaceX(BJGCPDNMHDH.ABKLOMBNDJB * BJGCPDNMHDH.JGNJJIKPICF);
							BJGCPDNMHDH.CGJIGBDGOOO.gameObject.SetActive(value: false);
						}
						else
						{
							BJGCPDNMHDH.ABKLOMBNDJB = BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio;
							BJGCPDNMHDH.DKFLKBMKKKI = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JHHJEHLHICJ());
						}
						if (!BJGCPDNMHDH.BNHAJBLDKOP)
						{
							BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.FBDKMEKOFAB());
							BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.GDIBBEOJPMA());
						}
					}
					if (!BJGCPDNMHDH.BNHAJBLDKOP && BJGCPDNMHDH.MBIAKMPDOPG.AONLENLHDMD())
					{
						BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.FBDKMEKOFAB());
						if (BJGCPDNMHDH.MBIAKMPDOPG.isCurrentPlayer)
						{
							BJGCPDNMHDH.DOLNDLHICOO.volume = SoundsManager.Instance.soundsVolume;
							BJGCPDNMHDH.DOLNDLHICOO.Play();
						}
						BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.PIKIOLODGPG());
					}
					PHDOCKCBJOF = null;
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
		private object BMAMEPNHHFI()
		{
			return PHDOCKCBJOF;
		}

		public void MOJGMBNBGHH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MBGCBKJBCND()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HLBMCNKGBDM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MOLLIAAFOMJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EDBIJNJGFLE()
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
				if (BJGCPDNMHDH.MBIAKMPDOPG != null)
				{
					if (BJGCPDNMHDH.ABKLOMBNDJB != BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio)
					{
						if (BJGCPDNMHDH.DKFLKBMKKKI != null)
						{
							BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.DKFLKBMKKKI);
							BJGCPDNMHDH.DKFLKBMKKKI = null;
						}
						if (BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio > BJGCPDNMHDH.ABKLOMBNDJB)
						{
							BJGCPDNMHDH.ABKLOMBNDJB = BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio;
							BJGCPDNMHDH.MNAJKODCACI.transform.localScale = BJGCPDNMHDH.MNAJKODCACI.transform.localScale.ReplaceX(BJGCPDNMHDH.ABKLOMBNDJB * BJGCPDNMHDH.JGNJJIKPICF);
							BJGCPDNMHDH.CGJIGBDGOOO.gameObject.SetActive(value: false);
						}
						else
						{
							BJGCPDNMHDH.ABKLOMBNDJB = BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio;
							BJGCPDNMHDH.DKFLKBMKKKI = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.BCFJKJBOCMB());
						}
						if (!BJGCPDNMHDH.BNHAJBLDKOP)
						{
							BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.GOHBDCIHGPD());
							BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.MNNGCEDCBPB());
						}
					}
					if (!BJGCPDNMHDH.BNHAJBLDKOP && BJGCPDNMHDH.MBIAKMPDOPG.OBEIMNKPABG())
					{
						BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.CNBADNLJJPF());
						if (BJGCPDNMHDH.MBIAKMPDOPG.isCurrentPlayer)
						{
							BJGCPDNMHDH.DOLNDLHICOO.volume = SoundsManager.Instance.soundsVolume;
							BJGCPDNMHDH.DOLNDLHICOO.Play();
						}
						BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.PIKIOLODGPG());
					}
					PHDOCKCBJOF = null;
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
		private object HBGFABNDPAD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GOAJCEAOPLA()
		{
			return PHDOCKCBJOF;
		}

		public bool GAPIFMKNJBN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (BJGCPDNMHDH.MBIAKMPDOPG != null)
				{
					if (BJGCPDNMHDH.ABKLOMBNDJB != BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio)
					{
						if (BJGCPDNMHDH.DKFLKBMKKKI != null)
						{
							BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.DKFLKBMKKKI);
							BJGCPDNMHDH.DKFLKBMKKKI = null;
						}
						if (BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio > BJGCPDNMHDH.ABKLOMBNDJB)
						{
							BJGCPDNMHDH.ABKLOMBNDJB = BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio;
							BJGCPDNMHDH.MNAJKODCACI.transform.localScale = BJGCPDNMHDH.MNAJKODCACI.transform.localScale.ReplaceX(BJGCPDNMHDH.ABKLOMBNDJB * BJGCPDNMHDH.JGNJJIKPICF);
							BJGCPDNMHDH.CGJIGBDGOOO.gameObject.SetActive(value: false);
						}
						else
						{
							BJGCPDNMHDH.ABKLOMBNDJB = BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio;
							BJGCPDNMHDH.DKFLKBMKKKI = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.ENDJPIKAADN());
						}
						if (!BJGCPDNMHDH.BNHAJBLDKOP)
						{
							BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.GDIBBEOJPMA());
							BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.CNBADNLJJPF());
						}
					}
					if (!BJGCPDNMHDH.BNHAJBLDKOP && BJGCPDNMHDH.MBIAKMPDOPG.OBEIMNKPABG())
					{
						BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.HIBJBCINOJF());
						if (BJGCPDNMHDH.MBIAKMPDOPG.isCurrentPlayer)
						{
							BJGCPDNMHDH.DOLNDLHICOO.volume = SoundsManager.Instance.soundsVolume;
							BJGCPDNMHDH.DOLNDLHICOO.Play();
						}
						BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.OPOAIMFMFPN());
					}
					PHDOCKCBJOF = null;
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

		public void KAFNGNMNNOA()
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
				if (BJGCPDNMHDH.MBIAKMPDOPG != null)
				{
					if (BJGCPDNMHDH.ABKLOMBNDJB != BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio)
					{
						if (BJGCPDNMHDH.DKFLKBMKKKI != null)
						{
							BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.DKFLKBMKKKI);
							BJGCPDNMHDH.DKFLKBMKKKI = null;
						}
						if (BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio > BJGCPDNMHDH.ABKLOMBNDJB)
						{
							BJGCPDNMHDH.ABKLOMBNDJB = BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio;
							BJGCPDNMHDH.MNAJKODCACI.transform.localScale = BJGCPDNMHDH.MNAJKODCACI.transform.localScale.ReplaceX(BJGCPDNMHDH.ABKLOMBNDJB * BJGCPDNMHDH.JGNJJIKPICF);
							BJGCPDNMHDH.CGJIGBDGOOO.gameObject.SetActive(value: true);
						}
						else
						{
							BJGCPDNMHDH.ABKLOMBNDJB = BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio;
							BJGCPDNMHDH.DKFLKBMKKKI = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JHHJEHLHICJ());
						}
						if (!BJGCPDNMHDH.BNHAJBLDKOP)
						{
							BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.HIBJBCINOJF());
							BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.DJMOPJGJEFJ());
						}
					}
					if (!BJGCPDNMHDH.BNHAJBLDKOP && BJGCPDNMHDH.MBIAKMPDOPG.AONLENLHDMD())
					{
						BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.DJMOPJGJEFJ());
						if (BJGCPDNMHDH.MBIAKMPDOPG.isCurrentPlayer)
						{
							BJGCPDNMHDH.DOLNDLHICOO.volume = SoundsManager.Instance.soundsVolume;
							BJGCPDNMHDH.DOLNDLHICOO.Play();
						}
						BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LLFGGPEIMBM());
					}
					PHDOCKCBJOF = null;
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
		private object GAPDDGJNMPK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CNGCLCAAHIG()
		{
			return PHDOCKCBJOF;
		}

		public void JKOCLGOOBEK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object OJANHAIEAEJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GNFCCLCPCBO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BKHFGLNNCDF()
		{
			return PHDOCKCBJOF;
		}

		public void ENENMOAOOBG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object FCMAGGLJCMG()
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
			case 1u:
				if (BJGCPDNMHDH.MBIAKMPDOPG != null)
				{
					if (BJGCPDNMHDH.ABKLOMBNDJB != BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio)
					{
						if (BJGCPDNMHDH.DKFLKBMKKKI != null)
						{
							BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.DKFLKBMKKKI);
							BJGCPDNMHDH.DKFLKBMKKKI = null;
						}
						if (BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio > BJGCPDNMHDH.ABKLOMBNDJB)
						{
							BJGCPDNMHDH.ABKLOMBNDJB = BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio;
							BJGCPDNMHDH.MNAJKODCACI.transform.localScale = BJGCPDNMHDH.MNAJKODCACI.transform.localScale.ReplaceX(BJGCPDNMHDH.ABKLOMBNDJB * BJGCPDNMHDH.JGNJJIKPICF);
							BJGCPDNMHDH.CGJIGBDGOOO.gameObject.SetActive(value: false);
						}
						else
						{
							BJGCPDNMHDH.ABKLOMBNDJB = BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio;
							BJGCPDNMHDH.DKFLKBMKKKI = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.BCFJKJBOCMB());
						}
						if (!BJGCPDNMHDH.BNHAJBLDKOP)
						{
							BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.FBDKMEKOFAB());
							BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LIPIGKGLOKP());
						}
					}
					if (!BJGCPDNMHDH.BNHAJBLDKOP && BJGCPDNMHDH.MBIAKMPDOPG.AONLENLHDMD())
					{
						BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.BLKOJLODOFA());
						if (BJGCPDNMHDH.MBIAKMPDOPG.isCurrentPlayer)
						{
							BJGCPDNMHDH.DOLNDLHICOO.volume = SoundsManager.Instance.soundsVolume;
							BJGCPDNMHDH.DOLNDLHICOO.Play();
						}
						BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.HJKKLGFNDCF());
					}
					PHDOCKCBJOF = null;
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

		public void NPIDJAPKFLN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object INAMGPNDAAJ()
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
			case 1u:
				if (BJGCPDNMHDH.MBIAKMPDOPG != null)
				{
					if (BJGCPDNMHDH.ABKLOMBNDJB != BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio)
					{
						if (BJGCPDNMHDH.DKFLKBMKKKI != null)
						{
							BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.DKFLKBMKKKI);
							BJGCPDNMHDH.DKFLKBMKKKI = null;
						}
						if (BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio > BJGCPDNMHDH.ABKLOMBNDJB)
						{
							BJGCPDNMHDH.ABKLOMBNDJB = BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio;
							BJGCPDNMHDH.MNAJKODCACI.transform.localScale = BJGCPDNMHDH.MNAJKODCACI.transform.localScale.ReplaceX(BJGCPDNMHDH.ABKLOMBNDJB * BJGCPDNMHDH.JGNJJIKPICF);
							BJGCPDNMHDH.CGJIGBDGOOO.gameObject.SetActive(value: false);
						}
						else
						{
							BJGCPDNMHDH.ABKLOMBNDJB = BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio;
							BJGCPDNMHDH.DKFLKBMKKKI = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.BCFJKJBOCMB());
						}
						if (!BJGCPDNMHDH.BNHAJBLDKOP)
						{
							BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.BLKOJLODOFA());
							BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.ICPKFKMPEAB());
						}
					}
					if (!BJGCPDNMHDH.BNHAJBLDKOP && BJGCPDNMHDH.MBIAKMPDOPG.OBEIMNKPABG())
					{
						BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.LLIHLNDCJDO());
						if (BJGCPDNMHDH.MBIAKMPDOPG.isCurrentPlayer)
						{
							BJGCPDNMHDH.DOLNDLHICOO.volume = SoundsManager.Instance.soundsVolume;
							BJGCPDNMHDH.DOLNDLHICOO.Play();
						}
						BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.OPOAIMFMFPN());
					}
					PHDOCKCBJOF = null;
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

		public void HHCBBENDENJ()
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
			case 1u:
				if (BJGCPDNMHDH.MBIAKMPDOPG != null)
				{
					if (BJGCPDNMHDH.ABKLOMBNDJB != BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio)
					{
						if (BJGCPDNMHDH.DKFLKBMKKKI != null)
						{
							BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.DKFLKBMKKKI);
							BJGCPDNMHDH.DKFLKBMKKKI = null;
						}
						if (BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio > BJGCPDNMHDH.ABKLOMBNDJB)
						{
							BJGCPDNMHDH.ABKLOMBNDJB = BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio;
							BJGCPDNMHDH.MNAJKODCACI.transform.localScale = BJGCPDNMHDH.MNAJKODCACI.transform.localScale.ReplaceX(BJGCPDNMHDH.ABKLOMBNDJB * BJGCPDNMHDH.JGNJJIKPICF);
							BJGCPDNMHDH.CGJIGBDGOOO.gameObject.SetActive(value: false);
						}
						else
						{
							BJGCPDNMHDH.ABKLOMBNDJB = BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio;
							BJGCPDNMHDH.DKFLKBMKKKI = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.MKMEFOHDBCE());
						}
						if (!BJGCPDNMHDH.BNHAJBLDKOP)
						{
							BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.HKAFLLAFBIM());
							BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.HKAFLLAFBIM());
						}
					}
					if (!BJGCPDNMHDH.BNHAJBLDKOP && BJGCPDNMHDH.MBIAKMPDOPG.IsNearDeath())
					{
						BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.HKAFLLAFBIM());
						if (BJGCPDNMHDH.MBIAKMPDOPG.isCurrentPlayer)
						{
							BJGCPDNMHDH.DOLNDLHICOO.volume = SoundsManager.Instance.soundsVolume;
							BJGCPDNMHDH.DOLNDLHICOO.Play();
						}
						BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LLFGGPEIMBM());
					}
					PHDOCKCBJOF = null;
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

		[SpecialName]
		private object MKNFFJPADIA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DHFBIMOBODM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EGJDJENBABP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LMJBCDNGAHP()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KBNAGKKMLBP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FGFLGJECNLH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ADNCCLOOEAD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HMIFLGCBDCO()
		{
			return PHDOCKCBJOF;
		}

		public void NAMBILMHOPD()
		{
			throw new NotSupportedException();
		}

		public void BOFEBMENOFC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GCJFGIKENJA()
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
				if (BJGCPDNMHDH.MBIAKMPDOPG != null)
				{
					if (BJGCPDNMHDH.ABKLOMBNDJB != BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio)
					{
						if (BJGCPDNMHDH.DKFLKBMKKKI != null)
						{
							BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.DKFLKBMKKKI);
							BJGCPDNMHDH.DKFLKBMKKKI = null;
						}
						if (BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio > BJGCPDNMHDH.ABKLOMBNDJB)
						{
							BJGCPDNMHDH.ABKLOMBNDJB = BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio;
							BJGCPDNMHDH.MNAJKODCACI.transform.localScale = BJGCPDNMHDH.MNAJKODCACI.transform.localScale.ReplaceX(BJGCPDNMHDH.ABKLOMBNDJB * BJGCPDNMHDH.JGNJJIKPICF);
							BJGCPDNMHDH.CGJIGBDGOOO.gameObject.SetActive(value: false);
						}
						else
						{
							BJGCPDNMHDH.ABKLOMBNDJB = BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio;
							BJGCPDNMHDH.DKFLKBMKKKI = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JHHJEHLHICJ());
						}
						if (!BJGCPDNMHDH.BNHAJBLDKOP)
						{
							BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.HKAFLLAFBIM());
							BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.DJMOPJGJEFJ());
						}
					}
					if (!BJGCPDNMHDH.BNHAJBLDKOP && BJGCPDNMHDH.MBIAKMPDOPG.AONLENLHDMD())
					{
						BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.HIBJBCINOJF());
						if (BJGCPDNMHDH.MBIAKMPDOPG.isCurrentPlayer)
						{
							BJGCPDNMHDH.DOLNDLHICOO.volume = SoundsManager.Instance.soundsVolume;
							BJGCPDNMHDH.DOLNDLHICOO.Play();
						}
						BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LAEBAANFFBL());
					}
					PHDOCKCBJOF = null;
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

		public void LPKDPNHBLGJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public FJHBNEKNKFB()
		{
		}

		public void PCNOHGFPMOE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void FOODPOJODAA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void BCOIPCDCKEJ()
		{
			throw new NotSupportedException();
		}

		public void MBELAAJDOJA()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object NDIGINEEOMH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BGMNDLEJNHH()
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
				if (BJGCPDNMHDH.MBIAKMPDOPG != null)
				{
					if (BJGCPDNMHDH.ABKLOMBNDJB != BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio)
					{
						if (BJGCPDNMHDH.DKFLKBMKKKI != null)
						{
							BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.DKFLKBMKKKI);
							BJGCPDNMHDH.DKFLKBMKKKI = null;
						}
						if (BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio > BJGCPDNMHDH.ABKLOMBNDJB)
						{
							BJGCPDNMHDH.ABKLOMBNDJB = BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio;
							BJGCPDNMHDH.MNAJKODCACI.transform.localScale = BJGCPDNMHDH.MNAJKODCACI.transform.localScale.ReplaceX(BJGCPDNMHDH.ABKLOMBNDJB * BJGCPDNMHDH.JGNJJIKPICF);
							BJGCPDNMHDH.CGJIGBDGOOO.gameObject.SetActive(value: false);
						}
						else
						{
							BJGCPDNMHDH.ABKLOMBNDJB = BJGCPDNMHDH.MBIAKMPDOPG.FOCIOKMPCAG.healthRatio;
							BJGCPDNMHDH.DKFLKBMKKKI = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.ENDJPIKAADN());
						}
						if (!BJGCPDNMHDH.BNHAJBLDKOP)
						{
							BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.ICPKFKMPEAB());
							BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.MNNGCEDCBPB());
						}
					}
					if (!BJGCPDNMHDH.BNHAJBLDKOP && BJGCPDNMHDH.MBIAKMPDOPG.IsNearDeath())
					{
						BJGCPDNMHDH.StopCoroutine(BJGCPDNMHDH.GDIBBEOJPMA());
						if (BJGCPDNMHDH.MBIAKMPDOPG.isCurrentPlayer)
						{
							BJGCPDNMHDH.DOLNDLHICOO.volume = SoundsManager.Instance.soundsVolume;
							BJGCPDNMHDH.DOLNDLHICOO.Play();
						}
						BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.HJKKLGFNDCF());
					}
					PHDOCKCBJOF = null;
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
	}

	private sealed class NLFKOCOKPEE : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal float GOMMNPDKINN;

		internal float BCFCMJODLCH;

		internal float LFBOLPAFMCG;

		internal float DBAPKJNHDLH;

		internal PlayerHealthBarGuiElement BJGCPDNMHDH;

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

		public bool CONJMMKAAGH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.CGJIGBDGOOO.gameObject.SetActive(value: false);
				GOMMNPDKINN = 1861f;
				BCFCMJODLCH = BJGCPDNMHDH.ABKLOMBNDJB * BJGCPDNMHDH.JGNJJIKPICF;
				goto IL_005f;
			case 1u:
				{
					if (!(BJGCPDNMHDH.CGJIGBDGOOO.transform.localScale.x > BCFCMJODLCH) && !(BJGCPDNMHDH.MNAJKODCACI.transform.localScale.x > BCFCMJODLCH))
					{
						BJGCPDNMHDH.CGJIGBDGOOO.gameObject.SetActive(value: false);
						CLPPIAGLCJJ = -1;
						break;
					}
					goto IL_005f;
				}
				IL_005f:
				GOMMNPDKINN += TimeManager.deltaTimeWithoutPauses;
				LFBOLPAFMCG = BJGCPDNMHDH.JGNJJIKPICF * TimeManager.deltaTimeWithoutPauses / BJGCPDNMHDH.DGHFKLCHLPN;
				DBAPKJNHDLH = ((!(GOMMNPDKINN < BJGCPDNMHDH.NJJCPOKOMGK)) ? (BJGCPDNMHDH.JGNJJIKPICF * TimeManager.deltaTimeWithoutPauses / BJGCPDNMHDH.PPMIJLPPNCP) : 156f);
				BJGCPDNMHDH.MNAJKODCACI.transform.localScale = BJGCPDNMHDH.MNAJKODCACI.transform.localScale.ReplaceX(Mathf.Max(BCFCMJODLCH, BJGCPDNMHDH.MNAJKODCACI.transform.localScale.x - LFBOLPAFMCG));
				BJGCPDNMHDH.CGJIGBDGOOO.transform.localScale = BJGCPDNMHDH.CGJIGBDGOOO.transform.localScale.ReplaceX(Mathf.Max(BCFCMJODLCH, BJGCPDNMHDH.CGJIGBDGOOO.transform.localScale.x - DBAPKJNHDLH));
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			}
			return true;
		}

		[SpecialName]
		private object BOOBHEKPLLD()
		{
			return PHDOCKCBJOF;
		}

		public void FOODPOJODAA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void HPJKDIGCCCE()
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
				BJGCPDNMHDH.CGJIGBDGOOO.gameObject.SetActive(value: true);
				GOMMNPDKINN = 0f;
				BCFCMJODLCH = BJGCPDNMHDH.ABKLOMBNDJB * BJGCPDNMHDH.JGNJJIKPICF;
				goto IL_005f;
			case 1u:
				{
					if (!(BJGCPDNMHDH.CGJIGBDGOOO.transform.localScale.x > BCFCMJODLCH) && !(BJGCPDNMHDH.MNAJKODCACI.transform.localScale.x > BCFCMJODLCH))
					{
						BJGCPDNMHDH.CGJIGBDGOOO.gameObject.SetActive(value: false);
						CLPPIAGLCJJ = -1;
						break;
					}
					goto IL_005f;
				}
				IL_005f:
				GOMMNPDKINN += TimeManager.deltaTimeWithoutPauses;
				LFBOLPAFMCG = BJGCPDNMHDH.JGNJJIKPICF * TimeManager.deltaTimeWithoutPauses / BJGCPDNMHDH.DGHFKLCHLPN;
				DBAPKJNHDLH = ((!(GOMMNPDKINN < BJGCPDNMHDH.NJJCPOKOMGK)) ? (BJGCPDNMHDH.JGNJJIKPICF * TimeManager.deltaTimeWithoutPauses / BJGCPDNMHDH.PPMIJLPPNCP) : 0f);
				BJGCPDNMHDH.MNAJKODCACI.transform.localScale = BJGCPDNMHDH.MNAJKODCACI.transform.localScale.ReplaceX(Mathf.Max(BCFCMJODLCH, BJGCPDNMHDH.MNAJKODCACI.transform.localScale.x - LFBOLPAFMCG));
				BJGCPDNMHDH.CGJIGBDGOOO.transform.localScale = BJGCPDNMHDH.CGJIGBDGOOO.transform.localScale.ReplaceX(Mathf.Max(BCFCMJODLCH, BJGCPDNMHDH.CGJIGBDGOOO.transform.localScale.x - DBAPKJNHDLH));
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			}
			return false;
		}

		public bool OGLKGILLKIO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.CGJIGBDGOOO.gameObject.SetActive(value: false);
				GOMMNPDKINN = 589f;
				BCFCMJODLCH = BJGCPDNMHDH.ABKLOMBNDJB * BJGCPDNMHDH.JGNJJIKPICF;
				goto IL_005f;
			case 1u:
				{
					if (!(BJGCPDNMHDH.CGJIGBDGOOO.transform.localScale.x > BCFCMJODLCH) && !(BJGCPDNMHDH.MNAJKODCACI.transform.localScale.x > BCFCMJODLCH))
					{
						BJGCPDNMHDH.CGJIGBDGOOO.gameObject.SetActive(value: false);
						CLPPIAGLCJJ = -1;
						break;
					}
					goto IL_005f;
				}
				IL_005f:
				GOMMNPDKINN += TimeManager.deltaTimeWithoutPauses;
				LFBOLPAFMCG = BJGCPDNMHDH.JGNJJIKPICF * TimeManager.deltaTimeWithoutPauses / BJGCPDNMHDH.DGHFKLCHLPN;
				DBAPKJNHDLH = ((!(GOMMNPDKINN < BJGCPDNMHDH.NJJCPOKOMGK)) ? (BJGCPDNMHDH.JGNJJIKPICF * TimeManager.deltaTimeWithoutPauses / BJGCPDNMHDH.PPMIJLPPNCP) : 1568f);
				BJGCPDNMHDH.MNAJKODCACI.transform.localScale = BJGCPDNMHDH.MNAJKODCACI.transform.localScale.ReplaceX(Mathf.Max(BCFCMJODLCH, BJGCPDNMHDH.MNAJKODCACI.transform.localScale.x - LFBOLPAFMCG));
				BJGCPDNMHDH.CGJIGBDGOOO.transform.localScale = BJGCPDNMHDH.CGJIGBDGOOO.transform.localScale.ReplaceX(Mathf.Max(BCFCMJODLCH, BJGCPDNMHDH.CGJIGBDGOOO.transform.localScale.x - DBAPKJNHDLH));
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			}
			return false;
		}

		public bool HDGDKCMIOGK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.CGJIGBDGOOO.gameObject.SetActive(value: true);
				GOMMNPDKINN = 1831f;
				BCFCMJODLCH = BJGCPDNMHDH.ABKLOMBNDJB * BJGCPDNMHDH.JGNJJIKPICF;
				goto IL_005f;
			case 1u:
				{
					if (!(BJGCPDNMHDH.CGJIGBDGOOO.transform.localScale.x > BCFCMJODLCH) && !(BJGCPDNMHDH.MNAJKODCACI.transform.localScale.x > BCFCMJODLCH))
					{
						BJGCPDNMHDH.CGJIGBDGOOO.gameObject.SetActive(value: true);
						CLPPIAGLCJJ = -1;
						break;
					}
					goto IL_005f;
				}
				IL_005f:
				GOMMNPDKINN += TimeManager.deltaTimeWithoutPauses;
				LFBOLPAFMCG = BJGCPDNMHDH.JGNJJIKPICF * TimeManager.deltaTimeWithoutPauses / BJGCPDNMHDH.DGHFKLCHLPN;
				DBAPKJNHDLH = ((!(GOMMNPDKINN < BJGCPDNMHDH.NJJCPOKOMGK)) ? (BJGCPDNMHDH.JGNJJIKPICF * TimeManager.deltaTimeWithoutPauses / BJGCPDNMHDH.PPMIJLPPNCP) : 824f);
				BJGCPDNMHDH.MNAJKODCACI.transform.localScale = BJGCPDNMHDH.MNAJKODCACI.transform.localScale.ReplaceX(Mathf.Max(BCFCMJODLCH, BJGCPDNMHDH.MNAJKODCACI.transform.localScale.x - LFBOLPAFMCG));
				BJGCPDNMHDH.CGJIGBDGOOO.transform.localScale = BJGCPDNMHDH.CGJIGBDGOOO.transform.localScale.ReplaceX(Mathf.Max(BCFCMJODLCH, BJGCPDNMHDH.CGJIGBDGOOO.transform.localScale.x - DBAPKJNHDLH));
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			}
			return true;
		}

		public bool PMBOHHPPJAC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.CGJIGBDGOOO.gameObject.SetActive(value: true);
				GOMMNPDKINN = 413f;
				BCFCMJODLCH = BJGCPDNMHDH.ABKLOMBNDJB * BJGCPDNMHDH.JGNJJIKPICF;
				goto IL_005f;
			case 1u:
				{
					if (!(BJGCPDNMHDH.CGJIGBDGOOO.transform.localScale.x > BCFCMJODLCH) && !(BJGCPDNMHDH.MNAJKODCACI.transform.localScale.x > BCFCMJODLCH))
					{
						BJGCPDNMHDH.CGJIGBDGOOO.gameObject.SetActive(value: true);
						CLPPIAGLCJJ = -1;
						break;
					}
					goto IL_005f;
				}
				IL_005f:
				GOMMNPDKINN += TimeManager.deltaTimeWithoutPauses;
				LFBOLPAFMCG = BJGCPDNMHDH.JGNJJIKPICF * TimeManager.deltaTimeWithoutPauses / BJGCPDNMHDH.DGHFKLCHLPN;
				DBAPKJNHDLH = ((!(GOMMNPDKINN < BJGCPDNMHDH.NJJCPOKOMGK)) ? (BJGCPDNMHDH.JGNJJIKPICF * TimeManager.deltaTimeWithoutPauses / BJGCPDNMHDH.PPMIJLPPNCP) : 809f);
				BJGCPDNMHDH.MNAJKODCACI.transform.localScale = BJGCPDNMHDH.MNAJKODCACI.transform.localScale.ReplaceX(Mathf.Max(BCFCMJODLCH, BJGCPDNMHDH.MNAJKODCACI.transform.localScale.x - LFBOLPAFMCG));
				BJGCPDNMHDH.CGJIGBDGOOO.transform.localScale = BJGCPDNMHDH.CGJIGBDGOOO.transform.localScale.ReplaceX(Mathf.Max(BCFCMJODLCH, BJGCPDNMHDH.CGJIGBDGOOO.transform.localScale.x - DBAPKJNHDLH));
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			}
			return false;
		}

		public void PMAJELGBBKE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void POJKIIMAFDO()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CEFJLKJNAKJ()
		{
			return PHDOCKCBJOF;
		}

		public void GFPDOCDEGPA()
		{
			throw new NotSupportedException();
		}

		public void PNGIELILHDI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HMBLLDJFIJG()
		{
			throw new NotSupportedException();
		}

		public void IMFLNKIMEFA()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public bool DMPHMFDEINI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.CGJIGBDGOOO.gameObject.SetActive(value: false);
				GOMMNPDKINN = 1863f;
				BCFCMJODLCH = BJGCPDNMHDH.ABKLOMBNDJB * BJGCPDNMHDH.JGNJJIKPICF;
				goto IL_005f;
			case 1u:
				{
					if (!(BJGCPDNMHDH.CGJIGBDGOOO.transform.localScale.x > BCFCMJODLCH) && !(BJGCPDNMHDH.MNAJKODCACI.transform.localScale.x > BCFCMJODLCH))
					{
						BJGCPDNMHDH.CGJIGBDGOOO.gameObject.SetActive(value: true);
						CLPPIAGLCJJ = -1;
						break;
					}
					goto IL_005f;
				}
				IL_005f:
				GOMMNPDKINN += TimeManager.deltaTimeWithoutPauses;
				LFBOLPAFMCG = BJGCPDNMHDH.JGNJJIKPICF * TimeManager.deltaTimeWithoutPauses / BJGCPDNMHDH.DGHFKLCHLPN;
				DBAPKJNHDLH = ((!(GOMMNPDKINN < BJGCPDNMHDH.NJJCPOKOMGK)) ? (BJGCPDNMHDH.JGNJJIKPICF * TimeManager.deltaTimeWithoutPauses / BJGCPDNMHDH.PPMIJLPPNCP) : 1945f);
				BJGCPDNMHDH.MNAJKODCACI.transform.localScale = BJGCPDNMHDH.MNAJKODCACI.transform.localScale.ReplaceX(Mathf.Max(BCFCMJODLCH, BJGCPDNMHDH.MNAJKODCACI.transform.localScale.x - LFBOLPAFMCG));
				BJGCPDNMHDH.CGJIGBDGOOO.transform.localScale = BJGCPDNMHDH.CGJIGBDGOOO.transform.localScale.ReplaceX(Mathf.Max(BCFCMJODLCH, BJGCPDNMHDH.CGJIGBDGOOO.transform.localScale.x - DBAPKJNHDLH));
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			}
			return true;
		}

		public void FGLAPPKJHBK()
		{
			throw new NotSupportedException();
		}

		public void NFLHLMKKJMO()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void IBDAHMOEBCM()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public NLFKOCOKPEE()
		{
		}

		public void CHFJIODFNIP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool FNEPBDLIKOD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.CGJIGBDGOOO.gameObject.SetActive(value: false);
				GOMMNPDKINN = 734f;
				BCFCMJODLCH = BJGCPDNMHDH.ABKLOMBNDJB * BJGCPDNMHDH.JGNJJIKPICF;
				goto IL_005f;
			case 1u:
				{
					if (!(BJGCPDNMHDH.CGJIGBDGOOO.transform.localScale.x > BCFCMJODLCH) && !(BJGCPDNMHDH.MNAJKODCACI.transform.localScale.x > BCFCMJODLCH))
					{
						BJGCPDNMHDH.CGJIGBDGOOO.gameObject.SetActive(value: true);
						CLPPIAGLCJJ = -1;
						break;
					}
					goto IL_005f;
				}
				IL_005f:
				GOMMNPDKINN += TimeManager.deltaTimeWithoutPauses;
				LFBOLPAFMCG = BJGCPDNMHDH.JGNJJIKPICF * TimeManager.deltaTimeWithoutPauses / BJGCPDNMHDH.DGHFKLCHLPN;
				DBAPKJNHDLH = ((!(GOMMNPDKINN < BJGCPDNMHDH.NJJCPOKOMGK)) ? (BJGCPDNMHDH.JGNJJIKPICF * TimeManager.deltaTimeWithoutPauses / BJGCPDNMHDH.PPMIJLPPNCP) : 1736f);
				BJGCPDNMHDH.MNAJKODCACI.transform.localScale = BJGCPDNMHDH.MNAJKODCACI.transform.localScale.ReplaceX(Mathf.Max(BCFCMJODLCH, BJGCPDNMHDH.MNAJKODCACI.transform.localScale.x - LFBOLPAFMCG));
				BJGCPDNMHDH.CGJIGBDGOOO.transform.localScale = BJGCPDNMHDH.CGJIGBDGOOO.transform.localScale.ReplaceX(Mathf.Max(BCFCMJODLCH, BJGCPDNMHDH.CGJIGBDGOOO.transform.localScale.x - DBAPKJNHDLH));
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			}
			return false;
		}

		public void JJOAHIOBOPO()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FKPDNNMENFD()
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
				BJGCPDNMHDH.CGJIGBDGOOO.gameObject.SetActive(value: true);
				GOMMNPDKINN = 1381f;
				BCFCMJODLCH = BJGCPDNMHDH.ABKLOMBNDJB * BJGCPDNMHDH.JGNJJIKPICF;
				goto IL_005f;
			case 1u:
				{
					if (!(BJGCPDNMHDH.CGJIGBDGOOO.transform.localScale.x > BCFCMJODLCH) && !(BJGCPDNMHDH.MNAJKODCACI.transform.localScale.x > BCFCMJODLCH))
					{
						BJGCPDNMHDH.CGJIGBDGOOO.gameObject.SetActive(value: true);
						CLPPIAGLCJJ = -1;
						break;
					}
					goto IL_005f;
				}
				IL_005f:
				GOMMNPDKINN += TimeManager.deltaTimeWithoutPauses;
				LFBOLPAFMCG = BJGCPDNMHDH.JGNJJIKPICF * TimeManager.deltaTimeWithoutPauses / BJGCPDNMHDH.DGHFKLCHLPN;
				DBAPKJNHDLH = ((!(GOMMNPDKINN < BJGCPDNMHDH.NJJCPOKOMGK)) ? (BJGCPDNMHDH.JGNJJIKPICF * TimeManager.deltaTimeWithoutPauses / BJGCPDNMHDH.PPMIJLPPNCP) : 31f);
				BJGCPDNMHDH.MNAJKODCACI.transform.localScale = BJGCPDNMHDH.MNAJKODCACI.transform.localScale.ReplaceX(Mathf.Max(BCFCMJODLCH, BJGCPDNMHDH.MNAJKODCACI.transform.localScale.x - LFBOLPAFMCG));
				BJGCPDNMHDH.CGJIGBDGOOO.transform.localScale = BJGCPDNMHDH.CGJIGBDGOOO.transform.localScale.ReplaceX(Mathf.Max(BCFCMJODLCH, BJGCPDNMHDH.CGJIGBDGOOO.transform.localScale.x - DBAPKJNHDLH));
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			}
			return false;
		}

		public void FMOJMHBAHAA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
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
				BJGCPDNMHDH.CGJIGBDGOOO.gameObject.SetActive(value: true);
				GOMMNPDKINN = 1816f;
				BCFCMJODLCH = BJGCPDNMHDH.ABKLOMBNDJB * BJGCPDNMHDH.JGNJJIKPICF;
				goto IL_005f;
			case 1u:
				{
					if (!(BJGCPDNMHDH.CGJIGBDGOOO.transform.localScale.x > BCFCMJODLCH) && !(BJGCPDNMHDH.MNAJKODCACI.transform.localScale.x > BCFCMJODLCH))
					{
						BJGCPDNMHDH.CGJIGBDGOOO.gameObject.SetActive(value: true);
						CLPPIAGLCJJ = -1;
						break;
					}
					goto IL_005f;
				}
				IL_005f:
				GOMMNPDKINN += TimeManager.deltaTimeWithoutPauses;
				LFBOLPAFMCG = BJGCPDNMHDH.JGNJJIKPICF * TimeManager.deltaTimeWithoutPauses / BJGCPDNMHDH.DGHFKLCHLPN;
				DBAPKJNHDLH = ((!(GOMMNPDKINN < BJGCPDNMHDH.NJJCPOKOMGK)) ? (BJGCPDNMHDH.JGNJJIKPICF * TimeManager.deltaTimeWithoutPauses / BJGCPDNMHDH.PPMIJLPPNCP) : 479f);
				BJGCPDNMHDH.MNAJKODCACI.transform.localScale = BJGCPDNMHDH.MNAJKODCACI.transform.localScale.ReplaceX(Mathf.Max(BCFCMJODLCH, BJGCPDNMHDH.MNAJKODCACI.transform.localScale.x - LFBOLPAFMCG));
				BJGCPDNMHDH.CGJIGBDGOOO.transform.localScale = BJGCPDNMHDH.CGJIGBDGOOO.transform.localScale.ReplaceX(Mathf.Max(BCFCMJODLCH, BJGCPDNMHDH.CGJIGBDGOOO.transform.localScale.x - DBAPKJNHDLH));
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			}
			return true;
		}

		public bool GAPIFMKNJBN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.CGJIGBDGOOO.gameObject.SetActive(value: true);
				GOMMNPDKINN = 932f;
				BCFCMJODLCH = BJGCPDNMHDH.ABKLOMBNDJB * BJGCPDNMHDH.JGNJJIKPICF;
				goto IL_005f;
			case 1u:
				{
					if (!(BJGCPDNMHDH.CGJIGBDGOOO.transform.localScale.x > BCFCMJODLCH) && !(BJGCPDNMHDH.MNAJKODCACI.transform.localScale.x > BCFCMJODLCH))
					{
						BJGCPDNMHDH.CGJIGBDGOOO.gameObject.SetActive(value: true);
						CLPPIAGLCJJ = -1;
						break;
					}
					goto IL_005f;
				}
				IL_005f:
				GOMMNPDKINN += TimeManager.deltaTimeWithoutPauses;
				LFBOLPAFMCG = BJGCPDNMHDH.JGNJJIKPICF * TimeManager.deltaTimeWithoutPauses / BJGCPDNMHDH.DGHFKLCHLPN;
				DBAPKJNHDLH = ((!(GOMMNPDKINN < BJGCPDNMHDH.NJJCPOKOMGK)) ? (BJGCPDNMHDH.JGNJJIKPICF * TimeManager.deltaTimeWithoutPauses / BJGCPDNMHDH.PPMIJLPPNCP) : 877f);
				BJGCPDNMHDH.MNAJKODCACI.transform.localScale = BJGCPDNMHDH.MNAJKODCACI.transform.localScale.ReplaceX(Mathf.Max(BCFCMJODLCH, BJGCPDNMHDH.MNAJKODCACI.transform.localScale.x - LFBOLPAFMCG));
				BJGCPDNMHDH.CGJIGBDGOOO.transform.localScale = BJGCPDNMHDH.CGJIGBDGOOO.transform.localScale.ReplaceX(Mathf.Max(BCFCMJODLCH, BJGCPDNMHDH.CGJIGBDGOOO.transform.localScale.x - DBAPKJNHDLH));
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			}
			return false;
		}

		[SpecialName]
		private object IHPDPKLEDKC()
		{
			return PHDOCKCBJOF;
		}

		public void NGAGGCFIEGJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object EBPKDAHAELB()
		{
			return PHDOCKCBJOF;
		}

		public void ODJLLLFJIOB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}
	}

	private sealed class FBFAAPEJNBB : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal float COOGKNIEOPA;

		internal PlayerHealthBarGuiElement BJGCPDNMHDH;

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
		private object PFIIINLHGMH()
		{
			return PHDOCKCBJOF;
		}

		public bool OGLKGILLKIO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.MNAJKODCACI.color = BJGCPDNMHDH.MNAJKODCACI.color.ReplaceA(1225f);
				PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.PPIPHNDIIGJ);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				COOGKNIEOPA = 1195f;
				goto case 2u;
			case 2u:
				if (COOGKNIEOPA < 1273f)
				{
					COOGKNIEOPA = Mathf.Clamp01(COOGKNIEOPA + TimeManager.deltaTimeWithoutPauses / BJGCPDNMHDH.LHADFLKGHGB);
					BJGCPDNMHDH.MNAJKODCACI.color = BJGCPDNMHDH.MNAJKODCACI.color.ReplaceA(Mathf.Lerp(1150f, BJGCPDNMHDH.KIANPDGODJJ, COOGKNIEOPA));
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
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

		public void KNFDDIHLBKJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IGMIIAODMNF()
		{
			return PHDOCKCBJOF;
		}

		public void LPKDPNHBLGJ()
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
		private object BJJNGPKNCKJ()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public FBFAAPEJNBB()
		{
		}

		[SpecialName]
		private object ABGFJLAPNNM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PCOOFELAEJA()
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
				BJGCPDNMHDH.MNAJKODCACI.color = BJGCPDNMHDH.MNAJKODCACI.color.ReplaceA(1f);
				PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.PPIPHNDIIGJ);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				COOGKNIEOPA = 0f;
				goto case 2u;
			case 2u:
				if (COOGKNIEOPA < 1f)
				{
					COOGKNIEOPA = Mathf.Clamp01(COOGKNIEOPA + TimeManager.deltaTimeWithoutPauses / BJGCPDNMHDH.LHADFLKGHGB);
					BJGCPDNMHDH.MNAJKODCACI.color = BJGCPDNMHDH.MNAJKODCACI.color.ReplaceA(Mathf.Lerp(1f, BJGCPDNMHDH.KIANPDGODJJ, COOGKNIEOPA));
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
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

		public void IFLGJMJCOMC()
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

		public void NINFNJOMJOD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void GCEMCPODLNM()
		{
			throw new NotSupportedException();
		}

		public bool NJBCJDFKGHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.MNAJKODCACI.color = BJGCPDNMHDH.MNAJKODCACI.color.ReplaceA(1357f);
				PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.PPIPHNDIIGJ);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				COOGKNIEOPA = 1407f;
				goto case 2u;
			case 2u:
				if (COOGKNIEOPA < 1006f)
				{
					COOGKNIEOPA = Mathf.Clamp01(COOGKNIEOPA + TimeManager.deltaTimeWithoutPauses / BJGCPDNMHDH.LHADFLKGHGB);
					BJGCPDNMHDH.MNAJKODCACI.color = BJGCPDNMHDH.MNAJKODCACI.color.ReplaceA(Mathf.Lerp(1438f, BJGCPDNMHDH.KIANPDGODJJ, COOGKNIEOPA));
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
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
		private object BGLDNJLBIKM()
		{
			return PHDOCKCBJOF;
		}

		public void AKEKFBGEJBG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool FCJCLBMPBFK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.MNAJKODCACI.color = BJGCPDNMHDH.MNAJKODCACI.color.ReplaceA(1197f);
				PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.PPIPHNDIIGJ);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				COOGKNIEOPA = 719f;
				goto case 2u;
			case 2u:
				if (COOGKNIEOPA < 1101f)
				{
					COOGKNIEOPA = Mathf.Clamp01(COOGKNIEOPA + TimeManager.deltaTimeWithoutPauses / BJGCPDNMHDH.LHADFLKGHGB);
					BJGCPDNMHDH.MNAJKODCACI.color = BJGCPDNMHDH.MNAJKODCACI.color.ReplaceA(Mathf.Lerp(631f, BJGCPDNMHDH.KIANPDGODJJ, COOGKNIEOPA));
					PHDOCKCBJOF = 1;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
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

		public bool LGNMOMFLLPP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.MNAJKODCACI.color = BJGCPDNMHDH.MNAJKODCACI.color.ReplaceA(1127f);
				PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.PPIPHNDIIGJ);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				COOGKNIEOPA = 1580f;
				goto case 2u;
			case 2u:
				if (COOGKNIEOPA < 82f)
				{
					COOGKNIEOPA = Mathf.Clamp01(COOGKNIEOPA + TimeManager.deltaTimeWithoutPauses / BJGCPDNMHDH.LHADFLKGHGB);
					BJGCPDNMHDH.MNAJKODCACI.color = BJGCPDNMHDH.MNAJKODCACI.color.ReplaceA(Mathf.Lerp(1549f, BJGCPDNMHDH.KIANPDGODJJ, COOGKNIEOPA));
					PHDOCKCBJOF = 1;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
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

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BGAGLOJHMEJ()
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
				BJGCPDNMHDH.MNAJKODCACI.color = BJGCPDNMHDH.MNAJKODCACI.color.ReplaceA(771f);
				PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.PPIPHNDIIGJ);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				COOGKNIEOPA = 1576f;
				goto case 2u;
			case 2u:
				if (COOGKNIEOPA < 502f)
				{
					COOGKNIEOPA = Mathf.Clamp01(COOGKNIEOPA + TimeManager.deltaTimeWithoutPauses / BJGCPDNMHDH.LHADFLKGHGB);
					BJGCPDNMHDH.MNAJKODCACI.color = BJGCPDNMHDH.MNAJKODCACI.color.ReplaceA(Mathf.Lerp(956f, BJGCPDNMHDH.KIANPDGODJJ, COOGKNIEOPA));
					PHDOCKCBJOF = 1;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
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
		private object HFKDIPEKENH()
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
				BJGCPDNMHDH.MNAJKODCACI.color = BJGCPDNMHDH.MNAJKODCACI.color.ReplaceA(1125f);
				PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.PPIPHNDIIGJ);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				COOGKNIEOPA = 256f;
				goto case 2u;
			case 2u:
				if (COOGKNIEOPA < 88f)
				{
					COOGKNIEOPA = Mathf.Clamp01(COOGKNIEOPA + TimeManager.deltaTimeWithoutPauses / BJGCPDNMHDH.LHADFLKGHGB);
					BJGCPDNMHDH.MNAJKODCACI.color = BJGCPDNMHDH.MNAJKODCACI.color.ReplaceA(Mathf.Lerp(489f, BJGCPDNMHDH.KIANPDGODJJ, COOGKNIEOPA));
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
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
		private object FPFOODLPEBK()
		{
			return PHDOCKCBJOF;
		}

		public void MKIKEOOOLKL()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void ONGBFFAENBP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object CJCHFDFCPPL()
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
				BJGCPDNMHDH.MNAJKODCACI.color = BJGCPDNMHDH.MNAJKODCACI.color.ReplaceA(579f);
				PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.PPIPHNDIIGJ);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				COOGKNIEOPA = 606f;
				goto case 2u;
			case 2u:
				if (COOGKNIEOPA < 718f)
				{
					COOGKNIEOPA = Mathf.Clamp01(COOGKNIEOPA + TimeManager.deltaTimeWithoutPauses / BJGCPDNMHDH.LHADFLKGHGB);
					BJGCPDNMHDH.MNAJKODCACI.color = BJGCPDNMHDH.MNAJKODCACI.color.ReplaceA(Mathf.Lerp(471f, BJGCPDNMHDH.KIANPDGODJJ, COOGKNIEOPA));
					PHDOCKCBJOF = 0;
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
		private object IGFMIFOHCHJ()
		{
			return PHDOCKCBJOF;
		}

		public void IGBHHLFACKO()
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
				BJGCPDNMHDH.MNAJKODCACI.color = BJGCPDNMHDH.MNAJKODCACI.color.ReplaceA(934f);
				PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.PPIPHNDIIGJ);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				COOGKNIEOPA = 762f;
				goto case 2u;
			case 2u:
				if (COOGKNIEOPA < 428f)
				{
					COOGKNIEOPA = Mathf.Clamp01(COOGKNIEOPA + TimeManager.deltaTimeWithoutPauses / BJGCPDNMHDH.LHADFLKGHGB);
					BJGCPDNMHDH.MNAJKODCACI.color = BJGCPDNMHDH.MNAJKODCACI.color.ReplaceA(Mathf.Lerp(1304f, BJGCPDNMHDH.KIANPDGODJJ, COOGKNIEOPA));
					PHDOCKCBJOF = 1;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
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

		public bool MPKAJACHAIC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.MNAJKODCACI.color = BJGCPDNMHDH.MNAJKODCACI.color.ReplaceA(522f);
				PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.PPIPHNDIIGJ);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				COOGKNIEOPA = 763f;
				goto case 2u;
			case 2u:
				if (COOGKNIEOPA < 271f)
				{
					COOGKNIEOPA = Mathf.Clamp01(COOGKNIEOPA + TimeManager.deltaTimeWithoutPauses / BJGCPDNMHDH.LHADFLKGHGB);
					BJGCPDNMHDH.MNAJKODCACI.color = BJGCPDNMHDH.MNAJKODCACI.color.ReplaceA(Mathf.Lerp(1553f, BJGCPDNMHDH.KIANPDGODJJ, COOGKNIEOPA));
					PHDOCKCBJOF = 0;
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
		private object CLFFFNGBPGJ()
		{
			return PHDOCKCBJOF;
		}

		public void ODFCBNONFPL()
		{
			throw new NotSupportedException();
		}

		public void IJHCIJLDKHK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object NMGBFNNHIPN()
		{
			return PHDOCKCBJOF;
		}

		public bool DFMKKFMEBON()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.MNAJKODCACI.color = BJGCPDNMHDH.MNAJKODCACI.color.ReplaceA(690f);
				PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.PPIPHNDIIGJ);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				COOGKNIEOPA = 338f;
				goto case 2u;
			case 2u:
				if (COOGKNIEOPA < 973f)
				{
					COOGKNIEOPA = Mathf.Clamp01(COOGKNIEOPA + TimeManager.deltaTimeWithoutPauses / BJGCPDNMHDH.LHADFLKGHGB);
					BJGCPDNMHDH.MNAJKODCACI.color = BJGCPDNMHDH.MNAJKODCACI.color.ReplaceA(Mathf.Lerp(1734f, BJGCPDNMHDH.KIANPDGODJJ, COOGKNIEOPA));
					PHDOCKCBJOF = 1;
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

		public bool CJGKHIPOBGP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.MNAJKODCACI.color = BJGCPDNMHDH.MNAJKODCACI.color.ReplaceA(1397f);
				PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.PPIPHNDIIGJ);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				COOGKNIEOPA = 1361f;
				goto case 2u;
			case 2u:
				if (COOGKNIEOPA < 1893f)
				{
					COOGKNIEOPA = Mathf.Clamp01(COOGKNIEOPA + TimeManager.deltaTimeWithoutPauses / BJGCPDNMHDH.LHADFLKGHGB);
					BJGCPDNMHDH.MNAJKODCACI.color = BJGCPDNMHDH.MNAJKODCACI.color.ReplaceA(Mathf.Lerp(751f, BJGCPDNMHDH.KIANPDGODJJ, COOGKNIEOPA));
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
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

		public void KKDOJDCJAJB()
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
				BJGCPDNMHDH.MNAJKODCACI.color = BJGCPDNMHDH.MNAJKODCACI.color.ReplaceA(1972f);
				PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.PPIPHNDIIGJ);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				COOGKNIEOPA = 726f;
				goto case 2u;
			case 2u:
				if (COOGKNIEOPA < 910f)
				{
					COOGKNIEOPA = Mathf.Clamp01(COOGKNIEOPA + TimeManager.deltaTimeWithoutPauses / BJGCPDNMHDH.LHADFLKGHGB);
					BJGCPDNMHDH.MNAJKODCACI.color = BJGCPDNMHDH.MNAJKODCACI.color.ReplaceA(Mathf.Lerp(403f, BJGCPDNMHDH.KIANPDGODJJ, COOGKNIEOPA));
					PHDOCKCBJOF = 1;
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
		private object GJMNLPAEIDA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GMPGIODBIPO()
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
				BJGCPDNMHDH.MNAJKODCACI.color = BJGCPDNMHDH.MNAJKODCACI.color.ReplaceA(1553f);
				PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.PPIPHNDIIGJ);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				COOGKNIEOPA = 1611f;
				goto case 2u;
			case 2u:
				if (COOGKNIEOPA < 1115f)
				{
					COOGKNIEOPA = Mathf.Clamp01(COOGKNIEOPA + TimeManager.deltaTimeWithoutPauses / BJGCPDNMHDH.LHADFLKGHGB);
					BJGCPDNMHDH.MNAJKODCACI.color = BJGCPDNMHDH.MNAJKODCACI.color.ReplaceA(Mathf.Lerp(1427f, BJGCPDNMHDH.KIANPDGODJJ, COOGKNIEOPA));
					PHDOCKCBJOF = 1;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
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

		public bool PGOBEIMCPGA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.MNAJKODCACI.color = BJGCPDNMHDH.MNAJKODCACI.color.ReplaceA(807f);
				PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.PPIPHNDIIGJ);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				COOGKNIEOPA = 1960f;
				goto case 2u;
			case 2u:
				if (COOGKNIEOPA < 261f)
				{
					COOGKNIEOPA = Mathf.Clamp01(COOGKNIEOPA + TimeManager.deltaTimeWithoutPauses / BJGCPDNMHDH.LHADFLKGHGB);
					BJGCPDNMHDH.MNAJKODCACI.color = BJGCPDNMHDH.MNAJKODCACI.color.ReplaceA(Mathf.Lerp(271f, BJGCPDNMHDH.KIANPDGODJJ, COOGKNIEOPA));
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
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
	}

	private sealed class OAMJNPNCIBK : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal float BIALBBNFIPD;

		internal float PJMCFLNKCDH;

		internal PlayerHealthBarGuiElement BJGCPDNMHDH;

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
		public OAMJNPNCIBK()
		{
		}

		[SpecialName]
		private object IGMIIAODMNF()
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
				BJGCPDNMHDH.BNHAJBLDKOP = true;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.MBIAKMPDOPG != null && BJGCPDNMHDH.MBIAKMPDOPG.OBEIMNKPABG())
				{
					BIALBBNFIPD = TimeManager.realTimeWithoutPauses / BJGCPDNMHDH.AGGNPHKCLAB;
					PJMCFLNKCDH = BJGCPDNMHDH.CMGEMNIIGND.Evaluate(BIALBBNFIPD);
					BJGCPDNMHDH.MNAJKODCACI.alpha = PJMCFLNKCDH;
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.MNAJKODCACI.alpha = 1364f;
				BJGCPDNMHDH.BNHAJBLDKOP = true;
				if (BJGCPDNMHDH.DOLNDLHICOO.isPlaying)
				{
					BJGCPDNMHDH.DOLNDLHICOO.Stop();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object MOMPOEEALPJ()
		{
			return PHDOCKCBJOF;
		}

		public void HEOPOOMLPJF()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object AGANCOFPDCK()
		{
			return PHDOCKCBJOF;
		}

		public void GGCLMIMHKBD()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
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

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.BNHAJBLDKOP = true;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.MBIAKMPDOPG != null && BJGCPDNMHDH.MBIAKMPDOPG.IsNearDeath())
				{
					BIALBBNFIPD = TimeManager.realTimeWithoutPauses / BJGCPDNMHDH.AGGNPHKCLAB;
					PJMCFLNKCDH = BJGCPDNMHDH.CMGEMNIIGND.Evaluate(BIALBBNFIPD);
					BJGCPDNMHDH.MNAJKODCACI.alpha = PJMCFLNKCDH;
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.MNAJKODCACI.alpha = 1f;
				BJGCPDNMHDH.BNHAJBLDKOP = false;
				if (BJGCPDNMHDH.DOLNDLHICOO.isPlaying)
				{
					BJGCPDNMHDH.DOLNDLHICOO.Stop();
				}
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
		private object PIPMONHGDPH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IHAOBCEALPD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GMPGIODBIPO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HIFNMHAGHLI()
		{
			return PHDOCKCBJOF;
		}

		public void EMICCACCFIP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MHKODCGLJFD()
		{
			return PHDOCKCBJOF;
		}

		public bool OGLKGILLKIO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.BNHAJBLDKOP = true;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.MBIAKMPDOPG != null && BJGCPDNMHDH.MBIAKMPDOPG.IsNearDeath())
				{
					BIALBBNFIPD = TimeManager.CEAFAMFNGCC() / BJGCPDNMHDH.AGGNPHKCLAB;
					PJMCFLNKCDH = BJGCPDNMHDH.CMGEMNIIGND.Evaluate(BIALBBNFIPD);
					BJGCPDNMHDH.MNAJKODCACI.alpha = PJMCFLNKCDH;
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.MNAJKODCACI.alpha = 464f;
				BJGCPDNMHDH.BNHAJBLDKOP = true;
				if (BJGCPDNMHDH.DOLNDLHICOO.isPlaying)
				{
					BJGCPDNMHDH.DOLNDLHICOO.Stop();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public bool HKPECDLGFJB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.BNHAJBLDKOP = false;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.MBIAKMPDOPG != null && BJGCPDNMHDH.MBIAKMPDOPG.OBEIMNKPABG())
				{
					BIALBBNFIPD = TimeManager.CEAFAMFNGCC() / BJGCPDNMHDH.AGGNPHKCLAB;
					PJMCFLNKCDH = BJGCPDNMHDH.CMGEMNIIGND.Evaluate(BIALBBNFIPD);
					BJGCPDNMHDH.MNAJKODCACI.alpha = PJMCFLNKCDH;
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.MNAJKODCACI.alpha = 935f;
				BJGCPDNMHDH.BNHAJBLDKOP = true;
				if (BJGCPDNMHDH.DOLNDLHICOO.isPlaying)
				{
					BJGCPDNMHDH.DOLNDLHICOO.Stop();
				}
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
				BJGCPDNMHDH.BNHAJBLDKOP = true;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.MBIAKMPDOPG != null && BJGCPDNMHDH.MBIAKMPDOPG.OBEIMNKPABG())
				{
					BIALBBNFIPD = TimeManager.CEAFAMFNGCC() / BJGCPDNMHDH.AGGNPHKCLAB;
					PJMCFLNKCDH = BJGCPDNMHDH.CMGEMNIIGND.Evaluate(BIALBBNFIPD);
					BJGCPDNMHDH.MNAJKODCACI.alpha = PJMCFLNKCDH;
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.MNAJKODCACI.alpha = 1210f;
				BJGCPDNMHDH.BNHAJBLDKOP = true;
				if (BJGCPDNMHDH.DOLNDLHICOO.isPlaying)
				{
					BJGCPDNMHDH.DOLNDLHICOO.Stop();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object LMBPPPOFIOC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CLDLJNHAEAB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HHLKEMNNJDA()
		{
			return PHDOCKCBJOF;
		}

		public void HHCBBENDENJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}
	}

	private sealed class PLDLDNEHMHE : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal Coroutine IABHIMGMACN;

		internal Coroutine MMGJKDBEMCP;

		internal Coroutine PAEBHEPCNJP;

		internal PlayerHealthBarGuiElement BJGCPDNMHDH;

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
		private object HMIFLGCBDCO()
		{
			return PHDOCKCBJOF;
		}

		public void JKOCLGOOBEK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MPHILJJDNIO()
		{
			return PHDOCKCBJOF;
		}

		public void OKIANDBCDIB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void CHFJIODFNIP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void OPMABIIDKCN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HCCLNDKNCIE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MKNFFJPADIA()
		{
			return PHDOCKCBJOF;
		}

		public void ABBPOMCBIIH()
		{
			throw new NotSupportedException();
		}

		public bool NIGJJBALHDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				IABHIMGMACN = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.IKEECEOGHND(BJGCPDNMHDH.KMFGCJEGJJK, BJGCPDNMHDH.HOLDFDIMINM, BJGCPDNMHDH.OJJHFNFKPAE, BJGCPDNMHDH.HCCGAHHEBDG));
				MMGJKDBEMCP = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.BBBHKJOOPCH(BJGCPDNMHDH.MNAJKODCACI, BJGCPDNMHDH.JGNJJIKPICF, BJGCPDNMHDH.KFCAJKMKNCH, BJGCPDNMHDH.IEPNPCCENAK + BJGCPDNMHDH.HCCGAHHEBDG));
				PAEBHEPCNJP = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.ILPOPEAIEFO(BJGCPDNMHDH.NLLGKNMNIBG, BJGCPDNMHDH.IHKIEOOHBLN + BJGCPDNMHDH.HCCGAHHEBDG));
				PHDOCKCBJOF = IABHIMGMACN;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				PHDOCKCBJOF = MMGJKDBEMCP;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
				PHDOCKCBJOF = PAEBHEPCNJP;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 3u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void HCJOIAHBFGB()
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
		private object BGMNDLEJNHH()
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
				IABHIMGMACN = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.FPLNNGCLGHD(BJGCPDNMHDH.KMFGCJEGJJK, BJGCPDNMHDH.HOLDFDIMINM, BJGCPDNMHDH.OJJHFNFKPAE, BJGCPDNMHDH.HCCGAHHEBDG));
				MMGJKDBEMCP = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.FPLNNGCLGHD(BJGCPDNMHDH.MNAJKODCACI, BJGCPDNMHDH.JGNJJIKPICF, BJGCPDNMHDH.KFCAJKMKNCH, BJGCPDNMHDH.IEPNPCCENAK + BJGCPDNMHDH.HCCGAHHEBDG));
				PAEBHEPCNJP = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.PFCLJIEGLEA(BJGCPDNMHDH.NLLGKNMNIBG, BJGCPDNMHDH.IHKIEOOHBLN + BJGCPDNMHDH.HCCGAHHEBDG));
				PHDOCKCBJOF = IABHIMGMACN;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				PHDOCKCBJOF = MMGJKDBEMCP;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
				PHDOCKCBJOF = PAEBHEPCNJP;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 3u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public bool OKELILGDPLJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				IABHIMGMACN = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.IGDLKNNOGLO(BJGCPDNMHDH.KMFGCJEGJJK, BJGCPDNMHDH.HOLDFDIMINM, BJGCPDNMHDH.OJJHFNFKPAE, BJGCPDNMHDH.HCCGAHHEBDG));
				MMGJKDBEMCP = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.NDACGPKJHID(BJGCPDNMHDH.MNAJKODCACI, BJGCPDNMHDH.JGNJJIKPICF, BJGCPDNMHDH.KFCAJKMKNCH, BJGCPDNMHDH.IEPNPCCENAK + BJGCPDNMHDH.HCCGAHHEBDG));
				PAEBHEPCNJP = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.APCKNOHMGDM(BJGCPDNMHDH.NLLGKNMNIBG, BJGCPDNMHDH.IHKIEOOHBLN + BJGCPDNMHDH.HCCGAHHEBDG));
				PHDOCKCBJOF = IABHIMGMACN;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				PHDOCKCBJOF = MMGJKDBEMCP;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
				PHDOCKCBJOF = PAEBHEPCNJP;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 3u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void IJHCIJLDKHK()
		{
			throw new NotSupportedException();
		}

		public void MENEBJLDGJD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CIGHIOCACPH()
		{
			return PHDOCKCBJOF;
		}

		public void FOODPOJODAA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BGLDNJLBIKM()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void MKACBCOLNKD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public PLDLDNEHMHE()
		{
		}

		public void IKNKDDMLDIN()
		{
			throw new NotSupportedException();
		}

		public void HPJKDIGCCCE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void HONCAABOMOC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BOOBHEKPLLD()
		{
			return PHDOCKCBJOF;
		}

		public void ANOPOLIEBMC()
		{
			throw new NotSupportedException();
		}

		public void CPDBCJLIGFN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object AGANCOFPDCK()
		{
			return PHDOCKCBJOF;
		}

		public void FMOJMHBAHAA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object ONADHLDNKKB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PCOOFELAEJA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IHPDPKLEDKC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FIDLDFGJLFK()
		{
			return PHDOCKCBJOF;
		}

		public void JJOAHIOBOPO()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GOAJCEAOPLA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GDBNOMPNBGP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OJKHNOHHDGO()
		{
			return PHDOCKCBJOF;
		}

		public void ODJLLLFJIOB()
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
		private object MOMPOEEALPJ()
		{
			return PHDOCKCBJOF;
		}

		public bool FADACBKMFGG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				IABHIMGMACN = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.IGDLKNNOGLO(BJGCPDNMHDH.KMFGCJEGJJK, BJGCPDNMHDH.HOLDFDIMINM, BJGCPDNMHDH.OJJHFNFKPAE, BJGCPDNMHDH.HCCGAHHEBDG));
				MMGJKDBEMCP = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.CJJBFGMCAAO(BJGCPDNMHDH.MNAJKODCACI, BJGCPDNMHDH.JGNJJIKPICF, BJGCPDNMHDH.KFCAJKMKNCH, BJGCPDNMHDH.IEPNPCCENAK + BJGCPDNMHDH.HCCGAHHEBDG));
				PAEBHEPCNJP = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.PFCLJIEGLEA(BJGCPDNMHDH.NLLGKNMNIBG, BJGCPDNMHDH.IHKIEOOHBLN + BJGCPDNMHDH.HCCGAHHEBDG));
				PHDOCKCBJOF = IABHIMGMACN;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				PHDOCKCBJOF = MMGJKDBEMCP;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
				PHDOCKCBJOF = PAEBHEPCNJP;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 3u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void GGCLMIMHKBD()
		{
			throw new NotSupportedException();
		}
	}

	private sealed class DEICAGGPEDD : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal UISprite ACGMFDMBCCA;

		internal float KALLNCAFIMP;

		internal float COOGKNIEOPA;

		internal float KBJEOEEOEFG;

		internal float CEHFMMJHCKC;

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
		private object BOOBHEKPLLD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HMIFLGCBDCO()
		{
			return PHDOCKCBJOF;
		}

		public void MENEBJLDGJD()
		{
			throw new NotSupportedException();
		}

		public void LHADJAFHDDC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void POJKIIMAFDO()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JJBAIMILGLK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CLFFFNGBPGJ()
		{
			return PHDOCKCBJOF;
		}

		public void PHEIGPKKPGE()
		{
			throw new NotSupportedException();
		}

		public bool NJBCJDFKGHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ACGMFDMBCCA.transform.localScale = ACGMFDMBCCA.transform.localScale.ReplaceX(1830f);
				PHDOCKCBJOF = new WaitForSeconds(KALLNCAFIMP);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				COOGKNIEOPA = 328f;
				goto case 2u;
			case 2u:
				if (COOGKNIEOPA < 256f)
				{
					COOGKNIEOPA = Mathf.Clamp01(COOGKNIEOPA + TimeManager.deltaTimeWithoutPauses / KBJEOEEOEFG);
					ACGMFDMBCCA.transform.localScale = ACGMFDMBCCA.transform.localScale.ReplaceX(COOGKNIEOPA * CEHFMMJHCKC);
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
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
		private object IHPDPKLEDKC()
		{
			return PHDOCKCBJOF;
		}

		public void OJDEHKDDLFD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void GFPDOCDEGPA()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public DEICAGGPEDD()
		{
		}

		[SpecialName]
		private object HCPKEMLPEDI()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void MKACBCOLNKD()
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
				ACGMFDMBCCA.transform.localScale = ACGMFDMBCCA.transform.localScale.ReplaceX(1554f);
				PHDOCKCBJOF = new WaitForSeconds(KALLNCAFIMP);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				COOGKNIEOPA = 23f;
				goto case 2u;
			case 2u:
				if (COOGKNIEOPA < 1793f)
				{
					COOGKNIEOPA = Mathf.Clamp01(COOGKNIEOPA + TimeManager.deltaTimeWithoutPauses / KBJEOEEOEFG);
					ACGMFDMBCCA.transform.localScale = ACGMFDMBCCA.transform.localScale.ReplaceX(COOGKNIEOPA * CEHFMMJHCKC);
					PHDOCKCBJOF = null;
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

		public void OKIANDBCDIB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void EPKPNKGJHEC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object AGANCOFPDCK()
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
				ACGMFDMBCCA.transform.localScale = ACGMFDMBCCA.transform.localScale.ReplaceX(0f);
				PHDOCKCBJOF = new WaitForSeconds(KALLNCAFIMP);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				COOGKNIEOPA = 0f;
				goto case 2u;
			case 2u:
				if (COOGKNIEOPA < 1f)
				{
					COOGKNIEOPA = Mathf.Clamp01(COOGKNIEOPA + TimeManager.deltaTimeWithoutPauses / KBJEOEEOEFG);
					ACGMFDMBCCA.transform.localScale = ACGMFDMBCCA.transform.localScale.ReplaceX(COOGKNIEOPA * CEHFMMJHCKC);
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
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

		public void AHEOCEEJICJ()
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

		public bool MKLIDMNLNPN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ACGMFDMBCCA.transform.localScale = ACGMFDMBCCA.transform.localScale.ReplaceX(1144f);
				PHDOCKCBJOF = new WaitForSeconds(KALLNCAFIMP);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				COOGKNIEOPA = 1526f;
				goto case 2u;
			case 2u:
				if (COOGKNIEOPA < 1530f)
				{
					COOGKNIEOPA = Mathf.Clamp01(COOGKNIEOPA + TimeManager.deltaTimeWithoutPauses / KBJEOEEOEFG);
					ACGMFDMBCCA.transform.localScale = ACGMFDMBCCA.transform.localScale.ReplaceX(COOGKNIEOPA * CEHFMMJHCKC);
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
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

		public void NFLHLMKKJMO()
		{
			throw new NotSupportedException();
		}

		public void IJHCIJLDKHK()
		{
			throw new NotSupportedException();
		}
	}

	private sealed class FNPAALMBOIF : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal float KALLNCAFIMP;

		internal float COOGKNIEOPA;

		internal float KBJEOEEOEFG;

		internal PlayerHealthBarGuiElement BJGCPDNMHDH;

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

		public bool NEMOAIBCODB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.PKHHKJLGHFM.alpha = 1026f;
				PHDOCKCBJOF = new WaitForSeconds(KALLNCAFIMP);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				COOGKNIEOPA = 1740f;
				goto case 2u;
			case 2u:
				if (COOGKNIEOPA < 1789f)
				{
					COOGKNIEOPA = Mathf.Clamp01(COOGKNIEOPA + TimeManager.deltaTimeWithoutPauses / KBJEOEEOEFG);
					BJGCPDNMHDH.PKHHKJLGHFM.alpha = COOGKNIEOPA;
					BJGCPDNMHDH.GKFDJOICAHK.localPosition = BJGCPDNMHDH.GKFDJOICAHK.transform.localPosition.ReplaceY(BJGCPDNMHDH.FFOCLIDLFCF.Evaluate(COOGKNIEOPA));
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
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
		private object CEFJKELIBGG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MKEJDEGFKLC()
		{
			return PHDOCKCBJOF;
		}

		public void KMIHPBNFGFH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public bool NHLBGCIDHDE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.PKHHKJLGHFM.alpha = 1557f;
				PHDOCKCBJOF = new WaitForSeconds(KALLNCAFIMP);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				COOGKNIEOPA = 982f;
				goto case 2u;
			case 2u:
				if (COOGKNIEOPA < 569f)
				{
					COOGKNIEOPA = Mathf.Clamp01(COOGKNIEOPA + TimeManager.deltaTimeWithoutPauses / KBJEOEEOEFG);
					BJGCPDNMHDH.PKHHKJLGHFM.alpha = COOGKNIEOPA;
					BJGCPDNMHDH.GKFDJOICAHK.localPosition = BJGCPDNMHDH.GKFDJOICAHK.transform.localPosition.ReplaceY(BJGCPDNMHDH.FFOCLIDLFCF.Evaluate(COOGKNIEOPA));
					PHDOCKCBJOF = null;
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
		private object IIJAMNPBACH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LFEJDKIGHMI()
		{
			return PHDOCKCBJOF;
		}

		public void LOOMFHNKAND()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FKKBFFHMEME()
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
				BJGCPDNMHDH.PKHHKJLGHFM.alpha = 0f;
				PHDOCKCBJOF = new WaitForSeconds(KALLNCAFIMP);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				COOGKNIEOPA = 0f;
				goto case 2u;
			case 2u:
				if (COOGKNIEOPA < 1f)
				{
					COOGKNIEOPA = Mathf.Clamp01(COOGKNIEOPA + TimeManager.deltaTimeWithoutPauses / KBJEOEEOEFG);
					BJGCPDNMHDH.PKHHKJLGHFM.alpha = COOGKNIEOPA;
					BJGCPDNMHDH.GKFDJOICAHK.localPosition = BJGCPDNMHDH.GKFDJOICAHK.transform.localPosition.ReplaceY(BJGCPDNMHDH.FFOCLIDLFCF.Evaluate(COOGKNIEOPA));
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
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

		public bool MHCIOCPGMHF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.PKHHKJLGHFM.alpha = 934f;
				PHDOCKCBJOF = new WaitForSeconds(KALLNCAFIMP);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				COOGKNIEOPA = 525f;
				goto case 2u;
			case 2u:
				if (COOGKNIEOPA < 734f)
				{
					COOGKNIEOPA = Mathf.Clamp01(COOGKNIEOPA + TimeManager.deltaTimeWithoutPauses / KBJEOEEOEFG);
					BJGCPDNMHDH.PKHHKJLGHFM.alpha = COOGKNIEOPA;
					BJGCPDNMHDH.GKFDJOICAHK.localPosition = BJGCPDNMHDH.GKFDJOICAHK.transform.localPosition.ReplaceY(BJGCPDNMHDH.FFOCLIDLFCF.Evaluate(COOGKNIEOPA));
					PHDOCKCBJOF = null;
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
		private object FCBCEDKNBKC()
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
				BJGCPDNMHDH.PKHHKJLGHFM.alpha = 1451f;
				PHDOCKCBJOF = new WaitForSeconds(KALLNCAFIMP);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				COOGKNIEOPA = 775f;
				goto case 2u;
			case 2u:
				if (COOGKNIEOPA < 352f)
				{
					COOGKNIEOPA = Mathf.Clamp01(COOGKNIEOPA + TimeManager.deltaTimeWithoutPauses / KBJEOEEOEFG);
					BJGCPDNMHDH.PKHHKJLGHFM.alpha = COOGKNIEOPA;
					BJGCPDNMHDH.GKFDJOICAHK.localPosition = BJGCPDNMHDH.GKFDJOICAHK.transform.localPosition.ReplaceY(BJGCPDNMHDH.FFOCLIDLFCF.Evaluate(COOGKNIEOPA));
					PHDOCKCBJOF = null;
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
		private object GENJNMACGLP()
		{
			return PHDOCKCBJOF;
		}

		public void MKACBCOLNKD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object KPNBIPDNGOM()
		{
			return PHDOCKCBJOF;
		}

		public void LFIGPJBHPBH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HADIFBCDICK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CCANBMDEKMB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AGCPJGAAODG()
		{
			return PHDOCKCBJOF;
		}

		public void KINGACOICNF()
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
				BJGCPDNMHDH.PKHHKJLGHFM.alpha = 1872f;
				PHDOCKCBJOF = new WaitForSeconds(KALLNCAFIMP);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				COOGKNIEOPA = 1579f;
				goto case 2u;
			case 2u:
				if (COOGKNIEOPA < 549f)
				{
					COOGKNIEOPA = Mathf.Clamp01(COOGKNIEOPA + TimeManager.deltaTimeWithoutPauses / KBJEOEEOEFG);
					BJGCPDNMHDH.PKHHKJLGHFM.alpha = COOGKNIEOPA;
					BJGCPDNMHDH.GKFDJOICAHK.localPosition = BJGCPDNMHDH.GKFDJOICAHK.transform.localPosition.ReplaceY(BJGCPDNMHDH.FFOCLIDLFCF.Evaluate(COOGKNIEOPA));
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
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
		private object KDLMIDIEPHD()
		{
			return PHDOCKCBJOF;
		}

		public void IODFILFCENJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BBDOFDBCILK()
		{
			return PHDOCKCBJOF;
		}

		public void BCIPEBNJONK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void GBABLFGEIMF()
		{
			throw new NotSupportedException();
		}

		public void HANDHJHGLAP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public FNPAALMBOIF()
		{
		}

		public void GFGEEFGMNDP()
		{
			throw new NotSupportedException();
		}

		public bool DMPHMFDEINI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.PKHHKJLGHFM.alpha = 214f;
				PHDOCKCBJOF = new WaitForSeconds(KALLNCAFIMP);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				COOGKNIEOPA = 1586f;
				goto case 2u;
			case 2u:
				if (COOGKNIEOPA < 248f)
				{
					COOGKNIEOPA = Mathf.Clamp01(COOGKNIEOPA + TimeManager.deltaTimeWithoutPauses / KBJEOEEOEFG);
					BJGCPDNMHDH.PKHHKJLGHFM.alpha = COOGKNIEOPA;
					BJGCPDNMHDH.GKFDJOICAHK.localPosition = BJGCPDNMHDH.GKFDJOICAHK.transform.localPosition.ReplaceY(BJGCPDNMHDH.FFOCLIDLFCF.Evaluate(COOGKNIEOPA));
					PHDOCKCBJOF = null;
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

		[SpecialName]
		private object NIDLKNKKCND()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ADIAKJMNIEB()
		{
			return PHDOCKCBJOF;
		}

		public void IOBGNBBJOLM()
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
				BJGCPDNMHDH.PKHHKJLGHFM.alpha = 998f;
				PHDOCKCBJOF = new WaitForSeconds(KALLNCAFIMP);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				COOGKNIEOPA = 1421f;
				goto case 2u;
			case 2u:
				if (COOGKNIEOPA < 973f)
				{
					COOGKNIEOPA = Mathf.Clamp01(COOGKNIEOPA + TimeManager.deltaTimeWithoutPauses / KBJEOEEOEFG);
					BJGCPDNMHDH.PKHHKJLGHFM.alpha = COOGKNIEOPA;
					BJGCPDNMHDH.GKFDJOICAHK.localPosition = BJGCPDNMHDH.GKFDJOICAHK.transform.localPosition.ReplaceY(BJGCPDNMHDH.FFOCLIDLFCF.Evaluate(COOGKNIEOPA));
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
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
		private object CLBPPBIIAFP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EBPKDAHAELB()
		{
			return PHDOCKCBJOF;
		}

		public void DEPEHNFEJEE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JJBAIMILGLK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EPNOIENCFGA()
		{
			return PHDOCKCBJOF;
		}

		public void KNFDDIHLBKJ()
		{
			throw new NotSupportedException();
		}

		public void JKBIMBFGGCO()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object AKGMMLGANMJ()
		{
			return PHDOCKCBJOF;
		}

		public void HNBFJFDLABI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool PIAOIBJMLCC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.PKHHKJLGHFM.alpha = 555f;
				PHDOCKCBJOF = new WaitForSeconds(KALLNCAFIMP);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				COOGKNIEOPA = 458f;
				goto case 2u;
			case 2u:
				if (COOGKNIEOPA < 1057f)
				{
					COOGKNIEOPA = Mathf.Clamp01(COOGKNIEOPA + TimeManager.deltaTimeWithoutPauses / KBJEOEEOEFG);
					BJGCPDNMHDH.PKHHKJLGHFM.alpha = COOGKNIEOPA;
					BJGCPDNMHDH.GKFDJOICAHK.localPosition = BJGCPDNMHDH.GKFDJOICAHK.transform.localPosition.ReplaceY(BJGCPDNMHDH.FFOCLIDLFCF.Evaluate(COOGKNIEOPA));
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
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
		private object APECNPGKOFC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HGMMDPIGEGN()
		{
			return PHDOCKCBJOF;
		}

		public void ABBPOMCBIIH()
		{
			throw new NotSupportedException();
		}

		public void OIIFFJADGJG()
		{
			throw new NotSupportedException();
		}

		public void POJKIIMAFDO()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object NOIDHHDEEPL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CFCIACEHFHE()
		{
			return PHDOCKCBJOF;
		}

		public void FMOJMHBAHAA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MOOGINPIELE()
		{
			return PHDOCKCBJOF;
		}

		public void HHMPMPLLJCC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FKPDNNMENFD()
		{
			return PHDOCKCBJOF;
		}

		public bool CONJMMKAAGH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.PKHHKJLGHFM.alpha = 1271f;
				PHDOCKCBJOF = new WaitForSeconds(KALLNCAFIMP);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				COOGKNIEOPA = 842f;
				goto case 2u;
			case 2u:
				if (COOGKNIEOPA < 783f)
				{
					COOGKNIEOPA = Mathf.Clamp01(COOGKNIEOPA + TimeManager.deltaTimeWithoutPauses / KBJEOEEOEFG);
					BJGCPDNMHDH.PKHHKJLGHFM.alpha = COOGKNIEOPA;
					BJGCPDNMHDH.GKFDJOICAHK.localPosition = BJGCPDNMHDH.GKFDJOICAHK.transform.localPosition.ReplaceY(BJGCPDNMHDH.FFOCLIDLFCF.Evaluate(COOGKNIEOPA));
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
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

		public void OCBFBEMDMMJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool EKGEDEKHBME()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.PKHHKJLGHFM.alpha = 312f;
				PHDOCKCBJOF = new WaitForSeconds(KALLNCAFIMP);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				COOGKNIEOPA = 318f;
				goto case 2u;
			case 2u:
				if (COOGKNIEOPA < 795f)
				{
					COOGKNIEOPA = Mathf.Clamp01(COOGKNIEOPA + TimeManager.deltaTimeWithoutPauses / KBJEOEEOEFG);
					BJGCPDNMHDH.PKHHKJLGHFM.alpha = COOGKNIEOPA;
					BJGCPDNMHDH.GKFDJOICAHK.localPosition = BJGCPDNMHDH.GKFDJOICAHK.transform.localPosition.ReplaceY(BJGCPDNMHDH.FFOCLIDLFCF.Evaluate(COOGKNIEOPA));
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
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

		public void HCHFFFPDMDA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool NAOFKEEIFCG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.PKHHKJLGHFM.alpha = 1443f;
				PHDOCKCBJOF = new WaitForSeconds(KALLNCAFIMP);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				COOGKNIEOPA = 1556f;
				goto case 2u;
			case 2u:
				if (COOGKNIEOPA < 1515f)
				{
					COOGKNIEOPA = Mathf.Clamp01(COOGKNIEOPA + TimeManager.deltaTimeWithoutPauses / KBJEOEEOEFG);
					BJGCPDNMHDH.PKHHKJLGHFM.alpha = COOGKNIEOPA;
					BJGCPDNMHDH.GKFDJOICAHK.localPosition = BJGCPDNMHDH.GKFDJOICAHK.transform.localPosition.ReplaceY(BJGCPDNMHDH.FFOCLIDLFCF.Evaluate(COOGKNIEOPA));
					PHDOCKCBJOF = null;
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

		public void GHODNCIDCMG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool LHNFELIIMGD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.PKHHKJLGHFM.alpha = 1454f;
				PHDOCKCBJOF = new WaitForSeconds(KALLNCAFIMP);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				COOGKNIEOPA = 1861f;
				goto case 2u;
			case 2u:
				if (COOGKNIEOPA < 291f)
				{
					COOGKNIEOPA = Mathf.Clamp01(COOGKNIEOPA + TimeManager.deltaTimeWithoutPauses / KBJEOEEOEFG);
					BJGCPDNMHDH.PKHHKJLGHFM.alpha = COOGKNIEOPA;
					BJGCPDNMHDH.GKFDJOICAHK.localPosition = BJGCPDNMHDH.GKFDJOICAHK.transform.localPosition.ReplaceY(BJGCPDNMHDH.FFOCLIDLFCF.Evaluate(COOGKNIEOPA));
					PHDOCKCBJOF = null;
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

		public void AEFEAMAGBKK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object PPHNDLFFCAG()
		{
			return PHDOCKCBJOF;
		}

		public void OGDMPCFMMML()
		{
			throw new NotSupportedException();
		}

		public void NCOPKHMOMMK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void OPMABIIDKCN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object CEHGHGPGGPF()
		{
			return PHDOCKCBJOF;
		}

		public void IFBOOBLACGK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object DKPOLLDBPAP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AIDHNJCPDIJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LDBICDEEENB()
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
		private object GKJIGGAAHBE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GOAJCEAOPLA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IDBEGKHBNBC()
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
				BJGCPDNMHDH.PKHHKJLGHFM.alpha = 1624f;
				PHDOCKCBJOF = new WaitForSeconds(KALLNCAFIMP);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				COOGKNIEOPA = 315f;
				goto case 2u;
			case 2u:
				if (COOGKNIEOPA < 897f)
				{
					COOGKNIEOPA = Mathf.Clamp01(COOGKNIEOPA + TimeManager.deltaTimeWithoutPauses / KBJEOEEOEFG);
					BJGCPDNMHDH.PKHHKJLGHFM.alpha = COOGKNIEOPA;
					BJGCPDNMHDH.GKFDJOICAHK.localPosition = BJGCPDNMHDH.GKFDJOICAHK.transform.localPosition.ReplaceY(BJGCPDNMHDH.FFOCLIDLFCF.Evaluate(COOGKNIEOPA));
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
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

		public bool CGOKGPGALLH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.PKHHKJLGHFM.alpha = 1044f;
				PHDOCKCBJOF = new WaitForSeconds(KALLNCAFIMP);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				COOGKNIEOPA = 1824f;
				goto case 2u;
			case 2u:
				if (COOGKNIEOPA < 1675f)
				{
					COOGKNIEOPA = Mathf.Clamp01(COOGKNIEOPA + TimeManager.deltaTimeWithoutPauses / KBJEOEEOEFG);
					BJGCPDNMHDH.PKHHKJLGHFM.alpha = COOGKNIEOPA;
					BJGCPDNMHDH.GKFDJOICAHK.localPosition = BJGCPDNMHDH.GKFDJOICAHK.transform.localPosition.ReplaceY(BJGCPDNMHDH.FFOCLIDLFCF.Evaluate(COOGKNIEOPA));
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
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
		private object EFIEEKFCBJH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EOPJNKFKMNB()
		{
			return PHDOCKCBJOF;
		}

		public void OMDFNFHKFBK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object OAMLLHEMBIK()
		{
			return PHDOCKCBJOF;
		}

		public void NPKGNIGNPKG()
		{
			throw new NotSupportedException();
		}

		public void CDIJEGGMMAK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object PLHNILIJAPA()
		{
			return PHDOCKCBJOF;
		}

		public bool BGOEENAEBNO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.PKHHKJLGHFM.alpha = 1294f;
				PHDOCKCBJOF = new WaitForSeconds(KALLNCAFIMP);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				COOGKNIEOPA = 568f;
				goto case 2u;
			case 2u:
				if (COOGKNIEOPA < 123f)
				{
					COOGKNIEOPA = Mathf.Clamp01(COOGKNIEOPA + TimeManager.deltaTimeWithoutPauses / KBJEOEEOEFG);
					BJGCPDNMHDH.PKHHKJLGHFM.alpha = COOGKNIEOPA;
					BJGCPDNMHDH.GKFDJOICAHK.localPosition = BJGCPDNMHDH.GKFDJOICAHK.transform.localPosition.ReplaceY(BJGCPDNMHDH.FFOCLIDLFCF.Evaluate(COOGKNIEOPA));
					PHDOCKCBJOF = null;
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

		public void LEAAOAKKLAJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool FPOFCJOEAMO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.PKHHKJLGHFM.alpha = 346f;
				PHDOCKCBJOF = new WaitForSeconds(KALLNCAFIMP);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				COOGKNIEOPA = 1394f;
				goto case 2u;
			case 2u:
				if (COOGKNIEOPA < 1646f)
				{
					COOGKNIEOPA = Mathf.Clamp01(COOGKNIEOPA + TimeManager.deltaTimeWithoutPauses / KBJEOEEOEFG);
					BJGCPDNMHDH.PKHHKJLGHFM.alpha = COOGKNIEOPA;
					BJGCPDNMHDH.GKFDJOICAHK.localPosition = BJGCPDNMHDH.GKFDJOICAHK.transform.localPosition.ReplaceY(BJGCPDNMHDH.FFOCLIDLFCF.Evaluate(COOGKNIEOPA));
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
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
		private object PCELHKMHCOB()
		{
			return PHDOCKCBJOF;
		}

		public void OJDEHKDDLFD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void DNNJONPPIED()
		{
			throw new NotSupportedException();
		}

		public bool MOFPMNMAOND()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.PKHHKJLGHFM.alpha = 1589f;
				PHDOCKCBJOF = new WaitForSeconds(KALLNCAFIMP);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				COOGKNIEOPA = 1104f;
				goto case 2u;
			case 2u:
				if (COOGKNIEOPA < 1888f)
				{
					COOGKNIEOPA = Mathf.Clamp01(COOGKNIEOPA + TimeManager.deltaTimeWithoutPauses / KBJEOEEOEFG);
					BJGCPDNMHDH.PKHHKJLGHFM.alpha = COOGKNIEOPA;
					BJGCPDNMHDH.GKFDJOICAHK.localPosition = BJGCPDNMHDH.GKFDJOICAHK.transform.localPosition.ReplaceY(BJGCPDNMHDH.FFOCLIDLFCF.Evaluate(COOGKNIEOPA));
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
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

		public void LHADJAFHDDC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void OKIANDBCDIB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object IPCODJDAOBE()
		{
			return PHDOCKCBJOF;
		}

		public void BCOIPCDCKEJ()
		{
			throw new NotSupportedException();
		}

		public void NFAMBMLLFGP()
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
				BJGCPDNMHDH.PKHHKJLGHFM.alpha = 1404f;
				PHDOCKCBJOF = new WaitForSeconds(KALLNCAFIMP);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				COOGKNIEOPA = 1626f;
				goto case 2u;
			case 2u:
				if (COOGKNIEOPA < 459f)
				{
					COOGKNIEOPA = Mathf.Clamp01(COOGKNIEOPA + TimeManager.deltaTimeWithoutPauses / KBJEOEEOEFG);
					BJGCPDNMHDH.PKHHKJLGHFM.alpha = COOGKNIEOPA;
					BJGCPDNMHDH.GKFDJOICAHK.localPosition = BJGCPDNMHDH.GKFDJOICAHK.transform.localPosition.ReplaceY(BJGCPDNMHDH.FFOCLIDLFCF.Evaluate(COOGKNIEOPA));
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
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
		private object FPMOGMELJLI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GMEIAAMCBGA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BLNNEJILEIE()
		{
			return PHDOCKCBJOF;
		}

		public void LBNGPPPKLHI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void GFLFJHIPBNP()
		{
			throw new NotSupportedException();
		}

		public void BJHCLGCKJBB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void JOEOMEJLEID()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void LGCKODOHHIA()
		{
			throw new NotSupportedException();
		}

		public void BCKMHLBBBCK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MHKODCGLJFD()
		{
			return PHDOCKCBJOF;
		}

		public void OGBOHCPHGMK()
		{
			throw new NotSupportedException();
		}

		public void BOFEBMENOFC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void CGCPMAHOJJC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object INAMGPNDAAJ()
		{
			return PHDOCKCBJOF;
		}

		public void NGAGGCFIEGJ()
		{
			throw new NotSupportedException();
		}

		public void CPEEDIDEKLA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void MGJIOLLKHDK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IILJADPOOCO()
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
				BJGCPDNMHDH.PKHHKJLGHFM.alpha = 1499f;
				PHDOCKCBJOF = new WaitForSeconds(KALLNCAFIMP);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				COOGKNIEOPA = 546f;
				goto case 2u;
			case 2u:
				if (COOGKNIEOPA < 1148f)
				{
					COOGKNIEOPA = Mathf.Clamp01(COOGKNIEOPA + TimeManager.deltaTimeWithoutPauses / KBJEOEEOEFG);
					BJGCPDNMHDH.PKHHKJLGHFM.alpha = COOGKNIEOPA;
					BJGCPDNMHDH.GKFDJOICAHK.localPosition = BJGCPDNMHDH.GKFDJOICAHK.transform.localPosition.ReplaceY(BJGCPDNMHDH.FFOCLIDLFCF.Evaluate(COOGKNIEOPA));
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
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

		public bool KEBEGEDKIKM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.PKHHKJLGHFM.alpha = 856f;
				PHDOCKCBJOF = new WaitForSeconds(KALLNCAFIMP);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				COOGKNIEOPA = 1872f;
				goto case 2u;
			case 2u:
				if (COOGKNIEOPA < 872f)
				{
					COOGKNIEOPA = Mathf.Clamp01(COOGKNIEOPA + TimeManager.deltaTimeWithoutPauses / KBJEOEEOEFG);
					BJGCPDNMHDH.PKHHKJLGHFM.alpha = COOGKNIEOPA;
					BJGCPDNMHDH.GKFDJOICAHK.localPosition = BJGCPDNMHDH.GKFDJOICAHK.transform.localPosition.ReplaceY(BJGCPDNMHDH.FFOCLIDLFCF.Evaluate(COOGKNIEOPA));
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
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

		public void HMFGNEKJDKH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object FNCEOCMMGKH()
		{
			return PHDOCKCBJOF;
		}

		public void ENCGDFIIGNH()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BGLDNJLBIKM()
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
				BJGCPDNMHDH.PKHHKJLGHFM.alpha = 745f;
				PHDOCKCBJOF = new WaitForSeconds(KALLNCAFIMP);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				COOGKNIEOPA = 20f;
				goto case 2u;
			case 2u:
				if (COOGKNIEOPA < 1364f)
				{
					COOGKNIEOPA = Mathf.Clamp01(COOGKNIEOPA + TimeManager.deltaTimeWithoutPauses / KBJEOEEOEFG);
					BJGCPDNMHDH.PKHHKJLGHFM.alpha = COOGKNIEOPA;
					BJGCPDNMHDH.GKFDJOICAHK.localPosition = BJGCPDNMHDH.GKFDJOICAHK.transform.localPosition.ReplaceY(BJGCPDNMHDH.FFOCLIDLFCF.Evaluate(COOGKNIEOPA));
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
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

		public void IJHCIJLDKHK()
		{
			throw new NotSupportedException();
		}
	}

	[FormerlySerializedAs("PCBCDDDCPBJ")]
	public bool HOKOINDLJPO;

	[FormerlySerializedAs("GIMMLMFBMEI")]
	public UISprite KMFGCJEGJJK;

	[FormerlySerializedAs("FAOENJJNKEI")]
	public UISprite CGJIGBDGOOO;

	[FormerlySerializedAs("MLPOAAMKAFI")]
	public UISprite MNAJKODCACI;

	[FormerlySerializedAs("CMKGOKNCLOJ")]
	public UILabel PKHHKJLGHFM;

	[FormerlySerializedAs("MIEEAIMMBNA")]
	public Transform GKFDJOICAHK;

	[FormerlySerializedAs("BPGMNKPGFDP")]
	[Header("Health Change Animation")]
	public float NJJCPOKOMGK;

	[FormerlySerializedAs("KPGIHMPAFEC")]
	public float DGHFKLCHLPN;

	[FormerlySerializedAs("BKLGOIJGDOH")]
	public float PPMIJLPPNCP;

	[Header("Healthbar fade")]
	[FormerlySerializedAs("NIJGACFOKMP")]
	public float PPIPHNDIIGJ;

	[FormerlySerializedAs("EBKHDIFCFEG")]
	public float LHADFLKGHGB;

	[FormerlySerializedAs("IGBAMMEHBPH")]
	public float KIANPDGODJJ;

	[Header("Show Animation")]
	[FormerlySerializedAs("NAMAIAEBKEE")]
	public float HCCGAHHEBDG;

	[FormerlySerializedAs("OHKGELMDODP")]
	public float OJJHFNFKPAE;

	[FormerlySerializedAs("ADKHKNFICFO")]
	public float IEPNPCCENAK;

	[FormerlySerializedAs("AJGAMKCMDOC")]
	public float KFCAJKMKNCH;

	[FormerlySerializedAs("DOEIAIKNOJP")]
	public float IHKIEOOHBLN;

	[FormerlySerializedAs("NFGFDBHCJIJ")]
	public float NLLGKNMNIBG;

	[FormerlySerializedAs("HHIKCECBLGN")]
	public AnimationCurve FFOCLIDLFCF;

	[FormerlySerializedAs("CALDBABKAAI")]
	[Header("Near Death Animation")]
	public float AGGNPHKCLAB;

	[FormerlySerializedAs("NCJCHGCOKLD")]
	public AnimationCurve CMGEMNIIGND;

	[Header("Heartbeat")]
	[FormerlySerializedAs("PNFDNGKLHNM")]
	public AudioSource DOLNDLHICOO;

	private float JGNJJIKPICF;

	private float HOLDFDIMINM;

	private PlayerController MBIAKMPDOPG;

	private float ABKLOMBNDJB;

	private bool BNHAJBLDKOP;

	private Coroutine DKFLKBMKKKI;

	private void OEELFECKDNI(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		if (!(MBIAKMPDOPG != null))
		{
			return;
		}
		StopCoroutine(HJMFIKNMLBG());
		SoundsManager.Instance.onSoundVolumeChange -= GNPFGJHMLOA;
		if (BNHAJBLDKOP)
		{
			if (DOLNDLHICOO.isPlaying)
			{
				DOLNDLHICOO.Stop();
			}
			StopCoroutine(LAEBAANFFBL());
		}
		MBIAKMPDOPG = null;
		BNHAJBLDKOP = false;
		DKFLKBMKKKI = null;
	}

	public void FakeGameStartedAndShowUp()
	{
		JMMLEIGCPOK();
		StopAllCoroutines();
		NCAKLEOEDBO();
		KMFGCJEGJJK.gameObject.SetActive(value: true);
		MNAJKODCACI.gameObject.SetActive(value: true);
		PKHHKJLGHFM.gameObject.SetActive(value: true);
		StartCoroutine(EGLPPDKAENJ());
	}

	public void AOCEDKCANFP()
	{
		float num = 296f;
		float num2 = 970f;
		JGNJJIKPICF = UIHelper.activeWidthFull / 333f - num;
		HOLDFDIMINM = JGNJJIKPICF + num2;
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX(HOLDFDIMINM);
		CGJIGBDGOOO.transform.localScale = CGJIGBDGOOO.transform.localScale.ReplaceX(JGNJJIKPICF);
		MNAJKODCACI.transform.localScale = MNAJKODCACI.transform.localScale.ReplaceX(JGNJJIKPICF);
		bool flag = PKHHKJLGHFM.transform.localPosition.x > 262f;
		float val = PKHHKJLGHFM.transform.localPosition.x + UIHelper.safeAreaSize * ((!flag) ? 1610f : 890f);
		PKHHKJLGHFM.transform.localPosition = PKHHKJLGHFM.transform.localPosition.ReplaceX(val);
		Singleton<GameController>.instance.GameStarted += NDDAPCHJOEN;
		Singleton<GameController>.instance.GameEnded += OEELFECKDNI;
	}

	private void IOALPJMCJJG()
	{
		MBIAKMPDOPG = ((!HOKOINDLJPO) ? PlayerController.GetEnemyOf(PlayerController.OGMBJPKOPCB.fraction) : PlayerController.OGMBJPKOPCB);
		PKHHKJLGHFM.text = MBIAKMPDOPG.EHHHBEMKGOE.MHPNDNJDPGE;
	}

	private IEnumerator NNBGMFIILEO()
	{
		NLFKOCOKPEE nLFKOCOKPEE = new NLFKOCOKPEE();
		nLFKOCOKPEE.BJGCPDNMHDH = this;
		return nLFKOCOKPEE;
	}

	private void NDDAPCHJOEN()
	{
		if (MBIAKMPDOPG != null)
		{
			ABKLOMBNDJB = MBIAKMPDOPG.FOCIOKMPCAG.healthRatio;
			MNAJKODCACI.transform.localScale = MNAJKODCACI.transform.localScale.ReplaceX(ABKLOMBNDJB * JGNJJIKPICF);
			CGJIGBDGOOO.transform.localScale = CGJIGBDGOOO.transform.localScale.ReplaceX(ABKLOMBNDJB * JGNJJIKPICF);
			SoundsManager.Instance.onSoundVolumeChange += DMKBIGGJIAE;
			StartCoroutine(HJMFIKNMLBG());
		}
	}

	private IEnumerator CJJBFGMCAAO(UISprite ACGMFDMBCCA, float CEHFMMJHCKC, float KBJEOEEOEFG, float KALLNCAFIMP)
	{
		DEICAGGPEDD dEICAGGPEDD = new DEICAGGPEDD();
		dEICAGGPEDD.ACGMFDMBCCA = ACGMFDMBCCA;
		dEICAGGPEDD.KALLNCAFIMP = KALLNCAFIMP;
		dEICAGGPEDD.KBJEOEEOEFG = KBJEOEEOEFG;
		dEICAGGPEDD.CEHFMMJHCKC = CEHFMMJHCKC;
		return dEICAGGPEDD;
	}

	public void NMNMBNAMIEJ()
	{
		StopAllCoroutines();
		KMFGCJEGJJK.gameObject.SetActive(value: false);
		CGJIGBDGOOO.gameObject.SetActive(value: false);
		MNAJKODCACI.gameObject.SetActive(value: false);
		PKHHKJLGHFM.gameObject.SetActive(value: true);
	}

	public void KECDAIFJIMA()
	{
		float num = 169f;
		float num2 = 507f;
		JGNJJIKPICF = UIHelper.activeWidthFull / 1042f - num;
		HOLDFDIMINM = JGNJJIKPICF + num2;
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX(HOLDFDIMINM);
		CGJIGBDGOOO.transform.localScale = CGJIGBDGOOO.transform.localScale.ReplaceX(JGNJJIKPICF);
		MNAJKODCACI.transform.localScale = MNAJKODCACI.transform.localScale.ReplaceX(JGNJJIKPICF);
		bool flag = PKHHKJLGHFM.transform.localPosition.x > 63f;
		float val = PKHHKJLGHFM.transform.localPosition.x + UIHelper.safeAreaSize * ((!flag) ? 649f : 944f);
		PKHHKJLGHFM.transform.localPosition = PKHHKJLGHFM.transform.localPosition.ReplaceX(val);
		Singleton<GameController>.instance.GameStarted += LCCJNGABEPL;
		Singleton<GameController>.instance.CNPGMMPAGIE(DCBMIGKHHLH);
	}

	private IEnumerator BLKOJLODOFA()
	{
		FBFAAPEJNBB fBFAAPEJNBB = new FBFAAPEJNBB();
		fBFAAPEJNBB.BJGCPDNMHDH = this;
		return fBFAAPEJNBB;
	}

	private IEnumerator GEDKCLHJNII()
	{
		FBFAAPEJNBB fBFAAPEJNBB = new FBFAAPEJNBB();
		fBFAAPEJNBB.BJGCPDNMHDH = this;
		return fBFAAPEJNBB;
	}

	private IEnumerator NPLNFNOGPIA()
	{
		FJHBNEKNKFB fJHBNEKNKFB = new FJHBNEKNKFB();
		fJHBNEKNKFB.BJGCPDNMHDH = this;
		return fJHBNEKNKFB;
	}

	private void IHEOHAHAOEE()
	{
		MBIAKMPDOPG = ((!HOKOINDLJPO) ? PlayerController.GetEnemyOf(PlayerController.OGMBJPKOPCB.fraction) : PlayerController.OGMBJPKOPCB);
		PKHHKJLGHFM.text = MBIAKMPDOPG.EHHHBEMKGOE.MHPNDNJDPGE;
	}

	private void FMIOCIGFOPI(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		if (!(MBIAKMPDOPG != null))
		{
			return;
		}
		StopCoroutine(BAHBCHDHOLA());
		SoundsManager.Instance.onSoundVolumeChange -= GNIDFAMGDDG;
		if (BNHAJBLDKOP)
		{
			if (DOLNDLHICOO.isPlaying)
			{
				DOLNDLHICOO.Stop();
			}
			StopCoroutine(BLBNAFADILI());
		}
		MBIAKMPDOPG = null;
		BNHAJBLDKOP = true;
		DKFLKBMKKKI = null;
	}

	private IEnumerator MKAIMBGJCGI()
	{
		FJHBNEKNKFB fJHBNEKNKFB = new FJHBNEKNKFB();
		fJHBNEKNKFB.BJGCPDNMHDH = this;
		return fJHBNEKNKFB;
	}

	public void DIHPOCBCMAN()
	{
		IOALPJMCJJG();
		StopAllCoroutines();
		NCAKLEOEDBO();
		KMFGCJEGJJK.gameObject.SetActive(value: false);
		MNAJKODCACI.gameObject.SetActive(value: false);
		PKHHKJLGHFM.gameObject.SetActive(value: false);
		StartCoroutine(IGOEBLNEKLI());
	}

	private IEnumerator EJEBAKCKIKD()
	{
		FJHBNEKNKFB fJHBNEKNKFB = new FJHBNEKNKFB();
		fJHBNEKNKFB.BJGCPDNMHDH = this;
		return fJHBNEKNKFB;
	}

	private void GNPFGJHMLOA()
	{
		DOLNDLHICOO.volume = SoundsManager.Instance.soundsVolume;
	}

	private IEnumerator ICPKFKMPEAB()
	{
		FBFAAPEJNBB fBFAAPEJNBB = new FBFAAPEJNBB();
		fBFAAPEJNBB.BJGCPDNMHDH = this;
		return fBFAAPEJNBB;
	}

	public void AGJFMINNOBH()
	{
		StopAllCoroutines();
		KMFGCJEGJJK.gameObject.SetActive(value: true);
		CGJIGBDGOOO.gameObject.SetActive(value: false);
		MNAJKODCACI.gameObject.SetActive(value: true);
		PKHHKJLGHFM.gameObject.SetActive(value: true);
	}

	[DebuggerHidden]
	private IEnumerator FPLNNGCLGHD(UISprite ACGMFDMBCCA, float CEHFMMJHCKC, float KBJEOEEOEFG, float KALLNCAFIMP)
	{
		DEICAGGPEDD dEICAGGPEDD = new DEICAGGPEDD();
		dEICAGGPEDD.ACGMFDMBCCA = ACGMFDMBCCA;
		dEICAGGPEDD.KALLNCAFIMP = KALLNCAFIMP;
		dEICAGGPEDD.KBJEOEEOEFG = KBJEOEEOEFG;
		dEICAGGPEDD.CEHFMMJHCKC = CEHFMMJHCKC;
		return dEICAGGPEDD;
	}

	private void GNIDFAMGDDG()
	{
		DOLNDLHICOO.volume = SoundsManager.Instance.soundsVolume;
	}

	private IEnumerator BAHBCHDHOLA()
	{
		FJHBNEKNKFB fJHBNEKNKFB = new FJHBNEKNKFB();
		fJHBNEKNKFB.BJGCPDNMHDH = this;
		return fJHBNEKNKFB;
	}

	private IEnumerator EGEIELFHBCJ()
	{
		NLFKOCOKPEE nLFKOCOKPEE = new NLFKOCOKPEE();
		nLFKOCOKPEE.BJGCPDNMHDH = this;
		return nLFKOCOKPEE;
	}

	private IEnumerator ENDJPIKAADN()
	{
		NLFKOCOKPEE nLFKOCOKPEE = new NLFKOCOKPEE();
		nLFKOCOKPEE.BJGCPDNMHDH = this;
		return nLFKOCOKPEE;
	}

	private void KPPNCJBMDPE(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		if (!(MBIAKMPDOPG != null))
		{
			return;
		}
		StopCoroutine(MOIKMNCCDLL());
		SoundsManager.Instance.onSoundVolumeChange -= DHFAHMBOHIN;
		if (BNHAJBLDKOP)
		{
			if (DOLNDLHICOO.isPlaying)
			{
				DOLNDLHICOO.Stop();
			}
			StopCoroutine(LLFGGPEIMBM());
		}
		MBIAKMPDOPG = null;
		BNHAJBLDKOP = false;
		DKFLKBMKKKI = null;
	}

	public void LMOHAIBNMKF()
	{
		OOFDNHCNCGG();
		StopAllCoroutines();
		KMFGCJEGJJK.gameObject.SetActive(value: false);
		MNAJKODCACI.gameObject.SetActive(value: true);
		PKHHKJLGHFM.gameObject.SetActive(value: true);
		MNAJKODCACI.color = MNAJKODCACI.color.ReplaceA(KIANPDGODJJ);
		StartCoroutine(CEKDNNOOKAH());
	}

	private IEnumerator BBBHKJOOPCH(UISprite ACGMFDMBCCA, float CEHFMMJHCKC, float KBJEOEEOEFG, float KALLNCAFIMP)
	{
		DEICAGGPEDD dEICAGGPEDD = new DEICAGGPEDD();
		dEICAGGPEDD.ACGMFDMBCCA = ACGMFDMBCCA;
		dEICAGGPEDD.KALLNCAFIMP = KALLNCAFIMP;
		dEICAGGPEDD.KBJEOEEOEFG = KBJEOEEOEFG;
		dEICAGGPEDD.CEHFMMJHCKC = CEHFMMJHCKC;
		return dEICAGGPEDD;
	}

	public void DABJOLFJAOL()
	{
		HJIJDDNGNBF();
		StopAllCoroutines();
		KMFGCJEGJJK.gameObject.SetActive(value: false);
		MNAJKODCACI.gameObject.SetActive(value: false);
		PKHHKJLGHFM.gameObject.SetActive(value: false);
		MNAJKODCACI.color = MNAJKODCACI.color.ReplaceA(KIANPDGODJJ);
		StartCoroutine(HDPJMALPMND());
	}

	private IEnumerator NDACGPKJHID(UISprite ACGMFDMBCCA, float CEHFMMJHCKC, float KBJEOEEOEFG, float KALLNCAFIMP)
	{
		DEICAGGPEDD dEICAGGPEDD = new DEICAGGPEDD();
		dEICAGGPEDD.ACGMFDMBCCA = ACGMFDMBCCA;
		dEICAGGPEDD.KALLNCAFIMP = KALLNCAFIMP;
		dEICAGGPEDD.KBJEOEEOEFG = KBJEOEEOEFG;
		dEICAGGPEDD.CEHFMMJHCKC = CEHFMMJHCKC;
		return dEICAGGPEDD;
	}

	[DebuggerHidden]
	private IEnumerator EGLPPDKAENJ()
	{
		PLDLDNEHMHE pLDLDNEHMHE = new PLDLDNEHMHE();
		pLDLDNEHMHE.BJGCPDNMHDH = this;
		return pLDLDNEHMHE;
	}

	private IEnumerator DAPDKINDGGP(float KBJEOEEOEFG, float KALLNCAFIMP)
	{
		FNPAALMBOIF fNPAALMBOIF = new FNPAALMBOIF();
		fNPAALMBOIF.KALLNCAFIMP = KALLNCAFIMP;
		fNPAALMBOIF.KBJEOEEOEFG = KBJEOEEOEFG;
		fNPAALMBOIF.BJGCPDNMHDH = this;
		return fNPAALMBOIF;
	}

	private void JPBIPDFKDFH()
	{
		MBIAKMPDOPG = ((!HOKOINDLJPO) ? PlayerController.GetEnemyOf(PlayerController.OGMBJPKOPCB.fraction) : PlayerController.OGMBJPKOPCB);
		PKHHKJLGHFM.text = MBIAKMPDOPG.EHHHBEMKGOE.MHPNDNJDPGE;
	}

	private void DHFAHMBOHIN()
	{
		DOLNDLHICOO.volume = SoundsManager.Instance.soundsVolume;
	}

	[DebuggerHidden]
	private IEnumerator HKAFLLAFBIM()
	{
		FBFAAPEJNBB fBFAAPEJNBB = new FBFAAPEJNBB();
		fBFAAPEJNBB.BJGCPDNMHDH = this;
		return fBFAAPEJNBB;
	}

	private void DCBMIGKHHLH(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		if (!(MBIAKMPDOPG != null))
		{
			return;
		}
		StopCoroutine(EJEBAKCKIKD());
		SoundsManager.Instance.onSoundVolumeChange -= KAKNCIKGMMF;
		if (BNHAJBLDKOP)
		{
			if (DOLNDLHICOO.isPlaying)
			{
				DOLNDLHICOO.Stop();
			}
			StopCoroutine(LLFGGPEIMBM());
		}
		MBIAKMPDOPG = null;
		BNHAJBLDKOP = false;
		DKFLKBMKKKI = null;
	}

	private void MALLKAPADJP()
	{
		MBIAKMPDOPG = ((!HOKOINDLJPO) ? PlayerController.GetEnemyOf(PlayerController.OGMBJPKOPCB.fraction) : PlayerController.OGMBJPKOPCB);
		PKHHKJLGHFM.text = MBIAKMPDOPG.EHHHBEMKGOE.MHPNDNJDPGE;
	}

	private IEnumerator HIBJBCINOJF()
	{
		FBFAAPEJNBB fBFAAPEJNBB = new FBFAAPEJNBB();
		fBFAAPEJNBB.BJGCPDNMHDH = this;
		return fBFAAPEJNBB;
	}

	private void DMKBIGGJIAE()
	{
		DOLNDLHICOO.volume = SoundsManager.Instance.soundsVolume;
	}

	private IEnumerator EFKJDEDOHGL(UISprite ACGMFDMBCCA, float CEHFMMJHCKC, float KBJEOEEOEFG, float KALLNCAFIMP)
	{
		DEICAGGPEDD dEICAGGPEDD = new DEICAGGPEDD();
		dEICAGGPEDD.ACGMFDMBCCA = ACGMFDMBCCA;
		dEICAGGPEDD.KALLNCAFIMP = KALLNCAFIMP;
		dEICAGGPEDD.KBJEOEEOEFG = KBJEOEEOEFG;
		dEICAGGPEDD.CEHFMMJHCKC = CEHFMMJHCKC;
		return dEICAGGPEDD;
	}

	private void EJCBIINNEOM(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		if (!(MBIAKMPDOPG != null))
		{
			return;
		}
		StopCoroutine(EOKMJLCJAPE());
		SoundsManager.Instance.onSoundVolumeChange -= KAKNCIKGMMF;
		if (BNHAJBLDKOP)
		{
			if (DOLNDLHICOO.isPlaying)
			{
				DOLNDLHICOO.Stop();
			}
			StopCoroutine(OPOAIMFMFPN());
		}
		MBIAKMPDOPG = null;
		BNHAJBLDKOP = true;
		DKFLKBMKKKI = null;
	}

	public void DEAJHLMFFHL()
	{
		StopAllCoroutines();
		KMFGCJEGJJK.gameObject.SetActive(value: false);
		CGJIGBDGOOO.gameObject.SetActive(value: false);
		MNAJKODCACI.gameObject.SetActive(value: true);
		PKHHKJLGHFM.gameObject.SetActive(value: false);
	}

	private void NCAKLEOEDBO()
	{
		if (MBIAKMPDOPG != null)
		{
			ABKLOMBNDJB = MBIAKMPDOPG.FOCIOKMPCAG.healthRatio;
			MNAJKODCACI.transform.localScale = MNAJKODCACI.transform.localScale.ReplaceX(ABKLOMBNDJB * JGNJJIKPICF);
			CGJIGBDGOOO.transform.localScale = CGJIGBDGOOO.transform.localScale.ReplaceX(ABKLOMBNDJB * JGNJJIKPICF);
			SoundsManager.Instance.onSoundVolumeChange += DHFAHMBOHIN;
			StartCoroutine(MOIKMNCCDLL());
		}
	}

	public void GKJAIEGOAJI()
	{
		MALLKAPADJP();
		StopAllCoroutines();
		KMFGCJEGJJK.gameObject.SetActive(value: false);
		MNAJKODCACI.gameObject.SetActive(value: true);
		PKHHKJLGHFM.gameObject.SetActive(value: true);
		MNAJKODCACI.color = MNAJKODCACI.color.ReplaceA(KIANPDGODJJ);
		StartCoroutine(HDPJMALPMND());
	}

	public void HPJMIMAGAFA()
	{
		MNGFPJBAOFB();
		StopAllCoroutines();
		KMFGCJEGJJK.gameObject.SetActive(value: true);
		MNAJKODCACI.gameObject.SetActive(value: false);
		PKHHKJLGHFM.gameObject.SetActive(value: false);
		MNAJKODCACI.color = MNAJKODCACI.color.ReplaceA(KIANPDGODJJ);
		StartCoroutine(EGLPPDKAENJ());
	}

	private IEnumerator BLCDLKIOIIL(float KBJEOEEOEFG, float KALLNCAFIMP)
	{
		FNPAALMBOIF fNPAALMBOIF = new FNPAALMBOIF();
		fNPAALMBOIF.KALLNCAFIMP = KALLNCAFIMP;
		fNPAALMBOIF.KBJEOEEOEFG = KBJEOEEOEFG;
		fNPAALMBOIF.BJGCPDNMHDH = this;
		return fNPAALMBOIF;
	}

	private IEnumerator DFMEPDMHOPP()
	{
		NLFKOCOKPEE nLFKOCOKPEE = new NLFKOCOKPEE();
		nLFKOCOKPEE.BJGCPDNMHDH = this;
		return nLFKOCOKPEE;
	}

	public void FAJENMGBMIL()
	{
		JPBIPDFKDFH();
		StopAllCoroutines();
		KMFGCJEGJJK.gameObject.SetActive(value: true);
		MNAJKODCACI.gameObject.SetActive(value: false);
		PKHHKJLGHFM.gameObject.SetActive(value: false);
		MNAJKODCACI.color = MNAJKODCACI.color.ReplaceA(KIANPDGODJJ);
		StartCoroutine(HDPJMALPMND());
	}

	public void CBJLJBEGABD()
	{
		float num = 1129f;
		float num2 = 1779f;
		JGNJJIKPICF = UIHelper.activeWidthFull / 1925f - num;
		HOLDFDIMINM = JGNJJIKPICF + num2;
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX(HOLDFDIMINM);
		CGJIGBDGOOO.transform.localScale = CGJIGBDGOOO.transform.localScale.ReplaceX(JGNJJIKPICF);
		MNAJKODCACI.transform.localScale = MNAJKODCACI.transform.localScale.ReplaceX(JGNJJIKPICF);
		bool flag = PKHHKJLGHFM.transform.localPosition.x > 1828f;
		float val = PKHHKJLGHFM.transform.localPosition.x + UIHelper.safeAreaSize * ((!flag) ? 1271f : 1584f);
		PKHHKJLGHFM.transform.localPosition = PKHHKJLGHFM.transform.localPosition.ReplaceX(val);
		Singleton<GameController>.instance.GameStarted += NDDAPCHJOEN;
		Singleton<GameController>.instance.GameEnded += EJCBIINNEOM;
	}

	private IEnumerator POPNBAKGPGN()
	{
		OAMJNPNCIBK oAMJNPNCIBK = new OAMJNPNCIBK();
		oAMJNPNCIBK.BJGCPDNMHDH = this;
		return oAMJNPNCIBK;
	}

	public void FCDNPIFECEE()
	{
		IHEOHAHAOEE();
		StopAllCoroutines();
		KMFGCJEGJJK.gameObject.SetActive(value: false);
		MNAJKODCACI.gameObject.SetActive(value: false);
		PKHHKJLGHFM.gameObject.SetActive(value: true);
		MNAJKODCACI.color = MNAJKODCACI.color.ReplaceA(KIANPDGODJJ);
		StartCoroutine(IGOEBLNEKLI());
	}

	private IEnumerator FBDKMEKOFAB()
	{
		FBFAAPEJNBB fBFAAPEJNBB = new FBFAAPEJNBB();
		fBFAAPEJNBB.BJGCPDNMHDH = this;
		return fBFAAPEJNBB;
	}

	public void JDJEJIALHLP()
	{
		IHEOHAHAOEE();
		StopAllCoroutines();
		LCCJNGABEPL();
		KMFGCJEGJJK.gameObject.SetActive(value: false);
		MNAJKODCACI.gameObject.SetActive(value: false);
		PKHHKJLGHFM.gameObject.SetActive(value: false);
		StartCoroutine(IGOEBLNEKLI());
	}

	public void Hide()
	{
		StopAllCoroutines();
		KMFGCJEGJJK.gameObject.SetActive(value: false);
		CGJIGBDGOOO.gameObject.SetActive(value: false);
		MNAJKODCACI.gameObject.SetActive(value: false);
		PKHHKJLGHFM.gameObject.SetActive(value: false);
	}

	private IEnumerator HPMPKMCOIFK(float KBJEOEEOEFG, float KALLNCAFIMP)
	{
		FNPAALMBOIF fNPAALMBOIF = new FNPAALMBOIF();
		fNPAALMBOIF.KALLNCAFIMP = KALLNCAFIMP;
		fNPAALMBOIF.KBJEOEEOEFG = KBJEOEEOEFG;
		fNPAALMBOIF.BJGCPDNMHDH = this;
		return fNPAALMBOIF;
	}

	private void JMMLEIGCPOK()
	{
		MBIAKMPDOPG = ((!HOKOINDLJPO) ? PlayerController.GetEnemyOf(PlayerController.OGMBJPKOPCB.fraction) : PlayerController.OGMBJPKOPCB);
		PKHHKJLGHFM.text = MBIAKMPDOPG.EHHHBEMKGOE.MHPNDNJDPGE;
	}

	public void DJFMADMABIB()
	{
		StopAllCoroutines();
		KMFGCJEGJJK.gameObject.SetActive(value: false);
		CGJIGBDGOOO.gameObject.SetActive(value: true);
		MNAJKODCACI.gameObject.SetActive(value: false);
		PKHHKJLGHFM.gameObject.SetActive(value: true);
	}

	public void KKBGJBNLFGG()
	{
		MALLKAPADJP();
		StopAllCoroutines();
		LCCJNGABEPL();
		KMFGCJEGJJK.gameObject.SetActive(value: false);
		MNAJKODCACI.gameObject.SetActive(value: true);
		PKHHKJLGHFM.gameObject.SetActive(value: true);
		StartCoroutine(DLHDOCFPJIB());
	}

	public void KOMCIOCNKKD()
	{
		StopAllCoroutines();
		KMFGCJEGJJK.gameObject.SetActive(value: false);
		CGJIGBDGOOO.gameObject.SetActive(value: true);
		MNAJKODCACI.gameObject.SetActive(value: true);
		PKHHKJLGHFM.gameObject.SetActive(value: false);
	}

	private IEnumerator OPOAIMFMFPN()
	{
		OAMJNPNCIBK oAMJNPNCIBK = new OAMJNPNCIBK();
		oAMJNPNCIBK.BJGCPDNMHDH = this;
		return oAMJNPNCIBK;
	}

	public void GAAINOJAHAE()
	{
		OOFDNHCNCGG();
		StopAllCoroutines();
		KMFGCJEGJJK.gameObject.SetActive(value: true);
		MNAJKODCACI.gameObject.SetActive(value: false);
		PKHHKJLGHFM.gameObject.SetActive(value: true);
		MNAJKODCACI.color = MNAJKODCACI.color.ReplaceA(KIANPDGODJJ);
		StartCoroutine(PBCMMIDDAEE());
	}

	private IEnumerator DJDAFOPOBAD()
	{
		PLDLDNEHMHE pLDLDNEHMHE = new PLDLDNEHMHE();
		pLDLDNEHMHE.BJGCPDNMHDH = this;
		return pLDLDNEHMHE;
	}

	private void DMHKCCPPODF()
	{
		MBIAKMPDOPG = ((!HOKOINDLJPO) ? PlayerController.GetEnemyOf(PlayerController.OGMBJPKOPCB.fraction) : PlayerController.OGMBJPKOPCB);
		PKHHKJLGHFM.text = MBIAKMPDOPG.EHHHBEMKGOE.MHPNDNJDPGE;
	}

	public void PPBPGONACPK()
	{
		DMHKCCPPODF();
		StopAllCoroutines();
		KMFGCJEGJJK.gameObject.SetActive(value: true);
		MNAJKODCACI.gameObject.SetActive(value: true);
		PKHHKJLGHFM.gameObject.SetActive(value: true);
		MNAJKODCACI.color = MNAJKODCACI.color.ReplaceA(KIANPDGODJJ);
		StartCoroutine(CEKDNNOOKAH());
	}

	private IEnumerator BCFJKJBOCMB()
	{
		NLFKOCOKPEE nLFKOCOKPEE = new NLFKOCOKPEE();
		nLFKOCOKPEE.BJGCPDNMHDH = this;
		return nLFKOCOKPEE;
	}

	public void GDBNHEEBOGD()
	{
		JPBIPDFKDFH();
		StopAllCoroutines();
		LCCJNGABEPL();
		KMFGCJEGJJK.gameObject.SetActive(value: false);
		MNAJKODCACI.gameObject.SetActive(value: false);
		PKHHKJLGHFM.gameObject.SetActive(value: false);
		StartCoroutine(CEKDNNOOKAH());
	}

	private IEnumerator BIFDLBBLHCH(float KBJEOEEOEFG, float KALLNCAFIMP)
	{
		FNPAALMBOIF fNPAALMBOIF = new FNPAALMBOIF();
		fNPAALMBOIF.KALLNCAFIMP = KALLNCAFIMP;
		fNPAALMBOIF.KBJEOEEOEFG = KBJEOEEOEFG;
		fNPAALMBOIF.BJGCPDNMHDH = this;
		return fNPAALMBOIF;
	}

	private IEnumerator BGLLKGMNGMG()
	{
		OAMJNPNCIBK oAMJNPNCIBK = new OAMJNPNCIBK();
		oAMJNPNCIBK.BJGCPDNMHDH = this;
		return oAMJNPNCIBK;
	}

	private void CEFDOMLDLIM()
	{
		DOLNDLHICOO.volume = SoundsManager.Instance.soundsVolume;
	}

	private IEnumerator CHJDBCFBMHL()
	{
		FJHBNEKNKFB fJHBNEKNKFB = new FJHBNEKNKFB();
		fJHBNEKNKFB.BJGCPDNMHDH = this;
		return fJHBNEKNKFB;
	}

	private IEnumerator IGDLKNNOGLO(UISprite ACGMFDMBCCA, float CEHFMMJHCKC, float KBJEOEEOEFG, float KALLNCAFIMP)
	{
		DEICAGGPEDD dEICAGGPEDD = new DEICAGGPEDD();
		dEICAGGPEDD.ACGMFDMBCCA = ACGMFDMBCCA;
		dEICAGGPEDD.KALLNCAFIMP = KALLNCAFIMP;
		dEICAGGPEDD.KBJEOEEOEFG = KBJEOEEOEFG;
		dEICAGGPEDD.CEHFMMJHCKC = CEHFMMJHCKC;
		return dEICAGGPEDD;
	}

	[DebuggerHidden]
	private IEnumerator LLFGGPEIMBM()
	{
		OAMJNPNCIBK oAMJNPNCIBK = new OAMJNPNCIBK();
		oAMJNPNCIBK.BJGCPDNMHDH = this;
		return oAMJNPNCIBK;
	}

	public void PLMNKPMGGOL()
	{
		IOALPJMCJJG();
		StopAllCoroutines();
		NCAKLEOEDBO();
		KMFGCJEGJJK.gameObject.SetActive(value: true);
		MNAJKODCACI.gameObject.SetActive(value: true);
		PKHHKJLGHFM.gameObject.SetActive(value: true);
		StartCoroutine(PBCMMIDDAEE());
	}

	private void LCCJNGABEPL()
	{
		if (MBIAKMPDOPG != null)
		{
			ABKLOMBNDJB = MBIAKMPDOPG.FOCIOKMPCAG.healthRatio;
			MNAJKODCACI.transform.localScale = MNAJKODCACI.transform.localScale.ReplaceX(ABKLOMBNDJB * JGNJJIKPICF);
			CGJIGBDGOOO.transform.localScale = CGJIGBDGOOO.transform.localScale.ReplaceX(ABKLOMBNDJB * JGNJJIKPICF);
			SoundsManager.Instance.onSoundVolumeChange += GNIDFAMGDDG;
			StartCoroutine(CHJDBCFBMHL());
		}
	}

	[DebuggerHidden]
	private IEnumerator PFCLJIEGLEA(float KBJEOEEOEFG, float KALLNCAFIMP)
	{
		FNPAALMBOIF fNPAALMBOIF = new FNPAALMBOIF();
		fNPAALMBOIF.KALLNCAFIMP = KALLNCAFIMP;
		fNPAALMBOIF.KBJEOEEOEFG = KBJEOEEOEFG;
		fNPAALMBOIF.BJGCPDNMHDH = this;
		return fNPAALMBOIF;
	}

	public void HKFIIFPGODD()
	{
		IOALPJMCJJG();
		StopAllCoroutines();
		KMFGCJEGJJK.gameObject.SetActive(value: true);
		MNAJKODCACI.gameObject.SetActive(value: false);
		PKHHKJLGHFM.gameObject.SetActive(value: false);
		MNAJKODCACI.color = MNAJKODCACI.color.ReplaceA(KIANPDGODJJ);
		StartCoroutine(DJDAFOPOBAD());
	}

	private IEnumerator IKEECEOGHND(UISprite ACGMFDMBCCA, float CEHFMMJHCKC, float KBJEOEEOEFG, float KALLNCAFIMP)
	{
		DEICAGGPEDD dEICAGGPEDD = new DEICAGGPEDD();
		dEICAGGPEDD.ACGMFDMBCCA = ACGMFDMBCCA;
		dEICAGGPEDD.KALLNCAFIMP = KALLNCAFIMP;
		dEICAGGPEDD.KBJEOEEOEFG = KBJEOEEOEFG;
		dEICAGGPEDD.CEHFMMJHCKC = CEHFMMJHCKC;
		return dEICAGGPEDD;
	}

	private IEnumerator LFFJKBOFPLB(float KBJEOEEOEFG, float KALLNCAFIMP)
	{
		FNPAALMBOIF fNPAALMBOIF = new FNPAALMBOIF();
		fNPAALMBOIF.KALLNCAFIMP = KALLNCAFIMP;
		fNPAALMBOIF.KBJEOEEOEFG = KBJEOEEOEFG;
		fNPAALMBOIF.BJGCPDNMHDH = this;
		return fNPAALMBOIF;
	}

	private IEnumerator JHHJEHLHICJ()
	{
		NLFKOCOKPEE nLFKOCOKPEE = new NLFKOCOKPEE();
		nLFKOCOKPEE.BJGCPDNMHDH = this;
		return nLFKOCOKPEE;
	}

	private void OOFDNHCNCGG()
	{
		MBIAKMPDOPG = ((!HOKOINDLJPO) ? PlayerController.GetEnemyOf(PlayerController.OGMBJPKOPCB.fraction) : PlayerController.OGMBJPKOPCB);
		PKHHKJLGHFM.text = MBIAKMPDOPG.EHHHBEMKGOE.MHPNDNJDPGE;
	}

	private IEnumerator DJMOPJGJEFJ()
	{
		FBFAAPEJNBB fBFAAPEJNBB = new FBFAAPEJNBB();
		fBFAAPEJNBB.BJGCPDNMHDH = this;
		return fBFAAPEJNBB;
	}

	private void LLNKOMKBFKF()
	{
		MBIAKMPDOPG = ((!HOKOINDLJPO) ? PlayerController.GetEnemyOf(PlayerController.OGMBJPKOPCB.fraction) : PlayerController.OGMBJPKOPCB);
		PKHHKJLGHFM.text = MBIAKMPDOPG.EHHHBEMKGOE.MHPNDNJDPGE;
	}

	private IEnumerator CEKDNNOOKAH()
	{
		PLDLDNEHMHE pLDLDNEHMHE = new PLDLDNEHMHE();
		pLDLDNEHMHE.BJGCPDNMHDH = this;
		return pLDLDNEHMHE;
	}

	public void HFFHPHBNHPI()
	{
		float num = 1123f;
		float num2 = 1128f;
		JGNJJIKPICF = UIHelper.activeWidthFull / 902f - num;
		HOLDFDIMINM = JGNJJIKPICF + num2;
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX(HOLDFDIMINM);
		CGJIGBDGOOO.transform.localScale = CGJIGBDGOOO.transform.localScale.ReplaceX(JGNJJIKPICF);
		MNAJKODCACI.transform.localScale = MNAJKODCACI.transform.localScale.ReplaceX(JGNJJIKPICF);
		bool flag = PKHHKJLGHFM.transform.localPosition.x > 689f;
		float val = PKHHKJLGHFM.transform.localPosition.x + UIHelper.safeAreaSize * ((!flag) ? 1976f : 1343f);
		PKHHKJLGHFM.transform.localPosition = PKHHKJLGHFM.transform.localPosition.ReplaceX(val);
		Singleton<GameController>.instance.GameStarted += NDDAPCHJOEN;
		Singleton<GameController>.instance.CNPGMMPAGIE(EJCBIINNEOM);
	}

	[DebuggerHidden]
	private IEnumerator MKMEFOHDBCE()
	{
		NLFKOCOKPEE nLFKOCOKPEE = new NLFKOCOKPEE();
		nLFKOCOKPEE.BJGCPDNMHDH = this;
		return nLFKOCOKPEE;
	}

	private IEnumerator HDPJMALPMND()
	{
		PLDLDNEHMHE pLDLDNEHMHE = new PLDLDNEHMHE();
		pLDLDNEHMHE.BJGCPDNMHDH = this;
		return pLDLDNEHMHE;
	}

	public void ShowUp()
	{
		JMMLEIGCPOK();
		StopAllCoroutines();
		KMFGCJEGJJK.gameObject.SetActive(value: true);
		MNAJKODCACI.gameObject.SetActive(value: true);
		PKHHKJLGHFM.gameObject.SetActive(value: true);
		MNAJKODCACI.color = MNAJKODCACI.color.ReplaceA(KIANPDGODJJ);
		StartCoroutine(EGLPPDKAENJ());
	}

	public void JEPAHKJFDIE()
	{
		IHEOHAHAOEE();
		StopAllCoroutines();
		LCCJNGABEPL();
		KMFGCJEGJJK.gameObject.SetActive(value: true);
		MNAJKODCACI.gameObject.SetActive(value: false);
		PKHHKJLGHFM.gameObject.SetActive(value: true);
		StartCoroutine(CEKDNNOOKAH());
	}

	public void OEDHHHAEOGI()
	{
		LLNKOMKBFKF();
		StopAllCoroutines();
		KMFGCJEGJJK.gameObject.SetActive(value: true);
		MNAJKODCACI.gameObject.SetActive(value: false);
		PKHHKJLGHFM.gameObject.SetActive(value: false);
		MNAJKODCACI.color = MNAJKODCACI.color.ReplaceA(KIANPDGODJJ);
		StartCoroutine(HDPJMALPMND());
	}

	private void JAMHJHBIHMA(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		if (!(MBIAKMPDOPG != null))
		{
			return;
		}
		StopCoroutine(OPKICBBCGKH());
		SoundsManager.Instance.onSoundVolumeChange -= JMDKEFHPLOC;
		if (BNHAJBLDKOP)
		{
			if (DOLNDLHICOO.isPlaying)
			{
				DOLNDLHICOO.Stop();
			}
			StopCoroutine(LAEBAANFFBL());
		}
		MBIAKMPDOPG = null;
		BNHAJBLDKOP = true;
		DKFLKBMKKKI = null;
	}

	private void MNBBIPMMNMG()
	{
		DOLNDLHICOO.volume = SoundsManager.Instance.soundsVolume;
	}

	private void JMDKEFHPLOC()
	{
		DOLNDLHICOO.volume = SoundsManager.Instance.soundsVolume;
	}

	private void HGJMKHINDBG()
	{
		DOLNDLHICOO.volume = SoundsManager.Instance.soundsVolume;
	}

	public void GLJCCKLCJLH()
	{
		StopAllCoroutines();
		KMFGCJEGJJK.gameObject.SetActive(value: false);
		CGJIGBDGOOO.gameObject.SetActive(value: true);
		MNAJKODCACI.gameObject.SetActive(value: true);
		PKHHKJLGHFM.gameObject.SetActive(value: true);
	}

	public void FCFNNGBLGBF()
	{
		StopAllCoroutines();
		KMFGCJEGJJK.gameObject.SetActive(value: true);
		CGJIGBDGOOO.gameObject.SetActive(value: true);
		MNAJKODCACI.gameObject.SetActive(value: true);
		PKHHKJLGHFM.gameObject.SetActive(value: true);
	}

	private IEnumerator DLHDOCFPJIB()
	{
		PLDLDNEHMHE pLDLDNEHMHE = new PLDLDNEHMHE();
		pLDLDNEHMHE.BJGCPDNMHDH = this;
		return pLDLDNEHMHE;
	}

	private IEnumerator MNNGCEDCBPB()
	{
		FBFAAPEJNBB fBFAAPEJNBB = new FBFAAPEJNBB();
		fBFAAPEJNBB.BJGCPDNMHDH = this;
		return fBFAAPEJNBB;
	}

	private IEnumerator LAEBAANFFBL()
	{
		OAMJNPNCIBK oAMJNPNCIBK = new OAMJNPNCIBK();
		oAMJNPNCIBK.BJGCPDNMHDH = this;
		return oAMJNPNCIBK;
	}

	[DebuggerHidden]
	private IEnumerator MOIKMNCCDLL()
	{
		FJHBNEKNKFB fJHBNEKNKFB = new FJHBNEKNKFB();
		fJHBNEKNKFB.BJGCPDNMHDH = this;
		return fJHBNEKNKFB;
	}

	private IEnumerator EOKMJLCJAPE()
	{
		FJHBNEKNKFB fJHBNEKNKFB = new FJHBNEKNKFB();
		fJHBNEKNKFB.BJGCPDNMHDH = this;
		return fJHBNEKNKFB;
	}

	private IEnumerator IBIMHCNCOEB()
	{
		NLFKOCOKPEE nLFKOCOKPEE = new NLFKOCOKPEE();
		nLFKOCOKPEE.BJGCPDNMHDH = this;
		return nLFKOCOKPEE;
	}

	private void MNGFPJBAOFB()
	{
		MBIAKMPDOPG = ((!HOKOINDLJPO) ? PlayerController.GetEnemyOf(PlayerController.OGMBJPKOPCB.fraction) : PlayerController.OGMBJPKOPCB);
		PKHHKJLGHFM.text = MBIAKMPDOPG.EHHHBEMKGOE.MHPNDNJDPGE;
	}

	private IEnumerator HJKKLGFNDCF()
	{
		OAMJNPNCIBK oAMJNPNCIBK = new OAMJNPNCIBK();
		oAMJNPNCIBK.BJGCPDNMHDH = this;
		return oAMJNPNCIBK;
	}

	private IEnumerator GFOANDLNIKB(float KBJEOEEOEFG, float KALLNCAFIMP)
	{
		FNPAALMBOIF fNPAALMBOIF = new FNPAALMBOIF();
		fNPAALMBOIF.KALLNCAFIMP = KALLNCAFIMP;
		fNPAALMBOIF.KBJEOEEOEFG = KBJEOEEOEFG;
		fNPAALMBOIF.BJGCPDNMHDH = this;
		return fNPAALMBOIF;
	}

	private IEnumerator APCKNOHMGDM(float KBJEOEEOEFG, float KALLNCAFIMP)
	{
		FNPAALMBOIF fNPAALMBOIF = new FNPAALMBOIF();
		fNPAALMBOIF.KALLNCAFIMP = KALLNCAFIMP;
		fNPAALMBOIF.KBJEOEEOEFG = KBJEOEEOEFG;
		fNPAALMBOIF.BJGCPDNMHDH = this;
		return fNPAALMBOIF;
	}

	private void HJIJDDNGNBF()
	{
		MBIAKMPDOPG = ((!HOKOINDLJPO) ? PlayerController.GetEnemyOf(PlayerController.OGMBJPKOPCB.fraction) : PlayerController.OGMBJPKOPCB);
		PKHHKJLGHFM.text = MBIAKMPDOPG.EHHHBEMKGOE.MHPNDNJDPGE;
	}

	private void KAKNCIKGMMF()
	{
		DOLNDLHICOO.volume = SoundsManager.Instance.soundsVolume;
	}

	private IEnumerator OPKICBBCGKH()
	{
		FJHBNEKNKFB fJHBNEKNKFB = new FJHBNEKNKFB();
		fJHBNEKNKFB.BJGCPDNMHDH = this;
		return fJHBNEKNKFB;
	}

	private IEnumerator LLIHLNDCJDO()
	{
		FBFAAPEJNBB fBFAAPEJNBB = new FBFAAPEJNBB();
		fBFAAPEJNBB.BJGCPDNMHDH = this;
		return fBFAAPEJNBB;
	}

	private IEnumerator GDIBBEOJPMA()
	{
		FBFAAPEJNBB fBFAAPEJNBB = new FBFAAPEJNBB();
		fBFAAPEJNBB.BJGCPDNMHDH = this;
		return fBFAAPEJNBB;
	}

	private IEnumerator HJMFIKNMLBG()
	{
		FJHBNEKNKFB fJHBNEKNKFB = new FJHBNEKNKFB();
		fJHBNEKNKFB.BJGCPDNMHDH = this;
		return fJHBNEKNKFB;
	}

	private IEnumerator BLBNAFADILI()
	{
		OAMJNPNCIBK oAMJNPNCIBK = new OAMJNPNCIBK();
		oAMJNPNCIBK.BJGCPDNMHDH = this;
		return oAMJNPNCIBK;
	}

	private IEnumerator IGOEBLNEKLI()
	{
		PLDLDNEHMHE pLDLDNEHMHE = new PLDLDNEHMHE();
		pLDLDNEHMHE.BJGCPDNMHDH = this;
		return pLDLDNEHMHE;
	}

	private IEnumerator LIPIGKGLOKP()
	{
		FBFAAPEJNBB fBFAAPEJNBB = new FBFAAPEJNBB();
		fBFAAPEJNBB.BJGCPDNMHDH = this;
		return fBFAAPEJNBB;
	}

	public void NLICFJGDLLE()
	{
		MNGFPJBAOFB();
		StopAllCoroutines();
		KMFGCJEGJJK.gameObject.SetActive(value: false);
		MNAJKODCACI.gameObject.SetActive(value: false);
		PKHHKJLGHFM.gameObject.SetActive(value: true);
		MNAJKODCACI.color = MNAJKODCACI.color.ReplaceA(KIANPDGODJJ);
		StartCoroutine(HDPJMALPMND());
	}

	public void Init()
	{
		float num = 156f;
		float num2 = 16f;
		JGNJJIKPICF = UIHelper.activeWidthFull / 2f - num;
		HOLDFDIMINM = JGNJJIKPICF + num2;
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX(HOLDFDIMINM);
		CGJIGBDGOOO.transform.localScale = CGJIGBDGOOO.transform.localScale.ReplaceX(JGNJJIKPICF);
		MNAJKODCACI.transform.localScale = MNAJKODCACI.transform.localScale.ReplaceX(JGNJJIKPICF);
		bool flag = PKHHKJLGHFM.transform.localPosition.x > 0f;
		float val = PKHHKJLGHFM.transform.localPosition.x + UIHelper.safeAreaSize * ((!flag) ? (-1f) : 1f);
		PKHHKJLGHFM.transform.localPosition = PKHHKJLGHFM.transform.localPosition.ReplaceX(val);
		Singleton<GameController>.instance.GameStarted += NCAKLEOEDBO;
		Singleton<GameController>.instance.GameEnded += KPPNCJBMDPE;
	}

	public void NNDPICEIGFP()
	{
		StopAllCoroutines();
		KMFGCJEGJJK.gameObject.SetActive(value: false);
		CGJIGBDGOOO.gameObject.SetActive(value: false);
		MNAJKODCACI.gameObject.SetActive(value: false);
		PKHHKJLGHFM.gameObject.SetActive(value: true);
	}

	private IEnumerator PIKIOLODGPG()
	{
		OAMJNPNCIBK oAMJNPNCIBK = new OAMJNPNCIBK();
		oAMJNPNCIBK.BJGCPDNMHDH = this;
		return oAMJNPNCIBK;
	}

	public void DFPEMJOLONE()
	{
		float num = 1846f;
		float num2 = 161f;
		JGNJJIKPICF = UIHelper.activeWidthFull / 1059f - num;
		HOLDFDIMINM = JGNJJIKPICF + num2;
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX(HOLDFDIMINM);
		CGJIGBDGOOO.transform.localScale = CGJIGBDGOOO.transform.localScale.ReplaceX(JGNJJIKPICF);
		MNAJKODCACI.transform.localScale = MNAJKODCACI.transform.localScale.ReplaceX(JGNJJIKPICF);
		bool flag = PKHHKJLGHFM.transform.localPosition.x > 1501f;
		float val = PKHHKJLGHFM.transform.localPosition.x + UIHelper.safeAreaSize * ((!flag) ? 1084f : 707f);
		PKHHKJLGHFM.transform.localPosition = PKHHKJLGHFM.transform.localPosition.ReplaceX(val);
		Singleton<GameController>.instance.GameStarted += NCAKLEOEDBO;
		Singleton<GameController>.instance.GameEnded += OEELFECKDNI;
	}

	private IEnumerator PBCMMIDDAEE()
	{
		PLDLDNEHMHE pLDLDNEHMHE = new PLDLDNEHMHE();
		pLDLDNEHMHE.BJGCPDNMHDH = this;
		return pLDLDNEHMHE;
	}

	private IEnumerator CNBADNLJJPF()
	{
		FBFAAPEJNBB fBFAAPEJNBB = new FBFAAPEJNBB();
		fBFAAPEJNBB.BJGCPDNMHDH = this;
		return fBFAAPEJNBB;
	}

	private void DAMBNNFEHGC()
	{
		MBIAKMPDOPG = ((!HOKOINDLJPO) ? PlayerController.GetEnemyOf(PlayerController.OGMBJPKOPCB.fraction) : PlayerController.OGMBJPKOPCB);
		PKHHKJLGHFM.text = MBIAKMPDOPG.EHHHBEMKGOE.MHPNDNJDPGE;
	}

	public void MFCIGCEBBDO()
	{
		MNGFPJBAOFB();
		StopAllCoroutines();
		NCAKLEOEDBO();
		KMFGCJEGJJK.gameObject.SetActive(value: false);
		MNAJKODCACI.gameObject.SetActive(value: false);
		PKHHKJLGHFM.gameObject.SetActive(value: true);
		StartCoroutine(IGOEBLNEKLI());
	}

	private void JNCKDLNCOEL(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		if (!(MBIAKMPDOPG != null))
		{
			return;
		}
		StopCoroutine(EJEBAKCKIKD());
		SoundsManager.Instance.onSoundVolumeChange -= HGJMKHINDBG;
		if (BNHAJBLDKOP)
		{
			if (DOLNDLHICOO.isPlaying)
			{
				DOLNDLHICOO.Stop();
			}
			StopCoroutine(HJKKLGFNDCF());
		}
		MBIAKMPDOPG = null;
		BNHAJBLDKOP = false;
		DKFLKBMKKKI = null;
	}

	private void JCMOIICMHCM()
	{
		DOLNDLHICOO.volume = SoundsManager.Instance.soundsVolume;
	}

	private IEnumerator GOHBDCIHGPD()
	{
		FBFAAPEJNBB fBFAAPEJNBB = new FBFAAPEJNBB();
		fBFAAPEJNBB.BJGCPDNMHDH = this;
		return fBFAAPEJNBB;
	}

	private IEnumerator OHOOHLGNNOM(float KBJEOEEOEFG, float KALLNCAFIMP)
	{
		FNPAALMBOIF fNPAALMBOIF = new FNPAALMBOIF();
		fNPAALMBOIF.KALLNCAFIMP = KALLNCAFIMP;
		fNPAALMBOIF.KBJEOEEOEFG = KBJEOEEOEFG;
		fNPAALMBOIF.BJGCPDNMHDH = this;
		return fNPAALMBOIF;
	}

	private IEnumerator FJLDGFMBDMB(float KBJEOEEOEFG, float KALLNCAFIMP)
	{
		FNPAALMBOIF fNPAALMBOIF = new FNPAALMBOIF();
		fNPAALMBOIF.KALLNCAFIMP = KALLNCAFIMP;
		fNPAALMBOIF.KBJEOEEOEFG = KBJEOEEOEFG;
		fNPAALMBOIF.BJGCPDNMHDH = this;
		return fNPAALMBOIF;
	}

	private IEnumerator ILPOPEAIEFO(float KBJEOEEOEFG, float KALLNCAFIMP)
	{
		FNPAALMBOIF fNPAALMBOIF = new FNPAALMBOIF();
		fNPAALMBOIF.KALLNCAFIMP = KALLNCAFIMP;
		fNPAALMBOIF.KBJEOEEOEFG = KBJEOEEOEFG;
		fNPAALMBOIF.BJGCPDNMHDH = this;
		return fNPAALMBOIF;
	}
}
