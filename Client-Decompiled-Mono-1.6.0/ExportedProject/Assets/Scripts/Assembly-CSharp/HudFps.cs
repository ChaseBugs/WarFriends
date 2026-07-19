using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

internal class HudFps : MonoBehaviour
{
	private sealed class PFCEHPBADKG : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal HudFps BJGCPDNMHDH;

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
		private object JEPCFCNIOGH()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void GEEKOICFEIB()
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
			case 1u:
				BJGCPDNMHDH.NPEMPJIDALP();
				PHDOCKCBJOF = new WaitForSeconds(0.333f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return false;
			}
		}

		public bool DDLMLOJGJMA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				BJGCPDNMHDH.DGIFOIKMOLA();
				PHDOCKCBJOF = new WaitForSeconds(10f);
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
		private object PIPMONHGDPH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CIGHIOCACPH()
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

		[DebuggerHidden]
		public PFCEHPBADKG()
		{
		}
	}

	private UILabel FKLKLCBOMNE;

	private void NIMLNHLFAKB()
	{
	}

	private IEnumerator FJAKHMICJPC()
	{
		PFCEHPBADKG pFCEHPBADKG = new PFCEHPBADKG();
		pFCEHPBADKG.BJGCPDNMHDH = this;
		return pFCEHPBADKG;
	}

	private void GGNGJIFLPDA()
	{
	}

	private void EJNJCILPBEC()
	{
		FKLKLCBOMNE = GetComponent<UILabel>();
		DebugSettings.instance.Changed += IDCICNBENDP;
	}

	private void JDPDEKENPLD()
	{
		FKLKLCBOMNE = GetComponent<UILabel>();
		DebugSettings.instance.Changed += ANFNFGLOBNB;
	}

	private void IOKMAFLIJEG()
	{
		FKLKLCBOMNE = GetComponent<UILabel>();
		DebugSettings.instance.Changed += JAFNJEBPJIC;
	}

	private void MNLFDPJFIOL()
	{
		StartCoroutine(FJAKHMICJPC());
		FKLKLCBOMNE.text = string.Empty;
	}

	private void IDCICNBENDP()
	{
	}

	private IEnumerator JIMEAKEEOCN()
	{
		PFCEHPBADKG pFCEHPBADKG = new PFCEHPBADKG();
		pFCEHPBADKG.BJGCPDNMHDH = this;
		return pFCEHPBADKG;
	}

	private void ANFNFGLOBNB()
	{
	}

	private void OnEnable()
	{
		StartCoroutine(CCHOOIGIAOK());
		FKLKLCBOMNE.text = string.Empty;
	}

	private void HOCCEMOAENF()
	{
		StartCoroutine(GEGLEJBPDBJ());
		FKLKLCBOMNE.text = string.Empty;
	}

	private void FGOAPPLNMKL()
	{
		FKLKLCBOMNE = GetComponent<UILabel>();
		DebugSettings.instance.Changed += ALLKANAJCBJ;
	}

	private IEnumerator IMOEDJFAHHA()
	{
		PFCEHPBADKG pFCEHPBADKG = new PFCEHPBADKG();
		pFCEHPBADKG.BJGCPDNMHDH = this;
		return pFCEHPBADKG;
	}

	private void CIGLDDGDAPM()
	{
		FKLKLCBOMNE = GetComponent<UILabel>();
		DebugSettings.instance.Changed += DHHLBEBLPHK;
	}

	private void OLBEOPKDEBJ()
	{
		FKLKLCBOMNE = GetComponent<UILabel>();
		DebugSettings.instance.Changed += LNJMOMODKPK;
	}

	private void DAPFGNMPCOK()
	{
		StartCoroutine(ANGMMHAIKPP());
		FKLKLCBOMNE.text = string.Empty;
	}

	private void HNHCFBIMIFF()
	{
	}

	private void HMOEHPBFECG()
	{
		FKLKLCBOMNE = GetComponent<UILabel>();
		DebugSettings.instance.Changed += ANFNFGLOBNB;
	}

	private void JECAHGGGJOA()
	{
	}

	private void OIKLJGMKMAE()
	{
		FKLKLCBOMNE = GetComponent<UILabel>();
		DebugSettings.instance.Changed += JAFNJEBPJIC;
	}

	private void BDCKIKFECEH()
	{
		StartCoroutine(ANGMMHAIKPP());
		FKLKLCBOMNE.text = string.Empty;
	}

	private void JAFNJEBPJIC()
	{
	}

	private void ALLKANAJCBJ()
	{
	}

	private void KEAOHHIKOGC()
	{
	}

	private void FANDCCNILLD()
	{
		FKLKLCBOMNE = GetComponent<UILabel>();
		DebugSettings.instance.Changed += GGNGJIFLPDA;
	}

	private void DGIFOIKMOLA()
	{
	}

	private void JIJKJCHMKAM()
	{
		StartCoroutine(PGJANAIGKGP());
		FKLKLCBOMNE.text = string.Empty;
	}

	private void MELAMCKHAGF()
	{
	}

	private void DHHLBEBLPHK()
	{
	}

	private void PCDHCIDJJOB()
	{
		FKLKLCBOMNE = GetComponent<UILabel>();
		DebugSettings.instance.Changed += IJCEHNPDCEO;
	}

	private void MLBAFICPECE()
	{
		FKLKLCBOMNE = GetComponent<UILabel>();
		DebugSettings.instance.Changed += HNHCFBIMIFF;
	}

	[DebuggerHidden]
	private IEnumerator CCHOOIGIAOK()
	{
		PFCEHPBADKG pFCEHPBADKG = new PFCEHPBADKG();
		pFCEHPBADKG.BJGCPDNMHDH = this;
		return pFCEHPBADKG;
	}

	private void MPGMPOKIENC()
	{
	}

	private void KINHAJCDKGN()
	{
		FKLKLCBOMNE = GetComponent<UILabel>();
		DebugSettings.instance.Changed += IJCEHNPDCEO;
	}

	private IEnumerator ANGMMHAIKPP()
	{
		PFCEHPBADKG pFCEHPBADKG = new PFCEHPBADKG();
		pFCEHPBADKG.BJGCPDNMHDH = this;
		return pFCEHPBADKG;
	}

	private IEnumerator NAAPJMNFAGB()
	{
		PFCEHPBADKG pFCEHPBADKG = new PFCEHPBADKG();
		pFCEHPBADKG.BJGCPDNMHDH = this;
		return pFCEHPBADKG;
	}

	private void MPLAGOGPBLB()
	{
	}

	private IEnumerator HCBMPJDLGBG()
	{
		PFCEHPBADKG pFCEHPBADKG = new PFCEHPBADKG();
		pFCEHPBADKG.BJGCPDNMHDH = this;
		return pFCEHPBADKG;
	}

	private void KDLEFBDAHJI()
	{
	}

	private void PKJLOOOIJCC()
	{
		StartCoroutine(FJAKHMICJPC());
		FKLKLCBOMNE.text = string.Empty;
	}

	private void OENFPFDKDLP()
	{
	}

	private void BACJPKBJNIB()
	{
		FKLKLCBOMNE = GetComponent<UILabel>();
		DebugSettings.instance.Changed += IDCICNBENDP;
	}

	private void ADGENMCFHOM()
	{
		StartCoroutine(HCBMPJDLGBG());
		FKLKLCBOMNE.text = string.Empty;
	}

	private void Awake()
	{
		FKLKLCBOMNE = GetComponent<UILabel>();
		DebugSettings.instance.Changed += NMAJALHCKIP;
	}

	private IEnumerator PEJEJJOOACE()
	{
		PFCEHPBADKG pFCEHPBADKG = new PFCEHPBADKG();
		pFCEHPBADKG.BJGCPDNMHDH = this;
		return pFCEHPBADKG;
	}

	private void NPEMPJIDALP()
	{
	}

	private void PIIFEPFCOJF()
	{
		FKLKLCBOMNE = GetComponent<UILabel>();
		DebugSettings.instance.Changed += HNHCFBIMIFF;
	}

	private void EKMGFCBEPID()
	{
		StartCoroutine(IMOEDJFAHHA());
		FKLKLCBOMNE.text = string.Empty;
	}

	private IEnumerator GEGLEJBPDBJ()
	{
		PFCEHPBADKG pFCEHPBADKG = new PFCEHPBADKG();
		pFCEHPBADKG.BJGCPDNMHDH = this;
		return pFCEHPBADKG;
	}

	private void OAHBEJNNNAB()
	{
		StartCoroutine(GEGLEJBPDBJ());
		FKLKLCBOMNE.text = string.Empty;
	}

	private void KFFGFHOLKML()
	{
	}

	private void IJCEHNPDCEO()
	{
	}

	private void NMAJALHCKIP()
	{
	}

	private IEnumerator PEAGDOIBABI()
	{
		PFCEHPBADKG pFCEHPBADKG = new PFCEHPBADKG();
		pFCEHPBADKG.BJGCPDNMHDH = this;
		return pFCEHPBADKG;
	}

	private void KOJDGOBMEOO()
	{
		StartCoroutine(CCHOOIGIAOK());
		FKLKLCBOMNE.text = string.Empty;
	}

	private void GMDAMPOFBAI()
	{
	}

	private IEnumerator PGJANAIGKGP()
	{
		PFCEHPBADKG pFCEHPBADKG = new PFCEHPBADKG();
		pFCEHPBADKG.BJGCPDNMHDH = this;
		return pFCEHPBADKG;
	}

	private void OJPECELKONI()
	{
		StartCoroutine(GEGLEJBPDBJ());
		FKLKLCBOMNE.text = string.Empty;
	}

	private IEnumerator EHJPBMMIMDO()
	{
		PFCEHPBADKG pFCEHPBADKG = new PFCEHPBADKG();
		pFCEHPBADKG.BJGCPDNMHDH = this;
		return pFCEHPBADKG;
	}

	private void IGKJMKFPCJB()
	{
	}

	private void LNJMOMODKPK()
	{
	}
}
