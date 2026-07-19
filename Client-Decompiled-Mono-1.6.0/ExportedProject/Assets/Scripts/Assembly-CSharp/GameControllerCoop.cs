using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

public class GameControllerCoop : GameControllerOnline
{
	private sealed class NCEKIFIDMCF : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal GameControllerCoop BJGCPDNMHDH;

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
		public NCEKIFIDMCF()
		{
		}

		[SpecialName]
		private object IDLFKAKINAP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MILFCGMBHIG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GMPGIODBIPO()
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
				ALJKAAMHHLB.POPONJAMPDF("GameControllerCoop.StartGame START");
				ObjectPoolDatabase.networkPool.FreeObjectsWithPrefab(Singleton<ObjectPoolDatabase>.instance.KHLGDCHJJPB);
				BJGCPDNMHDH.AAIEPHNDCJP.Killed -= BJGCPDNMHDH.CHEDFKIPJFF;
				BJGCPDNMHDH.AAIEPHNDCJP.Killed += BJGCPDNMHDH.CHEDFKIPJFF;
				GameControllerOnline.HMAIEJHCHDE.Killed -= BJGCPDNMHDH.LLCPCOECHFD;
				GameControllerOnline.HMAIEJHCHDE.Killed += BJGCPDNMHDH.LLCPCOECHFD;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.IABAJLPCCEL());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				BJGCPDNMHDH.time = 0f;
				PHDOCKCBJOF = new WaitForSeconds(0.2f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
				LoadingDialog.Hide();
				Singleton<GuiManager>.instance.FadeIn(GuiElementSingle<PlayerHealthBars>.instance);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 3u:
				BJGCPDNMHDH.FEHCCGEGPLH.RPC("StartCameraAnimationFinishedRPC", PhotonTargets.Others, PlayerController.OGMBJPKOPCB.NAGAHNHAKBJ);
				BJGCPDNMHDH.StartCameraAnimationFinishedRPC(PlayerController.OGMBJPKOPCB.NAGAHNHAKBJ);
				PHDOCKCBJOF = new WaitForSeconds(0.8f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 4u:
				ALJKAAMHHLB.POPONJAMPDF("GameControllerCoop.StartGame DONE");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void BLOCBAKBHBF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void OKIANDBCDIB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void JKOCLGOOBEK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void KHMNEOBMJLN()
		{
			throw new NotSupportedException();
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

		public bool CONJMMKAAGH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.BCPKGMMMOPH("ID_DOGTAGS");
				ObjectPoolDatabase.COJFMKNGPBP().FreeObjectsWithPrefab(Singleton<ObjectPoolDatabase>.instance.KHLGDCHJJPB);
				BJGCPDNMHDH.AAIEPHNDCJP.DIOEINBFJBG(BJGCPDNMHDH.CHEDFKIPJFF);
				BJGCPDNMHDH.AAIEPHNDCJP.FFEDMMENHFA(BJGCPDNMHDH.CHEDFKIPJFF);
				GameControllerOnline.HMAIEJHCHDE.Killed -= BJGCPDNMHDH.NFBJOLBAEEC;
				GameControllerOnline.HMAIEJHCHDE.Killed += BJGCPDNMHDH.NFBJOLBAEEC;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.IABAJLPCCEL());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				BJGCPDNMHDH.time = 1038f;
				PHDOCKCBJOF = new WaitForSeconds(1629f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 2u:
				LoadingDialog.Hide();
				Singleton<GuiManager>.instance.JPLLGFNECAG(GuiElementSingle<PlayerHealthBars>.instance);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(1443f));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 3u:
				BJGCPDNMHDH.FEHCCGEGPLH.RPC("ID_CONFIRM_EXITINGCOOP", PhotonTargets.Others, PlayerController.OGMBJPKOPCB.NAGAHNHAKBJ);
				BJGCPDNMHDH.StartCameraAnimationFinishedRPC(PlayerController.OGMBJPKOPCB.NAGAHNHAKBJ);
				PHDOCKCBJOF = new WaitForSeconds(189f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 4u:
				ALJKAAMHHLB.HAAIJJBEPPN("-ABILITYMAXDESC");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
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
				ALJKAAMHHLB.CIILNLBGGHM("ID_CRAFTABLEWARCARDS");
				ObjectPoolDatabase.INOJHPIKICM().FreeObjectsWithPrefab(Singleton<ObjectPoolDatabase>.instance.KHLGDCHJJPB);
				BJGCPDNMHDH.AAIEPHNDCJP.Killed -= BJGCPDNMHDH.CHEDFKIPJFF;
				BJGCPDNMHDH.AAIEPHNDCJP.Killed += BJGCPDNMHDH.CHEDFKIPJFF;
				GameControllerOnline.HMAIEJHCHDE.DIOEINBFJBG(BJGCPDNMHDH.LLCPCOECHFD);
				GameControllerOnline.HMAIEJHCHDE.Killed += BJGCPDNMHDH.NFBJOLBAEEC;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.IABAJLPCCEL());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				BJGCPDNMHDH.time = 1838f;
				PHDOCKCBJOF = new WaitForSeconds(921f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
				LoadingDialog.Hide();
				Singleton<GuiManager>.instance.FadeIn(GuiElementSingle<PlayerHealthBars>.instance);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(552f));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 3u:
			{
				PhotonView fEHCCGEGPLH = BJGCPDNMHDH.FEHCCGEGPLH;
				object[] array = new object[1];
				array[1] = PlayerController.OGMBJPKOPCB.NAGAHNHAKBJ;
				fEHCCGEGPLH.RPC("Gold", PhotonTargets.Others, array);
				BJGCPDNMHDH.StartCameraAnimationFinishedRPC(PlayerController.OGMBJPKOPCB.NAGAHNHAKBJ);
				PHDOCKCBJOF = new WaitForSeconds(1473f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			}
			case 4u:
				ALJKAAMHHLB.POPONJAMPDF("AtlasPreparer.ClearMenuLoadGameCoroutine");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object KKCOHEHPJPF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HHHLDCLIFKJ()
		{
			return PHDOCKCBJOF;
		}

		public void CHANLKFNCLA()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object NCKCKPNAHAD()
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
				ALJKAAMHHLB.BCFGNBMMJIB("getOriginalAccountAlias");
				ObjectPoolDatabase.COJFMKNGPBP().EMLIBBBMNLN(Singleton<ObjectPoolDatabase>.instance.KHLGDCHJJPB);
				BJGCPDNMHDH.AAIEPHNDCJP.DIOEINBFJBG(BJGCPDNMHDH.CHEDFKIPJFF);
				BJGCPDNMHDH.AAIEPHNDCJP.FFEDMMENHFA(BJGCPDNMHDH.CHEDFKIPJFF);
				GameControllerOnline.HMAIEJHCHDE.DIOEINBFJBG(BJGCPDNMHDH.OALMGHBFMJG);
				GameControllerOnline.HMAIEJHCHDE.FFEDMMENHFA(BJGCPDNMHDH.NFBJOLBAEEC);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.IABAJLPCCEL());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				BJGCPDNMHDH.time = 464f;
				PHDOCKCBJOF = new WaitForSeconds(1154f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
				LoadingDialog.Hide();
				Singleton<GuiManager>.instance.FadeIn(GuiElementSingle<PlayerHealthBars>.instance);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(1896f));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 3u:
			{
				PhotonView fEHCCGEGPLH = BJGCPDNMHDH.FEHCCGEGPLH;
				object[] array = new object[1];
				array[1] = PlayerController.OGMBJPKOPCB.NAGAHNHAKBJ;
				fEHCCGEGPLH.RPC("ID_CONFIRM_ERROR", PhotonTargets.Others, array);
				BJGCPDNMHDH.StartCameraAnimationFinishedRPC(PlayerController.OGMBJPKOPCB.NAGAHNHAKBJ);
				PHDOCKCBJOF = new WaitForSeconds(504f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			}
			case 4u:
				ALJKAAMHHLB.CJEDHGLIGJH("ID_VISUALRARITY1");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void CHFJIODFNIP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object EBPKDAHAELB()
		{
			return PHDOCKCBJOF;
		}

		public bool DKIKFMODFJF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.CJEDHGLIGJH("ID_TUTORIAL_UPGRADEWEAPON_8");
				ObjectPoolDatabase.DKNHCGGKNMF().EMLIBBBMNLN(Singleton<ObjectPoolDatabase>.instance.KHLGDCHJJPB);
				BJGCPDNMHDH.AAIEPHNDCJP.CMBKMOHOAGD(BJGCPDNMHDH.CHEDFKIPJFF);
				BJGCPDNMHDH.AAIEPHNDCJP.FDHJCAGOFKN(BJGCPDNMHDH.CHEDFKIPJFF);
				GameControllerOnline.HMAIEJHCHDE.CMBKMOHOAGD(BJGCPDNMHDH.LLCPCOECHFD);
				GameControllerOnline.HMAIEJHCHDE.FDHJCAGOFKN(BJGCPDNMHDH.LLCPCOECHFD);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.IABAJLPCCEL());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				BJGCPDNMHDH.time = 907f;
				PHDOCKCBJOF = new WaitForSeconds(430f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 2u:
				LoadingDialog.Hide();
				Singleton<GuiManager>.instance.FadeIn(GuiElementSingle<PlayerHealthBars>.instance);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(626f));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 3u:
			{
				PhotonView fEHCCGEGPLH = BJGCPDNMHDH.FEHCCGEGPLH;
				object[] array = new object[0];
				array[1] = PlayerController.OGMBJPKOPCB.NAGAHNHAKBJ;
				fEHCCGEGPLH.RPC("WENEEDTO", PhotonTargets.All, array);
				BJGCPDNMHDH.StartCameraAnimationFinishedRPC(PlayerController.OGMBJPKOPCB.NAGAHNHAKBJ);
				PHDOCKCBJOF = new WaitForSeconds(1090f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			}
			case 4u:
				ALJKAAMHHLB.CCDJDGFFCHC("Pack_Type");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object KJMPNHLOKJL()
		{
			return PHDOCKCBJOF;
		}

		public void MKIKEOOOLKL()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GDCFFBBNGHH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MBDBIPHLEIA()
		{
			return PHDOCKCBJOF;
		}

		public bool HKPECDLGFJB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.PIEBOOFPHPC("DOWNLOADBTN");
				ObjectPoolDatabase.COJFMKNGPBP().NDPKMHDALCM(Singleton<ObjectPoolDatabase>.instance.KHLGDCHJJPB);
				BJGCPDNMHDH.AAIEPHNDCJP.Killed -= BJGCPDNMHDH.CHEDFKIPJFF;
				BJGCPDNMHDH.AAIEPHNDCJP.FDHJCAGOFKN(BJGCPDNMHDH.CHEDFKIPJFF);
				GameControllerOnline.HMAIEJHCHDE.CMBKMOHOAGD(BJGCPDNMHDH.LLCPCOECHFD);
				GameControllerOnline.HMAIEJHCHDE.FDHJCAGOFKN(BJGCPDNMHDH.LLCPCOECHFD);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.IABAJLPCCEL());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				BJGCPDNMHDH.time = 947f;
				PHDOCKCBJOF = new WaitForSeconds(1995f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 2u:
				LoadingDialog.Hide();
				Singleton<GuiManager>.instance.POHMFFFEIED(GuiElementSingle<PlayerHealthBars>.instance);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(1334f));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 3u:
			{
				PhotonView fEHCCGEGPLH = BJGCPDNMHDH.FEHCCGEGPLH;
				object[] array = new object[0];
				array[0] = PlayerController.OGMBJPKOPCB.NAGAHNHAKBJ;
				fEHCCGEGPLH.RPC("+0", PhotonTargets.Others, array);
				BJGCPDNMHDH.StartCameraAnimationFinishedRPC(PlayerController.OGMBJPKOPCB.NAGAHNHAKBJ);
				PHDOCKCBJOF = new WaitForSeconds(1374f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			}
			case 4u:
				ALJKAAMHHLB.BIDJNBKOMIN(" a: ");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public bool KKINHOPBKLH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.DHPGNLOHBLC("InAppHandlerIos: Validating inapp on server... inappId = ");
				ObjectPoolDatabase.EHFPBDJMGNC().NDPKMHDALCM(Singleton<ObjectPoolDatabase>.instance.KHLGDCHJJPB);
				BJGCPDNMHDH.AAIEPHNDCJP.Killed -= BJGCPDNMHDH.CHEDFKIPJFF;
				BJGCPDNMHDH.AAIEPHNDCJP.FFEDMMENHFA(BJGCPDNMHDH.CHEDFKIPJFF);
				GameControllerOnline.HMAIEJHCHDE.DIOEINBFJBG(BJGCPDNMHDH.LLCPCOECHFD);
				GameControllerOnline.HMAIEJHCHDE.FDHJCAGOFKN(BJGCPDNMHDH.LLCPCOECHFD);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.IABAJLPCCEL());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				BJGCPDNMHDH.time = 555f;
				PHDOCKCBJOF = new WaitForSeconds(197f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
				LoadingDialog.Hide();
				Singleton<GuiManager>.instance.JPLLGFNECAG(GuiElementSingle<PlayerHealthBars>.instance);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(1368f));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 3u:
			{
				PhotonView fEHCCGEGPLH = BJGCPDNMHDH.FEHCCGEGPLH;
				object[] array = new object[0];
				array[1] = PlayerController.OGMBJPKOPCB.NAGAHNHAKBJ;
				fEHCCGEGPLH.RPC("ID_CONFIRM_RESTORE", PhotonTargets.All, array);
				BJGCPDNMHDH.StartCameraAnimationFinishedRPC(PlayerController.OGMBJPKOPCB.NAGAHNHAKBJ);
				PHDOCKCBJOF = new WaitForSeconds(818f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			}
			case 4u:
				ALJKAAMHHLB.IEBHKBNOEBP("[0-9.,]*");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object BNFADGLHBAH()
		{
			return PHDOCKCBJOF;
		}

		public void HCJOIAHBFGB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool IEDGDDDADFM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.BIDJNBKOMIN("BEGINNERS {0}   {1}.   {2}");
				ObjectPoolDatabase.CHHLLIAHECC().NDPKMHDALCM(Singleton<ObjectPoolDatabase>.instance.KHLGDCHJJPB);
				BJGCPDNMHDH.AAIEPHNDCJP.DIOEINBFJBG(BJGCPDNMHDH.CHEDFKIPJFF);
				BJGCPDNMHDH.AAIEPHNDCJP.Killed += BJGCPDNMHDH.CHEDFKIPJFF;
				GameControllerOnline.HMAIEJHCHDE.Killed -= BJGCPDNMHDH.OALMGHBFMJG;
				GameControllerOnline.HMAIEJHCHDE.Killed += BJGCPDNMHDH.LLCPCOECHFD;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.IABAJLPCCEL());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				BJGCPDNMHDH.time = 1070f;
				PHDOCKCBJOF = new WaitForSeconds(377f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 2u:
				LoadingDialog.Hide();
				Singleton<GuiManager>.instance.POHMFFFEIED(GuiElementSingle<PlayerHealthBars>.instance);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(955f));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 3u:
				BJGCPDNMHDH.FEHCCGEGPLH.RPC("ID_DEBUG_GUIERROR", PhotonTargets.All, PlayerController.OGMBJPKOPCB.NAGAHNHAKBJ);
				BJGCPDNMHDH.StartCameraAnimationFinishedRPC(PlayerController.OGMBJPKOPCB.NAGAHNHAKBJ);
				PHDOCKCBJOF = new WaitForSeconds(1701f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 4u:
				ALJKAAMHHLB.PJIMOPNDNKO("C5");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object AFDKAGLDADB()
		{
			return PHDOCKCBJOF;
		}

		public void ODFCBNONFPL()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BGAGLOJHMEJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IJFPHIKFJFB()
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
				ALJKAAMHHLB.ALPPDLMMCIH("Beanstalk: ");
				ObjectPoolDatabase.COJFMKNGPBP().EMLIBBBMNLN(Singleton<ObjectPoolDatabase>.instance.KHLGDCHJJPB);
				BJGCPDNMHDH.AAIEPHNDCJP.Killed -= BJGCPDNMHDH.CHEDFKIPJFF;
				BJGCPDNMHDH.AAIEPHNDCJP.FFEDMMENHFA(BJGCPDNMHDH.CHEDFKIPJFF);
				GameControllerOnline.HMAIEJHCHDE.DIOEINBFJBG(BJGCPDNMHDH.OALMGHBFMJG);
				GameControllerOnline.HMAIEJHCHDE.Killed += BJGCPDNMHDH.LLCPCOECHFD;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.IABAJLPCCEL());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				BJGCPDNMHDH.time = 315f;
				PHDOCKCBJOF = new WaitForSeconds(1406f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 2u:
				LoadingDialog.Hide();
				Singleton<GuiManager>.instance.POHMFFFEIED(GuiElementSingle<PlayerHealthBars>.instance);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(1756f));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 3u:
			{
				PhotonView fEHCCGEGPLH = BJGCPDNMHDH.FEHCCGEGPLH;
				object[] array = new object[0];
				array[0] = PlayerController.OGMBJPKOPCB.NAGAHNHAKBJ;
				fEHCCGEGPLH.RPC("ID_STAT_WEAPONSPURCHASED", PhotonTargets.Others, array);
				BJGCPDNMHDH.StartCameraAnimationFinishedRPC(PlayerController.OGMBJPKOPCB.NAGAHNHAKBJ);
				PHDOCKCBJOF = new WaitForSeconds(306f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			}
			case 4u:
				ALJKAAMHHLB.KEJEFPFHIFB("#DANIEL# Assignment Claimed: ");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object AGCPJGAAODG()
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
				ALJKAAMHHLB.KEJEFPFHIFB("SpecialFeature");
				ObjectPoolDatabase.CHHLLIAHECC().NDPKMHDALCM(Singleton<ObjectPoolDatabase>.instance.KHLGDCHJJPB);
				BJGCPDNMHDH.AAIEPHNDCJP.DIOEINBFJBG(BJGCPDNMHDH.CHEDFKIPJFF);
				BJGCPDNMHDH.AAIEPHNDCJP.Killed += BJGCPDNMHDH.CHEDFKIPJFF;
				GameControllerOnline.HMAIEJHCHDE.Killed -= BJGCPDNMHDH.NFBJOLBAEEC;
				GameControllerOnline.HMAIEJHCHDE.FDHJCAGOFKN(BJGCPDNMHDH.OALMGHBFMJG);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.IABAJLPCCEL());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				BJGCPDNMHDH.time = 303f;
				PHDOCKCBJOF = new WaitForSeconds(705f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
				LoadingDialog.Hide();
				Singleton<GuiManager>.instance.POHMFFFEIED(GuiElementSingle<PlayerHealthBars>.instance);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(1790f));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 3u:
			{
				PhotonView fEHCCGEGPLH = BJGCPDNMHDH.FEHCCGEGPLH;
				object[] array = new object[1];
				array[1] = PlayerController.OGMBJPKOPCB.NAGAHNHAKBJ;
				fEHCCGEGPLH.RPC("MatchStart", PhotonTargets.All, array);
				BJGCPDNMHDH.StartCameraAnimationFinishedRPC(PlayerController.OGMBJPKOPCB.NAGAHNHAKBJ);
				PHDOCKCBJOF = new WaitForSeconds(1939f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			}
			case 4u:
				ALJKAAMHHLB.BIDJNBKOMIN("ID_GETFORREWARD1");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void DLIBOPAMHAN()
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

		public void NINFNJOMJOD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object NAPMJAMDKMJ()
		{
			return PHDOCKCBJOF;
		}

		public void EMICCACCFIP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void MIEFKIEABBN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void CDDFJOEEFID()
		{
			throw new NotSupportedException();
		}

		public void PDKPELBIAON()
		{
			throw new NotSupportedException();
		}

		public bool MPKAJACHAIC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.BIDJNBKOMIN("Play_Card_Tutorial");
				ObjectPoolDatabase.MFKPDKCLDBI().NDPKMHDALCM(Singleton<ObjectPoolDatabase>.instance.KHLGDCHJJPB);
				BJGCPDNMHDH.AAIEPHNDCJP.Killed -= BJGCPDNMHDH.CHEDFKIPJFF;
				BJGCPDNMHDH.AAIEPHNDCJP.FFEDMMENHFA(BJGCPDNMHDH.CHEDFKIPJFF);
				GameControllerOnline.HMAIEJHCHDE.CMBKMOHOAGD(BJGCPDNMHDH.LLCPCOECHFD);
				GameControllerOnline.HMAIEJHCHDE.FFEDMMENHFA(BJGCPDNMHDH.NFBJOLBAEEC);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.IABAJLPCCEL());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				BJGCPDNMHDH.time = 544f;
				PHDOCKCBJOF = new WaitForSeconds(702f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 2u:
				LoadingDialog.Hide();
				Singleton<GuiManager>.instance.FadeIn(GuiElementSingle<PlayerHealthBars>.instance);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(596f));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 3u:
				BJGCPDNMHDH.FEHCCGEGPLH.RPC("ID_READYTIME", PhotonTargets.All, PlayerController.OGMBJPKOPCB.NAGAHNHAKBJ);
				BJGCPDNMHDH.StartCameraAnimationFinishedRPC(PlayerController.OGMBJPKOPCB.NAGAHNHAKBJ);
				PHDOCKCBJOF = new WaitForSeconds(1186f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 4u:
				ALJKAAMHHLB.HNMONAFFBLE("({0}\u00a0/\u00a0{1})");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void CPDBCJLIGFN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool FNEPBDLIKOD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.DHPGNLOHBLC("LevelName");
				ObjectPoolDatabase.EHFPBDJMGNC().FreeObjectsWithPrefab(Singleton<ObjectPoolDatabase>.instance.KHLGDCHJJPB);
				BJGCPDNMHDH.AAIEPHNDCJP.DIOEINBFJBG(BJGCPDNMHDH.CHEDFKIPJFF);
				BJGCPDNMHDH.AAIEPHNDCJP.Killed += BJGCPDNMHDH.CHEDFKIPJFF;
				GameControllerOnline.HMAIEJHCHDE.Killed -= BJGCPDNMHDH.OALMGHBFMJG;
				GameControllerOnline.HMAIEJHCHDE.Killed += BJGCPDNMHDH.LLCPCOECHFD;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.IABAJLPCCEL());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				BJGCPDNMHDH.time = 1996f;
				PHDOCKCBJOF = new WaitForSeconds(1152f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
				LoadingDialog.Hide();
				Singleton<GuiManager>.instance.POHMFFFEIED(GuiElementSingle<PlayerHealthBars>.instance);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(1091f));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 3u:
			{
				PhotonView fEHCCGEGPLH = BJGCPDNMHDH.FEHCCGEGPLH;
				object[] array = new object[0];
				array[1] = PlayerController.OGMBJPKOPCB.NAGAHNHAKBJ;
				fEHCCGEGPLH.RPC("ID_STARTERPACKCONTENTS", PhotonTargets.All, array);
				BJGCPDNMHDH.StartCameraAnimationFinishedRPC(PlayerController.OGMBJPKOPCB.NAGAHNHAKBJ);
				PHDOCKCBJOF = new WaitForSeconds(597f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			}
			case 4u:
				ALJKAAMHHLB.IEBHKBNOEBP("ID_POSITIONXYREWARD");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object JPJBNHHKOJD()
		{
			return PHDOCKCBJOF;
		}
	}

	private sealed class OILCCDFMJEJ : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal GameControllerCoop BJGCPDNMHDH;

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
		private object BNMEIAPPLDP()
		{
			return PHDOCKCBJOF;
		}

		public bool LPMIKEPIMCM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				if (GuiElementSingle<PauseScreen>.instance.NPFFMLLLDAF())
				{
					GuiElementSingle<PauseScreen>.instance.HideDialog();
				}
				goto case 0u;
			case 0u:
				if (!GuiScreenSingle<GameOverScreen>.instance.isAnimationFinished)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				TimeManager.instance.SetupPhysicsTiming(true);
				Singleton<PerformanceManager>.instance.LCOIHOCJGLF(false);
				Singleton<GameCamera>.instance.SetTarget(GameControllerOnline.HMAIEJHCHDE);
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<SpectateScreen>.instance);
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(true);
				if (TimeManager.instance.isPaused && BJGCPDNMHDH.gameIsRunning)
				{
					TimeManager.FODFANEEDFF();
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<PauseScreen>.instance, 692f);
				}
				else
				{
					TimeManager.UnFreezeGame(603f);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object MIKGAKNJGKL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PNBPOAMPNKP()
		{
			return PHDOCKCBJOF;
		}

		public bool DAKMHLEGICB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				if (GuiElementSingle<PauseScreen>.instance.NPFFMLLLDAF())
				{
					GuiElementSingle<PauseScreen>.instance.HideDialog();
				}
				goto case 0u;
			case 0u:
				if (!GuiScreenSingle<GameOverScreen>.instance.isAnimationFinished)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				TimeManager.instance.SetupPhysicsTiming(true);
				Singleton<PerformanceManager>.instance.MBIALLFNEFO(false);
				Singleton<GameCamera>.instance.SetTarget(GameControllerOnline.HMAIEJHCHDE);
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SpectateScreen>.instance);
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(true);
				if (TimeManager.instance.GDJLMGAHHOH() && BJGCPDNMHDH.gameIsRunning)
				{
					TimeManager.FODFANEEDFF();
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<PauseScreen>.instance, 1382f);
				}
				else
				{
					TimeManager.UnFreezeGame(865f);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object ANBCMDOAJCM()
		{
			return PHDOCKCBJOF;
		}

		public bool CBGPIONEKLM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				if (GuiElementSingle<PauseScreen>.instance.NPFFMLLLDAF())
				{
					GuiElementSingle<PauseScreen>.instance.HideDialog();
				}
				goto case 0u;
			case 0u:
				if (!GuiScreenSingle<GameOverScreen>.instance.isAnimationFinished)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				TimeManager.instance.SetupPhysicsTiming(false);
				Singleton<PerformanceManager>.instance.AGMMGEJNAMD(true);
				Singleton<GameCamera>.instance.SetTarget(GameControllerOnline.HMAIEJHCHDE);
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SpectateScreen>.instance);
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(true);
				if (TimeManager.instance.isPaused && BJGCPDNMHDH.gameIsRunning)
				{
					TimeManager.DCODDANOPCP();
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<PauseScreen>.instance, 397f);
				}
				else
				{
					TimeManager.UnFreezeGame(1658f);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void HLJMNBBDJGE()
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
			case 1u:
				if (GuiElementSingle<PauseScreen>.instance.isShowed)
				{
					GuiElementSingle<PauseScreen>.instance.HideDialog();
				}
				goto case 0u;
			case 0u:
				if (!GuiScreenSingle<GameOverScreen>.instance.BFNOINNNHGP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				TimeManager.instance.SetupPhysicsTiming(true);
				Singleton<PerformanceManager>.instance.LCOIHOCJGLF(true);
				Singleton<GameCamera>.instance.SetTarget(GameControllerOnline.HMAIEJHCHDE);
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SpectateScreen>.instance);
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(true);
				if (TimeManager.instance.CCAFFILOOIA() && BJGCPDNMHDH.gameIsRunning)
				{
					TimeManager.DCODDANOPCP();
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<PauseScreen>.instance, 1346f);
				}
				else
				{
					TimeManager.UnFreezeGame(347f);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public bool MPKAJACHAIC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				if (GuiElementSingle<PauseScreen>.instance.NPFFMLLLDAF())
				{
					GuiElementSingle<PauseScreen>.instance.HideDialog();
				}
				goto case 0u;
			case 0u:
				if (!GuiScreenSingle<GameOverScreen>.instance.isAnimationFinished)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				TimeManager.instance.SetupPhysicsTiming(false);
				Singleton<PerformanceManager>.instance.MBIALLFNEFO(true);
				Singleton<GameCamera>.instance.AIDAFGCCCDO(GameControllerOnline.HMAIEJHCHDE);
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<SpectateScreen>.instance);
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(false);
				if (TimeManager.instance.GDJLMGAHHOH() && BJGCPDNMHDH.gameIsRunning)
				{
					TimeManager.DCODDANOPCP();
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<PauseScreen>.instance, 390f);
				}
				else
				{
					TimeManager.UnFreezeGame(1740f);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void KLIEOBHDFCG()
		{
			throw new NotSupportedException();
		}

		public void GFJIKANGNMC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void ELMJLOBAMKH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool ONIAGKNGBHE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				if (GuiElementSingle<PauseScreen>.instance.isShowed)
				{
					GuiElementSingle<PauseScreen>.instance.HideDialog();
				}
				goto case 0u;
			case 0u:
				if (!GuiScreenSingle<GameOverScreen>.instance.BFNOINNNHGP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				TimeManager.instance.SetupPhysicsTiming(false);
				Singleton<PerformanceManager>.instance.SetShadowsDistance(false);
				Singleton<GameCamera>.instance.AIDAFGCCCDO(GameControllerOnline.HMAIEJHCHDE);
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<SpectateScreen>.instance);
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(true);
				if (TimeManager.instance.isPaused && BJGCPDNMHDH.gameIsRunning)
				{
					TimeManager.FreezeGame();
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<PauseScreen>.instance, 272f);
				}
				else
				{
					TimeManager.UnFreezeGame(473f);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object MPHILJJDNIO()
		{
			return PHDOCKCBJOF;
		}

		public bool HCONPNNPBAD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				if (GuiElementSingle<PauseScreen>.instance.NPFFMLLLDAF())
				{
					GuiElementSingle<PauseScreen>.instance.HideDialog();
				}
				goto case 0u;
			case 0u:
				if (!GuiScreenSingle<GameOverScreen>.instance.isAnimationFinished)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				TimeManager.instance.SetupPhysicsTiming(true);
				Singleton<PerformanceManager>.instance.SetShadowsDistance(false);
				Singleton<GameCamera>.instance.SetTarget(GameControllerOnline.HMAIEJHCHDE);
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<SpectateScreen>.instance);
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(false);
				if (TimeManager.instance.isPaused && BJGCPDNMHDH.gameIsRunning)
				{
					TimeManager.FreezeGame();
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<PauseScreen>.instance, 932f);
				}
				else
				{
					TimeManager.UnFreezeGame(1145f);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void FIENOOBNNGD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object EFIEEKFCBJH()
		{
			return PHDOCKCBJOF;
		}

		public bool GPIPJIDGCKM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				if (GuiElementSingle<PauseScreen>.instance.isShowed)
				{
					GuiElementSingle<PauseScreen>.instance.HideDialog();
				}
				goto case 0u;
			case 0u:
				if (!GuiScreenSingle<GameOverScreen>.instance.BFNOINNNHGP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				TimeManager.instance.SetupPhysicsTiming(true);
				Singleton<PerformanceManager>.instance.AKNADEPIPNP(true);
				Singleton<GameCamera>.instance.SetTarget(GameControllerOnline.HMAIEJHCHDE);
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<SpectateScreen>.instance);
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(true);
				if (TimeManager.instance.isPaused && BJGCPDNMHDH.gameIsRunning)
				{
					TimeManager.DCODDANOPCP();
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<PauseScreen>.instance, 670f);
				}
				else
				{
					TimeManager.UnFreezeGame(696f);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void KKDOJDCJAJB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object CPAFPFPNDNO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OJMKDIBHMND()
		{
			return PHDOCKCBJOF;
		}

		public void GGCLMIMHKBD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CMNCAPEMEJI()
		{
			return PHDOCKCBJOF;
		}

		public void JKBIMBFGGCO()
		{
			throw new NotSupportedException();
		}

		public bool IGOKEIDOCKB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				if (GuiElementSingle<PauseScreen>.instance.isShowed)
				{
					GuiElementSingle<PauseScreen>.instance.HideDialog();
				}
				goto case 0u;
			case 0u:
				if (!GuiScreenSingle<GameOverScreen>.instance.isAnimationFinished)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				TimeManager.instance.SetupPhysicsTiming(true);
				Singleton<PerformanceManager>.instance.AGMMGEJNAMD(false);
				Singleton<GameCamera>.instance.AIDAFGCCCDO(GameControllerOnline.HMAIEJHCHDE);
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SpectateScreen>.instance);
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(false);
				if (TimeManager.instance.CCAFFILOOIA() && BJGCPDNMHDH.gameIsRunning)
				{
					TimeManager.DCODDANOPCP();
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<PauseScreen>.instance, 290f);
				}
				else
				{
					TimeManager.UnFreezeGame(978f);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void PHEIGPKKPGE()
		{
			throw new NotSupportedException();
		}

		public void EKPOLGNAAOI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GKJIGGAAHBE()
		{
			return PHDOCKCBJOF;
		}

		public void MIPBONGPIJE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void OPMABIIDKCN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MOOGINPIELE()
		{
			return PHDOCKCBJOF;
		}

		public void GBABLFGEIMF()
		{
			throw new NotSupportedException();
		}

		public void ENFGGBNAPGG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void GGMKKIDFJOH()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object EKJDPPIGKCF()
		{
			return PHDOCKCBJOF;
		}

		public void EPIKLCFKOBJ()
		{
			throw new NotSupportedException();
		}

		public void CKEOKOKAAPB()
		{
			throw new NotSupportedException();
		}

		public void NBMNDHCIBME()
		{
			throw new NotSupportedException();
		}

		public bool NOHPKMDNEAO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				if (GuiElementSingle<PauseScreen>.instance.isShowed)
				{
					GuiElementSingle<PauseScreen>.instance.HideDialog();
				}
				goto case 0u;
			case 0u:
				if (!GuiScreenSingle<GameOverScreen>.instance.BFNOINNNHGP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				TimeManager.instance.SetupPhysicsTiming(true);
				Singleton<PerformanceManager>.instance.AGMMGEJNAMD(false);
				Singleton<GameCamera>.instance.AIDAFGCCCDO(GameControllerOnline.HMAIEJHCHDE);
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SpectateScreen>.instance);
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(false);
				if (TimeManager.instance.CCAFFILOOIA() && BJGCPDNMHDH.gameIsRunning)
				{
					TimeManager.FODFANEEDFF();
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<PauseScreen>.instance, 848f);
				}
				else
				{
					TimeManager.UnFreezeGame(739f);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object JEKHOAFAIBP()
		{
			return PHDOCKCBJOF;
		}

		public bool LAICPPPPIKL()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				if (GuiElementSingle<PauseScreen>.instance.isShowed)
				{
					GuiElementSingle<PauseScreen>.instance.HideDialog();
				}
				goto case 0u;
			case 0u:
				if (!GuiScreenSingle<GameOverScreen>.instance.isAnimationFinished)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				TimeManager.instance.SetupPhysicsTiming(false);
				Singleton<PerformanceManager>.instance.CLABLOFKMGA(true);
				Singleton<GameCamera>.instance.AIDAFGCCCDO(GameControllerOnline.HMAIEJHCHDE);
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SpectateScreen>.instance);
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(false);
				if (TimeManager.instance.GDJLMGAHHOH() && BJGCPDNMHDH.gameIsRunning)
				{
					TimeManager.DCODDANOPCP();
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<PauseScreen>.instance, 69f);
				}
				else
				{
					TimeManager.UnFreezeGame(845f);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public bool NAOFKEEIFCG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				if (GuiElementSingle<PauseScreen>.instance.isShowed)
				{
					GuiElementSingle<PauseScreen>.instance.HideDialog();
				}
				goto case 0u;
			case 0u:
				if (!GuiScreenSingle<GameOverScreen>.instance.isAnimationFinished)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				TimeManager.instance.SetupPhysicsTiming(false);
				Singleton<PerformanceManager>.instance.CAPGAAJFBDB(true);
				Singleton<GameCamera>.instance.SetTarget(GameControllerOnline.HMAIEJHCHDE);
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<SpectateScreen>.instance);
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(false);
				if (TimeManager.instance.isPaused && BJGCPDNMHDH.gameIsRunning)
				{
					TimeManager.FODFANEEDFF();
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<PauseScreen>.instance, 547f);
				}
				else
				{
					TimeManager.UnFreezeGame(1182f);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object AFAOHBIDOJD()
		{
			return PHDOCKCBJOF;
		}

		public void HDDLDAHLPCO()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void LFOLGBNBBAG()
		{
			throw new NotSupportedException();
		}

		public bool JIIOHNFHPOI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				if (GuiElementSingle<PauseScreen>.instance.NPFFMLLLDAF())
				{
					GuiElementSingle<PauseScreen>.instance.HideDialog();
				}
				goto case 0u;
			case 0u:
				if (!GuiScreenSingle<GameOverScreen>.instance.isAnimationFinished)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				TimeManager.instance.SetupPhysicsTiming(true);
				Singleton<PerformanceManager>.instance.FDFJMPCABLN(false);
				Singleton<GameCamera>.instance.SetTarget(GameControllerOnline.HMAIEJHCHDE);
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SpectateScreen>.instance);
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(true);
				if (TimeManager.instance.isPaused && BJGCPDNMHDH.gameIsRunning)
				{
					TimeManager.FODFANEEDFF();
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<PauseScreen>.instance, 688f);
				}
				else
				{
					TimeManager.UnFreezeGame(76f);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object FCBCEDKNBKC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FKPDNNMENFD()
		{
			return PHDOCKCBJOF;
		}

		public void HCHFFFPDMDA()
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
			case 1u:
				if (GuiElementSingle<PauseScreen>.instance.isShowed)
				{
					GuiElementSingle<PauseScreen>.instance.HideDialog();
				}
				goto case 0u;
			case 0u:
				if (!GuiScreenSingle<GameOverScreen>.instance.isAnimationFinished)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				TimeManager.instance.SetupPhysicsTiming(true);
				Singleton<PerformanceManager>.instance.FDFJMPCABLN(true);
				Singleton<GameCamera>.instance.AIDAFGCCCDO(GameControllerOnline.HMAIEJHCHDE);
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<SpectateScreen>.instance);
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(false);
				if (TimeManager.instance.CCAFFILOOIA() && BJGCPDNMHDH.gameIsRunning)
				{
					TimeManager.DCODDANOPCP();
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<PauseScreen>.instance, 1544f);
				}
				else
				{
					TimeManager.UnFreezeGame(1958f);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object CFBNPKIMOJC()
		{
			return PHDOCKCBJOF;
		}

		public void LFIGPJBHPBH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BNFADGLHBAH()
		{
			return PHDOCKCBJOF;
		}

		public void GEAHPAFNAPJ()
		{
			throw new NotSupportedException();
		}

		public bool BGOEENAEBNO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				if (GuiElementSingle<PauseScreen>.instance.NPFFMLLLDAF())
				{
					GuiElementSingle<PauseScreen>.instance.HideDialog();
				}
				goto case 0u;
			case 0u:
				if (!GuiScreenSingle<GameOverScreen>.instance.isAnimationFinished)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				TimeManager.instance.SetupPhysicsTiming(true);
				Singleton<PerformanceManager>.instance.AOBNCIOGFKA(false);
				Singleton<GameCamera>.instance.SetTarget(GameControllerOnline.HMAIEJHCHDE);
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SpectateScreen>.instance);
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(true);
				if (TimeManager.instance.GDJLMGAHHOH() && BJGCPDNMHDH.gameIsRunning)
				{
					TimeManager.DCODDANOPCP();
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<PauseScreen>.instance, 979f);
				}
				else
				{
					TimeManager.UnFreezeGame(1062f);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public bool HOOHJGPHHGN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				if (GuiElementSingle<PauseScreen>.instance.NPFFMLLLDAF())
				{
					GuiElementSingle<PauseScreen>.instance.HideDialog();
				}
				goto case 0u;
			case 0u:
				if (!GuiScreenSingle<GameOverScreen>.instance.BFNOINNNHGP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				TimeManager.instance.SetupPhysicsTiming(false);
				Singleton<PerformanceManager>.instance.CAPGAAJFBDB(false);
				Singleton<GameCamera>.instance.SetTarget(GameControllerOnline.HMAIEJHCHDE);
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SpectateScreen>.instance);
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(true);
				if (TimeManager.instance.CCAFFILOOIA() && BJGCPDNMHDH.gameIsRunning)
				{
					TimeManager.FODFANEEDFF();
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<PauseScreen>.instance, 351f);
				}
				else
				{
					TimeManager.UnFreezeGame(1703f);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object MJKLPCMKADD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HCPKEMLPEDI()
		{
			return PHDOCKCBJOF;
		}

		public void HEOPOOMLPJF()
		{
			throw new NotSupportedException();
		}

		public bool PMBOHHPPJAC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				if (GuiElementSingle<PauseScreen>.instance.isShowed)
				{
					GuiElementSingle<PauseScreen>.instance.HideDialog();
				}
				goto case 0u;
			case 0u:
				if (!GuiScreenSingle<GameOverScreen>.instance.BFNOINNNHGP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				TimeManager.instance.SetupPhysicsTiming(true);
				Singleton<PerformanceManager>.instance.KHEDGHEHPLK(true);
				Singleton<GameCamera>.instance.SetTarget(GameControllerOnline.HMAIEJHCHDE);
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SpectateScreen>.instance);
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(false);
				if (TimeManager.instance.isPaused && BJGCPDNMHDH.gameIsRunning)
				{
					TimeManager.FreezeGame();
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<PauseScreen>.instance, 1431f);
				}
				else
				{
					TimeManager.UnFreezeGame(733f);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public bool KHNDCDGBFJH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				if (GuiElementSingle<PauseScreen>.instance.NPFFMLLLDAF())
				{
					GuiElementSingle<PauseScreen>.instance.HideDialog();
				}
				goto case 0u;
			case 0u:
				if (!GuiScreenSingle<GameOverScreen>.instance.BFNOINNNHGP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				TimeManager.instance.SetupPhysicsTiming(false);
				Singleton<PerformanceManager>.instance.AKNADEPIPNP(true);
				Singleton<GameCamera>.instance.AIDAFGCCCDO(GameControllerOnline.HMAIEJHCHDE);
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<SpectateScreen>.instance);
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(true);
				if (TimeManager.instance.isPaused && BJGCPDNMHDH.gameIsRunning)
				{
					TimeManager.FreezeGame();
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<PauseScreen>.instance, 1987f);
				}
				else
				{
					TimeManager.UnFreezeGame(1152f);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object CGNOIKAGEMC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HADIFBCDICK()
		{
			return PHDOCKCBJOF;
		}

		public void MIFJOIIKFEB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BGMNDLEJNHH()
		{
			return PHDOCKCBJOF;
		}

		public bool GAPIFMKNJBN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				if (GuiElementSingle<PauseScreen>.instance.isShowed)
				{
					GuiElementSingle<PauseScreen>.instance.HideDialog();
				}
				goto case 0u;
			case 0u:
				if (!GuiScreenSingle<GameOverScreen>.instance.isAnimationFinished)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				TimeManager.instance.SetupPhysicsTiming(false);
				Singleton<PerformanceManager>.instance.AOBNCIOGFKA(false);
				Singleton<GameCamera>.instance.SetTarget(GameControllerOnline.HMAIEJHCHDE);
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<SpectateScreen>.instance);
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(false);
				if (TimeManager.instance.GDJLMGAHHOH() && BJGCPDNMHDH.gameIsRunning)
				{
					TimeManager.FODFANEEDFF();
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<PauseScreen>.instance, 1776f);
				}
				else
				{
					TimeManager.UnFreezeGame(1875f);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object EAGBDDECKHF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JDECDOJJAAH()
		{
			return PHDOCKCBJOF;
		}

		public void EFDJMHAPDLB()
		{
			throw new NotSupportedException();
		}

		public void EFKBIIPFDOM()
		{
			throw new NotSupportedException();
		}

		public void IDCJDJMGKFG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object FGFLGJECNLH()
		{
			return PHDOCKCBJOF;
		}

		public void HMBLLDJFIJG()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object AAAOCACGKIP()
		{
			return PHDOCKCBJOF;
		}

		public void FLOBHENENIC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IHDBAJNCNGN()
		{
			return PHDOCKCBJOF;
		}

		public void PPHBGPPJBNK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object DEOOBMKFKDE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MHKODCGLJFD()
		{
			return PHDOCKCBJOF;
		}

		public bool BEIABOJAIFM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				if (GuiElementSingle<PauseScreen>.instance.isShowed)
				{
					GuiElementSingle<PauseScreen>.instance.HideDialog();
				}
				goto case 0u;
			case 0u:
				if (!GuiScreenSingle<GameOverScreen>.instance.isAnimationFinished)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				TimeManager.instance.SetupPhysicsTiming(true);
				Singleton<PerformanceManager>.instance.CAPGAAJFBDB(false);
				Singleton<GameCamera>.instance.SetTarget(GameControllerOnline.HMAIEJHCHDE);
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SpectateScreen>.instance);
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(false);
				if (TimeManager.instance.isPaused && BJGCPDNMHDH.gameIsRunning)
				{
					TimeManager.FODFANEEDFF();
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<PauseScreen>.instance, 810f);
				}
				else
				{
					TimeManager.UnFreezeGame(652f);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void GOGEDHILBIA()
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
			case 1u:
				if (GuiElementSingle<PauseScreen>.instance.isShowed)
				{
					GuiElementSingle<PauseScreen>.instance.HideDialog();
				}
				goto case 0u;
			case 0u:
				if (!GuiScreenSingle<GameOverScreen>.instance.isAnimationFinished)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				TimeManager.instance.SetupPhysicsTiming(false);
				Singleton<PerformanceManager>.instance.FDFJMPCABLN(true);
				Singleton<GameCamera>.instance.AIDAFGCCCDO(GameControllerOnline.HMAIEJHCHDE);
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SpectateScreen>.instance);
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(true);
				if (TimeManager.instance.GDJLMGAHHOH() && BJGCPDNMHDH.gameIsRunning)
				{
					TimeManager.FreezeGame();
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<PauseScreen>.instance, 31f);
				}
				else
				{
					TimeManager.UnFreezeGame(1128f);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				if (GuiElementSingle<PauseScreen>.instance.isShowed)
				{
					GuiElementSingle<PauseScreen>.instance.HideDialog();
				}
				goto case 0u;
			case 0u:
				if (!GuiScreenSingle<GameOverScreen>.instance.isAnimationFinished)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				TimeManager.instance.SetupPhysicsTiming(false);
				Singleton<PerformanceManager>.instance.SetShadowsDistance(false);
				Singleton<GameCamera>.instance.SetTarget(GameControllerOnline.HMAIEJHCHDE);
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SpectateScreen>.instance);
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(false);
				if (TimeManager.instance.isPaused && BJGCPDNMHDH.gameIsRunning)
				{
					TimeManager.FreezeGame();
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<PauseScreen>.instance);
				}
				else
				{
					TimeManager.UnFreezeGame();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void FLGABFOKLNM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void LEAAOAKKLAJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MHFEOEIHFDC()
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
		private object EOPJNKFKMNB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GLIHEBDJCGM()
		{
			return PHDOCKCBJOF;
		}

		public bool LGNMOMFLLPP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				if (GuiElementSingle<PauseScreen>.instance.NPFFMLLLDAF())
				{
					GuiElementSingle<PauseScreen>.instance.HideDialog();
				}
				goto case 0u;
			case 0u:
				if (!GuiScreenSingle<GameOverScreen>.instance.BFNOINNNHGP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				TimeManager.instance.SetupPhysicsTiming(false);
				Singleton<PerformanceManager>.instance.MBIALLFNEFO(true);
				Singleton<GameCamera>.instance.AIDAFGCCCDO(GameControllerOnline.HMAIEJHCHDE);
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SpectateScreen>.instance);
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(true);
				if (TimeManager.instance.CCAFFILOOIA() && BJGCPDNMHDH.gameIsRunning)
				{
					TimeManager.FreezeGame();
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<PauseScreen>.instance, 1398f);
				}
				else
				{
					TimeManager.UnFreezeGame(330f);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object DAAINALAFOJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HIFNMHAGHLI()
		{
			return PHDOCKCBJOF;
		}

		public void HCJOIAHBFGB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void OGDMPCFMMML()
		{
			throw new NotSupportedException();
		}

		public void EGAONBPLDAG()
		{
			throw new NotSupportedException();
		}

		public void KHMNEOBMJLN()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object DOOAHBLHGFO()
		{
			return PHDOCKCBJOF;
		}

		public void OKIANDBCDIB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool HOJKAHEGFEB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				if (GuiElementSingle<PauseScreen>.instance.NPFFMLLLDAF())
				{
					GuiElementSingle<PauseScreen>.instance.HideDialog();
				}
				goto case 0u;
			case 0u:
				if (!GuiScreenSingle<GameOverScreen>.instance.BFNOINNNHGP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				TimeManager.instance.SetupPhysicsTiming(false);
				Singleton<PerformanceManager>.instance.LCOIHOCJGLF(true);
				Singleton<GameCamera>.instance.AIDAFGCCCDO(GameControllerOnline.HMAIEJHCHDE);
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<SpectateScreen>.instance);
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(true);
				if (TimeManager.instance.GDJLMGAHHOH() && BJGCPDNMHDH.gameIsRunning)
				{
					TimeManager.FODFANEEDFF();
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<PauseScreen>.instance, 807f);
				}
				else
				{
					TimeManager.UnFreezeGame(1353f);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void POJKIIMAFDO()
		{
			throw new NotSupportedException();
		}

		public void BOFEBMENOFC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MJPEJLKAOEH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BOOBHEKPLLD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BIMFPFEHMAP()
		{
			return PHDOCKCBJOF;
		}

		public bool HEHJAEIGHDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				if (GuiElementSingle<PauseScreen>.instance.isShowed)
				{
					GuiElementSingle<PauseScreen>.instance.HideDialog();
				}
				goto case 0u;
			case 0u:
				if (!GuiScreenSingle<GameOverScreen>.instance.isAnimationFinished)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				TimeManager.instance.SetupPhysicsTiming(true);
				Singleton<PerformanceManager>.instance.MBIALLFNEFO(true);
				Singleton<GameCamera>.instance.SetTarget(GameControllerOnline.HMAIEJHCHDE);
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SpectateScreen>.instance);
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(true);
				if (TimeManager.instance.CCAFFILOOIA() && BJGCPDNMHDH.gameIsRunning)
				{
					TimeManager.DCODDANOPCP();
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<PauseScreen>.instance, 1231f);
				}
				else
				{
					TimeManager.UnFreezeGame(676f);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object GOAJCEAOPLA()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public OILCCDFMJEJ()
		{
		}

		public void EBCEAGIOPJD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object KKKMCHGLHLL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IDLFKAKINAP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AHFIDCCJHKE()
		{
			return PHDOCKCBJOF;
		}

		public bool MKCOLOBIAAP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				if (GuiElementSingle<PauseScreen>.instance.NPFFMLLLDAF())
				{
					GuiElementSingle<PauseScreen>.instance.HideDialog();
				}
				goto case 0u;
			case 0u:
				if (!GuiScreenSingle<GameOverScreen>.instance.BFNOINNNHGP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				TimeManager.instance.SetupPhysicsTiming(true);
				Singleton<PerformanceManager>.instance.AKNADEPIPNP(false);
				Singleton<GameCamera>.instance.AIDAFGCCCDO(GameControllerOnline.HMAIEJHCHDE);
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<SpectateScreen>.instance);
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(false);
				if (TimeManager.instance.CCAFFILOOIA() && BJGCPDNMHDH.gameIsRunning)
				{
					TimeManager.DCODDANOPCP();
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<PauseScreen>.instance, 1993f);
				}
				else
				{
					TimeManager.UnFreezeGame(943f);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public bool DDLMLOJGJMA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				if (GuiElementSingle<PauseScreen>.instance.isShowed)
				{
					GuiElementSingle<PauseScreen>.instance.HideDialog();
				}
				goto case 0u;
			case 0u:
				if (!GuiScreenSingle<GameOverScreen>.instance.isAnimationFinished)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				TimeManager.instance.SetupPhysicsTiming(true);
				Singleton<PerformanceManager>.instance.MBIALLFNEFO(false);
				Singleton<GameCamera>.instance.AIDAFGCCCDO(GameControllerOnline.HMAIEJHCHDE);
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SpectateScreen>.instance);
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(false);
				if (TimeManager.instance.GDJLMGAHHOH() && BJGCPDNMHDH.gameIsRunning)
				{
					TimeManager.FreezeGame();
					Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<PauseScreen>.instance, 91f);
				}
				else
				{
					TimeManager.UnFreezeGame(912f);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void BBBLJNFEACC()
		{
			throw new NotSupportedException();
		}

		public void ABOOMAKBEDI()
		{
			throw new NotSupportedException();
		}

		public void EJADBNAIHEF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void JOEOMEJLEID()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void KNFDMCEJHLB()
		{
			throw new NotSupportedException();
		}

		public void PDNKLJFHBGO()
		{
			throw new NotSupportedException();
		}

		public void ELAJECMEMNC()
		{
			throw new NotSupportedException();
		}
	}

	private sealed class MGAAEFEKILD
	{
		internal PlayerController KHLGDCHJJPB;

		internal void MCFGAFBEJDK()
		{
			KHLGDCHJJPB.gameObject.SetActive(true);
			TimeManager.instance.SetupPhysicsTiming(false);
		}

		internal void MPHECHCFCAN()
		{
			KHLGDCHJJPB.gameObject.SetActive(true);
			TimeManager.instance.SetupPhysicsTiming(true);
		}

		internal void MMEEJDGGAID()
		{
			KHLGDCHJJPB.gameObject.SetActive(false);
			TimeManager.instance.SetupPhysicsTiming(false);
		}

		internal void FHDOHCJJEMM()
		{
			KHLGDCHJJPB.gameObject.SetActive(false);
			TimeManager.instance.SetupPhysicsTiming(true);
		}

		internal void LJCDGJKCNEC()
		{
			KHLGDCHJJPB.gameObject.SetActive(false);
			TimeManager.instance.SetupPhysicsTiming(false);
		}

		internal void LGJCNCHBFDA()
		{
			KHLGDCHJJPB.gameObject.SetActive(true);
			TimeManager.instance.SetupPhysicsTiming(false);
		}

		internal void NNIJEDKBPGJ()
		{
			KHLGDCHJJPB.gameObject.SetActive(true);
			TimeManager.instance.SetupPhysicsTiming(false);
		}

		internal void KNJBDOADLDO()
		{
			KHLGDCHJJPB.gameObject.SetActive(false);
			TimeManager.instance.SetupPhysicsTiming(false);
		}

		internal void EMKPBGFBPFI()
		{
			KHLGDCHJJPB.gameObject.SetActive(true);
			TimeManager.instance.SetupPhysicsTiming(false);
		}

		internal void OABFAOLFMMJ()
		{
			KHLGDCHJJPB.gameObject.SetActive(false);
			TimeManager.instance.SetupPhysicsTiming(true);
		}

		internal void AMIJFGBOCLC()
		{
			KHLGDCHJJPB.gameObject.SetActive(true);
			TimeManager.instance.SetupPhysicsTiming(true);
		}

		internal void OKNCFDMEFGJ()
		{
			KHLGDCHJJPB.gameObject.SetActive(true);
			TimeManager.instance.SetupPhysicsTiming(true);
		}

		internal void HHLMDAKDHFK()
		{
			KHLGDCHJJPB.gameObject.SetActive(false);
			TimeManager.instance.SetupPhysicsTiming(false);
		}

		internal void NDJOJHNIBFC()
		{
			KHLGDCHJJPB.gameObject.SetActive(false);
			TimeManager.instance.SetupPhysicsTiming(true);
		}

		internal void BMCMDMKGHHO()
		{
			KHLGDCHJJPB.gameObject.SetActive(true);
			TimeManager.instance.SetupPhysicsTiming(false);
		}

		internal void LHPPLGOOLEC()
		{
			KHLGDCHJJPB.gameObject.SetActive(true);
			TimeManager.instance.SetupPhysicsTiming(true);
		}

		internal void NNFHNIMCBLH()
		{
			KHLGDCHJJPB.gameObject.SetActive(false);
			TimeManager.instance.SetupPhysicsTiming(true);
		}

		internal void FIBGJHCGHJH()
		{
			KHLGDCHJJPB.gameObject.SetActive(false);
			TimeManager.instance.SetupPhysicsTiming(false);
		}

		internal void NAJNECOMDDN()
		{
			KHLGDCHJJPB.gameObject.SetActive(true);
			TimeManager.instance.SetupPhysicsTiming(false);
		}
	}

	private sealed class NHLGPCGCNKF : IEnumerator, IDisposable, IEnumerator<object>
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

		public bool KDFAHLNCNMN()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return true;
		}

		[SpecialName]
		private object IGMIIAODMNF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FPFOODLPEBK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JALKNCBEINE()
		{
			return PHDOCKCBJOF;
		}

		public bool FJKEEKBNKPN()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return false;
		}

		public void NDPOBCODJAI()
		{
			throw new NotSupportedException();
		}

		public bool DKIKFMODFJF()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return true;
		}

		public bool MHNPBDBGBLK()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return true;
		}

		public void GFPDOCDEGPA()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CIGHIOCACPH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BOOBHEKPLLD()
		{
			return PHDOCKCBJOF;
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

		public void HONCAABOMOC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GAPDDGJNMPK()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Dispose()
		{
		}

		public void ELMJLOBAMKH()
		{
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public bool DFMKKFMEBON()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return true;
		}

		public bool JPBGJLDMOPO()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return true;
		}

		public void ENFGGBNAPGG()
		{
		}

		public void HNBFJFDLABI()
		{
		}

		[SpecialName]
		private object BJJNGPKNCKJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PFIIINLHGMH()
		{
			return PHDOCKCBJOF;
		}

		public void GFJIKANGNMC()
		{
		}

		[SpecialName]
		private object FCFHLDPLIDC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NCKCKPNAHAD()
		{
			return PHDOCKCBJOF;
		}

		public void IPKNPABKAJD()
		{
			throw new NotSupportedException();
		}

		public void HKFEFDNFKKK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IHAOBCEALPD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ONADHLDNKKB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EPGLILIJMEM()
		{
			return PHDOCKCBJOF;
		}

		public void JBHOCIFIMBH()
		{
		}

		[SpecialName]
		private object BMAMEPNHHFI()
		{
			return PHDOCKCBJOF;
		}

		public void JJOAHIOBOPO()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KKCOHEHPJPF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EDBIJNJGFLE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AFDKAGLDADB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IDLFKAKINAP()
		{
			return PHDOCKCBJOF;
		}

		public bool CBGPIONEKLM()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return false;
		}

		public void LFIGPJBHPBH()
		{
		}

		[SpecialName]
		private object DHFBIMOBODM()
		{
			return PHDOCKCBJOF;
		}

		public void CFHJPHLFONO()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HIFNMHAGHLI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ECJHOPIBAMO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HBKJOBOMGKB()
		{
			return PHDOCKCBJOF;
		}

		public void BCOIPCDCKEJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GDCFFBBNGHH()
		{
			return PHDOCKCBJOF;
		}

		public bool CIIHKFDLDKN()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return false;
		}

		public bool IBEPOFJDKLG()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return true;
		}

		public void EJADBNAIHEF()
		{
		}

		public void ODFCBNONFPL()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IPCODJDAOBE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CJCHFDFCPPL()
		{
			return PHDOCKCBJOF;
		}

		public void BLOCBAKBHBF()
		{
		}

		[SpecialName]
		private object ADNCCLOOEAD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BPKCMCDJOBF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FMCLBOCENPE()
		{
			return PHDOCKCBJOF;
		}

		public void LFOLGBNBBAG()
		{
			throw new NotSupportedException();
		}

		public void DBJCDLFKDDI()
		{
			throw new NotSupportedException();
		}

		public void CPEDOIELFMP()
		{
		}

		public void DLIBOPAMHAN()
		{
		}

		[SpecialName]
		private object CLFFFNGBPGJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CDFEOBMLNCG()
		{
			return PHDOCKCBJOF;
		}

		public void ODPKEEIHOPK()
		{
		}

		public void NBMNDHCIBME()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HBGFABNDPAD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GCJFGIKENJA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IHDBAJNCNGN()
		{
			return PHDOCKCBJOF;
		}

		public bool FADACBKMFGG()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return true;
		}

		[SpecialName]
		private object HADIFBCDICK()
		{
			return PHDOCKCBJOF;
		}

		public void PDKPELBIAON()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object AGANCOFPDCK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BMGHJKFMKJE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BNFADGLHBAH()
		{
			return PHDOCKCBJOF;
		}

		public void IOBGNBBJOLM()
		{
		}

		public bool FBMLBIOKKBE()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return false;
		}

		public void IGBHHLFACKO()
		{
		}

		[SpecialName]
		private object EFIEEKFCBJH()
		{
			return PHDOCKCBJOF;
		}

		public void HHMPMPLLJCC()
		{
			throw new NotSupportedException();
		}

		public void JDFJKNFDDGN()
		{
		}

		[DebuggerHidden]
		public NHLGPCGCNKF()
		{
		}

		public bool LDINGGNOLKA()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return false;
		}

		public void KHMNEOBMJLN()
		{
			throw new NotSupportedException();
		}

		public bool BCFKDABEHHO()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return false;
		}

		public bool BEIABOJAIFM()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return true;
		}

		public bool CGOKGPGALLH()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return false;
		}

		public void CDIJEGGMMAK()
		{
		}

		public void BCKMHLBBBCK()
		{
			throw new NotSupportedException();
		}
	}

	public override string loadingWaitingCards
	{
		get
		{
			return Localization.Localize("ID_WAITINGFORFRIENDCARDS");
		}
	}

	public override string loadingWaiting
	{
		get
		{
			return Localization.Localize("ID_WAITINGFORFRIEND");
		}
	}

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

	public override bool canDeployUnits
	{
		get
		{
			return false;
		}
	}

	protected override bool JPADCGODJBO
	{
		get
		{
			return DEGCDEAANEL;
		}
	}

	public override string quitText
	{
		get
		{
			return Localization.Localize((!JPADCGODJBO) ? "ID_CONFIRM_EXITINGCOOPNODOGTAG_TEXT" : "ID_CONFIRM_EXITINGCOOP_TEXT");
		}
	}

	private Dictionary<string, UnitUpgradeDefinition> JLOJANIPMPE { get; set; }

	public override List<UnitUpgradeDefinition> opponentUpgrades
	{
		get
		{
			List<UnitUpgradeDefinition> upgrades = DailyMissionsManager.instance.currentMission.GetUpgrades();
			JLOJANIPMPE = new Dictionary<string, UnitUpgradeDefinition>();
			for (int i = 0; i < LevelManager.instance.behaviours.Count; i++)
			{
				LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[i];
				JLOJANIPMPE[levelBehaviour.GetType().ToString()] = upgrades[i];
			}
			return upgrades;
		}
	}

	public override List<UnitUpgradeDefinition> myUpgrades
	{
		get
		{
			if (Singleton<PhotonConnectionManager>.instance.isClient)
			{
				return Singleton<GameController>.instance.KKHKAJPNDEC.EHHHBEMKGOE.KBBDGCLPOCJ;
			}
			return base.myUpgrades;
		}
	}

	protected virtual void LPKIOODGJIO()
	{
		base.HKGOKPMIEEI();
		BEGOFBBPOLA();
	}

	[SpecialName]
	protected virtual bool LOAFGHDIMFB()
	{
		return DEGCDEAANEL;
	}

	protected virtual void LEAJGMJPMEH()
	{
		FOMELELMFPM();
		if (gameIsRunning && (MatchManager.HHEAOEEBICE() || !MatchManager.allPlayersFinishetStartAnimation))
		{
			if (MatchManager.isReconnect)
			{
				float value = MatchManager.reconnectLength - (Time.realtimeSinceStartup - MatchManager.KKAGFMGEOBC);
				value = Mathf.Clamp(value, 1425f, 625f);
				GuiElementSingle<ReconnectDialog>.instance.DHELCKICBCI(value);
				if (value <= 1993f && (PhotonNetwork.room == null || PhotonNetwork.room.playerCount != 8))
				{
					if (MatchManager.reconnectState == KAKELCLPDDK.Me)
					{
						Forfeit();
					}
					else if (Singleton<PhotonConnectionManager>.instance.isMasterClient)
					{
						if (PhotonNetwork.room != null)
						{
							PhotonNetwork.room.open = false;
						}
						GuiElementSingle<ReconnectDialog>.instance.HideDialog();
						TimeManager.Resume(814f);
						GAEAGAPHLAM(Singleton<GameController>.instance.KKHKAJPNDEC.NAGAHNHAKBJ, 1699f, (GameController.HKGHCIEPGEL)4);
					}
					else
					{
						Forfeit();
					}
					GuiElementSingle<ReconnectDialog>.instance.HideDialog();
				}
			}
			else
			{
				GuiElementSingle<ReconnectDialog>.instance.OINBLJODNCF(209f);
			}
		}
		KCFDDKOIAOK();
	}

	[SpecialName]
	public virtual void BNOMKILIAIB(List<Card> IDEBKDPMPGM)
	{
		Singleton<GameController>.instance.GMNKFFNFEHG.cardsForGame = IDEBKDPMPGM;
	}

	public virtual IEnumerator PGKGDLJCBOD()
	{
		return new NHLGPCGCNKF();
	}

	[SpecialName]
	public virtual string LBJHFLBAPAK()
	{
		return Localization.Localize((!JPADCGODJBO) ? "gold" : "Dirt");
	}

	public override void StartMultiplayerGame(string JLBLNDGIINB, CloudRegionCode GJBFKKOAMPA)
	{
		LoadingDialog.SetLook(false);
		base.StartMultiplayerGame(JLBLNDGIINB, GJBFKKOAMPA);
		if (Singleton<GameController>.instance.isCoop)
		{
			LoadingDialog.ShowLoading(Localization.Localize("ID_WAITINGFORFRIEND"), false, true).DGPEHPHGDEF = NMCJNOFAJLL;
		}
	}

	public virtual void EODGMDGOEDJ()
	{
		base.Quit();
		DailyMissionsManager.instance.JLPBMNHBNNP();
	}

	private void NFBJOLBAEEC(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if (Singleton<GameController>.instance.mainController == this && !Singleton<PhotonConnectionManager>.instance.isMasterClient)
		{
			PlayerController kHLGDCHJJPB = (PlayerController)MAIPDGCABNL;
			Singleton<GameCamera>.instance.LODMODJFFBE(kHLGDCHJJPB, OHJPPHFEAFI.HNFNINFCBEJ is PlayerController);
		}
	}

	[SpecialName]
	public virtual List<Card> LCHAHGKMCPJ()
	{
		return Singleton<GameController>.instance.GMNKFFNFEHG.cardsForGame;
	}

	protected virtual void AEIILHDCPCF(byte MNMLNIMFMJP)
	{
		StopAllCoroutines();
		TimeManager.instance.EndMission();
		base.FinishGameMultiplayerRPC(MNMLNIMFMJP);
	}

	[PunRPC]
	private void FinishGameCoopClient(byte MNMLNIMFMJP, int EJBEDLHIKDG)
	{
		CCINFCHDGCH(EJBEDLHIKDG, 3f, (GameController.HKGHCIEPGEL)MNMLNIMFMJP);
	}

	protected virtual void NGMOODLGOFC()
	{
		FOMELELMFPM();
		if (gameIsRunning && (MatchManager.HHEAOEEBICE() || !MatchManager.FLMLENJOPNK()))
		{
			if (MatchManager.isReconnect)
			{
				float value = MatchManager.GAEHMADFCPA() - (Time.realtimeSinceStartup - MatchManager.KKAGFMGEOBC);
				value = Mathf.Clamp(value, 36f, 1022f);
				GuiElementSingle<ReconnectDialog>.instance.IOFMNOGNONI(value);
				if (value <= 155f && (PhotonNetwork.room == null || PhotonNetwork.room.playerCount != 0))
				{
					if (MatchManager.ACJJGBBBPFP() == KAKELCLPDDK.None)
					{
						Forfeit();
					}
					else if (Singleton<PhotonConnectionManager>.instance.isMasterClient)
					{
						if (PhotonNetwork.room != null)
						{
							PhotonNetwork.room.open = false;
						}
						GuiElementSingle<ReconnectDialog>.instance.HideDialog();
						TimeManager.Resume(1932f);
						CCINFCHDGCH(Singleton<GameController>.instance.KKHKAJPNDEC.NAGAHNHAKBJ, 1991f, GameController.HKGHCIEPGEL.Forfeit);
					}
					else
					{
						Forfeit();
					}
					GuiElementSingle<ReconnectDialog>.instance.HideDialog();
				}
			}
			else
			{
				GuiElementSingle<ReconnectDialog>.instance.IOFMNOGNONI(1416f);
			}
		}
		KCFDDKOIAOK();
	}

	protected override void BEGOFBBPOLA()
	{
		if (Singleton<PhotonConnectionManager>.instance.isMasterClient)
		{
			Singleton<BeanstalkServerManager>.instance.EBPGOPEHDMP();
		}
		else
		{
			Singleton<BeanstalkServerManager>.instance.BIKCJBEEDMA();
		}
		base.BEGOFBBPOLA();
	}

	[SpecialName]
	private void KEOLPGLCKHI(Dictionary<string, UnitUpgradeDefinition> IDEBKDPMPGM)
	{
		_003CFIIDLHLCOAG_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void LLCPCOECHFD(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if (Singleton<GameController>.instance.mainController == this && !Singleton<PhotonConnectionManager>.instance.isMasterClient)
		{
			PlayerController kHLGDCHJJPB = (PlayerController)MAIPDGCABNL;
			Singleton<GameCamera>.instance.FocusPlayer(kHLGDCHJJPB, OHJPPHFEAFI.HNFNINFCBEJ is PlayerController);
		}
	}

	public override UpgradeSlots.UnitUpgrades PickUpgradesForUnit(bool KPIGIEPMLLC, AIObject ECHOPGPBLOK)
	{
		LevelBehaviour aCLDFHJKBLI = ECHOPGPBLOK.ACLDFHJKBLI;
		GHPGNELIDBM fraction = ECHOPGPBLOK.fraction;
		UpgradeSlots.UnitUpgrades pFGLIAHPMCK = base.PickUpgradesForUnit(KPIGIEPMLLC, ECHOPGPBLOK);
		pFGLIAHPMCK = DailyMissionsManager.ScaleUpgradesForMission(fraction, aCLDFHJKBLI, pFGLIAHPMCK);
		aCLDFHJKBLI.behaviourDefinition.MIKOLPDBCLK(pFGLIAHPMCK.scaleDamage, pFGLIAHPMCK.scaleHp);
		return pFGLIAHPMCK;
	}

	protected override void BLBNJHMPGNK()
	{
		base.BLBNJHMPGNK();
		Singleton<GameController>.instance.KKHKAJPNDEC = null;
	}

	public virtual IEnumerator FDDNGAEIAPM()
	{
		NCEKIFIDMCF nCEKIFIDMCF = new NCEKIFIDMCF();
		nCEKIFIDMCF.BJGCPDNMHDH = this;
		return nCEKIFIDMCF;
	}

	private void NMCJNOFAJLL()
	{
		UnityEngine.Debug.Log("Cancel clicked, will to try call disconnect ");
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<DailyMissionScreen>.instance);
		UnityEngine.Debug.Log("Disconnect, clicked on dialog !!!");
		PhotonConnectionManager.Disconnect();
		StopAllCoroutines();
		Quit();
	}

	[DebuggerHidden]
	private IEnumerator JGAOIECKFOK()
	{
		OILCCDFMJEJ oILCCDFMJEJ = new OILCCDFMJEJ();
		oILCCDFMJEJ.BJGCPDNMHDH = this;
		return oILCCDFMJEJ;
	}

	protected virtual void MHBINCAGJCA()
	{
		base.BLBNJHMPGNK();
		Singleton<GameController>.instance.KKHKAJPNDEC = null;
	}

	[DebuggerHidden]
	public override IEnumerator AquireLevelName()
	{
		return new NHLGPCGCNKF();
	}

	public virtual void KOEMECKGDGO()
	{
	}

	public override void Rematch()
	{
		LoadingDialog.SetLook(false);
		LoadingDialog.ShowLoading(Localization.Localize("ID_WAITINGFORFRIEND"), true, true).DGPEHPHGDEF = NMCJNOFAJLL;
		base.Rematch();
	}

	public virtual void DLNHOILIPFF()
	{
		base.Forfeit();
		DailyMissionsManager.instance.LFFBCGDBGHH().EndMission(false);
		if (Singleton<PhotonConnectionManager>.instance.isClient)
		{
			Disconnect();
		}
	}

	public new void StartMultiplayerGame(DatabasePlayer NCFFGKHPJLH, out string JLBLNDGIINB, out bool MKDDIBOHCIA)
	{
		LoadingDialog.SetLook(false);
		base.StartMultiplayerGame(NCFFGKHPJLH, out JLBLNDGIINB, out MKDDIBOHCIA);
		if (Singleton<GameController>.instance.isCoop && MKDDIBOHCIA)
		{
			LoadingDialog.ShowLoading(Localization.Localize("ID_WAITINGFORFRIEND"), true, true).DGPEHPHGDEF = NMCJNOFAJLL;
		}
	}

	public override void FinishGame()
	{
		StopAllCoroutines();
		TimeManager.instance.EndMission();
		if (gameIsRunning)
		{
			Singleton<MatchManager>.instance.matchTime = time;
			if (Singleton<PhotonConnectionManager>.instance.isMasterClient)
			{
				FEHCCGEGPLH.RPC("FinishGameMultiplayerRPC", PhotonTargets.Others, (byte)Singleton<GameController>.instance.MNMLNIMFMJP);
			}
			else
			{
				FEHCCGEGPLH.RPC("FinishGameCoopClient", PhotonTargets.Others, (byte)Singleton<GameController>.instance.MNMLNIMFMJP, PhotonNetwork.player.ID);
			}
			IDLPGDJILPI(CKDIHNEIHKL.GLFPILGCAPM.GameFinished);
			MatchManager.matchState = GLFPILGCAPM.GameFinished;
			gameIsRunning = false;
			Reset();
			base.mMainController.FinishGame();
		}
	}

	[SpecialName]
	public virtual List<Card> NLBAJAJHLJO()
	{
		return Singleton<GameController>.instance.GMNKFFNFEHG.cardsForGame;
	}

	protected virtual void EDMFALFNLFO()
	{
		base.BLBNJHMPGNK();
		Singleton<GameController>.instance.KKHKAJPNDEC = null;
	}

	private void GJFFOLADPLN(int EJBEDLHIKDG, float KBJEOEEOEFG, GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		MGAAEFEKILD mGAAEFEKILD = new MGAAEFEKILD();
		mGAAEFEKILD.KHLGDCHJJPB = PlayerController.FBIOLEEFJMA(EJBEDLHIKDG);
		if (mGAAEFEKILD.KHLGDCHJJPB != null)
		{
			if (MNMLNIMFMJP == GameController.HKGHCIEPGEL.WinByForfeit)
			{
				GuiElementSingle<CoopInfos>.instance.GADEJPAFCMD();
			}
			else
			{
				GuiElementSingle<CoopInfos>.instance.KOGGPCMGBLH();
				ResumeGame();
			}
			mGAAEFEKILD.KHLGDCHJJPB.currentPlayerPoint = null;
			mGAAEFEKILD.KHLGDCHJJPB.LMIHBNGHEHM.EIPHAAGCHCP = false;
			mGAAEFEKILD.KHLGDCHJJPB.LMIHBNGHEHM.AJADIICCLHO = true;
			InvokeAfterRealTime(mGAAEFEKILD.FHDOHCJJEMM, KBJEOEEOEFG);
		}
	}

	protected virtual void IEBDAIIMCNB()
	{
		FOMELELMFPM();
		if (gameIsRunning && (MatchManager.HHEAOEEBICE() || !MatchManager.FLMLENJOPNK()))
		{
			if (MatchManager.HHEAOEEBICE())
			{
				float value = MatchManager.reconnectLength - (Time.realtimeSinceStartup - MatchManager.KKAGFMGEOBC);
				value = Mathf.Clamp(value, 479f, 291f);
				GuiElementSingle<ReconnectDialog>.instance.FPOECIIIODH(value);
				if (value <= 1359f && (PhotonNetwork.room == null || PhotonNetwork.room.playerCount != 3))
				{
					if (MatchManager.ACJJGBBBPFP() == KAKELCLPDDK.None)
					{
						Forfeit();
					}
					else if (Singleton<PhotonConnectionManager>.instance.isMasterClient)
					{
						if (PhotonNetwork.room != null)
						{
							PhotonNetwork.room.open = true;
						}
						GuiElementSingle<ReconnectDialog>.instance.HideDialog();
						TimeManager.Resume(1444f);
						GAEAGAPHLAM(Singleton<GameController>.instance.KKHKAJPNDEC.NAGAHNHAKBJ, 344f, GameController.HKGHCIEPGEL.Kia);
					}
					else
					{
						Forfeit();
					}
					GuiElementSingle<ReconnectDialog>.instance.HideDialog();
				}
			}
			else
			{
				GuiElementSingle<ReconnectDialog>.instance.DHELCKICBCI(1887f);
			}
		}
		KCFDDKOIAOK();
	}

	public virtual void IGLNKHCHIEA()
	{
	}

	public virtual void OFJJIBIAJPM(string JLBLNDGIINB, CloudRegionCode GJBFKKOAMPA)
	{
		LoadingDialog.FEHDJPIKOJD(false);
		base.StartMultiplayerGame(JLBLNDGIINB, GJBFKKOAMPA);
		if (Singleton<GameController>.instance.MNPNHJKBNCJ())
		{
			LoadingDialog.PGFBMJFLHPC(Localization.Localize("gold3"), true, true).DGPEHPHGDEF = NMCJNOFAJLL;
		}
	}

	[DebuggerHidden]
	[CompilerGenerated]
	private IEnumerator IABAJLPCCEL()
	{
		return base.StartGame();
	}

	[SpecialName]
	public virtual void CIMFKHDPDLF(List<Card> IDEBKDPMPGM)
	{
		Singleton<GameController>.instance.GMNKFFNFEHG.cardsForGame = IDEBKDPMPGM;
	}

	protected override void Update()
	{
		base.Update();
		if (gameIsRunning && TimeManager.instance.pauseStatus == TimeManager.HICMJEBLEDA.PausedRemote && TimeManager.pauseTimeLeft <= 0f && Singleton<PhotonConnectionManager>.instance.isMasterClient)
		{
			FEHCCGEGPLH.RPC("FinishGameMultiplayerRPC", PhotonTargets.Others, (byte)5);
			TimeManager.Resume();
		}
		if (PlayerController.OGMBJPKOPCB.LMIHBNGHEHM.EHFIJJBPEEG == CKDIHNEIHKL.GLFPILGCAPM.Rematch && GuiElementSingle<LoadingDialog>.instance.isShowed)
		{
			LoadingDialog.SetHeader(MatchManager.matchStatusLoading);
			string matchTimeStatus = MatchManager.matchTimeStatus;
			string hOLNKOFHDNK = ((!string.IsNullOrEmpty(matchTimeStatus)) ? matchTimeStatus : MatchManager.matchStatusAfterMatch);
			LoadingDialog.SetText(hOLNKOFHDNK);
		}
		if (MatchManager.matchState == GLFPILGCAPM.WaitingForOpponent && GuiElementSingle<LoadingDialog>.instance.isShowed)
		{
			string matchTimeStatus2 = MatchManager.matchTimeStatus;
			LoadingDialog.SetText(matchTimeStatus2);
		}
	}

	public override void Forfeit()
	{
		base.Forfeit();
		DailyMissionsManager.instance.currentMission.EndMission(false);
		if (Singleton<PhotonConnectionManager>.instance.isClient)
		{
			Disconnect();
		}
	}

	private void GAEAGAPHLAM(int EJBEDLHIKDG, float KBJEOEEOEFG, GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		MGAAEFEKILD mGAAEFEKILD = new MGAAEFEKILD();
		mGAAEFEKILD.KHLGDCHJJPB = PlayerController.FBIOLEEFJMA(EJBEDLHIKDG);
		if (mGAAEFEKILD.KHLGDCHJJPB != null)
		{
			if (MNMLNIMFMJP == GameController.HKGHCIEPGEL.Forfeit)
			{
				GuiElementSingle<CoopInfos>.instance.EOKGGGCJFBN();
			}
			else
			{
				GuiElementSingle<CoopInfos>.instance.ShowCoopPartnerLeft();
				ResumeGame();
			}
			mGAAEFEKILD.KHLGDCHJJPB.CMKNJFHHOHA(null);
			mGAAEFEKILD.KHLGDCHJJPB.LMIHBNGHEHM.BJIAOHPEDAP(true);
			mGAAEFEKILD.KHLGDCHJJPB.LMIHBNGHEHM.LODPIIGCEKP(false);
			InvokeAfterRealTime(mGAAEFEKILD.LJCDGJKCNEC, KBJEOEEOEFG);
		}
	}

	public virtual UpgradeSlots.UnitUpgrades NPIDIPDIIGB(bool KPIGIEPMLLC, AIObject ECHOPGPBLOK)
	{
		LevelBehaviour aCLDFHJKBLI = ECHOPGPBLOK.ACLDFHJKBLI;
		GHPGNELIDBM fraction = ECHOPGPBLOK.fraction;
		UpgradeSlots.UnitUpgrades pFGLIAHPMCK = base.PickUpgradesForUnit(KPIGIEPMLLC, ECHOPGPBLOK);
		pFGLIAHPMCK = DailyMissionsManager.ScaleUpgradesForMission(fraction, aCLDFHJKBLI, pFGLIAHPMCK);
		aCLDFHJKBLI.behaviourDefinition.MBNKINKNPIG(pFGLIAHPMCK.scaleDamage, pFGLIAHPMCK.scaleHp);
		return pFGLIAHPMCK;
	}

	public override void Quit()
	{
		base.Quit();
		DailyMissionsManager.instance.Quit();
	}

	[PunRPC]
	protected override void FinishGameMultiplayerRPC(byte MNMLNIMFMJP)
	{
		StopAllCoroutines();
		TimeManager.instance.EndMission();
		base.FinishGameMultiplayerRPC(MNMLNIMFMJP);
	}

	protected override MapDefinition.DefendPosition PKMFODGDMON(GHPGNELIDBM CIOPAKLHFIL, int MADABBPIDCJ, PhotonPlayer KHLGDCHJJPB)
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
			if (KHLGDCHJJPB.isMasterClient)
			{
				return list[0];
			}
			return list[1];
		}
		UnityEngine.Debug.LogError("No main position was set in map definition");
		return null;
	}

	private void CHEDFKIPJFF(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		base.AAIEPHNDCJP.Killed -= CHEDFKIPJFF;
		if (gameIsRunning && Singleton<GameController>.instance.mainController == this && !Singleton<PhotonConnectionManager>.instance.isMasterClient)
		{
			Singleton<MatchManager>.instance.SetHitBy(LLAOOPMGBAG);
			base.mMainController.MNMLNIMFMJP = GameController.HKGHCIEPGEL.Kia;
			PlayerController.OGMBJPKOPCB.LMIHBNGHEHM.EHFIJJBPEEG = CKDIHNEIHKL.GLFPILGCAPM.GameFinished;
			FEHCCGEGPLH.RPC("FinishGameCoopClient", PhotonTargets.Others, (byte)Singleton<GameController>.instance.MNMLNIMFMJP, PhotonNetwork.player.ID);
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<GameOverScreen>.instance);
			StartCoroutine(JGAOIECKFOK());
		}
	}

	private void CCINFCHDGCH(int EJBEDLHIKDG, float KBJEOEEOEFG, GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		MGAAEFEKILD mGAAEFEKILD = new MGAAEFEKILD();
		mGAAEFEKILD.KHLGDCHJJPB = PlayerController.GetPlayer(EJBEDLHIKDG);
		if (mGAAEFEKILD.KHLGDCHJJPB != null)
		{
			if (MNMLNIMFMJP == GameController.HKGHCIEPGEL.Kia)
			{
				GuiElementSingle<CoopInfos>.instance.ShowCoopPartnerDied();
			}
			else
			{
				GuiElementSingle<CoopInfos>.instance.ShowCoopPartnerLeft();
				ResumeGame();
			}
			mGAAEFEKILD.KHLGDCHJJPB.currentPlayerPoint = null;
			mGAAEFEKILD.KHLGDCHJJPB.LMIHBNGHEHM.EIPHAAGCHCP = false;
			mGAAEFEKILD.KHLGDCHJJPB.LMIHBNGHEHM.AJADIICCLHO = true;
			InvokeAfterRealTime(mGAAEFEKILD.LJCDGJKCNEC, KBJEOEEOEFG);
		}
	}

	[SpecialName]
	public virtual List<UnitUpgradeDefinition> CFJLPPLLBLI()
	{
		if (Singleton<PhotonConnectionManager>.instance.isClient)
		{
			return Singleton<GameController>.instance.KKHKAJPNDEC.EHHHBEMKGOE.EIMJHEOMGGI();
		}
		return base.myUpgrades;
	}

	protected override void PKCOLNDDFPO()
	{
		FOMELELMFPM();
		if (gameIsRunning && (MatchManager.isReconnect || !MatchManager.allPlayersFinishetStartAnimation))
		{
			if (MatchManager.isReconnect)
			{
				float value = MatchManager.reconnectLength - (Time.realtimeSinceStartup - MatchManager.KKAGFMGEOBC);
				value = Mathf.Clamp(value, 0f, float.PositiveInfinity);
				GuiElementSingle<ReconnectDialog>.instance.SetWaitTime(value);
				if (value <= 0f && (PhotonNetwork.room == null || PhotonNetwork.room.playerCount != 2))
				{
					if (MatchManager.reconnectState == KAKELCLPDDK.Me)
					{
						Forfeit();
					}
					else if (Singleton<PhotonConnectionManager>.instance.isMasterClient)
					{
						if (PhotonNetwork.room != null)
						{
							PhotonNetwork.room.open = false;
						}
						GuiElementSingle<ReconnectDialog>.instance.HideDialog();
						TimeManager.Resume();
						CCINFCHDGCH(Singleton<GameController>.instance.KKHKAJPNDEC.NAGAHNHAKBJ, 0f, GameController.HKGHCIEPGEL.Forfeit);
					}
					else
					{
						Forfeit();
					}
					GuiElementSingle<ReconnectDialog>.instance.HideDialog();
				}
			}
			else
			{
				GuiElementSingle<ReconnectDialog>.instance.SetWaitTime(-1f);
			}
		}
		KCFDDKOIAOK();
	}

	protected virtual void CEPOFENIGPE()
	{
		base.BLBNJHMPGNK();
		Singleton<GameController>.instance.KKHKAJPNDEC = null;
	}

	[SpecialName]
	public virtual string AMOCJEGHPJE()
	{
		return Localization.Localize((!JPADCGODJBO) ? "ID_SLOTUPGRADE_DAMAGE" : "CardManager: Added {0}x card {1}");
	}

	public override void FinishChoosingCards()
	{
	}

	public virtual void CBNBHLONKPD(StringBuilder HOLNKOFHDNK)
	{
		MEJMLNDFDBP.ABKAOAODKGC(ref HOLNKOFHDNK, DailyMissionsManager.instance.OCKCBFLKEGJ().remainingTime);
	}

	protected virtual void AMDDLFLDFMP(byte MNMLNIMFMJP)
	{
		StopAllCoroutines();
		TimeManager.instance.LCMLMABHKIJ();
		base.FinishGameMultiplayerRPC(MNMLNIMFMJP);
	}

	protected override void FAKFMLCMIOL(PlayerController NPHCOBMHFND)
	{
	}

	public virtual void KJAFPGAGKKL()
	{
		LoadingDialog.FEHDJPIKOJD(false);
		LoadingDialog.FDBHFJFKALH(Localization.Localize("ID_WARNING_OFFEREXPIRED"), false, true).DGPEHPHGDEF = NMCJNOFAJLL;
		base.Rematch();
	}

	public virtual void PNJLJKELINN()
	{
	}

	public void FPKHIMHAMJH(DatabasePlayer NCFFGKHPJLH, out string JLBLNDGIINB, out bool MKDDIBOHCIA)
	{
		LoadingDialog.NJHOCHGJICN(false);
		base.StartMultiplayerGame(NCFFGKHPJLH, out JLBLNDGIINB, out MKDDIBOHCIA);
		if (Singleton<GameController>.instance.isCoop && MKDDIBOHCIA)
		{
			LoadingDialog.PGFBMJFLHPC(Localization.Localize("NO any UIRoot - failed "), true, true, true).DGPEHPHGDEF = NMCJNOFAJLL;
		}
	}

	private IEnumerator OLGJJHAAOBO()
	{
		OILCCDFMJEJ oILCCDFMJEJ = new OILCCDFMJEJ();
		oILCCDFMJEJ.BJGCPDNMHDH = this;
		return oILCCDFMJEJ;
	}

	public virtual void OEPIDODCNFB(StringBuilder HOLNKOFHDNK)
	{
		MEJMLNDFDBP.ABKAOAODKGC(ref HOLNKOFHDNK, DailyMissionsManager.instance.OCKCBFLKEGJ().remainingTime);
	}

	protected override Dictionary<string, UnitUpgradeDefinition> PAGGMONGACL(GHPGNELIDBM CIOPAKLHFIL)
	{
		if (Singleton<PhotonConnectionManager>.instance.isClient)
		{
			return Singleton<GameController>.instance.KKHKAJPNDEC.EHHHBEMKGOE.HDDPODGBNIC;
		}
		if (CIOPAKLHFIL == PlayerController.OGMBJPKOPCB.fraction)
		{
			return PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.HDDPODGBNIC;
		}
		return JLOJANIPMPE;
	}

	private IEnumerator GBMCAGIOAPK()
	{
		OILCCDFMJEJ oILCCDFMJEJ = new OILCCDFMJEJ();
		oILCCDFMJEJ.BJGCPDNMHDH = this;
		return oILCCDFMJEJ;
	}

	public virtual UpgradeSlots.UnitUpgrades CEPNPDGPKLE(bool KPIGIEPMLLC, AIObject ECHOPGPBLOK)
	{
		LevelBehaviour aCLDFHJKBLI = ECHOPGPBLOK.ACLDFHJKBLI;
		GHPGNELIDBM fraction = ECHOPGPBLOK.fraction;
		UpgradeSlots.UnitUpgrades pFGLIAHPMCK = base.PickUpgradesForUnit(KPIGIEPMLLC, ECHOPGPBLOK);
		pFGLIAHPMCK = DailyMissionsManager.EEKPBLHNNJD(fraction, aCLDFHJKBLI, pFGLIAHPMCK);
		aCLDFHJKBLI.behaviourDefinition.NNECIPAKPIL(pFGLIAHPMCK.scaleDamage, pFGLIAHPMCK.scaleHp);
		return pFGLIAHPMCK;
	}

	[DebuggerHidden]
	public override IEnumerator StartGame()
	{
		NCEKIFIDMCF nCEKIFIDMCF = new NCEKIFIDMCF();
		nCEKIFIDMCF.BJGCPDNMHDH = this;
		return nCEKIFIDMCF;
	}

	protected override void BDKLKNMCPPA()
	{
		if (!gameIsRunning || !TimeManager.instance.isPaused || !(TimeManager.pauseTimeLeft <= 0f) || MatchManager.isReconnect)
		{
			return;
		}
		if (TimeManager.instance.pauseStatus == TimeManager.HICMJEBLEDA.PausedRemote)
		{
			ResumeGame();
		}
		if (TimeManager.instance.pauseStatus == TimeManager.HICMJEBLEDA.PausedRemoteFocusLost)
		{
			if (Singleton<PhotonConnectionManager>.instance.isMasterClient)
			{
				ResumeGame();
			}
			else
			{
				Forfeit();
			}
		}
	}

	public virtual void OMHNGLPGPPB()
	{
	}

	public virtual void BNDLLKLJIFK()
	{
		LoadingDialog.SetLook(true);
		LoadingDialog.FDBHFJFKALH(Localization.Localize("Total_Battles"), true, false, true).DGPEHPHGDEF = NMCJNOFAJLL;
		base.Rematch();
	}

	protected override void HKGOKPMIEEI()
	{
		base.HKGOKPMIEEI();
		BEGOFBBPOLA();
	}

	public override void GetTimeProgressText(StringBuilder HOLNKOFHDNK)
	{
		MEJMLNDFDBP.ABKAOAODKGC(ref HOLNKOFHDNK, DailyMissionsManager.instance.currentMission.remainingTime);
	}

	[SpecialName]
	public virtual bool AFGFLGNIKNM()
	{
		return false;
	}

	[SpecialName]
	public virtual List<UnitUpgradeDefinition> DDLDNEAJKLG()
	{
		if (Singleton<PhotonConnectionManager>.instance.GHIKMFDGIHB())
		{
			return Singleton<GameController>.instance.KKHKAJPNDEC.EHHHBEMKGOE.HBOHEBDHLHP();
		}
		return base.myUpgrades;
	}

	[SpecialName]
	public virtual List<UnitUpgradeDefinition> LJMNGMNNAAD()
	{
		if (Singleton<PhotonConnectionManager>.instance.GHIKMFDGIHB())
		{
			return Singleton<GameController>.instance.KKHKAJPNDEC.EHHHBEMKGOE.HBOHEBDHLHP();
		}
		return base.myUpgrades;
	}

	public virtual IEnumerator JBFKKIEOBAA()
	{
		return new NHLGPCGCNKF();
	}

	[SpecialName]
	public virtual List<UnitUpgradeDefinition> CNMEPPHMJIJ()
	{
		List<UnitUpgradeDefinition> upgrades = DailyMissionsManager.instance.EEIJPIPFAMO().GetUpgrades();
		KEOLPGLCKHI(new Dictionary<string, UnitUpgradeDefinition>());
		for (int i = 1; i < LevelManager.instance.behaviours.Count; i++)
		{
			LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[i];
			JLOJANIPMPE[levelBehaviour.GetType().ToString()] = upgrades[i];
		}
		return upgrades;
	}

	private void OALMGHBFMJG(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if (Singleton<GameController>.instance.mainController == this && !Singleton<PhotonConnectionManager>.instance.isMasterClient)
		{
			PlayerController kHLGDCHJJPB = (PlayerController)MAIPDGCABNL;
			Singleton<GameCamera>.instance.LODMODJFFBE(kHLGDCHJJPB, OHJPPHFEAFI.HNFNINFCBEJ is PlayerController);
		}
	}

	[SpecialName]
	public virtual string KNIALAGDACB()
	{
		return Localization.Localize("PA: warbucks spent ");
	}

	public override void PauseGame(bool IEFGEFFDHOK)
	{
		if (!gameIsRunning)
		{
			return;
		}
		if (Singleton<PhotonConnectionManager>.instance.isMasterClient)
		{
			if (DGCCAECHJIN < 1)
			{
				TimeManager.Pause(IEFGEFFDHOK);
			}
			else if (IEFGEFFDHOK)
			{
				TimeManager.Pause(IEFGEFFDHOK);
			}
			else
			{
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<CantPauseDialog>.instance);
			}
		}
		else if (PlayerController.OGMBJPKOPCB.LMIHBNGHEHM.EHFIJJBPEEG == CKDIHNEIHKL.GLFPILGCAPM.GameFinished)
		{
			Forfeit();
		}
		else if (DGCCAECHJIN < 1)
		{
			TimeManager.Pause(IEFGEFFDHOK);
		}
		else if (IEFGEFFDHOK)
		{
			Forfeit();
		}
		else
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<CantPauseDialog>.instance);
		}
		DGCCAECHJIN++;
		PhotonNetwork.SendOutgoingCommands();
	}

	public virtual UpgradeSlots.UnitUpgrades GJHHFHBLJPF(bool KPIGIEPMLLC, AIObject ECHOPGPBLOK)
	{
		LevelBehaviour aCLDFHJKBLI = ECHOPGPBLOK.ACLDFHJKBLI;
		GHPGNELIDBM fraction = ECHOPGPBLOK.fraction;
		UpgradeSlots.UnitUpgrades pFGLIAHPMCK = base.PickUpgradesForUnit(KPIGIEPMLLC, ECHOPGPBLOK);
		pFGLIAHPMCK = DailyMissionsManager.ScaleUpgradesForMission(fraction, aCLDFHJKBLI, pFGLIAHPMCK);
		aCLDFHJKBLI.behaviourDefinition.PBKKFFKLHKA(pFGLIAHPMCK.scaleDamage, pFGLIAHPMCK.scaleHp);
		return pFGLIAHPMCK;
	}

	public virtual void HGJEHGMFEIH(StringBuilder HOLNKOFHDNK)
	{
		MEJMLNDFDBP.ABKAOAODKGC(ref HOLNKOFHDNK, DailyMissionsManager.instance.DPLEEBIFDKL().remainingTime);
	}

	public virtual IEnumerator DEPBJMPKIMG()
	{
		return new NHLGPCGCNKF();
	}

	public override void ShowResultsScreen()
	{
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<DailyMissionScreen>.instance);
	}

	[SpecialName]
	public virtual bool LDLKALFLAIM()
	{
		return true;
	}

	[SpecialName]
	public virtual void GKDGEPABMLF(List<Card> IDEBKDPMPGM)
	{
		Singleton<GameController>.instance.GMNKFFNFEHG.cardsForGame = IDEBKDPMPGM;
	}
}
