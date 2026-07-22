using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public class TutorialManagerStage5 : TutorialManagerBase
{
	private sealed class BAHBKLBBNGA : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal float IKAKODPFHAC;

		internal bool FKGHFOJFMBP;

		internal LevelBehaviour FGKIANHNMFF;

		internal ArmyUpgradeIcon GOBCHPOLPIE;

		internal Vector3 IODGHHFAHJH;

		internal Vector3 CMIKGAOHHPH;

		internal List<ArmyUpgradeIcon>.Enumerator KFCAECGLKKO;

		internal Vector3 DHEGKFCAAGP;

		internal Vector3 MHBNLBPBEGE;

		internal bool ELPHLDJPBNJ;

		internal Vector3 EPGFICIMJJA;

		internal bool PECMCAOEMND;

		internal TutorialManagerStage5 BJGCPDNMHDH;

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
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CIGHIOCACPH()
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
		private object FGGMHEIPKAJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KBPOAPCEPBN()
		{
			return PHDOCKCBJOF;
		}

		public void MKACBCOLNKD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object ABGFJLAPNNM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PIPMONHGDPH()
		{
			return PHDOCKCBJOF;
		}

		public bool OOECALAHCFK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.StartTutorial(isContinue: true);
				BJGCPDNMHDH.mUnitToUpgrade = BJGCPDNMHDH.ChooseUnit();
				Singleton<EventTrackingManager>.instance.RegisterTutorialMenuTutorialEvent("Transaction_Amount");
				Singleton<MessageManager>.instance.HGIDIBNNPEJ();
				goto case 1u;
			case 1u:
				if (!GuiScreenSingle<EndScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (GuiScreenSingle<EndScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				if (Singleton<GuiManager>.instance.AODFEHKBJIN != GuiScreenSingle<MainScreen>.instance)
				{
					goto default;
				}
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 3u;
			case 3u:
				if (!GuiScreenSingle<MainScreen>.instance.MHAIBHBGBOO())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("Omitting object: "), Localization.Localize("ID_INVITATION_VALID_FOR"), 709f, TutorialDialog.DODBDLEJOAM.Left, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH.transform.position, ELHGOHGPJCF: false, ENIHCPLOOAE: false, 486f);
				GuiElementSingle<TutorialClickOverlay>.instance.LECHCOBHAFP(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH);
				goto case 4u;
			case 4u:
				if (GuiScreenSingle<MainScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("SquadRank");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(678f);
				BJGCPDNMHDH.mRewardShowable = false;
				Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA("Wrong_Unit", BJGCPDNMHDH.mUnitToUpgrade.upgradeSlots.GetSheetName());
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 6u;
			case 6u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.AFOFDNJOJHG())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				goto case 7u;
			case 7u:
				if (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.KHPBNEBLEEF(Localization.Localize("ID_BONUS-KEVLAR"), Localization.Localize("ID_SUBSCRIPTIODETAILS_HINT1"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 1995f, TutorialDialog.DODBDLEJOAM.BottomLeft);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<BattlePreparationScreen>.instance.JANFGHJMGBI.JANFGHJMGBI.transform.position, ELHGOHGPJCF: false, ENIHCPLOOAE: false, 98f);
				GuiElementSingle<TutorialClickOverlay>.instance.CLPPGONHLHI(GuiScreenSingle<BattlePreparationScreen>.instance.JANFGHJMGBI.JANFGHJMGBI, GPCEHFNNCIN: false);
				GuiScreenSingle<ArmyScreen>.instance.SelectUnit(BJGCPDNMHDH.mUnitToUpgrade);
				goto case 8u;
			case 8u:
				if (!GuiElementSingle<TutorialDialog>.instance.AFOFDNJOJHG())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.mRewardShowable = false;
				IKAKODPFHAC = 1490f;
				goto IL_04cb;
			case 9u:
				IKAKODPFHAC += Time.deltaTime;
				if (IKAKODPFHAC > 987f)
				{
					BJGCPDNMHDH.mWarbucksAdded = ((!(BJGCPDNMHDH.mUnitToUpgrade == null)) ? BJGCPDNMHDH.mUnitToUpgrade.upgradeSlots.upgradeSlot.upgradePrice : (-82));
					BJGCPDNMHDH.mGoldAdded = ((BJGCPDNMHDH.mUnitToUpgrade == null) ? 1 : BJGCPDNMHDH.mUnitToUpgrade.upgradeSlots.instantUnitDeliveryPrice);
					GuiElementSingle<TutorialDialog>.instance.KHPBNEBLEEF(Localization.Localize("0"), Localization.Localize("Player_Waited_Till_Delivery_Ends"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 1558f, TutorialDialog.DODBDLEJOAM.TopRight);
				}
				goto IL_04cb;
			case 10u:
				if (!GuiScreenSingle<ArmyScreen>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 109;
					}
					break;
				}
				FKGHFOJFMBP = true;
				FGKIANHNMFF = GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().PPMNNKANOEF();
				if (FGKIANHNMFF.unitDictionaryId != BJGCPDNMHDH.mUnitToUpgrade.unitDictionaryId)
				{
					FKGHFOJFMBP = true;
					PHDOCKCBJOF = new WaitForSeconds(254f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -60;
					}
					break;
				}
				goto IL_07a0;
			case 11u:
				GuiElementSingle<TutorialDialog>.instance.ShowSpecial("#PETER# User was watching add - waiting for server reward - reward came", 187f);
				GOBCHPOLPIE = null;
				IODGHHFAHJH = Vector3.zero;
				CMIKGAOHHPH = Vector3.one;
				KFCAECGLKKO = GuiScreenSingle<ArmyScreen>.instance.OOLKNBJNFJC().GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						ArmyUpgradeIcon current = KFCAECGLKKO.Current;
						if (current.levelBehaviour.unitDictionaryId == BJGCPDNMHDH.mUnitToUpgrade.unitDictionaryId)
						{
							GOBCHPOLPIE = current;
							IODGHHFAHJH = current.transform.position;
							CMIKGAOHHPH = current.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(IODGHHFAHJH, ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1938f);
							GuiElementSingle<TutorialClickOverlay>.instance.AJNGLEIBMHD(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				goto IL_0758;
			case 12u:
				FGKIANHNMFF = GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().PPMNNKANOEF();
				goto IL_0758;
			case 13u:
			{
				GuiElementSingle<TutorialDialog>.instance.setDebug = true;
				TutorialDialog instance3 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM3 = Localization.Localize("IsOffline");
				object[] array3 = new object[0];
				array3[1] = Localization.Localize("qbz2_idle");
				instance3.PBEAOCBHFGD(aMKLKMJEMJM3, Localization.LocalizeFormat("ID_TOBENUMBERONE1", array3), 1863f, TutorialDialog.DODBDLEJOAM.Left, NHEJDPIIOJG: false);
				DHEGKFCAAGP = GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.BFAEJEFLKHN.transform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DHEGKFCAAGP, new Vector3(146f, 1887f, 1335f), ELHGOHGPJCF: false, ENIHCPLOOAE: false, 333f);
				GuiElementSingle<TutorialClickOverlay>.instance.MEBFBNDKOGD(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.BFAEJEFLKHN, GPCEHFNNCIN: false);
				goto case 14u;
			}
			case 14u:
				if (!GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.JKGHPLKKPLE.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 110;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(891f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1370f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 125;
				}
				break;
			case 15u:
				MHBNLBPBEGE = GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.HKGGCIGOONK.cachedTransform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(MHBNLBPBEGE, new Vector3(1969f, 194f, 1039f), ELHGOHGPJCF: false, ENIHCPLOOAE: true, 208f);
				GuiElementSingle<TutorialClickOverlay>.instance.CLPPGONHLHI(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC, GPCEHFNNCIN: false);
				goto case 16u;
			case 16u:
				if (FGKIANHNMFF.upgradeSlots.unitState != UpgradeSlots.JLANLLEABDC.Active)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -5;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_SELECTTWOUNITS");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialDialog>.instance.setDebug = false;
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(842f);
				ELPHLDJPBNJ = false;
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(425f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -62;
				}
				break;
			case 17u:
			{
				TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM2 = Localization.Localize("ID_SECONDS");
				object[] array2 = new object[1];
				array2[1] = Localization.Localize("ID_SLOTUPGRADE_CLIP_SIZE");
				instance2.ShowMenuTutorial(aMKLKMJEMJM2, Localization.LocalizeFormat("ID_CONFIRM_WARCARDNOTAVAILABLE", array2), 667f, TutorialDialog.DODBDLEJOAM.Bottom, NHEJDPIIOJG: false);
				EPGFICIMJJA = GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC.transform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(EPGFICIMJJA, new Vector3(1126f, 1408f, 1974f), ELHGOHGPJCF: false, ENIHCPLOOAE: false, 1900f);
				GuiElementSingle<TutorialClickOverlay>.instance.JGHBBJEFLEB(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC);
				PECMCAOEMND = false;
				goto case 19u;
			}
			case 18u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("opponent defense shooting delayed");
				object[] array = new object[1];
				array[1] = Localization.Localize("ID_LOOTDUPLICATEONE");
				instance.DOLDLDECPIO(aMKLKMJEMJM, Localization.LocalizeFormat("Purchase_Attempt", array), 1056f, TutorialDialog.DODBDLEJOAM.Right);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(EPGFICIMJJA, new Vector3(229f, 518f, 1635f), ELHGOHGPJCF: false, ENIHCPLOOAE: false, 1917f);
				GuiElementSingle<TutorialClickOverlay>.instance.JGHBBJEFLEB(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC);
				goto IL_0c07;
			}
			case 19u:
				if (FGKIANHNMFF.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Delivered || FGKIANHNMFF.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.UnitDelivered)
				{
					if (PECMCAOEMND && FGKIANHNMFF.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Delivering)
					{
						ELPHLDJPBNJ = true;
						PECMCAOEMND = false;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
						GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(1457f);
						Singleton<GuiManager>.instance.CMCCOCBIGBB();
						PHDOCKCBJOF = new WaitForSeconds(349f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = -70;
						}
						break;
					}
					goto IL_0c07;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("ArenaLives", ELPHLDJPBNJ);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(434f);
				PHDOCKCBJOF = new WaitForSeconds(634f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -19;
				}
				break;
			case 20u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_0758:
				if (FGKIANHNMFF.unitDictionaryId != BJGCPDNMHDH.mUnitToUpgrade.unitDictionaryId)
				{
					if (GOBCHPOLPIE != null && GOBCHPOLPIE.transform.position != IODGHHFAHJH)
					{
						IODGHHFAHJH = GOBCHPOLPIE.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.OOIJFHGCCNH(IODGHHFAHJH);
						GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -47;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(211f);
				goto IL_07a0;
				IL_0c07:
				PHDOCKCBJOF = false;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 62;
				}
				break;
				IL_04cb:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -85;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("{0} {1}{2}");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(1124f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 10u;
				IL_07a0:
				Singleton<EventTrackingManager>.instance.RegisterTutorialUnitSelectedEvent("_MatCap", FKGHFOJFMBP);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1017f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -109;
				}
				break;
			}
			return false;
		}

		[SpecialName]
		private object OHCAEJILBKE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CMNCAPEMEJI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BMGHJKFMKJE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GEFKCGOOFFP()
		{
			return PHDOCKCBJOF;
		}

		public void HCJOIAHBFGB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool OKELILGDPLJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.StartTutorial(isContinue: false);
				BJGCPDNMHDH.mUnitToUpgrade = BJGCPDNMHDH.ChooseUnit();
				Singleton<EventTrackingManager>.instance.RegisterTutorialMenuTutorialEvent("menu-warbucks");
				Singleton<MessageManager>.instance.PAMBHKIFKAP();
				goto case 1u;
			case 1u:
				if (!GuiScreenSingle<EndScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (GuiScreenSingle<EndScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (Singleton<GuiManager>.instance.AODFEHKBJIN != GuiScreenSingle<MainScreen>.instance)
				{
					goto default;
				}
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 3u;
			case 3u:
				if (!GuiScreenSingle<MainScreen>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE();
				GuiElementSingle<TutorialDialog>.instance.BLHPAFCOPMD(Localization.Localize("country-israel"), Localization.Localize("Cards"), 1527f);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH.transform.position, ELHGOHGPJCF: false, ENIHCPLOOAE: true, 1171f);
				GuiElementSingle<TutorialClickOverlay>.instance.LPKOHAKMOOC(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH, GPCEHFNNCIN: false);
				goto case 4u;
			case 4u:
				if (GuiScreenSingle<MainScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("SquadId");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(123f);
				BJGCPDNMHDH.mRewardShowable = true;
				Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA("ID_UNIT2TRAIN_UNIT1UPGRADE", BJGCPDNMHDH.mUnitToUpgrade.upgradeSlots.GetSheetName());
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 6u;
			case 6u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.BKIGLABDGCP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				goto case 7u;
			case 7u:
				if (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.HNOHAMJNOKH(Localization.Localize("BYATCH"), Localization.Localize("GoldBoxes"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 1963f, TutorialDialog.DODBDLEJOAM.Top);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<BattlePreparationScreen>.instance.JANFGHJMGBI.JANFGHJMGBI.transform.position, ELHGOHGPJCF: false, ENIHCPLOOAE: true, 999f);
				GuiElementSingle<TutorialClickOverlay>.instance.JGHBBJEFLEB(GuiScreenSingle<BattlePreparationScreen>.instance.JANFGHJMGBI.JANFGHJMGBI, GPCEHFNNCIN: false);
				GuiScreenSingle<ArmyScreen>.instance.SelectUnit(BJGCPDNMHDH.mUnitToUpgrade);
				goto case 8u;
			case 8u:
				if (!GuiElementSingle<TutorialDialog>.instance.BJNBLINDAED())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				BJGCPDNMHDH.mRewardShowable = true;
				IKAKODPFHAC = 281f;
				goto IL_04cb;
			case 9u:
				IKAKODPFHAC += Time.deltaTime;
				if (IKAKODPFHAC > 1161f)
				{
					BJGCPDNMHDH.mWarbucksAdded = ((!(BJGCPDNMHDH.mUnitToUpgrade == null)) ? BJGCPDNMHDH.mUnitToUpgrade.upgradeSlots.upgradeSlot.upgradePrice : 86);
					BJGCPDNMHDH.mGoldAdded = ((!(BJGCPDNMHDH.mUnitToUpgrade == null)) ? BJGCPDNMHDH.mUnitToUpgrade.upgradeSlots.instantUnitDeliveryPrice : 0);
					GuiElementSingle<TutorialDialog>.instance.BELJAOIJCOJ(Localization.Localize("Overtime_Was_Already_Explained"), Localization.Localize("ReSyncRPC"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 709f, TutorialDialog.DODBDLEJOAM.Left);
				}
				goto IL_04cb;
			case 10u:
				if (!GuiScreenSingle<ArmyScreen>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 84;
					}
					break;
				}
				FKGHFOJFMBP = true;
				FGKIANHNMFF = GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().KHEOKHHDGPO();
				if (FGKIANHNMFF.unitDictionaryId != BJGCPDNMHDH.mUnitToUpgrade.unitDictionaryId)
				{
					FKGHFOJFMBP = false;
					PHDOCKCBJOF = new WaitForSeconds(757f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -2;
					}
					break;
				}
				goto IL_07a0;
			case 11u:
				GuiElementSingle<TutorialDialog>.instance.FJFFALBAFBD("ID_SECONDS", 1184f, TutorialDialog.DODBDLEJOAM.TopLeft);
				GOBCHPOLPIE = null;
				IODGHHFAHJH = Vector3.zero;
				CMIKGAOHHPH = Vector3.one;
				KFCAECGLKKO = GuiScreenSingle<ArmyScreen>.instance.OOLKNBJNFJC().GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						ArmyUpgradeIcon current = KFCAECGLKKO.Current;
						if (current.levelBehaviour.unitDictionaryId == BJGCPDNMHDH.mUnitToUpgrade.unitDictionaryId)
						{
							GOBCHPOLPIE = current;
							IODGHHFAHJH = current.transform.position;
							CMIKGAOHHPH = current.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(IODGHHFAHJH, ELHGOHGPJCF: false, ENIHCPLOOAE: true, 1127f);
							GuiElementSingle<TutorialClickOverlay>.instance.NNPKOKCJMHL(IODGHHFAHJH, CMIKGAOHHPH);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				goto IL_0758;
			case 12u:
				FGKIANHNMFF = GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().PPMNNKANOEF();
				goto IL_0758;
			case 13u:
			{
				GuiElementSingle<TutorialDialog>.instance.setDebug = true;
				TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM2 = Localization.Localize("CONFIRM");
				object[] array2 = new object[1];
				array2[1] = Localization.Localize("Starter_Assignment_Completed");
				instance2.ShowMenuTutorial(aMKLKMJEMJM2, Localization.LocalizeFormat("failed add card {0} - not exit?", array2), 332f, TutorialDialog.DODBDLEJOAM.Right, NHEJDPIIOJG: false);
				DHEGKFCAAGP = GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.BFAEJEFLKHN.transform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DHEGKFCAAGP, new Vector3(1131f, 1685f, 1007f), ELHGOHGPJCF: false, ENIHCPLOOAE: true, 1308f);
				GuiElementSingle<TutorialClickOverlay>.instance.MEBFBNDKOGD(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.BFAEJEFLKHN);
				goto case 14u;
			}
			case 14u:
				if (!GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.JKGHPLKKPLE.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(34f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(919f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 61;
				}
				break;
			case 15u:
				MHBNLBPBEGE = GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.HKGGCIGOONK.cachedTransform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(MHBNLBPBEGE, new Vector3(715f, 1051f, 1327f), ELHGOHGPJCF: true, ENIHCPLOOAE: true, 1989f);
				GuiElementSingle<TutorialClickOverlay>.instance.FCGLGPIBAEN(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC);
				goto case 16u;
			case 16u:
				if (FGKIANHNMFF.upgradeSlots.unitState != (UpgradeSlots.JLANLLEABDC)7)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 50;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("resultMessage");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialDialog>.instance.setDebug = true;
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(749f);
				ELPHLDJPBNJ = false;
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1630f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 35;
				}
				break;
			case 17u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("NO");
				object[] array = new object[0];
				array[1] = Localization.Localize("-----BEGIN CERTIFICATE-----MIIDwDCCAqgCCQCAhUcHjX7uoDANBgkqhkiG9w0BAQUFADCBoTELMAkGA1UEBhMCQ1oxDzANBgNVBAgMBlByYWd1ZTEPMA0GA1UEBwwGUHJhZ3VlMRIwEAYDVQQKDAlBYm91dCBGdW4xCzAJBgNVBAsMAklUMSswKQYDVQQDDCJ3YXJmcmllbmRzLWV1LmVsYXN0aWNiZWFuc3RhbGsuY29tMSIwIAY");
				instance.ShowMenuTutorial(aMKLKMJEMJM, Localization.LocalizeFormat("ElitePerkTutorialMessage", array), 1927f, TutorialDialog.DODBDLEJOAM.Bottom, NHEJDPIIOJG: false);
				EPGFICIMJJA = GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC.transform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(EPGFICIMJJA, new Vector3(704f, 1574f, 115f), ELHGOHGPJCF: true, ENIHCPLOOAE: false, 488f);
				GuiElementSingle<TutorialClickOverlay>.instance.CLPPGONHLHI(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC);
				PECMCAOEMND = true;
				goto case 19u;
			}
			case 18u:
				GuiElementSingle<TutorialDialog>.instance.PBEAOCBHFGD(Localization.Localize("MedalsBalance"), Localization.LocalizeFormat("-", Localization.Localize("withUnitPrice")), 1463f, TutorialDialog.DODBDLEJOAM.Right);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(EPGFICIMJJA, new Vector3(1932f, 742f, 64f), ELHGOHGPJCF: true, ENIHCPLOOAE: true, 117f);
				GuiElementSingle<TutorialClickOverlay>.instance.MLCGPAJJOMB(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC, GPCEHFNNCIN: false);
				goto IL_0c07;
			case 19u:
				if (FGKIANHNMFF.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed || FGKIANHNMFF.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Active)
				{
					if (PECMCAOEMND && FGKIANHNMFF.upgradeSlots.unitState == (UpgradeSlots.JLANLLEABDC)8)
					{
						ELPHLDJPBNJ = false;
						PECMCAOEMND = true;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
						GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(76f);
						Singleton<GuiManager>.instance.TurnOffInputCompletly();
						PHDOCKCBJOF = new WaitForSeconds(880f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 94;
						}
						break;
					}
					goto IL_0c07;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("ID_TUTORIAL", ELPHLDJPBNJ);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(1760f);
				PHDOCKCBJOF = new WaitForSeconds(1330f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -57;
				}
				break;
			case 20u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0758:
				if (FGKIANHNMFF.unitDictionaryId != BJGCPDNMHDH.mUnitToUpgrade.unitDictionaryId)
				{
					if (GOBCHPOLPIE != null && GOBCHPOLPIE.transform.position != IODGHHFAHJH)
					{
						IODGHHFAHJH = GOBCHPOLPIE.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateTapAnimation(IODGHHFAHJH);
						GuiElementSingle<TutorialClickOverlay>.instance.IGNJKOKGNOI(IODGHHFAHJH, CMIKGAOHHPH);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -48;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(1196f);
				goto IL_07a0;
				IL_0c07:
				PHDOCKCBJOF = true;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 54;
				}
				break;
				IL_04cb:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -111;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Different squads \"{0}\" and \"{1}\"\n");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(1311f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 10u;
				IL_07a0:
				Singleton<EventTrackingManager>.instance.RegisterTutorialUnitSelectedEvent("ID_MONTH", FKGHFOJFMBP);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(737f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 36;
				}
				break;
			}
			return false;
		}

		public void EFDJMHAPDLB()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HOCLBPGAEMP()
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
				BJGCPDNMHDH.StartTutorial(isContinue: false);
				BJGCPDNMHDH.mUnitToUpgrade = BJGCPDNMHDH.ChooseUnit();
				Singleton<EventTrackingManager>.instance.RegisterTutorialMenuTutorialEvent("setCustomProfileNumber");
				Singleton<MessageManager>.instance.HGIDIBNNPEJ();
				goto case 1u;
			case 1u:
				if (!GuiScreenSingle<EndScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (GuiScreenSingle<EndScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				if (Singleton<GuiManager>.instance.AODFEHKBJIN != GuiScreenSingle<MainScreen>.instance)
				{
					goto default;
				}
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 3u;
			case 3u:
				if (!GuiScreenSingle<MainScreen>.instance.LHDGJFHPJNM())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ShowArenaDialog"), Localization.Localize("InstantBattleEnded: LEVEL UP "), 494f);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH.transform.position, ELHGOHGPJCF: false, ENIHCPLOOAE: false, 1105f);
				GuiElementSingle<TutorialClickOverlay>.instance.GBHNBKFGCPG(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH, GPCEHFNNCIN: false);
				goto case 4u;
			case 4u:
				if (GuiScreenSingle<MainScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("{0}%");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(1838f);
				BJGCPDNMHDH.mRewardShowable = true;
				Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA("GameLoginManager: Invite Facebook Friends", BJGCPDNMHDH.mUnitToUpgrade.upgradeSlots.GetSheetName());
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 6u;
			case 6u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.BKIGLABDGCP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				goto case 7u;
			case 7u:
				if (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.EOPPCIEONEG(Localization.Localize("), "), Localization.Localize("SetFractionRPC"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 1145f, TutorialDialog.DODBDLEJOAM.Right);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<BattlePreparationScreen>.instance.JANFGHJMGBI.JANFGHJMGBI.transform.position, ELHGOHGPJCF: true, ENIHCPLOOAE: true, 1090f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<BattlePreparationScreen>.instance.JANFGHJMGBI.JANFGHJMGBI);
				GuiScreenSingle<ArmyScreen>.instance.PCALNGOCDKE(BJGCPDNMHDH.mUnitToUpgrade);
				goto case 8u;
			case 8u:
				if (!GuiElementSingle<TutorialDialog>.instance.AFOFDNJOJHG())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				BJGCPDNMHDH.mRewardShowable = false;
				IKAKODPFHAC = 309f;
				goto IL_04cb;
			case 9u:
				IKAKODPFHAC += Time.deltaTime;
				if (IKAKODPFHAC > 1298f)
				{
					BJGCPDNMHDH.mWarbucksAdded = ((!(BJGCPDNMHDH.mUnitToUpgrade == null)) ? BJGCPDNMHDH.mUnitToUpgrade.upgradeSlots.upgradeSlot.upgradePrice : (-10));
					BJGCPDNMHDH.mGoldAdded = ((!(BJGCPDNMHDH.mUnitToUpgrade == null)) ? BJGCPDNMHDH.mUnitToUpgrade.upgradeSlots.instantUnitDeliveryPrice : 0);
					GuiElementSingle<TutorialDialog>.instance.HNOHAMJNOKH(Localization.Localize(" OK!"), Localization.Localize("null"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 480f);
				}
				goto IL_04cb;
			case 10u:
				if (!GuiScreenSingle<ArmyScreen>.instance.BJNBLINDAED())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 115;
					}
					break;
				}
				FKGHFOJFMBP = true;
				FGKIANHNMFF = GuiScreenSingle<ArmyScreen>.instance.selectedIcon.BNPKCKFMBLG();
				if (FGKIANHNMFF.unitDictionaryId != BJGCPDNMHDH.mUnitToUpgrade.unitDictionaryId)
				{
					FKGHFOJFMBP = false;
					PHDOCKCBJOF = new WaitForSeconds(479f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 40;
					}
					break;
				}
				goto IL_07a0;
			case 11u:
				GuiElementSingle<TutorialDialog>.instance.ShowSpecial("resultMessage", 918f, TutorialDialog.DODBDLEJOAM.BottomLeft);
				GOBCHPOLPIE = null;
				IODGHHFAHJH = Vector3.zero;
				CMIKGAOHHPH = Vector3.one;
				KFCAECGLKKO = GuiScreenSingle<ArmyScreen>.instance.OOLKNBJNFJC().GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						ArmyUpgradeIcon current = KFCAECGLKKO.Current;
						if (current.levelBehaviour.unitDictionaryId == BJGCPDNMHDH.mUnitToUpgrade.unitDictionaryId)
						{
							GOBCHPOLPIE = current;
							IODGHHFAHJH = current.transform.position;
							CMIKGAOHHPH = current.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(IODGHHFAHJH, ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1217f);
							GuiElementSingle<TutorialClickOverlay>.instance.AJNGLEIBMHD(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				goto IL_0758;
			case 12u:
				FGKIANHNMFF = GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().KHEOKHHDGPO();
				goto IL_0758;
			case 13u:
				GuiElementSingle<TutorialDialog>.instance.setDebug = true;
				GuiElementSingle<TutorialDialog>.instance.DOLDLDECPIO(Localization.Localize("ID_GUI_BEADVISED_PURCHASEVIP"), Localization.LocalizeFormat("{0} {1}", Localization.Localize("ElitePackDeadline")), 556f, TutorialDialog.DODBDLEJOAM.Right);
				DHEGKFCAAGP = GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.BFAEJEFLKHN.transform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DHEGKFCAAGP, new Vector3(521f, 337f, 763f), ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1908f);
				GuiElementSingle<TutorialClickOverlay>.instance.CAIGHMDPBDI(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.BFAEJEFLKHN, GPCEHFNNCIN: false);
				goto case 14u;
			case 14u:
				if (!GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.JKGHPLKKPLE.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(1218f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1641f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 13;
				}
				break;
			case 15u:
				MHBNLBPBEGE = GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.HKGGCIGOONK.cachedTransform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(MHBNLBPBEGE, new Vector3(1654f, 338f, 811f), ELHGOHGPJCF: true, ENIHCPLOOAE: true, 1871f);
				GuiElementSingle<TutorialClickOverlay>.instance.CAIGHMDPBDI(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC);
				goto case 16u;
			case 16u:
				if (FGKIANHNMFF.upgradeSlots.unitState != UpgradeSlots.JLANLLEABDC.Locked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -114;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("PA: warbucks spent ");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialDialog>.instance.setDebug = false;
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(1751f);
				ELPHLDJPBNJ = true;
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(470f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -58;
				}
				break;
			case 17u:
			{
				TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM2 = Localization.Localize("No main position was set in map definition");
				object[] array2 = new object[1];
				array2[1] = Localization.Localize("ID_WEHAVERECEIVEDCOMPLAINTSREGARDING");
				instance2.ShowMenuTutorial(aMKLKMJEMJM2, Localization.LocalizeFormat("_Wind", array2), 252f, TutorialDialog.DODBDLEJOAM.BottomRight);
				EPGFICIMJJA = GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC.transform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(EPGFICIMJJA, new Vector3(438f, 1569f, 625f), ELHGOHGPJCF: false, ENIHCPLOOAE: true, 644f);
				GuiElementSingle<TutorialClickOverlay>.instance.MEBFBNDKOGD(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC);
				PECMCAOEMND = true;
				goto case 19u;
			}
			case 18u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("ShotFrequencyMaxCannon");
				object[] array = new object[0];
				array[1] = Localization.Localize("null");
				instance.BLHPAFCOPMD(aMKLKMJEMJM, Localization.LocalizeFormat("{0}{1}", array), 165f, TutorialDialog.DODBDLEJOAM.Left, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(EPGFICIMJJA, new Vector3(381f, 1486f, 1515f), ELHGOHGPJCF: false, ENIHCPLOOAE: true, 1653f);
				GuiElementSingle<TutorialClickOverlay>.instance.FCGLGPIBAEN(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC);
				goto IL_0c07;
			}
			case 19u:
				if (FGKIANHNMFF.upgradeSlots.unitState == (UpgradeSlots.JLANLLEABDC)7 || FGKIANHNMFF.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Locked)
				{
					if (PECMCAOEMND && FGKIANHNMFF.upgradeSlots.unitState == (UpgradeSlots.JLANLLEABDC)7)
					{
						ELPHLDJPBNJ = false;
						PECMCAOEMND = true;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
						GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(1225f);
						Singleton<GuiManager>.instance.CMCCOCBIGBB();
						PHDOCKCBJOF = new WaitForSeconds(1778f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 32;
						}
						break;
					}
					goto IL_0c07;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("lootboxes", ELPHLDJPBNJ);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(885f);
				PHDOCKCBJOF = new WaitForSeconds(437f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 64;
				}
				break;
			case 20u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0758:
				if (FGKIANHNMFF.unitDictionaryId != BJGCPDNMHDH.mUnitToUpgrade.unitDictionaryId)
				{
					if (GOBCHPOLPIE != null && GOBCHPOLPIE.transform.position != IODGHHFAHJH)
					{
						IODGHHFAHJH = GOBCHPOLPIE.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.EIDNJNBEPFI(IODGHHFAHJH);
						GuiElementSingle<TutorialClickOverlay>.instance.IGNJKOKGNOI(IODGHHFAHJH, CMIKGAOHHPH);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -29;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(1721f);
				goto IL_07a0;
				IL_0c07:
				PHDOCKCBJOF = false;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 109;
				}
				break;
				IL_04cb:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 81;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("MessageId");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(1443f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 10u;
				IL_07a0:
				Singleton<EventTrackingManager>.instance.RegisterTutorialUnitSelectedEvent("game-card-ico-headsup", FKGHFOJFMBP);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(975f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 120;
				}
				break;
			}
			return true;
		}

		public void INBELBGOCLD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KBNAGKKMLBP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FIDLDFGJLFK()
		{
			return PHDOCKCBJOF;
		}

		public void OMDFNFHKFBK()
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
				BJGCPDNMHDH.StartTutorial(isContinue: false);
				BJGCPDNMHDH.mUnitToUpgrade = BJGCPDNMHDH.ChooseUnit();
				Singleton<EventTrackingManager>.instance.RegisterTutorialMenuTutorialEvent("501 START");
				Singleton<MessageManager>.instance.StopMessageCoroutine();
				goto case 1u;
			case 1u:
				if (!GuiScreenSingle<EndScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (GuiScreenSingle<EndScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				if (Singleton<GuiManager>.instance.AODFEHKBJIN != GuiScreenSingle<MainScreen>.instance)
				{
					goto default;
				}
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 3u;
			case 3u:
				if (!GuiScreenSingle<MainScreen>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_TUTORIAL_UPGRADEUNIT_3"), Localization.Localize("ID_TUTORIAL_UPGRADEUNIT_4"), 0.1f, TutorialDialog.DODBDLEJOAM.Right, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH.transform.position);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH, GPCEHFNNCIN: false);
				goto case 4u;
			case 4u:
				if (GuiScreenSingle<MainScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("502 MENU BATTLE SCREEN SHOWN");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide();
				BJGCPDNMHDH.mRewardShowable = false;
				Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA("UnitTutorial", BJGCPDNMHDH.mUnitToUpgrade.upgradeSlots.GetSheetName());
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 6u;
			case 6u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				goto case 7u;
			case 7u:
				if (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.ShowReward(Localization.Localize("ID_TUTORIAL_UPGRADEUNIT_3"), Localization.Localize("ID_TUTORIAL_UPGRADEUNIT_4"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 0f, TutorialDialog.DODBDLEJOAM.Right);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<BattlePreparationScreen>.instance.JANFGHJMGBI.JANFGHJMGBI.transform.position);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<BattlePreparationScreen>.instance.JANFGHJMGBI.JANFGHJMGBI, GPCEHFNNCIN: false);
				GuiScreenSingle<ArmyScreen>.instance.SelectUnit(BJGCPDNMHDH.mUnitToUpgrade);
				goto case 8u;
			case 8u:
				if (!GuiElementSingle<TutorialDialog>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				BJGCPDNMHDH.mRewardShowable = true;
				IKAKODPFHAC = 0f;
				goto IL_04cb;
			case 9u:
				IKAKODPFHAC += Time.deltaTime;
				if (IKAKODPFHAC > 20f)
				{
					BJGCPDNMHDH.mWarbucksAdded = ((!(BJGCPDNMHDH.mUnitToUpgrade == null)) ? BJGCPDNMHDH.mUnitToUpgrade.upgradeSlots.upgradeSlot.upgradePrice : 375);
					BJGCPDNMHDH.mGoldAdded = ((BJGCPDNMHDH.mUnitToUpgrade == null) ? 1 : BJGCPDNMHDH.mUnitToUpgrade.upgradeSlots.instantUnitDeliveryPrice);
					GuiElementSingle<TutorialDialog>.instance.ShowReward(Localization.Localize("ID_TUTORIAL_UPGRADEWEAPON_3"), Localization.Localize("ID_TUTORIAL_UPGRADEWEAPON_4"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 0f, TutorialDialog.DODBDLEJOAM.Right);
				}
				goto IL_04cb;
			case 10u:
				if (!GuiScreenSingle<ArmyScreen>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 10;
					}
					break;
				}
				FKGHFOJFMBP = false;
				FGKIANHNMFF = GuiScreenSingle<ArmyScreen>.instance.selectedIcon.levelBehaviour;
				if (FGKIANHNMFF.unitDictionaryId != BJGCPDNMHDH.mUnitToUpgrade.unitDictionaryId)
				{
					FKGHFOJFMBP = true;
					PHDOCKCBJOF = new WaitForSeconds(0.5f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 11;
					}
					break;
				}
				goto IL_07a0;
			case 11u:
				GuiElementSingle<TutorialDialog>.instance.ShowSpecial("ID_TUTORIAL_UPGRADEUNIT_5", 0.25f);
				GOBCHPOLPIE = null;
				IODGHHFAHJH = Vector3.zero;
				CMIKGAOHHPH = Vector3.one;
				KFCAECGLKKO = GuiScreenSingle<ArmyScreen>.instance.armyIcons.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						ArmyUpgradeIcon current = KFCAECGLKKO.Current;
						if (current.levelBehaviour.unitDictionaryId == BJGCPDNMHDH.mUnitToUpgrade.unitDictionaryId)
						{
							GOBCHPOLPIE = current;
							IODGHHFAHJH = current.transform.position;
							CMIKGAOHHPH = current.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(IODGHHFAHJH);
							GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				goto IL_0758;
			case 12u:
				FGKIANHNMFF = GuiScreenSingle<ArmyScreen>.instance.selectedIcon.levelBehaviour;
				goto IL_0758;
			case 13u:
				GuiElementSingle<TutorialDialog>.instance.setDebug = true;
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_TUTORIAL_UPGRADEUNIT_6"), Localization.LocalizeFormat("ID_TUTORIAL_TAPON", Localization.Localize("ID_TRAIN")), 0.6f, TutorialDialog.DODBDLEJOAM.BottomRight, NHEJDPIIOJG: false);
				DHEGKFCAAGP = GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.BFAEJEFLKHN.transform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DHEGKFCAAGP, new Vector3(40f, -56f, 0f));
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.BFAEJEFLKHN, GPCEHFNNCIN: false);
				goto case 14u;
			case 14u:
				if (!GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.JKGHPLKKPLE.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 14;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide();
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(0.5f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 15;
				}
				break;
			case 15u:
				MHBNLBPBEGE = GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.HKGGCIGOONK.cachedTransform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(MHBNLBPBEGE, new Vector3(40f, -56f, 0f));
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC, GPCEHFNNCIN: false);
				goto case 16u;
			case 16u:
				if (FGKIANHNMFF.upgradeSlots.unitState != UpgradeSlots.JLANLLEABDC.Delivering)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 16;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("505 MENU ARMY SCREEN BUY UPGRADE");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialDialog>.instance.setDebug = false;
				GuiElementSingle<TutorialClickOverlay>.instance.Hide();
				ELPHLDJPBNJ = false;
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1.1f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 17;
				}
				break;
			case 17u:
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_TUTORIAL_UPGRADEUNIT_7"), Localization.LocalizeFormat("ID_TUTORIAL_TAPON", Localization.Localize("ID_DELIVERNOW")), 0.6f, TutorialDialog.DODBDLEJOAM.BottomRight, NHEJDPIIOJG: false);
				EPGFICIMJJA = GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC.transform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(EPGFICIMJJA, new Vector3(40f, -56f, 0f));
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC, GPCEHFNNCIN: false);
				PECMCAOEMND = true;
				goto case 19u;
			case 18u:
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_TUTORIAL_UPGRADEUNIT_8"), Localization.LocalizeFormat("ID_TUTORIAL_TAPON", Localization.Localize("ID_ACTIVATION")), 0.6f, TutorialDialog.DODBDLEJOAM.BottomRight, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(EPGFICIMJJA, new Vector3(40f, -56f, 0f));
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC, GPCEHFNNCIN: false);
				goto IL_0c07;
			case 19u:
				if (FGKIANHNMFF.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Delivering || FGKIANHNMFF.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Delivered)
				{
					if (PECMCAOEMND && FGKIANHNMFF.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Delivered)
					{
						ELPHLDJPBNJ = true;
						PECMCAOEMND = false;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.Hide();
						GuiElementSingle<TutorialClickOverlay>.instance.Hide();
						Singleton<GuiManager>.instance.TurnOffInputCompletly();
						PHDOCKCBJOF = new WaitForSeconds(1.1f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 18;
						}
						break;
					}
					goto IL_0c07;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("506 MENU ARMY SCREEN UPGRADE ACTIVATED", ELPHLDJPBNJ);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide();
				PHDOCKCBJOF = new WaitForSeconds(2.8f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 20;
				}
				break;
			case 20u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0758:
				if (FGKIANHNMFF.unitDictionaryId != BJGCPDNMHDH.mUnitToUpgrade.unitDictionaryId)
				{
					if (GOBCHPOLPIE != null && GOBCHPOLPIE.transform.position != IODGHHFAHJH)
					{
						IODGHHFAHJH = GOBCHPOLPIE.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateTapAnimation(IODGHHFAHJH);
						GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 12;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide();
				goto IL_07a0;
				IL_0c07:
				PHDOCKCBJOF = false;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 19;
				}
				break;
				IL_04cb:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 9;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("503 MENU ARMY SCREEN SHOWN");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide();
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 10u;
				IL_07a0:
				Singleton<EventTrackingManager>.instance.RegisterTutorialUnitSelectedEvent("504 MENU ARMY SCREEN UNIT SELECTED", FKGHFOJFMBP);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(0.5f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 13;
				}
				break;
			}
			return true;
		}

		[SpecialName]
		private object DKPOLLDBPAP()
		{
			return PHDOCKCBJOF;
		}

		public void MEBPMHDHIPJ()
		{
			throw new NotSupportedException();
		}

		public bool JIIOHNFHPOI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.StartTutorial(isContinue: true);
				BJGCPDNMHDH.mUnitToUpgrade = BJGCPDNMHDH.ChooseUnit();
				Singleton<EventTrackingManager>.instance.RegisterTutorialMenuTutorialEvent("Player chose to stay on his account");
				Singleton<MessageManager>.instance.MNDIJBOCFPM();
				goto case 1u;
			case 1u:
				if (!GuiScreenSingle<EndScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (GuiScreenSingle<EndScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (Singleton<GuiManager>.instance.AODFEHKBJIN != GuiScreenSingle<MainScreen>.instance)
				{
					goto default;
				}
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 3u;
			case 3u:
				if (!GuiScreenSingle<MainScreen>.instance.BJNBLINDAED())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
				GuiElementSingle<TutorialDialog>.instance.DOLDLDECPIO(Localization.Localize("Manual_Unit_Spawn"), Localization.Localize("OldSquadRank"), 546f, TutorialDialog.DODBDLEJOAM.TopRight, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH.transform.position, ELHGOHGPJCF: true, ENIHCPLOOAE: false, 836f);
				GuiElementSingle<TutorialClickOverlay>.instance.LPKOHAKMOOC(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH, GPCEHFNNCIN: false);
				goto case 4u;
			case 4u:
				if (GuiScreenSingle<MainScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("menu-army-cat-explosive");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(39f);
				BJGCPDNMHDH.mRewardShowable = true;
				Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA(" mSpriteName:", BJGCPDNMHDH.mUnitToUpgrade.upgradeSlots.GetSheetName());
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 6u;
			case 6u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				goto case 7u;
			case 7u:
				if (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.HNOHAMJNOKH(Localization.Localize("game-missions-blue-mission-ico"), Localization.Localize("ID_CONFIRM_ERROR"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 844f, TutorialDialog.DODBDLEJOAM.Bottom);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<BattlePreparationScreen>.instance.JANFGHJMGBI.JANFGHJMGBI.transform.position, ELHGOHGPJCF: false, ENIHCPLOOAE: false, 1144f);
				GuiElementSingle<TutorialClickOverlay>.instance.FCGLGPIBAEN(GuiScreenSingle<BattlePreparationScreen>.instance.JANFGHJMGBI.JANFGHJMGBI);
				GuiScreenSingle<ArmyScreen>.instance.SelectUnit(BJGCPDNMHDH.mUnitToUpgrade);
				goto case 8u;
			case 8u:
				if (!GuiElementSingle<TutorialDialog>.instance.LHDGJFHPJNM())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				BJGCPDNMHDH.mRewardShowable = true;
				IKAKODPFHAC = 970f;
				goto IL_04cb;
			case 9u:
				IKAKODPFHAC += Time.deltaTime;
				if (IKAKODPFHAC > 2f)
				{
					BJGCPDNMHDH.mWarbucksAdded = ((!(BJGCPDNMHDH.mUnitToUpgrade == null)) ? BJGCPDNMHDH.mUnitToUpgrade.upgradeSlots.upgradeSlot.CIBEGNHKPJH() : 145);
					BJGCPDNMHDH.mGoldAdded = ((BJGCPDNMHDH.mUnitToUpgrade == null) ? 1 : BJGCPDNMHDH.mUnitToUpgrade.upgradeSlots.instantUnitDeliveryPrice);
					GuiElementSingle<TutorialDialog>.instance.IOEJCIDBAPL(Localization.Localize("_Packs"), Localization.Localize("N"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 1784f, TutorialDialog.DODBDLEJOAM.TopLeft);
				}
				goto IL_04cb;
			case 10u:
				if (!GuiScreenSingle<ArmyScreen>.instance.LHDGJFHPJNM())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -104;
					}
					break;
				}
				FKGHFOJFMBP = true;
				FGKIANHNMFF = GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().PPMNNKANOEF();
				if (FGKIANHNMFF.unitDictionaryId != BJGCPDNMHDH.mUnitToUpgrade.unitDictionaryId)
				{
					FKGHFOJFMBP = false;
					PHDOCKCBJOF = new WaitForSeconds(442f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -34;
					}
					break;
				}
				goto IL_07a0;
			case 11u:
				GuiElementSingle<TutorialDialog>.instance.GKODNFIOLPB("{0} {1}", 965f, TutorialDialog.DODBDLEJOAM.Bottom);
				GOBCHPOLPIE = null;
				IODGHHFAHJH = Vector3.zero;
				CMIKGAOHHPH = Vector3.one;
				KFCAECGLKKO = GuiScreenSingle<ArmyScreen>.instance.MAPKDMOOFMM().GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						ArmyUpgradeIcon current = KFCAECGLKKO.Current;
						if (current.levelBehaviour.unitDictionaryId == BJGCPDNMHDH.mUnitToUpgrade.unitDictionaryId)
						{
							GOBCHPOLPIE = current;
							IODGHHFAHJH = current.transform.position;
							CMIKGAOHHPH = current.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(IODGHHFAHJH, ELHGOHGPJCF: true, ENIHCPLOOAE: true, 114f);
							GuiElementSingle<TutorialClickOverlay>.instance.NNPKOKCJMHL(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				goto IL_0758;
			case 12u:
				FGKIANHNMFF = GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().BNPKCKFMBLG();
				goto IL_0758;
			case 13u:
				GuiElementSingle<TutorialDialog>.instance.DEACFMCKNKM(IDEBKDPMPGM: true);
				GuiElementSingle<TutorialDialog>.instance.BLHPAFCOPMD(Localization.Localize("reset tutorial"), Localization.LocalizeFormat("ID_", Localization.Localize("Exception during Load Event Assignment Config: ")), 1253f, TutorialDialog.DODBDLEJOAM.TopRight, NHEJDPIIOJG: false);
				DHEGKFCAAGP = GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.BFAEJEFLKHN.transform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(DHEGKFCAAGP, new Vector3(1298f, 521f, 962f), ELHGOHGPJCF: true, ENIHCPLOOAE: true, 1141f);
				GuiElementSingle<TutorialClickOverlay>.instance.CLPPGONHLHI(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.BFAEJEFLKHN, GPCEHFNNCIN: false);
				goto case 14u;
			case 14u:
				if (!GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.JKGHPLKKPLE.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -93;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(1041f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1279f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 109;
				}
				break;
			case 15u:
				MHBNLBPBEGE = GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.HKGGCIGOONK.cachedTransform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(MHBNLBPBEGE, new Vector3(277f, 1525f, 310f), ELHGOHGPJCF: false, ENIHCPLOOAE: false, 262f);
				GuiElementSingle<TutorialClickOverlay>.instance.CAIGHMDPBDI(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC);
				goto case 16u;
			case 16u:
				if (FGKIANHNMFF.upgradeSlots.unitState != UpgradeSlots.JLANLLEABDC.Delivering)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -62;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("weaponDelivery");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialDialog>.instance.DEACFMCKNKM(IDEBKDPMPGM: false);
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(500f);
				ELPHLDJPBNJ = false;
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(779f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 24;
				}
				break;
			case 17u:
				GuiElementSingle<TutorialDialog>.instance.DOLDLDECPIO(Localization.Localize("Parachuter"), Localization.LocalizeFormat("Show reconnect dialog isPaused", Localization.Localize("WarFriends benötigt die Erlaubnis, auf deinen Medienspeicher zuzugreifen, um wichtige Spieldaten herunterladen zu können.Ohne diese Berechtigung läuft das Spiel nicht und wird geschlossen. Bitte versuche es erneut oder schließe WarFriends.")), 466f, TutorialDialog.DODBDLEJOAM.BottomLeft);
				EPGFICIMJJA = GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC.transform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(EPGFICIMJJA, new Vector3(1892f, 1271f, 232f), ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1771f);
				GuiElementSingle<TutorialClickOverlay>.instance.MLCGPAJJOMB(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC, GPCEHFNNCIN: false);
				PECMCAOEMND = false;
				goto case 19u;
			case 18u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("percent");
				object[] array = new object[1];
				array[1] = Localization.Localize("ID_READYTIME");
				instance.BLHPAFCOPMD(aMKLKMJEMJM, Localization.LocalizeFormat("NO", array), 1776f, TutorialDialog.DODBDLEJOAM.Left, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(EPGFICIMJJA, new Vector3(1077f, 1276f, 1598f), ELHGOHGPJCF: false, ENIHCPLOOAE: false, 347f);
				GuiElementSingle<TutorialClickOverlay>.instance.FCGLGPIBAEN(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC, GPCEHFNNCIN: false);
				goto IL_0c07;
			}
			case 19u:
				if (FGKIANHNMFF.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Delivering || FGKIANHNMFF.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed)
				{
					if (PECMCAOEMND && FGKIANHNMFF.upgradeSlots.unitState == (UpgradeSlots.JLANLLEABDC)8)
					{
						ELPHLDJPBNJ = false;
						PECMCAOEMND = false;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.Hide();
						GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(902f);
						Singleton<GuiManager>.instance.TurnOffInputCompletly();
						PHDOCKCBJOF = new WaitForSeconds(898f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 113;
						}
						break;
					}
					goto IL_0c07;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("GO TO OFFER", ELPHLDJPBNJ);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(1912f);
				PHDOCKCBJOF = new WaitForSeconds(1661f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 16;
				}
				break;
			case 20u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0758:
				if (FGKIANHNMFF.unitDictionaryId != BJGCPDNMHDH.mUnitToUpgrade.unitDictionaryId)
				{
					if (GOBCHPOLPIE != null && GOBCHPOLPIE.transform.position != IODGHHFAHJH)
					{
						IODGHHFAHJH = GOBCHPOLPIE.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateTapAnimation(IODGHHFAHJH);
						GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -46;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(423f);
				goto IL_07a0;
				IL_0c07:
				PHDOCKCBJOF = true;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 29;
				}
				break;
				IL_04cb:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -53;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("*****   Bootcamp 2/3 Ended   *****");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(1618f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 10u;
				IL_07a0:
				Singleton<EventTrackingManager>.instance.KEKPOIPDIGK("AchievementClaimed", FKGHFOJFMBP);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1654f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 30;
				}
				break;
			}
			return false;
		}

		public void KAFNGNMNNOA()
		{
			throw new NotSupportedException();
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
		private object HMIFLGCBDCO()
		{
			return PHDOCKCBJOF;
		}

		public void PHEIGPKKPGE()
		{
			throw new NotSupportedException();
		}

		public void CJLDNKALLLI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object IBCJOBKGEEG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AHFIDCCJHKE()
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
				BJGCPDNMHDH.StartTutorial(isContinue: true);
				BJGCPDNMHDH.mUnitToUpgrade = BJGCPDNMHDH.ChooseUnit();
				Singleton<EventTrackingManager>.instance.RegisterTutorialMenuTutorialEvent("(");
				Singleton<MessageManager>.instance.ANLNFNOJNDF();
				goto case 1u;
			case 1u:
				if (!GuiScreenSingle<EndScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (GuiScreenSingle<EndScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (Singleton<GuiManager>.instance.AODFEHKBJIN != GuiScreenSingle<MainScreen>.instance)
				{
					goto default;
				}
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 3u;
			case 3u:
				if (!GuiScreenSingle<MainScreen>.instance.BJNBLINDAED())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
				GuiElementSingle<TutorialDialog>.instance.PBEAOCBHFGD(Localization.Localize("ID_BATTLECANCELED"), Localization.Localize(", action already scheduled"), 1076f, TutorialDialog.DODBDLEJOAM.Left, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH.transform.position, ELHGOHGPJCF: true, ENIHCPLOOAE: true, 1757f);
				GuiElementSingle<TutorialClickOverlay>.instance.PGOLMCBEIOD(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH, GPCEHFNNCIN: false);
				goto case 4u;
			case 4u:
				if (GuiScreenSingle<MainScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("FOCUS CAMPAIGN!!!!");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(332f);
				BJGCPDNMHDH.mRewardShowable = true;
				Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA("ID_GETSOMEWARBUCKS", BJGCPDNMHDH.mUnitToUpgrade.upgradeSlots.GetSheetName());
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 6u;
			case 6u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.LHDGJFHPJNM())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				goto case 7u;
			case 7u:
				if (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.KHPBNEBLEEF(Localization.Localize(" ID_"), Localization.Localize("game-card-ico-shieldgenerator"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 1323f, TutorialDialog.DODBDLEJOAM.Bottom);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<BattlePreparationScreen>.instance.JANFGHJMGBI.JANFGHJMGBI.transform.position, ELHGOHGPJCF: true, ENIHCPLOOAE: true, 376f);
				GuiElementSingle<TutorialClickOverlay>.instance.CAIGHMDPBDI(GuiScreenSingle<BattlePreparationScreen>.instance.JANFGHJMGBI.JANFGHJMGBI, GPCEHFNNCIN: false);
				GuiScreenSingle<ArmyScreen>.instance.PCALNGOCDKE(BJGCPDNMHDH.mUnitToUpgrade);
				goto case 8u;
			case 8u:
				if (!GuiElementSingle<TutorialDialog>.instance.MHAIBHBGBOO())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				BJGCPDNMHDH.mRewardShowable = true;
				IKAKODPFHAC = 94f;
				goto IL_04cb;
			case 9u:
				IKAKODPFHAC += Time.deltaTime;
				if (IKAKODPFHAC > 163f)
				{
					BJGCPDNMHDH.mWarbucksAdded = ((!(BJGCPDNMHDH.mUnitToUpgrade == null)) ? BJGCPDNMHDH.mUnitToUpgrade.upgradeSlots.upgradeSlot.upgradePrice : 43);
					BJGCPDNMHDH.mGoldAdded = ((BJGCPDNMHDH.mUnitToUpgrade == null) ? 1 : BJGCPDNMHDH.mUnitToUpgrade.upgradeSlots.instantUnitDeliveryPrice);
					GuiElementSingle<TutorialDialog>.instance.ShowReward(Localization.Localize("ID_NOHEROESINCURRENTARENA"), Localization.Localize("ID_NO"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 573f);
				}
				goto IL_04cb;
			case 10u:
				if (!GuiScreenSingle<ArmyScreen>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 87;
					}
					break;
				}
				FKGHFOJFMBP = true;
				FGKIANHNMFF = GuiScreenSingle<ArmyScreen>.instance.BDBKFBEIHNF().PPMNNKANOEF();
				if (FGKIANHNMFF.unitDictionaryId != BJGCPDNMHDH.mUnitToUpgrade.unitDictionaryId)
				{
					FKGHFOJFMBP = true;
					PHDOCKCBJOF = new WaitForSeconds(972f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -72;
					}
					break;
				}
				goto IL_07a0;
			case 11u:
				GuiElementSingle<TutorialDialog>.instance.FJFFALBAFBD("Card_1_Played", 290f, TutorialDialog.DODBDLEJOAM.BottomLeft);
				GOBCHPOLPIE = null;
				IODGHHFAHJH = Vector3.zero;
				CMIKGAOHHPH = Vector3.one;
				KFCAECGLKKO = GuiScreenSingle<ArmyScreen>.instance.armyIcons.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						ArmyUpgradeIcon current = KFCAECGLKKO.Current;
						if (current.AIHMCHBCJDO().unitDictionaryId == BJGCPDNMHDH.mUnitToUpgrade.unitDictionaryId)
						{
							GOBCHPOLPIE = current;
							IODGHHFAHJH = current.transform.position;
							CMIKGAOHHPH = current.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(IODGHHFAHJH, ELHGOHGPJCF: true, ENIHCPLOOAE: true, 343f);
							GuiElementSingle<TutorialClickOverlay>.instance.EEMMKEMADFC(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				goto IL_0758;
			case 12u:
				FGKIANHNMFF = GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().levelBehaviour;
				goto IL_0758;
			case 13u:
			{
				GuiElementSingle<TutorialDialog>.instance.DEACFMCKNKM(IDEBKDPMPGM: false);
				TutorialDialog instance3 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM3 = Localization.Localize("/PC/");
				object[] array3 = new object[0];
				array3[0] = Localization.Localize("()V");
				instance3.BLHPAFCOPMD(aMKLKMJEMJM3, Localization.LocalizeFormat("ID_CONFIRM_PLAYERNOTEXISTS", array3), 815f, TutorialDialog.DODBDLEJOAM.TopLeft);
				DHEGKFCAAGP = GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.BFAEJEFLKHN.transform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(DHEGKFCAAGP, new Vector3(1891f, 328f, 1895f), ELHGOHGPJCF: true, ENIHCPLOOAE: true, 1115f);
				GuiElementSingle<TutorialClickOverlay>.instance.MEBFBNDKOGD(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.BFAEJEFLKHN);
				goto case 14u;
			}
			case 14u:
				if (!GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.JKGHPLKKPLE.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -116;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(1767f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1250f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 49;
				}
				break;
			case 15u:
				MHBNLBPBEGE = GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.HKGGCIGOONK.cachedTransform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(MHBNLBPBEGE, new Vector3(1427f, 59f, 1700f), ELHGOHGPJCF: true, ENIHCPLOOAE: true, 1883f);
				GuiElementSingle<TutorialClickOverlay>.instance.CLPPGONHLHI(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC);
				goto case 16u;
			case 16u:
				if (FGKIANHNMFF.upgradeSlots.unitState != UpgradeSlots.JLANLLEABDC.Delivering)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 38;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Saving first played timestamp");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				GuiElementSingle<TutorialDialog>.instance.DEACFMCKNKM(IDEBKDPMPGM: true);
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(319f);
				ELPHLDJPBNJ = false;
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1217f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -47;
				}
				break;
			case 17u:
			{
				TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM2 = Localization.Localize("friendlyName");
				object[] array2 = new object[0];
				array2[0] = Localization.Localize("123456789");
				instance2.DOLDLDECPIO(aMKLKMJEMJM2, Localization.LocalizeFormat("Google2u.DBUpgradeSlots", array2), 345f, TutorialDialog.DODBDLEJOAM.BottomRight);
				EPGFICIMJJA = GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC.transform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(EPGFICIMJJA, new Vector3(1973f, 519f, 1057f), ELHGOHGPJCF: false, ENIHCPLOOAE: true, 482f);
				GuiElementSingle<TutorialClickOverlay>.instance.CAIGHMDPBDI(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC, GPCEHFNNCIN: false);
				PECMCAOEMND = false;
				goto case 19u;
			}
			case 18u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("SetAngle");
				object[] array = new object[0];
				array[0] = Localization.Localize("ID_CARD_DESC_BUDDYCREATE");
				instance.DOLDLDECPIO(aMKLKMJEMJM, Localization.LocalizeFormat("ID_WARNING_CANTSENDINVITE", array), 1781f, TutorialDialog.DODBDLEJOAM.Top);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(EPGFICIMJJA, new Vector3(531f, 856f, 1865f), ELHGOHGPJCF: false, ENIHCPLOOAE: false, 952f);
				GuiElementSingle<TutorialClickOverlay>.instance.CAIGHMDPBDI(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC, GPCEHFNNCIN: false);
				goto IL_0c07;
			}
			case 19u:
				if (FGKIANHNMFF.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.UnitDelivering || FGKIANHNMFF.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.UnitDelivering)
				{
					if (PECMCAOEMND && FGKIANHNMFF.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.UnitDelivered)
					{
						ELPHLDJPBNJ = true;
						PECMCAOEMND = true;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
						GuiElementSingle<TutorialClickOverlay>.instance.Hide(878f);
						Singleton<GuiManager>.instance.TurnOffInputCompletly();
						PHDOCKCBJOF = new WaitForSeconds(238f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 52;
						}
						break;
					}
					goto IL_0c07;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("NewVisuals", ELPHLDJPBNJ);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(45f);
				PHDOCKCBJOF = new WaitForSeconds(514f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -22;
				}
				break;
			case 20u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0758:
				if (FGKIANHNMFF.unitDictionaryId != BJGCPDNMHDH.mUnitToUpgrade.unitDictionaryId)
				{
					if (GOBCHPOLPIE != null && GOBCHPOLPIE.transform.position != IODGHHFAHJH)
					{
						IODGHHFAHJH = GOBCHPOLPIE.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateTapAnimation(IODGHHFAHJH);
						GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 126;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(168f);
				goto IL_07a0;
				IL_0c07:
				PHDOCKCBJOF = true;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -24;
				}
				break;
				IL_04cb:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -106;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ERROR : Couldnt parse deposited card = ");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(1878f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 10u;
				IL_07a0:
				Singleton<EventTrackingManager>.instance.RegisterTutorialUnitSelectedEvent("아니오", FKGHFOJFMBP);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1134f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -71;
				}
				break;
			}
			return true;
		}

		public bool FCJCLBMPBFK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.StartTutorial(isContinue: false);
				BJGCPDNMHDH.mUnitToUpgrade = BJGCPDNMHDH.ChooseUnit();
				Singleton<EventTrackingManager>.instance.RegisterTutorialMenuTutorialEvent("FB: FacebookLogout - RemoveFacebook - 2");
				Singleton<MessageManager>.instance.ANLNFNOJNDF();
				goto case 1u;
			case 1u:
				if (!GuiScreenSingle<EndScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (GuiScreenSingle<EndScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				if (Singleton<GuiManager>.instance.AODFEHKBJIN != GuiScreenSingle<MainScreen>.instance)
				{
					goto default;
				}
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 3u;
			case 3u:
				if (!GuiScreenSingle<MainScreen>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("MaintenanceMessage"), Localization.Localize("{0}"), 424f, TutorialDialog.DODBDLEJOAM.BottomLeft, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH.transform.position, ELHGOHGPJCF: false, ENIHCPLOOAE: true, 1963f);
				GuiElementSingle<TutorialClickOverlay>.instance.PGOLMCBEIOD(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH, GPCEHFNNCIN: false);
				goto case 4u;
			case 4u:
				if (GuiScreenSingle<MainScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("game-card-ico-mineyourstep-full");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(1647f);
				BJGCPDNMHDH.mRewardShowable = true;
				Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA("LootboxType", BJGCPDNMHDH.mUnitToUpgrade.upgradeSlots.GetSheetName());
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 6u;
			case 6u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.BKIGLABDGCP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 7u;
			case 7u:
				if (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.KHPBNEBLEEF(Localization.Localize("PurchaseCurrency"), Localization.Localize("RecieveSkillShotsCount"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 998f, TutorialDialog.DODBDLEJOAM.Top);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<BattlePreparationScreen>.instance.JANFGHJMGBI.JANFGHJMGBI.transform.position, ELHGOHGPJCF: false, ENIHCPLOOAE: false, 255f);
				GuiElementSingle<TutorialClickOverlay>.instance.JGHBBJEFLEB(GuiScreenSingle<BattlePreparationScreen>.instance.JANFGHJMGBI.JANFGHJMGBI);
				GuiScreenSingle<ArmyScreen>.instance.SelectUnit(BJGCPDNMHDH.mUnitToUpgrade);
				goto case 8u;
			case 8u:
				if (!GuiElementSingle<TutorialDialog>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				BJGCPDNMHDH.mRewardShowable = true;
				IKAKODPFHAC = 17f;
				goto IL_04cb;
			case 9u:
				IKAKODPFHAC += Time.deltaTime;
				if (IKAKODPFHAC > 630f)
				{
					BJGCPDNMHDH.mWarbucksAdded = ((!(BJGCPDNMHDH.mUnitToUpgrade == null)) ? BJGCPDNMHDH.mUnitToUpgrade.upgradeSlots.upgradeSlot.upgradePrice : (-129));
					BJGCPDNMHDH.mGoldAdded = ((!(BJGCPDNMHDH.mUnitToUpgrade == null)) ? BJGCPDNMHDH.mUnitToUpgrade.upgradeSlots.instantUnitDeliveryPrice : 0);
					GuiElementSingle<TutorialDialog>.instance.IOEJCIDBAPL(Localization.Localize("BatchSizeMin"), Localization.Localize("Deliver_Upgrade_For_Army_Unit"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 50f, TutorialDialog.DODBDLEJOAM.Bottom);
				}
				goto IL_04cb;
			case 10u:
				if (!GuiScreenSingle<ArmyScreen>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -32;
					}
					break;
				}
				FKGHFOJFMBP = false;
				FGKIANHNMFF = GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().AIHMCHBCJDO();
				if (FGKIANHNMFF.unitDictionaryId != BJGCPDNMHDH.mUnitToUpgrade.unitDictionaryId)
				{
					FKGHFOJFMBP = true;
					PHDOCKCBJOF = new WaitForSeconds(457f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 17;
					}
					break;
				}
				goto IL_07a0;
			case 11u:
				GuiElementSingle<TutorialDialog>.instance.FJFFALBAFBD("null customization for: ", 947f);
				GOBCHPOLPIE = null;
				IODGHHFAHJH = Vector3.zero;
				CMIKGAOHHPH = Vector3.one;
				KFCAECGLKKO = GuiScreenSingle<ArmyScreen>.instance.armyIcons.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						ArmyUpgradeIcon current = KFCAECGLKKO.Current;
						if (current.KHEOKHHDGPO().unitDictionaryId == BJGCPDNMHDH.mUnitToUpgrade.unitDictionaryId)
						{
							GOBCHPOLPIE = current;
							IODGHHFAHJH = current.transform.position;
							CMIKGAOHHPH = current.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(IODGHHFAHJH, ELHGOHGPJCF: false, ENIHCPLOOAE: false, 1314f);
							GuiElementSingle<TutorialClickOverlay>.instance.AJNGLEIBMHD(IODGHHFAHJH, CMIKGAOHHPH);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				goto IL_0758;
			case 12u:
				FGKIANHNMFF = GuiScreenSingle<ArmyScreen>.instance.selectedIcon.PPMNNKANOEF();
				goto IL_0758;
			case 13u:
				GuiElementSingle<TutorialDialog>.instance.DEACFMCKNKM(IDEBKDPMPGM: false);
				GuiElementSingle<TutorialDialog>.instance.DOLDLDECPIO(Localization.Localize("claimReward"), Localization.LocalizeFormat("Region", Localization.Localize("InstantBattleEnded: NUMBER OF BATTLES = ")), 1513f, TutorialDialog.DODBDLEJOAM.Center, NHEJDPIIOJG: false);
				DHEGKFCAAGP = GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.BFAEJEFLKHN.transform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DHEGKFCAAGP, new Vector3(512f, 485f, 805f), ELHGOHGPJCF: false, ENIHCPLOOAE: false, 1415f);
				GuiElementSingle<TutorialClickOverlay>.instance.CAIGHMDPBDI(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.BFAEJEFLKHN, GPCEHFNNCIN: false);
				goto case 14u;
			case 14u:
				if (!GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.JKGHPLKKPLE.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -54;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(558f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(568f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -125;
				}
				break;
			case 15u:
				MHBNLBPBEGE = GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.HKGGCIGOONK.cachedTransform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(MHBNLBPBEGE, new Vector3(488f, 634f, 1130f), ELHGOHGPJCF: false, ENIHCPLOOAE: true, 538f);
				GuiElementSingle<TutorialClickOverlay>.instance.CLPPGONHLHI(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC);
				goto case 16u;
			case 16u:
				if (FGKIANHNMFF.upgradeSlots.unitState != (UpgradeSlots.JLANLLEABDC)7)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 32;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Error - sheet {0} doesnt have column {1}");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialDialog>.instance.setDebug = false;
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(1396f);
				ELPHLDJPBNJ = true;
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1125f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -82;
				}
				break;
			case 17u:
			{
				TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM2 = Localization.Localize(" AFTER: critical: ");
				object[] array2 = new object[0];
				array2[0] = Localization.Localize("ID_TUTORIAL_SWIPE_UP");
				instance2.DOLDLDECPIO(aMKLKMJEMJM2, Localization.LocalizeFormat("(", array2), 552f, TutorialDialog.DODBDLEJOAM.Center, NHEJDPIIOJG: false);
				EPGFICIMJJA = GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC.transform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(EPGFICIMJJA, new Vector3(925f, 1538f, 356f), ELHGOHGPJCF: false, ENIHCPLOOAE: false, 538f);
				GuiElementSingle<TutorialClickOverlay>.instance.CLPPGONHLHI(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC);
				PECMCAOEMND = false;
				goto case 19u;
			}
			case 18u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("PlayWindowCount");
				object[] array = new object[0];
				array[1] = Localization.Localize("N");
				instance.PBEAOCBHFGD(aMKLKMJEMJM, Localization.LocalizeFormat("S", array), 735f, TutorialDialog.DODBDLEJOAM.TopRight);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(EPGFICIMJJA, new Vector3(1567f, 425f, 1923f), ELHGOHGPJCF: false, ENIHCPLOOAE: true, 558f);
				GuiElementSingle<TutorialClickOverlay>.instance.JGHBBJEFLEB(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC, GPCEHFNNCIN: false);
				goto IL_0c07;
			}
			case 19u:
				if (FGKIANHNMFF.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Active || FGKIANHNMFF.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Delivering)
				{
					if (PECMCAOEMND && FGKIANHNMFF.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Delivering)
					{
						ELPHLDJPBNJ = false;
						PECMCAOEMND = false;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
						GuiElementSingle<TutorialClickOverlay>.instance.Hide(146f);
						Singleton<GuiManager>.instance.TurnOffInputCompletly();
						PHDOCKCBJOF = new WaitForSeconds(673f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 94;
						}
						break;
					}
					goto IL_0c07;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent(" ", ELPHLDJPBNJ);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(407f);
				PHDOCKCBJOF = new WaitForSeconds(777f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 29;
				}
				break;
			case 20u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0758:
				if (FGKIANHNMFF.unitDictionaryId != BJGCPDNMHDH.mUnitToUpgrade.unitDictionaryId)
				{
					if (GOBCHPOLPIE != null && GOBCHPOLPIE.transform.position != IODGHHFAHJH)
					{
						IODGHHFAHJH = GOBCHPOLPIE.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateTapAnimation(IODGHHFAHJH, ELHGOHGPJCF: false);
						GuiElementSingle<TutorialClickOverlay>.instance.AJNGLEIBMHD(IODGHHFAHJH, CMIKGAOHHPH);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -117;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(496f);
				goto IL_07a0;
				IL_0c07:
				PHDOCKCBJOF = false;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 58;
				}
				break;
				IL_04cb:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -126;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("https://");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(710f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 10u;
				IL_07a0:
				Singleton<EventTrackingManager>.instance.RegisterTutorialUnitSelectedEvent("url", FKGHFOJFMBP);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(377f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -65;
				}
				break;
			}
			return true;
		}

		public void LKACEPHEHPK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MOMPOEEALPJ()
		{
			return PHDOCKCBJOF;
		}

		public void BCIPEBNJONK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void NINFHADPHJI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool DKJMOPNHIAB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.StartTutorial(isContinue: false);
				BJGCPDNMHDH.mUnitToUpgrade = BJGCPDNMHDH.ChooseUnit();
				Singleton<EventTrackingManager>.instance.RegisterTutorialMenuTutorialEvent("Purchase_Validated");
				Singleton<MessageManager>.instance.StopMessageCoroutine();
				goto case 1u;
			case 1u:
				if (!GuiScreenSingle<EndScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (GuiScreenSingle<EndScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				if (Singleton<GuiManager>.instance.AODFEHKBJIN != GuiScreenSingle<MainScreen>.instance)
				{
					goto default;
				}
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 3u;
			case 3u:
				if (!GuiScreenSingle<MainScreen>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE();
				GuiElementSingle<TutorialDialog>.instance.BLHPAFCOPMD(Localization.Localize("ANDROID: PACK "), Localization.Localize("{0} Emblem {1} LVL {2}"), 35f, TutorialDialog.DODBDLEJOAM.Right, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH.transform.position, ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1558f);
				GuiElementSingle<TutorialClickOverlay>.instance.GBHNBKFGCPG(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH, GPCEHFNNCIN: false);
				goto case 4u;
			case 4u:
				if (GuiScreenSingle<MainScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(" ");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(1484f);
				BJGCPDNMHDH.mRewardShowable = true;
				Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA("dailyRewardData", BJGCPDNMHDH.mUnitToUpgrade.upgradeSlots.GetSheetName());
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 6u;
			case 6u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.MHAIBHBGBOO())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				goto case 7u;
			case 7u:
				if (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.IOEJCIDBAPL(Localization.Localize("shotReal"), Localization.Localize("ID_RENTAL_GRENADE"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 26f, TutorialDialog.DODBDLEJOAM.Left);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<BattlePreparationScreen>.instance.JANFGHJMGBI.JANFGHJMGBI.transform.position, ELHGOHGPJCF: false, ENIHCPLOOAE: true, 1822f);
				GuiElementSingle<TutorialClickOverlay>.instance.CLPPGONHLHI(GuiScreenSingle<BattlePreparationScreen>.instance.JANFGHJMGBI.JANFGHJMGBI, GPCEHFNNCIN: false);
				GuiScreenSingle<ArmyScreen>.instance.SelectUnit(BJGCPDNMHDH.mUnitToUpgrade);
				goto case 8u;
			case 8u:
				if (!GuiElementSingle<TutorialDialog>.instance.BKIGLABDGCP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				BJGCPDNMHDH.mRewardShowable = true;
				IKAKODPFHAC = 621f;
				goto IL_04cb;
			case 9u:
				IKAKODPFHAC += Time.deltaTime;
				if (IKAKODPFHAC > 963f)
				{
					BJGCPDNMHDH.mWarbucksAdded = ((!(BJGCPDNMHDH.mUnitToUpgrade == null)) ? BJGCPDNMHDH.mUnitToUpgrade.upgradeSlots.upgradeSlot.upgradePrice : 161);
					BJGCPDNMHDH.mGoldAdded = ((BJGCPDNMHDH.mUnitToUpgrade == null) ? 1 : BJGCPDNMHDH.mUnitToUpgrade.upgradeSlots.instantUnitDeliveryPrice);
					GuiElementSingle<TutorialDialog>.instance.BELJAOIJCOJ(Localization.Localize("ID_ARENASHORTCUTEVENTSTART"), Localization.Localize("ID_TUTORIAL_UPGRADEWEAPON_4"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 30f, TutorialDialog.DODBDLEJOAM.Top);
				}
				goto IL_04cb;
			case 10u:
				if (!GuiScreenSingle<ArmyScreen>.instance.AFOFDNJOJHG())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -93;
					}
					break;
				}
				FKGHFOJFMBP = false;
				FGKIANHNMFF = GuiScreenSingle<ArmyScreen>.instance.BDBKFBEIHNF().BNPKCKFMBLG();
				if (FGKIANHNMFF.unitDictionaryId != BJGCPDNMHDH.mUnitToUpgrade.unitDictionaryId)
				{
					FKGHFOJFMBP = true;
					PHDOCKCBJOF = new WaitForSeconds(1942f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 122;
					}
					break;
				}
				goto IL_07a0;
			case 11u:
				GuiElementSingle<TutorialDialog>.instance.FJFFALBAFBD("Bad Decal Manager Data", 1080f);
				GOBCHPOLPIE = null;
				IODGHHFAHJH = Vector3.zero;
				CMIKGAOHHPH = Vector3.one;
				KFCAECGLKKO = GuiScreenSingle<ArmyScreen>.instance.MAPKDMOOFMM().GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						ArmyUpgradeIcon current = KFCAECGLKKO.Current;
						if (current.PPMNNKANOEF().unitDictionaryId == BJGCPDNMHDH.mUnitToUpgrade.unitDictionaryId)
						{
							GOBCHPOLPIE = current;
							IODGHHFAHJH = current.transform.position;
							CMIKGAOHHPH = current.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(IODGHHFAHJH, ELHGOHGPJCF: false, ENIHCPLOOAE: false, 148f);
							GuiElementSingle<TutorialClickOverlay>.instance.IGNJKOKGNOI(IODGHHFAHJH, CMIKGAOHHPH);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				goto IL_0758;
			case 12u:
				FGKIANHNMFF = GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().PPMNNKANOEF();
				goto IL_0758;
			case 13u:
			{
				GuiElementSingle<TutorialDialog>.instance.setDebug = false;
				TutorialDialog instance3 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM3 = Localization.Localize("One Time Reward: ");
				object[] array3 = new object[0];
				array3[0] = Localization.Localize("data saved in DB for unit {0} : {1}");
				instance3.DOLDLDECPIO(aMKLKMJEMJM3, Localization.LocalizeFormat("0", array3), 101f, TutorialDialog.DODBDLEJOAM.Top, NHEJDPIIOJG: false);
				DHEGKFCAAGP = GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.BFAEJEFLKHN.transform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DHEGKFCAAGP, new Vector3(1529f, 122f, 37f), ELHGOHGPJCF: false, ENIHCPLOOAE: false, 691f);
				GuiElementSingle<TutorialClickOverlay>.instance.MLCGPAJJOMB(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.BFAEJEFLKHN);
				goto case 14u;
			}
			case 14u:
				if (!GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.JKGHPLKKPLE.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 121;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(1549f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1751f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -4;
				}
				break;
			case 15u:
				MHBNLBPBEGE = GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.HKGGCIGOONK.cachedTransform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(MHBNLBPBEGE, new Vector3(984f, 1641f, 112f), ELHGOHGPJCF: false, ENIHCPLOOAE: true, 1492f);
				GuiElementSingle<TutorialClickOverlay>.instance.JGHBBJEFLEB(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC, GPCEHFNNCIN: false);
				goto case 16u;
			case 16u:
				if (FGKIANHNMFF.upgradeSlots.unitState != UpgradeSlots.JLANLLEABDC.Delivered)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -65;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("menu-unitstats-shotdamage");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialDialog>.instance.setDebug = false;
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(1471f);
				ELPHLDJPBNJ = true;
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(705f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 24;
				}
				break;
			case 17u:
			{
				TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM2 = Localization.Localize("strafing_left");
				object[] array2 = new object[0];
				array2[0] = Localization.Localize("ID_STATE_GAMELOADING");
				instance2.DOLDLDECPIO(aMKLKMJEMJM2, Localization.LocalizeFormat("Evaluation is old! ", array2), 3f, TutorialDialog.DODBDLEJOAM.BottomLeft);
				EPGFICIMJJA = GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC.transform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(EPGFICIMJJA, new Vector3(100f, 1662f, 694f), ELHGOHGPJCF: false, ENIHCPLOOAE: false, 935f);
				GuiElementSingle<TutorialClickOverlay>.instance.CAIGHMDPBDI(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC);
				PECMCAOEMND = true;
				goto case 19u;
			}
			case 18u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("Exception while Parsing");
				object[] array = new object[0];
				array[1] = Localization.Localize("Sniper_Tutorial_Duration");
				instance.PBEAOCBHFGD(aMKLKMJEMJM, Localization.LocalizeFormat("Time", array), 1928f, TutorialDialog.DODBDLEJOAM.BottomRight);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(EPGFICIMJJA, new Vector3(674f, 708f, 879f), ELHGOHGPJCF: false, ENIHCPLOOAE: true, 1187f);
				GuiElementSingle<TutorialClickOverlay>.instance.MLCGPAJJOMB(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC);
				goto IL_0c07;
			}
			case 19u:
				if (FGKIANHNMFF.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Delivering || FGKIANHNMFF.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Delivered)
				{
					if (PECMCAOEMND && FGKIANHNMFF.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Delivered)
					{
						ELPHLDJPBNJ = false;
						PECMCAOEMND = false;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
						GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(1933f);
						Singleton<GuiManager>.instance.TurnOffInputCompletly();
						PHDOCKCBJOF = new WaitForSeconds(835f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 92;
						}
						break;
					}
					goto IL_0c07;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("ExtraRewards", ELPHLDJPBNJ);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(64f);
				PHDOCKCBJOF = new WaitForSeconds(880f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -38;
				}
				break;
			case 20u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_0758:
				if (FGKIANHNMFF.unitDictionaryId != BJGCPDNMHDH.mUnitToUpgrade.unitDictionaryId)
				{
					if (GOBCHPOLPIE != null && GOBCHPOLPIE.transform.position != IODGHHFAHJH)
					{
						IODGHHFAHJH = GOBCHPOLPIE.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.EIDNJNBEPFI(IODGHHFAHJH, ELHGOHGPJCF: false);
						GuiElementSingle<TutorialClickOverlay>.instance.IGNJKOKGNOI(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 87;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(35f);
				goto IL_07a0;
				IL_0c07:
				PHDOCKCBJOF = false;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -96;
				}
				break;
				IL_04cb:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 109;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_DEBUG_STACKTRACEINCONSOLE");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(1934f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 10u;
				IL_07a0:
				Singleton<EventTrackingManager>.instance.RegisterTutorialUnitSelectedEvent("Visual {0}, overcount {1}, added warbucks {2}", FKGHFOJFMBP);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1896f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -102;
				}
				break;
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
				BJGCPDNMHDH.StartTutorial(isContinue: false);
				BJGCPDNMHDH.mUnitToUpgrade = BJGCPDNMHDH.ChooseUnit();
				Singleton<EventTrackingManager>.instance.RegisterTutorialMenuTutorialEvent("M");
				Singleton<MessageManager>.instance.LOKBALDOPIK();
				goto case 1u;
			case 1u:
				if (!GuiScreenSingle<EndScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (GuiScreenSingle<EndScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				if (Singleton<GuiManager>.instance.AODFEHKBJIN != GuiScreenSingle<MainScreen>.instance)
				{
					goto default;
				}
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 3u;
			case 3u:
				if (!GuiScreenSingle<MainScreen>.instance.BJNBLINDAED())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
				GuiElementSingle<TutorialDialog>.instance.BLHPAFCOPMD(Localization.Localize("leagueMembers"), Localization.Localize("CSV saved"), 1731f, TutorialDialog.DODBDLEJOAM.TopLeft);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH.transform.position, ELHGOHGPJCF: false, ENIHCPLOOAE: false, 443f);
				GuiElementSingle<TutorialClickOverlay>.instance.LECHCOBHAFP(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH);
				goto case 4u;
			case 4u:
				if (GuiScreenSingle<MainScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("PlayerName");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(60f);
				BJGCPDNMHDH.mRewardShowable = false;
				Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA("subscription", BJGCPDNMHDH.mUnitToUpgrade.upgradeSlots.GetSheetName());
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 6u;
			case 6u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.LHDGJFHPJNM())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 7u;
			case 7u:
				if (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.KHPBNEBLEEF(Localization.Localize("antialiasing"), Localization.Localize("GameLaunch"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 1200f, TutorialDialog.DODBDLEJOAM.TopRight);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<BattlePreparationScreen>.instance.JANFGHJMGBI.JANFGHJMGBI.transform.position, ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1678f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<BattlePreparationScreen>.instance.JANFGHJMGBI.JANFGHJMGBI);
				GuiScreenSingle<ArmyScreen>.instance.SelectUnit(BJGCPDNMHDH.mUnitToUpgrade);
				goto case 8u;
			case 8u:
				if (!GuiElementSingle<TutorialDialog>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				BJGCPDNMHDH.mRewardShowable = false;
				IKAKODPFHAC = 266f;
				goto IL_04cb;
			case 9u:
				IKAKODPFHAC += Time.deltaTime;
				if (IKAKODPFHAC > 950f)
				{
					BJGCPDNMHDH.mWarbucksAdded = ((!(BJGCPDNMHDH.mUnitToUpgrade == null)) ? BJGCPDNMHDH.mUnitToUpgrade.upgradeSlots.upgradeSlot.upgradePrice : (-174));
					BJGCPDNMHDH.mGoldAdded = ((!(BJGCPDNMHDH.mUnitToUpgrade == null)) ? BJGCPDNMHDH.mUnitToUpgrade.upgradeSlots.instantUnitDeliveryPrice : 0);
					GuiElementSingle<TutorialDialog>.instance.EOPPCIEONEG(Localization.Localize("DeliveryTime"), Localization.Localize("WeaponTutorial"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 139f, TutorialDialog.DODBDLEJOAM.BottomRight);
				}
				goto IL_04cb;
			case 10u:
				if (!GuiScreenSingle<ArmyScreen>.instance.BKIGLABDGCP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -43;
					}
					break;
				}
				FKGHFOJFMBP = true;
				FGKIANHNMFF = GuiScreenSingle<ArmyScreen>.instance.selectedIcon.PPMNNKANOEF();
				if (FGKIANHNMFF.unitDictionaryId != BJGCPDNMHDH.mUnitToUpgrade.unitDictionaryId)
				{
					FKGHFOJFMBP = false;
					PHDOCKCBJOF = new WaitForSeconds(984f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 76;
					}
					break;
				}
				goto IL_07a0;
			case 11u:
				GuiElementSingle<TutorialDialog>.instance.NIGINCPEHFP("ID_STAT_WINLOSSRATIO", 235f, TutorialDialog.DODBDLEJOAM.BottomRight);
				GOBCHPOLPIE = null;
				IODGHHFAHJH = Vector3.zero;
				CMIKGAOHHPH = Vector3.one;
				KFCAECGLKKO = GuiScreenSingle<ArmyScreen>.instance.MAPKDMOOFMM().GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						ArmyUpgradeIcon current = KFCAECGLKKO.Current;
						if (current.PPMNNKANOEF().unitDictionaryId == BJGCPDNMHDH.mUnitToUpgrade.unitDictionaryId)
						{
							GOBCHPOLPIE = current;
							IODGHHFAHJH = current.transform.position;
							CMIKGAOHHPH = current.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(IODGHHFAHJH, ELHGOHGPJCF: false, ENIHCPLOOAE: true, 758f);
							GuiElementSingle<TutorialClickOverlay>.instance.NNPKOKCJMHL(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				goto IL_0758;
			case 12u:
				FGKIANHNMFF = GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().KHEOKHHDGPO();
				goto IL_0758;
			case 13u:
			{
				GuiElementSingle<TutorialDialog>.instance.setDebug = false;
				TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM2 = Localization.Localize("GetGameConfiguration()");
				object[] array2 = new object[0];
				array2[0] = Localization.Localize("{0}.");
				instance2.ShowMenuTutorial(aMKLKMJEMJM2, Localization.LocalizeFormat("GameLauncher.Async started", array2), 296f, TutorialDialog.DODBDLEJOAM.Bottom);
				DHEGKFCAAGP = GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.BFAEJEFLKHN.transform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DHEGKFCAAGP, new Vector3(460f, 1680f, 788f), ELHGOHGPJCF: true, ENIHCPLOOAE: true, 1603f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.BFAEJEFLKHN, GPCEHFNNCIN: false);
				goto case 14u;
			}
			case 14u:
				if (!GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.JKGHPLKKPLE.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -77;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(1144f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1843f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -27;
				}
				break;
			case 15u:
				MHBNLBPBEGE = GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.HKGGCIGOONK.cachedTransform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(MHBNLBPBEGE, new Vector3(1861f, 1060f, 1130f), ELHGOHGPJCF: true, ENIHCPLOOAE: true, 229f);
				GuiElementSingle<TutorialClickOverlay>.instance.CLPPGONHLHI(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC);
				goto case 16u;
			case 16u:
				if (FGKIANHNMFF.upgradeSlots.unitState != UpgradeSlots.JLANLLEABDC.Delivering)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -88;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("game-card-ico-supersoldiers");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				GuiElementSingle<TutorialDialog>.instance.setDebug = false;
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(1549f);
				ELPHLDJPBNJ = false;
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1482f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 91;
				}
				break;
			case 17u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("Bad WAR ARENA Data, data= ");
				object[] array = new object[0];
				array[1] = Localization.Localize("FuseSDK: Parsing error in _GameDataReceived");
				instance.DOLDLDECPIO(aMKLKMJEMJM, Localization.LocalizeFormat("ID_RETRY", array), 1194f, TutorialDialog.DODBDLEJOAM.BottomLeft, NHEJDPIIOJG: false);
				EPGFICIMJJA = GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC.transform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(EPGFICIMJJA, new Vector3(1018f, 577f, 794f), ELHGOHGPJCF: true, ENIHCPLOOAE: true, 170f);
				GuiElementSingle<TutorialClickOverlay>.instance.MEBFBNDKOGD(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC, GPCEHFNNCIN: false);
				PECMCAOEMND = true;
				goto case 19u;
			}
			case 18u:
				GuiElementSingle<TutorialDialog>.instance.BLHPAFCOPMD(Localization.Localize("Mobile/Diffuse"), Localization.LocalizeFormat("S", Localization.Localize("RETRYPERM")), 334f, TutorialDialog.DODBDLEJOAM.BottomRight);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(EPGFICIMJJA, new Vector3(293f, 395f, 796f), ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1308f);
				GuiElementSingle<TutorialClickOverlay>.instance.JGHBBJEFLEB(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC);
				goto IL_0c07;
			case 19u:
				if (FGKIANHNMFF.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Delivering || FGKIANHNMFF.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Delivered)
				{
					if (PECMCAOEMND && FGKIANHNMFF.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.UnitDelivering)
					{
						ELPHLDJPBNJ = true;
						PECMCAOEMND = true;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
						GuiElementSingle<TutorialClickOverlay>.instance.Hide(1535f);
						Singleton<GuiManager>.instance.CMCCOCBIGBB();
						PHDOCKCBJOF = new WaitForSeconds(1054f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 106;
						}
						break;
					}
					goto IL_0c07;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("Player_Level", ELPHLDJPBNJ);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(1133f);
				PHDOCKCBJOF = new WaitForSeconds(259f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -22;
				}
				break;
			case 20u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0758:
				if (FGKIANHNMFF.unitDictionaryId != BJGCPDNMHDH.mUnitToUpgrade.unitDictionaryId)
				{
					if (GOBCHPOLPIE != null && GOBCHPOLPIE.transform.position != IODGHHFAHJH)
					{
						IODGHHFAHJH = GOBCHPOLPIE.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.IMOAGBADPCC(IODGHHFAHJH, ELHGOHGPJCF: false);
						GuiElementSingle<TutorialClickOverlay>.instance.EEMMKEMADFC(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -63;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(826f);
				goto IL_07a0;
				IL_0c07:
				PHDOCKCBJOF = false;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 47;
				}
				break;
				IL_04cb:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -76;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("champion");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(1783f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 10u;
				IL_07a0:
				Singleton<EventTrackingManager>.instance.KEKPOIPDIGK("run", FKGHFOJFMBP);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(753f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 73;
				}
				break;
			}
			return true;
		}

		public bool DEEBEBGBMKK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.StartTutorial(isContinue: true);
				BJGCPDNMHDH.mUnitToUpgrade = BJGCPDNMHDH.ChooseUnit();
				Singleton<EventTrackingManager>.instance.RegisterTutorialMenuTutorialEvent("Player_Waited_Till_Delivery_Ends");
				Singleton<MessageManager>.instance.OILMPBGNNBD();
				goto case 1u;
			case 1u:
				if (!GuiScreenSingle<EndScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (GuiScreenSingle<EndScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (Singleton<GuiManager>.instance.AODFEHKBJIN != GuiScreenSingle<MainScreen>.instance)
				{
					goto default;
				}
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 3u;
			case 3u:
				if (!GuiScreenSingle<MainScreen>.instance.LHDGJFHPJNM())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE();
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("Awaiting players - Removing player "), Localization.Localize("Skipping next player league notification"), 1259f, TutorialDialog.DODBDLEJOAM.BottomLeft);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH.transform.position, ELHGOHGPJCF: false, ENIHCPLOOAE: true, 1697f);
				GuiElementSingle<TutorialClickOverlay>.instance.GBHNBKFGCPG(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH, GPCEHFNNCIN: false);
				goto case 4u;
			case 4u:
				if (GuiScreenSingle<MainScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_DAILYGOLDBOOSTERHINT1");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(1649f);
				BJGCPDNMHDH.mRewardShowable = true;
				Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA("_CameraWS", BJGCPDNMHDH.mUnitToUpgrade.upgradeSlots.GetSheetName());
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 6u;
			case 6u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.BJNBLINDAED())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				goto case 7u;
			case 7u:
				if (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.HNOHAMJNOKH(Localization.Localize(" tutorial running: "), Localization.Localize("SquadId"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 563f);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<BattlePreparationScreen>.instance.JANFGHJMGBI.JANFGHJMGBI.transform.position, ELHGOHGPJCF: false, ENIHCPLOOAE: true, 639f);
				GuiElementSingle<TutorialClickOverlay>.instance.MEBFBNDKOGD(GuiScreenSingle<BattlePreparationScreen>.instance.JANFGHJMGBI.JANFGHJMGBI, GPCEHFNNCIN: false);
				GuiScreenSingle<ArmyScreen>.instance.PCALNGOCDKE(BJGCPDNMHDH.mUnitToUpgrade);
				goto case 8u;
			case 8u:
				if (!GuiElementSingle<TutorialDialog>.instance.MHAIBHBGBOO())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				BJGCPDNMHDH.mRewardShowable = true;
				IKAKODPFHAC = 1773f;
				goto IL_04cb;
			case 9u:
				IKAKODPFHAC += Time.deltaTime;
				if (IKAKODPFHAC > 1562f)
				{
					BJGCPDNMHDH.mWarbucksAdded = ((!(BJGCPDNMHDH.mUnitToUpgrade == null)) ? BJGCPDNMHDH.mUnitToUpgrade.upgradeSlots.upgradeSlot.upgradePrice : 38);
					BJGCPDNMHDH.mGoldAdded = ((BJGCPDNMHDH.mUnitToUpgrade == null) ? 1 : BJGCPDNMHDH.mUnitToUpgrade.upgradeSlots.instantUnitDeliveryPrice);
					GuiElementSingle<TutorialDialog>.instance.NHJEOINEAEO(Localization.Localize("Prefabs Full Path: \"{0}\"\n"), Localization.Localize("Sessions"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 1453f, TutorialDialog.DODBDLEJOAM.BottomRight);
				}
				goto IL_04cb;
			case 10u:
				if (!GuiScreenSingle<ArmyScreen>.instance.AFOFDNJOJHG())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 17;
					}
					break;
				}
				FKGHFOJFMBP = false;
				FGKIANHNMFF = GuiScreenSingle<ArmyScreen>.instance.BDBKFBEIHNF().AIHMCHBCJDO();
				if (FGKIANHNMFF.unitDictionaryId != BJGCPDNMHDH.mUnitToUpgrade.unitDictionaryId)
				{
					FKGHFOJFMBP = true;
					PHDOCKCBJOF = new WaitForSeconds(699f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 88;
					}
					break;
				}
				goto IL_07a0;
			case 11u:
				GuiElementSingle<TutorialDialog>.instance.ShowSpecial("CONFIRM", 837f, TutorialDialog.DODBDLEJOAM.BottomLeft);
				GOBCHPOLPIE = null;
				IODGHHFAHJH = Vector3.zero;
				CMIKGAOHHPH = Vector3.one;
				KFCAECGLKKO = GuiScreenSingle<ArmyScreen>.instance.armyIcons.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						ArmyUpgradeIcon current = KFCAECGLKKO.Current;
						if (current.BNPKCKFMBLG().unitDictionaryId == BJGCPDNMHDH.mUnitToUpgrade.unitDictionaryId)
						{
							GOBCHPOLPIE = current;
							IODGHHFAHJH = current.transform.position;
							CMIKGAOHHPH = current.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(IODGHHFAHJH, ELHGOHGPJCF: false, ENIHCPLOOAE: false, 780f);
							GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(IODGHHFAHJH, CMIKGAOHHPH);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				goto IL_0758;
			case 12u:
				FGKIANHNMFF = GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().levelBehaviour;
				goto IL_0758;
			case 13u:
			{
				GuiElementSingle<TutorialDialog>.instance.setDebug = true;
				TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM2 = Localization.Localize("\n");
				object[] array2 = new object[0];
				array2[1] = Localization.Localize("Squad name failure");
				instance2.DOLDLDECPIO(aMKLKMJEMJM2, Localization.LocalizeFormat("extraTickets", array2), 1751f, TutorialDialog.DODBDLEJOAM.Bottom);
				DHEGKFCAAGP = GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.BFAEJEFLKHN.transform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DHEGKFCAAGP, new Vector3(1957f, 753f, 1287f), ELHGOHGPJCF: false, ENIHCPLOOAE: true, 1693f);
				GuiElementSingle<TutorialClickOverlay>.instance.MLCGPAJJOMB(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.BFAEJEFLKHN, GPCEHFNNCIN: false);
				goto case 14u;
			}
			case 14u:
				if (!GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.JKGHPLKKPLE.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 70;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(574f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1154f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -86;
				}
				break;
			case 15u:
				MHBNLBPBEGE = GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.HKGGCIGOONK.cachedTransform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(MHBNLBPBEGE, new Vector3(486f, 561f, 570f), ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1707f);
				GuiElementSingle<TutorialClickOverlay>.instance.MLCGPAJJOMB(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC);
				goto case 16u;
			case 16u:
				if (FGKIANHNMFF.upgradeSlots.unitState != UpgradeSlots.JLANLLEABDC.Delivering)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -21;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Mobile/Diffuse");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialDialog>.instance.setDebug = false;
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(1918f);
				ELPHLDJPBNJ = true;
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1972f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 24;
				}
				break;
			case 17u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("isCanceled");
				object[] array = new object[1];
				array[1] = Localization.Localize("menu-wftv-twitch-ico");
				instance.DOLDLDECPIO(aMKLKMJEMJM, Localization.LocalizeFormat("Google2u.DBUpgradeSlotsAssaulter", array), 143f, TutorialDialog.DODBDLEJOAM.Bottom);
				EPGFICIMJJA = GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC.transform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(EPGFICIMJJA, new Vector3(1040f, 1760f, 1779f), ELHGOHGPJCF: false, ENIHCPLOOAE: true, 1885f);
				GuiElementSingle<TutorialClickOverlay>.instance.MLCGPAJJOMB(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC, GPCEHFNNCIN: false);
				PECMCAOEMND = true;
				goto case 19u;
			}
			case 18u:
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("IsWarPath"), Localization.LocalizeFormat("Play_Card_Tutorial", Localization.Localize("BoughtIndex")), 193f, TutorialDialog.DODBDLEJOAM.TopLeft);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(EPGFICIMJJA, new Vector3(1036f, 1605f, 1884f), ELHGOHGPJCF: true, ENIHCPLOOAE: true, 744f);
				GuiElementSingle<TutorialClickOverlay>.instance.JGHBBJEFLEB(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC, GPCEHFNNCIN: false);
				goto IL_0c07;
			case 19u:
				if (FGKIANHNMFF.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Active || FGKIANHNMFF.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.UnitDelivering)
				{
					if (PECMCAOEMND && FGKIANHNMFF.upgradeSlots.unitState == (UpgradeSlots.JLANLLEABDC)8)
					{
						ELPHLDJPBNJ = false;
						PECMCAOEMND = false;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
						GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(943f);
						Singleton<GuiManager>.instance.CMCCOCBIGBB();
						PHDOCKCBJOF = new WaitForSeconds(1776f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = -80;
						}
						break;
					}
					goto IL_0c07;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("ID_TUTORIAL_DELIVERED_UNIT", ELPHLDJPBNJ);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(429f);
				PHDOCKCBJOF = new WaitForSeconds(1053f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -87;
				}
				break;
			case 20u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_0758:
				if (FGKIANHNMFF.unitDictionaryId != BJGCPDNMHDH.mUnitToUpgrade.unitDictionaryId)
				{
					if (GOBCHPOLPIE != null && GOBCHPOLPIE.transform.position != IODGHHFAHJH)
					{
						IODGHHFAHJH = GOBCHPOLPIE.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.OBNDALJCPHG(IODGHHFAHJH);
						GuiElementSingle<TutorialClickOverlay>.instance.IGNJKOKGNOI(IODGHHFAHJH, CMIKGAOHHPH);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -57;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(727f);
				goto IL_07a0;
				IL_0c07:
				PHDOCKCBJOF = false;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 12;
				}
				break;
				IL_04cb:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -79;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("These colours are used in IDs:\n");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(1367f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 10u;
				IL_07a0:
				Singleton<EventTrackingManager>.instance.KEKPOIPDIGK("CONTENTS_FILE_DESCRIPTOR", FKGHFOJFMBP);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1517f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 16;
				}
				break;
			}
			return false;
		}

		public void NAMBILMHOPD()
		{
			throw new NotSupportedException();
		}

		public void EMICCACCFIP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BEGHOADNMJF()
		{
			return PHDOCKCBJOF;
		}

		public void DBJCDLFKDDI()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CJCHFDFCPPL()
		{
			return PHDOCKCBJOF;
		}

		public void PAOPOFJHFGD()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public BAHBKLBBNGA()
		{
		}

		[SpecialName]
		private object OJANHAIEAEJ()
		{
			return PHDOCKCBJOF;
		}

		public void FLCIMHOJPDF()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void JKOCLGOOBEK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void HNFEJKPKEHK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void MIPBONGPIJE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void IKNKDDMLDIN()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FMCLBOCENPE()
		{
			return PHDOCKCBJOF;
		}

		public void HDDLDAHLPCO()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool GPIPJIDGCKM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.StartTutorial(isContinue: true);
				BJGCPDNMHDH.mUnitToUpgrade = BJGCPDNMHDH.ChooseUnit();
				Singleton<EventTrackingManager>.instance.RegisterTutorialMenuTutorialEvent("trial");
				Singleton<MessageManager>.instance.StopMessageCoroutine();
				goto case 1u;
			case 1u:
				if (!GuiScreenSingle<EndScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (GuiScreenSingle<EndScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				if (Singleton<GuiManager>.instance.AODFEHKBJIN != GuiScreenSingle<MainScreen>.instance)
				{
					goto default;
				}
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 3u;
			case 3u:
				if (!GuiScreenSingle<MainScreen>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE();
				GuiElementSingle<TutorialDialog>.instance.DOLDLDECPIO(Localization.Localize("S"), Localization.Localize("GameControllerOnline.StartGame START"), 1844f, TutorialDialog.DODBDLEJOAM.Left, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH.transform.position, ELHGOHGPJCF: true, ENIHCPLOOAE: true, 1300f);
				GuiElementSingle<TutorialClickOverlay>.instance.LECHCOBHAFP(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH);
				goto case 4u;
			case 4u:
				if (GuiScreenSingle<MainScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(")");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(1636f);
				BJGCPDNMHDH.mRewardShowable = false;
				Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA(" {0}\u00a0{1}", BJGCPDNMHDH.mUnitToUpgrade.upgradeSlots.GetSheetName());
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 6u;
			case 6u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.AFOFDNJOJHG())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				goto case 7u;
			case 7u:
				if (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.HNOHAMJNOKH(Localization.Localize("Wrong_Category"), Localization.Localize("Para funcionar, WarFriends necesita descargar unos 190 MB de datos adicionales.\nEl tiempo de descarga puede variar, dependiendo de tu red y tu ubicación.\n\n¿Continuar?"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 1787f, TutorialDialog.DODBDLEJOAM.Left);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<BattlePreparationScreen>.instance.JANFGHJMGBI.JANFGHJMGBI.transform.position, ELHGOHGPJCF: true, ENIHCPLOOAE: false, 1991f);
				GuiElementSingle<TutorialClickOverlay>.instance.JGHBBJEFLEB(GuiScreenSingle<BattlePreparationScreen>.instance.JANFGHJMGBI.JANFGHJMGBI, GPCEHFNNCIN: false);
				GuiScreenSingle<ArmyScreen>.instance.PCALNGOCDKE(BJGCPDNMHDH.mUnitToUpgrade);
				goto case 8u;
			case 8u:
				if (!GuiElementSingle<TutorialDialog>.instance.MHAIBHBGBOO())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				BJGCPDNMHDH.mRewardShowable = false;
				IKAKODPFHAC = 141f;
				goto IL_04cb;
			case 9u:
				IKAKODPFHAC += Time.deltaTime;
				if (IKAKODPFHAC > 1041f)
				{
					BJGCPDNMHDH.mWarbucksAdded = ((!(BJGCPDNMHDH.mUnitToUpgrade == null)) ? BJGCPDNMHDH.mUnitToUpgrade.upgradeSlots.upgradeSlot.upgradePrice : (-13));
					BJGCPDNMHDH.mGoldAdded = ((BJGCPDNMHDH.mUnitToUpgrade == null) ? 1 : BJGCPDNMHDH.mUnitToUpgrade.upgradeSlots.instantUnitDeliveryPrice);
					GuiElementSingle<TutorialDialog>.instance.NHJEOINEAEO(Localization.Localize("SetNoDamageChanceRPC"), Localization.Localize("ID_SKILLSHOTHINT_EXPLOSIVEKILL"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 566f, TutorialDialog.DODBDLEJOAM.Bottom);
				}
				goto IL_04cb;
			case 10u:
				if (!GuiScreenSingle<ArmyScreen>.instance.AFOFDNJOJHG())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -26;
					}
					break;
				}
				FKGHFOJFMBP = true;
				FGKIANHNMFF = GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().AIHMCHBCJDO();
				if (FGKIANHNMFF.unitDictionaryId != BJGCPDNMHDH.mUnitToUpgrade.unitDictionaryId)
				{
					FKGHFOJFMBP = true;
					PHDOCKCBJOF = new WaitForSeconds(81f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 117;
					}
					break;
				}
				goto IL_07a0;
			case 11u:
				GuiElementSingle<TutorialDialog>.instance.NIGINCPEHFP("isGameCenter", 1101f, TutorialDialog.DODBDLEJOAM.Right);
				GOBCHPOLPIE = null;
				IODGHHFAHJH = Vector3.zero;
				CMIKGAOHHPH = Vector3.one;
				KFCAECGLKKO = GuiScreenSingle<ArmyScreen>.instance.MAPKDMOOFMM().GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						ArmyUpgradeIcon current = KFCAECGLKKO.Current;
						if (current.BNPKCKFMBLG().unitDictionaryId == BJGCPDNMHDH.mUnitToUpgrade.unitDictionaryId)
						{
							GOBCHPOLPIE = current;
							IODGHHFAHJH = current.transform.position;
							CMIKGAOHHPH = current.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(IODGHHFAHJH, ELHGOHGPJCF: true, ENIHCPLOOAE: false, 309f);
							GuiElementSingle<TutorialClickOverlay>.instance.IGNJKOKGNOI(IODGHHFAHJH, CMIKGAOHHPH);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				goto IL_0758;
			case 12u:
				FGKIANHNMFF = GuiScreenSingle<ArmyScreen>.instance.BDBKFBEIHNF().levelBehaviour;
				goto IL_0758;
			case 13u:
			{
				GuiElementSingle<TutorialDialog>.instance.DEACFMCKNKM(IDEBKDPMPGM: false);
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("(Lcom/google/android/gms/common/api/GoogleApiClient;)Ljava/lang/String;");
				object[] array = new object[1];
				array[1] = Localization.Localize("+{0}");
				instance.PBEAOCBHFGD(aMKLKMJEMJM, Localization.LocalizeFormat("BattleRewards", array), 1716f, TutorialDialog.DODBDLEJOAM.BottomRight);
				DHEGKFCAAGP = GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.BFAEJEFLKHN.transform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(DHEGKFCAAGP, new Vector3(1716f, 1250f, 694f), ELHGOHGPJCF: false, ENIHCPLOOAE: true, 823f);
				GuiElementSingle<TutorialClickOverlay>.instance.FCGLGPIBAEN(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.BFAEJEFLKHN);
				goto case 14u;
			}
			case 14u:
				if (!GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.JKGHPLKKPLE.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -60;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(700f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1825f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 104;
				}
				break;
			case 15u:
				MHBNLBPBEGE = GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.HKGGCIGOONK.cachedTransform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(MHBNLBPBEGE, new Vector3(1297f, 84f, 1227f), ELHGOHGPJCF: true, ENIHCPLOOAE: true, 40f);
				GuiElementSingle<TutorialClickOverlay>.instance.FCGLGPIBAEN(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC, GPCEHFNNCIN: false);
				goto case 16u;
			case 16u:
				if (FGKIANHNMFF.upgradeSlots.unitState != UpgradeSlots.JLANLLEABDC.Active)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 38;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Time");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialDialog>.instance.DEACFMCKNKM(IDEBKDPMPGM: false);
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(1584f);
				ELPHLDJPBNJ = false;
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1910f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -109;
				}
				break;
			case 17u:
				GuiElementSingle<TutorialDialog>.instance.DOLDLDECPIO(Localization.Localize("qbz_idle"), Localization.LocalizeFormat("BotUnits", Localization.Localize("ClientId")), 1383f, TutorialDialog.DODBDLEJOAM.TopLeft);
				EPGFICIMJJA = GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC.transform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(EPGFICIMJJA, new Vector3(1472f, 203f, 690f), ELHGOHGPJCF: true, ENIHCPLOOAE: true, 1450f);
				GuiElementSingle<TutorialClickOverlay>.instance.MEBFBNDKOGD(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC, GPCEHFNNCIN: false);
				PECMCAOEMND = true;
				goto case 19u;
			case 18u:
				GuiElementSingle<TutorialDialog>.instance.DOLDLDECPIO(Localization.Localize("."), Localization.LocalizeFormat("Player_Level", Localization.Localize("NetworkReInstantiate")), 962f, TutorialDialog.DODBDLEJOAM.Center, NHEJDPIIOJG: false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(EPGFICIMJJA, new Vector3(1171f, 1418f, 1415f), ELHGOHGPJCF: true, ENIHCPLOOAE: false, 144f);
				GuiElementSingle<TutorialClickOverlay>.instance.MLCGPAJJOMB(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC, GPCEHFNNCIN: false);
				goto IL_0c07;
			case 19u:
				if (FGKIANHNMFF.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.UnitDelivering || FGKIANHNMFF.upgradeSlots.unitState == (UpgradeSlots.JLANLLEABDC)7)
				{
					if (PECMCAOEMND && FGKIANHNMFF.upgradeSlots.unitState == (UpgradeSlots.JLANLLEABDC)7)
					{
						ELPHLDJPBNJ = false;
						PECMCAOEMND = false;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.Hide();
						GuiElementSingle<TutorialClickOverlay>.instance.Hide(751f);
						Singleton<GuiManager>.instance.TurnOffInputCompletly();
						PHDOCKCBJOF = new WaitForSeconds(862f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 63;
						}
						break;
					}
					goto IL_0c07;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("ON DEBUG ARENA!", ELPHLDJPBNJ);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(455f);
				PHDOCKCBJOF = new WaitForSeconds(1010f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -30;
				}
				break;
			case 20u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0758:
				if (FGKIANHNMFF.unitDictionaryId != BJGCPDNMHDH.mUnitToUpgrade.unitDictionaryId)
				{
					if (GOBCHPOLPIE != null && GOBCHPOLPIE.transform.position != IODGHHFAHJH)
					{
						IODGHHFAHJH = GOBCHPOLPIE.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.NFPJIFHLFNB(IODGHHFAHJH);
						GuiElementSingle<TutorialClickOverlay>.instance.IGNJKOKGNOI(IODGHHFAHJH, CMIKGAOHHPH);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 108;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(883f);
				goto IL_07a0;
				IL_0c07:
				PHDOCKCBJOF = true;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -20;
				}
				break;
				IL_04cb:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 80;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_CATEGORY_LOW_SG_SHOTGUN");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(1310f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 10u;
				IL_07a0:
				Singleton<EventTrackingManager>.instance.KEKPOIPDIGK("\"", FKGHFOJFMBP);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1632f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -17;
				}
				break;
			}
			return true;
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

		public void IGBHHLFACKO()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object LMJBCDNGAHP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CLFFFNGBPGJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KJMPNHLOKJL()
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
				BJGCPDNMHDH.StartTutorial(isContinue: false);
				BJGCPDNMHDH.mUnitToUpgrade = BJGCPDNMHDH.ChooseUnit();
				Singleton<EventTrackingManager>.instance.RegisterTutorialMenuTutorialEvent("Agent get stucked !!! ");
				Singleton<MessageManager>.instance.MNDIJBOCFPM();
				goto case 1u;
			case 1u:
				if (!GuiScreenSingle<EndScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 2u;
			case 2u:
				if (GuiScreenSingle<EndScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				if (Singleton<GuiManager>.instance.AODFEHKBJIN != GuiScreenSingle<MainScreen>.instance)
				{
					goto default;
				}
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 3u;
			case 3u:
				if (!GuiScreenSingle<MainScreen>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE();
				GuiElementSingle<TutorialDialog>.instance.DOLDLDECPIO(Localization.Localize("0"), Localization.Localize("{0}/{1} ({2})\n"), 1983f, TutorialDialog.DODBDLEJOAM.BottomRight);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH.transform.position, ELHGOHGPJCF: true, ENIHCPLOOAE: false, 898f);
				GuiElementSingle<TutorialClickOverlay>.instance.GBHNBKFGCPG(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH, GPCEHFNNCIN: false);
				goto case 4u;
			case 4u:
				if (GuiScreenSingle<MainScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("RETRYPERM");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(1785f);
				BJGCPDNMHDH.mRewardShowable = true;
				Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA("country-belgium", BJGCPDNMHDH.mUnitToUpgrade.upgradeSlots.GetSheetName());
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 6u;
			case 6u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.BJNBLINDAED())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 7u;
			case 7u:
				if (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.IOEJCIDBAPL(Localization.Localize("-[^-]*$"), Localization.Localize("ID_CATEGORY_LOW_PL_LMG"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 370f, TutorialDialog.DODBDLEJOAM.Left);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<BattlePreparationScreen>.instance.JANFGHJMGBI.JANFGHJMGBI.transform.position, ELHGOHGPJCF: false, ENIHCPLOOAE: false, 585f);
				GuiElementSingle<TutorialClickOverlay>.instance.CLPPGONHLHI(GuiScreenSingle<BattlePreparationScreen>.instance.JANFGHJMGBI.JANFGHJMGBI, GPCEHFNNCIN: false);
				GuiScreenSingle<ArmyScreen>.instance.SelectUnit(BJGCPDNMHDH.mUnitToUpgrade);
				goto case 8u;
			case 8u:
				if (!GuiElementSingle<TutorialDialog>.instance.LHDGJFHPJNM())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				BJGCPDNMHDH.mRewardShowable = true;
				IKAKODPFHAC = 1085f;
				goto IL_04cb;
			case 9u:
				IKAKODPFHAC += Time.deltaTime;
				if (IKAKODPFHAC > 1436f)
				{
					BJGCPDNMHDH.mWarbucksAdded = ((!(BJGCPDNMHDH.mUnitToUpgrade == null)) ? BJGCPDNMHDH.mUnitToUpgrade.upgradeSlots.upgradeSlot.upgradePrice : 159);
					BJGCPDNMHDH.mGoldAdded = ((!(BJGCPDNMHDH.mUnitToUpgrade == null)) ? BJGCPDNMHDH.mUnitToUpgrade.upgradeSlots.instantUnitDeliveryPrice : 0);
					GuiElementSingle<TutorialDialog>.instance.ShowReward(Localization.Localize("Facebook_Activated"), Localization.Localize("()Z"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 327f, TutorialDialog.DODBDLEJOAM.Right);
				}
				goto IL_04cb;
			case 10u:
				if (!GuiScreenSingle<ArmyScreen>.instance.AFOFDNJOJHG())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -38;
					}
					break;
				}
				FKGHFOJFMBP = true;
				FGKIANHNMFF = GuiScreenSingle<ArmyScreen>.instance.MJKLLFPEKAJ().BNPKCKFMBLG();
				if (FGKIANHNMFF.unitDictionaryId != BJGCPDNMHDH.mUnitToUpgrade.unitDictionaryId)
				{
					FKGHFOJFMBP = true;
					PHDOCKCBJOF = new WaitForSeconds(254f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 21;
					}
					break;
				}
				goto IL_07a0;
			case 11u:
				GuiElementSingle<TutorialDialog>.instance.FJFFALBAFBD("getGameConfigurationValue", 1991f, TutorialDialog.DODBDLEJOAM.Right);
				GOBCHPOLPIE = null;
				IODGHHFAHJH = Vector3.zero;
				CMIKGAOHHPH = Vector3.one;
				KFCAECGLKKO = GuiScreenSingle<ArmyScreen>.instance.OOLKNBJNFJC().GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						ArmyUpgradeIcon current = KFCAECGLKKO.Current;
						if (current.BNPKCKFMBLG().unitDictionaryId == BJGCPDNMHDH.mUnitToUpgrade.unitDictionaryId)
						{
							GOBCHPOLPIE = current;
							IODGHHFAHJH = current.transform.position;
							CMIKGAOHHPH = current.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(IODGHHFAHJH, ELHGOHGPJCF: false, ENIHCPLOOAE: false, 39f);
							GuiElementSingle<TutorialClickOverlay>.instance.EEMMKEMADFC(IODGHHFAHJH, CMIKGAOHHPH);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				goto IL_0758;
			case 12u:
				FGKIANHNMFF = GuiScreenSingle<ArmyScreen>.instance.GIMBEPIFBLA().AIHMCHBCJDO();
				goto IL_0758;
			case 13u:
			{
				GuiElementSingle<TutorialDialog>.instance.setDebug = true;
				TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM2 = Localization.Localize("Area");
				object[] array2 = new object[0];
				array2[1] = Localization.Localize("Weapon Power This: {0},   Equipped {1}: {2},   Difference: {3}");
				instance2.ShowMenuTutorial(aMKLKMJEMJM2, Localization.LocalizeFormat("SyncTrajectoryRPC", array2), 1784f, TutorialDialog.DODBDLEJOAM.Top, NHEJDPIIOJG: false);
				DHEGKFCAAGP = GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.BFAEJEFLKHN.transform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(DHEGKFCAAGP, new Vector3(616f, 1738f, 1423f), ELHGOHGPJCF: false, ENIHCPLOOAE: false, 743f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.BFAEJEFLKHN, GPCEHFNNCIN: false);
				goto case 14u;
			}
			case 14u:
				if (!GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.JKGHPLKKPLE.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -109;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(1337f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(512f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -10;
				}
				break;
			case 15u:
				MHBNLBPBEGE = GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.HKGGCIGOONK.cachedTransform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(MHBNLBPBEGE, new Vector3(872f, 1218f, 78f), ELHGOHGPJCF: true, ENIHCPLOOAE: true, 1507f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC);
				goto case 16u;
			case 16u:
				if (FGKIANHNMFF.upgradeSlots.unitState != UpgradeSlots.JLANLLEABDC.UnitDelivering)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("vip");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				GuiElementSingle<TutorialDialog>.instance.setDebug = true;
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(1763f);
				ELPHLDJPBNJ = false;
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(656f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 17u:
				GuiElementSingle<TutorialDialog>.instance.BLHPAFCOPMD(Localization.Localize("Wrong_Weapon"), Localization.LocalizeFormat("Arena Wins: ", Localization.Localize("chatmessage")), 1017f, TutorialDialog.DODBDLEJOAM.Left);
				EPGFICIMJJA = GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC.transform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(EPGFICIMJJA, new Vector3(292f, 1344f, 1590f), ELHGOHGPJCF: true, ENIHCPLOOAE: true, 1617f);
				GuiElementSingle<TutorialClickOverlay>.instance.CAIGHMDPBDI(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC, GPCEHFNNCIN: false);
				PECMCAOEMND = true;
				goto case 19u;
			case 18u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("Squad updated , key=squad");
				object[] array = new object[1];
				array[1] = Localization.Localize("currentActivity");
				instance.BLHPAFCOPMD(aMKLKMJEMJM, Localization.LocalizeFormat("ID_NO", array), 1530f, TutorialDialog.DODBDLEJOAM.Left);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(EPGFICIMJJA, new Vector3(1039f, 1944f, 1804f), ELHGOHGPJCF: false, ENIHCPLOOAE: true, 992f);
				GuiElementSingle<TutorialClickOverlay>.instance.MEBFBNDKOGD(GuiScreenSingle<ArmyScreen>.instance.KPEENKKMNDD.EDHCOMHOKDC.MEEKMLJEOBB.GEIOMOLICCC, GPCEHFNNCIN: false);
				goto IL_0c07;
			}
			case 19u:
				if (FGKIANHNMFF.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Delivered || FGKIANHNMFF.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed)
				{
					if (PECMCAOEMND && FGKIANHNMFF.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.UnitDelivering)
					{
						ELPHLDJPBNJ = false;
						PECMCAOEMND = true;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
						GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(263f);
						Singleton<GuiManager>.instance.CMCCOCBIGBB();
						PHDOCKCBJOF = new WaitForSeconds(140f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 36;
						}
						break;
					}
					goto IL_0c07;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("#DANIEL# Price: {0}\nFormatted price: {1}", ELPHLDJPBNJ);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(427f);
				PHDOCKCBJOF = new WaitForSeconds(1171f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 35;
				}
				break;
			case 20u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_0758:
				if (FGKIANHNMFF.unitDictionaryId != BJGCPDNMHDH.mUnitToUpgrade.unitDictionaryId)
				{
					if (GOBCHPOLPIE != null && GOBCHPOLPIE.transform.position != IODGHHFAHJH)
					{
						IODGHHFAHJH = GOBCHPOLPIE.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateTapAnimation(IODGHHFAHJH);
						GuiElementSingle<TutorialClickOverlay>.instance.NNPKOKCJMHL(IODGHHFAHJH, CMIKGAOHHPH, GPCEHFNNCIN: false);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 11;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(1713f);
				goto IL_07a0;
				IL_0c07:
				PHDOCKCBJOF = true;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 95;
				}
				break;
				IL_04cb:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 73;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Request Finished with Error! ");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(975f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 10u;
				IL_07a0:
				Singleton<EventTrackingManager>.instance.RegisterTutorialUnitSelectedEvent("SoldierBehaviourStartShootingNetwork", FKGHFOJFMBP);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(130f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 125;
				}
				break;
			}
			return false;
		}

		[SpecialName]
		private object BLOJDIFOPIA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BGLDNJLBIKM()
		{
			return PHDOCKCBJOF;
		}
	}

	private static TutorialManagerStage5 mInstance;

	public const string id = "Stage5";

	private LevelBehaviour mUnitToUpgrade;

	private int mGoldAdded;

	private int mWarbucksAdded;

	private bool mRewardShowable;

	public static TutorialManagerStage5 instance
	{
		get
		{
			mInstance = mInstance ?? UnityEngine.Object.FindObjectOfType<TutorialManagerStage5>();
			return mInstance;
		}
	}

	public bool wasFinished => data.started;

	public int numberOfGames => (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.TutorialUpgradeUnitAfterGames).FLOATVALUE;

	private bool canRunTutorial => !LevelManager.instance.isLevelUp && !wasFinished && !TutorialManagerStage4.instance.isTutorialRunning;

	protected override void Awake()
	{
		base.Awake();
		mInstance = this;
	}

	protected void OnApplicationPause(bool pause)
	{
		if (pause && base.isTutorialRunning)
		{
			StopTutorial();
		}
	}

	public void RewardCame(int wb, int gold)
	{
		mWarbucksAdded = wb;
		mGoldAdded = gold;
		if (mRewardShowable)
		{
			GuiElementSingle<TutorialDialog>.instance.ShowReward(Localization.Localize("ID_TUTORIAL_UPGRADEUNIT_3"), Localization.Localize("ID_TUTORIAL_UPGRADEUNIT_4"), mWarbucksAdded, mGoldAdded, 0f, TutorialDialog.DODBDLEJOAM.Right);
		}
	}

	public bool TryToStartUnitUpgradeTutorial()
	{
		if (wasFinished)
		{
			return false;
		}
		if (StatsManager.instance.totalGames < numberOfGames)
		{
			return false;
		}
		if (StatsManager.instance.unitsUpgrades > 0 || LevelManager.instance.DeliveringUnit() != null)
		{
			data.started = true;
			Save();
			return false;
		}
		if (!canRunTutorial)
		{
			return false;
		}
		RunTutorial();
		return true;
	}

	public void RunTutorial()
	{
		StopTutorial();
		Singleton<GuiManager>.instance.TurnOnInputCompletly();
		StartCoroutine(RadicalRoutine.Run(UpdateUnitTutorial()));
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

	private LevelBehaviour ChooseUnit()
	{
		return LevelManager.instance.Unit("Google2u.DBUpgradeSlotsAssaulter");
	}

	private void StopTutorial()
	{
		StopAllCoroutines();
		GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
		GuiElementSingle<TutorialClickOverlay>.instance.Hide();
		if (GuiElementSingle<TutorialDialog>.instance.isShowed)
		{
			GuiElementSingle<TutorialDialog>.instance.Hide();
		}
	}

	[DebuggerHidden]
	public IEnumerator UpdateUnitTutorial()
	{
		BAHBKLBBNGA bAHBKLBBNGA = new BAHBKLBBNGA();
		bAHBKLBBNGA.BJGCPDNMHDH = this;
		return bAHBKLBBNGA;
	}
}
