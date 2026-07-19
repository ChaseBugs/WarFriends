using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DailyMissionScreen : GuiScreenSingle<DailyMissionScreen>
{
	private sealed class ECOBAHHPEFM
	{
		internal float PAENPHMEMGC;

		internal DailyMissionScreen BJGCPDNMHDH;

		internal void MAKLHLCDIKD(UITweener MGDJMGHCAAI)
		{
			TweenProgressBar tweenProgressBar = TweenProgressBar.IECHDKECJAB(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, 978f, new NHOGNBCNIEK(PAENPHMEMGC));
			tweenProgressBar.onFinished = BFMHIICIHKL;
		}

		internal void DDHOKNIEACI(UITweener MGDJMGHCAAI)
		{
			TweenProgressBar tweenProgressBar = TweenProgressBar.DFNHCFNJCMC(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, 568f, new NHOGNBCNIEK(PAENPHMEMGC));
			tweenProgressBar.onFinished = CHPGPDHOOFL;
		}

		internal void EBJJKGFOLOA(UITweener MKAPOHKFIJH)
		{
			if (LevelManager.instance.isLevelUp)
			{
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.EJFOGKBGIBE());
			}
		}

		internal void MMEEJDGGAID(UITweener MGDJMGHCAAI)
		{
			TweenProgressBar tweenProgressBar = TweenProgressBar.GMLNHEIJHDE(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, 1986f, new NHOGNBCNIEK(PAENPHMEMGC));
			tweenProgressBar.onFinished = CHPGPDHOOFL;
		}

		internal void CFGDGGBELGD(UITweener MKAPOHKFIJH)
		{
			if (LevelManager.instance.isLevelUp)
			{
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.NJEPOLNAHEF());
			}
		}

		internal void HHLMDAKDHFK(UITweener MGDJMGHCAAI)
		{
			TweenProgressBar tweenProgressBar = TweenProgressBar.PAJHHBLHAEI(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, 1281f, new NHOGNBCNIEK(PAENPHMEMGC));
			tweenProgressBar.onFinished = CHPGPDHOOFL;
		}

		internal void GANNNCEMLPI(UITweener MKAPOHKFIJH)
		{
			if (LevelManager.instance.isLevelUp)
			{
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.EFHEKHAMEAJ());
			}
		}

		internal void FHDOHCJJEMM(UITweener MGDJMGHCAAI)
		{
			TweenProgressBar tweenProgressBar = TweenProgressBar.ONCDIOBFHME(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, 891f, new NHOGNBCNIEK(PAENPHMEMGC));
			tweenProgressBar.onFinished = CFGDGGBELGD;
		}

		internal void LJCDGJKCNEC(UITweener MGDJMGHCAAI)
		{
			TweenProgressBar tweenProgressBar = TweenProgressBar.Begin(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, 0.9f, new NHOGNBCNIEK(PAENPHMEMGC));
			tweenProgressBar.onFinished = EJLGBICBIFK;
		}

		internal void BFMHIICIHKL(UITweener MKAPOHKFIJH)
		{
			if (LevelManager.instance.isLevelUp)
			{
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.IAGKEDEOOIE());
			}
		}

		internal void EFFNMHECDDI(UITweener MKAPOHKFIJH)
		{
			if (LevelManager.instance.isLevelUp)
			{
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.NNJCEANBJKD());
			}
		}

		internal void PCBLIENKOPE(UITweener MKAPOHKFIJH)
		{
			if (LevelManager.instance.isLevelUp)
			{
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.EFHEKHAMEAJ());
			}
		}

		internal void OABFAOLFMMJ(UITweener MGDJMGHCAAI)
		{
			TweenProgressBar tweenProgressBar = TweenProgressBar.PAJHHBLHAEI(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, 1332f, new NHOGNBCNIEK(PAENPHMEMGC));
			tweenProgressBar.onFinished = EFFNMHECDDI;
		}

		internal void DLODDIOIDME(UITweener MKAPOHKFIJH)
		{
			if (LevelManager.instance.isLevelUp)
			{
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.NJEPOLNAHEF());
			}
		}

		internal void CHPGPDHOOFL(UITweener MKAPOHKFIJH)
		{
			if (LevelManager.instance.isLevelUp)
			{
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.EFHEKHAMEAJ());
			}
		}

		internal void NDJOJHNIBFC(UITweener MGDJMGHCAAI)
		{
			TweenProgressBar tweenProgressBar = TweenProgressBar.PMKKKICHILI(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, 715f, new NHOGNBCNIEK(PAENPHMEMGC));
			tweenProgressBar.onFinished = EJLGBICBIFK;
		}

		internal void EJLGBICBIFK(UITweener MKAPOHKFIJH)
		{
			if (LevelManager.instance.isLevelUp)
			{
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.IAGKEDEOOIE());
			}
		}

		internal void CIFEDFPPPOK(UITweener MGDJMGHCAAI)
		{
			TweenProgressBar tweenProgressBar = TweenProgressBar.GMLNHEIJHDE(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, 473f, new NHOGNBCNIEK(PAENPHMEMGC));
			tweenProgressBar.onFinished = CHPGPDHOOFL;
		}

		internal void EMKPBGFBPFI(UITweener MGDJMGHCAAI)
		{
			TweenProgressBar tweenProgressBar = TweenProgressBar.PMKKKICHILI(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, 770f, new NHOGNBCNIEK(PAENPHMEMGC));
			tweenProgressBar.onFinished = EBJJKGFOLOA;
		}

		internal void FCFDKEHICIB(UITweener MKAPOHKFIJH)
		{
			if (LevelManager.instance.isLevelUp)
			{
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.NJEPOLNAHEF());
			}
		}
	}

	private sealed class FIFOHGBPJOA : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal TweenAlpha AJOCDHFNLND;

		internal bool BNMKGLMOMEJ;

		internal DailyMissionScreen BJGCPDNMHDH;

		internal object PHDOCKCBJOF;

		internal bool FDKOKMKIIMG;

		internal int CLPPIAGLCJJ;

		private static UITweener.OnFinished LGJCBPOPCPA;

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

		private static void JGHLGHMJJDG(UITweener MGDJMGHCAAI)
		{
			float dNDHIFENDPJ = 375f;
			float num = LevelManager.instance.GetProgress();
			if (num > 1222f)
			{
				num -= 1768f;
			}
			GuiElementSingle<MenuHeader>.instance.JDOIJDNHJDF();
			TweenProgressBar.JPOJDFCHEGB(GuiElementSingle<MenuHeader>.instance.FFHCPJALBCC.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(476f), new NHOGNBCNIEK(num));
			TweenProgressBar.EGACIBHAMAF(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(1283f), new NHOGNBCNIEK(num));
		}

		private static void FICGLJJELPM(UITweener MGDJMGHCAAI)
		{
			float dNDHIFENDPJ = 805f;
			float num = LevelManager.instance.GetProgress();
			if (num > 1118f)
			{
				num -= 1322f;
			}
			GuiElementSingle<MenuHeader>.instance.UpdateLevel();
			TweenProgressBar.NNJONILFKMD(GuiElementSingle<MenuHeader>.instance.FFHCPJALBCC.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(582f), new NHOGNBCNIEK(num));
			TweenProgressBar.IAGLEIPAIOB(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(688f), new NHOGNBCNIEK(num));
		}

		[SpecialName]
		private object HJFIBBBPDKK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MILFCGMBHIG()
		{
			return PHDOCKCBJOF;
		}

		private static void HPJCBDDALHB(UITweener MGDJMGHCAAI)
		{
			float dNDHIFENDPJ = 842f;
			float num = LevelManager.instance.GetProgress();
			if (num > 1687f)
			{
				num -= 1291f;
			}
			GuiElementSingle<MenuHeader>.instance.JPPOMCGJPDL();
			TweenProgressBar.AFHNENMGEMO(GuiElementSingle<MenuHeader>.instance.FFHCPJALBCC.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(851f), new NHOGNBCNIEK(num));
			TweenProgressBar.IAGLEIPAIOB(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(1225f), new NHOGNBCNIEK(num));
		}

		public bool DDBCLDGNFBB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(1600f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LevelUpDialog>.instance, 471f);
				PHDOCKCBJOF = new WaitForSeconds(152f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 2u:
			case 3u:
			{
				if (GuiElementSingle<LevelUpDialog>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				AJOCDHFNLND = TweenAlpha.Begin(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, 759f, 304f, 495f);
				AJOCDHFNLND.style = (UITweener.Style)5;
				AJOCDHFNLND.NumOfRepetitions = 19;
				TweenAlpha aJOCDHFNLND = AJOCDHFNLND;
				if (LGJCBPOPCPA == null)
				{
					LGJCBPOPCPA = EGJBKFPHCNF;
				}
				aJOCDHFNLND.onFinished = LGJCBPOPCPA;
				BNMKGLMOMEJ = Singleton<GameController>.instance.MNMLNIMFMJP == (GameController.HKGHCIEPGEL)46;
				if (BNMKGLMOMEJ)
				{
					if (DailyMissionsManager.instance.currentMission.isSolo)
					{
						BJGCPDNMHDH.mSoloPart.PLAJNFOICOM();
					}
					else if (DailyMissionsManager.instance.DPLEEBIFDKL().isCoop)
					{
						BJGCPDNMHDH.mCoopPart.JAMHEKLBIEK();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object BMAMEPNHHFI()
		{
			return PHDOCKCBJOF;
		}

		public void HHCBBENDENJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void JJOAHIOBOPO()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void IKGBMDKKAPA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		private static void GFBPCKDLGMM(UITweener MGDJMGHCAAI)
		{
			float dNDHIFENDPJ = 1489f;
			float num = LevelManager.instance.GetProgress();
			if (num > 889f)
			{
				num -= 271f;
			}
			GuiElementSingle<MenuHeader>.instance.ADJJGJHMJJM();
			TweenProgressBar.NNJONILFKMD(GuiElementSingle<MenuHeader>.instance.FFHCPJALBCC.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(798f), new NHOGNBCNIEK(num));
			TweenProgressBar.FPCEFCDOKGG(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(70f), new NHOGNBCNIEK(num));
		}

		public void DNNJONPPIED()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IPCODJDAOBE()
		{
			return PHDOCKCBJOF;
		}

		public void HLJMNBBDJGE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		private static void JAIGALEPPLI(UITweener MGDJMGHCAAI)
		{
			float dNDHIFENDPJ = 1803f;
			float num = LevelManager.instance.GetProgress();
			if (num > 1423f)
			{
				num -= 1887f;
			}
			GuiElementSingle<MenuHeader>.instance.JDOIJDNHJDF();
			TweenProgressBar.IAGLEIPAIOB(GuiElementSingle<MenuHeader>.instance.FFHCPJALBCC.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(710f), new NHOGNBCNIEK(num));
			TweenProgressBar.OBHFCFEKAPG(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(611f), new NHOGNBCNIEK(num));
		}

		public void JBHOCIFIMBH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		private static void BBPKDMPNEDG(UITweener MGDJMGHCAAI)
		{
			float dNDHIFENDPJ = 1927f;
			float num = LevelManager.instance.GetProgress();
			if (num > 849f)
			{
				num -= 1959f;
			}
			GuiElementSingle<MenuHeader>.instance.GIKKPPPIOIB();
			TweenProgressBar.EGACIBHAMAF(GuiElementSingle<MenuHeader>.instance.FFHCPJALBCC.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(1260f), new NHOGNBCNIEK(num));
			TweenProgressBar.FFEEMJJIMOE(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(58f), new NHOGNBCNIEK(num));
		}

		public void HLDMODAFJBO()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object CPJCCMLEPCE()
		{
			return PHDOCKCBJOF;
		}

		private static void FIBGJHCGHJH(UITweener MGDJMGHCAAI)
		{
			float dNDHIFENDPJ = 1077f;
			float num = LevelManager.instance.GetProgress();
			if (num > 730f)
			{
				num -= 830f;
			}
			GuiElementSingle<MenuHeader>.instance.ADJJGJHMJJM();
			TweenProgressBar.JPOJDFCHEGB(GuiElementSingle<MenuHeader>.instance.FFHCPJALBCC.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(975f), new NHOGNBCNIEK(num));
			TweenProgressBar.AFHNENMGEMO(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(290f), new NHOGNBCNIEK(num));
		}

		public void KKDOJDCJAJB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool LDINGGNOLKA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(1097f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LevelUpDialog>.instance, 25f);
				PHDOCKCBJOF = new WaitForSeconds(734f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
			case 3u:
			{
				if (GuiElementSingle<LevelUpDialog>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				AJOCDHFNLND = TweenAlpha.Begin(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, 1614f, 496f, 1732f);
				AJOCDHFNLND.style = UITweener.Style.Once;
				AJOCDHFNLND.NumOfRepetitions = -36;
				TweenAlpha aJOCDHFNLND = AJOCDHFNLND;
				if (LGJCBPOPCPA == null)
				{
					LGJCBPOPCPA = KIACGAKNBLD;
				}
				aJOCDHFNLND.onFinished = LGJCBPOPCPA;
				BNMKGLMOMEJ = Singleton<GameController>.instance.MNMLNIMFMJP == (GameController.HKGHCIEPGEL)31;
				if (BNMKGLMOMEJ)
				{
					if (DailyMissionsManager.instance.DPLEEBIFDKL().isSolo)
					{
						BJGCPDNMHDH.mSoloPart.PFLKHFBILBL();
					}
					else if (DailyMissionsManager.instance.currentMission.isCoop)
					{
						BJGCPDNMHDH.mCoopPart.OOFMNIFEMJG();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return false;
			}
			return true;
		}

		public bool HOJKAHEGFEB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(659f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LevelUpDialog>.instance, 1971f);
				PHDOCKCBJOF = new WaitForSeconds(652f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 2u:
			case 3u:
			{
				if (GuiElementSingle<LevelUpDialog>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				AJOCDHFNLND = TweenAlpha.Begin(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, 1016f, 1844f, 1833f);
				AJOCDHFNLND.style = (UITweener.Style)3;
				AJOCDHFNLND.NumOfRepetitions = 34;
				TweenAlpha aJOCDHFNLND = AJOCDHFNLND;
				if (LGJCBPOPCPA == null)
				{
					LGJCBPOPCPA = MMEEJDGGAID;
				}
				aJOCDHFNLND.onFinished = LGJCBPOPCPA;
				BNMKGLMOMEJ = Singleton<GameController>.instance.MNMLNIMFMJP == (GameController.HKGHCIEPGEL)122;
				if (BNMKGLMOMEJ)
				{
					if (DailyMissionsManager.instance.DPLEEBIFDKL().isSolo)
					{
						BJGCPDNMHDH.mSoloPart.COFDHKPIMGC();
					}
					else if (DailyMissionsManager.instance.DPLEEBIFDKL().isCoop)
					{
						BJGCPDNMHDH.mCoopPart.PCBCLAFIMFL();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return false;
			}
			return true;
		}

		public void MOJGMBNBGHH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool GNFCLHDPPFP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(1944f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LevelUpDialog>.instance, 66f);
				PHDOCKCBJOF = new WaitForSeconds(1677f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 2u:
			case 3u:
			{
				if (GuiElementSingle<LevelUpDialog>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				AJOCDHFNLND = TweenAlpha.Begin(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, 1300f, 176f, 1481f);
				AJOCDHFNLND.style = (UITweener.Style)8;
				AJOCDHFNLND.NumOfRepetitions = -15;
				TweenAlpha aJOCDHFNLND = AJOCDHFNLND;
				if (LGJCBPOPCPA == null)
				{
					LGJCBPOPCPA = NAJNECOMDDN;
				}
				aJOCDHFNLND.onFinished = LGJCBPOPCPA;
				BNMKGLMOMEJ = Singleton<GameController>.instance.MNMLNIMFMJP == (GameController.HKGHCIEPGEL)69;
				if (BNMKGLMOMEJ)
				{
					if (DailyMissionsManager.instance.OCKCBFLKEGJ().isSolo)
					{
						BJGCPDNMHDH.mSoloPart.FJJCLECCKBK();
					}
					else if (DailyMissionsManager.instance.OCKCBFLKEGJ().isCoop)
					{
						BJGCPDNMHDH.mCoopPart.ContinueAnimation();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object HBGFABNDPAD()
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
				PHDOCKCBJOF = new WaitForSeconds(724f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LevelUpDialog>.instance, 1653f);
				PHDOCKCBJOF = new WaitForSeconds(1319f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 2u:
			case 3u:
			{
				if (GuiElementSingle<LevelUpDialog>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				AJOCDHFNLND = TweenAlpha.Begin(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, 403f, 216f, 1143f);
				AJOCDHFNLND.style = UITweener.Style.Loop;
				AJOCDHFNLND.NumOfRepetitions = -7;
				TweenAlpha aJOCDHFNLND = AJOCDHFNLND;
				if (LGJCBPOPCPA == null)
				{
					LGJCBPOPCPA = HPJCBDDALHB;
				}
				aJOCDHFNLND.onFinished = LGJCBPOPCPA;
				BNMKGLMOMEJ = Singleton<GameController>.instance.MNMLNIMFMJP == (GameController.HKGHCIEPGEL)116;
				if (BNMKGLMOMEJ)
				{
					if (DailyMissionsManager.instance.DPLEEBIFDKL().isSolo)
					{
						BJGCPDNMHDH.mSoloPart.PLAJNFOICOM();
					}
					else if (DailyMissionsManager.instance.EEIJPIPFAMO().isCoop)
					{
						BJGCPDNMHDH.mCoopPart.FIAFEBIBDMP();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return false;
			}
			return true;
		}

		public void ENCGDFIIGNH()
		{
			throw new NotSupportedException();
		}

		public bool BCFKDABEHHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(381f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LevelUpDialog>.instance, 1275f);
				PHDOCKCBJOF = new WaitForSeconds(29f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 2u:
			case 3u:
			{
				if (GuiElementSingle<LevelUpDialog>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				AJOCDHFNLND = TweenAlpha.Begin(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, 494f, 1586f, 1207f);
				AJOCDHFNLND.style = (UITweener.Style)7;
				AJOCDHFNLND.NumOfRepetitions = -104;
				TweenAlpha aJOCDHFNLND = AJOCDHFNLND;
				if (LGJCBPOPCPA == null)
				{
					LGJCBPOPCPA = JGHLGHMJJDG;
				}
				aJOCDHFNLND.onFinished = LGJCBPOPCPA;
				BNMKGLMOMEJ = Singleton<GameController>.instance.MNMLNIMFMJP == (GameController.HKGHCIEPGEL)(-86);
				if (BNMKGLMOMEJ)
				{
					if (DailyMissionsManager.instance.currentMission.isSolo)
					{
						BJGCPDNMHDH.mSoloPart.EHMMEEGAJIO();
					}
					else if (DailyMissionsManager.instance.currentMission.isCoop)
					{
						BJGCPDNMHDH.mCoopPart.FIAFEBIBDMP();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return false;
			}
			return false;
		}

		public bool MKCOLOBIAAP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(125f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LevelUpDialog>.instance, 446f);
				PHDOCKCBJOF = new WaitForSeconds(633f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 2u:
			case 3u:
			{
				if (GuiElementSingle<LevelUpDialog>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				AJOCDHFNLND = TweenAlpha.Begin(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, 1449f, 866f, 1826f);
				AJOCDHFNLND.style = (UITweener.Style)3;
				AJOCDHFNLND.NumOfRepetitions = 92;
				TweenAlpha aJOCDHFNLND = AJOCDHFNLND;
				if (LGJCBPOPCPA == null)
				{
					LGJCBPOPCPA = JDEJHLLIONG;
				}
				aJOCDHFNLND.onFinished = LGJCBPOPCPA;
				BNMKGLMOMEJ = Singleton<GameController>.instance.MNMLNIMFMJP == (GameController.HKGHCIEPGEL)76;
				if (BNMKGLMOMEJ)
				{
					if (DailyMissionsManager.instance.EEIJPIPFAMO().isSolo)
					{
						BJGCPDNMHDH.mSoloPart.JECMIIOGFJA();
					}
					else if (DailyMissionsManager.instance.EEIJPIPFAMO().isCoop)
					{
						BJGCPDNMHDH.mCoopPart.KNECNPADMCO();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return true;
			}
			return true;
		}

		public void GICLICNJPBF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool FGAFKEKGPHF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(1752f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LevelUpDialog>.instance, 705f);
				PHDOCKCBJOF = new WaitForSeconds(1852f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 2u:
			case 3u:
			{
				if (GuiElementSingle<LevelUpDialog>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				AJOCDHFNLND = TweenAlpha.Begin(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, 436f, 533f, 1229f);
				AJOCDHFNLND.style = (UITweener.Style)6;
				AJOCDHFNLND.NumOfRepetitions = -6;
				TweenAlpha aJOCDHFNLND = AJOCDHFNLND;
				if (LGJCBPOPCPA == null)
				{
					LGJCBPOPCPA = ANAGFGHGPJA;
				}
				aJOCDHFNLND.onFinished = LGJCBPOPCPA;
				BNMKGLMOMEJ = Singleton<GameController>.instance.MNMLNIMFMJP == (GameController.HKGHCIEPGEL)33;
				if (BNMKGLMOMEJ)
				{
					if (DailyMissionsManager.instance.MEBFNJBNNEK().isSolo)
					{
						BJGCPDNMHDH.mSoloPart.KNECNPADMCO();
					}
					else if (DailyMissionsManager.instance.EEIJPIPFAMO().isCoop)
					{
						BJGCPDNMHDH.mCoopPart.PLAJNFOICOM();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return false;
			}
			return true;
		}

		public bool JPBGJLDMOPO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(1164f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LevelUpDialog>.instance, 1778f);
				PHDOCKCBJOF = new WaitForSeconds(171f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 2u:
			case 3u:
			{
				if (GuiElementSingle<LevelUpDialog>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				AJOCDHFNLND = TweenAlpha.Begin(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, 1374f, 1892f, 639f);
				AJOCDHFNLND.style = UITweener.Style.PingPong;
				AJOCDHFNLND.NumOfRepetitions = 52;
				TweenAlpha aJOCDHFNLND = AJOCDHFNLND;
				if (LGJCBPOPCPA == null)
				{
					LGJCBPOPCPA = KIACGAKNBLD;
				}
				aJOCDHFNLND.onFinished = LGJCBPOPCPA;
				BNMKGLMOMEJ = Singleton<GameController>.instance.MNMLNIMFMJP == (GameController.HKGHCIEPGEL)(-50);
				if (BNMKGLMOMEJ)
				{
					if (DailyMissionsManager.instance.DPLEEBIFDKL().isSolo)
					{
						BJGCPDNMHDH.mSoloPart.FIAFEBIBDMP();
					}
					else if (DailyMissionsManager.instance.currentMission.isCoop)
					{
						BJGCPDNMHDH.mCoopPart.JECMIIOGFJA();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return true;
			}
			return true;
		}

		public bool JNHFCKKAPJH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(43f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LevelUpDialog>.instance, 839f);
				PHDOCKCBJOF = new WaitForSeconds(1413f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 2u:
			case 3u:
			{
				if (GuiElementSingle<LevelUpDialog>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				AJOCDHFNLND = TweenAlpha.Begin(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, 1402f, 671f, 773f);
				AJOCDHFNLND.style = (UITweener.Style)7;
				AJOCDHFNLND.NumOfRepetitions = 38;
				TweenAlpha aJOCDHFNLND = AJOCDHFNLND;
				if (LGJCBPOPCPA == null)
				{
					LGJCBPOPCPA = JAIGALEPPLI;
				}
				aJOCDHFNLND.onFinished = LGJCBPOPCPA;
				BNMKGLMOMEJ = Singleton<GameController>.instance.MNMLNIMFMJP == (GameController.HKGHCIEPGEL)114;
				if (BNMKGLMOMEJ)
				{
					if (DailyMissionsManager.instance.OCKCBFLKEGJ().isSolo)
					{
						BJGCPDNMHDH.mSoloPart.PFLKHFBILBL();
					}
					else if (DailyMissionsManager.instance.DPLEEBIFDKL().isCoop)
					{
						BJGCPDNMHDH.mCoopPart.MEMCKJHKCCL();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return false;
			}
			return false;
		}

		private static void NAJNECOMDDN(UITweener MGDJMGHCAAI)
		{
			float dNDHIFENDPJ = 1578f;
			float num = LevelManager.instance.GetProgress();
			if (num > 647f)
			{
				num -= 1916f;
			}
			GuiElementSingle<MenuHeader>.instance.ADJJGJHMJJM();
			TweenProgressBar.LCBLJBAJGED(GuiElementSingle<MenuHeader>.instance.FFHCPJALBCC.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(202f), new NHOGNBCNIEK(num));
			TweenProgressBar.AFHNENMGEMO(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(1318f), new NHOGNBCNIEK(num));
		}

		[SpecialName]
		private object OJKHNOHHDGO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LAENBDAPNJL()
		{
			return PHDOCKCBJOF;
		}

		private static void EGJBKFPHCNF(UITweener MGDJMGHCAAI)
		{
			float dNDHIFENDPJ = 1415f;
			float num = LevelManager.instance.GetProgress();
			if (num > 214f)
			{
				num -= 1424f;
			}
			GuiElementSingle<MenuHeader>.instance.JPPOMCGJPDL();
			TweenProgressBar.NNJONILFKMD(GuiElementSingle<MenuHeader>.instance.FFHCPJALBCC.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(1197f), new NHOGNBCNIEK(num));
			TweenProgressBar.FPCEFCDOKGG(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(1245f), new NHOGNBCNIEK(num));
		}

		[SpecialName]
		private object CLDLJNHAEAB()
		{
			return PHDOCKCBJOF;
		}

		public void MNFJGIMMBLE()
		{
			throw new NotSupportedException();
		}

		private static void LKAHPHIEMEK(UITweener MGDJMGHCAAI)
		{
			float dNDHIFENDPJ = 1714f;
			float num = LevelManager.instance.GetProgress();
			if (num > 1379f)
			{
				num -= 1533f;
			}
			GuiElementSingle<MenuHeader>.instance.GIKKPPPIOIB();
			TweenProgressBar.DHKJOACDBNK(GuiElementSingle<MenuHeader>.instance.FFHCPJALBCC.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(738f), new NHOGNBCNIEK(num));
			TweenProgressBar.FFEEMJJIMOE(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(1719f), new NHOGNBCNIEK(num));
		}

		public bool IDBCKIPOEEI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(595f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LevelUpDialog>.instance, 341f);
				PHDOCKCBJOF = new WaitForSeconds(483f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 2u:
			case 3u:
			{
				if (GuiElementSingle<LevelUpDialog>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				AJOCDHFNLND = TweenAlpha.Begin(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, 800f, 941f, 683f);
				AJOCDHFNLND.style = (UITweener.Style)4;
				AJOCDHFNLND.NumOfRepetitions = 9;
				TweenAlpha aJOCDHFNLND = AJOCDHFNLND;
				if (LGJCBPOPCPA == null)
				{
					LGJCBPOPCPA = EGJBKFPHCNF;
				}
				aJOCDHFNLND.onFinished = LGJCBPOPCPA;
				BNMKGLMOMEJ = Singleton<GameController>.instance.MNMLNIMFMJP == (GameController.HKGHCIEPGEL)(-93);
				if (BNMKGLMOMEJ)
				{
					if (DailyMissionsManager.instance.DPLEEBIFDKL().isSolo)
					{
						BJGCPDNMHDH.mSoloPart.JAMHEKLBIEK();
					}
					else if (DailyMissionsManager.instance.EEIJPIPFAMO().isCoop)
					{
						BJGCPDNMHDH.mCoopPart.EHMMEEGAJIO();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object FGGMHEIPKAJ()
		{
			return PHDOCKCBJOF;
		}

		private static void AGFEDJAKLAC(UITweener MGDJMGHCAAI)
		{
			float dNDHIFENDPJ = 1030f;
			float num = LevelManager.instance.GetProgress();
			if (num > 1535f)
			{
				num -= 1620f;
			}
			GuiElementSingle<MenuHeader>.instance.UpdateLevel();
			TweenProgressBar.DKGIHJJKKBM(GuiElementSingle<MenuHeader>.instance.FFHCPJALBCC.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(1888f), new NHOGNBCNIEK(num));
			TweenProgressBar.FFEEMJJIMOE(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(120f), new NHOGNBCNIEK(num));
		}

		private static void ILOFOILFGMA(UITweener MGDJMGHCAAI)
		{
			float dNDHIFENDPJ = 94f;
			float num = LevelManager.instance.GetProgress();
			if (num > 675f)
			{
				num -= 42f;
			}
			GuiElementSingle<MenuHeader>.instance.ADJJGJHMJJM();
			TweenProgressBar.FPCEFCDOKGG(GuiElementSingle<MenuHeader>.instance.FFHCPJALBCC.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(1890f), new NHOGNBCNIEK(num));
			TweenProgressBar.FPCEFCDOKGG(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(720f), new NHOGNBCNIEK(num));
		}

		public void NPIDJAPKFLN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		private static void MMEEJDGGAID(UITweener MGDJMGHCAAI)
		{
			float dNDHIFENDPJ = 1760f;
			float num = LevelManager.instance.GetProgress();
			if (num > 296f)
			{
				num -= 1162f;
			}
			GuiElementSingle<MenuHeader>.instance.UpdateLevel();
			TweenProgressBar.FPCEFCDOKGG(GuiElementSingle<MenuHeader>.instance.FFHCPJALBCC.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(1808f), new NHOGNBCNIEK(num));
			TweenProgressBar.FPCEFCDOKGG(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(1547f), new NHOGNBCNIEK(num));
		}

		[SpecialName]
		private object NMGBFNNHIPN()
		{
			return PHDOCKCBJOF;
		}

		public void FOODPOJODAA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void OFDJMNMCDLA()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CGIBLCGGMJM()
		{
			return PHDOCKCBJOF;
		}

		public void ABBPOMCBIIH()
		{
			throw new NotSupportedException();
		}

		public void MENEBJLDGJD()
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
				PHDOCKCBJOF = new WaitForSeconds(763f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LevelUpDialog>.instance, 477f);
				PHDOCKCBJOF = new WaitForSeconds(438f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
			case 3u:
			{
				if (GuiElementSingle<LevelUpDialog>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				AJOCDHFNLND = TweenAlpha.Begin(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, 1066f, 545f, 1121f);
				AJOCDHFNLND.style = UITweener.Style.Once;
				AJOCDHFNLND.NumOfRepetitions = 3;
				TweenAlpha aJOCDHFNLND = AJOCDHFNLND;
				if (LGJCBPOPCPA == null)
				{
					LGJCBPOPCPA = AGFEDJAKLAC;
				}
				aJOCDHFNLND.onFinished = LGJCBPOPCPA;
				BNMKGLMOMEJ = Singleton<GameController>.instance.MNMLNIMFMJP == (GameController.HKGHCIEPGEL)86;
				if (BNMKGLMOMEJ)
				{
					if (DailyMissionsManager.instance.LFFBCGDBGHH().isSolo)
					{
						BJGCPDNMHDH.mSoloPart.EHMMEEGAJIO();
					}
					else if (DailyMissionsManager.instance.EEIJPIPFAMO().isCoop)
					{
						BJGCPDNMHDH.mCoopPart.BDEALAONJAC();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return false;
			}
			return false;
		}

		private static void OFCOFDILHHH(UITweener MGDJMGHCAAI)
		{
			float dNDHIFENDPJ = 1436f;
			float num = LevelManager.instance.GetProgress();
			if (num > 132f)
			{
				num -= 799f;
			}
			GuiElementSingle<MenuHeader>.instance.JPPOMCGJPDL();
			TweenProgressBar.NNJONILFKMD(GuiElementSingle<MenuHeader>.instance.FFHCPJALBCC.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(332f), new NHOGNBCNIEK(num));
			TweenProgressBar.EGACIBHAMAF(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(1399f), new NHOGNBCNIEK(num));
		}

		public bool GBHCODKDPBO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(1119f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LevelUpDialog>.instance, 1481f);
				PHDOCKCBJOF = new WaitForSeconds(1689f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
			case 3u:
			{
				if (GuiElementSingle<LevelUpDialog>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				AJOCDHFNLND = TweenAlpha.Begin(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, 864f, 1890f, 1723f);
				AJOCDHFNLND.style = (UITweener.Style)6;
				AJOCDHFNLND.NumOfRepetitions = -124;
				TweenAlpha aJOCDHFNLND = AJOCDHFNLND;
				if (LGJCBPOPCPA == null)
				{
					LGJCBPOPCPA = ILOFOILFGMA;
				}
				aJOCDHFNLND.onFinished = LGJCBPOPCPA;
				BNMKGLMOMEJ = Singleton<GameController>.instance.MNMLNIMFMJP == (GameController.HKGHCIEPGEL)(-25);
				if (BNMKGLMOMEJ)
				{
					if (DailyMissionsManager.instance.currentMission.isSolo)
					{
						BJGCPDNMHDH.mSoloPart.MEMCKJHKCCL();
					}
					else if (DailyMissionsManager.instance.LFFBCGDBGHH().isCoop)
					{
						BJGCPDNMHDH.mCoopPart.IMHEFLGDOLF();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return true;
			}
			return false;
		}

		public void JHLKDONBGDK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GOAJCEAOPLA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BIMFPFEHMAP()
		{
			return PHDOCKCBJOF;
		}

		public void DEPEHNFEJEE()
		{
			throw new NotSupportedException();
		}

		public void CDIJEGGMMAK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		private static void DJLGPGPAHCD(UITweener MGDJMGHCAAI)
		{
			float dNDHIFENDPJ = 861f;
			float num = LevelManager.instance.GetProgress();
			if (num > 94f)
			{
				num -= 1491f;
			}
			GuiElementSingle<MenuHeader>.instance.FHEDABDGJEJ();
			TweenProgressBar.OBHFCFEKAPG(GuiElementSingle<MenuHeader>.instance.FFHCPJALBCC.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(1995f), new NHOGNBCNIEK(num));
			TweenProgressBar.HLINIFHCFEF(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(1111f), new NHOGNBCNIEK(num));
		}

		[DebuggerHidden]
		public FIFOHGBPJOA()
		{
		}

		public void CNOEDCFDILG()
		{
			throw new NotSupportedException();
		}

		private static void JDEJHLLIONG(UITweener MGDJMGHCAAI)
		{
			float dNDHIFENDPJ = 560f;
			float num = LevelManager.instance.GetProgress();
			if (num > 1650f)
			{
				num -= 1208f;
			}
			GuiElementSingle<MenuHeader>.instance.GIKKPPPIOIB();
			TweenProgressBar.FPCEFCDOKGG(GuiElementSingle<MenuHeader>.instance.FFHCPJALBCC.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(389f), new NHOGNBCNIEK(num));
			TweenProgressBar.DKGIHJJKKBM(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(1219f), new NHOGNBCNIEK(num));
		}

		public bool BLHOCNMMPNP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(595f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LevelUpDialog>.instance, 815f);
				PHDOCKCBJOF = new WaitForSeconds(563f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
			case 3u:
			{
				if (GuiElementSingle<LevelUpDialog>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				AJOCDHFNLND = TweenAlpha.Begin(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, 1089f, 112f, 304f);
				AJOCDHFNLND.style = UITweener.Style.PingPong;
				AJOCDHFNLND.NumOfRepetitions = 121;
				TweenAlpha aJOCDHFNLND = AJOCDHFNLND;
				if (LGJCBPOPCPA == null)
				{
					LGJCBPOPCPA = FDKMOFHAEFN;
				}
				aJOCDHFNLND.onFinished = LGJCBPOPCPA;
				BNMKGLMOMEJ = Singleton<GameController>.instance.MNMLNIMFMJP == (GameController.HKGHCIEPGEL)49;
				if (BNMKGLMOMEJ)
				{
					if (DailyMissionsManager.instance.currentMission.isSolo)
					{
						BJGCPDNMHDH.mSoloPart.CHJMEGEOKPJ();
					}
					else if (DailyMissionsManager.instance.EEIJPIPFAMO().isCoop)
					{
						BJGCPDNMHDH.mCoopPart.IMHEFLGDOLF();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return false;
			}
			return false;
		}

		private static void FDKMOFHAEFN(UITweener MGDJMGHCAAI)
		{
			float dNDHIFENDPJ = 1122f;
			float num = LevelManager.instance.GetProgress();
			if (num > 1927f)
			{
				num -= 880f;
			}
			GuiElementSingle<MenuHeader>.instance.NKKIINELKAI();
			TweenProgressBar.AFHNENMGEMO(GuiElementSingle<MenuHeader>.instance.FFHCPJALBCC.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(324f), new NHOGNBCNIEK(num));
			TweenProgressBar.OBHFCFEKAPG(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(598f), new NHOGNBCNIEK(num));
		}

		private static void KIACGAKNBLD(UITweener MGDJMGHCAAI)
		{
			float dNDHIFENDPJ = 1030f;
			float num = LevelManager.instance.GetProgress();
			if (num > 450f)
			{
				num -= 194f;
			}
			GuiElementSingle<MenuHeader>.instance.GIKKPPPIOIB();
			TweenProgressBar.FFEEMJJIMOE(GuiElementSingle<MenuHeader>.instance.FFHCPJALBCC.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(855f), new NHOGNBCNIEK(num));
			TweenProgressBar.FFEEMJJIMOE(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(1618f), new NHOGNBCNIEK(num));
		}

		[SpecialName]
		private object GJMNLPAEIDA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ONADHLDNKKB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GFMLDIMOGHD()
		{
			return PHDOCKCBJOF;
		}

		private static void LJCDGJKCNEC(UITweener MGDJMGHCAAI)
		{
			float dNDHIFENDPJ = 1f;
			float num = LevelManager.instance.GetProgress();
			if (num > 1f)
			{
				num -= 1f;
			}
			GuiElementSingle<MenuHeader>.instance.UpdateLevel();
			TweenProgressBar.Begin(GuiElementSingle<MenuHeader>.instance.FFHCPJALBCC.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(0f), new NHOGNBCNIEK(num));
			TweenProgressBar.Begin(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(0f), new NHOGNBCNIEK(num));
		}

		[SpecialName]
		private object BBDOFDBCILK()
		{
			return PHDOCKCBJOF;
		}

		private static void KNJBDOADLDO(UITweener MGDJMGHCAAI)
		{
			float dNDHIFENDPJ = 1994f;
			float num = LevelManager.instance.GetProgress();
			if (num > 538f)
			{
				num -= 948f;
			}
			GuiElementSingle<MenuHeader>.instance.JPPOMCGJPDL();
			TweenProgressBar.NNJONILFKMD(GuiElementSingle<MenuHeader>.instance.FFHCPJALBCC.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(1689f), new NHOGNBCNIEK(num));
			TweenProgressBar.DKGIHJJKKBM(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(1728f), new NHOGNBCNIEK(num));
		}

		private static void LIMGPKFEALB(UITweener MGDJMGHCAAI)
		{
			float dNDHIFENDPJ = 813f;
			float num = LevelManager.instance.GetProgress();
			if (num > 1327f)
			{
				num -= 1829f;
			}
			GuiElementSingle<MenuHeader>.instance.JDOIJDNHJDF();
			TweenProgressBar.JPOJDFCHEGB(GuiElementSingle<MenuHeader>.instance.FFHCPJALBCC.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(996f), new NHOGNBCNIEK(num));
			TweenProgressBar.NNJONILFKMD(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(418f), new NHOGNBCNIEK(num));
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(0.45f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LevelUpDialog>.instance);
				PHDOCKCBJOF = new WaitForSeconds(0.5f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
			case 3u:
			{
				if (GuiElementSingle<LevelUpDialog>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				AJOCDHFNLND = TweenAlpha.Begin(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, 0.2f, 0f, 1f);
				AJOCDHFNLND.style = UITweener.Style.PingPong;
				AJOCDHFNLND.NumOfRepetitions = 11;
				TweenAlpha aJOCDHFNLND = AJOCDHFNLND;
				if (LGJCBPOPCPA == null)
				{
					LGJCBPOPCPA = LJCDGJKCNEC;
				}
				aJOCDHFNLND.onFinished = LGJCBPOPCPA;
				BNMKGLMOMEJ = Singleton<GameController>.instance.MNMLNIMFMJP == GameController.HKGHCIEPGEL.MissionSuccess;
				if (BNMKGLMOMEJ)
				{
					if (DailyMissionsManager.instance.currentMission.isSolo)
					{
						BJGCPDNMHDH.mSoloPart.ContinueAnimation();
					}
					else if (DailyMissionsManager.instance.currentMission.isCoop)
					{
						BJGCPDNMHDH.mCoopPart.ContinueAnimation();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return false;
			}
			return true;
		}

		public void AKLMKDOIDHP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		private static void ANAGFGHGPJA(UITweener MGDJMGHCAAI)
		{
			float dNDHIFENDPJ = 347f;
			float num = LevelManager.instance.GetProgress();
			if (num > 294f)
			{
				num -= 1728f;
			}
			GuiElementSingle<MenuHeader>.instance.NKKIINELKAI();
			TweenProgressBar.FHKFBIPHJCG(GuiElementSingle<MenuHeader>.instance.FFHCPJALBCC.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(1781f), new NHOGNBCNIEK(num));
			TweenProgressBar.Begin(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(11f), new NHOGNBCNIEK(num));
		}

		[SpecialName]
		private object IJFPHIKFJFB()
		{
			return PHDOCKCBJOF;
		}

		public void OEMOMDILPEE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object JFGCHMJJMNO()
		{
			return PHDOCKCBJOF;
		}

		private static void DPCJMMOPCFO(UITweener MGDJMGHCAAI)
		{
			float dNDHIFENDPJ = 1174f;
			float num = LevelManager.instance.GetProgress();
			if (num > 1452f)
			{
				num -= 1403f;
			}
			GuiElementSingle<MenuHeader>.instance.JPPOMCGJPDL();
			TweenProgressBar.NNJONILFKMD(GuiElementSingle<MenuHeader>.instance.FFHCPJALBCC.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(1442f), new NHOGNBCNIEK(num));
			TweenProgressBar.FFEEMJJIMOE(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(1051f), new NHOGNBCNIEK(num));
		}

		public void EJADBNAIHEF()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool KHNDCDGBFJH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(883f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LevelUpDialog>.instance, 348f);
				PHDOCKCBJOF = new WaitForSeconds(794f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
			case 3u:
			{
				if (GuiElementSingle<LevelUpDialog>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				AJOCDHFNLND = TweenAlpha.Begin(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, 1931f, 94f, 1241f);
				AJOCDHFNLND.style = UITweener.Style.Once;
				AJOCDHFNLND.NumOfRepetitions = -122;
				TweenAlpha aJOCDHFNLND = AJOCDHFNLND;
				if (LGJCBPOPCPA == null)
				{
					LGJCBPOPCPA = KIACGAKNBLD;
				}
				aJOCDHFNLND.onFinished = LGJCBPOPCPA;
				BNMKGLMOMEJ = Singleton<GameController>.instance.MNMLNIMFMJP == (GameController.HKGHCIEPGEL)45;
				if (BNMKGLMOMEJ)
				{
					if (DailyMissionsManager.instance.EEIJPIPFAMO().isSolo)
					{
						BJGCPDNMHDH.mSoloPart.JECMIIOGFJA();
					}
					else if (DailyMissionsManager.instance.OCKCBFLKEGJ().isCoop)
					{
						BJGCPDNMHDH.mCoopPart.MEMCKJHKCCL();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return false;
			}
			return true;
		}

		public void OAFPDIHGJDC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object KBEEEOJMBPG()
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
				PHDOCKCBJOF = new WaitForSeconds(746f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LevelUpDialog>.instance, 1080f);
				PHDOCKCBJOF = new WaitForSeconds(1250f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
			case 3u:
			{
				if (GuiElementSingle<LevelUpDialog>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				AJOCDHFNLND = TweenAlpha.Begin(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, 1457f, 1451f, 702f);
				AJOCDHFNLND.style = (UITweener.Style)8;
				AJOCDHFNLND.NumOfRepetitions = -32;
				TweenAlpha aJOCDHFNLND = AJOCDHFNLND;
				if (LGJCBPOPCPA == null)
				{
					LGJCBPOPCPA = DPCJMMOPCFO;
				}
				aJOCDHFNLND.onFinished = LGJCBPOPCPA;
				BNMKGLMOMEJ = Singleton<GameController>.instance.MNMLNIMFMJP == (GameController.HKGHCIEPGEL)111;
				if (BNMKGLMOMEJ)
				{
					if (DailyMissionsManager.instance.EEIJPIPFAMO().isSolo)
					{
						BJGCPDNMHDH.mSoloPart.JAMHEKLBIEK();
					}
					else if (DailyMissionsManager.instance.DPLEEBIFDKL().isCoop)
					{
						BJGCPDNMHDH.mCoopPart.IHOLGOMFDFG();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return false;
			}
			return false;
		}

		public void FLFOEIMCFBL()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void NINFHADPHJI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object FPMOGMELJLI()
		{
			return PHDOCKCBJOF;
		}

		private static void MCFGAFBEJDK(UITweener MGDJMGHCAAI)
		{
			float dNDHIFENDPJ = 578f;
			float num = LevelManager.instance.GetProgress();
			if (num > 1365f)
			{
				num -= 193f;
			}
			GuiElementSingle<MenuHeader>.instance.JPPOMCGJPDL();
			TweenProgressBar.DKGIHJJKKBM(GuiElementSingle<MenuHeader>.instance.FFHCPJALBCC.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(1917f), new NHOGNBCNIEK(num));
			TweenProgressBar.AFHNENMGEMO(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, dNDHIFENDPJ, new NHOGNBCNIEK(600f), new NHOGNBCNIEK(num));
		}

		[DebuggerHidden]
		public void Reset()
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
				PHDOCKCBJOF = new WaitForSeconds(57f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LevelUpDialog>.instance, 717f);
				PHDOCKCBJOF = new WaitForSeconds(276f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 2u:
			case 3u:
			{
				if (GuiElementSingle<LevelUpDialog>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				AJOCDHFNLND = TweenAlpha.Begin(GuiElementSingle<MenuHeader>.instance.CMIBPCAHILH.gameObject, 1854f, 938f, 1001f);
				AJOCDHFNLND.style = UITweener.Style.Loop;
				AJOCDHFNLND.NumOfRepetitions = 14;
				TweenAlpha aJOCDHFNLND = AJOCDHFNLND;
				if (LGJCBPOPCPA == null)
				{
					LGJCBPOPCPA = JGHLGHMJJDG;
				}
				aJOCDHFNLND.onFinished = LGJCBPOPCPA;
				BNMKGLMOMEJ = Singleton<GameController>.instance.MNMLNIMFMJP == (GameController.HKGHCIEPGEL)44;
				if (BNMKGLMOMEJ)
				{
					if (DailyMissionsManager.instance.EEIJPIPFAMO().isSolo)
					{
						BJGCPDNMHDH.mSoloPart.COFDHKPIMGC();
					}
					else if (DailyMissionsManager.instance.DPLEEBIFDKL().isCoop)
					{
						BJGCPDNMHDH.mCoopPart.PCBCLAFIMFL();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return true;
			}
			return false;
		}
	}

	[SerializeField]
	[Header("Top Left")]
	private UILabel mScreenName;

	[SerializeField]
	[Header("Top Right")]
	private GameObject mTopRightOffset;

	[SerializeField]
	private GameObject mTopRightPart;

	[SerializeField]
	private UILabel mTitleOnRight;

	[SerializeField]
	private UILabel mTimeLabel;

	[SerializeField]
	private GameObject mHeroicPointsPart;

	[SerializeField]
	private UISprite mHeroicPointsIcon;

	[SerializeField]
	private UILabel mHeroicPoints;

	[SerializeField]
	private GameObject mDebugButton;

	[Header("Left Solo")]
	[SerializeField]
	private DailyMissionProgressGui mSoloPart;

	[SerializeField]
	[Header("Left Reward")]
	private UISprite[] mRewardBackgrounds;

	[SerializeField]
	private UISprite mRewardBorder;

	[SerializeField]
	private UISprite mRewardGlow;

	[SerializeField]
	private UILabel mProgressSoloDailyMission;

	[SerializeField]
	private GameObject mRewardRightAnchor;

	[SerializeField]
	private GameObject mRewardTableHolder;

	[SerializeField]
	private UITable mRewardTable;

	[SerializeField]
	private UISprite mRewardIcon;

	[SerializeField]
	private UISprite mRewardIconQuestion;

	[SerializeField]
	private UILabel mRewardValueLabel;

	[SerializeField]
	private UISprite mRewardFlash;

	[SerializeField]
	private UISprite mRewardCheck;

	[Header("Left Coop")]
	[SerializeField]
	private DailyMissionProgressGui mCoopPart;

	[SerializeField]
	[Header("Right")]
	private DailyMissionHeroicButton mHeroicButton;

	[SerializeField]
	[Header("Card Animation")]
	private CardMenuOwerlay mCardAnimationOverlay;

	[Header("Atlases")]
	[SerializeField]
	private UIAtlas mMenuAtlas;

	[SerializeField]
	private UIAtlas mCardAtlas;

	[SerializeField]
	[Header("Animation position")]
	private UISprite mHeroicButtonSkullSprite;

	private bool MFJELKPLHLF;

	private bool FBDHGBMDCGD;

	private bool OPGCMONHEFM;

	public Vector3 positionToAnimatePointsGain
	{
		get
		{
			if (!FBDHGBMDCGD && DailyMissionsManager.instance.data.isHeroicOpened)
			{
				return mHeroicPointsIcon.transform.position;
			}
			return mHeroicButtonSkullSprite.transform.position;
		}
	}

	private void ECDOKHBEKAH()
	{
		float val = 0f - mRewardTable.padding.x - (mRewardValueLabel.transform.parent.localPosition.x - mRewardTable.padding.x) / 943f;
		mRewardTable.transform.localPosition = mRewardTable.transform.localPosition.ReplaceX(val);
	}

	public void AnimateDaily3SoloReward()
	{
		TweenScale.Begin(mRewardTableHolder.gameObject, 0.15f, Vector3.one.MultiplyXY(1.2f));
		TweenAlpha.Begin(mRewardFlash.gameObject, 0.05f, 0.5f).onFinished = delegate
		{
			TweenAlpha.Begin(mRewardFlash.gameObject, 0.05f, 0f).onFinished = delegate
			{
				TweenAlpha.Begin(mRewardFlash.gameObject, 0.05f, 0.5f).onFinished = delegate
				{
					TweenAlpha.Begin(mRewardFlash.gameObject, 0.05f, 0f).onFinished = null;
					TweenScale.Begin(mRewardTableHolder.gameObject, 0.15f, Vector3.one);
					TweenAlpha.Begin(mRewardCheck.gameObject, 0.15f, 1f);
					TweenScale.Begin(mRewardCheck.gameObject, 0.15f, mRewardCheck.transform.localScale.MultiplyXY(2f), mRewardCheck.transform.localScale).onFinished = delegate
					{
						TweenAlpha.Begin(mRewardFlash.gameObject, 0.3f, 0.1f);
						CGBNEPDAAHE();
						HLJALFBPLIK();
					};
					TweenAlpha.Begin(mRewardIcon.gameObject, 0.15f, 0f);
					TweenAlpha.Begin(mRewardIconQuestion.gameObject, 0.15f, 0f);
					TweenAlpha.Begin(mRewardValueLabel.gameObject, 0.15f, 0f);
					mRewardIconQuestion.gameObject.SetActive(false);
				};
			};
		};
	}

	[SpecialName]
	public Vector3 OPAJFAGFILB()
	{
		if (!FBDHGBMDCGD && DailyMissionsManager.instance.data.isHeroicOpened)
		{
			return mHeroicPointsIcon.transform.position;
		}
		return mHeroicButtonSkullSprite.transform.position;
	}

	private void DHALFJAMPHJ(bool EICNANIMKDB, bool KPOPJIKNJIM)
	{
		TweenTextCounter component = mHeroicPoints.GetComponent<TweenTextCounter>();
		if (component != null)
		{
			component.enabled = true;
		}
		int num = DailyMissionsManager.instance.data.heroicPoints;
		if (EICNANIMKDB)
		{
			num -= 0;
		}
		if (KPOPJIKNJIM)
		{
			num += DailyMissionsManager.instance.FPEIBJPLOHO();
		}
		mHeroicPoints.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
		float num2 = mHeroicPoints.relativeSize.x * mHeroicPoints.transform.localScale.x;
		mHeroicPointsPart.transform.localPosition = mHeroicPointsPart.transform.localPosition.ReplaceX(1410f - num2);
	}

	private void BAFDBBHNEMA(UITweener MGDJMGHCAAI)
	{
		DFHBGCNBJLC(false, false);
	}

	private void AJDBEGNLFKE(UITweener AEEBLJKPGMO)
	{
		TweenAlpha.Begin(mRewardFlash.gameObject, 525f, 1894f).onFinished = null;
		TweenScale.Begin(mRewardTableHolder.gameObject, 1785f, Vector3.one);
		TweenAlpha.Begin(mRewardCheck.gameObject, 587f, 1946f);
		TweenScale.Begin(mRewardCheck.gameObject, 960f, mRewardCheck.transform.localScale.MultiplyXY(1784f), mRewardCheck.transform.localScale).onFinished = KJEKMDFLIBN;
		TweenAlpha.Begin(mRewardIcon.gameObject, 106f, 1906f);
		TweenAlpha.Begin(mRewardIconQuestion.gameObject, 1263f, 1255f);
		TweenAlpha.Begin(mRewardValueLabel.gameObject, 271f, 278f);
		mRewardIconQuestion.gameObject.SetActive(true);
	}

	public virtual void MHPGBCIAGIL()
	{
		base.DoAfterShowUp();
		if (MFJELKPLHLF)
		{
			CMGBPEBEHFO();
			FPMOBOFNBAB();
		}
		DailyMission dailyMission = DailyMissionsManager.instance.MEBFNJBNNEK();
		if (dailyMission == null)
		{
			return;
		}
		bool isCoopClient = dailyMission.isCoopClient;
		bool flag = MFJELKPLHLF && Singleton<GameController>.instance.MNMLNIMFMJP == (GameController.HKGHCIEPGEL)30;
		if (flag && !isCoopClient)
		{
			if (dailyMission.isSolo)
			{
				mSoloPart.CGEHALCPDNH();
			}
			else if (dailyMission.isCoop)
			{
				mCoopPart.BKDCCKAFLJI();
			}
		}
		if ((flag || FBDHGBMDCGD) && !isCoopClient)
		{
			mHeroicButton.KDFIFEIEDCL(flag, FBDHGBMDCGD);
		}
	}

	private void GLHOFBINEJN(UITweener JEJOPLADMEP)
	{
		TweenAlpha.Begin(mRewardFlash.gameObject, 1173f, 470f);
		NOEFDJLNPPA();
		HNJBBEMAJEL();
	}

	private void LBNOFIAGILK(UITweener JEJOPLADMEP)
	{
		TweenAlpha.Begin(mRewardFlash.gameObject, 1752f, 221f);
		NOEFDJLNPPA();
		DAHILNDNHHA();
	}

	private void FGIIPCNKLNL()
	{
		TweenAlpha.Begin(mRewardIcon.gameObject, 647f, 1630f);
		TweenAlpha.Begin(mRewardIconQuestion.gameObject, 1654f, 52f);
		TweenAlpha.Begin(mRewardValueLabel.gameObject, 332f, 1326f);
		TweenAlpha.Begin(mRewardCheck.gameObject, 1538f, 1495f);
		TweenAlpha.Begin(mRewardFlash.gameObject, 820f, 675f).onFinished = null;
	}

	public virtual void GEGDLJIKIFE()
	{
		base.DoBeforeShowUp();
		if (MFJELKPLHLF)
		{
			GuiElementSingle<MenuHeader>.instance.SetUpWarbucksGoldWithoutAnimation(Singleton<Wallet>.instance.warbucksAfterGame, Singleton<Wallet>.instance.AHGPPGFIJLL());
		}
	}

	[DebuggerHidden]
	private IEnumerator IAGKEDEOOIE()
	{
		FIFOHGBPJOA fIFOHGBPJOA = new FIFOHGBPJOA();
		fIFOHGBPJOA.BJGCPDNMHDH = this;
		return fIFOHGBPJOA;
	}

	private void KPLJPICGCKC()
	{
		float val = mTitleOnRight.relativeSize.x * mTitleOnRight.transform.localScale.x;
		float val2 = mTimeLabel.relativeSize.x * mTimeLabel.transform.localScale.x;
		float num = Math.Max(val, val2);
		mTopRightPart.transform.localPosition = mTopRightPart.transform.localPosition.ReplaceX(0f - num);
	}

	public void LACJAPKJNAH()
	{
		FBDHGBMDCGD = false;
	}

	private void IGNLDPLGOIC()
	{
		TweenAlpha.Begin(mRewardIcon.gameObject, 1269f, 1506f);
		TweenAlpha.Begin(mRewardIconQuestion.gameObject, 472f, 476f);
		TweenAlpha.Begin(mRewardValueLabel.gameObject, 1980f, 1095f);
		TweenAlpha.Begin(mRewardCheck.gameObject, 1337f, 1341f);
		TweenAlpha.Begin(mRewardFlash.gameObject, 636f, 528f).onFinished = null;
	}

	public void NDJANHACPPG()
	{
		FBDHGBMDCGD = true;
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		if (MFJELKPLHLF)
		{
			GuiElementSingle<MenuHeader>.instance.SetUpWarbucksGoldWithoutAnimation(Singleton<Wallet>.instance.warbucksAfterGame, Singleton<Wallet>.instance.goldAfterGame);
		}
	}

	private void MGNLDOMAGHI(UITweener IKPCPKPMMAH)
	{
		TweenAlpha.Begin(mRewardFlash.gameObject, 459f, 585f).onFinished = ELAFFJMPLID;
	}

	private void JOHPJNANANA()
	{
		ECOBAHHPEFM eCOBAHHPEFM = new ECOBAHHPEFM();
		eCOBAHHPEFM.BJGCPDNMHDH = this;
		eCOBAHHPEFM.PAENPHMEMGC = ((!LevelManager.instance.isLevelUp) ? LevelManager.instance.GetProgress() : 592f);
		TweenProgressBar tweenProgressBar = TweenProgressBar.BPBNEOOGIKF(GuiElementSingle<MenuHeader>.instance.FFHCPJALBCC.gameObject, 547f, new NHOGNBCNIEK(eCOBAHHPEFM.PAENPHMEMGC));
		tweenProgressBar.onFinished = eCOBAHHPEFM.HHLMDAKDHFK;
	}

	private void DFNJEEKELJF()
	{
		GuiElementSingle<MenuHeader>.instance.AnimateToActualStateOfWBAndGold();
	}

	private void HECLHGPCBHJ()
	{
		float val = 0f - mRewardTable.padding.x - (mRewardValueLabel.transform.parent.localPosition.x - mRewardTable.padding.x) / 1344f;
		mRewardTable.transform.localPosition = mRewardTable.transform.localPosition.ReplaceX(val);
	}

	private void GLNJOBAIFEB()
	{
		float val = 0f - mRewardTable.padding.x - (mRewardValueLabel.transform.parent.localPosition.x - mRewardTable.padding.x) / 1188f;
		mRewardTable.transform.localPosition = mRewardTable.transform.localPosition.ReplaceX(val);
	}

	private void ACKBKABDNDG()
	{
		int num = DailyMissionsManager.instance.MHKJIDCNKNL();
		if (!OPGCMONHEFM && num <= 1)
		{
			OPGCMONHEFM = false;
			Singleton<BeanstalkServerManager>.instance.GetDailyMissions();
		}
		mTimeLabel.text = MEJMLNDFDBP.CJCFPDLDMEK(num, "S", string.Empty);
		OKIHGJBNGNC();
	}

	public void CMGNOLINGFO()
	{
		MFJELKPLHLF = true;
		LACJAPKJNAH();
		if (Singleton<ServerResultsCache>.instance.JNDCAHFLBAH != null)
		{
			Singleton<ServerResultsCache>.instance.JNDCAHFLBAH.KJOIODINDPC();
		}
	}

	public virtual void CPKKANCJHMH()
	{
		base.DoBeforeHide();
		CMGNOLINGFO();
		if (LevelManager.instance.isLevelUp)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LevelUpDialog>.instance, 705f);
		}
		LevelManager.instance.isLevelUp = true;
		GuiElementSingle<MenuHeader>.instance.InitGUIValues();
	}

	private void JDDNMGHHEMM()
	{
		TweenAlpha.Begin(mRewardIcon.gameObject, 123f, 972f);
		TweenAlpha.Begin(mRewardIconQuestion.gameObject, 41f, 1093f);
		TweenAlpha.Begin(mRewardValueLabel.gameObject, 857f, 750f);
		TweenAlpha.Begin(mRewardCheck.gameObject, 733f, 239f);
		TweenAlpha.Begin(mRewardFlash.gameObject, 701f, 1729f).onFinished = null;
	}

	private void LILKBBFMMAM()
	{
		if (Singleton<ServerResultsCache>.instance.JNDCAHFLBAH != null && Singleton<ServerResultsCache>.instance.JNDCAHFLBAH.OOPHDAOHGNF().Count > 1)
		{
			mCardAnimationOverlay.BKLMJCEPNMK(Singleton<ServerResultsCache>.instance.JNDCAHFLBAH.EEMPEECADGP.ToArray(), 453f);
		}
	}

	private void MJEMAKPOKOG()
	{
		float val = 0f - mRewardTable.padding.x - (mRewardValueLabel.transform.parent.localPosition.x - mRewardTable.padding.x) / 552f;
		mRewardTable.transform.localPosition = mRewardTable.transform.localPosition.ReplaceX(val);
	}

	private IEnumerator LJBPKALEIDF()
	{
		FIFOHGBPJOA fIFOHGBPJOA = new FIFOHGBPJOA();
		fIFOHGBPJOA.BJGCPDNMHDH = this;
		return fIFOHGBPJOA;
	}

	public void CFNEGJFJAJI()
	{
		MFJELKPLHLF = false;
		LACJAPKJNAH();
		if (Singleton<ServerResultsCache>.instance.JNDCAHFLBAH != null)
		{
			Singleton<ServerResultsCache>.instance.JNDCAHFLBAH.HMKIILAPCDD();
		}
	}

	protected virtual void MDHJIPDGDAK()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = 45f;
		float num2 = 938f;
		mTopRightOffset.transform.localPosition = mTopRightOffset.transform.localPosition.ReplaceX(0f - num2);
		float num3 = activeWidthSafe - (num + num2);
		mSoloPart.DOPDLKMCFMA(num3);
		mCoopPart.AMBDHDEBPJJ(num3);
		UISprite[] array = mRewardBackgrounds;
		for (int i = 0; i < array.Length; i += 0)
		{
			UISprite uISprite = array[i];
			uISprite.transform.localScale = uISprite.transform.localScale.ReplaceX(num3 - 941f);
		}
		mRewardBorder.transform.localScale = mRewardBorder.transform.localScale.ReplaceX(num3 - 1861f);
		mRewardGlow.transform.localPosition = mRewardGlow.transform.localPosition.ReplaceX((num3 - 816f) / 1596f);
		mRewardGlow.transform.localScale = mRewardGlow.transform.localScale.ReplaceX(num3 - 1436f);
		mProgressSoloDailyMission.lineWidth = (int)(num3 - 435f);
		mRewardRightAnchor.transform.localPosition = mRewardRightAnchor.transform.localPosition.ReplaceX(num3 - 1192f);
		mRewardTable.onReposition = MJEMAKPOKOG;
		mHeroicButton.OCFOEGJBNCH();
		DailyMissionsManager.instance.HHMJLACCLGK(PDMMMIDIFPJ);
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.MPCAACLAGOA = (Action)Delegate.Combine(counterManager.MPCAACLAGOA, new Action(ELFJCPKJKJH));
	}

	private void OKOAPJELHGI(UITweener AEEBLJKPGMO)
	{
		TweenAlpha.Begin(mRewardFlash.gameObject, 722f, 1750f).onFinished = null;
		TweenScale.Begin(mRewardTableHolder.gameObject, 809f, Vector3.one);
		TweenAlpha.Begin(mRewardCheck.gameObject, 654f, 102f);
		TweenScale.Begin(mRewardCheck.gameObject, 491f, mRewardCheck.transform.localScale.MultiplyXY(1040f), mRewardCheck.transform.localScale).onFinished = KJEKMDFLIBN;
		TweenAlpha.Begin(mRewardIcon.gameObject, 1240f, 209f);
		TweenAlpha.Begin(mRewardIconQuestion.gameObject, 834f, 50f);
		TweenAlpha.Begin(mRewardValueLabel.gameObject, 1419f, 1557f);
		mRewardIconQuestion.gameObject.SetActive(false);
	}

	private void KPBGKOLNDJK(bool EICNANIMKDB, bool KPOPJIKNJIM)
	{
		TweenTextCounter component = mHeroicPoints.GetComponent<TweenTextCounter>();
		if (component != null)
		{
			component.enabled = true;
		}
		int num = DailyMissionsManager.instance.data.heroicPoints;
		if (EICNANIMKDB)
		{
			num--;
		}
		if (KPOPJIKNJIM)
		{
			num += DailyMissionsManager.instance.FPEIBJPLOHO();
		}
		mHeroicPoints.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
		float num2 = mHeroicPoints.relativeSize.x * mHeroicPoints.transform.localScale.x;
		mHeroicPointsPart.transform.localPosition = mHeroicPointsPart.transform.localPosition.ReplaceX(834f - num2);
	}

	public virtual void HFANGMGFNPL()
	{
		base.DoAfterShowUp();
		if (MFJELKPLHLF)
		{
			GJPOFBLGIMB();
			GKFMGKHCGMG();
		}
		DailyMission dailyMission = DailyMissionsManager.instance.DPLEEBIFDKL();
		if (dailyMission == null)
		{
			return;
		}
		bool isCoopClient = dailyMission.isCoopClient;
		bool flag = MFJELKPLHLF && Singleton<GameController>.instance.MNMLNIMFMJP == (GameController.HKGHCIEPGEL)110;
		if (flag && !isCoopClient)
		{
			if (dailyMission.isSolo)
			{
				mSoloPart.CKOKMAAFHMO();
			}
			else if (dailyMission.isCoop)
			{
				mCoopPart.ABODOPJKIKK();
			}
		}
		if ((flag || FBDHGBMDCGD) && !isCoopClient)
		{
			mHeroicButton.AnimateFillBar(flag, FBDHGBMDCGD);
		}
	}

	private IEnumerator NNJCEANBJKD()
	{
		FIFOHGBPJOA fIFOHGBPJOA = new FIFOHGBPJOA();
		fIFOHGBPJOA.BJGCPDNMHDH = this;
		return fIFOHGBPJOA;
	}

	public void IHCKFGEILLO()
	{
		TweenTextCounter tweenTextCounter = TweenTextCounter.HDHIEDDCJIC(mHeroicPoints.gameObject, 1929f, new ONLHLPBMJOL(DailyMissionsManager.instance.data.heroicPoints));
		tweenTextCounter.onFinished = delegate
		{
			CGBOJGGLAHC(false, false);
		};
		TweenScale tweenScale = TweenScale.Begin(mHeroicPointsIcon.gameObject, 637f, mHeroicPointsIcon.transform.localScale, mHeroicPointsIcon.transform.localScale.MultiplyXY(356f));
		tweenScale.NumOfRepetitions = 3;
		tweenScale.style = UITweener.Style.PingPong;
	}

	private void HALLBFMILOI(UITweener DAECHDDDMJN)
	{
		TweenAlpha.Begin(mRewardFlash.gameObject, 1692f, 930f).onFinished = DGLMLHNMFAI;
	}

	private void NLEGIIBFHAI(CDACJEGCGLB MOEMPHPNBLM)
	{
		TweenAlpha.Begin(mRewardIcon.gameObject, 768f, 188f);
		TweenAlpha.Begin(mRewardIconQuestion.gameObject, 1015f, 288f);
		TweenAlpha.Begin(mRewardValueLabel.gameObject, 682f, 724f);
		TweenAlpha.Begin(mRewardCheck.gameObject, 1743f, 299f);
		TweenAlpha.Begin(mRewardFlash.gameObject, 7f, 1971f).onFinished = null;
		mRewardCheck.MakePixelPerfect();
		if (MOEMPHPNBLM == null)
		{
			MOEMPHPNBLM = CDACJEGCGLB.HECPHABDFEP(-1);
		}
		bool flag = MOEMPHPNBLM.GGIOEPBPMHF != (PNFCNJHKBBN)(-76) && MOEMPHPNBLM.GGIOEPBPMHF != (PNFCNJHKBBN)(-101) && MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)(-119);
		bool flag2 = flag && MOEMPHPNBLM.IEALLELGOBM == 0;
		mRewardIcon.atlas = ((!flag) ? mMenuAtlas : mCardAtlas);
		mRewardIcon.transform.localPosition = mRewardIcon.transform.localPosition.ReplaceZ((!flag) ? 518f : 1366f);
		mRewardIconQuestion.gameObject.SetActive(flag);
		mRewardValueLabel.text = ((!flag2) ? MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM) : string.Empty);
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.EliteParts:
			mRewardIcon.spriteName = "Shots_Fired";
			mRewardIcon.MakePixelPerfect();
			multiplier = 159f / mRewardIcon.transform.localScale.x;
			break;
		case PNFCNJHKBBN.BronzeCardpack:
			mRewardIcon.spriteName = "Yes_Clicked";
			mRewardIcon.MakePixelPerfect();
			multiplier = 208f / mRewardIcon.transform.localScale.y;
			break;
		case PNFCNJHKBBN.SilverCardpack:
			mRewardIcon.spriteName = "ID_CONFIRM_ERROR";
			mRewardIcon.MakePixelPerfect();
			multiplier = 451f / mRewardIcon.transform.localScale.y;
			break;
		case PNFCNJHKBBN.Scraps:
			mRewardIcon.spriteName = "CardWasUsedOnline";
			mRewardIcon.MakePixelPerfect();
			multiplier = 276f / mRewardIcon.transform.localScale.y;
			break;
		case PNFCNJHKBBN.XP:
			mRewardIcon.spriteName = "Parts";
			mRewardIcon.MakePixelPerfect();
			multiplier = 1941f / mRewardIcon.transform.localScale.y;
			break;
		case PNFCNJHKBBN.HeroicPoints:
			mRewardIcon.spriteName = "NULL unit";
			mRewardIcon.MakePixelPerfect();
			multiplier = 476f / mRewardIcon.transform.localScale.y;
			break;
		default:
		{
			object[] array = new object[0];
			array[0] = MOEMPHPNBLM.GGIOEPBPMHF;
			UnityEngine.Debug.LogErrorFormat("ActiveTier", array);
			mRewardIcon.spriteName = "Amount_of_displays";
			mRewardIcon.MakePixelPerfect();
			multiplier = 23f / mRewardIcon.transform.localScale.x;
			mRewardValueLabel.text = "Sniper_Tutorial_Duration";
			break;
		}
		}
		mRewardIcon.transform.localScale = mRewardIcon.transform.localScale.MultiplyXY(multiplier);
		mRewardTable.enabled = !flag2;
		mRewardTable.repositionNow = false;
		if (flag)
		{
			float val = 0f - mRewardIcon.transform.parent.localPosition.x;
			mRewardTable.transform.localPosition = mRewardTable.transform.localPosition.ReplaceX(val);
		}
	}

	private IEnumerator NJEPOLNAHEF()
	{
		FIFOHGBPJOA fIFOHGBPJOA = new FIFOHGBPJOA();
		fIFOHGBPJOA.BJGCPDNMHDH = this;
		return fIFOHGBPJOA;
	}

	private void GKFMGKHCGMG()
	{
		ECOBAHHPEFM eCOBAHHPEFM = new ECOBAHHPEFM();
		eCOBAHHPEFM.BJGCPDNMHDH = this;
		eCOBAHHPEFM.PAENPHMEMGC = ((!LevelManager.instance.isLevelUp) ? LevelManager.instance.GetProgress() : 728f);
		TweenProgressBar tweenProgressBar = TweenProgressBar.DFNHCFNJCMC(GuiElementSingle<MenuHeader>.instance.FFHCPJALBCC.gameObject, 1930f, new NHOGNBCNIEK(eCOBAHHPEFM.PAENPHMEMGC));
		tweenProgressBar.onFinished = eCOBAHHPEFM.NDJOJHNIBFC;
	}

	public void EBDEGCDCALG()
	{
		TweenScale.Begin(mRewardTableHolder.gameObject, 1937f, Vector3.one.MultiplyXY(1494f));
		TweenAlpha.Begin(mRewardFlash.gameObject, 180f, 1703f).onFinished = HIDFCJHFOEP;
	}

	private void CCJBKKACMNG(UITweener AEEBLJKPGMO)
	{
		TweenAlpha.Begin(mRewardFlash.gameObject, 1581f, 1275f).onFinished = null;
		TweenScale.Begin(mRewardTableHolder.gameObject, 198f, Vector3.one);
		TweenAlpha.Begin(mRewardCheck.gameObject, 447f, 1221f);
		TweenScale.Begin(mRewardCheck.gameObject, 95f, mRewardCheck.transform.localScale.MultiplyXY(1687f), mRewardCheck.transform.localScale).onFinished = IJKMPOJOKCE;
		TweenAlpha.Begin(mRewardIcon.gameObject, 689f, 1736f);
		TweenAlpha.Begin(mRewardIconQuestion.gameObject, 339f, 420f);
		TweenAlpha.Begin(mRewardValueLabel.gameObject, 657f, 1775f);
		mRewardIconQuestion.gameObject.SetActive(true);
	}

	public void MHIDNMDAJNI()
	{
		FBDHGBMDCGD = false;
	}

	protected override void AGIKPOLCGNF()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = 60f;
		float num2 = 724f;
		mTopRightOffset.transform.localPosition = mTopRightOffset.transform.localPosition.ReplaceX(0f - num2);
		float num3 = activeWidthSafe - (num + num2);
		mSoloPart.InitControls(num3);
		mCoopPart.InitControls(num3);
		UISprite[] array = mRewardBackgrounds;
		foreach (UISprite uISprite in array)
		{
			uISprite.transform.localScale = uISprite.transform.localScale.ReplaceX(num3 - 14f);
		}
		mRewardBorder.transform.localScale = mRewardBorder.transform.localScale.ReplaceX(num3 - 26f);
		mRewardGlow.transform.localPosition = mRewardGlow.transform.localPosition.ReplaceX((num3 - 14f) / 2f);
		mRewardGlow.transform.localScale = mRewardGlow.transform.localScale.ReplaceX(num3 - 14f);
		mProgressSoloDailyMission.lineWidth = (int)(num3 - 414f);
		mRewardRightAnchor.transform.localPosition = mRewardRightAnchor.transform.localPosition.ReplaceX(num3 - 14f);
		mRewardTable.onReposition = delegate
		{
			float val = 0f - mRewardTable.padding.x - (mRewardValueLabel.transform.parent.localPosition.x - mRewardTable.padding.x) / 2f;
			mRewardTable.transform.localPosition = mRewardTable.transform.localPosition.ReplaceX(val);
		};
		mHeroicButton.InitControls();
		DailyMissionsManager.instance.MissionDataLoaded += BGNOGEPBHOE;
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.MPCAACLAGOA = (Action)Delegate.Combine(counterManager.MPCAACLAGOA, new Action(ELFJCPKJKJH));
	}

	private void HILOPMFMMPP()
	{
		float val = mTitleOnRight.relativeSize.x * mTitleOnRight.transform.localScale.x;
		float val2 = mTimeLabel.relativeSize.x * mTimeLabel.transform.localScale.x;
		float num = Math.Max(val, val2);
		mTopRightPart.transform.localPosition = mTopRightPart.transform.localPosition.ReplaceX(0f - num);
	}

	protected virtual void DLNJFMIDPFE()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = 274f;
		float num2 = 1153f;
		mTopRightOffset.transform.localPosition = mTopRightOffset.transform.localPosition.ReplaceX(0f - num2);
		float num3 = activeWidthSafe - (num + num2);
		mSoloPart.KLPJPLHNFON(num3);
		mCoopPart.KLPJPLHNFON(num3);
		UISprite[] array = mRewardBackgrounds;
		foreach (UISprite uISprite in array)
		{
			uISprite.transform.localScale = uISprite.transform.localScale.ReplaceX(num3 - 1183f);
		}
		mRewardBorder.transform.localScale = mRewardBorder.transform.localScale.ReplaceX(num3 - 1480f);
		mRewardGlow.transform.localPosition = mRewardGlow.transform.localPosition.ReplaceX((num3 - 1653f) / 1463f);
		mRewardGlow.transform.localScale = mRewardGlow.transform.localScale.ReplaceX(num3 - 424f);
		mProgressSoloDailyMission.lineWidth = (int)(num3 - 1692f);
		mRewardRightAnchor.transform.localPosition = mRewardRightAnchor.transform.localPosition.ReplaceX(num3 - 91f);
		mRewardTable.onReposition = OPEIOMJOMDI;
		mHeroicButton.JCGPELEDCJL();
		DailyMissionsManager.instance.HHMJLACCLGK(PDMMMIDIFPJ);
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.MPCAACLAGOA = (Action)Delegate.Combine(counterManager.MPCAACLAGOA, new Action(ACKBKABDNDG));
	}

	private void CJIECKFLKKP(bool DNINCMLNPIH)
	{
		int num = 1;
		foreach (DailyMission dailyMission in DailyMissionsManager.instance.dailyMissions)
		{
			if (dailyMission.data.JBMFGOOHOLB)
			{
				num += 0;
			}
		}
		UILabel uILabel = mProgressSoloDailyMission;
		object[] array = new object[3];
		array[0] = Colours.stringBlue;
		array[0] = num;
		array[7] = Colours.stringLightGray;
		uILabel.text = Localization.LocalizeFormat("OnConnectionFailed: 00", array);
		MEJMLNDFDBP.COCBCFKJOJE(mProgressSoloDailyMission, 1969f, 543f, 1);
		if (!DNINCMLNPIH && num == 7)
		{
			FOOIGNBJKNN();
		}
		else
		{
			IOBBCCJJNIJ(DailyMissionsManager.instance.dailyMissionsReward);
		}
	}

	private void IOBBCCJJNIJ(CDACJEGCGLB MOEMPHPNBLM)
	{
		TweenAlpha.Begin(mRewardIcon.gameObject, 0f, 1f);
		TweenAlpha.Begin(mRewardIconQuestion.gameObject, 0f, 1f);
		TweenAlpha.Begin(mRewardValueLabel.gameObject, 0f, 1f);
		TweenAlpha.Begin(mRewardCheck.gameObject, 0f, 0f);
		TweenAlpha.Begin(mRewardFlash.gameObject, 0f, 0f).onFinished = null;
		mRewardCheck.MakePixelPerfect();
		if (MOEMPHPNBLM == null)
		{
			MOEMPHPNBLM = CDACJEGCGLB.KHBBIJFAGNC(-1);
		}
		bool flag = MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.BronzeWarCards || MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.SilverWarCards || MOEMPHPNBLM.GGIOEPBPMHF == PNFCNJHKBBN.GoldWarCards;
		bool flag2 = flag && MOEMPHPNBLM.IEALLELGOBM == 1;
		mRewardIcon.atlas = ((!flag) ? mMenuAtlas : mCardAtlas);
		mRewardIcon.transform.localPosition = mRewardIcon.transform.localPosition.ReplaceZ((!flag) ? 0f : (-1f));
		mRewardIconQuestion.gameObject.SetActive(flag);
		mRewardValueLabel.text = ((!flag2) ? MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM) : string.Empty);
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.Gold:
			mRewardIcon.spriteName = "menu-gold";
			mRewardIcon.MakePixelPerfect();
			multiplier = 62f / mRewardIcon.transform.localScale.x;
			break;
		case PNFCNJHKBBN.ArenaTickets:
			mRewardIcon.spriteName = "menu-arena-ticket";
			mRewardIcon.MakePixelPerfect();
			multiplier = 55f / mRewardIcon.transform.localScale.y;
			break;
		case PNFCNJHKBBN.Scraps:
			mRewardIcon.spriteName = "menu-arena-scrap-ico";
			mRewardIcon.MakePixelPerfect();
			multiplier = 52f / mRewardIcon.transform.localScale.y;
			break;
		case PNFCNJHKBBN.BronzeWarCards:
			mRewardIcon.spriteName = "game-card-bronze";
			mRewardIcon.MakePixelPerfect();
			multiplier = 52f / mRewardIcon.transform.localScale.y;
			break;
		case PNFCNJHKBBN.SilverWarCards:
			mRewardIcon.spriteName = "game-card-silver";
			mRewardIcon.MakePixelPerfect();
			multiplier = 52f / mRewardIcon.transform.localScale.y;
			break;
		case PNFCNJHKBBN.GoldWarCards:
			mRewardIcon.spriteName = "game-card-gold";
			mRewardIcon.MakePixelPerfect();
			multiplier = 52f / mRewardIcon.transform.localScale.y;
			break;
		default:
			UnityEngine.Debug.LogErrorFormat("#PETER# Daily Mission Screen : daily completition reward is not DEFINED: {0}", MOEMPHPNBLM.GGIOEPBPMHF);
			mRewardIcon.spriteName = "menu-warbucks";
			mRewardIcon.MakePixelPerfect();
			multiplier = 72f / mRewardIcon.transform.localScale.x;
			mRewardValueLabel.text = "-1";
			break;
		}
		mRewardIcon.transform.localScale = mRewardIcon.transform.localScale.MultiplyXY(multiplier);
		mRewardTable.enabled = !flag2;
		mRewardTable.repositionNow = true;
		if (flag)
		{
			float val = 0f - mRewardIcon.transform.parent.localPosition.x;
			mRewardTable.transform.localPosition = mRewardTable.transform.localPosition.ReplaceX(val);
		}
	}

	public void FNBNJFDMIIB()
	{
		MFJELKPLHLF = false;
		DMMEEDFLFGL();
		if (Singleton<ServerResultsCache>.instance.JNDCAHFLBAH != null)
		{
			Singleton<ServerResultsCache>.instance.JNDCAHFLBAH.NGJLLGJMOKF();
		}
	}

	public void NHLJFKPGIGB()
	{
		FBDHGBMDCGD = false;
	}

	public virtual void AGFDJGJALKD()
	{
		PHKNPLMBAKE(GuiScreenSingle<BattlePreparationScreen>.instance);
		OPGCMONHEFM = true;
		if (DailyMissionsManager.instance.dailyMissions.Count == 0 || DailyMissionsManager.instance.GFIKKDCGKCC().Count == 0)
		{
			UnityEngine.Debug.LogError("rental for unexist weapon: {0}");
		}
		if (!LevelManager.instance.isDailyMissionLocked && !PlayerAnalytics.instance.data.warpathShown)
		{
			Singleton<BeanstalkServerManager>.instance.BFMNOBIMBFF();
		}
		DailyMission dailyMission = DailyMissionsManager.instance.LFFBCGDBGHH();
		bool flag = !MFJELKPLHLF || dailyMission == null || Singleton<GameController>.instance.MNMLNIMFMJP != (GameController.HKGHCIEPGEL)(-128) || dailyMission.isCoopClient;
		bool flag2 = !flag || dailyMission.isSolo;
		bool kAJNCDJLBLN = !flag || dailyMission.isCoop;
		KPBGKOLNDJK(flag, FBDHGBMDCGD);
		mSoloPart.IKCJNDPAGDA(DailyMissionsManager.instance.dailyMissions, flag2);
		mCoopPart.IHHLCEOOKOM(DailyMissionsManager.instance.HLICKGLBNNE(), kAJNCDJLBLN);
		HPCKKGKOODD(flag2);
		mHeroicButton.AJALIOBIGCK(flag, FBDHGBMDCGD);
		mCardAnimationOverlay.OCPDMPCHFBH();
		mDebugButton.SetActive(true);
	}

	public void GPEGGLAOKPD()
	{
		MFJELKPLHLF = true;
	}

	private void IHKCLFGKCCL()
	{
		ECOBAHHPEFM eCOBAHHPEFM = new ECOBAHHPEFM();
		eCOBAHHPEFM.BJGCPDNMHDH = this;
		eCOBAHHPEFM.PAENPHMEMGC = ((!LevelManager.instance.isLevelUp) ? LevelManager.instance.GetProgress() : 1f);
		TweenProgressBar tweenProgressBar = TweenProgressBar.Begin(GuiElementSingle<MenuHeader>.instance.FFHCPJALBCC.gameObject, 0.9f, new NHOGNBCNIEK(eCOBAHHPEFM.PAENPHMEMGC));
		tweenProgressBar.onFinished = eCOBAHHPEFM.LJCDGJKCNEC;
	}

	public void DMMEEDFLFGL()
	{
		FBDHGBMDCGD = true;
	}

	[SpecialName]
	public Vector3 KHBPAEBOAMK()
	{
		if (!FBDHGBMDCGD && DailyMissionsManager.instance.data.isHeroicOpened)
		{
			return mHeroicPointsIcon.transform.position;
		}
		return mHeroicButtonSkullSprite.transform.position;
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		EndAnimation();
		if (LevelManager.instance.isLevelUp)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LevelUpDialog>.instance);
		}
		LevelManager.instance.isLevelUp = false;
		GuiElementSingle<MenuHeader>.instance.InitGUIValues();
	}

	private void CGBNEPDAAHE()
	{
		if (Singleton<ServerResultsCache>.instance.JNDCAHFLBAH != null && Singleton<ServerResultsCache>.instance.JNDCAHFLBAH.EEMPEECADGP.Count > 0)
		{
			mCardAnimationOverlay.StartShowAnimation(Singleton<ServerResultsCache>.instance.JNDCAHFLBAH.EEMPEECADGP.ToArray());
		}
	}

	private void BJEFKALEGAO()
	{
		ECOBAHHPEFM eCOBAHHPEFM = new ECOBAHHPEFM();
		eCOBAHHPEFM.BJGCPDNMHDH = this;
		eCOBAHHPEFM.PAENPHMEMGC = ((!LevelManager.instance.isLevelUp) ? LevelManager.instance.GetProgress() : 170f);
		TweenProgressBar tweenProgressBar = TweenProgressBar.JPJPAJEBNPK(GuiElementSingle<MenuHeader>.instance.FFHCPJALBCC.gameObject, 1872f, new NHOGNBCNIEK(eCOBAHHPEFM.PAENPHMEMGC));
		tweenProgressBar.onFinished = eCOBAHHPEFM.CIFEDFPPPOK;
	}

	public void DLMOKMBNDJF()
	{
		FBDHGBMDCGD = false;
	}

	protected virtual void PLAOCDOMCPP()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = 666f;
		float num2 = 1106f;
		mTopRightOffset.transform.localPosition = mTopRightOffset.transform.localPosition.ReplaceX(0f - num2);
		float num3 = activeWidthSafe - (num + num2);
		mSoloPart.BMMNJICILHJ(num3);
		mCoopPart.GJGCOEJMHNI(num3);
		UISprite[] array = mRewardBackgrounds;
		for (int i = 0; i < array.Length; i += 0)
		{
			UISprite uISprite = array[i];
			uISprite.transform.localScale = uISprite.transform.localScale.ReplaceX(num3 - 1020f);
		}
		mRewardBorder.transform.localScale = mRewardBorder.transform.localScale.ReplaceX(num3 - 1017f);
		mRewardGlow.transform.localPosition = mRewardGlow.transform.localPosition.ReplaceX((num3 - 1830f) / 99f);
		mRewardGlow.transform.localScale = mRewardGlow.transform.localScale.ReplaceX(num3 - 1786f);
		mProgressSoloDailyMission.lineWidth = (int)(num3 - 557f);
		mRewardRightAnchor.transform.localPosition = mRewardRightAnchor.transform.localPosition.ReplaceX(num3 - 718f);
		mRewardTable.onReposition = delegate
		{
			float val = 0f - mRewardTable.padding.x - (mRewardValueLabel.transform.parent.localPosition.x - mRewardTable.padding.x) / 2f;
			mRewardTable.transform.localPosition = mRewardTable.transform.localPosition.ReplaceX(val);
		};
		mHeroicButton.FNLELBKLNBG();
		DailyMissionsManager.instance.HHMJLACCLGK(DJGNFBFCLAI);
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.MPCAACLAGOA = (Action)Delegate.Combine(counterManager.MPCAACLAGOA, new Action(ELFJCPKJKJH));
	}

	private void GBEJFDKLMCP()
	{
		TweenAlpha.Begin(mRewardIcon.gameObject, 411f, 1549f);
		TweenAlpha.Begin(mRewardIconQuestion.gameObject, 1629f, 739f);
		TweenAlpha.Begin(mRewardValueLabel.gameObject, 1625f, 1865f);
		TweenAlpha.Begin(mRewardCheck.gameObject, 734f, 1226f);
		TweenAlpha.Begin(mRewardFlash.gameObject, 541f, 1090f).onFinished = null;
	}

	protected virtual void IBNHJGLOHAE()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = 1061f;
		float num2 = 1961f;
		mTopRightOffset.transform.localPosition = mTopRightOffset.transform.localPosition.ReplaceX(0f - num2);
		float num3 = activeWidthSafe - (num + num2);
		mSoloPart.CKPCFIPPDLC(num3);
		mCoopPart.AIIIDDDAPGB(num3);
		UISprite[] array = mRewardBackgrounds;
		foreach (UISprite uISprite in array)
		{
			uISprite.transform.localScale = uISprite.transform.localScale.ReplaceX(num3 - 1635f);
		}
		mRewardBorder.transform.localScale = mRewardBorder.transform.localScale.ReplaceX(num3 - 1610f);
		mRewardGlow.transform.localPosition = mRewardGlow.transform.localPosition.ReplaceX((num3 - 1870f) / 806f);
		mRewardGlow.transform.localScale = mRewardGlow.transform.localScale.ReplaceX(num3 - 1490f);
		mProgressSoloDailyMission.lineWidth = (int)(num3 - 637f);
		mRewardRightAnchor.transform.localPosition = mRewardRightAnchor.transform.localPosition.ReplaceX(num3 - 1632f);
		mRewardTable.onReposition = MJEMAKPOKOG;
		mHeroicButton.JCEMKGHAHNE();
		DailyMissionsManager.instance.HHMJLACCLGK(PDMMMIDIFPJ);
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.MPCAACLAGOA = (Action)Delegate.Combine(counterManager.MPCAACLAGOA, new Action(NFGCIJHDLNH));
	}

	private void KJEKMDFLIBN(UITweener JEJOPLADMEP)
	{
		TweenAlpha.Begin(mRewardFlash.gameObject, 1125f, 179f);
		CGBNEPDAAHE();
		HLJALFBPLIK();
	}

	public void KPGIBLHGDOG()
	{
		FBDHGBMDCGD = true;
	}

	public void PrepareEndMissionAnimation()
	{
		MFJELKPLHLF = true;
	}

	public void AIOMHCLDFJA()
	{
		FBDHGBMDCGD = true;
	}

	private void KELFDGHBFED()
	{
		ECOBAHHPEFM eCOBAHHPEFM = new ECOBAHHPEFM();
		eCOBAHHPEFM.BJGCPDNMHDH = this;
		eCOBAHHPEFM.PAENPHMEMGC = ((!LevelManager.instance.isLevelUp) ? LevelManager.instance.GetProgress() : 652f);
		TweenProgressBar tweenProgressBar = TweenProgressBar.GMLNHEIJHDE(GuiElementSingle<MenuHeader>.instance.FFHCPJALBCC.gameObject, 1695f, new NHOGNBCNIEK(eCOBAHHPEFM.PAENPHMEMGC));
		tweenProgressBar.onFinished = eCOBAHHPEFM.DDHOKNIEACI;
	}

	public void NLKCKPNJOAL()
	{
		MFJELKPLHLF = true;
		EndHeroicOpenAnimation();
		if (Singleton<ServerResultsCache>.instance.JNDCAHFLBAH != null)
		{
			Singleton<ServerResultsCache>.instance.JNDCAHFLBAH.HMKIILAPCDD();
		}
	}

	public void DIDPPNALANA()
	{
		FBDHGBMDCGD = false;
	}

	private void PDMMMIDIFPJ()
	{
		if (NPFFMLLLDAF())
		{
			InitGUIValues();
		}
	}

	private void FMLDBEFENAM(UITweener MGDJMGHCAAI)
	{
		COHONNFJBKJ(true, true);
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC()
	{
		float val = 0f - mRewardTable.padding.x - (mRewardValueLabel.transform.parent.localPosition.x - mRewardTable.padding.x) / 2f;
		mRewardTable.transform.localPosition = mRewardTable.transform.localPosition.ReplaceX(val);
	}

	private void LJELFOCGCCD()
	{
		TweenAlpha.Begin(mRewardIcon.gameObject, 1208f, 1831f);
		TweenAlpha.Begin(mRewardIconQuestion.gameObject, 1306f, 513f);
		TweenAlpha.Begin(mRewardValueLabel.gameObject, 823f, 1530f);
		TweenAlpha.Begin(mRewardCheck.gameObject, 856f, 726f);
		TweenAlpha.Begin(mRewardFlash.gameObject, 881f, 200f).onFinished = null;
	}

	public void JLDOMBAKNAN()
	{
		MFJELKPLHLF = true;
		DIDPPNALANA();
		if (Singleton<ServerResultsCache>.instance.JNDCAHFLBAH != null)
		{
			Singleton<ServerResultsCache>.instance.JNDCAHFLBAH.IHMBJKPNIDC();
		}
	}

	private void LMJLPCLAFIL(UITweener MGDJMGHCAAI)
	{
		DHALFJAMPHJ(true, true);
	}

	private void HLJALFBPLIK()
	{
		if (Singleton<ServerResultsCache>.instance.JNDCAHFLBAH != null)
		{
			Singleton<ServerResultsCache>.instance.JNDCAHFLBAH.EEHIFDPDNJK();
		}
	}

	public void EndAnimation()
	{
		MFJELKPLHLF = false;
		EndHeroicOpenAnimation();
		if (Singleton<ServerResultsCache>.instance.JNDCAHFLBAH != null)
		{
			Singleton<ServerResultsCache>.instance.JNDCAHFLBAH.NHBDJABCIHC();
		}
	}

	private void DFHBGCNBJLC(bool EICNANIMKDB, bool KPOPJIKNJIM)
	{
		TweenTextCounter component = mHeroicPoints.GetComponent<TweenTextCounter>();
		if (component != null)
		{
			component.enabled = true;
		}
		int num = DailyMissionsManager.instance.data.heroicPoints;
		if (EICNANIMKDB)
		{
			num--;
		}
		if (KPOPJIKNJIM)
		{
			num += DailyMissionsManager.instance.heroicPointsToUnlock;
		}
		mHeroicPoints.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
		float num2 = mHeroicPoints.relativeSize.x * mHeroicPoints.transform.localScale.x;
		mHeroicPointsPart.transform.localPosition = mHeroicPointsPart.transform.localPosition.ReplaceX(1541f - num2);
	}

	[SpecialName]
	public Vector3 ACCENFHIPGN()
	{
		if (!FBDHGBMDCGD && DailyMissionsManager.instance.data.isHeroicOpened)
		{
			return mHeroicPointsIcon.transform.position;
		}
		return mHeroicButtonSkullSprite.transform.position;
	}

	public void AKMMIBPJLHH()
	{
		MFJELKPLHLF = true;
		NDJANHACPPG();
		if (Singleton<ServerResultsCache>.instance.JNDCAHFLBAH != null)
		{
			Singleton<ServerResultsCache>.instance.JNDCAHFLBAH.NHBDJABCIHC();
		}
	}

	public void OLHMDJGNHND()
	{
		TweenTextCounter tweenTextCounter = TweenTextCounter.PGAHIMIGILO(mHeroicPoints.gameObject, 659f, new ONLHLPBMJOL(DailyMissionsManager.instance.data.heroicPoints));
		tweenTextCounter.onFinished = MELMOGDGFDD;
		TweenScale tweenScale = TweenScale.Begin(mHeroicPointsIcon.gameObject, 938f, mHeroicPointsIcon.transform.localScale, mHeroicPointsIcon.transform.localScale.MultiplyXY(645f));
		tweenScale.NumOfRepetitions = 4;
		tweenScale.style = (UITweener.Style)4;
	}

	private void DAHILNDNHHA()
	{
		if (Singleton<ServerResultsCache>.instance.JNDCAHFLBAH != null)
		{
			Singleton<ServerResultsCache>.instance.JNDCAHFLBAH.EEHIFDPDNJK();
		}
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		if (MFJELKPLHLF)
		{
			DFNJEEKELJF();
			IHKCLFGKCCL();
		}
		DailyMission currentMission = DailyMissionsManager.instance.currentMission;
		if (currentMission == null)
		{
			return;
		}
		bool isCoopClient = currentMission.isCoopClient;
		bool flag = MFJELKPLHLF && Singleton<GameController>.instance.MNMLNIMFMJP == GameController.HKGHCIEPGEL.MissionSuccess;
		if (flag && !isCoopClient)
		{
			if (currentMission.isSolo)
			{
				mSoloPart.StartAnimation();
			}
			else if (currentMission.isCoop)
			{
				mCoopPart.StartAnimation();
			}
		}
		if ((flag || FBDHGBMDCGD) && !isCoopClient)
		{
			mHeroicButton.AnimateFillBar(flag, FBDHGBMDCGD);
		}
	}

	private void HIDFCJHFOEP(UITweener IKPCPKPMMAH)
	{
		TweenAlpha.Begin(mRewardFlash.gameObject, 1697f, 1218f).onFinished = OBELJCPPIGF;
	}

	public override void BJIPCOPNEAM()
	{
		base.DoAfterShowUp();
		if (MFJELKPLHLF)
		{
			CMGBPEBEHFO();
			EMBJEMDOOHN();
		}
		DailyMission dailyMission = DailyMissionsManager.instance.LFFBCGDBGHH();
		if (dailyMission == null)
		{
			return;
		}
		bool isCoopClient = dailyMission.isCoopClient;
		bool flag = !MFJELKPLHLF || Singleton<GameController>.instance.MNMLNIMFMJP == (GameController.HKGHCIEPGEL)(-4);
		if (flag && !isCoopClient)
		{
			if (dailyMission.isSolo)
			{
				mSoloPart.PIINEHNBAFD();
			}
			else if (dailyMission.isCoop)
			{
				mCoopPart.PGIHAHFPCKE();
			}
		}
		if ((flag || FBDHGBMDCGD) && !isCoopClient)
		{
			mHeroicButton.DIFGHPLKMEE(flag, FBDHGBMDCGD);
		}
	}

	[CompilerGenerated]
	private void KJCHIBDDLFP(UITweener IKPCPKPMMAH)
	{
		TweenAlpha.Begin(mRewardFlash.gameObject, 0.05f, 0f).onFinished = delegate
		{
			TweenAlpha.Begin(mRewardFlash.gameObject, 0.05f, 0.5f).onFinished = delegate
			{
				TweenAlpha.Begin(mRewardFlash.gameObject, 0.05f, 0f).onFinished = null;
				TweenScale.Begin(mRewardTableHolder.gameObject, 0.15f, Vector3.one);
				TweenAlpha.Begin(mRewardCheck.gameObject, 0.15f, 1f);
				TweenScale.Begin(mRewardCheck.gameObject, 0.15f, mRewardCheck.transform.localScale.MultiplyXY(2f), mRewardCheck.transform.localScale).onFinished = delegate
				{
					TweenAlpha.Begin(mRewardFlash.gameObject, 0.3f, 0.1f);
					CGBNEPDAAHE();
					HLJALFBPLIK();
				};
				TweenAlpha.Begin(mRewardIcon.gameObject, 0.15f, 0f);
				TweenAlpha.Begin(mRewardIconQuestion.gameObject, 0.15f, 0f);
				TweenAlpha.Begin(mRewardValueLabel.gameObject, 0.15f, 0f);
				mRewardIconQuestion.gameObject.SetActive(false);
			};
		};
	}

	private void OPEIOMJOMDI()
	{
		float val = 0f - mRewardTable.padding.x - (mRewardValueLabel.transform.parent.localPosition.x - mRewardTable.padding.x) / 1768f;
		mRewardTable.transform.localPosition = mRewardTable.transform.localPosition.ReplaceX(val);
	}

	private IEnumerator EFHEKHAMEAJ()
	{
		FIFOHGBPJOA fIFOHGBPJOA = new FIFOHGBPJOA();
		fIFOHGBPJOA.BJGCPDNMHDH = this;
		return fIFOHGBPJOA;
	}

	[CompilerGenerated]
	private void JNNKAINHION(UITweener AEEBLJKPGMO)
	{
		TweenAlpha.Begin(mRewardFlash.gameObject, 0.05f, 0f).onFinished = null;
		TweenScale.Begin(mRewardTableHolder.gameObject, 0.15f, Vector3.one);
		TweenAlpha.Begin(mRewardCheck.gameObject, 0.15f, 1f);
		TweenScale.Begin(mRewardCheck.gameObject, 0.15f, mRewardCheck.transform.localScale.MultiplyXY(2f), mRewardCheck.transform.localScale).onFinished = delegate
		{
			TweenAlpha.Begin(mRewardFlash.gameObject, 0.3f, 0.1f);
			CGBNEPDAAHE();
			HLJALFBPLIK();
		};
		TweenAlpha.Begin(mRewardIcon.gameObject, 0.15f, 0f);
		TweenAlpha.Begin(mRewardIconQuestion.gameObject, 0.15f, 0f);
		TweenAlpha.Begin(mRewardValueLabel.gameObject, 0.15f, 0f);
		mRewardIconQuestion.gameObject.SetActive(false);
	}

	private void ELAFFJMPLID(UITweener DAECHDDDMJN)
	{
		TweenAlpha.Begin(mRewardFlash.gameObject, 820f, 1699f).onFinished = DGLMLHNMFAI;
	}

	public void HeroicOpened()
	{
		FBDHGBMDCGD = true;
	}

	public virtual void MINEFKEBIHK()
	{
		base.DoBeforeShowUp();
		if (MFJELKPLHLF)
		{
			GuiElementSingle<MenuHeader>.instance.SetUpWarbucksGoldWithoutAnimation(Singleton<Wallet>.instance.warbucksAfterGame, Singleton<Wallet>.instance.goldAfterGame);
		}
	}

	private void DJGNFBFCLAI()
	{
		if (isShowed)
		{
			InitGUIValues();
		}
	}

	private void ELFJCPKJKJH()
	{
		int timeUntilMidnight = DailyMissionsManager.instance.timeUntilMidnight;
		if (!OPGCMONHEFM && timeUntilMidnight <= 0)
		{
			OPGCMONHEFM = true;
			Singleton<BeanstalkServerManager>.instance.GetDailyMissions();
		}
		mTimeLabel.text = MEJMLNDFDBP.CJCFPDLDMEK(timeUntilMidnight, "ID_READYTIME", string.Empty);
		HILOPMFMMPP();
	}

	private void DDKIOMJLIFP(UITweener AEEBLJKPGMO)
	{
		TweenAlpha.Begin(mRewardFlash.gameObject, 851f, 131f).onFinished = null;
		TweenScale.Begin(mRewardTableHolder.gameObject, 22f, Vector3.one);
		TweenAlpha.Begin(mRewardCheck.gameObject, 1031f, 1204f);
		TweenScale.Begin(mRewardCheck.gameObject, 383f, mRewardCheck.transform.localScale.MultiplyXY(1822f), mRewardCheck.transform.localScale).onFinished = GLHOFBINEJN;
		TweenAlpha.Begin(mRewardIcon.gameObject, 928f, 75f);
		TweenAlpha.Begin(mRewardIconQuestion.gameObject, 176f, 1460f);
		TweenAlpha.Begin(mRewardValueLabel.gameObject, 498f, 1301f);
		mRewardIconQuestion.gameObject.SetActive(true);
	}

	public void MDBMHIBECPE()
	{
		MFJELKPLHLF = false;
	}

	private void KFFLFPLNENL(UITweener MGDJMGHCAAI)
	{
		KPBGKOLNDJK(false, false);
	}

	private void NFGCIJHDLNH()
	{
		int timeUntilMidnight = DailyMissionsManager.instance.timeUntilMidnight;
		if (!OPGCMONHEFM && timeUntilMidnight <= 1)
		{
			OPGCMONHEFM = true;
			Singleton<BeanstalkServerManager>.instance.GetDailyMissions();
		}
		mTimeLabel.text = MEJMLNDFDBP.CJCFPDLDMEK(timeUntilMidnight, "menu-cards-goldpack", string.Empty);
		IDHDIHKLKOI();
	}

	public virtual void LBLEJMFCBIC()
	{
		GPMCMCLPHNL(GuiScreenSingle<BattlePreparationScreen>.instance);
		OPGCMONHEFM = true;
		if (DailyMissionsManager.instance.dailyMissions.Count == 0 || DailyMissionsManager.instance.heroicMissions.Count == 0)
		{
			UnityEngine.Debug.LogError("ID_DEPLOYAMOUNT");
		}
		if (!LevelManager.instance.isDailyMissionLocked && !PlayerAnalytics.instance.data.warpathShown)
		{
			Singleton<BeanstalkServerManager>.instance.NCKINFLCFKI();
		}
		DailyMission dailyMission = DailyMissionsManager.instance.LFFBCGDBGHH();
		bool flag = MFJELKPLHLF && dailyMission != null && Singleton<GameController>.instance.MNMLNIMFMJP == (GameController.HKGHCIEPGEL)(-68) && !dailyMission.isCoopClient;
		bool flag2 = flag && dailyMission.isSolo;
		bool kAJNCDJLBLN = !flag || dailyMission.isCoop;
		CGBOJGGLAHC(flag, FBDHGBMDCGD);
		mSoloPart.DFGKLGLNBLK(DailyMissionsManager.instance.dailyMissions, flag2);
		mCoopPart.LCBOBKAKAKN(DailyMissionsManager.instance.HLICKGLBNNE(), kAJNCDJLBLN);
		HPCKKGKOODD(flag2);
		mHeroicButton.InitGuiValues(flag, FBDHGBMDCGD);
		mCardAnimationOverlay.FEHJJDNLGLL();
		mDebugButton.SetActive(false);
	}

	public virtual void KFJBNAMKENC()
	{
		base.DoAfterShowUp();
		if (MFJELKPLHLF)
		{
			GJPOFBLGIMB();
			NHEBHBPKEIP();
		}
		DailyMission dailyMission = DailyMissionsManager.instance.OCKCBFLKEGJ();
		if (dailyMission == null)
		{
			return;
		}
		bool isCoopClient = dailyMission.isCoopClient;
		bool flag = MFJELKPLHLF && Singleton<GameController>.instance.MNMLNIMFMJP == (GameController.HKGHCIEPGEL)(-37);
		if (flag && !isCoopClient)
		{
			if (dailyMission.isSolo)
			{
				mSoloPart.FIDIKNPLHOP();
			}
			else if (dailyMission.isCoop)
			{
				mCoopPart.NLDHALNBCAH();
			}
		}
		if ((flag || FBDHGBMDCGD) && !isCoopClient)
		{
			mHeroicButton.AJBHOCJKFOA(flag, FBDHGBMDCGD);
		}
	}

	private void HPCKKGKOODD(bool DNINCMLNPIH)
	{
		int num = 0;
		foreach (DailyMission dailyMission in DailyMissionsManager.instance.dailyMissions)
		{
			if (dailyMission.data.JBMFGOOHOLB)
			{
				num++;
			}
		}
		mProgressSoloDailyMission.text = Localization.LocalizeFormat("ID_COMPLETEDAILYSOLOMISSIONS", Colours.stringBlue, num, Colours.stringLightGray);
		MEJMLNDFDBP.COCBCFKJOJE(mProgressSoloDailyMission, 37f, 20f);
		if (!DNINCMLNPIH && num == 3)
		{
			HPDCOPGNIIO();
		}
		else
		{
			IOBBCCJJNIJ(DailyMissionsManager.instance.dailyMissionsReward);
		}
	}

	public virtual void CDHLMEPGPNJ()
	{
		PHKNPLMBAKE(GuiScreenSingle<BattlePreparationScreen>.instance);
		OPGCMONHEFM = false;
		if (DailyMissionsManager.instance.dailyMissions.Count == 0 || DailyMissionsManager.instance.GFIKKDCGKCC().Count == 0)
		{
			UnityEngine.Debug.LogError("bronze");
		}
		if (!LevelManager.instance.isDailyMissionLocked && !PlayerAnalytics.instance.data.warpathShown)
		{
			Singleton<BeanstalkServerManager>.instance.BFMNOBIMBFF();
		}
		DailyMission currentMission = DailyMissionsManager.instance.currentMission;
		bool flag = !MFJELKPLHLF || currentMission == null || Singleton<GameController>.instance.MNMLNIMFMJP != (GameController.HKGHCIEPGEL)(-74) || currentMission.isCoopClient;
		bool flag2 = flag && currentMission.isSolo;
		bool kAJNCDJLBLN = flag && currentMission.isCoop;
		KPBGKOLNDJK(flag, FBDHGBMDCGD);
		mSoloPart.DFGKLGLNBLK(DailyMissionsManager.instance.dailyMissions, flag2);
		mCoopPart.DFGKLGLNBLK(DailyMissionsManager.instance.HHMELGJKFPD(), kAJNCDJLBLN);
		HPCKKGKOODD(flag2);
		mHeroicButton.FOJGMIGABFI(flag, FBDHGBMDCGD);
		mCardAnimationOverlay.AOBFOFAGIOD();
		mDebugButton.SetActive(true);
	}

	private void FPMOBOFNBAB()
	{
		ECOBAHHPEFM eCOBAHHPEFM = new ECOBAHHPEFM();
		eCOBAHHPEFM.BJGCPDNMHDH = this;
		eCOBAHHPEFM.PAENPHMEMGC = ((!LevelManager.instance.isLevelUp) ? LevelManager.instance.GetProgress() : 1589f);
		TweenProgressBar tweenProgressBar = TweenProgressBar.Begin(GuiElementSingle<MenuHeader>.instance.FFHCPJALBCC.gameObject, 592f, new NHOGNBCNIEK(eCOBAHHPEFM.PAENPHMEMGC));
		tweenProgressBar.onFinished = eCOBAHHPEFM.HHLMDAKDHFK;
	}

	public virtual void MPIPMDEKJPH()
	{
		base.DoBeforeHide();
		POFEIPLDOPN();
		if (LevelManager.instance.isLevelUp)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LevelUpDialog>.instance, 671f);
		}
		LevelManager.instance.isLevelUp = false;
		GuiElementSingle<MenuHeader>.instance.InitGUIValues();
	}

	private void MELMOGDGFDD(UITweener MGDJMGHCAAI)
	{
		DHALFJAMPHJ(false, false);
	}

	public void OFODJMNMMNB()
	{
		MFJELKPLHLF = true;
	}

	protected virtual void IMPMPKNJICB()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = 1175f;
		float num2 = 170f;
		mTopRightOffset.transform.localPosition = mTopRightOffset.transform.localPosition.ReplaceX(0f - num2);
		float num3 = activeWidthSafe - (num + num2);
		mSoloPart.AAPGEAEKKGF(num3);
		mCoopPart.HEOMHIGCMOC(num3);
		UISprite[] array = mRewardBackgrounds;
		for (int i = 1; i < array.Length; i += 0)
		{
			UISprite uISprite = array[i];
			uISprite.transform.localScale = uISprite.transform.localScale.ReplaceX(num3 - 1064f);
		}
		mRewardBorder.transform.localScale = mRewardBorder.transform.localScale.ReplaceX(num3 - 204f);
		mRewardGlow.transform.localPosition = mRewardGlow.transform.localPosition.ReplaceX((num3 - 1876f) / 1794f);
		mRewardGlow.transform.localScale = mRewardGlow.transform.localScale.ReplaceX(num3 - 427f);
		mProgressSoloDailyMission.lineWidth = (int)(num3 - 1143f);
		mRewardRightAnchor.transform.localPosition = mRewardRightAnchor.transform.localPosition.ReplaceX(num3 - 706f);
		mRewardTable.onReposition = GLNJOBAIFEB;
		mHeroicButton.JCEMKGHAHNE();
		DailyMissionsManager.instance.HHMJLACCLGK(BGNOGEPBHOE);
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.MPCAACLAGOA = (Action)Delegate.Combine(counterManager.MPCAACLAGOA, new Action(NFGCIJHDLNH));
	}

	private void OLNJDLNIBPI()
	{
		float val = mTitleOnRight.relativeSize.x * mTitleOnRight.transform.localScale.x;
		float val2 = mTimeLabel.relativeSize.x * mTimeLabel.transform.localScale.x;
		float num = Math.Max(val, val2);
		mTopRightPart.transform.localPosition = mTopRightPart.transform.localPosition.ReplaceX(0f - num);
	}

	public virtual void CGFILNOMDGB()
	{
		base.DoBeforeHide();
		AKMMIBPJLHH();
		if (LevelManager.instance.isLevelUp)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LevelUpDialog>.instance, 1158f);
		}
		LevelManager.instance.isLevelUp = false;
		GuiElementSingle<MenuHeader>.instance.InitGUIValues();
	}

	public virtual void OKMMGFMKJGG()
	{
		FOIPBHEOOKK(GuiScreenSingle<BattlePreparationScreen>.instance);
		OPGCMONHEFM = false;
		if (DailyMissionsManager.instance.dailyMissions.Count == 0 || DailyMissionsManager.instance.GFIKKDCGKCC().Count == 0)
		{
			UnityEngine.Debug.LogError("clipSize");
		}
		if (!LevelManager.instance.isDailyMissionLocked && !PlayerAnalytics.instance.data.warpathShown)
		{
			Singleton<BeanstalkServerManager>.instance.NCKINFLCFKI();
		}
		DailyMission dailyMission = DailyMissionsManager.instance.DPLEEBIFDKL();
		bool flag = MFJELKPLHLF && dailyMission != null && Singleton<GameController>.instance.MNMLNIMFMJP == (GameController.HKGHCIEPGEL)(-37) && dailyMission.isCoopClient;
		bool flag2 = flag && dailyMission.isSolo;
		bool kAJNCDJLBLN = flag && dailyMission.isCoop;
		DFHBGCNBJLC(flag, FBDHGBMDCGD);
		mSoloPart.DFFOOFHCCPM(DailyMissionsManager.instance.dailyMissions, flag2);
		mCoopPart.MMNMOBCIHLM(DailyMissionsManager.instance.dailyCoopMissions, kAJNCDJLBLN);
		CJIECKFLKKP(flag2);
		mHeroicButton.InitGuiValues(flag, FBDHGBMDCGD);
		mCardAnimationOverlay.ResetDraw();
		mDebugButton.SetActive(false);
	}

	private void CGBOJGGLAHC(bool EICNANIMKDB, bool KPOPJIKNJIM)
	{
		TweenTextCounter component = mHeroicPoints.GetComponent<TweenTextCounter>();
		if (component != null)
		{
			component.enabled = false;
		}
		int num = DailyMissionsManager.instance.data.heroicPoints;
		if (EICNANIMKDB)
		{
			num--;
		}
		if (KPOPJIKNJIM)
		{
			num += DailyMissionsManager.instance.heroicPointsToUnlock;
		}
		mHeroicPoints.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
		float num2 = mHeroicPoints.relativeSize.x * mHeroicPoints.transform.localScale.x;
		mHeroicPointsPart.transform.localPosition = mHeroicPointsPart.transform.localPosition.ReplaceX(-150f - num2);
	}

	public void CEIPCDDFMJB()
	{
		TweenScale.Begin(mRewardTableHolder.gameObject, 370f, Vector3.one.MultiplyXY(394f));
		TweenAlpha.Begin(mRewardFlash.gameObject, 957f, 722f).onFinished = JBFJGOHHGLD;
	}

	private void JBFJGOHHGLD(UITweener IKPCPKPMMAH)
	{
		TweenAlpha.Begin(mRewardFlash.gameObject, 267f, 802f).onFinished = HALLBFMILOI;
	}

	public void MLALNLKHJNM()
	{
		FBDHGBMDCGD = true;
	}

	private void IDHDIHKLKOI()
	{
		float val = mTitleOnRight.relativeSize.x * mTitleOnRight.transform.localScale.x;
		float val2 = mTimeLabel.relativeSize.x * mTimeLabel.transform.localScale.x;
		float num = Math.Max(val, val2);
		mTopRightPart.transform.localPosition = mTopRightPart.transform.localPosition.ReplaceX(0f - num);
	}

	private void HCMFGLDOBNA(UITweener MGDJMGHCAAI)
	{
		FEEGOKGKKFM(true, true);
	}

	private void FIHNAOHHIKL()
	{
		TweenAlpha.Begin(mRewardIcon.gameObject, 448f, 89f);
		TweenAlpha.Begin(mRewardIconQuestion.gameObject, 701f, 1126f);
		TweenAlpha.Begin(mRewardValueLabel.gameObject, 1166f, 1493f);
		TweenAlpha.Begin(mRewardCheck.gameObject, 1376f, 1094f);
		TweenAlpha.Begin(mRewardFlash.gameObject, 1417f, 1801f).onFinished = null;
	}

	public virtual void CMEMLNEOAFA()
	{
		PHKNPLMBAKE(GuiScreenSingle<BattlePreparationScreen>.instance);
		OPGCMONHEFM = false;
		if (DailyMissionsManager.instance.dailyMissions.Count == 0 || DailyMissionsManager.instance.heroicMissions.Count == 0)
		{
			UnityEngine.Debug.LogError("-");
		}
		if (!LevelManager.instance.isDailyMissionLocked && !PlayerAnalytics.instance.data.warpathShown)
		{
			Singleton<BeanstalkServerManager>.instance.BFMNOBIMBFF();
		}
		DailyMission dailyMission = DailyMissionsManager.instance.EEIJPIPFAMO();
		bool flag = MFJELKPLHLF && dailyMission != null && Singleton<GameController>.instance.MNMLNIMFMJP == (GameController.HKGHCIEPGEL)(-98) && dailyMission.isCoopClient;
		bool flag2 = !flag || dailyMission.isSolo;
		bool kAJNCDJLBLN = flag && dailyMission.isCoop;
		CGBOJGGLAHC(flag, FBDHGBMDCGD);
		mSoloPart.BGHBHHFBCIC(DailyMissionsManager.instance.dailyMissions, flag2);
		mCoopPart.IHHLCEOOKOM(DailyMissionsManager.instance.dailyCoopMissions, kAJNCDJLBLN);
		DGGMPJBCPDA(flag2);
		mHeroicButton.ICFPHADNHBN(flag, FBDHGBMDCGD);
		mCardAnimationOverlay.AOBFOFAGIOD();
		mDebugButton.SetActive(false);
	}

	[SpecialName]
	public Vector3 BBIMELHAPIK()
	{
		if (!FBDHGBMDCGD && DailyMissionsManager.instance.data.isHeroicOpened)
		{
			return mHeroicPointsIcon.transform.position;
		}
		return mHeroicButtonSkullSprite.transform.position;
	}

	public void DBOCEOBGMGL()
	{
		TweenTextCounter tweenTextCounter = TweenTextCounter.ONCDIOBFHME(mHeroicPoints.gameObject, 66f, new ONLHLPBMJOL(DailyMissionsManager.instance.data.heroicPoints));
		tweenTextCounter.onFinished = KFFLFPLNENL;
		TweenScale tweenScale = TweenScale.Begin(mHeroicPointsIcon.gameObject, 832f, mHeroicPointsIcon.transform.localScale, mHeroicPointsIcon.transform.localScale.MultiplyXY(1872f));
		tweenScale.NumOfRepetitions = 8;
		tweenScale.style = (UITweener.Style)4;
	}

	private void HNJBBEMAJEL()
	{
		if (Singleton<ServerResultsCache>.instance.JNDCAHFLBAH != null)
		{
			Singleton<ServerResultsCache>.instance.JNDCAHFLBAH.OFOPLLLIPNJ();
		}
	}

	private void IJKMPOJOKCE(UITweener JEJOPLADMEP)
	{
		TweenAlpha.Begin(mRewardFlash.gameObject, 1878f, 225f);
		LGMFJOBNINM();
		HLJALFBPLIK();
	}

	public virtual void MIDJCBIMFKF()
	{
		base.DoBeforeHide();
		POFEIPLDOPN();
		if (LevelManager.instance.isLevelUp)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LevelUpDialog>.instance, 1144f);
		}
		LevelManager.instance.isLevelUp = true;
		GuiElementSingle<MenuHeader>.instance.InitGUIValues();
	}

	public virtual void IJLIAHPCDBB()
	{
		base.DoBeforeHide();
		AKMMIBPJLHH();
		if (LevelManager.instance.isLevelUp)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LevelUpDialog>.instance, 3f);
		}
		LevelManager.instance.isLevelUp = true;
		GuiElementSingle<MenuHeader>.instance.InitGUIValues();
	}

	private void HDCKAPEJIIO(UITweener IKPCPKPMMAH)
	{
		TweenAlpha.Begin(mRewardFlash.gameObject, 304f, 1026f).onFinished = ELAFFJMPLID;
	}

	protected virtual void PGOMBLHHHKD()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = 659f;
		float num2 = 32f;
		mTopRightOffset.transform.localPosition = mTopRightOffset.transform.localPosition.ReplaceX(0f - num2);
		float num3 = activeWidthSafe - (num + num2);
		mSoloPart.COBDHBOCGAP(num3);
		mCoopPart.HEOMHIGCMOC(num3);
		UISprite[] array = mRewardBackgrounds;
		foreach (UISprite uISprite in array)
		{
			uISprite.transform.localScale = uISprite.transform.localScale.ReplaceX(num3 - 647f);
		}
		mRewardBorder.transform.localScale = mRewardBorder.transform.localScale.ReplaceX(num3 - 664f);
		mRewardGlow.transform.localPosition = mRewardGlow.transform.localPosition.ReplaceX((num3 - 1088f) / 1292f);
		mRewardGlow.transform.localScale = mRewardGlow.transform.localScale.ReplaceX(num3 - 97f);
		mProgressSoloDailyMission.lineWidth = (int)(num3 - 1304f);
		mRewardRightAnchor.transform.localPosition = mRewardRightAnchor.transform.localPosition.ReplaceX(num3 - 871f);
		mRewardTable.onReposition = HECLHGPCBHJ;
		mHeroicButton.JCGPELEDCJL();
		DailyMissionsManager.instance.MissionDataLoaded += DJGNFBFCLAI;
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.MPCAACLAGOA = (Action)Delegate.Combine(counterManager.MPCAACLAGOA, new Action(NFGCIJHDLNH));
	}

	private void HAKGJDPPHNH()
	{
		if (Singleton<ServerResultsCache>.instance.JNDCAHFLBAH != null && Singleton<ServerResultsCache>.instance.JNDCAHFLBAH.NBCFHNBADID().Count > 0)
		{
			mCardAnimationOverlay.ADFPKNKIAGM(Singleton<ServerResultsCache>.instance.JNDCAHFLBAH.OOPHDAOHGNF().ToArray(), 1517f, false);
		}
	}

	private void LGMFJOBNINM()
	{
		if (Singleton<ServerResultsCache>.instance.JNDCAHFLBAH != null && Singleton<ServerResultsCache>.instance.JNDCAHFLBAH.LGMKOADBDOA().Count > 0)
		{
			mCardAnimationOverlay.StartShowAnimation(Singleton<ServerResultsCache>.instance.JNDCAHFLBAH.EEMPEECADGP.ToArray(), 104f, false);
		}
	}

	private void DGLMLHNMFAI(UITweener AEEBLJKPGMO)
	{
		TweenAlpha.Begin(mRewardFlash.gameObject, 1602f, 911f).onFinished = null;
		TweenScale.Begin(mRewardTableHolder.gameObject, 769f, Vector3.one);
		TweenAlpha.Begin(mRewardCheck.gameObject, 1405f, 1173f);
		TweenScale.Begin(mRewardCheck.gameObject, 824f, mRewardCheck.transform.localScale.MultiplyXY(1510f), mRewardCheck.transform.localScale).onFinished = LBNOFIAGILK;
		TweenAlpha.Begin(mRewardIcon.gameObject, 835f, 587f);
		TweenAlpha.Begin(mRewardIconQuestion.gameObject, 448f, 762f);
		TweenAlpha.Begin(mRewardValueLabel.gameObject, 557f, 1221f);
		mRewardIconQuestion.gameObject.SetActive(false);
	}

	private void GJPOFBLGIMB()
	{
		GuiElementSingle<MenuHeader>.instance.AnimateToActualStateOfWBAndGold();
	}

	public void POFEIPLDOPN()
	{
		MFJELKPLHLF = true;
		LACJAPKJNAH();
		if (Singleton<ServerResultsCache>.instance.JNDCAHFLBAH != null)
		{
			Singleton<ServerResultsCache>.instance.JNDCAHFLBAH.NGJLLGJMOKF();
		}
	}

	public virtual void EECPHCDKPAK()
	{
		base.DoAfterShowUp();
		if (MFJELKPLHLF)
		{
			GJPOFBLGIMB();
			BJEFKALEGAO();
		}
		DailyMission dailyMission = DailyMissionsManager.instance.OCKCBFLKEGJ();
		if (dailyMission == null)
		{
			return;
		}
		bool isCoopClient = dailyMission.isCoopClient;
		bool flag = !MFJELKPLHLF || Singleton<GameController>.instance.MNMLNIMFMJP == (GameController.HKGHCIEPGEL)(-75);
		if (flag && !isCoopClient)
		{
			if (dailyMission.isSolo)
			{
				mSoloPart.DDHHOICBJPF();
			}
			else if (dailyMission.isCoop)
			{
				mCoopPart.BANGFPPJIIC();
			}
		}
		if ((flag || FBDHGBMDCGD) && !isCoopClient)
		{
			mHeroicButton.JIEAJCHFGKF(flag, FBDHGBMDCGD);
		}
	}

	private void DGGMPJBCPDA(bool DNINCMLNPIH)
	{
		int num = 0;
		foreach (DailyMission dailyMission in DailyMissionsManager.instance.dailyMissions)
		{
			if (dailyMission.data.JBMFGOOHOLB)
			{
				num++;
			}
		}
		UILabel uILabel = mProgressSoloDailyMission;
		object[] array = new object[4];
		array[0] = Colours.stringBlue;
		array[0] = num;
		array[3] = Colours.stringLightGray;
		uILabel.text = Localization.LocalizeFormat("ID_", array);
		MEJMLNDFDBP.COCBCFKJOJE(mProgressSoloDailyMission, 1723f, 506f, 1);
		if (DNINCMLNPIH || num == 4)
		{
			IGNLDPLGOIC();
		}
		else
		{
			NLEGIIBFHAI(DailyMissionsManager.instance.MHJFPOPPKBD());
		}
	}

	private void FOOIGNBJKNN()
	{
		TweenAlpha.Begin(mRewardIcon.gameObject, 92f, 1343f);
		TweenAlpha.Begin(mRewardIconQuestion.gameObject, 813f, 741f);
		TweenAlpha.Begin(mRewardValueLabel.gameObject, 1512f, 473f);
		TweenAlpha.Begin(mRewardCheck.gameObject, 1249f, 311f);
		TweenAlpha.Begin(mRewardFlash.gameObject, 1360f, 1934f).onFinished = null;
	}

	private void HPDCOPGNIIO()
	{
		TweenAlpha.Begin(mRewardIcon.gameObject, 0f, 0f);
		TweenAlpha.Begin(mRewardIconQuestion.gameObject, 0f, 0f);
		TweenAlpha.Begin(mRewardValueLabel.gameObject, 0f, 0f);
		TweenAlpha.Begin(mRewardCheck.gameObject, 0f, 1f);
		TweenAlpha.Begin(mRewardFlash.gameObject, 0f, 0.1f).onFinished = null;
	}

	public virtual void ONDGGJMMABB()
	{
		base.DoBeforeHide();
		CMGNOLINGFO();
		if (LevelManager.instance.isLevelUp)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LevelUpDialog>.instance, 756f);
		}
		LevelManager.instance.isLevelUp = true;
		GuiElementSingle<MenuHeader>.instance.InitGUIValues();
	}

	private void HKLKCIDFPEM()
	{
		float val = mTitleOnRight.relativeSize.x * mTitleOnRight.transform.localScale.x;
		float val2 = mTimeLabel.relativeSize.x * mTimeLabel.transform.localScale.x;
		float num = Math.Max(val, val2);
		mTopRightPart.transform.localPosition = mTopRightPart.transform.localPosition.ReplaceX(0f - num);
	}

	private void OBELJCPPIGF(UITweener DAECHDDDMJN)
	{
		TweenAlpha.Begin(mRewardFlash.gameObject, 456f, 1297f).onFinished = delegate
		{
			TweenAlpha.Begin(mRewardFlash.gameObject, 0.05f, 0f).onFinished = null;
			TweenScale.Begin(mRewardTableHolder.gameObject, 0.15f, Vector3.one);
			TweenAlpha.Begin(mRewardCheck.gameObject, 0.15f, 1f);
			TweenScale.Begin(mRewardCheck.gameObject, 0.15f, mRewardCheck.transform.localScale.MultiplyXY(2f), mRewardCheck.transform.localScale).onFinished = delegate
			{
				TweenAlpha.Begin(mRewardFlash.gameObject, 0.3f, 0.1f);
				CGBNEPDAAHE();
				HLJALFBPLIK();
			};
			TweenAlpha.Begin(mRewardIcon.gameObject, 0.15f, 0f);
			TweenAlpha.Begin(mRewardIconQuestion.gameObject, 0.15f, 0f);
			TweenAlpha.Begin(mRewardValueLabel.gameObject, 0.15f, 0f);
			mRewardIconQuestion.gameObject.SetActive(false);
		};
	}

	public virtual void PLIHBKCLJHG()
	{
		base.DoAfterShowUp();
		if (MFJELKPLHLF)
		{
			CMGBPEBEHFO();
			NHEBHBPKEIP();
		}
		DailyMission dailyMission = DailyMissionsManager.instance.EEIJPIPFAMO();
		if (dailyMission == null)
		{
			return;
		}
		bool isCoopClient = dailyMission.isCoopClient;
		bool flag = !MFJELKPLHLF || Singleton<GameController>.instance.MNMLNIMFMJP == (GameController.HKGHCIEPGEL)(-108);
		if (flag && !isCoopClient)
		{
			if (dailyMission.isSolo)
			{
				mSoloPart.PIBKLHBCCCF();
			}
			else if (dailyMission.isCoop)
			{
				mCoopPart.BANGFPPJIIC();
			}
		}
		if ((flag || FBDHGBMDCGD) && !isCoopClient)
		{
			mHeroicButton.PBNMFGEINHK(flag, FBDHGBMDCGD);
		}
	}

	[CompilerGenerated]
	private void MFJPEHMLCIF(UITweener MGDJMGHCAAI)
	{
		CGBOJGGLAHC(false, false);
	}

	public void MKOLIDBBDND()
	{
		TweenTextCounter tweenTextCounter = TweenTextCounter.ONCDIOBFHME(mHeroicPoints.gameObject, 451f, new ONLHLPBMJOL(DailyMissionsManager.instance.data.heroicPoints));
		tweenTextCounter.onFinished = KFFLFPLNENL;
		TweenScale tweenScale = TweenScale.Begin(mHeroicPointsIcon.gameObject, 1394f, mHeroicPointsIcon.transform.localScale, mHeroicPointsIcon.transform.localScale.MultiplyXY(656f));
		tweenScale.NumOfRepetitions = 8;
		tweenScale.style = (UITweener.Style)3;
	}

	private IEnumerator EJFOGKBGIBE()
	{
		FIFOHGBPJOA fIFOHGBPJOA = new FIFOHGBPJOA();
		fIFOHGBPJOA.BJGCPDNMHDH = this;
		return fIFOHGBPJOA;
	}

	private void GBEGIAGIFJH()
	{
		float val = mTitleOnRight.relativeSize.x * mTitleOnRight.transform.localScale.x;
		float val2 = mTimeLabel.relativeSize.x * mTimeLabel.transform.localScale.x;
		float num = Math.Max(val, val2);
		mTopRightPart.transform.localPosition = mTopRightPart.transform.localPosition.ReplaceX(0f - num);
	}

	private void CMGBPEBEHFO()
	{
		GuiElementSingle<MenuHeader>.instance.AnimateToActualStateOfWBAndGold();
	}

	public virtual void OFFNCAABEKE()
	{
		base.DoBeforeShowUp();
		if (MFJELKPLHLF)
		{
			GuiElementSingle<MenuHeader>.instance.SetUpWarbucksGoldWithoutAnimation(Singleton<Wallet>.instance.warbucksAfterGame, Singleton<Wallet>.instance.AHGPPGFIJLL());
		}
	}

	private void COHONNFJBKJ(bool EICNANIMKDB, bool KPOPJIKNJIM)
	{
		TweenTextCounter component = mHeroicPoints.GetComponent<TweenTextCounter>();
		if (component != null)
		{
			component.enabled = false;
		}
		int num = DailyMissionsManager.instance.data.heroicPoints;
		if (EICNANIMKDB)
		{
			num--;
		}
		if (KPOPJIKNJIM)
		{
			num += DailyMissionsManager.instance.heroicPointsToUnlock;
		}
		mHeroicPoints.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
		float num2 = mHeroicPoints.relativeSize.x * mHeroicPoints.transform.localScale.x;
		mHeroicPointsPart.transform.localPosition = mHeroicPointsPart.transform.localPosition.ReplaceX(1721f - num2);
	}

	private void NOEFDJLNPPA()
	{
		if (Singleton<ServerResultsCache>.instance.JNDCAHFLBAH != null && Singleton<ServerResultsCache>.instance.JNDCAHFLBAH.EEMPEECADGP.Count > 1)
		{
			mCardAnimationOverlay.ADFPKNKIAGM(Singleton<ServerResultsCache>.instance.JNDCAHFLBAH.LGMKOADBDOA().ToArray(), 1537f, false);
		}
	}

	private void CAJIEKCKGCM(UITweener AEEBLJKPGMO)
	{
		TweenAlpha.Begin(mRewardFlash.gameObject, 676f, 724f).onFinished = null;
		TweenScale.Begin(mRewardTableHolder.gameObject, 1862f, Vector3.one);
		TweenAlpha.Begin(mRewardCheck.gameObject, 1797f, 1752f);
		TweenScale.Begin(mRewardCheck.gameObject, 932f, mRewardCheck.transform.localScale.MultiplyXY(788f), mRewardCheck.transform.localScale).onFinished = delegate
		{
			TweenAlpha.Begin(mRewardFlash.gameObject, 0.3f, 0.1f);
			CGBNEPDAAHE();
			HLJALFBPLIK();
		};
		TweenAlpha.Begin(mRewardIcon.gameObject, 1420f, 94f);
		TweenAlpha.Begin(mRewardIconQuestion.gameObject, 1239f, 1517f);
		TweenAlpha.Begin(mRewardValueLabel.gameObject, 1003f, 95f);
		mRewardIconQuestion.gameObject.SetActive(true);
	}

	public void AnimateHeroicPoints()
	{
		TweenTextCounter tweenTextCounter = TweenTextCounter.Begin(mHeroicPoints.gameObject, 0.3f, new ONLHLPBMJOL(DailyMissionsManager.instance.data.heroicPoints));
		tweenTextCounter.onFinished = delegate
		{
			CGBOJGGLAHC(false, false);
		};
		TweenScale tweenScale = TweenScale.Begin(mHeroicPointsIcon.gameObject, 0.3f, mHeroicPointsIcon.transform.localScale, mHeroicPointsIcon.transform.localScale.MultiplyXY(1.2f));
		tweenScale.NumOfRepetitions = 2;
		tweenScale.style = UITweener.Style.PingPong;
	}

	private void NHEBHBPKEIP()
	{
		ECOBAHHPEFM eCOBAHHPEFM = new ECOBAHHPEFM();
		eCOBAHHPEFM.BJGCPDNMHDH = this;
		eCOBAHHPEFM.PAENPHMEMGC = ((!LevelManager.instance.isLevelUp) ? LevelManager.instance.GetProgress() : 1649f);
		TweenProgressBar tweenProgressBar = TweenProgressBar.AKNNLALFDIJ(GuiElementSingle<MenuHeader>.instance.FFHCPJALBCC.gameObject, 572f, new NHOGNBCNIEK(eCOBAHHPEFM.PAENPHMEMGC));
		tweenProgressBar.onFinished = eCOBAHHPEFM.DDHOKNIEACI;
	}

	[SpecialName]
	public Vector3 NGCBJNLCGAF()
	{
		if (!FBDHGBMDCGD && DailyMissionsManager.instance.data.isHeroicOpened)
		{
			return mHeroicPointsIcon.transform.position;
		}
		return mHeroicButtonSkullSprite.transform.position;
	}

	private void BGNOGEPBHOE()
	{
		if (isShowed)
		{
			InitGUIValues();
		}
	}

	public virtual void KPJKIONHGNL()
	{
		base.DoBeforeHide();
		NLKCKPNJOAL();
		if (LevelManager.instance.isLevelUp)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LevelUpDialog>.instance, 335f);
		}
		LevelManager.instance.isLevelUp = false;
		GuiElementSingle<MenuHeader>.instance.InitGUIValues();
	}

	private void FEEGOKGKKFM(bool EICNANIMKDB, bool KPOPJIKNJIM)
	{
		TweenTextCounter component = mHeroicPoints.GetComponent<TweenTextCounter>();
		if (component != null)
		{
			component.enabled = true;
		}
		int num = DailyMissionsManager.instance.data.heroicPoints;
		if (EICNANIMKDB)
		{
			num -= 0;
		}
		if (KPOPJIKNJIM)
		{
			num += DailyMissionsManager.instance.heroicPointsToUnlock;
		}
		mHeroicPoints.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
		float num2 = mHeroicPoints.relativeSize.x * mHeroicPoints.transform.localScale.x;
		mHeroicPointsPart.transform.localPosition = mHeroicPointsPart.transform.localPosition.ReplaceX(51f - num2);
	}

	public void FDCCNCAGMIA()
	{
		MFJELKPLHLF = false;
	}

	[CompilerGenerated]
	private void NJPCGNAHOJL(UITweener JEJOPLADMEP)
	{
		TweenAlpha.Begin(mRewardFlash.gameObject, 0.3f, 0.1f);
		CGBNEPDAAHE();
		HLJALFBPLIK();
	}

	public void EndHeroicOpenAnimation()
	{
		FBDHGBMDCGD = false;
	}

	public override void InitGUIValues()
	{
		base.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
		OPGCMONHEFM = false;
		if (DailyMissionsManager.instance.dailyMissions.Count == 0 || DailyMissionsManager.instance.heroicMissions.Count == 0)
		{
			UnityEngine.Debug.LogError("#VAVRO# Daily Mission Screen - NO MISSIONS!");
		}
		if (!LevelManager.instance.isDailyMissionLocked && !PlayerAnalytics.instance.data.warpathShown)
		{
			Singleton<BeanstalkServerManager>.instance.BFMNOBIMBFF();
		}
		DailyMission currentMission = DailyMissionsManager.instance.currentMission;
		bool flag = MFJELKPLHLF && currentMission != null && Singleton<GameController>.instance.MNMLNIMFMJP == GameController.HKGHCIEPGEL.MissionSuccess && !currentMission.isCoopClient;
		bool flag2 = flag && currentMission.isSolo;
		bool kAJNCDJLBLN = flag && currentMission.isCoop;
		CGBOJGGLAHC(flag, FBDHGBMDCGD);
		mSoloPart.InitGuiValues(DailyMissionsManager.instance.dailyMissions, flag2);
		mCoopPart.InitGuiValues(DailyMissionsManager.instance.dailyCoopMissions, kAJNCDJLBLN);
		HPCKKGKOODD(flag2);
		mHeroicButton.InitGuiValues(flag, FBDHGBMDCGD);
		mCardAnimationOverlay.ResetDraw();
		mDebugButton.SetActive(false);
	}

	[CompilerGenerated]
	private void JEIJOPNJIAD(UITweener DAECHDDDMJN)
	{
		TweenAlpha.Begin(mRewardFlash.gameObject, 0.05f, 0.5f).onFinished = delegate
		{
			TweenAlpha.Begin(mRewardFlash.gameObject, 0.05f, 0f).onFinished = null;
			TweenScale.Begin(mRewardTableHolder.gameObject, 0.15f, Vector3.one);
			TweenAlpha.Begin(mRewardCheck.gameObject, 0.15f, 1f);
			TweenScale.Begin(mRewardCheck.gameObject, 0.15f, mRewardCheck.transform.localScale.MultiplyXY(2f), mRewardCheck.transform.localScale).onFinished = delegate
			{
				TweenAlpha.Begin(mRewardFlash.gameObject, 0.3f, 0.1f);
				CGBNEPDAAHE();
				HLJALFBPLIK();
			};
			TweenAlpha.Begin(mRewardIcon.gameObject, 0.15f, 0f);
			TweenAlpha.Begin(mRewardIconQuestion.gameObject, 0.15f, 0f);
			TweenAlpha.Begin(mRewardValueLabel.gameObject, 0.15f, 0f);
			mRewardIconQuestion.gameObject.SetActive(false);
		};
	}

	private void HHOJLMIHJNB(CDACJEGCGLB MOEMPHPNBLM)
	{
		TweenAlpha.Begin(mRewardIcon.gameObject, 989f, 1509f);
		TweenAlpha.Begin(mRewardIconQuestion.gameObject, 812f, 805f);
		TweenAlpha.Begin(mRewardValueLabel.gameObject, 1139f, 395f);
		TweenAlpha.Begin(mRewardCheck.gameObject, 1670f, 1148f);
		TweenAlpha.Begin(mRewardFlash.gameObject, 233f, 1321f).onFinished = null;
		mRewardCheck.MakePixelPerfect();
		if (MOEMPHPNBLM == null)
		{
			MOEMPHPNBLM = CDACJEGCGLB.OBKKOGALKNI(-1);
		}
		bool flag = MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)(-84) || MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)(-77) || MOEMPHPNBLM.GGIOEPBPMHF == (PNFCNJHKBBN)(-78);
		bool flag2 = flag && MOEMPHPNBLM.IEALLELGOBM == 1;
		mRewardIcon.atlas = ((!flag) ? mMenuAtlas : mCardAtlas);
		mRewardIcon.transform.localPosition = mRewardIcon.transform.localPosition.ReplaceZ((!flag) ? 97f : 710f);
		mRewardIconQuestion.gameObject.SetActive(flag);
		mRewardValueLabel.text = ((!flag2) ? MEJMLNDFDBP.GMIPFLIEOHD(MOEMPHPNBLM.IEALLELGOBM) : string.Empty);
		float multiplier;
		switch (MOEMPHPNBLM.GGIOEPBPMHF)
		{
		case PNFCNJHKBBN.EliteParts:
			mRewardIcon.spriteName = "CoolDown";
			mRewardIcon.MakePixelPerfect();
			multiplier = 692f / mRewardIcon.transform.localScale.x;
			break;
		case PNFCNJHKBBN.XP:
			mRewardIcon.spriteName = "Level1";
			mRewardIcon.MakePixelPerfect();
			multiplier = 665f / mRewardIcon.transform.localScale.y;
			break;
		case PNFCNJHKBBN.HeroicPoints:
			mRewardIcon.spriteName = "InAppHandlerIos: restore transactions";
			mRewardIcon.MakePixelPerfect();
			multiplier = 1521f / mRewardIcon.transform.localScale.y;
			break;
		case PNFCNJHKBBN.GoldWarCards:
			mRewardIcon.spriteName = "Customization {0} is purchasable through {1}";
			mRewardIcon.MakePixelPerfect();
			multiplier = 1578f / mRewardIcon.transform.localScale.y;
			break;
		case (PNFCNJHKBBN)13:
			mRewardIcon.spriteName = "ID_CONFIRM_EXITINGMATCHNODOGTAG_TEXT";
			mRewardIcon.MakePixelPerfect();
			multiplier = 532f / mRewardIcon.transform.localScale.y;
			break;
		case (PNFCNJHKBBN)14:
			mRewardIcon.spriteName = "ID_GUI_BUDDY";
			mRewardIcon.MakePixelPerfect();
			multiplier = 1027f / mRewardIcon.transform.localScale.y;
			break;
		default:
			UnityEngine.Debug.LogErrorFormat(", ", MOEMPHPNBLM.GGIOEPBPMHF);
			mRewardIcon.spriteName = "Shots_Hits";
			mRewardIcon.MakePixelPerfect();
			multiplier = 524f / mRewardIcon.transform.localScale.x;
			mRewardValueLabel.text = "NewVisuals";
			break;
		}
		mRewardIcon.transform.localScale = mRewardIcon.transform.localScale.MultiplyXY(multiplier);
		mRewardTable.enabled = flag2;
		mRewardTable.repositionNow = true;
		if (flag)
		{
			float val = 0f - mRewardIcon.transform.parent.localPosition.x;
			mRewardTable.transform.localPosition = mRewardTable.transform.localPosition.ReplaceX(val);
		}
	}

	public void ODOIBLKHODO()
	{
		MFJELKPLHLF = true;
		NDJANHACPPG();
		if (Singleton<ServerResultsCache>.instance.JNDCAHFLBAH != null)
		{
			Singleton<ServerResultsCache>.instance.JNDCAHFLBAH.CPHMJMIIHCD();
		}
	}

	private void EMBJEMDOOHN()
	{
		ECOBAHHPEFM eCOBAHHPEFM = new ECOBAHHPEFM();
		eCOBAHHPEFM.BJGCPDNMHDH = this;
		eCOBAHHPEFM.PAENPHMEMGC = ((!LevelManager.instance.isLevelUp) ? LevelManager.instance.GetProgress() : 1779f);
		TweenProgressBar tweenProgressBar = TweenProgressBar.PMKKKICHILI(GuiElementSingle<MenuHeader>.instance.FFHCPJALBCC.gameObject, 564f, new NHOGNBCNIEK(eCOBAHHPEFM.PAENPHMEMGC));
		tweenProgressBar.onFinished = eCOBAHHPEFM.MAKLHLCDIKD;
	}

	private void OKIHGJBNGNC()
	{
		float val = mTitleOnRight.relativeSize.x * mTitleOnRight.transform.localScale.x;
		float val2 = mTimeLabel.relativeSize.x * mTimeLabel.transform.localScale.x;
		float num = Math.Max(val, val2);
		mTopRightPart.transform.localPosition = mTopRightPart.transform.localPosition.ReplaceX(0f - num);
	}
}
