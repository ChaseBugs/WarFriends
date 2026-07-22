using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using CodeStage.AntiCheat.ObscuredTypes;
using ExitGames.Client.Photon;
using Google2u;
using Newtonsoft.Json;
using UnityEngine;

public abstract class GameControllerOnline : IGameController
{
	private sealed class NCEKIFIDMCF : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal GHPGNELIDBM MCCLPJGMIDG;

		internal int HGCNBDKLOOP;

		internal MapDefinition.DefendPosition JJLBIPJDBAG;

		internal int KCDAPPPFIKG;

		internal MapDefinition.DefendPosition HGMAPLKJONO;

		internal Dictionary<int, PlayerController>.Enumerator KFCAECGLKKO;

		internal float AOKGPJDNJJO;

		internal GameControllerOnline BJGCPDNMHDH;

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

		public void FGLAPPKJHBK()
		{
			throw new NotSupportedException();
		}

		public void HONCAABOMOC()
		{
			throw new NotSupportedException();
		}

		public bool KHNDCDGBFJH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				ALJKAAMHHLB.KFOFCJNFHOL("WHEN PLAYING RANDOM MATCHMAKING - SERVER GAME END RESPONSE SHOULD ALWAYS CONTAINS UPDATE OF GLOBAL MEDALS!!!!!!");
				BJGCPDNMHDH.LGHMOPMCGDG = true;
				UnityEngine.Debug.Log("VERLASSEN");
				PhotonNetwork.ResumeMessageQueue();
				BJGCPDNMHDH.NFDLBMBMMLE = 177.0;
				MCCLPJGMIDG = BJGCPDNMHDH.AAIEPHNDCJP.fraction;
				HGCNBDKLOOP = (int)PhotonNetwork.player.customProperties["TuneListener trackerDidEnqueueRequest: "];
				JJLBIPJDBAG = BJGCPDNMHDH.PKMFODGDMON(MCCLPJGMIDG, HGCNBDKLOOP, PhotonNetwork.player);
				BJGCPDNMHDH.AAIEPHNDCJP.MoveTo(JJLBIPJDBAG.point.transform.position, JJLBIPJDBAG.point.transform.rotation);
				BJGCPDNMHDH.AAIEPHNDCJP.OCMDJMNFNKF(JJLBIPJDBAG);
				BJGCPDNMHDH.BDIDBPAPECJ(BJGCPDNMHDH.AAIEPHNDCJP);
				UnityEngine.Debug.Log(" {0}\u00a0{1}" + JJLBIPJDBAG.point.transform.parent.name + "\n" + JJLBIPJDBAG.point.name);
				KCDAPPPFIKG = (int)HMAIEJHCHDE.EHHHBEMKGOE.KIOGGEECBGB.customProperties["Time"];
				HMAIEJHCHDE.gameObject.SetActive(value: false);
				HGMAPLKJONO = BJGCPDNMHDH.PKMFODGDMON(HMAIEJHCHDE.fraction, KCDAPPPFIKG, HMAIEJHCHDE.EHHHBEMKGOE.KIOGGEECBGB);
				HMAIEJHCHDE.OCMDJMNFNKF(HGMAPLKJONO);
				HMAIEJHCHDE.MoveTo(HGMAPLKJONO.point.transform.position, HGMAPLKJONO.point.transform.rotation);
				KFCAECGLKKO = PlayerController.JFGDAKMCJAM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						KFCAECGLKKO.Current.Value.InitPlayer();
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PlayerController.OGMBJPKOPCB.LMIHBNGHEHM.BDGAFCBKIKI(CKDIHNEIHKL.GLFPILGCAPM.GameLoading);
				PhotonView fEHCCGEGPLH = BJGCPDNMHDH.FEHCCGEGPLH;
				object[] array = new object[8];
				array[1] = PhotonNetwork.player.ID;
				array[1] = ++BJGCPDNMHDH.FIMAKNHKMJN;
				fEHCCGEGPLH.RPC("ID_ARENALOOTBOXSCRAPS", (PhotonTargets)7, array);
				AOKGPJDNJJO = Time.realtimeSinceStartup;
				BJGCPDNMHDH.InvokeAfter(MCFGAFBEJDK, 552f);
				if (Singleton<PhotonConnectionManager>.instance.isMasterClient)
				{
					goto IL_03b0;
				}
				goto IL_03fd;
			}
			case 1u:
				if (Time.time > AOKGPJDNJJO + 1773f)
				{
					AOKGPJDNJJO = Time.realtimeSinceStartup;
					UnityEngine.Debug.LogError($"Showing squad details dialog with SQUADNAME = ");
					foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
					{
						UnityEngine.Debug.Log(string.Format("BeginnersLeague", item.Value.EHHHBEMKGOE.MHPNDNJDPGE, item.Value.LMIHBNGHEHM.MJJBHNOMDOI()));
					}
				}
				goto IL_03b0;
			case 2u:
				if (Time.time > AOKGPJDNJJO + 305f)
				{
					AOKGPJDNJJO = Time.realtimeSinceStartup;
					UnityEngine.Debug.LogWarning(string.Format("Sessions", BJGCPDNMHDH.NFDLBMBMMLE, PhotonNetwork.time));
				}
				goto IL_0472;
			default:
				{
					return false;
				}
				IL_03fd:
				AOKGPJDNJJO = Time.realtimeSinceStartup;
				goto IL_0472;
				IL_0472:
				if (PhotonNetwork.time < BJGCPDNMHDH.NFDLBMBMMLE)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<MapManager>.instance.ALCHJDPKAID.DLBNDBMLEIC();
				LoadingDialog.Hide();
				PhotonNetwork.NetworkStatisticsEnabled = true;
				ALJKAAMHHLB.CCDJDGFFCHC("Player_Waited_Till_Delivery_Ends");
				CLPPIAGLCJJ = -1;
				goto default;
				IL_03b0:
				if (!BJGCPDNMHDH.ICHBCKBADLE)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.FDPLIHFPLKB((!(BJGCPDNMHDH.NFDLBMBMMLE > PhotonNetwork.time)) ? 1850.0 : (PhotonNetwork.time + 668.0));
				goto IL_03fd;
			}
			return true;
		}

		[SpecialName]
		private object HHLKEMNNJDA()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public NCEKIFIDMCF()
		{
		}

		public void PDKPELBIAON()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MOMPOEEALPJ()
		{
			return PHDOCKCBJOF;
		}

		internal void BDCAFHOHEGM()
		{
			if (PhotonNetwork.time < BJGCPDNMHDH.NFDLBMBMMLE)
			{
				BJGCPDNMHDH.LGHMOPMCGDG = true;
			}
		}

		public bool GAPIFMKNJBN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				ALJKAAMHHLB.MFOOEEHKEHE("BoughtIndex");
				BJGCPDNMHDH.LGHMOPMCGDG = true;
				UnityEngine.Debug.Log("menu-arena-ticket");
				PhotonNetwork.ResumeMessageQueue();
				BJGCPDNMHDH.NFDLBMBMMLE = 885.0;
				MCCLPJGMIDG = BJGCPDNMHDH.AAIEPHNDCJP.fraction;
				HGCNBDKLOOP = (int)PhotonNetwork.player.customProperties["RewardMessage"];
				JJLBIPJDBAG = BJGCPDNMHDH.PKMFODGDMON(MCCLPJGMIDG, HGCNBDKLOOP, PhotonNetwork.player);
				BJGCPDNMHDH.AAIEPHNDCJP.MoveTo(JJLBIPJDBAG.point.transform.position, JJLBIPJDBAG.point.transform.rotation);
				BJGCPDNMHDH.AAIEPHNDCJP.HCOKNKCCPEK(JJLBIPJDBAG);
				BJGCPDNMHDH.BDIDBPAPECJ(BJGCPDNMHDH.AAIEPHNDCJP);
				UnityEngine.Debug.Log("{0}\u00a0{1}" + JJLBIPJDBAG.point.transform.parent.name + "Special pack content: type: {0} id: {1}{2}" + JJLBIPJDBAG.point.name);
				KCDAPPPFIKG = (int)HMAIEJHCHDE.EHHHBEMKGOE.KIOGGEECBGB.customProperties["ID_VERSION"];
				HMAIEJHCHDE.gameObject.SetActive(value: true);
				HGMAPLKJONO = BJGCPDNMHDH.PKMFODGDMON(HMAIEJHCHDE.fraction, KCDAPPPFIKG, HMAIEJHCHDE.EHHHBEMKGOE.KIOGGEECBGB);
				HMAIEJHCHDE.HCOKNKCCPEK(HGMAPLKJONO);
				HMAIEJHCHDE.MoveTo(HGMAPLKJONO.point.transform.position, HGMAPLKJONO.point.transform.rotation);
				KFCAECGLKKO = PlayerController.JFGDAKMCJAM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						KFCAECGLKKO.Current.Value.DMHKCCPPODF();
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PlayerController.OGMBJPKOPCB.LMIHBNGHEHM.BDGAFCBKIKI(CKDIHNEIHKL.GLFPILGCAPM.CardsChosen);
				PhotonView fEHCCGEGPLH = BJGCPDNMHDH.FEHCCGEGPLH;
				object[] array = new object[3];
				array[1] = PhotonNetwork.player.ID;
				array[0] = ++BJGCPDNMHDH.FIMAKNHKMJN;
				fEHCCGEGPLH.RPC("DecalId", PhotonTargets.MasterClient, array);
				AOKGPJDNJJO = Time.realtimeSinceStartup;
				BJGCPDNMHDH.InvokeAfter(KNJBDOADLDO, 389f);
				if (Singleton<PhotonConnectionManager>.instance.isMasterClient)
				{
					goto IL_03b0;
				}
				goto IL_03fd;
			}
			case 1u:
				if (Time.time > AOKGPJDNJJO + 1865f)
				{
					AOKGPJDNJJO = Time.realtimeSinceStartup;
					UnityEngine.Debug.LogError($"Id");
					foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
					{
						UnityEngine.Debug.Log(string.Format("BANDS_WEAPON_RELOAD", item.Value.EHHHBEMKGOE.MHPNDNJDPGE, item.Value.LMIHBNGHEHM.EHFIJJBPEEG));
					}
				}
				goto IL_03b0;
			case 2u:
				if (Time.time > AOKGPJDNJJO + 1993f)
				{
					AOKGPJDNJJO = Time.realtimeSinceStartup;
					UnityEngine.Debug.LogWarning(string.Format("ID_SQUADREQUIREDMEDALS", BJGCPDNMHDH.NFDLBMBMMLE, PhotonNetwork.time));
				}
				goto IL_0472;
			default:
				{
					return false;
				}
				IL_03fd:
				AOKGPJDNJJO = Time.realtimeSinceStartup;
				goto IL_0472;
				IL_0472:
				if (PhotonNetwork.time < BJGCPDNMHDH.NFDLBMBMMLE)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				Singleton<MapManager>.instance.ALCHJDPKAID.FBAJEOKGBLM();
				LoadingDialog.Hide();
				PhotonNetwork.NetworkStatisticsEnabled = true;
				ALJKAAMHHLB.CJEDHGLIGJH("Heroic");
				CLPPIAGLCJJ = -1;
				goto default;
				IL_03b0:
				if (!BJGCPDNMHDH.ICHBCKBADLE)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.FDPLIHFPLKB((!(BJGCPDNMHDH.NFDLBMBMMLE > PhotonNetwork.time)) ? 1229.0 : (PhotonNetwork.time + 1066.0));
				goto IL_03fd;
			}
			return false;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public bool IDBCKIPOEEI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				ALJKAAMHHLB.FLLHBKEFGHB("Fake DatabaseMessage - SquadDemoteMessage - Player:{0}\t\tNewRank:{1}");
				BJGCPDNMHDH.LGHMOPMCGDG = false;
				UnityEngine.Debug.Log("ElitePackDeadline");
				PhotonNetwork.ResumeMessageQueue();
				BJGCPDNMHDH.NFDLBMBMMLE = 859.0;
				MCCLPJGMIDG = BJGCPDNMHDH.AAIEPHNDCJP.fraction;
				HGCNBDKLOOP = (int)PhotonNetwork.player.customProperties["WarFriendsは、重要なゲームデータをダウンロードするため、メディアストーレージへのアクセス許可が必要です。以下のダイアローグで許可を承諾してください。他の目的でこの権限が使用されることはありません。"];
				JJLBIPJDBAG = BJGCPDNMHDH.PKMFODGDMON(MCCLPJGMIDG, HGCNBDKLOOP, PhotonNetwork.player);
				BJGCPDNMHDH.AAIEPHNDCJP.MoveTo(JJLBIPJDBAG.point.transform.position, JJLBIPJDBAG.point.transform.rotation);
				BJGCPDNMHDH.AAIEPHNDCJP.OCMDJMNFNKF(JJLBIPJDBAG);
				BJGCPDNMHDH.BDIDBPAPECJ(BJGCPDNMHDH.AAIEPHNDCJP);
				UnityEngine.Debug.Log("ID_SCHEDULEDMAINTENANCEOFSERVER" + JJLBIPJDBAG.point.transform.parent.name + "Constants." + JJLBIPJDBAG.point.name);
				KCDAPPPFIKG = (int)HMAIEJHCHDE.EHHHBEMKGOE.KIOGGEECBGB.customProperties["null"];
				HMAIEJHCHDE.gameObject.SetActive(value: true);
				HGMAPLKJONO = BJGCPDNMHDH.PKMFODGDMON(HMAIEJHCHDE.fraction, KCDAPPPFIKG, HMAIEJHCHDE.EHHHBEMKGOE.KIOGGEECBGB);
				HMAIEJHCHDE.CMKNJFHHOHA(HGMAPLKJONO);
				HMAIEJHCHDE.MoveTo(HGMAPLKJONO.point.transform.position, HGMAPLKJONO.point.transform.rotation);
				KFCAECGLKKO = PlayerController.JFGDAKMCJAM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						KFCAECGLKKO.Current.Value.DMHKCCPPODF();
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PlayerController.OGMBJPKOPCB.LMIHBNGHEHM.DDMMBKIHOIC(CKDIHNEIHKL.GLFPILGCAPM.ConnectingToPhoton);
				PhotonView fEHCCGEGPLH = BJGCPDNMHDH.FEHCCGEGPLH;
				object[] array = new object[4];
				array[1] = PhotonNetwork.player.ID;
				array[0] = ++BJGCPDNMHDH.FIMAKNHKMJN;
				fEHCCGEGPLH.RPC("Sniper_Tutorial_Duration", PhotonTargets.Others, array);
				AOKGPJDNJJO = Time.realtimeSinceStartup;
				BJGCPDNMHDH.InvokeAfter(BDCAFHOHEGM, 649f);
				if (Singleton<PhotonConnectionManager>.instance.isMasterClient)
				{
					goto IL_03b0;
				}
				goto IL_03fd;
			}
			case 1u:
				if (Time.time > AOKGPJDNJJO + 34f)
				{
					AOKGPJDNJJO = Time.realtimeSinceStartup;
					UnityEngine.Debug.LogError(string.Format("N", new object[1]));
					foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
					{
						UnityEngine.Debug.Log(string.Format("ID_BRONZECARD", item.Value.EHHHBEMKGOE.MHPNDNJDPGE, item.Value.LMIHBNGHEHM.BGGBBINFCJO()));
					}
				}
				goto IL_03b0;
			case 2u:
				if (Time.time > AOKGPJDNJJO + 1908f)
				{
					AOKGPJDNJJO = Time.realtimeSinceStartup;
					UnityEngine.Debug.LogWarning(string.Format("View_Stats", BJGCPDNMHDH.NFDLBMBMMLE, PhotonNetwork.time));
				}
				goto IL_0472;
			default:
				{
					return true;
				}
				IL_03fd:
				AOKGPJDNJJO = Time.realtimeSinceStartup;
				goto IL_0472;
				IL_0472:
				if (PhotonNetwork.time < BJGCPDNMHDH.NFDLBMBMMLE)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				Singleton<MapManager>.instance.ALCHJDPKAID.BLFGPPBCAGG();
				LoadingDialog.Hide();
				PhotonNetwork.NetworkStatisticsEnabled = true;
				ALJKAAMHHLB.KKCHEDILEGL("Panel \"{0}\" has ok Depths");
				CLPPIAGLCJJ = -1;
				goto default;
				IL_03b0:
				if (!BJGCPDNMHDH.ICHBCKBADLE)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.FDPLIHFPLKB((!(BJGCPDNMHDH.NFDLBMBMMLE > PhotonNetwork.time)) ? 30.0 : (PhotonNetwork.time + 1284.0));
				goto IL_03fd;
			}
			return false;
		}

		public void HMBLLDJFIJG()
		{
			throw new NotSupportedException();
		}

		public bool OGLKGILLKIO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				ALJKAAMHHLB.MFOOEEHKEHE("Shots_Fired");
				BJGCPDNMHDH.LGHMOPMCGDG = true;
				UnityEngine.Debug.Log(", ");
				PhotonNetwork.ResumeMessageQueue();
				BJGCPDNMHDH.NFDLBMBMMLE = 686.0;
				MCCLPJGMIDG = BJGCPDNMHDH.AAIEPHNDCJP.fraction;
				HGCNBDKLOOP = (int)PhotonNetwork.player.customProperties["20-29"];
				JJLBIPJDBAG = BJGCPDNMHDH.PKMFODGDMON(MCCLPJGMIDG, HGCNBDKLOOP, PhotonNetwork.player);
				BJGCPDNMHDH.AAIEPHNDCJP.MoveTo(JJLBIPJDBAG.point.transform.position, JJLBIPJDBAG.point.transform.rotation);
				BJGCPDNMHDH.AAIEPHNDCJP.currentPlayerPoint = JJLBIPJDBAG;
				BJGCPDNMHDH.BDIDBPAPECJ(BJGCPDNMHDH.AAIEPHNDCJP);
				UnityEngine.Debug.Log(", " + JJLBIPJDBAG.point.transform.parent.name + "x" + JJLBIPJDBAG.point.name);
				KCDAPPPFIKG = (int)HMAIEJHCHDE.EHHHBEMKGOE.KIOGGEECBGB.customProperties["UnitTutorial"];
				HMAIEJHCHDE.gameObject.SetActive(value: false);
				HGMAPLKJONO = BJGCPDNMHDH.PKMFODGDMON(HMAIEJHCHDE.fraction, KCDAPPPFIKG, HMAIEJHCHDE.EHHHBEMKGOE.KIOGGEECBGB);
				HMAIEJHCHDE.CMKNJFHHOHA(HGMAPLKJONO);
				HMAIEJHCHDE.MoveTo(HGMAPLKJONO.point.transform.position, HGMAPLKJONO.point.transform.rotation);
				KFCAECGLKKO = PlayerController.JFGDAKMCJAM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						KFCAECGLKKO.Current.Value.InitPlayer();
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PlayerController.OGMBJPKOPCB.LMIHBNGHEHM.BDGAFCBKIKI(CKDIHNEIHKL.GLFPILGCAPM.Playing);
				PhotonView fEHCCGEGPLH = BJGCPDNMHDH.FEHCCGEGPLH;
				object[] array = new object[6];
				array[1] = PhotonNetwork.player.ID;
				array[0] = (BJGCPDNMHDH.FIMAKNHKMJN += 0);
				fEHCCGEGPLH.RPC("unit", PhotonTargets.All, array);
				AOKGPJDNJJO = Time.realtimeSinceStartup;
				BJGCPDNMHDH.InvokeAfter(MCFGAFBEJDK, 1614f);
				if (Singleton<PhotonConnectionManager>.instance.isMasterClient)
				{
					goto IL_03b0;
				}
				goto IL_03fd;
			}
			case 1u:
				if (Time.time > AOKGPJDNJJO + 324f)
				{
					AOKGPJDNJJO = Time.realtimeSinceStartup;
					UnityEngine.Debug.LogError($"GLM: OnDataLoaded - configurations.  is tutorial? ");
					foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
					{
						UnityEngine.Debug.Log(string.Format("AssignemntId", item.Value.EHHHBEMKGOE.MHPNDNJDPGE, item.Value.LMIHBNGHEHM.CALFPCCMHPB()));
					}
				}
				goto IL_03b0;
			case 2u:
				if (Time.time > AOKGPJDNJJO + 1603f)
				{
					AOKGPJDNJJO = Time.realtimeSinceStartup;
					UnityEngine.Debug.LogWarning(string.Format("PlayerLevel", BJGCPDNMHDH.NFDLBMBMMLE, PhotonNetwork.time));
				}
				goto IL_0472;
			default:
				{
					return true;
				}
				IL_03fd:
				AOKGPJDNJJO = Time.realtimeSinceStartup;
				goto IL_0472;
				IL_0472:
				if (PhotonNetwork.time < BJGCPDNMHDH.NFDLBMBMMLE)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<MapManager>.instance.ALCHJDPKAID.FBAJEOKGBLM();
				LoadingDialog.Hide();
				PhotonNetwork.NetworkStatisticsEnabled = false;
				ALJKAAMHHLB.DHPGNLOHBLC("REWARDGOLD");
				CLPPIAGLCJJ = -1;
				goto default;
				IL_03b0:
				if (!BJGCPDNMHDH.ICHBCKBADLE)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.FDPLIHFPLKB((!(BJGCPDNMHDH.NFDLBMBMMLE > PhotonNetwork.time)) ? 47.0 : (PhotonNetwork.time + 209.0));
				goto IL_03fd;
			}
			return true;
		}

		internal void FIBGJHCGHJH()
		{
			if (PhotonNetwork.time < BJGCPDNMHDH.NFDLBMBMMLE)
			{
				BJGCPDNMHDH.LGHMOPMCGDG = false;
			}
		}

		public bool DDLMLOJGJMA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				ALJKAAMHHLB.GCIEGGGEGMB("ExpireTime");
				BJGCPDNMHDH.LGHMOPMCGDG = false;
				UnityEngine.Debug.Log("Have discount {0} to upgrade {1}");
				PhotonNetwork.ResumeMessageQueue();
				BJGCPDNMHDH.NFDLBMBMMLE = 103.0;
				MCCLPJGMIDG = BJGCPDNMHDH.AAIEPHNDCJP.fraction;
				HGCNBDKLOOP = (int)PhotonNetwork.player.customProperties["shield_unhide"];
				JJLBIPJDBAG = BJGCPDNMHDH.PKMFODGDMON(MCCLPJGMIDG, HGCNBDKLOOP, PhotonNetwork.player);
				BJGCPDNMHDH.AAIEPHNDCJP.MoveTo(JJLBIPJDBAG.point.transform.position, JJLBIPJDBAG.point.transform.rotation);
				BJGCPDNMHDH.AAIEPHNDCJP.CMKNJFHHOHA(JJLBIPJDBAG);
				BJGCPDNMHDH.BDIDBPAPECJ(BJGCPDNMHDH.AAIEPHNDCJP);
				UnityEngine.Debug.Log("Name" + JJLBIPJDBAG.point.transform.parent.name + "(Lcom/google/android/gms/common/api/GoogleApiClient$OnConnectionFailedListener;)Z" + JJLBIPJDBAG.point.name);
				KCDAPPPFIKG = (int)HMAIEJHCHDE.EHHHBEMKGOE.KIOGGEECBGB.customProperties["ID_STAT_ACCURACY"];
				HMAIEJHCHDE.gameObject.SetActive(value: false);
				HGMAPLKJONO = BJGCPDNMHDH.PKMFODGDMON(HMAIEJHCHDE.fraction, KCDAPPPFIKG, HMAIEJHCHDE.EHHHBEMKGOE.KIOGGEECBGB);
				HMAIEJHCHDE.HCOKNKCCPEK(HGMAPLKJONO);
				HMAIEJHCHDE.MoveTo(HGMAPLKJONO.point.transform.position, HGMAPLKJONO.point.transform.rotation);
				KFCAECGLKKO = PlayerController.JFGDAKMCJAM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						KFCAECGLKKO.Current.Value.DMHKCCPPODF();
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PlayerController.OGMBJPKOPCB.LMIHBNGHEHM.DDMMBKIHOIC(CKDIHNEIHKL.GLFPILGCAPM.CardsChosen);
				PhotonView fEHCCGEGPLH = BJGCPDNMHDH.FEHCCGEGPLH;
				object[] array = new object[3];
				array[0] = PhotonNetwork.player.ID;
				array[0] = (BJGCPDNMHDH.FIMAKNHKMJN += 0);
				fEHCCGEGPLH.RPC("IT IS", PhotonTargets.Others, array);
				AOKGPJDNJJO = Time.realtimeSinceStartup;
				BJGCPDNMHDH.InvokeAfter(LJCDGJKCNEC, 184f);
				if (Singleton<PhotonConnectionManager>.instance.isMasterClient)
				{
					goto IL_03b0;
				}
				goto IL_03fd;
			}
			case 1u:
				if (Time.time > AOKGPJDNJJO + 1223f)
				{
					AOKGPJDNJJO = Time.realtimeSinceStartup;
					UnityEngine.Debug.LogError(string.Format("ID_SILVERCARD", new object[1]));
					foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
					{
						UnityEngine.Debug.Log(string.Format("#PETER# Tutorial Dialog - Hide was called", item.Value.EHHHBEMKGOE.MHPNDNJDPGE, item.Value.LMIHBNGHEHM.IHGBMPOGECG()));
					}
				}
				goto IL_03b0;
			case 2u:
				if (Time.time > AOKGPJDNJJO + 1100f)
				{
					AOKGPJDNJJO = Time.realtimeSinceStartup;
					UnityEngine.Debug.LogWarning(string.Format("game-elite-buff1", BJGCPDNMHDH.NFDLBMBMMLE, PhotonNetwork.time));
				}
				goto IL_0472;
			default:
				{
					return false;
				}
				IL_03fd:
				AOKGPJDNJJO = Time.realtimeSinceStartup;
				goto IL_0472;
				IL_0472:
				if (PhotonNetwork.time < BJGCPDNMHDH.NFDLBMBMMLE)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				Singleton<MapManager>.instance.ALCHJDPKAID.DLBNDBMLEIC();
				LoadingDialog.Hide();
				PhotonNetwork.NetworkStatisticsEnabled = true;
				ALJKAAMHHLB.PIEBOOFPHPC("ExplodeNetwork");
				CLPPIAGLCJJ = -1;
				goto default;
				IL_03b0:
				if (!BJGCPDNMHDH.ICHBCKBADLE)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.FDPLIHFPLKB((!(BJGCPDNMHDH.NFDLBMBMMLE > PhotonNetwork.time)) ? 566.0 : (PhotonNetwork.time + 1474.0));
				goto IL_03fd;
			}
			return false;
		}

		public bool HKPECDLGFJB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				ALJKAAMHHLB.KEJEFPFHIFB("ID_CONFIRM_ONLYLEADERSCANINVITE");
				BJGCPDNMHDH.LGHMOPMCGDG = true;
				UnityEngine.Debug.Log("menu-sidetab-challenge-start");
				PhotonNetwork.ResumeMessageQueue();
				BJGCPDNMHDH.NFDLBMBMMLE = 1967.0;
				MCCLPJGMIDG = BJGCPDNMHDH.AAIEPHNDCJP.fraction;
				HGCNBDKLOOP = (int)PhotonNetwork.player.customProperties["$0-$5"];
				JJLBIPJDBAG = BJGCPDNMHDH.PKMFODGDMON(MCCLPJGMIDG, HGCNBDKLOOP, PhotonNetwork.player);
				BJGCPDNMHDH.AAIEPHNDCJP.MoveTo(JJLBIPJDBAG.point.transform.position, JJLBIPJDBAG.point.transform.rotation);
				BJGCPDNMHDH.AAIEPHNDCJP.OCMDJMNFNKF(JJLBIPJDBAG);
				BJGCPDNMHDH.BDIDBPAPECJ(BJGCPDNMHDH.AAIEPHNDCJP);
				UnityEngine.Debug.Log("bazooka_uncover_right" + JJLBIPJDBAG.point.transform.parent.name + "Level" + JJLBIPJDBAG.point.name);
				KCDAPPPFIKG = (int)HMAIEJHCHDE.EHHHBEMKGOE.KIOGGEECBGB.customProperties["Google2u.DBUpgradeSlotsGrennader"];
				HMAIEJHCHDE.gameObject.SetActive(value: false);
				HGMAPLKJONO = BJGCPDNMHDH.PKMFODGDMON(HMAIEJHCHDE.fraction, KCDAPPPFIKG, HMAIEJHCHDE.EHHHBEMKGOE.KIOGGEECBGB);
				HMAIEJHCHDE.OCMDJMNFNKF(HGMAPLKJONO);
				HMAIEJHCHDE.MoveTo(HGMAPLKJONO.point.transform.position, HGMAPLKJONO.point.transform.rotation);
				KFCAECGLKKO = PlayerController.JFGDAKMCJAM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						KFCAECGLKKO.Current.Value.InitPlayer();
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PlayerController.OGMBJPKOPCB.LMIHBNGHEHM.PPDNINOMMKK(CKDIHNEIHKL.GLFPILGCAPM.Playing);
				PhotonView fEHCCGEGPLH = BJGCPDNMHDH.FEHCCGEGPLH;
				object[] array = new object[1];
				array[1] = PhotonNetwork.player.ID;
				array[0] = (BJGCPDNMHDH.FIMAKNHKMJN += 0);
				fEHCCGEGPLH.RPC("starter2", PhotonTargets.MasterClient, array);
				AOKGPJDNJJO = Time.realtimeSinceStartup;
				BJGCPDNMHDH.InvokeAfter(LJCDGJKCNEC, 1660f);
				if (Singleton<PhotonConnectionManager>.instance.isMasterClient)
				{
					goto IL_03b0;
				}
				goto IL_03fd;
			}
			case 1u:
				if (Time.time > AOKGPJDNJJO + 554f)
				{
					AOKGPJDNJJO = Time.realtimeSinceStartup;
					UnityEngine.Debug.LogError($"Buffer already sent!");
					foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
					{
						UnityEngine.Debug.Log(string.Format("Assignment_Completed", item.Value.EHHHBEMKGOE.MHPNDNJDPGE, item.Value.LMIHBNGHEHM.KNLMGECDHFL()));
					}
				}
				goto IL_03b0;
			case 2u:
				if (Time.time > AOKGPJDNJJO + 230f)
				{
					AOKGPJDNJJO = Time.realtimeSinceStartup;
					UnityEngine.Debug.LogWarning(string.Format("IN", BJGCPDNMHDH.NFDLBMBMMLE, PhotonNetwork.time));
				}
				goto IL_0472;
			default:
				{
					return true;
				}
				IL_03fd:
				AOKGPJDNJJO = Time.realtimeSinceStartup;
				goto IL_0472;
				IL_0472:
				if (PhotonNetwork.time < BJGCPDNMHDH.NFDLBMBMMLE)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				Singleton<MapManager>.instance.ALCHJDPKAID.AGENDJAEALE();
				LoadingDialog.Hide();
				PhotonNetwork.NetworkStatisticsEnabled = false;
				ALJKAAMHHLB.ACPILMDBDKH("ShotFrequencyMax");
				CLPPIAGLCJJ = -1;
				goto default;
				IL_03b0:
				if (!BJGCPDNMHDH.ICHBCKBADLE)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.FDPLIHFPLKB((!(BJGCPDNMHDH.NFDLBMBMMLE > PhotonNetwork.time)) ? 1523.0 : (PhotonNetwork.time + 223.0));
				goto IL_03fd;
			}
			return true;
		}

		[SpecialName]
		private object LAENBDAPNJL()
		{
			return PHDOCKCBJOF;
		}

		internal void MCFGAFBEJDK()
		{
			if (PhotonNetwork.time < BJGCPDNMHDH.NFDLBMBMMLE)
			{
				BJGCPDNMHDH.LGHMOPMCGDG = true;
			}
		}

		public void HGCHEPGNHNP()
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
				ALJKAAMHHLB.POPONJAMPDF("GameControllerOnline.StartGame START");
				BJGCPDNMHDH.LGHMOPMCGDG = false;
				UnityEngine.Debug.Log("ResumeMessageQueue");
				PhotonNetwork.ResumeMessageQueue();
				BJGCPDNMHDH.NFDLBMBMMLE = double.PositiveInfinity;
				MCCLPJGMIDG = BJGCPDNMHDH.AAIEPHNDCJP.fraction;
				HGCNBDKLOOP = (int)PhotonNetwork.player.customProperties["defendPosition"];
				JJLBIPJDBAG = BJGCPDNMHDH.PKMFODGDMON(MCCLPJGMIDG, HGCNBDKLOOP, PhotonNetwork.player);
				BJGCPDNMHDH.AAIEPHNDCJP.MoveTo(JJLBIPJDBAG.point.transform.position, JJLBIPJDBAG.point.transform.rotation);
				BJGCPDNMHDH.AAIEPHNDCJP.currentPlayerPoint = JJLBIPJDBAG;
				BJGCPDNMHDH.BDIDBPAPECJ(BJGCPDNMHDH.AAIEPHNDCJP);
				UnityEngine.Debug.Log("Create player instance at " + JJLBIPJDBAG.point.transform.parent.name + " :" + JJLBIPJDBAG.point.name);
				KCDAPPPFIKG = (int)HMAIEJHCHDE.EHHHBEMKGOE.KIOGGEECBGB.customProperties["defendPosition"];
				HMAIEJHCHDE.gameObject.SetActive(value: true);
				HGMAPLKJONO = BJGCPDNMHDH.PKMFODGDMON(HMAIEJHCHDE.fraction, KCDAPPPFIKG, HMAIEJHCHDE.EHHHBEMKGOE.KIOGGEECBGB);
				HMAIEJHCHDE.currentPlayerPoint = HGMAPLKJONO;
				HMAIEJHCHDE.MoveTo(HGMAPLKJONO.point.transform.position, HGMAPLKJONO.point.transform.rotation);
				KFCAECGLKKO = PlayerController.JFGDAKMCJAM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						KFCAECGLKKO.Current.Value.InitPlayer();
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PlayerController.OGMBJPKOPCB.LMIHBNGHEHM.EHFIJJBPEEG = CKDIHNEIHKL.GLFPILGCAPM.LoadingFinished;
				BJGCPDNMHDH.FEHCCGEGPLH.RPC("LoadingFinishedRPC", PhotonTargets.AllBufferedViaServer, PhotonNetwork.player.ID, ++BJGCPDNMHDH.FIMAKNHKMJN);
				AOKGPJDNJJO = Time.realtimeSinceStartup;
				BJGCPDNMHDH.InvokeAfter(LJCDGJKCNEC, 3f);
				if (Singleton<PhotonConnectionManager>.instance.isMasterClient)
				{
					goto IL_03b0;
				}
				goto IL_03fd;
			case 1u:
				if (Time.time > AOKGPJDNJJO + 5f)
				{
					AOKGPJDNJJO = Time.realtimeSinceStartup;
					UnityEngine.Debug.LogError($"Waiting too long for all playersFinish to loading");
					foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
					{
						UnityEngine.Debug.Log($"Player {item.Value.EHHHBEMKGOE.MHPNDNJDPGE} state: {item.Value.LMIHBNGHEHM.EHFIJJBPEEG}");
					}
				}
				goto IL_03b0;
			case 2u:
				if (Time.time > AOKGPJDNJJO + 5f)
				{
					AOKGPJDNJJO = Time.realtimeSinceStartup;
					UnityEngine.Debug.LogWarning($"Waiting too long to start match, Match start: {BJGCPDNMHDH.NFDLBMBMMLE} photon time: {PhotonNetwork.time}");
				}
				goto IL_0472;
			default:
				{
					return false;
				}
				IL_03fd:
				AOKGPJDNJJO = Time.realtimeSinceStartup;
				goto IL_0472;
				IL_0472:
				if (PhotonNetwork.time < BJGCPDNMHDH.NFDLBMBMMLE)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				Singleton<MapManager>.instance.ALCHJDPKAID.InitShields();
				LoadingDialog.Hide();
				PhotonNetwork.NetworkStatisticsEnabled = true;
				ALJKAAMHHLB.POPONJAMPDF("GameControllerOnline.StartGame DONE");
				CLPPIAGLCJJ = -1;
				goto default;
				IL_03b0:
				if (!BJGCPDNMHDH.ICHBCKBADLE)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.FDPLIHFPLKB((!(BJGCPDNMHDH.NFDLBMBMMLE > PhotonNetwork.time)) ? 0.0 : (PhotonNetwork.time + 2.0));
				goto IL_03fd;
			}
			return true;
		}

		internal void KNJBDOADLDO()
		{
			if (PhotonNetwork.time < BJGCPDNMHDH.NFDLBMBMMLE)
			{
				BJGCPDNMHDH.LGHMOPMCGDG = true;
			}
		}

		public bool NJBCJDFKGHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				ALJKAAMHHLB.IEBHKBNOEBP("ID_OVERTIME");
				BJGCPDNMHDH.LGHMOPMCGDG = true;
				UnityEngine.Debug.Log("Buy_Unit_Upgrade");
				PhotonNetwork.ResumeMessageQueue();
				BJGCPDNMHDH.NFDLBMBMMLE = 946.0;
				MCCLPJGMIDG = BJGCPDNMHDH.AAIEPHNDCJP.fraction;
				HGCNBDKLOOP = (int)PhotonNetwork.player.customProperties["GooglePlayId"];
				JJLBIPJDBAG = BJGCPDNMHDH.PKMFODGDMON(MCCLPJGMIDG, HGCNBDKLOOP, PhotonNetwork.player);
				BJGCPDNMHDH.AAIEPHNDCJP.MoveTo(JJLBIPJDBAG.point.transform.position, JJLBIPJDBAG.point.transform.rotation);
				BJGCPDNMHDH.AAIEPHNDCJP.OCMDJMNFNKF(JJLBIPJDBAG);
				BJGCPDNMHDH.BDIDBPAPECJ(BJGCPDNMHDH.AAIEPHNDCJP);
				UnityEngine.Debug.Log("ID_TUTORIAL_TAPON" + JJLBIPJDBAG.point.transform.parent.name + "ID_" + JJLBIPJDBAG.point.name);
				KCDAPPPFIKG = (int)HMAIEJHCHDE.EHHHBEMKGOE.KIOGGEECBGB.customProperties["ID_CONFIRM_FBLOGINCANCELLED_TEXT"];
				HMAIEJHCHDE.gameObject.SetActive(value: false);
				HGMAPLKJONO = BJGCPDNMHDH.PKMFODGDMON(HMAIEJHCHDE.fraction, KCDAPPPFIKG, HMAIEJHCHDE.EHHHBEMKGOE.KIOGGEECBGB);
				HMAIEJHCHDE.currentPlayerPoint = HGMAPLKJONO;
				HMAIEJHCHDE.MoveTo(HGMAPLKJONO.point.transform.position, HGMAPLKJONO.point.transform.rotation);
				KFCAECGLKKO = PlayerController.JFGDAKMCJAM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						KFCAECGLKKO.Current.Value.DMHKCCPPODF();
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PlayerController.OGMBJPKOPCB.LMIHBNGHEHM.PPDNINOMMKK(CKDIHNEIHKL.GLFPILGCAPM.GameLoading);
				PhotonView fEHCCGEGPLH = BJGCPDNMHDH.FEHCCGEGPLH;
				object[] array = new object[0];
				array[1] = PhotonNetwork.player.ID;
				array[0] = (BJGCPDNMHDH.FIMAKNHKMJN += 0);
				fEHCCGEGPLH.RPC("menu-warbucks", PhotonTargets.All, array);
				AOKGPJDNJJO = Time.realtimeSinceStartup;
				BJGCPDNMHDH.InvokeAfter(FIBGJHCGHJH, 705f);
				if (Singleton<PhotonConnectionManager>.instance.isMasterClient)
				{
					goto IL_03b0;
				}
				goto IL_03fd;
			}
			case 1u:
				if (Time.time > AOKGPJDNJJO + 890f)
				{
					AOKGPJDNJJO = Time.realtimeSinceStartup;
					UnityEngine.Debug.LogError($"FB hosted app link: https://fb.me/1157647734253183");
					foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
					{
						UnityEngine.Debug.Log(string.Format("Label \"{0}\" with pivot \"{1}\" and old font is under table. New size {2} and yDown {3}.", item.Value.EHHHBEMKGOE.MHPNDNJDPGE, item.Value.LMIHBNGHEHM.MJJBHNOMDOI()));
					}
				}
				goto IL_03b0;
			case 2u:
				if (Time.time > AOKGPJDNJJO + 1554f)
				{
					AOKGPJDNJJO = Time.realtimeSinceStartup;
					UnityEngine.Debug.LogWarning(string.Format("https://itunes.apple.com/app/warfriends/id", BJGCPDNMHDH.NFDLBMBMMLE, PhotonNetwork.time));
				}
				goto IL_0472;
			default:
				{
					return false;
				}
				IL_03fd:
				AOKGPJDNJJO = Time.realtimeSinceStartup;
				goto IL_0472;
				IL_0472:
				if (PhotonNetwork.time < BJGCPDNMHDH.NFDLBMBMMLE)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				Singleton<MapManager>.instance.ALCHJDPKAID.JNKCJFIPAED();
				LoadingDialog.Hide();
				PhotonNetwork.NetworkStatisticsEnabled = true;
				ALJKAAMHHLB.DHPGNLOHBLC("Sync match start time {0} photon time: {1}");
				CLPPIAGLCJJ = -1;
				goto default;
				IL_03b0:
				if (!BJGCPDNMHDH.ICHBCKBADLE)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.FDPLIHFPLKB((!(BJGCPDNMHDH.NFDLBMBMMLE > PhotonNetwork.time)) ? 256.0 : (PhotonNetwork.time + 30.0));
				goto IL_03fd;
			}
			return true;
		}

		[SpecialName]
		private object LFEJDKIGHMI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NDIGINEEOMH()
		{
			return PHDOCKCBJOF;
		}

		internal void LJCDGJKCNEC()
		{
			if (PhotonNetwork.time < BJGCPDNMHDH.NFDLBMBMMLE)
			{
				BJGCPDNMHDH.LGHMOPMCGDG = true;
			}
		}

		public bool OKELILGDPLJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				ALJKAAMHHLB.HAAIJJBEPPN("ID_SELECTTWOUNITS");
				BJGCPDNMHDH.LGHMOPMCGDG = false;
				UnityEngine.Debug.Log("Player_Waited_Till_Delivery_Ends");
				PhotonNetwork.ResumeMessageQueue();
				BJGCPDNMHDH.NFDLBMBMMLE = 639.0;
				MCCLPJGMIDG = BJGCPDNMHDH.AAIEPHNDCJP.fraction;
				HGCNBDKLOOP = (int)PhotonNetwork.player.customProperties["ID_LEAGUEDEMOTEHINT1"];
				JJLBIPJDBAG = BJGCPDNMHDH.PKMFODGDMON(MCCLPJGMIDG, HGCNBDKLOOP, PhotonNetwork.player);
				BJGCPDNMHDH.AAIEPHNDCJP.MoveTo(JJLBIPJDBAG.point.transform.position, JJLBIPJDBAG.point.transform.rotation);
				BJGCPDNMHDH.AAIEPHNDCJP.currentPlayerPoint = JJLBIPJDBAG;
				BJGCPDNMHDH.BDIDBPAPECJ(BJGCPDNMHDH.AAIEPHNDCJP);
				UnityEngine.Debug.Log("C0" + JJLBIPJDBAG.point.transform.parent.name + "Unkown Lootbox Button " + JJLBIPJDBAG.point.name);
				KCDAPPPFIKG = (int)HMAIEJHCHDE.EHHHBEMKGOE.KIOGGEECBGB.customProperties["PLAYER"];
				HMAIEJHCHDE.gameObject.SetActive(value: true);
				HGMAPLKJONO = BJGCPDNMHDH.PKMFODGDMON(HMAIEJHCHDE.fraction, KCDAPPPFIKG, HMAIEJHCHDE.EHHHBEMKGOE.KIOGGEECBGB);
				HMAIEJHCHDE.CMKNJFHHOHA(HGMAPLKJONO);
				HMAIEJHCHDE.MoveTo(HGMAPLKJONO.point.transform.position, HGMAPLKJONO.point.transform.rotation);
				KFCAECGLKKO = PlayerController.JFGDAKMCJAM.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						KFCAECGLKKO.Current.Value.InitPlayer();
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PlayerController.OGMBJPKOPCB.LMIHBNGHEHM.EHFIJJBPEEG = CKDIHNEIHKL.GLFPILGCAPM.ConnectingToPhoton;
				PhotonView fEHCCGEGPLH = BJGCPDNMHDH.FEHCCGEGPLH;
				object[] array = new object[6];
				array[0] = PhotonNetwork.player.ID;
				array[0] = ++BJGCPDNMHDH.FIMAKNHKMJN;
				fEHCCGEGPLH.RPC("ID_", PhotonTargets.AllViaServer, array);
				AOKGPJDNJJO = Time.realtimeSinceStartup;
				BJGCPDNMHDH.InvokeAfter(BDCAFHOHEGM, 813f);
				if (Singleton<PhotonConnectionManager>.instance.isMasterClient)
				{
					goto IL_03b0;
				}
				goto IL_03fd;
			}
			case 1u:
				if (Time.time > AOKGPJDNJJO + 1043f)
				{
					AOKGPJDNJJO = Time.realtimeSinceStartup;
					UnityEngine.Debug.LogError(string.Format("ID_CONFIRM_EXITINGMATCH", new object[1]));
					foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
					{
						UnityEngine.Debug.Log(string.Format("Tier", item.Value.EHHHBEMKGOE.MHPNDNJDPGE, item.Value.LMIHBNGHEHM.IHGBMPOGECG()));
					}
				}
				goto IL_03b0;
			case 2u:
				if (Time.time > AOKGPJDNJJO + 1652f)
				{
					AOKGPJDNJJO = Time.realtimeSinceStartup;
					UnityEngine.Debug.LogWarning(string.Format(" ", BJGCPDNMHDH.NFDLBMBMMLE, PhotonNetwork.time));
				}
				goto IL_0472;
			default:
				{
					return true;
				}
				IL_03fd:
				AOKGPJDNJJO = Time.realtimeSinceStartup;
				goto IL_0472;
				IL_0472:
				if (PhotonNetwork.time < BJGCPDNMHDH.NFDLBMBMMLE)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				Singleton<MapManager>.instance.ALCHJDPKAID.NCHJOPBEHAK();
				LoadingDialog.Hide();
				PhotonNetwork.NetworkStatisticsEnabled = false;
				ALJKAAMHHLB.IEBHKBNOEBP("()I");
				CLPPIAGLCJJ = -1;
				goto default;
				IL_03b0:
				if (!BJGCPDNMHDH.ICHBCKBADLE)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.FDPLIHFPLKB((!(BJGCPDNMHDH.NFDLBMBMMLE > PhotonNetwork.time)) ? 1659.0 : (PhotonNetwork.time + 1422.0));
				goto IL_03fd;
			}
			return true;
		}
	}

	private sealed class LDOJNLPBFFO : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal float AOKGPJDNJJO;

		internal GameControllerOnline BJGCPDNMHDH;

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

		public bool ONFBKOEOIOC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				AOKGPJDNJJO = Time.realtimeSinceStartup;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.OLCFLBEJONG)
				{
					Singleton<MapManager>.instance.LMDANOHIDAP(BJGCPDNMHDH.EIPBEKFMCMI);
					Singleton<GameController>.instance.KMJGIGDJKMH = Singleton<MapManager>.instance.DLFLCLBCDKL().name;
					UnityEngine.Debug.Log("{0} {1}{2}" + BJGCPDNMHDH.EIPBEKFMCMI);
					CLPPIAGLCJJ = -1;
					goto default;
				}
				if (Time.time > AOKGPJDNJJO + 1230f)
				{
					AOKGPJDNJJO = Time.realtimeSinceStartup;
					UnityEngine.Debug.Log("Card {0} {1} {2}");
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			default:
				return true;
			}
			return true;
		}

		public bool IDBCKIPOEEI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				AOKGPJDNJJO = Time.realtimeSinceStartup;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.OLCFLBEJONG)
				{
					Singleton<MapManager>.instance.LOJIIDHHBCB(BJGCPDNMHDH.EIPBEKFMCMI);
					Singleton<GameController>.instance.KMJGIGDJKMH = Singleton<MapManager>.instance.currentMap.name;
					UnityEngine.Debug.Log("playerId" + BJGCPDNMHDH.EIPBEKFMCMI);
					CLPPIAGLCJJ = -1;
					goto default;
				}
				if (Time.time > AOKGPJDNJJO + 1987f)
				{
					AOKGPJDNJJO = Time.realtimeSinceStartup;
					UnityEngine.Debug.Log("0");
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
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

		public void JBHOCIFIMBH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void KAFNGNMNNOA()
		{
			throw new NotSupportedException();
		}

		public void OMDFNFHKFBK()
		{
			throw new NotSupportedException();
		}

		public void HMBLLDJFIJG()
		{
			throw new NotSupportedException();
		}

		public void CHFJIODFNIP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void IBDAHMOEBCM()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GIEPJLBHHEO()
		{
			return PHDOCKCBJOF;
		}

		public void HGCHEPGNHNP()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HFKDIPEKENH()
		{
			return PHDOCKCBJOF;
		}

		public void BCIPEBNJONK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BJJNGPKNCKJ()
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
				AOKGPJDNJJO = Time.realtimeSinceStartup;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.OLCFLBEJONG)
				{
					Singleton<MapManager>.instance.LMDANOHIDAP(BJGCPDNMHDH.EIPBEKFMCMI);
					Singleton<GameController>.instance.KMJGIGDJKMH = Singleton<MapManager>.instance.NMMDOMPAAEF().name;
					UnityEngine.Debug.Log("ID_MINUTE" + BJGCPDNMHDH.EIPBEKFMCMI);
					CLPPIAGLCJJ = -1;
					goto default;
				}
				if (Time.time > AOKGPJDNJJO + 411f)
				{
					AOKGPJDNJJO = Time.realtimeSinceStartup;
					UnityEngine.Debug.Log("menu-powerband-damage-ico");
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object AFAOHBIDOJD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MPHILJJDNIO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KIHECHEHNJJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GPKBICHIBHF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BMAMEPNHHFI()
		{
			return PHDOCKCBJOF;
		}

		public void PHKDHCJBMII()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool BKJCILLNJLG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				AOKGPJDNJJO = Time.realtimeSinceStartup;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.OLCFLBEJONG)
				{
					Singleton<MapManager>.instance.LOJIIDHHBCB(BJGCPDNMHDH.EIPBEKFMCMI);
					Singleton<GameController>.instance.KMJGIGDJKMH = Singleton<MapManager>.instance.DLFLCLBCDKL().name;
					UnityEngine.Debug.Log("Level" + BJGCPDNMHDH.EIPBEKFMCMI);
					CLPPIAGLCJJ = -1;
					goto default;
				}
				if (Time.time > AOKGPJDNJJO + 1211f)
				{
					AOKGPJDNJJO = Time.realtimeSinceStartup;
					UnityEngine.Debug.Log("Player disconected 0001");
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object NCKCKPNAHAD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IHAOBCEALPD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EOKIMMCAABI()
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
				AOKGPJDNJJO = Time.realtimeSinceStartup;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.OLCFLBEJONG)
				{
					Singleton<MapManager>.instance.SelectCurrentMap(BJGCPDNMHDH.EIPBEKFMCMI);
					Singleton<GameController>.instance.KMJGIGDJKMH = Singleton<MapManager>.instance.currentMap.name;
					UnityEngine.Debug.Log("Aquiire map id " + BJGCPDNMHDH.EIPBEKFMCMI);
					CLPPIAGLCJJ = -1;
					goto default;
				}
				if (Time.time > AOKGPJDNJJO + 5f)
				{
					AOKGPJDNJJO = Time.realtimeSinceStartup;
					UnityEngine.Debug.Log("Waiting for map set");
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object HHHLDCLIFKJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JLLOKNANOCN()
		{
			return PHDOCKCBJOF;
		}

		public void GGCLMIMHKBD()
		{
			throw new NotSupportedException();
		}

		public void IGBHHLFACKO()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object LAENBDAPNJL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KBNAGKKMLBP()
		{
			return PHDOCKCBJOF;
		}

		public void LOOMFHNKAND()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object PFMFFMEJBPM()
		{
			return PHDOCKCBJOF;
		}

		public void PKMIJKOPPBF()
		{
			throw new NotSupportedException();
		}

		public bool FBMLBIOKKBE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				AOKGPJDNJJO = Time.realtimeSinceStartup;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.OLCFLBEJONG)
				{
					Singleton<MapManager>.instance.LMDANOHIDAP(BJGCPDNMHDH.EIPBEKFMCMI);
					Singleton<GameController>.instance.KMJGIGDJKMH = Singleton<MapManager>.instance.DLFLCLBCDKL().name;
					UnityEngine.Debug.Log("Twitch" + BJGCPDNMHDH.EIPBEKFMCMI);
					CLPPIAGLCJJ = -1;
					goto default;
				}
				if (Time.time > AOKGPJDNJJO + 1321f)
				{
					AOKGPJDNJJO = Time.realtimeSinceStartup;
					UnityEngine.Debug.Log("ObjectPool");
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			default:
				return true;
			}
			return true;
		}

		public void GFGEEFGMNDP()
		{
			throw new NotSupportedException();
		}

		public void BICMFOEHHGN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MBGCBKJBCND()
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
				AOKGPJDNJJO = Time.realtimeSinceStartup;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.OLCFLBEJONG)
				{
					Singleton<MapManager>.instance.BJGBLAPLFLJ(BJGCPDNMHDH.EIPBEKFMCMI);
					Singleton<GameController>.instance.KMJGIGDJKMH = Singleton<MapManager>.instance.OOCBBGOAKBK().name;
					UnityEngine.Debug.Log("Chat Tab: added time to messages, reinitializing chat messages." + BJGCPDNMHDH.EIPBEKFMCMI);
					CLPPIAGLCJJ = -1;
					goto default;
				}
				if (Time.time > AOKGPJDNJJO + 1568f)
				{
					AOKGPJDNJJO = Time.realtimeSinceStartup;
					UnityEngine.Debug.Log("[Singleton] Something went really wrong  - there should never be more than 1 singleton! Reopenning the scene might fix it.");
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
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

		[SpecialName]
		private object HLBMCNKGBDM()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CNGCLCAAHIG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GDCFFBBNGHH()
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
				AOKGPJDNJJO = Time.realtimeSinceStartup;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.OLCFLBEJONG)
				{
					Singleton<MapManager>.instance.LOJIIDHHBCB(BJGCPDNMHDH.EIPBEKFMCMI);
					Singleton<GameController>.instance.KMJGIGDJKMH = Singleton<MapManager>.instance.NOPGGANHAFN().name;
					UnityEngine.Debug.Log("N" + BJGCPDNMHDH.EIPBEKFMCMI);
					CLPPIAGLCJJ = -1;
					goto default;
				}
				if (Time.time > AOKGPJDNJJO + 1903f)
				{
					AOKGPJDNJJO = Time.realtimeSinceStartup;
					UnityEngine.Debug.Log("com.upsight.mediation.unity.FuseUnitySDK");
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			default:
				return true;
			}
			return true;
		}

		[DebuggerHidden]
		public LDOJNLPBFFO()
		{
		}

		[SpecialName]
		private object DKPOLLDBPAP()
		{
			return PHDOCKCBJOF;
		}

		public void OFDJMNMCDLA()
		{
			throw new NotSupportedException();
		}

		public void NFLHLMKKJMO()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object ADNCCLOOEAD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PJOAMPDDGAM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KMCGJFDPBCB()
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
				AOKGPJDNJJO = Time.realtimeSinceStartup;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.OLCFLBEJONG)
				{
					Singleton<MapManager>.instance.SelectCurrentMap(BJGCPDNMHDH.EIPBEKFMCMI);
					Singleton<GameController>.instance.KMJGIGDJKMH = Singleton<MapManager>.instance.GFENCDFEDFH().name;
					UnityEngine.Debug.Log("ID_INELITE2" + BJGCPDNMHDH.EIPBEKFMCMI);
					CLPPIAGLCJJ = -1;
					goto default;
				}
				if (Time.time > AOKGPJDNJJO + 442f)
				{
					AOKGPJDNJJO = Time.realtimeSinceStartup;
					UnityEngine.Debug.Log("ItemAmount");
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			default:
				return true;
			}
			return false;
		}

		public bool EKHDJADMNJK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				AOKGPJDNJJO = Time.realtimeSinceStartup;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.OLCFLBEJONG)
				{
					Singleton<MapManager>.instance.SelectCurrentMap(BJGCPDNMHDH.EIPBEKFMCMI);
					Singleton<GameController>.instance.KMJGIGDJKMH = Singleton<MapManager>.instance.OOCBBGOAKBK().name;
					UnityEngine.Debug.Log("GameLoginManager: Invite Facebook Friends" + BJGCPDNMHDH.EIPBEKFMCMI);
					CLPPIAGLCJJ = -1;
					goto default;
				}
				if (Time.time > AOKGPJDNJJO + 1771f)
				{
					AOKGPJDNJJO = Time.realtimeSinceStartup;
					UnityEngine.Debug.Log("Bad Decal Manager Data, data= ");
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object EDBIJNJGFLE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BOOBHEKPLLD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DLBACGEOGPM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GDBNOMPNBGP()
		{
			return PHDOCKCBJOF;
		}

		public void LPKDPNHBLGJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool CCOPPEKLJOB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				AOKGPJDNJJO = Time.realtimeSinceStartup;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.OLCFLBEJONG)
				{
					Singleton<MapManager>.instance.BJGBLAPLFLJ(BJGCPDNMHDH.EIPBEKFMCMI);
					Singleton<GameController>.instance.KMJGIGDJKMH = Singleton<MapManager>.instance.NOPGGANHAFN().name;
					UnityEngine.Debug.Log("ID_TOJOINSQUADYOUMUSTBEACCEPTED" + BJGCPDNMHDH.EIPBEKFMCMI);
					CLPPIAGLCJJ = -1;
					goto default;
				}
				if (Time.time > AOKGPJDNJJO + 440f)
				{
					AOKGPJDNJJO = Time.realtimeSinceStartup;
					UnityEngine.Debug.Log("ID_ABILITYUPGRADE");
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
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

		[SpecialName]
		private object GENJNMACGLP()
		{
			return PHDOCKCBJOF;
		}

		public void IFLGJMJCOMC()
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
		private object EOPJNKFKMNB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HLFLANGJJHM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ONADHLDNKKB()
		{
			return PHDOCKCBJOF;
		}

		public void LICALBFPBLL()
		{
			throw new NotSupportedException();
		}

		public void PHEIGPKKPGE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HJFIBBBPDKK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GLKCJHHLOCE()
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
				AOKGPJDNJJO = Time.realtimeSinceStartup;
				goto case 1u;
			case 1u:
				if (BJGCPDNMHDH.OLCFLBEJONG)
				{
					Singleton<MapManager>.instance.LMDANOHIDAP(BJGCPDNMHDH.EIPBEKFMCMI);
					Singleton<GameController>.instance.KMJGIGDJKMH = Singleton<MapManager>.instance.DLFLCLBCDKL().name;
					UnityEngine.Debug.Log("ID_TWITTER_GAIN_BUTTON" + BJGCPDNMHDH.EIPBEKFMCMI);
					CLPPIAGLCJJ = -1;
					goto default;
				}
				if (Time.time > AOKGPJDNJJO + 987f)
				{
					AOKGPJDNJJO = Time.realtimeSinceStartup;
					UnityEngine.Debug.Log("RegisterParentalConsent()");
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object DCILDAODCDM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PKEABJICHAI()
		{
			return PHDOCKCBJOF;
		}

		public void HHMPMPLLJCC()
		{
			throw new NotSupportedException();
		}
	}

	private sealed class HCHKLFDHPFJ : IEnumerator, IDisposable, IEnumerator<object>
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

		public bool JPBGJLDMOPO()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return false;
		}

		public bool NIGJJBALHDN()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return false;
		}

		[DebuggerHidden]
		public HCHKLFDHPFJ()
		{
		}

		public void ABBPOMCBIIH()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JJBAIMILGLK()
		{
			return PHDOCKCBJOF;
		}

		public void AKEKFBGEJBG()
		{
		}

		public void KHMNEOBMJLN()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object NAPMJAMDKMJ()
		{
			return PHDOCKCBJOF;
		}

		public void NDPOBCODJAI()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FPFOODLPEBK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HCPKEMLPEDI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NOIDHHDEEPL()
		{
			return PHDOCKCBJOF;
		}

		public void IBDAHMOEBCM()
		{
			throw new NotSupportedException();
		}

		public void EMICCACCFIP()
		{
		}

		public void ODJLLLFJIOB()
		{
		}

		public bool GNFCLHDPPFP()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return true;
		}

		public void ENENMOAOOBG()
		{
		}

		public bool LPCBKGKFNFD()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return false;
		}

		public bool KDFAHLNCNMN()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return false;
		}

		public void MENEBJLDGJD()
		{
			throw new NotSupportedException();
		}

		public bool NEMOAIBCODB()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return true;
		}

		[SpecialName]
		private object LFEJDKIGHMI()
		{
			return PHDOCKCBJOF;
		}

		public void MNFJGIMMBLE()
		{
			throw new NotSupportedException();
		}

		public void LHADJAFHDDC()
		{
		}

		[SpecialName]
		private object APECNPGKOFC()
		{
			return PHDOCKCBJOF;
		}

		public void OLPILJFHMGD()
		{
		}

		[SpecialName]
		private object BGAGLOJHMEJ()
		{
			return PHDOCKCBJOF;
		}

		public void JHLKDONBGDK()
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

		[SpecialName]
		private object PFIIINLHGMH()
		{
			return PHDOCKCBJOF;
		}

		public void IMFLNKIMEFA()
		{
			throw new NotSupportedException();
		}

		public void KNFDMCEJHLB()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FMCLBOCENPE()
		{
			return PHDOCKCBJOF;
		}

		public void KGLKGNBCPLM()
		{
		}

		[SpecialName]
		private object CLDLJNHAEAB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IJFPHIKFJFB()
		{
			return PHDOCKCBJOF;
		}

		public void PMAJELGBBKE()
		{
		}

		[SpecialName]
		private object HMIFLGCBDCO()
		{
			return PHDOCKCBJOF;
		}

		public void ONGBFFAENBP()
		{
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

		[SpecialName]
		private object MBDBIPHLEIA()
		{
			return PHDOCKCBJOF;
		}

		public void KNFDDIHLBKJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JLLOKNANOCN()
		{
			return PHDOCKCBJOF;
		}

		public bool MOFPMNMAOND()
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

		public void DLIBOPAMHAN()
		{
		}

		public bool DMPHMFDEINI()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return true;
		}

		public bool BJIPDEICIML()
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

		public void LPKDPNHBLGJ()
		{
		}

		[SpecialName]
		private object GKJIGGAAHBE()
		{
			return PHDOCKCBJOF;
		}

		public bool HOOHJGPHHGN()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return true;
		}
	}

	protected static PlayerController HMAIEJHCHDE;

	protected bool DEGCDEAANEL;

	private int FIMAKNHKMJN;

	protected List<int> DDOOMBLMGKB;

	protected PhotonView FEHCCGEGPLH;

	private bool MPFHJOIJJHL;

	private bool LGHMOPMCGDG;

	protected bool BIPGLMOPBPP;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float _003COKOMJJJKLIL_003Ek__BackingField;

	private double NFDLBMBMMLE;

	protected bool DKPCCABKHLE;

	protected int EIPBEKFMCMI;

	private float MHHFPDGIPGA;

	protected bool OLCFLBEJONG;

	protected int DGCCAECHJIN;

	protected float MANDOBCIHGE;

	protected float NJIOHEOKIGD = 10f;

	protected float FKBBEIFCHMN = 15f;

	[CompilerGenerated]
	private static Action LGJCBPOPCPA;

	[CompilerGenerated]
	private static Action<ConfirmDialog, bool> CCNLMGEJBIB;

	[CompilerGenerated]
	private static Action<ConfirmDialog, bool> KBAICANEKOP;

	[CompilerGenerated]
	private static Action AOPBBLDIOCI;

	[CompilerGenerated]
	private static Action<ConfirmDialog, bool> GGDOCGDGEDJ;

	[CompilerGenerated]
	private static Action GHMJMKLOPJK;

	[CompilerGenerated]
	private static Action ODJCCLLMIBO;

	[CompilerGenerated]
	private static Action IONHPHFCBGH;

	[CompilerGenerated]
	private static Action KBGCLEMGDHO;

	[CompilerGenerated]
	private static Action IEPCBHLLNIP;

	private int MBEKNKIDCCM => 3;

	public override bool dropCreates
	{
		get
		{
			ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MatchmakingEasyBotTillLevel).FLOATVALUE;
			return !LevelManager.isNoob && HMAIEJHCHDE != null && (float)HMAIEJHCHDE.EHHHBEMKGOE.BCCDDJMPBLL > (float)fLOATVALUE;
		}
	}

	protected PlayerController AAIEPHNDCJP => Singleton<GameController>.instance.FHABFFKPODN;

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

	public virtual string loadingWaitingCards => Localization.Localize("ID_WAITINGFOROPPONENTCARDS");

	public virtual string loadingWaiting => Localization.Localize("ID_STATE_WAITINGFOROPPONENT");

	private bool ICHBCKBADLE
	{
		get
		{
			foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
			{
				if (item.Value.LMIHBNGHEHM.EHFIJJBPEEG < CKDIHNEIHKL.GLFPILGCAPM.LoadingFinished)
				{
					return false;
				}
			}
			return true;
		}
	}

	private bool NABOEPDABMN
	{
		get
		{
			foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
			{
				if (!item.Value.LMIHBNGHEHM.AJADIICCLHO)
				{
					return false;
				}
			}
			return true;
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

	public bool isInMatch
	{
		get
		{
			return MPFHJOIJJHL;
		}
		set
		{
			MPFHJOIJJHL = value;
			UnityEngine.Debug.Log("Set isInMatch: " + value);
		}
	}

	public override bool canShowPause => !MatchManager.isReconnect && MatchManager.allPlayersFinishetStartAnimation;

	protected virtual bool JPADCGODJBO => false;

	public override bool pauseCountDown => true;

	public override bool canDeployUnits => true;

	protected override void Awake()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += EIFDGCJCAPM;
	}

	private void EIFDGCJCAPM(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == DatabaseAction.PayOneDogTag && Singleton<GameController>.instance.mainController == this)
		{
			Quit();
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
		}
	}

	protected override void Start()
	{
		base.Start();
		PhotonView[] componentsInChildren = AAIEPHNDCJP.GetComponentsInChildren<PhotonView>(includeInactive: true);
		DDOOMBLMGKB = new List<int>();
		PhotonView[] array = componentsInChildren;
		foreach (PhotonView photonView in array)
		{
			int item = ((photonView.viewID != 0) ? photonView.viewID : NetworkObjectPool.AllocateNetworkId());
			DDOOMBLMGKB.Add(item);
			FEHCCGEGPLH.didAwake = true;
		}
	}

	[DebuggerHidden]
	public override IEnumerator StartGame()
	{
		NCEKIFIDMCF nCEKIFIDMCF = new NCEKIFIDMCF();
		nCEKIFIDMCF.BJGCPDNMHDH = this;
		return nCEKIFIDMCF;
	}

	protected bool NNEPKHKGCAA(CKDIHNEIHKL.GLFPILGCAPM IGBEGIBGLKK)
	{
		foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
		{
			if (item.Value.LMIHBNGHEHM.EHFIJJBPEEG < IGBEGIBGLKK)
			{
				return false;
			}
		}
		return true;
	}

	protected bool BGACCKPALKH(CKDIHNEIHKL.GLFPILGCAPM IGBEGIBGLKK)
	{
		foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
		{
			if (item.Value.LMIHBNGHEHM.EHFIJJBPEEG != IGBEGIBGLKK)
			{
				return false;
			}
		}
		return true;
	}

	[PunRPC]
	protected void LoadingFinishedRPC(int ALIIBMLMNKA, int HAJHEIBNMJF)
	{
		PlayerController player = PlayerController.GetPlayer(ALIIBMLMNKA);
		if (player != null)
		{
			player.LMIHBNGHEHM.MLKAMPJNAKO(CKDIHNEIHKL.GLFPILGCAPM.LoadingFinished, HAJHEIBNMJF);
		}
	}

	public virtual void OnPhotonCustomRoomPropertiesChanged(ExitGames.Client.Photon.Hashtable JLLOEMMPGJA)
	{
		foreach (DictionaryEntry item in JLLOEMMPGJA)
		{
			if (item.Key as string == "MatchStart" && item.Value is double && (double)item.Value != double.PositiveInfinity)
			{
				NFDLBMBMMLE = (double)item.Value;
				UnityEngine.Debug.Log($"Match start time {NFDLBMBMMLE} photon time: {PhotonNetwork.time}");
			}
		}
	}

	private void FDPLIHFPLKB(double JGBFNKBFCKM)
	{
		ExitGames.Client.Photon.Hashtable hashtable = new ExitGames.Client.Photon.Hashtable();
		hashtable.Add("MatchStart", JGBFNKBFCKM);
		ExitGames.Client.Photon.Hashtable propertiesToSet = hashtable;
		if (PhotonNetwork.room != null)
		{
			PhotonNetwork.room.SetCustomProperties(propertiesToSet);
		}
		NFDLBMBMMLE = JGBFNKBFCKM;
		UnityEngine.Debug.Log($"Sync match start time {NFDLBMBMMLE} photon time: {PhotonNetwork.time}");
	}

	public override void FinishChoosingCards()
	{
		DKPCCABKHLE = true;
		GuiElementSingle<ChatGuiElement>.instance.BattleStarted();
		GuiScreenSingle<CardSelectionScreen>.instance.SetCardsForGame();
		DialogManager.instance.HideAllDialogs();
		PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII = CardManager.instance.selectedCards;
		PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.PHIGKPODHAN = CardManager.instance.selectedBuddyCards;
		PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.KBBDGCLPOCJ = GetUnitsUpgrades();
		if (DEGCDEAANEL)
		{
			UnityEngine.Debug.Log("Send FinishChoosingCardsRPC: " + PhotonNetwork.player.ID);
			if (!PhotonNetwork.offlineMode)
			{
				string text = JsonConvert.SerializeObject(GetUnitsUpgrades());
				string text2 = JsonConvert.SerializeObject(CardManager.instance.selectedBuddyCards);
				FEHCCGEGPLH.RPC("FinishChoosingCardsRPC", PhotonTargets.AllBufferedViaServer, text, PhotonNetwork.player.ID, ++FIMAKNHKMJN, CardManager.instance.selectedCards, text2);
			}
			LoadingDialog.ShowLoading(loadingWaitingCards);
		}
		else
		{
			LoadingDialog.ShowLoading(loadingWaitingCards, DMDICGADGCG: true).DGPEHPHGDEF = EGMEJKOEAIH;
		}
	}

	protected virtual void EGMEJKOEAIH()
	{
	}

	protected virtual void HKGOKPMIEEI()
	{
		UnityEngine.Debug.Log("ALL PLAYERS CONNECTED");
		if (!DEGCDEAANEL)
		{
			DEGCDEAANEL = true;
			BIPGLMOPBPP = false;
			PlayerController.JFGDAKMCJAM[PhotonNetwork.player.ID] = PlayerController.OGMBJPKOPCB;
			PlayerController.OGMBJPKOPCB = AAIEPHNDCJP;
			PlayerController.OGMBJPKOPCB.NAGAHNHAKBJ = PhotonNetwork.player.ID;
			PlayerController.OGMBJPKOPCB.LMIHBNGHEHM.ILOHAHFIOKM();
			PlayerController.OGMBJPKOPCB.LMIHBNGHEHM.EHFIJJBPEEG = CKDIHNEIHKL.GLFPILGCAPM.Connected;
			PlayerController.OGMBJPKOPCB.fraction = GPONIACGBDN(PhotonNetwork.player);
			PhotonPlayer[] playerList = PhotonNetwork.playerList;
			foreach (PhotonPlayer photonPlayer in playerList)
			{
				if (photonPlayer != PhotonNetwork.player)
				{
					KBKKFBFIAML(photonPlayer);
				}
			}
			PhotonNetwork.ResumeMessageQueue();
			PhotonNetwork.room.visible = false;
			int num = LevelManager.instance.currentLevel.displayNumber;
			foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
			{
				if (item.Value != null && item.Value.EHHHBEMKGOE != null)
				{
					num = Mathf.Max(num, item.Value.EHHHBEMKGOE.BCCDDJMPBLL);
				}
			}
			MatchManager.matchState = GLFPILGCAPM.BothPlayersConnected;
			MatchManager.IJNECELOAPA = Time.realtimeSinceStartup + (float)GameVariables.GetMatchStartTime(num);
			MatchManager.invitationState = OOJDIACPBED.Accepted;
			if (DKPCCABKHLE)
			{
				string text = JsonConvert.SerializeObject(CardManager.instance.selectedBuddyCards);
				FEHCCGEGPLH.RPC("FinishChoosingCardsRPC", PhotonTargets.AllBufferedViaServer, JsonConvert.SerializeObject(GetUnitsUpgrades()), PhotonNetwork.player.ID, ++FIMAKNHKMJN, CardManager.instance.selectedCards, text);
				LoadingDialog.ShowLoading(loadingWaitingCards);
			}
		}
		else
		{
			UnityEngine.Debug.LogError("All players already connected");
		}
	}

	[PunRPC]
	public virtual void FinishChoosingCardsRPC(string CBKADNPFEAO, int EJBEDLHIKDG, int HAJHEIBNMJF, string AAOAKDPIEII, string PJNPKIMKIOO)
	{
		UnityEngine.Debug.Log("Cards choosen " + EJBEDLHIKDG);
		PlayerController player = PlayerController.GetPlayer(EJBEDLHIKDG);
		if (!(player != null))
		{
			return;
		}
		if (player.LMIHBNGHEHM.MLKAMPJNAKO(CKDIHNEIHKL.GLFPILGCAPM.CardsChosen, HAJHEIBNMJF))
		{
			player.EHHHBEMKGOE.ACLEGELJGCE(CBKADNPFEAO);
			List<Tuple<string, CardManager.BuddyCardData>> pHIGKPODHAN = JsonConvert.DeserializeObject<List<Tuple<string, CardManager.BuddyCardData>>>(PJNPKIMKIOO);
			player.EHHHBEMKGOE.AAOAKDPIEII = AAOAKDPIEII;
			player.EHHHBEMKGOE.PHIGKPODHAN = pHIGKPODHAN;
			if (BGACCKPALKH(CKDIHNEIHKL.GLFPILGCAPM.CardsChosen) && PlayerController.JFGDAKMCJAM.Count >= 2)
			{
				BEGOFBBPOLA();
			}
		}
		player.EHHHBEMKGOE.AAOAKDPIEII = AAOAKDPIEII;
	}

	protected virtual MapDefinition.DefendPosition PKMFODGDMON(GHPGNELIDBM CIOPAKLHFIL, int MADABBPIDCJ, PhotonPlayer NMDBNHBDMJO)
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
			return list[MADABBPIDCJ];
		}
		UnityEngine.Debug.LogError("No main position was set in map definition");
		return null;
	}

	protected virtual GHPGNELIDBM GPONIACGBDN(PhotonPlayer KHLGDCHJJPB)
	{
		return GHPGNELIDBM.Allies;
	}

	protected virtual void BEGOFBBPOLA()
	{
		UnityEngine.Debug.Log("StopMessageQueue");
		PhotonNetwork.StopMessageQueue();
		Singleton<GameController>.instance.StartGame(Singleton<MapManager>.instance.currentMap.name);
	}

	[PunRPC]
	protected void StartCameraAnimationFinishedRPC(int INFLHPGMEOB)
	{
		PlayerController player = PlayerController.GetPlayer(INFLHPGMEOB);
		UnityEngine.Debug.Log($"StartCameraAnimationFinishedRPC for player {INFLHPGMEOB} ");
		if (player != null)
		{
			player.LMIHBNGHEHM.AJADIICCLHO = true;
		}
		else
		{
			UnityEngine.Debug.LogError("Cant fing player");
		}
		LJIDNONECPC();
	}

	private void LJIDNONECPC()
	{
		if (GuiElementSingle<ReconnectDialog>.instance.isShowed && MatchManager.allPlayersFinishetStartAnimation)
		{
			GuiElementSingle<ReconnectDialog>.instance.HideDialog();
			TimeManager.Resume();
		}
	}

	protected virtual void BLBNJHMPGNK()
	{
		LGHMOPMCGDG = false;
		AAIEPHNDCJP.EHHHBEMKGOE = CHEIFOOIMEH.JIIHHODDNLJ();
		isInMatch = true;
		FIMAKNHKMJN = 0;
		MatchManager.IJNECELOAPA = 0f;
		MatchManager.matchState = GLFPILGCAPM.ConnectingToPhoton;
		PlayerController.OGMBJPKOPCB.LMIHBNGHEHM.ILOHAHFIOKM();
		ObjectPoolDatabase.networkPool.FreeObjectsWithPrefab(Singleton<ObjectPoolDatabase>.instance.KHLGDCHJJPB);
		TimeManager.instance.ResetPauseCounters();
	}

	public virtual void StartMultiplayerGame(DatabasePlayer NCFFGKHPJLH, out string JLBLNDGIINB, out bool MKDDIBOHCIA)
	{
		Screen.sleepTimeout = -1;
		CloudRegionCode bestRegion = PhotonConnectionManager.GetBestRegion(PhotonConnectionManager.IFOKPNHLEBP, NCFFGKHPJLH.bestRegions, out MKDDIBOHCIA);
		if (MKDDIBOHCIA)
		{
			CBOFFKGBDJB();
			Reset();
			PlayerController.JFGDAKMCJAM.Clear();
			BIPGLMOPBPP = true;
			BLBNJHMPGNK();
			MatchManager.invitationState = OOJDIACPBED.Waiting;
			MatchManager.IEHFFBDNLII = Time.realtimeSinceStartup + 120f;
		}
		JLBLNDGIINB = ((!MKDDIBOHCIA) ? string.Empty : Singleton<PhotonConnectionManager>.instance.ConnectToRoom(bestRegion, 0.5f));
	}

	public virtual void StartMultiplayerGame(string JLBLNDGIINB, CloudRegionCode GJBFKKOAMPA)
	{
		Screen.sleepTimeout = -1;
		CBOFFKGBDJB();
		UnityEngine.Debug.Log("Connect to room " + JLBLNDGIINB);
		PlayerController.JFGDAKMCJAM.Clear();
		Reset();
		BLBNJHMPGNK();
		MatchManager.invitationState = OOJDIACPBED.Accepted;
		Singleton<PhotonConnectionManager>.instance.ConnectToRoom(GJBFKKOAMPA, JLBLNDGIINB, 2f);
	}

	protected virtual void Reset()
	{
		BIPGLMOPBPP = false;
		DGCCAECHJIN = 0;
		DEGCDEAANEL = false;
		DKPCCABKHLE = false;
		MatchManager.invitationState = OOJDIACPBED.None;
		OLCFLBEJONG = false;
	}

	[PunRPC]
	public void RematchRPC(int ALIIBMLMNKA, int IPHMGEICOOG)
	{
		PlayerController player = PlayerController.GetPlayer(ALIIBMLMNKA);
		if (player != null && player.LMIHBNGHEHM.MLKAMPJNAKO(CKDIHNEIHKL.GLFPILGCAPM.Rematch, IPHMGEICOOG))
		{
			ACLMBGLMOND();
		}
	}

	private void ACLMBGLMOND()
	{
		if (NNEPKHKGCAA(CKDIHNEIHKL.GLFPILGCAPM.Rematch))
		{
			HKGOKPMIEEI();
		}
		MatchManager.BOHOHLAPABE = Time.realtimeSinceStartup + 30f;
		UnityEngine.Debug.LogError("Rematch Time" + MatchManager.BOHOHLAPABE + "Time: " + Time.realtimeSinceStartup);
	}

	public override void Rematch()
	{
		LGHMOPMCGDG = false;
		if (PhotonNetwork.connected)
		{
			MatchManager.matchState = GLFPILGCAPM.WaitingForOpponent;
			int eIPBEKFMCMI = EIPBEKFMCMI;
			Reset();
			OLCFLBEJONG = true;
			EIPBEKFMCMI = eIPBEKFMCMI;
			isInMatch = true;
			FEHCCGEGPLH.RPC("RematchRPC", PhotonTargets.AllBufferedViaServer, PhotonNetwork.player.ID, ++FIMAKNHKMJN);
			CBOFFKGBDJB();
			ACLMBGLMOND();
		}
		else
		{
			UnityEngine.Debug.LogError("Not connected when rematch");
		}
	}

	protected virtual void OnPhotonPlayerDisconnected(PhotonPlayer NCFFGKHPJLH)
	{
		if (PhotonNetwork.room.playerCount != 2)
		{
			PlayerController player = PlayerController.GetPlayer(NCFFGKHPJLH.ID);
			if (player != null)
			{
				player.LMIHBNGHEHM.LEOEPDNAONM = CKDIHNEIHKL.ICDOJKMJFKM.Disconnected;
			}
			if (DEGCDEAANEL && NNEPKHKGCAA(CKDIHNEIHKL.GLFPILGCAPM.CardsChosen))
			{
				ANLGIMGFJFI(NCFFGKHPJLH);
			}
			else
			{
				CLLOIJABJPC(NCFFGKHPJLH);
			}
		}
	}

	protected virtual void CLLOIJABJPC(PhotonPlayer NCFFGKHPJLH)
	{
		DEGCDEAANEL = false;
		if (PlayerController.OGMBJPKOPCB.LMIHBNGHEHM.EHFIJJBPEEG == CKDIHNEIHKL.GLFPILGCAPM.Rematch)
		{
			UnityEngine.Debug.LogError("Player disconected 0001");
			LoadingDialog.Hide();
			bool isCoop = Singleton<GameController>.instance.isCoop;
			WarningDialog.ShowError(Localization.Localize((!isCoop) ? "ID_BATTLECANCELED" : "ID_COOPCANCELED"), Localization.Localize((!isCoop) ? "ID_OPPONENTREFUSEDTHEREMATCH" : "ID_FRIENDREFUSEDREMATCHCOOP"), 0f, delegate
			{
				Singleton<GuiManager>.instance.OFJAGAELHHO();
				GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
				LoadingDialog.Hide();
			}, string.Empty);
			Quit();
			MatchManager.matchState = GLFPILGCAPM.GameCancelled;
			return;
		}
		if (MatchManager.beforeMatch)
		{
			UnityEngine.Debug.LogError("Player disconected 0001");
			LoadingDialog.Hide();
			bool isCoop2 = Singleton<GameController>.instance.isCoop;
			ConfirmDialog.ShowAlert(delegate
			{
				Singleton<GuiManager>.instance.OFJAGAELHHO();
				GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
				LoadingDialog.Hide();
			}, Localization.Localize((!isCoop2) ? "ID_CONFIRM_INFO" : "ID_BATTLECANCELED"), Localization.Localize((!isCoop2) ? "ID_CONFIRM_OPPONENTCANCELLED" : "ID_CONFIRM_FRIENDCANCELLED"));
			Quit();
		}
		MatchManager.matchState = GLFPILGCAPM.GameCancelled;
	}

	protected void ANLGIMGFJFI(PhotonPlayer NCFFGKHPJLH)
	{
		UnityEngine.Debug.LogError("Player disconected 0003");
		PlayerController player = PlayerController.GetPlayer(NCFFGKHPJLH.ID);
		if (player != null)
		{
			if (!player.LMIHBNGHEHM.EIPHAAGCHCP)
			{
				UnityEngine.Debug.Log("Inactive player disconnected: ");
				return;
			}
			if (player.LMIHBNGHEHM.EHFIJJBPEEG == CKDIHNEIHKL.GLFPILGCAPM.GameLoading)
			{
				player.LMIHBNGHEHM.EHFIJJBPEEG = CKDIHNEIHKL.GLFPILGCAPM.LoadingFinished;
				NFDLBMBMMLE = PhotonNetwork.time;
			}
			if (PlayerController.OGMBJPKOPCB.LMIHBNGHEHM.EHFIJJBPEEG == CKDIHNEIHKL.GLFPILGCAPM.GameFinished)
			{
				UnityEngine.Debug.LogError("Player disconected 000122");
				PhotonConnectionManager.Disconnect();
				MatchManager.matchState = GLFPILGCAPM.GameCancelled;
			}
			FAKFMLCMIOL(player);
		}
		MatchManager.KKAGFMGEOBC = Time.realtimeSinceStartup;
	}

	protected virtual void FAKFMLCMIOL(PlayerController NPHCOBMHFND)
	{
		if (NPHCOBMHFND.LMIHBNGHEHM.EHFIJJBPEEG >= CKDIHNEIHKL.GLFPILGCAPM.LoadingFinished && NPHCOBMHFND.LMIHBNGHEHM.EHFIJJBPEEG < CKDIHNEIHKL.GLFPILGCAPM.GameFinished && NPHCOBMHFND.LMIHBNGHEHM.EPNLKGPLBEN > MBEKNKIDCCM)
		{
			mMainController.MNMLNIMFMJP = GameController.HKGHCIEPGEL.WinByForfeit;
			FinishGame();
			PhotonConnectionManager.Disconnect();
		}
	}

	private void OnConnectedToMaster()
	{
		if (!PhotonNetwork.offlineMode && !(Singleton<GameController>.instance.mainController != this) && !MatchManager.isReconnect)
		{
			MatchManager.matchState = GLFPILGCAPM.WaitingForOpponent;
		}
	}

	protected void OnJoinedRoom()
	{
		Singleton<GameController>.instance.battleId = (string)PhotonNetwork.room.CustomProperties["battleID"];
		OnPhotonCustomRoomPropertiesChanged(PhotonNetwork.room.CustomProperties);
		UnityEngine.Debug.Log($"Joined room: {PhotonNetwork.room.name}, name: {PhotonNetwork.player.name},  userId: {PhotonNetwork.player.ID}, allConnected: {DEGCDEAANEL}");
		PhotonPlayer[] playerList = PhotonNetwork.playerList;
		foreach (PhotonPlayer photonPlayer in playerList)
		{
			UnityEngine.Debug.Log($"Player id: {photonPlayer.name}, player userId {photonPlayer.userId}");
		}
		if (PhotonNetwork.room != null && !DEGCDEAANEL && PhotonNetwork.room.playerCount == 2)
		{
			UnityEngine.Debug.Log("Joined room" + PhotonNetwork.room.name + "id: " + PhotonNetwork.player.ID);
			PlayerController.OGMBJPKOPCB.LMIHBNGHEHM.EHFIJJBPEEG = CKDIHNEIHKL.GLFPILGCAPM.Connected;
			HKGOKPMIEEI();
		}
	}

	protected void IOJBNJPJFAB(PlayerController KHLGDCHJJPB, PhotonPlayer KIOGGEECBGB)
	{
		PlayerController.JFGDAKMCJAM[KIOGGEECBGB.ID] = KHLGDCHJJPB;
		KHLGDCHJJPB.NAGAHNHAKBJ = KIOGGEECBGB.ID;
		KHLGDCHJJPB.EHHHBEMKGOE.KIOGGEECBGB = KIOGGEECBGB;
		KHLGDCHJJPB.LMIHBNGHEHM.LEOEPDNAONM = CKDIHNEIHKL.ICDOJKMJFKM.Connected;
		BDIDBPAPECJ(KHLGDCHJJPB);
		if (Singleton<PhotonConnectionManager>.instance.isClient && PhotonNetwork.isMasterClient)
		{
			UnityEngine.Debug.Log("Setting master client");
			PhotonNetwork.SetMasterClient(KIOGGEECBGB);
		}
		foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
		{
			item.Value.ReSync();
		}
		if (Singleton<PhotonConnectionManager>.instance.isMasterClient)
		{
			InvokeAfterRealTime(delegate
			{
				SpawningManager.instance.ReSyncUnits();
				Singleton<SpawningManagerDeathMatch>.instance.ReSyncPower();
				Singleton<MapManager>.instance.ResyncShields();
				CAILPIKNLFP();
			}, 0.5f);
		}
		FGHOMGGIEBH();
	}

	private void CAILPIKNLFP()
	{
		FEHCCGEGPLH.RPC("ResyncTimeRPC", PhotonTargets.Others, time);
	}

	[PunRPC]
	protected void ResyncTimeRPC(float KJPFOPAINOK)
	{
		time = KJPFOPAINOK;
	}

	private void FGHOMGGIEBH()
	{
		if (PlayerController.OGMBJPKOPCB.LMIHBNGHEHM.EHFIJJBPEEG == CKDIHNEIHKL.GLFPILGCAPM.LoadingFinished)
		{
			FEHCCGEGPLH.RPC("LoadingFinishedRPC", PhotonTargets.AllBufferedViaServer, PhotonNetwork.player.ID, FIMAKNHKMJN);
		}
		if (PlayerController.OGMBJPKOPCB.LMIHBNGHEHM.AJADIICCLHO)
		{
			FEHCCGEGPLH.RPC("StartCameraAnimationFinishedRPC", PhotonTargets.Others, PlayerController.OGMBJPKOPCB.NAGAHNHAKBJ);
		}
	}

	private void KAIPOAPHOCE(PhotonPlayer KHLGDCHJJPB)
	{
		EIPBEKFMCMI = UnityEngine.Random.Range(0, Math.Min((int)PhotonNetwork.player.customProperties["maxMapId"], (int)KHLGDCHJJPB.customProperties["maxMapId"]));
		if ((int)PhotonNetwork.player.customProperties["isRandomMap"] == 0)
		{
			EIPBEKFMCMI = (int)PhotonNetwork.player.customProperties["mapId"];
		}
		if ((int)KHLGDCHJJPB.customProperties["isRandomMap"] == 0)
		{
			EIPBEKFMCMI = (int)KHLGDCHJJPB.customProperties["mapId"];
		}
		UnityEngine.Debug.Log("Selected new room MAP id is: " + EIPBEKFMCMI);
		OLCFLBEJONG = true;
		PhotonCachedRPC.SendOfflineRPC(FEHCCGEGPLH, "SetMapRPC", PhotonTargets.AllBufferedViaServer, EIPBEKFMCMI);
	}

	[PunRPC]
	protected void SetMapRPC(int NOCEDALFEJM)
	{
		UnityEngine.Debug.Log("Map was set to: " + NOCEDALFEJM);
		EIPBEKFMCMI = NOCEDALFEJM;
		OLCFLBEJONG = true;
	}

	private void BDIDBPAPECJ(PlayerController KHLGDCHJJPB)
	{
		PhotonView[] componentsInChildren = KHLGDCHJJPB.GetComponentsInChildren<PhotonView>(includeInactive: true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			PhotonView photonView = componentsInChildren[i];
			int num = DDOOMBLMGKB[i] % 1000;
			photonView.viewID = 1000 * KHLGDCHJJPB.EHHHBEMKGOE.KIOGGEECBGB.ID + num;
			PhotonNetwork.networkingPeer.ChangePhotonView(photonView);
			photonView.didAwake = true;
		}
	}

	private void KBKKFBFIAML(PhotonPlayer KHLGDCHJJPB)
	{
		UnityEngine.Debug.Log("Clear players");
		GHPGNELIDBM gHPGNELIDBM = GPONIACGBDN(KHLGDCHJJPB);
		if (HMAIEJHCHDE == null)
		{
			HMAIEJHCHDE = UnityEngine.Object.Instantiate(Singleton<ObjectPoolDatabase>.instance.KHLGDCHJJPB);
			HMAIEJHCHDE.transform.parent = Singleton<MainSceneRoot>.instance.transform;
		}
		HMAIEJHCHDE.gameObject.SetActive(value: false);
		if (gHPGNELIDBM == PlayerController.OGMBJPKOPCB.fraction)
		{
			Singleton<GameController>.instance.KKHKAJPNDEC = HMAIEJHCHDE;
		}
		else
		{
			Singleton<GameController>.instance.opponent = HMAIEJHCHDE;
		}
		HMAIEJHCHDE.fraction = gHPGNELIDBM;
		PlayerController.JFGDAKMCJAM[KHLGDCHJJPB.ID] = HMAIEJHCHDE;
		HMAIEJHCHDE.NAGAHNHAKBJ = KHLGDCHJJPB.ID;
		HMAIEJHCHDE.EHHHBEMKGOE = CHEIFOOIMEH.JGEPOKBLAIE(KHLGDCHJJPB, HMAIEJHCHDE.fraction);
		HMAIEJHCHDE.weaponInventory.SetWeapons(HMAIEJHCHDE.EHHHBEMKGOE.GGKGGMNIDMI);
		HMAIEJHCHDE.LMIHBNGHEHM.ILOHAHFIOKM();
		HMAIEJHCHDE.LMIHBNGHEHM.EHFIJJBPEEG = CKDIHNEIHKL.GLFPILGCAPM.Connected;
		Singleton<ArmyPreviewCamera>.instance.RenderToTexture(HMAIEJHCHDE, PNDNEMDPFHC: true, PlayerTexturePool.DFJJOANIJID.Classic);
		BDIDBPAPECJ(HMAIEJHCHDE);
	}

	private void OnPhotonPlayerConnected(PhotonPlayer KHLGDCHJJPB)
	{
		UnityEngine.Debug.Log(string.Format("PLAYER CONNECTED: {0}, name: {1},  userId: {2}, allConnected: {3}" + KHLGDCHJJPB.userId, KHLGDCHJJPB.ID, KHLGDCHJJPB.name, KHLGDCHJJPB.userId, DEGCDEAANEL));
		PhotonPlayer[] playerList = PhotonNetwork.playerList;
		foreach (PhotonPlayer photonPlayer in playerList)
		{
			UnityEngine.Debug.Log("Player: " + photonPlayer.name);
		}
		if (!DEGCDEAANEL)
		{
			UnityEngine.Debug.Log("Joined room" + ((PhotonNetwork.room == null) ? "null" : PhotonNetwork.room.name) + "id: " + PhotonNetwork.player.ID);
			KAIPOAPHOCE(KHLGDCHJJPB);
			HKGOKPMIEEI();
		}
	}

	protected void FLAGMPEFCDM(DisconnectCause FAODDFIDOAC)
	{
		if (FAODDFIDOAC == DisconnectCause.MaxCcuReached)
		{
			Quit();
			MatchManager.matchState = GLFPILGCAPM.GameCancelled;
			ConfirmDialog.ShowAlert(delegate
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
			}, Localization.Localize("ID_CONFIRM_INFO"), Localization.Localize("ID_CONFIRM_MAXCCUREACHED"));
			GuiElementSingle<WarningDialog>.instance.HideDialog();
			Singleton<BeanstalkServerManager>.instance.PhotonIsFull();
			Singleton<DogTagManager>.instance.ResetLocalDogtags();
		}
	}

	protected virtual void OnCustomAuthenticationFailed()
	{
		Quit();
		MatchManager.matchState = GLFPILGCAPM.GameCancelled;
		ConfirmDialog.Hide();
		WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_INFO"), Localization.Localize("ID_WARNING_CONNECTIONERROR"), 0f, delegate
		{
			Singleton<GuiManager>.instance.OFJAGAELHHO();
			GuiElementSingle<WarningDialog>.instance.HOHFMAJJJKN = null;
		}, string.Empty);
		Singleton<DogTagManager>.instance.ResetLocalDogtags();
	}

	protected virtual void OnConnectionFail(DisconnectCause FAODDFIDOAC)
	{
		UnityEngine.Debug.LogError("OnConnectionFailed: " + FAODDFIDOAC);
		UnityEngine.Debug.LogError(DebugSettings.GetNetworkStatsText());
		FLAGMPEFCDM(FAODDFIDOAC);
		PlayerController.OGMBJPKOPCB.LMIHBNGHEHM.LEOEPDNAONM = CKDIHNEIHKL.ICDOJKMJFKM.Disconnected;
		if (DEGCDEAANEL && NNEPKHKGCAA(CKDIHNEIHKL.GLFPILGCAPM.CardsChosen))
		{
			NABOEHCIIPD();
		}
		else if ((MatchManager.beforeMatch || MatchManager.afterMatch) && Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.Menu)
		{
			UnityEngine.Debug.LogError("OnConnectionFailed: 00");
			ConfirmDialog.ShowAlert(delegate
			{
				Singleton<GuiManager>.instance.OFJAGAELHHO();
				LoadingDialog.Hide();
			}, Localization.Localize("ID_CONFIRM_INFO"), Localization.Localize("ID_YOUWEREDISCONNECTED"));
			LoadingDialog.Hide();
			Quit();
		}
		else
		{
			MatchManager.matchState = GLFPILGCAPM.ConnectingToPhoton;
			InvokeAfter(delegate
			{
				PhotonConnectionManager.ConnectToPhotonSafe();
			}, 1.5f);
		}
	}

	protected void KCOPCEKOCHL()
	{
		UnityEngine.Debug.LogError("KCOPCEKOCHL");
		NMOLNGAJPDM();
	}

	protected void NABOEHCIIPD()
	{
		PlayerController.OGMBJPKOPCB.LMIHBNGHEHM.LEOEPDNAONM = CKDIHNEIHKL.ICDOJKMJFKM.Disconnected;
		MatchManager.matchState = MatchManager.matchState;
		MatchManager.KKAGFMGEOBC = Time.realtimeSinceStartup;
		PhotonConnectionManager.TryRecconnectToPhoton();
	}

	protected virtual void PKCOLNDDFPO()
	{
		FOMELELMFPM();
		if (gameIsRunning && (MatchManager.isReconnect || !MatchManager.allPlayersFinishetStartAnimation))
		{
			if (Time.realtimeSinceStartup > MHHFPDGIPGA)
			{
				MHHFPDGIPGA = Time.realtimeSinceStartup + 2f;
				UnityEngine.Debug.Log($"CheckForReconnect: isReconnect: {MatchManager.reconnectState}");
			}
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
					else
					{
						mMainController.MNMLNIMFMJP = GameController.HKGHCIEPGEL.WinByForfeit;
						FinishGame();
						if (PhotonNetwork.room != null)
						{
							PhotonNetwork.room.open = false;
						}
						PhotonConnectionManager.Disconnect();
					}
					GuiElementSingle<ReconnectDialog>.instance.HideDialog();
					UnityEngine.Debug.Log("Hide reconnect dialog");
				}
			}
			else
			{
				GuiElementSingle<ReconnectDialog>.instance.SetWaitTime(-1f);
			}
		}
		KCFDDKOIAOK();
	}

	protected void FOMELELMFPM()
	{
		if (PhotonNetwork.room == null || !PhotonNetwork.connected || PhotonNetwork.room.playerCount != 2 || !MatchManager.isReconnect || !gameIsRunning)
		{
			return;
		}
		PhotonPlayer[] playerList = PhotonNetwork.playerList;
		foreach (PhotonPlayer photonPlayer in playerList)
		{
			PlayerController playerController = PlayerController.FindPlayerWithUserId(photonPlayer.userId);
			if (playerController != null && playerController.LMIHBNGHEHM.LEOEPDNAONM == CKDIHNEIHKL.ICDOJKMJFKM.Disconnected)
			{
				IOJBNJPJFAB(playerController, photonPlayer);
			}
		}
		if (!MatchManager.isReconnect && MatchManager.allPlayersFinishetStartAnimation)
		{
			TimeManager.Resume();
			GuiElementSingle<ReconnectDialog>.instance.HideDialog();
			UnityEngine.Debug.Log("Player reconnected in CheckPlayersReconnectStates");
		}
	}

	protected void KCFDDKOIAOK()
	{
		if ((MatchManager.isReconnect || !MatchManager.allPlayersFinishetStartAnimation) && gameIsRunning && !GuiElementSingle<ReconnectDialog>.instance.isShowed)
		{
			UnityEngine.Debug.Log("Show reconnect dialog");
			if (TimeManager.instance.isPaused)
			{
				UnityEngine.Debug.Log("Show reconnect dialog isPaused");
				GuiElementSingle<PauseScreen>.instance.HideDialog();
			}
			TimeManager.Pause(IEFGEFFDHOK: false);
			Singleton<GuiManager>.instance.ShowDialogInstant(GuiElementSingle<ReconnectDialog>.instance);
			GuiElementSingle<ReconnectDialog>.instance.SetCause(MatchManager.reconnectState, MatchManager.allPlayersFinishetStartAnimation);
		}
		if (!MatchManager.isReconnect && MatchManager.allPlayersFinishetStartAnimation && gameIsRunning && GuiElementSingle<ReconnectDialog>.instance.isShowed)
		{
			TimeManager.Resume();
			GuiElementSingle<ReconnectDialog>.instance.HideDialog();
		}
	}

	private void OnDisconnectedFromPhoton()
	{
		if (!Singleton.applicationIsQuitting && !(Singleton<GameController>.instance.mainController != this))
		{
			UnityEngine.Debug.LogWarning("OnDisconnectedFromPhoton");
		}
	}

	protected void PHEKHJHJODD(int PNAKMCNGGHE)
	{
		UnityEngine.Debug.LogError($"JoinRoomFailedAfterReconnect: {PNAKMCNGGHE} GameIsRunning: {gameIsRunning}");
		if (PNAKMCNGGHE == 32758 || PNAKMCNGGHE == 32764)
		{
			NMOLNGAJPDM();
			return;
		}
		PhotonConnectionManager.Disconnect();
		InvokeAfter(NABOEHCIIPD, 0.5f);
	}

	private void NMOLNGAJPDM()
	{
		if (gameIsRunning)
		{
			Forfeit();
			Disconnect();
			return;
		}
		NFDLBMBMMLE = 0.0;
		foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
		{
			if (item.Value.LMIHBNGHEHM.EIPHAAGCHCP && item.Value.LMIHBNGHEHM.EHFIJJBPEEG == CKDIHNEIHKL.GLFPILGCAPM.GameLoading)
			{
				item.Value.LMIHBNGHEHM.EHFIJJBPEEG = CKDIHNEIHKL.GLFPILGCAPM.LoadingFinished;
			}
		}
	}

	protected virtual void OnPhotonJoinRoomFailed(object[] CJLLLNBEDHO)
	{
		UnityEngine.Debug.LogError($"OnPhotonJoinRoomFailed: {CJLLLNBEDHO[0]}, message {CJLLLNBEDHO[1]}");
		if (MatchManager.isReconnect)
		{
			PHEKHJHJODD(Convert.ToInt32(CJLLLNBEDHO[0]));
			return;
		}
		BIPGLMOPBPP = false;
		if (MatchManager.beforeMatch)
		{
			Quit();
			MatchManager.matchState = GLFPILGCAPM.GameCancelled;
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_GAMEDOESNOTEXIST"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, delegate
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
				LoadingDialog.Hide();
			}, string.Empty);
		}
		else
		{
			UnityEngine.Debug.LogError("Failed to join room during or after match and MatchManager.isReconnect = FALSE");
		}
	}

	private void OnConnectedToPhoton()
	{
		if (!(Singleton<GameController>.instance.mainController != this))
		{
			UnityEngine.Debug.Log("On conencted to photon");
		}
	}

	private void OnJoinedLobby()
	{
		if (!(Singleton<GameController>.instance.mainController != this))
		{
			UnityEngine.Debug.Log("On joined lobby");
		}
	}

	private void OnPhotonCreateRoomFailed()
	{
		if (!(Singleton<GameController>.instance.mainController != this))
		{
			UnityEngine.Debug.LogError("OnPhotonCreateRoomFailed");
		}
	}

	private void OnCreatedRoom()
	{
		if (!(Singleton<GameController>.instance.mainController != this))
		{
			UnityEngine.Debug.Log("OnCreatedRoom");
		}
	}

	private void OnLeftRoom()
	{
		if (!(Singleton<GameController>.instance.mainController != this))
		{
			UnityEngine.Debug.Log("#VAVRO# OnLeftRoom");
		}
	}

	protected void IDLPGDJILPI(CKDIHNEIHKL.GLFPILGCAPM IGBEGIBGLKK)
	{
		foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
		{
			item.Value.LMIHBNGHEHM.EHFIJJBPEEG = IGBEGIBGLKK;
		}
	}

	public override void FinishGame()
	{
		if (gameIsRunning)
		{
			Singleton<MatchManager>.instance.matchTime = (float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DeathMatchTime).FLOATVALUE - time;
			FEHCCGEGPLH.RPC("FinishGameMultiplayerRPC", PhotonTargets.Others, (byte)HHBOLLHONAO(Singleton<GameController>.instance.MNMLNIMFMJP));
			gameIsRunning = false;
			Reset();
			MatchManager.matchState = GLFPILGCAPM.GameFinished;
			IDLPGDJILPI(CKDIHNEIHKL.GLFPILGCAPM.GameFinished);
			mMainController.FinishGame();
		}
	}

	private GameController.HKGHCIEPGEL HHBOLLHONAO(GameController.HKGHCIEPGEL EOEDEMIMFBG)
	{
		switch (EOEDEMIMFBG)
		{
		case GameController.HKGHCIEPGEL.Killed:
			return GameController.HKGHCIEPGEL.Win;
		case GameController.HKGHCIEPGEL.Win:
			return GameController.HKGHCIEPGEL.Killed;
		case GameController.HKGHCIEPGEL.Forfeit:
			return GameController.HKGHCIEPGEL.WinByForfeit;
		case GameController.HKGHCIEPGEL.WinByForfeit:
			return GameController.HKGHCIEPGEL.Forfeit;
		default:
			return EOEDEMIMFBG;
		}
	}

	[PunRPC]
	protected virtual void FinishGameMultiplayerRPC(byte MNMLNIMFMJP)
	{
		if (gameIsRunning)
		{
			UnityEngine.Debug.Log("Finish game network");
			Singleton<MatchManager>.instance.matchTime = (float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DeathMatchTime).FLOATVALUE - time;
			gameIsRunning = false;
			Reset();
			MatchManager.matchState = GLFPILGCAPM.GameFinished;
			IDLPGDJILPI(CKDIHNEIHKL.GLFPILGCAPM.GameFinished);
			Singleton<GameController>.instance.MNMLNIMFMJP = (GameController.HKGHCIEPGEL)MNMLNIMFMJP;
			mMainController.FinishGame();
		}
	}

	public override void LoadingStarted()
	{
		IDLPGDJILPI(CKDIHNEIHKL.GLFPILGCAPM.GameLoading);
		AAIEPHNDCJP.EHHHBEMKGOE = CHEIFOOIMEH.JIIHHODDNLJ();
		LoadingDialog.ShowLoading(Localization.Localize("ID_LOADING"), DMDICGADGCG: false, BGOHKCCLDJP: true);
	}

	public override void StopGame(bool KANLHOCIMID = true)
	{
		Disconnect();
		gameIsRunning = false;
		mMainController.StopGame(KANLHOCIMID);
	}

	public override void FreeLevel()
	{
		HMAIEJHCHDE.gameObject.SetActive(value: false);
		AAIEPHNDCJP.currentPlayerPoint = null;
		HMAIEJHCHDE.currentPlayerPoint = null;
		isInMatch = false;
	}

	[DebuggerHidden]
	public override IEnumerator AquireLevelName()
	{
		LDOJNLPBFFO lDOJNLPBFFO = new LDOJNLPBFFO();
		lDOJNLPBFFO.BJGCPDNMHDH = this;
		return lDOJNLPBFFO;
	}

	protected virtual void CBOFFKGBDJB()
	{
		Singleton<DogTagManager>.instance.UseDogTagLocaly();
	}

	protected virtual void PCIJPCBAOID()
	{
		Singleton<DogTagManager>.instance.PayOneDogTag();
	}

	public override void Quit()
	{
		PlayerController.OGMBJPKOPCB.LMIHBNGHEHM.ILOHAHFIOKM();
		Screen.sleepTimeout = -2;
		if (JPADCGODJBO)
		{
			PCIJPCBAOID();
		}
		Singleton<DogTagManager>.instance.ResetLocalDogtags();
		StopAllCoroutines();
		PhotonConnectionManager.Disconnect();
		Reset();
		isInMatch = false;
	}

	public virtual void PausematchMaking(bool NMCKKMEKOHM)
	{
	}

	public override void Forfeit()
	{
		mMainController.MNMLNIMFMJP = GameController.HKGHCIEPGEL.Forfeit;
		FinishGame();
	}

	public override void PauseGame(bool IEFGEFFDHOK)
	{
		if (!gameIsRunning)
		{
			return;
		}
		if (NABOEPDABMN || IEFGEFFDHOK)
		{
			if (!TimeManager.instance.isPaused)
			{
				DGCCAECHJIN++;
			}
			if (DGCCAECHJIN <= 1)
			{
				TimeManager.Pause(IEFGEFFDHOK);
			}
			else if (IEFGEFFDHOK)
			{
				Forfeit();
				Disconnect();
			}
			else
			{
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<CantPauseDialog>.instance);
			}
		}
		PhotonNetwork.SendOutgoingCommands();
	}

	public override void ResumeGame()
	{
		TimeManager.Resume();
	}

	public override void UnPauseGame()
	{
	}

	public void Disconnect()
	{
		InvokeAfterRealTime(PhotonNetwork.SendOutgoingCommands, 0.1f);
		InvokeAfterRealTime(PhotonConnectionManager.Disconnect, 1f);
	}

	[DebuggerHidden]
	public virtual IEnumerator WaitForServerResponse()
	{
		return new HCHKLFDHPFJ();
	}

	protected virtual void Update()
	{
		if (DKPCCABKHLE && !gameIsRunning)
		{
			float num = MatchManager.IJNECELOAPA - Time.realtimeSinceStartup;
			if (num > 1f && MatchManager.matchState != GLFPILGCAPM.GameLoading)
			{
				LoadingDialog.SetText(MEJMLNDFDBP.ABKAOAODKGC(num));
			}
			LoadingDialog.SetHeader(MatchManager.matchStatusLoading);
			if (PlayerController.OGMBJPKOPCB.LMIHBNGHEHM.EHFIJJBPEEG == CKDIHNEIHKL.GLFPILGCAPM.Rematch)
			{
				LoadingDialog.SetHeader(MatchManager.matchStatusLoading);
				string matchTimeStatus = MatchManager.matchTimeStatus;
				string hOLNKOFHDNK = ((!string.IsNullOrEmpty(matchTimeStatus)) ? matchTimeStatus : MatchManager.matchStatusAfterMatch);
				LoadingDialog.SetText(hOLNKOFHDNK);
			}
		}
		if (!gameIsRunning && LGHMOPMCGDG && MatchManager.matchState == GLFPILGCAPM.GameLoading && GuiElementSingle<LoadingDialog>.instance.isShowed)
		{
			LoadingDialog.SetHeader(Localization.Localize("ID_WAITINGFOROTHERPLAYER"));
			if (MatchManager.isReconnect)
			{
				switch (MatchManager.reconnectState)
				{
				case KAKELCLPDDK.Me:
					LoadingDialog.SetHeader(Localization.Localize("ID_YOUWEREDISCONNECTED"));
					break;
				case KAKELCLPDDK.Other:
					LoadingDialog.SetHeader(Localization.Localize((!Singleton<GameController>.instance.isMission) ? "ID_OPPONENTWASDISCONNECTED" : "ID_FRIENDWASDISCONNECTED"));
					break;
				}
				float hNDGIJBHMOD = MatchManager.reconnectLength - (Time.realtimeSinceStartup - MatchManager.KKAGFMGEOBC);
				LoadingDialog.SetText(MEJMLNDFDBP.ABKAOAODKGC(hNDGIJBHMOD));
			}
		}
		if (PlayerController.OGMBJPKOPCB.LMIHBNGHEHM.EHFIJJBPEEG == CKDIHNEIHKL.GLFPILGCAPM.Rematch && !DEGCDEAANEL && Time.realtimeSinceStartup > MatchManager.BOHOHLAPABE)
		{
			Quit();
			LoadingDialog.Hide();
			MatchManager.matchState = GLFPILGCAPM.GameCancelled;
			bool isCoop = Singleton<GameController>.instance.isCoop;
			WarningDialog.ShowError(Localization.Localize((!isCoop) ? "ID_BATTLECANCELED" : "ID_COOPCANCELED"), Localization.Localize((!isCoop) ? "ID_OPPONENTREFUSEDTHEREMATCH" : "ID_FRIENDREFUSEDREMATCHCOOP"), 0f, delegate
			{
				Singleton<GuiManager>.instance.OFJAGAELHHO();
				LoadingDialog.Hide();
			}, string.Empty);
			PlayerController.OGMBJPKOPCB.LMIHBNGHEHM.ILOHAHFIOKM();
			GuiElementSingle<WarningDialog>.instance.HideDialog();
		}
		if (BIPGLMOPBPP && (MatchManager.invitationState == OOJDIACPBED.Denied || MatchManager.invitationTimeRemaining <= 0f))
		{
			LoadingDialog.Hide();
			BIPGLMOPBPP = false;
			Quit();
			GuiElementSingle<InvitationFailedDialog>.instance.ShowDialog(MatchManager.invitationState);
			MatchManager.matchState = GLFPILGCAPM.GameCancelled;
		}
		BDKLKNMCPPA();
		PKCOLNDDFPO();
	}

	protected virtual void BDKLKNMCPPA()
	{
		if (gameIsRunning && TimeManager.instance.isPaused && TimeManager.pauseTimeLeft <= 0f && !MatchManager.isReconnect)
		{
			if (TimeManager.instance.pauseStatus == TimeManager.HICMJEBLEDA.PausedRemote)
			{
				ResumeGame();
			}
			if (TimeManager.instance.pauseStatus == TimeManager.HICMJEBLEDA.PausedRemoteFocusLost)
			{
				mMainController.MNMLNIMFMJP = GameController.HKGHCIEPGEL.WinByForfeit;
				FinishGame();
			}
		}
	}

	[CompilerGenerated]
	private static void CAGICLHPJLE()
	{
		Singleton<GuiManager>.instance.OFJAGAELHHO();
		GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
		LoadingDialog.Hide();
	}

	[CompilerGenerated]
	private static void PFOPECMLKBG(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		Singleton<GuiManager>.instance.OFJAGAELHHO();
		GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
		LoadingDialog.Hide();
	}

	[CompilerGenerated]
	private void JBHLFNFHDHG()
	{
		SpawningManager.instance.ReSyncUnits();
		Singleton<SpawningManagerDeathMatch>.instance.ReSyncPower();
		Singleton<MapManager>.instance.ResyncShields();
		CAILPIKNLFP();
	}

	[CompilerGenerated]
	private static void JFGCKOCCCFC(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
	}

	[CompilerGenerated]
	private static void MICMKMEKOJH()
	{
		Singleton<GuiManager>.instance.OFJAGAELHHO();
		GuiElementSingle<WarningDialog>.instance.HOHFMAJJJKN = null;
	}

	[CompilerGenerated]
	private static void GDEMPAHBBIK(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		Singleton<GuiManager>.instance.OFJAGAELHHO();
		LoadingDialog.Hide();
	}

	[CompilerGenerated]
	private static void PEKJDGNAPBI()
	{
		PhotonConnectionManager.ConnectToPhotonSafe();
	}

	[CompilerGenerated]
	private static void LPIELFCMGJG()
	{
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
		LoadingDialog.Hide();
	}

	[CompilerGenerated]
	private static void MFAHHMBADFB()
	{
		Singleton<GuiManager>.instance.OFJAGAELHHO();
		LoadingDialog.Hide();
	}
}
