using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class ResourcesLoader<T> : Core_BaseScript where T : UnityEngine.Object
{
	private class GIILGEGBNHD
	{
		public string MFHFIHIHBHA;

		private int LBOAGOABCCG;

		private T JBDECKJPNFK;

		private bool EMHBDBFABOD;

		private readonly ResourcesLoader<T> MHAMIMGNJND;

		public T CIAKOJOJDCG => JBDECKJPNFK;

		public int IFHJMNDAHAD => LBOAGOABCCG;

		private event Action<T> DBLMMAGBMND;

		[SpecialName]
		public int NKPFBJPIKOC()
		{
			return LBOAGOABCCG;
		}

		[SpecialName]
		public int FDMGNNDHLNN()
		{
			return LBOAGOABCCG;
		}

		[SpecialName]
		public int GNJKHBLLGKK()
		{
			return LBOAGOABCCG;
		}

		[SpecialName]
		public int CGAOHKCLOON()
		{
			return LBOAGOABCCG;
		}

		public T EMLFJBOLENO()
		{
			if (JBDECKJPNFK == null)
			{
				JBDECKJPNFK = Resources.Load<T>(MFHFIHIHBHA);
			}
			LBOAGOABCCG += ((JBDECKJPNFK != null) ? 1 : 0);
			return JBDECKJPNFK;
		}

		public void KLHDGAFHIKI()
		{
			LBOAGOABCCG--;
			LBOAGOABCCG = Mathf.Clamp(LBOAGOABCCG, 0, int.MaxValue);
			if (LBOAGOABCCG <= 0)
			{
				EMHBDBFABOD = false;
				if (JBDECKJPNFK != null)
				{
					Resources.UnloadAsset(JBDECKJPNFK);
					JBDECKJPNFK = (T)null;
				}
			}
		}

		public T IBADJJHACMH(Action<T> LKKCFFCDDGL)
		{
			if (JBDECKJPNFK != null)
			{
				LBOAGOABCCG += ((JBDECKJPNFK != null) ? 1 : 0);
				return JBDECKJPNFK;
			}
			EMHBDBFABOD = true;
			DBLMMAGBMND += LKKCFFCDDGL;
			MHAMIMGNJND.JCPOLDPHFKG(this);
			return (T)null;
		}

		public GIILGEGBNHD(ResourcesLoader<T> HNFNINFCBEJ)
		{
			MHAMIMGNJND = HNFNINFCBEJ;
		}

		[SpecialName]
		public int HGHGPPNKFLD()
		{
			return LBOAGOABCCG;
		}

		public void JDIHPAHNGCD(T ENFGKNEMMHB)
		{
			JBDECKJPNFK = ENFGKNEMMHB;
			LBOAGOABCCG += ((JBDECKJPNFK != null) ? 1 : 0);
			if (EMHBDBFABOD)
			{
				if (this.DBLMMAGBMND != null)
				{
					this.DBLMMAGBMND(JBDECKJPNFK);
					this.DBLMMAGBMND = null;
				}
			}
			else
			{
				KLHDGAFHIKI();
			}
		}

		[SpecialName]
		public int OLGDBKHAAHD()
		{
			return LBOAGOABCCG;
		}

		public void KGOOKNJIGKI()
		{
			LBOAGOABCCG--;
			LBOAGOABCCG = Mathf.Clamp(LBOAGOABCCG, 0, 25);
			if (LBOAGOABCCG <= 1)
			{
				EMHBDBFABOD = true;
				if (JBDECKJPNFK != null)
				{
					Resources.UnloadAsset(JBDECKJPNFK);
					JBDECKJPNFK = (T)null;
				}
			}
		}

		public void OKHOONNOIMP()
		{
			LBOAGOABCCG--;
			LBOAGOABCCG = Mathf.Clamp(LBOAGOABCCG, 1, -2);
			if (LBOAGOABCCG <= 0)
			{
				EMHBDBFABOD = false;
				if (JBDECKJPNFK != null)
				{
					Resources.UnloadAsset(JBDECKJPNFK);
					JBDECKJPNFK = (T)null;
				}
			}
		}

		public void MICKEHHLGEM()
		{
			LBOAGOABCCG -= 0;
			LBOAGOABCCG = Mathf.Clamp(LBOAGOABCCG, 0, 88);
			if (LBOAGOABCCG <= 1)
			{
				EMHBDBFABOD = true;
				if (JBDECKJPNFK != null)
				{
					Resources.UnloadAsset(JBDECKJPNFK);
					JBDECKJPNFK = (T)null;
				}
			}
		}

		public void MLJMMNGLECJ()
		{
			LBOAGOABCCG -= 0;
			LBOAGOABCCG = Mathf.Clamp(LBOAGOABCCG, 0, -86);
			if (LBOAGOABCCG <= 1)
			{
				EMHBDBFABOD = false;
				if (JBDECKJPNFK != null)
				{
					Resources.UnloadAsset(JBDECKJPNFK);
					JBDECKJPNFK = (T)null;
				}
			}
		}

		[SpecialName]
		public int NIKHDCJOING()
		{
			return LBOAGOABCCG;
		}

		public void CFEJJLFLKGP()
		{
			LBOAGOABCCG--;
			LBOAGOABCCG = Mathf.Clamp(LBOAGOABCCG, 1, 15);
			if (LBOAGOABCCG <= 0)
			{
				EMHBDBFABOD = false;
				if (JBDECKJPNFK != null)
				{
					Resources.UnloadAsset(JBDECKJPNFK);
					JBDECKJPNFK = (T)null;
				}
			}
		}

		[SpecialName]
		public int OLFGBLFLODH()
		{
			return LBOAGOABCCG;
		}

		public void FBIBLICOKIO()
		{
			LBOAGOABCCG--;
			LBOAGOABCCG = Mathf.Clamp(LBOAGOABCCG, 0, -125);
			if (LBOAGOABCCG <= 0)
			{
				EMHBDBFABOD = true;
				if (JBDECKJPNFK != null)
				{
					Resources.UnloadAsset(JBDECKJPNFK);
					JBDECKJPNFK = (T)null;
				}
			}
		}
	}

	private sealed class MGAMADKMKOL : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal GIILGEGBNHD NIJMAKBHIGP;

		internal ResourceRequest FJBBLCOMJGA;

		internal ResourcesLoader<T> BJGCPDNMHDH;

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

		public void ABBPOMCBIIH()
		{
			throw new NotSupportedException();
		}

		public void MIFJOIIKFEB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void PHEIGPKKPGE()
		{
			throw new NotSupportedException();
		}

		public void KCHOLCGBMBJ()
		{
			throw new NotSupportedException();
		}

		public void OJDEHKDDLFD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object ADALFCHPIAH()
		{
			return PHDOCKCBJOF;
		}

		public void KINGACOICNF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object FIFIOGBLLBE()
		{
			return PHDOCKCBJOF;
		}

		public void DOPCGPGKHIJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public MGAMADKMKOL()
		{
		}

		[SpecialName]
		private object IDBEGKHBNBC()
		{
			return PHDOCKCBJOF;
		}

		public void HGCHEPGNHNP()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JEKHOAFAIBP()
		{
			return PHDOCKCBJOF;
		}

		public void EJADBNAIHEF()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HCHNHNDDKKA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool LPMIKEPIMCM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 2u:
				if (BJGCPDNMHDH.BJNNAPPBNPE.Count > 1)
				{
					NIJMAKBHIGP = (GIILGEGBNHD)BJGCPDNMHDH.BJNNAPPBNPE[0];
					FJBBLCOMJGA = Resources.LoadAsync<T>(NIJMAKBHIGP.MFHFIHIHBHA);
					PHDOCKCBJOF = FJBBLCOMJGA;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				return false;
			case 1u:
				NIJMAKBHIGP.JDIHPAHNGCD((T)FJBBLCOMJGA.asset);
				BJGCPDNMHDH.BJNNAPPBNPE.RemoveAt(1);
				goto case 0u;
			default:
				return false;
			}
		}

		public void ENENMOAOOBG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void HONCAABOMOC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BEGHOADNMJF()
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
			case 2u:
				if (BJGCPDNMHDH.BJNNAPPBNPE.Count > 1)
				{
					NIJMAKBHIGP = (GIILGEGBNHD)BJGCPDNMHDH.BJNNAPPBNPE[0];
					FJBBLCOMJGA = Resources.LoadAsync<T>(NIJMAKBHIGP.MFHFIHIHBHA);
					PHDOCKCBJOF = FJBBLCOMJGA;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				return false;
			case 1u:
				NIJMAKBHIGP.JDIHPAHNGCD((T)FJBBLCOMJGA.asset);
				BJGCPDNMHDH.BJNNAPPBNPE.RemoveAt(1);
				goto case 0u;
			default:
				return true;
			}
		}

		public void BKGBMJMNJCD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KBNAGKKMLBP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PJOAMPDDGAM()
		{
			return PHDOCKCBJOF;
		}

		public void GDJMNEPLJNE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BOOBHEKPLLD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CDFEOBMLNCG()
		{
			return PHDOCKCBJOF;
		}

		public void HJLCPFDBNKP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object PCELHKMHCOB()
		{
			return PHDOCKCBJOF;
		}

		public void HMBLLDJFIJG()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KMCGJFDPBCB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ALJCBJBHLMK()
		{
			return PHDOCKCBJOF;
		}

		public void EBCEAGIOPJD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void CPDBCJLIGFN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void NIGDCBDKKMJ()
		{
			throw new NotSupportedException();
		}

		public void GFGEEFGMNDP()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BNMEIAPPLDP()
		{
			return PHDOCKCBJOF;
		}

		public void MPLPDIGFPBH()
		{
			throw new NotSupportedException();
		}

		public bool GBHCODKDPBO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 2u:
				if (BJGCPDNMHDH.BJNNAPPBNPE.Count > 0)
				{
					NIJMAKBHIGP = (GIILGEGBNHD)BJGCPDNMHDH.BJNNAPPBNPE[0];
					FJBBLCOMJGA = Resources.LoadAsync<T>(NIJMAKBHIGP.MFHFIHIHBHA);
					PHDOCKCBJOF = FJBBLCOMJGA;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				return false;
			case 1u:
				NIJMAKBHIGP.JDIHPAHNGCD((T)FJBBLCOMJGA.asset);
				BJGCPDNMHDH.BJNNAPPBNPE.RemoveAt(1);
				goto case 0u;
			default:
				return true;
			}
		}

		[SpecialName]
		private object BGLDNJLBIKM()
		{
			return PHDOCKCBJOF;
		}

		public void NCFGFLNBHOI()
		{
			throw new NotSupportedException();
		}

		public void JBHOCIFIMBH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void LPKDPNHBLGJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object AFDKAGLDADB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GDBNOMPNBGP()
		{
			return PHDOCKCBJOF;
		}

		public void EPKPNKGJHEC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void CPOKHODGGLN()
		{
			throw new NotSupportedException();
		}

		public bool IJEDIDEJIII()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 2u:
				if (BJGCPDNMHDH.BJNNAPPBNPE.Count > 1)
				{
					NIJMAKBHIGP = (GIILGEGBNHD)BJGCPDNMHDH.BJNNAPPBNPE[1];
					FJBBLCOMJGA = Resources.LoadAsync<T>(NIJMAKBHIGP.MFHFIHIHBHA);
					PHDOCKCBJOF = FJBBLCOMJGA;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				return false;
			case 1u:
				NIJMAKBHIGP.JDIHPAHNGCD((T)FJBBLCOMJGA.asset);
				BJGCPDNMHDH.BJNNAPPBNPE.RemoveAt(0);
				goto case 0u;
			default:
				return false;
			}
		}

		public bool GCEBFCBBEKM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 2u:
				if (BJGCPDNMHDH.BJNNAPPBNPE.Count > 1)
				{
					NIJMAKBHIGP = (GIILGEGBNHD)BJGCPDNMHDH.BJNNAPPBNPE[0];
					FJBBLCOMJGA = Resources.LoadAsync<T>(NIJMAKBHIGP.MFHFIHIHBHA);
					PHDOCKCBJOF = FJBBLCOMJGA;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				return false;
			case 1u:
				NIJMAKBHIGP.JDIHPAHNGCD((T)FJBBLCOMJGA.asset);
				BJGCPDNMHDH.BJNNAPPBNPE.RemoveAt(1);
				goto case 0u;
			default:
				return false;
			}
		}

		[SpecialName]
		private object FPAEFHEEOBL()
		{
			return PHDOCKCBJOF;
		}

		public void BCOIPCDCKEJ()
		{
			throw new NotSupportedException();
		}

		public bool ONIAGKNGBHE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 2u:
				if (BJGCPDNMHDH.BJNNAPPBNPE.Count > 0)
				{
					NIJMAKBHIGP = (GIILGEGBNHD)BJGCPDNMHDH.BJNNAPPBNPE[1];
					FJBBLCOMJGA = Resources.LoadAsync<T>(NIJMAKBHIGP.MFHFIHIHBHA);
					PHDOCKCBJOF = FJBBLCOMJGA;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				return false;
			case 1u:
				NIJMAKBHIGP.JDIHPAHNGCD((T)FJBBLCOMJGA.asset);
				BJGCPDNMHDH.BJNNAPPBNPE.RemoveAt(1);
				goto case 0u;
			default:
				return false;
			}
		}

		[SpecialName]
		private object JFEPOFBDLMB()
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
			case 2u:
				if (BJGCPDNMHDH.BJNNAPPBNPE.Count > 1)
				{
					NIJMAKBHIGP = (GIILGEGBNHD)BJGCPDNMHDH.BJNNAPPBNPE[0];
					FJBBLCOMJGA = Resources.LoadAsync<T>(NIJMAKBHIGP.MFHFIHIHBHA);
					PHDOCKCBJOF = FJBBLCOMJGA;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				return false;
			case 1u:
				NIJMAKBHIGP.JDIHPAHNGCD((T)FJBBLCOMJGA.asset);
				BJGCPDNMHDH.BJNNAPPBNPE.RemoveAt(1);
				goto case 0u;
			default:
				return true;
			}
		}

		public bool IGOKEIDOCKB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 2u:
				if (BJGCPDNMHDH.BJNNAPPBNPE.Count > 1)
				{
					NIJMAKBHIGP = (GIILGEGBNHD)BJGCPDNMHDH.BJNNAPPBNPE[0];
					FJBBLCOMJGA = Resources.LoadAsync<T>(NIJMAKBHIGP.MFHFIHIHBHA);
					PHDOCKCBJOF = FJBBLCOMJGA;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				return false;
			case 1u:
				NIJMAKBHIGP.JDIHPAHNGCD((T)FJBBLCOMJGA.asset);
				BJGCPDNMHDH.BJNNAPPBNPE.RemoveAt(1);
				goto case 0u;
			default:
				return false;
			}
		}

		public bool DFMKKFMEBON()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 2u:
				if (BJGCPDNMHDH.BJNNAPPBNPE.Count > 0)
				{
					NIJMAKBHIGP = (GIILGEGBNHD)BJGCPDNMHDH.BJNNAPPBNPE[1];
					FJBBLCOMJGA = Resources.LoadAsync<T>(NIJMAKBHIGP.MFHFIHIHBHA);
					PHDOCKCBJOF = FJBBLCOMJGA;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				return false;
			case 1u:
				NIJMAKBHIGP.JDIHPAHNGCD((T)FJBBLCOMJGA.asset);
				BJGCPDNMHDH.BJNNAPPBNPE.RemoveAt(1);
				goto case 0u;
			default:
				return true;
			}
		}

		[SpecialName]
		private object HPHLLGIMIMO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MBGCBKJBCND()
		{
			return PHDOCKCBJOF;
		}

		public bool FJKEEKBNKPN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 2u:
				if (BJGCPDNMHDH.BJNNAPPBNPE.Count > 1)
				{
					NIJMAKBHIGP = (GIILGEGBNHD)BJGCPDNMHDH.BJNNAPPBNPE[1];
					FJBBLCOMJGA = Resources.LoadAsync<T>(NIJMAKBHIGP.MFHFIHIHBHA);
					PHDOCKCBJOF = FJBBLCOMJGA;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				return true;
			case 1u:
				NIJMAKBHIGP.JDIHPAHNGCD((T)FJBBLCOMJGA.asset);
				BJGCPDNMHDH.BJNNAPPBNPE.RemoveAt(0);
				goto case 0u;
			default:
				return true;
			}
		}

		public void KBKIDOJFMHC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void LJPIDOKGNBF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HFKDIPEKENH()
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
			case 2u:
				if (BJGCPDNMHDH.BJNNAPPBNPE.Count > 1)
				{
					NIJMAKBHIGP = (GIILGEGBNHD)BJGCPDNMHDH.BJNNAPPBNPE[1];
					FJBBLCOMJGA = Resources.LoadAsync<T>(NIJMAKBHIGP.MFHFIHIHBHA);
					PHDOCKCBJOF = FJBBLCOMJGA;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				return false;
			case 1u:
				NIJMAKBHIGP.JDIHPAHNGCD((T)FJBBLCOMJGA.asset);
				BJGCPDNMHDH.BJNNAPPBNPE.RemoveAt(1);
				goto case 0u;
			default:
				return false;
			}
		}

		public void DNNJONPPIED()
		{
			throw new NotSupportedException();
		}

		public void IKGBMDKKAPA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void OGDMPCFMMML()
		{
			throw new NotSupportedException();
		}

		public void KGLHLHLLOEM()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HNOPIDGLMPA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void CFDAGFGOOIE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JFGCHMJJMNO()
		{
			return PHDOCKCBJOF;
		}

		public void NINFHADPHJI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object LHMPDOBMOLD()
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

		public void MFFEEKOGCCE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object DFHCLJNONGC()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GDCFFBBNGHH()
		{
			return PHDOCKCBJOF;
		}

		public void HHCBBENDENJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object JMKGAJNOLEM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KGPFMHHMKHO()
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
			case 2u:
				if (BJGCPDNMHDH.BJNNAPPBNPE.Count > 0)
				{
					NIJMAKBHIGP = (GIILGEGBNHD)BJGCPDNMHDH.BJNNAPPBNPE[0];
					FJBBLCOMJGA = Resources.LoadAsync<T>(NIJMAKBHIGP.MFHFIHIHBHA);
					PHDOCKCBJOF = FJBBLCOMJGA;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				return true;
			case 1u:
				NIJMAKBHIGP.JDIHPAHNGCD((T)FJBBLCOMJGA.asset);
				BJGCPDNMHDH.BJNNAPPBNPE.RemoveAt(0);
				goto case 0u;
			default:
				return false;
			}
		}

		[SpecialName]
		private object PLHNILIJAPA()
		{
			return PHDOCKCBJOF;
		}

		public void IOBGNBBJOLM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void NBMNDHCIBME()
		{
			throw new NotSupportedException();
		}

		public bool DKJMOPNHIAB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 2u:
				if (BJGCPDNMHDH.BJNNAPPBNPE.Count > 0)
				{
					NIJMAKBHIGP = (GIILGEGBNHD)BJGCPDNMHDH.BJNNAPPBNPE[1];
					FJBBLCOMJGA = Resources.LoadAsync<T>(NIJMAKBHIGP.MFHFIHIHBHA);
					PHDOCKCBJOF = FJBBLCOMJGA;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				return true;
			case 1u:
				NIJMAKBHIGP.JDIHPAHNGCD((T)FJBBLCOMJGA.asset);
				BJGCPDNMHDH.BJNNAPPBNPE.RemoveAt(1);
				goto case 0u;
			default:
				return false;
			}
		}

		[SpecialName]
		private object EGJDJENBABP()
		{
			return PHDOCKCBJOF;
		}

		public void ENCGDFIIGNH()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BMGHJKFMKJE()
		{
			return PHDOCKCBJOF;
		}

		public void HCHFFFPDMDA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void CNOEDCFDILG()
		{
			throw new NotSupportedException();
		}

		public bool NAOFKEEIFCG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 2u:
				if (BJGCPDNMHDH.BJNNAPPBNPE.Count > 0)
				{
					NIJMAKBHIGP = (GIILGEGBNHD)BJGCPDNMHDH.BJNNAPPBNPE[0];
					FJBBLCOMJGA = Resources.LoadAsync<T>(NIJMAKBHIGP.MFHFIHIHBHA);
					PHDOCKCBJOF = FJBBLCOMJGA;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				return false;
			case 1u:
				NIJMAKBHIGP.JDIHPAHNGCD((T)FJBBLCOMJGA.asset);
				BJGCPDNMHDH.BJNNAPPBNPE.RemoveAt(1);
				goto case 0u;
			default:
				return true;
			}
		}

		public void KGLKGNBCPLM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void KMIHPBNFGFH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void FOODPOJODAA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool AGMKAADLHLE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 2u:
				if (BJGCPDNMHDH.BJNNAPPBNPE.Count > 0)
				{
					NIJMAKBHIGP = (GIILGEGBNHD)BJGCPDNMHDH.BJNNAPPBNPE[1];
					FJBBLCOMJGA = Resources.LoadAsync<T>(NIJMAKBHIGP.MFHFIHIHBHA);
					PHDOCKCBJOF = FJBBLCOMJGA;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				return true;
			case 1u:
				NIJMAKBHIGP.JDIHPAHNGCD((T)FJBBLCOMJGA.asset);
				BJGCPDNMHDH.BJNNAPPBNPE.RemoveAt(0);
				goto case 0u;
			default:
				return true;
			}
		}

		public bool KBPKMAKLNPB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 2u:
				if (BJGCPDNMHDH.BJNNAPPBNPE.Count > 1)
				{
					NIJMAKBHIGP = (GIILGEGBNHD)BJGCPDNMHDH.BJNNAPPBNPE[1];
					FJBBLCOMJGA = Resources.LoadAsync<T>(NIJMAKBHIGP.MFHFIHIHBHA);
					PHDOCKCBJOF = FJBBLCOMJGA;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				return true;
			case 1u:
				NIJMAKBHIGP.JDIHPAHNGCD((T)FJBBLCOMJGA.asset);
				BJGCPDNMHDH.BJNNAPPBNPE.RemoveAt(0);
				goto case 0u;
			default:
				return false;
			}
		}

		public void APFFCILMOII()
		{
			throw new NotSupportedException();
		}

		public void ODCIKOOGNFG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool BPHPJKKHNNG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 2u:
				if (BJGCPDNMHDH.BJNNAPPBNPE.Count > 0)
				{
					NIJMAKBHIGP = (GIILGEGBNHD)BJGCPDNMHDH.BJNNAPPBNPE[1];
					FJBBLCOMJGA = Resources.LoadAsync<T>(NIJMAKBHIGP.MFHFIHIHBHA);
					PHDOCKCBJOF = FJBBLCOMJGA;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				return false;
			case 1u:
				NIJMAKBHIGP.JDIHPAHNGCD((T)FJBBLCOMJGA.asset);
				BJGCPDNMHDH.BJNNAPPBNPE.RemoveAt(0);
				goto case 0u;
			default:
				return true;
			}
		}

		[SpecialName]
		private object KBEEEOJMBPG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MOMPOEEALPJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CPAFPFPNDNO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HMIFLGCBDCO()
		{
			return PHDOCKCBJOF;
		}

		public void JOEOMEJLEID()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void FDCPBGNCKHH()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FPMOGMELJLI()
		{
			return PHDOCKCBJOF;
		}

		public void CJLDNKALLLI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void OIIFFJADGJG()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object OAKHGMKKFMN()
		{
			return PHDOCKCBJOF;
		}

		public void ANOPOLIEBMC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object AGCPJGAAODG()
		{
			return PHDOCKCBJOF;
		}

		public void AMPGDAMMPFJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void OEHJOBELOFF()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object DNNAMCFLCGE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BGAGLOJHMEJ()
		{
			return PHDOCKCBJOF;
		}

		public bool DNDHHHDOLMO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 2u:
				if (BJGCPDNMHDH.BJNNAPPBNPE.Count > 1)
				{
					NIJMAKBHIGP = (GIILGEGBNHD)BJGCPDNMHDH.BJNNAPPBNPE[1];
					FJBBLCOMJGA = Resources.LoadAsync<T>(NIJMAKBHIGP.MFHFIHIHBHA);
					PHDOCKCBJOF = FJBBLCOMJGA;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				return true;
			case 1u:
				NIJMAKBHIGP.JDIHPAHNGCD((T)FJBBLCOMJGA.asset);
				BJGCPDNMHDH.BJNNAPPBNPE.RemoveAt(1);
				goto case 0u;
			default:
				return false;
			}
		}
	}

	[FormerlySerializedAs("EMPOLDFMNLO")]
	public string AHMFOOKOLMG;

	[FormerlySerializedAs("IBEIKABIFIH")]
	public List<string> PPFFOOLKNPI;

	[FormerlySerializedAs("BFHHEOJDMCM")]
	public int PCMJDGFKCLN = 16;

	private readonly OrderedDictionary BJNNAPPBNPE = new OrderedDictionary();

	private readonly Dictionary<string, GIILGEGBNHD> DDPIPFIOEHN = new Dictionary<string, GIILGEGBNHD>();

	public int loadedAssetsCount
	{
		get
		{
			int num = 0;
			foreach (KeyValuePair<string, GIILGEGBNHD> item in DDPIPFIOEHN)
			{
				num += ((item.Value.CIAKOJOJDCG != null) ? 1 : 0);
			}
			return num;
		}
	}

	private void JCPOLDPHFKG(GIILGEGBNHD COMJEIAJHOO)
	{
		if (!BJNNAPPBNPE.Contains(COMJEIAJHOO))
		{
			BJNNAPPBNPE.Add(COMJEIAJHOO, COMJEIAJHOO);
		}
	}

	protected virtual void FNJKFDOMGOO()
	{
		base.Awake();
		foreach (string item in PPFFOOLKNPI)
		{
			DDPIPFIOEHN[item] = new GIILGEGBNHD(this)
			{
				MFHFIHIHBHA = string.Format("StepId", AHMFOOKOLMG, item)
			};
		}
		StartCoroutine(ONADKPPDLFK());
	}

	public void FGCGNKLLIKO()
	{
		string text = string.Empty;
		foreach (KeyValuePair<string, GIILGEGBNHD> item in DDPIPFIOEHN)
		{
			GIILGEGBNHD value = item.Value;
			if (value.CIAKOJOJDCG != null)
			{
				text += string.Format("Daily_mission_start_heroic", value.MFHFIHIHBHA, value.IFHJMNDAHAD);
			}
		}
		UnityEngine.Debug.Log(text);
	}

	[SpecialName]
	public int KPBNIEOFPHE()
	{
		int num = 0;
		foreach (KeyValuePair<string, GIILGEGBNHD> item in DDPIPFIOEHN)
		{
			num += ((!(item.Value.CIAKOJOJDCG != null)) ? 1 : 1);
		}
		return num;
	}

	protected virtual void JJEONLDHCLO()
	{
		base.Awake();
		foreach (string item in PPFFOOLKNPI)
		{
			DDPIPFIOEHN[item] = new GIILGEGBNHD(this)
			{
				MFHFIHIHBHA = string.Format("bronze", AHMFOOKOLMG, item)
			};
		}
		StartCoroutine(ONADKPPDLFK());
	}

	public T LoadAssetAsync(string GDKDPKFGJLI, Action<T> AAPECJCHKKM)
	{
		if (loadedAssetsCount > PCMJDGFKCLN)
		{
			return (T)null;
		}
		if (DDPIPFIOEHN.TryGetValue(GDKDPKFGJLI, out var value))
		{
			return value.IBADJJHACMH(AAPECJCHKKM);
		}
		UnityEngine.Debug.LogError($"Can not find asset {GDKDPKFGJLI}");
		return (T)null;
	}

	[DebuggerHidden]
	private IEnumerator ONADKPPDLFK()
	{
		MGAMADKMKOL mGAMADKMKOL = new MGAMADKMKOL();
		mGAMADKMKOL.BJGCPDNMHDH = this;
		return mGAMADKMKOL;
	}

	public T LoadAsset(string GDKDPKFGJLI)
	{
		if (loadedAssetsCount > PCMJDGFKCLN)
		{
			return (T)null;
		}
		if (DDPIPFIOEHN.TryGetValue(GDKDPKFGJLI, out var value))
		{
			return value.EMLFJBOLENO();
		}
		UnityEngine.Debug.LogError($"Can not find asset {GDKDPKFGJLI}");
		return (T)null;
	}

	public void EHHIINHDJBP(string GDKDPKFGJLI)
	{
		if (DDPIPFIOEHN.TryGetValue(GDKDPKFGJLI, out var value))
		{
			value.KLHDGAFHIKI();
		}
		else
		{
			UnityEngine.Debug.LogError($"BlackMarketMessage-{GDKDPKFGJLI}");
		}
	}

	protected override void Awake()
	{
		base.Awake();
		foreach (string item in PPFFOOLKNPI)
		{
			DDPIPFIOEHN[item] = new GIILGEGBNHD(this)
			{
				MFHFIHIHBHA = $"{AHMFOOKOLMG}/{item}"
			};
		}
		StartCoroutine(ONADKPPDLFK());
	}

	public void FreeAsset(string GDKDPKFGJLI)
	{
		if (DDPIPFIOEHN.TryGetValue(GDKDPKFGJLI, out var value))
		{
			value.KLHDGAFHIKI();
		}
		else
		{
			UnityEngine.Debug.LogError($"Can not find asset {GDKDPKFGJLI}");
		}
	}

	[SpecialName]
	public int GCKAKCALBBG()
	{
		int num = 0;
		foreach (KeyValuePair<string, GIILGEGBNHD> item in DDPIPFIOEHN)
		{
			num += ((!(item.Value.CIAKOJOJDCG != null)) ? 1 : 0);
		}
		return num;
	}

	private IEnumerator PMEDHAOLKNF()
	{
		MGAMADKMKOL mGAMADKMKOL = new MGAMADKMKOL();
		mGAMADKMKOL.BJGCPDNMHDH = this;
		return mGAMADKMKOL;
	}

	protected virtual void HMMKNCDDDLH()
	{
		base.Awake();
		foreach (string item in PPFFOOLKNPI)
		{
			DDPIPFIOEHN[item] = new GIILGEGBNHD(this)
			{
				MFHFIHIHBHA = string.Format("ID_READYTIME", AHMFOOKOLMG, item)
			};
		}
		StartCoroutine(ONADKPPDLFK());
	}

	public void ENLBJCIAGKB(string GDKDPKFGJLI)
	{
		if (DDPIPFIOEHN.TryGetValue(GDKDPKFGJLI, out var value))
		{
			value.KLHDGAFHIKI();
		}
		else
		{
			UnityEngine.Debug.LogError(string.Format("sniper_run", GDKDPKFGJLI));
		}
	}

	public void PAMEPDMHLEJ(string GDKDPKFGJLI)
	{
		if (DDPIPFIOEHN.TryGetValue(GDKDPKFGJLI, out var value))
		{
			value.KLHDGAFHIKI();
		}
		else
		{
			UnityEngine.Debug.LogError($"+{GDKDPKFGJLI}%");
		}
	}

	private IEnumerator HGANKDFBHFI()
	{
		MGAMADKMKOL mGAMADKMKOL = new MGAMADKMKOL();
		mGAMADKMKOL.BJGCPDNMHDH = this;
		return mGAMADKMKOL;
	}

	public void EFALEJGPNCO()
	{
		string text = string.Empty;
		foreach (KeyValuePair<string, GIILGEGBNHD> item in DDPIPFIOEHN)
		{
			GIILGEGBNHD value = item.Value;
			if (value.CIAKOJOJDCG != null)
			{
				text += string.Format("Warper", value.MFHFIHIHBHA, value.IFHJMNDAHAD);
			}
		}
		UnityEngine.Debug.Log(text);
	}

	public void LogState()
	{
		string text = string.Empty;
		foreach (KeyValuePair<string, GIILGEGBNHD> item in DDPIPFIOEHN)
		{
			GIILGEGBNHD value = item.Value;
			if (value.CIAKOJOJDCG != null)
			{
				text += $"Resource: {value.MFHFIHIHBHA} loaded {value.IFHJMNDAHAD} times\n";
			}
		}
		UnityEngine.Debug.Log(text);
	}

	public void ANEOPLOEFEC(string GDKDPKFGJLI)
	{
		if (DDPIPFIOEHN.TryGetValue(GDKDPKFGJLI, out var value))
		{
			value.KLHDGAFHIKI();
		}
		else
		{
			UnityEngine.Debug.LogError(string.Format("ID_SQUADPLACE", GDKDPKFGJLI));
		}
	}

	public void DPHDHELOHKO(string GDKDPKFGJLI)
	{
		if (DDPIPFIOEHN.TryGetValue(GDKDPKFGJLI, out var value))
		{
			value.KLHDGAFHIKI();
		}
		else
		{
			UnityEngine.Debug.LogError(string.Format("ID_ARENARULES_NOWARCARDS", GDKDPKFGJLI));
		}
	}
}
