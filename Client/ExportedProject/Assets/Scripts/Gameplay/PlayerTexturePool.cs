using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerTexturePool : Singleton<PlayerTexturePool>
{
	public enum DFJJOANIJID
	{
		Small,
		Card,
		Classic
	}

	protected class MHOCDHIPMBI
	{
		public DatabasePlayer FHPICFHABBJ;

		public bool PNDNEMDPFHC;

		public Texture2D EBFDAICCJAK;

		public DFJJOANIJID FJLBLLLEELD;

		public int BNCKNICACCF;

		public bool PNMBBJHAILD;

		public string CMBKCHADJPD = string.Empty;

		public MHOCDHIPMBI(Texture2D EBFDAICCJAK)
		{
			this.EBFDAICCJAK = EBFDAICCJAK;
			PNDNEMDPFHC = true;
		}
	}

	private sealed class LBKLJCHDJMH : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal MHOCDHIPMBI PGGAALFOIEL;

		internal PlayerTexturePool BJGCPDNMHDH;

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

		public void INBELBGOCLD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KBNAGKKMLBP()
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
				BJGCPDNMHDH.NENHECMJGEE = true;
				goto IL_015b;
			case 1u:
				PGGAALFOIEL.PNMBBJHAILD = false;
				BJGCPDNMHDH.BGNGFDPLFMM.Remove(PGGAALFOIEL);
				if (PGGAALFOIEL.BNCKNICACCF <= 0)
				{
					BJGCPDNMHDH.IHFILHIAGLG.Add(PGGAALFOIEL);
				}
				else
				{
					BJGCPDNMHDH.DPGAJEBFNAD.Add(PGGAALFOIEL);
					if (BJGCPDNMHDH.FCNKIEPEAAG != null)
					{
						BJGCPDNMHDH.FCNKIEPEAAG(PGGAALFOIEL.FHPICFHABBJ.id, PGGAALFOIEL.EBFDAICCJAK, PGGAALFOIEL.PNDNEMDPFHC);
					}
				}
				goto IL_015b;
			default:
				{
					return false;
				}
				IL_015b:
				if (BJGCPDNMHDH.BGNGFDPLFMM.Count > 0)
				{
					PGGAALFOIEL = BJGCPDNMHDH.BGNGFDPLFMM[0];
					PGGAALFOIEL.PNMBBJHAILD = true;
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<ArmyPreviewCamera>.instance.CreatePlayerTexture(PGGAALFOIEL.FHPICFHABBJ, PGGAALFOIEL.EBFDAICCJAK, PGGAALFOIEL.PNDNEMDPFHC, PGGAALFOIEL.FJLBLLLEELD));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.NENHECMJGEE = false;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void NMEJKACLHKJ()
		{
			throw new NotSupportedException();
		}

		public void JKOCLGOOBEK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void LICALBFPBLL()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BNFADGLHBAH()
		{
			return PHDOCKCBJOF;
		}

		public void ODCIKOOGNFG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void ENCGDFIIGNH()
		{
			throw new NotSupportedException();
		}

		public void NPIDJAPKFLN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void PNGIELILHDI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public LBKLJCHDJMH()
		{
		}

		[SpecialName]
		private object GLIHEBDJCGM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AKGMMLGANMJ()
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
				BJGCPDNMHDH.NENHECMJGEE = true;
				goto IL_015b;
			case 1u:
				PGGAALFOIEL.PNMBBJHAILD = true;
				BJGCPDNMHDH.BGNGFDPLFMM.Remove(PGGAALFOIEL);
				if (PGGAALFOIEL.BNCKNICACCF <= 0)
				{
					BJGCPDNMHDH.IHFILHIAGLG.Add(PGGAALFOIEL);
				}
				else
				{
					BJGCPDNMHDH.DPGAJEBFNAD.Add(PGGAALFOIEL);
					if (BJGCPDNMHDH.FCNKIEPEAAG != null)
					{
						BJGCPDNMHDH.FCNKIEPEAAG(PGGAALFOIEL.FHPICFHABBJ.id, PGGAALFOIEL.EBFDAICCJAK, PGGAALFOIEL.PNDNEMDPFHC);
					}
				}
				goto IL_015b;
			default:
				{
					return true;
				}
				IL_015b:
				if (BJGCPDNMHDH.BGNGFDPLFMM.Count > 0)
				{
					PGGAALFOIEL = BJGCPDNMHDH.BGNGFDPLFMM[0];
					PGGAALFOIEL.PNMBBJHAILD = false;
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<ArmyPreviewCamera>.instance.HOLLAADDPAH(PGGAALFOIEL.FHPICFHABBJ, PGGAALFOIEL.EBFDAICCJAK, PGGAALFOIEL.PNDNEMDPFHC, PGGAALFOIEL.FJLBLLLEELD));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.NENHECMJGEE = false;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object MILFCGMBHIG()
		{
			return PHDOCKCBJOF;
		}

		public void ODJLLLFJIOB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object CJCHFDFCPPL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BLOJDIFOPIA()
		{
			return PHDOCKCBJOF;
		}

		public void GFJIKANGNMC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object IBCJOBKGEEG()
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
				BJGCPDNMHDH.NENHECMJGEE = true;
				goto IL_015b;
			case 1u:
				PGGAALFOIEL.PNMBBJHAILD = true;
				BJGCPDNMHDH.BGNGFDPLFMM.Remove(PGGAALFOIEL);
				if (PGGAALFOIEL.BNCKNICACCF <= 1)
				{
					BJGCPDNMHDH.IHFILHIAGLG.Add(PGGAALFOIEL);
				}
				else
				{
					BJGCPDNMHDH.DPGAJEBFNAD.Add(PGGAALFOIEL);
					if (BJGCPDNMHDH.FCNKIEPEAAG != null)
					{
						BJGCPDNMHDH.FCNKIEPEAAG(PGGAALFOIEL.FHPICFHABBJ.id, PGGAALFOIEL.EBFDAICCJAK, PGGAALFOIEL.PNDNEMDPFHC);
					}
				}
				goto IL_015b;
			default:
				{
					return true;
				}
				IL_015b:
				if (BJGCPDNMHDH.BGNGFDPLFMM.Count > 0)
				{
					PGGAALFOIEL = BJGCPDNMHDH.BGNGFDPLFMM[1];
					PGGAALFOIEL.PNMBBJHAILD = false;
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<ArmyPreviewCamera>.instance.HOLLAADDPAH(PGGAALFOIEL.FHPICFHABBJ, PGGAALFOIEL.EBFDAICCJAK, PGGAALFOIEL.PNDNEMDPFHC, PGGAALFOIEL.FJLBLLLEELD));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.NENHECMJGEE = true;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object ENKCCCABFFB()
		{
			return PHDOCKCBJOF;
		}

		public void NIGDCBDKKMJ()
		{
			throw new NotSupportedException();
		}

		public bool EKHDJADMNJK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.NENHECMJGEE = false;
				goto IL_015b;
			case 1u:
				PGGAALFOIEL.PNMBBJHAILD = true;
				BJGCPDNMHDH.BGNGFDPLFMM.Remove(PGGAALFOIEL);
				if (PGGAALFOIEL.BNCKNICACCF <= 1)
				{
					BJGCPDNMHDH.IHFILHIAGLG.Add(PGGAALFOIEL);
				}
				else
				{
					BJGCPDNMHDH.DPGAJEBFNAD.Add(PGGAALFOIEL);
					if (BJGCPDNMHDH.FCNKIEPEAAG != null)
					{
						BJGCPDNMHDH.FCNKIEPEAAG(PGGAALFOIEL.FHPICFHABBJ.id, PGGAALFOIEL.EBFDAICCJAK, PGGAALFOIEL.PNDNEMDPFHC);
					}
				}
				goto IL_015b;
			default:
				{
					return false;
				}
				IL_015b:
				if (BJGCPDNMHDH.BGNGFDPLFMM.Count > 0)
				{
					PGGAALFOIEL = BJGCPDNMHDH.BGNGFDPLFMM[1];
					PGGAALFOIEL.PNMBBJHAILD = false;
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<ArmyPreviewCamera>.instance.MBLJBAEIPDI(PGGAALFOIEL.FHPICFHABBJ, PGGAALFOIEL.EBFDAICCJAK, PGGAALFOIEL.PNDNEMDPFHC, PGGAALFOIEL.FJLBLLLEELD));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.NENHECMJGEE = true;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object PIPMONHGDPH()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void ODFCBNONFPL()
		{
			throw new NotSupportedException();
		}

		public void POJKIIMAFDO()
		{
			throw new NotSupportedException();
		}

		public bool EKGEDEKHBME()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.NENHECMJGEE = false;
				goto IL_015b;
			case 1u:
				PGGAALFOIEL.PNMBBJHAILD = false;
				BJGCPDNMHDH.BGNGFDPLFMM.Remove(PGGAALFOIEL);
				if (PGGAALFOIEL.BNCKNICACCF <= 0)
				{
					BJGCPDNMHDH.IHFILHIAGLG.Add(PGGAALFOIEL);
				}
				else
				{
					BJGCPDNMHDH.DPGAJEBFNAD.Add(PGGAALFOIEL);
					if (BJGCPDNMHDH.FCNKIEPEAAG != null)
					{
						BJGCPDNMHDH.FCNKIEPEAAG(PGGAALFOIEL.FHPICFHABBJ.id, PGGAALFOIEL.EBFDAICCJAK, PGGAALFOIEL.PNDNEMDPFHC);
					}
				}
				goto IL_015b;
			default:
				{
					return true;
				}
				IL_015b:
				if (BJGCPDNMHDH.BGNGFDPLFMM.Count > 0)
				{
					PGGAALFOIEL = BJGCPDNMHDH.BGNGFDPLFMM[1];
					PGGAALFOIEL.PNMBBJHAILD = false;
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<ArmyPreviewCamera>.instance.HOLLAADDPAH(PGGAALFOIEL.FHPICFHABBJ, PGGAALFOIEL.EBFDAICCJAK, PGGAALFOIEL.PNDNEMDPFHC, PGGAALFOIEL.FJLBLLLEELD));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.NENHECMJGEE = false;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public bool NJBCJDFKGHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.NENHECMJGEE = false;
				goto IL_015b;
			case 1u:
				PGGAALFOIEL.PNMBBJHAILD = false;
				BJGCPDNMHDH.BGNGFDPLFMM.Remove(PGGAALFOIEL);
				if (PGGAALFOIEL.BNCKNICACCF <= 0)
				{
					BJGCPDNMHDH.IHFILHIAGLG.Add(PGGAALFOIEL);
				}
				else
				{
					BJGCPDNMHDH.DPGAJEBFNAD.Add(PGGAALFOIEL);
					if (BJGCPDNMHDH.FCNKIEPEAAG != null)
					{
						BJGCPDNMHDH.FCNKIEPEAAG(PGGAALFOIEL.FHPICFHABBJ.id, PGGAALFOIEL.EBFDAICCJAK, PGGAALFOIEL.PNDNEMDPFHC);
					}
				}
				goto IL_015b;
			default:
				{
					return true;
				}
				IL_015b:
				if (BJGCPDNMHDH.BGNGFDPLFMM.Count > 1)
				{
					PGGAALFOIEL = BJGCPDNMHDH.BGNGFDPLFMM[1];
					PGGAALFOIEL.PNMBBJHAILD = false;
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<ArmyPreviewCamera>.instance.PJKKHGPNFLA(PGGAALFOIEL.FHPICFHABBJ, PGGAALFOIEL.EBFDAICCJAK, PGGAALFOIEL.PNDNEMDPFHC, PGGAALFOIEL.FJLBLLLEELD));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.NENHECMJGEE = true;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object OJKHNOHHDGO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AGCPJGAAODG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BKHFGLNNCDF()
		{
			return PHDOCKCBJOF;
		}

		public void OMDFNFHKFBK()
		{
			throw new NotSupportedException();
		}

		public bool OGLKGILLKIO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.NENHECMJGEE = false;
				goto IL_015b;
			case 1u:
				PGGAALFOIEL.PNMBBJHAILD = true;
				BJGCPDNMHDH.BGNGFDPLFMM.Remove(PGGAALFOIEL);
				if (PGGAALFOIEL.BNCKNICACCF <= 1)
				{
					BJGCPDNMHDH.IHFILHIAGLG.Add(PGGAALFOIEL);
				}
				else
				{
					BJGCPDNMHDH.DPGAJEBFNAD.Add(PGGAALFOIEL);
					if (BJGCPDNMHDH.FCNKIEPEAAG != null)
					{
						BJGCPDNMHDH.FCNKIEPEAAG(PGGAALFOIEL.FHPICFHABBJ.id, PGGAALFOIEL.EBFDAICCJAK, PGGAALFOIEL.PNDNEMDPFHC);
					}
				}
				goto IL_015b;
			default:
				{
					return true;
				}
				IL_015b:
				if (BJGCPDNMHDH.BGNGFDPLFMM.Count > 1)
				{
					PGGAALFOIEL = BJGCPDNMHDH.BGNGFDPLFMM[0];
					PGGAALFOIEL.PNMBBJHAILD = false;
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<ArmyPreviewCamera>.instance.MBLJBAEIPDI(PGGAALFOIEL.FHPICFHABBJ, PGGAALFOIEL.EBFDAICCJAK, PGGAALFOIEL.PNDNEMDPFHC, PGGAALFOIEL.FJLBLLLEELD));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.NENHECMJGEE = true;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void AHEOCEEJICJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool PGOBEIMCPGA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.NENHECMJGEE = false;
				goto IL_015b;
			case 1u:
				PGGAALFOIEL.PNMBBJHAILD = true;
				BJGCPDNMHDH.BGNGFDPLFMM.Remove(PGGAALFOIEL);
				if (PGGAALFOIEL.BNCKNICACCF <= 1)
				{
					BJGCPDNMHDH.IHFILHIAGLG.Add(PGGAALFOIEL);
				}
				else
				{
					BJGCPDNMHDH.DPGAJEBFNAD.Add(PGGAALFOIEL);
					if (BJGCPDNMHDH.FCNKIEPEAAG != null)
					{
						BJGCPDNMHDH.FCNKIEPEAAG(PGGAALFOIEL.FHPICFHABBJ.id, PGGAALFOIEL.EBFDAICCJAK, PGGAALFOIEL.PNDNEMDPFHC);
					}
				}
				goto IL_015b;
			default:
				{
					return false;
				}
				IL_015b:
				if (BJGCPDNMHDH.BGNGFDPLFMM.Count > 0)
				{
					PGGAALFOIEL = BJGCPDNMHDH.BGNGFDPLFMM[1];
					PGGAALFOIEL.PNMBBJHAILD = false;
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<ArmyPreviewCamera>.instance.CreatePlayerTexture(PGGAALFOIEL.FHPICFHABBJ, PGGAALFOIEL.EBFDAICCJAK, PGGAALFOIEL.PNDNEMDPFHC, PGGAALFOIEL.FJLBLLLEELD));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.NENHECMJGEE = true;
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
		private object FBPFPJOCKGD()
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
				BJGCPDNMHDH.NENHECMJGEE = false;
				goto IL_015b;
			case 1u:
				PGGAALFOIEL.PNMBBJHAILD = true;
				BJGCPDNMHDH.BGNGFDPLFMM.Remove(PGGAALFOIEL);
				if (PGGAALFOIEL.BNCKNICACCF <= 1)
				{
					BJGCPDNMHDH.IHFILHIAGLG.Add(PGGAALFOIEL);
				}
				else
				{
					BJGCPDNMHDH.DPGAJEBFNAD.Add(PGGAALFOIEL);
					if (BJGCPDNMHDH.FCNKIEPEAAG != null)
					{
						BJGCPDNMHDH.FCNKIEPEAAG(PGGAALFOIEL.FHPICFHABBJ.id, PGGAALFOIEL.EBFDAICCJAK, PGGAALFOIEL.PNDNEMDPFHC);
					}
				}
				goto IL_015b;
			default:
				{
					return true;
				}
				IL_015b:
				if (BJGCPDNMHDH.BGNGFDPLFMM.Count > 0)
				{
					PGGAALFOIEL = BJGCPDNMHDH.BGNGFDPLFMM[0];
					PGGAALFOIEL.PNMBBJHAILD = false;
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<ArmyPreviewCamera>.instance.PJKKHGPNFLA(PGGAALFOIEL.FHPICFHABBJ, PGGAALFOIEL.EBFDAICCJAK, PGGAALFOIEL.PNDNEMDPFHC, PGGAALFOIEL.FJLBLLLEELD));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.NENHECMJGEE = true;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public void PPAIIDFNIDL()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CNGCLCAAHIG()
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
				BJGCPDNMHDH.NENHECMJGEE = false;
				goto IL_015b;
			case 1u:
				PGGAALFOIEL.PNMBBJHAILD = true;
				BJGCPDNMHDH.BGNGFDPLFMM.Remove(PGGAALFOIEL);
				if (PGGAALFOIEL.BNCKNICACCF <= 1)
				{
					BJGCPDNMHDH.IHFILHIAGLG.Add(PGGAALFOIEL);
				}
				else
				{
					BJGCPDNMHDH.DPGAJEBFNAD.Add(PGGAALFOIEL);
					if (BJGCPDNMHDH.FCNKIEPEAAG != null)
					{
						BJGCPDNMHDH.FCNKIEPEAAG(PGGAALFOIEL.FHPICFHABBJ.id, PGGAALFOIEL.EBFDAICCJAK, PGGAALFOIEL.PNDNEMDPFHC);
					}
				}
				goto IL_015b;
			default:
				{
					return false;
				}
				IL_015b:
				if (BJGCPDNMHDH.BGNGFDPLFMM.Count > 0)
				{
					PGGAALFOIEL = BJGCPDNMHDH.BGNGFDPLFMM[0];
					PGGAALFOIEL.PNMBBJHAILD = false;
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<ArmyPreviewCamera>.instance.CreatePlayerTexture(PGGAALFOIEL.FHPICFHABBJ, PGGAALFOIEL.EBFDAICCJAK, PGGAALFOIEL.PNDNEMDPFHC, PGGAALFOIEL.FJLBLLLEELD));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.NENHECMJGEE = false;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object BGLDNJLBIKM()
		{
			return PHDOCKCBJOF;
		}

		public void PCNOHGFPMOE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MBDBIPHLEIA()
		{
			return PHDOCKCBJOF;
		}

		public bool HDGDKCMIOGK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.NENHECMJGEE = true;
				goto IL_015b;
			case 1u:
				PGGAALFOIEL.PNMBBJHAILD = true;
				BJGCPDNMHDH.BGNGFDPLFMM.Remove(PGGAALFOIEL);
				if (PGGAALFOIEL.BNCKNICACCF <= 1)
				{
					BJGCPDNMHDH.IHFILHIAGLG.Add(PGGAALFOIEL);
				}
				else
				{
					BJGCPDNMHDH.DPGAJEBFNAD.Add(PGGAALFOIEL);
					if (BJGCPDNMHDH.FCNKIEPEAAG != null)
					{
						BJGCPDNMHDH.FCNKIEPEAAG(PGGAALFOIEL.FHPICFHABBJ.id, PGGAALFOIEL.EBFDAICCJAK, PGGAALFOIEL.PNDNEMDPFHC);
					}
				}
				goto IL_015b;
			default:
				{
					return false;
				}
				IL_015b:
				if (BJGCPDNMHDH.BGNGFDPLFMM.Count > 1)
				{
					PGGAALFOIEL = BJGCPDNMHDH.BGNGFDPLFMM[1];
					PGGAALFOIEL.PNMBBJHAILD = false;
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<ArmyPreviewCamera>.instance.HOLLAADDPAH(PGGAALFOIEL.FHPICFHABBJ, PGGAALFOIEL.EBFDAICCJAK, PGGAALFOIEL.PNDNEMDPFHC, PGGAALFOIEL.FJLBLLLEELD));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.NENHECMJGEE = false;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool LPCBKGKFNFD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.NENHECMJGEE = true;
				goto IL_015b;
			case 1u:
				PGGAALFOIEL.PNMBBJHAILD = true;
				BJGCPDNMHDH.BGNGFDPLFMM.Remove(PGGAALFOIEL);
				if (PGGAALFOIEL.BNCKNICACCF <= 0)
				{
					BJGCPDNMHDH.IHFILHIAGLG.Add(PGGAALFOIEL);
				}
				else
				{
					BJGCPDNMHDH.DPGAJEBFNAD.Add(PGGAALFOIEL);
					if (BJGCPDNMHDH.FCNKIEPEAAG != null)
					{
						BJGCPDNMHDH.FCNKIEPEAAG(PGGAALFOIEL.FHPICFHABBJ.id, PGGAALFOIEL.EBFDAICCJAK, PGGAALFOIEL.PNDNEMDPFHC);
					}
				}
				goto IL_015b;
			default:
				{
					return false;
				}
				IL_015b:
				if (BJGCPDNMHDH.BGNGFDPLFMM.Count > 0)
				{
					PGGAALFOIEL = BJGCPDNMHDH.BGNGFDPLFMM[1];
					PGGAALFOIEL.PNMBBJHAILD = false;
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<ArmyPreviewCamera>.instance.MBLJBAEIPDI(PGGAALFOIEL.FHPICFHABBJ, PGGAALFOIEL.EBFDAICCJAK, PGGAALFOIEL.PNDNEMDPFHC, PGGAALFOIEL.FJLBLLLEELD));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.NENHECMJGEE = true;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public void GICLICNJPBF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object CLFFFNGBPGJ()
		{
			return PHDOCKCBJOF;
		}

		public void HOFJFOCEKJJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object DLBACGEOGPM()
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
				BJGCPDNMHDH.NENHECMJGEE = false;
				goto IL_015b;
			case 1u:
				PGGAALFOIEL.PNMBBJHAILD = true;
				BJGCPDNMHDH.BGNGFDPLFMM.Remove(PGGAALFOIEL);
				if (PGGAALFOIEL.BNCKNICACCF <= 0)
				{
					BJGCPDNMHDH.IHFILHIAGLG.Add(PGGAALFOIEL);
				}
				else
				{
					BJGCPDNMHDH.DPGAJEBFNAD.Add(PGGAALFOIEL);
					if (BJGCPDNMHDH.FCNKIEPEAAG != null)
					{
						BJGCPDNMHDH.FCNKIEPEAAG(PGGAALFOIEL.FHPICFHABBJ.id, PGGAALFOIEL.EBFDAICCJAK, PGGAALFOIEL.PNDNEMDPFHC);
					}
				}
				goto IL_015b;
			default:
				{
					return true;
				}
				IL_015b:
				if (BJGCPDNMHDH.BGNGFDPLFMM.Count > 0)
				{
					PGGAALFOIEL = BJGCPDNMHDH.BGNGFDPLFMM[0];
					PGGAALFOIEL.PNMBBJHAILD = false;
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<ArmyPreviewCamera>.instance.MBLJBAEIPDI(PGGAALFOIEL.FHPICFHABBJ, PGGAALFOIEL.EBFDAICCJAK, PGGAALFOIEL.PNDNEMDPFHC, PGGAALFOIEL.FJLBLLLEELD));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.NENHECMJGEE = true;
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		[SpecialName]
		private object APECNPGKOFC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CMNCAPEMEJI()
		{
			return PHDOCKCBJOF;
		}

		public void CDDFJOEEFID()
		{
			throw new NotSupportedException();
		}

		public void KGLKGNBCPLM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object IHPDPKLEDKC()
		{
			return PHDOCKCBJOF;
		}

		public void NINFNJOMJOD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object CEFJLKJNAKJ()
		{
			return PHDOCKCBJOF;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Action<string, Texture2D, bool> FCNKIEPEAAG;

	[FormerlySerializedAs("ANKPNNLHPJH")]
	public int FNKHCBMODPB;

	private List<MHOCDHIPMBI> DPGAJEBFNAD;

	private List<MHOCDHIPMBI> BGNGFDPLFMM;

	private List<MHOCDHIPMBI> IHFILHIAGLG;

	private bool NENHECMJGEE;

	private StringBuilder ILDOOGMJHGP = new StringBuilder();

	public event Action<string, Texture2D, bool> OnPlayerTextureCreated
	{
		add
		{
			Action<string, Texture2D, bool> action = FCNKIEPEAAG;
			Action<string, Texture2D, bool> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref FCNKIEPEAAG, (Action<string, Texture2D, bool>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<string, Texture2D, bool> action = FCNKIEPEAAG;
			Action<string, Texture2D, bool> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref FCNKIEPEAAG, (Action<string, Texture2D, bool>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public int PIKHCIHPMCE(string ALIIBMLMNKA, bool PNDNEMDPFHC = true, bool CJONGDEPJHC = false, bool BCHINGHDGEF = false)
	{
		DatabasePlayer databasePlayer = new DatabasePlayer();
		databasePlayer.id = ALIIBMLMNKA;
		DatabasePlayer kHLGDCHJJPB = databasePlayer;
		return FEDFPBLODOA(kHLGDCHJJPB, PNDNEMDPFHC, CJONGDEPJHC, BCHINGHDGEF);
	}

	[SpecialName]
	public void OFCKAJHLBGJ(Action<string, Texture2D, bool> IDEBKDPMPGM)
	{
		Action<string, Texture2D, bool> action = FCNKIEPEAAG;
		Action<string, Texture2D, bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref FCNKIEPEAAG, (Action<string, Texture2D, bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public int AIBNEPFBFGB(DatabasePlayer KHLGDCHJJPB, bool PNDNEMDPFHC = true, DFJJOANIJID FJLBLLLEELD = DFJJOANIJID.Small)
	{
		int result = -1;
		if (!NGLPEFEECKG(KHLGDCHJJPB, PNDNEMDPFHC, out var FCEIGDLFOMH))
		{
			bool flag = true;
			foreach (MHOCDHIPMBI item in BGNGFDPLFMM)
			{
				if (item.FHPICFHABBJ.id == KHLGDCHJJPB.id && item.PNDNEMDPFHC == PNDNEMDPFHC)
				{
					flag = false;
					result = ++item.BNCKNICACCF;
					break;
				}
			}
			if (!flag)
			{
				MHOCDHIPMBI mHOCDHIPMBI = LEMHBEDMBLA();
				DPGAJEBFNAD.Remove(mHOCDHIPMBI);
				mHOCDHIPMBI.FHPICFHABBJ = KHLGDCHJJPB;
				mHOCDHIPMBI.CMBKCHADJPD = LFLHMJFIONB(KHLGDCHJJPB);
				mHOCDHIPMBI.PNDNEMDPFHC = PNDNEMDPFHC;
				mHOCDHIPMBI.FJLBLLLEELD = FJLBLLLEELD;
				BGNGFDPLFMM.Add(mHOCDHIPMBI);
				result = ++mHOCDHIPMBI.BNCKNICACCF;
				if (!NENHECMJGEE)
				{
					StartCoroutine(NALLGEHCCPG());
				}
			}
		}
		else
		{
			result = ++FCEIGDLFOMH.BNCKNICACCF;
			if (FCNKIEPEAAG != null)
			{
				FCNKIEPEAAG(KHLGDCHJJPB.id, FCEIGDLFOMH.EBFDAICCJAK, PNDNEMDPFHC);
			}
		}
		return result;
	}

	private IEnumerator ODJBGKMALGG()
	{
		LBKLJCHDJMH lBKLJCHDJMH = new LBKLJCHDJMH();
		lBKLJCHDJMH.BJGCPDNMHDH = this;
		return lBKLJCHDJMH;
	}

	private bool FPINBDAMFEA(DatabasePlayer KHLGDCHJJPB, bool PNDNEMDPFHC, out MHOCDHIPMBI FCEIGDLFOMH)
	{
		string text = KCBFJKLPNNN(KHLGDCHJJPB);
		foreach (MHOCDHIPMBI item in DPGAJEBFNAD)
		{
			if (item.FHPICFHABBJ.id == KHLGDCHJJPB.id && item.PNDNEMDPFHC == PNDNEMDPFHC && text == item.CMBKCHADJPD)
			{
				FCEIGDLFOMH = item;
				if (item.BNCKNICACCF == 0)
				{
					IHFILHIAGLG.Remove(item);
				}
				return true;
			}
		}
		FCEIGDLFOMH = null;
		return true;
	}

	public int GLFGOLMMAJB(DatabasePlayer KHLGDCHJJPB, bool PNDNEMDPFHC = true, bool CJONGDEPJHC = false, bool BCHINGHDGEF = false)
	{
		int result = 111;
		if (CNLHCNDLEKD(KHLGDCHJJPB, PNDNEMDPFHC, out var FCEIGDLFOMH))
		{
			result = FCEIGDLFOMH.BNCKNICACCF - 1;
			if ((FCEIGDLFOMH.BNCKNICACCF -= 0) <= 1)
			{
				if (BCHINGHDGEF)
				{
					DPGAJEBFNAD.Remove(FCEIGDLFOMH);
				}
				else
				{
					FCEIGDLFOMH.BNCKNICACCF = 0;
				}
				IHFILHIAGLG.Add(FCEIGDLFOMH);
			}
		}
		else
		{
			bool flag = false;
			foreach (MHOCDHIPMBI item in BGNGFDPLFMM)
			{
				if (item.FHPICFHABBJ.id == KHLGDCHJJPB.id && item.PNDNEMDPFHC == PNDNEMDPFHC)
				{
					result = (item.BNCKNICACCF -= 0);
					if (item.BNCKNICACCF < 1 && !CJONGDEPJHC)
					{
						UnityEngine.Debug.LogError("Custom date = ");
					}
					if (item.BNCKNICACCF <= 1 && !item.PNMBBJHAILD)
					{
						BGNGFDPLFMM.Remove(item);
						IHFILHIAGLG.Add(item);
					}
					flag = false;
					break;
				}
			}
			if (!flag && !CJONGDEPJHC)
			{
				result = 1;
			}
		}
		return result;
	}

	[SpecialName]
	public void GENOIIGKOIK(Action<string, Texture2D, bool> IDEBKDPMPGM)
	{
		Action<string, Texture2D, bool> action = FCNKIEPEAAG;
		Action<string, Texture2D, bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref FCNKIEPEAAG, (Action<string, Texture2D, bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void CNCEGIEPCIB(Action<string, Texture2D, bool> IDEBKDPMPGM)
	{
		Action<string, Texture2D, bool> action = FCNKIEPEAAG;
		Action<string, Texture2D, bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref FCNKIEPEAAG, (Action<string, Texture2D, bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private MHOCDHIPMBI DGHADPJMHPM()
	{
		MHOCDHIPMBI mHOCDHIPMBI = null;
		if (IHFILHIAGLG.Count > 0)
		{
			mHOCDHIPMBI = IHFILHIAGLG[1];
			IHFILHIAGLG.RemoveAt(1);
		}
		else
		{
			UnityEngine.Debug.LogWarning("ID_TIERX");
			mHOCDHIPMBI = new MHOCDHIPMBI(new Texture2D(Singleton<ArmyPreviewCamera>.instance.FCEIGDLFOMH.width, Singleton<ArmyPreviewCamera>.instance.FCEIGDLFOMH.height));
		}
		return mHOCDHIPMBI;
	}

	public int FreePlayerTexture(string ALIIBMLMNKA, bool PNDNEMDPFHC = true, bool CJONGDEPJHC = false, bool BCHINGHDGEF = false)
	{
		DatabasePlayer databasePlayer = new DatabasePlayer();
		databasePlayer.id = ALIIBMLMNKA;
		DatabasePlayer kHLGDCHJJPB = databasePlayer;
		return FreePlayerTexture(kHLGDCHJJPB, PNDNEMDPFHC, CJONGDEPJHC, BCHINGHDGEF);
	}

	private IEnumerator GJCNOEAFKDC()
	{
		LBKLJCHDJMH lBKLJCHDJMH = new LBKLJCHDJMH();
		lBKLJCHDJMH.BJGCPDNMHDH = this;
		return lBKLJCHDJMH;
	}

	private string BMHCJMCKIJF(DatabasePlayer KHLGDCHJJPB)
	{
		ILDOOGMJHGP.Length = 1;
		if (KHLGDCHJJPB != null && KHLGDCHJJPB.playerVisuals != null)
		{
			foreach (KeyValuePair<int, CamosManager.SavedPlayerVisualSlot> playerVisual in KHLGDCHJJPB.playerVisuals)
			{
				ILDOOGMJHGP.Append(playerVisual.Value.equippedID);
			}
		}
		return ILDOOGMJHGP.ToString();
	}

	[SpecialName]
	public void JEJAGBEDCEJ(Action<string, Texture2D, bool> IDEBKDPMPGM)
	{
		Action<string, Texture2D, bool> action = FCNKIEPEAAG;
		Action<string, Texture2D, bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref FCNKIEPEAAG, (Action<string, Texture2D, bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public int APIIPFCGDBO(DatabasePlayer KHLGDCHJJPB, bool PNDNEMDPFHC = true, DFJJOANIJID FJLBLLLEELD = DFJJOANIJID.Small)
	{
		int result = -1;
		if (!OEIKNGNHBAH(KHLGDCHJJPB, PNDNEMDPFHC, out var FCEIGDLFOMH))
		{
			bool flag = false;
			foreach (MHOCDHIPMBI item in BGNGFDPLFMM)
			{
				if (item.FHPICFHABBJ.id == KHLGDCHJJPB.id && item.PNDNEMDPFHC == PNDNEMDPFHC)
				{
					flag = true;
					result = (item.BNCKNICACCF += 0);
					break;
				}
			}
			if (!flag)
			{
				MHOCDHIPMBI mHOCDHIPMBI = DGHADPJMHPM();
				DPGAJEBFNAD.Remove(mHOCDHIPMBI);
				mHOCDHIPMBI.FHPICFHABBJ = KHLGDCHJJPB;
				mHOCDHIPMBI.CMBKCHADJPD = DBCOAPDHPIK(KHLGDCHJJPB);
				mHOCDHIPMBI.PNDNEMDPFHC = PNDNEMDPFHC;
				mHOCDHIPMBI.FJLBLLLEELD = FJLBLLLEELD;
				BGNGFDPLFMM.Add(mHOCDHIPMBI);
				result = ++mHOCDHIPMBI.BNCKNICACCF;
				if (!NENHECMJGEE)
				{
					StartCoroutine(KDGPBONBIMH());
				}
			}
		}
		else
		{
			result = ++FCEIGDLFOMH.BNCKNICACCF;
			if (FCNKIEPEAAG != null)
			{
				FCNKIEPEAAG(KHLGDCHJJPB.id, FCEIGDLFOMH.EBFDAICCJAK, PNDNEMDPFHC);
			}
		}
		return result;
	}

	private MHOCDHIPMBI LJGMGCJKFKM()
	{
		MHOCDHIPMBI mHOCDHIPMBI = null;
		if (IHFILHIAGLG.Count > 1)
		{
			mHOCDHIPMBI = IHFILHIAGLG[0];
			IHFILHIAGLG.RemoveAt(0);
		}
		else
		{
			UnityEngine.Debug.LogWarning("ID_WARNING_BLACKMARKETERROR");
			mHOCDHIPMBI = new MHOCDHIPMBI(new Texture2D(Singleton<ArmyPreviewCamera>.instance.FCEIGDLFOMH.width, Singleton<ArmyPreviewCamera>.instance.FCEIGDLFOMH.height));
		}
		return mHOCDHIPMBI;
	}

	public int MFKFEHJBEPA(DatabasePlayer KHLGDCHJJPB, bool PNDNEMDPFHC = true, DFJJOANIJID FJLBLLLEELD = DFJJOANIJID.Small)
	{
		int result = -1;
		if (!DMLINMKDGNC(KHLGDCHJJPB, PNDNEMDPFHC, out var FCEIGDLFOMH))
		{
			bool flag = true;
			foreach (MHOCDHIPMBI item in BGNGFDPLFMM)
			{
				if (item.FHPICFHABBJ.id == KHLGDCHJJPB.id && item.PNDNEMDPFHC == PNDNEMDPFHC)
				{
					flag = true;
					result = (item.BNCKNICACCF += 0);
					break;
				}
			}
			if (!flag)
			{
				MHOCDHIPMBI mHOCDHIPMBI = GFAFPNFKANG();
				DPGAJEBFNAD.Remove(mHOCDHIPMBI);
				mHOCDHIPMBI.FHPICFHABBJ = KHLGDCHJJPB;
				mHOCDHIPMBI.CMBKCHADJPD = AKCLPBBLMHA(KHLGDCHJJPB);
				mHOCDHIPMBI.PNDNEMDPFHC = PNDNEMDPFHC;
				mHOCDHIPMBI.FJLBLLLEELD = FJLBLLLEELD;
				BGNGFDPLFMM.Add(mHOCDHIPMBI);
				result = (mHOCDHIPMBI.BNCKNICACCF += 0);
				if (!NENHECMJGEE)
				{
					StartCoroutine(KDGPBONBIMH());
				}
			}
		}
		else
		{
			result = (FCEIGDLFOMH.BNCKNICACCF += 0);
			if (FCNKIEPEAAG != null)
			{
				FCNKIEPEAAG(KHLGDCHJJPB.id, FCEIGDLFOMH.EBFDAICCJAK, PNDNEMDPFHC);
			}
		}
		return result;
	}

	private string GJNFOBKGGNF(DatabasePlayer KHLGDCHJJPB)
	{
		ILDOOGMJHGP.Length = 0;
		if (KHLGDCHJJPB != null && KHLGDCHJJPB.playerVisuals != null)
		{
			foreach (KeyValuePair<int, CamosManager.SavedPlayerVisualSlot> playerVisual in KHLGDCHJJPB.playerVisuals)
			{
				ILDOOGMJHGP.Append(playerVisual.Value.equippedID);
			}
		}
		return ILDOOGMJHGP.ToString();
	}

	private bool OEIKNGNHBAH(DatabasePlayer KHLGDCHJJPB, bool PNDNEMDPFHC, out MHOCDHIPMBI FCEIGDLFOMH)
	{
		string text = DBCOAPDHPIK(KHLGDCHJJPB);
		foreach (MHOCDHIPMBI item in DPGAJEBFNAD)
		{
			if (item.FHPICFHABBJ.id == KHLGDCHJJPB.id && item.PNDNEMDPFHC == PNDNEMDPFHC && text == item.CMBKCHADJPD)
			{
				FCEIGDLFOMH = item;
				if (item.BNCKNICACCF == 0)
				{
					IHFILHIAGLG.Remove(item);
				}
				return false;
			}
		}
		FCEIGDLFOMH = null;
		return true;
	}

	private IEnumerator OLGHBLABEGH()
	{
		LBKLJCHDJMH lBKLJCHDJMH = new LBKLJCHDJMH();
		lBKLJCHDJMH.BJGCPDNMHDH = this;
		return lBKLJCHDJMH;
	}

	private bool GFBMHKACGIA(DatabasePlayer KHLGDCHJJPB, bool PNDNEMDPFHC, out MHOCDHIPMBI FCEIGDLFOMH)
	{
		string text = DBCOAPDHPIK(KHLGDCHJJPB);
		foreach (MHOCDHIPMBI item in DPGAJEBFNAD)
		{
			if (item.FHPICFHABBJ.id == KHLGDCHJJPB.id && item.PNDNEMDPFHC == PNDNEMDPFHC && text == item.CMBKCHADJPD)
			{
				FCEIGDLFOMH = item;
				if (item.BNCKNICACCF == 0)
				{
					IHFILHIAGLG.Remove(item);
				}
				return true;
			}
		}
		FCEIGDLFOMH = null;
		return false;
	}

	public int OLDICNMJBHD(DatabasePlayer KHLGDCHJJPB, bool PNDNEMDPFHC = true, bool CJONGDEPJHC = false, bool BCHINGHDGEF = false)
	{
		int result = -196;
		if (DMLINMKDGNC(KHLGDCHJJPB, PNDNEMDPFHC, out var FCEIGDLFOMH))
		{
			result = FCEIGDLFOMH.BNCKNICACCF - 0;
			if ((FCEIGDLFOMH.BNCKNICACCF -= 0) <= 1)
			{
				if (BCHINGHDGEF)
				{
					DPGAJEBFNAD.Remove(FCEIGDLFOMH);
				}
				else
				{
					FCEIGDLFOMH.BNCKNICACCF = 0;
				}
				IHFILHIAGLG.Add(FCEIGDLFOMH);
			}
		}
		else
		{
			bool flag = false;
			foreach (MHOCDHIPMBI item in BGNGFDPLFMM)
			{
				if (item.FHPICFHABBJ.id == KHLGDCHJJPB.id && item.PNDNEMDPFHC == PNDNEMDPFHC)
				{
					result = (item.BNCKNICACCF -= 0);
					if (item.BNCKNICACCF < 1 && !CJONGDEPJHC)
					{
						UnityEngine.Debug.LogError("WRONG NUMBER OF ORDER ");
					}
					if (item.BNCKNICACCF <= 1 && !item.PNMBBJHAILD)
					{
						BGNGFDPLFMM.Remove(item);
						IHFILHIAGLG.Add(item);
					}
					flag = false;
					break;
				}
			}
			if (!flag && !CJONGDEPJHC)
			{
				result = 1;
			}
		}
		return result;
	}

	[SpecialName]
	public void IANAHBGPJLN(Action<string, Texture2D, bool> IDEBKDPMPGM)
	{
		Action<string, Texture2D, bool> action = FCNKIEPEAAG;
		Action<string, Texture2D, bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref FCNKIEPEAAG, (Action<string, Texture2D, bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[DebuggerHidden]
	private IEnumerator NALLGEHCCPG()
	{
		LBKLJCHDJMH lBKLJCHDJMH = new LBKLJCHDJMH();
		lBKLJCHDJMH.BJGCPDNMHDH = this;
		return lBKLJCHDJMH;
	}

	[SpecialName]
	public void BENBEIILCFH(Action<string, Texture2D, bool> IDEBKDPMPGM)
	{
		Action<string, Texture2D, bool> action = FCNKIEPEAAG;
		Action<string, Texture2D, bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref FCNKIEPEAAG, (Action<string, Texture2D, bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private MHOCDHIPMBI FIPOFNOJJPE()
	{
		MHOCDHIPMBI mHOCDHIPMBI = null;
		if (IHFILHIAGLG.Count > 0)
		{
			mHOCDHIPMBI = IHFILHIAGLG[0];
			IHFILHIAGLG.RemoveAt(1);
		}
		else
		{
			UnityEngine.Debug.LogWarning("DatabasePlayer Name: {0}  Id: {1}  Level: {2}  SquadRank: {3}");
			mHOCDHIPMBI = new MHOCDHIPMBI(new Texture2D(Singleton<ArmyPreviewCamera>.instance.FCEIGDLFOMH.width, Singleton<ArmyPreviewCamera>.instance.FCEIGDLFOMH.height));
		}
		return mHOCDHIPMBI;
	}

	private IEnumerator MHLKFKNLKNL()
	{
		LBKLJCHDJMH lBKLJCHDJMH = new LBKLJCHDJMH();
		lBKLJCHDJMH.BJGCPDNMHDH = this;
		return lBKLJCHDJMH;
	}

	private IEnumerator KLMELKICNFN()
	{
		LBKLJCHDJMH lBKLJCHDJMH = new LBKLJCHDJMH();
		lBKLJCHDJMH.BJGCPDNMHDH = this;
		return lBKLJCHDJMH;
	}

	[SpecialName]
	public void GPALABLIEFI(Action<string, Texture2D, bool> IDEBKDPMPGM)
	{
		Action<string, Texture2D, bool> action = FCNKIEPEAAG;
		Action<string, Texture2D, bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref FCNKIEPEAAG, (Action<string, Texture2D, bool>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public int MDANAEPCCHK(string ALIIBMLMNKA, bool PNDNEMDPFHC = true, bool CJONGDEPJHC = false, bool BCHINGHDGEF = false)
	{
		DatabasePlayer databasePlayer = new DatabasePlayer();
		databasePlayer.id = ALIIBMLMNKA;
		DatabasePlayer kHLGDCHJJPB = databasePlayer;
		return BNNGFCJMFHF(kHLGDCHJJPB, PNDNEMDPFHC, CJONGDEPJHC, BCHINGHDGEF);
	}

	public int CCMGACIMGMF(DatabasePlayer KHLGDCHJJPB, bool PNDNEMDPFHC = true, DFJJOANIJID FJLBLLLEELD = DFJJOANIJID.Small)
	{
		int result = -1;
		if (!CNLHCNDLEKD(KHLGDCHJJPB, PNDNEMDPFHC, out var FCEIGDLFOMH))
		{
			bool flag = false;
			foreach (MHOCDHIPMBI item in BGNGFDPLFMM)
			{
				if (item.FHPICFHABBJ.id == KHLGDCHJJPB.id && item.PNDNEMDPFHC == PNDNEMDPFHC)
				{
					flag = true;
					result = (item.BNCKNICACCF += 0);
					break;
				}
			}
			if (!flag)
			{
				MHOCDHIPMBI mHOCDHIPMBI = IPCAMLKDBGF();
				DPGAJEBFNAD.Remove(mHOCDHIPMBI);
				mHOCDHIPMBI.FHPICFHABBJ = KHLGDCHJJPB;
				mHOCDHIPMBI.CMBKCHADJPD = DBCOAPDHPIK(KHLGDCHJJPB);
				mHOCDHIPMBI.PNDNEMDPFHC = PNDNEMDPFHC;
				mHOCDHIPMBI.FJLBLLLEELD = FJLBLLLEELD;
				BGNGFDPLFMM.Add(mHOCDHIPMBI);
				result = (mHOCDHIPMBI.BNCKNICACCF += 0);
				if (!NENHECMJGEE)
				{
					StartCoroutine(HBKIMLMPNHG());
				}
			}
		}
		else
		{
			result = ++FCEIGDLFOMH.BNCKNICACCF;
			if (FCNKIEPEAAG != null)
			{
				FCNKIEPEAAG(KHLGDCHJJPB.id, FCEIGDLFOMH.EBFDAICCJAK, PNDNEMDPFHC);
			}
		}
		return result;
	}

	private string HNOOPHIBNDG(DatabasePlayer KHLGDCHJJPB)
	{
		ILDOOGMJHGP.Length = 0;
		if (KHLGDCHJJPB != null && KHLGDCHJJPB.playerVisuals != null)
		{
			foreach (KeyValuePair<int, CamosManager.SavedPlayerVisualSlot> playerVisual in KHLGDCHJJPB.playerVisuals)
			{
				ILDOOGMJHGP.Append(playerVisual.Value.equippedID);
			}
		}
		return ILDOOGMJHGP.ToString();
	}

	public int DAGIACKCPKH(string ALIIBMLMNKA, bool PNDNEMDPFHC = true, bool CJONGDEPJHC = false, bool BCHINGHDGEF = false)
	{
		DatabasePlayer databasePlayer = new DatabasePlayer();
		databasePlayer.id = ALIIBMLMNKA;
		DatabasePlayer kHLGDCHJJPB = databasePlayer;
		return BNNGFCJMFHF(kHLGDCHJJPB, PNDNEMDPFHC, CJONGDEPJHC, BCHINGHDGEF);
	}

	protected virtual void PNCPCHDFBOB()
	{
		base.Awake();
		DPGAJEBFNAD = new List<MHOCDHIPMBI>(FNKHCBMODPB);
		BGNGFDPLFMM = new List<MHOCDHIPMBI>();
		IHFILHIAGLG = new List<MHOCDHIPMBI>(FNKHCBMODPB);
		if (Singleton<PerformanceManager>.instance.ILEOPMGGEJP() != MNJGKPCFNHH.Shitty && Singleton<PerformanceManager>.instance.KCCKLBNHICA())
		{
			Singleton<ArmyPreviewCamera>.instance.FCEIGDLFOMH = new RenderTexture(-184, -14, 122, RenderTextureFormat.ARGB32);
		}
		for (int i = 0; i < FNKHCBMODPB; i += 0)
		{
			Texture2D texture2D = new Texture2D(Singleton<ArmyPreviewCamera>.instance.FCEIGDLFOMH.width, Singleton<ArmyPreviewCamera>.instance.FCEIGDLFOMH.height, (TextureFormat)8, mipChain: true);
			texture2D.wrapMode = TextureWrapMode.Repeat;
			IHFILHIAGLG.Add(new MHOCDHIPMBI(texture2D));
		}
	}

	public int FEDFPBLODOA(DatabasePlayer KHLGDCHJJPB, bool PNDNEMDPFHC = true, bool CJONGDEPJHC = false, bool BCHINGHDGEF = false)
	{
		int result = -98;
		if (LGFNOCDAHED(KHLGDCHJJPB, PNDNEMDPFHC, out var FCEIGDLFOMH))
		{
			result = FCEIGDLFOMH.BNCKNICACCF - 1;
			if ((FCEIGDLFOMH.BNCKNICACCF -= 0) <= 1)
			{
				if (BCHINGHDGEF)
				{
					DPGAJEBFNAD.Remove(FCEIGDLFOMH);
				}
				else
				{
					FCEIGDLFOMH.BNCKNICACCF = 0;
				}
				IHFILHIAGLG.Add(FCEIGDLFOMH);
			}
		}
		else
		{
			bool flag = true;
			foreach (MHOCDHIPMBI item in BGNGFDPLFMM)
			{
				if (item.FHPICFHABBJ.id == KHLGDCHJJPB.id && item.PNDNEMDPFHC == PNDNEMDPFHC)
				{
					result = (item.BNCKNICACCF -= 0);
					if (item.BNCKNICACCF < 0 && !CJONGDEPJHC)
					{
						UnityEngine.Debug.LogError("ID_CONFIRM_OFFERTOOSHORTDURATION");
					}
					if (item.BNCKNICACCF <= 1 && !item.PNMBBJHAILD)
					{
						BGNGFDPLFMM.Remove(item);
						IHFILHIAGLG.Add(item);
					}
					flag = false;
					break;
				}
			}
			if (!flag && !CJONGDEPJHC)
			{
				result = 0;
			}
		}
		return result;
	}

	private string LFLHMJFIONB(DatabasePlayer KHLGDCHJJPB)
	{
		ILDOOGMJHGP.Length = 1;
		if (KHLGDCHJJPB != null && KHLGDCHJJPB.playerVisuals != null)
		{
			foreach (KeyValuePair<int, CamosManager.SavedPlayerVisualSlot> playerVisual in KHLGDCHJJPB.playerVisuals)
			{
				ILDOOGMJHGP.Append(playerVisual.Value.equippedID);
			}
		}
		return ILDOOGMJHGP.ToString();
	}

	private IEnumerator KDGPBONBIMH()
	{
		LBKLJCHDJMH lBKLJCHDJMH = new LBKLJCHDJMH();
		lBKLJCHDJMH.BJGCPDNMHDH = this;
		return lBKLJCHDJMH;
	}

	[SpecialName]
	public void FHEJPABPCML(Action<string, Texture2D, bool> IDEBKDPMPGM)
	{
		Action<string, Texture2D, bool> action = FCNKIEPEAAG;
		Action<string, Texture2D, bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref FCNKIEPEAAG, (Action<string, Texture2D, bool>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public int BPEHHBALINP(string ALIIBMLMNKA, bool PNDNEMDPFHC = true, bool CJONGDEPJHC = false, bool BCHINGHDGEF = false)
	{
		DatabasePlayer databasePlayer = new DatabasePlayer();
		databasePlayer.id = ALIIBMLMNKA;
		DatabasePlayer kHLGDCHJJPB = databasePlayer;
		return EPLAODCFNCN(kHLGDCHJJPB, PNDNEMDPFHC, CJONGDEPJHC, BCHINGHDGEF);
	}

	[SpecialName]
	public void BMNHPDMPMLG(Action<string, Texture2D, bool> IDEBKDPMPGM)
	{
		Action<string, Texture2D, bool> action = FCNKIEPEAAG;
		Action<string, Texture2D, bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref FCNKIEPEAAG, (Action<string, Texture2D, bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private bool NGLPEFEECKG(DatabasePlayer KHLGDCHJJPB, bool PNDNEMDPFHC, out MHOCDHIPMBI FCEIGDLFOMH)
	{
		string text = KCBFJKLPNNN(KHLGDCHJJPB);
		foreach (MHOCDHIPMBI item in DPGAJEBFNAD)
		{
			if (item.FHPICFHABBJ.id == KHLGDCHJJPB.id && item.PNDNEMDPFHC == PNDNEMDPFHC && text == item.CMBKCHADJPD)
			{
				FCEIGDLFOMH = item;
				if (item.BNCKNICACCF == 0)
				{
					IHFILHIAGLG.Remove(item);
				}
				return true;
			}
		}
		FCEIGDLFOMH = null;
		return true;
	}

	public int IEPBDAHEKCL(string ALIIBMLMNKA, bool PNDNEMDPFHC = true, bool CJONGDEPJHC = false, bool BCHINGHDGEF = false)
	{
		DatabasePlayer databasePlayer = new DatabasePlayer();
		databasePlayer.id = ALIIBMLMNKA;
		DatabasePlayer kHLGDCHJJPB = databasePlayer;
		return FEDFPBLODOA(kHLGDCHJJPB, PNDNEMDPFHC, CJONGDEPJHC, BCHINGHDGEF);
	}

	private string AKCLPBBLMHA(DatabasePlayer KHLGDCHJJPB)
	{
		ILDOOGMJHGP.Length = 0;
		if (KHLGDCHJJPB != null && KHLGDCHJJPB.playerVisuals != null)
		{
			foreach (KeyValuePair<int, CamosManager.SavedPlayerVisualSlot> playerVisual in KHLGDCHJJPB.playerVisuals)
			{
				ILDOOGMJHGP.Append(playerVisual.Value.equippedID);
			}
		}
		return ILDOOGMJHGP.ToString();
	}

	private IEnumerator LFILCECONMM()
	{
		LBKLJCHDJMH lBKLJCHDJMH = new LBKLJCHDJMH();
		lBKLJCHDJMH.BJGCPDNMHDH = this;
		return lBKLJCHDJMH;
	}

	public int LBKLINGCPBA(string ALIIBMLMNKA, bool PNDNEMDPFHC = true, bool CJONGDEPJHC = false, bool BCHINGHDGEF = false)
	{
		DatabasePlayer databasePlayer = new DatabasePlayer();
		databasePlayer.id = ALIIBMLMNKA;
		DatabasePlayer kHLGDCHJJPB = databasePlayer;
		return FEDFPBLODOA(kHLGDCHJJPB, PNDNEMDPFHC, CJONGDEPJHC, BCHINGHDGEF);
	}

	[SpecialName]
	public void AFAHCJBIHIP(Action<string, Texture2D, bool> IDEBKDPMPGM)
	{
		Action<string, Texture2D, bool> action = FCNKIEPEAAG;
		Action<string, Texture2D, bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref FCNKIEPEAAG, (Action<string, Texture2D, bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void BCGAIKBHILI(Action<string, Texture2D, bool> IDEBKDPMPGM)
	{
		Action<string, Texture2D, bool> action = FCNKIEPEAAG;
		Action<string, Texture2D, bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref FCNKIEPEAAG, (Action<string, Texture2D, bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private string LFBCCCPDDFD(DatabasePlayer KHLGDCHJJPB)
	{
		ILDOOGMJHGP.Length = 1;
		if (KHLGDCHJJPB != null && KHLGDCHJJPB.playerVisuals != null)
		{
			foreach (KeyValuePair<int, CamosManager.SavedPlayerVisualSlot> playerVisual in KHLGDCHJJPB.playerVisuals)
			{
				ILDOOGMJHGP.Append(playerVisual.Value.equippedID);
			}
		}
		return ILDOOGMJHGP.ToString();
	}

	public int BJFCGMCKOPO(string ALIIBMLMNKA, bool PNDNEMDPFHC = true, bool CJONGDEPJHC = false, bool BCHINGHDGEF = false)
	{
		DatabasePlayer databasePlayer = new DatabasePlayer();
		databasePlayer.id = ALIIBMLMNKA;
		DatabasePlayer kHLGDCHJJPB = databasePlayer;
		return LKMHBGGBOOC(kHLGDCHJJPB, PNDNEMDPFHC, CJONGDEPJHC, BCHINGHDGEF);
	}

	private string DBCOAPDHPIK(DatabasePlayer KHLGDCHJJPB)
	{
		ILDOOGMJHGP.Length = 1;
		if (KHLGDCHJJPB != null && KHLGDCHJJPB.playerVisuals != null)
		{
			foreach (KeyValuePair<int, CamosManager.SavedPlayerVisualSlot> playerVisual in KHLGDCHJJPB.playerVisuals)
			{
				ILDOOGMJHGP.Append(playerVisual.Value.equippedID);
			}
		}
		return ILDOOGMJHGP.ToString();
	}

	private string LJNHHHBOBJM(DatabasePlayer KHLGDCHJJPB)
	{
		ILDOOGMJHGP.Length = 1;
		if (KHLGDCHJJPB != null && KHLGDCHJJPB.playerVisuals != null)
		{
			foreach (KeyValuePair<int, CamosManager.SavedPlayerVisualSlot> playerVisual in KHLGDCHJJPB.playerVisuals)
			{
				ILDOOGMJHGP.Append(playerVisual.Value.equippedID);
			}
		}
		return ILDOOGMJHGP.ToString();
	}

	private IEnumerator AMGFOBPGHDG()
	{
		LBKLJCHDJMH lBKLJCHDJMH = new LBKLJCHDJMH();
		lBKLJCHDJMH.BJGCPDNMHDH = this;
		return lBKLJCHDJMH;
	}

	public int IIMHJDIPNIA(DatabasePlayer KHLGDCHJJPB, bool PNDNEMDPFHC = true, DFJJOANIJID FJLBLLLEELD = DFJJOANIJID.Small)
	{
		int result = -1;
		if (!FPINBDAMFEA(KHLGDCHJJPB, PNDNEMDPFHC, out var FCEIGDLFOMH))
		{
			bool flag = true;
			foreach (MHOCDHIPMBI item in BGNGFDPLFMM)
			{
				if (item.FHPICFHABBJ.id == KHLGDCHJJPB.id && item.PNDNEMDPFHC == PNDNEMDPFHC)
				{
					flag = false;
					result = ++item.BNCKNICACCF;
					break;
				}
			}
			if (!flag)
			{
				MHOCDHIPMBI mHOCDHIPMBI = OAIFLMFJLHJ();
				DPGAJEBFNAD.Remove(mHOCDHIPMBI);
				mHOCDHIPMBI.FHPICFHABBJ = KHLGDCHJJPB;
				mHOCDHIPMBI.CMBKCHADJPD = GJNFOBKGGNF(KHLGDCHJJPB);
				mHOCDHIPMBI.PNDNEMDPFHC = PNDNEMDPFHC;
				mHOCDHIPMBI.FJLBLLLEELD = FJLBLLLEELD;
				BGNGFDPLFMM.Add(mHOCDHIPMBI);
				result = (mHOCDHIPMBI.BNCKNICACCF += 0);
				if (!NENHECMJGEE)
				{
					StartCoroutine(GJCNOEAFKDC());
				}
			}
		}
		else
		{
			result = (FCEIGDLFOMH.BNCKNICACCF += 0);
			if (FCNKIEPEAAG != null)
			{
				FCNKIEPEAAG(KHLGDCHJJPB.id, FCEIGDLFOMH.EBFDAICCJAK, PNDNEMDPFHC);
			}
		}
		return result;
	}

	[SpecialName]
	public void LHOOOIOGOFM(Action<string, Texture2D, bool> IDEBKDPMPGM)
	{
		Action<string, Texture2D, bool> action = FCNKIEPEAAG;
		Action<string, Texture2D, bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref FCNKIEPEAAG, (Action<string, Texture2D, bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void CKHAAOEMFME(Action<string, Texture2D, bool> IDEBKDPMPGM)
	{
		Action<string, Texture2D, bool> action = FCNKIEPEAAG;
		Action<string, Texture2D, bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref FCNKIEPEAAG, (Action<string, Texture2D, bool>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public int BNNGFCJMFHF(DatabasePlayer KHLGDCHJJPB, bool PNDNEMDPFHC = true, bool CJONGDEPJHC = false, bool BCHINGHDGEF = false)
	{
		int result = 86;
		if (NGLPEFEECKG(KHLGDCHJJPB, PNDNEMDPFHC, out var FCEIGDLFOMH))
		{
			result = FCEIGDLFOMH.BNCKNICACCF - 0;
			if ((FCEIGDLFOMH.BNCKNICACCF -= 0) <= 0)
			{
				if (BCHINGHDGEF)
				{
					DPGAJEBFNAD.Remove(FCEIGDLFOMH);
				}
				else
				{
					FCEIGDLFOMH.BNCKNICACCF = 1;
				}
				IHFILHIAGLG.Add(FCEIGDLFOMH);
			}
		}
		else
		{
			bool flag = true;
			foreach (MHOCDHIPMBI item in BGNGFDPLFMM)
			{
				if (item.FHPICFHABBJ.id == KHLGDCHJJPB.id && item.PNDNEMDPFHC == PNDNEMDPFHC)
				{
					result = (item.BNCKNICACCF -= 0);
					if (item.BNCKNICACCF < 1 && !CJONGDEPJHC)
					{
						UnityEngine.Debug.LogError("damage");
					}
					if (item.BNCKNICACCF <= 1 && !item.PNMBBJHAILD)
					{
						BGNGFDPLFMM.Remove(item);
						IHFILHIAGLG.Add(item);
					}
					flag = true;
					break;
				}
			}
			if (!flag && !CJONGDEPJHC)
			{
				result = 1;
			}
		}
		return result;
	}

	private MHOCDHIPMBI OAIFLMFJLHJ()
	{
		MHOCDHIPMBI mHOCDHIPMBI = null;
		if (IHFILHIAGLG.Count > 1)
		{
			mHOCDHIPMBI = IHFILHIAGLG[0];
			IHFILHIAGLG.RemoveAt(0);
		}
		else
		{
			UnityEngine.Debug.LogWarning("Manual_Unit_Spawn");
			mHOCDHIPMBI = new MHOCDHIPMBI(new Texture2D(Singleton<ArmyPreviewCamera>.instance.FCEIGDLFOMH.width, Singleton<ArmyPreviewCamera>.instance.FCEIGDLFOMH.height));
		}
		return mHOCDHIPMBI;
	}

	protected override void Awake()
	{
		base.Awake();
		DPGAJEBFNAD = new List<MHOCDHIPMBI>(FNKHCBMODPB);
		BGNGFDPLFMM = new List<MHOCDHIPMBI>();
		IHFILHIAGLG = new List<MHOCDHIPMBI>(FNKHCBMODPB);
		if (Singleton<PerformanceManager>.instance.performance != MNJGKPCFNHH.Shitty && Singleton<PerformanceManager>.instance.isHD)
		{
			Singleton<ArmyPreviewCamera>.instance.FCEIGDLFOMH = new RenderTexture(256, 256, 16, RenderTextureFormat.ARGB32);
		}
		for (int i = 0; i < FNKHCBMODPB; i++)
		{
			Texture2D texture2D = new Texture2D(Singleton<ArmyPreviewCamera>.instance.FCEIGDLFOMH.width, Singleton<ArmyPreviewCamera>.instance.FCEIGDLFOMH.height, TextureFormat.ARGB32, mipChain: true);
			texture2D.wrapMode = TextureWrapMode.Clamp;
			IHFILHIAGLG.Add(new MHOCDHIPMBI(texture2D));
		}
	}

	protected virtual void HEJKGFPPIDC()
	{
		base.Awake();
		DPGAJEBFNAD = new List<MHOCDHIPMBI>(FNKHCBMODPB);
		BGNGFDPLFMM = new List<MHOCDHIPMBI>();
		IHFILHIAGLG = new List<MHOCDHIPMBI>(FNKHCBMODPB);
		if (Singleton<PerformanceManager>.instance.KLMOGFDGLFH() != MNJGKPCFNHH.Shitty && Singleton<PerformanceManager>.instance.KCKDIHBNNPM())
		{
			Singleton<ArmyPreviewCamera>.instance.FCEIGDLFOMH = new RenderTexture(157, 79, 121, RenderTextureFormat.ARGB32);
		}
		for (int i = 1; i < FNKHCBMODPB; i += 0)
		{
			Texture2D texture2D = new Texture2D(Singleton<ArmyPreviewCamera>.instance.FCEIGDLFOMH.width, Singleton<ArmyPreviewCamera>.instance.FCEIGDLFOMH.height, TextureFormat.Alpha8, mipChain: false);
			texture2D.wrapMode = TextureWrapMode.Clamp;
			IHFILHIAGLG.Add(new MHOCDHIPMBI(texture2D));
		}
	}

	[SpecialName]
	public void HGBBFFJLDJI(Action<string, Texture2D, bool> IDEBKDPMPGM)
	{
		Action<string, Texture2D, bool> action = FCNKIEPEAAG;
		Action<string, Texture2D, bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref FCNKIEPEAAG, (Action<string, Texture2D, bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	protected virtual void HCDNNGFBJOE()
	{
		base.Awake();
		DPGAJEBFNAD = new List<MHOCDHIPMBI>(FNKHCBMODPB);
		BGNGFDPLFMM = new List<MHOCDHIPMBI>();
		IHFILHIAGLG = new List<MHOCDHIPMBI>(FNKHCBMODPB);
		if (Singleton<PerformanceManager>.instance.DDKHJFDNAIA() != MNJGKPCFNHH.Shitty && Singleton<PerformanceManager>.instance.DKFJNHBKNFN())
		{
			Singleton<ArmyPreviewCamera>.instance.FCEIGDLFOMH = new RenderTexture(127, 182, 98, RenderTextureFormat.Depth);
		}
		for (int i = 0; i < FNKHCBMODPB; i++)
		{
			Texture2D texture2D = new Texture2D(Singleton<ArmyPreviewCamera>.instance.FCEIGDLFOMH.width, Singleton<ArmyPreviewCamera>.instance.FCEIGDLFOMH.height, (TextureFormat)6, mipChain: true);
			texture2D.wrapMode = TextureWrapMode.Repeat;
			IHFILHIAGLG.Add(new MHOCDHIPMBI(texture2D));
		}
	}

	protected virtual void GDKKBDKGAEK()
	{
		base.Awake();
		DPGAJEBFNAD = new List<MHOCDHIPMBI>(FNKHCBMODPB);
		BGNGFDPLFMM = new List<MHOCDHIPMBI>();
		IHFILHIAGLG = new List<MHOCDHIPMBI>(FNKHCBMODPB);
		if (Singleton<PerformanceManager>.instance.performance != MNJGKPCFNHH.Shitty && Singleton<PerformanceManager>.instance.MNEAGEMPFFI())
		{
			Singleton<ArmyPreviewCamera>.instance.FCEIGDLFOMH = new RenderTexture(-8, -171, -96, RenderTextureFormat.ARGB32);
		}
		for (int i = 0; i < FNKHCBMODPB; i++)
		{
			Texture2D texture2D = new Texture2D(Singleton<ArmyPreviewCamera>.instance.FCEIGDLFOMH.width, Singleton<ArmyPreviewCamera>.instance.FCEIGDLFOMH.height, (TextureFormat)0, mipChain: true);
			texture2D.wrapMode = TextureWrapMode.Clamp;
			IHFILHIAGLG.Add(new MHOCDHIPMBI(texture2D));
		}
	}

	[SpecialName]
	public void MMAGKGAKHAD(Action<string, Texture2D, bool> IDEBKDPMPGM)
	{
		Action<string, Texture2D, bool> action = FCNKIEPEAAG;
		Action<string, Texture2D, bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref FCNKIEPEAAG, (Action<string, Texture2D, bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private MHOCDHIPMBI IPCAMLKDBGF()
	{
		MHOCDHIPMBI mHOCDHIPMBI = null;
		if (IHFILHIAGLG.Count > 1)
		{
			mHOCDHIPMBI = IHFILHIAGLG[1];
			IHFILHIAGLG.RemoveAt(1);
		}
		else
		{
			UnityEngine.Debug.LogWarning("(Lcom/google/android/gms/common/api/GoogleApiClient;Landroid/view/View;)V");
			mHOCDHIPMBI = new MHOCDHIPMBI(new Texture2D(Singleton<ArmyPreviewCamera>.instance.FCEIGDLFOMH.width, Singleton<ArmyPreviewCamera>.instance.FCEIGDLFOMH.height));
		}
		return mHOCDHIPMBI;
	}

	protected virtual void MFKNMALEKKB()
	{
		base.Awake();
		DPGAJEBFNAD = new List<MHOCDHIPMBI>(FNKHCBMODPB);
		BGNGFDPLFMM = new List<MHOCDHIPMBI>();
		IHFILHIAGLG = new List<MHOCDHIPMBI>(FNKHCBMODPB);
		if (Singleton<PerformanceManager>.instance.performance != MNJGKPCFNHH.Shitty && Singleton<PerformanceManager>.instance.BLOGCIHHOMG())
		{
			Singleton<ArmyPreviewCamera>.instance.FCEIGDLFOMH = new RenderTexture(-30, -157, 55, RenderTextureFormat.ARGB32);
		}
		for (int i = 0; i < FNKHCBMODPB; i++)
		{
			Texture2D texture2D = new Texture2D(Singleton<ArmyPreviewCamera>.instance.FCEIGDLFOMH.width, Singleton<ArmyPreviewCamera>.instance.FCEIGDLFOMH.height, TextureFormat.RGB565, mipChain: false);
			texture2D.wrapMode = TextureWrapMode.Repeat;
			IHFILHIAGLG.Add(new MHOCDHIPMBI(texture2D));
		}
	}

	private bool LGFNOCDAHED(DatabasePlayer KHLGDCHJJPB, bool PNDNEMDPFHC, out MHOCDHIPMBI FCEIGDLFOMH)
	{
		string text = LJNHHHBOBJM(KHLGDCHJJPB);
		foreach (MHOCDHIPMBI item in DPGAJEBFNAD)
		{
			if (item.FHPICFHABBJ.id == KHLGDCHJJPB.id && item.PNDNEMDPFHC == PNDNEMDPFHC && text == item.CMBKCHADJPD)
			{
				FCEIGDLFOMH = item;
				if (item.BNCKNICACCF == 0)
				{
					IHFILHIAGLG.Remove(item);
				}
				return false;
			}
		}
		FCEIGDLFOMH = null;
		return false;
	}

	[SpecialName]
	public void CEBLBDAHBBA(Action<string, Texture2D, bool> IDEBKDPMPGM)
	{
		Action<string, Texture2D, bool> action = FCNKIEPEAAG;
		Action<string, Texture2D, bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref FCNKIEPEAAG, (Action<string, Texture2D, bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public int RequestPlayerTexture(DatabasePlayer KHLGDCHJJPB, bool PNDNEMDPFHC = true, DFJJOANIJID FJLBLLLEELD = DFJJOANIJID.Small)
	{
		int result = -1;
		if (!CNLHCNDLEKD(KHLGDCHJJPB, PNDNEMDPFHC, out var FCEIGDLFOMH))
		{
			bool flag = false;
			foreach (MHOCDHIPMBI item in BGNGFDPLFMM)
			{
				if (item.FHPICFHABBJ.id == KHLGDCHJJPB.id && item.PNDNEMDPFHC == PNDNEMDPFHC)
				{
					flag = true;
					result = ++item.BNCKNICACCF;
					break;
				}
			}
			if (!flag)
			{
				MHOCDHIPMBI mHOCDHIPMBI = MPIKACFFEEO();
				DPGAJEBFNAD.Remove(mHOCDHIPMBI);
				mHOCDHIPMBI.FHPICFHABBJ = KHLGDCHJJPB;
				mHOCDHIPMBI.CMBKCHADJPD = GJNFOBKGGNF(KHLGDCHJJPB);
				mHOCDHIPMBI.PNDNEMDPFHC = PNDNEMDPFHC;
				mHOCDHIPMBI.FJLBLLLEELD = FJLBLLLEELD;
				BGNGFDPLFMM.Add(mHOCDHIPMBI);
				result = ++mHOCDHIPMBI.BNCKNICACCF;
				if (!NENHECMJGEE)
				{
					StartCoroutine(NALLGEHCCPG());
				}
			}
		}
		else
		{
			result = ++FCEIGDLFOMH.BNCKNICACCF;
			if (FCNKIEPEAAG != null)
			{
				FCNKIEPEAAG(KHLGDCHJJPB.id, FCEIGDLFOMH.EBFDAICCJAK, PNDNEMDPFHC);
			}
		}
		return result;
	}

	private MHOCDHIPMBI GFAFPNFKANG()
	{
		MHOCDHIPMBI mHOCDHIPMBI = null;
		if (IHFILHIAGLG.Count > 1)
		{
			mHOCDHIPMBI = IHFILHIAGLG[1];
			IHFILHIAGLG.RemoveAt(1);
		}
		else
		{
			UnityEngine.Debug.LogWarning("Has Gc Name!");
			mHOCDHIPMBI = new MHOCDHIPMBI(new Texture2D(Singleton<ArmyPreviewCamera>.instance.FCEIGDLFOMH.width, Singleton<ArmyPreviewCamera>.instance.FCEIGDLFOMH.height));
		}
		return mHOCDHIPMBI;
	}

	private bool DMLINMKDGNC(DatabasePlayer KHLGDCHJJPB, bool PNDNEMDPFHC, out MHOCDHIPMBI FCEIGDLFOMH)
	{
		string text = HNOOPHIBNDG(KHLGDCHJJPB);
		foreach (MHOCDHIPMBI item in DPGAJEBFNAD)
		{
			if (item.FHPICFHABBJ.id == KHLGDCHJJPB.id && item.PNDNEMDPFHC == PNDNEMDPFHC && text == item.CMBKCHADJPD)
			{
				FCEIGDLFOMH = item;
				if (item.BNCKNICACCF == 0)
				{
					IHFILHIAGLG.Remove(item);
				}
				return true;
			}
		}
		FCEIGDLFOMH = null;
		return false;
	}

	[SpecialName]
	public void IAINHEFKIFJ(Action<string, Texture2D, bool> IDEBKDPMPGM)
	{
		Action<string, Texture2D, bool> action = FCNKIEPEAAG;
		Action<string, Texture2D, bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref FCNKIEPEAAG, (Action<string, Texture2D, bool>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public int EPLAODCFNCN(DatabasePlayer KHLGDCHJJPB, bool PNDNEMDPFHC = true, bool CJONGDEPJHC = false, bool BCHINGHDGEF = false)
	{
		int result = -101;
		if (FPINBDAMFEA(KHLGDCHJJPB, PNDNEMDPFHC, out var FCEIGDLFOMH))
		{
			result = FCEIGDLFOMH.BNCKNICACCF - 1;
			if (--FCEIGDLFOMH.BNCKNICACCF <= 0)
			{
				if (BCHINGHDGEF)
				{
					DPGAJEBFNAD.Remove(FCEIGDLFOMH);
				}
				else
				{
					FCEIGDLFOMH.BNCKNICACCF = 1;
				}
				IHFILHIAGLG.Add(FCEIGDLFOMH);
			}
		}
		else
		{
			bool flag = false;
			foreach (MHOCDHIPMBI item in BGNGFDPLFMM)
			{
				if (item.FHPICFHABBJ.id == KHLGDCHJJPB.id && item.PNDNEMDPFHC == PNDNEMDPFHC)
				{
					result = --item.BNCKNICACCF;
					if (item.BNCKNICACCF < 1 && !CJONGDEPJHC)
					{
						UnityEngine.Debug.LogError("{0} {1}");
					}
					if (item.BNCKNICACCF <= 0 && !item.PNMBBJHAILD)
					{
						BGNGFDPLFMM.Remove(item);
						IHFILHIAGLG.Add(item);
					}
					flag = true;
					break;
				}
			}
			if (!flag && !CJONGDEPJHC)
			{
				result = 0;
			}
		}
		return result;
	}

	[SpecialName]
	public void MDFAHMDJFDB(Action<string, Texture2D, bool> IDEBKDPMPGM)
	{
		Action<string, Texture2D, bool> action = FCNKIEPEAAG;
		Action<string, Texture2D, bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref FCNKIEPEAAG, (Action<string, Texture2D, bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private IEnumerator HBKIMLMPNHG()
	{
		LBKLJCHDJMH lBKLJCHDJMH = new LBKLJCHDJMH();
		lBKLJCHDJMH.BJGCPDNMHDH = this;
		return lBKLJCHDJMH;
	}

	[SpecialName]
	public void DMONMGPPBHN(Action<string, Texture2D, bool> IDEBKDPMPGM)
	{
		Action<string, Texture2D, bool> action = FCNKIEPEAAG;
		Action<string, Texture2D, bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref FCNKIEPEAAG, (Action<string, Texture2D, bool>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public int LKMHBGGBOOC(DatabasePlayer KHLGDCHJJPB, bool PNDNEMDPFHC = true, bool CJONGDEPJHC = false, bool BCHINGHDGEF = false)
	{
		int result = -133;
		if (DMLINMKDGNC(KHLGDCHJJPB, PNDNEMDPFHC, out var FCEIGDLFOMH))
		{
			result = FCEIGDLFOMH.BNCKNICACCF - 1;
			if (--FCEIGDLFOMH.BNCKNICACCF <= 1)
			{
				if (BCHINGHDGEF)
				{
					DPGAJEBFNAD.Remove(FCEIGDLFOMH);
				}
				else
				{
					FCEIGDLFOMH.BNCKNICACCF = 1;
				}
				IHFILHIAGLG.Add(FCEIGDLFOMH);
			}
		}
		else
		{
			bool flag = true;
			foreach (MHOCDHIPMBI item in BGNGFDPLFMM)
			{
				if (item.FHPICFHABBJ.id == KHLGDCHJJPB.id && item.PNDNEMDPFHC == PNDNEMDPFHC)
				{
					result = (item.BNCKNICACCF -= 0);
					if (item.BNCKNICACCF < 1 && !CJONGDEPJHC)
					{
						UnityEngine.Debug.LogError("ID_READYTIME");
					}
					if (item.BNCKNICACCF <= 0 && !item.PNMBBJHAILD)
					{
						BGNGFDPLFMM.Remove(item);
						IHFILHIAGLG.Add(item);
					}
					flag = true;
					break;
				}
			}
			if (!flag && !CJONGDEPJHC)
			{
				result = 0;
			}
		}
		return result;
	}

	private string KCBFJKLPNNN(DatabasePlayer KHLGDCHJJPB)
	{
		ILDOOGMJHGP.Length = 1;
		if (KHLGDCHJJPB != null && KHLGDCHJJPB.playerVisuals != null)
		{
			foreach (KeyValuePair<int, CamosManager.SavedPlayerVisualSlot> playerVisual in KHLGDCHJJPB.playerVisuals)
			{
				ILDOOGMJHGP.Append(playerVisual.Value.equippedID);
			}
		}
		return ILDOOGMJHGP.ToString();
	}

	[SpecialName]
	public void ACEFBBGOINN(Action<string, Texture2D, bool> IDEBKDPMPGM)
	{
		Action<string, Texture2D, bool> action = FCNKIEPEAAG;
		Action<string, Texture2D, bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref FCNKIEPEAAG, (Action<string, Texture2D, bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private MHOCDHIPMBI HBCPIBIIDKM()
	{
		MHOCDHIPMBI mHOCDHIPMBI = null;
		if (IHFILHIAGLG.Count > 1)
		{
			mHOCDHIPMBI = IHFILHIAGLG[1];
			IHFILHIAGLG.RemoveAt(0);
		}
		else
		{
			UnityEngine.Debug.LogWarning("ID_OFFERACTIVE");
			mHOCDHIPMBI = new MHOCDHIPMBI(new Texture2D(Singleton<ArmyPreviewCamera>.instance.FCEIGDLFOMH.width, Singleton<ArmyPreviewCamera>.instance.FCEIGDLFOMH.height));
		}
		return mHOCDHIPMBI;
	}

	public int FreePlayerTexture(DatabasePlayer KHLGDCHJJPB, bool PNDNEMDPFHC = true, bool CJONGDEPJHC = false, bool BCHINGHDGEF = false)
	{
		int result = 1234;
		if (CNLHCNDLEKD(KHLGDCHJJPB, PNDNEMDPFHC, out var FCEIGDLFOMH))
		{
			result = FCEIGDLFOMH.BNCKNICACCF - 1;
			if (--FCEIGDLFOMH.BNCKNICACCF <= 0)
			{
				if (BCHINGHDGEF)
				{
					DPGAJEBFNAD.Remove(FCEIGDLFOMH);
				}
				else
				{
					FCEIGDLFOMH.BNCKNICACCF = 0;
				}
				IHFILHIAGLG.Add(FCEIGDLFOMH);
			}
		}
		else
		{
			bool flag = false;
			foreach (MHOCDHIPMBI item in BGNGFDPLFMM)
			{
				if (item.FHPICFHABBJ.id == KHLGDCHJJPB.id && item.PNDNEMDPFHC == PNDNEMDPFHC)
				{
					result = --item.BNCKNICACCF;
					if (item.BNCKNICACCF < 0 && !CJONGDEPJHC)
					{
						UnityEngine.Debug.LogError("Texture reference count is less than zero!");
					}
					if (item.BNCKNICACCF <= 0 && !item.PNMBBJHAILD)
					{
						BGNGFDPLFMM.Remove(item);
						IHFILHIAGLG.Add(item);
					}
					flag = true;
					break;
				}
			}
			if (!flag && !CJONGDEPJHC)
			{
				result = 0;
			}
		}
		return result;
	}

	[SpecialName]
	public void JLOKOBIENPP(Action<string, Texture2D, bool> IDEBKDPMPGM)
	{
		Action<string, Texture2D, bool> action = FCNKIEPEAAG;
		Action<string, Texture2D, bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref FCNKIEPEAAG, (Action<string, Texture2D, bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void EPPEDDFMHIB(Action<string, Texture2D, bool> IDEBKDPMPGM)
	{
		Action<string, Texture2D, bool> action = FCNKIEPEAAG;
		Action<string, Texture2D, bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref FCNKIEPEAAG, (Action<string, Texture2D, bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private MHOCDHIPMBI LEMHBEDMBLA()
	{
		MHOCDHIPMBI mHOCDHIPMBI = null;
		if (IHFILHIAGLG.Count > 0)
		{
			mHOCDHIPMBI = IHFILHIAGLG[0];
			IHFILHIAGLG.RemoveAt(0);
		}
		else
		{
			UnityEngine.Debug.LogWarning("DecalId");
			mHOCDHIPMBI = new MHOCDHIPMBI(new Texture2D(Singleton<ArmyPreviewCamera>.instance.FCEIGDLFOMH.width, Singleton<ArmyPreviewCamera>.instance.FCEIGDLFOMH.height));
		}
		return mHOCDHIPMBI;
	}

	private bool CNLHCNDLEKD(DatabasePlayer KHLGDCHJJPB, bool PNDNEMDPFHC, out MHOCDHIPMBI FCEIGDLFOMH)
	{
		string text = GJNFOBKGGNF(KHLGDCHJJPB);
		foreach (MHOCDHIPMBI item in DPGAJEBFNAD)
		{
			if (item.FHPICFHABBJ.id == KHLGDCHJJPB.id && item.PNDNEMDPFHC == PNDNEMDPFHC && text == item.CMBKCHADJPD)
			{
				FCEIGDLFOMH = item;
				if (item.BNCKNICACCF == 0)
				{
					IHFILHIAGLG.Remove(item);
				}
				return true;
			}
		}
		FCEIGDLFOMH = null;
		return false;
	}

	private MHOCDHIPMBI MPIKACFFEEO()
	{
		MHOCDHIPMBI mHOCDHIPMBI = null;
		if (IHFILHIAGLG.Count > 0)
		{
			mHOCDHIPMBI = IHFILHIAGLG[0];
			IHFILHIAGLG.RemoveAt(0);
		}
		else
		{
			UnityEngine.Debug.LogWarning("Increasing texture count in player texture pool!");
			mHOCDHIPMBI = new MHOCDHIPMBI(new Texture2D(Singleton<ArmyPreviewCamera>.instance.FCEIGDLFOMH.width, Singleton<ArmyPreviewCamera>.instance.FCEIGDLFOMH.height));
		}
		return mHOCDHIPMBI;
	}

	public int FNHIOAADLFN(string ALIIBMLMNKA, bool PNDNEMDPFHC = true, bool CJONGDEPJHC = false, bool BCHINGHDGEF = false)
	{
		DatabasePlayer databasePlayer = new DatabasePlayer();
		databasePlayer.id = ALIIBMLMNKA;
		DatabasePlayer kHLGDCHJJPB = databasePlayer;
		return FEDFPBLODOA(kHLGDCHJJPB, PNDNEMDPFHC, CJONGDEPJHC, BCHINGHDGEF);
	}
}
