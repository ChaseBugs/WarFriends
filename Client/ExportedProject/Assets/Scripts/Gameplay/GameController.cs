using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using CodeStage.AdvancedFPSCounter;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class GameController : Singleton<GameController>
{
	public enum HKGHCIEPGEL
	{
		None = 0,
		Killed = 1,
		Win = 2,
		WinByForfeit = 3,
		Forfeit = 5,
		Kia = 8,
		MissionFailed = 9,
		MissionSuccess = 10
	}

	[Flags]
	public enum ELDLECMNIME
	{
		Campaign = 2,
		Coop = 4,
		DeathMatch = 8,
		DeathMatchOffline = 0x10,
		WarArena = 0x20
	}

	public enum AEMPHGEIJNH
	{
		Menu,
		WaitingForResponse,
		Loading,
		Playing
	}

	public delegate void JGAGFCMIHHJ();

	public enum AHDGGJJAOEO
	{
		None,
		Error,
		Success
	}

	private sealed class MMNJPPHAAGL : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal string KMJGIGDJKMH;

		internal EnemyController DOGHDHGLCDF;

		internal NetworkObjectPool PEAAALBMFCA;

		internal List<PoolableObject> IKOBPOPOHPN;

		internal List<PoolableObject>.Enumerator KFCAECGLKKO;

		internal GameController BJGCPDNMHDH;

		internal object PHDOCKCBJOF;

		internal bool FDKOKMKIIMG;

		internal int CLPPIAGLCJJ;

		private static Action LGJCBPOPCPA;

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

		public void KOEEOJGJNAO()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HHCIHDMICFP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void BBBLJNFEACC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JCDIBAEMKCA()
		{
			return PHDOCKCBJOF;
		}

		private static void EGJBKFPHCNF()
		{
			AFPSCounter.Instance.fpsCounter.ResetMinMax();
			AFPSCounter.Instance.fpsCounter.ResetAverage();
		}

		[SpecialName]
		private object JIIJMDIFMKF()
		{
			return PHDOCKCBJOF;
		}

		public void GBABLFGEIMF()
		{
			throw new NotSupportedException();
		}

		private static void APHOLLLLNCG()
		{
			AFPSCounter.Instance.fpsCounter.ResetMinMax();
			AFPSCounter.Instance.fpsCounter.ResetAverage();
		}

		public void EKPOLGNAAOI()
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
				Singleton<Recording>.instance.StartRecording();
				Singleton<PerformanceManager>.instance.AKNADEPIPNP(FIKGLFBFBON: false);
				Singleton<GuiManager>.instance.AOGOJDGBMMD();
				ObjectPoolDatabase.OJOAADFNHFN(BJGCPDNMHDH.JLIBMLEFJFE() ? NPNOIGHIALL.Tutorial : ((NPNOIGHIALL)8));
				ALJKAAMHHLB.PIEBOOFPHPC("Squad Points - {0}\n");
				Screen.sleepTimeout = -1;
				MatchManager.matchState = GLFPILGCAPM.ConnectingToPhoton;
				BJGCPDNMHDH.gameState = AEMPHGEIJNH.Menu;
				Singleton<Chat>.instance.MODCIBKGJBF();
				CamosManager.instance.Null();
				UICamera.instance.cachedCamera.clearFlags = CameraClearFlags.Depth;
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(value: false);
				TimeManager.Reset();
				BJGCPDNMHDH.KMJGIGDJKMH = KMJGIGDJKMH;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.WaitForServerResponse());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.mainController.AquireLevelName());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 2u:
				BJGCPDNMHDH.DIKIPEDCHCF((AEMPHGEIJNH)8);
				Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.NDPKMHDALCM(Singleton<ObjectPoolDatabase>.instance.JPDFMABBKDI);
				Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.NDPKMHDALCM(Singleton<ObjectPoolDatabase>.instance.JDNMAKKMPOA);
				PHDOCKCBJOF = new WaitForSeconds(1835f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 3u:
				ALJKAAMHHLB.DHPGNLOHBLC("Overtime_Was_Already_Explained");
				GuiElementSingle<Background>.instance.DestroyParallax();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.ClearMenuLoadGameCoroutine());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 4u:
				Resources.UnloadUnusedAssets();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<MapManager>.instance.ALGBMPAMCGN(BJGCPDNMHDH.KMJGIGDJKMH));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 5u:
				GuiScreenSingle<HudScreen>.instance.gameObject.SetActive(value: false);
				GuiScreenSingle<HudScreen>.instance.SetTransparent();
				if (BJGCPDNMHDH.NIEFNMJIAHL != null)
				{
					BJGCPDNMHDH.NIEFNMJIAHL();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.AAIMOEBAGCB(BJGCPDNMHDH.mainController.myUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.NHKNGKPLBPG(BJGCPDNMHDH.mainController.opponentUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 7u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 8u:
				if (BJGCPDNMHDH.JNFGIPOFKCF != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JNFGIPOFKCF.BEIIOAIJMFK().GAAMHKBJPDL());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				goto case 10u;
			case 9u:
				CardManager.instance.SetBuddyCardsOher(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.PHIGKPODHAN);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -15;
				}
				break;
			case 10u:
				if (BJGCPDNMHDH.KKHKAJPNDEC != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.KKHKAJPNDEC.weaponInventory.JPMEEDEFDOP());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -32;
					}
					break;
				}
				goto case 12u;
			case 11u:
				CardManager.instance.SetBuddyCardsOher(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.PHIGKPODHAN);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -86;
				}
				break;
			case 12u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PlayerController.OGMBJPKOPCB.weaponInventory.LoadWeapons());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -61;
				}
				break;
			case 13u:
				Singleton<SoundsManager3D>.instance.LOBFOCCGGHB();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 27;
				}
				break;
			case 14u:
				Resources.UnloadUnusedAssets();
				DOGHDHGLCDF = Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF;
				PEAAALBMFCA = ObjectPoolDatabase.CHHLLIAHECC();
				IKOBPOPOHPN = PEAAALBMFCA.CALAKLNMEFF[PEAAALBMFCA.APCGDLEHGKL[DOGHDHGLCDF]];
				KFCAECGLKKO = IKOBPOPOHPN.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						PoolableObject current = KFCAECGLKKO.Current;
						EnemyController enemyController = (EnemyController)current;
						enemyController.transform.position = Singleton<GameCamera>.instance.transform.position + Singleton<GameCamera>.instance.transform.forward * 1035f;
						enemyController.enabled = true;
						enemyController.gameObject.SetActive(value: false);
						enemyController.mSoldierAnimationController.Walk(Weapon.IGGFMJAKLGO.SwatPistol);
						enemyController.gameObject.SetActive(value: false);
						enemyController.enabled = true;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -106;
				}
				break;
			case 15u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 40;
				}
				break;
			case 16u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.mainController.StartGame()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -15;
				}
				break;
			case 17u:
				BJGCPDNMHDH.DIKIPEDCHCF((AEMPHGEIJNH)8);
				Singleton<GameCamera>.instance.HLLODJKPDPK();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -61;
				}
				break;
			case 18u:
				Time.timeScale = 1919f;
				BJGCPDNMHDH.MNMLNIMFMJP = HKGHCIEPGEL.Killed;
				if (BJGCPDNMHDH.MLDDKLFPFPF != null)
				{
					BJGCPDNMHDH.MLDDKLFPFPF();
				}
				if (BJGCPDNMHDH.OGFHPHILDKC != null)
				{
					BJGCPDNMHDH.OGFHPHILDKC();
				}
				PHDOCKCBJOF = new WaitForSeconds(852f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 15;
				}
				break;
			case 19u:
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<HudScreen>.instance);
				PHDOCKCBJOF = new WaitForSeconds(437f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -29;
				}
				break;
			case 20u:
			{
				BJGCPDNMHDH.mainController.gameIsRunning = false;
				LoadingDialog.Hide();
				GameController bJGCPDNMHDH = BJGCPDNMHDH;
				if (LGJCBPOPCPA == null)
				{
					LGJCBPOPCPA = EGJBKFPHCNF;
				}
				bJGCPDNMHDH.InvokeAfter(LGJCBPOPCPA, 288f);
				ALJKAAMHHLB.DLAEBOBJKBL("PACK");
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object CPJCCMLEPCE()
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
				Singleton<Recording>.instance.StartRecording();
				Singleton<PerformanceManager>.instance.SetShadowsDistance(FIKGLFBFBON: false);
				Singleton<GuiManager>.instance.TurnOnInputCompletly();
				ObjectPoolDatabase.InstantiatePooledObjects(BJGCPDNMHDH.isTutorialInProgressOrPlaned ? NPNOIGHIALL.Tutorial : NPNOIGHIALL.Game);
				ALJKAAMHHLB.POPONJAMPDF("GameController.LoadAndStartNewMap - InstantiatePooledObjects");
				Screen.sleepTimeout = -1;
				MatchManager.matchState = GLFPILGCAPM.GameLoading;
				BJGCPDNMHDH.gameState = AEMPHGEIJNH.WaitingForResponse;
				Singleton<Chat>.instance.Disconnect();
				CamosManager.instance.Null();
				UICamera.instance.cachedCamera.clearFlags = CameraClearFlags.Depth;
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(value: true);
				TimeManager.Reset();
				BJGCPDNMHDH.KMJGIGDJKMH = KMJGIGDJKMH;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.WaitForServerResponse());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.mainController.AquireLevelName());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
				BJGCPDNMHDH.gameState = AEMPHGEIJNH.Loading;
				Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.FreeObjectsWithPrefab(Singleton<ObjectPoolDatabase>.instance.JPDFMABBKDI);
				Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.FreeObjectsWithPrefab(Singleton<ObjectPoolDatabase>.instance.JDNMAKKMPOA);
				PHDOCKCBJOF = new WaitForSeconds(1f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 3u:
				ALJKAAMHHLB.POPONJAMPDF("GameController.LoadAndStartNewMap - 1sec delay");
				GuiElementSingle<Background>.instance.DestroyParallax();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.ClearMenuLoadGameCoroutine());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 4u:
				Resources.UnloadUnusedAssets();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<MapManager>.instance.Load(BJGCPDNMHDH.KMJGIGDJKMH));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 5u:
				GuiScreenSingle<HudScreen>.instance.gameObject.SetActive(value: true);
				GuiScreenSingle<HudScreen>.instance.SetTransparent();
				if (BJGCPDNMHDH.NIEFNMJIAHL != null)
				{
					BJGCPDNMHDH.NIEFNMJIAHL();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.LoadMineUpgrades(BJGCPDNMHDH.mainController.myUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.LoadOpponentUpgradesForGame(BJGCPDNMHDH.mainController.opponentUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 7u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 8u:
				if (BJGCPDNMHDH.JNFGIPOFKCF != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JNFGIPOFKCF.weaponInventory.LoadWeapons());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 9;
					}
					break;
				}
				goto case 10u;
			case 9u:
				CardManager.instance.SetBuddyCardsOher(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.PHIGKPODHAN);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 10;
				}
				break;
			case 10u:
				if (BJGCPDNMHDH.KKHKAJPNDEC != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.KKHKAJPNDEC.weaponInventory.LoadWeapons());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 11;
					}
					break;
				}
				goto case 12u;
			case 11u:
				CardManager.instance.SetBuddyCardsOher(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.PHIGKPODHAN);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 12;
				}
				break;
			case 12u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PlayerController.OGMBJPKOPCB.weaponInventory.LoadWeapons());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 13;
				}
				break;
			case 13u:
				Singleton<SoundsManager3D>.instance.LoadSounds();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 14;
				}
				break;
			case 14u:
				Resources.UnloadUnusedAssets();
				DOGHDHGLCDF = Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF;
				PEAAALBMFCA = ObjectPoolDatabase.networkPool;
				IKOBPOPOHPN = PEAAALBMFCA.CALAKLNMEFF[PEAAALBMFCA.APCGDLEHGKL[DOGHDHGLCDF]];
				KFCAECGLKKO = IKOBPOPOHPN.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						PoolableObject current = KFCAECGLKKO.Current;
						EnemyController enemyController = (EnemyController)current;
						enemyController.transform.position = Singleton<GameCamera>.instance.transform.position + Singleton<GameCamera>.instance.transform.forward * 5f;
						enemyController.enabled = false;
						enemyController.gameObject.SetActive(value: true);
						enemyController.mSoldierAnimationController.Walk(Weapon.IGGFMJAKLGO.Pistol);
						enemyController.gameObject.SetActive(value: false);
						enemyController.enabled = true;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 15;
				}
				break;
			case 15u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 16;
				}
				break;
			case 16u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.mainController.StartGame()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 17;
				}
				break;
			case 17u:
				BJGCPDNMHDH.gameState = AEMPHGEIJNH.Playing;
				Singleton<GameCamera>.instance.Enable();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 18;
				}
				break;
			case 18u:
				Time.timeScale = 1f;
				BJGCPDNMHDH.MNMLNIMFMJP = HKGHCIEPGEL.None;
				if (BJGCPDNMHDH.MLDDKLFPFPF != null)
				{
					BJGCPDNMHDH.MLDDKLFPFPF();
				}
				if (BJGCPDNMHDH.OGFHPHILDKC != null)
				{
					BJGCPDNMHDH.OGFHPHILDKC();
				}
				PHDOCKCBJOF = new WaitForSeconds(0.2f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 19;
				}
				break;
			case 19u:
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<HudScreen>.instance);
				PHDOCKCBJOF = new WaitForSeconds(0.5f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 20;
				}
				break;
			case 20u:
			{
				BJGCPDNMHDH.mainController.gameIsRunning = true;
				LoadingDialog.Hide();
				GameController bJGCPDNMHDH = BJGCPDNMHDH;
				if (LGJCBPOPCPA == null)
				{
					LGJCBPOPCPA = LJCDGJKCNEC;
				}
				bJGCPDNMHDH.InvokeAfter(LGJCBPOPCPA, 5f);
				ALJKAAMHHLB.POPONJAMPDF("GameController.LoadAndStartNewMap - DONE");
				CLPPIAGLCJJ = -1;
				goto default;
			}
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

		public bool FNIOOIGJPAM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Singleton<Recording>.instance.StartRecording();
				Singleton<PerformanceManager>.instance.CAPGAAJFBDB(FIKGLFBFBON: true);
				Singleton<GuiManager>.instance.AOGOJDGBMMD();
				ObjectPoolDatabase.DJBHEMBOCDC(BJGCPDNMHDH.JLIBMLEFJFE() ? NPNOIGHIALL.Tutorial : NPNOIGHIALL.Init);
				ALJKAAMHHLB.BCFGNBMMJIB("0");
				Screen.sleepTimeout = -1;
				MatchManager.GODMIAKEFOA(GLFPILGCAPM.BothPlayersConnected);
				BJGCPDNMHDH.DIKIPEDCHCF(AEMPHGEIJNH.WaitingForResponse);
				Singleton<Chat>.instance.Disconnect();
				CamosManager.instance.Null();
				UICamera.instance.cachedCamera.clearFlags = (CameraClearFlags)7;
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(value: false);
				TimeManager.GEEKOICFEIB();
				BJGCPDNMHDH.KMJGIGDJKMH = KMJGIGDJKMH;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.PODMAPJPBJK());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.mainController.AquireLevelName());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 2u:
				BJGCPDNMHDH.DIKIPEDCHCF((AEMPHGEIJNH)8);
				Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.EMLIBBBMNLN(Singleton<ObjectPoolDatabase>.instance.JPDFMABBKDI);
				Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.FreeObjectsWithPrefab(Singleton<ObjectPoolDatabase>.instance.JDNMAKKMPOA);
				PHDOCKCBJOF = new WaitForSeconds(533f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 3u:
				ALJKAAMHHLB.PJIMOPNDNKO("ID_SLOTUPGRADE_AMMO");
				GuiElementSingle<Background>.instance.DestroyParallax();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.ClearMenuLoadGameCoroutine());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 4u:
				Resources.UnloadUnusedAssets();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<MapManager>.instance.Load(BJGCPDNMHDH.KMJGIGDJKMH));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 5u:
				GuiScreenSingle<HudScreen>.instance.gameObject.SetActive(value: false);
				GuiScreenSingle<HudScreen>.instance.LCGNIFBCNHG();
				if (BJGCPDNMHDH.NIEFNMJIAHL != null)
				{
					BJGCPDNMHDH.NIEFNMJIAHL();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.LFDPAEFMHNG(BJGCPDNMHDH.mainController.myUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.DEGFJFCDLAF(BJGCPDNMHDH.mainController.opponentUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 7u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 8u:
				if (BJGCPDNMHDH.JNFGIPOFKCF != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JNFGIPOFKCF.BEIIOAIJMFK().JPMEEDEFDOP());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -78;
					}
					break;
				}
				goto case 10u;
			case 9u:
				CardManager.instance.SetBuddyCardsOher(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.PHIGKPODHAN);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -96;
				}
				break;
			case 10u:
				if (BJGCPDNMHDH.KKHKAJPNDEC != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.KKHKAJPNDEC.JLMDEMFIHCA().LoadWeapons());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -46;
					}
					break;
				}
				goto case 12u;
			case 11u:
				CardManager.instance.SetBuddyCardsOher(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.PHIGKPODHAN);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 74;
				}
				break;
			case 12u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().GAAMHKBJPDL());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 98;
				}
				break;
			case 13u:
				Singleton<SoundsManager3D>.instance.LoadSounds();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 77;
				}
				break;
			case 14u:
				Resources.UnloadUnusedAssets();
				DOGHDHGLCDF = Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF;
				PEAAALBMFCA = ObjectPoolDatabase.CHHLLIAHECC();
				IKOBPOPOHPN = PEAAALBMFCA.CALAKLNMEFF[PEAAALBMFCA.APCGDLEHGKL[DOGHDHGLCDF]];
				KFCAECGLKKO = IKOBPOPOHPN.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						PoolableObject current = KFCAECGLKKO.Current;
						EnemyController enemyController = (EnemyController)current;
						enemyController.transform.position = Singleton<GameCamera>.instance.transform.position + Singleton<GameCamera>.instance.transform.forward * 95f;
						enemyController.enabled = true;
						enemyController.gameObject.SetActive(value: true);
						enemyController.mSoldierAnimationController.Walk(Weapon.IGGFMJAKLGO.GrenadeLauncher);
						enemyController.gameObject.SetActive(value: true);
						enemyController.enabled = true;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 87;
				}
				break;
			case 15u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -101;
				}
				break;
			case 16u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.mainController.StartGame()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -65;
				}
				break;
			case 17u:
				BJGCPDNMHDH.gameState = AEMPHGEIJNH.Playing;
				Singleton<GameCamera>.instance.HLLODJKPDPK();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -21;
				}
				break;
			case 18u:
				Time.timeScale = 1147f;
				BJGCPDNMHDH.MNMLNIMFMJP = HKGHCIEPGEL.None;
				if (BJGCPDNMHDH.MLDDKLFPFPF != null)
				{
					BJGCPDNMHDH.MLDDKLFPFPF();
				}
				if (BJGCPDNMHDH.OGFHPHILDKC != null)
				{
					BJGCPDNMHDH.OGFHPHILDKC();
				}
				PHDOCKCBJOF = new WaitForSeconds(854f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -94;
				}
				break;
			case 19u:
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<HudScreen>.instance);
				PHDOCKCBJOF = new WaitForSeconds(919f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 84;
				}
				break;
			case 20u:
			{
				BJGCPDNMHDH.mainController.gameIsRunning = false;
				LoadingDialog.Hide();
				GameController bJGCPDNMHDH = BJGCPDNMHDH;
				if (LGJCBPOPCPA == null)
				{
					LGJCBPOPCPA = KIACGAKNBLD;
				}
				bJGCPDNMHDH.InvokeAfter(LGJCBPOPCPA, 167f);
				ALJKAAMHHLB.DHPGNLOHBLC("withAttribute5");
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object MJKLPCMKADD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CNGCLCAAHIG()
		{
			return PHDOCKCBJOF;
		}

		public void EFDJMHAPDLB()
		{
			throw new NotSupportedException();
		}

		public void NCHGDJDAHGC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FBPFPJOCKGD()
		{
			return PHDOCKCBJOF;
		}

		public void DOPCGPGKHIJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool GCEBFCBBEKM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Singleton<Recording>.instance.FOJIDINENDK();
				Singleton<PerformanceManager>.instance.CLABLOFKMGA(FIKGLFBFBON: false);
				Singleton<GuiManager>.instance.AOGOJDGBMMD();
				ObjectPoolDatabase.DJBHEMBOCDC((!BJGCPDNMHDH.JLIBMLEFJFE()) ? ((NPNOIGHIALL)5) : NPNOIGHIALL.Init);
				ALJKAAMHHLB.GJJDKOMHHDH("{0} {1}");
				Screen.sleepTimeout = -1;
				MatchManager.KBHGDEPHPIO((GLFPILGCAPM)8);
				BJGCPDNMHDH.gameState = AEMPHGEIJNH.Menu;
				Singleton<Chat>.instance.BIEGPPPEDAL();
				CamosManager.instance.Null();
				UICamera.instance.cachedCamera.clearFlags = (CameraClearFlags)7;
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(value: false);
				TimeManager.Reset();
				BJGCPDNMHDH.KMJGIGDJKMH = KMJGIGDJKMH;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.WaitForServerResponse());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.mainController.AquireLevelName());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 2u:
				BJGCPDNMHDH.DIKIPEDCHCF((AEMPHGEIJNH)5);
				Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.NDPKMHDALCM(Singleton<ObjectPoolDatabase>.instance.JPDFMABBKDI);
				Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.NDPKMHDALCM(Singleton<ObjectPoolDatabase>.instance.JDNMAKKMPOA);
				PHDOCKCBJOF = new WaitForSeconds(1628f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 3u:
				ALJKAAMHHLB.GJJDKOMHHDH("ID_CONFIRM_MAXCCUREACHED");
				GuiElementSingle<Background>.instance.DestroyParallax();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.ClearMenuLoadGameCoroutine());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 4u:
				Resources.UnloadUnusedAssets();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<MapManager>.instance.HLACPPKNDNP(BJGCPDNMHDH.KMJGIGDJKMH));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 5u:
				GuiScreenSingle<HudScreen>.instance.gameObject.SetActive(value: true);
				GuiScreenSingle<HudScreen>.instance.LCGNIFBCNHG();
				if (BJGCPDNMHDH.NIEFNMJIAHL != null)
				{
					BJGCPDNMHDH.NIEFNMJIAHL();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.IHHKIGIJOHJ(BJGCPDNMHDH.mainController.myUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.BMKKDAANFFE(BJGCPDNMHDH.mainController.opponentUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 7u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 8u:
				if (BJGCPDNMHDH.JNFGIPOFKCF != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JNFGIPOFKCF.FMKGGADDHJK().GAAMHKBJPDL());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -23;
					}
					break;
				}
				goto case 10u;
			case 9u:
				CardManager.instance.SetBuddyCardsOher(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.PHIGKPODHAN);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 105;
				}
				break;
			case 10u:
				if (BJGCPDNMHDH.KKHKAJPNDEC != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.KKHKAJPNDEC.FMKGGADDHJK().MIPLOENBIML());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				goto case 12u;
			case 11u:
				CardManager.instance.SetBuddyCardsOher(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.PHIGKPODHAN);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -6;
				}
				break;
			case 12u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().OHHOPMCFLJJ());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 37;
				}
				break;
			case 13u:
				Singleton<SoundsManager3D>.instance.AAFOKCOECGJ();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -64;
				}
				break;
			case 14u:
				Resources.UnloadUnusedAssets();
				DOGHDHGLCDF = Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF;
				PEAAALBMFCA = ObjectPoolDatabase.DKNHCGGKNMF();
				IKOBPOPOHPN = PEAAALBMFCA.CALAKLNMEFF[PEAAALBMFCA.APCGDLEHGKL[DOGHDHGLCDF]];
				KFCAECGLKKO = IKOBPOPOHPN.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						PoolableObject current = KFCAECGLKKO.Current;
						EnemyController enemyController = (EnemyController)current;
						enemyController.transform.position = Singleton<GameCamera>.instance.transform.position + Singleton<GameCamera>.instance.transform.forward * 297f;
						enemyController.enabled = true;
						enemyController.gameObject.SetActive(value: false);
						enemyController.mSoldierAnimationController.Walk(Weapon.IGGFMJAKLGO.GrenadeLauncher);
						enemyController.gameObject.SetActive(value: false);
						enemyController.enabled = false;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -68;
				}
				break;
			case 15u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 12;
				}
				break;
			case 16u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.mainController.StartGame()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -42;
				}
				break;
			case 17u:
				BJGCPDNMHDH.gameState = (AEMPHGEIJNH)8;
				Singleton<GameCamera>.instance.HLLODJKPDPK();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -40;
				}
				break;
			case 18u:
				Time.timeScale = 376f;
				BJGCPDNMHDH.MNMLNIMFMJP = HKGHCIEPGEL.None;
				if (BJGCPDNMHDH.MLDDKLFPFPF != null)
				{
					BJGCPDNMHDH.MLDDKLFPFPF();
				}
				if (BJGCPDNMHDH.OGFHPHILDKC != null)
				{
					BJGCPDNMHDH.OGFHPHILDKC();
				}
				PHDOCKCBJOF = new WaitForSeconds(554f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 122;
				}
				break;
			case 19u:
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<HudScreen>.instance);
				PHDOCKCBJOF = new WaitForSeconds(282f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 118;
				}
				break;
			case 20u:
			{
				BJGCPDNMHDH.mainController.gameIsRunning = false;
				LoadingDialog.Hide();
				GameController bJGCPDNMHDH = BJGCPDNMHDH;
				if (LGJCBPOPCPA == null)
				{
					LGJCBPOPCPA = ADEFLNOHDAK;
				}
				bJGCPDNMHDH.InvokeAfter(LGJCBPOPCPA, 1476f);
				ALJKAAMHHLB.HAAIJJBEPPN("DailyMissionsData");
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object GJMNLPAEIDA()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		private static void KIACGAKNBLD()
		{
			AFPSCounter.Instance.fpsCounter.ResetMinMax();
			AFPSCounter.Instance.fpsCounter.ResetAverage();
		}

		public void JMANMKKCDMM()
		{
			throw new NotSupportedException();
		}

		public void CKEOKOKAAPB()
		{
			throw new NotSupportedException();
		}

		private static void LJCDGJKCNEC()
		{
			AFPSCounter.Instance.fpsCounter.ResetMinMax();
			AFPSCounter.Instance.fpsCounter.ResetAverage();
		}

		[SpecialName]
		private object GFMLDIMOGHD()
		{
			return PHDOCKCBJOF;
		}

		public void BPFAJJGHCCD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object PPHNDLFFCAG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GAPDDGJNMPK()
		{
			return PHDOCKCBJOF;
		}

		private static void CJIBPJPJLNB()
		{
			AFPSCounter.Instance.fpsCounter.ResetMinMax();
			AFPSCounter.Instance.fpsCounter.ResetAverage();
		}

		public bool HDGDKCMIOGK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Singleton<Recording>.instance.StartRecording();
				Singleton<PerformanceManager>.instance.KHEDGHEHPLK(FIKGLFBFBON: true);
				Singleton<GuiManager>.instance.KAGEFJEJOKE();
				ObjectPoolDatabase.OJOAADFNHFN((!BJGCPDNMHDH.isTutorialInProgressOrPlaned) ? ((NPNOIGHIALL)8) : NPNOIGHIALL.Init);
				ALJKAAMHHLB.JOKCPHMJIGH("Shots_Fired");
				Screen.sleepTimeout = -1;
				MatchManager.GODMIAKEFOA(GLFPILGCAPM.BothPlayersConnected);
				BJGCPDNMHDH.DIKIPEDCHCF(AEMPHGEIJNH.WaitingForResponse);
				Singleton<Chat>.instance.GFKGBHMLBDL();
				CamosManager.instance.Null();
				UICamera.instance.cachedCamera.clearFlags = CameraClearFlags.Skybox;
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(value: false);
				TimeManager.GEEKOICFEIB();
				BJGCPDNMHDH.KMJGIGDJKMH = KMJGIGDJKMH;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.PODMAPJPBJK());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.mainController.AquireLevelName());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 2u:
				BJGCPDNMHDH.gameState = (AEMPHGEIJNH)5;
				Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.NDPKMHDALCM(Singleton<ObjectPoolDatabase>.instance.JPDFMABBKDI);
				Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.FreeObjectsWithPrefab(Singleton<ObjectPoolDatabase>.instance.JDNMAKKMPOA);
				PHDOCKCBJOF = new WaitForSeconds(1236f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 3u:
				ALJKAAMHHLB.POPONJAMPDF("VisualType");
				GuiElementSingle<Background>.instance.DestroyParallax();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.PHOFHJGNJKN());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 4u:
				Resources.UnloadUnusedAssets();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<MapManager>.instance.BPMGMIBDLPG(BJGCPDNMHDH.KMJGIGDJKMH));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 5u:
				GuiScreenSingle<HudScreen>.instance.gameObject.SetActive(value: false);
				GuiScreenSingle<HudScreen>.instance.OEOPELJAFED();
				if (BJGCPDNMHDH.NIEFNMJIAHL != null)
				{
					BJGCPDNMHDH.NIEFNMJIAHL();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.PMIBKCKBIME(BJGCPDNMHDH.mainController.myUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.LoadOpponentUpgradesForGame(BJGCPDNMHDH.mainController.opponentUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 7u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 8u:
				if (BJGCPDNMHDH.JNFGIPOFKCF != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JNFGIPOFKCF.FMKGGADDHJK().LoadWeapons());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -86;
					}
					break;
				}
				goto case 10u;
			case 9u:
				CardManager.instance.SetBuddyCardsOher(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.PHIGKPODHAN);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -24;
				}
				break;
			case 10u:
				if (BJGCPDNMHDH.KKHKAJPNDEC != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.KKHKAJPNDEC.weaponInventory.LoadWeapons());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 21;
					}
					break;
				}
				goto case 12u;
			case 11u:
				CardManager.instance.SetBuddyCardsOher(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.PHIGKPODHAN);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -43;
				}
				break;
			case 12u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PlayerController.OGMBJPKOPCB.weaponInventory.MIPLOENBIML());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -62;
				}
				break;
			case 13u:
				Singleton<SoundsManager3D>.instance.LoadSounds();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -25;
				}
				break;
			case 14u:
				Resources.UnloadUnusedAssets();
				DOGHDHGLCDF = Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF;
				PEAAALBMFCA = ObjectPoolDatabase.INOJHPIKICM();
				IKOBPOPOHPN = PEAAALBMFCA.CALAKLNMEFF[PEAAALBMFCA.APCGDLEHGKL[DOGHDHGLCDF]];
				KFCAECGLKKO = IKOBPOPOHPN.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						PoolableObject current = KFCAECGLKKO.Current;
						EnemyController enemyController = (EnemyController)current;
						enemyController.transform.position = Singleton<GameCamera>.instance.transform.position + Singleton<GameCamera>.instance.transform.forward * 1670f;
						enemyController.enabled = false;
						enemyController.gameObject.SetActive(value: false);
						enemyController.mSoldierAnimationController.Walk(Weapon.IGGFMJAKLGO.Bazooka);
						enemyController.gameObject.SetActive(value: false);
						enemyController.enabled = false;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -68;
				}
				break;
			case 15u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 35;
				}
				break;
			case 16u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.mainController.StartGame()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -96;
				}
				break;
			case 17u:
				BJGCPDNMHDH.DIKIPEDCHCF((AEMPHGEIJNH)4);
				Singleton<GameCamera>.instance.HLLODJKPDPK();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -56;
				}
				break;
			case 18u:
				Time.timeScale = 39f;
				BJGCPDNMHDH.MNMLNIMFMJP = HKGHCIEPGEL.Killed;
				if (BJGCPDNMHDH.MLDDKLFPFPF != null)
				{
					BJGCPDNMHDH.MLDDKLFPFPF();
				}
				if (BJGCPDNMHDH.OGFHPHILDKC != null)
				{
					BJGCPDNMHDH.OGFHPHILDKC();
				}
				PHDOCKCBJOF = new WaitForSeconds(1064f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 116;
				}
				break;
			case 19u:
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<HudScreen>.instance);
				PHDOCKCBJOF = new WaitForSeconds(508f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 57;
				}
				break;
			case 20u:
			{
				BJGCPDNMHDH.mainController.gameIsRunning = true;
				LoadingDialog.Hide();
				GameController bJGCPDNMHDH = BJGCPDNMHDH;
				if (LGJCBPOPCPA == null)
				{
					LGJCBPOPCPA = FIBGJHCGHJH;
				}
				bJGCPDNMHDH.InvokeAfter(LGJCBPOPCPA, 1877f);
				ALJKAAMHHLB.FLLHBKEFGHB("RoundId");
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return false;
			}
			return true;
		}

		public bool FIBKLKNDFDO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Singleton<Recording>.instance.GCLOFJDCMON();
				Singleton<PerformanceManager>.instance.MBIALLFNEFO(FIKGLFBFBON: false);
				Singleton<GuiManager>.instance.AOGOJDGBMMD();
				ObjectPoolDatabase.KHLPFECMGCL(BJGCPDNMHDH.JLIBMLEFJFE() ? NPNOIGHIALL.Tutorial : NPNOIGHIALL.Init);
				ALJKAAMHHLB.ACPILMDBDKH("Yes_Clicked");
				Screen.sleepTimeout = -1;
				MatchManager.JKLPOGEGDNH(GLFPILGCAPM.WaitingForOpponent);
				BJGCPDNMHDH.DIKIPEDCHCF(AEMPHGEIJNH.WaitingForResponse);
				Singleton<Chat>.instance.GBNCCGDBDLJ();
				CamosManager.instance.Null();
				UICamera.instance.cachedCamera.clearFlags = CameraClearFlags.Nothing;
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(value: false);
				TimeManager.GEEKOICFEIB();
				BJGCPDNMHDH.KMJGIGDJKMH = KMJGIGDJKMH;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.WaitForServerResponse());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.mainController.AquireLevelName());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 2u:
				BJGCPDNMHDH.DIKIPEDCHCF((AEMPHGEIJNH)4);
				Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.FreeObjectsWithPrefab(Singleton<ObjectPoolDatabase>.instance.JPDFMABBKDI);
				Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.EMLIBBBMNLN(Singleton<ObjectPoolDatabase>.instance.JDNMAKKMPOA);
				PHDOCKCBJOF = new WaitForSeconds(1177f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 3u:
				ALJKAAMHHLB.KEJEFPFHIFB("warArenaCrown");
				GuiElementSingle<Background>.instance.DestroyParallax();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.PHOFHJGNJKN());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 4u:
				Resources.UnloadUnusedAssets();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<MapManager>.instance.HLACPPKNDNP(BJGCPDNMHDH.KMJGIGDJKMH));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 5u:
				GuiScreenSingle<HudScreen>.instance.gameObject.SetActive(value: true);
				GuiScreenSingle<HudScreen>.instance.NLBOJLHBFDM();
				if (BJGCPDNMHDH.NIEFNMJIAHL != null)
				{
					BJGCPDNMHDH.NIEFNMJIAHL();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.AHLLPIMMHPE(BJGCPDNMHDH.mainController.myUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.LoadOpponentUpgradesForGame(BJGCPDNMHDH.mainController.opponentUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 7u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 8u:
				if (BJGCPDNMHDH.JNFGIPOFKCF != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JNFGIPOFKCF.BEIIOAIJMFK().OHHOPMCFLJJ());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -109;
					}
					break;
				}
				goto case 10u;
			case 9u:
				CardManager.instance.SetBuddyCardsOher(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.PHIGKPODHAN);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -88;
				}
				break;
			case 10u:
				if (BJGCPDNMHDH.KKHKAJPNDEC != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.KKHKAJPNDEC.weaponInventory.OHHOPMCFLJJ());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -122;
					}
					break;
				}
				goto case 12u;
			case 11u:
				CardManager.instance.SetBuddyCardsOher(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.PHIGKPODHAN);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -29;
				}
				break;
			case 12u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().OHHOPMCFLJJ());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -52;
				}
				break;
			case 13u:
				Singleton<SoundsManager3D>.instance.LoadSounds();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 13;
				}
				break;
			case 14u:
				Resources.UnloadUnusedAssets();
				DOGHDHGLCDF = Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF;
				PEAAALBMFCA = ObjectPoolDatabase.KKCMCNCCIMB();
				IKOBPOPOHPN = PEAAALBMFCA.CALAKLNMEFF[PEAAALBMFCA.APCGDLEHGKL[DOGHDHGLCDF]];
				KFCAECGLKKO = IKOBPOPOHPN.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						PoolableObject current = KFCAECGLKKO.Current;
						EnemyController enemyController = (EnemyController)current;
						enemyController.transform.position = Singleton<GameCamera>.instance.transform.position + Singleton<GameCamera>.instance.transform.forward * 1675f;
						enemyController.enabled = true;
						enemyController.gameObject.SetActive(value: false);
						enemyController.mSoldierAnimationController.Walk(Weapon.IGGFMJAKLGO.Riffle);
						enemyController.gameObject.SetActive(value: false);
						enemyController.enabled = true;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -11;
				}
				break;
			case 15u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -22;
				}
				break;
			case 16u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.mainController.StartGame()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -84;
				}
				break;
			case 17u:
				BJGCPDNMHDH.gameState = AEMPHGEIJNH.Playing;
				Singleton<GameCamera>.instance.Enable();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -63;
				}
				break;
			case 18u:
				Time.timeScale = 135f;
				BJGCPDNMHDH.MNMLNIMFMJP = HKGHCIEPGEL.None;
				if (BJGCPDNMHDH.MLDDKLFPFPF != null)
				{
					BJGCPDNMHDH.MLDDKLFPFPF();
				}
				if (BJGCPDNMHDH.OGFHPHILDKC != null)
				{
					BJGCPDNMHDH.OGFHPHILDKC();
				}
				PHDOCKCBJOF = new WaitForSeconds(264f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -35;
				}
				break;
			case 19u:
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<HudScreen>.instance);
				PHDOCKCBJOF = new WaitForSeconds(828f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 63;
				}
				break;
			case 20u:
			{
				BJGCPDNMHDH.mainController.gameIsRunning = true;
				LoadingDialog.Hide();
				GameController bJGCPDNMHDH = BJGCPDNMHDH;
				if (LGJCBPOPCPA == null)
				{
					LGJCBPOPCPA = ADEFLNOHDAK;
				}
				bJGCPDNMHDH.InvokeAfter(LGJCBPOPCPA, 924f);
				ALJKAAMHHLB.HAAIJJBEPPN("ID_STAT_SQUADTOTAL");
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return false;
			}
			return true;
		}

		public void HNFEJKPKEHK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void GDJMNEPLJNE()
		{
			throw new NotSupportedException();
		}

		public void GFLFJHIPBNP()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public MMNJPPHAAGL()
		{
		}

		[SpecialName]
		private object DAAINALAFOJ()
		{
			return PHDOCKCBJOF;
		}

		public bool FOKKNCCLABE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Singleton<Recording>.instance.StartRecording();
				Singleton<PerformanceManager>.instance.FDFJMPCABLN(FIKGLFBFBON: false);
				Singleton<GuiManager>.instance.KAGEFJEJOKE();
				ObjectPoolDatabase.EOGLFOKEDPF((!BJGCPDNMHDH.isTutorialInProgressOrPlaned) ? NPNOIGHIALL.Init : NPNOIGHIALL.Init);
				ALJKAAMHHLB.AFBPFLKBNGM("ID_GOLD");
				Screen.sleepTimeout = -1;
				MatchManager.JKLPOGEGDNH(GLFPILGCAPM.GameCancelled);
				BJGCPDNMHDH.DIKIPEDCHCF(AEMPHGEIJNH.Menu);
				Singleton<Chat>.instance.JFMAHJBIOCE();
				CamosManager.instance.Null();
				UICamera.instance.cachedCamera.clearFlags = (CameraClearFlags)6;
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(value: true);
				TimeManager.GEEKOICFEIB();
				BJGCPDNMHDH.KMJGIGDJKMH = KMJGIGDJKMH;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.PODMAPJPBJK());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.mainController.AquireLevelName());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 2u:
				BJGCPDNMHDH.DIKIPEDCHCF((AEMPHGEIJNH)4);
				Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.NDPKMHDALCM(Singleton<ObjectPoolDatabase>.instance.JPDFMABBKDI);
				Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.FreeObjectsWithPrefab(Singleton<ObjectPoolDatabase>.instance.JDNMAKKMPOA);
				PHDOCKCBJOF = new WaitForSeconds(1925f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 3u:
				ALJKAAMHHLB.PIEBOOFPHPC("TotalPacketBytes: {0} TotalCommandBytes: {1} TotalPacketCount: {2} TotalCommandsInPackets: {3} UnreliableCommandCount: {4} ReliableCommandCount: {5}");
				GuiElementSingle<Background>.instance.DestroyParallax();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.PHOFHJGNJKN());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 4u:
				Resources.UnloadUnusedAssets();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<MapManager>.instance.ALGBMPAMCGN(BJGCPDNMHDH.KMJGIGDJKMH));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 5u:
				GuiScreenSingle<HudScreen>.instance.gameObject.SetActive(value: false);
				GuiScreenSingle<HudScreen>.instance.PBAOFHDILFK();
				if (BJGCPDNMHDH.NIEFNMJIAHL != null)
				{
					BJGCPDNMHDH.NIEFNMJIAHL();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.INOELOHHGOF(BJGCPDNMHDH.mainController.myUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.INPOHMCEPNK(BJGCPDNMHDH.mainController.opponentUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 7u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 8u:
				if (BJGCPDNMHDH.JNFGIPOFKCF != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JNFGIPOFKCF.weaponInventory.OHHOPMCFLJJ());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -97;
					}
					break;
				}
				goto case 10u;
			case 9u:
				CardManager.instance.SetBuddyCardsOher(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.PHIGKPODHAN);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -53;
				}
				break;
			case 10u:
				if (BJGCPDNMHDH.KKHKAJPNDEC != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.KKHKAJPNDEC.FMKGGADDHJK().LoadWeapons());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 80;
					}
					break;
				}
				goto case 12u;
			case 11u:
				CardManager.instance.SetBuddyCardsOher(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.PHIGKPODHAN);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 66;
				}
				break;
			case 12u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PlayerController.OGMBJPKOPCB.weaponInventory.MIPLOENBIML());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 36;
				}
				break;
			case 13u:
				Singleton<SoundsManager3D>.instance.AAFOKCOECGJ();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -40;
				}
				break;
			case 14u:
				Resources.UnloadUnusedAssets();
				DOGHDHGLCDF = Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF;
				PEAAALBMFCA = ObjectPoolDatabase.EHFPBDJMGNC();
				IKOBPOPOHPN = PEAAALBMFCA.CALAKLNMEFF[PEAAALBMFCA.APCGDLEHGKL[DOGHDHGLCDF]];
				KFCAECGLKKO = IKOBPOPOHPN.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						PoolableObject current = KFCAECGLKKO.Current;
						EnemyController enemyController = (EnemyController)current;
						enemyController.transform.position = Singleton<GameCamera>.instance.transform.position + Singleton<GameCamera>.instance.transform.forward * 388f;
						enemyController.enabled = false;
						enemyController.gameObject.SetActive(value: false);
						enemyController.mSoldierAnimationController.Walk(Weapon.IGGFMJAKLGO.GrenadeLauncher);
						enemyController.gameObject.SetActive(value: true);
						enemyController.enabled = false;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -3;
				}
				break;
			case 15u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -123;
				}
				break;
			case 16u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.mainController.StartGame()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -56;
				}
				break;
			case 17u:
				BJGCPDNMHDH.DIKIPEDCHCF(AEMPHGEIJNH.Loading);
				Singleton<GameCamera>.instance.Enable();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 107;
				}
				break;
			case 18u:
				Time.timeScale = 1615f;
				BJGCPDNMHDH.MNMLNIMFMJP = HKGHCIEPGEL.Killed;
				if (BJGCPDNMHDH.MLDDKLFPFPF != null)
				{
					BJGCPDNMHDH.MLDDKLFPFPF();
				}
				if (BJGCPDNMHDH.OGFHPHILDKC != null)
				{
					BJGCPDNMHDH.OGFHPHILDKC();
				}
				PHDOCKCBJOF = new WaitForSeconds(571f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 54;
				}
				break;
			case 19u:
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<HudScreen>.instance);
				PHDOCKCBJOF = new WaitForSeconds(844f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -67;
				}
				break;
			case 20u:
			{
				BJGCPDNMHDH.mainController.gameIsRunning = false;
				LoadingDialog.Hide();
				GameController bJGCPDNMHDH = BJGCPDNMHDH;
				if (LGJCBPOPCPA == null)
				{
					LGJCBPOPCPA = APHOLLLLNCG;
				}
				bJGCPDNMHDH.InvokeAfter(LGJCBPOPCPA, 1199f);
				ALJKAAMHHLB.DHPGNLOHBLC("getGameConfigurationKeys");
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return false;
			}
			return false;
		}

		public void EJADBNAIHEF()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		private static void FLHHIKGAEDM()
		{
			AFPSCounter.Instance.fpsCounter.ResetMinMax();
			AFPSCounter.Instance.fpsCounter.ResetAverage();
		}

		public void LOOMFHNKAND()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object PNBPOAMPNKP()
		{
			return PHDOCKCBJOF;
		}

		public void AHEOCEEJICJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object OFAOFOPFIJJ()
		{
			return PHDOCKCBJOF;
		}

		public void KKCNPIPOCKK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HHHLDCLIFKJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ONADHLDNKKB()
		{
			return PHDOCKCBJOF;
		}

		private static void DGELDDJAEEF()
		{
			AFPSCounter.Instance.fpsCounter.ResetMinMax();
			AFPSCounter.Instance.fpsCounter.ResetAverage();
		}

		public void AKEKFBGEJBG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		private static void DFAGLMPEDIH()
		{
			AFPSCounter.Instance.fpsCounter.ResetMinMax();
			AFPSCounter.Instance.fpsCounter.ResetAverage();
		}

		public bool ICKNHCBNOMG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Singleton<Recording>.instance.StartRecording();
				Singleton<PerformanceManager>.instance.AOBNCIOGFKA(FIKGLFBFBON: false);
				Singleton<GuiManager>.instance.KAGEFJEJOKE();
				ObjectPoolDatabase.KHLPFECMGCL(BJGCPDNMHDH.isTutorialInProgressOrPlaned ? NPNOIGHIALL.Tutorial : NPNOIGHIALL.Game);
				ALJKAAMHHLB.DHPGNLOHBLC("#Mission# New Wawe comming");
				Screen.sleepTimeout = -1;
				MatchManager.KBHGDEPHPIO((GLFPILGCAPM)6);
				BJGCPDNMHDH.gameState = AEMPHGEIJNH.Menu;
				Singleton<Chat>.instance.Disconnect();
				CamosManager.instance.Null();
				UICamera.instance.cachedCamera.clearFlags = (CameraClearFlags)8;
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(value: false);
				TimeManager.Reset();
				BJGCPDNMHDH.KMJGIGDJKMH = KMJGIGDJKMH;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.PODMAPJPBJK());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.mainController.AquireLevelName());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 2u:
				BJGCPDNMHDH.gameState = AEMPHGEIJNH.Playing;
				Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.EMLIBBBMNLN(Singleton<ObjectPoolDatabase>.instance.JPDFMABBKDI);
				Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.NDPKMHDALCM(Singleton<ObjectPoolDatabase>.instance.JDNMAKKMPOA);
				PHDOCKCBJOF = new WaitForSeconds(1716f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 3u:
				ALJKAAMHHLB.BIDJNBKOMIN("Equipping visual \"{0}\" from rental");
				GuiElementSingle<Background>.instance.DestroyParallax();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.ClearMenuLoadGameCoroutine());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 4u:
				Resources.UnloadUnusedAssets();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<MapManager>.instance.BGPOIGKLDJE(BJGCPDNMHDH.KMJGIGDJKMH));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 5u:
				GuiScreenSingle<HudScreen>.instance.gameObject.SetActive(value: false);
				GuiScreenSingle<HudScreen>.instance.OEOPELJAFED();
				if (BJGCPDNMHDH.NIEFNMJIAHL != null)
				{
					BJGCPDNMHDH.NIEFNMJIAHL();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.ALCJENMGIMJ(BJGCPDNMHDH.mainController.myUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.OJFAHJCHLAI(BJGCPDNMHDH.mainController.opponentUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 7u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 8u:
				if (BJGCPDNMHDH.JNFGIPOFKCF != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JNFGIPOFKCF.weaponInventory.OHHOPMCFLJJ());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -112;
					}
					break;
				}
				goto case 10u;
			case 9u:
				CardManager.instance.SetBuddyCardsOher(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.PHIGKPODHAN);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 58;
				}
				break;
			case 10u:
				if (BJGCPDNMHDH.KKHKAJPNDEC != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.KKHKAJPNDEC.BEIIOAIJMFK().OHHOPMCFLJJ());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 41;
					}
					break;
				}
				goto case 12u;
			case 11u:
				CardManager.instance.SetBuddyCardsOher(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.PHIGKPODHAN);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -125;
				}
				break;
			case 12u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().OHHOPMCFLJJ());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -118;
				}
				break;
			case 13u:
				Singleton<SoundsManager3D>.instance.GCOKDIOKPKG();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 102;
				}
				break;
			case 14u:
				Resources.UnloadUnusedAssets();
				DOGHDHGLCDF = Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF;
				PEAAALBMFCA = ObjectPoolDatabase.ADBOHNCGKHA();
				IKOBPOPOHPN = PEAAALBMFCA.CALAKLNMEFF[PEAAALBMFCA.APCGDLEHGKL[DOGHDHGLCDF]];
				KFCAECGLKKO = IKOBPOPOHPN.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						PoolableObject current = KFCAECGLKKO.Current;
						EnemyController enemyController = (EnemyController)current;
						enemyController.transform.position = Singleton<GameCamera>.instance.transform.position + Singleton<GameCamera>.instance.transform.forward * 409f;
						enemyController.enabled = true;
						enemyController.gameObject.SetActive(value: true);
						enemyController.mSoldierAnimationController.Walk(Weapon.IGGFMJAKLGO.Bazooka);
						enemyController.gameObject.SetActive(value: false);
						enemyController.enabled = false;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -95;
				}
				break;
			case 15u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 16u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.mainController.StartGame()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -127;
				}
				break;
			case 17u:
				BJGCPDNMHDH.DIKIPEDCHCF(AEMPHGEIJNH.WaitingForResponse);
				Singleton<GameCamera>.instance.HLLODJKPDPK();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -60;
				}
				break;
			case 18u:
				Time.timeScale = 824f;
				BJGCPDNMHDH.MNMLNIMFMJP = HKGHCIEPGEL.None;
				if (BJGCPDNMHDH.MLDDKLFPFPF != null)
				{
					BJGCPDNMHDH.MLDDKLFPFPF();
				}
				if (BJGCPDNMHDH.OGFHPHILDKC != null)
				{
					BJGCPDNMHDH.OGFHPHILDKC();
				}
				PHDOCKCBJOF = new WaitForSeconds(1362f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -115;
				}
				break;
			case 19u:
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<HudScreen>.instance);
				PHDOCKCBJOF = new WaitForSeconds(469f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 63;
				}
				break;
			case 20u:
			{
				BJGCPDNMHDH.mainController.gameIsRunning = true;
				LoadingDialog.Hide();
				GameController bJGCPDNMHDH = BJGCPDNMHDH;
				if (LGJCBPOPCPA == null)
				{
					LGJCBPOPCPA = LJCDGJKCNEC;
				}
				bJGCPDNMHDH.InvokeAfter(LGJCBPOPCPA, 273f);
				ALJKAAMHHLB.BCFGNBMMJIB("GLM: RegisterOrLogin -  2");
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object BJECHFCOBLP()
		{
			return PHDOCKCBJOF;
		}

		private static void BPONFHMBCLK()
		{
			AFPSCounter.Instance.fpsCounter.ResetMinMax();
			AFPSCounter.Instance.fpsCounter.ResetAverage();
		}

		public void JDFJKNFDDGN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void MIFJOIIKFEB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool PPOPGFELIDA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Singleton<Recording>.instance.StartRecording();
				Singleton<PerformanceManager>.instance.LCOIHOCJGLF(FIKGLFBFBON: false);
				Singleton<GuiManager>.instance.AOGOJDGBMMD();
				ObjectPoolDatabase.EOGLFOKEDPF(BJGCPDNMHDH.isTutorialInProgressOrPlaned ? NPNOIGHIALL.Tutorial : ((NPNOIGHIALL)7));
				ALJKAAMHHLB.GCIEGGGEGMB("ExceptionStacktrace");
				Screen.sleepTimeout = -1;
				MatchManager.matchState = GLFPILGCAPM.GameCancelled;
				BJGCPDNMHDH.gameState = AEMPHGEIJNH.Menu;
				Singleton<Chat>.instance.Disconnect();
				CamosManager.instance.Null();
				UICamera.instance.cachedCamera.clearFlags = (CameraClearFlags)5;
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(value: false);
				TimeManager.Reset();
				BJGCPDNMHDH.KMJGIGDJKMH = KMJGIGDJKMH;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.WaitForServerResponse());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.mainController.AquireLevelName());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 2u:
				BJGCPDNMHDH.DIKIPEDCHCF(AEMPHGEIJNH.Loading);
				Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.NDPKMHDALCM(Singleton<ObjectPoolDatabase>.instance.JPDFMABBKDI);
				Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.EMLIBBBMNLN(Singleton<ObjectPoolDatabase>.instance.JDNMAKKMPOA);
				PHDOCKCBJOF = new WaitForSeconds(1178f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 3u:
				ALJKAAMHHLB.GLEKOOMNAKI("Area");
				GuiElementSingle<Background>.instance.DestroyParallax();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.ClearMenuLoadGameCoroutine());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 4u:
				Resources.UnloadUnusedAssets();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<MapManager>.instance.ALGBMPAMCGN(BJGCPDNMHDH.KMJGIGDJKMH));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 5u:
				GuiScreenSingle<HudScreen>.instance.gameObject.SetActive(value: false);
				GuiScreenSingle<HudScreen>.instance.KFLNKPBCBDD();
				if (BJGCPDNMHDH.NIEFNMJIAHL != null)
				{
					BJGCPDNMHDH.NIEFNMJIAHL();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.HAMMNLGJFON(BJGCPDNMHDH.mainController.myUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.HGPDIMKPINN(BJGCPDNMHDH.mainController.opponentUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 7u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 8u:
				if (BJGCPDNMHDH.JNFGIPOFKCF != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JNFGIPOFKCF.weaponInventory.JPMEEDEFDOP());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -128;
					}
					break;
				}
				goto case 10u;
			case 9u:
				CardManager.instance.SetBuddyCardsOher(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.PHIGKPODHAN);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -126;
				}
				break;
			case 10u:
				if (BJGCPDNMHDH.KKHKAJPNDEC != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.KKHKAJPNDEC.BEIIOAIJMFK().GAAMHKBJPDL());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 89;
					}
					break;
				}
				goto case 12u;
			case 11u:
				CardManager.instance.SetBuddyCardsOher(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.PHIGKPODHAN);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 31;
				}
				break;
			case 12u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().LoadWeapons());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -14;
				}
				break;
			case 13u:
				Singleton<SoundsManager3D>.instance.LOBFOCCGGHB();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 89;
				}
				break;
			case 14u:
				Resources.UnloadUnusedAssets();
				DOGHDHGLCDF = Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF;
				PEAAALBMFCA = ObjectPoolDatabase.COJFMKNGPBP();
				IKOBPOPOHPN = PEAAALBMFCA.CALAKLNMEFF[PEAAALBMFCA.APCGDLEHGKL[DOGHDHGLCDF]];
				KFCAECGLKKO = IKOBPOPOHPN.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						PoolableObject current = KFCAECGLKKO.Current;
						EnemyController enemyController = (EnemyController)current;
						enemyController.transform.position = Singleton<GameCamera>.instance.transform.position + Singleton<GameCamera>.instance.transform.forward * 390f;
						enemyController.enabled = false;
						enemyController.gameObject.SetActive(value: false);
						enemyController.mSoldierAnimationController.Walk(Weapon.IGGFMJAKLGO.GrenadeLauncher);
						enemyController.gameObject.SetActive(value: true);
						enemyController.enabled = true;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 15u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 47;
				}
				break;
			case 16u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.mainController.StartGame()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 90;
				}
				break;
			case 17u:
				BJGCPDNMHDH.gameState = AEMPHGEIJNH.WaitingForResponse;
				Singleton<GameCamera>.instance.HLLODJKPDPK();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -32;
				}
				break;
			case 18u:
				Time.timeScale = 1527f;
				BJGCPDNMHDH.MNMLNIMFMJP = HKGHCIEPGEL.Killed;
				if (BJGCPDNMHDH.MLDDKLFPFPF != null)
				{
					BJGCPDNMHDH.MLDDKLFPFPF();
				}
				if (BJGCPDNMHDH.OGFHPHILDKC != null)
				{
					BJGCPDNMHDH.OGFHPHILDKC();
				}
				PHDOCKCBJOF = new WaitForSeconds(1310f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -115;
				}
				break;
			case 19u:
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<HudScreen>.instance);
				PHDOCKCBJOF = new WaitForSeconds(1780f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -60;
				}
				break;
			case 20u:
			{
				BJGCPDNMHDH.mainController.gameIsRunning = true;
				LoadingDialog.Hide();
				GameController bJGCPDNMHDH = BJGCPDNMHDH;
				if (LGJCBPOPCPA == null)
				{
					LGJCBPOPCPA = LJCDGJKCNEC;
				}
				bJGCPDNMHDH.InvokeAfter(LGJCBPOPCPA, 576f);
				ALJKAAMHHLB.PJIMOPNDNKO(" S:");
				CLPPIAGLCJJ = -1;
				goto default;
			}
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

		[SpecialName]
		private object ALJCNLJGABF()
		{
			return PHDOCKCBJOF;
		}

		public void HANDHJHGLAP()
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
				Singleton<Recording>.instance.FOJIDINENDK();
				Singleton<PerformanceManager>.instance.AOBNCIOGFKA(FIKGLFBFBON: true);
				Singleton<GuiManager>.instance.KAGEFJEJOKE();
				ObjectPoolDatabase.DJBHEMBOCDC((!BJGCPDNMHDH.JLIBMLEFJFE()) ? NPNOIGHIALL.Tutorial : NPNOIGHIALL.Init);
				ALJKAAMHHLB.HNMONAFFBLE("bazooka_uncover_left");
				Screen.sleepTimeout = -1;
				MatchManager.GODMIAKEFOA(GLFPILGCAPM.GameCancelled);
				BJGCPDNMHDH.gameState = AEMPHGEIJNH.Menu;
				Singleton<Chat>.instance.JIDBDDJADON();
				CamosManager.instance.Null();
				UICamera.instance.cachedCamera.clearFlags = (CameraClearFlags)8;
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(value: false);
				TimeManager.GEEKOICFEIB();
				BJGCPDNMHDH.KMJGIGDJKMH = KMJGIGDJKMH;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.WaitForServerResponse());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.mainController.AquireLevelName());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 2u:
				BJGCPDNMHDH.gameState = AEMPHGEIJNH.Menu;
				Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.FreeObjectsWithPrefab(Singleton<ObjectPoolDatabase>.instance.JPDFMABBKDI);
				Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.NDPKMHDALCM(Singleton<ObjectPoolDatabase>.instance.JDNMAKKMPOA);
				PHDOCKCBJOF = new WaitForSeconds(616f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 3u:
				ALJKAAMHHLB.CJEDHGLIGJH("\t");
				GuiElementSingle<Background>.instance.FGABLBFJFEP();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.ClearMenuLoadGameCoroutine());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 4u:
				Resources.UnloadUnusedAssets();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<MapManager>.instance.ALGBMPAMCGN(BJGCPDNMHDH.KMJGIGDJKMH));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 5u:
				GuiScreenSingle<HudScreen>.instance.gameObject.SetActive(value: false);
				GuiScreenSingle<HudScreen>.instance.OEOPELJAFED();
				if (BJGCPDNMHDH.NIEFNMJIAHL != null)
				{
					BJGCPDNMHDH.NIEFNMJIAHL();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.DFLCBPJJNJM(BJGCPDNMHDH.mainController.myUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.MENLJAJLFOM(BJGCPDNMHDH.mainController.opponentUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 7u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 8u:
				if (BJGCPDNMHDH.JNFGIPOFKCF != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JNFGIPOFKCF.FMKGGADDHJK().GAAMHKBJPDL());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -63;
					}
					break;
				}
				goto case 10u;
			case 9u:
				CardManager.instance.SetBuddyCardsOher(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.PHIGKPODHAN);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 51;
				}
				break;
			case 10u:
				if (BJGCPDNMHDH.KKHKAJPNDEC != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.KKHKAJPNDEC.BEIIOAIJMFK().GAAMHKBJPDL());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -54;
					}
					break;
				}
				goto case 12u;
			case 11u:
				CardManager.instance.SetBuddyCardsOher(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.PHIGKPODHAN);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 74;
				}
				break;
			case 12u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().LoadWeapons());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -15;
				}
				break;
			case 13u:
				Singleton<SoundsManager3D>.instance.GCOKDIOKPKG();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -66;
				}
				break;
			case 14u:
				Resources.UnloadUnusedAssets();
				DOGHDHGLCDF = Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF;
				PEAAALBMFCA = ObjectPoolDatabase.ADBOHNCGKHA();
				IKOBPOPOHPN = PEAAALBMFCA.CALAKLNMEFF[PEAAALBMFCA.APCGDLEHGKL[DOGHDHGLCDF]];
				KFCAECGLKKO = IKOBPOPOHPN.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						PoolableObject current = KFCAECGLKKO.Current;
						EnemyController enemyController = (EnemyController)current;
						enemyController.transform.position = Singleton<GameCamera>.instance.transform.position + Singleton<GameCamera>.instance.transform.forward * 97f;
						enemyController.enabled = true;
						enemyController.gameObject.SetActive(value: true);
						enemyController.mSoldierAnimationController.Walk(Weapon.IGGFMJAKLGO.Grenade);
						enemyController.gameObject.SetActive(value: true);
						enemyController.enabled = false;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -76;
				}
				break;
			case 15u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -29;
				}
				break;
			case 16u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.mainController.StartGame()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 78;
				}
				break;
			case 17u:
				BJGCPDNMHDH.gameState = (AEMPHGEIJNH)5;
				Singleton<GameCamera>.instance.HLLODJKPDPK();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 40;
				}
				break;
			case 18u:
				Time.timeScale = 1056f;
				BJGCPDNMHDH.MNMLNIMFMJP = HKGHCIEPGEL.None;
				if (BJGCPDNMHDH.MLDDKLFPFPF != null)
				{
					BJGCPDNMHDH.MLDDKLFPFPF();
				}
				if (BJGCPDNMHDH.OGFHPHILDKC != null)
				{
					BJGCPDNMHDH.OGFHPHILDKC();
				}
				PHDOCKCBJOF = new WaitForSeconds(577f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 84;
				}
				break;
			case 19u:
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<HudScreen>.instance);
				PHDOCKCBJOF = new WaitForSeconds(965f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 126;
				}
				break;
			case 20u:
			{
				BJGCPDNMHDH.mainController.gameIsRunning = true;
				LoadingDialog.Hide();
				GameController bJGCPDNMHDH = BJGCPDNMHDH;
				if (LGJCBPOPCPA == null)
				{
					LGJCBPOPCPA = DFAGLMPEDIH;
				}
				bJGCPDNMHDH.InvokeAfter(LGJCBPOPCPA, 41f);
				ALJKAAMHHLB.MAJHIDGCOGK("PauseDuration");
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return true;
			}
			return true;
		}

		private static void BEIGOGFHJIB()
		{
			AFPSCounter.Instance.fpsCounter.ResetMinMax();
			AFPSCounter.Instance.fpsCounter.ResetAverage();
		}

		public bool FCPJPIDEPOF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Singleton<Recording>.instance.StartRecording();
				Singleton<PerformanceManager>.instance.KHEDGHEHPLK(FIKGLFBFBON: false);
				Singleton<GuiManager>.instance.TurnOnInputCompletly();
				ObjectPoolDatabase.InstantiatePooledObjects((!BJGCPDNMHDH.isTutorialInProgressOrPlaned) ? NPNOIGHIALL.Tutorial : NPNOIGHIALL.Tutorial);
				ALJKAAMHHLB.JOKCPHMJIGH("Xp");
				Screen.sleepTimeout = -1;
				MatchManager.JKLPOGEGDNH(GLFPILGCAPM.GameLoading);
				BJGCPDNMHDH.gameState = AEMPHGEIJNH.Menu;
				Singleton<Chat>.instance.BIEGPPPEDAL();
				CamosManager.instance.Null();
				UICamera.instance.cachedCamera.clearFlags = (CameraClearFlags)5;
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(value: false);
				TimeManager.Reset();
				BJGCPDNMHDH.KMJGIGDJKMH = KMJGIGDJKMH;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.PODMAPJPBJK());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.mainController.AquireLevelName());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
				BJGCPDNMHDH.DIKIPEDCHCF(AEMPHGEIJNH.Playing);
				Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.NDPKMHDALCM(Singleton<ObjectPoolDatabase>.instance.JPDFMABBKDI);
				Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.FreeObjectsWithPrefab(Singleton<ObjectPoolDatabase>.instance.JDNMAKKMPOA);
				PHDOCKCBJOF = new WaitForSeconds(1467f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 3u:
				ALJKAAMHHLB.ACPILMDBDKH("HP");
				GuiElementSingle<Background>.instance.DestroyParallax();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.PHOFHJGNJKN());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 4u:
				Resources.UnloadUnusedAssets();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<MapManager>.instance.ALGBMPAMCGN(BJGCPDNMHDH.KMJGIGDJKMH));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 5u:
				GuiScreenSingle<HudScreen>.instance.gameObject.SetActive(value: true);
				GuiScreenSingle<HudScreen>.instance.OEOPELJAFED();
				if (BJGCPDNMHDH.NIEFNMJIAHL != null)
				{
					BJGCPDNMHDH.NIEFNMJIAHL();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.LKNNHEPKDJP(BJGCPDNMHDH.mainController.myUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.DPOACGBGFIA(BJGCPDNMHDH.mainController.opponentUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 7u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 8u:
				if (BJGCPDNMHDH.JNFGIPOFKCF != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JNFGIPOFKCF.JLMDEMFIHCA().LoadWeapons());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -115;
					}
					break;
				}
				goto case 10u;
			case 9u:
				CardManager.instance.SetBuddyCardsOher(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.PHIGKPODHAN);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -17;
				}
				break;
			case 10u:
				if (BJGCPDNMHDH.KKHKAJPNDEC != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.KKHKAJPNDEC.weaponInventory.JPMEEDEFDOP());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -19;
					}
					break;
				}
				goto case 12u;
			case 11u:
				CardManager.instance.SetBuddyCardsOher(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.PHIGKPODHAN);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 10;
				}
				break;
			case 12u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PlayerController.OGMBJPKOPCB.weaponInventory.MIPLOENBIML());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -71;
				}
				break;
			case 13u:
				Singleton<SoundsManager3D>.instance.AAFOKCOECGJ();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 41;
				}
				break;
			case 14u:
				Resources.UnloadUnusedAssets();
				DOGHDHGLCDF = Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF;
				PEAAALBMFCA = ObjectPoolDatabase.MFKPDKCLDBI();
				IKOBPOPOHPN = PEAAALBMFCA.CALAKLNMEFF[PEAAALBMFCA.APCGDLEHGKL[DOGHDHGLCDF]];
				KFCAECGLKKO = IKOBPOPOHPN.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						PoolableObject current = KFCAECGLKKO.Current;
						EnemyController enemyController = (EnemyController)current;
						enemyController.transform.position = Singleton<GameCamera>.instance.transform.position + Singleton<GameCamera>.instance.transform.forward * 41f;
						enemyController.enabled = true;
						enemyController.gameObject.SetActive(value: true);
						enemyController.mSoldierAnimationController.Walk(Weapon.IGGFMJAKLGO.Grenade);
						enemyController.gameObject.SetActive(value: false);
						enemyController.enabled = false;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 113;
				}
				break;
			case 15u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -11;
				}
				break;
			case 16u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.mainController.StartGame()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 32;
				}
				break;
			case 17u:
				BJGCPDNMHDH.gameState = (AEMPHGEIJNH)7;
				Singleton<GameCamera>.instance.HLLODJKPDPK();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -45;
				}
				break;
			case 18u:
				Time.timeScale = 1188f;
				BJGCPDNMHDH.MNMLNIMFMJP = HKGHCIEPGEL.None;
				if (BJGCPDNMHDH.MLDDKLFPFPF != null)
				{
					BJGCPDNMHDH.MLDDKLFPFPF();
				}
				if (BJGCPDNMHDH.OGFHPHILDKC != null)
				{
					BJGCPDNMHDH.OGFHPHILDKC();
				}
				PHDOCKCBJOF = new WaitForSeconds(965f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 50;
				}
				break;
			case 19u:
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<HudScreen>.instance);
				PHDOCKCBJOF = new WaitForSeconds(1752f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 9;
				}
				break;
			case 20u:
			{
				BJGCPDNMHDH.mainController.gameIsRunning = true;
				LoadingDialog.Hide();
				GameController bJGCPDNMHDH = BJGCPDNMHDH;
				if (LGJCBPOPCPA == null)
				{
					LGJCBPOPCPA = DGELDDJAEEF;
				}
				bJGCPDNMHDH.InvokeAfter(LGJCBPOPCPA, 1253f);
				ALJKAAMHHLB.BCFGNBMMJIB("For panel \"{0}\" layers:\n");
				CLPPIAGLCJJ = -1;
				goto default;
			}
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

		public bool LPCBKGKFNFD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Singleton<Recording>.instance.StartRecording();
				Singleton<PerformanceManager>.instance.CAPGAAJFBDB(FIKGLFBFBON: true);
				Singleton<GuiManager>.instance.AOGOJDGBMMD();
				ObjectPoolDatabase.InstantiatePooledObjects(BJGCPDNMHDH.JLIBMLEFJFE() ? NPNOIGHIALL.Tutorial : ((NPNOIGHIALL)8));
				ALJKAAMHHLB.GCIEGGGEGMB("Xp");
				Screen.sleepTimeout = -1;
				MatchManager.JKLPOGEGDNH(GLFPILGCAPM.WaitingForOpponent);
				BJGCPDNMHDH.DIKIPEDCHCF(AEMPHGEIJNH.Menu);
				Singleton<Chat>.instance.GFKGBHMLBDL();
				CamosManager.instance.Null();
				UICamera.instance.cachedCamera.clearFlags = (CameraClearFlags)5;
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(value: false);
				TimeManager.Reset();
				BJGCPDNMHDH.KMJGIGDJKMH = KMJGIGDJKMH;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.WaitForServerResponse());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.mainController.AquireLevelName());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 2u:
				BJGCPDNMHDH.DIKIPEDCHCF(AEMPHGEIJNH.Playing);
				Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.EMLIBBBMNLN(Singleton<ObjectPoolDatabase>.instance.JPDFMABBKDI);
				Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.FreeObjectsWithPrefab(Singleton<ObjectPoolDatabase>.instance.JDNMAKKMPOA);
				PHDOCKCBJOF = new WaitForSeconds(1717f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 3u:
				ALJKAAMHHLB.CCDJDGFFCHC("was:{0} is:{1} removed:{2}");
				GuiElementSingle<Background>.instance.FGABLBFJFEP();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.PHOFHJGNJKN());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 4u:
				Resources.UnloadUnusedAssets();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<MapManager>.instance.HLACPPKNDNP(BJGCPDNMHDH.KMJGIGDJKMH));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 5u:
				GuiScreenSingle<HudScreen>.instance.gameObject.SetActive(value: false);
				GuiScreenSingle<HudScreen>.instance.SetTransparent();
				if (BJGCPDNMHDH.NIEFNMJIAHL != null)
				{
					BJGCPDNMHDH.NIEFNMJIAHL();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.EGBFNBAHFAH(BJGCPDNMHDH.mainController.myUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.PKOMOKDMNPE(BJGCPDNMHDH.mainController.opponentUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 7u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 8u:
				if (BJGCPDNMHDH.JNFGIPOFKCF != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JNFGIPOFKCF.BEIIOAIJMFK().MIPLOENBIML());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 110;
					}
					break;
				}
				goto case 10u;
			case 9u:
				CardManager.instance.SetBuddyCardsOher(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.PHIGKPODHAN);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 20;
				}
				break;
			case 10u:
				if (BJGCPDNMHDH.KKHKAJPNDEC != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.KKHKAJPNDEC.JLMDEMFIHCA().JPMEEDEFDOP());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -60;
					}
					break;
				}
				goto case 12u;
			case 11u:
				CardManager.instance.SetBuddyCardsOher(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.PHIGKPODHAN);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -38;
				}
				break;
			case 12u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PlayerController.OGMBJPKOPCB.weaponInventory.JPMEEDEFDOP());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -6;
				}
				break;
			case 13u:
				Singleton<SoundsManager3D>.instance.IBAHNGKDCPA();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 9;
				}
				break;
			case 14u:
				Resources.UnloadUnusedAssets();
				DOGHDHGLCDF = Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF;
				PEAAALBMFCA = ObjectPoolDatabase.INOJHPIKICM();
				IKOBPOPOHPN = PEAAALBMFCA.CALAKLNMEFF[PEAAALBMFCA.APCGDLEHGKL[DOGHDHGLCDF]];
				KFCAECGLKKO = IKOBPOPOHPN.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						PoolableObject current = KFCAECGLKKO.Current;
						EnemyController enemyController = (EnemyController)current;
						enemyController.transform.position = Singleton<GameCamera>.instance.transform.position + Singleton<GameCamera>.instance.transform.forward * 151f;
						enemyController.enabled = true;
						enemyController.gameObject.SetActive(value: true);
						enemyController.mSoldierAnimationController.Walk(Weapon.IGGFMJAKLGO.Tool);
						enemyController.gameObject.SetActive(value: false);
						enemyController.enabled = true;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -49;
				}
				break;
			case 15u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -74;
				}
				break;
			case 16u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.mainController.StartGame()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 105;
				}
				break;
			case 17u:
				BJGCPDNMHDH.gameState = AEMPHGEIJNH.WaitingForResponse;
				Singleton<GameCamera>.instance.HLLODJKPDPK();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 46;
				}
				break;
			case 18u:
				Time.timeScale = 1315f;
				BJGCPDNMHDH.MNMLNIMFMJP = HKGHCIEPGEL.None;
				if (BJGCPDNMHDH.MLDDKLFPFPF != null)
				{
					BJGCPDNMHDH.MLDDKLFPFPF();
				}
				if (BJGCPDNMHDH.OGFHPHILDKC != null)
				{
					BJGCPDNMHDH.OGFHPHILDKC();
				}
				PHDOCKCBJOF = new WaitForSeconds(737f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 113;
				}
				break;
			case 19u:
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<HudScreen>.instance);
				PHDOCKCBJOF = new WaitForSeconds(1928f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -22;
				}
				break;
			case 20u:
			{
				BJGCPDNMHDH.mainController.gameIsRunning = false;
				LoadingDialog.Hide();
				GameController bJGCPDNMHDH = BJGCPDNMHDH;
				if (LGJCBPOPCPA == null)
				{
					LGJCBPOPCPA = EGJBKFPHCNF;
				}
				bJGCPDNMHDH.InvokeAfter(LGJCBPOPCPA, 814f);
				ALJKAAMHHLB.POPONJAMPDF("IsSpecial");
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return false;
			}
			return false;
		}

		private static void FIBGJHCGHJH()
		{
			AFPSCounter.Instance.fpsCounter.ResetMinMax();
			AFPSCounter.Instance.fpsCounter.ResetAverage();
		}

		public void NDPOBCODJAI()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object ENKCCCABFFB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LKAEMBCGLBN()
		{
			return PHDOCKCBJOF;
		}

		private static void NNIJEDKBPGJ()
		{
			AFPSCounter.Instance.fpsCounter.ResetMinMax();
			AFPSCounter.Instance.fpsCounter.ResetAverage();
		}

		[SpecialName]
		private object HPHLLGIMIMO()
		{
			return PHDOCKCBJOF;
		}

		public void HCHFFFPDMDA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HLBMCNKGBDM()
		{
			return PHDOCKCBJOF;
		}

		private static void ADEFLNOHDAK()
		{
			AFPSCounter.Instance.fpsCounter.ResetMinMax();
			AFPSCounter.Instance.fpsCounter.ResetAverage();
		}

		private static void OKBIKLGPNKI()
		{
			AFPSCounter.Instance.fpsCounter.ResetMinMax();
			AFPSCounter.Instance.fpsCounter.ResetAverage();
		}

		private static void OCHIBNMPIFM()
		{
			AFPSCounter.Instance.fpsCounter.ResetMinMax();
			AFPSCounter.Instance.fpsCounter.ResetAverage();
		}

		public void CCPGGFONBKA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void LKACEPHEHPK()
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
				Singleton<Recording>.instance.FOJIDINENDK();
				Singleton<PerformanceManager>.instance.CAPGAAJFBDB(FIKGLFBFBON: true);
				Singleton<GuiManager>.instance.KAGEFJEJOKE();
				ObjectPoolDatabase.EOGLFOKEDPF((!BJGCPDNMHDH.isTutorialInProgressOrPlaned) ? NPNOIGHIALL.Tutorial : NPNOIGHIALL.Tutorial);
				ALJKAAMHHLB.DLAEBOBJKBL("isSuccess");
				Screen.sleepTimeout = -1;
				MatchManager.GODMIAKEFOA(GLFPILGCAPM.GameLoading);
				BJGCPDNMHDH.DIKIPEDCHCF(AEMPHGEIJNH.Menu);
				Singleton<Chat>.instance.MODCIBKGJBF();
				CamosManager.instance.Null();
				UICamera.instance.cachedCamera.clearFlags = CameraClearFlags.Color;
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(value: false);
				TimeManager.Reset();
				BJGCPDNMHDH.KMJGIGDJKMH = KMJGIGDJKMH;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.WaitForServerResponse());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.mainController.AquireLevelName());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 2u:
				BJGCPDNMHDH.DIKIPEDCHCF(AEMPHGEIJNH.Menu);
				Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.FreeObjectsWithPrefab(Singleton<ObjectPoolDatabase>.instance.JPDFMABBKDI);
				Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.FreeObjectsWithPrefab(Singleton<ObjectPoolDatabase>.instance.JDNMAKKMPOA);
				PHDOCKCBJOF = new WaitForSeconds(614f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 3u:
				ALJKAAMHHLB.BIDJNBKOMIN("ID_LEAGUEREWARDHINT2");
				GuiElementSingle<Background>.instance.DestroyParallax();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.PHOFHJGNJKN());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 4u:
				Resources.UnloadUnusedAssets();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<MapManager>.instance.PEBCGPPNBGE(BJGCPDNMHDH.KMJGIGDJKMH));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 5u:
				GuiScreenSingle<HudScreen>.instance.gameObject.SetActive(value: true);
				GuiScreenSingle<HudScreen>.instance.NLBOJLHBFDM();
				if (BJGCPDNMHDH.NIEFNMJIAHL != null)
				{
					BJGCPDNMHDH.NIEFNMJIAHL();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.HACBEEBGCMO(BJGCPDNMHDH.mainController.myUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.OJFAHJCHLAI(BJGCPDNMHDH.mainController.opponentUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 7u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 8u:
				if (BJGCPDNMHDH.JNFGIPOFKCF != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JNFGIPOFKCF.JLMDEMFIHCA().JPMEEDEFDOP());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 34;
					}
					break;
				}
				goto case 10u;
			case 9u:
				CardManager.instance.SetBuddyCardsOher(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.PHIGKPODHAN);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -86;
				}
				break;
			case 10u:
				if (BJGCPDNMHDH.KKHKAJPNDEC != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.KKHKAJPNDEC.BEIIOAIJMFK().GAAMHKBJPDL());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -23;
					}
					break;
				}
				goto case 12u;
			case 11u:
				CardManager.instance.SetBuddyCardsOher(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.PHIGKPODHAN);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -96;
				}
				break;
			case 12u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().LoadWeapons());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 75;
				}
				break;
			case 13u:
				Singleton<SoundsManager3D>.instance.LoadSounds();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 40;
				}
				break;
			case 14u:
				Resources.UnloadUnusedAssets();
				DOGHDHGLCDF = Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF;
				PEAAALBMFCA = ObjectPoolDatabase.MFKPDKCLDBI();
				IKOBPOPOHPN = PEAAALBMFCA.CALAKLNMEFF[PEAAALBMFCA.APCGDLEHGKL[DOGHDHGLCDF]];
				KFCAECGLKKO = IKOBPOPOHPN.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						PoolableObject current = KFCAECGLKKO.Current;
						EnemyController enemyController = (EnemyController)current;
						enemyController.transform.position = Singleton<GameCamera>.instance.transform.position + Singleton<GameCamera>.instance.transform.forward * 213f;
						enemyController.enabled = false;
						enemyController.gameObject.SetActive(value: false);
						enemyController.mSoldierAnimationController.Walk(Weapon.IGGFMJAKLGO.Pistol);
						enemyController.gameObject.SetActive(value: false);
						enemyController.enabled = false;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 103;
				}
				break;
			case 15u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 115;
				}
				break;
			case 16u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.mainController.StartGame()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 84;
				}
				break;
			case 17u:
				BJGCPDNMHDH.DIKIPEDCHCF(AEMPHGEIJNH.WaitingForResponse);
				Singleton<GameCamera>.instance.HLLODJKPDPK();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 36;
				}
				break;
			case 18u:
				Time.timeScale = 645f;
				BJGCPDNMHDH.MNMLNIMFMJP = HKGHCIEPGEL.None;
				if (BJGCPDNMHDH.MLDDKLFPFPF != null)
				{
					BJGCPDNMHDH.MLDDKLFPFPF();
				}
				if (BJGCPDNMHDH.OGFHPHILDKC != null)
				{
					BJGCPDNMHDH.OGFHPHILDKC();
				}
				PHDOCKCBJOF = new WaitForSeconds(1022f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -92;
				}
				break;
			case 19u:
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<HudScreen>.instance);
				PHDOCKCBJOF = new WaitForSeconds(801f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 75;
				}
				break;
			case 20u:
			{
				BJGCPDNMHDH.mainController.gameIsRunning = true;
				LoadingDialog.Hide();
				GameController bJGCPDNMHDH = BJGCPDNMHDH;
				if (LGJCBPOPCPA == null)
				{
					LGJCBPOPCPA = EGJBKFPHCNF;
				}
				bJGCPDNMHDH.InvokeAfter(LGJCBPOPCPA, 626f);
				ALJKAAMHHLB.GLEKOOMNAKI("111 STAGE 4 STARTED");
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return true;
			}
			return true;
		}

		public void LDBLCPIGLOF()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object AFAOHBIDOJD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ECJHOPIBAMO()
		{
			return PHDOCKCBJOF;
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

		public bool OKELILGDPLJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Singleton<Recording>.instance.StartRecording();
				Singleton<PerformanceManager>.instance.LCOIHOCJGLF(FIKGLFBFBON: false);
				Singleton<GuiManager>.instance.KAGEFJEJOKE();
				ObjectPoolDatabase.InstantiatePooledObjects(BJGCPDNMHDH.isTutorialInProgressOrPlaned ? NPNOIGHIALL.Tutorial : NPNOIGHIALL.Menu);
				ALJKAAMHHLB.KEJEFPFHIFB("Title Text Font Size");
				Screen.sleepTimeout = -1;
				MatchManager.GODMIAKEFOA(GLFPILGCAPM.GameFinished);
				BJGCPDNMHDH.DIKIPEDCHCF(AEMPHGEIJNH.WaitingForResponse);
				Singleton<Chat>.instance.GBNCCGDBDLJ();
				CamosManager.instance.Null();
				UICamera.instance.cachedCamera.clearFlags = CameraClearFlags.Skybox;
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(value: false);
				TimeManager.Reset();
				BJGCPDNMHDH.KMJGIGDJKMH = KMJGIGDJKMH;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.PODMAPJPBJK());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.mainController.AquireLevelName());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
				BJGCPDNMHDH.gameState = AEMPHGEIJNH.Playing;
				Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.FreeObjectsWithPrefab(Singleton<ObjectPoolDatabase>.instance.JPDFMABBKDI);
				Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.EMLIBBBMNLN(Singleton<ObjectPoolDatabase>.instance.JDNMAKKMPOA);
				PHDOCKCBJOF = new WaitForSeconds(229f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 3u:
				ALJKAAMHHLB.CIILNLBGGHM("-");
				GuiElementSingle<Background>.instance.DestroyParallax();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.PHOFHJGNJKN());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 4u:
				Resources.UnloadUnusedAssets();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<MapManager>.instance.AOFOACBGBOL(BJGCPDNMHDH.KMJGIGDJKMH));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 5u:
				GuiScreenSingle<HudScreen>.instance.gameObject.SetActive(value: false);
				GuiScreenSingle<HudScreen>.instance.KFLNKPBCBDD();
				if (BJGCPDNMHDH.NIEFNMJIAHL != null)
				{
					BJGCPDNMHDH.NIEFNMJIAHL();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.NLOKMAOGIDK(BJGCPDNMHDH.mainController.myUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.ELANPOJLEPN(BJGCPDNMHDH.mainController.opponentUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 7u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 8u:
				if (BJGCPDNMHDH.JNFGIPOFKCF != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JNFGIPOFKCF.JLMDEMFIHCA().MIPLOENBIML());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				goto case 10u;
			case 9u:
				CardManager.instance.SetBuddyCardsOher(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.PHIGKPODHAN);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 93;
				}
				break;
			case 10u:
				if (BJGCPDNMHDH.KKHKAJPNDEC != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.KKHKAJPNDEC.JLMDEMFIHCA().GAAMHKBJPDL());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 29;
					}
					break;
				}
				goto case 12u;
			case 11u:
				CardManager.instance.SetBuddyCardsOher(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.PHIGKPODHAN);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -18;
				}
				break;
			case 12u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PlayerController.OGMBJPKOPCB.weaponInventory.JPMEEDEFDOP());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -57;
				}
				break;
			case 13u:
				Singleton<SoundsManager3D>.instance.AAFOKCOECGJ();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 52;
				}
				break;
			case 14u:
				Resources.UnloadUnusedAssets();
				DOGHDHGLCDF = Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF;
				PEAAALBMFCA = ObjectPoolDatabase.KJEANKAJELG();
				IKOBPOPOHPN = PEAAALBMFCA.CALAKLNMEFF[PEAAALBMFCA.APCGDLEHGKL[DOGHDHGLCDF]];
				KFCAECGLKKO = IKOBPOPOHPN.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						PoolableObject current = KFCAECGLKKO.Current;
						EnemyController enemyController = (EnemyController)current;
						enemyController.transform.position = Singleton<GameCamera>.instance.transform.position + Singleton<GameCamera>.instance.transform.forward * 1851f;
						enemyController.enabled = false;
						enemyController.gameObject.SetActive(value: true);
						enemyController.mSoldierAnimationController.Walk(Weapon.IGGFMJAKLGO.Riffle);
						enemyController.gameObject.SetActive(value: false);
						enemyController.enabled = true;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 14;
				}
				break;
			case 15u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 105;
				}
				break;
			case 16u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.mainController.StartGame()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -31;
				}
				break;
			case 17u:
				BJGCPDNMHDH.gameState = AEMPHGEIJNH.Playing;
				Singleton<GameCamera>.instance.Enable();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 34;
				}
				break;
			case 18u:
				Time.timeScale = 403f;
				BJGCPDNMHDH.MNMLNIMFMJP = HKGHCIEPGEL.None;
				if (BJGCPDNMHDH.MLDDKLFPFPF != null)
				{
					BJGCPDNMHDH.MLDDKLFPFPF();
				}
				if (BJGCPDNMHDH.OGFHPHILDKC != null)
				{
					BJGCPDNMHDH.OGFHPHILDKC();
				}
				PHDOCKCBJOF = new WaitForSeconds(1133f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 56;
				}
				break;
			case 19u:
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<HudScreen>.instance);
				PHDOCKCBJOF = new WaitForSeconds(1959f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 20u:
			{
				BJGCPDNMHDH.mainController.gameIsRunning = false;
				LoadingDialog.Hide();
				GameController bJGCPDNMHDH = BJGCPDNMHDH;
				if (LGJCBPOPCPA == null)
				{
					LGJCBPOPCPA = DGELDDJAEEF;
				}
				bJGCPDNMHDH.InvokeAfter(LGJCBPOPCPA, 1611f);
				ALJKAAMHHLB.HAAIJJBEPPN("Gold");
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return false;
			}
			return true;
		}

		public void PAODBOEOFNF()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IILJADPOOCO()
		{
			return PHDOCKCBJOF;
		}

		public void GEAHPAFNAPJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BJJNGPKNCKJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FIFIOGBLLBE()
		{
			return PHDOCKCBJOF;
		}

		public void GGDBAJJAHNO()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void MDBDGOJADJM()
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
				Singleton<Recording>.instance.StartRecording();
				Singleton<PerformanceManager>.instance.LCOIHOCJGLF(FIKGLFBFBON: false);
				Singleton<GuiManager>.instance.TurnOnInputCompletly();
				ObjectPoolDatabase.OJOAADFNHFN(BJGCPDNMHDH.JLIBMLEFJFE() ? NPNOIGHIALL.Tutorial : NPNOIGHIALL.Menu);
				ALJKAAMHHLB.KFOFCJNFHOL("Error Deserializing JSON for ");
				Screen.sleepTimeout = -1;
				MatchManager.GODMIAKEFOA(GLFPILGCAPM.BothPlayersConnected);
				BJGCPDNMHDH.DIKIPEDCHCF(AEMPHGEIJNH.WaitingForResponse);
				Singleton<Chat>.instance.GHDLHHFMEAC();
				CamosManager.instance.Null();
				UICamera.instance.cachedCamera.clearFlags = CameraClearFlags.Nothing;
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(value: true);
				TimeManager.Reset();
				BJGCPDNMHDH.KMJGIGDJKMH = KMJGIGDJKMH;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.PODMAPJPBJK());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.mainController.AquireLevelName());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 2u:
				BJGCPDNMHDH.gameState = AEMPHGEIJNH.Playing;
				Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.FreeObjectsWithPrefab(Singleton<ObjectPoolDatabase>.instance.JPDFMABBKDI);
				Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.NDPKMHDALCM(Singleton<ObjectPoolDatabase>.instance.JDNMAKKMPOA);
				PHDOCKCBJOF = new WaitForSeconds(1573f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 3u:
				ALJKAAMHHLB.PIEBOOFPHPC("menu-assignments-type-kill");
				GuiElementSingle<Background>.instance.DestroyParallax();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.ClearMenuLoadGameCoroutine());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 4u:
				Resources.UnloadUnusedAssets();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<MapManager>.instance.BPMGMIBDLPG(BJGCPDNMHDH.KMJGIGDJKMH));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 5u:
				GuiScreenSingle<HudScreen>.instance.gameObject.SetActive(value: false);
				GuiScreenSingle<HudScreen>.instance.SetTransparent();
				if (BJGCPDNMHDH.NIEFNMJIAHL != null)
				{
					BJGCPDNMHDH.NIEFNMJIAHL();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.PHLEEDHECMI(BJGCPDNMHDH.mainController.myUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.OKHFKDNNLNA(BJGCPDNMHDH.mainController.opponentUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 7u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 8u:
				if (BJGCPDNMHDH.JNFGIPOFKCF != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JNFGIPOFKCF.JLMDEMFIHCA().JPMEEDEFDOP());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -109;
					}
					break;
				}
				goto case 10u;
			case 9u:
				CardManager.instance.SetBuddyCardsOher(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.PHIGKPODHAN);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -107;
				}
				break;
			case 10u:
				if (BJGCPDNMHDH.KKHKAJPNDEC != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.KKHKAJPNDEC.weaponInventory.OHHOPMCFLJJ());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -123;
					}
					break;
				}
				goto case 12u;
			case 11u:
				CardManager.instance.SetBuddyCardsOher(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.PHIGKPODHAN);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 57;
				}
				break;
			case 12u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().GAAMHKBJPDL());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -71;
				}
				break;
			case 13u:
				Singleton<SoundsManager3D>.instance.GCOKDIOKPKG();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -39;
				}
				break;
			case 14u:
				Resources.UnloadUnusedAssets();
				DOGHDHGLCDF = Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF;
				PEAAALBMFCA = ObjectPoolDatabase.KKCMCNCCIMB();
				IKOBPOPOHPN = PEAAALBMFCA.CALAKLNMEFF[PEAAALBMFCA.APCGDLEHGKL[DOGHDHGLCDF]];
				KFCAECGLKKO = IKOBPOPOHPN.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						PoolableObject current = KFCAECGLKKO.Current;
						EnemyController enemyController = (EnemyController)current;
						enemyController.transform.position = Singleton<GameCamera>.instance.transform.position + Singleton<GameCamera>.instance.transform.forward * 830f;
						enemyController.enabled = false;
						enemyController.gameObject.SetActive(value: false);
						enemyController.mSoldierAnimationController.Walk(Weapon.IGGFMJAKLGO.Minigun);
						enemyController.gameObject.SetActive(value: true);
						enemyController.enabled = false;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 48;
				}
				break;
			case 15u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 82;
				}
				break;
			case 16u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.mainController.StartGame()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 109;
				}
				break;
			case 17u:
				BJGCPDNMHDH.DIKIPEDCHCF((AEMPHGEIJNH)8);
				Singleton<GameCamera>.instance.HLLODJKPDPK();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -7;
				}
				break;
			case 18u:
				Time.timeScale = 1452f;
				BJGCPDNMHDH.MNMLNIMFMJP = HKGHCIEPGEL.None;
				if (BJGCPDNMHDH.MLDDKLFPFPF != null)
				{
					BJGCPDNMHDH.MLDDKLFPFPF();
				}
				if (BJGCPDNMHDH.OGFHPHILDKC != null)
				{
					BJGCPDNMHDH.OGFHPHILDKC();
				}
				PHDOCKCBJOF = new WaitForSeconds(133f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -27;
				}
				break;
			case 19u:
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<HudScreen>.instance);
				PHDOCKCBJOF = new WaitForSeconds(858f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 94;
				}
				break;
			case 20u:
			{
				BJGCPDNMHDH.mainController.gameIsRunning = false;
				LoadingDialog.Hide();
				GameController bJGCPDNMHDH = BJGCPDNMHDH;
				if (LGJCBPOPCPA == null)
				{
					LGJCBPOPCPA = FLHHIKGAEDM;
				}
				bJGCPDNMHDH.InvokeAfter(LGJCBPOPCPA, 1848f);
				ALJKAAMHHLB.BCPKGMMMOPH("-[0-9]*$");
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object ONLMGMBKGHI()
		{
			return PHDOCKCBJOF;
		}

		public void PDKPELBIAON()
		{
			throw new NotSupportedException();
		}

		public void HBHILKGDCMG()
		{
			throw new NotSupportedException();
		}

		public void HEOPOOMLPJF()
		{
			throw new NotSupportedException();
		}

		public void JFPPMJPGGIN()
		{
			throw new NotSupportedException();
		}

		public void GFGEEFGMNDP()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BGLDNJLBIKM()
		{
			return PHDOCKCBJOF;
		}

		public void MHKKAFGKBJK()
		{
			throw new NotSupportedException();
		}

		public void KCHOLCGBMBJ()
		{
			throw new NotSupportedException();
		}

		public void PPHBGPPJBNK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void CDIJEGGMMAK()
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
				Singleton<Recording>.instance.FOJIDINENDK();
				Singleton<PerformanceManager>.instance.AOBNCIOGFKA(FIKGLFBFBON: true);
				Singleton<GuiManager>.instance.TurnOnInputCompletly();
				ObjectPoolDatabase.EOGLFOKEDPF(BJGCPDNMHDH.isTutorialInProgressOrPlaned ? NPNOIGHIALL.Tutorial : NPNOIGHIALL.Menu);
				ALJKAAMHHLB.EGLIMGAEPGI(" ");
				Screen.sleepTimeout = -1;
				MatchManager.matchState = GLFPILGCAPM.GameCancelled;
				BJGCPDNMHDH.gameState = AEMPHGEIJNH.WaitingForResponse;
				Singleton<Chat>.instance.JFMAHJBIOCE();
				CamosManager.instance.Null();
				UICamera.instance.cachedCamera.clearFlags = (CameraClearFlags)5;
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(value: true);
				TimeManager.Reset();
				BJGCPDNMHDH.KMJGIGDJKMH = KMJGIGDJKMH;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.WaitForServerResponse());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.mainController.AquireLevelName());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 2u:
				BJGCPDNMHDH.DIKIPEDCHCF((AEMPHGEIJNH)5);
				Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.NDPKMHDALCM(Singleton<ObjectPoolDatabase>.instance.JPDFMABBKDI);
				Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.EMLIBBBMNLN(Singleton<ObjectPoolDatabase>.instance.JDNMAKKMPOA);
				PHDOCKCBJOF = new WaitForSeconds(394f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 3u:
				ALJKAAMHHLB.BCPKGMMMOPH("#PETER# Tutorial Dialog - showing and mHideDialog is set to false");
				GuiElementSingle<Background>.instance.DestroyParallax();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.ClearMenuLoadGameCoroutine());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 4u:
				Resources.UnloadUnusedAssets();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<MapManager>.instance.PEBCGPPNBGE(BJGCPDNMHDH.KMJGIGDJKMH));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 5u:
				GuiScreenSingle<HudScreen>.instance.gameObject.SetActive(value: true);
				GuiScreenSingle<HudScreen>.instance.OEOPELJAFED();
				if (BJGCPDNMHDH.NIEFNMJIAHL != null)
				{
					BJGCPDNMHDH.NIEFNMJIAHL();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.PMIBKCKBIME(BJGCPDNMHDH.mainController.myUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.HGPDIMKPINN(BJGCPDNMHDH.mainController.opponentUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 7u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 8u:
				if (BJGCPDNMHDH.JNFGIPOFKCF != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JNFGIPOFKCF.JLMDEMFIHCA().OHHOPMCFLJJ());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -51;
					}
					break;
				}
				goto case 10u;
			case 9u:
				CardManager.instance.SetBuddyCardsOher(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.PHIGKPODHAN);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 116;
				}
				break;
			case 10u:
				if (BJGCPDNMHDH.KKHKAJPNDEC != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.KKHKAJPNDEC.BEIIOAIJMFK().LoadWeapons());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 24;
					}
					break;
				}
				goto case 12u;
			case 11u:
				CardManager.instance.SetBuddyCardsOher(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.PHIGKPODHAN);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -38;
				}
				break;
			case 12u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PlayerController.OGMBJPKOPCB.weaponInventory.MIPLOENBIML());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -110;
				}
				break;
			case 13u:
				Singleton<SoundsManager3D>.instance.LoadSounds();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 88;
				}
				break;
			case 14u:
				Resources.UnloadUnusedAssets();
				DOGHDHGLCDF = Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF;
				PEAAALBMFCA = ObjectPoolDatabase.networkPool;
				IKOBPOPOHPN = PEAAALBMFCA.CALAKLNMEFF[PEAAALBMFCA.APCGDLEHGKL[DOGHDHGLCDF]];
				KFCAECGLKKO = IKOBPOPOHPN.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						PoolableObject current = KFCAECGLKKO.Current;
						EnemyController enemyController = (EnemyController)current;
						enemyController.transform.position = Singleton<GameCamera>.instance.transform.position + Singleton<GameCamera>.instance.transform.forward * 91f;
						enemyController.enabled = false;
						enemyController.gameObject.SetActive(value: false);
						enemyController.mSoldierAnimationController.Walk(Weapon.IGGFMJAKLGO.Tool);
						enemyController.gameObject.SetActive(value: false);
						enemyController.enabled = false;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 41;
				}
				break;
			case 15u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 95;
				}
				break;
			case 16u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.mainController.StartGame()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 69;
				}
				break;
			case 17u:
				BJGCPDNMHDH.gameState = (AEMPHGEIJNH)5;
				Singleton<GameCamera>.instance.HLLODJKPDPK();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 99;
				}
				break;
			case 18u:
				Time.timeScale = 1058f;
				BJGCPDNMHDH.MNMLNIMFMJP = HKGHCIEPGEL.Killed;
				if (BJGCPDNMHDH.MLDDKLFPFPF != null)
				{
					BJGCPDNMHDH.MLDDKLFPFPF();
				}
				if (BJGCPDNMHDH.OGFHPHILDKC != null)
				{
					BJGCPDNMHDH.OGFHPHILDKC();
				}
				PHDOCKCBJOF = new WaitForSeconds(1995f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 71;
				}
				break;
			case 19u:
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<HudScreen>.instance);
				PHDOCKCBJOF = new WaitForSeconds(1179f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -8;
				}
				break;
			case 20u:
			{
				BJGCPDNMHDH.mainController.gameIsRunning = true;
				LoadingDialog.Hide();
				GameController bJGCPDNMHDH = BJGCPDNMHDH;
				if (LGJCBPOPCPA == null)
				{
					LGJCBPOPCPA = BPONFHMBCLK;
				}
				bJGCPDNMHDH.InvokeAfter(LGJCBPOPCPA, 1447f);
				ALJKAAMHHLB.KEJEFPFHIFB("BUYING CARD PACK: type:{0} -> cardType:{1}");
				CLPPIAGLCJJ = -1;
				goto default;
			}
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

		[SpecialName]
		private object NDIGINEEOMH()
		{
			return PHDOCKCBJOF;
		}

		public bool CJGDOJHLOII()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Singleton<Recording>.instance.FOJIDINENDK();
				Singleton<PerformanceManager>.instance.AKNADEPIPNP(FIKGLFBFBON: false);
				Singleton<GuiManager>.instance.TurnOnInputCompletly();
				ObjectPoolDatabase.EOGLFOKEDPF(BJGCPDNMHDH.isTutorialInProgressOrPlaned ? NPNOIGHIALL.Tutorial : NPNOIGHIALL.Menu);
				ALJKAAMHHLB.KFOFCJNFHOL("WRONG NUMBER OF ORDER ");
				Screen.sleepTimeout = -1;
				MatchManager.matchState = GLFPILGCAPM.ConnectingToPhoton;
				BJGCPDNMHDH.DIKIPEDCHCF(AEMPHGEIJNH.WaitingForResponse);
				Singleton<Chat>.instance.JIDBDDJADON();
				CamosManager.instance.Null();
				UICamera.instance.cachedCamera.clearFlags = CameraClearFlags.Depth;
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(value: false);
				TimeManager.Reset();
				BJGCPDNMHDH.KMJGIGDJKMH = KMJGIGDJKMH;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.WaitForServerResponse());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.mainController.AquireLevelName());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 2u:
				BJGCPDNMHDH.DIKIPEDCHCF(AEMPHGEIJNH.Loading);
				Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.FreeObjectsWithPrefab(Singleton<ObjectPoolDatabase>.instance.JPDFMABBKDI);
				Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.EMLIBBBMNLN(Singleton<ObjectPoolDatabase>.instance.JDNMAKKMPOA);
				PHDOCKCBJOF = new WaitForSeconds(379f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 3u:
				ALJKAAMHHLB.CJEDHGLIGJH("game-card-bronze-big");
				GuiElementSingle<Background>.instance.DestroyParallax();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.PHOFHJGNJKN());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 4u:
				Resources.UnloadUnusedAssets();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<MapManager>.instance.BGPOIGKLDJE(BJGCPDNMHDH.KMJGIGDJKMH));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 5u:
				GuiScreenSingle<HudScreen>.instance.gameObject.SetActive(value: false);
				GuiScreenSingle<HudScreen>.instance.SetTransparent();
				if (BJGCPDNMHDH.NIEFNMJIAHL != null)
				{
					BJGCPDNMHDH.NIEFNMJIAHL();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.LoadMineUpgrades(BJGCPDNMHDH.mainController.myUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.JEEGJEPKMKM(BJGCPDNMHDH.mainController.opponentUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 7u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 8u:
				if (BJGCPDNMHDH.JNFGIPOFKCF != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JNFGIPOFKCF.BEIIOAIJMFK().LoadWeapons());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				goto case 10u;
			case 9u:
				CardManager.instance.SetBuddyCardsOher(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.PHIGKPODHAN);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -75;
				}
				break;
			case 10u:
				if (BJGCPDNMHDH.KKHKAJPNDEC != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.KKHKAJPNDEC.weaponInventory.MIPLOENBIML());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -114;
					}
					break;
				}
				goto case 12u;
			case 11u:
				CardManager.instance.SetBuddyCardsOher(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.PHIGKPODHAN);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -72;
				}
				break;
			case 12u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().MIPLOENBIML());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -107;
				}
				break;
			case 13u:
				Singleton<SoundsManager3D>.instance.IBAHNGKDCPA();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -115;
				}
				break;
			case 14u:
				Resources.UnloadUnusedAssets();
				DOGHDHGLCDF = Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF;
				PEAAALBMFCA = ObjectPoolDatabase.INOJHPIKICM();
				IKOBPOPOHPN = PEAAALBMFCA.CALAKLNMEFF[PEAAALBMFCA.APCGDLEHGKL[DOGHDHGLCDF]];
				KFCAECGLKKO = IKOBPOPOHPN.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						PoolableObject current = KFCAECGLKKO.Current;
						EnemyController enemyController = (EnemyController)current;
						enemyController.transform.position = Singleton<GameCamera>.instance.transform.position + Singleton<GameCamera>.instance.transform.forward * 1047f;
						enemyController.enabled = false;
						enemyController.gameObject.SetActive(value: true);
						enemyController.mSoldierAnimationController.Walk(Weapon.IGGFMJAKLGO.GrenadeLauncher);
						enemyController.gameObject.SetActive(value: true);
						enemyController.enabled = true;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 15u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 56;
				}
				break;
			case 16u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.mainController.StartGame()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -63;
				}
				break;
			case 17u:
				BJGCPDNMHDH.DIKIPEDCHCF((AEMPHGEIJNH)4);
				Singleton<GameCamera>.instance.HLLODJKPDPK();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -127;
				}
				break;
			case 18u:
				Time.timeScale = 1007f;
				BJGCPDNMHDH.MNMLNIMFMJP = HKGHCIEPGEL.None;
				if (BJGCPDNMHDH.MLDDKLFPFPF != null)
				{
					BJGCPDNMHDH.MLDDKLFPFPF();
				}
				if (BJGCPDNMHDH.OGFHPHILDKC != null)
				{
					BJGCPDNMHDH.OGFHPHILDKC();
				}
				PHDOCKCBJOF = new WaitForSeconds(930f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 28;
				}
				break;
			case 19u:
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<HudScreen>.instance);
				PHDOCKCBJOF = new WaitForSeconds(213f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -38;
				}
				break;
			case 20u:
			{
				BJGCPDNMHDH.mainController.gameIsRunning = true;
				LoadingDialog.Hide();
				GameController bJGCPDNMHDH = BJGCPDNMHDH;
				if (LGJCBPOPCPA == null)
				{
					LGJCBPOPCPA = NNIJEDKBPGJ;
				}
				bJGCPDNMHDH.InvokeAfter(LGJCBPOPCPA, 1322f);
				ALJKAAMHHLB.CIILNLBGGHM("ID_GETFORPROMOTION1");
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return true;
			}
			return false;
		}

		public bool APJNFAOFAFD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Singleton<Recording>.instance.GCLOFJDCMON();
				Singleton<PerformanceManager>.instance.MBIALLFNEFO(FIKGLFBFBON: false);
				Singleton<GuiManager>.instance.KAGEFJEJOKE();
				ObjectPoolDatabase.DJBHEMBOCDC(BJGCPDNMHDH.isTutorialInProgressOrPlaned ? NPNOIGHIALL.Tutorial : ((NPNOIGHIALL)7));
				ALJKAAMHHLB.ACPILMDBDKH("RateOfFire");
				Screen.sleepTimeout = -1;
				MatchManager.GODMIAKEFOA((GLFPILGCAPM)7);
				BJGCPDNMHDH.DIKIPEDCHCF(AEMPHGEIJNH.WaitingForResponse);
				Singleton<Chat>.instance.MODCIBKGJBF();
				CamosManager.instance.Null();
				UICamera.instance.cachedCamera.clearFlags = (CameraClearFlags)6;
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(value: false);
				TimeManager.Reset();
				BJGCPDNMHDH.KMJGIGDJKMH = KMJGIGDJKMH;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.WaitForServerResponse());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.mainController.AquireLevelName());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
				BJGCPDNMHDH.gameState = AEMPHGEIJNH.Loading;
				Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.EMLIBBBMNLN(Singleton<ObjectPoolDatabase>.instance.JPDFMABBKDI);
				Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.FreeObjectsWithPrefab(Singleton<ObjectPoolDatabase>.instance.JDNMAKKMPOA);
				PHDOCKCBJOF = new WaitForSeconds(764f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 3u:
				ALJKAAMHHLB.BIDJNBKOMIN("EnviromentalHitRPC");
				GuiElementSingle<Background>.instance.DestroyParallax();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.ClearMenuLoadGameCoroutine());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 4u:
				Resources.UnloadUnusedAssets();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<MapManager>.instance.ENMIHJIEPGF(BJGCPDNMHDH.KMJGIGDJKMH));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 5u:
				GuiScreenSingle<HudScreen>.instance.gameObject.SetActive(value: false);
				GuiScreenSingle<HudScreen>.instance.KFLNKPBCBDD();
				if (BJGCPDNMHDH.NIEFNMJIAHL != null)
				{
					BJGCPDNMHDH.NIEFNMJIAHL();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.MKMJAPMBMLH(BJGCPDNMHDH.mainController.myUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.OJFAHJCHLAI(BJGCPDNMHDH.mainController.opponentUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 7u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 8u:
				if (BJGCPDNMHDH.JNFGIPOFKCF != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JNFGIPOFKCF.BEIIOAIJMFK().OHHOPMCFLJJ());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -60;
					}
					break;
				}
				goto case 10u;
			case 9u:
				CardManager.instance.SetBuddyCardsOher(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.PHIGKPODHAN);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -60;
				}
				break;
			case 10u:
				if (BJGCPDNMHDH.KKHKAJPNDEC != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.KKHKAJPNDEC.FMKGGADDHJK().MIPLOENBIML());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -60;
					}
					break;
				}
				goto case 12u;
			case 11u:
				CardManager.instance.SetBuddyCardsOher(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.PHIGKPODHAN);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 121;
				}
				break;
			case 12u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().LoadWeapons());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -68;
				}
				break;
			case 13u:
				Singleton<SoundsManager3D>.instance.LoadSounds();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 11;
				}
				break;
			case 14u:
				Resources.UnloadUnusedAssets();
				DOGHDHGLCDF = Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF;
				PEAAALBMFCA = ObjectPoolDatabase.INOJHPIKICM();
				IKOBPOPOHPN = PEAAALBMFCA.CALAKLNMEFF[PEAAALBMFCA.APCGDLEHGKL[DOGHDHGLCDF]];
				KFCAECGLKKO = IKOBPOPOHPN.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						PoolableObject current = KFCAECGLKKO.Current;
						EnemyController enemyController = (EnemyController)current;
						enemyController.transform.position = Singleton<GameCamera>.instance.transform.position + Singleton<GameCamera>.instance.transform.forward * 377f;
						enemyController.enabled = false;
						enemyController.gameObject.SetActive(value: false);
						enemyController.mSoldierAnimationController.Walk(Weapon.IGGFMJAKLGO.SwatPistol);
						enemyController.gameObject.SetActive(value: false);
						enemyController.enabled = false;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -91;
				}
				break;
			case 15u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -111;
				}
				break;
			case 16u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.mainController.StartGame()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 73;
				}
				break;
			case 17u:
				BJGCPDNMHDH.DIKIPEDCHCF((AEMPHGEIJNH)6);
				Singleton<GameCamera>.instance.Enable();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -97;
				}
				break;
			case 18u:
				Time.timeScale = 1555f;
				BJGCPDNMHDH.MNMLNIMFMJP = HKGHCIEPGEL.None;
				if (BJGCPDNMHDH.MLDDKLFPFPF != null)
				{
					BJGCPDNMHDH.MLDDKLFPFPF();
				}
				if (BJGCPDNMHDH.OGFHPHILDKC != null)
				{
					BJGCPDNMHDH.OGFHPHILDKC();
				}
				PHDOCKCBJOF = new WaitForSeconds(1735f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -28;
				}
				break;
			case 19u:
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<HudScreen>.instance);
				PHDOCKCBJOF = new WaitForSeconds(1433f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 29;
				}
				break;
			case 20u:
			{
				BJGCPDNMHDH.mainController.gameIsRunning = true;
				LoadingDialog.Hide();
				GameController bJGCPDNMHDH = BJGCPDNMHDH;
				if (LGJCBPOPCPA == null)
				{
					LGJCBPOPCPA = DGELDDJAEEF;
				}
				bJGCPDNMHDH.InvokeAfter(LGJCBPOPCPA, 1696f);
				ALJKAAMHHLB.CCDJDGFFCHC("104 STAGE 1 COVER 1");
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return true;
			}
			return true;
		}

		public void AJEIGCJPEFN()
		{
			throw new NotSupportedException();
		}

		public void AKLMKDOIDHP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		private static void ILOFOILFGMA()
		{
			AFPSCounter.Instance.fpsCounter.ResetMinMax();
			AFPSCounter.Instance.fpsCounter.ResetAverage();
		}

		public bool GPIPJIDGCKM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Singleton<Recording>.instance.FOJIDINENDK();
				Singleton<PerformanceManager>.instance.KHEDGHEHPLK(FIKGLFBFBON: false);
				Singleton<GuiManager>.instance.AOGOJDGBMMD();
				ObjectPoolDatabase.KHLPFECMGCL((!BJGCPDNMHDH.isTutorialInProgressOrPlaned) ? ((NPNOIGHIALL)8) : NPNOIGHIALL.Init);
				ALJKAAMHHLB.ACPILMDBDKH("bot-");
				Screen.sleepTimeout = -1;
				MatchManager.matchState = (GLFPILGCAPM)8;
				BJGCPDNMHDH.DIKIPEDCHCF(AEMPHGEIJNH.WaitingForResponse);
				Singleton<Chat>.instance.GBNCCGDBDLJ();
				CamosManager.instance.Null();
				UICamera.instance.cachedCamera.clearFlags = (CameraClearFlags)8;
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(value: true);
				TimeManager.GEEKOICFEIB();
				BJGCPDNMHDH.KMJGIGDJKMH = KMJGIGDJKMH;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.PODMAPJPBJK());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.mainController.AquireLevelName());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 2u:
				BJGCPDNMHDH.DIKIPEDCHCF((AEMPHGEIJNH)4);
				Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.NDPKMHDALCM(Singleton<ObjectPoolDatabase>.instance.JPDFMABBKDI);
				Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.EMLIBBBMNLN(Singleton<ObjectPoolDatabase>.instance.JDNMAKKMPOA);
				PHDOCKCBJOF = new WaitForSeconds(1194f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 3u:
				ALJKAAMHHLB.GLEKOOMNAKI("ID_DAYS");
				GuiElementSingle<Background>.instance.DestroyParallax();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.ClearMenuLoadGameCoroutine());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 4u:
				Resources.UnloadUnusedAssets();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<MapManager>.instance.PEBCGPPNBGE(BJGCPDNMHDH.KMJGIGDJKMH));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 5u:
				GuiScreenSingle<HudScreen>.instance.gameObject.SetActive(value: false);
				GuiScreenSingle<HudScreen>.instance.PBAOFHDILFK();
				if (BJGCPDNMHDH.NIEFNMJIAHL != null)
				{
					BJGCPDNMHDH.NIEFNMJIAHL();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.HAMMNLGJFON(BJGCPDNMHDH.mainController.myUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.ELANPOJLEPN(BJGCPDNMHDH.mainController.opponentUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 7u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 8u:
				if (BJGCPDNMHDH.JNFGIPOFKCF != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JNFGIPOFKCF.weaponInventory.OHHOPMCFLJJ());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -46;
					}
					break;
				}
				goto case 10u;
			case 9u:
				CardManager.instance.SetBuddyCardsOher(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.PHIGKPODHAN);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -32;
				}
				break;
			case 10u:
				if (BJGCPDNMHDH.KKHKAJPNDEC != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.KKHKAJPNDEC.JLMDEMFIHCA().MIPLOENBIML());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -98;
					}
					break;
				}
				goto case 12u;
			case 11u:
				CardManager.instance.SetBuddyCardsOher(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.PHIGKPODHAN);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 112;
				}
				break;
			case 12u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().JPMEEDEFDOP());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -108;
				}
				break;
			case 13u:
				Singleton<SoundsManager3D>.instance.IBAHNGKDCPA();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -95;
				}
				break;
			case 14u:
				Resources.UnloadUnusedAssets();
				DOGHDHGLCDF = Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF;
				PEAAALBMFCA = ObjectPoolDatabase.DKNHCGGKNMF();
				IKOBPOPOHPN = PEAAALBMFCA.CALAKLNMEFF[PEAAALBMFCA.APCGDLEHGKL[DOGHDHGLCDF]];
				KFCAECGLKKO = IKOBPOPOHPN.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						PoolableObject current = KFCAECGLKKO.Current;
						EnemyController enemyController = (EnemyController)current;
						enemyController.transform.position = Singleton<GameCamera>.instance.transform.position + Singleton<GameCamera>.instance.transform.forward * 1316f;
						enemyController.enabled = false;
						enemyController.gameObject.SetActive(value: false);
						enemyController.mSoldierAnimationController.Walk(Weapon.IGGFMJAKLGO.Pistol);
						enemyController.gameObject.SetActive(value: false);
						enemyController.enabled = false;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 43;
				}
				break;
			case 15u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 82;
				}
				break;
			case 16u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.mainController.StartGame()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -116;
				}
				break;
			case 17u:
				BJGCPDNMHDH.gameState = (AEMPHGEIJNH)5;
				Singleton<GameCamera>.instance.HLLODJKPDPK();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -86;
				}
				break;
			case 18u:
				Time.timeScale = 696f;
				BJGCPDNMHDH.MNMLNIMFMJP = HKGHCIEPGEL.Killed;
				if (BJGCPDNMHDH.MLDDKLFPFPF != null)
				{
					BJGCPDNMHDH.MLDDKLFPFPF();
				}
				if (BJGCPDNMHDH.OGFHPHILDKC != null)
				{
					BJGCPDNMHDH.OGFHPHILDKC();
				}
				PHDOCKCBJOF = new WaitForSeconds(573f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -7;
				}
				break;
			case 19u:
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<HudScreen>.instance);
				PHDOCKCBJOF = new WaitForSeconds(1129f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 94;
				}
				break;
			case 20u:
			{
				BJGCPDNMHDH.mainController.gameIsRunning = true;
				LoadingDialog.Hide();
				GameController bJGCPDNMHDH = BJGCPDNMHDH;
				if (LGJCBPOPCPA == null)
				{
					LGJCBPOPCPA = EGJBKFPHCNF;
				}
				bJGCPDNMHDH.InvokeAfter(LGJCBPOPCPA, 1130f);
				ALJKAAMHHLB.CJEDHGLIGJH("ID_INSTANTBATTLEHINT2");
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return true;
			}
			return true;
		}

		public void LHADJAFHDDC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool ACHIHMMCDNF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Singleton<Recording>.instance.GCLOFJDCMON();
				Singleton<PerformanceManager>.instance.SetShadowsDistance(FIKGLFBFBON: true);
				Singleton<GuiManager>.instance.TurnOnInputCompletly();
				ObjectPoolDatabase.OJOAADFNHFN(BJGCPDNMHDH.isTutorialInProgressOrPlaned ? NPNOIGHIALL.Tutorial : ((NPNOIGHIALL)7));
				ALJKAAMHHLB.KEJEFPFHIFB("ID_GUI_BEADVISED");
				Screen.sleepTimeout = -1;
				MatchManager.GODMIAKEFOA((GLFPILGCAPM)8);
				BJGCPDNMHDH.gameState = AEMPHGEIJNH.WaitingForResponse;
				Singleton<Chat>.instance.GBNCCGDBDLJ();
				CamosManager.instance.Null();
				UICamera.instance.cachedCamera.clearFlags = (CameraClearFlags)0;
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(value: true);
				TimeManager.Reset();
				BJGCPDNMHDH.KMJGIGDJKMH = KMJGIGDJKMH;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.WaitForServerResponse());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.mainController.AquireLevelName());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 2u:
				BJGCPDNMHDH.DIKIPEDCHCF(AEMPHGEIJNH.Loading);
				Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.NDPKMHDALCM(Singleton<ObjectPoolDatabase>.instance.JPDFMABBKDI);
				Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.NDPKMHDALCM(Singleton<ObjectPoolDatabase>.instance.JDNMAKKMPOA);
				PHDOCKCBJOF = new WaitForSeconds(118f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 3u:
				ALJKAAMHHLB.CCDJDGFFCHC("ID_CONFIRM_NOSKIRMISHAVAILABLE");
				GuiElementSingle<Background>.instance.DestroyParallax();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.ClearMenuLoadGameCoroutine());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 4u:
				Resources.UnloadUnusedAssets();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<MapManager>.instance.BGPOIGKLDJE(BJGCPDNMHDH.KMJGIGDJKMH));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 5u:
				GuiScreenSingle<HudScreen>.instance.gameObject.SetActive(value: true);
				GuiScreenSingle<HudScreen>.instance.SetTransparent();
				if (BJGCPDNMHDH.NIEFNMJIAHL != null)
				{
					BJGCPDNMHDH.NIEFNMJIAHL();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.NLIALMAJDAF(BJGCPDNMHDH.mainController.myUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.INPOHMCEPNK(BJGCPDNMHDH.mainController.opponentUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 7u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 8u:
				if (BJGCPDNMHDH.JNFGIPOFKCF != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JNFGIPOFKCF.BEIIOAIJMFK().JPMEEDEFDOP());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -73;
					}
					break;
				}
				goto case 10u;
			case 9u:
				CardManager.instance.SetBuddyCardsOher(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.PHIGKPODHAN);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 104;
				}
				break;
			case 10u:
				if (BJGCPDNMHDH.KKHKAJPNDEC != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.KKHKAJPNDEC.FMKGGADDHJK().LoadWeapons());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -28;
					}
					break;
				}
				goto case 12u;
			case 11u:
				CardManager.instance.SetBuddyCardsOher(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.PHIGKPODHAN);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 101;
				}
				break;
			case 12u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PlayerController.OGMBJPKOPCB.JLMDEMFIHCA().MIPLOENBIML());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 54;
				}
				break;
			case 13u:
				Singleton<SoundsManager3D>.instance.LOBFOCCGGHB();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 110;
				}
				break;
			case 14u:
				Resources.UnloadUnusedAssets();
				DOGHDHGLCDF = Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF;
				PEAAALBMFCA = ObjectPoolDatabase.KJEANKAJELG();
				IKOBPOPOHPN = PEAAALBMFCA.CALAKLNMEFF[PEAAALBMFCA.APCGDLEHGKL[DOGHDHGLCDF]];
				KFCAECGLKKO = IKOBPOPOHPN.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						PoolableObject current = KFCAECGLKKO.Current;
						EnemyController enemyController = (EnemyController)current;
						enemyController.transform.position = Singleton<GameCamera>.instance.transform.position + Singleton<GameCamera>.instance.transform.forward * 621f;
						enemyController.enabled = true;
						enemyController.gameObject.SetActive(value: false);
						enemyController.mSoldierAnimationController.Walk(Weapon.IGGFMJAKLGO.Tool);
						enemyController.gameObject.SetActive(value: true);
						enemyController.enabled = true;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -17;
				}
				break;
			case 15u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 78;
				}
				break;
			case 16u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.mainController.StartGame()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -74;
				}
				break;
			case 17u:
				BJGCPDNMHDH.gameState = AEMPHGEIJNH.Loading;
				Singleton<GameCamera>.instance.Enable();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -4;
				}
				break;
			case 18u:
				Time.timeScale = 1545f;
				BJGCPDNMHDH.MNMLNIMFMJP = HKGHCIEPGEL.Killed;
				if (BJGCPDNMHDH.MLDDKLFPFPF != null)
				{
					BJGCPDNMHDH.MLDDKLFPFPF();
				}
				if (BJGCPDNMHDH.OGFHPHILDKC != null)
				{
					BJGCPDNMHDH.OGFHPHILDKC();
				}
				PHDOCKCBJOF = new WaitForSeconds(938f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -43;
				}
				break;
			case 19u:
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<HudScreen>.instance);
				PHDOCKCBJOF = new WaitForSeconds(517f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 86;
				}
				break;
			case 20u:
			{
				BJGCPDNMHDH.mainController.gameIsRunning = false;
				LoadingDialog.Hide();
				GameController bJGCPDNMHDH = BJGCPDNMHDH;
				if (LGJCBPOPCPA == null)
				{
					LGJCBPOPCPA = ILOFOILFGMA;
				}
				bJGCPDNMHDH.InvokeAfter(LGJCBPOPCPA, 1235f);
				ALJKAAMHHLB.ALPPDLMMCIH("Play_Card_Tutorial_Duration");
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object JFGCHMJJMNO()
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
				Singleton<Recording>.instance.StartRecording();
				Singleton<PerformanceManager>.instance.CLABLOFKMGA(FIKGLFBFBON: false);
				Singleton<GuiManager>.instance.KAGEFJEJOKE();
				ObjectPoolDatabase.OJOAADFNHFN((!BJGCPDNMHDH.isTutorialInProgressOrPlaned) ? NPNOIGHIALL.Tutorial : NPNOIGHIALL.Init);
				ALJKAAMHHLB.BIDJNBKOMIN("{0}\u00a0{1}");
				Screen.sleepTimeout = -1;
				MatchManager.JKLPOGEGDNH((GLFPILGCAPM)7);
				BJGCPDNMHDH.gameState = AEMPHGEIJNH.WaitingForResponse;
				Singleton<Chat>.instance.GBNCCGDBDLJ();
				CamosManager.instance.Null();
				UICamera.instance.cachedCamera.clearFlags = (CameraClearFlags)5;
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(value: false);
				TimeManager.Reset();
				BJGCPDNMHDH.KMJGIGDJKMH = KMJGIGDJKMH;
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.PODMAPJPBJK());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.mainController.AquireLevelName());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 2u:
				BJGCPDNMHDH.gameState = (AEMPHGEIJNH)5;
				Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.EMLIBBBMNLN(Singleton<ObjectPoolDatabase>.instance.JPDFMABBKDI);
				Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.EMLIBBBMNLN(Singleton<ObjectPoolDatabase>.instance.JDNMAKKMPOA);
				PHDOCKCBJOF = new WaitForSeconds(1698f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 3u:
				ALJKAAMHHLB.IEBHKBNOEBP("DogTagCap");
				GuiElementSingle<Background>.instance.DestroyParallax();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.PHOFHJGNJKN());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 4u:
				Resources.UnloadUnusedAssets();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<MapManager>.instance.HLACPPKNDNP(BJGCPDNMHDH.KMJGIGDJKMH));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 5u:
				GuiScreenSingle<HudScreen>.instance.gameObject.SetActive(value: true);
				GuiScreenSingle<HudScreen>.instance.NLBOJLHBFDM();
				if (BJGCPDNMHDH.NIEFNMJIAHL != null)
				{
					BJGCPDNMHDH.NIEFNMJIAHL();
				}
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.HAMMNLGJFON(BJGCPDNMHDH.mainController.myUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 6u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<UpgradesManager>.instance.MEJDHGEOJFM(BJGCPDNMHDH.mainController.opponentUpgrades));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 7u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 8u:
				if (BJGCPDNMHDH.JNFGIPOFKCF != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JNFGIPOFKCF.FMKGGADDHJK().OHHOPMCFLJJ());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 75;
					}
					break;
				}
				goto case 10u;
			case 9u:
				CardManager.instance.SetBuddyCardsOher(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.PHIGKPODHAN);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: false));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -70;
				}
				break;
			case 10u:
				if (BJGCPDNMHDH.KKHKAJPNDEC != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.KKHKAJPNDEC.JLMDEMFIHCA().JPMEEDEFDOP());
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -81;
					}
					break;
				}
				goto case 12u;
			case 11u:
				CardManager.instance.SetBuddyCardsOher(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.PHIGKPODHAN);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(CardManager.instance.InitGameCards(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: true));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -58;
				}
				break;
			case 12u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(PlayerController.OGMBJPKOPCB.FMKGGADDHJK().GAAMHKBJPDL());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -92;
				}
				break;
			case 13u:
				Singleton<SoundsManager3D>.instance.AAFOKCOECGJ();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 58;
				}
				break;
			case 14u:
				Resources.UnloadUnusedAssets();
				DOGHDHGLCDF = Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF;
				PEAAALBMFCA = ObjectPoolDatabase.MFKPDKCLDBI();
				IKOBPOPOHPN = PEAAALBMFCA.CALAKLNMEFF[PEAAALBMFCA.APCGDLEHGKL[DOGHDHGLCDF]];
				KFCAECGLKKO = IKOBPOPOHPN.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						PoolableObject current = KFCAECGLKKO.Current;
						EnemyController enemyController = (EnemyController)current;
						enemyController.transform.position = Singleton<GameCamera>.instance.transform.position + Singleton<GameCamera>.instance.transform.forward * 1534f;
						enemyController.enabled = true;
						enemyController.gameObject.SetActive(value: false);
						enemyController.mSoldierAnimationController.Walk(Weapon.IGGFMJAKLGO.Minigun);
						enemyController.gameObject.SetActive(value: false);
						enemyController.enabled = false;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -125;
				}
				break;
			case 15u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -107;
				}
				break;
			case 16u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.mainController.StartGame()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 58;
				}
				break;
			case 17u:
				BJGCPDNMHDH.DIKIPEDCHCF(AEMPHGEIJNH.Loading);
				Singleton<GameCamera>.instance.Enable();
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 113;
				}
				break;
			case 18u:
				Time.timeScale = 284f;
				BJGCPDNMHDH.MNMLNIMFMJP = HKGHCIEPGEL.Killed;
				if (BJGCPDNMHDH.MLDDKLFPFPF != null)
				{
					BJGCPDNMHDH.MLDDKLFPFPF();
				}
				if (BJGCPDNMHDH.OGFHPHILDKC != null)
				{
					BJGCPDNMHDH.OGFHPHILDKC();
				}
				PHDOCKCBJOF = new WaitForSeconds(450f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -23;
				}
				break;
			case 19u:
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<HudScreen>.instance);
				PHDOCKCBJOF = new WaitForSeconds(803f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -27;
				}
				break;
			case 20u:
			{
				BJGCPDNMHDH.mainController.gameIsRunning = true;
				LoadingDialog.Hide();
				GameController bJGCPDNMHDH = BJGCPDNMHDH;
				if (LGJCBPOPCPA == null)
				{
					LGJCBPOPCPA = APHOLLLLNCG;
				}
				bJGCPDNMHDH.InvokeAfter(LGJCBPOPCPA, 1885f);
				ALJKAAMHHLB.PIEBOOFPHPC("ID_MYWARCARDS");
				CLPPIAGLCJJ = -1;
				goto default;
			}
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object JKKAEPEAGNP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JFHOHPKEFGM()
		{
			return PHDOCKCBJOF;
		}
	}

	private sealed class APOEGAMPAFA : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal GameController BJGCPDNMHDH;

		internal object PHDOCKCBJOF;

		internal bool FDKOKMKIIMG;

		internal int CLPPIAGLCJJ;

		private static Action LGJCBPOPCPA;

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

		public void CFDAGFGOOIE()
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
			case 1u:
			{
				bool? gJFHKPIHDCH = BJGCPDNMHDH.GJFHKPIHDCH;
				if (!gJFHKPIHDCH.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				bool? gJFHKPIHDCH2 = BJGCPDNMHDH.GJFHKPIHDCH;
				if (gJFHKPIHDCH2 == true && !gJFHKPIHDCH2.HasValue)
				{
					string hOLNKOFHDNK = Localization.Localize("ID_WARNING_MAINTENANCE");
					string oKMNFHNBMFA = Localization.Localize("ID_INCHAMPION1");
					if (LGJCBPOPCPA == null)
					{
						LGJCBPOPCPA = GGJDILDIFPJ;
					}
					WarningDialog.ShowError(hOLNKOFHDNK, oKMNFHNBMFA, 982f, LGJCBPOPCPA, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
					BJGCPDNMHDH.TryStopLoading();
					BJGCPDNMHDH.Quit();
					if ((bool)(BJGCPDNMHDH.mainController as GameControllerOnline))
					{
						((GameControllerOnline)BJGCPDNMHDH.mainController).Disconnect();
					}
					CLPPIAGLCJJ = -1;
				}
				goto default;
			}
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object DOOAHBLHGFO()
		{
			return PHDOCKCBJOF;
		}

		public void EPKPNKGJHEC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool BGOEENAEBNO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
			{
				bool? gJFHKPIHDCH = BJGCPDNMHDH.GJFHKPIHDCH;
				if (gJFHKPIHDCH.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				bool? gJFHKPIHDCH2 = BJGCPDNMHDH.GJFHKPIHDCH;
				if (gJFHKPIHDCH2 == true && !gJFHKPIHDCH2.HasValue)
				{
					string hOLNKOFHDNK = Localization.Localize("RETRYPERM");
					string oKMNFHNBMFA = Localization.Localize(".");
					if (LGJCBPOPCPA == null)
					{
						LGJCBPOPCPA = NGMELCCIEHN;
					}
					WarningDialog.ShowError(hOLNKOFHDNK, oKMNFHNBMFA, 109f, LGJCBPOPCPA, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
					BJGCPDNMHDH.TryStopLoading();
					BJGCPDNMHDH.HGBNEFDBFDC();
					if ((bool)(BJGCPDNMHDH.mainController as GameControllerOnline))
					{
						((GameControllerOnline)BJGCPDNMHDH.mainController).Disconnect();
					}
					CLPPIAGLCJJ = -1;
				}
				goto default;
			}
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object HMIFLGCBDCO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BLNNEJILEIE()
		{
			return PHDOCKCBJOF;
		}

		public void HJLCPFDBNKP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void MDBDGOJADJM()
		{
			throw new NotSupportedException();
		}

		private static void NNFHNIMCBLH()
		{
			Singleton<BeanstalkServerManager>.instance.BKPEOBBLCNG();
			GameLoginManager.Relog(showScreen: false);
		}

		private static void NGMELCCIEHN()
		{
			Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
			GameLoginManager.Relog(showScreen: false);
		}

		[SpecialName]
		private object CFBNPKIMOJC()
		{
			return PHDOCKCBJOF;
		}

		private static void POGLHCIAAGH()
		{
			Singleton<BeanstalkServerManager>.instance.BKPEOBBLCNG();
			GameLoginManager.Relog(showScreen: false);
		}

		public void PAOPOFJHFGD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IGFMIFOHCHJ()
		{
			return PHDOCKCBJOF;
		}

		public bool FPMHODJKAKK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
			{
				bool? gJFHKPIHDCH = BJGCPDNMHDH.GJFHKPIHDCH;
				if (!gJFHKPIHDCH.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (BJGCPDNMHDH.GJFHKPIHDCH != false)
				{
					string hOLNKOFHDNK = Localization.Localize("\n");
					string oKMNFHNBMFA = Localization.Localize("clipSize");
					if (LGJCBPOPCPA == null)
					{
						LGJCBPOPCPA = FDKEAJLEMCM;
					}
					WarningDialog.ShowError(hOLNKOFHDNK, oKMNFHNBMFA, 1613f, LGJCBPOPCPA, string.Empty, JCOGJEEFLBC: true);
					BJGCPDNMHDH.TryStopLoading();
					BJGCPDNMHDH.Quit();
					if ((bool)(BJGCPDNMHDH.mainController as GameControllerOnline))
					{
						((GameControllerOnline)BJGCPDNMHDH.mainController).Disconnect();
					}
					CLPPIAGLCJJ = -1;
				}
				goto default;
			}
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object CCANBMDEKMB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NFJJHCBCIEM()
		{
			return PHDOCKCBJOF;
		}

		private static void LJCDGJKCNEC()
		{
			Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
			GameLoginManager.Relog();
		}

		[SpecialName]
		private object CNGCLCAAHIG()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public APOEGAMPAFA()
		{
		}

		public void CBPDLFGDOHJ()
		{
			throw new NotSupportedException();
		}

		public void HGCHEPGNHNP()
		{
			throw new NotSupportedException();
		}

		public void PHEIGPKKPGE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object LHMPDOBMOLD()
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
			case 1u:
			{
				bool? gJFHKPIHDCH = BJGCPDNMHDH.GJFHKPIHDCH;
				if (!gJFHKPIHDCH.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (BJGCPDNMHDH.GJFHKPIHDCH != false)
				{
					string hOLNKOFHDNK = Localization.Localize("ID_CONFIRM_DOGTAGSAREFULL");
					string oKMNFHNBMFA = Localization.Localize("ID_FEATURE_CRITICAL-WEAPONPREFIX");
					if (LGJCBPOPCPA == null)
					{
						LGJCBPOPCPA = KPHEPHDFCKK;
					}
					WarningDialog.JACKIDKHKAI(hOLNKOFHDNK, oKMNFHNBMFA, 127f, LGJCBPOPCPA, string.Empty, JCOGJEEFLBC: true);
					BJGCPDNMHDH.NOKJMDOPFHL();
					BJGCPDNMHDH.HGBNEFDBFDC();
					if ((bool)(BJGCPDNMHDH.mainController as GameControllerOnline))
					{
						((GameControllerOnline)BJGCPDNMHDH.mainController).Disconnect();
					}
					CLPPIAGLCJJ = -1;
				}
				goto default;
			}
			default:
				return false;
			}
			return true;
		}

		public void DBJCDLFKDDI()
		{
			throw new NotSupportedException();
		}

		public void MBELAAJDOJA()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GLAOFCCAAEN()
		{
			return PHDOCKCBJOF;
		}

		public void FGLAPPKJHBK()
		{
			throw new NotSupportedException();
		}

		public bool HMLAEHJKPJE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
			{
				bool? gJFHKPIHDCH = BJGCPDNMHDH.GJFHKPIHDCH;
				if (!gJFHKPIHDCH.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				bool? gJFHKPIHDCH2 = BJGCPDNMHDH.GJFHKPIHDCH;
				if (gJFHKPIHDCH2 == true && !gJFHKPIHDCH2.HasValue)
				{
					string hOLNKOFHDNK = Localization.Localize("Test");
					string oKMNFHNBMFA = Localization.Localize("GameControllerDMO: Application resumed pased at time: {0} timeLeft {1}, currentTime: {2}");
					if (LGJCBPOPCPA == null)
					{
						LGJCBPOPCPA = IBOOIIJAHMC;
					}
					WarningDialog.ShowError(hOLNKOFHDNK, oKMNFHNBMFA, 837f, LGJCBPOPCPA, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
					BJGCPDNMHDH.NOKJMDOPFHL();
					BJGCPDNMHDH.Quit();
					if ((bool)(BJGCPDNMHDH.mainController as GameControllerOnline))
					{
						((GameControllerOnline)BJGCPDNMHDH.mainController).Disconnect();
					}
					CLPPIAGLCJJ = -1;
				}
				goto default;
			}
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object FKKBFFHMEME()
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
			{
				bool? gJFHKPIHDCH = BJGCPDNMHDH.GJFHKPIHDCH;
				if (!gJFHKPIHDCH.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (BJGCPDNMHDH.GJFHKPIHDCH != false)
				{
					string hOLNKOFHDNK = Localization.Localize("\n");
					string oKMNFHNBMFA = Localization.Localize("StartTime");
					if (LGJCBPOPCPA == null)
					{
						LGJCBPOPCPA = LJCDGJKCNEC;
					}
					WarningDialog.KHOMNBHMFGA(hOLNKOFHDNK, oKMNFHNBMFA, 1510f, LGJCBPOPCPA, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
					BJGCPDNMHDH.TryStopLoading();
					BJGCPDNMHDH.HGBNEFDBFDC();
					if ((bool)(BJGCPDNMHDH.mainController as GameControllerOnline))
					{
						((GameControllerOnline)BJGCPDNMHDH.mainController).Disconnect();
					}
					CLPPIAGLCJJ = -1;
				}
				goto default;
			}
			default:
				return false;
			}
			return false;
		}

		public void HKHANLKODIB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object FCBCEDKNBKC()
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
			{
				bool? gJFHKPIHDCH = BJGCPDNMHDH.GJFHKPIHDCH;
				if (gJFHKPIHDCH.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				bool? gJFHKPIHDCH2 = BJGCPDNMHDH.GJFHKPIHDCH;
				if (gJFHKPIHDCH2 == true && !gJFHKPIHDCH2.HasValue)
				{
					string hOLNKOFHDNK = Localization.Localize("GLM: After tutorial GC check -> REMOVE GC");
					string oKMNFHNBMFA = Localization.Localize("Id");
					if (LGJCBPOPCPA == null)
					{
						LGJCBPOPCPA = FDKEAJLEMCM;
					}
					WarningDialog.JACKIDKHKAI(hOLNKOFHDNK, oKMNFHNBMFA, 1880f, LGJCBPOPCPA, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
					BJGCPDNMHDH.TryStopLoading();
					BJGCPDNMHDH.HGBNEFDBFDC();
					if ((bool)(BJGCPDNMHDH.mainController as GameControllerOnline))
					{
						((GameControllerOnline)BJGCPDNMHDH.mainController).Disconnect();
					}
					CLPPIAGLCJJ = -1;
				}
				goto default;
			}
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object NEGMMIBLJLP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BGAGLOJHMEJ()
		{
			return PHDOCKCBJOF;
		}

		private static void NJBDFPIAGLF()
		{
			Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
			GameLoginManager.Relog(showScreen: false);
		}

		public void NAMBILMHOPD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FKPDNNMENFD()
		{
			return PHDOCKCBJOF;
		}

		private static void EFNJFNKJOMB()
		{
			Singleton<BeanstalkServerManager>.instance.BKPEOBBLCNG();
			GameLoginManager.Relog();
		}

		public bool AIFKBHCOIKG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
			{
				bool? gJFHKPIHDCH = BJGCPDNMHDH.GJFHKPIHDCH;
				if (!gJFHKPIHDCH.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (BJGCPDNMHDH.GJFHKPIHDCH != false)
				{
					string hOLNKOFHDNK = Localization.Localize("nonEliteUnits");
					string oKMNFHNBMFA = Localization.Localize("PlayerProgressRate");
					if (LGJCBPOPCPA == null)
					{
						LGJCBPOPCPA = POGLHCIAAGH;
					}
					WarningDialog.ShowError(hOLNKOFHDNK, oKMNFHNBMFA, 221f, LGJCBPOPCPA, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
					BJGCPDNMHDH.NOKJMDOPFHL();
					BJGCPDNMHDH.Quit();
					if ((bool)(BJGCPDNMHDH.mainController as GameControllerOnline))
					{
						((GameControllerOnline)BJGCPDNMHDH.mainController).Disconnect();
					}
					CLPPIAGLCJJ = -1;
				}
				goto default;
			}
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object GPKBICHIBHF()
		{
			return PHDOCKCBJOF;
		}

		public void BPFAJJGHCCD()
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
			case 1u:
			{
				bool? gJFHKPIHDCH = BJGCPDNMHDH.GJFHKPIHDCH;
				if (!gJFHKPIHDCH.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				bool? gJFHKPIHDCH2 = BJGCPDNMHDH.GJFHKPIHDCH;
				if (gJFHKPIHDCH2 != true && !gJFHKPIHDCH2.HasValue)
				{
					string hOLNKOFHDNK = Localization.Localize("onPause");
					string oKMNFHNBMFA = Localization.Localize("ID_TUTORIAL_PROGRESS_KILLING2");
					if (LGJCBPOPCPA == null)
					{
						LGJCBPOPCPA = POGLHCIAAGH;
					}
					WarningDialog.JACKIDKHKAI(hOLNKOFHDNK, oKMNFHNBMFA, 886f, LGJCBPOPCPA, string.Empty, JCOGJEEFLBC: true);
					BJGCPDNMHDH.TryStopLoading();
					BJGCPDNMHDH.Quit();
					if ((bool)(BJGCPDNMHDH.mainController as GameControllerOnline))
					{
						((GameControllerOnline)BJGCPDNMHDH.mainController).Disconnect();
					}
					CLPPIAGLCJJ = -1;
				}
				goto default;
			}
			default:
				return false;
			}
			return true;
		}

		public void GEAHPAFNAPJ()
		{
			throw new NotSupportedException();
		}

		public bool IEDGDDDADFM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
			{
				bool? gJFHKPIHDCH = BJGCPDNMHDH.GJFHKPIHDCH;
				if (gJFHKPIHDCH.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				bool? gJFHKPIHDCH2 = BJGCPDNMHDH.GJFHKPIHDCH;
				if (gJFHKPIHDCH2 != true && !gJFHKPIHDCH2.HasValue)
				{
					string hOLNKOFHDNK = Localization.Localize("menu-armypower-ico");
					string oKMNFHNBMFA = Localization.Localize("ID_CONFIRM_FORFEIT_TEXT");
					if (LGJCBPOPCPA == null)
					{
						LGJCBPOPCPA = IBOOIIJAHMC;
					}
					WarningDialog.ShowError(hOLNKOFHDNK, oKMNFHNBMFA, 448f, LGJCBPOPCPA, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
					BJGCPDNMHDH.TryStopLoading();
					BJGCPDNMHDH.HGBNEFDBFDC();
					if ((bool)(BJGCPDNMHDH.mainController as GameControllerOnline))
					{
						((GameControllerOnline)BJGCPDNMHDH.mainController).Disconnect();
					}
					CLPPIAGLCJJ = -1;
				}
				goto default;
			}
			default:
				return true;
			}
			return false;
		}

		public void ODPKEEIHOPK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object NMAMPDNFNHE()
		{
			return PHDOCKCBJOF;
		}

		public void JMANMKKCDMM()
		{
			throw new NotSupportedException();
		}

		public void PDKPELBIAON()
		{
			throw new NotSupportedException();
		}

		public void GEEKOICFEIB()
		{
			throw new NotSupportedException();
		}

		private static void CMDLGJKIBLL()
		{
			Singleton<BeanstalkServerManager>.instance.BKPEOBBLCNG();
			GameLoginManager.Relog(showScreen: false);
		}

		private static void KPHEPHDFCKK()
		{
			Singleton<BeanstalkServerManager>.instance.BPDHHBFKHJP();
			GameLoginManager.Relog(showScreen: false);
		}

		public bool LMNIKLKKIDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
			{
				bool? gJFHKPIHDCH = BJGCPDNMHDH.GJFHKPIHDCH;
				if (gJFHKPIHDCH.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				bool? gJFHKPIHDCH2 = BJGCPDNMHDH.GJFHKPIHDCH;
				if (gJFHKPIHDCH2 != true && !gJFHKPIHDCH2.HasValue)
				{
					string hOLNKOFHDNK = Localization.Localize("313 MENU ENABLE PUSH");
					string oKMNFHNBMFA = Localization.Localize("Buy Warbucks Request Success");
					if (LGJCBPOPCPA == null)
					{
						LGJCBPOPCPA = GGJDILDIFPJ;
					}
					WarningDialog.KHOMNBHMFGA(hOLNKOFHDNK, oKMNFHNBMFA, 1275f, LGJCBPOPCPA, string.Empty, JCOGJEEFLBC: true);
					BJGCPDNMHDH.NOKJMDOPFHL();
					BJGCPDNMHDH.HGBNEFDBFDC();
					if ((bool)(BJGCPDNMHDH.mainController as GameControllerOnline))
					{
						((GameControllerOnline)BJGCPDNMHDH.mainController).Disconnect();
					}
					CLPPIAGLCJJ = -1;
				}
				goto default;
			}
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object MHKODCGLJFD()
		{
			return PHDOCKCBJOF;
		}

		private static void BMCMDMKGHHO()
		{
			Singleton<BeanstalkServerManager>.instance.BPDHHBFKHJP();
			GameLoginManager.Relog();
		}

		public bool OKELILGDPLJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
			{
				bool? gJFHKPIHDCH = BJGCPDNMHDH.GJFHKPIHDCH;
				if (gJFHKPIHDCH.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (BJGCPDNMHDH.GJFHKPIHDCH != true)
				{
					string hOLNKOFHDNK = Localization.Localize("Show starter pack: {0}\tConfiguration time: {1}\tTime till end time: {2}\tLast shown: {3}");
					string oKMNFHNBMFA = Localization.Localize("S");
					if (LGJCBPOPCPA == null)
					{
						LGJCBPOPCPA = GGJDILDIFPJ;
					}
					WarningDialog.JACKIDKHKAI(hOLNKOFHDNK, oKMNFHNBMFA, 4f, LGJCBPOPCPA, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
					BJGCPDNMHDH.TryStopLoading();
					BJGCPDNMHDH.Quit();
					if ((bool)(BJGCPDNMHDH.mainController as GameControllerOnline))
					{
						((GameControllerOnline)BJGCPDNMHDH.mainController).Disconnect();
					}
					CLPPIAGLCJJ = -1;
				}
				goto default;
			}
			default:
				return true;
			}
			return false;
		}

		public void HCJOIAHBFGB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HIFNMHAGHLI()
		{
			return PHDOCKCBJOF;
		}

		public void CJLDNKALLLI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object IHPDPKLEDKC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BCIDICEAAEN()
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
			case 1u:
			{
				bool? gJFHKPIHDCH = BJGCPDNMHDH.GJFHKPIHDCH;
				if (!gJFHKPIHDCH.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (BJGCPDNMHDH.GJFHKPIHDCH != true)
				{
					string hOLNKOFHDNK = Localization.Localize("antialiasing");
					string oKMNFHNBMFA = Localization.Localize("DE");
					if (LGJCBPOPCPA == null)
					{
						LGJCBPOPCPA = HHLMDAKDHFK;
					}
					WarningDialog.KHOMNBHMFGA(hOLNKOFHDNK, oKMNFHNBMFA, 801f, LGJCBPOPCPA, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
					BJGCPDNMHDH.TryStopLoading();
					BJGCPDNMHDH.HGBNEFDBFDC();
					if ((bool)(BJGCPDNMHDH.mainController as GameControllerOnline))
					{
						((GameControllerOnline)BJGCPDNMHDH.mainController).Disconnect();
					}
					CLPPIAGLCJJ = -1;
				}
				goto default;
			}
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

		public void FIENOOBNNGD()
		{
			throw new NotSupportedException();
		}

		public bool HKPECDLGFJB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
			{
				bool? gJFHKPIHDCH = BJGCPDNMHDH.GJFHKPIHDCH;
				if (!gJFHKPIHDCH.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				bool? gJFHKPIHDCH2 = BJGCPDNMHDH.GJFHKPIHDCH;
				if (gJFHKPIHDCH2 == true && !gJFHKPIHDCH2.HasValue)
				{
					string hOLNKOFHDNK = Localization.Localize("reached max depth!");
					string oKMNFHNBMFA = Localization.Localize("Network pool: InstantiatePooledObjects '");
					if (LGJCBPOPCPA == null)
					{
						LGJCBPOPCPA = KPHEPHDFCKK;
					}
					WarningDialog.JACKIDKHKAI(hOLNKOFHDNK, oKMNFHNBMFA, 543f, LGJCBPOPCPA, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
					BJGCPDNMHDH.TryStopLoading();
					BJGCPDNMHDH.HGBNEFDBFDC();
					if ((bool)(BJGCPDNMHDH.mainController as GameControllerOnline))
					{
						((GameControllerOnline)BJGCPDNMHDH.mainController).Disconnect();
					}
					CLPPIAGLCJJ = -1;
				}
				goto default;
			}
			default:
				return true;
			}
			return true;
		}

		public void HKFEFDNFKKK()
		{
			throw new NotSupportedException();
		}

		public bool LPMIKEPIMCM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
			{
				bool? gJFHKPIHDCH = BJGCPDNMHDH.GJFHKPIHDCH;
				if (!gJFHKPIHDCH.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (BJGCPDNMHDH.GJFHKPIHDCH != false)
				{
					string hOLNKOFHDNK = Localization.Localize("BonusDamage");
					string oKMNFHNBMFA = Localization.Localize("Beanstalk: On Send Settings");
					if (LGJCBPOPCPA == null)
					{
						LGJCBPOPCPA = FKIBFHGKMFJ;
					}
					WarningDialog.ShowError(hOLNKOFHDNK, oKMNFHNBMFA, 1162f, LGJCBPOPCPA, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
					BJGCPDNMHDH.TryStopLoading();
					BJGCPDNMHDH.HGBNEFDBFDC();
					if ((bool)(BJGCPDNMHDH.mainController as GameControllerOnline))
					{
						((GameControllerOnline)BJGCPDNMHDH.mainController).Disconnect();
					}
					CLPPIAGLCJJ = -1;
				}
				goto default;
			}
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

		public void EFKBIIPFDOM()
		{
			throw new NotSupportedException();
		}

		public bool KEBEGEDKIKM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
			{
				bool? gJFHKPIHDCH = BJGCPDNMHDH.GJFHKPIHDCH;
				if (gJFHKPIHDCH.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				bool? gJFHKPIHDCH2 = BJGCPDNMHDH.GJFHKPIHDCH;
				if (gJFHKPIHDCH2 == true && !gJFHKPIHDCH2.HasValue)
				{
					string hOLNKOFHDNK = Localization.Localize("Weapon upgrade for ");
					string oKMNFHNBMFA = Localization.Localize("ID_UNIT2UPGRADE_UNIT1UPGRADE");
					if (LGJCBPOPCPA == null)
					{
						LGJCBPOPCPA = NGMELCCIEHN;
					}
					WarningDialog.ShowError(hOLNKOFHDNK, oKMNFHNBMFA, 1176f, LGJCBPOPCPA, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
					BJGCPDNMHDH.TryStopLoading();
					BJGCPDNMHDH.HGBNEFDBFDC();
					if ((bool)(BJGCPDNMHDH.mainController as GameControllerOnline))
					{
						((GameControllerOnline)BJGCPDNMHDH.mainController).Disconnect();
					}
					CLPPIAGLCJJ = -1;
				}
				goto default;
			}
			default:
				return false;
			}
			return true;
		}

		private static void FDKEAJLEMCM()
		{
			Singleton<BeanstalkServerManager>.instance.BPDHHBFKHJP();
			GameLoginManager.Relog(showScreen: false);
		}

		public void DOPCGPGKHIJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		private static void IBOOIIJAHMC()
		{
			Singleton<BeanstalkServerManager>.instance.BPDHHBFKHJP();
			GameLoginManager.Relog(showScreen: false);
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
			{
				bool? gJFHKPIHDCH = BJGCPDNMHDH.GJFHKPIHDCH;
				if (!gJFHKPIHDCH.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (BJGCPDNMHDH.GJFHKPIHDCH != true)
				{
					string hOLNKOFHDNK = Localization.Localize("ID_CONFIRM_SERVERERROR_TEXT");
					string oKMNFHNBMFA = Localization.Localize("ID_CONFIRM_SERVERERROR");
					if (LGJCBPOPCPA == null)
					{
						LGJCBPOPCPA = LJCDGJKCNEC;
					}
					WarningDialog.ShowError(hOLNKOFHDNK, oKMNFHNBMFA, 0f, LGJCBPOPCPA, string.Empty);
					BJGCPDNMHDH.TryStopLoading();
					BJGCPDNMHDH.Quit();
					if ((bool)(BJGCPDNMHDH.mainController as GameControllerOnline))
					{
						((GameControllerOnline)BJGCPDNMHDH.mainController).Disconnect();
					}
					CLPPIAGLCJJ = -1;
				}
				goto default;
			}
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object HADIFBCDICK()
		{
			return PHDOCKCBJOF;
		}

		public void MGJIOLLKHDK()
		{
			throw new NotSupportedException();
		}

		public void DBEMHFEBPFM()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void KHMNEOBMJLN()
		{
			throw new NotSupportedException();
		}

		public void OKIANDBCDIB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void EJNCMFMOBAJ()
		{
			throw new NotSupportedException();
		}

		public void GGDBAJJAHNO()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object AGANCOFPDCK()
		{
			return PHDOCKCBJOF;
		}

		public void ODJLLLFJIOB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		private static void JMEBCMMIPAF()
		{
			Singleton<BeanstalkServerManager>.instance.EOAILOJFNJG();
			GameLoginManager.Relog(showScreen: false);
		}

		[SpecialName]
		private object MPHILJJDNIO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PLHNILIJAPA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ADNCCLOOEAD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HLFLANGJJHM()
		{
			return PHDOCKCBJOF;
		}

		public bool DIFNNJALIPB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
			{
				bool? gJFHKPIHDCH = BJGCPDNMHDH.GJFHKPIHDCH;
				if (!gJFHKPIHDCH.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (BJGCPDNMHDH.GJFHKPIHDCH != true)
				{
					string hOLNKOFHDNK = Localization.Localize("Days_Since_Install");
					string oKMNFHNBMFA = Localization.Localize("Prefabs search finished.\n");
					if (LGJCBPOPCPA == null)
					{
						LGJCBPOPCPA = HHLMDAKDHFK;
					}
					WarningDialog.KHOMNBHMFGA(hOLNKOFHDNK, oKMNFHNBMFA, 177f, LGJCBPOPCPA, string.Empty);
					BJGCPDNMHDH.NOKJMDOPFHL();
					BJGCPDNMHDH.HGBNEFDBFDC();
					if ((bool)(BJGCPDNMHDH.mainController as GameControllerOnline))
					{
						((GameControllerOnline)BJGCPDNMHDH.mainController).Disconnect();
					}
					CLPPIAGLCJJ = -1;
				}
				goto default;
			}
			default:
				return true;
			}
			return true;
		}

		public void JKBIMBFGGCO()
		{
			throw new NotSupportedException();
		}

		private static void HHLMDAKDHFK()
		{
			Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
			GameLoginManager.Relog(showScreen: false);
		}

		public bool MHNPBDBGBLK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
			{
				bool? gJFHKPIHDCH = BJGCPDNMHDH.GJFHKPIHDCH;
				if (!gJFHKPIHDCH.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				bool? gJFHKPIHDCH2 = BJGCPDNMHDH.GJFHKPIHDCH;
				if (gJFHKPIHDCH2 == true && !gJFHKPIHDCH2.HasValue)
				{
					string hOLNKOFHDNK = Localization.Localize("FB: FacebookLogout - RemoveFacebook - 1");
					string oKMNFHNBMFA = Localization.Localize("squadPoints");
					if (LGJCBPOPCPA == null)
					{
						LGJCBPOPCPA = NNFHNIMCBLH;
					}
					WarningDialog.KHOMNBHMFGA(hOLNKOFHDNK, oKMNFHNBMFA, 1533f, LGJCBPOPCPA, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
					BJGCPDNMHDH.NOKJMDOPFHL();
					BJGCPDNMHDH.Quit();
					if ((bool)(BJGCPDNMHDH.mainController as GameControllerOnline))
					{
						((GameControllerOnline)BJGCPDNMHDH.mainController).Disconnect();
					}
					CLPPIAGLCJJ = -1;
				}
				goto default;
			}
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

		[SpecialName]
		private object DFHCLJNONGC()
		{
			return PHDOCKCBJOF;
		}

		private static void FICGLJJELPM()
		{
			Singleton<BeanstalkServerManager>.instance.BPDHHBFKHJP();
			GameLoginManager.Relog();
		}

		public void CPDBCJLIGFN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void ANOPOLIEBMC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HLBMCNKGBDM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JGKMCJOGEIH()
		{
			return PHDOCKCBJOF;
		}

		public void CNBLDCICPLL()
		{
			throw new NotSupportedException();
		}

		private static void GGJDILDIFPJ()
		{
			Singleton<BeanstalkServerManager>.instance.EOAILOJFNJG();
			GameLoginManager.Relog();
		}

		[SpecialName]
		private object KKCOHEHPJPF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GMEIAAMCBGA()
		{
			return PHDOCKCBJOF;
		}

		public void CKEOKOKAAPB()
		{
			throw new NotSupportedException();
		}

		public void ELMJLOBAMKH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void JHLKDONBGDK()
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
			case 1u:
			{
				bool? gJFHKPIHDCH = BJGCPDNMHDH.GJFHKPIHDCH;
				if (!gJFHKPIHDCH.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				bool? gJFHKPIHDCH2 = BJGCPDNMHDH.GJFHKPIHDCH;
				if (gJFHKPIHDCH2 == true && !gJFHKPIHDCH2.HasValue)
				{
					string hOLNKOFHDNK = Localization.Localize("Missing shader in ");
					string oKMNFHNBMFA = Localization.Localize("ID_STAT_SQUADTOTAL");
					if (LGJCBPOPCPA == null)
					{
						LGJCBPOPCPA = BMCMDMKGHHO;
					}
					WarningDialog.KHOMNBHMFGA(hOLNKOFHDNK, oKMNFHNBMFA, 1742f, LGJCBPOPCPA, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
					BJGCPDNMHDH.NOKJMDOPFHL();
					BJGCPDNMHDH.Quit();
					if ((bool)(BJGCPDNMHDH.mainController as GameControllerOnline))
					{
						((GameControllerOnline)BJGCPDNMHDH.mainController).Disconnect();
					}
					CLPPIAGLCJJ = -1;
				}
				goto default;
			}
			default:
				return false;
			}
			return true;
		}

		private static void ECPLPHONBFM()
		{
			Singleton<BeanstalkServerManager>.instance.EOAILOJFNJG();
			GameLoginManager.Relog(showScreen: false);
		}

		[SpecialName]
		private object GMPGIODBIPO()
		{
			return PHDOCKCBJOF;
		}

		public void NIGDCBDKKMJ()
		{
			throw new NotSupportedException();
		}

		public void HBHILKGDCMG()
		{
			throw new NotSupportedException();
		}

		public void ADLICCCIEGG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool FIBKLKNDFDO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
			{
				bool? gJFHKPIHDCH = BJGCPDNMHDH.GJFHKPIHDCH;
				if (gJFHKPIHDCH.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				bool? gJFHKPIHDCH2 = BJGCPDNMHDH.GJFHKPIHDCH;
				if (gJFHKPIHDCH2 == true && !gJFHKPIHDCH2.HasValue)
				{
					string hOLNKOFHDNK = Localization.Localize("$0-$5");
					string oKMNFHNBMFA = Localization.Localize("SyncUpgradesRPC");
					if (LGJCBPOPCPA == null)
					{
						LGJCBPOPCPA = POGLHCIAAGH;
					}
					WarningDialog.ShowError(hOLNKOFHDNK, oKMNFHNBMFA, 1893f, LGJCBPOPCPA, string.Empty, JCOGJEEFLBC: true);
					BJGCPDNMHDH.TryStopLoading();
					BJGCPDNMHDH.HGBNEFDBFDC();
					if ((bool)(BJGCPDNMHDH.mainController as GameControllerOnline))
					{
						((GameControllerOnline)BJGCPDNMHDH.mainController).Disconnect();
					}
					CLPPIAGLCJJ = -1;
				}
				goto default;
			}
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

		public void LEAAOAKKLAJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void JKOCLGOOBEK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		private static void FKIBFHGKMFJ()
		{
			Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
			GameLoginManager.Relog(showScreen: false);
		}
	}

	private sealed class CHEINCNDKIG : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal GameController BJGCPDNMHDH;

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

		public void NPIDJAPKFLN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object JALKNCBEINE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HLBMCNKGBDM()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public CHEINCNDKIG()
		{
		}

		[SpecialName]
		private object MPHILJJDNIO()
		{
			return PHDOCKCBJOF;
		}

		public void FGLAPPKJHBK()
		{
			throw new NotSupportedException();
		}

		public void ODFCBNONFPL()
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
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(string.Format("VipReward2", BJGCPDNMHDH.CBAPHFGNLLH.BJLPMKCIHJK().Replace("GameController.LoadAndStartNewMap - DONE", string.Empty)));
				BJGCPDNMHDH.HCIECMLDPFB = false;
				if (BJGCPDNMHDH.HKCMKDFCNBP != null)
				{
					BJGCPDNMHDH.HKCMKDFCNBP(BJGCPDNMHDH.MNMLNIMFMJP);
				}
				Singleton<BeanstalkServerManager>.instance.JIPDCIDHLOI(BJGCPDNMHDH.MNMLNIMFMJP);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.NPOCKLJOIDP()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
			case 2u:
				if (BJGCPDNMHDH.PEGCHNGBOAM() != AEMPHGEIJNH.Menu)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Time.timeScale = 137f;
				LoadingDialog.FDBHFJFKALH(Localization.Localize("LevelProgress"), DMDICGADGCG: false, BGOHKCCLDJP: true, KKLNBPJCLHC: true);
				PHDOCKCBJOF = new WaitForSeconds(602f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 3u:
				GameControllerTutorial.RestartTutorial();
				BJGCPDNMHDH.ContinueTutorialImmediately();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void IMFLNKIMEFA()
		{
			throw new NotSupportedException();
		}

		public void KHMNEOBMJLN()
		{
			throw new NotSupportedException();
		}

		public void GGCLMIMHKBD()
		{
			throw new NotSupportedException();
		}

		public void MHKKAFGKBJK()
		{
			throw new NotSupportedException();
		}

		public bool HKPECDLGFJB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(string.Format("ID_CONFIRM_ERROR", BJGCPDNMHDH.CBAPHFGNLLH.IDCJLPILIGL().Replace("ID_EXCLUSIVECHARACTER", string.Empty)));
				BJGCPDNMHDH.HCIECMLDPFB = true;
				if (BJGCPDNMHDH.HKCMKDFCNBP != null)
				{
					BJGCPDNMHDH.HKCMKDFCNBP(BJGCPDNMHDH.MNMLNIMFMJP);
				}
				Singleton<BeanstalkServerManager>.instance.GameEnded(BJGCPDNMHDH.MNMLNIMFMJP);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.NPOCKLJOIDP()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
			case 2u:
				if (BJGCPDNMHDH.NOPCKHHDOMN() != AEMPHGEIJNH.Menu)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				Time.timeScale = 1453f;
				LoadingDialog.PGFBMJFLHPC(Localization.Localize("Buy_Army_Unit"), DMDICGADGCG: false, BGOHKCCLDJP: true, KKLNBPJCLHC: true);
				PHDOCKCBJOF = new WaitForSeconds(1310f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 3u:
				GameControllerTutorial.GAIPAMAIBBB();
				BJGCPDNMHDH.ContinueTutorialImmediately();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object IDLFKAKINAP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JDKFIHJHNJC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CJCHFDFCPPL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GENJNMACGLP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LMJBCDNGAHP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GOAJCEAOPLA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HCCLNDKNCIE()
		{
			return PHDOCKCBJOF;
		}

		public void MKACBCOLNKD()
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
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(string.Format("{0}99 RESTART", BJGCPDNMHDH.CBAPHFGNLLH.tutorialStageId.Replace("Stage", string.Empty)));
				BJGCPDNMHDH.HCIECMLDPFB = true;
				if (BJGCPDNMHDH.HKCMKDFCNBP != null)
				{
					BJGCPDNMHDH.HKCMKDFCNBP(BJGCPDNMHDH.MNMLNIMFMJP);
				}
				Singleton<BeanstalkServerManager>.instance.GameEnded(BJGCPDNMHDH.MNMLNIMFMJP);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.NPOCKLJOIDP()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
			case 2u:
				if (BJGCPDNMHDH.gameState != AEMPHGEIJNH.Menu)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				Time.timeScale = 1f;
				LoadingDialog.ShowLoading(Localization.Localize("ID_LOADING"), DMDICGADGCG: false, BGOHKCCLDJP: true);
				PHDOCKCBJOF = new WaitForSeconds(0.1f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 3u:
				GameControllerTutorial.RestartTutorial();
				BJGCPDNMHDH.ContinueTutorialImmediately();
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
		private object MBDBIPHLEIA()
		{
			return PHDOCKCBJOF;
		}

		public void CPOKHODGGLN()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object INAMGPNDAAJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FBPFPJOCKGD()
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
		private object BMGHJKFMKJE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NAPMJAMDKMJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JEPCFCNIOGH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HHHLDCLIFKJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GLIHEBDJCGM()
		{
			return PHDOCKCBJOF;
		}

		public void ANOPOLIEBMC()
		{
			throw new NotSupportedException();
		}

		public bool GAPIFMKNJBN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(string.Format("Level", BJGCPDNMHDH.CBAPHFGNLLH.BJLPMKCIHJK().Replace("Lcom/google/android/gms/games/achievement/Achievements;", string.Empty)));
				BJGCPDNMHDH.HCIECMLDPFB = false;
				if (BJGCPDNMHDH.HKCMKDFCNBP != null)
				{
					BJGCPDNMHDH.HKCMKDFCNBP(BJGCPDNMHDH.MNMLNIMFMJP);
				}
				Singleton<BeanstalkServerManager>.instance.FPIOOBKMHFN(BJGCPDNMHDH.MNMLNIMFMJP);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.NPOCKLJOIDP()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
			case 2u:
				if (BJGCPDNMHDH.PEGCHNGBOAM() != AEMPHGEIJNH.Menu)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Time.timeScale = 1098f;
				LoadingDialog.FDBHFJFKALH(Localization.Localize("Total_Warbucks_Spent"), DMDICGADGCG: true, BGOHKCCLDJP: true);
				PHDOCKCBJOF = new WaitForSeconds(670f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 3u:
				GameControllerTutorial.LKKCDNBBEBJ();
				BJGCPDNMHDH.ContinueTutorialImmediately();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object MLDIMIPJMDD()
		{
			return PHDOCKCBJOF;
		}

		public void CDDFJOEEFID()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KKKMCHGLHLL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KBNAGKKMLBP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GDCFFBBNGHH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GJMNLPAEIDA()
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
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(string.Format("game-card-ico-explosivetiming", BJGCPDNMHDH.CBAPHFGNLLH.tutorialStageId.Replace("07", string.Empty)));
				BJGCPDNMHDH.HCIECMLDPFB = true;
				if (BJGCPDNMHDH.HKCMKDFCNBP != null)
				{
					BJGCPDNMHDH.HKCMKDFCNBP(BJGCPDNMHDH.MNMLNIMFMJP);
				}
				Singleton<BeanstalkServerManager>.instance.FPIOOBKMHFN(BJGCPDNMHDH.MNMLNIMFMJP);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.NPOCKLJOIDP()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
			case 2u:
				if (BJGCPDNMHDH.AFDJHMHONOH() != AEMPHGEIJNH.Menu)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				Time.timeScale = 1596f;
				LoadingDialog.PGFBMJFLHPC(Localization.Localize("ClientOnly"));
				PHDOCKCBJOF = new WaitForSeconds(493f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 3u:
				GameControllerTutorial.RestartTutorial();
				BJGCPDNMHDH.ContinueTutorialImmediately();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public bool ILNBJIJONKD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(string.Format("), ", BJGCPDNMHDH.CBAPHFGNLLH.BJLPMKCIHJK().Replace("unit", string.Empty)));
				BJGCPDNMHDH.HCIECMLDPFB = false;
				if (BJGCPDNMHDH.HKCMKDFCNBP != null)
				{
					BJGCPDNMHDH.HKCMKDFCNBP(BJGCPDNMHDH.MNMLNIMFMJP);
				}
				Singleton<BeanstalkServerManager>.instance.GameEnded(BJGCPDNMHDH.MNMLNIMFMJP);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(RadicalRoutine.Run(BJGCPDNMHDH.NPOCKLJOIDP()));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
			case 2u:
				if (BJGCPDNMHDH.gameState != AEMPHGEIJNH.Menu)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				Time.timeScale = 822f;
				LoadingDialog.ShowLoading(Localization.Localize("InfluencerAlias"));
				PHDOCKCBJOF = new WaitForSeconds(1852f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 3u:
				GameControllerTutorial.LKKCDNBBEBJ();
				BJGCPDNMHDH.ContinueTutorialImmediately();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void CJLDNKALLLI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BLOJDIFOPIA()
		{
			return PHDOCKCBJOF;
		}

		public void KGLKGNBCPLM()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void NCFGFLNBHOI()
		{
			throw new NotSupportedException();
		}

		public void NFLHLMKKJMO()
		{
			throw new NotSupportedException();
		}

		public void GEEKOICFEIB()
		{
			throw new NotSupportedException();
		}

		public void IGBHHLFACKO()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}
	}

	private sealed class KCPGHGNIGFP : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal GameController BJGCPDNMHDH;

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

		internal void PPKGMGNKNAE()
		{
			BJGCPDNMHDH.MNMLNIMFMJP = HKGHCIEPGEL.Killed;
			BJGCPDNMHDH.OJIENOPOBLO(KANLHOCIMID: false, HNCPBGJJEPO: true);
		}

		internal void OKNCFDMEFGJ()
		{
			BJGCPDNMHDH.MNMLNIMFMJP = (HKGHCIEPGEL)7;
			BJGCPDNMHDH.OJIENOPOBLO(KANLHOCIMID: true, HNCPBGJJEPO: true);
		}

		public void IDCJDJMGKFG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object AFDKAGLDADB()
		{
			return PHDOCKCBJOF;
		}

		public void JKBIMBFGGCO()
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
				BJGCPDNMHDH.HDBGBMPCMON = null;
				Singleton<BeanstalkServerManager>.instance.ActionUpdated += BJGCPDNMHDH.EOJIIDEEOEE;
				if (!BJGCPDNMHDH.HCIECMLDPFB)
				{
					goto case 1u;
				}
				goto case 2u;
			case 1u:
				if (!GuiScreenSingle<GameOverScreen>.instance.isAnimationFinished)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<Recording>.instance.StopRecording();
				PHDOCKCBJOF = new WaitForRealSeconds(0.5f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
				LoadingDialog.SetLook(EDHDMJLHLFA: false);
				LoadingDialog.ShowLoading(Localization.Localize("ID_LOADING"), DMDICGADGCG: false, BGOHKCCLDJP: true);
				if (DebugSettings.debugEnabled && BJGCPDNMHDH.HDBGBMPCMON != null)
				{
					LoadingDialog.SetText(BJGCPDNMHDH.HDBGBMPCMON);
				}
				goto case 3u;
			case 3u:
				if (BJGCPDNMHDH.gameEndServerResponse == AHDGGJJAOEO.None)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				Singleton<BeanstalkServerManager>.instance.ActionUpdated -= BJGCPDNMHDH.EOJIIDEEOEE;
				if (BJGCPDNMHDH.gameEndServerResponse == AHDGGJJAOEO.Error)
				{
					string text = Localization.Localize("ID_CONFIRM_UNKNOWNREASON");
					switch (BJGCPDNMHDH.errorReason)
					{
					case IJEAJGCCHEF.ServerRespondedWithError:
						text = Localization.Localize("ID_CONFIRM_SERVERRESPONDEDWITHERROR");
						break;
					case IJEAJGCCHEF.ServerDidntRespondAfterGame:
						text = Localization.Localize("ID_CONFIRM_SERVERDIDNTRESPONDAFTER");
						break;
					case IJEAJGCCHEF.GameDidntExist:
						text = Localization.Localize("ID_CONFIRM_GAMEDIDNTEXIST");
						break;
					case IJEAJGCCHEF.GameAlreadyEnded:
						text = Localization.Localize("ID_CONFIRM_GAMELAREADYENDED");
						break;
					case IJEAJGCCHEF.InvalidToken:
						text = Localization.Localize("ID_CONFIRM_LOGGEDOUT_TEXT");
						break;
					default:
						text = string.Format("{0} {1}.", Localization.Localize("ID_CONFIRM_OTHERSERVERRESPONDERROR"), (int)BJGCPDNMHDH.errorReason);
						break;
					}
					WarningDialog.ShowError(text, Localization.Localize("ID_CONFIRM_SERVERERROR"), 0f, LJCDGJKCNEC, string.Empty);
					LoadingDialog.ShowLoading(Localization.Localize("ID_LOADING"), DMDICGADGCG: false, BGOHKCCLDJP: true, KKLNBPJCLHC: true);
				}
				if (BJGCPDNMHDH.gameEndServerResponse == AHDGGJJAOEO.Success)
				{
					BJGCPDNMHDH.MKEGPEBGOGM(KANLHOCIMID: true);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void LDBLCPIGLOF()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FPFOODLPEBK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BGMNDLEJNHH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IHAOBCEALPD()
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
				BJGCPDNMHDH.HDBGBMPCMON = null;
				Singleton<BeanstalkServerManager>.instance.CPOFECKKEGJ(BJGCPDNMHDH.EOJIIDEEOEE);
				if (!BJGCPDNMHDH.HCIECMLDPFB)
				{
					goto case 1u;
				}
				goto case 2u;
			case 1u:
				if (!GuiScreenSingle<GameOverScreen>.instance.BFNOINNNHGP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<Recording>.instance.StopRecording();
				PHDOCKCBJOF = new WaitForRealSeconds(1047f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 2u:
				LoadingDialog.FEHDJPIKOJD(EDHDMJLHLFA: false);
				LoadingDialog.ShowLoading(Localization.Localize("いいえ"), DMDICGADGCG: false, BGOHKCCLDJP: false, KKLNBPJCLHC: true);
				if (DebugSettings.debugEnabled && BJGCPDNMHDH.HDBGBMPCMON != null)
				{
					LoadingDialog.BKOEMIKFMHN(BJGCPDNMHDH.HDBGBMPCMON, LMMNFFJAICA: true);
				}
				goto case 3u;
			case 3u:
				if (BJGCPDNMHDH.gameEndServerResponse == AHDGGJJAOEO.None)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				Singleton<BeanstalkServerManager>.instance.ActionUpdated -= BJGCPDNMHDH.EOJIIDEEOEE;
				if (BJGCPDNMHDH.gameEndServerResponse == AHDGGJJAOEO.Error)
				{
					string text = Localization.Localize("Not sending error to database!!");
					switch (BJGCPDNMHDH.AMHOIGBECKJ())
					{
					case (IJEAJGCCHEF)193:
						text = Localization.Localize("menu-cards-silverpack");
						break;
					case (IJEAJGCCHEF)192:
						text = Localization.Localize("0");
						break;
					case (IJEAJGCCHEF)191:
						text = Localization.Localize("FuseSDK: Parsing error in _AccountLoginComplete");
						break;
					case (IJEAJGCCHEF)190:
						text = Localization.Localize("ID_NO");
						break;
					case (IJEAJGCCHEF)(-16):
						text = Localization.Localize("LeagueId");
						break;
					default:
						text = string.Format("ID_BUTTON_YOURSQUAD", Localization.Localize("ID_TUTORIAL_UPGRADEUNIT_4"), (int)BJGCPDNMHDH.AMHOIGBECKJ());
						break;
					}
					WarningDialog.KHOMNBHMFGA(text, Localization.Localize("Mode"), 599f, NNIJEDKBPGJ, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
					LoadingDialog.ShowLoading(Localization.Localize("canShow"));
				}
				if (BJGCPDNMHDH.gameEndServerResponse == AHDGGJJAOEO.Error)
				{
					BJGCPDNMHDH.OJIENOPOBLO(KANLHOCIMID: false);
				}
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

		public void MNFJGIMMBLE()
		{
			throw new NotSupportedException();
		}

		internal void ECPMEMNKMCB()
		{
			BJGCPDNMHDH.MNMLNIMFMJP = HKGHCIEPGEL.WinByForfeit;
			BJGCPDNMHDH.OJIENOPOBLO(KANLHOCIMID: true);
		}

		internal void CHDOECNGOPM()
		{
			BJGCPDNMHDH.MNMLNIMFMJP = HKGHCIEPGEL.WinByForfeit;
			BJGCPDNMHDH.MKEGPEBGOGM(KANLHOCIMID: true);
		}

		public bool JFPOOBJNEPF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.HDBGBMPCMON = null;
				Singleton<BeanstalkServerManager>.instance.IKBAIIHMPOK(BJGCPDNMHDH.EOJIIDEEOEE);
				if (!BJGCPDNMHDH.HCIECMLDPFB)
				{
					goto case 1u;
				}
				goto case 2u;
			case 1u:
				if (!GuiScreenSingle<GameOverScreen>.instance.BFNOINNNHGP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<Recording>.instance.HBDHNEOLBKI();
				PHDOCKCBJOF = new WaitForRealSeconds(523f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
				LoadingDialog.SetLook(EDHDMJLHLFA: true);
				LoadingDialog.PGFBMJFLHPC(Localization.Localize("ID_GUI_ALL"), DMDICGADGCG: false, BGOHKCCLDJP: true, KKLNBPJCLHC: true);
				if (DebugSettings.debugEnabled && BJGCPDNMHDH.HDBGBMPCMON != null)
				{
					LoadingDialog.SetText(BJGCPDNMHDH.HDBGBMPCMON);
				}
				goto case 3u;
			case 3u:
				if (BJGCPDNMHDH.gameEndServerResponse == AHDGGJJAOEO.None)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				Singleton<BeanstalkServerManager>.instance.ActionUpdated -= BJGCPDNMHDH.EOJIIDEEOEE;
				if (BJGCPDNMHDH.gameEndServerResponse == AHDGGJJAOEO.None)
				{
					string text = Localization.Localize("T");
					switch (BJGCPDNMHDH.errorReason)
					{
					case (IJEAJGCCHEF)41:
						text = Localization.Localize("ID_INCHAMPION1");
						break;
					case (IJEAJGCCHEF)40:
						text = Localization.Localize("Daily Mission Screen : daily completition reward is not DEFINED: {0}");
						break;
					case (IJEAJGCCHEF)39:
						text = Localization.Localize("ID_DELIVEREDTIME");
						break;
					case (IJEAJGCCHEF)38:
						text = Localization.Localize("Size");
						break;
					case (IJEAJGCCHEF)93:
						text = Localization.Localize("LootBoxOpen");
						break;
					default:
						text = string.Format("D2", Localization.Localize("Have discount {0} to upgrade {1}"), (int)BJGCPDNMHDH.AMHOIGBECKJ());
						break;
					}
					WarningDialog.KHOMNBHMFGA(text, Localization.Localize("Pack_Type"), 638f, NNIJEDKBPGJ, string.Empty, JCOGJEEFLBC: true);
					LoadingDialog.FDBHFJFKALH(Localization.Localize("null card in reward dialog"), DMDICGADGCG: true, BGOHKCCLDJP: true, KKLNBPJCLHC: true);
				}
				if (BJGCPDNMHDH.gameEndServerResponse == AHDGGJJAOEO.Success)
				{
					BJGCPDNMHDH.OJIENOPOBLO(KANLHOCIMID: false, HNCPBGJJEPO: true);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void HEOPOOMLPJF()
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
				BJGCPDNMHDH.HDBGBMPCMON = null;
				Singleton<BeanstalkServerManager>.instance.CPOFECKKEGJ(BJGCPDNMHDH.EOJIIDEEOEE);
				if (!BJGCPDNMHDH.HCIECMLDPFB)
				{
					goto case 1u;
				}
				goto case 2u;
			case 1u:
				if (!GuiScreenSingle<GameOverScreen>.instance.isAnimationFinished)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<Recording>.instance.GFIGPMJALIP();
				PHDOCKCBJOF = new WaitForRealSeconds(1298f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 2u:
				LoadingDialog.NJHOCHGJICN(EDHDMJLHLFA: false);
				LoadingDialog.ShowLoading(Localization.Localize("Packs"), DMDICGADGCG: true, BGOHKCCLDJP: true, KKLNBPJCLHC: true);
				if (DebugSettings.debugEnabled && BJGCPDNMHDH.HDBGBMPCMON != null)
				{
					LoadingDialog.SetText(BJGCPDNMHDH.HDBGBMPCMON);
				}
				goto case 3u;
			case 3u:
				if (BJGCPDNMHDH.gameEndServerResponse == AHDGGJJAOEO.None)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				Singleton<BeanstalkServerManager>.instance.ActionUpdated -= BJGCPDNMHDH.EOJIIDEEOEE;
				if (BJGCPDNMHDH.gameEndServerResponse == AHDGGJJAOEO.Error)
				{
					string text = Localization.Localize("registerParentalConsent");
					switch (BJGCPDNMHDH.AMHOIGBECKJ())
					{
					case (IJEAJGCCHEF)2:
						text = Localization.Localize("0");
						break;
					case IJEAJGCCHEF.Success:
						text = Localization.Localize("AmmoPool");
						break;
					case (IJEAJGCCHEF)0:
						text = Localization.Localize("x0");
						break;
					case (IJEAJGCCHEF)(-1):
						text = Localization.Localize("game-card-ico-shieldgenerator");
						break;
					case (IJEAJGCCHEF)132:
						text = Localization.Localize("game-card-ico-healingstorm");
						break;
					default:
						text = string.Format("PushNotificationDialog {0}", Localization.Localize("BS: Sending emblem = "), (int)BJGCPDNMHDH.errorReason);
						break;
					}
					WarningDialog.ShowError(text, Localization.Localize("PrepareBotForDeathMatch 8"), 992f, CIFEDFPPPOK, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
					LoadingDialog.ShowLoading(Localization.Localize("de"), DMDICGADGCG: false, BGOHKCCLDJP: true);
				}
				if (BJGCPDNMHDH.gameEndServerResponse == (AHDGGJJAOEO)7)
				{
					BJGCPDNMHDH.OJIENOPOBLO(KANLHOCIMID: false, HNCPBGJJEPO: true);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void EPKPNKGJHEC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HMIFLGCBDCO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ADNCCLOOEAD()
		{
			return PHDOCKCBJOF;
		}

		public void CHFJIODFNIP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		internal void JDEJHLLIONG()
		{
			BJGCPDNMHDH.MNMLNIMFMJP = (HKGHCIEPGEL)7;
			BJGCPDNMHDH.OJIENOPOBLO(KANLHOCIMID: true, HNCPBGJJEPO: true);
		}

		public bool EKGEDEKHBME()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.HDBGBMPCMON = null;
				Singleton<BeanstalkServerManager>.instance.IKBAIIHMPOK(BJGCPDNMHDH.EOJIIDEEOEE);
				if (!BJGCPDNMHDH.HCIECMLDPFB)
				{
					goto case 1u;
				}
				goto case 2u;
			case 1u:
				if (!GuiScreenSingle<GameOverScreen>.instance.isAnimationFinished)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<Recording>.instance.FKLIOPJAAOE();
				PHDOCKCBJOF = new WaitForRealSeconds(345f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
				LoadingDialog.SetLook(EDHDMJLHLFA: false);
				LoadingDialog.PGFBMJFLHPC(Localization.Localize("AdminPlayerId"), DMDICGADGCG: false, BGOHKCCLDJP: true);
				if (DebugSettings.debugEnabled && BJGCPDNMHDH.HDBGBMPCMON != null)
				{
					LoadingDialog.BKOEMIKFMHN(BJGCPDNMHDH.HDBGBMPCMON);
				}
				goto case 3u;
			case 3u:
				if (BJGCPDNMHDH.gameEndServerResponse == AHDGGJJAOEO.None)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				Singleton<BeanstalkServerManager>.instance.NNDMMGIGLHH(BJGCPDNMHDH.EOJIIDEEOEE);
				if (BJGCPDNMHDH.gameEndServerResponse == AHDGGJJAOEO.Error)
				{
					string text = Localization.Localize("Clear players");
					switch (BJGCPDNMHDH.AMHOIGBECKJ())
					{
					case (IJEAJGCCHEF)123:
						text = Localization.Localize("You are about to LEAVE the Arena lobby during matchmaking. This will count as a DEFEAT and you will lose a HEART. Do you really want to leave?");
						break;
					case (IJEAJGCCHEF)122:
						text = Localization.Localize("ID_RELOG_TO_WRONG_FB_DIALOG_TEXT2");
						break;
					case (IJEAJGCCHEF)121:
						text = Localization.Localize("Sniper_Tutorial_Played");
						break;
					case (IJEAJGCCHEF)120:
						text = Localization.Localize("GameCenterManager: Authenticate called - canShowDialog:");
						break;
					case (IJEAJGCCHEF)(-154):
						text = Localization.Localize("mortarBuildTime");
						break;
					default:
						text = string.Format("Player disconected 0003", Localization.Localize("PlayerProgressRate"), (int)BJGCPDNMHDH.errorReason);
						break;
					}
					WarningDialog.JACKIDKHKAI(text, Localization.Localize("QUIT"), 206f, PPKGMGNKNAE, string.Empty);
					LoadingDialog.PGFBMJFLHPC(Localization.Localize("Achievement '{0}' progress '{1}' successfully reported."));
				}
				if (BJGCPDNMHDH.gameEndServerResponse == (AHDGGJJAOEO)7)
				{
					BJGCPDNMHDH.MKEGPEBGOGM(KANLHOCIMID: true, HNCPBGJJEPO: true);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		internal void LJCDGJKCNEC()
		{
			BJGCPDNMHDH.MNMLNIMFMJP = HKGHCIEPGEL.Forfeit;
			BJGCPDNMHDH.MKEGPEBGOGM(KANLHOCIMID: true, HNCPBGJJEPO: true);
		}

		[SpecialName]
		private object DOOAHBLHGFO()
		{
			return PHDOCKCBJOF;
		}

		public void HHCIHDMICFP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HCPKEMLPEDI()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public KCPGHGNIGFP()
		{
		}

		[SpecialName]
		private object IGMIIAODMNF()
		{
			return PHDOCKCBJOF;
		}

		public void OLPILJFHMGD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object DGEECEBHPNC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BGLDNJLBIKM()
		{
			return PHDOCKCBJOF;
		}

		public void KKDOJDCJAJB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		internal void MAKLHLCDIKD()
		{
			BJGCPDNMHDH.MNMLNIMFMJP = (HKGHCIEPGEL)4;
			BJGCPDNMHDH.MKEGPEBGOGM(KANLHOCIMID: true);
		}

		public bool PGOBEIMCPGA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.HDBGBMPCMON = null;
				Singleton<BeanstalkServerManager>.instance.ActionUpdated += BJGCPDNMHDH.EOJIIDEEOEE;
				if (!BJGCPDNMHDH.HCIECMLDPFB)
				{
					goto case 1u;
				}
				goto case 2u;
			case 1u:
				if (!GuiScreenSingle<GameOverScreen>.instance.BFNOINNNHGP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<Recording>.instance.FKLIOPJAAOE();
				PHDOCKCBJOF = new WaitForRealSeconds(1951f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 2u:
				LoadingDialog.NJHOCHGJICN(EDHDMJLHLFA: true);
				LoadingDialog.PGFBMJFLHPC(Localization.Localize("maxMapId"), DMDICGADGCG: true, BGOHKCCLDJP: false, KKLNBPJCLHC: true);
				if (DebugSettings.debugEnabled && BJGCPDNMHDH.HDBGBMPCMON != null)
				{
					LoadingDialog.SetText(BJGCPDNMHDH.HDBGBMPCMON);
				}
				goto case 3u;
			case 3u:
				if (BJGCPDNMHDH.gameEndServerResponse == AHDGGJJAOEO.None)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				Singleton<BeanstalkServerManager>.instance.NNDMMGIGLHH(BJGCPDNMHDH.EOJIIDEEOEE);
				if (BJGCPDNMHDH.gameEndServerResponse == AHDGGJJAOEO.None)
				{
					string text = Localization.Localize("3");
					switch (BJGCPDNMHDH.errorReason)
					{
					case (IJEAJGCCHEF)(-177):
						text = Localization.Localize("ID_CONFIRM_OPPONENTCANCELLED");
						break;
					case (IJEAJGCCHEF)(-178):
						text = Localization.Localize("SquadId");
						break;
					case (IJEAJGCCHEF)(-179):
						text = Localization.Localize("DogTagCap");
						break;
					case (IJEAJGCCHEF)(-180):
						text = Localization.Localize("Beanstalk: Update squad finished");
						break;
					case (IJEAJGCCHEF)135:
						text = Localization.Localize("Grenade_Throwing_Tutorial_Duration");
						break;
					default:
						text = string.Format("Enable Push Notifications - device token is the same! Not sending deviceToken", Localization.Localize("ID_CONFIRM_GAMEDOESNOTEXIST"), (int)BJGCPDNMHDH.errorReason);
						break;
					}
					WarningDialog.JACKIDKHKAI(text, Localization.Localize("shield_shot"), 1284f, CIFEDFPPPOK, string.Empty, JCOGJEEFLBC: true);
					LoadingDialog.PGFBMJFLHPC(Localization.Localize("seconds"), DMDICGADGCG: true);
				}
				if (BJGCPDNMHDH.gameEndServerResponse == (AHDGGJJAOEO)4)
				{
					BJGCPDNMHDH.MKEGPEBGOGM(KANLHOCIMID: true);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object KKKMCHGLHLL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EOKIMMCAABI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LMBPPPOFIOC()
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
				BJGCPDNMHDH.HDBGBMPCMON = null;
				Singleton<BeanstalkServerManager>.instance.FKHHHMDONNC(BJGCPDNMHDH.EOJIIDEEOEE);
				if (!BJGCPDNMHDH.HCIECMLDPFB)
				{
					goto case 1u;
				}
				goto case 2u;
			case 1u:
				if (!GuiScreenSingle<GameOverScreen>.instance.BFNOINNNHGP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<Recording>.instance.FKLIOPJAAOE();
				PHDOCKCBJOF = new WaitForRealSeconds(332f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 2u:
				LoadingDialog.NJHOCHGJICN(EDHDMJLHLFA: true);
				LoadingDialog.PGFBMJFLHPC(Localization.Localize("SetHitByPlayerRPC "), DMDICGADGCG: false, BGOHKCCLDJP: false, KKLNBPJCLHC: true);
				if (DebugSettings.debugEnabled && BJGCPDNMHDH.HDBGBMPCMON != null)
				{
					LoadingDialog.BKOEMIKFMHN(BJGCPDNMHDH.HDBGBMPCMON, LMMNFFJAICA: true);
				}
				goto case 3u;
			case 3u:
				if (BJGCPDNMHDH.gameEndServerResponse == AHDGGJJAOEO.None)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				Singleton<BeanstalkServerManager>.instance.ActionUpdated -= BJGCPDNMHDH.EOJIIDEEOEE;
				if (BJGCPDNMHDH.gameEndServerResponse == AHDGGJJAOEO.Error)
				{
					string text = Localization.Localize("getOriginalAccountId");
					switch (BJGCPDNMHDH.errorReason)
					{
					case (IJEAJGCCHEF)182:
						text = Localization.Localize("CONFIRMAR");
						break;
					case (IJEAJGCCHEF)181:
						text = Localization.Localize("color=\"#FFD700\"");
						break;
					case (IJEAJGCCHEF)180:
						text = Localization.Localize("05");
						break;
					case (IJEAJGCCHEF)179:
						text = Localization.Localize("SquadWarsId");
						break;
					case (IJEAJGCCHEF)184:
						text = Localization.Localize("nextGenerate");
						break;
					default:
						text = string.Format("ID_HOURS", Localization.Localize("menu-twitter"), (int)BJGCPDNMHDH.errorReason);
						break;
					}
					WarningDialog.ShowError(text, Localization.Localize("06"), 186f, PCKMJMGLPDG, string.Empty, JCOGJEEFLBC: true);
					LoadingDialog.PGFBMJFLHPC(Localization.Localize("Heroic"), DMDICGADGCG: false, BGOHKCCLDJP: true, KKLNBPJCLHC: true);
				}
				if (BJGCPDNMHDH.gameEndServerResponse == (AHDGGJJAOEO)7)
				{
					BJGCPDNMHDH.OJIENOPOBLO(KANLHOCIMID: false);
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void NINFNJOMJOD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void NDPOBCODJAI()
		{
			throw new NotSupportedException();
		}

		internal void PCKMJMGLPDG()
		{
			BJGCPDNMHDH.MNMLNIMFMJP = HKGHCIEPGEL.Kia;
			BJGCPDNMHDH.MKEGPEBGOGM(KANLHOCIMID: false, HNCPBGJJEPO: true);
		}

		[SpecialName]
		private object CNGCLCAAHIG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object INAMGPNDAAJ()
		{
			return PHDOCKCBJOF;
		}

		internal void CIFEDFPPPOK()
		{
			BJGCPDNMHDH.MNMLNIMFMJP = HKGHCIEPGEL.Killed;
			BJGCPDNMHDH.OJIENOPOBLO(KANLHOCIMID: true, HNCPBGJJEPO: true);
		}

		public void BCKMHLBBBCK()
		{
			throw new NotSupportedException();
		}

		internal void PANKBNOCEAM()
		{
			BJGCPDNMHDH.MNMLNIMFMJP = HKGHCIEPGEL.Forfeit;
			BJGCPDNMHDH.OJIENOPOBLO(KANLHOCIMID: false, HNCPBGJJEPO: true);
		}

		[SpecialName]
		private object FMCLBOCENPE()
		{
			return PHDOCKCBJOF;
		}

		public void PKMIJKOPPBF()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void LHADJAFHDDC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		internal void NNIJEDKBPGJ()
		{
			BJGCPDNMHDH.MNMLNIMFMJP = HKGHCIEPGEL.Killed;
			BJGCPDNMHDH.MKEGPEBGOGM(KANLHOCIMID: true, HNCPBGJJEPO: true);
		}

		[SpecialName]
		private object BEGHOADNMJF()
		{
			return PHDOCKCBJOF;
		}
	}

	private sealed class KGCALFKEMNC : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal bool HNCPBGJJEPO;

		internal bool KANLHOCIMID;

		internal GameController BJGCPDNMHDH;

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

		public bool HNCDLFFBMAA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Screen.sleepTimeout = 9;
				BJGCPDNMHDH.gameState = AEMPHGEIJNH.Loading;
				LoadingDialog.ShowLoading(Localization.Localize("Lost"));
				if (DebugSettings.debugEnabled && BJGCPDNMHDH.HDBGBMPCMON != null)
				{
					LoadingDialog.BKOEMIKFMHN(BJGCPDNMHDH.HDBGBMPCMON, LMMNFFJAICA: true);
				}
				PHDOCKCBJOF = new WaitForRealSeconds(760f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(value: false);
				Singleton<GameCamera>.instance.LNCHKBAIKEK();
				LightmapSettings.lightmaps = new LightmapData[1];
				// Unity 2018 no longer exposes the old empty LightProbes constructor. Null is
				// the supported representation of an intentionally cleared probe asset.
				LightmapSettings.lightProbes = null;
				PHDOCKCBJOF = new WaitForRealSeconds(97f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 2u:
				TimeManager.Reset();
				Ammo.ammoPool.CHMFDFKCKAG();
				ObjectPoolDatabase.FLAHKAIJHBP().CHMFDFKCKAG();
				ObjectPoolDatabase.GLHPLCEFHGD().FreeWholePool();
				Singleton<MapManager>.instance.BOEBBNOPEMG();
				if (BJGCPDNMHDH.JOCAMIMDBLB != null)
				{
					BJGCPDNMHDH.JOCAMIMDBLB();
				}
				BJGCPDNMHDH.mainController.FreeLevel();
				EnemyLeveledWeapon.HEONPCGEABM();
				PlayerWeapon.HPJHOKJMNOC();
				Singleton<UpgradesManager>.instance.MELNDDADJBI();
				Singleton<SoundsManager3D>.instance.HKKMEPDLGCH();
				CardManager.instance.ReleaseCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: false);
				if (BJGCPDNMHDH.JNFGIPOFKCF != null)
				{
					CardManager.instance.ReleaseCards(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: true);
				}
				if (BJGCPDNMHDH.KKHKAJPNDEC != null)
				{
					CardManager.instance.ReleaseCards(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: false);
				}
				TimeManager.instance.EndOfEndGame();
				PHDOCKCBJOF = new WaitForRealSeconds(1193f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 3u:
				Resources.UnloadUnusedAssets();
				PHDOCKCBJOF = new WaitForRealSeconds(151f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 4u:
				if (!BJGCPDNMHDH.ECHCLJJJPML())
				{
					PlayerAnalytics.instance.UseLastBoughtUnit();
				}
				CamosManager.instance.LoadAll();
				GuiElementSingle<Background>.instance.GDBMDNEHNBO();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.OGHLMGCCCAF());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 5u:
				PHDOCKCBJOF = new WaitForRealSeconds(858f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 6u:
				Singleton<DogTagManager>.instance.ResetLocalDogtags();
				UICamera.instance.cachedCamera.clearFlags = CameraClearFlags.Skybox;
				BJGCPDNMHDH.DIKIPEDCHCF(AEMPHGEIJNH.WaitingForResponse);
				Singleton<Chat>.instance.Connect();
				if (BJGCPDNMHDH.JCMCCAHEBDE)
				{
					BJGCPDNMHDH.JCMCCAHEBDE = false;
					GameLoginManager.instance.AccountChange();
				}
				else if (!BJGCPDNMHDH.HCIECMLDPFB)
				{
					LoadingDialog.Hide();
					if (HNCPBGJJEPO)
					{
						Singleton<BeanstalkServerManager>.instance.BPDHHBFKHJP();
						GameLoginManager.Relog(showScreen: false);
					}
					else if (KANLHOCIMID)
					{
						BJGCPDNMHDH.mainController.ShowResultsScreen();
					}
					else
					{
						ObjectPoolDatabase.InstantiatePooledObjects((NPNOIGHIALL)6);
						Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<MainScreen>.instance);
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object MPEPJNIDBLI()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object LMBPPPOFIOC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MHKODCGLJFD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GOAJCEAOPLA()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public KGCALFKEMNC()
		{
		}

		public void IGBHHLFACKO()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool IDBCKIPOEEI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Screen.sleepTimeout = -13;
				BJGCPDNMHDH.gameState = AEMPHGEIJNH.Playing;
				LoadingDialog.ShowLoading(Localization.Localize("vipId"), DMDICGADGCG: true);
				if (DebugSettings.debugEnabled && BJGCPDNMHDH.HDBGBMPCMON != null)
				{
					LoadingDialog.SetText(BJGCPDNMHDH.HDBGBMPCMON, LMMNFFJAICA: true);
				}
				PHDOCKCBJOF = new WaitForRealSeconds(785f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(value: true);
				Singleton<GameCamera>.instance.LNDHIADPMGP();
				LightmapSettings.lightmaps = new LightmapData[0];
				LightmapSettings.lightProbes = null;
				PHDOCKCBJOF = new WaitForRealSeconds(572f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 2u:
				TimeManager.GEEKOICFEIB();
				Ammo.ammoPool.CHMFDFKCKAG();
				ObjectPoolDatabase.PABAMAJHKIN().CHMFDFKCKAG();
				ObjectPoolDatabase.GLHPLCEFHGD().FreeWholePool();
				Singleton<MapManager>.instance.HPCJHDEGIBE();
				if (BJGCPDNMHDH.JOCAMIMDBLB != null)
				{
					BJGCPDNMHDH.JOCAMIMDBLB();
				}
				BJGCPDNMHDH.mainController.FreeLevel();
				EnemyLeveledWeapon.JOLFHJBHDLG();
				PlayerWeapon.HNLFCDHGDOH();
				Singleton<UpgradesManager>.instance.BGGIGDFAHPM();
				Singleton<SoundsManager3D>.instance.FJDJGKOGHDH();
				CardManager.instance.ReleaseCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: true);
				if (BJGCPDNMHDH.JNFGIPOFKCF != null)
				{
					CardManager.instance.ReleaseCards(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: false);
				}
				if (BJGCPDNMHDH.KKHKAJPNDEC != null)
				{
					CardManager.instance.ReleaseCards(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: false);
				}
				TimeManager.instance.EndOfEndGame();
				PHDOCKCBJOF = new WaitForRealSeconds(1170f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 3u:
				Resources.UnloadUnusedAssets();
				PHDOCKCBJOF = new WaitForRealSeconds(579f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 4u:
				if (!BJGCPDNMHDH.ECHCLJJJPML())
				{
					PlayerAnalytics.instance.UseLastBoughtUnit();
				}
				CamosManager.instance.LoadAll();
				GuiElementSingle<Background>.instance.FABHDIEENGE();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.FPPHKIGCGFG());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 5u:
				PHDOCKCBJOF = new WaitForRealSeconds(1464f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 6u:
				Singleton<DogTagManager>.instance.OGBBHOGJJMC();
				UICamera.instance.cachedCamera.clearFlags = (CameraClearFlags)6;
				BJGCPDNMHDH.gameState = AEMPHGEIJNH.WaitingForResponse;
				Singleton<Chat>.instance.OLGBMILOMNH();
				if (BJGCPDNMHDH.JCMCCAHEBDE)
				{
					BJGCPDNMHDH.JCMCCAHEBDE = false;
					GameLoginManager.instance.AccountChange();
				}
				else if (!BJGCPDNMHDH.HCIECMLDPFB)
				{
					LoadingDialog.Hide();
					if (HNCPBGJJEPO)
					{
						Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
						GameLoginManager.Relog(showScreen: false);
					}
					else if (KANLHOCIMID)
					{
						BJGCPDNMHDH.mainController.ShowResultsScreen();
					}
					else
					{
						ObjectPoolDatabase.OJOAADFNHFN(NPNOIGHIALL.Menu);
						Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<MainScreen>.instance);
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool OKELILGDPLJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Screen.sleepTimeout = -40;
				BJGCPDNMHDH.DIKIPEDCHCF(AEMPHGEIJNH.Menu);
				LoadingDialog.PGFBMJFLHPC(Localization.Localize("Reward {0:D2}"), DMDICGADGCG: false, BGOHKCCLDJP: false, KKLNBPJCLHC: true);
				if (DebugSettings.debugEnabled && BJGCPDNMHDH.HDBGBMPCMON != null)
				{
					LoadingDialog.BKOEMIKFMHN(BJGCPDNMHDH.HDBGBMPCMON);
				}
				PHDOCKCBJOF = new WaitForRealSeconds(1350f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(value: false);
				Singleton<GameCamera>.instance.Disable();
				LightmapSettings.lightmaps = new LightmapData[0];
				LightmapSettings.lightProbes = null;
				PHDOCKCBJOF = new WaitForRealSeconds(78f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 2u:
				TimeManager.GEEKOICFEIB();
				Ammo.ammoPool.CHMFDFKCKAG();
				ObjectPoolDatabase.ammoPool.CFILHOEHMEK();
				ObjectPoolDatabase.DKNHCGGKNMF().CHMFDFKCKAG();
				Singleton<MapManager>.instance.DestroyCurrentScene();
				if (BJGCPDNMHDH.JOCAMIMDBLB != null)
				{
					BJGCPDNMHDH.JOCAMIMDBLB();
				}
				BJGCPDNMHDH.mainController.FreeLevel();
				EnemyLeveledWeapon.PGMDLJLCEDL();
				PlayerWeapon.HNLFCDHGDOH();
				Singleton<UpgradesManager>.instance.PKNCJFPMBHG();
				Singleton<SoundsManager3D>.instance.FJDJGKOGHDH();
				CardManager.instance.ReleaseCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: false);
				if (BJGCPDNMHDH.JNFGIPOFKCF != null)
				{
					CardManager.instance.ReleaseCards(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: true);
				}
				if (BJGCPDNMHDH.KKHKAJPNDEC != null)
				{
					CardManager.instance.ReleaseCards(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: true);
				}
				TimeManager.instance.EndOfEndGame();
				PHDOCKCBJOF = new WaitForRealSeconds(1846f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 3u:
				Resources.UnloadUnusedAssets();
				PHDOCKCBJOF = new WaitForRealSeconds(660f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 4u:
				if (!BJGCPDNMHDH.isMission)
				{
					PlayerAnalytics.instance.UseLastBoughtUnit();
				}
				CamosManager.instance.LoadAll();
				GuiElementSingle<Background>.instance.FDDDDLNKACJ();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.HIEDGFKNLOK());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 5u:
				PHDOCKCBJOF = new WaitForRealSeconds(119f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 6u:
				Singleton<DogTagManager>.instance.ResetLocalDogtags();
				UICamera.instance.cachedCamera.clearFlags = CameraClearFlags.Skybox;
				BJGCPDNMHDH.DIKIPEDCHCF(AEMPHGEIJNH.Menu);
				Singleton<Chat>.instance.DHBMLBNMOCF();
				if (BJGCPDNMHDH.JCMCCAHEBDE)
				{
					BJGCPDNMHDH.JCMCCAHEBDE = false;
					GameLoginManager.instance.AccountChange();
				}
				else if (!BJGCPDNMHDH.HCIECMLDPFB)
				{
					LoadingDialog.Hide();
					if (HNCPBGJJEPO)
					{
						Singleton<BeanstalkServerManager>.instance.EOAILOJFNJG();
						GameLoginManager.Relog();
					}
					else if (KANLHOCIMID)
					{
						BJGCPDNMHDH.mainController.ShowResultsScreen();
					}
					else
					{
						ObjectPoolDatabase.EOGLFOKEDPF((NPNOIGHIALL)5);
						Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<MainScreen>.instance);
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object HCCLNDKNCIE()
		{
			return PHDOCKCBJOF;
		}

		public void OKIANDBCDIB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void JJOAHIOBOPO()
		{
			throw new NotSupportedException();
		}

		public void GCEMCPODLNM()
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
				Screen.sleepTimeout = -2;
				BJGCPDNMHDH.gameState = AEMPHGEIJNH.Loading;
				LoadingDialog.ShowLoading(Localization.Localize("ID_LOADING"), DMDICGADGCG: false, BGOHKCCLDJP: true);
				if (DebugSettings.debugEnabled && BJGCPDNMHDH.HDBGBMPCMON != null)
				{
					LoadingDialog.SetText(BJGCPDNMHDH.HDBGBMPCMON);
				}
				PHDOCKCBJOF = new WaitForRealSeconds(0.5f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(value: false);
				Singleton<GameCamera>.instance.Disable();
				LightmapSettings.lightmaps = new LightmapData[0];
				LightmapSettings.lightProbes = null;
				PHDOCKCBJOF = new WaitForRealSeconds(0.2f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
				TimeManager.Reset();
				Ammo.ammoPool.FreeWholePool();
				ObjectPoolDatabase.ammoPool.FreeWholePool();
				ObjectPoolDatabase.networkPool.FreeWholePool();
				Singleton<MapManager>.instance.DestroyCurrentScene();
				if (BJGCPDNMHDH.JOCAMIMDBLB != null)
				{
					BJGCPDNMHDH.JOCAMIMDBLB();
				}
				BJGCPDNMHDH.mainController.FreeLevel();
				EnemyLeveledWeapon.ClearModels();
				PlayerWeapon.ClearModels();
				Singleton<UpgradesManager>.instance.UnloadAll();
				Singleton<SoundsManager3D>.instance.UnloadSounds();
				CardManager.instance.ReleaseCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: true);
				if (BJGCPDNMHDH.JNFGIPOFKCF != null)
				{
					CardManager.instance.ReleaseCards(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: false);
				}
				if (BJGCPDNMHDH.KKHKAJPNDEC != null)
				{
					CardManager.instance.ReleaseCards(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: false);
				}
				TimeManager.instance.EndOfEndGame();
				PHDOCKCBJOF = new WaitForRealSeconds(0.2f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 3u:
				Resources.UnloadUnusedAssets();
				PHDOCKCBJOF = new WaitForRealSeconds(0.5f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 4u:
				if (!BJGCPDNMHDH.isMission)
				{
					PlayerAnalytics.instance.UseLastBoughtUnit();
				}
				CamosManager.instance.LoadAll();
				GuiElementSingle<Background>.instance.LoadParallax();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.LoadMenuClearGameCoroutine());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 5u:
				PHDOCKCBJOF = new WaitForRealSeconds(0.2f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 6u:
				Singleton<DogTagManager>.instance.ResetLocalDogtags();
				UICamera.instance.cachedCamera.clearFlags = CameraClearFlags.Nothing;
				BJGCPDNMHDH.gameState = AEMPHGEIJNH.Menu;
				Singleton<Chat>.instance.Connect();
				if (BJGCPDNMHDH.JCMCCAHEBDE)
				{
					BJGCPDNMHDH.JCMCCAHEBDE = false;
					GameLoginManager.instance.AccountChange();
				}
				else if (!BJGCPDNMHDH.HCIECMLDPFB)
				{
					LoadingDialog.Hide();
					if (HNCPBGJJEPO)
					{
						Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
						GameLoginManager.Relog();
					}
					else if (KANLHOCIMID)
					{
						BJGCPDNMHDH.mainController.ShowResultsScreen();
					}
					else
					{
						ObjectPoolDatabase.InstantiatePooledObjects(NPNOIGHIALL.Menu);
						Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<MainScreen>.instance);
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object CLFFFNGBPGJ()
		{
			return PHDOCKCBJOF;
		}

		public void FMOJMHBAHAA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool FNEPBDLIKOD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				Screen.sleepTimeout = -61;
				BJGCPDNMHDH.DIKIPEDCHCF(AEMPHGEIJNH.Menu);
				LoadingDialog.ShowLoading(Localization.Localize("Level"), DMDICGADGCG: false, BGOHKCCLDJP: true, KKLNBPJCLHC: true);
				if (DebugSettings.debugEnabled && BJGCPDNMHDH.HDBGBMPCMON != null)
				{
					LoadingDialog.SetText(BJGCPDNMHDH.HDBGBMPCMON);
				}
				PHDOCKCBJOF = new WaitForRealSeconds(102f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				PlayerController.OGMBJPKOPCB.gameObject.SetActive(value: true);
				Singleton<GameCamera>.instance.LNCHKBAIKEK();
				LightmapSettings.lightmaps = new LightmapData[1];
				LightmapSettings.lightProbes = null;
				PHDOCKCBJOF = new WaitForRealSeconds(674f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 2u:
				TimeManager.Reset();
				Ammo.ammoPool.CFILHOEHMEK();
				ObjectPoolDatabase.PABAMAJHKIN().FreeWholePool();
				ObjectPoolDatabase.ADBOHNCGKHA().FreeWholePool();
				Singleton<MapManager>.instance.HPCJHDEGIBE();
				if (BJGCPDNMHDH.JOCAMIMDBLB != null)
				{
					BJGCPDNMHDH.JOCAMIMDBLB();
				}
				BJGCPDNMHDH.mainController.FreeLevel();
				EnemyLeveledWeapon.INBIKNDHDNF();
				PlayerWeapon.ClearModels();
				Singleton<UpgradesManager>.instance.BNDNGPKOAPB();
				Singleton<SoundsManager3D>.instance.HKKMEPDLGCH();
				CardManager.instance.ReleaseCards(PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: true);
				if (BJGCPDNMHDH.JNFGIPOFKCF != null)
				{
					CardManager.instance.ReleaseCards(BJGCPDNMHDH.JNFGIPOFKCF.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: true, isCurrentPlayer: false);
				}
				if (BJGCPDNMHDH.KKHKAJPNDEC != null)
				{
					CardManager.instance.ReleaseCards(BJGCPDNMHDH.KKHKAJPNDEC.EHHHBEMKGOE.AAOAKDPIEII, isOpponnetCard: false, isCurrentPlayer: true);
				}
				TimeManager.instance.EndOfEndGame();
				PHDOCKCBJOF = new WaitForRealSeconds(1790f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 3u:
				Resources.UnloadUnusedAssets();
				PHDOCKCBJOF = new WaitForRealSeconds(1079f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 4u:
				if (!BJGCPDNMHDH.ECHCLJJJPML())
				{
					PlayerAnalytics.instance.UseLastBoughtUnit();
				}
				CamosManager.instance.LoadAll();
				GuiElementSingle<Background>.instance.FDDDDLNKACJ();
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<AtlasPreparer>.instance.KOPHFEBKGMO());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 5u:
				PHDOCKCBJOF = new WaitForRealSeconds(1536f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 6u:
				Singleton<DogTagManager>.instance.OGBBHOGJJMC();
				UICamera.instance.cachedCamera.clearFlags = (CameraClearFlags)5;
				BJGCPDNMHDH.gameState = AEMPHGEIJNH.WaitingForResponse;
				Singleton<Chat>.instance.JGOOLPIAOCO();
				if (BJGCPDNMHDH.JCMCCAHEBDE)
				{
					BJGCPDNMHDH.JCMCCAHEBDE = true;
					GameLoginManager.instance.AccountChange();
				}
				else if (!BJGCPDNMHDH.HCIECMLDPFB)
				{
					LoadingDialog.Hide();
					if (HNCPBGJJEPO)
					{
						Singleton<BeanstalkServerManager>.instance.BKPEOBBLCNG();
						GameLoginManager.Relog();
					}
					else if (KANLHOCIMID)
					{
						BJGCPDNMHDH.mainController.ShowResultsScreen();
					}
					else
					{
						ObjectPoolDatabase.InstantiatePooledObjects(NPNOIGHIALL.Menu);
						Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<MainScreen>.instance);
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AEMPHGEIJNH _003CLFKKFABIGGM_003Ek__BackingField;

	[FormerlySerializedAs("BBKLJKAKJME")]
	public GameControllerCampaign FJODNDELMBL;

	[FormerlySerializedAs("MGIJOKDKDJJ")]
	public GameControllerCoop GEBDKFCNCAC;

	[FormerlySerializedAs("HIAHKAEFHOC")]
	public GameControllerDeathMatch GMNKFFNFEHG;

	[FormerlySerializedAs("KMFDOMOJAEJ")]
	public GameControllerDeathMatchOffline NOPKOCCCFIM;

	[FormerlySerializedAs("KCEOMJEOJFA")]
	public GameControllerTutorial CBAPHFGNLLH;

	[FormerlySerializedAs("DDEJOBGOOBF")]
	public GameControllerWarArena MBPKLMKBJAB;

	public HKGHCIEPGEL MNMLNIMFMJP;

	[FormerlySerializedAs("MMDBHABIMBG")]
	public AudioClip ALPBOGHGLGK;

	private bool? GJFHKPIHDCH;

	private bool OKFJGLIACLC;

	private bool GOEOJDFMNPF;

	private bool HCIECMLDPFB;

	private bool JCMCCAHEBDE;

	private ICFCHEHNHEN NGDKKFFCGCI;

	private IGameController DHBCAGBEIHJ;

	private PlayerController JNFGIPOFKCF;

	[FormerlySerializedAs("PBBDJAODLIJ")]
	public PlayerController KKHKAJPNDEC;

	[FormerlySerializedAs("MHHPANHFGJC")]
	public string KMJGIGDJKMH;

	[FormerlySerializedAs("NAGCCPFHPOB")]
	public AudioClip JIMEEFOHFCC;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action<HKGHCIEPGEL> HKCMKDFCNBP;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private JGAGFCMIHHJ NIEFNMJIAHL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private JGAGFCMIHHJ MLDDKLFPFPF;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private JGAGFCMIHHJ OGFHPHILDKC;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action JOCAMIMDBLB;

	private string FIFJMOAINMF;

	private bool PBJPODPEHCB;

	[FormerlySerializedAs("ELIALMPMEGM")]
	public PlayerController FHABFFKPODN;

	private string HDBGBMPCMON;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AHDGGJJAOEO _003CMIPJPKFEMAJ_003Ek__BackingField;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private IJEAJGCCHEF _003CECLGOPKEKBK_003Ek__BackingField;

	public AEMPHGEIJNH gameState
	{
		[CompilerGenerated]
		get
		{
			return _003CLFKKFABIGGM_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CLFKKFABIGGM_003Ek__BackingField = value;
		}
	}

	public IGameController mainController
	{
		get
		{
			return DHBCAGBEIHJ;
		}
		set
		{
			FAKMIGKOEFD(FJODNDELMBL, value);
			FAKMIGKOEFD(GEBDKFCNCAC, value);
			FAKMIGKOEFD(GMNKFFNFEHG, value);
			FAKMIGKOEFD(NOPKOCCCFIM, value);
			FAKMIGKOEFD(CBAPHFGNLLH, value);
			FAKMIGKOEFD(MBPKLMKBJAB, value);
			DHBCAGBEIHJ = value;
		}
	}

	public float time => mainController.time;

	public bool wonLastGame => MNMLNIMFMJP == HKGHCIEPGEL.MissionSuccess || MNMLNIMFMJP == HKGHCIEPGEL.Win || MNMLNIMFMJP == HKGHCIEPGEL.WinByForfeit;

	public bool gameIsRunning
	{
		get
		{
			return OKFJGLIACLC;
		}
		set
		{
			TimeManager.instance.KFHGKFELCDG = value;
			OKFJGLIACLC = value;
		}
	}

	public ELDLECMNIME gameType
	{
		get
		{
			if (isCoop)
			{
				return ELDLECMNIME.Coop;
			}
			if (isDeathMatch)
			{
				return ELDLECMNIME.DeathMatch;
			}
			if (isDeathMatchOffline)
			{
				return ELDLECMNIME.DeathMatchOffline;
			}
			if (isWarArena)
			{
				return ELDLECMNIME.WarArena;
			}
			return ELDLECMNIME.Campaign;
		}
	}

	public bool isMission => isCampaign || isCoop;

	public bool isCampaign => object.Equals(mainController, FJODNDELMBL);

	public bool isCoop => object.Equals(mainController, GEBDKFCNCAC);

	public bool isBattle => isDeathMatch || isDeathMatchOffline;

	public bool isPVP => isDeathMatch || isDeathMatchOffline || isWarArena;

	public bool isDeathMatch => object.Equals(mainController, GMNKFFNFEHG);

	public bool isDeathMatchOffline => object.Equals(mainController, NOPKOCCCFIM);

	public bool isWarArena => object.Equals(mainController, MBPKLMKBJAB);

	public bool isTutorial => object.Equals(mainController, CBAPHFGNLLH);

	public bool isTutorialInProgressOrPlaned => PBJPODPEHCB || isTutorial;

	public bool isNotTutorialEnded => isTutorialInProgressOrPlaned && !TutorialManagerStage3.instance.isTutorialNearEnd;

	public bool isTutorialStage1 => object.Equals(mainController, CBAPHFGNLLH) && TutorialManagerStage1.instance.isTutorialRunning;

	public bool isTutorialStage2 => object.Equals(mainController, CBAPHFGNLLH) && TutorialManagerStage2.instance.isTutorialRunning;

	public bool isTutorialStage3 => object.Equals(mainController, CBAPHFGNLLH) && TutorialManagerStage3.instance.isTutorialRunning;

	public bool isFirstLoadingOfWarfriends => !SavingLastSelected.instance.firstTutorialGameEnded;

	public string battleId
	{
		get
		{
			return FIFJMOAINMF;
		}
		set
		{
			FIFJMOAINMF = value;
		}
	}

	public bool isRandomMatchMaking => isBattle && GMNKFFNFEHG.isRandomMatchMaking;

	public bool isChallenge => isBattle && !GMNKFFNFEHG.isRandomMatchMaking;

	public bool isInMenuOrWait => gameState <= AEMPHGEIJNH.WaitingForResponse;

	public bool isLoadingOrPlaying => gameState >= AEMPHGEIJNH.Loading;

	public AHDGGJJAOEO gameEndServerResponse
	{
		[CompilerGenerated]
		get
		{
			return _003CMIPJPKFEMAJ_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CMIPJPKFEMAJ_003Ek__BackingField = value;
		}
	}

	public IJEAJGCCHEF errorReason
	{
		[CompilerGenerated]
		get
		{
			return _003CECLGOPKEKBK_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CECLGOPKEKBK_003Ek__BackingField = value;
		}
	}

	public PlayerController opponent
	{
		get
		{
			return JNFGIPOFKCF;
		}
		set
		{
			UnityEngine.Debug.Log("Set opponent: " + ((!(value != null)) ? "null" : value.name));
			JNFGIPOFKCF = value;
		}
	}

	public event Action<HKGHCIEPGEL> GameEnded
	{
		add
		{
			Action<HKGHCIEPGEL> action = HKCMKDFCNBP;
			Action<HKGHCIEPGEL> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref HKCMKDFCNBP, (Action<HKGHCIEPGEL>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<HKGHCIEPGEL> action = HKCMKDFCNBP;
			Action<HKGHCIEPGEL> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref HKCMKDFCNBP, (Action<HKGHCIEPGEL>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public event JGAGFCMIHHJ BeforeGameStarted
	{
		add
		{
			JGAGFCMIHHJ jGAGFCMIHHJ = NIEFNMJIAHL;
			JGAGFCMIHHJ jGAGFCMIHHJ2;
			do
			{
				jGAGFCMIHHJ2 = jGAGFCMIHHJ;
				jGAGFCMIHHJ = Interlocked.CompareExchange(ref NIEFNMJIAHL, (JGAGFCMIHHJ)Delegate.Combine(jGAGFCMIHHJ2, value), jGAGFCMIHHJ);
			}
			while ((object)jGAGFCMIHHJ != jGAGFCMIHHJ2);
		}
		remove
		{
			JGAGFCMIHHJ jGAGFCMIHHJ = NIEFNMJIAHL;
			JGAGFCMIHHJ jGAGFCMIHHJ2;
			do
			{
				jGAGFCMIHHJ2 = jGAGFCMIHHJ;
				jGAGFCMIHHJ = Interlocked.CompareExchange(ref NIEFNMJIAHL, (JGAGFCMIHHJ)Delegate.Remove(jGAGFCMIHHJ2, value), jGAGFCMIHHJ);
			}
			while ((object)jGAGFCMIHHJ != jGAGFCMIHHJ2);
		}
	}

	public event JGAGFCMIHHJ GameStarted
	{
		add
		{
			JGAGFCMIHHJ jGAGFCMIHHJ = MLDDKLFPFPF;
			JGAGFCMIHHJ jGAGFCMIHHJ2;
			do
			{
				jGAGFCMIHHJ2 = jGAGFCMIHHJ;
				jGAGFCMIHHJ = Interlocked.CompareExchange(ref MLDDKLFPFPF, (JGAGFCMIHHJ)Delegate.Combine(jGAGFCMIHHJ2, value), jGAGFCMIHHJ);
			}
			while ((object)jGAGFCMIHHJ != jGAGFCMIHHJ2);
		}
		remove
		{
			JGAGFCMIHHJ jGAGFCMIHHJ = MLDDKLFPFPF;
			JGAGFCMIHHJ jGAGFCMIHHJ2;
			do
			{
				jGAGFCMIHHJ2 = jGAGFCMIHHJ;
				jGAGFCMIHHJ = Interlocked.CompareExchange(ref MLDDKLFPFPF, (JGAGFCMIHHJ)Delegate.Remove(jGAGFCMIHHJ2, value), jGAGFCMIHHJ);
			}
			while ((object)jGAGFCMIHHJ != jGAGFCMIHHJ2);
		}
	}

	public event JGAGFCMIHHJ AfterGameStarted
	{
		add
		{
			JGAGFCMIHHJ jGAGFCMIHHJ = OGFHPHILDKC;
			JGAGFCMIHHJ jGAGFCMIHHJ2;
			do
			{
				jGAGFCMIHHJ2 = jGAGFCMIHHJ;
				jGAGFCMIHHJ = Interlocked.CompareExchange(ref OGFHPHILDKC, (JGAGFCMIHHJ)Delegate.Combine(jGAGFCMIHHJ2, value), jGAGFCMIHHJ);
			}
			while ((object)jGAGFCMIHHJ != jGAGFCMIHHJ2);
		}
		remove
		{
			JGAGFCMIHHJ jGAGFCMIHHJ = OGFHPHILDKC;
			JGAGFCMIHHJ jGAGFCMIHHJ2;
			do
			{
				jGAGFCMIHHJ2 = jGAGFCMIHHJ;
				jGAGFCMIHHJ = Interlocked.CompareExchange(ref OGFHPHILDKC, (JGAGFCMIHHJ)Delegate.Remove(jGAGFCMIHHJ2, value), jGAGFCMIHHJ);
			}
			while ((object)jGAGFCMIHHJ != jGAGFCMIHHJ2);
		}
	}

	public event Action SceneFreed
	{
		add
		{
			Action action = JOCAMIMDBLB;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref JOCAMIMDBLB, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = JOCAMIMDBLB;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref JOCAMIMDBLB, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	[SpecialName]
	public void CEJMPILMGBJ(JGAGFCMIHHJ IDEBKDPMPGM)
	{
		JGAGFCMIHHJ jGAGFCMIHHJ = OGFHPHILDKC;
		JGAGFCMIHHJ jGAGFCMIHHJ2;
		do
		{
			jGAGFCMIHHJ2 = jGAGFCMIHHJ;
			jGAGFCMIHHJ = Interlocked.CompareExchange(ref OGFHPHILDKC, (JGAGFCMIHHJ)Delegate.Remove(jGAGFCMIHHJ2, IDEBKDPMPGM), jGAGFCMIHHJ);
		}
		while ((object)jGAGFCMIHHJ != jGAGFCMIHHJ2);
	}

	[SpecialName]
	public bool LLCIMHJOOCB()
	{
		return object.Equals(mainController, GMNKFFNFEHG);
	}

	public void JPMCHLOGHJK()
	{
		mainController.StopGame();
		mainController.Forfeit();
		JCMCCAHEBDE = false;
	}

	private void EPLLBNHACFJ()
	{
		try
		{
			LoadingDialog.FDBHFJFKALH(string.Empty, DMDICGADGCG: true, BGOHKCCLDJP: false, KKLNBPJCLHC: true);
			GameLoginManager.instance.RegisterOrLogin(SessionManager.MFGMKAJDCAI.None);
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.LogError("\n" + ex.Message);
			UnityEngine.Debug.LogError("InstantBattleEnded: Instant Battle Time " + ex.StackTrace);
			DialogManager.instance.HideAllDialogs();
			WarningDialog.ShowError(Localization.LocalizeFormat("globalSquadLeaderboard", ex.Message), Localization.Localize("ID_ZEROSECONDS"), 987f, delegate
			{
				UnityEngine.Debug.Log("RETRY");
				AKDMOOGBMBC();
			}, string.Empty);
		}
	}

	[SpecialName]
	public bool BGAJLJEJEFG()
	{
		return !isBattle || GMNKFFNFEHG.isRandomMatchMaking;
	}

	protected void OnApplicationPause(bool NMCKKMEKOHM)
	{
		if (NMCKKMEKOHM)
		{
			mainController.PauseGame(IEFGEFFDHOK: true);
			UnityEngine.Debug.Log("Application paused");
		}
	}

	public void StartMultiplayerGame(DatabasePlayer KHLGDCHJJPB)
	{
		GOEOJDFMNPF = false;
		string JLBLNDGIINB;
		bool MKDDIBOHCIA;
		if (isDeathMatch)
		{
			GMNKFFNFEHG.StartMultiplayerGame(KHLGDCHJJPB, out JLBLNDGIINB, out MKDDIBOHCIA);
			if (MKDDIBOHCIA)
			{
				Singleton<BeanstalkServerManager>.instance.Challenge(KHLGDCHJJPB, Singleton<MapManager>.instance.currentMap.name, JLBLNDGIINB: JLBLNDGIINB, HLPHCDNMJLG: -1, OKIIAAPDJIK: string.Empty, ADBBOLJGLCA: string.Empty);
				GuiScreenSingle<CardSelectionScreen>.instance.ShowLobby();
			}
			else
			{
				WarningDialog.ShowError(Localization.Localize("ID_WARNING_CANNOTINVITE_TEXT"), Localization.Localize("ID_WARNING_CANNOTINVITE"), 0f, null, string.Empty);
				Singleton<PhotonConnectionManager>.instance.CheckPingsNow();
			}
		}
		if (isCoop)
		{
			GEBDKFCNCAC.StartMultiplayerGame(KHLGDCHJJPB, out JLBLNDGIINB, out MKDDIBOHCIA);
			if (MKDDIBOHCIA)
			{
				DailyMission currentMission = DailyMissionsManager.instance.currentMission;
				int num = DailyMissionsManager.instance.currentMission.number - 1;
				SavedMission savedMission = DailyMissionsManager.instance.data.dailyMissions[num];
				JToken value = JToken.FromObject(currentMission.config);
				string aDBBOLJGLCA = JsonConvert.SerializeObject(value);
				Singleton<BeanstalkServerManager>.instance.Challenge(KHLGDCHJJPB, Singleton<MapManager>.instance.currentMap.name, num, savedMission.missionType, aDBBOLJGLCA, JLBLNDGIINB);
			}
			else
			{
				WarningDialog.ShowError(Localization.Localize("ID_WARNING_CANNOTINVITE_TEXT"), Localization.Localize("ID_WARNING_CANNOTINVITE"), 0f, null, string.Empty);
				Singleton<PhotonConnectionManager>.instance.CheckPingsNow();
			}
		}
	}

	public IEnumerator PODMAPJPBJK()
	{
		APOEGAMPAFA aPOEGAMPAFA = new APOEGAMPAFA();
		aPOEGAMPAFA.BJGCPDNMHDH = this;
		return aPOEGAMPAFA;
	}

	[SpecialName]
	public bool NLJPNIIIGLK()
	{
		return object.Equals(mainController, NOPKOCCCFIM);
	}

	public void OnGameResumed(TimeManager.HICMJEBLEDA HBDEGMCLFDD)
	{
		GuiElementSingle<PauseScreen>.instance.HideDialog();
	}

	public void EOOPIGOEFMC(string FBEAOHMDKDJ = "ModernTown")
	{
		GJFHKPIHDCH = null;
		ALJKAAMHHLB.PIEBOOFPHPC("withPublisherSubAdgroup" + FBEAOHMDKDJ + "Wrong_Category");
		mainController.LoadingStarted();
		ALJKAAMHHLB.GJJDKOMHHDH("special");
		StartCoroutine(BJCPBHKLMCH(FBEAOHMDKDJ));
		ALJKAAMHHLB.PJIMOPNDNKO("userId");
	}

	public void CEHPKOFNDIL()
	{
		mainController = NOPKOCCCFIM;
		UnityEngine.Debug.Log("ID_OFFERACTIVE");
	}

	public void ContinueOrStartTutorial()
	{
		UnityEngine.Debug.Log("#VAVRO# set continue in tutorial");
		PBJPODPEHCB = true;
	}

	public void FAFIFKHDPKN()
	{
		PBJPODPEHCB = true;
	}

	private void EOJIIDEEOEE(DatabaseAction MHLAAHNPMFG, int NOCEDALFEJM, CAMPAFGONHH LLAOOPMGBAG)
	{
		if (DebugSettings.debugEnabled)
		{
			HDBGBMPCMON = $"WaitForGameEndResponse Try {NOCEDALFEJM} action {LLAOOPMGBAG}";
			UnityEngine.Debug.Log(HDBGBMPCMON + " time: " + Time.realtimeSinceStartup);
			LoadingDialog.SetText(HDBGBMPCMON);
		}
	}

	[CompilerGenerated]
	private void OPMCCGBAOOJ()
	{
		UnityEngine.Debug.Log("RETRY");
		AKDMOOGBMBC();
	}

	private void MKEGPEBGOGM(bool KANLHOCIMID, bool HNCPBGJJEPO = false)
	{
		StartCoroutine(RadicalRoutine.Run(KLHDGAFHIKI(KANLHOCIMID, HNCPBGJJEPO)));
	}

	public void COENHPMMCNN()
	{
		UnityEngine.Debug.Log("ID_TURRETBUILDTIME");
		SoundsManager.Instance.PlaySound((!wonLastGame) ? ALPBOGHGLGK : JIMEEFOHFCC, 591f);
		HCIECMLDPFB = false;
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<GameOverScreen>.instance);
		StartCoroutine(RadicalRoutine.Run(NPOCKLJOIDP()));
		if (HKCMKDFCNBP != null)
		{
			Delegate[] invocationList = HKCMKDFCNBP.GetInvocationList();
			for (int i = 1; i < invocationList.Length; i += 0)
			{
				try
				{
					Delegate obj = invocationList[i];
					MethodInfo method = obj.Method;
					object target = obj.Target;
					object[] array = new object[0];
					array[1] = MNMLNIMFMJP;
					method.Invoke(target, array);
				}
				catch (Exception exception)
				{
					AnalyticsHelper.LogHandledException(exception);
				}
			}
		}
		BattleAnalyticsManager.NPAJKFMCPPC().FinishGame();
		Singleton<BeanstalkServerManager>.instance.FPIOOBKMHFN(MNMLNIMFMJP);
	}

	[SpecialName]
	public AEMPHGEIJNH AFDJHMHONOH()
	{
		return _003CLFKKFABIGGM_003Ek__BackingField;
	}

	private void ACHLLDKBHMO(string DAIFMFEBDMB = "")
	{
		if (!string.IsNullOrEmpty(DAIFMFEBDMB))
		{
			battleId = DAIFMFEBDMB;
		}
		SwitchToTutorial();
		string mapName = GameControllerTutorial.GetMapName();
		StartGame(mapName);
	}

	[SpecialName]
	public bool HMBNJHKKIPJ()
	{
		return object.Equals(mainController, FJODNDELMBL);
	}

	[SpecialName]
	public bool BAKCODKBCPJ()
	{
		return object.Equals(mainController, CBAPHFGNLLH);
	}

	[SpecialName]
	public void MAMBOBJAGOJ(Action<HKGHCIEPGEL> IDEBKDPMPGM)
	{
		Action<HKGHCIEPGEL> action = HKCMKDFCNBP;
		Action<HKGHCIEPGEL> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref HKCMKDFCNBP, (Action<HKGHCIEPGEL>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public bool GMFAFJHGFIH(HHFHFANGCEJ PNAKMCNGGHE)
	{
		NGDKKFFCGCI = (ICFCHEHNHEN)PNAKMCNGGHE;
		if (NGDKKFFCGCI.CBIOKPKJNPC != Singleton<CurrentBundleVersion>.instance.OAEMJCMHBAL())
		{
			WarningDialog.JACKIDKHKAI(Localization.LocalizeFormat("Card withdrawn", NGDKKFFCGCI.CBIOKPKJNPC, Singleton<CurrentBundleVersion>.instance.photonVersion, null), Localization.Localize("\"NEGINFINITY\""), 764f, null, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
			return false;
		}
		return true;
	}

	public void OFOIBAENJFA()
	{
		PLBGGPKGHKN(GMNKFFNFEHG);
		GMNKFFNFEHG.isInMatch = true;
	}

	[SpecialName]
	public bool ICINKELJCAH()
	{
		return object.Equals(mainController, CBAPHFGNLLH) && TutorialManagerStage1.instance.isTutorialRunning;
	}

	public void StartGame(string FBEAOHMDKDJ = "ModernTown")
	{
		GJFHKPIHDCH = null;
		ALJKAAMHHLB.POPONJAMPDF("GameController.StartGame '" + FBEAOHMDKDJ + "' START");
		mainController.LoadingStarted();
		ALJKAAMHHLB.POPONJAMPDF("GameController.StartGame - LoadingStarted");
		StartCoroutine(MDACPGHOIIN(FBEAOHMDKDJ));
		ALJKAAMHHLB.POPONJAMPDF("GameController.StartGame - DONE");
	}

	[SpecialName]
	public bool ECHCLJJJPML()
	{
		return HMBNJHKKIPJ() || MNPNHJKBNCJ();
	}

	public void CAOMINCKBBO()
	{
		PLBGGPKGHKN(FJODNDELMBL);
	}

	[SpecialName]
	public bool GHKPKDPOGHF()
	{
		return OKFJGLIACLC;
	}

	public void Rematch()
	{
		mainController.Rematch();
	}

	[SpecialName]
	public void CNPGMMPAGIE(Action<HKGHCIEPGEL> IDEBKDPMPGM)
	{
		Action<HKGHCIEPGEL> action = HKCMKDFCNBP;
		Action<HKGHCIEPGEL> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref HKCMKDFCNBP, (Action<HKGHCIEPGEL>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public bool KKHKIEFMENC()
	{
		return OKFJGLIACLC;
	}

	public bool DKFCCEEKACL(HHFHFANGCEJ PNAKMCNGGHE)
	{
		NGDKKFFCGCI = (ICFCHEHNHEN)PNAKMCNGGHE;
		if (NGDKKFFCGCI.CBIOKPKJNPC != Singleton<CurrentBundleVersion>.instance.JEEDKJKOPLI())
		{
			object[] array = new object[1];
			array[0] = NGDKKFFCGCI.CBIOKPKJNPC;
			array[1] = Singleton<CurrentBundleVersion>.instance.EGCFOBBHLBH();
			WarningDialog.KHOMNBHMFGA(Localization.LocalizeFormat("CH", array), Localization.Localize("Player_Waited_Till_Delivery_Ends"), 532f, null, string.Empty, JCOGJEEFLBC: true);
			return true;
		}
		return false;
	}

	public IEnumerator GBHHELBPCKA()
	{
		CHEINCNDKIG cHEINCNDKIG = new CHEINCNDKIG();
		cHEINCNDKIG.BJGCPDNMHDH = this;
		return cHEINCNDKIG;
	}

	public void GPHLCKOOJEG()
	{
		UnityEngine.Debug.Log("ID_NUMMEMBERS");
		PhotonNetwork.Disconnect();
		InvokeAfterRealTime(delegate
		{
			Component component = mainController;
			component.SendMessage("OnConnectionFail", DisconnectCause.DisconnectByClientTimeout, SendMessageOptions.DontRequireReceiver);
		}, 743f);
	}

	public void NCAMALKMNPM()
	{
		mainController = NOPKOCCCFIM;
		UnityEngine.Debug.Log("ID_WARNING_NOTENOUGHTICKETSARENA");
	}

	[SpecialName]
	public bool KFMOODIAKJI()
	{
		return SavingLastSelected.instance.firstTutorialGameEnded;
	}

	public void SwitchToTutorial()
	{
		mainController = CBAPHFGNLLH;
	}

	[DebuggerHidden]
	public IEnumerator WaitForServerResponse()
	{
		APOEGAMPAFA aPOEGAMPAFA = new APOEGAMPAFA();
		aPOEGAMPAFA.BJGCPDNMHDH = this;
		return aPOEGAMPAFA;
	}

	private IEnumerator BJCPBHKLMCH(string KMJGIGDJKMH)
	{
		MMNJPPHAAGL mMNJPPHAAGL = new MMNJPPHAAGL();
		mMNJPPHAAGL.KMJGIGDJKMH = KMJGIGDJKMH;
		mMNJPPHAAGL.BJGCPDNMHDH = this;
		return mMNJPPHAAGL;
	}

	public void OJPPEBCAMOJ()
	{
		mainController.StopGame(KANLHOCIMID: false);
		mainController.Forfeit();
		JCMCCAHEBDE = true;
	}

	public void LHKGMPLBKNC()
	{
		mainController = MBPKLMKBJAB;
		GMNKFFNFEHG.isInMatch = false;
	}

	[SpecialName]
	public IJEAJGCCHEF AMHOIGBECKJ()
	{
		return _003CECLGOPKEKBK_003Ek__BackingField;
	}

	public void TryStopLoading()
	{
		if (gameState <= AEMPHGEIJNH.WaitingForResponse)
		{
			gameState = AEMPHGEIJNH.Menu;
			StopAllCoroutines();
		}
		else
		{
			UnityEngine.Debug.LogError("Stop Loading called when Game is loading or running");
		}
	}

	[SpecialName]
	public bool OJHIKLMNHNE()
	{
		return object.Equals(mainController, CBAPHFGNLLH) && TutorialManagerStage1.instance.isTutorialRunning;
	}

	[SpecialName]
	public bool FJOGEJNMNHI()
	{
		return !isBattle || GMNKFFNFEHG.isRandomMatchMaking;
	}

	[SpecialName]
	public bool IMEJOPKIKOD()
	{
		return object.Equals(mainController, FJODNDELMBL);
	}

	[SpecialName]
	public void PLBGGPKGHKN(IGameController IDEBKDPMPGM)
	{
		FAKMIGKOEFD(FJODNDELMBL, IDEBKDPMPGM);
		FAKMIGKOEFD(GEBDKFCNCAC, IDEBKDPMPGM);
		FAKMIGKOEFD(GMNKFFNFEHG, IDEBKDPMPGM);
		FAKMIGKOEFD(NOPKOCCCFIM, IDEBKDPMPGM);
		FAKMIGKOEFD(CBAPHFGNLLH, IDEBKDPMPGM);
		FAKMIGKOEFD(MBPKLMKBJAB, IDEBKDPMPGM);
		DHBCAGBEIHJ = IDEBKDPMPGM;
	}

	[SpecialName]
	public bool DAIEAMEFGIE()
	{
		return object.Equals(mainController, CBAPHFGNLLH);
	}

	public void InteruptStartingTutorial()
	{
		PBJPODPEHCB = false;
	}

	public bool SetChallenge(HHFHFANGCEJ PNAKMCNGGHE)
	{
		NGDKKFFCGCI = (ICFCHEHNHEN)PNAKMCNGGHE;
		if (NGDKKFFCGCI.CBIOKPKJNPC != Singleton<CurrentBundleVersion>.instance.photonVersion)
		{
			WarningDialog.ShowError(Localization.LocalizeFormat("ID_WARNING_BADVERSIONERROR_TEXT", NGDKKFFCGCI.CBIOKPKJNPC, Singleton<CurrentBundleVersion>.instance.photonVersion), Localization.Localize("ID_WARNING_BADVERSIONERROR"), 0f, null, string.Empty);
			return false;
		}
		return true;
	}

	[SpecialName]
	public void NOLNFONBIOO(JGAGFCMIHHJ IDEBKDPMPGM)
	{
		JGAGFCMIHHJ jGAGFCMIHHJ = OGFHPHILDKC;
		JGAGFCMIHHJ jGAGFCMIHHJ2;
		do
		{
			jGAGFCMIHHJ2 = jGAGFCMIHHJ;
			jGAGFCMIHHJ = Interlocked.CompareExchange(ref OGFHPHILDKC, (JGAGFCMIHHJ)Delegate.Remove(jGAGFCMIHHJ2, IDEBKDPMPGM), jGAGFCMIHHJ);
		}
		while ((object)jGAGFCMIHHJ != jGAGFCMIHHJ2);
	}

	public void SwitchToDeathMatch()
	{
		mainController = GMNKFFNFEHG;
		GMNKFFNFEHG.isInMatch = false;
	}

	private void OJIENOPOBLO(bool KANLHOCIMID, bool HNCPBGJJEPO = false)
	{
		StartCoroutine(RadicalRoutine.Run(KLHDGAFHIKI(KANLHOCIMID, HNCPBGJJEPO)));
	}

	[SpecialName]
	public bool ALPNOKNLMEG()
	{
		return object.Equals(mainController, FJODNDELMBL);
	}

	[SpecialName]
	public void KLPDOJMAFOO(Action IDEBKDPMPGM)
	{
		Action action = JOCAMIMDBLB;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref JOCAMIMDBLB, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void KGGGGIDHDDA(string DAIFMFEBDMB = "")
	{
		if (!string.IsNullOrEmpty(DAIFMFEBDMB))
		{
			battleId = DAIFMFEBDMB;
		}
		SwitchToTutorial();
		string fBEAOHMDKDJ = GameControllerTutorial.DGGGINEECHH();
		NMHKLCLAFGN(fBEAOHMDKDJ);
	}

	public void PGCANLPKKOL()
	{
		PBJPODPEHCB = false;
	}

	public void Quit()
	{
		if (isInMenuOrWait)
		{
			if (mainController != null)
			{
				UnityEngine.Debug.Log("Quit called for game controller.");
				mainController.Quit();
				LoadingDialog.SetLook(EDHDMJLHLFA: false);
			}
		}
		else
		{
			UnityEngine.Debug.LogError("Quit called when Game is loading or running");
		}
	}

	public void TestDisconnect()
	{
		UnityEngine.Debug.Log("Test disconnect");
		PhotonNetwork.Disconnect();
		InvokeAfterRealTime(delegate
		{
			Component component = mainController;
			component.SendMessage("OnConnectionFail", DisconnectCause.DisconnectByClientTimeout, SendMessageOptions.DontRequireReceiver);
		}, 2f);
	}

	protected override void Awake()
	{
		ALJKAAMHHLB.POPONJAMPDF("GameController.Awake START");
		base.Awake();
		Application.targetFrameRate = 60;
		gameState = AEMPHGEIJNH.Menu;
		Time.timeScale = 1f;
		PhotonNetwork.offlineMode = true;
		Singleton<BeanstalkServerManager>.instance.MatchMakingGameCreated += KBAJKDEIDDL;
		TimeManager.instance.GamePaused += OnGamePaused;
		TimeManager.instance.GameResumed += OnGameResumed;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
		PlayerController.OGMBJPKOPCB = FHABFFKPODN;
		ALJKAAMHHLB.POPONJAMPDF("GameController.Awake DONE");
	}

	protected virtual void NBDOFMHBKFG()
	{
		base.Start();
		ALJKAAMHHLB.HNMONAFFBLE("IsVip");
		FMLAOABILMN();
		ALJKAAMHHLB.MFOOEEHKEHE("WarFriends");
		SwitchToSinglePlayer();
		ALJKAAMHHLB.EGLIMGAEPGI("ID_BLACKMARKETLEFTTEXT3");
	}

	[SpecialName]
	private void DIKIPEDCHCF(AEMPHGEIJNH IDEBKDPMPGM)
	{
		_003CLFKKFABIGGM_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void StopAllTutorials()
	{
		TutorialManagerStage1.instance.FinishTutorial();
		TutorialManagerStage2.instance.FinishTutorial();
		TutorialManagerStage3.instance.FinishTutorial();
	}

	[SpecialName]
	public AEMPHGEIJNH NOPCKHHDOMN()
	{
		return _003CLFKKFABIGGM_003Ek__BackingField;
	}

	public void SwitchToWarArena()
	{
		mainController = MBPKLMKBJAB;
		GMNKFFNFEHG.isInMatch = false;
	}

	private void AKDMOOGBMBC()
	{
		try
		{
			LoadingDialog.ShowLoading(string.Empty, DMDICGADGCG: false, BGOHKCCLDJP: false, KKLNBPJCLHC: true);
			GameLoginManager.instance.RegisterOrLogin();
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.LogError("Caught Exception at startup " + ex.Message);
			UnityEngine.Debug.LogError("Stacktrace " + ex.StackTrace);
			DialogManager.instance.HideAllDialogs();
			WarningDialog.ShowError(Localization.LocalizeFormat("ID_CONFIRM_STARTUPERROR_TEXT", ex.Message), Localization.Localize("ID_CONFIRM_STARTUPERROR"), 0f, delegate
			{
				UnityEngine.Debug.Log("RETRY");
				AKDMOOGBMBC();
			}, string.Empty);
		}
	}

	public void FinishGame()
	{
		UnityEngine.Debug.Log("Finish Game");
		SoundsManager.Instance.PlaySound((!wonLastGame) ? ALPBOGHGLGK : JIMEEFOHFCC);
		HCIECMLDPFB = false;
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<GameOverScreen>.instance);
		StartCoroutine(RadicalRoutine.Run(NPOCKLJOIDP()));
		if (HKCMKDFCNBP != null)
		{
			Delegate[] invocationList = HKCMKDFCNBP.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				try
				{
					Delegate obj = invocationList[i];
					obj.Method.Invoke(obj.Target, new object[1] { MNMLNIMFMJP });
				}
				catch (Exception exception)
				{
					AnalyticsHelper.LogHandledException(exception);
				}
			}
		}
		BattleAnalyticsManager.instance.FinishGame();
		Singleton<BeanstalkServerManager>.instance.GameEnded(MNMLNIMFMJP);
	}

	public void ChangeAccountDuringTutorial()
	{
		mainController.StopGame(KANLHOCIMID: false);
		mainController.Forfeit();
		JCMCCAHEBDE = true;
	}

	public void InstanceOnAfterPlayerDataLoaded()
	{
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded -= InstanceOnAfterPlayerDataLoaded;
		if (gameState == AEMPHGEIJNH.Menu)
		{
			if (PBJPODPEHCB)
			{
				DialogManager.instance.HideAllDialogs();
				Singleton<GameController>.instance.ContinueTutorialImmediately();
				PBJPODPEHCB = false;
			}
			else if (!Singleton<GameController>.instance.isTutorial)
			{
				ObjectPoolDatabase.InstantiatePooledObjects(NPNOIGHIALL.Menu);
				if (!GuiElementSingle<Background>.instance.isShowed)
				{
					Singleton<GuiManager>.instance.FadeIn(GuiElementSingle<Background>.instance);
				}
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<MainScreen>.instance);
				Singleton<GameCamera>.instance.Disable();
			}
		}
		UnityEngine.Debug.Log("acountDataDownloadingInProgress = False");
		GameLoginManager.instance.acountDataDownloadingInProgress = false;
	}

	public void HGBNEFDBFDC()
	{
		if (isInMenuOrWait)
		{
			if (mainController != null)
			{
				UnityEngine.Debug.Log("GameController.Awake START");
				mainController.Quit();
				LoadingDialog.FEHDJPIKOJD(EDHDMJLHLFA: false);
			}
		}
		else
		{
			UnityEngine.Debug.LogError("GoldExpCoefficient");
		}
	}

	public void EDGDLNNIPCG()
	{
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded -= EDGDLNNIPCG;
		if (AFDJHMHONOH() == AEMPHGEIJNH.Menu)
		{
			if (PBJPODPEHCB)
			{
				DialogManager.instance.HideAllDialogs();
				Singleton<GameController>.instance.ContinueTutorialImmediately();
				PBJPODPEHCB = true;
			}
			else if (!Singleton<GameController>.instance.isTutorial)
			{
				ObjectPoolDatabase.OJOAADFNHFN((NPNOIGHIALL)4);
				if (!GuiElementSingle<Background>.instance.NPFFMLLLDAF())
				{
					Singleton<GuiManager>.instance.POHMFFFEIED(GuiElementSingle<Background>.instance);
				}
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<MainScreen>.instance);
				Singleton<GameCamera>.instance.Disable();
			}
		}
		UnityEngine.Debug.Log("FR");
		GameLoginManager.instance.acountDataDownloadingInProgress = false;
	}

	[DebuggerHidden]
	public IEnumerator RestartTutorial()
	{
		CHEINCNDKIG cHEINCNDKIG = new CHEINCNDKIG();
		cHEINCNDKIG.BJGCPDNMHDH = this;
		return cHEINCNDKIG;
	}

	private void KBAJKDEIDDL(bool NCMHGPNPEJM)
	{
		UnityEngine.Debug.Log("Game created on server+" + NCMHGPNPEJM);
		GJFHKPIHDCH = NCMHGPNPEJM;
	}

	protected void OnApplicationResumed()
	{
		UnityEngine.Debug.Log("GameController: Application resumed");
		mainController.UnPauseGame();
	}

	public void StopGame(bool KANLHOCIMID)
	{
		MKEGPEBGOGM(KANLHOCIMID);
		MNMLNIMFMJP = HKGHCIEPGEL.Forfeit;
		if (HKCMKDFCNBP != null)
		{
			HKCMKDFCNBP(MNMLNIMFMJP);
		}
		Singleton<BeanstalkServerManager>.instance.GameEnded(MNMLNIMFMJP);
	}

	[SpecialName]
	public bool MNPNHJKBNCJ()
	{
		return object.Equals(mainController, GEBDKFCNCAC);
	}

	public void ContinueTutorialImmediately()
	{
		Singleton<GameController>.instance.ACHLLDKBHMO(string.Empty);
		Singleton<BeanstalkServerManager>.instance.RestartTutorial();
	}

	public void OnGamePaused(TimeManager.HICMJEBLEDA HBDEGMCLFDD)
	{
		if (mainController.canShowPause && gameIsRunning)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<PauseScreen>.instance);
		}
	}

	public void SwitchToDeatchMatchOffline()
	{
		mainController = NOPKOCCCFIM;
		UnityEngine.Debug.Log("#VAVRO# switch to DM OFFLINE");
	}

	protected override void Start()
	{
		base.Start();
		ALJKAAMHHLB.POPONJAMPDF("GameController.Start START");
		AKDMOOGBMBC();
		ALJKAAMHHLB.POPONJAMPDF("GameController.Start RunApplication");
		SwitchToSinglePlayer();
		ALJKAAMHHLB.POPONJAMPDF("GameController.Start DONE");
	}

	[DebuggerHidden]
	private IEnumerator MDACPGHOIIN(string KMJGIGDJKMH)
	{
		MMNJPPHAAGL mMNJPPHAAGL = new MMNJPPHAAGL();
		mMNJPPHAAGL.KMJGIGDJKMH = KMJGIGDJKMH;
		mMNJPPHAAGL.BJGCPDNMHDH = this;
		return mMNJPPHAAGL;
	}

	[DebuggerHidden]
	private IEnumerator NPOCKLJOIDP()
	{
		KCPGHGNIGFP kCPGHGNIGFP = new KCPGHGNIGFP();
		kCPGHGNIGFP.BJGCPDNMHDH = this;
		return kCPGHGNIGFP;
	}

	public void PBKBNHIAMBG(TimeManager.HICMJEBLEDA HBDEGMCLFDD)
	{
		if (mainController.canShowPause && KKHKIEFMENC())
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<PauseScreen>.instance, 1002f);
		}
	}

	public void HHFPFOKGMGJ(TimeManager.HICMJEBLEDA HBDEGMCLFDD)
	{
		GuiElementSingle<PauseScreen>.instance.HideDialog();
	}

	protected virtual void OBBHECACANB()
	{
		base.Start();
		ALJKAAMHHLB.KKCHEDILEGL("PlayerName");
		FMLAOABILMN();
		ALJKAAMHHLB.KFOFCJNFHOL("#PETER# Tutorial Dialog - showing and mHideDialog is set to false");
		SwitchToSinglePlayer();
		ALJKAAMHHLB.DHPGNLOHBLC("shield_hide");
	}

	public void StartHostMultiplayer()
	{
		GOEOJDFMNPF = true;
		Singleton<MapManager>.instance.SelectCurrentMap(NGDKKFFCGCI.FBEAOHMDKDJ);
		if (NGDKKFFCGCI.EMLLELGLJNO == ELDLECMNIME.DeathMatch)
		{
			UnityEngine.Debug.Log("SWITCH TO DEATCHMATCH");
			SwitchToDeathMatch();
		}
		if (NGDKKFFCGCI.EMLLELGLJNO == ELDLECMNIME.Coop)
		{
			UnityEngine.Debug.Log("SWITCH TO Coop");
			SwitchToCoop();
		}
		if (isDeathMatch)
		{
			GMNKFFNFEHG.StartMultiplayerGame(NGDKKFFCGCI.JLBLNDGIINB, NGDKKFFCGCI.GJBFKKOAMPA);
			GuiScreenSingle<CardSelectionScreen>.instance.ShowLobby();
		}
		if (isCoop)
		{
			GEBDKFCNCAC.StartMultiplayerGame(NGDKKFFCGCI.JLBLNDGIINB, NGDKKFFCGCI.GJBFKKOAMPA);
		}
	}

	public void SwitchToCoop()
	{
		mainController = GEBDKFCNCAC;
		GEBDKFCNCAC.isInMatch = false;
	}

	[SpecialName]
	public bool JLIBMLEFJFE()
	{
		return !PBJPODPEHCB && BAKCODKBCPJ();
	}

	public void SwitchToSinglePlayer()
	{
		mainController = FJODNDELMBL;
	}

	[DebuggerHidden]
	private IEnumerator KLHDGAFHIKI(bool KANLHOCIMID, bool HNCPBGJJEPO)
	{
		KGCALFKEMNC kGCALFKEMNC = new KGCALFKEMNC();
		kGCALFKEMNC.HNCPBGJJEPO = HNCPBGJJEPO;
		kGCALFKEMNC.KANLHOCIMID = KANLHOCIMID;
		kGCALFKEMNC.BJGCPDNMHDH = this;
		return kGCALFKEMNC;
	}

	public void NOKJMDOPFHL()
	{
		if (gameState <= AEMPHGEIJNH.WaitingForResponse)
		{
			DIKIPEDCHCF(AEMPHGEIJNH.WaitingForResponse);
			StopAllCoroutines();
		}
		else
		{
			UnityEngine.Debug.LogError(" <=");
		}
	}

	private void FMLAOABILMN()
	{
		try
		{
			LoadingDialog.ShowLoading(string.Empty, DMDICGADGCG: false, BGOHKCCLDJP: true, KKLNBPJCLHC: true);
			GameLoginManager.instance.RegisterOrLogin(SessionManager.MFGMKAJDCAI.None);
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.LogError("{0} {1}" + ex.Message);
			UnityEngine.Debug.LogError("/" + ex.StackTrace);
			DialogManager.instance.HideAllDialogs();
			object[] array = new object[0];
			array[0] = ex.Message;
			WarningDialog.ShowError(Localization.LocalizeFormat("Status", array), Localization.Localize("Squad message = "), 1946f, delegate
			{
				UnityEngine.Debug.Log("RETRY");
				AKDMOOGBMBC();
			}, string.Empty, JCOGJEEFLBC: true);
		}
	}

	private void PMMMGCGNEBM(DatabaseAction IFGAGNBDKBE)
	{
		ALJKAAMHHLB.POPONJAMPDF("GameController.OnDataLoaded " + IFGAGNBDKBE);
		if (IFGAGNBDKBE == DatabaseAction.CreateGcAccount || IFGAGNBDKBE == DatabaseAction.AddDebugGoodies || IFGAGNBDKBE == DatabaseAction.GetPlayerData || IFGAGNBDKBE == DatabaseAction.CreateAccount || IFGAGNBDKBE == DatabaseAction.MaxAll)
		{
			if (IFGAGNBDKBE == DatabaseAction.CreateGcAccount || IFGAGNBDKBE == DatabaseAction.CreateAccount || IFGAGNBDKBE == DatabaseAction.GetPlayerData)
			{
				Singleton<MessageManager>.instance.StopMessageCoroutine();
			}
			UnityEngine.Debug.Log("SETTING AFTER PLAYER DATA LOADED -> WAITING FOR " + IFGAGNBDKBE);
			Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += InstanceOnAfterPlayerDataLoaded;
		}
		ALJKAAMHHLB.POPONJAMPDF(string.Concat("GameController.OnDataLoaded ", IFGAGNBDKBE, " finished"));
	}

	public void PHKIFEIIDPJ()
	{
		UnityEngine.Debug.Log(" set loading for league ");
		PBJPODPEHCB = true;
	}

	[CompilerGenerated]
	private void INPFCDMLEHE()
	{
		Component component = mainController;
		component.SendMessage("OnConnectionFail", DisconnectCause.DisconnectByClientTimeout, SendMessageOptions.DontRequireReceiver);
	}

	private void FAKMIGKOEFD(Component IFHEILJCIKK, IGameController PHHJDIGEOPJ)
	{
		IFHEILJCIKK.gameObject.SetActive(object.Equals(IFHEILJCIKK, PHHJDIGEOPJ));
	}

	[SpecialName]
	public AEMPHGEIJNH PEGCHNGBOAM()
	{
		return _003CLFKKFABIGGM_003Ek__BackingField;
	}

	public void NMHKLCLAFGN(string FBEAOHMDKDJ = "ModernTown")
	{
		GJFHKPIHDCH = null;
		ALJKAAMHHLB.PIEBOOFPHPC("C2" + FBEAOHMDKDJ + "Reward");
		mainController.LoadingStarted();
		ALJKAAMHHLB.PJIMOPNDNKO("ID_SKILLSHOTHINT_COVERED");
		StartCoroutine(BJCPBHKLMCH(FBEAOHMDKDJ));
		ALJKAAMHHLB.ACPILMDBDKH("NO");
	}
}
