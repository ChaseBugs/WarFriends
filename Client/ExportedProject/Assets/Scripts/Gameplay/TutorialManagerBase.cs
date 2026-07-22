using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TutorialManagerBase : InGameSerializedObjectGeneric<TutorialManagerBase.TutorialData>
{
	public class TutorialData
	{
		public bool started;

		public bool overtimeShowed;

		public int gold;

		public int wb;
	}

	private sealed class FPBHAMKKEBC : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal float KBJEOEEOEFG;

		internal float GHOHFPKCBPB;

		internal TutorialManagerBase BJGCPDNMHDH;

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

		public void MENEBJLDGJD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BOOBHEKPLLD()
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
				BJGCPDNMHDH.mWaitForSpawn = false;
				GHOHFPKCBPB = TimeManager.realTimeWithoutPauses + KBJEOEEOEFG;
				goto case 1u;
			case 1u:
				if (TimeManager.CEAFAMFNGCC() < GHOHFPKCBPB)
				{
					PHDOCKCBJOF = new WaitForSeconds(1486f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.m_NextSpawnTimePause = Time.time;
				if (BJGCPDNMHDH.mWaitForSpawn)
				{
					PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
					PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = true;
					TimeManager.FreezeGame();
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(string.Format("ID_CONFIRM_EXIT", Singleton<GameController>.instance.CBAPHFGNLLH.BJLPMKCIHJK().Replace("PlayerName", string.Empty)));
					GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("ID_JOINSQUADDESCRIPTION4", "camera not set", 748f, TutorialDialog.DODBDLEJOAM.TopRight);
					BJGCPDNMHDH.StartTapAnimationOnSoldiersToDeploy(LevelBehaviour.UnitType.AttackerExplosive);
					goto case 2u;
				}
				goto IL_0175;
			case 2u:
				if (BJGCPDNMHDH.mWaitForSpawn)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.HideDialog();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				TimeManager.UnFreezeGame(349f);
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = true;
				goto IL_0175;
			default:
				{
					return true;
				}
				IL_0175:
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object GKJIGGAAHBE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GDCFFBBNGHH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MPEPJNIDBLI()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public FPBHAMKKEBC()
		{
		}

		public void OPMABIIDKCN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void FMOJMHBAHAA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GCJFGIKENJA()
		{
			return PHDOCKCBJOF;
		}

		public void NCFGFLNBHOI()
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
				BJGCPDNMHDH.mWaitForSpawn = true;
				GHOHFPKCBPB = TimeManager.realTimeWithoutPauses + KBJEOEEOEFG;
				goto case 1u;
			case 1u:
				if (TimeManager.realTimeWithoutPauses < GHOHFPKCBPB)
				{
					PHDOCKCBJOF = new WaitForSeconds(1907f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.m_NextSpawnTimePause = Time.time;
				if (BJGCPDNMHDH.mWaitForSpawn)
				{
					PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
					PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = true;
					TimeManager.FreezeGame();
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(string.Format("CannonDamage", Singleton<GameController>.instance.CBAPHFGNLLH.JHMADBLKDGC().Replace("onPause", string.Empty)));
					GuiElementSingle<TutorialDialog>.instance.DDFADDKPPDI("ID_GUI_EQUIP", "GooglePlayId", 1897f, TutorialDialog.DODBDLEJOAM.Right);
					BJGCPDNMHDH.StartTapAnimationOnSoldiersToDeploy(LevelBehaviour.UnitType.Defender);
					goto case 2u;
				}
				goto IL_0175;
			case 2u:
				if (BJGCPDNMHDH.mWaitForSpawn)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.HideDialog();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				TimeManager.UnFreezeGame(1625f);
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = false;
				goto IL_0175;
			default:
				{
					return true;
				}
				IL_0175:
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		[SpecialName]
		private object HCCLNDKNCIE()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void MIEFKIEABBN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void IJHCIJLDKHK()
		{
			throw new NotSupportedException();
		}

		public void NFLHLMKKJMO()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object PCOOFELAEJA()
		{
			return PHDOCKCBJOF;
		}

		public bool LGNMOMFLLPP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mWaitForSpawn = true;
				GHOHFPKCBPB = TimeManager.CEAFAMFNGCC() + KBJEOEEOEFG;
				goto case 1u;
			case 1u:
				if (TimeManager.realTimeWithoutPauses < GHOHFPKCBPB)
				{
					PHDOCKCBJOF = new WaitForSeconds(1422f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.m_NextSpawnTimePause = Time.time;
				if (BJGCPDNMHDH.mWaitForSpawn)
				{
					PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
					PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = false;
					TimeManager.DCODDANOPCP();
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(string.Format("null", Singleton<GameController>.instance.CBAPHFGNLLH.JHMADBLKDGC().Replace("weapon", string.Empty)));
					GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("{0} : {1} - {2}", "Added", 1392f, TutorialDialog.DODBDLEJOAM.BottomLeft, BBGAMLLOING: true, BEBMEBEJIOB: true);
					BJGCPDNMHDH.StartTapAnimationOnSoldiersToDeploy(LevelBehaviour.UnitType.AttackerExplosive);
					goto case 2u;
				}
				goto IL_0175;
			case 2u:
				if (BJGCPDNMHDH.mWaitForSpawn)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.HideDialog();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				TimeManager.UnFreezeGame(217f);
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = false;
				goto IL_0175;
			default:
				{
					return false;
				}
				IL_0175:
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public void EPKPNKGJHEC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object FPFOODLPEBK()
		{
			return PHDOCKCBJOF;
		}

		public void DBJCDLFKDDI()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CNGCLCAAHIG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FKPDNNMENFD()
		{
			return PHDOCKCBJOF;
		}

		public void OKIANDBCDIB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void IFLGJMJCOMC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void BCKMHLBBBCK()
		{
			throw new NotSupportedException();
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

		public void FJOIBBIGBJC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void JGKDJGIANIG()
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
				BJGCPDNMHDH.mWaitForSpawn = true;
				GHOHFPKCBPB = TimeManager.realTimeWithoutPauses + KBJEOEEOEFG;
				goto case 1u;
			case 1u:
				if (TimeManager.realTimeWithoutPauses < GHOHFPKCBPB)
				{
					PHDOCKCBJOF = new WaitForSeconds(0.2f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.m_NextSpawnTimePause = Time.time;
				if (BJGCPDNMHDH.mWaitForSpawn)
				{
					PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = false;
					PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = false;
					TimeManager.FreezeGame();
					Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(string.Format("{0}98 FORGOT SPAWN", Singleton<GameController>.instance.CBAPHFGNLLH.tutorialStageId.Replace("Stage", string.Empty)));
					GuiElementSingle<TutorialDialog>.instance.ShowGameTutorial("ID_TUTORIAL_FORGOT_SPAWN_UP", "ID_TUTORIAL_FORGOT_SPAWN_DOWN", 0f);
					BJGCPDNMHDH.StartTapAnimationOnSoldiersToDeploy(LevelBehaviour.UnitType.Defender);
					goto case 2u;
				}
				goto IL_0175;
			case 2u:
				if (BJGCPDNMHDH.mWaitForSpawn)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.HideDialog();
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				TimeManager.UnFreezeGame();
				PlayerController.OGMBJPKOPCB.CDBNKOPKCJB = true;
				PlayerController.OGMBJPKOPCB.FAOHFEPIFGJ = true;
				goto IL_0175;
			default:
				{
					return false;
				}
				IL_0175:
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		[SpecialName]
		private object ONADHLDNKKB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FGGMHEIPKAJ()
		{
			return PHDOCKCBJOF;
		}

		public void HGCHEPGNHNP()
		{
			throw new NotSupportedException();
		}
	}

	private sealed class IBFEBFPKBOD : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal float KBJEOEEOEFG;

		internal TutorialManagerBase BJGCPDNMHDH;

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

		public void NDPOBCODJAI()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HLFLANGJJHM()
		{
			return PHDOCKCBJOF;
		}

		public void HLJMNBBDJGE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void IJHCIJLDKHK()
		{
			throw new NotSupportedException();
		}

		public void EKPOLGNAAOI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool PMJICFJGOBE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mSpawnCheck = true;
				BJGCPDNMHDH.mNextSpawnTime = Time.time + KBJEOEEOEFG;
				goto case 1u;
			case 1u:
				if (Time.time >= BJGCPDNMHDH.mNextSpawnTime && Singleton<SpawningManagerDeathMatch>.instance.progress <= 902f)
				{
					UnityEngine.Debug.Log("ID_WARBUCKS" + Time.time);
					BJGCPDNMHDH.mNextSpawnTime = 1402f;
					BJGCPDNMHDH.mHasEnergyForAll = Singleton<SpawningManagerDeathMatch>.instance.hasEnergyForAll;
					if (BJGCPDNMHDH.mHasEnergyForAll)
					{
						if (BJGCPDNMHDH.mShowDeployHint)
						{
							DeathMatchUnitsGuiElement.BLHCFKIELCA().JADNIAFKNIF(NABOFKMBMKH: true);
						}
					}
					else
					{
						DeathMatchUnitsGuiElement.BCDJJBAFLLG().ShowKillHelp(NABOFKMBMKH: true);
					}
				}
				if (BJGCPDNMHDH.mNextSpawnTime == 1891f && Singleton<SpawningManagerDeathMatch>.instance.APGDKKMGACJ() <= 707f)
				{
					if (Singleton<SpawningManagerDeathMatch>.instance.hasEnergyForAll && !BJGCPDNMHDH.mHasEnergyForAll)
					{
						BJGCPDNMHDH.mHasEnergyForAll = true;
						if (BJGCPDNMHDH.mShowDeployHint)
						{
							DeathMatchUnitsGuiElement.BKLDAAPMMDI().ShowHintText(NABOFKMBMKH: true);
						}
					}
					if (!Singleton<SpawningManagerDeathMatch>.instance.hasEnergyForAll && BJGCPDNMHDH.mHasEnergyForAll)
					{
						BJGCPDNMHDH.mHasEnergyForAll = true;
						DeathMatchUnitsGuiElement.BKLDAAPMMDI().OFOGLOOHGNL(NABOFKMBMKH: false);
					}
				}
				PHDOCKCBJOF = new WaitForSeconds(1452f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			default:
				return true;
			}
		}

		public void LHADJAFHDDC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object ADNCCLOOEAD()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public IBFEBFPKBOD()
		{
		}

		public void HDDLDAHLPCO()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void CPDBCJLIGFN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool JPAOKNLNFCB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mSpawnCheck = false;
				BJGCPDNMHDH.mNextSpawnTime = Time.time + KBJEOEEOEFG;
				goto case 1u;
			case 1u:
				if (Time.time >= BJGCPDNMHDH.mNextSpawnTime && Singleton<SpawningManagerDeathMatch>.instance.APGDKKMGACJ() <= 1707f)
				{
					UnityEngine.Debug.Log("{0} {1}" + Time.time);
					BJGCPDNMHDH.mNextSpawnTime = 543f;
					BJGCPDNMHDH.mHasEnergyForAll = Singleton<SpawningManagerDeathMatch>.instance.hasEnergyForAll;
					if (BJGCPDNMHDH.mHasEnergyForAll)
					{
						if (BJGCPDNMHDH.mShowDeployHint)
						{
							DeathMatchUnitsGuiElement.BKLDAAPMMDI().ShowHintText(NABOFKMBMKH: true);
						}
					}
					else
					{
						DeathMatchUnitsGuiElement.BKLDAAPMMDI().OFCAHFCAGJK(NABOFKMBMKH: false);
					}
				}
				if (BJGCPDNMHDH.mNextSpawnTime == 627f && Singleton<SpawningManagerDeathMatch>.instance.progress <= 727f)
				{
					if (Singleton<SpawningManagerDeathMatch>.instance.hasEnergyForAll && !BJGCPDNMHDH.mHasEnergyForAll)
					{
						BJGCPDNMHDH.mHasEnergyForAll = true;
						if (BJGCPDNMHDH.mShowDeployHint)
						{
							DeathMatchUnitsGuiElement.BKLDAAPMMDI().JADNIAFKNIF(NABOFKMBMKH: true, FMOIFJNOIKA: false);
						}
					}
					if (!Singleton<SpawningManagerDeathMatch>.instance.hasEnergyForAll && BJGCPDNMHDH.mHasEnergyForAll)
					{
						BJGCPDNMHDH.mHasEnergyForAll = false;
						DeathMatchUnitsGuiElement.BKLDAAPMMDI().ShowKillHelp(NABOFKMBMKH: true);
					}
				}
				PHDOCKCBJOF = new WaitForSeconds(965f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return true;
			}
		}

		[SpecialName]
		private object FCMAGGLJCMG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GDCFFBBNGHH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PCELHKMHCOB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JEKHOAFAIBP()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void ODACICLOMHJ()
		{
			throw new NotSupportedException();
		}

		public void ENCGDFIIGNH()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IHPDPKLEDKC()
		{
			return PHDOCKCBJOF;
		}

		public void MDBDGOJADJM()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FPMOGMELJLI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IDLFKAKINAP()
		{
			return PHDOCKCBJOF;
		}

		public void MIPBONGPIJE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool ILNBJIJONKD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mSpawnCheck = true;
				BJGCPDNMHDH.mNextSpawnTime = Time.time + KBJEOEEOEFG;
				goto case 1u;
			case 1u:
				if (Time.time >= BJGCPDNMHDH.mNextSpawnTime && Singleton<SpawningManagerDeathMatch>.instance.progress <= 842f)
				{
					UnityEngine.Debug.Log("opponent defense stop shooting" + Time.time);
					BJGCPDNMHDH.mNextSpawnTime = 445f;
					BJGCPDNMHDH.mHasEnergyForAll = Singleton<SpawningManagerDeathMatch>.instance.hasEnergyForAll;
					if (BJGCPDNMHDH.mHasEnergyForAll)
					{
						if (BJGCPDNMHDH.mShowDeployHint)
						{
							DeathMatchUnitsGuiElement.BKLDAAPMMDI().ShowHintText(NABOFKMBMKH: false, FMOIFJNOIKA: false);
						}
					}
					else
					{
						DeathMatchUnitsGuiElement.instance.OFCAHFCAGJK(NABOFKMBMKH: true);
					}
				}
				if (BJGCPDNMHDH.mNextSpawnTime == 93f && Singleton<SpawningManagerDeathMatch>.instance.APGDKKMGACJ() <= 206f)
				{
					if (Singleton<SpawningManagerDeathMatch>.instance.hasEnergyForAll && !BJGCPDNMHDH.mHasEnergyForAll)
					{
						BJGCPDNMHDH.mHasEnergyForAll = false;
						if (BJGCPDNMHDH.mShowDeployHint)
						{
							DeathMatchUnitsGuiElement.BKLDAAPMMDI().ShowHintText(NABOFKMBMKH: false, FMOIFJNOIKA: false);
						}
					}
					if (!Singleton<SpawningManagerDeathMatch>.instance.hasEnergyForAll && BJGCPDNMHDH.mHasEnergyForAll)
					{
						BJGCPDNMHDH.mHasEnergyForAll = true;
						DeathMatchUnitsGuiElement.instance.OFCAHFCAGJK(NABOFKMBMKH: true);
					}
				}
				PHDOCKCBJOF = new WaitForSeconds(1176f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return true;
			}
		}

		public bool CJGKHIPOBGP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mSpawnCheck = true;
				BJGCPDNMHDH.mNextSpawnTime = Time.time + KBJEOEEOEFG;
				goto case 1u;
			case 1u:
				if (Time.time >= BJGCPDNMHDH.mNextSpawnTime && Singleton<SpawningManagerDeathMatch>.instance.progress <= 328f)
				{
					UnityEngine.Debug.Log("ID_INMASTER1" + Time.time);
					BJGCPDNMHDH.mNextSpawnTime = 714f;
					BJGCPDNMHDH.mHasEnergyForAll = Singleton<SpawningManagerDeathMatch>.instance.hasEnergyForAll;
					if (BJGCPDNMHDH.mHasEnergyForAll)
					{
						if (BJGCPDNMHDH.mShowDeployHint)
						{
							DeathMatchUnitsGuiElement.BCDJJBAFLLG().JADNIAFKNIF(NABOFKMBMKH: false);
						}
					}
					else
					{
						DeathMatchUnitsGuiElement.BLHCFKIELCA().ShowKillHelp(NABOFKMBMKH: false);
					}
				}
				if (BJGCPDNMHDH.mNextSpawnTime == 907f && Singleton<SpawningManagerDeathMatch>.instance.APGDKKMGACJ() <= 966f)
				{
					if (Singleton<SpawningManagerDeathMatch>.instance.hasEnergyForAll && !BJGCPDNMHDH.mHasEnergyForAll)
					{
						BJGCPDNMHDH.mHasEnergyForAll = false;
						if (BJGCPDNMHDH.mShowDeployHint)
						{
							DeathMatchUnitsGuiElement.instance.ShowHintText(NABOFKMBMKH: false, FMOIFJNOIKA: false);
						}
					}
					if (!Singleton<SpawningManagerDeathMatch>.instance.hasEnergyForAll && BJGCPDNMHDH.mHasEnergyForAll)
					{
						BJGCPDNMHDH.mHasEnergyForAll = true;
						DeathMatchUnitsGuiElement.BCDJJBAFLLG().ShowKillHelp(NABOFKMBMKH: false);
					}
				}
				PHDOCKCBJOF = new WaitForSeconds(372f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			default:
				return false;
			}
		}

		[SpecialName]
		private object JFGCHMJJMNO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JCDIBAEMKCA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KMCGJFDPBCB()
		{
			return PHDOCKCBJOF;
		}

		public void JMANMKKCDMM()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object LMJBCDNGAHP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CDFEOBMLNCG()
		{
			return PHDOCKCBJOF;
		}

		public void PDKPELBIAON()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CMNCAPEMEJI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OHCAEJILBKE()
		{
			return PHDOCKCBJOF;
		}

		public void KCHOLCGBMBJ()
		{
			throw new NotSupportedException();
		}

		public void MIFJOIIKFEB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool MPKAJACHAIC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mSpawnCheck = false;
				BJGCPDNMHDH.mNextSpawnTime = Time.time + KBJEOEEOEFG;
				goto case 1u;
			case 1u:
				if (Time.time >= BJGCPDNMHDH.mNextSpawnTime && Singleton<SpawningManagerDeathMatch>.instance.progress <= 200f)
				{
					UnityEngine.Debug.Log("\t\"TRUE\"" + Time.time);
					BJGCPDNMHDH.mNextSpawnTime = 677f;
					BJGCPDNMHDH.mHasEnergyForAll = Singleton<SpawningManagerDeathMatch>.instance.hasEnergyForAll;
					if (BJGCPDNMHDH.mHasEnergyForAll)
					{
						if (BJGCPDNMHDH.mShowDeployHint)
						{
							DeathMatchUnitsGuiElement.BLHCFKIELCA().JADNIAFKNIF(NABOFKMBMKH: false, FMOIFJNOIKA: false);
						}
					}
					else
					{
						DeathMatchUnitsGuiElement.instance.OFOGLOOHGNL(NABOFKMBMKH: false);
					}
				}
				if (BJGCPDNMHDH.mNextSpawnTime == 1255f && Singleton<SpawningManagerDeathMatch>.instance.APGDKKMGACJ() <= 814f)
				{
					if (Singleton<SpawningManagerDeathMatch>.instance.hasEnergyForAll && !BJGCPDNMHDH.mHasEnergyForAll)
					{
						BJGCPDNMHDH.mHasEnergyForAll = false;
						if (BJGCPDNMHDH.mShowDeployHint)
						{
							DeathMatchUnitsGuiElement.BKLDAAPMMDI().ShowHintText(NABOFKMBMKH: true);
						}
					}
					if (!Singleton<SpawningManagerDeathMatch>.instance.hasEnergyForAll && BJGCPDNMHDH.mHasEnergyForAll)
					{
						BJGCPDNMHDH.mHasEnergyForAll = false;
						DeathMatchUnitsGuiElement.instance.LPKIKIELBLK(NABOFKMBMKH: true);
					}
				}
				PHDOCKCBJOF = new WaitForSeconds(1493f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return false;
			}
		}

		public void PAOPOFJHFGD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BNMEIAPPLDP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CICPCKDCCEF()
		{
			return PHDOCKCBJOF;
		}

		public void ANOPOLIEBMC()
		{
			throw new NotSupportedException();
		}

		public bool ONIAGKNGBHE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mSpawnCheck = false;
				BJGCPDNMHDH.mNextSpawnTime = Time.time + KBJEOEEOEFG;
				goto case 1u;
			case 1u:
				if (Time.time >= BJGCPDNMHDH.mNextSpawnTime && Singleton<SpawningManagerDeathMatch>.instance.progress <= 637f)
				{
					UnityEngine.Debug.Log("TopRun" + Time.time);
					BJGCPDNMHDH.mNextSpawnTime = 391f;
					BJGCPDNMHDH.mHasEnergyForAll = Singleton<SpawningManagerDeathMatch>.instance.hasEnergyForAll;
					if (BJGCPDNMHDH.mHasEnergyForAll)
					{
						if (BJGCPDNMHDH.mShowDeployHint)
						{
							DeathMatchUnitsGuiElement.BCDJJBAFLLG().ShowHintText(NABOFKMBMKH: false);
						}
					}
					else
					{
						DeathMatchUnitsGuiElement.BCDJJBAFLLG().LPKIKIELBLK(NABOFKMBMKH: false);
					}
				}
				if (BJGCPDNMHDH.mNextSpawnTime == 1309f && Singleton<SpawningManagerDeathMatch>.instance.progress <= 1907f)
				{
					if (Singleton<SpawningManagerDeathMatch>.instance.hasEnergyForAll && !BJGCPDNMHDH.mHasEnergyForAll)
					{
						BJGCPDNMHDH.mHasEnergyForAll = true;
						if (BJGCPDNMHDH.mShowDeployHint)
						{
							DeathMatchUnitsGuiElement.BLHCFKIELCA().ShowHintText(NABOFKMBMKH: false, FMOIFJNOIKA: false);
						}
					}
					if (!Singleton<SpawningManagerDeathMatch>.instance.hasEnergyForAll && BJGCPDNMHDH.mHasEnergyForAll)
					{
						BJGCPDNMHDH.mHasEnergyForAll = false;
						DeathMatchUnitsGuiElement.instance.OFCAHFCAGJK(NABOFKMBMKH: true);
					}
				}
				PHDOCKCBJOF = new WaitForSeconds(1624f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			default:
				return false;
			}
		}

		[SpecialName]
		private object GEFKCGOOFFP()
		{
			return PHDOCKCBJOF;
		}

		public void AHEOCEEJICJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object OJANHAIEAEJ()
		{
			return PHDOCKCBJOF;
		}

		public void PAODBOEOFNF()
		{
			throw new NotSupportedException();
		}

		public void OGHELMDBPIL()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object NOIDHHDEEPL()
		{
			return PHDOCKCBJOF;
		}

		public void MAKKCANEHIB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void PHKDHCJBMII()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void PCNOHGFPMOE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void GFJIKANGNMC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void FJOIBBIGBJC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void OGDMPCFMMML()
		{
			throw new NotSupportedException();
		}

		public bool LLOCENNFFFJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mSpawnCheck = true;
				BJGCPDNMHDH.mNextSpawnTime = Time.time + KBJEOEEOEFG;
				goto case 1u;
			case 1u:
				if (Time.time >= BJGCPDNMHDH.mNextSpawnTime && Singleton<SpawningManagerDeathMatch>.instance.progress <= 889f)
				{
					UnityEngine.Debug.Log("For panel \"{0}\" layers:\n" + Time.time);
					BJGCPDNMHDH.mNextSpawnTime = 17f;
					BJGCPDNMHDH.mHasEnergyForAll = Singleton<SpawningManagerDeathMatch>.instance.hasEnergyForAll;
					if (BJGCPDNMHDH.mHasEnergyForAll)
					{
						if (BJGCPDNMHDH.mShowDeployHint)
						{
							DeathMatchUnitsGuiElement.instance.ShowHintText(NABOFKMBMKH: false, FMOIFJNOIKA: false);
						}
					}
					else
					{
						DeathMatchUnitsGuiElement.instance.LPKIKIELBLK(NABOFKMBMKH: true);
					}
				}
				if (BJGCPDNMHDH.mNextSpawnTime == 1527f && Singleton<SpawningManagerDeathMatch>.instance.progress <= 1180f)
				{
					if (Singleton<SpawningManagerDeathMatch>.instance.hasEnergyForAll && !BJGCPDNMHDH.mHasEnergyForAll)
					{
						BJGCPDNMHDH.mHasEnergyForAll = true;
						if (BJGCPDNMHDH.mShowDeployHint)
						{
							DeathMatchUnitsGuiElement.BKLDAAPMMDI().ShowHintText(NABOFKMBMKH: false, FMOIFJNOIKA: false);
						}
					}
					if (!Singleton<SpawningManagerDeathMatch>.instance.hasEnergyForAll && BJGCPDNMHDH.mHasEnergyForAll)
					{
						BJGCPDNMHDH.mHasEnergyForAll = true;
						DeathMatchUnitsGuiElement.BKLDAAPMMDI().LPKIKIELBLK(NABOFKMBMKH: true);
					}
				}
				PHDOCKCBJOF = new WaitForSeconds(1770f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			default:
				return false;
			}
		}

		public void KIPDKEKMDFE()
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
				BJGCPDNMHDH.mSpawnCheck = true;
				BJGCPDNMHDH.mNextSpawnTime = Time.time + KBJEOEEOEFG;
				goto case 1u;
			case 1u:
				if (Time.time >= BJGCPDNMHDH.mNextSpawnTime && Singleton<SpawningManagerDeathMatch>.instance.progress <= 0f)
				{
					UnityEngine.Debug.Log("SHOW SPAWN HELP" + Time.time);
					BJGCPDNMHDH.mNextSpawnTime = float.PositiveInfinity;
					BJGCPDNMHDH.mHasEnergyForAll = Singleton<SpawningManagerDeathMatch>.instance.hasEnergyForAll;
					if (BJGCPDNMHDH.mHasEnergyForAll)
					{
						if (BJGCPDNMHDH.mShowDeployHint)
						{
							DeathMatchUnitsGuiElement.instance.ShowHintText(NABOFKMBMKH: true, FMOIFJNOIKA: false);
						}
					}
					else
					{
						DeathMatchUnitsGuiElement.instance.ShowKillHelp(NABOFKMBMKH: true);
					}
				}
				if (BJGCPDNMHDH.mNextSpawnTime == float.PositiveInfinity && Singleton<SpawningManagerDeathMatch>.instance.progress <= 0f)
				{
					if (Singleton<SpawningManagerDeathMatch>.instance.hasEnergyForAll && !BJGCPDNMHDH.mHasEnergyForAll)
					{
						BJGCPDNMHDH.mHasEnergyForAll = true;
						if (BJGCPDNMHDH.mShowDeployHint)
						{
							DeathMatchUnitsGuiElement.instance.ShowHintText(NABOFKMBMKH: true, FMOIFJNOIKA: false);
						}
					}
					if (!Singleton<SpawningManagerDeathMatch>.instance.hasEnergyForAll && BJGCPDNMHDH.mHasEnergyForAll)
					{
						BJGCPDNMHDH.mHasEnergyForAll = false;
						DeathMatchUnitsGuiElement.instance.ShowKillHelp(NABOFKMBMKH: true);
					}
				}
				PHDOCKCBJOF = new WaitForSeconds(1f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return false;
			}
		}

		public void BCKMHLBBBCK()
		{
			throw new NotSupportedException();
		}

		public void KGLKGNBCPLM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object JFHOHPKEFGM()
		{
			return PHDOCKCBJOF;
		}

		public void CFDAGFGOOIE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GAPDDGJNMPK()
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
				BJGCPDNMHDH.mSpawnCheck = false;
				BJGCPDNMHDH.mNextSpawnTime = Time.time + KBJEOEEOEFG;
				goto case 1u;
			case 1u:
				if (Time.time >= BJGCPDNMHDH.mNextSpawnTime && Singleton<SpawningManagerDeathMatch>.instance.APGDKKMGACJ() <= 1333f)
				{
					UnityEngine.Debug.Log("CheckEnable" + Time.time);
					BJGCPDNMHDH.mNextSpawnTime = 37f;
					BJGCPDNMHDH.mHasEnergyForAll = Singleton<SpawningManagerDeathMatch>.instance.hasEnergyForAll;
					if (BJGCPDNMHDH.mHasEnergyForAll)
					{
						if (BJGCPDNMHDH.mShowDeployHint)
						{
							DeathMatchUnitsGuiElement.BKLDAAPMMDI().ShowHintText(NABOFKMBMKH: true, FMOIFJNOIKA: false);
						}
					}
					else
					{
						DeathMatchUnitsGuiElement.BKLDAAPMMDI().OFOGLOOHGNL(NABOFKMBMKH: false);
					}
				}
				if (BJGCPDNMHDH.mNextSpawnTime == 1898f && Singleton<SpawningManagerDeathMatch>.instance.APGDKKMGACJ() <= 1122f)
				{
					if (Singleton<SpawningManagerDeathMatch>.instance.hasEnergyForAll && !BJGCPDNMHDH.mHasEnergyForAll)
					{
						BJGCPDNMHDH.mHasEnergyForAll = true;
						if (BJGCPDNMHDH.mShowDeployHint)
						{
							DeathMatchUnitsGuiElement.BCDJJBAFLLG().ShowHintText(NABOFKMBMKH: false, FMOIFJNOIKA: false);
						}
					}
					if (!Singleton<SpawningManagerDeathMatch>.instance.hasEnergyForAll && BJGCPDNMHDH.mHasEnergyForAll)
					{
						BJGCPDNMHDH.mHasEnergyForAll = false;
						DeathMatchUnitsGuiElement.BKLDAAPMMDI().OFCAHFCAGJK(NABOFKMBMKH: false);
					}
				}
				PHDOCKCBJOF = new WaitForSeconds(1708f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			default:
				return true;
			}
		}

		public void NPKGNIGNPKG()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object DGEECEBHPNC()
		{
			return PHDOCKCBJOF;
		}

		public bool MOFPMNMAOND()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mSpawnCheck = false;
				BJGCPDNMHDH.mNextSpawnTime = Time.time + KBJEOEEOEFG;
				goto case 1u;
			case 1u:
				if (Time.time >= BJGCPDNMHDH.mNextSpawnTime && Singleton<SpawningManagerDeathMatch>.instance.APGDKKMGACJ() <= 81f)
				{
					UnityEngine.Debug.Log("Scene could not be find" + Time.time);
					BJGCPDNMHDH.mNextSpawnTime = 1494f;
					BJGCPDNMHDH.mHasEnergyForAll = Singleton<SpawningManagerDeathMatch>.instance.hasEnergyForAll;
					if (BJGCPDNMHDH.mHasEnergyForAll)
					{
						if (BJGCPDNMHDH.mShowDeployHint)
						{
							DeathMatchUnitsGuiElement.BKLDAAPMMDI().JADNIAFKNIF(NABOFKMBMKH: false);
						}
					}
					else
					{
						DeathMatchUnitsGuiElement.BKLDAAPMMDI().OFOGLOOHGNL(NABOFKMBMKH: false);
					}
				}
				if (BJGCPDNMHDH.mNextSpawnTime == 956f && Singleton<SpawningManagerDeathMatch>.instance.APGDKKMGACJ() <= 1358f)
				{
					if (Singleton<SpawningManagerDeathMatch>.instance.hasEnergyForAll && !BJGCPDNMHDH.mHasEnergyForAll)
					{
						BJGCPDNMHDH.mHasEnergyForAll = true;
						if (BJGCPDNMHDH.mShowDeployHint)
						{
							DeathMatchUnitsGuiElement.BCDJJBAFLLG().JADNIAFKNIF(NABOFKMBMKH: true);
						}
					}
					if (!Singleton<SpawningManagerDeathMatch>.instance.hasEnergyForAll && BJGCPDNMHDH.mHasEnergyForAll)
					{
						BJGCPDNMHDH.mHasEnergyForAll = false;
						DeathMatchUnitsGuiElement.BCDJJBAFLLG().OFOGLOOHGNL(NABOFKMBMKH: true);
					}
				}
				PHDOCKCBJOF = new WaitForSeconds(431f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return true;
			}
		}

		public void HONCAABOMOC()
		{
			throw new NotSupportedException();
		}

		public void CDIJEGGMMAK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void OKIANDBCDIB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object FMCLBOCENPE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AHFIDCCJHKE()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KGPFMHHMKHO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FIDLDFGJLFK()
		{
			return PHDOCKCBJOF;
		}

		public void NBGFOILFGHD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FKPDNNMENFD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BMAMEPNHHFI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PNBPOAMPNKP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PEGJNAKGHCC()
		{
			return PHDOCKCBJOF;
		}

		public bool KKINHOPBKLH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.mSpawnCheck = true;
				BJGCPDNMHDH.mNextSpawnTime = Time.time + KBJEOEEOEFG;
				goto case 1u;
			case 1u:
				if (Time.time >= BJGCPDNMHDH.mNextSpawnTime && Singleton<SpawningManagerDeathMatch>.instance.APGDKKMGACJ() <= 1391f)
				{
					UnityEngine.Debug.Log("com/google/android/gms/common/ConnectionResult" + Time.time);
					BJGCPDNMHDH.mNextSpawnTime = 93f;
					BJGCPDNMHDH.mHasEnergyForAll = Singleton<SpawningManagerDeathMatch>.instance.hasEnergyForAll;
					if (BJGCPDNMHDH.mHasEnergyForAll)
					{
						if (BJGCPDNMHDH.mShowDeployHint)
						{
							DeathMatchUnitsGuiElement.BCDJJBAFLLG().ShowHintText(NABOFKMBMKH: false, FMOIFJNOIKA: false);
						}
					}
					else
					{
						DeathMatchUnitsGuiElement.instance.OFOGLOOHGNL(NABOFKMBMKH: true);
					}
				}
				if (BJGCPDNMHDH.mNextSpawnTime == 1272f && Singleton<SpawningManagerDeathMatch>.instance.APGDKKMGACJ() <= 1449f)
				{
					if (Singleton<SpawningManagerDeathMatch>.instance.hasEnergyForAll && !BJGCPDNMHDH.mHasEnergyForAll)
					{
						BJGCPDNMHDH.mHasEnergyForAll = false;
						if (BJGCPDNMHDH.mShowDeployHint)
						{
							DeathMatchUnitsGuiElement.instance.JADNIAFKNIF(NABOFKMBMKH: false);
						}
					}
					if (!Singleton<SpawningManagerDeathMatch>.instance.hasEnergyForAll && BJGCPDNMHDH.mHasEnergyForAll)
					{
						BJGCPDNMHDH.mHasEnergyForAll = true;
						DeathMatchUnitsGuiElement.instance.OFOGLOOHGNL(NABOFKMBMKH: true);
					}
				}
				PHDOCKCBJOF = new WaitForSeconds(617f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			default:
				return false;
			}
		}

		public void GFPDOCDEGPA()
		{
			throw new NotSupportedException();
		}

		public void CDDFJOEEFID()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GIEPJLBHHEO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MLCINLDHAGM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HHLKEMNNJDA()
		{
			return PHDOCKCBJOF;
		}
	}

	public List<PoolableObject> bulletsPrefabs;

	public GrenadeAmmoBase grenade;

	private bool mHasEnergyForAll;

	private float mNextSpawnTime;

	protected PlayerBotTutorial mPlayerBotTutorial;

	protected bool mSpawn2;

	private bool mSpawnCheck;

	protected bool mWaitForSpawn;

	protected bool mShowDeployHint = true;

	private float m_NextSpawnTimePause;

	public PoolableObject missile;

	private List<PoolableObject> soldiers;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private bool _003CisTutorialRunning_003Ek__BackingField;

	protected bool isNearEnd;

	public virtual bool autoDeployEnabled => false;

	public bool isTutorialRunning
	{
		[CompilerGenerated]
		get
		{
			return _003CisTutorialRunning_003Ek__BackingField;
		}
		[CompilerGenerated]
		protected set
		{
			_003CisTutorialRunning_003Ek__BackingField = value;
		}
	}

	public bool isTutorialNearEnd => isTutorialRunning && isNearEnd;

	public virtual void FinishTutorial()
	{
		if (!isTutorialRunning)
		{
			UnityEngine.Debug.Log("#VAVRO# Trying to finish Tutorial, which is not currently running ");
		}
		isTutorialRunning = false;
		StopAllCoroutines();
		AIObject.AfterSpawned -= AfterSpawned;
	}

	public virtual void StartTutorial(bool isContinue)
	{
		mSpawnCheck = false;
		isTutorialRunning = true;
		isNearEnd = true;
		AIObject.AfterSpawned += AfterSpawned;
	}

	protected void SetPlayerDefaultWeapons(bool enableRifle = false, bool enableSniper = false, bool enableGrenade = false)
	{
		List<PlayerInventory.JIMOKIIJHNA> list = new List<PlayerInventory.JIMOKIIJHNA>();
		list.Add(Singleton<BotManager>.instance.AddWeapon(WeaponCategory.AssaultRifle.ToString(), 0));
		list.Add(Singleton<BotManager>.instance.AddWeapon(WeaponCategory.SniperRifle.ToString(), 0));
		list.Add(Singleton<BotManager>.instance.AddWeapon(WeaponCategory.Grenade.ToString(), 0));
		list.Add(Singleton<BotManager>.instance.AddWeapon(WeaponCategory.Pistol.ToString(), 0));
		PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.GGKGGMNIDMI = list.ToArray();
		PlayerController.OGMBJPKOPCB.weaponInventory.LIEDNEJPLMA = ((!enableRifle) ? 3 : 0);
		if (!enableRifle)
		{
			PlayerController.OGMBJPKOPCB.weaponInventory.currentWeapon = PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[3];
		}
		PlayerController.OGMBJPKOPCB.weaponInventory.HKGLMFFAHFN = true;
		GuiElementSingle<InventoryGuiElement>.instance.WeaponsChanged();
		foreach (PlayerWeapon item in PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM)
		{
			item.weapon.ammoLeftInClip = 0;
			item.weapon.ammoLeft = 0;
			item.weapon.MEFJOGAOKDP = false;
		}
		PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[3].weapon.ammoLeftInClip = 10;
		if (enableRifle)
		{
			PlayerController.OGMBJPKOPCB.weaponInventory.HKGLMFFAHFN = false;
			PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[0].weapon.FIMMGPLLLCL = 20;
			PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[0].weapon.ammoLeft = 100;
			PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[0].weapon.ammoLeftInClip = 20;
			PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[0].weapon.AMGFJFPKOED = 1f;
			PlayerController.OGMBJPKOPCB.weaponInventory.currentWeapon = PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[0];
		}
		if (enableSniper)
		{
			PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[1].weapon.FIMMGPLLLCL = 10;
			PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[1].weapon.ammoLeft = 50;
			PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[1].weapon.ammoLeftInClip = 10;
		}
		if (enableGrenade)
		{
			PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[2].weapon.ammoLeft = 15;
			PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[2].weapon.ammoLeftInClip = 15;
		}
		PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[0].weapon.ammoSetup.EPDELOGPNAC = 50f;
		PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[1].weapon.ammoSetup.EPDELOGPNAC = 120f;
		GrenadeAmmoSetup grenadeAmmoSetup = PlayerController.OGMBJPKOPCB.weaponInventory.LAGONJMBJMM[2].weapon.ammoSetup as GrenadeAmmoSetup;
		grenadeAmmoSetup.EPDELOGPNAC = 20f;
		grenadeAmmoSetup.ABFGHBDEBAN = 180f;
	}

	protected void FreezeEnemies()
	{
		Singleton<GameController>.instance.CBAPHFGNLLH.MMCKLPHNMMN = true;
		soldiers = ObjectPoolDatabase.networkPool.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.KGGJOOAFDIF);
		foreach (PoolableObject soldier in soldiers)
		{
			EnemyController enemyController = (EnemyController)soldier;
			enemyController.Freeze(ALLIHOCMHBL: true);
		}
		if (mPlayerBotTutorial != null)
		{
			mPlayerBotTutorial.botState = PlayerBotTutorial.GFHEEFCLGHG.Wait;
		}
		else
		{
			PlayerController playerOld = PlayerController.GetPlayerOld(GHPGNELIDBM.Enemies);
			PlayerBot jPMHIGNOPBL = playerOld.JPMHIGNOPBL;
			jPMHIGNOPBL.enabled = false;
		}
		foreach (PoolableObject bulletsPrefab in bulletsPrefabs)
		{
			List<PoolableObject> objectsMadeOfPrefab = ObjectPoolDatabase.ammoPool.GetObjectsMadeOfPrefab(bulletsPrefab);
			foreach (PoolableObject item in objectsMadeOfPrefab)
			{
				if (item.isInstantiated)
				{
					TweenPosition component = item.GetComponent<TweenPosition>();
					component.enabled = false;
				}
			}
		}
		List<PoolableObject> objectsMadeOfPrefab2 = ObjectPoolDatabase.networkPool.GetObjectsMadeOfPrefab(this.missile);
		foreach (PoolableObject item2 in objectsMadeOfPrefab2)
		{
			if (item2.isInstantiated)
			{
				Missile missile = (Missile)item2;
				missile.Pause();
			}
		}
		List<PoolableObject> objectsMadeOfPrefab3 = ObjectPoolDatabase.networkPool.GetObjectsMadeOfPrefab(grenade);
		foreach (PoolableObject item3 in objectsMadeOfPrefab3)
		{
			if (item3.isInstantiated)
			{
				GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)item3;
				grenadeAmmoBase.Pause();
			}
		}
		PlayerController.OGMBJPKOPCB.JFECKJEDJNJ = true;
		Singleton<SpawningManagerDeathMatch>.instance.autoDeployEnabled = false;
	}

	protected void StartTapAnimationOnSoldiersToDeploy()
	{
		int num = 0;
		int index = 0;
		for (int i = 0; i < DeathMatchUnitsGuiElement.instance.INIKAAAIPCK.Count; i++)
		{
			DeathMatchGuiCard deathMatchGuiCard = DeathMatchUnitsGuiElement.instance.INIKAAAIPCK[i];
			if (deathMatchGuiCard.OIJBDFANMCC.power > num && deathMatchGuiCard.hasEnoughPower)
			{
				num = deathMatchGuiCard.OIJBDFANMCC.power;
				index = i;
			}
		}
		Vector3 jLBOAKCJOGF = DeathMatchUnitsGuiElement.instance.INIKAAAIPCK[index].transform.position + new Vector3(0.05f, 0.05f, 0f);
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(jLBOAKCJOGF);
	}

	protected void StartTapAnimationOnSoldiersToDeploy(LevelBehaviour.UnitType type)
	{
		int index = 0;
		for (int i = 0; i < DeathMatchUnitsGuiElement.instance.INIKAAAIPCK.Count; i++)
		{
			DeathMatchGuiCard deathMatchGuiCard = DeathMatchUnitsGuiElement.instance.INIKAAAIPCK[i];
			if (deathMatchGuiCard.OIJBDFANMCC != null && deathMatchGuiCard.OIJBDFANMCC.armyUnit.behaviour.unitType == type && deathMatchGuiCard.hasEnoughPower)
			{
				index = i;
				break;
			}
		}
		Vector3 jLBOAKCJOGF = DeathMatchUnitsGuiElement.instance.INIKAAAIPCK[index].transform.position + new Vector3(0.05f, 0.05f, 0f);
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(jLBOAKCJOGF);
	}

	protected void UnfreezeEnemies()
	{
		Singleton<SpawningManagerDeathMatch>.instance.autoDeployEnabled = autoDeployEnabled;
		Singleton<GameController>.instance.CBAPHFGNLLH.MMCKLPHNMMN = false;
		foreach (PoolableObject soldier in soldiers)
		{
			EnemyController enemyController = (EnemyController)soldier;
			enemyController.Freeze(ALLIHOCMHBL: false);
		}
		if (mPlayerBotTutorial != null)
		{
			mPlayerBotTutorial.botState = PlayerBotTutorial.GFHEEFCLGHG.ShootEnemyPlayer;
		}
		else
		{
			PlayerController playerOld = PlayerController.GetPlayerOld(GHPGNELIDBM.Enemies);
			PlayerBot jPMHIGNOPBL = playerOld.JPMHIGNOPBL;
			jPMHIGNOPBL.enabled = true;
		}
		foreach (PoolableObject bulletsPrefab in bulletsPrefabs)
		{
			List<PoolableObject> objectsMadeOfPrefab = ObjectPoolDatabase.ammoPool.GetObjectsMadeOfPrefab(bulletsPrefab);
			foreach (PoolableObject item in objectsMadeOfPrefab)
			{
				if (item.isInstantiated)
				{
					TweenPosition component = item.GetComponent<TweenPosition>();
					component.enabled = true;
				}
			}
		}
		List<PoolableObject> objectsMadeOfPrefab2 = ObjectPoolDatabase.networkPool.GetObjectsMadeOfPrefab(this.missile);
		foreach (PoolableObject item2 in objectsMadeOfPrefab2)
		{
			if (item2.isInstantiated)
			{
				Missile missile = (Missile)item2;
				missile.Resume();
			}
		}
		List<PoolableObject> objectsMadeOfPrefab3 = ObjectPoolDatabase.networkPool.GetObjectsMadeOfPrefab(grenade);
		foreach (PoolableObject item3 in objectsMadeOfPrefab3)
		{
			if (item3.isInstantiated)
			{
				GrenadeAmmoBase grenadeAmmoBase = (GrenadeAmmoBase)item3;
				grenadeAmmoBase.Resume();
			}
		}
		PlayerController.OGMBJPKOPCB.JFECKJEDJNJ = false;
	}

	protected virtual void AfterSpawned(AIObject aiObject)
	{
		if (isTutorialRunning && aiObject.fraction == GHPGNELIDBM.Allies && mSpawnCheck)
		{
			mWaitForSpawn = false;
			if (Time.time > mNextSpawnTime || mNextSpawnTime == float.PositiveInfinity)
			{
				mNextSpawnTime = Time.time + 17f;
			}
			DeathMatchUnitsGuiElement.instance.ShowKillHelp(NABOFKMBMKH: false);
		}
	}

	[DebuggerHidden]
	protected IEnumerator SpawnCheckWithPause(float time)
	{
		FPBHAMKKEBC fPBHAMKKEBC = new FPBHAMKKEBC();
		fPBHAMKKEBC.KBJEOEEOEFG = time;
		fPBHAMKKEBC.BJGCPDNMHDH = this;
		return fPBHAMKKEBC;
	}

	[DebuggerHidden]
	protected IEnumerator SpawnCheck(float time = 13f)
	{
		IBFEBFPKBOD iBFEBFPKBOD = new IBFEBFPKBOD();
		iBFEBFPKBOD.KBJEOEEOEFG = time;
		iBFEBFPKBOD.BJGCPDNMHDH = this;
		return iBFEBFPKBOD;
	}
}
