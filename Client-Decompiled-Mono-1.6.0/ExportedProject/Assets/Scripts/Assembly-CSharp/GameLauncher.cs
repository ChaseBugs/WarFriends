using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using CodeStage.AntiCheat.ObscuredTypes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLauncher : Core_BaseScript
{
	[Serializable]
	public class LogoScale
	{
		public int width;

		public int height;

		public float scale = 1f;
	}

	private sealed class JNAGDDONNMO : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal float GNIONNGOEJF;

		internal GameLauncher BJGCPDNMHDH;

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

		public bool KHNDCDGBFJH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(241f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JIIIEADHBHK());
				PHDOCKCBJOF = new WaitForSeconds(1421f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 2u:
				BJGCPDNMHDH.HKAFPCAPDIG.gameObject.SetActive(false);
				BJGCPDNMHDH.ENMLDHGLIJN.gameObject.SetActive(true);
				PHDOCKCBJOF = new WaitForSeconds(1808f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 3u:
			case 4u:
				if (!BJGCPDNMHDH.NFCFELCNIJI)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				ALJKAAMHHLB.FLMPAIEBDBB("ID_ARENAENDEDDESCRIPTION0WINS");
				GNIONNGOEJF = Time.realtimeSinceStartup + 622f;
				goto case 5u;
			case 5u:
				if (!BJGCPDNMHDH.ICPEJCOLIGF)
				{
					if (!(Time.realtimeSinceStartup > GNIONNGOEJF))
					{
						PHDOCKCBJOF = new WaitForSeconds(1837f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 3;
						}
						break;
					}
					Exception exception = new Exception("WarBucks");
					AnalyticsHelper.LogHandledException(exception);
				}
				ALJKAAMHHLB.AEHLEODHMGP("\"{0}\"\t");
				ALJKAAMHHLB.GLEKOOMNAKI("FinishChoosingCardsRPC");
				goto case 6u;
			case 6u:
				if (BJGCPDNMHDH.KEKKDELENHO == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				ALJKAAMHHLB.DHPGNLOHBLC("GameGold");
				UnityEngine.Debug.Log(" NOT OK!\t\t\t\t\t\t");
				BJGCPDNMHDH.KEKKDELENHO.allowSceneActivation = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object AHFIDCCJHKE()
		{
			return PHDOCKCBJOF;
		}

		public void NINFNJOMJOD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void DBJCDLFKDDI()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Reset()
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
				PHDOCKCBJOF = new WaitForSeconds(1f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JIIIEADHBHK());
				PHDOCKCBJOF = new WaitForSeconds(2f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
				BJGCPDNMHDH.HKAFPCAPDIG.gameObject.SetActive(false);
				BJGCPDNMHDH.ENMLDHGLIJN.gameObject.SetActive(true);
				PHDOCKCBJOF = new WaitForSeconds(1f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 3u:
			case 4u:
				if (!BJGCPDNMHDH.NFCFELCNIJI)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				ALJKAAMHHLB.DPDCBOLJKOI("GameLauncher.GooglePlayInit");
				GNIONNGOEJF = Time.realtimeSinceStartup + 5f;
				goto case 5u;
			case 5u:
				if (!BJGCPDNMHDH.ICPEJCOLIGF)
				{
					if (!(Time.realtimeSinceStartup > GNIONNGOEJF))
					{
						PHDOCKCBJOF = new WaitForSeconds(0.1f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 5;
						}
						break;
					}
					Exception exception = new Exception("Google Play Time out");
					AnalyticsHelper.LogHandledException(exception);
				}
				ALJKAAMHHLB.PDICPJLEKBI("GameLauncher.GooglePlayInit");
				ALJKAAMHHLB.POPONJAMPDF("GameLauncher.GooglePlayInit");
				goto case 6u;
			case 6u:
				if (BJGCPDNMHDH.KEKKDELENHO == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				ALJKAAMHHLB.POPONJAMPDF("GameLauncher Async done");
				UnityEngine.Debug.Log("Loading:  mAsync.allowSceneActivation = true");
				BJGCPDNMHDH.KEKKDELENHO.allowSceneActivation = true;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object EAGBDDECKHF()
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
				PHDOCKCBJOF = new WaitForSeconds(1310f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JIIIEADHBHK());
				PHDOCKCBJOF = new WaitForSeconds(439f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 2u:
				BJGCPDNMHDH.HKAFPCAPDIG.gameObject.SetActive(false);
				BJGCPDNMHDH.ENMLDHGLIJN.gameObject.SetActive(true);
				PHDOCKCBJOF = new WaitForSeconds(1817f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 3u:
			case 4u:
				if (!BJGCPDNMHDH.NFCFELCNIJI)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				ALJKAAMHHLB.IIKFADEHJIL("GameController.OnDataLoaded ");
				GNIONNGOEJF = Time.realtimeSinceStartup + 1887f;
				goto case 5u;
			case 5u:
				if (!BJGCPDNMHDH.ICPEJCOLIGF)
				{
					if (!(Time.realtimeSinceStartup > GNIONNGOEJF))
					{
						PHDOCKCBJOF = new WaitForSeconds(1396f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 4;
						}
						break;
					}
					Exception exception = new Exception("Buy_DogTags");
					AnalyticsHelper.LogHandledException(exception);
				}
				ALJKAAMHHLB.BDMJCGAGCEE("ID_LOADING");
				ALJKAAMHHLB.PJIMOPNDNKO("x");
				goto case 6u;
			case 6u:
				if (BJGCPDNMHDH.KEKKDELENHO == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				ALJKAAMHHLB.GCIEGGGEGMB("Sync match start time {0} photon time: {1}");
				UnityEngine.Debug.Log("\n");
				BJGCPDNMHDH.KEKKDELENHO.allowSceneActivation = true;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public bool FNEPBDLIKOD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(414f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JIIIEADHBHK());
				PHDOCKCBJOF = new WaitForSeconds(1370f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 2u:
				BJGCPDNMHDH.HKAFPCAPDIG.gameObject.SetActive(true);
				BJGCPDNMHDH.ENMLDHGLIJN.gameObject.SetActive(false);
				PHDOCKCBJOF = new WaitForSeconds(358f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 3u:
			case 4u:
				if (!BJGCPDNMHDH.NFCFELCNIJI)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				ALJKAAMHHLB.KPDABFIIJMN(" BUTTONS CONTENT ");
				GNIONNGOEJF = Time.realtimeSinceStartup + 1578f;
				goto case 5u;
			case 5u:
				if (!BJGCPDNMHDH.ICPEJCOLIGF)
				{
					if (!(Time.realtimeSinceStartup > GNIONNGOEJF))
					{
						PHDOCKCBJOF = new WaitForSeconds(594f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 4;
						}
						break;
					}
					Exception exception = new Exception("game-tilegfx-tutorial");
					AnalyticsHelper.LogHandledException(exception);
				}
				ALJKAAMHHLB.ELFCGAGEFLH("Visual {0}, no overcount");
				ALJKAAMHHLB.CCDJDGFFCHC("game-card-ico-supersoldiers");
				goto case 6u;
			case 6u:
				if (BJGCPDNMHDH.KEKKDELENHO == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				ALJKAAMHHLB.HNMONAFFBLE("N");
				UnityEngine.Debug.Log("DeviceToken");
				BJGCPDNMHDH.KEKKDELENHO.allowSceneActivation = true;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object LMJBCDNGAHP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BOOBHEKPLLD()
		{
			return PHDOCKCBJOF;
		}

		public void FMOJMHBAHAA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void ABBPOMCBIIH()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GEFKCGOOFFP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KKCOHEHPJPF()
		{
			return PHDOCKCBJOF;
		}

		public void OMDFNFHKFBK()
		{
			throw new NotSupportedException();
		}

		public bool GCEBFCBBEKM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(889f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JIIIEADHBHK());
				PHDOCKCBJOF = new WaitForSeconds(1038f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 2u:
				BJGCPDNMHDH.HKAFPCAPDIG.gameObject.SetActive(false);
				BJGCPDNMHDH.ENMLDHGLIJN.gameObject.SetActive(true);
				PHDOCKCBJOF = new WaitForSeconds(495f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 3u:
			case 4u:
				if (!BJGCPDNMHDH.NFCFELCNIJI)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				ALJKAAMHHLB.KPDABFIIJMN("Executing Oflline RPC {0} {1}");
				GNIONNGOEJF = Time.realtimeSinceStartup + 415f;
				goto case 5u;
			case 5u:
				if (!BJGCPDNMHDH.ICPEJCOLIGF)
				{
					if (!(Time.realtimeSinceStartup > GNIONNGOEJF))
					{
						PHDOCKCBJOF = new WaitForSeconds(738f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 7;
						}
						break;
					}
					Exception exception = new Exception("Rule Record For Height");
					AnalyticsHelper.LogHandledException(exception);
				}
				ALJKAAMHHLB.GHBPDBCICLM("App could not be run");
				ALJKAAMHHLB.BIDJNBKOMIN("ID_GUI_TIMEXPBONUS");
				goto case 6u;
			case 6u:
				if (BJGCPDNMHDH.KEKKDELENHO == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				ALJKAAMHHLB.MFOOEEHKEHE("Spend_Gold_On_Army");
				UnityEngine.Debug.Log("setUserId");
				BJGCPDNMHDH.KEKKDELENHO.allowSceneActivation = true;
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

		[SpecialName]
		private object NDIGINEEOMH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KBEEEOJMBPG()
		{
			return PHDOCKCBJOF;
		}

		public void AHEOCEEJICJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public JNAGDDONNMO()
		{
		}

		public void MIPBONGPIJE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void FIAPMEMIIKB()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object INAMGPNDAAJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HGOKAFJBFGJ()
		{
			return PHDOCKCBJOF;
		}

		public void CPOKHODGGLN()
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
				PHDOCKCBJOF = new WaitForSeconds(108f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JIIIEADHBHK());
				PHDOCKCBJOF = new WaitForSeconds(1340f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
				BJGCPDNMHDH.HKAFPCAPDIG.gameObject.SetActive(false);
				BJGCPDNMHDH.ENMLDHGLIJN.gameObject.SetActive(false);
				PHDOCKCBJOF = new WaitForSeconds(1241f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 3u:
			case 4u:
				if (!BJGCPDNMHDH.NFCFELCNIJI)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				ALJKAAMHHLB.FLMPAIEBDBB("ID_ARENARULES_NOCRATES");
				GNIONNGOEJF = Time.realtimeSinceStartup + 830f;
				goto case 5u;
			case 5u:
				if (!BJGCPDNMHDH.ICPEJCOLIGF)
				{
					if (!(Time.realtimeSinceStartup > GNIONNGOEJF))
					{
						PHDOCKCBJOF = new WaitForSeconds(1490f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 8;
						}
						break;
					}
					Exception exception = new Exception("AssignmentId");
					AnalyticsHelper.LogHandledException(exception);
				}
				ALJKAAMHHLB.CNOACHKNDCB("getSessionPercentile");
				ALJKAAMHHLB.GJJDKOMHHDH(")");
				goto case 6u;
			case 6u:
				if (BJGCPDNMHDH.KEKKDELENHO == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				ALJKAAMHHLB.ACPILMDBDKH("ID_WEHAVERECEIVEDCOMPLAINTSREGARDING");
				UnityEngine.Debug.Log("ID_CONFIRM_ERROR");
				BJGCPDNMHDH.KEKKDELENHO.allowSceneActivation = false;
				CLPPIAGLCJJ = -1;
				goto default;
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
				PHDOCKCBJOF = new WaitForSeconds(1043f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JIIIEADHBHK());
				PHDOCKCBJOF = new WaitForSeconds(1520f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 2u:
				BJGCPDNMHDH.HKAFPCAPDIG.gameObject.SetActive(false);
				BJGCPDNMHDH.ENMLDHGLIJN.gameObject.SetActive(false);
				PHDOCKCBJOF = new WaitForSeconds(1639f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 3u:
			case 4u:
				if (!BJGCPDNMHDH.NFCFELCNIJI)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				ALJKAAMHHLB.ACOCPELKALN(".");
				GNIONNGOEJF = Time.realtimeSinceStartup + 612f;
				goto case 5u;
			case 5u:
				if (!BJGCPDNMHDH.ICPEJCOLIGF)
				{
					if (!(Time.realtimeSinceStartup > GNIONNGOEJF))
					{
						PHDOCKCBJOF = new WaitForSeconds(1041f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 7;
						}
						break;
					}
					Exception exception = new Exception("Grenade_Throwing_Tutorial_Duration");
					AnalyticsHelper.LogHandledException(exception);
				}
				ALJKAAMHHLB.EEDNCCEAKDI("shield_run");
				ALJKAAMHHLB.GJJDKOMHHDH("ID_MONEYPACKINFORMATIONS");
				goto case 6u;
			case 6u:
				if (BJGCPDNMHDH.KEKKDELENHO == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				ALJKAAMHHLB.ALPPDLMMCIH("Checker");
				UnityEngine.Debug.Log("0.5");
				BJGCPDNMHDH.KEKKDELENHO.allowSceneActivation = true;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object HCCLNDKNCIE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AGANCOFPDCK()
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
				PHDOCKCBJOF = new WaitForSeconds(1061f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JIIIEADHBHK());
				PHDOCKCBJOF = new WaitForSeconds(537f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 2u:
				BJGCPDNMHDH.HKAFPCAPDIG.gameObject.SetActive(false);
				BJGCPDNMHDH.ENMLDHGLIJN.gameObject.SetActive(false);
				PHDOCKCBJOF = new WaitForSeconds(439f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 3u:
			case 4u:
				if (!BJGCPDNMHDH.NFCFELCNIJI)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				ALJKAAMHHLB.IIKFADEHJIL("GLM: RegisterOrLogin -  3");
				GNIONNGOEJF = Time.realtimeSinceStartup + 344f;
				goto case 5u;
			case 5u:
				if (!BJGCPDNMHDH.ICPEJCOLIGF)
				{
					if (!(Time.realtimeSinceStartup > GNIONNGOEJF))
					{
						PHDOCKCBJOF = new WaitForSeconds(760f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 4;
						}
						break;
					}
					Exception exception = new Exception("ExplodeDamage");
					AnalyticsHelper.LogHandledException(exception);
				}
				ALJKAAMHHLB.PDICPJLEKBI("------------------\n");
				ALJKAAMHHLB.GJJDKOMHHDH("ID_VIDEOSERVICE");
				goto case 6u;
			case 6u:
				if (BJGCPDNMHDH.KEKKDELENHO == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				ALJKAAMHHLB.FLLHBKEFGHB("special");
				UnityEngine.Debug.Log("ID_INFO");
				BJGCPDNMHDH.KEKKDELENHO.allowSceneActivation = true;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void NBMNDHCIBME()
		{
			throw new NotSupportedException();
		}

		public void MHKKAFGKBJK()
		{
			throw new NotSupportedException();
		}

		public void MAKKCANEHIB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object LKAEMBCGLBN()
		{
			return PHDOCKCBJOF;
		}

		public void CDDFJOEEFID()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IJFPHIKFJFB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HHHLDCLIFKJ()
		{
			return PHDOCKCBJOF;
		}

		public void BCIPEBNJONK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object JMKGAJNOLEM()
		{
			return PHDOCKCBJOF;
		}

		public void HHMPMPLLJCC()
		{
			throw new NotSupportedException();
		}

		public void JFPPMJPGGIN()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JPJBNHHKOJD()
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
				PHDOCKCBJOF = new WaitForSeconds(1086f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JIIIEADHBHK());
				PHDOCKCBJOF = new WaitForSeconds(1577f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 2u:
				BJGCPDNMHDH.HKAFPCAPDIG.gameObject.SetActive(false);
				BJGCPDNMHDH.ENMLDHGLIJN.gameObject.SetActive(false);
				PHDOCKCBJOF = new WaitForSeconds(697f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 3u:
			case 4u:
				if (!BJGCPDNMHDH.NFCFELCNIJI)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				ALJKAAMHHLB.NOGHPDFNHOB("withAgencyId");
				GNIONNGOEJF = Time.realtimeSinceStartup + 1164f;
				goto case 5u;
			case 5u:
				if (!BJGCPDNMHDH.ICPEJCOLIGF)
				{
					if (!(Time.realtimeSinceStartup > GNIONNGOEJF))
					{
						PHDOCKCBJOF = new WaitForSeconds(504f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						break;
					}
					Exception exception = new Exception("\t\"FALSE\"");
					AnalyticsHelper.LogHandledException(exception);
				}
				ALJKAAMHHLB.CNOACHKNDCB(" & ");
				ALJKAAMHHLB.CIILNLBGGHM("AdAvailabilityResponse(");
				goto case 6u;
			case 6u:
				if (BJGCPDNMHDH.KEKKDELENHO == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				ALJKAAMHHLB.CJEDHGLIGJH("GameReward");
				UnityEngine.Debug.Log("withAttribute3");
				BJGCPDNMHDH.KEKKDELENHO.allowSceneActivation = true;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object GCJFGIKENJA()
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
				PHDOCKCBJOF = new WaitForSeconds(395f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JIIIEADHBHK());
				PHDOCKCBJOF = new WaitForSeconds(893f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 2u:
				BJGCPDNMHDH.HKAFPCAPDIG.gameObject.SetActive(true);
				BJGCPDNMHDH.ENMLDHGLIJN.gameObject.SetActive(true);
				PHDOCKCBJOF = new WaitForSeconds(1978f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 3u:
			case 4u:
				if (!BJGCPDNMHDH.NFCFELCNIJI)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				ALJKAAMHHLB.NBJCJMJIPND("Area");
				GNIONNGOEJF = Time.realtimeSinceStartup + 1211f;
				goto case 5u;
			case 5u:
				if (!BJGCPDNMHDH.ICPEJCOLIGF)
				{
					if (!(Time.realtimeSinceStartup > GNIONNGOEJF))
					{
						PHDOCKCBJOF = new WaitForSeconds(1057f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						break;
					}
					Exception exception = new Exception("GetLockResultRPC");
					AnalyticsHelper.LogHandledException(exception);
				}
				ALJKAAMHHLB.AEHLEODHMGP("N0");
				ALJKAAMHHLB.DHPGNLOHBLC("UnitTutorial");
				goto case 6u;
			case 6u:
				if (BJGCPDNMHDH.KEKKDELENHO == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				ALJKAAMHHLB.AFBPFLKBNGM("0\u00a0");
				UnityEngine.Debug.Log("lootboxesOfferAdd");
				BJGCPDNMHDH.KEKKDELENHO.allowSceneActivation = true;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object APECNPGKOFC()
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
				PHDOCKCBJOF = new WaitForSeconds(599f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JIIIEADHBHK());
				PHDOCKCBJOF = new WaitForSeconds(1834f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 2u:
				BJGCPDNMHDH.HKAFPCAPDIG.gameObject.SetActive(false);
				BJGCPDNMHDH.ENMLDHGLIJN.gameObject.SetActive(true);
				PHDOCKCBJOF = new WaitForSeconds(1796f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 3u:
			case 4u:
				if (!BJGCPDNMHDH.NFCFELCNIJI)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				ALJKAAMHHLB.KNALFHAOFBN("Can not find player with fraction ");
				GNIONNGOEJF = Time.realtimeSinceStartup + 1664f;
				goto case 5u;
			case 5u:
				if (!BJGCPDNMHDH.ICPEJCOLIGF)
				{
					if (!(Time.realtimeSinceStartup > GNIONNGOEJF))
					{
						PHDOCKCBJOF = new WaitForSeconds(1228f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 3;
						}
						break;
					}
					Exception exception = new Exception("run");
					AnalyticsHelper.LogHandledException(exception);
				}
				ALJKAAMHHLB.CNOACHKNDCB("确认");
				ALJKAAMHHLB.ACPILMDBDKH("ID_STAT_WINS");
				goto case 6u;
			case 6u:
				if (BJGCPDNMHDH.KEKKDELENHO == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				ALJKAAMHHLB.POPONJAMPDF("FacebookName");
				UnityEngine.Debug.Log("GooglePlayId");
				BJGCPDNMHDH.KEKKDELENHO.allowSceneActivation = false;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object BLOJDIFOPIA()
		{
			return PHDOCKCBJOF;
		}

		public void LKACEPHEHPK()
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
				PHDOCKCBJOF = new WaitForSeconds(745f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JIIIEADHBHK());
				PHDOCKCBJOF = new WaitForSeconds(1034f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 2u:
				BJGCPDNMHDH.HKAFPCAPDIG.gameObject.SetActive(true);
				BJGCPDNMHDH.ENMLDHGLIJN.gameObject.SetActive(true);
				PHDOCKCBJOF = new WaitForSeconds(1061f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 3u:
			case 4u:
				if (!BJGCPDNMHDH.NFCFELCNIJI)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				ALJKAAMHHLB.JIBKGLAPOIB("Grenade_Throwing_Tutorial_Duration");
				GNIONNGOEJF = Time.realtimeSinceStartup + 1895f;
				goto case 5u;
			case 5u:
				if (!BJGCPDNMHDH.ICPEJCOLIGF)
				{
					if (!(Time.realtimeSinceStartup > GNIONNGOEJF))
					{
						PHDOCKCBJOF = new WaitForSeconds(95f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 8;
						}
						break;
					}
					Exception exception = new Exception("313 MENU ENABLE PUSH");
					AnalyticsHelper.LogHandledException(exception);
				}
				ALJKAAMHHLB.GHBPDBCICLM("url");
				ALJKAAMHHLB.BCPKGMMMOPH("ID_AFFECTEDOWNUNITS");
				goto case 6u;
			case 6u:
				if (BJGCPDNMHDH.KEKKDELENHO == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				ALJKAAMHHLB.BCPKGMMMOPH("ID_ARENASHORTCUTPHASEEND");
				UnityEngine.Debug.Log("AdminPlayerId");
				BJGCPDNMHDH.KEKKDELENHO.allowSceneActivation = false;
				CLPPIAGLCJJ = -1;
				goto default;
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

		public void AKEKFBGEJBG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MPHILJJDNIO()
		{
			return PHDOCKCBJOF;
		}

		public void INBELBGOCLD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object EBPKDAHAELB()
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
				PHDOCKCBJOF = new WaitForSeconds(1624f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JIIIEADHBHK());
				PHDOCKCBJOF = new WaitForSeconds(1517f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 2u:
				BJGCPDNMHDH.HKAFPCAPDIG.gameObject.SetActive(false);
				BJGCPDNMHDH.ENMLDHGLIJN.gameObject.SetActive(true);
				PHDOCKCBJOF = new WaitForSeconds(1290f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 3u:
			case 4u:
				if (!BJGCPDNMHDH.NFCFELCNIJI)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				ALJKAAMHHLB.HGHDLLMKPEO("Player_Had_To_Select_Grenade");
				GNIONNGOEJF = Time.realtimeSinceStartup + 1761f;
				goto case 5u;
			case 5u:
				if (!BJGCPDNMHDH.ICPEJCOLIGF)
				{
					if (!(Time.realtimeSinceStartup > GNIONNGOEJF))
					{
						PHDOCKCBJOF = new WaitForSeconds(942f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 6;
						}
						break;
					}
					Exception exception = new Exception("CreateGcAccount with ");
					AnalyticsHelper.LogHandledException(exception);
				}
				ALJKAAMHHLB.PDICPJLEKBI("Automatic_Equip");
				ALJKAAMHHLB.DHPGNLOHBLC("AssignmentData");
				goto case 6u;
			case 6u:
				if (BJGCPDNMHDH.KEKKDELENHO == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				ALJKAAMHHLB.GJJDKOMHHDH("+0");
				UnityEngine.Debug.Log("reloadTime");
				BJGCPDNMHDH.KEKKDELENHO.allowSceneActivation = true;
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public bool OKELILGDPLJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(647f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JIIIEADHBHK());
				PHDOCKCBJOF = new WaitForSeconds(860f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 2u:
				BJGCPDNMHDH.HKAFPCAPDIG.gameObject.SetActive(true);
				BJGCPDNMHDH.ENMLDHGLIJN.gameObject.SetActive(true);
				PHDOCKCBJOF = new WaitForSeconds(1422f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 3u:
			case 4u:
				if (!BJGCPDNMHDH.NFCFELCNIJI)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				ALJKAAMHHLB.JHOMLIBOPJD("ID_STATE_WAITINGFOROPPONENT");
				GNIONNGOEJF = Time.realtimeSinceStartup + 1914f;
				goto case 5u;
			case 5u:
				if (!BJGCPDNMHDH.ICPEJCOLIGF)
				{
					if (!(Time.realtimeSinceStartup > GNIONNGOEJF))
					{
						PHDOCKCBJOF = new WaitForSeconds(1955f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 8;
						}
						break;
					}
					Exception exception = new Exception("ID_DAYSAGO");
					AnalyticsHelper.LogHandledException(exception);
				}
				ALJKAAMHHLB.BDMJCGAGCEE("TransactionId123");
				ALJKAAMHHLB.IEBHKBNOEBP(", dictionary= ");
				goto case 6u;
			case 6u:
				if (BJGCPDNMHDH.KEKKDELENHO == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				ALJKAAMHHLB.BIDJNBKOMIN("resizing texture ");
				UnityEngine.Debug.Log("NewVisuals");
				BJGCPDNMHDH.KEKKDELENHO.allowSceneActivation = false;
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
	}

	private sealed class EDJCKHBMGAB : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal GameLauncher BJGCPDNMHDH;

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

		public void KAFNGNMNNOA()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MBGCBKJBCND()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BJDOHADMIEB()
		{
			return PHDOCKCBJOF;
		}

		public void FLGABFOKLNM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HGMMDPIGEGN()
		{
			return PHDOCKCBJOF;
		}

		public void MKACBCOLNKD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool MPKAJACHAIC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.IEBHKBNOEBP("ID_SECOND");
				if (BJGCPDNMHDH.LPJICJIIMNG)
				{
					BJGCPDNMHDH.KHAFLJBGEGC = GooglePlayDownloader.GetExpansionFilePath();
					BJGCPDNMHDH.MDJFBFNMDKD = GooglePlayDownloader.GetMainOBBPath(BJGCPDNMHDH.KHAFLJBGEGC);
					object[] array = new object[0];
					array[0] = BJGCPDNMHDH.KHAFLJBGEGC ?? "REMOVING CURRENT PLAYER FROM SQUAD ";
					array[0] = BJGCPDNMHDH.MDJFBFNMDKD ?? ". Loading default...";
					UnityEngine.Debug.LogWarningFormat("succesfully", array);
					if (BJGCPDNMHDH.MDJFBFNMDKD != null)
					{
						BJGCPDNMHDH.AKLJDFKFKHL = true;
						try
						{
							FileStream fileStream = File.OpenRead(BJGCPDNMHDH.MDJFBFNMDKD);
							long num = ((64 >= fileStream.Length) ? fileStream.Length : 70);
							if (num > 1)
							{
								byte[] buffer = new byte[num];
								int num2 = fileStream.Read(buffer, 1, (int)num);
								UnityEngine.Debug.LogWarning("Different levels \"{0}\" and \"{1}\"\n" + num2);
							}
							else
							{
								UnityEngine.Debug.LogWarning("Wrong_Weapon");
							}
						}
						catch (Exception ex)
						{
							UnityEngine.Debug.LogWarning("ID_ARENARULES_HALVEDAMMO" + ex.ToString());
							BJGCPDNMHDH.AKLJDFKFKHL = true;
						}
						if (!BJGCPDNMHDH.AKLJDFKFKHL)
						{
							BJGCPDNMHDH.JDFMLCIODND.Show();
							BJGCPDNMHDH.JDFMLCIODND.MAHCHHEBJDL();
							goto case 1u;
						}
					}
					goto IL_0265;
				}
				goto IL_040d;
			case 1u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.LHAOJPIJCNG;
					NoodlePermissionGranter.GrantPermission(NoodlePermissionGranter.NoodleAndroidPermission.WRITE_EXTERNAL_STORAGE);
					goto case 2u;
				}
				Application.Quit();
				goto IL_0265;
			case 2u:
				if (!BJGCPDNMHDH.AKLJDFKFKHL)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				goto IL_0265;
			case 3u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.KKPMALKPMFF;
					NoodlePermissionGranter.GrantPermission(NoodlePermissionGranter.NoodleAndroidPermission.WRITE_EXTERNAL_STORAGE);
					goto case 6u;
				}
				PHDOCKCBJOF = new WaitForRealSeconds(1452f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 4u:
				BJGCPDNMHDH.JDFMLCIODND.Show();
				BJGCPDNMHDH.JDFMLCIODND.KJLALGDJFHN();
				goto case 5u;
			case 5u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.KKPMALKPMFF;
					NoodlePermissionGranter.GrantPermission(NoodlePermissionGranter.NoodleAndroidPermission.WRITE_EXTERNAL_STORAGE);
				}
				else
				{
					Application.Quit();
				}
				goto case 6u;
			case 6u:
				if ((BJGCPDNMHDH.MDJFBFNMDKD = GooglePlayDownloader.GetMainOBBPath(BJGCPDNMHDH.KHAFLJBGEGC)) == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				goto IL_040d;
			case 7u:
				ALJKAAMHHLB.EGLIMGAEPGI("D3");
				ALJKAAMHHLB.EEDNCCEAKDI("S");
				UnityEngine.Object.Destroy(BJGCPDNMHDH.AADLIDMHFLM.gameObject);
				Singleton<GameCenterProvider>.instance.JFHNEDNOHIJ = false;
				UnityEngine.Debug.Log("WithdrawerId");
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 8u:
			{
				for (int i = 0; i < BJGCPDNMHDH.transform.childCount; i++)
				{
					Transform child = BJGCPDNMHDH.transform.GetChild(i);
					child.gameObject.SetActive(false);
				}
				BJGCPDNMHDH.ENMLDHGLIJN.gameObject.SetActive(true);
				Resources.UnloadAsset(BJGCPDNMHDH.BINPHPBJPMD.texture);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -38;
				}
				break;
			}
			case 9u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -52;
				}
				break;
			case 10u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -39;
				}
				break;
			case 11u:
				UnityEngine.Object.Destroy(BJGCPDNMHDH.gameObject);
				ALJKAAMHHLB.BIDJNBKOMIN("ID_UNIT2UPGRADEABILITY_UNIT1TRAIN");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_040d:
				ALJKAAMHHLB.DLAEBOBJKBL("RequestsResults");
				BJGCPDNMHDH.FAGNMEOAFNF.SetActive(false);
				UnityEngine.Debug.Log("S" + DateTime.UtcNow);
				Application.backgroundLoadingPriority = (ThreadPriority)3;
				ALJKAAMHHLB.PDJBNKAOBBG("{0}\u00a0{1}");
				BJGCPDNMHDH.KEKKDELENHO = SceneManager.LoadSceneAsync("/PC/");
				ALJKAAMHHLB.KEJEFPFHIFB("ID_STAT_UNITSUPGRADES");
				BJGCPDNMHDH.KEKKDELENHO.allowSceneActivation = true;
				PHDOCKCBJOF = BJGCPDNMHDH.KEKKDELENHO;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
				IL_0265:
				if (BJGCPDNMHDH.MDJFBFNMDKD == null)
				{
					BJGCPDNMHDH.JDFMLCIODND.Show();
					BJGCPDNMHDH.JDFMLCIODND.BPOEFALJCIH();
					goto case 3u;
				}
				goto IL_040d;
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
				ALJKAAMHHLB.EGLIMGAEPGI("Facebook Service: share dialog succeeded. Obsah dict = ");
				if (BJGCPDNMHDH.LPJICJIIMNG)
				{
					BJGCPDNMHDH.KHAFLJBGEGC = GooglePlayDownloader.GetExpansionFilePath();
					BJGCPDNMHDH.MDJFBFNMDKD = GooglePlayDownloader.GetMainOBBPath(BJGCPDNMHDH.KHAFLJBGEGC);
					object[] array = new object[5];
					array[1] = BJGCPDNMHDH.KHAFLJBGEGC ?? "iCloud: Save Player!";
					array[0] = BJGCPDNMHDH.MDJFBFNMDKD ?? ") ";
					UnityEngine.Debug.LogWarningFormat("StartTime", array);
					if (BJGCPDNMHDH.MDJFBFNMDKD != null)
					{
						BJGCPDNMHDH.AKLJDFKFKHL = false;
						try
						{
							FileStream fileStream = File.OpenRead(BJGCPDNMHDH.MDJFBFNMDKD);
							long num = ((96 >= fileStream.Length) ? fileStream.Length : (-62));
							if (num > 0)
							{
								byte[] buffer = new byte[num];
								int num2 = fileStream.Read(buffer, 0, (int)num);
								UnityEngine.Debug.LogWarning("otherInfo" + num2);
							}
							else
							{
								UnityEngine.Debug.LogWarning("ID_STAT_LOSSES");
							}
						}
						catch (Exception ex)
						{
							UnityEngine.Debug.LogWarning("shield_shot" + ex.ToString());
							BJGCPDNMHDH.AKLJDFKFKHL = false;
						}
						if (!BJGCPDNMHDH.AKLJDFKFKHL)
						{
							BJGCPDNMHDH.JDFMLCIODND.Show();
							BJGCPDNMHDH.JDFMLCIODND.MAHCHHEBJDL();
							goto case 1u;
						}
					}
					goto IL_0265;
				}
				goto IL_040d;
			case 1u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.LHAOJPIJCNG;
					NoodlePermissionGranter.GrantPermission(NoodlePermissionGranter.NoodleAndroidPermission.WRITE_EXTERNAL_STORAGE);
					goto case 2u;
				}
				Application.Quit();
				goto IL_0265;
			case 2u:
				if (!BJGCPDNMHDH.AKLJDFKFKHL)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				goto IL_0265;
			case 3u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.JHHKBBAEGHD;
					NoodlePermissionGranter.GrantPermission(NoodlePermissionGranter.NoodleAndroidPermission.WRITE_EXTERNAL_STORAGE);
					goto case 6u;
				}
				PHDOCKCBJOF = new WaitForRealSeconds(909f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 4u:
				BJGCPDNMHDH.JDFMLCIODND.Show();
				BJGCPDNMHDH.JDFMLCIODND.KJLALGDJFHN();
				goto case 5u;
			case 5u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.JMAMMDDKPPB;
					NoodlePermissionGranter.GrantPermission(NoodlePermissionGranter.NoodleAndroidPermission.WRITE_EXTERNAL_STORAGE);
				}
				else
				{
					Application.Quit();
				}
				goto case 6u;
			case 6u:
				if ((BJGCPDNMHDH.MDJFBFNMDKD = GooglePlayDownloader.GetMainOBBPath(BJGCPDNMHDH.KHAFLJBGEGC)) == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto IL_040d;
			case 7u:
				ALJKAAMHHLB.AFBPFLKBNGM("Player disconected 0001");
				ALJKAAMHHLB.GHBPDBCICLM("Prefabs");
				UnityEngine.Object.Destroy(BJGCPDNMHDH.AADLIDMHFLM.gameObject);
				Singleton<GameCenterProvider>.instance.JFHNEDNOHIJ = false;
				UnityEngine.Debug.Log("com/google/android/gms/games/Games");
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 8u:
			{
				for (int i = 0; i < BJGCPDNMHDH.transform.childCount; i += 0)
				{
					Transform child = BJGCPDNMHDH.transform.GetChild(i);
					child.gameObject.SetActive(true);
				}
				BJGCPDNMHDH.ENMLDHGLIJN.gameObject.SetActive(true);
				Resources.UnloadAsset(BJGCPDNMHDH.BINPHPBJPMD.texture);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -89;
				}
				break;
			}
			case 9u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 24;
				}
				break;
			case 10u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -8;
				}
				break;
			case 11u:
				UnityEngine.Object.Destroy(BJGCPDNMHDH.gameObject);
				ALJKAAMHHLB.ACPILMDBDKH("S");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_040d:
				ALJKAAMHHLB.MAJHIDGCOGK("ItemsOwned_Rarity_4");
				BJGCPDNMHDH.FAGNMEOAFNF.SetActive(false);
				UnityEngine.Debug.Log("ID_NEWLOOTBOXINBATTLES" + DateTime.UtcNow);
				Application.backgroundLoadingPriority = (ThreadPriority)3;
				ALJKAAMHHLB.PDJBNKAOBBG("PACK");
				BJGCPDNMHDH.KEKKDELENHO = SceneManager.LoadSceneAsync("Manual_Unit_Spawn");
				ALJKAAMHHLB.KEJEFPFHIFB("GameController.Start START");
				BJGCPDNMHDH.KEKKDELENHO.allowSceneActivation = false;
				PHDOCKCBJOF = BJGCPDNMHDH.KEKKDELENHO;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
				IL_0265:
				if (BJGCPDNMHDH.MDJFBFNMDKD == null)
				{
					BJGCPDNMHDH.JDFMLCIODND.Show();
					BJGCPDNMHDH.JDFMLCIODND.SetDownloadTexts();
					goto case 3u;
				}
				goto IL_040d;
			}
			return false;
		}

		public void HCPCOBKDMJA()
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
				ALJKAAMHHLB.CIILNLBGGHM(" is not supported on this platform!");
				if (BJGCPDNMHDH.LPJICJIIMNG)
				{
					BJGCPDNMHDH.KHAFLJBGEGC = GooglePlayDownloader.GetExpansionFilePath();
					BJGCPDNMHDH.MDJFBFNMDKD = GooglePlayDownloader.GetMainOBBPath(BJGCPDNMHDH.KHAFLJBGEGC);
					UnityEngine.Debug.LogWarningFormat("InstantBattleEnded: 3RD REWARD WARBUCKS: ", BJGCPDNMHDH.KHAFLJBGEGC ?? "response contain VipReward", BJGCPDNMHDH.MDJFBFNMDKD ?? "menu-squad-{0}", null, null);
					if (BJGCPDNMHDH.MDJFBFNMDKD != null)
					{
						BJGCPDNMHDH.AKLJDFKFKHL = false;
						try
						{
							FileStream fileStream = File.OpenRead(BJGCPDNMHDH.MDJFBFNMDKD);
							long num = ((79 >= fileStream.Length) ? fileStream.Length : 100);
							if (num > 0)
							{
								byte[] buffer = new byte[num];
								int num2 = fileStream.Read(buffer, 1, (int)num);
								UnityEngine.Debug.LogWarning("ID_READYTIME" + num2);
							}
							else
							{
								UnityEngine.Debug.LogWarning("ID_CONFIRM_LEAVESQUAD");
							}
						}
						catch (Exception ex)
						{
							UnityEngine.Debug.LogWarning("Awaiting players - Player id:\"{0}\" is not in list of awaiting members - cannot decline player" + ex.ToString());
							BJGCPDNMHDH.AKLJDFKFKHL = false;
						}
						if (!BJGCPDNMHDH.AKLJDFKFKHL)
						{
							BJGCPDNMHDH.JDFMLCIODND.Show();
							BJGCPDNMHDH.JDFMLCIODND.PPAICMHHKOO();
							goto case 1u;
						}
					}
					goto IL_0265;
				}
				goto IL_040d;
			case 1u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.OBNHCBGMDKI;
					NoodlePermissionGranter.GrantPermission(NoodlePermissionGranter.NoodleAndroidPermission.WRITE_EXTERNAL_STORAGE);
					goto case 2u;
				}
				Application.Quit();
				goto IL_0265;
			case 2u:
				if (!BJGCPDNMHDH.AKLJDFKFKHL)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				goto IL_0265;
			case 3u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.ACBFFHLCKBD;
					NoodlePermissionGranter.GrantPermission(NoodlePermissionGranter.NoodleAndroidPermission.WRITE_EXTERNAL_STORAGE);
					goto case 6u;
				}
				PHDOCKCBJOF = new WaitForRealSeconds(506f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 4u:
				BJGCPDNMHDH.JDFMLCIODND.Show();
				BJGCPDNMHDH.JDFMLCIODND.SetReallyDontDownloadTexts();
				goto case 5u;
			case 5u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.PMGNMPPAMGL;
					NoodlePermissionGranter.GrantPermission((NoodlePermissionGranter.NoodleAndroidPermission)1);
				}
				else
				{
					Application.Quit();
				}
				goto case 6u;
			case 6u:
				if ((BJGCPDNMHDH.MDJFBFNMDKD = GooglePlayDownloader.GetMainOBBPath(BJGCPDNMHDH.KHAFLJBGEGC)) == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_040d;
			case 7u:
				ALJKAAMHHLB.FLLHBKEFGHB("IDFV");
				ALJKAAMHHLB.BDMJCGAGCEE("Client has newer config for: {0} Saved version {1} Client version {2}");
				UnityEngine.Object.Destroy(BJGCPDNMHDH.AADLIDMHFLM.gameObject);
				Singleton<GameCenterProvider>.instance.JFHNEDNOHIJ = false;
				UnityEngine.Debug.Log("ID_CRATESTOLEN");
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 8u:
			{
				for (int i = 0; i < BJGCPDNMHDH.transform.childCount; i += 0)
				{
					Transform child = BJGCPDNMHDH.transform.GetChild(i);
					child.gameObject.SetActive(true);
				}
				BJGCPDNMHDH.ENMLDHGLIJN.gameObject.SetActive(false);
				Resources.UnloadAsset(BJGCPDNMHDH.BINPHPBJPMD.texture);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 11;
				}
				break;
			}
			case 9u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 116;
				}
				break;
			case 10u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -21;
				}
				break;
			case 11u:
				UnityEngine.Object.Destroy(BJGCPDNMHDH.gameObject);
				ALJKAAMHHLB.CIILNLBGGHM("S");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_040d:
				ALJKAAMHHLB.JOKCPHMJIGH("ID_CONFIRM_ERROR");
				BJGCPDNMHDH.FAGNMEOAFNF.SetActive(true);
				UnityEngine.Debug.Log("MedalsBalance" + DateTime.UtcNow);
				Application.backgroundLoadingPriority = ThreadPriority.BelowNormal;
				ALJKAAMHHLB.JHOMLIBOPJD("bot");
				BJGCPDNMHDH.KEKKDELENHO = SceneManager.LoadSceneAsync("{0} {1}.");
				ALJKAAMHHLB.EGLIMGAEPGI("subscribed");
				BJGCPDNMHDH.KEKKDELENHO.allowSceneActivation = true;
				PHDOCKCBJOF = BJGCPDNMHDH.KEKKDELENHO;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
				IL_0265:
				if (BJGCPDNMHDH.MDJFBFNMDKD == null)
				{
					BJGCPDNMHDH.JDFMLCIODND.Show();
					BJGCPDNMHDH.JDFMLCIODND.SetDownloadTexts();
					goto case 3u;
				}
				goto IL_040d;
			}
			return false;
		}

		[SpecialName]
		private object EKJDPPIGKCF()
		{
			return PHDOCKCBJOF;
		}

		public void NAKEBJFGMII()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BGAGLOJHMEJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ENJAAMADMEH()
		{
			return PHDOCKCBJOF;
		}

		public void JANIKOFKDCH()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HNBOIMNNPOH()
		{
			return PHDOCKCBJOF;
		}

		public void HMBLLDJFIJG()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JKKAEPEAGNP()
		{
			return PHDOCKCBJOF;
		}

		public void JJOAHIOBOPO()
		{
			throw new NotSupportedException();
		}

		public void HOFJFOCEKJJ()
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
				ALJKAAMHHLB.BIDJNBKOMIN("C4");
				if (BJGCPDNMHDH.LPJICJIIMNG)
				{
					BJGCPDNMHDH.KHAFLJBGEGC = GooglePlayDownloader.GetExpansionFilePath();
					BJGCPDNMHDH.MDJFBFNMDKD = GooglePlayDownloader.GetMainOBBPath(BJGCPDNMHDH.KHAFLJBGEGC);
					UnityEngine.Debug.LogWarningFormat("ID_OFFERACTIVE", BJGCPDNMHDH.KHAFLJBGEGC ?? "ID_GUI_SQUADWARSEND", BJGCPDNMHDH.MDJFBFNMDKD ?? "Skill", null, null, null, null, null, null);
					if (BJGCPDNMHDH.MDJFBFNMDKD != null)
					{
						BJGCPDNMHDH.AKLJDFKFKHL = false;
						try
						{
							FileStream fileStream = File.OpenRead(BJGCPDNMHDH.MDJFBFNMDKD);
							long num = ((122 >= fileStream.Length) ? fileStream.Length : 43);
							if (num > 0)
							{
								byte[] buffer = new byte[num];
								int num2 = fileStream.Read(buffer, 1, (int)num);
								UnityEngine.Debug.LogWarning("#Mission# New Wawe comming" + num2);
							}
							else
							{
								UnityEngine.Debug.LogWarning("CN");
							}
						}
						catch (Exception ex)
						{
							UnityEngine.Debug.LogWarning(")" + ex.ToString());
							BJGCPDNMHDH.AKLJDFKFKHL = true;
						}
						if (!BJGCPDNMHDH.AKLJDFKFKHL)
						{
							BJGCPDNMHDH.JDFMLCIODND.Show();
							BJGCPDNMHDH.JDFMLCIODND.PPAICMHHKOO();
							goto case 1u;
						}
					}
					goto IL_0265;
				}
				goto IL_040d;
			case 1u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.LHAOJPIJCNG;
					NoodlePermissionGranter.GrantPermission((NoodlePermissionGranter.NoodleAndroidPermission)1);
					goto case 2u;
				}
				Application.Quit();
				goto IL_0265;
			case 2u:
				if (!BJGCPDNMHDH.AKLJDFKFKHL)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				goto IL_0265;
			case 3u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.PMGNMPPAMGL;
					NoodlePermissionGranter.GrantPermission((NoodlePermissionGranter.NoodleAndroidPermission)1);
					goto case 6u;
				}
				PHDOCKCBJOF = new WaitForRealSeconds(1553f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 4u:
				BJGCPDNMHDH.JDFMLCIODND.Show();
				BJGCPDNMHDH.JDFMLCIODND.SetReallyDontDownloadTexts();
				goto case 5u;
			case 5u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.ICPLPNJDABJ;
					NoodlePermissionGranter.GrantPermission(NoodlePermissionGranter.NoodleAndroidPermission.WRITE_EXTERNAL_STORAGE);
				}
				else
				{
					Application.Quit();
				}
				goto case 6u;
			case 6u:
				if ((BJGCPDNMHDH.MDJFBFNMDKD = GooglePlayDownloader.GetMainOBBPath(BJGCPDNMHDH.KHAFLJBGEGC)) == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_040d;
			case 7u:
				ALJKAAMHHLB.ALPPDLMMCIH("ID_CLAIM");
				ALJKAAMHHLB.BDMJCGAGCEE("com/google/android/gms/games/Games");
				UnityEngine.Object.Destroy(BJGCPDNMHDH.AADLIDMHFLM.gameObject);
				Singleton<GameCenterProvider>.instance.JFHNEDNOHIJ = false;
				UnityEngine.Debug.Log("tickets");
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 8u:
			{
				for (int i = 0; i < BJGCPDNMHDH.transform.childCount; i++)
				{
					Transform child = BJGCPDNMHDH.transform.GetChild(i);
					child.gameObject.SetActive(true);
				}
				BJGCPDNMHDH.ENMLDHGLIJN.gameObject.SetActive(false);
				Resources.UnloadAsset(BJGCPDNMHDH.BINPHPBJPMD.texture);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 124;
				}
				break;
			}
			case 9u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 110;
				}
				break;
			case 10u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 86;
				}
				break;
			case 11u:
				UnityEngine.Object.Destroy(BJGCPDNMHDH.gameObject);
				ALJKAAMHHLB.GLEKOOMNAKI("{0} {1}");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_040d:
				ALJKAAMHHLB.KKCHEDILEGL("Metal");
				BJGCPDNMHDH.FAGNMEOAFNF.SetActive(false);
				UnityEngine.Debug.Log("Google2u." + DateTime.UtcNow);
				Application.backgroundLoadingPriority = ThreadPriority.High;
				ALJKAAMHHLB.EBHAFIJJMIN("0");
				BJGCPDNMHDH.KEKKDELENHO = SceneManager.LoadSceneAsync("Thank you for the following. Once again.");
				ALJKAAMHHLB.DHPGNLOHBLC("Weapon");
				BJGCPDNMHDH.KEKKDELENHO.allowSceneActivation = true;
				PHDOCKCBJOF = BJGCPDNMHDH.KEKKDELENHO;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
				IL_0265:
				if (BJGCPDNMHDH.MDJFBFNMDKD == null)
				{
					BJGCPDNMHDH.JDFMLCIODND.Show();
					BJGCPDNMHDH.JDFMLCIODND.BPOEFALJCIH();
					goto case 3u;
				}
				goto IL_040d;
			}
			return true;
		}

		[SpecialName]
		private object DOCGGPBBOAD()
		{
			return PHDOCKCBJOF;
		}

		public void NGAGGCFIEGJ()
		{
			throw new NotSupportedException();
		}

		public void NBMNDHCIBME()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MLDIMIPJMDD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HJHFKNCBGDG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FPAEFHEEOBL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OJANHAIEAEJ()
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
				ALJKAAMHHLB.GLEKOOMNAKI(" abilityIcon:");
				if (BJGCPDNMHDH.LPJICJIIMNG)
				{
					BJGCPDNMHDH.KHAFLJBGEGC = GooglePlayDownloader.GetExpansionFilePath();
					BJGCPDNMHDH.MDJFBFNMDKD = GooglePlayDownloader.GetMainOBBPath(BJGCPDNMHDH.KHAFLJBGEGC);
					object[] array = new object[0];
					array[0] = BJGCPDNMHDH.KHAFLJBGEGC ?? "isInterrupted";
					array[0] = BJGCPDNMHDH.MDJFBFNMDKD ?? "Skill";
					UnityEngine.Debug.LogWarningFormat("shootAdditive", array);
					if (BJGCPDNMHDH.MDJFBFNMDKD != null)
					{
						BJGCPDNMHDH.AKLJDFKFKHL = true;
						try
						{
							FileStream fileStream = File.OpenRead(BJGCPDNMHDH.MDJFBFNMDKD);
							long num = ((-86 >= fileStream.Length) ? fileStream.Length : (-32));
							if (num > 1)
							{
								byte[] buffer = new byte[num];
								int num2 = fileStream.Read(buffer, 0, (int)num);
								UnityEngine.Debug.LogWarning("Metal" + num2);
							}
							else
							{
								UnityEngine.Debug.LogWarning("titleFontSize");
							}
						}
						catch (Exception ex)
						{
							UnityEngine.Debug.LogWarning("Joined room" + ex.ToString());
							BJGCPDNMHDH.AKLJDFKFKHL = false;
						}
						if (!BJGCPDNMHDH.AKLJDFKFKHL)
						{
							BJGCPDNMHDH.JDFMLCIODND.Show();
							BJGCPDNMHDH.JDFMLCIODND.PPAICMHHKOO();
							goto case 1u;
						}
					}
					goto IL_0265;
				}
				goto IL_040d;
			case 1u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.LHAOJPIJCNG;
					NoodlePermissionGranter.GrantPermission(NoodlePermissionGranter.NoodleAndroidPermission.WRITE_EXTERNAL_STORAGE);
					goto case 2u;
				}
				Application.Quit();
				goto IL_0265;
			case 2u:
				if (!BJGCPDNMHDH.AKLJDFKFKHL)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				goto IL_0265;
			case 3u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.KKPMALKPMFF;
					NoodlePermissionGranter.GrantPermission((NoodlePermissionGranter.NoodleAndroidPermission)1);
					goto case 6u;
				}
				PHDOCKCBJOF = new WaitForRealSeconds(974f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 4u:
				BJGCPDNMHDH.JDFMLCIODND.Show();
				BJGCPDNMHDH.JDFMLCIODND.SetReallyDontDownloadTexts();
				goto case 5u;
			case 5u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.JMAMMDDKPPB;
					NoodlePermissionGranter.GrantPermission(NoodlePermissionGranter.NoodleAndroidPermission.WRITE_EXTERNAL_STORAGE);
				}
				else
				{
					Application.Quit();
				}
				goto case 6u;
			case 6u:
				if ((BJGCPDNMHDH.MDJFBFNMDKD = GooglePlayDownloader.GetMainOBBPath(BJGCPDNMHDH.KHAFLJBGEGC)) == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_040d;
			case 7u:
				ALJKAAMHHLB.HAAIJJBEPPN("WarBucks");
				ALJKAAMHHLB.BDMJCGAGCEE("dogtags");
				UnityEngine.Object.Destroy(BJGCPDNMHDH.AADLIDMHFLM.gameObject);
				Singleton<GameCenterProvider>.instance.JFHNEDNOHIJ = false;
				UnityEngine.Debug.Log("ID_MISSION_SURVIVE_HUD");
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 8u:
			{
				for (int i = 0; i < BJGCPDNMHDH.transform.childCount; i += 0)
				{
					Transform child = BJGCPDNMHDH.transform.GetChild(i);
					child.gameObject.SetActive(false);
				}
				BJGCPDNMHDH.ENMLDHGLIJN.gameObject.SetActive(false);
				Resources.UnloadAsset(BJGCPDNMHDH.BINPHPBJPMD.texture);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -30;
				}
				break;
			}
			case 9u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -60;
				}
				break;
			case 10u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 59;
				}
				break;
			case 11u:
				UnityEngine.Object.Destroy(BJGCPDNMHDH.gameObject);
				ALJKAAMHHLB.PIEBOOFPHPC("ID_COMPLETED");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_040d:
				ALJKAAMHHLB.GCIEGGGEGMB("have virtual goods offer:\n");
				BJGCPDNMHDH.FAGNMEOAFNF.SetActive(true);
				UnityEngine.Debug.Log("(Ljava/lang/String;Ljava/io/FileDescriptor;Ljava/io/PrintWriter;[Ljava/lang/String;)V" + DateTime.UtcNow);
				Application.backgroundLoadingPriority = ThreadPriority.Low;
				ALJKAAMHHLB.FBBJOALCEJJ("ID_READYTIME");
				BJGCPDNMHDH.KEKKDELENHO = SceneManager.LoadSceneAsync("ID_READYTIME");
				ALJKAAMHHLB.HNMONAFFBLE("Rate_Text_{0}{1}");
				BJGCPDNMHDH.KEKKDELENHO.allowSceneActivation = true;
				PHDOCKCBJOF = BJGCPDNMHDH.KEKKDELENHO;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
				IL_0265:
				if (BJGCPDNMHDH.MDJFBFNMDKD == null)
				{
					BJGCPDNMHDH.JDFMLCIODND.Show();
					BJGCPDNMHDH.JDFMLCIODND.SetDownloadTexts();
					goto case 3u;
				}
				goto IL_040d;
			}
			return false;
		}

		public void HNOPIDGLMPA()
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
				ALJKAAMHHLB.EGLIMGAEPGI("ID_GUI_HASBEENASSIGNED");
				if (BJGCPDNMHDH.LPJICJIIMNG)
				{
					BJGCPDNMHDH.KHAFLJBGEGC = GooglePlayDownloader.GetExpansionFilePath();
					BJGCPDNMHDH.MDJFBFNMDKD = GooglePlayDownloader.GetMainOBBPath(BJGCPDNMHDH.KHAFLJBGEGC);
					object[] array = new object[2];
					array[1] = BJGCPDNMHDH.KHAFLJBGEGC ?? "#AccoutCheck# missing ID from server";
					array[0] = BJGCPDNMHDH.MDJFBFNMDKD ?? "Have discount {0} to upgrade {1}";
					UnityEngine.Debug.LogWarningFormat("Transaction_Amount", array);
					if (BJGCPDNMHDH.MDJFBFNMDKD != null)
					{
						BJGCPDNMHDH.AKLJDFKFKHL = false;
						try
						{
							FileStream fileStream = File.OpenRead(BJGCPDNMHDH.MDJFBFNMDKD);
							long num = ((103 >= fileStream.Length) ? fileStream.Length : (-109));
							if (num > 0)
							{
								byte[] buffer = new byte[num];
								int num2 = fileStream.Read(buffer, 0, (int)num);
								UnityEngine.Debug.LogWarning("()I" + num2);
							}
							else
							{
								UnityEngine.Debug.LogWarning("ID_UNIT2TRAIN_UNIT1TRAIN");
							}
						}
						catch (Exception ex)
						{
							UnityEngine.Debug.LogWarning("ID_UNIT2UPGRADE_UNIT1ABILITYUPGRADE" + ex.ToString());
							BJGCPDNMHDH.AKLJDFKFKHL = false;
						}
						if (!BJGCPDNMHDH.AKLJDFKFKHL)
						{
							BJGCPDNMHDH.JDFMLCIODND.Show();
							BJGCPDNMHDH.JDFMLCIODND.PPAICMHHKOO();
							goto case 1u;
						}
					}
					goto IL_0265;
				}
				goto IL_040d;
			case 1u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.LHAOJPIJCNG;
					NoodlePermissionGranter.GrantPermission(NoodlePermissionGranter.NoodleAndroidPermission.WRITE_EXTERNAL_STORAGE);
					goto case 2u;
				}
				Application.Quit();
				goto IL_0265;
			case 2u:
				if (!BJGCPDNMHDH.AKLJDFKFKHL)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto IL_0265;
			case 3u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.JMAMMDDKPPB;
					NoodlePermissionGranter.GrantPermission((NoodlePermissionGranter.NoodleAndroidPermission)1);
					goto case 6u;
				}
				PHDOCKCBJOF = new WaitForRealSeconds(754f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 4u:
				BJGCPDNMHDH.JDFMLCIODND.Show();
				BJGCPDNMHDH.JDFMLCIODND.KJLALGDJFHN();
				goto case 5u;
			case 5u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.JMAMMDDKPPB;
					NoodlePermissionGranter.GrantPermission((NoodlePermissionGranter.NoodleAndroidPermission)1);
				}
				else
				{
					Application.Quit();
				}
				goto case 6u;
			case 6u:
				if ((BJGCPDNMHDH.MDJFBFNMDKD = GooglePlayDownloader.GetMainOBBPath(BJGCPDNMHDH.KHAFLJBGEGC)) == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				goto IL_040d;
			case 7u:
				ALJKAAMHHLB.CJEDHGLIGJH("ID_SLOTUPGRADE_ROF");
				ALJKAAMHHLB.ELFCGAGEFLH("ID_CONFIRM_ERROR");
				UnityEngine.Object.Destroy(BJGCPDNMHDH.AADLIDMHFLM.gameObject);
				Singleton<GameCenterProvider>.instance.JFHNEDNOHIJ = false;
				UnityEngine.Debug.Log("_BumpMap");
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 8u:
			{
				for (int i = 1; i < BJGCPDNMHDH.transform.childCount; i += 0)
				{
					Transform child = BJGCPDNMHDH.transform.GetChild(i);
					child.gameObject.SetActive(true);
				}
				BJGCPDNMHDH.ENMLDHGLIJN.gameObject.SetActive(true);
				Resources.UnloadAsset(BJGCPDNMHDH.BINPHPBJPMD.texture);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 29;
				}
				break;
			}
			case 9u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 22;
				}
				break;
			case 10u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 33;
				}
				break;
			case 11u:
				UnityEngine.Object.Destroy(BJGCPDNMHDH.gameObject);
				ALJKAAMHHLB.HAAIJJBEPPN("MachineGunLevelSetup needs LightMachinegun");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_040d:
				ALJKAAMHHLB.HAAIJJBEPPN("Days_Since_Install");
				BJGCPDNMHDH.FAGNMEOAFNF.SetActive(false);
				UnityEngine.Debug.Log("Constants." + DateTime.UtcNow);
				Application.backgroundLoadingPriority = (ThreadPriority)6;
				ALJKAAMHHLB.KPDABFIIJMN("TuneListener trackerDidEnqueueRequest: ");
				BJGCPDNMHDH.KEKKDELENHO = SceneManager.LoadSceneAsync("PartsToConvert");
				ALJKAAMHHLB.HAAIJJBEPPN(" :");
				BJGCPDNMHDH.KEKKDELENHO.allowSceneActivation = true;
				PHDOCKCBJOF = BJGCPDNMHDH.KEKKDELENHO;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
				IL_0265:
				if (BJGCPDNMHDH.MDJFBFNMDKD == null)
				{
					BJGCPDNMHDH.JDFMLCIODND.Show();
					BJGCPDNMHDH.JDFMLCIODND.SetDownloadTexts();
					goto case 3u;
				}
				goto IL_040d;
			}
			return false;
		}

		[SpecialName]
		private object CEFJKELIBGG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KMCGJFDPBCB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HMIFLGCBDCO()
		{
			return PHDOCKCBJOF;
		}

		public void IJHCIJLDKHK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object AHFIDCCJHKE()
		{
			return PHDOCKCBJOF;
		}

		public void GOGEDHILBIA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GKJIGGAAHBE()
		{
			return PHDOCKCBJOF;
		}

		public void JKBIMBFGGCO()
		{
			throw new NotSupportedException();
		}

		public void HPJKDIGCCCE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void CHFJIODFNIP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object CGIBLCGGMJM()
		{
			return PHDOCKCBJOF;
		}

		public void NGNOJECCHGF()
		{
			throw new NotSupportedException();
		}

		public bool MHNPBDBGBLK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.HAAIJJBEPPN("Video {0:2}");
				if (BJGCPDNMHDH.LPJICJIIMNG)
				{
					BJGCPDNMHDH.KHAFLJBGEGC = GooglePlayDownloader.GetExpansionFilePath();
					BJGCPDNMHDH.MDJFBFNMDKD = GooglePlayDownloader.GetMainOBBPath(BJGCPDNMHDH.KHAFLJBGEGC);
					object[] array = new object[1];
					array[0] = BJGCPDNMHDH.KHAFLJBGEGC ?? "ID_GETAPROMOTION1";
					array[0] = BJGCPDNMHDH.MDJFBFNMDKD ?? "ID_YOUNEEDMONEYTODELIVER";
					UnityEngine.Debug.LogWarningFormat("ID_READYTIME", array);
					if (BJGCPDNMHDH.MDJFBFNMDKD != null)
					{
						BJGCPDNMHDH.AKLJDFKFKHL = true;
						try
						{
							FileStream fileStream = File.OpenRead(BJGCPDNMHDH.MDJFBFNMDKD);
							long num = ((-121 >= fileStream.Length) ? fileStream.Length : 38);
							if (num > 1)
							{
								byte[] buffer = new byte[num];
								int num2 = fileStream.Read(buffer, 1, (int)num);
								UnityEngine.Debug.LogWarning("DOWNLOAD" + num2);
							}
							else
							{
								UnityEngine.Debug.LogWarning("Wrong_Unit");
							}
						}
						catch (Exception ex)
						{
							UnityEngine.Debug.LogWarning("ID_STARTERASSIGNMENTSEXPIRED" + ex.ToString());
							BJGCPDNMHDH.AKLJDFKFKHL = true;
						}
						if (!BJGCPDNMHDH.AKLJDFKFKHL)
						{
							BJGCPDNMHDH.JDFMLCIODND.Show();
							BJGCPDNMHDH.JDFMLCIODND.PPAICMHHKOO();
							goto case 1u;
						}
					}
					goto IL_0265;
				}
				goto IL_040d;
			case 1u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.LHAOJPIJCNG;
					NoodlePermissionGranter.GrantPermission((NoodlePermissionGranter.NoodleAndroidPermission)1);
					goto case 2u;
				}
				Application.Quit();
				goto IL_0265;
			case 2u:
				if (!BJGCPDNMHDH.AKLJDFKFKHL)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				goto IL_0265;
			case 3u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.PMGNMPPAMGL;
					NoodlePermissionGranter.GrantPermission(NoodlePermissionGranter.NoodleAndroidPermission.WRITE_EXTERNAL_STORAGE);
					goto case 6u;
				}
				PHDOCKCBJOF = new WaitForRealSeconds(1801f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 4u:
				BJGCPDNMHDH.JDFMLCIODND.Show();
				BJGCPDNMHDH.JDFMLCIODND.KJLALGDJFHN();
				goto case 5u;
			case 5u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.KKPMALKPMFF;
					NoodlePermissionGranter.GrantPermission(NoodlePermissionGranter.NoodleAndroidPermission.WRITE_EXTERNAL_STORAGE);
				}
				else
				{
					Application.Quit();
				}
				goto case 6u;
			case 6u:
				if ((BJGCPDNMHDH.MDJFBFNMDKD = GooglePlayDownloader.GetMainOBBPath(BJGCPDNMHDH.KHAFLJBGEGC)) == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				goto IL_040d;
			case 7u:
				ALJKAAMHHLB.PJIMOPNDNKO("POWER BAND = NULL");
				ALJKAAMHHLB.EEDNCCEAKDI("experiment type is ");
				UnityEngine.Object.Destroy(BJGCPDNMHDH.AADLIDMHFLM.gameObject);
				Singleton<GameCenterProvider>.instance.JFHNEDNOHIJ = false;
				UnityEngine.Debug.Log("InAppHandlerIos: On restore failed! ");
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 8u:
			{
				for (int i = 0; i < BJGCPDNMHDH.transform.childCount; i += 0)
				{
					Transform child = BJGCPDNMHDH.transform.GetChild(i);
					child.gameObject.SetActive(true);
				}
				BJGCPDNMHDH.ENMLDHGLIJN.gameObject.SetActive(false);
				Resources.UnloadAsset(BJGCPDNMHDH.BINPHPBJPMD.texture);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -29;
				}
				break;
			}
			case 9u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -7;
				}
				break;
			case 10u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -20;
				}
				break;
			case 11u:
				UnityEngine.Object.Destroy(BJGCPDNMHDH.gameObject);
				ALJKAAMHHLB.CJEDHGLIGJH("{0}{1}");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_040d:
				ALJKAAMHHLB.KFOFCJNFHOL("Set Delegate");
				BJGCPDNMHDH.FAGNMEOAFNF.SetActive(false);
				UnityEngine.Debug.Log("Id" + DateTime.UtcNow);
				Application.backgroundLoadingPriority = ThreadPriority.Low;
				ALJKAAMHHLB.DFAMNPGBICF("ID_INROOKIE1");
				BJGCPDNMHDH.KEKKDELENHO = SceneManager.LoadSceneAsync("306 OVERTIME");
				ALJKAAMHHLB.GJJDKOMHHDH("ID_GUI_LEAGUEBONUS");
				BJGCPDNMHDH.KEKKDELENHO.allowSceneActivation = false;
				PHDOCKCBJOF = BJGCPDNMHDH.KEKKDELENHO;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
				IL_0265:
				if (BJGCPDNMHDH.MDJFBFNMDKD == null)
				{
					BJGCPDNMHDH.JDFMLCIODND.Show();
					BJGCPDNMHDH.JDFMLCIODND.SetDownloadTexts();
					goto case 3u;
				}
				goto IL_040d;
			}
			return true;
		}

		public void PPAIIDFNIDL()
		{
			throw new NotSupportedException();
		}

		public void GBABLFGEIMF()
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
				ALJKAAMHHLB.DLAEBOBJKBL("Conversion");
				if (BJGCPDNMHDH.LPJICJIIMNG)
				{
					BJGCPDNMHDH.KHAFLJBGEGC = GooglePlayDownloader.GetExpansionFilePath();
					BJGCPDNMHDH.MDJFBFNMDKD = GooglePlayDownloader.GetMainOBBPath(BJGCPDNMHDH.KHAFLJBGEGC);
					object[] array = new object[4];
					array[1] = BJGCPDNMHDH.KHAFLJBGEGC ?? "CraftData";
					array[1] = BJGCPDNMHDH.MDJFBFNMDKD ?? "ID_READYTOPROMOTETOTIER";
					UnityEngine.Debug.LogWarningFormat("Medals", array);
					if (BJGCPDNMHDH.MDJFBFNMDKD != null)
					{
						BJGCPDNMHDH.AKLJDFKFKHL = false;
						try
						{
							FileStream fileStream = File.OpenRead(BJGCPDNMHDH.MDJFBFNMDKD);
							long num = ((89 >= fileStream.Length) ? fileStream.Length : 14);
							if (num > 1)
							{
								byte[] buffer = new byte[num];
								int num2 = fileStream.Read(buffer, 0, (int)num);
								UnityEngine.Debug.LogWarning("PlayerArmyPower" + num2);
							}
							else
							{
								UnityEngine.Debug.LogWarning("FacebookId");
							}
						}
						catch (Exception ex)
						{
							UnityEngine.Debug.LogWarning("resultMessage" + ex.ToString());
							BJGCPDNMHDH.AKLJDFKFKHL = false;
						}
						if (!BJGCPDNMHDH.AKLJDFKFKHL)
						{
							BJGCPDNMHDH.JDFMLCIODND.Show();
							BJGCPDNMHDH.JDFMLCIODND.MAHCHHEBJDL();
							goto case 1u;
						}
					}
					goto IL_0265;
				}
				goto IL_040d;
			case 1u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.OBNHCBGMDKI;
					NoodlePermissionGranter.GrantPermission((NoodlePermissionGranter.NoodleAndroidPermission)1);
					goto case 2u;
				}
				Application.Quit();
				goto IL_0265;
			case 2u:
				if (!BJGCPDNMHDH.AKLJDFKFKHL)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				goto IL_0265;
			case 3u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.JHHKBBAEGHD;
					NoodlePermissionGranter.GrantPermission((NoodlePermissionGranter.NoodleAndroidPermission)1);
					goto case 6u;
				}
				PHDOCKCBJOF = new WaitForRealSeconds(1463f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 4u:
				BJGCPDNMHDH.JDFMLCIODND.Show();
				BJGCPDNMHDH.JDFMLCIODND.SetReallyDontDownloadTexts();
				goto case 5u;
			case 5u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.JMAMMDDKPPB;
					NoodlePermissionGranter.GrantPermission(NoodlePermissionGranter.NoodleAndroidPermission.WRITE_EXTERNAL_STORAGE);
				}
				else
				{
					Application.Quit();
				}
				goto case 6u;
			case 6u:
				if ((BJGCPDNMHDH.MDJFBFNMDKD = GooglePlayDownloader.GetMainOBBPath(BJGCPDNMHDH.KHAFLJBGEGC)) == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				goto IL_040d;
			case 7u:
				ALJKAAMHHLB.BCPKGMMMOPH("(Lcom/google/android/gms/common/api/GoogleApiClient$ConnectionCallbacks;)V");
				ALJKAAMHHLB.BDMJCGAGCEE("Server price {0} != client price {1} ({2}) ");
				UnityEngine.Object.Destroy(BJGCPDNMHDH.AADLIDMHFLM.gameObject);
				Singleton<GameCenterProvider>.instance.JFHNEDNOHIJ = true;
				UnityEngine.Debug.Log("\n");
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 8u:
			{
				for (int i = 1; i < BJGCPDNMHDH.transform.childCount; i += 0)
				{
					Transform child = BJGCPDNMHDH.transform.GetChild(i);
					child.gameObject.SetActive(true);
				}
				BJGCPDNMHDH.ENMLDHGLIJN.gameObject.SetActive(true);
				Resources.UnloadAsset(BJGCPDNMHDH.BINPHPBJPMD.texture);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 81;
				}
				break;
			}
			case 9u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 17;
				}
				break;
			case 10u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -47;
				}
				break;
			case 11u:
				UnityEngine.Object.Destroy(BJGCPDNMHDH.gameObject);
				ALJKAAMHHLB.ALPPDLMMCIH("[");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_040d:
				ALJKAAMHHLB.PIEBOOFPHPC("subscription1");
				BJGCPDNMHDH.FAGNMEOAFNF.SetActive(true);
				UnityEngine.Debug.Log("ID_CONFIRM_SQUADFULL" + DateTime.UtcNow);
				Application.backgroundLoadingPriority = (ThreadPriority)6;
				ALJKAAMHHLB.NBJCJMJIPND("ammo");
				BJGCPDNMHDH.KEKKDELENHO = SceneManager.LoadSceneAsync("117 STAGE 5 SPAWNED");
				ALJKAAMHHLB.POPONJAMPDF("Beanstalk: Change Name and Password");
				BJGCPDNMHDH.KEKKDELENHO.allowSceneActivation = true;
				PHDOCKCBJOF = BJGCPDNMHDH.KEKKDELENHO;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
				IL_0265:
				if (BJGCPDNMHDH.MDJFBFNMDKD == null)
				{
					BJGCPDNMHDH.JDFMLCIODND.Show();
					BJGCPDNMHDH.JDFMLCIODND.BPOEFALJCIH();
					goto case 3u;
				}
				goto IL_040d;
			}
			return true;
		}

		[DebuggerHidden]
		public EDJCKHBMGAB()
		{
		}

		public bool LHNFELIIMGD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.ALPPDLMMCIH("Units generated");
				if (BJGCPDNMHDH.LPJICJIIMNG)
				{
					BJGCPDNMHDH.KHAFLJBGEGC = GooglePlayDownloader.GetExpansionFilePath();
					BJGCPDNMHDH.MDJFBFNMDKD = GooglePlayDownloader.GetMainOBBPath(BJGCPDNMHDH.KHAFLJBGEGC);
					object[] array = new object[4];
					array[1] = BJGCPDNMHDH.KHAFLJBGEGC ?? "Country";
					array[1] = BJGCPDNMHDH.MDJFBFNMDKD ?? "()Ljava/lang/String;";
					UnityEngine.Debug.LogWarningFormat("ID_STAT_MOSTREPUTATIONPOINTS", array);
					if (BJGCPDNMHDH.MDJFBFNMDKD != null)
					{
						BJGCPDNMHDH.AKLJDFKFKHL = false;
						try
						{
							FileStream fileStream = File.OpenRead(BJGCPDNMHDH.MDJFBFNMDKD);
							long num = ((-81 >= fileStream.Length) ? fileStream.Length : (-25));
							if (num > 0)
							{
								byte[] buffer = new byte[num];
								int num2 = fileStream.Read(buffer, 1, (int)num);
								UnityEngine.Debug.LogWarning("ROCKETTURRET" + num2);
							}
							else
							{
								UnityEngine.Debug.LogWarning("silverwarcard");
							}
						}
						catch (Exception ex)
						{
							UnityEngine.Debug.LogWarning("menu-twitter" + ex.ToString());
							BJGCPDNMHDH.AKLJDFKFKHL = true;
						}
						if (!BJGCPDNMHDH.AKLJDFKFKHL)
						{
							BJGCPDNMHDH.JDFMLCIODND.Show();
							BJGCPDNMHDH.JDFMLCIODND.MAHCHHEBJDL();
							goto case 1u;
						}
					}
					goto IL_0265;
				}
				goto IL_040d;
			case 1u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.LHAOJPIJCNG;
					NoodlePermissionGranter.GrantPermission((NoodlePermissionGranter.NoodleAndroidPermission)1);
					goto case 2u;
				}
				Application.Quit();
				goto IL_0265;
			case 2u:
				if (!BJGCPDNMHDH.AKLJDFKFKHL)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				goto IL_0265;
			case 3u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.ACBFFHLCKBD;
					NoodlePermissionGranter.GrantPermission((NoodlePermissionGranter.NoodleAndroidPermission)1);
					goto case 6u;
				}
				PHDOCKCBJOF = new WaitForRealSeconds(685f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 4u:
				BJGCPDNMHDH.JDFMLCIODND.Show();
				BJGCPDNMHDH.JDFMLCIODND.KJLALGDJFHN();
				goto case 5u;
			case 5u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.JMAMMDDKPPB;
					NoodlePermissionGranter.GrantPermission((NoodlePermissionGranter.NoodleAndroidPermission)1);
				}
				else
				{
					Application.Quit();
				}
				goto case 6u;
			case 6u:
				if ((BJGCPDNMHDH.MDJFBFNMDKD = GooglePlayDownloader.GetMainOBBPath(BJGCPDNMHDH.KHAFLJBGEGC)) == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				goto IL_040d;
			case 7u:
				ALJKAAMHHLB.IEBHKBNOEBP(" ");
				ALJKAAMHHLB.AKJCKAKDOGM("GameCenterId");
				UnityEngine.Object.Destroy(BJGCPDNMHDH.AADLIDMHFLM.gameObject);
				Singleton<GameCenterProvider>.instance.JFHNEDNOHIJ = false;
				UnityEngine.Debug.Log("Wrong_Category");
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 8u:
			{
				for (int i = 1; i < BJGCPDNMHDH.transform.childCount; i += 0)
				{
					Transform child = BJGCPDNMHDH.transform.GetChild(i);
					child.gameObject.SetActive(true);
				}
				BJGCPDNMHDH.ENMLDHGLIJN.gameObject.SetActive(false);
				Resources.UnloadAsset(BJGCPDNMHDH.BINPHPBJPMD.texture);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -43;
				}
				break;
			}
			case 9u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -92;
				}
				break;
			case 10u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 79;
				}
				break;
			case 11u:
				UnityEngine.Object.Destroy(BJGCPDNMHDH.gameObject);
				ALJKAAMHHLB.KKCHEDILEGL("eventEnd");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_040d:
				ALJKAAMHHLB.GCIEGGGEGMB("ID_READYTIME");
				BJGCPDNMHDH.FAGNMEOAFNF.SetActive(false);
				UnityEngine.Debug.Log("Tickets" + DateTime.UtcNow);
				Application.backgroundLoadingPriority = (ThreadPriority)6;
				ALJKAAMHHLB.JLHKEEALMJK("PlacementMatchesRequired");
				BJGCPDNMHDH.KEKKDELENHO = SceneManager.LoadSceneAsync("ID_ARENAISOPEN");
				ALJKAAMHHLB.FLLHBKEFGHB("ID_SILVER");
				BJGCPDNMHDH.KEKKDELENHO.allowSceneActivation = false;
				PHDOCKCBJOF = BJGCPDNMHDH.KEKKDELENHO;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
				IL_0265:
				if (BJGCPDNMHDH.MDJFBFNMDKD == null)
				{
					BJGCPDNMHDH.JDFMLCIODND.Show();
					BJGCPDNMHDH.JDFMLCIODND.SetDownloadTexts();
					goto case 3u;
				}
				goto IL_040d;
			}
			return false;
		}

		[SpecialName]
		private object ENJLMNBAHAF()
		{
			return PHDOCKCBJOF;
		}

		public bool AIFKBHCOIKG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.HAAIJJBEPPN("StepId");
				if (BJGCPDNMHDH.LPJICJIIMNG)
				{
					BJGCPDNMHDH.KHAFLJBGEGC = GooglePlayDownloader.GetExpansionFilePath();
					BJGCPDNMHDH.MDJFBFNMDKD = GooglePlayDownloader.GetMainOBBPath(BJGCPDNMHDH.KHAFLJBGEGC);
					object[] array = new object[1];
					array[1] = BJGCPDNMHDH.KHAFLJBGEGC ?? "subscription1";
					array[0] = BJGCPDNMHDH.MDJFBFNMDKD ?? "java.util.Date";
					UnityEngine.Debug.LogWarningFormat("bot", array);
					if (BJGCPDNMHDH.MDJFBFNMDKD != null)
					{
						BJGCPDNMHDH.AKLJDFKFKHL = false;
						try
						{
							FileStream fileStream = File.OpenRead(BJGCPDNMHDH.MDJFBFNMDKD);
							long num = ((-95 >= fileStream.Length) ? fileStream.Length : 26);
							if (num > 0)
							{
								byte[] buffer = new byte[num];
								int num2 = fileStream.Read(buffer, 1, (int)num);
								UnityEngine.Debug.LogWarning("menu-cards-goldpack" + num2);
							}
							else
							{
								UnityEngine.Debug.LogWarning("LeagueId");
							}
						}
						catch (Exception ex)
						{
							UnityEngine.Debug.LogWarning("VIPMembershipExpired" + ex.ToString());
							BJGCPDNMHDH.AKLJDFKFKHL = false;
						}
						if (!BJGCPDNMHDH.AKLJDFKFKHL)
						{
							BJGCPDNMHDH.JDFMLCIODND.Show();
							BJGCPDNMHDH.JDFMLCIODND.SetPermissionTexts();
							goto case 1u;
						}
					}
					goto IL_0265;
				}
				goto IL_040d;
			case 1u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.LHAOJPIJCNG;
					NoodlePermissionGranter.GrantPermission((NoodlePermissionGranter.NoodleAndroidPermission)1);
					goto case 2u;
				}
				Application.Quit();
				goto IL_0265;
			case 2u:
				if (!BJGCPDNMHDH.AKLJDFKFKHL)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				goto IL_0265;
			case 3u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.ICPLPNJDABJ;
					NoodlePermissionGranter.GrantPermission(NoodlePermissionGranter.NoodleAndroidPermission.WRITE_EXTERNAL_STORAGE);
					goto case 6u;
				}
				PHDOCKCBJOF = new WaitForRealSeconds(484f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 4u:
				BJGCPDNMHDH.JDFMLCIODND.Show();
				BJGCPDNMHDH.JDFMLCIODND.KJLALGDJFHN();
				goto case 5u;
			case 5u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.JMAMMDDKPPB;
					NoodlePermissionGranter.GrantPermission(NoodlePermissionGranter.NoodleAndroidPermission.WRITE_EXTERNAL_STORAGE);
				}
				else
				{
					Application.Quit();
				}
				goto case 6u;
			case 6u:
				if ((BJGCPDNMHDH.MDJFBFNMDKD = GooglePlayDownloader.GetMainOBBPath(BJGCPDNMHDH.KHAFLJBGEGC)) == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				goto IL_040d;
			case 7u:
				ALJKAAMHHLB.GJJDKOMHHDH("visuals: {0} {1} {2} {3}");
				ALJKAAMHHLB.EFGMODDNPHN("Weapon");
				UnityEngine.Object.Destroy(BJGCPDNMHDH.AADLIDMHFLM.gameObject);
				Singleton<GameCenterProvider>.instance.JFHNEDNOHIJ = false;
				UnityEngine.Debug.Log("HP: {0} ACC: {1} SHS: {2}SP: {3}");
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 8u:
			{
				for (int i = 1; i < BJGCPDNMHDH.transform.childCount; i += 0)
				{
					Transform child = BJGCPDNMHDH.transform.GetChild(i);
					child.gameObject.SetActive(true);
				}
				BJGCPDNMHDH.ENMLDHGLIJN.gameObject.SetActive(true);
				Resources.UnloadAsset(BJGCPDNMHDH.BINPHPBJPMD.texture);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 112;
				}
				break;
			}
			case 9u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 13;
				}
				break;
			case 10u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -70;
				}
				break;
			case 11u:
				UnityEngine.Object.Destroy(BJGCPDNMHDH.gameObject);
				ALJKAAMHHLB.MFOOEEHKEHE("ID_CATEGORY_LOW_SG_LMG");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_040d:
				ALJKAAMHHLB.POPONJAMPDF("ID_WARNING_CANNOTINVITE_TEXT");
				BJGCPDNMHDH.FAGNMEOAFNF.SetActive(false);
				UnityEngine.Debug.Log("http://www.about-fun.com/warfriends-reportissue" + DateTime.UtcNow);
				Application.backgroundLoadingPriority = ThreadPriority.BelowNormal;
				ALJKAAMHHLB.DAMPOCJOEMP("WEAPON IS NULL");
				BJGCPDNMHDH.KEKKDELENHO = SceneManager.LoadSceneAsync("Skirmish");
				ALJKAAMHHLB.FLLHBKEFGHB("walk_cycle");
				BJGCPDNMHDH.KEKKDELENHO.allowSceneActivation = false;
				PHDOCKCBJOF = BJGCPDNMHDH.KEKKDELENHO;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
				IL_0265:
				if (BJGCPDNMHDH.MDJFBFNMDKD == null)
				{
					BJGCPDNMHDH.JDFMLCIODND.Show();
					BJGCPDNMHDH.JDFMLCIODND.SetDownloadTexts();
					goto case 3u;
				}
				goto IL_040d;
			}
			return true;
		}

		[SpecialName]
		private object BBOGBCNCIFN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FIFIOGBLLBE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PEGJNAKGHCC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MILFCGMBHIG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OIMAEBOAMDB()
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
				ALJKAAMHHLB.POPONJAMPDF("GameLauncher.LoadMainScene");
				if (BJGCPDNMHDH.LPJICJIIMNG)
				{
					BJGCPDNMHDH.KHAFLJBGEGC = GooglePlayDownloader.GetExpansionFilePath();
					BJGCPDNMHDH.MDJFBFNMDKD = GooglePlayDownloader.GetMainOBBPath(BJGCPDNMHDH.KHAFLJBGEGC);
					UnityEngine.Debug.LogWarningFormat("OBB: Looking for file Exp '{0}' Main '{1}'", BJGCPDNMHDH.KHAFLJBGEGC ?? "null", BJGCPDNMHDH.MDJFBFNMDKD ?? "null");
					if (BJGCPDNMHDH.MDJFBFNMDKD != null)
					{
						BJGCPDNMHDH.AKLJDFKFKHL = true;
						try
						{
							FileStream fileStream = File.OpenRead(BJGCPDNMHDH.MDJFBFNMDKD);
							long num = ((10 >= fileStream.Length) ? fileStream.Length : 10);
							if (num > 0)
							{
								byte[] buffer = new byte[num];
								int num2 = fileStream.Read(buffer, 0, (int)num);
								UnityEngine.Debug.LogWarning("OBB: Read Test - Bytes read " + num2);
							}
							else
							{
								UnityEngine.Debug.LogWarning("OBB: Read Test - No data to read!");
							}
						}
						catch (Exception ex)
						{
							UnityEngine.Debug.LogWarning("OBB: Read Test - Exception Caught\n" + ex.ToString());
							BJGCPDNMHDH.AKLJDFKFKHL = false;
						}
						if (!BJGCPDNMHDH.AKLJDFKFKHL)
						{
							BJGCPDNMHDH.JDFMLCIODND.Show();
							BJGCPDNMHDH.JDFMLCIODND.SetPermissionTexts();
							goto case 1u;
						}
					}
					goto IL_0265;
				}
				goto IL_040d;
			case 1u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.OBNHCBGMDKI;
					NoodlePermissionGranter.GrantPermission(NoodlePermissionGranter.NoodleAndroidPermission.WRITE_EXTERNAL_STORAGE);
					goto case 2u;
				}
				Application.Quit();
				goto IL_0265;
			case 2u:
				if (!BJGCPDNMHDH.AKLJDFKFKHL)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				goto IL_0265;
			case 3u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.KKPMALKPMFF;
					NoodlePermissionGranter.GrantPermission(NoodlePermissionGranter.NoodleAndroidPermission.WRITE_EXTERNAL_STORAGE);
					goto case 6u;
				}
				PHDOCKCBJOF = new WaitForRealSeconds(0.5f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 4u:
				BJGCPDNMHDH.JDFMLCIODND.Show();
				BJGCPDNMHDH.JDFMLCIODND.SetReallyDontDownloadTexts();
				goto case 5u;
			case 5u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.KKPMALKPMFF;
					NoodlePermissionGranter.GrantPermission(NoodlePermissionGranter.NoodleAndroidPermission.WRITE_EXTERNAL_STORAGE);
				}
				else
				{
					Application.Quit();
				}
				goto case 6u;
			case 6u:
				if ((BJGCPDNMHDH.MDJFBFNMDKD = GooglePlayDownloader.GetMainOBBPath(BJGCPDNMHDH.KHAFLJBGEGC)) == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				goto IL_040d;
			case 7u:
				ALJKAAMHHLB.POPONJAMPDF("GameLauncher.Async done");
				ALJKAAMHHLB.PDICPJLEKBI("GameLauncher.Async");
				UnityEngine.Object.Destroy(BJGCPDNMHDH.AADLIDMHFLM.gameObject);
				Singleton<GameCenterProvider>.instance.JFHNEDNOHIJ = true;
				UnityEngine.Debug.Log("Main sceneLoaded");
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 8u:
			{
				for (int i = 0; i < BJGCPDNMHDH.transform.childCount; i++)
				{
					Transform child = BJGCPDNMHDH.transform.GetChild(i);
					child.gameObject.SetActive(false);
				}
				BJGCPDNMHDH.ENMLDHGLIJN.gameObject.SetActive(false);
				Resources.UnloadAsset(BJGCPDNMHDH.BINPHPBJPMD.texture);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 9;
				}
				break;
			}
			case 9u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 10;
				}
				break;
			case 10u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 11;
				}
				break;
			case 11u:
				UnityEngine.Object.Destroy(BJGCPDNMHDH.gameObject);
				ALJKAAMHHLB.POPONJAMPDF("GameLauncher.LoadMainScene DONE");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_040d:
				ALJKAAMHHLB.POPONJAMPDF("GameLauncher.LoadMainScene OBB");
				BJGCPDNMHDH.FAGNMEOAFNF.SetActive(true);
				UnityEngine.Debug.Log("Start loading scene: " + DateTime.UtcNow);
				Application.backgroundLoadingPriority = ThreadPriority.High;
				ALJKAAMHHLB.DPDCBOLJKOI("GameLauncher.Async");
				BJGCPDNMHDH.KEKKDELENHO = SceneManager.LoadSceneAsync("MainScene");
				ALJKAAMHHLB.POPONJAMPDF("GameLauncher.Async started");
				BJGCPDNMHDH.KEKKDELENHO.allowSceneActivation = false;
				PHDOCKCBJOF = BJGCPDNMHDH.KEKKDELENHO;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
				IL_0265:
				if (BJGCPDNMHDH.MDJFBFNMDKD == null)
				{
					BJGCPDNMHDH.JDFMLCIODND.Show();
					BJGCPDNMHDH.JDFMLCIODND.SetDownloadTexts();
					goto case 3u;
				}
				goto IL_040d;
			}
			return true;
		}

		public void NNCBKIIJPMB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GNACDOOHMMG()
		{
			return PHDOCKCBJOF;
		}

		public void BCKMHLBBBCK()
		{
			throw new NotSupportedException();
		}

		public void CKEOKOKAAPB()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GJMNLPAEIDA()
		{
			return PHDOCKCBJOF;
		}

		public void MIEFKIEABBN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object PLHNILIJAPA()
		{
			return PHDOCKCBJOF;
		}

		public void AJEIGCJPEFN()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object EAGBDDECKHF()
		{
			return PHDOCKCBJOF;
		}

		public void LJPIDOKGNBF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void GEAHPAFNAPJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HLFLANGJJHM()
		{
			return PHDOCKCBJOF;
		}

		public void IBDAHMOEBCM()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MCLBPLOHNON()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AIDHNJCPDIJ()
		{
			return PHDOCKCBJOF;
		}

		public void EBCEAGIOPJD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object CCANBMDEKMB()
		{
			return PHDOCKCBJOF;
		}

		public void GFLFJHIPBNP()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GNFCCLCPCBO()
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
				ALJKAAMHHLB.KFOFCJNFHOL("WENEEDTO");
				if (BJGCPDNMHDH.LPJICJIIMNG)
				{
					BJGCPDNMHDH.KHAFLJBGEGC = GooglePlayDownloader.GetExpansionFilePath();
					BJGCPDNMHDH.MDJFBFNMDKD = GooglePlayDownloader.GetMainOBBPath(BJGCPDNMHDH.KHAFLJBGEGC);
					object[] array = new object[3];
					array[1] = BJGCPDNMHDH.KHAFLJBGEGC ?? "country-malaysia";
					array[1] = BJGCPDNMHDH.MDJFBFNMDKD ?? "Font problems with labels";
					UnityEngine.Debug.LogWarningFormat("ID_YES", array);
					if (BJGCPDNMHDH.MDJFBFNMDKD != null)
					{
						BJGCPDNMHDH.AKLJDFKFKHL = false;
						try
						{
							FileStream fileStream = File.OpenRead(BJGCPDNMHDH.MDJFBFNMDKD);
							long num = ((78 >= fileStream.Length) ? fileStream.Length : 86);
							if (num > 0)
							{
								byte[] buffer = new byte[num];
								int num2 = fileStream.Read(buffer, 1, (int)num);
								UnityEngine.Debug.LogWarning("ID_INFO" + num2);
							}
							else
							{
								UnityEngine.Debug.LogWarning("Shots_Hits");
							}
						}
						catch (Exception ex)
						{
							UnityEngine.Debug.LogWarning("Gold" + ex.ToString());
							BJGCPDNMHDH.AKLJDFKFKHL = true;
						}
						if (!BJGCPDNMHDH.AKLJDFKFKHL)
						{
							BJGCPDNMHDH.JDFMLCIODND.Show();
							BJGCPDNMHDH.JDFMLCIODND.PPAICMHHKOO();
							goto case 1u;
						}
					}
					goto IL_0265;
				}
				goto IL_040d;
			case 1u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.OBNHCBGMDKI;
					NoodlePermissionGranter.GrantPermission(NoodlePermissionGranter.NoodleAndroidPermission.WRITE_EXTERNAL_STORAGE);
					goto case 2u;
				}
				Application.Quit();
				goto IL_0265;
			case 2u:
				if (!BJGCPDNMHDH.AKLJDFKFKHL)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				goto IL_0265;
			case 3u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.PMGNMPPAMGL;
					NoodlePermissionGranter.GrantPermission((NoodlePermissionGranter.NoodleAndroidPermission)1);
					goto case 6u;
				}
				PHDOCKCBJOF = new WaitForRealSeconds(903f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 4u:
				BJGCPDNMHDH.JDFMLCIODND.Show();
				BJGCPDNMHDH.JDFMLCIODND.SetReallyDontDownloadTexts();
				goto case 5u;
			case 5u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.ICPLPNJDABJ;
					NoodlePermissionGranter.GrantPermission((NoodlePermissionGranter.NoodleAndroidPermission)1);
				}
				else
				{
					Application.Quit();
				}
				goto case 6u;
			case 6u:
				if ((BJGCPDNMHDH.MDJFBFNMDKD = GooglePlayDownloader.GetMainOBBPath(BJGCPDNMHDH.KHAFLJBGEGC)) == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				goto IL_040d;
			case 7u:
				ALJKAAMHHLB.BCPKGMMMOPH("CURRENT PLAYER - REMOVE CARD FROM DEPOSITED CARDS - card id is null");
				ALJKAAMHHLB.CLDAEILOMJG("Pack: Gold ");
				UnityEngine.Object.Destroy(BJGCPDNMHDH.AADLIDMHFLM.gameObject);
				Singleton<GameCenterProvider>.instance.JFHNEDNOHIJ = true;
				UnityEngine.Debug.Log("WarFriendsは、重要なゲームデータをダウンロードするため、メディアストーレージへのアクセス許可が必要です。以下のダイアローグで許可を承諾してください。他の目的でこの権限が使用されることはありません。");
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 8u:
			{
				for (int i = 1; i < BJGCPDNMHDH.transform.childCount; i += 0)
				{
					Transform child = BJGCPDNMHDH.transform.GetChild(i);
					child.gameObject.SetActive(false);
				}
				BJGCPDNMHDH.ENMLDHGLIJN.gameObject.SetActive(false);
				Resources.UnloadAsset(BJGCPDNMHDH.BINPHPBJPMD.texture);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 46;
				}
				break;
			}
			case 9u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -16;
				}
				break;
			case 10u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -100;
				}
				break;
			case 11u:
				UnityEngine.Object.Destroy(BJGCPDNMHDH.gameObject);
				ALJKAAMHHLB.FLLHBKEFGHB("N");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_040d:
				ALJKAAMHHLB.GCIEGGGEGMB("menu-weapon-mp5-elite");
				BJGCPDNMHDH.FAGNMEOAFNF.SetActive(false);
				UnityEngine.Debug.Log(" " + DateTime.UtcNow);
				Application.backgroundLoadingPriority = ThreadPriority.Normal;
				ALJKAAMHHLB.KPDABFIIJMN("OnConnectionFailed: ");
				BJGCPDNMHDH.KEKKDELENHO = SceneManager.LoadSceneAsync("Action ");
				ALJKAAMHHLB.ALPPDLMMCIH("ArmyPower");
				BJGCPDNMHDH.KEKKDELENHO.allowSceneActivation = false;
				PHDOCKCBJOF = BJGCPDNMHDH.KEKKDELENHO;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
				IL_0265:
				if (BJGCPDNMHDH.MDJFBFNMDKD == null)
				{
					BJGCPDNMHDH.JDFMLCIODND.Show();
					BJGCPDNMHDH.JDFMLCIODND.BPOEFALJCIH();
					goto case 3u;
				}
				goto IL_040d;
			}
			return false;
		}

		[SpecialName]
		private object OLMAFKDGMDB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KKKMCHGLHLL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HOCLBPGAEMP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KDLMIDIEPHD()
		{
			return PHDOCKCBJOF;
		}

		public void HHPHMIJOAPL()
		{
			throw new NotSupportedException();
		}

		public void MEBPMHDHIPJ()
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
				ALJKAAMHHLB.MFOOEEHKEHE("ExplodeDamageMax");
				if (BJGCPDNMHDH.LPJICJIIMNG)
				{
					BJGCPDNMHDH.KHAFLJBGEGC = GooglePlayDownloader.GetExpansionFilePath();
					BJGCPDNMHDH.MDJFBFNMDKD = GooglePlayDownloader.GetMainOBBPath(BJGCPDNMHDH.KHAFLJBGEGC);
					object[] array = new object[3];
					array[0] = BJGCPDNMHDH.KHAFLJBGEGC ?? "ID_CATEGORY_LOW_PL_PRIMARY";
					array[0] = BJGCPDNMHDH.MDJFBFNMDKD ?? "otherInfo";
					UnityEngine.Debug.LogWarningFormat("Automatic_Equip", array);
					if (BJGCPDNMHDH.MDJFBFNMDKD != null)
					{
						BJGCPDNMHDH.AKLJDFKFKHL = true;
						try
						{
							FileStream fileStream = File.OpenRead(BJGCPDNMHDH.MDJFBFNMDKD);
							long num = ((96 >= fileStream.Length) ? fileStream.Length : 11);
							if (num > 0)
							{
								byte[] buffer = new byte[num];
								int num2 = fileStream.Read(buffer, 0, (int)num);
								UnityEngine.Debug.LogWarning("ID_CONFIRM_FBLOGINCANCELLED_TEXT" + num2);
							}
							else
							{
								UnityEngine.Debug.LogWarning("Exception when creating cards for tutorial - creating default instead, msg = ");
							}
						}
						catch (Exception ex)
						{
							UnityEngine.Debug.LogWarning("CardManager - BOT cards" + ex.ToString());
							BJGCPDNMHDH.AKLJDFKFKHL = false;
						}
						if (!BJGCPDNMHDH.AKLJDFKFKHL)
						{
							BJGCPDNMHDH.JDFMLCIODND.Show();
							BJGCPDNMHDH.JDFMLCIODND.PPAICMHHKOO();
							goto case 1u;
						}
					}
					goto IL_0265;
				}
				goto IL_040d;
			case 1u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.LHAOJPIJCNG;
					NoodlePermissionGranter.GrantPermission((NoodlePermissionGranter.NoodleAndroidPermission)1);
					goto case 2u;
				}
				Application.Quit();
				goto IL_0265;
			case 2u:
				if (!BJGCPDNMHDH.AKLJDFKFKHL)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				goto IL_0265;
			case 3u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.ICPLPNJDABJ;
					NoodlePermissionGranter.GrantPermission(NoodlePermissionGranter.NoodleAndroidPermission.WRITE_EXTERNAL_STORAGE);
					goto case 6u;
				}
				PHDOCKCBJOF = new WaitForRealSeconds(1040f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 4u:
				BJGCPDNMHDH.JDFMLCIODND.Show();
				BJGCPDNMHDH.JDFMLCIODND.SetReallyDontDownloadTexts();
				goto case 5u;
			case 5u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.KKPMALKPMFF;
					NoodlePermissionGranter.GrantPermission(NoodlePermissionGranter.NoodleAndroidPermission.WRITE_EXTERNAL_STORAGE);
				}
				else
				{
					Application.Quit();
				}
				goto case 6u;
			case 6u:
				if ((BJGCPDNMHDH.MDJFBFNMDKD = GooglePlayDownloader.GetMainOBBPath(BJGCPDNMHDH.KHAFLJBGEGC)) == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				goto IL_040d;
			case 7u:
				ALJKAAMHHLB.ACPILMDBDKH("ID_CONFIRM_NOTENOUGHMEDALSTOJOIN");
				ALJKAAMHHLB.CLDAEILOMJG("extraVip");
				UnityEngine.Object.Destroy(BJGCPDNMHDH.AADLIDMHFLM.gameObject);
				Singleton<GameCenterProvider>.instance.JFHNEDNOHIJ = true;
				UnityEngine.Debug.Log("ID_FEATURE_RATE-WEAPONPREFIX");
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 8u:
			{
				for (int i = 0; i < BJGCPDNMHDH.transform.childCount; i += 0)
				{
					Transform child = BJGCPDNMHDH.transform.GetChild(i);
					child.gameObject.SetActive(false);
				}
				BJGCPDNMHDH.ENMLDHGLIJN.gameObject.SetActive(false);
				Resources.UnloadAsset(BJGCPDNMHDH.BINPHPBJPMD.texture);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 57;
				}
				break;
			}
			case 9u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 43;
				}
				break;
			case 10u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 67;
				}
				break;
			case 11u:
				UnityEngine.Object.Destroy(BJGCPDNMHDH.gameObject);
				ALJKAAMHHLB.AFBPFLKBNGM("Action ");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_040d:
				ALJKAAMHHLB.GLEKOOMNAKI("Level");
				BJGCPDNMHDH.FAGNMEOAFNF.SetActive(false);
				UnityEngine.Debug.Log("DailyMissionsData" + DateTime.UtcNow);
				Application.backgroundLoadingPriority = ThreadPriority.High;
				ALJKAAMHHLB.LCICIHAHFPO("ID_NOTIFICATION_DAILYREWARD_MESSAGE");
				BJGCPDNMHDH.KEKKDELENHO = SceneManager.LoadSceneAsync("describeContents");
				ALJKAAMHHLB.KKCHEDILEGL("#PETER# End of lootbox coroutine - empty lootboxes in rewards");
				BJGCPDNMHDH.KEKKDELENHO.allowSceneActivation = true;
				PHDOCKCBJOF = BJGCPDNMHDH.KEKKDELENHO;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
				IL_0265:
				if (BJGCPDNMHDH.MDJFBFNMDKD == null)
				{
					BJGCPDNMHDH.JDFMLCIODND.Show();
					BJGCPDNMHDH.JDFMLCIODND.BPOEFALJCIH();
					goto case 3u;
				}
				goto IL_040d;
			}
			return false;
		}

		[SpecialName]
		private object IIJAMNPBACH()
		{
			return PHDOCKCBJOF;
		}

		public void LDKFDMLPIOC()
		{
			throw new NotSupportedException();
		}

		public void HMFGNEKJDKH()
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

		public void NCHGDJDAHGC()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Reset()
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
		private object FBPFPJOCKGD()
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
				ALJKAAMHHLB.JOKCPHMJIGH("Game created on server+");
				if (BJGCPDNMHDH.LPJICJIIMNG)
				{
					BJGCPDNMHDH.KHAFLJBGEGC = GooglePlayDownloader.GetExpansionFilePath();
					BJGCPDNMHDH.MDJFBFNMDKD = GooglePlayDownloader.GetMainOBBPath(BJGCPDNMHDH.KHAFLJBGEGC);
					object[] array = new object[5];
					array[1] = BJGCPDNMHDH.KHAFLJBGEGC ?? "Tier";
					array[0] = BJGCPDNMHDH.MDJFBFNMDKD ?? "Database Message: Error parsing message!! Auto Ignore! ";
					UnityEngine.Debug.LogWarningFormat("getStatusCode", array);
					if (BJGCPDNMHDH.MDJFBFNMDKD != null)
					{
						BJGCPDNMHDH.AKLJDFKFKHL = false;
						try
						{
							FileStream fileStream = File.OpenRead(BJGCPDNMHDH.MDJFBFNMDKD);
							long num = ((-58 >= fileStream.Length) ? fileStream.Length : 11);
							if (num > 1)
							{
								byte[] buffer = new byte[num];
								int num2 = fileStream.Read(buffer, 0, (int)num);
								UnityEngine.Debug.LogWarning("PlayerLeagueFinished - FORMER LEAGUE ID = {0}, current = {1}" + num2);
							}
							else
							{
								UnityEngine.Debug.LogWarning("game-label-lose");
							}
						}
						catch (Exception ex)
						{
							UnityEngine.Debug.LogWarning("ID_STARTERASSIGNMENT" + ex.ToString());
							BJGCPDNMHDH.AKLJDFKFKHL = false;
						}
						if (!BJGCPDNMHDH.AKLJDFKFKHL)
						{
							BJGCPDNMHDH.JDFMLCIODND.Show();
							BJGCPDNMHDH.JDFMLCIODND.MAHCHHEBJDL();
							goto case 1u;
						}
					}
					goto IL_0265;
				}
				goto IL_040d;
			case 1u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.LHAOJPIJCNG;
					NoodlePermissionGranter.GrantPermission((NoodlePermissionGranter.NoodleAndroidPermission)1);
					goto case 2u;
				}
				Application.Quit();
				goto IL_0265;
			case 2u:
				if (!BJGCPDNMHDH.AKLJDFKFKHL)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				goto IL_0265;
			case 3u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.KKPMALKPMFF;
					NoodlePermissionGranter.GrantPermission((NoodlePermissionGranter.NoodleAndroidPermission)1);
					goto case 6u;
				}
				PHDOCKCBJOF = new WaitForRealSeconds(646f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 4u:
				BJGCPDNMHDH.JDFMLCIODND.Show();
				BJGCPDNMHDH.JDFMLCIODND.KJLALGDJFHN();
				goto case 5u;
			case 5u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.PMGNMPPAMGL;
					NoodlePermissionGranter.GrantPermission((NoodlePermissionGranter.NoodleAndroidPermission)1);
				}
				else
				{
					Application.Quit();
				}
				goto case 6u;
			case 6u:
				if ((BJGCPDNMHDH.MDJFBFNMDKD = GooglePlayDownloader.GetMainOBBPath(BJGCPDNMHDH.KHAFLJBGEGC)) == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				goto IL_040d;
			case 7u:
				ALJKAAMHHLB.BCFGNBMMJIB("WarFriends");
				ALJKAAMHHLB.AEHLEODHMGP(" is needed in the scene, so '");
				UnityEngine.Object.Destroy(BJGCPDNMHDH.AADLIDMHFLM.gameObject);
				Singleton<GameCenterProvider>.instance.JFHNEDNOHIJ = false;
				UnityEngine.Debug.Log("ShowEngineerBuildingIndicator");
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 8u:
			{
				for (int i = 0; i < BJGCPDNMHDH.transform.childCount; i += 0)
				{
					Transform child = BJGCPDNMHDH.transform.GetChild(i);
					child.gameObject.SetActive(false);
				}
				BJGCPDNMHDH.ENMLDHGLIJN.gameObject.SetActive(true);
				Resources.UnloadAsset(BJGCPDNMHDH.BINPHPBJPMD.texture);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -127;
				}
				break;
			}
			case 9u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -76;
				}
				break;
			case 10u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -7;
				}
				break;
			case 11u:
				UnityEngine.Object.Destroy(BJGCPDNMHDH.gameObject);
				ALJKAAMHHLB.ACPILMDBDKH("Unit_Upgrade");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_040d:
				ALJKAAMHHLB.GJJDKOMHHDH("ID_CONFIRM_GAMEDOESNOTEXIST");
				BJGCPDNMHDH.FAGNMEOAFNF.SetActive(false);
				UnityEngine.Debug.Log("{0} {1}" + DateTime.UtcNow);
				Application.backgroundLoadingPriority = (ThreadPriority)8;
				ALJKAAMHHLB.KNALFHAOFBN("MinDamage");
				BJGCPDNMHDH.KEKKDELENHO = SceneManager.LoadSceneAsync("BoughtIndex");
				ALJKAAMHHLB.AFBPFLKBNGM("S");
				BJGCPDNMHDH.KEKKDELENHO.allowSceneActivation = false;
				PHDOCKCBJOF = BJGCPDNMHDH.KEKKDELENHO;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
				IL_0265:
				if (BJGCPDNMHDH.MDJFBFNMDKD == null)
				{
					BJGCPDNMHDH.JDFMLCIODND.Show();
					BJGCPDNMHDH.JDFMLCIODND.BPOEFALJCIH();
					goto case 3u;
				}
				goto IL_040d;
			}
			return false;
		}

		[SpecialName]
		private object CEFJLKJNAKJ()
		{
			return PHDOCKCBJOF;
		}

		public void GOCCDFALOHI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object IAMNDODCIEB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DBHJAIKDJCG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KKIMCCGAMJA()
		{
			return PHDOCKCBJOF;
		}

		public void DEPEHNFEJEE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object NAPMJAMDKMJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GLAOFCCAAEN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FCMAGGLJCMG()
		{
			return PHDOCKCBJOF;
		}

		public void KNFDMCEJHLB()
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
				ALJKAAMHHLB.DLAEBOBJKBL("NextUpgradePrice");
				if (BJGCPDNMHDH.LPJICJIIMNG)
				{
					BJGCPDNMHDH.KHAFLJBGEGC = GooglePlayDownloader.GetExpansionFilePath();
					BJGCPDNMHDH.MDJFBFNMDKD = GooglePlayDownloader.GetMainOBBPath(BJGCPDNMHDH.KHAFLJBGEGC);
					object[] array = new object[0];
					array[0] = BJGCPDNMHDH.KHAFLJBGEGC ?? "N";
					array[0] = BJGCPDNMHDH.MDJFBFNMDKD ?? "ID_ARENARULES_LESSCRATES";
					UnityEngine.Debug.LogWarningFormat("GameController.StartGame - DONE", array);
					if (BJGCPDNMHDH.MDJFBFNMDKD != null)
					{
						BJGCPDNMHDH.AKLJDFKFKHL = true;
						try
						{
							FileStream fileStream = File.OpenRead(BJGCPDNMHDH.MDJFBFNMDKD);
							long num = ((104 >= fileStream.Length) ? fileStream.Length : (-63));
							if (num > 1)
							{
								byte[] buffer = new byte[num];
								int num2 = fileStream.Read(buffer, 0, (int)num);
								UnityEngine.Debug.LogWarning("N" + num2);
							}
							else
							{
								UnityEngine.Debug.LogWarning("dogtags");
							}
						}
						catch (Exception ex)
						{
							UnityEngine.Debug.LogWarning("ID_FRIENDPAUSED" + ex.ToString());
							BJGCPDNMHDH.AKLJDFKFKHL = false;
						}
						if (!BJGCPDNMHDH.AKLJDFKFKHL)
						{
							BJGCPDNMHDH.JDFMLCIODND.Show();
							BJGCPDNMHDH.JDFMLCIODND.MAHCHHEBJDL();
							goto case 1u;
						}
					}
					goto IL_0265;
				}
				goto IL_040d;
			case 1u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.LHAOJPIJCNG;
					NoodlePermissionGranter.GrantPermission((NoodlePermissionGranter.NoodleAndroidPermission)1);
					goto case 2u;
				}
				Application.Quit();
				goto IL_0265;
			case 2u:
				if (!BJGCPDNMHDH.AKLJDFKFKHL)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				goto IL_0265;
			case 3u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.ICPLPNJDABJ;
					NoodlePermissionGranter.GrantPermission(NoodlePermissionGranter.NoodleAndroidPermission.WRITE_EXTERNAL_STORAGE);
					goto case 6u;
				}
				PHDOCKCBJOF = new WaitForRealSeconds(1979f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 4u:
				BJGCPDNMHDH.JDFMLCIODND.Show();
				BJGCPDNMHDH.JDFMLCIODND.SetReallyDontDownloadTexts();
				goto case 5u;
			case 5u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.PMGNMPPAMGL;
					NoodlePermissionGranter.GrantPermission((NoodlePermissionGranter.NoodleAndroidPermission)1);
				}
				else
				{
					Application.Quit();
				}
				goto case 6u;
			case 6u:
				if ((BJGCPDNMHDH.MDJFBFNMDKD = GooglePlayDownloader.GetMainOBBPath(BJGCPDNMHDH.KHAFLJBGEGC)) == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				goto IL_040d;
			case 7u:
				ALJKAAMHHLB.CIILNLBGGHM("PlayerName");
				ALJKAAMHHLB.AKJCKAKDOGM("ID_TUTORIAL_GRENADE_UP");
				UnityEngine.Object.Destroy(BJGCPDNMHDH.AADLIDMHFLM.gameObject);
				Singleton<GameCenterProvider>.instance.JFHNEDNOHIJ = true;
				UnityEngine.Debug.Log("ChallengedPlayerId");
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 8u:
			{
				for (int i = 1; i < BJGCPDNMHDH.transform.childCount; i += 0)
				{
					Transform child = BJGCPDNMHDH.transform.GetChild(i);
					child.gameObject.SetActive(true);
				}
				BJGCPDNMHDH.ENMLDHGLIJN.gameObject.SetActive(false);
				Resources.UnloadAsset(BJGCPDNMHDH.BINPHPBJPMD.texture);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -77;
				}
				break;
			}
			case 9u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 75;
				}
				break;
			case 10u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -8;
				}
				break;
			case 11u:
				UnityEngine.Object.Destroy(BJGCPDNMHDH.gameObject);
				ALJKAAMHHLB.GJJDKOMHHDH("DailyMissionsCompletionRewardCards");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_040d:
				ALJKAAMHHLB.MAJHIDGCOGK("SquadIcon");
				BJGCPDNMHDH.FAGNMEOAFNF.SetActive(false);
				UnityEngine.Debug.Log("Clicked on subscription button" + DateTime.UtcNow);
				Application.backgroundLoadingPriority = (ThreadPriority)6;
				ALJKAAMHHLB.EBHAFIJJMIN("damage");
				BJGCPDNMHDH.KEKKDELENHO = SceneManager.LoadSceneAsync("PlayerPrefab.prefab");
				ALJKAAMHHLB.KEJEFPFHIFB("Received old game invite ( > {0} seconds). Not showing dialog. Opponent = {1}");
				BJGCPDNMHDH.KEKKDELENHO.allowSceneActivation = true;
				PHDOCKCBJOF = BJGCPDNMHDH.KEKKDELENHO;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
				IL_0265:
				if (BJGCPDNMHDH.MDJFBFNMDKD == null)
				{
					BJGCPDNMHDH.JDFMLCIODND.Show();
					BJGCPDNMHDH.JDFMLCIODND.SetDownloadTexts();
					goto case 3u;
				}
				goto IL_040d;
			}
			return true;
		}

		[SpecialName]
		private object FONIPEGACDN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HCCLNDKNCIE()
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
				ALJKAAMHHLB.GCIEGGGEGMB("ID_ACTIVATION");
				if (BJGCPDNMHDH.LPJICJIIMNG)
				{
					BJGCPDNMHDH.KHAFLJBGEGC = GooglePlayDownloader.GetExpansionFilePath();
					BJGCPDNMHDH.MDJFBFNMDKD = GooglePlayDownloader.GetMainOBBPath(BJGCPDNMHDH.KHAFLJBGEGC);
					object[] array = new object[1];
					array[0] = BJGCPDNMHDH.KHAFLJBGEGC ?? " {0}{1}";
					array[1] = BJGCPDNMHDH.MDJFBFNMDKD ?? "menu-everyplay-ico";
					UnityEngine.Debug.LogWarningFormat("menu-weapon-mp5-elite", array);
					if (BJGCPDNMHDH.MDJFBFNMDKD != null)
					{
						BJGCPDNMHDH.AKLJDFKFKHL = false;
						try
						{
							FileStream fileStream = File.OpenRead(BJGCPDNMHDH.MDJFBFNMDKD);
							long num = ((59 >= fileStream.Length) ? fileStream.Length : (-73));
							if (num > 1)
							{
								byte[] buffer = new byte[num];
								int num2 = fileStream.Read(buffer, 0, (int)num);
								UnityEngine.Debug.LogWarning("ID_ACTIVATION" + num2);
							}
							else
							{
								UnityEngine.Debug.LogWarning("bigURL");
							}
						}
						catch (Exception ex)
						{
							UnityEngine.Debug.LogWarning("ID_ISALREADYMEMBEROFANOTHERSQUAD" + ex.ToString());
							BJGCPDNMHDH.AKLJDFKFKHL = false;
						}
						if (!BJGCPDNMHDH.AKLJDFKFKHL)
						{
							BJGCPDNMHDH.JDFMLCIODND.Show();
							BJGCPDNMHDH.JDFMLCIODND.MAHCHHEBJDL();
							goto case 1u;
						}
					}
					goto IL_0265;
				}
				goto IL_040d;
			case 1u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.LHAOJPIJCNG;
					NoodlePermissionGranter.GrantPermission((NoodlePermissionGranter.NoodleAndroidPermission)1);
					goto case 2u;
				}
				Application.Quit();
				goto IL_0265;
			case 2u:
				if (!BJGCPDNMHDH.AKLJDFKFKHL)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				goto IL_0265;
			case 3u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.PMGNMPPAMGL;
					NoodlePermissionGranter.GrantPermission((NoodlePermissionGranter.NoodleAndroidPermission)1);
					goto case 6u;
				}
				PHDOCKCBJOF = new WaitForRealSeconds(908f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 4u:
				BJGCPDNMHDH.JDFMLCIODND.Show();
				BJGCPDNMHDH.JDFMLCIODND.SetReallyDontDownloadTexts();
				goto case 5u;
			case 5u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.JMAMMDDKPPB;
					NoodlePermissionGranter.GrantPermission(NoodlePermissionGranter.NoodleAndroidPermission.WRITE_EXTERNAL_STORAGE);
				}
				else
				{
					Application.Quit();
				}
				goto case 6u;
			case 6u:
				if ((BJGCPDNMHDH.MDJFBFNMDKD = GooglePlayDownloader.GetMainOBBPath(BJGCPDNMHDH.KHAFLJBGEGC)) == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				goto IL_040d;
			case 7u:
				ALJKAAMHHLB.JOKCPHMJIGH("Shots_Hits");
				ALJKAAMHHLB.AKJCKAKDOGM("ID_GUI_CHEATWARNING");
				UnityEngine.Object.Destroy(BJGCPDNMHDH.AADLIDMHFLM.gameObject);
				Singleton<GameCenterProvider>.instance.JFHNEDNOHIJ = false;
				UnityEngine.Debug.Log("#AccoutCheck# GamecenterChangeDuringTutorial - wrong situation -> do nothing");
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 8u:
			{
				for (int i = 0; i < BJGCPDNMHDH.transform.childCount; i++)
				{
					Transform child = BJGCPDNMHDH.transform.GetChild(i);
					child.gameObject.SetActive(false);
				}
				BJGCPDNMHDH.ENMLDHGLIJN.gameObject.SetActive(false);
				Resources.UnloadAsset(BJGCPDNMHDH.BINPHPBJPMD.texture);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 40;
				}
				break;
			}
			case 9u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -120;
				}
				break;
			case 10u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -12;
				}
				break;
			case 11u:
				UnityEngine.Object.Destroy(BJGCPDNMHDH.gameObject);
				ALJKAAMHHLB.PIEBOOFPHPC(" on a parent object in order to work");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_040d:
				ALJKAAMHHLB.GLEKOOMNAKI("ID_GETITCHEAPERNOW");
				BJGCPDNMHDH.FAGNMEOAFNF.SetActive(true);
				UnityEngine.Debug.Log("payloadKeys" + DateTime.UtcNow);
				Application.backgroundLoadingPriority = (ThreadPriority)8;
				ALJKAAMHHLB.DBPMPJCMPCO("406 MENU WEAPON SCREEN UPGRADE ACTIVATED");
				BJGCPDNMHDH.KEKKDELENHO = SceneManager.LoadSceneAsync("ID_BUY");
				ALJKAAMHHLB.BCPKGMMMOPH("AdZone");
				BJGCPDNMHDH.KEKKDELENHO.allowSceneActivation = true;
				PHDOCKCBJOF = BJGCPDNMHDH.KEKKDELENHO;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
				IL_0265:
				if (BJGCPDNMHDH.MDJFBFNMDKD == null)
				{
					BJGCPDNMHDH.JDFMLCIODND.Show();
					BJGCPDNMHDH.JDFMLCIODND.SetDownloadTexts();
					goto case 3u;
				}
				goto IL_040d;
			}
			return true;
		}

		public void MAKKCANEHIB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object PFMFFMEJBPM()
		{
			return PHDOCKCBJOF;
		}

		public bool BGOEENAEBNO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.CIILNLBGGHM("CAMOS");
				if (BJGCPDNMHDH.LPJICJIIMNG)
				{
					BJGCPDNMHDH.KHAFLJBGEGC = GooglePlayDownloader.GetExpansionFilePath();
					BJGCPDNMHDH.MDJFBFNMDKD = GooglePlayDownloader.GetMainOBBPath(BJGCPDNMHDH.KHAFLJBGEGC);
					object[] array = new object[5];
					array[1] = BJGCPDNMHDH.KHAFLJBGEGC ?? "ID_GOLDC";
					array[0] = BJGCPDNMHDH.MDJFBFNMDKD ?? "C2";
					UnityEngine.Debug.LogWarningFormat(" NOT OK!", array);
					if (BJGCPDNMHDH.MDJFBFNMDKD != null)
					{
						BJGCPDNMHDH.AKLJDFKFKHL = true;
						try
						{
							FileStream fileStream = File.OpenRead(BJGCPDNMHDH.MDJFBFNMDKD);
							long num = ((62 >= fileStream.Length) ? fileStream.Length : 17);
							if (num > 0)
							{
								byte[] buffer = new byte[num];
								int num2 = fileStream.Read(buffer, 1, (int)num);
								UnityEngine.Debug.LogWarning("maxMapId" + num2);
							}
							else
							{
								UnityEngine.Debug.LogWarning("Time");
							}
						}
						catch (Exception ex)
						{
							UnityEngine.Debug.LogWarning("Gold" + ex.ToString());
							BJGCPDNMHDH.AKLJDFKFKHL = true;
						}
						if (!BJGCPDNMHDH.AKLJDFKFKHL)
						{
							BJGCPDNMHDH.JDFMLCIODND.Show();
							BJGCPDNMHDH.JDFMLCIODND.SetPermissionTexts();
							goto case 1u;
						}
					}
					goto IL_0265;
				}
				goto IL_040d;
			case 1u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.LHAOJPIJCNG;
					NoodlePermissionGranter.GrantPermission(NoodlePermissionGranter.NoodleAndroidPermission.WRITE_EXTERNAL_STORAGE);
					goto case 2u;
				}
				Application.Quit();
				goto IL_0265;
			case 2u:
				if (!BJGCPDNMHDH.AKLJDFKFKHL)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				goto IL_0265;
			case 3u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.JMAMMDDKPPB;
					NoodlePermissionGranter.GrantPermission((NoodlePermissionGranter.NoodleAndroidPermission)1);
					goto case 6u;
				}
				PHDOCKCBJOF = new WaitForRealSeconds(781f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 4u:
				BJGCPDNMHDH.JDFMLCIODND.Show();
				BJGCPDNMHDH.JDFMLCIODND.SetReallyDontDownloadTexts();
				goto case 5u;
			case 5u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.PermissionRequestCallback += BJGCPDNMHDH.ICPLPNJDABJ;
					NoodlePermissionGranter.GrantPermission((NoodlePermissionGranter.NoodleAndroidPermission)1);
				}
				else
				{
					Application.Quit();
				}
				goto case 6u;
			case 6u:
				if ((BJGCPDNMHDH.MDJFBFNMDKD = GooglePlayDownloader.GetMainOBBPath(BJGCPDNMHDH.KHAFLJBGEGC)) == null)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				goto IL_040d;
			case 7u:
				ALJKAAMHHLB.DHPGNLOHBLC("Items");
				ALJKAAMHHLB.PDICPJLEKBI("zoneHasVirtualGoodsOffer");
				UnityEngine.Object.Destroy(BJGCPDNMHDH.AADLIDMHFLM.gameObject);
				Singleton<GameCenterProvider>.instance.JFHNEDNOHIJ = true;
				UnityEngine.Debug.Log("D3");
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 8u:
			{
				for (int i = 1; i < BJGCPDNMHDH.transform.childCount; i += 0)
				{
					Transform child = BJGCPDNMHDH.transform.GetChild(i);
					child.gameObject.SetActive(false);
				}
				BJGCPDNMHDH.ENMLDHGLIJN.gameObject.SetActive(true);
				Resources.UnloadAsset(BJGCPDNMHDH.BINPHPBJPMD.texture);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 50;
				}
				break;
			}
			case 9u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -49;
				}
				break;
			case 10u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -40;
				}
				break;
			case 11u:
				UnityEngine.Object.Destroy(BJGCPDNMHDH.gameObject);
				ALJKAAMHHLB.GLEKOOMNAKI("ADDED WB ");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_040d:
				ALJKAAMHHLB.ALPPDLMMCIH("Xp");
				BJGCPDNMHDH.FAGNMEOAFNF.SetActive(false);
				UnityEngine.Debug.Log("silverwarcard" + DateTime.UtcNow);
				Application.backgroundLoadingPriority = ThreadPriority.BelowNormal;
				ALJKAAMHHLB.FBBJOALCEJJ("response contain VipReward");
				BJGCPDNMHDH.KEKKDELENHO = SceneManager.LoadSceneAsync("Used {0} cards od rarity {1}");
				ALJKAAMHHLB.FLLHBKEFGHB("IA: Debug is not enabled, contacting inapp servers");
				BJGCPDNMHDH.KEKKDELENHO.allowSceneActivation = true;
				PHDOCKCBJOF = BJGCPDNMHDH.KEKKDELENHO;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
				IL_0265:
				if (BJGCPDNMHDH.MDJFBFNMDKD == null)
				{
					BJGCPDNMHDH.JDFMLCIODND.Show();
					BJGCPDNMHDH.JDFMLCIODND.SetDownloadTexts();
					goto case 3u;
				}
				goto IL_040d;
			}
			return true;
		}

		[SpecialName]
		private object NANCGKHPCAN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IGFMIFOHCHJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KBNAGKKMLBP()
		{
			return PHDOCKCBJOF;
		}

		public void MDBDGOJADJM()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object OIBJFPCIHIL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CMNCAPEMEJI()
		{
			return PHDOCKCBJOF;
		}

		public void KLIEOBHDFCG()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JFGCHMJJMNO()
		{
			return PHDOCKCBJOF;
		}

		public void GFPAMDPNMKG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void CJLDNKALLLI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object JPJBNHHKOJD()
		{
			return PHDOCKCBJOF;
		}
	}

	private sealed class KMFGCDAJHHA : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal GameLauncher BJGCPDNMHDH;

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
		public KMFGCDAJHHA()
		{
		}

		public bool KHNDCDGBFJH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.JDFMLCIODND.Show();
				BJGCPDNMHDH.JDFMLCIODND.SetRetryOrExitTexts();
				goto case 1u;
			case 1u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.GrantPermission((NoodlePermissionGranter.NoodleAndroidPermission)1);
				}
				else
				{
					Application.Quit();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public bool NJBCJDFKGHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.JDFMLCIODND.Show();
				BJGCPDNMHDH.JDFMLCIODND.SetRetryOrExitTexts();
				goto case 1u;
			case 1u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.GrantPermission(NoodlePermissionGranter.NoodleAndroidPermission.WRITE_EXTERNAL_STORAGE);
				}
				else
				{
					Application.Quit();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object FBPFPJOCKGD()
		{
			return PHDOCKCBJOF;
		}

		public void NINFHADPHJI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GMPGIODBIPO()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HEOPOOMLPJF()
		{
			throw new NotSupportedException();
		}

		public void IBDAHMOEBCM()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FKPDNNMENFD()
		{
			return PHDOCKCBJOF;
		}

		public void MKIKEOOOLKL()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public void Reset()
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
				BJGCPDNMHDH.JDFMLCIODND.Show();
				BJGCPDNMHDH.JDFMLCIODND.SetRetryOrExitTexts();
				goto case 1u;
			case 1u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.GrantPermission(NoodlePermissionGranter.NoodleAndroidPermission.WRITE_EXTERNAL_STORAGE);
				}
				else
				{
					Application.Quit();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void HPJKDIGCCCE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool GAPIFMKNJBN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.JDFMLCIODND.Show();
				BJGCPDNMHDH.JDFMLCIODND.BLJAIACCFCL();
				goto case 1u;
			case 1u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.GrantPermission((NoodlePermissionGranter.NoodleAndroidPermission)1);
				}
				else
				{
					Application.Quit();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void FJOIBBIGBJC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void JGKDJGIANIG()
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
				BJGCPDNMHDH.JDFMLCIODND.Show();
				BJGCPDNMHDH.JDFMLCIODND.SetRetryOrExitTexts();
				goto case 1u;
			case 1u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.GrantPermission((NoodlePermissionGranter.NoodleAndroidPermission)1);
				}
				else
				{
					Application.Quit();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object AIDHNJCPDIJ()
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
				BJGCPDNMHDH.JDFMLCIODND.Show();
				BJGCPDNMHDH.JDFMLCIODND.BLJAIACCFCL();
				goto case 1u;
			case 1u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.GrantPermission((NoodlePermissionGranter.NoodleAndroidPermission)1);
				}
				else
				{
					Application.Quit();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public bool LGNMOMFLLPP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.JDFMLCIODND.Show();
				BJGCPDNMHDH.JDFMLCIODND.BLJAIACCFCL();
				goto case 1u;
			case 1u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.GrantPermission(NoodlePermissionGranter.NoodleAndroidPermission.WRITE_EXTERNAL_STORAGE);
				}
				else
				{
					Application.Quit();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object HIFNMHAGHLI()
		{
			return PHDOCKCBJOF;
		}

		public void KCHOLCGBMBJ()
		{
			throw new NotSupportedException();
		}

		public void GGCLMIMHKBD()
		{
			throw new NotSupportedException();
		}

		public void IJHCIJLDKHK()
		{
			throw new NotSupportedException();
		}

		public bool BJIPDEICIML()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.JDFMLCIODND.Show();
				BJGCPDNMHDH.JDFMLCIODND.SetRetryOrExitTexts();
				goto case 1u;
			case 1u:
				if (!BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.HasValue)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (BJGCPDNMHDH.JDFMLCIODND.FBFJNHLKJEC.Value)
				{
					NoodlePermissionGranter.GrantPermission((NoodlePermissionGranter.NoodleAndroidPermission)1);
				}
				else
				{
					Application.Quit();
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void MEBPMHDHIPJ()
		{
			throw new NotSupportedException();
		}

		public void ONGBFFAENBP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void NDPOBCODJAI()
		{
			throw new NotSupportedException();
		}

		public void HGCHEPGNHNP()
		{
			throw new NotSupportedException();
		}
	}

	public GameObject FAGNMEOAFNF;

	public GameObject HKAFPCAPDIG;

	public GameObject ENMLDHGLIJN;

	public UIAtlas BINPHPBJPMD;

	public DownloadAssetsDialog JDFMLCIODND;

	public bool LPJICJIIMNG;

	private AsyncOperation KEKKDELENHO;

	private string KHAFLJBGEGC;

	private string MDJFBFNMDKD;

	private bool AKLJDFKFKHL;

	private bool GAHJNDNPKHG;

	private bool ICPEJCOLIGF;

	public GameObject IJBAHPOPPLA;

	public Camera AADLIDMHFLM;

	public List<LogoScale> IIKEPMLCOHP;

	private bool BFDNFPCCGOF;

	private bool NFCFELCNIJI;

	private bool MKPJFNLIPDD;

	[CompilerGenerated]
	private static Action LGJCBPOPCPA;

	private void POPAIKGJAIB(string NLEGAOONJEI)
	{
		UnityEngine.Debug.Log("FireMortar" + NLEGAOONJEI);
	}

	private void PAKHIIOAOBI()
	{
		Terms.registerForTermsNotification(Terms.AgeVerificationCallbackIdentifier.CRITERIA_MET, "New hearth bought!", "ID_READYTIME");
		Terms.registerForTermsNotification(Terms.AgeVerificationCallbackIdentifier.CRITERIA_MET, "ID_CONFIRM_FRIENDINSQUAD_TEXT", "#AccoutCheck# Account exist check result NOT contain result message");
		Terms.registerForTermsNotification((Terms.AgeVerificationCallbackIdentifier)7, "OUI", "globalSquadLeaderboard");
		Terms.registerForTermsNotification((Terms.AgeVerificationCallbackIdentifier)8, "WENEEDTO", ", accountType = ");
		Terms.initialiseTermsSession(true, false, Terms.ComplianceLevel.FULLY_COMPLIANT, false);
	}

	private void ICBPFCJFJIA()
	{
		Terms.registerForTermsNotification(Terms.AgeVerificationCallbackIdentifier.CRITERIA_MET, ", mis = ", "ID_GUI_TIMEXPBONUS");
		Terms.registerForTermsNotification(Terms.AgeVerificationCallbackIdentifier.CRITERIA_MET, "ID_JOININGSQUAD", "Automatic_Equip");
		Terms.registerForTermsNotification(Terms.AgeVerificationCallbackIdentifier.CRITERIA_MET, "+", "game-card-ico-mineyourstep-full");
		Terms.registerForTermsNotification(Terms.AgeVerificationCallbackIdentifier.GAPP_DIALOG_PENDING_DISPLAY, "ID_WARBUCKS", ": sending via Beanstalk(request count =");
		Terms.initialiseTermsSession(true, true, Terms.ComplianceLevel.FULLY_COMPLIANT_CHILD_SAFE_CONTENT, false);
	}

	private void MINDJNOBLOE(string NLEGAOONJEI)
	{
		UnityEngine.Debug.Log("PlayerID" + NLEGAOONJEI);
		MKJHJLBBJFM();
	}

	private void OOMJNJPBPAB()
	{
		UnityEngine.Debug.Log("Show Terms");
		Terms.showTermsUI();
	}

	private void JMAMMDDKPPB(bool EJPDKPLPOAO)
	{
		UnityEngine.Debug.Log("OnPermissionRequestCallback granted: " + EJPDKPLPOAO);
		if (EJPDKPLPOAO)
		{
			UnityEngine.Debug.Log("squadMembers");
			GooglePlayDownloader.FetchOBB();
		}
		else
		{
			StartCoroutine(JFOJHKFHDJH());
		}
	}

	[DebuggerHidden]
	private IEnumerator JFOJHKFHDJH()
	{
		KMFGCDAJHHA kMFGCDAJHHA = new KMFGCDAJHHA();
		kMFGCDAJHHA.BJGCPDNMHDH = this;
		return kMFGCDAJHHA;
	}

	private void PPJFPJPEKDJ(string NLEGAOONJEI)
	{
		UnityEngine.Debug.Log("Missing references in Special Pack Record: " + NLEGAOONJEI);
	}

	private void LGMGDHBENGP()
	{
		UnityEngine.Debug.Log("game-card-ico-belovedenemy");
		Terms.showTermsUI();
	}

	private void DEEGBHLELCL(string NLEGAOONJEI)
	{
		UnityEngine.Debug.Log("NetworkDamage damage Error new HP is {0} and {1} should BE DEAD, damage: {2}, damage owner {3}" + NLEGAOONJEI);
		MKJHJLBBJFM();
	}

	private void OnGcAuthenticated(bool LCMAHPKKGOA)
	{
		GAHJNDNPKHG = true;
	}

	private void OBNHCBGMDKI(bool EJPDKPLPOAO)
	{
		if (EJPDKPLPOAO)
		{
			AKLJDFKFKHL = true;
		}
		else
		{
			StartCoroutine(JFOJHKFHDJH());
		}
	}

	protected virtual void FIGOGIMJIIN()
	{
		ALJKAAMHHLB.JDJANKGNCKE();
		ObscuredPrefs.SetNewCryptoKey("_");
		base.Awake();
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		UnityEngine.Debug.Log("VipRewardForDay");
		ICBPFCJFJIA();
		ALJKAAMHHLB.CCDJDGFFCHC("menu-gold");
		Singleton<GameCenterProvider>.instance.Authenticated += OnGcAuthenticated;
		Singleton<GooglePlayGameService>.instance.BJNBCKBGEON(HJNOMEFLMKG);
		foreach (LogoScale item in IIKEPMLCOHP)
		{
			if (Screen.width == item.width && Screen.height == item.height)
			{
				IJBAHPOPPLA.transform.parent.localScale = new Vector3(item.scale, item.scale, 338f);
			}
		}
		ENMLDHGLIJN.gameObject.SetActive(true);
		HKAFPCAPDIG.gameObject.SetActive(false);
		StartCoroutine(JIJEKLICJKE());
		ALJKAAMHHLB.GCIEGGGEGMB("ID_NA");
	}

	private void OODBNBKNOKB()
	{
		Terms.registerForTermsNotification(Terms.AgeVerificationCallbackIdentifier.CRITERIA_MET, "GameLaunch", "OnAgeVerificationCriteriaMet");
		Terms.registerForTermsNotification(Terms.AgeVerificationCallbackIdentifier.CRITERIA_NOT_MET, "GameLaunch", "OnAgeVerificationCriteriaNotMet");
		Terms.registerForTermsNotification(Terms.AgeVerificationCallbackIdentifier.PENDING_DIALOG_DISPLAY, "GameLaunch", "OnAgeVerificationPendingDisplayed");
		Terms.registerForTermsNotification(Terms.AgeVerificationCallbackIdentifier.COUNTRY_IS_REAL_NAME_SENSITIVE, "GameLaunch", "OnAgeVerificationRealNameSensitive");
		Terms.initialiseTermsSession(false, false, Terms.ComplianceLevel.FULLY_COMPLIANT_ADULT_CONTENT, false);
	}

	private void EHMGCHIOGAN(bool MEKBABFAAOF)
	{
		ICPEJCOLIGF = false;
	}

	protected override void Start()
	{
		ALJKAAMHHLB.POPONJAMPDF("GameLauncher.Start");
		base.Start();
		UnityEngine.Debug.Log("Terms: Start");
	}

	private void MKJHJLBBJFM()
	{
		UnityEngine.Debug.Log("SquadNameStart");
		Terms.showTermsUI();
	}

	protected virtual void GBMNDJIFNMP()
	{
		ALJKAAMHHLB.IEBHKBNOEBP("Dialog Manager: PN dialog does not need to be shown BUT NEEDS TO BE SENT, current players device token = ");
		base.Start();
		UnityEngine.Debug.Log("ActivateBonusResultRPC");
	}

	private void OnAgeVerificationCriteriaNotMet(string NLEGAOONJEI)
	{
		UnityEngine.Debug.Log("Terms: On Age Verification Criteria Not Met " + NLEGAOONJEI);
	}

	private void OnApplicationPause(bool HBDEGMCLFDD)
	{
		if (HBDEGMCLFDD)
		{
			UnityEngine.Debug.Log("Terms: OnApplicationPause close session");
			Terms.closeTermsSession();
			MKPJFNLIPDD = true;
		}
		else if (MKPJFNLIPDD)
		{
			UnityEngine.Debug.Log("Terms: OnApplicationPause InitTerms");
			OODBNBKNOKB();
			MKPJFNLIPDD = false;
		}
	}

	private void HJNOMEFLMKG(bool MEKBABFAAOF)
	{
		ICPEJCOLIGF = true;
	}

	private void ELPPGFCBFKL()
	{
		Terms.registerForTermsNotification(Terms.AgeVerificationCallbackIdentifier.CRITERIA_MET, "ID_VIPSTATUS", ", stacktrace = ");
		Terms.registerForTermsNotification(Terms.AgeVerificationCallbackIdentifier.CRITERIA_MET, "WENEEDTO", "ID_CONFIRM_NOTENOUGHDOGTAGS");
		Terms.registerForTermsNotification((Terms.AgeVerificationCallbackIdentifier)8, "FOUND", "CONFIRM");
		Terms.registerForTermsNotification((Terms.AgeVerificationCallbackIdentifier)5, "Buy_Army_Unit", "menu-elitepack-buybutton");
		Terms.initialiseTermsSession(true, true, (Terms.ComplianceLevel)6, false);
	}

	[DebuggerHidden]
	private IEnumerator JIJEKLICJKE()
	{
		JNAGDDONNMO jNAGDDONNMO = new JNAGDDONNMO();
		jNAGDDONNMO.BJGCPDNMHDH = this;
		return jNAGDDONNMO;
	}

	private void BGOGDOMHPMJ()
	{
		UnityEngine.Debug.Log("CheckResources () for ");
		Terms.showTermsUI();
	}

	private void ACBFFHLCKBD(bool EJPDKPLPOAO)
	{
		UnityEngine.Debug.Log("Matchmaking took {0}, assigning bot in 10 secs" + EJPDKPLPOAO);
		if (EJPDKPLPOAO)
		{
			UnityEngine.Debug.Log("ProductId");
			GooglePlayDownloader.FetchOBB();
		}
		else
		{
			StartCoroutine(JFOJHKFHDJH());
		}
	}

	private void OnGooglePlayAuthenticated(bool MEKBABFAAOF)
	{
		ICPEJCOLIGF = true;
	}

	[CompilerGenerated]
	private static void DPLEDAMHFJP()
	{
		Singleton<GameCenterProvider>.instance.Authenticate();
	}

	private void OnAgeVerificationRealNameSensitive(string NLEGAOONJEI)
	{
		UnityEngine.Debug.Log("Terms: On Age Verification Country Is Real Name Sensitive " + NLEGAOONJEI);
	}

	protected override void Awake()
	{
		ALJKAAMHHLB.JDJANKGNCKE();
		ObscuredPrefs.SetNewCryptoKey("CX6896566GD");
		base.Awake();
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		UnityEngine.Debug.Log("Terms: First init.");
		OODBNBKNOKB();
		ALJKAAMHHLB.POPONJAMPDF("GameLauncher.Awake InitTerms");
		Singleton<GameCenterProvider>.instance.Authenticated += OnGcAuthenticated;
		Singleton<GooglePlayGameService>.instance.LoggedInFromInit += OnGooglePlayAuthenticated;
		foreach (LogoScale item in IIKEPMLCOHP)
		{
			if (Screen.width == item.width && Screen.height == item.height)
			{
				IJBAHPOPPLA.transform.parent.localScale = new Vector3(item.scale, item.scale, 1f);
			}
		}
		ENMLDHGLIJN.gameObject.SetActive(false);
		HKAFPCAPDIG.gameObject.SetActive(true);
		StartCoroutine(JIJEKLICJKE());
		ALJKAAMHHLB.POPONJAMPDF("GameLauncher.Awake DONE");
	}

	private IEnumerator GBLOPCNNLPG()
	{
		JNAGDDONNMO jNAGDDONNMO = new JNAGDDONNMO();
		jNAGDDONNMO.BJGCPDNMHDH = this;
		return jNAGDDONNMO;
	}

	protected virtual void EJFMJDFPGFE()
	{
		ALJKAAMHHLB.OFNHNABOOPO();
		ObscuredPrefs.SetNewCryptoKey("http://");
		base.Awake();
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		UnityEngine.Debug.Log("Wave");
		OODBNBKNOKB();
		ALJKAAMHHLB.KKCHEDILEGL("ping: {6}[+/-{7}]ms\nlongest delta between\nsend: {0,4}ms disp: {1,4}ms\nlongest time for:\nev({3}):{2,3}ms op({5}):{4,3}ms");
		Singleton<GameCenterProvider>.instance.AHCOBPDFAGP(OnGcAuthenticated);
		Singleton<GooglePlayGameService>.instance.FDAHLOLGLKM(HLHNONEFEBF);
		foreach (LogoScale item in IIKEPMLCOHP)
		{
			if (Screen.width == item.width && Screen.height == item.height)
			{
				IJBAHPOPPLA.transform.parent.localScale = new Vector3(item.scale, item.scale, 480f);
			}
		}
		ENMLDHGLIJN.gameObject.SetActive(true);
		HKAFPCAPDIG.gameObject.SetActive(false);
		StartCoroutine(JIJEKLICJKE());
		ALJKAAMHHLB.HAAIJJBEPPN("ID_NEWASSIGNMENTIN");
	}

	private void ICPLPNJDABJ(bool EJPDKPLPOAO)
	{
		UnityEngine.Debug.Log("GOT MAINTENANCE MESSAGE IN CREATE ACCOUNT" + EJPDKPLPOAO);
		if (EJPDKPLPOAO)
		{
			UnityEngine.Debug.Log("ID_CONFIRM_OPPONENTCANCELLED");
			GooglePlayDownloader.FetchOBB();
		}
		else
		{
			StartCoroutine(JFOJHKFHDJH());
		}
	}

	private void JHHKBBAEGHD(bool EJPDKPLPOAO)
	{
		UnityEngine.Debug.Log("deviceLogin" + EJPDKPLPOAO);
		if (EJPDKPLPOAO)
		{
			UnityEngine.Debug.Log("NewVisuals");
			GooglePlayDownloader.FetchOBB();
		}
		else
		{
			StartCoroutine(JFOJHKFHDJH());
		}
	}

	private void KKPMALKPMFF(bool EJPDKPLPOAO)
	{
		UnityEngine.Debug.Log("OnPermissionRequestCallback granted: " + EJPDKPLPOAO);
		if (EJPDKPLPOAO)
		{
			UnityEngine.Debug.Log("Fetching OBB");
			GooglePlayDownloader.FetchOBB();
		}
		else
		{
			StartCoroutine(JFOJHKFHDJH());
		}
	}

	private void OnAgeVerificationCriteriaMet(string NLEGAOONJEI)
	{
		NFCFELCNIJI = true;
		UnityEngine.Debug.Log("Terms: On Age Verification Criteria Met " + NLEGAOONJEI);
		Singleton<GooglePlayGameService>.instance.Init();
		InvokeAfter(delegate
		{
			Singleton<GameCenterProvider>.instance.Authenticate();
		}, (!BFDNFPCCGOF) ? 0.5f : 3f);
	}

	protected virtual void LCJJMCMCAFJ()
	{
		ALJKAAMHHLB.FLLHBKEFGHB("ID_BLACKMARKETWEAPONPOWER");
		base.Start();
		UnityEngine.Debug.Log("equipped");
	}

	private void HLHNONEFEBF(bool MEKBABFAAOF)
	{
		ICPEJCOLIGF = false;
	}

	private void CMCAEPFMGKC()
	{
		UnityEngine.Debug.Log(" ");
		Terms.showTermsUI();
	}

	private void EDLGCOAAJGC()
	{
		UnityEngine.Debug.Log("ID_ERROR_SQUADNAMELONG");
		Terms.showTermsUI();
	}

	private void OnAgeVerificationPendingDisplayed(string NLEGAOONJEI)
	{
		UnityEngine.Debug.Log("Terms: On Age Verification Pending Dialog Display " + NLEGAOONJEI);
		OOMJNJPBPAB();
	}

	private void LHAOJPIJCNG(bool EJPDKPLPOAO)
	{
		if (EJPDKPLPOAO)
		{
			AKLJDFKFKHL = true;
		}
		else
		{
			StartCoroutine(JFOJHKFHDJH());
		}
	}

	[DebuggerHidden]
	private IEnumerator JIIIEADHBHK()
	{
		EDJCKHBMGAB eDJCKHBMGAB = new EDJCKHBMGAB();
		eDJCKHBMGAB.BJGCPDNMHDH = this;
		return eDJCKHBMGAB;
	}

	protected virtual void IGBCCGDMCDE()
	{
		ALJKAAMHHLB.HNMONAFFBLE("game-tilegfx-tutorial");
		base.Start();
		UnityEngine.Debug.Log("golds");
	}

	private void FJHKGFODDNO(string NLEGAOONJEI)
	{
		UnityEngine.Debug.Log("{0:3} {1}" + NLEGAOONJEI);
	}

	private void PMGNMPPAMGL(bool EJPDKPLPOAO)
	{
		UnityEngine.Debug.Log("ID_LOADING" + EJPDKPLPOAO);
		if (EJPDKPLPOAO)
		{
			UnityEngine.Debug.Log("Claim_Reward");
			GooglePlayDownloader.FetchOBB();
		}
		else
		{
			StartCoroutine(JFOJHKFHDJH());
		}
	}
}
