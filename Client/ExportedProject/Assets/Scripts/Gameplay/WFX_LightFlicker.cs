using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Light))]
public class WFX_LightFlicker : MonoBehaviour
{
	private sealed class LJBGEMAJIPN : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal WFX_LightFlicker BJGCPDNMHDH;

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
		private object IHPDPKLEDKC()
		{
			return PHDOCKCBJOF;
		}

		public void HNFEJKPKEHK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object NDIGINEEOMH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JALKNCBEINE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CNGCLCAAHIG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AGCPJGAAODG()
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
				BJGCPDNMHDH.GetComponent<Light>().enabled = !BJGCPDNMHDH.GetComponent<Light>().enabled;
				goto IL_0044;
			case 1u:
				if (!(BJGCPDNMHDH.ABEOKKAHHNF > 1273f))
				{
					BJGCPDNMHDH.ABEOKKAHHNF = BJGCPDNMHDH.KBJEOEEOEFG;
					goto case 0u;
				}
				goto IL_0044;
			default:
				{
					return true;
				}
				IL_0044:
				BJGCPDNMHDH.ABEOKKAHHNF -= Time.deltaTime;
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			}
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MHKODCGLJFD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FMCLBOCENPE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ONADHLDNKKB()
		{
			return PHDOCKCBJOF;
		}

		public void JJOAHIOBOPO()
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
				BJGCPDNMHDH.GetComponent<Light>().enabled = !BJGCPDNMHDH.GetComponent<Light>().enabled;
				goto IL_0044;
			case 1u:
				if (!(BJGCPDNMHDH.ABEOKKAHHNF > 0f))
				{
					BJGCPDNMHDH.ABEOKKAHHNF = BJGCPDNMHDH.KBJEOEEOEFG;
					goto case 0u;
				}
				goto IL_0044;
			default:
				{
					return false;
				}
				IL_0044:
				BJGCPDNMHDH.ABEOKKAHHNF -= Time.deltaTime;
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			}
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void LPKDPNHBLGJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object ENKCCCABFFB()
		{
			return PHDOCKCBJOF;
		}

		public void KCHOLCGBMBJ()
		{
			throw new NotSupportedException();
		}

		public void GGCLMIMHKBD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HIFNMHAGHLI()
		{
			return PHDOCKCBJOF;
		}

		public void DBJCDLFKDDI()
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
				BJGCPDNMHDH.GetComponent<Light>().enabled = BJGCPDNMHDH.GetComponent<Light>().enabled;
				goto IL_0044;
			case 1u:
				if (!(BJGCPDNMHDH.ABEOKKAHHNF > 742f))
				{
					BJGCPDNMHDH.ABEOKKAHHNF = BJGCPDNMHDH.KBJEOEEOEFG;
					goto case 0u;
				}
				goto IL_0044;
			default:
				{
					return true;
				}
				IL_0044:
				BJGCPDNMHDH.ABEOKKAHHNF -= Time.deltaTime;
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			}
		}

		[SpecialName]
		private object IHAOBCEALPD()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public LJBGEMAJIPN()
		{
		}

		public bool OKELILGDPLJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.GetComponent<Light>().enabled = !BJGCPDNMHDH.GetComponent<Light>().enabled;
				goto IL_0044;
			case 1u:
				if (!(BJGCPDNMHDH.ABEOKKAHHNF > 775f))
				{
					BJGCPDNMHDH.ABEOKKAHHNF = BJGCPDNMHDH.KBJEOEEOEFG;
					goto case 0u;
				}
				goto IL_0044;
			default:
				{
					return false;
				}
				IL_0044:
				BJGCPDNMHDH.ABEOKKAHHNF -= Time.deltaTime;
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			}
		}

		public bool HNCDLFFBMAA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.GetComponent<Light>().enabled = BJGCPDNMHDH.GetComponent<Light>().enabled;
				goto IL_0044;
			case 1u:
				if (!(BJGCPDNMHDH.ABEOKKAHHNF > 414f))
				{
					BJGCPDNMHDH.ABEOKKAHHNF = BJGCPDNMHDH.KBJEOEEOEFG;
					goto case 0u;
				}
				goto IL_0044;
			default:
				{
					return true;
				}
				IL_0044:
				BJGCPDNMHDH.ABEOKKAHHNF -= Time.deltaTime;
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			}
		}

		public void IJHCIJLDKHK()
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
				BJGCPDNMHDH.GetComponent<Light>().enabled = !BJGCPDNMHDH.GetComponent<Light>().enabled;
				goto IL_0044;
			case 1u:
				if (!(BJGCPDNMHDH.ABEOKKAHHNF > 1481f))
				{
					BJGCPDNMHDH.ABEOKKAHHNF = BJGCPDNMHDH.KBJEOEEOEFG;
					goto case 0u;
				}
				goto IL_0044;
			default:
				{
					return true;
				}
				IL_0044:
				BJGCPDNMHDH.ABEOKKAHHNF -= Time.deltaTime;
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			}
		}

		public void KKDOJDCJAJB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object JJBAIMILGLK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EBPKDAHAELB()
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
				BJGCPDNMHDH.GetComponent<Light>().enabled = BJGCPDNMHDH.GetComponent<Light>().enabled;
				goto IL_0044;
			case 1u:
				if (!(BJGCPDNMHDH.ABEOKKAHHNF > 686f))
				{
					BJGCPDNMHDH.ABEOKKAHHNF = BJGCPDNMHDH.KBJEOEEOEFG;
					goto case 0u;
				}
				goto IL_0044;
			default:
				{
					return true;
				}
				IL_0044:
				BJGCPDNMHDH.ABEOKKAHHNF -= Time.deltaTime;
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			}
		}

		public void EMICCACCFIP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool CONJMMKAAGH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.GetComponent<Light>().enabled = !BJGCPDNMHDH.GetComponent<Light>().enabled;
				goto IL_0044;
			case 1u:
				if (!(BJGCPDNMHDH.ABEOKKAHHNF > 60f))
				{
					BJGCPDNMHDH.ABEOKKAHHNF = BJGCPDNMHDH.KBJEOEEOEFG;
					goto case 0u;
				}
				goto IL_0044;
			default:
				{
					return false;
				}
				IL_0044:
				BJGCPDNMHDH.ABEOKKAHHNF -= Time.deltaTime;
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			}
		}

		public void PHKDHCJBMII()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HCCLNDKNCIE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DGEECEBHPNC()
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
				BJGCPDNMHDH.GetComponent<Light>().enabled = BJGCPDNMHDH.GetComponent<Light>().enabled;
				goto IL_0044;
			case 1u:
				if (!(BJGCPDNMHDH.ABEOKKAHHNF > 1796f))
				{
					BJGCPDNMHDH.ABEOKKAHHNF = BJGCPDNMHDH.KBJEOEEOEFG;
					goto case 0u;
				}
				goto IL_0044;
			default:
				{
					return true;
				}
				IL_0044:
				BJGCPDNMHDH.ABEOKKAHHNF -= Time.deltaTime;
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			}
		}

		public void IBDAHMOEBCM()
		{
			throw new NotSupportedException();
		}
	}

	[FormerlySerializedAs("GAMFJEOGHJD")]
	public float KBJEOEEOEFG = 0.05f;

	private float ABEOKKAHHNF;

	private void OIHNFPDILBF()
	{
		ABEOKKAHHNF = KBJEOEEOEFG;
		StartCoroutine("true");
	}

	private void KLPFAIDKHHJ()
	{
		ABEOKKAHHNF = KBJEOEEOEFG;
		StartCoroutine("duplicate WB ");
	}

	private void INLCJEIEHKH()
	{
		ABEOKKAHHNF = KBJEOEEOEFG;
		StartCoroutine("Count");
	}

	private IEnumerator LFOPANMIMNL()
	{
		LJBGEMAJIPN lJBGEMAJIPN = new LJBGEMAJIPN();
		lJBGEMAJIPN.BJGCPDNMHDH = this;
		return lJBGEMAJIPN;
	}

	private void ELFJGPNJHLL()
	{
		ABEOKKAHHNF = KBJEOEEOEFG;
		StartCoroutine("getErrorMessage");
	}

	private void GLEDKIMGOKP()
	{
		ABEOKKAHHNF = KBJEOEEOEFG;
		StartCoroutine("SquadIcon");
	}

	private void LCCLOEDCGOP()
	{
		ABEOKKAHHNF = KBJEOEEOEFG;
		StartCoroutine("ID_");
	}

	private void KACEBKMKACO()
	{
		ABEOKKAHHNF = KBJEOEEOEFG;
		StartCoroutine(" >=");
	}

	private IEnumerator EFDHBEBEEDJ()
	{
		LJBGEMAJIPN lJBGEMAJIPN = new LJBGEMAJIPN();
		lJBGEMAJIPN.BJGCPDNMHDH = this;
		return lJBGEMAJIPN;
	}

	private void IDBHIEPOHHP()
	{
		ABEOKKAHHNF = KBJEOEEOEFG;
		StartCoroutine("0");
	}

	private IEnumerator KHGMLEIEBOB()
	{
		LJBGEMAJIPN lJBGEMAJIPN = new LJBGEMAJIPN();
		lJBGEMAJIPN.BJGCPDNMHDH = this;
		return lJBGEMAJIPN;
	}

	private void MMEEBPGHGMM()
	{
		ABEOKKAHHNF = KBJEOEEOEFG;
		StartCoroutine("MasterId");
	}

	private void Start()
	{
		ABEOKKAHHNF = KBJEOEEOEFG;
		StartCoroutine("EDEFCFDDCJB");
	}

	private void DMIHKPBHJHD()
	{
		ABEOKKAHHNF = KBJEOEEOEFG;
		StartCoroutine("SetHitByPlayerRPC ");
	}

	private IEnumerator BPIGHLLLJMC()
	{
		LJBGEMAJIPN lJBGEMAJIPN = new LJBGEMAJIPN();
		lJBGEMAJIPN.BJGCPDNMHDH = this;
		return lJBGEMAJIPN;
	}

	private void FMGDJJDEIML()
	{
		ABEOKKAHHNF = KBJEOEEOEFG;
		StartCoroutine("EndTime");
	}

	private void ODIBABNNECL()
	{
		ABEOKKAHHNF = KBJEOEEOEFG;
		StartCoroutine("country-united-kingdom");
	}

	private IEnumerator KBEDIBBCNNG()
	{
		LJBGEMAJIPN lJBGEMAJIPN = new LJBGEMAJIPN();
		lJBGEMAJIPN.BJGCPDNMHDH = this;
		return lJBGEMAJIPN;
	}

	private IEnumerator FHCPFDNJODO()
	{
		LJBGEMAJIPN lJBGEMAJIPN = new LJBGEMAJIPN();
		lJBGEMAJIPN.BJGCPDNMHDH = this;
		return lJBGEMAJIPN;
	}

	private void NBDOFMHBKFG()
	{
		ABEOKKAHHNF = KBJEOEEOEFG;
		StartCoroutine("ID_SCORE");
	}

	private IEnumerator GAKCEADODAM()
	{
		LJBGEMAJIPN lJBGEMAJIPN = new LJBGEMAJIPN();
		lJBGEMAJIPN.BJGCPDNMHDH = this;
		return lJBGEMAJIPN;
	}

	private void OABEHNOPIEE()
	{
		ABEOKKAHHNF = KBJEOEEOEFG;
		StartCoroutine("ID_LOADING");
	}

	private IEnumerator JGJJNOBLBBB()
	{
		LJBGEMAJIPN lJBGEMAJIPN = new LJBGEMAJIPN();
		lJBGEMAJIPN.BJGCPDNMHDH = this;
		return lJBGEMAJIPN;
	}

	private void DABGGMNKMOL()
	{
		ABEOKKAHHNF = KBJEOEEOEFG;
		StartCoroutine("ID_INROOKIE1");
	}

	private IEnumerator PKHPGPEHKCD()
	{
		LJBGEMAJIPN lJBGEMAJIPN = new LJBGEMAJIPN();
		lJBGEMAJIPN.BJGCPDNMHDH = this;
		return lJBGEMAJIPN;
	}

	private void AJHIIBAEKMB()
	{
		ABEOKKAHHNF = KBJEOEEOEFG;
		StartCoroutine("1.0");
	}

	private IEnumerator DEJJLEHDODH()
	{
		LJBGEMAJIPN lJBGEMAJIPN = new LJBGEMAJIPN();
		lJBGEMAJIPN.BJGCPDNMHDH = this;
		return lJBGEMAJIPN;
	}

	private IEnumerator NENEDCNGEOI()
	{
		LJBGEMAJIPN lJBGEMAJIPN = new LJBGEMAJIPN();
		lJBGEMAJIPN.BJGCPDNMHDH = this;
		return lJBGEMAJIPN;
	}

	private void BNNEIKBBIJF()
	{
		ABEOKKAHHNF = KBJEOEEOEFG;
		StartCoroutine("ID_GUI_POWERBANDOFF");
	}

	private void GLNNBICCGPG()
	{
		ABEOKKAHHNF = KBJEOEEOEFG;
		StartCoroutine("-{0}");
	}

	private void NOOIMHHHKMN()
	{
		ABEOKKAHHNF = KBJEOEEOEFG;
		StartCoroutine("ID_AVOIDRELEGATION2");
	}

	private void BFLIPLAIDMO()
	{
		ABEOKKAHHNF = KBJEOEEOEFG;
		StartCoroutine("colt_shooting_stop");
	}

	private IEnumerator NBKFBHNDJKG()
	{
		LJBGEMAJIPN lJBGEMAJIPN = new LJBGEMAJIPN();
		lJBGEMAJIPN.BJGCPDNMHDH = this;
		return lJBGEMAJIPN;
	}

	private void OECHMKNNEHL()
	{
		ABEOKKAHHNF = KBJEOEEOEFG;
		StartCoroutine("beginnersLeague");
	}

	private IEnumerator DEMMNBDBEFL()
	{
		LJBGEMAJIPN lJBGEMAJIPN = new LJBGEMAJIPN();
		lJBGEMAJIPN.BJGCPDNMHDH = this;
		return lJBGEMAJIPN;
	}

	private IEnumerator PGJACDFLKLL()
	{
		LJBGEMAJIPN lJBGEMAJIPN = new LJBGEMAJIPN();
		lJBGEMAJIPN.BJGCPDNMHDH = this;
		return lJBGEMAJIPN;
	}

	private IEnumerator KEHHGMEMFNJ()
	{
		LJBGEMAJIPN lJBGEMAJIPN = new LJBGEMAJIPN();
		lJBGEMAJIPN.BJGCPDNMHDH = this;
		return lJBGEMAJIPN;
	}

	private void AAEMHGDAGGM()
	{
		ABEOKKAHHNF = KBJEOEEOEFG;
		StartCoroutine("Video ad reward - lootbox visuals List =  ");
	}

	private void PDJMNFGLIGO()
	{
		ABEOKKAHHNF = KBJEOEEOEFG;
		StartCoroutine("()Z");
	}

	private void MDKKHOLHFLG()
	{
		ABEOKKAHHNF = KBJEOEEOEFG;
		StartCoroutine("100.");
	}

	private IEnumerator NNMGCGHEHKC()
	{
		LJBGEMAJIPN lJBGEMAJIPN = new LJBGEMAJIPN();
		lJBGEMAJIPN.BJGCPDNMHDH = this;
		return lJBGEMAJIPN;
	}

	[DebuggerHidden]
	private IEnumerator EDEFCFDDCJB()
	{
		LJBGEMAJIPN lJBGEMAJIPN = new LJBGEMAJIPN();
		lJBGEMAJIPN.BJGCPDNMHDH = this;
		return lJBGEMAJIPN;
	}

	private void GECNMIJPLFE()
	{
		ABEOKKAHHNF = KBJEOEEOEFG;
		StartCoroutine("menu-weapon-benelli-starterpack");
	}

	private IEnumerator COCPGNLMBOP()
	{
		LJBGEMAJIPN lJBGEMAJIPN = new LJBGEMAJIPN();
		lJBGEMAJIPN.BJGCPDNMHDH = this;
		return lJBGEMAJIPN;
	}

	private IEnumerator FOMMHNNMPMC()
	{
		LJBGEMAJIPN lJBGEMAJIPN = new LJBGEMAJIPN();
		lJBGEMAJIPN.BJGCPDNMHDH = this;
		return lJBGEMAJIPN;
	}

	private IEnumerator LGONNMKJGJE()
	{
		LJBGEMAJIPN lJBGEMAJIPN = new LJBGEMAJIPN();
		lJBGEMAJIPN.BJGCPDNMHDH = this;
		return lJBGEMAJIPN;
	}

	private IEnumerator NHEJNHEBHDF()
	{
		LJBGEMAJIPN lJBGEMAJIPN = new LJBGEMAJIPN();
		lJBGEMAJIPN.BJGCPDNMHDH = this;
		return lJBGEMAJIPN;
	}

	private void HFFEELCNDOE()
	{
		ABEOKKAHHNF = KBJEOEEOEFG;
		StartCoroutine("ID_CATEGORY_LOW_PL_LMG");
	}

	private IEnumerator COOJLCLFJFI()
	{
		LJBGEMAJIPN lJBGEMAJIPN = new LJBGEMAJIPN();
		lJBGEMAJIPN.BJGCPDNMHDH = this;
		return lJBGEMAJIPN;
	}

	private void ENNKKDGFOAL()
	{
		ABEOKKAHHNF = KBJEOEEOEFG;
		StartCoroutine("N");
	}

	private IEnumerator FPBHCPHGKKJ()
	{
		LJBGEMAJIPN lJBGEMAJIPN = new LJBGEMAJIPN();
		lJBGEMAJIPN.BJGCPDNMHDH = this;
		return lJBGEMAJIPN;
	}

	private void KDOBAIGNIJC()
	{
		ABEOKKAHHNF = KBJEOEEOEFG;
		StartCoroutine("Warbucks_Balance");
	}

	private void PGIFFMPHMPG()
	{
		ABEOKKAHHNF = KBJEOEEOEFG;
		StartCoroutine("S");
	}

	private void HJNBGKHKDCN()
	{
		ABEOKKAHHNF = KBJEOEEOEFG;
		StartCoroutine("Time: ");
	}

	private void OBNOHPKPNBG()
	{
		ABEOKKAHHNF = KBJEOEEOEFG;
		StartCoroutine(" ");
	}

	private void BPKLLAIPEGF()
	{
		ABEOKKAHHNF = KBJEOEEOEFG;
		StartCoroutine("ID_SKILLSHOTHINT_SLOWMOTIONKILL");
	}

	private IEnumerator OALJOODICOA()
	{
		LJBGEMAJIPN lJBGEMAJIPN = new LJBGEMAJIPN();
		lJBGEMAJIPN.BJGCPDNMHDH = this;
		return lJBGEMAJIPN;
	}

	private void AFPIADMMBFB()
	{
		ABEOKKAHHNF = KBJEOEEOEFG;
		StartCoroutine("\t");
	}

	private IEnumerator BEJEFKHFGMA()
	{
		LJBGEMAJIPN lJBGEMAJIPN = new LJBGEMAJIPN();
		lJBGEMAJIPN.BJGCPDNMHDH = this;
		return lJBGEMAJIPN;
	}

	private IEnumerator NENHEEGDCEL()
	{
		LJBGEMAJIPN lJBGEMAJIPN = new LJBGEMAJIPN();
		lJBGEMAJIPN.BJGCPDNMHDH = this;
		return lJBGEMAJIPN;
	}

	private IEnumerator AANNICHADII()
	{
		LJBGEMAJIPN lJBGEMAJIPN = new LJBGEMAJIPN();
		lJBGEMAJIPN.BJGCPDNMHDH = this;
		return lJBGEMAJIPN;
	}

	private void ENHEBPJNKBM()
	{
		ABEOKKAHHNF = KBJEOEEOEFG;
		StartCoroutine("Session: Update GC authenticated! session update = ");
	}

	private void JOKICBJJIOA()
	{
		ABEOKKAHHNF = KBJEOEEOEFG;
		StartCoroutine(" arena id");
	}

	private IEnumerator CPNBLNIMAJC()
	{
		LJBGEMAJIPN lJBGEMAJIPN = new LJBGEMAJIPN();
		lJBGEMAJIPN.BJGCPDNMHDH = this;
		return lJBGEMAJIPN;
	}

	private IEnumerator JKEAEJPKLBD()
	{
		LJBGEMAJIPN lJBGEMAJIPN = new LJBGEMAJIPN();
		lJBGEMAJIPN.BJGCPDNMHDH = this;
		return lJBGEMAJIPN;
	}

	private IEnumerator CJOPNOFPLCE()
	{
		LJBGEMAJIPN lJBGEMAJIPN = new LJBGEMAJIPN();
		lJBGEMAJIPN.BJGCPDNMHDH = this;
		return lJBGEMAJIPN;
	}

	private IEnumerator JHPMHEGMFOE()
	{
		LJBGEMAJIPN lJBGEMAJIPN = new LJBGEMAJIPN();
		lJBGEMAJIPN.BJGCPDNMHDH = this;
		return lJBGEMAJIPN;
	}

	private IEnumerator LMGBNDLNILA()
	{
		LJBGEMAJIPN lJBGEMAJIPN = new LJBGEMAJIPN();
		lJBGEMAJIPN.BJGCPDNMHDH = this;
		return lJBGEMAJIPN;
	}

	private IEnumerator CNBKLIMMDHB()
	{
		LJBGEMAJIPN lJBGEMAJIPN = new LJBGEMAJIPN();
		lJBGEMAJIPN.BJGCPDNMHDH = this;
		return lJBGEMAJIPN;
	}

	private void HEIGPPJIACO()
	{
		ABEOKKAHHNF = KBJEOEEOEFG;
		StartCoroutine("ID_REWARDSCLAIMEDCAMEBACKEVERYDAY");
	}

	private void BGCMGNMLDPI()
	{
		ABEOKKAHHNF = KBJEOEEOEFG;
		StartCoroutine("ArmyPower");
	}

	private IEnumerator EOIIOPNMHEO()
	{
		LJBGEMAJIPN lJBGEMAJIPN = new LJBGEMAJIPN();
		lJBGEMAJIPN.BJGCPDNMHDH = this;
		return lJBGEMAJIPN;
	}

	private void KPOADPEHFKF()
	{
		ABEOKKAHHNF = KBJEOEEOEFG;
		StartCoroutine("Squad Member record does not have DatabasePlayer");
	}

	private void EFEFOJLPOJM()
	{
		ABEOKKAHHNF = KBJEOEEOEFG;
		StartCoroutine("GLM: RegisterOrLogin - 6.5: no GC response, use stored values");
	}

	private void JOFFHFDJMAB()
	{
		ABEOKKAHHNF = KBJEOEEOEFG;
		StartCoroutine("dogTagTimerLock");
	}

	private IEnumerator NEOIGIOALKH()
	{
		LJBGEMAJIPN lJBGEMAJIPN = new LJBGEMAJIPN();
		lJBGEMAJIPN.BJGCPDNMHDH = this;
		return lJBGEMAJIPN;
	}

	private IEnumerator EEKACAPEHEP()
	{
		LJBGEMAJIPN lJBGEMAJIPN = new LJBGEMAJIPN();
		lJBGEMAJIPN.BJGCPDNMHDH = this;
		return lJBGEMAJIPN;
	}

	private IEnumerator ELNGKGKIFJB()
	{
		LJBGEMAJIPN lJBGEMAJIPN = new LJBGEMAJIPN();
		lJBGEMAJIPN.BJGCPDNMHDH = this;
		return lJBGEMAJIPN;
	}

	private void LFGAFALKANI()
	{
		ABEOKKAHHNF = KBJEOEEOEFG;
		StartCoroutine("SquadRank");
	}

	private IEnumerator PKAIHGNHMDA()
	{
		LJBGEMAJIPN lJBGEMAJIPN = new LJBGEMAJIPN();
		lJBGEMAJIPN.BJGCPDNMHDH = this;
		return lJBGEMAJIPN;
	}
}
