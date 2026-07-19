using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class IntroductionDealsItem : MonoBehaviour
{
	[Serializable]
	public class WidgetAlpha
	{
		public GameObject element;

		public float alpha = 1f;
	}

	private sealed class NAABLHNJHDD : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal List<WidgetAlpha>.Enumerator KFCAECGLKKO;

		internal float KBJEOEEOEFG;

		internal IntroductionDealsItem BJGCPDNMHDH;

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
				KFCAECGLKKO = BJGCPDNMHDH.LPEIOHAMKJJ.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						WidgetAlpha current = KFCAECGLKKO.Current;
						TweenAlpha.Begin(current.element, KBJEOEEOEFG, 1984f);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				if (KBJEOEEOEFG > 825f)
				{
					PHDOCKCBJOF = new WaitForSeconds(KBJEOEEOEFG);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				BJGCPDNMHDH.OPPAADCPKCL();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public bool DDLMLOJGJMA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.LPEIOHAMKJJ.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						WidgetAlpha current = KFCAECGLKKO.Current;
						TweenAlpha.Begin(current.element, KBJEOEEOEFG, 1586f);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				if (KBJEOEEOEFG > 1371f)
				{
					PHDOCKCBJOF = new WaitForSeconds(KBJEOEEOEFG);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				BJGCPDNMHDH.JFOIMNILIHE();
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
				KFCAECGLKKO = BJGCPDNMHDH.LPEIOHAMKJJ.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						WidgetAlpha current = KFCAECGLKKO.Current;
						TweenAlpha.Begin(current.element, KBJEOEEOEFG, 1768f);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				if (KBJEOEEOEFG > 612f)
				{
					PHDOCKCBJOF = new WaitForSeconds(KBJEOEEOEFG);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				BJGCPDNMHDH.JFOIMNILIHE();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public bool KDFAHLNCNMN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.LPEIOHAMKJJ.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						WidgetAlpha current = KFCAECGLKKO.Current;
						TweenAlpha.Begin(current.element, KBJEOEEOEFG, 1030f);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				if (KBJEOEEOEFG > 1493f)
				{
					PHDOCKCBJOF = new WaitForSeconds(KBJEOEEOEFG);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				BJGCPDNMHDH.JFOIMNILIHE();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void HGCHEPGNHNP()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MPEPJNIDBLI()
		{
			return PHDOCKCBJOF;
		}

		public void HHCBBENDENJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object KIHECHEHNJJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MHKODCGLJFD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LAENBDAPNJL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HFKDIPEKENH()
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
				KFCAECGLKKO = BJGCPDNMHDH.LPEIOHAMKJJ.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						WidgetAlpha current = KFCAECGLKKO.Current;
						TweenAlpha.Begin(current.element, KBJEOEEOEFG, 0f);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				if (KBJEOEEOEFG > 0f)
				{
					PHDOCKCBJOF = new WaitForSeconds(KBJEOEEOEFG);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				BJGCPDNMHDH.OPPAADCPKCL();
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
		private object KBNAGKKMLBP()
		{
			return PHDOCKCBJOF;
		}

		public void EPKPNKGJHEC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool ICKNHCBNOMG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.LPEIOHAMKJJ.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						WidgetAlpha current = KFCAECGLKKO.Current;
						TweenAlpha.Begin(current.element, KBJEOEEOEFG, 434f);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				if (KBJEOEEOEFG > 1211f)
				{
					PHDOCKCBJOF = new WaitForSeconds(KBJEOEEOEFG);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				BJGCPDNMHDH.OPPAADCPKCL();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public bool NJBCJDFKGHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.LPEIOHAMKJJ.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						WidgetAlpha current = KFCAECGLKKO.Current;
						TweenAlpha.Begin(current.element, KBJEOEEOEFG, 735f);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				if (KBJEOEEOEFG > 657f)
				{
					PHDOCKCBJOF = new WaitForSeconds(KBJEOEEOEFG);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				BJGCPDNMHDH.JFOIMNILIHE();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void IJHCIJLDKHK()
		{
			throw new NotSupportedException();
		}

		public void KGLKGNBCPLM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public NAABLHNJHDD()
		{
		}

		[SpecialName]
		private object CLDLJNHAEAB()
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
				KFCAECGLKKO = BJGCPDNMHDH.LPEIOHAMKJJ.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						WidgetAlpha current = KFCAECGLKKO.Current;
						TweenAlpha.Begin(current.element, KBJEOEEOEFG, 1995f);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				if (KBJEOEEOEFG > 1710f)
				{
					PHDOCKCBJOF = new WaitForSeconds(KBJEOEEOEFG);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				BJGCPDNMHDH.MGCJKMEEDCG();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object GDCFFBBNGHH()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IGMIIAODMNF()
		{
			return PHDOCKCBJOF;
		}

		public void IKNKDDMLDIN()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IHAOBCEALPD()
		{
			return PHDOCKCBJOF;
		}
	}

	private sealed class JBOGKOPAPPN : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal List<WidgetAlpha>.Enumerator KFCAECGLKKO;

		internal float KBJEOEEOEFG;

		internal IntroductionDealsItem BJGCPDNMHDH;

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
		private object BMAMEPNHHFI()
		{
			return PHDOCKCBJOF;
		}

		public void CDIJEGGMMAK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void IJHCIJLDKHK()
		{
			throw new NotSupportedException();
		}

		public void ABBPOMCBIIH()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CICPCKDCCEF()
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
				KFCAECGLKKO = BJGCPDNMHDH.LPEIOHAMKJJ.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						WidgetAlpha current = KFCAECGLKKO.Current;
						TweenAlpha.Begin(current.element, KBJEOEEOEFG, current.alpha);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				TweenColorSpecial.MDBMAINKPKG(GuiScreenSingle<MainScreen>.instance.HIPDGKKHODB.GJIGEFJAKNM.gameObject, KBJEOEEOEFG, BJGCPDNMHDH.CKOECFCJBJE);
				TweenColorSpecial.JPOJDFCHEGB(GuiScreenSingle<MainScreen>.instance.HIPDGKKHODB.FNGFNNOIOCD.gameObject, KBJEOEEOEFG, BJGCPDNMHDH.CKOECFCJBJE);
				TweenAlpha.Begin(GuiScreenSingle<MainScreen>.instance.HIPDGKKHODB.KMFGCJEGJJK.gameObject, KBJEOEEOEFG, BJGCPDNMHDH.DIBNEJCCAIA);
				BJGCPDNMHDH.MFOEIGPEJFP();
				if (KBJEOEEOEFG > 1220f)
				{
					PHDOCKCBJOF = new WaitForSeconds(KBJEOEEOEFG);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				BJGCPDNMHDH.OKPHOBDPFHL = TimeManager.realTimeWithoutPauses + BJGCPDNMHDH.MEHFCECFLHP;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void MKIKEOOOLKL()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object IDLFKAKINAP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DFHCLJNONGC()
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
				KFCAECGLKKO = BJGCPDNMHDH.LPEIOHAMKJJ.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						WidgetAlpha current = KFCAECGLKKO.Current;
						TweenAlpha.Begin(current.element, KBJEOEEOEFG, current.alpha);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				TweenColorSpecial.LEMANGJFIPE(GuiScreenSingle<MainScreen>.instance.HIPDGKKHODB.GJIGEFJAKNM.gameObject, KBJEOEEOEFG, BJGCPDNMHDH.CKOECFCJBJE);
				TweenColorSpecial.LEMANGJFIPE(GuiScreenSingle<MainScreen>.instance.HIPDGKKHODB.FNGFNNOIOCD.gameObject, KBJEOEEOEFG, BJGCPDNMHDH.CKOECFCJBJE);
				TweenAlpha.Begin(GuiScreenSingle<MainScreen>.instance.HIPDGKKHODB.KMFGCJEGJJK.gameObject, KBJEOEEOEFG, BJGCPDNMHDH.DIBNEJCCAIA);
				BJGCPDNMHDH.HNDOGAHDADL();
				if (KBJEOEEOEFG > 96f)
				{
					PHDOCKCBJOF = new WaitForSeconds(KBJEOEEOEFG);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				BJGCPDNMHDH.OKPHOBDPFHL = TimeManager.CEAFAMFNGCC() + BJGCPDNMHDH.MEHFCECFLHP;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void MKACBCOLNKD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public JBOGKOPAPPN()
		{
		}

		public void LOOMFHNKAND()
		{
			throw new NotSupportedException();
		}

		public bool HOOHJGPHHGN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.LPEIOHAMKJJ.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						WidgetAlpha current = KFCAECGLKKO.Current;
						TweenAlpha.Begin(current.element, KBJEOEEOEFG, current.alpha);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				TweenColorSpecial.IJIDNJACAMO(GuiScreenSingle<MainScreen>.instance.HIPDGKKHODB.GJIGEFJAKNM.gameObject, KBJEOEEOEFG, BJGCPDNMHDH.CKOECFCJBJE);
				TweenColorSpecial.KMDIDKBDCDM(GuiScreenSingle<MainScreen>.instance.HIPDGKKHODB.FNGFNNOIOCD.gameObject, KBJEOEEOEFG, BJGCPDNMHDH.CKOECFCJBJE);
				TweenAlpha.Begin(GuiScreenSingle<MainScreen>.instance.HIPDGKKHODB.KMFGCJEGJJK.gameObject, KBJEOEEOEFG, BJGCPDNMHDH.DIBNEJCCAIA);
				BJGCPDNMHDH.HNDOGAHDADL();
				if (KBJEOEEOEFG > 618f)
				{
					PHDOCKCBJOF = new WaitForSeconds(KBJEOEEOEFG);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				BJGCPDNMHDH.OKPHOBDPFHL = TimeManager.realTimeWithoutPauses + BJGCPDNMHDH.MEHFCECFLHP;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object AGCPJGAAODG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IBCJOBKGEEG()
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
				KFCAECGLKKO = BJGCPDNMHDH.LPEIOHAMKJJ.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						WidgetAlpha current = KFCAECGLKKO.Current;
						TweenAlpha.Begin(current.element, KBJEOEEOEFG, current.alpha);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				TweenColorSpecial.HMAJBKEOBMJ(GuiScreenSingle<MainScreen>.instance.HIPDGKKHODB.GJIGEFJAKNM.gameObject, KBJEOEEOEFG, BJGCPDNMHDH.CKOECFCJBJE);
				TweenColorSpecial.JPOJDFCHEGB(GuiScreenSingle<MainScreen>.instance.HIPDGKKHODB.FNGFNNOIOCD.gameObject, KBJEOEEOEFG, BJGCPDNMHDH.CKOECFCJBJE);
				TweenAlpha.Begin(GuiScreenSingle<MainScreen>.instance.HIPDGKKHODB.KMFGCJEGJJK.gameObject, KBJEOEEOEFG, BJGCPDNMHDH.DIBNEJCCAIA);
				BJGCPDNMHDH.HNDOGAHDADL();
				if (KBJEOEEOEFG > 1515f)
				{
					PHDOCKCBJOF = new WaitForSeconds(KBJEOEEOEFG);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				BJGCPDNMHDH.OKPHOBDPFHL = TimeManager.realTimeWithoutPauses + BJGCPDNMHDH.MEHFCECFLHP;
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
		private object BOOBHEKPLLD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PFMFFMEJBPM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BLOJDIFOPIA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PEGJNAKGHCC()
		{
			return PHDOCKCBJOF;
		}

		public void GFPDOCDEGPA()
		{
			throw new NotSupportedException();
		}

		public void FIAPMEMIIKB()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object OAMLLHEMBIK()
		{
			return PHDOCKCBJOF;
		}

		public void OMDFNFHKFBK()
		{
			throw new NotSupportedException();
		}

		public bool KDFAHLNCNMN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.LPEIOHAMKJJ.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						WidgetAlpha current = KFCAECGLKKO.Current;
						TweenAlpha.Begin(current.element, KBJEOEEOEFG, current.alpha);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				TweenColorSpecial.JPOJDFCHEGB(GuiScreenSingle<MainScreen>.instance.HIPDGKKHODB.GJIGEFJAKNM.gameObject, KBJEOEEOEFG, BJGCPDNMHDH.CKOECFCJBJE);
				TweenColorSpecial.Begin(GuiScreenSingle<MainScreen>.instance.HIPDGKKHODB.FNGFNNOIOCD.gameObject, KBJEOEEOEFG, BJGCPDNMHDH.CKOECFCJBJE);
				TweenAlpha.Begin(GuiScreenSingle<MainScreen>.instance.HIPDGKKHODB.KMFGCJEGJJK.gameObject, KBJEOEEOEFG, BJGCPDNMHDH.DIBNEJCCAIA);
				BJGCPDNMHDH.HNDOGAHDADL();
				if (KBJEOEEOEFG > 992f)
				{
					PHDOCKCBJOF = new WaitForSeconds(KBJEOEEOEFG);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				BJGCPDNMHDH.OKPHOBDPFHL = TimeManager.CEAFAMFNGCC() + BJGCPDNMHDH.MEHFCECFLHP;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void NINFHADPHJI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object OJKHNOHHDGO()
		{
			return PHDOCKCBJOF;
		}

		public void DEPEHNFEJEE()
		{
			throw new NotSupportedException();
		}

		public void BCKMHLBBBCK()
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
				KFCAECGLKKO = BJGCPDNMHDH.LPEIOHAMKJJ.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						WidgetAlpha current = KFCAECGLKKO.Current;
						TweenAlpha.Begin(current.element, KBJEOEEOEFG, current.alpha);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				TweenColorSpecial.Begin(GuiScreenSingle<MainScreen>.instance.HIPDGKKHODB.GJIGEFJAKNM.gameObject, KBJEOEEOEFG, BJGCPDNMHDH.CKOECFCJBJE);
				TweenColorSpecial.IHPAHOHIOPC(GuiScreenSingle<MainScreen>.instance.HIPDGKKHODB.FNGFNNOIOCD.gameObject, KBJEOEEOEFG, BJGCPDNMHDH.CKOECFCJBJE);
				TweenAlpha.Begin(GuiScreenSingle<MainScreen>.instance.HIPDGKKHODB.KMFGCJEGJJK.gameObject, KBJEOEEOEFG, BJGCPDNMHDH.DIBNEJCCAIA);
				BJGCPDNMHDH.HNDOGAHDADL();
				if (KBJEOEEOEFG > 1295f)
				{
					PHDOCKCBJOF = new WaitForSeconds(KBJEOEEOEFG);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				BJGCPDNMHDH.OKPHOBDPFHL = TimeManager.realTimeWithoutPauses + BJGCPDNMHDH.MEHFCECFLHP;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object IGFMIFOHCHJ()
		{
			return PHDOCKCBJOF;
		}

		public void CFHJPHLFONO()
		{
			throw new NotSupportedException();
		}

		public void MAKKCANEHIB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object KKKMCHGLHLL()
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
				KFCAECGLKKO = BJGCPDNMHDH.LPEIOHAMKJJ.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						WidgetAlpha current = KFCAECGLKKO.Current;
						TweenAlpha.Begin(current.element, KBJEOEEOEFG, current.alpha);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				TweenColorSpecial.GMLNHEIJHDE(GuiScreenSingle<MainScreen>.instance.HIPDGKKHODB.GJIGEFJAKNM.gameObject, KBJEOEEOEFG, BJGCPDNMHDH.CKOECFCJBJE);
				TweenColorSpecial.PDFHNDPEEMA(GuiScreenSingle<MainScreen>.instance.HIPDGKKHODB.FNGFNNOIOCD.gameObject, KBJEOEEOEFG, BJGCPDNMHDH.CKOECFCJBJE);
				TweenAlpha.Begin(GuiScreenSingle<MainScreen>.instance.HIPDGKKHODB.KMFGCJEGJJK.gameObject, KBJEOEEOEFG, BJGCPDNMHDH.DIBNEJCCAIA);
				BJGCPDNMHDH.MFOEIGPEJFP();
				if (KBJEOEEOEFG > 936f)
				{
					PHDOCKCBJOF = new WaitForSeconds(KBJEOEEOEFG);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				BJGCPDNMHDH.OKPHOBDPFHL = TimeManager.realTimeWithoutPauses + BJGCPDNMHDH.MEHFCECFLHP;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object GKJIGGAAHBE()
		{
			return PHDOCKCBJOF;
		}

		public void FLFOEIMCFBL()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void GGLMLMFEJCD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void CPOKHODGGLN()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BGLDNJLBIKM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CLDLJNHAEAB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MHKODCGLJFD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OJMKDIBHMND()
		{
			return PHDOCKCBJOF;
		}

		public void NGAGGCFIEGJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IAMNDODCIEB()
		{
			return PHDOCKCBJOF;
		}

		public void NINFNJOMJOD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HJFIBBBPDKK()
		{
			return PHDOCKCBJOF;
		}

		public void CKEOKOKAAPB()
		{
			throw new NotSupportedException();
		}

		public bool FCJCLBMPBFK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.LPEIOHAMKJJ.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						WidgetAlpha current = KFCAECGLKKO.Current;
						TweenAlpha.Begin(current.element, KBJEOEEOEFG, current.alpha);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				TweenColorSpecial.AHFIPGHPDHH(GuiScreenSingle<MainScreen>.instance.HIPDGKKHODB.GJIGEFJAKNM.gameObject, KBJEOEEOEFG, BJGCPDNMHDH.CKOECFCJBJE);
				TweenColorSpecial.AHFIPGHPDHH(GuiScreenSingle<MainScreen>.instance.HIPDGKKHODB.FNGFNNOIOCD.gameObject, KBJEOEEOEFG, BJGCPDNMHDH.CKOECFCJBJE);
				TweenAlpha.Begin(GuiScreenSingle<MainScreen>.instance.HIPDGKKHODB.KMFGCJEGJJK.gameObject, KBJEOEEOEFG, BJGCPDNMHDH.DIBNEJCCAIA);
				BJGCPDNMHDH.DLNFBJHHGBK();
				if (KBJEOEEOEFG > 1191f)
				{
					PHDOCKCBJOF = new WaitForSeconds(KBJEOEEOEFG);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				BJGCPDNMHDH.OKPHOBDPFHL = TimeManager.CEAFAMFNGCC() + BJGCPDNMHDH.MEHFCECFLHP;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void GFGEEFGMNDP()
		{
			throw new NotSupportedException();
		}

		public void CPDBCJLIGFN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object DKPOLLDBPAP()
		{
			return PHDOCKCBJOF;
		}

		public void ENFGGBNAPGG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object CMNCAPEMEJI()
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
				KFCAECGLKKO = BJGCPDNMHDH.LPEIOHAMKJJ.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						WidgetAlpha current = KFCAECGLKKO.Current;
						TweenAlpha.Begin(current.element, KBJEOEEOEFG, current.alpha);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				TweenColorSpecial.JPOJDFCHEGB(GuiScreenSingle<MainScreen>.instance.HIPDGKKHODB.GJIGEFJAKNM.gameObject, KBJEOEEOEFG, BJGCPDNMHDH.CKOECFCJBJE);
				TweenColorSpecial.KMDIDKBDCDM(GuiScreenSingle<MainScreen>.instance.HIPDGKKHODB.FNGFNNOIOCD.gameObject, KBJEOEEOEFG, BJGCPDNMHDH.CKOECFCJBJE);
				TweenAlpha.Begin(GuiScreenSingle<MainScreen>.instance.HIPDGKKHODB.KMFGCJEGJJK.gameObject, KBJEOEEOEFG, BJGCPDNMHDH.DIBNEJCCAIA);
				BJGCPDNMHDH.NAPALFCBIPE();
				if (KBJEOEEOEFG > 745f)
				{
					PHDOCKCBJOF = new WaitForSeconds(KBJEOEEOEFG);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				BJGCPDNMHDH.OKPHOBDPFHL = TimeManager.realTimeWithoutPauses + BJGCPDNMHDH.MEHFCECFLHP;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object NOIDHHDEEPL()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void IHAHCOPGPIM()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void JKOCLGOOBEK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object AIDHNJCPDIJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JDKFIHJHNJC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GPKBICHIBHF()
		{
			return PHDOCKCBJOF;
		}

		public void KIPDKEKMDFE()
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
				KFCAECGLKKO = BJGCPDNMHDH.LPEIOHAMKJJ.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						WidgetAlpha current = KFCAECGLKKO.Current;
						TweenAlpha.Begin(current.element, KBJEOEEOEFG, current.alpha);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				TweenColorSpecial.Begin(GuiScreenSingle<MainScreen>.instance.HIPDGKKHODB.GJIGEFJAKNM.gameObject, KBJEOEEOEFG, BJGCPDNMHDH.CKOECFCJBJE);
				TweenColorSpecial.Begin(GuiScreenSingle<MainScreen>.instance.HIPDGKKHODB.FNGFNNOIOCD.gameObject, KBJEOEEOEFG, BJGCPDNMHDH.CKOECFCJBJE);
				TweenAlpha.Begin(GuiScreenSingle<MainScreen>.instance.HIPDGKKHODB.KMFGCJEGJJK.gameObject, KBJEOEEOEFG, BJGCPDNMHDH.DIBNEJCCAIA);
				BJGCPDNMHDH.DLNFBJHHGBK();
				if (KBJEOEEOEFG > 0f)
				{
					PHDOCKCBJOF = new WaitForSeconds(KBJEOEEOEFG);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				BJGCPDNMHDH.OKPHOBDPFHL = TimeManager.realTimeWithoutPauses + BJGCPDNMHDH.MEHFCECFLHP;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public bool PIAOIBJMLCC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.LPEIOHAMKJJ.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						WidgetAlpha current = KFCAECGLKKO.Current;
						TweenAlpha.Begin(current.element, KBJEOEEOEFG, current.alpha);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				TweenColorSpecial.NFCEEJODFMO(GuiScreenSingle<MainScreen>.instance.HIPDGKKHODB.GJIGEFJAKNM.gameObject, KBJEOEEOEFG, BJGCPDNMHDH.CKOECFCJBJE);
				TweenColorSpecial.MDBMAINKPKG(GuiScreenSingle<MainScreen>.instance.HIPDGKKHODB.FNGFNNOIOCD.gameObject, KBJEOEEOEFG, BJGCPDNMHDH.CKOECFCJBJE);
				TweenAlpha.Begin(GuiScreenSingle<MainScreen>.instance.HIPDGKKHODB.KMFGCJEGJJK.gameObject, KBJEOEEOEFG, BJGCPDNMHDH.DIBNEJCCAIA);
				BJGCPDNMHDH.DLNFBJHHGBK();
				if (KBJEOEEOEFG > 1695f)
				{
					PHDOCKCBJOF = new WaitForSeconds(KBJEOEEOEFG);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				BJGCPDNMHDH.OKPHOBDPFHL = TimeManager.CEAFAMFNGCC() + BJGCPDNMHDH.MEHFCECFLHP;
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

		public void MENEBJLDGJD()
		{
			throw new NotSupportedException();
		}

		public void CHANLKFNCLA()
		{
			throw new NotSupportedException();
		}

		public bool FPMHODJKAKK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = BJGCPDNMHDH.LPEIOHAMKJJ.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						WidgetAlpha current = KFCAECGLKKO.Current;
						TweenAlpha.Begin(current.element, KBJEOEEOEFG, current.alpha);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				TweenColorSpecial.IJIDNJACAMO(GuiScreenSingle<MainScreen>.instance.HIPDGKKHODB.GJIGEFJAKNM.gameObject, KBJEOEEOEFG, BJGCPDNMHDH.CKOECFCJBJE);
				TweenColorSpecial.Begin(GuiScreenSingle<MainScreen>.instance.HIPDGKKHODB.FNGFNNOIOCD.gameObject, KBJEOEEOEFG, BJGCPDNMHDH.CKOECFCJBJE);
				TweenAlpha.Begin(GuiScreenSingle<MainScreen>.instance.HIPDGKKHODB.KMFGCJEGJJK.gameObject, KBJEOEEOEFG, BJGCPDNMHDH.DIBNEJCCAIA);
				BJGCPDNMHDH.HNDOGAHDADL();
				if (KBJEOEEOEFG > 1837f)
				{
					PHDOCKCBJOF = new WaitForSeconds(KBJEOEEOEFG);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			case 1u:
				BJGCPDNMHDH.OKPHOBDPFHL = TimeManager.realTimeWithoutPauses + BJGCPDNMHDH.MEHFCECFLHP;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object ADNCCLOOEAD()
		{
			return PHDOCKCBJOF;
		}
	}

	private sealed class ENJNCINNAFG : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal float KBJEOEEOEFG;

		internal IntroductionDealsItem BJGCPDNMHDH;

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

		public void OAFPDIHGJDC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void IJHCIJLDKHK()
		{
			throw new NotSupportedException();
		}

		public bool PKOMECFNPIP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.OKPHOBDPFHL = TimeManager.realTimeWithoutPauses + KBJEOEEOEFG * 573f;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.Hide(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LOFMDBHAFAO(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object FONIPEGACDN()
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
				BJGCPDNMHDH.OKPHOBDPFHL = TimeManager.realTimeWithoutPauses + KBJEOEEOEFG * 1052f;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.GDLOAPIHMOB(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.Show(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object IILJADPOOCO()
		{
			return PHDOCKCBJOF;
		}

		public void JAGFOHHEPLO()
		{
			throw new NotSupportedException();
		}

		public bool IIJKAMFGNKA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.OKPHOBDPFHL = TimeManager.realTimeWithoutPauses + KBJEOEEOEFG * 1499f;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.EPCEHACNCNH(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.DMLDBKFCACB(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object FPFOODLPEBK()
		{
			return PHDOCKCBJOF;
		}

		public void OCBFBEMDMMJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void JBHOCIFIMBH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void ANOPOLIEBMC()
		{
			throw new NotSupportedException();
		}

		public void NAMBILMHOPD()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public ENJNCINNAFG()
		{
		}

		[SpecialName]
		private object AKGMMLGANMJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DEOOBMKFKDE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GMEIAAMCBGA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MHKODCGLJFD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MLDIMIPJMDD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ABGFJLAPNNM()
		{
			return PHDOCKCBJOF;
		}

		public void MKACBCOLNKD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool EBLHEEKHANA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.OKPHOBDPFHL = TimeManager.realTimeWithoutPauses + KBJEOEEOEFG * 1847f;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.NDODOLKAABG(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.ONCKKJFAMKF(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object EGJDJENBABP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HHHLDCLIFKJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CIHKIABJBGJ()
		{
			return PHDOCKCBJOF;
		}

		public bool DEEBEBGBMKK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.OKPHOBDPFHL = TimeManager.realTimeWithoutPauses + KBJEOEEOEFG * 1029f;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.OMCADBPJEOL(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.DMLDBKFCACB(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public bool BJIPDEICIML()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.OKPHOBDPFHL = TimeManager.realTimeWithoutPauses + KBJEOEEOEFG * 1757f;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.GDLOAPIHMOB(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.ONCKKJFAMKF(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void FJOIBBIGBJC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GPKBICHIBHF()
		{
			return PHDOCKCBJOF;
		}

		public void GBGMIJNBLNH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HOFJFOCEKJJ()
		{
			throw new NotSupportedException();
		}

		public void HHCBBENDENJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool GNFCLHDPPFP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.OKPHOBDPFHL = TimeManager.CEAFAMFNGCC() + KBJEOEEOEFG * 190f;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.NDODOLKAABG(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.ONCKKJFAMKF(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void BCIPEBNJONK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void FFNAPBHOACE()
		{
			throw new NotSupportedException();
		}

		public void GGMKKIDFJOH()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object LMLPPCCDELM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NDIGINEEOMH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CPJCCMLEPCE()
		{
			return PHDOCKCBJOF;
		}

		public bool LHNFELIIMGD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.OKPHOBDPFHL = TimeManager.CEAFAMFNGCC() + KBJEOEEOEFG * 1796f;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.OCAEJPMPBMH(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LOFMDBHAFAO(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
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
				BJGCPDNMHDH.OKPHOBDPFHL = TimeManager.realTimeWithoutPauses + KBJEOEEOEFG * 3f;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.GDLOAPIHMOB(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.ONCKKJFAMKF(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void NBGFOILFGHD()
		{
			throw new NotSupportedException();
		}

		public void KAFNGNMNNOA()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BJDOHADMIEB()
		{
			return PHDOCKCBJOF;
		}

		public bool DLAPDOPMBNE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.OKPHOBDPFHL = TimeManager.realTimeWithoutPauses + KBJEOEEOEFG * 461f;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.OCAEJPMPBMH(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.DMLDBKFCACB(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object CGNOIKAGEMC()
		{
			return PHDOCKCBJOF;
		}

		public void JKBIMBFGGCO()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KMCGJFDPBCB()
		{
			return PHDOCKCBJOF;
		}

		public void PNGIELILHDI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void MOJGMBNBGHH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HEOPOOMLPJF()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FJGIOPMDPGA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FHOGCOKPBKL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MCPPGAGMDGB()
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
				BJGCPDNMHDH.OKPHOBDPFHL = TimeManager.CEAFAMFNGCC() + KBJEOEEOEFG * 1418f;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.GDLOAPIHMOB(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.ONCKKJFAMKF(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public bool MKLIDMNLNPN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.OKPHOBDPFHL = TimeManager.realTimeWithoutPauses + KBJEOEEOEFG * 1220f;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.Hide(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LOFMDBHAFAO(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void FCHOHLMCHED()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GNACDOOHMMG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IGMIIAODMNF()
		{
			return PHDOCKCBJOF;
		}

		public void AJEIGCJPEFN()
		{
			throw new NotSupportedException();
		}

		public bool CJGDOJHLOII()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.OKPHOBDPFHL = TimeManager.CEAFAMFNGCC() + KBJEOEEOEFG * 438f;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.OMCADBPJEOL(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.ONCKKJFAMKF(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void FILDGEMDECJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object EPNOIENCFGA()
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
				BJGCPDNMHDH.OKPHOBDPFHL = TimeManager.CEAFAMFNGCC() + KBJEOEEOEFG * 537f;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.EPCEHACNCNH(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.Show(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void PMAJELGBBKE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object DAAINALAFOJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HADIFBCDICK()
		{
			return PHDOCKCBJOF;
		}

		public void ABBPOMCBIIH()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FCBCEDKNBKC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PKEABJICHAI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MOMPOEEALPJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DGEECEBHPNC()
		{
			return PHDOCKCBJOF;
		}

		public void KHMNEOBMJLN()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MNAKOOGPNOH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AGANCOFPDCK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JMKGAJNOLEM()
		{
			return PHDOCKCBJOF;
		}

		public bool IBEPOFJDKLG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.OKPHOBDPFHL = TimeManager.realTimeWithoutPauses + KBJEOEEOEFG * 902f;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.Hide(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LOFMDBHAFAO(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void DECFCNMMOAG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object OHCAEJILBKE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NAAMAOJBKBK()
		{
			return PHDOCKCBJOF;
		}

		public void GGLMLMFEJCD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GEFKCGOOFFP()
		{
			return PHDOCKCBJOF;
		}

		public bool GCEBFCBBEKM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.OKPHOBDPFHL = TimeManager.CEAFAMFNGCC() + KBJEOEEOEFG * 1553f;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.OMCADBPJEOL(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.Show(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void EHMOLOCPIGB()
		{
			throw new NotSupportedException();
		}

		public void CHANLKFNCLA()
		{
			throw new NotSupportedException();
		}

		public void BKGBMJMNJCD()
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
				BJGCPDNMHDH.OKPHOBDPFHL = TimeManager.CEAFAMFNGCC() + KBJEOEEOEFG * 2f;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.Hide(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.ONCKKJFAMKF(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object HKABKPOFMIJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GOOABACIPKD()
		{
			return PHDOCKCBJOF;
		}

		public bool JNHFCKKAPJH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.OKPHOBDPFHL = TimeManager.CEAFAMFNGCC() + KBJEOEEOEFG * 1553f;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.OCAEJPMPBMH(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.ONCKKJFAMKF(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object AJPFLBOOFNJ()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HJLCPFDBNKP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void LHADJAFHDDC()
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
				BJGCPDNMHDH.OKPHOBDPFHL = TimeManager.CEAFAMFNGCC() + KBJEOEEOEFG * 1638f;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.OMCADBPJEOL(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.DMLDBKFCACB(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
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
		private object IHDBAJNCNGN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object INHIPKJFGDI()
		{
			return PHDOCKCBJOF;
		}

		public void GOCCDFALOHI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object OJEDLKAFEIN()
		{
			return PHDOCKCBJOF;
		}

		public bool MPKAJACHAIC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.OKPHOBDPFHL = TimeManager.realTimeWithoutPauses + KBJEOEEOEFG * 844f;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.OCAEJPMPBMH(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.DMLDBKFCACB(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object PCELHKMHCOB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FKJJFNMBKOP()
		{
			return PHDOCKCBJOF;
		}

		public bool KAIHNOCLNHK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.OKPHOBDPFHL = TimeManager.realTimeWithoutPauses + KBJEOEEOEFG * 675f;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.NDODOLKAABG(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LOFMDBHAFAO(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public bool IGKACECJBEB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.OKPHOBDPFHL = TimeManager.realTimeWithoutPauses + KBJEOEEOEFG * 301f;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.EPCEHACNCNH(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.DMLDBKFCACB(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object CEFJKELIBGG()
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
				BJGCPDNMHDH.OKPHOBDPFHL = TimeManager.CEAFAMFNGCC() + KBJEOEEOEFG * 1187f;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.NDODOLKAABG(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.Show(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object EPGLILIJMEM()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void CFLPOEJGKFF()
		{
			throw new NotSupportedException();
		}

		public void IMFLNKIMEFA()
		{
			throw new NotSupportedException();
		}

		public void FGLAPPKJHBK()
		{
			throw new NotSupportedException();
		}

		public bool KKINHOPBKLH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.OKPHOBDPFHL = TimeManager.CEAFAMFNGCC() + KBJEOEEOEFG * 1425f;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.NDODOLKAABG(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.DMLDBKFCACB(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.OKPHOBDPFHL = TimeManager.realTimeWithoutPauses + KBJEOEEOEFG * 2f;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.Hide(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.Show(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void COGFDADOPLD()
		{
			throw new NotSupportedException();
		}

		public void FAOLFOHEEGF()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool AELAICNOAPN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.OKPHOBDPFHL = TimeManager.CEAFAMFNGCC() + KBJEOEEOEFG * 998f;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.NDODOLKAABG(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.ONCKKJFAMKF(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void LICALBFPBLL()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JDECDOJJAAH()
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
				BJGCPDNMHDH.OKPHOBDPFHL = TimeManager.realTimeWithoutPauses + KBJEOEEOEFG * 1298f;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.EPCEHACNCNH(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.ONCKKJFAMKF(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void GFPAMDPNMKG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void HKFEFDNFKKK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object LAENBDAPNJL()
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
				BJGCPDNMHDH.OKPHOBDPFHL = TimeManager.CEAFAMFNGCC() + KBJEOEEOEFG * 1834f;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.Hide(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.ONCKKJFAMKF(KBJEOEEOEFG));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}
	}

	[Header("Core")]
	public List<WidgetAlpha> LPEIOHAMKJJ;

	public float MEHFCECFLHP = 3f;

	public Color CKOECFCJBJE;

	public float DIBNEJCCAIA = 0.5f;

	[Header("Weapon Texture")]
	public UITexture NGHCDIMLGMO;

	public string NLAPDGJOBOK;

	protected float OKPHOBDPFHL;

	private bool DBLMMAGBMND;

	public virtual bool hasMoreLooks
	{
		get
		{
			return false;
		}
	}

	public virtual bool isLastLook
	{
		get
		{
			return true;
		}
	}

	[SpecialName]
	public virtual bool FEBAKFHNHGB()
	{
		return true;
	}

	public virtual IEnumerator GDLOAPIHMOB(float KBJEOEEOEFG)
	{
		NAABLHNJHDD nAABLHNJHDD = new NAABLHNJHDD();
		nAABLHNJHDD.KBJEOEEOEFG = KBJEOEEOEFG;
		nAABLHNJHDD.BJGCPDNMHDH = this;
		return nAABLHNJHDD;
	}

	[DebuggerHidden]
	public virtual IEnumerator Hide(float KBJEOEEOEFG)
	{
		NAABLHNJHDD nAABLHNJHDD = new NAABLHNJHDD();
		nAABLHNJHDD.KBJEOEEOEFG = KBJEOEEOEFG;
		nAABLHNJHDD.BJGCPDNMHDH = this;
		return nAABLHNJHDD;
	}

	public virtual IEnumerator NDODOLKAABG(float KBJEOEEOEFG)
	{
		NAABLHNJHDD nAABLHNJHDD = new NAABLHNJHDD();
		nAABLHNJHDD.KBJEOEEOEFG = KBJEOEEOEFG;
		nAABLHNJHDD.BJGCPDNMHDH = this;
		return nAABLHNJHDD;
	}

	public virtual void InitControls()
	{
	}

	protected void BJPABDDHCHP(float EKLJNMMKOLL)
	{
		OKPHOBDPFHL = TimeManager.realTimeWithoutPauses + EKLJNMMKOLL;
	}

	public bool LNGFGGAGMJP()
	{
		return TimeManager.CEAFAMFNGCC() < OKPHOBDPFHL;
	}

	public virtual bool LHFOMPDODJC()
	{
		return false;
	}

	private void MGCJKMEEDCG()
	{
		if (NGHCDIMLGMO != null && !string.IsNullOrEmpty(NLAPDGJOBOK) && DBLMMAGBMND)
		{
			NGHCDIMLGMO.mainTexture = null;
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.GMACFOOOLJG();
			resourceLoaderTexture2D.FreeAsset(NLAPDGJOBOK);
			DBLMMAGBMND = true;
		}
	}

	public virtual IEnumerator KKFMEGJAHIM(float KBJEOEEOEFG)
	{
		ENJNCINNAFG eNJNCINNAFG = new ENJNCINNAFG();
		eNJNCINNAFG.KBJEOEEOEFG = KBJEOEEOEFG;
		eNJNCINNAFG.BJGCPDNMHDH = this;
		return eNJNCINNAFG;
	}

	protected void LDNOPACODIP(float EKLJNMMKOLL)
	{
		OKPHOBDPFHL = TimeManager.realTimeWithoutPauses + EKLJNMMKOLL;
	}

	public bool ANELGJOMCAB()
	{
		return TimeManager.CEAFAMFNGCC() < OKPHOBDPFHL;
	}

	private void NAPALFCBIPE()
	{
		if (NGHCDIMLGMO != null && !string.IsNullOrEmpty(NLAPDGJOBOK) && !DBLMMAGBMND)
		{
			DBLMMAGBMND = false;
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HOBDKJCMHNN();
			Texture2D texture2D = resourceLoaderTexture2D.LoadAsset(NLAPDGJOBOK);
			NGHCDIMLGMO.gameObject.SetActive(texture2D != null);
			if (texture2D != null)
			{
				NGHCDIMLGMO.mainTexture = texture2D;
			}
		}
	}

	protected void HBDJGAKINJN(float EKLJNMMKOLL)
	{
		OKPHOBDPFHL = TimeManager.CEAFAMFNGCC() + EKLJNMMKOLL;
	}

	public virtual bool KPEHFFDDDKD()
	{
		return true;
	}

	[SpecialName]
	public virtual bool DAPHOJDBHFE()
	{
		return true;
	}

	public virtual IEnumerator DMLDBKFCACB(float KBJEOEEOEFG)
	{
		JBOGKOPAPPN jBOGKOPAPPN = new JBOGKOPAPPN();
		jBOGKOPAPPN.KBJEOEEOEFG = KBJEOEEOEFG;
		jBOGKOPAPPN.BJGCPDNMHDH = this;
		return jBOGKOPAPPN;
	}

	public virtual bool AMOKIDIOEJO()
	{
		return false;
	}

	public virtual void FHINGMFHKLG()
	{
	}

	private void HNDOGAHDADL()
	{
		if (NGHCDIMLGMO != null && !string.IsNullOrEmpty(NLAPDGJOBOK) && !DBLMMAGBMND)
		{
			DBLMMAGBMND = false;
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HNCFECDNLDI();
			Texture2D texture2D = resourceLoaderTexture2D.LoadAsset(NLAPDGJOBOK);
			NGHCDIMLGMO.gameObject.SetActive(texture2D != null);
			if (texture2D != null)
			{
				NGHCDIMLGMO.mainTexture = texture2D;
			}
		}
	}

	[DebuggerHidden]
	public virtual IEnumerator Show(float KBJEOEEOEFG)
	{
		JBOGKOPAPPN jBOGKOPAPPN = new JBOGKOPAPPN();
		jBOGKOPAPPN.KBJEOEEOEFG = KBJEOEEOEFG;
		jBOGKOPAPPN.BJGCPDNMHDH = this;
		return jBOGKOPAPPN;
	}

	private void JFOIMNILIHE()
	{
		if (NGHCDIMLGMO != null && !string.IsNullOrEmpty(NLAPDGJOBOK) && DBLMMAGBMND)
		{
			NGHCDIMLGMO.mainTexture = null;
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HOBDKJCMHNN();
			resourceLoaderTexture2D.FreeAsset(NLAPDGJOBOK);
			DBLMMAGBMND = true;
		}
	}

	public virtual void MEHAKDFBGJN()
	{
	}

	public virtual IEnumerator OCAEJPMPBMH(float KBJEOEEOEFG)
	{
		NAABLHNJHDD nAABLHNJHDD = new NAABLHNJHDD();
		nAABLHNJHDD.KBJEOEEOEFG = KBJEOEEOEFG;
		nAABLHNJHDD.BJGCPDNMHDH = this;
		return nAABLHNJHDD;
	}

	protected void KEMGNNCHGDA(float EKLJNMMKOLL)
	{
		OKPHOBDPFHL = TimeManager.CEAFAMFNGCC() + EKLJNMMKOLL;
	}

	public virtual void KBALFNMGIOA()
	{
	}

	public bool DIEACOMHPOP()
	{
		return TimeManager.realTimeWithoutPauses < OKPHOBDPFHL;
	}

	public virtual void AIIIDDDAPGB()
	{
	}

	[SpecialName]
	public virtual bool EIJJPCDHBMG()
	{
		return true;
	}

	public virtual void AAEDAJEEGDD()
	{
	}

	[SpecialName]
	public virtual bool KAEGGLFKJHD()
	{
		return true;
	}

	[SpecialName]
	public virtual bool HGBLICDJOHG()
	{
		return false;
	}

	public bool BKJLIIINJLG()
	{
		return TimeManager.realTimeWithoutPauses < OKPHOBDPFHL;
	}

	public virtual IEnumerator LOFMDBHAFAO(float KBJEOEEOEFG)
	{
		JBOGKOPAPPN jBOGKOPAPPN = new JBOGKOPAPPN();
		jBOGKOPAPPN.KBJEOEEOEFG = KBJEOEEOEFG;
		jBOGKOPAPPN.BJGCPDNMHDH = this;
		return jBOGKOPAPPN;
	}

	public virtual IEnumerator ONCKKJFAMKF(float KBJEOEEOEFG)
	{
		JBOGKOPAPPN jBOGKOPAPPN = new JBOGKOPAPPN();
		jBOGKOPAPPN.KBJEOEEOEFG = KBJEOEEOEFG;
		jBOGKOPAPPN.BJGCPDNMHDH = this;
		return jBOGKOPAPPN;
	}

	public virtual void FCIANKCBLKM()
	{
	}

	public bool PDFDHAGAOEC()
	{
		return TimeManager.realTimeWithoutPauses < OKPHOBDPFHL;
	}

	public virtual void InitEvents()
	{
	}

	public bool IsShowTime()
	{
		return TimeManager.realTimeWithoutPauses < OKPHOBDPFHL;
	}

	[SpecialName]
	public virtual bool OKFFGJDBNFO()
	{
		return true;
	}

	private void MFOEIGPEJFP()
	{
		if (NGHCDIMLGMO != null && !string.IsNullOrEmpty(NLAPDGJOBOK) && !DBLMMAGBMND)
		{
			DBLMMAGBMND = false;
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.MJBHFBJHPFG();
			Texture2D texture2D = resourceLoaderTexture2D.LoadAsset(NLAPDGJOBOK);
			NGHCDIMLGMO.gameObject.SetActive(texture2D != null);
			if (texture2D != null)
			{
				NGHCDIMLGMO.mainTexture = texture2D;
			}
		}
	}

	public bool JEOFLLBGGJB()
	{
		return TimeManager.realTimeWithoutPauses < OKPHOBDPFHL;
	}

	[SpecialName]
	public virtual bool KMAAKJEKFMJ()
	{
		return false;
	}

	public virtual bool IsAvailable()
	{
		return true;
	}

	private void DLNFBJHHGBK()
	{
		if (NGHCDIMLGMO != null && !string.IsNullOrEmpty(NLAPDGJOBOK) && !DBLMMAGBMND)
		{
			DBLMMAGBMND = true;
			ResourceLoaderTexture2D weapons = Singleton<GuiTexureAssets>.instance.weapons;
			Texture2D texture2D = weapons.LoadAsset(NLAPDGJOBOK);
			NGHCDIMLGMO.gameObject.SetActive(texture2D != null);
			if (texture2D != null)
			{
				NGHCDIMLGMO.mainTexture = texture2D;
			}
		}
	}

	private void OPPAADCPKCL()
	{
		if (NGHCDIMLGMO != null && !string.IsNullOrEmpty(NLAPDGJOBOK) && DBLMMAGBMND)
		{
			NGHCDIMLGMO.mainTexture = null;
			ResourceLoaderTexture2D weapons = Singleton<GuiTexureAssets>.instance.weapons;
			weapons.FreeAsset(NLAPDGJOBOK);
			DBLMMAGBMND = false;
		}
	}

	public virtual IEnumerator EPCEHACNCNH(float KBJEOEEOEFG)
	{
		NAABLHNJHDD nAABLHNJHDD = new NAABLHNJHDD();
		nAABLHNJHDD.KBJEOEEOEFG = KBJEOEEOEFG;
		nAABLHNJHDD.BJGCPDNMHDH = this;
		return nAABLHNJHDD;
	}

	[DebuggerHidden]
	public virtual IEnumerator Change(float KBJEOEEOEFG)
	{
		ENJNCINNAFG eNJNCINNAFG = new ENJNCINNAFG();
		eNJNCINNAFG.KBJEOEEOEFG = KBJEOEEOEFG;
		eNJNCINNAFG.BJGCPDNMHDH = this;
		return eNJNCINNAFG;
	}

	public virtual bool EOJDPCMGMBP()
	{
		return true;
	}

	[SpecialName]
	public virtual bool HJMPIKCDJDP()
	{
		return false;
	}

	public virtual void InitGuiValues()
	{
	}

	public virtual IEnumerator OMCADBPJEOL(float KBJEOEEOEFG)
	{
		NAABLHNJHDD nAABLHNJHDD = new NAABLHNJHDD();
		nAABLHNJHDD.KBJEOEEOEFG = KBJEOEEOEFG;
		nAABLHNJHDD.BJGCPDNMHDH = this;
		return nAABLHNJHDD;
	}
}
