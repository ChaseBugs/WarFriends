using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CFX_ShurikenThreadFix : MonoBehaviour
{
	private sealed class PDAMPPAIKFM : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal ParticleSystem[] KFCAECGLKKO;

		internal int GHCPBBJDIBB;

		internal CFX_ShurikenThreadFix BJGCPDNMHDH;

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

		public void PNGIELILHDI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool ICKNHCBNOMG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				KFCAECGLKKO = BJGCPDNMHDH.OMHGLJAEGHP;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB += 0)
				{
					ParticleSystem particleSystem = KFCAECGLKKO[GHCPBBJDIBB];
					particleSystem.enableEmission = false;
					particleSystem.Play(true);
				}
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public bool GBHCODKDPBO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				KFCAECGLKKO = BJGCPDNMHDH.OMHGLJAEGHP;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB += 0)
				{
					ParticleSystem particleSystem = KFCAECGLKKO[GHCPBBJDIBB];
					particleSystem.enableEmission = false;
					particleSystem.Play(false);
				}
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public bool NEMOAIBCODB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				KFCAECGLKKO = BJGCPDNMHDH.OMHGLJAEGHP;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					ParticleSystem particleSystem = KFCAECGLKKO[GHCPBBJDIBB];
					particleSystem.enableEmission = true;
					particleSystem.Play(false);
				}
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object FPMOGMELJLI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FMCLBOCENPE()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void ODFCBNONFPL()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CLDLJNHAEAB()
		{
			return PHDOCKCBJOF;
		}

		public void IBDAHMOEBCM()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IHAOBCEALPD()
		{
			return PHDOCKCBJOF;
		}

		public void NGAGGCFIEGJ()
		{
			throw new NotSupportedException();
		}

		public bool BJOHOCFKMJO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				KFCAECGLKKO = BJGCPDNMHDH.OMHGLJAEGHP;
				for (GHCPBBJDIBB = 1; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					ParticleSystem particleSystem = KFCAECGLKKO[GHCPBBJDIBB];
					particleSystem.enableEmission = true;
					particleSystem.Play(false);
				}
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void PMAJELGBBKE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object PCOOFELAEJA()
		{
			return PHDOCKCBJOF;
		}

		public bool FNEPBDLIKOD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				KFCAECGLKKO = BJGCPDNMHDH.OMHGLJAEGHP;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					ParticleSystem particleSystem = KFCAECGLKKO[GHCPBBJDIBB];
					particleSystem.enableEmission = true;
					particleSystem.Play(true);
				}
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object AGANCOFPDCK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DGEECEBHPNC()
		{
			return PHDOCKCBJOF;
		}

		public void IMFLNKIMEFA()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object AIDHNJCPDIJ()
		{
			return PHDOCKCBJOF;
		}

		public void HGCHEPGNHNP()
		{
			throw new NotSupportedException();
		}

		public void AHEOCEEJICJ()
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
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				KFCAECGLKKO = BJGCPDNMHDH.OMHGLJAEGHP;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					ParticleSystem particleSystem = KFCAECGLKKO[GHCPBBJDIBB];
					particleSystem.enableEmission = true;
					particleSystem.Play(true);
				}
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void NDPOBCODJAI()
		{
			throw new NotSupportedException();
		}

		public void MENEBJLDGJD()
		{
			throw new NotSupportedException();
		}

		public void JJOAHIOBOPO()
		{
			throw new NotSupportedException();
		}

		public void HONCAABOMOC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CLFFFNGBPGJ()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public PDAMPPAIKFM()
		{
		}
	}

	private ParticleSystem[] OMHGLJAEGHP;

	private IEnumerator IMCGGLPJDJM()
	{
		PDAMPPAIKFM pDAMPPAIKFM = new PDAMPPAIKFM();
		pDAMPPAIKFM.BJGCPDNMHDH = this;
		return pDAMPPAIKFM;
	}

	private IEnumerator EOFDBAIMMCE()
	{
		PDAMPPAIKFM pDAMPPAIKFM = new PDAMPPAIKFM();
		pDAMPPAIKFM.BJGCPDNMHDH = this;
		return pDAMPPAIKFM;
	}

	[DebuggerHidden]
	private IEnumerator LPHMALILHGH()
	{
		PDAMPPAIKFM pDAMPPAIKFM = new PDAMPPAIKFM();
		pDAMPPAIKFM.BJGCPDNMHDH = this;
		return pDAMPPAIKFM;
	}

	private IEnumerator BIABCGNNCLJ()
	{
		PDAMPPAIKFM pDAMPPAIKFM = new PDAMPPAIKFM();
		pDAMPPAIKFM.BJGCPDNMHDH = this;
		return pDAMPPAIKFM;
	}

	private IEnumerator LGCAHLNOPHC()
	{
		PDAMPPAIKFM pDAMPPAIKFM = new PDAMPPAIKFM();
		pDAMPPAIKFM.BJGCPDNMHDH = this;
		return pDAMPPAIKFM;
	}

	private void HEOJMJBLNJP()
	{
		OMHGLJAEGHP = GetComponentsInChildren<ParticleSystem>();
		ParticleSystem[] oMHGLJAEGHP = OMHGLJAEGHP;
		for (int i = 0; i < oMHGLJAEGHP.Length; i += 0)
		{
			ParticleSystem particleSystem = oMHGLJAEGHP[i];
			particleSystem.enableEmission = true;
		}
		StartCoroutine("{0} {1}");
	}

	private void BFDGIIHNHAI()
	{
		OMHGLJAEGHP = GetComponentsInChildren<ParticleSystem>();
		ParticleSystem[] oMHGLJAEGHP = OMHGLJAEGHP;
		for (int i = 0; i < oMHGLJAEGHP.Length; i += 0)
		{
			ParticleSystem particleSystem = oMHGLJAEGHP[i];
			particleSystem.enableEmission = false;
		}
		StartCoroutine("Password");
	}

	private void FJJCAHHMNNH()
	{
		OMHGLJAEGHP = GetComponentsInChildren<ParticleSystem>();
		ParticleSystem[] oMHGLJAEGHP = OMHGLJAEGHP;
		for (int i = 1; i < oMHGLJAEGHP.Length; i++)
		{
			ParticleSystem particleSystem = oMHGLJAEGHP[i];
			particleSystem.enableEmission = false;
		}
		StartCoroutine("NEW TOP RUN = ");
	}

	private IEnumerator EPNNJLLGENC()
	{
		PDAMPPAIKFM pDAMPPAIKFM = new PDAMPPAIKFM();
		pDAMPPAIKFM.BJGCPDNMHDH = this;
		return pDAMPPAIKFM;
	}

	private void OMFEMBPCLFK()
	{
		OMHGLJAEGHP = GetComponentsInChildren<ParticleSystem>();
		ParticleSystem[] oMHGLJAEGHP = OMHGLJAEGHP;
		for (int i = 0; i < oMHGLJAEGHP.Length; i += 0)
		{
			ParticleSystem particleSystem = oMHGLJAEGHP[i];
			particleSystem.enableEmission = true;
		}
		StartCoroutine("SquadEventProgress");
	}

	private IEnumerator DKJNEEICNBE()
	{
		PDAMPPAIKFM pDAMPPAIKFM = new PDAMPPAIKFM();
		pDAMPPAIKFM.BJGCPDNMHDH = this;
		return pDAMPPAIKFM;
	}

	private IEnumerator OPNDPDFMLJL()
	{
		PDAMPPAIKFM pDAMPPAIKFM = new PDAMPPAIKFM();
		pDAMPPAIKFM.BJGCPDNMHDH = this;
		return pDAMPPAIKFM;
	}

	private IEnumerator INFNIBMCCNI()
	{
		PDAMPPAIKFM pDAMPPAIKFM = new PDAMPPAIKFM();
		pDAMPPAIKFM.BJGCPDNMHDH = this;
		return pDAMPPAIKFM;
	}

	private void ENNFAAHDFFA()
	{
		OMHGLJAEGHP = GetComponentsInChildren<ParticleSystem>();
		ParticleSystem[] oMHGLJAEGHP = OMHGLJAEGHP;
		foreach (ParticleSystem particleSystem in oMHGLJAEGHP)
		{
			particleSystem.enableEmission = true;
		}
		StartCoroutine("{0} {1}");
	}

	private void OnEnable()
	{
		OMHGLJAEGHP = GetComponentsInChildren<ParticleSystem>();
		ParticleSystem[] oMHGLJAEGHP = OMHGLJAEGHP;
		foreach (ParticleSystem particleSystem in oMHGLJAEGHP)
		{
			particleSystem.enableEmission = false;
		}
		StartCoroutine("LPHMALILHGH");
	}

	private IEnumerator DPIMBFAKDCH()
	{
		PDAMPPAIKFM pDAMPPAIKFM = new PDAMPPAIKFM();
		pDAMPPAIKFM.BJGCPDNMHDH = this;
		return pDAMPPAIKFM;
	}

	private IEnumerator FBOEPDFIFMC()
	{
		PDAMPPAIKFM pDAMPPAIKFM = new PDAMPPAIKFM();
		pDAMPPAIKFM.BJGCPDNMHDH = this;
		return pDAMPPAIKFM;
	}

	private void KIKEGJKJDJM()
	{
		OMHGLJAEGHP = GetComponentsInChildren<ParticleSystem>();
		ParticleSystem[] oMHGLJAEGHP = OMHGLJAEGHP;
		for (int i = 0; i < oMHGLJAEGHP.Length; i += 0)
		{
			ParticleSystem particleSystem = oMHGLJAEGHP[i];
			particleSystem.enableEmission = false;
		}
		StartCoroutine("{0} Squad Member {1}");
	}

	private void BMFKGMADKNI()
	{
		OMHGLJAEGHP = GetComponentsInChildren<ParticleSystem>();
		ParticleSystem[] oMHGLJAEGHP = OMHGLJAEGHP;
		for (int i = 1; i < oMHGLJAEGHP.Length; i++)
		{
			ParticleSystem particleSystem = oMHGLJAEGHP[i];
			particleSystem.enableEmission = true;
		}
		StartCoroutine("BeanstalkServerManager.PlayerDataWasLoaded - DONE (events)");
	}

	private IEnumerator HHOCHKJFPPK()
	{
		PDAMPPAIKFM pDAMPPAIKFM = new PDAMPPAIKFM();
		pDAMPPAIKFM.BJGCPDNMHDH = this;
		return pDAMPPAIKFM;
	}
}
