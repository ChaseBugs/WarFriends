using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Google2u;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Serialization;

public class GameControllerTutorial : IGameController
{
	private sealed class PBFOPDADAJH : IEnumerator, IDisposable, IEnumerator<object>
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

		public bool EKHDJADMNJK()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return true;
		}

		[DebuggerHidden]
		public void Dispose()
		{
		}

		[SpecialName]
		private object DGEECEBHPNC()
		{
			return PHDOCKCBJOF;
		}

		public bool DDLMLOJGJMA()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return false;
		}

		public void OJDEHKDDLFD()
		{
		}

		[DebuggerHidden]
		public PBFOPDADAJH()
		{
		}

		[SpecialName]
		private object GDCFFBBNGHH()
		{
			return PHDOCKCBJOF;
		}

		public void HEOPOOMLPJF()
		{
			throw new NotSupportedException();
		}

		public void ODFCBNONFPL()
		{
			throw new NotSupportedException();
		}

		public bool FNEPBDLIKOD()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return false;
		}

		[SpecialName]
		private object GOAJCEAOPLA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BNFADGLHBAH()
		{
			return PHDOCKCBJOF;
		}

		public void AHEOCEEJICJ()
		{
		}

		public bool MoveNext()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return false;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}
	}

	private sealed class LIMGNABNMEG : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal GHPGNELIDBM MCCLPJGMIDG;

		internal MapDefinition.DefendPosition JJLBIPJDBAG;

		internal PlayerBot PNBNBGCNMCF;

		internal bool FABFPMKKFJK;

		internal GameControllerTutorial BJGCPDNMHDH;

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

		public void MIEFKIEABBN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object OEKIILKKNOE()
		{
			return PHDOCKCBJOF;
		}

		public void POJNMHLNOOF()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object ILNCOKPCNBB()
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
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.BIFELDOOCNM());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				Singleton<ArmyPreviewCamera>.instance.LCIFJLNADFP(BJGCPDNMHDH.JJKLKPKMHJO(), PNDNEMDPFHC: false, PlayerTexturePool.DFJJOANIJID.Card);
				PlayerController.JFGDAKMCJAM.Clear();
				UnityEngine.Debug.Log("global");
				MCCLPJGMIDG = GHPGNELIDBM.None;
				JJLBIPJDBAG = BJGCPDNMHDH.CHCPANHGABC(MCCLPJGMIDG);
				BJGCPDNMHDH.PHCFJDNCHII().fraction = MCCLPJGMIDG;
				BJGCPDNMHDH.AAIEPHNDCJP.MoveTo(JJLBIPJDBAG.point.transform.position, JJLBIPJDBAG.point.transform.rotation);
				BJGCPDNMHDH.AAIEPHNDCJP.HCOKNKCCPEK(JJLBIPJDBAG);
				BJGCPDNMHDH.PLIGGFJCAPA().EHHHBEMKGOE = CHEIFOOIMEH.JIIHHODDNLJ();
				PlayerController.OGMBJPKOPCB = BJGCPDNMHDH.JJKLKPKMHJO();
				PlayerController.JFGDAKMCJAM[0] = BJGCPDNMHDH.PLIGGFJCAPA();
				BJGCPDNMHDH.PHCFJDNCHII().NAGAHNHAKBJ = 0;
				BJGCPDNMHDH.PLIGGFJCAPA().DMHKCCPPODF();
				BJGCPDNMHDH.PHCFJDNCHII().DIOEINBFJBG(BJGCPDNMHDH.CHEDFKIPJFF);
				BJGCPDNMHDH.PLIGGFJCAPA().FDHJCAGOFKN(BJGCPDNMHDH.CHEDFKIPJFF);
				BJGCPDNMHDH.LAHLHAMCFAM();
				Singleton<BotManager>.instance.DDLKOAIFIJM(BJGCPDNMHDH.NLAKCKMCOMN.JPMHIGNOPBL);
				BJGCPDNMHDH.NLAKCKMCOMN.InitPlayer();
				PNBNBGCNMCF = BJGCPDNMHDH.NLAKCKMCOMN.JPMHIGNOPBL;
				PNBNBGCNMCF.enabled = false;
				CardManager.instance.ClearCardsForGame();
				GameLoginManager.instance.CheckGpgsOnTutorialStart();
				if (TutorialManagerStage2.instance.isTutorialRunning || TutorialManagerStage3.instance.data.started)
				{
					FABFPMKKFJK = TutorialManagerStage2.instance.isTutorialRunning;
					UnityEngine.Debug.Log(" (ID:");
					TutorialManagerStage2.instance.FinishTutorial();
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("#VAVRO# Trying to finish Tutorial, which is not currently running ");
					TutorialManagerStage3.instance.StartTutorial(FABFPMKKFJK);
					CardManager.instance.cardsForGame.Clear();
					TutorialManagerStage2.instance.EquipTutorialUnitAfterSkipTutorial();
					PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII = CardManager.instance.selectedCards;
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				if (TutorialManagerStage1.instance.isTutorialRunning || TutorialManagerStage2.instance.data.started)
				{
					bool isTutorialRunning = TutorialManagerStage1.instance.isTutorialRunning;
					UnityEngine.Debug.Log("1");
					TutorialManagerStage1.instance.FinishTutorial();
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("SquadMemberId");
					TutorialManagerStage2.instance.StartTutorial(isTutorialRunning);
				}
				else
				{
					UnityEngine.Debug.Log("nonEliteUnits");
					TutorialManagerStage1.instance.StartTutorial(isContinue: true);
				}
				goto case 4u;
			case 2u:
				PHDOCKCBJOF = new WaitForSeconds(1832f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 3u:
				Singleton<SoundsManager3D>.instance.GCOKDIOKPKG();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.ALLMFMGKLOC(BJGCPDNMHDH.myUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 4u:
				PHDOCKCBJOF = new WaitForSeconds(435f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 5u:
				LoadingDialog.Hide();
				if (Singleton<GameController>.instance.isTutorialStage1)
				{
					BJGCPDNMHDH.AAIEPHNDCJP.BEIIOAIJMFK().LIEDNEJPLMA = 6;
					SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.DailyVIPCardsShow, 864f);
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(1218f));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<GameStartScreen>.instance);
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.HIFIIAIAJKP());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				break;
			case 7u:
				PHDOCKCBJOF = new WaitForSeconds(191f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 6u:
			case 8u:
				Time.timeScale = 1737f;
				BJGCPDNMHDH.time = 925f;
				BJGCPDNMHDH.MMCKLPHNMMN = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object AIDHNJCPDIJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OJKHNOHHDGO()
		{
			return PHDOCKCBJOF;
		}

		public void CKEOKOKAAPB()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HJHFKNCBGDG()
		{
			return PHDOCKCBJOF;
		}

		public bool MKCOLOBIAAP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.MCMLNCLLBPA());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				Singleton<ArmyPreviewCamera>.instance.RenderToTexture(BJGCPDNMHDH.PLIGGFJCAPA(), PNDNEMDPFHC: true);
				PlayerController.JFGDAKMCJAM.Clear();
				UnityEngine.Debug.Log("ID_CONFIRM_PROMOTETOLEADER");
				MCCLPJGMIDG = GHPGNELIDBM.None;
				JJLBIPJDBAG = BJGCPDNMHDH.BJOFNDKLKOC(MCCLPJGMIDG);
				BJGCPDNMHDH.AAIEPHNDCJP.fraction = MCCLPJGMIDG;
				BJGCPDNMHDH.PLIGGFJCAPA().MoveTo(JJLBIPJDBAG.point.transform.position, JJLBIPJDBAG.point.transform.rotation);
				BJGCPDNMHDH.PLIGGFJCAPA().currentPlayerPoint = JJLBIPJDBAG;
				BJGCPDNMHDH.JJKLKPKMHJO().EHHHBEMKGOE = CHEIFOOIMEH.NLCGDAFBFNE();
				PlayerController.OGMBJPKOPCB = BJGCPDNMHDH.AAIEPHNDCJP;
				PlayerController.JFGDAKMCJAM[0] = BJGCPDNMHDH.AAIEPHNDCJP;
				BJGCPDNMHDH.AAIEPHNDCJP.NAGAHNHAKBJ = 1;
				BJGCPDNMHDH.AAIEPHNDCJP.InitPlayer();
				BJGCPDNMHDH.PHCFJDNCHII().DIOEINBFJBG(BJGCPDNMHDH.CHEDFKIPJFF);
				BJGCPDNMHDH.PHCFJDNCHII().Killed += BJGCPDNMHDH.NMNCDNBPLHN;
				BJGCPDNMHDH.IMHLCOJKELJ();
				Singleton<BotManager>.instance.PrepareBotForTutorial(BJGCPDNMHDH.NLAKCKMCOMN.JPMHIGNOPBL);
				BJGCPDNMHDH.NLAKCKMCOMN.InitPlayer();
				PNBNBGCNMCF = BJGCPDNMHDH.NLAKCKMCOMN.JPMHIGNOPBL;
				PNBNBGCNMCF.enabled = true;
				CardManager.instance.ClearCardsForGame();
				GameLoginManager.instance.CheckGpgsOnTutorialStart();
				if (TutorialManagerStage2.instance.isTutorialRunning || TutorialManagerStage3.instance.data.started)
				{
					FABFPMKKFJK = TutorialManagerStage2.instance.isTutorialRunning;
					UnityEngine.Debug.Log("AdZone");
					TutorialManagerStage2.instance.FinishTutorial();
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("warp_movement");
					TutorialManagerStage3.instance.StartTutorial(FABFPMKKFJK);
					CardManager.instance.cardsForGame.Clear();
					TutorialManagerStage2.instance.EquipTutorialUnitAfterSkipTutorial();
					PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII = CardManager.instance.selectedCards;
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: false));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				if (TutorialManagerStage1.instance.isTutorialRunning || TutorialManagerStage2.instance.data.started)
				{
					bool isTutorialRunning = TutorialManagerStage1.instance.isTutorialRunning;
					UnityEngine.Debug.Log("#VAVRO# switch to DM OFFLINE");
					TutorialManagerStage1.instance.FinishTutorial();
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("{0} {1}");
					TutorialManagerStage2.instance.StartTutorial(isTutorialRunning);
				}
				else
				{
					UnityEngine.Debug.Log("offerMult");
					TutorialManagerStage1.instance.StartTutorial(isContinue: false);
				}
				goto case 4u;
			case 2u:
				PHDOCKCBJOF = new WaitForSeconds(1959f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 3u:
				Singleton<SoundsManager3D>.instance.LOBFOCCGGHB();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.LMPNIBKNJKP(BJGCPDNMHDH.myUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 4u:
				PHDOCKCBJOF = new WaitForSeconds(211f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 5u:
				LoadingDialog.Hide();
				if (Singleton<GameController>.instance.ICINKELJCAH())
				{
					BJGCPDNMHDH.PLIGGFJCAPA().JLMDEMFIHCA().LIEDNEJPLMA = 5;
					SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-69), 1199f);
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(1817f));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				else
				{
					Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<GameStartScreen>.instance);
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.HIFIIAIAJKP());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				break;
			case 7u:
				PHDOCKCBJOF = new WaitForSeconds(1245f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 6u:
			case 8u:
				Time.timeScale = 541f;
				BJGCPDNMHDH.time = 1605f;
				BJGCPDNMHDH.MMCKLPHNMMN = true;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object BMGHJKFMKJE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HMILEBCNNCP()
		{
			return PHDOCKCBJOF;
		}

		public void MPKODAJAPFD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void MEKLPMCIMBH()
		{
			throw new NotSupportedException();
		}

		public void HHPHMIJOAPL()
		{
			throw new NotSupportedException();
		}

		public void IMFLNKIMEFA()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GPKBICHIBHF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KLECLPIKEJK()
		{
			return PHDOCKCBJOF;
		}

		public void CFDAGFGOOIE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CGIBLCGGMJM()
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
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.MCMLNCLLBPA());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<ArmyPreviewCamera>.instance.LCIFJLNADFP(BJGCPDNMHDH.JJKLKPKMHJO(), PNDNEMDPFHC: true);
				PlayerController.JFGDAKMCJAM.Clear();
				UnityEngine.Debug.Log("_MIN_");
				MCCLPJGMIDG = GHPGNELIDBM.Allies;
				JJLBIPJDBAG = BJGCPDNMHDH.KBDJJAGKHNI(MCCLPJGMIDG);
				BJGCPDNMHDH.PHCFJDNCHII().fraction = MCCLPJGMIDG;
				BJGCPDNMHDH.PHCFJDNCHII().MoveTo(JJLBIPJDBAG.point.transform.position, JJLBIPJDBAG.point.transform.rotation);
				BJGCPDNMHDH.PLIGGFJCAPA().HCOKNKCCPEK(JJLBIPJDBAG);
				BJGCPDNMHDH.AAIEPHNDCJP.EHHHBEMKGOE = CHEIFOOIMEH.LGIDNJCHMBC();
				PlayerController.OGMBJPKOPCB = BJGCPDNMHDH.JJKLKPKMHJO();
				PlayerController.JFGDAKMCJAM[0] = BJGCPDNMHDH.AAIEPHNDCJP;
				BJGCPDNMHDH.PLIGGFJCAPA().NAGAHNHAKBJ = 1;
				BJGCPDNMHDH.PHCFJDNCHII().DMHKCCPPODF();
				BJGCPDNMHDH.AAIEPHNDCJP.DIOEINBFJBG(BJGCPDNMHDH.CHEDFKIPJFF);
				BJGCPDNMHDH.AAIEPHNDCJP.FDHJCAGOFKN(BJGCPDNMHDH.CHEDFKIPJFF);
				BJGCPDNMHDH.IMHLCOJKELJ();
				Singleton<BotManager>.instance.DDLKOAIFIJM(BJGCPDNMHDH.NLAKCKMCOMN.JPMHIGNOPBL);
				BJGCPDNMHDH.NLAKCKMCOMN.DMHKCCPPODF();
				PNBNBGCNMCF = BJGCPDNMHDH.NLAKCKMCOMN.JPMHIGNOPBL;
				PNBNBGCNMCF.enabled = true;
				CardManager.instance.ClearCardsForGame();
				GameLoginManager.instance.CheckGpgsOnTutorialStart();
				if (TutorialManagerStage2.instance.isTutorialRunning || TutorialManagerStage3.instance.data.started)
				{
					FABFPMKKFJK = TutorialManagerStage2.instance.isTutorialRunning;
					UnityEngine.Debug.Log("ID_EXPIRED");
					TutorialManagerStage2.instance.FinishTutorial();
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("test_searchString");
					TutorialManagerStage3.instance.StartTutorial(FABFPMKKFJK);
					CardManager.instance.cardsForGame.Clear();
					TutorialManagerStage2.instance.EquipTutorialUnitAfterSkipTutorial();
					PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII = CardManager.instance.selectedCards;
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				if (TutorialManagerStage1.instance.isTutorialRunning || TutorialManagerStage2.instance.data.started)
				{
					bool isTutorialRunning = TutorialManagerStage1.instance.isTutorialRunning;
					UnityEngine.Debug.Log("ID_SELECTONEUNIT");
					TutorialManagerStage1.instance.FinishTutorial();
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Bad Player Visuals!");
					TutorialManagerStage2.instance.StartTutorial(isTutorialRunning);
				}
				else
				{
					UnityEngine.Debug.Log("ID_YOUVEENTEREDALEAGUE");
					TutorialManagerStage1.instance.StartTutorial(isContinue: false);
				}
				goto case 4u;
			case 2u:
				PHDOCKCBJOF = new WaitForSeconds(397f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 3u:
				Singleton<SoundsManager3D>.instance.AAFOKCOECGJ();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.IJEIKPBIJPE(BJGCPDNMHDH.myUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 4u:
				PHDOCKCBJOF = new WaitForSeconds(583f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 5u:
				LoadingDialog.Hide();
				if (Singleton<GameController>.instance.ICINKELJCAH())
				{
					BJGCPDNMHDH.PLIGGFJCAPA().BEIIOAIJMFK().LIEDNEJPLMA = 7;
					SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-1), 1609f);
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(1363f));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				else
				{
					Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<GameStartScreen>.instance);
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.StartBeginAnimation());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				break;
			case 7u:
				PHDOCKCBJOF = new WaitForSeconds(396f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 6u:
			case 8u:
				Time.timeScale = 1495f;
				BJGCPDNMHDH.time = 465f;
				BJGCPDNMHDH.MMCKLPHNMMN = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object OJEDLKAFEIN()
		{
			return PHDOCKCBJOF;
		}

		public void JCDBOCPAKEC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void LEAAOAKKLAJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void KIPDKEKMDFE()
		{
			throw new NotSupportedException();
		}

		public bool LPCBKGKFNFD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.BIFELDOOCNM());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<ArmyPreviewCamera>.instance.KIONJHBCIBE(BJGCPDNMHDH.AAIEPHNDCJP, PNDNEMDPFHC: false, PlayerTexturePool.DFJJOANIJID.Card);
				PlayerController.JFGDAKMCJAM.Clear();
				UnityEngine.Debug.Log("LastUpdate");
				MCCLPJGMIDG = (GHPGNELIDBM)6;
				JJLBIPJDBAG = BJGCPDNMHDH.PKMFODGDMON(MCCLPJGMIDG);
				BJGCPDNMHDH.JJKLKPKMHJO().fraction = MCCLPJGMIDG;
				BJGCPDNMHDH.PLIGGFJCAPA().MoveTo(JJLBIPJDBAG.point.transform.position, JJLBIPJDBAG.point.transform.rotation);
				BJGCPDNMHDH.PLIGGFJCAPA().HCOKNKCCPEK(JJLBIPJDBAG);
				BJGCPDNMHDH.PHCFJDNCHII().EHHHBEMKGOE = CHEIFOOIMEH.NLCGDAFBFNE();
				PlayerController.OGMBJPKOPCB = BJGCPDNMHDH.PHCFJDNCHII();
				PlayerController.JFGDAKMCJAM[1] = BJGCPDNMHDH.PHCFJDNCHII();
				BJGCPDNMHDH.AAIEPHNDCJP.NAGAHNHAKBJ = 0;
				BJGCPDNMHDH.JJKLKPKMHJO().InitPlayer();
				BJGCPDNMHDH.PHCFJDNCHII().CMBKMOHOAGD(BJGCPDNMHDH.PCJPIKKLIDK);
				BJGCPDNMHDH.PLIGGFJCAPA().FFEDMMENHFA(BJGCPDNMHDH.CHEDFKIPJFF);
				BJGCPDNMHDH.LAHLHAMCFAM();
				Singleton<BotManager>.instance.DDLKOAIFIJM(BJGCPDNMHDH.NLAKCKMCOMN.JPMHIGNOPBL);
				BJGCPDNMHDH.NLAKCKMCOMN.DMHKCCPPODF();
				PNBNBGCNMCF = BJGCPDNMHDH.NLAKCKMCOMN.JPMHIGNOPBL;
				PNBNBGCNMCF.enabled = true;
				CardManager.instance.ClearCardsForGame();
				GameLoginManager.instance.CheckGpgsOnTutorialStart();
				if (TutorialManagerStage2.instance.isTutorialRunning || TutorialManagerStage3.instance.data.started)
				{
					FABFPMKKFJK = TutorialManagerStage2.instance.isTutorialRunning;
					UnityEngine.Debug.Log("SetUpShieldNetwork");
					TutorialManagerStage2.instance.FinishTutorial();
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(", response: ");
					TutorialManagerStage3.instance.StartTutorial(FABFPMKKFJK);
					CardManager.instance.cardsForGame.Clear();
					TutorialManagerStage2.instance.EquipTutorialUnitAfterSkipTutorial();
					PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII = CardManager.instance.selectedCards;
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (TutorialManagerStage1.instance.isTutorialRunning || TutorialManagerStage2.instance.data.started)
				{
					bool isTutorialRunning = TutorialManagerStage1.instance.isTutorialRunning;
					UnityEngine.Debug.Log("ID_READYTIME");
					TutorialManagerStage1.instance.FinishTutorial();
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_WARNING_ACCOUNTALREADYCREATED");
					TutorialManagerStage2.instance.StartTutorial(isTutorialRunning);
				}
				else
				{
					UnityEngine.Debug.Log("menu-gold");
					TutorialManagerStage1.instance.StartTutorial(isContinue: true);
				}
				goto case 4u;
			case 2u:
				PHDOCKCBJOF = new WaitForSeconds(951f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 3u:
				Singleton<SoundsManager3D>.instance.LoadSounds();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.NLIALMAJDAF(BJGCPDNMHDH.myUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 4u:
				PHDOCKCBJOF = new WaitForSeconds(742f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 5u:
				LoadingDialog.Hide();
				if (Singleton<GameController>.instance.ICINKELJCAH())
				{
					BJGCPDNMHDH.JJKLKPKMHJO().weaponInventory.LIEDNEJPLMA = 8;
					SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-97), 1803f);
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(306f));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<GameStartScreen>.instance);
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.HIFIIAIAJKP());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				break;
			case 7u:
				PHDOCKCBJOF = new WaitForSeconds(853f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 6u:
			case 8u:
				Time.timeScale = 260f;
				BJGCPDNMHDH.time = 1641f;
				BJGCPDNMHDH.MMCKLPHNMMN = true;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public bool DLAPDOPMBNE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.BIFELDOOCNM());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<ArmyPreviewCamera>.instance.LCIFJLNADFP(BJGCPDNMHDH.PHCFJDNCHII(), PNDNEMDPFHC: false);
				PlayerController.JFGDAKMCJAM.Clear();
				UnityEngine.Debug.Log("Shots_Fired");
				MCCLPJGMIDG = GHPGNELIDBM.Enemies;
				JJLBIPJDBAG = BJGCPDNMHDH.KBDJJAGKHNI(MCCLPJGMIDG);
				BJGCPDNMHDH.JJKLKPKMHJO().fraction = MCCLPJGMIDG;
				BJGCPDNMHDH.JJKLKPKMHJO().MoveTo(JJLBIPJDBAG.point.transform.position, JJLBIPJDBAG.point.transform.rotation);
				BJGCPDNMHDH.JJKLKPKMHJO().HCOKNKCCPEK(JJLBIPJDBAG);
				BJGCPDNMHDH.AAIEPHNDCJP.EHHHBEMKGOE = CHEIFOOIMEH.LLOHKIKGGLF();
				PlayerController.OGMBJPKOPCB = BJGCPDNMHDH.PHCFJDNCHII();
				PlayerController.JFGDAKMCJAM[1] = BJGCPDNMHDH.JJKLKPKMHJO();
				BJGCPDNMHDH.AAIEPHNDCJP.NAGAHNHAKBJ = 0;
				BJGCPDNMHDH.JJKLKPKMHJO().DMHKCCPPODF();
				BJGCPDNMHDH.JJKLKPKMHJO().Killed -= BJGCPDNMHDH.NMNCDNBPLHN;
				BJGCPDNMHDH.AAIEPHNDCJP.Killed += BJGCPDNMHDH.PCJPIKKLIDK;
				BJGCPDNMHDH.LAHLHAMCFAM();
				Singleton<BotManager>.instance.LOOGALLHLMO(BJGCPDNMHDH.NLAKCKMCOMN.JPMHIGNOPBL);
				BJGCPDNMHDH.NLAKCKMCOMN.InitPlayer();
				PNBNBGCNMCF = BJGCPDNMHDH.NLAKCKMCOMN.JPMHIGNOPBL;
				PNBNBGCNMCF.enabled = true;
				CardManager.instance.ClearCardsForGame();
				GameLoginManager.instance.CheckGpgsOnTutorialStart();
				if (TutorialManagerStage2.instance.isTutorialRunning || TutorialManagerStage3.instance.data.started)
				{
					FABFPMKKFJK = TutorialManagerStage2.instance.isTutorialRunning;
					UnityEngine.Debug.Log("{0} Emblem {1} LVL {2}");
					TutorialManagerStage2.instance.FinishTutorial();
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("StartingGold");
					TutorialManagerStage3.instance.StartTutorial(FABFPMKKFJK);
					CardManager.instance.cardsForGame.Clear();
					TutorialManagerStage2.instance.EquipTutorialUnitAfterSkipTutorial();
					PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII = CardManager.instance.selectedCards;
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: false));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (TutorialManagerStage1.instance.isTutorialRunning || TutorialManagerStage2.instance.data.started)
				{
					bool isTutorialRunning = TutorialManagerStage1.instance.isTutorialRunning;
					UnityEngine.Debug.Log("SET HP: ");
					TutorialManagerStage1.instance.FinishTutorial();
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("BeginnersLeague");
					TutorialManagerStage2.instance.StartTutorial(isTutorialRunning);
				}
				else
				{
					UnityEngine.Debug.Log("ID_PLAYBATTLETOENTERBRONZELEAGUE");
					TutorialManagerStage1.instance.StartTutorial(isContinue: true);
				}
				goto case 4u;
			case 2u:
				PHDOCKCBJOF = new WaitForSeconds(1381f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 3u:
				Singleton<SoundsManager3D>.instance.GCOKDIOKPKG();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.FFMAGHFENAP(BJGCPDNMHDH.myUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 4u:
				PHDOCKCBJOF = new WaitForSeconds(220f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 5u:
				LoadingDialog.Hide();
				if (Singleton<GameController>.instance.OJHIKLMNHNE())
				{
					BJGCPDNMHDH.PHCFJDNCHII().FMKGGADDHJK().LIEDNEJPLMA = 2;
					SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-122), 398f);
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(466f));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				else
				{
					Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<GameStartScreen>.instance);
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.StartBeginAnimation());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				break;
			case 7u:
				PHDOCKCBJOF = new WaitForSeconds(1810f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 6u:
			case 8u:
				Time.timeScale = 990f;
				BJGCPDNMHDH.time = 122f;
				BJGCPDNMHDH.MMCKLPHNMMN = true;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
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
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.LoadTutorialCoroutine());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				Singleton<ArmyPreviewCamera>.instance.LCIFJLNADFP(BJGCPDNMHDH.PLIGGFJCAPA(), PNDNEMDPFHC: false, PlayerTexturePool.DFJJOANIJID.Card);
				PlayerController.JFGDAKMCJAM.Clear();
				UnityEngine.Debug.Log("ID_YOUAREPREMIUMMEMBERWITHBENEFITS");
				MCCLPJGMIDG = (GHPGNELIDBM)8;
				JJLBIPJDBAG = BJGCPDNMHDH.KBDJJAGKHNI(MCCLPJGMIDG);
				BJGCPDNMHDH.PHCFJDNCHII().fraction = MCCLPJGMIDG;
				BJGCPDNMHDH.JJKLKPKMHJO().MoveTo(JJLBIPJDBAG.point.transform.position, JJLBIPJDBAG.point.transform.rotation);
				BJGCPDNMHDH.AAIEPHNDCJP.OCMDJMNFNKF(JJLBIPJDBAG);
				BJGCPDNMHDH.JJKLKPKMHJO().EHHHBEMKGOE = CHEIFOOIMEH.LLOHKIKGGLF();
				PlayerController.OGMBJPKOPCB = BJGCPDNMHDH.JJKLKPKMHJO();
				PlayerController.JFGDAKMCJAM[0] = BJGCPDNMHDH.JJKLKPKMHJO();
				BJGCPDNMHDH.AAIEPHNDCJP.NAGAHNHAKBJ = 0;
				BJGCPDNMHDH.PLIGGFJCAPA().DMHKCCPPODF();
				BJGCPDNMHDH.AAIEPHNDCJP.Killed -= BJGCPDNMHDH.NMNCDNBPLHN;
				BJGCPDNMHDH.PLIGGFJCAPA().FFEDMMENHFA(BJGCPDNMHDH.CHEDFKIPJFF);
				BJGCPDNMHDH.IMHLCOJKELJ();
				Singleton<BotManager>.instance.OCEPDEABOHJ(BJGCPDNMHDH.NLAKCKMCOMN.JPMHIGNOPBL);
				BJGCPDNMHDH.NLAKCKMCOMN.InitPlayer();
				PNBNBGCNMCF = BJGCPDNMHDH.NLAKCKMCOMN.JPMHIGNOPBL;
				PNBNBGCNMCF.enabled = true;
				CardManager.instance.ClearCardsForGame();
				GameLoginManager.instance.CheckGpgsOnTutorialStart();
				if (TutorialManagerStage2.instance.isTutorialRunning || TutorialManagerStage3.instance.data.started)
				{
					FABFPMKKFJK = TutorialManagerStage2.instance.isTutorialRunning;
					UnityEngine.Debug.Log("SHOW WAR ARENA DIALOG!!");
					TutorialManagerStage2.instance.FinishTutorial();
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_DAILYMISSIONX");
					TutorialManagerStage3.instance.StartTutorial(FABFPMKKFJK);
					CardManager.instance.cardsForGame.Clear();
					TutorialManagerStage2.instance.EquipTutorialUnitAfterSkipTutorial();
					PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII = CardManager.instance.selectedCards;
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: false));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (TutorialManagerStage1.instance.isTutorialRunning || TutorialManagerStage2.instance.data.started)
				{
					bool isTutorialRunning = TutorialManagerStage1.instance.isTutorialRunning;
					UnityEngine.Debug.Log("subtitle");
					TutorialManagerStage1.instance.FinishTutorial();
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("<");
					TutorialManagerStage2.instance.StartTutorial(isTutorialRunning);
				}
				else
				{
					UnityEngine.Debug.Log(" ");
					TutorialManagerStage1.instance.StartTutorial(isContinue: true);
				}
				goto case 4u;
			case 2u:
				PHDOCKCBJOF = new WaitForSeconds(733f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 3u:
				Singleton<SoundsManager3D>.instance.AAFOKCOECGJ();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.EGBFNBAHFAH(BJGCPDNMHDH.myUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 4u:
				PHDOCKCBJOF = new WaitForSeconds(1415f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 5u:
				LoadingDialog.Hide();
				if (Singleton<GameController>.instance.ICINKELJCAH())
				{
					BJGCPDNMHDH.PLIGGFJCAPA().BEIIOAIJMFK().LIEDNEJPLMA = 1;
					SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-112), 68f);
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(1560f));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				else
				{
					Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<GameStartScreen>.instance);
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.StartBeginAnimation());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				break;
			case 7u:
				PHDOCKCBJOF = new WaitForSeconds(1957f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 6u:
			case 8u:
				Time.timeScale = 1600f;
				BJGCPDNMHDH.time = 625f;
				BJGCPDNMHDH.MMCKLPHNMMN = true;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object FKPDNNMENFD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ADNCCLOOEAD()
		{
			return PHDOCKCBJOF;
		}

		public bool GFIEJKOANFL()
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
				Singleton<ArmyPreviewCamera>.instance.MDCPOGFDCPC(BJGCPDNMHDH.PLIGGFJCAPA(), PNDNEMDPFHC: true, PlayerTexturePool.DFJJOANIJID.Card);
				PlayerController.JFGDAKMCJAM.Clear();
				UnityEngine.Debug.Log("LevelName");
				MCCLPJGMIDG = (GHPGNELIDBM)6;
				JJLBIPJDBAG = BJGCPDNMHDH.AGMHNCNKJHP(MCCLPJGMIDG);
				BJGCPDNMHDH.PHCFJDNCHII().fraction = MCCLPJGMIDG;
				BJGCPDNMHDH.AAIEPHNDCJP.MoveTo(JJLBIPJDBAG.point.transform.position, JJLBIPJDBAG.point.transform.rotation);
				BJGCPDNMHDH.AAIEPHNDCJP.HCOKNKCCPEK(JJLBIPJDBAG);
				BJGCPDNMHDH.JJKLKPKMHJO().EHHHBEMKGOE = CHEIFOOIMEH.PNPIGMOACFK();
				PlayerController.OGMBJPKOPCB = BJGCPDNMHDH.PHCFJDNCHII();
				PlayerController.JFGDAKMCJAM[0] = BJGCPDNMHDH.PHCFJDNCHII();
				BJGCPDNMHDH.AAIEPHNDCJP.NAGAHNHAKBJ = 0;
				BJGCPDNMHDH.AAIEPHNDCJP.DMHKCCPPODF();
				BJGCPDNMHDH.PLIGGFJCAPA().DIOEINBFJBG(BJGCPDNMHDH.PCJPIKKLIDK);
				BJGCPDNMHDH.PLIGGFJCAPA().Killed += BJGCPDNMHDH.NMNCDNBPLHN;
				BJGCPDNMHDH.LCGHIOPCLLF();
				Singleton<BotManager>.instance.IOCODOGFKNH(BJGCPDNMHDH.NLAKCKMCOMN.JPMHIGNOPBL);
				BJGCPDNMHDH.NLAKCKMCOMN.InitPlayer();
				PNBNBGCNMCF = BJGCPDNMHDH.NLAKCKMCOMN.JPMHIGNOPBL;
				PNBNBGCNMCF.enabled = false;
				CardManager.instance.ClearCardsForGame();
				GameLoginManager.instance.CheckGpgsOnTutorialStart();
				if (TutorialManagerStage2.instance.isTutorialRunning || TutorialManagerStage3.instance.data.started)
				{
					FABFPMKKFJK = TutorialManagerStage2.instance.isTutorialRunning;
					UnityEngine.Debug.Log("LevelGold");
					TutorialManagerStage2.instance.FinishTutorial();
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Chat: Disconnect");
					TutorialManagerStage3.instance.StartTutorial(FABFPMKKFJK);
					CardManager.instance.cardsForGame.Clear();
					TutorialManagerStage2.instance.EquipTutorialUnitAfterSkipTutorial();
					PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII = CardManager.instance.selectedCards;
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: false));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (TutorialManagerStage1.instance.isTutorialRunning || TutorialManagerStage2.instance.data.started)
				{
					bool isTutorialRunning = TutorialManagerStage1.instance.isTutorialRunning;
					UnityEngine.Debug.Log("ID_GUI_EQUIPPED");
					TutorialManagerStage1.instance.FinishTutorial();
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_STATE_WAITINGFOROPPONENT");
					TutorialManagerStage2.instance.StartTutorial(isTutorialRunning);
				}
				else
				{
					UnityEngine.Debug.Log("\t");
					TutorialManagerStage1.instance.StartTutorial(isContinue: true);
				}
				goto case 4u;
			case 2u:
				PHDOCKCBJOF = new WaitForSeconds(1763f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 3u:
				Singleton<SoundsManager3D>.instance.GCOKDIOKPKG();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.LoadMineUpgrades(BJGCPDNMHDH.myUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 4u:
				PHDOCKCBJOF = new WaitForSeconds(1481f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 5u:
				LoadingDialog.Hide();
				if (Singleton<GameController>.instance.ICINKELJCAH())
				{
					BJGCPDNMHDH.AAIEPHNDCJP.FMKGGADDHJK().LIEDNEJPLMA = 4;
					SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-6), 1541f);
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(150f));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<GameStartScreen>.instance);
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.HIFIIAIAJKP());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				break;
			case 7u:
				PHDOCKCBJOF = new WaitForSeconds(1909f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 6u:
			case 8u:
				Time.timeScale = 1035f;
				BJGCPDNMHDH.time = 494f;
				BJGCPDNMHDH.MMCKLPHNMMN = false;
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
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.BIFELDOOCNM());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				Singleton<ArmyPreviewCamera>.instance.BDHBFHGBDOK(BJGCPDNMHDH.JJKLKPKMHJO(), PNDNEMDPFHC: false, PlayerTexturePool.DFJJOANIJID.Card);
				PlayerController.JFGDAKMCJAM.Clear();
				UnityEngine.Debug.Log("setUserName");
				MCCLPJGMIDG = GHPGNELIDBM.Enemies;
				JJLBIPJDBAG = BJGCPDNMHDH.CHCPANHGABC(MCCLPJGMIDG);
				BJGCPDNMHDH.AAIEPHNDCJP.fraction = MCCLPJGMIDG;
				BJGCPDNMHDH.AAIEPHNDCJP.MoveTo(JJLBIPJDBAG.point.transform.position, JJLBIPJDBAG.point.transform.rotation);
				BJGCPDNMHDH.PHCFJDNCHII().CMKNJFHHOHA(JJLBIPJDBAG);
				BJGCPDNMHDH.PLIGGFJCAPA().EHHHBEMKGOE = CHEIFOOIMEH.FNKEPILGJAO();
				PlayerController.OGMBJPKOPCB = BJGCPDNMHDH.JJKLKPKMHJO();
				PlayerController.JFGDAKMCJAM[1] = BJGCPDNMHDH.PLIGGFJCAPA();
				BJGCPDNMHDH.JJKLKPKMHJO().NAGAHNHAKBJ = 0;
				BJGCPDNMHDH.AAIEPHNDCJP.InitPlayer();
				BJGCPDNMHDH.JJKLKPKMHJO().Killed -= BJGCPDNMHDH.NMNCDNBPLHN;
				BJGCPDNMHDH.AAIEPHNDCJP.FFEDMMENHFA(BJGCPDNMHDH.NMNCDNBPLHN);
				BJGCPDNMHDH.LCGHIOPCLLF();
				Singleton<BotManager>.instance.OCEPDEABOHJ(BJGCPDNMHDH.NLAKCKMCOMN.JPMHIGNOPBL);
				BJGCPDNMHDH.NLAKCKMCOMN.InitPlayer();
				PNBNBGCNMCF = BJGCPDNMHDH.NLAKCKMCOMN.JPMHIGNOPBL;
				PNBNBGCNMCF.enabled = true;
				CardManager.instance.ClearCardsForGame();
				GameLoginManager.instance.CheckGpgsOnTutorialStart();
				if (TutorialManagerStage2.instance.isTutorialRunning || TutorialManagerStage3.instance.data.started)
				{
					FABFPMKKFJK = TutorialManagerStage2.instance.isTutorialRunning;
					UnityEngine.Debug.Log("01 ");
					TutorialManagerStage2.instance.FinishTutorial();
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Sniper_Tutorial_Duration");
					TutorialManagerStage3.instance.StartTutorial(FABFPMKKFJK);
					CardManager.instance.cardsForGame.Clear();
					TutorialManagerStage2.instance.EquipTutorialUnitAfterSkipTutorial();
					PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII = CardManager.instance.selectedCards;
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				if (TutorialManagerStage1.instance.isTutorialRunning || TutorialManagerStage2.instance.data.started)
				{
					bool isTutorialRunning = TutorialManagerStage1.instance.isTutorialRunning;
					UnityEngine.Debug.Log("IsWarArena");
					TutorialManagerStage1.instance.FinishTutorial();
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("AdDidShow(");
					TutorialManagerStage2.instance.StartTutorial(isTutorialRunning);
				}
				else
				{
					UnityEngine.Debug.Log("iconParent");
					TutorialManagerStage1.instance.StartTutorial(isContinue: false);
				}
				goto case 4u;
			case 2u:
				PHDOCKCBJOF = new WaitForSeconds(213f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 3u:
				Singleton<SoundsManager3D>.instance.GCOKDIOKPKG();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.PHLEEDHECMI(BJGCPDNMHDH.myUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 4u:
				PHDOCKCBJOF = new WaitForSeconds(1595f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 5u:
				LoadingDialog.Hide();
				if (Singleton<GameController>.instance.OJHIKLMNHNE())
				{
					BJGCPDNMHDH.JJKLKPKMHJO().weaponInventory.LIEDNEJPLMA = 7;
					SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-8), 1777f);
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(352f));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				else
				{
					Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<GameStartScreen>.instance);
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.JGDIFKHNHGE());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				break;
			case 7u:
				PHDOCKCBJOF = new WaitForSeconds(1609f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 6u:
			case 8u:
				Time.timeScale = 1252f;
				BJGCPDNMHDH.time = 1262f;
				BJGCPDNMHDH.MMCKLPHNMMN = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object IHAJFNHBAHB()
		{
			return PHDOCKCBJOF;
		}

		public void MBCPJPIHNIK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BGLDNJLBIKM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FKKBFFHMEME()
		{
			return PHDOCKCBJOF;
		}

		public void JJOAHIOBOPO()
		{
			throw new NotSupportedException();
		}

		public void NAKEBJFGMII()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void DBEMHFEBPFM()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool JICHKPANPEE()
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
				Singleton<ArmyPreviewCamera>.instance.RenderToTexture(BJGCPDNMHDH.PLIGGFJCAPA(), PNDNEMDPFHC: false);
				PlayerController.JFGDAKMCJAM.Clear();
				UnityEngine.Debug.Log("ID_YOUHAVENOSILVERWARCARDSAVAILABLE");
				MCCLPJGMIDG = GHPGNELIDBM.None;
				JJLBIPJDBAG = BJGCPDNMHDH.AGMHNCNKJHP(MCCLPJGMIDG);
				BJGCPDNMHDH.PLIGGFJCAPA().fraction = MCCLPJGMIDG;
				BJGCPDNMHDH.JJKLKPKMHJO().MoveTo(JJLBIPJDBAG.point.transform.position, JJLBIPJDBAG.point.transform.rotation);
				BJGCPDNMHDH.PLIGGFJCAPA().OCMDJMNFNKF(JJLBIPJDBAG);
				BJGCPDNMHDH.AAIEPHNDCJP.EHHHBEMKGOE = CHEIFOOIMEH.KPGNGIOHAMA();
				PlayerController.OGMBJPKOPCB = BJGCPDNMHDH.JJKLKPKMHJO();
				PlayerController.JFGDAKMCJAM[0] = BJGCPDNMHDH.JJKLKPKMHJO();
				BJGCPDNMHDH.PLIGGFJCAPA().NAGAHNHAKBJ = 1;
				BJGCPDNMHDH.PHCFJDNCHII().DMHKCCPPODF();
				BJGCPDNMHDH.JJKLKPKMHJO().Killed -= BJGCPDNMHDH.NMNCDNBPLHN;
				BJGCPDNMHDH.PHCFJDNCHII().FDHJCAGOFKN(BJGCPDNMHDH.PCJPIKKLIDK);
				BJGCPDNMHDH.LCGHIOPCLLF();
				Singleton<BotManager>.instance.OCEPDEABOHJ(BJGCPDNMHDH.NLAKCKMCOMN.JPMHIGNOPBL);
				BJGCPDNMHDH.NLAKCKMCOMN.InitPlayer();
				PNBNBGCNMCF = BJGCPDNMHDH.NLAKCKMCOMN.JPMHIGNOPBL;
				PNBNBGCNMCF.enabled = true;
				CardManager.instance.ClearCardsForGame();
				GameLoginManager.instance.CheckGpgsOnTutorialStart();
				if (TutorialManagerStage2.instance.isTutorialRunning || TutorialManagerStage3.instance.data.started)
				{
					FABFPMKKFJK = TutorialManagerStage2.instance.isTutorialRunning;
					UnityEngine.Debug.Log("RewardGold");
					TutorialManagerStage2.instance.FinishTutorial();
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("com/google/android/gms/common/api/Status");
					TutorialManagerStage3.instance.StartTutorial(FABFPMKKFJK);
					CardManager.instance.cardsForGame.Clear();
					TutorialManagerStage2.instance.EquipTutorialUnitAfterSkipTutorial();
					PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII = CardManager.instance.selectedCards;
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: false));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				if (TutorialManagerStage1.instance.isTutorialRunning || TutorialManagerStage2.instance.data.started)
				{
					bool isTutorialRunning = TutorialManagerStage1.instance.isTutorialRunning;
					UnityEngine.Debug.Log(" {0}{1}");
					TutorialManagerStage1.instance.FinishTutorial();
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Card_2_Played");
					TutorialManagerStage2.instance.StartTutorial(isTutorialRunning);
				}
				else
				{
					UnityEngine.Debug.Log("\"{0}\":");
					TutorialManagerStage1.instance.StartTutorial(isContinue: false);
				}
				goto case 4u;
			case 2u:
				PHDOCKCBJOF = new WaitForSeconds(359f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 3u:
				Singleton<SoundsManager3D>.instance.IBAHNGKDCPA();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.ALCJENMGIMJ(BJGCPDNMHDH.myUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 4u:
				PHDOCKCBJOF = new WaitForSeconds(1056f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 5u:
				LoadingDialog.Hide();
				if (Singleton<GameController>.instance.OJHIKLMNHNE())
				{
					BJGCPDNMHDH.PHCFJDNCHII().weaponInventory.LIEDNEJPLMA = 4;
					SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-104), 1508f);
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(1278f));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				else
				{
					Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<GameStartScreen>.instance);
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.JGDIFKHNHGE());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				break;
			case 7u:
				PHDOCKCBJOF = new WaitForSeconds(1085f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 6u:
			case 8u:
				Time.timeScale = 1869f;
				BJGCPDNMHDH.time = 1716f;
				BJGCPDNMHDH.MMCKLPHNMMN = false;
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
		private object ALJCNLJGABF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FLJNAIIJAFO()
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
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.NDDANOBHOPG());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<ArmyPreviewCamera>.instance.DIMPHNLEKHG(BJGCPDNMHDH.PLIGGFJCAPA(), PNDNEMDPFHC: true, PlayerTexturePool.DFJJOANIJID.Card);
				PlayerController.JFGDAKMCJAM.Clear();
				UnityEngine.Debug.Log("BoughtIndex");
				MCCLPJGMIDG = (GHPGNELIDBM)3;
				JJLBIPJDBAG = BJGCPDNMHDH.LLBHFHGMECD(MCCLPJGMIDG);
				BJGCPDNMHDH.PHCFJDNCHII().fraction = MCCLPJGMIDG;
				BJGCPDNMHDH.PLIGGFJCAPA().MoveTo(JJLBIPJDBAG.point.transform.position, JJLBIPJDBAG.point.transform.rotation);
				BJGCPDNMHDH.AAIEPHNDCJP.CMKNJFHHOHA(JJLBIPJDBAG);
				BJGCPDNMHDH.AAIEPHNDCJP.EHHHBEMKGOE = CHEIFOOIMEH.FNKEPILGJAO();
				PlayerController.OGMBJPKOPCB = BJGCPDNMHDH.AAIEPHNDCJP;
				PlayerController.JFGDAKMCJAM[1] = BJGCPDNMHDH.JJKLKPKMHJO();
				BJGCPDNMHDH.AAIEPHNDCJP.NAGAHNHAKBJ = 0;
				BJGCPDNMHDH.JJKLKPKMHJO().DMHKCCPPODF();
				BJGCPDNMHDH.PLIGGFJCAPA().DIOEINBFJBG(BJGCPDNMHDH.NMNCDNBPLHN);
				BJGCPDNMHDH.PHCFJDNCHII().FDHJCAGOFKN(BJGCPDNMHDH.NMNCDNBPLHN);
				BJGCPDNMHDH.LAHLHAMCFAM();
				Singleton<BotManager>.instance.OCEPDEABOHJ(BJGCPDNMHDH.NLAKCKMCOMN.JPMHIGNOPBL);
				BJGCPDNMHDH.NLAKCKMCOMN.InitPlayer();
				PNBNBGCNMCF = BJGCPDNMHDH.NLAKCKMCOMN.JPMHIGNOPBL;
				PNBNBGCNMCF.enabled = false;
				CardManager.instance.ClearCardsForGame();
				GameLoginManager.instance.CheckGpgsOnTutorialStart();
				if (TutorialManagerStage2.instance.isTutorialRunning || TutorialManagerStage3.instance.data.started)
				{
					FABFPMKKFJK = TutorialManagerStage2.instance.isTutorialRunning;
					UnityEngine.Debug.Log("Buy as many as you can");
					TutorialManagerStage2.instance.FinishTutorial();
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Warbucks - League:{0} Battle:{1} Extra:{2} Winstreak:{3} (offer mult {4})\n");
					TutorialManagerStage3.instance.StartTutorial(FABFPMKKFJK);
					CardManager.instance.cardsForGame.Clear();
					TutorialManagerStage2.instance.EquipTutorialUnitAfterSkipTutorial();
					PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII = CardManager.instance.selectedCards;
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: false));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				if (TutorialManagerStage1.instance.isTutorialRunning || TutorialManagerStage2.instance.data.started)
				{
					bool isTutorialRunning = TutorialManagerStage1.instance.isTutorialRunning;
					UnityEngine.Debug.Log("ONLY EDITOR FEATURE");
					TutorialManagerStage1.instance.FinishTutorial();
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("InAppHandlerIos: GetProducstsInfo");
					TutorialManagerStage2.instance.StartTutorial(isTutorialRunning);
				}
				else
				{
					UnityEngine.Debug.Log("http://");
					TutorialManagerStage1.instance.StartTutorial(isContinue: true);
				}
				goto case 4u;
			case 2u:
				PHDOCKCBJOF = new WaitForSeconds(1962f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 3u:
				Singleton<SoundsManager3D>.instance.AAFOKCOECGJ();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.HAMMNLGJFON(BJGCPDNMHDH.myUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 4u:
				PHDOCKCBJOF = new WaitForSeconds(1373f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 5u:
				LoadingDialog.Hide();
				if (Singleton<GameController>.instance.isTutorialStage1)
				{
					BJGCPDNMHDH.AAIEPHNDCJP.BEIIOAIJMFK().LIEDNEJPLMA = 3;
					SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-106), 1521f);
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(805f));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<GameStartScreen>.instance);
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.JGDIFKHNHGE());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				break;
			case 7u:
				PHDOCKCBJOF = new WaitForSeconds(1024f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 6u:
			case 8u:
				Time.timeScale = 1766f;
				BJGCPDNMHDH.time = 1267f;
				BJGCPDNMHDH.MMCKLPHNMMN = true;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void NGAGGCFIEGJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HMIFLGCBDCO()
		{
			return PHDOCKCBJOF;
		}

		public void GBGMIJNBLNH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object IHAOBCEALPD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OIBJFPCIHIL()
		{
			return PHDOCKCBJOF;
		}

		public void DLPFJEAMNIO()
		{
			throw new NotSupportedException();
		}

		public void BJHCLGCKJBB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MFNFCFAJKCM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HHHLDCLIFKJ()
		{
			return PHDOCKCBJOF;
		}

		public bool LLOCENNFFFJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.BIFELDOOCNM());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<ArmyPreviewCamera>.instance.LCIFJLNADFP(BJGCPDNMHDH.AAIEPHNDCJP, PNDNEMDPFHC: true);
				PlayerController.JFGDAKMCJAM.Clear();
				UnityEngine.Debug.Log(" NOT OK!\t\t\t\t\t\t");
				MCCLPJGMIDG = (GHPGNELIDBM)8;
				JJLBIPJDBAG = BJGCPDNMHDH.LLBHFHGMECD(MCCLPJGMIDG);
				BJGCPDNMHDH.AAIEPHNDCJP.fraction = MCCLPJGMIDG;
				BJGCPDNMHDH.PLIGGFJCAPA().MoveTo(JJLBIPJDBAG.point.transform.position, JJLBIPJDBAG.point.transform.rotation);
				BJGCPDNMHDH.AAIEPHNDCJP.HCOKNKCCPEK(JJLBIPJDBAG);
				BJGCPDNMHDH.JJKLKPKMHJO().EHHHBEMKGOE = CHEIFOOIMEH.NLCGDAFBFNE();
				PlayerController.OGMBJPKOPCB = BJGCPDNMHDH.JJKLKPKMHJO();
				PlayerController.JFGDAKMCJAM[1] = BJGCPDNMHDH.AAIEPHNDCJP;
				BJGCPDNMHDH.PLIGGFJCAPA().NAGAHNHAKBJ = 1;
				BJGCPDNMHDH.PLIGGFJCAPA().InitPlayer();
				BJGCPDNMHDH.PHCFJDNCHII().DIOEINBFJBG(BJGCPDNMHDH.PCJPIKKLIDK);
				BJGCPDNMHDH.AAIEPHNDCJP.FFEDMMENHFA(BJGCPDNMHDH.PCJPIKKLIDK);
				BJGCPDNMHDH.LAHLHAMCFAM();
				Singleton<BotManager>.instance.PrepareBotForTutorial(BJGCPDNMHDH.NLAKCKMCOMN.JPMHIGNOPBL);
				BJGCPDNMHDH.NLAKCKMCOMN.InitPlayer();
				PNBNBGCNMCF = BJGCPDNMHDH.NLAKCKMCOMN.JPMHIGNOPBL;
				PNBNBGCNMCF.enabled = true;
				CardManager.instance.ClearCardsForGame();
				GameLoginManager.instance.CheckGpgsOnTutorialStart();
				if (TutorialManagerStage2.instance.isTutorialRunning || TutorialManagerStage3.instance.data.started)
				{
					FABFPMKKFJK = TutorialManagerStage2.instance.isTutorialRunning;
					UnityEngine.Debug.Log("ID_DAILYMISSIONSUNLOCKED");
					TutorialManagerStage2.instance.FinishTutorial();
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("#AccoutCheck# account exist");
					TutorialManagerStage3.instance.StartTutorial(FABFPMKKFJK);
					CardManager.instance.cardsForGame.Clear();
					TutorialManagerStage2.instance.EquipTutorialUnitAfterSkipTutorial();
					PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII = CardManager.instance.selectedCards;
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				if (TutorialManagerStage1.instance.isTutorialRunning || TutorialManagerStage2.instance.data.started)
				{
					bool isTutorialRunning = TutorialManagerStage1.instance.isTutorialRunning;
					UnityEngine.Debug.Log("Buy_Army_Unit_At_Rank");
					TutorialManagerStage1.instance.FinishTutorial();
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Shots_Hits");
					TutorialManagerStage2.instance.StartTutorial(isTutorialRunning);
				}
				else
				{
					UnityEngine.Debug.Log("mapId");
					TutorialManagerStage1.instance.StartTutorial(isContinue: true);
				}
				goto case 4u;
			case 2u:
				PHDOCKCBJOF = new WaitForSeconds(642f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 3u:
				Singleton<SoundsManager3D>.instance.LOBFOCCGGHB();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.NLOKMAOGIDK(BJGCPDNMHDH.myUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 4u:
				PHDOCKCBJOF = new WaitForSeconds(748f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 5u:
				LoadingDialog.Hide();
				if (Singleton<GameController>.instance.isTutorialStage1)
				{
					BJGCPDNMHDH.JJKLKPKMHJO().JLMDEMFIHCA().LIEDNEJPLMA = 5;
					SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.CardPlayed, 654f);
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(1071f));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				else
				{
					Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<GameStartScreen>.instance);
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.JGDIFKHNHGE());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				break;
			case 7u:
				PHDOCKCBJOF = new WaitForSeconds(323f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 6u:
			case 8u:
				Time.timeScale = 1282f;
				BJGCPDNMHDH.time = 1996f;
				BJGCPDNMHDH.MMCKLPHNMMN = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void MNFJGIMMBLE()
		{
			throw new NotSupportedException();
		}

		public bool NIGJJBALHDN()
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
				Singleton<ArmyPreviewCamera>.instance.KIONJHBCIBE(BJGCPDNMHDH.PHCFJDNCHII(), PNDNEMDPFHC: false);
				PlayerController.JFGDAKMCJAM.Clear();
				UnityEngine.Debug.Log("ID_ZEROSECONDS");
				MCCLPJGMIDG = (GHPGNELIDBM)3;
				JJLBIPJDBAG = BJGCPDNMHDH.PKMFODGDMON(MCCLPJGMIDG);
				BJGCPDNMHDH.JJKLKPKMHJO().fraction = MCCLPJGMIDG;
				BJGCPDNMHDH.PHCFJDNCHII().MoveTo(JJLBIPJDBAG.point.transform.position, JJLBIPJDBAG.point.transform.rotation);
				BJGCPDNMHDH.JJKLKPKMHJO().CMKNJFHHOHA(JJLBIPJDBAG);
				BJGCPDNMHDH.JJKLKPKMHJO().EHHHBEMKGOE = CHEIFOOIMEH.AHBIMJAAFIO();
				PlayerController.OGMBJPKOPCB = BJGCPDNMHDH.PHCFJDNCHII();
				PlayerController.JFGDAKMCJAM[0] = BJGCPDNMHDH.PLIGGFJCAPA();
				BJGCPDNMHDH.PHCFJDNCHII().NAGAHNHAKBJ = 0;
				BJGCPDNMHDH.JJKLKPKMHJO().DMHKCCPPODF();
				BJGCPDNMHDH.AAIEPHNDCJP.CMBKMOHOAGD(BJGCPDNMHDH.CHEDFKIPJFF);
				BJGCPDNMHDH.PLIGGFJCAPA().Killed += BJGCPDNMHDH.NMNCDNBPLHN;
				BJGCPDNMHDH.IMHLCOJKELJ();
				Singleton<BotManager>.instance.OCEPDEABOHJ(BJGCPDNMHDH.NLAKCKMCOMN.JPMHIGNOPBL);
				BJGCPDNMHDH.NLAKCKMCOMN.DMHKCCPPODF();
				PNBNBGCNMCF = BJGCPDNMHDH.NLAKCKMCOMN.JPMHIGNOPBL;
				PNBNBGCNMCF.enabled = true;
				CardManager.instance.ClearCardsForGame();
				GameLoginManager.instance.CheckGpgsOnTutorialStart();
				if (TutorialManagerStage2.instance.isTutorialRunning || TutorialManagerStage3.instance.data.started)
				{
					FABFPMKKFJK = TutorialManagerStage2.instance.isTutorialRunning;
					UnityEngine.Debug.Log("ID_TUTORIAL_SNIPER_UP");
					TutorialManagerStage2.instance.FinishTutorial();
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_GUI_EQUIP");
					TutorialManagerStage3.instance.StartTutorial(FABFPMKKFJK);
					CardManager.instance.cardsForGame.Clear();
					TutorialManagerStage2.instance.EquipTutorialUnitAfterSkipTutorial();
					PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII = CardManager.instance.selectedCards;
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				if (TutorialManagerStage1.instance.isTutorialRunning || TutorialManagerStage2.instance.data.started)
				{
					bool isTutorialRunning = TutorialManagerStage1.instance.isTutorialRunning;
					UnityEngine.Debug.Log("\\s");
					TutorialManagerStage1.instance.FinishTutorial();
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("game-neardeath-indicator");
					TutorialManagerStage2.instance.StartTutorial(isTutorialRunning);
				}
				else
				{
					UnityEngine.Debug.Log("SquadId");
					TutorialManagerStage1.instance.StartTutorial(isContinue: true);
				}
				goto case 4u;
			case 2u:
				PHDOCKCBJOF = new WaitForSeconds(896f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 3u:
				Singleton<SoundsManager3D>.instance.IBAHNGKDCPA();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.LFDPAEFMHNG(BJGCPDNMHDH.myUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 4u:
				PHDOCKCBJOF = new WaitForSeconds(318f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 5u:
				LoadingDialog.Hide();
				if (Singleton<GameController>.instance.isTutorialStage1)
				{
					BJGCPDNMHDH.JJKLKPKMHJO().weaponInventory.LIEDNEJPLMA = 4;
					SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-119), 1075f);
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(1532f));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				else
				{
					Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<GameStartScreen>.instance);
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.HIFIIAIAJKP());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				break;
			case 7u:
				PHDOCKCBJOF = new WaitForSeconds(1259f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 6u:
			case 8u:
				Time.timeScale = 1705f;
				BJGCPDNMHDH.time = 1888f;
				BJGCPDNMHDH.MMCKLPHNMMN = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void NDPOBCODJAI()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object EFIEEKFCBJH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NFJJHCBCIEM()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object DGEECEBHPNC()
		{
			return PHDOCKCBJOF;
		}

		public void GIAIFFPNMPJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KPNBIPDNGOM()
		{
			return PHDOCKCBJOF;
		}

		public void GGCLMIMHKBD()
		{
			throw new NotSupportedException();
		}

		public void NINFHADPHJI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object LMLPPCCDELM()
		{
			return PHDOCKCBJOF;
		}

		public void POAFKMGKBLJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GNFCCLCPCBO()
		{
			return PHDOCKCBJOF;
		}

		public void OEMOMDILPEE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MNAKOOGPNOH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MKEJDEGFKLC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GEFKCGOOFFP()
		{
			return PHDOCKCBJOF;
		}

		public void FFNAPBHOACE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MCCMIANNJAN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HKABKPOFMIJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AAIGGFHFBIC()
		{
			return PHDOCKCBJOF;
		}

		public void AKLMKDOIDHP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object FGFLGJECNLH()
		{
			return PHDOCKCBJOF;
		}

		public void PPHBGPPJBNK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void NAMBILMHOPD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MOMPOEEALPJ()
		{
			return PHDOCKCBJOF;
		}

		public void IOHPKCNPKAH()
		{
			throw new NotSupportedException();
		}

		public void NCOPKHMOMMK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BGAGLOJHMEJ()
		{
			return PHDOCKCBJOF;
		}

		public void IHAHCOPGPIM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void CPEEDIDEKLA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void AKEKFBGEJBG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object JEKHOAFAIBP()
		{
			return PHDOCKCBJOF;
		}

		public void NGNOJECCHGF()
		{
			throw new NotSupportedException();
		}

		public void OFDJMNMCDLA()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HGOKAFJBFGJ()
		{
			return PHDOCKCBJOF;
		}

		public void LHMNIFOJGIG()
		{
			throw new NotSupportedException();
		}

		public void MPNLGDNLLKF()
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
		private object LJNKKNHFIMG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AGANCOFPDCK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AOIEEEHJNLN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KKKMCHGLHLL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MJPEJLKAOEH()
		{
			return PHDOCKCBJOF;
		}

		public void FDCPBGNCKHH()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CDFEOBMLNCG()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public LIMGNABNMEG()
		{
		}

		[SpecialName]
		private object AAAOCACGKIP()
		{
			return PHDOCKCBJOF;
		}

		public void DECFCNMMOAG()
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
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.LoadTutorialCoroutine());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<ArmyPreviewCamera>.instance.MDCPOGFDCPC(BJGCPDNMHDH.PHCFJDNCHII(), PNDNEMDPFHC: false, PlayerTexturePool.DFJJOANIJID.Card);
				PlayerController.JFGDAKMCJAM.Clear();
				UnityEngine.Debug.Log("Local");
				MCCLPJGMIDG = (GHPGNELIDBM)8;
				JJLBIPJDBAG = BJGCPDNMHDH.PKMFODGDMON(MCCLPJGMIDG);
				BJGCPDNMHDH.PLIGGFJCAPA().fraction = MCCLPJGMIDG;
				BJGCPDNMHDH.JJKLKPKMHJO().MoveTo(JJLBIPJDBAG.point.transform.position, JJLBIPJDBAG.point.transform.rotation);
				BJGCPDNMHDH.PLIGGFJCAPA().currentPlayerPoint = JJLBIPJDBAG;
				BJGCPDNMHDH.AAIEPHNDCJP.EHHHBEMKGOE = CHEIFOOIMEH.PNPIGMOACFK();
				PlayerController.OGMBJPKOPCB = BJGCPDNMHDH.AAIEPHNDCJP;
				PlayerController.JFGDAKMCJAM[0] = BJGCPDNMHDH.AAIEPHNDCJP;
				BJGCPDNMHDH.AAIEPHNDCJP.NAGAHNHAKBJ = 0;
				BJGCPDNMHDH.PHCFJDNCHII().DMHKCCPPODF();
				BJGCPDNMHDH.JJKLKPKMHJO().DIOEINBFJBG(BJGCPDNMHDH.CHEDFKIPJFF);
				BJGCPDNMHDH.JJKLKPKMHJO().Killed += BJGCPDNMHDH.NMNCDNBPLHN;
				BJGCPDNMHDH.LCGHIOPCLLF();
				Singleton<BotManager>.instance.LOOGALLHLMO(BJGCPDNMHDH.NLAKCKMCOMN.JPMHIGNOPBL);
				BJGCPDNMHDH.NLAKCKMCOMN.DMHKCCPPODF();
				PNBNBGCNMCF = BJGCPDNMHDH.NLAKCKMCOMN.JPMHIGNOPBL;
				PNBNBGCNMCF.enabled = true;
				CardManager.instance.ClearCardsForGame();
				GameLoginManager.instance.CheckGpgsOnTutorialStart();
				if (TutorialManagerStage2.instance.isTutorialRunning || TutorialManagerStage3.instance.data.started)
				{
					FABFPMKKFJK = TutorialManagerStage2.instance.isTutorialRunning;
					UnityEngine.Debug.Log("Showing squad details dialog with SQUADNAME = ");
					TutorialManagerStage2.instance.FinishTutorial();
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("{0}{1}[-] {2}/[-] 3");
					TutorialManagerStage3.instance.StartTutorial(FABFPMKKFJK);
					CardManager.instance.cardsForGame.Clear();
					TutorialManagerStage2.instance.EquipTutorialUnitAfterSkipTutorial();
					PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII = CardManager.instance.selectedCards;
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: false));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				if (TutorialManagerStage1.instance.isTutorialRunning || TutorialManagerStage2.instance.data.started)
				{
					bool isTutorialRunning = TutorialManagerStage1.instance.isTutorialRunning;
					UnityEngine.Debug.Log("Texture {0} is no longer loaded");
					TutorialManagerStage1.instance.FinishTutorial();
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(" , ");
					TutorialManagerStage2.instance.StartTutorial(isTutorialRunning);
				}
				else
				{
					UnityEngine.Debug.Log("FpsDevice");
					TutorialManagerStage1.instance.StartTutorial(isContinue: true);
				}
				goto case 4u;
			case 2u:
				PHDOCKCBJOF = new WaitForSeconds(901f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 3u:
				Singleton<SoundsManager3D>.instance.GCOKDIOKPKG();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.LKNNHEPKDJP(BJGCPDNMHDH.myUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 4u:
				PHDOCKCBJOF = new WaitForSeconds(269f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 5u:
				LoadingDialog.Hide();
				if (Singleton<GameController>.instance.isTutorialStage1)
				{
					BJGCPDNMHDH.JJKLKPKMHJO().weaponInventory.LIEDNEJPLMA = 8;
					SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-80), 349f);
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(598f));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				else
				{
					Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<GameStartScreen>.instance);
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.HIFIIAIAJKP());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				break;
			case 7u:
				PHDOCKCBJOF = new WaitForSeconds(1998f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 6u:
			case 8u:
				Time.timeScale = 570f;
				BJGCPDNMHDH.time = 2f;
				BJGCPDNMHDH.MMCKLPHNMMN = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object CNGCLCAAHIG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AFDKAGLDADB()
		{
			return PHDOCKCBJOF;
		}

		public void OKIANDBCDIB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GNACDOOHMMG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CEFJLKJNAKJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BCIDICEAAEN()
		{
			return PHDOCKCBJOF;
		}

		public void EPIIDCKHCIN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void OMDFNFHKFBK()
		{
			throw new NotSupportedException();
		}

		public void IBLNBELFKNF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void BCOIPCDCKEJ()
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
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.LoadTutorialCoroutine());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<ArmyPreviewCamera>.instance.RenderToTexture(BJGCPDNMHDH.AAIEPHNDCJP, PNDNEMDPFHC: true);
				PlayerController.JFGDAKMCJAM.Clear();
				UnityEngine.Debug.Log("Start TUTORIAL");
				MCCLPJGMIDG = GHPGNELIDBM.Allies;
				JJLBIPJDBAG = BJGCPDNMHDH.PKMFODGDMON(MCCLPJGMIDG);
				BJGCPDNMHDH.AAIEPHNDCJP.fraction = MCCLPJGMIDG;
				BJGCPDNMHDH.AAIEPHNDCJP.MoveTo(JJLBIPJDBAG.point.transform.position, JJLBIPJDBAG.point.transform.rotation);
				BJGCPDNMHDH.AAIEPHNDCJP.currentPlayerPoint = JJLBIPJDBAG;
				BJGCPDNMHDH.AAIEPHNDCJP.EHHHBEMKGOE = CHEIFOOIMEH.JIIHHODDNLJ();
				PlayerController.OGMBJPKOPCB = BJGCPDNMHDH.AAIEPHNDCJP;
				PlayerController.JFGDAKMCJAM[0] = BJGCPDNMHDH.AAIEPHNDCJP;
				BJGCPDNMHDH.AAIEPHNDCJP.NAGAHNHAKBJ = 0;
				BJGCPDNMHDH.AAIEPHNDCJP.InitPlayer();
				BJGCPDNMHDH.AAIEPHNDCJP.Killed -= BJGCPDNMHDH.CHEDFKIPJFF;
				BJGCPDNMHDH.AAIEPHNDCJP.Killed += BJGCPDNMHDH.CHEDFKIPJFF;
				BJGCPDNMHDH.IMHLCOJKELJ();
				Singleton<BotManager>.instance.PrepareBotForTutorial(BJGCPDNMHDH.NLAKCKMCOMN.JPMHIGNOPBL);
				BJGCPDNMHDH.NLAKCKMCOMN.InitPlayer();
				PNBNBGCNMCF = BJGCPDNMHDH.NLAKCKMCOMN.JPMHIGNOPBL;
				PNBNBGCNMCF.enabled = true;
				CardManager.instance.ClearCardsForGame();
				GameLoginManager.instance.CheckGpgsOnTutorialStart();
				if (TutorialManagerStage2.instance.isTutorialRunning || TutorialManagerStage3.instance.data.started)
				{
					FABFPMKKFJK = TutorialManagerStage2.instance.isTutorialRunning;
					UnityEngine.Debug.Log("Starting stage 3 ");
					TutorialManagerStage2.instance.FinishTutorial();
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("221 END");
					TutorialManagerStage3.instance.StartTutorial(FABFPMKKFJK);
					CardManager.instance.cardsForGame.Clear();
					TutorialManagerStage2.instance.EquipTutorialUnitAfterSkipTutorial();
					PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII = CardManager.instance.selectedCards;
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: false));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				if (TutorialManagerStage1.instance.isTutorialRunning || TutorialManagerStage2.instance.data.started)
				{
					bool isTutorialRunning = TutorialManagerStage1.instance.isTutorialRunning;
					UnityEngine.Debug.Log("Starting stage 2 ");
					TutorialManagerStage1.instance.FinishTutorial();
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("128 END");
					TutorialManagerStage2.instance.StartTutorial(isTutorialRunning);
				}
				else
				{
					UnityEngine.Debug.Log("Starting stage 1 ");
					TutorialManagerStage1.instance.StartTutorial(isContinue: false);
				}
				goto case 4u;
			case 2u:
				PHDOCKCBJOF = new WaitForSeconds(2f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 3u:
				Singleton<SoundsManager3D>.instance.LoadSounds();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.LoadMineUpgrades(BJGCPDNMHDH.myUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 4u:
				PHDOCKCBJOF = new WaitForSeconds(0.25f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 5u:
				LoadingDialog.Hide();
				if (Singleton<GameController>.instance.isTutorialStage1)
				{
					BJGCPDNMHDH.AAIEPHNDCJP.weaponInventory.LIEDNEJPLMA = 3;
					SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.BootcampIntro);
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(1.5f));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				else
				{
					Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<GameStartScreen>.instance);
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.StartBeginAnimation());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				break;
			case 7u:
				PHDOCKCBJOF = new WaitForSeconds(1f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 6u:
			case 8u:
				Time.timeScale = 1f;
				BJGCPDNMHDH.time = 90f;
				BJGCPDNMHDH.MMCKLPHNMMN = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object GKOFBBLAMCN()
		{
			return PHDOCKCBJOF;
		}

		public void BCKMHLBBBCK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FFNFEAHBBLJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HGMMDPIGEGN()
		{
			return PHDOCKCBJOF;
		}

		public bool AELAICNOAPN()
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
				Singleton<ArmyPreviewCamera>.instance.BCPDNHEDBGO(BJGCPDNMHDH.AAIEPHNDCJP, PNDNEMDPFHC: true, PlayerTexturePool.DFJJOANIJID.Card);
				PlayerController.JFGDAKMCJAM.Clear();
				UnityEngine.Debug.Log("#AccoutCheck# Account exist check result NOT contain result message");
				MCCLPJGMIDG = (GHPGNELIDBM)4;
				JJLBIPJDBAG = BJGCPDNMHDH.KBDJJAGKHNI(MCCLPJGMIDG);
				BJGCPDNMHDH.PLIGGFJCAPA().fraction = MCCLPJGMIDG;
				BJGCPDNMHDH.JJKLKPKMHJO().MoveTo(JJLBIPJDBAG.point.transform.position, JJLBIPJDBAG.point.transform.rotation);
				BJGCPDNMHDH.AAIEPHNDCJP.HCOKNKCCPEK(JJLBIPJDBAG);
				BJGCPDNMHDH.PHCFJDNCHII().EHHHBEMKGOE = CHEIFOOIMEH.KPGNGIOHAMA();
				PlayerController.OGMBJPKOPCB = BJGCPDNMHDH.JJKLKPKMHJO();
				PlayerController.JFGDAKMCJAM[1] = BJGCPDNMHDH.PLIGGFJCAPA();
				BJGCPDNMHDH.PLIGGFJCAPA().NAGAHNHAKBJ = 1;
				BJGCPDNMHDH.JJKLKPKMHJO().DMHKCCPPODF();
				BJGCPDNMHDH.AAIEPHNDCJP.CMBKMOHOAGD(BJGCPDNMHDH.CHEDFKIPJFF);
				BJGCPDNMHDH.AAIEPHNDCJP.Killed += BJGCPDNMHDH.PCJPIKKLIDK;
				BJGCPDNMHDH.LAHLHAMCFAM();
				Singleton<BotManager>.instance.DDLKOAIFIJM(BJGCPDNMHDH.NLAKCKMCOMN.JPMHIGNOPBL);
				BJGCPDNMHDH.NLAKCKMCOMN.InitPlayer();
				PNBNBGCNMCF = BJGCPDNMHDH.NLAKCKMCOMN.JPMHIGNOPBL;
				PNBNBGCNMCF.enabled = false;
				CardManager.instance.ClearCardsForGame();
				GameLoginManager.instance.CheckGpgsOnTutorialStart();
				if (TutorialManagerStage2.instance.isTutorialRunning || TutorialManagerStage3.instance.data.started)
				{
					FABFPMKKFJK = TutorialManagerStage2.instance.isTutorialRunning;
					UnityEngine.Debug.Log("\t\"TRUE\"");
					TutorialManagerStage2.instance.FinishTutorial();
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Accuracy");
					TutorialManagerStage3.instance.StartTutorial(FABFPMKKFJK);
					CardManager.instance.cardsForGame.Clear();
					TutorialManagerStage2.instance.EquipTutorialUnitAfterSkipTutorial();
					PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII = CardManager.instance.selectedCards;
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: false));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				if (TutorialManagerStage1.instance.isTutorialRunning || TutorialManagerStage2.instance.data.started)
				{
					bool isTutorialRunning = TutorialManagerStage1.instance.isTutorialRunning;
					UnityEngine.Debug.Log("REINTENTAR");
					TutorialManagerStage1.instance.FinishTutorial();
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(" {0}{1}");
					TutorialManagerStage2.instance.StartTutorial(isTutorialRunning);
				}
				else
				{
					UnityEngine.Debug.Log("!!!!! Player entered normal leagues FIRST TIME!!!!");
					TutorialManagerStage1.instance.StartTutorial(isContinue: false);
				}
				goto case 4u;
			case 2u:
				PHDOCKCBJOF = new WaitForSeconds(595f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 3u:
				Singleton<SoundsManager3D>.instance.LoadSounds();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.HACBEEBGCMO(BJGCPDNMHDH.myUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 4u:
				PHDOCKCBJOF = new WaitForSeconds(984f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 5u:
				LoadingDialog.Hide();
				if (Singleton<GameController>.instance.ICINKELJCAH())
				{
					BJGCPDNMHDH.AAIEPHNDCJP.JLMDEMFIHCA().LIEDNEJPLMA = 3;
					SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-29), 1880f);
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(1773f));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				else
				{
					Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<GameStartScreen>.instance);
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.HIFIIAIAJKP());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
				}
				break;
			case 7u:
				PHDOCKCBJOF = new WaitForSeconds(833f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 6u:
			case 8u:
				Time.timeScale = 1621f;
				BJGCPDNMHDH.time = 10f;
				BJGCPDNMHDH.MMCKLPHNMMN = true;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void OJDEHKDDLFD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GDCFFBBNGHH()
		{
			return PHDOCKCBJOF;
		}

		public bool LGLPPAENMGK()
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
				Singleton<ArmyPreviewCamera>.instance.MANAHDDIFIO(BJGCPDNMHDH.AAIEPHNDCJP, PNDNEMDPFHC: true, PlayerTexturePool.DFJJOANIJID.Card);
				PlayerController.JFGDAKMCJAM.Clear();
				UnityEngine.Debug.Log("Token");
				MCCLPJGMIDG = (GHPGNELIDBM)6;
				JJLBIPJDBAG = BJGCPDNMHDH.AGMHNCNKJHP(MCCLPJGMIDG);
				BJGCPDNMHDH.PHCFJDNCHII().fraction = MCCLPJGMIDG;
				BJGCPDNMHDH.JJKLKPKMHJO().MoveTo(JJLBIPJDBAG.point.transform.position, JJLBIPJDBAG.point.transform.rotation);
				BJGCPDNMHDH.JJKLKPKMHJO().HCOKNKCCPEK(JJLBIPJDBAG);
				BJGCPDNMHDH.PHCFJDNCHII().EHHHBEMKGOE = CHEIFOOIMEH.FNKEPILGJAO();
				PlayerController.OGMBJPKOPCB = BJGCPDNMHDH.PHCFJDNCHII();
				PlayerController.JFGDAKMCJAM[0] = BJGCPDNMHDH.AAIEPHNDCJP;
				BJGCPDNMHDH.AAIEPHNDCJP.NAGAHNHAKBJ = 0;
				BJGCPDNMHDH.JJKLKPKMHJO().DMHKCCPPODF();
				BJGCPDNMHDH.PLIGGFJCAPA().DIOEINBFJBG(BJGCPDNMHDH.NMNCDNBPLHN);
				BJGCPDNMHDH.PLIGGFJCAPA().FDHJCAGOFKN(BJGCPDNMHDH.NMNCDNBPLHN);
				BJGCPDNMHDH.LAHLHAMCFAM();
				Singleton<BotManager>.instance.PrepareBotForTutorial(BJGCPDNMHDH.NLAKCKMCOMN.JPMHIGNOPBL);
				BJGCPDNMHDH.NLAKCKMCOMN.InitPlayer();
				PNBNBGCNMCF = BJGCPDNMHDH.NLAKCKMCOMN.JPMHIGNOPBL;
				PNBNBGCNMCF.enabled = true;
				CardManager.instance.ClearCardsForGame();
				GameLoginManager.instance.CheckGpgsOnTutorialStart();
				if (TutorialManagerStage2.instance.isTutorialRunning || TutorialManagerStage3.instance.data.started)
				{
					FABFPMKKFJK = TutorialManagerStage2.instance.isTutorialRunning;
					UnityEngine.Debug.Log("ID_CONFIRM_ERROR");
					TutorialManagerStage2.instance.FinishTutorial();
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Overtime_Was_Already_Explained");
					TutorialManagerStage3.instance.StartTutorial(FABFPMKKFJK);
					CardManager.instance.cardsForGame.Clear();
					TutorialManagerStage2.instance.EquipTutorialUnitAfterSkipTutorial();
					PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII = CardManager.instance.selectedCards;
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: false));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				if (TutorialManagerStage1.instance.isTutorialRunning || TutorialManagerStage2.instance.data.started)
				{
					bool isTutorialRunning = TutorialManagerStage1.instance.isTutorialRunning;
					UnityEngine.Debug.Log("ID_DEBUG_EVENTASSIGNMENTUPDATE");
					TutorialManagerStage1.instance.FinishTutorial();
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("KCOPCEKOCHL");
					TutorialManagerStage2.instance.StartTutorial(isTutorialRunning);
				}
				else
				{
					UnityEngine.Debug.Log("WarArenaData");
					TutorialManagerStage1.instance.StartTutorial(isContinue: false);
				}
				goto case 4u;
			case 2u:
				PHDOCKCBJOF = new WaitForSeconds(1413f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 3u:
				Singleton<SoundsManager3D>.instance.IBAHNGKDCPA();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.FFMAGHFENAP(BJGCPDNMHDH.myUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 4u:
				PHDOCKCBJOF = new WaitForSeconds(786f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 5u:
				LoadingDialog.Hide();
				if (Singleton<GameController>.instance.ICINKELJCAH())
				{
					BJGCPDNMHDH.PHCFJDNCHII().BEIIOAIJMFK().LIEDNEJPLMA = 8;
					SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-92), 151f);
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(288f));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				else
				{
					Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<GameStartScreen>.instance);
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.HIFIIAIAJKP());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				break;
			case 7u:
				PHDOCKCBJOF = new WaitForSeconds(1908f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 6u:
			case 8u:
				Time.timeScale = 1693f;
				BJGCPDNMHDH.time = 1306f;
				BJGCPDNMHDH.MMCKLPHNMMN = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void JOEOMEJLEID()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool FADACBKMFGG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.CNJMCFDKLCN());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				Singleton<ArmyPreviewCamera>.instance.KIONJHBCIBE(BJGCPDNMHDH.AAIEPHNDCJP, PNDNEMDPFHC: true, PlayerTexturePool.DFJJOANIJID.Card);
				PlayerController.JFGDAKMCJAM.Clear();
				UnityEngine.Debug.Log("Special pack content: type: {0} id: {1} seconds: {2}{3}");
				MCCLPJGMIDG = GHPGNELIDBM.Enemies;
				JJLBIPJDBAG = BJGCPDNMHDH.KBDJJAGKHNI(MCCLPJGMIDG);
				BJGCPDNMHDH.PHCFJDNCHII().fraction = MCCLPJGMIDG;
				BJGCPDNMHDH.PLIGGFJCAPA().MoveTo(JJLBIPJDBAG.point.transform.position, JJLBIPJDBAG.point.transform.rotation);
				BJGCPDNMHDH.PLIGGFJCAPA().currentPlayerPoint = JJLBIPJDBAG;
				BJGCPDNMHDH.PLIGGFJCAPA().EHHHBEMKGOE = CHEIFOOIMEH.PNPIGMOACFK();
				PlayerController.OGMBJPKOPCB = BJGCPDNMHDH.PLIGGFJCAPA();
				PlayerController.JFGDAKMCJAM[0] = BJGCPDNMHDH.JJKLKPKMHJO();
				BJGCPDNMHDH.AAIEPHNDCJP.NAGAHNHAKBJ = 0;
				BJGCPDNMHDH.PHCFJDNCHII().DMHKCCPPODF();
				BJGCPDNMHDH.AAIEPHNDCJP.Killed -= BJGCPDNMHDH.CHEDFKIPJFF;
				BJGCPDNMHDH.PLIGGFJCAPA().Killed += BJGCPDNMHDH.CHEDFKIPJFF;
				BJGCPDNMHDH.LCGHIOPCLLF();
				Singleton<BotManager>.instance.PrepareBotForTutorial(BJGCPDNMHDH.NLAKCKMCOMN.JPMHIGNOPBL);
				BJGCPDNMHDH.NLAKCKMCOMN.DMHKCCPPODF();
				PNBNBGCNMCF = BJGCPDNMHDH.NLAKCKMCOMN.JPMHIGNOPBL;
				PNBNBGCNMCF.enabled = true;
				CardManager.instance.ClearCardsForGame();
				GameLoginManager.instance.CheckGpgsOnTutorialStart();
				if (TutorialManagerStage2.instance.isTutorialRunning || TutorialManagerStage3.instance.data.started)
				{
					FABFPMKKFJK = TutorialManagerStage2.instance.isTutorialRunning;
					UnityEngine.Debug.Log("{0} / [FECA21]{1}");
					TutorialManagerStage2.instance.FinishTutorial();
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("lootboxes");
					TutorialManagerStage3.instance.StartTutorial(FABFPMKKFJK);
					CardManager.instance.cardsForGame.Clear();
					TutorialManagerStage2.instance.EquipTutorialUnitAfterSkipTutorial();
					PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII = CardManager.instance.selectedCards;
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: false));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				if (TutorialManagerStage1.instance.isTutorialRunning || TutorialManagerStage2.instance.data.started)
				{
					bool isTutorialRunning = TutorialManagerStage1.instance.isTutorialRunning;
					UnityEngine.Debug.Log("VipReward1");
					TutorialManagerStage1.instance.FinishTutorial();
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("  ");
					TutorialManagerStage2.instance.StartTutorial(isTutorialRunning);
				}
				else
				{
					UnityEngine.Debug.Log("year");
					TutorialManagerStage1.instance.StartTutorial(isContinue: true);
				}
				goto case 4u;
			case 2u:
				PHDOCKCBJOF = new WaitForSeconds(627f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 3u:
				Singleton<SoundsManager3D>.instance.IBAHNGKDCPA();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.LoadMineUpgrades(BJGCPDNMHDH.myUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 4u:
				PHDOCKCBJOF = new WaitForSeconds(1955f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 5u:
				LoadingDialog.Hide();
				if (Singleton<GameController>.instance.isTutorialStage1)
				{
					BJGCPDNMHDH.PLIGGFJCAPA().JLMDEMFIHCA().LIEDNEJPLMA = 6;
					SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-4), 1752f);
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(24f));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				else
				{
					Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<GameStartScreen>.instance);
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.HIFIIAIAJKP());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				break;
			case 7u:
				PHDOCKCBJOF = new WaitForSeconds(1131f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 6u:
			case 8u:
				Time.timeScale = 31f;
				BJGCPDNMHDH.time = 1325f;
				BJGCPDNMHDH.MMCKLPHNMMN = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void NHFMKLGIKPM()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void PCNOHGFPMOE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void CHANLKFNCLA()
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
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.CNJMCFDKLCN());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				Singleton<ArmyPreviewCamera>.instance.MANAHDDIFIO(BJGCPDNMHDH.PLIGGFJCAPA(), PNDNEMDPFHC: true, PlayerTexturePool.DFJJOANIJID.Card);
				PlayerController.JFGDAKMCJAM.Clear();
				UnityEngine.Debug.Log("N");
				MCCLPJGMIDG = GHPGNELIDBM.Enemies;
				JJLBIPJDBAG = BJGCPDNMHDH.KBDJJAGKHNI(MCCLPJGMIDG);
				BJGCPDNMHDH.PLIGGFJCAPA().fraction = MCCLPJGMIDG;
				BJGCPDNMHDH.AAIEPHNDCJP.MoveTo(JJLBIPJDBAG.point.transform.position, JJLBIPJDBAG.point.transform.rotation);
				BJGCPDNMHDH.PHCFJDNCHII().CMKNJFHHOHA(JJLBIPJDBAG);
				BJGCPDNMHDH.JJKLKPKMHJO().EHHHBEMKGOE = CHEIFOOIMEH.PNPIGMOACFK();
				PlayerController.OGMBJPKOPCB = BJGCPDNMHDH.AAIEPHNDCJP;
				PlayerController.JFGDAKMCJAM[1] = BJGCPDNMHDH.PHCFJDNCHII();
				BJGCPDNMHDH.JJKLKPKMHJO().NAGAHNHAKBJ = 0;
				BJGCPDNMHDH.PHCFJDNCHII().DMHKCCPPODF();
				BJGCPDNMHDH.PLIGGFJCAPA().CMBKMOHOAGD(BJGCPDNMHDH.CHEDFKIPJFF);
				BJGCPDNMHDH.PHCFJDNCHII().FFEDMMENHFA(BJGCPDNMHDH.PCJPIKKLIDK);
				BJGCPDNMHDH.LAHLHAMCFAM();
				Singleton<BotManager>.instance.PrepareBotForTutorial(BJGCPDNMHDH.NLAKCKMCOMN.JPMHIGNOPBL);
				BJGCPDNMHDH.NLAKCKMCOMN.DMHKCCPPODF();
				PNBNBGCNMCF = BJGCPDNMHDH.NLAKCKMCOMN.JPMHIGNOPBL;
				PNBNBGCNMCF.enabled = false;
				CardManager.instance.ClearCardsForGame();
				GameLoginManager.instance.CheckGpgsOnTutorialStart();
				if (TutorialManagerStage2.instance.isTutorialRunning || TutorialManagerStage3.instance.data.started)
				{
					FABFPMKKFJK = TutorialManagerStage2.instance.isTutorialRunning;
					UnityEngine.Debug.Log("Shields");
					TutorialManagerStage2.instance.FinishTutorial();
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("gold");
					TutorialManagerStage3.instance.StartTutorial(FABFPMKKFJK);
					CardManager.instance.cardsForGame.Clear();
					TutorialManagerStage2.instance.EquipTutorialUnitAfterSkipTutorial();
					PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII = CardManager.instance.selectedCards;
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: false));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (TutorialManagerStage1.instance.isTutorialRunning || TutorialManagerStage2.instance.data.started)
				{
					bool isTutorialRunning = TutorialManagerStage1.instance.isTutorialRunning;
					UnityEngine.Debug.Log("groundBoxHit");
					TutorialManagerStage1.instance.FinishTutorial();
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_SALEPERCENTLINE");
					TutorialManagerStage2.instance.StartTutorial(isTutorialRunning);
				}
				else
				{
					UnityEngine.Debug.Log("-");
					TutorialManagerStage1.instance.StartTutorial(isContinue: true);
				}
				goto case 4u;
			case 2u:
				PHDOCKCBJOF = new WaitForSeconds(851f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 3u:
				Singleton<SoundsManager3D>.instance.LOBFOCCGGHB();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.ALLMFMGKLOC(BJGCPDNMHDH.myUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 4u:
				PHDOCKCBJOF = new WaitForSeconds(1395f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 5u:
				LoadingDialog.Hide();
				if (Singleton<GameController>.instance.OJHIKLMNHNE())
				{
					BJGCPDNMHDH.PHCFJDNCHII().FMKGGADDHJK().LIEDNEJPLMA = 2;
					SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.StartGameVsSound, 1448f);
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(445f));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				else
				{
					Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<GameStartScreen>.instance);
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.JGDIFKHNHGE());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				break;
			case 7u:
				PHDOCKCBJOF = new WaitForSeconds(1807f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 6u:
			case 8u:
				Time.timeScale = 646f;
				BJGCPDNMHDH.time = 416f;
				BJGCPDNMHDH.MMCKLPHNMMN = false;
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

		public bool IGKACECJBEB()
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
				Singleton<ArmyPreviewCamera>.instance.KIONJHBCIBE(BJGCPDNMHDH.PLIGGFJCAPA(), PNDNEMDPFHC: true, PlayerTexturePool.DFJJOANIJID.Card);
				PlayerController.JFGDAKMCJAM.Clear();
				UnityEngine.Debug.Log("TryActivateBonusRPC");
				MCCLPJGMIDG = (GHPGNELIDBM)3;
				JJLBIPJDBAG = BJGCPDNMHDH.AGMHNCNKJHP(MCCLPJGMIDG);
				BJGCPDNMHDH.JJKLKPKMHJO().fraction = MCCLPJGMIDG;
				BJGCPDNMHDH.PHCFJDNCHII().MoveTo(JJLBIPJDBAG.point.transform.position, JJLBIPJDBAG.point.transform.rotation);
				BJGCPDNMHDH.PHCFJDNCHII().HCOKNKCCPEK(JJLBIPJDBAG);
				BJGCPDNMHDH.PLIGGFJCAPA().EHHHBEMKGOE = CHEIFOOIMEH.FNKEPILGJAO();
				PlayerController.OGMBJPKOPCB = BJGCPDNMHDH.AAIEPHNDCJP;
				PlayerController.JFGDAKMCJAM[1] = BJGCPDNMHDH.JJKLKPKMHJO();
				BJGCPDNMHDH.JJKLKPKMHJO().NAGAHNHAKBJ = 0;
				BJGCPDNMHDH.AAIEPHNDCJP.InitPlayer();
				BJGCPDNMHDH.AAIEPHNDCJP.Killed -= BJGCPDNMHDH.NMNCDNBPLHN;
				BJGCPDNMHDH.PHCFJDNCHII().FDHJCAGOFKN(BJGCPDNMHDH.NMNCDNBPLHN);
				BJGCPDNMHDH.LAHLHAMCFAM();
				Singleton<BotManager>.instance.OCEPDEABOHJ(BJGCPDNMHDH.NLAKCKMCOMN.JPMHIGNOPBL);
				BJGCPDNMHDH.NLAKCKMCOMN.InitPlayer();
				PNBNBGCNMCF = BJGCPDNMHDH.NLAKCKMCOMN.JPMHIGNOPBL;
				PNBNBGCNMCF.enabled = false;
				CardManager.instance.ClearCardsForGame();
				GameLoginManager.instance.CheckGpgsOnTutorialStart();
				if (TutorialManagerStage2.instance.isTutorialRunning || TutorialManagerStage3.instance.data.started)
				{
					FABFPMKKFJK = TutorialManagerStage2.instance.isTutorialRunning;
					UnityEngine.Debug.Log("PrepareBotForDeathMatch 9");
					TutorialManagerStage2.instance.FinishTutorial();
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("AccountType");
					TutorialManagerStage3.instance.StartTutorial(FABFPMKKFJK);
					CardManager.instance.cardsForGame.Clear();
					TutorialManagerStage2.instance.EquipTutorialUnitAfterSkipTutorial();
					PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII = CardManager.instance.selectedCards;
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				if (TutorialManagerStage1.instance.isTutorialRunning || TutorialManagerStage2.instance.data.started)
				{
					bool isTutorialRunning = TutorialManagerStage1.instance.isTutorialRunning;
					UnityEngine.Debug.Log("PlayerToInviteId");
					TutorialManagerStage1.instance.FinishTutorial();
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_RANK");
					TutorialManagerStage2.instance.StartTutorial(isTutorialRunning);
				}
				else
				{
					UnityEngine.Debug.Log("PA: number of sessions");
					TutorialManagerStage1.instance.StartTutorial(isContinue: true);
				}
				goto case 4u;
			case 2u:
				PHDOCKCBJOF = new WaitForSeconds(1996f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 3u:
				Singleton<SoundsManager3D>.instance.IBAHNGKDCPA();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.ALLMFMGKLOC(BJGCPDNMHDH.myUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 4u:
				PHDOCKCBJOF = new WaitForSeconds(802f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 5u:
				LoadingDialog.Hide();
				if (Singleton<GameController>.instance.isTutorialStage1)
				{
					BJGCPDNMHDH.PHCFJDNCHII().weaponInventory.LIEDNEJPLMA = 4;
					SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.MissionNewWave, 330f);
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(1953f));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				else
				{
					Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<GameStartScreen>.instance);
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.HIFIIAIAJKP());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				break;
			case 7u:
				PHDOCKCBJOF = new WaitForSeconds(71f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 6u:
			case 8u:
				Time.timeScale = 1209f;
				BJGCPDNMHDH.time = 396f;
				BJGCPDNMHDH.MMCKLPHNMMN = true;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}
	}

	private sealed class IMDALEGJCDN : IEnumerator, IDisposable, IEnumerator<object>
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

		public void KGLKGNBCPLM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool FNLDIMGNGMM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Singleton<GameController>.instance.PEGCHNGBOAM() != GameController.AEMPHGEIJNH.Menu)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1286f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
				}
				return true;
			case 2u:
				TutorialManagerStage3.instance.FinishMenuTutorial();
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object NFJJHCBCIEM()
		{
			return PHDOCKCBJOF;
		}

		public bool HCONPNNPBAD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Singleton<GameController>.instance.NOPCKHHDOMN() != GameController.AEMPHGEIJNH.Menu)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1483f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				return false;
			case 2u:
				TutorialManagerStage3.instance.FinishMenuTutorial();
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void LOOMFHNKAND()
		{
			throw new NotSupportedException();
		}

		public void LFIGPJBHPBH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void HMFGNEKJDKH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void AEFEAMAGBKK()
		{
			throw new NotSupportedException();
		}

		public void CFDAGFGOOIE()
		{
			throw new NotSupportedException();
		}

		public void ADLICCCIEGG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void GHILCKCFAFN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object DFKJEOAPBGP()
		{
			return PHDOCKCBJOF;
		}

		public void HJLCPFDBNKP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object JCDIBAEMKCA()
		{
			return PHDOCKCBJOF;
		}

		public void FCHOHLMCHED()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IAMNDODCIEB()
		{
			return PHDOCKCBJOF;
		}

		public void GICFBDJLDKF()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void MGJIOLLKHDK()
		{
			throw new NotSupportedException();
		}

		public void EHMOLOCPIGB()
		{
			throw new NotSupportedException();
		}

		public bool PGOBEIMCPGA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Singleton<GameController>.instance.AFDJHMHONOH() != GameController.AEMPHGEIJNH.Menu)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1554f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				return false;
			case 2u:
				TutorialManagerStage3.instance.FinishMenuTutorial();
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public bool IEDGDDDADFM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Singleton<GameController>.instance.AFDJHMHONOH() != GameController.AEMPHGEIJNH.Menu)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(813f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				return true;
			case 2u:
				TutorialManagerStage3.instance.FinishMenuTutorial();
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void GEEKOICFEIB()
		{
			throw new NotSupportedException();
		}

		public bool PIAOIBJMLCC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Singleton<GameController>.instance.gameState != GameController.AEMPHGEIJNH.Menu)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1020f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
				}
				return false;
			case 2u:
				TutorialManagerStage3.instance.FinishMenuTutorial();
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object NOIDHHDEEPL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BGLDNJLBIKM()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool GBHCODKDPBO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Singleton<GameController>.instance.AFDJHMHONOH() != GameController.AEMPHGEIJNH.Menu)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1635f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
				}
				return true;
			case 2u:
				TutorialManagerStage3.instance.FinishMenuTutorial();
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void BKGBMJMNJCD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MCLBPLOHNON()
		{
			return PHDOCKCBJOF;
		}

		public void ONGBFFAENBP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void CHANLKFNCLA()
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
			case 1u:
				if (Singleton<GameController>.instance.AFDJHMHONOH() != GameController.AEMPHGEIJNH.Menu)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1070f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				return false;
			case 2u:
				TutorialManagerStage3.instance.FinishMenuTutorial();
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void OKIANDBCDIB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void KPJIDBHHKFM()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object JFEPOFBDLMB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HADIFBCDICK()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public IMDALEGJCDN()
		{
		}

		public void GGCLMIMHKBD()
		{
			throw new NotSupportedException();
		}

		public void FILDGEMDECJ()
		{
			throw new NotSupportedException();
		}

		public void ABBPOMCBIIH()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IPCODJDAOBE()
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
			case 1u:
				if (Singleton<GameController>.instance.AFDJHMHONOH() != GameController.AEMPHGEIJNH.Menu)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(192f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				return true;
			case 2u:
				TutorialManagerStage3.instance.FinishMenuTutorial();
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object JKKAEPEAGNP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CLBPPBIIAFP()
		{
			return PHDOCKCBJOF;
		}

		public void OMDFNFHKFBK()
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
			case 1u:
				if (Singleton<GameController>.instance.gameState != GameController.AEMPHGEIJNH.Menu)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(876f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				return true;
			case 2u:
				TutorialManagerStage3.instance.FinishMenuTutorial();
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object EPNOIENCFGA()
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
			case 1u:
				if (Singleton<GameController>.instance.NOPCKHHDOMN() != GameController.AEMPHGEIJNH.Menu)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(731f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				return true;
			case 2u:
				TutorialManagerStage3.instance.FinishMenuTutorial();
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void NBMNDHCIBME()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object OJMKDIBHMND()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BNMEIAPPLDP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JIIJMDIFMKF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DCILDAODCDM()
		{
			return PHDOCKCBJOF;
		}

		public void DLIBOPAMHAN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool EOLNOFMPMHI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Singleton<GameController>.instance.AFDJHMHONOH() != GameController.AEMPHGEIJNH.Menu)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1290f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
				}
				return true;
			case 2u:
				TutorialManagerStage3.instance.FinishMenuTutorial();
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void IOBGNBBJOLM()
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
			case 1u:
				if (Singleton<GameController>.instance.AFDJHMHONOH() != GameController.AEMPHGEIJNH.Menu)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(293f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
				}
				return false;
			case 2u:
				TutorialManagerStage3.instance.FinishMenuTutorial();
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void ABOOMAKBEDI()
		{
			throw new NotSupportedException();
		}

		public void NFAMBMLLFGP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object LPMKMBAOMFP()
		{
			return PHDOCKCBJOF;
		}

		public void HJOCCDLNFLN()
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
			case 1u:
				if (Singleton<GameController>.instance.PEGCHNGBOAM() != GameController.AEMPHGEIJNH.Menu)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1748f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				return true;
			case 2u:
				TutorialManagerStage3.instance.FinishMenuTutorial();
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object KKCOHEHPJPF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BGMNDLEJNHH()
		{
			return PHDOCKCBJOF;
		}

		public void ODPKEEIHOPK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object IGFMIFOHCHJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FKJJFNMBKOP()
		{
			return PHDOCKCBJOF;
		}

		public void NDPOBCODJAI()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HLFLANGJJHM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GOAJCEAOPLA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CICPCKDCCEF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PFIIINLHGMH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MNAKOOGPNOH()
		{
			return PHDOCKCBJOF;
		}

		public bool LGLPPAENMGK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Singleton<GameController>.instance.AFDJHMHONOH() != GameController.AEMPHGEIJNH.Menu)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(451f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				return false;
			case 2u:
				TutorialManagerStage3.instance.FinishMenuTutorial();
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object HJHFKNCBGDG()
		{
			return PHDOCKCBJOF;
		}

		public void CNBLDCICPLL()
		{
			throw new NotSupportedException();
		}

		public void MAKKCANEHIB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void GFJIKANGNMC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HBGFABNDPAD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EOKIMMCAABI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BLNNEJILEIE()
		{
			return PHDOCKCBJOF;
		}

		public void IGBHHLFACKO()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void MKIKEOOOLKL()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool PPOPGFELIDA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Singleton<GameController>.instance.AFDJHMHONOH() != GameController.AEMPHGEIJNH.Menu)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(571f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				return false;
			case 2u:
				TutorialManagerStage3.instance.FinishMenuTutorial();
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void CCPGGFONBKA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void FDCPBGNCKHH()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object ENJLMNBAHAF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LKAEMBCGLBN()
		{
			return PHDOCKCBJOF;
		}

		public void NGNOJECCHGF()
		{
			throw new NotSupportedException();
		}

		public void JKBIMBFGGCO()
		{
			throw new NotSupportedException();
		}

		public bool BIGKCFMEBJE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Singleton<GameController>.instance.gameState != GameController.AEMPHGEIJNH.Menu)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(869f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				return true;
			case 2u:
				TutorialManagerStage3.instance.FinishMenuTutorial();
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public bool CCDJGNJGPDM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Singleton<GameController>.instance.NOPCKHHDOMN() != GameController.AEMPHGEIJNH.Menu)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(624f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				return true;
			case 2u:
				TutorialManagerStage3.instance.FinishMenuTutorial();
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void CFHJPHLFONO()
		{
			throw new NotSupportedException();
		}

		public void NINFHADPHJI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HHLKEMNNJDA()
		{
			return PHDOCKCBJOF;
		}

		public bool GMBFJOBKMMN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Singleton<GameController>.instance.PEGCHNGBOAM() != GameController.AEMPHGEIJNH.Menu)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(270f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				return false;
			case 2u:
				TutorialManagerStage3.instance.FinishMenuTutorial();
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public bool KOMAOOLHONO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Singleton<GameController>.instance.AFDJHMHONOH() != GameController.AEMPHGEIJNH.Menu)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1228f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				return true;
			case 2u:
				TutorialManagerStage3.instance.FinishMenuTutorial();
				CLPPIAGLCJJ = -1;
				break;
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
			case 1u:
				if (Singleton<GameController>.instance.NOPCKHHDOMN() != GameController.AEMPHGEIJNH.Menu)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1996f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
				}
				return true;
			case 2u:
				TutorialManagerStage3.instance.FinishMenuTutorial();
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void NIEPBMPJEAE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GPKBICHIBHF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AIDHNJCPDIJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JMGAHAGANGP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FFNFEAHBBLJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GFBODCHPCLP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GNACDOOHMMG()
		{
			return PHDOCKCBJOF;
		}

		public void IFLGJMJCOMC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object OLMAFKDGMDB()
		{
			return PHDOCKCBJOF;
		}

		public void OGHELMDBPIL()
		{
			throw new NotSupportedException();
		}

		public void LHADJAFHDDC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool FOKKNCCLABE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Singleton<GameController>.instance.NOPCKHHDOMN() != GameController.AEMPHGEIJNH.Menu)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(694f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				return true;
			case 2u:
				TutorialManagerStage3.instance.FinishMenuTutorial();
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object CEFJLKJNAKJ()
		{
			return PHDOCKCBJOF;
		}

		public void PDKPELBIAON()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FFJBOMJMIAE()
		{
			return PHDOCKCBJOF;
		}

		public bool AKFKBNAMOAI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Singleton<GameController>.instance.gameState != GameController.AEMPHGEIJNH.Menu)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1589f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
				}
				return false;
			case 2u:
				TutorialManagerStage3.instance.FinishMenuTutorial();
				CLPPIAGLCJJ = -1;
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
			case 1u:
				if (Singleton<GameController>.instance.gameState != GameController.AEMPHGEIJNH.Menu)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(3f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
				}
				return true;
			case 2u:
				TutorialManagerStage3.instance.FinishMenuTutorial();
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void GFPAMDPNMKG()
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
			case 1u:
				if (Singleton<GameController>.instance.NOPCKHHDOMN() != GameController.AEMPHGEIJNH.Menu)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(939f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				return false;
			case 2u:
				TutorialManagerStage3.instance.FinishMenuTutorial();
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object IHAOBCEALPD()
		{
			return PHDOCKCBJOF;
		}

		public void GOBLBCJNIBD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object EKJDPPIGKCF()
		{
			return PHDOCKCBJOF;
		}

		public void GGMKKIDFJOH()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object AAIGGFHFBIC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CCANBMDEKMB()
		{
			return PHDOCKCBJOF;
		}

		public void ODINNCBLBOF()
		{
			throw new NotSupportedException();
		}

		public void DOPCGPGKHIJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool IGKACECJBEB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (Singleton<GameController>.instance.gameState != GameController.AEMPHGEIJNH.Menu)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
				}
				else
				{
					PHDOCKCBJOF = new WaitForSeconds(1974f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
				}
				return true;
			case 2u:
				TutorialManagerStage3.instance.FinishMenuTutorial();
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void NCHGDJDAHGC()
		{
			throw new NotSupportedException();
		}

		public void MPNLGDNLLKF()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object FGGMHEIPKAJ()
		{
			return PHDOCKCBJOF;
		}
	}

	private readonly List<TutorialManagerBase> DEHPFPNPDOK = new List<TutorialManagerBase>();

	protected PlayerController NLAKCKMCOMN;

	[FormerlySerializedAs("HDBGLKICGPH")]
	public bool MMCKLPHNMMN;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private float _003COKOMJJJKLIL_003Ek__BackingField;

	[HideInInspector]
	[FormerlySerializedAs("MOBLBPDEKDJ")]
	public List<Card> CPLFJCDIIPG;

	private List<Card> AKPBGICMHKD;

	private bool MKDMABLGHAN;

	protected PlayerController AAIEPHNDCJP => Singleton<GameController>.instance.FHABFFKPODN;

	public override bool dropCreates => false;

	public override List<Card> cardsForGame
	{
		get
		{
			return Singleton<GameController>.instance.GMNKFFNFEHG.cardsForGame;
		}
		set
		{
			Singleton<GameController>.instance.GMNKFFNFEHG.cardsForGame = value;
		}
	}

	public GameController mMainController
	{
		get
		{
			return Singleton<GameController>.instance;
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public string tutorialStageId
	{
		get
		{
			if (TutorialManagerStage1.instance.isTutorialRunning)
			{
				return "Stage1";
			}
			if (TutorialManagerStage2.instance.isTutorialRunning)
			{
				return "Stage2";
			}
			if (TutorialManagerStage3.instance.isTutorialRunning)
			{
				return "Stage3";
			}
			return "Unknown Tutorial Stage";
		}
	}

	public override bool canShowPause => true;

	public override float time
	{
		[CompilerGenerated]
		get
		{
			return _003COKOMJJJKLIL_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003COKOMJJJKLIL_003Ek__BackingField = value;
		}
	}

	public override bool gameIsRunning
	{
		get
		{
			return mMainController.gameIsRunning;
		}
		set
		{
			mMainController.gameIsRunning = value;
		}
	}

	public override bool canDeployUnits => Singleton<GameController>.instance.isTutorialStage2;

	public override string quitText => string.Empty;

	public override bool pauseCountDown => false;

	[SpecialName]
	public virtual bool ILOGNPPHHDL()
	{
		return false;
	}

	[SpecialName]
	public virtual string HDEKAEPCFMG()
	{
		return string.Empty;
	}

	[SpecialName]
	public virtual void LMGGKGIGADM(bool IDEBKDPMPGM)
	{
		mMainController.gameIsRunning = IDEBKDPMPGM;
	}

	[SpecialName]
	public string IDCJLPILIGL()
	{
		if (TutorialManagerStage1.instance.isTutorialRunning)
		{
			return "ID_READYTIME";
		}
		if (TutorialManagerStage2.instance.isTutorialRunning)
		{
			return "ID_SYSTEMMAINTENANCE";
		}
		if (TutorialManagerStage3.instance.isTutorialRunning)
		{
			return "Video {0} service {1} thumbnail {2}";
		}
		return "reloadTime";
	}

	public override void FinishGame()
	{
		GuiElementSingle<TutorialDialog>.instance.HideDialog();
		Singleton<TutorialProgressShower>.instance.Hide();
		Singleton<MatchManager>.instance.matchTime = 90f - time;
		if (gameIsRunning)
		{
			gameIsRunning = false;
			if (mMainController.MNMLNIMFMJP == GameController.HKGHCIEPGEL.Forfeit)
			{
				mMainController.StartCoroutine(mMainController.RestartTutorial());
			}
			else
			{
				mMainController.FinishGame();
			}
		}
	}

	public override void Quit()
	{
	}

	public void MHIAOAMDIGC()
	{
		CPLFJCDIIPG = new List<Card>();
		try
		{
			string vALUE = Singleton<GameVariables>.instance.BKHOJMDIIEF().GetRow(StringConstants.rowIds.TutorialCards).VALUE;
			List<string> list = JsonConvert.DeserializeObject<List<string>>(vALUE);
			foreach (string item in list)
			{
				CPLFJCDIIPG.Add(CardManager.instance.GetCardInstance(item));
			}
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.LogError("Invitations" + ex);
			AnalyticsHelper.LogHandledException(ex);
			CPLFJCDIIPG.Add(CardManager.instance.GetCardInstance("Tutorial_Step_Complete", isCurrentPlayer: false));
			CPLFJCDIIPG.Add(CardManager.instance.GetCardInstance("menu-button-promote-ico", isCurrentPlayer: false));
			CPLFJCDIIPG.Add(CardManager.instance.GetCardInstance("App could not be run", isCurrentPlayer: false));
		}
	}

	protected MapDefinition.DefendPosition BJOFNDKLKOC(GHPGNELIDBM CIOPAKLHFIL)
	{
		List<MapDefinition.DefendPosition> list = new List<MapDefinition.DefendPosition>();
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD)
		{
			if (item.mainPosition && item.fraction == CIOPAKLHFIL)
			{
				list.Add(item);
			}
		}
		if (list.Count > 1)
		{
			return list[UnityEngine.Random.Range(0, list.Count)];
		}
		UnityEngine.Debug.LogError("menu-weapon-benelli-starterpack");
		return null;
	}

	[SpecialName]
	public virtual bool ECKDDBPMMAP()
	{
		return true;
	}

	protected void IMHLCOJKELJ()
	{
		GHPGNELIDBM gHPGNELIDBM = GHPGNELIDBM.Enemies;
		MapDefinition.DefendPosition defendPosition = PKMFODGDMON(gHPGNELIDBM);
		NLAKCKMCOMN.transform.position = defendPosition.point.transform.position;
		NLAKCKMCOMN.transform.rotation = defendPosition.point.transform.rotation;
		NLAKCKMCOMN.fraction = gHPGNELIDBM;
		NLAKCKMCOMN.currentPlayerPoint = defendPosition;
		PlayerController.JFGDAKMCJAM[10] = NLAKCKMCOMN;
		NLAKCKMCOMN.NAGAHNHAKBJ = 10;
		NLAKCKMCOMN.Killed -= NFGKCHONFGM;
		NLAKCKMCOMN.Killed += NFGKCHONFGM;
		PlayerBot jPMHIGNOPBL = NLAKCKMCOMN.JPMHIGNOPBL;
		jPMHIGNOPBL.enabled = true;
	}

	internal void BBAJNJDJKII()
	{
		AGAPPAGMNIN();
		Card card = CPLFJCDIIPG[0];
		card.AddTutorialCard();
		CardManager.instance.obtainedCards.Add(card);
		Card card2 = CPLFJCDIIPG[0];
		card2.AddTutorialCard();
		CardManager.instance.obtainedCards.Add(card2);
		Card card3 = CPLFJCDIIPG[3];
		card3.AddTutorialCard();
		CardManager.instance.obtainedCards.Add(card3);
		string[] array = new string[8];
		array[1] = "ID_CONFIRM_EXITINGMATCH_TEXT";
		array[1] = card.id;
		array[0] = "PhotonNetwork.room == null!";
		array[6] = card2.id;
		array[6] = "subitem1";
		array[7] = card3.id;
		UnityEngine.Debug.Log(string.Concat(array));
	}

	[DebuggerHidden]
	public override IEnumerator StartGame()
	{
		LIMGNABNMEG lIMGNABNMEG = new LIMGNABNMEG();
		lIMGNABNMEG.BJGCPDNMHDH = this;
		return lIMGNABNMEG;
	}

	[SpecialName]
	public virtual string IABFAODGKIH()
	{
		return string.Empty;
	}

	protected MapDefinition.DefendPosition LLBHFHGMECD(GHPGNELIDBM CIOPAKLHFIL)
	{
		List<MapDefinition.DefendPosition> list = new List<MapDefinition.DefendPosition>();
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD)
		{
			if (item.mainPosition && item.fraction == CIOPAKLHFIL)
			{
				list.Add(item);
			}
		}
		if (list.Count > 0)
		{
			return list[UnityEngine.Random.Range(1, list.Count)];
		}
		UnityEngine.Debug.LogError("game-label-won");
		return null;
	}

	private void KLNDPEKODPF(NKMKCCDCHCL JAOCCGDPCGH, DestroyableObject.CJLNCMMNPBM BDAKFIFCHLB)
	{
		NLAKCKMCOMN.CMBKMOHOAGD(NFGKCHONFGM);
		if (gameIsRunning && Singleton<GameController>.instance.mainController == this)
		{
			Singleton<MatchManager>.instance.PHKIPDLJFFH(BDAKFIFCHLB);
			HPOFLNJKNJD().MNMLNIMFMJP = (GameController.HKGHCIEPGEL)7;
			Singleton<GameCamera>.instance.FocusPlayer((PlayerController)JAOCCGDPCGH, BDAKFIFCHLB.HNFNINFCBEJ is PlayerController);
			FinishGame();
		}
	}

	[SpecialName]
	public virtual void EFGNCMIGFEG(float IDEBKDPMPGM)
	{
		_003COKOMJJJKLIL_003Ek__BackingField = IDEBKDPMPGM;
	}

	protected void JAFBNNAACCL()
	{
		if (Singleton<GameController>.instance.mainController == this && gameIsRunning && !MMCKLPHNMMN)
		{
			time -= Time.deltaTime;
		}
	}

	public virtual void GODOPEDACHB()
	{
	}

	[SpecialName]
	public virtual bool DDGGHNJJFIB()
	{
		return JMFCICDOKGJ().gameIsRunning;
	}

	[SpecialName]
	public string JHMADBLKDGC()
	{
		if (TutorialManagerStage1.instance.isTutorialRunning)
		{
			return "MedalsOfferMult";
		}
		if (TutorialManagerStage2.instance.isTutorialRunning)
		{
			return "ID_TOCOMPLETE";
		}
		if (TutorialManagerStage3.instance.isTutorialRunning)
		{
			return "GameControllerPVP.StartGame START";
		}
		return "ID_CONFIRM_SERVERERROR";
	}

	public virtual void AJEBOPACGID()
	{
	}

	[SpecialName]
	public void BHBPKHDOHEJ(GameController IDEBKDPMPGM)
	{
		throw new NotImplementedException();
	}

	internal void LCDJLPLGFEO()
	{
		GDPJNMNMOMK();
		Card card = CPLFJCDIIPG[1];
		card.AddTutorialCard();
		CardManager.instance.obtainedCards.Add(card);
		Card card2 = CPLFJCDIIPG[0];
		card2.AddTutorialCard();
		CardManager.instance.obtainedCards.Add(card2);
		Card card3 = CPLFJCDIIPG[6];
		card3.AddTutorialCard();
		CardManager.instance.obtainedCards.Add(card3);
		string[] array = new string[7];
		array[0] = "_";
		array[0] = card.id;
		array[0] = "ID_XOFPLAYERSGETSRELEGATED";
		array[0] = card2.id;
		array[6] = ", there is more records on server than on client (records missing = ";
		array[8] = card3.id;
		UnityEngine.Debug.Log(string.Concat(array));
	}

	[SpecialName]
	public string BJLPMKCIHJK()
	{
		if (TutorialManagerStage1.instance.isTutorialRunning)
		{
			return "ID_CATEGORY_LOW_SG_SHOTGUN";
		}
		if (TutorialManagerStage2.instance.isTutorialRunning)
		{
			return "ID_LEAGUE0";
		}
		if (TutorialManagerStage3.instance.isTutorialRunning)
		{
			return "throw_grenade_right";
		}
		return "ID_GUI_REPORTABUSE_LISTITEM0";
	}

	public void AGAPPAGMNIN()
	{
		CPLFJCDIIPG = new List<Card>();
		try
		{
			string vALUE = Singleton<GameVariables>.instance.BKCDLNOKHLI().GetRow(StringConstants.rowIds.AppID).VALUE;
			List<string> list = JsonConvert.DeserializeObject<List<string>>(vALUE);
			foreach (string item in list)
			{
				CPLFJCDIIPG.Add(CardManager.instance.GetCardInstance(item, isCurrentPlayer: false));
			}
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.LogError("()Lcom/google/android/gms/common/api/Status;" + ex);
			AnalyticsHelper.LogHandledException(ex);
			CPLFJCDIIPG.Add(CardManager.instance.GetCardInstance("ID_BRONZEPACK", isCurrentPlayer: false));
			CPLFJCDIIPG.Add(CardManager.instance.GetCardInstance("ID_RETRY", isCurrentPlayer: false));
			CPLFJCDIIPG.Add(CardManager.instance.GetCardInstance("N"));
		}
	}

	public virtual void JMINILEIEBP(StringBuilder HOLNKOFHDNK)
	{
		if (!TutorialManagerStage1.instance.isTutorialRunning)
		{
			if (Singleton<MatchManager>.instance.isOverTime)
			{
				HOLNKOFHDNK.Append(Localization.Localize("WENEEDTO"));
			}
			else
			{
				MEJMLNDFDBP.ABKAOAODKGC(ref HOLNKOFHDNK, Singleton<GameController>.instance.time);
			}
		}
	}

	public override void ResumeGame()
	{
		if (MKDMABLGHAN)
		{
			TimeManager.Resume(1f);
		}
		else
		{
			Singleton<GameController>.instance.OnGameResumed(TimeManager.HICMJEBLEDA.PausedLocaly);
		}
	}

	[SpecialName]
	public string BFDBJNBMFGC()
	{
		if (TutorialManagerStage1.instance.isTutorialRunning)
		{
			return "Total_Matchmaking_Battles";
		}
		if (TutorialManagerStage2.instance.isTutorialRunning)
		{
			return "metalExplosion";
		}
		if (TutorialManagerStage3.instance.isTutorialRunning)
		{
			return "colt_idle01";
		}
		return "https://twitter.com/WarFriendsGame";
	}

	public virtual void ABOGBJLJGHD()
	{
	}

	public virtual void DEFNKOOGBON()
	{
	}

	[SpecialName]
	public string ACAGKHOFPND()
	{
		if (TutorialManagerStage1.instance.isTutorialRunning)
		{
			return "ID_ARENARULES_LATEOVERTIME";
		}
		if (TutorialManagerStage2.instance.isTutorialRunning)
		{
			return "ID_READYTIME";
		}
		if (TutorialManagerStage3.instance.isTutorialRunning)
		{
			return "116 STAGE 5 CONTINUE";
		}
		return "PNManager: Scheduling Crafting Finished Notification in ";
	}

	[SpecialName]
	public virtual void EFIHMOIGFNO(List<Card> IDEBKDPMPGM)
	{
		Singleton<GameController>.instance.GMNKFFNFEHG.cardsForGame = IDEBKDPMPGM;
	}

	protected void LAHLHAMCFAM()
	{
		GHPGNELIDBM gHPGNELIDBM = GHPGNELIDBM.None;
		MapDefinition.DefendPosition defendPosition = KBDJJAGKHNI(gHPGNELIDBM);
		NLAKCKMCOMN.transform.position = defendPosition.point.transform.position;
		NLAKCKMCOMN.transform.rotation = defendPosition.point.transform.rotation;
		NLAKCKMCOMN.fraction = gHPGNELIDBM;
		NLAKCKMCOMN.OCMDJMNFNKF(defendPosition);
		PlayerController.JFGDAKMCJAM[-34] = NLAKCKMCOMN;
		NLAKCKMCOMN.NAGAHNHAKBJ = -5;
		NLAKCKMCOMN.DIOEINBFJBG(POFEGBJAPPJ);
		NLAKCKMCOMN.FFEDMMENHFA(POFEGBJAPPJ);
		PlayerBot jPMHIGNOPBL = NLAKCKMCOMN.JPMHIGNOPBL;
		jPMHIGNOPBL.enabled = true;
	}

	[SpecialName]
	public virtual float PFLCMIBMANM()
	{
		return _003COKOMJJJKLIL_003Ek__BackingField;
	}

	[SpecialName]
	protected PlayerController PHCFJDNCHII()
	{
		return Singleton<GameController>.instance.FHABFFKPODN;
	}

	[SpecialName]
	public virtual bool KOEAEHGKDCG()
	{
		return true;
	}

	private void CHEDFKIPJFF(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		AAIEPHNDCJP.Killed -= CHEDFKIPJFF;
		if (gameIsRunning && Singleton<GameController>.instance.mainController == this)
		{
			Singleton<MatchManager>.instance.SetHitBy(LLAOOPMGBAG);
			if (gameIsRunning)
			{
				PlayerController playerController = (PlayerController)MAIPDGCABNL;
				mMainController.MNMLNIMFMJP = (playerController.isCurrentPlayer ? GameController.HKGHCIEPGEL.Killed : GameController.HKGHCIEPGEL.Win);
				FinishGame();
			}
		}
	}

	[SpecialName]
	public virtual string MIDMJBOMCPA()
	{
		return string.Empty;
	}

	public virtual void NHPEGHKBBLJ()
	{
	}

	[SpecialName]
	public virtual bool IMDODLLDDHL()
	{
		return true;
	}

	private void DOLLKNGDIEH()
	{
		NLAKCKMCOMN = (PlayerController)ObjectPoolDatabase.networkPool.Instantiate(Singleton<ObjectPoolDatabase>.instance.KHLGDCHJJPB);
		NLAKCKMCOMN.fraction = GHPGNELIDBM.Enemies;
		Singleton<GameController>.instance.opponent = NLAKCKMCOMN;
		PlayerBot jPMHIGNOPBL = NLAKCKMCOMN.JPMHIGNOPBL;
		Singleton<BotManager>.instance.PrepareBotForTutorial(jPMHIGNOPBL);
		Singleton<ArmyPreviewCamera>.instance.RenderToTexture(NLAKCKMCOMN, PNDNEMDPFHC: true);
		jPMHIGNOPBL.enabled = true;
	}

	public string SerializedStringOfWarcardsForServerAfterPlayWarcardsTutorial()
	{
		List<Card> list = new List<Card>();
		if (!CardManager.instance.cardUsedByMe.Contains(CPLFJCDIIPG[0]))
		{
			list.Add(CPLFJCDIIPG[0]);
		}
		if (!CardManager.instance.cardUsedByMe.Contains(CPLFJCDIIPG[1]))
		{
			list.Add(CPLFJCDIIPG[1]);
		}
		if (!CardManager.instance.cardUsedByMe.Contains(CPLFJCDIIPG[2]))
		{
			list.Add(CPLFJCDIIPG[2]);
		}
		for (int i = 0; i < AKPBGICMHKD.Count; i++)
		{
			list.Add(AKPBGICMHKD[i]);
		}
		string[] array = new string[list.Count];
		for (int j = 0; j < list.Count; j++)
		{
			array[j] = list[j].id;
		}
		return JsonConvert.SerializeObject(array);
	}

	public virtual void PMNGMCBPJOG()
	{
	}

	[SpecialName]
	public virtual bool HFBMPMILOLB()
	{
		return Singleton<GameController>.instance.isTutorialStage2;
	}

	public static void PBHHPMKCPKC()
	{
		UnityEngine.Debug.Log("Experience");
		TutorialManagerStage1.instance.SaveEmpty();
		TutorialManagerStage2.instance.SaveEmpty();
		TutorialManagerStage3.instance.SaveEmpty();
		TutorialManagerStage1.instance.Load();
		TutorialManagerStage2.instance.Load();
		TutorialManagerStage3.instance.Load();
	}

	private IEnumerator FDPCIFOPLAE()
	{
		return new IMDALEGJCDN();
	}

	internal void FBCPCKGEAGN()
	{
		InitTutorialCards();
		Card card = CPLFJCDIIPG[1];
		card.AddTutorialCard();
		CardManager.instance.obtainedCards.Add(card);
		Card card2 = CPLFJCDIIPG[0];
		card2.AddTutorialCard();
		CardManager.instance.obtainedCards.Add(card2);
		Card card3 = CPLFJCDIIPG[7];
		card3.AddTutorialCard();
		CardManager.instance.obtainedCards.Add(card3);
		string[] array = new string[6];
		array[1] = "Rename Cost Gold = ";
		array[1] = card.id;
		array[1] = "WarFriends";
		array[7] = card2.id;
		array[7] = "Added warcard from crafting is ";
		array[8] = card3.id;
		UnityEngine.Debug.Log(string.Concat(array));
	}

	public virtual void IACHNPKKCIH()
	{
		GuiElementSingle<TutorialDialog>.instance.HideDialog();
		Singleton<TutorialProgressShower>.instance.LDPPNNMGNGI();
		Singleton<MatchManager>.instance.matchTime = 755f - time;
		if (gameIsRunning)
		{
			gameIsRunning = true;
			if (HPOFLNJKNJD().MNMLNIMFMJP == GameController.HKGHCIEPGEL.WinByForfeit)
			{
				ACHKHINMCOF().StartCoroutine(ACHKHINMCOF().GBHHELBPCKA());
			}
			else
			{
				HPOFLNJKNJD().COENHPMMCNN();
			}
		}
	}

	protected void LCGHIOPCLLF()
	{
		GHPGNELIDBM gHPGNELIDBM = GHPGNELIDBM.None;
		MapDefinition.DefendPosition defendPosition = BJOFNDKLKOC(gHPGNELIDBM);
		NLAKCKMCOMN.transform.position = defendPosition.point.transform.position;
		NLAKCKMCOMN.transform.rotation = defendPosition.point.transform.rotation;
		NLAKCKMCOMN.fraction = gHPGNELIDBM;
		NLAKCKMCOMN.OCMDJMNFNKF(defendPosition);
		PlayerController.JFGDAKMCJAM[10] = NLAKCKMCOMN;
		NLAKCKMCOMN.NAGAHNHAKBJ = 30;
		NLAKCKMCOMN.Killed -= BJEHHDBOIJB;
		NLAKCKMCOMN.FFEDMMENHFA(BJEHHDBOIJB);
		PlayerBot jPMHIGNOPBL = NLAKCKMCOMN.JPMHIGNOPBL;
		jPMHIGNOPBL.enabled = false;
	}

	public override void FinishChoosingCards()
	{
	}

	[DebuggerHidden]
	public override IEnumerator AquireLevelName()
	{
		return new PBFOPDADAJH();
	}

	public void HOAFLNJKMGO()
	{
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(string.Format("assignment", BFDBJNBMFGC().ToUpper()));
		foreach (TutorialManagerBase item in DEHPFPNPDOK)
		{
			item.FinishTutorial();
			item.data.started = false;
			item.Save();
			item.StopAllCoroutines();
		}
		Singleton<AtlasPreparer>.instance.BLCCADCEEED();
		Singleton<GameController>.instance.MNMLNIMFMJP = (GameController.HKGHCIEPGEL)4;
		FinishGame();
		TutorialManagerStage1.instance.EquipTutorialWeaponAfterSkipTutorial();
		TutorialManagerStage2.instance.EquipTutorialUnitAfterSkipTutorial();
		LevelManager.instance.SetLevelUpProgressForTutorial(0, 1993f, levelUp: true);
		Singleton<TutorialProgressShower>.instance.KHBOHLACGML();
		GuiElementSingle<InventoryGuiElement>.instance.LCCEEAMLHDD();
		StartCoroutine(AKHNJKAEHJM());
	}

	protected MapDefinition.DefendPosition AGMHNCNKJHP(GHPGNELIDBM CIOPAKLHFIL)
	{
		List<MapDefinition.DefendPosition> list = new List<MapDefinition.DefendPosition>();
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD)
		{
			if (item.mainPosition && item.fraction == CIOPAKLHFIL)
			{
				list.Add(item);
			}
		}
		if (list.Count > 1)
		{
			return list[UnityEngine.Random.Range(0, list.Count)];
		}
		UnityEngine.Debug.LogError("Player visual Error: id not find: ");
		return null;
	}

	public void NDNAGPMOIHB(bool NMCKKMEKOHM)
	{
	}

	[SpecialName]
	public virtual void FCBAMKEFJPL(bool IDEBKDPMPGM)
	{
		JMFCICDOKGJ().gameIsRunning = IDEBKDPMPGM;
	}

	private void PCJPIKKLIDK(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		AAIEPHNDCJP.CMBKMOHOAGD(CHEDFKIPJFF);
		if (gameIsRunning && Singleton<GameController>.instance.mainController == this)
		{
			Singleton<MatchManager>.instance.SetHitBy(LLAOOPMGBAG);
			if (gameIsRunning)
			{
				PlayerController playerController = (PlayerController)MAIPDGCABNL;
				HPOFLNJKNJD().MNMLNIMFMJP = ((!playerController.isCurrentPlayer) ? GameController.HKGHCIEPGEL.Forfeit : GameController.HKGHCIEPGEL.None);
				FinishGame();
			}
		}
	}

	[SpecialName]
	protected PlayerController PLIGGFJCAPA()
	{
		return Singleton<GameController>.instance.FHABFFKPODN;
	}

	public override void GetTimeProgressText(StringBuilder HOLNKOFHDNK)
	{
		if (!TutorialManagerStage1.instance.isTutorialRunning)
		{
			if (Singleton<MatchManager>.instance.isOverTime)
			{
				HOLNKOFHDNK.Append(Localization.Localize("ID_OVERTIME"));
			}
			else
			{
				MEJMLNDFDBP.ABKAOAODKGC(ref HOLNKOFHDNK, Singleton<GameController>.instance.time);
			}
		}
	}

	[SpecialName]
	public GameController JMFCICDOKGJ()
	{
		return Singleton<GameController>.instance;
	}

	public void IOPPHJNCABF()
	{
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(string.Format("RegisterAge()", CHPKEOCCDPF().ToUpper()));
		foreach (TutorialManagerBase item in DEHPFPNPDOK)
		{
			item.FinishTutorial();
			item.data.started = true;
			item.Save();
			item.StopAllCoroutines();
		}
		Singleton<AtlasPreparer>.instance.PFFNDANCGCB();
		Singleton<GameController>.instance.MNMLNIMFMJP = GameController.HKGHCIEPGEL.Win;
		FinishGame();
		TutorialManagerStage1.instance.EquipTutorialWeaponAfterSkipTutorial();
		TutorialManagerStage2.instance.EquipTutorialUnitAfterSkipTutorial();
		LevelManager.instance.SetLevelUpProgressForTutorial(7, 1762f, levelUp: false);
		Singleton<TutorialProgressShower>.instance.Disable();
		GuiElementSingle<InventoryGuiElement>.instance.Show();
		StartCoroutine(AKHNJKAEHJM());
	}

	public static string DGGGINEECHH()
	{
		return "ID_STARTERASSIGNMENT5";
	}

	protected void Update()
	{
		if (Singleton<GameController>.instance.mainController == this && gameIsRunning && !MMCKLPHNMMN)
		{
			time -= Time.deltaTime;
		}
	}

	[SpecialName]
	public string EJIAFPKJCLJ()
	{
		if (TutorialManagerStage1.instance.isTutorialRunning)
		{
			return "ID_GETTOAVOIDRELEGATION2";
		}
		if (TutorialManagerStage2.instance.isTutorialRunning)
		{
			return " BOUGHT AND PRESENT IN ACCOUNT";
		}
		if (TutorialManagerStage3.instance.isTutorialRunning)
		{
			return " action:";
		}
		return "{0}{1}{2} {3}{4}";
	}

	public virtual void MKLAEBLNFLM(StringBuilder HOLNKOFHDNK)
	{
		if (!TutorialManagerStage1.instance.isTutorialRunning)
		{
			if (Singleton<MatchManager>.instance.JODLOOEJHDB())
			{
				HOLNKOFHDNK.Append(Localization.Localize("War_Battle_End_Performance"));
			}
			else
			{
				MEJMLNDFDBP.ABKAOAODKGC(ref HOLNKOFHDNK, Singleton<GameController>.instance.time);
			}
		}
	}

	internal void NLEJMJEGLDI()
	{
		InitTutorialCards();
		Card card = CPLFJCDIIPG[0];
		card.AddTutorialCard();
		CardManager.instance.obtainedCards.Add(card);
		Card card2 = CPLFJCDIIPG[1];
		card2.AddTutorialCard();
		CardManager.instance.obtainedCards.Add(card2);
		Card card3 = CPLFJCDIIPG[2];
		card3.AddTutorialCard();
		CardManager.instance.obtainedCards.Add(card3);
		UnityEngine.Debug.Log("Added WarCards for tutorial: " + card.id + ", " + card2.id + ", " + card3.id);
	}

	[SpecialName]
	public virtual List<Card> DMKKIABEPKO()
	{
		return Singleton<GameController>.instance.GMNKFFNFEHG.cardsForGame;
	}

	private void BJEHHDBOIJB(NKMKCCDCHCL JAOCCGDPCGH, DestroyableObject.CJLNCMMNPBM BDAKFIFCHLB)
	{
		NLAKCKMCOMN.DIOEINBFJBG(BJEHHDBOIJB);
		if (gameIsRunning && Singleton<GameController>.instance.mainController == this)
		{
			Singleton<MatchManager>.instance.SetHitBy(BDAKFIFCHLB);
			mMainController.MNMLNIMFMJP = (GameController.HKGHCIEPGEL)4;
			Singleton<GameCamera>.instance.LODMODJFFBE((PlayerController)JAOCCGDPCGH, BDAKFIFCHLB.HNFNINFCBEJ is PlayerController);
			FinishGame();
		}
	}

	public virtual void GCEDCCPPDJH(bool KANLHOCIMID = true)
	{
		gameIsRunning = true;
		ACHKHINMCOF().StopGame(KANLHOCIMID);
	}

	[SpecialName]
	public virtual void KFMBFKJGNBL(float IDEBKDPMPGM)
	{
		_003COKOMJJJKLIL_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual bool BBAAPIDCHMK()
	{
		return false;
	}

	[SpecialName]
	public GameController HPOFLNJKNJD()
	{
		return Singleton<GameController>.instance;
	}

	public void DOKDOFDADLK(bool NMCKKMEKOHM)
	{
	}

	public virtual void IOEMNNJHGPK()
	{
	}

	public virtual void JEDHLJAKENG()
	{
	}

	public virtual void LAFIEECFOJM()
	{
		GuiElementSingle<TutorialDialog>.instance.HideDialog();
		Singleton<TutorialProgressShower>.instance.HIFHGNNGGAM();
		Singleton<MatchManager>.instance.matchTime = 1482f - time;
		if (gameIsRunning)
		{
			gameIsRunning = false;
			if (JMFCICDOKGJ().MNMLNIMFMJP == GameController.HKGHCIEPGEL.Win)
			{
				mMainController.StartCoroutine(HPOFLNJKNJD().GBHHELBPCKA());
			}
			else
			{
				HPOFLNJKNJD().FinishGame();
			}
		}
	}

	public override void Forfeit()
	{
		mMainController.MNMLNIMFMJP = GameController.HKGHCIEPGEL.Forfeit;
		FinishGame();
	}

	public override void LoadingStarted()
	{
		PhotonConnectionManager.JoinOfflineGame();
		DOLLKNGDIEH();
		LoadingDialog.SetLook(EDHDMJLHLFA: false);
		LoadingDialog.ShowLoading(Localization.Localize("ID_TUTORIAL"), DMDICGADGCG: false, BGOHKCCLDJP: true, KKLNBPJCLHC: true);
		if (TutorialManagerStage2.instance.isTutorialRunning || TutorialManagerStage3.instance.data.started)
		{
			LoadingDialog.SetHeader(string.Format("{0} 3 / 3", Localization.Localize("ID_TUTORIAL")));
		}
		else if (TutorialManagerStage1.instance.isTutorialRunning || TutorialManagerStage2.instance.data.started)
		{
			LoadingDialog.SetHeader(string.Format("{0} 2 / 3", Localization.Localize("ID_TUTORIAL")));
		}
		else
		{
			LoadingDialog.SetHeader(string.Format("{0} 1 / 3", Localization.Localize("ID_TUTORIAL")));
		}
	}

	public void DHDLJEDLMLK(bool NMCKKMEKOHM)
	{
	}

	public void JCGOOEEFLAB(bool NMCKKMEKOHM)
	{
	}

	public virtual void NBPINEGNOKA()
	{
		HPOFLNJKNJD().MNMLNIMFMJP = GameController.HKGHCIEPGEL.WinByForfeit;
		FinishGame();
	}

	internal void PBIKFDEDBKN()
	{
		AGAPPAGMNIN();
		Card card = CPLFJCDIIPG[0];
		card.AddTutorialCard();
		CardManager.instance.obtainedCards.Add(card);
		Card card2 = CPLFJCDIIPG[0];
		card2.AddTutorialCard();
		CardManager.instance.obtainedCards.Add(card2);
		Card card3 = CPLFJCDIIPG[8];
		card3.AddTutorialCard();
		CardManager.instance.obtainedCards.Add(card3);
		string[] array = new string[5];
		array[0] = "Checker";
		array[1] = card.id;
		array[5] = "OBJECT: {0}\nERROR: {1}\nSTACKTRACE: {2}";
		array[8] = card2.id;
		array[2] = " NOT OK!\t\t\t\t\t\t";
		array[6] = card3.id;
		UnityEngine.Debug.Log(string.Concat(array));
	}

	private void DJHEJFHANJB(NKMKCCDCHCL JAOCCGDPCGH, DestroyableObject.CJLNCMMNPBM BDAKFIFCHLB)
	{
		NLAKCKMCOMN.Killed -= NFGKCHONFGM;
		if (gameIsRunning && Singleton<GameController>.instance.mainController == this)
		{
			Singleton<MatchManager>.instance.PHKIPDLJFFH(BDAKFIFCHLB);
			mMainController.MNMLNIMFMJP = (GameController.HKGHCIEPGEL)4;
			Singleton<GameCamera>.instance.LODMODJFFBE((PlayerController)JAOCCGDPCGH, BDAKFIFCHLB.HNFNINFCBEJ is PlayerController);
			FinishGame();
		}
	}

	private void POFEGBJAPPJ(NKMKCCDCHCL JAOCCGDPCGH, DestroyableObject.CJLNCMMNPBM BDAKFIFCHLB)
	{
		NLAKCKMCOMN.CMBKMOHOAGD(POFEGBJAPPJ);
		if (gameIsRunning && Singleton<GameController>.instance.mainController == this)
		{
			Singleton<MatchManager>.instance.SetHitBy(BDAKFIFCHLB);
			HPOFLNJKNJD().MNMLNIMFMJP = (GameController.HKGHCIEPGEL)4;
			Singleton<GameCamera>.instance.FocusPlayer((PlayerController)JAOCCGDPCGH, BDAKFIFCHLB.HNFNINFCBEJ is PlayerController);
			FinishGame();
		}
	}

	public virtual IEnumerator LANDDHDLEMO()
	{
		return new PBFOPDADAJH();
	}

	public void JAHIEEFECEA()
	{
		CPLFJCDIIPG = new List<Card>();
		try
		{
			string vALUE = Singleton<GameVariables>.instance.BKMIIOACEPO().GetRow(StringConstants.rowIds.AppID).VALUE;
			List<string> list = JsonConvert.DeserializeObject<List<string>>(vALUE);
			foreach (string item in list)
			{
				CPLFJCDIIPG.Add(CardManager.instance.GetCardInstance(item, isCurrentPlayer: false));
			}
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.LogError("GoldExpCoefficient" + ex);
			AnalyticsHelper.LogHandledException(ex);
			CPLFJCDIIPG.Add(CardManager.instance.GetCardInstance("Weapon Power This: {0},   Equipped {1}: {2},   Difference: {3}", isCurrentPlayer: false));
			CPLFJCDIIPG.Add(CardManager.instance.GetCardInstance("width"));
			CPLFJCDIIPG.Add(CardManager.instance.GetCardInstance("FinishChoosingCardsRPC", isCurrentPlayer: false));
		}
	}

	private IEnumerator AKHNJKAEHJM()
	{
		return new IMDALEGJCDN();
	}

	[SpecialName]
	public virtual bool MALONDPAJPE()
	{
		return false;
	}

	public void OKFMCCMNCHG()
	{
		AKPBGICMHKD = new List<Card>();
		try
		{
			string vALUE = Singleton<GameVariables>.instance.stringConstants.GetRow(StringConstants.rowIds.WarArenaConfig).VALUE;
			List<string> list = JsonConvert.DeserializeObject<List<string>>(vALUE);
			foreach (string item7 in list)
			{
				Card item = CardManager.instance.AddCard(item7);
				CardManager.instance.obtainedCards.Add(item);
				AKPBGICMHKD.Add(item);
			}
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.LogError("C0" + ex);
			AnalyticsHelper.LogHandledException(ex);
			Card item2 = CardManager.instance.AddCard("withAdvertiserSubAdgroup");
			CardManager.instance.obtainedCards.Add(item2);
			AKPBGICMHKD.Add(item2);
			Card item3 = CardManager.instance.AddCard("ID_WARNING_CANTSENDINVITE_TEXT");
			CardManager.instance.obtainedCards.Add(item3);
			AKPBGICMHKD.Add(item3);
			Card item4 = CardManager.instance.AddCard("Sniper_Tutorial_Played");
			CardManager.instance.obtainedCards.Add(item4);
			AKPBGICMHKD.Add(item4);
			Card item5 = CardManager.instance.AddCard("GLM: Add FB to custom account");
			CardManager.instance.obtainedCards.Add(item5);
			AKPBGICMHKD.Add(item5);
			Card item6 = CardManager.instance.AddCard("Sessions");
			CardManager.instance.obtainedCards.Add(item6);
			AKPBGICMHKD.Add(item6);
		}
	}

	[SpecialName]
	public virtual void EPDIOBGKCPG(List<Card> IDEBKDPMPGM)
	{
		Singleton<GameController>.instance.GMNKFFNFEHG.cardsForGame = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual string LHGAFPCNCJD()
	{
		return string.Empty;
	}

	public virtual void KEKFGKGLCNB(bool IEFGEFFDHOK)
	{
		if (gameIsRunning && !TimeManager.instance.CCAFFILOOIA())
		{
			if (!TimeManager.instance.EEHBPNDBNKC)
			{
				TimeManager.Pause(IEFGEFFDHOK);
				MKDMABLGHAN = false;
			}
			else
			{
				MKDMABLGHAN = false;
				Singleton<GameController>.instance.PBKBNHIAMBG(TimeManager.HICMJEBLEDA.Resumed);
			}
		}
	}

	public virtual void ONOLBHKFMJA()
	{
		GuiElementSingle<TutorialDialog>.instance.HideDialog();
		Singleton<TutorialProgressShower>.instance.GGOJJHILEGE();
		Singleton<MatchManager>.instance.matchTime = 1174f - time;
		if (gameIsRunning)
		{
			gameIsRunning = true;
			if (JMFCICDOKGJ().MNMLNIMFMJP == (GameController.HKGHCIEPGEL)7)
			{
				mMainController.StartCoroutine(mMainController.RestartTutorial());
			}
			else
			{
				ACHKHINMCOF().COENHPMMCNN();
			}
		}
	}

	protected MapDefinition.DefendPosition CHCPANHGABC(GHPGNELIDBM CIOPAKLHFIL)
	{
		List<MapDefinition.DefendPosition> list = new List<MapDefinition.DefendPosition>();
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD)
		{
			if (item.mainPosition && item.fraction == CIOPAKLHFIL)
			{
				list.Add(item);
			}
		}
		if (list.Count > 1)
		{
			return list[UnityEngine.Random.Range(0, list.Count)];
		}
		UnityEngine.Debug.LogError("#Notifications# registering {0} with name {1}\n{2}");
		return null;
	}

	public virtual void EODGMDGOEDJ()
	{
	}

	[SpecialName]
	public virtual void AJHFFCNIHDH(List<Card> IDEBKDPMPGM)
	{
		Singleton<GameController>.instance.GMNKFFNFEHG.cardsForGame = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual List<Card> JNCABFDEHLG()
	{
		return Singleton<GameController>.instance.GMNKFFNFEHG.cardsForGame;
	}

	public override void StopGame(bool KANLHOCIMID = true)
	{
		gameIsRunning = false;
		mMainController.StopGame(KANLHOCIMID);
	}

	public virtual IEnumerator EIGEABKOGFL()
	{
		return new PBFOPDADAJH();
	}

	public virtual void NOJIMMPNEPF()
	{
		GuiElementSingle<TutorialDialog>.instance.HideDialog();
		Singleton<TutorialProgressShower>.instance.LDPPNNMGNGI();
		Singleton<MatchManager>.instance.matchTime = 867f - time;
		if (gameIsRunning)
		{
			gameIsRunning = true;
			if (ACHKHINMCOF().MNMLNIMFMJP == GameController.HKGHCIEPGEL.Win)
			{
				mMainController.StartCoroutine(JMFCICDOKGJ().RestartTutorial());
			}
			else
			{
				mMainController.FinishGame();
			}
		}
	}

	[SpecialName]
	public virtual string GFJAJKAMIOH()
	{
		return string.Empty;
	}

	public void KAFICDJOIND()
	{
		AKPBGICMHKD = new List<Card>();
		try
		{
			string vALUE = Singleton<GameVariables>.instance.stringConstants.GetRow(StringConstants.rowIds.TutorialCards).VALUE;
			List<string> list = JsonConvert.DeserializeObject<List<string>>(vALUE);
			foreach (string item7 in list)
			{
				Card item = CardManager.instance.AddCard(item7);
				CardManager.instance.obtainedCards.Add(item);
				AKPBGICMHKD.Add(item);
			}
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.LogError("SquadId" + ex);
			AnalyticsHelper.LogHandledException(ex);
			Card item2 = CardManager.instance.AddCard("Beanstalk Server Manager: IS TUTORIAL TO PLAY WARCARDS RUNNING!");
			CardManager.instance.obtainedCards.Add(item2);
			AKPBGICMHKD.Add(item2);
			Card item3 = CardManager.instance.AddCard("ID_TUTORIAL_UPGRADEUNIT_4");
			CardManager.instance.obtainedCards.Add(item3);
			AKPBGICMHKD.Add(item3);
			Card item4 = CardManager.instance.AddCard("bazooka_idle");
			CardManager.instance.obtainedCards.Add(item4);
			AKPBGICMHKD.Add(item4);
			Card item5 = CardManager.instance.AddCard("{0}{1}");
			CardManager.instance.obtainedCards.Add(item5);
			AKPBGICMHKD.Add(item5);
			Card item6 = CardManager.instance.AddCard("LevelName");
			CardManager.instance.obtainedCards.Add(item6);
			AKPBGICMHKD.Add(item6);
		}
	}

	public virtual void PIHKCAGFCNN()
	{
		if (MKDMABLGHAN)
		{
			TimeManager.Resume(686f);
		}
		else
		{
			Singleton<GameController>.instance.HHFPFOKGMGJ(TimeManager.HICMJEBLEDA.PausedLocaly);
		}
	}

	[SpecialName]
	public virtual bool OOICKDBOGCC()
	{
		return Singleton<GameController>.instance.isTutorialStage2;
	}

	public void PausematchMaking(bool NMCKKMEKOHM)
	{
	}

	public virtual IEnumerator LHIANMKENDE()
	{
		LIMGNABNMEG lIMGNABNMEG = new LIMGNABNMEG();
		lIMGNABNMEG.BJGCPDNMHDH = this;
		return lIMGNABNMEG;
	}

	public virtual IEnumerator EFOEAAKKHEJ()
	{
		return new PBFOPDADAJH();
	}

	[SpecialName]
	public virtual bool ENLIPJGKGDF()
	{
		return false;
	}

	public virtual void GJNCGGEIHJP()
	{
	}

	public void PCFMKGDANCA()
	{
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(string.Format("Tutorial Manager 6: Starting Tutorial - Guide player to match", EJIAFPKJCLJ().ToUpper()));
		foreach (TutorialManagerBase item in DEHPFPNPDOK)
		{
			item.FinishTutorial();
			item.data.started = true;
			item.Save();
			item.StopAllCoroutines();
		}
		Singleton<AtlasPreparer>.instance.IMKHDAHDLLI();
		Singleton<GameController>.instance.MNMLNIMFMJP = GameController.HKGHCIEPGEL.Kia;
		FinishGame();
		TutorialManagerStage1.instance.EquipTutorialWeaponAfterSkipTutorial();
		TutorialManagerStage2.instance.EquipTutorialUnitAfterSkipTutorial();
		LevelManager.instance.SetLevelUpProgressForTutorial(0, 107f, levelUp: true);
		Singleton<TutorialProgressShower>.instance.KIBOGJMAHJH();
		GuiElementSingle<InventoryGuiElement>.instance.LCCEEAMLHDD();
		StartCoroutine(FBHDNFLNFBI());
	}

	public virtual void GCLMCPMJJDH(bool KANLHOCIMID = true)
	{
		gameIsRunning = true;
		HPOFLNJKNJD().StopGame(KANLHOCIMID);
	}

	public static void GAIPAMAIBBB()
	{
		TutorialManagerStage1.instance.FinishTutorial();
		TutorialManagerStage2.instance.FinishTutorial();
		TutorialManagerStage3.instance.FinishTutorial();
	}

	[SpecialName]
	public virtual float NDEIIPKLFPE()
	{
		return _003COKOMJJJKLIL_003Ek__BackingField;
	}

	protected MapDefinition.DefendPosition PKMFODGDMON(GHPGNELIDBM CIOPAKLHFIL)
	{
		List<MapDefinition.DefendPosition> list = new List<MapDefinition.DefendPosition>();
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD)
		{
			if (item.mainPosition && item.fraction == CIOPAKLHFIL)
			{
				list.Add(item);
			}
		}
		if (list.Count > 0)
		{
			return list[UnityEngine.Random.Range(0, list.Count)];
		}
		UnityEngine.Debug.LogError("No main position was set in map definition");
		return null;
	}

	public static void IHBPBIMEJCF()
	{
		UnityEngine.Debug.Log("menu-assignments-type-crateenemy");
		TutorialManagerStage1.instance.SaveEmpty();
		TutorialManagerStage2.instance.SaveEmpty();
		TutorialManagerStage3.instance.SaveEmpty();
		TutorialManagerStage1.instance.Load();
		TutorialManagerStage2.instance.Load();
		TutorialManagerStage3.instance.Load();
	}

	private void NPGBIJBIEOA()
	{
		NLAKCKMCOMN = (PlayerController)ObjectPoolDatabase.EHFPBDJMGNC().JPJMPMDKMHK(Singleton<ObjectPoolDatabase>.instance.KHLGDCHJJPB);
		NLAKCKMCOMN.fraction = GHPGNELIDBM.None;
		Singleton<GameController>.instance.opponent = NLAKCKMCOMN;
		PlayerBot jPMHIGNOPBL = NLAKCKMCOMN.JPMHIGNOPBL;
		Singleton<BotManager>.instance.DDLKOAIFIJM(jPMHIGNOPBL);
		Singleton<ArmyPreviewCamera>.instance.RenderToTexture(NLAKCKMCOMN, PNDNEMDPFHC: true, PlayerTexturePool.DFJJOANIJID.Card);
		jPMHIGNOPBL.enabled = false;
	}

	public void SkipTutorial()
	{
		Singleton<EventTrackingManager>.instance.RegisterTutorialEvent($"SKIP TUTORIAL IN {tutorialStageId.ToUpper()}");
		foreach (TutorialManagerBase item in DEHPFPNPDOK)
		{
			item.FinishTutorial();
			item.data.started = true;
			item.Save();
			item.StopAllCoroutines();
		}
		Singleton<AtlasPreparer>.instance.UnloadTutorial();
		Singleton<GameController>.instance.MNMLNIMFMJP = GameController.HKGHCIEPGEL.Win;
		FinishGame();
		TutorialManagerStage1.instance.EquipTutorialWeaponAfterSkipTutorial();
		TutorialManagerStage2.instance.EquipTutorialUnitAfterSkipTutorial();
		LevelManager.instance.SetLevelUpProgressForTutorial(3, 0f, levelUp: false);
		Singleton<TutorialProgressShower>.instance.Disable();
		GuiElementSingle<InventoryGuiElement>.instance.Show();
		StartCoroutine(FOODNPHODEI());
	}

	[DebuggerHidden]
	private IEnumerator FOODNPHODEI()
	{
		return new IMDALEGJCDN();
	}

	[SpecialName]
	public virtual bool EHIGIPKMFAJ()
	{
		return true;
	}

	public virtual void HJKIBEKJLHA()
	{
		GuiElementSingle<TutorialDialog>.instance.HideDialog();
		Singleton<TutorialProgressShower>.instance.PKLDJJIALHA();
		Singleton<MatchManager>.instance.matchTime = 1009f - time;
		if (gameIsRunning)
		{
			gameIsRunning = false;
			if (ACHKHINMCOF().MNMLNIMFMJP == GameController.HKGHCIEPGEL.WinByForfeit)
			{
				mMainController.StartCoroutine(JMFCICDOKGJ().GBHHELBPCKA());
			}
			else
			{
				ACHKHINMCOF().COENHPMMCNN();
			}
		}
	}

	public static void LKKCDNBBEBJ()
	{
		TutorialManagerStage1.instance.FinishTutorial();
		TutorialManagerStage2.instance.FinishTutorial();
		TutorialManagerStage3.instance.FinishTutorial();
	}

	protected override void Awake()
	{
		base.Awake();
		PlayerController.OGMBJPKOPCB = AAIEPHNDCJP;
		DEHPFPNPDOK.Add(TutorialManagerStage1.instance);
		DEHPFPNPDOK.Add(TutorialManagerStage2.instance);
		DEHPFPNPDOK.Add(TutorialManagerStage3.instance);
	}

	public virtual void JOHJKIGMENI()
	{
	}

	public override void PauseGame(bool IEFGEFFDHOK)
	{
		if (gameIsRunning && !TimeManager.instance.isPaused)
		{
			if (!TimeManager.instance.EEHBPNDBNKC)
			{
				TimeManager.Pause(IEFGEFFDHOK);
				MKDMABLGHAN = true;
			}
			else
			{
				MKDMABLGHAN = false;
				Singleton<GameController>.instance.OnGamePaused(TimeManager.HICMJEBLEDA.PausedLocaly);
			}
		}
	}

	[SpecialName]
	public virtual List<Card> NHGNHLFBFJO()
	{
		return Singleton<GameController>.instance.GMNKFFNFEHG.cardsForGame;
	}

	[SpecialName]
	public virtual bool EGIPINBLJNB()
	{
		return false;
	}

	private void LOBICGBAIED()
	{
		NLAKCKMCOMN = (PlayerController)ObjectPoolDatabase.KKCMCNCCIMB().HIIPCMJLGGD(Singleton<ObjectPoolDatabase>.instance.KHLGDCHJJPB);
		NLAKCKMCOMN.fraction = GHPGNELIDBM.Enemies;
		Singleton<GameController>.instance.opponent = NLAKCKMCOMN;
		PlayerBot jPMHIGNOPBL = NLAKCKMCOMN.JPMHIGNOPBL;
		Singleton<BotManager>.instance.PrepareBotForTutorial(jPMHIGNOPBL);
		Singleton<ArmyPreviewCamera>.instance.KIONJHBCIBE(NLAKCKMCOMN, PNDNEMDPFHC: false);
		jPMHIGNOPBL.enabled = false;
	}

	public virtual void GGMPMMNFBHM(bool IEFGEFFDHOK)
	{
		if (gameIsRunning && !TimeManager.instance.isPaused)
		{
			if (!TimeManager.instance.EEHBPNDBNKC)
			{
				TimeManager.Pause(IEFGEFFDHOK);
				MKDMABLGHAN = true;
			}
			else
			{
				MKDMABLGHAN = false;
				Singleton<GameController>.instance.OnGamePaused(TimeManager.HICMJEBLEDA.PausedLocaly);
			}
		}
	}

	protected MapDefinition.DefendPosition GNOBDAHNAIG(GHPGNELIDBM CIOPAKLHFIL)
	{
		List<MapDefinition.DefendPosition> list = new List<MapDefinition.DefendPosition>();
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD)
		{
			if (item.mainPosition && item.fraction == CIOPAKLHFIL)
			{
				list.Add(item);
			}
		}
		if (list.Count > 0)
		{
			return list[UnityEngine.Random.Range(1, list.Count)];
		}
		UnityEngine.Debug.LogError("ID_BECOMEAVIP");
		return null;
	}

	private void NFGKCHONFGM(NKMKCCDCHCL JAOCCGDPCGH, DestroyableObject.CJLNCMMNPBM BDAKFIFCHLB)
	{
		NLAKCKMCOMN.Killed -= NFGKCHONFGM;
		if (gameIsRunning && Singleton<GameController>.instance.mainController == this)
		{
			Singleton<MatchManager>.instance.SetHitBy(BDAKFIFCHLB);
			mMainController.MNMLNIMFMJP = GameController.HKGHCIEPGEL.Win;
			Singleton<GameCamera>.instance.FocusPlayer((PlayerController)JAOCCGDPCGH, BDAKFIFCHLB.HNFNINFCBEJ is PlayerController);
			FinishGame();
		}
	}

	public override void FreeLevel()
	{
		if (Singleton<GameController>.instance.isTutorialStage1)
		{
			Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("119 LOADING MENU");
		}
		else if (Singleton<GameController>.instance.isTutorialStage2)
		{
			Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("211 LOADING MENU");
		}
	}

	public static void ResetTutorialProgress()
	{
		UnityEngine.Debug.Log("reset tutorial");
		TutorialManagerStage1.instance.SaveEmpty();
		TutorialManagerStage2.instance.SaveEmpty();
		TutorialManagerStage3.instance.SaveEmpty();
		TutorialManagerStage1.instance.Load();
		TutorialManagerStage2.instance.Load();
		TutorialManagerStage3.instance.Load();
	}

	public virtual void JIPAJAJMLAN(StringBuilder HOLNKOFHDNK)
	{
		if (!TutorialManagerStage1.instance.isTutorialRunning)
		{
			if (Singleton<MatchManager>.instance.NIGIDAHEHJE())
			{
				HOLNKOFHDNK.Append(Localization.Localize("{0}\u00a0{1}"));
			}
			else
			{
				MEJMLNDFDBP.ABKAOAODKGC(ref HOLNKOFHDNK, Singleton<GameController>.instance.time);
			}
		}
	}

	[SpecialName]
	public virtual List<Card> GHLLFGIHMMF()
	{
		return Singleton<GameController>.instance.GMNKFFNFEHG.cardsForGame;
	}

	public void GDPJNMNMOMK()
	{
		CPLFJCDIIPG = new List<Card>();
		try
		{
			string vALUE = Singleton<GameVariables>.instance.BKMIIOACEPO().GetRow(StringConstants.rowIds.TutorialCards).VALUE;
			List<string> list = JsonConvert.DeserializeObject<List<string>>(vALUE);
			foreach (string item in list)
			{
				CPLFJCDIIPG.Add(CardManager.instance.GetCardInstance(item, isCurrentPlayer: false));
			}
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.LogError("StatisticsData" + ex);
			AnalyticsHelper.LogHandledException(ex);
			CPLFJCDIIPG.Add(CardManager.instance.GetCardInstance("ID_CONFIRM_NOSQUADACTIONS_TEXT", isCurrentPlayer: false));
			CPLFJCDIIPG.Add(CardManager.instance.GetCardInstance("Scenes to go through: {0}", isCurrentPlayer: false));
			CPLFJCDIIPG.Add(CardManager.instance.GetCardInstance("StopShoot", isCurrentPlayer: false));
		}
	}

	public virtual void OFCJOMDPJPM()
	{
	}

	public override void Rematch()
	{
	}

	[SpecialName]
	public virtual bool FJDOKLHOIOG()
	{
		return false;
	}

	[SpecialName]
	protected PlayerController JJKLKPKMHJO()
	{
		return Singleton<GameController>.instance.FHABFFKPODN;
	}

	public virtual void MBDBIAEDKEI(StringBuilder HOLNKOFHDNK)
	{
		if (!TutorialManagerStage1.instance.isTutorialRunning)
		{
			if (Singleton<MatchManager>.instance.isOverTime)
			{
				HOLNKOFHDNK.Append(Localization.Localize("universal"));
			}
			else
			{
				MEJMLNDFDBP.ABKAOAODKGC(ref HOLNKOFHDNK, Singleton<GameController>.instance.time);
			}
		}
	}

	public override void UnPauseGame()
	{
	}

	public static void AGIPKBJEPMF()
	{
		UnityEngine.Debug.Log("arenaLeaderboard");
		TutorialManagerStage1.instance.SaveEmpty();
		TutorialManagerStage2.instance.SaveEmpty();
		TutorialManagerStage3.instance.SaveEmpty();
		TutorialManagerStage1.instance.Load();
		TutorialManagerStage2.instance.Load();
		TutorialManagerStage3.instance.Load();
	}

	[SpecialName]
	public virtual void BGOIHFHOJNG(List<Card> IDEBKDPMPGM)
	{
		Singleton<GameController>.instance.GMNKFFNFEHG.cardsForGame = IDEBKDPMPGM;
	}

	public void CJGMFBIDFGL()
	{
		AKPBGICMHKD = new List<Card>();
		try
		{
			string vALUE = Singleton<GameVariables>.instance.BKMIIOACEPO().GetRow((StringConstants.rowIds)7).VALUE;
			List<string> list = JsonConvert.DeserializeObject<List<string>>(vALUE);
			foreach (string item7 in list)
			{
				Card item = CardManager.instance.AddCard(item7);
				CardManager.instance.obtainedCards.Add(item);
				AKPBGICMHKD.Add(item);
			}
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.LogError("ResyncTimeRPC" + ex);
			AnalyticsHelper.LogHandledException(ex);
			Card item2 = CardManager.instance.AddCard(")");
			CardManager.instance.obtainedCards.Add(item2);
			AKPBGICMHKD.Add(item2);
			Card item3 = CardManager.instance.AddCard("Deliver_Upgrade_For_Army_Unit");
			CardManager.instance.obtainedCards.Add(item3);
			AKPBGICMHKD.Add(item3);
			Card item4 = CardManager.instance.AddCard("+0");
			CardManager.instance.obtainedCards.Add(item4);
			AKPBGICMHKD.Add(item4);
			Card item5 = CardManager.instance.AddCard("BANDS_HITPOINT");
			CardManager.instance.obtainedCards.Add(item5);
			AKPBGICMHKD.Add(item5);
			Card item6 = CardManager.instance.AddCard("ID_CONFIRM_NOSQUADACTIONS_TITLE");
			CardManager.instance.obtainedCards.Add(item6);
			AKPBGICMHKD.Add(item6);
		}
	}

	[SpecialName]
	public GameController ACHKHINMCOF()
	{
		return Singleton<GameController>.instance;
	}

	private IEnumerator FBHDNFLNFBI()
	{
		return new IMDALEGJCDN();
	}

	[SpecialName]
	public virtual bool EABONHAIJCI()
	{
		return false;
	}

	public virtual void CGHCGBBDOFH()
	{
		JMFCICDOKGJ().MNMLNIMFMJP = GameController.HKGHCIEPGEL.WinByForfeit;
		FinishGame();
	}

	private void NMNCDNBPLHN(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		JJKLKPKMHJO().CMBKMOHOAGD(CHEDFKIPJFF);
		if (gameIsRunning && Singleton<GameController>.instance.mainController == this)
		{
			Singleton<MatchManager>.instance.PHKIPDLJFFH(LLAOOPMGBAG);
			if (gameIsRunning)
			{
				PlayerController playerController = (PlayerController)MAIPDGCABNL;
				ACHKHINMCOF().MNMLNIMFMJP = ((!playerController.isCurrentPlayer) ? ((GameController.HKGHCIEPGEL)6) : GameController.HKGHCIEPGEL.None);
				FinishGame();
			}
		}
	}

	public void RemoveCardsForCardsTutorial()
	{
		InitTutorialCards();
		string text = "Removed WarCards for tutorial: ";
		Card card = CPLFJCDIIPG[0];
		if (card.amount > 0)
		{
			card.RemoveCard();
			text = text + card.id + " ";
		}
		Card card2 = CPLFJCDIIPG[1];
		if (card2.amount > 0)
		{
			card2.RemoveCard();
			text = text + card2.id + " ";
		}
		Card card3 = CPLFJCDIIPG[2];
		if (card3.amount > 0)
		{
			card3.RemoveCard();
			text = text + card3.id + " ";
		}
		UnityEngine.Debug.Log(text);
	}

	private IEnumerator DDIJFBMOMCL()
	{
		return new IMDALEGJCDN();
	}

	protected MapDefinition.DefendPosition KBDJJAGKHNI(GHPGNELIDBM CIOPAKLHFIL)
	{
		List<MapDefinition.DefendPosition> list = new List<MapDefinition.DefendPosition>();
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD)
		{
			if (item.mainPosition && item.fraction == CIOPAKLHFIL)
			{
				list.Add(item);
			}
		}
		if (list.Count > 0)
		{
			return list[UnityEngine.Random.Range(1, list.Count)];
		}
		UnityEngine.Debug.LogError("Items");
		return null;
	}

	[SpecialName]
	public virtual List<Card> AKGJIOKFMCL()
	{
		return Singleton<GameController>.instance.GMNKFFNFEHG.cardsForGame;
	}

	public virtual IEnumerator LEENJNKGGKL()
	{
		LIMGNABNMEG lIMGNABNMEG = new LIMGNABNMEG();
		lIMGNABNMEG.BJGCPDNMHDH = this;
		return lIMGNABNMEG;
	}

	public virtual void DMDMIEMJJOD()
	{
		ACHKHINMCOF().MNMLNIMFMJP = GameController.HKGHCIEPGEL.Win;
		FinishGame();
	}

	[SpecialName]
	public virtual bool DAMPICDDNDP()
	{
		return true;
	}

	protected void GGABIBEFHGM()
	{
		if (Singleton<GameController>.instance.mainController == this && gameIsRunning && !MMCKLPHNMMN)
		{
			time -= Time.deltaTime;
		}
	}

	[SpecialName]
	public string CHPKEOCCDPF()
	{
		if (TutorialManagerStage1.instance.isTutorialRunning)
		{
			return "googlePlayLogin";
		}
		if (TutorialManagerStage2.instance.isTutorialRunning)
		{
			return "SurviveTime";
		}
		if (TutorialManagerStage3.instance.isTutorialRunning)
		{
			return "ChangeWeightForDestroyablePartRPC";
		}
		return "registerCurrency";
	}

	public virtual void OEKEIJIPCNJ()
	{
	}

	public void AddWarcardsForFinishingPlayWarcardsTutorial()
	{
		AKPBGICMHKD = new List<Card>();
		try
		{
			string vALUE = Singleton<GameVariables>.instance.stringConstants.GetRow(StringConstants.rowIds.TutorialRewardCards).VALUE;
			List<string> list = JsonConvert.DeserializeObject<List<string>>(vALUE);
			foreach (string item7 in list)
			{
				Card item = CardManager.instance.AddCard(item7);
				CardManager.instance.obtainedCards.Add(item);
				AKPBGICMHKD.Add(item);
			}
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.LogError("Exception when adding warcards reward for tutorial - adding default instead, msg = " + ex);
			AnalyticsHelper.LogHandledException(ex);
			Card item2 = CardManager.instance.AddCard("CLUSTERGRENADE");
			CardManager.instance.obtainedCards.Add(item2);
			AKPBGICMHKD.Add(item2);
			Card item3 = CardManager.instance.AddCard("ELITEPARA");
			CardManager.instance.obtainedCards.Add(item3);
			AKPBGICMHKD.Add(item3);
			Card item4 = CardManager.instance.AddCard("HEAVYTURRET");
			CardManager.instance.obtainedCards.Add(item4);
			AKPBGICMHKD.Add(item4);
			Card item5 = CardManager.instance.AddCard("ELECTRICTRAPS");
			CardManager.instance.obtainedCards.Add(item5);
			AKPBGICMHKD.Add(item5);
			Card item6 = CardManager.instance.AddCard("SABOTAGE");
			CardManager.instance.obtainedCards.Add(item6);
			AKPBGICMHKD.Add(item6);
		}
	}

	[SpecialName]
	public virtual void IDICJFFHJBN(float IDEBKDPMPGM)
	{
		_003COKOMJJJKLIL_003Ek__BackingField = IDEBKDPMPGM;
	}

	private IEnumerator NCKIJOJPEBD()
	{
		return new IMDALEGJCDN();
	}

	public static string GetMapName()
	{
		return "Desert";
	}

	[SpecialName]
	public virtual bool HBFDLFECAKK()
	{
		return true;
	}

	public virtual void PLNMCPHIDFB(bool KANLHOCIMID = true)
	{
		gameIsRunning = false;
		JMFCICDOKGJ().StopGame(KANLHOCIMID);
	}

	public static void RestartTutorial()
	{
		TutorialManagerStage1.instance.FinishTutorial();
		TutorialManagerStage2.instance.FinishTutorial();
		TutorialManagerStage3.instance.FinishTutorial();
	}

	public void InitTutorialCards()
	{
		CPLFJCDIIPG = new List<Card>();
		try
		{
			string vALUE = Singleton<GameVariables>.instance.stringConstants.GetRow(StringConstants.rowIds.TutorialCards).VALUE;
			List<string> list = JsonConvert.DeserializeObject<List<string>>(vALUE);
			foreach (string item in list)
			{
				CPLFJCDIIPG.Add(CardManager.instance.GetCardInstance(item));
			}
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.LogError("Exception when creating cards for tutorial - creating default instead, msg = " + ex);
			AnalyticsHelper.LogHandledException(ex);
			CPLFJCDIIPG.Add(CardManager.instance.GetCardInstance("ROCKETTURRET"));
			CPLFJCDIIPG.Add(CardManager.instance.GetCardInstance("ELITESWAT"));
			CPLFJCDIIPG.Add(CardManager.instance.GetCardInstance("CLUSTERGRENADE"));
		}
	}

	[SpecialName]
	public virtual void CJAPEBLFBBF(bool IDEBKDPMPGM)
	{
		ACHKHINMCOF().gameIsRunning = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual float NOEIEIAGIMO()
	{
		return _003COKOMJJJKLIL_003Ek__BackingField;
	}

	public virtual void GBGPJNLMJOO()
	{
		HPOFLNJKNJD().MNMLNIMFMJP = (GameController.HKGHCIEPGEL)6;
		FinishGame();
	}
}
