using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TutorialManagerStage6 : TutorialManagerBase
{
	private sealed class IDABCBMMFHP : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal TutorialManagerStage6 BJGCPDNMHDH;

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
		private object AAAOCACGKIP()
		{
			return PHDOCKCBJOF;
		}

		public void IODFILFCENJ()
		{
			throw new NotSupportedException();
		}

		public bool JPBGJLDMOPO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.StartTutorial(false);
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Remove(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Combine(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Remove(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Combine(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Remove(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Combine(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElementSingle<ChatGuiElement>.instance.ChangingState -= BJGCPDNMHDH.OnChangingState;
				GuiElementSingle<ChatGuiElement>.instance.ChangingState += BJGCPDNMHDH.OnChangingState;
				BJGCPDNMHDH.StartAnimations();
				goto case 2u;
			case 2u:
			case 3u:
			case 5u:
				if (StatsManager.instance.battlesPlayed >= 0)
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = false;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1449f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (Singleton<GameController>.instance.DAIEAMEFGIE())
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = false;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(134f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				if (Singleton<GameController>.instance.NOPCKHHDOMN() != GameController.AEMPHGEIJNH.Menu)
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = true;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1229f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				if (!BJGCPDNMHDH.mInMenu)
				{
					BJGCPDNMHDH.StartAnimations(true);
				}
				if (BJGCPDNMHDH.mChangingScreen)
				{
					BJGCPDNMHDH.mChangingScreen = false;
					BJGCPDNMHDH.StopAnimations();
					PHDOCKCBJOF = new WaitForSeconds(Singleton<GuiManager>.instance.AODFEHKBJIN.DCIKANJJFIJ);
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
						CLPPIAGLCJJ = 5;
					}
				}
				break;
			case 4u:
				BJGCPDNMHDH.StartAnimations();
				goto case 2u;
			case 1u:
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Remove(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Remove(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Remove(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElementSingle<ChatGuiElement>.instance.IKMJBGIEEFE(BJGCPDNMHDH.OnChangingState);
				PHDOCKCBJOF = new WaitForSeconds(1768f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 6u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void KGLKGNBCPLM()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void CHFJIODFNIP()
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
		private object NAPMJAMDKMJ()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void JKOCLGOOBEK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool IIJKAMFGNKA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.StartTutorial(false);
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Remove(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Combine(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Remove(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Combine(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Remove(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Combine(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElementSingle<ChatGuiElement>.instance.EPGGEMCMEKL(BJGCPDNMHDH.OnChangingState);
				GuiElementSingle<ChatGuiElement>.instance.ChangingState += BJGCPDNMHDH.OnChangingState;
				BJGCPDNMHDH.StartAnimations();
				goto case 2u;
			case 2u:
			case 3u:
			case 5u:
				if (StatsManager.instance.battlesPlayed >= 1)
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = true;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(540f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (Singleton<GameController>.instance.DAIEAMEFGIE())
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = true;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(754f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				if (Singleton<GameController>.instance.NOPCKHHDOMN() != GameController.AEMPHGEIJNH.Menu)
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = false;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1157f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				if (!BJGCPDNMHDH.mInMenu)
				{
					BJGCPDNMHDH.StartAnimations(true);
				}
				if (BJGCPDNMHDH.mChangingScreen)
				{
					BJGCPDNMHDH.mChangingScreen = false;
					BJGCPDNMHDH.StopAnimations();
					PHDOCKCBJOF = new WaitForSeconds(Singleton<GuiManager>.instance.AODFEHKBJIN.DCIKANJJFIJ);
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
						CLPPIAGLCJJ = 4;
					}
				}
				break;
			case 4u:
				BJGCPDNMHDH.StartAnimations(true);
				goto case 2u;
			case 1u:
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Remove(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Remove(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Remove(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElementSingle<ChatGuiElement>.instance.IKMJBGIEEFE(BJGCPDNMHDH.OnChangingState);
				PHDOCKCBJOF = new WaitForSeconds(328f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 6u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
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
				BJGCPDNMHDH.StartTutorial(true);
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Remove(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Combine(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Remove(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Combine(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Remove(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Combine(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElementSingle<ChatGuiElement>.instance.FGCECNNCKGI(BJGCPDNMHDH.OnChangingState);
				GuiElementSingle<ChatGuiElement>.instance.ChangingState += BJGCPDNMHDH.OnChangingState;
				BJGCPDNMHDH.StartAnimations();
				goto case 2u;
			case 2u:
			case 3u:
			case 5u:
				if (StatsManager.instance.battlesPlayed >= 0)
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = false;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1367f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (Singleton<GameController>.instance.DAIEAMEFGIE())
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = true;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1112f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				if (Singleton<GameController>.instance.NOPCKHHDOMN() != GameController.AEMPHGEIJNH.Menu)
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = true;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1860f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				if (!BJGCPDNMHDH.mInMenu)
				{
					BJGCPDNMHDH.StartAnimations(true);
				}
				if (BJGCPDNMHDH.mChangingScreen)
				{
					BJGCPDNMHDH.mChangingScreen = true;
					BJGCPDNMHDH.StopAnimations();
					PHDOCKCBJOF = new WaitForSeconds(Singleton<GuiManager>.instance.AODFEHKBJIN.DCIKANJJFIJ);
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
						CLPPIAGLCJJ = 4;
					}
				}
				break;
			case 4u:
				BJGCPDNMHDH.StartAnimations();
				goto case 2u;
			case 1u:
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Remove(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Remove(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Remove(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElementSingle<ChatGuiElement>.instance.FGCECNNCKGI(BJGCPDNMHDH.OnChangingState);
				PHDOCKCBJOF = new WaitForSeconds(921f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 6u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object BMGHJKFMKJE()
		{
			return PHDOCKCBJOF;
		}

		public void CHANLKFNCLA()
		{
			throw new NotSupportedException();
		}

		public bool NEMOAIBCODB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.StartTutorial(false);
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Remove(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Combine(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Remove(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Combine(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Remove(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Combine(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElementSingle<ChatGuiElement>.instance.EPGGEMCMEKL(BJGCPDNMHDH.OnChangingState);
				GuiElementSingle<ChatGuiElement>.instance.ChangingState += BJGCPDNMHDH.OnChangingState;
				BJGCPDNMHDH.StartAnimations(true);
				goto case 2u;
			case 2u:
			case 3u:
			case 5u:
				if (StatsManager.instance.battlesPlayed >= 1)
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = false;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(330f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (Singleton<GameController>.instance.DAIEAMEFGIE())
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = false;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1474f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				if (Singleton<GameController>.instance.PEGCHNGBOAM() != GameController.AEMPHGEIJNH.Menu)
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = false;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(266f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				if (!BJGCPDNMHDH.mInMenu)
				{
					BJGCPDNMHDH.StartAnimations(true);
				}
				if (BJGCPDNMHDH.mChangingScreen)
				{
					BJGCPDNMHDH.mChangingScreen = false;
					BJGCPDNMHDH.StopAnimations();
					PHDOCKCBJOF = new WaitForSeconds(Singleton<GuiManager>.instance.AODFEHKBJIN.DCIKANJJFIJ);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
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
				BJGCPDNMHDH.StartAnimations(true);
				goto case 2u;
			case 1u:
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Remove(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Remove(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Remove(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElementSingle<ChatGuiElement>.instance.FGCECNNCKGI(BJGCPDNMHDH.OnChangingState);
				PHDOCKCBJOF = new WaitForSeconds(856f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 6u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void BCIPEBNJONK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MOMPOEEALPJ()
		{
			return PHDOCKCBJOF;
		}

		public void EFDJMHAPDLB()
		{
			throw new NotSupportedException();
		}

		public void ENFGGBNAPGG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BGBGCFGNJLA()
		{
			return PHDOCKCBJOF;
		}

		public void IBDAHMOEBCM()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GKDLMFPKKNM()
		{
			return PHDOCKCBJOF;
		}

		public void ODJLLLFJIOB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool BIGKCFMEBJE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.StartTutorial(true);
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Remove(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Combine(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Remove(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Combine(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Remove(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Combine(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElementSingle<ChatGuiElement>.instance.EPGGEMCMEKL(BJGCPDNMHDH.OnChangingState);
				GuiElementSingle<ChatGuiElement>.instance.ChangingState += BJGCPDNMHDH.OnChangingState;
				BJGCPDNMHDH.StartAnimations(true);
				goto case 2u;
			case 2u:
			case 3u:
			case 5u:
				if (StatsManager.instance.battlesPlayed >= 1)
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = false;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(613f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (Singleton<GameController>.instance.DAIEAMEFGIE())
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = false;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(640f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (Singleton<GameController>.instance.gameState != GameController.AEMPHGEIJNH.Menu)
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = false;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(206f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				if (!BJGCPDNMHDH.mInMenu)
				{
					BJGCPDNMHDH.StartAnimations();
				}
				if (BJGCPDNMHDH.mChangingScreen)
				{
					BJGCPDNMHDH.mChangingScreen = false;
					BJGCPDNMHDH.StopAnimations();
					PHDOCKCBJOF = new WaitForSeconds(Singleton<GuiManager>.instance.AODFEHKBJIN.DCIKANJJFIJ);
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
				break;
			case 4u:
				BJGCPDNMHDH.StartAnimations();
				goto case 2u;
			case 1u:
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Remove(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Remove(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Remove(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElementSingle<ChatGuiElement>.instance.IKMJBGIEEFE(BJGCPDNMHDH.OnChangingState);
				PHDOCKCBJOF = new WaitForSeconds(1704f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 6u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public bool BJBEBPMDICE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.StartTutorial(false);
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Remove(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Combine(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Remove(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Combine(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Remove(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Combine(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElementSingle<ChatGuiElement>.instance.EPGGEMCMEKL(BJGCPDNMHDH.OnChangingState);
				GuiElementSingle<ChatGuiElement>.instance.ChangingState += BJGCPDNMHDH.OnChangingState;
				BJGCPDNMHDH.StartAnimations();
				goto case 2u;
			case 2u:
			case 3u:
			case 5u:
				if (StatsManager.instance.battlesPlayed >= 1)
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = false;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(895f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (Singleton<GameController>.instance.isTutorial)
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = true;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(752f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				if (Singleton<GameController>.instance.PEGCHNGBOAM() != GameController.AEMPHGEIJNH.Menu)
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = false;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1964f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				if (!BJGCPDNMHDH.mInMenu)
				{
					BJGCPDNMHDH.StartAnimations(true);
				}
				if (BJGCPDNMHDH.mChangingScreen)
				{
					BJGCPDNMHDH.mChangingScreen = true;
					BJGCPDNMHDH.StopAnimations();
					PHDOCKCBJOF = new WaitForSeconds(Singleton<GuiManager>.instance.AODFEHKBJIN.DCIKANJJFIJ);
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
				break;
			case 4u:
				BJGCPDNMHDH.StartAnimations();
				goto case 2u;
			case 1u:
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Remove(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Remove(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Remove(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElementSingle<ChatGuiElement>.instance.FGCECNNCKGI(BJGCPDNMHDH.OnChangingState);
				PHDOCKCBJOF = new WaitForSeconds(1336f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 6u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void MKIKEOOOLKL()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void DLIBOPAMHAN()
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

		public void GFGEEFGMNDP()
		{
			throw new NotSupportedException();
		}

		public void ODFCBNONFPL()
		{
			throw new NotSupportedException();
		}

		public void GCEMCPODLNM()
		{
			throw new NotSupportedException();
		}

		public void IKNKDDMLDIN()
		{
			throw new NotSupportedException();
		}

		public void CNOEDCFDILG()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GMPGIODBIPO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ADIAKJMNIEB()
		{
			return PHDOCKCBJOF;
		}

		public void ODACICLOMHJ()
		{
			throw new NotSupportedException();
		}

		public void KKDOJDCJAJB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HJFIBBBPDKK()
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
				BJGCPDNMHDH.StartTutorial(true);
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Remove(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Combine(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Remove(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Combine(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Remove(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Combine(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElementSingle<ChatGuiElement>.instance.EPGGEMCMEKL(BJGCPDNMHDH.OnChangingState);
				GuiElementSingle<ChatGuiElement>.instance.ChangingState += BJGCPDNMHDH.OnChangingState;
				BJGCPDNMHDH.StartAnimations();
				goto case 2u;
			case 2u:
			case 3u:
			case 5u:
				if (StatsManager.instance.battlesPlayed >= 0)
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = true;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1262f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (Singleton<GameController>.instance.DAIEAMEFGIE())
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = false;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(956f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				if (Singleton<GameController>.instance.NOPCKHHDOMN() != GameController.AEMPHGEIJNH.Menu)
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = false;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1595f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				if (!BJGCPDNMHDH.mInMenu)
				{
					BJGCPDNMHDH.StartAnimations(true);
				}
				if (BJGCPDNMHDH.mChangingScreen)
				{
					BJGCPDNMHDH.mChangingScreen = true;
					BJGCPDNMHDH.StopAnimations();
					PHDOCKCBJOF = new WaitForSeconds(Singleton<GuiManager>.instance.AODFEHKBJIN.DCIKANJJFIJ);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
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
				BJGCPDNMHDH.StartAnimations(true);
				goto case 2u;
			case 1u:
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Remove(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Remove(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Remove(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElementSingle<ChatGuiElement>.instance.ChangingState -= BJGCPDNMHDH.OnChangingState;
				PHDOCKCBJOF = new WaitForSeconds(1073f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 6u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void PMAJELGBBKE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MBDBIPHLEIA()
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
				BJGCPDNMHDH.StartTutorial(true);
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Remove(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Combine(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Remove(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Combine(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Remove(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Combine(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElementSingle<ChatGuiElement>.instance.IKMJBGIEEFE(BJGCPDNMHDH.OnChangingState);
				GuiElementSingle<ChatGuiElement>.instance.ChangingState += BJGCPDNMHDH.OnChangingState;
				BJGCPDNMHDH.StartAnimations();
				goto case 2u;
			case 2u:
			case 3u:
			case 5u:
				if (StatsManager.instance.battlesPlayed >= 1)
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = false;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(587f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (Singleton<GameController>.instance.BAKCODKBCPJ())
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = false;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1659f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				if (Singleton<GameController>.instance.gameState != GameController.AEMPHGEIJNH.Menu)
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = true;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(645f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				if (!BJGCPDNMHDH.mInMenu)
				{
					BJGCPDNMHDH.StartAnimations(true);
				}
				if (BJGCPDNMHDH.mChangingScreen)
				{
					BJGCPDNMHDH.mChangingScreen = true;
					BJGCPDNMHDH.StopAnimations();
					PHDOCKCBJOF = new WaitForSeconds(Singleton<GuiManager>.instance.AODFEHKBJIN.DCIKANJJFIJ);
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
				BJGCPDNMHDH.StartAnimations();
				goto case 2u;
			case 1u:
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Remove(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Remove(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Remove(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElementSingle<ChatGuiElement>.instance.FGCECNNCKGI(BJGCPDNMHDH.OnChangingState);
				PHDOCKCBJOF = new WaitForSeconds(1548f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 6u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void OMDFNFHKFBK()
		{
			throw new NotSupportedException();
		}

		public void DBEMHFEBPFM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object PEGJNAKGHCC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IGMIIAODMNF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BBHOODPMEFM()
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
				BJGCPDNMHDH.StartTutorial(true);
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Remove(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Combine(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Remove(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Combine(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Remove(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Combine(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElementSingle<ChatGuiElement>.instance.ChangingState -= BJGCPDNMHDH.OnChangingState;
				GuiElementSingle<ChatGuiElement>.instance.ChangingState += BJGCPDNMHDH.OnChangingState;
				BJGCPDNMHDH.StartAnimations(true);
				goto case 2u;
			case 2u:
			case 3u:
			case 5u:
				if (StatsManager.instance.battlesPlayed >= 1)
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = false;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(774f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (Singleton<GameController>.instance.isTutorial)
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = false;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1761f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				if (Singleton<GameController>.instance.NOPCKHHDOMN() != GameController.AEMPHGEIJNH.Menu)
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = false;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(259f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				if (!BJGCPDNMHDH.mInMenu)
				{
					BJGCPDNMHDH.StartAnimations();
				}
				if (BJGCPDNMHDH.mChangingScreen)
				{
					BJGCPDNMHDH.mChangingScreen = false;
					BJGCPDNMHDH.StopAnimations();
					PHDOCKCBJOF = new WaitForSeconds(Singleton<GuiManager>.instance.AODFEHKBJIN.DCIKANJJFIJ);
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
						CLPPIAGLCJJ = 8;
					}
				}
				break;
			case 4u:
				BJGCPDNMHDH.StartAnimations(true);
				goto case 2u;
			case 1u:
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Remove(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Remove(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Remove(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElementSingle<ChatGuiElement>.instance.EPGGEMCMEKL(BJGCPDNMHDH.OnChangingState);
				PHDOCKCBJOF = new WaitForSeconds(1237f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 6u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object MIKGAKNJGKL()
		{
			return PHDOCKCBJOF;
		}

		public void HNLLOFFANCE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KMCGJFDPBCB()
		{
			return PHDOCKCBJOF;
		}

		public bool HMLAEHJKPJE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.StartTutorial(false);
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Remove(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Combine(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Remove(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Combine(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Remove(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Combine(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElementSingle<ChatGuiElement>.instance.ChangingState -= BJGCPDNMHDH.OnChangingState;
				GuiElementSingle<ChatGuiElement>.instance.ChangingState += BJGCPDNMHDH.OnChangingState;
				BJGCPDNMHDH.StartAnimations();
				goto case 2u;
			case 2u:
			case 3u:
			case 5u:
				if (StatsManager.instance.battlesPlayed >= 0)
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = true;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1209f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (Singleton<GameController>.instance.BAKCODKBCPJ())
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = true;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1850f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				if (Singleton<GameController>.instance.gameState != GameController.AEMPHGEIJNH.Menu)
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = true;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1411f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				if (!BJGCPDNMHDH.mInMenu)
				{
					BJGCPDNMHDH.StartAnimations(true);
				}
				if (BJGCPDNMHDH.mChangingScreen)
				{
					BJGCPDNMHDH.mChangingScreen = true;
					BJGCPDNMHDH.StopAnimations();
					PHDOCKCBJOF = new WaitForSeconds(Singleton<GuiManager>.instance.AODFEHKBJIN.DCIKANJJFIJ);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
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
				BJGCPDNMHDH.StartAnimations();
				goto case 2u;
			case 1u:
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Remove(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Remove(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Remove(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElementSingle<ChatGuiElement>.instance.IKMJBGIEEFE(BJGCPDNMHDH.OnChangingState);
				PHDOCKCBJOF = new WaitForSeconds(658f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 6u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
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
		private object PFMFFMEJBPM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KLEHMEIAJHO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LFEJDKIGHMI()
		{
			return PHDOCKCBJOF;
		}

		public void CDIJEGGMMAK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool LGNMOMFLLPP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.StartTutorial(false);
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Remove(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Combine(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Remove(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Combine(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Remove(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Combine(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElementSingle<ChatGuiElement>.instance.EPGGEMCMEKL(BJGCPDNMHDH.OnChangingState);
				GuiElementSingle<ChatGuiElement>.instance.ChangingState += BJGCPDNMHDH.OnChangingState;
				BJGCPDNMHDH.StartAnimations();
				goto case 2u;
			case 2u:
			case 3u:
			case 5u:
				if (StatsManager.instance.battlesPlayed >= 0)
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = false;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1096f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (Singleton<GameController>.instance.BAKCODKBCPJ())
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = false;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1587f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				if (Singleton<GameController>.instance.AFDJHMHONOH() != GameController.AEMPHGEIJNH.Menu)
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = false;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1864f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				if (!BJGCPDNMHDH.mInMenu)
				{
					BJGCPDNMHDH.StartAnimations();
				}
				if (BJGCPDNMHDH.mChangingScreen)
				{
					BJGCPDNMHDH.mChangingScreen = false;
					BJGCPDNMHDH.StopAnimations();
					PHDOCKCBJOF = new WaitForSeconds(Singleton<GuiManager>.instance.AODFEHKBJIN.DCIKANJJFIJ);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
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
				BJGCPDNMHDH.StartAnimations();
				goto case 2u;
			case 1u:
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Remove(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Remove(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Remove(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElementSingle<ChatGuiElement>.instance.FGCECNNCKGI(BJGCPDNMHDH.OnChangingState);
				PHDOCKCBJOF = new WaitForSeconds(1954f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 6u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public bool BKJCILLNJLG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.StartTutorial(true);
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Remove(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Combine(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Remove(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Combine(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Remove(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Combine(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElementSingle<ChatGuiElement>.instance.IKMJBGIEEFE(BJGCPDNMHDH.OnChangingState);
				GuiElementSingle<ChatGuiElement>.instance.ChangingState += BJGCPDNMHDH.OnChangingState;
				BJGCPDNMHDH.StartAnimations();
				goto case 2u;
			case 2u:
			case 3u:
			case 5u:
				if (StatsManager.instance.battlesPlayed >= 0)
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = true;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1611f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (Singleton<GameController>.instance.BAKCODKBCPJ())
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = true;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(369f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				if (Singleton<GameController>.instance.NOPCKHHDOMN() != GameController.AEMPHGEIJNH.Menu)
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = true;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(186f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				if (!BJGCPDNMHDH.mInMenu)
				{
					BJGCPDNMHDH.StartAnimations();
				}
				if (BJGCPDNMHDH.mChangingScreen)
				{
					BJGCPDNMHDH.mChangingScreen = false;
					BJGCPDNMHDH.StopAnimations();
					PHDOCKCBJOF = new WaitForSeconds(Singleton<GuiManager>.instance.AODFEHKBJIN.DCIKANJJFIJ);
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
				break;
			case 4u:
				BJGCPDNMHDH.StartAnimations();
				goto case 2u;
			case 1u:
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Remove(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Remove(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Remove(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElementSingle<ChatGuiElement>.instance.FGCECNNCKGI(BJGCPDNMHDH.OnChangingState);
				PHDOCKCBJOF = new WaitForSeconds(946f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 6u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object HLBMCNKGBDM()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public IDABCBMMFHP()
		{
		}

		[SpecialName]
		private object FONIPEGACDN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GDBNOMPNBGP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KIHECHEHNJJ()
		{
			return PHDOCKCBJOF;
		}

		public void HNFEJKPKEHK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object DFHCLJNONGC()
		{
			return PHDOCKCBJOF;
		}

		public void NGAGGCFIEGJ()
		{
			throw new NotSupportedException();
		}

		public void GBGMIJNBLNH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GPKBICHIBHF()
		{
			return PHDOCKCBJOF;
		}

		public bool LPMIKEPIMCM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.StartTutorial(false);
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Remove(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Combine(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Remove(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Combine(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Remove(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Combine(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElementSingle<ChatGuiElement>.instance.ChangingState -= BJGCPDNMHDH.OnChangingState;
				GuiElementSingle<ChatGuiElement>.instance.ChangingState += BJGCPDNMHDH.OnChangingState;
				BJGCPDNMHDH.StartAnimations(true);
				goto case 2u;
			case 2u:
			case 3u:
			case 5u:
				if (StatsManager.instance.battlesPlayed >= 1)
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = false;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(538f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (Singleton<GameController>.instance.BAKCODKBCPJ())
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = true;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1568f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				if (Singleton<GameController>.instance.gameState != GameController.AEMPHGEIJNH.Menu)
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = false;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1994f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				if (!BJGCPDNMHDH.mInMenu)
				{
					BJGCPDNMHDH.StartAnimations();
				}
				if (BJGCPDNMHDH.mChangingScreen)
				{
					BJGCPDNMHDH.mChangingScreen = true;
					BJGCPDNMHDH.StopAnimations();
					PHDOCKCBJOF = new WaitForSeconds(Singleton<GuiManager>.instance.AODFEHKBJIN.DCIKANJJFIJ);
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
				break;
			case 4u:
				BJGCPDNMHDH.StartAnimations(true);
				goto case 2u;
			case 1u:
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Remove(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Remove(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Remove(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElementSingle<ChatGuiElement>.instance.ChangingState -= BJGCPDNMHDH.OnChangingState;
				PHDOCKCBJOF = new WaitForSeconds(1963f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 6u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object EOPJNKFKMNB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object INAMGPNDAAJ()
		{
			return PHDOCKCBJOF;
		}

		public void HONCAABOMOC()
		{
			throw new NotSupportedException();
		}

		public bool IBEPOFJDKLG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.StartTutorial(false);
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Remove(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Combine(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Remove(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Combine(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Remove(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Combine(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElementSingle<ChatGuiElement>.instance.ChangingState -= BJGCPDNMHDH.OnChangingState;
				GuiElementSingle<ChatGuiElement>.instance.ChangingState += BJGCPDNMHDH.OnChangingState;
				BJGCPDNMHDH.StartAnimations(true);
				goto case 2u;
			case 2u:
			case 3u:
			case 5u:
				if (StatsManager.instance.battlesPlayed >= 1)
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = false;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(504f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (Singleton<GameController>.instance.BAKCODKBCPJ())
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = false;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1742f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				if (Singleton<GameController>.instance.NOPCKHHDOMN() != GameController.AEMPHGEIJNH.Menu)
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = false;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1830f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				if (!BJGCPDNMHDH.mInMenu)
				{
					BJGCPDNMHDH.StartAnimations(true);
				}
				if (BJGCPDNMHDH.mChangingScreen)
				{
					BJGCPDNMHDH.mChangingScreen = false;
					BJGCPDNMHDH.StopAnimations();
					PHDOCKCBJOF = new WaitForSeconds(Singleton<GuiManager>.instance.AODFEHKBJIN.DCIKANJJFIJ);
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
				BJGCPDNMHDH.StartAnimations(true);
				goto case 2u;
			case 1u:
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Remove(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Remove(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Remove(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElementSingle<ChatGuiElement>.instance.FGCECNNCKGI(BJGCPDNMHDH.OnChangingState);
				PHDOCKCBJOF = new WaitForSeconds(1542f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 6u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public bool DMPHMFDEINI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.StartTutorial(false);
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Remove(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Combine(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Remove(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Combine(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Remove(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Combine(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElementSingle<ChatGuiElement>.instance.EPGGEMCMEKL(BJGCPDNMHDH.OnChangingState);
				GuiElementSingle<ChatGuiElement>.instance.ChangingState += BJGCPDNMHDH.OnChangingState;
				BJGCPDNMHDH.StartAnimations();
				goto case 2u;
			case 2u:
			case 3u:
			case 5u:
				if (StatsManager.instance.battlesPlayed >= 1)
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = true;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(899f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (Singleton<GameController>.instance.isTutorial)
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = true;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1137f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				if (Singleton<GameController>.instance.PEGCHNGBOAM() != GameController.AEMPHGEIJNH.Menu)
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = false;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(180f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				if (!BJGCPDNMHDH.mInMenu)
				{
					BJGCPDNMHDH.StartAnimations();
				}
				if (BJGCPDNMHDH.mChangingScreen)
				{
					BJGCPDNMHDH.mChangingScreen = false;
					BJGCPDNMHDH.StopAnimations();
					PHDOCKCBJOF = new WaitForSeconds(Singleton<GuiManager>.instance.AODFEHKBJIN.DCIKANJJFIJ);
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
						CLPPIAGLCJJ = 7;
					}
				}
				break;
			case 4u:
				BJGCPDNMHDH.StartAnimations(true);
				goto case 2u;
			case 1u:
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Remove(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Remove(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Remove(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElementSingle<ChatGuiElement>.instance.ChangingState -= BJGCPDNMHDH.OnChangingState;
				PHDOCKCBJOF = new WaitForSeconds(391f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 6u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void IMFLNKIMEFA()
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
				BJGCPDNMHDH.StartTutorial(false);
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Remove(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Combine(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Remove(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Combine(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Remove(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Combine(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElementSingle<ChatGuiElement>.instance.ChangingState -= BJGCPDNMHDH.OnChangingState;
				GuiElementSingle<ChatGuiElement>.instance.ChangingState += BJGCPDNMHDH.OnChangingState;
				BJGCPDNMHDH.StartAnimations();
				goto case 2u;
			case 2u:
			case 3u:
			case 5u:
				if (StatsManager.instance.battlesPlayed >= 1)
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = false;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(0.5f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (Singleton<GameController>.instance.isTutorial)
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = false;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(1f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				if (Singleton<GameController>.instance.gameState != GameController.AEMPHGEIJNH.Menu)
				{
					if (BJGCPDNMHDH.mInMenu)
					{
						BJGCPDNMHDH.mInMenu = false;
						BJGCPDNMHDH.StopAnimations();
					}
					PHDOCKCBJOF = new WaitForRealSeconds(0.5f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				if (!BJGCPDNMHDH.mInMenu)
				{
					BJGCPDNMHDH.StartAnimations();
				}
				if (BJGCPDNMHDH.mChangingScreen)
				{
					BJGCPDNMHDH.mChangingScreen = false;
					BJGCPDNMHDH.StopAnimations();
					PHDOCKCBJOF = new WaitForSeconds(Singleton<GuiManager>.instance.AODFEHKBJIN.DCIKANJJFIJ);
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
				BJGCPDNMHDH.StartAnimations();
				goto case 2u;
			case 1u:
				GuiScreen.LHMKJNFDMCM = (Action)Delegate.Remove(GuiScreen.LHMKJNFDMCM, new Action(BJGCPDNMHDH.OnChangingScreen));
				GuiElement.NPPHONBAEFN = (Action)Delegate.Remove(GuiElement.NPPHONBAEFN, new Action(BJGCPDNMHDH.OnShowingDialog));
				GuiElement.GLNGDNMNGIO = (Action<GuiElement>)Delegate.Remove(GuiElement.GLNGDNMNGIO, new Action<GuiElement>(BJGCPDNMHDH.OnHidingDialog));
				GuiElementSingle<ChatGuiElement>.instance.ChangingState -= BJGCPDNMHDH.OnChangingState;
				PHDOCKCBJOF = new WaitForSeconds(2.8f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 6u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}
	}

	private static TutorialManagerStage6 mInstance;

	private bool mChangingScreen;

	private bool mInMenu;

	private const int mTillMatches = 1;

	public static TutorialManagerStage6 instance
	{
		get
		{
			mInstance = mInstance ?? UnityEngine.Object.FindObjectOfType<TutorialManagerStage6>();
			return mInstance;
		}
	}

	private bool isAnyElementShown
	{
		get
		{
			return GuiElementSingle<LoadingDialog>.instance.isShowed || DialogManager.instance.isSomeDialogShowed || GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		mInstance = this;
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += delegate
		{
			UnityEngine.Debug.Log("Tutorial Manager 6: Battles played: " + StatsManager.instance.battlesPlayed + " tutorial running: " + Singleton<GameController>.instance.isTutorialInProgressOrPlaned);
			if (!Singleton<GameController>.instance.isTutorialInProgressOrPlaned && StatsManager.instance.battlesPlayed < 1)
			{
				RunTutorial();
			}
		};
	}

	public void RunTutorial()
	{
		if (!base.isTutorialRunning)
		{
			StopAllCoroutines();
			StartCoroutine(RadicalRoutine.Run(GuidePlayerToMatch()));
			UnityEngine.Debug.Log("Tutorial Manager 6: Starting Tutorial - Guide player to match");
		}
	}

	public override void StartTutorial(bool isContinue)
	{
		base.StartTutorial(isContinue);
		StartCoroutine(Singleton<AtlasPreparer>.instance.LoadTutorialCoroutine());
	}

	private void CleanUpAfterTutorial()
	{
		data.started = true;
		Save();
		Singleton<AtlasPreparer>.instance.UnloadTutorial();
	}

	[DebuggerHidden]
	public IEnumerator GuidePlayerToMatch()
	{
		IDABCBMMFHP iDABCBMMFHP = new IDABCBMMFHP();
		iDABCBMMFHP.BJGCPDNMHDH = this;
		return iDABCBMMFHP;
	}

	private void OnChangingScreen()
	{
		mChangingScreen = true;
	}

	private void OnShowingDialog()
	{
		if (mInMenu)
		{
			StopAnimations();
		}
	}

	private void OnHidingDialog(GuiElement dialog)
	{
		if (mInMenu)
		{
			StartAnimations(true);
		}
	}

	private void OnChangingState()
	{
		if (mInMenu && Singleton<GuiManager>.instance.AODFEHKBJIN != null && Singleton<GuiManager>.instance.AODFEHKBJIN.isFullyShowed)
		{
			if (GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed)
			{
				StopAnimations();
			}
			else
			{
				StartAnimations();
			}
		}
	}

	private void StopAnimations()
	{
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StopGoToBattle();
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
	}

	private void StartAnimations(bool specialCondition = false)
	{
		mChangingScreen = false;
		mInMenu = Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.Menu;
		if (specialCondition)
		{
			if (GuiElementSingle<LoadingDialog>.instance.isShowed || GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed || DialogManager.instance.numberOfShownDialogues > 1)
			{
				return;
			}
		}
		else if (isAnyElementShown)
		{
			return;
		}
		if (Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<MainScreen>.instance)
		{
			GuiElementSingle<TutorialOverlayGuiElement>.instance.StartGoToBattle(GuiScreenSingle<MainScreen>.instance.IJPJDKALPDP.transform.position);
			GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<MainScreen>.instance.OMDKNOFNFBB.transform.position);
		}
		if (Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<BattlePreparationScreen>.instance)
		{
			GuiElementSingle<TutorialOverlayGuiElement>.instance.StartGoToBattle(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.IJPJDKALPDP.transform.position);
			GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<BattlePreparationScreen>.instance.AIMNGAOAPPE.OMDKNOFNFBB.transform.position);
		}
		if (Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<CardSelectionScreen>.instance)
		{
			GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<CardSelectionScreen>.instance.OMDKNOFNFBB.transform.position);
		}
	}
}
