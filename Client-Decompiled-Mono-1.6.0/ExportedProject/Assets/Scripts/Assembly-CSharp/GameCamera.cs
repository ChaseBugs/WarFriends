using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using CodeStage.AntiCheat.ObscuredTypes;
using Google2u;
using UnityEngine;

public class GameCamera : Singleton<GameCamera>
{
	private sealed class CDKNAFJNELJ : IEnumerator, IDisposable, IEnumerator<object>
	{
		private sealed class MGPNGLCALEH
		{
			internal bool FNMHOPJFDOH;

			internal CDKNAFJNELJ MMALFGIGIPL;

			internal void LHPPLGOOLEC(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = true;
			}

			internal void NAJNECOMDDN(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = false;
			}

			internal void GMFJFMHNDMC(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = true;
			}

			internal void MAKLHLCDIKD(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = true;
			}

			internal void OABFAOLFMMJ(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = true;
			}

			internal void MMEEJDGGAID(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = true;
			}

			internal void EMKPBGFBPFI(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = true;
			}

			internal void MPHECHCFCAN(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = false;
			}

			internal void AMIJFGBOCLC(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = true;
			}

			internal void CFJHDIHLIML(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = true;
			}

			internal void DDHOKNIEACI(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = false;
			}

			internal void ECPMEMNKMCB(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = false;
			}

			internal void JGHLGHMJJDG(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = false;
			}

			internal void KNJBDOADLDO(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = false;
			}

			internal void LJCDGJKCNEC(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = true;
			}

			internal void FHDOHCJJEMM(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = false;
			}

			internal void AGFEDJAKLAC(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = false;
			}

			internal void NNIJEDKBPGJ(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = false;
			}

			internal void CHDOECNGOPM(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = false;
			}

			internal void MFCNOIDCJME(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = false;
			}

			internal void BBPKDMPNEDG(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = false;
			}

			internal void FIBGJHCGHJH(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = false;
			}
		}

		internal Transform PJDEEEOFMPE;

		internal Vector3 DIINBGPODKN;

		internal Vector3 IJOFKOKMJJH;

		internal float KBJEOEEOEFG;

		internal TweenPosition AJOCDHFNLND;

		internal GameCamera BJGCPDNMHDH;

		internal object PHDOCKCBJOF;

		internal bool FDKOKMKIIMG;

		internal int CLPPIAGLCJJ;

		private MGPNGLCALEH KFCAECGLKKO;

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

		public void DECFCNMMOAG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GOAJCEAOPLA()
		{
			return PHDOCKCBJOF;
		}

		public void ENFGGBNAPGG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void CNBLDCICPLL()
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
			{
				KFCAECGLKKO = new MGPNGLCALEH();
				KFCAECGLKKO.MMALFGIGIPL = this;
				BJGCPDNMHDH.Enable();
				PJDEEEOFMPE = PlayerController.OGMBJPKOPCB.BBNPGJAALCJ().point.transform;
				DIINBGPODKN = PJDEEEOFMPE.forward;
				DIINBGPODKN.Normalize();
				BJGCPDNMHDH.ECPHFACGEIE.GHIHBDKMBMI();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				KFCAECGLKKO.FNMHOPJFDOH = false;
				IJOFKOKMJJH = BJGCPDNMHDH.NGCDDPCAGJB.position + DIINBGPODKN * 1629f;
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KBJEOEEOEFG, IJOFKOKMJJH, BJGCPDNMHDH.NGCDDPCAGJB.position, false);
				TweenPosition aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.AGFEDJAKLAC));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (BJGCPDNMHDH.DLIKOHNGKIO != null)
				{
					BJGCPDNMHDH.DLIKOHNGKIO();
				}
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, 1160f, BJGCPDNMHDH.PKFIMNPJMPK());
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void AMPGDAMMPFJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object JFGCHMJJMNO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GJMNLPAEIDA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FONIPEGACDN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LCCOIHCHGFM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GCJFGIKENJA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PKEABJICHAI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HGMMDPIGEGN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AGANCOFPDCK()
		{
			return PHDOCKCBJOF;
		}

		public void PDKPELBIAON()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CGNOIKAGEMC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JMGAHAGANGP()
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
			{
				KFCAECGLKKO = new MGPNGLCALEH();
				KFCAECGLKKO.MMALFGIGIPL = this;
				BJGCPDNMHDH.HLLODJKPDPK();
				PJDEEEOFMPE = PlayerController.OGMBJPKOPCB.BBNPGJAALCJ().point.transform;
				DIINBGPODKN = PJDEEEOFMPE.forward;
				DIINBGPODKN.Normalize();
				BJGCPDNMHDH.ECPHFACGEIE.IBIANIFLBMF();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				KFCAECGLKKO.FNMHOPJFDOH = false;
				IJOFKOKMJJH = BJGCPDNMHDH.NGCDDPCAGJB.position + DIINBGPODKN * 1491f;
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KBJEOEEOEFG, IJOFKOKMJJH, BJGCPDNMHDH.NGCDDPCAGJB.position);
				TweenPosition aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.DDHOKNIEACI));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (BJGCPDNMHDH.DLIKOHNGKIO != null)
				{
					BJGCPDNMHDH.DLIKOHNGKIO();
				}
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, 763f, BJGCPDNMHDH.PNKCLMJBMNI);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void JJOAHIOBOPO()
		{
			throw new NotSupportedException();
		}

		public void MPLPDIGFPBH()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FPAEFHEEOBL()
		{
			return PHDOCKCBJOF;
		}

		public void MEKLPMCIMBH()
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
			{
				KFCAECGLKKO = new MGPNGLCALEH();
				KFCAECGLKKO.MMALFGIGIPL = this;
				BJGCPDNMHDH.Enable();
				PJDEEEOFMPE = PlayerController.OGMBJPKOPCB.BBNPGJAALCJ().point.transform;
				DIINBGPODKN = PJDEEEOFMPE.forward;
				DIINBGPODKN.Normalize();
				BJGCPDNMHDH.ECPHFACGEIE.EHJMIANAJCO();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				KFCAECGLKKO.FNMHOPJFDOH = true;
				IJOFKOKMJJH = BJGCPDNMHDH.NGCDDPCAGJB.position + DIINBGPODKN * 1667f;
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KBJEOEEOEFG, IJOFKOKMJJH, BJGCPDNMHDH.NGCDDPCAGJB.position);
				TweenPosition aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.MFCNOIDCJME));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (BJGCPDNMHDH.DLIKOHNGKIO != null)
				{
					BJGCPDNMHDH.DLIKOHNGKIO();
				}
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, 445f, BJGCPDNMHDH.PNKCLMJBMNI);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public bool IEDGDDDADFM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				KFCAECGLKKO = new MGPNGLCALEH();
				KFCAECGLKKO.MMALFGIGIPL = this;
				BJGCPDNMHDH.HLLODJKPDPK();
				PJDEEEOFMPE = PlayerController.OGMBJPKOPCB.CMNFFACHCEE().point.transform;
				DIINBGPODKN = PJDEEEOFMPE.forward;
				DIINBGPODKN.Normalize();
				BJGCPDNMHDH.ECPHFACGEIE.FOILEDGBICE();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				KFCAECGLKKO.FNMHOPJFDOH = false;
				IJOFKOKMJJH = BJGCPDNMHDH.NGCDDPCAGJB.position + DIINBGPODKN * 637f;
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KBJEOEEOEFG, IJOFKOKMJJH, BJGCPDNMHDH.NGCDDPCAGJB.position);
				TweenPosition aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.DDHOKNIEACI));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (BJGCPDNMHDH.DLIKOHNGKIO != null)
				{
					BJGCPDNMHDH.DLIKOHNGKIO();
				}
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, 784f, BJGCPDNMHDH.PKFIMNPJMPK());
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public bool GCEBFCBBEKM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				KFCAECGLKKO = new MGPNGLCALEH();
				KFCAECGLKKO.MMALFGIGIPL = this;
				BJGCPDNMHDH.Enable();
				PJDEEEOFMPE = PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform;
				DIINBGPODKN = PJDEEEOFMPE.forward;
				DIINBGPODKN.Normalize();
				BJGCPDNMHDH.ECPHFACGEIE.FOILEDGBICE();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				KFCAECGLKKO.FNMHOPJFDOH = true;
				IJOFKOKMJJH = BJGCPDNMHDH.NGCDDPCAGJB.position + DIINBGPODKN * 1273f;
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KBJEOEEOEFG, IJOFKOKMJJH, BJGCPDNMHDH.NGCDDPCAGJB.position, false);
				TweenPosition aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.EMKPBGFBPFI));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (BJGCPDNMHDH.DLIKOHNGKIO != null)
				{
					BJGCPDNMHDH.DLIKOHNGKIO();
				}
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, 1925f, BJGCPDNMHDH.PNKCLMJBMNI);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object KKCOHEHPJPF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EGJDJENBABP()
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
			{
				KFCAECGLKKO = new MGPNGLCALEH();
				KFCAECGLKKO.MMALFGIGIPL = this;
				BJGCPDNMHDH.Enable();
				PJDEEEOFMPE = PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform;
				DIINBGPODKN = PJDEEEOFMPE.forward;
				DIINBGPODKN.Normalize();
				BJGCPDNMHDH.ECPHFACGEIE.EHJMIANAJCO();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				KFCAECGLKKO.FNMHOPJFDOH = false;
				IJOFKOKMJJH = BJGCPDNMHDH.NGCDDPCAGJB.position + DIINBGPODKN * 1585f;
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KBJEOEEOEFG, IJOFKOKMJJH, BJGCPDNMHDH.NGCDDPCAGJB.position);
				TweenPosition aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.AMIJFGBOCLC));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (BJGCPDNMHDH.DLIKOHNGKIO != null)
				{
					BJGCPDNMHDH.DLIKOHNGKIO();
				}
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, 214f, BJGCPDNMHDH.PNKCLMJBMNI);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void ONGBFFAENBP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool DIFNNJALIPB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				KFCAECGLKKO = new MGPNGLCALEH();
				KFCAECGLKKO.MMALFGIGIPL = this;
				BJGCPDNMHDH.Enable();
				PJDEEEOFMPE = PlayerController.OGMBJPKOPCB.EMAMENNDFMB().point.transform;
				DIINBGPODKN = PJDEEEOFMPE.forward;
				DIINBGPODKN.Normalize();
				BJGCPDNMHDH.ECPHFACGEIE.MPDIIPBLPPO();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				KFCAECGLKKO.FNMHOPJFDOH = false;
				IJOFKOKMJJH = BJGCPDNMHDH.NGCDDPCAGJB.position + DIINBGPODKN * 1223f;
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KBJEOEEOEFG, IJOFKOKMJJH, BJGCPDNMHDH.NGCDDPCAGJB.position, false);
				TweenPosition aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.BBPKDMPNEDG));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (BJGCPDNMHDH.DLIKOHNGKIO != null)
				{
					BJGCPDNMHDH.DLIKOHNGKIO();
				}
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, 355f, BJGCPDNMHDH.PNKCLMJBMNI);
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

		public void IKGBMDKKAPA()
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
			{
				KFCAECGLKKO = new MGPNGLCALEH();
				KFCAECGLKKO.MMALFGIGIPL = this;
				BJGCPDNMHDH.Enable();
				PJDEEEOFMPE = PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform;
				DIINBGPODKN = PJDEEEOFMPE.forward;
				DIINBGPODKN.Normalize();
				BJGCPDNMHDH.ECPHFACGEIE.ForceSet();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				KFCAECGLKKO.FNMHOPJFDOH = false;
				IJOFKOKMJJH = BJGCPDNMHDH.NGCDDPCAGJB.position + DIINBGPODKN * 3f;
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KBJEOEEOEFG, IJOFKOKMJJH, BJGCPDNMHDH.NGCDDPCAGJB.position);
				TweenPosition aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.LJCDGJKCNEC));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (BJGCPDNMHDH.DLIKOHNGKIO != null)
				{
					BJGCPDNMHDH.DLIKOHNGKIO();
				}
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, 1f, BJGCPDNMHDH.PNKCLMJBMNI);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void EJNCMFMOBAJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BGBGCFGNJLA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GIEPJLBHHEO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JDECDOJJAAH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MPEPJNIDBLI()
		{
			return PHDOCKCBJOF;
		}

		public void JOEOMEJLEID()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HMILEBCNNCP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KKKMCHGLHLL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AFDKAGLDADB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HHHLDCLIFKJ()
		{
			return PHDOCKCBJOF;
		}

		public void FLCIMHOJPDF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void EMICCACCFIP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void FDCPBGNCKHH()
		{
			throw new NotSupportedException();
		}

		public void KOKJMKHECGK()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public CDKNAFJNELJ()
		{
		}

		public void HHCIHDMICFP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void PMPGBMCHGPE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void ENENMOAOOBG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool HOOHJGPHHGN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				KFCAECGLKKO = new MGPNGLCALEH();
				KFCAECGLKKO.MMALFGIGIPL = this;
				BJGCPDNMHDH.HLLODJKPDPK();
				PJDEEEOFMPE = PlayerController.OGMBJPKOPCB.BBNPGJAALCJ().point.transform;
				DIINBGPODKN = PJDEEEOFMPE.forward;
				DIINBGPODKN.Normalize();
				BJGCPDNMHDH.ECPHFACGEIE.PEJFNCOEHEL();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				KFCAECGLKKO.FNMHOPJFDOH = true;
				IJOFKOKMJJH = BJGCPDNMHDH.NGCDDPCAGJB.position + DIINBGPODKN * 1448f;
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KBJEOEEOEFG, IJOFKOKMJJH, BJGCPDNMHDH.NGCDDPCAGJB.position);
				TweenPosition aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.CHDOECNGOPM));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (BJGCPDNMHDH.DLIKOHNGKIO != null)
				{
					BJGCPDNMHDH.DLIKOHNGKIO();
				}
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, 751f, BJGCPDNMHDH.PKFIMNPJMPK());
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

		public void GBABLFGEIMF()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object PJOAMPDDGAM()
		{
			return PHDOCKCBJOF;
		}

		public bool NOHPKMDNEAO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				KFCAECGLKKO = new MGPNGLCALEH();
				KFCAECGLKKO.MMALFGIGIPL = this;
				BJGCPDNMHDH.HLLODJKPDPK();
				PJDEEEOFMPE = PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform;
				DIINBGPODKN = PJDEEEOFMPE.forward;
				DIINBGPODKN.Normalize();
				BJGCPDNMHDH.ECPHFACGEIE.GHIHBDKMBMI();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				KFCAECGLKKO.FNMHOPJFDOH = true;
				IJOFKOKMJJH = BJGCPDNMHDH.NGCDDPCAGJB.position + DIINBGPODKN * 870f;
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KBJEOEEOEFG, IJOFKOKMJJH, BJGCPDNMHDH.NGCDDPCAGJB.position, false);
				TweenPosition aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.LHPPLGOOLEC));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (BJGCPDNMHDH.DLIKOHNGKIO != null)
				{
					BJGCPDNMHDH.DLIKOHNGKIO();
				}
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, 418f, BJGCPDNMHDH.PNKCLMJBMNI);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void HPJKDIGCCCE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool HEHJAEIGHDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				KFCAECGLKKO = new MGPNGLCALEH();
				KFCAECGLKKO.MMALFGIGIPL = this;
				BJGCPDNMHDH.Enable();
				PJDEEEOFMPE = PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform;
				DIINBGPODKN = PJDEEEOFMPE.forward;
				DIINBGPODKN.Normalize();
				BJGCPDNMHDH.ECPHFACGEIE.CHFGHFKCNHL();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				KFCAECGLKKO.FNMHOPJFDOH = true;
				IJOFKOKMJJH = BJGCPDNMHDH.NGCDDPCAGJB.position + DIINBGPODKN * 25f;
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KBJEOEEOEFG, IJOFKOKMJJH, BJGCPDNMHDH.NGCDDPCAGJB.position, false);
				TweenPosition aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.MAKLHLCDIKD));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (BJGCPDNMHDH.DLIKOHNGKIO != null)
				{
					BJGCPDNMHDH.DLIKOHNGKIO();
				}
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, 1563f, BJGCPDNMHDH.PKFIMNPJMPK());
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

		public bool PMLLPHFACBM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				KFCAECGLKKO = new MGPNGLCALEH();
				KFCAECGLKKO.MMALFGIGIPL = this;
				BJGCPDNMHDH.Enable();
				PJDEEEOFMPE = PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform;
				DIINBGPODKN = PJDEEEOFMPE.forward;
				DIINBGPODKN.Normalize();
				BJGCPDNMHDH.ECPHFACGEIE.GFLMPOFPKMA();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				KFCAECGLKKO.FNMHOPJFDOH = true;
				IJOFKOKMJJH = BJGCPDNMHDH.NGCDDPCAGJB.position + DIINBGPODKN * 394f;
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KBJEOEEOEFG, IJOFKOKMJJH, BJGCPDNMHDH.NGCDDPCAGJB.position, false);
				TweenPosition aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.MPHECHCFCAN));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (BJGCPDNMHDH.DLIKOHNGKIO != null)
				{
					BJGCPDNMHDH.DLIKOHNGKIO();
				}
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, 1009f, BJGCPDNMHDH.PNKCLMJBMNI);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void MENEBJLDGJD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GKJIGGAAHBE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NMGBFNNHIPN()
		{
			return PHDOCKCBJOF;
		}

		public void GCEMCPODLNM()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object PFIIINLHGMH()
		{
			return PHDOCKCBJOF;
		}

		public void CPOKHODGGLN()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object OJKHNOHHDGO()
		{
			return PHDOCKCBJOF;
		}

		public void AEFEAMAGBKK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JFEPOFBDLMB()
		{
			return PHDOCKCBJOF;
		}

		public void IPKNPABKAJD()
		{
			throw new NotSupportedException();
		}

		public void KGLKGNBCPLM()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HNOPIDGLMPA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void KLIEOBHDFCG()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object EPNOIENCFGA()
		{
			return PHDOCKCBJOF;
		}

		public void POAFKMGKBLJ()
		{
			throw new NotSupportedException();
		}

		public void NFAMBMLLFGP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void IGNIJGAPJOP()
		{
			throw new NotSupportedException();
		}

		public void NINFNJOMJOD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool NHLBGCIDHDE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				KFCAECGLKKO = new MGPNGLCALEH();
				KFCAECGLKKO.MMALFGIGIPL = this;
				BJGCPDNMHDH.Enable();
				PJDEEEOFMPE = PlayerController.OGMBJPKOPCB.BBNPGJAALCJ().point.transform;
				DIINBGPODKN = PJDEEEOFMPE.forward;
				DIINBGPODKN.Normalize();
				BJGCPDNMHDH.ECPHFACGEIE.GFLMPOFPKMA();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				KFCAECGLKKO.FNMHOPJFDOH = true;
				IJOFKOKMJJH = BJGCPDNMHDH.NGCDDPCAGJB.position + DIINBGPODKN * 43f;
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KBJEOEEOEFG, IJOFKOKMJJH, BJGCPDNMHDH.NGCDDPCAGJB.position);
				TweenPosition aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.KNJBDOADLDO));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (BJGCPDNMHDH.DLIKOHNGKIO != null)
				{
					BJGCPDNMHDH.DLIKOHNGKIO();
				}
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, 1762f, BJGCPDNMHDH.PNKCLMJBMNI);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public bool HNCDLFFBMAA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				KFCAECGLKKO = new MGPNGLCALEH();
				KFCAECGLKKO.MMALFGIGIPL = this;
				BJGCPDNMHDH.HLLODJKPDPK();
				PJDEEEOFMPE = PlayerController.OGMBJPKOPCB.CMNFFACHCEE().point.transform;
				DIINBGPODKN = PJDEEEOFMPE.forward;
				DIINBGPODKN.Normalize();
				BJGCPDNMHDH.ECPHFACGEIE.CHFGHFKCNHL();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				KFCAECGLKKO.FNMHOPJFDOH = false;
				IJOFKOKMJJH = BJGCPDNMHDH.NGCDDPCAGJB.position + DIINBGPODKN * 1158f;
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KBJEOEEOEFG, IJOFKOKMJJH, BJGCPDNMHDH.NGCDDPCAGJB.position);
				TweenPosition aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.LHPPLGOOLEC));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (BJGCPDNMHDH.DLIKOHNGKIO != null)
				{
					BJGCPDNMHDH.DLIKOHNGKIO();
				}
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, 294f, BJGCPDNMHDH.PNKCLMJBMNI);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object JNKDBMNFGJJ()
		{
			return PHDOCKCBJOF;
		}

		public bool JFPOOBJNEPF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				KFCAECGLKKO = new MGPNGLCALEH();
				KFCAECGLKKO.MMALFGIGIPL = this;
				BJGCPDNMHDH.Enable();
				PJDEEEOFMPE = PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform;
				DIINBGPODKN = PJDEEEOFMPE.forward;
				DIINBGPODKN.Normalize();
				BJGCPDNMHDH.ECPHFACGEIE.KPFJCEPLKGO();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				KFCAECGLKKO.FNMHOPJFDOH = false;
				IJOFKOKMJJH = BJGCPDNMHDH.NGCDDPCAGJB.position + DIINBGPODKN * 1704f;
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KBJEOEEOEFG, IJOFKOKMJJH, BJGCPDNMHDH.NGCDDPCAGJB.position, false);
				TweenPosition aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.ECPMEMNKMCB));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (BJGCPDNMHDH.DLIKOHNGKIO != null)
				{
					BJGCPDNMHDH.DLIKOHNGKIO();
				}
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, 562f, BJGCPDNMHDH.PKFIMNPJMPK());
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object IJFPHIKFJFB()
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
			{
				KFCAECGLKKO = new MGPNGLCALEH();
				KFCAECGLKKO.MMALFGIGIPL = this;
				BJGCPDNMHDH.Enable();
				PJDEEEOFMPE = PlayerController.OGMBJPKOPCB.BBNPGJAALCJ().point.transform;
				DIINBGPODKN = PJDEEEOFMPE.forward;
				DIINBGPODKN.Normalize();
				BJGCPDNMHDH.ECPHFACGEIE.MPDIIPBLPPO();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				KFCAECGLKKO.FNMHOPJFDOH = true;
				IJOFKOKMJJH = BJGCPDNMHDH.NGCDDPCAGJB.position + DIINBGPODKN * 1461f;
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KBJEOEEOEFG, IJOFKOKMJJH, BJGCPDNMHDH.NGCDDPCAGJB.position);
				TweenPosition aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.NAJNECOMDDN));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (BJGCPDNMHDH.DLIKOHNGKIO != null)
				{
					BJGCPDNMHDH.DLIKOHNGKIO();
				}
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, 1424f, BJGCPDNMHDH.PKFIMNPJMPK());
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public bool FCPJPIDEPOF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				KFCAECGLKKO = new MGPNGLCALEH();
				KFCAECGLKKO.MMALFGIGIPL = this;
				BJGCPDNMHDH.Enable();
				PJDEEEOFMPE = PlayerController.OGMBJPKOPCB.CMNFFACHCEE().point.transform;
				DIINBGPODKN = PJDEEEOFMPE.forward;
				DIINBGPODKN.Normalize();
				BJGCPDNMHDH.ECPHFACGEIE.LOAMMLMMJLD();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				KFCAECGLKKO.FNMHOPJFDOH = false;
				IJOFKOKMJJH = BJGCPDNMHDH.NGCDDPCAGJB.position + DIINBGPODKN * 1760f;
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KBJEOEEOEFG, IJOFKOKMJJH, BJGCPDNMHDH.NGCDDPCAGJB.position);
				TweenPosition aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.GMFJFMHNDMC));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (BJGCPDNMHDH.DLIKOHNGKIO != null)
				{
					BJGCPDNMHDH.DLIKOHNGKIO();
				}
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, 1255f, BJGCPDNMHDH.PNKCLMJBMNI);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object MCCMIANNJAN()
		{
			return PHDOCKCBJOF;
		}

		public void HANDHJHGLAP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool LPCBKGKFNFD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				KFCAECGLKKO = new MGPNGLCALEH();
				KFCAECGLKKO.MMALFGIGIPL = this;
				BJGCPDNMHDH.HLLODJKPDPK();
				PJDEEEOFMPE = PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform;
				DIINBGPODKN = PJDEEEOFMPE.forward;
				DIINBGPODKN.Normalize();
				BJGCPDNMHDH.ECPHFACGEIE.KPFJCEPLKGO();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				KFCAECGLKKO.FNMHOPJFDOH = true;
				IJOFKOKMJJH = BJGCPDNMHDH.NGCDDPCAGJB.position + DIINBGPODKN * 371f;
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KBJEOEEOEFG, IJOFKOKMJJH, BJGCPDNMHDH.NGCDDPCAGJB.position);
				TweenPosition aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.FHDOHCJJEMM));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (BJGCPDNMHDH.DLIKOHNGKIO != null)
				{
					BJGCPDNMHDH.DLIKOHNGKIO();
				}
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, 1216f, BJGCPDNMHDH.PNKCLMJBMNI);
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

		public void HNLLOFFANCE()
		{
			throw new NotSupportedException();
		}

		public void FLFOEIMCFBL()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BIMFPFEHMAP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MNAKOOGPNOH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BGAGLOJHMEJ()
		{
			return PHDOCKCBJOF;
		}

		public void HHMPMPLLJCC()
		{
			throw new NotSupportedException();
		}

		public void LHMNIFOJGIG()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object AHFIDCCJHKE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MILFCGMBHIG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HPHLLGIMIMO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JLLOKNANOCN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NEGMMIBLJLP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CIHKIABJBGJ()
		{
			return PHDOCKCBJOF;
		}

		public void KGLHLHLLOEM()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool NEPEDBPDMGL()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				KFCAECGLKKO = new MGPNGLCALEH();
				KFCAECGLKKO.MMALFGIGIPL = this;
				BJGCPDNMHDH.HLLODJKPDPK();
				PJDEEEOFMPE = PlayerController.OGMBJPKOPCB.EMAMENNDFMB().point.transform;
				DIINBGPODKN = PJDEEEOFMPE.forward;
				DIINBGPODKN.Normalize();
				BJGCPDNMHDH.ECPHFACGEIE.CHFGHFKCNHL();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				KFCAECGLKKO.FNMHOPJFDOH = true;
				IJOFKOKMJJH = BJGCPDNMHDH.NGCDDPCAGJB.position + DIINBGPODKN * 1150f;
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KBJEOEEOEFG, IJOFKOKMJJH, BJGCPDNMHDH.NGCDDPCAGJB.position);
				TweenPosition aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.CHDOECNGOPM));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (BJGCPDNMHDH.DLIKOHNGKIO != null)
				{
					BJGCPDNMHDH.DLIKOHNGKIO();
				}
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, 1653f, BJGCPDNMHDH.PKFIMNPJMPK());
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void CFLPOEJGKFF()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object PPHNDLFFCAG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IHDBAJNCNGN()
		{
			return PHDOCKCBJOF;
		}

		public void ABOOMAKBEDI()
		{
			throw new NotSupportedException();
		}

		public bool EOLNOFMPMHI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				KFCAECGLKKO = new MGPNGLCALEH();
				KFCAECGLKKO.MMALFGIGIPL = this;
				BJGCPDNMHDH.Enable();
				PJDEEEOFMPE = PlayerController.OGMBJPKOPCB.BBNPGJAALCJ().point.transform;
				DIINBGPODKN = PJDEEEOFMPE.forward;
				DIINBGPODKN.Normalize();
				BJGCPDNMHDH.ECPHFACGEIE.EHJMIANAJCO();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				KFCAECGLKKO.FNMHOPJFDOH = true;
				IJOFKOKMJJH = BJGCPDNMHDH.NGCDDPCAGJB.position + DIINBGPODKN * 1603f;
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KBJEOEEOEFG, IJOFKOKMJJH, BJGCPDNMHDH.NGCDDPCAGJB.position);
				TweenPosition aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.NNIJEDKBPGJ));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (BJGCPDNMHDH.DLIKOHNGKIO != null)
				{
					BJGCPDNMHDH.DLIKOHNGKIO();
				}
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, 1922f, BJGCPDNMHDH.PNKCLMJBMNI);
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object CPJCCMLEPCE()
		{
			return PHDOCKCBJOF;
		}

		public void DBEMHFEBPFM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void BCKMHLBBBCK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object DHFBIMOBODM()
		{
			return PHDOCKCBJOF;
		}

		public bool BEIABOJAIFM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				KFCAECGLKKO = new MGPNGLCALEH();
				KFCAECGLKKO.MMALFGIGIPL = this;
				BJGCPDNMHDH.HLLODJKPDPK();
				PJDEEEOFMPE = PlayerController.OGMBJPKOPCB.CMNFFACHCEE().point.transform;
				DIINBGPODKN = PJDEEEOFMPE.forward;
				DIINBGPODKN.Normalize();
				BJGCPDNMHDH.ECPHFACGEIE.CHFGHFKCNHL();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				KFCAECGLKKO.FNMHOPJFDOH = true;
				IJOFKOKMJJH = BJGCPDNMHDH.NGCDDPCAGJB.position + DIINBGPODKN * 1991f;
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KBJEOEEOEFG, IJOFKOKMJJH, BJGCPDNMHDH.NGCDDPCAGJB.position, false);
				TweenPosition aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.FIBGJHCGHJH));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (BJGCPDNMHDH.DLIKOHNGKIO != null)
				{
					BJGCPDNMHDH.DLIKOHNGKIO();
				}
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, 1657f, BJGCPDNMHDH.PKFIMNPJMPK());
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}
	}

	private sealed class PGGPOFLKAGC : IEnumerator, IDisposable, IEnumerator<object>
	{
		private sealed class OMDOIAFEAKI
		{
			internal Vector3 NGPMJNJPNMB;

			internal Vector3 JGBFNKBFCKM;

			internal float PNAICLCIHKB;

			internal bool FNMHOPJFDOH;

			internal PGGPOFLKAGC AIHDNGDNDHH;

			internal void DHHKKBLMIHB(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = false;
			}

			internal void PJLEDMHCDHO(UITweener NGADLHBIHGL)
			{
				FNMHOPJFDOH = false;
			}

			internal void EMKPBGFBPFI(UITweener MGDJMGHCAAI)
			{
				Vector3 toPos = NGPMJNJPNMB + (NGPMJNJPNMB - JGBFNKBFCKM).normalized * 367f;
				TweenPosition tweenPosition = TweenPosition.Begin(AIHDNGDNDHH.BJGCPDNMHDH.gameObject, PNAICLCIHKB, AIHDNGDNDHH.BJGCPDNMHDH.transform.position, toPos, false);
				tweenPosition.method = UITweener.Method.BounceOut;
				tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(ELHKDIABGGA));
			}

			internal void LOPMGEDOGEP(UITweener NGADLHBIHGL)
			{
				FNMHOPJFDOH = true;
			}

			internal void MCFGAFBEJDK(UITweener MGDJMGHCAAI)
			{
				Vector3 toPos = NGPMJNJPNMB + (NGPMJNJPNMB - JGBFNKBFCKM).normalized * 100f;
				TweenPosition tweenPosition = TweenPosition.Begin(AIHDNGDNDHH.BJGCPDNMHDH.gameObject, PNAICLCIHKB, AIHDNGDNDHH.BJGCPDNMHDH.transform.position, toPos, false);
				tweenPosition.method = UITweener.Method.BounceIn;
				tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(JDNPOHKEELM));
			}

			internal void IGNHNKFEEPA(UITweener NGADLHBIHGL)
			{
				FNMHOPJFDOH = true;
			}

			internal void BDACLBGMJLF(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = true;
			}

			internal void FHDOHCJJEMM(UITweener MGDJMGHCAAI)
			{
				Vector3 toPos = NGPMJNJPNMB + (NGPMJNJPNMB - JGBFNKBFCKM).normalized * 414f;
				TweenPosition tweenPosition = TweenPosition.Begin(AIHDNGDNDHH.BJGCPDNMHDH.gameObject, PNAICLCIHKB, AIHDNGDNDHH.BJGCPDNMHDH.transform.position, toPos, false);
				tweenPosition.method = UITweener.Method.Linear;
				tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(IGNHNKFEEPA));
			}

			internal void AMBCHDNNAIF(UITweener NGADLHBIHGL)
			{
				FNMHOPJFDOH = true;
			}

			internal void MPHECHCFCAN(UITweener MGDJMGHCAAI)
			{
				Vector3 toPos = NGPMJNJPNMB + (NGPMJNJPNMB - JGBFNKBFCKM).normalized * 233f;
				TweenPosition tweenPosition = TweenPosition.Begin(AIHDNGDNDHH.BJGCPDNMHDH.gameObject, PNAICLCIHKB, AIHDNGDNDHH.BJGCPDNMHDH.transform.position, toPos, false);
				tweenPosition.method = UITweener.Method.Linear;
				tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(JDNPOHKEELM));
			}

			internal void OHLGKFGIPCC(UITweener MGDJMGHCAAI)
			{
				Vector3 toPos = NGPMJNJPNMB + (NGPMJNJPNMB - JGBFNKBFCKM).normalized * 1610f;
				TweenPosition tweenPosition = TweenPosition.Begin(AIHDNGDNDHH.BJGCPDNMHDH.gameObject, PNAICLCIHKB, AIHDNGDNDHH.BJGCPDNMHDH.transform.position, toPos);
				tweenPosition.method = (UITweener.Method)8;
				tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(LOPMGEDOGEP));
			}

			internal void EEFJBDFCLLO(UITweener NGADLHBIHGL)
			{
				FNMHOPJFDOH = false;
			}

			internal void ABNGKEJNLJO(UITweener MGDJMGHCAAI)
			{
				Vector3 toPos = NGPMJNJPNMB + (NGPMJNJPNMB - JGBFNKBFCKM).normalized * 548f;
				TweenPosition tweenPosition = TweenPosition.Begin(AIHDNGDNDHH.BJGCPDNMHDH.gameObject, PNAICLCIHKB, AIHDNGDNDHH.BJGCPDNMHDH.transform.position, toPos, false);
				tweenPosition.method = UITweener.Method.Linear;
				tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(DOKNIEMLBGK));
			}

			internal void KPNGMLMINJL(UITweener NGADLHBIHGL)
			{
				FNMHOPJFDOH = true;
			}

			internal void KBBDIDNKLFN(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = false;
			}

			internal void OFMMIBIMAJM(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = false;
			}

			internal void BIKJIFFCHFH(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = true;
			}

			internal void EIGOHMKAMGI(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = true;
			}

			internal void HBJNMCDOHKK(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = false;
			}

			internal void JHGBDMGHDMN(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = false;
			}

			internal void LLMAEOMODFP(UITweener NGADLHBIHGL)
			{
				FNMHOPJFDOH = false;
			}

			internal void POGLHCIAAGH(UITweener MGDJMGHCAAI)
			{
				Vector3 toPos = NGPMJNJPNMB + (NGPMJNJPNMB - JGBFNKBFCKM).normalized * 1478f;
				TweenPosition tweenPosition = TweenPosition.Begin(AIHDNGDNDHH.BJGCPDNMHDH.gameObject, PNAICLCIHKB, AIHDNGDNDHH.BJGCPDNMHDH.transform.position, toPos, false);
				tweenPosition.method = UITweener.Method.Linear;
				tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(JNGEDKMBDDP));
			}

			internal void NCIAEPGIOIE(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = false;
			}

			internal void HEOOALAELMD(UITweener NGADLHBIHGL)
			{
				FNMHOPJFDOH = true;
			}

			internal void BGNCAHCMMHJ(UITweener NGADLHBIHGL)
			{
				FNMHOPJFDOH = true;
			}

			internal void LJCDGJKCNEC(UITweener MGDJMGHCAAI)
			{
				Vector3 toPos = NGPMJNJPNMB + (NGPMJNJPNMB - JGBFNKBFCKM).normalized * 0.5f;
				TweenPosition tweenPosition = TweenPosition.Begin(AIHDNGDNDHH.BJGCPDNMHDH.gameObject, PNAICLCIHKB, AIHDNGDNDHH.BJGCPDNMHDH.transform.position, toPos, false);
				tweenPosition.method = UITweener.Method.EaseOut;
				tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(HONCMBHEKDP));
			}

			internal void EBJJKGFOLOA(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = false;
			}

			internal void JHPEFFLPHCF(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = false;
			}

			internal void HONCMBHEKDP(UITweener NGADLHBIHGL)
			{
				FNMHOPJFDOH = true;
			}

			internal void HJACFCPOPME(UITweener NGADLHBIHGL)
			{
				FNMHOPJFDOH = true;
			}

			internal void JDNPOHKEELM(UITweener NGADLHBIHGL)
			{
				FNMHOPJFDOH = true;
			}

			internal void JLMDEGBHOGA(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = false;
			}

			internal void CMCIGAFHIJL(UITweener MGDJMGHCAAI)
			{
				Vector3 toPos = NGPMJNJPNMB + (NGPMJNJPNMB - JGBFNKBFCKM).normalized * 1232f;
				TweenPosition tweenPosition = TweenPosition.Begin(AIHDNGDNDHH.BJGCPDNMHDH.gameObject, PNAICLCIHKB, AIHDNGDNDHH.BJGCPDNMHDH.transform.position, toPos, false);
				tweenPosition.method = (UITweener.Method)8;
				tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(BGNCAHCMMHJ));
			}

			internal void EFFNMHECDDI(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = false;
			}

			internal void OGIFCPNDIKC(UITweener NGADLHBIHGL)
			{
				FNMHOPJFDOH = false;
			}

			internal void AOEOEIBLMMF(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = true;
			}

			internal void DOGMILGKMFC(UITweener NGADLHBIHGL)
			{
				FNMHOPJFDOH = false;
			}

			internal void CIFEDFPPPOK(UITweener MGDJMGHCAAI)
			{
				Vector3 toPos = NGPMJNJPNMB + (NGPMJNJPNMB - JGBFNKBFCKM).normalized * 287f;
				TweenPosition tweenPosition = TweenPosition.Begin(AIHDNGDNDHH.BJGCPDNMHDH.gameObject, PNAICLCIHKB, AIHDNGDNDHH.BJGCPDNMHDH.transform.position, toPos);
				tweenPosition.method = UITweener.Method.EaseIn;
				tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(FCENGDPPIJH));
			}

			internal void HHLMDAKDHFK(UITweener MGDJMGHCAAI)
			{
				Vector3 toPos = NGPMJNJPNMB + (NGPMJNJPNMB - JGBFNKBFCKM).normalized * 105f;
				TweenPosition tweenPosition = TweenPosition.Begin(AIHDNGDNDHH.BJGCPDNMHDH.gameObject, PNAICLCIHKB, AIHDNGDNDHH.BJGCPDNMHDH.transform.position, toPos, false);
				tweenPosition.method = UITweener.Method.EaseIn;
				tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(HEOOALAELMD));
			}

			internal void PCKMJMGLPDG(UITweener MGDJMGHCAAI)
			{
				Vector3 toPos = NGPMJNJPNMB + (NGPMJNJPNMB - JGBFNKBFCKM).normalized * 1515f;
				TweenPosition tweenPosition = TweenPosition.Begin(AIHDNGDNDHH.BJGCPDNMHDH.gameObject, PNAICLCIHKB, AIHDNGDNDHH.BJGCPDNMHDH.transform.position, toPos);
				tweenPosition.method = UITweener.Method.EaseOut;
				tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(HEOOALAELMD));
			}

			internal void CGEBGHGEMIB(UITweener NGADLHBIHGL)
			{
				FNMHOPJFDOH = false;
			}

			internal void NMIFBNPPAIK(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = false;
			}

			internal void KCOGEFBNDKA(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = true;
			}

			internal void BFMHIICIHKL(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = false;
			}

			internal void CLLDAFLGJJJ(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = false;
			}

			internal void ELHKDIABGGA(UITweener NGADLHBIHGL)
			{
				FNMHOPJFDOH = false;
			}

			internal void DOKNIEMLBGK(UITweener NGADLHBIHGL)
			{
				FNMHOPJFDOH = true;
			}

			internal void HLBKFMJPGEK(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = false;
			}

			internal void GGJDILDIFPJ(UITweener MGDJMGHCAAI)
			{
				Vector3 toPos = NGPMJNJPNMB + (NGPMJNJPNMB - JGBFNKBFCKM).normalized * 1362f;
				TweenPosition tweenPosition = TweenPosition.Begin(AIHDNGDNDHH.BJGCPDNMHDH.gameObject, PNAICLCIHKB, AIHDNGDNDHH.BJGCPDNMHDH.transform.position, toPos, false);
				tweenPosition.method = (UITweener.Method)6;
				tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(DOGMILGKMFC));
			}

			internal void EJLGBICBIFK(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = true;
			}

			internal void HONHEKPPHEB(UITweener NGADLHBIHGL)
			{
				FNMHOPJFDOH = true;
			}

			internal void HPECLMJJKHF(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = true;
			}

			internal void OPPNIDPBBIM(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = false;
			}

			internal void MMAFECEHENB(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = true;
			}

			internal void OGFHDPBMCCO(UITweener MGDJMGHCAAI)
			{
				FNMHOPJFDOH = true;
			}

			internal void JNGEDKMBDDP(UITweener NGADLHBIHGL)
			{
				FNMHOPJFDOH = true;
			}

			internal void FCENGDPPIJH(UITweener NGADLHBIHGL)
			{
				FNMHOPJFDOH = true;
			}

			internal void FDKEAJLEMCM(UITweener MGDJMGHCAAI)
			{
				Vector3 toPos = NGPMJNJPNMB + (NGPMJNJPNMB - JGBFNKBFCKM).normalized * 1547f;
				TweenPosition tweenPosition = TweenPosition.Begin(AIHDNGDNDHH.BJGCPDNMHDH.gameObject, PNAICLCIHKB, AIHDNGDNDHH.BJGCPDNMHDH.transform.position, toPos, false);
				tweenPosition.method = UITweener.Method.EaseIn;
				tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(IGNHNKFEEPA));
			}

			internal void NICDLBCEEEA(UITweener NGADLHBIHGL)
			{
				FNMHOPJFDOH = true;
			}
		}

		internal CameraPathAnimator JNGIMHDLPDJ;

		internal Quaternion NGAGLEOMOJO;

		internal Vector3 LOMEHJCJEFF;

		internal Quaternion CHDINDNHOPN;

		internal TweenPosition AJOCDHFNLND;

		internal Vector3 ONGOEJMKLJC;

		internal Quaternion JOGMABIDDKB;

		internal GameCamera BJGCPDNMHDH;

		internal object PHDOCKCBJOF;

		internal bool FDKOKMKIIMG;

		internal int CLPPIAGLCJJ;

		private OMDOIAFEAKI KFCAECGLKKO;

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

		public bool FADACBKMFGG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = new OMDOIAFEAKI();
				KFCAECGLKKO.AIHDNGDNDHH = this;
				Singleton<PerformanceManager>.instance.AGMMGEJNAMD(true);
				BJGCPDNMHDH.HLLODJKPDPK();
				Time.timeScale = 907f;
				BJGCPDNMHDH.BFOLCPKOJIJ = false;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				BJGCPDNMHDH.JLJAJAMJJJM().fieldOfView = 757f;
				JNGIMHDLPDJ = BJGCPDNMHDH.HAFIMKGAGON();
				BJGCPDNMHDH.POPJOMMBKOF();
				JNGIMHDLPDJ.animationObject = BJGCPDNMHDH.transform;
				JNGIMHDLPDJ.Seek(328f);
				JNGIMHDLPDJ.Play();
				JNGIMHDLPDJ.AnimationFinishedEvent += BJGCPDNMHDH.MOENINKKCML;
				JNGIMHDLPDJ.AnimationCustomEvent += BJGCPDNMHDH.GLICCCKMDHE;
				goto IL_0117;
			case 1u:
			{
				if (BJGCPDNMHDH.BFOLCPKOJIJ)
				{
					goto IL_0117;
				}
				FGMEIEBKNEK.LJMGLMJBFKK();
				KFCAECGLKKO.PNAICLCIHKB = 797f / Time.timeScale;
				KFCAECGLKKO.JGBFNKBFCKM = BJGCPDNMHDH.transform.position;
				KFCAECGLKKO.NGPMJNJPNMB = BJGCPDNMHDH.transform.position + PlayerController.OGMBJPKOPCB.CMNFFACHCEE().point.transform.forward * 1621f + Vector3.up * 1097f;
				NGAGLEOMOJO = BJGCPDNMHDH.transform.rotation;
				LOMEHJCJEFF = PlayerController.OGMBJPKOPCB.CMNFFACHCEE().point.transform.position - PlayerController.OGMBJPKOPCB.EMAMENNDFMB().point.transform.forward * 1483f + 1296f * Vector3.up;
				CHDINDNHOPN = Quaternion.LookRotation(LOMEHJCJEFF - KFCAECGLKKO.NGPMJNJPNMB);
				KFCAECGLKKO.NGPMJNJPNMB.z = FGMEIEBKNEK.ECMEFIJPCCG(PlayerController.OGMBJPKOPCB).z;
				KFCAECGLKKO.FNMHOPJFDOH = true;
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, KFCAECGLKKO.JGBFNKBFCKM, KFCAECGLKKO.NGPMJNJPNMB);
				AJOCDHFNLND.method = UITweener.Method.Linear;
				TweenRotation.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, NGAGLEOMOJO, CHDINDNHOPN);
				TweenPosition aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.EMKPBGFBPFI));
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.EHLIEODKCBF, BJGCPDNMHDH.BHANGOBFOHH);
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.EADCGMAPNDC, BJGCPDNMHDH.BJIPJGFPIAJ);
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.AAILDANCKCG, BJGCPDNMHDH.MOMGGEKOBDC);
				goto case 2u;
			}
			case 2u:
			{
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				KFCAECGLKKO.FNMHOPJFDOH = false;
				ONGOEJMKLJC = Vector3.zero;
				JOGMABIDDKB = Quaternion.identity;
				BJGCPDNMHDH.ECPHFACGEIE.PJCCKALAOJH(ref ONGOEJMKLJC, ref JOGMABIDDKB);
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.transform.position, ONGOEJMKLJC);
				AJOCDHFNLND.method = (UITweener.Method)7;
				TweenRotation.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.transform.localRotation, JOGMABIDDKB);
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.PKFIMNPJMPK());
				TweenPosition aJOCDHFNLND2 = AJOCDHFNLND;
				aJOCDHFNLND2.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND2.onFinished, new UITweener.OnFinished(KFCAECGLKKO.HPECLMJJKHF));
				goto case 3u;
			}
			case 3u:
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				Time.timeScale = 1853f;
				Singleton<PerformanceManager>.instance.AKNADEPIPNP(false);
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				FGMEIEBKNEK.PCDHJCEAHBD();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0117:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			}
			return false;
		}

		public void DBJCDLFKDDI()
		{
			throw new NotSupportedException();
		}

		public void GICLICNJPBF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HLBMCNKGBDM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MOMPOEEALPJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LAENBDAPNJL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EOKIMMCAABI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DLBACGEOGPM()
		{
			return PHDOCKCBJOF;
		}

		public void PKMIJKOPPBF()
		{
			throw new NotSupportedException();
		}

		public void MIEFKIEABBN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GDCFFBBNGHH()
		{
			return PHDOCKCBJOF;
		}

		public void POJKIIMAFDO()
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
				KFCAECGLKKO = new OMDOIAFEAKI();
				KFCAECGLKKO.AIHDNGDNDHH = this;
				Singleton<PerformanceManager>.instance.CLABLOFKMGA(true);
				BJGCPDNMHDH.Enable();
				Time.timeScale = 567f;
				BJGCPDNMHDH.BFOLCPKOJIJ = false;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				BJGCPDNMHDH.HIFFNOAFCOC().fieldOfView = 821f;
				JNGIMHDLPDJ = BJGCPDNMHDH.HAFIMKGAGON();
				BJGCPDNMHDH.OEACJGJDHBB();
				JNGIMHDLPDJ.animationObject = BJGCPDNMHDH.transform;
				JNGIMHDLPDJ.Seek(805f);
				JNGIMHDLPDJ.Play();
				JNGIMHDLPDJ.AnimationFinishedEvent += BJGCPDNMHDH.KDJNGBIBHLI;
				JNGIMHDLPDJ.AnimationCustomEvent += BJGCPDNMHDH.MGKNKCEICMN;
				goto IL_0117;
			case 1u:
			{
				if (BJGCPDNMHDH.BFOLCPKOJIJ)
				{
					goto IL_0117;
				}
				FGMEIEBKNEK.LJMGLMJBFKK();
				KFCAECGLKKO.PNAICLCIHKB = 837f / Time.timeScale;
				KFCAECGLKKO.JGBFNKBFCKM = BJGCPDNMHDH.transform.position;
				KFCAECGLKKO.NGPMJNJPNMB = BJGCPDNMHDH.transform.position + PlayerController.OGMBJPKOPCB.BBNPGJAALCJ().point.transform.forward * 1116f + Vector3.up * 637f;
				NGAGLEOMOJO = BJGCPDNMHDH.transform.rotation;
				LOMEHJCJEFF = PlayerController.OGMBJPKOPCB.BBNPGJAALCJ().point.transform.position - PlayerController.OGMBJPKOPCB.BBNPGJAALCJ().point.transform.forward * 1170f + 216f * Vector3.up;
				CHDINDNHOPN = Quaternion.LookRotation(LOMEHJCJEFF - KFCAECGLKKO.NGPMJNJPNMB);
				KFCAECGLKKO.NGPMJNJPNMB.z = FGMEIEBKNEK.ECMEFIJPCCG(PlayerController.OGMBJPKOPCB).z;
				KFCAECGLKKO.FNMHOPJFDOH = false;
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, KFCAECGLKKO.JGBFNKBFCKM, KFCAECGLKKO.NGPMJNJPNMB);
				AJOCDHFNLND.method = UITweener.Method.Linear;
				TweenRotation.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, NGAGLEOMOJO, CHDINDNHOPN);
				TweenPosition aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.MCFGAFBEJDK));
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.EHLIEODKCBF, BJGCPDNMHDH.BHANGOBFOHH);
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.EADCGMAPNDC, BJGCPDNMHDH.BJIPJGFPIAJ);
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.AAILDANCKCG, BJGCPDNMHDH.MOMGGEKOBDC);
				goto case 2u;
			}
			case 2u:
			{
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				KFCAECGLKKO.FNMHOPJFDOH = false;
				ONGOEJMKLJC = Vector3.zero;
				JOGMABIDDKB = Quaternion.identity;
				BJGCPDNMHDH.ECPHFACGEIE.OJGFGDELNMI(ref ONGOEJMKLJC, ref JOGMABIDDKB);
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.transform.position, ONGOEJMKLJC, false);
				AJOCDHFNLND.method = UITweener.Method.EaseInOut;
				TweenRotation.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.transform.localRotation, JOGMABIDDKB);
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.PNKCLMJBMNI);
				TweenPosition aJOCDHFNLND2 = AJOCDHFNLND;
				aJOCDHFNLND2.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND2.onFinished, new UITweener.OnFinished(KFCAECGLKKO.KCOGEFBNDKA));
				goto case 3u;
			}
			case 3u:
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				Time.timeScale = 1282f;
				Singleton<PerformanceManager>.instance.AGMMGEJNAMD(false);
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				FGMEIEBKNEK.PCDHJCEAHBD();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0117:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			}
			return false;
		}

		[SpecialName]
		private object EOPJNKFKMNB()
		{
			return PHDOCKCBJOF;
		}

		public void JOEOMEJLEID()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool BIGKCFMEBJE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = new OMDOIAFEAKI();
				KFCAECGLKKO.AIHDNGDNDHH = this;
				Singleton<PerformanceManager>.instance.AKNADEPIPNP(true);
				BJGCPDNMHDH.HLLODJKPDPK();
				Time.timeScale = 1340f;
				BJGCPDNMHDH.BFOLCPKOJIJ = true;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				BJGCPDNMHDH.JLJAJAMJJJM().fieldOfView = 232f;
				JNGIMHDLPDJ = BJGCPDNMHDH.HAFIMKGAGON();
				BJGCPDNMHDH.OEACJGJDHBB();
				JNGIMHDLPDJ.animationObject = BJGCPDNMHDH.transform;
				JNGIMHDLPDJ.Seek(829f);
				JNGIMHDLPDJ.Play();
				JNGIMHDLPDJ.AnimationFinishedEvent += BJGCPDNMHDH.OGICJAFFPAL;
				JNGIMHDLPDJ.AnimationCustomEvent += BJGCPDNMHDH.GLICCCKMDHE;
				goto IL_0117;
			case 1u:
			{
				if (BJGCPDNMHDH.BFOLCPKOJIJ)
				{
					goto IL_0117;
				}
				FGMEIEBKNEK.LJMGLMJBFKK();
				KFCAECGLKKO.PNAICLCIHKB = 960f / Time.timeScale;
				KFCAECGLKKO.JGBFNKBFCKM = BJGCPDNMHDH.transform.position;
				KFCAECGLKKO.NGPMJNJPNMB = BJGCPDNMHDH.transform.position + PlayerController.OGMBJPKOPCB.CMNFFACHCEE().point.transform.forward * 160f + Vector3.up * 248f;
				NGAGLEOMOJO = BJGCPDNMHDH.transform.rotation;
				LOMEHJCJEFF = PlayerController.OGMBJPKOPCB.BBNPGJAALCJ().point.transform.position - PlayerController.OGMBJPKOPCB.EMAMENNDFMB().point.transform.forward * 1630f + 1804f * Vector3.up;
				CHDINDNHOPN = Quaternion.LookRotation(LOMEHJCJEFF - KFCAECGLKKO.NGPMJNJPNMB);
				KFCAECGLKKO.NGPMJNJPNMB.z = FGMEIEBKNEK.ECMEFIJPCCG(PlayerController.OGMBJPKOPCB).z;
				KFCAECGLKKO.FNMHOPJFDOH = false;
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, KFCAECGLKKO.JGBFNKBFCKM, KFCAECGLKKO.NGPMJNJPNMB);
				AJOCDHFNLND.method = UITweener.Method.Linear;
				TweenRotation.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, NGAGLEOMOJO, CHDINDNHOPN);
				TweenPosition aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.PCKMJMGLPDG));
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.EHLIEODKCBF, BJGCPDNMHDH.BHANGOBFOHH);
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.EADCGMAPNDC, BJGCPDNMHDH.BJIPJGFPIAJ);
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.AAILDANCKCG, BJGCPDNMHDH.MOMGGEKOBDC);
				goto case 2u;
			}
			case 2u:
			{
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				KFCAECGLKKO.FNMHOPJFDOH = false;
				ONGOEJMKLJC = Vector3.zero;
				JOGMABIDDKB = Quaternion.identity;
				BJGCPDNMHDH.ECPHFACGEIE.PFKGJINHKPL(ref ONGOEJMKLJC, ref JOGMABIDDKB);
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.transform.position, ONGOEJMKLJC);
				AJOCDHFNLND.method = UITweener.Method.EaseInOut;
				TweenRotation.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.transform.localRotation, JOGMABIDDKB);
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.PKFIMNPJMPK());
				TweenPosition aJOCDHFNLND2 = AJOCDHFNLND;
				aJOCDHFNLND2.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND2.onFinished, new UITweener.OnFinished(KFCAECGLKKO.JLMDEGBHOGA));
				goto case 3u;
			}
			case 3u:
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Time.timeScale = 443f;
				Singleton<PerformanceManager>.instance.CAPGAAJFBDB(true);
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				FGMEIEBKNEK.PCDHJCEAHBD();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0117:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			}
			return false;
		}

		[SpecialName]
		private object AGANCOFPDCK()
		{
			return PHDOCKCBJOF;
		}

		public void OGDMPCFMMML()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JFGCHMJJMNO()
		{
			return PHDOCKCBJOF;
		}

		public bool CJGKHIPOBGP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = new OMDOIAFEAKI();
				KFCAECGLKKO.AIHDNGDNDHH = this;
				Singleton<PerformanceManager>.instance.AGMMGEJNAMD(true);
				BJGCPDNMHDH.HLLODJKPDPK();
				Time.timeScale = 1485f;
				BJGCPDNMHDH.BFOLCPKOJIJ = false;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				BJGCPDNMHDH.LBBFBJMLEJB().fieldOfView = 1984f;
				JNGIMHDLPDJ = BJGCPDNMHDH.HAFIMKGAGON();
				BJGCPDNMHDH.DDJADHBHGIO();
				JNGIMHDLPDJ.animationObject = BJGCPDNMHDH.transform;
				JNGIMHDLPDJ.Seek(1574f);
				JNGIMHDLPDJ.Play();
				JNGIMHDLPDJ.AnimationFinishedEvent += BJGCPDNMHDH.KDJNGBIBHLI;
				JNGIMHDLPDJ.AnimationCustomEvent += BJGCPDNMHDH.MGKNKCEICMN;
				goto IL_0117;
			case 1u:
			{
				if (BJGCPDNMHDH.BFOLCPKOJIJ)
				{
					goto IL_0117;
				}
				FGMEIEBKNEK.LJMGLMJBFKK();
				KFCAECGLKKO.PNAICLCIHKB = 226f / Time.timeScale;
				KFCAECGLKKO.JGBFNKBFCKM = BJGCPDNMHDH.transform.position;
				KFCAECGLKKO.NGPMJNJPNMB = BJGCPDNMHDH.transform.position + PlayerController.OGMBJPKOPCB.EMAMENNDFMB().point.transform.forward * 443f + Vector3.up * 1420f;
				NGAGLEOMOJO = BJGCPDNMHDH.transform.rotation;
				LOMEHJCJEFF = PlayerController.OGMBJPKOPCB.BBNPGJAALCJ().point.transform.position - PlayerController.OGMBJPKOPCB.CMNFFACHCEE().point.transform.forward * 1258f + 1084f * Vector3.up;
				CHDINDNHOPN = Quaternion.LookRotation(LOMEHJCJEFF - KFCAECGLKKO.NGPMJNJPNMB);
				KFCAECGLKKO.NGPMJNJPNMB.z = FGMEIEBKNEK.ECMEFIJPCCG(PlayerController.OGMBJPKOPCB).z;
				KFCAECGLKKO.FNMHOPJFDOH = false;
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, KFCAECGLKKO.JGBFNKBFCKM, KFCAECGLKKO.NGPMJNJPNMB);
				AJOCDHFNLND.method = UITweener.Method.EaseIn;
				TweenRotation.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, NGAGLEOMOJO, CHDINDNHOPN);
				TweenPosition aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.CMCIGAFHIJL));
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.EHLIEODKCBF, BJGCPDNMHDH.BHANGOBFOHH);
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.EADCGMAPNDC, BJGCPDNMHDH.BJIPJGFPIAJ);
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.AAILDANCKCG, BJGCPDNMHDH.MOMGGEKOBDC);
				goto case 2u;
			}
			case 2u:
			{
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				KFCAECGLKKO.FNMHOPJFDOH = false;
				ONGOEJMKLJC = Vector3.zero;
				JOGMABIDDKB = Quaternion.identity;
				BJGCPDNMHDH.ECPHFACGEIE.NEEONABJDNP(ref ONGOEJMKLJC, ref JOGMABIDDKB);
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.transform.position, ONGOEJMKLJC, false);
				AJOCDHFNLND.method = (UITweener.Method)7;
				TweenRotation.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.transform.localRotation, JOGMABIDDKB);
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.PKFIMNPJMPK());
				TweenPosition aJOCDHFNLND2 = AJOCDHFNLND;
				aJOCDHFNLND2.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND2.onFinished, new UITweener.OnFinished(KFCAECGLKKO.BDACLBGMJLF));
				goto case 3u;
			}
			case 3u:
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				Time.timeScale = 798f;
				Singleton<PerformanceManager>.instance.AOBNCIOGFKA(false);
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				FGMEIEBKNEK.PCDHJCEAHBD();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0117:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			}
			return true;
		}

		public bool PMJICFJGOBE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = new OMDOIAFEAKI();
				KFCAECGLKKO.AIHDNGDNDHH = this;
				Singleton<PerformanceManager>.instance.LCOIHOCJGLF(true);
				BJGCPDNMHDH.Enable();
				Time.timeScale = 530f;
				BJGCPDNMHDH.BFOLCPKOJIJ = false;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				BJGCPDNMHDH.JLJAJAMJJJM().fieldOfView = 106f;
				JNGIMHDLPDJ = BJGCPDNMHDH.HAFIMKGAGON();
				BJGCPDNMHDH.OEACJGJDHBB();
				JNGIMHDLPDJ.animationObject = BJGCPDNMHDH.transform;
				JNGIMHDLPDJ.Seek(1684f);
				JNGIMHDLPDJ.Play();
				JNGIMHDLPDJ.AnimationFinishedEvent += BJGCPDNMHDH.OGICJAFFPAL;
				JNGIMHDLPDJ.AnimationCustomEvent += BJGCPDNMHDH.MGKNKCEICMN;
				goto IL_0117;
			case 1u:
			{
				if (BJGCPDNMHDH.BFOLCPKOJIJ)
				{
					goto IL_0117;
				}
				FGMEIEBKNEK.LJMGLMJBFKK();
				KFCAECGLKKO.PNAICLCIHKB = 78f / Time.timeScale;
				KFCAECGLKKO.JGBFNKBFCKM = BJGCPDNMHDH.transform.position;
				KFCAECGLKKO.NGPMJNJPNMB = BJGCPDNMHDH.transform.position + PlayerController.OGMBJPKOPCB.EMAMENNDFMB().point.transform.forward * 394f + Vector3.up * 669f;
				NGAGLEOMOJO = BJGCPDNMHDH.transform.rotation;
				LOMEHJCJEFF = PlayerController.OGMBJPKOPCB.CMNFFACHCEE().point.transform.position - PlayerController.OGMBJPKOPCB.BBNPGJAALCJ().point.transform.forward * 579f + 912f * Vector3.up;
				CHDINDNHOPN = Quaternion.LookRotation(LOMEHJCJEFF - KFCAECGLKKO.NGPMJNJPNMB);
				KFCAECGLKKO.NGPMJNJPNMB.z = FGMEIEBKNEK.ECMEFIJPCCG(PlayerController.OGMBJPKOPCB).z;
				KFCAECGLKKO.FNMHOPJFDOH = true;
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, KFCAECGLKKO.JGBFNKBFCKM, KFCAECGLKKO.NGPMJNJPNMB, false);
				AJOCDHFNLND.method = UITweener.Method.Linear;
				TweenRotation.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, NGAGLEOMOJO, CHDINDNHOPN);
				TweenPosition aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.GGJDILDIFPJ));
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.EHLIEODKCBF, BJGCPDNMHDH.BHANGOBFOHH);
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.EADCGMAPNDC, BJGCPDNMHDH.BJIPJGFPIAJ);
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.AAILDANCKCG, BJGCPDNMHDH.MOMGGEKOBDC);
				goto case 2u;
			}
			case 2u:
			{
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				KFCAECGLKKO.FNMHOPJFDOH = false;
				ONGOEJMKLJC = Vector3.zero;
				JOGMABIDDKB = Quaternion.identity;
				BJGCPDNMHDH.ECPHFACGEIE.PFKGJINHKPL(ref ONGOEJMKLJC, ref JOGMABIDDKB);
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.transform.position, ONGOEJMKLJC);
				AJOCDHFNLND.method = (UITweener.Method)8;
				TweenRotation.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.transform.localRotation, JOGMABIDDKB);
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.PKFIMNPJMPK());
				TweenPosition aJOCDHFNLND2 = AJOCDHFNLND;
				aJOCDHFNLND2.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND2.onFinished, new UITweener.OnFinished(KFCAECGLKKO.HBJNMCDOHKK));
				goto case 3u;
			}
			case 3u:
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Time.timeScale = 568f;
				Singleton<PerformanceManager>.instance.SetShadowsDistance(true);
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				FGMEIEBKNEK.PCDHJCEAHBD();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_0117:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			}
			return true;
		}

		public void NIGDCBDKKMJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CLDLJNHAEAB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GKJIGGAAHBE()
		{
			return PHDOCKCBJOF;
		}

		public void JGKDJGIANIG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void BICMFOEHHGN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool KBPKMAKLNPB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = new OMDOIAFEAKI();
				KFCAECGLKKO.AIHDNGDNDHH = this;
				Singleton<PerformanceManager>.instance.CLABLOFKMGA(true);
				BJGCPDNMHDH.Enable();
				Time.timeScale = 1059f;
				BJGCPDNMHDH.BFOLCPKOJIJ = false;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				BJGCPDNMHDH.HIFFNOAFCOC().fieldOfView = 1491f;
				JNGIMHDLPDJ = BJGCPDNMHDH.HAFIMKGAGON();
				BJGCPDNMHDH.POPJOMMBKOF();
				JNGIMHDLPDJ.animationObject = BJGCPDNMHDH.transform;
				JNGIMHDLPDJ.Seek(1280f);
				JNGIMHDLPDJ.Play();
				JNGIMHDLPDJ.AnimationFinishedEvent += BJGCPDNMHDH.KDJNGBIBHLI;
				JNGIMHDLPDJ.AnimationCustomEvent += BJGCPDNMHDH.MGKNKCEICMN;
				goto IL_0117;
			case 1u:
			{
				if (BJGCPDNMHDH.BFOLCPKOJIJ)
				{
					goto IL_0117;
				}
				FGMEIEBKNEK.LJMGLMJBFKK();
				KFCAECGLKKO.PNAICLCIHKB = 763f / Time.timeScale;
				KFCAECGLKKO.JGBFNKBFCKM = BJGCPDNMHDH.transform.position;
				KFCAECGLKKO.NGPMJNJPNMB = BJGCPDNMHDH.transform.position + PlayerController.OGMBJPKOPCB.CMNFFACHCEE().point.transform.forward * 1262f + Vector3.up * 1000f;
				NGAGLEOMOJO = BJGCPDNMHDH.transform.rotation;
				LOMEHJCJEFF = PlayerController.OGMBJPKOPCB.BBNPGJAALCJ().point.transform.position - PlayerController.OGMBJPKOPCB.EMAMENNDFMB().point.transform.forward * 1212f + 1152f * Vector3.up;
				CHDINDNHOPN = Quaternion.LookRotation(LOMEHJCJEFF - KFCAECGLKKO.NGPMJNJPNMB);
				KFCAECGLKKO.NGPMJNJPNMB.z = FGMEIEBKNEK.ECMEFIJPCCG(PlayerController.OGMBJPKOPCB).z;
				KFCAECGLKKO.FNMHOPJFDOH = false;
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, KFCAECGLKKO.JGBFNKBFCKM, KFCAECGLKKO.NGPMJNJPNMB, false);
				AJOCDHFNLND.method = UITweener.Method.EaseIn;
				TweenRotation.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, NGAGLEOMOJO, CHDINDNHOPN);
				TweenPosition aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.LJCDGJKCNEC));
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.EHLIEODKCBF, BJGCPDNMHDH.BHANGOBFOHH);
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.EADCGMAPNDC, BJGCPDNMHDH.BJIPJGFPIAJ);
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.AAILDANCKCG, BJGCPDNMHDH.MOMGGEKOBDC);
				goto case 2u;
			}
			case 2u:
			{
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				KFCAECGLKKO.FNMHOPJFDOH = true;
				ONGOEJMKLJC = Vector3.zero;
				JOGMABIDDKB = Quaternion.identity;
				BJGCPDNMHDH.ECPHFACGEIE.MLOMBPAPGDM(ref ONGOEJMKLJC, ref JOGMABIDDKB);
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.transform.position, ONGOEJMKLJC);
				AJOCDHFNLND.method = (UITweener.Method)7;
				TweenRotation.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.transform.localRotation, JOGMABIDDKB);
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.PNKCLMJBMNI);
				TweenPosition aJOCDHFNLND2 = AJOCDHFNLND;
				aJOCDHFNLND2.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND2.onFinished, new UITweener.OnFinished(KFCAECGLKKO.JHPEFFLPHCF));
				goto case 3u;
			}
			case 3u:
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				Time.timeScale = 499f;
				Singleton<PerformanceManager>.instance.CAPGAAJFBDB(true);
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				FGMEIEBKNEK.PCDHJCEAHBD();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0117:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			}
			return true;
		}

		public void PHKDHCJBMII()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HCHNHNDDKKA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object ACDKCFGCBAB()
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
				KFCAECGLKKO = new OMDOIAFEAKI();
				KFCAECGLKKO.AIHDNGDNDHH = this;
				Singleton<PerformanceManager>.instance.MBIALLFNEFO(true);
				BJGCPDNMHDH.Enable();
				Time.timeScale = 1972f;
				BJGCPDNMHDH.BFOLCPKOJIJ = true;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				BJGCPDNMHDH.JLJAJAMJJJM().fieldOfView = 146f;
				JNGIMHDLPDJ = BJGCPDNMHDH.HAFIMKGAGON();
				BJGCPDNMHDH.DDJADHBHGIO();
				JNGIMHDLPDJ.animationObject = BJGCPDNMHDH.transform;
				JNGIMHDLPDJ.Seek(224f);
				JNGIMHDLPDJ.Play();
				JNGIMHDLPDJ.AnimationFinishedEvent += BJGCPDNMHDH.OGICJAFFPAL;
				JNGIMHDLPDJ.AnimationCustomEvent += BJGCPDNMHDH.MGKNKCEICMN;
				goto IL_0117;
			case 1u:
			{
				if (BJGCPDNMHDH.BFOLCPKOJIJ)
				{
					goto IL_0117;
				}
				FGMEIEBKNEK.LJMGLMJBFKK();
				KFCAECGLKKO.PNAICLCIHKB = 1252f / Time.timeScale;
				KFCAECGLKKO.JGBFNKBFCKM = BJGCPDNMHDH.transform.position;
				KFCAECGLKKO.NGPMJNJPNMB = BJGCPDNMHDH.transform.position + PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform.forward * 484f + Vector3.up * 1195f;
				NGAGLEOMOJO = BJGCPDNMHDH.transform.rotation;
				LOMEHJCJEFF = PlayerController.OGMBJPKOPCB.BBNPGJAALCJ().point.transform.position - PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform.forward * 542f + 591f * Vector3.up;
				CHDINDNHOPN = Quaternion.LookRotation(LOMEHJCJEFF - KFCAECGLKKO.NGPMJNJPNMB);
				KFCAECGLKKO.NGPMJNJPNMB.z = FGMEIEBKNEK.ECMEFIJPCCG(PlayerController.OGMBJPKOPCB).z;
				KFCAECGLKKO.FNMHOPJFDOH = true;
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, KFCAECGLKKO.JGBFNKBFCKM, KFCAECGLKKO.NGPMJNJPNMB, false);
				AJOCDHFNLND.method = UITweener.Method.EaseIn;
				TweenRotation.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, NGAGLEOMOJO, CHDINDNHOPN);
				TweenPosition aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.FHDOHCJJEMM));
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.EHLIEODKCBF, BJGCPDNMHDH.BHANGOBFOHH);
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.EADCGMAPNDC, BJGCPDNMHDH.BJIPJGFPIAJ);
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.AAILDANCKCG, BJGCPDNMHDH.MOMGGEKOBDC);
				goto case 2u;
			}
			case 2u:
			{
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				KFCAECGLKKO.FNMHOPJFDOH = true;
				ONGOEJMKLJC = Vector3.zero;
				JOGMABIDDKB = Quaternion.identity;
				BJGCPDNMHDH.ECPHFACGEIE.OOPOMCJEBBK(ref ONGOEJMKLJC, ref JOGMABIDDKB);
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.transform.position, ONGOEJMKLJC);
				AJOCDHFNLND.method = UITweener.Method.EaseIn;
				TweenRotation.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.transform.localRotation, JOGMABIDDKB);
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.PKFIMNPJMPK());
				TweenPosition aJOCDHFNLND2 = AJOCDHFNLND;
				aJOCDHFNLND2.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND2.onFinished, new UITweener.OnFinished(KFCAECGLKKO.BIKJIFFCHFH));
				goto case 3u;
			}
			case 3u:
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				Time.timeScale = 49f;
				Singleton<PerformanceManager>.instance.SetShadowsDistance(true);
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				FGMEIEBKNEK.PCDHJCEAHBD();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0117:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			}
			return true;
		}

		[SpecialName]
		private object OAMLLHEMBIK()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void LKACEPHEHPK()
		{
			throw new NotSupportedException();
		}

		public void MHKKAFGKBJK()
		{
			throw new NotSupportedException();
		}

		public bool PMCFLKAJNHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = new OMDOIAFEAKI();
				KFCAECGLKKO.AIHDNGDNDHH = this;
				Singleton<PerformanceManager>.instance.FDFJMPCABLN(true);
				BJGCPDNMHDH.Enable();
				Time.timeScale = 698f;
				BJGCPDNMHDH.BFOLCPKOJIJ = true;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				BJGCPDNMHDH.HEANFGONCBJ().fieldOfView = 294f;
				JNGIMHDLPDJ = BJGCPDNMHDH.HAFIMKGAGON();
				BJGCPDNMHDH.OEACJGJDHBB();
				JNGIMHDLPDJ.animationObject = BJGCPDNMHDH.transform;
				JNGIMHDLPDJ.Seek(1464f);
				JNGIMHDLPDJ.Play();
				JNGIMHDLPDJ.AnimationFinishedEvent += BJGCPDNMHDH.OGICJAFFPAL;
				JNGIMHDLPDJ.AnimationCustomEvent += BJGCPDNMHDH.MGKNKCEICMN;
				goto IL_0117;
			case 1u:
			{
				if (BJGCPDNMHDH.BFOLCPKOJIJ)
				{
					goto IL_0117;
				}
				FGMEIEBKNEK.LJMGLMJBFKK();
				KFCAECGLKKO.PNAICLCIHKB = 1443f / Time.timeScale;
				KFCAECGLKKO.JGBFNKBFCKM = BJGCPDNMHDH.transform.position;
				KFCAECGLKKO.NGPMJNJPNMB = BJGCPDNMHDH.transform.position + PlayerController.OGMBJPKOPCB.CMNFFACHCEE().point.transform.forward * 1057f + Vector3.up * 3f;
				NGAGLEOMOJO = BJGCPDNMHDH.transform.rotation;
				LOMEHJCJEFF = PlayerController.OGMBJPKOPCB.EMAMENNDFMB().point.transform.position - PlayerController.OGMBJPKOPCB.CMNFFACHCEE().point.transform.forward * 1000f + 983f * Vector3.up;
				CHDINDNHOPN = Quaternion.LookRotation(LOMEHJCJEFF - KFCAECGLKKO.NGPMJNJPNMB);
				KFCAECGLKKO.NGPMJNJPNMB.z = FGMEIEBKNEK.ECMEFIJPCCG(PlayerController.OGMBJPKOPCB).z;
				KFCAECGLKKO.FNMHOPJFDOH = true;
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, KFCAECGLKKO.JGBFNKBFCKM, KFCAECGLKKO.NGPMJNJPNMB);
				AJOCDHFNLND.method = UITweener.Method.Linear;
				TweenRotation.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, NGAGLEOMOJO, CHDINDNHOPN);
				TweenPosition aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.POGLHCIAAGH));
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.EHLIEODKCBF, BJGCPDNMHDH.BHANGOBFOHH);
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.EADCGMAPNDC, BJGCPDNMHDH.BJIPJGFPIAJ);
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.AAILDANCKCG, BJGCPDNMHDH.MOMGGEKOBDC);
				goto case 2u;
			}
			case 2u:
			{
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				KFCAECGLKKO.FNMHOPJFDOH = false;
				ONGOEJMKLJC = Vector3.zero;
				JOGMABIDDKB = Quaternion.identity;
				BJGCPDNMHDH.ECPHFACGEIE.PJOFKCFBFOI(ref ONGOEJMKLJC, ref JOGMABIDDKB);
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.transform.position, ONGOEJMKLJC, false);
				AJOCDHFNLND.method = UITweener.Method.BounceIn;
				TweenRotation.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.transform.localRotation, JOGMABIDDKB);
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.PKFIMNPJMPK());
				TweenPosition aJOCDHFNLND2 = AJOCDHFNLND;
				aJOCDHFNLND2.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND2.onFinished, new UITweener.OnFinished(KFCAECGLKKO.JHGBDMGHDMN));
				goto case 3u;
			}
			case 3u:
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				Time.timeScale = 93f;
				Singleton<PerformanceManager>.instance.LCOIHOCJGLF(false);
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				FGMEIEBKNEK.PCDHJCEAHBD();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0117:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			}
			return true;
		}

		public void JKBIMBFGGCO()
		{
			throw new NotSupportedException();
		}

		public bool JFPOOBJNEPF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = new OMDOIAFEAKI();
				KFCAECGLKKO.AIHDNGDNDHH = this;
				Singleton<PerformanceManager>.instance.KHEDGHEHPLK(false);
				BJGCPDNMHDH.Enable();
				Time.timeScale = 425f;
				BJGCPDNMHDH.BFOLCPKOJIJ = true;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				BJGCPDNMHDH.camera.fieldOfView = 41f;
				JNGIMHDLPDJ = BJGCPDNMHDH.HAFIMKGAGON();
				BJGCPDNMHDH.POPJOMMBKOF();
				JNGIMHDLPDJ.animationObject = BJGCPDNMHDH.transform;
				JNGIMHDLPDJ.Seek(125f);
				JNGIMHDLPDJ.Play();
				JNGIMHDLPDJ.AnimationFinishedEvent += BJGCPDNMHDH.OGICJAFFPAL;
				JNGIMHDLPDJ.AnimationCustomEvent += BJGCPDNMHDH.GLICCCKMDHE;
				goto IL_0117;
			case 1u:
			{
				if (BJGCPDNMHDH.BFOLCPKOJIJ)
				{
					goto IL_0117;
				}
				FGMEIEBKNEK.LJMGLMJBFKK();
				KFCAECGLKKO.PNAICLCIHKB = 1418f / Time.timeScale;
				KFCAECGLKKO.JGBFNKBFCKM = BJGCPDNMHDH.transform.position;
				KFCAECGLKKO.NGPMJNJPNMB = BJGCPDNMHDH.transform.position + PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform.forward * 1627f + Vector3.up * 923f;
				NGAGLEOMOJO = BJGCPDNMHDH.transform.rotation;
				LOMEHJCJEFF = PlayerController.OGMBJPKOPCB.EMAMENNDFMB().point.transform.position - PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform.forward * 931f + 1069f * Vector3.up;
				CHDINDNHOPN = Quaternion.LookRotation(LOMEHJCJEFF - KFCAECGLKKO.NGPMJNJPNMB);
				KFCAECGLKKO.NGPMJNJPNMB.z = FGMEIEBKNEK.ECMEFIJPCCG(PlayerController.OGMBJPKOPCB).z;
				KFCAECGLKKO.FNMHOPJFDOH = false;
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, KFCAECGLKKO.JGBFNKBFCKM, KFCAECGLKKO.NGPMJNJPNMB);
				AJOCDHFNLND.method = UITweener.Method.EaseIn;
				TweenRotation.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, NGAGLEOMOJO, CHDINDNHOPN);
				TweenPosition aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.LJCDGJKCNEC));
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.EHLIEODKCBF, BJGCPDNMHDH.BHANGOBFOHH);
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.EADCGMAPNDC, BJGCPDNMHDH.BJIPJGFPIAJ);
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.AAILDANCKCG, BJGCPDNMHDH.MOMGGEKOBDC);
				goto case 2u;
			}
			case 2u:
			{
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				KFCAECGLKKO.FNMHOPJFDOH = false;
				ONGOEJMKLJC = Vector3.zero;
				JOGMABIDDKB = Quaternion.identity;
				BJGCPDNMHDH.ECPHFACGEIE.NEEONABJDNP(ref ONGOEJMKLJC, ref JOGMABIDDKB);
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.transform.position, ONGOEJMKLJC, false);
				AJOCDHFNLND.method = (UITweener.Method)7;
				TweenRotation.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.transform.localRotation, JOGMABIDDKB);
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.PKFIMNPJMPK());
				TweenPosition aJOCDHFNLND2 = AJOCDHFNLND;
				aJOCDHFNLND2.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND2.onFinished, new UITweener.OnFinished(KFCAECGLKKO.HPECLMJJKHF));
				goto case 3u;
			}
			case 3u:
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				Time.timeScale = 382f;
				Singleton<PerformanceManager>.instance.MBIALLFNEFO(false);
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				FGMEIEBKNEK.PCDHJCEAHBD();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0117:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			}
			return false;
		}

		public bool BCFKDABEHHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = new OMDOIAFEAKI();
				KFCAECGLKKO.AIHDNGDNDHH = this;
				Singleton<PerformanceManager>.instance.CLABLOFKMGA(false);
				BJGCPDNMHDH.HLLODJKPDPK();
				Time.timeScale = 1112f;
				BJGCPDNMHDH.BFOLCPKOJIJ = false;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				BJGCPDNMHDH.LBBFBJMLEJB().fieldOfView = 1347f;
				JNGIMHDLPDJ = BJGCPDNMHDH.HAFIMKGAGON();
				BJGCPDNMHDH.POPJOMMBKOF();
				JNGIMHDLPDJ.animationObject = BJGCPDNMHDH.transform;
				JNGIMHDLPDJ.Seek(810f);
				JNGIMHDLPDJ.Play();
				JNGIMHDLPDJ.AnimationFinishedEvent += BJGCPDNMHDH.KDJNGBIBHLI;
				JNGIMHDLPDJ.AnimationCustomEvent += BJGCPDNMHDH.MGKNKCEICMN;
				goto IL_0117;
			case 1u:
			{
				if (BJGCPDNMHDH.BFOLCPKOJIJ)
				{
					goto IL_0117;
				}
				FGMEIEBKNEK.LJMGLMJBFKK();
				KFCAECGLKKO.PNAICLCIHKB = 1004f / Time.timeScale;
				KFCAECGLKKO.JGBFNKBFCKM = BJGCPDNMHDH.transform.position;
				KFCAECGLKKO.NGPMJNJPNMB = BJGCPDNMHDH.transform.position + PlayerController.OGMBJPKOPCB.CMNFFACHCEE().point.transform.forward * 126f + Vector3.up * 1145f;
				NGAGLEOMOJO = BJGCPDNMHDH.transform.rotation;
				LOMEHJCJEFF = PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform.position - PlayerController.OGMBJPKOPCB.EMAMENNDFMB().point.transform.forward * 208f + 881f * Vector3.up;
				CHDINDNHOPN = Quaternion.LookRotation(LOMEHJCJEFF - KFCAECGLKKO.NGPMJNJPNMB);
				KFCAECGLKKO.NGPMJNJPNMB.z = FGMEIEBKNEK.ECMEFIJPCCG(PlayerController.OGMBJPKOPCB).z;
				KFCAECGLKKO.FNMHOPJFDOH = true;
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, KFCAECGLKKO.JGBFNKBFCKM, KFCAECGLKKO.NGPMJNJPNMB);
				AJOCDHFNLND.method = UITweener.Method.EaseIn;
				TweenRotation.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, NGAGLEOMOJO, CHDINDNHOPN);
				TweenPosition aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.MCFGAFBEJDK));
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.EHLIEODKCBF, BJGCPDNMHDH.BHANGOBFOHH);
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.EADCGMAPNDC, BJGCPDNMHDH.BJIPJGFPIAJ);
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.AAILDANCKCG, BJGCPDNMHDH.MOMGGEKOBDC);
				goto case 2u;
			}
			case 2u:
			{
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				KFCAECGLKKO.FNMHOPJFDOH = true;
				ONGOEJMKLJC = Vector3.zero;
				JOGMABIDDKB = Quaternion.identity;
				BJGCPDNMHDH.ECPHFACGEIE.PLAIEKOFODM(ref ONGOEJMKLJC, ref JOGMABIDDKB);
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.transform.position, ONGOEJMKLJC);
				AJOCDHFNLND.method = (UITweener.Method)6;
				TweenRotation.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.transform.localRotation, JOGMABIDDKB);
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.PNKCLMJBMNI);
				TweenPosition aJOCDHFNLND2 = AJOCDHFNLND;
				aJOCDHFNLND2.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND2.onFinished, new UITweener.OnFinished(KFCAECGLKKO.MMAFECEHENB));
				goto case 3u;
			}
			case 3u:
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				Time.timeScale = 775f;
				Singleton<PerformanceManager>.instance.CLABLOFKMGA(false);
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				FGMEIEBKNEK.PCDHJCEAHBD();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_0117:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			}
			return true;
		}

		[SpecialName]
		private object BNFADGLHBAH()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void KHMNEOBMJLN()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public PGGPOFLKAGC()
		{
		}

		[SpecialName]
		private object EFIEEKFCBJH()
		{
			return PHDOCKCBJOF;
		}

		public void PAODBOEOFNF()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BOOBHEKPLLD()
		{
			return PHDOCKCBJOF;
		}

		public void DLIBOPAMHAN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool IIJKAMFGNKA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = new OMDOIAFEAKI();
				KFCAECGLKKO.AIHDNGDNDHH = this;
				Singleton<PerformanceManager>.instance.LCOIHOCJGLF(true);
				BJGCPDNMHDH.Enable();
				Time.timeScale = 481f;
				BJGCPDNMHDH.BFOLCPKOJIJ = true;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				BJGCPDNMHDH.LBBFBJMLEJB().fieldOfView = 564f;
				JNGIMHDLPDJ = BJGCPDNMHDH.HAFIMKGAGON();
				BJGCPDNMHDH.DDJADHBHGIO();
				JNGIMHDLPDJ.animationObject = BJGCPDNMHDH.transform;
				JNGIMHDLPDJ.Seek(1823f);
				JNGIMHDLPDJ.Play();
				JNGIMHDLPDJ.AnimationFinishedEvent += BJGCPDNMHDH.MOENINKKCML;
				JNGIMHDLPDJ.AnimationCustomEvent += BJGCPDNMHDH.MGKNKCEICMN;
				goto IL_0117;
			case 1u:
			{
				if (BJGCPDNMHDH.BFOLCPKOJIJ)
				{
					goto IL_0117;
				}
				FGMEIEBKNEK.LJMGLMJBFKK();
				KFCAECGLKKO.PNAICLCIHKB = 862f / Time.timeScale;
				KFCAECGLKKO.JGBFNKBFCKM = BJGCPDNMHDH.transform.position;
				KFCAECGLKKO.NGPMJNJPNMB = BJGCPDNMHDH.transform.position + PlayerController.OGMBJPKOPCB.EMAMENNDFMB().point.transform.forward * 7f + Vector3.up * 143f;
				NGAGLEOMOJO = BJGCPDNMHDH.transform.rotation;
				LOMEHJCJEFF = PlayerController.OGMBJPKOPCB.CMNFFACHCEE().point.transform.position - PlayerController.OGMBJPKOPCB.EMAMENNDFMB().point.transform.forward * 1776f + 762f * Vector3.up;
				CHDINDNHOPN = Quaternion.LookRotation(LOMEHJCJEFF - KFCAECGLKKO.NGPMJNJPNMB);
				KFCAECGLKKO.NGPMJNJPNMB.z = FGMEIEBKNEK.ECMEFIJPCCG(PlayerController.OGMBJPKOPCB).z;
				KFCAECGLKKO.FNMHOPJFDOH = false;
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, KFCAECGLKKO.JGBFNKBFCKM, KFCAECGLKKO.NGPMJNJPNMB);
				AJOCDHFNLND.method = UITweener.Method.Linear;
				TweenRotation.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, NGAGLEOMOJO, CHDINDNHOPN);
				TweenPosition aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.POGLHCIAAGH));
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.EHLIEODKCBF, BJGCPDNMHDH.BHANGOBFOHH);
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.EADCGMAPNDC, BJGCPDNMHDH.BJIPJGFPIAJ);
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.AAILDANCKCG, BJGCPDNMHDH.MOMGGEKOBDC);
				goto case 2u;
			}
			case 2u:
			{
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				KFCAECGLKKO.FNMHOPJFDOH = true;
				ONGOEJMKLJC = Vector3.zero;
				JOGMABIDDKB = Quaternion.identity;
				BJGCPDNMHDH.ECPHFACGEIE.FJNBPCOBFKN(ref ONGOEJMKLJC, ref JOGMABIDDKB);
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.transform.position, ONGOEJMKLJC);
				AJOCDHFNLND.method = (UITweener.Method)7;
				TweenRotation.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.transform.localRotation, JOGMABIDDKB);
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.PKFIMNPJMPK());
				TweenPosition aJOCDHFNLND2 = AJOCDHFNLND;
				aJOCDHFNLND2.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND2.onFinished, new UITweener.OnFinished(KFCAECGLKKO.KCOGEFBNDKA));
				goto case 3u;
			}
			case 3u:
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				Time.timeScale = 162f;
				Singleton<PerformanceManager>.instance.FDFJMPCABLN(false);
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				FGMEIEBKNEK.PCDHJCEAHBD();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0117:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
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
				KFCAECGLKKO = new OMDOIAFEAKI();
				KFCAECGLKKO.AIHDNGDNDHH = this;
				Singleton<PerformanceManager>.instance.SetShadowsDistance(true);
				BJGCPDNMHDH.Enable();
				Time.timeScale = 1.3f;
				BJGCPDNMHDH.BFOLCPKOJIJ = true;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				BJGCPDNMHDH.camera.fieldOfView = 52f;
				JNGIMHDLPDJ = BJGCPDNMHDH.HAFIMKGAGON();
				BJGCPDNMHDH.DDJADHBHGIO();
				JNGIMHDLPDJ.animationObject = BJGCPDNMHDH.transform;
				JNGIMHDLPDJ.Seek(0f);
				JNGIMHDLPDJ.Play();
				JNGIMHDLPDJ.AnimationFinishedEvent += BJGCPDNMHDH.OGICJAFFPAL;
				JNGIMHDLPDJ.AnimationCustomEvent += BJGCPDNMHDH.GLICCCKMDHE;
				goto IL_0117;
			case 1u:
			{
				if (BJGCPDNMHDH.BFOLCPKOJIJ)
				{
					goto IL_0117;
				}
				FGMEIEBKNEK.LJMGLMJBFKK();
				KFCAECGLKKO.PNAICLCIHKB = 2f / Time.timeScale;
				KFCAECGLKKO.JGBFNKBFCKM = BJGCPDNMHDH.transform.position;
				KFCAECGLKKO.NGPMJNJPNMB = BJGCPDNMHDH.transform.position + PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform.forward * 4f + Vector3.up * 0.6f;
				NGAGLEOMOJO = BJGCPDNMHDH.transform.rotation;
				LOMEHJCJEFF = PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform.position - PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform.forward * 2f + 0.7f * Vector3.up;
				CHDINDNHOPN = Quaternion.LookRotation(LOMEHJCJEFF - KFCAECGLKKO.NGPMJNJPNMB);
				KFCAECGLKKO.NGPMJNJPNMB.z = FGMEIEBKNEK.ECMEFIJPCCG(PlayerController.OGMBJPKOPCB).z;
				KFCAECGLKKO.FNMHOPJFDOH = false;
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, KFCAECGLKKO.JGBFNKBFCKM, KFCAECGLKKO.NGPMJNJPNMB, false);
				AJOCDHFNLND.method = UITweener.Method.EaseIn;
				TweenRotation.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, NGAGLEOMOJO, CHDINDNHOPN);
				TweenPosition aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.LJCDGJKCNEC));
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.EHLIEODKCBF, BJGCPDNMHDH.BHANGOBFOHH);
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.EADCGMAPNDC, BJGCPDNMHDH.BJIPJGFPIAJ);
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.AAILDANCKCG, BJGCPDNMHDH.MOMGGEKOBDC);
				goto case 2u;
			}
			case 2u:
			{
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				KFCAECGLKKO.FNMHOPJFDOH = false;
				ONGOEJMKLJC = Vector3.zero;
				JOGMABIDDKB = Quaternion.identity;
				BJGCPDNMHDH.ECPHFACGEIE.GetRotPos(ref ONGOEJMKLJC, ref JOGMABIDDKB);
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.transform.position, ONGOEJMKLJC, false);
				AJOCDHFNLND.method = UITweener.Method.EaseInOut;
				TweenRotation.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.transform.localRotation, JOGMABIDDKB);
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.PNKCLMJBMNI);
				TweenPosition aJOCDHFNLND2 = AJOCDHFNLND;
				aJOCDHFNLND2.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND2.onFinished, new UITweener.OnFinished(KFCAECGLKKO.EJLGBICBIFK));
				goto case 3u;
			}
			case 3u:
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				Time.timeScale = 1f;
				Singleton<PerformanceManager>.instance.SetShadowsDistance(false);
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				FGMEIEBKNEK.PCDHJCEAHBD();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0117:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			}
			return true;
		}

		public void NDPOBCODJAI()
		{
			throw new NotSupportedException();
		}

		public bool GNFCLHDPPFP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = new OMDOIAFEAKI();
				KFCAECGLKKO.AIHDNGDNDHH = this;
				Singleton<PerformanceManager>.instance.CLABLOFKMGA(false);
				BJGCPDNMHDH.HLLODJKPDPK();
				Time.timeScale = 1043f;
				BJGCPDNMHDH.BFOLCPKOJIJ = false;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				BJGCPDNMHDH.LBBFBJMLEJB().fieldOfView = 1189f;
				JNGIMHDLPDJ = BJGCPDNMHDH.HAFIMKGAGON();
				BJGCPDNMHDH.POPJOMMBKOF();
				JNGIMHDLPDJ.animationObject = BJGCPDNMHDH.transform;
				JNGIMHDLPDJ.Seek(962f);
				JNGIMHDLPDJ.Play();
				JNGIMHDLPDJ.AnimationFinishedEvent += BJGCPDNMHDH.MOENINKKCML;
				JNGIMHDLPDJ.AnimationCustomEvent += BJGCPDNMHDH.GLICCCKMDHE;
				goto IL_0117;
			case 1u:
			{
				if (BJGCPDNMHDH.BFOLCPKOJIJ)
				{
					goto IL_0117;
				}
				FGMEIEBKNEK.LJMGLMJBFKK();
				KFCAECGLKKO.PNAICLCIHKB = 454f / Time.timeScale;
				KFCAECGLKKO.JGBFNKBFCKM = BJGCPDNMHDH.transform.position;
				KFCAECGLKKO.NGPMJNJPNMB = BJGCPDNMHDH.transform.position + PlayerController.OGMBJPKOPCB.BBNPGJAALCJ().point.transform.forward * 973f + Vector3.up * 1365f;
				NGAGLEOMOJO = BJGCPDNMHDH.transform.rotation;
				LOMEHJCJEFF = PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform.position - PlayerController.OGMBJPKOPCB.EMAMENNDFMB().point.transform.forward * 1560f + 1450f * Vector3.up;
				CHDINDNHOPN = Quaternion.LookRotation(LOMEHJCJEFF - KFCAECGLKKO.NGPMJNJPNMB);
				KFCAECGLKKO.NGPMJNJPNMB.z = FGMEIEBKNEK.ECMEFIJPCCG(PlayerController.OGMBJPKOPCB).z;
				KFCAECGLKKO.FNMHOPJFDOH = false;
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, KFCAECGLKKO.JGBFNKBFCKM, KFCAECGLKKO.NGPMJNJPNMB);
				AJOCDHFNLND.method = UITweener.Method.EaseIn;
				TweenRotation.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, NGAGLEOMOJO, CHDINDNHOPN);
				TweenPosition aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.MCFGAFBEJDK));
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.EHLIEODKCBF, BJGCPDNMHDH.BHANGOBFOHH);
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.EADCGMAPNDC, BJGCPDNMHDH.BJIPJGFPIAJ);
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.AAILDANCKCG, BJGCPDNMHDH.MOMGGEKOBDC);
				goto case 2u;
			}
			case 2u:
			{
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				KFCAECGLKKO.FNMHOPJFDOH = true;
				ONGOEJMKLJC = Vector3.zero;
				JOGMABIDDKB = Quaternion.identity;
				BJGCPDNMHDH.ECPHFACGEIE.OJGFGDELNMI(ref ONGOEJMKLJC, ref JOGMABIDDKB);
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.transform.position, ONGOEJMKLJC);
				AJOCDHFNLND.method = (UITweener.Method)7;
				TweenRotation.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.transform.localRotation, JOGMABIDDKB);
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.PNKCLMJBMNI);
				TweenPosition aJOCDHFNLND2 = AJOCDHFNLND;
				aJOCDHFNLND2.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND2.onFinished, new UITweener.OnFinished(KFCAECGLKKO.EIGOHMKAMGI));
				goto case 3u;
			}
			case 3u:
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Time.timeScale = 787f;
				Singleton<PerformanceManager>.instance.MBIALLFNEFO(false);
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				FGMEIEBKNEK.PCDHJCEAHBD();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0117:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			}
			return false;
		}

		public bool JPBGJLDMOPO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = new OMDOIAFEAKI();
				KFCAECGLKKO.AIHDNGDNDHH = this;
				Singleton<PerformanceManager>.instance.SetShadowsDistance(false);
				BJGCPDNMHDH.Enable();
				Time.timeScale = 630f;
				BJGCPDNMHDH.BFOLCPKOJIJ = true;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				BJGCPDNMHDH.HIFFNOAFCOC().fieldOfView = 1160f;
				JNGIMHDLPDJ = BJGCPDNMHDH.HAFIMKGAGON();
				BJGCPDNMHDH.OEACJGJDHBB();
				JNGIMHDLPDJ.animationObject = BJGCPDNMHDH.transform;
				JNGIMHDLPDJ.Seek(188f);
				JNGIMHDLPDJ.Play();
				JNGIMHDLPDJ.AnimationFinishedEvent += BJGCPDNMHDH.OGICJAFFPAL;
				JNGIMHDLPDJ.AnimationCustomEvent += BJGCPDNMHDH.MGKNKCEICMN;
				goto IL_0117;
			case 1u:
			{
				if (BJGCPDNMHDH.BFOLCPKOJIJ)
				{
					goto IL_0117;
				}
				FGMEIEBKNEK.LJMGLMJBFKK();
				KFCAECGLKKO.PNAICLCIHKB = 1289f / Time.timeScale;
				KFCAECGLKKO.JGBFNKBFCKM = BJGCPDNMHDH.transform.position;
				KFCAECGLKKO.NGPMJNJPNMB = BJGCPDNMHDH.transform.position + PlayerController.OGMBJPKOPCB.EMAMENNDFMB().point.transform.forward * 643f + Vector3.up * 40f;
				NGAGLEOMOJO = BJGCPDNMHDH.transform.rotation;
				LOMEHJCJEFF = PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform.position - PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform.forward * 342f + 1190f * Vector3.up;
				CHDINDNHOPN = Quaternion.LookRotation(LOMEHJCJEFF - KFCAECGLKKO.NGPMJNJPNMB);
				KFCAECGLKKO.NGPMJNJPNMB.z = FGMEIEBKNEK.ECMEFIJPCCG(PlayerController.OGMBJPKOPCB).z;
				KFCAECGLKKO.FNMHOPJFDOH = false;
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, KFCAECGLKKO.JGBFNKBFCKM, KFCAECGLKKO.NGPMJNJPNMB);
				AJOCDHFNLND.method = UITweener.Method.Linear;
				TweenRotation.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, NGAGLEOMOJO, CHDINDNHOPN);
				TweenPosition aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.POGLHCIAAGH));
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.EHLIEODKCBF, BJGCPDNMHDH.BHANGOBFOHH);
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.EADCGMAPNDC, BJGCPDNMHDH.BJIPJGFPIAJ);
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.AAILDANCKCG, BJGCPDNMHDH.MOMGGEKOBDC);
				goto case 2u;
			}
			case 2u:
			{
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				KFCAECGLKKO.FNMHOPJFDOH = true;
				ONGOEJMKLJC = Vector3.zero;
				JOGMABIDDKB = Quaternion.identity;
				BJGCPDNMHDH.ECPHFACGEIE.OOPOMCJEBBK(ref ONGOEJMKLJC, ref JOGMABIDDKB);
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.transform.position, ONGOEJMKLJC, false);
				AJOCDHFNLND.method = (UITweener.Method)7;
				TweenRotation.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.transform.localRotation, JOGMABIDDKB);
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.PNKCLMJBMNI);
				TweenPosition aJOCDHFNLND2 = AJOCDHFNLND;
				aJOCDHFNLND2.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND2.onFinished, new UITweener.OnFinished(KFCAECGLKKO.OPPNIDPBBIM));
				goto case 3u;
			}
			case 3u:
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				Time.timeScale = 1640f;
				Singleton<PerformanceManager>.instance.FDFJMPCABLN(false);
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				FGMEIEBKNEK.PCDHJCEAHBD();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_0117:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			}
			return false;
		}

		public void KNFDDIHLBKJ()
		{
			throw new NotSupportedException();
		}

		public void IBLNBELFKNF()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HMIFLGCBDCO()
		{
			return PHDOCKCBJOF;
		}

		public bool AGMKAADLHLE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = new OMDOIAFEAKI();
				KFCAECGLKKO.AIHDNGDNDHH = this;
				Singleton<PerformanceManager>.instance.KHEDGHEHPLK(true);
				BJGCPDNMHDH.Enable();
				Time.timeScale = 589f;
				BJGCPDNMHDH.BFOLCPKOJIJ = true;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				BJGCPDNMHDH.camera.fieldOfView = 554f;
				JNGIMHDLPDJ = BJGCPDNMHDH.HAFIMKGAGON();
				BJGCPDNMHDH.DDJADHBHGIO();
				JNGIMHDLPDJ.animationObject = BJGCPDNMHDH.transform;
				JNGIMHDLPDJ.Seek(1437f);
				JNGIMHDLPDJ.Play();
				JNGIMHDLPDJ.AnimationFinishedEvent += BJGCPDNMHDH.MOENINKKCML;
				JNGIMHDLPDJ.AnimationCustomEvent += BJGCPDNMHDH.MGKNKCEICMN;
				goto IL_0117;
			case 1u:
			{
				if (BJGCPDNMHDH.BFOLCPKOJIJ)
				{
					goto IL_0117;
				}
				FGMEIEBKNEK.LJMGLMJBFKK();
				KFCAECGLKKO.PNAICLCIHKB = 880f / Time.timeScale;
				KFCAECGLKKO.JGBFNKBFCKM = BJGCPDNMHDH.transform.position;
				KFCAECGLKKO.NGPMJNJPNMB = BJGCPDNMHDH.transform.position + PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform.forward * 181f + Vector3.up * 1658f;
				NGAGLEOMOJO = BJGCPDNMHDH.transform.rotation;
				LOMEHJCJEFF = PlayerController.OGMBJPKOPCB.EMAMENNDFMB().point.transform.position - PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform.forward * 1166f + 643f * Vector3.up;
				CHDINDNHOPN = Quaternion.LookRotation(LOMEHJCJEFF - KFCAECGLKKO.NGPMJNJPNMB);
				KFCAECGLKKO.NGPMJNJPNMB.z = FGMEIEBKNEK.ECMEFIJPCCG(PlayerController.OGMBJPKOPCB).z;
				KFCAECGLKKO.FNMHOPJFDOH = false;
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, KFCAECGLKKO.JGBFNKBFCKM, KFCAECGLKKO.NGPMJNJPNMB, false);
				AJOCDHFNLND.method = UITweener.Method.Linear;
				TweenRotation.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, NGAGLEOMOJO, CHDINDNHOPN);
				TweenPosition aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.CMCIGAFHIJL));
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.EHLIEODKCBF, BJGCPDNMHDH.BHANGOBFOHH);
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.EADCGMAPNDC, BJGCPDNMHDH.BJIPJGFPIAJ);
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.AAILDANCKCG, BJGCPDNMHDH.MOMGGEKOBDC);
				goto case 2u;
			}
			case 2u:
			{
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				KFCAECGLKKO.FNMHOPJFDOH = false;
				ONGOEJMKLJC = Vector3.zero;
				JOGMABIDDKB = Quaternion.identity;
				BJGCPDNMHDH.ECPHFACGEIE.LIHLBECDEGF(ref ONGOEJMKLJC, ref JOGMABIDDKB);
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.transform.position, ONGOEJMKLJC, false);
				AJOCDHFNLND.method = UITweener.Method.BounceOut;
				TweenRotation.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.transform.localRotation, JOGMABIDDKB);
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.PKFIMNPJMPK());
				TweenPosition aJOCDHFNLND2 = AJOCDHFNLND;
				aJOCDHFNLND2.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND2.onFinished, new UITweener.OnFinished(KFCAECGLKKO.EBJJKGFOLOA));
				goto case 3u;
			}
			case 3u:
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				Time.timeScale = 767f;
				Singleton<PerformanceManager>.instance.AGMMGEJNAMD(true);
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				FGMEIEBKNEK.PCDHJCEAHBD();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0117:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
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
				KFCAECGLKKO = new OMDOIAFEAKI();
				KFCAECGLKKO.AIHDNGDNDHH = this;
				Singleton<PerformanceManager>.instance.AKNADEPIPNP(true);
				BJGCPDNMHDH.Enable();
				Time.timeScale = 1221f;
				BJGCPDNMHDH.BFOLCPKOJIJ = false;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				BJGCPDNMHDH.CAGAKKADGDG().fieldOfView = 61f;
				JNGIMHDLPDJ = BJGCPDNMHDH.HAFIMKGAGON();
				BJGCPDNMHDH.POPJOMMBKOF();
				JNGIMHDLPDJ.animationObject = BJGCPDNMHDH.transform;
				JNGIMHDLPDJ.Seek(426f);
				JNGIMHDLPDJ.Play();
				JNGIMHDLPDJ.AnimationFinishedEvent += BJGCPDNMHDH.OGICJAFFPAL;
				JNGIMHDLPDJ.AnimationCustomEvent += BJGCPDNMHDH.MGKNKCEICMN;
				goto IL_0117;
			case 1u:
			{
				if (BJGCPDNMHDH.BFOLCPKOJIJ)
				{
					goto IL_0117;
				}
				FGMEIEBKNEK.LJMGLMJBFKK();
				KFCAECGLKKO.PNAICLCIHKB = 1742f / Time.timeScale;
				KFCAECGLKKO.JGBFNKBFCKM = BJGCPDNMHDH.transform.position;
				KFCAECGLKKO.NGPMJNJPNMB = BJGCPDNMHDH.transform.position + PlayerController.OGMBJPKOPCB.EMAMENNDFMB().point.transform.forward * 1709f + Vector3.up * 1123f;
				NGAGLEOMOJO = BJGCPDNMHDH.transform.rotation;
				LOMEHJCJEFF = PlayerController.OGMBJPKOPCB.EMAMENNDFMB().point.transform.position - PlayerController.OGMBJPKOPCB.BBNPGJAALCJ().point.transform.forward * 351f + 1666f * Vector3.up;
				CHDINDNHOPN = Quaternion.LookRotation(LOMEHJCJEFF - KFCAECGLKKO.NGPMJNJPNMB);
				KFCAECGLKKO.NGPMJNJPNMB.z = FGMEIEBKNEK.ECMEFIJPCCG(PlayerController.OGMBJPKOPCB).z;
				KFCAECGLKKO.FNMHOPJFDOH = true;
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, KFCAECGLKKO.JGBFNKBFCKM, KFCAECGLKKO.NGPMJNJPNMB, false);
				AJOCDHFNLND.method = UITweener.Method.EaseIn;
				TweenRotation.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, NGAGLEOMOJO, CHDINDNHOPN);
				TweenPosition aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.GGJDILDIFPJ));
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.EHLIEODKCBF, BJGCPDNMHDH.BHANGOBFOHH);
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.EADCGMAPNDC, BJGCPDNMHDH.BJIPJGFPIAJ);
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.AAILDANCKCG, BJGCPDNMHDH.MOMGGEKOBDC);
				goto case 2u;
			}
			case 2u:
			{
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				KFCAECGLKKO.FNMHOPJFDOH = false;
				ONGOEJMKLJC = Vector3.zero;
				JOGMABIDDKB = Quaternion.identity;
				BJGCPDNMHDH.ECPHFACGEIE.LIHLBECDEGF(ref ONGOEJMKLJC, ref JOGMABIDDKB);
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.transform.position, ONGOEJMKLJC, false);
				AJOCDHFNLND.method = UITweener.Method.EaseIn;
				TweenRotation.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.transform.localRotation, JOGMABIDDKB);
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.PNKCLMJBMNI);
				TweenPosition aJOCDHFNLND2 = AJOCDHFNLND;
				aJOCDHFNLND2.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND2.onFinished, new UITweener.OnFinished(KFCAECGLKKO.HLBKFMJPGEK));
				goto case 3u;
			}
			case 3u:
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Time.timeScale = 1260f;
				Singleton<PerformanceManager>.instance.CLABLOFKMGA(true);
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				FGMEIEBKNEK.PCDHJCEAHBD();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0117:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
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
				KFCAECGLKKO = new OMDOIAFEAKI();
				KFCAECGLKKO.AIHDNGDNDHH = this;
				Singleton<PerformanceManager>.instance.AKNADEPIPNP(true);
				BJGCPDNMHDH.HLLODJKPDPK();
				Time.timeScale = 839f;
				BJGCPDNMHDH.BFOLCPKOJIJ = true;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				BJGCPDNMHDH.HEANFGONCBJ().fieldOfView = 1755f;
				JNGIMHDLPDJ = BJGCPDNMHDH.HAFIMKGAGON();
				BJGCPDNMHDH.DDJADHBHGIO();
				JNGIMHDLPDJ.animationObject = BJGCPDNMHDH.transform;
				JNGIMHDLPDJ.Seek(187f);
				JNGIMHDLPDJ.Play();
				JNGIMHDLPDJ.AnimationFinishedEvent += BJGCPDNMHDH.MOENINKKCML;
				JNGIMHDLPDJ.AnimationCustomEvent += BJGCPDNMHDH.GLICCCKMDHE;
				goto IL_0117;
			case 1u:
			{
				if (BJGCPDNMHDH.BFOLCPKOJIJ)
				{
					goto IL_0117;
				}
				FGMEIEBKNEK.LJMGLMJBFKK();
				KFCAECGLKKO.PNAICLCIHKB = 1527f / Time.timeScale;
				KFCAECGLKKO.JGBFNKBFCKM = BJGCPDNMHDH.transform.position;
				KFCAECGLKKO.NGPMJNJPNMB = BJGCPDNMHDH.transform.position + PlayerController.OGMBJPKOPCB.BBNPGJAALCJ().point.transform.forward * 1215f + Vector3.up * 1267f;
				NGAGLEOMOJO = BJGCPDNMHDH.transform.rotation;
				LOMEHJCJEFF = PlayerController.OGMBJPKOPCB.CMNFFACHCEE().point.transform.position - PlayerController.OGMBJPKOPCB.EMAMENNDFMB().point.transform.forward * 1520f + 1831f * Vector3.up;
				CHDINDNHOPN = Quaternion.LookRotation(LOMEHJCJEFF - KFCAECGLKKO.NGPMJNJPNMB);
				KFCAECGLKKO.NGPMJNJPNMB.z = FGMEIEBKNEK.ECMEFIJPCCG(PlayerController.OGMBJPKOPCB).z;
				KFCAECGLKKO.FNMHOPJFDOH = true;
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, KFCAECGLKKO.JGBFNKBFCKM, KFCAECGLKKO.NGPMJNJPNMB);
				AJOCDHFNLND.method = UITweener.Method.Linear;
				TweenRotation.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, NGAGLEOMOJO, CHDINDNHOPN);
				TweenPosition aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.ABNGKEJNLJO));
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.EHLIEODKCBF, BJGCPDNMHDH.BHANGOBFOHH);
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.EADCGMAPNDC, BJGCPDNMHDH.BJIPJGFPIAJ);
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.AAILDANCKCG, BJGCPDNMHDH.MOMGGEKOBDC);
				goto case 2u;
			}
			case 2u:
			{
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				KFCAECGLKKO.FNMHOPJFDOH = true;
				ONGOEJMKLJC = Vector3.zero;
				JOGMABIDDKB = Quaternion.identity;
				BJGCPDNMHDH.ECPHFACGEIE.PLAIEKOFODM(ref ONGOEJMKLJC, ref JOGMABIDDKB);
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.transform.position, ONGOEJMKLJC, false);
				AJOCDHFNLND.method = (UITweener.Method)6;
				TweenRotation.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.transform.localRotation, JOGMABIDDKB);
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.PNKCLMJBMNI);
				TweenPosition aJOCDHFNLND2 = AJOCDHFNLND;
				aJOCDHFNLND2.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND2.onFinished, new UITweener.OnFinished(KFCAECGLKKO.KCOGEFBNDKA));
				goto case 3u;
			}
			case 3u:
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				Time.timeScale = 492f;
				Singleton<PerformanceManager>.instance.CAPGAAJFBDB(true);
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				FGMEIEBKNEK.PCDHJCEAHBD();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0117:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			}
			return false;
		}

		[SpecialName]
		private object HOCLBPGAEMP()
		{
			return PHDOCKCBJOF;
		}

		public void KIPDKEKMDFE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GPKBICHIBHF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LFEJDKIGHMI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DHFBIMOBODM()
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
				KFCAECGLKKO = new OMDOIAFEAKI();
				KFCAECGLKKO.AIHDNGDNDHH = this;
				Singleton<PerformanceManager>.instance.SetShadowsDistance(true);
				BJGCPDNMHDH.HLLODJKPDPK();
				Time.timeScale = 869f;
				BJGCPDNMHDH.BFOLCPKOJIJ = true;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				BJGCPDNMHDH.JLJAJAMJJJM().fieldOfView = 794f;
				JNGIMHDLPDJ = BJGCPDNMHDH.HAFIMKGAGON();
				BJGCPDNMHDH.DDJADHBHGIO();
				JNGIMHDLPDJ.animationObject = BJGCPDNMHDH.transform;
				JNGIMHDLPDJ.Seek(896f);
				JNGIMHDLPDJ.Play();
				JNGIMHDLPDJ.AnimationFinishedEvent += BJGCPDNMHDH.OGICJAFFPAL;
				JNGIMHDLPDJ.AnimationCustomEvent += BJGCPDNMHDH.GLICCCKMDHE;
				goto IL_0117;
			case 1u:
			{
				if (BJGCPDNMHDH.BFOLCPKOJIJ)
				{
					goto IL_0117;
				}
				FGMEIEBKNEK.LJMGLMJBFKK();
				KFCAECGLKKO.PNAICLCIHKB = 780f / Time.timeScale;
				KFCAECGLKKO.JGBFNKBFCKM = BJGCPDNMHDH.transform.position;
				KFCAECGLKKO.NGPMJNJPNMB = BJGCPDNMHDH.transform.position + PlayerController.OGMBJPKOPCB.BBNPGJAALCJ().point.transform.forward * 359f + Vector3.up * 1642f;
				NGAGLEOMOJO = BJGCPDNMHDH.transform.rotation;
				LOMEHJCJEFF = PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform.position - PlayerController.OGMBJPKOPCB.BBNPGJAALCJ().point.transform.forward * 348f + 393f * Vector3.up;
				CHDINDNHOPN = Quaternion.LookRotation(LOMEHJCJEFF - KFCAECGLKKO.NGPMJNJPNMB);
				KFCAECGLKKO.NGPMJNJPNMB.z = FGMEIEBKNEK.ECMEFIJPCCG(PlayerController.OGMBJPKOPCB).z;
				KFCAECGLKKO.FNMHOPJFDOH = true;
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, KFCAECGLKKO.JGBFNKBFCKM, KFCAECGLKKO.NGPMJNJPNMB, false);
				AJOCDHFNLND.method = UITweener.Method.EaseIn;
				TweenRotation.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, NGAGLEOMOJO, CHDINDNHOPN);
				TweenPosition aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.HHLMDAKDHFK));
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.EHLIEODKCBF, BJGCPDNMHDH.BHANGOBFOHH);
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.EADCGMAPNDC, BJGCPDNMHDH.BJIPJGFPIAJ);
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.AAILDANCKCG, BJGCPDNMHDH.MOMGGEKOBDC);
				goto case 2u;
			}
			case 2u:
			{
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				KFCAECGLKKO.FNMHOPJFDOH = true;
				ONGOEJMKLJC = Vector3.zero;
				JOGMABIDDKB = Quaternion.identity;
				BJGCPDNMHDH.ECPHFACGEIE.OJGFGDELNMI(ref ONGOEJMKLJC, ref JOGMABIDDKB);
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.transform.position, ONGOEJMKLJC, false);
				AJOCDHFNLND.method = UITweener.Method.Linear;
				TweenRotation.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.transform.localRotation, JOGMABIDDKB);
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.PNKCLMJBMNI);
				TweenPosition aJOCDHFNLND2 = AJOCDHFNLND;
				aJOCDHFNLND2.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND2.onFinished, new UITweener.OnFinished(KFCAECGLKKO.JLMDEGBHOGA));
				goto case 3u;
			}
			case 3u:
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Time.timeScale = 292f;
				Singleton<PerformanceManager>.instance.FDFJMPCABLN(true);
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				FGMEIEBKNEK.PCDHJCEAHBD();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0117:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			}
			return true;
		}

		public bool HEHJAEIGHDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = new OMDOIAFEAKI();
				KFCAECGLKKO.AIHDNGDNDHH = this;
				Singleton<PerformanceManager>.instance.KHEDGHEHPLK(true);
				BJGCPDNMHDH.Enable();
				Time.timeScale = 1679f;
				BJGCPDNMHDH.BFOLCPKOJIJ = true;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				BJGCPDNMHDH.CAGAKKADGDG().fieldOfView = 1735f;
				JNGIMHDLPDJ = BJGCPDNMHDH.HAFIMKGAGON();
				BJGCPDNMHDH.DDJADHBHGIO();
				JNGIMHDLPDJ.animationObject = BJGCPDNMHDH.transform;
				JNGIMHDLPDJ.Seek(1959f);
				JNGIMHDLPDJ.Play();
				JNGIMHDLPDJ.AnimationFinishedEvent += BJGCPDNMHDH.OGICJAFFPAL;
				JNGIMHDLPDJ.AnimationCustomEvent += BJGCPDNMHDH.MGKNKCEICMN;
				goto IL_0117;
			case 1u:
			{
				if (BJGCPDNMHDH.BFOLCPKOJIJ)
				{
					goto IL_0117;
				}
				FGMEIEBKNEK.LJMGLMJBFKK();
				KFCAECGLKKO.PNAICLCIHKB = 460f / Time.timeScale;
				KFCAECGLKKO.JGBFNKBFCKM = BJGCPDNMHDH.transform.position;
				KFCAECGLKKO.NGPMJNJPNMB = BJGCPDNMHDH.transform.position + PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform.forward * 313f + Vector3.up * 1079f;
				NGAGLEOMOJO = BJGCPDNMHDH.transform.rotation;
				LOMEHJCJEFF = PlayerController.OGMBJPKOPCB.BBNPGJAALCJ().point.transform.position - PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform.forward * 1096f + 135f * Vector3.up;
				CHDINDNHOPN = Quaternion.LookRotation(LOMEHJCJEFF - KFCAECGLKKO.NGPMJNJPNMB);
				KFCAECGLKKO.NGPMJNJPNMB.z = FGMEIEBKNEK.ECMEFIJPCCG(PlayerController.OGMBJPKOPCB).z;
				KFCAECGLKKO.FNMHOPJFDOH = false;
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, KFCAECGLKKO.JGBFNKBFCKM, KFCAECGLKKO.NGPMJNJPNMB);
				AJOCDHFNLND.method = UITweener.Method.EaseIn;
				TweenRotation.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, NGAGLEOMOJO, CHDINDNHOPN);
				TweenPosition aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.MPHECHCFCAN));
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.EHLIEODKCBF, BJGCPDNMHDH.BHANGOBFOHH);
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.EADCGMAPNDC, BJGCPDNMHDH.BJIPJGFPIAJ);
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.AAILDANCKCG, BJGCPDNMHDH.MOMGGEKOBDC);
				goto case 2u;
			}
			case 2u:
			{
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				KFCAECGLKKO.FNMHOPJFDOH = false;
				ONGOEJMKLJC = Vector3.zero;
				JOGMABIDDKB = Quaternion.identity;
				BJGCPDNMHDH.ECPHFACGEIE.PLAIEKOFODM(ref ONGOEJMKLJC, ref JOGMABIDDKB);
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.transform.position, ONGOEJMKLJC);
				AJOCDHFNLND.method = UITweener.Method.EaseOut;
				TweenRotation.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.transform.localRotation, JOGMABIDDKB);
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.PNKCLMJBMNI);
				TweenPosition aJOCDHFNLND2 = AJOCDHFNLND;
				aJOCDHFNLND2.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND2.onFinished, new UITweener.OnFinished(KFCAECGLKKO.OGFHDPBMCCO));
				goto case 3u;
			}
			case 3u:
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				Time.timeScale = 458f;
				Singleton<PerformanceManager>.instance.SetShadowsDistance(false);
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				FGMEIEBKNEK.PCDHJCEAHBD();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_0117:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			}
			return true;
		}

		[SpecialName]
		private object BNMEIAPPLDP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JLLOKNANOCN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EGJDJENBABP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DFHCLJNONGC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MPHILJJDNIO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GENJNMACGLP()
		{
			return PHDOCKCBJOF;
		}

		public void CCPGGFONBKA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool CCOPPEKLJOB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = new OMDOIAFEAKI();
				KFCAECGLKKO.AIHDNGDNDHH = this;
				Singleton<PerformanceManager>.instance.AOBNCIOGFKA(false);
				BJGCPDNMHDH.HLLODJKPDPK();
				Time.timeScale = 71f;
				BJGCPDNMHDH.BFOLCPKOJIJ = false;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				BJGCPDNMHDH.LBBFBJMLEJB().fieldOfView = 1345f;
				JNGIMHDLPDJ = BJGCPDNMHDH.HAFIMKGAGON();
				BJGCPDNMHDH.POPJOMMBKOF();
				JNGIMHDLPDJ.animationObject = BJGCPDNMHDH.transform;
				JNGIMHDLPDJ.Seek(840f);
				JNGIMHDLPDJ.Play();
				JNGIMHDLPDJ.AnimationFinishedEvent += BJGCPDNMHDH.OGICJAFFPAL;
				JNGIMHDLPDJ.AnimationCustomEvent += BJGCPDNMHDH.GLICCCKMDHE;
				goto IL_0117;
			case 1u:
			{
				if (BJGCPDNMHDH.BFOLCPKOJIJ)
				{
					goto IL_0117;
				}
				FGMEIEBKNEK.LJMGLMJBFKK();
				KFCAECGLKKO.PNAICLCIHKB = 307f / Time.timeScale;
				KFCAECGLKKO.JGBFNKBFCKM = BJGCPDNMHDH.transform.position;
				KFCAECGLKKO.NGPMJNJPNMB = BJGCPDNMHDH.transform.position + PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform.forward * 971f + Vector3.up * 936f;
				NGAGLEOMOJO = BJGCPDNMHDH.transform.rotation;
				LOMEHJCJEFF = PlayerController.OGMBJPKOPCB.EMAMENNDFMB().point.transform.position - PlayerController.OGMBJPKOPCB.EMAMENNDFMB().point.transform.forward * 635f + 1931f * Vector3.up;
				CHDINDNHOPN = Quaternion.LookRotation(LOMEHJCJEFF - KFCAECGLKKO.NGPMJNJPNMB);
				KFCAECGLKKO.NGPMJNJPNMB.z = FGMEIEBKNEK.ECMEFIJPCCG(PlayerController.OGMBJPKOPCB).z;
				KFCAECGLKKO.FNMHOPJFDOH = false;
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, KFCAECGLKKO.JGBFNKBFCKM, KFCAECGLKKO.NGPMJNJPNMB, false);
				AJOCDHFNLND.method = UITweener.Method.EaseIn;
				TweenRotation.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, NGAGLEOMOJO, CHDINDNHOPN);
				TweenPosition aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.CIFEDFPPPOK));
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.EHLIEODKCBF, BJGCPDNMHDH.BHANGOBFOHH);
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.EADCGMAPNDC, BJGCPDNMHDH.BJIPJGFPIAJ);
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.AAILDANCKCG, BJGCPDNMHDH.MOMGGEKOBDC);
				goto case 2u;
			}
			case 2u:
			{
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				KFCAECGLKKO.FNMHOPJFDOH = false;
				ONGOEJMKLJC = Vector3.zero;
				JOGMABIDDKB = Quaternion.identity;
				BJGCPDNMHDH.ECPHFACGEIE.HKKOAONIMPK(ref ONGOEJMKLJC, ref JOGMABIDDKB);
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.transform.position, ONGOEJMKLJC, false);
				AJOCDHFNLND.method = (UITweener.Method)7;
				TweenRotation.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.transform.localRotation, JOGMABIDDKB);
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.PKFIMNPJMPK());
				TweenPosition aJOCDHFNLND2 = AJOCDHFNLND;
				aJOCDHFNLND2.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND2.onFinished, new UITweener.OnFinished(KFCAECGLKKO.OGFHDPBMCCO));
				goto case 3u;
			}
			case 3u:
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				Time.timeScale = 81f;
				Singleton<PerformanceManager>.instance.KHEDGHEHPLK(true);
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				FGMEIEBKNEK.PCDHJCEAHBD();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0117:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			}
			return true;
		}

		public bool GPIPJIDGCKM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				KFCAECGLKKO = new OMDOIAFEAKI();
				KFCAECGLKKO.AIHDNGDNDHH = this;
				Singleton<PerformanceManager>.instance.CLABLOFKMGA(false);
				BJGCPDNMHDH.HLLODJKPDPK();
				Time.timeScale = 1384f;
				BJGCPDNMHDH.BFOLCPKOJIJ = true;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				BJGCPDNMHDH.camera.fieldOfView = 1984f;
				JNGIMHDLPDJ = BJGCPDNMHDH.HAFIMKGAGON();
				BJGCPDNMHDH.POPJOMMBKOF();
				JNGIMHDLPDJ.animationObject = BJGCPDNMHDH.transform;
				JNGIMHDLPDJ.Seek(451f);
				JNGIMHDLPDJ.Play();
				JNGIMHDLPDJ.AnimationFinishedEvent += BJGCPDNMHDH.OGICJAFFPAL;
				JNGIMHDLPDJ.AnimationCustomEvent += BJGCPDNMHDH.MGKNKCEICMN;
				goto IL_0117;
			case 1u:
			{
				if (BJGCPDNMHDH.BFOLCPKOJIJ)
				{
					goto IL_0117;
				}
				FGMEIEBKNEK.LJMGLMJBFKK();
				KFCAECGLKKO.PNAICLCIHKB = 1699f / Time.timeScale;
				KFCAECGLKKO.JGBFNKBFCKM = BJGCPDNMHDH.transform.position;
				KFCAECGLKKO.NGPMJNJPNMB = BJGCPDNMHDH.transform.position + PlayerController.OGMBJPKOPCB.BBNPGJAALCJ().point.transform.forward * 795f + Vector3.up * 1328f;
				NGAGLEOMOJO = BJGCPDNMHDH.transform.rotation;
				LOMEHJCJEFF = PlayerController.OGMBJPKOPCB.EMAMENNDFMB().point.transform.position - PlayerController.OGMBJPKOPCB.CMNFFACHCEE().point.transform.forward * 418f + 1899f * Vector3.up;
				CHDINDNHOPN = Quaternion.LookRotation(LOMEHJCJEFF - KFCAECGLKKO.NGPMJNJPNMB);
				KFCAECGLKKO.NGPMJNJPNMB.z = FGMEIEBKNEK.ECMEFIJPCCG(PlayerController.OGMBJPKOPCB).z;
				KFCAECGLKKO.FNMHOPJFDOH = false;
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, KFCAECGLKKO.JGBFNKBFCKM, KFCAECGLKKO.NGPMJNJPNMB);
				AJOCDHFNLND.method = UITweener.Method.Linear;
				TweenRotation.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, NGAGLEOMOJO, CHDINDNHOPN);
				TweenPosition aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.PCKMJMGLPDG));
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.EHLIEODKCBF, BJGCPDNMHDH.BHANGOBFOHH);
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.EADCGMAPNDC, BJGCPDNMHDH.BJIPJGFPIAJ);
				BJGCPDNMHDH.InvokeAfterRealTime(FGMEIEBKNEK.AAILDANCKCG, BJGCPDNMHDH.MOMGGEKOBDC);
				goto case 2u;
			}
			case 2u:
			{
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				KFCAECGLKKO.FNMHOPJFDOH = true;
				ONGOEJMKLJC = Vector3.zero;
				JOGMABIDDKB = Quaternion.identity;
				BJGCPDNMHDH.ECPHFACGEIE.ADOFEHNMMOC(ref ONGOEJMKLJC, ref JOGMABIDDKB);
				AJOCDHFNLND = TweenPosition.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.transform.position, ONGOEJMKLJC, false);
				AJOCDHFNLND.method = UITweener.Method.EaseInOut;
				TweenRotation.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.transform.localRotation, JOGMABIDDKB);
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, KFCAECGLKKO.PNAICLCIHKB, BJGCPDNMHDH.PKFIMNPJMPK());
				TweenPosition aJOCDHFNLND2 = AJOCDHFNLND;
				aJOCDHFNLND2.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND2.onFinished, new UITweener.OnFinished(KFCAECGLKKO.EJLGBICBIFK));
				goto case 3u;
			}
			case 3u:
				if (!KFCAECGLKKO.FNMHOPJFDOH)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Time.timeScale = 1491f;
				Singleton<PerformanceManager>.instance.MBIALLFNEFO(true);
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				FGMEIEBKNEK.PCDHJCEAHBD();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_0117:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			}
			return false;
		}
	}

	private sealed class ILPLKEMPGIH : IEnumerator, IDisposable, IEnumerator<object>
	{
		private sealed class ADGFNJOKCEJ
		{
			internal bool MOPBHNIHFAC;

			internal Vector3 NNIFEFPIPAN;

			internal Vector3 IFBJNODDLJC;

			internal bool KJLGCGEGMPJ;

			internal ILPLKEMPGIH ALIKEGIJIHD;

			internal void POGLHCIAAGH(UITweener MGDJMGHCAAI)
			{
				MOPBHNIHFAC = true;
				Vector3 toPos = NNIFEFPIPAN + IFBJNODDLJC * 1960f;
				TweenPosition tweenPosition = TweenPosition.Begin(ALIKEGIJIHD.BJGCPDNMHDH.gameObject, 1109f, ALIKEGIJIHD.BJGCPDNMHDH.transform.position, toPos, false);
				tweenPosition.delay = 1469f;
				tweenPosition.method = UITweener.Method.EaseIn;
				tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(KCOGEFBNDKA));
			}

			internal void HOMIPBFODIC(UITweener MGDJMGHCAAI)
			{
				MOPBHNIHFAC = true;
				Vector3 toPos = NNIFEFPIPAN + IFBJNODDLJC * 591f;
				TweenPosition tweenPosition = TweenPosition.Begin(ALIKEGIJIHD.BJGCPDNMHDH.gameObject, 1341f, ALIKEGIJIHD.BJGCPDNMHDH.transform.position, toPos);
				tweenPosition.delay = 363f;
				tweenPosition.method = UITweener.Method.EaseOut;
				tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(JCFDEFFIHAM));
			}

			internal void CJIBPJPJLNB(UITweener MGDJMGHCAAI)
			{
				MOPBHNIHFAC = false;
				Vector3 toPos = NNIFEFPIPAN + IFBJNODDLJC * 1120f;
				TweenPosition tweenPosition = TweenPosition.Begin(ALIKEGIJIHD.BJGCPDNMHDH.gameObject, 674f, ALIKEGIJIHD.BJGCPDNMHDH.transform.position, toPos);
				tweenPosition.delay = 1226f;
				tweenPosition.method = (UITweener.Method)6;
				tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(AFJHEFPPKHG));
			}

			internal void MAKLHLCDIKD(UITweener MGDJMGHCAAI)
			{
				MOPBHNIHFAC = true;
				Vector3 toPos = NNIFEFPIPAN + IFBJNODDLJC * 256f;
				TweenPosition tweenPosition = TweenPosition.Begin(ALIKEGIJIHD.BJGCPDNMHDH.gameObject, 1358f, ALIKEGIJIHD.BJGCPDNMHDH.transform.position, toPos);
				tweenPosition.delay = 977f;
				tweenPosition.method = (UITweener.Method)8;
				tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(DIDKLCKIPGN));
			}

			internal void CLLDAFLGJJJ(UITweener NGADLHBIHGL)
			{
				MOPBHNIHFAC = true;
				KJLGCGEGMPJ = false;
			}

			internal void CENOGMHAJNK(UITweener NGADLHBIHGL)
			{
				MOPBHNIHFAC = true;
				KJLGCGEGMPJ = true;
			}

			internal void IAAHOKHAJHK(UITweener NGADLHBIHGL)
			{
				MOPBHNIHFAC = true;
				KJLGCGEGMPJ = true;
			}

			internal void AOEOEIBLMMF(UITweener NGADLHBIHGL)
			{
				MOPBHNIHFAC = false;
				KJLGCGEGMPJ = true;
			}

			internal void KCOGEFBNDKA(UITweener NGADLHBIHGL)
			{
				MOPBHNIHFAC = true;
				KJLGCGEGMPJ = false;
			}

			internal void FDKEAJLEMCM(UITweener MGDJMGHCAAI)
			{
				MOPBHNIHFAC = false;
				Vector3 toPos = NNIFEFPIPAN + IFBJNODDLJC * 299f;
				TweenPosition tweenPosition = TweenPosition.Begin(ALIKEGIJIHD.BJGCPDNMHDH.gameObject, 1780f, ALIKEGIJIHD.BJGCPDNMHDH.transform.position, toPos);
				tweenPosition.delay = 1654f;
				tweenPosition.method = UITweener.Method.Linear;
				tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(BIKJIFFCHFH));
			}

			internal void EJLGBICBIFK(UITweener NGADLHBIHGL)
			{
				MOPBHNIHFAC = false;
				KJLGCGEGMPJ = true;
			}

			internal void JEDCBCPMJGI(UITweener MGDJMGHCAAI)
			{
				MOPBHNIHFAC = true;
				Vector3 toPos = NNIFEFPIPAN + IFBJNODDLJC * 1012f;
				TweenPosition tweenPosition = TweenPosition.Begin(ALIKEGIJIHD.BJGCPDNMHDH.gameObject, 1025f, ALIKEGIJIHD.BJGCPDNMHDH.transform.position, toPos, false);
				tweenPosition.delay = 1140f;
				tweenPosition.method = (UITweener.Method)8;
				tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(OIDEHFKFFGK));
			}

			internal void FKBGKGFEEIB(UITweener NGADLHBIHGL)
			{
				MOPBHNIHFAC = false;
				KJLGCGEGMPJ = true;
			}

			internal void NDJOJHNIBFC(UITweener MGDJMGHCAAI)
			{
				MOPBHNIHFAC = false;
				Vector3 toPos = NNIFEFPIPAN + IFBJNODDLJC * 702f;
				TweenPosition tweenPosition = TweenPosition.Begin(ALIKEGIJIHD.BJGCPDNMHDH.gameObject, 1094f, ALIKEGIJIHD.BJGCPDNMHDH.transform.position, toPos, false);
				tweenPosition.delay = 978f;
				tweenPosition.method = UITweener.Method.BounceOut;
				tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(PCBLIENKOPE));
			}

			internal void BMCMDMKGHHO(UITweener MGDJMGHCAAI)
			{
				MOPBHNIHFAC = true;
				Vector3 toPos = NNIFEFPIPAN + IFBJNODDLJC * 1692f;
				TweenPosition tweenPosition = TweenPosition.Begin(ALIKEGIJIHD.BJGCPDNMHDH.gameObject, 1112f, ALIKEGIJIHD.BJGCPDNMHDH.transform.position, toPos);
				tweenPosition.delay = 1811f;
				tweenPosition.method = (UITweener.Method)7;
				tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(PEOKGFIGIGH));
			}

			internal void PANKBNOCEAM(UITweener MGDJMGHCAAI)
			{
				MOPBHNIHFAC = true;
				Vector3 toPos = NNIFEFPIPAN + IFBJNODDLJC * 1613f;
				TweenPosition tweenPosition = TweenPosition.Begin(ALIKEGIJIHD.BJGCPDNMHDH.gameObject, 150f, ALIKEGIJIHD.BJGCPDNMHDH.transform.position, toPos);
				tweenPosition.delay = 147f;
				tweenPosition.method = (UITweener.Method)7;
				tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(JCFDEFFIHAM));
			}

			internal void POGDLLFCOKO(UITweener MGDJMGHCAAI)
			{
				MOPBHNIHFAC = true;
				Vector3 toPos = NNIFEFPIPAN + IFBJNODDLJC * 1800f;
				TweenPosition tweenPosition = TweenPosition.Begin(ALIKEGIJIHD.BJGCPDNMHDH.gameObject, 177f, ALIKEGIJIHD.BJGCPDNMHDH.transform.position, toPos, false);
				tweenPosition.delay = 1831f;
				tweenPosition.method = UITweener.Method.EaseOut;
				tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(FCFDKEHICIB));
			}

			internal void PEOKGFIGIGH(UITweener NGADLHBIHGL)
			{
				MOPBHNIHFAC = false;
				KJLGCGEGMPJ = true;
			}

			internal void JHPEFFLPHCF(UITweener NGADLHBIHGL)
			{
				MOPBHNIHFAC = true;
				KJLGCGEGMPJ = false;
			}

			internal void DIDKLCKIPGN(UITweener NGADLHBIHGL)
			{
				MOPBHNIHFAC = false;
				KJLGCGEGMPJ = true;
			}

			internal void PKCBGEEBOMA(UITweener NGADLHBIHGL)
			{
				MOPBHNIHFAC = false;
				KJLGCGEGMPJ = true;
			}

			internal void LEDJMCDANFJ(UITweener NGADLHBIHGL)
			{
				MOPBHNIHFAC = true;
				KJLGCGEGMPJ = true;
			}

			internal void LJCDGJKCNEC(UITweener MGDJMGHCAAI)
			{
				MOPBHNIHFAC = true;
				Vector3 toPos = NNIFEFPIPAN + IFBJNODDLJC * 5f;
				TweenPosition tweenPosition = TweenPosition.Begin(ALIKEGIJIHD.BJGCPDNMHDH.gameObject, 15f, ALIKEGIJIHD.BJGCPDNMHDH.transform.position, toPos, false);
				tweenPosition.delay = 0f;
				tweenPosition.method = UITweener.Method.EaseOut;
				tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(EJLGBICBIFK));
			}

			internal void AGFEDJAKLAC(UITweener MGDJMGHCAAI)
			{
				MOPBHNIHFAC = true;
				Vector3 toPos = NNIFEFPIPAN + IFBJNODDLJC * 1384f;
				TweenPosition tweenPosition = TweenPosition.Begin(ALIKEGIJIHD.BJGCPDNMHDH.gameObject, 808f, ALIKEGIJIHD.BJGCPDNMHDH.transform.position, toPos, false);
				tweenPosition.delay = 438f;
				tweenPosition.method = UITweener.Method.Linear;
				tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(AFJHEFPPKHG));
			}

			internal void AFJHEFPPKHG(UITweener NGADLHBIHGL)
			{
				MOPBHNIHFAC = false;
				KJLGCGEGMPJ = true;
			}

			internal void KPHEPHDFCKK(UITweener MGDJMGHCAAI)
			{
				MOPBHNIHFAC = false;
				Vector3 toPos = NNIFEFPIPAN + IFBJNODDLJC * 1991f;
				TweenPosition tweenPosition = TweenPosition.Begin(ALIKEGIJIHD.BJGCPDNMHDH.gameObject, 1446f, ALIKEGIJIHD.BJGCPDNMHDH.transform.position, toPos, false);
				tweenPosition.delay = 187f;
				tweenPosition.method = UITweener.Method.Linear;
				tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(PKCBGEEBOMA));
			}

			internal void LMOFHDINPEI(UITweener NGADLHBIHGL)
			{
				MOPBHNIHFAC = false;
				KJLGCGEGMPJ = true;
			}

			internal void KIACGAKNBLD(UITweener MGDJMGHCAAI)
			{
				MOPBHNIHFAC = true;
				Vector3 toPos = NNIFEFPIPAN + IFBJNODDLJC * 1194f;
				TweenPosition tweenPosition = TweenPosition.Begin(ALIKEGIJIHD.BJGCPDNMHDH.gameObject, 830f, ALIKEGIJIHD.BJGCPDNMHDH.transform.position, toPos, false);
				tweenPosition.delay = 353f;
				tweenPosition.method = (UITweener.Method)8;
				tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(DIDKLCKIPGN));
			}

			internal void GANNNCEMLPI(UITweener NGADLHBIHGL)
			{
				MOPBHNIHFAC = true;
				KJLGCGEGMPJ = true;
			}

			internal void IDEPAHOBFCP(UITweener NGADLHBIHGL)
			{
				MOPBHNIHFAC = true;
				KJLGCGEGMPJ = true;
			}

			internal void PCBLIENKOPE(UITweener NGADLHBIHGL)
			{
				MOPBHNIHFAC = false;
				KJLGCGEGMPJ = true;
			}

			internal void MFCNOIDCJME(UITweener MGDJMGHCAAI)
			{
				MOPBHNIHFAC = false;
				Vector3 toPos = NNIFEFPIPAN + IFBJNODDLJC * 572f;
				TweenPosition tweenPosition = TweenPosition.Begin(ALIKEGIJIHD.BJGCPDNMHDH.gameObject, 1314f, ALIKEGIJIHD.BJGCPDNMHDH.transform.position, toPos);
				tweenPosition.delay = 125f;
				tweenPosition.method = UITweener.Method.EaseInOut;
				tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(JHPEFFLPHCF));
			}

			internal void GGJDILDIFPJ(UITweener MGDJMGHCAAI)
			{
				MOPBHNIHFAC = false;
				Vector3 toPos = NNIFEFPIPAN + IFBJNODDLJC * 488f;
				TweenPosition tweenPosition = TweenPosition.Begin(ALIKEGIJIHD.BJGCPDNMHDH.gameObject, 1009f, ALIKEGIJIHD.BJGCPDNMHDH.transform.position, toPos);
				tweenPosition.delay = 975f;
				tweenPosition.method = (UITweener.Method)8;
				tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(KCOGEFBNDKA));
			}

			internal void EOHOLKEGGLH(UITweener MGDJMGHCAAI)
			{
				MOPBHNIHFAC = true;
				Vector3 toPos = NNIFEFPIPAN + IFBJNODDLJC * 1181f;
				TweenPosition tweenPosition = TweenPosition.Begin(ALIKEGIJIHD.BJGCPDNMHDH.gameObject, 74f, ALIKEGIJIHD.BJGCPDNMHDH.transform.position, toPos);
				tweenPosition.delay = 990f;
				tweenPosition.method = UITweener.Method.Linear;
				tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(CFGDGGBELGD));
			}

			internal void FCFDKEHICIB(UITweener NGADLHBIHGL)
			{
				MOPBHNIHFAC = true;
				KJLGCGEGMPJ = true;
			}

			internal void CFGDGGBELGD(UITweener NGADLHBIHGL)
			{
				MOPBHNIHFAC = false;
				KJLGCGEGMPJ = false;
			}

			internal void JCFDEFFIHAM(UITweener NGADLHBIHGL)
			{
				MOPBHNIHFAC = false;
				KJLGCGEGMPJ = false;
			}

			internal void EIHHMNDHDHL(UITweener NGADLHBIHGL)
			{
				MOPBHNIHFAC = false;
				KJLGCGEGMPJ = false;
			}

			internal void LGJCNCHBFDA(UITweener MGDJMGHCAAI)
			{
				MOPBHNIHFAC = false;
				Vector3 toPos = NNIFEFPIPAN + IFBJNODDLJC * 845f;
				TweenPosition tweenPosition = TweenPosition.Begin(ALIKEGIJIHD.BJGCPDNMHDH.gameObject, 855f, ALIKEGIJIHD.BJGCPDNMHDH.transform.position, toPos);
				tweenPosition.delay = 1674f;
				tweenPosition.method = (UITweener.Method)8;
				tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(JHPEFFLPHCF));
			}

			internal void OFJDLANHAMD(UITweener MGDJMGHCAAI)
			{
				MOPBHNIHFAC = true;
				Vector3 toPos = NNIFEFPIPAN + IFBJNODDLJC * 1119f;
				TweenPosition tweenPosition = TweenPosition.Begin(ALIKEGIJIHD.BJGCPDNMHDH.gameObject, 1104f, ALIKEGIJIHD.BJGCPDNMHDH.transform.position, toPos, false);
				tweenPosition.delay = 1829f;
				tweenPosition.method = (UITweener.Method)8;
				tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(GANNNCEMLPI));
			}

			internal void OIDEHFKFFGK(UITweener NGADLHBIHGL)
			{
				MOPBHNIHFAC = false;
				KJLGCGEGMPJ = true;
			}

			internal void LHPPLGOOLEC(UITweener MGDJMGHCAAI)
			{
				MOPBHNIHFAC = false;
				Vector3 toPos = NNIFEFPIPAN + IFBJNODDLJC * 61f;
				TweenPosition tweenPosition = TweenPosition.Begin(ALIKEGIJIHD.BJGCPDNMHDH.gameObject, 683f, ALIKEGIJIHD.BJGCPDNMHDH.transform.position, toPos);
				tweenPosition.delay = 855f;
				tweenPosition.method = (UITweener.Method)7;
				tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(CFGDGGBELGD));
			}

			internal void BIKJIFFCHFH(UITweener NGADLHBIHGL)
			{
				MOPBHNIHFAC = true;
				KJLGCGEGMPJ = true;
			}

			internal void ALFPMCHHIMH(UITweener NGADLHBIHGL)
			{
				MOPBHNIHFAC = true;
				KJLGCGEGMPJ = false;
			}

			internal void NAJNECOMDDN(UITweener MGDJMGHCAAI)
			{
				MOPBHNIHFAC = true;
				Vector3 toPos = NNIFEFPIPAN + IFBJNODDLJC * 1191f;
				TweenPosition tweenPosition = TweenPosition.Begin(ALIKEGIJIHD.BJGCPDNMHDH.gameObject, 1926f, ALIKEGIJIHD.BJGCPDNMHDH.transform.position, toPos, false);
				tweenPosition.delay = 1058f;
				tweenPosition.method = UITweener.Method.BounceIn;
				tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(JHPEFFLPHCF));
			}

			internal void ECPMEMNKMCB(UITweener MGDJMGHCAAI)
			{
				MOPBHNIHFAC = true;
				Vector3 toPos = NNIFEFPIPAN + IFBJNODDLJC * 1964f;
				TweenPosition tweenPosition = TweenPosition.Begin(ALIKEGIJIHD.BJGCPDNMHDH.gameObject, 536f, ALIKEGIJIHD.BJGCPDNMHDH.transform.position, toPos);
				tweenPosition.delay = 1705f;
				tweenPosition.method = (UITweener.Method)8;
				tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(DIDKLCKIPGN));
			}

			internal void CIFEDFPPPOK(UITweener MGDJMGHCAAI)
			{
				MOPBHNIHFAC = false;
				Vector3 toPos = NNIFEFPIPAN + IFBJNODDLJC * 701f;
				TweenPosition tweenPosition = TweenPosition.Begin(ALIKEGIJIHD.BJGCPDNMHDH.gameObject, 1389f, ALIKEGIJIHD.BJGCPDNMHDH.transform.position, toPos);
				tweenPosition.delay = 1436f;
				tweenPosition.method = (UITweener.Method)7;
				tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(PKCBGEEBOMA));
			}

			internal void FIBGJHCGHJH(UITweener MGDJMGHCAAI)
			{
				MOPBHNIHFAC = false;
				Vector3 toPos = NNIFEFPIPAN + IFBJNODDLJC * 142f;
				TweenPosition tweenPosition = TweenPosition.Begin(ALIKEGIJIHD.BJGCPDNMHDH.gameObject, 1312f, ALIKEGIJIHD.BJGCPDNMHDH.transform.position, toPos, false);
				tweenPosition.delay = 966f;
				tweenPosition.method = (UITweener.Method)8;
				tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(LMOFHDINPEI));
			}

			internal void KILJJNKMNHO(UITweener NGADLHBIHGL)
			{
				MOPBHNIHFAC = true;
				KJLGCGEGMPJ = true;
			}
		}

		internal float OAGNKGDKODI;

		internal PlayerController KHLGDCHJJPB;

		internal Vector3 PJKJEGDNCOM;

		internal TweenRotation AJOCDHFNLND;

		internal GameCamera BJGCPDNMHDH;

		internal object PHDOCKCBJOF;

		internal bool FDKOKMKIIMG;

		internal int CLPPIAGLCJJ;

		private ADGFNJOKCEJ KFCAECGLKKO;

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

		public void OFDJMNMCDLA()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object PLHNILIJAPA()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public ILPLKEMPGIH()
		{
		}

		public bool PMBOHHPPJAC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				KFCAECGLKKO = new ADGFNJOKCEJ();
				KFCAECGLKKO.ALIKEGIJIHD = this;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				OAGNKGDKODI = 1578f;
				KFCAECGLKKO.MOPBHNIHFAC = true;
				KFCAECGLKKO.KJLGCGEGMPJ = false;
				KFCAECGLKKO.NNIFEFPIPAN = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position - KHLGDCHJJPB.transform.forward * 600f + KHLGDCHJJPB.transform.right * 365f + Vector3.up * 579f;
				PJKJEGDNCOM = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position;
				KFCAECGLKKO.IFBJNODDLJC = (KFCAECGLKKO.NNIFEFPIPAN - BJGCPDNMHDH.transform.position).normalized;
				TimeManager.instance.DCEJMAFHNKI();
				BJGCPDNMHDH.AEEFNAGJNMN = BJGCPDNMHDH.transform.rotation;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, 363f);
				AJOCDHFNLND = TweenRotation.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, Quaternion.LookRotation(PJKJEGDNCOM - KFCAECGLKKO.NNIFEFPIPAN));
				AJOCDHFNLND.delay = 419f;
				AJOCDHFNLND.method = UITweener.Method.EaseIn;
				TweenPosition.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, BJGCPDNMHDH.transform.position, KFCAECGLKKO.NNIFEFPIPAN, false).delay = 767f;
				TweenRotation aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.EOHOLKEGGLH));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.KJLGCGEGMPJ)
				{
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.HNGMFABKLKF);
					if (KFCAECGLKKO.MOPBHNIHFAC)
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position - BJGCPDNMHDH.transform.position);
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

		public void MKMMKLOPKPD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IJFPHIKFJFB()
		{
			return PHDOCKCBJOF;
		}

		public void LFOLGBNBBAG()
		{
			throw new NotSupportedException();
		}

		public void NPIDJAPKFLN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MKNFFJPADIA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HHHLDCLIFKJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KLAPICIGNJB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ADIAKJMNIEB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IBCJOBKGEEG()
		{
			return PHDOCKCBJOF;
		}

		public void MEBPMHDHIPJ()
		{
			throw new NotSupportedException();
		}

		public void PHEIGPKKPGE()
		{
			throw new NotSupportedException();
		}

		public void MFFEEKOGCCE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void LOOMFHNKAND()
		{
			throw new NotSupportedException();
		}

		public bool CCOPPEKLJOB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				KFCAECGLKKO = new ADGFNJOKCEJ();
				KFCAECGLKKO.ALIKEGIJIHD = this;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				OAGNKGDKODI = 290f;
				KFCAECGLKKO.MOPBHNIHFAC = false;
				KFCAECGLKKO.KJLGCGEGMPJ = true;
				KFCAECGLKKO.NNIFEFPIPAN = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position - KHLGDCHJJPB.transform.forward * 1851f + KHLGDCHJJPB.transform.right * 408f + Vector3.up * 178f;
				PJKJEGDNCOM = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position;
				KFCAECGLKKO.IFBJNODDLJC = (KFCAECGLKKO.NNIFEFPIPAN - BJGCPDNMHDH.transform.position).normalized;
				TimeManager.instance.EndGame();
				BJGCPDNMHDH.AEEFNAGJNMN = BJGCPDNMHDH.transform.rotation;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, 614f);
				AJOCDHFNLND = TweenRotation.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, Quaternion.LookRotation(PJKJEGDNCOM - KFCAECGLKKO.NNIFEFPIPAN), true);
				AJOCDHFNLND.delay = 388f;
				AJOCDHFNLND.method = UITweener.Method.EaseIn;
				TweenPosition.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, BJGCPDNMHDH.transform.position, KFCAECGLKKO.NNIFEFPIPAN).delay = 1513f;
				TweenRotation aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.ECPMEMNKMCB));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.KJLGCGEGMPJ)
				{
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.HNGMFABKLKF);
					if (KFCAECGLKKO.MOPBHNIHFAC)
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position - BJGCPDNMHDH.transform.position);
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

		public void JDFJKNFDDGN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void LJPIDOKGNBF()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void MPLPDIGFPBH()
		{
			throw new NotSupportedException();
		}

		public void MPKODAJAPFD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void KIPDKEKMDFE()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void GHODNCIDCMG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void MKIKEOOOLKL()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object ENKCCCABFFB()
		{
			return PHDOCKCBJOF;
		}

		public void EKPOLGNAAOI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void AKEKFBGEJBG()
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
			{
				KFCAECGLKKO = new ADGFNJOKCEJ();
				KFCAECGLKKO.ALIKEGIJIHD = this;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				OAGNKGDKODI = 1879f;
				KFCAECGLKKO.MOPBHNIHFAC = true;
				KFCAECGLKKO.KJLGCGEGMPJ = true;
				KFCAECGLKKO.NNIFEFPIPAN = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position - KHLGDCHJJPB.transform.forward * 1229f + KHLGDCHJJPB.transform.right * 1972f + Vector3.up * 823f;
				PJKJEGDNCOM = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position;
				KFCAECGLKKO.IFBJNODDLJC = (KFCAECGLKKO.NNIFEFPIPAN - BJGCPDNMHDH.transform.position).normalized;
				TimeManager.instance.KIKGGBHKOAK();
				BJGCPDNMHDH.AEEFNAGJNMN = BJGCPDNMHDH.transform.rotation;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, 1861f);
				AJOCDHFNLND = TweenRotation.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, Quaternion.LookRotation(PJKJEGDNCOM - KFCAECGLKKO.NNIFEFPIPAN), true);
				AJOCDHFNLND.delay = 1533f;
				AJOCDHFNLND.method = UITweener.Method.Linear;
				TweenPosition.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, BJGCPDNMHDH.transform.position, KFCAECGLKKO.NNIFEFPIPAN).delay = 500f;
				TweenRotation aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.MAKLHLCDIKD));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.KJLGCGEGMPJ)
				{
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.HNGMFABKLKF);
					if (KFCAECGLKKO.MOPBHNIHFAC)
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position - BJGCPDNMHDH.transform.position);
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

		public void EFKBIIPFDOM()
		{
			throw new NotSupportedException();
		}

		public void KNFDDIHLBKJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object OJMKDIBHMND()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void KGLHLHLLOEM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object IPCODJDAOBE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IIJAMNPBACH()
		{
			return PHDOCKCBJOF;
		}

		public void LDBAMIKAGHC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BLOJDIFOPIA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FFJBOMJMIAE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HBKJOBOMGKB()
		{
			return PHDOCKCBJOF;
		}

		public bool CCDJGNJGPDM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				KFCAECGLKKO = new ADGFNJOKCEJ();
				KFCAECGLKKO.ALIKEGIJIHD = this;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				OAGNKGDKODI = 518f;
				KFCAECGLKKO.MOPBHNIHFAC = true;
				KFCAECGLKKO.KJLGCGEGMPJ = false;
				KFCAECGLKKO.NNIFEFPIPAN = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position - KHLGDCHJJPB.transform.forward * 282f + KHLGDCHJJPB.transform.right * 1836f + Vector3.up * 596f;
				PJKJEGDNCOM = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position;
				KFCAECGLKKO.IFBJNODDLJC = (KFCAECGLKKO.NNIFEFPIPAN - BJGCPDNMHDH.transform.position).normalized;
				TimeManager.instance.KIKGGBHKOAK();
				BJGCPDNMHDH.AEEFNAGJNMN = BJGCPDNMHDH.transform.rotation;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, 245f);
				AJOCDHFNLND = TweenRotation.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, Quaternion.LookRotation(PJKJEGDNCOM - KFCAECGLKKO.NNIFEFPIPAN));
				AJOCDHFNLND.delay = 1445f;
				AJOCDHFNLND.method = UITweener.Method.Linear;
				TweenPosition.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, BJGCPDNMHDH.transform.position, KFCAECGLKKO.NNIFEFPIPAN, false).delay = 594f;
				TweenRotation aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.MFCNOIDCJME));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.KJLGCGEGMPJ)
				{
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.HNGMFABKLKF);
					if (KFCAECGLKKO.MOPBHNIHFAC)
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position - BJGCPDNMHDH.transform.position);
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

		[SpecialName]
		private object KJMPNHLOKJL()
		{
			return PHDOCKCBJOF;
		}

		public void MOJGMBNBGHH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BEGHOADNMJF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LPMKMBAOMFP()
		{
			return PHDOCKCBJOF;
		}

		public void OGDMPCFMMML()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BNFADGLHBAH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GDCFFBBNGHH()
		{
			return PHDOCKCBJOF;
		}

		public void OJDEHKDDLFD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object LHMPDOBMOLD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LMLPPCCDELM()
		{
			return PHDOCKCBJOF;
		}

		public bool BANDNPPLIJA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				KFCAECGLKKO = new ADGFNJOKCEJ();
				KFCAECGLKKO.ALIKEGIJIHD = this;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				OAGNKGDKODI = 802f;
				KFCAECGLKKO.MOPBHNIHFAC = true;
				KFCAECGLKKO.KJLGCGEGMPJ = true;
				KFCAECGLKKO.NNIFEFPIPAN = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position - KHLGDCHJJPB.transform.forward * 1225f + KHLGDCHJJPB.transform.right * 723f + Vector3.up * 1051f;
				PJKJEGDNCOM = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position;
				KFCAECGLKKO.IFBJNODDLJC = (KFCAECGLKKO.NNIFEFPIPAN - BJGCPDNMHDH.transform.position).normalized;
				TimeManager.instance.EndGame();
				BJGCPDNMHDH.AEEFNAGJNMN = BJGCPDNMHDH.transform.rotation;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, 107f);
				AJOCDHFNLND = TweenRotation.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, Quaternion.LookRotation(PJKJEGDNCOM - KFCAECGLKKO.NNIFEFPIPAN), true);
				AJOCDHFNLND.delay = 369f;
				AJOCDHFNLND.method = UITweener.Method.EaseIn;
				TweenPosition.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, BJGCPDNMHDH.transform.position, KFCAECGLKKO.NNIFEFPIPAN).delay = 1176f;
				TweenRotation aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.OFJDLANHAMD));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.KJLGCGEGMPJ)
				{
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.HNGMFABKLKF);
					if (KFCAECGLKKO.MOPBHNIHFAC)
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position - BJGCPDNMHDH.transform.position);
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

		public void GFJIKANGNMC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void KINGACOICNF()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void EPKPNKGJHEC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool MKCOLOBIAAP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				KFCAECGLKKO = new ADGFNJOKCEJ();
				KFCAECGLKKO.ALIKEGIJIHD = this;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				OAGNKGDKODI = 556f;
				KFCAECGLKKO.MOPBHNIHFAC = true;
				KFCAECGLKKO.KJLGCGEGMPJ = true;
				KFCAECGLKKO.NNIFEFPIPAN = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position - KHLGDCHJJPB.transform.forward * 742f + KHLGDCHJJPB.transform.right * 149f + Vector3.up * 1873f;
				PJKJEGDNCOM = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position;
				KFCAECGLKKO.IFBJNODDLJC = (KFCAECGLKKO.NNIFEFPIPAN - BJGCPDNMHDH.transform.position).normalized;
				TimeManager.instance.KIKGGBHKOAK();
				BJGCPDNMHDH.AEEFNAGJNMN = BJGCPDNMHDH.transform.rotation;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, 953f);
				AJOCDHFNLND = TweenRotation.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, Quaternion.LookRotation(PJKJEGDNCOM - KFCAECGLKKO.NNIFEFPIPAN), true);
				AJOCDHFNLND.delay = 1021f;
				AJOCDHFNLND.method = UITweener.Method.Linear;
				TweenPosition.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, BJGCPDNMHDH.transform.position, KFCAECGLKKO.NNIFEFPIPAN, false).delay = 518f;
				TweenRotation aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.OFJDLANHAMD));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.KJLGCGEGMPJ)
				{
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.HNGMFABKLKF);
					if (KFCAECGLKKO.MOPBHNIHFAC)
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position - BJGCPDNMHDH.transform.position);
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

		public bool IIJKAMFGNKA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				KFCAECGLKKO = new ADGFNJOKCEJ();
				KFCAECGLKKO.ALIKEGIJIHD = this;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				OAGNKGDKODI = 1870f;
				KFCAECGLKKO.MOPBHNIHFAC = true;
				KFCAECGLKKO.KJLGCGEGMPJ = false;
				KFCAECGLKKO.NNIFEFPIPAN = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position - KHLGDCHJJPB.transform.forward * 1549f + KHLGDCHJJPB.transform.right * 745f + Vector3.up * 1322f;
				PJKJEGDNCOM = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position;
				KFCAECGLKKO.IFBJNODDLJC = (KFCAECGLKKO.NNIFEFPIPAN - BJGCPDNMHDH.transform.position).normalized;
				TimeManager.instance.DCEJMAFHNKI();
				BJGCPDNMHDH.AEEFNAGJNMN = BJGCPDNMHDH.transform.rotation;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, 1525f);
				AJOCDHFNLND = TweenRotation.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, Quaternion.LookRotation(PJKJEGDNCOM - KFCAECGLKKO.NNIFEFPIPAN), true);
				AJOCDHFNLND.delay = 625f;
				AJOCDHFNLND.method = UITweener.Method.Linear;
				TweenPosition.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, BJGCPDNMHDH.transform.position, KFCAECGLKKO.NNIFEFPIPAN).delay = 1751f;
				TweenRotation aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.JEDCBCPMJGI));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.KJLGCGEGMPJ)
				{
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.HNGMFABKLKF);
					if (KFCAECGLKKO.MOPBHNIHFAC)
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position - BJGCPDNMHDH.transform.position);
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
		private object FGFLGJECNLH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FJGIOPMDPGA()
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
			{
				KFCAECGLKKO = new ADGFNJOKCEJ();
				KFCAECGLKKO.ALIKEGIJIHD = this;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				OAGNKGDKODI = 56f;
				KFCAECGLKKO.MOPBHNIHFAC = false;
				KFCAECGLKKO.KJLGCGEGMPJ = true;
				KFCAECGLKKO.NNIFEFPIPAN = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position - KHLGDCHJJPB.transform.forward * 1747f + KHLGDCHJJPB.transform.right * 139f + Vector3.up * 284f;
				PJKJEGDNCOM = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position;
				KFCAECGLKKO.IFBJNODDLJC = (KFCAECGLKKO.NNIFEFPIPAN - BJGCPDNMHDH.transform.position).normalized;
				TimeManager.instance.EndGame();
				BJGCPDNMHDH.AEEFNAGJNMN = BJGCPDNMHDH.transform.rotation;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, 1016f);
				AJOCDHFNLND = TweenRotation.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, Quaternion.LookRotation(PJKJEGDNCOM - KFCAECGLKKO.NNIFEFPIPAN));
				AJOCDHFNLND.delay = 721f;
				AJOCDHFNLND.method = UITweener.Method.Linear;
				TweenPosition.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, BJGCPDNMHDH.transform.position, KFCAECGLKKO.NNIFEFPIPAN).delay = 807f;
				TweenRotation aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.JEDCBCPMJGI));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.KJLGCGEGMPJ)
				{
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.HNGMFABKLKF);
					if (KFCAECGLKKO.MOPBHNIHFAC)
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position - BJGCPDNMHDH.transform.position);
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

		[SpecialName]
		private object MDHGGDNNOAK()
		{
			return PHDOCKCBJOF;
		}

		public void JMANMKKCDMM()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CEFJKELIBGG()
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
			{
				KFCAECGLKKO = new ADGFNJOKCEJ();
				KFCAECGLKKO.ALIKEGIJIHD = this;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				OAGNKGDKODI = 602f;
				KFCAECGLKKO.MOPBHNIHFAC = true;
				KFCAECGLKKO.KJLGCGEGMPJ = true;
				KFCAECGLKKO.NNIFEFPIPAN = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position - KHLGDCHJJPB.transform.forward * 889f + KHLGDCHJJPB.transform.right * 811f + Vector3.up * 938f;
				PJKJEGDNCOM = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position;
				KFCAECGLKKO.IFBJNODDLJC = (KFCAECGLKKO.NNIFEFPIPAN - BJGCPDNMHDH.transform.position).normalized;
				TimeManager.instance.EndGame();
				BJGCPDNMHDH.AEEFNAGJNMN = BJGCPDNMHDH.transform.rotation;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, 1369f);
				AJOCDHFNLND = TweenRotation.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, Quaternion.LookRotation(PJKJEGDNCOM - KFCAECGLKKO.NNIFEFPIPAN), true);
				AJOCDHFNLND.delay = 1063f;
				AJOCDHFNLND.method = UITweener.Method.EaseIn;
				TweenPosition.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, BJGCPDNMHDH.transform.position, KFCAECGLKKO.NNIFEFPIPAN).delay = 818f;
				TweenRotation aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.POGDLLFCOKO));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.KJLGCGEGMPJ)
				{
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.HNGMFABKLKF);
					if (KFCAECGLKKO.MOPBHNIHFAC)
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position - BJGCPDNMHDH.transform.position);
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

		public bool AGMKAADLHLE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				KFCAECGLKKO = new ADGFNJOKCEJ();
				KFCAECGLKKO.ALIKEGIJIHD = this;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				OAGNKGDKODI = 761f;
				KFCAECGLKKO.MOPBHNIHFAC = true;
				KFCAECGLKKO.KJLGCGEGMPJ = false;
				KFCAECGLKKO.NNIFEFPIPAN = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position - KHLGDCHJJPB.transform.forward * 1658f + KHLGDCHJJPB.transform.right * 1018f + Vector3.up * 1815f;
				PJKJEGDNCOM = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position;
				KFCAECGLKKO.IFBJNODDLJC = (KFCAECGLKKO.NNIFEFPIPAN - BJGCPDNMHDH.transform.position).normalized;
				TimeManager.instance.DCEJMAFHNKI();
				BJGCPDNMHDH.AEEFNAGJNMN = BJGCPDNMHDH.transform.rotation;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, 461f);
				AJOCDHFNLND = TweenRotation.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, Quaternion.LookRotation(PJKJEGDNCOM - KFCAECGLKKO.NNIFEFPIPAN));
				AJOCDHFNLND.delay = 588f;
				AJOCDHFNLND.method = UITweener.Method.EaseIn;
				TweenPosition.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, BJGCPDNMHDH.transform.position, KFCAECGLKKO.NNIFEFPIPAN).delay = 1920f;
				TweenRotation aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.CIFEDFPPPOK));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.KJLGCGEGMPJ)
				{
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.HNGMFABKLKF);
					if (KFCAECGLKKO.MOPBHNIHFAC)
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position - BJGCPDNMHDH.transform.position);
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

		public bool KIFNNJFJJCG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				KFCAECGLKKO = new ADGFNJOKCEJ();
				KFCAECGLKKO.ALIKEGIJIHD = this;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				OAGNKGDKODI = 1378f;
				KFCAECGLKKO.MOPBHNIHFAC = true;
				KFCAECGLKKO.KJLGCGEGMPJ = false;
				KFCAECGLKKO.NNIFEFPIPAN = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position - KHLGDCHJJPB.transform.forward * 1067f + KHLGDCHJJPB.transform.right * 1963f + Vector3.up * 467f;
				PJKJEGDNCOM = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position;
				KFCAECGLKKO.IFBJNODDLJC = (KFCAECGLKKO.NNIFEFPIPAN - BJGCPDNMHDH.transform.position).normalized;
				TimeManager.instance.KIKGGBHKOAK();
				BJGCPDNMHDH.AEEFNAGJNMN = BJGCPDNMHDH.transform.rotation;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, 1059f);
				AJOCDHFNLND = TweenRotation.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, Quaternion.LookRotation(PJKJEGDNCOM - KFCAECGLKKO.NNIFEFPIPAN));
				AJOCDHFNLND.delay = 1291f;
				AJOCDHFNLND.method = UITweener.Method.Linear;
				TweenPosition.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, BJGCPDNMHDH.transform.position, KFCAECGLKKO.NNIFEFPIPAN, false).delay = 1316f;
				TweenRotation aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.NDJOJHNIBFC));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.KJLGCGEGMPJ)
				{
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.HNGMFABKLKF);
					if (KFCAECGLKKO.MOPBHNIHFAC)
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position - BJGCPDNMHDH.transform.position);
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
		private object FLJNAIIJAFO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CIGHIOCACPH()
		{
			return PHDOCKCBJOF;
		}

		public bool ANIKAJEKMPM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				KFCAECGLKKO = new ADGFNJOKCEJ();
				KFCAECGLKKO.ALIKEGIJIHD = this;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				OAGNKGDKODI = 1886f;
				KFCAECGLKKO.MOPBHNIHFAC = true;
				KFCAECGLKKO.KJLGCGEGMPJ = false;
				KFCAECGLKKO.NNIFEFPIPAN = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position - KHLGDCHJJPB.transform.forward * 411f + KHLGDCHJJPB.transform.right * 897f + Vector3.up * 713f;
				PJKJEGDNCOM = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position;
				KFCAECGLKKO.IFBJNODDLJC = (KFCAECGLKKO.NNIFEFPIPAN - BJGCPDNMHDH.transform.position).normalized;
				TimeManager.instance.DCEJMAFHNKI();
				BJGCPDNMHDH.AEEFNAGJNMN = BJGCPDNMHDH.transform.rotation;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, 370f);
				AJOCDHFNLND = TweenRotation.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, Quaternion.LookRotation(PJKJEGDNCOM - KFCAECGLKKO.NNIFEFPIPAN), true);
				AJOCDHFNLND.delay = 1157f;
				AJOCDHFNLND.method = UITweener.Method.Linear;
				TweenPosition.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, BJGCPDNMHDH.transform.position, KFCAECGLKKO.NNIFEFPIPAN, false).delay = 1418f;
				TweenRotation aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.EOHOLKEGGLH));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.KJLGCGEGMPJ)
				{
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.HNGMFABKLKF);
					if (KFCAECGLKKO.MOPBHNIHFAC)
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position - BJGCPDNMHDH.transform.position);
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

		[SpecialName]
		private object HJFIBBBPDKK()
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
			{
				KFCAECGLKKO = new ADGFNJOKCEJ();
				KFCAECGLKKO.ALIKEGIJIHD = this;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				OAGNKGDKODI = 1081f;
				KFCAECGLKKO.MOPBHNIHFAC = false;
				KFCAECGLKKO.KJLGCGEGMPJ = false;
				KFCAECGLKKO.NNIFEFPIPAN = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position - KHLGDCHJJPB.transform.forward * 1189f + KHLGDCHJJPB.transform.right * 846f + Vector3.up * 825f;
				PJKJEGDNCOM = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position;
				KFCAECGLKKO.IFBJNODDLJC = (KFCAECGLKKO.NNIFEFPIPAN - BJGCPDNMHDH.transform.position).normalized;
				TimeManager.instance.DCEJMAFHNKI();
				BJGCPDNMHDH.AEEFNAGJNMN = BJGCPDNMHDH.transform.rotation;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, 479f);
				AJOCDHFNLND = TweenRotation.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, Quaternion.LookRotation(PJKJEGDNCOM - KFCAECGLKKO.NNIFEFPIPAN), true);
				AJOCDHFNLND.delay = 649f;
				AJOCDHFNLND.method = UITweener.Method.Linear;
				TweenPosition.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, BJGCPDNMHDH.transform.position, KFCAECGLKKO.NNIFEFPIPAN, false).delay = 330f;
				TweenRotation aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.FIBGJHCGHJH));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.KJLGCGEGMPJ)
				{
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.HNGMFABKLKF);
					if (KFCAECGLKKO.MOPBHNIHFAC)
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position - BJGCPDNMHDH.transform.position);
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

		public void MPNLGDNLLKF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object CPJCCMLEPCE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DNNAMCFLCGE()
		{
			return PHDOCKCBJOF;
		}

		public void KKCNPIPOCKK()
		{
			throw new NotSupportedException();
		}

		public void GFPDOCDEGPA()
		{
			throw new NotSupportedException();
		}

		public void CFDAGFGOOIE()
		{
			throw new NotSupportedException();
		}

		public void IHAHCOPGPIM()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object ONADHLDNKKB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DBKMMECKKLG()
		{
			return PHDOCKCBJOF;
		}

		public void FLOBHENENIC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object ACDKCFGCBAB()
		{
			return PHDOCKCBJOF;
		}

		public void NIEPBMPJEAE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object OFAOFOPFIJJ()
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
			{
				KFCAECGLKKO = new ADGFNJOKCEJ();
				KFCAECGLKKO.ALIKEGIJIHD = this;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				OAGNKGDKODI = 1054f;
				KFCAECGLKKO.MOPBHNIHFAC = false;
				KFCAECGLKKO.KJLGCGEGMPJ = false;
				KFCAECGLKKO.NNIFEFPIPAN = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position - KHLGDCHJJPB.transform.forward * 61f + KHLGDCHJJPB.transform.right * 339f + Vector3.up * 421f;
				PJKJEGDNCOM = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position;
				KFCAECGLKKO.IFBJNODDLJC = (KFCAECGLKKO.NNIFEFPIPAN - BJGCPDNMHDH.transform.position).normalized;
				TimeManager.instance.KIKGGBHKOAK();
				BJGCPDNMHDH.AEEFNAGJNMN = BJGCPDNMHDH.transform.rotation;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, 1752f);
				AJOCDHFNLND = TweenRotation.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, Quaternion.LookRotation(PJKJEGDNCOM - KFCAECGLKKO.NNIFEFPIPAN));
				AJOCDHFNLND.delay = 113f;
				AJOCDHFNLND.method = UITweener.Method.Linear;
				TweenPosition.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, BJGCPDNMHDH.transform.position, KFCAECGLKKO.NNIFEFPIPAN).delay = 740f;
				TweenRotation aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.CJIBPJPJLNB));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.KJLGCGEGMPJ)
				{
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.HNGMFABKLKF);
					if (KFCAECGLKKO.MOPBHNIHFAC)
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position - BJGCPDNMHDH.transform.position);
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

		[SpecialName]
		private object JFEPOFBDLMB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NOIDHHDEEPL()
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
			{
				KFCAECGLKKO = new ADGFNJOKCEJ();
				KFCAECGLKKO.ALIKEGIJIHD = this;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				OAGNKGDKODI = 1918f;
				KFCAECGLKKO.MOPBHNIHFAC = true;
				KFCAECGLKKO.KJLGCGEGMPJ = true;
				KFCAECGLKKO.NNIFEFPIPAN = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position - KHLGDCHJJPB.transform.forward * 1746f + KHLGDCHJJPB.transform.right * 533f + Vector3.up * 1212f;
				PJKJEGDNCOM = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position;
				KFCAECGLKKO.IFBJNODDLJC = (KFCAECGLKKO.NNIFEFPIPAN - BJGCPDNMHDH.transform.position).normalized;
				TimeManager.instance.DCEJMAFHNKI();
				BJGCPDNMHDH.AEEFNAGJNMN = BJGCPDNMHDH.transform.rotation;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, 338f);
				AJOCDHFNLND = TweenRotation.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, Quaternion.LookRotation(PJKJEGDNCOM - KFCAECGLKKO.NNIFEFPIPAN));
				AJOCDHFNLND.delay = 117f;
				AJOCDHFNLND.method = UITweener.Method.Linear;
				TweenPosition.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, BJGCPDNMHDH.transform.position, KFCAECGLKKO.NNIFEFPIPAN).delay = 1995f;
				TweenRotation aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.POGDLLFCOKO));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.KJLGCGEGMPJ)
				{
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.HNGMFABKLKF);
					if (KFCAECGLKKO.MOPBHNIHFAC)
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position - BJGCPDNMHDH.transform.position);
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

		public bool OOECALAHCFK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				KFCAECGLKKO = new ADGFNJOKCEJ();
				KFCAECGLKKO.ALIKEGIJIHD = this;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				OAGNKGDKODI = 1791f;
				KFCAECGLKKO.MOPBHNIHFAC = true;
				KFCAECGLKKO.KJLGCGEGMPJ = false;
				KFCAECGLKKO.NNIFEFPIPAN = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position - KHLGDCHJJPB.transform.forward * 1831f + KHLGDCHJJPB.transform.right * 677f + Vector3.up * 393f;
				PJKJEGDNCOM = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position;
				KFCAECGLKKO.IFBJNODDLJC = (KFCAECGLKKO.NNIFEFPIPAN - BJGCPDNMHDH.transform.position).normalized;
				TimeManager.instance.EndGame();
				BJGCPDNMHDH.AEEFNAGJNMN = BJGCPDNMHDH.transform.rotation;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, 1154f);
				AJOCDHFNLND = TweenRotation.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, Quaternion.LookRotation(PJKJEGDNCOM - KFCAECGLKKO.NNIFEFPIPAN), true);
				AJOCDHFNLND.delay = 1227f;
				AJOCDHFNLND.method = UITweener.Method.EaseIn;
				TweenPosition.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, BJGCPDNMHDH.transform.position, KFCAECGLKKO.NNIFEFPIPAN).delay = 1481f;
				TweenRotation aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.NAJNECOMDDN));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.KJLGCGEGMPJ)
				{
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.HNGMFABKLKF);
					if (KFCAECGLKKO.MOPBHNIHFAC)
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position - BJGCPDNMHDH.transform.position);
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
		private object GIEPJLBHHEO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PFMFFMEJBPM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HADIFBCDICK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JLLOKNANOCN()
		{
			return PHDOCKCBJOF;
		}

		public void ABOOMAKBEDI()
		{
			throw new NotSupportedException();
		}

		public void PPAIIDFNIDL()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object OIMAEBOAMDB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ENJAAMADMEH()
		{
			return PHDOCKCBJOF;
		}

		public void CFLPOEJGKFF()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JPJBNHHKOJD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BMGHJKFMKJE()
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
			{
				KFCAECGLKKO = new ADGFNJOKCEJ();
				KFCAECGLKKO.ALIKEGIJIHD = this;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				OAGNKGDKODI = 1287f;
				KFCAECGLKKO.MOPBHNIHFAC = true;
				KFCAECGLKKO.KJLGCGEGMPJ = false;
				KFCAECGLKKO.NNIFEFPIPAN = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position - KHLGDCHJJPB.transform.forward * 864f + KHLGDCHJJPB.transform.right * 1972f + Vector3.up * 315f;
				PJKJEGDNCOM = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position;
				KFCAECGLKKO.IFBJNODDLJC = (KFCAECGLKKO.NNIFEFPIPAN - BJGCPDNMHDH.transform.position).normalized;
				TimeManager.instance.KIKGGBHKOAK();
				BJGCPDNMHDH.AEEFNAGJNMN = BJGCPDNMHDH.transform.rotation;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, 284f);
				AJOCDHFNLND = TweenRotation.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, Quaternion.LookRotation(PJKJEGDNCOM - KFCAECGLKKO.NNIFEFPIPAN), true);
				AJOCDHFNLND.delay = 1146f;
				AJOCDHFNLND.method = UITweener.Method.Linear;
				TweenPosition.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, BJGCPDNMHDH.transform.position, KFCAECGLKKO.NNIFEFPIPAN).delay = 1397f;
				TweenRotation aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.CJIBPJPJLNB));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.KJLGCGEGMPJ)
				{
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.HNGMFABKLKF);
					if (KFCAECGLKKO.MOPBHNIHFAC)
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position - BJGCPDNMHDH.transform.position);
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
		private object EMNOCMFCHJN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AJPFLBOOFNJ()
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
			{
				KFCAECGLKKO = new ADGFNJOKCEJ();
				KFCAECGLKKO.ALIKEGIJIHD = this;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				OAGNKGDKODI = 1f;
				KFCAECGLKKO.MOPBHNIHFAC = true;
				KFCAECGLKKO.KJLGCGEGMPJ = true;
				KFCAECGLKKO.NNIFEFPIPAN = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position - KHLGDCHJJPB.transform.forward * 770f + KHLGDCHJJPB.transform.right * 368f + Vector3.up * 88f;
				PJKJEGDNCOM = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position;
				KFCAECGLKKO.IFBJNODDLJC = (KFCAECGLKKO.NNIFEFPIPAN - BJGCPDNMHDH.transform.position).normalized;
				TimeManager.instance.EndGame();
				BJGCPDNMHDH.AEEFNAGJNMN = BJGCPDNMHDH.transform.rotation;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, 594f);
				AJOCDHFNLND = TweenRotation.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, Quaternion.LookRotation(PJKJEGDNCOM - KFCAECGLKKO.NNIFEFPIPAN), true);
				AJOCDHFNLND.delay = 446f;
				AJOCDHFNLND.method = UITweener.Method.EaseIn;
				TweenPosition.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, BJGCPDNMHDH.transform.position, KFCAECGLKKO.NNIFEFPIPAN).delay = 42f;
				TweenRotation aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.CJIBPJPJLNB));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.KJLGCGEGMPJ)
				{
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.HNGMFABKLKF);
					if (KFCAECGLKKO.MOPBHNIHFAC)
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position - BJGCPDNMHDH.transform.position);
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
		private object KBPOAPCEPBN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MBDBIPHLEIA()
		{
			return PHDOCKCBJOF;
		}

		public void KGLKGNBCPLM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void HNOPIDGLMPA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void CDDFJOEEFID()
		{
			throw new NotSupportedException();
		}

		public bool DKIKFMODFJF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				KFCAECGLKKO = new ADGFNJOKCEJ();
				KFCAECGLKKO.ALIKEGIJIHD = this;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				OAGNKGDKODI = 1570f;
				KFCAECGLKKO.MOPBHNIHFAC = false;
				KFCAECGLKKO.KJLGCGEGMPJ = false;
				KFCAECGLKKO.NNIFEFPIPAN = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position - KHLGDCHJJPB.transform.forward * 1789f + KHLGDCHJJPB.transform.right * 1136f + Vector3.up * 1491f;
				PJKJEGDNCOM = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position;
				KFCAECGLKKO.IFBJNODDLJC = (KFCAECGLKKO.NNIFEFPIPAN - BJGCPDNMHDH.transform.position).normalized;
				TimeManager.instance.DCEJMAFHNKI();
				BJGCPDNMHDH.AEEFNAGJNMN = BJGCPDNMHDH.transform.rotation;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, 1150f);
				AJOCDHFNLND = TweenRotation.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, Quaternion.LookRotation(PJKJEGDNCOM - KFCAECGLKKO.NNIFEFPIPAN), true);
				AJOCDHFNLND.delay = 1913f;
				AJOCDHFNLND.method = UITweener.Method.EaseIn;
				TweenPosition.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, BJGCPDNMHDH.transform.position, KFCAECGLKKO.NNIFEFPIPAN).delay = 233f;
				TweenRotation aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.AGFEDJAKLAC));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.KJLGCGEGMPJ)
				{
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.HNGMFABKLKF);
					if (KFCAECGLKKO.MOPBHNIHFAC)
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position - BJGCPDNMHDH.transform.position);
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

		public bool FNIOOIGJPAM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				KFCAECGLKKO = new ADGFNJOKCEJ();
				KFCAECGLKKO.ALIKEGIJIHD = this;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				OAGNKGDKODI = 734f;
				KFCAECGLKKO.MOPBHNIHFAC = false;
				KFCAECGLKKO.KJLGCGEGMPJ = false;
				KFCAECGLKKO.NNIFEFPIPAN = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position - KHLGDCHJJPB.transform.forward * 636f + KHLGDCHJJPB.transform.right * 1585f + Vector3.up * 436f;
				PJKJEGDNCOM = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position;
				KFCAECGLKKO.IFBJNODDLJC = (KFCAECGLKKO.NNIFEFPIPAN - BJGCPDNMHDH.transform.position).normalized;
				TimeManager.instance.EndGame();
				BJGCPDNMHDH.AEEFNAGJNMN = BJGCPDNMHDH.transform.rotation;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, 114f);
				AJOCDHFNLND = TweenRotation.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, Quaternion.LookRotation(PJKJEGDNCOM - KFCAECGLKKO.NNIFEFPIPAN));
				AJOCDHFNLND.delay = 1446f;
				AJOCDHFNLND.method = UITweener.Method.EaseIn;
				TweenPosition.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, BJGCPDNMHDH.transform.position, KFCAECGLKKO.NNIFEFPIPAN, false).delay = 157f;
				TweenRotation aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.FDKEAJLEMCM));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.KJLGCGEGMPJ)
				{
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.HNGMFABKLKF);
					if (KFCAECGLKKO.MOPBHNIHFAC)
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position - BJGCPDNMHDH.transform.position);
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

		public bool KBPKMAKLNPB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				KFCAECGLKKO = new ADGFNJOKCEJ();
				KFCAECGLKKO.ALIKEGIJIHD = this;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				OAGNKGDKODI = 1673f;
				KFCAECGLKKO.MOPBHNIHFAC = false;
				KFCAECGLKKO.KJLGCGEGMPJ = false;
				KFCAECGLKKO.NNIFEFPIPAN = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position - KHLGDCHJJPB.transform.forward * 1725f + KHLGDCHJJPB.transform.right * 25f + Vector3.up * 1950f;
				PJKJEGDNCOM = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position;
				KFCAECGLKKO.IFBJNODDLJC = (KFCAECGLKKO.NNIFEFPIPAN - BJGCPDNMHDH.transform.position).normalized;
				TimeManager.instance.DCEJMAFHNKI();
				BJGCPDNMHDH.AEEFNAGJNMN = BJGCPDNMHDH.transform.rotation;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, 339f);
				AJOCDHFNLND = TweenRotation.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, Quaternion.LookRotation(PJKJEGDNCOM - KFCAECGLKKO.NNIFEFPIPAN));
				AJOCDHFNLND.delay = 1275f;
				AJOCDHFNLND.method = UITweener.Method.Linear;
				TweenPosition.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, BJGCPDNMHDH.transform.position, KFCAECGLKKO.NNIFEFPIPAN, false).delay = 881f;
				TweenRotation aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.NDJOJHNIBFC));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.KJLGCGEGMPJ)
				{
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.HNGMFABKLKF);
					if (KFCAECGLKKO.MOPBHNIHFAC)
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position - BJGCPDNMHDH.transform.position);
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

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				KFCAECGLKKO = new ADGFNJOKCEJ();
				KFCAECGLKKO.ALIKEGIJIHD = this;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				OAGNKGDKODI = 1f;
				KFCAECGLKKO.MOPBHNIHFAC = false;
				KFCAECGLKKO.KJLGCGEGMPJ = false;
				KFCAECGLKKO.NNIFEFPIPAN = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position - KHLGDCHJJPB.transform.forward * 1.5f + KHLGDCHJJPB.transform.right * 1f + Vector3.up * 1.2f;
				PJKJEGDNCOM = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position;
				KFCAECGLKKO.IFBJNODDLJC = (KFCAECGLKKO.NNIFEFPIPAN - BJGCPDNMHDH.transform.position).normalized;
				TimeManager.instance.EndGame();
				BJGCPDNMHDH.AEEFNAGJNMN = BJGCPDNMHDH.transform.rotation;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, 40f);
				AJOCDHFNLND = TweenRotation.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, Quaternion.LookRotation(PJKJEGDNCOM - KFCAECGLKKO.NNIFEFPIPAN));
				AJOCDHFNLND.delay = 0f;
				AJOCDHFNLND.method = UITweener.Method.EaseIn;
				TweenPosition.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, BJGCPDNMHDH.transform.position, KFCAECGLKKO.NNIFEFPIPAN, false).delay = 0f;
				TweenRotation aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.LJCDGJKCNEC));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.KJLGCGEGMPJ)
				{
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.HNGMFABKLKF);
					if (KFCAECGLKKO.MOPBHNIHFAC)
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position - BJGCPDNMHDH.transform.position);
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

		public void KAFNGNMNNOA()
		{
			throw new NotSupportedException();
		}

		public void FGLAPPKJHBK()
		{
			throw new NotSupportedException();
		}

		public void PHKDHCJBMII()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool LGLPPAENMGK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				KFCAECGLKKO = new ADGFNJOKCEJ();
				KFCAECGLKKO.ALIKEGIJIHD = this;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				OAGNKGDKODI = 85f;
				KFCAECGLKKO.MOPBHNIHFAC = true;
				KFCAECGLKKO.KJLGCGEGMPJ = false;
				KFCAECGLKKO.NNIFEFPIPAN = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position - KHLGDCHJJPB.transform.forward * 1442f + KHLGDCHJJPB.transform.right * 1647f + Vector3.up * 68f;
				PJKJEGDNCOM = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position;
				KFCAECGLKKO.IFBJNODDLJC = (KFCAECGLKKO.NNIFEFPIPAN - BJGCPDNMHDH.transform.position).normalized;
				TimeManager.instance.KIKGGBHKOAK();
				BJGCPDNMHDH.AEEFNAGJNMN = BJGCPDNMHDH.transform.rotation;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, 760f);
				AJOCDHFNLND = TweenRotation.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, Quaternion.LookRotation(PJKJEGDNCOM - KFCAECGLKKO.NNIFEFPIPAN), true);
				AJOCDHFNLND.delay = 1023f;
				AJOCDHFNLND.method = UITweener.Method.EaseIn;
				TweenPosition.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, BJGCPDNMHDH.transform.position, KFCAECGLKKO.NNIFEFPIPAN, false).delay = 35f;
				TweenRotation aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.FDKEAJLEMCM));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.KJLGCGEGMPJ)
				{
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.HNGMFABKLKF);
					if (KFCAECGLKKO.MOPBHNIHFAC)
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position - BJGCPDNMHDH.transform.position);
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

		public void OOOLABBEKDF()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object LMJBCDNGAHP()
		{
			return PHDOCKCBJOF;
		}

		public bool MHCIOCPGMHF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				KFCAECGLKKO = new ADGFNJOKCEJ();
				KFCAECGLKKO.ALIKEGIJIHD = this;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				OAGNKGDKODI = 729f;
				KFCAECGLKKO.MOPBHNIHFAC = true;
				KFCAECGLKKO.KJLGCGEGMPJ = false;
				KFCAECGLKKO.NNIFEFPIPAN = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position - KHLGDCHJJPB.transform.forward * 1433f + KHLGDCHJJPB.transform.right * 1309f + Vector3.up * 1898f;
				PJKJEGDNCOM = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position;
				KFCAECGLKKO.IFBJNODDLJC = (KFCAECGLKKO.NNIFEFPIPAN - BJGCPDNMHDH.transform.position).normalized;
				TimeManager.instance.KIKGGBHKOAK();
				BJGCPDNMHDH.AEEFNAGJNMN = BJGCPDNMHDH.transform.rotation;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, 379f);
				AJOCDHFNLND = TweenRotation.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, Quaternion.LookRotation(PJKJEGDNCOM - KFCAECGLKKO.NNIFEFPIPAN), true);
				AJOCDHFNLND.delay = 1320f;
				AJOCDHFNLND.method = UITweener.Method.EaseIn;
				TweenPosition.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, BJGCPDNMHDH.transform.position, KFCAECGLKKO.NNIFEFPIPAN, false).delay = 1230f;
				TweenRotation aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.FDKEAJLEMCM));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.KJLGCGEGMPJ)
				{
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.HNGMFABKLKF);
					if (KFCAECGLKKO.MOPBHNIHFAC)
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position - BJGCPDNMHDH.transform.position);
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

		public bool AIFKBHCOIKG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				KFCAECGLKKO = new ADGFNJOKCEJ();
				KFCAECGLKKO.ALIKEGIJIHD = this;
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				OAGNKGDKODI = 1892f;
				KFCAECGLKKO.MOPBHNIHFAC = false;
				KFCAECGLKKO.KJLGCGEGMPJ = true;
				KFCAECGLKKO.NNIFEFPIPAN = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position - KHLGDCHJJPB.transform.forward * 137f + KHLGDCHJJPB.transform.right * 1618f + Vector3.up * 1341f;
				PJKJEGDNCOM = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position;
				KFCAECGLKKO.IFBJNODDLJC = (KFCAECGLKKO.NNIFEFPIPAN - BJGCPDNMHDH.transform.position).normalized;
				TimeManager.instance.EndGame();
				BJGCPDNMHDH.AEEFNAGJNMN = BJGCPDNMHDH.transform.rotation;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, 579f);
				AJOCDHFNLND = TweenRotation.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, Quaternion.LookRotation(PJKJEGDNCOM - KFCAECGLKKO.NNIFEFPIPAN), true);
				AJOCDHFNLND.delay = 295f;
				AJOCDHFNLND.method = UITweener.Method.EaseIn;
				TweenPosition.Begin(BJGCPDNMHDH.gameObject, OAGNKGDKODI, BJGCPDNMHDH.transform.position, KFCAECGLKKO.NNIFEFPIPAN).delay = 1125f;
				TweenRotation aJOCDHFNLND = AJOCDHFNLND;
				aJOCDHFNLND.onFinished = (UITweener.OnFinished)Delegate.Combine(aJOCDHFNLND.onFinished, new UITweener.OnFinished(KFCAECGLKKO.NDJOJHNIBFC));
				goto case 1u;
			}
			case 1u:
				if (!KFCAECGLKKO.KJLGCGEGMPJ)
				{
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.HNGMFABKLKF);
					if (KFCAECGLKKO.MOPBHNIHFAC)
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position - BJGCPDNMHDH.transform.position);
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

		public void GDJMNEPLJNE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BIGMAMMHKFP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LDBICDEEENB()
		{
			return PHDOCKCBJOF;
		}
	}

	private sealed class DEMDEMKGBAF : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal float BMHCHLIFGAB;

		internal PlayerController KHLGDCHJJPB;

		internal Vector3 NJEEECDEAAP;

		internal Vector3 JKGKCGHALHH;

		internal Vector3 LDOPAMLMIEM;

		internal Vector3 GBBHOBILBPE;

		internal Vector3 PJKJEGDNCOM;

		internal float GFMHPOJAKKK;

		internal Vector3 LLENOKPFOJL;

		internal GameCamera BJGCPDNMHDH;

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
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void GFPDOCDEGPA()
		{
			throw new NotSupportedException();
		}

		public bool HDGDKCMIOGK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				TimeManager.instance.EndGame();
				BMHCHLIFGAB = 1118f;
				NJEEECDEAAP = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position;
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				LDOPAMLMIEM = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position - KHLGDCHJJPB.transform.forward * 1476f + KHLGDCHJJPB.transform.right * BMHCHLIFGAB + Vector3.up * 168f;
				GBBHOBILBPE = NJEEECDEAAP - LDOPAMLMIEM;
				PJKJEGDNCOM = NJEEECDEAAP;
				GFMHPOJAKKK = 617f;
				goto case 1u;
			case 1u:
				if (GFMHPOJAKKK < BJGCPDNMHDH.FFBCLAAGOEK)
				{
					GFMHPOJAKKK += Time.unscaledDeltaTime;
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.JCAOCHMKFOI);
					LLENOKPFOJL = Quaternion.Euler(1801f, (0f - BMHCHLIFGAB) * BJGCPDNMHDH.BLCBHCPDOLO.Evaluate(GFMHPOJAKKK), 1570f) * GBBHOBILBPE;
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, PJKJEGDNCOM - LLENOKPFOJL, BJGCPDNMHDH.NDNCOKHKKFM.Evaluate(GFMHPOJAKKK));
					BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position);
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

		public void NINFHADPHJI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void PHKDHCJBMII()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void DBJCDLFKDDI()
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
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				TimeManager.instance.EndGame();
				BMHCHLIFGAB = 1f;
				NJEEECDEAAP = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position;
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				LDOPAMLMIEM = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position - KHLGDCHJJPB.transform.forward * 1f + KHLGDCHJJPB.transform.right * BMHCHLIFGAB + Vector3.up * 1.2f;
				GBBHOBILBPE = NJEEECDEAAP - LDOPAMLMIEM;
				PJKJEGDNCOM = NJEEECDEAAP;
				GFMHPOJAKKK = 0f;
				goto case 1u;
			case 1u:
				if (GFMHPOJAKKK < BJGCPDNMHDH.FFBCLAAGOEK)
				{
					GFMHPOJAKKK += Time.unscaledDeltaTime;
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.JCAOCHMKFOI);
					LLENOKPFOJL = Quaternion.Euler(0f, (0f - BMHCHLIFGAB) * BJGCPDNMHDH.BLCBHCPDOLO.Evaluate(GFMHPOJAKKK), 0f) * GBBHOBILBPE;
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, PJKJEGDNCOM - LLENOKPFOJL, BJGCPDNMHDH.NDNCOKHKKFM.Evaluate(GFMHPOJAKKK));
					BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position);
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
		private object HFKDIPEKENH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BLOJDIFOPIA()
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
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				TimeManager.instance.DCEJMAFHNKI();
				BMHCHLIFGAB = 677f;
				NJEEECDEAAP = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position;
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				LDOPAMLMIEM = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position - KHLGDCHJJPB.transform.forward * 1213f + KHLGDCHJJPB.transform.right * BMHCHLIFGAB + Vector3.up * 516f;
				GBBHOBILBPE = NJEEECDEAAP - LDOPAMLMIEM;
				PJKJEGDNCOM = NJEEECDEAAP;
				GFMHPOJAKKK = 281f;
				goto case 1u;
			case 1u:
				if (GFMHPOJAKKK < BJGCPDNMHDH.FFBCLAAGOEK)
				{
					GFMHPOJAKKK += Time.unscaledDeltaTime;
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.JCAOCHMKFOI);
					LLENOKPFOJL = Quaternion.Euler(368f, (0f - BMHCHLIFGAB) * BJGCPDNMHDH.BLCBHCPDOLO.Evaluate(GFMHPOJAKKK), 411f) * GBBHOBILBPE;
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, PJKJEGDNCOM - LLENOKPFOJL, BJGCPDNMHDH.NDNCOKHKKFM.Evaluate(GFMHPOJAKKK));
					BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position);
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

		[DebuggerHidden]
		public DEMDEMKGBAF()
		{
		}

		[SpecialName]
		private object JALKNCBEINE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KIHECHEHNJJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IDLFKAKINAP()
		{
			return PHDOCKCBJOF;
		}

		public void AHEOCEEJICJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object LMBPPPOFIOC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IHPDPKLEDKC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LFEJDKIGHMI()
		{
			return PHDOCKCBJOF;
		}

		public void FJOIBBIGBJC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool MKLIDMNLNPN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				TimeManager.instance.EndGame();
				BMHCHLIFGAB = 101f;
				NJEEECDEAAP = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position;
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				LDOPAMLMIEM = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position - KHLGDCHJJPB.transform.forward * 1201f + KHLGDCHJJPB.transform.right * BMHCHLIFGAB + Vector3.up * 99f;
				GBBHOBILBPE = NJEEECDEAAP - LDOPAMLMIEM;
				PJKJEGDNCOM = NJEEECDEAAP;
				GFMHPOJAKKK = 577f;
				goto case 1u;
			case 1u:
				if (GFMHPOJAKKK < BJGCPDNMHDH.FFBCLAAGOEK)
				{
					GFMHPOJAKKK += Time.unscaledDeltaTime;
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.JCAOCHMKFOI);
					LLENOKPFOJL = Quaternion.Euler(251f, (0f - BMHCHLIFGAB) * BJGCPDNMHDH.BLCBHCPDOLO.Evaluate(GFMHPOJAKKK), 306f) * GBBHOBILBPE;
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, PJKJEGDNCOM - LLENOKPFOJL, BJGCPDNMHDH.NDNCOKHKKFM.Evaluate(GFMHPOJAKKK));
					BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position);
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

		public bool NJBCJDFKGHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				TimeManager.instance.DCEJMAFHNKI();
				BMHCHLIFGAB = 1879f;
				NJEEECDEAAP = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position;
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				LDOPAMLMIEM = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position - KHLGDCHJJPB.transform.forward * 999f + KHLGDCHJJPB.transform.right * BMHCHLIFGAB + Vector3.up * 503f;
				GBBHOBILBPE = NJEEECDEAAP - LDOPAMLMIEM;
				PJKJEGDNCOM = NJEEECDEAAP;
				GFMHPOJAKKK = 1985f;
				goto case 1u;
			case 1u:
				if (GFMHPOJAKKK < BJGCPDNMHDH.FFBCLAAGOEK)
				{
					GFMHPOJAKKK += Time.unscaledDeltaTime;
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.JCAOCHMKFOI);
					LLENOKPFOJL = Quaternion.Euler(1325f, (0f - BMHCHLIFGAB) * BJGCPDNMHDH.BLCBHCPDOLO.Evaluate(GFMHPOJAKKK), 79f) * GBBHOBILBPE;
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, PJKJEGDNCOM - LLENOKPFOJL, BJGCPDNMHDH.NDNCOKHKKFM.Evaluate(GFMHPOJAKKK));
					BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position);
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

		public bool OKELILGDPLJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				TimeManager.instance.KIKGGBHKOAK();
				BMHCHLIFGAB = 1285f;
				NJEEECDEAAP = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position;
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				LDOPAMLMIEM = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position - KHLGDCHJJPB.transform.forward * 1820f + KHLGDCHJJPB.transform.right * BMHCHLIFGAB + Vector3.up * 854f;
				GBBHOBILBPE = NJEEECDEAAP - LDOPAMLMIEM;
				PJKJEGDNCOM = NJEEECDEAAP;
				GFMHPOJAKKK = 1583f;
				goto case 1u;
			case 1u:
				if (GFMHPOJAKKK < BJGCPDNMHDH.FFBCLAAGOEK)
				{
					GFMHPOJAKKK += Time.unscaledDeltaTime;
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.JCAOCHMKFOI);
					LLENOKPFOJL = Quaternion.Euler(1318f, (0f - BMHCHLIFGAB) * BJGCPDNMHDH.BLCBHCPDOLO.Evaluate(GFMHPOJAKKK), 1164f) * GBBHOBILBPE;
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, PJKJEGDNCOM - LLENOKPFOJL, BJGCPDNMHDH.NDNCOKHKKFM.Evaluate(GFMHPOJAKKK));
					BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position);
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

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void CPDBCJLIGFN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GDBNOMPNBGP()
		{
			return PHDOCKCBJOF;
		}

		public void JMANMKKCDMM()
		{
			throw new NotSupportedException();
		}

		public void ONGBFFAENBP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object FBPFPJOCKGD()
		{
			return PHDOCKCBJOF;
		}
	}

	private sealed class CMKGCGFGHGL : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal bool GIBNBNNGOCA;

		internal float GJNNILFEENM;

		internal float NNOGOMECPCL;

		internal Vector3 LIIDNBJLGKK;

		internal PlayerController KHLGDCHJJPB;

		internal Vector3 BOGNOBEGGCA;

		internal Vector3 NJEEECDEAAP;

		internal Vector3 OEJPDPIFMMN;

		internal Vector3 NJOALCJKMBG;

		internal float NHNBKDPDAJO;

		internal float BMHCHLIFGAB;

		internal List<MapDefinition.DefendPosition>.Enumerator KFCAECGLKKO;

		internal float COOGKNIEOPA;

		internal float LADMMFLMOLE;

		internal bool POJLMKBHOKE;

		internal float KACAOLJDOBD;

		internal float PNBNBEGGBOJ;

		internal float EGPHGLFABMF;

		internal Vector3 JKGKCGHALHH;

		internal Vector3 LDOPAMLMIEM;

		internal Vector3 GBBHOBILBPE;

		internal Vector3 PJKJEGDNCOM;

		internal float GFMHPOJAKKK;

		internal float EGPAJKLILCP;

		internal Vector3 DBBPNFBMCKG;

		internal GameCamera BJGCPDNMHDH;

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
		private object IHAOBCEALPD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HHLKEMNNJDA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object APECNPGKOFC()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public CMKGCGFGHGL()
		{
		}

		public void AKEKFBGEJBG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void OKIANDBCDIB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GMPGIODBIPO()
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
				GJNNILFEENM = ((!GIBNBNNGOCA) ? BJGCPDNMHDH.LINAKKNHIMN : BJGCPDNMHDH.EHFLEBJNBLN);
				NNOGOMECPCL = ((!GIBNBNNGOCA) ? BJGCPDNMHDH.DMOJKNBFAIG : BJGCPDNMHDH.FCJAGHDNONI);
				TimeManager.FODFANEEDFF();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				LIIDNBJLGKK = BJGCPDNMHDH.transform.position;
				BOGNOBEGGCA = -KHLGDCHJJPB.BBNPGJAALCJ().point.transform.forward;
				NJEEECDEAAP = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position;
				OEJPDPIFMMN = NJEEECDEAAP;
				NJOALCJKMBG = Vector3.up;
				NHNBKDPDAJO = 1444f;
				BMHCHLIFGAB = 1355f;
				KFCAECGLKKO = Singleton<MapManager>.instance.ALCHJDPKAID.MNKKJJADINL().GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
						if (current.fraction == KHLGDCHJJPB.fraction)
						{
							Vector3 lhs = NJEEECDEAAP - current.point.transform.position;
							float num = Vector3.Dot(lhs, current.point.transform.right);
							if (num <= BJGCPDNMHDH.LNIPMGOFEJN && num >= 0f - BJGCPDNMHDH.LNIPMGOFEJN)
							{
								BMHCHLIFGAB = ((!(num > 1621f)) ? 173f : 1908f);
								NHNBKDPDAJO = BJGCPDNMHDH.MKBOFBPMAKK * BMHCHLIFGAB;
								OEJPDPIFMMN = BMHCHLIFGAB * current.point.transform.right * BJGCPDNMHDH.LNIPMGOFEJN + NJEEECDEAAP;
							}
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				OEJPDPIFMMN += BOGNOBEGGCA * BJGCPDNMHDH.AMMELLKBLID.x + Vector3.up * BJGCPDNMHDH.AMMELLKBLID.y;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.LAEADIDHNGP, BJGCPDNMHDH.ECFEPPBGAIO);
				COOGKNIEOPA = 1984f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				POJLMKBHOKE = false;
				goto case 1u;
			case 1u:
				if (COOGKNIEOPA < 1495f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / GJNNILFEENM);
					KACAOLJDOBD = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					PNBNBEGGBOJ = BJGCPDNMHDH.CMGCJMNLCPB.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(LIIDNBJLGKK, OEJPDPIFMMN, KACAOLJDOBD);
					BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(NJEEECDEAAP.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position) * Quaternion.Euler(1513f, 204f, Mathf.Lerp(373f, NHNBKDPDAJO, PNBNBEGGBOJ));
					if (!POJLMKBHOKE && COOGKNIEOPA > (GJNNILFEENM - NNOGOMECPCL) / GJNNILFEENM)
					{
						POJLMKBHOKE = true;
						TweenFOV.Begin(BJGCPDNMHDH.gameObject, NNOGOMECPCL, 654f);
					}
					PHDOCKCBJOF = 1;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				EGPHGLFABMF = Time.realtimeSinceStartup + BJGCPDNMHDH.NGLBIAMOBHF;
				goto case 2u;
			case 2u:
				if (EGPHGLFABMF > Time.realtimeSinceStartup)
				{
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				TimeManager.instance.KIKGGBHKOAK();
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				LDOPAMLMIEM = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position - KHLGDCHJJPB.transform.forward * 1387f + KHLGDCHJJPB.transform.right * BMHCHLIFGAB + Vector3.up * 984f;
				GBBHOBILBPE = NJEEECDEAAP - LDOPAMLMIEM;
				PJKJEGDNCOM = NJEEECDEAAP;
				GFMHPOJAKKK = 1279f;
				goto case 3u;
			case 3u:
				if (GFMHPOJAKKK < BJGCPDNMHDH.FFBCLAAGOEK)
				{
					EGPAJKLILCP = BJGCPDNMHDH.FJGHEKIIIJJ.Evaluate(GFMHPOJAKKK);
					GFMHPOJAKKK += Time.unscaledDeltaTime;
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.JCAOCHMKFOI);
					DBBPNFBMCKG = Quaternion.Euler(1507f, (0f - BMHCHLIFGAB) * BJGCPDNMHDH.BLCBHCPDOLO.Evaluate(GFMHPOJAKKK), 787f) * GBBHOBILBPE;
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, PJKJEGDNCOM - DBBPNFBMCKG, BJGCPDNMHDH.NDNCOKHKKFM.Evaluate(GFMHPOJAKKK));
					if ((PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position).magnitude < 1969f)
					{
						object[] array = new object[1];
						array[0] = COOGKNIEOPA;
						array[1] = PJKJEGDNCOM;
						array[2] = BJGCPDNMHDH.transform.position;
						array[1] = NJEEECDEAAP;
						array[6] = LDOPAMLMIEM;
						array[0] = EGPAJKLILCP;
						array[6] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("OnFetchDeferredAppLinkSucceededEvent", array));
					}
					else if (PJKJEGDNCOM.x == BJGCPDNMHDH.transform.position.x && PJKJEGDNCOM.z == BJGCPDNMHDH.transform.position.z)
					{
						object[] array2 = new object[5];
						array2[0] = COOGKNIEOPA;
						array2[0] = PJKJEGDNCOM;
						array2[6] = BJGCPDNMHDH.transform.position;
						array2[1] = NJEEECDEAAP;
						array2[5] = LDOPAMLMIEM;
						array2[5] = EGPAJKLILCP;
						array2[3] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("No", array2));
					}
					else
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position) * Quaternion.Euler(1551f, 15f, Mathf.Lerp(1171f, NHNBKDPDAJO, EGPAJKLILCP));
					}
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
		private object CNGCLCAAHIG()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
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
				GJNNILFEENM = ((!GIBNBNNGOCA) ? BJGCPDNMHDH.LINAKKNHIMN : BJGCPDNMHDH.EHFLEBJNBLN);
				NNOGOMECPCL = ((!GIBNBNNGOCA) ? BJGCPDNMHDH.DMOJKNBFAIG : BJGCPDNMHDH.FCJAGHDNONI);
				TimeManager.FODFANEEDFF();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				LIIDNBJLGKK = BJGCPDNMHDH.transform.position;
				BOGNOBEGGCA = -KHLGDCHJJPB.EMAMENNDFMB().point.transform.forward;
				NJEEECDEAAP = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position;
				OEJPDPIFMMN = NJEEECDEAAP;
				NJOALCJKMBG = Vector3.up;
				NHNBKDPDAJO = 544f;
				BMHCHLIFGAB = 1206f;
				KFCAECGLKKO = Singleton<MapManager>.instance.ALCHJDPKAID.IJDLIIBLLJO().GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
						if (current.fraction == KHLGDCHJJPB.fraction)
						{
							Vector3 lhs = NJEEECDEAAP - current.point.transform.position;
							float num = Vector3.Dot(lhs, current.point.transform.right);
							if (num <= BJGCPDNMHDH.LNIPMGOFEJN && num >= 0f - BJGCPDNMHDH.LNIPMGOFEJN)
							{
								BMHCHLIFGAB = ((!(num > 1158f)) ? 1324f : 1845f);
								NHNBKDPDAJO = BJGCPDNMHDH.MKBOFBPMAKK * BMHCHLIFGAB;
								OEJPDPIFMMN = BMHCHLIFGAB * current.point.transform.right * BJGCPDNMHDH.LNIPMGOFEJN + NJEEECDEAAP;
							}
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				OEJPDPIFMMN += BOGNOBEGGCA * BJGCPDNMHDH.AMMELLKBLID.x + Vector3.up * BJGCPDNMHDH.AMMELLKBLID.y;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.LAEADIDHNGP, BJGCPDNMHDH.ECFEPPBGAIO);
				COOGKNIEOPA = 976f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				POJLMKBHOKE = false;
				goto case 1u;
			case 1u:
				if (COOGKNIEOPA < 572f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / GJNNILFEENM);
					KACAOLJDOBD = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					PNBNBEGGBOJ = BJGCPDNMHDH.CMGCJMNLCPB.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(LIIDNBJLGKK, OEJPDPIFMMN, KACAOLJDOBD);
					BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(NJEEECDEAAP.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position) * Quaternion.Euler(1261f, 457f, Mathf.Lerp(1701f, NHNBKDPDAJO, PNBNBEGGBOJ));
					if (!POJLMKBHOKE && COOGKNIEOPA > (GJNNILFEENM - NNOGOMECPCL) / GJNNILFEENM)
					{
						POJLMKBHOKE = true;
						TweenFOV.Begin(BJGCPDNMHDH.gameObject, NNOGOMECPCL, 292f);
					}
					PHDOCKCBJOF = 1;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				EGPHGLFABMF = Time.realtimeSinceStartup + BJGCPDNMHDH.NGLBIAMOBHF;
				goto case 2u;
			case 2u:
				if (EGPHGLFABMF > Time.realtimeSinceStartup)
				{
					PHDOCKCBJOF = 1;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				TimeManager.instance.EndGame();
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				LDOPAMLMIEM = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position - KHLGDCHJJPB.transform.forward * 1630f + KHLGDCHJJPB.transform.right * BMHCHLIFGAB + Vector3.up * 1303f;
				GBBHOBILBPE = NJEEECDEAAP - LDOPAMLMIEM;
				PJKJEGDNCOM = NJEEECDEAAP;
				GFMHPOJAKKK = 242f;
				goto case 3u;
			case 3u:
				if (GFMHPOJAKKK < BJGCPDNMHDH.FFBCLAAGOEK)
				{
					EGPAJKLILCP = BJGCPDNMHDH.FJGHEKIIIJJ.Evaluate(GFMHPOJAKKK);
					GFMHPOJAKKK += Time.unscaledDeltaTime;
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.JCAOCHMKFOI);
					DBBPNFBMCKG = Quaternion.Euler(169f, (0f - BMHCHLIFGAB) * BJGCPDNMHDH.BLCBHCPDOLO.Evaluate(GFMHPOJAKKK), 535f) * GBBHOBILBPE;
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, PJKJEGDNCOM - DBBPNFBMCKG, BJGCPDNMHDH.NDNCOKHKKFM.Evaluate(GFMHPOJAKKK));
					if ((PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position).magnitude < 1075f)
					{
						object[] array = new object[1];
						array[0] = COOGKNIEOPA;
						array[1] = PJKJEGDNCOM;
						array[3] = BJGCPDNMHDH.transform.position;
						array[7] = NJEEECDEAAP;
						array[5] = LDOPAMLMIEM;
						array[2] = EGPAJKLILCP;
						array[3] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("ID_READYTIME", array));
					}
					else if (PJKJEGDNCOM.x == BJGCPDNMHDH.transform.position.x && PJKJEGDNCOM.z == BJGCPDNMHDH.transform.position.z)
					{
						object[] array2 = new object[0];
						array2[0] = COOGKNIEOPA;
						array2[0] = PJKJEGDNCOM;
						array2[2] = BJGCPDNMHDH.transform.position;
						array2[5] = NJEEECDEAAP;
						array2[4] = LDOPAMLMIEM;
						array2[3] = EGPAJKLILCP;
						array2[2] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("ID_ROUNDREWARD", array2));
					}
					else
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position) * Quaternion.Euler(1040f, 1922f, Mathf.Lerp(1193f, NHNBKDPDAJO, EGPAJKLILCP));
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

		public bool HDGDKCMIOGK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				GJNNILFEENM = ((!GIBNBNNGOCA) ? BJGCPDNMHDH.LINAKKNHIMN : BJGCPDNMHDH.EHFLEBJNBLN);
				NNOGOMECPCL = ((!GIBNBNNGOCA) ? BJGCPDNMHDH.DMOJKNBFAIG : BJGCPDNMHDH.FCJAGHDNONI);
				TimeManager.FreezeGame();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				LIIDNBJLGKK = BJGCPDNMHDH.transform.position;
				BOGNOBEGGCA = -KHLGDCHJJPB.BBNPGJAALCJ().point.transform.forward;
				NJEEECDEAAP = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position;
				OEJPDPIFMMN = NJEEECDEAAP;
				NJOALCJKMBG = Vector3.up;
				NHNBKDPDAJO = 1575f;
				BMHCHLIFGAB = 1472f;
				KFCAECGLKKO = Singleton<MapManager>.instance.ALCHJDPKAID.DFFPKLEEKKK().GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
						if (current.fraction == KHLGDCHJJPB.fraction)
						{
							Vector3 lhs = NJEEECDEAAP - current.point.transform.position;
							float num = Vector3.Dot(lhs, current.point.transform.right);
							if (num <= BJGCPDNMHDH.LNIPMGOFEJN && num >= 0f - BJGCPDNMHDH.LNIPMGOFEJN)
							{
								BMHCHLIFGAB = ((!(num > 181f)) ? 1974f : 150f);
								NHNBKDPDAJO = BJGCPDNMHDH.MKBOFBPMAKK * BMHCHLIFGAB;
								OEJPDPIFMMN = BMHCHLIFGAB * current.point.transform.right * BJGCPDNMHDH.LNIPMGOFEJN + NJEEECDEAAP;
							}
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				OEJPDPIFMMN += BOGNOBEGGCA * BJGCPDNMHDH.AMMELLKBLID.x + Vector3.up * BJGCPDNMHDH.AMMELLKBLID.y;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.LAEADIDHNGP, BJGCPDNMHDH.ECFEPPBGAIO);
				COOGKNIEOPA = 1622f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				POJLMKBHOKE = false;
				goto case 1u;
			case 1u:
				if (COOGKNIEOPA < 1715f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / GJNNILFEENM);
					KACAOLJDOBD = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					PNBNBEGGBOJ = BJGCPDNMHDH.CMGCJMNLCPB.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(LIIDNBJLGKK, OEJPDPIFMMN, KACAOLJDOBD);
					BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(NJEEECDEAAP.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position) * Quaternion.Euler(933f, 1897f, Mathf.Lerp(160f, NHNBKDPDAJO, PNBNBEGGBOJ));
					if (!POJLMKBHOKE && COOGKNIEOPA > (GJNNILFEENM - NNOGOMECPCL) / GJNNILFEENM)
					{
						POJLMKBHOKE = false;
						TweenFOV.Begin(BJGCPDNMHDH.gameObject, NNOGOMECPCL, 1773f);
					}
					PHDOCKCBJOF = 1;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				EGPHGLFABMF = Time.realtimeSinceStartup + BJGCPDNMHDH.NGLBIAMOBHF;
				goto case 2u;
			case 2u:
				if (EGPHGLFABMF > Time.realtimeSinceStartup)
				{
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				TimeManager.instance.KIKGGBHKOAK();
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				LDOPAMLMIEM = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position - KHLGDCHJJPB.transform.forward * 480f + KHLGDCHJJPB.transform.right * BMHCHLIFGAB + Vector3.up * 1580f;
				GBBHOBILBPE = NJEEECDEAAP - LDOPAMLMIEM;
				PJKJEGDNCOM = NJEEECDEAAP;
				GFMHPOJAKKK = 1464f;
				goto case 3u;
			case 3u:
				if (GFMHPOJAKKK < BJGCPDNMHDH.FFBCLAAGOEK)
				{
					EGPAJKLILCP = BJGCPDNMHDH.FJGHEKIIIJJ.Evaluate(GFMHPOJAKKK);
					GFMHPOJAKKK += Time.unscaledDeltaTime;
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.JCAOCHMKFOI);
					DBBPNFBMCKG = Quaternion.Euler(1102f, (0f - BMHCHLIFGAB) * BJGCPDNMHDH.BLCBHCPDOLO.Evaluate(GFMHPOJAKKK), 1413f) * GBBHOBILBPE;
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, PJKJEGDNCOM - DBBPNFBMCKG, BJGCPDNMHDH.NDNCOKHKKFM.Evaluate(GFMHPOJAKKK));
					if ((PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position).magnitude < 979f)
					{
						object[] array = new object[8];
						array[1] = COOGKNIEOPA;
						array[0] = PJKJEGDNCOM;
						array[5] = BJGCPDNMHDH.transform.position;
						array[4] = NJEEECDEAAP;
						array[0] = LDOPAMLMIEM;
						array[8] = EGPAJKLILCP;
						array[1] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("ID_FEATURE_BURSTSIZE-DESRIPTION", array));
					}
					else if (PJKJEGDNCOM.x == BJGCPDNMHDH.transform.position.x && PJKJEGDNCOM.z == BJGCPDNMHDH.transform.position.z)
					{
						object[] array2 = new object[8];
						array2[0] = COOGKNIEOPA;
						array2[0] = PJKJEGDNCOM;
						array2[3] = BJGCPDNMHDH.transform.position;
						array2[6] = NJEEECDEAAP;
						array2[3] = LDOPAMLMIEM;
						array2[0] = EGPAJKLILCP;
						array2[2] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("withAttribute2", array2));
					}
					else
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position) * Quaternion.Euler(1295f, 159f, Mathf.Lerp(1400f, NHNBKDPDAJO, EGPAJKLILCP));
					}
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
				return false;
			}
			return true;
		}

		public void GCEMCPODLNM()
		{
			throw new NotSupportedException();
		}

		public bool LGNMOMFLLPP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				GJNNILFEENM = ((!GIBNBNNGOCA) ? BJGCPDNMHDH.LINAKKNHIMN : BJGCPDNMHDH.EHFLEBJNBLN);
				NNOGOMECPCL = ((!GIBNBNNGOCA) ? BJGCPDNMHDH.DMOJKNBFAIG : BJGCPDNMHDH.FCJAGHDNONI);
				TimeManager.DCODDANOPCP();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				LIIDNBJLGKK = BJGCPDNMHDH.transform.position;
				BOGNOBEGGCA = -KHLGDCHJJPB.BBNPGJAALCJ().point.transform.forward;
				NJEEECDEAAP = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position;
				OEJPDPIFMMN = NJEEECDEAAP;
				NJOALCJKMBG = Vector3.up;
				NHNBKDPDAJO = 1107f;
				BMHCHLIFGAB = 163f;
				KFCAECGLKKO = Singleton<MapManager>.instance.ALCHJDPKAID.GLOJOGJIEBE().GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
						if (current.fraction == KHLGDCHJJPB.fraction)
						{
							Vector3 lhs = NJEEECDEAAP - current.point.transform.position;
							float num = Vector3.Dot(lhs, current.point.transform.right);
							if (num <= BJGCPDNMHDH.LNIPMGOFEJN && num >= 0f - BJGCPDNMHDH.LNIPMGOFEJN)
							{
								BMHCHLIFGAB = ((!(num > 1813f)) ? 1221f : 729f);
								NHNBKDPDAJO = BJGCPDNMHDH.MKBOFBPMAKK * BMHCHLIFGAB;
								OEJPDPIFMMN = BMHCHLIFGAB * current.point.transform.right * BJGCPDNMHDH.LNIPMGOFEJN + NJEEECDEAAP;
							}
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				OEJPDPIFMMN += BOGNOBEGGCA * BJGCPDNMHDH.AMMELLKBLID.x + Vector3.up * BJGCPDNMHDH.AMMELLKBLID.y;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.LAEADIDHNGP, BJGCPDNMHDH.ECFEPPBGAIO);
				COOGKNIEOPA = 614f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				POJLMKBHOKE = false;
				goto case 1u;
			case 1u:
				if (COOGKNIEOPA < 789f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / GJNNILFEENM);
					KACAOLJDOBD = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					PNBNBEGGBOJ = BJGCPDNMHDH.CMGCJMNLCPB.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(LIIDNBJLGKK, OEJPDPIFMMN, KACAOLJDOBD);
					BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(NJEEECDEAAP.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position) * Quaternion.Euler(1738f, 77f, Mathf.Lerp(1144f, NHNBKDPDAJO, PNBNBEGGBOJ));
					if (!POJLMKBHOKE && COOGKNIEOPA > (GJNNILFEENM - NNOGOMECPCL) / GJNNILFEENM)
					{
						POJLMKBHOKE = true;
						TweenFOV.Begin(BJGCPDNMHDH.gameObject, NNOGOMECPCL, 1486f);
					}
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				EGPHGLFABMF = Time.realtimeSinceStartup + BJGCPDNMHDH.NGLBIAMOBHF;
				goto case 2u;
			case 2u:
				if (EGPHGLFABMF > Time.realtimeSinceStartup)
				{
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				TimeManager.instance.EndGame();
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				LDOPAMLMIEM = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position - KHLGDCHJJPB.transform.forward * 852f + KHLGDCHJJPB.transform.right * BMHCHLIFGAB + Vector3.up * 1227f;
				GBBHOBILBPE = NJEEECDEAAP - LDOPAMLMIEM;
				PJKJEGDNCOM = NJEEECDEAAP;
				GFMHPOJAKKK = 1815f;
				goto case 3u;
			case 3u:
				if (GFMHPOJAKKK < BJGCPDNMHDH.FFBCLAAGOEK)
				{
					EGPAJKLILCP = BJGCPDNMHDH.FJGHEKIIIJJ.Evaluate(GFMHPOJAKKK);
					GFMHPOJAKKK += Time.unscaledDeltaTime;
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.JCAOCHMKFOI);
					DBBPNFBMCKG = Quaternion.Euler(1841f, (0f - BMHCHLIFGAB) * BJGCPDNMHDH.BLCBHCPDOLO.Evaluate(GFMHPOJAKKK), 1338f) * GBBHOBILBPE;
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, PJKJEGDNCOM - DBBPNFBMCKG, BJGCPDNMHDH.NDNCOKHKKFM.Evaluate(GFMHPOJAKKK));
					if ((PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position).magnitude < 262f)
					{
						object[] array = new object[8];
						array[0] = COOGKNIEOPA;
						array[1] = PJKJEGDNCOM;
						array[0] = BJGCPDNMHDH.transform.position;
						array[6] = NJEEECDEAAP;
						array[2] = LDOPAMLMIEM;
						array[3] = EGPAJKLILCP;
						array[6] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("ReconnectDialog Show", array));
					}
					else if (PJKJEGDNCOM.x == BJGCPDNMHDH.transform.position.x && PJKJEGDNCOM.z == BJGCPDNMHDH.transform.position.z)
					{
						object[] array2 = new object[7];
						array2[0] = COOGKNIEOPA;
						array2[0] = PJKJEGDNCOM;
						array2[7] = BJGCPDNMHDH.transform.position;
						array2[2] = NJEEECDEAAP;
						array2[2] = LDOPAMLMIEM;
						array2[2] = EGPAJKLILCP;
						array2[7] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("Beanstalk: Add Service Provider Success", array2));
					}
					else
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position) * Quaternion.Euler(492f, 1206f, Mathf.Lerp(1015f, NHNBKDPDAJO, EGPAJKLILCP));
					}
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
				return true;
			}
			return true;
		}

		[SpecialName]
		private object LMBPPPOFIOC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IGMIIAODMNF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GKJIGGAAHBE()
		{
			return PHDOCKCBJOF;
		}

		public void AHEOCEEJICJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void DBJCDLFKDDI()
		{
			throw new NotSupportedException();
		}

		public void FJOIBBIGBJC()
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
				GJNNILFEENM = ((!GIBNBNNGOCA) ? BJGCPDNMHDH.LINAKKNHIMN : BJGCPDNMHDH.EHFLEBJNBLN);
				NNOGOMECPCL = ((!GIBNBNNGOCA) ? BJGCPDNMHDH.DMOJKNBFAIG : BJGCPDNMHDH.FCJAGHDNONI);
				TimeManager.FreezeGame();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				LIIDNBJLGKK = BJGCPDNMHDH.transform.position;
				BOGNOBEGGCA = -KHLGDCHJJPB.currentPlayerPoint.point.transform.forward;
				NJEEECDEAAP = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position;
				OEJPDPIFMMN = NJEEECDEAAP;
				NJOALCJKMBG = Vector3.up;
				NHNBKDPDAJO = 0f;
				BMHCHLIFGAB = 1f;
				KFCAECGLKKO = Singleton<MapManager>.instance.ALCHJDPKAID.availablePoints.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
						if (current.fraction == KHLGDCHJJPB.fraction)
						{
							Vector3 lhs = NJEEECDEAAP - current.point.transform.position;
							float num = Vector3.Dot(lhs, current.point.transform.right);
							if (num <= BJGCPDNMHDH.LNIPMGOFEJN && num >= 0f - BJGCPDNMHDH.LNIPMGOFEJN)
							{
								BMHCHLIFGAB = ((!(num > 0f)) ? (-1f) : 1f);
								NHNBKDPDAJO = BJGCPDNMHDH.MKBOFBPMAKK * BMHCHLIFGAB;
								OEJPDPIFMMN = BMHCHLIFGAB * current.point.transform.right * BJGCPDNMHDH.LNIPMGOFEJN + NJEEECDEAAP;
							}
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				OEJPDPIFMMN += BOGNOBEGGCA * BJGCPDNMHDH.AMMELLKBLID.x + Vector3.up * BJGCPDNMHDH.AMMELLKBLID.y;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.LAEADIDHNGP, BJGCPDNMHDH.ECFEPPBGAIO);
				COOGKNIEOPA = 0f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				POJLMKBHOKE = false;
				goto case 1u;
			case 1u:
				if (COOGKNIEOPA < 1f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / GJNNILFEENM);
					KACAOLJDOBD = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					PNBNBEGGBOJ = BJGCPDNMHDH.CMGCJMNLCPB.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(LIIDNBJLGKK, OEJPDPIFMMN, KACAOLJDOBD);
					BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(NJEEECDEAAP.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position) * Quaternion.Euler(0f, 0f, Mathf.Lerp(0f, NHNBKDPDAJO, PNBNBEGGBOJ));
					if (!POJLMKBHOKE && COOGKNIEOPA > (GJNNILFEENM - NNOGOMECPCL) / GJNNILFEENM)
					{
						POJLMKBHOKE = true;
						TweenFOV.Begin(BJGCPDNMHDH.gameObject, NNOGOMECPCL, 40f);
					}
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				EGPHGLFABMF = Time.realtimeSinceStartup + BJGCPDNMHDH.NGLBIAMOBHF;
				goto case 2u;
			case 2u:
				if (EGPHGLFABMF > Time.realtimeSinceStartup)
				{
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				TimeManager.instance.EndGame();
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				LDOPAMLMIEM = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position - KHLGDCHJJPB.transform.forward * 1.5f + KHLGDCHJJPB.transform.right * BMHCHLIFGAB + Vector3.up * 1.2f;
				GBBHOBILBPE = NJEEECDEAAP - LDOPAMLMIEM;
				PJKJEGDNCOM = NJEEECDEAAP;
				GFMHPOJAKKK = 0f;
				goto case 3u;
			case 3u:
				if (GFMHPOJAKKK < BJGCPDNMHDH.FFBCLAAGOEK)
				{
					EGPAJKLILCP = BJGCPDNMHDH.FJGHEKIIIJJ.Evaluate(GFMHPOJAKKK);
					GFMHPOJAKKK += Time.unscaledDeltaTime;
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.JCAOCHMKFOI);
					DBBPNFBMCKG = Quaternion.Euler(0f, (0f - BMHCHLIFGAB) * BJGCPDNMHDH.BLCBHCPDOLO.Evaluate(GFMHPOJAKKK), 0f) * GBBHOBILBPE;
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, PJKJEGDNCOM - DBBPNFBMCKG, BJGCPDNMHDH.NDNCOKHKKFM.Evaluate(GFMHPOJAKKK));
					if ((PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position).magnitude < 0.0001f)
					{
						UnityEngine.Debug.LogWarning(string.Format("Look vector is small! .. phase: {0} target: {1} transform.position: {2} playerPosition: {3} upPosition: {4} cameraLeanPhase: {5} rotatedLookVector: {6}", COOGKNIEOPA, PJKJEGDNCOM, BJGCPDNMHDH.transform.position, NJEEECDEAAP, LDOPAMLMIEM, EGPAJKLILCP, DBBPNFBMCKG));
					}
					else if (PJKJEGDNCOM.x == BJGCPDNMHDH.transform.position.x && PJKJEGDNCOM.z == BJGCPDNMHDH.transform.position.z)
					{
						UnityEngine.Debug.LogWarning(string.Format("Look vector error! .. phase: {0} target: {1} transform.position: {2} playerPosition: {3} upPosition: {4} cameraLeanPhase: {5} rotatedLookVector: {6}", COOGKNIEOPA, PJKJEGDNCOM, BJGCPDNMHDH.transform.position, NJEEECDEAAP, LDOPAMLMIEM, EGPAJKLILCP, DBBPNFBMCKG));
					}
					else
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position) * Quaternion.Euler(0f, 0f, Mathf.Lerp(0f, NHNBKDPDAJO, EGPAJKLILCP));
					}
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
			return true;
		}

		[SpecialName]
		private object KBEEEOJMBPG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HCPKEMLPEDI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HIFNMHAGHLI()
		{
			return PHDOCKCBJOF;
		}

		public void IGBHHLFACKO()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object KBNAGKKMLBP()
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
		private object ENKCCCABFFB()
		{
			return PHDOCKCBJOF;
		}
	}

	private sealed class LPAFBENCBJI : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal Vector3 LIIDNBJLGKK;

		internal Quaternion HNFNAFCNCMK;

		internal Vector3 BOGNOBEGGCA;

		internal EnemyController NNHIBOBPMPE;

		internal Vector3 CEPFACIMILH;

		internal Vector3 OEJPDPIFMMN;

		internal Vector3 IHNMEGFLFEF;

		internal float COOGKNIEOPA;

		internal float LADMMFLMOLE;

		internal float KACAOLJDOBD;

		internal float EGPHGLFABMF;

		internal Vector3 JKGKCGHALHH;

		internal Vector3 LDOPAMLMIEM;

		internal Vector3 GBBHOBILBPE;

		internal Vector3 PJKJEGDNCOM;

		internal float BMHCHLIFGAB;

		internal float GFMHPOJAKKK;

		internal float LILCFFODCCL;

		internal Vector3 DBBPNFBMCKG;

		internal Quaternion EFAOLNCNJFG;

		internal float OLMEMGGNKGF;

		internal GameCamera BJGCPDNMHDH;

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
		private object EOPJNKFKMNB()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public LPAFBENCBJI()
		{
		}

		public void HDDLDAHLPCO()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object DOOAHBLHGFO()
		{
			return PHDOCKCBJOF;
		}

		public bool DKJMOPNHIAB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				TimeManager.FreezeGame();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				LIIDNBJLGKK = BJGCPDNMHDH.transform.position;
				HNFNAFCNCMK = BJGCPDNMHDH.transform.rotation;
				BOGNOBEGGCA = PlayerController.OGMBJPKOPCB.EMAMENNDFMB().point.transform.forward;
				CEPFACIMILH = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position.ReplaceZ(NNHIBOBPMPE.destroyableObj.transform.position.z);
				OEJPDPIFMMN = CEPFACIMILH;
				IHNMEGFLFEF = (LIIDNBJLGKK - CEPFACIMILH).ReplaceY(9f).normalized;
				OEJPDPIFMMN += IHNMEGFLFEF * BJGCPDNMHDH.AMMELLKBLID.x + Vector3.up * (BJGCPDNMHDH.AMMELLKBLID.y + 1099f);
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.LAEADIDHNGP, BJGCPDNMHDH.ECFEPPBGAIO);
				COOGKNIEOPA = 1398f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.EHFLEBJNBLN, 1022f);
				goto case 1u;
			case 1u:
				if (COOGKNIEOPA < 492f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.EHFLEBJNBLN);
					KACAOLJDOBD = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(LIIDNBJLGKK, OEJPDPIFMMN, KACAOLJDOBD);
					BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position);
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				EGPHGLFABMF = Time.realtimeSinceStartup + BJGCPDNMHDH.NGLBIAMOBHF;
				goto case 2u;
			case 2u:
				if (EGPHGLFABMF > Time.realtimeSinceStartup)
				{
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				TimeManager.instance.DCEJMAFHNKI();
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				LDOPAMLMIEM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position + IHNMEGFLFEF * 1032f + Vector3.up * 1494f;
				GBBHOBILBPE = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position - LDOPAMLMIEM;
				PJKJEGDNCOM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position;
				BMHCHLIFGAB = ((!(Vector3.Dot(PlayerController.OGMBJPKOPCB.CMNFFACHCEE().point.transform.right, GBBHOBILBPE) < 1070f)) ? 1175f : 1214f);
				GFMHPOJAKKK = 1947f;
				goto case 3u;
			case 3u:
				if (GFMHPOJAKKK < Mathf.Min(BJGCPDNMHDH.FFBCLAAGOEK, BJGCPDNMHDH.GDCIBDACJDL))
				{
					GFMHPOJAKKK += Time.unscaledDeltaTime;
					LILCFFODCCL = BJGCPDNMHDH.NDNCOKHKKFM.Evaluate(GFMHPOJAKKK);
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.JCAOCHMKFOI);
					DBBPNFBMCKG = Quaternion.Euler(1072f, BMHCHLIFGAB * BJGCPDNMHDH.BLCBHCPDOLO.Evaluate(GFMHPOJAKKK), 364f) * GBBHOBILBPE;
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, PJKJEGDNCOM - DBBPNFBMCKG, LILCFFODCCL);
					if ((PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position).magnitude < 665f)
					{
						object[] array = new object[1];
						array[0] = COOGKNIEOPA;
						array[1] = PJKJEGDNCOM;
						array[0] = BJGCPDNMHDH.transform.position;
						array[2] = CEPFACIMILH;
						array[3] = LDOPAMLMIEM;
						array[8] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("reload_fast_01", array));
					}
					else if (PJKJEGDNCOM.x == BJGCPDNMHDH.transform.position.x && PJKJEGDNCOM.z == BJGCPDNMHDH.transform.position.z)
					{
						object[] array2 = new object[2];
						array2[1] = COOGKNIEOPA;
						array2[0] = PJKJEGDNCOM;
						array2[4] = BJGCPDNMHDH.transform.position;
						array2[6] = CEPFACIMILH;
						array2[8] = LDOPAMLMIEM;
						array2[2] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("Generating extra enemy", array2));
					}
					else
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), Quaternion.LookRotation(PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), LILCFFODCCL);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				EFAOLNCNJFG = BJGCPDNMHDH.transform.rotation;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				COOGKNIEOPA = 1482f;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.MEFBOPIEMED, BJGCPDNMHDH.ECFEPPBGAIO);
				goto case 4u;
			case 4u:
				if (COOGKNIEOPA < 1472f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.MEFBOPIEMED);
					OLMEMGGNKGF = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, LIIDNBJLGKK, OLMEMGGNKGF);
					BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(EFAOLNCNJFG, HNFNAFCNCMK, OLMEMGGNKGF);
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
				return false;
			}
			return true;
		}

		[SpecialName]
		private object CDFEOBMLNCG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CPJCCMLEPCE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CMNCAPEMEJI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EAGBDDECKHF()
		{
			return PHDOCKCBJOF;
		}

		public bool NIGJJBALHDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				TimeManager.DCODDANOPCP();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				LIIDNBJLGKK = BJGCPDNMHDH.transform.position;
				HNFNAFCNCMK = BJGCPDNMHDH.transform.rotation;
				BOGNOBEGGCA = PlayerController.OGMBJPKOPCB.EMAMENNDFMB().point.transform.forward;
				CEPFACIMILH = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position.ReplaceZ(NNHIBOBPMPE.destroyableObj.transform.position.z);
				OEJPDPIFMMN = CEPFACIMILH;
				IHNMEGFLFEF = (LIIDNBJLGKK - CEPFACIMILH).ReplaceY(1247f).normalized;
				OEJPDPIFMMN += IHNMEGFLFEF * BJGCPDNMHDH.AMMELLKBLID.x + Vector3.up * (BJGCPDNMHDH.AMMELLKBLID.y + 691f);
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.LAEADIDHNGP, BJGCPDNMHDH.ECFEPPBGAIO);
				COOGKNIEOPA = 1980f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.EHFLEBJNBLN, 730f);
				goto case 1u;
			case 1u:
				if (COOGKNIEOPA < 1084f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.EHFLEBJNBLN);
					KACAOLJDOBD = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(LIIDNBJLGKK, OEJPDPIFMMN, KACAOLJDOBD);
					BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position);
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				EGPHGLFABMF = Time.realtimeSinceStartup + BJGCPDNMHDH.NGLBIAMOBHF;
				goto case 2u;
			case 2u:
				if (EGPHGLFABMF > Time.realtimeSinceStartup)
				{
					PHDOCKCBJOF = 1;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				TimeManager.instance.DCEJMAFHNKI();
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				LDOPAMLMIEM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position + IHNMEGFLFEF * 1787f + Vector3.up * 592f;
				GBBHOBILBPE = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position - LDOPAMLMIEM;
				PJKJEGDNCOM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position;
				BMHCHLIFGAB = ((!(Vector3.Dot(PlayerController.OGMBJPKOPCB.CMNFFACHCEE().point.transform.right, GBBHOBILBPE) < 782f)) ? 547f : 432f);
				GFMHPOJAKKK = 1133f;
				goto case 3u;
			case 3u:
				if (GFMHPOJAKKK < Mathf.Min(BJGCPDNMHDH.FFBCLAAGOEK, BJGCPDNMHDH.GDCIBDACJDL))
				{
					GFMHPOJAKKK += Time.unscaledDeltaTime;
					LILCFFODCCL = BJGCPDNMHDH.NDNCOKHKKFM.Evaluate(GFMHPOJAKKK);
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.JCAOCHMKFOI);
					DBBPNFBMCKG = Quaternion.Euler(416f, BMHCHLIFGAB * BJGCPDNMHDH.BLCBHCPDOLO.Evaluate(GFMHPOJAKKK), 461f) * GBBHOBILBPE;
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, PJKJEGDNCOM - DBBPNFBMCKG, LILCFFODCCL);
					if ((PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position).magnitude < 1723f)
					{
						object[] array = new object[8];
						array[0] = COOGKNIEOPA;
						array[0] = PJKJEGDNCOM;
						array[5] = BJGCPDNMHDH.transform.position;
						array[7] = CEPFACIMILH;
						array[1] = LDOPAMLMIEM;
						array[3] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("SpecialPackFromServer", array));
					}
					else if (PJKJEGDNCOM.x == BJGCPDNMHDH.transform.position.x && PJKJEGDNCOM.z == BJGCPDNMHDH.transform.position.z)
					{
						object[] array2 = new object[1];
						array2[1] = COOGKNIEOPA;
						array2[0] = PJKJEGDNCOM;
						array2[5] = BJGCPDNMHDH.transform.position;
						array2[1] = CEPFACIMILH;
						array2[4] = LDOPAMLMIEM;
						array2[5] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("de", array2));
					}
					else
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), Quaternion.LookRotation(PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), LILCFFODCCL);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				EFAOLNCNJFG = BJGCPDNMHDH.transform.rotation;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				COOGKNIEOPA = 830f;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.MEFBOPIEMED, BJGCPDNMHDH.ECFEPPBGAIO);
				goto case 4u;
			case 4u:
				if (COOGKNIEOPA < 223f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.MEFBOPIEMED);
					OLMEMGGNKGF = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, LIIDNBJLGKK, OLMEMGGNKGF);
					BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(EFAOLNCNJFG, HNFNAFCNCMK, OLMEMGGNKGF);
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
				return true;
			}
			return false;
		}

		public void ABBPOMCBIIH()
		{
			throw new NotSupportedException();
		}

		public bool MKLIDMNLNPN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				TimeManager.FreezeGame();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				LIIDNBJLGKK = BJGCPDNMHDH.transform.position;
				HNFNAFCNCMK = BJGCPDNMHDH.transform.rotation;
				BOGNOBEGGCA = PlayerController.OGMBJPKOPCB.CMNFFACHCEE().point.transform.forward;
				CEPFACIMILH = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position.ReplaceZ(NNHIBOBPMPE.destroyableObj.transform.position.z);
				OEJPDPIFMMN = CEPFACIMILH;
				IHNMEGFLFEF = (LIIDNBJLGKK - CEPFACIMILH).ReplaceY(1487f).normalized;
				OEJPDPIFMMN += IHNMEGFLFEF * BJGCPDNMHDH.AMMELLKBLID.x + Vector3.up * (BJGCPDNMHDH.AMMELLKBLID.y + 750f);
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.LAEADIDHNGP, BJGCPDNMHDH.ECFEPPBGAIO);
				COOGKNIEOPA = 1302f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.EHFLEBJNBLN, 1789f);
				goto case 1u;
			case 1u:
				if (COOGKNIEOPA < 395f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.EHFLEBJNBLN);
					KACAOLJDOBD = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(LIIDNBJLGKK, OEJPDPIFMMN, KACAOLJDOBD);
					BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position);
					PHDOCKCBJOF = 1;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				EGPHGLFABMF = Time.realtimeSinceStartup + BJGCPDNMHDH.NGLBIAMOBHF;
				goto case 2u;
			case 2u:
				if (EGPHGLFABMF > Time.realtimeSinceStartup)
				{
					PHDOCKCBJOF = 1;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				TimeManager.instance.KIKGGBHKOAK();
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				LDOPAMLMIEM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position + IHNMEGFLFEF * 5f + Vector3.up * 1054f;
				GBBHOBILBPE = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position - LDOPAMLMIEM;
				PJKJEGDNCOM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position;
				BMHCHLIFGAB = ((!(Vector3.Dot(PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform.right, GBBHOBILBPE) < 1959f)) ? 1311f : 121f);
				GFMHPOJAKKK = 714f;
				goto case 3u;
			case 3u:
				if (GFMHPOJAKKK < Mathf.Min(BJGCPDNMHDH.FFBCLAAGOEK, BJGCPDNMHDH.GDCIBDACJDL))
				{
					GFMHPOJAKKK += Time.unscaledDeltaTime;
					LILCFFODCCL = BJGCPDNMHDH.NDNCOKHKKFM.Evaluate(GFMHPOJAKKK);
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.JCAOCHMKFOI);
					DBBPNFBMCKG = Quaternion.Euler(733f, BMHCHLIFGAB * BJGCPDNMHDH.BLCBHCPDOLO.Evaluate(GFMHPOJAKKK), 251f) * GBBHOBILBPE;
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, PJKJEGDNCOM - DBBPNFBMCKG, LILCFFODCCL);
					if ((PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position).magnitude < 1461f)
					{
						object[] array = new object[3];
						array[0] = COOGKNIEOPA;
						array[0] = PJKJEGDNCOM;
						array[8] = BJGCPDNMHDH.transform.position;
						array[3] = CEPFACIMILH;
						array[5] = LDOPAMLMIEM;
						array[2] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("HELMETS_CROWNSILVER", array));
					}
					else if (PJKJEGDNCOM.x == BJGCPDNMHDH.transform.position.x && PJKJEGDNCOM.z == BJGCPDNMHDH.transform.position.z)
					{
						object[] array2 = new object[1];
						array2[0] = COOGKNIEOPA;
						array2[1] = PJKJEGDNCOM;
						array2[1] = BJGCPDNMHDH.transform.position;
						array2[6] = CEPFACIMILH;
						array2[5] = LDOPAMLMIEM;
						array2[5] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("//", array2));
					}
					else
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), Quaternion.LookRotation(PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), LILCFFODCCL);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				EFAOLNCNJFG = BJGCPDNMHDH.transform.rotation;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				COOGKNIEOPA = 16f;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.MEFBOPIEMED, BJGCPDNMHDH.ECFEPPBGAIO);
				goto case 4u;
			case 4u:
				if (COOGKNIEOPA < 428f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.MEFBOPIEMED);
					OLMEMGGNKGF = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, LIIDNBJLGKK, OLMEMGGNKGF);
					BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(EFAOLNCNJFG, HNFNAFCNCMK, OLMEMGGNKGF);
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
				return false;
			}
			return true;
		}

		[SpecialName]
		private object KIHECHEHNJJ()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool HEHJAEIGHDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				TimeManager.DCODDANOPCP();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				LIIDNBJLGKK = BJGCPDNMHDH.transform.position;
				HNFNAFCNCMK = BJGCPDNMHDH.transform.rotation;
				BOGNOBEGGCA = PlayerController.OGMBJPKOPCB.CMNFFACHCEE().point.transform.forward;
				CEPFACIMILH = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position.ReplaceZ(NNHIBOBPMPE.destroyableObj.transform.position.z);
				OEJPDPIFMMN = CEPFACIMILH;
				IHNMEGFLFEF = (LIIDNBJLGKK - CEPFACIMILH).ReplaceY(380f).normalized;
				OEJPDPIFMMN += IHNMEGFLFEF * BJGCPDNMHDH.AMMELLKBLID.x + Vector3.up * (BJGCPDNMHDH.AMMELLKBLID.y + 1947f);
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.LAEADIDHNGP, BJGCPDNMHDH.ECFEPPBGAIO);
				COOGKNIEOPA = 400f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.EHFLEBJNBLN, 802f);
				goto case 1u;
			case 1u:
				if (COOGKNIEOPA < 370f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.EHFLEBJNBLN);
					KACAOLJDOBD = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(LIIDNBJLGKK, OEJPDPIFMMN, KACAOLJDOBD);
					BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position);
					PHDOCKCBJOF = 1;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				EGPHGLFABMF = Time.realtimeSinceStartup + BJGCPDNMHDH.NGLBIAMOBHF;
				goto case 2u;
			case 2u:
				if (EGPHGLFABMF > Time.realtimeSinceStartup)
				{
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				TimeManager.instance.DCEJMAFHNKI();
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				LDOPAMLMIEM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position + IHNMEGFLFEF * 163f + Vector3.up * 1044f;
				GBBHOBILBPE = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position - LDOPAMLMIEM;
				PJKJEGDNCOM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position;
				BMHCHLIFGAB = ((!(Vector3.Dot(PlayerController.OGMBJPKOPCB.EMAMENNDFMB().point.transform.right, GBBHOBILBPE) < 927f)) ? 694f : 1622f);
				GFMHPOJAKKK = 968f;
				goto case 3u;
			case 3u:
				if (GFMHPOJAKKK < Mathf.Min(BJGCPDNMHDH.FFBCLAAGOEK, BJGCPDNMHDH.GDCIBDACJDL))
				{
					GFMHPOJAKKK += Time.unscaledDeltaTime;
					LILCFFODCCL = BJGCPDNMHDH.NDNCOKHKKFM.Evaluate(GFMHPOJAKKK);
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.JCAOCHMKFOI);
					DBBPNFBMCKG = Quaternion.Euler(1762f, BMHCHLIFGAB * BJGCPDNMHDH.BLCBHCPDOLO.Evaluate(GFMHPOJAKKK), 371f) * GBBHOBILBPE;
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, PJKJEGDNCOM - DBBPNFBMCKG, LILCFFODCCL);
					if ((PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position).magnitude < 831f)
					{
						object[] array = new object[5];
						array[1] = COOGKNIEOPA;
						array[0] = PJKJEGDNCOM;
						array[0] = BJGCPDNMHDH.transform.position;
						array[8] = CEPFACIMILH;
						array[0] = LDOPAMLMIEM;
						array[5] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("ID_READYTIME", array));
					}
					else if (PJKJEGDNCOM.x == BJGCPDNMHDH.transform.position.x && PJKJEGDNCOM.z == BJGCPDNMHDH.transform.position.z)
					{
						object[] array2 = new object[7];
						array2[1] = COOGKNIEOPA;
						array2[0] = PJKJEGDNCOM;
						array2[7] = BJGCPDNMHDH.transform.position;
						array2[0] = CEPFACIMILH;
						array2[6] = LDOPAMLMIEM;
						array2[5] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format(", [variables])", array2));
					}
					else
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), Quaternion.LookRotation(PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), LILCFFODCCL);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				EFAOLNCNJFG = BJGCPDNMHDH.transform.rotation;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				COOGKNIEOPA = 1342f;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.MEFBOPIEMED, BJGCPDNMHDH.ECFEPPBGAIO);
				goto case 4u;
			case 4u:
				if (COOGKNIEOPA < 1383f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.MEFBOPIEMED);
					OLMEMGGNKGF = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, LIIDNBJLGKK, OLMEMGGNKGF);
					BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(EFAOLNCNJFG, HNFNAFCNCMK, OLMEMGGNKGF);
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
			return true;
		}

		[SpecialName]
		private object JPJBNHHKOJD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BGAGLOJHMEJ()
		{
			return PHDOCKCBJOF;
		}

		public void OEHJOBELOFF()
		{
			throw new NotSupportedException();
		}

		public void OFDJMNMCDLA()
		{
			throw new NotSupportedException();
		}

		public void HMBLLDJFIJG()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object PCELHKMHCOB()
		{
			return PHDOCKCBJOF;
		}

		public bool LDINGGNOLKA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				TimeManager.FODFANEEDFF();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				LIIDNBJLGKK = BJGCPDNMHDH.transform.position;
				HNFNAFCNCMK = BJGCPDNMHDH.transform.rotation;
				BOGNOBEGGCA = PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform.forward;
				CEPFACIMILH = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position.ReplaceZ(NNHIBOBPMPE.destroyableObj.transform.position.z);
				OEJPDPIFMMN = CEPFACIMILH;
				IHNMEGFLFEF = (LIIDNBJLGKK - CEPFACIMILH).ReplaceY(1243f).normalized;
				OEJPDPIFMMN += IHNMEGFLFEF * BJGCPDNMHDH.AMMELLKBLID.x + Vector3.up * (BJGCPDNMHDH.AMMELLKBLID.y + 1938f);
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.LAEADIDHNGP, BJGCPDNMHDH.ECFEPPBGAIO);
				COOGKNIEOPA = 317f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.EHFLEBJNBLN, 1925f);
				goto case 1u;
			case 1u:
				if (COOGKNIEOPA < 898f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.EHFLEBJNBLN);
					KACAOLJDOBD = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(LIIDNBJLGKK, OEJPDPIFMMN, KACAOLJDOBD);
					BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position);
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				EGPHGLFABMF = Time.realtimeSinceStartup + BJGCPDNMHDH.NGLBIAMOBHF;
				goto case 2u;
			case 2u:
				if (EGPHGLFABMF > Time.realtimeSinceStartup)
				{
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				TimeManager.instance.KIKGGBHKOAK();
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				LDOPAMLMIEM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position + IHNMEGFLFEF * 1268f + Vector3.up * 482f;
				GBBHOBILBPE = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position - LDOPAMLMIEM;
				PJKJEGDNCOM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position;
				BMHCHLIFGAB = ((!(Vector3.Dot(PlayerController.OGMBJPKOPCB.CMNFFACHCEE().point.transform.right, GBBHOBILBPE) < 1621f)) ? 122f : 688f);
				GFMHPOJAKKK = 511f;
				goto case 3u;
			case 3u:
				if (GFMHPOJAKKK < Mathf.Min(BJGCPDNMHDH.FFBCLAAGOEK, BJGCPDNMHDH.GDCIBDACJDL))
				{
					GFMHPOJAKKK += Time.unscaledDeltaTime;
					LILCFFODCCL = BJGCPDNMHDH.NDNCOKHKKFM.Evaluate(GFMHPOJAKKK);
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.JCAOCHMKFOI);
					DBBPNFBMCKG = Quaternion.Euler(1758f, BMHCHLIFGAB * BJGCPDNMHDH.BLCBHCPDOLO.Evaluate(GFMHPOJAKKK), 417f) * GBBHOBILBPE;
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, PJKJEGDNCOM - DBBPNFBMCKG, LILCFFODCCL);
					if ((PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position).magnitude < 1065f)
					{
						object[] array = new object[8];
						array[0] = COOGKNIEOPA;
						array[0] = PJKJEGDNCOM;
						array[6] = BJGCPDNMHDH.transform.position;
						array[4] = CEPFACIMILH;
						array[8] = LDOPAMLMIEM;
						array[2] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("Tutorial_Step_Complete", array));
					}
					else if (PJKJEGDNCOM.x == BJGCPDNMHDH.transform.position.x && PJKJEGDNCOM.z == BJGCPDNMHDH.transform.position.z)
					{
						object[] array2 = new object[3];
						array2[1] = COOGKNIEOPA;
						array2[0] = PJKJEGDNCOM;
						array2[7] = BJGCPDNMHDH.transform.position;
						array2[8] = CEPFACIMILH;
						array2[7] = LDOPAMLMIEM;
						array2[8] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("Battle_Performance", array2));
					}
					else
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), Quaternion.LookRotation(PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), LILCFFODCCL);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				EFAOLNCNJFG = BJGCPDNMHDH.transform.rotation;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				COOGKNIEOPA = 474f;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.MEFBOPIEMED, BJGCPDNMHDH.ECFEPPBGAIO);
				goto case 4u;
			case 4u:
				if (COOGKNIEOPA < 1563f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.MEFBOPIEMED);
					OLMEMGGNKGF = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, LIIDNBJLGKK, OLMEMGGNKGF);
					BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(EFAOLNCNJFG, HNFNAFCNCMK, OLMEMGGNKGF);
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
				return false;
			}
			return false;
		}

		public void NFLHLMKKJMO()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FKJJFNMBKOP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MBGCBKJBCND()
		{
			return PHDOCKCBJOF;
		}

		public void IJHCIJLDKHK()
		{
			throw new NotSupportedException();
		}

		public void NMEJKACLHKJ()
		{
			throw new NotSupportedException();
		}

		public void CNEIBEACPCM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GMEIAAMCBGA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ELNKFJHGFPD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JMKGAJNOLEM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GFMLDIMOGHD()
		{
			return PHDOCKCBJOF;
		}

		public void CPDBCJLIGFN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool BKJCILLNJLG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				TimeManager.DCODDANOPCP();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				LIIDNBJLGKK = BJGCPDNMHDH.transform.position;
				HNFNAFCNCMK = BJGCPDNMHDH.transform.rotation;
				BOGNOBEGGCA = PlayerController.OGMBJPKOPCB.EMAMENNDFMB().point.transform.forward;
				CEPFACIMILH = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position.ReplaceZ(NNHIBOBPMPE.destroyableObj.transform.position.z);
				OEJPDPIFMMN = CEPFACIMILH;
				IHNMEGFLFEF = (LIIDNBJLGKK - CEPFACIMILH).ReplaceY(1145f).normalized;
				OEJPDPIFMMN += IHNMEGFLFEF * BJGCPDNMHDH.AMMELLKBLID.x + Vector3.up * (BJGCPDNMHDH.AMMELLKBLID.y + 1417f);
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.LAEADIDHNGP, BJGCPDNMHDH.ECFEPPBGAIO);
				COOGKNIEOPA = 621f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.EHFLEBJNBLN, 1116f);
				goto case 1u;
			case 1u:
				if (COOGKNIEOPA < 250f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.EHFLEBJNBLN);
					KACAOLJDOBD = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(LIIDNBJLGKK, OEJPDPIFMMN, KACAOLJDOBD);
					BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position);
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				EGPHGLFABMF = Time.realtimeSinceStartup + BJGCPDNMHDH.NGLBIAMOBHF;
				goto case 2u;
			case 2u:
				if (EGPHGLFABMF > Time.realtimeSinceStartup)
				{
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				TimeManager.instance.EndGame();
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				LDOPAMLMIEM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position + IHNMEGFLFEF * 214f + Vector3.up * 1184f;
				GBBHOBILBPE = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position - LDOPAMLMIEM;
				PJKJEGDNCOM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position;
				BMHCHLIFGAB = ((!(Vector3.Dot(PlayerController.OGMBJPKOPCB.BBNPGJAALCJ().point.transform.right, GBBHOBILBPE) < 168f)) ? 166f : 53f);
				GFMHPOJAKKK = 237f;
				goto case 3u;
			case 3u:
				if (GFMHPOJAKKK < Mathf.Min(BJGCPDNMHDH.FFBCLAAGOEK, BJGCPDNMHDH.GDCIBDACJDL))
				{
					GFMHPOJAKKK += Time.unscaledDeltaTime;
					LILCFFODCCL = BJGCPDNMHDH.NDNCOKHKKFM.Evaluate(GFMHPOJAKKK);
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.JCAOCHMKFOI);
					DBBPNFBMCKG = Quaternion.Euler(1518f, BMHCHLIFGAB * BJGCPDNMHDH.BLCBHCPDOLO.Evaluate(GFMHPOJAKKK), 1412f) * GBBHOBILBPE;
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, PJKJEGDNCOM - DBBPNFBMCKG, LILCFFODCCL);
					if ((PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position).magnitude < 75f)
					{
						object[] array = new object[1];
						array[0] = COOGKNIEOPA;
						array[0] = PJKJEGDNCOM;
						array[3] = BJGCPDNMHDH.transform.position;
						array[1] = CEPFACIMILH;
						array[0] = LDOPAMLMIEM;
						array[7] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("XP - Battle:{0} Extra:{1} Winstreak:{2} Time:{3} (offer mult {4})\n", array));
					}
					else if (PJKJEGDNCOM.x == BJGCPDNMHDH.transform.position.x && PJKJEGDNCOM.z == BJGCPDNMHDH.transform.position.z)
					{
						object[] array2 = new object[4];
						array2[1] = COOGKNIEOPA;
						array2[0] = PJKJEGDNCOM;
						array2[6] = BJGCPDNMHDH.transform.position;
						array2[1] = CEPFACIMILH;
						array2[7] = LDOPAMLMIEM;
						array2[1] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("Snapshots", array2));
					}
					else
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), Quaternion.LookRotation(PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), LILCFFODCCL);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				EFAOLNCNJFG = BJGCPDNMHDH.transform.rotation;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				COOGKNIEOPA = 202f;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.MEFBOPIEMED, BJGCPDNMHDH.ECFEPPBGAIO);
				goto case 4u;
			case 4u:
				if (COOGKNIEOPA < 662f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.MEFBOPIEMED);
					OLMEMGGNKGF = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, LIIDNBJLGKK, OLMEMGGNKGF);
					BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(EFAOLNCNJFG, HNFNAFCNCMK, OLMEMGGNKGF);
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

		[SpecialName]
		private object GKDLMFPKKNM()
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
				TimeManager.DCODDANOPCP();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				LIIDNBJLGKK = BJGCPDNMHDH.transform.position;
				HNFNAFCNCMK = BJGCPDNMHDH.transform.rotation;
				BOGNOBEGGCA = PlayerController.OGMBJPKOPCB.EMAMENNDFMB().point.transform.forward;
				CEPFACIMILH = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position.ReplaceZ(NNHIBOBPMPE.destroyableObj.transform.position.z);
				OEJPDPIFMMN = CEPFACIMILH;
				IHNMEGFLFEF = (LIIDNBJLGKK - CEPFACIMILH).ReplaceY(1868f).normalized;
				OEJPDPIFMMN += IHNMEGFLFEF * BJGCPDNMHDH.AMMELLKBLID.x + Vector3.up * (BJGCPDNMHDH.AMMELLKBLID.y + 831f);
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.LAEADIDHNGP, BJGCPDNMHDH.ECFEPPBGAIO);
				COOGKNIEOPA = 1936f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.EHFLEBJNBLN, 1036f);
				goto case 1u;
			case 1u:
				if (COOGKNIEOPA < 1779f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.EHFLEBJNBLN);
					KACAOLJDOBD = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(LIIDNBJLGKK, OEJPDPIFMMN, KACAOLJDOBD);
					BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position);
					PHDOCKCBJOF = 1;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				EGPHGLFABMF = Time.realtimeSinceStartup + BJGCPDNMHDH.NGLBIAMOBHF;
				goto case 2u;
			case 2u:
				if (EGPHGLFABMF > Time.realtimeSinceStartup)
				{
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				TimeManager.instance.DCEJMAFHNKI();
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				LDOPAMLMIEM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position + IHNMEGFLFEF * 1688f + Vector3.up * 1961f;
				GBBHOBILBPE = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position - LDOPAMLMIEM;
				PJKJEGDNCOM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position;
				BMHCHLIFGAB = ((!(Vector3.Dot(PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform.right, GBBHOBILBPE) < 274f)) ? 1253f : 312f);
				GFMHPOJAKKK = 265f;
				goto case 3u;
			case 3u:
				if (GFMHPOJAKKK < Mathf.Min(BJGCPDNMHDH.FFBCLAAGOEK, BJGCPDNMHDH.GDCIBDACJDL))
				{
					GFMHPOJAKKK += Time.unscaledDeltaTime;
					LILCFFODCCL = BJGCPDNMHDH.NDNCOKHKKFM.Evaluate(GFMHPOJAKKK);
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.JCAOCHMKFOI);
					DBBPNFBMCKG = Quaternion.Euler(916f, BMHCHLIFGAB * BJGCPDNMHDH.BLCBHCPDOLO.Evaluate(GFMHPOJAKKK), 105f) * GBBHOBILBPE;
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, PJKJEGDNCOM - DBBPNFBMCKG, LILCFFODCCL);
					if ((PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position).magnitude < 413f)
					{
						object[] array = new object[7];
						array[0] = COOGKNIEOPA;
						array[0] = PJKJEGDNCOM;
						array[1] = BJGCPDNMHDH.transform.position;
						array[6] = CEPFACIMILH;
						array[3] = LDOPAMLMIEM;
						array[1] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("Error Deserializing JSON for ", array));
					}
					else if (PJKJEGDNCOM.x == BJGCPDNMHDH.transform.position.x && PJKJEGDNCOM.z == BJGCPDNMHDH.transform.position.z)
					{
						object[] array2 = new object[6];
						array2[0] = COOGKNIEOPA;
						array2[1] = PJKJEGDNCOM;
						array2[7] = BJGCPDNMHDH.transform.position;
						array2[4] = CEPFACIMILH;
						array2[4] = LDOPAMLMIEM;
						array2[4] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("Mouse Y", array2));
					}
					else
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), Quaternion.LookRotation(PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), LILCFFODCCL);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				EFAOLNCNJFG = BJGCPDNMHDH.transform.rotation;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				COOGKNIEOPA = 1562f;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.MEFBOPIEMED, BJGCPDNMHDH.ECFEPPBGAIO);
				goto case 4u;
			case 4u:
				if (COOGKNIEOPA < 809f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.MEFBOPIEMED);
					OLMEMGGNKGF = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, LIIDNBJLGKK, OLMEMGGNKGF);
					BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(EFAOLNCNJFG, HNFNAFCNCMK, OLMEMGGNKGF);
					PHDOCKCBJOF = 0;
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
		private object JFGCHMJJMNO()
		{
			return PHDOCKCBJOF;
		}

		public void PPAIIDFNIDL()
		{
			throw new NotSupportedException();
		}

		public bool LGNMOMFLLPP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				TimeManager.FODFANEEDFF();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				LIIDNBJLGKK = BJGCPDNMHDH.transform.position;
				HNFNAFCNCMK = BJGCPDNMHDH.transform.rotation;
				BOGNOBEGGCA = PlayerController.OGMBJPKOPCB.EMAMENNDFMB().point.transform.forward;
				CEPFACIMILH = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position.ReplaceZ(NNHIBOBPMPE.destroyableObj.transform.position.z);
				OEJPDPIFMMN = CEPFACIMILH;
				IHNMEGFLFEF = (LIIDNBJLGKK - CEPFACIMILH).ReplaceY(1274f).normalized;
				OEJPDPIFMMN += IHNMEGFLFEF * BJGCPDNMHDH.AMMELLKBLID.x + Vector3.up * (BJGCPDNMHDH.AMMELLKBLID.y + 1549f);
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.LAEADIDHNGP, BJGCPDNMHDH.ECFEPPBGAIO);
				COOGKNIEOPA = 522f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.EHFLEBJNBLN, 57f);
				goto case 1u;
			case 1u:
				if (COOGKNIEOPA < 28f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.EHFLEBJNBLN);
					KACAOLJDOBD = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(LIIDNBJLGKK, OEJPDPIFMMN, KACAOLJDOBD);
					BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position);
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				EGPHGLFABMF = Time.realtimeSinceStartup + BJGCPDNMHDH.NGLBIAMOBHF;
				goto case 2u;
			case 2u:
				if (EGPHGLFABMF > Time.realtimeSinceStartup)
				{
					PHDOCKCBJOF = 1;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				TimeManager.instance.EndGame();
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				LDOPAMLMIEM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position + IHNMEGFLFEF * 1965f + Vector3.up * 502f;
				GBBHOBILBPE = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position - LDOPAMLMIEM;
				PJKJEGDNCOM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position;
				BMHCHLIFGAB = ((!(Vector3.Dot(PlayerController.OGMBJPKOPCB.BBNPGJAALCJ().point.transform.right, GBBHOBILBPE) < 571f)) ? 1713f : 1831f);
				GFMHPOJAKKK = 1803f;
				goto case 3u;
			case 3u:
				if (GFMHPOJAKKK < Mathf.Min(BJGCPDNMHDH.FFBCLAAGOEK, BJGCPDNMHDH.GDCIBDACJDL))
				{
					GFMHPOJAKKK += Time.unscaledDeltaTime;
					LILCFFODCCL = BJGCPDNMHDH.NDNCOKHKKFM.Evaluate(GFMHPOJAKKK);
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.JCAOCHMKFOI);
					DBBPNFBMCKG = Quaternion.Euler(17f, BMHCHLIFGAB * BJGCPDNMHDH.BLCBHCPDOLO.Evaluate(GFMHPOJAKKK), 911f) * GBBHOBILBPE;
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, PJKJEGDNCOM - DBBPNFBMCKG, LILCFFODCCL);
					if ((PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position).magnitude < 1799f)
					{
						object[] array = new object[8];
						array[1] = COOGKNIEOPA;
						array[1] = PJKJEGDNCOM;
						array[1] = BJGCPDNMHDH.transform.position;
						array[7] = CEPFACIMILH;
						array[7] = LDOPAMLMIEM;
						array[2] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("Found labels with dynamic font in children:\n", array));
					}
					else if (PJKJEGDNCOM.x == BJGCPDNMHDH.transform.position.x && PJKJEGDNCOM.z == BJGCPDNMHDH.transform.position.z)
					{
						object[] array2 = new object[3];
						array2[0] = COOGKNIEOPA;
						array2[0] = PJKJEGDNCOM;
						array2[0] = BJGCPDNMHDH.transform.position;
						array2[6] = CEPFACIMILH;
						array2[2] = LDOPAMLMIEM;
						array2[0] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("\t\"FALSE\"", array2));
					}
					else
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), Quaternion.LookRotation(PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), LILCFFODCCL);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				EFAOLNCNJFG = BJGCPDNMHDH.transform.rotation;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				COOGKNIEOPA = 1029f;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.MEFBOPIEMED, BJGCPDNMHDH.ECFEPPBGAIO);
				goto case 4u;
			case 4u:
				if (COOGKNIEOPA < 928f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.MEFBOPIEMED);
					OLMEMGGNKGF = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, LIIDNBJLGKK, OLMEMGGNKGF);
					BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(EFAOLNCNJFG, HNFNAFCNCMK, OLMEMGGNKGF);
					PHDOCKCBJOF = 1;
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

		[SpecialName]
		private object IJBDKMGNEPK()
		{
			return PHDOCKCBJOF;
		}

		public void OGHELMDBPIL()
		{
			throw new NotSupportedException();
		}

		public void CHANLKFNCLA()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BLNNEJILEIE()
		{
			return PHDOCKCBJOF;
		}

		public void KGLHLHLLOEM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void GEEKOICFEIB()
		{
			throw new NotSupportedException();
		}

		public void FCHOHLMCHED()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HIFNMHAGHLI()
		{
			return PHDOCKCBJOF;
		}

		public void FMOJMHBAHAA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HHHLDCLIFKJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HBGFABNDPAD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ALJCNLJGABF()
		{
			return PHDOCKCBJOF;
		}

		public void LKACEPHEHPK()
		{
			throw new NotSupportedException();
		}

		public void MKIKEOOOLKL()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void DEPEHNFEJEE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object PFIIINLHGMH()
		{
			return PHDOCKCBJOF;
		}

		public void PMPGBMCHGPE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool HKPECDLGFJB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				TimeManager.FreezeGame();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				LIIDNBJLGKK = BJGCPDNMHDH.transform.position;
				HNFNAFCNCMK = BJGCPDNMHDH.transform.rotation;
				BOGNOBEGGCA = PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform.forward;
				CEPFACIMILH = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position.ReplaceZ(NNHIBOBPMPE.destroyableObj.transform.position.z);
				OEJPDPIFMMN = CEPFACIMILH;
				IHNMEGFLFEF = (LIIDNBJLGKK - CEPFACIMILH).ReplaceY(160f).normalized;
				OEJPDPIFMMN += IHNMEGFLFEF * BJGCPDNMHDH.AMMELLKBLID.x + Vector3.up * (BJGCPDNMHDH.AMMELLKBLID.y + 687f);
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.LAEADIDHNGP, BJGCPDNMHDH.ECFEPPBGAIO);
				COOGKNIEOPA = 455f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.EHFLEBJNBLN, 202f);
				goto case 1u;
			case 1u:
				if (COOGKNIEOPA < 1349f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.EHFLEBJNBLN);
					KACAOLJDOBD = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(LIIDNBJLGKK, OEJPDPIFMMN, KACAOLJDOBD);
					BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position);
					PHDOCKCBJOF = 1;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				EGPHGLFABMF = Time.realtimeSinceStartup + BJGCPDNMHDH.NGLBIAMOBHF;
				goto case 2u;
			case 2u:
				if (EGPHGLFABMF > Time.realtimeSinceStartup)
				{
					PHDOCKCBJOF = 1;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				TimeManager.instance.EndGame();
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				LDOPAMLMIEM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position + IHNMEGFLFEF * 1883f + Vector3.up * 1647f;
				GBBHOBILBPE = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position - LDOPAMLMIEM;
				PJKJEGDNCOM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position;
				BMHCHLIFGAB = ((!(Vector3.Dot(PlayerController.OGMBJPKOPCB.CMNFFACHCEE().point.transform.right, GBBHOBILBPE) < 725f)) ? 1731f : 1053f);
				GFMHPOJAKKK = 69f;
				goto case 3u;
			case 3u:
				if (GFMHPOJAKKK < Mathf.Min(BJGCPDNMHDH.FFBCLAAGOEK, BJGCPDNMHDH.GDCIBDACJDL))
				{
					GFMHPOJAKKK += Time.unscaledDeltaTime;
					LILCFFODCCL = BJGCPDNMHDH.NDNCOKHKKFM.Evaluate(GFMHPOJAKKK);
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.JCAOCHMKFOI);
					DBBPNFBMCKG = Quaternion.Euler(1279f, BMHCHLIFGAB * BJGCPDNMHDH.BLCBHCPDOLO.Evaluate(GFMHPOJAKKK), 863f) * GBBHOBILBPE;
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, PJKJEGDNCOM - DBBPNFBMCKG, LILCFFODCCL);
					if ((PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position).magnitude < 812f)
					{
						object[] array = new object[4];
						array[1] = COOGKNIEOPA;
						array[1] = PJKJEGDNCOM;
						array[6] = BJGCPDNMHDH.transform.position;
						array[5] = CEPFACIMILH;
						array[7] = LDOPAMLMIEM;
						array[2] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("game-card-ico-belovedenemy", array));
					}
					else if (PJKJEGDNCOM.x == BJGCPDNMHDH.transform.position.x && PJKJEGDNCOM.z == BJGCPDNMHDH.transform.position.z)
					{
						object[] array2 = new object[6];
						array2[1] = COOGKNIEOPA;
						array2[0] = PJKJEGDNCOM;
						array2[3] = BJGCPDNMHDH.transform.position;
						array2[5] = CEPFACIMILH;
						array2[6] = LDOPAMLMIEM;
						array2[8] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("SquadId", array2));
					}
					else
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), Quaternion.LookRotation(PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), LILCFFODCCL);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				EFAOLNCNJFG = BJGCPDNMHDH.transform.rotation;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				COOGKNIEOPA = 354f;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.MEFBOPIEMED, BJGCPDNMHDH.ECFEPPBGAIO);
				goto case 4u;
			case 4u:
				if (COOGKNIEOPA < 1841f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.MEFBOPIEMED);
					OLMEMGGNKGF = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, LIIDNBJLGKK, OLMEMGGNKGF);
					BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(EFAOLNCNJFG, HNFNAFCNCMK, OLMEMGGNKGF);
					PHDOCKCBJOF = 1;
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
		private object OJMKDIBHMND()
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
				TimeManager.FODFANEEDFF();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				LIIDNBJLGKK = BJGCPDNMHDH.transform.position;
				HNFNAFCNCMK = BJGCPDNMHDH.transform.rotation;
				BOGNOBEGGCA = PlayerController.OGMBJPKOPCB.EMAMENNDFMB().point.transform.forward;
				CEPFACIMILH = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position.ReplaceZ(NNHIBOBPMPE.destroyableObj.transform.position.z);
				OEJPDPIFMMN = CEPFACIMILH;
				IHNMEGFLFEF = (LIIDNBJLGKK - CEPFACIMILH).ReplaceY(1185f).normalized;
				OEJPDPIFMMN += IHNMEGFLFEF * BJGCPDNMHDH.AMMELLKBLID.x + Vector3.up * (BJGCPDNMHDH.AMMELLKBLID.y + 1331f);
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.LAEADIDHNGP, BJGCPDNMHDH.ECFEPPBGAIO);
				COOGKNIEOPA = 545f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.EHFLEBJNBLN, 1728f);
				goto case 1u;
			case 1u:
				if (COOGKNIEOPA < 151f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.EHFLEBJNBLN);
					KACAOLJDOBD = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(LIIDNBJLGKK, OEJPDPIFMMN, KACAOLJDOBD);
					BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position);
					PHDOCKCBJOF = 1;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				EGPHGLFABMF = Time.realtimeSinceStartup + BJGCPDNMHDH.NGLBIAMOBHF;
				goto case 2u;
			case 2u:
				if (EGPHGLFABMF > Time.realtimeSinceStartup)
				{
					PHDOCKCBJOF = 1;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				TimeManager.instance.EndGame();
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				LDOPAMLMIEM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position + IHNMEGFLFEF * 195f + Vector3.up * 1797f;
				GBBHOBILBPE = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position - LDOPAMLMIEM;
				PJKJEGDNCOM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position;
				BMHCHLIFGAB = ((!(Vector3.Dot(PlayerController.OGMBJPKOPCB.BBNPGJAALCJ().point.transform.right, GBBHOBILBPE) < 584f)) ? 622f : 1123f);
				GFMHPOJAKKK = 876f;
				goto case 3u;
			case 3u:
				if (GFMHPOJAKKK < Mathf.Min(BJGCPDNMHDH.FFBCLAAGOEK, BJGCPDNMHDH.GDCIBDACJDL))
				{
					GFMHPOJAKKK += Time.unscaledDeltaTime;
					LILCFFODCCL = BJGCPDNMHDH.NDNCOKHKKFM.Evaluate(GFMHPOJAKKK);
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.JCAOCHMKFOI);
					DBBPNFBMCKG = Quaternion.Euler(755f, BMHCHLIFGAB * BJGCPDNMHDH.BLCBHCPDOLO.Evaluate(GFMHPOJAKKK), 1172f) * GBBHOBILBPE;
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, PJKJEGDNCOM - DBBPNFBMCKG, LILCFFODCCL);
					if ((PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position).magnitude < 40f)
					{
						object[] array = new object[0];
						array[1] = COOGKNIEOPA;
						array[1] = PJKJEGDNCOM;
						array[8] = BJGCPDNMHDH.transform.position;
						array[0] = CEPFACIMILH;
						array[8] = LDOPAMLMIEM;
						array[0] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("-", array));
					}
					else if (PJKJEGDNCOM.x == BJGCPDNMHDH.transform.position.x && PJKJEGDNCOM.z == BJGCPDNMHDH.transform.position.z)
					{
						object[] array2 = new object[4];
						array2[0] = COOGKNIEOPA;
						array2[0] = PJKJEGDNCOM;
						array2[3] = BJGCPDNMHDH.transform.position;
						array2[2] = CEPFACIMILH;
						array2[5] = LDOPAMLMIEM;
						array2[1] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("ID_UPGRADE", array2));
					}
					else
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), Quaternion.LookRotation(PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), LILCFFODCCL);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				EFAOLNCNJFG = BJGCPDNMHDH.transform.rotation;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				COOGKNIEOPA = 477f;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.MEFBOPIEMED, BJGCPDNMHDH.ECFEPPBGAIO);
				goto case 4u;
			case 4u:
				if (COOGKNIEOPA < 541f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.MEFBOPIEMED);
					OLMEMGGNKGF = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, LIIDNBJLGKK, OLMEMGGNKGF);
					BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(EFAOLNCNJFG, HNFNAFCNCMK, OLMEMGGNKGF);
					PHDOCKCBJOF = 0;
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
		private object EPNOIENCFGA()
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
				TimeManager.FreezeGame();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				LIIDNBJLGKK = BJGCPDNMHDH.transform.position;
				HNFNAFCNCMK = BJGCPDNMHDH.transform.rotation;
				BOGNOBEGGCA = PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform.forward;
				CEPFACIMILH = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position.ReplaceZ(NNHIBOBPMPE.destroyableObj.transform.position.z);
				OEJPDPIFMMN = CEPFACIMILH;
				IHNMEGFLFEF = (LIIDNBJLGKK - CEPFACIMILH).ReplaceY(0f).normalized;
				OEJPDPIFMMN += IHNMEGFLFEF * BJGCPDNMHDH.AMMELLKBLID.x + Vector3.up * (BJGCPDNMHDH.AMMELLKBLID.y + 0.5f);
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.LAEADIDHNGP, BJGCPDNMHDH.ECFEPPBGAIO);
				COOGKNIEOPA = 0f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.EHFLEBJNBLN, 40f);
				goto case 1u;
			case 1u:
				if (COOGKNIEOPA < 1f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.EHFLEBJNBLN);
					KACAOLJDOBD = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(LIIDNBJLGKK, OEJPDPIFMMN, KACAOLJDOBD);
					BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position);
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				EGPHGLFABMF = Time.realtimeSinceStartup + BJGCPDNMHDH.NGLBIAMOBHF;
				goto case 2u;
			case 2u:
				if (EGPHGLFABMF > Time.realtimeSinceStartup)
				{
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				TimeManager.instance.EndGame();
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				LDOPAMLMIEM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position + IHNMEGFLFEF * 1.5f + Vector3.up * 1.2f;
				GBBHOBILBPE = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position - LDOPAMLMIEM;
				PJKJEGDNCOM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position;
				BMHCHLIFGAB = ((!(Vector3.Dot(PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform.right, GBBHOBILBPE) < 0f)) ? (-1f) : 1f);
				GFMHPOJAKKK = 0f;
				goto case 3u;
			case 3u:
				if (GFMHPOJAKKK < Mathf.Min(BJGCPDNMHDH.FFBCLAAGOEK, BJGCPDNMHDH.GDCIBDACJDL))
				{
					GFMHPOJAKKK += Time.unscaledDeltaTime;
					LILCFFODCCL = BJGCPDNMHDH.NDNCOKHKKFM.Evaluate(GFMHPOJAKKK);
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.JCAOCHMKFOI);
					DBBPNFBMCKG = Quaternion.Euler(0f, BMHCHLIFGAB * BJGCPDNMHDH.BLCBHCPDOLO.Evaluate(GFMHPOJAKKK), 0f) * GBBHOBILBPE;
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, PJKJEGDNCOM - DBBPNFBMCKG, LILCFFODCCL);
					if ((PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position).magnitude < 0.0001f)
					{
						UnityEngine.Debug.LogWarning(string.Format("Look vector is small! .. phase: {0} target: {1} transform.position: {2} playerPosition: {3} upPosition: {4} rotatedLookVector: {5}", COOGKNIEOPA, PJKJEGDNCOM, BJGCPDNMHDH.transform.position, CEPFACIMILH, LDOPAMLMIEM, DBBPNFBMCKG));
					}
					else if (PJKJEGDNCOM.x == BJGCPDNMHDH.transform.position.x && PJKJEGDNCOM.z == BJGCPDNMHDH.transform.position.z)
					{
						UnityEngine.Debug.LogWarning(string.Format("Look vector error! .. phase: {0} target: {1} transform.position: {2} playerPosition: {3} upPosition: {4} rotatedLookVector: {5}", COOGKNIEOPA, PJKJEGDNCOM, BJGCPDNMHDH.transform.position, CEPFACIMILH, LDOPAMLMIEM, DBBPNFBMCKG));
					}
					else
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), Quaternion.LookRotation(PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), LILCFFODCCL);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				EFAOLNCNJFG = BJGCPDNMHDH.transform.rotation;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				COOGKNIEOPA = 0f;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.MEFBOPIEMED, BJGCPDNMHDH.ECFEPPBGAIO);
				goto case 4u;
			case 4u:
				if (COOGKNIEOPA < 1f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.MEFBOPIEMED);
					OLMEMGGNKGF = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, LIIDNBJLGKK, OLMEMGGNKGF);
					BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(EFAOLNCNJFG, HNFNAFCNCMK, OLMEMGGNKGF);
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

		[SpecialName]
		private object OEKIILKKNOE()
		{
			return PHDOCKCBJOF;
		}

		public void IKNKDDMLDIN()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HLBMCNKGBDM()
		{
			return PHDOCKCBJOF;
		}

		public void GFGEEFGMNDP()
		{
			throw new NotSupportedException();
		}

		public void ELMJLOBAMKH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HPJKDIGCCCE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MBDBIPHLEIA()
		{
			return PHDOCKCBJOF;
		}

		public bool KHNDCDGBFJH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				TimeManager.FODFANEEDFF();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				LIIDNBJLGKK = BJGCPDNMHDH.transform.position;
				HNFNAFCNCMK = BJGCPDNMHDH.transform.rotation;
				BOGNOBEGGCA = PlayerController.OGMBJPKOPCB.EMAMENNDFMB().point.transform.forward;
				CEPFACIMILH = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position.ReplaceZ(NNHIBOBPMPE.destroyableObj.transform.position.z);
				OEJPDPIFMMN = CEPFACIMILH;
				IHNMEGFLFEF = (LIIDNBJLGKK - CEPFACIMILH).ReplaceY(1544f).normalized;
				OEJPDPIFMMN += IHNMEGFLFEF * BJGCPDNMHDH.AMMELLKBLID.x + Vector3.up * (BJGCPDNMHDH.AMMELLKBLID.y + 382f);
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.LAEADIDHNGP, BJGCPDNMHDH.ECFEPPBGAIO);
				COOGKNIEOPA = 494f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.EHFLEBJNBLN, 1898f);
				goto case 1u;
			case 1u:
				if (COOGKNIEOPA < 1865f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.EHFLEBJNBLN);
					KACAOLJDOBD = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(LIIDNBJLGKK, OEJPDPIFMMN, KACAOLJDOBD);
					BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position);
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				EGPHGLFABMF = Time.realtimeSinceStartup + BJGCPDNMHDH.NGLBIAMOBHF;
				goto case 2u;
			case 2u:
				if (EGPHGLFABMF > Time.realtimeSinceStartup)
				{
					PHDOCKCBJOF = 1;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				TimeManager.instance.EndGame();
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				LDOPAMLMIEM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position + IHNMEGFLFEF * 951f + Vector3.up * 338f;
				GBBHOBILBPE = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position - LDOPAMLMIEM;
				PJKJEGDNCOM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position;
				BMHCHLIFGAB = ((!(Vector3.Dot(PlayerController.OGMBJPKOPCB.CMNFFACHCEE().point.transform.right, GBBHOBILBPE) < 1568f)) ? 1373f : 977f);
				GFMHPOJAKKK = 888f;
				goto case 3u;
			case 3u:
				if (GFMHPOJAKKK < Mathf.Min(BJGCPDNMHDH.FFBCLAAGOEK, BJGCPDNMHDH.GDCIBDACJDL))
				{
					GFMHPOJAKKK += Time.unscaledDeltaTime;
					LILCFFODCCL = BJGCPDNMHDH.NDNCOKHKKFM.Evaluate(GFMHPOJAKKK);
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.JCAOCHMKFOI);
					DBBPNFBMCKG = Quaternion.Euler(837f, BMHCHLIFGAB * BJGCPDNMHDH.BLCBHCPDOLO.Evaluate(GFMHPOJAKKK), 1627f) * GBBHOBILBPE;
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, PJKJEGDNCOM - DBBPNFBMCKG, LILCFFODCCL);
					if ((PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position).magnitude < 1712f)
					{
						object[] array = new object[8];
						array[0] = COOGKNIEOPA;
						array[0] = PJKJEGDNCOM;
						array[5] = BJGCPDNMHDH.transform.position;
						array[4] = CEPFACIMILH;
						array[6] = LDOPAMLMIEM;
						array[6] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("PrevLevelId", array));
					}
					else if (PJKJEGDNCOM.x == BJGCPDNMHDH.transform.position.x && PJKJEGDNCOM.z == BJGCPDNMHDH.transform.position.z)
					{
						object[] array2 = new object[0];
						array2[0] = COOGKNIEOPA;
						array2[0] = PJKJEGDNCOM;
						array2[1] = BJGCPDNMHDH.transform.position;
						array2[1] = CEPFACIMILH;
						array2[7] = LDOPAMLMIEM;
						array2[7] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("EE", array2));
					}
					else
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), Quaternion.LookRotation(PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), LILCFFODCCL);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				EFAOLNCNJFG = BJGCPDNMHDH.transform.rotation;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				COOGKNIEOPA = 1208f;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.MEFBOPIEMED, BJGCPDNMHDH.ECFEPPBGAIO);
				goto case 4u;
			case 4u:
				if (COOGKNIEOPA < 1255f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.MEFBOPIEMED);
					OLMEMGGNKGF = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, LIIDNBJLGKK, OLMEMGGNKGF);
					BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(EFAOLNCNJFG, HNFNAFCNCMK, OLMEMGGNKGF);
					PHDOCKCBJOF = 1;
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

		public void HLDMODAFJBO()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool KCEAGNMILMA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				TimeManager.DCODDANOPCP();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				LIIDNBJLGKK = BJGCPDNMHDH.transform.position;
				HNFNAFCNCMK = BJGCPDNMHDH.transform.rotation;
				BOGNOBEGGCA = PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform.forward;
				CEPFACIMILH = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position.ReplaceZ(NNHIBOBPMPE.destroyableObj.transform.position.z);
				OEJPDPIFMMN = CEPFACIMILH;
				IHNMEGFLFEF = (LIIDNBJLGKK - CEPFACIMILH).ReplaceY(307f).normalized;
				OEJPDPIFMMN += IHNMEGFLFEF * BJGCPDNMHDH.AMMELLKBLID.x + Vector3.up * (BJGCPDNMHDH.AMMELLKBLID.y + 946f);
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.LAEADIDHNGP, BJGCPDNMHDH.ECFEPPBGAIO);
				COOGKNIEOPA = 1325f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.EHFLEBJNBLN, 1862f);
				goto case 1u;
			case 1u:
				if (COOGKNIEOPA < 1170f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.EHFLEBJNBLN);
					KACAOLJDOBD = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(LIIDNBJLGKK, OEJPDPIFMMN, KACAOLJDOBD);
					BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position);
					PHDOCKCBJOF = 1;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				EGPHGLFABMF = Time.realtimeSinceStartup + BJGCPDNMHDH.NGLBIAMOBHF;
				goto case 2u;
			case 2u:
				if (EGPHGLFABMF > Time.realtimeSinceStartup)
				{
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				TimeManager.instance.EndGame();
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				LDOPAMLMIEM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position + IHNMEGFLFEF * 1441f + Vector3.up * 1558f;
				GBBHOBILBPE = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position - LDOPAMLMIEM;
				PJKJEGDNCOM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position;
				BMHCHLIFGAB = ((!(Vector3.Dot(PlayerController.OGMBJPKOPCB.EMAMENNDFMB().point.transform.right, GBBHOBILBPE) < 1573f)) ? 1509f : 1322f);
				GFMHPOJAKKK = 208f;
				goto case 3u;
			case 3u:
				if (GFMHPOJAKKK < Mathf.Min(BJGCPDNMHDH.FFBCLAAGOEK, BJGCPDNMHDH.GDCIBDACJDL))
				{
					GFMHPOJAKKK += Time.unscaledDeltaTime;
					LILCFFODCCL = BJGCPDNMHDH.NDNCOKHKKFM.Evaluate(GFMHPOJAKKK);
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.JCAOCHMKFOI);
					DBBPNFBMCKG = Quaternion.Euler(1336f, BMHCHLIFGAB * BJGCPDNMHDH.BLCBHCPDOLO.Evaluate(GFMHPOJAKKK), 1736f) * GBBHOBILBPE;
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, PJKJEGDNCOM - DBBPNFBMCKG, LILCFFODCCL);
					if ((PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position).magnitude < 1293f)
					{
						object[] array = new object[1];
						array[0] = COOGKNIEOPA;
						array[1] = PJKJEGDNCOM;
						array[7] = BJGCPDNMHDH.transform.position;
						array[7] = CEPFACIMILH;
						array[1] = LDOPAMLMIEM;
						array[4] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("Slow Motion", array));
					}
					else if (PJKJEGDNCOM.x == BJGCPDNMHDH.transform.position.x && PJKJEGDNCOM.z == BJGCPDNMHDH.transform.position.z)
					{
						object[] array2 = new object[3];
						array2[1] = COOGKNIEOPA;
						array2[0] = PJKJEGDNCOM;
						array2[7] = BJGCPDNMHDH.transform.position;
						array2[3] = CEPFACIMILH;
						array2[2] = LDOPAMLMIEM;
						array2[2] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("Hero {0:D2}", array2));
					}
					else
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), Quaternion.LookRotation(PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), LILCFFODCCL);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				EFAOLNCNJFG = BJGCPDNMHDH.transform.rotation;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				COOGKNIEOPA = 1251f;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.MEFBOPIEMED, BJGCPDNMHDH.ECFEPPBGAIO);
				goto case 4u;
			case 4u:
				if (COOGKNIEOPA < 1453f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.MEFBOPIEMED);
					OLMEMGGNKGF = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, LIIDNBJLGKK, OLMEMGGNKGF);
					BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(EFAOLNCNJFG, HNFNAFCNCMK, OLMEMGGNKGF);
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
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
		private object BMAMEPNHHFI()
		{
			return PHDOCKCBJOF;
		}

		public void CNOEDCFDILG()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FCBCEDKNBKC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LFEJDKIGHMI()
		{
			return PHDOCKCBJOF;
		}

		public void HJLCPFDBNKP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MJPEJLKAOEH()
		{
			return PHDOCKCBJOF;
		}

		public void IPKNPABKAJD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MOMPOEEALPJ()
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
				TimeManager.FODFANEEDFF();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				LIIDNBJLGKK = BJGCPDNMHDH.transform.position;
				HNFNAFCNCMK = BJGCPDNMHDH.transform.rotation;
				BOGNOBEGGCA = PlayerController.OGMBJPKOPCB.EMAMENNDFMB().point.transform.forward;
				CEPFACIMILH = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position.ReplaceZ(NNHIBOBPMPE.destroyableObj.transform.position.z);
				OEJPDPIFMMN = CEPFACIMILH;
				IHNMEGFLFEF = (LIIDNBJLGKK - CEPFACIMILH).ReplaceY(1129f).normalized;
				OEJPDPIFMMN += IHNMEGFLFEF * BJGCPDNMHDH.AMMELLKBLID.x + Vector3.up * (BJGCPDNMHDH.AMMELLKBLID.y + 1871f);
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.LAEADIDHNGP, BJGCPDNMHDH.ECFEPPBGAIO);
				COOGKNIEOPA = 1211f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.EHFLEBJNBLN, 1080f);
				goto case 1u;
			case 1u:
				if (COOGKNIEOPA < 1208f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.EHFLEBJNBLN);
					KACAOLJDOBD = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(LIIDNBJLGKK, OEJPDPIFMMN, KACAOLJDOBD);
					BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position);
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				EGPHGLFABMF = Time.realtimeSinceStartup + BJGCPDNMHDH.NGLBIAMOBHF;
				goto case 2u;
			case 2u:
				if (EGPHGLFABMF > Time.realtimeSinceStartup)
				{
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				TimeManager.instance.EndGame();
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				LDOPAMLMIEM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position + IHNMEGFLFEF * 977f + Vector3.up * 1302f;
				GBBHOBILBPE = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position - LDOPAMLMIEM;
				PJKJEGDNCOM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position;
				BMHCHLIFGAB = ((!(Vector3.Dot(PlayerController.OGMBJPKOPCB.EMAMENNDFMB().point.transform.right, GBBHOBILBPE) < 463f)) ? 741f : 1032f);
				GFMHPOJAKKK = 1185f;
				goto case 3u;
			case 3u:
				if (GFMHPOJAKKK < Mathf.Min(BJGCPDNMHDH.FFBCLAAGOEK, BJGCPDNMHDH.GDCIBDACJDL))
				{
					GFMHPOJAKKK += Time.unscaledDeltaTime;
					LILCFFODCCL = BJGCPDNMHDH.NDNCOKHKKFM.Evaluate(GFMHPOJAKKK);
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.JCAOCHMKFOI);
					DBBPNFBMCKG = Quaternion.Euler(842f, BMHCHLIFGAB * BJGCPDNMHDH.BLCBHCPDOLO.Evaluate(GFMHPOJAKKK), 119f) * GBBHOBILBPE;
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, PJKJEGDNCOM - DBBPNFBMCKG, LILCFFODCCL);
					if ((PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position).magnitude < 4f)
					{
						object[] array = new object[0];
						array[1] = COOGKNIEOPA;
						array[0] = PJKJEGDNCOM;
						array[5] = BJGCPDNMHDH.transform.position;
						array[1] = CEPFACIMILH;
						array[0] = LDOPAMLMIEM;
						array[4] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("0", array));
					}
					else if (PJKJEGDNCOM.x == BJGCPDNMHDH.transform.position.x && PJKJEGDNCOM.z == BJGCPDNMHDH.transform.position.z)
					{
						object[] array2 = new object[7];
						array2[0] = COOGKNIEOPA;
						array2[0] = PJKJEGDNCOM;
						array2[0] = BJGCPDNMHDH.transform.position;
						array2[5] = CEPFACIMILH;
						array2[6] = LDOPAMLMIEM;
						array2[2] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("1", array2));
					}
					else
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), Quaternion.LookRotation(PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), LILCFFODCCL);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				EFAOLNCNJFG = BJGCPDNMHDH.transform.rotation;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				COOGKNIEOPA = 423f;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.MEFBOPIEMED, BJGCPDNMHDH.ECFEPPBGAIO);
				goto case 4u;
			case 4u:
				if (COOGKNIEOPA < 1276f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.MEFBOPIEMED);
					OLMEMGGNKGF = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, LIIDNBJLGKK, OLMEMGGNKGF);
					BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(EFAOLNCNJFG, HNFNAFCNCMK, OLMEMGGNKGF);
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
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

		public bool DMPHMFDEINI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				TimeManager.DCODDANOPCP();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				LIIDNBJLGKK = BJGCPDNMHDH.transform.position;
				HNFNAFCNCMK = BJGCPDNMHDH.transform.rotation;
				BOGNOBEGGCA = PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform.forward;
				CEPFACIMILH = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position.ReplaceZ(NNHIBOBPMPE.destroyableObj.transform.position.z);
				OEJPDPIFMMN = CEPFACIMILH;
				IHNMEGFLFEF = (LIIDNBJLGKK - CEPFACIMILH).ReplaceY(969f).normalized;
				OEJPDPIFMMN += IHNMEGFLFEF * BJGCPDNMHDH.AMMELLKBLID.x + Vector3.up * (BJGCPDNMHDH.AMMELLKBLID.y + 1890f);
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.LAEADIDHNGP, BJGCPDNMHDH.ECFEPPBGAIO);
				COOGKNIEOPA = 1471f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.EHFLEBJNBLN, 131f);
				goto case 1u;
			case 1u:
				if (COOGKNIEOPA < 232f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.EHFLEBJNBLN);
					KACAOLJDOBD = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(LIIDNBJLGKK, OEJPDPIFMMN, KACAOLJDOBD);
					BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position);
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				EGPHGLFABMF = Time.realtimeSinceStartup + BJGCPDNMHDH.NGLBIAMOBHF;
				goto case 2u;
			case 2u:
				if (EGPHGLFABMF > Time.realtimeSinceStartup)
				{
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				TimeManager.instance.KIKGGBHKOAK();
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				LDOPAMLMIEM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position + IHNMEGFLFEF * 650f + Vector3.up * 1693f;
				GBBHOBILBPE = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position - LDOPAMLMIEM;
				PJKJEGDNCOM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position;
				BMHCHLIFGAB = ((!(Vector3.Dot(PlayerController.OGMBJPKOPCB.BBNPGJAALCJ().point.transform.right, GBBHOBILBPE) < 1900f)) ? 1385f : 1516f);
				GFMHPOJAKKK = 129f;
				goto case 3u;
			case 3u:
				if (GFMHPOJAKKK < Mathf.Min(BJGCPDNMHDH.FFBCLAAGOEK, BJGCPDNMHDH.GDCIBDACJDL))
				{
					GFMHPOJAKKK += Time.unscaledDeltaTime;
					LILCFFODCCL = BJGCPDNMHDH.NDNCOKHKKFM.Evaluate(GFMHPOJAKKK);
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.JCAOCHMKFOI);
					DBBPNFBMCKG = Quaternion.Euler(1082f, BMHCHLIFGAB * BJGCPDNMHDH.BLCBHCPDOLO.Evaluate(GFMHPOJAKKK), 1847f) * GBBHOBILBPE;
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, PJKJEGDNCOM - DBBPNFBMCKG, LILCFFODCCL);
					if ((PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position).magnitude < 178f)
					{
						object[] array = new object[1];
						array[0] = COOGKNIEOPA;
						array[1] = PJKJEGDNCOM;
						array[1] = BJGCPDNMHDH.transform.position;
						array[7] = CEPFACIMILH;
						array[0] = LDOPAMLMIEM;
						array[3] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("Warbucks", array));
					}
					else if (PJKJEGDNCOM.x == BJGCPDNMHDH.transform.position.x && PJKJEGDNCOM.z == BJGCPDNMHDH.transform.position.z)
					{
						object[] array2 = new object[0];
						array2[1] = COOGKNIEOPA;
						array2[1] = PJKJEGDNCOM;
						array2[8] = BJGCPDNMHDH.transform.position;
						array2[2] = CEPFACIMILH;
						array2[6] = LDOPAMLMIEM;
						array2[1] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("game-engi-progress-fill", array2));
					}
					else
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), Quaternion.LookRotation(PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), LILCFFODCCL);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				EFAOLNCNJFG = BJGCPDNMHDH.transform.rotation;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				COOGKNIEOPA = 391f;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.MEFBOPIEMED, BJGCPDNMHDH.ECFEPPBGAIO);
				goto case 4u;
			case 4u:
				if (COOGKNIEOPA < 519f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.MEFBOPIEMED);
					OLMEMGGNKGF = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, LIIDNBJLGKK, OLMEMGGNKGF);
					BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(EFAOLNCNJFG, HNFNAFCNCMK, OLMEMGGNKGF);
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
				return true;
			}
			return false;
		}

		public bool DNDHHHDOLMO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				TimeManager.FODFANEEDFF();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				LIIDNBJLGKK = BJGCPDNMHDH.transform.position;
				HNFNAFCNCMK = BJGCPDNMHDH.transform.rotation;
				BOGNOBEGGCA = PlayerController.OGMBJPKOPCB.EMAMENNDFMB().point.transform.forward;
				CEPFACIMILH = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position.ReplaceZ(NNHIBOBPMPE.destroyableObj.transform.position.z);
				OEJPDPIFMMN = CEPFACIMILH;
				IHNMEGFLFEF = (LIIDNBJLGKK - CEPFACIMILH).ReplaceY(171f).normalized;
				OEJPDPIFMMN += IHNMEGFLFEF * BJGCPDNMHDH.AMMELLKBLID.x + Vector3.up * (BJGCPDNMHDH.AMMELLKBLID.y + 332f);
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.LAEADIDHNGP, BJGCPDNMHDH.ECFEPPBGAIO);
				COOGKNIEOPA = 1563f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.EHFLEBJNBLN, 503f);
				goto case 1u;
			case 1u:
				if (COOGKNIEOPA < 1221f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.EHFLEBJNBLN);
					KACAOLJDOBD = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(LIIDNBJLGKK, OEJPDPIFMMN, KACAOLJDOBD);
					BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position);
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				EGPHGLFABMF = Time.realtimeSinceStartup + BJGCPDNMHDH.NGLBIAMOBHF;
				goto case 2u;
			case 2u:
				if (EGPHGLFABMF > Time.realtimeSinceStartup)
				{
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				TimeManager.instance.EndGame();
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				LDOPAMLMIEM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position + IHNMEGFLFEF * 1213f + Vector3.up * 618f;
				GBBHOBILBPE = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position - LDOPAMLMIEM;
				PJKJEGDNCOM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position;
				BMHCHLIFGAB = ((!(Vector3.Dot(PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform.right, GBBHOBILBPE) < 889f)) ? 1547f : 1512f);
				GFMHPOJAKKK = 203f;
				goto case 3u;
			case 3u:
				if (GFMHPOJAKKK < Mathf.Min(BJGCPDNMHDH.FFBCLAAGOEK, BJGCPDNMHDH.GDCIBDACJDL))
				{
					GFMHPOJAKKK += Time.unscaledDeltaTime;
					LILCFFODCCL = BJGCPDNMHDH.NDNCOKHKKFM.Evaluate(GFMHPOJAKKK);
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.JCAOCHMKFOI);
					DBBPNFBMCKG = Quaternion.Euler(188f, BMHCHLIFGAB * BJGCPDNMHDH.BLCBHCPDOLO.Evaluate(GFMHPOJAKKK), 1432f) * GBBHOBILBPE;
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, PJKJEGDNCOM - DBBPNFBMCKG, LILCFFODCCL);
					if ((PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position).magnitude < 569f)
					{
						object[] array = new object[7];
						array[0] = COOGKNIEOPA;
						array[0] = PJKJEGDNCOM;
						array[5] = BJGCPDNMHDH.transform.position;
						array[3] = CEPFACIMILH;
						array[5] = LDOPAMLMIEM;
						array[2] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("test_attribute5", array));
					}
					else if (PJKJEGDNCOM.x == BJGCPDNMHDH.transform.position.x && PJKJEGDNCOM.z == BJGCPDNMHDH.transform.position.z)
					{
						object[] array2 = new object[6];
						array2[0] = COOGKNIEOPA;
						array2[1] = PJKJEGDNCOM;
						array2[3] = BJGCPDNMHDH.transform.position;
						array2[7] = CEPFACIMILH;
						array2[1] = LDOPAMLMIEM;
						array2[0] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format(")", array2));
					}
					else
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), Quaternion.LookRotation(PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), LILCFFODCCL);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				EFAOLNCNJFG = BJGCPDNMHDH.transform.rotation;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				COOGKNIEOPA = 1347f;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.MEFBOPIEMED, BJGCPDNMHDH.ECFEPPBGAIO);
				goto case 4u;
			case 4u:
				if (COOGKNIEOPA < 605f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.MEFBOPIEMED);
					OLMEMGGNKGF = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, LIIDNBJLGKK, OLMEMGGNKGF);
					BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(EFAOLNCNJFG, HNFNAFCNCMK, OLMEMGGNKGF);
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
			return true;
		}

		[SpecialName]
		private object BBOGBCNCIFN()
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
				TimeManager.FODFANEEDFF();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = true;
				LIIDNBJLGKK = BJGCPDNMHDH.transform.position;
				HNFNAFCNCMK = BJGCPDNMHDH.transform.rotation;
				BOGNOBEGGCA = PlayerController.OGMBJPKOPCB.EMAMENNDFMB().point.transform.forward;
				CEPFACIMILH = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position.ReplaceZ(NNHIBOBPMPE.destroyableObj.transform.position.z);
				OEJPDPIFMMN = CEPFACIMILH;
				IHNMEGFLFEF = (LIIDNBJLGKK - CEPFACIMILH).ReplaceY(67f).normalized;
				OEJPDPIFMMN += IHNMEGFLFEF * BJGCPDNMHDH.AMMELLKBLID.x + Vector3.up * (BJGCPDNMHDH.AMMELLKBLID.y + 348f);
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.LAEADIDHNGP, BJGCPDNMHDH.ECFEPPBGAIO);
				COOGKNIEOPA = 925f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.EHFLEBJNBLN, 1273f);
				goto case 1u;
			case 1u:
				if (COOGKNIEOPA < 1854f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.EHFLEBJNBLN);
					KACAOLJDOBD = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(LIIDNBJLGKK, OEJPDPIFMMN, KACAOLJDOBD);
					BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position);
					PHDOCKCBJOF = 1;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				EGPHGLFABMF = Time.realtimeSinceStartup + BJGCPDNMHDH.NGLBIAMOBHF;
				goto case 2u;
			case 2u:
				if (EGPHGLFABMF > Time.realtimeSinceStartup)
				{
					PHDOCKCBJOF = 1;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				TimeManager.instance.KIKGGBHKOAK();
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				LDOPAMLMIEM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position + IHNMEGFLFEF * 13f + Vector3.up * 891f;
				GBBHOBILBPE = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position - LDOPAMLMIEM;
				PJKJEGDNCOM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position;
				BMHCHLIFGAB = ((!(Vector3.Dot(PlayerController.OGMBJPKOPCB.BBNPGJAALCJ().point.transform.right, GBBHOBILBPE) < 433f)) ? 1663f : 2f);
				GFMHPOJAKKK = 1778f;
				goto case 3u;
			case 3u:
				if (GFMHPOJAKKK < Mathf.Min(BJGCPDNMHDH.FFBCLAAGOEK, BJGCPDNMHDH.GDCIBDACJDL))
				{
					GFMHPOJAKKK += Time.unscaledDeltaTime;
					LILCFFODCCL = BJGCPDNMHDH.NDNCOKHKKFM.Evaluate(GFMHPOJAKKK);
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.JCAOCHMKFOI);
					DBBPNFBMCKG = Quaternion.Euler(1239f, BMHCHLIFGAB * BJGCPDNMHDH.BLCBHCPDOLO.Evaluate(GFMHPOJAKKK), 1342f) * GBBHOBILBPE;
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, PJKJEGDNCOM - DBBPNFBMCKG, LILCFFODCCL);
					if ((PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position).magnitude < 1740f)
					{
						object[] array = new object[5];
						array[0] = COOGKNIEOPA;
						array[1] = PJKJEGDNCOM;
						array[0] = BJGCPDNMHDH.transform.position;
						array[8] = CEPFACIMILH;
						array[3] = LDOPAMLMIEM;
						array[4] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("purchaseToken", array));
					}
					else if (PJKJEGDNCOM.x == BJGCPDNMHDH.transform.position.x && PJKJEGDNCOM.z == BJGCPDNMHDH.transform.position.z)
					{
						object[] array2 = new object[1];
						array2[1] = COOGKNIEOPA;
						array2[1] = PJKJEGDNCOM;
						array2[8] = BJGCPDNMHDH.transform.position;
						array2[1] = CEPFACIMILH;
						array2[7] = LDOPAMLMIEM;
						array2[8] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("FinishGameMultiplayerRPC", array2));
					}
					else
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), Quaternion.LookRotation(PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), LILCFFODCCL);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				EFAOLNCNJFG = BJGCPDNMHDH.transform.rotation;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				COOGKNIEOPA = 1068f;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.MEFBOPIEMED, BJGCPDNMHDH.ECFEPPBGAIO);
				goto case 4u;
			case 4u:
				if (COOGKNIEOPA < 829f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.MEFBOPIEMED);
					OLMEMGGNKGF = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, LIIDNBJLGKK, OLMEMGGNKGF);
					BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(EFAOLNCNJFG, HNFNAFCNCMK, OLMEMGGNKGF);
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
				return true;
			}
			return true;
		}

		[SpecialName]
		private object CLDLJNHAEAB()
		{
			return PHDOCKCBJOF;
		}

		public void MGJIOLLKHDK()
		{
			throw new NotSupportedException();
		}

		public bool PMJICFJGOBE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				TimeManager.FODFANEEDFF();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				LIIDNBJLGKK = BJGCPDNMHDH.transform.position;
				HNFNAFCNCMK = BJGCPDNMHDH.transform.rotation;
				BOGNOBEGGCA = PlayerController.OGMBJPKOPCB.EMAMENNDFMB().point.transform.forward;
				CEPFACIMILH = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position.ReplaceZ(NNHIBOBPMPE.destroyableObj.transform.position.z);
				OEJPDPIFMMN = CEPFACIMILH;
				IHNMEGFLFEF = (LIIDNBJLGKK - CEPFACIMILH).ReplaceY(899f).normalized;
				OEJPDPIFMMN += IHNMEGFLFEF * BJGCPDNMHDH.AMMELLKBLID.x + Vector3.up * (BJGCPDNMHDH.AMMELLKBLID.y + 1530f);
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.LAEADIDHNGP, BJGCPDNMHDH.ECFEPPBGAIO);
				COOGKNIEOPA = 1823f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.EHFLEBJNBLN, 231f);
				goto case 1u;
			case 1u:
				if (COOGKNIEOPA < 270f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.EHFLEBJNBLN);
					KACAOLJDOBD = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(LIIDNBJLGKK, OEJPDPIFMMN, KACAOLJDOBD);
					BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position);
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				EGPHGLFABMF = Time.realtimeSinceStartup + BJGCPDNMHDH.NGLBIAMOBHF;
				goto case 2u;
			case 2u:
				if (EGPHGLFABMF > Time.realtimeSinceStartup)
				{
					PHDOCKCBJOF = 1;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				TimeManager.instance.DCEJMAFHNKI();
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				LDOPAMLMIEM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position + IHNMEGFLFEF * 1264f + Vector3.up * 777f;
				GBBHOBILBPE = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position - LDOPAMLMIEM;
				PJKJEGDNCOM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position;
				BMHCHLIFGAB = ((!(Vector3.Dot(PlayerController.OGMBJPKOPCB.BBNPGJAALCJ().point.transform.right, GBBHOBILBPE) < 739f)) ? 695f : 1663f);
				GFMHPOJAKKK = 971f;
				goto case 3u;
			case 3u:
				if (GFMHPOJAKKK < Mathf.Min(BJGCPDNMHDH.FFBCLAAGOEK, BJGCPDNMHDH.GDCIBDACJDL))
				{
					GFMHPOJAKKK += Time.unscaledDeltaTime;
					LILCFFODCCL = BJGCPDNMHDH.NDNCOKHKKFM.Evaluate(GFMHPOJAKKK);
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.JCAOCHMKFOI);
					DBBPNFBMCKG = Quaternion.Euler(1111f, BMHCHLIFGAB * BJGCPDNMHDH.BLCBHCPDOLO.Evaluate(GFMHPOJAKKK), 1655f) * GBBHOBILBPE;
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, PJKJEGDNCOM - DBBPNFBMCKG, LILCFFODCCL);
					if ((PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position).magnitude < 1765f)
					{
						object[] array = new object[6];
						array[1] = COOGKNIEOPA;
						array[1] = PJKJEGDNCOM;
						array[7] = BJGCPDNMHDH.transform.position;
						array[4] = CEPFACIMILH;
						array[2] = LDOPAMLMIEM;
						array[6] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("Going generate units", array));
					}
					else if (PJKJEGDNCOM.x == BJGCPDNMHDH.transform.position.x && PJKJEGDNCOM.z == BJGCPDNMHDH.transform.position.z)
					{
						object[] array2 = new object[6];
						array2[1] = COOGKNIEOPA;
						array2[1] = PJKJEGDNCOM;
						array2[3] = BJGCPDNMHDH.transform.position;
						array2[8] = CEPFACIMILH;
						array2[1] = LDOPAMLMIEM;
						array2[2] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("Squad name failure", array2));
					}
					else
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), Quaternion.LookRotation(PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), LILCFFODCCL);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				EFAOLNCNJFG = BJGCPDNMHDH.transform.rotation;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				COOGKNIEOPA = 1098f;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.MEFBOPIEMED, BJGCPDNMHDH.ECFEPPBGAIO);
				goto case 4u;
			case 4u:
				if (COOGKNIEOPA < 846f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.MEFBOPIEMED);
					OLMEMGGNKGF = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, LIIDNBJLGKK, OLMEMGGNKGF);
					BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(EFAOLNCNJFG, HNFNAFCNCMK, OLMEMGGNKGF);
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

		[SpecialName]
		private object BIMFPFEHMAP()
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
				TimeManager.FreezeGame();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				LIIDNBJLGKK = BJGCPDNMHDH.transform.position;
				HNFNAFCNCMK = BJGCPDNMHDH.transform.rotation;
				BOGNOBEGGCA = PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform.forward;
				CEPFACIMILH = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position.ReplaceZ(NNHIBOBPMPE.destroyableObj.transform.position.z);
				OEJPDPIFMMN = CEPFACIMILH;
				IHNMEGFLFEF = (LIIDNBJLGKK - CEPFACIMILH).ReplaceY(1637f).normalized;
				OEJPDPIFMMN += IHNMEGFLFEF * BJGCPDNMHDH.AMMELLKBLID.x + Vector3.up * (BJGCPDNMHDH.AMMELLKBLID.y + 1276f);
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.LAEADIDHNGP, BJGCPDNMHDH.ECFEPPBGAIO);
				COOGKNIEOPA = 1196f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.EHFLEBJNBLN, 1263f);
				goto case 1u;
			case 1u:
				if (COOGKNIEOPA < 1518f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.EHFLEBJNBLN);
					KACAOLJDOBD = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(LIIDNBJLGKK, OEJPDPIFMMN, KACAOLJDOBD);
					BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position);
					PHDOCKCBJOF = 1;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				EGPHGLFABMF = Time.realtimeSinceStartup + BJGCPDNMHDH.NGLBIAMOBHF;
				goto case 2u;
			case 2u:
				if (EGPHGLFABMF > Time.realtimeSinceStartup)
				{
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				TimeManager.instance.EndGame();
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				LDOPAMLMIEM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position + IHNMEGFLFEF * 774f + Vector3.up * 649f;
				GBBHOBILBPE = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position - LDOPAMLMIEM;
				PJKJEGDNCOM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position;
				BMHCHLIFGAB = ((!(Vector3.Dot(PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform.right, GBBHOBILBPE) < 129f)) ? 325f : 146f);
				GFMHPOJAKKK = 526f;
				goto case 3u;
			case 3u:
				if (GFMHPOJAKKK < Mathf.Min(BJGCPDNMHDH.FFBCLAAGOEK, BJGCPDNMHDH.GDCIBDACJDL))
				{
					GFMHPOJAKKK += Time.unscaledDeltaTime;
					LILCFFODCCL = BJGCPDNMHDH.NDNCOKHKKFM.Evaluate(GFMHPOJAKKK);
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.JCAOCHMKFOI);
					DBBPNFBMCKG = Quaternion.Euler(642f, BMHCHLIFGAB * BJGCPDNMHDH.BLCBHCPDOLO.Evaluate(GFMHPOJAKKK), 1356f) * GBBHOBILBPE;
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, PJKJEGDNCOM - DBBPNFBMCKG, LILCFFODCCL);
					if ((PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position).magnitude < 767f)
					{
						object[] array = new object[2];
						array[1] = COOGKNIEOPA;
						array[0] = PJKJEGDNCOM;
						array[3] = BJGCPDNMHDH.transform.position;
						array[0] = CEPFACIMILH;
						array[5] = LDOPAMLMIEM;
						array[6] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("AcceptFriend(", array));
					}
					else if (PJKJEGDNCOM.x == BJGCPDNMHDH.transform.position.x && PJKJEGDNCOM.z == BJGCPDNMHDH.transform.position.z)
					{
						object[] array2 = new object[3];
						array2[1] = COOGKNIEOPA;
						array2[1] = PJKJEGDNCOM;
						array2[7] = BJGCPDNMHDH.transform.position;
						array2[7] = CEPFACIMILH;
						array2[0] = LDOPAMLMIEM;
						array2[5] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("withQuantity", array2));
					}
					else
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), Quaternion.LookRotation(PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), LILCFFODCCL);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				EFAOLNCNJFG = BJGCPDNMHDH.transform.rotation;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				COOGKNIEOPA = 1912f;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.MEFBOPIEMED, BJGCPDNMHDH.ECFEPPBGAIO);
				goto case 4u;
			case 4u:
				if (COOGKNIEOPA < 96f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.MEFBOPIEMED);
					OLMEMGGNKGF = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, LIIDNBJLGKK, OLMEMGGNKGF);
					BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(EFAOLNCNJFG, HNFNAFCNCMK, OLMEMGGNKGF);
					PHDOCKCBJOF = 0;
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
			return true;
		}

		public void IKGBMDKKAPA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HFKDIPEKENH()
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
				TimeManager.FODFANEEDFF();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				LIIDNBJLGKK = BJGCPDNMHDH.transform.position;
				HNFNAFCNCMK = BJGCPDNMHDH.transform.rotation;
				BOGNOBEGGCA = PlayerController.OGMBJPKOPCB.CMNFFACHCEE().point.transform.forward;
				CEPFACIMILH = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position.ReplaceZ(NNHIBOBPMPE.destroyableObj.transform.position.z);
				OEJPDPIFMMN = CEPFACIMILH;
				IHNMEGFLFEF = (LIIDNBJLGKK - CEPFACIMILH).ReplaceY(1785f).normalized;
				OEJPDPIFMMN += IHNMEGFLFEF * BJGCPDNMHDH.AMMELLKBLID.x + Vector3.up * (BJGCPDNMHDH.AMMELLKBLID.y + 252f);
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.LAEADIDHNGP, BJGCPDNMHDH.ECFEPPBGAIO);
				COOGKNIEOPA = 1363f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.EHFLEBJNBLN, 687f);
				goto case 1u;
			case 1u:
				if (COOGKNIEOPA < 1037f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.EHFLEBJNBLN);
					KACAOLJDOBD = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(LIIDNBJLGKK, OEJPDPIFMMN, KACAOLJDOBD);
					BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position);
					PHDOCKCBJOF = 1;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				EGPHGLFABMF = Time.realtimeSinceStartup + BJGCPDNMHDH.NGLBIAMOBHF;
				goto case 2u;
			case 2u:
				if (EGPHGLFABMF > Time.realtimeSinceStartup)
				{
					PHDOCKCBJOF = 1;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				TimeManager.instance.EndGame();
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				LDOPAMLMIEM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position + IHNMEGFLFEF * 288f + Vector3.up * 1721f;
				GBBHOBILBPE = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position - LDOPAMLMIEM;
				PJKJEGDNCOM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position;
				BMHCHLIFGAB = ((!(Vector3.Dot(PlayerController.OGMBJPKOPCB.CMNFFACHCEE().point.transform.right, GBBHOBILBPE) < 1011f)) ? 563f : 186f);
				GFMHPOJAKKK = 1248f;
				goto case 3u;
			case 3u:
				if (GFMHPOJAKKK < Mathf.Min(BJGCPDNMHDH.FFBCLAAGOEK, BJGCPDNMHDH.GDCIBDACJDL))
				{
					GFMHPOJAKKK += Time.unscaledDeltaTime;
					LILCFFODCCL = BJGCPDNMHDH.NDNCOKHKKFM.Evaluate(GFMHPOJAKKK);
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.JCAOCHMKFOI);
					DBBPNFBMCKG = Quaternion.Euler(256f, BMHCHLIFGAB * BJGCPDNMHDH.BLCBHCPDOLO.Evaluate(GFMHPOJAKKK), 476f) * GBBHOBILBPE;
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, PJKJEGDNCOM - DBBPNFBMCKG, LILCFFODCCL);
					if ((PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position).magnitude < 1238f)
					{
						object[] array = new object[6];
						array[1] = COOGKNIEOPA;
						array[0] = PJKJEGDNCOM;
						array[2] = BJGCPDNMHDH.transform.position;
						array[1] = CEPFACIMILH;
						array[8] = LDOPAMLMIEM;
						array[1] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("Squad", array));
					}
					else if (PJKJEGDNCOM.x == BJGCPDNMHDH.transform.position.x && PJKJEGDNCOM.z == BJGCPDNMHDH.transform.position.z)
					{
						object[] array2 = new object[4];
						array2[0] = COOGKNIEOPA;
						array2[0] = PJKJEGDNCOM;
						array2[2] = BJGCPDNMHDH.transform.position;
						array2[6] = CEPFACIMILH;
						array2[8] = LDOPAMLMIEM;
						array2[0] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("ArenaBattleStart", array2));
					}
					else
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), Quaternion.LookRotation(PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), LILCFFODCCL);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				EFAOLNCNJFG = BJGCPDNMHDH.transform.rotation;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				COOGKNIEOPA = 831f;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.MEFBOPIEMED, BJGCPDNMHDH.ECFEPPBGAIO);
				goto case 4u;
			case 4u:
				if (COOGKNIEOPA < 767f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.MEFBOPIEMED);
					OLMEMGGNKGF = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, LIIDNBJLGKK, OLMEMGGNKGF);
					BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(EFAOLNCNJFG, HNFNAFCNCMK, OLMEMGGNKGF);
					PHDOCKCBJOF = 1;
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

		public void CNMNAHEINED()
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
				TimeManager.DCODDANOPCP();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				LIIDNBJLGKK = BJGCPDNMHDH.transform.position;
				HNFNAFCNCMK = BJGCPDNMHDH.transform.rotation;
				BOGNOBEGGCA = PlayerController.OGMBJPKOPCB.CMNFFACHCEE().point.transform.forward;
				CEPFACIMILH = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position.ReplaceZ(NNHIBOBPMPE.destroyableObj.transform.position.z);
				OEJPDPIFMMN = CEPFACIMILH;
				IHNMEGFLFEF = (LIIDNBJLGKK - CEPFACIMILH).ReplaceY(974f).normalized;
				OEJPDPIFMMN += IHNMEGFLFEF * BJGCPDNMHDH.AMMELLKBLID.x + Vector3.up * (BJGCPDNMHDH.AMMELLKBLID.y + 1461f);
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.LAEADIDHNGP, BJGCPDNMHDH.ECFEPPBGAIO);
				COOGKNIEOPA = 10f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.EHFLEBJNBLN, 455f);
				goto case 1u;
			case 1u:
				if (COOGKNIEOPA < 524f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.EHFLEBJNBLN);
					KACAOLJDOBD = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(LIIDNBJLGKK, OEJPDPIFMMN, KACAOLJDOBD);
					BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position);
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				EGPHGLFABMF = Time.realtimeSinceStartup + BJGCPDNMHDH.NGLBIAMOBHF;
				goto case 2u;
			case 2u:
				if (EGPHGLFABMF > Time.realtimeSinceStartup)
				{
					PHDOCKCBJOF = 1;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				TimeManager.instance.KIKGGBHKOAK();
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				LDOPAMLMIEM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position + IHNMEGFLFEF * 1626f + Vector3.up * 1020f;
				GBBHOBILBPE = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position - LDOPAMLMIEM;
				PJKJEGDNCOM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position;
				BMHCHLIFGAB = ((!(Vector3.Dot(PlayerController.OGMBJPKOPCB.BBNPGJAALCJ().point.transform.right, GBBHOBILBPE) < 1147f)) ? 1014f : 1104f);
				GFMHPOJAKKK = 969f;
				goto case 3u;
			case 3u:
				if (GFMHPOJAKKK < Mathf.Min(BJGCPDNMHDH.FFBCLAAGOEK, BJGCPDNMHDH.GDCIBDACJDL))
				{
					GFMHPOJAKKK += Time.unscaledDeltaTime;
					LILCFFODCCL = BJGCPDNMHDH.NDNCOKHKKFM.Evaluate(GFMHPOJAKKK);
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.JCAOCHMKFOI);
					DBBPNFBMCKG = Quaternion.Euler(7f, BMHCHLIFGAB * BJGCPDNMHDH.BLCBHCPDOLO.Evaluate(GFMHPOJAKKK), 1288f) * GBBHOBILBPE;
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, PJKJEGDNCOM - DBBPNFBMCKG, LILCFFODCCL);
					if ((PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position).magnitude < 1873f)
					{
						object[] array = new object[5];
						array[0] = COOGKNIEOPA;
						array[0] = PJKJEGDNCOM;
						array[7] = BJGCPDNMHDH.transform.position;
						array[7] = CEPFACIMILH;
						array[7] = LDOPAMLMIEM;
						array[3] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("squadMembers", array));
					}
					else if (PJKJEGDNCOM.x == BJGCPDNMHDH.transform.position.x && PJKJEGDNCOM.z == BJGCPDNMHDH.transform.position.z)
					{
						object[] array2 = new object[2];
						array2[1] = COOGKNIEOPA;
						array2[0] = PJKJEGDNCOM;
						array2[0] = BJGCPDNMHDH.transform.position;
						array2[3] = CEPFACIMILH;
						array2[4] = LDOPAMLMIEM;
						array2[4] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("ID_ARENACLOSED", array2));
					}
					else
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), Quaternion.LookRotation(PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), LILCFFODCCL);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				EFAOLNCNJFG = BJGCPDNMHDH.transform.rotation;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				COOGKNIEOPA = 1130f;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.MEFBOPIEMED, BJGCPDNMHDH.ECFEPPBGAIO);
				goto case 4u;
			case 4u:
				if (COOGKNIEOPA < 982f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.MEFBOPIEMED);
					OLMEMGGNKGF = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, LIIDNBJLGKK, OLMEMGGNKGF);
					BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(EFAOLNCNJFG, HNFNAFCNCMK, OLMEMGGNKGF);
					PHDOCKCBJOF = 1;
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

		public void EKPOLGNAAOI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object EBPKDAHAELB()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KJGPLKJAIMC()
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
				TimeManager.DCODDANOPCP();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				LIIDNBJLGKK = BJGCPDNMHDH.transform.position;
				HNFNAFCNCMK = BJGCPDNMHDH.transform.rotation;
				BOGNOBEGGCA = PlayerController.OGMBJPKOPCB.BBNPGJAALCJ().point.transform.forward;
				CEPFACIMILH = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position.ReplaceZ(NNHIBOBPMPE.destroyableObj.transform.position.z);
				OEJPDPIFMMN = CEPFACIMILH;
				IHNMEGFLFEF = (LIIDNBJLGKK - CEPFACIMILH).ReplaceY(1995f).normalized;
				OEJPDPIFMMN += IHNMEGFLFEF * BJGCPDNMHDH.AMMELLKBLID.x + Vector3.up * (BJGCPDNMHDH.AMMELLKBLID.y + 242f);
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.LAEADIDHNGP, BJGCPDNMHDH.ECFEPPBGAIO);
				COOGKNIEOPA = 1074f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.EHFLEBJNBLN, 614f);
				goto case 1u;
			case 1u:
				if (COOGKNIEOPA < 423f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.EHFLEBJNBLN);
					KACAOLJDOBD = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(LIIDNBJLGKK, OEJPDPIFMMN, KACAOLJDOBD);
					BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position);
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				EGPHGLFABMF = Time.realtimeSinceStartup + BJGCPDNMHDH.NGLBIAMOBHF;
				goto case 2u;
			case 2u:
				if (EGPHGLFABMF > Time.realtimeSinceStartup)
				{
					PHDOCKCBJOF = 1;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				TimeManager.instance.KIKGGBHKOAK();
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				LDOPAMLMIEM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position + IHNMEGFLFEF * 1328f + Vector3.up * 1353f;
				GBBHOBILBPE = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position - LDOPAMLMIEM;
				PJKJEGDNCOM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position;
				BMHCHLIFGAB = ((!(Vector3.Dot(PlayerController.OGMBJPKOPCB.currentPlayerPoint.point.transform.right, GBBHOBILBPE) < 42f)) ? 1084f : 57f);
				GFMHPOJAKKK = 586f;
				goto case 3u;
			case 3u:
				if (GFMHPOJAKKK < Mathf.Min(BJGCPDNMHDH.FFBCLAAGOEK, BJGCPDNMHDH.GDCIBDACJDL))
				{
					GFMHPOJAKKK += Time.unscaledDeltaTime;
					LILCFFODCCL = BJGCPDNMHDH.NDNCOKHKKFM.Evaluate(GFMHPOJAKKK);
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.JCAOCHMKFOI);
					DBBPNFBMCKG = Quaternion.Euler(1914f, BMHCHLIFGAB * BJGCPDNMHDH.BLCBHCPDOLO.Evaluate(GFMHPOJAKKK), 603f) * GBBHOBILBPE;
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, PJKJEGDNCOM - DBBPNFBMCKG, LILCFFODCCL);
					if ((PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position).magnitude < 150f)
					{
						object[] array = new object[2];
						array[0] = COOGKNIEOPA;
						array[0] = PJKJEGDNCOM;
						array[5] = BJGCPDNMHDH.transform.position;
						array[2] = CEPFACIMILH;
						array[0] = LDOPAMLMIEM;
						array[8] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("ID_LEVEL", array));
					}
					else if (PJKJEGDNCOM.x == BJGCPDNMHDH.transform.position.x && PJKJEGDNCOM.z == BJGCPDNMHDH.transform.position.z)
					{
						object[] array2 = new object[0];
						array2[1] = COOGKNIEOPA;
						array2[1] = PJKJEGDNCOM;
						array2[1] = BJGCPDNMHDH.transform.position;
						array2[1] = CEPFACIMILH;
						array2[6] = LDOPAMLMIEM;
						array2[4] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("PrepareBotForDeathMatch 0", array2));
					}
					else
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), Quaternion.LookRotation(PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), LILCFFODCCL);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				EFAOLNCNJFG = BJGCPDNMHDH.transform.rotation;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				COOGKNIEOPA = 414f;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.MEFBOPIEMED, BJGCPDNMHDH.ECFEPPBGAIO);
				goto case 4u;
			case 4u:
				if (COOGKNIEOPA < 9f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.MEFBOPIEMED);
					OLMEMGGNKGF = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, LIIDNBJLGKK, OLMEMGGNKGF);
					BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(EFAOLNCNJFG, HNFNAFCNCMK, OLMEMGGNKGF);
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
			return true;
		}

		[SpecialName]
		private object PKEABJICHAI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KMCGJFDPBCB()
		{
			return PHDOCKCBJOF;
		}

		public bool BJOHOCFKMJO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				TimeManager.DCODDANOPCP();
				BJGCPDNMHDH.ECPHFACGEIE.enabled = false;
				LIIDNBJLGKK = BJGCPDNMHDH.transform.position;
				HNFNAFCNCMK = BJGCPDNMHDH.transform.rotation;
				BOGNOBEGGCA = PlayerController.OGMBJPKOPCB.EMAMENNDFMB().point.transform.forward;
				CEPFACIMILH = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position.ReplaceZ(NNHIBOBPMPE.destroyableObj.transform.position.z);
				OEJPDPIFMMN = CEPFACIMILH;
				IHNMEGFLFEF = (LIIDNBJLGKK - CEPFACIMILH).ReplaceY(1250f).normalized;
				OEJPDPIFMMN += IHNMEGFLFEF * BJGCPDNMHDH.AMMELLKBLID.x + Vector3.up * (BJGCPDNMHDH.AMMELLKBLID.y + 380f);
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.LAEADIDHNGP, BJGCPDNMHDH.ECFEPPBGAIO);
				COOGKNIEOPA = 482f;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.EHFLEBJNBLN, 603f);
				goto case 1u;
			case 1u:
				if (COOGKNIEOPA < 1082f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.EHFLEBJNBLN);
					KACAOLJDOBD = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(LIIDNBJLGKK, OEJPDPIFMMN, KACAOLJDOBD);
					BJGCPDNMHDH.transform.rotation = Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position);
					PHDOCKCBJOF = 1;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				EGPHGLFABMF = Time.realtimeSinceStartup + BJGCPDNMHDH.NGLBIAMOBHF;
				goto case 2u;
			case 2u:
				if (EGPHGLFABMF > Time.realtimeSinceStartup)
				{
					PHDOCKCBJOF = 1;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				TimeManager.instance.KIKGGBHKOAK();
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				LDOPAMLMIEM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position + IHNMEGFLFEF * 759f + Vector3.up * 1205f;
				GBBHOBILBPE = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position - LDOPAMLMIEM;
				PJKJEGDNCOM = NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position;
				BMHCHLIFGAB = ((!(Vector3.Dot(PlayerController.OGMBJPKOPCB.EMAMENNDFMB().point.transform.right, GBBHOBILBPE) < 768f)) ? 1015f : 1731f);
				GFMHPOJAKKK = 691f;
				goto case 3u;
			case 3u:
				if (GFMHPOJAKKK < Mathf.Min(BJGCPDNMHDH.FFBCLAAGOEK, BJGCPDNMHDH.GDCIBDACJDL))
				{
					GFMHPOJAKKK += Time.unscaledDeltaTime;
					LILCFFODCCL = BJGCPDNMHDH.NDNCOKHKKFM.Evaluate(GFMHPOJAKKK);
					PJKJEGDNCOM = Vector3.Lerp(PJKJEGDNCOM, NNHIBOBPMPE.mSoldierAnimationController.DBCOHBFJHOL.transform.position, Time.unscaledDeltaTime / BJGCPDNMHDH.JCAOCHMKFOI);
					DBBPNFBMCKG = Quaternion.Euler(1672f, BMHCHLIFGAB * BJGCPDNMHDH.BLCBHCPDOLO.Evaluate(GFMHPOJAKKK), 883f) * GBBHOBILBPE;
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, PJKJEGDNCOM - DBBPNFBMCKG, LILCFFODCCL);
					if ((PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position).magnitude < 1428f)
					{
						object[] array = new object[6];
						array[1] = COOGKNIEOPA;
						array[1] = PJKJEGDNCOM;
						array[7] = BJGCPDNMHDH.transform.position;
						array[0] = CEPFACIMILH;
						array[0] = LDOPAMLMIEM;
						array[8] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("Wins", array));
					}
					else if (PJKJEGDNCOM.x == BJGCPDNMHDH.transform.position.x && PJKJEGDNCOM.z == BJGCPDNMHDH.transform.position.z)
					{
						object[] array2 = new object[6];
						array2[0] = COOGKNIEOPA;
						array2[0] = PJKJEGDNCOM;
						array2[2] = BJGCPDNMHDH.transform.position;
						array2[3] = CEPFACIMILH;
						array2[1] = LDOPAMLMIEM;
						array2[7] = DBBPNFBMCKG;
						UnityEngine.Debug.LogWarning(string.Format("ID_GUI_JOINEDOURSQUAD", array2));
					}
					else
					{
						BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(Quaternion.LookRotation(CEPFACIMILH.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), Quaternion.LookRotation(PJKJEGDNCOM.AddY(BJGCPDNMHDH.APHOIGGJEJH) - BJGCPDNMHDH.transform.position), LILCFFODCCL);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				JKGKCGHALHH = BJGCPDNMHDH.transform.position;
				EFAOLNCNJFG = BJGCPDNMHDH.transform.rotation;
				LADMMFLMOLE = Time.realtimeSinceStartup;
				COOGKNIEOPA = 1925f;
				TweenFOV.Begin(BJGCPDNMHDH.gameObject, BJGCPDNMHDH.MEFBOPIEMED, BJGCPDNMHDH.ECFEPPBGAIO);
				goto case 4u;
			case 4u:
				if (COOGKNIEOPA < 749f)
				{
					COOGKNIEOPA = Mathf.Clamp01((Time.realtimeSinceStartup - LADMMFLMOLE) / BJGCPDNMHDH.MEFBOPIEMED);
					OLMEMGGNKGF = BJGCPDNMHDH.OPBPBKGFLLO.Evaluate(COOGKNIEOPA);
					BJGCPDNMHDH.transform.position = Vector3.Lerp(JKGKCGHALHH, LIIDNBJLGKK, OLMEMGGNKGF);
					BJGCPDNMHDH.transform.rotation = Quaternion.Lerp(EFAOLNCNJFG, HNFNAFCNCMK, OLMEMGGNKGF);
					PHDOCKCBJOF = 0;
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
	}

	public GameObject FKFDNNPBOFI;

	public CameraPlayerFollow.ThirdPersoncameraDefinition OJIIEFMCBHI;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Action EGLJLPCCBHL;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action HLELJGBNBEG;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action DLIKOHNGKIO;

	private float JODMDEAEEHE;

	private Camera GNICEGBOGOL;

	public float NBAAPLMCCJJ = 0.5f;

	public float BGHBLOIHDOB = 0.8f;

	public float JLHFPANIKPO = 0.5f;

	public float ALKLGAKEICE = 0.8f;

	private Transform NGCDDPCAGJB;

	private BKKKEBHEFPI PDLJPAKACDM;

	private BKKKEBHEFPI DNPJGODEPON;

	private CameraPlayerFollow ECPHFACGEIE;

	public float PPNDNOHMBKH;

	public float DBKEIAILHKD;

	public List<Vector3> GDAFLEDIOJP;

	public List<Quaternion> JPMGIHOPPCH;

	public float BHANGOBFOHH = 4f;

	public float BJIPJGFPIAJ = 4f;

	public float MOMGGEKOBDC = 2f;

	private readonly List<Vector3> LCIECDBFPFF = new List<Vector3>();

	[Header("Focus Enemy Animation")]
	public float EHFLEBJNBLN = 1f;

	public float LINAKKNHIMN = 2f;

	public float LAEADIDHNGP = 0.3f;

	public float FCJAGHDNONI = 0.2f;

	public float DMOJKNBFAIG = 0.2f;

	public float ECFEPPBGAIO = 70f;

	public float LNIPMGOFEJN = 0.5f;

	public Vector2 AMMELLKBLID = new Vector2(1f, 0.25f);

	public float APHOIGGJEJH = 0.35f;

	public float NGLBIAMOBHF = 0.2f;

	public float MKBOFBPMAKK = 10f;

	public AnimationCurve CMGCJMNLCPB;

	public AnimationCurve OPBPBKGFLLO;

	public float HNGMFABKLKF = 1f;

	public float FFBCLAAGOEK = 8f;

	public float JCAOCHMKFOI = 1f;

	public AnimationCurve BLCBHCPDOLO;

	public AnimationCurve NDNCOKHKKFM;

	public AnimationCurve FJGHEKIIIJJ;

	public float GDCIBDACJDL = 4f;

	public float MEFBOPIEMED = 1f;

	private PlayerWeapon KDMMCFKPAIC;

	private TweenFOV DONBAHPHKMK;

	private bool MMICNPGHHEM = true;

	private bool LNCOOICJBOI;

	private Quaternion AEEFNAGJNMN;

	private bool BFOLCPKOJIJ;

	private Vector3 AGPLEANDGFF;

	private int PKDLNCNNKAB;

	private PlayerController JDGADCDMFHM;

	[CompilerGenerated]
	private static Action IONHPHFCBGH;

	[CompilerGenerated]
	private static Action KBGCLEMGDHO;

	[CompilerGenerated]
	private static Action JNFIADMBDDB;

	public Camera camera
	{
		get
		{
			if (GNICEGBOGOL == null)
			{
				GNICEGBOGOL = GetComponentsInChildren<Camera>(true)[0];
			}
			return GNICEGBOGOL;
		}
	}

	private float PNKCLMJBMNI
	{
		get
		{
			return (!ScreenManager.isSmallScreen) ? 52 : 34;
		}
	}

	public event Action AnimationFinished
	{
		add
		{
			Action action = EGLJLPCCBHL;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref EGLJLPCCBHL, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = EGLJLPCCBHL;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref EGLJLPCCBHL, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public event Action AnimationOnPlayerStop
	{
		add
		{
			Action action = HLELJGBNBEG;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref HLELJGBNBEG, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = HLELJGBNBEG;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref HLELJGBNBEG, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public event Action SingleAnimationFinished
	{
		add
		{
			Action action = DLIKOHNGKIO;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref DLIKOHNGKIO, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = DLIKOHNGKIO;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref DLIKOHNGKIO, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public void KBHFPBMIAKP(PlayerController KHLGDCHJJPB, bool GIBNBNNGOCA)
	{
		MMICNPGHHEM = true;
		FKFDNNPBOFI.gameObject.SetActive(false);
		ECPHFACGEIE.enabled = true;
		Singleton<PerformanceManager>.instance.AGMMGEJNAMD(true);
		if (KHLGDCHJJPB.fraction == PlayerController.OGMBJPKOPCB.fraction)
		{
			if (Singleton<GameController>.instance.IMEJOPKIKOD() || Singleton<GameController>.instance.isCoop)
			{
				UnityEngine.Debug.Log("ID_CONFIRM_ERROR");
				StartCoroutine(BHEJICEBOGM(KHLGDCHJJPB));
			}
			else
			{
				StartCoroutine(KKGJNKBHLJH(KHLGDCHJJPB));
			}
		}
		else
		{
			StartCoroutine(RadicalRoutine.Run(KKEBEKJBDDE(KHLGDCHJJPB, GIBNBNNGOCA)));
		}
	}

	public void SetFollowedActive(bool DDKAFCNJKIP)
	{
		ECPHFACGEIE.enabled = DDKAFCNJKIP;
	}

	private CameraPathAnimator HAFIMKGAGON()
	{
		return PlayerController.OGMBJPKOPCB.currentPlayerPoint.cameraPath;
	}

	private void PMJGBGBJGAD(UITweener MGDJMGHCAAI)
	{
		MMICNPGHHEM = true;
		ECPHFACGEIE.enabled = true;
	}

	private void OEACJGJDHBB()
	{
		CameraPathAnimator cameraPathAnimator = HAFIMKGAGON();
		CameraPath cameraPath = cameraPathAnimator.cameraPath;
		Vector3 position = Singleton<GameController>.instance.opponent.currentPlayerPoint.point.transform.position;
		float nearestPoint = cameraPath.GetNearestPoint(position, false);
		LCIECDBFPFF.Add(position);
		CameraPathDelay cameraPathDelay = cameraPath.delayList[1];
		cameraPathDelay.percent = nearestPoint;
		cameraPath.eventList[0].percent = nearestPoint;
	}

	private void DMIICHDJOFK(PlayerController.KKPHPLOEACG PKJAIKIGBOO)
	{
		if (PKJAIKIGBOO == PlayerController.KKPHPLOEACG.HidingBehindShield)
		{
			LNCOOICJBOI = false;
			ECPHFACGEIE.GIFJOLADLEB = OJIIEFMCBHI;
		}
		if (PKJAIKIGBOO == PlayerController.KKPHPLOEACG.HidingBehindShield)
		{
			KDMMCFKPAIC = JDGADCDMFHM.BEIIOAIJMFK().MFHBEJOLGLC();
			LNCOOICJBOI = false;
			ECPHFACGEIE.GIFJOLADLEB = KDMMCFKPAIC.DFJLLCGEPGH;
		}
		OLPCPFOLBNP();
	}

	[SpecialName]
	public void GAGCNEBEGPI(Action IDEBKDPMPGM)
	{
		Action action = DLIKOHNGKIO;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DLIKOHNGKIO, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private IEnumerator IHFBFMEGPIA(PlayerController KHLGDCHJJPB)
	{
		DEMDEMKGBAF dEMDEMKGBAF = new DEMDEMKGBAF();
		dEMDEMKGBAF.KHLGDCHJJPB = KHLGDCHJJPB;
		dEMDEMKGBAF.BJGCPDNMHDH = this;
		return dEMDEMKGBAF;
	}

	private void OLPCPFOLBNP()
	{
		if (ScreenManager.isSmallScreen)
		{
			ECPHFACGEIE.GIFJOLADLEB.distanceScale = 1577f;
			ECPHFACGEIE.GIFJOLADLEB.scale = 1926f;
			ECPHFACGEIE.GIFJOLADLEB.fwScale = 47f;
		}
		else
		{
			ECPHFACGEIE.GIFJOLADLEB.distanceScale = 1092f;
			ECPHFACGEIE.GIFJOLADLEB.scale = 606f;
			ECPHFACGEIE.GIFJOLADLEB.fwScale = 1509f;
		}
	}

	public IEnumerator HIFIIAIAJKP()
	{
		PGGPOFLKAGC pGGPOFLKAGC = new PGGPOFLKAGC();
		pGGPOFLKAGC.BJGCPDNMHDH = this;
		return pGGPOFLKAGC;
	}

	public void SetTarget(PlayerController KHLGDCHJJPB)
	{
		ECPHFACGEIE.enabled = true;
		ECPHFACGEIE.MKIPAEDAADL = KHLGDCHJJPB;
		if (JDGADCDMFHM != null)
		{
			JDGADCDMFHM.PlayerStateChanged -= DIIOPOIKNGK;
		}
		JDGADCDMFHM = KHLGDCHJJPB;
		JDGADCDMFHM.PlayerStateChanged -= DIIOPOIKNGK;
		JDGADCDMFHM.PlayerStateChanged += DIIOPOIKNGK;
		TweenPosition component = GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenRotation component2 = GetComponent<TweenRotation>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		StopAllCoroutines();
		TweenFOV.Begin(base.gameObject, 1f, PNKCLMJBMNI);
	}

	private void KDJNGBIBHLI()
	{
		BFOLCPKOJIJ = false;
		ECPHFACGEIE.GIFJOLADLEB = JDGADCDMFHM.weaponInventory.OLHICLNCPNA().DFJLLCGEPGH;
		ECPHFACGEIE.MKIPAEDAADL = JDGADCDMFHM;
		PMFECCJAKCI();
		CameraPathAnimator cameraPathAnimator = HAFIMKGAGON();
		cameraPathAnimator.AnimationFinishedEvent -= OGICJAFFPAL;
		if (EGLJLPCCBHL != null)
		{
			EGLJLPCCBHL();
		}
	}

	public void OHLBGBAPOAE()
	{
		Enable();
		OGICJAFFPAL();
		ECPHFACGEIE.FOILEDGBICE();
		ECPHFACGEIE.enabled = false;
	}

	[DebuggerHidden]
	private IEnumerator GKCLCOADDLM(EnemyController NNHIBOBPMPE)
	{
		LPAFBENCBJI lPAFBENCBJI = new LPAFBENCBJI();
		lPAFBENCBJI.NNHIBOBPMPE = NNHIBOBPMPE;
		lPAFBENCBJI.BJGCPDNMHDH = this;
		return lPAFBENCBJI;
	}

	private void PODOLBHIKBH()
	{
		if (ScreenManager.isSmallScreen)
		{
			ECPHFACGEIE.GIFJOLADLEB.distanceScale = 1.62f;
			ECPHFACGEIE.GIFJOLADLEB.scale = 1f;
			ECPHFACGEIE.GIFJOLADLEB.fwScale = 2.41f;
		}
		else
		{
			ECPHFACGEIE.GIFJOLADLEB.distanceScale = 1f;
			ECPHFACGEIE.GIFJOLADLEB.scale = 1f;
			ECPHFACGEIE.GIFJOLADLEB.fwScale = 1f;
		}
	}

	public void HLLODJKPDPK()
	{
		HEANFGONCBJ().cullingMask = PKDLNCNNKAB;
		CAGAKKADGDG().enabled = false;
		FKFDNNPBOFI.gameObject.SetActive(true);
	}

	public void MEKHLFKJEKD()
	{
		float num = 521f;
		TweenFOV.Begin(base.gameObject, num, PKFIMNPJMPK());
		TweenRotation tweenRotation = TweenRotation.Begin(base.gameObject, num * 1102f, AEEFNAGJNMN, true);
		TweenPosition.Begin(base.gameObject, num, base.transform.position, AGPLEANDGFF, false);
		tweenRotation.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenRotation.onFinished, (UITweener.OnFinished)delegate
		{
			ECPHFACGEIE.enabled = true;
		});
	}

	[DebuggerHidden]
	private IEnumerator LKDGAIEEHHP(PlayerController KHLGDCHJJPB)
	{
		ILPLKEMPGIH iLPLKEMPGIH = new ILPLKEMPGIH();
		iLPLKEMPGIH.KHLGDCHJJPB = KHLGDCHJJPB;
		iLPLKEMPGIH.BJGCPDNMHDH = this;
		return iLPLKEMPGIH;
	}

	private void EONJDJOBMMK()
	{
		if (ScreenManager.isSmallScreen)
		{
			ECPHFACGEIE.GIFJOLADLEB.distanceScale = 1334f;
			ECPHFACGEIE.GIFJOLADLEB.scale = 1452f;
			ECPHFACGEIE.GIFJOLADLEB.fwScale = 653f;
		}
		else
		{
			ECPHFACGEIE.GIFJOLADLEB.distanceScale = 976f;
			ECPHFACGEIE.GIFJOLADLEB.scale = 81f;
			ECPHFACGEIE.GIFJOLADLEB.fwScale = 753f;
		}
	}

	protected virtual void HFKIAIEGNGI()
	{
		base.Start();
		SetTarget(PlayerController.OGMBJPKOPCB);
	}

	public void AIDAFGCCCDO(PlayerController KHLGDCHJJPB)
	{
		ECPHFACGEIE.enabled = false;
		ECPHFACGEIE.MKIPAEDAADL = KHLGDCHJJPB;
		if (JDGADCDMFHM != null)
		{
			JDGADCDMFHM.PONCLMNBAJM(DMIICHDJOFK);
		}
		JDGADCDMFHM = KHLGDCHJJPB;
		JDGADCDMFHM.PlayerStateChanged -= MBHPMIGOGNL;
		JDGADCDMFHM.MGODCJLIBAE(DMIICHDJOFK);
		TweenPosition component = GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenRotation component2 = GetComponent<TweenRotation>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		StopAllCoroutines();
		TweenFOV.Begin(base.gameObject, 1168f, PKFIMNPJMPK());
	}

	private void DIIOPOIKNGK(PlayerController.KKPHPLOEACG PKJAIKIGBOO)
	{
		if (PKJAIKIGBOO == PlayerController.KKPHPLOEACG.Walking)
		{
			LNCOOICJBOI = true;
			ECPHFACGEIE.GIFJOLADLEB = OJIIEFMCBHI;
		}
		if (PKJAIKIGBOO == PlayerController.KKPHPLOEACG.HidingBehindShield)
		{
			KDMMCFKPAIC = JDGADCDMFHM.weaponInventory.currentWeapon;
			LNCOOICJBOI = false;
			ECPHFACGEIE.GIFJOLADLEB = KDMMCFKPAIC.DFJLLCGEPGH;
		}
		PODOLBHIKBH();
	}

	private void GLICCCKMDHE(string DDLNDBANBHK)
	{
		CameraPathAnimator cameraPathAnimator = HAFIMKGAGON();
		cameraPathAnimator.AnimationCustomEvent -= GLICCCKMDHE;
		if (HLELJGBNBEG != null)
		{
			HLELJGBNBEG();
		}
	}

	public void LNDHIADPMGP()
	{
		LBBFBJMLEJB().cullingMask = 0;
		JLJAJAMJJJM().enabled = false;
		FKFDNNPBOFI.gameObject.SetActive(true);
	}

	protected override void Awake()
	{
		base.Awake();
		Singleton<GameController>.instance.BeforeGameStarted += ENMHEEHAIHC;
		Singleton<GameController>.instance.SceneFreed += NOICEJMDDPN;
		NGCDDPCAGJB = base.transform;
		GNICEGBOGOL = GetComponent<Camera>();
		PKDLNCNNKAB = camera.cullingMask;
		camera.fieldOfView = PNKCLMJBMNI;
		PDLJPAKACDM = new BKKKEBHEFPI(NGCDDPCAGJB, BKKKEBHEFPI.NBAOBLLJBEF.PositionAdditive, false)
		{
			GCLDEPBBIKB = new Vector3(NBAAPLMCCJJ, NBAAPLMCCJJ, NBAAPLMCCJJ),
			DOFNFNCMCPC = Vector3.one - new Vector3(BGHBLOIHDOB, BGHBLOIHDOB, BGHBLOIHDOB),
			LFLPCDLFGNC = Vector3.zero,
			JLANLLEABDC = Vector3.zero,
			ECCFEECFMOP = -0.01f * Vector3.one,
			KKPEFBEIJLA = 0.01f * Vector3.one
		};
		DNPJGODEPON = new BKKKEBHEFPI(NGCDDPCAGJB, BKKKEBHEFPI.NBAOBLLJBEF.PositionAdditive, false)
		{
			GCLDEPBBIKB = new Vector3(JLHFPANIKPO, JLHFPANIKPO, JLHFPANIKPO),
			DOFNFNCMCPC = Vector3.one - new Vector3(ALKLGAKEICE, ALKLGAKEICE, ALKLGAKEICE),
			LFLPCDLFGNC = Vector3.zero,
			JLANLLEABDC = Vector3.zero,
			ECCFEECFMOP = -0.25f * Vector3.one,
			KKPEFBEIJLA = 0.25f * Vector3.one
		};
		ECPHFACGEIE = GetComponent<CameraPlayerFollow>();
		camera.cullingMask = 0;
		FKFDNNPBOFI.gameObject.SetActive(false);
		UnityEngine.Debug.Log(camera.depthTextureMode);
	}

	private void PMFECCJAKCI()
	{
		if (ScreenManager.isSmallScreen)
		{
			ECPHFACGEIE.GIFJOLADLEB.distanceScale = 1385f;
			ECPHFACGEIE.GIFJOLADLEB.scale = 1322f;
			ECPHFACGEIE.GIFJOLADLEB.fwScale = 466f;
		}
		else
		{
			ECPHFACGEIE.GIFJOLADLEB.distanceScale = 95f;
			ECPHFACGEIE.GIFJOLADLEB.scale = 1853f;
			ECPHFACGEIE.GIFJOLADLEB.fwScale = 675f;
		}
	}

	public void StartTutorialCamera()
	{
		Enable();
		OGICJAFFPAL();
		ECPHFACGEIE.ForceSet();
		ECPHFACGEIE.enabled = true;
	}

	[SpecialName]
	private float PKFIMNPJMPK()
	{
		return (!ScreenManager.isSmallScreen) ? (-7) : (-67);
	}

	private IEnumerator APLEOCEHJFA(PlayerController KHLGDCHJJPB)
	{
		ILPLKEMPGIH iLPLKEMPGIH = new ILPLKEMPGIH();
		iLPLKEMPGIH.KHLGDCHJJPB = KHLGDCHJJPB;
		iLPLKEMPGIH.BJGCPDNMHDH = this;
		return iLPLKEMPGIH;
	}

	[SpecialName]
	public Camera JLJAJAMJJJM()
	{
		if (GNICEGBOGOL == null)
		{
			GNICEGBOGOL = GetComponentsInChildren<Camera>(false)[1];
		}
		return GNICEGBOGOL;
	}

	public void PFBCLMECEHL(PlayerController KHLGDCHJJPB)
	{
		float num = 1983f;
		ECPHFACGEIE.enabled = false;
		AEEFNAGJNMN = base.transform.rotation;
		AGPLEANDGFF = base.transform.position;
		TweenFOV.Begin(base.gameObject, num, 618f);
		Vector3 vector = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position + KHLGDCHJJPB.transform.forward * 1188f + KHLGDCHJJPB.transform.right * 601f + Vector3.up * 758f;
		Vector3 vector2 = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position + Vector3.up * 571f;
		TweenRotation tweenRotation = TweenRotation.Begin(base.gameObject, num * 1503f, Quaternion.LookRotation(vector2 - vector), true);
		tweenRotation.delay = num * 11f;
		TweenPosition.Begin(base.gameObject, num, base.transform.position, vector, false);
	}

	public void ShootShake()
	{
		if (MMICNPGHHEM)
		{
			PDLJPAKACDM.COGPBBOLBOM(new Vector3(0f, -0.06f, 0f));
		}
	}

	[SpecialName]
	public Camera LBBFBJMLEJB()
	{
		if (GNICEGBOGOL == null)
		{
			GNICEGBOGOL = GetComponentsInChildren<Camera>(false)[0];
		}
		return GNICEGBOGOL;
	}

	public void HitShake()
	{
		ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.HitShakeFrequency).FLOATVALUE;
		if (MMICNPGHHEM && Time.realtimeSinceStartup > JODMDEAEEHE + (float)fLOATVALUE)
		{
			JODMDEAEEHE = Time.realtimeSinceStartup;
			Vector2 vector = UnityEngine.Random.insideUnitCircle.normalized * 0.3f;
			if (DNPJGODEPON.JLANLLEABDC != DNPJGODEPON.LFLPCDLFGNC)
			{
				vector *= 0.5f;
			}
			DNPJGODEPON.COGPBBOLBOM(new Vector3(0f, vector.x, vector.y));
		}
	}

	public void UnfocusTutorial()
	{
		float num = 2f;
		TweenFOV.Begin(base.gameObject, num, PNKCLMJBMNI);
		TweenRotation tweenRotation = TweenRotation.Begin(base.gameObject, num * 0.6f, AEEFNAGJNMN);
		TweenPosition.Begin(base.gameObject, num, base.transform.position, AGPLEANDGFF, false);
		tweenRotation.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenRotation.onFinished, (UITweener.OnFinished)delegate
		{
			ECPHFACGEIE.enabled = true;
		});
	}

	private void DJNOFKCJOPJ()
	{
		AIDAFGCCCDO(PlayerController.OGMBJPKOPCB);
		GNICEGBOGOL.depthTextureMode = DepthTextureMode.Depth;
		MMICNPGHHEM = false;
	}

	public void NFKBMNLBLIM(EnemyController NNHIBOBPMPE)
	{
		MMICNPGHHEM = false;
		FKFDNNPBOFI.gameObject.SetActive(false);
		ECPHFACGEIE.enabled = false;
		Singleton<PerformanceManager>.instance.AOBNCIOGFKA(false);
		StartCoroutine(RadicalRoutine.Run(GKCLCOADDLM(NNHIBOBPMPE)));
	}

	[SpecialName]
	public Camera CAGAKKADGDG()
	{
		if (GNICEGBOGOL == null)
		{
			GNICEGBOGOL = GetComponentsInChildren<Camera>(false)[0];
		}
		return GNICEGBOGOL;
	}

	private void ANNNAEEIMOF(UITweener MGDJMGHCAAI)
	{
		MMICNPGHHEM = false;
		ECPHFACGEIE.enabled = true;
	}

	public void FocusBoss(EnemyController NNHIBOBPMPE)
	{
		MMICNPGHHEM = false;
		FKFDNNPBOFI.gameObject.SetActive(false);
		ECPHFACGEIE.enabled = false;
		Singleton<PerformanceManager>.instance.SetShadowsDistance(true);
		StartCoroutine(RadicalRoutine.Run(GKCLCOADDLM(NNHIBOBPMPE)));
	}

	public void KPOCOCMEJLC(PlayerController KHLGDCHJJPB)
	{
		float num = 120f;
		ECPHFACGEIE.enabled = false;
		AEEFNAGJNMN = base.transform.rotation;
		AGPLEANDGFF = base.transform.position;
		TweenFOV.Begin(base.gameObject, num, 566f);
		Vector3 vector = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[0].transform.position + KHLGDCHJJPB.transform.forward * 1518f + KHLGDCHJJPB.transform.right * 1876f + Vector3.up * 1251f;
		Vector3 vector2 = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position + Vector3.up * 1739f;
		TweenRotation tweenRotation = TweenRotation.Begin(base.gameObject, num * 805f, Quaternion.LookRotation(vector2 - vector), true);
		tweenRotation.delay = num * 950f;
		TweenPosition.Begin(base.gameObject, num, base.transform.position, vector, false);
	}

	private void OGICJAFFPAL()
	{
		BFOLCPKOJIJ = false;
		ECPHFACGEIE.GIFJOLADLEB = JDGADCDMFHM.weaponInventory.currentWeapon.DFJLLCGEPGH;
		ECPHFACGEIE.MKIPAEDAADL = JDGADCDMFHM;
		PODOLBHIKBH();
		CameraPathAnimator cameraPathAnimator = HAFIMKGAGON();
		cameraPathAnimator.AnimationFinishedEvent -= OGICJAFFPAL;
		if (EGLJLPCCBHL != null)
		{
			EGLJLPCCBHL();
		}
	}

	public void Enable()
	{
		camera.cullingMask = PKDLNCNNKAB;
		camera.enabled = true;
		FKFDNNPBOFI.gameObject.SetActive(true);
	}

	[CompilerGenerated]
	private void EKMKIEDMNMF(UITweener MGDJMGHCAAI)
	{
		ECPHFACGEIE.enabled = true;
	}

	[SpecialName]
	public Camera HIFFNOAFCOC()
	{
		if (GNICEGBOGOL == null)
		{
			GNICEGBOGOL = GetComponentsInChildren<Camera>(true)[0];
		}
		return GNICEGBOGOL;
	}

	[DebuggerHidden]
	private IEnumerator KKEBEKJBDDE(PlayerController KHLGDCHJJPB, bool GIBNBNNGOCA)
	{
		CMKGCGFGHGL cMKGCGFGHGL = new CMKGCGFGHGL();
		cMKGCGFGHGL.GIBNBNNGOCA = GIBNBNNGOCA;
		cMKGCGFGHGL.KHLGDCHJJPB = KHLGDCHJJPB;
		cMKGCGFGHGL.BJGCPDNMHDH = this;
		return cMKGCGFGHGL;
	}

	public void LGAJJBGFAFD(bool DDKAFCNJKIP)
	{
		ECPHFACGEIE.enabled = DDKAFCNJKIP;
	}

	private void MGKNKCEICMN(string DDLNDBANBHK)
	{
		CameraPathAnimator cameraPathAnimator = HAFIMKGAGON();
		cameraPathAnimator.AnimationCustomEvent -= GLICCCKMDHE;
		if (HLELJGBNBEG != null)
		{
			HLELJGBNBEG();
		}
	}

	[DebuggerHidden]
	public IEnumerator SingleCameraAnimation(float KBJEOEEOEFG = 2f)
	{
		CDKNAFJNELJ cDKNAFJNELJ = new CDKNAFJNELJ();
		cDKNAFJNELJ.KBJEOEEOEFG = KBJEOEEOEFG;
		cDKNAFJNELJ.BJGCPDNMHDH = this;
		return cDKNAFJNELJ;
	}

	public void NHOJNBPKBFP()
	{
		HLLODJKPDPK();
		KDJNGBIBHLI();
		ECPHFACGEIE.PEJFNCOEHEL();
		ECPHFACGEIE.enabled = true;
	}

	public void LODMODJFFBE(PlayerController KHLGDCHJJPB, bool GIBNBNNGOCA)
	{
		MMICNPGHHEM = false;
		FKFDNNPBOFI.gameObject.SetActive(true);
		ECPHFACGEIE.enabled = true;
		Singleton<PerformanceManager>.instance.FDFJMPCABLN(true);
		if (KHLGDCHJJPB.fraction == PlayerController.OGMBJPKOPCB.fraction)
		{
			if (Singleton<GameController>.instance.HMBNJHKKIPJ() || Singleton<GameController>.instance.MNPNHJKBNCJ())
			{
				UnityEngine.Debug.Log("BeAdvisedJoinOrCreateSquad");
				StartCoroutine(BHEJICEBOGM(KHLGDCHJJPB));
			}
			else
			{
				StartCoroutine(APLEOCEHJFA(KHLGDCHJJPB));
			}
		}
		else
		{
			StartCoroutine(RadicalRoutine.Run(KKEBEKJBDDE(KHLGDCHJJPB, GIBNBNNGOCA)));
		}
	}

	public void GGDHCIOCAMB(bool DDKAFCNJKIP)
	{
		ECPHFACGEIE.enabled = DDKAFCNJKIP;
	}

	public void LNCHKBAIKEK()
	{
		CAGAKKADGDG().cullingMask = 0;
		JLJAJAMJJJM().enabled = true;
		FKFDNNPBOFI.gameObject.SetActive(false);
	}

	protected void Update()
	{
		if (BFOLCPKOJIJ || !(Time.timeScale > 0.001f))
		{
			return;
		}
		if (MMICNPGHHEM && PDLJPAKACDM != null)
		{
			PDLJPAKACDM.GGCOLMKICEC();
			DNPJGODEPON.GGCOLMKICEC();
		}
		if (!LNCOOICJBOI && !(JDGADCDMFHM == null))
		{
			PlayerWeapon currentWeapon = JDGADCDMFHM.weaponInventory.currentWeapon;
			if (currentWeapon != KDMMCFKPAIC || KDMMCFKPAIC == null)
			{
				KDMMCFKPAIC = currentWeapon;
				ECPHFACGEIE.GIFJOLADLEB = KDMMCFKPAIC.DFJLLCGEPGH;
				PODOLBHIKBH();
			}
			if (DONBAHPHKMK != null && !MMICNPGHHEM)
			{
			}
		}
	}

	private void NOICEJMDDPN()
	{
		GNICEGBOGOL.depthTextureMode = DepthTextureMode.None;
	}

	[SpecialName]
	public Camera HEANFGONCBJ()
	{
		if (GNICEGBOGOL == null)
		{
			GNICEGBOGOL = GetComponentsInChildren<Camera>(false)[0];
		}
		return GNICEGBOGOL;
	}

	private IEnumerator KKGJNKBHLJH(PlayerController KHLGDCHJJPB)
	{
		ILPLKEMPGIH iLPLKEMPGIH = new ILPLKEMPGIH();
		iLPLKEMPGIH.KHLGDCHJJPB = KHLGDCHJJPB;
		iLPLKEMPGIH.BJGCPDNMHDH = this;
		return iLPLKEMPGIH;
	}

	private void ENMHEEHAIHC()
	{
		SetTarget(PlayerController.OGMBJPKOPCB);
		GNICEGBOGOL.depthTextureMode = DepthTextureMode.None;
		MMICNPGHHEM = true;
	}

	[DebuggerHidden]
	public IEnumerator StartBeginAnimation()
	{
		PGGPOFLKAGC pGGPOFLKAGC = new PGGPOFLKAGC();
		pGGPOFLKAGC.BJGCPDNMHDH = this;
		return pGGPOFLKAGC;
	}

	[DebuggerHidden]
	private IEnumerator BHEJICEBOGM(PlayerController KHLGDCHJJPB)
	{
		DEMDEMKGBAF dEMDEMKGBAF = new DEMDEMKGBAF();
		dEMDEMKGBAF.KHLGDCHJJPB = KHLGDCHJJPB;
		dEMDEMKGBAF.BJGCPDNMHDH = this;
		return dEMDEMKGBAF;
	}

	private void MBHPMIGOGNL(PlayerController.KKPHPLOEACG PKJAIKIGBOO)
	{
		if (PKJAIKIGBOO == PlayerController.KKPHPLOEACG.HidingBehindShield)
		{
			LNCOOICJBOI = true;
			ECPHFACGEIE.GIFJOLADLEB = OJIIEFMCBHI;
		}
		if (PKJAIKIGBOO == PlayerController.KKPHPLOEACG.HidingBehindShield)
		{
			KDMMCFKPAIC = JDGADCDMFHM.JLMDEMFIHCA().LJELEJEJIEB();
			LNCOOICJBOI = false;
			ECPHFACGEIE.GIFJOLADLEB = KDMMCFKPAIC.DFJLLCGEPGH;
		}
		KLDMKPKIEHB();
	}

	public void Disable()
	{
		camera.cullingMask = 0;
		camera.enabled = false;
		FKFDNNPBOFI.gameObject.SetActive(false);
	}

	private void POPJOMMBKOF()
	{
		CameraPathAnimator cameraPathAnimator = HAFIMKGAGON();
		CameraPath cameraPath = cameraPathAnimator.cameraPath;
		Vector3 position = Singleton<GameController>.instance.opponent.BBNPGJAALCJ().point.transform.position;
		float nearestPoint = cameraPath.GetNearestPoint(position, true);
		LCIECDBFPFF.Add(position);
		CameraPathDelay cameraPathDelay = cameraPath.delayList[1];
		cameraPathDelay.percent = nearestPoint;
		cameraPath.eventList[1].percent = nearestPoint;
	}

	public IEnumerator JGDIFKHNHGE()
	{
		PGGPOFLKAGC pGGPOFLKAGC = new PGGPOFLKAGC();
		pGGPOFLKAGC.BJGCPDNMHDH = this;
		return pGGPOFLKAGC;
	}

	private void MOENINKKCML()
	{
		BFOLCPKOJIJ = false;
		ECPHFACGEIE.GIFJOLADLEB = JDGADCDMFHM.BEIIOAIJMFK().CILCMCDCKKE().DFJLLCGEPGH;
		ECPHFACGEIE.MKIPAEDAADL = JDGADCDMFHM;
		EONJDJOBMMK();
		CameraPathAnimator cameraPathAnimator = HAFIMKGAGON();
		cameraPathAnimator.AnimationFinishedEvent -= KDJNGBIBHLI;
		if (EGLJLPCCBHL != null)
		{
			EGLJLPCCBHL();
		}
	}

	public void FocusEnemyPlayerTutorial(PlayerController KHLGDCHJJPB)
	{
		float num = 2f;
		ECPHFACGEIE.enabled = false;
		AEEFNAGJNMN = base.transform.rotation;
		AGPLEANDGFF = base.transform.position;
		TweenFOV.Begin(base.gameObject, num, 40f);
		Vector3 vector = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position + KHLGDCHJJPB.transform.forward * 1.5f + KHLGDCHJJPB.transform.right * 1f + Vector3.up * 1.2f;
		Vector3 vector2 = KHLGDCHJJPB.FOCIOKMPCAG.AMEELJHHGKP[1].transform.position + Vector3.up * 0.25f;
		TweenRotation tweenRotation = TweenRotation.Begin(base.gameObject, num * 0.6f, Quaternion.LookRotation(vector2 - vector));
		tweenRotation.delay = num * 0.3f;
		TweenPosition.Begin(base.gameObject, num, base.transform.position, vector, false);
	}

	private void DDJADHBHGIO()
	{
		CameraPathAnimator cameraPathAnimator = HAFIMKGAGON();
		CameraPath cameraPath = cameraPathAnimator.cameraPath;
		Vector3 position = Singleton<GameController>.instance.opponent.currentPlayerPoint.point.transform.position;
		float nearestPoint = cameraPath.GetNearestPoint(position, true);
		LCIECDBFPFF.Add(position);
		CameraPathDelay cameraPathDelay = cameraPath.delayList[1];
		cameraPathDelay.percent = nearestPoint;
		cameraPath.eventList[0].percent = nearestPoint;
	}

	public void EDBCNPJDDNB(bool DDKAFCNJKIP)
	{
		ECPHFACGEIE.enabled = DDKAFCNJKIP;
	}

	private void KLDMKPKIEHB()
	{
		if (ScreenManager.isSmallScreen)
		{
			ECPHFACGEIE.GIFJOLADLEB.distanceScale = 307f;
			ECPHFACGEIE.GIFJOLADLEB.scale = 940f;
			ECPHFACGEIE.GIFJOLADLEB.fwScale = 851f;
		}
		else
		{
			ECPHFACGEIE.GIFJOLADLEB.distanceScale = 404f;
			ECPHFACGEIE.GIFJOLADLEB.scale = 476f;
			ECPHFACGEIE.GIFJOLADLEB.fwScale = 262f;
		}
	}

	protected override void Start()
	{
		base.Start();
		SetTarget(PlayerController.OGMBJPKOPCB);
	}

	[SpecialName]
	public void BFMNLCJDPNG(Action IDEBKDPMPGM)
	{
		Action action = EGLJLPCCBHL;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref EGLJLPCCBHL, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void PGOKOPPJINA()
	{
		float num = 1654f;
		TweenFOV.Begin(base.gameObject, num, PNKCLMJBMNI);
		TweenRotation tweenRotation = TweenRotation.Begin(base.gameObject, num * 426f, AEEFNAGJNMN, true);
		TweenPosition.Begin(base.gameObject, num, base.transform.position, AGPLEANDGFF);
		tweenRotation.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenRotation.onFinished, (UITweener.OnFinished)delegate
		{
			ECPHFACGEIE.enabled = true;
		});
	}

	public void JKJNLCILLPC()
	{
		float num = 172f;
		TweenFOV.Begin(base.gameObject, num, PKFIMNPJMPK());
		TweenRotation tweenRotation = TweenRotation.Begin(base.gameObject, num * 554f, AEEFNAGJNMN, true);
		TweenPosition.Begin(base.gameObject, num, base.transform.position, AGPLEANDGFF);
		tweenRotation.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenRotation.onFinished, (UITweener.OnFinished)delegate
		{
			ECPHFACGEIE.enabled = true;
		});
	}

	private void BMMPJEMJNAH()
	{
		GNICEGBOGOL.depthTextureMode = DepthTextureMode.None;
	}

	private void ICOPDCLKPAL()
	{
		GNICEGBOGOL.depthTextureMode = DepthTextureMode.Depth;
	}

	[SpecialName]
	public void NHAGLMBNNJM(Action IDEBKDPMPGM)
	{
		Action action = EGLJLPCCBHL;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref EGLJLPCCBHL, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void FocusPlayer(PlayerController KHLGDCHJJPB, bool GIBNBNNGOCA)
	{
		MMICNPGHHEM = false;
		FKFDNNPBOFI.gameObject.SetActive(false);
		ECPHFACGEIE.enabled = false;
		Singleton<PerformanceManager>.instance.SetShadowsDistance(true);
		if (KHLGDCHJJPB.fraction == PlayerController.OGMBJPKOPCB.fraction)
		{
			if (Singleton<GameController>.instance.isCampaign || Singleton<GameController>.instance.isCoop)
			{
				UnityEngine.Debug.Log("FOCUS CAMPAIGN!!!!");
				StartCoroutine(BHEJICEBOGM(KHLGDCHJJPB));
			}
			else
			{
				StartCoroutine(LKDGAIEEHHP(KHLGDCHJJPB));
			}
		}
		else
		{
			StartCoroutine(RadicalRoutine.Run(KKEBEKJBDDE(KHLGDCHJJPB, GIBNBNNGOCA)));
		}
	}
}
