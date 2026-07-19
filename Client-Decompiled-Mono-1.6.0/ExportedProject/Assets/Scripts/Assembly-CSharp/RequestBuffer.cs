using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using UnityEngine;

public class RequestBuffer
{
	private sealed class PDPMFPGALHI : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal float HJGIAOJHNJB;

		internal RequestBuffer BJGCPDNMHDH;

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
		private object LKAEMBCGLBN()
		{
			return PHDOCKCBJOF;
		}

		public void MDBDGOJADJM()
		{
			throw new NotSupportedException();
		}

		public void IHAHCOPGPIM()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object FCMAGGLJCMG()
		{
			return PHDOCKCBJOF;
		}

		public void EEHBKGPLIJN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool NAMPBIHOFGI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(HJGIAOJHNJB);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 1u:
			case 3u:
				if (Singleton<BeanstalkServerManager>.instance.MNILIIKGNKG())
				{
					PHDOCKCBJOF = new WaitForSeconds(295f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
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
				break;
			case 4u:
				BJGCPDNMHDH.Send();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void LDKFDMLPIOC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GDCFFBBNGHH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KKKMCHGLHLL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IHDBAJNCNGN()
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
				PHDOCKCBJOF = new WaitForSeconds(HJGIAOJHNJB);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 1u:
			case 3u:
				if (Singleton<BeanstalkServerManager>.instance.MNILIIKGNKG())
				{
					PHDOCKCBJOF = new WaitForSeconds(1014f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
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
				break;
			case 4u:
				BJGCPDNMHDH.Send();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void KOEEOJGJNAO()
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

		[SpecialName]
		private object GFMLDIMOGHD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CFBNPKIMOJC()
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
				PHDOCKCBJOF = new WaitForSeconds(HJGIAOJHNJB);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 1u:
			case 3u:
				if (Singleton<BeanstalkServerManager>.instance.GIIFAMLDBNI())
				{
					PHDOCKCBJOF = new WaitForSeconds(1076f);
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
						CLPPIAGLCJJ = 6;
					}
				}
				break;
			case 4u:
				BJGCPDNMHDH.Send();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public bool PPOPGFELIDA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(HJGIAOJHNJB);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 2u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 1u:
			case 3u:
				if (Singleton<BeanstalkServerManager>.instance.MNILIIKGNKG())
				{
					PHDOCKCBJOF = new WaitForSeconds(287f);
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
						CLPPIAGLCJJ = 6;
					}
				}
				break;
			case 4u:
				BJGCPDNMHDH.Send();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object GNFCCLCPCBO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FKJJFNMBKOP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EAGBDDECKHF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NIDLKNKKCND()
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
				PHDOCKCBJOF = new WaitForSeconds(HJGIAOJHNJB);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
			case 3u:
				if (Singleton<BeanstalkServerManager>.instance.MNILIIKGNKG())
				{
					PHDOCKCBJOF = new WaitForSeconds(172f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
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
				break;
			case 4u:
				BJGCPDNMHDH.Send();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void KNFDMCEJHLB()
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
				PHDOCKCBJOF = new WaitForSeconds(HJGIAOJHNJB);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 2u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 1u:
			case 3u:
				if (Singleton<BeanstalkServerManager>.instance.isSending)
				{
					PHDOCKCBJOF = new WaitForSeconds(729f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				else
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
				}
				break;
			case 4u:
				BJGCPDNMHDH.Send();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object GMEIAAMCBGA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GIEPJLBHHEO()
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
				PHDOCKCBJOF = new WaitForSeconds(HJGIAOJHNJB);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 1u:
			case 3u:
				if (Singleton<BeanstalkServerManager>.instance.GIIFAMLDBNI())
				{
					PHDOCKCBJOF = new WaitForSeconds(1073f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
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
				break;
			case 4u:
				BJGCPDNMHDH.Send();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object GENJNMACGLP()
		{
			return PHDOCKCBJOF;
		}

		public void MIEFKIEABBN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void KFOFFCGINMO()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool NOHPKMDNEAO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(HJGIAOJHNJB);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 2u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 1u:
			case 3u:
				if (Singleton<BeanstalkServerManager>.instance.MNILIIKGNKG())
				{
					PHDOCKCBJOF = new WaitForSeconds(170f);
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
						CLPPIAGLCJJ = 6;
					}
				}
				break;
			case 4u:
				BJGCPDNMHDH.Send();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void PDKPELBIAON()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JKKAEPEAGNP()
		{
			return PHDOCKCBJOF;
		}

		public void AEFEAMAGBKK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object COEKBAFPBLD()
		{
			return PHDOCKCBJOF;
		}

		public void EFKBIIPFDOM()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object DEOOBMKFKDE()
		{
			return PHDOCKCBJOF;
		}

		public void PDNKLJFHBGO()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GPKBICHIBHF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PEGJNAKGHCC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EOPJNKFKMNB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BEGHOADNMJF()
		{
			return PHDOCKCBJOF;
		}

		public void FMOJMHBAHAA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object ENKCCCABFFB()
		{
			return PHDOCKCBJOF;
		}

		public void HMBLLDJFIJG()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public PDPMFPGALHI()
		{
		}

		public bool AGMKAADLHLE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(HJGIAOJHNJB);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 2u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
			case 3u:
				if (Singleton<BeanstalkServerManager>.instance.isSending)
				{
					PHDOCKCBJOF = new WaitForSeconds(1132f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
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
				break;
			case 4u:
				BJGCPDNMHDH.Send();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object MPHILJJDNIO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KKCOHEHPJPF()
		{
			return PHDOCKCBJOF;
		}

		public void NBMNDHCIBME()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BIMFPFEHMAP()
		{
			return PHDOCKCBJOF;
		}

		public void NNCBKIIJPMB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object JFGCHMJJMNO()
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
				PHDOCKCBJOF = new WaitForSeconds(HJGIAOJHNJB);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 2u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 1u:
			case 3u:
				if (Singleton<BeanstalkServerManager>.instance.GIIFAMLDBNI())
				{
					PHDOCKCBJOF = new WaitForSeconds(1687f);
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
						CLPPIAGLCJJ = 8;
					}
				}
				break;
			case 4u:
				BJGCPDNMHDH.Send();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void MPLPDIGFPBH()
		{
			throw new NotSupportedException();
		}

		public void ENFGGBNAPGG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object OEKIILKKNOE()
		{
			return PHDOCKCBJOF;
		}

		public bool CMBMOAECEJG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(HJGIAOJHNJB);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
			case 3u:
				if (Singleton<BeanstalkServerManager>.instance.MNILIIKGNKG())
				{
					PHDOCKCBJOF = new WaitForSeconds(898f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
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
				break;
			case 4u:
				BJGCPDNMHDH.Send();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void OKIANDBCDIB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void DLIBOPAMHAN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void JMANMKKCDMM()
		{
			throw new NotSupportedException();
		}

		public void LBNGPPPKLHI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void BDPFKFGBNOH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object JDECDOJJAAH()
		{
			return PHDOCKCBJOF;
		}

		public void HHMPMPLLJCC()
		{
			throw new NotSupportedException();
		}

		public void AMPGDAMMPFJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool IBEPOFJDKLG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(HJGIAOJHNJB);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 1u:
			case 3u:
				if (Singleton<BeanstalkServerManager>.instance.MNILIIKGNKG())
				{
					PHDOCKCBJOF = new WaitForSeconds(222f);
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
				break;
			case 4u:
				BJGCPDNMHDH.Send();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public bool CCOPPEKLJOB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(HJGIAOJHNJB);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 2u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 1u:
			case 3u:
				if (Singleton<BeanstalkServerManager>.instance.GIIFAMLDBNI())
				{
					PHDOCKCBJOF = new WaitForSeconds(625f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
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
				break;
			case 4u:
				BJGCPDNMHDH.Send();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void HHCIHDMICFP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void POJKIIMAFDO()
		{
			throw new NotSupportedException();
		}

		public void MIPBONGPIJE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BGLDNJLBIKM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OAKHGMKKFMN()
		{
			return PHDOCKCBJOF;
		}

		public bool DDLMLOJGJMA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(HJGIAOJHNJB);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 2u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 1u:
			case 3u:
				if (Singleton<BeanstalkServerManager>.instance.GIIFAMLDBNI())
				{
					PHDOCKCBJOF = new WaitForSeconds(1786f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
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
				break;
			case 4u:
				BJGCPDNMHDH.Send();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void GFJIKANGNMC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void OPMABIIDKCN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MLDIMIPJMDD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GOAJCEAOPLA()
		{
			return PHDOCKCBJOF;
		}

		public bool CGOKGPGALLH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(HJGIAOJHNJB);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 1u:
			case 3u:
				if (Singleton<BeanstalkServerManager>.instance.GIIFAMLDBNI())
				{
					PHDOCKCBJOF = new WaitForSeconds(154f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
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
				break;
			case 4u:
				BJGCPDNMHDH.Send();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object MJPEJLKAOEH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AFAOHBIDOJD()
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
				PHDOCKCBJOF = new WaitForSeconds(HJGIAOJHNJB);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 2u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 1u:
			case 3u:
				if (Singleton<BeanstalkServerManager>.instance.isSending)
				{
					PHDOCKCBJOF = new WaitForSeconds(0.2f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
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
				break;
			case 4u:
				BJGCPDNMHDH.Send();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void NPKGNIGNPKG()
		{
			throw new NotSupportedException();
		}

		public void PKMIJKOPPBF()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object INAMGPNDAAJ()
		{
			return PHDOCKCBJOF;
		}

		public void EHMOLOCPIGB()
		{
			throw new NotSupportedException();
		}

		public void HKFEFDNFKKK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CCANBMDEKMB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AGANCOFPDCK()
		{
			return PHDOCKCBJOF;
		}

		public void GFPDOCDEGPA()
		{
			throw new NotSupportedException();
		}

		public void MIFJOIIKFEB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HDDLDAHLPCO()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object CNGCLCAAHIG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FPFOODLPEBK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IHPDPKLEDKC()
		{
			return PHDOCKCBJOF;
		}

		public void BCIPEBNJONK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void ODPKEEIHOPK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}
	}

	public bool alreadySent;

	public string id;

	public int requestCount;

	public Dictionary<int, Request> requests;

	private float mTimeOut;

	private RadicalRoutine mWaitingRoutine;

	public void AddRequest(DatabaseAction databaseAction, string objData, int warbucks = 0, int gold = 0, string parameter = "", bool additionalParameter = false)
	{
		if (DebugSettings.debugEnabled)
		{
			UnityEngine.Debug.Log("Add request to buffer");
		}
		Request request = new Request();
		request.data = objData;
		request.action = databaseAction;
		Request value = request;
		switch (databaseAction)
		{
		case DatabaseAction.InstantWeaponUpgrade:
		case DatabaseAction.BuyWeapon:
		case DatabaseAction.InstantUnitUpgrade:
		case DatabaseAction.BuyUnit:
		case DatabaseAction.BuyCardPack:
		case DatabaseAction.BuyDecal:
		case DatabaseAction.InstantBuyUnit:
		case DatabaseAction.InstantBuyWeapon:
			PlayerAnalytics.instance.AddTransaction((int)databaseAction, parameter, gold, warbucks, 0f);
			break;
		}
		switch (databaseAction)
		{
		case DatabaseAction.BuyWeapon:
			if (gold > 0)
			{
				Singleton<EventTrackingManager>.instance.RegisterGameItemBoughtEvent("Buy_Weapon_Gold", "Weapon_ID", parameter, gold);
				Singleton<EventTrackingManager>.instance.DDIEAJKJMFL(KKFOLKGHOJE.PurchasePremiumWeapon);
				Singleton<EventTrackingManager>.instance.RegisterGoldOut("Buy_Weapon", gold);
				Singleton<EventTrackingManager>.instance.RegisterGameItemBoughtEvent("Buy_Weapon_At_Rank_Gold", "Rank", LevelManager.instance.levelNumber.ToString(), gold);
			}
			else
			{
				Singleton<EventTrackingManager>.instance.RegisterGameItemBoughtEvent("Buy_Weapon", "Weapon_ID", parameter, warbucks);
				Singleton<EventTrackingManager>.instance.RegisterGameItemBoughtEvent("Buy_Weapon_At_Rank", "Rank", LevelManager.instance.levelNumber.ToString(), warbucks);
				Singleton<EventTrackingManager>.instance.DDIEAJKJMFL(KKFOLKGHOJE.PurchaseSoftWeapon);
			}
			break;
		case DatabaseAction.BuyWeaponUpgrade:
		{
			Dictionary<string, object> dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(objData);
			string text = "0";
			if (dictionary.ContainsKey("BoughtIndex"))
			{
				text = dictionary["BoughtIndex"].ToString();
			}
			Singleton<EventTrackingManager>.instance.RegisterGameItemBoughtEvent("Buy_Weapon_Upgrade", "Weapon_ID", parameter + " " + text, warbucks);
			Singleton<EventTrackingManager>.instance.RegisterGameItemBoughtEvent("Buy_Weapon_Upgrade_At_Rank", "Rank", LevelManager.instance.levelNumber.ToString(), warbucks);
			Singleton<EventTrackingManager>.instance.DDIEAJKJMFL(KKFOLKGHOJE.PurchaseWeaponUpgrade);
			break;
		}
		case DatabaseAction.BuyUnit:
			if (gold > 0)
			{
				Singleton<EventTrackingManager>.instance.RegisterGameItemBoughtEvent("Buy_Army_Unit_Gold", "Army_Unit_ID", parameter, gold);
				Singleton<EventTrackingManager>.instance.DDIEAJKJMFL(KKFOLKGHOJE.PurchasePremiumUnit);
				Singleton<EventTrackingManager>.instance.RegisterGameItemBoughtEvent("Buy_Army_Unit_At_Rank_Gold", "Rank", LevelManager.instance.levelNumber.ToString(), gold);
			}
			else
			{
				Singleton<EventTrackingManager>.instance.RegisterGameItemBoughtEvent("Buy_Army_Unit", "Army_Unit_ID", parameter, warbucks);
				Singleton<EventTrackingManager>.instance.RegisterGameItemBoughtEvent("Buy_Army_Unit_At_Rank", "Rank", LevelManager.instance.levelNumber.ToString(), warbucks);
				Singleton<EventTrackingManager>.instance.DDIEAJKJMFL(KKFOLKGHOJE.PurchaseSoftUnit);
			}
			break;
		case DatabaseAction.BuyUnitUpgrade:
		{
			Dictionary<string, object> dictionary4 = JsonConvert.DeserializeObject<Dictionary<string, object>>(objData);
			string text4 = "0";
			bool flag = false;
			if (dictionary4.ContainsKey("BoughtIndex"))
			{
				text4 = dictionary4["BoughtIndex"].ToString();
			}
			if (dictionary4.ContainsKey("IsSpecial"))
			{
				flag = dictionary4["IsSpecial"].ToString().Equals("1");
			}
			string fKBHNLOAPAA = ((!flag) ? (parameter + " " + text4) : (parameter + " Special " + text4));
			Singleton<EventTrackingManager>.instance.RegisterGameItemBoughtEvent("Buy_Upgrade_For_Army_Unit", "Army_Unit_ID", fKBHNLOAPAA, warbucks);
			Singleton<EventTrackingManager>.instance.RegisterGameItemBoughtEvent((!flag) ? "Buy_Upgrade_For_Army_Unit_At_Rank" : "Buy_Upgrade_For_Army_Unit_At_Rank_Special", "Rank", LevelManager.instance.levelNumber.ToString(), warbucks);
			Singleton<EventTrackingManager>.instance.DDIEAJKJMFL(KKFOLKGHOJE.PurchaseUnitUpgrade);
			break;
		}
		case DatabaseAction.UpgradeEliteSlot:
		{
			Dictionary<string, object> dictionary3 = JsonConvert.DeserializeObject<Dictionary<string, object>>(objData);
			string text2 = dictionary3["BoughtIndex"].ToString();
			string text3 = dictionary3["LevelName"].ToString();
			string s3 = dictionary3["SpentParts"].ToString();
			string s4 = dictionary3["SpentWarbucks"].ToString();
			Singleton<EventTrackingManager>.instance.RegisterGameItemBoughtElite(text3 + " " + text2, int.Parse(s3), int.Parse(s4));
			break;
		}
		case DatabaseAction.ConvertPartsToScraps:
		{
			Dictionary<string, object> dictionary2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(objData);
			string iOIKKIIFOCB = dictionary2["LevelName"].ToString();
			string s = dictionary2["PartsToConvert"].ToString();
			string s2 = dictionary2["Scraps"].ToString();
			Singleton<EventTrackingManager>.instance.RegisterScrappingParts(iOIKKIIFOCB, int.Parse(s), int.Parse(s2));
			break;
		}
		case DatabaseAction.BuyDecal:
			if (warbucks > 0)
			{
				Singleton<EventTrackingManager>.instance.RegisterGameItemBoughtEvent("Buy_Player_Customizations_Warbucks", "Item_ID", parameter, warbucks);
			}
			else
			{
				Singleton<EventTrackingManager>.instance.RegisterGameItemBoughtEvent("Buy_Player_Customizations_Gold", "Item_ID", parameter, gold);
			}
			break;
		}
		string text5 = string.Empty;
		string text6 = string.Empty;
		string text7 = string.Empty;
		int num = 0;
		if (databaseAction == DatabaseAction.BuyWeapon || databaseAction == DatabaseAction.BuyWeaponUpgrade)
		{
			if (warbucks > 0)
			{
				text5 = "Spend_Warbucks_On_Weapons";
				text7 = ((databaseAction != DatabaseAction.BuyWeapon) ? "Buy_Weapon_Upgrade" : "Buy_Weapon");
				num = warbucks;
			}
			else
			{
				text5 = "Spend_Gold_On_Weapons";
				text6 = ((databaseAction != DatabaseAction.BuyWeapon) ? "Buy_Weapon_Upgrade" : "Buy_Weapon");
				num = gold;
			}
		}
		if (databaseAction == DatabaseAction.BuyUnit || databaseAction == DatabaseAction.BuyUnitUpgrade)
		{
			if (warbucks > 0)
			{
				text5 = "Spend_Warbucks_On_Army";
				num = warbucks;
				text7 = ((databaseAction != DatabaseAction.BuyWeapon) ? "Buy_Unit_Upgrade" : "Buy_Unit");
			}
			else
			{
				text5 = "Spend_Gold_On_Army";
				num = gold;
				text6 = ((databaseAction != DatabaseAction.BuyWeapon) ? "Buy_Unit_Upgrade" : "Buy_Unit");
			}
		}
		if (databaseAction == DatabaseAction.BuyDecal)
		{
			if (warbucks > 0)
			{
				if (!additionalParameter)
				{
					text5 = "Spend_Warbucks_On_Player_Customizations";
					num = warbucks;
				}
			}
			else if (additionalParameter)
			{
				text5 = "Spend_Gold_On_Power_Bands";
				num = gold;
				Singleton<EventTrackingManager>.instance.RegisterPowerBandEvent(objData, gold, true);
			}
			else
			{
				text5 = "Spend_Gold_On_Player_Customizations";
				num = gold;
				Singleton<EventTrackingManager>.instance.DDIEAJKJMFL(KKFOLKGHOJE.PurchaseCosmeticItem);
			}
		}
		if (databaseAction == DatabaseAction.InstantWeaponUpgrade)
		{
			text5 = "Skip_Wait_Weapon_Upgrades";
			num = gold;
			Singleton<EventTrackingManager>.instance.DDIEAJKJMFL(KKFOLKGHOJE.DeliverWeaponUpgrade);
			text6 = "Buy_Instant_Weapon_Upgrade";
		}
		if (databaseAction == DatabaseAction.InstantUnitUpgrade)
		{
			text5 = "Skip_Wait_Unit_Upgrades";
			num = gold;
			Singleton<EventTrackingManager>.instance.DDIEAJKJMFL(KKFOLKGHOJE.DeliverUnitUpgrade);
			text6 = "Buy_Instant_Unit_Upgrade";
		}
		if (databaseAction == DatabaseAction.BuyCardPack)
		{
			if (gold > 0)
			{
				text5 = "Spend_Gold_On_Card_Packs";
				num = gold;
				text6 = "Buy_Card_Pack";
			}
			Singleton<EventTrackingManager>.instance.RegisterBuyCardPackEvent(parameter, num, gold > 0);
		}
		if (!string.IsNullOrEmpty(text6))
		{
			Singleton<EventTrackingManager>.instance.RegisterGoldOut(text6, gold);
		}
		if (!string.IsNullOrEmpty(text7))
		{
			Singleton<EventTrackingManager>.instance.RegisterWBOut(text7, warbucks);
		}
		if (num != 0 && !string.IsNullOrEmpty(text5))
		{
			Singleton<EventTrackingManager>.instance.RegisterEconomyEvent(text5, num);
		}
		requests.Add(requestCount++, value);
		if (mWaitingRoutine != null)
		{
			mWaitingRoutine.Cancel();
			mWaitingRoutine = RadicalRoutine.Create(WaitAndSend(mTimeOut));
			RequestBufferManager.instance.StartCoroutine(RadicalRoutine.Run(mWaitingRoutine.enumerator));
		}
		RequestBufferManager.instance.Save();
		PushNotificationManager.instance.ScheduleLocalNotifications(databaseAction);
	}

	public void Send()
	{
		UnityEngine.Debug.Log("RequestBuffer " + id + ": sending via Beanstalk(request count =" + requestCount + ")");
		if (alreadySent)
		{
			UnityEngine.Debug.LogError("Buffer already sent!");
			RequestBufferManager.instance.RemoveRequestBuffer(id);
		}
		else
		{
			alreadySent = true;
			Singleton<BeanstalkServerManager>.instance.JEFCEEEJMLG(id, requests, requestCount);
		}
	}

	internal void Init(string bufferId, float timeOut)
	{
		requestCount = 0;
		id = bufferId;
		mTimeOut = timeOut;
		mWaitingRoutine = RadicalRoutine.Create(WaitAndSend(mTimeOut));
		RequestBufferManager.instance.StartCoroutine(RadicalRoutine.Run(mWaitingRoutine.enumerator));
		requests = new Dictionary<int, Request>();
		alreadySent = false;
	}

	internal void Init(string bufferId)
	{
		requestCount = 0;
		id = bufferId;
		requests = new Dictionary<int, Request>();
		alreadySent = false;
	}

	[DebuggerHidden]
	private IEnumerator WaitAndSend(float waitTime)
	{
		PDPMFPGALHI pDPMFPGALHI = new PDPMFPGALHI();
		pDPMFPGALHI.HJGIAOJHNJB = waitTime;
		pDPMFPGALHI.BJGCPDNMHDH = this;
		return pDPMFPGALHI;
	}
}
