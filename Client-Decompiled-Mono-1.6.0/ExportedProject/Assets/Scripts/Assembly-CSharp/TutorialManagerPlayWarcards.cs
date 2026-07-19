using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TutorialManagerPlayWarcards : TutorialManagerBase
{
	private sealed class KAAENBBKGGF : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal TutorialManagerPlayWarcards BJGCPDNMHDH;

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
		private object GLIHEBDJCGM()
		{
			return PHDOCKCBJOF;
		}

		public void CFHJPHLFONO()
		{
			throw new NotSupportedException();
		}

		public void BJHCLGCKJBB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool LHBPPCGLHDI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.FEKCJMKEIPM());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				Singleton<GameController>.instance.CBAPHFGNLLH.LCDJLPLGFEO();
				GuiElementSingle<ChatGuiElement>.instance.UpdateButtonLook();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CardSelection()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
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
			return true;
		}

		[SpecialName]
		private object INAMGPNDAAJ()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void FIENOOBNNGD()
		{
			throw new NotSupportedException();
		}

		public void MFFEEKOGCCE()
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
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.LoadTutorialCoroutine());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<GameController>.instance.CBAPHFGNLLH.NLEJMJEGLDI();
				GuiElementSingle<ChatGuiElement>.instance.UpdateButtonLook();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CardSelection()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
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

		public void MENEBJLDGJD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BBOGBCNCIFN()
		{
			return PHDOCKCBJOF;
		}

		public void PMPGBMCHGPE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool BJIPDEICIML()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.FEKCJMKEIPM());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<GameController>.instance.CBAPHFGNLLH.NLEJMJEGLDI();
				GuiElementSingle<ChatGuiElement>.instance.UpdateButtonLook();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CardSelection()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 2u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
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

		public void OJDEHKDDLFD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void EJNCMFMOBAJ()
		{
			throw new NotSupportedException();
		}

		public void GIAIFFPNMPJ()
		{
			throw new NotSupportedException();
		}

		public void HHCIHDMICFP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void CCPGGFONBKA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void JGKDJGIANIG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object FKPDNNMENFD()
		{
			return PHDOCKCBJOF;
		}

		public void CDDFJOEEFID()
		{
			throw new NotSupportedException();
		}

		public void FGLAPPKJHBK()
		{
			throw new NotSupportedException();
		}

		public void LHADJAFHDDC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object LMBPPPOFIOC()
		{
			return PHDOCKCBJOF;
		}

		public bool EJKHEELJJFM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.CNJMCFDKLCN());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<GameController>.instance.CBAPHFGNLLH.FBCPCKGEAGN();
				GuiElementSingle<ChatGuiElement>.instance.UpdateButtonLook();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CardSelection()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 2u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
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

		public void PAOPOFJHFGD()
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
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.NDDANOBHOPG());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<GameController>.instance.CBAPHFGNLLH.PBIKFDEDBKN();
				GuiElementSingle<ChatGuiElement>.instance.UpdateButtonLook();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CardSelection()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 2u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 3u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void KOEEOJGJNAO()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool NJBCJDFKGHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.LoadTutorialCoroutine());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				Singleton<GameController>.instance.CBAPHFGNLLH.LCDJLPLGFEO();
				GuiElementSingle<ChatGuiElement>.instance.UpdateButtonLook();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CardSelection()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 2u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
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

		public bool KHNDCDGBFJH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.NDDANOBHOPG());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<GameController>.instance.CBAPHFGNLLH.PBIKFDEDBKN();
				GuiElementSingle<ChatGuiElement>.instance.UpdateButtonLook();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CardSelection()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 2u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 3u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object DHFBIMOBODM()
		{
			return PHDOCKCBJOF;
		}

		public void KHMNEOBMJLN()
		{
			throw new NotSupportedException();
		}

		public void PHEIGPKKPGE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IIJAMNPBACH()
		{
			return PHDOCKCBJOF;
		}

		public void NAMBILMHOPD()
		{
			throw new NotSupportedException();
		}

		public void GFJIKANGNMC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void NINFHADPHJI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void AKEKFBGEJBG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool MOFPMNMAOND()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.NDDANOBHOPG());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<GameController>.instance.CBAPHFGNLLH.LCDJLPLGFEO();
				GuiElementSingle<ChatGuiElement>.instance.UpdateButtonLook();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CardSelection()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 2u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
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

		public void ANOPOLIEBMC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MDHGGDNNOAK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HIFNMHAGHLI()
		{
			return PHDOCKCBJOF;
		}

		public void PDNKLJFHBGO()
		{
			throw new NotSupportedException();
		}

		public bool LPCENKMGCDJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.CNJMCFDKLCN());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<GameController>.instance.CBAPHFGNLLH.NLEJMJEGLDI();
				GuiElementSingle<ChatGuiElement>.instance.UpdateButtonLook();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CardSelection()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 2u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 3u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void FLFOEIMCFBL()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool MHNPBDBGBLK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.LoadTutorialCoroutine());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				Singleton<GameController>.instance.CBAPHFGNLLH.FBCPCKGEAGN();
				GuiElementSingle<ChatGuiElement>.instance.UpdateButtonLook();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CardSelection()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 2u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
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
			return false;
		}

		[SpecialName]
		private object KJMPNHLOKJL()
		{
			return PHDOCKCBJOF;
		}

		public void HNFEJKPKEHK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void CBPDLFGDOHJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HLBMCNKGBDM()
		{
			return PHDOCKCBJOF;
		}

		public void IGBHHLFACKO()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object ALJCBJBHLMK()
		{
			return PHDOCKCBJOF;
		}

		public void CDIJEGGMMAK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool ECPGMIIEFDP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.MCMLNCLLBPA());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<GameController>.instance.CBAPHFGNLLH.BBAJNJDJKII();
				GuiElementSingle<ChatGuiElement>.instance.UpdateButtonLook();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CardSelection()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
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
			return true;
		}

		public bool PJJPPMIBNLN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.LoadTutorialCoroutine());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<GameController>.instance.CBAPHFGNLLH.BBAJNJDJKII();
				GuiElementSingle<ChatGuiElement>.instance.UpdateButtonLook();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CardSelection()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 2u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
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

		[SpecialName]
		private object DCILDAODCDM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CNGCLCAAHIG()
		{
			return PHDOCKCBJOF;
		}

		public void NPIDJAPKFLN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object DBKMMECKKLG()
		{
			return PHDOCKCBJOF;
		}

		public bool NHLBGCIDHDE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.FEKCJMKEIPM());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				Singleton<GameController>.instance.CBAPHFGNLLH.PBIKFDEDBKN();
				GuiElementSingle<ChatGuiElement>.instance.UpdateButtonLook();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CardSelection()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 2u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
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

		public bool IJEDIDEJIII()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.NDDANOBHOPG());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				Singleton<GameController>.instance.CBAPHFGNLLH.LCDJLPLGFEO();
				GuiElementSingle<ChatGuiElement>.instance.UpdateButtonLook();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CardSelection()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
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
			return true;
		}

		[SpecialName]
		private object MCCMIANNJAN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OEKIILKKNOE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FIDLDFGJLFK()
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
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.MCMLNCLLBPA());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<GameController>.instance.CBAPHFGNLLH.BBAJNJDJKII();
				GuiElementSingle<ChatGuiElement>.instance.UpdateButtonLook();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CardSelection()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 2u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
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

		[SpecialName]
		private object JDECDOJJAAH()
		{
			return PHDOCKCBJOF;
		}

		public void MPKODAJAPFD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void KCHOLCGBMBJ()
		{
			throw new NotSupportedException();
		}

		public void NCFGFLNBHOI()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CGNOIKAGEMC()
		{
			return PHDOCKCBJOF;
		}

		public void FOBPOJPHNHE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void MPNLGDNLLKF()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object LMJBCDNGAHP()
		{
			return PHDOCKCBJOF;
		}

		public void KINGACOICNF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MBDBIPHLEIA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OJKHNOHHDGO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LGDOCMENCOG()
		{
			return PHDOCKCBJOF;
		}

		public bool BPHPJKKHNNG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.FEKCJMKEIPM());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<GameController>.instance.CBAPHFGNLLH.PBIKFDEDBKN();
				GuiElementSingle<ChatGuiElement>.instance.UpdateButtonLook();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CardSelection()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 2u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
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

		public void MBCPJPIHNIK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object LAENBDAPNJL()
		{
			return PHDOCKCBJOF;
		}

		public void CPEEDIDEKLA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool DMPHMFDEINI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.BIFELDOOCNM());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				Singleton<GameController>.instance.CBAPHFGNLLH.NLEJMJEGLDI();
				GuiElementSingle<ChatGuiElement>.instance.UpdateButtonLook();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CardSelection()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 2u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 3u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object BGLDNJLBIKM()
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
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.NDDANOBHOPG());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				Singleton<GameController>.instance.CBAPHFGNLLH.BBAJNJDJKII();
				GuiElementSingle<ChatGuiElement>.instance.UpdateButtonLook();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CardSelection()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
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

		public void NDPOBCODJAI()
		{
			throw new NotSupportedException();
		}

		public void CFDAGFGOOIE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GPKBICHIBHF()
		{
			return PHDOCKCBJOF;
		}

		public void PPHBGPPJBNK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void JBHOCIFIMBH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void JANIKOFKDCH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object EOPJNKFKMNB()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public KAAENBBKGGF()
		{
		}

		[SpecialName]
		private object BKHFGLNNCDF()
		{
			return PHDOCKCBJOF;
		}

		public void HNLLOFFANCE()
		{
			throw new NotSupportedException();
		}

		public bool PMBOHHPPJAC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.MCMLNCLLBPA());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<GameController>.instance.CBAPHFGNLLH.BBAJNJDJKII();
				GuiElementSingle<ChatGuiElement>.instance.UpdateButtonLook();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CardSelection()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Welcome()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 3u:
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
		private object IPCODJDAOBE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MLCINLDHAGM()
		{
			return PHDOCKCBJOF;
		}

		public void ODFCBNONFPL()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KGPFMHHMKHO()
		{
			return PHDOCKCBJOF;
		}
	}

	private sealed class MBOAFNJNLAC : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal TutorialManagerPlayWarcards BJGCPDNMHDH;

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
		private object IBCJOBKGEEG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AGANCOFPDCK()
		{
			return PHDOCKCBJOF;
		}

		public bool EOLNOFMPMHI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mGameStarted = true;
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				UnityEngine.Debug.Log("getCurrentAccountName");
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("http://www.imgawards.com/wp-content/uploads/2015/12/Cover-Winter_WarFriends.png");
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = false;
				goto case 3u;
			case 3u:
				if (!Singleton<GameController>.instance.KKHKIEFMENC())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1311f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				break;
			case 4u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.GameCardTutorial()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object BIMFPFEHMAP()
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
				BJGCPDNMHDH.mGameStarted = true;
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				UnityEngine.Debug.Log("ID_ACTIVATEXVIPFORYGOLD");
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_ONLINE");
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = false;
				goto case 3u;
			case 3u:
				if (!Singleton<GameController>.instance.gameIsRunning)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(925f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
				}
				break;
			case 4u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.GameCardTutorial()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object ACDKCFGCBAB()
		{
			return PHDOCKCBJOF;
		}

		public bool BCFKDABEHHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mGameStarted = true;
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				UnityEngine.Debug.Log("ID_RELOG_TO_WRONG_FB_DIALOG_TEXT1");
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Days_Since_Install");
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = true;
				goto case 3u;
			case 3u:
				if (!Singleton<GameController>.instance.GHKPKDPOGHF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(436f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				break;
			case 4u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.GameCardTutorial()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void JMANMKKCDMM()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HHLKEMNNJDA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FFJBOMJMIAE()
		{
			return PHDOCKCBJOF;
		}

		public void JOEOMEJLEID()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool DFMKKFMEBON()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mGameStarted = true;
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				UnityEngine.Debug.Log(" Desc without HINT = ");
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("FLOATVALUE");
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = false;
				goto case 3u;
			case 3u:
				if (!Singleton<GameController>.instance.gameIsRunning)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1175f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				break;
			case 4u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.GameCardTutorial()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object ALJCNLJGABF()
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
				BJGCPDNMHDH.mGameStarted = true;
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				UnityEngine.Debug.Log("Social_Behaviour");
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ProgressId");
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = true;
				goto case 3u;
			case 3u:
				if (!Singleton<GameController>.instance.GHKPKDPOGHF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1592f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				break;
			case 4u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.GameCardTutorial()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object DFKJEOAPBGP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KOGGPMGMFIN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BEGHOADNMJF()
		{
			return PHDOCKCBJOF;
		}

		public void LHMNIFOJGIG()
		{
			throw new NotSupportedException();
		}

		public bool FADACBKMFGG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mGameStarted = true;
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				UnityEngine.Debug.Log("DogTagLastUpdate");
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_GUI_ALLCARDS");
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = false;
				goto case 3u;
			case 3u:
				if (!Singleton<GameController>.instance.GHKPKDPOGHF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(19f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
				}
				break;
			case 4u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.GameCardTutorial()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public bool PMCFLKAJNHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mGameStarted = true;
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				UnityEngine.Debug.Log("PlayerInventory: Init");
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Custom string = ");
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = false;
				goto case 3u;
			case 3u:
				if (!Singleton<GameController>.instance.GHKPKDPOGHF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1749f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				break;
			case 4u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.GameCardTutorial()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public bool JNHFCKKAPJH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mGameStarted = true;
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				UnityEngine.Debug.Log("b");
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("shield_run");
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = true;
				goto case 3u;
			case 3u:
				if (!Singleton<GameController>.instance.KKHKIEFMENC())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(199f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				break;
			case 4u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.GameCardTutorial()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public bool JFPOOBJNEPF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mGameStarted = false;
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				UnityEngine.Debug.Log("\t");
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("VipRewardForDay");
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = false;
				goto case 3u;
			case 3u:
				if (!Singleton<GameController>.instance.GHKPKDPOGHF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1392f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				break;
			case 4u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.GameCardTutorial()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object IJFPHIKFJFB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PLHNILIJAPA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IDBEGKHBNBC()
		{
			return PHDOCKCBJOF;
		}

		public void KKCNPIPOCKK()
		{
			throw new NotSupportedException();
		}

		public void EKPOLGNAAOI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool CMBMOAECEJG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mGameStarted = true;
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				UnityEngine.Debug.Log("GameGold");
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_TUTORIAL_GO_TO_ARMORY_8_DOWN");
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = false;
				goto case 3u;
			case 3u:
				if (!Singleton<GameController>.instance.KKHKIEFMENC())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(747f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				break;
			case 4u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.GameCardTutorial()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object MPHILJJDNIO()
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
				BJGCPDNMHDH.mGameStarted = false;
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				UnityEngine.Debug.Log("CH");
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(",");
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = false;
				goto case 3u;
			case 3u:
				if (!Singleton<GameController>.instance.GHKPKDPOGHF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1855f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				break;
			case 4u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.GameCardTutorial()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void CKEOKOKAAPB()
		{
			throw new NotSupportedException();
		}

		public void FJOIBBIGBJC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HBGFABNDPAD()
		{
			return PHDOCKCBJOF;
		}

		public bool FGAFKEKGPHF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mGameStarted = false;
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				UnityEngine.Debug.Log("-[^-]*$");
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("1");
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = false;
				goto case 3u;
			case 3u:
				if (!Singleton<GameController>.instance.KKHKIEFMENC())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1607f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				break;
			case 4u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.GameCardTutorial()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void IMFLNKIMEFA()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object AFAOHBIDOJD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BKHFGLNNCDF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BBHOODPMEFM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BGLDNJLBIKM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KBPOAPCEPBN()
		{
			return PHDOCKCBJOF;
		}

		public void CDDFJOEEFID()
		{
			throw new NotSupportedException();
		}

		public void IJHCIJLDKHK()
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
				BJGCPDNMHDH.mGameStarted = false;
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				UnityEngine.Debug.Log("WarbucksBalance");
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("([-_:]|\\s)");
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = true;
				goto case 3u;
			case 3u:
				if (!Singleton<GameController>.instance.KKHKIEFMENC())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1242f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				break;
			case 4u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.GameCardTutorial()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object HGOKAFJBFGJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MFNFCFAJKCM()
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
				BJGCPDNMHDH.mGameStarted = true;
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				UnityEngine.Debug.Log("grenadeExplosion");
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_BUY");
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = true;
				goto case 3u;
			case 3u:
				if (!Singleton<GameController>.instance.GHKPKDPOGHF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1725f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				break;
			case 4u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.GameCardTutorial()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[DebuggerHidden]
		public MBOAFNJNLAC()
		{
		}

		[SpecialName]
		private object GEFKCGOOFFP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DJIJFANFBCP()
		{
			return PHDOCKCBJOF;
		}

		public void NPKGNIGNPKG()
		{
			throw new NotSupportedException();
		}

		public bool EBLHEEKHANA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mGameStarted = true;
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				UnityEngine.Debug.Log("S");
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_ARENARULES_LIVE");
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = false;
				goto case 3u;
			case 3u:
				if (!Singleton<GameController>.instance.KKHKIEFMENC())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1913f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				break;
			case 4u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.GameCardTutorial()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object IDLFKAKINAP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FKJJFNMBKOP()
		{
			return PHDOCKCBJOF;
		}

		public void CFHJPHLFONO()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GNFCCLCPCBO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ELNKFJHGFPD()
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
				BJGCPDNMHDH.mGameStarted = true;
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				UnityEngine.Debug.Log("Gold");
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_STAT_UNITSUPGRADES");
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = false;
				goto case 3u;
			case 3u:
				if (!Singleton<GameController>.instance.KKHKIEFMENC())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(605f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				break;
			case 4u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.GameCardTutorial()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void MIPBONGPIJE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool OGLKGILLKIO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mGameStarted = false;
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				UnityEngine.Debug.Log("ID_TUTORIAL_PROGRESS_KILLING2");
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("0");
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = false;
				goto case 3u;
			case 3u:
				if (!Singleton<GameController>.instance.gameIsRunning)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(160f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				break;
			case 4u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.GameCardTutorial()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object CLFFFNGBPGJ()
		{
			return PHDOCKCBJOF;
		}

		public void IKNKDDMLDIN()
		{
			throw new NotSupportedException();
		}

		public void BBBLJNFEACC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object OJANHAIEAEJ()
		{
			return PHDOCKCBJOF;
		}

		public void JKOCLGOOBEK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object DFHCLJNONGC()
		{
			return PHDOCKCBJOF;
		}

		public void LFOLGBNBBAG()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KGPFMHHMKHO()
		{
			return PHDOCKCBJOF;
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

		public bool BJIPDEICIML()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mGameStarted = false;
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				UnityEngine.Debug.Log("ID_AGAINSTTHESAMEOPPONENT");
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("shotReal");
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = true;
				goto case 3u;
			case 3u:
				if (!Singleton<GameController>.instance.gameIsRunning)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1565f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				break;
			case 4u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.GameCardTutorial()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public bool AAOIPMCCPEM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mGameStarted = false;
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				UnityEngine.Debug.Log("   {0}");
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("localSquadLeaderboard");
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = false;
				goto case 3u;
			case 3u:
				if (!Singleton<GameController>.instance.KKHKIEFMENC())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(455f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				break;
			case 4u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.GameCardTutorial()));
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

		public void FLOBHENENIC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JIIJMDIFMKF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CPJCCMLEPCE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JMGAHAGANGP()
		{
			return PHDOCKCBJOF;
		}

		public void PHKDHCJBMII()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void KIPDKEKMDFE()
		{
			throw new NotSupportedException();
		}

		public bool IGOKEIDOCKB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mGameStarted = true;
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				UnityEngine.Debug.Log("ID_WARNING_BUDDYCARDNOTREADY");
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_GUI_CHEATWARNING");
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = true;
				goto case 3u;
			case 3u:
				if (!Singleton<GameController>.instance.GHKPKDPOGHF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1685f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				break;
			case 4u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.GameCardTutorial()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object DBKMMECKKLG()
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
				BJGCPDNMHDH.mGameStarted = false;
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				UnityEngine.Debug.Log("*****   Bootcamp Play WarCards Started   *****");
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("603 GAME STARTED");
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = true;
				goto case 3u;
			case 3u:
				if (!Singleton<GameController>.instance.gameIsRunning)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(2.5f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				break;
			case 4u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.GameCardTutorial()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object HJHFKNCBGDG()
		{
			return PHDOCKCBJOF;
		}

		public bool LPCBKGKFNFD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mGameStarted = true;
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				UnityEngine.Debug.Log("ID_SEC");
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("SquadIcons/");
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = true;
				goto case 3u;
			case 3u:
				if (!Singleton<GameController>.instance.KKHKIEFMENC())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(843f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				break;
			case 4u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.GameCardTutorial()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void KBKIDOJFMHC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BCIDICEAAEN()
		{
			return PHDOCKCBJOF;
		}

		public bool NJBCJDFKGHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mGameStarted = false;
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				UnityEngine.Debug.Log("0");
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("TimeBonus");
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = false;
				goto case 3u;
			case 3u:
				if (!Singleton<GameController>.instance.GHKPKDPOGHF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(557f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				break;
			case 4u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.GameCardTutorial()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void AKEKFBGEJBG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void POJNMHLNOOF()
		{
			throw new NotSupportedException();
		}

		public void GDJMNEPLJNE()
		{
			throw new NotSupportedException();
		}

		public void EBAGFJMHLCB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void IBLNBELFKNF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void KKDOJDCJAJB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool LGNMOMFLLPP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mGameStarted = true;
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				UnityEngine.Debug.Log("HeroicMissionsUnlocked");
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_VIPLOOTBOXREWARDED");
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = false;
				goto case 3u;
			case 3u:
				if (!Singleton<GameController>.instance.KKHKIEFMENC())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(815f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				break;
			case 4u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.GameCardTutorial()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void KMIHPBNFGFH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HNBOIMNNPOH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CFBNPKIMOJC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NFJJHCBCIEM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FPAEFHEEOBL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LMLPPCCDELM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CLDLJNHAEAB()
		{
			return PHDOCKCBJOF;
		}

		public bool GPIPJIDGCKM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mGameStarted = false;
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				UnityEngine.Debug.Log("({0}\u00a0/\u00a0{1})");
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Player ");
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = true;
				goto case 3u;
			case 3u:
				if (!Singleton<GameController>.instance.KKHKIEFMENC())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(411f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				break;
			case 4u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.GameCardTutorial()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public bool LHNFELIIMGD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mGameStarted = true;
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				UnityEngine.Debug.Log("[.,']*");
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("country-bulgaria");
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = false;
				goto case 3u;
			case 3u:
				if (!Singleton<GameController>.instance.GHKPKDPOGHF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(732f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
				}
				break;
			case 4u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.GameCardTutorial()));
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
				BJGCPDNMHDH.mGameStarted = true;
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				UnityEngine.Debug.Log("ID_VIPLOOTBOXREWARDED");
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(" , ");
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = false;
				goto case 3u;
			case 3u:
				if (!Singleton<GameController>.instance.KKHKIEFMENC())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(481f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				break;
			case 4u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.GameCardTutorial()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public bool BEIABOJAIFM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mGameStarted = true;
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				UnityEngine.Debug.Log(".");
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("menu-assignments-type-cards");
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = true;
				goto case 3u;
			case 3u:
				if (!Singleton<GameController>.instance.GHKPKDPOGHF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(723f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				break;
			case 4u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.GameCardTutorial()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public bool JICHKPANPEE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mGameStarted = false;
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				UnityEngine.Debug.Log("#PETER# League Arc ");
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Deploys_Count");
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = true;
				goto case 3u;
			case 3u:
				if (!Singleton<GameController>.instance.gameIsRunning)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1863f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				break;
			case 4u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.GameCardTutorial()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object MNAKOOGPNOH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MBDBIPHLEIA()
		{
			return PHDOCKCBJOF;
		}

		public bool IIJKAMFGNKA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mGameStarted = false;
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				UnityEngine.Debug.Log("Amount");
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("seconds");
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = false;
				goto case 3u;
			case 3u:
				if (!Singleton<GameController>.instance.KKHKIEFMENC())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1447f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				break;
			case 4u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.GameCardTutorial()));
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

		public void HOFJFOCEKJJ()
		{
			throw new NotSupportedException();
		}

		public void OMDFNFHKFBK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MLDIMIPJMDD()
		{
			return PHDOCKCBJOF;
		}

		public void PAODBOEOFNF()
		{
			throw new NotSupportedException();
		}

		public void IGBHHLFACKO()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BJDOHADMIEB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JFEPOFBDLMB()
		{
			return PHDOCKCBJOF;
		}

		public void PNGIELILHDI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object CIHKIABJBGJ()
		{
			return PHDOCKCBJOF;
		}

		public void HCJOIAHBFGB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool APJNFAOFAFD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mGameStarted = true;
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				UnityEngine.Debug.Log("S");
				goto case 2u;
			case 2u:
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("WarFriends");
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = true;
				goto case 3u;
			case 3u:
				if (!Singleton<GameController>.instance.KKHKIEFMENC())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1795f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				break;
			case 4u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.GameCardTutorial()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}
	}

	private sealed class HFBKLMNHKKA : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal int OCDOPAILCEM;

		internal float IOKOECCLPAJ;

		internal PlayerController LHAAAIGMEBK;

		internal bool ODLFCGKPGLC;

		internal int OIMCIGPBAKI;

		internal TutorialManagerPlayWarcards BJGCPDNMHDH;

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

		public void LFIGPJBHPBH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object OAKHGMKKFMN()
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
				OCDOPAILCEM = CardManager.instance.cardsForGame.Count;
				IOKOECCLPAJ = Time.time + 1185f;
				LHAAAIGMEBK = PlayerController.GetEnemyOf((GHPGNELIDBM)7);
				goto case 1u;
			case 1u:
				if (Time.time < IOKOECCLPAJ)
				{
					if (CardManager.instance.cardsForGame.Count != 3)
					{
						LHAAAIGMEBK.KIIHLIPAGIH = false;
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				LHAAAIGMEBK.KIIHLIPAGIH = false;
				ODLFCGKPGLC = false;
				OIMCIGPBAKI = 1;
				if (CardManager.instance.cardsForGame.Count == OCDOPAILCEM)
				{
					ODLFCGKPGLC = false;
					OIMCIGPBAKI = (int)TimeManager.CEAFAMFNGCC();
					TimeManager.DCODDANOPCP();
					PlayerController.OGMBJPKOPCB.JODNNABEFDH = true;
					PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
					GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("()Lcom/google/android/gms/common/api/Result;", "BAND_TYPE_RELOAD", 1721f, TutorialDialog.DODBDLEJOAM.Top);
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(BJGCPDNMHDH.cardGUI.FLBLEPLAKEA(), new Vector3(1156f, 1676f, 144f), true, false, 937f);
					goto case 2u;
				}
				goto IL_0210;
			case 2u:
				if (OCDOPAILCEM == CardManager.instance.cardsForGame.Count)
				{
					GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateTapAnimation(BJGCPDNMHDH.cardGUI.PAGLGINLLOG(), new Vector3(750f, 986f, 1688f), false);
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				OIMCIGPBAKI = Mathf.Abs((int)TimeManager.CEAFAMFNGCC() - OIMCIGPBAKI);
				TimeManager.UnFreezeGame(730f);
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = true;
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				goto IL_0210;
			default:
				{
					return true;
				}
				IL_0210:
				Singleton<EventTrackingManager>.instance.RegisterTutorialPlayCardEvent("0", ODLFCGKPGLC, OIMCIGPBAKI);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object KBNAGKKMLBP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FMCLBOCENPE()
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
				OCDOPAILCEM = CardManager.instance.cardsForGame.Count;
				IOKOECCLPAJ = Time.time + 1833f;
				LHAAAIGMEBK = PlayerController.GetEnemyOf((GHPGNELIDBM)3);
				goto case 1u;
			case 1u:
				if (Time.time < IOKOECCLPAJ)
				{
					if (CardManager.instance.cardsForGame.Count != 6)
					{
						LHAAAIGMEBK.KIIHLIPAGIH = true;
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				LHAAAIGMEBK.KIIHLIPAGIH = true;
				ODLFCGKPGLC = false;
				OIMCIGPBAKI = 1;
				if (CardManager.instance.cardsForGame.Count == OCDOPAILCEM)
				{
					ODLFCGKPGLC = false;
					OIMCIGPBAKI = (int)TimeManager.realTimeWithoutPauses;
					TimeManager.DCODDANOPCP();
					PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
					PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
					GuiElementSingle<TutorialDialog>.instance.DDFADDKPPDI("ID_GUI_VIPMEMBERSHIP", "ID_READYTIME", 87f, TutorialDialog.DODBDLEJOAM.Right, false, true);
					GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(BJGCPDNMHDH.cardGUI.PMIHCEABNLG(), new Vector3(992f, 515f, 573f), true, true, 727f);
					goto case 2u;
				}
				goto IL_0210;
			case 2u:
				if (OCDOPAILCEM == CardManager.instance.cardsForGame.Count)
				{
					GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateTapAnimation(BJGCPDNMHDH.cardGUI.PMIHCEABNLG(), new Vector3(1888f, 1030f, 292f), false);
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				OIMCIGPBAKI = Mathf.Abs((int)TimeManager.CEAFAMFNGCC() - OIMCIGPBAKI);
				TimeManager.UnFreezeGame(1991f);
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				goto IL_0210;
			default:
				{
					return false;
				}
				IL_0210:
				Singleton<EventTrackingManager>.instance.RegisterTutorialPlayCardEvent("PromotedPlayer", ODLFCGKPGLC, OIMCIGPBAKI);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object JPJBNHHKOJD()
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
				OCDOPAILCEM = CardManager.instance.cardsForGame.Count;
				IOKOECCLPAJ = Time.time + 1877f;
				LHAAAIGMEBK = PlayerController.GetEnemyOf(GHPGNELIDBM.Enemies);
				goto case 1u;
			case 1u:
				if (Time.time < IOKOECCLPAJ)
				{
					if (CardManager.instance.cardsForGame.Count != 8)
					{
						LHAAAIGMEBK.KIIHLIPAGIH = false;
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				LHAAAIGMEBK.KIIHLIPAGIH = false;
				ODLFCGKPGLC = false;
				OIMCIGPBAKI = 0;
				if (CardManager.instance.cardsForGame.Count == OCDOPAILCEM)
				{
					ODLFCGKPGLC = true;
					OIMCIGPBAKI = (int)TimeManager.realTimeWithoutPauses;
					TimeManager.FreezeGame();
					PlayerController.OGMBJPKOPCB.JODNNABEFDH = true;
					PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
					GuiElementSingle<TutorialDialog>.instance.DDFADDKPPDI("BlackMarketMessage-{0}", "subscriptionAnalytics", 1771f, TutorialDialog.DODBDLEJOAM.BottomLeft);
					GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(BJGCPDNMHDH.cardGUI.PMIHCEABNLG(), new Vector3(1744f, 1417f, 1239f), false, false, 720f);
					goto case 2u;
				}
				goto IL_0210;
			case 2u:
				if (OCDOPAILCEM == CardManager.instance.cardsForGame.Count)
				{
					GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateTapAnimation(BJGCPDNMHDH.cardGUI.PMIHCEABNLG(), new Vector3(369f, 1061f, 1684f));
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				OIMCIGPBAKI = Mathf.Abs((int)TimeManager.realTimeWithoutPauses - OIMCIGPBAKI);
				TimeManager.UnFreezeGame(1193f);
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = true;
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				goto IL_0210;
			default:
				{
					return true;
				}
				IL_0210:
				Singleton<EventTrackingManager>.instance.RegisterTutorialPlayCardEvent("Generate army 4", ODLFCGKPGLC, OIMCIGPBAKI);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void NFLHLMKKJMO()
		{
			throw new NotSupportedException();
		}

		public void OMDFNFHKFBK()
		{
			throw new NotSupportedException();
		}

		public bool HCONPNNPBAD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				OCDOPAILCEM = CardManager.instance.cardsForGame.Count;
				IOKOECCLPAJ = Time.time + 273f;
				LHAAAIGMEBK = PlayerController.GetEnemyOf((GHPGNELIDBM)6);
				goto case 1u;
			case 1u:
				if (Time.time < IOKOECCLPAJ)
				{
					if (CardManager.instance.cardsForGame.Count != 3)
					{
						LHAAAIGMEBK.KIIHLIPAGIH = true;
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				LHAAAIGMEBK.KIIHLIPAGIH = true;
				ODLFCGKPGLC = true;
				OIMCIGPBAKI = 0;
				if (CardManager.instance.cardsForGame.Count == OCDOPAILCEM)
				{
					ODLFCGKPGLC = true;
					OIMCIGPBAKI = (int)TimeManager.CEAFAMFNGCC();
					TimeManager.FODFANEEDFF();
					PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
					PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
					GuiElementSingle<TutorialDialog>.instance.KOGOLIJLMDN("GLM: RegisterOrLogin - need add GC", "grenadeExplosion", 752f, TutorialDialog.DODBDLEJOAM.TopRight, true);
					GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(BJGCPDNMHDH.cardGUI.GetFirstCardPosition(), new Vector3(633f, 760f, 302f), true, false, 1695f);
					goto case 2u;
				}
				goto IL_0210;
			case 2u:
				if (OCDOPAILCEM == CardManager.instance.cardsForGame.Count)
				{
					GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateTapAnimation(BJGCPDNMHDH.cardGUI.FLBLEPLAKEA(), new Vector3(355f, 498f, 576f), false);
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				OIMCIGPBAKI = Mathf.Abs((int)TimeManager.realTimeWithoutPauses - OIMCIGPBAKI);
				TimeManager.UnFreezeGame(1484f);
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				goto IL_0210;
			default:
				{
					return false;
				}
				IL_0210:
				Singleton<EventTrackingManager>.instance.RegisterTutorialPlayCardEvent("ROCKETTURRET", ODLFCGKPGLC, OIMCIGPBAKI);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void KHMNEOBMJLN()
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
				OCDOPAILCEM = CardManager.instance.cardsForGame.Count;
				IOKOECCLPAJ = Time.time + 30f;
				LHAAAIGMEBK = PlayerController.GetEnemyOf(GHPGNELIDBM.Allies);
				goto case 1u;
			case 1u:
				if (Time.time < IOKOECCLPAJ)
				{
					if (CardManager.instance.cardsForGame.Count != 3)
					{
						LHAAAIGMEBK.KIIHLIPAGIH = false;
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				LHAAAIGMEBK.KIIHLIPAGIH = false;
				ODLFCGKPGLC = false;
				OIMCIGPBAKI = 0;
				if (CardManager.instance.cardsForGame.Count == OCDOPAILCEM)
				{
					ODLFCGKPGLC = true;
					OIMCIGPBAKI = (int)TimeManager.realTimeWithoutPauses;
					TimeManager.FreezeGame();
					PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
					PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
					GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("ID_TUTORIAL_PLAY_CARD_UP", "ID_TUTORIAL_PLAY_CARD_DOWN", 0.2f);
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(BJGCPDNMHDH.cardGUI.GetFirstCardPosition(), new Vector3(0f, 50f, 0f));
					goto case 2u;
				}
				goto IL_0210;
			case 2u:
				if (OCDOPAILCEM == CardManager.instance.cardsForGame.Count)
				{
					GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateTapAnimation(BJGCPDNMHDH.cardGUI.GetFirstCardPosition(), new Vector3(0f, 50f, 0f));
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				OIMCIGPBAKI = Mathf.Abs((int)TimeManager.realTimeWithoutPauses - OIMCIGPBAKI);
				TimeManager.UnFreezeGame();
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = true;
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				goto IL_0210;
			default:
				{
					return false;
				}
				IL_0210:
				Singleton<EventTrackingManager>.instance.RegisterTutorialPlayCardEvent("635 STAGE 10 PLAY CARD", ODLFCGKPGLC, OIMCIGPBAKI);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void GFGEEFGMNDP()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KKCOHEHPJPF()
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
				OCDOPAILCEM = CardManager.instance.cardsForGame.Count;
				IOKOECCLPAJ = Time.time + 1060f;
				LHAAAIGMEBK = PlayerController.GetEnemyOf(GHPGNELIDBM.None);
				goto case 1u;
			case 1u:
				if (Time.time < IOKOECCLPAJ)
				{
					if (CardManager.instance.cardsForGame.Count != 0)
					{
						LHAAAIGMEBK.KIIHLIPAGIH = true;
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				LHAAAIGMEBK.KIIHLIPAGIH = true;
				ODLFCGKPGLC = true;
				OIMCIGPBAKI = 0;
				if (CardManager.instance.cardsForGame.Count == OCDOPAILCEM)
				{
					ODLFCGKPGLC = true;
					OIMCIGPBAKI = (int)TimeManager.CEAFAMFNGCC();
					TimeManager.FODFANEEDFF();
					PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
					PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
					GuiElementSingle<TutorialDialog>.instance.KOGOLIJLMDN("mortar_down", "ID_LVLNUMBER", 143f, TutorialDialog.DODBDLEJOAM.Right, false, true);
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(BJGCPDNMHDH.cardGUI.PMIHCEABNLG(), new Vector3(1878f, 1828f, 681f), false, false, 160f);
					goto case 2u;
				}
				goto IL_0210;
			case 2u:
				if (OCDOPAILCEM == CardManager.instance.cardsForGame.Count)
				{
					GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateTapAnimation(BJGCPDNMHDH.cardGUI.PAGLGINLLOG(), new Vector3(561f, 1342f, 1371f), false);
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				OIMCIGPBAKI = Mathf.Abs((int)TimeManager.CEAFAMFNGCC() - OIMCIGPBAKI);
				TimeManager.UnFreezeGame(1045f);
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = true;
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				goto IL_0210;
			default:
				{
					return false;
				}
				IL_0210:
				Singleton<EventTrackingManager>.instance.RegisterTutorialPlayCardEvent("hasConnectedApi", ODLFCGKPGLC, OIMCIGPBAKI);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public bool LLOCENNFFFJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				OCDOPAILCEM = CardManager.instance.cardsForGame.Count;
				IOKOECCLPAJ = Time.time + 1281f;
				LHAAAIGMEBK = PlayerController.GetEnemyOf((GHPGNELIDBM)5);
				goto case 1u;
			case 1u:
				if (Time.time < IOKOECCLPAJ)
				{
					if (CardManager.instance.cardsForGame.Count != 4)
					{
						LHAAAIGMEBK.KIIHLIPAGIH = true;
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				LHAAAIGMEBK.KIIHLIPAGIH = true;
				ODLFCGKPGLC = true;
				OIMCIGPBAKI = 0;
				if (CardManager.instance.cardsForGame.Count == OCDOPAILCEM)
				{
					ODLFCGKPGLC = true;
					OIMCIGPBAKI = (int)TimeManager.CEAFAMFNGCC();
					TimeManager.FreezeGame();
					PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
					PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
					GuiElementSingle<TutorialDialog>.instance.BLHEPOBPHPK("iconParent", "Card_3_Played", 630f, TutorialDialog.DODBDLEJOAM.Left, true, true);
					GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(BJGCPDNMHDH.cardGUI.PMIHCEABNLG(), new Vector3(1347f, 897f, 1167f), true, true, 619f);
					goto case 2u;
				}
				goto IL_0210;
			case 2u:
				if (OCDOPAILCEM == CardManager.instance.cardsForGame.Count)
				{
					GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateTapAnimation(BJGCPDNMHDH.cardGUI.GetFirstCardPosition(), new Vector3(1111f, 619f, 1581f));
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				OIMCIGPBAKI = Mathf.Abs((int)TimeManager.realTimeWithoutPauses - OIMCIGPBAKI);
				TimeManager.UnFreezeGame(1182f);
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = true;
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				goto IL_0210;
			default:
				{
					return false;
				}
				IL_0210:
				Singleton<EventTrackingManager>.instance.RegisterTutorialPlayCardEvent("metalExplosion", ODLFCGKPGLC, OIMCIGPBAKI);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void FMOJMHBAHAA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void JJOAHIOBOPO()
		{
			throw new NotSupportedException();
		}

		public void ONGBFFAENBP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object CNGCLCAAHIG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ABGFJLAPNNM()
		{
			return PHDOCKCBJOF;
		}

		public void HHMPMPLLJCC()
		{
			throw new NotSupportedException();
		}

		public void POJKIIMAFDO()
		{
			throw new NotSupportedException();
		}

		public void GFPDOCDEGPA()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GKJIGGAAHBE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JFHOHPKEFGM()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void MIPBONGPIJE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void ODFCBNONFPL()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IBCJOBKGEEG()
		{
			return PHDOCKCBJOF;
		}

		public void AJEIGCJPEFN()
		{
			throw new NotSupportedException();
		}

		public void KCHOLCGBMBJ()
		{
			throw new NotSupportedException();
		}

		public void HMBLLDJFIJG()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object NOIDHHDEEPL()
		{
			return PHDOCKCBJOF;
		}

		public bool LMNIKLKKIDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				OCDOPAILCEM = CardManager.instance.cardsForGame.Count;
				IOKOECCLPAJ = Time.time + 1584f;
				LHAAAIGMEBK = PlayerController.GetEnemyOf((GHPGNELIDBM)8);
				goto case 1u;
			case 1u:
				if (Time.time < IOKOECCLPAJ)
				{
					if (CardManager.instance.cardsForGame.Count != 1)
					{
						LHAAAIGMEBK.KIIHLIPAGIH = true;
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				LHAAAIGMEBK.KIIHLIPAGIH = true;
				ODLFCGKPGLC = true;
				OIMCIGPBAKI = 1;
				if (CardManager.instance.cardsForGame.Count == OCDOPAILCEM)
				{
					ODLFCGKPGLC = false;
					OIMCIGPBAKI = (int)TimeManager.CEAFAMFNGCC();
					TimeManager.DCODDANOPCP();
					PlayerController.OGMBJPKOPCB.JODNNABEFDH = true;
					PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
					GuiElementSingle<TutorialDialog>.instance.BLHEPOBPHPK("{0} {1}", "utcTimeFromServer", 452f, TutorialDialog.DODBDLEJOAM.Top, false, true);
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(BJGCPDNMHDH.cardGUI.FLBLEPLAKEA(), new Vector3(1437f, 539f, 405f), false, false, 11f);
					goto case 2u;
				}
				goto IL_0210;
			case 2u:
				if (OCDOPAILCEM == CardManager.instance.cardsForGame.Count)
				{
					GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateTapAnimation(BJGCPDNMHDH.cardGUI.FLBLEPLAKEA(), new Vector3(1039f, 794f, 1075f));
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				OIMCIGPBAKI = Mathf.Abs((int)TimeManager.realTimeWithoutPauses - OIMCIGPBAKI);
				TimeManager.UnFreezeGame(1546f);
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				goto IL_0210;
			default:
				{
					return true;
				}
				IL_0210:
				Singleton<EventTrackingManager>.instance.RegisterTutorialPlayCardEvent("Set active weapon", ODLFCGKPGLC, OIMCIGPBAKI);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public void JKOCLGOOBEK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object AFDKAGLDADB()
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
				OCDOPAILCEM = CardManager.instance.cardsForGame.Count;
				IOKOECCLPAJ = Time.time + 1124f;
				LHAAAIGMEBK = PlayerController.GetEnemyOf((GHPGNELIDBM)5);
				goto case 1u;
			case 1u:
				if (Time.time < IOKOECCLPAJ)
				{
					if (CardManager.instance.cardsForGame.Count != 8)
					{
						LHAAAIGMEBK.KIIHLIPAGIH = true;
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				LHAAAIGMEBK.KIIHLIPAGIH = true;
				ODLFCGKPGLC = false;
				OIMCIGPBAKI = 0;
				if (CardManager.instance.cardsForGame.Count == OCDOPAILCEM)
				{
					ODLFCGKPGLC = true;
					OIMCIGPBAKI = (int)TimeManager.realTimeWithoutPauses;
					TimeManager.DCODDANOPCP();
					PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
					PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
					GuiElementSingle<TutorialDialog>.instance.BLHEPOBPHPK("Unit delivery was : ", "ID_CONFIRM_FRIENDCANCELLED", 866f, TutorialDialog.DODBDLEJOAM.Bottom);
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(BJGCPDNMHDH.cardGUI.PAGLGINLLOG(), new Vector3(59f, 1650f, 1679f), false, true, 152f);
					goto case 2u;
				}
				goto IL_0210;
			case 2u:
				if (OCDOPAILCEM == CardManager.instance.cardsForGame.Count)
				{
					GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateTapAnimation(BJGCPDNMHDH.cardGUI.PMIHCEABNLG(), new Vector3(1272f, 527f, 90f), false);
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				OIMCIGPBAKI = Mathf.Abs((int)TimeManager.realTimeWithoutPauses - OIMCIGPBAKI);
				TimeManager.UnFreezeGame(1769f);
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = true;
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				goto IL_0210;
			default:
				{
					return false;
				}
				IL_0210:
				Singleton<EventTrackingManager>.instance.RegisterTutorialPlayCardEvent("file://", ODLFCGKPGLC, OIMCIGPBAKI);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		[SpecialName]
		private object BGLDNJLBIKM()
		{
			return PHDOCKCBJOF;
		}

		public void PDKPELBIAON()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KLEHMEIAJHO()
		{
			return PHDOCKCBJOF;
		}

		public void PCNOHGFPMOE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GNFCCLCPCBO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FKPDNNMENFD()
		{
			return PHDOCKCBJOF;
		}

		public void NMEJKACLHKJ()
		{
			throw new NotSupportedException();
		}

		public void EFDJMHAPDLB()
		{
			throw new NotSupportedException();
		}

		public void PMAJELGBBKE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object KBPOAPCEPBN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IGFMIFOHCHJ()
		{
			return PHDOCKCBJOF;
		}

		public void NCOPKHMOMMK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public HFBKLMNHKKA()
		{
		}

		[SpecialName]
		private object ADIAKJMNIEB()
		{
			return PHDOCKCBJOF;
		}

		public bool HEHJAEIGHDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				OCDOPAILCEM = CardManager.instance.cardsForGame.Count;
				IOKOECCLPAJ = Time.time + 1567f;
				LHAAAIGMEBK = PlayerController.GetEnemyOf((GHPGNELIDBM)4);
				goto case 1u;
			case 1u:
				if (Time.time < IOKOECCLPAJ)
				{
					if (CardManager.instance.cardsForGame.Count != 5)
					{
						LHAAAIGMEBK.KIIHLIPAGIH = true;
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				LHAAAIGMEBK.KIIHLIPAGIH = true;
				ODLFCGKPGLC = true;
				OIMCIGPBAKI = 1;
				if (CardManager.instance.cardsForGame.Count == OCDOPAILCEM)
				{
					ODLFCGKPGLC = true;
					OIMCIGPBAKI = (int)TimeManager.realTimeWithoutPauses;
					TimeManager.FODFANEEDFF();
					PlayerController.OGMBJPKOPCB.JODNNABEFDH = true;
					PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
					GuiElementSingle<TutorialDialog>.instance.KOGOLIJLMDN("game-ico-poison", "Squad", 893f, TutorialDialog.DODBDLEJOAM.Top, true);
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(BJGCPDNMHDH.cardGUI.PMIHCEABNLG(), new Vector3(1003f, 593f, 1025f), false, false, 1755f);
					goto case 2u;
				}
				goto IL_0210;
			case 2u:
				if (OCDOPAILCEM == CardManager.instance.cardsForGame.Count)
				{
					GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateTapAnimation(BJGCPDNMHDH.cardGUI.PMIHCEABNLG(), new Vector3(517f, 57f, 347f), false);
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				OIMCIGPBAKI = Mathf.Abs((int)TimeManager.realTimeWithoutPauses - OIMCIGPBAKI);
				TimeManager.UnFreezeGame(1202f);
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				goto IL_0210;
			default:
				{
					return true;
				}
				IL_0210:
				Singleton<EventTrackingManager>.instance.RegisterTutorialPlayCardEvent("MASTER", ODLFCGKPGLC, OIMCIGPBAKI);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		[SpecialName]
		private object GEFKCGOOFFP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CFBNPKIMOJC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NDIGINEEOMH()
		{
			return PHDOCKCBJOF;
		}

		public void GCEMCPODLNM()
		{
			throw new NotSupportedException();
		}

		public void GIAIFFPNMPJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object APECNPGKOFC()
		{
			return PHDOCKCBJOF;
		}

		public void JHLKDONBGDK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HGCHEPGNHNP()
		{
			throw new NotSupportedException();
		}
	}

	private sealed class BEOBPDLHFPH : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal TutorialManagerPlayWarcards BJGCPDNMHDH;

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
		private object AHFIDCCJHKE()
		{
			return PHDOCKCBJOF;
		}

		public void OJDEHKDDLFD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MPEPJNIDBLI()
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
				UIDraggablePanel.panelDisabled = true;
				BJGCPDNMHDH.fightPressed = false;
				UnityEngine.Debug.Log(GuiScreenSingle<CardSelectionScreen>.instance);
				GuiScreenSingle<CardSelectionScreen>.instance.OHACNCHPIPD();
				PHDOCKCBJOF = new WaitForSeconds(500f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				GuiElementSingle<TutorialDialog>.instance.CNLFPNFIBIO(Localization.Localize("[CardHealthChangeUnit] - used again after spawning start, but before finish!!!"), Localization.Localize("$5-$10"), 1658f, TutorialDialog.DODBDLEJOAM.BottomLeft);
				PHDOCKCBJOF = new WaitForSeconds(1843f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 2u:
			case 3u:
				if (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				goto case 4u;
			case 4u:
				if (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(141f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				break;
			case 5u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("LevelExperience");
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckCards()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 6u:
				PHDOCKCBJOF = new WaitForSeconds(730f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 7u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Beanstalk: Squad Details is cached, returning ...");
				UIDraggablePanel.panelDisabled = false;
				BJGCPDNMHDH.fightPressed = true;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object INAMGPNDAAJ()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public BEOBPDLHFPH()
		{
		}

		public void JMANMKKCDMM()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MHKODCGLJFD()
		{
			return PHDOCKCBJOF;
		}

		public void PKMIJKOPPBF()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KJMPNHLOKJL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LFEJDKIGHMI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CCANBMDEKMB()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FGGMHEIPKAJ()
		{
			return PHDOCKCBJOF;
		}

		public void PHEIGPKKPGE()
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
				UIDraggablePanel.panelDisabled = false;
				BJGCPDNMHDH.fightPressed = true;
				UnityEngine.Debug.Log(GuiScreenSingle<CardSelectionScreen>.instance);
				GuiScreenSingle<CardSelectionScreen>.instance.DisableFightButton();
				PHDOCKCBJOF = new WaitForSeconds(1038f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				GuiElementSingle<TutorialDialog>.instance.CAIFLLEIJAF(Localization.Localize(")"), Localization.Localize("ID_READYTIME"), 1094f, TutorialDialog.DODBDLEJOAM.BottomLeft, false, true);
				PHDOCKCBJOF = new WaitForSeconds(1685f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 2u:
			case 3u:
				if (!GuiElementSingle<TutorialDialog>.instance.GDAIHLIGAKP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				goto case 4u;
			case 4u:
				if (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1090f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				break;
			case 5u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Beanstalk: On Update device token");
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckCards()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 6u:
				PHDOCKCBJOF = new WaitForSeconds(1365f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 7u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("#PETER# removing warcards from slots");
				UIDraggablePanel.panelDisabled = true;
				BJGCPDNMHDH.fightPressed = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public bool ICKNHCBNOMG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				UIDraggablePanel.panelDisabled = true;
				BJGCPDNMHDH.fightPressed = true;
				UnityEngine.Debug.Log(GuiScreenSingle<CardSelectionScreen>.instance);
				GuiScreenSingle<CardSelectionScreen>.instance.DisableFightButton();
				PHDOCKCBJOF = new WaitForSeconds(544f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				GuiElementSingle<TutorialDialog>.instance.CNLFPNFIBIO(Localization.Localize("Automatic_Equip"), Localization.Localize("BuddyCard_"), 1000f, TutorialDialog.DODBDLEJOAM.BottomRight, true);
				PHDOCKCBJOF = new WaitForSeconds(669f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 2u:
			case 3u:
				if (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				goto case 4u;
			case 4u:
				if (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1196f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				break;
			case 5u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("N");
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckCards()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 6u:
				PHDOCKCBJOF = new WaitForSeconds(904f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 7u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Squad Entered Event");
				UIDraggablePanel.panelDisabled = true;
				BJGCPDNMHDH.fightPressed = true;
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

		public bool JMCPAKBLPML()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				UIDraggablePanel.panelDisabled = false;
				BJGCPDNMHDH.fightPressed = false;
				UnityEngine.Debug.Log(GuiScreenSingle<CardSelectionScreen>.instance);
				GuiScreenSingle<CardSelectionScreen>.instance.OHACNCHPIPD();
				PHDOCKCBJOF = new WaitForSeconds(849f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				GuiElementSingle<TutorialDialog>.instance.ShowGameTutorialDirectly(Localization.Localize(" "), Localization.Localize("ID_AWESOME"), 427f, TutorialDialog.DODBDLEJOAM.Bottom, true, true);
				PHDOCKCBJOF = new WaitForSeconds(1353f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 2u:
			case 3u:
				if (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				goto case 4u;
			case 4u:
				if (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1950f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				break;
			case 5u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(", dictionary= ");
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckCards()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 6u:
				PHDOCKCBJOF = new WaitForSeconds(1134f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 7u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Wrong_Category");
				UIDraggablePanel.panelDisabled = true;
				BJGCPDNMHDH.fightPressed = true;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public bool MKLIDMNLNPN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				UIDraggablePanel.panelDisabled = false;
				BJGCPDNMHDH.fightPressed = true;
				UnityEngine.Debug.Log(GuiScreenSingle<CardSelectionScreen>.instance);
				GuiScreenSingle<CardSelectionScreen>.instance.OHACNCHPIPD();
				PHDOCKCBJOF = new WaitForSeconds(1150f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				GuiElementSingle<TutorialDialog>.instance.MHEOKFFFOKI(Localization.Localize("ShowEngineerBuildingIndicator"), Localization.Localize("SoldierBehaviourStartShootingNetwork"), 203f, TutorialDialog.DODBDLEJOAM.BottomLeft, true);
				PHDOCKCBJOF = new WaitForSeconds(799f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
			case 3u:
				if (!GuiElementSingle<TutorialDialog>.instance.GDAIHLIGAKP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				goto case 4u;
			case 4u:
				if (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(809f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				break;
			case 5u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Map_device_levelGroup");
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckCards()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 6u:
				PHDOCKCBJOF = new WaitForSeconds(79f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 7u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Shields");
				UIDraggablePanel.panelDisabled = true;
				BJGCPDNMHDH.fightPressed = true;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void LPKDPNHBLGJ()
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

		public bool PGOBEIMCPGA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				UIDraggablePanel.panelDisabled = false;
				BJGCPDNMHDH.fightPressed = false;
				UnityEngine.Debug.Log(GuiScreenSingle<CardSelectionScreen>.instance);
				GuiScreenSingle<CardSelectionScreen>.instance.DisableFightButton();
				PHDOCKCBJOF = new WaitForSeconds(658f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				GuiElementSingle<TutorialDialog>.instance.GFCPBIFKFIJ(Localization.Localize("upgrades"), Localization.Localize("ShotFrequencyMax"), 462f, TutorialDialog.DODBDLEJOAM.TopRight, true);
				PHDOCKCBJOF = new WaitForSeconds(1162f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 2u:
			case 3u:
				if (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				goto case 4u;
			case 4u:
				if (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1889f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				break;
			case 5u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("YES");
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckCards()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 6u:
				PHDOCKCBJOF = new WaitForSeconds(496f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 7u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(" ");
				UIDraggablePanel.panelDisabled = true;
				BJGCPDNMHDH.fightPressed = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void IGBHHLFACKO()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void GFGEEFGMNDP()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JJBAIMILGLK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EAGBDDECKHF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NAPMJAMDKMJ()
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
				UIDraggablePanel.panelDisabled = true;
				BJGCPDNMHDH.fightPressed = false;
				UnityEngine.Debug.Log(GuiScreenSingle<CardSelectionScreen>.instance);
				GuiScreenSingle<CardSelectionScreen>.instance.DisableFightButton();
				PHDOCKCBJOF = new WaitForSeconds(0.4f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				GuiElementSingle<TutorialDialog>.instance.ShowGameTutorialDirectly(Localization.Localize("ID_TUTORIAL_WARCARDS_STARTUP"), Localization.Localize("ID_TUTORIAL_WARCARDS_STARTDOWN"), 0f, TutorialDialog.DODBDLEJOAM.Center, true, true);
				PHDOCKCBJOF = new WaitForSeconds(0.4f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
			case 3u:
				if (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.Hide();
				goto case 4u;
			case 4u:
				if (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(0.1f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
				}
				break;
			case 5u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("601 TUTORIAL STARTED");
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckCards()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 6u:
				PHDOCKCBJOF = new WaitForSeconds(0.5f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 7u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("602 LOADING MAP");
				UIDraggablePanel.panelDisabled = false;
				BJGCPDNMHDH.fightPressed = false;
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

		public void MEBPMHDHIPJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object AFAOHBIDOJD()
		{
			return PHDOCKCBJOF;
		}

		public bool ILNBJIJONKD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				UIDraggablePanel.panelDisabled = true;
				BJGCPDNMHDH.fightPressed = true;
				UnityEngine.Debug.Log(GuiScreenSingle<CardSelectionScreen>.instance);
				GuiScreenSingle<CardSelectionScreen>.instance.DisableFightButton();
				PHDOCKCBJOF = new WaitForSeconds(1006f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				GuiElementSingle<TutorialDialog>.instance.GFCPBIFKFIJ(Localization.Localize("Silver"), Localization.Localize("DecalManagerData"), 163f, TutorialDialog.DODBDLEJOAM.TopLeft, true);
				PHDOCKCBJOF = new WaitForSeconds(559f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 2u:
			case 3u:
				if (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				goto case 4u;
			case 4u:
				if (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1692f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				break;
			case 5u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("DeviceTokenUpdate, playerid = ");
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckCards()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 6u:
				PHDOCKCBJOF = new WaitForSeconds(1262f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 7u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ArmyPower");
				UIDraggablePanel.panelDisabled = true;
				BJGCPDNMHDH.fightPressed = true;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void KNFDDIHLBKJ()
		{
			throw new NotSupportedException();
		}

		public bool LLOCENNFFFJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				UIDraggablePanel.panelDisabled = false;
				BJGCPDNMHDH.fightPressed = true;
				UnityEngine.Debug.Log(GuiScreenSingle<CardSelectionScreen>.instance);
				GuiScreenSingle<CardSelectionScreen>.instance.OHACNCHPIPD();
				PHDOCKCBJOF = new WaitForSeconds(1460f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				GuiElementSingle<TutorialDialog>.instance.HBNEPCEAGLH(Localization.Localize("FuseSDK: Parsing error in _GameDataSetAcknowledged"), Localization.Localize("NEIN"), 907f, TutorialDialog.DODBDLEJOAM.TopLeft);
				PHDOCKCBJOF = new WaitForSeconds(1496f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 2u:
			case 3u:
				if (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				goto case 4u;
			case 4u:
				if (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1696f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				break;
			case 5u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("DB_enviroment");
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckCards()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 6u:
				PHDOCKCBJOF = new WaitForSeconds(866f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 7u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_FACEBOOKLOGOUTLEGALTEXT2");
				UIDraggablePanel.panelDisabled = false;
				BJGCPDNMHDH.fightPressed = true;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void HCJOIAHBFGB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void KHMNEOBMJLN()
		{
			throw new NotSupportedException();
		}

		public void JKOCLGOOBEK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void ODPKEEIHOPK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void NIGDCBDKKMJ()
		{
			throw new NotSupportedException();
		}

		public void LHADJAFHDDC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool CJGKHIPOBGP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				UIDraggablePanel.panelDisabled = false;
				BJGCPDNMHDH.fightPressed = false;
				UnityEngine.Debug.Log(GuiScreenSingle<CardSelectionScreen>.instance);
				GuiScreenSingle<CardSelectionScreen>.instance.OHACNCHPIPD();
				PHDOCKCBJOF = new WaitForSeconds(1967f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				GuiElementSingle<TutorialDialog>.instance.CNLFPNFIBIO(Localization.Localize("hiding dialog............"), Localization.Localize("ID_PHASECLOSED"), 1162f, TutorialDialog.DODBDLEJOAM.TopLeft);
				PHDOCKCBJOF = new WaitForSeconds(368f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 2u:
			case 3u:
				if (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				goto case 4u;
			case 4u:
				if (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1754f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				break;
			case 5u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_EMPTYSQUADNAME");
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckCards()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 6u:
				PHDOCKCBJOF = new WaitForSeconds(105f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 7u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Saved_data.csv");
				UIDraggablePanel.panelDisabled = true;
				BJGCPDNMHDH.fightPressed = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void CPOKHODGGLN()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JALKNCBEINE()
		{
			return PHDOCKCBJOF;
		}
	}

	private sealed class DBGNGDGLECF : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal int ADMPALFACLD;

		internal List<CardContainer>.Enumerator KFCAECGLKKO;

		internal List<CardContainer>.Enumerator GHCPBBJDIBB;

		internal Transform JDJCJNHOCKB;

		internal TutorialManagerPlayWarcards BJGCPDNMHDH;

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
		private object ENKCCCABFFB()
		{
			return PHDOCKCBJOF;
		}

		public void NINFNJOMJOD()
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
			case 1u:
				if (ADMPALFACLD < 3)
				{
					ADMPALFACLD = 0;
					GHCPBBJDIBB = GuiScreenSingle<CardSelectionScreen>.instance.KJJBNILDGLB.GetEnumerator();
					try
					{
						while (GHCPBBJDIBB.MoveNext())
						{
							CardContainer current2 = GHCPBBJDIBB.Current;
							if (current2.isAvailable && !current2.isEmpty)
							{
								ADMPALFACLD++;
							}
						}
					}
					finally
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
					JDJCJNHOCKB = BJGCPDNMHDH.AvailableCardRecord();
					if (JDJCJNHOCKB != null && ADMPALFACLD < 3)
					{
						GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateSwipeAnimation(JDJCJNHOCKB.position, BJGCPDNMHDH.AvailableCardContainer().position);
					}
					if (GuiElementSingle<TutorialDialog>.instance.isShowed)
					{
						PHDOCKCBJOF = null;
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						break;
					}
				}
				if (ADMPALFACLD > 2)
				{
					GuiScreenSingle<CardSelectionScreen>.instance.EnableFightButton();
				}
				if (GuiElementSingle<TutorialDialog>.instance.isShowed)
				{
					GuiElementSingle<TutorialDialog>.instance.Hide();
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopSwipeAnimation();
				goto case 2u;
			case 2u:
				if (!GuiElementSingle<TutorialDialog>.instance.isShowed && DialogManager.instance.isSomeDialogShowed)
				{
					PHDOCKCBJOF = null;
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
						CLPPIAGLCJJ = 3;
					}
				}
				break;
			case 0u:
			case 3u:
				if (!BJGCPDNMHDH.fightPressed)
				{
					ADMPALFACLD = 0;
					KFCAECGLKKO = GuiScreenSingle<CardSelectionScreen>.instance.KJJBNILDGLB.GetEnumerator();
					try
					{
						while (KFCAECGLKKO.MoveNext())
						{
							CardContainer current = KFCAECGLKKO.Current;
							if (current.isAvailable && !current.isEmpty)
							{
								ADMPALFACLD++;
							}
						}
					}
					finally
					{
						((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
					}
					if (ADMPALFACLD < 3)
					{
						GuiScreenSingle<CardSelectionScreen>.instance.DisableFightButton();
						GuiElementSingle<TutorialDialog>.instance.ShowSpecial("ID_TUTORIAL_NEWDRAGCARD", -0.7f, TutorialDialog.DODBDLEJOAM.Right);
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StartSwipeAnimation(BJGCPDNMHDH.AvailableCardRecord().position, BJGCPDNMHDH.AvailableCardContainer().position, 0.6f);
					}
					goto case 1u;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object FBPFPJOCKGD()
		{
			return PHDOCKCBJOF;
		}

		public bool MOFPMNMAOND()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				if (ADMPALFACLD < 6)
				{
					ADMPALFACLD = 1;
					GHCPBBJDIBB = GuiScreenSingle<CardSelectionScreen>.instance.KJJBNILDGLB.GetEnumerator();
					try
					{
						while (GHCPBBJDIBB.MoveNext())
						{
							CardContainer current2 = GHCPBBJDIBB.Current;
							if (current2.isAvailable && !current2.ICMDJEOIKPC())
							{
								ADMPALFACLD++;
							}
						}
					}
					finally
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
					JDJCJNHOCKB = BJGCPDNMHDH.AvailableCardRecord();
					if (JDJCJNHOCKB != null && ADMPALFACLD < 5)
					{
						GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateSwipeAnimation(JDJCJNHOCKB.position, BJGCPDNMHDH.AvailableCardContainer().position, false);
					}
					if (GuiElementSingle<TutorialDialog>.instance.NPFFMLLLDAF())
					{
						PHDOCKCBJOF = null;
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						break;
					}
				}
				if (ADMPALFACLD > 8)
				{
					GuiScreenSingle<CardSelectionScreen>.instance.BHKBNFODIPK();
				}
				if (GuiElementSingle<TutorialDialog>.instance.isShowed)
				{
					GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NEPLCBOPDEF();
				goto case 2u;
			case 2u:
				if (!GuiElementSingle<TutorialDialog>.instance.NPFFMLLLDAF() && DialogManager.instance.isSomeDialogShowed)
				{
					PHDOCKCBJOF = null;
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
						CLPPIAGLCJJ = 6;
					}
				}
				break;
			case 0u:
			case 3u:
				if (!BJGCPDNMHDH.fightPressed)
				{
					ADMPALFACLD = 1;
					KFCAECGLKKO = GuiScreenSingle<CardSelectionScreen>.instance.KJJBNILDGLB.GetEnumerator();
					try
					{
						while (KFCAECGLKKO.MoveNext())
						{
							CardContainer current = KFCAECGLKKO.Current;
							if (current.isAvailable && !current.MGOENJCJCJD())
							{
								ADMPALFACLD += 0;
							}
						}
					}
					finally
					{
						((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
					}
					if (ADMPALFACLD < 6)
					{
						GuiScreenSingle<CardSelectionScreen>.instance.OHACNCHPIPD();
						GuiElementSingle<TutorialDialog>.instance.ShowSpecial("squadName", 1681f, TutorialDialog.DODBDLEJOAM.Bottom);
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StartSwipeAnimation(BJGCPDNMHDH.AvailableCardRecord().position, BJGCPDNMHDH.AvailableCardContainer().position, 1628f, false, 1166f);
					}
					goto case 1u;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object LFEJDKIGHMI()
		{
			return PHDOCKCBJOF;
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

		[SpecialName]
		private object HCCLNDKNCIE()
		{
			return PHDOCKCBJOF;
		}

		public void DBJCDLFKDDI()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MKNFFJPADIA()
		{
			return PHDOCKCBJOF;
		}

		public void PHKDHCJBMII()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object IHAOBCEALPD()
		{
			return PHDOCKCBJOF;
		}

		public void KGLKGNBCPLM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void MEBPMHDHIPJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MHKODCGLJFD()
		{
			return PHDOCKCBJOF;
		}

		public bool CONJMMKAAGH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				if (ADMPALFACLD < 2)
				{
					ADMPALFACLD = 1;
					GHCPBBJDIBB = GuiScreenSingle<CardSelectionScreen>.instance.KJJBNILDGLB.GetEnumerator();
					try
					{
						while (GHCPBBJDIBB.MoveNext())
						{
							CardContainer current2 = GHCPBBJDIBB.Current;
							if (current2.BHJLNOCCLDO() && !current2.isEmpty)
							{
								ADMPALFACLD++;
							}
						}
					}
					finally
					{
						((IDisposable)GHCPBBJDIBB/*cast due to .constrained prefix*/).Dispose();
					}
					JDJCJNHOCKB = BJGCPDNMHDH.AvailableCardRecord();
					if (JDJCJNHOCKB != null && ADMPALFACLD < 6)
					{
						GuiElementSingle<TutorialOverlayGuiElement>.instance.IEGPPIEBKHO(JDJCJNHOCKB.position, BJGCPDNMHDH.AvailableCardContainer().position);
					}
					if (GuiElementSingle<TutorialDialog>.instance.NPFFMLLLDAF())
					{
						PHDOCKCBJOF = null;
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						break;
					}
				}
				if (ADMPALFACLD > 2)
				{
					GuiScreenSingle<CardSelectionScreen>.instance.EnableFightButton();
				}
				if (GuiElementSingle<TutorialDialog>.instance.isShowed)
				{
					GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.HMPAKNMIOEC();
				goto case 2u;
			case 2u:
				if (!GuiElementSingle<TutorialDialog>.instance.isShowed && DialogManager.instance.isSomeDialogShowed)
				{
					PHDOCKCBJOF = null;
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
			case 0u:
			case 3u:
				if (!BJGCPDNMHDH.fightPressed)
				{
					ADMPALFACLD = 1;
					KFCAECGLKKO = GuiScreenSingle<CardSelectionScreen>.instance.KJJBNILDGLB.GetEnumerator();
					try
					{
						while (KFCAECGLKKO.MoveNext())
						{
							CardContainer current = KFCAECGLKKO.Current;
							if (current.isAvailable && !current.MGOENJCJCJD())
							{
								ADMPALFACLD++;
							}
						}
					}
					finally
					{
						((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
					}
					if (ADMPALFACLD < 2)
					{
						GuiScreenSingle<CardSelectionScreen>.instance.DisableFightButton();
						GuiElementSingle<TutorialDialog>.instance.GKODNFIOLPB("Found starting warbucks currency = ", 1969f, TutorialDialog.DODBDLEJOAM.TopLeft);
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StartSwipeAnimation(BJGCPDNMHDH.AvailableCardRecord().position, BJGCPDNMHDH.AvailableCardContainer().position, 308f, false, 797f);
					}
					goto case 1u;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void HPJKDIGCCCE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object KBEEEOJMBPG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GKJIGGAAHBE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FKKBFFHMEME()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public DBGNGDGLECF()
		{
		}

		public void MIEFKIEABBN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object OJMKDIBHMND()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IHPDPKLEDKC()
		{
			return PHDOCKCBJOF;
		}

		public void DLIBOPAMHAN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void JJOAHIOBOPO()
		{
			throw new NotSupportedException();
		}
	}

	private static TutorialManagerPlayWarcards mInstance;

	public const string id = "PlayWarcards";

	public CardsGuiElementNew cardGUI;

	private bool mGameStarted;

	public static TutorialManagerPlayWarcards instance
	{
		get
		{
			mInstance = mInstance ?? UnityEngine.Object.FindObjectOfType<TutorialManagerPlayWarcards>();
			return mInstance;
		}
	}

	public bool shouldStartTutorial
	{
		get
		{
			return PlayerAnalytics.instance.data.cardTutState == 1 && !LevelManager.instance.isWarcardsLocked;
		}
	}

	public bool fightPressed { get; set; }

	public override bool autoDeployEnabled
	{
		get
		{
			return true;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		mInstance = this;
		Singleton<GameController>.instance.GameStarted += OnGameStarted;
		Singleton<GameController>.instance.GameEnded += OnGameEnded;
		AIObject.AfterSpawned += AfterSpawned;
	}

	public override void FinishTutorial()
	{
		base.FinishTutorial();
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StopSwipeAnimation();
	}

	private void OnGameStarted()
	{
		if (base.isTutorialRunning)
		{
			mGameStarted = true;
		}
	}

	private void OnGameEnded(GameController.HKGHCIEPGEL obj)
	{
		if (base.isTutorialRunning)
		{
			if (obj != GameController.HKGHCIEPGEL.Forfeit)
			{
				UnityEngine.Debug.Log(string.Concat("#VAVRO# IT WAS ", obj, " IN TUTORIAL"));
				PlayerAnalytics.instance.data.cardTutState = 2;
			}
			else
			{
				Singleton<GameController>.instance.CBAPHFGNLLH.RemoveCardsForCardsTutorial();
				UnityEngine.Debug.LogError("IT WAS FORFEIT IN TUTORIAL");
			}
			Singleton<EventTrackingManager>.instance.RegisterTutorialGameEnded(6, "604 GAME END");
			Singleton<AtlasPreparer>.instance.UnloadTutorial();
			StopAllCoroutines();
			GuiElementSingle<TutorialDialog>.instance.HideDialog();
			UnityEngine.Debug.Log("*****   Bootcamp Play warcards Ended   *****");
		}
	}

	public override void StartTutorial(bool isContinue)
	{
		data.started = true;
		Save();
		base.StartTutorial(isContinue);
		Singleton<GameController>.instance.SwitchToDeathMatch();
		Singleton<GameController>.instance.GMNKFFNFEHG.StartTutorialMatch();
		GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
		StartCoroutine(RadicalRoutine.Run(Tutorial()));
	}

	[DebuggerHidden]
	private IEnumerator Tutorial()
	{
		KAAENBBKGGF kAAENBBKGGF = new KAAENBBKGGF();
		kAAENBBKGGF.BJGCPDNMHDH = this;
		return kAAENBBKGGF;
	}

	[DebuggerHidden]
	private IEnumerator Welcome()
	{
		MBOAFNJNLAC mBOAFNJNLAC = new MBOAFNJNLAC();
		mBOAFNJNLAC.BJGCPDNMHDH = this;
		return mBOAFNJNLAC;
	}

	[DebuggerHidden]
	private IEnumerator GameCardTutorial()
	{
		HFBKLMNHKKA hFBKLMNHKKA = new HFBKLMNHKKA();
		hFBKLMNHKKA.BJGCPDNMHDH = this;
		return hFBKLMNHKKA;
	}

	[DebuggerHidden]
	private IEnumerator CardSelection()
	{
		BEOBPDLHFPH bEOBPDLHFPH = new BEOBPDLHFPH();
		bEOBPDLHFPH.BJGCPDNMHDH = this;
		return bEOBPDLHFPH;
	}

	[DebuggerHidden]
	private IEnumerator CheckCards()
	{
		DBGNGDGLECF dBGNGDGLECF = new DBGNGDGLECF();
		dBGNGDGLECF.BJGCPDNMHDH = this;
		return dBGNGDGLECF;
	}

	private Transform AvailableCardContainer()
	{
		foreach (CardContainer item in GuiScreenSingle<CardSelectionScreen>.instance.KJJBNILDGLB)
		{
			if (item.isAvailable && item.isEmpty)
			{
				return item.transform;
			}
		}
		return null;
	}

	private Transform AvailableCardRecord()
	{
		foreach (CardRecord value in GuiScreenSingle<CardSelectionScreen>.instance.instantiatedCards.Values)
		{
			if (value.isAvailable)
			{
				return value.transform;
			}
		}
		return null;
	}
}
