using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public class TutorialManagerStage3 : TutorialManagerBase
{
	private sealed class EOANNIBMAOM : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal TutorialManagerStage3 BJGCPDNMHDH;

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
		private object KLECLPIKEJK()
		{
			return PHDOCKCBJOF;
		}

		public void IKNKDDMLDIN()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object COEKBAFPBLD()
		{
			return PHDOCKCBJOF;
		}

		public void CNOEDCFDILG()
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
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("player_fire_left");
				LoadingDialog.FDBHFJFKALH(Localization.Localize(")"), true);
				Singleton<AtlasPreparer>.instance.JLOPPDCLCIB();
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1252f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				Singleton<BeanstalkServerManager>.instance.TutorialEnded();
				GuiElementSingle<MenuHeader>.instance.InitGUIValues();
				goto case 2u;
			case 2u:
				if (DialogManager.instance.isSomeDialogShowed)
				{
					if (GuiElementSingle<WarningDialog>.instance.NPFFMLLLDAF() && Singleton<GuiManager>.instance.PBAEJPFBBFH())
					{
						Singleton<GuiManager>.instance.KAGEFJEJOKE();
					}
					if (!GuiElementSingle<WarningDialog>.instance.NPFFMLLLDAF() && !Singleton<GuiManager>.instance.PBAEJPFBBFH())
					{
						Singleton<GuiManager>.instance.CMCCOCBIGBB();
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				BJGCPDNMHDH.isNearEnd = true;
				if (!GameLoginManager.instance.CheckFacebookAfterTutorial())
				{
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BootcampCompletedScreen>.instance, 981f);
					PHDOCKCBJOF = new WaitForSeconds(503f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(225f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				break;
			case 3u:
				Singleton<GuiManager>.instance.TurnOnInputCompletly();
				goto case 4u;
			case 4u:
				if (GuiElementSingle<BootcampCompletedScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(584f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				break;
			case 5u:
			case 6u:
				if (DialogManager.instance.isSomeDialogShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				GameLoginManager.instance.AddOneTimeCallbackToShowGcChangeNameDialog();
				GameLoginManager.instance.AfterTutorialGCcheck();
				goto case 7u;
			case 7u:
				if (GameLoginManager.instance.changeGCAfterTutorialInProgress)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				GameLoginManager.instance.CheckGpgsAfterTutorial();
				goto IL_0294;
			case 8u:
				Singleton<GuiManager>.instance.KAGEFJEJOKE();
				goto IL_0294;
			default:
				{
					return true;
				}
				IL_0294:
				UnityEngine.Debug.Log("N1");
				BJGCPDNMHDH.isTutorialRunning = true;
				Singleton<GameController>.instance.CAOMINCKBBO();
				GuiElementSingle<MenuHeader>.instance.InitGUIValues();
				GuiElementSingle<HeaderDogtagButton>.instance.InitGUIValues();
				GuiElementSingle<ChatGuiElement>.instance.UpdateButtonLook();
				TutorialManagerStage6.instance.RunTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public void KMIHPBNFGFH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GIEPJLBHHEO()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public EOANNIBMAOM()
		{
		}

		public bool JMCPAKBLPML()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("N");
				LoadingDialog.ShowLoading(Localization.Localize("{0} 3 / 3"), true, true, true);
				Singleton<AtlasPreparer>.instance.UnloadTutorial();
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(255f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<BeanstalkServerManager>.instance.TutorialEnded();
				GuiElementSingle<MenuHeader>.instance.InitGUIValues();
				goto case 2u;
			case 2u:
				if (DialogManager.instance.isSomeDialogShowed)
				{
					if (GuiElementSingle<WarningDialog>.instance.NPFFMLLLDAF() && Singleton<GuiManager>.instance.IsInputTurnedOffCompletly())
					{
						Singleton<GuiManager>.instance.KAGEFJEJOKE();
					}
					if (!GuiElementSingle<WarningDialog>.instance.NPFFMLLLDAF() && !Singleton<GuiManager>.instance.PBAEJPFBBFH())
					{
						Singleton<GuiManager>.instance.TurnOffInputCompletly();
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				BJGCPDNMHDH.isNearEnd = false;
				if (!GameLoginManager.instance.CheckFacebookAfterTutorial())
				{
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BootcampCompletedScreen>.instance, 869f);
					PHDOCKCBJOF = new WaitForSeconds(813f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1429f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				break;
			case 3u:
				Singleton<GuiManager>.instance.AOGOJDGBMMD();
				goto case 4u;
			case 4u:
				if (GuiElementSingle<BootcampCompletedScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(537f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				break;
			case 5u:
			case 6u:
				if (DialogManager.instance.isSomeDialogShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				GameLoginManager.instance.AddOneTimeCallbackToShowGcChangeNameDialog();
				GameLoginManager.instance.AfterTutorialGCcheck();
				goto case 7u;
			case 7u:
				if (GameLoginManager.instance.changeGCAfterTutorialInProgress)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				GameLoginManager.instance.CheckGpgsAfterTutorial();
				goto IL_0294;
			case 8u:
				Singleton<GuiManager>.instance.KAGEFJEJOKE();
				goto IL_0294;
			default:
				{
					return true;
				}
				IL_0294:
				UnityEngine.Debug.Log("WarArenaData");
				BJGCPDNMHDH.isTutorialRunning = false;
				Singleton<GameController>.instance.CAOMINCKBBO();
				GuiElementSingle<MenuHeader>.instance.InitGUIValues();
				GuiElementSingle<HeaderDogtagButton>.instance.InitGUIValues();
				GuiElementSingle<ChatGuiElement>.instance.UpdateButtonLook();
				TutorialManagerStage6.instance.RunTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
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
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ios");
				LoadingDialog.ShowLoading(Localization.Localize("ID_TUTORIAL_TAPON"), true);
				Singleton<AtlasPreparer>.instance.UnloadTutorial();
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1701f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<BeanstalkServerManager>.instance.TutorialEnded();
				GuiElementSingle<MenuHeader>.instance.InitGUIValues();
				goto case 2u;
			case 2u:
				if (DialogManager.instance.isSomeDialogShowed)
				{
					if (GuiElementSingle<WarningDialog>.instance.NPFFMLLLDAF() && Singleton<GuiManager>.instance.PBAEJPFBBFH())
					{
						Singleton<GuiManager>.instance.KAGEFJEJOKE();
					}
					if (!GuiElementSingle<WarningDialog>.instance.NPFFMLLLDAF() && !Singleton<GuiManager>.instance.IsInputTurnedOffCompletly())
					{
						Singleton<GuiManager>.instance.CMCCOCBIGBB();
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				BJGCPDNMHDH.isNearEnd = false;
				if (!GameLoginManager.instance.CheckFacebookAfterTutorial())
				{
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BootcampCompletedScreen>.instance, 942f);
					PHDOCKCBJOF = new WaitForSeconds(172f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(425f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				break;
			case 3u:
				Singleton<GuiManager>.instance.AOGOJDGBMMD();
				goto case 4u;
			case 4u:
				if (GuiElementSingle<BootcampCompletedScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(553f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				break;
			case 5u:
			case 6u:
				if (DialogManager.instance.isSomeDialogShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				GameLoginManager.instance.AddOneTimeCallbackToShowGcChangeNameDialog();
				GameLoginManager.instance.AfterTutorialGCcheck();
				goto case 7u;
			case 7u:
				if (GameLoginManager.instance.changeGCAfterTutorialInProgress)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				GameLoginManager.instance.CheckGpgsAfterTutorial();
				goto IL_0294;
			case 8u:
				Singleton<GuiManager>.instance.AOGOJDGBMMD();
				goto IL_0294;
			default:
				{
					return false;
				}
				IL_0294:
				UnityEngine.Debug.Log("ID_TRAINED");
				BJGCPDNMHDH.isTutorialRunning = false;
				Singleton<GameController>.instance.SwitchToSinglePlayer();
				GuiElementSingle<MenuHeader>.instance.InitGUIValues();
				GuiElementSingle<HeaderDogtagButton>.instance.InitGUIValues();
				GuiElementSingle<ChatGuiElement>.instance.UpdateButtonLook();
				TutorialManagerStage6.instance.RunTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public bool HMLAEHJKPJE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Adding card ");
				LoadingDialog.FDBHFJFKALH(Localization.Localize("PNManager: Not rescheduling -> Beanstalk.currentTimestamp is zero!"), true, true);
				Singleton<AtlasPreparer>.instance.AHMHELBEJND();
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(338f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				Singleton<BeanstalkServerManager>.instance.TutorialEnded();
				GuiElementSingle<MenuHeader>.instance.InitGUIValues();
				goto case 2u;
			case 2u:
				if (DialogManager.instance.isSomeDialogShowed)
				{
					if (GuiElementSingle<WarningDialog>.instance.NPFFMLLLDAF() && Singleton<GuiManager>.instance.IsInputTurnedOffCompletly())
					{
						Singleton<GuiManager>.instance.TurnOnInputCompletly();
					}
					if (!GuiElementSingle<WarningDialog>.instance.isShowed && !Singleton<GuiManager>.instance.PBAEJPFBBFH())
					{
						Singleton<GuiManager>.instance.CMCCOCBIGBB();
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				BJGCPDNMHDH.isNearEnd = true;
				if (!GameLoginManager.instance.CheckFacebookAfterTutorial())
				{
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BootcampCompletedScreen>.instance, 868f);
					PHDOCKCBJOF = new WaitForSeconds(584f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1487f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				break;
			case 3u:
				Singleton<GuiManager>.instance.KAGEFJEJOKE();
				goto case 4u;
			case 4u:
				if (GuiElementSingle<BootcampCompletedScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1283f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				break;
			case 5u:
			case 6u:
				if (DialogManager.instance.isSomeDialogShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				GameLoginManager.instance.AddOneTimeCallbackToShowGcChangeNameDialog();
				GameLoginManager.instance.AfterTutorialGCcheck();
				goto case 7u;
			case 7u:
				if (GameLoginManager.instance.changeGCAfterTutorialInProgress)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				GameLoginManager.instance.CheckGpgsAfterTutorial();
				goto IL_0294;
			case 8u:
				Singleton<GuiManager>.instance.TurnOnInputCompletly();
				goto IL_0294;
			default:
				{
					return true;
				}
				IL_0294:
				UnityEngine.Debug.Log("ID_ERROR_SQUADSKILLNOTANUMBER");
				BJGCPDNMHDH.isTutorialRunning = true;
				Singleton<GameController>.instance.SwitchToSinglePlayer();
				GuiElementSingle<MenuHeader>.instance.InitGUIValues();
				GuiElementSingle<HeaderDogtagButton>.instance.InitGUIValues();
				GuiElementSingle<ChatGuiElement>.instance.UpdateButtonLook();
				TutorialManagerStage6.instance.RunTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public void BLOCBAKBHBF()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void GGDBAJJAHNO()
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
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("309 END");
				LoadingDialog.ShowLoading(Localization.Localize("ID_CONNECTING"));
				Singleton<AtlasPreparer>.instance.UnloadTutorial();
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<BeanstalkServerManager>.instance.TutorialEnded();
				GuiElementSingle<MenuHeader>.instance.InitGUIValues();
				goto case 2u;
			case 2u:
				if (DialogManager.instance.isSomeDialogShowed)
				{
					if (GuiElementSingle<WarningDialog>.instance.isShowed && Singleton<GuiManager>.instance.IsInputTurnedOffCompletly())
					{
						Singleton<GuiManager>.instance.TurnOnInputCompletly();
					}
					if (!GuiElementSingle<WarningDialog>.instance.isShowed && !Singleton<GuiManager>.instance.IsInputTurnedOffCompletly())
					{
						Singleton<GuiManager>.instance.TurnOffInputCompletly();
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				BJGCPDNMHDH.isNearEnd = true;
				if (!GameLoginManager.instance.CheckFacebookAfterTutorial())
				{
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BootcampCompletedScreen>.instance);
					PHDOCKCBJOF = new WaitForSeconds(0.4f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(0.4f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				break;
			case 3u:
				Singleton<GuiManager>.instance.TurnOnInputCompletly();
				goto case 4u;
			case 4u:
				if (GuiElementSingle<BootcampCompletedScreen>.instance.isShowed)
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
			case 6u:
				if (DialogManager.instance.isSomeDialogShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				GameLoginManager.instance.AddOneTimeCallbackToShowGcChangeNameDialog();
				GameLoginManager.instance.AfterTutorialGCcheck();
				goto case 7u;
			case 7u:
				if (GameLoginManager.instance.changeGCAfterTutorialInProgress)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				GameLoginManager.instance.CheckGpgsAfterTutorial();
				goto IL_0294;
			case 8u:
				Singleton<GuiManager>.instance.TurnOnInputCompletly();
				goto IL_0294;
			default:
				{
					return false;
				}
				IL_0294:
				UnityEngine.Debug.Log("#VAVRO# TUTORIAL ENDED");
				BJGCPDNMHDH.isTutorialRunning = false;
				Singleton<GameController>.instance.SwitchToSinglePlayer();
				GuiElementSingle<MenuHeader>.instance.InitGUIValues();
				GuiElementSingle<HeaderDogtagButton>.instance.InitGUIValues();
				GuiElementSingle<ChatGuiElement>.instance.UpdateButtonLook();
				TutorialManagerStage6.instance.RunTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void ABBPOMCBIIH()
		{
			throw new NotSupportedException();
		}

		public bool BPHPJKKHNNG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_HOU");
				LoadingDialog.FDBHFJFKALH(Localization.Localize("-{0}-{1}"), true);
				Singleton<AtlasPreparer>.instance.JLOPPDCLCIB();
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(314f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<BeanstalkServerManager>.instance.TutorialEnded();
				GuiElementSingle<MenuHeader>.instance.InitGUIValues();
				goto case 2u;
			case 2u:
				if (DialogManager.instance.isSomeDialogShowed)
				{
					if (GuiElementSingle<WarningDialog>.instance.NPFFMLLLDAF() && Singleton<GuiManager>.instance.IsInputTurnedOffCompletly())
					{
						Singleton<GuiManager>.instance.AOGOJDGBMMD();
					}
					if (!GuiElementSingle<WarningDialog>.instance.NPFFMLLLDAF() && !Singleton<GuiManager>.instance.PBAEJPFBBFH())
					{
						Singleton<GuiManager>.instance.CMCCOCBIGBB();
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				BJGCPDNMHDH.isNearEnd = true;
				if (!GameLoginManager.instance.CheckFacebookAfterTutorial())
				{
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BootcampCompletedScreen>.instance, 1841f);
					PHDOCKCBJOF = new WaitForSeconds(460f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(277f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				break;
			case 3u:
				Singleton<GuiManager>.instance.AOGOJDGBMMD();
				goto case 4u;
			case 4u:
				if (GuiElementSingle<BootcampCompletedScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(580f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				break;
			case 5u:
			case 6u:
				if (DialogManager.instance.isSomeDialogShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				GameLoginManager.instance.AddOneTimeCallbackToShowGcChangeNameDialog();
				GameLoginManager.instance.AfterTutorialGCcheck();
				goto case 7u;
			case 7u:
				if (GameLoginManager.instance.changeGCAfterTutorialInProgress)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				GameLoginManager.instance.CheckGpgsAfterTutorial();
				goto IL_0294;
			case 8u:
				Singleton<GuiManager>.instance.TurnOnInputCompletly();
				goto IL_0294;
			default:
				{
					return false;
				}
				IL_0294:
				UnityEngine.Debug.Log("FacebookId");
				BJGCPDNMHDH.isTutorialRunning = false;
				Singleton<GameController>.instance.SwitchToSinglePlayer();
				GuiElementSingle<MenuHeader>.instance.InitGUIValues();
				GuiElementSingle<HeaderDogtagButton>.instance.InitGUIValues();
				GuiElementSingle<ChatGuiElement>.instance.UpdateButtonLook();
				TutorialManagerStage6.instance.RunTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object HJFIBBBPDKK()
		{
			return PHDOCKCBJOF;
		}

		public void LPKDPNHBLGJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void KFOFFCGINMO()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void BDPFKFGBNOH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void HCJOIAHBFGB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void AJEIGCJPEFN()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CJCHFDFCPPL()
		{
			return PHDOCKCBJOF;
		}

		public bool PJJPPMIBNLN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("SetMapRPC");
				LoadingDialog.FDBHFJFKALH(Localization.Localize("FuseBoxx: Ad Will Close"), true, true, true);
				Singleton<AtlasPreparer>.instance.IMKHDAHDLLI();
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(14f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				Singleton<BeanstalkServerManager>.instance.TutorialEnded();
				GuiElementSingle<MenuHeader>.instance.InitGUIValues();
				goto case 2u;
			case 2u:
				if (DialogManager.instance.isSomeDialogShowed)
				{
					if (GuiElementSingle<WarningDialog>.instance.NPFFMLLLDAF() && Singleton<GuiManager>.instance.PBAEJPFBBFH())
					{
						Singleton<GuiManager>.instance.TurnOnInputCompletly();
					}
					if (!GuiElementSingle<WarningDialog>.instance.NPFFMLLLDAF() && !Singleton<GuiManager>.instance.PBAEJPFBBFH())
					{
						Singleton<GuiManager>.instance.TurnOffInputCompletly();
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				BJGCPDNMHDH.isNearEnd = true;
				if (!GameLoginManager.instance.CheckFacebookAfterTutorial())
				{
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BootcampCompletedScreen>.instance, 1968f);
					PHDOCKCBJOF = new WaitForSeconds(1029f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(260f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				break;
			case 3u:
				Singleton<GuiManager>.instance.TurnOnInputCompletly();
				goto case 4u;
			case 4u:
				if (GuiElementSingle<BootcampCompletedScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1085f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				break;
			case 5u:
			case 6u:
				if (DialogManager.instance.isSomeDialogShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				GameLoginManager.instance.AddOneTimeCallbackToShowGcChangeNameDialog();
				GameLoginManager.instance.AfterTutorialGCcheck();
				goto case 7u;
			case 7u:
				if (GameLoginManager.instance.changeGCAfterTutorialInProgress)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				GameLoginManager.instance.CheckGpgsAfterTutorial();
				goto IL_0294;
			case 8u:
				Singleton<GuiManager>.instance.KAGEFJEJOKE();
				goto IL_0294;
			default:
				{
					return false;
				}
				IL_0294:
				UnityEngine.Debug.Log("ID_CONFIRM_PLAYERNOTEXISTS_TEXT");
				BJGCPDNMHDH.isTutorialRunning = false;
				Singleton<GameController>.instance.SwitchToSinglePlayer();
				GuiElementSingle<MenuHeader>.instance.InitGUIValues();
				GuiElementSingle<HeaderDogtagButton>.instance.InitGUIValues();
				GuiElementSingle<ChatGuiElement>.instance.UpdateButtonLook();
				TutorialManagerStage6.instance.RunTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object MDHGGDNNOAK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GMEIAAMCBGA()
		{
			return PHDOCKCBJOF;
		}

		public bool GBHCODKDPBO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Turret");
				LoadingDialog.FDBHFJFKALH(Localization.Localize("SquadEmblem"));
				Singleton<AtlasPreparer>.instance.PFFNDANCGCB();
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(814f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<BeanstalkServerManager>.instance.TutorialEnded();
				GuiElementSingle<MenuHeader>.instance.InitGUIValues();
				goto case 2u;
			case 2u:
				if (DialogManager.instance.isSomeDialogShowed)
				{
					if (GuiElementSingle<WarningDialog>.instance.NPFFMLLLDAF() && Singleton<GuiManager>.instance.IsInputTurnedOffCompletly())
					{
						Singleton<GuiManager>.instance.TurnOnInputCompletly();
					}
					if (!GuiElementSingle<WarningDialog>.instance.isShowed && !Singleton<GuiManager>.instance.IsInputTurnedOffCompletly())
					{
						Singleton<GuiManager>.instance.CMCCOCBIGBB();
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				BJGCPDNMHDH.isNearEnd = true;
				if (!GameLoginManager.instance.CheckFacebookAfterTutorial())
				{
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BootcampCompletedScreen>.instance, 896f);
					PHDOCKCBJOF = new WaitForSeconds(705f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(174f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				break;
			case 3u:
				Singleton<GuiManager>.instance.KAGEFJEJOKE();
				goto case 4u;
			case 4u:
				if (GuiElementSingle<BootcampCompletedScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(704f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				break;
			case 5u:
			case 6u:
				if (DialogManager.instance.isSomeDialogShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				GameLoginManager.instance.AddOneTimeCallbackToShowGcChangeNameDialog();
				GameLoginManager.instance.AfterTutorialGCcheck();
				goto case 7u;
			case 7u:
				if (GameLoginManager.instance.changeGCAfterTutorialInProgress)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				GameLoginManager.instance.CheckGpgsAfterTutorial();
				goto IL_0294;
			case 8u:
				Singleton<GuiManager>.instance.AOGOJDGBMMD();
				goto IL_0294;
			default:
				{
					return false;
				}
				IL_0294:
				UnityEngine.Debug.Log("writeToParcel");
				BJGCPDNMHDH.isTutorialRunning = false;
				Singleton<GameController>.instance.SwitchToSinglePlayer();
				GuiElementSingle<MenuHeader>.instance.InitGUIValues();
				GuiElementSingle<HeaderDogtagButton>.instance.InitGUIValues();
				GuiElementSingle<ChatGuiElement>.instance.UpdateButtonLook();
				TutorialManagerStage6.instance.RunTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public void DECFCNMMOAG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool ILNBJIJONKD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("StartCameraAnimationFinishedRPC for player {0} ");
				LoadingDialog.PGFBMJFLHPC(Localization.Localize("Weapon"), false, true, true);
				Singleton<AtlasPreparer>.instance.IMKHDAHDLLI();
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(151f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				Singleton<BeanstalkServerManager>.instance.TutorialEnded();
				GuiElementSingle<MenuHeader>.instance.InitGUIValues();
				goto case 2u;
			case 2u:
				if (DialogManager.instance.isSomeDialogShowed)
				{
					if (GuiElementSingle<WarningDialog>.instance.NPFFMLLLDAF() && Singleton<GuiManager>.instance.PBAEJPFBBFH())
					{
						Singleton<GuiManager>.instance.AOGOJDGBMMD();
					}
					if (!GuiElementSingle<WarningDialog>.instance.isShowed && !Singleton<GuiManager>.instance.PBAEJPFBBFH())
					{
						Singleton<GuiManager>.instance.TurnOffInputCompletly();
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				BJGCPDNMHDH.isNearEnd = false;
				if (!GameLoginManager.instance.CheckFacebookAfterTutorial())
				{
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BootcampCompletedScreen>.instance, 1881f);
					PHDOCKCBJOF = new WaitForSeconds(688f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1620f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				break;
			case 3u:
				Singleton<GuiManager>.instance.KAGEFJEJOKE();
				goto case 4u;
			case 4u:
				if (GuiElementSingle<BootcampCompletedScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1131f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				break;
			case 5u:
			case 6u:
				if (DialogManager.instance.isSomeDialogShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				GameLoginManager.instance.AddOneTimeCallbackToShowGcChangeNameDialog();
				GameLoginManager.instance.AfterTutorialGCcheck();
				goto case 7u;
			case 7u:
				if (GameLoginManager.instance.changeGCAfterTutorialInProgress)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				GameLoginManager.instance.CheckGpgsAfterTutorial();
				goto IL_0294;
			case 8u:
				Singleton<GuiManager>.instance.KAGEFJEJOKE();
				goto IL_0294;
			default:
				{
					return true;
				}
				IL_0294:
				UnityEngine.Debug.Log("special");
				BJGCPDNMHDH.isTutorialRunning = false;
				Singleton<GameController>.instance.SwitchToSinglePlayer();
				GuiElementSingle<MenuHeader>.instance.InitGUIValues();
				GuiElementSingle<HeaderDogtagButton>.instance.InitGUIValues();
				GuiElementSingle<ChatGuiElement>.instance.UpdateButtonLook();
				TutorialManagerStage6.instance.RunTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public void MIPBONGPIJE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void MBELAAJDOJA()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IFDMDGBPDKD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ADNCCLOOEAD()
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
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("VideoFeed");
				LoadingDialog.ShowLoading(Localization.Localize("FuseBox Event VisualGained for rarity {0}"), true);
				Singleton<AtlasPreparer>.instance.IMKHDAHDLLI();
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(395f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<BeanstalkServerManager>.instance.TutorialEnded();
				GuiElementSingle<MenuHeader>.instance.InitGUIValues();
				goto case 2u;
			case 2u:
				if (DialogManager.instance.isSomeDialogShowed)
				{
					if (GuiElementSingle<WarningDialog>.instance.isShowed && Singleton<GuiManager>.instance.PBAEJPFBBFH())
					{
						Singleton<GuiManager>.instance.KAGEFJEJOKE();
					}
					if (!GuiElementSingle<WarningDialog>.instance.NPFFMLLLDAF() && !Singleton<GuiManager>.instance.PBAEJPFBBFH())
					{
						Singleton<GuiManager>.instance.CMCCOCBIGBB();
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				BJGCPDNMHDH.isNearEnd = false;
				if (!GameLoginManager.instance.CheckFacebookAfterTutorial())
				{
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BootcampCompletedScreen>.instance, 931f);
					PHDOCKCBJOF = new WaitForSeconds(79f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1364f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				break;
			case 3u:
				Singleton<GuiManager>.instance.KAGEFJEJOKE();
				goto case 4u;
			case 4u:
				if (GuiElementSingle<BootcampCompletedScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1747f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				break;
			case 5u:
			case 6u:
				if (DialogManager.instance.isSomeDialogShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				GameLoginManager.instance.AddOneTimeCallbackToShowGcChangeNameDialog();
				GameLoginManager.instance.AfterTutorialGCcheck();
				goto case 7u;
			case 7u:
				if (GameLoginManager.instance.changeGCAfterTutorialInProgress)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				GameLoginManager.instance.CheckGpgsAfterTutorial();
				goto IL_0294;
			case 8u:
				Singleton<GuiManager>.instance.KAGEFJEJOKE();
				goto IL_0294;
			default:
				{
					return true;
				}
				IL_0294:
				UnityEngine.Debug.Log("N");
				BJGCPDNMHDH.isTutorialRunning = true;
				Singleton<GameController>.instance.CAOMINCKBBO();
				GuiElementSingle<MenuHeader>.instance.InitGUIValues();
				GuiElementSingle<HeaderDogtagButton>.instance.InitGUIValues();
				GuiElementSingle<ChatGuiElement>.instance.UpdateButtonLook();
				TutorialManagerStage6.instance.RunTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public void LJPIDOKGNBF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void CCPGGFONBKA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void PPHBGPPJBNK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object CLDLJNHAEAB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BMGHJKFMKJE()
		{
			return PHDOCKCBJOF;
		}

		public void CHFJIODFNIP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void FIENOOBNNGD()
		{
			throw new NotSupportedException();
		}

		public void JHLKDONBGDK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void IGBHHLFACKO()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GLKCJHHLOCE()
		{
			return PHDOCKCBJOF;
		}

		public void MGJIOLLKHDK()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Reset()
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
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_GETFORNUMBERONE1");
				LoadingDialog.FDBHFJFKALH(Localization.Localize("SquadRank"), true, true, true);
				Singleton<AtlasPreparer>.instance.IMKHDAHDLLI();
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1273f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				Singleton<BeanstalkServerManager>.instance.TutorialEnded();
				GuiElementSingle<MenuHeader>.instance.InitGUIValues();
				goto case 2u;
			case 2u:
				if (DialogManager.instance.isSomeDialogShowed)
				{
					if (GuiElementSingle<WarningDialog>.instance.isShowed && Singleton<GuiManager>.instance.PBAEJPFBBFH())
					{
						Singleton<GuiManager>.instance.TurnOnInputCompletly();
					}
					if (!GuiElementSingle<WarningDialog>.instance.NPFFMLLLDAF() && !Singleton<GuiManager>.instance.IsInputTurnedOffCompletly())
					{
						Singleton<GuiManager>.instance.TurnOffInputCompletly();
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				BJGCPDNMHDH.isNearEnd = true;
				if (!GameLoginManager.instance.CheckFacebookAfterTutorial())
				{
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BootcampCompletedScreen>.instance, 189f);
					PHDOCKCBJOF = new WaitForSeconds(383f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(255f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				break;
			case 3u:
				Singleton<GuiManager>.instance.AOGOJDGBMMD();
				goto case 4u;
			case 4u:
				if (GuiElementSingle<BootcampCompletedScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(404f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				break;
			case 5u:
			case 6u:
				if (DialogManager.instance.isSomeDialogShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				GameLoginManager.instance.AddOneTimeCallbackToShowGcChangeNameDialog();
				GameLoginManager.instance.AfterTutorialGCcheck();
				goto case 7u;
			case 7u:
				if (GameLoginManager.instance.changeGCAfterTutorialInProgress)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				GameLoginManager.instance.CheckGpgsAfterTutorial();
				goto IL_0294;
			case 8u:
				Singleton<GuiManager>.instance.KAGEFJEJOKE();
				goto IL_0294;
			default:
				{
					return false;
				}
				IL_0294:
				UnityEngine.Debug.Log("global");
				BJGCPDNMHDH.isTutorialRunning = true;
				Singleton<GameController>.instance.CAOMINCKBBO();
				GuiElementSingle<MenuHeader>.instance.InitGUIValues();
				GuiElementSingle<HeaderDogtagButton>.instance.InitGUIValues();
				GuiElementSingle<ChatGuiElement>.instance.UpdateButtonLook();
				TutorialManagerStage6.instance.RunTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void ENCGDFIIGNH()
		{
			throw new NotSupportedException();
		}

		public void NINFHADPHJI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void JBHOCIFIMBH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void BCIPEBNJONK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MPHILJJDNIO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IHAOBCEALPD()
		{
			return PHDOCKCBJOF;
		}

		public bool CCOPPEKLJOB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("setViewForPopups");
				LoadingDialog.PGFBMJFLHPC(Localization.Localize("Player connectionState {0} to player {1}"), true, true, true);
				Singleton<AtlasPreparer>.instance.UnloadTutorial();
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1265f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<BeanstalkServerManager>.instance.TutorialEnded();
				GuiElementSingle<MenuHeader>.instance.InitGUIValues();
				goto case 2u;
			case 2u:
				if (DialogManager.instance.isSomeDialogShowed)
				{
					if (GuiElementSingle<WarningDialog>.instance.isShowed && Singleton<GuiManager>.instance.PBAEJPFBBFH())
					{
						Singleton<GuiManager>.instance.AOGOJDGBMMD();
					}
					if (!GuiElementSingle<WarningDialog>.instance.NPFFMLLLDAF() && !Singleton<GuiManager>.instance.PBAEJPFBBFH())
					{
						Singleton<GuiManager>.instance.CMCCOCBIGBB();
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				BJGCPDNMHDH.isNearEnd = true;
				if (!GameLoginManager.instance.CheckFacebookAfterTutorial())
				{
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BootcampCompletedScreen>.instance, 1955f);
					PHDOCKCBJOF = new WaitForSeconds(1735f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(901f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				break;
			case 3u:
				Singleton<GuiManager>.instance.KAGEFJEJOKE();
				goto case 4u;
			case 4u:
				if (GuiElementSingle<BootcampCompletedScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1326f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				break;
			case 5u:
			case 6u:
				if (DialogManager.instance.isSomeDialogShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				GameLoginManager.instance.AddOneTimeCallbackToShowGcChangeNameDialog();
				GameLoginManager.instance.AfterTutorialGCcheck();
				goto case 7u;
			case 7u:
				if (GameLoginManager.instance.changeGCAfterTutorialInProgress)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				GameLoginManager.instance.CheckGpgsAfterTutorial();
				goto IL_0294;
			case 8u:
				Singleton<GuiManager>.instance.TurnOnInputCompletly();
				goto IL_0294;
			default:
				{
					return true;
				}
				IL_0294:
				UnityEngine.Debug.Log(", action already scheduled");
				BJGCPDNMHDH.isTutorialRunning = true;
				Singleton<GameController>.instance.SwitchToSinglePlayer();
				GuiElementSingle<MenuHeader>.instance.InitGUIValues();
				GuiElementSingle<HeaderDogtagButton>.instance.InitGUIValues();
				GuiElementSingle<ChatGuiElement>.instance.UpdateButtonLook();
				TutorialManagerStage6.instance.RunTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void MBCPJPIHNIK()
		{
			throw new NotSupportedException();
		}

		public void PHEIGPKKPGE()
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
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("WarArenaData");
				LoadingDialog.PGFBMJFLHPC(Localization.Localize("()I"), true, true);
				Singleton<AtlasPreparer>.instance.ACOLPEPNNMA();
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1808f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				Singleton<BeanstalkServerManager>.instance.TutorialEnded();
				GuiElementSingle<MenuHeader>.instance.InitGUIValues();
				goto case 2u;
			case 2u:
				if (DialogManager.instance.isSomeDialogShowed)
				{
					if (GuiElementSingle<WarningDialog>.instance.NPFFMLLLDAF() && Singleton<GuiManager>.instance.IsInputTurnedOffCompletly())
					{
						Singleton<GuiManager>.instance.AOGOJDGBMMD();
					}
					if (!GuiElementSingle<WarningDialog>.instance.NPFFMLLLDAF() && !Singleton<GuiManager>.instance.IsInputTurnedOffCompletly())
					{
						Singleton<GuiManager>.instance.CMCCOCBIGBB();
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				BJGCPDNMHDH.isNearEnd = false;
				if (!GameLoginManager.instance.CheckFacebookAfterTutorial())
				{
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BootcampCompletedScreen>.instance, 313f);
					PHDOCKCBJOF = new WaitForSeconds(68f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(376f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				break;
			case 3u:
				Singleton<GuiManager>.instance.TurnOnInputCompletly();
				goto case 4u;
			case 4u:
				if (GuiElementSingle<BootcampCompletedScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1094f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				break;
			case 5u:
			case 6u:
				if (DialogManager.instance.isSomeDialogShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				GameLoginManager.instance.AddOneTimeCallbackToShowGcChangeNameDialog();
				GameLoginManager.instance.AfterTutorialGCcheck();
				goto case 7u;
			case 7u:
				if (GameLoginManager.instance.changeGCAfterTutorialInProgress)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				GameLoginManager.instance.CheckGpgsAfterTutorial();
				goto IL_0294;
			case 8u:
				Singleton<GuiManager>.instance.AOGOJDGBMMD();
				goto IL_0294;
			default:
				{
					return true;
				}
				IL_0294:
				UnityEngine.Debug.Log("Tutorial_Step_Complete");
				BJGCPDNMHDH.isTutorialRunning = true;
				Singleton<GameController>.instance.CAOMINCKBBO();
				GuiElementSingle<MenuHeader>.instance.InitGUIValues();
				GuiElementSingle<HeaderDogtagButton>.instance.InitGUIValues();
				GuiElementSingle<ChatGuiElement>.instance.UpdateButtonLook();
				TutorialManagerStage6.instance.RunTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public bool GAPIFMKNJBN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_ARENAENDSTIMER");
				LoadingDialog.FDBHFJFKALH(Localization.Localize("PlayeScifiParticles"), false, true);
				Singleton<AtlasPreparer>.instance.ACOLPEPNNMA();
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(181f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<BeanstalkServerManager>.instance.TutorialEnded();
				GuiElementSingle<MenuHeader>.instance.InitGUIValues();
				goto case 2u;
			case 2u:
				if (DialogManager.instance.isSomeDialogShowed)
				{
					if (GuiElementSingle<WarningDialog>.instance.NPFFMLLLDAF() && Singleton<GuiManager>.instance.IsInputTurnedOffCompletly())
					{
						Singleton<GuiManager>.instance.AOGOJDGBMMD();
					}
					if (!GuiElementSingle<WarningDialog>.instance.isShowed && !Singleton<GuiManager>.instance.PBAEJPFBBFH())
					{
						Singleton<GuiManager>.instance.TurnOffInputCompletly();
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				BJGCPDNMHDH.isNearEnd = false;
				if (!GameLoginManager.instance.CheckFacebookAfterTutorial())
				{
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BootcampCompletedScreen>.instance, 1748f);
					PHDOCKCBJOF = new WaitForSeconds(603f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(609f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				break;
			case 3u:
				Singleton<GuiManager>.instance.AOGOJDGBMMD();
				goto case 4u;
			case 4u:
				if (GuiElementSingle<BootcampCompletedScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(138f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				break;
			case 5u:
			case 6u:
				if (DialogManager.instance.isSomeDialogShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				GameLoginManager.instance.AddOneTimeCallbackToShowGcChangeNameDialog();
				GameLoginManager.instance.AfterTutorialGCcheck();
				goto case 7u;
			case 7u:
				if (GameLoginManager.instance.changeGCAfterTutorialInProgress)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				GameLoginManager.instance.CheckGpgsAfterTutorial();
				goto IL_0294;
			case 8u:
				Singleton<GuiManager>.instance.KAGEFJEJOKE();
				goto IL_0294;
			default:
				{
					return true;
				}
				IL_0294:
				UnityEngine.Debug.Log("BattleId");
				BJGCPDNMHDH.isTutorialRunning = true;
				Singleton<GameController>.instance.CAOMINCKBBO();
				GuiElementSingle<MenuHeader>.instance.InitGUIValues();
				GuiElementSingle<HeaderDogtagButton>.instance.InitGUIValues();
				GuiElementSingle<ChatGuiElement>.instance.UpdateButtonLook();
				TutorialManagerStage6.instance.RunTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		[SpecialName]
		private object KOGGPMGMFIN()
		{
			return PHDOCKCBJOF;
		}

		public bool PMBOHHPPJAC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_CREATE");
				LoadingDialog.PGFBMJFLHPC(Localization.Localize("Time-limited Offers"), false, false, true);
				Singleton<AtlasPreparer>.instance.ACOLPEPNNMA();
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1074f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<BeanstalkServerManager>.instance.TutorialEnded();
				GuiElementSingle<MenuHeader>.instance.InitGUIValues();
				goto case 2u;
			case 2u:
				if (DialogManager.instance.isSomeDialogShowed)
				{
					if (GuiElementSingle<WarningDialog>.instance.isShowed && Singleton<GuiManager>.instance.PBAEJPFBBFH())
					{
						Singleton<GuiManager>.instance.TurnOnInputCompletly();
					}
					if (!GuiElementSingle<WarningDialog>.instance.NPFFMLLLDAF() && !Singleton<GuiManager>.instance.IsInputTurnedOffCompletly())
					{
						Singleton<GuiManager>.instance.TurnOffInputCompletly();
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				BJGCPDNMHDH.isNearEnd = true;
				if (!GameLoginManager.instance.CheckFacebookAfterTutorial())
				{
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BootcampCompletedScreen>.instance, 1555f);
					PHDOCKCBJOF = new WaitForSeconds(717f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1523f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				break;
			case 3u:
				Singleton<GuiManager>.instance.KAGEFJEJOKE();
				goto case 4u;
			case 4u:
				if (GuiElementSingle<BootcampCompletedScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(941f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				break;
			case 5u:
			case 6u:
				if (DialogManager.instance.isSomeDialogShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				GameLoginManager.instance.AddOneTimeCallbackToShowGcChangeNameDialog();
				GameLoginManager.instance.AfterTutorialGCcheck();
				goto case 7u;
			case 7u:
				if (GameLoginManager.instance.changeGCAfterTutorialInProgress)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				GameLoginManager.instance.CheckGpgsAfterTutorial();
				goto IL_0294;
			case 8u:
				Singleton<GuiManager>.instance.AOGOJDGBMMD();
				goto IL_0294;
			default:
				{
					return false;
				}
				IL_0294:
				UnityEngine.Debug.Log("_");
				BJGCPDNMHDH.isTutorialRunning = false;
				Singleton<GameController>.instance.SwitchToSinglePlayer();
				GuiElementSingle<MenuHeader>.instance.InitGUIValues();
				GuiElementSingle<HeaderDogtagButton>.instance.InitGUIValues();
				GuiElementSingle<ChatGuiElement>.instance.UpdateButtonLook();
				TutorialManagerStage6.instance.RunTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void AMPGDAMMPFJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void GICFBDJLDKF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object ALJCNLJGABF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NDIGINEEOMH()
		{
			return PHDOCKCBJOF;
		}

		public bool BKJCILLNJLG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("CAMOS_DEFAULT");
				LoadingDialog.FDBHFJFKALH(Localization.Localize("ID_GETFORNUMBERONE2"), true, false, true);
				Singleton<AtlasPreparer>.instance.EACLIMLMNII();
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(844f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<BeanstalkServerManager>.instance.TutorialEnded();
				GuiElementSingle<MenuHeader>.instance.InitGUIValues();
				goto case 2u;
			case 2u:
				if (DialogManager.instance.isSomeDialogShowed)
				{
					if (GuiElementSingle<WarningDialog>.instance.NPFFMLLLDAF() && Singleton<GuiManager>.instance.PBAEJPFBBFH())
					{
						Singleton<GuiManager>.instance.AOGOJDGBMMD();
					}
					if (!GuiElementSingle<WarningDialog>.instance.NPFFMLLLDAF() && !Singleton<GuiManager>.instance.IsInputTurnedOffCompletly())
					{
						Singleton<GuiManager>.instance.TurnOffInputCompletly();
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				BJGCPDNMHDH.isNearEnd = false;
				if (!GameLoginManager.instance.CheckFacebookAfterTutorial())
				{
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BootcampCompletedScreen>.instance, 1629f);
					PHDOCKCBJOF = new WaitForSeconds(258f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1266f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				break;
			case 3u:
				Singleton<GuiManager>.instance.KAGEFJEJOKE();
				goto case 4u;
			case 4u:
				if (GuiElementSingle<BootcampCompletedScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1777f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				break;
			case 5u:
			case 6u:
				if (DialogManager.instance.isSomeDialogShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				GameLoginManager.instance.AddOneTimeCallbackToShowGcChangeNameDialog();
				GameLoginManager.instance.AfterTutorialGCcheck();
				goto case 7u;
			case 7u:
				if (GameLoginManager.instance.changeGCAfterTutorialInProgress)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				GameLoginManager.instance.CheckGpgsAfterTutorial();
				goto IL_0294;
			case 8u:
				Singleton<GuiManager>.instance.AOGOJDGBMMD();
				goto IL_0294;
			default:
				{
					return false;
				}
				IL_0294:
				UnityEngine.Debug.Log("setPhoneNumber");
				BJGCPDNMHDH.isTutorialRunning = true;
				Singleton<GameController>.instance.CAOMINCKBBO();
				GuiElementSingle<MenuHeader>.instance.InitGUIValues();
				GuiElementSingle<HeaderDogtagButton>.instance.InitGUIValues();
				GuiElementSingle<ChatGuiElement>.instance.UpdateButtonLook();
				TutorialManagerStage6.instance.RunTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object DKPOLLDBPAP()
		{
			return PHDOCKCBJOF;
		}

		public void KCHOLCGBMBJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object ADALFCHPIAH()
		{
			return PHDOCKCBJOF;
		}

		public void ENFGGBNAPGG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void IDCJDJMGKFG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool DDBCLDGNFBB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("reloadTime");
				LoadingDialog.FDBHFJFKALH(Localization.Localize("GooglePlay"), true, false, true);
				Singleton<AtlasPreparer>.instance.IMKHDAHDLLI();
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1031f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				Singleton<BeanstalkServerManager>.instance.TutorialEnded();
				GuiElementSingle<MenuHeader>.instance.InitGUIValues();
				goto case 2u;
			case 2u:
				if (DialogManager.instance.isSomeDialogShowed)
				{
					if (GuiElementSingle<WarningDialog>.instance.NPFFMLLLDAF() && Singleton<GuiManager>.instance.IsInputTurnedOffCompletly())
					{
						Singleton<GuiManager>.instance.AOGOJDGBMMD();
					}
					if (!GuiElementSingle<WarningDialog>.instance.isShowed && !Singleton<GuiManager>.instance.IsInputTurnedOffCompletly())
					{
						Singleton<GuiManager>.instance.TurnOffInputCompletly();
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				BJGCPDNMHDH.isNearEnd = true;
				if (!GameLoginManager.instance.CheckFacebookAfterTutorial())
				{
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BootcampCompletedScreen>.instance, 1425f);
					PHDOCKCBJOF = new WaitForSeconds(1132f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1468f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				break;
			case 3u:
				Singleton<GuiManager>.instance.TurnOnInputCompletly();
				goto case 4u;
			case 4u:
				if (GuiElementSingle<BootcampCompletedScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1319f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				break;
			case 5u:
			case 6u:
				if (DialogManager.instance.isSomeDialogShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				GameLoginManager.instance.AddOneTimeCallbackToShowGcChangeNameDialog();
				GameLoginManager.instance.AfterTutorialGCcheck();
				goto case 7u;
			case 7u:
				if (GameLoginManager.instance.changeGCAfterTutorialInProgress)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				GameLoginManager.instance.CheckGpgsAfterTutorial();
				goto IL_0294;
			case 8u:
				Singleton<GuiManager>.instance.TurnOnInputCompletly();
				goto IL_0294;
			default:
				{
					return false;
				}
				IL_0294:
				UnityEngine.Debug.Log("Buy_Player_Customizations_Warbucks");
				BJGCPDNMHDH.isTutorialRunning = false;
				Singleton<GameController>.instance.SwitchToSinglePlayer();
				GuiElementSingle<MenuHeader>.instance.InitGUIValues();
				GuiElementSingle<HeaderDogtagButton>.instance.InitGUIValues();
				GuiElementSingle<ChatGuiElement>.instance.UpdateButtonLook();
				TutorialManagerStage6.instance.RunTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
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
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Squad Card ID \"{0}\" is not pressent");
				LoadingDialog.FDBHFJFKALH(Localization.Localize("PlacementMatchesRequired"), true, true);
				Singleton<AtlasPreparer>.instance.JCEMPPLLEBM();
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1530f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<BeanstalkServerManager>.instance.TutorialEnded();
				GuiElementSingle<MenuHeader>.instance.InitGUIValues();
				goto case 2u;
			case 2u:
				if (DialogManager.instance.isSomeDialogShowed)
				{
					if (GuiElementSingle<WarningDialog>.instance.isShowed && Singleton<GuiManager>.instance.PBAEJPFBBFH())
					{
						Singleton<GuiManager>.instance.TurnOnInputCompletly();
					}
					if (!GuiElementSingle<WarningDialog>.instance.isShowed && !Singleton<GuiManager>.instance.IsInputTurnedOffCompletly())
					{
						Singleton<GuiManager>.instance.CMCCOCBIGBB();
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				BJGCPDNMHDH.isNearEnd = true;
				if (!GameLoginManager.instance.CheckFacebookAfterTutorial())
				{
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BootcampCompletedScreen>.instance, 942f);
					PHDOCKCBJOF = new WaitForSeconds(173f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(300f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				break;
			case 3u:
				Singleton<GuiManager>.instance.TurnOnInputCompletly();
				goto case 4u;
			case 4u:
				if (GuiElementSingle<BootcampCompletedScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(479f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
				}
				break;
			case 5u:
			case 6u:
				if (DialogManager.instance.isSomeDialogShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				GameLoginManager.instance.AddOneTimeCallbackToShowGcChangeNameDialog();
				GameLoginManager.instance.AfterTutorialGCcheck();
				goto case 7u;
			case 7u:
				if (GameLoginManager.instance.changeGCAfterTutorialInProgress)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				GameLoginManager.instance.CheckGpgsAfterTutorial();
				goto IL_0294;
			case 8u:
				Singleton<GuiManager>.instance.TurnOnInputCompletly();
				goto IL_0294;
			default:
				{
					return true;
				}
				IL_0294:
				UnityEngine.Debug.Log("212 MENU LEVEL UP SHOWN");
				BJGCPDNMHDH.isTutorialRunning = true;
				Singleton<GameController>.instance.SwitchToSinglePlayer();
				GuiElementSingle<MenuHeader>.instance.InitGUIValues();
				GuiElementSingle<HeaderDogtagButton>.instance.InitGUIValues();
				GuiElementSingle<ChatGuiElement>.instance.UpdateButtonLook();
				TutorialManagerStage6.instance.RunTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void FGLAPPKJHBK()
		{
			throw new NotSupportedException();
		}

		public void OGDMPCFMMML()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JDKFIHJHNJC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BNFADGLHBAH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CPAFPFPNDNO()
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
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("CardManagerData");
				LoadingDialog.ShowLoading(Localization.Localize("173432c2"), false, false, true);
				Singleton<AtlasPreparer>.instance.BLCCADCEEED();
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1753f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				Singleton<BeanstalkServerManager>.instance.TutorialEnded();
				GuiElementSingle<MenuHeader>.instance.InitGUIValues();
				goto case 2u;
			case 2u:
				if (DialogManager.instance.isSomeDialogShowed)
				{
					if (GuiElementSingle<WarningDialog>.instance.NPFFMLLLDAF() && Singleton<GuiManager>.instance.PBAEJPFBBFH())
					{
						Singleton<GuiManager>.instance.KAGEFJEJOKE();
					}
					if (!GuiElementSingle<WarningDialog>.instance.isShowed && !Singleton<GuiManager>.instance.PBAEJPFBBFH())
					{
						Singleton<GuiManager>.instance.CMCCOCBIGBB();
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				BJGCPDNMHDH.isNearEnd = false;
				if (!GameLoginManager.instance.CheckFacebookAfterTutorial())
				{
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BootcampCompletedScreen>.instance, 316f);
					PHDOCKCBJOF = new WaitForSeconds(1592f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(759f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				break;
			case 3u:
				Singleton<GuiManager>.instance.TurnOnInputCompletly();
				goto case 4u;
			case 4u:
				if (GuiElementSingle<BootcampCompletedScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1949f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				break;
			case 5u:
			case 6u:
				if (DialogManager.instance.isSomeDialogShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				GameLoginManager.instance.AddOneTimeCallbackToShowGcChangeNameDialog();
				GameLoginManager.instance.AfterTutorialGCcheck();
				goto case 7u;
			case 7u:
				if (GameLoginManager.instance.changeGCAfterTutorialInProgress)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				GameLoginManager.instance.CheckGpgsAfterTutorial();
				goto IL_0294;
			case 8u:
				Singleton<GuiManager>.instance.TurnOnInputCompletly();
				goto IL_0294;
			default:
				{
					return false;
				}
				IL_0294:
				UnityEngine.Debug.Log("Regions");
				BJGCPDNMHDH.isTutorialRunning = true;
				Singleton<GameController>.instance.CAOMINCKBBO();
				GuiElementSingle<MenuHeader>.instance.InitGUIValues();
				GuiElementSingle<HeaderDogtagButton>.instance.InitGUIValues();
				GuiElementSingle<ChatGuiElement>.instance.UpdateButtonLook();
				TutorialManagerStage6.instance.RunTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object JGKMCJOGEIH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AGANCOFPDCK()
		{
			return PHDOCKCBJOF;
		}

		public void CJLDNKALLLI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object LAENBDAPNJL()
		{
			return PHDOCKCBJOF;
		}

		public void FLCIMHOJPDF()
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
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("game-engi-progress-bg");
				LoadingDialog.FDBHFJFKALH(Localization.Localize(" BOXES "), false, true, true);
				Singleton<AtlasPreparer>.instance.BLCCADCEEED();
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1829f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				Singleton<BeanstalkServerManager>.instance.TutorialEnded();
				GuiElementSingle<MenuHeader>.instance.InitGUIValues();
				goto case 2u;
			case 2u:
				if (DialogManager.instance.isSomeDialogShowed)
				{
					if (GuiElementSingle<WarningDialog>.instance.isShowed && Singleton<GuiManager>.instance.PBAEJPFBBFH())
					{
						Singleton<GuiManager>.instance.TurnOnInputCompletly();
					}
					if (!GuiElementSingle<WarningDialog>.instance.isShowed && !Singleton<GuiManager>.instance.PBAEJPFBBFH())
					{
						Singleton<GuiManager>.instance.CMCCOCBIGBB();
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				BJGCPDNMHDH.isNearEnd = true;
				if (!GameLoginManager.instance.CheckFacebookAfterTutorial())
				{
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BootcampCompletedScreen>.instance, 420f);
					PHDOCKCBJOF = new WaitForSeconds(1769f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(637f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				break;
			case 3u:
				Singleton<GuiManager>.instance.KAGEFJEJOKE();
				goto case 4u;
			case 4u:
				if (GuiElementSingle<BootcampCompletedScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(355f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				break;
			case 5u:
			case 6u:
				if (DialogManager.instance.isSomeDialogShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				GameLoginManager.instance.AddOneTimeCallbackToShowGcChangeNameDialog();
				GameLoginManager.instance.AfterTutorialGCcheck();
				goto case 7u;
			case 7u:
				if (GameLoginManager.instance.changeGCAfterTutorialInProgress)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				GameLoginManager.instance.CheckGpgsAfterTutorial();
				goto IL_0294;
			case 8u:
				Singleton<GuiManager>.instance.KAGEFJEJOKE();
				goto IL_0294;
			default:
				{
					return false;
				}
				IL_0294:
				UnityEngine.Debug.Log("{0} {1} Button");
				BJGCPDNMHDH.isTutorialRunning = true;
				Singleton<GameController>.instance.CAOMINCKBBO();
				GuiElementSingle<MenuHeader>.instance.InitGUIValues();
				GuiElementSingle<HeaderDogtagButton>.instance.InitGUIValues();
				GuiElementSingle<ChatGuiElement>.instance.UpdateButtonLook();
				TutorialManagerStage6.instance.RunTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object JMKGAJNOLEM()
		{
			return PHDOCKCBJOF;
		}

		public bool NAMPBIHOFGI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("tc");
				LoadingDialog.PGFBMJFLHPC(Localization.Localize("MagazineSize"), false, false, true);
				Singleton<AtlasPreparer>.instance.IMKHDAHDLLI();
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(550f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<BeanstalkServerManager>.instance.TutorialEnded();
				GuiElementSingle<MenuHeader>.instance.InitGUIValues();
				goto case 2u;
			case 2u:
				if (DialogManager.instance.isSomeDialogShowed)
				{
					if (GuiElementSingle<WarningDialog>.instance.NPFFMLLLDAF() && Singleton<GuiManager>.instance.PBAEJPFBBFH())
					{
						Singleton<GuiManager>.instance.KAGEFJEJOKE();
					}
					if (!GuiElementSingle<WarningDialog>.instance.isShowed && !Singleton<GuiManager>.instance.PBAEJPFBBFH())
					{
						Singleton<GuiManager>.instance.CMCCOCBIGBB();
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				BJGCPDNMHDH.isNearEnd = false;
				if (!GameLoginManager.instance.CheckFacebookAfterTutorial())
				{
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BootcampCompletedScreen>.instance, 1488f);
					PHDOCKCBJOF = new WaitForSeconds(1916f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1057f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				break;
			case 3u:
				Singleton<GuiManager>.instance.TurnOnInputCompletly();
				goto case 4u;
			case 4u:
				if (GuiElementSingle<BootcampCompletedScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(375f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				break;
			case 5u:
			case 6u:
				if (DialogManager.instance.isSomeDialogShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				GameLoginManager.instance.AddOneTimeCallbackToShowGcChangeNameDialog();
				GameLoginManager.instance.AfterTutorialGCcheck();
				goto case 7u;
			case 7u:
				if (GameLoginManager.instance.changeGCAfterTutorialInProgress)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				GameLoginManager.instance.CheckGpgsAfterTutorial();
				goto IL_0294;
			case 8u:
				Singleton<GuiManager>.instance.KAGEFJEJOKE();
				goto IL_0294;
			default:
				{
					return true;
				}
				IL_0294:
				UnityEngine.Debug.Log("ID_YOUROPPONENT");
				BJGCPDNMHDH.isTutorialRunning = true;
				Singleton<GameController>.instance.SwitchToSinglePlayer();
				GuiElementSingle<MenuHeader>.instance.InitGUIValues();
				GuiElementSingle<HeaderDogtagButton>.instance.InitGUIValues();
				GuiElementSingle<ChatGuiElement>.instance.UpdateButtonLook();
				TutorialManagerStage6.instance.RunTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public bool CBGPIONEKLM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(" ID_");
				LoadingDialog.FDBHFJFKALH(Localization.Localize("withAttribute2"), false, true, true);
				Singleton<AtlasPreparer>.instance.IMKHDAHDLLI();
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1217f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<BeanstalkServerManager>.instance.TutorialEnded();
				GuiElementSingle<MenuHeader>.instance.InitGUIValues();
				goto case 2u;
			case 2u:
				if (DialogManager.instance.isSomeDialogShowed)
				{
					if (GuiElementSingle<WarningDialog>.instance.isShowed && Singleton<GuiManager>.instance.PBAEJPFBBFH())
					{
						Singleton<GuiManager>.instance.TurnOnInputCompletly();
					}
					if (!GuiElementSingle<WarningDialog>.instance.isShowed && !Singleton<GuiManager>.instance.PBAEJPFBBFH())
					{
						Singleton<GuiManager>.instance.TurnOffInputCompletly();
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				BJGCPDNMHDH.isNearEnd = false;
				if (!GameLoginManager.instance.CheckFacebookAfterTutorial())
				{
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BootcampCompletedScreen>.instance, 767f);
					PHDOCKCBJOF = new WaitForSeconds(78f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(40f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				break;
			case 3u:
				Singleton<GuiManager>.instance.TurnOnInputCompletly();
				goto case 4u;
			case 4u:
				if (GuiElementSingle<BootcampCompletedScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1250f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				break;
			case 5u:
			case 6u:
				if (DialogManager.instance.isSomeDialogShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				GameLoginManager.instance.AddOneTimeCallbackToShowGcChangeNameDialog();
				GameLoginManager.instance.AfterTutorialGCcheck();
				goto case 7u;
			case 7u:
				if (GameLoginManager.instance.changeGCAfterTutorialInProgress)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				GameLoginManager.instance.CheckGpgsAfterTutorial();
				goto IL_0294;
			case 8u:
				Singleton<GuiManager>.instance.TurnOnInputCompletly();
				goto IL_0294;
			default:
				{
					return true;
				}
				IL_0294:
				UnityEngine.Debug.Log("author");
				BJGCPDNMHDH.isTutorialRunning = false;
				Singleton<GameController>.instance.SwitchToSinglePlayer();
				GuiElementSingle<MenuHeader>.instance.InitGUIValues();
				GuiElementSingle<HeaderDogtagButton>.instance.InitGUIValues();
				GuiElementSingle<ChatGuiElement>.instance.UpdateButtonLook();
				TutorialManagerStage6.instance.RunTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		[SpecialName]
		private object LMJBCDNGAHP()
		{
			return PHDOCKCBJOF;
		}

		public void NDPOBCODJAI()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BLOJDIFOPIA()
		{
			return PHDOCKCBJOF;
		}

		public void NFAMBMLLFGP()
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
		private object HJHFKNCBGDG()
		{
			return PHDOCKCBJOF;
		}

		public void HJLCPFDBNKP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object PGMPMBFDAAC()
		{
			return PHDOCKCBJOF;
		}

		public void OEHJOBELOFF()
		{
			throw new NotSupportedException();
		}
	}

	private sealed class DHDAHKOFLGL : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal EnemyController KGGJOOAFDIF;

		internal PlayerController LHAAAIGMEBK;

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

		public void EMICCACCFIP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void IGBHHLFACKO()
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
			case 1u:
				if (KGGJOOAFDIF.isAlive)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				LHAAAIGMEBK = Singleton<GameController>.instance.opponent;
				LHAAAIGMEBK.KIIHLIPAGIH = false;
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

		public bool HOOHJGPHHGN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (KGGJOOAFDIF.isAlive)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				LHAAAIGMEBK = Singleton<GameController>.instance.opponent;
				LHAAAIGMEBK.KIIHLIPAGIH = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object NDIGINEEOMH()
		{
			return PHDOCKCBJOF;
		}

		public void ONGBFFAENBP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BNFADGLHBAH()
		{
			return PHDOCKCBJOF;
		}

		public void FJOIBBIGBJC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void PNGIELILHDI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public bool MOFPMNMAOND()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (KGGJOOAFDIF.isAlive)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				LHAAAIGMEBK = Singleton<GameController>.instance.opponent;
				LHAAAIGMEBK.KIIHLIPAGIH = true;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void AJEIGCJPEFN()
		{
			throw new NotSupportedException();
		}

		public bool DDLMLOJGJMA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (KGGJOOAFDIF.isAlive)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				LHAAAIGMEBK = Singleton<GameController>.instance.opponent;
				LHAAAIGMEBK.KIIHLIPAGIH = true;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void AKEKFBGEJBG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HHLKEMNNJDA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GJMNLPAEIDA()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public DHDAHKOFLGL()
		{
		}

		[SpecialName]
		private object KIHECHEHNJJ()
		{
			return PHDOCKCBJOF;
		}

		public void EPKPNKGJHEC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void IJHCIJLDKHK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object DGEECEBHPNC()
		{
			return PHDOCKCBJOF;
		}

		public void PHKDHCJBMII()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object CIGHIOCACPH()
		{
			return PHDOCKCBJOF;
		}
	}

	private sealed class JAAGHMKDIIA : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal List<MapDefinition.DefendPosition> KFPHCMGGAIJ;

		internal PlayerController LHAAAIGMEBK;

		internal PlayerBot PNBNBGCNMCF;

		internal List<SpawningManagerDeathMatch.ArmyUnitDefinition> ALEFMCLGCAP;

		internal List<SpawningManagerDeathMatch.ArmyUnitDefinition>.Enumerator KFCAECGLKKO;

		internal TutorialManagerStage3 BJGCPDNMHDH;

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
				UnityEngine.Debug.Log("ID_HEALTH");
				goto case 2u;
			case 2u:
			{
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("damage");
				KFPHCMGGAIJ = Singleton<MapManager>.instance.ALCHJDPKAID.DJGINOBOEPA();
				for (int i = 0; i < KFPHCMGGAIJ.Count; i += 0)
				{
					KFPHCMGGAIJ[i].point.LMHDAIBCLDP().maxHealth = 1089f;
					KFPHCMGGAIJ[i].point.KJCHIHLJMMF().OEAGCMGINCB();
				}
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 1737f;
				Singleton<SpawningManagerDeathMatch>.instance.KPGIELJBLEH(false);
				Singleton<SpawningManagerDeathMatch>.instance.HFLKFDEDGDG = 423f;
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf((GHPGNELIDBM)5);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 897f;
				LHAAAIGMEBK.FOCIOKMPCAG.APJEBOPJPLA();
				LHAAAIGMEBK.KIIHLIPAGIH = false;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.MBECPMJFIHB();
				PNBNBGCNMCF.PADBFAIBBDG = 8;
				PNBNBGCNMCF.MGECHKCAELH = false;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = false;
				goto case 3u;
			}
			case 3u:
				if (!Singleton<GameController>.instance.KKHKIEFMENC())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				PNBNBGCNMCF.FIODCBFFKAN(true);
				PHDOCKCBJOF = new WaitForSeconds(948f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 4u:
				ALEFMCLGCAP = Singleton<SpawningManagerDeathMatch>.instance.GPMINOBFHLG(new List<Tuple<int, int>>
				{
					new Tuple<int, int>(0, 0),
					new Tuple<int, int>(1, 0),
					new Tuple<int, int>(1, 1)
				});
				Singleton<SpawningManagerDeathMatch>.instance.BONPBCMFNHI(ALEFMCLGCAP);
				DeathMatchUnitsGuiElement.BLHCFKIELCA().Enable();
				Singleton<SpawningManagerDeathMatch>.instance.PGBMKIHFJML(BJGCPDNMHDH.InstanceOnArmyChangedFirst);
				DeathMatchUnitsGuiElement.BCDJJBAFLLG().MDBPINJMNKO.shouldUpdate = true;
				DeathMatchUnitsGuiElement.BLHCFKIELCA().MDBPINJMNKO.CLLJEINIGBL();
				Singleton<SpawningManagerDeathMatch>.instance.Enable();
				PHDOCKCBJOF = new WaitForSeconds(1768f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 5u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("game-card-ico-shieldsup");
				TimeManager.FODFANEEDFF();
				GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("_", "ID_LOGOUT", 1039f, TutorialDialog.DODBDLEJOAM.TopLeft, false, true);
				GuiElementSingle<TutorialDialog>.instance.AJJDDGAGKEI("StartOverTime_RPC", "\n\t");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = true;
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = false;
				goto case 6u;
			case 6u:
				if (!GuiElementSingle<TutorialDialog>.instance.GDAIHLIGAKP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				KFCAECGLKKO = Singleton<SpawningManagerDeathMatch>.instance.DPDIFLKIFJC.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SpawningManagerDeathMatch.ArmyUnitDefinition current = KFCAECGLKKO.Current;
						if (current.armyUnit.behaviour.unitType == LevelBehaviour.UnitType.Defender)
						{
							Singleton<SpawningManagerDeathMatch>.instance.PreGenerateRandomUnit(current);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("testingidsquadwarsend");
				Singleton<SpawningManagerDeathMatch>.instance.OLJIPPEIOBO(false);
				Singleton<SpawningManagerDeathMatch>.instance.ResetAutoDeployProgress();
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheckWithPause((float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldenSuitcaseAdCount).FLOATVALUE - 1100f)));
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = true;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = true;
				TimeManager.UnFreezeGame(1977f);
				PHDOCKCBJOF = new WaitForSeconds(1698f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 7u:
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.SpawnCheck(1925f));
				PHDOCKCBJOF = new WaitForSeconds(1646f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 8u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public bool HDGDKCMIOGK()
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
				UnityEngine.Debug.Log("Min_fps");
				goto case 2u;
			case 2u:
			{
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_DOUBLEGOLD");
				KFPHCMGGAIJ = Singleton<MapManager>.instance.ALCHJDPKAID.KLIMIPLCAIB();
				for (int i = 1; i < KFPHCMGGAIJ.Count; i += 0)
				{
					KFPHCMGGAIJ[i].point.PKBPGCGNCAD().maxHealth = 1171f;
					KFPHCMGGAIJ[i].point.LMHDAIBCLDP().OEAGCMGINCB();
				}
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 757f;
				Singleton<SpawningManagerDeathMatch>.instance.OLJIPPEIOBO(false);
				Singleton<SpawningManagerDeathMatch>.instance.HFLKFDEDGDG = 112f;
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf(GHPGNELIDBM.None);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 1134f;
				LHAAAIGMEBK.FOCIOKMPCAG.Refill();
				LHAAAIGMEBK.KIIHLIPAGIH = false;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.DMIECFDHMKN();
				PNBNBGCNMCF.PADBFAIBBDG = 1;
				PNBNBGCNMCF.MGECHKCAELH = false;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = false;
				goto case 3u;
			}
			case 3u:
				if (!Singleton<GameController>.instance.GHKPKDPOGHF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				PNBNBGCNMCF.OLDDFGBFMFK(true);
				PHDOCKCBJOF = new WaitForSeconds(1922f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 4u:
				ALEFMCLGCAP = Singleton<SpawningManagerDeathMatch>.instance.GetTutorial(new List<Tuple<int, int>>
				{
					new Tuple<int, int>(1, 1),
					new Tuple<int, int>(1, 0),
					new Tuple<int, int>(0, 1)
				});
				Singleton<SpawningManagerDeathMatch>.instance.BONPBCMFNHI(ALEFMCLGCAP);
				DeathMatchUnitsGuiElement.instance.Enable();
				Singleton<SpawningManagerDeathMatch>.instance.JNEGMAGNBJI(BJGCPDNMHDH.InstanceOnArmyChangedFirst);
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().MDBPINJMNKO.shouldUpdate = true;
				DeathMatchUnitsGuiElement.BCDJJBAFLLG().MDBPINJMNKO.CLLJEINIGBL();
				Singleton<SpawningManagerDeathMatch>.instance.Enable();
				PHDOCKCBJOF = new WaitForSeconds(231f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 5u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("right");
				TimeManager.DCODDANOPCP();
				GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("ID_TAKEMETHERE", "onFirstPlaylistDownloaded", 1786f, TutorialDialog.DODBDLEJOAM.Top);
				GuiElementSingle<TutorialDialog>.instance.FMPPLLLJIML("monthLenght", "NETWORK_ERROR");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = true;
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = true;
				goto case 6u;
			case 6u:
				if (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				KFCAECGLKKO = Singleton<SpawningManagerDeathMatch>.instance.DPDIFLKIFJC.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SpawningManagerDeathMatch.ArmyUnitDefinition current = KFCAECGLKKO.Current;
						if (current.armyUnit.behaviour.unitType == LevelBehaviour.UnitType.Defender)
						{
							Singleton<SpawningManagerDeathMatch>.instance.PreGenerateRandomUnit(current);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(" IN TUTORIAL");
				Singleton<SpawningManagerDeathMatch>.instance.OLJIPPEIOBO(true);
				Singleton<SpawningManagerDeathMatch>.instance.ResetAutoDeployProgress();
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheckWithPause((float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.MaxPingToConnectRegion).FLOATVALUE - 1724f)));
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = true;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = true;
				TimeManager.UnFreezeGame(531f);
				PHDOCKCBJOF = new WaitForSeconds(1133f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 7u:
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.SpawnCheck(1380f));
				PHDOCKCBJOF = new WaitForSeconds(458f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 8u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void JANIKOFKDCH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void GBGMIJNBLNH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool KKINHOPBKLH()
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
				UnityEngine.Debug.Log("SquadId");
				goto case 2u;
			case 2u:
			{
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(",  ");
				KFPHCMGGAIJ = Singleton<MapManager>.instance.ALCHJDPKAID.CJKAPGGJLLK();
				for (int i = 0; i < KFPHCMGGAIJ.Count; i += 0)
				{
					KFPHCMGGAIJ[i].point.CGKKGILAAPG().maxHealth = 1635f;
					KFPHCMGGAIJ[i].point.IGEDGCNJCAP().OEAGCMGINCB();
				}
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 1651f;
				Singleton<SpawningManagerDeathMatch>.instance.OLJIPPEIOBO(true);
				Singleton<SpawningManagerDeathMatch>.instance.HFLKFDEDGDG = 1149f;
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf(GHPGNELIDBM.Allies);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 309f;
				LHAAAIGMEBK.FOCIOKMPCAG.Refill();
				LHAAAIGMEBK.KIIHLIPAGIH = false;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.GetWeakBotConfig();
				PNBNBGCNMCF.PADBFAIBBDG = 5;
				PNBNBGCNMCF.MGECHKCAELH = true;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = false;
				goto case 3u;
			}
			case 3u:
				if (!Singleton<GameController>.instance.KKHKIEFMENC())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				PNBNBGCNMCF.ANMBBDFMCMJ(true);
				PHDOCKCBJOF = new WaitForSeconds(1966f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 4u:
				ALEFMCLGCAP = Singleton<SpawningManagerDeathMatch>.instance.GetTutorial(new List<Tuple<int, int>>
				{
					new Tuple<int, int>(0, 1),
					new Tuple<int, int>(0, 0),
					new Tuple<int, int>(0, 0)
				});
				Singleton<SpawningManagerDeathMatch>.instance.BONPBCMFNHI(ALEFMCLGCAP);
				DeathMatchUnitsGuiElement.BCDJJBAFLLG().Enable();
				Singleton<SpawningManagerDeathMatch>.instance.ArmyChanged += BJGCPDNMHDH.InstanceOnArmyChangedFirst;
				DeathMatchUnitsGuiElement.BLHCFKIELCA().MDBPINJMNKO.AHPJFHNNODC(false);
				DeathMatchUnitsGuiElement.BCDJJBAFLLG().MDBPINJMNKO.GAOCAKKOPMK();
				Singleton<SpawningManagerDeathMatch>.instance.Enable();
				PHDOCKCBJOF = new WaitForSeconds(1391f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 5u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Name");
				TimeManager.FODFANEEDFF();
				GuiElementSingle<TutorialDialog>.instance.BLHEPOBPHPK("WarBucks", " Waypoint Target", 1561f, TutorialDialog.DODBDLEJOAM.Right, false, true);
				GuiElementSingle<TutorialDialog>.instance.HBEKIOOJMPA("ID_READYTIME", "ShotFrequencyMax");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = false;
				goto case 6u;
			case 6u:
				if (!GuiElementSingle<TutorialDialog>.instance.GDAIHLIGAKP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				KFCAECGLKKO = Singleton<SpawningManagerDeathMatch>.instance.DPDIFLKIFJC.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SpawningManagerDeathMatch.ArmyUnitDefinition current = KFCAECGLKKO.Current;
						if (current.armyUnit.behaviour.unitType == LevelBehaviour.UnitType.Defender)
						{
							Singleton<SpawningManagerDeathMatch>.instance.PreGenerateRandomUnit(current);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ReSyncPowerRPC");
				Singleton<SpawningManagerDeathMatch>.instance.OLJIPPEIOBO(true);
				Singleton<SpawningManagerDeathMatch>.instance.ResetAutoDeployProgress();
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheckWithPause((float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-190)).FLOATVALUE - 821f)));
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = false;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = true;
				TimeManager.UnFreezeGame(1368f);
				PHDOCKCBJOF = new WaitForSeconds(1422f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 7u:
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.SpawnCheck(1733f));
				PHDOCKCBJOF = new WaitForSeconds(267f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 8u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void GOCCDFALOHI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void AKEKFBGEJBG()
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
				BJGCPDNMHDH.mGameStarted = true;
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				UnityEngine.Debug.Log("leagueMembers");
				goto case 2u;
			case 2u:
			{
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(",");
				KFPHCMGGAIJ = Singleton<MapManager>.instance.ALCHJDPKAID.MNKKJJADINL();
				for (int i = 0; i < KFPHCMGGAIJ.Count; i++)
				{
					KFPHCMGGAIJ[i].point.PKBPGCGNCAD().maxHealth = 148f;
					KFPHCMGGAIJ[i].point.PKBPGCGNCAD().Refill();
				}
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 1992f;
				Singleton<SpawningManagerDeathMatch>.instance.OLJIPPEIOBO(true);
				Singleton<SpawningManagerDeathMatch>.instance.HFLKFDEDGDG = 1386f;
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf((GHPGNELIDBM)3);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 870f;
				LHAAAIGMEBK.FOCIOKMPCAG.Refill();
				LHAAAIGMEBK.KIIHLIPAGIH = true;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.MBECPMJFIHB();
				PNBNBGCNMCF.PADBFAIBBDG = 8;
				PNBNBGCNMCF.MGECHKCAELH = true;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = false;
				goto case 3u;
			}
			case 3u:
				if (!Singleton<GameController>.instance.GHKPKDPOGHF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				PNBNBGCNMCF.FIODCBFFKAN(true);
				PHDOCKCBJOF = new WaitForSeconds(1395f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 4u:
				ALEFMCLGCAP = Singleton<SpawningManagerDeathMatch>.instance.GPMINOBFHLG(new List<Tuple<int, int>>
				{
					new Tuple<int, int>(0, 1),
					new Tuple<int, int>(0, 1),
					new Tuple<int, int>(1, 1)
				});
				Singleton<SpawningManagerDeathMatch>.instance.SetTutorialUnits(ALEFMCLGCAP);
				DeathMatchUnitsGuiElement.BLHCFKIELCA().Enable();
				Singleton<SpawningManagerDeathMatch>.instance.PGBMKIHFJML(BJGCPDNMHDH.InstanceOnArmyChangedFirst);
				DeathMatchUnitsGuiElement.instance.MDBPINJMNKO.GAODJMFOOHM(true);
				DeathMatchUnitsGuiElement.BLHCFKIELCA().MDBPINJMNKO.CLLJEINIGBL();
				Singleton<SpawningManagerDeathMatch>.instance.Enable();
				PHDOCKCBJOF = new WaitForSeconds(174f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 5u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("{0} {1}");
				TimeManager.FreezeGame();
				GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("{0} ({1})", "bronze", 377f, TutorialDialog.DODBDLEJOAM.Left, false, true);
				GuiElementSingle<TutorialDialog>.instance.HBEKIOOJMPA("BS: Remove Google Play", ")");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = false;
				goto case 6u;
			case 6u:
				if (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				KFCAECGLKKO = Singleton<SpawningManagerDeathMatch>.instance.DPDIFLKIFJC.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SpawningManagerDeathMatch.ArmyUnitDefinition current = KFCAECGLKKO.Current;
						if (current.armyUnit.behaviour.unitType == LevelBehaviour.UnitType.Defender)
						{
							Singleton<SpawningManagerDeathMatch>.instance.NANNKFNBFBK(current);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("menu-arena-lootbox-bronze");
				Singleton<SpawningManagerDeathMatch>.instance.autoDeployEnabled = false;
				Singleton<SpawningManagerDeathMatch>.instance.ResetAutoDeployProgress();
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheckWithPause((float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldenSuitcase_GoldRewardMax).FLOATVALUE - 823f)));
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = false;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
				TimeManager.UnFreezeGame(1699f);
				PHDOCKCBJOF = new WaitForSeconds(829f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 7u:
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.SpawnCheck(1773f));
				PHDOCKCBJOF = new WaitForSeconds(154f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 8u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public bool IDBCKIPOEEI()
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
				UnityEngine.Debug.Log("Gold:     {0}\n");
				goto case 2u;
			case 2u:
			{
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("{0}{1}{2}");
				KFPHCMGGAIJ = Singleton<MapManager>.instance.ALCHJDPKAID.JCPPFKEIAFM();
				for (int i = 1; i < KFPHCMGGAIJ.Count; i++)
				{
					KFPHCMGGAIJ[i].point.CGKKGILAAPG().maxHealth = 767f;
					KFPHCMGGAIJ[i].point.PNKKPNIMEPL().Refill();
				}
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 1433f;
				Singleton<SpawningManagerDeathMatch>.instance.KPGIELJBLEH(false);
				Singleton<SpawningManagerDeathMatch>.instance.HFLKFDEDGDG = 1087f;
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf(GHPGNELIDBM.None);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 400f;
				LHAAAIGMEBK.FOCIOKMPCAG.APJEBOPJPLA();
				LHAAAIGMEBK.KIIHLIPAGIH = true;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.GetWeakBotConfig();
				PNBNBGCNMCF.PADBFAIBBDG = 4;
				PNBNBGCNMCF.MGECHKCAELH = true;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = true;
				goto case 3u;
			}
			case 3u:
				if (!Singleton<GameController>.instance.KKHKIEFMENC())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				PNBNBGCNMCF.OLDDFGBFMFK(true);
				PHDOCKCBJOF = new WaitForSeconds(167f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 4u:
				ALEFMCLGCAP = Singleton<SpawningManagerDeathMatch>.instance.CEGAOAEOOBC(new List<Tuple<int, int>>
				{
					new Tuple<int, int>(0, 1),
					new Tuple<int, int>(1, 1),
					new Tuple<int, int>(1, 1)
				});
				Singleton<SpawningManagerDeathMatch>.instance.BONPBCMFNHI(ALEFMCLGCAP);
				DeathMatchUnitsGuiElement.BLHCFKIELCA().Enable();
				Singleton<SpawningManagerDeathMatch>.instance.PGBMKIHFJML(BJGCPDNMHDH.InstanceOnArmyChangedFirst);
				DeathMatchUnitsGuiElement.BLHCFKIELCA().MDBPINJMNKO.LIOJDDABNKO(false);
				DeathMatchUnitsGuiElement.BCDJJBAFLLG().MDBPINJMNKO.HDOFLJONIFH();
				Singleton<SpawningManagerDeathMatch>.instance.Enable();
				PHDOCKCBJOF = new WaitForSeconds(596f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 5u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("nd");
				TimeManager.FreezeGame();
				GuiElementSingle<TutorialDialog>.instance.DDFADDKPPDI("ID_HEROIC", "ID_OFFERACTIVE", 650f, TutorialDialog.DODBDLEJOAM.TopRight, true, true);
				GuiElementSingle<TutorialDialog>.instance.AJJDDGAGKEI("game-kill-environmental", "DogTagLastUpdate");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = false;
				goto case 6u;
			case 6u:
				if (!GuiElementSingle<TutorialDialog>.instance.GDAIHLIGAKP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				KFCAECGLKKO = Singleton<SpawningManagerDeathMatch>.instance.DPDIFLKIFJC.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SpawningManagerDeathMatch.ArmyUnitDefinition current = KFCAECGLKKO.Current;
						if (current.armyUnit.behaviour.unitType == LevelBehaviour.UnitType.Defender)
						{
							Singleton<SpawningManagerDeathMatch>.instance.NANNKFNBFBK(current);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_UNLOCKEDATRANKX");
				Singleton<SpawningManagerDeathMatch>.instance.KPGIELJBLEH(true);
				Singleton<SpawningManagerDeathMatch>.instance.MBKEOOJFOKP();
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheckWithPause((float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.ServerRentalMaxUnits).FLOATVALUE - 1886f)));
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = false;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = true;
				TimeManager.UnFreezeGame(351f);
				PHDOCKCBJOF = new WaitForSeconds(55f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 7u:
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.SpawnCheck(881f));
				PHDOCKCBJOF = new WaitForSeconds(842f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 8u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object JMKGAJNOLEM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MOMPOEEALPJ()
		{
			return PHDOCKCBJOF;
		}

		public void KNFDMCEJHLB()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GDCFFBBNGHH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IDLFKAKINAP()
		{
			return PHDOCKCBJOF;
		}

		public void KHMNEOBMJLN()
		{
			throw new NotSupportedException();
		}

		public void FDCPBGNCKHH()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KBPOAPCEPBN()
		{
			return PHDOCKCBJOF;
		}

		public void GICFBDJLDKF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void JKBIMBFGGCO()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JFEPOFBDLMB()
		{
			return PHDOCKCBJOF;
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
				BJGCPDNMHDH.mGameStarted = false;
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				UnityEngine.Debug.Log("*****   Bootcamp 3/3 Started   *****");
				goto case 2u;
			case 2u:
			{
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("302 GAME STARTED");
				KFPHCMGGAIJ = Singleton<MapManager>.instance.ALCHJDPKAID.availablePoints;
				for (int i = 0; i < KFPHCMGGAIJ.Count; i++)
				{
					KFPHCMGGAIJ[i].point.shield.maxHealth = 500f;
					KFPHCMGGAIJ[i].point.shield.Refill();
				}
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 0f;
				Singleton<SpawningManagerDeathMatch>.instance.autoDeployEnabled = false;
				Singleton<SpawningManagerDeathMatch>.instance.HFLKFDEDGDG = 2f;
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf(GHPGNELIDBM.Allies);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 125f;
				LHAAAIGMEBK.FOCIOKMPCAG.Refill();
				LHAAAIGMEBK.KIIHLIPAGIH = true;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.GetWeakBotConfig();
				PNBNBGCNMCF.PADBFAIBBDG = 6;
				PNBNBGCNMCF.MGECHKCAELH = false;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = true;
				goto case 3u;
			}
			case 3u:
				if (!Singleton<GameController>.instance.gameIsRunning)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				PNBNBGCNMCF.canSpawn = false;
				PHDOCKCBJOF = new WaitForSeconds(2f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 4u:
				ALEFMCLGCAP = Singleton<SpawningManagerDeathMatch>.instance.GetTutorial(new List<Tuple<int, int>>
				{
					new Tuple<int, int>(0, 1),
					new Tuple<int, int>(0, 1),
					new Tuple<int, int>(0, 1)
				});
				Singleton<SpawningManagerDeathMatch>.instance.SetTutorialUnits(ALEFMCLGCAP);
				DeathMatchUnitsGuiElement.instance.Enable();
				Singleton<SpawningManagerDeathMatch>.instance.ArmyChanged += BJGCPDNMHDH.InstanceOnArmyChangedFirst;
				DeathMatchUnitsGuiElement.instance.MDBPINJMNKO.shouldUpdate = true;
				DeathMatchUnitsGuiElement.instance.MDBPINJMNKO.InstantUpdate();
				Singleton<SpawningManagerDeathMatch>.instance.Enable();
				PHDOCKCBJOF = new WaitForSeconds(0.5f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 5u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("303 STAGE 9 STARTED");
				TimeManager.FreezeGame();
				GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("ID_TUTORIAL_START_PHASE2", "ID_TUTORIAL_START_PHASE2_DOWN", 0f, TutorialDialog.DODBDLEJOAM.Center, true);
				GuiElementSingle<TutorialDialog>.instance.SetSoldierSprite("game-tutorial-infantry", "menu-army-cat-defender");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = false;
				goto case 6u;
			case 6u:
				if (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				KFCAECGLKKO = Singleton<SpawningManagerDeathMatch>.instance.DPDIFLKIFJC.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SpawningManagerDeathMatch.ArmyUnitDefinition current = KFCAECGLKKO.Current;
						if (current.armyUnit.behaviour.unitType == LevelBehaviour.UnitType.Defender)
						{
							Singleton<SpawningManagerDeathMatch>.instance.PreGenerateRandomUnit(current);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("304 STAGE 9 CONTINUE");
				Singleton<SpawningManagerDeathMatch>.instance.autoDeployEnabled = true;
				Singleton<SpawningManagerDeathMatch>.instance.ResetAutoDeployProgress();
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheckWithPause((float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.FullAutoDeployTime).FLOATVALUE - 1f)));
				GuiElementSingle<TutorialDialog>.instance.Hide();
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = true;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = true;
				TimeManager.UnFreezeGame();
				PHDOCKCBJOF = new WaitForSeconds(1f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 7u:
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.SpawnCheck());
				PHDOCKCBJOF = new WaitForSeconds(9f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 8u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object KDLMIDIEPHD()
		{
			return PHDOCKCBJOF;
		}

		public void HNBFJFDLABI()
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
				BJGCPDNMHDH.mGameStarted = true;
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				UnityEngine.Debug.Log("There is NULL card in card manager -> cards");
				goto case 2u;
			case 2u:
			{
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("AssignmentData");
				KFPHCMGGAIJ = Singleton<MapManager>.instance.ALCHJDPKAID.KLIMIPLCAIB();
				for (int i = 1; i < KFPHCMGGAIJ.Count; i += 0)
				{
					KFPHCMGGAIJ[i].point.CGKKGILAAPG().maxHealth = 40f;
					KFPHCMGGAIJ[i].point.LMHDAIBCLDP().APJEBOPJPLA();
				}
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 350f;
				Singleton<SpawningManagerDeathMatch>.instance.autoDeployEnabled = true;
				Singleton<SpawningManagerDeathMatch>.instance.HFLKFDEDGDG = 1536f;
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf(GHPGNELIDBM.Enemies);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 628f;
				LHAAAIGMEBK.FOCIOKMPCAG.OEAGCMGINCB();
				LHAAAIGMEBK.KIIHLIPAGIH = true;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.GetWeakBotConfig();
				PNBNBGCNMCF.PADBFAIBBDG = 3;
				PNBNBGCNMCF.MGECHKCAELH = false;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = true;
				goto case 3u;
			}
			case 3u:
				if (!Singleton<GameController>.instance.KKHKIEFMENC())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				PNBNBGCNMCF.FIODCBFFKAN(true);
				PHDOCKCBJOF = new WaitForSeconds(576f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 4u:
				ALEFMCLGCAP = Singleton<SpawningManagerDeathMatch>.instance.GetTutorial(new List<Tuple<int, int>>
				{
					new Tuple<int, int>(1, 0),
					new Tuple<int, int>(0, 1),
					new Tuple<int, int>(0, 0)
				});
				Singleton<SpawningManagerDeathMatch>.instance.BONPBCMFNHI(ALEFMCLGCAP);
				DeathMatchUnitsGuiElement.BLHCFKIELCA().Enable();
				Singleton<SpawningManagerDeathMatch>.instance.JNEGMAGNBJI(BJGCPDNMHDH.InstanceOnArmyChangedFirst);
				DeathMatchUnitsGuiElement.instance.MDBPINJMNKO.GAODJMFOOHM(false);
				DeathMatchUnitsGuiElement.BCDJJBAFLLG().MDBPINJMNKO.KLPHMIGJLCG();
				Singleton<SpawningManagerDeathMatch>.instance.Enable();
				PHDOCKCBJOF = new WaitForSeconds(1681f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 5u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Gold_Balance");
				TimeManager.FODFANEEDFF();
				GuiElementSingle<TutorialDialog>.instance.DDFADDKPPDI("[]", "ID_RELOG_TO_FB_DIALOG_TITLE", 106f, TutorialDialog.DODBDLEJOAM.Top, true);
				GuiElementSingle<TutorialDialog>.instance.SetSoldierSprite("ID_OPPONENTREFUSEDTHEREMATCH", "B");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = false;
				goto case 6u;
			case 6u:
				if (!GuiElementSingle<TutorialDialog>.instance.GDAIHLIGAKP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				KFCAECGLKKO = Singleton<SpawningManagerDeathMatch>.instance.DPDIFLKIFJC.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SpawningManagerDeathMatch.ArmyUnitDefinition current = KFCAECGLKKO.Current;
						if (current.armyUnit.behaviour.unitType == LevelBehaviour.UnitType.Defender)
						{
							Singleton<SpawningManagerDeathMatch>.instance.PreGenerateRandomUnit(current);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_LOADING");
				Singleton<SpawningManagerDeathMatch>.instance.OLJIPPEIOBO(true);
				Singleton<SpawningManagerDeathMatch>.instance.MBKEOOJFOKP();
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheckWithPause((float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-119)).FLOATVALUE - 1538f)));
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = true;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
				TimeManager.UnFreezeGame(1144f);
				PHDOCKCBJOF = new WaitForSeconds(1205f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 7u:
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.SpawnCheck(981f));
				PHDOCKCBJOF = new WaitForSeconds(844f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 8u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object GKJIGGAAHBE()
		{
			return PHDOCKCBJOF;
		}

		public void MEBPMHDHIPJ()
		{
			throw new NotSupportedException();
		}

		public void MIFJOIIKFEB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
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
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				UnityEngine.Debug.Log("Generate army 3");
				goto case 2u;
			case 2u:
			{
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("CurrentTier");
				KFPHCMGGAIJ = Singleton<MapManager>.instance.ALCHJDPKAID.JCPPFKEIAFM();
				for (int i = 1; i < KFPHCMGGAIJ.Count; i += 0)
				{
					KFPHCMGGAIJ[i].point.PNKKPNIMEPL().maxHealth = 1245f;
					KFPHCMGGAIJ[i].point.IGEDGCNJCAP().OEAGCMGINCB();
				}
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 1138f;
				Singleton<SpawningManagerDeathMatch>.instance.KPGIELJBLEH(false);
				Singleton<SpawningManagerDeathMatch>.instance.HFLKFDEDGDG = 1073f;
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf((GHPGNELIDBM)3);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 202f;
				LHAAAIGMEBK.FOCIOKMPCAG.OEAGCMGINCB();
				LHAAAIGMEBK.KIIHLIPAGIH = false;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.MBECPMJFIHB();
				PNBNBGCNMCF.PADBFAIBBDG = 8;
				PNBNBGCNMCF.MGECHKCAELH = true;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = false;
				goto case 3u;
			}
			case 3u:
				if (!Singleton<GameController>.instance.gameIsRunning)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				PNBNBGCNMCF.BBAFFFOGING(false);
				PHDOCKCBJOF = new WaitForSeconds(1697f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 4u:
				ALEFMCLGCAP = Singleton<SpawningManagerDeathMatch>.instance.GetTutorial(new List<Tuple<int, int>>
				{
					new Tuple<int, int>(0, 0),
					new Tuple<int, int>(0, 1),
					new Tuple<int, int>(0, 0)
				});
				Singleton<SpawningManagerDeathMatch>.instance.SetTutorialUnits(ALEFMCLGCAP);
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().Enable();
				Singleton<SpawningManagerDeathMatch>.instance.PGBMKIHFJML(BJGCPDNMHDH.InstanceOnArmyChangedFirst);
				DeathMatchUnitsGuiElement.instance.MDBPINJMNKO.INGNIDHDLPD(false);
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().MDBPINJMNKO.MHGLNMLKENG();
				Singleton<SpawningManagerDeathMatch>.instance.Enable();
				PHDOCKCBJOF = new WaitForSeconds(1068f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 5u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Rules");
				TimeManager.FreezeGame();
				GuiElementSingle<TutorialDialog>.instance.DDFADDKPPDI("placement", "game-card-ico-headsup", 1242f, TutorialDialog.DODBDLEJOAM.Right, true);
				GuiElementSingle<TutorialDialog>.instance.FMPPLLLJIML("QA", "LandedNetwork");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = true;
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = false;
				goto case 6u;
			case 6u:
				if (!GuiElementSingle<TutorialDialog>.instance.GDAIHLIGAKP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				KFCAECGLKKO = Singleton<SpawningManagerDeathMatch>.instance.DPDIFLKIFJC.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SpawningManagerDeathMatch.ArmyUnitDefinition current = KFCAECGLKKO.Current;
						if (current.armyUnit.behaviour.unitType == LevelBehaviour.UnitType.Defender)
						{
							Singleton<SpawningManagerDeathMatch>.instance.NANNKFNBFBK(current);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("country-lithuania");
				Singleton<SpawningManagerDeathMatch>.instance.OLJIPPEIOBO(true);
				Singleton<SpawningManagerDeathMatch>.instance.MBKEOOJFOKP();
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheckWithPause((float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.PlayerExplosiveCoef).FLOATVALUE - 1756f)));
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = true;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
				TimeManager.UnFreezeGame(1004f);
				PHDOCKCBJOF = new WaitForSeconds(1311f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 7u:
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.SpawnCheck(901f));
				PHDOCKCBJOF = new WaitForSeconds(597f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 8u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
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
				BJGCPDNMHDH.mGameStarted = false;
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				UnityEngine.Debug.Log("{0} {1} {2} {3}");
				goto case 2u;
			case 2u:
			{
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ShootFromCrawl");
				KFPHCMGGAIJ = Singleton<MapManager>.instance.ALCHJDPKAID.DFFPKLEEKKK();
				for (int i = 0; i < KFPHCMGGAIJ.Count; i += 0)
				{
					KFPHCMGGAIJ[i].point.shield.maxHealth = 945f;
					KFPHCMGGAIJ[i].point.IGEDGCNJCAP().OEAGCMGINCB();
				}
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 1934f;
				Singleton<SpawningManagerDeathMatch>.instance.KPGIELJBLEH(true);
				Singleton<SpawningManagerDeathMatch>.instance.HFLKFDEDGDG = 1471f;
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf((GHPGNELIDBM)8);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 385f;
				LHAAAIGMEBK.FOCIOKMPCAG.APJEBOPJPLA();
				LHAAAIGMEBK.KIIHLIPAGIH = true;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.DMIECFDHMKN();
				PNBNBGCNMCF.PADBFAIBBDG = 3;
				PNBNBGCNMCF.MGECHKCAELH = true;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = false;
				goto case 3u;
			}
			case 3u:
				if (!Singleton<GameController>.instance.gameIsRunning)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				PNBNBGCNMCF.OLDDFGBFMFK(false);
				PHDOCKCBJOF = new WaitForSeconds(777f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 4u:
				ALEFMCLGCAP = Singleton<SpawningManagerDeathMatch>.instance.CEGAOAEOOBC(new List<Tuple<int, int>>
				{
					new Tuple<int, int>(1, 0),
					new Tuple<int, int>(1, 0),
					new Tuple<int, int>(1, 0)
				});
				Singleton<SpawningManagerDeathMatch>.instance.BONPBCMFNHI(ALEFMCLGCAP);
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().Enable();
				Singleton<SpawningManagerDeathMatch>.instance.ArmyChanged += BJGCPDNMHDH.InstanceOnArmyChangedFirst;
				DeathMatchUnitsGuiElement.BLHCFKIELCA().MDBPINJMNKO.shouldUpdate = false;
				DeathMatchUnitsGuiElement.BLHCFKIELCA().MDBPINJMNKO.KLPHMIGJLCG();
				Singleton<SpawningManagerDeathMatch>.instance.Enable();
				PHDOCKCBJOF = new WaitForSeconds(288f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 5u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ShootCopyRPC");
				TimeManager.FODFANEEDFF();
				GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("Password", "0", 431f, TutorialDialog.DODBDLEJOAM.Left, true, true);
				GuiElementSingle<TutorialDialog>.instance.FMPPLLLJIML("{0} {1}", " friends - global:");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = true;
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = true;
				goto case 6u;
			case 6u:
				if (!GuiElementSingle<TutorialDialog>.instance.GDAIHLIGAKP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				KFCAECGLKKO = Singleton<SpawningManagerDeathMatch>.instance.DPDIFLKIFJC.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SpawningManagerDeathMatch.ArmyUnitDefinition current = KFCAECGLKKO.Current;
						if (current.armyUnit.behaviour.unitType == LevelBehaviour.UnitType.Defender)
						{
							Singleton<SpawningManagerDeathMatch>.instance.PreGenerateRandomUnit(current);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_STAT_SNIPERRIFLEKILLS");
				Singleton<SpawningManagerDeathMatch>.instance.autoDeployEnabled = false;
				Singleton<SpawningManagerDeathMatch>.instance.ResetAutoDeployProgress();
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheckWithPause((float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-184)).FLOATVALUE - 527f)));
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = true;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
				TimeManager.UnFreezeGame(1154f);
				PHDOCKCBJOF = new WaitForSeconds(653f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 7u:
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.SpawnCheck(1570f));
				PHDOCKCBJOF = new WaitForSeconds(512f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 8u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void OGHELMDBPIL()
		{
			throw new NotSupportedException();
		}

		public void BCOIPCDCKEJ()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public JAAGHMKDIIA()
		{
		}

		[SpecialName]
		private object DBKMMECKKLG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ENKCCCABFFB()
		{
			return PHDOCKCBJOF;
		}

		public void EJADBNAIHEF()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void IGNIJGAPJOP()
		{
			throw new NotSupportedException();
		}

		public void ABOOMAKBEDI()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CIGHIOCACPH()
		{
			return PHDOCKCBJOF;
		}

		public void IOBGNBBJOLM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object NFJJHCBCIEM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IGMIIAODMNF()
		{
			return PHDOCKCBJOF;
		}

		public void LKACEPHEHPK()
		{
			throw new NotSupportedException();
		}

		public void JKOCLGOOBEK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void CDDFJOEEFID()
		{
			throw new NotSupportedException();
		}

		public void GBABLFGEIMF()
		{
			throw new NotSupportedException();
		}

		public void KCHOLCGBMBJ()
		{
			throw new NotSupportedException();
		}

		public void HOFJFOCEKJJ()
		{
			throw new NotSupportedException();
		}

		public void BLOCBAKBHBF()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HHMPMPLLJCC()
		{
			throw new NotSupportedException();
		}

		public bool JPAOKNLNFCB()
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
				UnityEngine.Debug.Log("PickDropPointRPC");
				goto case 2u;
			case 2u:
			{
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("These IDs have the same translations:\n");
				KFPHCMGGAIJ = Singleton<MapManager>.instance.ALCHJDPKAID.availablePoints;
				for (int i = 1; i < KFPHCMGGAIJ.Count; i += 0)
				{
					KFPHCMGGAIJ[i].point.PNKKPNIMEPL().maxHealth = 611f;
					KFPHCMGGAIJ[i].point.IGEDGCNJCAP().APJEBOPJPLA();
				}
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 931f;
				Singleton<SpawningManagerDeathMatch>.instance.autoDeployEnabled = false;
				Singleton<SpawningManagerDeathMatch>.instance.HFLKFDEDGDG = 1339f;
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf((GHPGNELIDBM)4);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 999f;
				LHAAAIGMEBK.FOCIOKMPCAG.OEAGCMGINCB();
				LHAAAIGMEBK.KIIHLIPAGIH = false;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.MBECPMJFIHB();
				PNBNBGCNMCF.PADBFAIBBDG = 6;
				PNBNBGCNMCF.MGECHKCAELH = true;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = true;
				goto case 3u;
			}
			case 3u:
				if (!Singleton<GameController>.instance.gameIsRunning)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				PNBNBGCNMCF.canSpawn = false;
				PHDOCKCBJOF = new WaitForSeconds(416f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 4u:
				ALEFMCLGCAP = Singleton<SpawningManagerDeathMatch>.instance.CEGAOAEOOBC(new List<Tuple<int, int>>
				{
					new Tuple<int, int>(1, 1),
					new Tuple<int, int>(1, 1),
					new Tuple<int, int>(1, 0)
				});
				Singleton<SpawningManagerDeathMatch>.instance.SetTutorialUnits(ALEFMCLGCAP);
				DeathMatchUnitsGuiElement.BCDJJBAFLLG().Enable();
				Singleton<SpawningManagerDeathMatch>.instance.ArmyChanged += BJGCPDNMHDH.InstanceOnArmyChangedFirst;
				DeathMatchUnitsGuiElement.BCDJJBAFLLG().MDBPINJMNKO.NHOKPBAKMKL(false);
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().MDBPINJMNKO.HDOFLJONIFH();
				Singleton<SpawningManagerDeathMatch>.instance.Enable();
				PHDOCKCBJOF = new WaitForSeconds(93f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 5u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Cache: Removing ");
				TimeManager.FODFANEEDFF();
				GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("ID_SELECTTWOUNITS", "Automatic_Equip", 917f, TutorialDialog.DODBDLEJOAM.Center, true, true);
				GuiElementSingle<TutorialDialog>.instance.SetSoldierSprite("can not find currency for: ", ", interval = ");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = false;
				goto case 6u;
			case 6u:
				if (!GuiElementSingle<TutorialDialog>.instance.GDAIHLIGAKP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				KFCAECGLKKO = Singleton<SpawningManagerDeathMatch>.instance.DPDIFLKIFJC.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SpawningManagerDeathMatch.ArmyUnitDefinition current = KFCAECGLKKO.Current;
						if (current.armyUnit.behaviour.unitType == LevelBehaviour.UnitType.Defender)
						{
							Singleton<SpawningManagerDeathMatch>.instance.PreGenerateRandomUnit(current);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("You probably assigned bad type of AmmoSetup to mine");
				Singleton<SpawningManagerDeathMatch>.instance.OLJIPPEIOBO(true);
				Singleton<SpawningManagerDeathMatch>.instance.MBKEOOJFOKP();
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheckWithPause((float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-125)).FLOATVALUE - 430f)));
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = false;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = true;
				TimeManager.UnFreezeGame(1837f);
				PHDOCKCBJOF = new WaitForSeconds(1278f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 7u:
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.SpawnCheck(270f));
				PHDOCKCBJOF = new WaitForSeconds(1119f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 8u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public bool LPMIKEPIMCM()
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
				UnityEngine.Debug.Log("BeginnersLeague");
				goto case 2u;
			case 2u:
			{
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Spend_Warbucks_On_Army");
				KFPHCMGGAIJ = Singleton<MapManager>.instance.ALCHJDPKAID.GDNIEHIBOFG();
				for (int i = 1; i < KFPHCMGGAIJ.Count; i += 0)
				{
					KFPHCMGGAIJ[i].point.LHHMNLJKOAO().maxHealth = 652f;
					KFPHCMGGAIJ[i].point.LHHMNLJKOAO().APJEBOPJPLA();
				}
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 803f;
				Singleton<SpawningManagerDeathMatch>.instance.autoDeployEnabled = false;
				Singleton<SpawningManagerDeathMatch>.instance.HFLKFDEDGDG = 814f;
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf((GHPGNELIDBM)5);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 1317f;
				LHAAAIGMEBK.FOCIOKMPCAG.APJEBOPJPLA();
				LHAAAIGMEBK.KIIHLIPAGIH = true;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.GetWeakBotConfig();
				PNBNBGCNMCF.PADBFAIBBDG = 5;
				PNBNBGCNMCF.MGECHKCAELH = false;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = true;
				goto case 3u;
			}
			case 3u:
				if (!Singleton<GameController>.instance.gameIsRunning)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				PNBNBGCNMCF.canSpawn = true;
				PHDOCKCBJOF = new WaitForSeconds(1693f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 4u:
				ALEFMCLGCAP = Singleton<SpawningManagerDeathMatch>.instance.CEGAOAEOOBC(new List<Tuple<int, int>>
				{
					new Tuple<int, int>(0, 0),
					new Tuple<int, int>(1, 1),
					new Tuple<int, int>(0, 0)
				});
				Singleton<SpawningManagerDeathMatch>.instance.SetTutorialUnits(ALEFMCLGCAP);
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().Enable();
				Singleton<SpawningManagerDeathMatch>.instance.JNEGMAGNBJI(BJGCPDNMHDH.InstanceOnArmyChangedFirst);
				DeathMatchUnitsGuiElement.BLHCFKIELCA().MDBPINJMNKO.NHOKPBAKMKL(true);
				DeathMatchUnitsGuiElement.BCDJJBAFLLG().MDBPINJMNKO.LIHDDPHJNOG();
				Singleton<SpawningManagerDeathMatch>.instance.Enable();
				PHDOCKCBJOF = new WaitForSeconds(293f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 5u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(" ");
				TimeManager.FreezeGame();
				GuiElementSingle<TutorialDialog>.instance.KOGOLIJLMDN("Action ", "#AccoutCheck# account exist", 1606f, TutorialDialog.DODBDLEJOAM.Top, true, true);
				GuiElementSingle<TutorialDialog>.instance.SetSoldierSprite("TEXTURE SIZE IS: ", "ID_EMPTYARENAHEROESPREVIOUS");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = true;
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = false;
				goto case 6u;
			case 6u:
				if (!GuiElementSingle<TutorialDialog>.instance.GDAIHLIGAKP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				KFCAECGLKKO = Singleton<SpawningManagerDeathMatch>.instance.DPDIFLKIFJC.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SpawningManagerDeathMatch.ArmyUnitDefinition current = KFCAECGLKKO.Current;
						if (current.armyUnit.behaviour.unitType == LevelBehaviour.UnitType.Defender)
						{
							Singleton<SpawningManagerDeathMatch>.instance.NANNKFNBFBK(current);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("game-card-ico-criticalinsurance");
				Singleton<SpawningManagerDeathMatch>.instance.OLJIPPEIOBO(false);
				Singleton<SpawningManagerDeathMatch>.instance.ResetAutoDeployProgress();
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheckWithPause((float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-165)).FLOATVALUE - 773f)));
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = false;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
				TimeManager.UnFreezeGame(474f);
				PHDOCKCBJOF = new WaitForSeconds(401f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 7u:
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.SpawnCheck(261f));
				PHDOCKCBJOF = new WaitForSeconds(1456f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 8u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void PPAIIDFNIDL()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Dispose()
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
				BJGCPDNMHDH.mGameStarted = true;
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				UnityEngine.Debug.Log("ID_UNITTYPE1-DESCRIPTION");
				goto case 2u;
			case 2u:
			{
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("#PHOTON# switching to TCP");
				KFPHCMGGAIJ = Singleton<MapManager>.instance.ALCHJDPKAID.KLIMIPLCAIB();
				for (int i = 0; i < KFPHCMGGAIJ.Count; i += 0)
				{
					KFPHCMGGAIJ[i].point.PHANADCNBFD().maxHealth = 1999f;
					KFPHCMGGAIJ[i].point.LHHMNLJKOAO().APJEBOPJPLA();
				}
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 901f;
				Singleton<SpawningManagerDeathMatch>.instance.autoDeployEnabled = false;
				Singleton<SpawningManagerDeathMatch>.instance.HFLKFDEDGDG = 498f;
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf((GHPGNELIDBM)8);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 915f;
				LHAAAIGMEBK.FOCIOKMPCAG.APJEBOPJPLA();
				LHAAAIGMEBK.KIIHLIPAGIH = true;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.DMIECFDHMKN();
				PNBNBGCNMCF.PADBFAIBBDG = 2;
				PNBNBGCNMCF.MGECHKCAELH = false;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = true;
				goto case 3u;
			}
			case 3u:
				if (!Singleton<GameController>.instance.gameIsRunning)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				PNBNBGCNMCF.OLDDFGBFMFK(false);
				PHDOCKCBJOF = new WaitForSeconds(475f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 4u:
				ALEFMCLGCAP = Singleton<SpawningManagerDeathMatch>.instance.GPMINOBFHLG(new List<Tuple<int, int>>
				{
					new Tuple<int, int>(0, 1),
					new Tuple<int, int>(1, 1),
					new Tuple<int, int>(0, 1)
				});
				Singleton<SpawningManagerDeathMatch>.instance.SetTutorialUnits(ALEFMCLGCAP);
				DeathMatchUnitsGuiElement.instance.Enable();
				Singleton<SpawningManagerDeathMatch>.instance.PGBMKIHFJML(BJGCPDNMHDH.InstanceOnArmyChangedFirst);
				DeathMatchUnitsGuiElement.BCDJJBAFLLG().MDBPINJMNKO.LIOJDDABNKO(false);
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().MDBPINJMNKO.HDOFLJONIFH();
				Singleton<SpawningManagerDeathMatch>.instance.Enable();
				PHDOCKCBJOF = new WaitForSeconds(1651f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 5u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Deadline");
				TimeManager.FODFANEEDFF();
				GuiElementSingle<TutorialDialog>.instance.KOGOLIJLMDN("clipSize", "Turret", 1729f, TutorialDialog.DODBDLEJOAM.Center, true, true);
				GuiElementSingle<TutorialDialog>.instance.FMPPLLLJIML("GameLauncher Async done", "getGameConfigurationKeys");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = true;
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = true;
				goto case 6u;
			case 6u:
				if (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				KFCAECGLKKO = Singleton<SpawningManagerDeathMatch>.instance.DPDIFLKIFJC.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SpawningManagerDeathMatch.ArmyUnitDefinition current = KFCAECGLKKO.Current;
						if (current.armyUnit.behaviour.unitType == LevelBehaviour.UnitType.Defender)
						{
							Singleton<SpawningManagerDeathMatch>.instance.PreGenerateRandomUnit(current);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Wrong_Category");
				Singleton<SpawningManagerDeathMatch>.instance.OLJIPPEIOBO(false);
				Singleton<SpawningManagerDeathMatch>.instance.ResetAutoDeployProgress();
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheckWithPause((float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-76)).FLOATVALUE - 816f)));
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = true;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
				TimeManager.UnFreezeGame(1322f);
				PHDOCKCBJOF = new WaitForSeconds(1852f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 7u:
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.SpawnCheck(308f));
				PHDOCKCBJOF = new WaitForSeconds(1605f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 8u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object AIDHNJCPDIJ()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MILFCGMBHIG()
		{
			return PHDOCKCBJOF;
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
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				UnityEngine.Debug.Log("ID_RENTAL_LMG");
				goto case 2u;
			case 2u:
			{
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("\t");
				KFPHCMGGAIJ = Singleton<MapManager>.instance.ALCHJDPKAID.OKBGNPFGPCD();
				for (int i = 1; i < KFPHCMGGAIJ.Count; i++)
				{
					KFPHCMGGAIJ[i].point.IGEDGCNJCAP().maxHealth = 338f;
					KFPHCMGGAIJ[i].point.PKBPGCGNCAD().OEAGCMGINCB();
				}
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 313f;
				Singleton<SpawningManagerDeathMatch>.instance.OLJIPPEIOBO(true);
				Singleton<SpawningManagerDeathMatch>.instance.HFLKFDEDGDG = 1764f;
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf(GHPGNELIDBM.Enemies);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 1341f;
				LHAAAIGMEBK.FOCIOKMPCAG.OEAGCMGINCB();
				LHAAAIGMEBK.KIIHLIPAGIH = false;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.MBECPMJFIHB();
				PNBNBGCNMCF.PADBFAIBBDG = 6;
				PNBNBGCNMCF.MGECHKCAELH = true;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = true;
				goto case 3u;
			}
			case 3u:
				if (!Singleton<GameController>.instance.KKHKIEFMENC())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				PNBNBGCNMCF.BBAFFFOGING(false);
				PHDOCKCBJOF = new WaitForSeconds(353f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 4u:
				ALEFMCLGCAP = Singleton<SpawningManagerDeathMatch>.instance.GPMINOBFHLG(new List<Tuple<int, int>>
				{
					new Tuple<int, int>(0, 0),
					new Tuple<int, int>(0, 1),
					new Tuple<int, int>(0, 1)
				});
				Singleton<SpawningManagerDeathMatch>.instance.BONPBCMFNHI(ALEFMCLGCAP);
				DeathMatchUnitsGuiElement.BLHCFKIELCA().Enable();
				Singleton<SpawningManagerDeathMatch>.instance.ArmyChanged += BJGCPDNMHDH.InstanceOnArmyChangedFirst;
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().MDBPINJMNKO.PFPLHOHDFFD(true);
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().MDBPINJMNKO.HFNPJIMLJNG();
				Singleton<SpawningManagerDeathMatch>.instance.Enable();
				PHDOCKCBJOF = new WaitForSeconds(993f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 5u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_TOBENUMBERONE2");
				TimeManager.FODFANEEDFF();
				GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("explodeDamage", "AssignmentsUpdate", 1309f, TutorialDialog.DODBDLEJOAM.Left);
				GuiElementSingle<TutorialDialog>.instance.AJJDDGAGKEI("http://www.about-fun.com/warfriends-mobcrush", "some_pub_sub3");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = true;
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = false;
				goto case 6u;
			case 6u:
				if (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				KFCAECGLKKO = Singleton<SpawningManagerDeathMatch>.instance.DPDIFLKIFJC.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SpawningManagerDeathMatch.ArmyUnitDefinition current = KFCAECGLKKO.Current;
						if (current.armyUnit.behaviour.unitType == LevelBehaviour.UnitType.Defender)
						{
							Singleton<SpawningManagerDeathMatch>.instance.NANNKFNBFBK(current);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_CONFIRM_LOGGEDOUT");
				Singleton<SpawningManagerDeathMatch>.instance.KPGIELJBLEH(false);
				Singleton<SpawningManagerDeathMatch>.instance.MBKEOOJFOKP();
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheckWithPause((float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.ServerRentalWeaponProbability).FLOATVALUE - 1181f)));
				GuiElementSingle<TutorialDialog>.instance.Hide();
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = false;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
				TimeManager.UnFreezeGame(1273f);
				PHDOCKCBJOF = new WaitForSeconds(405f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 7u:
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.SpawnCheck(790f));
				PHDOCKCBJOF = new WaitForSeconds(346f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 8u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object HHLKEMNNJDA()
		{
			return PHDOCKCBJOF;
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
				UnityEngine.Debug.Log("WarCards");
				goto case 2u;
			case 2u:
			{
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("S");
				KFPHCMGGAIJ = Singleton<MapManager>.instance.ALCHJDPKAID.GDNIEHIBOFG();
				for (int i = 0; i < KFPHCMGGAIJ.Count; i += 0)
				{
					KFPHCMGGAIJ[i].point.LMHDAIBCLDP().maxHealth = 833f;
					KFPHCMGGAIJ[i].point.PKBPGCGNCAD().APJEBOPJPLA();
				}
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 1371f;
				Singleton<SpawningManagerDeathMatch>.instance.OLJIPPEIOBO(false);
				Singleton<SpawningManagerDeathMatch>.instance.HFLKFDEDGDG = 763f;
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf((GHPGNELIDBM)8);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 1573f;
				LHAAAIGMEBK.FOCIOKMPCAG.OEAGCMGINCB();
				LHAAAIGMEBK.KIIHLIPAGIH = false;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.DMIECFDHMKN();
				PNBNBGCNMCF.PADBFAIBBDG = 7;
				PNBNBGCNMCF.MGECHKCAELH = true;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = true;
				goto case 3u;
			}
			case 3u:
				if (!Singleton<GameController>.instance.gameIsRunning)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				PNBNBGCNMCF.canSpawn = true;
				PHDOCKCBJOF = new WaitForSeconds(155f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 4u:
				ALEFMCLGCAP = Singleton<SpawningManagerDeathMatch>.instance.GetTutorial(new List<Tuple<int, int>>
				{
					new Tuple<int, int>(0, 1),
					new Tuple<int, int>(1, 0),
					new Tuple<int, int>(0, 0)
				});
				Singleton<SpawningManagerDeathMatch>.instance.BONPBCMFNHI(ALEFMCLGCAP);
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().Enable();
				Singleton<SpawningManagerDeathMatch>.instance.ArmyChanged += BJGCPDNMHDH.InstanceOnArmyChangedFirst;
				DeathMatchUnitsGuiElement.BCDJJBAFLLG().MDBPINJMNKO.PJFDIEGEGAC(false);
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().MDBPINJMNKO.AEKAOMNLMBL();
				Singleton<SpawningManagerDeathMatch>.instance.Enable();
				PHDOCKCBJOF = new WaitForSeconds(393f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 5u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("com/google/android/gms/games/Games");
				TimeManager.DCODDANOPCP();
				GuiElementSingle<TutorialDialog>.instance.BLHEPOBPHPK("ExtraHeart", "SHOW WAR ARENA DIALOG!!", 974f, TutorialDialog.DODBDLEJOAM.Bottom, true, true);
				GuiElementSingle<TutorialDialog>.instance.SetSoldierSprite("EnteredLeague", "ID_SLOTUPGRADE_DAMAGE");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = true;
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = false;
				goto case 6u;
			case 6u:
				if (!GuiElementSingle<TutorialDialog>.instance.GDAIHLIGAKP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				KFCAECGLKKO = Singleton<SpawningManagerDeathMatch>.instance.DPDIFLKIFJC.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SpawningManagerDeathMatch.ArmyUnitDefinition current = KFCAECGLKKO.Current;
						if (current.armyUnit.behaviour.unitType == LevelBehaviour.UnitType.Defender)
						{
							Singleton<SpawningManagerDeathMatch>.instance.PreGenerateRandomUnit(current);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Cards choosen ");
				Singleton<SpawningManagerDeathMatch>.instance.OLJIPPEIOBO(true);
				Singleton<SpawningManagerDeathMatch>.instance.ResetAutoDeployProgress();
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheckWithPause((float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-54)).FLOATVALUE - 1319f)));
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = true;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = true;
				TimeManager.UnFreezeGame(272f);
				PHDOCKCBJOF = new WaitForSeconds(1045f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 7u:
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.SpawnCheck(379f));
				PHDOCKCBJOF = new WaitForSeconds(498f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 8u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void PAODBOEOFNF()
		{
			throw new NotSupportedException();
		}

		public bool MOFPMNMAOND()
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
				UnityEngine.Debug.Log("author");
				goto case 2u;
			case 2u:
			{
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Medals/");
				KFPHCMGGAIJ = Singleton<MapManager>.instance.ALCHJDPKAID.JCAHHLHKIBN();
				for (int i = 0; i < KFPHCMGGAIJ.Count; i++)
				{
					KFPHCMGGAIJ[i].point.LMHDAIBCLDP().maxHealth = 885f;
					KFPHCMGGAIJ[i].point.PKBPGCGNCAD().APJEBOPJPLA();
				}
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 1002f;
				Singleton<SpawningManagerDeathMatch>.instance.OLJIPPEIOBO(false);
				Singleton<SpawningManagerDeathMatch>.instance.HFLKFDEDGDG = 527f;
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf(GHPGNELIDBM.None);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 1564f;
				LHAAAIGMEBK.FOCIOKMPCAG.APJEBOPJPLA();
				LHAAAIGMEBK.KIIHLIPAGIH = true;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.DMIECFDHMKN();
				PNBNBGCNMCF.PADBFAIBBDG = 0;
				PNBNBGCNMCF.MGECHKCAELH = true;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = false;
				goto case 3u;
			}
			case 3u:
				if (!Singleton<GameController>.instance.gameIsRunning)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				PNBNBGCNMCF.ANMBBDFMCMJ(true);
				PHDOCKCBJOF = new WaitForSeconds(141f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 4u:
				ALEFMCLGCAP = Singleton<SpawningManagerDeathMatch>.instance.GPMINOBFHLG(new List<Tuple<int, int>>
				{
					new Tuple<int, int>(1, 1),
					new Tuple<int, int>(1, 0),
					new Tuple<int, int>(0, 1)
				});
				Singleton<SpawningManagerDeathMatch>.instance.SetTutorialUnits(ALEFMCLGCAP);
				DeathMatchUnitsGuiElement.BLHCFKIELCA().Enable();
				Singleton<SpawningManagerDeathMatch>.instance.PGBMKIHFJML(BJGCPDNMHDH.InstanceOnArmyChangedFirst);
				DeathMatchUnitsGuiElement.BLHCFKIELCA().MDBPINJMNKO.PFPLHOHDFFD(true);
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().MDBPINJMNKO.LIHDDPHJNOG();
				Singleton<SpawningManagerDeathMatch>.instance.Enable();
				PHDOCKCBJOF = new WaitForSeconds(1471f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 5u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("AdminName");
				TimeManager.DCODDANOPCP();
				GuiElementSingle<TutorialDialog>.instance.BLHEPOBPHPK("UpdateIndicatorRPC", "x", 1375f, TutorialDialog.DODBDLEJOAM.TopRight, false, true);
				GuiElementSingle<TutorialDialog>.instance.FMPPLLLJIML("Area", "Buy_Rental_Army_Unit_Gold");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = true;
				goto case 6u;
			case 6u:
				if (!GuiElementSingle<TutorialDialog>.instance.GDAIHLIGAKP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				KFCAECGLKKO = Singleton<SpawningManagerDeathMatch>.instance.DPDIFLKIFJC.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SpawningManagerDeathMatch.ArmyUnitDefinition current = KFCAECGLKKO.Current;
						if (current.armyUnit.behaviour.unitType == LevelBehaviour.UnitType.Defender)
						{
							Singleton<SpawningManagerDeathMatch>.instance.PreGenerateRandomUnit(current);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_ARENALOOTBOXTICKETS");
				Singleton<SpawningManagerDeathMatch>.instance.autoDeployEnabled = false;
				Singleton<SpawningManagerDeathMatch>.instance.ResetAutoDeployProgress();
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheckWithPause((float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.WinstreakReward8).FLOATVALUE - 1483f)));
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = false;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
				TimeManager.UnFreezeGame(199f);
				PHDOCKCBJOF = new WaitForSeconds(1084f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 7u:
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.SpawnCheck(196f));
				PHDOCKCBJOF = new WaitForSeconds(1657f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 8u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void HJLCPFDBNKP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void IBDAHMOEBCM()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object NOIDHHDEEPL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MCCMIANNJAN()
		{
			return PHDOCKCBJOF;
		}

		public void POAFKMGKBLJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object LFEJDKIGHMI()
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
				BJGCPDNMHDH.mGameStarted = true;
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				UnityEngine.Debug.Log("ACD: Player prefs were hacked!");
				goto case 2u;
			case 2u:
			{
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ItemRarity_0");
				KFPHCMGGAIJ = Singleton<MapManager>.instance.ALCHJDPKAID.availablePoints;
				for (int i = 1; i < KFPHCMGGAIJ.Count; i++)
				{
					KFPHCMGGAIJ[i].point.IGEDGCNJCAP().maxHealth = 216f;
					KFPHCMGGAIJ[i].point.LHHMNLJKOAO().APJEBOPJPLA();
				}
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 814f;
				Singleton<SpawningManagerDeathMatch>.instance.OLJIPPEIOBO(true);
				Singleton<SpawningManagerDeathMatch>.instance.HFLKFDEDGDG = 1729f;
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf(GHPGNELIDBM.None);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 898f;
				LHAAAIGMEBK.FOCIOKMPCAG.OEAGCMGINCB();
				LHAAAIGMEBK.KIIHLIPAGIH = false;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.MBECPMJFIHB();
				PNBNBGCNMCF.PADBFAIBBDG = 1;
				PNBNBGCNMCF.MGECHKCAELH = true;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = false;
				goto case 3u;
			}
			case 3u:
				if (!Singleton<GameController>.instance.KKHKIEFMENC())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				PNBNBGCNMCF.canSpawn = true;
				PHDOCKCBJOF = new WaitForSeconds(1472f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 4u:
				ALEFMCLGCAP = Singleton<SpawningManagerDeathMatch>.instance.CEGAOAEOOBC(new List<Tuple<int, int>>
				{
					new Tuple<int, int>(0, 1),
					new Tuple<int, int>(0, 1),
					new Tuple<int, int>(0, 1)
				});
				Singleton<SpawningManagerDeathMatch>.instance.BONPBCMFNHI(ALEFMCLGCAP);
				DeathMatchUnitsGuiElement.BCDJJBAFLLG().Enable();
				Singleton<SpawningManagerDeathMatch>.instance.JNEGMAGNBJI(BJGCPDNMHDH.InstanceOnArmyChangedFirst);
				DeathMatchUnitsGuiElement.BCDJJBAFLLG().MDBPINJMNKO.BDHPCMOGAHF(false);
				DeathMatchUnitsGuiElement.BLHCFKIELCA().MDBPINJMNKO.HDOFLJONIFH();
				Singleton<SpawningManagerDeathMatch>.instance.Enable();
				PHDOCKCBJOF = new WaitForSeconds(1739f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 5u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Overtime_Was_Already_Explained");
				TimeManager.DCODDANOPCP();
				GuiElementSingle<TutorialDialog>.instance.BLHEPOBPHPK("_MIN_", "AccountType", 675f, TutorialDialog.DODBDLEJOAM.BottomLeft, true, true);
				GuiElementSingle<TutorialDialog>.instance.HBEKIOOJMPA("Gold", "ID_FACEBOOKLOGOUTLEGALTEXT2");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = true;
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = true;
				goto case 6u;
			case 6u:
				if (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				KFCAECGLKKO = Singleton<SpawningManagerDeathMatch>.instance.DPDIFLKIFJC.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SpawningManagerDeathMatch.ArmyUnitDefinition current = KFCAECGLKKO.Current;
						if (current.armyUnit.behaviour.unitType == LevelBehaviour.UnitType.Defender)
						{
							Singleton<SpawningManagerDeathMatch>.instance.PreGenerateRandomUnit(current);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(" was activated (through fast activation).");
				Singleton<SpawningManagerDeathMatch>.instance.OLJIPPEIOBO(false);
				Singleton<SpawningManagerDeathMatch>.instance.MBKEOOJFOKP();
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheckWithPause((float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.GoldCardRarity).FLOATVALUE - 1605f)));
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = false;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = true;
				TimeManager.UnFreezeGame(842f);
				PHDOCKCBJOF = new WaitForSeconds(87f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 7u:
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.SpawnCheck(969f));
				PHDOCKCBJOF = new WaitForSeconds(1154f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 8u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void MIEFKIEABBN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool EKGEDEKHBME()
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
				UnityEngine.Debug.Log(" OK!");
				goto case 2u;
			case 2u:
			{
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_FRIENDPAUSED");
				KFPHCMGGAIJ = Singleton<MapManager>.instance.ALCHJDPKAID.MIIAMFDOKIP();
				for (int i = 1; i < KFPHCMGGAIJ.Count; i++)
				{
					KFPHCMGGAIJ[i].point.LMHDAIBCLDP().maxHealth = 558f;
					KFPHCMGGAIJ[i].point.PKBPGCGNCAD().APJEBOPJPLA();
				}
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 947f;
				Singleton<SpawningManagerDeathMatch>.instance.KPGIELJBLEH(true);
				Singleton<SpawningManagerDeathMatch>.instance.HFLKFDEDGDG = 1115f;
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf((GHPGNELIDBM)4);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 18f;
				LHAAAIGMEBK.FOCIOKMPCAG.APJEBOPJPLA();
				LHAAAIGMEBK.KIIHLIPAGIH = false;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.MBECPMJFIHB();
				PNBNBGCNMCF.PADBFAIBBDG = 7;
				PNBNBGCNMCF.MGECHKCAELH = false;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = true;
				goto case 3u;
			}
			case 3u:
				if (!Singleton<GameController>.instance.KKHKIEFMENC())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				PNBNBGCNMCF.KLLJIBDDKHB(false);
				PHDOCKCBJOF = new WaitForSeconds(252f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 4u:
				ALEFMCLGCAP = Singleton<SpawningManagerDeathMatch>.instance.CEGAOAEOOBC(new List<Tuple<int, int>>
				{
					new Tuple<int, int>(1, 0),
					new Tuple<int, int>(1, 1),
					new Tuple<int, int>(1, 1)
				});
				Singleton<SpawningManagerDeathMatch>.instance.SetTutorialUnits(ALEFMCLGCAP);
				DeathMatchUnitsGuiElement.instance.Enable();
				Singleton<SpawningManagerDeathMatch>.instance.PGBMKIHFJML(BJGCPDNMHDH.InstanceOnArmyChangedFirst);
				DeathMatchUnitsGuiElement.BCDJJBAFLLG().MDBPINJMNKO.LIOJDDABNKO(false);
				DeathMatchUnitsGuiElement.BLHCFKIELCA().MDBPINJMNKO.DKPLBHODAAF();
				Singleton<SpawningManagerDeathMatch>.instance.Enable();
				PHDOCKCBJOF = new WaitForSeconds(1587f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 5u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("MatchStart");
				TimeManager.FreezeGame();
				GuiElementSingle<TutorialDialog>.instance.DDFADDKPPDI("MedalsBalance", "ID_CONFIRM_GAMELAREADYENDED", 568f, TutorialDialog.DODBDLEJOAM.Left);
				GuiElementSingle<TutorialDialog>.instance.FMPPLLLJIML("Wave", "GameLoginManager: Logout from facebook");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = false;
				goto case 6u;
			case 6u:
				if (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				KFCAECGLKKO = Singleton<SpawningManagerDeathMatch>.instance.DPDIFLKIFJC.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SpawningManagerDeathMatch.ArmyUnitDefinition current = KFCAECGLKKO.Current;
						if (current.armyUnit.behaviour.unitType == LevelBehaviour.UnitType.Defender)
						{
							Singleton<SpawningManagerDeathMatch>.instance.PreGenerateRandomUnit(current);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_ARENARULES_UNITCOST");
				Singleton<SpawningManagerDeathMatch>.instance.OLJIPPEIOBO(false);
				Singleton<SpawningManagerDeathMatch>.instance.MBKEOOJFOKP();
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheckWithPause((float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-187)).FLOATVALUE - 536f)));
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = false;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
				TimeManager.UnFreezeGame(1937f);
				PHDOCKCBJOF = new WaitForSeconds(1190f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 7u:
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.SpawnCheck(908f));
				PHDOCKCBJOF = new WaitForSeconds(1862f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 8u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void OJDEHKDDLFD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void BICMFOEHHGN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void DNNJONPPIED()
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
				BJGCPDNMHDH.mGameStarted = false;
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				UnityEngine.Debug.Log("[0-9.,]*");
				goto case 2u;
			case 2u:
			{
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Get player data: I WILL TRY TO SEND PN DEVICE TOKEN");
				KFPHCMGGAIJ = Singleton<MapManager>.instance.ALCHJDPKAID.DGHFCDMHBIM();
				for (int i = 1; i < KFPHCMGGAIJ.Count; i += 0)
				{
					KFPHCMGGAIJ[i].point.PNKKPNIMEPL().maxHealth = 721f;
					KFPHCMGGAIJ[i].point.PHANADCNBFD().OEAGCMGINCB();
				}
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 1272f;
				Singleton<SpawningManagerDeathMatch>.instance.autoDeployEnabled = false;
				Singleton<SpawningManagerDeathMatch>.instance.HFLKFDEDGDG = 1049f;
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf((GHPGNELIDBM)5);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 123f;
				LHAAAIGMEBK.FOCIOKMPCAG.APJEBOPJPLA();
				LHAAAIGMEBK.KIIHLIPAGIH = true;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.GetWeakBotConfig();
				PNBNBGCNMCF.PADBFAIBBDG = 3;
				PNBNBGCNMCF.MGECHKCAELH = false;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = false;
				goto case 3u;
			}
			case 3u:
				if (!Singleton<GameController>.instance.KKHKIEFMENC())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				PNBNBGCNMCF.ANMBBDFMCMJ(true);
				PHDOCKCBJOF = new WaitForSeconds(883f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 4u:
				ALEFMCLGCAP = Singleton<SpawningManagerDeathMatch>.instance.GetTutorial(new List<Tuple<int, int>>
				{
					new Tuple<int, int>(0, 1),
					new Tuple<int, int>(1, 0),
					new Tuple<int, int>(1, 0)
				});
				Singleton<SpawningManagerDeathMatch>.instance.SetTutorialUnits(ALEFMCLGCAP);
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().Enable();
				Singleton<SpawningManagerDeathMatch>.instance.ArmyChanged += BJGCPDNMHDH.InstanceOnArmyChangedFirst;
				DeathMatchUnitsGuiElement.BCDJJBAFLLG().MDBPINJMNKO.shouldUpdate = false;
				DeathMatchUnitsGuiElement.instance.MDBPINJMNKO.AEKAOMNLMBL();
				Singleton<SpawningManagerDeathMatch>.instance.Enable();
				PHDOCKCBJOF = new WaitForSeconds(420f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 5u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_LOADING");
				TimeManager.FreezeGame();
				GuiElementSingle<TutorialDialog>.instance.DDFADDKPPDI("Army upgrade for ", "ID_WAITINGFORFRIENDCARDS", 315f, TutorialDialog.DODBDLEJOAM.TopLeft, true);
				GuiElementSingle<TutorialDialog>.instance.SetSoldierSprite("Player_Level", " (#");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = false;
				goto case 6u;
			case 6u:
				if (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				KFCAECGLKKO = Singleton<SpawningManagerDeathMatch>.instance.DPDIFLKIFJC.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SpawningManagerDeathMatch.ArmyUnitDefinition current = KFCAECGLKKO.Current;
						if (current.armyUnit.behaviour.unitType == LevelBehaviour.UnitType.Defender)
						{
							Singleton<SpawningManagerDeathMatch>.instance.PreGenerateRandomUnit(current);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_ARENARULES_EXPLOSIVESPROHIBITED");
				Singleton<SpawningManagerDeathMatch>.instance.OLJIPPEIOBO(false);
				Singleton<SpawningManagerDeathMatch>.instance.ResetAutoDeployProgress();
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheckWithPause((float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-111)).FLOATVALUE - 1944f)));
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = true;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
				TimeManager.UnFreezeGame(223f);
				PHDOCKCBJOF = new WaitForSeconds(1643f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 7u:
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.SpawnCheck(559f));
				PHDOCKCBJOF = new WaitForSeconds(862f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 8u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public bool HMLAEHJKPJE()
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
				UnityEngine.Debug.Log("country-austria");
				goto case 2u;
			case 2u:
			{
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(" {0}\u00a0{1}");
				KFPHCMGGAIJ = Singleton<MapManager>.instance.ALCHJDPKAID.ADKJKHAHCJD();
				for (int i = 0; i < KFPHCMGGAIJ.Count; i += 0)
				{
					KFPHCMGGAIJ[i].point.shield.maxHealth = 343f;
					KFPHCMGGAIJ[i].point.LHHMNLJKOAO().Refill();
				}
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 101f;
				Singleton<SpawningManagerDeathMatch>.instance.OLJIPPEIOBO(true);
				Singleton<SpawningManagerDeathMatch>.instance.HFLKFDEDGDG = 7f;
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf(GHPGNELIDBM.None);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 394f;
				LHAAAIGMEBK.FOCIOKMPCAG.OEAGCMGINCB();
				LHAAAIGMEBK.KIIHLIPAGIH = false;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.MBECPMJFIHB();
				PNBNBGCNMCF.PADBFAIBBDG = 4;
				PNBNBGCNMCF.MGECHKCAELH = false;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = false;
				goto case 3u;
			}
			case 3u:
				if (!Singleton<GameController>.instance.GHKPKDPOGHF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				PNBNBGCNMCF.canSpawn = true;
				PHDOCKCBJOF = new WaitForSeconds(1697f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 4u:
				ALEFMCLGCAP = Singleton<SpawningManagerDeathMatch>.instance.CEGAOAEOOBC(new List<Tuple<int, int>>
				{
					new Tuple<int, int>(0, 0),
					new Tuple<int, int>(1, 0),
					new Tuple<int, int>(1, 1)
				});
				Singleton<SpawningManagerDeathMatch>.instance.BONPBCMFNHI(ALEFMCLGCAP);
				DeathMatchUnitsGuiElement.BCDJJBAFLLG().Enable();
				Singleton<SpawningManagerDeathMatch>.instance.JNEGMAGNBJI(BJGCPDNMHDH.InstanceOnArmyChangedFirst);
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().MDBPINJMNKO.AHPJFHNNODC(false);
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().MDBPINJMNKO.CLLJEINIGBL();
				Singleton<SpawningManagerDeathMatch>.instance.Enable();
				PHDOCKCBJOF = new WaitForSeconds(776f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 5u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("]=");
				TimeManager.DCODDANOPCP();
				GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("ID_GAMECENTERUSER", "ID_TUTORIAL_GO_TO_ARMORY_2_DOWN", 33f, TutorialDialog.DODBDLEJOAM.Left, true);
				GuiElementSingle<TutorialDialog>.instance.SetSoldierSprite("'x'0", "GameControllerPVP.StartGame DONE");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = false;
				goto case 6u;
			case 6u:
				if (!GuiElementSingle<TutorialDialog>.instance.GDAIHLIGAKP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				KFCAECGLKKO = Singleton<SpawningManagerDeathMatch>.instance.DPDIFLKIFJC.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SpawningManagerDeathMatch.ArmyUnitDefinition current = KFCAECGLKKO.Current;
						if (current.armyUnit.behaviour.unitType == LevelBehaviour.UnitType.Defender)
						{
							Singleton<SpawningManagerDeathMatch>.instance.PreGenerateRandomUnit(current);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("expireTime");
				Singleton<SpawningManagerDeathMatch>.instance.KPGIELJBLEH(false);
				Singleton<SpawningManagerDeathMatch>.instance.ResetAutoDeployProgress();
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheckWithPause((float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-40)).FLOATVALUE - 1857f)));
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = false;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
				TimeManager.UnFreezeGame(1927f);
				PHDOCKCBJOF = new WaitForSeconds(433f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 7u:
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.SpawnCheck(1299f));
				PHDOCKCBJOF = new WaitForSeconds(635f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 8u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void MPKODAJAPFD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HGOKAFJBFGJ()
		{
			return PHDOCKCBJOF;
		}

		public void FLGABFOKLNM()
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
		private object ADIAKJMNIEB()
		{
			return PHDOCKCBJOF;
		}

		public void BKGBMJMNJCD()
		{
			throw new NotSupportedException();
		}

		public bool BEIABOJAIFM()
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
				UnityEngine.Debug.Log("ru");
				goto case 2u;
			case 2u:
			{
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_SALEPERCENT");
				KFPHCMGGAIJ = Singleton<MapManager>.instance.ALCHJDPKAID.HNPHEEHLNDB();
				for (int i = 0; i < KFPHCMGGAIJ.Count; i++)
				{
					KFPHCMGGAIJ[i].point.CGKKGILAAPG().maxHealth = 1980f;
					KFPHCMGGAIJ[i].point.IGEDGCNJCAP().Refill();
				}
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 355f;
				Singleton<SpawningManagerDeathMatch>.instance.KPGIELJBLEH(false);
				Singleton<SpawningManagerDeathMatch>.instance.HFLKFDEDGDG = 8f;
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf(GHPGNELIDBM.Allies);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 259f;
				LHAAAIGMEBK.FOCIOKMPCAG.APJEBOPJPLA();
				LHAAAIGMEBK.KIIHLIPAGIH = false;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.DMIECFDHMKN();
				PNBNBGCNMCF.PADBFAIBBDG = 6;
				PNBNBGCNMCF.MGECHKCAELH = false;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = true;
				goto case 3u;
			}
			case 3u:
				if (!Singleton<GameController>.instance.KKHKIEFMENC())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				PNBNBGCNMCF.canSpawn = false;
				PHDOCKCBJOF = new WaitForSeconds(1764f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 4u:
				ALEFMCLGCAP = Singleton<SpawningManagerDeathMatch>.instance.GPMINOBFHLG(new List<Tuple<int, int>>
				{
					new Tuple<int, int>(1, 0),
					new Tuple<int, int>(0, 0),
					new Tuple<int, int>(0, 0)
				});
				Singleton<SpawningManagerDeathMatch>.instance.SetTutorialUnits(ALEFMCLGCAP);
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().Enable();
				Singleton<SpawningManagerDeathMatch>.instance.ArmyChanged += BJGCPDNMHDH.InstanceOnArmyChangedFirst;
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().MDBPINJMNKO.INGNIDHDLPD(false);
				DeathMatchUnitsGuiElement.instance.MDBPINJMNKO.KLPHMIGJLCG();
				Singleton<SpawningManagerDeathMatch>.instance.Enable();
				PHDOCKCBJOF = new WaitForSeconds(1623f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 5u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("N");
				TimeManager.FODFANEEDFF();
				GuiElementSingle<TutorialDialog>.instance.DDFADDKPPDI("Time", "ID_CONFIRM_LEAVE_SPECTATE_TEXT", 1982f, TutorialDialog.DODBDLEJOAM.BottomRight, true, true);
				GuiElementSingle<TutorialDialog>.instance.AJJDDGAGKEI("com.tune.TuneEvent", "getErrorCode");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = false;
				goto case 6u;
			case 6u:
				if (!GuiElementSingle<TutorialDialog>.instance.GDAIHLIGAKP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				KFCAECGLKKO = Singleton<SpawningManagerDeathMatch>.instance.DPDIFLKIFJC.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SpawningManagerDeathMatch.ArmyUnitDefinition current = KFCAECGLKKO.Current;
						if (current.armyUnit.behaviour.unitType == LevelBehaviour.UnitType.Defender)
						{
							Singleton<SpawningManagerDeathMatch>.instance.PreGenerateRandomUnit(current);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("damage");
				Singleton<SpawningManagerDeathMatch>.instance.KPGIELJBLEH(true);
				Singleton<SpawningManagerDeathMatch>.instance.MBKEOOJFOKP();
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheckWithPause((float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.BronzePackMaxRarityCardsType).FLOATVALUE - 1417f)));
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = false;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
				TimeManager.UnFreezeGame(1354f);
				PHDOCKCBJOF = new WaitForSeconds(491f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 7u:
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.SpawnCheck(1645f));
				PHDOCKCBJOF = new WaitForSeconds(1410f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 8u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object HJFIBBBPDKK()
		{
			return PHDOCKCBJOF;
		}

		public void CPEEDIDEKLA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void CNBLDCICPLL()
		{
			throw new NotSupportedException();
		}

		public void IPKNPABKAJD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object LNAPDCBIFIJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GENJNMACGLP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CGNOIKAGEMC()
		{
			return PHDOCKCBJOF;
		}

		public void IOHPKCNPKAH()
		{
			throw new NotSupportedException();
		}

		public bool AKFKBNAMOAI()
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
				UnityEngine.Debug.Log("KLHPEJKKNPD");
				goto case 2u;
			case 2u:
			{
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Area");
				KFPHCMGGAIJ = Singleton<MapManager>.instance.ALCHJDPKAID.DLPPKPNJFIK();
				for (int i = 1; i < KFPHCMGGAIJ.Count; i++)
				{
					KFPHCMGGAIJ[i].point.PKBPGCGNCAD().maxHealth = 850f;
					KFPHCMGGAIJ[i].point.LHHMNLJKOAO().Refill();
				}
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 678f;
				Singleton<SpawningManagerDeathMatch>.instance.KPGIELJBLEH(false);
				Singleton<SpawningManagerDeathMatch>.instance.HFLKFDEDGDG = 56f;
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf((GHPGNELIDBM)6);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 799f;
				LHAAAIGMEBK.FOCIOKMPCAG.APJEBOPJPLA();
				LHAAAIGMEBK.KIIHLIPAGIH = true;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.GetWeakBotConfig();
				PNBNBGCNMCF.PADBFAIBBDG = 6;
				PNBNBGCNMCF.MGECHKCAELH = true;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = true;
				goto case 3u;
			}
			case 3u:
				if (!Singleton<GameController>.instance.KKHKIEFMENC())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				PNBNBGCNMCF.OLDDFGBFMFK(false);
				PHDOCKCBJOF = new WaitForSeconds(1595f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 4u:
				ALEFMCLGCAP = Singleton<SpawningManagerDeathMatch>.instance.GetTutorial(new List<Tuple<int, int>>
				{
					new Tuple<int, int>(1, 1),
					new Tuple<int, int>(1, 1),
					new Tuple<int, int>(0, 0)
				});
				Singleton<SpawningManagerDeathMatch>.instance.SetTutorialUnits(ALEFMCLGCAP);
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().Enable();
				Singleton<SpawningManagerDeathMatch>.instance.ArmyChanged += BJGCPDNMHDH.InstanceOnArmyChangedFirst;
				DeathMatchUnitsGuiElement.BCDJJBAFLLG().MDBPINJMNKO.BDHPCMOGAHF(false);
				DeathMatchUnitsGuiElement.BLHCFKIELCA().MDBPINJMNKO.InstantUpdate();
				Singleton<SpawningManagerDeathMatch>.instance.Enable();
				PHDOCKCBJOF = new WaitForSeconds(1510f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 5u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("74379913-3b64-482e-bda1-8a8d90c0f3f9");
				TimeManager.DCODDANOPCP();
				GuiElementSingle<TutorialDialog>.instance.BLHEPOBPHPK("NewArena", "Reward", 234f, TutorialDialog.DODBDLEJOAM.Left, false, true);
				GuiElementSingle<TutorialDialog>.instance.HBEKIOOJMPA("game-card-ico-headsup", "ID_ARMYPOWER");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = true;
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = false;
				goto case 6u;
			case 6u:
				if (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				KFCAECGLKKO = Singleton<SpawningManagerDeathMatch>.instance.DPDIFLKIFJC.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SpawningManagerDeathMatch.ArmyUnitDefinition current = KFCAECGLKKO.Current;
						if (current.armyUnit.behaviour.unitType == LevelBehaviour.UnitType.Defender)
						{
							Singleton<SpawningManagerDeathMatch>.instance.NANNKFNBFBK(current);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Freeze game:");
				Singleton<SpawningManagerDeathMatch>.instance.OLJIPPEIOBO(false);
				Singleton<SpawningManagerDeathMatch>.instance.MBKEOOJFOKP();
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheckWithPause((float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.GoldCardRarityEarly).FLOATVALUE - 1498f)));
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = false;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = true;
				TimeManager.UnFreezeGame(812f);
				PHDOCKCBJOF = new WaitForSeconds(1315f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 7u:
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.SpawnCheck(1934f));
				PHDOCKCBJOF = new WaitForSeconds(1804f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 8u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
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

		public bool BLHOCNMMPNP()
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
				UnityEngine.Debug.Log("0");
				goto case 2u;
			case 2u:
			{
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("{0}{1}[-] {2}/[-] 3");
				KFPHCMGGAIJ = Singleton<MapManager>.instance.ALCHJDPKAID.GLOJOGJIEBE();
				for (int i = 0; i < KFPHCMGGAIJ.Count; i++)
				{
					KFPHCMGGAIJ[i].point.KJCHIHLJMMF().maxHealth = 1667f;
					KFPHCMGGAIJ[i].point.PNKKPNIMEPL().Refill();
				}
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 1080f;
				Singleton<SpawningManagerDeathMatch>.instance.OLJIPPEIOBO(true);
				Singleton<SpawningManagerDeathMatch>.instance.HFLKFDEDGDG = 1274f;
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf((GHPGNELIDBM)5);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 1067f;
				LHAAAIGMEBK.FOCIOKMPCAG.OEAGCMGINCB();
				LHAAAIGMEBK.KIIHLIPAGIH = false;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.MBECPMJFIHB();
				PNBNBGCNMCF.PADBFAIBBDG = 2;
				PNBNBGCNMCF.MGECHKCAELH = false;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = false;
				goto case 3u;
			}
			case 3u:
				if (!Singleton<GameController>.instance.KKHKIEFMENC())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				PNBNBGCNMCF.ANMBBDFMCMJ(false);
				PHDOCKCBJOF = new WaitForSeconds(1741f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 4u:
				ALEFMCLGCAP = Singleton<SpawningManagerDeathMatch>.instance.GPMINOBFHLG(new List<Tuple<int, int>>
				{
					new Tuple<int, int>(0, 1),
					new Tuple<int, int>(1, 1),
					new Tuple<int, int>(0, 0)
				});
				Singleton<SpawningManagerDeathMatch>.instance.BONPBCMFNHI(ALEFMCLGCAP);
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().Enable();
				Singleton<SpawningManagerDeathMatch>.instance.JNEGMAGNBJI(BJGCPDNMHDH.InstanceOnArmyChangedFirst);
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().MDBPINJMNKO.PJFDIEGEGAC(false);
				DeathMatchUnitsGuiElement.instance.MDBPINJMNKO.CLLJEINIGBL();
				Singleton<SpawningManagerDeathMatch>.instance.Enable();
				PHDOCKCBJOF = new WaitForSeconds(890f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 5u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("BUYING CARD PACK: type:{0} -> cardType:{1}");
				TimeManager.DCODDANOPCP();
				GuiElementSingle<TutorialDialog>.instance.KOGOLIJLMDN(" NOT OK!\t\t\t\t\t\t", "game-card-ico-swiftimmortality", 529f, TutorialDialog.DODBDLEJOAM.Right, true);
				GuiElementSingle<TutorialDialog>.instance.FMPPLLLJIML("Application paused", "Wins");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = true;
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = false;
				goto case 6u;
			case 6u:
				if (!GuiElementSingle<TutorialDialog>.instance.GDAIHLIGAKP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				KFCAECGLKKO = Singleton<SpawningManagerDeathMatch>.instance.DPDIFLKIFJC.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SpawningManagerDeathMatch.ArmyUnitDefinition current = KFCAECGLKKO.Current;
						if (current.armyUnit.behaviour.unitType == LevelBehaviour.UnitType.Defender)
						{
							Singleton<SpawningManagerDeathMatch>.instance.PreGenerateRandomUnit(current);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Gold");
				Singleton<SpawningManagerDeathMatch>.instance.KPGIELJBLEH(false);
				Singleton<SpawningManagerDeathMatch>.instance.ResetAutoDeployProgress();
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheckWithPause((float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.InstantBattleCostMin).FLOATVALUE - 160f)));
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = true;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
				TimeManager.UnFreezeGame(1621f);
				PHDOCKCBJOF = new WaitForSeconds(1386f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 7u:
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.SpawnCheck(682f));
				PHDOCKCBJOF = new WaitForSeconds(1648f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 8u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object FKKBFFHMEME()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JKKAEPEAGNP()
		{
			return PHDOCKCBJOF;
		}

		public void FCHOHLMCHED()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IFDMDGBPDKD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HBKJOBOMGKB()
		{
			return PHDOCKCBJOF;
		}

		public void HCHNHNDDKKA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object JEPCFCNIOGH()
		{
			return PHDOCKCBJOF;
		}

		public void PMAJELGBBKE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void NINFNJOMJOD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool JFPOOBJNEPF()
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
				UnityEngine.Debug.Log("ID_RESTART");
				goto case 2u;
			case 2u:
			{
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("DEPOSITING INFORMATIONS:\n");
				KFPHCMGGAIJ = Singleton<MapManager>.instance.ALCHJDPKAID.JCPPFKEIAFM();
				for (int i = 0; i < KFPHCMGGAIJ.Count; i += 0)
				{
					KFPHCMGGAIJ[i].point.JPHAJDIIAAI().maxHealth = 703f;
					KFPHCMGGAIJ[i].point.PHANADCNBFD().OEAGCMGINCB();
				}
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 192f;
				Singleton<SpawningManagerDeathMatch>.instance.OLJIPPEIOBO(false);
				Singleton<SpawningManagerDeathMatch>.instance.HFLKFDEDGDG = 224f;
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf((GHPGNELIDBM)3);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 1427f;
				LHAAAIGMEBK.FOCIOKMPCAG.Refill();
				LHAAAIGMEBK.KIIHLIPAGIH = false;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.GetWeakBotConfig();
				PNBNBGCNMCF.PADBFAIBBDG = 0;
				PNBNBGCNMCF.MGECHKCAELH = true;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = false;
				goto case 3u;
			}
			case 3u:
				if (!Singleton<GameController>.instance.gameIsRunning)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				PNBNBGCNMCF.FIODCBFFKAN(true);
				PHDOCKCBJOF = new WaitForSeconds(1235f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 4u:
				ALEFMCLGCAP = Singleton<SpawningManagerDeathMatch>.instance.CEGAOAEOOBC(new List<Tuple<int, int>>
				{
					new Tuple<int, int>(0, 0),
					new Tuple<int, int>(0, 1),
					new Tuple<int, int>(0, 0)
				});
				Singleton<SpawningManagerDeathMatch>.instance.BONPBCMFNHI(ALEFMCLGCAP);
				DeathMatchUnitsGuiElement.BKLDAAPMMDI().Enable();
				Singleton<SpawningManagerDeathMatch>.instance.ArmyChanged += BJGCPDNMHDH.InstanceOnArmyChangedFirst;
				DeathMatchUnitsGuiElement.instance.MDBPINJMNKO.INGNIDHDLPD(false);
				DeathMatchUnitsGuiElement.BCDJJBAFLLG().MDBPINJMNKO.InstantUpdate();
				Singleton<SpawningManagerDeathMatch>.instance.Enable();
				PHDOCKCBJOF = new WaitForSeconds(1124f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 5u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("weapon");
				TimeManager.FreezeGame();
				GuiElementSingle<TutorialDialog>.instance.KOGOLIJLMDN("SpawnByCardRPC", "<", 1165f, TutorialDialog.DODBDLEJOAM.Left, true, true);
				GuiElementSingle<TutorialDialog>.instance.SetSoldierSprite("ID_ARENAREWARD_TICKETS", "GameCenterId");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = true;
				goto case 6u;
			case 6u:
				if (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				KFCAECGLKKO = Singleton<SpawningManagerDeathMatch>.instance.DPDIFLKIFJC.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SpawningManagerDeathMatch.ArmyUnitDefinition current = KFCAECGLKKO.Current;
						if (current.armyUnit.behaviour.unitType == LevelBehaviour.UnitType.Defender)
						{
							Singleton<SpawningManagerDeathMatch>.instance.NANNKFNBFBK(current);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("canShow");
				Singleton<SpawningManagerDeathMatch>.instance.KPGIELJBLEH(false);
				Singleton<SpawningManagerDeathMatch>.instance.ResetAutoDeployProgress();
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheckWithPause((float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-90)).FLOATVALUE - 576f)));
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = false;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = true;
				TimeManager.UnFreezeGame(685f);
				PHDOCKCBJOF = new WaitForSeconds(67f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 7u:
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.SpawnCheck(114f));
				PHDOCKCBJOF = new WaitForSeconds(1493f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 8u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object GFMLDIMOGHD()
		{
			return PHDOCKCBJOF;
		}

		public void ODFCBNONFPL()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BBOGBCNCIFN()
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
				BJGCPDNMHDH.mGameStarted = true;
				PHDOCKCBJOF = new WaitForEndOfFrame();
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				UnityEngine.Debug.Log("game-elite-debuff1");
				goto case 2u;
			case 2u:
			{
				if (!BJGCPDNMHDH.mGameStarted)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("05");
				KFPHCMGGAIJ = Singleton<MapManager>.instance.ALCHJDPKAID.FOKIJHBHGJH();
				for (int i = 0; i < KFPHCMGGAIJ.Count; i++)
				{
					KFPHCMGGAIJ[i].point.IGEDGCNJCAP().maxHealth = 1014f;
					KFPHCMGGAIJ[i].point.JPHAJDIIAAI().APJEBOPJPLA();
				}
				Singleton<ScoreManager>.instance.FJPNILFKIAB = 1930f;
				Singleton<SpawningManagerDeathMatch>.instance.autoDeployEnabled = true;
				Singleton<SpawningManagerDeathMatch>.instance.HFLKFDEDGDG = 581f;
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.CheckAmmo()));
				LHAAAIGMEBK = PlayerController.GetEnemyOf((GHPGNELIDBM)4);
				LHAAAIGMEBK.FOCIOKMPCAG.maxHealth = 1292f;
				LHAAAIGMEBK.FOCIOKMPCAG.OEAGCMGINCB();
				LHAAAIGMEBK.KIIHLIPAGIH = false;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PNBNBGCNMCF.BPFKMNIHCGP = BotManager.GetWeakBotConfig();
				PNBNBGCNMCF.PADBFAIBBDG = 1;
				PNBNBGCNMCF.MGECHKCAELH = true;
				PNBNBGCNMCF = LHAAAIGMEBK.JPMHIGNOPBL;
				PlayerController.OGMBJPKOPCB.KIIHLIPAGIH = true;
				goto case 3u;
			}
			case 3u:
				if (!Singleton<GameController>.instance.GHKPKDPOGHF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				PNBNBGCNMCF.KLLJIBDDKHB(false);
				PHDOCKCBJOF = new WaitForSeconds(1217f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 4u:
				ALEFMCLGCAP = Singleton<SpawningManagerDeathMatch>.instance.CEGAOAEOOBC(new List<Tuple<int, int>>
				{
					new Tuple<int, int>(0, 0),
					new Tuple<int, int>(0, 1),
					new Tuple<int, int>(1, 0)
				});
				Singleton<SpawningManagerDeathMatch>.instance.BONPBCMFNHI(ALEFMCLGCAP);
				DeathMatchUnitsGuiElement.BCDJJBAFLLG().Enable();
				Singleton<SpawningManagerDeathMatch>.instance.PGBMKIHFJML(BJGCPDNMHDH.InstanceOnArmyChangedFirst);
				DeathMatchUnitsGuiElement.instance.MDBPINJMNKO.INGNIDHDLPD(false);
				DeathMatchUnitsGuiElement.instance.MDBPINJMNKO.CLLJEINIGBL();
				Singleton<SpawningManagerDeathMatch>.instance.Enable();
				PHDOCKCBJOF = new WaitForSeconds(1141f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 5u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(" (");
				TimeManager.FODFANEEDFF();
				GuiElementSingle<TutorialDialog>.instance.KOGOLIJLMDN("_", "id", 1700f, TutorialDialog.DODBDLEJOAM.TopLeft, true, true);
				GuiElementSingle<TutorialDialog>.instance.AJJDDGAGKEI("ID_VALUEPACK", "ID_ARENASTARTSTIMER");
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = false;
				goto case 6u;
			case 6u:
				if (!GuiElementSingle<TutorialDialog>.instance.GDAIHLIGAKP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				KFCAECGLKKO = Singleton<SpawningManagerDeathMatch>.instance.DPDIFLKIFJC.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						SpawningManagerDeathMatch.ArmyUnitDefinition current = KFCAECGLKKO.Current;
						if (current.armyUnit.behaviour.unitType == LevelBehaviour.UnitType.Defender)
						{
							Singleton<SpawningManagerDeathMatch>.instance.PreGenerateRandomUnit(current);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("WarsEvaluation");
				Singleton<SpawningManagerDeathMatch>.instance.OLJIPPEIOBO(false);
				Singleton<SpawningManagerDeathMatch>.instance.MBKEOOJFOKP();
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.SpawnCheckWithPause((float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.SquadWarsLowSquadsNoReward).FLOATVALUE - 1570f)));
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = false;
				PlayerController.OGMBJPKOPCB.JODNNABEFDH = false;
				TimeManager.UnFreezeGame(1496f);
				PHDOCKCBJOF = new WaitForSeconds(1130f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 7u:
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.SpawnCheck(1053f));
				PHDOCKCBJOF = new WaitForSeconds(1126f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 8u:
				BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.Overtime()));
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}
	}

	private sealed class LFCKGNCMGMB : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal TutorialManagerStage3 BJGCPDNMHDH;

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
		private object BOOBHEKPLLD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NDIGINEEOMH()
		{
			return PHDOCKCBJOF;
		}

		public void NINFNJOMJOD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object IJFPHIKFJFB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KIHECHEHNJJ()
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
			case 1u:
				if (Singleton<GameController>.instance.CBAPHFGNLLH.time > 1202f)
				{
					PHDOCKCBJOF = new WaitForSeconds(330f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_FREEPERCENTLINE");
				Singleton<MatchManager>.instance.StartOverTime(PlayerController.OGMBJPKOPCB, Singleton<GameController>.instance.opponent);
				if (!TutorialManagerStage2.instance.data.overtimeShowed)
				{
					PHDOCKCBJOF = new WaitForSeconds(1951f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				goto IL_0161;
			case 2u:
				TimeManager.FreezeGame();
				GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("아니오", string.Empty, 914f, TutorialDialog.DODBDLEJOAM.BottomLeft, true);
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				BJGCPDNMHDH.data.overtimeShowed = true;
				BJGCPDNMHDH.Save();
				goto case 3u;
			case 3u:
				if (!GuiElementSingle<TutorialDialog>.instance.GDAIHLIGAKP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				TimeManager.UnFreezeGame(383f);
				goto IL_0161;
			default:
				{
					return false;
				}
				IL_0161:
				Singleton<EventTrackingManager>.instance.RegisterTutorialOvertimeExplainedEvent(" (not enough warbucks), ", TutorialManagerStage2.instance.data.overtimeShowed);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		[SpecialName]
		private object GDCFFBBNGHH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GLIHEBDJCGM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CLDLJNHAEAB()
		{
			return PHDOCKCBJOF;
		}

		public bool DMPHMFDEINI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Singleton<GameController>.instance.CBAPHFGNLLH.time > 693f)
				{
					PHDOCKCBJOF = new WaitForSeconds(1520f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(", ");
				Singleton<MatchManager>.instance.INNLJEMFICP(PlayerController.OGMBJPKOPCB, Singleton<GameController>.instance.opponent);
				if (!TutorialManagerStage2.instance.data.overtimeShowed)
				{
					PHDOCKCBJOF = new WaitForSeconds(211f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				goto IL_0161;
			case 2u:
				TimeManager.FODFANEEDFF();
				GuiElementSingle<TutorialDialog>.instance.BLHEPOBPHPK("Different squad points \"{0}\" and \"{1}\"\n", string.Empty, 722f, TutorialDialog.DODBDLEJOAM.Left);
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				BJGCPDNMHDH.data.overtimeShowed = true;
				BJGCPDNMHDH.Save();
				goto case 3u;
			case 3u:
				if (!GuiElementSingle<TutorialDialog>.instance.GDAIHLIGAKP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				TimeManager.UnFreezeGame(976f);
				goto IL_0161;
			default:
				{
					return false;
				}
				IL_0161:
				Singleton<EventTrackingManager>.instance.RegisterTutorialOvertimeExplainedEvent("Skipping note with message ", TutorialManagerStage2.instance.data.overtimeShowed);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public bool GBHCODKDPBO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Singleton<GameController>.instance.CBAPHFGNLLH.time > 1726f)
				{
					PHDOCKCBJOF = new WaitForSeconds(1039f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Chillingo: On Age Verification Pending Dialog Display ");
				Singleton<MatchManager>.instance.StartOverTime(PlayerController.OGMBJPKOPCB, Singleton<GameController>.instance.opponent);
				if (!TutorialManagerStage2.instance.data.overtimeShowed)
				{
					PHDOCKCBJOF = new WaitForSeconds(40f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_0161;
			case 2u:
				TimeManager.FreezeGame();
				GuiElementSingle<TutorialDialog>.instance.DDFADDKPPDI("testingidsquadjoinrequest", string.Empty, 317f, TutorialDialog.DODBDLEJOAM.Top, false, true);
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				BJGCPDNMHDH.data.overtimeShowed = true;
				BJGCPDNMHDH.Save();
				goto case 3u;
			case 3u:
				if (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				TimeManager.UnFreezeGame(658f);
				goto IL_0161;
			default:
				{
					return false;
				}
				IL_0161:
				Singleton<EventTrackingManager>.instance.RegisterTutorialOvertimeExplainedEvent("ID_SLOTUPGRADE_POWER", TutorialManagerStage2.instance.data.overtimeShowed);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object KJMPNHLOKJL()
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
			case 1u:
				if (Singleton<GameController>.instance.CBAPHFGNLLH.time > 668f)
				{
					PHDOCKCBJOF = new WaitForSeconds(567f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("BattleId");
				Singleton<MatchManager>.instance.INNLJEMFICP(PlayerController.OGMBJPKOPCB, Singleton<GameController>.instance.opponent);
				if (!TutorialManagerStage2.instance.data.overtimeShowed)
				{
					PHDOCKCBJOF = new WaitForSeconds(1824f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				goto IL_0161;
			case 2u:
				TimeManager.FODFANEEDFF();
				GuiElementSingle<TutorialDialog>.instance.DDFADDKPPDI("ID_ISALREADYMEMBEROFANOTHERSQUAD", string.Empty, 1690f, TutorialDialog.DODBDLEJOAM.BottomLeft, true, true);
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				BJGCPDNMHDH.data.overtimeShowed = false;
				BJGCPDNMHDH.Save();
				goto case 3u;
			case 3u:
				if (!GuiElementSingle<TutorialDialog>.instance.GDAIHLIGAKP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				TimeManager.UnFreezeGame(659f);
				goto IL_0161;
			default:
				{
					return true;
				}
				IL_0161:
				Singleton<EventTrackingManager>.instance.RegisterTutorialOvertimeExplainedEvent("PH", TutorialManagerStage2.instance.data.overtimeShowed);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void IFLGJMJCOMC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public LFCKGNCMGMB()
		{
		}

		public void FJOIBBIGBJC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool DKIKFMODFJF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Singleton<GameController>.instance.CBAPHFGNLLH.time > 458f)
				{
					PHDOCKCBJOF = new WaitForSeconds(1340f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Medals/");
				Singleton<MatchManager>.instance.StartOverTime(PlayerController.OGMBJPKOPCB, Singleton<GameController>.instance.opponent);
				if (!TutorialManagerStage2.instance.data.overtimeShowed)
				{
					PHDOCKCBJOF = new WaitForSeconds(451f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_0161;
			case 2u:
				TimeManager.FreezeGame();
				GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("ID_XTICKETS", string.Empty, 465f, TutorialDialog.DODBDLEJOAM.BottomRight, false, true);
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				BJGCPDNMHDH.data.overtimeShowed = true;
				BJGCPDNMHDH.Save();
				goto case 3u;
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
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				TimeManager.UnFreezeGame(218f);
				goto IL_0161;
			default:
				{
					return false;
				}
				IL_0161:
				Singleton<EventTrackingManager>.instance.RegisterTutorialOvertimeExplainedEvent("menu-weapons-tab-active", TutorialManagerStage2.instance.data.overtimeShowed);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object OAMLLHEMBIK()
		{
			return PHDOCKCBJOF;
		}

		public void ENCGDFIIGNH()
		{
			throw new NotSupportedException();
		}

		public bool NJBCJDFKGHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Singleton<GameController>.instance.CBAPHFGNLLH.time > 1220f)
				{
					PHDOCKCBJOF = new WaitForSeconds(1752f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("setUserName");
				Singleton<MatchManager>.instance.INNLJEMFICP(PlayerController.OGMBJPKOPCB, Singleton<GameController>.instance.opponent);
				if (!TutorialManagerStage2.instance.data.overtimeShowed)
				{
					PHDOCKCBJOF = new WaitForSeconds(1670f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				goto IL_0161;
			case 2u:
				TimeManager.FreezeGame();
				GuiElementSingle<TutorialDialog>.instance.DDFADDKPPDI("#VOJTA# LOADED DAILY MISSIONS AFTER LEVEL UP", string.Empty, 119f, TutorialDialog.DODBDLEJOAM.BottomRight, true);
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				BJGCPDNMHDH.data.overtimeShowed = false;
				BJGCPDNMHDH.Save();
				goto case 3u;
			case 3u:
				if (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				TimeManager.UnFreezeGame(830f);
				goto IL_0161;
			default:
				{
					return false;
				}
				IL_0161:
				Singleton<EventTrackingManager>.instance.RegisterTutorialOvertimeExplainedEvent("0", TutorialManagerStage2.instance.data.overtimeShowed);
				CLPPIAGLCJJ = -1;
				goto default;
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
			case 1u:
				if (Singleton<GameController>.instance.CBAPHFGNLLH.time > 0f)
				{
					PHDOCKCBJOF = new WaitForSeconds(1f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("306 OVERTIME");
				Singleton<MatchManager>.instance.StartOverTime(PlayerController.OGMBJPKOPCB, Singleton<GameController>.instance.opponent);
				if (!TutorialManagerStage2.instance.data.overtimeShowed)
				{
					PHDOCKCBJOF = new WaitForSeconds(1f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				goto IL_0161;
			case 2u:
				TimeManager.FreezeGame();
				GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("ID_TUTORIAL_OVERTIME", string.Empty, 0.3f, TutorialDialog.DODBDLEJOAM.Center, true);
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				BJGCPDNMHDH.data.overtimeShowed = true;
				BJGCPDNMHDH.Save();
				goto case 3u;
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
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				GuiElementSingle<TutorialDialog>.instance.Hide();
				TimeManager.UnFreezeGame();
				goto IL_0161;
			default:
				{
					return false;
				}
				IL_0161:
				Singleton<EventTrackingManager>.instance.RegisterTutorialOvertimeExplainedEvent("TUTORIAL 3 OVERTIME CONTINUE", TutorialManagerStage2.instance.data.overtimeShowed);
				CLPPIAGLCJJ = -1;
				goto default;
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
			case 1u:
				if (Singleton<GameController>.instance.CBAPHFGNLLH.time > 1417f)
				{
					PHDOCKCBJOF = new WaitForSeconds(566f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("RewardMessage");
				Singleton<MatchManager>.instance.INNLJEMFICP(PlayerController.OGMBJPKOPCB, Singleton<GameController>.instance.opponent);
				if (!TutorialManagerStage2.instance.data.overtimeShowed)
				{
					PHDOCKCBJOF = new WaitForSeconds(1329f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				goto IL_0161;
			case 2u:
				TimeManager.FODFANEEDFF();
				GuiElementSingle<TutorialDialog>.instance.BLHEPOBPHPK("Vip", string.Empty, 833f, TutorialDialog.DODBDLEJOAM.Right, true, true);
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				BJGCPDNMHDH.data.overtimeShowed = false;
				BJGCPDNMHDH.Save();
				goto case 3u;
			case 3u:
				if (!GuiElementSingle<TutorialDialog>.instance.continueClicked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				GuiElementSingle<TutorialDialog>.instance.Hide();
				TimeManager.UnFreezeGame(1221f);
				goto IL_0161;
			default:
				{
					return false;
				}
				IL_0161:
				Singleton<EventTrackingManager>.instance.RegisterTutorialOvertimeExplainedEvent("GooglePlay", TutorialManagerStage2.instance.data.overtimeShowed);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object KKKMCHGLHLL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CCANBMDEKMB()
		{
			return PHDOCKCBJOF;
		}

		public void OAFPDIHGJDC()
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
			case 1u:
				if (Singleton<GameController>.instance.CBAPHFGNLLH.time > 1313f)
				{
					PHDOCKCBJOF = new WaitForSeconds(52f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("BAND_REWARD_HEALTH");
				Singleton<MatchManager>.instance.INNLJEMFICP(PlayerController.OGMBJPKOPCB, Singleton<GameController>.instance.opponent);
				if (!TutorialManagerStage2.instance.data.overtimeShowed)
				{
					PHDOCKCBJOF = new WaitForSeconds(1133f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				goto IL_0161;
			case 2u:
				TimeManager.DCODDANOPCP();
				GuiElementSingle<TutorialDialog>.instance.DDFADDKPPDI("122 MENU WEAPON SCREEN TUTORIAL WEAPON SELECTED", string.Empty, 1323f, TutorialDialog.DODBDLEJOAM.Bottom);
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				BJGCPDNMHDH.data.overtimeShowed = true;
				BJGCPDNMHDH.Save();
				goto case 3u;
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
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				TimeManager.UnFreezeGame(262f);
				goto IL_0161;
			default:
				{
					return false;
				}
				IL_0161:
				Singleton<EventTrackingManager>.instance.RegisterTutorialOvertimeExplainedEvent("Player Card {0} {1} {2}", TutorialManagerStage2.instance.data.overtimeShowed);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public bool PMBOHHPPJAC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Singleton<GameController>.instance.CBAPHFGNLLH.time > 369f)
				{
					PHDOCKCBJOF = new WaitForSeconds(379f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_INSILVER2");
				Singleton<MatchManager>.instance.INNLJEMFICP(PlayerController.OGMBJPKOPCB, Singleton<GameController>.instance.opponent);
				if (!TutorialManagerStage2.instance.data.overtimeShowed)
				{
					PHDOCKCBJOF = new WaitForSeconds(1736f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				goto IL_0161;
			case 2u:
				TimeManager.FreezeGame();
				GuiElementSingle<TutorialDialog>.instance.BLHEPOBPHPK("ID_GUI_BEADVISED", string.Empty, 593f, TutorialDialog.DODBDLEJOAM.Bottom, false, true);
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				BJGCPDNMHDH.data.overtimeShowed = true;
				BJGCPDNMHDH.Save();
				goto case 3u;
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
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				TimeManager.UnFreezeGame(324f);
				goto IL_0161;
			default:
				{
					return true;
				}
				IL_0161:
				Singleton<EventTrackingManager>.instance.RegisterTutorialOvertimeExplainedEvent("?", TutorialManagerStage2.instance.data.overtimeShowed);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public void MIEFKIEABBN()
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
			case 1u:
				if (Singleton<GameController>.instance.CBAPHFGNLLH.time > 2f)
				{
					PHDOCKCBJOF = new WaitForSeconds(1484f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("{0}:\t{1}\n");
				Singleton<MatchManager>.instance.StartOverTime(PlayerController.OGMBJPKOPCB, Singleton<GameController>.instance.opponent);
				if (!TutorialManagerStage2.instance.data.overtimeShowed)
				{
					PHDOCKCBJOF = new WaitForSeconds(709f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				goto IL_0161;
			case 2u:
				TimeManager.FreezeGame();
				GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("TW_Follow", string.Empty, 1005f, TutorialDialog.DODBDLEJOAM.TopLeft, true);
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				BJGCPDNMHDH.data.overtimeShowed = false;
				BJGCPDNMHDH.Save();
				goto case 3u;
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
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				TimeManager.UnFreezeGame(1982f);
				goto IL_0161;
			default:
				{
					return true;
				}
				IL_0161:
				Singleton<EventTrackingManager>.instance.RegisterTutorialOvertimeExplainedEvent(" iconName:", TutorialManagerStage2.instance.data.overtimeShowed);
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public void IPKNPABKAJD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MPEPJNIDBLI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BLOJDIFOPIA()
		{
			return PHDOCKCBJOF;
		}

		public bool JMCPAKBLPML()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Singleton<GameController>.instance.CBAPHFGNLLH.time > 1989f)
				{
					PHDOCKCBJOF = new WaitForSeconds(1960f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("GetOriginalAccountId()");
				Singleton<MatchManager>.instance.INNLJEMFICP(PlayerController.OGMBJPKOPCB, Singleton<GameController>.instance.opponent);
				if (!TutorialManagerStage2.instance.data.overtimeShowed)
				{
					PHDOCKCBJOF = new WaitForSeconds(692f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				goto IL_0161;
			case 2u:
				TimeManager.FreezeGame();
				GuiElementSingle<TutorialDialog>.instance.KOGOLIJLMDN("BS: On add video reward success!", string.Empty, 1532f);
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				BJGCPDNMHDH.data.overtimeShowed = true;
				BJGCPDNMHDH.Save();
				goto case 3u;
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
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				TimeManager.UnFreezeGame(1340f);
				goto IL_0161;
			default:
				{
					return false;
				}
				IL_0161:
				Singleton<EventTrackingManager>.instance.RegisterTutorialOvertimeExplainedEvent("About to show Buy Power Band Reminder: ", TutorialManagerStage2.instance.data.overtimeShowed);
				CLPPIAGLCJJ = -1;
				goto default;
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
		private object GJMNLPAEIDA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FMCLBOCENPE()
		{
			return PHDOCKCBJOF;
		}

		public void NFLHLMKKJMO()
		{
			throw new NotSupportedException();
		}
	}

	private sealed class IJIENBLFAJD : IEnumerator, IDisposable, IEnumerator<object>
	{
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

		public void KCHOLCGBMBJ()
		{
			throw new NotSupportedException();
		}

		public bool ILNBJIJONKD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (PlayerController.OGMBJPKOPCB.FMKGGADDHJK().LAGONJMBJMM[1].weapon.ammoLeft < 34)
				{
					PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().LAGONJMBJMM[1].weapon.ammoLeft = 70;
				}
				PHDOCKCBJOF = new WaitForRealSeconds(1190f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			default:
				return true;
			}
		}

		[SpecialName]
		private object HCPKEMLPEDI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DCILDAODCDM()
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
			case 1u:
				if (PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[1].weapon.ammoLeft < -88)
				{
					PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[0].weapon.ammoLeft = 57;
				}
				PHDOCKCBJOF = new WaitForRealSeconds(1999f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			default:
				return false;
			}
		}

		public void ANOPOLIEBMC()
		{
			throw new NotSupportedException();
		}

		public void CCPGGFONBKA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object FPMOGMELJLI()
		{
			return PHDOCKCBJOF;
		}

		public void LJPIDOKGNBF()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void FJOIBBIGBJC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object AFDKAGLDADB()
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
			case 1u:
				if (PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[1].HFNAMMBPJAJ().ammoLeft < 0)
				{
					PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().LAGONJMBJMM[0].weapon.ammoLeft = 113;
				}
				PHDOCKCBJOF = new WaitForRealSeconds(403f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			default:
				return false;
			}
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[0].weapon.ammoLeft < 41)
				{
					PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[0].weapon.ammoLeft = 100;
				}
				PHDOCKCBJOF = new WaitForRealSeconds(2f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return false;
			}
		}

		public void HGCHEPGNHNP()
		{
			throw new NotSupportedException();
		}

		public bool EJKHEELJJFM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().LAGONJMBJMM[1].HFNAMMBPJAJ().ammoLeft < 19)
				{
					PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[1].HFNAMMBPJAJ().ammoLeft = 36;
				}
				PHDOCKCBJOF = new WaitForRealSeconds(567f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			default:
				return true;
			}
		}

		[SpecialName]
		private object AKGMMLGANMJ()
		{
			return PHDOCKCBJOF;
		}

		public void FOODPOJODAA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void LICALBFPBLL()
		{
			throw new NotSupportedException();
		}

		public void GFPAMDPNMKG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void KIPDKEKMDFE()
		{
			throw new NotSupportedException();
		}

		public void CNMNAHEINED()
		{
			throw new NotSupportedException();
		}

		public void MBELAAJDOJA()
		{
			throw new NotSupportedException();
		}

		public void BCOIPCDCKEJ()
		{
			throw new NotSupportedException();
		}

		public void MIEFKIEABBN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool GBLFIBDBMGE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[0].HFNAMMBPJAJ().ammoLeft < 17)
				{
					PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().LAGONJMBJMM[0].weapon.ammoLeft = 2;
				}
				PHDOCKCBJOF = new WaitForRealSeconds(1003f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			default:
				return true;
			}
		}

		public void OGBOHCPHGMK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object ABGFJLAPNNM()
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
			case 1u:
				if (PlayerController.OGMBJPKOPCB.FMKGGADDHJK().LAGONJMBJMM[0].weapon.ammoLeft < 63)
				{
					PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().LAGONJMBJMM[1].HFNAMMBPJAJ().ammoLeft = 75;
				}
				PHDOCKCBJOF = new WaitForRealSeconds(1363f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			default:
				return true;
			}
		}

		public bool LPMIKEPIMCM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().LAGONJMBJMM[1].weapon.ammoLeft < -118)
				{
					PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().LAGONJMBJMM[1].weapon.ammoLeft = -68;
				}
				PHDOCKCBJOF = new WaitForRealSeconds(515f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return false;
			}
		}

		public void NPIDJAPKFLN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object EOPJNKFKMNB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GDCFFBBNGHH()
		{
			return PHDOCKCBJOF;
		}

		public void HLJMNBBDJGE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object EKJDPPIGKCF()
		{
			return PHDOCKCBJOF;
		}

		public void NGAGGCFIEGJ()
		{
			throw new NotSupportedException();
		}

		public void POJKIIMAFDO()
		{
			throw new NotSupportedException();
		}

		public void KNFDDIHLBKJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HHHLDCLIFKJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KLEHMEIAJHO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PEGJNAKGHCC()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HMBLLDJFIJG()
		{
			throw new NotSupportedException();
		}

		public void LPKDPNHBLGJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object JCDIBAEMKCA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OAMLLHEMBIK()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object LMJBCDNGAHP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FKKBFFHMEME()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IHPDPKLEDKC()
		{
			return PHDOCKCBJOF;
		}

		public void NFLHLMKKJMO()
		{
			throw new NotSupportedException();
		}

		public void OFDJMNMCDLA()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object AGANCOFPDCK()
		{
			return PHDOCKCBJOF;
		}

		public void NPKGNIGNPKG()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HHLKEMNNJDA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IBCJOBKGEEG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HBKJOBOMGKB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HOCLBPGAEMP()
		{
			return PHDOCKCBJOF;
		}

		public void HANDHJHGLAP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object KIHECHEHNJJ()
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
			case 1u:
				if (PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().LAGONJMBJMM[1].weapon.ammoLeft < 12)
				{
					PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().LAGONJMBJMM[0].HFNAMMBPJAJ().ammoLeft = 117;
				}
				PHDOCKCBJOF = new WaitForRealSeconds(293f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return false;
			}
		}

		public bool DKJMOPNHIAB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (PlayerController.OGMBJPKOPCB.FMKGGADDHJK().LAGONJMBJMM[0].weapon.ammoLeft < 28)
				{
					PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().LAGONJMBJMM[1].HFNAMMBPJAJ().ammoLeft = -44;
				}
				PHDOCKCBJOF = new WaitForRealSeconds(1315f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			default:
				return true;
			}
		}

		[DebuggerHidden]
		public IJIENBLFAJD()
		{
		}

		public void NBGFOILFGHD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object NMGBFNNHIPN()
		{
			return PHDOCKCBJOF;
		}

		public bool JPAOKNLNFCB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().LAGONJMBJMM[0].HFNAMMBPJAJ().ammoLeft < -46)
				{
					PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[1].HFNAMMBPJAJ().ammoLeft = 82;
				}
				PHDOCKCBJOF = new WaitForRealSeconds(222f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			default:
				return false;
			}
		}

		public bool IGOKEIDOCKB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (PlayerController.OGMBJPKOPCB.FMKGGADDHJK().LAGONJMBJMM[0].HFNAMMBPJAJ().ammoLeft < -74)
				{
					PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().LAGONJMBJMM[1].HFNAMMBPJAJ().ammoLeft = -34;
				}
				PHDOCKCBJOF = new WaitForRealSeconds(1798f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			default:
				return true;
			}
		}

		public void HNFEJKPKEHK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GENJNMACGLP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GNFCCLCPCBO()
		{
			return PHDOCKCBJOF;
		}

		public bool PPOPGFELIDA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().LAGONJMBJMM[0].weapon.ammoLeft < 93)
				{
					PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().LAGONJMBJMM[0].weapon.ammoLeft = -81;
				}
				PHDOCKCBJOF = new WaitForRealSeconds(566f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			default:
				return false;
			}
		}

		[SpecialName]
		private object HFKDIPEKENH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MIKGAKNJGKL()
		{
			return PHDOCKCBJOF;
		}
	}

	private static TutorialManagerStage3 mInstance;

	public const string id = "Stage3";

	public CardsGuiElementNew cardGUI;

	private bool mGameStarted;

	public static TutorialManagerStage3 instance
	{
		get
		{
			mInstance = mInstance ?? UnityEngine.Object.FindObjectOfType<TutorialManagerStage3>();
			return mInstance;
		}
	}

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

	private void OnGameStarted()
	{
		mGameStarted = true;
		if (base.isTutorialRunning)
		{
			Singleton<GameController>.instance.opponent.FOCIOKMPCAG.GPLNJOPPKIM.Enable();
			Singleton<GameController>.instance.opponent.FOCIOKMPCAG.GPLNJOPPKIM.FadeIn(0.1f);
		}
	}

	protected override void AfterSpawned(AIObject aiObject)
	{
		base.AfterSpawned(aiObject);
		if (base.isTutorialRunning)
		{
			TurretRockets turretRockets = aiObject as TurretRockets;
			if (turretRockets != null && turretRockets.fraction == PlayerController.OGMBJPKOPCB.fraction)
			{
				MissileSetup component = turretRockets.GetComponent<MissileSetup>();
				component.MAOPCAMOEEK = 0.04f;
				component.ABFGHBDEBAN = 400f;
				turretRockets.destroyableObj.maxHealth *= 2f;
				turretRockets.destroyableObj.Refill();
			}
		}
	}

	public void FinishMenuTutorial()
	{
		StartCoroutine(AfterGameCoroutine());
	}

	[DebuggerHidden]
	private IEnumerator AfterGameCoroutine()
	{
		EOANNIBMAOM eOANNIBMAOM = new EOANNIBMAOM();
		eOANNIBMAOM.BJGCPDNMHDH = this;
		return eOANNIBMAOM;
	}

	private void OnGameEnded(GameController.HKGHCIEPGEL obj)
	{
		if (base.isTutorialRunning)
		{
			GameLoginManager.instance.TryPresetStartingCurrency();
			Singleton<EventTrackingManager>.instance.RegisterTutorialGameEnded(3, "308 GAME END");
			StopAllCoroutines();
			GuiElementSingle<TutorialDialog>.instance.HideDialog();
			Singleton<Wallet>.instance.SetRewardForTutorial(2500, 3);
			Singleton<ScoreManager>.instance.score += 10000;
			LevelManager.instance.SetLevelUpProgressForTutorial(3, 0f, false);
			UnityEngine.Debug.Log("*****   Bootcamp 3/3 Ended   *****");
			LevelManager.instance.levelExperience += Singleton<ScoreManager>.instance.score;
		}
	}

	public override void StartTutorial(bool isContinue)
	{
		SetPlayerDefaultWeapons(true, true, true);
		if (isContinue)
		{
			data.gold = (int)Singleton<Wallet>.instance.gold;
			data.wb = (int)Singleton<Wallet>.instance.warBucks;
		}
		else if (data.gold != 0 && data.wb != 0)
		{
			Singleton<Wallet>.instance.SetTutorialCurrency(data.wb, data.gold);
		}
		data.started = true;
		Save();
		base.StartTutorial(isContinue);
		PrepareDataForTutorial();
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("301 LOADING MAP");
		StartCoroutine(RadicalRoutine.Run(Welcome()));
	}

	private void PrepareDataForTutorial()
	{
		LevelManager.instance.SetLevelUpProgressForTutorial(3, 0f, false);
		PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.BCCDDJMPBLL = 3;
		PlayerController.GetEnemyOf(PlayerController.OGMBJPKOPCB.fraction).EHHHBEMKGOE.BCCDDJMPBLL = 3;
		GuiElementSingle<MenuHeader>.instance.InitGUIValues();
	}

	public override void FinishTutorial()
	{
		base.FinishTutorial();
		Singleton<SpawningManagerDeathMatch>.instance.ArmyChanged -= InstanceOnArmyChangedFirst;
	}

	private void InstanceOnArmyChangedFirst()
	{
		Singleton<SpawningManagerDeathMatch>.instance.ArmyChanged -= InstanceOnArmyChangedFirst;
		List<SpawningManagerDeathMatch.ArmyUnitDefinition> tutorial = Singleton<SpawningManagerDeathMatch>.instance.GetTutorial(new List<Tuple<int, int>>
		{
			new Tuple<int, int>(0, 0),
			new Tuple<int, int>(0, 0),
			new Tuple<int, int>(0, 0)
		});
		Singleton<SpawningManagerDeathMatch>.instance.SetTutorialUnits(tutorial);
		EnemyController enemyController = (EnemyController)Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(LevelManager.instance.behaviours[1]);
		if (enemyController != null && enemyController.prefab != null)
		{
			enemyController.fraction = GHPGNELIDBM.Enemies;
			int nOCEDALFEJM = ObjectPoolDatabase.networkPool.APCGDLEHGKL[enemyController.prefab];
			enemyController = (EnemyController)ObjectPoolDatabase.networkPool.ReInstantiate(nOCEDALFEJM, enemyController.indexInObjectPool);
			enemyController.power = 4;
			enemyController.StartEnemyBehaviour();
			enemyController.power = 4;
		}
		StartCoroutine(CheckKilledShotGunner(enemyController));
		InvokeAfter(delegate
		{
			PlayerController opponent = Singleton<GameController>.instance.opponent;
			opponent.JPMHIGNOPBL.canSpawn = true;
		}, 5f);
	}

	[DebuggerHidden]
	private IEnumerator CheckKilledShotGunner(EnemyController enemy)
	{
		DHDAHKOFLGL dHDAHKOFLGL = new DHDAHKOFLGL();
		dHDAHKOFLGL.KGGJOOAFDIF = enemy;
		return dHDAHKOFLGL;
	}

	[DebuggerHidden]
	private IEnumerator Welcome()
	{
		JAAGHMKDIIA jAAGHMKDIIA = new JAAGHMKDIIA();
		jAAGHMKDIIA.BJGCPDNMHDH = this;
		return jAAGHMKDIIA;
	}

	[DebuggerHidden]
	private IEnumerator Overtime()
	{
		LFCKGNCMGMB lFCKGNCMGMB = new LFCKGNCMGMB();
		lFCKGNCMGMB.BJGCPDNMHDH = this;
		return lFCKGNCMGMB;
	}

	[DebuggerHidden]
	private IEnumerator CheckAmmo()
	{
		return new IJIENBLFAJD();
	}
}
