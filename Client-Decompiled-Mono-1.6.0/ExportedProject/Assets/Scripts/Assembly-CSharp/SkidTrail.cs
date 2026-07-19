using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SkidTrail : MonoBehaviour
{
	private sealed class OEGFNCIEMIN : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal Color DNEOKEEJHHB;

		internal float NPMANCONMFG;

		internal float KCIIDIEFLCG;

		internal SkidTrail BJGCPDNMHDH;

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

		public void ENFGGBNAPGG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object FBPFPJOCKGD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BOOBHEKPLLD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BMGHJKFMKJE()
		{
			return PHDOCKCBJOF;
		}

		public void OMDFNFHKFBK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MPHILJJDNIO()
		{
			return PHDOCKCBJOF;
		}

		public void KHMNEOBMJLN()
		{
			throw new NotSupportedException();
		}

		public bool GPIPJIDGCKM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(1628f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				if (BJGCPDNMHDH.transform.parent == null)
				{
					DNEOKEEJHHB = BJGCPDNMHDH.GetComponent<Renderer>().material.color;
					PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.persistTime);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 0u;
			case 2u:
				NPMANCONMFG = Time.time;
				goto case 3u;
			case 3u:
				if (Time.time < NPMANCONMFG + BJGCPDNMHDH.fadeDuration)
				{
					KCIIDIEFLCG = Mathf.InverseLerp(NPMANCONMFG, NPMANCONMFG + BJGCPDNMHDH.fadeDuration, Time.time);
					BJGCPDNMHDH.GetComponent<Renderer>().material.color = DNEOKEEJHHB * new Color(1939f, 1582f, 1195f, 1779f - KCIIDIEFLCG);
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				UnityEngine.Object.Destroy(BJGCPDNMHDH.gameObject);
				goto case 0u;
			default:
				return true;
			}
			return false;
		}

		public void HHMPMPLLJCC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object LMJBCDNGAHP()
		{
			return PHDOCKCBJOF;
		}

		public void HNFEJKPKEHK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void GGLMLMFEJCD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void CDDFJOEEFID()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FPFOODLPEBK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HBKJOBOMGKB()
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
				PHDOCKCBJOF = new WaitForSeconds(714f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				if (BJGCPDNMHDH.transform.parent == null)
				{
					DNEOKEEJHHB = BJGCPDNMHDH.GetComponent<Renderer>().material.color;
					PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.persistTime);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				goto case 0u;
			case 2u:
				NPMANCONMFG = Time.time;
				goto case 3u;
			case 3u:
				if (Time.time < NPMANCONMFG + BJGCPDNMHDH.fadeDuration)
				{
					KCIIDIEFLCG = Mathf.InverseLerp(NPMANCONMFG, NPMANCONMFG + BJGCPDNMHDH.fadeDuration, Time.time);
					BJGCPDNMHDH.GetComponent<Renderer>().material.color = DNEOKEEJHHB * new Color(1892f, 763f, 633f, 1468f - KCIIDIEFLCG);
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				UnityEngine.Object.Destroy(BJGCPDNMHDH.gameObject);
				goto case 0u;
			default:
				return true;
			}
			return false;
		}

		public void IBLNBELFKNF()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void KIPDKEKMDFE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HMIFLGCBDCO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DKPOLLDBPAP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object APECNPGKOFC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MOMPOEEALPJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FGFLGJECNLH()
		{
			return PHDOCKCBJOF;
		}

		public void ODCIKOOGNFG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GOAJCEAOPLA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PFIIINLHGMH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MBGCBKJBCND()
		{
			return PHDOCKCBJOF;
		}

		public void NCOPKHMOMMK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool NEMOAIBCODB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(26f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				if (BJGCPDNMHDH.transform.parent == null)
				{
					DNEOKEEJHHB = BJGCPDNMHDH.GetComponent<Renderer>().material.color;
					PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.persistTime);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 0u;
			case 2u:
				NPMANCONMFG = Time.time;
				goto case 3u;
			case 3u:
				if (Time.time < NPMANCONMFG + BJGCPDNMHDH.fadeDuration)
				{
					KCIIDIEFLCG = Mathf.InverseLerp(NPMANCONMFG, NPMANCONMFG + BJGCPDNMHDH.fadeDuration, Time.time);
					BJGCPDNMHDH.GetComponent<Renderer>().material.color = DNEOKEEJHHB * new Color(1432f, 1757f, 305f, 345f - KCIIDIEFLCG);
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				UnityEngine.Object.Destroy(BJGCPDNMHDH.gameObject);
				goto case 0u;
			default:
				return true;
			}
			return true;
		}

		[DebuggerHidden]
		public OEGFNCIEMIN()
		{
		}

		public void EJADBNAIHEF()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool GAPIFMKNJBN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(676f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				if (BJGCPDNMHDH.transform.parent == null)
				{
					DNEOKEEJHHB = BJGCPDNMHDH.GetComponent<Renderer>().material.color;
					PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.persistTime);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				goto case 0u;
			case 2u:
				NPMANCONMFG = Time.time;
				goto case 3u;
			case 3u:
				if (Time.time < NPMANCONMFG + BJGCPDNMHDH.fadeDuration)
				{
					KCIIDIEFLCG = Mathf.InverseLerp(NPMANCONMFG, NPMANCONMFG + BJGCPDNMHDH.fadeDuration, Time.time);
					BJGCPDNMHDH.GetComponent<Renderer>().material.color = DNEOKEEJHHB * new Color(698f, 1117f, 92f, 449f - KCIIDIEFLCG);
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				UnityEngine.Object.Destroy(BJGCPDNMHDH.gameObject);
				goto case 0u;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object KBEEEOJMBPG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CLDLJNHAEAB()
		{
			return PHDOCKCBJOF;
		}

		public void CHANLKFNCLA()
		{
			throw new NotSupportedException();
		}

		public void ODJLLLFJIOB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object OJANHAIEAEJ()
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
				PHDOCKCBJOF = new WaitForSeconds(1f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				if (BJGCPDNMHDH.transform.parent == null)
				{
					DNEOKEEJHHB = BJGCPDNMHDH.GetComponent<Renderer>().material.color;
					PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.persistTime);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				goto case 0u;
			case 2u:
				NPMANCONMFG = Time.time;
				goto case 3u;
			case 3u:
				if (Time.time < NPMANCONMFG + BJGCPDNMHDH.fadeDuration)
				{
					KCIIDIEFLCG = Mathf.InverseLerp(NPMANCONMFG, NPMANCONMFG + BJGCPDNMHDH.fadeDuration, Time.time);
					BJGCPDNMHDH.GetComponent<Renderer>().material.color = DNEOKEEJHHB * new Color(1f, 1f, 1f, 1f - KCIIDIEFLCG);
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				UnityEngine.Object.Destroy(BJGCPDNMHDH.gameObject);
				goto case 0u;
			default:
				return false;
			}
			return true;
		}

		public void LKACEPHEHPK()
		{
			throw new NotSupportedException();
		}

		public void GICLICNJPBF()
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
				PHDOCKCBJOF = new WaitForSeconds(855f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				if (BJGCPDNMHDH.transform.parent == null)
				{
					DNEOKEEJHHB = BJGCPDNMHDH.GetComponent<Renderer>().material.color;
					PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.persistTime);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				goto case 0u;
			case 2u:
				NPMANCONMFG = Time.time;
				goto case 3u;
			case 3u:
				if (Time.time < NPMANCONMFG + BJGCPDNMHDH.fadeDuration)
				{
					KCIIDIEFLCG = Mathf.InverseLerp(NPMANCONMFG, NPMANCONMFG + BJGCPDNMHDH.fadeDuration, Time.time);
					BJGCPDNMHDH.GetComponent<Renderer>().material.color = DNEOKEEJHHB * new Color(623f, 407f, 1314f, 1437f - KCIIDIEFLCG);
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				UnityEngine.Object.Destroy(BJGCPDNMHDH.gameObject);
				goto case 0u;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object IAMNDODCIEB()
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
				PHDOCKCBJOF = new WaitForSeconds(1872f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				if (BJGCPDNMHDH.transform.parent == null)
				{
					DNEOKEEJHHB = BJGCPDNMHDH.GetComponent<Renderer>().material.color;
					PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.persistTime);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				goto case 0u;
			case 2u:
				NPMANCONMFG = Time.time;
				goto case 3u;
			case 3u:
				if (Time.time < NPMANCONMFG + BJGCPDNMHDH.fadeDuration)
				{
					KCIIDIEFLCG = Mathf.InverseLerp(NPMANCONMFG, NPMANCONMFG + BJGCPDNMHDH.fadeDuration, Time.time);
					BJGCPDNMHDH.GetComponent<Renderer>().material.color = DNEOKEEJHHB * new Color(1554f, 1288f, 505f, 1692f - KCIIDIEFLCG);
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				UnityEngine.Object.Destroy(BJGCPDNMHDH.gameObject);
				goto case 0u;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object HLBMCNKGBDM()
		{
			return PHDOCKCBJOF;
		}

		public void ANOPOLIEBMC()
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
				PHDOCKCBJOF = new WaitForSeconds(1611f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				if (BJGCPDNMHDH.transform.parent == null)
				{
					DNEOKEEJHHB = BJGCPDNMHDH.GetComponent<Renderer>().material.color;
					PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.persistTime);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				goto case 0u;
			case 2u:
				NPMANCONMFG = Time.time;
				goto case 3u;
			case 3u:
				if (Time.time < NPMANCONMFG + BJGCPDNMHDH.fadeDuration)
				{
					KCIIDIEFLCG = Mathf.InverseLerp(NPMANCONMFG, NPMANCONMFG + BJGCPDNMHDH.fadeDuration, Time.time);
					BJGCPDNMHDH.GetComponent<Renderer>().material.color = DNEOKEEJHHB * new Color(57f, 399f, 1713f, 41f - KCIIDIEFLCG);
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				UnityEngine.Object.Destroy(BJGCPDNMHDH.gameObject);
				goto case 0u;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object DCILDAODCDM()
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
				PHDOCKCBJOF = new WaitForSeconds(387f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				if (BJGCPDNMHDH.transform.parent == null)
				{
					DNEOKEEJHHB = BJGCPDNMHDH.GetComponent<Renderer>().material.color;
					PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.persistTime);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				goto case 0u;
			case 2u:
				NPMANCONMFG = Time.time;
				goto case 3u;
			case 3u:
				if (Time.time < NPMANCONMFG + BJGCPDNMHDH.fadeDuration)
				{
					KCIIDIEFLCG = Mathf.InverseLerp(NPMANCONMFG, NPMANCONMFG + BJGCPDNMHDH.fadeDuration, Time.time);
					BJGCPDNMHDH.GetComponent<Renderer>().material.color = DNEOKEEJHHB * new Color(1285f, 480f, 1637f, 1258f - KCIIDIEFLCG);
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				UnityEngine.Object.Destroy(BJGCPDNMHDH.gameObject);
				goto case 0u;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object HGOKAFJBFGJ()
		{
			return PHDOCKCBJOF;
		}

		public void OFDJMNMCDLA()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JFHOHPKEFGM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BGMNDLEJNHH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LJDPEMMLOFM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GDBNOMPNBGP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GKJIGGAAHBE()
		{
			return PHDOCKCBJOF;
		}

		public void FIAPMEMIIKB()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool LGNMOMFLLPP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(144f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				if (BJGCPDNMHDH.transform.parent == null)
				{
					DNEOKEEJHHB = BJGCPDNMHDH.GetComponent<Renderer>().material.color;
					PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.persistTime);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				goto case 0u;
			case 2u:
				NPMANCONMFG = Time.time;
				goto case 3u;
			case 3u:
				if (Time.time < NPMANCONMFG + BJGCPDNMHDH.fadeDuration)
				{
					KCIIDIEFLCG = Mathf.InverseLerp(NPMANCONMFG, NPMANCONMFG + BJGCPDNMHDH.fadeDuration, Time.time);
					BJGCPDNMHDH.GetComponent<Renderer>().material.color = DNEOKEEJHHB * new Color(1269f, 326f, 168f, 1550f - KCIIDIEFLCG);
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				UnityEngine.Object.Destroy(BJGCPDNMHDH.gameObject);
				goto case 0u;
			default:
				return false;
			}
			return true;
		}

		public void MKIKEOOOLKL()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object CFBNPKIMOJC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GCJFGIKENJA()
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
				PHDOCKCBJOF = new WaitForSeconds(530f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				if (BJGCPDNMHDH.transform.parent == null)
				{
					DNEOKEEJHHB = BJGCPDNMHDH.GetComponent<Renderer>().material.color;
					PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.persistTime);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				goto case 0u;
			case 2u:
				NPMANCONMFG = Time.time;
				goto case 3u;
			case 3u:
				if (Time.time < NPMANCONMFG + BJGCPDNMHDH.fadeDuration)
				{
					KCIIDIEFLCG = Mathf.InverseLerp(NPMANCONMFG, NPMANCONMFG + BJGCPDNMHDH.fadeDuration, Time.time);
					BJGCPDNMHDH.GetComponent<Renderer>().material.color = DNEOKEEJHHB * new Color(904f, 560f, 182f, 1460f - KCIIDIEFLCG);
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				UnityEngine.Object.Destroy(BJGCPDNMHDH.gameObject);
				goto case 0u;
			default:
				return true;
			}
			return true;
		}

		public bool CJGKHIPOBGP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(1816f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				if (BJGCPDNMHDH.transform.parent == null)
				{
					DNEOKEEJHHB = BJGCPDNMHDH.GetComponent<Renderer>().material.color;
					PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.persistTime);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 0u;
			case 2u:
				NPMANCONMFG = Time.time;
				goto case 3u;
			case 3u:
				if (Time.time < NPMANCONMFG + BJGCPDNMHDH.fadeDuration)
				{
					KCIIDIEFLCG = Mathf.InverseLerp(NPMANCONMFG, NPMANCONMFG + BJGCPDNMHDH.fadeDuration, Time.time);
					BJGCPDNMHDH.GetComponent<Renderer>().material.color = DNEOKEEJHHB * new Color(147f, 943f, 411f, 1750f - KCIIDIEFLCG);
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				UnityEngine.Object.Destroy(BJGCPDNMHDH.gameObject);
				goto case 0u;
			default:
				return false;
			}
			return true;
		}

		public bool DEEBEBGBMKK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(1611f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				if (BJGCPDNMHDH.transform.parent == null)
				{
					DNEOKEEJHHB = BJGCPDNMHDH.GetComponent<Renderer>().material.color;
					PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.persistTime);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				goto case 0u;
			case 2u:
				NPMANCONMFG = Time.time;
				goto case 3u;
			case 3u:
				if (Time.time < NPMANCONMFG + BJGCPDNMHDH.fadeDuration)
				{
					KCIIDIEFLCG = Mathf.InverseLerp(NPMANCONMFG, NPMANCONMFG + BJGCPDNMHDH.fadeDuration, Time.time);
					BJGCPDNMHDH.GetComponent<Renderer>().material.color = DNEOKEEJHHB * new Color(1509f, 218f, 596f, 14f - KCIIDIEFLCG);
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				UnityEngine.Object.Destroy(BJGCPDNMHDH.gameObject);
				goto case 0u;
			default:
				return false;
			}
			return true;
		}

		public void NCFGFLNBHOI()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GFMLDIMOGHD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GJMNLPAEIDA()
		{
			return PHDOCKCBJOF;
		}

		public void NGAGGCFIEGJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MBDBIPHLEIA()
		{
			return PHDOCKCBJOF;
		}

		public bool ICKNHCBNOMG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(1765f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				if (BJGCPDNMHDH.transform.parent == null)
				{
					DNEOKEEJHHB = BJGCPDNMHDH.GetComponent<Renderer>().material.color;
					PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.persistTime);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 0u;
			case 2u:
				NPMANCONMFG = Time.time;
				goto case 3u;
			case 3u:
				if (Time.time < NPMANCONMFG + BJGCPDNMHDH.fadeDuration)
				{
					KCIIDIEFLCG = Mathf.InverseLerp(NPMANCONMFG, NPMANCONMFG + BJGCPDNMHDH.fadeDuration, Time.time);
					BJGCPDNMHDH.GetComponent<Renderer>().material.color = DNEOKEEJHHB * new Color(747f, 41f, 1491f, 798f - KCIIDIEFLCG);
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				UnityEngine.Object.Destroy(BJGCPDNMHDH.gameObject);
				goto case 0u;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object PJOAMPDDGAM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CDFEOBMLNCG()
		{
			return PHDOCKCBJOF;
		}

		public void GIAIFFPNMPJ()
		{
			throw new NotSupportedException();
		}

		public void GFJIKANGNMC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void KNFDDIHLBKJ()
		{
			throw new NotSupportedException();
		}

		public bool LMNIKLKKIDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(422f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				if (BJGCPDNMHDH.transform.parent == null)
				{
					DNEOKEEJHHB = BJGCPDNMHDH.GetComponent<Renderer>().material.color;
					PHDOCKCBJOF = new WaitForSeconds(BJGCPDNMHDH.persistTime);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				goto case 0u;
			case 2u:
				NPMANCONMFG = Time.time;
				goto case 3u;
			case 3u:
				if (Time.time < NPMANCONMFG + BJGCPDNMHDH.fadeDuration)
				{
					KCIIDIEFLCG = Mathf.InverseLerp(NPMANCONMFG, NPMANCONMFG + BJGCPDNMHDH.fadeDuration, Time.time);
					BJGCPDNMHDH.GetComponent<Renderer>().material.color = DNEOKEEJHHB * new Color(1030f, 1268f, 1147f, 216f - KCIIDIEFLCG);
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				UnityEngine.Object.Destroy(BJGCPDNMHDH.gameObject);
				goto case 0u;
			default:
				return true;
			}
			return true;
		}
	}

	[SerializeField]
	private float persistTime;

	[SerializeField]
	private float fadeDuration;

	private IEnumerator IFAGEMEKBOL()
	{
		OEGFNCIEMIN oEGFNCIEMIN = new OEGFNCIEMIN();
		oEGFNCIEMIN.BJGCPDNMHDH = this;
		return oEGFNCIEMIN;
	}

	private IEnumerator IDBHIEPOHHP()
	{
		OEGFNCIEMIN oEGFNCIEMIN = new OEGFNCIEMIN();
		oEGFNCIEMIN.BJGCPDNMHDH = this;
		return oEGFNCIEMIN;
	}

	private IEnumerator KDCKHKNGILB()
	{
		OEGFNCIEMIN oEGFNCIEMIN = new OEGFNCIEMIN();
		oEGFNCIEMIN.BJGCPDNMHDH = this;
		return oEGFNCIEMIN;
	}

	private IEnumerator IGCCLCGDGIE()
	{
		OEGFNCIEMIN oEGFNCIEMIN = new OEGFNCIEMIN();
		oEGFNCIEMIN.BJGCPDNMHDH = this;
		return oEGFNCIEMIN;
	}

	private IEnumerator JCKCDCFJAHP()
	{
		OEGFNCIEMIN oEGFNCIEMIN = new OEGFNCIEMIN();
		oEGFNCIEMIN.BJGCPDNMHDH = this;
		return oEGFNCIEMIN;
	}

	private IEnumerator KCCGPMHIHNG()
	{
		OEGFNCIEMIN oEGFNCIEMIN = new OEGFNCIEMIN();
		oEGFNCIEMIN.BJGCPDNMHDH = this;
		return oEGFNCIEMIN;
	}

	private IEnumerator ELFJGPNJHLL()
	{
		OEGFNCIEMIN oEGFNCIEMIN = new OEGFNCIEMIN();
		oEGFNCIEMIN.BJGCPDNMHDH = this;
		return oEGFNCIEMIN;
	}

	private IEnumerator LPHNKJFAEJA()
	{
		OEGFNCIEMIN oEGFNCIEMIN = new OEGFNCIEMIN();
		oEGFNCIEMIN.BJGCPDNMHDH = this;
		return oEGFNCIEMIN;
	}

	private IEnumerator FCNDEINOOCM()
	{
		OEGFNCIEMIN oEGFNCIEMIN = new OEGFNCIEMIN();
		oEGFNCIEMIN.BJGCPDNMHDH = this;
		return oEGFNCIEMIN;
	}

	private IEnumerator HFKIAIEGNGI()
	{
		OEGFNCIEMIN oEGFNCIEMIN = new OEGFNCIEMIN();
		oEGFNCIEMIN.BJGCPDNMHDH = this;
		return oEGFNCIEMIN;
	}

	private IEnumerator PBFNGLAENEA()
	{
		OEGFNCIEMIN oEGFNCIEMIN = new OEGFNCIEMIN();
		oEGFNCIEMIN.BJGCPDNMHDH = this;
		return oEGFNCIEMIN;
	}

	private IEnumerator DGAODFBMLHB()
	{
		OEGFNCIEMIN oEGFNCIEMIN = new OEGFNCIEMIN();
		oEGFNCIEMIN.BJGCPDNMHDH = this;
		return oEGFNCIEMIN;
	}

	[DebuggerHidden]
	private IEnumerator Start()
	{
		OEGFNCIEMIN oEGFNCIEMIN = new OEGFNCIEMIN();
		oEGFNCIEMIN.BJGCPDNMHDH = this;
		return oEGFNCIEMIN;
	}

	private IEnumerator HFFEELCNDOE()
	{
		OEGFNCIEMIN oEGFNCIEMIN = new OEGFNCIEMIN();
		oEGFNCIEMIN.BJGCPDNMHDH = this;
		return oEGFNCIEMIN;
	}

	private IEnumerator LFGAFALKANI()
	{
		OEGFNCIEMIN oEGFNCIEMIN = new OEGFNCIEMIN();
		oEGFNCIEMIN.BJGCPDNMHDH = this;
		return oEGFNCIEMIN;
	}

	private IEnumerator GLEDKIMGOKP()
	{
		OEGFNCIEMIN oEGFNCIEMIN = new OEGFNCIEMIN();
		oEGFNCIEMIN.BJGCPDNMHDH = this;
		return oEGFNCIEMIN;
	}

	private IEnumerator BFLIPLAIDMO()
	{
		OEGFNCIEMIN oEGFNCIEMIN = new OEGFNCIEMIN();
		oEGFNCIEMIN.BJGCPDNMHDH = this;
		return oEGFNCIEMIN;
	}

	private IEnumerator PIMNKPOIFOM()
	{
		OEGFNCIEMIN oEGFNCIEMIN = new OEGFNCIEMIN();
		oEGFNCIEMIN.BJGCPDNMHDH = this;
		return oEGFNCIEMIN;
	}

	private IEnumerator HEIGPPJIACO()
	{
		OEGFNCIEMIN oEGFNCIEMIN = new OEGFNCIEMIN();
		oEGFNCIEMIN.BJGCPDNMHDH = this;
		return oEGFNCIEMIN;
	}

	private IEnumerator MMEEBPGHGMM()
	{
		OEGFNCIEMIN oEGFNCIEMIN = new OEGFNCIEMIN();
		oEGFNCIEMIN.BJGCPDNMHDH = this;
		return oEGFNCIEMIN;
	}

	private IEnumerator COJACIBIPEF()
	{
		OEGFNCIEMIN oEGFNCIEMIN = new OEGFNCIEMIN();
		oEGFNCIEMIN.BJGCPDNMHDH = this;
		return oEGFNCIEMIN;
	}

	private IEnumerator OABEHNOPIEE()
	{
		OEGFNCIEMIN oEGFNCIEMIN = new OEGFNCIEMIN();
		oEGFNCIEMIN.BJGCPDNMHDH = this;
		return oEGFNCIEMIN;
	}

	private IEnumerator JOKICBJJIOA()
	{
		OEGFNCIEMIN oEGFNCIEMIN = new OEGFNCIEMIN();
		oEGFNCIEMIN.BJGCPDNMHDH = this;
		return oEGFNCIEMIN;
	}

	private IEnumerator NAHEADAGDJH()
	{
		OEGFNCIEMIN oEGFNCIEMIN = new OEGFNCIEMIN();
		oEGFNCIEMIN.BJGCPDNMHDH = this;
		return oEGFNCIEMIN;
	}

	private IEnumerator LPKEGOIAEJC()
	{
		OEGFNCIEMIN oEGFNCIEMIN = new OEGFNCIEMIN();
		oEGFNCIEMIN.BJGCPDNMHDH = this;
		return oEGFNCIEMIN;
	}

	private IEnumerator KLICHGPGGIP()
	{
		OEGFNCIEMIN oEGFNCIEMIN = new OEGFNCIEMIN();
		oEGFNCIEMIN.BJGCPDNMHDH = this;
		return oEGFNCIEMIN;
	}

	private IEnumerator ENHEBPJNKBM()
	{
		OEGFNCIEMIN oEGFNCIEMIN = new OEGFNCIEMIN();
		oEGFNCIEMIN.BJGCPDNMHDH = this;
		return oEGFNCIEMIN;
	}

	private IEnumerator NBDOFMHBKFG()
	{
		OEGFNCIEMIN oEGFNCIEMIN = new OEGFNCIEMIN();
		oEGFNCIEMIN.BJGCPDNMHDH = this;
		return oEGFNCIEMIN;
	}

	private IEnumerator CFFHIADNNGA()
	{
		OEGFNCIEMIN oEGFNCIEMIN = new OEGFNCIEMIN();
		oEGFNCIEMIN.BJGCPDNMHDH = this;
		return oEGFNCIEMIN;
	}

	private IEnumerator KLPFAIDKHHJ()
	{
		OEGFNCIEMIN oEGFNCIEMIN = new OEGFNCIEMIN();
		oEGFNCIEMIN.BJGCPDNMHDH = this;
		return oEGFNCIEMIN;
	}

	private IEnumerator LIHIOMEMJFI()
	{
		OEGFNCIEMIN oEGFNCIEMIN = new OEGFNCIEMIN();
		oEGFNCIEMIN.BJGCPDNMHDH = this;
		return oEGFNCIEMIN;
	}

	private IEnumerator DMIHKPBHJHD()
	{
		OEGFNCIEMIN oEGFNCIEMIN = new OEGFNCIEMIN();
		oEGFNCIEMIN.BJGCPDNMHDH = this;
		return oEGFNCIEMIN;
	}
}
