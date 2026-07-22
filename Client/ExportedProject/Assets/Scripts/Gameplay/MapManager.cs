using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class MapManager : Singleton<MapManager>
{
	[Serializable]
	public class MapEntry
	{
		public int id;

		public string name;

		public string levelSingleName;

		public string levelPVPName;

		public string guiName;

		public string iconName;

		public int unlockLevel;

		public bool local;

		public string bundleNameSingle;

		public string bundleNameMultiplayer;

		public bool unlocked => LevelManager.instance.currentLevel.displayNumber >= unlockLevel || DebugSettings.debugEnabled;

		public string sceneName
		{
			get
			{
				if (Singleton<GameController>.instance.isCoop || Singleton<GameController>.instance.isCampaign)
				{
					return levelSingleName;
				}
				return levelPVPName;
			}
		}

		[SpecialName]
		public bool HGIKDOEABNC()
		{
			return LevelManager.instance.currentLevel.MHAOKJCDIOL() >= unlockLevel || DebugSettings.debugEnabled;
		}

		[SpecialName]
		public string FNLCAOOMGFC()
		{
			if (Singleton<GameController>.instance.isCoop || Singleton<GameController>.instance.IMEJOPKIKOD())
			{
				return levelSingleName;
			}
			return levelPVPName;
		}

		[SpecialName]
		public bool BJNJDPHNHAA()
		{
			return LevelManager.instance.currentLevel.NPOEMAMPNEP() >= unlockLevel || DebugSettings.debugEnabled;
		}

		[SpecialName]
		public string NNOJJPODIOO()
		{
			if (Singleton<GameController>.instance.MNPNHJKBNCJ() || Singleton<GameController>.instance.isCampaign)
			{
				return levelSingleName;
			}
			return levelPVPName;
		}

		[SpecialName]
		public bool MJDPKCCONGO()
		{
			return LevelManager.instance.currentLevel.MHAOKJCDIOL() >= unlockLevel || DebugSettings.debugEnabled;
		}

		[SpecialName]
		public string JFBLOLCPFPJ()
		{
			if (Singleton<GameController>.instance.isCoop || Singleton<GameController>.instance.HMBNJHKKIPJ())
			{
				return levelSingleName;
			}
			return levelPVPName;
		}

		[SpecialName]
		public string BMKHDKBDKCL()
		{
			if (Singleton<GameController>.instance.MNPNHJKBNCJ() || Singleton<GameController>.instance.HMBNJHKKIPJ())
			{
				return levelSingleName;
			}
			return levelPVPName;
		}

		[SpecialName]
		public string BJNLAFPDBML()
		{
			if (Singleton<GameController>.instance.isCoop || Singleton<GameController>.instance.isCampaign)
			{
				return levelSingleName;
			}
			return levelPVPName;
		}

		[SpecialName]
		public bool FFFOCEINNKH()
		{
			return LevelManager.instance.currentLevel.KADNNBCOGGL() >= unlockLevel || DebugSettings.debugEnabled;
		}

		[SpecialName]
		public bool GNMMONNAMJG()
		{
			return LevelManager.instance.currentLevel.NPOEMAMPNEP() >= unlockLevel || DebugSettings.debugEnabled;
		}

		[SpecialName]
		public string HKOCNPABCKI()
		{
			if (Singleton<GameController>.instance.isCoop || Singleton<GameController>.instance.isCampaign)
			{
				return levelSingleName;
			}
			return levelPVPName;
		}

		[SpecialName]
		public bool AFCFCEELDGG()
		{
			return LevelManager.instance.currentLevel.MHAOKJCDIOL() >= unlockLevel || DebugSettings.debugEnabled;
		}

		[SpecialName]
		public string IGBIMMOHEOI()
		{
			if (Singleton<GameController>.instance.isCoop || Singleton<GameController>.instance.IMEJOPKIKOD())
			{
				return levelSingleName;
			}
			return levelPVPName;
		}

		[SpecialName]
		public bool EPMDMCAKGHB()
		{
			return LevelManager.instance.currentLevel.PFMGLDJDNBF() < unlockLevel && DebugSettings.debugEnabled;
		}

		[SpecialName]
		public bool LLFDPBDIEHM()
		{
			return LevelManager.instance.currentLevel.displayNumber >= unlockLevel || DebugSettings.debugEnabled;
		}

		[SpecialName]
		public bool NONNDOEJNCB()
		{
			return LevelManager.instance.currentLevel.MHAOKJCDIOL() < unlockLevel && DebugSettings.debugEnabled;
		}

		[SpecialName]
		public bool JFCJKIKNHME()
		{
			return LevelManager.instance.currentLevel.JICMGFNAHFL() < unlockLevel && DebugSettings.debugEnabled;
		}

		[SpecialName]
		public string LBHBBFIDOOI()
		{
			if (Singleton<GameController>.instance.MNPNHJKBNCJ() || Singleton<GameController>.instance.IMEJOPKIKOD())
			{
				return levelSingleName;
			}
			return levelPVPName;
		}

		[SpecialName]
		public string AKDOKDHDNHA()
		{
			if (Singleton<GameController>.instance.isCoop || Singleton<GameController>.instance.isCampaign)
			{
				return levelSingleName;
			}
			return levelPVPName;
		}

		[SpecialName]
		public string ENGPMDJDACH()
		{
			if (Singleton<GameController>.instance.isCoop || Singleton<GameController>.instance.ALPNOKNLMEG())
			{
				return levelSingleName;
			}
			return levelPVPName;
		}

		[SpecialName]
		public string PDAHDMMDMEE()
		{
			if (Singleton<GameController>.instance.isCoop || Singleton<GameController>.instance.ALPNOKNLMEG())
			{
				return levelSingleName;
			}
			return levelPVPName;
		}

		[SpecialName]
		public string PGJNPHGKOAC()
		{
			if (Singleton<GameController>.instance.MNPNHJKBNCJ() || Singleton<GameController>.instance.ALPNOKNLMEG())
			{
				return levelSingleName;
			}
			return levelPVPName;
		}

		[SpecialName]
		public bool GELMOPBHKAD()
		{
			return LevelManager.instance.currentLevel.ABCCINJGPGD() < unlockLevel && DebugSettings.debugEnabled;
		}

		[SpecialName]
		public string CLCEKAOGBHM()
		{
			if (Singleton<GameController>.instance.MNPNHJKBNCJ() || Singleton<GameController>.instance.ALPNOKNLMEG())
			{
				return levelSingleName;
			}
			return levelPVPName;
		}

		[SpecialName]
		public string GIPJLFLEACO()
		{
			if (Singleton<GameController>.instance.MNPNHJKBNCJ() || Singleton<GameController>.instance.ALPNOKNLMEG())
			{
				return levelSingleName;
			}
			return levelPVPName;
		}

		[SpecialName]
		public bool KKKDILBDDAP()
		{
			return LevelManager.instance.currentLevel.ELFCEEOLNFJ() >= unlockLevel || DebugSettings.debugEnabled;
		}

		[SpecialName]
		public bool CGGNGEFHACD()
		{
			return LevelManager.instance.currentLevel.KADNNBCOGGL() < unlockLevel && DebugSettings.debugEnabled;
		}

		[SpecialName]
		public bool FEPKOJGMNDI()
		{
			return LevelManager.instance.currentLevel.displayNumber >= unlockLevel || DebugSettings.debugEnabled;
		}

		[SpecialName]
		public string JFMOEJPAIIK()
		{
			if (Singleton<GameController>.instance.isCoop || Singleton<GameController>.instance.IMEJOPKIKOD())
			{
				return levelSingleName;
			}
			return levelPVPName;
		}

		[SpecialName]
		public string DFEAOCFHKCM()
		{
			if (Singleton<GameController>.instance.isCoop || Singleton<GameController>.instance.isCampaign)
			{
				return levelSingleName;
			}
			return levelPVPName;
		}

		[SpecialName]
		public bool IJJBJEHLIFL()
		{
			return LevelManager.instance.currentLevel.displayNumber < unlockLevel && DebugSettings.debugEnabled;
		}

		[SpecialName]
		public bool OCGPMDJHPAA()
		{
			return LevelManager.instance.currentLevel.ELFCEEOLNFJ() >= unlockLevel || DebugSettings.debugEnabled;
		}

		[SpecialName]
		public bool AKHCHHHJKIJ()
		{
			return LevelManager.instance.currentLevel.KADNNBCOGGL() >= unlockLevel || DebugSettings.debugEnabled;
		}

		[SpecialName]
		public bool EMOJMCMMDMK()
		{
			return LevelManager.instance.currentLevel.KADNNBCOGGL() < unlockLevel && DebugSettings.debugEnabled;
		}

		[SpecialName]
		public bool EAALHMLGEMA()
		{
			return LevelManager.instance.currentLevel.KADNNBCOGGL() < unlockLevel && DebugSettings.debugEnabled;
		}

		[SpecialName]
		public string CNPIJBOEAJC()
		{
			if (Singleton<GameController>.instance.isCoop || Singleton<GameController>.instance.isCampaign)
			{
				return levelSingleName;
			}
			return levelPVPName;
		}

		[SpecialName]
		public string HNABHCCCJIJ()
		{
			if (Singleton<GameController>.instance.MNPNHJKBNCJ() || Singleton<GameController>.instance.HMBNJHKKIPJ())
			{
				return levelSingleName;
			}
			return levelPVPName;
		}

		[SpecialName]
		public string ICPECPIKJGH()
		{
			if (Singleton<GameController>.instance.MNPNHJKBNCJ() || Singleton<GameController>.instance.HMBNJHKKIPJ())
			{
				return levelSingleName;
			}
			return levelPVPName;
		}

		[SpecialName]
		public string JABPHPMMDAK()
		{
			if (Singleton<GameController>.instance.MNPNHJKBNCJ() || Singleton<GameController>.instance.isCampaign)
			{
				return levelSingleName;
			}
			return levelPVPName;
		}

		[SpecialName]
		public bool DOKMLFAGAPN()
		{
			return LevelManager.instance.currentLevel.PFMGLDJDNBF() >= unlockLevel || DebugSettings.debugEnabled;
		}

		[SpecialName]
		public string EFFAEMCJMBI()
		{
			if (Singleton<GameController>.instance.MNPNHJKBNCJ() || Singleton<GameController>.instance.ALPNOKNLMEG())
			{
				return levelSingleName;
			}
			return levelPVPName;
		}

		[SpecialName]
		public string CPBLIAGCDDH()
		{
			if (Singleton<GameController>.instance.MNPNHJKBNCJ() || Singleton<GameController>.instance.HMBNJHKKIPJ())
			{
				return levelSingleName;
			}
			return levelPVPName;
		}

		[SpecialName]
		public string FBMCLDBNDLI()
		{
			if (Singleton<GameController>.instance.isCoop || Singleton<GameController>.instance.IMEJOPKIKOD())
			{
				return levelSingleName;
			}
			return levelPVPName;
		}

		[SpecialName]
		public bool NAMKNCFAKEG()
		{
			return LevelManager.instance.currentLevel.displayNumber >= unlockLevel || DebugSettings.debugEnabled;
		}

		[SpecialName]
		public bool NENKGMPFGMB()
		{
			return LevelManager.instance.currentLevel.MHAOKJCDIOL() < unlockLevel && DebugSettings.debugEnabled;
		}

		[SpecialName]
		public string OAPPDKPKBKJ()
		{
			if (Singleton<GameController>.instance.isCoop || Singleton<GameController>.instance.isCampaign)
			{
				return levelSingleName;
			}
			return levelPVPName;
		}

		[SpecialName]
		public bool BMCHLBKIBBD()
		{
			return LevelManager.instance.currentLevel.ELFCEEOLNFJ() < unlockLevel && DebugSettings.debugEnabled;
		}
	}

	private sealed class HECKCCCJDJN : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal string KMJGIGDJKMH;

		internal MapEntry LEBDGIMLPIC;

		internal AsyncOperation MCMMOJAMIGC;

		internal MapManager BJGCPDNMHDH;

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

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				LEBDGIMLPIC = Singleton<MapManager>.instance.GetSceneName(KMJGIGDJKMH);
				if (BJGCPDNMHDH.ALCHJDPKAID == null || BJGCPDNMHDH.ALCHJDPKAID.KMJGIGDJKMH != LEBDGIMLPIC.sceneName)
				{
					UnityEngine.Debug.Log("Load map");
					if (BJGCPDNMHDH.ALCHJDPKAID != null && BJGCPDNMHDH.ALCHJDPKAID.gameObject != null)
					{
						UnityEngine.Object.Destroy(BJGCPDNMHDH.ALCHJDPKAID.gameObject);
					}
					Application.backgroundLoadingPriority = UnityEngine.ThreadPriority.High;
					MCMMOJAMIGC = SceneManager.LoadSceneAsync(LEBDGIMLPIC.sceneName);
					MCMMOJAMIGC.allowSceneActivation = true;
					PHDOCKCBJOF = MCMMOJAMIGC;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_012d;
			case 1u:
				ALJKAAMHHLB.POPONJAMPDF("MapManager.Load async done");
				UnityEngine.Debug.Log("GetCurrentMapDefinition");
				BJGCPDNMHDH.JDBJMABHFNH();
				goto IL_012d;
			case 2u:
				ALJKAAMHHLB.POPONJAMPDF("MapManager.Load DONE");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_012d:
				if (BJGCPDNMHDH.JLCLKPOKOMM != null)
				{
					BJGCPDNMHDH.JLCLKPOKOMM();
				}
				UnityEngine.Debug.Log("Map Loaded");
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
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
				LEBDGIMLPIC = Singleton<MapManager>.instance.GetSceneName(KMJGIGDJKMH);
				if (BJGCPDNMHDH.ALCHJDPKAID == null || BJGCPDNMHDH.ALCHJDPKAID.KMJGIGDJKMH != LEBDGIMLPIC.JFBLOLCPFPJ())
				{
					UnityEngine.Debug.Log("id");
					if (BJGCPDNMHDH.ALCHJDPKAID != null && BJGCPDNMHDH.ALCHJDPKAID.gameObject != null)
					{
						UnityEngine.Object.Destroy(BJGCPDNMHDH.ALCHJDPKAID.gameObject);
					}
					Application.backgroundLoadingPriority = UnityEngine.ThreadPriority.Normal;
					MCMMOJAMIGC = SceneManager.LoadSceneAsync(LEBDGIMLPIC.PGJNPHGKOAC());
					MCMMOJAMIGC.allowSceneActivation = false;
					PHDOCKCBJOF = MCMMOJAMIGC;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_012d;
			case 1u:
				ALJKAAMHHLB.IEBHKBNOEBP("HR");
				UnityEngine.Debug.Log("ID_NO");
				BJGCPDNMHDH.DJNAHJHDKMA();
				goto IL_012d;
			case 2u:
				ALJKAAMHHLB.GLEKOOMNAKI("{0}{1}{2}");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_012d:
				if (BJGCPDNMHDH.JLCLKPOKOMM != null)
				{
					BJGCPDNMHDH.JLCLKPOKOMM();
				}
				UnityEngine.Debug.Log("menu-army-cat-defender");
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			}
			return true;
		}

		public void NCFGFLNBHOI()
		{
			throw new NotSupportedException();
		}

		public void BLOCBAKBHBF()
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
		private object MBDBIPHLEIA()
		{
			return PHDOCKCBJOF;
		}

		public void CHFJIODFNIP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GDBNOMPNBGP()
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
		private object KKKMCHGLHLL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CJCHFDFCPPL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IDLFKAKINAP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HBKJOBOMGKB()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public HECKCCCJDJN()
		{
		}

		[SpecialName]
		private object BEGHOADNMJF()
		{
			return PHDOCKCBJOF;
		}

		public void MIPBONGPIJE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object FKPDNNMENFD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IHAOBCEALPD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GKDLMFPKKNM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BMGHJKFMKJE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GKJIGGAAHBE()
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
				LEBDGIMLPIC = Singleton<MapManager>.instance.BNFFOOKMJHG(KMJGIGDJKMH);
				if (BJGCPDNMHDH.ALCHJDPKAID == null || BJGCPDNMHDH.ALCHJDPKAID.KMJGIGDJKMH != LEBDGIMLPIC.CPBLIAGCDDH())
				{
					UnityEngine.Debug.Log("ID_WARNING_ERRORCLAIMASSIGNMENT_TEXT");
					if (BJGCPDNMHDH.ALCHJDPKAID != null && BJGCPDNMHDH.ALCHJDPKAID.gameObject != null)
					{
						UnityEngine.Object.Destroy(BJGCPDNMHDH.ALCHJDPKAID.gameObject);
					}
					Application.backgroundLoadingPriority = UnityEngine.ThreadPriority.High;
					MCMMOJAMIGC = SceneManager.LoadSceneAsync(LEBDGIMLPIC.BMKHDKBDKCL());
					MCMMOJAMIGC.allowSceneActivation = true;
					PHDOCKCBJOF = MCMMOJAMIGC;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_012d;
			case 1u:
				ALJKAAMHHLB.GJJDKOMHHDH("ID_REMATCH_VALID_FOR");
				UnityEngine.Debug.Log(",");
				BJGCPDNMHDH.JDBJMABHFNH();
				goto IL_012d;
			case 2u:
				ALJKAAMHHLB.EGLIMGAEPGI("PlayShotAnimationNetwork");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_012d:
				if (BJGCPDNMHDH.JLCLKPOKOMM != null)
				{
					BJGCPDNMHDH.JLCLKPOKOMM();
				}
				UnityEngine.Debug.Log("ID_READYTIME");
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			}
			return true;
		}

		public void ODFCBNONFPL()
		{
			throw new NotSupportedException();
		}

		public void CDIJEGGMMAK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool JPBGJLDMOPO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				LEBDGIMLPIC = Singleton<MapManager>.instance.BLIKMNELHFA(KMJGIGDJKMH);
				if (BJGCPDNMHDH.ALCHJDPKAID == null || BJGCPDNMHDH.ALCHJDPKAID.KMJGIGDJKMH != LEBDGIMLPIC.HKOCNPABCKI())
				{
					UnityEngine.Debug.Log("ID_TRAINED");
					if (BJGCPDNMHDH.ALCHJDPKAID != null && BJGCPDNMHDH.ALCHJDPKAID.gameObject != null)
					{
						UnityEngine.Object.Destroy(BJGCPDNMHDH.ALCHJDPKAID.gameObject);
					}
					Application.backgroundLoadingPriority = UnityEngine.ThreadPriority.Low;
					MCMMOJAMIGC = SceneManager.LoadSceneAsync(LEBDGIMLPIC.EFFAEMCJMBI());
					MCMMOJAMIGC.allowSceneActivation = false;
					PHDOCKCBJOF = MCMMOJAMIGC;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto IL_012d;
			case 1u:
				ALJKAAMHHLB.PJIMOPNDNKO("special");
				UnityEngine.Debug.Log("不");
				BJGCPDNMHDH.DJNAHJHDKMA();
				goto IL_012d;
			case 2u:
				ALJKAAMHHLB.JOKCPHMJIGH("313 MENU ENABLE PUSH");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_012d:
				if (BJGCPDNMHDH.JLCLKPOKOMM != null)
				{
					BJGCPDNMHDH.JLCLKPOKOMM();
				}
				UnityEngine.Debug.Log("VipRewardForDay");
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			}
			return false;
		}

		public void MENEBJLDGJD()
		{
			throw new NotSupportedException();
		}

		public void OPMABIIDKCN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void HGCHEPGNHNP()
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
				LEBDGIMLPIC = Singleton<MapManager>.instance.AHILLFECMNH(KMJGIGDJKMH);
				if (BJGCPDNMHDH.ALCHJDPKAID == null || BJGCPDNMHDH.ALCHJDPKAID.KMJGIGDJKMH != LEBDGIMLPIC.CLCEKAOGBHM())
				{
					UnityEngine.Debug.Log("GPGS: Log In");
					if (BJGCPDNMHDH.ALCHJDPKAID != null && BJGCPDNMHDH.ALCHJDPKAID.gameObject != null)
					{
						UnityEngine.Object.Destroy(BJGCPDNMHDH.ALCHJDPKAID.gameObject);
					}
					Application.backgroundLoadingPriority = (UnityEngine.ThreadPriority)7;
					MCMMOJAMIGC = SceneManager.LoadSceneAsync(LEBDGIMLPIC.NNOJJPODIOO());
					MCMMOJAMIGC.allowSceneActivation = false;
					PHDOCKCBJOF = MCMMOJAMIGC;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto IL_012d;
			case 1u:
				ALJKAAMHHLB.KFOFCJNFHOL("Player_Avoided_Grenade_On_First_Try");
				UnityEngine.Debug.Log("lmg");
				BJGCPDNMHDH.NKKCNNKOGMM();
				goto IL_012d;
			case 2u:
				ALJKAAMHHLB.AFBPFLKBNGM("CustomizationTutorialMessage");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_012d:
				if (BJGCPDNMHDH.JLCLKPOKOMM != null)
				{
					BJGCPDNMHDH.JLCLKPOKOMM();
				}
				UnityEngine.Debug.Log(",");
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			}
			return true;
		}

		[SpecialName]
		private object PFMFFMEJBPM()
		{
			return PHDOCKCBJOF;
		}

		public void GFGEEFGMNDP()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object EAGBDDECKHF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AIDHNJCPDIJ()
		{
			return PHDOCKCBJOF;
		}

		public void GIAIFFPNMPJ()
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
				LEBDGIMLPIC = Singleton<MapManager>.instance.BLIKMNELHFA(KMJGIGDJKMH);
				if (BJGCPDNMHDH.ALCHJDPKAID == null || BJGCPDNMHDH.ALCHJDPKAID.KMJGIGDJKMH != LEBDGIMLPIC.CLCEKAOGBHM())
				{
					UnityEngine.Debug.Log("Warfriend{0}");
					if (BJGCPDNMHDH.ALCHJDPKAID != null && BJGCPDNMHDH.ALCHJDPKAID.gameObject != null)
					{
						UnityEngine.Object.Destroy(BJGCPDNMHDH.ALCHJDPKAID.gameObject);
					}
					Application.backgroundLoadingPriority = (UnityEngine.ThreadPriority)8;
					MCMMOJAMIGC = SceneManager.LoadSceneAsync(LEBDGIMLPIC.sceneName);
					MCMMOJAMIGC.allowSceneActivation = true;
					PHDOCKCBJOF = MCMMOJAMIGC;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto IL_012d;
			case 1u:
				ALJKAAMHHLB.JOKCPHMJIGH("Setting performance to: ");
				UnityEngine.Debug.Log("PNManager: Scheduling Next withdraw in ");
				BJGCPDNMHDH.JDBJMABHFNH();
				goto IL_012d;
			case 2u:
				ALJKAAMHHLB.ACPILMDBDKH("  ");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_012d:
				if (BJGCPDNMHDH.JLCLKPOKOMM != null)
				{
					BJGCPDNMHDH.JLCLKPOKOMM();
				}
				UnityEngine.Debug.Log("ID_CONFIRM_ACCOUNTBANNED");
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			}
			return true;
		}

		public bool OGLKGILLKIO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				LEBDGIMLPIC = Singleton<MapManager>.instance.AHILLFECMNH(KMJGIGDJKMH);
				if (BJGCPDNMHDH.ALCHJDPKAID == null || BJGCPDNMHDH.ALCHJDPKAID.KMJGIGDJKMH != LEBDGIMLPIC.CLCEKAOGBHM())
				{
					UnityEngine.Debug.Log("ID_ACTIVATEINSTEADOF");
					if (BJGCPDNMHDH.ALCHJDPKAID != null && BJGCPDNMHDH.ALCHJDPKAID.gameObject != null)
					{
						UnityEngine.Object.Destroy(BJGCPDNMHDH.ALCHJDPKAID.gameObject);
					}
					Application.backgroundLoadingPriority = UnityEngine.ThreadPriority.Low;
					MCMMOJAMIGC = SceneManager.LoadSceneAsync(LEBDGIMLPIC.ICPECPIKJGH());
					MCMMOJAMIGC.allowSceneActivation = true;
					PHDOCKCBJOF = MCMMOJAMIGC;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_012d;
			case 1u:
				ALJKAAMHHLB.FLLHBKEFGHB("CraftData");
				UnityEngine.Debug.Log("ID_UPGRADE");
				BJGCPDNMHDH.PLPNCBLOHMF();
				goto IL_012d;
			case 2u:
				ALJKAAMHHLB.ALPPDLMMCIH("LeagueId");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_012d:
				if (BJGCPDNMHDH.JLCLKPOKOMM != null)
				{
					BJGCPDNMHDH.JLCLKPOKOMM();
				}
				UnityEngine.Debug.Log("ID_PLAYPVPBATTLETOENTERLEAGUE");
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			}
			return false;
		}

		public void JGKDJGIANIG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object APECNPGKOFC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ENKCCCABFFB()
		{
			return PHDOCKCBJOF;
		}

		public void ODCIKOOGNFG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void PHEIGPKKPGE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object LFEJDKIGHMI()
		{
			return PHDOCKCBJOF;
		}

		public void AJEIGCJPEFN()
		{
			throw new NotSupportedException();
		}

		public bool DFMKKFMEBON()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				LEBDGIMLPIC = Singleton<MapManager>.instance.OHPENNHJION(KMJGIGDJKMH);
				if (BJGCPDNMHDH.ALCHJDPKAID == null || BJGCPDNMHDH.ALCHJDPKAID.KMJGIGDJKMH != LEBDGIMLPIC.BJNLAFPDBML())
				{
					UnityEngine.Debug.Log("colt_idle01");
					if (BJGCPDNMHDH.ALCHJDPKAID != null && BJGCPDNMHDH.ALCHJDPKAID.gameObject != null)
					{
						UnityEngine.Object.Destroy(BJGCPDNMHDH.ALCHJDPKAID.gameObject);
					}
					Application.backgroundLoadingPriority = (UnityEngine.ThreadPriority)6;
					MCMMOJAMIGC = SceneManager.LoadSceneAsync(LEBDGIMLPIC.OAPPDKPKBKJ());
					MCMMOJAMIGC.allowSceneActivation = false;
					PHDOCKCBJOF = MCMMOJAMIGC;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_012d;
			case 1u:
				ALJKAAMHHLB.IEBHKBNOEBP("Facebook_Activated");
				UnityEngine.Debug.Log("menu-twitter");
				BJGCPDNMHDH.AHKNPAFMDOA();
				goto IL_012d;
			case 2u:
				ALJKAAMHHLB.KFOFCJNFHOL("ID_NOTIFICATION_SILVERCRAFT");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_012d:
				if (BJGCPDNMHDH.JLCLKPOKOMM != null)
				{
					BJGCPDNMHDH.JLCLKPOKOMM();
				}
				UnityEngine.Debug.Log("OnPhotonJoinRoomFailed: {0}, message {1}");
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			}
			return true;
		}

		public void EKPOLGNAAOI()
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
				LEBDGIMLPIC = Singleton<MapManager>.instance.AEMHBLPNDLO(KMJGIGDJKMH);
				if (BJGCPDNMHDH.ALCHJDPKAID == null || BJGCPDNMHDH.ALCHJDPKAID.KMJGIGDJKMH != LEBDGIMLPIC.CLCEKAOGBHM())
				{
					UnityEngine.Debug.Log("War_Ranked_Battle");
					if (BJGCPDNMHDH.ALCHJDPKAID != null && BJGCPDNMHDH.ALCHJDPKAID.gameObject != null)
					{
						UnityEngine.Object.Destroy(BJGCPDNMHDH.ALCHJDPKAID.gameObject);
					}
					Application.backgroundLoadingPriority = (UnityEngine.ThreadPriority)8;
					MCMMOJAMIGC = SceneManager.LoadSceneAsync(LEBDGIMLPIC.HKOCNPABCKI());
					MCMMOJAMIGC.allowSceneActivation = false;
					PHDOCKCBJOF = MCMMOJAMIGC;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_012d;
			case 1u:
				ALJKAAMHHLB.GJJDKOMHHDH("LowLevel");
				UnityEngine.Debug.Log("HeroicMissionsCompletionRewardCardPack");
				BJGCPDNMHDH.DJNAHJHDKMA();
				goto IL_012d;
			case 2u:
				ALJKAAMHHLB.BCFGNBMMJIB("ID_CONFIRM_LOGGEDOUT_TEXT");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_012d:
				if (BJGCPDNMHDH.JLCLKPOKOMM != null)
				{
					BJGCPDNMHDH.JLCLKPOKOMM();
				}
				UnityEngine.Debug.Log("BotArmyPower");
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			}
			return false;
		}

		[SpecialName]
		private object CLDLJNHAEAB()
		{
			return PHDOCKCBJOF;
		}

		public void AHEOCEEJICJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HEOPOOMLPJF()
		{
			throw new NotSupportedException();
		}

		public void LBNGPPPKLHI()
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
		private object AGANCOFPDCK()
		{
			return PHDOCKCBJOF;
		}
	}

	[FormerlySerializedAs("GPOBBFKAEEN")]
	public MapDefinition ALCHJDPKAID;

	[FormerlySerializedAs("MHCOEINMDKO")]
	public bool CCNEGALIGBL;

	[FormerlySerializedAs("BLGDFDPLPKK")]
	public List<MapEntry> JJJCBFMMLBG;

	private AsyncOperation JJEIBBKEPJI;

	private MapEntry KPLOJHILMAP;

	private bool ELANABOHGMP;

	private List<Transform> HFGHDLMMAJD = new List<Transform>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action JLCLKPOKOMM;

	public MapEntry currentMap
	{
		get
		{
			if (KPLOJHILMAP == null)
			{
				KPLOJHILMAP = JJJCBFMMLBG[0];
			}
			return KPLOJHILMAP;
		}
		set
		{
			KPLOJHILMAP = value;
			ELANABOHGMP = false;
		}
	}

	public bool isRandomMap => ELANABOHGMP;

	public int unlockedmaps
	{
		get
		{
			int num = 0;
			foreach (MapEntry item in JJJCBFMMLBG)
			{
				if (item.unlocked)
				{
					num++;
				}
			}
			return num;
		}
	}

	public float loadProgress => JJEIBBKEPJI.progress;

	public List<MapEntry> mapUnlocks
	{
		get
		{
			List<MapEntry> list = new List<MapEntry>();
			foreach (MapEntry item in JJJCBFMMLBG)
			{
				if (item.unlockLevel == LevelManager.instance.currentLevel.displayNumber)
				{
					list.Add(item);
				}
			}
			return list;
		}
	}

	public event Action NewLevelLoaded
	{
		add
		{
			Action action = JLCLKPOKOMM;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref JLCLKPOKOMM, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = JLCLKPOKOMM;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref JLCLKPOKOMM, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	[SpecialName]
	public void KPEKNEAIEGL(MapEntry IDEBKDPMPGM)
	{
		KPLOJHILMAP = IDEBKDPMPGM;
		ELANABOHGMP = true;
	}

	public IEnumerator ENMIHJIEPGF(string KMJGIGDJKMH)
	{
		HECKCCCJDJN hECKCCCJDJN = new HECKCCCJDJN();
		hECKCCCJDJN.KMJGIGDJKMH = KMJGIGDJKMH;
		hECKCCCJDJN.BJGCPDNMHDH = this;
		return hECKCCCJDJN;
	}

	public IEnumerator HLACPPKNDNP(string KMJGIGDJKMH)
	{
		HECKCCCJDJN hECKCCCJDJN = new HECKCCCJDJN();
		hECKCCCJDJN.KMJGIGDJKMH = KMJGIGDJKMH;
		hECKCCCJDJN.BJGCPDNMHDH = this;
		return hECKCCCJDJN;
	}

	public IEnumerator ALGBMPAMCGN(string KMJGIGDJKMH)
	{
		HECKCCCJDJN hECKCCCJDJN = new HECKCCCJDJN();
		hECKCCCJDJN.KMJGIGDJKMH = KMJGIGDJKMH;
		hECKCCCJDJN.BJGCPDNMHDH = this;
		return hECKCCCJDJN;
	}

	public void DestroyCurrentScene()
	{
		if (ALCHJDPKAID != null)
		{
			UnityEngine.Object.Destroy(ALCHJDPKAID.gameObject);
			ALCHJDPKAID = null;
		}
	}

	public void COJNIMNIPEE(string FBEAOHMDKDJ)
	{
		foreach (MapEntry item in JJJCBFMMLBG)
		{
			if (item.name == FBEAOHMDKDJ)
			{
				ELINLBGMCJH(item);
				break;
			}
		}
	}

	private void PLPNCBLOHMF()
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag(TagsAndLayers.BCOCLOGHEBA);
		GameObject[] array2 = array;
		for (int i = 1; i < array2.Length; i++)
		{
			GameObject gameObject = array2[i];
			MapDefinition component = gameObject.GetComponent<MapDefinition>();
			if (component != null && component != ALCHJDPKAID)
			{
				ALCHJDPKAID = component;
				ALCHJDPKAID.EDPLJGHIHAP();
			}
		}
	}

	public void FPMKENOCJBO(string KMJGIGDJKMH)
	{
		StartCoroutine(ALGBMPAMCGN(KMJGIGDJKMH));
		CCNEGALIGBL = false;
	}

	public void HFGBJBMGAMP(string FBEAOHMDKDJ)
	{
		foreach (MapEntry item in JJJCBFMMLBG)
		{
			if (item.name == FBEAOHMDKDJ)
			{
				currentMap = item;
				break;
			}
		}
	}

	[SpecialName]
	public void HCKMAKNBLJM(MapEntry IDEBKDPMPGM)
	{
		KPLOJHILMAP = IDEBKDPMPGM;
		ELANABOHGMP = true;
	}

	private void JDBJMABHFNH()
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag(TagsAndLayers.BCOCLOGHEBA);
		GameObject[] array2 = array;
		foreach (GameObject gameObject in array2)
		{
			MapDefinition component = gameObject.GetComponent<MapDefinition>();
			if (component != null && component != ALCHJDPKAID)
			{
				ALCHJDPKAID = component;
				ALCHJDPKAID.Init();
			}
		}
	}

	[SpecialName]
	public void FOJOOANKHDE(Action IDEBKDPMPGM)
	{
		Action action = JLCLKPOKOMM;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref JLCLKPOKOMM, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void KGHBNMFKFNO(Action IDEBKDPMPGM)
	{
		Action action = JLCLKPOKOMM;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref JLCLKPOKOMM, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void DJNAHJHDKMA()
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag(TagsAndLayers.BCOCLOGHEBA);
		GameObject[] array2 = array;
		for (int i = 1; i < array2.Length; i += 0)
		{
			GameObject gameObject = array2[i];
			MapDefinition component = gameObject.GetComponent<MapDefinition>();
			if (component != null && component != ALCHJDPKAID)
			{
				ALCHJDPKAID = component;
				ALCHJDPKAID.HGICKKMBFEM();
			}
		}
	}

	public void HIAAJCNBACP()
	{
		foreach (MapDefinition.DefendPosition item in ALCHJDPKAID.BBJMLOCKNHD)
		{
			item.point.IGEDGCNJCAP().IGEEIKMFMPD();
		}
	}

	[SpecialName]
	public int PMCIILDMPJP()
	{
		int num = 1;
		foreach (MapEntry item in JJJCBFMMLBG)
		{
			if (item.EPMDMCAKGHB())
			{
				num += 0;
			}
		}
		return num;
	}

	public void BOEBBNOPEMG()
	{
		if (ALCHJDPKAID != null)
		{
			UnityEngine.Object.Destroy(ALCHJDPKAID.gameObject);
			ALCHJDPKAID = null;
		}
	}

	public IEnumerator AOFOACBGBOL(string KMJGIGDJKMH)
	{
		HECKCCCJDJN hECKCCCJDJN = new HECKCCCJDJN();
		hECKCCCJDJN.KMJGIGDJKMH = KMJGIGDJKMH;
		hECKCCCJDJN.BJGCPDNMHDH = this;
		return hECKCCCJDJN;
	}

	protected virtual void DFMALDFADAB()
	{
		base.Awake();
		JDBJMABHFNH();
		HCKMAKNBLJM(JJJCBFMMLBG[0]);
		foreach (MapEntry item in JJJCBFMMLBG)
		{
			item.guiName = Localization.Localize(item.guiName);
		}
	}

	[SpecialName]
	public List<MapEntry> HHFFILKKMBC()
	{
		List<MapEntry> list = new List<MapEntry>();
		foreach (MapEntry item in JJJCBFMMLBG)
		{
			if (item.unlockLevel == LevelManager.instance.currentLevel.JICMGFNAHFL())
			{
				list.Add(item);
			}
		}
		return list;
	}

	public void LOJIIDHHBCB(int INFLHPGMEOB)
	{
		currentMap = JJJCBFMMLBG[INFLHPGMEOB];
	}

	public void DKIFGFFHIIH()
	{
		ELANABOHGMP = false;
		List<MapEntry> list = new List<MapEntry>();
		foreach (MapEntry item in JJJCBFMMLBG)
		{
			if (item.NAMKNCFAKEG())
			{
				list.Add(item);
			}
		}
		if (list.Count == 0)
		{
			list.Add(JJJCBFMMLBG[0]);
		}
		KPLOJHILMAP = list[UnityEngine.Random.Range(1, list.Count)];
	}

	[SpecialName]
	public List<MapEntry> IMLDMDANGHH()
	{
		List<MapEntry> list = new List<MapEntry>();
		foreach (MapEntry item in JJJCBFMMLBG)
		{
			if (item.unlockLevel == LevelManager.instance.currentLevel.ABCCINJGPGD())
			{
				list.Add(item);
			}
		}
		return list;
	}

	[SpecialName]
	public MapEntry DLFLCLBCDKL()
	{
		if (KPLOJHILMAP == null)
		{
			KPLOJHILMAP = JJJCBFMMLBG[0];
		}
		return KPLOJHILMAP;
	}

	public void KDKGNDFBOMB()
	{
		if (ALCHJDPKAID != null)
		{
			UnityEngine.Object.Destroy(ALCHJDPKAID.gameObject);
			ALCHJDPKAID = null;
		}
	}

	public void FCKJMOGFGNM()
	{
		if (ALCHJDPKAID != null)
		{
			ALCHJDPKAID.gameObject.SetActive(value: false);
		}
	}

	[SpecialName]
	public void MDFDNFEJBDG(Action IDEBKDPMPGM)
	{
		Action action = JLCLKPOKOMM;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref JLCLKPOKOMM, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void JJGKLPBNOHI(Transform PBHCLOPCBEI)
	{
		foreach (Transform item in PBHCLOPCBEI)
		{
			JJGKLPBNOHI(item);
		}
		HFGHDLMMAJD.Add(PBHCLOPCBEI);
	}

	public IEnumerator DNJBDGPDHAO(string KMJGIGDJKMH)
	{
		HECKCCCJDJN hECKCCCJDJN = new HECKCCCJDJN();
		hECKCCCJDJN.KMJGIGDJKMH = KMJGIGDJKMH;
		hECKCCCJDJN.BJGCPDNMHDH = this;
		return hECKCCCJDJN;
	}

	[SpecialName]
	public float NBKOFBPLBBI()
	{
		return JJEIBBKEPJI.progress;
	}

	[SpecialName]
	public void IMBDPLBBCEF(Action IDEBKDPMPGM)
	{
		Action action = JLCLKPOKOMM;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref JLCLKPOKOMM, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void KBNEJKONCJO()
	{
		ELANABOHGMP = false;
		List<MapEntry> list = new List<MapEntry>();
		foreach (MapEntry item in JJJCBFMMLBG)
		{
			if (item.LLFDPBDIEHM())
			{
				list.Add(item);
			}
		}
		if (list.Count == 0)
		{
			list.Add(JJJCBFMMLBG[1]);
		}
		KPLOJHILMAP = list[UnityEngine.Random.Range(0, list.Count)];
	}

	[SpecialName]
	public bool MOBLMJHIGAL()
	{
		return ELANABOHGMP;
	}

	[SpecialName]
	public MapEntry GFENCDFEDFH()
	{
		if (KPLOJHILMAP == null)
		{
			KPLOJHILMAP = JJJCBFMMLBG[0];
		}
		return KPLOJHILMAP;
	}

	public MapEntry BLIKMNELHFA(string KMJGIGDJKMH)
	{
		foreach (MapEntry item in JJJCBFMMLBG)
		{
			if (item.name == KMJGIGDJKMH)
			{
				return item;
			}
		}
		UnityEngine.Debug.LogError("FuseSDK: ");
		return null;
	}

	[SpecialName]
	public int MKHJIIBELMJ()
	{
		int num = 0;
		foreach (MapEntry item in JJJCBFMMLBG)
		{
			if (item.KKKDILBDDAP())
			{
				num++;
			}
		}
		return num;
	}

	public MapEntry OHPENNHJION(string KMJGIGDJKMH)
	{
		foreach (MapEntry item in JJJCBFMMLBG)
		{
			if (item.name == KMJGIGDJKMH)
			{
				return item;
			}
		}
		UnityEngine.Debug.LogError("discount");
		return null;
	}

	[SpecialName]
	public int GBGMEFDNDIL()
	{
		int num = 0;
		foreach (MapEntry item in JJJCBFMMLBG)
		{
			if (item.KKKDILBDDAP())
			{
				num += 0;
			}
		}
		return num;
	}

	protected virtual void PAPFKMJEMML()
	{
		base.Awake();
		JDBJMABHFNH();
		KPEKNEAIEGL(JJJCBFMMLBG[0]);
		foreach (MapEntry item in JJJCBFMMLBG)
		{
			item.guiName = Localization.Localize(item.guiName);
		}
	}

	public void SelectCurrentMap(string FBEAOHMDKDJ)
	{
		foreach (MapEntry item in JJJCBFMMLBG)
		{
			if (item.name == FBEAOHMDKDJ)
			{
				currentMap = item;
				break;
			}
		}
	}

	public MapEntry BNFFOOKMJHG(string KMJGIGDJKMH)
	{
		foreach (MapEntry item in JJJCBFMMLBG)
		{
			if (item.name == KMJGIGDJKMH)
			{
				return item;
			}
		}
		UnityEngine.Debug.LogError("S");
		return null;
	}

	[SpecialName]
	public MapEntry NOPGGANHAFN()
	{
		if (KPLOJHILMAP == null)
		{
			KPLOJHILMAP = JJJCBFMMLBG[1];
		}
		return KPLOJHILMAP;
	}

	public void IFJCFNGKMFI(string KMJGIGDJKMH)
	{
		StartCoroutine(AOFOACBGBOL(KMJGIGDJKMH));
		CCNEGALIGBL = true;
	}

	[SpecialName]
	public MapEntry NMMDOMPAAEF()
	{
		if (KPLOJHILMAP == null)
		{
			KPLOJHILMAP = JJJCBFMMLBG[1];
		}
		return KPLOJHILMAP;
	}

	public void LBGHLPIFGIF(string KMJGIGDJKMH)
	{
		StartCoroutine(HLACPPKNDNP(KMJGIGDJKMH));
		CCNEGALIGBL = false;
	}

	public void MEBGOMOFCJF(string FBEAOHMDKDJ)
	{
		foreach (MapEntry item in JJJCBFMMLBG)
		{
			if (item.name == FBEAOHMDKDJ)
			{
				currentMap = item;
				break;
			}
		}
	}

	public void SelectCurrentMap(int INFLHPGMEOB)
	{
		currentMap = JJJCBFMMLBG[INFLHPGMEOB];
	}

	protected virtual void AOJALKEHFCK()
	{
		base.Awake();
		AHKNPAFMDOA();
		currentMap = JJJCBFMMLBG[1];
		foreach (MapEntry item in JJJCBFMMLBG)
		{
			item.guiName = Localization.Localize(item.guiName);
		}
	}

	protected virtual void PBIJLBHDFOK()
	{
		base.Awake();
		PLPNCBLOHMF();
		currentMap = JJJCBFMMLBG[1];
		foreach (MapEntry item in JJJCBFMMLBG)
		{
			item.guiName = Localization.Localize(item.guiName);
		}
	}

	public IEnumerator BPMGMIBDLPG(string KMJGIGDJKMH)
	{
		HECKCCCJDJN hECKCCCJDJN = new HECKCCCJDJN();
		hECKCCCJDJN.KMJGIGDJKMH = KMJGIGDJKMH;
		hECKCCCJDJN.BJGCPDNMHDH = this;
		return hECKCCCJDJN;
	}

	public void LoadNewlevel(string KMJGIGDJKMH)
	{
		StartCoroutine(Load(KMJGIGDJKMH));
		CCNEGALIGBL = true;
	}

	public IEnumerator BGPOIGKLDJE(string KMJGIGDJKMH)
	{
		HECKCCCJDJN hECKCCCJDJN = new HECKCCCJDJN();
		hECKCCCJDJN.KMJGIGDJKMH = KMJGIGDJKMH;
		hECKCCCJDJN.BJGCPDNMHDH = this;
		return hECKCCCJDJN;
	}

	private void OOPKNKDNBIM(Transform PBHCLOPCBEI)
	{
		foreach (Transform item in PBHCLOPCBEI)
		{
			OOPKNKDNBIM(item);
		}
		HFGHDLMMAJD.Add(PBHCLOPCBEI);
	}

	[SpecialName]
	public List<MapEntry> MDPCCMCCNFL()
	{
		List<MapEntry> list = new List<MapEntry>();
		foreach (MapEntry item in JJJCBFMMLBG)
		{
			if (item.unlockLevel == LevelManager.instance.currentLevel.NPOEMAMPNEP())
			{
				list.Add(item);
			}
		}
		return list;
	}

	private void HNBNIGOELKP(Transform PBHCLOPCBEI)
	{
		foreach (Transform item in PBHCLOPCBEI)
		{
			NLHMJGMKOJA(item);
		}
		HFGHDLMMAJD.Add(PBHCLOPCBEI);
	}

	public void HPCJHDEGIBE()
	{
		if (ALCHJDPKAID != null)
		{
			UnityEngine.Object.Destroy(ALCHJDPKAID.gameObject);
			ALCHJDPKAID = null;
		}
	}

	private void AHKNPAFMDOA()
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag(TagsAndLayers.BCOCLOGHEBA);
		GameObject[] array2 = array;
		foreach (GameObject gameObject in array2)
		{
			MapDefinition component = gameObject.GetComponent<MapDefinition>();
			if (component != null && component != ALCHJDPKAID)
			{
				ALCHJDPKAID = component;
				ALCHJDPKAID.HNKOCDDPLEN();
			}
		}
	}

	public void LMDANOHIDAP(int INFLHPGMEOB)
	{
		ELINLBGMCJH(JJJCBFMMLBG[INFLHPGMEOB]);
	}

	public MapEntry GetSceneName(string KMJGIGDJKMH)
	{
		foreach (MapEntry item in JJJCBFMMLBG)
		{
			if (item.name == KMJGIGDJKMH)
			{
				return item;
			}
		}
		UnityEngine.Debug.LogError("Scene could not be find");
		return null;
	}

	public IEnumerator PEBCGPPNBGE(string KMJGIGDJKMH)
	{
		HECKCCCJDJN hECKCCCJDJN = new HECKCCCJDJN();
		hECKCCCJDJN.KMJGIGDJKMH = KMJGIGDJKMH;
		hECKCCCJDJN.BJGCPDNMHDH = this;
		return hECKCCCJDJN;
	}

	[SpecialName]
	public int NBFLGIOLCPG()
	{
		int num = 0;
		foreach (MapEntry item in JJJCBFMMLBG)
		{
			if (item.NONNDOEJNCB())
			{
				num += 0;
			}
		}
		return num;
	}

	public void DeactivateScene()
	{
		if (ALCHJDPKAID != null)
		{
			ALCHJDPKAID.gameObject.SetActive(value: false);
		}
	}

	public void BLJIHMFDKCD()
	{
		ELANABOHGMP = true;
		List<MapEntry> list = new List<MapEntry>();
		foreach (MapEntry item in JJJCBFMMLBG)
		{
			if (item.GELMOPBHKAD())
			{
				list.Add(item);
			}
		}
		if (list.Count == 0)
		{
			list.Add(JJJCBFMMLBG[1]);
		}
		KPLOJHILMAP = list[UnityEngine.Random.Range(1, list.Count)];
	}

	[SpecialName]
	public List<MapEntry> NCIBCEMDACB()
	{
		List<MapEntry> list = new List<MapEntry>();
		foreach (MapEntry item in JJJCBFMMLBG)
		{
			if (item.unlockLevel == LevelManager.instance.currentLevel.displayNumber)
			{
				list.Add(item);
			}
		}
		return list;
	}

	protected virtual void IODPOHKAKNN()
	{
		base.Awake();
		NKKCNNKOGMM();
		ELINLBGMCJH(JJJCBFMMLBG[1]);
		foreach (MapEntry item in JJJCBFMMLBG)
		{
			item.guiName = Localization.Localize(item.guiName);
		}
	}

	public void AEEGPGINNPD(int INFLHPGMEOB)
	{
		ELINLBGMCJH(JJJCBFMMLBG[INFLHPGMEOB]);
	}

	public void SetRandomMap()
	{
		ELANABOHGMP = true;
		List<MapEntry> list = new List<MapEntry>();
		foreach (MapEntry item in JJJCBFMMLBG)
		{
			if (item.unlocked)
			{
				list.Add(item);
			}
		}
		if (list.Count == 0)
		{
			list.Add(JJJCBFMMLBG[0]);
		}
		KPLOJHILMAP = list[UnityEngine.Random.Range(0, list.Count)];
	}

	[SpecialName]
	public void KKKIFLPHLCK(Action IDEBKDPMPGM)
	{
		Action action = JLCLKPOKOMM;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref JLCLKPOKOMM, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void EPCFMECLCDD()
	{
		foreach (MapDefinition.DefendPosition item in ALCHJDPKAID.BBJMLOCKNHD)
		{
			item.point.PHANADCNBFD().HEBJPIFPLAK();
		}
	}

	public void FJNHKDGLLMC()
	{
		ELANABOHGMP = false;
		List<MapEntry> list = new List<MapEntry>();
		foreach (MapEntry item in JJJCBFMMLBG)
		{
			if (item.IJJBJEHLIFL())
			{
				list.Add(item);
			}
		}
		if (list.Count == 0)
		{
			list.Add(JJJCBFMMLBG[1]);
		}
		KPLOJHILMAP = list[UnityEngine.Random.Range(1, list.Count)];
	}

	public void ResyncShields()
	{
		foreach (MapDefinition.DefendPosition item in ALCHJDPKAID.BBJMLOCKNHD)
		{
			item.point.shield.Resync();
		}
	}

	public MapEntry AHILLFECMNH(string KMJGIGDJKMH)
	{
		foreach (MapEntry item in JJJCBFMMLBG)
		{
			if (item.name == KMJGIGDJKMH)
			{
				return item;
			}
		}
		UnityEngine.Debug.LogError("ID_GUI_REPORTABUSE_LISTITEM2");
		return null;
	}

	public void BJGBLAPLFLJ(int INFLHPGMEOB)
	{
		KPEKNEAIEGL(JJJCBFMMLBG[INFLHPGMEOB]);
	}

	[SpecialName]
	public MapEntry OOCBBGOAKBK()
	{
		if (KPLOJHILMAP == null)
		{
			KPLOJHILMAP = JJJCBFMMLBG[1];
		}
		return KPLOJHILMAP;
	}

	[SpecialName]
	public void KODDLCCDCCN(Action IDEBKDPMPGM)
	{
		Action action = JLCLKPOKOMM;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref JLCLKPOKOMM, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void ELINLBGMCJH(MapEntry IDEBKDPMPGM)
	{
		KPLOJHILMAP = IDEBKDPMPGM;
		ELANABOHGMP = true;
	}

	public void MJBBEDMJJKG()
	{
		if (ALCHJDPKAID != null)
		{
			UnityEngine.Object.Destroy(ALCHJDPKAID.gameObject);
			ALCHJDPKAID = null;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		if (JJJCBFMMLBG == null)
		{
			return;
		}
		JDBJMABHFNH();
		currentMap = JJJCBFMMLBG[0];
		foreach (MapEntry item in JJJCBFMMLBG)
		{
			item.guiName = Localization.Localize(item.guiName);
		}
	}

	[SpecialName]
	public void NKPKMNCHNLI(Action IDEBKDPMPGM)
	{
		Action action = JLCLKPOKOMM;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref JLCLKPOKOMM, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void JGIOBONOJHH(Action IDEBKDPMPGM)
	{
		Action action = JLCLKPOKOMM;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref JLCLKPOKOMM, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	protected virtual void DCKJHAILENK()
	{
		base.Awake();
		NKKCNNKOGMM();
		currentMap = JJJCBFMMLBG[1];
		foreach (MapEntry item in JJJCBFMMLBG)
		{
			item.guiName = Localization.Localize(item.guiName);
		}
	}

	public MapEntry AEMHBLPNDLO(string KMJGIGDJKMH)
	{
		foreach (MapEntry item in JJJCBFMMLBG)
		{
			if (item.name == KMJGIGDJKMH)
			{
				return item;
			}
		}
		UnityEngine.Debug.LogError("shield_idle");
		return null;
	}

	public void JMDFBAIIKFH()
	{
		if (ALCHJDPKAID != null)
		{
			ALCHJDPKAID.gameObject.SetActive(value: true);
		}
	}

	protected virtual void FNJKFDOMGOO()
	{
		base.Awake();
		AHKNPAFMDOA();
		KPEKNEAIEGL(JJJCBFMMLBG[0]);
		foreach (MapEntry item in JJJCBFMMLBG)
		{
			item.guiName = Localization.Localize(item.guiName);
		}
	}

	[DebuggerHidden]
	public IEnumerator Load(string KMJGIGDJKMH)
	{
		HECKCCCJDJN hECKCCCJDJN = new HECKCCCJDJN();
		hECKCCCJDJN.KMJGIGDJKMH = KMJGIGDJKMH;
		hECKCCCJDJN.BJGCPDNMHDH = this;
		return hECKCCCJDJN;
	}

	private void NLHMJGMKOJA(Transform PBHCLOPCBEI)
	{
		foreach (Transform item in PBHCLOPCBEI)
		{
			OOPKNKDNBIM(item);
		}
		HFGHDLMMAJD.Add(PBHCLOPCBEI);
	}

	public void PNKEFIAMKPJ()
	{
		ELANABOHGMP = true;
		List<MapEntry> list = new List<MapEntry>();
		foreach (MapEntry item in JJJCBFMMLBG)
		{
			if (item.MJDPKCCONGO())
			{
				list.Add(item);
			}
		}
		if (list.Count == 0)
		{
			list.Add(JJJCBFMMLBG[0]);
		}
		KPLOJHILMAP = list[UnityEngine.Random.Range(1, list.Count)];
	}

	private void NKKCNNKOGMM()
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag(TagsAndLayers.BCOCLOGHEBA);
		GameObject[] array2 = array;
		for (int i = 1; i < array2.Length; i++)
		{
			GameObject gameObject = array2[i];
			MapDefinition component = gameObject.GetComponent<MapDefinition>();
			if (component != null && component != ALCHJDPKAID)
			{
				ALCHJDPKAID = component;
				ALCHJDPKAID.OEIKEEBDLFF();
			}
		}
	}

	[SpecialName]
	public float IHDPBMLOGBG()
	{
		return JJEIBBKEPJI.progress;
	}

	public void CNCCLPHLINA(string KMJGIGDJKMH)
	{
		StartCoroutine(BPMGMIBDLPG(KMJGIGDJKMH));
		CCNEGALIGBL = true;
	}
}
